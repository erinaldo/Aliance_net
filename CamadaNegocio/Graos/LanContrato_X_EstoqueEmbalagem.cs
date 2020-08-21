using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_Contrato_X_EstoqueEmbalagem
    {
        public static TList_Contrato_X_EstoqueEmbalagem Buscar(string Nr_contrato,
                                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            return new TCD_Contrato_X_EstoqueEmbalagem(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Estoque.TList_RegLanEstoque BuscarEstoque(string Nr_contrato,
                                                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_contrato_x_estoqueembalagem x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.cd_produto = a.cd_produto " +
                                                      "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                      "and x.nr_contrato = " + Nr_contrato + ")";
            }
            return new CamadaDados.Estoque.TCD_LanEstoque(banco).Select(filtro, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato_X_EstoqueEmbalagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_EstoqueEmbalagem qtb_cont = new TCD_Contrato_X_EstoqueEmbalagem();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else
                    qtb_cont.Banco_Dados = banco;
                string retorno = qtb_cont.Gravar(val);
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if(st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque embalagem: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato_X_EstoqueEmbalagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_EstoqueEmbalagem qtb_cont = new TCD_Contrato_X_EstoqueEmbalagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else
                    qtb_cont.Banco_Dados = banco;
                qtb_cont.Excluir(val);
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estoque embalagem: " + ex.Message.Trim()); 
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static void EmprestarEmbalagem(TRegistro_CadContrato rContrato,
                                              CamadaDados.Estoque.TRegistro_LanEstoque rEstoque,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_EstoqueEmbalagem qtb_cont = new TCD_Contrato_X_EstoqueEmbalagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else
                    qtb_cont.Banco_Dados = banco;
                if (rContrato == null)
                    throw new Exception("Não existe contrato informado para emprestar embalagens.");
                if (rEstoque == null)
                    throw new Exception("Não existe registro estoque informado para emprestar embalagens.");
                //Gravar Estoque
                CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_cont.Banco_Dados);
                //Gravar contrato x estoque
                Gravar(new TRegistro_Contrato_X_EstoqueEmbalagem()
                {
                    Cd_empresa = rEstoque.Cd_empresa,
                    Cd_produto = rEstoque.Cd_produto,
                    Id_lanctoestoque = rEstoque.Id_lanctoestoque,
                    Nr_contrato = rContrato.Nr_contrato.Value,
                    Ds_observacao = rEstoque.Ds_observacao
                }, qtb_cont.Banco_Dados);
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro emprestar embalagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static void DevolverEmbalagem(TRegistro_CadContrato rContrato,
                                             CamadaDados.Estoque.TRegistro_LanEstoque rEstoque,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_EstoqueEmbalagem qtb_cont = new TCD_Contrato_X_EstoqueEmbalagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else
                    qtb_cont.Banco_Dados = banco;
                if (rContrato == null)
                    throw new Exception("Não existe contrato informado para devolver embalagens.");
                if (rEstoque == null)
                    throw new Exception("Não existe registro estoque informado para devolver embalagens.");
                //Gravar Estoque
                CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_cont.Banco_Dados);
                //Gravar contrato x estoque
                Gravar(new TRegistro_Contrato_X_EstoqueEmbalagem()
                {
                    Cd_empresa = rEstoque.Cd_empresa,
                    Cd_produto = rEstoque.Cd_produto,
                    Id_lanctoestoque = rEstoque.Id_lanctoestoque,
                    Nr_contrato = rContrato.Nr_contrato.Value,
                    Ds_observacao = rEstoque.Ds_observacao
                }, qtb_cont.Banco_Dados);
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver embalagens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }
    }
}
