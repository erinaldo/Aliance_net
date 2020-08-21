using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_PercDesconto : List<TRegistro_PercDesconto>, IComparer<TRegistro_PercDesconto>
    {
        #region IComparer<TRegistro_PercDesconto> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_PercDesconto()
        { }

        public TList_PercDesconto(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PercDesconto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PercDesconto x, TRegistro_PercDesconto y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    
    public class TRegistro_PercDesconto
    {
        
        public string Cd_tabeladesconto
        { get; set; }
        
        public string Ds_tabeladesconto
        { get; set; }
        
        public string Cd_tipoamostra
        { get; set; }
        
        public string Ds_tipoamostra
        { get; set; }
        
        public decimal Pc_resultado
        { get; set; }
        
        public decimal Pc_descestoque
        { get; set; }
        
        public decimal Pc_descpagto
        { get; set; }
        
        public decimal Taxa_secagem
        { get; set; }
        
        public string St_registro
        { get; set; }

        public TRegistro_PercDesconto()
        {
            this.Cd_tabeladesconto = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.Cd_tipoamostra = string.Empty;
            this.Ds_tipoamostra = string.Empty;
            this.Pc_resultado = decimal.Zero;
            this.Pc_descestoque = decimal.Zero;
            this.Pc_descpagto = decimal.Zero;
            this.Taxa_secagem = decimal.Zero;
            this.St_registro = "A";
        }
    }

    public class TCD_PercDesconto : TDataQuery
    {
        public TCD_PercDesconto()
        { }

        public TCD_PercDesconto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_TabelaDesconto, b.ds_TabelaDesconto, ");
                sql.AppendLine("a.CD_TipoAmostra, a.PC_DescEstoque, c.ds_amostra,");
                sql.AppendLine("a.PC_DescPagto, a.PC_Resultado, a.ST_Registro, a.Taxa_Secagem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_GRO_Perc_Desconto a ");
            sql.AppendLine("inner join TB_GRO_TabelaDesconto b ");
            sql.AppendLine("On a.CD_TabelaDesconto = b.CD_TabelaDesconto");
            sql.AppendLine("inner join TB_GRO_Amostra c ");
            sql.AppendLine("On a.CD_TipoAmostra = c.CD_tipoAmostra");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            sql.AppendLine("order by a.pc_resultado ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PercDesconto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PercDesconto lista = new TList_PercDesconto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_PercDesconto reg = new TRegistro_PercDesconto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra")))
                        reg.Cd_tipoamostra = reader.GetString(reader.GetOrdinal("cd_tipoamostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_amostra")))
                        reg.Ds_tipoamostra = (reader.GetString(reader.GetOrdinal("ds_amostra")));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_resultado")))
                        reg.Pc_resultado = reader.GetDecimal(reader.GetOrdinal("Pc_resultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_descestoque")))
                        reg.Pc_descestoque = reader.GetDecimal(reader.GetOrdinal("Pc_descestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_DescPagto")))
                        reg.Pc_descpagto = reader.GetDecimal(reader.GetOrdinal("Pc_DescPagto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Taxa_secagem")))
                        reg.Taxa_secagem = reader.GetDecimal(reader.GetOrdinal("Taxa_secagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_PercDesconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);
            hs.Add("@P_PC_RESULTADO", val.Pc_resultado);
            hs.Add("@P_PC_DESCESTOQUE", val.Pc_descestoque);
            hs.Add("@P_PC_DESCPAGTO", val.Pc_descpagto);
            hs.Add("@P_TAXA_SECAGEM", val.Taxa_secagem);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_GRO_PERC_DESCONTO", hs);
        }

        public string Excluir(TRegistro_PercDesconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);
            hs.Add("@P_PC_RESULTADO", val.Pc_resultado);

            return this.executarProc("EXCLUI_GRO_PERC_DESCONTO", hs);
        }
    }
}
