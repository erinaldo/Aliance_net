using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_CfgContrato : List<TRegistro_CfgContrato>, IComparer<TRegistro_CfgContrato>
    {
        #region IComparer<TRegistro_CfgContrato> Members
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

        public TList_CfgContrato()
        { }

        public TList_CfgContrato(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgContrato value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgContrato x, TRegistro_CfgContrato y)
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
    
    public class TRegistro_CfgContrato
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        private decimal? id_configboleto;
        public decimal? Id_configboleto
        {
            get { return id_configboleto; }
            set
            {
                id_configboleto = value;
                id_configboletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configboletostr;
        public string Id_configboletostr
        {
            get { return id_configboletostr; }
            set
            {
                id_configboletostr = value;
                try
                {
                    id_configboleto = decimal.Parse(value);
                }
                catch { id_configboleto = null; }
            }
        }
        public string Ds_configboleto
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public string Cd_centroresult
        { get; set; }
        public string Ds_centroresult
        { get; set; }

        public TRegistro_CfgContrato()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.tp_docto = null;
            this.tp_doctostr = string.Empty;
            this.Ds_tpdocto = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.id_configboleto = null;
            this.id_configboletostr = string.Empty;
            this.Ds_configboleto = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_historico = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.Cd_centroresult = string.Empty;
            this.Ds_centroresult = string.Empty;
        }
    }

    public class TCD_CfgContrato : TDataQuery
    {
        public TCD_CfgContrato()
        { }

        public TCD_CfgContrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_CondPGTO, d.DS_CondPGTO, ");
                sql.AppendLine("a.Tp_Docto, e.DS_TpDocto, ");
                sql.AppendLine("a.TP_Duplicata, f.DS_TpDuplicata, ");
                sql.AppendLine("f.id_config, i.ds_config, ");
                sql.AppendLine("a.CD_Historico, g.DS_Historico, ");
                sql.AppendLine("a.CD_TabelaPreco, h.DS_TabelaPreco, ");
                sql.AppendLine("a.CD_CentroResult, j.DS_CentroResultado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_CfgContrato a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_CondPGTO d ");
            sql.AppendLine("on a.CD_CondPGTO = d.CD_CondPGTO ");
            sql.AppendLine("inner join TB_FIN_TPDocto_Dup e ");
            sql.AppendLine("on a.Tp_Docto = e.Tp_Docto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata f ");
            sql.AppendLine("on a.TP_Duplicata = f.TP_Duplicata ");
            sql.AppendLine("inner join TB_FIN_Historico g ");
            sql.AppendLine("on a.CD_Historico = g.CD_Historico ");
            sql.AppendLine("left outer join TB_DIV_TabelaPreco h ");
            sql.AppendLine("on a.cd_tabelapreco = h.cd_tabelapreco ");
            sql.AppendLine("left outer join TB_COB_CfgBanco i ");
            sql.AppendLine("on f.id_config = i.id_config ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado j ");
            sql.AppendLine("on a.cd_centroresult = j.cd_centroresult ");

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

        public TList_CfgContrato Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgContrato lista = new TList_CfgContrato();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CfgContrato reg = new TRegistro_CfgContrato();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("DS_TpDocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_configboleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_configboleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("cd_centroresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultado")))
                        reg.Ds_centroresult = reader.GetString(reader.GetOrdinal("ds_centroresultado"));

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

        public string Gravar(TRegistro_CfgContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);

            return this.executarProc("IA_OSE_CFGCONTRATO", hs);
        }

        public string Excluir(TRegistro_CfgContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_OSE_CFGCONTRATO", hs);
        }
    }
}
