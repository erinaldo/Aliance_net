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
    public partial class TFCadBanco : FormCadPadrao.FFormCadPadrao
    {
        public TFCadBanco()
        {
            InitializeComponent();
            DTS = BS_CadBanco;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bordainferior.Focused)
                    (BS_CadBanco.Current as TRegistro_CadBanco).Bordainferior = bordainferior.Value;
                return TCN_CadBanco.GravarBanco(BS_CadBanco.Current as TRegistro_CadBanco, null);
            }
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            TList_CadBanco lista = TCN_CadBanco.Buscar(cd_banco.Text, ds_banco.Text, "", 0, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadBanco.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        BS_CadBanco.Clear();
                return lista.Count;
            }
            else
                return 0;
           
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value,this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadBanco.AddNew();
                base.afterNovo();
                cd_banco.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadBanco.RemoveCurrent();
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
                        TCN_CadBanco.DeletarBanco(BS_CadBanco.Current as TRegistro_CadBanco, null);
                        BS_CadBanco.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void TFCadBanco_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBanco);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void bb_layout_Click(object sender, EventArgs e)
        {
            if (BS_CadBanco.Current != null)
                using (TFCadCFGImpCheque fCfg = new TFCadCFGImpCheque())
                {
                    fCfg.Cd_banco = (BS_CadBanco.Current as TRegistro_CadBanco).Cd_banco;
                    fCfg.ShowDialog();
                }
        }

        private void gBanco_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBanco.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadBanco.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadBanco());
            TList_CadBanco lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBanco.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBanco.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadBanco(lP.Find(gBanco.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBanco.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadBanco(lP.Find(gBanco.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBanco.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadBanco.DataSource as TList_CadBanco).Sort(lComparer);
            BS_CadBanco.ResetBindings(false);
            gBanco.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBanco);
        }
    }
}

