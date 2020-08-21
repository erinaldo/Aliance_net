using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace AlianceAtualiza
{
    public partial class TFAtualiza : Form
    {

        private string Arquivo { get; set; }
        public TFAtualiza()
        {
            InitializeComponent();
        }

        private void Atualiza(string arquivo)
        {

            if (!System.IO.Directory.Exists("C:\\Aliance.NET\\Versao\\Dll"))
                System.IO.Directory.CreateDirectory("C:\\Aliance.NET\\Versao\\Dll");

            //Verificar se existe arquivos .ali
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("c:\\aliance.net\\Versao\\Dll");
            foreach (System.IO.FileInfo file in dir.GetFiles("*.ali"))
                if (file.Name.Substring(file.Name.LastIndexOf('.') + 1, 3).Trim().Equals("ali"))
                    System.IO.File.Delete(file.DirectoryName + "\\" + file.Name);
            lblMsg.Items.Add("Fazendo Download Versão " + arquivo.Substring(0, arquivo.IndexOf('.')));


            // download
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(Properties.Settings.Default.servidorFTP + "/" + arquivo);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential(Properties.Settings.Default.loginFTP, Properties.Settings.Default.senhaFTP);
            req.UsePassive = true;
            req.UseBinary = true;
            req.KeepAlive = true;


            // busca tamanho do arquivo
            FtpWebRequest ftpsize = (FtpWebRequest)WebRequest.Create(Properties.Settings.Default.servidorFTP + "/" + arquivo);
            ftpsize.Method = WebRequestMethods.Ftp.GetFileSize;
            ftpsize.Credentials = new NetworkCredential(Properties.Settings.Default.loginFTP, Properties.Settings.Default.senhaFTP);
            ftpsize.UsePassive = true;
            ftpsize.UseBinary = true;
            ftpsize.KeepAlive = true;
            FtpWebResponse respsize = (FtpWebResponse)ftpsize.GetResponse();


            FtpWebResponse resp = (FtpWebResponse)req.GetResponse();
            byte[] buffer = new byte[2048];
            if (!System.IO.Directory.Exists("c:\\aliance.net\\Versao\\Dll"))
                System.IO.Directory.CreateDirectory("c:\\aliance.net\\Versao\\Dll");
            System.IO.FileStream newFile = new System.IO.FileStream("c:\\aliance.net\\Versao\\Dll\\" + arquivo, System.IO.FileMode.Create);
            System.IO.Stream responseStream = resp.GetResponseStream();
            int readCount = responseStream.Read(buffer, 0, buffer.Length);
            progressBar1.Maximum = (int)respsize.ContentLength;
            progressBar1.Visible = (int)respsize.ContentLength == 0 ? false : true;
            while (readCount > 0)
            {
                progressBar1.Value = (int)newFile.Length;

                newFile.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, buffer.Length);
            }
            lblMsg.Items.Add("Download efetuado com sucesso! ");
            newFile.Close();
            responseStream.Close();
            resp.Close();
            //Verificar se existe alguma instancia do Aliance Aberta
            foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Aliance.NET"))
            {
                p.Kill();
                p.WaitForExit();
            }
            //Descompactar arquivo
            using (Ionic.Utils.Zip.ZipFile zip = Ionic.Utils.Zip.ZipFile.Read("c:\\aliance.net\\Versao\\Dll\\" + arquivo))
            {
                zip.ExtractAll("c:\\aliance.net\\Versao\\Dll", true);
            }
            Properties.Settings.Default.versaoAliance = decimal.Parse(arquivo.Substring(0, arquivo.IndexOf('.')));
            Properties.Settings.Default.Save();
        }
        
        private void VerificaAtualiza()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.servidorFTP) ||
                string.IsNullOrEmpty(Properties.Settings.Default.loginFTP) ||
                string.IsNullOrEmpty(Properties.Settings.Default.senhaFTP))
            {
                lblMsg.Items.Add("Necessário configurar SERVIDOR...");
                return;
            }
            string erro = string.Empty;
            //Verificar se existe versao disponivel no servidor
            try
            {
                string arquivo = string.Empty;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Properties.Settings.Default.servidorFTP);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Properties.Settings.Default.loginFTP, Properties.Settings.Default.senhaFTP);
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
                    Properties.Settings.Default.versaoAliance <
                            decimal.Parse(arquivo.Substring(0, arquivo.IndexOf('.'))))
                {

                    
                    lblMsg.Items.Add("Existe nova versão disponivel para download...");
                    MessageBox.Show("Versão Nº" + decimal.Parse(arquivo.Substring(0, arquivo.IndexOf('.'))) + " está disponivel para download.\r\n" +
                                    "O sistema Aliance.NET será atualizado automaticamente!", 
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Arquivo = arquivo;
                    Show();
                    Atualiza(arquivo);
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message.Trim() + "\r\n" + "Deseja corrigir configuração servidor?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    lblConfigServidor_Click(this, new EventArgs());
            }
            finally
            {
                if (System.IO.File.Exists("c:\\aliance.net\\Versao\\Dll\\Aliance.NET.exe"))
                {
                    System.Diagnostics.Process.Start("c:\\aliance.net\\Versao\\Dll\\Aliance.NET.exe",
                                                     Properties.Settings.Default.servidorFTP + "|" +
                                                     Properties.Settings.Default.loginFTP + "|" +
                                                     Properties.Settings.Default.senhaFTP + "|" +
                                                     Properties.Settings.Default.versaoAliance.ToString());
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        private void lblConfigServidor_Click(object sender, EventArgs e)
        {
            using (TFConfig fConfig = new TFConfig())
            {
                fConfig.ShowDialog();
                VerificaAtualiza();
            }
        }

        private void TFAtualiza_Load(object sender, EventArgs e)
        {
            lblVersao.Text = Properties.Settings.Default.versaoAliance.ToString();
            VerificaAtualiza();
        }

        private void lblConfigServidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VerificaAtualiza();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VerificaAtualiza();
        }
    }
}
