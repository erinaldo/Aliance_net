using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCad_ConvUnidade : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_ConvUnidade()
        {
            InitializeComponent();
            DTS = BS_CadConvUnidade;
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
                return TCN_CadConvUnidade.Gravar(BS_CadConvUnidade.Current as TRegistro_CadConvUnidade, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadConvUnidade lista = TCN_CadConvUnidade.Busca(CD_Unidade_Orig.Text,
                                                                  CD_Unidade_Dest.Text, 
                                                                  string.Empty, 
                                                                  0, 
                                                                  string.Empty,
                                                                  null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadConvUnidade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadConvUnidade.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadConvUnidade.AddNew();
                base.afterNovo();
                if (!CD_Unidade_Orig.Focus())
                    CD_Unidade_Dest.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadConvUnidade.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                CD_Unidade_Dest.Focus();
            BB_UNIDADE_ORIG.Enabled = false;
            BB_UNIDADE_DEST.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (g_convUnidade.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadConvUnidade.Excluir(BS_CadConvUnidade.Current as TRegistro_CadConvUnidade, null);
                        BS_CadConvUnidade.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
            else
            {
                MessageBox.Show("Não Existe Conversão de Unidade Para Ser Excluída!");
            }
        }

        private void CD_UNIDADE_ORIG_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_UNIDADE|=|'" + CD_Unidade_Orig.Text + "'"
            , new Componentes.EditDefault[] { CD_Unidade_Orig, DS_Unidade_Orig }, new TCD_CadUnidade());
        }

        private void BB_UNIDADE_ORIG_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("CD_UNIDADE|Cód. Unidade Origem|50;DS_UNIDADE|Desc. Unidade Origem|350"
                     , new Componentes.EditDefault[] { CD_Unidade_Orig, DS_Unidade_Orig }, new TCD_CadUnidade(), null);
        }

        private void CD_UNIDADE_DEST_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_UNIDADE|=|'" + CD_Unidade_Dest.Text + "'"
             , new Componentes.EditDefault[] { CD_Unidade_Dest, DS_Unidade_Dest }, new TCD_CadUnidade());
        }

        private void BB_UNIDADE_DEST_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("CD_UNIDADE|Cód. Unidade Destino|50;DS_UNIDADE|Desc. Unidade Destino|350"
             , new Componentes.EditDefault[] { CD_Unidade_Dest, DS_Unidade_Dest }, new TCD_CadUnidade(), null);
        }

        private void TFCad_ConvUnidade_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_convUnidade);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("* - Multiplicação", "*"));
            CBox1.Add(new Utils.TDataCombo("/ - Divisão", "/"));
            ST_Fator.DataSource = CBox1;
            ST_Fator.DisplayMember = "Display";
            ST_Fator.ValueMember = "Value";
            ST_Fator.SelectedValue = "";
        }

        private void g_convUnidade_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_convUnidade.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadConvUnidade.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadConvUnidade());
            TList_CadConvUnidade lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_convUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_convUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadConvUnidade(lP.Find(g_convUnidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_convUnidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadConvUnidade(lP.Find(g_convUnidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_convUnidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadConvUnidade.List as TList_CadConvUnidade).Sort(lComparer);
            BS_CadConvUnidade.ResetBindings(false);
            g_convUnidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCad_ConvUnidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_convUnidade);
        }    
    }
}
