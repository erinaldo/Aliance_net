using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace Fiscal.Cadastros
{
    public partial class TFCadMovimentacao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMovimentacao()
        {
            InitializeComponent();
            DTS = bs_CadMovimentacao;
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("(NENHUM)", ""));
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            this.pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadMovimentacao lista = TCN_CadMovimentacao.Busca(cd_movimentacao.Text , 
                                                                    DS_Movimentacao.Text, 
                                                                    tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString(): string.Empty,
                                                                    null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CadMovimentacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CadMovimentacao.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (tp_movimento.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatório informar tipo de movimento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_movimento.Focus();
                    return "";
                }
                if (tp_movimento.SelectedValue.ToString().Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar tipo de movimento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_movimento.Focus();
                    return "";
                }
                return TCN_CadMovimentacao.Gravar(bs_CadMovimentacao.Current as TRegistro_CadMovimentacao, null);
            }
            else
                return "";
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadMovimentacao.Excluir(bs_CadMovimentacao.Current as TRegistro_CadMovimentacao, null);
                    bs_CadMovimentacao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
                bs_CadMovimentacao.AddNew();
            base.afterNovo();
            if (!(cd_movimentacao.Focus()))
                DS_Movimentacao.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
                DS_Movimentacao.Focus();
        }

        public override void afterCancela()
        {
            tp_movimento.SelectedIndex = 0;
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                cd_movimentacao.Focus();
        }
       
        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";

            string vParamFixo = string.Empty;
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    vParamFixo += ";a.TP_Mov|=|'P'";
                else if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                    vParamFixo += ";a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico, ds_historico },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + CD_Historico.NM_CampoBusca + "|=|'" + CD_Historico.Text + "'";
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    vColunas += ";a.TP_Mov|=|'P'";
                else if(tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                    vColunas += ";a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico, ds_historico },
                                    new TCD_CadHistorico());
        }

        private void bb_obsFisDentro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Observação Fiscal|350;" +
                              "CD_ObservacaoFiscal|Cód. Obs. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_DentroEstado, ds_obsfiscaldentroestado },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void CD_ObsFiscal_DentroEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_ObsFiscal_DentroEstado.NM_CampoBusca + "|=|'" + CD_ObsFiscal_DentroEstado.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_DentroEstado, ds_obsfiscaldentroestado },
                                    new TCD_CadObservacaoFiscal());
        }

        private void CD_ObsFiscal_ForaEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_ObsFiscal_ForaEstado.NM_CampoBusca + "|=|'" + CD_ObsFiscal_ForaEstado.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_ForaEstado, ds_obsfiscalforaestado },
                                    new TCD_CadObservacaoFiscal());
        }

        private void bb_obsFisFora_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Observação Fiscal|350;" +
                              "CD_ObservacaoFiscal|Cód. Obs. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_ForaEstado, ds_obsfiscalforaestado },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void BB_Internacional_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Observação Fiscal Internacional|350;" +
                              "CD_ObservacaoFiscal|Cód. Obs. Fiscal Internacional|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_Internacional, ds_obsfiscalinternacional },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void CD_ObsFiscal_Internacional_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_ObsFiscal_Internacional.NM_CampoBusca + "|=|'" + CD_ObsFiscal_Internacional.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ObsFiscal_Internacional, ds_obsfiscalinternacional },
                                    new TCD_CadObservacaoFiscal());
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                CD_Historico.Clear();
                ds_historico.Clear();
            }
        }

        private void CD_DadosAdic_DentroEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_DadosAdic_DentroEstado.NM_CampoBusca +"|=|'" + CD_DadosAdic_DentroEstado.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_DentroEstado, ds_DadosAdicdentroestado},
                                    new TCD_CadObservacaoFiscal());
        }

        private void CD_DadosAdic_ForaEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_DadosAdic_ForaEstado.NM_CampoBusca + "|=|'" + CD_DadosAdic_ForaEstado.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_ForaEstado, ds_DadosAdicForaestado },
                                    new TCD_CadObservacaoFiscal());
        }

        private void CD_DadosAdic_Internacional_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_DadosAdic_Internacional.NM_CampoBusca + "|=|'" + CD_DadosAdic_Internacional.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_Internacional, ds_DadosAdicInternacional },
                                    new TCD_CadObservacaoFiscal());
        }

        private void BB_DadosAdic_DentroEstado_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Dados Adicionais|350;" +
                              "CD_ObservacaoFiscal|Cód. Dados Adic.|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_DentroEstado, ds_DadosAdicdentroestado },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void BB_DadosAdic_ForaEstado_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Dados Adicionais|350;" +
                              "CD_ObservacaoFiscal|Cód. Dados Adic.|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_ForaEstado, ds_DadosAdicForaestado },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void BB_DadosAdic_Internacional_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Dados Adicionais Internacional|350;" +
                              "CD_ObservacaoFiscal|Cód. Dados Adic. Internacional|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_DadosAdic_Internacional, ds_DadosAdicInternacional },
                                    new TCD_CadObservacaoFiscal(), "");
        }

        private void TFCadMovimentacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadMovimentacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.St_deducao = "S";
                fBusca.Tp_registro = (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? "'D'" : "'R'");
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult.Text = fBusca.Cd_centro;
                        cd_centroresult_Leave(this, new EventArgs());
                    }
            }
        }

        private void cd_centroresult_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "isnull(a.st_deducao, 'N')|=|'S';" +
                            "a.tp_registro|=|'" + (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? "D" : "R") + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult, ds_centroresultado },
                new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }
    }
}

