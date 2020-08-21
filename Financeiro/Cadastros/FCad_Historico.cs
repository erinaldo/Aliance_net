using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCad_Historico : Form
    {
        public TFCad_Historico()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("TODOS", string.Empty));
            cbx.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx;
            tp_movimento.ValueMember = "Value";
            tp_movimento.DisplayMember = "Display";
        }

        private void afterNovo()
        {
            using (TFHistorico fHistorico = new TFHistorico())
            {
                if(fHistorico.ShowDialog() == DialogResult.OK)
                    if(fHistorico.rHist != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadHistorico.Gravar(fHistorico.rHist, null);
                            MessageBox.Show("Historico gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsHistorico.Current != null)
                using (TFHistorico fHist = new TFHistorico())
                {
                    fHist.rHist = bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico;
                    if(fHist.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadHistorico.Gravar(fHist.rHist, null);
                            MessageBox.Show("Historico alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsHistorico.Current !=null)
                if(MessageBox.Show("Confirma exclusão do historico selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadHistorico.Excluir(bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico, null);
                        MessageBox.Show("Historico excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsHistorico.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsHistorico.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadHistorico.Buscar(cd_historico.Text,
                                                                                                tp_movimento.SelectedValue == null ? string.Empty : tp_movimento.SelectedValue.ToString(),
                                                                                                ds_historico.Text,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                0,
                                                                                                string.Empty);
        }

        private void TFCad_Historico_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void gHistorico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gHistorico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsHistorico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico());
            CamadaDados.Financeiro.Cadastros.TList_CadHistorico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gHistorico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gHistorico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadHistorico(lP.Find(gHistorico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gHistorico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadHistorico(lP.Find(gHistorico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gHistorico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsHistorico.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadHistorico).Sort(lComparer);
            bsHistorico.ResetBindings(false);
            gHistorico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }
        
        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFCad_Historico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
