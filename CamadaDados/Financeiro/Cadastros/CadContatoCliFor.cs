using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadContatoCliFor : List<TRegistro_CadContatoCliFor>, IComparer<TRegistro_CadContatoCliFor>
    {
        #region IComparer<TRegistro_CadContatoCliFor> Members
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

        public TList_CadContatoCliFor()
        { }

        public TList_CadContatoCliFor(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadContatoCliFor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadContatoCliFor x, TRegistro_CadContatoCliFor y)
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
    
    public class TRegistro_CadContatoCliFor
    {
        public decimal Id_Contato { set; get; }
        public string Id_Contato_St
        {
            get { return Id_Contato.ToString(); } 
            set {

                try { Id_Contato = decimal.Parse(value); } 
                catch { } 
            } 
        }
        public string Cd_CliFor
        {get; set;}        
        private string tp_contato;
        public string Tp_Contato
        {
            get { return tp_contato; }
            set
            {
                tp_contato = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_contato = "FINANCEIRO";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_contato = "COMERCIAL";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_contato = "OPERACIONAL";
                else if (value.Trim().ToUpper().Equals("O"))
                    tipo_contato = "OUTROS";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_contato = "FATURAMENTO";
            }
        }
        private string tipo_contato;
        public string Tipo_contato
        {
            get { return tipo_contato; }
            set
            {
                tipo_contato = value;
                if (value.Trim().ToUpper().Equals("FINANCEIRO"))
                    tp_contato = "F";
                else if (value.Trim().ToUpper().Equals("COMERCIAL"))
                    tp_contato = "C";
                else if (value.Trim().ToUpper().Equals("OPERACIONAL"))
                    tp_contato = "P";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_contato = "O";
                else if (value.Trim().ToUpper().Equals("FATURAMENTO"))
                    tp_contato = "T";
            }
        }
        public string Nm_Contato
        { get; set; }
        public string Email
        {get; set;}
        public string Fone
        {get; set;}
        public string FoneMovel
        {get; set;}
        public string ST_Registro
        {
            get;
            set;
        }
        public bool St_utilizarContato
        { get; set; }
        public string DS_Observacao { get; set; }
        private string st_receberdanfe;
        public string St_receberdanfe
        {
            get { return st_receberdanfe; }
            set
            {
                st_receberdanfe = value;
                st_receberdanfebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_receberdanfebool;
        public bool St_receberdanfebool
        {
            get { return st_receberdanfebool; }
            set
            {
                st_receberdanfebool = value;
                st_receberdanfe = value ? "S" : "N";
            }
        }
        private string st_receberxmlnfe;
        public string St_receberxmlnfe
        {
            get { return st_receberxmlnfe; }
            set
            {
                st_receberxmlnfe = value;
                st_receberxmlnfebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_receberxmlnfebool;
        public bool St_receberxmlnfebool
        {
            get { return st_receberxmlnfebool; }
            set
            {
                st_receberxmlnfebool = value;
                st_receberxmlnfe = value ? "S" : "N";
            }
        }
        private string st_receberos;
        public string St_receberOS
        {
            get { return st_receberos; }
            set
            {
                st_receberos = value;
                st_receberosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_receberosbool;
        public bool St_receberOSbool
        {
            get { return st_receberosbool; }
            set
            {
                st_receberosbool = value;
                st_receberos = value ? "S" : "N";
            }
        }
        private string tp_relacionamento;
        public string Tp_relacionamento
        {
            get { return tp_relacionamento; }
            set
            {
                tp_relacionamento = value;
                if (value.Trim().ToUpper().Equals("PA"))
                    tipo_relacionamento = "PAI";
                else if (value.Trim().ToUpper().Equals("MA"))
                    tipo_relacionamento = "MÃE";
                else if (value.Trim().ToUpper().Equals("FL"))
                    tipo_relacionamento = "FILHO/FILHA";
                else if (value.Trim().ToUpper().Equals("NT"))
                    tipo_relacionamento = "NETO/NETA";
                else if (value.Trim().ToUpper().Equals("AV"))
                    tipo_relacionamento = "AVÔ/AVÓ";
                else if (value.Trim().ToUpper().Equals("PR"))
                    tipo_relacionamento = "PRIMO/PRIMA";
                else if (value.Trim().ToUpper().Equals("SB"))
                    tipo_relacionamento = "SOBRINHO/SOBRINHA";
                else if (value.Trim().ToUpper().Equals("TI"))
                    tipo_relacionamento = "TIO/TIA";
                else if (value.Trim().ToUpper().Equals("SG"))
                    tipo_relacionamento = "SOGRO/SOGRA";
                else if (value.Trim().ToUpper().Equals("CH"))
                    tipo_relacionamento = "CUNHADO/CUNHADA";
                else if (value.Trim().ToUpper().Equals("AM"))
                    tipo_relacionamento = "AMIGO/AMIGA";
                else if (value.Trim().ToUpper().Equals("VZ"))
                    tipo_relacionamento = "VIZINHO/VIZINHA";
                else if (value.Trim().ToUpper().Equals("OU"))
                    tipo_relacionamento = "OUTROS";
            }
        }
        private string tipo_relacionamento;
        public string Tipo_relaciomento
        {
            get { return tipo_relacionamento; }
            set
            {
                tipo_relacionamento = value;
                if (value.Trim().ToUpper().Equals("PAI"))
                    tp_relacionamento = "PA";
                else if (value.Trim().ToUpper().Equals("MÃE"))
                    tp_relacionamento = "MA";
                else if (value.Trim().ToUpper().Equals("FILHO/FILHA"))
                    tp_relacionamento = "FL";
                else if (value.Trim().ToUpper().Equals("NETO/NETA"))
                    tp_relacionamento = "NT";
                else if (value.Trim().ToUpper().Equals("AVÔ/AVÓ"))
                    tp_relacionamento = "AV";
                else if (value.Trim().ToUpper().Equals("PRIMO/PRIMA"))
                    tp_relacionamento = "PR";
                else if (value.Trim().ToUpper().Equals("SOBRINHO/SOBRINHA"))
                    tp_relacionamento = "SB";
                else if (value.Trim().ToUpper().Equals("TIO/TIA"))
                    tp_relacionamento = "TI";
                else if (value.Trim().ToUpper().Equals("SOGRO/SOGRA"))
                    tp_relacionamento = "SG";
                else if (value.Trim().ToUpper().Equals("CUNHADO/CUNHADA"))
                    tp_relacionamento = "CH";
                else if (value.Trim().ToUpper().Equals("AMIGO/AMIGA"))
                    tp_relacionamento = "AM";
                else if (value.Trim().ToUpper().Equals("VIZINHO/VIZINHA"))
                    tp_relacionamento = "VZ";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_relacionamento = "OU";
            }
        }
        private DateTime? dt_nascimento;
        public DateTime? Dt_nascimento
        {
            get { return dt_nascimento; }
            set
            {
                dt_nascimento = value;
                dt_nascimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_nascimentostr;
        public string Dt_nascimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_nascimentostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_nascimentostr = value;
                try
                {
                    dt_nascimento = DateTime.Parse(value);
                }
                catch { dt_nascimento = null; }
            }
        }
        private string st_envemailaniversario;
        public string St_envemailaniversario
        {
            get { return st_envemailaniversario; }
            set
            {
                st_envemailaniversario = value;
                st_envemailaniversariobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_envemailaniversariobool;
        public bool St_envemailaniversariobool
        {
            get { return st_envemailaniversariobool; }
            set
            {
                st_envemailaniversariobool = value;
                st_envemailaniversario = value ? "S" : "N";
            }
        }
        public TList_DataContato lDataContato
        { get; set; }
        public TList_DataContato lDataContatoDel
        { get; set; }
        
        public TRegistro_CadContatoCliFor()
        {
            Cd_CliFor = string.Empty;
            tp_contato = string.Empty;
            tipo_contato = string.Empty;
            Email = string.Empty;
            Fone = string.Empty;
            FoneMovel = string.Empty;
            DS_Observacao = string.Empty;
            ST_Registro = "A";
            st_receberdanfe = "S";
            st_receberdanfebool = true;
            st_receberxmlnfe = "S";
            st_receberxmlnfebool = true;
            St_utilizarContato = false;
            st_receberos = "N";
            st_receberosbool = false;
            tp_relacionamento = string.Empty;
            tipo_relacionamento = string.Empty;
            dt_nascimento = null;
            dt_nascimentostr = string.Empty;
            st_envemailaniversario = "N";
            st_envemailaniversariobool = false;

            lDataContato = new TList_DataContato();
            lDataContatoDel = new TList_DataContato();
        }
    }

    public class TCD_CadContatoCliFor : TDataQuery
    {
        public TCD_CadContatoCliFor()
        { }

        public TCD_CadContatoCliFor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "  TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "  a.Id_Contato, a.CD_Clifor,a.TP_Contato, ");
                sql.AppendLine("a.NM_Contato,a.Email,a.Fone,a.FoneMovel, ds_observacao, ");
                sql.AppendLine("a.st_receberdanfe, a.st_receberxmlnfe, a.st_receberOS, ");
                sql.AppendLine("a.TP_Relacionamento, a.DT_Nascimento, a.ST_EnvEmailAniversario ");
            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_ContatoClifor a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadContatoCliFor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadContatoCliFor lista = new TList_CadContatoCliFor();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {

                while (reader.Read())
                {
                    TRegistro_CadContatoCliFor reg = new TRegistro_CadContatoCliFor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Contato"))))
                        reg.Id_Contato = reader.GetDecimal(reader.GetOrdinal("Id_Contato"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_CliFor"))))
                        reg.Cd_CliFor = reader.GetString(reader.GetOrdinal("Cd_CliFor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Contato"))))
                        reg.Tp_Contato = reader.GetString(reader.GetOrdinal("Tp_Contato"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_Contato"))))
                        reg.Nm_Contato = reader.GetString(reader.GetOrdinal("Nm_Contato"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Email"))))
                        reg.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fone"))))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("FoneMovel"))))
                        reg.FoneMovel = reader.GetString(reader.GetOrdinal("FoneMovel"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_receberdanfe")))
                        reg.St_receberdanfe = reader.GetString(reader.GetOrdinal("st_receberdanfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_receberxmlnfe")))
                        reg.St_receberxmlnfe = reader.GetString(reader.GetOrdinal("st_receberxmlnfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_receberOS")))
                        reg.St_receberOS = reader.GetString(reader.GetOrdinal("st_receberOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Relacionamento")))
                        reg.Tp_relacionamento = reader.GetString(reader.GetOrdinal("TP_Relacionamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Nascimento")))
                        reg.Dt_nascimento = reader.GetDateTime(reader.GetOrdinal("DT_Nascimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EnvEmailAniversario")))
                        reg.St_envemailaniversario = reader.GetString(reader.GetOrdinal("ST_EnvEmailAniversario"));
                    lista.Add(reg);
                }
            }
            catch
            {
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

        public string GravarContatoCliFor(TRegistro_CadContatoCliFor val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_ID_CONTATO", val.Id_Contato);
            hs.Add("@P_CD_CLIFOR", val.Cd_CliFor);
            hs.Add("@P_TP_CONTATO", val.Tp_Contato);
            hs.Add("@P_NM_CONTATO", val.Nm_Contato);
            hs.Add("@P_EMAIL", val.Email);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_FONEMOVEL", val.FoneMovel);
            hs.Add("@P_DS_OBSERVACAO", val.DS_Observacao);
            hs.Add("@P_ST_RECEBERDANFE", val.St_receberdanfe);
            hs.Add("@P_ST_RECEBERXMLNFE", val.St_receberxmlnfe);
            hs.Add("@P_ST_RECEBEROS", val.St_receberOS);
            hs.Add("@P_TP_RELACIONAMENTO", val.Tp_relacionamento);
            hs.Add("@P_DT_NASCIMENTO", val.Dt_nascimento);
            hs.Add("@P_ST_ENVEMAILANIVERSARIO", val.St_envemailaniversario);

            return executarProc("IA_FIN_CONTATOCLIFOR", hs);
        }

        public string DeletarContatoCliFor(TRegistro_CadContatoCliFor val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_CONTATO", val.Id_Contato);
            hs.Add("@P_CD_CLIFOR", val.Cd_CliFor);

            return executarProc("EXCLUI_FIN_CONTATOCLIFOR", hs);
        }
    }
}
