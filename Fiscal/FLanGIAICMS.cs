using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Fiscal
{
    public partial class TFLanGIAICMS : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanGIAICMS()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            bsGiaIcms.DataSource = CamadaNegocio.Fiscal.GIA_ICMS.TCN_GIAICMS.Buscar(CD_Empresa.Text,
                                                                                    new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1).ToString("dd/MM/yyyy"),
                                                                                    new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month), 23, 59, 59).ToString("dd/MM/yyyy HH:mm:ss"),
                                                                                    null);
        }

        private void afterPrint()
        {
            if (bsGiaIcms.Current != null) 
            {
                (bsGiaIcms.Current as CamadaDados.Fiscal.GIA_ICMS.TRegistro_GIAICMS).Dt_referencia = dtPeriodo.Value;
                //Chamar tela de impressao relatorio
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsGiaIcms;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.Ident = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIS";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATÓRIO GIA ICMS";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATÓRIO GIA ICMS",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATÓRIO GIA ICMS",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void GerarGia()
        {
            if (bsGiaIcms.Current == null)
            {
                MessageBox.Show("Não existe registro para gerar GIA/ICMS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(path_gia.Text))
            {
                MessageBox.Show("Obrigatorio informar PATH para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!System.IO.Directory.Exists(path_gia.Text))
            {
                if (MessageBox.Show("PATH informado não existe. Deseja Criar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        System.IO.Directory.CreateDirectory(path_gia.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro criar diretorio: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Obrigatorio informar PATH valido para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }   
            }
            try
            {
                string path = string.Empty;
                if (path_gia.Text.Trim().Substring(path_gia.Text.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    path = path_gia.Text.Trim() + System.IO.Path.DirectorySeparatorChar.ToString();
                (bsGiaIcms.Current as CamadaDados.Fiscal.GIA_ICMS.TRegistro_GIAICMS).Dt_referencia = dtPeriodo.Value;
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path + "GIA" + dtPeriodo.Value.Year.ToString() + dtPeriodo.Value.Month.ToString().FormatStringEsquerda(2, '0') + ".txt", false, System.Text.Encoding.Default))
                {
                    sw.Write(CamadaNegocio.Fiscal.GIA_ICMS.TCN_GIAICMS.GerarGIAICMS(bsGiaIcms.Current as CamadaDados.Fiscal.GIA_ICMS.TRegistro_GIAICMS));
                    sw.Close();
                }
                MessageBox.Show("Arquivo GIA/ICMS gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gerar arquivo GIA: " + ex.Message.Trim());
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

        private void TFLanGIAICMS_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("NORMAL", "43"));
            cbx.Add(new Utils.TDataCombo("RETIFICAÇÃO", "51"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
            tp_registro.SelectedIndex = 0;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.GerarGia();   
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = path_gia.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_gia.Text = fbd.SelectedPath.Trim();
            }
        }

        private void TFLanGIAICMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fiscal.Properties.Settings.Default.Save();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanGIAICMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GerarGia();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o Relatório que deseja alterar.");
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }
    }
}
