using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadTpContribuicaoPisCofins : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpContribuicaoPisCofins()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_TpContribuicaoPisCofins.Gravar(bsTpContribuicao.Current as CamadaDados.Fiscal.TRegistro_TpContribuicaoPisCofins, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_TpContribuicaoPisCofins lista =
                CamadaNegocio.Fiscal.TCN_TpContribuicaoPisCofins.Buscar(id_tpcontribuicao.Text,
                                                                        ds_tpcontribuicao.Text,
                                                                        null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpContribuicao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTpContribuicao.Clear();
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
                bsTpContribuicao.AddNew();
            base.afterNovo();
            if (!id_tpcontribuicao.Focus())
                ds_tpcontribuicao.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_tpcontribuicao.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpContribuicao.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_TpContribuicaoPisCofins.Excluir(bsTpContribuicao.Current as CamadaDados.Fiscal.TRegistro_TpContribuicaoPisCofins, null);
                    bsTpContribuicao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gTpContribuicao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpContribuicao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpContribuicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_TpContribuicaoPisCofins());
            CamadaDados.Fiscal.TList_TpContribuicaoPisCofins lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpContribuicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpContribuicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_TpContribuicaoPisCofins(lP.Find(gTpContribuicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpContribuicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_TpContribuicaoPisCofins(lP.Find(gTpContribuicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpContribuicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpContribuicao.List as CamadaDados.Fiscal.TList_TpContribuicaoPisCofins).Sort(lComparer);
            bsTpContribuicao.ResetBindings(false);
            gTpContribuicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

    }
}
