using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    public class TList_Abastecidas : List<TRegistro_Abastecidas>, IComparer<TRegistro_Abastecidas>
    {
        #region IComparer<TRegistro_Abastecidas> Members
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

        public TList_Abastecidas()
        { }

        public TList_Abastecidas(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Abastecidas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Abastecidas x, TRegistro_Abastecidas y)
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

    public class TRegistro_Abastecidas
    {
        private decimal? id_abastecida;
        
        public decimal? Id_abastecida
        {
            get { return id_abastecida; }
            set
            {
                id_abastecida = value;
                id_abastecidastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_abastecidastr;
        
        public string Id_abastecidastr
        {
            get { return id_abastecidastr; }
            set
            {
                id_abastecidastr = value;
                try
                {
                    id_abastecida = decimal.Parse(value);
                }
                catch
                { id_abastecida = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? id_abastecimento;
        
        public decimal? Id_abastecimento
        {
            get { return id_abastecimento; }
            set
            {
                id_abastecimento = value;
                id_abastecimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_abastecimentostr;
        
        public string Id_abastecimentostr
        {
            get { return id_abastecimentostr; }
            set
            {
                id_abastecimentostr = value;
                try
                {
                    id_abastecimento = decimal.Parse(value);
                }
                catch
                { id_abastecimento = null; }
            }
        }
        
        public decimal Volume
        { get; set; }
        private DateTime? dt_abastecida;
        
        public DateTime? Dt_abastecida
        {
            get { return dt_abastecida; }
            set
            {
                dt_abastecida = value;
                dt_abastecidastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_abastecidastr;
        public string Dt_abastecidastr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_abastecidastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_abastecidastr = value;
                try
                {
                    dt_abastecida = DateTime.Parse(value);
                }
                catch
                { dt_abastecida = null; }
            }
        }

        public TRegistro_Abastecidas()
        {
            this.id_abastecida = null;
            this.id_abastecidastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_abastecimento = null;
            this.id_abastecimentostr = string.Empty;
            this.Volume = decimal.Zero;
            this.dt_abastecida = null;
            this.dt_abastecidastr = string.Empty;
        }
    }

    public class TCD_Abastecidas : TDataQuery
    {
        public TCD_Abastecidas()
        { }

        public TCD_Abastecidas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_abastecida, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.id_abastecimento, a.volume, a.dt_abastecida ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Abastecidas a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_abastecida desc ");
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

        public TList_Abastecidas Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Abastecidas lista = new TList_Abastecidas();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Abastecidas reg = new TRegistro_Abastecidas();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Abastecimento")))
                        reg.Id_abastecimento = reader.GetDecimal(reader.GetOrdinal("ID_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Abastecida")))
                        reg.Id_abastecida = reader.GetDecimal(reader.GetOrdinal("ID_Abastecida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volume")))
                        reg.Volume = reader.GetDecimal(reader.GetOrdinal("Volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abastecida")))
                        reg.Dt_abastecida = reader.GetDateTime(reader.GetOrdinal("DT_Abastecida"));

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

        public string Gravar(TRegistro_Abastecidas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ABASTECIDA", val.Id_abastecida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_VOLUME", val.Volume);
            hs.Add("@P_DT_ABASTECIDA", val.Dt_abastecida);

            return this.executarProc("IA_FRT_ABASTECIDAS", hs);
        }

        public string Excluir(TRegistro_Abastecidas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ABASTECIDA", val.Id_abastecida);

            return this.executarProc("EXCLUI_FRT_ABASTECIDAS", hs);
        }
    }
}
