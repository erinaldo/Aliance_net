using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadDetRecIsentaPisCofins : FormCadPadrao.FFormCadPadrao
    {
        public TFCadDetRecIsentaPisCofins()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_DetRecIsentaPisCofins.Gravar(bsDetRecIsenta.Current as CamadaDados.Fiscal.TRegistro_DetRecIsentaPisCofins, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_DetRecIsentaPisCofins lista =
                CamadaNegocio.Fiscal.TCN_DetRecIsentaPisCofins.Buscar(id_detrecisenta.Text,
                                                                      CD_Imposto.Text,
                                                                      cd_st.Text,
                                                                      ds_detrecisenta.Text,
                                                                      null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsDetRecIsenta.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsDetRecIsenta.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsDetRecIsenta.AddNew();
            base.afterNovo();
            CD_Imposto.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_imposto.Enabled = false;
            bb_st.Enabled = false;
            ds_detrecisenta.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsDetRecIsenta.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_DetRecIsentaPisCofins.Excluir((bsDetRecIsenta.Current as CamadaDados.Fiscal.TRegistro_DetRecIsentaPisCofins), null);
                    bsDetRecIsenta.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gDetRecIsenta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDetRecIsenta.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDetRecIsenta.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_DetRecIsentaPisCofins());
            CamadaDados.Fiscal.TList_DetRecIsentaPisCofins lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDetRecIsenta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDetRecIsenta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_DetRecIsentaPisCofins(lP.Find(gDetRecIsenta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDetRecIsenta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_DetRecIsentaPisCofins(lP.Find(gDetRecIsenta.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDetRecIsenta.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDetRecIsenta.List as CamadaDados.Fiscal.TList_DetRecIsentaPisCofins).Sort(lComparer);
            bsDetRecIsenta.ResetBindings(false);
            gDetRecIsenta.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.cd_imposto|Cd. Imposto|80";
            string vParam = "||a.st_pis = 0 or a.st_cofins = 0";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Imposto, ds_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto(),
                                            vParam);
        }

        private void CD_Imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + CD_Imposto.Text + ";" +
                            "||a.st_pis = 0 or a.st_cofins = 0";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Imposto, ds_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void cd_st_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_st|=|'" + cd_st.Text.Trim() + "';"+
                "a.cd_imposto|=|" + (string.IsNullOrEmpty(CD_Imposto.Text) ? "null" : CD_Imposto.Text);
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_st, ds_situacao },
                                            new CamadaDados.Fiscal.TCD_CadSitTribut());
        }

        private void bb_st_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_situacao|Situação Tributaria|200;" +
                              "a.cd_st|Cd. St.|80";
            string vParam = "a.cd_imposto|=|" + (string.IsNullOrEmpty(CD_Imposto.Text) ? "null" : CD_Imposto.Text);
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_st, ds_situacao },
                                            new CamadaDados.Fiscal.TCD_CadSitTribut(), vParam);
        }

        private void TFCadDetRecIsentaPisCofins_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gDetRecIsenta);
            this.pDados.set_FormatZero();
        }

        private void TFCadDetRecIsentaPisCofins_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gDetRecIsenta);
        }
    }
}
