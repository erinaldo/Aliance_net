using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;

namespace WS_AlianceFoods
{
    public class TProduto
    {
        public string Cd_item { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public double Quantidade { get; set; }
        public double Vl_venda { get; set; }
        public double Vl_pago { get; set; }
        public double Vl_subtotal { get { return (Quantidade * Vl_venda) - Vl_pago; } }
        public string Observacao { get; set; }
        public string Porta { get; set; }
        public decimal Combinado { get; set; }
        public bool ST_NotVendaMenor { get; set; }
        public int Ativo { get; set; }
        public string Hora { get; set; }

        public TProduto() 
        {
            this.Cd_item = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Quantidade = 0;
            this.Vl_venda = 0;
            this.Observacao = string.Empty;
            this.Porta = string.Empty;
            this.Combinado = 0;
            this.ST_NotVendaMenor = false;
            this.Ativo = 1;
            this.Hora = string.Empty;
        }
    }

    public class TObservacao
    {
        public string Codigo { get; set; }
        public string Observa { get; set; }

        public TObservacao() 
        {
            this.Codigo = string.Empty;
            this.Observa = string.Empty;
        }
    }

    public class TSabor
    {
        public string Codigo { get; set; }
        public string Sabor { get; set; }

        public TSabor() 
        {
            this.Codigo = string.Empty;
            this.Sabor = string.Empty;
        }
    }

    public class TPortador
    {
        public string Id_portador { get; set; }
        public string Ds_portador { get; set; }
    }
        
    public static class TConexao
    {
        static string servidor = string.Empty;
        static string banco = string.Empty;
        static string login = string.Empty;
        static string senha = string.Empty;

        static  fbCon;
        public static FbConnection FbCon
        { get { return fbCon; } }
        public static void Ativar(bool ativar)
        {                                                                                                                                                                                           
            if (ativar)
            {
                if (string.IsNullOrEmpty(servidor) ||
                    string.IsNullOrEmpty(banco) ||
                    string.IsNullOrEmpty(login) ||
                    string.IsNullOrEmpty(senha))
                {
                    StreamReader r = new StreamReader("C:\\TecnoAliance\\Servico\\Config.txt");
                    while (!r.EndOfStream)
                    {
                        string[] linha = r.ReadLine().Split(new char[] { '=' });
                        if (linha[0].Trim().ToUpper().Equals("SERVIDOR"))
                            servidor = linha[1].Trim();
                        if (linha[0].Trim().ToUpper().Equals("BANCO"))
                            banco = linha[1].Trim();
                        if (linha[0].Trim().ToUpper().Equals("LOGIN"))
                            login = linha[1].Trim();
                        if (linha[0].Trim().ToUpper().Equals("SENHA"))
                            senha = linha[1].Trim();
                    }
                }
                fbCon = new FbConnection("DataSource=" + servidor + 
                                         ";DataBase=" + banco + 
                                         ";User=" + login + 
                                         ";Password=" + senha);
                fbCon.Open();

            }
            else
            {
                if(fbCon.State == System.Data.ConnectionState.Open)
                    fbCon.Close();
            }
        }
    }

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tecnoaliance.com.br/ws_foods/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TWS_Foods : System.Web.Services.WebService
    {
        private string Conexao = "user id=MASTER;data source='localhost';persist security info=false;initial catalog=BASE_RDC;password=LogMaster*2015;Connect Timeout=120";
        private string strConAliance = "user id=MASTER;data source='localhost';persist security info=false;initial catalog=ALIANCE;password=LogMaster*2015;Connect Timeout=120";

        [WebMethod]
        public string ValidarLogin(string Login, string Senha)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select a.cd_clifor from TB_FIN_Clifor a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("on a.loginvendedor = b.login ");
            sql.AppendLine("where a.loginvendedor = '" + Login.Trim() + "' ");
            sql.AppendLine("and b.senha = '" + Senha.Trim() + "' ");

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                //Executar comando
                object obj = comando.ExecuteScalar();
                return obj == null ? "3" : obj.ToString();
            }
            catch { return "9"; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string ValidarLogin(string Login, string Senha)
        //{
        //    FbCommand fbCom = new FbCommand("select codigo from cliente where tipocli = 5 and login = '" + Login.Trim() + "' and senha = '" + Senha.Trim() + "'");
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        object obj = fbCom.ExecuteScalar();
        //        return obj == null ? "3" : obj.ToString();
        //    }
        //    catch { return "9"; }
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        public string AbrirCaixa(string Login, string Vl_abertura)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction t = null;
            try
            {
                //Abrir conexao
                con.Open();
                t = con.BeginTransaction();
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.Text;
                //Verificar se vendedor tem permissao para abrir caixa
                //códigocomentado por que não existe regra especial por usuario para abrir caixa
                //comando.CommandText = "select coalesce(caixa, 0) from cliente where login = '" + Login.Trim() + "'";
                //object obj = comando.ExecuteScalar();
                //if (obj.ToString().Trim().Equals("0"))
                //    return "7";//Login não tem permissão para abrir caixa
                comando.CommandText = "select a.id_caixa from TB_PDV_Caixa a where isnull(a.st_registro, 'A') = 'A' and a.login = '" + Login.Trim() + "'";
                object obj = comando.ExecuteScalar();
                if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                {
                    string cd_empresa = string.Empty;
                    comando.CommandText = "select top 1 cd_empresa TB_RES_Config ";
                    cd_empresa = comando.ExecuteScalar().ToString();
                    //Buscar codigo do vendedor
                    comando.CommandText = "select cd_clifor from TB_FIN_Clifor where login = '" + Login.Trim() + "'";
                    obj = comando.ExecuteScalar();
                    //Abrir caixa
                    comando.CommandText = "insert into TB_PDV_CAIXA(ID_CAIXA, LOGIN, CD_EMPRESA, DT_ABERTURA, VL_TRANSPORTAR, ST_REGISTRO, DT_Cad, DT_Alt)" +
                                          "values(@P_ID_CAIXA, @P_LOGIN, @P_CD_EMPRESA, @P_DT_ABERTURA, @P_VL_TRANSPORTAR, @P_ST_REGISTRO, GETDATE(), GETDATE())";
                    comando.Parameters.AddWithValue("@P_ID_CAIXA", obj.ToString());
                    comando.Parameters.AddWithValue("@P_LOGIN", Login.Trim());
                    comando.Parameters.AddWithValue("@P_CD_EMPRESA", cd_empresa);
                    comando.Parameters.AddWithValue("@P_DT_ABERTURA", DateTime.Now);
                    comando.Parameters.AddWithValue("@P_VL_TRANSPORTAR", decimal.Divide(decimal.Parse(Vl_abertura), 100));
                    comando.Parameters.AddWithValue("@P_ST_REGISTRO", "A");
                    comando.ExecuteNonQuery();
                    //Código comentado por forma de pagamento não existir no aliance na abertura de caixa.
                    //comando.CommandText = "select codigo from abrefechacaixa where numcaixa = " + obj.ToString() + " and status = 1";
                    //obj = fbCom.ExecuteScalar();
                    //string id_caixa = obj.ToString();
                    //////Buscar Forma Pagamento
                    //fbCom.CommandText = "select codigo, descricao from formapagamento where tipo > 0";
                    //FbDataReader reader = fbCom.ExecuteReader();
                    //System.Collections.ArrayList lPortador = new System.Collections.ArrayList();
                    //if (reader.HasRows)
                    //    while (reader.Read())
                    //    {
                    //        string portador = string.Empty;
                    //        if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
                    //            portador = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
                    //        if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
                    //            portador += "|" + reader.GetString(reader.GetOrdinal("descricao"));
                    //        lPortador.Add(portador);

                    //    }
                    //for (int i = 0; i < lPortador.Count; i++)
                    //{
                    //    string cod_forma = lPortador[i].ToString().Split(new char[] { '|' })[0];
                    //    string ds_forma = lPortador[i].ToString().Split(new char[] { '|' })[1];
                    //    fbCom.CommandText = "insert into abrefechacaixa_x_portador(id_caixa, id_portador, descricao)values(@id_caixa, @id_portador, @descricao)";
                    //    fbCom.Parameters.Add("@id_caixa", id_caixa);
                    //    fbCom.Parameters.Add("@id_portador", cod_forma);
                    //    fbCom.Parameters.Add("@descricao", ds_forma);
                    //    fbCom.ExecuteNonQuery();
                    //}
                    t.Commit();
                    return "0";//Caixa Aberto com Sucesso
                }
                else return "8";//Caixa ja esta aberto para o login informado
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                return "9";
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string AbrirCaixa(string Login, string Vl_abertura)
        //{
        //    //Verificar se existe caixa aberto para o login
        //    FbTransaction fbTran = null;
        //    FbCommand fbCom = new FbCommand();
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbTran = TConexao.FbCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        //        fbCom.Connection = TConexao.FbCon;
        //        fbCom.Transaction = fbTran;
        //        fbCom.CommandType = System.Data.CommandType.Text;
        //        fbCom.Connection = TConexao.FbCon;
        //        //Verificar se vendedor tem permissao para abrir caixa
        //        fbCom.CommandText = "select coalesce(caixa, 0) from cliente where login = '" + Login.Trim() + "'";
        //        object obj = fbCom.ExecuteScalar();
        //        if (obj.ToString().Trim().Equals("0"))
        //            return "7";//Login não tem permissão para abrir caixa
        //        fbCom.CommandText = "select a.codigo from abrefechacaixa a where a.status = 1 and a.login = '" + Login.Trim() + "'";
        //        obj = fbCom.ExecuteScalar();
        //        if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
        //        {
        //            //Buscar codigo do vendedor
        //            fbCom.CommandText = "select codigo from cliente where login = '" + Login.Trim() + "'";
        //            obj = fbCom.ExecuteScalar();
        //            //Abrir caixa
        //            fbCom.CommandText = "insert into abrefechacaixa(numcaixa, databer, horabre, valorabre, status, login)" +
        //                                "values(@numcaixa, @databer, @horabre, @valorabre, @status, @login)";
        //            fbCom.Parameters.Add("@numcaixa", obj.ToString());
        //            fbCom.Parameters.Add("@databer", DateTime.Now.Date);
        //            fbCom.Parameters.Add("@horabre", DateTime.Now.TimeOfDay);
        //            fbCom.Parameters.Add("@valorabre", decimal.Divide(decimal.Parse(Vl_abertura), 100));
        //            fbCom.Parameters.Add("@status", "1");
        //            fbCom.Parameters.Add("@login", Login.Trim());
        //            fbCom.ExecuteNonQuery();
        //            fbCom.CommandText = "select codigo from abrefechacaixa where numcaixa = " + obj.ToString() + " and status = 1";
        //            obj = fbCom.ExecuteScalar();
        //            string id_caixa = obj.ToString();
        //            ////Buscar Forma Pagamento
        //            fbCom.CommandText = "select codigo, descricao from formapagamento where tipo > 0";
        //            FbDataReader reader = fbCom.ExecuteReader();
        //            System.Collections.ArrayList lPortador = new System.Collections.ArrayList();
        //            if(reader.HasRows)
        //                while (reader.Read())
        //                {
        //                    string portador = string.Empty;
        //                    if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
        //                        portador = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
        //                    if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
        //                        portador += "|" + reader.GetString(reader.GetOrdinal("descricao"));
        //                    lPortador.Add(portador);

        //                }
        //            for (int i = 0; i < lPortador.Count; i++)
        //            {
        //                string cod_forma = lPortador[i].ToString().Split(new char[] { '|' })[0];
        //                string ds_forma = lPortador[i].ToString().Split(new char[] { '|' })[1];
        //                fbCom.CommandText = "insert into abrefechacaixa_x_portador(id_caixa, id_portador, descricao)values(@id_caixa, @id_portador, @descricao)";
        //                fbCom.Parameters.Add("@id_caixa", id_caixa);
        //                fbCom.Parameters.Add("@id_portador", cod_forma);
        //                fbCom.Parameters.Add("@descricao", ds_forma);
        //                fbCom.ExecuteNonQuery();
        //            }
        //            fbTran.Commit();
        //            return "0";//Caixa Aberto com Sucesso
        //        }
        //        else return "8";//Caixa ja esta aberto para o login informado
        //    }
        //    catch 
        //    {
        //        if (fbTran != null)
        //            fbTran.Rollback();
        //        return "9"; 
        //    }
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}



        //[WebMethod]
        //public string AbrirCartao(string NumeroCartao, string Fone, string CartaoMenor, string NomeCliente)
        //{
        //    FbCommand fbCom = new FbCommand();
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        //Buscar padrao caracteres do numero cartao
        //        fbCom.CommandText = "select padraoetiq from paramsis";
        //        object obj = fbCom.ExecuteScalar();
        //        if (obj != null)
        //            if (NumeroCartao.Trim().Length != obj.ToString().Trim().Length)
        //                return "3"; //Cartao Invalido
        //        //Buscar cartao rotativo
        //        bool st_rotativo = false;
        //        fbCom.CommandText = "select tp_cartao from paramsis";
        //        obj = fbCom.ExecuteScalar();
        //        if (obj != null)
        //            st_rotativo = obj.ToString().Trim().Equals("1");
        //        if (st_rotativo)
        //        {
        //            fbCom.CommandText = "select 1 from paramsis " +
        //                                "where faixa_cartao_ini <= " + NumeroCartao + " and faixa_cartao_fim >= " + NumeroCartao;
        //            obj = fbCom.ExecuteScalar();
        //            if (obj == null ? true : !obj.ToString().Trim().Equals("1"))
        //                return "3";//Cartao Invalido
        //        }
        //        fbCom.CommandText = "select cast(a.databre + a.horabre as timestamp) as dt_abertura, " +
        //                            "a.bloqueado, current_timestamp as dt_atual " +
        //                            "from inicard a " +
        //                            "where a.codbarra = '" + NumeroCartao.Trim() + "' and a.status = 1";
        //        FbDataReader reader = fbCom.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            if (reader.Read())
        //            {
        //                DateTime dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
        //                DateTime dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
        //                bool St_bloqueado = !reader.IsDBNull(reader.GetOrdinal("bloqueado"));
        //                if (St_bloqueado)
        //                    return "4";//Cartao Bloqueado
        //                fbCom.CommandText = "select expiracartao from paramsis";
        //                obj = fbCom.ExecuteScalar();
        //                if (obj == null ? false : decimal.Parse(obj.ToString()) > 0)
        //                    if (dt_abertura.AddHours(Convert.ToDouble(obj.ToString())) < dt_atual)
        //                        return "2"; //Cartao expirado
        //                    else
        //                        return "1"; //Cartao ja estava aberto
        //                else
        //                    return "1"; //Cartao ja estava Aberto
        //            }
        //            else
        //            {
        //                //Buscar limite credito do cartao
        //                double vl_limite = 0;
        //                fbCom.CommandText = "select limitecred from inicard where codbarra = '" + NumeroCartao.Trim() + "' " +
        //                                    "and status = 1 and coalesce(bloqueado, 0) <> 1";
        //                obj = fbCom.ExecuteScalar();
        //                if (obj != null)
        //                    vl_limite = Convert.ToDouble(obj.ToString());
        //                //Buscar cliente
        //                int cd_cliente = 0;
        //                fbCom.CommandText = "select codigo from cliente where fone = '" + Fone.Trim() + "'";
        //                obj = fbCom.ExecuteScalar();
        //                if (obj != null)
        //                    cd_cliente = Convert.ToInt32(obj.ToString());
        //                else
        //                {
        //                    fbCom.CommandText = "insert into cliente(nome, fone, tipocli)values(@nome, @fone, @tipocli)";
        //                    fbCom.Parameters.Add("@nome", string.IsNullOrEmpty(NomeCliente) ? "CLIENTE PREFERENCIAL" : NomeCliente.Trim());
        //                    fbCom.Parameters.Add("@fone", Fone);
        //                    fbCom.Parameters.Add("@tipocli", "0");
        //                    fbCom.ExecuteNonQuery();
        //                    fbCom.CommandText = "select codigo from cliente where fone = '" + Fone.Trim() + "'";
        //                    obj = fbCom.ExecuteScalar();
        //                    if (obj != null)
        //                        cd_cliente = Convert.ToInt32(obj.ToString());
        //                }
        //                //Verificar se cartao exige mesa
        //                fbCom.CommandText = "select mesa_cartao from paramsis";
        //                obj = fbCom.ExecuteScalar();
        //                if (obj == null ? true : !obj.ToString().Trim().Equals("1"))
        //                {
        //                    fbCom.CommandText = "select first 1 codigo from mesas";
        //                    obj = fbCom.ExecuteScalar();
        //                    fbCom.CommandText = "insert into inicard(databre, horabre, codbarra, codcliente, " +
        //                                        "limitecred, status, cartaomenor, mesa)values(@databre, @horabre, @codbarra, " +
        //                                        "@codcliente, @limitecred, @status, @cartaomenor, @mesa)";
        //                    fbCom.Parameters.Add("@databre", DateTime.Now.Date);
        //                    fbCom.Parameters.Add("@horabre", DateTime.Now.TimeOfDay);
        //                    fbCom.Parameters.Add("@codbarra", NumeroCartao);
        //                    fbCom.Parameters.Add("@codcliente", cd_cliente);
        //                    fbCom.Parameters.Add("@limitecred", vl_limite);
        //                    fbCom.Parameters.Add("@status", "1");
        //                    fbCom.Parameters.Add("@cartaomenor", CartaoMenor);
        //                    fbCom.Parameters.Add("@mesa", obj.ToString());
        //                    fbCom.ExecuteNonQuery();
        //                    return "5"; //Cartao Aberto com Mesa Padrao
        //                }
        //                else
        //                {
        //                    fbCom.CommandText = "insert into inicard(databre, horabre, codbarra, codcliente, " +
        //                                        "limitecred, status, cartaomenor)values(@databre, @horabre, @codbarra, " +
        //                                        "@codcliente, @limitecred, @status, @cartaomenor)";
        //                    fbCom.Parameters.Add("@databre", DateTime.Now.Date);
        //                    fbCom.Parameters.Add("@horabre", DateTime.Now.TimeOfDay);
        //                    fbCom.Parameters.Add("@codbarra", NumeroCartao);
        //                    fbCom.Parameters.Add("@codcliente", cd_cliente);
        //                    fbCom.Parameters.Add("@limitecred", vl_limite);
        //                    fbCom.Parameters.Add("@status", "1");
        //                    fbCom.Parameters.Add("@cartaomenor", CartaoMenor);
        //                    fbCom.ExecuteNonQuery();
        //                    return "0"; //Cartao Aberto
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //Buscar limite credito do cartao
        //            double vl_limite = 0;
        //            fbCom.CommandText = "select limitecred from inicard where codbarra = '" + NumeroCartao.Trim() + "' " +
        //                                "and status = 1 and coalesce(bloqueado, 0) <> 1";
        //            obj = fbCom.ExecuteScalar();
        //            if (obj != null)
        //                vl_limite = Convert.ToDouble(obj.ToString());
        //            //Buscar cliente
        //            int cd_cliente = 0;
        //            fbCom.CommandText = "select codigo from cliente where fone = '" + Fone.Trim() + "'";
        //            obj = fbCom.ExecuteScalar();
        //            if (obj != null)
        //                cd_cliente = Convert.ToInt32(obj.ToString());
        //            else
        //            {
        //                fbCom.CommandText = "insert into cliente(nome, fone, tipocli)values(@nome, @fone, @tipocli)";
        //                fbCom.Parameters.Add("@nome", "CLIENTE PREFERENCIAL");
        //                fbCom.Parameters.Add("@fone", Fone);
        //                fbCom.Parameters.Add("@tipocli", "0");
        //                fbCom.ExecuteNonQuery();
        //                fbCom.CommandText = "select codigo from cliente where fone = '" + Fone.Trim() + "'";
        //                obj = fbCom.ExecuteScalar();
        //                if (obj != null)
        //                    cd_cliente = Convert.ToInt32(obj.ToString());
        //            }
        //            //Verificar se cartao exige mesa
        //            fbCom.CommandText = "select mesa_cartao from paramsis";
        //            obj = fbCom.ExecuteScalar();
        //            if (obj == null ? true : !obj.ToString().Trim().Equals("1"))
        //            {
        //                fbCom.CommandText = "select first 1 codigo from mesas";
        //                obj = fbCom.ExecuteScalar();
        //                fbCom.CommandText = "insert into inicard(databre, horabre, codbarra, codcliente, " +
        //                                    "limitecred, status, cartaomenor, mesa)values(@databre, @horabre, @codbarra, " +
        //                                    "@codcliente, @limitecred, @status, @cartaomenor, @mesa)";
        //                fbCom.Parameters.Add("@databre", DateTime.Now.Date);
        //                fbCom.Parameters.Add("@horabre", DateTime.Now.TimeOfDay);
        //                fbCom.Parameters.Add("@codbarra", NumeroCartao);
        //                fbCom.Parameters.Add("@codcliente", cd_cliente);
        //                fbCom.Parameters.Add("@limitecred", vl_limite);
        //                fbCom.Parameters.Add("@status", "1");
        //                fbCom.Parameters.Add("@cartaomenor", CartaoMenor);
        //                fbCom.Parameters.Add("@mesa", obj.ToString());
        //                fbCom.ExecuteNonQuery();
        //                return "5"; //Cartao Aberto com Mesa Padrao
        //            }
        //            else
        //            {
        //                fbCom.CommandText = "insert into inicard(databre, horabre, codbarra, codcliente, " +
        //                                    "limitecred, status, cartaomenor)values(@databre, @horabre, @codbarra, " +
        //                                    "@codcliente, @limitecred, @status, @cartaomenor)";
        //                fbCom.Parameters.Add("@databre", DateTime.Now.Date);
        //                fbCom.Parameters.Add("@horabre", DateTime.Now.TimeOfDay);
        //                fbCom.Parameters.Add("@codbarra", NumeroCartao);
        //                fbCom.Parameters.Add("@codcliente", cd_cliente);
        //                fbCom.Parameters.Add("@limitecred", vl_limite);
        //                fbCom.Parameters.Add("@status", "1");
        //                fbCom.Parameters.Add("@cartaomenor", CartaoMenor);
        //                fbCom.ExecuteNonQuery();
        //                return "0"; //Cartao Aberto
        //            }
        //        }
        //    }
        //    catch { return "9"; }//Erro Sistema
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        public string AbrirCartao(string NumeroCartao, string Fone, string CartaoMenor, string NomeCliente)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction t = null;
            try
            {
                con.Open();
                t = con.BeginTransaction();
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //Código comentado por não possuir este padrão na tabela TB_RES_Config
                ////Buscar padrao caracteres do numero cartao
                //comando.CommandText = "select padraoetiq from paramsis";
                //object obj = comando.ExecuteScalar();
                //if (obj != null)
                //    if (NumeroCartao.Trim().Length != obj.ToString().Trim().Length)
                //        return "3"; //Cartao Invalido
                //Buscar cartao rotativo
                bool st_rotativo = false;
                comando.CommandText = "select TP_Cartao from TB_RES_Config";
                object obj = comando.ExecuteScalar();
                if (obj != null)
                    st_rotativo = obj.ToString().Trim().Equals("0");
                if (st_rotativo)
                {
                    comando.CommandText = "select 1 from TB_RES_Config " +
                                        "where NR_CartaoRotIni <= " + NumeroCartao + " and NR_CartaoRotFin >= " + NumeroCartao;
                    obj = comando.ExecuteScalar();
                    if (obj == null ? true : !obj.ToString().Trim().Equals("1"))
                        return "3";//Cartao Invalido
                }
                comando.CommandText = "select a.DT_Abertura, " +
                                    "GETDATE() as dt_atual " +
                                    "from TB_RES_Cartao a " +
                                    "where a.NR_Cartao = '" + NumeroCartao.Trim() + "' and ISNULL(a.ST_Registro, 'A') = 'A'";
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        DateTime dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                        DateTime dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
                        //Não existe campo para cartao bloqueado
                        //bool St_bloqueado = !reader.IsDBNull(reader.GetOrdinal("bloqueado"));
                        //if (St_bloqueado)
                        //    return "4";//Cartao Bloqueado

                        //Comnetado por não existir expiracartao na tabela TB_RES_Cartao no Aliance
                        //comando.CommandText = "select expiracartao from paramsis";
                        //obj = comando.ExecuteScalar();
                        //if (obj == null ? false : decimal.Parse(obj.ToString()) > 0)
                        //    if (dt_abertura.AddHours(Convert.ToDouble(obj.ToString())) < dt_atual)
                        //        return "2"; //Cartao expirado
                        //    else
                        //        return "1"; //Cartao ja estava aberto
                        //else
                        //    return "1"; //Cartao ja estava Aberto
                        return "1"; //Cartao ja estava Aberto
                    }
                    else
                    {
                        //Buscar limite credito do cartao
                        double vl_limite = 0;
                        comando.CommandText = "select Vl_LimiteCartao from TB_RES_Cartao where NR_Cartao = '" + NumeroCartao.Trim() + "' " +
                                              "and ISNULL(a.ST_Registro, 'A') = 'A' ";/*and coalesce(bloqueado, 0) <> 1";*/
                        obj = comando.ExecuteScalar();
                        if (obj != null)
                            vl_limite = Convert.ToDouble(obj.ToString());
                        //Buscar cliente
                        string cd_cliente = string.Empty;
                        comando.CommandText = "select codigo from TB_FIN_Endereco where Celular = '" + Fone.Trim() + "'";
                        obj = comando.ExecuteScalar();
                        if (obj != null)
                            cd_cliente = obj.ToString();
                        else
                        {
                            string condfiscal = string.Empty;
                            comando.CommandText = "select Cd_CondFiscal_Clifor from TB_RES_Config";
                            obj = comando.ExecuteScalar();
                            if (obj != null)
                                condfiscal = obj.ToString();
                            comando.CommandText = "IA_FIN_CLIFOR";
                            //Derivar Parametros
                            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                            comando.Parameters["@P_CD_CLIFOR"].Value = DBNull.Value;
                            comando.Parameters["@P_NM_CLIFOR"].Value = string.IsNullOrEmpty(NomeCliente) ? "CLIENTE PREFERENCIAL" : NomeCliente.Trim();
                            comando.Parameters["@P_CD_CONDFISCAL_CLIFOR"].Value = condfiscal;
                            comando.Parameters["@P_TP_PESSOA"].Value = "F";
                            comando.ExecuteNonQuery();
                            cd_cliente = comando.Parameters["@P_CD_CLIFOR"].Value.ToString();

                            comando.CommandText = "IA_FIN_ENDERECO";
                            comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                            comando.Parameters["@P_CELULAR"].Value = Fone.Trim();
                            comando.ExecuteNonQuery();
                        }
                        string cd_empresa = string.Empty;
                        string id_cartao = string.Empty;
                        //Verificar se cartao exige mesa
                        comando.CommandText = "select ST_MesaCartao from TB_RES_Config";
                        obj = comando.ExecuteScalar();
                        comando.CommandText = "select top 1 cd_empresa TB_RES_Config ";
                        cd_empresa = comando.ExecuteScalar().ToString();

                        comando.CommandText = "select id_cartao from TB_RES_Cartao from nr_cartao = '" + NumeroCartao.Trim() + "'";
                        id_cartao = comando.ExecuteScalar().ToString();
                        if (obj == null ? true : !obj.ToString().Trim().Equals("S"))
                        {
                            string mesa = string.Empty;
                            
                            //
                            comando.CommandText = "select TOP 1 ID_Mesa from TB_RES_Mesa";
                            mesa = comando.ExecuteScalar().ToString();
                            comando.CommandText = "IA_RES_CARTAO";
                           
                            //Derivar Parametros
                            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                            comando.Parameters["@P_CD_EMPRESA"].Value = cd_empresa;
                            comando.Parameters["@P_ID_CARTAO"].Value = id_cartao;
                            comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                            comando.Parameters["@P_ID_MESA"].Value = mesa;
                            comando.Parameters["@P_NR_CARTAO"].Value = NumeroCartao;
                            comando.Parameters["@P_DT_ABERTURA"].Value = DateTime.Now;
                            comando.Parameters["@P_ST_MENORIDADE"].Value = CartaoMenor.Equals("1") ? "S" : "N";
                            comando.Parameters["@P_VL_LIMITECARTAO"].Value = vl_limite;
                            comando.Parameters["@P_ST_REGISTRO"].Value = "A";

                            comando.ExecuteNonQuery();
                            return "5"; //Cartao Aberto com Mesa Padrao
                        }
                        else
                        {
                            //Derivar Parametros
                            comando.CommandText = "IA_RES_CARTAO";
                            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                            comando.Parameters["@P_CD_EMPRESA"].Value = cd_empresa;
                            comando.Parameters["@P_ID_CARTAO"].Value = id_cartao;
                            comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                            comando.Parameters["@P_NR_CARTAO"].Value = NumeroCartao;
                            comando.Parameters["@P_DT_ABERTURA"].Value = DateTime.Now;
                            comando.Parameters["@P_ST_MENORIDADE"].Value = CartaoMenor.Equals("1") ? "S" : "N";
                            comando.Parameters["@P_VL_LIMITECARTAO"].Value = vl_limite;
                            comando.Parameters["@P_ST_REGISTRO"].Value = "A";
                            comando.ExecuteNonQuery();
                            return "0"; //Cartao Aberto
                        }
                    }
                }
                else
                {
                    //Buscar limite credito do cartao
                    double vl_limite = 0;
                    comando.CommandText = "select Vl_LimiteCartao from TB_RES_Cartao where NR_Cartao = '" + NumeroCartao.Trim() + "' " +
                                        "and ISNULL(a.ST_Registro, 'A') = 'A'"; /*and coalesce(bloqueado, 0) <> 1";*/
                    obj = comando.ExecuteScalar();
                    if (obj != null)
                        vl_limite = Convert.ToDouble(obj.ToString());
                    //Buscar cliente
                    string cd_cliente = string.Empty;
                    comando.CommandText = "select codigo from TB_FIN_Endereco where Celular = '" + Fone.Trim() + "'";
                    obj = comando.ExecuteScalar();
                    if (obj != null)
                        cd_cliente = obj.ToString();
                    else
                    {
                        string condfiscal = string.Empty;
                        comando.CommandText = "select Cd_CondFiscal_Clifor from TB_RES_Config";
                        obj = comando.ExecuteScalar();
                        if (obj != null)
                            condfiscal = obj.ToString();
                        comando.CommandText = "IA_FIN_CLIFOR";
                        //Derivar Parametros
                        System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@P_CD_CLIFOR"].Value = DBNull.Value;
                        comando.Parameters["@P_NM_CLIFOR"].Value = string.IsNullOrEmpty(NomeCliente) ? "CLIENTE PREFERENCIAL" : NomeCliente.Trim();
                        comando.Parameters["@P_CD_CONDFISCAL_CLIFOR"].Value = condfiscal;
                        comando.Parameters["@P_TP_PESSOA"].Value = "F";
                        comando.ExecuteNonQuery();
                        cd_cliente = comando.Parameters["@P_CD_CLIFOR"].Value.ToString();

                        comando.CommandText = "IA_FIN_ENDERECO";
                        comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                        comando.Parameters["@P_CELULAR"].Value = Fone.Trim();
                        comando.ExecuteNonQuery();
                    }
                    //Verificar se cartao exige mesa
                    comando.CommandText = "select ST_MesaCartao from TB_RES_Config";
                    obj = comando.ExecuteScalar();
                    string cd_empresa = string.Empty;
                    string id_cartao = string.Empty;
                    //Buscar Empresa
                    comando.CommandText = "select top 1 cd_empresa TB_RES_Config ";
                    cd_empresa = comando.ExecuteScalar().ToString();
                    //Buscar Cartão
                    comando.CommandText = "select id_cartao from TB_RES_Cartao from nr_cartao = '" + NumeroCartao.Trim() + "'";
                    id_cartao = comando.ExecuteScalar().ToString();
                    if (obj == null ? true : !obj.ToString().Trim().Equals("S"))
                    {
                        comando.CommandText = "select top 1 ID_Mesa from TB_RES_Mesa";
                        obj = comando.ExecuteScalar();
                        comando.CommandText = "IA_RES_CARTAO";

                        //Derivar Parametros
                        System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@P_CD_EMPRESA"].Value = cd_empresa;
                        comando.Parameters["@P_ID_CARTAO"].Value = id_cartao;
                        comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                        comando.Parameters["@P_ID_MESA"].Value = obj.ToString();
                        comando.Parameters["@P_NR_CARTAO"].Value = NumeroCartao;
                        comando.Parameters["@P_DT_ABERTURA"].Value = DateTime.Now;
                        comando.Parameters["@P_ST_MENORIDADE"].Value = CartaoMenor.Equals("1") ? "S" : "N";
                        comando.Parameters["@P_VL_LIMITECARTAO"].Value = vl_limite;
                        comando.Parameters["@P_ST_REGISTRO"].Value = "A";
                        return "5"; //Cartao Aberto com Mesa Padrao
                    }
                    else
                    {
                        System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@P_CD_EMPRESA"].Value = cd_empresa;
                        comando.Parameters["@P_ID_CARTAO"].Value = id_cartao;
                        comando.Parameters["@P_CD_CLIFOR"].Value = cd_cliente;
                        comando.Parameters["@P_NR_CARTAO"].Value = NumeroCartao;
                        comando.Parameters["@P_DT_ABERTURA"].Value = DateTime.Now;
                        comando.Parameters["@P_ST_MENORIDADE"].Value = CartaoMenor.Equals("1") ? "S" : "N";
                        comando.Parameters["@P_VL_LIMITECARTAO"].Value = vl_limite;
                        comando.Parameters["@P_ST_REGISTRO"].Value = "A";
                        comando.ExecuteNonQuery();
                        return "0"; //Cartao Aberto
                    }
                }
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                return "9";
            }//Erro Sistema
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }

        [WebMethod]
        public string ValidarCartao(string NumeroCartao)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            comando.CommandText = "select a.ID_Mesa, a.dt_abertura, " +
                                            "getdate() as dt_atual, b.DS_Mesa as ds_mesa, c.nm_clifor " +
                                            "from TB_RES_Cartao a " +
                                            "left outer join TB_RES_Mesa b " +
                                            "on a.ID_Mesa = b.ID_Mesa " +
                                            "left outer join TB_FIN_Clifor c " +
                                            "on a.CD_Clifor = c.CD_Clifor " +
                                            "where a.NR_Cartao = '" + NumeroCartao.Trim() + "' and isnull(a.ST_Registro, 'A') = 'A'";
            try
            {
                con.Open();
                comando.Connection = con;
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        DateTime dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                        DateTime dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
                        string id_mesa = string.Empty;
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Mesa")))
                            id_mesa = reader.GetInt32(reader.GetOrdinal("ID_Mesa")).ToString();
                        string ds_mesa = string.Empty;
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_mesa")))
                            ds_mesa = reader.GetString(reader.GetOrdinal("ds_mesa"));
                        //bool St_bloqueado = !reader.IsDBNull(reader.GetOrdinal("bloqueado"));
                        //if (St_bloqueado)
                        //    return "4";//Cartao Bloqueado
                        string nm_cliente = string.Empty;
                        if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                            nm_cliente = reader.GetString(reader.GetOrdinal("nm_clifor"));
                        ////Parametro Expirar Cartao
                        //fbCom.CommandText = "select expiracartao from paramsis";
                        //object obj = fbCom.ExecuteScalar();
                        //if (obj == null ? false : decimal.Parse(obj.ToString()) > 0)
                        //    if (dt_abertura.AddHours(Convert.ToDouble(obj.ToString())) < dt_atual)
                        //        return "2";//Cartao Expirado
                        //    else
                        //        return string.IsNullOrEmpty(id_mesa) ? "0-" + nm_cliente : "1-" + id_mesa + "-" + ds_mesa + "-" + nm_cliente;
                        //else
                            return string.IsNullOrEmpty(id_mesa) ? "0-" + nm_cliente : "1-" + id_mesa + "-" + ds_mesa + "-" + nm_cliente;
                    }
                    else
                    {
                        //Verificar se cartao rotativo
                        comando.CommandText = "select TP_Cartao from TB_RES_Config";
                        object obj = comando.ExecuteScalar();
                        if (obj == null ? false : obj.ToString().Equals("0"))
                        {
                            //Buscar Fone Consumidor Final
                            comando.CommandText = "select end.celular, a.nm_clifor " +
                                                "from TB_FIN_Clifor a " +
                                                "inner join TB_FIN_ENDERECO end " +
                                                "on end.cd_clifor = a.cd_clifor " +
                                                "inner join TB_RES_Config b " +
                                                "on a.CD_Clifor = b.CD_Clifor ";
                            reader = comando.ExecuteReader();
                            string nome = string.Empty;
                            string fone = string.Empty;
                            if (reader.HasRows)
                                if (reader.Read())
                                {
                                    
                                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                                        nome = reader.GetString(reader.GetOrdinal("nm_clifor"));
                                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                                        fone = reader.GetString(reader.GetOrdinal("celular"));
                                    
                                }
                            string ret = AbrirCartao(NumeroCartao, fone, "0", nome);
                            if (ret.Trim().Equals("0"))
                                return "0-" + nome.Trim();
                            else if (ret.Trim().Equals("5"))
                            {
                                //Buscar Mesa Cartao
                                comando.CommandText = "select top 1 ID_Mesa, DS_Mesa from TB_RES_Mesa";
                                string cod_mesa = string.Empty;
                                string ds_mesa = string.Empty;
                                reader = comando.ExecuteReader();
                                if(reader.HasRows)
                                    if (reader.Read())
                                    {
                                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Mesa")))
                                            cod_mesa = reader.GetInt32(reader.GetOrdinal("ID_Mesa")).ToString();
                                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Mesa")))
                                            ds_mesa = reader.GetString(reader.GetOrdinal("DS_Mesa"));
                                    }
                                return "1-" + cod_mesa + "-" + ds_mesa + "-";
                            }
                            else return "8-" + ret.Trim();
                        }
                        else return "3";//Cartao Fechado ou Inexistente
                    }
                }
                else
                {
                    //Verificar se cartao rotativo
                    comando.CommandText = "select TP_Cartao from TB_RES_Config";
                    object obj = comando.ExecuteScalar();
                    if (obj == null ? false : obj.ToString().Equals("0"))
                    {
                        //Buscar Fone Consumidor Final
                        comando.CommandText = "select end.celular, a.nm_clifor " +
                                            "from TB_FIN_Clifor a " +
                                            "inner join TB_FIN_ENDERECO end " +
                                            "on end.cd_clifor = a.cd_clifor " +
                                            "inner join TB_RES_Config b " +
                                            "on a.CD_Clifor = b.CD_Clifor ";
                        reader = comando.ExecuteReader();
                        string nome = string.Empty;
                        string fone = string.Empty;
                        if (reader.HasRows)
                            if (reader.Read())
                            {
                                
                                if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                                    nome = reader.GetString(reader.GetOrdinal("nm_clifor"));
                                if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                                    fone = reader.GetString(reader.GetOrdinal("celular"));
                                
                            }
                        string ret = AbrirCartao(NumeroCartao, fone, "0", nome);
                        if (ret.Trim().Equals("0"))
                            return "0-" + nome.Trim();
                        else if (ret.Trim().Equals("5"))
                        {
                            //Buscar Mesa Cartao
                            comando.CommandText = "select top 1 ID_Mesa, DS_Mesa from TB_RES_Mesa";
                            string cod_mesa = string.Empty;
                            string ds_mesa = string.Empty;
                            reader = comando.ExecuteReader();
                            if (reader.HasRows)
                                if (reader.Read())
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mesa")))
                                        cod_mesa = reader.GetInt32(reader.GetOrdinal("ID_Mesa")).ToString();
                                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mesa")))
                                        ds_mesa = reader.GetString(reader.GetOrdinal("DS_Mesa"));
                                }
                            return "1-" + cod_mesa + "-" + ds_mesa + "-";
                        }
                        else return "8-" + ret.Trim();
                    }
                    else return "3";//Cartao Fechado ou Inexistente
                }
            }
            catch { return "9"; }//Erro Sistema
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string ValidarCartao(string NumeroCartao)
        //{
        //    FbCommand fbCom = new FbCommand("select a.mesa, cast(a.databre + a.horabre as timestamp) as dt_abertura, " +
        //                                    "a.bloqueado, current_timestamp as dt_atual, b.descricao as ds_mesa, c.nome " +
        //                                    "from inicard a " +
        //                                    "left outer join mesas b " +
        //                                    "on a.mesa = b.mesa " +
        //                                    "left outer join cliente c " +
        //                                    "on a.codcliente = c.codigo " +
        //                                    "where a.codbarra = '" + NumeroCartao.Trim() + "' and a.status = 1");
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        FbDataReader reader = fbCom.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            if (reader.Read())
        //            {
        //                DateTime dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
        //                DateTime dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
        //                string id_mesa = string.Empty;
        //                if (!reader.IsDBNull(reader.GetOrdinal("mesa")))
        //                    id_mesa = reader.GetInt32(reader.GetOrdinal("mesa")).ToString();
        //                string ds_mesa = string.Empty;
        //                if (!reader.IsDBNull(reader.GetOrdinal("ds_mesa")))
        //                    ds_mesa = reader.GetString(reader.GetOrdinal("ds_mesa"));
        //                bool St_bloqueado = !reader.IsDBNull(reader.GetOrdinal("bloqueado"));
        //                if (St_bloqueado)
        //                    return "4";//Cartao Bloqueado
        //                string nm_cliente = string.Empty;
        //                if (!reader.IsDBNull(reader.GetOrdinal("nome")))
        //                    nm_cliente = reader.GetString(reader.GetOrdinal("nome"));
        //                //Parametro Expirar Cartao
        //                fbCom.CommandText = "select expiracartao from paramsis";
        //                object obj = fbCom.ExecuteScalar();
        //                if (obj == null ? false : decimal.Parse(obj.ToString()) > 0)
        //                    if (dt_abertura.AddHours(Convert.ToDouble(obj.ToString())) < dt_atual)
        //                        return "2";//Cartao Expirado
        //                    else
        //                        return string.IsNullOrEmpty(id_mesa) ? "0-" + nm_cliente : "1-" + id_mesa + "-" + ds_mesa + "-" + nm_cliente;
        //                else
        //                    return string.IsNullOrEmpty(id_mesa) ? "0-" + nm_cliente : "1-" + id_mesa + "-" + ds_mesa + "-" + nm_cliente;
        //            }
        //            else
        //            {
        //                //Verificar se cartao rotativo
        //                fbCom.CommandText = "select id_check from paramsis";
        //                object obj = fbCom.ExecuteScalar();
        //                if (obj == null ? false : obj.ToString().Equals("1"))
        //                {
        //                    //Buscar Fone Consumidor Final
        //                    fbCom.CommandText = "select fone, nome " +
        //                                        "from cliente a " +
        //                                        "inner join paramsis b " +
        //                                        "on a.codigo = b.clientemesa ";
        //                    reader = fbCom.ExecuteReader();
        //                    string nome = string.Empty;
        //                    string fone = string.Empty;
        //                    if (reader.HasRows)
        //                        if (reader.Read())
        //                        {

        //                            if (!reader.IsDBNull(reader.GetOrdinal("nome")))
        //                                nome = reader.GetString(reader.GetOrdinal("nome"));
        //                            if (!reader.IsDBNull(reader.GetOrdinal("fone")))
        //                                fone = reader.GetString(reader.GetOrdinal("fone"));

        //                        }
        //                    string ret = AbrirCartao(NumeroCartao, fone, "0", nome);
        //                    if (ret.Trim().Equals("0"))
        //                        return "0-" + nome.Trim();
        //                    else if (ret.Trim().Equals("5"))
        //                    {
        //                        //Buscar Mesa Cartao
        //                        fbCom.CommandText = "select first 1 codigo, descricao from mesas";
        //                        string cod_mesa = string.Empty;
        //                        string ds_mesa = string.Empty;
        //                        reader = fbCom.ExecuteReader();
        //                        if (reader.HasRows)
        //                            if (reader.Read())
        //                            {
        //                                if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
        //                                    cod_mesa = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
        //                                if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
        //                                    ds_mesa = reader.GetString(reader.GetOrdinal("descricao"));
        //                            }
        //                        return "1-" + cod_mesa + "-" + ds_mesa + "-";
        //                    }
        //                    else return "8-" + ret.Trim();
        //                }
        //                else return "3";//Cartao Fechado ou Inexistente
        //            }
        //        }
        //        else
        //        {
        //            //Verificar se cartao rotativo
        //            fbCom.CommandText = "select id_check from paramsis";
        //            object obj = fbCom.ExecuteScalar();
        //            if (obj == null ? false : obj.ToString().Equals("1"))
        //            {
        //                //Buscar Fone Consumidor Final
        //                fbCom.CommandText = "select fone, nome " +
        //                                    "from cliente a " +
        //                                    "inner join paramsis b " +
        //                                    "on a.codigo = b.clientemesa ";
        //                reader = fbCom.ExecuteReader();
        //                string nome = string.Empty;
        //                string fone = string.Empty;
        //                if (reader.HasRows)
        //                    if (reader.Read())
        //                    {

        //                        if (!reader.IsDBNull(reader.GetOrdinal("nome")))
        //                            nome = reader.GetString(reader.GetOrdinal("nome"));
        //                        if (!reader.IsDBNull(reader.GetOrdinal("fone")))
        //                            fone = reader.GetString(reader.GetOrdinal("fone"));

        //                    }
        //                string ret = AbrirCartao(NumeroCartao, fone, "0", nome);
        //                if (ret.Trim().Equals("0"))
        //                    return "0-" + nome.Trim();
        //                else if (ret.Trim().Equals("5"))
        //                {
        //                    //Buscar Mesa Cartao
        //                    fbCom.CommandText = "select first 1 codigo, descricao from mesas";
        //                    string cod_mesa = string.Empty;
        //                    string ds_mesa = string.Empty;
        //                    reader = fbCom.ExecuteReader();
        //                    if (reader.HasRows)
        //                        if (reader.Read())
        //                        {
        //                            if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
        //                                cod_mesa = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
        //                            if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
        //                                ds_mesa = reader.GetString(reader.GetOrdinal("descricao"));
        //                        }
        //                    return "1-" + cod_mesa + "-" + ds_mesa + "-";
        //                }
        //                else return "8-" + ret.Trim();
        //            }
        //            else return "3";//Cartao Fechado ou Inexistente
        //        }
        //    }
        //    catch { return "9"; }//Erro Sistema
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        public string FecharCartao(string NumeroCartao)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction t = null;
            try
            {
                con.Open();
                t = con.BeginTransaction();
                comando.Connection = con;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.Text;
                //Verificar cartao existe
                comando.CommandText = "select 1 from TB_RES_Cartao where NR_Cartao = '" + NumeroCartao.Trim() + "'";
                object obj = comando.ExecuteScalar();
                if (obj == null)
                    return "3";//Cartao Invalido
                ////Verificar cartao bloqueado
                //fbCom.CommandText = "select 1 from TB_RES_Cartao where NR_Cartao = '" + NumeroCartao.Trim() + "' and status = 1 and bloqueado is not null";
                //obj = fbCom.ExecuteScalar();
                //if (obj != null)
                //    return "4";//Cartao bloqueado
                //Codigo evento
                comando.CommandText = "select ID_Cartao from TB_RES_Cartao where NR_Cartao = '" + NumeroCartao.Trim() + "' and isnull(ST_Registro, 'A') = 'A'";
                obj = comando.ExecuteScalar();
                if (obj != null)
                {
                    comando.CommandText = "select 1 " +
                                        "from TB_RES_ItensPreVenda a " +
                                        "inner join TB_RES_PreVenda b " +
                                        "on a.cd_empresa = b.cd_empresa " +
                                        "and a.id_prevenda = b.id_prevenda " +
                                        "where b.ID_Cartao = " + obj.ToString() + " " +
                                        "and not exists(select 1 from TB_RES_ItensPreVenda_X_ItensCupom x " +
                                        "           where x.cd_empresa = a.cd_empresa " +
                                        "           and x.id_prevenda = a.id_prevenda " +
                                        "           and x.id_item = a.id_item ) ";
                    object obj_itens = comando.ExecuteScalar();

                    if (obj_itens != null)
                        return "2";//Cartao possui venda em aberto
                    else
                    {
                        comando.CommandText = "update TB_RES_Cartao set " +
                                            "DT_Fechamento = GETDATE() " +
                                            "ST_Registro = 'F' " +
                                            "where ID_Cartao = " + obj.ToString();

                        comando.ExecuteNonQuery();
                        return "0";//Cartao fechado
                    }
                }
                else return "1";//Cartao fechado
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                return "9";
            }//Erro sistema
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string FecharCartao(string NumeroCartao)
        //{
        //    FbCommand fbCom = new FbCommand();
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        //Verificar cartao existe
        //        fbCom.CommandText = "select 1 from inicard where codbarra = '" + NumeroCartao.Trim() + "'";
        //        object obj = fbCom.ExecuteScalar();
        //        if (obj == null)
        //            return "3";//Cartao Invalido
        //        //Verificar cartao bloqueado
        //        fbCom.CommandText = "select 1 from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1 and bloqueado is not null";
        //        obj = fbCom.ExecuteScalar();
        //        if (obj != null)
        //            return "4";//Cartao bloqueado
        //        //Codigo evento
        //        fbCom.CommandText = "select codigo from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1";
        //        obj = fbCom.ExecuteScalar();
        //        if (obj != null)
        //        {
        //            fbCom.CommandText = "select 1 " +
        //                                "from movimento a " +
        //                                "inner join produtos b " +
        //                                "on a.codpro = b.codigo " +
        //                                "where a.codevento = " + obj.ToString() + " " +
        //                                "and a.ativo = 1 " +
        //                                "group by b.descricao, a.vlrpro ";
        //            object obj_itens = fbCom.ExecuteScalar();

        //            if (obj_itens != null)
        //                return "2";//Cartao possui venda em aberto
        //            else
        //            {
        //                string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        //                fbCom.CommandText = "update inicard set " +
        //                                    "datafecha = '" + data.Substring(3, 2) + "-" + data.Substring(0, 2) + "-" + data.Substring(6, 4) + "', " +
        //                                    "horafecha = '" + data.Substring(11, 8) + "', " +
        //                                    "horasai = '" + data.Substring(11, 8) + "', " +
        //                                    "status = 0 " +
        //                                    "where codigo = " + obj.ToString();
                        
        //                fbCom.ExecuteNonQuery();
        //                return "0";//Cartao fechado
        //            }
        //        }
        //        else return "1";//Cartao fechado
        //    }
        //    catch { return "9"; }//Erro sistema
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        public string ValidarMesa(string Codigo)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select descricao from mesas where mesa = '" + Codigo.Trim() + "'");
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            
            try
            {
                con.Open();
                object obj = comando.ExecuteScalar();
                return obj == null ? "3" : Codigo.Trim() + "-" + obj.ToString();
            }
            catch { return "9"; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string ValidarMesa(string Codigo)
        //{
        //    FbCommand fbCom = new FbCommand("select descricao from mesas where mesa = '" + Codigo.Trim() + "'");
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        object obj = fbCom.ExecuteScalar();
        //        return obj == null ? "3" : Codigo.Trim() + "-" + obj.ToString();
        //    }
        //    catch { return "9"; }
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        public string BuscarProduto(string Codigo, string NumeroCartao)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("select ST_MenorIdade from TB_RES_Cartao where codbarra = '" + NumeroCartao.Trim() + "' and isnull(ST_Registro, 'A') = 'A' ");/* and coalesce(bloqueado, 0) <> 1");*/
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Conexao);
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(sql.ToString(), con);
            try
            {
                //Abrir conexao
                con.Open();
                object obj = comando.ExecuteScalar();
                bool st_cartaomenor = obj == null ? false : obj.ToString().Trim().Equals("S");
                //Buscar Tabela Preco
                string cd_tabelapreco = string.Empty;
                comando.CommandText = "select top 1 CD_TabelaPreco TB_RES_Config ";
                cd_tabelapreco = comando.ExecuteScalar().ToString();
                //Buscar Empresa
                string cd_empresa = string.Empty;
                comando.CommandText = "select top 1 CD_Empresa TB_RES_Config ";
                cd_empresa = comando.ExecuteScalar().ToString();
                //Buscar Produto
                comando.CommandText = "select CD_Produto, DS_Produto, vlrvenda, vendamenor, porta, coalesce(combinado, 0) as combinado, ativo " +
                                    "from TB_EST_Produto " +
                                    "where primario = 0 " +
                                    "and codigo = '" + Codigo.Trim() + "'";
                //Executar comando
                System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                TProduto rProd = null;
                while (reader.Read())
                {
                    rProd = new TProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        rProd.Cd_produto = reader.GetInt32(reader.GetOrdinal("CD_Produto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        rProd.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vlrvenda")))
                        rProd.Vl_venda = reader.GetFloat(reader.GetOrdinal("vlrvenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vendamenor")))
                        rProd.ST_NotVendaMenor = reader.GetInt32(reader.GetOrdinal("vendamenor")).Equals(1);
                    if (!reader.IsDBNull(reader.GetOrdinal("porta")))
                        rProd.Porta = reader.GetString(reader.GetOrdinal("porta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("combinado")))
                        rProd.Combinado = reader.GetInt32(reader.GetOrdinal("combinado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ativo")))
                        rProd.Ativo = reader.GetInt16(reader.GetOrdinal("ativo"));
                }
                return rProd == null ? "3" : rProd.Ativo.Equals(0) ? "5" : st_cartaomenor && rProd.ST_NotVendaMenor ? "4" : 
                                                                                              rProd.Cd_produto.Trim() + "-" +
                                                                                              rProd.Ds_produto.Trim() + "-" +
                                                                                              rProd.Vl_venda.ToString("N2", new System.Globalization.CultureInfo("en-US")) + "-" +
                                                                                              rProd.Porta.Trim() + "-" +
                                                                                              rProd.Combinado.ToString();
            }
            catch { return "9"; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //[WebMethod]
        //public string BuscarProduto(string Codigo, string NumeroCartao)
        //{
        //    FbCommand fbCom = new FbCommand();
        //    try
        //    {
        //        TConexao.Ativar(true);
        //        fbCom.Connection = TConexao.FbCon;
        //        fbCom.CommandText = "select cartaomenor from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1 and coalesce(bloqueado, 0) <> 1";
        //        object obj = fbCom.ExecuteScalar();
        //        bool st_cartaomenor = obj == null ? false : obj.ToString().Trim().Equals("1");
        //        fbCom.CommandText = "select codigo, descricao, vlrvenda, vendamenor, porta, coalesce(combinado, 0) as combinado, ativo " +
        //                            "from produtos " +
        //                            "where primario = 0 " +
        //                            "and codigo = '" + Codigo.Trim() + "'";
        //        FbDataReader reader = fbCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        TProduto rProd = null;
        //        while (reader.Read())
        //        {
        //            rProd = new TProduto();
        //            if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
        //                rProd.Cd_produto = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
        //            if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
        //                rProd.Ds_produto = reader.GetString(reader.GetOrdinal("descricao"));
        //            if (!reader.IsDBNull(reader.GetOrdinal("vlrvenda")))
        //                rProd.Vl_venda = reader.GetFloat(reader.GetOrdinal("vlrvenda"));
        //            if (!reader.IsDBNull(reader.GetOrdinal("vendamenor")))
        //                rProd.ST_NotVendaMenor = reader.GetInt32(reader.GetOrdinal("vendamenor")).Equals(1);
        //            if (!reader.IsDBNull(reader.GetOrdinal("porta")))
        //                rProd.Porta = reader.GetString(reader.GetOrdinal("porta"));
        //            if (!reader.IsDBNull(reader.GetOrdinal("combinado")))
        //                rProd.Combinado = reader.GetInt32(reader.GetOrdinal("combinado"));
        //            if (!reader.IsDBNull(reader.GetOrdinal("ativo")))
        //                rProd.Ativo = reader.GetInt16(reader.GetOrdinal("ativo"));
        //        }
        //        return rProd == null ? "3" : rProd.Ativo.Equals(0) ? "5" : st_cartaomenor && rProd.ST_NotVendaMenor ? "4" :
        //                                                                                      rProd.Cd_produto.Trim() + "-" +
        //                                                                                      rProd.Ds_produto.Trim() + "-" +
        //                                                                                      rProd.Vl_venda.ToString("N2", new System.Globalization.CultureInfo("en-US")) + "-" +
        //                                                                                      rProd.Porta.Trim() + "-" +
        //                                                                                      rProd.Combinado.ToString();
        //    }
        //    catch { return "9"; }
        //    finally
        //    {
        //        if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
        //            TConexao.FbCon.Close();
        //    }
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarSabores(string Cd_produto)
        {
            string sql = "select a.codigo, a.descricao " +
                         "from sabor a " +
                         "inner join produtos b " +
                         "on a.cd_grupo = b.cd_grupo " +
                         "where b.codigo = '" + Cd_produto.Trim() + "'";
            FbCommand fbCom = new FbCommand(sql);
            try
            {
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                FbDataReader reader = fbCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TSabor> lSabor = new List<TSabor>();
                while (reader.Read())
                {
                    TSabor reg = new TSabor();
                    if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
                        reg.Codigo = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
                        reg.Sabor = reader.GetString(reader.GetOrdinal("descricao"));

                    lSabor.Add(reg);
                }
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lSabor);
            }
            catch { return "9"; }
            finally
            { TConexao.Ativar(false); }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public string BuscarObservacao(string Cd_produto)
        {
            string sql = "select a.codigo, a.observacao " +
                         "from tb_observa a " +
                         "inner join produtos b " +
                         "on a.codgrupo = b.cd_grupo " +
                         "where b.codigo = '" + Cd_produto.Trim() + "'";
            FbCommand fbCom = new FbCommand(sql);
            try
            {
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                FbDataReader reader = fbCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<TObservacao> lObs = new List<TObservacao>();
                while (reader.Read())
                {
                    TObservacao reg = new TObservacao();
                    if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
                        reg.Codigo = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("observacao")))
                        reg.Observa = reader.GetString(reader.GetOrdinal("observacao"));
                    lObs.Add(reg);
                }
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lObs);
            }
            catch { return "9"; }
            finally
            { TConexao.Ativar(false); }
        }

        [WebMethod]
        public string FecharPedido(string NumeroCartao,
                                   string CodigoVendedor,
                                   string NumeroMesa,
                                   string Itens)
        {
            FbTransaction fbTran = null;
            try
            {
                List<TProduto> lProdutos = new List<TProduto>();
                string[] lItens = Itens.Split(new char[] { ';' });
                foreach (string it in lItens)
                {
                    string[] lIt = it.Split(new char[] { '-' });
                    TProduto rProd = new TProduto();
                    rProd.Cd_produto = lIt[0];
                    rProd.Ds_produto = lIt[1];
                    rProd.Quantidade = Convert.ToDouble(lIt[2]);
                    rProd.Vl_venda = Convert.ToDouble(lIt[3]);
                    rProd.Porta = lIt[4];
                    rProd.Observacao = lIt[5];
                    lProdutos.Add(rProd);
                }
                TConexao.Ativar(true);
                fbTran = TConexao.FbCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                FbCommand fbCom = new FbCommand();
                fbCom.Connection = TConexao.FbCon;
                fbCom.Transaction = fbTran;
                fbCom.CommandType = System.Data.CommandType.Text;
                if (!string.IsNullOrEmpty(NumeroMesa))
                {
                    //Update tabela inicard com o numero da mesa
                    fbCom.CommandText = "update inicard set mesa = '" + NumeroMesa.Trim() + "' " +
                                        "where codbarra = '" + NumeroCartao.Trim() + "' " +
                                        "and status = 1 " +
                                        "and coalesce(bloqueado, 0) <> 1";
                    fbCom.ExecuteNonQuery();
                }
                //Buscar codigo interno do cartao
                fbCom.CommandText = "select codigo from inicard where codbarra = '" + NumeroCartao.Trim() + "' " +
                                    "and status = 1 and coalesce(bloqueado, 0) <> 1";
                object obj = fbCom.ExecuteScalar();
                string codevento = string.Empty;
                if (obj != null)
                    codevento = obj.ToString();
                else return "98";
                //Buscar limite credito do cartao
                double vl_limite = 0;
                fbCom.CommandText = "select limitecred from inicard where codbarra = '" + NumeroCartao.Trim() + "' " +
                                    "and status = 1 and coalesce(bloqueado, 0) <> 1";
                obj = fbCom.ExecuteScalar();
                if (obj != null)
                    vl_limite = Convert.ToDouble(obj.ToString());
                if (vl_limite > 0)
                {
                    //Buscar valor consumido no cartao
                    fbCom.CommandText = "select coalesce(sum(qta * vlrpro), 0) " +
                                        "from movimento " +
                                        "where codbarra = '" + NumeroCartao.Trim() + "' " +
                                        "and codevento = '" + codevento.Trim() + "' " +
                                        "and ativo = 1";
                    obj = fbCom.ExecuteScalar();
                    if (obj != null)
                        if ((lProdutos.Sum(p => p.Vl_subtotal) + Convert.ToDouble(obj.ToString())) > vl_limite)
                            return "2";//Venda Fora Limite Credito
                }
                //Buscar canal
                string canal = string.Empty;
                fbCom.CommandText = "select first 1 canal from terminal where tipo = '7'";
                obj = fbCom.ExecuteScalar();
                if (obj != null)
                    canal = obj.ToString();
                else return "99";
                lProdutos.ForEach(p =>
                    {
                        fbCom.CommandText = "insert into movimento(codevento, codbarra, codpro, " +
                                            "qta, vlrpro, canal, data, hora, ativo, tp_movimento, " +
                                            "id_vend, portaimp, obs)values(@codevento, @codbarra, @codpro, " +
                                            "@qta, @vlrpro, @canal, @data, @hora, @ativo, @tp_movimento, " +
                                            "@id_vend, @portaimp, @obs)";
                        fbCom.Parameters.Clear();
                        fbCom.Parameters.Add("@codevento", codevento);
                        fbCom.Parameters.Add("@codbarra", NumeroCartao);
                        fbCom.Parameters.Add("@codpro", p.Cd_produto);
                        fbCom.Parameters.Add("@qta", p.Quantidade);
                        fbCom.Parameters.Add("@vlrpro", p.Vl_venda);
                        fbCom.Parameters.Add("@canal", canal);
                        fbCom.Parameters.Add("@data", DateTime.Now.Date);
                        fbCom.Parameters.Add("@hora", DateTime.Now.TimeOfDay);
                        fbCom.Parameters.Add("@ativo", "1");
                        fbCom.Parameters.Add("@tp_movimento", "S");
                        fbCom.Parameters.Add("@id_vend", CodigoVendedor);
                        fbCom.Parameters.Add("@portaimp", p.Porta);
                        fbCom.Parameters.Add("@obs", p.Observacao);
                        fbCom.ExecuteNonQuery();
                    });
                fbTran.Commit();
                return "0";
            }
            catch 
            {
                if (fbTran != null)
                    fbTran.Rollback();
                return "9"; 
            }
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }

        [WebMethod]
        public string ReceberPedido(string NumeroCartao,
                                    string Login,
                                    string lItens, 
                                    string Vl_receber,
                                    string Portador)
        {
            FbTransaction fbTran = null;
            try
            {
                List<TProduto> lProd = new List<TProduto>();
                TConexao.Ativar(true);
                fbTran = TConexao.FbCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                FbCommand fbCom = new FbCommand();
                fbCom.Connection = TConexao.FbCon;
                fbCom.Transaction = fbTran;
                fbCom.CommandType = System.Data.CommandType.Text;
                //Gravar IniCard
                fbCom.CommandText = "select codigo from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1";
                object obj = fbCom.ExecuteScalar();
                if (obj != null)
                {
                    fbCom.CommandText = "select codigo from ABREFECHACAIXA a where login = '" + Login.Trim() + "' and status = 1";
                    object obj_caixa = fbCom.ExecuteScalar();
                    if (obj_caixa != null)
                    {
                        //Buscar Lista de Itens
                        fbCom.CommandText = "select a.codmov, a.qta, a.vlrpro, a.pago " +
                                                "from movimento a " +
                                                "where a.codmov in(" + lItens + ")" +
                                                "and a.ativo = 1";
                        FbDataReader reader = fbCom.ExecuteReader();
                        while (reader.Read())
                        {
                            TProduto reg = new TProduto();
                            if (!reader.IsDBNull(reader.GetOrdinal("codmov")))
                                reg.Cd_item = reader.GetInt32(reader.GetOrdinal("codmov")).ToString();
                            if (!reader.IsDBNull(reader.GetOrdinal("qta")))
                                reg.Quantidade = Math.Round(reader.GetFloat(reader.GetOrdinal("qta")), 3);
                            if (!reader.IsDBNull(reader.GetOrdinal("vlrpro")))
                                reg.Vl_venda = Math.Round(reader.GetFloat(reader.GetOrdinal("vlrpro")), 2);
                            if (!reader.IsDBNull(reader.GetOrdinal("pago")))
                                reg.Vl_pago = Math.Round(reader.GetFloat(reader.GetOrdinal("pago")), 2);

                            lProd.Add(reg);
                        }
                        double saldo = double.Parse(Vl_receber) / 100;
                        foreach (TProduto p in lProd)
                        {
                            if (saldo > 0)
                            {
                                fbCom.CommandText = "update movimento set pago = coalesce(pago, 0) + @pago, codcaixa = @codcaixa, ativo = @ativo where codmov = @codmov";
                                fbCom.Parameters.Clear();
                                fbCom.Parameters.Add("@pago", saldo > p.Vl_subtotal ? p.Vl_subtotal : saldo);
                                fbCom.Parameters.Add("@codcaixa", obj_caixa.ToString());
                                fbCom.Parameters.Add("@codmov", p.Cd_item);
                                fbCom.Parameters.Add("@ativo", saldo >= p.Vl_subtotal ? "0" : "1");
                                fbCom.ExecuteNonQuery();

                                saldo -= saldo > p.Vl_subtotal ? p.Vl_subtotal : saldo;
                            }
                            else break;
                        }
                        //Gravar pagtoParcial

                        fbCom.CommandText = "insert into pagtoparcial(codcaixa, codevento, forma, data, hora, valor, desconto, statusreg)values(" +
                                            "@codcaixa, @codevento, @forma, @data, @hora, @valor, @desconto, @statusreg)";
                        fbCom.Parameters.Clear();
                        fbCom.Parameters.Add("@codcaixa", obj_caixa.ToString());
                        fbCom.Parameters.Add("@codevento", obj.ToString());
                        fbCom.Parameters.Add("@forma", Portador);
                        fbCom.Parameters.Add("@data", DateTime.Now.Date);
                        fbCom.Parameters.Add("@hora", DateTime.Now.TimeOfDay);
                        fbCom.Parameters.Add("@valor", decimal.Divide(decimal.Parse(Vl_receber), 100));
                        fbCom.Parameters.Add("@desconto", decimal.Zero);
                        fbCom.Parameters.Add("@statusreg", "1");
                        fbCom.ExecuteNonQuery();
                        //Alterar IniCard
                        fbCom.CommandText = "select coalesce(count(*), 0) " +
                                            "from movimento a " +
                                            "inner join produtos b " +
                                            "on a.codpro = b.codigo " +
                                            "where a.codevento = " + obj.ToString() + " " +
                                            "and a.ativo = 1";
                        object obj_total = fbCom.ExecuteScalar();
                        fbCom.CommandText = "update inicard set codevento = @codevento, datafecha = @data, horafecha = @hora, total = coalesce(total, 0) + @valor, " +
                                            "desconto = 0, status = @status, ativo = @ativo where codbarra = @codbarra and status = 1";
                        fbCom.Parameters.Clear();
                        fbCom.Parameters.Add("@codevento", obj_caixa.ToString());
                        fbCom.Parameters.Add("@data", DateTime.Now.Date);
                        fbCom.Parameters.Add("@hora", DateTime.Now.TimeOfDay);
                        fbCom.Parameters.Add("@valor", decimal.Divide(decimal.Parse(Vl_receber), 100));
                        fbCom.Parameters.Add("@status", obj_total == null ? "0" : decimal.Parse(obj_total.ToString()).Equals(decimal.Zero) ? "0" : "1");
                        fbCom.Parameters.Add("@ativo", "0");
                        fbCom.Parameters.Add("@codbarra", NumeroCartao);
                        fbCom.ExecuteNonQuery();

                        fbTran.Commit();
                        return "0";//Recebido com sucesso
                    }
                    else return "7";//Login não possui caixa aberto
                }
                else return "8";//Cartão não encontrado
            }
            catch
            {
                if (fbTran != null)
                    fbTran.Rollback();
                return "9";
            }
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                {
                    TConexao.FbCon.Close();
                    TConexao.FbCon.Dispose();
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultaItensPedido(string NumeroCartao)
        {
            FbCommand fbCom = new FbCommand();
            try
            {
                List<TProduto> lProd = new List<TProduto>();
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                //Codigo evento
                fbCom.CommandText = "select codigo from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1";
                object obj = fbCom.ExecuteScalar();
                if(obj != null)
                {
                    fbCom.CommandText = "select a.codmov, b.descricao, a.qta, a.vlrpro, a.pago, a.hora " +
                                        "from movimento a " +
                                        "inner join produtos b " +
                                        "on a.codpro = b.codigo " +
                                        "where a.codevento = " + obj.ToString() + " " +
                                        "and a.ativo = 1";
                    FbDataReader reader = fbCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    
                    while (reader.Read())
                    {
                        TProduto reg = new TProduto();
                        if (!reader.IsDBNull(reader.GetOrdinal("codmov")))
                            reg.Cd_item = reader.GetInt32(reader.GetOrdinal("codmov")).ToString();
                        if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
                            reg.Ds_produto = reader.GetString(reader.GetOrdinal("descricao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("qta")))
                            reg.Quantidade = Math.Round(reader.GetFloat(reader.GetOrdinal("qta")), 3);
                        if (!reader.IsDBNull(reader.GetOrdinal("vlrpro")))
                            reg.Vl_venda = Math.Round(reader.GetFloat(reader.GetOrdinal("vlrpro")), 2);
                        if (!reader.IsDBNull(reader.GetOrdinal("pago")))
                            reg.Vl_pago = Math.Round(reader.GetFloat(reader.GetOrdinal("pago")), 2);
                        if (!reader.IsDBNull(reader.GetOrdinal("hora")))
                            reg.Hora = ((TimeSpan)reader.GetValue(reader.GetOrdinal("hora"))).ToString();
                        lProd.Add(reg);
                    }
                }
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lProd);
            }
            catch { return "9"; }
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultaPortador()
        {
            FbCommand fbCom = new FbCommand();
            try
            {
                List<TPortador> lPort = new List<TPortador>();
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                //Codigo evento
                fbCom.CommandText = "select codigo, descricao from formapagamento where tipo > 0";
                FbDataReader reader = fbCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    TPortador reg = new TPortador();
                    if (!reader.IsDBNull(reader.GetOrdinal("codigo")))
                        reg.Id_portador = reader.GetInt32(reader.GetOrdinal("codigo")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("descricao")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("descricao"));
                    lPort.Add(reg);
                }
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lPort);
            }
            catch { return "9"; }
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }

        [WebMethod]
        public string AlterarMesa(string NumeroCartao, string Mesa)
        {
            FbCommand fbCom = new FbCommand();
            try
            {
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                fbCom.CommandText = "update inicard set " +
                                    "mesa = " + Mesa + " " +
                                    "where codbarra = '" + NumeroCartao.Trim() + "' and status = 1";
                fbCom.ExecuteNonQuery();
                return "0";
            }
            catch { return "9"; }//Erro Sistema
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }

        [WebMethod]
        public string CancelarItem(string NumeroCartao, string Cd_item)
        {
            FbCommand fbCom = new FbCommand();
            try
            {
                TConexao.Ativar(true);
                fbCom.Connection = TConexao.FbCon;
                //Codigo evento
                fbCom.CommandText = "select codigo from inicard where codbarra = '" + NumeroCartao.Trim() + "' and status = 1";
                object obj = fbCom.ExecuteScalar();
                if (obj != null)
                {
                    fbCom.CommandText = "update movimento set " +
                                        "tp_movimento = 'C', " +
                                        "ativo = 5 " +
                                        "where codmov = " + Cd_item + " " +
                                        "and codevento = " + obj.ToString();
                    fbCom.ExecuteNonQuery();
                    return "0";
                }
                else return "1";
            }
            catch { return "9"; }
            finally
            {
                if (TConexao.FbCon.State == System.Data.ConnectionState.Open)
                    TConexao.FbCon.Close();
            }
        }
    }
}
