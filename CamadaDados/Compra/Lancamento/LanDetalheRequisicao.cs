using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Querys;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_LanDetalheRequisicao : List<TRegistro_LanDetalheRequisicao>
    {
    }
    public class TRegistro_LanDetalheRequisicao
    {
        public decimal Id_Detalhe{get;set;}
        public decimal Id_Requisicao{get;set;}
        public string DS_Produto{get;set;}
        public string Sigla_Unidade{get; set;}
        public decimal Quantidade{get;set;}
        public decimal Vl_Subtotal { get;set;}

        public TRegistro_LanDetalheRequisicao()
        {
            this.Id_Detalhe = 0;
            this.Id_Requisicao = 0;
            this.DS_Produto = "";
            this.Sigla_Unidade = "";
            this.Vl_Subtotal = 0;
            this.Quantidade = 0;
        }
    }

    public class TCD_LanDetalheRequisicao : TDataQuery
    {

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.id_detalhe, a.id_requisicao, a.ds_produto, a.sigla_unidade, a.vl_subtotal, a.quantidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_CMP_DetalheRequisicao a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.id_detalhe asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_LanDetalheRequisicao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanDetalheRequisicao lista = new TList_LanDetalheRequisicao();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanDetalheRequisicao reg = new TRegistro_LanDetalheRequisicao();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Detalhe")))
                        reg.Id_Detalhe = reader.GetDecimal(reader.GetOrdinal("Id_Detalhe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Requisicao")))
                        reg.Id_Requisicao = reader.GetDecimal(reader.GetOrdinal("Id_Requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Subtotal")))
                        reg.Vl_Subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_Subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_LanDetalheRequisicao vRegistro) 
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_DETALHE", vRegistro.Id_Detalhe);
            hs.Add("@P_ID_REQUISICAO", vRegistro.Id_Requisicao);
            hs.Add("@P_DS_PRODUTO", vRegistro.DS_Produto);
            hs.Add("@P_SIGLA_UNIDADE", vRegistro.Sigla_Unidade);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_VL_SUBTOTAL", vRegistro.Vl_Subtotal);
          
            return this.executarProc("IA_CMP_DETALHEREQUISICAO", hs);
        }

        public string Deleta(TRegistro_LanDetalheRequisicao vRegistro) 
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_DETALHE", vRegistro.Id_Detalhe);
            return this.executarProc("EXCLUI_CMP_DETALHEREQUISICAO", hs);
        }
    }
}
