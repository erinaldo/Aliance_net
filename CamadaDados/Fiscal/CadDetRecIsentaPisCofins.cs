using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_DetRecIsentaPisCofins : List<TRegistro_DetRecIsentaPisCofins>, IComparer<TRegistro_DetRecIsentaPisCofins>
    {
        #region IComparer<TRegistro_DetRecIsentaPisCofins> Members
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

        public TList_DetRecIsentaPisCofins()
        { }

        public TList_DetRecIsentaPisCofins(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DetRecIsentaPisCofins value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DetRecIsentaPisCofins x, TRegistro_DetRecIsentaPisCofins y)
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

    
    public class TRegistro_DetRecIsentaPisCofins
    {
        private decimal? id_detrecisenta;
        
        public decimal? Id_detrecisenta
        {
            get { return id_detrecisenta; }
            set
            {
                id_detrecisenta = value;
                id_detrecisentastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_detrecisentastr;
        
        public string Id_detrecisentastr
        {
            get { return id_detrecisentastr; }
            set
            {
                id_detrecisentastr = value;
                try
                {
                    id_detrecisenta = decimal.Parse(value);
                }
                catch
                { id_detrecisenta = null; }
            }
        }
        
        public string Ds_detrecisenta
        { get; set; }
        private decimal? cd_imposto;
        
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = decimal.Parse(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        
        public string Ds_imposto
        { get; set; }
        
        public string Cd_st
        { get; set; }
        
        public string Ds_situacao
        { get; set; }

        public TRegistro_DetRecIsentaPisCofins()
        {
            this.id_detrecisenta = null;
            this.id_detrecisentastr = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Cd_st = string.Empty;
            this.Ds_situacao = string.Empty;
            this.Ds_detrecisenta = string.Empty;
        }
    }

    public class TCD_DetRecIsentaPisCofins : TDataQuery
    {
        public TCD_DetRecIsentaPisCofins()
        { }

        public TCD_DetRecIsentaPisCofins(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_detrecisenta, a.ds_detrecisenta, ");
                sql.AppendLine("a.cd_imposto, b.ds_imposto, a.cd_st, c.ds_situacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fis_detrecisentapiscofins a ");
            sql.AppendLine("inner join tb_fis_imposto b ");
            sql.AppendLine("on a.cd_imposto = b.cd_imposto ");
            sql.AppendLine("inner join tb_fis_sittribut c ");
            sql.AppendLine("on a.cd_imposto = c.cd_imposto ");
            sql.AppendLine("and a.cd_st = c.cd_st ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
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

        public TList_DetRecIsentaPisCofins Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_DetRecIsentaPisCofins lista = new TList_DetRecIsentaPisCofins();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_DetRecIsentaPisCofins reg = new TRegistro_DetRecIsentaPisCofins();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_detrecisenta")))
                        reg.Id_detrecisenta = reader.GetDecimal(reader.GetOrdinal("id_detrecisenta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_st"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("ds_situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_detrecisenta")))
                        reg.Ds_detrecisenta = reader.GetString(reader.GetOrdinal("ds_detrecisenta"));

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

        public string Gravar(TRegistro_DetRecIsentaPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_DETRECISENTA", val.Id_detrecisenta);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_DS_DETRECISENTA", val.Ds_detrecisenta);

            return this.executarProc("IA_FIS_DETRECISENTAPISCOFINS", hs);
        }

        public string Excluir(TRegistro_DetRecIsentaPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_DETRECISENTA", val.Id_detrecisenta);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_ST", val.Cd_st);

            return this.executarProc("EXCLUI_FIS_DETRECISENTAPISCOFINS", hs);
        }
    }
}
