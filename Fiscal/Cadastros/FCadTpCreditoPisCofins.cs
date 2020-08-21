using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadTpCreditoPisCofins : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpCreditoPisCofins()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_TpCreditoPisCofins.Gravar(bsTpCredito.Current as CamadaDados.Fiscal.TRegistro_TpCreditoPisCofins, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_TpCreditoPisCofins lista =
                CamadaNegocio.Fiscal.TCN_TpCreditoPisCofins.Buscar(id_tpcred.Text,
                                                                   ds_tpcred.Text,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpCredito.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTpCredito.Clear();
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
                bsTpCredito.AddNew();
            base.afterNovo();
            if (!id_tpcred.Focus())
                ds_tpcred.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_tpcred.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpCredito.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_TpCreditoPisCofins.Excluir((bsTpCredito.Current as CamadaDados.Fiscal.TRegistro_TpCreditoPisCofins), null);
                    bsTpCredito.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gTpCredito_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpCredito.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpCredito.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_TpCreditoPisCofins());
            CamadaDados.Fiscal.TList_TpCreditoPisCofins lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpCredito.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpCredito.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_TpCreditoPisCofins(lP.Find(gTpCredito.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpCredito.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_TpCreditoPisCofins(lP.Find(gTpCredito.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpCredito.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpCredito.List as CamadaDados.Fiscal.TList_TpCreditoPisCofins).Sort(lComparer);
            bsTpCredito.ResetBindings(false);
            gTpCredito.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
