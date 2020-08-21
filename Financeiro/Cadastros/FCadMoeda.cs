using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadMoeda : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMoeda()
        {
            InitializeComponent();
            DTS = bsMoeda;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadMoeda.GravarMoeda(bsMoeda.Current as TRegistro_Moeda, null);
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
                bsMoeda.AddNew();
            base.afterNovo();
            if (!cd_moeda.Focus())
                ds_moeda_singular.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                ds_moeda_singular.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsMoeda.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_Moeda lista = TCN_CadMoeda.Buscar(cd_moeda.Text,
                                                    ds_moeda_singular.Text,
                                                    ds_moeda_plural.Text,
                                                    sigla.Text,
                                                    0,
                                                    string.Empty,
                                                    null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMoeda.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsMoeda.Clear();
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
                        TCN_CadMoeda.DeletarMoeda(bsMoeda.Current as TRegistro_Moeda, null);
                        bsMoeda.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void FCadMoeda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMoeda);
        }

        private void FCadMoeda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMoeda);
        }

        private void gMoeda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gMoeda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsMoeda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Moeda());
            TList_Moeda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gMoeda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gMoeda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Moeda(lP.Find(gMoeda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gMoeda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Moeda(lP.Find(gMoeda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gMoeda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsMoeda.List as TList_Moeda).Sort(lComparer);
            bsMoeda.ResetBindings(false);
            gMoeda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
        }
    }
}
