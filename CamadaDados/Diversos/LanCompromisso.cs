using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Collections;

namespace CamadaDados.Diversos
{
    public class TList_LanCompromisso : List<TRegistro_LanCompromisso>
    { }
    
    public class TRegistro_LanCompromisso
    {
        private decimal? id_Compromisso;
        public decimal? Id_Compromisso
        {
            get { return id_Compromisso; }
            set
            {
                id_Compromisso = value;
                _ID_Compromisso_String = value.HasValue ? value.Value.ToString() : string.Empty;

            }
        }

        private string _ID_Compromisso_String;
        public string ID_Compromisso_String
        {
            get { return _ID_Compromisso_String; }
            set
            {
                _ID_Compromisso_String = value;
                try
                { id_Compromisso = Convert.ToDecimal(value); }
                catch
                { id_Compromisso = null; }
            }
        }

        public string Nm_Compromisso
        { get; set; }

        public string Ds_Compromisso
        { get; set; }

        private DateTime? dt_Compromisso;
        public DateTime? Dt_Compromisso
        {
            get { return dt_Compromisso; }
            set
            {
                dt_Compromisso = value;
                dtCompromisso = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }

        private string dtCompromisso;
        public string DtCompromisso
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dtCompromisso).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dtCompromisso = value;
                try
                {
                    dt_Compromisso = Convert.ToDateTime(value);
                }
                catch
                { dt_Compromisso = null; }
            }
        }

        public string UsuarioCompromisso
        { get; set; }

        public string EmailUsuarioCompromisso
        { get; set; }

        public string Login
        { get; set; }

        private string st_Compromisso;
        public string St_Compromisso
        {
            get { return st_Compromisso; }
            set
            {
                st_Compromisso = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_compromisso = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_compromisso = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status_compromisso = "EXECUTADO";
            }
        }

        private string status_compromisso;
        public string Status_compromisso
        {
            get { return status_compromisso; }
            set
            {
                st_Compromisso = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_Compromisso = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_Compromisso = "C";
                else if (value.Trim().ToUpper().Equals("EXECUTADO"))
                    st_Compromisso = "E";
            }
        }

        private string st_enviaremail;
        public string St_enviaremail
        {
            get { return st_enviaremail; }
            set
            {
                st_enviaremail = value;
                st_enviaremailbool = value.Trim().ToUpper().Equals("S");
            }
        }

        private bool st_enviaremailbool;
        public bool St_enviaremailbool
        {
            get { return st_enviaremailbool; }
            set
            {
                st_enviaremailbool = value;
                st_enviaremail = value ? "S" : "N";
            }
        }

        public TRegistro_LanCompromisso()
        {
            id_Compromisso = null;
            Nm_Compromisso = string.Empty;
            UsuarioCompromisso = string.Empty;
            this.EmailUsuarioCompromisso = string.Empty;
            this.Login = string.Empty;
            Ds_Compromisso = string.Empty;
            dt_Compromisso = null;
            dtCompromisso = string.Empty;
            st_Compromisso = "A";
            this.st_enviaremail = "N";
            this.st_enviaremailbool = false;
        }
    }

    public class TCD_LanCompromisso : TDataQuery
    {
        public TCD_LanCompromisso() { }

        public TCD_LanCompromisso(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string sqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_compromisso, a.UsuarioCompromisso, b.email_padrao, a.NM_Compromisso, ");
                sql.AppendLine("a.DS_Compromisso, a.DT_Compromisso, a.ST_Compromisso, a.Login, a.st_enviaremail ");
            }
            else
                sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM tb_div_compromisso a");
            sql.AppendLine("inner join tb_div_usuario b ");
            sql.AppendLine("on a.usuariocompromisso = b.login ");

            string cond = "where";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "and";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.sqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
       
        public TList_LanCompromisso Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanCompromisso lista = new TList_LanCompromisso();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.sqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanCompromisso reg = new TRegistro_LanCompromisso();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_Compromisso")))
                        reg.Id_Compromisso = reader.GetDecimal(reader.GetOrdinal("id_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_Compromisso")))
                        reg.Nm_Compromisso = reader.GetString(reader.GetOrdinal("nm_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Compromisso")))
                        reg.Ds_Compromisso = reader.GetString(reader.GetOrdinal("ds_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_Compromisso")))
                        reg.Dt_Compromisso = reader.GetDateTime(reader.GetOrdinal("dt_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("usuarioCompromisso")))
                        reg.UsuarioCompromisso = reader.GetString(reader.GetOrdinal("usuarioCompromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email_padrao")))
                        reg.EmailUsuarioCompromisso = reader.GetString(reader.GetOrdinal("email_padrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Compromisso")))
                        reg.St_Compromisso = (reader.GetString(reader.GetOrdinal("st_Compromisso")));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_enviaremail")))
                        reg.St_enviaremail = reader.GetString(reader.GetOrdinal("st_enviaremail"));

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

        public string Grava(TRegistro_LanCompromisso vRegitro)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_COMPROMISSO", vRegitro.Id_Compromisso);
            hs.Add("@P_USUARIOCOMPROMISSO", vRegitro.UsuarioCompromisso);
            hs.Add("@P_NM_COMPROMISSO", vRegitro.Nm_Compromisso);
            hs.Add("@P_DS_COMPROMISSO", vRegitro.Ds_Compromisso);
            hs.Add("@P_DT_COMPROMISSO", vRegitro.Dt_Compromisso);
            hs.Add("@P_ST_COMPROMISSO", vRegitro.St_Compromisso);
            hs.Add("@P_LOGIN", vRegitro.Login);
            hs.Add("@P_ST_ENVIAREMAIL", vRegitro.St_enviaremail);

            return this.executarProc("IA_DIV_COMPROMISSO", hs);
        }

        public string Deleta(TRegistro_LanCompromisso vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_COMPROMISSO", vRegistro.Id_Compromisso);
            return this.executarProc("EXCLUI_DIV_COMPROMISSO", hs);
        }
    }
}