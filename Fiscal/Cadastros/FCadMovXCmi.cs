using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadMovXCmi : Form
    {
        public string cd_mov, ds_mov, tp;
        private CamadaDados.Fiscal.TRegistro_CadMov_x_CMI rmov;
        public CamadaDados.Fiscal.TRegistro_CadMov_x_CMI rMov
        {
            get
            {
                if (bs_MovCmi.Current != null)
                    return bs_MovCmi.Current as TRegistro_CadMov_x_CMI;
                else return null;
            }
            set { rmov = value; }
        }

        public TFCadMovXCmi()
        {
            InitializeComponent();
        }

        private void bb_Movimentacao_Click(object sender, EventArgs e)
        {
            if (tp_movCMI.Text != "")
            {
                string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                                  "a.CD_Movimentacao|Cód. Movimentação|100;" +
                                  "a.TP_Movimento|Natureza|100";
                string vParam = "|NOT EXISTS|(Select 1 From TB_FIS_Movimentacao x Where x.tp_movimento = a.tp_movimento and x.CD_Movimentacao = " + CD_CMI.Text + ");" +
                                        "a.TP_Movimento|=|'" + tp_movCMI.Text.Trim() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao, tp_movMovimentacao },
                                        new TCD_CadMovimentacao(), vParam);

            }
            else
            {
                string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                                  "a.CD_Movimentacao|Cód. Movimentação|100;" +
                                  "a.TP_Movimento|Natureza|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao, tp_movMovimentacao },
                                       new TCD_CadMovimentacao(), "");
            }
        }

        private void bb_cmi_Click(object sender, EventArgs e)
        {

            if (CD_Movimentacao.Text != "")
            {

                string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                                  "a.CD_CMI|Cód. CMI|100;" +
                                  "a.TP_Movimento|Natureza|100";
                string vParamFixo = "|NOT EXISTS|(Select 1 From TB_FIS_Mov_X_CMI x Where x.CD_CMI = a.CD_CMI and x.CD_Movimentacao = " + CD_Movimentacao.Text + ");" +
                                    "a.TP_Movimento|=|'" + tp_movMovimentacao.Text.Trim() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, ds_cmi, tp_movCMI },
                                        new TCD_CadCMI(), vParamFixo);
            }
            else
            {

                string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                                 "a.CD_CMI|Cód. CMI|100;" +
                                 "a.TP_Movimento|Natureza|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, ds_cmi, tp_movCMI },
                                        new TCD_CadCMI(), "");
            }
        }

        private void TFCadMovXCmi_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bs_MovCmi.AddNew();
            CD_Movimentacao.Text = cd_mov;
            ds_Movimentacao.Text = ds_mov;
            tp_movMovimentacao.Text = tp;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                TCN_CadMov_x_CMI.GravarMovCMI(bs_MovCmi.Current as TRegistro_CadMov_x_CMI);
                MessageBox.Show("Salvo com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Movimentacao_Leave(object sender, EventArgs e)
        {
            if (CD_Movimentacao.Text.Trim() != "")
            {
                string vColunas = "a." + CD_Movimentacao.NM_CampoBusca + "|=|'" + CD_Movimentacao.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao, tp_movMovimentacao },
                                        new TCD_CadMovimentacao());
            }
            else
            {
                ds_Movimentacao.Clear();
                tp_movMovimentacao.Clear();
            }
        }

        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            if (CD_CMI.Text.Trim() != "")
            {
                string vColunas = "a.CD_CMI|=|'" + CD_CMI.Text + "'" +
                                  "|NOT EXISTS|(Select 1 From TB_FIS_Mov_X_CMI x Where x.CD_CMI = a.CD_CMI and x.CD_Movimentacao = " + CD_Movimentacao.Text + ");" +
                                  "a.TP_Movimento|=|'" + tp_movMovimentacao.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CMI, ds_cmi, tp_movCMI },
                                        new TCD_CadCMI());
            }
            else
            {
                ds_cmi.Clear();
                tp_movCMI.Clear();
            }
        }

        private void bb_Movimentacao_Click_1(object sender, EventArgs e)
        {
            if (tp_movCMI.Text != "")
            {
                string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                                  "a.CD_Movimentacao|Cód. Movimentação|100;" +
                                  "a.TP_Movimento|Natureza|100";
                string vParam = "|NOT EXISTS|(Select 1 From TB_FIS_Movimentacao x Where x.tp_movimento = a.tp_movimento and x.CD_Movimentacao = " + CD_CMI.Text + ");" +
                                        "a.TP_Movimento|=|'" + tp_movCMI.Text.Trim() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao, tp_movMovimentacao },
                                        new TCD_CadMovimentacao(), vParam);

            }
            else
            {
                string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                                  "a.CD_Movimentacao|Cód. Movimentação|100;" +
                                  "a.TP_Movimento|Natureza|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao, tp_movMovimentacao },
                                       new TCD_CadMovimentacao(), "");
            }
        }

        private void bb_cmi_Click_1(object sender, EventArgs e)
        {


            if (CD_Movimentacao.Text != "")
            {

                string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                                  "a.CD_CMI|Cód. CMI|100;" +
                                  "a.TP_Movimento|Natureza|100";
                string vParamFixo = "|NOT EXISTS|(Select 1 From TB_FIS_Mov_X_CMI x Where x.CD_CMI = a.CD_CMI and x.CD_Movimentacao = " + CD_Movimentacao.Text + ");" +
                                    "a.TP_Movimento|=|'" + tp_movMovimentacao.Text.Trim() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, ds_cmi, tp_movCMI },
                                        new TCD_CadCMI(), vParamFixo);
            }
            else
            {

                string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                                 "a.CD_CMI|Cód. CMI|100;" +
                                 "a.TP_Movimento|Natureza|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, ds_cmi, tp_movCMI },
                                        new TCD_CadCMI(), "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(FCadCmiSimples fcadCmiSimples = new FCadCmiSimples()){
                fcadCmiSimples.tp = tp;
                if (fcadCmiSimples.ShowDialog() == DialogResult.OK)
                {
                    CD_CMI.Text = fcadCmiSimples.cd_cmi;
                    ds_cmi.Text = fcadCmiSimples.ds_cmi;
                    tp_movCMI.Text = fcadCmiSimples.tp;

                }

            }


        }
    }
}
