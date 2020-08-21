using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Sementes.Cadastros;

namespace CamadaNegocio.Sementes.Cadastros
{
    public class TCN_TipoAnalise
    {
        public static TList_TipoAnalise Buscar(string Id_analise,
                                               string Ds_analise,
                                               int vTop,
                                               string vNm_campo,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_analise.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_analise";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_analise;
            }
            if (Ds_analise.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_analise";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_analise.Trim() + "%')";
            }

            return new TCD_TipoAnalise(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTipoAnalise(TRegistro_TipoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TipoAnalise qtb_analise = new TCD_TipoAnalise();
            try
            {
                if (banco == null)
                    st_transacao = qtb_analise.CriarBanco_Dados(true);
                else
                    qtb_analise.Banco_Dados = banco;
                //Gravar tipo analise
                string retorno = qtb_analise.GravarTipoAnalise(val);
                if (st_transacao)
                    qtb_analise.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_analise.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo amostra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_analise.deletarBanco_Dados();
            }
        }

        public static string DeletarTipoAnalise(TRegistro_TipoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TipoAnalise qtb_analise = new TCD_TipoAnalise();
            try
            {
                if (banco == null)
                    st_transacao = qtb_analise.CriarBanco_Dados(true);
                else
                    qtb_analise.Banco_Dados = banco;
                //Deletar tipo analise
                qtb_analise.DeletarTipoAnalise(val);
                if (st_transacao)
                    qtb_analise.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_analise.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tipo analise: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_analise.deletarBanco_Dados();
            }
        }
    }
}
