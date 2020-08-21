using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;

namespace Faturamento.Cadastros
{
    public partial class TFCadPontoVenda : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPontoVenda()
        {
            InitializeComponent();
            DTS = bsPontoVenda;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new Utils.TDataCombo("BEMATECH", "BT"));
            tp_impnaofiscal.DataSource = cbx;
            tp_impnaofiscal.DisplayMember = "Display";
            tp_impnaofiscal.ValueMember = "Value";
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
            {
                if (vl_maxretercaixa.Focused)
                {
                    if (st_fixarvlretido.Checked &&
                        vl_maxretercaixa.Value.Equals(decimal.Zero))
                        (bsPontoVenda.Current as TRegistro_PontoVenda).St_fixarvlretidobool = false;
                    (bsPontoVenda.Current as TRegistro_PontoVenda).Vl_maxretcaixa = vl_maxretercaixa.Value;
                }
                return TCN_PontoVenda.Gravar(bsPontoVenda.Current as TRegistro_PontoVenda, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_PontoVenda lista = TCN_PontoVenda.Buscar(id_pdv.Text,
                                                           ds_pdv.Text,
                                                           cd_terminal.Text,
                                                           cd_empresa.Text,
                                                           null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsPontoVenda.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsPontoVenda.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsPontoVenda.AddNew();
                base.afterNovo();
                if (!id_pdv.Focus())
                    ds_pdv.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsPontoVenda.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                ds_pdv.Focus();
        }

        public override void limparControls()
        {
            pDados.LimparRegistro();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_PontoVenda.Excluir(bsPontoVenda.Current as TRegistro_PontoVenda, null);
                    bsPontoVenda.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_terminal_Click(object sender, EventArgs e)
        {
            string vColunas = " a.ds_TERMINAL|Nome Terminal|350;" +
                  "a.CD_TERMINAL|Cód. Terminal|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_terminal, nm_terminal },
                                   new TCD_CadTerminal(), string.Empty);
        }

        private void cd_terminal_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_terminal|=|'" + cd_terminal.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_terminal, nm_terminal },
                                    new TCD_CadTerminal());
        }

        private void st_fixarvlretido_Click(object sender, EventArgs e)
        {
            if (st_fixarvlretido.Checked &&
                vl_maxretercaixa.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar valor para fixar no caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (bsPontoVenda.Current as TRegistro_PontoVenda).St_fixarvlretidobool = false;
                bsPontoVenda.ResetCurrentItem();
            }
        }

        private void vl_maxretercaixa_Leave(object sender, EventArgs e)
        {
            if (st_fixarvlretido.Checked &&
                vl_maxretercaixa.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar valor para fixar no caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (bsPontoVenda.Current as TRegistro_PontoVenda).St_fixarvlretidobool = false;
                bsPontoVenda.ResetCurrentItem();
            }
        }

        private void gPontoVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPontoVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPontoVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PontoVenda());
            TList_PontoVenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPontoVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPontoVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PontoVenda(lP.Find(gPontoVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPontoVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PontoVenda(lP.Find(gPontoVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPontoVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPontoVenda.List as TList_PontoVenda).Sort(lComparer);
            bsPontoVenda.ResetBindings(false);
            gPontoVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadPontoVenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPontoVenda);
        }

        private void TFCadPontoVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPontoVenda);
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

        private void bb_impressoras_Click(object sender, EventArgs e)
        {
            if (this.vTP_Modo.Equals(Utils.TTpModo.tm_Insert) ||
                 this.vTP_Modo.Equals(Utils.TTpModo.tm_Edit))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            impressorapadrao.Text = fLista.Impressora;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string vColunas = " a.DS_LOCALIMP|LOCAL IMP|350;" +
                  "a.ID_LOCALIMP|Cód. LOCAL IMP|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault1, editDefault2},
                                   new CamadaDados.Restaurante.Cadastro.TCD_LocalImp(), string.Empty);
        }
          

        private void editDefault1_Leave(object sender, EventArgs e)
        {

            string vParam = "a.ID_LOCALIMP|=|'" + editDefault1.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { editDefault1, editDefault2 },
                                    new CamadaDados.Restaurante.Cadastro.TCD_LocalImp());
        }
    }
}
