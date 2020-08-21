using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadMov_X_CMI : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMov_X_CMI()
        {
            InitializeComponent();
            DTS = bs_CadMovXCMI;
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
                return TCN_CadMov_x_CMI.GravarMovCMI(bs_CadMovXCMI.Current as TRegistro_CadMov_x_CMI);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadMov_x_CMI lista = TCN_CadMov_x_CMI.Busca(CD_Movimentacao.Text.Trim() != "" ? Convert.ToDecimal(CD_Movimentacao.Text):0, 
                                                              CD_CMI.Text.Trim() != "" ?Convert.ToDecimal(CD_CMI.Text):0, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CadMovXCMI.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CadMovXCMI.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bs_CadMovXCMI.AddNew();
                base.afterNovo();
                if (!CD_Movimentacao.Focus())
                    CD_CMI.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bs_CadMovXCMI.RemoveCurrent();
        }

        public override void afterAltera()
        {
           // base.afterAltera();
            //if (vTP_Modo == TTpModo.tm_Edit)
              //  CD_CMI.Focus();
        }

        public override void excluirRegistro()
        {
            
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadMov_x_CMI.DeletarMovCMI(bs_CadMovXCMI.Current as TRegistro_CadMov_x_CMI);
                    bs_CadMovXCMI.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
            
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

        private void TFCadMov_X_CMI_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_cadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadMov_X_CMI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_cadastro);
        }
    }
}

