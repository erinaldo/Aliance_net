using System;
using System.Collections;
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
    public partial class TFCadHistorico : FormCadPadrao.FFormCadPadrao
    {
        public TFCadHistorico()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("(NENHUM)", ""));
            cbx.Add(new TDataCombo("PAGAR", "P"));
            cbx.Add(new TDataCombo("RECEBER", "R"));
            tp_mov.DataSource = cbx;
            tp_mov.DisplayMember = "Display";
            tp_mov.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadHistorico.Gravar(bsHistorico.Current as TRegistro_CadHistorico, null);
            else
                return "";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsHistorico.AddNew();
            base.afterNovo();
            if (!CD_Historico.Focus())
                tp_mov.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                tp_mov.Enabled = false;
                DS_Historico.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsHistorico.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CadHistorico lista = TCN_CadHistorico.Buscar(CD_Historico.Text,
                                                                tp_mov.SelectedValue != null ? tp_mov.SelectedValue.ToString() : string.Empty,
                                                                DS_Historico.Text,
                                                                CD_Historico_Quitacao.Text,
                                                                cd_grupocf_juro.Text,
                                                                0,
                                                                string.Empty);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsHistorico.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsHistorico.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterExclui()
        {
            base.afterExclui();
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
                        TCN_CadHistorico.Excluir(bsHistorico.Current as TRegistro_CadHistorico, null);
                        bsHistorico.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message); }
                }
            }
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpHist|Tipo Histórico|350;" +
                              "TP_Hist|Cód. TP. Hist|100;" +
                              "st_caixagerencial|St. Cx.Gerencial|100;" +
                              "ST_Financeiro|St. Financeiro|100;" +
                              "ST_Quitacoes|St. Quitações|100;" +
                              "ST_Faturamento|St. Faturamenti|100";
            
           DataRowView linha =  UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Tp_Hist, DS_TpHist },
                                            new TCD_TPHist(), string.Empty);
        }
       
        private void Tp_Hist_Leave(object sender, EventArgs e)
        {
             string vColunas = "tp_hist|=|'" + Tp_Hist.Text.Trim() + "'";
             UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Tp_Hist, DS_TpHist },
                                     new TCD_TPHist());
        }

        private void CD_Historioco_Quitacao_Leave(object sender, EventArgs e)
      {
          string vColunas = "a.CD_Historico|=|'" + CD_Historico_Quitacao.Text + "'";
          if (tp_mov.SelectedValue != null)
              vColunas += ";a.TP_Mov|=|'" + tp_mov.SelectedValue.ToString().Trim().ToUpper() + "'";
          UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico_Quitacao, DS_Historico_Quitacao },
                                  new TCD_CadHistorico());
      }

        private void BB_Historioco_Quitacao_Click(object sender, EventArgs e)
      {
          string vColunas = "a.DS_Historico|Des. Histórico Quitação|350;" +
                            "a.CD_Historico|Cód. Histórico Quitação|100";
          string vParamFixo = string.Empty;
          if (tp_mov.SelectedValue != null)
              vParamFixo += ";a.TP_Mov|=|'" + tp_mov.SelectedValue.ToString().Trim().ToUpper() + "'";
              UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Quitacao, DS_Historico_Quitacao },
                                      new TCD_CadHistorico(), vParamFixo);
      }

        public override void afterPrint()
        {
            if (bsHistorico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsHistorico;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + this.Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else { MessageBox.Show("Não Existe Registro Para ser Impresso No Relatório!"); }
        }

        private void tp_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                CD_Historico_Quitacao.Clear();
                DS_Historico_Quitacao.Clear();
            }
        }

        private void TFCadHistorico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro_Historico);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void bb_grupocf_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupocf|Despesas Fixas|200;" +
                              "a.cd_grupocf|Codigo|80;" +
                              "b.ds_grupocf|Grupo Pai|200";
            string vParam = "isnull(a.st_sintetico, 'N')|<>|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupocf_juro, ds_grupocf_juro },
                                    new TCD_CadGrupoCF(), vParam);
        }

        private void cd_grupocf_juro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupocf|=|'" + cd_grupocf_juro.Text.Trim() + "';" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupocf_juro, ds_grupocf_juro },
                                    new TCD_CadGrupoCF());
        }

        private void TFCadHistorico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro_Historico);
        }

        private void gCadastro_Historico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro_Historico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsHistorico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadHistorico());
            TList_CadHistorico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro_Historico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro_Historico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadHistorico(lP.Find(gCadastro_Historico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro_Historico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadHistorico(lP.Find(gCadastro_Historico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro_Historico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsHistorico.List as TList_CadHistorico).Sort(lComparer);
            bsHistorico.ResetBindings(false);
            gCadastro_Historico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}

