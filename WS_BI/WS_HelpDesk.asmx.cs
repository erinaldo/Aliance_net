using System;
using System.Collections.Generic;
using System.Web.Services;
using Utils;

namespace WS_BI
{
    #region Classes
    public class TB_BIN_Setor
    {
        public decimal? Id_setor
        { get; set; }
        public string Ds_setor
        { get; set; }

        public TB_BIN_Setor()
        {
            this.Id_setor = null;
            this.Ds_setor = string.Empty;
        }
    }

    public class TB_BIN_Categoria
    {
        public decimal? Id_categoria
        { get; set; }
        public string Ds_categoria
        { get; set; }

        public TB_BIN_Categoria()
        {
            this.Id_categoria = null;
            this.Ds_categoria = string.Empty;
        }
    }

    public class TB_BIN_Etapa
    {
        public decimal? Id_etapa
        { get; set; }
        public string Ds_etapa
        { get; set; }
        public string St_abertura
        { get; set; }
        public string St_concluir
        { get; set; }
        public string St_encerrar
        { get; set; }
        public string St_interno
        { get; set; }

        public TB_BIN_Etapa()
        {
            this.Id_etapa = null;
            this.Ds_etapa = string.Empty;
            this.St_abertura = "N";
            this.St_concluir = "N";
            this.St_encerrar = "N";
        }
    }

    public class TB_BIN_Ticket
    {
        public decimal? Id_ticket
        { get; set; }
        public decimal? Id_setor
        { get; set; }
        public string Ds_setor
        { get; set; }
        public decimal? Id_categoria
        { get; set; }
        public string Ds_categoria
        { get; set; }
        public string LoginCliente
        { get; set; }
        public string LoginOperador
        { get; set; }
        private string st_prioridade;
        public string St_prioridade
        {
            get { return st_prioridade; }
            set
            {
                st_prioridade = value;
                if (value.Trim().ToUpper().Equals("0"))
                    prioridade = "BAIXA";
                else if (value.Trim().ToUpper().Equals("1"))
                    prioridade = "MEDIA";
                else if (value.Trim().ToUpper().Equals("2"))
                    prioridade = "ALTA";
            }
        }
        private string prioridade;
        public string Prioridade
        {
            get { return prioridade; }
            set { prioridade = value; }
        }
        public string Ds_assunto
        { get; set; }
        public DateTime? Dt_abertura
        { get; set; }
        public DateTime? Dt_concluido
        { get; set; }
        public DateTime? Dt_encerramento
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("L"))
                    status = "CONCLUIDO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CONCLUIDO"))
                    st_registro = "L";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }

        public List<TB_BIN_EvolucaoTicket> lEvolucao
        { get; set; }

        public TB_BIN_Ticket()
        {
            this.Id_ticket = null;
            this.Id_setor = null;
            this.Ds_setor = string.Empty;
            this.Id_categoria = null;
            this.Ds_categoria = string.Empty;
            this.LoginCliente = string.Empty;
            this.LoginOperador = string.Empty;
            this.st_prioridade = string.Empty;
            this.prioridade = string.Empty;
            this.Ds_assunto = string.Empty;
            this.Dt_abertura = null;
            this.Dt_concluido = null;
            this.Dt_encerramento = null;
            this.st_registro = "A";
            this.status = "ABERTO";

            this.lEvolucao = new List<TB_BIN_EvolucaoTicket>();
        }
    }

    public class TB_BIN_EvolucaoTicket
    {
        public decimal? Id_ticket
        { get; set; }
        public decimal? Id_evolucao
        { get; set; }
        public string LoginOperador
        { get; set; }
        public decimal? Id_etapa
        { get; set; }
        public string Ds_etapa
        { get; set; }
        public string Ds_evolucao
        { get; set; }
        public DateTime? Dt_evolucao
        { get; set; }

        public List<TB_BIN_AnexoEvolucao> lAnexo
        { get; set; }

        public TB_BIN_EvolucaoTicket()
        {
            this.Id_ticket = null;
            this.Id_evolucao = null;
            this.LoginOperador = string.Empty;
            this.Id_etapa = null;
            this.Ds_etapa = string.Empty;
            this.Ds_evolucao = string.Empty;
            this.Dt_evolucao = null;

            this.lAnexo = new List<TB_BIN_AnexoEvolucao>();
        }
    }

    public class TB_BIN_AnexoEvolucao
    {
        public decimal? Id_ticket
        { get; set; }
        public decimal? Id_evolucao
        { get; set; }
        public decimal? Id_anexo
        { get; set; }
        public string Ds_anexo
        { get; set; }
        public byte[] Img
        { get; set; }
        public string Tp_ext
        { get; set; }

        public TB_BIN_AnexoEvolucao()
        {
            this.Id_ticket = null;
            this.Id_evolucao = null;
            this.Id_anexo = null;
            this.Ds_anexo = string.Empty;
            this.Img = null;
        }
    }

    public class TChaveLic
    {
        public string Status { get; set; }
        public string Chave { get; set; }
        public double Qt_diasvalidade { get; set; }
        public string Dt_licenca { get; set; }
        public int Nr_seqlic { get; set; }

        public TChaveLic()
        {
            this.Status = string.Empty;
            this.Chave = string.Empty;
            this.Qt_diasvalidade = double.MinValue;
            this.Dt_licenca = string.Empty;
            this.Nr_seqlic = int.MinValue;
        }
    }
    #endregion

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_HelpDesk : System.Web.Services.WebService
    {
        private string Conexao = "user id=MASTER;data source='localhost';persist security info=false;initial catalog=BASE_RDC;password=LogMaster*2015;Connect Timeout=120";
        private string strConAliance = "user id=MASTER;data source='localhost';persist security info=false;initial catalog=ALIANCE;password=LogMaster*2015;Connect Timeout=120";

        [WebMethod]
        public bool ValidarLogin(string Login,
                                 string Senha)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select 1 from tb_bin_usercliente ");
            sql.AppendLine("where logincliente = '" + Login.Trim() + "'");
            sql.AppendLine("and senha = '" + Senha.Trim() + "'");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                object obj = comando.ExecuteScalar();
                return obj == null ? false : obj.ToString().Trim().Equals("1");
            }
            catch { return false; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_Setor> BuscarSetor()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select id_setor, ds_setor ");
            sql.AppendLine("from tb_bin_setor ");
            sql.AppendLine("where DS_SETOR = 'SUPORTE' ");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TB_BIN_Setor> retorno = new List<TB_BIN_Setor>();
                while (reader.Read())
                {
                    TB_BIN_Setor r = new TB_BIN_Setor();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_setor")))
                        r.Id_setor = reader.GetDecimal(reader.GetOrdinal("id_setor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_setor")))
                        r.Ds_setor = reader.GetString(reader.GetOrdinal("ds_setor"));

                    retorno.Add(r);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_Categoria> BuscarCategoria(string Id_setor)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select id_categoria, ds_categoria ");
            sql.AppendLine("from tb_bin_categoria a ");
            if(!string.IsNullOrEmpty(Id_setor))
            {
                sql.AppendLine("where exists(select 1 from tb_bin_setor_x_categoria x ");
                sql.AppendLine("where x.id_categoria = a.id_categoria ");
                sql.AppendLine("and x.id_setor = " + Id_setor + ")");
            }

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TB_BIN_Categoria> retorno = new List<TB_BIN_Categoria>();
                while (reader.Read())
                {
                    TB_BIN_Categoria r = new TB_BIN_Categoria();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_categoria")))
                        r.Id_categoria = reader.GetDecimal(reader.GetOrdinal("id_categoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_categoria")))
                        r.Ds_categoria = reader.GetString(reader.GetOrdinal("ds_categoria"));

                    retorno.Add(r);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_Etapa> BuscarEtapa(string Id_etapa,
                                              string Ds_etapa,
                                              string St_abertura,
                                              string St_concluir,
                                              string St_encerrar)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.id_etapa, a.ds_etapa, ");
            sql.AppendLine("a.st_abertura, a.st_concluir, a.st_encerrar, a.st_interno ");

            sql.AppendLine("from tb_bin_etapa a ");

            string cond = " where ";

            if (!string.IsNullOrEmpty(Id_etapa))
            {
                sql.AppendLine(cond + "a.id_etapa = " + Id_etapa);
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(Ds_etapa))
            {
                sql.AppendLine(cond + "a.ds_etapa like '%" + Ds_etapa.Trim() + "%'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(St_abertura))
            {
                sql.AppendLine(cond + "isnull(a.st_abertura, 'N') = '" + St_abertura.Trim() + "'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(St_concluir))
            {
                sql.AppendLine(cond + "isnull(a.st_concluir, 'N') = '" + St_concluir.Trim() +"'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(St_encerrar))
                sql.AppendLine(cond + "isnull(a.st_encerrar, 'N') = '" + St_encerrar.Trim() + "'");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TB_BIN_Etapa> retorno = new List<TB_BIN_Etapa>();
                while (reader.Read())
                {
                    TB_BIN_Etapa r = new TB_BIN_Etapa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        r.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        r.Ds_etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_abertura")))
                        r.St_abertura = reader.GetString(reader.GetOrdinal("st_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_concluir")))
                        r.St_concluir = reader.GetString(reader.GetOrdinal("st_concluir"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_encerrar")))
                        r.St_encerrar = reader.GetString(reader.GetOrdinal("st_encerrar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_interno")))
                        r.St_interno = reader.GetString(reader.GetOrdinal("st_interno"));

                    retorno.Add(r);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_Ticket> BuscarTicket(string Id_ticket,
                                                string Ds_assunto,
                                                string St_prioridade,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string LoginCliente,
                                                string St_registro)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.id_ticket, a.id_setor, b.ds_setor, ");
            sql.AppendLine("a.id_categoria, c.ds_categoria, a.logincliente, ");
            sql.AppendLine("a.loginoperador, a.st_prioridade, a.ds_assunto, ");
            sql.AppendLine("a.dt_abertura, a.dt_concluido, a.dt_encerramento, a.st_registro ");

            sql.AppendLine("from tb_bin_ticket a ");
            sql.AppendLine("inner join tb_bin_setor b ");
            sql.AppendLine("on a.id_setor = b.id_setor ");
            sql.AppendLine("inner join tb_bin_categoria c ");
            sql.AppendLine("on a.id_categoria = c.id_categoria ");

            string cond = " where ";

            if (!string.IsNullOrEmpty(Id_ticket))
            {
                sql.AppendLine(cond + "a.id_ticket = " + Id_ticket);
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(Ds_assunto))
            {
                sql.AppendLine(cond + "a.ds_assunto like '%" + Ds_assunto.Trim() + "%'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(St_prioridade))
            {
                sql.AppendLine(cond + "a.st_prioridade in(" + St_prioridade.Trim() + ")");
                cond = " and ";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                sql.AppendLine(cond + (Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_encerramento" : "a.dt_concluido") +
                                " >= '" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'");
                cond = " and ";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                sql.AppendLine(cond + (Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_encerramento" : "a.dt_concluido") +
                                " <= '" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(LoginCliente))
            {
                sql.AppendLine(cond + "a.logincliente = '" + LoginCliente.Trim() + "'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(St_registro))
                sql.AppendLine(cond + "a.st_registro in(" + St_registro.Trim() + ")");

            sql.AppendLine("order by a.id_ticket desc ");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader();
                List<TB_BIN_Ticket> retorno = new List<TB_BIN_Ticket>();
                while (reader.Read())
                {
                    TB_BIN_Ticket r = new TB_BIN_Ticket();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket")))
                        r.Id_ticket = reader.GetDecimal(reader.GetOrdinal("id_ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_setor")))
                        r.Id_setor = reader.GetDecimal(reader.GetOrdinal("id_setor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_setor")))
                        r.Ds_setor = reader.GetString(reader.GetOrdinal("ds_setor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_categoria")))
                        r.Id_categoria = reader.GetDecimal(reader.GetOrdinal("id_categoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_categoria")))
                        r.Ds_categoria = reader.GetString(reader.GetOrdinal("ds_categoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logincliente")))
                        r.LoginCliente = reader.GetString(reader.GetOrdinal("logincliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginoperador")))
                        r.LoginOperador = reader.GetString(reader.GetOrdinal("loginoperador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_prioridade")))
                        r.St_prioridade = reader.GetString(reader.GetOrdinal("st_prioridade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_assunto")))
                        r.Ds_assunto = reader.GetString(reader.GetOrdinal("ds_assunto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                        r.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_concluido")))
                        r.Dt_concluido = reader.GetDateTime(reader.GetOrdinal("dt_concluido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_encerramento")))
                        r.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("dt_encerramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        r.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    
                    retorno.Add(r);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_Etapa> BuscarEstapaEvoluir()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.id_etapa, a.ds_etapa, ");
            sql.AppendLine("a.st_abertura, a.st_concluir, a.st_encerrar ");

            sql.AppendLine("from tb_bin_etapa a ");

            sql.AppendLine("where isnull(a.st_abertura, 'N') = 'S'");
            sql.AppendLine("or isnull(a.st_concluir, 'N') = 'S'");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TB_BIN_Etapa> retorno = new List<TB_BIN_Etapa>();
                while (reader.Read())
                {
                    TB_BIN_Etapa r = new TB_BIN_Etapa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        r.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        r.Ds_etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_abertura")))
                        r.St_abertura = reader.GetString(reader.GetOrdinal("st_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_concluir")))
                        r.St_concluir = reader.GetString(reader.GetOrdinal("st_concluir"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_encerrar")))
                        r.St_encerrar = reader.GetString(reader.GetOrdinal("st_encerrar"));

                    retorno.Add(r);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_EvolucaoTicket> BuscarEvolucaoTicket(string Id_ticket)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.id_ticket, a.id_evolucao, a.loginoperador, ");
            sql.AppendLine("a.id_etapa, b.ds_etapa, a.ds_evolucao, a.dt_evolucao ");

            sql.AppendLine("from tb_bin_evolucaoticket a ");
            sql.AppendLine("inner join tb_bin_etapa b ");
            sql.AppendLine("on a.id_etapa = b.id_etapa ");

            sql.AppendLine("where a.id_ticket = " + Id_ticket);
            sql.AppendLine("and b.st_interno <> 'S'");

            sql.AppendLine("order by a.id_evolucao desc ");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader rev = comando.ExecuteReader();
                List<TB_BIN_EvolucaoTicket> retorno = new List<TB_BIN_EvolucaoTicket>();
                while (rev.Read())
                {
                    TB_BIN_EvolucaoTicket evolucao = new TB_BIN_EvolucaoTicket();
                    if (!rev.IsDBNull(rev.GetOrdinal("id_ticket")))
                        evolucao.Id_ticket = rev.GetDecimal(rev.GetOrdinal("id_ticket"));
                    if (!rev.IsDBNull(rev.GetOrdinal("id_evolucao")))
                        evolucao.Id_evolucao = rev.GetDecimal(rev.GetOrdinal("id_evolucao"));
                    if (!rev.IsDBNull(rev.GetOrdinal("loginoperador")))
                        evolucao.LoginOperador = rev.GetString(rev.GetOrdinal("loginoperador"));
                    if (!rev.IsDBNull(rev.GetOrdinal("id_etapa")))
                        evolucao.Id_etapa = rev.GetDecimal(rev.GetOrdinal("id_etapa"));
                    if (!rev.IsDBNull(rev.GetOrdinal("ds_etapa")))
                        evolucao.Ds_etapa = rev.GetString(rev.GetOrdinal("ds_etapa"));
                    if (!rev.IsDBNull(rev.GetOrdinal("ds_evolucao")))
                        evolucao.Ds_evolucao = rev.GetString(rev.GetOrdinal("ds_evolucao"));
                    if (!rev.IsDBNull(rev.GetOrdinal("dt_evolucao")))
                        evolucao.Dt_evolucao = rev.GetDateTime(rev.GetOrdinal("dt_evolucao"));

                    retorno.Add(evolucao);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public List<TB_BIN_AnexoEvolucao> BuscarAnexoEvolucao(string Id_ticket,
                                                              string Id_evolucao)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.id_ticket, a.id_evolucao, a.id_anexo, a.ds_anexo, a.imagem, a.tp_ext ");
            sql.AppendLine("from tb_bin_anexoevolucao a ");

            sql.AppendLine("where a.id_ticket = " + Id_ticket);
            sql.AppendLine("and a.id_evolucao = " + Id_evolucao);

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader rev = comando.ExecuteReader();
                List<TB_BIN_AnexoEvolucao> retorno = new List<TB_BIN_AnexoEvolucao>();
                while (rev.Read())
                {
                    TB_BIN_AnexoEvolucao anexo = new TB_BIN_AnexoEvolucao();
                    if (!rev.IsDBNull(rev.GetOrdinal("id_ticket")))
                        anexo.Id_ticket = rev.GetDecimal(rev.GetOrdinal("id_ticket"));
                    if (!rev.IsDBNull(rev.GetOrdinal("id_evolucao")))
                        anexo.Id_evolucao = rev.GetDecimal(rev.GetOrdinal("id_evolucao"));
                    if (!rev.IsDBNull(rev.GetOrdinal("id_anexo")))
                        anexo.Id_anexo = rev.GetDecimal(rev.GetOrdinal("id_anexo"));
                    if (!rev.IsDBNull(rev.GetOrdinal("ds_anexo")))
                        anexo.Ds_anexo = rev.GetString(rev.GetOrdinal("ds_anexo"));
                    if (!rev.IsDBNull(rev.GetOrdinal("imagem")))
                        anexo.Img = (byte[])rev.GetValue(rev.GetOrdinal("imagem"));
                    if (!rev.IsDBNull(rev.GetOrdinal("tp_ext")))
                        anexo.Tp_ext = rev.GetString(rev.GetOrdinal("tp_ext"));

                    retorno.Add(anexo);
                }
                return retorno;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public string LoginOperador(string LoginCliente,
                                     string Id_setor)
        {
            //System.Text.StringBuilder sql = new System.Text.StringBuilder();
            //sql.AppendLine("select d.loginoperador ");
            //sql.AppendLine("from tb_bin_usercliente a ");
            //sql.AppendLine("inner join tb_bin_cliente b ");
            //sql.AppendLine("on a.id_cliente = b.id_cliente ");
            //sql.AppendLine("inner join tb_bin_parceiro c ");
            //sql.AppendLine("on b.id_parceiro = c.id_parceiro ");
            //sql.AppendLine("inner join tb_bin_operador d ");
            //sql.AppendLine("on c.id_parceiro = d.id_parceiro ");
            //sql.AppendLine("inner join tb_bin_operador_x_setor e ");
            //sql.AppendLine("on d.loginoperador = e.loginoperador ");

            //sql.AppendLine("where a.logincliente = '" + LoginCliente.Trim() + "'");
            //sql.AppendLine("and e.id_setor = " + Id_setor);

            //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            //System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            //try
            //{
            //    //Abrir conexao
            //    con.Open();
            //    //Executar comando
            //    System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader();
            //    List<string> retorno = new List<string>();
            //    while (reader.Read())
            //    {
            //        if (!reader.IsDBNull(reader.GetOrdinal("loginoperador")))
            //            retorno.Add(reader.GetString(reader.GetOrdinal("loginoperador")));
            //    }
            //    if (retorno.Count.Equals(0))
            //        return string.Empty;
            //    else if (retorno.Count.Equals(1))
            //        return retorno[0];
            //    else
            //    {
            //        System.Random r = new Random();
            //        return retorno[r.Next(0, retorno.Count - 1)];
            //    }      
            //}
            //catch { return string.Empty; }
            //finally
            //{
            //    if (con.State == System.Data.ConnectionState.Open)
            //        con.Close();
            //}
            return "TECNOALIANCE";
        }

        [WebMethod]
        public void AbrirTicket(TB_BIN_Ticket val)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction t = null;
            try
            {
                con.Open();
                t = con.BeginTransaction();
                #region Ticket
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "IA_BIN_TICKET";
                //Derivar Parametros
                System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                comando.Parameters["@P_ID_TICKET"].Value = DBNull.Value;
                comando.Parameters["@P_ID_SETOR"].Value = val.Id_setor;
                comando.Parameters["@P_ID_CATEGORIA"].Value = val.Id_categoria;
                comando.Parameters["@P_LOGINCLIENTE"].Value = val.LoginCliente;
                comando.Parameters["@P_LOGINOPERADOR"].Value = val.LoginOperador;
                comando.Parameters["@P_ST_PRIORIDADE"].Value = val.St_prioridade;
                comando.Parameters["@P_DS_ASSUNTO"].Value = val.Ds_assunto;
                comando.Parameters["@P_DT_ABERTURA"].Value = val.Dt_abertura;
                comando.Parameters["@P_DT_CONCLUIDO"].Value = DBNull.Value;
                comando.Parameters["@P_DT_ENCERRAMENTO"].Value = DBNull.Value;
                comando.Parameters["@P_ST_REGISTRO"].Value = val.St_registro;
                //Gravar Ticket
                comando.ExecuteNonQuery();
                val.Id_ticket = Convert.ToDecimal(comando.Parameters["@P_ID_TICKET"].Value);
                #endregion

                #region Evolucao
                val.lEvolucao.ForEach(p =>
                    {
                        comando = new System.Data.SqlClient.SqlCommand();
                        comando.Connection = con;
                        comando.Transaction = t;
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandText = "IA_BIN_EVOLUCAOTICKET";
                        System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                        //Parametro id_evolucao
                        comando.Parameters["@P_ID_EVOLUCAO"].Value = DBNull.Value;
                        comando.Parameters["@P_ID_TICKET"].Value = val.Id_ticket;
                        comando.Parameters["@P_LOGINOPERADOR"].Value = DBNull.Value;
                        comando.Parameters["@P_ID_ETAPA"].Value = p.Id_etapa;
                        comando.Parameters["@P_DS_EVOLUCAO"].Value = p.Ds_evolucao;
                        comando.Parameters["@P_DT_EVOLUCAO"].Value = val.Dt_abertura;
                        comando.ExecuteNonQuery();
                        p.Id_evolucao = Convert.ToDecimal(comando.Parameters["@P_ID_EVOLUCAO"].Value);
                        //Anexos
                        p.lAnexo.ForEach(v =>
                            {
                                comando = new System.Data.SqlClient.SqlCommand();
                                comando.Connection = con;
                                comando.Transaction = t;
                                comando.CommandType = System.Data.CommandType.StoredProcedure;
                                comando.CommandText = "IA_BIN_ANEXOEVOLUCAO";
                                System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                                comando.Parameters["@P_ID_EVOLUCAO"].Value = p.Id_evolucao;
                                comando.Parameters["@P_ID_TICKET"].Value = val.Id_ticket;
                                comando.Parameters["@P_ID_ANEXO"].Value = DBNull.Value;
                                comando.Parameters["@P_DS_ANEXO"].Value = v.Ds_anexo;
                                comando.Parameters["@P_IMAGEM"].Value = v.Img;
                                comando.Parameters["@P_TP_EXT"].Value = v.Tp_ext;
                                comando.ExecuteNonQuery();
                            });
                    });
                #endregion
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw new Exception("Erro abrir ticket: " + val.LoginOperador + ex.Message.Trim()); 
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public void EvoluirTicket(TB_BIN_EvolucaoTicket val)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction t = null;
            try
            {
                //Abrir conexao
                con.Open();
                t = con.BeginTransaction();
                #region Evolucao
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "IA_BIN_EVOLUCAOTICKET";
                System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                comando.Parameters["@P_ID_EVOLUCAO"].Value = DBNull.Value;
                comando.Parameters["@P_ID_TICKET"].Value = val.Id_ticket;
                comando.Parameters["@P_LOGINOPERADOR"].Value = DBNull.Value;
                comando.Parameters["@P_ID_ETAPA"].Value = val.Id_etapa;
                comando.Parameters["@P_DS_EVOLUCAO"].Value = val.Ds_evolucao;
                comando.Parameters["@P_DT_EVOLUCAO"].Value = val.Dt_evolucao;
                //Executar comando
                comando.ExecuteNonQuery();
                val.Id_evolucao = Convert.ToDecimal(comando.Parameters["@P_ID_EVOLUCAO"].Value);
                #endregion

                #region Anexos
                val.lAnexo.ForEach(p =>
                    {
                        comando = new System.Data.SqlClient.SqlCommand();
                        comando.Connection = con;
                        comando.Transaction = t;
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandText = "IA_BIN_ANEXOEVOLUCAO";
                        System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@P_ID_EVOLUCAO"].Value = val.Id_evolucao;
                        comando.Parameters["@P_ID_TICKET"].Value = val.Id_ticket;
                        comando.Parameters["@P_ID_ANEXO"].Value = DBNull.Value;
                        comando.Parameters["@P_DS_ANEXO"].Value = p.Ds_anexo;
                        comando.Parameters["@P_IMAGEM"].Value = p.Img;
                        comando.Parameters["@P_TP_EXT"].Value = p.Tp_ext;
                        comando.ExecuteNonQuery();
                    });
                #endregion

                //Verificar se etapa e de CONCLUIR
                comando = new System.Data.SqlClient.SqlCommand();
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select 1 from tb_bin_etapa where id_etapa = " + val.Id_etapa.Value.ToString() +
                                      " and isnull(st_concluir, 'N') = 'S'";
                object obj = comando.ExecuteScalar();
                if (obj != null)
                {
                    comando = new System.Data.SqlClient.SqlCommand();
                    comando.Connection = con;
                    comando.Transaction = t;
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "update tb_bin_ticket set " +
                                          "dt_concluido = '" + val.Dt_evolucao.Value.ToString("yyyyMMdd HH:mm:ss") + "'," +
                                          "st_registro = 'L' " +
                                          "where id_ticket = " + val.Id_ticket.Value.ToString();
                    comando.ExecuteNonQuery();
                }
                //Verificar se etapa e de ABERTURA
                comando = new System.Data.SqlClient.SqlCommand();
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select 1 from tb_bin_etapa where id_etapa = " + val.Id_etapa.Value.ToString() +
                                      " and isnull(st_abertura, 'N') = 'S'";
                obj = comando.ExecuteScalar();
                if (obj != null)
                {
                    comando = new System.Data.SqlClient.SqlCommand();
                    comando.Connection = con;
                    comando.Transaction = t;
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "update tb_bin_ticket set " +
                                          "st_registro = 'A' " +
                                          "where id_ticket = " + val.Id_ticket.Value.ToString();
                    comando.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw new Exception("Erro gravar evolução: " + ex.Message.Trim()); 
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public TChaveLic CalcularSerial(string Cnpj_cliente, string Dt_servidor, int diasvalidade)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            TChaveLic retorno = new TChaveLic();

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            string msg = string.Empty;
            try
            {
                //Abrir conexao
                con.Open();
                //Buscar cadastro cliente
                sql.AppendLine("select id_cliente, isnull(qt_diasvalidadelic, 0) as qt_diasvalidadelic, dt_licenca, cnpj, st_registro ");
                sql.AppendLine("from tb_bin_cliente ");
                sql.AppendLine("where REPLACE(REPLACE(REPLACE(REPLACE(cnpj, ',',''), '.', ''), '/', ''), '-', '') in(" + Cnpj_cliente.Trim() + ")");
                comando.CommandText = sql.ToString();
                System.Data.DataTable tabela = new System.Data.DataTable();
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(comando);
                adapter.Fill(tabela);
                if (tabela.Rows.Count > 0)
                {
                    if (tabela.Rows[0]["st_registro"].ToString().Trim().ToUpper().Equals("A"))
                    {
                        System.Data.SqlClient.SqlConnection conAliance = new System.Data.SqlClient.SqlConnection(strConAliance);
                        System.Data.SqlClient.SqlCommand comAliance = new System.Data.SqlClient.SqlCommand();
                        //Buscar financeiro em aberto
                        try
                        {
                            conAliance.Open();
                            comAliance.Connection = conAliance;
                            comAliance.CommandText = "select 1 from vtb_fin_parcela a " +
                                                     "inner join vtb_fin_clifor b " +
                                                     "on a.cd_clifor = b.cd_clifor " +
                                                     "inner join tb_fin_duplicata c " +
                                                     "on a.cd_empresa = c.cd_empresa " +
                                                     "and a.nr_lancto = c.nr_lancto " +
                                                     "where isnull(c.st_registro, 'A') <> 'C' " +
                                                     "and isnull(a.st_registro, 'A') <> 'L' " +
                                                     "and convert(datetime, floor(convert(decimal(30,10), dateadd(day, 10, a.dt_vencto)))) < convert(datetime, floor(convert(decimal(30,10), getdate()))) " +
                                                     "and REPLACE(REPLACE(REPLACE(REPLACE(b.nr_cgc, ',',''), '.', ''), '/', ''), '-', '') = '" + tabela.Rows[0]["cnpj"].ToString().SoNumero() + "'";
                            object obj = comAliance.ExecuteScalar();
                            if (obj != null)
                                retorno.Status = "1";//Cliente possui financeiro vencido
                        }
                        catch { retorno.Status = "8"; }
                        finally
                        {
                            if (conAliance.State == System.Data.ConnectionState.Open)
                            {
                                conAliance.Close();
                                conAliance.Dispose();
                            }
                        }
                    }
                    else retorno.Status = "2";//Cliente Inativo
                }
                else retorno.Status = "3";//Cliente não encontrado
                //Calcular Chave acesso
                if (string.IsNullOrEmpty(retorno.Status))
                {
                    if (diasvalidade > 0)
                        retorno.Qt_diasvalidade = Convert.ToDouble(diasvalidade);
                    else
                    {
                        retorno.Qt_diasvalidade = double.Parse(tabela.Rows[0]["qt_diasvalidadelic"].ToString());
                        if (retorno.Qt_diasvalidade.Equals(0))
                            retorno.Qt_diasvalidade = 30;
                    }
                    if (string.IsNullOrEmpty(tabela.Rows[0]["dt_licenca"].ToString()))
                        retorno.Dt_licenca = Dt_servidor;
                    else
                    {

                        DateTime dt_lic = DateTime.Parse(tabela.Rows[0]["dt_licenca"].ToString());

                        if (dt_lic.AddDays(retorno.Qt_diasvalidade - 5).Date < DateTime.Now.Date)
                            retorno.Dt_licenca = DateTime.Parse(tabela.Rows[0]["dt_licenca"].ToString()).AddDays(retorno.Qt_diasvalidade).ToString("dd/MM/yyyy");
                        else retorno.Dt_licenca = DateTime.Parse(tabela.Rows[0]["dt_licenca"].ToString()).ToString("dd/MM/yyyy");
                    }
                    retorno.Nr_seqlic = new Random().Next(9999);
                    retorno.Chave = new Cryptography.Cryptography().GerarChaveAliance(tabela.Rows[0]["cnpj"].ToString().SoNumero(),
                                                                                      Convert.ToDouble(retorno.Nr_seqlic),
                                                                                      DateTime.Parse(retorno.Dt_licenca),
                                                                                      retorno.Qt_diasvalidade);
                    retorno.Status = "0";
                    comando.CommandText = "update tb_bin_cliente set dt_licenca = @dt_licenca, nr_seqlic = @p_nr_seqlic where id_cliente = @id_cliente";
                    comando.Parameters.Clear();
                    comando.Parameters.Add("@dt_licenca", DateTime.Parse(retorno.Dt_licenca));
                    comando.Parameters.Add("@p_nr_seqlic", retorno.Nr_seqlic);
                    comando.Parameters.Add("@id_cliente", tabela.Rows[0]["id_cliente"].ToString());
                    comando.ExecuteNonQuery();
                }
            }
            catch { retorno.Status = "9"; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return retorno;
        }

        [WebMethod]
        public CamadaDados.Financeiro.Bloqueto.blListaTitulo BuscarBoletos(string Cnpj_cliente)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("SELECT a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_cobranca, c.cd_clifor as cd_sacado, ");
            sql.AppendLine("a.cd_contager, d.ds_contager, d.cd_banco, e.ds_banco, d.nr_agencia, d.digitoagencia, isnull(a.st_registro, 'A') as st_registro, ");
            sql.AppendLine("d.nr_contacorrente, d.digitoconta, a.nossonumero, a.aceite_sn, a.especiedocumento, f.cd_portador, ");
            sql.AppendLine("a.dt_ocorrencia, a.dt_credito, a.dt_creditotaxa, f.ano, a.vl_multacalc, a.vl_jurocalc, a.qt_atualizatitulo, ");
            sql.AppendLine("f.pc_jurodia, f.tp_jurodia, f.pc_desconto, f.tp_desconto, f.nr_diasdesconto, f.pc_multa, f.tp_multa, f.nr_diasmulta, a.st_protestado, ");
            sql.AppendLine("a.dt_protesto, a.dt_baixa, c.nr_docto, f.postocedente, f.ds_instrucoes as instrucoes, ");
            sql.AppendLine("a.vl_despesacobranca, a.vl_abatimento, a.vl_desconto, a.vl_morajuros, f.tp_cobranca, ");
            sql.AppendLine("a.vl_iof, a.vl_outrasdespesas, a.vl_outroscreditos, a.ds_instrucoes, f.logo_banco, f.TP_LayoutBloqueto, ");
            sql.AppendLine("a.dt_emissaobloqueto, a.codigocedente, f.digitocedente, f.ds_localpagamento, f.tp_carteira, f.modalidade, ");
            sql.AppendLine("f.postocedente, b.dt_vencto, c.dt_emissao, ");
            sql.AppendLine("status_remessa = (select top 1 x.st_loteremessa ");
            sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
            sql.AppendLine("                    inner join tb_cob_loteremessa y ");
            sql.AppendLine("                    on x.id_lote = y.id_lote ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
            sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
            sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
            sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
            sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
            sql.AppendLine("                    order by y.dt_lote desc), ");
            sql.AppendLine("ds_motivo = (select top 1 x.ds_motivo ");
            sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
            sql.AppendLine("                    inner join tb_cob_loteremessa y ");
            sql.AppendLine("                    on x.id_lote = y.id_lote ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
            sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
            sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
            sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
            sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
            sql.AppendLine("                    order by y.dt_lote desc), ");
            //Dados correspondente
            sql.AppendLine("f.cd_bancocorrespondente, bd.ds_banco as ds_bancocorrespondente, f.st_protestoauto, f.nr_diasprotesto, ");
            sql.AppendLine("f.conveniocobranca, f.nr_agenciacorrespondente, f.nr_contacorrespondente, f.carteiracorrespondente, ");
            //Valor do documento
            sql.AppendLine("vl_documento = DBO.F_CALC_VL_DUP_MOEDAPADRAO(a.CD_Empresa, a.NR_Lancto, a.CD_Parcela, 'S', getDate(), ");
            sql.AppendLine("((isnull(b.vl_parcela_padrao, 0) - (select isNull(sum(isNull(x.vl_liquidacao_padrao, 0)),0) ");
            sql.AppendLine("                                   from tb_fin_liquidacao x ");
            sql.AppendLine("                                   where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("                                   and x.nr_lancto = b.nr_lancto ");
            sql.AppendLine("                                   and x.cd_parcela = b.cd_parcela ");
            sql.AppendLine("                                   and x.st_registro <> 'C' )))), ");
            //Dados do sacado
            sql.AppendLine("sacado.tp_pessoa as tp_pessoa_sacado, sacado.nm_clifor as nm_clifor_sacado, ");
            sql.AppendLine("case when sacado.tp_pessoa = 'J' then sacado.nr_cgc else sacado.nr_cpf end as nr_cgc_cpf_sacado, ");
            sql.AppendLine("endsacado.ds_endereco as ds_endsacado, endsacado.numero as numero_sacado, ");
            sql.AppendLine("endsacado.ds_complemento as ds_complemento_sacado, endsacado.bairro as bairro_sacado, ");
            sql.AppendLine("endsacado.ds_cidade as ds_cidade_sacado, endsacado.uf as uf_sacado, endsacado.cep as cep_sacado, ");
            //Dados do Avalista
            sql.AppendLine("avalista.tp_pessoa as tp_pessoa_avalista, avalista.nm_clifor as nm_clifor_avalista, ");
            sql.AppendLine("case when avalista.tp_pessoa = 'J' then avalista.nr_cgc else avalista.nr_cpf end as nr_cgc_cpf_avalista, ");
            sql.AppendLine("endavalista.ds_endereco as ds_endavalista, endavalista.numero as numero_avalista, ");
            sql.AppendLine("endavalista.ds_complemento as ds_complemento_avalista, endavalista.bairro as bairro_avalista, ");
            sql.AppendLine("endavalista.ds_cidade as ds_cidade_avalista, endavalista.uf as uf_avalista, endavalista.cep as cep_avalista, ");
            //Dados do Cedente
            sql.AppendLine("cedente.tp_pessoa as tp_pessoa_cedente, cedente.nm_clifor as nm_clifor_cedente, ");
            sql.AppendLine("case when cedente.tp_pessoa = 'J' then cedente.nr_cgc else cedente.nr_cpf end as nr_cgc_cpf_cedente, ");
            sql.AppendLine("endcedente.ds_endereco as ds_endereco_cedente, endcedente.numero as numero_cedente, ");
            sql.AppendLine("endcedente.ds_complemento as ds_complemento_cedente, endcedente.bairro as bairro_cedente, ");
            sql.AppendLine("endcedente.ds_cidade as ds_cidade_cedente, endcedente.uf as uf_cedente, endcedente.cep as cep_cedente ");

            sql.AppendLine("from tb_cob_titulo a  ");
            //Parcela
            sql.AppendLine("inner join tb_fin_parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = b.cd_parcela ");
            //Duplicata
            sql.AppendLine("inner join tb_fin_duplicata c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
            //Dados Conta Gerencial
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on a.cd_contager = d.cd_contager ");
            //Dados Banco
            sql.AppendLine("inner join tb_fin_banco e ");
            sql.AppendLine("on d.cd_banco = e.cd_banco ");
            //Configuração Boleto
            sql.AppendLine("inner join tb_cob_cfgbanco f ");
            sql.AppendLine("on e.cd_banco = f.cd_banco ");
            sql.AppendLine("and a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("and a.codigocedente = f.codigocedente ");
            sql.AppendLine("and a.tp_cobranca = f.tp_cobranca ");
            //Cliente Sacado
            sql.AppendLine("inner join vtb_fin_clifor sacado ");
            sql.AppendLine("on c.cd_clifor = sacado.cd_clifor ");
            //Endereco Sacado
            sql.AppendLine("inner join vtb_fin_endereco endsacado ");
            sql.AppendLine("on c.cd_clifor = endsacado.cd_clifor ");
            sql.AppendLine("and c.cd_endereco = endsacado.cd_endereco ");
            //Empresa Cedente
            sql.AppendLine("inner join tb_div_empresa empcedente ");
            sql.AppendLine("on f.cd_empresa = empcedente.cd_empresa ");
            //Cliente Cedente
            sql.AppendLine("inner join vtb_fin_clifor cedente ");
            sql.AppendLine("on empcedente.cd_clifor = cedente.cd_clifor ");
            //Enderco Cedente
            sql.AppendLine("inner join vtb_fin_endereco endcedente ");
            sql.AppendLine("on empcedente.cd_clifor = endcedente.cd_clifor ");
            sql.AppendLine("and empcedente.cd_endereco = endcedente.cd_endereco ");
            //Banco Correspondente
            sql.AppendLine("left outer join tb_fin_banco bd ");
            sql.AppendLine("on f.cd_bancocorrespondente = bd.cd_banco ");
            //Cliente Avalista
            sql.AppendLine("left outer join vtb_fin_clifor avalista ");
            sql.AppendLine("on c.cd_avalista = avalista.cd_clifor ");
            //Endereco Avalista
            sql.AppendLine("left outer join vtb_fin_endereco endavalista ");
            sql.AppendLine("on c.cd_avalista = endavalista.cd_clifor ");
            sql.AppendLine("and c.cd_endavalista = endavalista.cd_endereco ");

            sql.AppendLine("where isNull(a.st_registro, 'A') = 'A' ");
            sql.AppendLine("and REPLACE(REPLACE(REPLACE(REPLACE(sacado.nr_cgc, ',',''), '.', ''), '/', ''), '-', '') in(" + Cnpj_cliente + ")");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strConAliance);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lista = new CamadaDados.Financeiro.Bloqueto.blListaTitulo();
                CamadaDados.Financeiro.Bloqueto.blPessoa sacado = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endSacado = null;
                CamadaDados.Financeiro.Bloqueto.blPessoa avalista = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endAvalista = null;
                CamadaDados.Financeiro.Bloqueto.blCedente cedente = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endCedente = null;
                CamadaDados.Financeiro.Bloqueto.blContaBancaria dbCedente = null;
                CamadaDados.Financeiro.Bloqueto.blBanco banco = null;
                while (reader.Read())
                {
                    CamadaDados.Financeiro.Bloqueto.blTitulo reg = new CamadaDados.Financeiro.Bloqueto.blTitulo();
                    //Dados do titulo
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Sacado")))
                        reg.Cd_sacado = reader.GetString(reader.GetOrdinal("CD_Sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NossoNumero"))))
                        reg.Nosso_numero = reader.GetString(reader.GetOrdinal("NossoNumero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto")))
                        reg.NumeroDocumento = reader.GetString(reader.GetOrdinal("NR_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Aceite_SN"))))
                        reg.Aceite_documento = reader.GetString(reader.GetOrdinal("Aceite_SN")).Trim().ToUpper().Equals("S") ? CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adSim : CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adNao;
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetString(reader.GetOrdinal("ano"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("EspecieDocumento"))))
                        reg.Especie_documento = CamadaDados.Financeiro.Bloqueto.blTitulo.RetornarEspecieDocumento(Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("EspecieDocumento"))));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Vencto")))
                        reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Ocorrencia"))))
                        reg.Dt_ocorrencia = reader.GetDateTime(reader.GetOrdinal("DT_Ocorrencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Credito"))))
                        reg.Dt_credito = reader.GetDateTime(reader.GetOrdinal("DT_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_CreditoTaxa")))
                        reg.Dt_creditotaxa = reader.GetDateTime(reader.GetOrdinal("DT_CreditoTaxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Protesto"))))
                        reg.Dt_protesto = reader.GetDateTime(reader.GetOrdinal("DT_Protesto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Baixa"))))
                        reg.Dt_baixa = reader.GetDateTime(reader.GetOrdinal("DT_Baixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_DespesaCobranca"))))
                        reg.Vl_despesa_cobranca = reader.GetDecimal(reader.GetOrdinal("Vl_DespesaCobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Abatimento"))))
                        reg.Vl_abatimento = reader.GetDecimal(reader.GetOrdinal("Vl_Abatimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_MoraJuros"))))
                        reg.Vl_morajuros = reader.GetDecimal(reader.GetOrdinal("Vl_MoraJuros"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IOF"))))
                        reg.Vl_iof = reader.GetDecimal(reader.GetOrdinal("Vl_IOF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDespesas"))))
                        reg.Vl_outras_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDespesas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrosCreditos"))))
                        reg.vl_outros_creditos = reader.GetDecimal(reader.GetOrdinal("Vl_OutrosCreditos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_documento")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("vl_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_multacalc")))
                        reg.Vl_multacalc = reader.GetDecimal(reader.GetOrdinal("vl_multacalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_jurocalc")))
                        reg.Vl_jurocalc = reader.GetDecimal(reader.GetOrdinal("vl_jurocalc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Instrucoes"))))
                        reg.Instrucoes = reader.GetString(reader.GetOrdinal("DS_Instrucoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("instrucoes")))
                        reg.DS_Instrucoes = reader.GetString(reader.GetOrdinal("instrucoes"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_EmissaoBloqueto"))))
                        reg.Dt_emissaobloqueto = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoBloqueto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Carteira"))))
                        reg.Carteira = reader.GetString(reader.GetOrdinal("TP_Carteira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("modalidade")))
                        reg.Modalidade = reader.GetString(reader.GetOrdinal("modalidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_LocalPagamento"))))
                        reg.Local_pagamento = reader.GetString(reader.GetOrdinal("DS_LocalPagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logo_banco")))
                        reg.Logo_banco = (byte[])reader.GetValue(reader.GetOrdinal("Logo_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutBloqueto")))
                        reg.Tp_layoutbloqueto = reader.GetString(reader.GetOrdinal("TP_LayoutBloqueto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cobranca")))
                        reg.Tp_cobranca = reader.GetString(reader.GetOrdinal("tp_cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_jurodia")))
                        reg.Pc_jurodia = reader.GetDecimal(reader.GetOrdinal("pc_jurodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_jurodia")))
                        reg.Tp_jurodia = reader.GetString(reader.GetOrdinal("tp_jurodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_desconto")))
                        reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("pc_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasdesconto")))
                        reg.Nr_diasdesconto = reader.GetDecimal(reader.GetOrdinal("nr_diasdesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_multa")))
                        reg.Pc_multa = reader.GetDecimal(reader.GetOrdinal("pc_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_multa")))
                        reg.Tp_multa = reader.GetString(reader.GetOrdinal("tp_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasmulta")))
                        reg.Nr_diasmulta = reader.GetDecimal(reader.GetOrdinal("nr_diasmulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_bancocorrespondente")))
                        reg.Cd_bancocorrespondente = reader.GetString(reader.GetOrdinal("cd_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bancocorrespondente")))
                        reg.Ds_bancocorrespondente = reader.GetString(reader.GetOrdinal("ds_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ConvenioCobranca")))
                        reg.Conveniocobranca = reader.GetString(reader.GetOrdinal("conveniocobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_agenciacorrespondente")))
                        reg.Nr_agenciacorrespondente = reader.GetString(reader.GetOrdinal("nr_agenciacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contacorrespondente")))
                        reg.Nr_contacorrespondente = reader.GetString(reader.GetOrdinal("nr_contacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("carteiracorrespondente")))
                        reg.Carteiracorrespondente = reader.GetString(reader.GetOrdinal("carteiracorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_banco")))
                        reg.Nome_banco = reader.GetString(reader.GetOrdinal("ds_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_protestoauto")))
                        reg.St_protestarauto = reader.GetString(reader.GetOrdinal("st_protestoauto")).ToString().Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasprotesto")))
                        reg.Nr_diasprotestar = reader.GetDecimal(reader.GetOrdinal("nr_diasprotesto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status_remessa")))
                        reg.Status_remessa = reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("A") ? "ACEITO" :
                            reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("R") ? "REJEITADO" : string.Empty;
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_protestado")))
                        reg.St_protestado = reader.GetString(reader.GetOrdinal("st_protestado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_atualizatitulo")))
                        reg.Qt_atualizatitulo = reader.GetDecimal(reader.GetOrdinal("qt_atualizatitulo"));
                    //Dados do sacado
                    sacado = new CamadaDados.Financeiro.Bloqueto.blPessoa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_sacado"))))
                        sacado.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica :
                            CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_sacado"))))
                        sacado.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_sacado"))))
                        sacado.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_sacado"));
                    //Endereco do Sacado
                    endSacado = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endsacado")))
                        endSacado.Rua = reader.GetString(reader.GetOrdinal("ds_endsacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero_sacado"))))
                        endSacado.Numero = reader.GetString(reader.GetOrdinal("numero_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_sacado"))))
                        endSacado.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro_sacado"))))
                        endSacado.Bairro = reader.GetString(reader.GetOrdinal("bairro_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_sacado"))))
                        endSacado.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("uf_sacado"))))
                        endSacado.Estado = reader.GetString(reader.GetOrdinal("uf_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cep_sacado"))))
                        endSacado.CEP = reader.GetString(reader.GetOrdinal("cep_sacado"));
                    sacado.Endereco = endSacado;
                    reg.Sacado = sacado;
                    //Dados Avalista
                    avalista = new CamadaDados.Financeiro.Bloqueto.blPessoa();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa_avalista")))
                        avalista.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica : CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_avalista")))
                        avalista.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_avalista")))
                        avalista.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_avalista"));
                    reg.Avalista = avalista;
                    //Endereco Avalista
                    endAvalista = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endavalista")))
                        endAvalista.Rua = reader.GetString(reader.GetOrdinal("ds_endavalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero_avalista")))
                        endAvalista.Numero = reader.GetString(reader.GetOrdinal("numero_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento_avalista")))
                        endAvalista.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro_avalista")))
                        endAvalista.Bairro = reader.GetString(reader.GetOrdinal("bairro_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_avalista")))
                        endAvalista.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_avalista")))
                        endAvalista.Estado = reader.GetString(reader.GetOrdinal("uf_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep_avalista")))
                        endAvalista.CEP = reader.GetString(reader.GetOrdinal("cep_avalista"));
                    reg.EndAvalista = endAvalista;
                    //Dados do Cedente
                    cedente = new CamadaDados.Financeiro.Bloqueto.blCedente();
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_cedente"))))
                        cedente.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica : CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_cedente"))))
                        cedente.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_cedente"))))
                        cedente.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CodigoCedente")))
                        cedente.CodigoCedente = reader.GetString(reader.GetOrdinal("CodigoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoCedente")))
                        cedente.DigitoCodigoCedente = reader.GetString(reader.GetOrdinal("DigitoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("postocedente")))
                        cedente.Postocedente = reader.GetString(reader.GetOrdinal("postocedente"));
                    //Endereco do Cedente
                    endCedente = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_endereco_cedente"))))
                        endCedente.Rua = reader.GetString(reader.GetOrdinal("ds_endereco_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero_cedente"))))
                        endCedente.Numero = reader.GetString(reader.GetOrdinal("numero_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_cedente"))))
                        endCedente.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro_cedente"))))
                        endCedente.Bairro = reader.GetString(reader.GetOrdinal("bairro_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_cedente"))))
                        endCedente.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_cedente")))
                        endCedente.Estado = reader.GetString(reader.GetOrdinal("uf_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep_cedente")))
                        endCedente.CEP = reader.GetString(reader.GetOrdinal("cep_cedente"));
                    cedente.Endereco = endCedente;
                    //Dados Bancarios Cedente
                    dbCedente = new CamadaDados.Financeiro.Bloqueto.blContaBancaria();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Agencia")))
                        dbCedente.CodigoAgencia = reader.GetString(reader.GetOrdinal("NR_Agencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoAgencia")))
                        dbCedente.DigitoAgencia = reader.GetString(reader.GetOrdinal("DigitoAgencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ContaCorrente")))
                        dbCedente.NumeroConta = reader.GetString(reader.GetOrdinal("NR_ContaCorrente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoConta")))
                        dbCedente.DigitoConta = reader.GetString(reader.GetOrdinal("DigitoConta"));
                    //Dados do Banco
                    banco = new CamadaDados.Financeiro.Bloqueto.blBanco();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        banco.Codigo = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    dbCedente.Banco = banco;
                    cedente.ContaBancaria = dbCedente;
                    reg.Cedente = cedente;

                    lista.Add(reg);
                }
                return lista;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        [WebMethod]
        public CamadaDados.Financeiro.Bloqueto.blTitulo AtualizarBoleto(string Cd_empresa,
                                                                        string Nr_lancto,
                                                                        string Cd_parcela,
                                                                        string Id_cobranca)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("SELECT a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_cobranca, c.cd_clifor as cd_sacado, ");
            sql.AppendLine("a.cd_contager, d.ds_contager, d.cd_banco, e.ds_banco, d.nr_agencia, d.digitoagencia, isnull(a.st_registro, 'A') as st_registro, ");
            sql.AppendLine("d.nr_contacorrente, d.digitoconta, a.nossonumero, a.aceite_sn, a.especiedocumento, f.cd_portador, ");
            sql.AppendLine("a.dt_ocorrencia, a.dt_credito, a.dt_creditotaxa, f.ano, a.vl_multacalc, a.vl_jurocalc, a.qt_atualizatitulo, ");
            sql.AppendLine("f.pc_jurodia, f.tp_jurodia, f.pc_desconto, f.tp_desconto, f.nr_diasdesconto, f.pc_multa, f.tp_multa, f.nr_diasmulta, a.st_protestado, ");
            sql.AppendLine("a.dt_protesto, a.dt_baixa, c.nr_docto, f.postocedente, f.ds_instrucoes as instrucoes, ");
            sql.AppendLine("a.vl_despesacobranca, a.vl_abatimento, a.vl_desconto, a.vl_morajuros, f.tp_cobranca, ");
            sql.AppendLine("a.vl_iof, a.vl_outrasdespesas, a.vl_outroscreditos, a.ds_instrucoes, f.logo_banco, f.TP_LayoutBloqueto, ");
            sql.AppendLine("a.dt_emissaobloqueto, a.codigocedente, f.digitocedente, f.ds_localpagamento, f.tp_carteira, f.modalidade, ");
            sql.AppendLine("f.postocedente, b.dt_vencto, c.dt_emissao, ");
            sql.AppendLine("status_remessa = (select top 1 x.st_loteremessa ");
            sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
            sql.AppendLine("                    inner join tb_cob_loteremessa y ");
            sql.AppendLine("                    on x.id_lote = y.id_lote ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
            sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
            sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
            sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
            sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
            sql.AppendLine("                    order by y.dt_lote desc), ");
            sql.AppendLine("ds_motivo = (select top 1 x.ds_motivo ");
            sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
            sql.AppendLine("                    inner join tb_cob_loteremessa y ");
            sql.AppendLine("                    on x.id_lote = y.id_lote ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
            sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
            sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
            sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
            sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
            sql.AppendLine("                    order by y.dt_lote desc), ");
            //Dados correspondente
            sql.AppendLine("f.cd_bancocorrespondente, bd.ds_banco as ds_bancocorrespondente, f.st_protestoauto, f.nr_diasprotesto, ");
            sql.AppendLine("f.conveniocobranca, f.nr_agenciacorrespondente, f.nr_contacorrespondente, f.carteiracorrespondente, ");
            //Valor do documento
            sql.AppendLine("vl_documento = DBO.F_CALC_VL_DUP_MOEDAPADRAO(a.CD_Empresa, a.NR_Lancto, a.CD_Parcela, 'S', getDate(), ");
            sql.AppendLine("((isnull(b.vl_parcela_padrao, 0) - (select isNull(sum(isNull(x.vl_liquidacao_padrao, 0)),0) ");
            sql.AppendLine("                                   from tb_fin_liquidacao x ");
            sql.AppendLine("                                   where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("                                   and x.nr_lancto = b.nr_lancto ");
            sql.AppendLine("                                   and x.cd_parcela = b.cd_parcela ");
            sql.AppendLine("                                   and x.st_registro <> 'C' )))), ");
            //Dados do sacado
            sql.AppendLine("sacado.tp_pessoa as tp_pessoa_sacado, sacado.nm_clifor as nm_clifor_sacado, ");
            sql.AppendLine("case when sacado.tp_pessoa = 'J' then sacado.nr_cgc else sacado.nr_cpf end as nr_cgc_cpf_sacado, ");
            sql.AppendLine("endsacado.ds_endereco as ds_endsacado, endsacado.numero as numero_sacado, ");
            sql.AppendLine("endsacado.ds_complemento as ds_complemento_sacado, endsacado.bairro as bairro_sacado, ");
            sql.AppendLine("endsacado.ds_cidade as ds_cidade_sacado, endsacado.uf as uf_sacado, endsacado.cep as cep_sacado, ");
            //Dados do Avalista
            sql.AppendLine("avalista.tp_pessoa as tp_pessoa_avalista, avalista.nm_clifor as nm_clifor_avalista, ");
            sql.AppendLine("case when avalista.tp_pessoa = 'J' then avalista.nr_cgc else avalista.nr_cpf end as nr_cgc_cpf_avalista, ");
            sql.AppendLine("endavalista.ds_endereco as ds_endavalista, endavalista.numero as numero_avalista, ");
            sql.AppendLine("endavalista.ds_complemento as ds_complemento_avalista, endavalista.bairro as bairro_avalista, ");
            sql.AppendLine("endavalista.ds_cidade as ds_cidade_avalista, endavalista.uf as uf_avalista, endavalista.cep as cep_avalista, ");
            //Dados do Cedente
            sql.AppendLine("cedente.tp_pessoa as tp_pessoa_cedente, cedente.nm_clifor as nm_clifor_cedente, ");
            sql.AppendLine("case when cedente.tp_pessoa = 'J' then cedente.nr_cgc else cedente.nr_cpf end as nr_cgc_cpf_cedente, ");
            sql.AppendLine("endcedente.ds_endereco as ds_endereco_cedente, endcedente.numero as numero_cedente, ");
            sql.AppendLine("endcedente.ds_complemento as ds_complemento_cedente, endcedente.bairro as bairro_cedente, ");
            sql.AppendLine("endcedente.ds_cidade as ds_cidade_cedente, endcedente.uf as uf_cedente, endcedente.cep as cep_cedente ");

            sql.AppendLine("from tb_cob_titulo a  ");
            //Parcela
            sql.AppendLine("inner join tb_fin_parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = b.cd_parcela ");
            //Duplicata
            sql.AppendLine("inner join tb_fin_duplicata c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
            //Dados Conta Gerencial
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on a.cd_contager = d.cd_contager ");
            //Dados Banco
            sql.AppendLine("inner join tb_fin_banco e ");
            sql.AppendLine("on d.cd_banco = e.cd_banco ");
            //Configuração Boleto
            sql.AppendLine("inner join tb_cob_cfgbanco f ");
            sql.AppendLine("on e.cd_banco = f.cd_banco ");
            sql.AppendLine("and a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("and a.codigocedente = f.codigocedente ");
            sql.AppendLine("and a.tp_cobranca = f.tp_cobranca ");
            //Cliente Sacado
            sql.AppendLine("inner join vtb_fin_clifor sacado ");
            sql.AppendLine("on c.cd_clifor = sacado.cd_clifor ");
            //Endereco Sacado
            sql.AppendLine("inner join vtb_fin_endereco endsacado ");
            sql.AppendLine("on c.cd_clifor = endsacado.cd_clifor ");
            sql.AppendLine("and c.cd_endereco = endsacado.cd_endereco ");
            //Empresa Cedente
            sql.AppendLine("inner join tb_div_empresa empcedente ");
            sql.AppendLine("on f.cd_empresa = empcedente.cd_empresa ");
            //Cliente Cedente
            sql.AppendLine("inner join vtb_fin_clifor cedente ");
            sql.AppendLine("on empcedente.cd_clifor = cedente.cd_clifor ");
            //Enderco Cedente
            sql.AppendLine("inner join vtb_fin_endereco endcedente ");
            sql.AppendLine("on empcedente.cd_clifor = endcedente.cd_clifor ");
            sql.AppendLine("and empcedente.cd_endereco = endcedente.cd_endereco ");
            //Banco Correspondente
            sql.AppendLine("left outer join tb_fin_banco bd ");
            sql.AppendLine("on f.cd_bancocorrespondente = bd.cd_banco ");
            //Cliente Avalista
            sql.AppendLine("left outer join vtb_fin_clifor avalista ");
            sql.AppendLine("on c.cd_avalista = avalista.cd_clifor ");
            //Endereco Avalista
            sql.AppendLine("left outer join vtb_fin_endereco endavalista ");
            sql.AppendLine("on c.cd_avalista = endavalista.cd_clifor ");
            sql.AppendLine("and c.cd_endavalista = endavalista.cd_endereco ");

            sql.AppendLine("where isNull(a.st_registro, 'A') = 'A' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.nr_lancto = " + Nr_lancto);
            sql.AppendLine("and a.cd_parcela = " + Cd_parcela);
            sql.AppendLine("and a.id_cobranca = " + Id_cobranca);

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strConAliance);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader();
                CamadaDados.Financeiro.Bloqueto.blPessoa sacado = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endSacado = null;
                CamadaDados.Financeiro.Bloqueto.blPessoa avalista = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endAvalista = null;
                CamadaDados.Financeiro.Bloqueto.blCedente cedente = null;
                CamadaDados.Financeiro.Bloqueto.blEndereco endCedente = null;
                CamadaDados.Financeiro.Bloqueto.blContaBancaria dbCedente = null;
                CamadaDados.Financeiro.Bloqueto.blBanco banco = null;
                if (reader.HasRows)
                    if (reader.Read())
                    {
                        CamadaDados.Financeiro.Bloqueto.blTitulo reg = new CamadaDados.Financeiro.Bloqueto.blTitulo();
                        //Dados do titulo
                        if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                            reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Cd_Sacado")))
                            reg.Cd_sacado = reader.GetString(reader.GetOrdinal("CD_Sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                            reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                            reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                            reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                            reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                            reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                            reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("NossoNumero"))))
                            reg.Nosso_numero = reader.GetString(reader.GetOrdinal("NossoNumero"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto")))
                            reg.NumeroDocumento = reader.GetString(reader.GetOrdinal("NR_Docto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Aceite_SN"))))
                            reg.Aceite_documento = reader.GetString(reader.GetOrdinal("Aceite_SN")).Trim().ToUpper().Equals("S") ? CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adSim : CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adNao;
                        if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                            reg.Ano = reader.GetString(reader.GetOrdinal("ano"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("EspecieDocumento"))))
                            reg.Especie_documento = CamadaDados.Financeiro.Bloqueto.blTitulo.RetornarEspecieDocumento(Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("EspecieDocumento"))));
                        if (!reader.IsDBNull(reader.GetOrdinal("DT_Vencto")))
                            reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Ocorrencia"))))
                            reg.Dt_ocorrencia = reader.GetDateTime(reader.GetOrdinal("DT_Ocorrencia"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Credito"))))
                            reg.Dt_credito = reader.GetDateTime(reader.GetOrdinal("DT_Credito"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DT_CreditoTaxa")))
                            reg.Dt_creditotaxa = reader.GetDateTime(reader.GetOrdinal("DT_CreditoTaxa"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Protesto"))))
                            reg.Dt_protesto = reader.GetDateTime(reader.GetOrdinal("DT_Protesto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Baixa"))))
                            reg.Dt_baixa = reader.GetDateTime(reader.GetOrdinal("DT_Baixa"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_DespesaCobranca"))))
                            reg.Vl_despesa_cobranca = reader.GetDecimal(reader.GetOrdinal("Vl_DespesaCobranca"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Abatimento"))))
                            reg.Vl_abatimento = reader.GetDecimal(reader.GetOrdinal("Vl_Abatimento"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                            reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_MoraJuros"))))
                            reg.Vl_morajuros = reader.GetDecimal(reader.GetOrdinal("Vl_MoraJuros"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IOF"))))
                            reg.Vl_iof = reader.GetDecimal(reader.GetOrdinal("Vl_IOF"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDespesas"))))
                            reg.Vl_outras_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDespesas"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrosCreditos"))))
                            reg.vl_outros_creditos = reader.GetDecimal(reader.GetOrdinal("Vl_OutrosCreditos"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_documento")))
                            reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("vl_documento"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_multacalc")))
                            reg.Vl_multacalc = reader.GetDecimal(reader.GetOrdinal("vl_multacalc"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_jurocalc")))
                            reg.Vl_jurocalc = reader.GetDecimal(reader.GetOrdinal("vl_jurocalc"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DS_Instrucoes"))))
                            reg.Instrucoes = reader.GetString(reader.GetOrdinal("DS_Instrucoes"));
                        if (!reader.IsDBNull(reader.GetOrdinal("instrucoes")))
                            reg.DS_Instrucoes = reader.GetString(reader.GetOrdinal("instrucoes"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_EmissaoBloqueto"))))
                            reg.Dt_emissaobloqueto = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoBloqueto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("TP_Carteira"))))
                            reg.Carteira = reader.GetString(reader.GetOrdinal("TP_Carteira"));
                        if (!reader.IsDBNull(reader.GetOrdinal("modalidade")))
                            reg.Modalidade = reader.GetString(reader.GetOrdinal("modalidade"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DS_LocalPagamento"))))
                            reg.Local_pagamento = reader.GetString(reader.GetOrdinal("DS_LocalPagamento"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Logo_banco")))
                            reg.Logo_banco = (byte[])reader.GetValue(reader.GetOrdinal("Logo_banco"));
                        if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutBloqueto")))
                            reg.Tp_layoutbloqueto = reader.GetString(reader.GetOrdinal("TP_LayoutBloqueto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_cobranca")))
                            reg.Tp_cobranca = reader.GetString(reader.GetOrdinal("tp_cobranca"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                            reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                        if (!reader.IsDBNull(reader.GetOrdinal("pc_jurodia")))
                            reg.Pc_jurodia = reader.GetDecimal(reader.GetOrdinal("pc_jurodia"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_jurodia")))
                            reg.Tp_jurodia = reader.GetString(reader.GetOrdinal("tp_jurodia"));
                        if (!reader.IsDBNull(reader.GetOrdinal("pc_desconto")))
                            reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("pc_desconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                            reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_diasdesconto")))
                            reg.Nr_diasdesconto = reader.GetDecimal(reader.GetOrdinal("nr_diasdesconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("pc_multa")))
                            reg.Pc_multa = reader.GetDecimal(reader.GetOrdinal("pc_multa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_multa")))
                            reg.Tp_multa = reader.GetString(reader.GetOrdinal("tp_multa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_diasmulta")))
                            reg.Nr_diasmulta = reader.GetDecimal(reader.GetOrdinal("nr_diasmulta"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_bancocorrespondente")))
                            reg.Cd_bancocorrespondente = reader.GetString(reader.GetOrdinal("cd_bancocorrespondente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_bancocorrespondente")))
                            reg.Ds_bancocorrespondente = reader.GetString(reader.GetOrdinal("ds_bancocorrespondente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ConvenioCobranca")))
                            reg.Conveniocobranca = reader.GetString(reader.GetOrdinal("conveniocobranca"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_agenciacorrespondente")))
                            reg.Nr_agenciacorrespondente = reader.GetString(reader.GetOrdinal("nr_agenciacorrespondente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_contacorrespondente")))
                            reg.Nr_contacorrespondente = reader.GetString(reader.GetOrdinal("nr_contacorrespondente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("carteiracorrespondente")))
                            reg.Carteiracorrespondente = reader.GetString(reader.GetOrdinal("carteiracorrespondente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_banco")))
                            reg.Nome_banco = reader.GetString(reader.GetOrdinal("ds_banco"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_protestoauto")))
                            reg.St_protestarauto = reader.GetString(reader.GetOrdinal("st_protestoauto")).ToString().Trim().ToUpper().Equals("S");
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_diasprotesto")))
                            reg.Nr_diasprotestar = reader.GetDecimal(reader.GetOrdinal("nr_diasprotesto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("status_remessa")))
                            reg.Status_remessa = reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("A") ? "ACEITO" :
                                reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("R") ? "REJEITADO" : string.Empty;
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                            reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_protestado")))
                            reg.St_protestado = reader.GetString(reader.GetOrdinal("st_protestado"));
                        if (!reader.IsDBNull(reader.GetOrdinal("qt_atualizatitulo")))
                            reg.Qt_atualizatitulo = reader.GetDecimal(reader.GetOrdinal("qt_atualizatitulo"));
                        //Dados do sacado
                        sacado = new CamadaDados.Financeiro.Bloqueto.blPessoa();
                        if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_sacado"))))
                            sacado.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                                reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica :
                                CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                        if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_sacado"))))
                            sacado.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_sacado"))))
                            sacado.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_sacado"));
                        //Endereco do Sacado
                        endSacado = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_endsacado")))
                            endSacado.Rua = reader.GetString(reader.GetOrdinal("ds_endsacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("numero_sacado"))))
                            endSacado.Numero = reader.GetString(reader.GetOrdinal("numero_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_sacado"))))
                            endSacado.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("bairro_sacado"))))
                            endSacado.Bairro = reader.GetString(reader.GetOrdinal("bairro_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_sacado"))))
                            endSacado.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("uf_sacado"))))
                            endSacado.Estado = reader.GetString(reader.GetOrdinal("uf_sacado"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cep_sacado"))))
                            endSacado.CEP = reader.GetString(reader.GetOrdinal("cep_sacado"));
                        sacado.Endereco = endSacado;
                        reg.Sacado = sacado;
                        //Dados Avalista
                        avalista = new CamadaDados.Financeiro.Bloqueto.blPessoa();
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa_avalista")))
                            avalista.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                                reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica : CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                        if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_avalista")))
                            avalista.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_avalista")))
                            avalista.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_avalista"));
                        reg.Avalista = avalista;
                        //Endereco Avalista
                        endAvalista = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_endavalista")))
                            endAvalista.Rua = reader.GetString(reader.GetOrdinal("ds_endavalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("numero_avalista")))
                            endAvalista.Numero = reader.GetString(reader.GetOrdinal("numero_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento_avalista")))
                            endAvalista.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("bairro_avalista")))
                            endAvalista.Bairro = reader.GetString(reader.GetOrdinal("bairro_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_avalista")))
                            endAvalista.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("uf_avalista")))
                            endAvalista.Estado = reader.GetString(reader.GetOrdinal("uf_avalista"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cep_avalista")))
                            endAvalista.CEP = reader.GetString(reader.GetOrdinal("cep_avalista"));
                        reg.EndAvalista = endAvalista;
                        //Dados do Cedente
                        cedente = new CamadaDados.Financeiro.Bloqueto.blCedente();
                        if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_cedente"))))
                            cedente.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("J") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaJuridica :
                                reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("F") ? CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiPessoaFisica : CamadaDados.Financeiro.Bloqueto.TTipoInscricao.tiOutro;
                        if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_cedente"))))
                            cedente.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_cedente"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_cedente"))))
                            cedente.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_cedente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CodigoCedente")))
                            cedente.CodigoCedente = reader.GetString(reader.GetOrdinal("CodigoCedente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DigitoCedente")))
                            cedente.DigitoCodigoCedente = reader.GetString(reader.GetOrdinal("DigitoCedente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("postocedente")))
                            cedente.Postocedente = reader.GetString(reader.GetOrdinal("postocedente"));
                        //Endereco do Cedente
                        endCedente = new CamadaDados.Financeiro.Bloqueto.blEndereco();
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_endereco_cedente"))))
                            endCedente.Rua = reader.GetString(reader.GetOrdinal("ds_endereco_cedente"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("numero_cedente"))))
                            endCedente.Numero = reader.GetString(reader.GetOrdinal("numero_cedente"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_cedente"))))
                            endCedente.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_cedente"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("bairro_cedente"))))
                            endCedente.Bairro = reader.GetString(reader.GetOrdinal("bairro_cedente"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_cedente"))))
                            endCedente.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_cedente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("uf_cedente")))
                            endCedente.Estado = reader.GetString(reader.GetOrdinal("uf_cedente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cep_cedente")))
                            endCedente.CEP = reader.GetString(reader.GetOrdinal("cep_cedente"));
                        cedente.Endereco = endCedente;
                        //Dados Bancarios Cedente
                        dbCedente = new CamadaDados.Financeiro.Bloqueto.blContaBancaria();
                        if (!reader.IsDBNull(reader.GetOrdinal("NR_Agencia")))
                            dbCedente.CodigoAgencia = reader.GetString(reader.GetOrdinal("NR_Agencia"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DigitoAgencia")))
                            dbCedente.DigitoAgencia = reader.GetString(reader.GetOrdinal("DigitoAgencia"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NR_ContaCorrente")))
                            dbCedente.NumeroConta = reader.GetString(reader.GetOrdinal("NR_ContaCorrente"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DigitoConta")))
                            dbCedente.DigitoConta = reader.GetString(reader.GetOrdinal("DigitoConta"));
                        //Dados do Banco
                        banco = new CamadaDados.Financeiro.Bloqueto.blBanco();
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                            banco.Codigo = reader.GetString(reader.GetOrdinal("CD_Banco"));
                        dbCedente.Banco = banco;
                        cedente.ContaBancaria = dbCedente;
                        reg.Cedente = cedente;
                        reader.Close();
                        reg.Instrucoes = "VÁLIDO PARA PAGAMENTO SOMENTE ATÉ O DIA " + DateTime.Now.ToString("dd/MM/yyyy") + "\r\n" +
                                         "BOLETO REEMITIDO COM DATA DE VENCTO E VALOR ATUALIZADOS\r\n" +
                                         "(VALOR ORIGINAL + ENCARGOS)\r\n" +
                                         "VENCIMENTO ORIGINAL: " + reg.Dt_vencimento.Value.ToString("dd/MM/yyyy") + "\r\n" +
                                         "VALOR ORIGINAL: " + reg.Vl_atual.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                                         
                        //Calcular Multa
                        if (reg.Pc_multa > decimal.Zero)
                            if (reg.Dt_vencimento.Value.AddDays(Convert.ToDouble(reg.Nr_diasmulta)).Date < DateTime.Now.Date)
                                reg.Vl_multacalc = Math.Round(reg.Tp_multa.Trim().ToUpper().Equals("P") ? ((reg.Vl_documento * reg.Pc_multa) / 100) : reg.Pc_multa, 2);
                        //Calcular Juro
                        if ((reg.Pc_jurodia > decimal.Zero) && (reg.Dt_vencimento.Value.Date < DateTime.Now.Date))
                            reg.Vl_jurocalc = Math.Round((reg.Tp_jurodia.Trim().ToUpper().Equals("P") ? ((reg.Vl_documento * reg.Pc_jurodia) / 100) : reg.Pc_jurodia), 2) *
                                                    DateTime.Now.Subtract(reg.Dt_vencimento.Value).Days;
                        reg.Instrucoes += "ENCARGOS: " + (reg.Vl_multacalc + reg.Vl_jurocalc).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        reg.Dt_vencimento = DateTime.Now;
                        //Alterar Vencimento parcela
                        comando.CommandText = "update tb_fin_parcela set dt_vencto = convert(datetime, floor(convert(decimal(30,10), getdate()))), dt_alt = getdate() " +
                                              "where cd_empresa = @cd_empresa and nr_lancto = @nr_lancto and cd_parcela = @cd_parcela";
                        comando.Parameters.Clear();
                        comando.Parameters.Add("@cd_empresa", Cd_empresa);
                        comando.Parameters.Add("@nr_lancto", Nr_lancto);
                        comando.Parameters.Add("@cd_parcela", Cd_parcela);
                        comando.ExecuteNonQuery();
                        //Alterar dados boleto
                        comando.CommandText = "update tb_cob_titulo set vl_multacalc = @vl_multacalc, vl_jurocalc = @vl_jurocalc, ds_instrucoes = @ds_instrucoes, qt_atualizatitulo = isnull(qt_atualizatitulo, 0) + 1, dt_alt = getdate() " +
                                              "where cd_empresa = @cd_empresa and nr_lancto = @nr_lancto and cd_parcela = @cd_parcela and id_cobranca = @id_cobranca ";
                        comando.Parameters.Clear();
                        comando.Parameters.Add("@vl_jurocalc", reg.Vl_jurocalc);
                        comando.Parameters.Add("@vl_multacalc", reg.Vl_multacalc);
                        comando.Parameters.Add("@ds_instrucoes", reg.Instrucoes);
                        comando.Parameters.Add("@cd_empresa", Cd_empresa);
                        comando.Parameters.Add("@nr_lancto", Nr_lancto);
                        comando.Parameters.Add("@cd_parcela", Cd_parcela);
                        comando.Parameters.Add("@id_cobranca", Id_cobranca);
                        comando.ExecuteNonQuery();
                        return reg;
                    }
                    else return null;
                else return null;
            }
            catch { return null; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
