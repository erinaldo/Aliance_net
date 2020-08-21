using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using FormBusca;
using Componentes;
using Utils;

namespace Aliance.NET
{
    public partial class FLogin : Form
    {
        private string Cd_terminal = string.Empty;
        public void fplogin(ref string vLogin, ref string vSenha, ref string vCD_Terminal, ref string vDS_Terminal)
        {
            vLogin = Login.Text;
            vSenha = Senha.Text;
            vCD_Terminal = Cd_terminal;
            //Buscar descricao terminal
            object ds_terminal = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_terminal.Trim() + "'"
                                        }
                                    }, "a.ds_terminal");
            vDS_Terminal = ds_terminal == null ? string.Empty : ds_terminal.ToString();
        }

        public FLogin()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("PORTUGUÊS", "pt-BR"));
            cbx.Add(new TDataCombo("ESPANHOL", "es-ES"));
            cbx.Add(new TDataCombo("INGLÊS", "en-US"));
            cbIdioma.DataSource = cbx;
            cbIdioma.DisplayMember = "Display";
            cbIdioma.ValueMember = "Value";
            if (!string.IsNullOrEmpty(Aliance.NET.Properties.Settings.Default.CULTURA))
                cbIdioma.SelectedValue = Aliance.NET.Properties.Settings.Default.CULTURA;
            else
                cbIdioma.SelectedIndex = 0;
            Utils.Parametros.pubCultura = cbIdioma.SelectedValue.ToString();
        }
                        
        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                MessageBox.Show("Obrigatorio informar login.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Senha.Text))
            {
                MessageBox.Show("Obrigatorio informar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Senha.Focus();
                return;
            }
            if (cbEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatorio selecionar empresa para efetuar login.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (!System.IO.File.Exists("C:\\Aliance.NET\\ConectAliance.xml"))
            {
                MessageBox.Show("Arquivo de conexão não encontrado.\r\nConfigure novamente os dados de conexão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
            //Verificar se existe elemento para o usuario
            IEnumerable<XElement> usuario =
                from x in xml.Elements("usuario")
                where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Text.Trim().ToUpper())
                select x;
            if (usuario.Count() > 0)
            {
                foreach (XElement user in usuario)
                {
                    user.Attribute("lembrarsenha").SetValue(st_lembrarsenha.Checked ? "S" : "N");
                    user.Attribute("senha").SetValue(Utils.Estruturas.CalcChaveAcesso(Senha.Text));
                }
                IEnumerable<XElement> emp =
                    from y in usuario.Elements("empresa")
                    where y.Attribute("id").Value.Trim().ToUpper().Equals(cbEmpresa.Text.Trim().ToUpper())
                    select y;
                if (emp.Count() > 0)
                    foreach (XElement ep in emp)
                    {
                        ep.Attribute("qtd_conect").SetValue(decimal.Parse(ep.Attribute("qtd_conect").Value) + 1);
                        Utils.Parametros.pubNM_Servidor = ep.Element("servidor").Value;
                        Utils.Parametros.pubNM_BancoDados = ep.Element("banco").Value;

                        xml.Save("C:\\Aliance.NET\\ConectAliance.xml");
                    }
                else
                {
                    MessageBox.Show("Não existe configuração para o login e empresa informado.\r\nConfigure os dados para conexão.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Não existe configuração para o login.\r\nConfigure os dados de conexão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (Login.Focused)
                Login_Leave(sender, e);
            Properties.Settings.Default.DT_SERVIDOR = CamadaDados.UtilData.Data_Servidor();
            if (!Login.Text.Trim().ToUpper().Equals("MASTER") &&
                !Login.Text.Trim().ToUpper().Equals("DESENV"))//Somente usuario MASTER e DESENV pode logar sem terminal e sem chave de acesso
            {
                //Buscar data atual do servidor
                DateTime dt_atualservidor = CamadaDados.UtilData.Data_Servidor();
                if (dt_atualservidor.DayOfWeek != DayOfWeek.Saturday &&
                    dt_atualservidor.DayOfWeek != DayOfWeek.Sunday)
                {
                    //Validar licenca do sistema
                    CamadaDados.Diversos.TList_Licenca lic = new CamadaDados.Diversos.TCD_Licenca().Select(null, 1, string.Empty);
                    //Se não existir licenca, gerar uma nova
                    if (lic.Count.Equals(0) ? true :
                        (lic[0].Hash_chave.Trim() !=
                            Estruturas.SHA1(lic[0].Dt_ativacaostr +
                                            lic[0].Nr_sequencial.ToString() +
                                            lic[0].Qt_diasvalidade.ToString() +
                                            lic[0].Chave_validade.Trim())) ||
                             //Licenca expirada
                             lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade)).Date < dt_atualservidor ||
                            //Avisar 10 dias antes da Licença expirar
                            (lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade)).Date <= dt_atualservidor &&
                             lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade + 10)).Date >= dt_atualservidor))
                    {

                        try
                        {
                            if (lic.Count > 0)
                                if (dt_atualservidor < lic[0].Dt_ultimoacesso.Value)
                                {
                                    MessageBox.Show("Data atual do servidor é menor que ultimo acesso " + lic[0].Dt_ultimoacessostr + ".\r\n" +
                                                    "Não é permitido voltar a data do servidor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Environment.Exit(Environment.ExitCode);
                                }
                            CamadaDados.Help.TChaveLic cLic = ServiceRest.DataService.CalcularLicenca(
                                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null),
                                CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("WS_SERVIDOR_BI", null));
                            if (cLic.Status.Trim().Equals("0") && lic.Count > 0 ? lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade)).Date < dt_atualservidor : true)
                                CamadaNegocio.Diversos.TCN_Licenca.Gravar(
                                    new CamadaDados.Diversos.TRegistro_Licenca()
                                    {
                                        Dt_ativacao = DateTime.Parse(cLic.Dt_licenca),
                                        Dt_ultimoacesso = dt_atualservidor,
                                        Qt_diasvalidade = Convert.ToDecimal(cLic.Qt_diasvalidade),
                                        Nr_sequencial = cLic.Nr_seqlic,
                                        Chave_validade = cLic.Chave,
                                        Hash_chave = Estruturas.SHA1(cLic.Dt_licenca.Trim() +
                                                                     cLic.Nr_seqlic.ToString() +
                                                                     cLic.Qt_diasvalidade.ToString() +
                                                                     cLic.Chave.Trim())
                                    }, null);
                            else
                            {
                                //Verificar se Cliente tem acesso a tela de contas a pagar ou receber
                                if (new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_Menu",
                                                vOperador = "=",
                                                vVL_Busca = "'050700' or exists(select 1 from tb_div_usuario_x_grupos x " +
                                                                                "inner join tb_div_acesso y " +
                                                                                "on y.Login = x.Logingrp " +
                                                                                "where a.login = x.Loginusr " +
                                                                                "and y.id_menu = '050700' " +
                                                                                "and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "') "//Codigo Menu Tela Consulta Contas Pagar/Receber
                                            }
                                            }, "1") != null &&
                                    //Sempre aparecer antes do fim da licença se o usuario tiver acesso a tela de contas a pagar e a receber
                                    !cLic.Status.Equals("0") && lic.Count > 0 ? lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade + 10)).Date > dt_atualservidor.Date : false)
                                {
                                    MessageBox.Show("Sua LICENÇA DE USO expira em " + lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade + 10)).Subtract(dt_atualservidor).Days.ToString() + " dias.\r\n" +
                                                    "Obs.:Para evitar o bloqueio do sistema entre com contato com a TecnoAliance o mais breve possivel\r\n" +
                                                    "e informe o código da Mensagem <" + cLic.Status.Trim() + ">.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (lic.Count.Equals(0))
                                        Environment.Exit(Environment.ExitCode);
                                    if (lic[0].Hash_chave.Trim() !=
                                        Estruturas.SHA1(lic[0].Dt_ativacaostr +
                                                        lic[0].Nr_sequencial.ToString() +
                                                        lic[0].Qt_diasvalidade.ToString() +
                                                        lic[0].Chave_validade.Trim()))
                                        Environment.Exit(Environment.ExitCode);
                                }//Aparecer somente quando nao gerar licença e quando licença estiver expirada passados os 10 dias de carência
                                else if (!cLic.Status.Equals("0") && //Aparecer somente quando nao gerar licença e quando licença estiver expirada passados os 10 dias de carência
                                         lic.Count > 0 ? lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade + 10)).Date < dt_atualservidor.Date : true)
                                {
                                    MessageBox.Show("Licença do Sistema Aliance.Net expirou!\r\n" +
                                                    "Entre em contato com o suporte técnico do sistema.", "Mensagem",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Environment.Exit(Environment.ExitCode);
                                }
                            }
                        }
                        catch
                        {
                            if (lic.Count > 0 ? lic[0].Dt_ativacao.Value.AddDays(Convert.ToDouble(lic[0].Qt_diasvalidade)).Date < dt_atualservidor.Date : true)
                            {
                                //Verificar se o usuario tem permissao para calcular chave manual
                                if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CALCULAR CHAVE ATIVACAO SISTEMA", null))
                                {
                                    using (TFCalcChaveAcesso fChave = new TFCalcChaveAcesso())
                                    {
                                        if (fChave.ShowDialog() != DialogResult.OK)
                                        {
                                            MessageBox.Show("Obrigatorio informar licenca para acessar o sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Environment.Exit(Environment.ExitCode);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Licença do Sistema Aliance.Net expirou!\r\nUsuário não possui permissão para gravar licença manual.\r\n" +
                                                        "Entre em contato com o suporte técnico do sistema.", "Mensagem",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Environment.Exit(Environment.ExitCode);
                                }
                            }
                        }
                    }
                }
                //Validar terminal
                try
                {
                    Cd_terminal = CamadaNegocio.Diversos.TCN_CadTerminal.ValidaTerminal(Login.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                object obj_terminal = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_terminal x "+
                                                            "where x.cd_terminal = a.cd_terminal "+
                                                            "and x.login = '" + Login.Text.Trim() + "')"
                                            }
                                        }, "a.cd_terminal");
                if (obj_terminal != null)
                    Cd_terminal = obj_terminal.ToString();
            }
            if (CamadaNegocio.Diversos.TCN_CadUsuario.ExpirarSenha(Login.Text))
            {
                MessageBox.Show("Sua senha expirou.\r\nO sistema ira exigir a troca da mesma.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TFAlterarSenha fAlterarSenha = new TFAlterarSenha();
                try
                {
                    fAlterarSenha.vLogin = Login.Text;
                    if (fAlterarSenha.ShowDialog() == DialogResult.OK)
                    {
                        Senha.Text = fAlterarSenha.vSenhaAtual;
                        DialogResult = DialogResult.OK;
                    }
                    else
                        DialogResult = DialogResult.Cancel;
                }
                finally
                {
                    fAlterarSenha.Dispose();
                }
            }
            else
                DialogResult = DialogResult.OK;
            if (CamadaNegocio.Diversos.TCN_CadUsuario.verificarAlterarSenha(Login.Text))
            {
                TFAlterarSenha fAlterarSenha = new TFAlterarSenha();
                try
                {
                    fAlterarSenha.vLogin = Login.Text;
                    if (fAlterarSenha.ShowDialog() == DialogResult.OK)
                    {
                        Senha.Text = fAlterarSenha.vSenhaAtual;
                        DialogResult = DialogResult.OK;
                        TpBusca[] filtro = new TpBusca[1];
                        filtro[0].vNM_Campo = "login";
                        filtro[0].vOperador = "=";
                        filtro[0].vVL_Busca = "'" + Login.Text.Trim() + "'";
                        CamadaDados.Diversos.TList_CadUsuario user = new CamadaDados.Diversos.TCD_CadUsuario().Select(filtro, 1, string.Empty);
                        if (user.Count > 0)
                        {
                            user[0].St_AlterarSenha = "N";
                            CamadaNegocio.Diversos.TCN_CadUsuario.Gravar(user[0], null);
                        }
                    }
                    else
                        DialogResult = DialogResult.Cancel;
                }
                finally
                {
                    fAlterarSenha.Dispose();
                }
            }
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text))
            {
                Utils.Parametros.pubLogin = Login.Text;
                //Buscar xml com as config do usuario
                if (System.IO.File.Exists("C:\\Aliance.NET\\ConectAliance.xml"))
                {
                    XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
                    //Verificar se existe elemento para o usuario
                    IEnumerable<XElement> usuario =
                        from x in xml.Elements("usuario")
                        where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Text.Trim().ToUpper())
                        select x;
                    foreach (XElement user in usuario)
                    {
                        st_lembrarsenha.Checked = user.Attribute("lembrarsenha").Value.Trim().ToUpper().Equals("S");
                        if (st_lembrarsenha.Checked)
                            Senha.Text = Utils.Estruturas.DecChaveAcesso(user.Attribute("senha").Value);
                        //Buscar empresas configuradas para o usuario
                        var empresa =
                            from y in user.Elements("empresa")
                            orderby decimal.Parse(y.Attribute("qtd_conect").Value) descending
                            select y;
                        foreach (XElement emp in empresa)
                            cbEmpresa.Items.Add(emp.Attribute("id").Value);
                        if (cbEmpresa.Items.Count > 0)
                            cbEmpresa.SelectedIndex = 0;
                    }
                }
            }
        }
               
        private void FLogin_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CULTURA))
            {
                cbIdioma.SelectedValue = Properties.Settings.Default.CULTURA;
                Utils.Parametros.pubCultura = Properties.Settings.Default.CULTURA;
                Idioma.TIdioma.AjustaCultura(this);
            }
            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void cbIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.CULTURA = cbIdioma.SelectedValue != null ? cbIdioma.SelectedValue.ToString() :
                Properties.Settings.Default.CULTURA;
            Properties.Settings.Default.Save();
            Utils.Parametros.pubCultura = Properties.Settings.Default.CULTURA;
            Idioma.TIdioma.AjustaCultura(this);
        }

        private void lblSuporte_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tawk.to/chat/5941999350fd5105d0c8110e/1bjsuk5jp/?$_tawk_popout=true");
        }

        private void lblAcessoRemoto_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Utils.Parametros.pubPathAliance.Trim() +
                                        System.IO.Path.DirectorySeparatorChar.ToString() +
                                        "EasyDesk.exe"))
                if (System.Diagnostics.Process.GetProcessesByName("EasyDeskAccess").Length == 0)
                    try
                    {
                        System.Diagnostics.Process.Start(Utils.Parametros.pubPathAliance.Trim() +
                                                         System.IO.Path.DirectorySeparatorChar.ToString() +
                                                         "EasyDesk.exe");
                    }
                    catch
                    { }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                MessageBox.Show("Obrigatorio informar login para configurar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Focus();
                return;
            }
            if (st_lembrarsenha.Checked && string.IsNullOrEmpty(Senha.Text))
            {
                MessageBox.Show("Obrigatorio informar senha para configurar empresa e lembrar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Senha.Focus();
                return;
            }
            cbEmpresa.Items.Clear();
            using (TFEmpresa fEmp = new TFEmpresa())
            {
                fEmp.Login = Login.Text;
                fEmp.LembrarSenha = st_lembrarsenha.Checked ? "S" : "N";
                fEmp.Senha = Senha.Text;
                fEmp.ShowDialog();
                //Buscar empresa do usuario
                //Buscar xml com as config do usuario
                if (System.IO.File.Exists("C:\\Aliance.NET\\ConectAliance.xml"))
                {
                    XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
                    //Verificar se existe elemento para o usuario
                    IEnumerable<XElement> usuario =
                        from x in xml.Elements("usuario")
                        where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Text.Trim().ToUpper())
                        select x;
                    foreach (XElement user in usuario)
                    {
                        //Buscar empresas configuradas para o usuario
                        var empresa =
                            from y in user.Elements("empresa")
                            orderby decimal.Parse(y.Attribute("qtd_conect").Value) descending
                            select y;
                        foreach (XElement emp in empresa)
                            cbEmpresa.Items.Add(emp.Attribute("id").Value);
                        if (cbEmpresa.Items.Count > 0)
                            cbEmpresa.SelectedIndex = 0;
                    }
                }
            }
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                MessageBox.Show("Obrigatorio informar login para configurar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.Focus();
                return;
            }
            if (st_lembrarsenha.Checked && string.IsNullOrEmpty(Senha.Text))
            {
                MessageBox.Show("Obrigatorio informar senha para configurar empresa e lembrar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Senha.Focus();
                return;
            }
            using (TFEmpresa fEmp = new TFEmpresa())
            {
                fEmp.Login = Login.Text;
                fEmp.LembrarSenha = st_lembrarsenha.Checked ? "S" : "N";
                fEmp.Senha = Senha.Text;


                //Buscar empresa do usuario
                //Buscar xml com as config do usuario
                if (System.IO.File.Exists("C:\\Aliance.NET\\ConectAliance.xml"))
                {
                    XElement xml = XElement.Load("C:\\Aliance.NET\\ConectAliance.xml");
                    //Verificar se existe elemento para o usuario
                    IEnumerable<XElement> usuario =
                        from x in xml.Elements("usuario")
                        where x.Attribute("login").Value.Trim().ToUpper().Equals(Login.Text.Trim().ToUpper())
                        select x;

                    int i = 0;
                    foreach (XElement user in usuario)
                    {
                        //Buscar empresas configuradas para o usuario
                        IEnumerable<XElement> empresa =
                            from y in user.Elements("empresa")
                            orderby decimal.Parse(y.Attribute("qtd_conect").Value) descending
                            select y;
                        if (i == 0)
                        {
                            i++;
                            fEmp.DSBanco = empresa.ToList().Find(p => p.Attribute("id").Value.Equals(cbEmpresa.SelectedItem)).Element("banco").Value;
                            fEmp.DSServidor = empresa.ToList().Find(p => p.Attribute("id").Value.Equals(cbEmpresa.SelectedItem)).Element("servidor").Value;
                            fEmp.DSEmpresa = empresa.ToList().Find(p => p.Attribute("id").Value.Equals(cbEmpresa.SelectedItem)).Attribute("id").Value;
                        }
                       }
                }
                fEmp.ShowDialog();
            }
            Login_Leave(null,null);
        }
        
        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.Parametros.pubSenha = Senha.Text;
        }

        private void lblTicket_Click(object sender, EventArgs e)
        {
            using (Help.TFLoginHelpCNPJ fLogin = new Help.TFLoginHelpCNPJ())
            {
                if(fLogin.ShowDialog() == DialogResult.OK)
                {
                    using (Help.TFTicket fTicket = new Help.TFTicket())
                    {
                        fTicket.LoginCliente = fLogin.Login;
                        fTicket.Id_cliente = fLogin.Id_cliente;
                        fTicket.ShowDialog();
                    }
                }
            }
        }
    }
}