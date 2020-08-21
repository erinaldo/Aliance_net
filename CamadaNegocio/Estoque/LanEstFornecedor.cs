using CamadaDados.Estoque;
using CamadaDados.Estoque.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Estoque
{
    public class TCN_EstFornecedor
    {
        public static TList_EstFornecedor Buscar(string Cd_empresa,
                                                 string Cd_fornecedor,
                                                 string Cd_produto,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Cd_fornecedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_EstFornecedor(banco).Select(filtro, 0, string.Empty, string.Empty);
        }
        public static string Gravar(TRegistro_EstFornecedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EstFornecedor qtb_est = new TCD_EstFornecedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else qtb_est.Banco_Dados = banco;
                qtb_est.Gravar(val);
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque fornecedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_EstFornecedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EstFornecedor qtb_est = new TCD_EstFornecedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else qtb_est.Banco_Dados = banco;
                qtb_est.Excluir(val);
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estoque fornecedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }
        public static void Importar(List<TRegistro_CadProduto> lProduto,
                                    string Cd_empresa,
                                    string Cd_fornecedor,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EstFornecedor qtb_est = new TCD_EstFornecedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else qtb_est.Banco_Dados = banco;
                //Buscar lista de produtos do fornecedor
                qtb_est.Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_fornecedor",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_fornecedor.Trim() + "'"
                        }
                    }, 0, string.Empty, string.Empty).ForEach(p =>
                    {
                        if (!lProduto.Exists(v => v.CD_Produto.Trim().Equals(p.Cd_produto.Trim())))
                        {
                            p.Quantidade = decimal.Zero;
                            qtb_est.Gravar(p);
                        }
                    });
                lProduto.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.CD_Produto))
                        qtb_est.Gravar(new TRegistro_EstFornecedor
                        {
                            Cd_empresa = Cd_empresa,
                            Cd_fornecedor = Cd_fornecedor,
                            Cd_produto = p.CD_Produto,
                            Quantidade = p.Qt_dias_PrazoGarantia
                        });
                });
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro importar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }
    }
}
