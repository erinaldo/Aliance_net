using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class TFCadCultura : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCultura()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fazenda.Cadastros.TCN_Cultura.Gravar(bsCultura.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Cultura, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Cultura lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Cultura.Buscar(id_cultura.Text,
                                                                   ds_cultura.Text,
                                                                   cd_produto.Text,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCultura.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCultura.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCultura.AddNew();
                base.afterNovo();
                if (!id_cultura.Focus())
                    ds_cultura.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCultura.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_cultura.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Cultura.Excluir(
                        bsCultura.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Cultura, null);
                    bsCultura.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadCultura_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCultura);
            this.pDados.set_FormatZero();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gCultura_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCultura.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCultura.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fazenda.Cadastros.TRegistro_Cultura());
            CamadaDados.Fazenda.Cadastros.TList_Cultura lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCultura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCultura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Cultura(lP.Find(gCultura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCultura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Cultura(lP.Find(gCultura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCultura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCultura.List as CamadaDados.Fazenda.Cadastros.TList_Cultura).Sort(lComparer);
            bsCultura.ResetBindings(false);
            gCultura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadCultura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCultura);
        }
    }
}
