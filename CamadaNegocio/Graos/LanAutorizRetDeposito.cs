using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_AutorizRetDeposito
    {
        public static TList_AutorizRetDeposito Buscar(string Id_autoriz,
                                                      string Nr_contrato,
                                                      string Cd_contratante,
                                                      string Cd_unidade,
                                                      string Dt_ini,
                                                      string Dt_fin,
                                                      string Ds_observacao,
                                                      string St_registro,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_autoriz))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_autoriz";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_autoriz;
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_contratante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contratante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_unidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_unidade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_unidade.Trim() + "'";
            }
            if((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(Ds_observacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_Autoriz_RetDeposito(banco).Select(filtro, 0, string.Empty);
        }

        public static bool AutorizComMovimentacao(string Id_autoriz,
                                                  BancoDados.TObjetoBanco banco)
        {
            bool retorno = false;
            object obj = new CamadaDados.Balanca.TCD_LanPesagemGraos(banco).BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.ID_Autoriz",
                        vOperador = "=",
                        vVL_Busca = Id_autoriz
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "1");
            if (obj != null)
                retorno = obj.ToString().Trim().Equals("1");
            if (!retorno)
            {
                obj = new CamadaDados.Balanca.TCD_LanAplicacaoPedido(banco).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_autoriz",
                            vOperador = "=",
                            vVL_Busca = Id_autoriz
                        }
                    }, "1");
                if (obj != null)
                    retorno = obj.ToString().Trim().Equals("1");
            }
            return retorno;
        }

        public static string Gravar(TRegistro_AutorizRetDeposito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Autoriz_RetDeposito qtb_autoriz = new TCD_Autoriz_RetDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_autoriz.CriarBanco_Dados(true);
                else
                    qtb_autoriz.Banco_Dados = banco;
                string retorno = qtb_autoriz.Gravar(val);
                val.Id_autoriz = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_AUTORIZ"));
                if (st_transacao)
                    qtb_autoriz.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_autoriz.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar autorização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_autoriz.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AutorizRetDeposito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Autoriz_RetDeposito qtb_autoriz = new TCD_Autoriz_RetDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_autoriz.CriarBanco_Dados(true);
                else
                    qtb_autoriz.Banco_Dados = banco;
                val.St_registro = "C";//Exclusao logica do registro
                string retorno = Gravar(val, qtb_autoriz.Banco_Dados);
                if (st_transacao)
                    qtb_autoriz.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_autoriz.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir autorizacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_autoriz.deletarBanco_Dados();
            }
        }
    }
}
