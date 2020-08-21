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
using System.Collections;
using CamadaDados.Diversos;
using FormRelPadrao;
using CamadaDados.Consulta.Cadastro;

namespace Consulta
{
    public partial class TFLan_Homologacao : Form
    {
        private bool Altera_Relatorio = false;
        private bool Edit = false;
        public string vURLWebService = "";
        public string vSistema = "AL";

        public TFLan_Homologacao()
        {
            InitializeComponent();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("Almoxarifado", "AMX"));
            cbx.Add(new Utils.TDataCombo("Balança", "BAL"));
            cbx.Add(new Utils.TDataCombo("Compras", "CMP"));
            cbx.Add(new Utils.TDataCombo("Consulta", "CON"));
            cbx.Add(new Utils.TDataCombo("Contabilidade", "CTB"));
            cbx.Add(new Utils.TDataCombo("Parametros", "DIV"));
            cbx.Add(new Utils.TDataCombo("Estoque", "EST"));
            cbx.Add(new Utils.TDataCombo("Produção", "PRD"));
            cbx.Add(new Utils.TDataCombo("Faturamento", "FAT"));
            cbx.Add(new Utils.TDataCombo("Fazenda", "FAZ"));
            cbx.Add(new Utils.TDataCombo("Financeiro", "FIN"));
            cbx.Add(new Utils.TDataCombo("Fiscal", "FIS"));
            cbx.Add(new Utils.TDataCombo("Frente Caixa", "PDV"));
            cbx.Add(new Utils.TDataCombo("Frota", "FRT"));
            cbx.Add(new Utils.TDataCombo("Grãos", "GRO"));
            cbx.Add(new Utils.TDataCombo("Ordem Serviço", "OSE"));
            cbx.Add(new Utils.TDataCombo("Posto Combustivel", "POC"));
            cbx.Add(new Utils.TDataCombo("Sementes", " SEM"));

            cbModulo.DataSource = cbx;
            cbModulo.DisplayMember = "Display";
            cbModulo.ValueMember = "Value";
        }

        #region "BOTÕES DA TOOL STRIP"

            private void BB_Limpar_Click(object sender, EventArgs e)
            {
                pDadosFiltros.LimparRegistro();
                cbModulo.Focus();
            }

            private void BB_Buscar_Click(object sender, EventArgs e)
            {
                buscarRegistros();
            }

            private void BB_Relatorio_Click(object sender, EventArgs e)
            {
                try
                {
                    if (BS_Homologacao.Current != null)
                    {
                        CamadaDados.WS_RDC.TRegistro_Cad_RDC lista = ServiceRest.DataService.BuscarDetalhesRDC((BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).ID_RDC);

                        if (lista != null)
                        {
                            (BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report = lista.Code_Report;
                            BS_Homologacao.ResetCurrentItem();
                            TRegistro_Cad_Report Cad_Report = AtualizarRDC.ConvertRDCparaReport(lista);

                            Query_Report relatorio = new Query_Report();
                            relatorio.Homologacao = true;
                            relatorio.MontaFormRelatorio(Cad_Report, null);
                            if ((BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report != relatorio.Cad_Report.Code_Report)
                            {
                                (BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report = relatorio.Cad_Report.Code_Report;
                                Edit = true;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Atenção é necessário selecionar um RDC!", "Mensagem");
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Mensagem");
                }
            }

            private void BB_Homologar_Click(object sender, EventArgs e)
            {
                if (BS_Homologacao.Current != null)
                {
                    try
                    {
                        if (MessageBox.Show("Deseja realmente homologar este RDC?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            CamadaDados.WS_RDC.TRegistro_Cad_RDC lista = ServiceRest.DataService.BuscarDetalhesRDC((BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).ID_RDC);

                            if (lista != null)
                            {
                                (BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Code_Report = lista.Code_Report;
                                BS_Homologacao.ResetCurrentItem();
                                if (!Edit)
                                    ServiceRest.DataService.HomologarRDC(lista);
                                else
                                {
                                    (BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Versao = (BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC).Versao + 1;
                                    AtualizarRDC.GravarRDC(AtualizarRDC.ConvertRDCparaReport(BS_Homologacao.Current as CamadaDados.WS_RDC.TRegistro_Cad_RDC), null, "P");
                                }
                            }
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Mensagem");
                    }
                }
                else
                    MessageBox.Show("Atenção é necessário selecionar um RDC!", "Mensagem");
            }

            private void BB_Fechar_Click(object sender, EventArgs e)
            {
                this.Dispose();
            }

            private void BB_EditSQL_Click(object sender, EventArgs e)
            {
                if (BS_DTS.Current != null)
                {
                    TFCad_SQL fSQL = new TFCad_SQL(AtualizarRDC.ConvertDTSparaConsulta((BS_DTS.Current as CamadaDados.WS_RDC.TRegistro_Cad_DataSource)), false);
                    fSQL.Homologacao = true;
                    fSQL.ShowDialog();

                    if (fSQL.Cad_Consulta.DS_SQL != (BS_DTS.Current as CamadaDados.WS_RDC.TRegistro_Cad_DataSource).DS_SQL)
                    {
                        (BS_DTS.Current as CamadaDados.WS_RDC.TRegistro_Cad_DataSource).DS_SQL = fSQL.Cad_Consulta.DS_SQL;
                        BS_DTS.ResetCurrentItem();
                        Edit = true;
                    }
                }
                else
                    MessageBox.Show("Atenção é necessário selecionar um DataSource!", "Mensagem");
            }

        #endregion

        #region "AÇÕES DA CAMADA DE DADOS"

            public void buscarRegistros()
            {
                try
                {
                    List<CamadaDados.WS_RDC.TRegistro_Cad_RDC> lista = ServiceRest.DataService.BuscarRDC("", DS_RDC.Text, cbModulo.SelectedValue.ToString(), "H", false, true);

                    if (lista != null)
                    {
                        if (lista.Count > 0)
                        {
                            BS_Homologacao.DataSource = lista;
                        }
                        else
                            BS_Homologacao.Clear();
                    }
                    else
                        BS_Homologacao.Clear();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Mensagem");
                }
            }

        #endregion

        #region "ABA DTS"

            private void tabDTS_Enter(object sender, EventArgs e)
            {
                if ((BS_Homologacao != null) || (BS_Homologacao.Current != null))
                {
                    BB_EditSQL.Visible = true;
                }
                else
                {
                    tcCentral.SelectedTab = tpRDC;
                    MessageBox.Show("Atenção é necessário selecionar um RDC!", "Mensagem");
                }
            }

        #endregion

        #region "ABA HOMOLOGACAO"

            private void tpRDC_Enter(object sender, EventArgs e)
            {
                BB_EditSQL.Visible = false;
            }

        #endregion

        private void TFLan_Homologacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                BB_Limpar_Click(this, null);
            if (e.KeyCode == Keys.F2)
                BB_Buscar_Click(this, null);
            if (e.KeyCode == Keys.F3)
                BB_Relatorio_Click(this, null);
            if (e.KeyCode == Keys.F4)
                BB_Homologar_Click(this, null);
            if ((e.KeyCode == Keys.F1) && (BB_EditSQL.Visible))
                BB_EditSQL_Click(this, null);
        }

        private void TFLan_Homologacao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
