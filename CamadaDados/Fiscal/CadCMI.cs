using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{
    public class TList_CadCMI : List<TRegistro_CadCMI>, IComparer<TRegistro_CadCMI>
    {
        #region IComparer<TRegistro_CadCMI> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadCMI()
        { }

        public TList_CadCMI(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCMI value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCMI x, TRegistro_CadCMI y)
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

    public class TRegistro_CadCMI
    {
        private decimal? cd_cmi;
        public decimal? Cd_cmi
        {
            get {
                if (cd_cmi == 0)
                    return null;
                else
                return cd_cmi;
            }
            set
            {
                cd_cmi = value;
                cd_cmiString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_cmiString;
        public string Cd_cmiString
        {
            get { return cd_cmiString; }
            set
            {
                cd_cmiString = value;
                try
                {
                    cd_cmi = Convert.ToDecimal(value);
                }
                catch
                { cd_cmi = null; }
            }
        }
        public string Tp_duplicata { get; set; }
        public string ds_tpduplicata { get; set; }
        public string Cd_historico { get; set; }
        public string Ds_historico { get; set; }
        public string Cd_condpgto { get; set; }
        public string ds_condpgto { get; set; }
        public string Cd_moeda { get; set; }
        public string Ds_moeda { get; set; }
        public string Sigla { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto 
        {
            get
            {
                if (tp_docto == 0)
                    return null;
                else
                    return tp_docto;
            }
            set
            {
                tp_docto = value;
                tp_doctostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string tp_doctostring;
        public string Tp_doctostring
        {
            get { return tp_doctostring; }
            set 
            { 
                tp_doctostring = value;
                try
                {
                    Tp_docto = Convert.ToDecimal(value);
                }
                catch
                { Tp_docto = null; }
            }
        }
        public string ds_tpdocto { get; set; }
        public string Ds_cmi { get; set; }
        private string tp_movimento;
        public string Tp_movimento 
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set 
            { 
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        private string st_mestra;
        public string St_mestra 
        {
            get { return st_mestra; }
            set
            {
                st_mestra = value;
                st_mestrabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_mestrabool;
        public bool St_mestrabool
        {
            get { return st_mestrabool; }
            set 
            { 
                st_mestrabool = value;
                if (value)
                    st_mestra = "S";
                else
                    st_mestra = "N";
            }
        }
        private string st_devolucao;
        public string St_devolucao 
        {
            get { return st_devolucao; }
            set
            {
                st_devolucao = value;
                st_devolucaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_devolucaobool;
        public bool St_devolucaobool
        {
            get { return st_devolucaobool; }
            set 
            { 
                st_devolucaobool = value;
                if (value)
                    st_devolucao = "S";
                else
                    st_devolucao = "N";
            }
        }
        private string st_complementar;
        public string St_complementar 
        {
            get { return st_complementar; }
            set
            {
                st_complementar = value;
                st_complementarbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_complementarbool;
        public bool St_complementarbool
        {
            get { return st_complementarbool; }
            set 
            { 
                st_complementarbool = value;
                if (value)
                    st_complementar = "S";
                else
                    st_complementar = "N";
            }
        }
        private string st_geraestoque;
        public string St_geraestoque 
        {
            get { return st_geraestoque; }
            set
            {
                st_geraestoque = value;
                st_geraestoquebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_geraestoquebool;
        public bool St_geraestoquebool
        {
            get { return st_geraestoquebool; }
            set 
            { 
                st_geraestoquebool = value;
                if (value)
                    st_geraestoque = "S";
                else
                    st_geraestoque = "N";
            }
        }
        private string st_simplesremessa;
        public string St_simplesremessa 
        {
            get { return st_simplesremessa; }
            set
            {
                st_simplesremessa = value;
                st_simplesremessabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_simplesremessabool;
        public bool St_simplesremessabool
        {
            get { return st_simplesremessabool; }
            set 
            { 
                st_simplesremessabool = value;
                if (value)
                    st_simplesremessa = "S";
                else
                    st_simplesremessa = "N";
            }
        }
        private string st_compdevimposto;
        public string St_compdevimposto
        {
            get { return st_compdevimposto; }
            set
            {
                st_compdevimposto = value;
                st_compdevimpostobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_compdevimpostobool;
        public bool St_compdevimpostobool
        {
            get { return st_compdevimpostobool; }
            set
            {
                st_compdevimpostobool = value;
                st_compdevimposto = value ? "S" : "N";
            }
        }
        private string st_retorno;
        public string St_retorno
        {
            get { return st_retorno; }
            set
            {
                st_retorno = value;
                st_retornobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_retornobool;
        public bool St_retornobool
        {
            get { return st_retornobool; }
            set
            {
                st_retornobool = value;
                st_retorno = value ? "S" : "N";
            }
        }
        public string St_registro { get; set; }

        public TRegistro_CadCMI()
        {
             cd_cmi = null;
             cd_cmiString = string.Empty;
             Tp_duplicata = string.Empty;
             ds_tpduplicata = string.Empty;
             Cd_historico = string.Empty;
             Ds_historico = string.Empty;
             Cd_condpgto = string.Empty;
             ds_condpgto = string.Empty;
             Cd_moeda = string.Empty;
             Ds_moeda = string.Empty;
             Sigla = string.Empty;
             Tp_docto = null;
             tp_doctostring = string.Empty;
             ds_tpdocto = string.Empty;
             Ds_cmi = string.Empty;
             Tp_movimento = string.Empty;
             tipo_movimento = string.Empty;
             St_mestra = "N";
             st_mestrabool = false;
             St_devolucao = "N";
             st_devolucaobool = false;
             St_complementar = "N";
             st_complementarbool = false;
             St_geraestoque = "N";
             st_geraestoquebool = false;
             St_simplesremessa = "N";
             st_simplesremessabool = false;
             this.st_compdevimposto = "N"; ;
             this.st_compdevimpostobool = false;
             this.st_retorno = "N";
             this.st_retornobool = false;
             St_registro = "A";
        }
    }

    public class TCD_CadCMI : TDataQuery
    {
        public TCD_CadCMI()
        { }

        public TCD_CadCMI(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public TCD_CadCMI(string vNM_ProcSqlBusca)
        {
            this.NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
            else
            {
                string sql = this.GetType().GetMethod(this.NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, string.Empty }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo) 
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
            else
            {
                string sql = this.GetType().GetMethod(this.NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }
        
        public TList_CadCMI Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCMI lista = new TList_CadCMI();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCMI reg = new TRegistro_CadCMI();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CMI"))))
                        reg.Cd_cmi = reader.GetDecimal(reader.GetOrdinal("CD_CMI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Duplicata"))))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata"))))
                        reg.ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_dup")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico_dup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_condpgto"))))
                        reg.ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("cd_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moeda_singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Docto"))))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_tpdocto"))))
                        reg.ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));                    
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CMI"))))
                        reg.Ds_cmi = reader.GetString(reader.GetOrdinal("DS_CMI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Mestra"))))
                        reg.St_mestra = reader.GetString(reader.GetOrdinal("ST_Mestra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Devolucao"))))
                        reg.St_devolucao = reader.GetString(reader.GetOrdinal("ST_Devolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Complementar"))))
                        reg.St_complementar = reader.GetString(reader.GetOrdinal("ST_Complementar"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_GeraEstoque"))))
                        reg.St_geraestoque = reader.GetString(reader.GetOrdinal("ST_GeraEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_SimplesRemessa"))))
                        reg.St_simplesremessa = reader.GetString(reader.GetOrdinal("ST_SimplesRemessa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_CompDevImposto")))
                        reg.St_compdevimposto = reader.GetString(reader.GetOrdinal("ST_CompDevImposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Retorno")))
                        reg.St_retorno = reader.GetString(reader.GetOrdinal("ST_Retorno"));
                    
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

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_CMI, a.DS_CMI, a.TP_Docto, b.DS_TpDocto, a.CD_CondPgto, ");
                sql.AppendLine("c.DS_CondPgto, a.TP_Duplicata, d.DS_TpDuplicata, a.TP_Movimento, ");
                sql.AppendLine("a.ST_Mestra, a.ST_Complementar, a.ST_GeraEstoque, a.ST_SimplesRemessa, ");
                sql.AppendLine("a.ST_Registro, c.qt_parcelas, a.ST_Devolucao, a.ST_CompDevImposto, ");
                sql.AppendLine("c.qt_diasdesdobro, a.ST_Retorno, c.cd_moeda, f.ds_moeda_singular, f.sigla, ");
                sql.AppendLine("d.cd_historico_dup, e.ds_historico ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_CMI a ");
            sql.AppendLine("left outer join TB_FIN_TPDocto_Dup b ");
            sql.AppendLine("On b.TP_Docto = a.TP_Docto ");
            sql.AppendLine("left outer join TB_FIN_CondPgto c ");
            sql.AppendLine("On c.CD_CondPgto = a.CD_CondPgto ");
            sql.AppendLine("left outer join TB_FIN_TPDuplicata d ");
            sql.AppendLine("On d.TP_Duplicata = a.TP_Duplicata ");
            sql.AppendLine("left outer join TB_FIN_Historico e ");
            sql.AppendLine("On d.cd_historico_dup = e.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Moeda f ");
            sql.AppendLine("On c.cd_moeda = f.cd_moeda ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " ) ");

            return sql.ToString();
        }

        public string SqlCodeBuscaCMI_X_MOV(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_CMI, a.DS_CMI, a.TP_Docto, b.DS_TpDocto, a.CD_CondPgto, ");
                sql.AppendLine("c.DS_CondPgto, a.TP_Duplicata, d.DS_TpDuplicata, ");
                sql.AppendLine("a.TP_Movimento, a.ST_Mestra, a.ST_Devolucao, a.ST_Registro, ");
                sql.AppendLine("a.ST_Complementar, a.ST_GeraEstoque, a.ST_SimplesRemessa, ");
                sql.AppendLine("a.ST_CompDevImposto, a.ST_Retorno, ");
                sql.AppendLine("a.DT_Cad, a.DT_Alt, c.qt_parcelas, c.QT_DiasDesdobro, c.ST_ComEntrada, ");
                sql.AppendLine("c.CD_Juro_Fin, jfin.ds_juro as DS_Juro_Fin, jfin.pc_jurodiario_atrazo, jfin.tp_juro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_CMI a ");
            sql.AppendLine("left outer join TB_FIN_TPDocto_Dup b ");
            sql.AppendLine("On b.TP_Docto = a.TP_Docto ");
            sql.AppendLine("left outer join TB_FIN_CondPgto c ");
            sql.AppendLine("On c.CD_CondPgto = a.CD_CondPgto ");
            sql.AppendLine("left outer join TB_FIN_TPDuplicata d ");
            sql.AppendLine("On d.TP_Duplicata = a.TP_Duplicata ");
            sql.AppendLine("left outer join tb_fin_juro jfin ");
            sql.AppendLine("on c.cd_Juro_fin = jfin.cd_juro ");
            sql.AppendLine("inner join TB_FIS_Mov_X_CMI f ");
            sql.AppendLine("on f.cd_cmi = a.cd_cmi ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            else
            {
                string sql = this.GetType().GetMethod(this.NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public string Gravar(TRegistro_CadCMI val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_CD_CMI", val.Cd_cmi);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_DS_CMI", val.Ds_cmi);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_ST_MESTRA", val.St_mestra);
            hs.Add("@P_ST_DEVOLUCAO", val.St_devolucao);
            hs.Add("@P_ST_COMPLEMENTAR", val.St_complementar);
            hs.Add("@P_ST_GERAESTOQUE", val.St_geraestoque);
            hs.Add("@P_ST_SIMPLESREMESSA", val.St_simplesremessa);
            hs.Add("@P_ST_COMPDEVIMPOSTO", val.St_compdevimposto);
            hs.Add("@P_ST_RETORNO", val.St_retorno);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIS_CMI", hs);
        }

        public string Excluir(TRegistro_CadCMI val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CMI", val.Cd_cmi);

            return executarProc("EXCLUI_FIS_CMI", hs);
        }
    }

}
