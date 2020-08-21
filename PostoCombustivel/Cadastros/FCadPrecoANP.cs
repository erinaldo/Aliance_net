using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.PostoCombustivel.Cadastros;
using CamadaNegocio.PostoCombustivel.Cadastros;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadPrecoANP : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPrecoANP()
        {
            InitializeComponent();
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
            if (vl_preco.Focused)
                (bsPrecoANP.Current as TRegistro_PrecoANP).Vl_preco = vl_preco.Value;
            return TCN_PrecoANP.Gravar((bsPrecoANP.Current as TRegistro_PrecoANP), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {
            TList_PrecoANP lista = TCN_PrecoANP.Buscar(id_preco.Text,
                                                       cd_combustivel.Text,
                                                       dt_preco.Text,
                                                       string.Empty,
                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsPrecoANP.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsPrecoANP.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsPrecoANP.AddNew();
            base.afterNovo();
            if (!id_preco.Focus())
                cd_combustivel.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsPrecoANP.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_combustivel.Enabled = false;
            vl_preco.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsPrecoANP.Current != null)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_PrecoANP.Excluir(bsPrecoANP.Current as TRegistro_PrecoANP, null);
                        bsPrecoANP.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
        }

        private void bb_combustivel_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_combustivel, ds_combustivel }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_combustivel_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_combustivel.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_combustivel, ds_combustivel },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gPrecoANP_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPrecoANP.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPrecoANP.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PrecoANP());
            TList_PrecoANP lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPrecoANP.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPrecoANP.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PrecoANP(lP.Find(gPrecoANP.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPrecoANP.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PrecoANP(lP.Find(gPrecoANP.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPrecoANP.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPrecoANP.List as TList_PrecoANP).Sort(lComparer);
            bsPrecoANP.ResetBindings(false);
            gPrecoANP.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
