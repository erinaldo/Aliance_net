using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFCadDespesa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadDespesa()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DESPESA VIAGEM", "DV"));
            cbx.Add(new Utils.TDataCombo("MANUTENÇÃO/DESPESA VEICULO", "MV"));
            cbx.Add(new Utils.TDataCombo("ABASTECIMENTO", "AB"));
            cbx.Add(new Utils.TDataCombo("MANUTENÇÃO INTERNA", "MI"));
            cbx.Add(new Utils.TDataCombo("INFRAÇÃO", "IF"));
            tp_despesa.DataSource = cbx;
            tp_despesa.DisplayMember = "Display";
            tp_despesa.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Despesa.Gravar(bsDespesa.Current as TRegistro_Despesa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Despesa lista = TCN_Despesa.Buscar(id_despesa.Text,
                                                     ds_despesa.Text,
                                                     (tp_despesa.SelectedValue != null ? tp_despesa.SelectedValue.ToString() : string.Empty),
                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsDespesa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsDespesa.Clear();
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
                bsDespesa.AddNew();
            base.afterNovo();
            if (!id_despesa.Focus())
                ds_despesa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_despesa.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsDespesa.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_Despesa.Excluir(bsDespesa.Current as TRegistro_Despesa, null);
                    bsDespesa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gDespesa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDespesa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDespesa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Despesa());
            TList_Despesa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDespesa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDespesa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Despesa(lP.Find(gDespesa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDespesa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Despesa(lP.Find(gDespesa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDespesa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDespesa.List as TList_Despesa).Sort(lComparer);
            bsDespesa.ResetBindings(false);
            gDespesa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadDespesa_Load(object sender, EventArgs e)
        {

        }
    }
}
