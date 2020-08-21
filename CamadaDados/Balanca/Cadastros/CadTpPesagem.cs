using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Balanca.Cadastros
{
    public class TList_CadTpPesagem : List<TRegistro_CadTpPesagem>, IComparer<TRegistro_CadTpPesagem>
    {
        #region IComparer<TRegistro_CadTpPesagem> Members
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

        public TList_CadTpPesagem()
        { }

        public TList_CadTpPesagem(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTpPesagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTpPesagem x, TRegistro_CadTpPesagem y)
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
    
    public class TRegistro_CadTpPesagem
    {
        public string Tp_pesagem
        { get; set; }
        public string Nm_tppesagem
        { get; set; }
        private string st_seqmanual;
        public string St_seqmanual
        {
            get { return st_seqmanual; }
            set
            {
                st_seqmanual = value;
                st_seqmanualbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_seqmanualbool;
        public bool St_seqmanualbool
        {
            get { return st_seqmanualbool; }
            set
            {
                st_seqmanualbool = value;
                if (value)
                    st_seqmanual = "S";
                else
                    st_seqmanual = "N";
            }
        }
        private string tp_modo;
        public string Tp_modo
        {
            get { return tp_modo; }
            set
            {
                tp_modo = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_modo = "GRAOS";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_modo = "FAZENDA";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_modo = "AVULSA";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_modo = "DIVERSA";
            }
        }
        private string tipo_modo;
        public string Tipo_modo
        {
            get { return tipo_modo; }
            set
            {
                tipo_modo = value;
                if (value.Trim().ToUpper().Equals("GRAOS"))
                    tp_modo = "G";
                else if (value.Trim().ToUpper().Equals("FAZENDA"))
                    tp_modo = "F";
                else if (value.Trim().ToUpper().Equals("AVULSA"))
                    tp_modo = "V";
                else if (value.Trim().ToUpper().Equals("DIVERSA"))
                    tp_modo = "D";
            }
        }
        private string ordempesagem;
        public string Ordempesagem
        {
            get { return ordempesagem; }
            set
            {
                ordempesagem = value;
                if (value.Trim().ToUpper().Equals("BT"))
                    ordempsextenso = "BRUTO/TARA";
                else if (value.Trim().ToUpper().Equals("TB"))
                    ordempsextenso = "TARA/BRUTO";
                else if (value.Trim().ToUpper().Equals("NM"))
                    ordempsextenso = "NORMAL CONFORME TIPO DE MOVIMENTO";
                else if (value.Trim().ToUpper().Equals("DI"))
                    ordempsextenso = "DIRETA BRUTO E TARA";
            }
        }
        private string ordempsextenso;
        public string Ordempsextenso
        {
            get { return ordempsextenso; }
            set
            {
                ordempsextenso = value;
                if (value.Trim().ToUpper().Equals("BRUTO/TARA"))
                    ordempesagem = "BT";
                else if (value.Trim().ToUpper().Equals("TARA/BRUTO"))
                    ordempesagem = "TB";
                else if (value.Trim().ToUpper().Equals("NORMAL CONFORME TIPO DE MOVIMENTO"))
                    ordempesagem = "NM";
                else if (value.Trim().ToUpper().Equals("DIRETA BRUTO E TARA"))
                    ordempesagem = "DI";
            }
        }
        private string tp_movdefault;
        public string Tp_movdefault
        {
            get { return tp_movdefault; }
            set
            {
                tp_movdefault = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movdefault = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movdefault = "SAIDA";
            }
        }
        private string tipo_movdefault;
        public string Tipo_movdefault
        {
            get { return tipo_movdefault; }
            set
            {
                tipo_movdefault = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movdefault = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movdefault = "S";
            }
        }
        private string tp_transbordo;
        public string Tp_transbordo
        {
            get { return tp_transbordo; }
            set
            {
                tp_transbordo = value;
                tipo_transbordo = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool tipo_transbordo;
        public bool Tipo_transbordo
        {
            get { return tipo_transbordo; }
            set
            {
                tipo_transbordo = value;
                if (value)
                    tp_transbordo = "S";
                else
                    tp_transbordo = "N";
            }
        }
        public bool Tp_fazenda
        {
            get { return tp_modo.Trim().ToUpper().Equals("F"); }
        }        
        public decimal Ps_Min_Bruto
        { get; set; }
        public decimal Ps_Min_Tara
        { get; set; }
        public string Cd_protocolo { get; set; }
        public string Ds_protocolo { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadTpPesagem()
        {
            Tp_pesagem = string.Empty;
            Nm_tppesagem = string.Empty;
            st_seqmanual = "N";
            st_seqmanualbool = false;
            tp_modo = string.Empty;
            tipo_modo = string.Empty;
            ordempesagem = string.Empty;
            ordempsextenso = string.Empty;
            tp_movdefault = string.Empty;
            tipo_movdefault = string.Empty;
            tp_transbordo = "N";
            tipo_transbordo = false;
            Ps_Min_Bruto = decimal.Zero;
            Ps_Min_Tara = decimal.Zero;
            Cd_protocolo = string.Empty;
            Ds_protocolo = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_CadTpPesagem : TDataQuery
    {
        public TCD_CadTpPesagem()
        { }

        public TCD_CadTpPesagem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.tp_pesagem, a.nm_tppesagem, a.st_seqmanual, ");
                sql.AppendLine("a.tp_modo, a.ordempesagem, a.tp_movdefault, a.cd_protocolo, b.ds_protocolo, ");
                sql.AppendLine("a.tp_transbordo, a.ps_min_bruto, a.ps_min_tara ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_tppesagem a ");
            sql.AppendLine("left outer join tb_div_protocolo b ");
            sql.AppendLine("on a.cd_protocolo = b.cd_protocolo ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadTpPesagem Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadTpPesagem lista = new TList_CadTpPesagem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadTpPesagem reg = new TRegistro_CadTpPesagem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_TpPesagem"))))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TpPesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_SeqManual"))))
                        reg.St_seqmanual = reader.GetString(reader.GetOrdinal("ST_SeqManual"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Modo"))))
                        reg.Tp_modo = reader.GetString(reader.GetOrdinal("TP_Modo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("OrdemPesagem")))
                        reg.Ordempesagem = reader.GetString(reader.GetOrdinal("OrdemPesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_MovDefault")))
                        reg.Tp_movdefault = reader.GetString(reader.GetOrdinal("TP_MovDefault"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Transbordo")))
                        reg.Tp_transbordo = reader.GetString(reader.GetOrdinal("TP_Transbordo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Min_Bruto")))
                        reg.Ps_Min_Bruto = reader.GetDecimal(reader.GetOrdinal("Ps_Min_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Min_Tara")))
                        reg.Ps_Min_Tara = reader.GetDecimal(reader.GetOrdinal("Ps_Min_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Protocolo")))
                        reg.Cd_protocolo = reader.GetString(reader.GetOrdinal("CD_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Protocolo")))
                        reg.Ds_protocolo = reader.GetString(reader.GetOrdinal("DS_Protocolo"));

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

        public string Gravar(TRegistro_CadTpPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_NM_TPPESAGEM", val.Nm_tppesagem);
            hs.Add("@P_ST_SEQMANUAL", val.St_seqmanual);
            hs.Add("@P_TP_MODO", val.Tp_modo);
            hs.Add("@P_ORDEMPESAGEM", val.Ordempesagem);
            hs.Add("@P_TP_MOVDEFAULT", val.Tp_movdefault);
            hs.Add("@P_TP_TRANSBORDO", val.Tp_transbordo);
            hs.Add("@P_PS_MIN_BRUTO", val.Ps_Min_Bruto);
            hs.Add("@P_PS_MIN_TARA", val.Ps_Min_Tara);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);

            return executarProc("IA_BAL_TPPESAGEM", hs);
        }

        public string Excluir(TRegistro_CadTpPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return executarProc("EXCLUI_BAL_TPPESAGEM", hs);
        }
    }
}
