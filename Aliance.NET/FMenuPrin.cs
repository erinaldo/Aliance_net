using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using System.Reflection;
using Financeiro;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaNegocio.ConfigGer;
using Consulta;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using System.Net;
using CamadaDados.Graos;
using CamadaNegocio.Graos;

namespace Aliance.NET
{
    public partial class FMenuPrin : Form
    {
        private bool atualiza = false;
        private decimal versao = decimal.Zero;
        private string servidorFTP = string.Empty;
        private string loginFTP = string.Empty;
        private string senhaFTP = string.Empty;
        private string vlogin = string.Empty;
        private string vCD_Terminal = string.Empty;
        private string vDS_Terminal = string.Empty;
        private DataTable tabelaAcesso;
        //Tabela buscar dados dos semafaros
        private DataTable tb_semafaro;

        //private bool ST_AtualizarlistaTicket = false;
        private string Login_BI = string.Empty;
        //private TList_StatusTicket_BI lStatusTicket;
        //private System.Timers.Timer tmpStatusTicket;
        private System.Timers.Timer tmpStatusComp;
        private System.Timers.Timer tmpAtualiza;
        private TList_LanCompromisso lComp;
        private CamadaDados.Financeiro.Cadastros.TList_Aniversariante lAniversariante;
        /*
        private delegate void MensagemStatusTicketDelegate(TRegistro_StatusTicket_BI rStatus, string Ds_evolucao, DateTime? Dt_evolucao);

        private void MensagemStatusTicket(TRegistro_StatusTicket_BI rStatus, string Ds_evolucao, DateTime? Dt_evolucao)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new MensagemStatusTicketDelegate(MensagemStatusTicket), new object[] { rStatus, Ds_evolucao, Dt_evolucao });
                else
                    using (TFMsgTicket fMsg = new TFMsgTicket())
                    {
                        fMsg.Location = new Point(this.Width - fMsg.Width - 20, this.Height - fMsg.Height - 20);
                        fMsg.Id_ticket = rStatus.Id_ticket.Value.ToString();
                        fMsg.Ds_evolucao = Ds_evolucao;
                        fMsg.ShowDialog();
                        if (fMsg.St_atualiarTmpEvolucao)
                        {
                            rStatus.Dt_etapa = Dt_evolucao;
                            TCN_StatusTicket_BI.Gravar(rStatus, null);
                        }
                        if (fMsg.St_visualizarTicket)
                            using (Help.TFCentralHelpDesk fCentral = new Help.TFCentralHelpDesk())
                            {
                                fCentral.Id_ticket = rStatus.Id_ticket.Value.ToString();
                                fCentral.ShowDialog();
                            }
                    }
            }
            catch { }
        }
        */

        private string ret_num(string sNum)
        {
            Int16 x; string ret = string.Empty;

            for (x = 0; x <= sNum.Length - 1; x++)
                if ((sNum[x] == '0') || (sNum[x] == '1') || (sNum[x] == '2') || (sNum[x] == '3') || (sNum[x] == '4')
                    || (sNum[x] == '5') || (sNum[x] == '6') || (sNum[x] == '7') || (sNum[x] == '8') || (sNum[x] == '9'))
                    ret += sNum[x];
            if (string.IsNullOrEmpty(ret))
                ret = "0";
            return ret;
        }

        private void AtualizaParametros()
        {
            //Buscar parametro Banco DataCenter
            lblBd.Text = Utils.Parametros.pubNM_BancoDados.Trim().ToUpper();
            lblServidorBd.Text = Utils.Parametros.pubNM_Servidor.Trim().ToUpper();
        }

        private void EventoMenu(string vId_menu)
        {
            DataRow[] linhas = tabelaAcesso.Select("id_menu = '" + vId_menu + "'");
            if (!string.IsNullOrEmpty(linhas[0]["nm_modulo"].ToString().Trim()))
            {
                try
                {
                    Assembly extAssembly = Assembly.LoadFrom(Utils.Parametros.pubPathAliance.Trim() +
                                                             System.IO.Path.DirectorySeparatorChar.ToString() +
                                                             linhas[0]["nm_modulo"].ToString().Trim());
                    string Mod = extAssembly.ManifestModule.Name.Replace(".dll", "");
                    object extInfo = extAssembly.CreateInstance(Mod + ".TInfo");
                    extInfo.GetType().GetMethod("setPub").Invoke(extInfo, new object[] { "LOGIN:" + vlogin + "|" + "TERMINAL:" + vCD_Terminal });
                    //se for null significa que é um botao de submenu
                    if (string.IsNullOrEmpty(linhas[0].ItemArray[4].ToString()))
                    {
                        return;
                    }


                    Form extForm = (extAssembly.CreateInstance(linhas[0]["nm_classe"].ToString().Trim()) as Form);
                    if (vlogin.Trim() != "MASTER" && vlogin.Trim() != "DESENV")
                    {
                        //Gravar acesso na tabela acesso
                        TList_CadAcesso lAcesso = TCN_CadAcesso.BuscarAcesso(vlogin,
                                                                      vId_menu,
                                                                      null);
                        if (lAcesso.Count > 0)
                        {
                            lAcesso[0].Qtd_acesso += 1;
                            TCN_CadAcesso.GravarAcesso(lAcesso[0], null);
                        }
                    }
                    if (extForm.Tag == null)
                    {
                        this.AddOwnedForm(extForm);
                        extForm.MdiParent = this;
                        extForm.Tag = linhas[0]["cd_modulo"].ToString().Trim();
                        extForm.Show();
                    }
                    else if (extForm.Tag.ToString().Trim().ToUpper() != "N")
                    {
                        this.AddOwnedForm(extForm);
                        extForm.MdiParent = this;
                        extForm.Tag = linhas[0]["cd_modulo"].ToString().Trim();
                        extForm.Show();
                    }
                    else
                    {
                        extForm.Tag = "S";//Aberto pelo menu principal no modo MODAL
                        extForm.ShowDialog();
                    }
                }
                catch (System.IO.FileLoadException ex)
                {
                    MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                    "O sistema não pode ler o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                    "O sistema não pode encontrar o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show("Erro: O nome da classe do formulario esta incorreto.\r\n Formulario: " + linhas[0]["nm_classe"].ToString().Trim() + "\r\n\r\n" + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: Não foi possivel criar o formulario solicitado. \r\n Arquivo: " + linhas[0]["nm_modulo"].ToString().Trim() + "\r\n Formulario: " +
                                    linhas[0]["nm_classe"].ToString().Trim() + "\r\n" + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChamarRelatorio(string vIDReport)
        {
            try
            {
                //BUSCA O ID DO MENU
                if (vIDReport != "")
                {
                    TList_Cad_Report Reg_Report = TCN_Cad_Report.Buscar(vIDReport.Equals(string.Empty) ? 0 : Convert.ToDecimal(vIDReport), string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, false, false, true);

                    if (Reg_Report != null && Reg_Report.Count > 0)
                    {
                        //MONTA O FORM
                        new Query_Report().MontaFormRelatorio(Reg_Report[0], null);
                    }
                    else
                    {
                        throw new Exception("Erro: O código do relatório informado não esta cadastrado.");
                    }
                }
                else
                    throw new Exception("Erro: O código do relatório informado não esta cadastrado.");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarCompromissos()
        {
            //Buscar Compromissos
            DateTime dt_servidor = CamadaDados.UtilData.Data_Servidor();
            lComp = CamadaNegocio.Diversos.TCN_LanCompromisso.Busca(string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    dt_servidor.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                    dt_servidor.AddHours(168).ToString("dd/MM/yyyy HH:mm:ss"),
                                                                    Utils.Parametros.pubLogin,
                                                                    "'A'",
                                                                    null);
            if (lComp.Count > 0)
            {
                using (TFMsgComp fMsg = new TFMsgComp())
                {
                    fMsg.Location = new Point(850, 600);
                    fMsg.Size = new Size(431, 130);
                    fMsg.NM_Compromisso = "VOCÊ TEM " + lComp.Count.ToString().Trim() + ((lComp.Count > 1) ? " COMPROMISSOS" : " COMPROMISSO") + " NOS PROXIMOS 7 DIAS!";
                    fMsg.ShowDialog();
                    if (fMsg.St_visualizarComp)
                        using (Parametros.Diversos.TFLan_Compromisso fComp = new Parametros.Diversos.TFLan_Compromisso())
                        {
                            fComp.lCompromisso = lComp;
                            fComp.ShowDialog();
                        }
                }
                tmpStatusComp = new System.Timers.Timer(1550);
                tmpStatusComp.Elapsed += new System.Timers.ElapsedEventHandler(MsgComp_Elapsed);
                tmpStatusComp.Start();
            }
        }

        public void Click_Menu(object Sender, EventArgs e)
        {
            string[] strDadoRel = (Sender as ToolStripMenuItem).Tag.ToString().Split(new char[] { '|' });

            if (strDadoRel[0].Trim() == "R")
            {
                this.ChamarRelatorio(strDadoRel[1].Trim());
            }
            else
            {
                this.EventoMenu((Sender as ToolStripMenuItem).Name.ToString());
            }
        }

        public FMenuPrin()
        {
            InitializeComponent();
            Login_BI = string.Empty;
            //lStatusTicket = null;
            //tmpStatusTicket = null;
            if (System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() +
                                          System.IO.Path.DirectorySeparatorChar.ToString() +
                                          "Dll"))
                Utils.Parametros.pubPathAliance = System.IO.Directory.GetCurrentDirectory() +
                                                  System.IO.Path.DirectorySeparatorChar.ToString() +
                                                  "Dll";
            else Utils.Parametros.pubPathAliance = System.IO.Directory.GetCurrentDirectory();
            string vSenha = string.Empty;
            string[] vamb = Environment.GetCommandLineArgs();
            if (vamb.Length > 1)
            {
                string[] v = vamb[1].Split(new char[] { '|' });
                servidorFTP = v[0];
                loginFTP = v[1];
                senhaFTP = v[2];
                lblVersao.Text = v[3].Trim();
                ShowInTaskbar = false;
            }
            try
            {
                int tentativas = 0;
                for (tentativas = 0; tentativas < 3; tentativas++)
                {
                    using (FLogin telalogin = new FLogin())
                    {
                        if (telalogin.ShowDialog() == DialogResult.OK)
                        {
                            telalogin.fplogin(ref vlogin, ref vSenha, ref vCD_Terminal, ref vDS_Terminal);
                            Utils.Parametros.pubTerminal = vCD_Terminal;
                            if ((new TCD_CadUsuario().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "login",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vlogin.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "senha",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vSenha.Trim() + "'"
                                    }
                                }, "1") != null) ||
                                (vlogin.Trim().ToUpper().Equals("MASTER") && new BancoDados.TObjetoBanco().ValidarSenhaMaster(vSenha)) ||
                                (vlogin.Trim().ToUpper().Equals("DESENV") && new BancoDados.TObjetoBanco().ValidarSenhaDesenv(vSenha)))
                            {
                                //Mapear porta impressora para o terminal
                                if (!string.IsNullOrEmpty(vCD_Terminal))
                                {
                                    TRegistro_CadTerminal rTerminal = TCN_CadTerminal.Busca(vCD_Terminal, string.Empty, null)[0];
                                    if ((!string.IsNullOrEmpty(rTerminal.Mapearportatick)) &&
                                        (!string.IsNullOrEmpty(rTerminal.Porta_imptick)))
                                        System.Diagnostics.Process.Start("net", "use " + rTerminal.Porta_imptick.Trim() + " " + rTerminal.Mapearportatick.Trim());
                                }
                                edLogin.Text = vlogin;
                                cd_terminal.Text = vCD_Terminal;
                                ds_terminal.Text = vDS_Terminal;

                                CarregaMenu(vlogin, false);

                                Utils.Parametros.pubTopMax = Convert.ToInt16(TCN_CadParamGer.BuscaVlNumerico("TOPMAX_CONSULTA", null));
                                Utils.Parametros.pubPathConfig = TCN_CadParamGer.BuscaVlString("PATH_CONFIG", null);
                                Utils.Parametros.ST_UtilizarCoringaEsq = TCN_CadParamGer.BuscaVlBool("ST_UTILIZAR_CORINGA_ESQ", null);
                                Utils.Parametros.pubTmpStatusTicket = TCN_CadParamGer.BuscaVlNumerico("TMP_STATUS_TICKET_BI", null);
                                Utils.Parametros.pubTmpMsgTicket = TCN_CadParamGer.BuscaVlNumerico("TMP_MSG_BI", null);
                                Utils.Parametros.WS_ServidorHelpDesk = TCN_CadParamGer.BuscaVlString("WS_SERVIDOR_BI", null);
                                Utils.Parametros.pubTruncarSubTotal = TCN_CadParamGer.BuscaVlBool("ST_TRUNCAR_SUBTOTAL", null);

                                CriaMenus.Visible = false;
                                if ((vlogin.Trim().ToUpper().Equals("MASTER") ||
                                    vlogin.Trim().ToUpper().Equals("DESENV")) && Menuprin.Items.Count.Equals(0))
                                    CriaMenus.Visible = true;

                                break;
                            }
                            else
                                MessageBox.Show("Senha ou Usuário invalido !");
                        }
                        else
                        {
                            Environment.Exit(Environment.ExitCode);
                            break;
                        }
                    }
                }
                if (tentativas == 3)
                    Environment.Exit(Environment.ExitCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(Environment.ExitCode);
            }
        }

        public void CarregaMenu(string vlogin, bool LimparMenu)
        {
            if (LimparMenu)
                Menuprin.Items.Clear();

            string snivel = string.Empty;
            string Sidmenu = string.Empty;
            string Sdsmenu = string.Empty;
            string Stp_vento = string.Empty;
            string Sidreport = string.Empty;
            Int16 x = 0;
            Int16 Sidmenu1 = -1;
            Int16 Sidmenu2 = -1;
            Int16 Sidmenu3 = -1;
            Int32 Inivel;
            tabelaAcesso = new TCD_CadUsuario().BuscaAcessoMenu(vlogin);
            while (x <= tabelaAcesso.Rows.Count - 1)
            {
                Sidmenu = tabelaAcesso.Rows[x]["id_menu"].ToString().Trim();
                Sdsmenu = tabelaAcesso.Rows[x]["ds_menu"].ToString().Trim();
                snivel = tabelaAcesso.Rows[x]["NIVEL"].ToString().Trim();
                Stp_vento = tabelaAcesso.Rows[x]["TP_EVENTO"].ToString().Trim();
                Sidreport = tabelaAcesso.Rows[x]["id_report"].ToString().Trim();

                if (Sdsmenu != "-")
                {
                    Inivel = Convert.ToInt16(snivel);

                    try
                    {
                        if (Inivel == 1)
                        {
                            Sidmenu1++;
                            ToolStripItem it = Menuprin.Items.Add(Sdsmenu, null, Click_Menu);
                            it.Name = Sidmenu;
                            it.Tag = Stp_vento + "|" + Sidreport;

                            Sidmenu2 = -1;
                        }
                        else if (Inivel == 2)
                        {
                            Sidmenu2++;
                            ToolStripItem it = (Menuprin.Items[Sidmenu1] as ToolStripMenuItem).DropDown.Items.Add(Sdsmenu, null, Click_Menu);
                            it.Name = Sidmenu;
                            it.Tag = Stp_vento + "|" + Sidreport;

                            Sidmenu3 = -1;
                        }
                        else if (Inivel == 3)
                        {
                            Sidmenu3++;
                            ToolStripItem it = ((Menuprin.Items[Sidmenu1] as ToolStripMenuItem).DropDown.Items[Sidmenu2] as ToolStripMenuItem).DropDown.Items.Add(Sdsmenu, null, Click_Menu);
                            it.Name = Sidmenu;
                            it.Tag = Stp_vento + "|" + Sidreport;
                        }
                        else if (Inivel == 4)
                        {
                            ToolStripItem it = (((Menuprin.Items[Sidmenu1] as ToolStripMenuItem).DropDown.Items[Sidmenu2] as ToolStripMenuItem).DropDown.Items[Sidmenu3] as ToolStripMenuItem).DropDown.Items.Add(Sdsmenu, null, Click_Menu);
                            it.Name = Sidmenu;
                            it.Tag = Stp_vento + "|" + Sidreport;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao incluir " + Sidmenu);
                    }
                }
                x++;
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente finalizar o programa?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                Environment.Exit(Environment.ExitCode);
        }

        private void BB_Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void FMenuPrin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F9) & e.Control)
                Application.Restart();
            else if (e.KeyCode.Equals(Keys.F8) & e.Control)
                bb_alterarsenha_Click(this, new EventArgs());
            else if (e.KeyCode == (Keys.F12) & e.Control)
                using (Proc_Commoditties.TFConsultaRapida fConsulta = new Proc_Commoditties.TFConsultaRapida())
                {
                    fConsulta.ShowDialog();
                }
        }

        private void FMenuPrin_Load(object sender, EventArgs e)
        {
            //Mudar cor de fundo
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;
                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Catch and ignore the error if casting failed.
                }
            }

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            tsdNFeNFCe.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROCESSAR NFE", null);
            AtualizaParametros();
            tmpValidarDataServer.Enabled = true;
            //Criar de chamados com a data da ultima evolucao
            //Verificar se o usuario possui login BI
            object obj = new TCD_CadUsuario().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                }
                            }, "a.login_BI");
            if (obj != null ? !string.IsNullOrEmpty(obj.ToString()) : false)
            {
                Login_BI = obj.ToString();
                //tmpStatusTicket = new System.Timers.Timer(Utils.Parametros.pubTmpStatusTicket > decimal.Zero ? Convert.ToDouble(Utils.Parametros.pubTmpStatusTicket) : 15000);
                //tmpStatusTicket.Elapsed += new System.Timers.ElapsedEventHandler(tmpStatusTicket_Elapsed);
                //tmpStatusTicket.Start();
            }

            try
            {
                bsAcesso.DataSource = new TCD_CadAcesso().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.login",
                            vOperador =  "=",
                            vVL_Busca =  "'" + Utils.Parametros.pubLogin.Trim() + "' or " +
                                                          "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                                          "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "c.tp_evento",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        }
                    }, 10, string.Empty, "a.qtd_acesso desc");
            }
            catch { }
            if (bsAcesso.Count > 0)
                lAcesso.Visible = true;

            //Buscar Compromissos
            BuscarCompromissos();
            //Verificar se usuario tem acesso a tela de financeiro posto combustivel
            if (TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "VISUALIZAR FINANCEIRO POSTO", null))
            {
                bool st_visualiazar = true;
                if ((SettingsUtils.Default.DT_DESATIVAFINPOSTO != null) &&
                    (!string.IsNullOrEmpty(SettingsUtils.Default.ST_DESATIVAFINPOSTO)))
                {
                    if (SettingsUtils.Default.DT_DESATIVAFINPOSTO.Date < CamadaDados.UtilData.Data_Servidor().Date)
                    {
                        SettingsUtils.Default.ST_DESATIVAFINPOSTO = "N";
                        SettingsUtils.Default.Save();
                    }
                    else if (SettingsUtils.Default.ST_DESATIVAFINPOSTO.Trim().ToUpper().Equals("S") &&
                                SettingsUtils.Default.DT_DESATIVAFINPOSTO.Date.Equals(CamadaDados.UtilData.Data_Servidor().Date))
                        st_visualiazar = false;
                }
                if (st_visualiazar)
                    using (TFAgruparFinPosto fAgrup = new TFAgruparFinPosto())
                    {
                        SettingsUtils.Default.DT_DESATIVAFINPOSTO = CamadaDados.UtilData.Data_Servidor();
                        SettingsUtils.Default.Save();
                        fAgrup.St_abrirtelahoje = true;
                        fAgrup.ShowDialog();
                    }
            }
            //Buscar Lista Aniversariantes
            if (TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "VISUALIZAR DETALHES ANIVERSARIANTES", null))
            {
                pAniversario.Visible = true;

                //Arredondar panel aniversario
                System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
                p.StartFigure();
                p.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
                p.AddLine(40, 0, pAniversario.Width - 40, 0);
                p.AddArc(new Rectangle(pAniversario.Width - 40, 0, 40, 40), -90, 90);
                p.AddLine(pAniversario.Width, 40, pAniversario.Width, pAniversario.Height - 40);
                p.AddArc(new Rectangle(pAniversario.Width - 40, pAniversario.Height - 40, 40, 40), 0, 90);
                p.AddLine(pAniversario.Width - 40, pAniversario.Height, 40, pAniversario.Height);
                p.AddArc(new Rectangle(0, pAniversario.Height - 40, 40, 40), 90, 90);
                p.CloseFigure();
                pAniversario.Region = new Region(p);

                bkwAniversario.RunWorkerAsync();
            }
            else pAniversario.Visible = false;
            //Buscar Commodities
            TList_PrecoCommodities lCotacao = new TCD_PrecoCommodities().SelectProdCotacao(string.Empty, null);
            if (lCotacao.Count > 0)
            {
                bsPrecoCommodities.DataSource = lCotacao;
                bbAtualizaCotação.Enabled = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ATUALIZAR COTAÇÃO COMMODITIES", null);
                pCotacaoCommodities.Visible = true;
            }
            else pCotacaoCommodities.Visible = false;
            if (!string.IsNullOrEmpty(servidorFTP) &&
                !string.IsNullOrEmpty(loginFTP) &&
                !string.IsNullOrEmpty(senhaFTP))
            {
                tmpAtualiza = new System.Timers.Timer(300000);
                tmpAtualiza.Elapsed += new System.Timers.ElapsedEventHandler(tmpAtualiza_Elapsed);
                tmpAtualiza.Start();
            }
            if (atualiza)
            {
                MessageBox.Show("O sistema foi atualizado, para Versão N°" + versao, "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualiza = false;
            }
            flpSemaforo.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR SEMAFOROS", null);

            if (flpSemaforo.Visible)
            {
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(string.Empty,
                                                                                                                               string.Empty,
                                                                                                                               string.Empty,
                                                                                                                               null);
                if (lCfgNfe.Count > 0)
                {
                    pNFe.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente);
                    pNFeA.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente);
                    pNFSe.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente_nfes);
                    pNFCe.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente_nfce);
                    pNFCeA.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente_nfce);
                    pLMCe.Visible = !string.IsNullOrEmpty(lCfgNfe[0].Tp_ambiente_lmc);
                }
                pCTe.Visible = new CamadaDados.Frota.Cadastros.TCD_CfgFrota().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.tp_ambiente, '')",
                                        vOperador = "<>",
                                        vVL_Busca = "''"
                                    }
                                }, "1") != null;
                pLMCe.Visible = new CamadaDados.Frota.Cadastros.TCD_CfgMDFe().BuscarEscalar(null, "1") != null;
            }
            flpSemaforo_VisibleChanged(this, new EventArgs());
        }

        void tmpAtualiza_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                tmpAtualiza.Stop();
                //Verificar se existe versao disponivel no servidor
                string arquivo = string.Empty;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(servidorFTP);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(loginFTP, senhaFTP);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    System.IO.Stream responseStream = response.GetResponseStream();
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    {

                        foreach (string s in reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>())
                            if (s.Contains('.'))
                            {
                                string[] vet = s.Split(new char[] { '.' });
                                if (vet.Length.Equals(2))
                                    if (vet[1].Trim().Equals("ali"))
                                    {
                                        arquivo = s;
                                        response.Close();
                                        break;
                                    }
                            }
                    }
                }
                if (!string.IsNullOrEmpty(arquivo) &&
                    decimal.Parse(lblVersao.Text) <
                            decimal.Parse(arquivo.Substring(0, arquivo.IndexOf('.'))))
                    atualiza = true;
                versao = decimal.Parse(arquivo.Substring(0, arquivo.IndexOf('.')));
            }
            finally { tmpAtualiza.Start(); }
        }
        /*
        void tmpStatusTicket_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(Login_BI)) && (!string.IsNullOrEmpty(Utils.Parametros.WS_ServidorHelpDesk)))
            {
                tmpStatusTicket.Stop();
                try
                {
                    //Buscar lista de ticket
                    List<CamadaDados.Help.HistEvolucao> lHistRest = Help.THelp.BuscarHistorico(Login_BI);
                    List<CamadaDados.Help.Ticket> lTicket = new List<CamadaDados.Help.Ticket>();
                    decimal? id_ticketold = null;
                    lHistRest.ForEach(p =>
                    {
                        if (id_ticketold != p.Id_ticket)
                            lTicket.Add(new CamadaDados.Help.Ticket { Id_ticket = p.Id_ticket });
                        id_ticketold = p.Id_ticket;
                    });
                    if (!ST_AtualizarlistaTicket)
                    {
                        //Buscar ticket que estao no banco local
                        lStatusTicket = TCN_StatusTicket_BI.Buscar(string.Empty, Login_BI, string.Empty, string.Empty, null);
                        //Incluir ticket no banco local, caso esteja faltando
                        lTicket.ForEach(p =>
                            {
                                if (!lStatusTicket.Exists(v => v.Id_ticket == p.Id_ticket))
                                {
                                    TCN_StatusTicket_BI.Gravar(new TRegistro_StatusTicket_BI()
                                    {
                                        Id_ticket = p.Id_ticket,
                                        Login_BI = Login_BI,
                                        Dt_etapa = lHistRest.Where(x=> x.Id_ticket == p.Id_ticket).OrderByDescending(v => v.Dt_historico).FirstOrDefault().Dt_historico
                                    }, null);
                                    lStatusTicket.Add(new TRegistro_StatusTicket_BI()
                                    {
                                        Id_ticket = p.Id_ticket,
                                        Login_BI = Login_BI,
                                        Dt_etapa = lHistRest.Where(x=> x.Id_ticket == p.Id_ticket).OrderByDescending(v => v.Dt_historico).FirstOrDefault().Dt_historico
                                    });
                                }
                            });
                        //Excluir ticket no banco local, caso nao exista mais no BI
                        lStatusTicket.ForEach(p =>
                            {
                                if (!lTicket.Exists(v => v.Id_ticket == p.Id_ticket))
                                {
                                    TCN_StatusTicket_BI.Excluir(p, null);
                                    lStatusTicket.Remove(p);
                                }
                            });
                        ST_AtualizarlistaTicket = true;
                    }
                    else
                    {
                        if (lTicket.Count > 0)
                        {
                            if (lStatusTicket == null)
                                lStatusTicket = new TList_StatusTicket_BI();
                            lTicket.ForEach(s =>
                            {
                                if (lStatusTicket.Exists(v => v.Id_ticket == s.Id_ticket))
                                {
                                    //Buscar lista de evolucoes
                                    if (lHistRest.Where(x=> x.Id_ticket == s.Id_ticket).ToList().Exists(x => x.Dt_historico > lStatusTicket.FirstOrDefault(v => v.Id_ticket == s.Id_ticket).Dt_etapa))
                                    {
                                        StringBuilder msg = new StringBuilder();
                                        lHistRest.Where(x => x.Id_ticket == s.Id_ticket && x.Dt_historico > lStatusTicket.FirstOrDefault(v => v.Id_ticket == s.Id_ticket).Dt_etapa).OrderByDescending(x => x.Dt_historico).ToList().ForEach(x =>
                                                msg.AppendLine((string.IsNullOrEmpty(x.Loginoperador) ? string.Empty : x.Loginoperador.Trim()) + "|" + x.Ds_historico.Trim()));
                                        MensagemStatusTicket(lStatusTicket.FirstOrDefault(v => v.Id_ticket == s.Id_ticket),
                                                                msg.ToString(),
                                                                lHistRest.Where(x => x.Id_ticket == s.Id_ticket && x.Dt_historico > lStatusTicket.FirstOrDefault(v => v.Id_ticket == s.Id_ticket).Dt_etapa).OrderByDescending(x => x.Dt_historico).FirstOrDefault().Dt_historico);
                                        System.Threading.Thread.Sleep(Utils.Parametros.pubTmpMsgTicket > decimal.Zero ? Convert.ToInt32(Utils.Parametros.pubTmpMsgTicket) : 10000);
                                    }
                                }
                                else
                                {
                                    TCN_StatusTicket_BI.Gravar(new TRegistro_StatusTicket_BI()
                                    {
                                        Id_ticket = s.Id_ticket,
                                        Login_BI = Login_BI,
                                        Dt_etapa = lHistRest.Where(x=> x.Id_ticket == s.Id_ticket).OrderByDescending(v => v.Dt_historico).FirstOrDefault().Dt_historico
                                    }, null);
                                    lStatusTicket.Add(new TRegistro_StatusTicket_BI()
                                    {
                                        Id_ticket = s.Id_ticket,
                                        Login_BI = Login_BI,
                                        Dt_etapa = lHistRest.Where(x=> x.Id_ticket == s.Id_ticket).OrderByDescending(v => v.Dt_historico).FirstOrDefault().Dt_historico
                                    });
                                    StringBuilder msg = new StringBuilder();
                                    lHistRest.Where(x=> x.Id_ticket == s.Id_ticket).OrderByDescending(x => x.Dt_historico).ToList().ForEach(x => msg.AppendLine((string.IsNullOrEmpty(x.Loginoperador) ? string.Empty : x.Loginoperador.Trim()) + "|" + x.Ds_historico.Trim()));
                                    MensagemStatusTicket(lStatusTicket.FirstOrDefault(v => v.Id_ticket == s.Id_ticket),
                                                         msg.ToString(),
                                                         lHistRest.Where(x=> x.Id_ticket == s.Id_ticket).OrderByDescending(v => v.Dt_historico).FirstOrDefault().Dt_historico);
                                    System.Threading.Thread.Sleep(Utils.Parametros.pubTmpMsgTicket > decimal.Zero ? Convert.ToInt32(Utils.Parametros.pubTmpMsgTicket) : 10000);
                                }
                            });
                        }
                    }
                }
                catch { }
                finally
                {
                    tmpStatusTicket.Start();
                }
            }
        }
        */

        private void CriaMenus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente RE-PROCESSAR o cadastro dos MENUS? Essa operação eliminará todos os perfis de usuarios!", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(Utils.Parametros.pubPathAliance);
                System.IO.FileInfo[] lista = folder.GetFiles("*.dll");
                Int32 tam = lista.Length;
                string[] registros;
                TCN_CadMenu.DeletarTodoMenu();

                for (int x = 0; x < tam; x++)
                {
                    try
                    {
                        Assembly extAssembly = Assembly.LoadFrom(lista[x].FullName.Trim());
                        string Mod = extAssembly.ManifestModule.Name.Replace(".dll", "");

                        object extInfo = extAssembly.CreateInstance(Mod + ".TInfo");

                        string tt = extInfo.GetType().GetMethod("getInfoMenu").Invoke(extInfo, null).ToString();
                        registros = tt.Split('|');
                        for (int y = 0; y < registros.Length; y++)
                        {
                            TCN_CadMenu.GravarMenu(registros[y], extAssembly.ManifestModule.Name);
                        }

                    }
                    catch (System.IO.FileLoadException ex)
                    {
                        MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                        "O sistema não pode ler o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                        "O sistema não pode encontrar o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                    }
                }

                //RECARREGA OS DADOS DO MENU
                CarregaMenu(vlogin, true);
            }

        }

        private void bb_alterarsenha_Click(object sender, EventArgs e)
        {
            TFAlterarSenha fSenha = new TFAlterarSenha();
            try
            {
                fSenha.vLogin = Utils.Parametros.pubLogin;
                fSenha.vSenhaAtual = Utils.Parametros.pubSenha;
                fSenha.ShowDialog();
            }
            finally
            {
                fSenha.Dispose();
            }
        }

        private void bb_ConsultaRapida_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFConsultaRapida fConsulta = new Proc_Commoditties.TFConsultaRapida())
            {
                fConsulta.ShowDialog();
            }
        }

        private void tmpValidarDataServer_Tick(object sender, EventArgs e)
        {
            DateTime dt_server = new DateTime();
            if (CamadaDados.UtilData.Data_Servidor(ref dt_server))
                if (Properties.Settings.Default.DT_SERVIDOR > dt_server)
                {
                    MessageBox.Show("Data do servidor foi reconfigurada.\r\n" +
                                    "Não é permitido trabalhar com data inferior a data do ultimo acesso: " + Properties.Settings.Default.DT_SERVIDOR.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n " +
                                    "Data Atual Servidor: " + dt_server.ToString("dd/MM/yyyy HH:mm:ss"),
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(Environment.ExitCode);
                }
            //Atualizar Semafaros
            if (flpSemaforo.Visible)
            {
                tmpValidarDataServer.Enabled = false;
                if (!bgwSemafaro.IsBusy)
                    bgwSemafaro.RunWorkerAsync();
            }
        }

        private void MsgComp_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lComp.Count > 0)
            {
                tmpStatusComp.Stop();
                try
                {
                    lComp.ForEach(p =>
                    {
                        if (p.Dt_Compromisso.Value.AddMinutes(-120) <= CamadaDados.UtilData.Data_Servidor() &&
                            p.Dt_Compromisso.Value >= CamadaDados.UtilData.Data_Servidor() && p.St_Compromisso.ToUpper().Equals("A"))
                        {
                            using (TFMsgComp fMsg = new TFMsgComp())
                            {
                                fMsg.Location = new Point(930, 590);
                                fMsg.Size = new Size(350, 142);
                                fMsg.NM_Compromisso = p.Nm_Compromisso;
                                fMsg.Text = "Próximo Compromisso";
                                fMsg.DT_Comp = "HORÁRIO: " + p.Dt_Compromisso.Value.ToShortTimeString();
                                fMsg.ShowDialog();
                                if (fMsg.St_visualizarComp)
                                    using (Parametros.Diversos.TFLan_Compromisso fComp = new Parametros.Diversos.TFLan_Compromisso())
                                    {
                                        fComp.Id_Compromisso = p.ID_Compromisso_String;
                                        if (MessageBox.Show("Deseja ENCERRAR o Compromisso?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            p.St_Compromisso = "E";
                                            CamadaNegocio.Diversos.TCN_LanCompromisso.Gravar(p, null);
                                        }
                                        fComp.ShowDialog();
                                    }
                            }
                        }
                    });
                }
                catch { }
                finally
                {
                    tmpStatusComp.Start();
                }
            }
        }

        private void bbCompAtivos_Click(object sender, EventArgs e)
        {
            using (Parametros.Diversos.TFLan_Compromisso Comp = new Parametros.Diversos.TFLan_Compromisso())
            {
                Comp.bsCompromisso.DataSource = TCN_LanCompromisso.Busca(string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         Utils.Parametros.pubLogin,
                                                                         "A",
                                                                         null);
                Comp.ShowDialog();
            }
        }

        private void FMenuPrin_MdiChildActivate(object sender, EventArgs e)
        {
            if (sender != null)
                if ((sender as Form).MdiChildren != null)
                    for (int i = 0; i < (sender as Form).MdiChildren.Length; i++)
                        if ((sender as Form).MdiChildren[i].Visible)
                        {
                            tlpCentral.Visible = false;
                            //lAcesso.Visible = false;
                            break;
                        }
                        else
                            tlpCentral.Visible = true;
            //lAcesso.Visible = true;
        }

        private void lAcesso_DoubleClick(object sender, EventArgs e)
        {
            if (bsAcesso.Count > 0)
                EventoMenu((bsAcesso.Current as TRegistro_CadAcesso).Id_menu);
        }

        private void bb_chat_Click(object sender, EventArgs e)
        {

        }

        private void BuscarAniversarios()
        {
            decimal qtd_dias = TCN_CadParamGer.BuscaVlNumerico("DIAS_ANIVERSARIO_CLIENTE", null);
            if (qtd_dias.Equals(decimal.Zero))
                qtd_dias = 30;
            //Buscar clientes aniversariantes do mes
            lAniversariante = new CamadaDados.Financeiro.Cadastros.TCD_Aniversariante().Select(null, qtd_dias.ToString());
            lblAniversarianteNDias.Text = lAniversariante.Count.ToString();
        }

        private void bkwAniversario_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BuscarAniversarios();
        }

        private void bb_detalhesAniversariante_Click(object sender, EventArgs e)
        {
            this.BuscarAniversarios();
            if (lAniversariante.Count > 0)
                using (Proc_Commoditties.TFListaAniversariante fLista = new Proc_Commoditties.TFListaAniversariante())
                {
                    fLista.lAniversariante = lAniversariante;
                    fLista.ShowDialog();
                }
            else MessageBox.Show("Lista aniversariante vazia.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nFeNFSeNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFLanConsultaNFe fNfe = new Proc_Commoditties.TFLanConsultaNFe())
            {
                fNfe.ShowDialog();
            }
        }

        private void xMLNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFGerarXmlNfe fXmlNfe = new Proc_Commoditties.TFGerarXmlNfe())
            {
                fXmlNfe.St_nfce = false;
                fXmlNfe.ShowDialog();
            }
        }

        private void xMLNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFGerarXmlNfe fXmlNfe = new Proc_Commoditties.TFGerarXmlNfe())
            {
                fXmlNfe.St_nfce = true;
                fXmlNfe.ShowDialog();
            }
        }

        private void gerarArquivosContabilidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFGerarArqCont fArq = new TFGerarArqCont())
            {
                fArq.ShowDialog();
            }
        }

        private void flpSemaforo_VisibleChanged(object sender, EventArgs e)
        {
            tmpValidarDataServer_Tick(this, new EventArgs());
        }

        private void bbAtualizaCotação_Click(object sender, EventArgs e)
        {
            if (bsPrecoCommodities.Current != null)
                using (Proc_Commoditties.TFCotacaoCommodities fCotacao = new Proc_Commoditties.TFCotacaoCommodities())
                {
                    fCotacao.pCd_produto = (bsPrecoCommodities.Current as TRegistro_PrecoCommodities).Cd_produto;
                    fCotacao.pDs_produto = (bsPrecoCommodities.Current as TRegistro_PrecoCommodities).Ds_produto;
                    if (fCotacao.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_PrecoCommodities.Gravar(
                                new TRegistro_PrecoCommodities()
                                {
                                    Cd_produto = fCotacao.pCd_produto,
                                    Cd_unidade = fCotacao.pCd_unidade,
                                    Dt_preco = fCotacao.pDt_cotacao,
                                    Vl_precocompra = fCotacao.pVl_precocompra,
                                    Vl_precovenda = fCotacao.pVl_precovenda
                                }, null);
                            MessageBox.Show("Cotação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsPrecoCommodities.DataSource = new TCD_PrecoCommodities().SelectProdCotacao(string.Empty, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bbConexao_Click(object sender, EventArgs e)
        {

        }

        private void bgwSemafaro_DoWork(object sender, DoWorkEventArgs e)
        {
            tb_semafaro = new CamadaDados.TDataQuery().ExecutarBusca(
                                        "select " +
                                        "qtd_nfe = (select count(*) " +
                                        "			from TB_FAT_NOTAFISCAL a " +
                                        "			inner join tb_fat_serienf b " +
                                        "			on a.nr_serie = b.nr_serie " +
                                        "			and a.cd_modelo = b.cd_modelo " +
                                        "			inner join tb_div_empresa c " +
                                        "			on a.cd_empresa = c.cd_empresa " +
                                        "			where a.CD_Modelo = '55' " +
                                        "			and (isnull(a.st_registro, 'A') <> 'C' ) " +
                                        "			and (a.tp_nota = 'P' ) " +
                                        "			and (b.tp_serie = 'P' or b.tp_serie = 'M') " +
                                        "			and isnull(c.st_registro, 'A') <> 'C' " +
                                        "           and not exists(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                        "                           where x.cd_empresa = a.cd_empresa " +
                                        "                           and x.nr_lanctofiscal = a.nr_lanctofiscal)), " +
                                        "qtd_nfeA = (select count(*) " +
                                                    "from tb_fat_lotenfe_x_notafiscal a " +
                                                    "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 302), " +
                                        "qtd_nfce = (select count(*) " +
                                        "			from tb_pdv_nfce a " +
                                        "			inner join tb_div_empresa b " +
                                        "			on a.cd_empresa = b.cd_empresa " +
                                        "			where isnull(b.ST_Registro, 'A') <> 'C' " +
                                        "           and isnull(a.st_registro, 'A') <> 'C' " +
                                        "			and a.CD_Modelo = '65' " +
                                        "			and not exists(select 1 from TB_FAT_Lote_X_NFCe x " +
                                        "							where x.cd_empresa = a.cd_empresa " +
                                        "							and x.id_cupom = a.id_nfce)), " +
                                        "qtd_nfceA = (select count(*) " +
                                                    "from tb_fat_lote_x_nfce a " +
                                                    "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 150 and isnull(a.status, 0) <> 302), " +
                                        "qtd_nfse = (select count(*) " +
                                        "			from TB_FAT_NOTAFISCAL a " +
                                        "			inner join tb_fat_serienf b " +
                                        "			on a.nr_serie = b.nr_serie " +
                                        "			and a.cd_modelo = b.cd_modelo " +
                                        "			inner join tb_div_empresa c " +
                                        "			on a.cd_empresa = c.cd_empresa " +
                                        "			where a.CD_Modelo = '55' " +
                                        "			and isnull(a.st_registro, 'A') <> 'C' " +
                                        "			and a.tp_nota = 'P' " +
                                        "			and b.tp_serie = 'S' " +
                                        "			and isnull(c.st_registro, 'A') <> 'C' " +
                                        "           and not exists(select 1 from TB_FAT_LoteRPS_x_NFES x " +
                                        "                           where x.cd_empresa = a.cd_empresa " +
                                        "                           and x.nr_lanctofiscal = a.nr_lanctofiscal)), " +
                                        "qtd_cte = (select count(*) " +
                                        "			from tb_ctr_conhecimentofrete a " +
                                        "			inner join tb_div_empresa b " +
                                        "			on a.cd_empresa = b.cd_empresa " +
                                        "			where isnull(b.ST_Registro, 'A') <> 'C' " +
                                        "			and a.TP_Emissao = 'P' " +
                                        "			and a.CD_Modelo = '57' " +
                                        "			and isnull(a.ST_Registro, 'A') <> 'C' " +
                                        "			and not exists(select 1 from tb_ctr_lote_x_cte x " +
                                        "							where x.cd_empresa = a.cd_empresa " +
                                        "							and x.nr_lanctoctr = a.nr_lanctoctr)), " +
                                        "qtd_mdfe = (select count(*) " +
                                        "			from VTB_CTR_MDFE a " +
                                        "			inner join TB_DIV_Empresa b " +
                                        "			on a.CD_Empresa = b.CD_Empresa " +
                                        "			where isnull(b.ST_Registro, 'A') <> 'C' " +
                                        "			and isnull(a.st_registro, 'A') <> 'C' " +
                                        "			and isnull(a.st_transmitido, 'N') = 'N'), " +
                                        "qtd_lmce = (select count(*) " +
                                        "			from TB_PDC_LMC a " +
                                        "			inner join TB_DIV_Empresa b " +
                                        "			on a.CD_Empresa = b.CD_Empresa " +
                                        "			where isnull(b.ST_Registro, 'A') <> 'C' " +
                                        "			and isnull(a.nprot, '') = '') ", null);
        }

        private void bgwSemafaro_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (tb_semafaro != null)
                if (tb_semafaro.Rows.Count > 0)
                {
                    //NFe
                    if (pNFe.Visible)
                    {
                        lblNFe.Text = tb_semafaro.Rows[0]["qtd_nfe"].ToString();
                        lblNFe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfe"].ToString() != "0" ? 0 : 1;
                        lblNFeAceita.Text = tb_semafaro.Rows[0]["qtd_nfeA"].ToString();
                        lblNFeAceita.ImageIndex = tb_semafaro.Rows[0]["qtd_nfeA"].ToString() != "0" ? 0 : 1;
                    }
                    //NFCe
                    if (pNFCe.Visible)
                    {
                        lblNFCe.Text = tb_semafaro.Rows[0]["qtd_nfce"].ToString();
                        lblNFCe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfce"].ToString() != "0" ? 0 : 1;
                        lblNFCeAceita.Text = tb_semafaro.Rows[0]["qtd_nfceA"].ToString();
                        lblNFCeAceita.ImageIndex = tb_semafaro.Rows[0]["qtd_nfceA"].ToString() != "0" ? 0 : 1;
                    }
                    //NFSe
                    if (pNFSe.Visible)
                    {
                        lblNFSe.Text = tb_semafaro.Rows[0]["qtd_nfse"].ToString();
                        lblNFSe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfse"].ToString() != "0" ? 0 : 1;
                    }
                    //CTe
                    if (pCTe.Visible)
                    {
                        lblCTe.Text = tb_semafaro.Rows[0]["qtd_cte"].ToString();
                        lblCTe.ImageIndex = tb_semafaro.Rows[0]["qtd_cte"].ToString() != "0" ? 0 : 1;
                    }
                    //MDFe
                    if (pMDFe.Visible)
                    {
                        lblMDFe.Text = tb_semafaro.Rows[0]["qtd_mdfe"].ToString();
                        lblMDFe.ImageIndex = tb_semafaro.Rows[0]["qtd_mdfe"].ToString() != "0" ? 0 : 1;
                    }
                    //LMCe
                    if (pLMCe.Visible)
                    {
                        lblLMCe.Text = tb_semafaro.Rows[0]["qtd_lmce"].ToString();
                        lblLMCe.ImageIndex = tb_semafaro.Rows[0]["qtd_lmce"].ToString() != "0" ? 0 : 1;
                    }
                }
            tmpValidarDataServer.Start();
        }

        private void conexãoRemotaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void suporteOnLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tawk.to/chat/5941999350fd5105d0c8110e/1bjsuk5jp/?$_tawk_popout=true");
        }

        private void consultarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Help.TFCentralHelpDesk fCentral = new Help.TFCentralHelpDesk())
            {
                fCentral.ShowDialog();
            }
        }

        private void abrirTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar login
                TList_CadUsuario lUser = TCN_CadUsuario.Busca(Utils.Parametros.pubLogin, string.Empty, string.Empty, null);
                string LoginCliente = string.Empty;
                string Id_cliente = string.Empty;
                bool st_login = true;
                if (lUser.Count > 0)
                    if ((!string.IsNullOrEmpty(lUser[0].Login_BI)) && (!string.IsNullOrEmpty(lUser[0].Senha_BI)))
                    {
                        LoginCliente = lUser[0].Login_BI;
                        Id_cliente = ServiceRest.DataService.ValidarLogin(
                            TCN_CadEmpresa.Busca(string.Empty, string.Empty, "A", null),
                            lUser[0].Login_BI, 
                            lUser[0].Senha_BI);
                        if (!string.IsNullOrWhiteSpace(Id_cliente))
                            st_login = false;
                    }
                if (st_login)
                    using (Help.TFLoginHelpDesk fLogin = new Help.TFLoginHelpDesk())
                    {
                        if (fLogin.ShowDialog() == DialogResult.OK)
                        {
                            LoginCliente = fLogin.Login;
                            Id_cliente = fLogin.Id_cliente;
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar login para abrir ticket.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                if (!string.IsNullOrWhiteSpace(LoginCliente) && !string.IsNullOrWhiteSpace(Id_cliente))
                    using (Help.TFTicket fTicket = new Help.TFTicket())
                    {
                        fTicket.LoginCliente = LoginCliente;
                        fTicket.Id_cliente = Id_cliente;
                        fTicket.ShowDialog();
                    }
                else MessageBox.Show("Login invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}