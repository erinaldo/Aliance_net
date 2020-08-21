using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra;

namespace CamadaNegocio.Compra
{
    public class TCN_TpRequisicao
    {
        public static TList_TpRequisicao Buscar(string id_tprequisicao,
                                                string ds_tprequisicao,
                                                string tp_requisicao,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_tprequisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tprequisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_tprequisicao;
            }
            if (!string.IsNullOrEmpty(ds_tprequisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tprequisicao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_tprequisicao.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(tp_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_requisicao.Trim() + "'";
            }
            return new TCD_TpRequisicao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpRequisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpRequisicao qtb_tp = new TCD_TpRequisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                val.Id_tprequisicaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_tp.Gravar(val), "@P_ID_TPREQUISICAO");
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_tprequisicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpRequisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpRequisicao qtb_tp = new TCD_TpRequisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_tprequisicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TpRequisicao_X_GrupoProd
    {
        public static TList_TpRequisicao_X_GrupoProd Buscar(string id_tprequisicao,
                                                            string Cd_grupo,
                                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_tprequisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tprequisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_tprequisicao;
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            return new TCD_TpRequisicao_X_GrupoProd(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpRequisicao_X_GrupoProd val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpRequisicao_X_GrupoProd qtb_tp = new TCD_TpRequisicao_X_GrupoProd();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Gravar(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpRequisicao_X_GrupoProd val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpRequisicao_X_GrupoProd qtb_tp = new TCD_TpRequisicao_X_GrupoProd();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_tprequisicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
