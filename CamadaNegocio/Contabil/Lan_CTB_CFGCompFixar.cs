using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGCompFixar
    {
        public static TList_CTB_CFGCompFixacao Buscar(string Id_cfgctb,
                                                      string Cd_empresa,
                                                      string Tp_registro,
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
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_registro.Trim() + "'";
            }
            
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_CTB_CFGCompFixacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGCompFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCompFixacao qtb_cfg = new TCD_CTB_CFGCompFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";
                                        
                    filtro[1].vNM_Campo = "a.cd_produto";
                    filtro[1].vOperador = string.IsNullOrEmpty(val.Cd_produto) ? "is" : "=";
                    filtro[1].vVL_Busca = string.IsNullOrEmpty(val.Cd_produto) ? "null" : "'" + val.Cd_produto.Trim() + "'";

                    filtro[2].vNM_Campo = "a.tp_registro";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Tp_registro.Trim() + "'";
                    object obj = qtb_cfg.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                val.Id_cfgctbstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cfg.Gravar(val), "@P_ID_CFGCTB");
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGCompFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCompFixacao qtb_cfg = new TCD_CTB_CFGCompFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
