using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class TFCad_Equipamento : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Equipamento()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("MAQUINA", "M"));
            cbx.Add(new Utils.TDataCombo("VEICULO", "V"));
            cbx.Add(new Utils.TDataCombo("IMPLEMENTO", "I"));
            cbx.Add(new Utils.TDataCombo("OUTROS", "O"));
            tp_equipamento.DataSource = cbx;
            tp_equipamento.DisplayMember = "Display";
            tp_equipamento.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("OTIMO", "O"));
            cbx1.Add(new Utils.TDataCombo("BOM", "B"));
            cbx1.Add(new Utils.TDataCombo("REGULAR", "R"));
            cbx1.Add(new Utils.TDataCombo("RUIM", "U"));
            tp_conservacao.DataSource = cbx1;
            tp_conservacao.DisplayMember = "Display";
            tp_conservacao.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_equipamento.Focused)
                    (bsEquipamento.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Equipamento).Vl_equipamento =
                        vl_equipamento.Value;
                return CamadaNegocio.Fazenda.Cadastros.TCN_Equipamento.Gravar(bsEquipamento.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Equipamento, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Equipamento lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Equipamento.Buscar(cd_equipamento.Text,
                                                                       cd_fazenda.Text,
                                                                       tp_equipamento.SelectedValue != null ? tp_equipamento.SelectedValue.ToString() : string.Empty,
                                                                       tp_conservacao.SelectedValue != null ? tp_conservacao.SelectedValue.ToString() : string.Empty,
                                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEquipamento.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsEquipamento.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsEquipamento.AddNew();
                base.afterNovo();
                cd_equipamento.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsEquipamento.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_fazenda.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cd_fazenda.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Equipamento.Excluir(
                        bsEquipamento.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Equipamento, null);
                    bsEquipamento.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_Equipamento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEquipamento);
            this.pDados.set_FormatZero();
        }

        private void bb_equipamento_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_equipamento, ds_equipamento }, "isnull(e.st_patrimonio, 'N')|=|'S'");
        }

        private void cd_equipamento_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_equipamento.Text.Trim() + "';isnull(e.st_patrimonio, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_equipamento, ds_equipamento },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Fazenda|150;" +
                              "a.cd_fazenda|Cd. Fazenda|80";
            string vParam = "isnull(b.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Fazenda(), vParam);
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "isnull(b.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Fazenda());
        }

        private void gEquipamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEquipamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEquipamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fazenda.Cadastros.TRegistro_Equipamento());
            CamadaDados.Fazenda.Cadastros.TList_Equipamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEquipamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEquipamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Equipamento(lP.Find(gEquipamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEquipamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Equipamento(lP.Find(gEquipamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEquipamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEquipamento.List as CamadaDados.Fazenda.Cadastros.TList_Equipamento).Sort(lComparer);
            bsEquipamento.ResetBindings(false);
            gEquipamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCad_Equipamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEquipamento);
        }
    }
}
