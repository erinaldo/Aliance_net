using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using Utils;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using FormRelPadrao;

namespace Consulta
{
    public partial class TFLan_Relatorio : FormPadrao.FFormPadrao
    {
        private TList_Cad_Consulta lConsulta = new TList_Cad_Consulta();
        private ImageList il = new ImageList();
        public bool BIntelegence = false;
        public string URLWebService = "";
        public string TP_Sistema = "AL";

        public TFLan_Relatorio()
        {
            InitializeComponent();

            DTS = BS_Relatorio;
            DS_Report.CharacterCasing = CharacterCasing.Normal;
        }

        private void TFCad_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
        }

        public override string gravarRegistro()
        {
            try
            {
                if ((BS_Relatorio.Current as TRegistro_Cad_Report).Versao == 0)
                    (BS_Relatorio.Current as TRegistro_Cad_Report).Versao = 1;

                (BS_Relatorio.Current as TRegistro_Cad_Report).Sistema = TP_Sistema;

                //FAZ VALIDAÇÕES
                if (cbModulo.SelectedItem == null)
                    throw new Exception("É obrigatório informar o Módulo!");
                else if (DS_Report.Text.Trim() == "")
                    throw new Exception("É obrigatório informar o nome do relatório!");
                else if (treeConsulta.Nodes.Count <= 0)
                    throw new Exception("É obrigatório informar a pelo menos uma consulta no relatório!");
                else
                    return TCN_Cad_Report.GravarReportConsulta(BS_Relatorio.Current as TRegistro_Cad_Report, null);
            }
            catch(Exception erro)
            {
                MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
            }

            return "";
        }

        public override void afterBusca()
        {
            base.afterBusca();
            HabilitaConsulta(false);
        }

        public override void afterExclui()
        {
            if (BS_Relatorio.Count > 0)
            {
                this.vTP_Modo = TTpModo.tm_busca;
                this.excluirRegistro();
                this.buscarRegistros();
                this.modoBotoes(this.vTP_Modo, true, true, false, true, true, true, true);
                BB_Alterar.Visible = false;
                BB_Cancelar.Visible = false;
                cbChart.Enabled = false;
                cbDataCube.Enabled = false;
                cbRelatorio.Enabled = false;
                HabilitaConsulta(false);
                treeConsulta.Nodes.Clear();
            }
            else
            {
                MessageBox.Show("É necessário selecionar um relatório!", "Mensagem");
            }
        }

        public override void afterGrava()
        {
            if (this.gravarRegistro() != "")
            {
                this.vTP_Modo = TTpModo.tm_busca;
                this.habilitarControls(false);
                this.buscarRegistros();
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);

                cbChart.Enabled = false;
                cbDataCube.Enabled = false;
                cbRelatorio.Enabled = false;
                HabilitaConsulta(false);
            }
            else
            {
                this.vTP_Modo = TTpModo.tm_Insert;
                this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
            }
        }

        public override void afterAltera()
        {
            if (BS_Relatorio.Count > 0)
            {
                base.afterAltera();
                HabilitaConsulta(true);
            }
            else
            {
                MessageBox.Show("É necessário selecionar um relatório!", "Mensagem");
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_Relatorio.AddNew();
                base.afterNovo();
                
                cbChart.Enabled = false;
                cbDataCube.Enabled = false;
                cbRelatorio.Enabled = false;

                HabilitaConsulta(true);

                cbModulo.SelectedIndex = 0;
                if (cbModulo.Enabled)
                    cbModulo.Focus();
            }
        }

        public void HabilitaConsulta(bool habilita)
        {
            treeConsulta.Enabled = habilita;
            treeConsultaBusca.Enabled = habilita;
            BB_Add.Enabled = habilita;
            BB_Remover.Enabled = habilita;
            textBoxBusca.Enabled = habilita;
            BB_Filtro.Enabled = habilita;
            cbModulo.Enabled = habilita;
            DS_Report.Enabled = habilita;
            bbEditReport.Enabled = habilita;
            bb_Menu.Enabled = habilita;
            cbChart.Enabled = habilita;
            cbRelatorio.Enabled = habilita;
            cbDataCube.Enabled = habilita;
            bbExcluir.Enabled = habilita;
            toolStripConsulta.Enabled = habilita;
        }
        
        public override void afterCancela()
        {
            base.afterCancela();
            HabilitaConsulta(false);
            treeConsulta.Nodes.Clear();
        }

        public override void excluirRegistro()
        {
            try
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Cad_Report.DeletarReport(BS_Relatorio.Current as TRegistro_Cad_Report, null);
                        BS_Relatorio.RemoveCurrent();
                        afterBusca();

                        if (!BIntelegence)
                        {
                            //CARREGA NOVAMENTE O MENU
                            Type t = Application.OpenForms["FMenuPrin"].GetType();
                            t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { "MASTER", true });
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
            }
        }

        
            private void TFLan_Relatorio_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }
    }
}
