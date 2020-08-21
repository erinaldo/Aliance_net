using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGCMV
    {
        public static TList_CTB_CFGCMV Buscar(string Id_cfgctb,
                                              string Cd_empresa,
                                              string Cd_movimentacao,
                                              string Cd_produto,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cfgctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cfgctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cfgctb;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_movimentacao;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_CTB_CFGCMV(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGCMV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCMV qtb_cmv = new TCD_CTB_CFGCMV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cmv.CriarBanco_Dados(true);
                else qtb_cmv.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";
                    filtro[1].vNM_Campo = "a.cd_movimentacao";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = val.Cd_movimentacaostr;
                    filtro[2].vNM_Campo = "a.cd_produto";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Cd_produto.Trim() + "'";
                    object obj = qtb_cmv.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                val.Id_cfgctbstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cmv.Gravar(val), "@P_ID_CFGCTB");
                if (st_transacao)
                    qtb_cmv.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cmv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cmv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGCMV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCMV qtb_cmv = new TCD_CTB_CFGCMV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cmv.CriarBanco_Dados(true);
                else qtb_cmv.Banco_Dados = banco;
                qtb_cmv.Excluir(val);
                if (st_transacao)
                    qtb_cmv.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cmv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cmv.deletarBanco_Dados();
            }
        }
    }
}
