using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_Apontamento_Estoque
    {
        public static TList_Apontamento_Estoque Buscar(string Id_apontamento,
                                                       string Cd_empresa,
                                                       string Cd_produto,
                                                       string Id_lanctoestoque,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_apontamento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Id_lanctoestoque.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lanctoestoque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoestoque;
            }
            return new TCD_Apontamento_Estoque(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_Apontamento_Estoque BuscarEstMPrima(string Id_apontamento,
                                                                BancoDados.TObjetoBanco banco)
        {
            return new TCD_Apontamento_Estoque(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_prd_apontamentoproducao x "+
                                    "inner join tb_prd_apontamento_mprima y "+
                                    "on x.id_apontamento = y.id_apontamento "+
                                    "where x.id_apontamento = a.id_apontamento "+
                                    "and y.cd_produto = a.cd_produto "+
                                    "and x.id_apontamento = " + Id_apontamento + ")"
                    }
                }, 0, string.Empty);
        }

        public static CamadaDados.Estoque.TList_RegLanEstoque BuscarEstoque(string Id_apontamento,
                                                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 from tb_prd_apontamento_x_estoque x " +
                                  " where x.cd_empresa = a.cd_empresa " +
                                  " and x.cd_produto = a.cd_produto " +
                                  " and x.id_lanctoestoque = a.id_lanctoestoque " +
                                  " and x.id_apontamento = " + Id_apontamento.Trim() + ")";
            return new CamadaDados.Estoque.TCD_LanEstoque(banco).Select(filtro, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string GravarApontamentoEstoque(TRegistro_Apontamento_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_Estoque qtb_apontamento = new TCD_Apontamento_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                //Gravar Apontamento Estoque
                string retorno = qtb_apontamento.GravarApontamentoEstoque(val);
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }

        public static string DeletarApontamentoEstoque(TRegistro_Apontamento_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_Estoque qtb_apontamento = new TCD_Apontamento_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                //Cancelar lancamentos de estoque
                CamadaNegocio.Estoque.TCN_LanEstoque.DeletarEstoque(
                    new CamadaDados.Estoque.TRegistro_LanEstoque()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Cd_produto = val.Cd_produto,
                        Id_lanctoestoque = val.Id_lanctoestoque.Value
                    }, qtb_apontamento.Banco_Dados);
                //Deletar apontamento estoque
                qtb_apontamento.DeletarApontamentoEstoque(val);
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }
    }
}
