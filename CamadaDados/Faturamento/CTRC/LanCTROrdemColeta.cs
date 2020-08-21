using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_CTROrdemColeta : List<TRegistro_CTROrdemColeta>, IComparer<TRegistro_CTROrdemColeta>
    {
        #region IComparer<TRegistro_CTROrdemColeta> Members
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

        public TList_CTROrdemColeta()
        { }

        public TList_CTROrdemColeta(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTROrdemColeta value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTROrdemColeta x, TRegistro_CTROrdemColeta y)
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

    public class TRegistro_CTROrdemColeta
    {
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctoctr;
        public decimal? Nr_lanctoctr
        {
            get { return nr_lanctoctr; }
            set
            {
                nr_lanctoctr = value;
                nr_lanctoctrstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoctrstr;
        public string Nr_lanctoctrstr
        {
            get { return nr_lanctoctrstr; }
            set
            {
                nr_lanctoctrstr = value;
                try
                {
                    nr_lanctoctr = decimal.Parse(value);
                }
                catch { nr_lanctoctr = null; }
            }
        }
        private decimal? id_ordem;
        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;
        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = decimal.Parse(value);
                }
                catch { id_ordem = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cnpj_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Uf
        { get; set; }
        public string Fone
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Nr_ordem
        { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }

        public TRegistro_CTROrdemColeta()
        {
            this.Cd_empresa = string.Empty;
            this.nr_lanctoctr = null;
            this.nr_lanctoctrstr = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cnpj_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Uf = string.Empty;
            this.Fone = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Nr_serie = string.Empty;
            this.Nr_ordem = string.Empty;
            this.dt_emissao = null;
            this.dt_emissaostr = string.Empty;
        }
    }

    public class TCD_CTROrdemColeta : TDataQuery
    {
        public TCD_CTROrdemColeta() { }

        public TCD_CTROrdemColeta(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.NR_LanctoCTR, ");
                sql.AppendLine("a.Cd_Clifor, b.NM_Clifor, b.NR_CGC, ");
                sql.AppendLine("a.Cd_Endereco, c.Ds_Endereco, c.UF, ");
                sql.AppendLine("c.Fone, c.Insc_estadual, a.NR_Serie, ");
                sql.AppendLine("a.ID_Ordem, a.NR_Ordem, a.DT_Emissao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_OrdemColeta a ");
            sql.AppendLine("inner join VTB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = c.cd_endereco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CTROrdemColeta Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CTROrdemColeta lista = new TList_CTROrdemColeta();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CTROrdemColeta reg = new TRegistro_CTROrdemColeta();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("id_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj_clifor = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_ordem")))
                        reg.Nr_ordem = reader.GetString(reader.GetOrdinal("nr_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));

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

        public string Gravar(TRegistro_CTROrdemColeta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_NR_ORDEM", val.Nr_ordem);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);

            return this.executarProc("IA_CTR_ORDEMCOLETA", hs);
        }

        public string Excluir(TRegistro_CTROrdemColeta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);

            return this.executarProc("EXCLUI_CTR_ORDEMCOLETA", hs);
        }
    }
}
