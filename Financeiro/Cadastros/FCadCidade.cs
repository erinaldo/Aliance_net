using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadCidade : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCidade()
        {
            InitializeComponent();            
            DTS = bsCidade;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCidade.Gravar(bsCidade.Current as TRegistro_CadCidade,null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadCidade lista = TCN_CadCidade.Buscar(CD_Cidade.Text.Trim(), 
                                                         DS_Cidade.Text.Trim(), 
                                                         UF.Text.Trim(), 
                                                         string.Empty, 
                                                         0, 
                                                         null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCidade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCidade.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value,this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if((vTP_Modo==TTpModo.tm_busca)||(vTP_Modo==TTpModo.tm_Standby))
                bsCidade.AddNew();
            base.afterNovo();
            if (!CD_Cidade.Focus())
                DS_Cidade.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!CD_Cidade.Focus())
                    DS_Cidade.Focus();
            }
        }
        public override void afterCancela()
        {
            base.afterCancela();
            
        }

        private void bb_uf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.UF|Sigla|60;" +
                              "a.CD_UF|Código IBGE|80;" +
                              "a.DS_UF|Estado|300";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { UF, ds_uf },
                                    new TCD_CadUf(), "");
        }

        private void UF_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_uf|=|'" + UF.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { UF, ds_uf },
                                    new TCD_CadUf());
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadCidade.Excluir(bsCidade.Current as TRegistro_CadCidade, null);
                        bsCidade.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TFCadCidade_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCidade);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCidade);
        }

        private void gCidade_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCidade.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCidade.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadCidade());
            TList_CadCidade lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadCidade(lP.Find(gCidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadCidade(lP.Find(gCidade.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCidade.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCidade.List as TList_CadCidade).Sort(lComparer);
            bsCidade.ResetBindings(false);
            gCidade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}

