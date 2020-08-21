using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class TFCadFazenda : FormCadPadrao.FFormCadPadrao
    {
        public TFCadFazenda()
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
            {
                if (area_pastagem.Focused)
                    (bsFazenda.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda).Area_pastagem =
                        area_pastagem.Value;
                if (area_preservacao.Focused)
                    (bsFazenda.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda).Area_preservacao =
                        area_preservacao.Value;
                if (area_producao.Focused)
                    (bsFazenda.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda).Area_producao =
                        area_producao.Value;
                return CamadaNegocio.Fazenda.Cadastros.TCN_Fazenda.Gravar(bsFazenda.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Fazenda lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Fazenda.Buscar(cd_fazenda.Text,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsFazenda.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsFazenda.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsFazenda.AddNew();
                base.afterNovo();
                cd_fazenda.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsFazenda.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_fazenda.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cd_unidade.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Fazenda.Excluir(
                        bsFazenda.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda, null);
                    bsFazenda.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadFazenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gFazenda);
            this.pDados.set_FormatZero();
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_fazenda, nm_fazenda }, string.Empty);
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_fazenda.Text.Trim() + "'", new Componentes.EditDefault[] { cd_fazenda, nm_fazenda });
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|150;" +
                              "a.cd_unidade|Cd. Unidade|80;" +
                              "a.sigla_unidade|UND|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidade, ds_unidade, und1, und2, und3, und4 },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidade, ds_unidade, und1, und2, und3, und4 },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void gFazenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFazenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFazenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fazenda.Cadastros.TRegistro_Fazenda());
            CamadaDados.Fazenda.Cadastros.TList_Fazenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFazenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFazenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Fazenda(lP.Find(gFazenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFazenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Fazenda(lP.Find(gFazenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFazenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFazenda.List as CamadaDados.Fazenda.Cadastros.TList_Fazenda).Sort(lComparer);
            bsFazenda.ResetBindings(false);
            gFazenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadFazenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gFazenda);
        }
    }
}
