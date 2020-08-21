using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    public class TList_EncerranteBico : List<TRegistro_EncerranteBico>, IComparer<TRegistro_EncerranteBico>
    {
        #region IComparer<TRegistro_EncerranteBico> Members
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

        public TList_EncerranteBico()
        { }

        public TList_EncerranteBico(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EncerranteBico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EncerranteBico x, TRegistro_EncerranteBico y)
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

    public class TRegistro_EncerranteBico
    {
        private decimal? id_encerrante;
        public decimal? Id_encerrante
        {
            get { return id_encerrante; }
            set
            {
                id_encerrante = value;
                id_encerrantestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_encerrantestr;
        public string Id_encerrantestr
        {
            get { return id_encerrantestr; }
            set
            {
                id_encerrantestr = value;
                try
                {
                    id_encerrante = decimal.Parse(value);
                }
                catch
                { id_encerrante = null; }
            }
        }
        private decimal? id_bico;
        public decimal? Id_bico
        {
            get { return id_bico; }
            set
            {
                id_bico = value;
                id_bicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bicostr;
        public string Id_bicostr
        {
            get { return id_bicostr; }
            set
            {
                id_bicostr = value;
                try
                {
                    id_bico = decimal.Parse(value);
                }
                catch
                { id_bico = null; }
            }
        }
        public string Labelbico
        { get; set; }
        private DateTime? dt_encerrante;
        public DateTime? Dt_encerrante
        {
            get { return dt_encerrante; }
            set
            {
                dt_encerrante = value;
                dt_encerrantestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_encerrantestr;
        public string Dt_encerrantestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_encerrantestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerrantestr = value;
                try
                {
                    dt_encerrante = DateTime.Parse(value);
                }
                catch
                { dt_encerrante = null; }
            }
        }
        private string tp_encerrante;
        public string Tp_encerrante
        {
            get { return tp_encerrante; }
            set
            {
                tp_encerrante = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_encerrante = "ABERTURA";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_encerrante = "FECHAMENTO";
                else if (value.Trim().ToUpper().Equals("I"))
                    tipo_encerrante = "INTERVENÇÃO";
            }
        }
        private string tipo_encerrante;
        public string Tipo_encerrante
        {
            get { return tipo_encerrante; }
            set
            {
                tipo_encerrante = value;
                if (value.Trim().ToUpper().Equals("ABERTURA"))
                    tp_encerrante = "A";
                else if (value.Trim().ToUpper().Equals("FECHAMENTO"))
                    tp_encerrante = "F";
                else if (value.Trim().ToUpper().Equals("INTERVENÇÃO"))
                    tp_encerrante = "I";
            }
        }
        public decimal Qtd_encerrante
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }

        public TRegistro_EncerranteBico()
        {
            this.id_encerrante = null;
            this.id_encerrantestr = string.Empty;
            this.id_bico = null;
            this.id_bicostr = string.Empty;
            this.Labelbico = string.Empty;
            this.dt_encerrante = null;
            this.dt_encerrantestr = string.Empty;
            this.tp_encerrante = string.Empty;
            this.tipo_encerrante = string.Empty;
            this.Qtd_encerrante = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
        }
    }

    public class TCD_EncerranteBico : TDataQuery
    {
        public TCD_EncerranteBico()
        { }

        public TCD_EncerranteBico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_encerrante, a.id_bico, ");
                sql.AppendLine("a.dt_encerrante, a.tp_encerrante, a.qtd_encerrante, ");
                sql.AppendLine("b.cd_empresa, d.nm_empresa, c.cd_produto, e.ds_produto, ");
                sql.AppendLine("b.ds_label ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_encerrantebico a ");
            sql.AppendLine("inner join tb_pdc_bicobomba b ");
            sql.AppendLine("on a.id_bico = b.id_bico ");
            sql.AppendLine("inner join tb_pdc_tanque c ");
            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and b.id_tanque = c.id_tanque ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on b.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto e ");
            sql.AppendLine("on c.cd_produto = e.cd_produto ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_EncerranteBico Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_EncerranteBico lista = new TList_EncerranteBico();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EncerranteBico reg = new TRegistro_EncerranteBico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_encerrante"))))
                        reg.Id_encerrante = reader.GetDecimal(reader.GetOrdinal("id_encerrante"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_bico"))))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Labelbico = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_encerrante")))
                        reg.Dt_encerrante = reader.GetDateTime(reader.GetOrdinal("dt_encerrante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_encerrante")))
                        reg.Qtd_encerrante = reader.GetDecimal(reader.GetOrdinal("qtd_encerrante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_encerrante")))
                        reg.Tp_encerrante = reader.GetString(reader.GetOrdinal("tp_encerrante"));

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

        public string Gravar(TRegistro_EncerranteBico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ENCERRANTE", val.Id_encerrante);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_DT_ENCERRANTE", val.Dt_encerrante);
            hs.Add("@P_TP_ENCERRANTE", val.Tp_encerrante);
            hs.Add("@P_QTD_ENCERRANTE", val.Qtd_encerrante);

            return this.executarProc("IA_PDC_ENCERRANTEBICO", hs);
        }

        public string Excluir(TRegistro_EncerranteBico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ENCERRANTE", val.Id_encerrante);

            return this.executarProc("EXCLUI_PDC_ENCERRANTEBICO", hs);
        }
    }
}
