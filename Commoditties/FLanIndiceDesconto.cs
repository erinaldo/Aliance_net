using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFLanIndiceDesconto : Form
    {
        private bool Altera_relatorio = false;

        public TFLanIndiceDesconto()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFDescontoAmostra fDesc = new TFDescontoAmostra())
            {
                if(fDesc.ShowDialog() == DialogResult.OK)
                    if(fDesc.rDesc != null)
                        try
                        {
                            CamadaNegocio.Graos.TCN_DescontoXAmostra.Gravar(fDesc.rDesc, null);
                            MessageBox.Show("Cadastro desconto x amostra x indice gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cd_tabeladesconto.Clear();
                            cd_amostra.Clear();
                            cd_tabeladesconto.Text = fDesc.rDesc.Cd_tabeladesconto;
                            cd_amostra.Text = fDesc.rDesc.Cd_tipoamostra;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsDescontoAmostra.Current != null)
                using (TFDescontoAmostra fDesc = new TFDescontoAmostra())
                {
                    fDesc.rDesc = bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra;
                    if(fDesc.ShowDialog() == DialogResult.OK)
                        if(fDesc.rDesc != null)
                            try
                            {
                                CamadaNegocio.Graos.TCN_DescontoXAmostra.Gravar(fDesc.rDesc, null);
                                MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_tabeladesconto.Clear();
                                cd_amostra.Clear();
                                cd_tabeladesconto.Text = fDesc.rDesc.Cd_tabeladesconto;
                                cd_amostra.Text = fDesc.rDesc.Cd_tipoamostra;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsDescontoAmostra.Current !=null)
                if(MessageBox.Show("Confirma exclusão do registro corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Graos.TCN_DescontoXAmostra.Excluir(bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsDescontoAmostra.DataSource = CamadaNegocio.Graos.TCN_DescontoXAmostra.Buscar(cd_tabeladesconto.Text,
                                                                                           cd_amostra.Text,
                                                                                           null);
            bsDescontoAmostra_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsDescontoAmostra.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    BindingSource bin = new BindingSource();
                    bin.DataSource = new CamadaDados.Graos.TList_DescontoXAmostra() { bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra };
                    Rel.Altera_Relatorio = Altera_relatorio;
                    Rel.DTS_Relatorio = bin;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO INDICE DESCONTO";

                    if (Altera_relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO INDICE DESCONTO",
                                           fImp.pDs_mensagem);
                        Altera_relatorio = false;
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
                                               "RELATORIO INDICE DESCONTO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void gPercDesconto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPercDesconto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPercDesconto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Graos.TRegistro_PercDesconto());
            CamadaDados.Graos.TList_PercDesconto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPercDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPercDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Graos.TList_PercDesconto(lP.Find(gPercDesconto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPercDesconto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Graos.TList_PercDesconto(lP.Find(gPercDesconto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPercDesconto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPercDesconto.List as CamadaDados.Graos.TList_PercDesconto).Sort(lComparer);
            bsPercDesconto.ResetBindings(false);
            gPercDesconto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gDescontoAmostra_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDescontoAmostra.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDescontoAmostra.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Graos.TRegistro_DescontoXAmostra());
            CamadaDados.Graos.TList_DescontoXAmostra lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDescontoAmostra.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDescontoAmostra.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Graos.TList_DescontoXAmostra(lP.Find(gDescontoAmostra.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDescontoAmostra.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Graos.TList_DescontoXAmostra(lP.Find(gDescontoAmostra.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDescontoAmostra.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDescontoAmostra.List as CamadaDados.Graos.TList_DescontoXAmostra).Sort(lComparer);
            bsDescontoAmostra.ResetBindings(false);
            gDescontoAmostra.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanIndiceDesconto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabeladesconto },
                                                new CamadaDados.Graos.TCD_TabelaDesconto());
        }

        private void bb_tabeladesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabeladesconto|Tabela Desconto|200;" +
                              "a.cd_tabeladesconto|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto },
                                            new CamadaDados.Graos.TCD_TabelaDesconto(), string.Empty);
        }

        private void cd_amostra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tipoamostra|=|'" + cd_amostra.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_amostra },
                                                new CamadaDados.Graos.TCD_CadAmostra());
        }

        private void bb_amostra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|200;" +
                              "a.cd_tipoamostra|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_amostra },
                                            new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsDescontoAmostra_PositionChanged(object sender, EventArgs e)
        {
            if (bsDescontoAmostra.Current != null)
            {
                (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).lPerc =
                CamadaNegocio.Graos.TCN_PercDesconto.Buscar((bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).Cd_tabeladesconto,
                                                            (bsDescontoAmostra.Current as CamadaDados.Graos.TRegistro_DescontoXAmostra).Cd_tipoamostra,
                                                            null);
                bsDescontoAmostra.ResetCurrentItem();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLanIndiceDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
