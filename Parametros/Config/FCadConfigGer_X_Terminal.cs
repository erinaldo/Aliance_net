using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.ConfigGer;
using CamadaNegocio.ConfigGer;
using CamadaDados.Diversos;

namespace Parametros.Config
{
    public partial class TFCadConfigGer_X_Terminal : FormCadPadrao.FFormCadPadrao
    {
        public TFCadConfigGer_X_Terminal()
        {
            InitializeComponent();
            DTS = bsConfigGerTerminal;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadParamGer_X_Terminal.GravaParamGer_X_Terminal((bsConfigGerTerminal.Current as TRegistro_ParamGer_X_Terminal));
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_RegParamGer_X_Terminal lista = TCN_CadParamGer_X_Terminal.Busca(id_parametro.Text, cd_terminal.Text, 0, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                    bsConfigGerTerminal.DataSource = lista;
                this.Lista = lista;
                return lista.Count;

            }
            else {
                bsConfigGerTerminal.Clear();
            }
            return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsConfigGerTerminal.AddNew();
                base.afterNovo();
                id_parametro.Focus();
            }
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsConfigGerTerminal.RemoveCurrent();
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                //bb_parametro.Enabled = false;
                //bb_terminal.Enabled = false;
            }
        }

        
        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadParamGer_X_Terminal.DeletaParamGer((bsConfigGerTerminal.Current as TRegistro_ParamGer_X_Terminal));
                    bsConfigGerTerminal.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void id_parametro_Leave(object sender, EventArgs e)
        {
            string vColunas = "ID_Parametro|=|" + id_parametro.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_parametro, ds_parametro },
                                    new TCD_ParamGer());
        }

        private void cd_terminal_Leave(object sender, EventArgs e)
        {

            string vColunas = "CD_TERMINAL|=|" + cd_terminal.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_terminal, nm_terminal},
                                    new TCD_CadTerminal());
        }

        private void bb_parametro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Parametro|Descrição Parametro|350;" +
                              "DS_Finalidade|Finalidade Parametro|350;" +
                              "ID_Parametro|Cd. Parametro|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_parametro, ds_parametro },
                                    new TCD_ParamGer(), "");
        }

        private void bb_terminal_Click(object sender, EventArgs e)
        {
            string vColunas = " a.ds_TERMINAL|Nome Terminal|350;" +
                  "a.CD_TERMINAL|Cód. Terminal|100";
            
            //string vParamFixo = "";
            string vParamFixo = "|EXISTS|(select 1 from TB_DIV_Usuario_X_Terminal  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            /*paramentro que restringe acesso ao terminal por usuario*/
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_terminal, nm_terminal },
                                   new TCD_CadTerminal(), "");
       
        }

        private void tList_RegParamGer_X_TerminalDataGridDefault_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nm_terminal_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_parametroLabel_Click(object sender, EventArgs e)
        {

        }

        private void pDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TFCadConfigGer_X_Terminal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, tList_RegParamGer_X_TerminalDataGridDefault);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadConfigGer_X_Terminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, tList_RegParamGer_X_TerminalDataGridDefault);
        }
    }
}
