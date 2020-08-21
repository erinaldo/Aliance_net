using System;
using Utils;
using System.Windows.Forms;

namespace Fiscal
{
    public partial class TFLanSpedFiscal : Form
    {
        public TFLanSpedFiscal()
        {
            InitializeComponent();
            //Preencher combo ano
            for (int i = -10; i < 11; i++)
                cbAno.Items.Add(DateTime.Now.Year + i);
            cbAno.Text = DateTime.Now.Year.ToString();
            //Preencher Combo Mes
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("JANEIRO", "1"));
            cbx.Add(new TDataCombo("FEVEREIRO", "2"));
            cbx.Add(new TDataCombo("MARÇO", "3"));
            cbx.Add(new TDataCombo("ABRIL", "4"));
            cbx.Add(new TDataCombo("MAIO", "5"));
            cbx.Add(new TDataCombo("JUNHO", "6"));
            cbx.Add(new TDataCombo("JULHO", "7"));
            cbx.Add(new TDataCombo("AGOSTO", "8"));
            cbx.Add(new TDataCombo("SETEMBRO", "9"));
            cbx.Add(new TDataCombo("OUTUBRO", "10"));
            cbx.Add(new TDataCombo("NOVEMBRO", "11"));
            cbx.Add(new TDataCombo("DEZEMBRO", "12"));
            cbMes.DataSource = cbx;
            cbMes.DisplayMember = "Display";
            cbMes.ValueMember = "Value";
            cbMes.SelectedValue = DateTime.Now.AddMonths(-1).Month.ToString();
        }

        private void GerarArquivo()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(path_sped.Text))
            {
                MessageBox.Show("Obrigatorio informar path para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_sped.Focus();
                return;
            }
            ThreadEspera tEspera = new ThreadEspera("Iniciando procedimento gerar SPED FISCAL...");
            try
            {
                if (!System.IO.Directory.Exists(path_sped.Text))
                    System.IO.Directory.CreateDirectory(path_sped.Text);
                string arq = CamadaNegocio.Fiscal.SPED_FISCAL.TCN_SpedFiscal.ProcessarSpedFiscal(cbEmpresa.SelectedValue.ToString(),
                                                                                                 new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1),
                                                                                                 new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59),
                                                                                                 rb_Original.Checked ? "O" : rb_Substituto.Checked ? "S" : string.Empty,
                                                                                                 tEspera);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path_sped.Text + "\\efd" +
                                                                              cbEmpresa.SelectedValue.ToString().Trim() +
                                                                              cbMes.SelectedValue.ToString() +
                                                                              cbAno.Text + ".txt",
                                                                              false,
                                                                              System.Text.Encoding.Default))
                {
                    sw.Write(arq + "\r\n");
                    sw.Close();
                    MessageBox.Show("Arquivo Sped Fiscal gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TFLanSpedFiscal_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            path_sped.Text = Properties.Settings.Default.PATH_SPED;
            rb_Original.Checked = true;
        }

        private void BB_GerarFiscal_Click(object sender, EventArgs e)
        {
            GerarArquivo();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = path_sped.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_sped.Text = fbd.SelectedPath.Trim();
            }
        }

        private void TFLanSpedFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanSpedFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                GerarArquivo();
        }
    }
}
