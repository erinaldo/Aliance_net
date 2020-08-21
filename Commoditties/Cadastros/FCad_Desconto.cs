using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Graos;
using CamadaNegocio.Graos;

namespace Commoditties.Cadastros
{
    public partial class TFCad_Desconto : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Desconto()
        {
            InitializeComponent();
            DTS = BS_CadDesconto;
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
                return TCN_CadDesconto.Gravar(BS_CadDesconto.Current as TRegistro_CadDesconto, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadDesconto lista = TCN_CadDesconto.Busca(CD_TabelaDesconto.Text.Trim(), 
                                                            DS_Desconto.Text.Trim(),
                                                            null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadDesconto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadDesconto.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadDesconto.AddNew();
                base.afterNovo();
                if (!CD_TabelaDesconto.Focus())
                    DS_Desconto.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadDesconto.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if(!CD_TabelaDesconto.Focus())
                DS_Desconto.Focus();
            }
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadDesconto.Excluir(BS_CadDesconto.Current as TRegistro_CadDesconto, null);
                    BS_CadDesconto.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_Desconto_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void g_cad_tabelaDesconto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_cad_tabelaDesconto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadDesconto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadDesconto());
            TList_CadDesconto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_cad_tabelaDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_cad_tabelaDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadDesconto(lP.Find(g_cad_tabelaDesconto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_cad_tabelaDesconto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadDesconto(lP.Find(g_cad_tabelaDesconto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_cad_tabelaDesconto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadDesconto.List as TList_CadDesconto).Sort(lComparer);
            BS_CadDesconto.ResetBindings(false);
            g_cad_tabelaDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}