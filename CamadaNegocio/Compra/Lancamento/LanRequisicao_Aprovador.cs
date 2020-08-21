using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_LanRequisicao_Aprovador
    {
        public static TList_LanCMP_Requisicao Busca(decimal vID_Requisicao,
                                                   string vCD_CCusto_Busca,
                                                   string vCD_Produto_Busca,
                                                   string vCD_Requisitante,
                                                   string vST_AguardandoAprovacao,
                                                   string vST_aprovada,
                                                   string vST_reprovada,
                                                   string vST_Baixa,
                                                   string vST_Media,
                                                   string vST_Urgente,
                                                   bool vRequisicao_Fechada)
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
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Requisitante";
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


            if (vST_Baixa.Trim().Equals("Baixa") || (vST_Media.Trim().Equals("Normal")) || (vST_Urgente.Trim().Equals("Urgente")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Prioridade";
                vBusca[vBusca.Length - 1].vVL_Busca = "in";
                vBusca[vBusca.Length - 1].vOperador = "(";

                string virg = "";

                if (vST_Baixa.Trim().Equals("Baixa"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'B'";
                    virg = ",";
                };

                if (vST_Media.Trim().Equals("Normal"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'N'";
                    virg = ",";
                };
                if (vST_Urgente.Trim().Equals("Urgente"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca += virg + "'U'";
                    virg = ",";
                };

                vBusca[vBusca.Length - 1].vVL_Busca += ")";
            }

            if (vRequisicao_Fechada == true)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "IsNull(a.qtd_aprovada, 0)";
                vBusca[vBusca.Length - 1].vVL_Busca = "isnull((select IsNull(sum(d.qtd_saida),0) from tb_amx_Entregarequisicao a " +
                                                      " inner join tb_cmp_requisicao b on (b.id_requisicao = a.id_requisicao) " +
                                                      " inner join tb_amx_movimento c on (c.id_movimento = a.id_movimento) " +
                                                      " inner join tb_est_estoque d on (d.id_lanctoestoque = c.id_lanctoestoque and d.cd_produto = c.cd_produto and d.cd_empresa = c.cd_empresa)),0)";
                vBusca[vBusca.Length - 1].vOperador = "<>";
            }

            TCD_LanCMP_Requisicao cd = new TCD_LanCMP_Requisicao();
            TList_LanCMP_Requisicao lRequisicao = cd.Select(vBusca, 0, "");
            //Para cada requisição, buscar os detalhes
            for (int i = 0; i < lRequisicao.Count; i++)
                lRequisicao[i].lDetalheRequisicao = TCN_LanDetalheRequisicao.Busca(0, lRequisicao[i].ID_Requisicao.Value, "", "");
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
            catch (System.Data.SqlClient.SqlException ex)
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
    }
}
