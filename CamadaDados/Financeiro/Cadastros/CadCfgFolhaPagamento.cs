using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CfgFolhaPagamento : List<TRegistro_CfgFolhaPagamento>, IComparer<TRegistro_CfgFolhaPagamento>
    {
        #region IComparer<TRegistro_CfgFolhaPagamento> Members
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

        public TList_CfgFolhaPagamento()
        { }

        public TList_CfgFolhaPagamento(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgFolhaPagamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgFolhaPagamento x, TRegistro_CfgFolhaPagamento y)
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
    
    public class TRegistro_CfgFolhaPagamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Tp_movhistorico
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        public string Tp_movduplicata
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
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Cd_centroresult
        { get; set; }
        public string Ds_centroresult
        { get; set; }
        public decimal Diapagamento
        { get; set; }
        private string st_despmesanterior;
        public string St_despmesanterior
        {
            get { return st_despmesanterior; }
            set
            {
                st_despmesanterior = value;
                st_despmesanteriorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_despmesanteriorbool;
        public bool St_despmesanteriorbool
        {
            get { return st_despmesanteriorbool; }
            set
            {
                st_despmesanteriorbool = value;
                st_despmesanterior = value ? "S" : "N";
            }
        }

        public TRegistro_CfgFolhaPagamento()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_historico = string.Empty;
            this.Tp_movhistorico = string.Empty;
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.Tp_movduplicata = string.Empty;
            this.tp_docto = null;
            this.tp_doctostr = string.Empty;
            this.Ds_tpdocto = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.Cd_centroresult = string.Empty;
            this.Ds_centroresult = string.Empty;
            this.Diapagamento = decimal.Zero;
            this.st_despmesanterior = "N";
            this.st_despmesanteriorbool = false;
        }
    }

    public class TCD_CfgFolhaPagamento : TDataQuery
    {
        public TCD_CfgFolhaPagamento()
        { }

        public TCD_CfgFolhaPagamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.NM_Empresa, ");
                sql.AppendLine("a.cd_historico, c.DS_Historico, c.TP_MOV as tp_movhistorico, ");
                sql.AppendLine("a.cd_condpgto, d.DS_CondPGTO, a.tp_duplicata, ");
                sql.AppendLine("e.DS_TpDuplicata, e.TP_MOV as tp_movduplicata, ");
                sql.AppendLine("a.tp_docto, f.DS_TpDocto, a.cd_contager, ");
                sql.AppendLine("g.ds_contager, a.cd_portador, h.ds_portador, ");
                sql.AppendLine("a.cd_centroresult, i.ds_centroresultado, ");
                sql.AppendLine("a.diapagamento, a.st_despmesanterior ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cfgfolhapagamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Historico c ");
            sql.AppendLine("on a.cd_historico = c.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_CondPGTO d ");
            sql.AppendLine("on a.cd_condpgto = d.CD_CondPGTO ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata e ");
            sql.AppendLine("on a.tp_duplicata = e.TP_Duplicata ");
            sql.AppendLine("inner join TB_FIN_TPDocto_Dup f ");
            sql.AppendLine("on a.tp_docto = f.Tp_Docto ");
            sql.AppendLine("left outer join tb_fin_contager g ");
            sql.AppendLine("on a.cd_contager = g.cd_contager ");
            sql.AppendLine("left outer join tb_fin_portador h ");
            sql.AppendLine("on a.cd_portador = h.cd_portador ");
            sql.AppendLine("left outer join tb_fin_centroresultado i ");
            sql.AppendLine("on a.cd_centroresult = i.cd_centroresult ");
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

        public TList_CfgFolhaPagamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgFolhaPagamento lista = new TList_CfgFolhaPagamento();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgFolhaPagamento reg = new TRegistro_CfgFolhaPagamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movhistorico")))
                        reg.Tp_movhistorico = reader.GetString(reader.GetOrdinal("tp_movhistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movduplicata")))
                        reg.Tp_movduplicata = reader.GetString(reader.GetOrdinal("tp_movduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("cd_centroresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultado")))
                        reg.Ds_centroresult = reader.GetString(reader.GetOrdinal("ds_centroresultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diapagamento")))
                        reg.Diapagamento = reader.GetDecimal(reader.GetOrdinal("diapagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_despmesanterior")))
                        reg.St_despmesanterior = reader.GetString(reader.GetOrdinal("st_despmesanterior"));


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

        public string Gravar(TRegistro_CfgFolhaPagamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_ST_DESPMESANTERIOR", val.St_despmesanterior);
            hs.Add("@P_DIAPAGAMENTO", val.Diapagamento);

            return this.executarProc("IA_FIN_CFGFOLHAPAGAMENTO", hs);
        }

        public string Excluir(TRegistro_CfgFolhaPagamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CFGFOLHAPAGAMENTO", hs);
        }
    }
}
