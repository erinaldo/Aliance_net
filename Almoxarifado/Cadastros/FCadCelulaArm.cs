using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadCelulaArm : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCelulaArm()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCelulaArm.Gravar(bsCelulaArm.Current as TRegistro_CadCelulaArm, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadCelulaArm lista = TCN_CadCelulaArm.Buscar(id_celula.Text,
                                                               ds_celula.Text,
                                                               id_secao.Text,
                                                               Id_Rua.Text,
                                                               null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCelulaArm.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCelulaArm.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCelulaArm.RemoveCurrent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_celula.Focus();
            bb_Rua.Enabled = false;
            bb_secao.Enabled = false;
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsCelulaArm.AddNew();
            base.afterNovo();
            Id_Rua.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadCelulaArm.Excluir(bsCelulaArm.Current as TRegistro_CadCelulaArm, null);
                    bsCelulaArm.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void bb_Rua_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_rua|Nome Rua|150;id_rua|Código Rua|80"
             , new Componentes.EditDefault[] { Id_Rua, Ds_Rua }, new TCD_CadRua(), null);
        }

        private void Id_Rua_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_rua|=|" + Id_Rua.Text
                 , new Componentes.EditDefault[] { Id_Rua, Ds_Rua }, new TCD_CadRua());
        }

        private void bb_secao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_secao|Seção|100;" +
                              "a.id_secao|Id. Seção|80;" +
                              "a.id_rua|Id. Rua|80;" +
                              "b.ds_rua|Rua|100";
            string vParam = "a.id_rua|=|" + (string.IsNullOrEmpty(Id_Rua.Text) ? "null" : Id_Rua.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_secao, ds_secao },
                                    new TCD_CadSecao(), vParam);
        }

        private void id_secao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_secao|=|" + id_secao.Text + ";" +
                            "a.id_rua|=|" + (string.IsNullOrEmpty(Id_Rua.Text) ? "null" : Id_Rua.Text);
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_secao, ds_secao }, new TCD_CadSecao());
        }

        private void gCelulaArm_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCelulaArm.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCelulaArm.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_CadCelulaArm());
            CamadaDados.Almoxarifado.TList_CadCelulaArm lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCelulaArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCelulaArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadCelulaArm(lP.Find(gCelulaArm.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCelulaArm.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadCelulaArm(lP.Find(gCelulaArm.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCelulaArm.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCelulaArm.List as CamadaDados.Almoxarifado.TList_CadCelulaArm).Sort(lComparer);
            bsCelulaArm.ResetBindings(false);
            gCelulaArm.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadCelulaArm_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCelulaArm);
        }

        private void TFCadCelulaArm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCelulaArm);
        }
    }
}
