using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_IntervencaoTec : List<TRegistro_IntervencaoTec>, IComparer<TRegistro_IntervencaoTec>
    {
        #region IComparer<TRegistro_IntervencaoTec> Members
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

        public TList_IntervencaoTec()
        { }

        public TList_IntervencaoTec(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_IntervencaoTec value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_IntervencaoTec x, TRegistro_IntervencaoTec y)
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

    
    public class TRegistro_IntervencaoTec
    {
        private decimal? id_equipamento;
        
        public decimal? Id_equipamento
        {
            get { return id_equipamento; }
            set
            {
                id_equipamento = value;
                id_equipamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_equipamentostr;
        
        public string Id_equipamentostr
        {
            get { return id_equipamentostr; }
            set
            {
                id_equipamentostr = value;
                try
                {
                    id_equipamento = decimal.Parse(value);
                }
                catch
                { id_equipamento = null; }
            }
        }
        
        public string Ds_equipamento
        { get; set; }
        private decimal? id_intervencao;
        
        public decimal? Id_intervencao
        {
            get { return id_intervencao; }
            set
            {
                id_intervencao = value;
                id_intervencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_intervencaostr;
        
        public string Id_intervencaostr
        {
            get { return id_intervencaostr; }
            set
            {
                id_intervencaostr = value;
                try
                {
                    id_intervencao = decimal.Parse(value);
                }
                catch
                { id_intervencao = null; }
            }
        }
        
        public string Nr_ose
        { get; set; }
        
        public decimal Vl_acumulado_GT
        { get; set; }
        
        public decimal Nr_cro
        { get; set; }
        private DateTime? dt_intervencao;
        
        public DateTime? Dt_intervencao
        {
            get { return dt_intervencao; }
            set
            {
                dt_intervencao = value;
                dt_intervencaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_intervencaostr;
        public string Dt_intervencaostr
        {
            get { return dt_intervencaostr; }
            set
            {
                dt_intervencaostr = value;
                try
                {
                    dt_intervencao = DateTime.Parse(value);
                }
                catch
                { dt_intervencao = null; }
            }
        }
        private string st_perdadados;
        
        public string St_perdadados
        {
            get { return st_perdadados; }
            set
            {
                st_perdadados = value;
                st_perdadadosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_perdadadosbool;
        
        public bool St_perdadadosbool
        {
            get { return st_perdadadosbool; }
            set
            {
                st_perdadadosbool = value;
                st_perdadados = value ? "S" : "N";
            }
        }
        
        public string Motivo_intervencao
        { get; set; }
        
        public string Memoria_fiscal_ant
        { get; set; }
        
        public string Memoria_fiscal_nova
        { get; set; }

        public TRegistro_IntervencaoTec()
        {
            this.id_equipamento = null;
            this.id_equipamentostr = string.Empty;
            this.Ds_equipamento = string.Empty;
            this.id_intervencao = null;
            this.id_intervencaostr = string.Empty;
            this.Nr_ose = string.Empty;
            this.Vl_acumulado_GT = decimal.Zero;
            this.Nr_cro = decimal.Zero;
            this.dt_intervencao = null;
            this.dt_intervencaostr = string.Empty;
            this.st_perdadados = "N";
            this.st_perdadadosbool = false;
            this.Motivo_intervencao = string.Empty;
            this.Memoria_fiscal_ant = string.Empty;
            this.Memoria_fiscal_nova = string.Empty;
        }
    }

    public class TCD_IntervencaoTec : TDataQuery
    {
        public TCD_IntervencaoTec()
        { }

        public TCD_IntervencaoTec(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_Equipamento, b.DS_Equipamento, ");
                sql.AppendLine("a.ID_Intervencao, a.NR_OSE, a.Vl_Acumulado_GT, a.NR_CRO, ");
                sql.AppendLine("a.DT_Intervencao, a.ST_PerdaDados, a.Motivo_Intervencao, ");
                sql.AppendLine("a.Memoria_Fiscal_Ant, a.Memoria_Fiscal_Nova ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_IntervencaoTec a ");
            sql.AppendLine("inner join TB_PDV_EmissorCF b ");
            sql.AppendLine("on a.ID_Equipamento = b.ID_Equipamento ");

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

        public TList_IntervencaoTec Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_IntervencaoTec lista = new TList_IntervencaoTec();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_IntervencaoTec reg = new TRegistro_IntervencaoTec();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Equipamento")))
                        reg.Id_equipamento = reader.GetDecimal(reader.GetOrdinal("ID_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Equipamento")))
                        reg.Ds_equipamento = reader.GetString(reader.GetOrdinal("DS_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Intervencao")))
                        reg.Id_intervencao = reader.GetDecimal(reader.GetOrdinal("ID_Intervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_OSE")))
                        reg.Nr_ose = reader.GetString(reader.GetOrdinal("NR_OSE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acumulado_GT")))
                        reg.Vl_acumulado_GT = reader.GetDecimal(reader.GetOrdinal("Vl_Acumulado_GT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CRO")))
                        reg.Nr_cro = reader.GetDecimal(reader.GetOrdinal("NR_CRO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Intervencao")))
                        reg.Dt_intervencao = reader.GetDateTime(reader.GetOrdinal("DT_Intervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_PerdaDados")))
                        reg.St_perdadados = reader.GetString(reader.GetOrdinal("ST_PerdaDados"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Motivo_intervencao")))
                        reg.Motivo_intervencao = reader.GetString(reader.GetOrdinal("Motivo_Intervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Memoria_Fiscal_Ant")))
                        reg.Memoria_fiscal_ant = reader.GetString(reader.GetOrdinal("Memoria_Fiscal_Ant"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Memoria_Fiscal_Nova")))
                        reg.Memoria_fiscal_nova = reader.GetString(reader.GetOrdinal("Memoria_Fiscal_Nova"));

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

        public string Gravar(TRegistro_IntervencaoTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_EQUIPAMENTO", val.Id_equipamento);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);
            hs.Add("@P_NR_OSE", val.Nr_ose);
            hs.Add("@P_VL_ACUMULADO_GT", val.Vl_acumulado_GT);
            hs.Add("@P_NR_CRO", val.Nr_cro);
            hs.Add("@P_DT_INTERVENCAO", val.Dt_intervencao);
            hs.Add("@P_ST_PERDADADOS", val.St_perdadados);
            hs.Add("@P_MOTIVO_INTERVENCAO", val.Motivo_intervencao);
            hs.Add("@P_MEMORIA_FISCAL_ANT", val.Memoria_fiscal_ant);
            hs.Add("@P_MEMORIA_FISCAL_NOVA", val.Memoria_fiscal_nova);

            return this.executarProc("IA_PDV_INTERVENCAOTEC", hs);
        }

        public string Excluir(TRegistro_IntervencaoTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EQUIPAMENTO", val.Id_equipamento);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);

            return this.executarProc("EXCLUI_PDV_INTERVENCAOTEC", hs);
        }
    }
}