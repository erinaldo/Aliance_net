using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    public class TList_MedicaoTanque : List<TRegistro_MedicaoTanque>, IComparer<TRegistro_MedicaoTanque>
    {
        #region IComparer<TRegistro_MedicaoTanque> Members
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

        public TList_MedicaoTanque()
        { }

        public TList_MedicaoTanque(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MedicaoTanque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MedicaoTanque x, TRegistro_MedicaoTanque y)
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

    
    public class TRegistro_MedicaoTanque
    {
        private decimal? id_medicao;
        
        public decimal? Id_medicao
        {
            get { return id_medicao; }
            set
            {
                id_medicao = value;
                id_medicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_medicaostr;
        
        public string Id_medicaostr
        {
            get { return id_medicaostr; }
            set
            {
                id_medicaostr = value;
                try
                {
                    id_medicao = decimal.Parse(value);
                }
                catch
                { id_medicao = null; }
            }
        }
        private decimal? id_tanque;
        
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch
                { id_tanque = null; }
            }
        }
        
        public string Cd_combustivel
        { get; set; }
        
        public string Ds_combustivel
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Capacidadetanque
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_funcionario
        { get; set; }
        
        public string Nm_funcionario
        { get; set; }
        private DateTime? dt_medicao;
        
        public DateTime? Dt_medicao
        {
            get { return dt_medicao; }
            set
            {
                dt_medicao = value;
                dt_medicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_medicaostr;
        public string Dt_medicaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_medicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_medicaostr = value;
                try
                {
                    dt_medicao = DateTime.Parse(value);
                }
                catch
                { dt_medicao = null; }
            }
        }
        private string tp_medicao;
        
        public string Tp_medicao
        {
            get { return tp_medicao; }
            set
            {
                tp_medicao = value;
                if (tp_medicao.Trim().Equals("A"))
                    tipo_medicao = "ABERTURA";
                else if (tp_medicao.Trim().Equals("F"))
                    tipo_medicao = "FECHAMENTO";
            }
        }
        private string tipo_medicao;
        
        public string Tipo_medicao
        {
            get { return tipo_medicao; }
            set
            {
                tipo_medicao = value;
                if (value.Trim().ToUpper().Equals("ABERTURA"))
                    tp_medicao = "A";
                else if (value.Trim().ToUpper().Equals("FECHAMENTO"))
                    tp_medicao = "F";
            }
        }
        
        public decimal Qtd_combustivel
        { get; set; }
        public decimal? Id_lanctoestoque { get; set; }
        public Estoque.TRegistro_LanEstoque rEstoque { get; set; }
        public TRegistro_MedicaoTanque()
        {
            id_medicao = null;
            id_medicaostr = string.Empty;
            id_tanque = null;
            id_tanquestr = string.Empty;
            Cd_combustivel = string.Empty;
            Ds_combustivel = string.Empty;
            Sigla_unidade = string.Empty;
            Capacidadetanque = decimal.Zero;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_funcionario = string.Empty;
            Nm_funcionario = string.Empty;
            dt_medicao = null;
            dt_medicaostr = string.Empty;
            tp_medicao = string.Empty;
            tipo_medicao = string.Empty;
            Qtd_combustivel = decimal.Zero;
            Id_lanctoestoque = null;
            rEstoque = null;
        }
    }

    public class TCD_MedicaoTanque : TDataQuery
    {
        public TCD_MedicaoTanque()
        { }

        public TCD_MedicaoTanque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Medicao, a.Id_Tanque, a.tp_medicao, ");
                sql.AppendLine("b.CD_Produto as cd_combustivel, c.DS_Produto as ds_combustivel, ");
                sql.AppendLine("b.CapacidadeTanque, d.Sigla_Unidade, a.CD_Funcionario, ");
                sql.AppendLine("e.NM_Funcionario, a.DT_Medicao, a.QTD_Combustivel, ");
                sql.AppendLine("a.cd_empresa, f.nm_empresa, a.id_lanctoestoque ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_MedicaoTanque a ");
            sql.AppendLine("inner join TB_PDC_Tanque b ");
            sql.AppendLine("on a.Id_Tanque = b.Id_Tanque ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.CD_Unidade = d.CD_Unidade ");
            sql.AppendLine("left outer join VTB_FIN_FUNCIONARIO e ");
            sql.AppendLine("on a.CD_Funcionario = e.CD_Funcionario ");
            sql.AppendLine("inner join TB_DIV_Empresa f ");
            sql.AppendLine("on a.cd_empresa = f.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_MedicaoTanque Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MedicaoTanque lista = new TList_MedicaoTanque();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MedicaoTanque reg = new TRegistro_MedicaoTanque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_medicao"))))
                        reg.Id_medicao = reader.GetDecimal(reader.GetOrdinal("id_medicao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_tanque"))))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_combustivel"))))
                        reg.Cd_combustivel = reader.GetString(reader.GetOrdinal("cd_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_combustivel")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapacidadeTanque")))
                        reg.Capacidadetanque = reader.GetDecimal(reader.GetOrdinal("CapacidadeTanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("CD_Funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Funcionario")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("NM_Funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Medicao")))
                        reg.Dt_medicao = reader.GetDateTime(reader.GetOrdinal("DT_Medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_medicao")))
                        reg.Tp_medicao = reader.GetString(reader.GetOrdinal("tp_medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Combustivel")))
                        reg.Qtd_combustivel = reader.GetDecimal(reader.GetOrdinal("QTD_Combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));

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

        public string Gravar(TRegistro_MedicaoTanque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_MEDICAO", val.Id_medicao);
            hs.Add("@P_ID_TANQUE", val.Id_tanque);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);
            hs.Add("@P_CD_PRODUTO", val.Cd_combustivel);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_DT_MEDICAO", val.Dt_medicao);
            hs.Add("@P_TP_MEDICAO", val.Tp_medicao);
            hs.Add("@P_QTD_COMBUSTIVEL", val.Qtd_combustivel);

            return executarProc("IA_PDC_MEDICAOTANQUE", hs);
        }

        public string Excluir(TRegistro_MedicaoTanque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_MEDICAO", val.Id_medicao);

            return executarProc("EXCLUI_PDC_MEDICAOTANQUE", hs);
        }
    }
}
