using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_RegCadProtocolo : List<TRegistro_CadProtocolo>, IComparer<TRegistro_CadProtocolo>
    {
        #region IComparer<TRegistro_CadProtocolo> Members
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

        public TList_RegCadProtocolo()
        { }

        public TList_RegCadProtocolo(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadProtocolo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadProtocolo x, TRegistro_CadProtocolo y)
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
    
    public class TRegistro_CadProtocolo
    {
        public string Cd_protocolo
        { get; set; }
        public string Ds_protocolo
        { get; set; }
        public string Ds_porta
        { get; set; }
        public int Baudrate
        { get; set; }
        public int Databits
        { get; set; }
        public string Stopbits
        { get; set; }
        private string parity;
        public string Parity
        {
            get { return parity; }
            set
            {
                parity = value;
                if (string.IsNullOrEmpty(value))
                {
                    paritydisplay = "NONE";
                    return;
                }
                 if (value.Trim().Equals("0"))
                    paritydisplay = "NONE";
                else if (value.Trim().Equals("1"))
                    paritydisplay = "MARK";
                else if (value.Trim().Equals("2"))
                    paritydisplay = "EVEN";
                else if (value.Trim().Equals("3"))
                    paritydisplay = "ODD";
                else if (value.Trim().Equals("4"))
                    paritydisplay = "SPACE";
            }
        }
        private string paritydisplay;
        public string Paritydisplay
        {
            get { return paritydisplay; }
            set
            {
                paritydisplay = value;
                if (value.Trim().ToUpper().Equals("NOME"))
                    parity = "0";
                else if (value.Trim().ToUpper().Equals("MARK"))
                    parity = "1";
                else if (value.Trim().ToUpper().Equals("EVEN"))
                    parity = "2";
                else if (value.Trim().ToUpper().Equals("ODD"))
                    parity = "3";
                else if (value.Trim().ToUpper().Equals("SPACE"))
                    parity = "4";
            }
        }
        private int char_eol;
        public int Char_eol
        {
            get { return char_eol; }
            set
            {
                char_eol = value;
                char_eol_str = Convert.ToChar(value);
            }
        }
        private char char_eol_str;
        public char Char_eol_str
        {
            get { return char_eol_str; }
            set
            {
                char_eol_str = value;
                char_eol = Convert.ToInt32(value);
            }
        }
        private int char_psestavel;
        public int Char_psestavel
        {
            get { return char_psestavel; }
            set
            {
                char_psestavel = value;
                char_psestavel_str = Convert.ToChar(value);
            }
        }
        private char char_psestavel_str;
        public char Char_psestavel_str
        {
            get { return char_psestavel_str; }
            set
            {
                char_psestavel_str = value;
                char_psestavel = Convert.ToInt32(value);
            }
        }
        public int Pos_ini
        { get; set; }
        public int Size_word
        { get; set; }
        public int Tam_pacote
        { get; set; }
        public int Tam_bufferread
        { get; set; }
        private string st_discartarnull;
        public string St_discartarnull
        {
            get { return st_discartarnull; }
            set
            {
                st_discartarnull = value;
                st_discartarnullbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_discartarnullbool;
        public bool St_discartarnullbool
        {
            get { return st_discartarnullbool; }
            set
            {
                st_discartarnullbool = value;
                st_discartarnull = value ? "S" : "N";
            }
        }
        private string dtrenabled;
        public string Dtrenabled
        {
            get { return dtrenabled; }
            set
            {
                dtrenabled = value;
                dtrenabledbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool dtrenabledbool;
        public bool Dtrenabledbool
        {
            get { return dtrenabledbool; }
            set
            {
                dtrenabledbool = value;
                dtrenabled = value ? "S" : "N";
            }
        }
        private string handshake;
        public string Handshake
        {
            get { return handshake; }
            set
            {
                handshake = value;
                if (value.Trim().Equals("0"))
                    handshakedisplay = "NONE";
                else if (value.Trim().Equals("1"))
                    handshakedisplay = "REQUESTTOSEND";
                else if (value.Trim().Equals("2"))
                    handshakedisplay = "REQUESTTOSENDXONXOFF";
                else if (value.Trim().Equals("3"))
                    handshakedisplay = "XONXOFF";
            }
        }
        private string handshakedisplay;
        public string Handshakedisplay
        {
            get { return handshakedisplay; }
            set
            {
                handshakedisplay = value;
                if (value.Trim().ToUpper().Equals("NONE"))
                    handshake = "0";
                else if (value.Trim().ToUpper().Equals("REQUESTTOSEND"))
                    handshake = "1";
                else if (value.Trim().ToUpper().Equals("REQUESTTOSENDXONXOFF"))
                    handshake = "2";
                else if (value.Trim().ToUpper().Equals("XONXOFF"))
                    handshake = "3";
            }
        }
        public int ReceivedBytes
        { get; set; }
        private string rtsenabled;
        public string RTSEnabled
        {
            get { return rtsenabled; }
            set
            {
                rtsenabled = value;
                rtsenabledbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool rtsenabledbool;
        public bool RTSEnabledbool
        {
            get { return rtsenabledbool; }
            set
            {
                rtsenabledbool = value;
                rtsenabled = value ? "S" : "N";
            }
        }
        private string st_utilizardll;
        public string St_utilizardll
        {
            get { return st_utilizardll; }
            set
            {
                st_utilizardll = value;
                st_utilizardllbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_utilizardllbool;
        public bool St_utilizardllbool
        {
            get { return st_utilizardllbool; }
            set
            {
                st_utilizardllbool = value;
                st_utilizardll = value ? "S" : "N";
            }
        }
        public string Nm_dll
        { get; set; }
        
        public TRegistro_CadProtocolo()
        {
            this.Cd_protocolo = string.Empty;
            this.Ds_protocolo = string.Empty;
            this.Ds_porta = string.Empty;
            this.Baudrate = 2400;
            this.Databits = 8;
            this.Stopbits = "1";
            this.parity = "0";
            this.paritydisplay = "NONE";
            this.char_eol = 0;
            this.char_eol_str = ' ';
            this.char_psestavel = 0;
            this.char_psestavel_str = ' ';
            this.Pos_ini = 0;
            this.Size_word = 0;
            this.Tam_pacote = 0;
            this.Tam_bufferread = 0;
            this.st_discartarnull = "N";
            this.st_discartarnullbool = false;
            this.dtrenabled = "N";
            this.dtrenabledbool = false;
            this.handshake = "0";
            this.handshakedisplay = "NONE";
            this.ReceivedBytes = 1;
            this.rtsenabled = "N";
            this.rtsenabledbool = false;
            this.st_utilizardll = "N";
            this.st_utilizardllbool = false;
            this.Nm_dll = string.Empty;
        }
    }

    public class TCD_CadProtocolo : TDataQuery
    {
        public TCD_CadProtocolo() { }

        public TCD_CadProtocolo(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

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
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_protocolo, a.ds_protocolo, ");
                sql.AppendLine("a.ds_porta, a.baudrate, a.databits, a.stopbits, a.parity, ");
                sql.AppendLine("a.char_eol, a.char_psestavel, a.pos_ini, a.size_word, ");
                sql.AppendLine("a.tam_pacote, a.tam_bufferread, a.st_discartarnull, a.dtrenabled, ");
                sql.AppendLine("a.handshake, a.receivedbytes, a.rtsenabled, a.st_utilizardll, a.nm_dll ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Protocolo a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_RegCadProtocolo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegCadProtocolo lista = new TList_RegCadProtocolo();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadProtocolo reg = new TRegistro_CadProtocolo();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_protocolo")))
                        reg.Cd_protocolo = reader.GetString(reader.GetOrdinal("cd_protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_protocolo")))
                        reg.Ds_protocolo = reader.GetString(reader.GetOrdinal("ds_protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_porta")))
                        reg.Ds_porta = reader.GetString(reader.GetOrdinal("ds_porta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("baudrate")))
                        reg.Baudrate = reader.GetInt32(reader.GetOrdinal("baudrate"));
                    if (!reader.IsDBNull(reader.GetOrdinal("databits")))
                        reg.Databits = reader.GetInt32(reader.GetOrdinal("databits"));
                    if (!reader.IsDBNull(reader.GetOrdinal("stopbits")))
                        reg.Stopbits = reader.GetString(reader.GetOrdinal("stopbits"));
                    if (!reader.IsDBNull(reader.GetOrdinal("parity")))
                        reg.Parity = reader.GetString(reader.GetOrdinal("parity"));
                    if (!reader.IsDBNull(reader.GetOrdinal("char_eol")))
                        reg.Char_eol = reader.GetInt32(reader.GetOrdinal("char_eol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("char_psestavel")))
                        reg.Char_psestavel = reader.GetInt32(reader.GetOrdinal("char_psestavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pos_ini")))
                        reg.Pos_ini = reader.GetInt32(reader.GetOrdinal("pos_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("size_word")))
                        reg.Size_word = reader.GetInt32(reader.GetOrdinal("size_word"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tam_pacote")))
                        reg.Tam_pacote = reader.GetInt32(reader.GetOrdinal("tam_pacote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tam_bufferread")))
                        reg.Tam_bufferread = reader.GetInt32(reader.GetOrdinal("tam_bufferread"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_discartarnull")))
                        reg.St_discartarnull = reader.GetString(reader.GetOrdinal("st_discartarnull"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dtrenabled")))
                        reg.Dtrenabled = reader.GetString(reader.GetOrdinal("dtrenabled"));
                    if (!reader.IsDBNull(reader.GetOrdinal("handshake")))
                        reg.Handshake = reader.GetString(reader.GetOrdinal("handshake"));
                    if (!reader.IsDBNull(reader.GetOrdinal("receivedbytes")))
                        reg.ReceivedBytes = reader.GetInt32(reader.GetOrdinal("receivedbytes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("rtsenabled")))
                        reg.RTSEnabled = reader.GetString(reader.GetOrdinal("rtsenabled"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_utilizardll")))
                        reg.St_utilizardll = reader.GetString(reader.GetOrdinal("st_utilizardll"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_dll")))
                        reg.Nm_dll = reader.GetString(reader.GetOrdinal("nm_dll"));
                    
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

        public string Gravar(TRegistro_CadProtocolo val)
        {
            Hashtable hs = new Hashtable(20);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);
            hs.Add("@P_DS_PROTOCOLO", val.Ds_protocolo);
            hs.Add("@P_DS_PORTA", val.Ds_porta);
            hs.Add("@P_BAUDRATE", val.Baudrate);
            hs.Add("@P_DATABITS", val.Databits);
            hs.Add("@P_STOPBITS", val.Stopbits);
            hs.Add("@P_PARITY", val.Parity);
            hs.Add("@P_CHAR_EOL", val.Char_eol);
            hs.Add("@P_CHAR_PSESTAVEL", val.Char_psestavel);
            hs.Add("@P_POS_INI", val.Pos_ini);
            hs.Add("@P_SIZE_WORD", val.Size_word);
            hs.Add("@P_TAM_PACOTE", val.Tam_pacote);
            hs.Add("@P_TAM_BUFFERREAD", val.Tam_bufferread);
            hs.Add("@P_ST_DISCARTARNULL", val.St_discartarnull);
            hs.Add("@P_DTRENABLED", val.Dtrenabled);
            hs.Add("@P_HANDSHAKE", val.Handshake);
            hs.Add("@P_RECEIVEDBYTES", val.ReceivedBytes);
            hs.Add("@P_RTSENABLED", val.RTSEnabled);
            hs.Add("@P_ST_UTILIZARDLL", val.St_utilizardll);
            hs.Add("@P_NM_DLL", val.Nm_dll);

            return executarProc("IA_DIV_PROTOCOLO", hs);
        }

        public string Excluir(TRegistro_CadProtocolo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);
            return this.executarProc("EXCLUI_DIV_PROTOCOLO", hs);
        }
    }
}
