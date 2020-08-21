using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CFGImpCheque
    {
        public static TList_CFGImpCheque Buscar(string Cd_banco,
                                                decimal Linha,
                                                decimal Coluna,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (Linha > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.linha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Linha.ToString("N0", new System.Globalization.CultureInfo("en-US", true));
            }
            if (Coluna > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.coluna";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Coluna.ToString("N0", new System.Globalization.CultureInfo("en-US", true));
            }

            return new TCD_CFGImpCheque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGImpCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGImpCheque qtb_cfg = new TCD_CFGImpCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                //Verificar se existe configuracao para o banco na linha e coluna
                if (val.Id_campo == null)
                {
                    object obj = new TCD_CFGImpCheque(qtb_cfg.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_banco",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_banco.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.linha",
                                            vOperador = "=",
                                            vVL_Busca = val.Linha.ToString("N0", new System.Globalization.CultureInfo("en-US", true))
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.coluna",
                                            vOperador = "=",
                                            vVL_Busca = val.Coluna.ToString("N0", new System.Globalization.CultureInfo("en-US", true))
                                        }
                                    }, "a.id_campo");
                    if (obj != null)
                        val.Id_campo = decimal.Parse(obj.ToString());
                }
                val.Id_campostr = CamadaDados.TDataQuery.getPubVariavel(qtb_cfg.Gravar(val), "@P_ID_CAMPO");
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_campostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGImpCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGImpCheque qtb_cfg = new TCD_CFGImpCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_campostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config.:" + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
