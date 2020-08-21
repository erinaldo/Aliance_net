using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;

namespace Faturamento.Cadastros
{
    public partial class TFCadEmissorCF : FormCadPadrao.FFormCadPadrao
    {
        public TFCadEmissorCF()
        {
            InitializeComponent();
            DTS = bsEmissorCF;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("BEMATECH", "BT"));
            cbx.Add(new Utils.TDataCombo("DARUMA", "DR"));
            cbx.Add(new Utils.TDataCombo("SWEDA", "SW"));
            cbx.Add(new Utils.TDataCombo("ELGIN", "EG"));
            tp_marca.DataSource = cbx;
            tp_marca.DisplayMember = "Display";
            tp_marca.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx1.Add(new Utils.TDataCombo("CANCELADO", "C"));
            st_registro.DataSource = cbx1;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("DOCUMENTO VINCULADO", "DV"));
            cbx2.Add(new Utils.TDataCombo("RELATORIO GERENCIAl", "RG"));
            tp_confdivida.DataSource = cbx2;
            tp_confdivida.DisplayMember = "Display";
            tp_confdivida.ValueMember = "Value";
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
            {
                if (portaimp.Focused)
                    (bsEmissorCF.Current as TRegistro_EmissorCF).PortaImp = portaimp.Value;
                return TCN_EmissorCF.Gravar(bsEmissorCF.Current as TRegistro_EmissorCF, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_EmissorCF lista = TCN_EmissorCF.Buscar(id_equipamento.Text,
                                                         ds_equipamento.Text,
                                                         id_pdv.Text,
                                                         string.Empty,
                                                         nr_serie.Text,
                                                         tp_marca.SelectedValue != null ? tp_marca.SelectedValue.ToString() : string.Empty,
                                                         st_registro.SelectedValue != null ? st_registro.SelectedValue.ToString() : string.Empty,
                                                         null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEmissorCF.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsEmissorCF.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsEmissorCF.AddNew();
                base.afterNovo();
                if (!id_equipamento.Focus())
                    ds_equipamento.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsEmissorCF.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                ds_equipamento.Focus();
        }

        public override void limparControls()
        {
            pDados.LimparRegistro();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_EmissorCF.Excluir(bsEmissorCF.Current as TRegistro_EmissorCF, null);
                    bsEmissorCF.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
               
        private void bb_pdv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_pdv|Ponto Venda|200;" +
                              "a.id_pdv|Id. PDV|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_pdv, ds_pdv },
                                            new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda(), string.Empty);
        }

        private void id_pdv_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_pdv|=|" + id_pdv.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_pdv, ds_pdv },
                                            new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda());
        }

        private void TFCadEmissorCF_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEmissorCF);
        }

        private void TFCadEmissorCF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEmissorCF);
        }

        private void gEmissorCF_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gEmissorCF.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gEmissorCF.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gEmissorCF_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEmissorCF.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEmissorCF.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_EmissorCF());
            TList_EmissorCF lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEmissorCF.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEmissorCF.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_EmissorCF(lP.Find(gEmissorCF.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEmissorCF.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_EmissorCF(lP.Find(gEmissorCF.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEmissorCF.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEmissorCF.List as TList_EmissorCF).Sort(lComparer);
            bsEmissorCF.ResetBindings(false);
            gEmissorCF.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
