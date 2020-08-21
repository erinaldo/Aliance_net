using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Compra;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Compra
{
    public class TCN_Cad_Fornecedor_X_GrupoItem
    {
        public static TList_Cad_Fornecedor_X_GrupoItem Busca(string vCD_Clifor, 
                                                             string vCD_Grupo, 
                                                             int vTop,
                                                             string vNm_campo,
                                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Clifor.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }
            if (vCD_Grupo.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Grupo.Trim() + "'";
            }
            return new TCD_Cad_Fornecedor_X_GrupoItem(banco).Select(vBusca, vTop, string.Empty);
        }

        public static string GravaFornecedor_X_GrupoItem(TRegistro_Cad_Fornecedor_X_GrupoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Fornecedor_X_GrupoItem qtb_cad = new TCD_Cad_Fornecedor_X_GrupoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else
                    qtb_cad.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_cad.Grava(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }

        public static string DeletaFornecedor_X_GrupoItem(TRegistro_Cad_Fornecedor_X_GrupoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Fornecedor_X_GrupoItem qtb_cad = new TCD_Cad_Fornecedor_X_GrupoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else
                    qtb_cad.Banco_Dados = banco;
                qtb_cad.Deleta(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
    }
}
