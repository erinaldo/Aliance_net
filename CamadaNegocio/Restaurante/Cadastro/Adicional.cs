using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_Adicionais
    {

        public static TList_Adicionais Buscar(
                                          string cd_grupo_adicional, 
                                          string cd_produto_adicional, 
                                          string cd_produto, 
                                          BancoDados.TObjetoBanco banco) 
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_grupo_adicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_grupo_adicional.Trim();
            }
            if (!string.IsNullOrEmpty(cd_produto_adicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_produto_adicional.Trim();
            }
            if (!string.IsNullOrEmpty(cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1); 
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_produto x where a.cd_grupo =  x.cd_grupo and x.cd_produto = " +cd_produto.Trim() + ")";
            }
            return new TCD_Adicionais(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Adicionais val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adicionais qtb_orc = new TCD_Adicionais();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                string ret = string.Empty;

                if (string.IsNullOrEmpty(val.CD_Grupo_prod))
                    ret = qtb_orc.Gravar(val);
                else
                {
                    TList_CadProduto lprod = new TList_CadProduto();
                    lprod = TCN_CadProduto.Busca(string.Empty, string.Empty, 
                        val.CD_Grupo_prod, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, 0,
                        string.Empty, string.Empty, null);
                    lprod.ForEach(p =>
                    {
                        val.CD_Produto  = p.CD_Produto;
                        ret = qtb_orc.Gravar(val);
                    });

                }

                


               // val.Id_Local = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_Local"));

                

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.CD_Grupo.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar adicional: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Adicionais val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adicionais qtb_orc = new TCD_Adicionais();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir adicional: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
}
