using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Servicos.Cadastros;
using Utils;

namespace Servico.Cadastros
{
    public partial class TFCad_TPOrdem : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TPOrdem()
        {
            InitializeComponent();
            DTS = bsTpOrdem;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("OFICINA", "O"));
            cbx.Add(new TDataCombo("PRODUÇÃO PROPRIA", "P"));
            cbx.Add(new TDataCombo("PRESTAÇÃO SERVIÇO", "S"));
            cbx.Add(new TDataCombo("SERVIÇO INTERNO", "I"));
            tp_os.DataSource = cbx;
            tp_os.DisplayMember = "Display";
            tp_os.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("DUPLICATA", "D"));
            cbx1.Add(new TDataCombo("PEDIDO", "P"));
            cbx1.Add(new TDataCombo("PRE VENDA", "V"));
            tp_faturamento.DataSource = cbx1;
            tp_faturamento.DisplayMember = "Display";
            tp_faturamento.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_TpOrdem.Gravar(bsTpOrdem.Current as TRegistro_TpOrdem, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
         if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            bsTpOrdem.AddNew();
            base.afterNovo();
            if (!tp_ordem.Focus())
                ds_tipoordem.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!tp_ordem.Focus())
                    ds_tipoordem.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTpOrdem.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_TpOrdem lista = TCN_TpOrdem.Buscar(tp_ordem.Text,ds_tipoordem.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpOrdem.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTpOrdem.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_TpOrdem.Excluir(bsTpOrdem.Current as TRegistro_TpOrdem, null);
                    bsTpOrdem.RemoveCurrent();
                    pDados.LimparRegistro();
                }
            }
        }

        private void TFCad_TPOrdem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTpOrdem);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void gTpOrdem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpOrdem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpOrdem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_TpOrdem());
            TList_TpOrdem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpOrdem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpOrdem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_TpOrdem(lP.Find(gTpOrdem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpOrdem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_TpOrdem(lP.Find(gTpOrdem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpOrdem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpOrdem.List as TList_TpOrdem).Sort(lComparer);
            bsTpOrdem.ResetBindings(false);
            gTpOrdem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCad_TPOrdem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTpOrdem);
        }
    }
}
