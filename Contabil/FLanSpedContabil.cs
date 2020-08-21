using System;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFLanSpedContabil : Form
    {
        public TFLanSpedContabil()
        {
            InitializeComponent();
        }

        private void GerarArquivo()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ini.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_fin.Focus();
                return;
            }
            if (cbDRE.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório informar DRE.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbDRE.Focus();
                return;
            }
            if (string.IsNullOrEmpty(path_sped.Text))
            {
                MessageBox.Show("Obrigatorio informar path para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_sped.Focus();
                return;
            }
            
            ThreadEspera tEspera = new ThreadEspera("Iniciando procedimento gerar SPED CONTABIL...");
            try
            {
                if (!System.IO.Directory.Exists(path_sped.Text))
                    System.IO.Directory.CreateDirectory(path_sped.Text);
                string arq = CamadaNegocio.Contabil.SPED_CONTABIL.TCN_SpedContabil.ProcessarSpedContabil(cbEmpresa.SelectedValue.ToString(),
                                                                                                         DateTime.Parse(dt_ini.Text),
                                                                                                         DateTime.Parse(dt_fin.Text),
                                                                                                         decimal.Parse(cbDRE.SelectedValue.ToString()),
                                                                                                         tEspera);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path_sped.Text + "\\ecd" +
                                                                              cbEmpresa.SelectedValue.ToString() +
                                                                              dt_ini.Text.Substring(6, 4) + ".txt",
                                                                              false,
                                                                              System.Text.Encoding.Default))
                {
                    sw.Write(arq + "\r\n");
                    sw.Close();
                    MessageBox.Show("Arquivo Sped CONTABIL gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                tEspera.Fechar();
                tEspera = null;
            }
        }

        private void TFLanSpedContabil_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbDRE.DataSource = CamadaNegocio.Contabil.Cadastro.TCN_CTB_DRE.Buscar(string.Empty, string.Empty, null);
            cbDRE.DisplayMember = "DS_DRE";
            cbDRE.ValueMember = "ID_DRE";
            path_sped.Text = Properties.Settings.Default.PATH_SPEDCONTABIL;
        }

        private void TFLanSpedContabil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_sped.Text = fbd.SelectedPath.Trim();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_GerarFiscal_Click(object sender, EventArgs e)
        {
            this.GerarArquivo();
        }

        private void TFLanSpedContabil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarArquivo();
        }
    }
}
