using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using CamadaDados.Financeiro.Cadastros;

namespace Fiscal.Cadastros
{
    public partial class TFCadCMI : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCMI()
        {
            InitializeComponent();
            DTS = BS_CMI;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
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
                return TCN_CadCMI.Gravar(BS_CMI.Current as TRegistro_CadCMI, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadCMI lista = TCN_CadCMI.Busca(CD_CMI.Text.Trim(),
                                                  DS_CMI.Text.Trim(),
                                                  (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty),
                                                  Tp_Docto.Text.Trim(),
                                                  TP_Duplicata.Text.Trim(),
                                                  CD_CondPGTO.Text.Trim(),
                                                  false,
                                                  false,
                                                  false,
                                                  false,
                                                  false,
                                                  false,
                                                  false,
                                                  null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CMI.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CMI.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_CMI.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CMI.AddNew();
                base.afterNovo();
                if (!(CD_CMI.Focus()))
                    DS_CMI.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_CMI.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadCMI.Excluir(BS_CMI.Current as TRegistro_CadCMI, null);
                    BS_CMI.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_duplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_TpDuplicata|Tipo Duplicata|350;" +
                              "a.TP_Duplicata|TP. Duplicata|100";
            string vParamFixo = "a.TP_Mov|=|";
            if (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") : false)
                vParamFixo += "'P'";
            else 
                vParamFixo += "'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Duplicata, ds_tpduplicata },
                                    new TCD_CadTpDuplicata(), vParamFixo);
        }

        private void TP_Duplicata_Leave(object sender, EventArgs e)
        {
            if (TP_Duplicata.Text.Trim() != "")
            {
                string vColunas = "a.tp_duplicata|=|'" + TP_Duplicata.Text.Trim() + "';" +
                                  "a.TP_Mov|=|";
                if (tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") : false)
                   vColunas += "'P'";
                else 
                    vColunas += "'R'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Duplicata, ds_tpduplicata },
                                        new TCD_CadTpDuplicata());
            }
            else
                ds_tpduplicata.Clear();
        }

        private void bbDocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                              "TP_Docto|TP. Docto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Tp_Docto, ds_tpDocto },
                                    new TCD_CadTpDoctoDup(), "");
        }

        private void Tp_Docto_Leave(object sender, EventArgs e)
        {
            if (Tp_Docto.Text.Trim() != "")
            {
                string vColunas = "tp_docto|=|'" + Tp_Docto.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Tp_Docto, ds_tpDocto },
                                        new TCD_CadTpDoctoDup());
            }
            else
                ds_tpDocto.Clear();
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondPGTO, ds_condpgto },
                                    new TCD_CadCondPgto(), "");
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            if (CD_CondPGTO.Text.Trim() != "")
            {
                string vColunas = "a.cd_condpgto|=|'" + CD_CondPGTO.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CondPGTO, ds_condpgto },
                                        new TCD_CadCondPgto());
            }
            else
                ds_condpgto.Clear();
        }

        private void ST_Mestra_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !ST_Mestra.Checked;
            ST_Complementar.Enabled = !ST_Mestra.Checked;
            ST_SimplesRemessa.Enabled = !ST_Mestra.Checked;
            ST_GeraEstoque.Enabled = !ST_Mestra.Checked;
            st_compdevimposto.Enabled = !ST_Mestra.Checked;
            if (ST_Mestra.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Complementar.Checked = false;
                ST_SimplesRemessa.Checked = false;
                ST_GeraEstoque.Checked = false;
                st_compdevimposto.Checked = false;
            }
         }

        private void ST_Devolucao_CheckedChanged(object sender, EventArgs e)
        {
            ST_Complementar.Enabled = !ST_Devolucao.Checked;
            ST_Mestra.Enabled = !ST_Devolucao.Checked;
            ST_SimplesRemessa.Enabled = !ST_Devolucao.Checked;
            st_retorno.Enabled = !ST_Devolucao.Checked;
            st_compdevimposto.Enabled = !ST_Devolucao.Checked;
            Tp_Docto.Enabled = !ST_Devolucao.Checked;
            bbDocto.Enabled = !ST_Devolucao.Checked;
            TP_Duplicata.Enabled = !ST_Devolucao.Checked;
            bb_duplicata.Enabled = !ST_Devolucao.Checked;
            CD_CondPGTO.Enabled = !ST_Devolucao.Checked;
            bb_condpgto.Enabled = !ST_Devolucao.Checked;
            if (ST_Devolucao.Checked)
            {
                ST_Complementar.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
                st_compdevimposto.Checked = false;
                Tp_Docto.Text = string.Empty;
                TP_Duplicata.Text = string.Empty;
                CD_CondPGTO.Text = string.Empty;
            }
        }

        private void ST_Complementar_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !ST_Complementar.Checked;
            ST_Mestra.Enabled = !ST_Complementar.Checked;
            ST_SimplesRemessa.Enabled = !ST_Complementar.Checked;
            st_retorno.Enabled = !ST_Complementar.Checked;
            st_compdevimposto.Enabled = !ST_Complementar.Checked;
            if (ST_Complementar.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
                st_compdevimposto.Checked = false;
            }
        }

        private void ST_SimplesRemessa_CheckedChanged(object sender, EventArgs e)
        {
            st_retorno.Enabled = !ST_SimplesRemessa.Checked;
            ST_Devolucao.Enabled = !ST_SimplesRemessa.Checked;
            ST_Mestra.Enabled = !ST_SimplesRemessa.Checked;
            ST_Complementar.Enabled = !ST_SimplesRemessa.Checked;
            st_compdevimposto.Enabled = !ST_SimplesRemessa.Checked;
            TP_Duplicata.Enabled = !ST_SimplesRemessa.Checked;
            bb_duplicata.Enabled = !ST_SimplesRemessa.Checked;
            CD_CondPGTO.Enabled = !ST_SimplesRemessa.Checked;
            bb_condpgto.Enabled = !ST_SimplesRemessa.Checked;
            if (ST_SimplesRemessa.Checked)
            {
                st_retorno.Checked = false;
                ST_Devolucao.Checked = false;
                ST_Mestra.Checked = false;
                ST_Complementar.Checked = false;
                st_compdevimposto.Checked = false;
                ST_GeraEstoque.Enabled = true;
                TP_Duplicata.Clear();
                ds_tpduplicata.Clear();
                CD_CondPGTO.Clear();
                ds_condpgto.Clear();
            }
        }

        private void TFCadCMI_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.pDados.set_FormatZero();
        }
                
        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                TP_Duplicata.Clear();
                ds_tpduplicata.Clear();
            }
        }

        private void TFCadCMI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void st_retorno_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !st_retorno.Checked;
            ST_Complementar.Enabled = !st_retorno.Checked;
            ST_Mestra.Enabled = !st_retorno.Checked;
            ST_SimplesRemessa.Enabled = !st_retorno.Checked;

        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CMI.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadCMI());
            TList_CadCMI lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadCMI(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadCMI(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CMI.List as TList_CadCMI).Sort(lComparer);
            BS_CMI.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void st_compdevimposto_CheckedChanged(object sender, EventArgs e)
        {
            ST_Devolucao.Enabled = !st_compdevimposto.Checked;
            ST_Complementar.Enabled = !st_compdevimposto.Checked;
            ST_Mestra.Enabled = !st_compdevimposto.Checked;
            ST_SimplesRemessa.Enabled = !st_compdevimposto.Checked;
            st_retorno.Enabled = !st_compdevimposto.Checked;
            if (st_compdevimposto.Checked)
            {
                ST_Devolucao.Checked = false;
                ST_Complementar.Checked = false;
                ST_Mestra.Checked = false;
                ST_SimplesRemessa.Checked = false;
                st_retorno.Checked = false;
            }
        }
    }
}

