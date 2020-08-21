using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    #region Condição Pagamento
    public class TList_CadCondPgto : List<TRegistro_CadCondPgto>, IComparer<TRegistro_CadCondPgto>
    {
        #region IComparer<TRegistro_CadCondPgto> Members
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

        public TList_CadCondPgto()
        { }

        public TList_CadCondPgto(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCondPgto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCondPgto x, TRegistro_CadCondPgto y)
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

    public class TRegistro_CadCondPgto
    {
        public string Cd_condpgto { get; set; }
        public string Ds_condpgto { get; set; }
        public string Cd_portador { get; set; }
        public string Ds_portador { get; set; }
        public string Cd_moeda { get; set; }
        public string Ds_moeda_singular { get; set; }
        public string Sigla { get; set; }
        private string st_comentrada;
        private bool st_comentradabool;
        public string Cd_juro { get; set; }
        public string Ds_juro { get; set; }
        public string Tp_juro { get; set; }
        public string cd_Juro_Fin { get; set; }
        public string ds_Juro_Fin { get; set; }
        public string Tp_juro_fin { get; set; }
        public decimal Pc_jurodiario_atrazo { get; set; }
        public decimal Pc_jurodiario_atrazoFin { get; set; }
        public decimal Qt_parcelas { get; set; }
        public decimal Qt_diasdesdobro { get; set; }
        private string st_registro;
        public string St_registro 
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                status = value.Trim().ToUpper().Equals("A");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value)
                    st_registro = "A";
                else
                    st_registro = "C";
            }
        }
        private string st_venctoemferiado;
        private bool st_venctoemferiadobool;
        private string st_solicitardtvencto;
        private bool st_solicitardtvenctobool;
        public string St_comentrada
        {
            get
            {
                return st_comentrada;
            }
            set
            {
                st_comentrada = value;
                st_comentradabool = value.Trim().ToUpper().Equals("S");
            }
        }
        public bool St_comentradabool
        {
            get { return st_comentradabool; }
            set
            {
                st_comentradabool = value;
                if (value)
                    st_comentrada = "S";
                else
                    st_comentrada = "N";
            }
        }
        public string St_venctoemferiado
        {
            get { return st_venctoemferiado; }
            set
            {
                st_venctoemferiado = value;
                st_venctoemferiadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        public bool St_venctoemferiadobool
        {
            get { return st_venctoemferiadobool; }
            set 
            { 
                st_venctoemferiadobool = value;
                if (value)
                    st_venctoemferiado = "S";
                else
                    st_venctoemferiado = "N";
            }
        }
        public string St_solicitardtvencto 
        {
            get { return st_solicitardtvencto; }
            set
            {
                st_solicitardtvencto = value;
                st_solicitardtvenctobool = value.Trim().ToUpper().Equals("S");
            }
        }
        public bool St_solicitardtvenctobool
        {
            get { return st_solicitardtvenctobool; }
            set 
            { 
                st_solicitardtvenctobool = value;
                if (value)
                    st_solicitardtvencto = "S";
                else
                    st_solicitardtvencto = "N";
            }
        }
        public decimal pc_custofin { get; set; }
        public TList_CadCondPgto_X_Parcelas lCondPgto_X_Parcelas
        { get; set; }
        public TList_CadCondPgto_X_Parcelas lCondParcDel
        { get; set; }


        public TRegistro_CadCondPgto()
        {
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda_singular = string.Empty;
            this.Sigla = string.Empty;
            this.st_comentrada = string.Empty;
            this.st_comentradabool = false;
            this.Cd_juro = string.Empty;
            this.Ds_juro = string.Empty;
            this.Tp_juro = string.Empty;
            this.Pc_jurodiario_atrazo = 0;
            this.cd_Juro_Fin = string.Empty;
            this.ds_Juro_Fin = string.Empty;
            this.Tp_juro_fin = string.Empty;
            this.Pc_jurodiario_atrazoFin = 0;
            this.Qt_parcelas = 1;
            this.Qt_diasdesdobro = 0;
            this.pc_custofin = decimal.Zero;
            this.St_registro = "A";
            this.status = true;
            this.st_venctoemferiado = "N";
            this.st_venctoemferiadobool = false;
            this.st_solicitardtvencto = "N";
            this.st_solicitardtvenctobool = false;
            this.lCondPgto_X_Parcelas = new TList_CadCondPgto_X_Parcelas();
            this.lCondParcDel = new TList_CadCondPgto_X_Parcelas();
        }
    }

    public class TCD_CadCondPgto : TDataQuery
    {
        public TCD_CadCondPgto()
        { }

        public TCD_CadCondPgto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.cd_condpgto, a.ds_condpgto, a.cd_portador, b.ds_portador, d.pc_jurodiario_atrazo, ");
                sql.AppendLine("a.cd_moeda, c.ds_moeda_singular, c.sigla, a.st_comentrada, a.cd_juro, d.ds_juro,a.cd_juro_fin,e.ds_juro as ds_juro_fin, ");
                sql.AppendLine("d.pc_juroDiario_atrazo,e.pc_juroDiario_atrazo as pc_juroDiario_atrazoFin, e.tp_juro as tp_juro_fin, ");
                sql.AppendLine("a.qt_diasdesdobro, a.st_registro, a.st_venctoemferiado, a.st_solicitardtvencto, ");
                sql.AppendLine("b.st_controletitulo, d.tp_juro, a.qt_parcelas, a.pc_custofin ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + "");
            
            sql.AppendLine("from tb_fin_condpgto a ");
            sql.AppendLine("left outer join tb_fin_portador b ");
            sql.AppendLine("on a.cd_portador = b.cd_portador ");
            sql.AppendLine("left outer join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moeda = c.cd_moeda ");
            sql.AppendLine("left outer join tb_fin_juro d ");
            sql.AppendLine("on a.cd_juro = d.cd_juro ");
            sql.AppendLine("left outer join tb_fin_juro e ");
            sql.AppendLine("on a.cd_juro_fin = e.cd_juro ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            sql.AppendLine("order by a.cd_condpgto ");
            return sql.ToString();
        }

        public TList_CadCondPgto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCondPgto lista = new TList_CadCondPgto();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCondPgto reg = new TRegistro_CadCondPgto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO"))))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO")).Trim();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_moeda_singular")))
                        reg.Ds_moeda_singular = reader.GetString(reader.GetOrdinal("Ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_ComEntrada"))))
                        reg.St_comentrada = reader.GetString(reader.GetOrdinal("ST_ComEntrada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Juro"))))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("CD_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Juro")))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("DS_Juro"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_juro_fin"))))
                        reg.cd_Juro_Fin = reader.GetString(reader.GetOrdinal("cd_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_juro_Fin")))
                        reg.ds_Juro_Fin = reader.GetString(reader.GetOrdinal("ds_juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_juro_fin")))
                        reg.Tp_juro_fin = reader.GetString(reader.GetOrdinal("tp_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_jurodiario_atrazoFin")))
                        reg.Pc_jurodiario_atrazoFin = reader.GetDecimal(reader.GetOrdinal("Pc_jurodiario_atrazoFin"));

                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Juro")))
                        reg.Tp_juro = reader.GetString(reader.GetOrdinal("TP_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo")))
                        reg.Pc_jurodiario_atrazo = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Parcelas"))))
                        reg.Qt_parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_DiasDesdobro"))))
                        reg.Qt_diasdesdobro = reader.GetDecimal(reader.GetOrdinal("QT_DiasDesdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_VenctoEmFeriado"))))
                        reg.St_venctoemferiado = reader.GetString(reader.GetOrdinal("ST_VenctoEmFeriado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_SolicitarDTVencto"))))
                        reg.St_solicitardtvencto = reader.GetString(reader.GetOrdinal("ST_SolicitarDTVencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("pc_custofin"))))
                        reg.pc_custofin = reader.GetDecimal(reader.GetOrdinal("pc_custofin"));

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

        public string GravarCondPgto(TRegistro_CadCondPgto val)
        {
            Hashtable hs = new Hashtable(11);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_DS_CONDPGTO", val.Ds_condpgto);
            hs.Add("@P_CD_JURO_FIN", val.cd_Juro_Fin);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_ST_COMENTRADA", val.St_comentrada);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_QT_PARCELAS", val.Qt_parcelas);
            hs.Add("@P_QT_DIASDESDOBRO", val.Qt_diasdesdobro);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ST_VENCTOEMFERIADO", val.St_venctoemferiado);
            hs.Add("@P_ST_SOLICITARDTVENCTO", val.St_solicitardtvencto);
            hs.Add("@P_PC_CUSTOFIN", val.pc_custofin);

            return executarProc("IA_FIN_CONDPGTO", hs);
        }

        public string DeletarCondPgto(TRegistro_CadCondPgto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);

            return this.executarProc("EXCLUI_FIN_CONDPGTO", hs);
        }
    }
    #endregion

    #region Condição Pagamento X Parcelas
    public class TList_CadCondPgto_X_Parcelas : List<TRegistro_CadCondPgto_X_Parcelas>
    { }
    
    public class TRegistro_CadCondPgto_X_Parcelas
    {
        public string Cd_condpgto
        { get; set; }
        public decimal Id_parcela
        { get; set; }
        public decimal Qt_dias
        { get; set; }
        public decimal Pc_rateio
        { get; set; }

        public TRegistro_CadCondPgto_X_Parcelas()
        {
            this.Cd_condpgto = string.Empty;
            this.Id_parcela = 0;
            this.Qt_dias = 0;
            this.Pc_rateio = 0;
        }
    }

    public class TCD_CadCondPgto_X_Parcelas : TDataQuery
    {
        public TCD_CadCondPgto_X_Parcelas()
        { }

        public TCD_CadCondPgto_X_Parcelas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.cd_condpgto, b.ds_condpgto, ");
                sql.AppendLine("a.id_parcela, a.qt_dias, a.pc_rateio ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("from tb_fin_condpgto_x_parcelas a ");
            sql.AppendLine("inner join tb_fin_condpgto b ");
            sql.AppendLine("on a.cd_condpgto = b.cd_condpgto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_condpgto, a.id_parcela asc ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadCondPgto_X_Parcelas Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCondPgto_X_Parcelas lista = new TList_CadCondPgto_X_Parcelas();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(true);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCondPgto_X_Parcelas reg = new TRegistro_CadCondPgto_X_Parcelas();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Parcela"))))
                        reg.Id_parcela = reader.GetDecimal(reader.GetOrdinal("ID_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Dias"))))
                        reg.Qt_dias = reader.GetDecimal(reader.GetOrdinal("QT_Dias"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Rateio")))
                        reg.Pc_rateio = reader.GetDecimal(reader.GetOrdinal("PC_Rateio"));
                    
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

        public string GravarCondPgto_X_Parcelas(TRegistro_CadCondPgto_X_Parcelas val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_ID_PARCELA", val.Id_parcela);
            hs.Add("@P_QT_DIAS", val.Qt_dias);
            hs.Add("@P_PC_RATEIO", val.Pc_rateio);

            return this.executarProc("IA_FIN_CONDPGTO_X_PARCELAS", hs);
        }

        public string DeletarCondPgto_X_Parcelas(TRegistro_CadCondPgto_X_Parcelas val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_ID_PARCELA", val.Id_parcela);

            return this.executarProc("EXCLUI_FIN_CONDPGTO_X_PARCELAS", hs);
        }

        public string DeletarTodasParcelas(TRegistro_CadCondPgto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            
            return this.executarProc("EXCLUI_FIN_TODAS_PARCELAS", hs);
        }
    }
    #endregion
}
