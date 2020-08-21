using System;
using CamadaDados.Contabil;
using BancoDados;
using Utils;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGChequeCompensado
    {
        public static TList_CTB_CFGCheque_Compensado Busca(string Id_cfgctb,
                                                           string Cd_empresa,
                                                           string Cd_contagerent,
                                                           string Cd_contagersai,
                                                           TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cfgctb))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_CFGCTB";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_cfgctb;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contagerent))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contager_entrada";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_contagerent.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contagersai))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contager_saida";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_contagersai.Trim() + "'";
            }
            return new TCD_CTB_CFGCheque_Compensado(banco).Select(vBusca, 0, string.Empty);
        }
       
        public static string Gravar(TRegistro_CTB_CFGCheque_Compensado val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCheque_Compensado qtb_CTB_CFGCheque_Compensado = new TCD_CTB_CFGCheque_Compensado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGCheque_Compensado.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    TpBusca[] filtro = new TpBusca[4];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_contager_saida";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.Cd_contager_saida.Trim() + "'";
                    
                    filtro[2].vNM_Campo = "a.cd_contager_entrada";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Cd_contager_entrada.Trim() + "'";
                    
                    filtro[3].vNM_Campo = "a.tp_movimento";
                    filtro[3].vOperador = "=";
                    filtro[3].vVL_Busca = "'" + val.TP_Movimento.Trim() + "'";
                    object obj = qtb_CTB_CFGCheque_Compensado.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                string retorno = qtb_CTB_CFGCheque_Compensado.Grava(val);
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGCheque_Compensado val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCheque_Compensado qtb_CTB_CFGCheque_Compensado = new TCD_CTB_CFGCheque_Compensado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGCheque_Compensado.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados = banco;

                qtb_CTB_CFGCheque_Compensado.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGCheque_Compensado.deletarBanco_Dados();
            }
        }
    }
}
