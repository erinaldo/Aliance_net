using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadReceitaPisCofins : FormCadPadrao.FFormCadPadrao
    {
        public TFCadReceitaPisCofins()
        {
            InitializeComponent();
            DTS = bsReceita;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_ReceitaPisCofins.Gravar(bsReceita.Current as CamadaDados.Fiscal.TRegistro_ReceitaPisCofins, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_ReceitaPisCofins lista = CamadaNegocio.Fiscal.TCN_ReceitaPisCofins.Buscar(id_receita.Text,
                                                                                                               ds_receita.Text,
                                                                                                               null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsReceita.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsReceita.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_imposto.Enabled = false;
            ds_receita.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_busca) || (this.vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsReceita.AddNew();
                base.afterNovo();
                if (!(id_receita.Focus()))
                    ds_receita.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == Utils.TTpModo.tm_Insert)
                bsReceita.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_ReceitaPisCofins.Excluir((bsReceita.Current as CamadaDados.Fiscal.TRegistro_ReceitaPisCofins), null);
                    bsReceita.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gReceita_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gReceita.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsReceita.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_ReceitaPisCofins());
            CamadaDados.Fiscal.TList_ReceitaPisCofins lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gReceita.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gReceita.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_ReceitaPisCofins(lP.Find(gReceita.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gReceita.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_ReceitaPisCofins(lP.Find(gReceita.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gReceita.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsReceita.List as CamadaDados.Fiscal.TList_ReceitaPisCofins).Sort(lComparer);
            bsReceita.ResetBindings(false);
            gReceita.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadReceitaPisCofins_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gReceita);
            pDados.set_FormatZero();
        }

        private void TFCadReceitaPisCofins_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gReceita);
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.sigla|Sigla|50;" +
                              "a.cd_imposto|Codigo|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                new CamadaDados.Fiscal.TCD_CadImposto());
        }
    }
}
