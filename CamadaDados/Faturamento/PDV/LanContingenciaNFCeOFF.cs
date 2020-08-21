using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_ContingenciaNFCeOFF : List<TRegistro_ContingenciaNFCeOFF>, IComparer<TRegistro_ContingenciaNFCeOFF>
    {
        #region IComparer<TRegistro_ContingenciaNFCeOFF> Members
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

        public TList_ContingenciaNFCeOFF()
        { }

        public TList_ContingenciaNFCeOFF(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ContingenciaNFCeOFF value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ContingenciaNFCeOFF x, TRegistro_ContingenciaNFCeOFF y)
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

    public class TRegistro_ContingenciaNFCeOFF
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_pdv;
        public decimal? Id_pdv
        {
            get { return id_pdv; }
            set
            {
                id_pdv = value;
                id_pdvstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pdvstr;
        public string Id_pdvstr
        {
            get { return id_pdvstr; }
            set
            {
                id_pdvstr = value;
                try
                {
                    id_pdv = decimal.Parse(value);
                }
                catch { id_pdv = null; }
            }
        }
        public string Ds_pdv
        { get; set; }
        private decimal? id_contingencia;
        public decimal? Id_contingencia
        {
            get { return id_contingencia; }
            set
            {
                id_contingencia = value;
                id_contingenciastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_contingenciastr;
        public string Id_contingenciastr
        {
            get { return id_contingenciastr; }
            set
            {
                id_contingenciastr = value;
                try
                {
                    id_contingencia = decimal.Parse(value);
                }
                catch { id_contingencia = null; }
            }
        }
        public string Login_E
        { get; set; }
        public string Login_S
        { get; set; }
        private DateTime? dt_entrada;
        public DateTime? Dt_entrada
        {
            get { return dt_entrada; }
            set
            {
                dt_entrada = value;
                dt_entradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_entradastr;
        public string Dt_entradastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_entradastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_entradastr = value;
                try
                {
                    dt_entrada = DateTime.Parse(value);
                }
                catch { dt_entrada = null; }
            }
        }
        private DateTime? dt_saida;
        public DateTime? Dt_saida
        {
            get { return dt_saida; }
            set
            {
                dt_saida = value;
                dt_saidastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_saidastr;
        public string Dt_saidastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_saidastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_saidastr = value;
                try
                {
                    dt_saida = DateTime.Parse(value);
                }
                catch { dt_saida = null; }
            }
        }
        public string Justificativa
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (this.St_registro.Trim().ToUpper().Equals("F"))
                    return "FINALIZADO";
                else return string.Empty;
            }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_ContingenciaNFCeOFF()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_pdv = null;
            this.id_pdvstr = string.Empty;
            this.Ds_pdv = string.Empty;
            this.id_contingencia = null;
            this.id_contingenciastr = string.Empty;
            this.Login_E = string.Empty;
            this.Login_S = string.Empty;
            this.dt_entrada = null;
            this.dt_entradastr = string.Empty;
            this.dt_saida = null;
            this.dt_saidastr = string.Empty;
            this.Justificativa = string.Empty;
            this.St_registro = "A";
            this.St_processar = false;
        }
    }

    public class TCD_ContingenciaNFCeOFF : TDataQuery
    {
        public TCD_ContingenciaNFCeOFF() { }

        public TCD_ContingenciaNFCeOFF(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_PDV, c.DS_PDV, a.ID_Contingencia, ");
                sql.AppendLine("a.Login_E, a.Login_S, a.DT_Entrada, ");
                sql.AppendLine("a.DT_Saida, a.Justificativa, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_ContingenciaNFCeOFF a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_PDV_PontoVenda c ");
            sql.AppendLine("on a.ID_PDV = c.ID_PDV ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ContingenciaNFCeOFF Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ContingenciaNFCeOFF lista = new TList_ContingenciaNFCeOFF();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ContingenciaNFCeOFF reg = new TRegistro_ContingenciaNFCeOFF();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PDV")))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("ID_PDV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PDV")))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("DS_PDV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Contingencia")))
                        reg.Id_contingencia = reader.GetDecimal(reader.GetOrdinal("ID_Contingencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_E")))
                        reg.Login_E = reader.GetString(reader.GetOrdinal("Login_E"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_S")))
                        reg.Login_S = reader.GetString(reader.GetOrdinal("Login_S"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Entrada")))
                        reg.Dt_entrada = reader.GetDateTime(reader.GetOrdinal("DT_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Saida")))
                        reg.Dt_saida = reader.GetDateTime(reader.GetOrdinal("DT_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Justificativa")))
                        reg.Justificativa = reader.GetString(reader.GetOrdinal("Justificativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_ContingenciaNFCeOFF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_CONTINGENCIA", val.Id_contingencia);
            hs.Add("@P_LOGIN_E", val.Login_E);
            hs.Add("@P_LOGIN_S", val.Login_S);
            hs.Add("@P_DT_ENTRADA", val.Dt_entrada);
            hs.Add("@P_DT_SAIDA", val.Dt_saida);
            hs.Add("@P_JUSTIFICATIVA", val.Justificativa);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_CONTINGENCIANFCEOFF", hs);
        }

        public string Excluir(TRegistro_ContingenciaNFCeOFF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_CONTINGENCIA", val.Id_contingencia);

            return this.executarProc("EXCLUI_PDV_CONTINGENCIAOFF", hs);
        }
    }
}
