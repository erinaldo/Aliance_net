using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consulta
{
    public partial class TFLan_CentralRelatorios : Form
    {
        public TFLan_CentralRelatorios()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<TODOS MODULOS>", string.Empty));
            cbx.Add(new Utils.TDataCombo("Almoxarifado", "AMX"));
            cbx.Add(new Utils.TDataCombo("Balança", "BAL"));
            cbx.Add(new Utils.TDataCombo("Compras", "CMP"));
            cbx.Add(new Utils.TDataCombo("Consulta", "CON"));
            cbx.Add(new Utils.TDataCombo("Contabilidade", "CTB"));
            cbx.Add(new Utils.TDataCombo("Parametros", "DIV"));
            cbx.Add(new Utils.TDataCombo("Estoque", "EST"));
            cbx.Add(new Utils.TDataCombo("Empreendimento", "EMP"));
            cbx.Add(new Utils.TDataCombo("Produção", "PRD"));
            cbx.Add(new Utils.TDataCombo("Faturamento", "FAT"));
            cbx.Add(new Utils.TDataCombo("Fazenda", "FAZ"));
            cbx.Add(new Utils.TDataCombo("Financeiro", "FIN"));
            cbx.Add(new Utils.TDataCombo("Fiscal", "FIS"));
            cbx.Add(new Utils.TDataCombo("Frente Caixa", "PDV"));
            cbx.Add(new Utils.TDataCombo("Frota", "FRT"));
            cbx.Add(new Utils.TDataCombo("Grãos", "GRO"));
            cbx.Add(new Utils.TDataCombo("Mudança", "MUD"));
            cbx.Add(new Utils.TDataCombo("Locação", "LOC"));
            cbx.Add(new Utils.TDataCombo("Ordem Serviço", "OSE"));
            cbx.Add(new Utils.TDataCombo("Posto Combustivel", "POC"));
            cbx.Add(new Utils.TDataCombo("Sementes", " SEM"));

            cbModulo.DataSource = cbx;
            cbModulo.DisplayMember = "Display";
            cbModulo.ValueMember = "Value";
        }

        private void TFLan_CentralRelatorios_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void afterNovo()
        {
            using (TFCad_Report fReport = new TFCad_Report())
            {
                if(fReport.ShowDialog() == DialogResult.OK)
                    if(fReport.rReport != null)
                        try
                        {
                            CamadaNegocio.Consulta.Cadastro.TCN_Cad_Report.GravarReportConsulta(fReport.rReport, null);
                            MessageBox.Show("Relatorio gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsRelatorios.Current != null)
                using (TFCad_Report fReport = new TFCad_Report())
                {
                    fReport.rReport = bsRelatorios.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Report;
                    if(fReport.ShowDialog() == DialogResult.OK)
                        if(fReport.rReport != null)
                            try
                            {
                                CamadaNegocio.Consulta.Cadastro.TCN_Cad_Report.GravarReportConsulta(fReport.rReport, null);
                                MessageBox.Show("Relatorio alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsRelatorios.Current != null)
                if(MessageBox.Show("Confirma exclusão do relatorio selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Consulta.Cadastro.TCN_Cad_Report.DeletarReport(bsRelatorios.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Report, null);
                        afterBusca();
                        //CARREGA NOVAMENTE O MENU
                        Type t = Application.OpenForms["FMenuPrin"].GetType();
                        t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { Utils.Parametros.pubLogin, true });
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void afterBusca()
        {
            bsRelatorios.DataSource = CamadaNegocio.Consulta.Cadastro.TCN_Cad_Report.Buscar(decimal.Zero,
                                                                                            ds_report.Text.Trim(),
                                                                                            cbModulo.SelectedValue != null ? cbModulo.SelectedValue.ToString() : string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            false,
                                                                                            false,
                                                                                            true);
        }

        public void PublicarRelatorio()
        {
            try
            {
                if (MessageBox.Show("Deseja realmente publicar esta versão de relatório?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    FormRelPadrao.AtualizarRDC.GravarRDC(bsRelatorios.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Report, 
                                                         null, 
                                                         (bsRelatorios.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Report).ID_RDC.Trim().Equals("") ? "H" : "P");
                    MessageBox.Show("Versão do relatorio publicada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem");
            }
        }

        public void AtualizarRelatorio()
        {
            if (bsRelatorios.Count > 0)
            {
                Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio atualização relatorios.");
                try
                {
                    (bsRelatorios.List as CamadaDados.Consulta.Cadastro.TList_Cad_Report).ForEach(p =>
                        {
                            tEspera.Msg("Atualizando " + p.DS_Report.Trim() + "...");
                            try
                            {
                                FormRelPadrao.AtualizarRDC.VerificarVersaoRDC(p, true);
                            }
                            catch (Exception ex)
                            { tEspera.Msg(ex.Message.Trim()); }
                        });
                    System.Threading.Thread.Sleep(10000);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                    afterBusca();
                }
            }
            else
                MessageBox.Show("Não existe relatorio para ser atualizado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DownloadRelatorio()
        {
            using (TFDownload_Relatorio fDownload = new TFDownload_Relatorio())
            {
                fDownload.ShowDialog();
                this.afterBusca();
            }
        }

        public void HomologarRDC()
        {
            using (TFLan_Homologacao fHomolog = new TFLan_Homologacao())
            {
                fHomolog.ShowDialog();
                this.afterBusca();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_editarConsulta_Click(object sender, EventArgs e)
        {
            if(bsConsulta.Current != null)
                try
                {
                    TFCad_SQL fSQL = new TFCad_SQL(bsConsulta.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Consulta, true);
                    fSQL.Homologacao = true;
                    fSQL.pNMConsulta.Visible = true;
                    fSQL.NM_Consulta.Text = (bsConsulta.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Consulta).DS_Consulta;
                    fSQL.ShowDialog();

                    if (!string.IsNullOrEmpty(fSQL.Cad_Consulta.DS_SQL))
                    {
                        (bsConsulta.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Consulta).DS_Consulta = fSQL.NM_Consulta.Text;
                        (bsConsulta.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Consulta).DS_SQL = fSQL.DS_SQL.Text;
                        CamadaNegocio.Consulta.Cadastro.TCN_Cad_Consulta.GravaConsulta(bsConsulta.Current as CamadaDados.Consulta.Cadastro.TRegistro_Cad_Consulta, null);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
                    this.afterBusca();
                }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void TFLan_CentralRelatorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.PublicarRelatorio();
            else if (e.KeyCode.Equals(Keys.F10))
                this.AtualizarRelatorio();
            else if (e.KeyCode.Equals(Keys.F11))
                this.DownloadRelatorio();
            else if (e.KeyCode.Equals(Keys.F12))
                this.HomologarRDC();
        }

        private void BB_Publicar_Click(object sender, EventArgs e)
        {
            this.PublicarRelatorio();
        }

        private void bb_download_Click(object sender, EventArgs e)
        {
            this.DownloadRelatorio();
        }

        private void bb_homologar_Click(object sender, EventArgs e)
        {
            this.HomologarRDC();
        }

        private void BB_Atualizar_Click(object sender, EventArgs e)
        {
            this.AtualizarRelatorio();
        }

        private void TFLan_CentralRelatorios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
