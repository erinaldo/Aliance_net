using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal.Sintegra;

namespace Fiscal
{
    public partial class TFLanSintegra : Form
    {
        public TFLanSintegra()
        {
            InitializeComponent();

            //Preencher combo ano
            for (int i = -10; i < 11; i++)
                cbAno.Items.Add(DateTime.Now.Year + i);
            cbAno.Text = DateTime.Now.Year.ToString();
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
            cbMes.SelectedValue = DateTime.Now.Month.ToString();
        }

        private void ImportarDominio()
        {
            if(string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(path_arquivo.Text))
            {
                MessageBox.Show("Obrigatorio informar path para gerar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_arquivo.Focus();
                return;
            }
            using (TFImportDominio fImport = new TFImportDominio())
            {
                if (fImport.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Fiscal.IDominio.TCN_ImportDominio.GerarArquivo(CD_Empresa.Text,
                                                                                     new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1),
                                                                                     new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 
                                                                                         DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))),
                                                                                     path_arquivo.Text,
                                                                                     fImport.St_cliente,
                                                                                     fImport.St_fornecedor,
                                                                                     fImport.St_remetdest);
                        MessageBox.Show("Arquivo gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ValidarArquivo()
        {
            try
            {
                System.Diagnostics.Process.Start(path_validador.Text.Trim());
            }
            catch
            { }
        }

        private void GerarArquivo()
        {
            //validar empresa
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            //validar path
            if (path_arquivo.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar path para salvar o arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_arquivo.Focus();
                return;
            }
            //Verificar se existe NFe sem enviar para receita no periodo
            if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "case when a.tp_movimento = 'E' then convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) else convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) end",
                        vOperador = "between",
                        vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and '" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_nota",
                        vOperador = "=",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_transmitido_nfe, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'S'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    }
                }, "1") != null)
            {
                MessageBox.Show("Existe NFe não enviada para a receita no periodo.\r\n" +
                                "Obrigatorio excluir as mesmas e inutilizar os numeros para depois gerar o sintegra.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "case when a.tp_movimento = 'E' then convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) else convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) end",
                        vOperador = "between",
                        vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and '" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_nota",
                        vOperador = "=",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_transmitido_nfe, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_eventoNFe x " +
                                    "inner join tb_fat_evento y " +
                                    "on x.cd_evento = y.cd_evento " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                    "and y.tp_evento = 'CA' " +
                                    "and isnulL(x.st_registro, 'A') <> 'T')"
                    }
                }, "1") != null)
            {
                MessageBox.Show("Existe NFe com evento de cancelamento não transmitido para a receita.\r\n" +
                                "Obrigatorio enviar o evento para a receita ou excluir o mesmo para depois gerar o sintegra.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Finalidades finalidade = Finalidades.NORMAL;
                if (cbFinalidade.Text.Trim().ToUpper().Equals("RETIFICAÇÃO TOTAL"))
                    finalidade = Finalidades.RETIFICACAO_TOTAL;
                else if (cbFinalidade.Text.Trim().ToUpper().Equals("RETIFICAÇÃO ADITIVA"))
                    finalidade = Finalidades.RETIFICACAO_ADITIVA;
                else if (cbFinalidade.Text.Trim().ToUpper().Equals("RETIFICAÇÃO CORRETIVA"))
                    finalidade = Finalidades.RETIFICACAO_CORRETIVA;
                else if (cbFinalidade.Text.Trim().ToUpper().Equals("DESFAZIMENTO"))
                    finalidade = Finalidades.DESFAZIMENTO;

                Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio processo gerar sintegra.");
                try
                {
                    CamadaNegocio.Fiscal.Sintegra.TCN_Sintegra.GerarArquivo(CD_Empresa.Text,
                                                                            new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1),
                                                                            new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))),
                                                                            finalidade,
                                                                            path_arquivo.Text,
                                                                            cbTipo10.Checked,
                                                                            cbTipo11.Checked,
                                                                            cbTipo50.Checked,
                                                                            cbTipo51.Checked,
                                                                            cbTipo53.Checked,
                                                                            cbTipo54.Checked,
                                                                            cbTipo60M.Checked,
                                                                            cbTipo60A.Checked,
                                                                            cbTipo60D.Checked,
                                                                            cbTipo60I.Checked,
                                                                            cbTipo60R.Checked,
                                                                            cbTipo70.Checked,
                                                                            cbTipo71.Checked,
                                                                            cbTipo74.Checked,
                                                                            cbTipo75.Checked,
                                                                            cbTipo90.Checked,
                                                                            tEspera);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                }
                MessageBox.Show("Arquivo gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gerar arquivo: " + ex.Message);
            }
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_arquivo.Text = fbd.SelectedPath.Trim();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFLanSintegra_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            path_arquivo.Text = Fiscal.Properties.Settings.Default.PATH_SINTEGRA;
            cbFinalidade.SelectedIndex = 0;
        }

        private void TFLanSintegra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fiscal.Properties.Settings.Default.Save();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.GerarArquivo();
        }

        private void cbTipo50_CheckedChanged(object sender, EventArgs e)
        {
            cbTipo54.Checked = cbTipo50.Checked;
        }

        private void BB_Validar_Click(object sender, EventArgs e)
        {
            this.ValidarArquivo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanSintegra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarArquivo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.ValidarArquivo();
        }

        private void bb_validador_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "EXE|*.exe";
            if (ofp.ShowDialog() == DialogResult.OK)
                path_validador.Text = ofp.FileName.Trim();
        }

        private void cbTipo60M_CheckedChanged(object sender, EventArgs e)
        {
            cbTipo60A.Checked = cbTipo60M.Checked;
        }

        private void bb_importDominio_Click(object sender, EventArgs e)
        {
            this.ImportarDominio();
        }
    }
}
