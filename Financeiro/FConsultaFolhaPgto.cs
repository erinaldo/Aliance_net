using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFConsultaFolhaPgto : Form
    {
        bool Altera_Relatorio = false;

        public TFConsultaFolhaPgto()
        {
            InitializeComponent();
        }

        private void ImprimirCheques()
        {
            //Verificar se a condicao pagamento e a vista e se o portador movimenta cheque
            CamadaDados.Financeiro.Cadastros.TList_CfgFolhaPagamento lFolha =
                CamadaNegocio.Financeiro.Cadastros.TCN_CfgFolhaPagamento.Buscar((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            if (lFolha.Count > 0)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_condpgto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lFolha[0].Cd_condpgto.Trim() + "'"
                                    }
                                }, "a.qt_parcelas");
                if (obj == null ? false : obj.ToString().Trim().Equals("0"))
                {
                    obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "cd_portador",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lFolha[0].Cd_portador.Trim() + "'"
                                }
                            }, "st_controletitulo");
                    if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("S"))
                    {
                        //Buscar lista de cheques amarradas ao lote de folha
                        CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques =
                            new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                "inner join tb_fin_caixa y " +
                                                "on x.cd_contager = y.cd_contager " +
                                                "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                "inner join tb_fin_liquidacao z " +
                                                "on y.cd_contager = z.cd_contager " +
                                                "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                "inner join tb_fin_parcela w " + 
                                                "on z.cd_empresa = w.cd_empresa " +
                                                "and z.nr_lancto = w.nr_lancto " +
                                                "inner join tb_fin_folha_x_funcionarios folha " +
                                                "on w.cd_empresa = folha.cd_empresa " +
                                                "and w.nr_lancto = folha.nr_lancto " +
                                                "where a.cd_empresa = x.cd_empresa " +
                                                "and a.cd_banco = x.cd_banco " +
                                                "and a.nr_lanctocheque = x.nr_lanctocheque " +
                                                "and x.tp_lancto = 'OR' " +
                                                "and folha.id_folha = " + (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Id_folha.Value.ToString() + ")"
                                }
                            }, 0, string.Empty, "a.nr_cheque");
                        if (lCheques.Count > 0)
                            if(MessageBox.Show("Imprimir cheques emitidos?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                try
                                {
                                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(lCheques);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        } 

        private void LimparFiltros()
        {
            CD_Empresa.Clear();
            CD_Clifor.Clear();
            id_folha.Clear();
            cbAberto.Checked = false;
            cbProcessado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFFolhaPgto fFolha = new TFFolhaPgto())
            {
                if(fFolha.ShowDialog() == DialogResult.OK)
                    if (fFolha.rFolha != null)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Gravar(fFolha.rFolha, null);
                            MessageBox.Show("Folha gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_folha.Text = fFolha.rFolha.Id_folha.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsFolhaPgto.Current != null)
            {
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido alterar lote PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFFolhaPgto fFolha = new TFFolhaPgto())
                {
                    fFolha.rFolha = bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento;
                    if(fFolha.ShowDialog() == DialogResult.OK)
                        if (fFolha.rFolha != null)
                        {
                            try
                            {
                                CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Gravar(fFolha.rFolha, null);
                                MessageBox.Show("Folha alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    this.LimparFiltros();
                    id_folha.Text = fFolha.rFolha.Id_folha.Value.ToString();
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsFolhaPgto.Current != null)
            {
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Permitido excluir somente lote em ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Excluir(bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void afterPrint()
        {
            if (bsFolhaPgto.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    (bsFolhaPgto.DataSource as CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento).ForEach(p =>
                        p.lFolhaFunc = CamadaNegocio.Financeiro.Folha_Pagamento.TCN_Folha_X_Funcionarios.Buscar(p.Id_folha.Value.ToString(),
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                null));
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsFolhaPgto;
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
        }

        private void ProcessarFolha()
        {
            if (bsFolhaPgto.Current != null)
            {
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Lote folha pagamento ja se encontra PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Count.Equals(0))
                {
                    MessageBox.Show("Não existe folha de pagamento amarrado ao lote para ser processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string msg = string.Empty;
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Exists(p => p.Vl_pagamento.Equals(0)))
                    msg = "Lote possui folha de pagamento com valor zero.\r\n";
                if (MessageBox.Show(msg.Trim() + "Confirma processamento do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.ProcessarLoteFolha(bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento, null);
                        MessageBox.Show("Lote Processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ImprimirCheques();
                        this.LimparFiltros();
                        id_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Id_folha.Value.ToString();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EstornarProcesso()
        {
            if (bsFolhaPgto.Current != null)
            {
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Lote folha pagamento ja se encontra ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma estorno do processamento do lote?\r\n" +
                                   "As duplicatas serão canceladas.\r\n" +
                                   "Caso existe duplicata liquidada, necessario antes cancelar a liquidação.", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.EstornarProcessoFolha(bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento, null);
                        MessageBox.Show("Processamento lote estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Id_folha.Value.ToString();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterBusca()
        {
            string vStatus = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                vStatus = "'A'";
                virg = ",";
            }
            if (cbProcessado.Checked)
                vStatus += virg + "'P'";
            bsFolhaPgto.DataSource = CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Buscar(id_folha.Text,
                                                                                                        CD_Empresa.Text,
                                                                                                        mes_folha.Text,
                                                                                                        ano_folha.Text,
                                                                                                        CD_Clifor.Text,
                                                                                                        vStatus,
                                                                                                        null);
            bsFolhaPgto_PositionChanged(this, new EventArgs());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
               , new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
               "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
               "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
               "(exists(select 1 from tb_div_usuario_x_grupos y " +
               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "';" +
                                    "isnull(cargo.st_vendedor, 'N')|=|'S'"
                , new Componentes.EditDefault[] { CD_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, "isnull(a.st_vendedor, 'N')|=|'S'");
        }

        private void bsFolhaPgto_PositionChanged(object sender, EventArgs e)
        {
            if (bsFolhaPgto.Current != null)
            {
                (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc =
                    CamadaNegocio.Financeiro.Folha_Pagamento.TCN_Folha_X_Funcionarios.Buscar(
                    (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Id_folha.Value.ToString(),
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    null);
                bsFolhaPgto.ResetCurrentItem();
                tot_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Sum(v => v.Vl_pagamento).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void TFConsultaFolhaPgto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Consulta);
            Utils.ShapeGrid.RestoreShape(this, gFolha);
            Utils.ShapeGrid.RestoreShape(this, gPagto);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.ProcessarFolha();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFConsultaFolhaPgto_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode.Equals(Keys.F9))
                this.ProcessarFolha();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EstornarProcesso();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar layout.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gFolha_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    gFolha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gFolha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.EstornarProcesso();
        }

        private void gFolha_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFolha.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFolhaPgto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento());
            CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFolha.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFolha.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento(lP.Find(gFolha.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFolha.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento(lP.Find(gFolha.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFolha.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFolhaPgto.List as CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento).Sort(lComparer);
            bsFolhaPgto.ResetBindings(false);
            gFolha.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
        }

        private void gPagto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPagto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFolhaFunc.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios());
            CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPagto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPagto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios(lP.Find(gPagto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPagto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios(lP.Find(gPagto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPagto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFolhaFunc.List as CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios).Sort(lComparer);
            bsFolhaFunc.ResetBindings(false);
            gPagto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
        }

        private void TFConsultaFolhaPgto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Consulta);
            Utils.ShapeGrid.SaveShape(this, gFolha);
            Utils.ShapeGrid.SaveShape(this, gPagto);
        }

        private void cbAberto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
