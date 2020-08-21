using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadGrupoProduto
    {
        public static TList_CadGrupoProduto Busca(string vCD_Grupo,
                                                   string vDS_Grupo,
                                                   string vCD_Grupo_Pai,
                                                   BancoDados.TObjetoBanco banco)

        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Grupo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Grupo + "'";
            }

            if (vDS_Grupo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Grupo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Grupo.Trim() + "%')";
            }                        
            
            if (vCD_Grupo_Pai.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Grupo_Pai";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Grupo_Pai + "'";
            };

            return new TCD_CadGrupoProduto(banco).Select(vBusca, 0, "");
        }

        public static string Grava_CadGrupoProduto(TRegistro_CadGrupoProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoProduto cd = new TCD_CadGrupoProduto();
            try
            {



                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar grupo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Deleta_CadGrupoProduto(TRegistro_CadGrupoProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoProduto cd = new TCD_CadGrupoProduto();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir grupo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
