using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_ProdutoDerivado
    {
        public static TList_ProdutoDerivado Buscar(string Cd_empresa,
                                                   string Id_ticket,
                                                   string Tp_pesagem,
                                                   string Cd_produto,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }

            return new TCD_ProdutoDerivado().Select(filtro, 0, string.Empty);
        }

        public static void Gravar(TRegistro_LanPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProdutoDerivado qtb_prod = new TCD_ProdutoDerivado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                val.lProdutoDerivado.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Tp_pesagem = val.Tp_pesagem;
                        p.Id_ticket = val.Id_ticket;
                        if (p.Qtd_embalagem > 0)
                            Gravar(p, qtb_prod.Banco_Dados);
                        else
                            Excluir(p, qtb_prod.Banco_Dados);
                    });
                //Gravar quantidade total embalagem na pesagem
                val.Qtd_embalagem = val.lProdutoDerivado.Sum(p => p.Qtd_embalagem);
                new TCD_LanPesagem(qtb_prod.Banco_Dados).GravaPesagem(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar produto derivado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_ProdutoDerivado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProdutoDerivado qtb_prod = new TCD_ProdutoDerivado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                string retorno = qtb_prod.Gravar(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProdutoDerivado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProdutoDerivado qtb_prod = new TCD_ProdutoDerivado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                qtb_prod.Excluir(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }
    }
}
