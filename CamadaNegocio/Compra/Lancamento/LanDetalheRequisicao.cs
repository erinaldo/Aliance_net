using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;
using Utils;

namespace CamadaNegocio.Compra.Lancamento
{
   public class TCN_LanDetalheRequisicao
    {
       public static TList_LanDetalheRequisicao Busca(decimal vId_Detalhe,
                                                      decimal vId_Requisicao,
                                                      string vDS_Produto,
                                                      string vSigla_Unidade)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vId_Detalhe > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_Detalhe";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_Detalhe.ToString();
            }
            if (vId_Requisicao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_Requisicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_Requisicao.ToString();
            }
            if (vDS_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Produto + "'";
            }
            if (vSigla_Unidade.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Sigla_Unidade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSigla_Unidade + "'";
            }
            

            TCD_LanDetalheRequisicao cd = new TCD_LanDetalheRequisicao();
            return cd.Select(vBusca, 0, "");
         }

           public static string Grava_LanDetalheRequisicao(TRegistro_LanDetalheRequisicao val, BancoDados.TObjetoBanco banco)
            {
                bool pode_comitar = false;
                string ret = "";

                TCD_LanDetalheRequisicao cd = new TCD_LanDetalheRequisicao();
                if (banco == null)
                {
                    cd.CriarBanco_Dados(true);
                    pode_comitar = true;
                }
                else
                    cd.Banco_Dados = banco;

                try
                {
                    ret = cd.Grava(val);
                    if (pode_comitar)
                        cd.Banco_Dados.Commit_Tran();
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
                return ret;
            }

           public static void Deleta_LanDetalheRequisicao(TRegistro_LanDetalheRequisicao val)
            {
                TCD_LanDetalheRequisicao cd = new TCD_LanDetalheRequisicao();
                cd.Deleta(val);

        }
    }
}
