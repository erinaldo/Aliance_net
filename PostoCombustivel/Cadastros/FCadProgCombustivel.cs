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
    public partial class TFCadProgCombustivel : FormCadPadrao.FFormCadPadrao
    {
        public TFCadProgCombustivel()
        {
            InitializeComponent();
            DTS = bsProgCombustivel;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("PERCENTUAL", "P"));
            cbx.Add(new TDataCombo("VALOR", "V"));
            tp_desconto.DataSource = cbx;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";
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
            if (pc_desconto.Focused)
                (bsProgCombustivel.Current as TRegistro_ProgCombustivel).Pc_desconto = pc_desconto.Value;
            return TCN_ProgCombustivel.Gravar((bsProgCombustivel.Current as TRegistro_ProgCombustivel), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {
            TList_ProgCombustivel lista = TCN_ProgCombustivel.Buscar(cd_empresa.Text,
                                                                     cd_prod.Text,
                                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsProgCombustivel.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsProgCombustivel.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsProgCombustivel.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsProgCombustivel.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            bb_produto.Enabled = false;
            pc_desconto.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsProgCombustivel.Current != null)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_ProgCombustivel.Excluir(bsProgCombustivel.Current as TRegistro_ProgCombustivel, null);
                        bsProgCombustivel.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
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

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prod, ds_prod }, vParam);
        }

        private void cd_prod_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_prod.Text.Trim() + "';" +
                            "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_prod, ds_prod },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gProg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProg.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProgCombustivel.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_ProgCombustivel());
            CamadaDados.PostoCombustivel.Cadastros.TList_ProgCombustivel lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_ProgCombustivel(lP.Find(gProg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_ProgCombustivel(lP.Find(gProg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProgCombustivel.List as CamadaDados.PostoCombustivel.Cadastros.TList_ProgCombustivel).Sort(lComparer);
            bsProgCombustivel.ResetBindings(false);
            gProg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
