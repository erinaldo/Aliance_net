using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{
    public class TRegistro_CadImposto: ICloneable
    {
        private string cd_impostoSt;
        public string Cd_impostoSt
        {
            get { return this.cd_impostoSt; }

            set
            {
                this.cd_impostoSt = value;
                try
                { this.cd_imposto = Convert.ToDecimal(value); }
                catch { this.cd_imposto = null; } 
            }

        }
        private decimal? cd_imposto;
        public decimal? Cd_imposto 
        {
            get
            {
                if (this.cd_imposto == 0)
                { return null; }
                else
                    return this.cd_imposto;
            }
            set
            {
                this.cd_imposto = value;
                this.cd_impostoSt = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        public string ds_imposto { get; set; }
        public string Sigla { get; set; }
        public string st_registro { get; set; }
        public bool St_PIS { get; set; } = false;
        public bool St_Cofins { get; set; } = false;
        public bool St_ICMS { get; set; } = false;
        public bool St_IPI { get; set; } = false;
        public bool St_ISSQN { get; set; } = false;
        public bool St_CSLL { get; set; } = false;
        public bool St_IRRF { get; set; } = false;
        public bool St_INSS { get; set; } = false;
        public bool St_II { get; set; } = false;
        public bool St_Funrural { get; set; } = false;
        public bool St_Senar { get; set; } = false;

        public TRegistro_CadImposto()
        {
            cd_imposto = null;
            cd_impostoSt = string.Empty;
            ds_imposto = string.Empty;
            Sigla = string.Empty;
            st_registro = "A";
        }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
    public class TList_CadImposto : List<TRegistro_CadImposto>, IComparer<TRegistro_CadImposto>
    {
        #region IComparer<TRegistro_CadImposto> Members
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

        public TList_CadImposto()
        { }

        public TList_CadImposto(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadImposto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadImposto x, TRegistro_CadImposto y)
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

    public class TCD_CadImposto : TDataQuery
    {
        public TCD_CadImposto()
        { }

        public TCD_CadImposto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Imposto, a.DS_Imposto, ");
                sql.AppendLine("a.ST_Registro, a.st_pis, a.st_cofins, a.st_inss, ");
                sql.AppendLine("a.st_icms, a.st_issqn, a.st_csll, a.st_irrf, ");
                sql.AppendLine("a.st_ipi, a.st_ii, a.st_funrural, a.st_senar, a.sigla ");
                
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_Imposto a ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");
            string cond = " and ";

            if(vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public TList_CadImposto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadImposto lista = new TList_CadImposto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadImposto reg = new TRegistro_CadImposto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Imposto"))))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Imposto"))))
                        reg.ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.st_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_pis")))
                        reg.St_PIS = reader.GetBoolean(reader.GetOrdinal("st_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cofins")))
                        reg.St_Cofins = reader.GetBoolean(reader.GetOrdinal("st_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_icms")))
                        reg.St_ICMS = reader.GetBoolean(reader.GetOrdinal("st_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_issqn")))
                        reg.St_ISSQN = reader.GetBoolean(reader.GetOrdinal("st_issqn"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_csll")))
                        reg.St_CSLL = reader.GetBoolean(reader.GetOrdinal("st_csll"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_irrf")))
                        reg.St_IRRF = reader.GetBoolean(reader.GetOrdinal("st_irrf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_inss")))
                        reg.St_INSS = reader.GetBoolean(reader.GetOrdinal("st_inss"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_funrural")))
                        reg.St_Funrural = reader.GetBoolean(reader.GetOrdinal("st_funrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_senar")))
                        reg.St_Senar = reader.GetBoolean(reader.GetOrdinal("st_senar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_IPI")))
                        reg.St_IPI = reader.GetBoolean(reader.GetOrdinal("ST_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_II")))
                        reg.St_II = reader.GetBoolean(reader.GetOrdinal("ST_II"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadImposto val)
        {
            Hashtable hs = new Hashtable(14);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_DS_IMPOSTO", val.ds_imposto);
            hs.Add("@P_SIGLA", val.Sigla);
            hs.Add("@P_ST_REGISTRO", val.st_registro);
            hs.Add("@P_ST_PIS", val.St_PIS);
            hs.Add("@P_ST_COFINS", val.St_Cofins);
            hs.Add("@P_ST_ICMS", val.St_ICMS);
            hs.Add("@P_ST_ISSQN", val.St_ISSQN);
            hs.Add("@P_ST_CSLL", val.St_CSLL);
            hs.Add("@P_ST_IRRF", val.St_IRRF);
            hs.Add("@P_ST_INSS", val.St_INSS);
            hs.Add("@P_ST_IPI", val.St_IPI);
            hs.Add("@P_ST_II", val.St_II);
            hs.Add("@P_ST_FUNRURAL", val.St_Funrural);
            hs.Add("@P_ST_SENAR", val.St_Senar);

            return executarProc("IA_FIS_IMPOSTO", hs);
        }

        public string Excluir(TRegistro_CadImposto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);

            return executarProc("EXCLUI_FIS_IMPOSTO", hs);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
    }
}
