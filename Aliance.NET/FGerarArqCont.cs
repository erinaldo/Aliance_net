using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ionic.Utils.Zip;

namespace Aliance.NET
{
    public partial class TFGerarArqCont : Form
    {
        public TFGerarArqCont()
        {
            InitializeComponent();
            //Preencher combo ano
            for (int i = -10; i < 11; i++)
                cbAno.Items.Add(DateTime.Now.Year + i);
            cbAno.Text = DateTime.Now.AddMonths(-1).Year.ToString();
            //Preencher Combo Mes
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("JANEIRO", "1"));
            cbx.Add(new Utils.TDataCombo("FEVEREIRO", "2"));
            cbx.Add(new Utils.TDataCombo("MARÇO", "3"));
            cbx.Add(new Utils.TDataCombo("ABRIL", "4"));
            cbx.Add(new Utils.TDataCombo("MAIO", "5"));
            cbx.Add(new Utils.TDataCombo("JUNHO", "6"));
            cbx.Add(new Utils.TDataCombo("JULHO", "7"));
            cbx.Add(new Utils.TDataCombo("AGOSTO", "8"));
            cbx.Add(new Utils.TDataCombo("SETEMBRO", "9"));
            cbx.Add(new Utils.TDataCombo("OUTUBRO", "10"));
            cbx.Add(new Utils.TDataCombo("NOVEMBRO", "11"));
            cbx.Add(new Utils.TDataCombo("DEZEMBRO", "12"));
            cbMes.DataSource = cbx;
            cbMes.DisplayMember = "Display";
            cbMes.ValueMember = "Value";
            cbMes.SelectedValue = DateTime.Now.AddMonths(-1).Month.ToString();

            email.CharacterCasing = CharacterCasing.Lower;
        }

        private void GerarArquivos()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecinar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (!cbNFe.Checked &&
                !cbNFCe.Checked &&
                !cbRelNFCe.Checked &&
                !cbRelNFe.Checked)
            {
                MessageBox.Show("Obrigatório selecionar pelo menos uma opção para gerar informações.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(path.Text))
            {
                MessageBox.Show("Obrigatório informar path salvar arquivos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path.Focus();
                return;
            }
            List<string> anexos = new List<string>();
            CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe = null;
            if (cbNFe.Checked)
            {
                if (rCfgNfe == null)
                    rCfgNfe = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null)[0];
                //Gerar XML NFe
                //Limpar diretorio path arquivo
                if (System.IO.Directory.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                    try
                    {
                        System.IO.Directory.Delete(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"), true);
                    }
                    catch
                    {
                        MessageBox.Show("Diretório esta sendo utilizado por outro programa <" + path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ">");
                        return;
                    }
                System.IO.Directory.CreateDirectory(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                try
                {
                    string msg = srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                                               string.Empty,
                                                                               new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("dd/MM/yyyy"),
                                                                               new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("dd/MM/yyyy"),
                                                                               cbEmpresa.SelectedValue.ToString(),
                                                                               string.Empty,
                                                                               rCfgNfe);
                    //Compactar Arquivos
                    ZipFile zip = new ZipFile(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                    foreach (System.IO.FileInfo file in dir.GetFiles())
                        if (file.Name.Substring(file.Name.LastIndexOf('.') + 1, 3).Trim().Equals("xml"))
                            zip.AddFile(file.DirectoryName + "\\" + file.Name, string.Empty);
                    zip.Save();
                    if(System.IO.File.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip"))
                        anexos.Add(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            if (cbRelNFe.Checked)
            {
                //Gerar Rel Vendas NFe
                //Limpar diretorio path arquivo
                if (System.IO.Directory.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                    try
                    {
                        System.IO.Directory.Delete(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"), true);
                    }
                    catch
                    {
                        MessageBox.Show("Diretório esta sendo utilizado por outro programa <" + path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ">");
                        return;
                    }
                System.IO.Directory.CreateDirectory(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanFaturamento";
                Relatorio.NM_Classe = "TFLanFaturamento";
                Relatorio.Ident = "TFLanFaturamento_Visualizar_NotasFiscais";
                BindingSource bsNota = new BindingSource();
                bsNota.DataSource = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(cbEmpresa.SelectedValue.ToString(),
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               0,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               true,
                                                               string.Empty,
                                                               string.Empty,
                                                               "S",
                                                               "N",
                                                               string.Empty,
                                                               string.Empty,
                                                               new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("dd/MM/yyyy"),
                                                               new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("dd/MM/yyyy HH:mm:ss"),
                                                               decimal.Zero,
                                                               decimal.Zero,
                                                               string.Empty,
                                                               "'P'",
                                                               string.Empty,
                                                               false,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               0,
                                                               string.Empty, null);
                BindingSource bsInut = new BindingSource();
                bsInut.DataSource =
                    new CamadaDados.Faturamento.Cadastros.TCD_SeqInutNFe().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_modelo",
                                vOperador = "=",
                                vVL_Busca = "'55'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.NR_Protocolo",
                                vOperador = "is not",
                                vVL_Busca = "null"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.dh_processamento",
                                vOperador = "between",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and " +
                                            "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("yyyyMMdd HH:mm:ss") + "'"
                            }
                        }, 0, string.Empty);

                Relatorio.DTS_Relatorio = bsNota;
                Relatorio.Adiciona_DataSource("INUTILIZADOS", bsInut);
                Relatorio.Gera_Relatorio(string.Empty,
                                         false,
                                         false,
                                         false,
                                         true,
                                         path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf",
                                         null,
                                         null,
                                         "RELATÓRIO DE NFe",
                                         string.Empty);
                if (System.IO.File.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"))
                    anexos.Add(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            }

            if (cbNFCe.Checked)
            {
                if (rCfgNfe == null)
                    rCfgNfe = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null)[0];
                //Gerar XML NFCe
                //Limpar diretorio path arquivo
                if (System.IO.Directory.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                    try
                    {
                        System.IO.Directory.Delete(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"), true);
                    }
                    catch
                    {
                        MessageBox.Show("Diretório esta sendo utilizado por outro programa <" + path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ">");
                        return;
                    }
                System.IO.Directory.CreateDirectory(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                try
                {
                    string msg = NFCe.GerarXML.TGerarXML.GerarXMLPeriodo(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                                         string.Empty,
                                                                         new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("dd/MM/yyyy"),
                                                                         new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("dd/MM/yyyy HH:mm:ss"),
                                                                         cbEmpresa.SelectedValue.ToString(),
                                                                         string.Empty);
                    //Compactar Arquivos
                    ZipFile zip = new ZipFile(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                    foreach (System.IO.FileInfo file in dir.GetFiles())
                        if (file.Name.Substring(file.Name.LastIndexOf('.') + 1, 3).Trim().Equals("xml"))
                            zip.AddFile(file.DirectoryName + "\\" + file.Name, string.Empty);
                    zip.Save();
                    if(System.IO.File.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip"))
                        anexos.Add(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "NFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            if (cbRelNFCe.Checked)
            {
                //Gerar Rel Vendas NFCe
                //Limpar diretorio path arquivo
                if (System.IO.Directory.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                    try
                    {
                        System.IO.Directory.Delete(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"), true);
                    }
                    catch
                    {
                        MessageBox.Show("Diretório esta sendo utilizado por outro programa <" + path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ">");
                        return;
                    }
                System.IO.Directory.CreateDirectory(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFConsultaNFCe";
                Relatorio.NM_Classe = "TFConsultaNFCe";
                Relatorio.Ident = "TFConsultaNFCe";
                BindingSource bsVenda = new BindingSource();
                bsVenda.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(string.Empty,
                                                                                   string.Empty,
                                                                                   cbEmpresa.SelectedValue.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd"),
                                                                                   new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("yyyyMMdd HH:mm:ss"),
                                                                                   decimal.Zero,
                                                                                   decimal.Zero,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   true,
                                                                                   string.Empty,
                                                                                   "'A'",
                                                                                   0,
                                                                                   null);
                BindingSource bsInutilizadas = new BindingSource();
                bsInutilizadas.DataSource =
                    new CamadaDados.Faturamento.Cadastros.TCD_SeqInutNFe().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_modelo",
                                vOperador = "=",
                                vVL_Busca = "'65'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.NR_Protocolo",
                                vOperador = "is not",
                                vVL_Busca = "null"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.dh_processamento",
                                vOperador = "between",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and " +
                                            "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59).ToString("yyyyMMdd HH:mm:ss") + "'"
                            }
                        }, 0, string.Empty);
                Relatorio.DTS_Relatorio = bsVenda;
                Relatorio.Adiciona_DataSource("INUTILIZADOS", bsInutilizadas);
                Relatorio.Gera_Relatorio(string.Empty,
                                         false,
                                         false,
                                         false,
                                         true,
                                         path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf",
                                         null,
                                         null,
                                         "RELATÓRIO DE VENDAS NFCe",
                                         string.Empty);
                if(System.IO.File.Exists(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"))
                    anexos.Add(path.Text + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + "RELNFCe" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            }
            if (string.IsNullOrEmpty(email.Text))
                MessageBox.Show("Arquivos gerados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    new FormRelPadrao.Email(email.Text.Split(new char[] { ';' }).ToList(),
                                            "Faturamento " + cbEmpresa.Text,
                                            "Segue anexo movimento fiscal do periodo <b>" + cbMes.Text.Trim() + " de " + cbAno.Text + "</b>\r\n" +
                                            "Empresa <b>" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa.Trim() + "</b>",
                                            anexos,
                                            true).EnviarEmail();
                    MessageBox.Show("Email enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFGerarArqCont_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
            path.Text = Properties.Settings.Default.PATH_ARQ;
            email.Text = Properties.Settings.Default.EmailContador;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFGerarArqCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = path.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                    path.Text = fbd.SelectedPath.Trim();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.GerarArquivos();
        }

        private void TFGerarArqCont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarArquivos();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_clifor_contador.Trim() + "'"
                                    }
                                }, "a.email");
                if (obj != null)
                    email.Text = obj.ToString();
            }
        }
    }
}
