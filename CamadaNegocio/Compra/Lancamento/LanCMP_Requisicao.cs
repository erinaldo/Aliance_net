using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;
using Utils;
using CamadaNegocio.Almoxarifado;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_LanCMP_Requisicao
    {
        public static TList_LanCMP_Requisicao Busca(decimal vID_Requisicao,
                                                    string vCD_Empresa_Busca,
                                                    string vCD_CCusto_Busca,
                                                    string vCD_Produto_Busca,
                                                    string vST_AguardandoAprovacao,
                                                    string vST_aprovada,
                                                    string vST_reprovada,
                                                    string vST_Negociacao,
                                                    string vST_OrdemCompra,
                                                    string vST_PedidoConfirmado,
                                                    string vST_EmEstoque,
                                                    string vDt_Inicio,
                                                    string vDt_Fim,
                                                    string vST_Prioridade,
                                                    string vCD_Grupo_Busca,
                                                    bool vRequisicao_Fechada,
                                                    bool vRequisicao_Aprovacao)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Requisicao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Requisicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Requisicao.ToString();
            }
            if (vCD_Empresa_Busca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa_Busca + "'";
            }
            if (vCD_CCusto_Busca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CCusto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CCusto_Busca + "'";
            }
            if (vCD_Produto_Busca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto_Busca + "'";
            }

            if ((vST_reprovada.Trim().Equals("S")) || (vST_AguardandoAprovacao.Trim().Equals("S")) || (vST_aprovada.Trim().Equals("S")) || (vST_EmEstoque.Trim().Equals("S")) || (vST_Negociacao.Trim().Equals("S")) || (vST_OrdemCompra.Trim().Equals("S")) || (vST_PedidoConfirmado.Trim().Equals("S"))) 
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Requisicao";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(";
              
                string virg = "";

                if (vST_reprovada.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'RE'";
                    virg = ",";
                };

                if (vST_AguardandoAprovacao.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'AA'";
                    virg = ",";
                };
                if (vST_aprovada.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'AP'";
                    virg = ",";
                };
                if (vST_EmEstoque.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'EE'";
                    virg = ",";
                };
                if (vST_Negociacao.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'NG'";
                    virg = ",";
                };
                if (vST_OrdemCompra.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'OC'";
                    virg = ",";
                };
                if (vST_PedidoConfirmado.Trim().Equals("S"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'PE'";
                    virg = ",";
                }
                vBusca[vBusca.Length - 1].vVL_Busca += ")";
            }

            if ((vDt_Inicio.Trim() != "") && (vDt_Inicio.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Dt_Requisicao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDt_Inicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if ((vDt_Fim.Trim() != "") && (vDt_Fim.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Dt_Requisicao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDt_Fim + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }

            if (vST_Prioridade != "")  
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Prioridade";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Prioridade + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vRequisicao_Fechada == true)
            {
              //  Array.Resize(ref vBusca, vBusca.Length + 1);
            //    vBusca[vBusca.Length - 1].vNM_Campo = "IsNull(a.qtd_aprovada, 0)";
              //  vBusca[vBusca.Length - 1].vVL_Busca = "isnull((select IsNull(sum(d.qtd_saida),0) from tb_amx_Entregarequisicao a " +
           //   //                                        " inner join tb_cmp_requisicao b on (b.id_requisicao = a.id_requisicao) " +
                //                                      " inner join tb_amx_movimento c on (c.id_movimento = a.id_movimento) " +
             //                                         " inner join tb_est_estoque d on (d.id_lanctoestoque = c.id_lanctoestoque and d.cd_produto = c.cd_produto and d.cd_empresa = c.cd_empresa)),0)";
              //  vBusca[vBusca.Length - 1].vOperador = "<>";
            }
            if (vCD_Grupo_Busca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "gru.CD_Grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Grupo_Busca + "'";
            }

            if (vRequisicao_Aprovacao)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Requisicao";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(";
                vBusca[vBusca.Length - 1].vVL_Busca += "'RE',";
                vBusca[vBusca.Length - 1].vVL_Busca += "'AP'";
                vBusca[vBusca.Length - 1].vVL_Busca += ")";
            }

            TCD_LanCMP_Requisicao cd = new TCD_LanCMP_Requisicao();
            TList_LanCMP_Requisicao lRequisicao = cd.Select(vBusca, 0, "");
            //Para cada requisição, buscar os detalhes
            for (int i = 0; i < lRequisicao.Count; i++)
            {
                lRequisicao[i].lDetalheRequisicao = TCN_LanDetalheRequisicao.Busca(0, lRequisicao[i].ID_Requisicao.Value, "", "");
                lRequisicao[i].lEntregaRequisicao = TCN_LanEntregaRequisicao.Buscar(0, 0, lRequisicao[i].ID_Requisicao.Value);
            }
            return lRequisicao;
        }

        public static string Grava_LanCMP_Requisicao(TRegistro_LanCMP_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool pode_comitar = false;
            TCD_LanCMP_Requisicao cd = new TCD_LanCMP_Requisicao();
            try
            {
                if (banco == null)
                {
                    cd.CriarBanco_Dados(true);
                    pode_comitar = true;
                }
                else
                    cd.Banco_Dados = banco;

                //Grava requisicao
                string retreq = cd.Grava(val);
                for (int x = 0; x < val.lDetalheRequisicao.Count; x++)
                {
                    val.lDetalheRequisicao[x].Id_Requisicao = Convert.ToDecimal(Querys.TDataQuery.getPubVariavel(retreq, "@P_ID_REQUISICAO"));
                    TCN_LanDetalheRequisicao.Grava_LanDetalheRequisicao(val.lDetalheRequisicao[x], cd.Banco_Dados);
                }
                if (pode_comitar)
                    cd.Banco_Dados.Commit_Tran();
                return retreq;
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                if (pode_comitar)
                    cd.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";

            }
            finally
            {
                if (pode_comitar)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Deleta_LanCMP_Requisicao(TRegistro_LanCMP_Requisicao val)
        {
            TCD_LanCMP_Requisicao cd = new TCD_LanCMP_Requisicao();
            cd.Deleta(val);

        }

        public static TList_LanCMP_Requisicao BuscaLanAprovador(decimal vID_Requisicao,
                                                               string vCD_CCusto_Busca,
                                                               string vCD_Produto_Busca,
                                                               string vCD_Requisitante,
                                                               string vST_AguardandoAprovacao,
                                                               string vST_aprovada,
                                                               string vST_reprovada,
                                                               //string vPrioridade)
                                                               string vST_Baixa,
                                                               string vST_Media,
                                                               string vST_Urgente)
            {

                TpBusca[] vBusca = new TpBusca[0];

                if (vID_Requisicao > 0)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Requisicao";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = vID_Requisicao.ToString();
                }

                if (vCD_CCusto_Busca.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CCusto";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CCusto_Busca + "'";
                }
                if (vCD_Produto_Busca.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto_Busca + "'";
                }
                if (vCD_Requisitante.Trim() != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor_Requisitante";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Requisitante + "'";
                }

                if ((vST_reprovada.Trim().Equals("S")) || (vST_AguardandoAprovacao.Trim().Equals("S")) || (vST_aprovada.Trim().Equals("S")))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Requisicao";
                    vBusca[vBusca.Length - 1].vOperador = "in";
                    vBusca[vBusca.Length - 1].vVL_Busca = "(";

                    string virg = "";

                    if (vST_reprovada.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'RE'";
                        virg = ",";
                    };

                    if (vST_AguardandoAprovacao.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'AA'";
                        virg = ",";
                    };
                    if (vST_aprovada.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'AP'";
                        virg = ",";
                    };

                    vBusca[vBusca.Length - 1].vVL_Busca += ")";
                }
            
                if (vST_Baixa.Trim().Equals("S") || (vST_Media.Trim().Equals("S")) || (vST_Urgente.Trim().Equals("S")))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Prioridade";
                    vBusca[vBusca.Length - 1].vVL_Busca = "(";
                    vBusca[vBusca.Length - 1].vOperador = "in";

                    string virg = "";

                    if (vST_Baixa.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'B'";
                        virg = ",";
                    };

                    if (vST_Media.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'N'";
                        virg = ",";
                    };
                    if (vST_Urgente.Trim().Equals("S"))
                    {
                        vBusca[vBusca.Length - 1].vVL_Busca += virg + "'U'";
                        virg = ",";
                    };

                    vBusca[vBusca.Length - 1].vVL_Busca += ")";
                }
             
                TCD_LanCMP_Requisicao cd = new TCD_LanCMP_Requisicao();
                TList_LanCMP_Requisicao lRequisicao = cd.Select(vBusca, 0, "");

                for (int i = 0; i < lRequisicao.Count; i++)
                    lRequisicao[i].lDetalheRequisicao = TCN_LanDetalheRequisicao.Busca(0, lRequisicao[i].ID_Requisicao.Value, "", "");
                return lRequisicao;
            }
    }
}
