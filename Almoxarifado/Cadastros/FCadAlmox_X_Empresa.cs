using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadAlmox_X_Empresa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadAlmox_X_Empresa()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadAlmox_X_Empresa.Gravar(bsAlmoxEmpresa.Current as TRegistro_CadAlmox_X_Empresa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadAlmox_X_Empresa lista = TCN_CadAlmox_X_Empresa.Busca(id_almox.Text, cd_empresa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsAlmoxEmpresa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsAlmoxEmpresa.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsAlmoxEmpresa.RemoveCurrent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_almox.Enabled = false;
            bb_empresa.Enabled = false;
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
                bsAlmoxEmpresa.AddNew();
            base.afterNovo();
            id_almox.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadAlmox_X_Empresa.Excluir(bsAlmoxEmpresa.Current as TRegistro_CadAlmox_X_Empresa, null);
                    bsAlmoxEmpresa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almox },
                                             new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), string.Empty);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almox },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                        new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void gAlmoxEmpresa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAlmoxEmpresa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAlmoxEmpresa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_CadAlmox_X_Empresa());
            CamadaDados.Almoxarifado.TList_CadAlmox_X_Empresa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAlmoxEmpresa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAlmoxEmpresa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadAlmox_X_Empresa(lP.Find(gAlmoxEmpresa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAlmoxEmpresa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadAlmox_X_Empresa(lP.Find(gAlmoxEmpresa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAlmoxEmpresa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAlmoxEmpresa.List as CamadaDados.Almoxarifado.TList_CadAlmox_X_Empresa).Sort(lComparer);
            bsAlmoxEmpresa.ResetBindings(false);
            gAlmoxEmpresa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadAlmox_X_Empresa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAlmoxEmpresa);
        }

        private void TFCadAlmox_X_Empresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAlmoxEmpresa);
        }
    }
}
