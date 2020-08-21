using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public static class TCN_Lote_X_Servicos
    {
        public static TList_Lote_X_Servicos Buscar(string Id_lote,
                                                   string Id_os,
                                                   string Cd_empresa,
                                                   int vTop,
                                                   string vNm_campo,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (Id_os.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_Lote_X_Servicos(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_LanServico BuscarOsLote(string Id_lote,
                                                int vTop,
                                                string vNm_campo,
                                                BancoDados.TObjetoBanco banco)
        {
            if (Id_lote.Trim() != string.Empty)
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = string.Empty;
                filtro[0].vOperador = "exists";
                filtro[0].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                      "where x.id_os = a.id_os " +
                                      "and x.cd_empresa = a.cd_empresa " +
                                      "and x.id_lote = " + Id_lote + ")";
                return new TCD_LanServico(banco).Select(filtro, vTop, vNm_campo, string.Empty);
            }
            else
                return new TList_LanServico();
        }

        public static string GravarLote_X_Servicos(TRegistro_Lote_X_Servicos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Servicos qtb_lote = new TCD_Lote_X_Servicos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar lote x servico
                string retorno = qtb_lote.GravarLote_X_Servicos(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote servico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string DeletarLote_X_Servicos(TRegistro_Lote_X_Servicos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Servicos qtb_lote = new TCD_Lote_X_Servicos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Deletar Lote Servico
                qtb_lote.DeletarLote_X_Servicos(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote servico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
}
