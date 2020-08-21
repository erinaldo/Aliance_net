using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario : List<TRegistro_CadUsuario>
    { }

    public class TRegistro_CadUsuario
    {

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Nome_usuario { get; set; }
        private string tp_registro;

        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                tipo_registro = value.Trim().ToUpper().Equals("U") ? "USUARIO" : value.Trim().ToUpper().Equals("G") ? "GRUPO" : string.Empty;
            }
        }
        private string tipo_registro;

        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                tp_registro = value.Trim().ToUpper().Equals("USUARIO") ? "U" : value.Trim().ToUpper().Equals("GRUPO") ? "G" : string.Empty;
            }
        }
        private string st_expirarsenha;

        public string St_ExpirarSenha
        {
            get { return st_expirarsenha; }
            set
            {
                st_expirarsenha = value;
                st_expirarsenhabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_expirarsenhabool;

        public bool St_expirarsenhabool
        {
            get { return st_expirarsenhabool; }
            set
            {
                st_expirarsenhabool = value;
                st_expirarsenha = value ? "S" : "N";
            }
        }

        public decimal Qt_DiasExpirar { get; set; }

        public string St_Registro { get; set; }
        public string Status
        {
            get
            {
                if (St_Registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_Registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }

        public string Email_padrao
        { get; set; }
        private DateTime? dt_altsenha;

        public DateTime? Dt_altsenha
        {
            get { return dt_altsenha; }
            set
            {
                dt_altsenha = value;
                dt_altsenhastring = value.ToString();
            }
        }
        private string dt_altsenhastring;
        public string Dt_altsenhastring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_altsenhastring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_altsenhastring = value;
                try
                {
                    dt_altsenha = Convert.ToDateTime(value);
                }
                catch
                { dt_altsenha = null; }
            }
        }

        private string st_AlterarSenha;

        public string St_AlterarSenha
        {
            get { return st_AlterarSenha; }
            set
            {
                st_AlterarSenha = value;
                st_alterarsenhabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_alterarsenhabool;

        public bool St_alterarsenhabool
        {
            get { return st_alterarsenhabool; }
            set
            {
                st_alterarsenhabool = value;
                st_AlterarSenha = value ? "S" : "N";
            }
        }

        public System.Drawing.Color Cor_1
        { get; set; }

        public System.Drawing.Color Cor_2
        { get; set; }

        public System.Drawing.Color Cor_3
        { get; set; }

        public string Login_BI
        { get; set; }

        public string Senha_BI
        { get; set; }
        private string st_loginPDV;

        public string St_loginPDV
        {
            get { return st_loginPDV; }
            set
            {
                st_loginPDV = value;
                st_loginPDVbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_loginPDVbool;

        public bool St_loginPDVbool
        {
            get { return st_loginPDVbool; }
            set
            {
                st_loginPDVbool = value;
                st_loginPDV = value ? "S" : "N";
            }
        }

        public bool St_processar
        { get; set; }


        public TList_CadAcesso lAcesso
        { get; set; }

        public TList_CadUsuario_Grupo lGrupo
        { get; set; }

        public TList_CadUsuario_Grupo lGrupoDel
        { get; set; }

        public TList_CadUsuario_Empresa lEmpresa
        { get; set; }

        public TList_CadUsuario_Empresa lEmpresaDel
        { get; set; }

        public TList_CadUsuarioxTerminal lTerminal
        { get; set; }

        public TList_CadUsuarioxTerminal lTerminalDel
        { get; set; }

        public TList_CadUsuario_TipoPesagem lPesagem
        { get; set; }

        public TList_CadUsuario_TipoPesagem lPesagemDel
        { get; set; }

        public TList_CadUsuario_CFGPedido lPedido
        { get; set; }

        public TList_CadUsuario_CFGPedido lPedidoDel
        { get; set; }

        public TList_Usuario_ContaGer lContaGer
        { get; set; }

        public TList_Usuario_ContaGer lContaGerDel
        { get; set; }

        public TList_Usuario_TpRequisicao lTpRequisicao
        { get; set; }

        public TList_Usuario_TpRequisicao lTpRequisicaoDel
        { get; set; }

        public TList_Usuario_TpDuplicata lTpDuplicata
        { get; set; }

        public TList_Usuario_TpDuplicata lTpDupDel
        { get; set; }

        public TList_Usuario_RegraEspecial lRegra
        { get; set; }

        public TList_Usuario_RegraEspecial lRegraDel
        { get; set; }

        public Estoque.Cadastros.TList_CadTpProduto lTpProduto {get; set;}

        public CamadaDados.Faturamento.Cadastros.TList_CadEtapa lEtapaPed
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_CadEtapa lEtapaPedDel
        { get; set; }
        public TRegistro_CadUsuario()
        {
            this.lEtapaPed = new CamadaDados.Faturamento.Cadastros.TList_CadEtapa();
            this.lEtapaPedDel = new CamadaDados.Faturamento.Cadastros.TList_CadEtapa();
            this.lAcesso = new TList_CadAcesso();
            this.lGrupo = new TList_CadUsuario_Grupo();
            this.lGrupoDel = new TList_CadUsuario_Grupo();
            this.lEmpresa = new TList_CadUsuario_Empresa();
            this.lEmpresaDel = new TList_CadUsuario_Empresa();
            this.lTerminal = new TList_CadUsuarioxTerminal();
            this.lTerminalDel = new TList_CadUsuarioxTerminal();
            this.lPesagem = new TList_CadUsuario_TipoPesagem();
            this.lPesagemDel = new TList_CadUsuario_TipoPesagem();
            this.lPedido = new TList_CadUsuario_CFGPedido();
            this.lPedidoDel = new TList_CadUsuario_CFGPedido();
            this.lContaGer = new TList_Usuario_ContaGer();
            this.lContaGerDel = new TList_Usuario_ContaGer();
            this.lRegra = new TList_Usuario_RegraEspecial();
            this.lRegraDel = new TList_Usuario_RegraEspecial();
            this.lTpRequisicao = new TList_Usuario_TpRequisicao();
            this.lTpRequisicaoDel = new TList_Usuario_TpRequisicao();
            this.lTpDuplicata = new TList_Usuario_TpDuplicata();
            this.lTpDupDel = new TList_Usuario_TpDuplicata();
            this.St_processar = false;

            this.Login = string.Empty;
            this.Senha = string.Empty;
            this.Nome_usuario = string.Empty;
            this.tp_registro = string.Empty;
            this.tipo_registro = string.Empty;
            this.st_expirarsenha = string.Empty;
            this.st_expirarsenhabool = false;
            this.Qt_DiasExpirar = 0;
            this.St_Registro = "A";
            this.dt_altsenha = null;
            this.dt_altsenhastring = string.Empty;
            this.Email_padrao = string.Empty;
            this.st_AlterarSenha = string.Empty;
            this.st_alterarsenhabool = false;
            this.Login_BI = string.Empty;
            this.Senha_BI = string.Empty;
            this.st_loginPDV = "N";
            this.st_loginPDVbool = false;
            this.Cor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
                        ((int)(((byte)(169)))),
                        ((int)(((byte)(212)))),
                        ((int)(((byte)(121)))));
            this.Cor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
                        ((int)(((byte)(125)))),
                        ((int)(((byte)(199)))),
                        ((int)(((byte)(212)))));
            this.Cor_3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
                        ((int)(((byte)(183)))),
                        ((int)(((byte)(182)))),
                        ((int)(((byte)(181)))));
        }
    }

    public class TCD_CadUsuario : TDataQuery
    {
        public TCD_CadUsuario()
        { }

        public TCD_CadUsuario(BancoDados.TObjetoBanco banco)
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
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Login, a.Senha, a.st_loginPDV, ");
                sql.AppendLine("a.Nome_usuario, a.Tp_Registro, a.ST_ExpirarSenha, a.QT_diasExpirar,");
                sql.AppendLine("a.DT_AltSenha, a.st_registro, a.email_padrao, a.ST_AlterarSenha, ");
                sql.AppendLine("a.cor_1, a.cor_2, a.cor_3, a.login_BI, a.senha_BI ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario a ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            return sql.ToString();
        }

        public DataTable BuscaAcessoMenu(string vLogin)
        {
            StringBuilder sql;

            sql = new StringBuilder();
            // PARA MASTER RETORNA O MENU INTEIRO
            sql.AppendLine("Select distinct A.id_menu, A.DS_MENU, A.NIVEL , A.NM_MODULO, A.NM_CLASSE, A.TP_EVENTO, ");
            sql.AppendLine("a.id_menuraiz, a.id_report, a.cd_modulo, a.st_menuweb ");
            sql.AppendLine("From TB_DIV_MENU A ");

            if (vLogin != "MASTER" && vLogin != "DESENV")
            {
                sql.AppendLine(" INNER JOIN TB_DIV_Acesso B ");
                sql.AppendLine(" ON A.ID_MENU = B.ID_MENU ");
                sql.AppendLine("WHERE (B.Login = '" + vLogin + "')OR");
                sql.AppendLine("(EXISTS(SELECT 1 FROM TB_DIV_USUARIO_X_GRUPOS X ");
                sql.AppendLine("WHERE X.LOGINGRP = B.LOGIN AND X.LOGINUSR = '" + vLogin + "'))");
            }
            sql.AppendLine("ORDER BY A.ID_MENU");
            return ExecutarBusca(sql.ToString(), null);
        }

        public TList_CadUsuario Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario lista = new TList_CadUsuario();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadUsuario cadUser = new TRegistro_CadUsuario();
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        cadUser.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                        cadUser.Senha = reader.GetString(reader.GetOrdinal("senha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                        cadUser.Nome_usuario = reader.GetString(reader.GetOrdinal("nome_usuario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        cadUser.St_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExpirarSenha")))
                        cadUser.St_ExpirarSenha = reader.GetString(reader.GetOrdinal("ST_ExpirarSenha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_AltSenha")))
                        cadUser.Dt_altsenha = reader.GetDateTime(reader.GetOrdinal("DT_AltSenha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email_padrao")))
                        cadUser.Email_padrao = reader.GetString(reader.GetOrdinal("email_padrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_alterarSenha")))
                        cadUser.St_AlterarSenha = reader.GetString(reader.GetOrdinal("st_alterarSenha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        cadUser.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login_BI")))
                        cadUser.Login_BI = reader.GetString(reader.GetOrdinal("login_BI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("senha_BI")))
                        cadUser.Senha_BI = reader.GetString(reader.GetOrdinal("senha_BI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_loginPDV")))
                        cadUser.St_loginPDV = reader.GetString(reader.GetOrdinal("st_loginPDV"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cor_1")))
                    {
                        if (reader.GetString(reader.GetOrdinal("cor_1")).Trim().Length.Equals(12))
                        {
                            string aux = reader.GetString(reader.GetOrdinal("cor_1"));
                            cadUser.Cor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(0, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(3, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(6, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(9, 3)))))));
                        }
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cor_2")))
                    {
                        if (reader.GetString(reader.GetOrdinal("cor_2")).Trim().Length.Equals(12))
                        {
                            string aux = reader.GetString(reader.GetOrdinal("cor_2"));
                            cadUser.Cor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(0, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(3, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(6, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(9, 3)))))));
                        }
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cor_3")))
                    {
                        if (reader.GetString(reader.GetOrdinal("cor_3")).Trim().Length.Equals(12))
                        {
                            string aux = reader.GetString(reader.GetOrdinal("cor_3"));
                            cadUser.Cor_3 = System.Drawing.Color.FromArgb(((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(0, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(3, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(6, 3)))))),
                            ((int)(((byte)(Convert.ToInt32(aux.Trim().Substring(9, 3)))))));
                        }
                    }

                    lista.Add(cadUser);
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

        public string GravaUsuario(TRegistro_CadUsuario user)
        {
            Hashtable hs = new Hashtable(15);
            hs.Add("@P_LOGIN", user.Login);
            hs.Add("@P_SENHA", user.Senha);
            hs.Add("@P_NOME_USUARIO", user.Nome_usuario);
            hs.Add("@P_TP_REGISTRO", user.Tp_registro);
            hs.Add("@P_ST_EXPIRARSENHA", user.St_ExpirarSenha);
            hs.Add("@P_QT_DIASEXPIRAR", user.Qt_DiasExpirar);
            hs.Add("@P_ST_REGISTRO", user.St_Registro);
            hs.Add("@P_DT_ALTSENHA", user.Dt_altsenha);
            hs.Add("@P_EMAIL_PADRAO", user.Email_padrao);
            hs.Add("@P_ST_ALTERARSENHA", user.St_AlterarSenha);
            hs.Add("@P_LOGIN_BI", user.Login_BI);
            hs.Add("@P_SENHA_BI", user.Senha_BI);
            hs.Add("@P_ST_LOGINPDV", user.St_loginPDV);
            hs.Add("@P_COR_1", user.Cor_1.A.ToString().PadLeft(3, '0') + user.Cor_1.R.ToString().PadLeft(3, '0') + user.Cor_1.G.ToString().PadLeft(3, '0') + user.Cor_1.B.ToString().PadLeft(3, '0'));
            hs.Add("@P_COR_2", user.Cor_2.A.ToString().PadLeft(3, '0') + user.Cor_2.R.ToString().PadLeft(3, '0') + user.Cor_2.G.ToString().PadLeft(3, '0') + user.Cor_2.B.ToString().PadLeft(3, '0'));
            hs.Add("@P_COR_3", user.Cor_3.A.ToString().PadLeft(3, '0') + user.Cor_3.R.ToString().PadLeft(3, '0') + user.Cor_3.G.ToString().PadLeft(3, '0') + user.Cor_3.B.ToString().PadLeft(3, '0'));

            return executarProc("IA_DIV_USUARIO", hs);
        }

        public string DeletarUsuario(TRegistro_CadUsuario user)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_LOGIN", user.Login);
            return this.executarProc("EXCLUIR_DIV_USUARIO", hs);
        }
    }
}
