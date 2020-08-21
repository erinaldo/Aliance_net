using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFBackup : Form
    {
        public TFBackup()
        {
            InitializeComponent();
        }

        private void GerarBackup()
        {
            if (string.IsNullOrEmpty(nm_arquivo_backup.Text))
            {
                MessageBox.Show("Obrigatorio informar caminho para salvar arquivo backup.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_arquivo_backup.Focus();
                return;
            }
            if (!System.IO.Directory.Exists(nm_arquivo_backup.Text))
            {
                MessageBox.Show("Caminho inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_arquivo_backup.Focus();
                return;
            }
            if (st_enviaremail.Checked)
            {
                if (string.IsNullOrEmpty(nm_servidor_ftp.Text))
                {
                    MessageBox.Show("Obrigatorio informar servidor de ftp para enviar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nm_servidor_ftp.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(usuario_ftp.Text))
                {
                    MessageBox.Show("Obrigatorio informar usuario ftp para enviar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usuario_ftp.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(senha_ftp.Text))
                {
                    MessageBox.Show("Obrigatorio informar senha ftp para enviar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    senha_ftp.Focus();
                    return;
                }
            }
            string comando = "BACKUP DATABASE [" + Utils.Parametros.pubNM_BancoDados + "] " + 
                             "TO DISK = N'" + nm_arquivo_backup.Text.Trim() + "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK' " +
                             "WITH NOFORMAT, INIT, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            try
            {
                //Criar arquivo de backup
                new CamadaDados.TDataQuery().executarSql(comando, null);
                if (st_compactar.Checked)
                {
                    //Compactar arquivo
                    Utils.Compact_Data.Compactar(nm_arquivo_backup.Text.Trim() +
                                                 "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK",
                                                 nm_arquivo_backup.Text.Trim() +
                                                 "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".ZIP");
                    try
                    {
                        System.IO.File.Delete(nm_arquivo_backup.Text.Trim() +
                                                 "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK");
                    }
                    catch
                    { }
                }
                if (st_enviaremail.Checked)
                {
                    ////Enviar arquivo ftp
                    //Utils.Estruturas.EnviarFtp((st_compactar.Checked ? nm_arquivo_backup.Text.Trim() +
                    //                            "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".ZIP" :
                    //                            nm_arquivo_backup.Text.Trim() +
                    //                            "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK"),
                    //                            nm_servidor_ftp.Text,
                    //                            usuario_ftp.Text,
                    //                            senha_ftp.Text);
                    this.EnviarArquivo();
                }
                MessageBox.Show("Backup gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gerar backup: " + ex.Message.Trim());
            }
        }

        private void EnviarArquivo()
        {
            System.Net.FtpWebRequest ftpRequest;
            System.Net.FtpWebResponse ftpResponse;
            try
            {
                //define os requesitos para se conectar com o servidor
                ftpRequest = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(new Uri(nm_servidor_ftp.Text + "/" + 
                                                (st_compactar.Checked ?
                                                "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".ZIP" :
                                                "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK")));
                ftpRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                //ftpRequest.Proxy = null;
                ftpRequest.UsePassive = true;
                ftpRequest.UseBinary = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Credentials = new System.Net.NetworkCredential(usuario_ftp.Text, senha_ftp.Text);

                //Seleção do arquivo a ser enviado
                System.IO.FileInfo arquivo = new System.IO.FileInfo((st_compactar.Checked ? nm_arquivo_backup.Text.Trim() +
                                                "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".ZIP" :
                                                nm_arquivo_backup.Text.Trim() +
                                                "\\BKP_" + Utils.Parametros.pubNM_BancoDados + ".BAK"));
                byte[] fileContents = new byte[arquivo.Length];

                using (System.IO.FileStream fr = arquivo.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(arquivo.Length));
                }

                using (System.IO.Stream writer = ftpRequest.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //obtem o FtpWebResponse da operação de upload
                ftpResponse = (System.Net.FtpWebResponse)ftpRequest.GetResponse();
                MessageBox.Show(ftpResponse.StatusDescription);
            }
            catch (System.Net.WebException webex)
            {
                MessageBox.Show(webex.ToString());
            }
        }

        private void TFBackup_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDetalhes.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pFtp.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    nm_arquivo_backup.Text = fbdPath.SelectedPath.Trim();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.GerarBackup();
        }

        private void TFBackup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarBackup();
        }

        private void TFBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parametros.Properties.Settings.Default.Save();
        }
    }
}
