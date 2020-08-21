using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_PRD_Custo_STDFixosMPrima : List<TRegistro_Cad_PRD_Custo_STDFixosMPrima>
    { }

    public class TRegistro_Cad_PRD_Custo_STDFixosMPrima
    {
        public string Cd_produto
        { get; set; }

        public string Ds_produto
        { get; set; }

        private decimal? id_custo;
        public decimal? Id_custo
        {
            get 
            {
                if (id_custo == 0)
                    return null;
                else
                    return id_custo; 
            }
            set 
            { 
                id_custo = value;
                id_custostring = value.ToString();
            }
        }

        private string id_custostring;
        public string Id_custostring
        {
            get { return id_custostring; }
            set 
            { 
                id_custostring = value;
                try
                {
                    id_custo = Convert.ToDecimal(value);
                }
                catch { id_custo = null; }
            }
        }

        public string St_macro
        { get; set; }

        public decimal Vl_custostd
        { get; set; }

        public decimal Pc_custostd
        { get; set; }

        public decimal Vl_custofixo
        { get; set; }

        public decimal Pc_custovariavel
        { get; set; }
    }

    public class TCD_PRD_Custo_STDFixosMPrima : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.cd_produto, b.ds_produto, ");
                sql.AppendLine("a.id_custo, c.ds_custo, a.vl_custostd, a.pc_custostd ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_prd_custo_stdfixosmprima a ");
            sql.AppendLine("inner join tb_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_prd_custos c ");
            sql.AppendLine("on a.id_custo = c.id_custo ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaTotalizarCustoFixo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_produto, c.posicao, isNull(c.st_macro, 'N') as st_macro, ");
            sql.AppendLine("isNull(sum(isNull(a.vl_custoSTD,0)),0) + isnull(c.vl_custoMercado,0) as vl_custofixo, ");
            sql.AppendLine("isNull(sum(isNull(a.pc_custostd,0)),0) as pc_custovariavel ");
            sql.AppendLine("from tb_prd_custo_stdfixosmprima a ");
            sql.AppendLine("inner join tb_prd_custos b ");
            sql.AppendLine("on a.id_custo = b.id_custo ");
            sql.AppendLine("inner join tb_prd_cfgmprima_adubo c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("group by a.cd_produto, c.posicao, c.vl_custoMercado, c.st_macro ");
            sql.AppendLine("order by isNull(c.st_macro, 'N') desc, c.posicao asc ");
            return sql.ToString();
        }

        public TList_PRD_Custo_STDFixosMPrima BuscarTotalizarCustoFixo()
        {
            DataTable tabela = this.ExecutarBusca(this.SqlCodeBuscaTotalizarCustoFixo(), null);
            if (tabela != null)
            {
                TList_PRD_Custo_STDFixosMPrima lista = new TList_PRD_Custo_STDFixosMPrima();
                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    TRegistro_Cad_PRD_Custo_STDFixosMPrima reg = new TRegistro_Cad_PRD_Custo_STDFixosMPrima();
                    reg.Cd_produto = tabela.Rows[i]["CD_Produto"].ToString();
                    reg.St_macro = tabela.Rows[i]["ST_Macro"].ToString();
                    reg.Vl_custofixo = Convert.ToDecimal(tabela.Rows[i]["Vl_custofixo"].ToString());
                    reg.Pc_custovariavel = Convert.ToDecimal(tabela.Rows[i]["PC_CustoVariavel"].ToString());
                    lista.Add(reg);
                }
                return lista;
            }
            else
                return null;
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PRD_Custo_STDFixosMPrima Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PRD_Custo_STDFixosMPrima lista = new TList_PRD_Custo_STDFixosMPrima();
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
                    TRegistro_Cad_PRD_Custo_STDFixosMPrima reg = new TRegistro_Cad_PRD_Custo_STDFixosMPrima();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Custo"))))
                        reg.Id_custo = reader.GetDecimal(reader.GetOrdinal("ID_Custo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Custo"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Custo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_CustoSTD"))))
                        reg.Vl_custostd = reader.GetDecimal(reader.GetOrdinal("Vl_CustoSTD"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_CustoSTD"))))
                        reg.Pc_custostd = reader.GetDecimal(reader.GetOrdinal("PC_CustoSTD"));
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

        public string GravarSTDCustos(TRegistro_Cad_PRD_Custo_STDFixosMPrima val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            hs.Add("@P_VL_CUSTOSTD", val.Vl_custostd);
            hs.Add("@P_PC_CUSTOSTD", val.Pc_custostd);
            return this.executarProc("IA_PRD_CUSTO_STDFIXOSMPRIMA", hs);
        }
    }

}
