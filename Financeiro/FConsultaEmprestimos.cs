using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFConsultaEmprestimos : Form
    {
        private bool Altera_Relatorio = false;
        public TFConsultaEmprestimos()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_emprestimo.Clear();
            CD_Empresa.Clear();
            cd_clifor.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            st_recebido.Checked = false;
            st_concedido.Checked = false;
            st_ativo.Checked = false;
            st_cancelado.Checked = false;
            st_devolvido.Checked = false;
        }

        private void afterNovo()
        {
            using (TFEmprestimos fEmp = new TFEmprestimos())
            {
                if (fEmp.ShowDialog() == DialogResult.OK)
                    if (fEmp.rEmp != null)
                    {
                        if (fEmp.rEmp.lCheque.Count > 0)
                            if (fEmp.rEmp.lCheque.Sum(p => p.Vl_titulo) > fEmp.rEmp.Vl_emprestimo)
                                if (MessageBox.Show("Soma dos cheques maior que valor do emprestimo.\r\n" +
                                                   "Deseja gravar empréstimo no valor total dos cheques?", "Pergunta",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                    fEmp.rEmp.Vl_emprestimo = fEmp.rEmp.lCheque.Sum(p => p.Vl_titulo);
                                else
                                    return;
                        try
                        {
                            CamadaNegocio.Financeiro.Emprestimos.TCN_Emprestimos.Gravar(fEmp.rEmp, null);
                            MessageBox.Show("Emprestimo gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_emprestimo.Text = fEmp.rEmp.Id_emprestimostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void DevolverEmprestimo()
        {
            if (bsEmprestimo.Current != null)
            {
                if ((bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido devolver emprestimo cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Vl_atual > decimal.Zero)
                    using (TFDevEmprestimo fDev = new TFDevEmprestimo())
                    {
                        fDev.rEmp = bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos;
                        if(fDev.ShowDialog() == DialogResult.OK)
                            if (fDev.rEmp != null)
                            {
                                if (fDev.rEmp.lCheque.Count > 0)
                                    if (fDev.rEmp.lCheque.Sum(p => p.Vl_titulo) > fDev.rEmp.Vl_devolver)
                                    {
                                        MessageBox.Show("Soma dos cheques maior que valor do emprestimo.", "Mensagem",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                try
                                {
                                    CamadaNegocio.Financeiro.Emprestimos.TCN_Emprestimos.DevolverEmprestimo(fDev.rEmp, null);
                                    MessageBox.Show("Devolução realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.LimparFiltros();
                                    id_emprestimo.Text = fDev.rEmp.Id_emprestimostr;
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                else
                    MessageBox.Show("Emprestimo não possui mais saldo para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterExclui()
        {
            if (MessageBox.Show("Deseja cancelar o emprestimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                != DialogResult.Yes)
                return;
            if (bsEmprestimo.Current != null)
            {
                if ((bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Emprestimo ja se encontra cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_emprestimo_x_caixa x " +
                                        "where x.cd_contager = a.cd_contager " +
                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                        "and x.tp_lancto = 'D' " +
                                        "and x.cd_empresa = '" + (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Cd_empresa.Trim() + "' " +
                                        "and x.id_emprestimo = " + (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Id_emprestimostr + ")"
                        }
                    }, "1") != null)
                    if (MessageBox.Show("Emprestimo ja possui devolução, o cancelamento do mesmo ira cancelar as devoluções.\r\n" +
                                       "Deseja cancelar mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        return;
                try
                {
                    CamadaNegocio.Financeiro.Emprestimos.TCN_Emprestimos.Excluir((bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos), null);
                    MessageBox.Show("Emprestimo cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string tp_emp = string.Empty;
            string virg = string.Empty;
            if (st_recebido.Checked)
            {
                tp_emp = "'R'";
                virg = ",";
            }
            if(st_concedido.Checked)
                tp_emp += virg + "'C'";
            string status = string.Empty;
            virg = string.Empty;
            if (st_ativo.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (st_cancelado.Checked)
                status += virg + "'C'";
            bsEmprestimo.DataSource = CamadaNegocio.Financeiro.Emprestimos.TCN_Emprestimos.Buscar(id_emprestimo.Text,
                                                                                                  CD_Empresa.Text,
                                                                                                  cd_clifor.Text,
                                                                                                  DT_Inicial.Text,
                                                                                                  DT_Final.Text,
                                                                                                  tp_emp,
                                                                                                  status,
                                                                                                  st_devolvido.Checked,
                                                                                                  null);
            bsEmprestimo_PositionChanged(this, new EventArgs());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void TFConsultaEmprestimos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCaixa);
            Utils.ShapeGrid.RestoreShape(this, gEmprestimo);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
                
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsEmprestimo_PositionChanged(object sender, EventArgs e)
        {
            if (bsEmprestimo.Current != null)
            {
                (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).lCaixa =
                    CamadaNegocio.Financeiro.Emprestimos.TCN_Emprestimo_X_Caixa.BuscarCaixa(
                    (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Id_emprestimostr,
                    (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Cd_empresa,
                    null);
                bsEmprestimo.ResetCurrentItem();
            }
        }

        private void gEmprestimo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEmprestimo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEmprestimo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos());
            CamadaDados.Financeiro.Emprestimos.TList_Emprestimos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEmprestimo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEmprestimo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Emprestimos.TList_Emprestimos(lP.Find(gEmprestimo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEmprestimo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Emprestimos.TList_Emprestimos(lP.Find(gEmprestimo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEmprestimo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEmprestimo.List as CamadaDados.Financeiro.Emprestimos.TList_Emprestimos).Sort(lComparer);
            bsEmprestimo.ResetBindings(false);
            gEmprestimo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gCaixa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCaixa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCaixa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa());
            CamadaDados.Financeiro.Caixa.TList_LanCaixa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Caixa.TList_LanCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Caixa.TList_LanCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Sort(lComparer);
            bsCaixa.ResetBindings(false);
            gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gEmprestimo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gEmprestimo.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                    {
                        DataGridViewRow linha = gEmprestimo.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gEmprestimo.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_DEVOLVER_Click(object sender, EventArgs e)
        {
            this.DevolverEmprestimo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFConsultaEmprestimos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F4))
                this.DevolverEmprestimo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void TFConsultaEmprestimos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCaixa);
            Utils.ShapeGrid.SaveShape(this, gEmprestimo);
        }



        private void BB_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsEmprestimo.Current != null)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFRelatorioEmprestimo";
                Relatorio.NM_Classe = this.Name;
                Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);
                Relatorio.Ident = "TFRelatorioEmprestimo";
                Relatorio.Altera_Relatorio = this.Altera_Relatorio;
                Relatorio.DTS_Relatorio = bsEmprestimo;


                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Cd_clifor;
                        fImp.pMensagem = "RELATÓRIO DE EMPRESTIMOS";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO DE EMPRESTIMOS",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void relatorioSeparacaooItensDoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsCaixa.Current != null)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFRelatorioDevolucao";
                Relatorio.NM_Classe = this.Name;
                Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);
                Relatorio.Ident = "TFRelatorioDevolucao";
                Relatorio.Altera_Relatorio = this.Altera_Relatorio;
                BindingSource bd = new BindingSource();
                bd.DataSource = new CamadaDados.Financeiro.Emprestimos.TList_Emprestimos() { bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos };
                Relatorio.DTS_Relatorio = bd;


                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Cd_clifor;
                        fImp.pMensagem = "RELATÓRIO DE DEVOLUCAO";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO DE DEVOLUCAO",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void toolStripDropDown_Relatorios_Click(object sender, EventArgs e)
        {

        }
    }
}
