using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadTPDuplicata : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTPDuplicata()
        {
            InitializeComponent();
            DTS = bsTpDup;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("PAGAR", "P"));
            cbx.Add(new TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTpDuplicata.Gravar(bsTpDup.Current as TRegistro_CadTpDuplicata, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsTpDup.AddNew();
            base.afterNovo();
            if (!TP_Duplicata.Focus())
                tp_movimento.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                tp_movimento.Enabled = false;
                DS_TpDuplicata.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTpDup.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CadTpDuplicata lista = TCN_CadTpDuplicata.Buscar(TP_Duplicata.Text,
                                                                   DS_TpDuplicata.Text,
                                                                   tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpDup.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTpDup.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadTpDuplicata.Excluir(bsTpDup.Current as TRegistro_CadTpDuplicata, null);
                        bsTpDup.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_HistJuro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Juro, ds_historico_juro },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Juro_Leave(object sender, EventArgs e)
        {
            if (CD_Historico_Juro.Text.Trim() != "")
            {
                string vColunas = "a." + CD_Historico_Juro.NM_CampoBusca + "|=|'" + CD_Historico_Juro.Text + "';" +
                                  "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico_Juro, ds_historico_juro },
                                        new TCD_CadHistorico());
            }
            else
                ds_historico_juro.Clear();
        }

        private void bb_HistDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("P") ? "R" : "P" : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Desconto, ds_historico_desconto },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Desconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + CD_Historico_Desconto.NM_CampoBusca + "|=|'" + CD_Historico_Desconto.Text + "';" +
                               "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("P") ? "R" : "P" : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico_Desconto, ds_historico_desconto },
                                    new TCD_CadHistorico());
        }
          
        private void bb_Historico_Dup_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";

            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Dup, ds_Historico_Dup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Dup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + CD_Historico_Dup.Text + "';" +
                               "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico_Dup, ds_Historico_Dup },
                                                new TCD_CadHistorico());
        }

        private void bb_historico_dcamb_ativa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{cd_historico_dcamb_ativa, ds_historico_dcamb_ativa},
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_dcamb_ativa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_dcamb_ativa.Text + "';" +
                               "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_dcamb_ativa, ds_historico_dcamb_ativa },
                                    new TCD_CadHistorico());
        }

        private void bb_historico_dcam_passiva_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_dcam_passiva, ds_historico_dcamb_passiva },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_dcam_passiva_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_dcam_passiva.Text + "';" +
                               "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_dcam_passiva, ds_historico_dcamb_passiva },
                                    new TCD_CadHistorico());
        }

        private void TFCadTPDuplicata_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
        }

        private void bb_historico_trocoCH_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_trocoCH, ds_historico_trocoCH },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_trocoCH_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico_trocoCH.Text.Trim() + "';" +
                               "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_trocoCH, ds_historico_trocoCH },
                                    new TCD_CadHistorico());
        }

        private void bb_portadoragrupar_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_portador|Portador|200;" +
                              "a.cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portadoragrupar },
                                    new TCD_CadPortador(), string.Empty);
        }

        private void cd_portadoragrupar_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_portador|=|'" + cd_portadoragrupar.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portadoragrupar },
                                    new TCD_CadPortador());
        }

        private void bb_contageragrupar_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Descrição Conta Gerencial|350;" +
                              "a.CD_ContaGer|Cód. Conta Gerencial|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contageragrupar },
                                    new TCD_CadContaGer(), string.Empty);
        }

        private void cd_contageragrupar_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_Contager|=|'" + cd_contageragrupar.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contageragrupar },
                                    new TCD_CadContaGer());
        }

        private void bb_historicoquitacaoagrup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoquitacaoagrup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoquitacaoagrup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historicoquitacaoagrup.Text.Trim() + "';" +
                              "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoquitacaoagrup },
                                    new TCD_CadHistorico());
        }

        private void bb_historicoagrup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoagrup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoagrup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historicoagrup.Text.Trim() + "';" +
                              "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoagrup },
                                    new TCD_CadHistorico());
        }

        private void bb_portadorperdadup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_portador|Portador|200;" +
                              "a.cd_portador|Cd. Portador|80";
            string vParam = "isnull(a.st_controletitulo, 'N')|<>|'S';" +
                            "a.st_cartaocredito|=|1";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portadorperdadup },
                                    new TCD_CadPortador(), vParam);
        }

        private void cd_portadorperdadup_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_portador|=|'" + cd_portadorperdadup.Text.Trim() + "';" +
                            "isnull(a.st_controletitulo, 'N')|<>|'S';" +
                            "a.st_cartaocredito|=|1";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portadorperdadup },
                                    new TCD_CadPortador());
        }

        private void bb_contagerperdadup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Descrição Conta Gerencial|350;" +
                              "a.CD_ContaGer|Cód. Conta Gerencial|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contagerperdadup },
                                    new TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerperdadup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_Contager|=|'" + cd_contagerperdadup.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contagerperdadup },
                                    new TCD_CadContaGer());
        }

        private void bb_historicoquitperdadup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoquitperdadup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoquitperdadup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historicoquitperdadup.Text.Trim() + "';" +
                              "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoquitperdadup },
                                    new TCD_CadHistorico());
        }

        private void bb_historicoperdadup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoperdadup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historicoperdadup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historicoperdadup.Text.Trim() + "';" +
                              "a.TP_Mov|=|'" + (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historicoperdadup },
                                    new TCD_CadHistorico());
        }

        private void TFCadTPDuplicata_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpDup.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadTpDuplicata());
            TList_CadTpDuplicata lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadTpDuplicata(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadTpDuplicata(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpDup.List as TList_CadTpDuplicata).Sort(lComparer);
            bsTpDup.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_config },
                new TCD_CadCFGBanco(), string.Empty);
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_config }, new TCD_CadCFGBanco());
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.vTP_Modo == Utils.TTpModo.tm_Insert)
            {
                CD_Historico_Desconto.Clear();
                ds_historico_desconto.Clear();
                CD_Historico_Juro.Clear();
                ds_historico_juro.Clear();
                CD_Historico_Dup.Clear();
                ds_Historico_Dup.Clear();
            }
        }
    }
}

