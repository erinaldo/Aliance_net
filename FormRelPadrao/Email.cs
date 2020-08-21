using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using OutLook = Microsoft.Office.Interop.Outlook;

namespace FormRelPadrao
{
    public class Email
    {
        public string Remetente
        { get; set; }
        public List<string> Destinatario
        { get; set; }
        public string Titulo
        { get; set; }
        public string Mensagem
        { get; set; }
        public List<string> Anexo
        { get; set; }
        public string Smtp
        { get; set; }
        public int Porta_smtp
        { get; set; }
        public decimal? Id_TpData
        { get; set; }
        public bool St_html
        { get; set; }

        public Email()
        {
            Remetente = string.Empty;
            Destinatario = new List<string>();
            Titulo = string.Empty;
            Mensagem = string.Empty;
            Anexo = new List<string>();
            Smtp = string.Empty;
            Porta_smtp = 0;
        }

        public Email(List<string> vDestinatario,
                     string vTitulo,
                     string vMensagem,
                     List<string> vAnexo)
        {
            Destinatario = vDestinatario;
            Titulo = vTitulo;
            Mensagem = vMensagem;
            Anexo = vAnexo;
        }

        public Email(List<string> vDestinatario,
                     string vTitulo,
                     string vMensagem,
                     List<string> vAnexo,
                     bool vSt_html)
        {
            Destinatario = vDestinatario;
            Titulo = vTitulo;
            Mensagem = vMensagem;
            Anexo = vAnexo;
            St_html = vSt_html;
        }

        public bool EnviarEmail()
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVl_BoolTerminal("ST_ENVIAR_EMAIL_OUTLOOK", Utils.Parametros.pubTerminal, null))
            {
                if (Destinatario.Count > 0)
                    try
                    {
                        if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count().Equals(0))
                        {
                            System.Diagnostics.ProcessStartInfo inf = new System.Diagnostics.ProcessStartInfo("OUTLOOK");
                            inf.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                            System.Diagnostics.Process.Start(inf);
                        }
                        OutLook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                        OutLook.MailItem oMsg = oApp.CreateItem(OlItemType.olMailItem) as OutLook.MailItem;
                        //Titulo do email
                        oMsg.Subject = Titulo.Trim();
                        //Assinatura do usuário
                        object usu = new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.login",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                }
                                            }, "a.nome_usuario");
                        if (usu != null && !string.IsNullOrEmpty(usu.ToString()))
                            Mensagem = Mensagem.Trim() + "\n\n\n Ass.: " + usu;

                        //Mensagem do email
                        oMsg.HTMLBody = Mensagem.Trim();
                        if (Anexo.Count > 0)
                        {
                            int posicao = oMsg.Body.Length + 1;
                            int iAnexo = Convert.ToInt32(OutLook.OlAttachmentType.olByValue);
                            int cont = 1;
                            foreach (string a in Anexo)
                                oMsg.Attachments.Add(a, iAnexo, posicao, "Anexo" + (cont++).ToString());
                        }

                        //Destinatario
                        OutLook.Recipients r = oMsg.Recipients;
                        foreach (string d in Destinatario)
                        {
                            OutLook.Recipient oR = r.Add(d);
                            oR.Resolve();
                        }
                        //Enviar email
                        oMsg.Send();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Erro enviar email: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                else
                    return false;
            }
            else
            {
                //Objeto Email
                System.Net.Mail.MailMessage objemail = new System.Net.Mail.MailMessage();
                //Remetente do Email
                Remetente = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("EMAIL_PADRAO", null).Trim().ToLower();
                if (string.IsNullOrEmpty(Remetente))
                {
                    MessageBox.Show("Não existe email padrão configurado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_COPIA_EMAIL", string.Empty, null).Trim().ToUpper().Equals("S"))
                {
                    object obj = new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.login",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                    }
                                }, "a.email_padrao");
                    if (obj != null)
                        objemail.Bcc.Add(obj.ToString());
                }
                objemail.From = new System.Net.Mail.MailAddress(Remetente.Trim().ToLower());
                //Destinatario do Email
                if (Destinatario.Count < 1)
                {
                    MessageBox.Show("Obrigatorio informar destinatario para enviar email.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                foreach (string d in Destinatario)
                    objemail.To.Add(new System.Net.Mail.MailAddress(d.Trim().ToLower()));
                //Titulo do Email
                if (Titulo.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar titulo para enviar email.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                objemail.Subject = Titulo.Trim();
                //Assinatura do usuário
                object usu = new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.login",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                    }
                                }, "a.nome_usuario");
                if (usu != null && !string.IsNullOrEmpty(usu.ToString()))
                    Mensagem = Mensagem.Trim() + "\n\n\n Ass.: " + usu;
                //Mensagem do Email
                objemail.Body = Mensagem.Trim();
                //Html
                objemail.IsBodyHtml = St_html;
                //Anexos do email
                foreach (string str in Anexo)
                    objemail.Attachments.Add(new System.Net.Mail.Attachment(str.Trim()));
                //Configurar objeto SMTP
                Smtp = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("SERVIDOR_SMTP", Utils.Parametros.pubTerminal, null);
                if (Smtp.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Não existe configuração de servidor smtp para o terminal " + Utils.Parametros.pubTerminal.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                System.Net.Mail.SmtpClient objsmtp = new System.Net.Mail.SmtpClient();
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("CONEXAO_SSL_SMTP", null))
                    objsmtp.EnableSsl = true;
                objsmtp.Credentials = new System.Net.NetworkCredential(CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("EMAIL_PADRAO", null).Trim().ToLower(),
                                                                       CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("SENHA_EMAIL", null).Trim().ToLower());
                objsmtp.Host = Smtp.Trim().ToLower();
                //Configurar porta smtp
                Porta_smtp = Convert.ToInt32(CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("PORTA_SMTP", Utils.Parametros.pubTerminal, null));
                if (Porta_smtp < 1)
                {
                    MessageBox.Show("Não existe configuração de porta smtp para o terminal " + Utils.Parametros.pubTerminal.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                objsmtp.Port = Porta_smtp;
                //Criar metodo email enviado
                objsmtp.SendCompleted += new System.Net.Mail.SendCompletedEventHandler(objsmtp_SendCompleted);
                //Enviar Email
                try
                {
                    objsmtp.SendAsync(objemail, "Email enviado com sucesso");
                    return true;
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Erro enviar email: " + ex.Message.Trim());
                }
                finally
                {
                    objsmtp = null;
                }
            }
        }

        void objsmtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                //Gravar LogEmail
                try
                {
                    string anx = string.Empty;
                    string virg = string.Empty;
                    Anexo.ForEach(p =>
                        {
                            anx += virg + p.Trim();
                            virg = ";";
                        });
                    string dest = string.Empty;
                    virg = string.Empty;
                    Destinatario.ForEach(p =>
                    {
                        dest += virg + p.Trim();
                        virg = ";";
                    });
                    CamadaNegocio.Diversos.TCN_CadLogEmail.Gravar(new CamadaDados.Diversos.TRegistro_CadlogEmail()
                    {
                        Anexo = anx,
                        DS_Destinatario = dest,
                        DS_Titulo = Titulo.Trim(),
                        Loginremetente = Utils.Parametros.pubLogin,
                        Mensagem = Mensagem,
                        Id_TpData = Id_TpData,
                        Dt_email = CamadaDados.UtilData.Data_Servidor()
                    }, null);
                }
                catch
                { }
            else
            {
                (sender as System.Net.Mail.SmtpClient).SendAsyncCancel();
                string destinatario = string.Empty;
                string virg = string.Empty;
                Destinatario.ForEach(p => { destinatario += virg + p.Trim(); virg = ","; });
                MessageBox.Show("Erro enviar email.\r\nDestinatario: " + destinatario.Trim() + "\r\n" +
                                "Erro: " + e.Error.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
