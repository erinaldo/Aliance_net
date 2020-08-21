using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using Utils;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCad_LocalArm : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_LocalArm()
        {
            InitializeComponent();
            DTS = BS_CadLocalArm;
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
                return TCN_CadLocalArm.Gravar(BS_CadLocalArm.Current as TRegistro_CadLocalArm, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadLocalArm lista = TCN_CadLocalArm.Busca(CD_Local.Text, 
                                                            DS_Local.Text, 
                                                            string.Empty, 
                                                            string.Empty,
                                                            null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadLocalArm.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadLocalArm.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadLocalArm.AddNew();
                base.afterNovo();
                if (!CD_Local.Focus())
                    DS_Local.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadLocalArm.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_Local.Focus();
        }

        public override void excluirRegistro()
        {
            if (g_FCadLocalArm.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadLocalArm.Excluir(BS_CadLocalArm.Current as TRegistro_CadLocalArm, null);
                        BS_CadLocalArm.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void TFCad_LocalArm_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_FCadLocalArm);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("CARGA/DESCARGA", "A"));
            CBox1.Add(new Utils.TDataCombo("CARGA", "C"));
            CBox1.Add(new Utils.TDataCombo("DESCARGA", "D"));            
            TP_Local.DataSource = CBox1;
            TP_Local.DisplayMember = "Display";
            TP_Local.ValueMember = "Value";
            TP_Local.SelectedValue = "";
        }

        private void CD_Local_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TFCad_LocalArm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_FCadLocalArm);
        }

        private void g_FCadLocalArm_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_FCadLocalArm.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadLocalArm.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadLocalArm());
            TList_CadLocalArm lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_FCadLocalArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_FCadLocalArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadLocalArm(lP.Find(g_FCadLocalArm.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_FCadLocalArm.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadLocalArm(lP.Find(g_FCadLocalArm.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_FCadLocalArm.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadLocalArm.List as TList_CadLocalArm).Sort(lComparer);
            BS_CadLocalArm.ResetBindings(false);
            g_FCadLocalArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void g_FCadLocalArm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        g_FCadLocalArm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        g_FCadLocalArm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
