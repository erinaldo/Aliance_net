using System;
using System.ComponentModel;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;

namespace Estoque.Cadastros
{
    public partial class TFCad_Unidade : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Unidade()
        {
            InitializeComponent();
            DTS = BS_CadUnidade;

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo(string.Empty, string.Empty));
            cbx1.Add(new Utils.TDataCombo("METRO QUADRADO", "0"));
            cbx1.Add(new Utils.TDataCombo("METRO CUBICO", "1"));
            tp_unidade.DataSource = cbx1;
            tp_unidade.ValueMember = "Value";
            tp_unidade.DisplayMember = "Display";
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
                return TCN_CadUnidade.Gravar(BS_CadUnidade.Current as TRegistro_CadUnidade, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadUnidade lista = TCN_CadUnidade.Busca(CD_Unidade.Text, DS_Unidade.Text, Sigla_Unidade.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadUnidade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadUnidade.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadUnidade.AddNew();
                base.afterNovo();
                if (!CD_Unidade.Focus())
                    DS_Unidade.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadUnidade.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_Unidade.Focus();
        }

        public override void excluirRegistro()
        {
            if (g_CadUnidade.RowCount > 0)
            {
                if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        TCN_CadUnidade.Excluir(BS_CadUnidade.Current as TRegistro_CadUnidade, null);
                        BS_CadUnidade.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void CD_Unidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TFCad_Unidade_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void g_CadUnidade_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_CadUnidade.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadUnidade.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadUnidade());
            TList_CadUnidade lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_CadUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_CadUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadUnidade(lP.Find(g_CadUnidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_CadUnidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadUnidade(lP.Find(g_CadUnidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_CadUnidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadUnidade.List as TList_CadUnidade).Sort(lComparer);
            BS_CadUnidade.ResetBindings(false);
            g_CadUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao; 
        }
    }
}
