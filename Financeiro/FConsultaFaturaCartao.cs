using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using System.Data;

namespace Financeiro
{
    public partial class TFConsultaFaturaCartao : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaFaturaCartao()
        {
            InitializeComponent();
        }

        private void Totalizar()
        {
            if (bsFatura.Count > 0)
            {
                tot_nominal.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_nominal);
                tot_juro.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_juro);
                tot_fatura.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_fatura);
                tot_quitado.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_quitado);
                tot_sdquitar.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_Saldoquitar);
                tot_taxa.Value = (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_taxa);
            }
        }

        private void afterNovo()
        {
            using (TFLanFaturaCartao fFatura = new TFLanFaturaCartao())
            {
                if(fFatura.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Gravar(fFatura.rFatura, null);
                        MessageBox.Show("Fatura gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro gravar fatura: " + ex.Message.Trim()); }
            }
        }

        private void afterBusca()
        {
            bsFatura.DataSource = CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Buscar(id_fatura.Text,
                                                                                          CD_Empresa.Text,
                                                                                          nr_cartao.Text,
                                                                                          id_bandeira.Text,
                                                                                          id_maquina.Text,
                                                                                          string.Empty,
                                                                                          cbCredito.Checked ? "C" : cbDebito.Checked ? "D" : string.Empty,
                                                                                          cbPagar.Checked ? "P" : cbReceber.Checked ? "R" : string.Empty,
                                                                                          nr_autorizacao.Text,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          rbFatura.Checked ? "F" : string.Empty,
                                                                                          DT_Inicial.Text,
                                                                                          DT_Final.Text,
                                                                                          vl_ini.Value,
                                                                                          vl_fin.Value,
                                                                                          true,
                                                                                          cbAberto.Checked ? "A" : cbQuitado.Checked ? "Q" : string.Empty,
                                                                                          "a.dt_fatura",
                                                                                          null);
            Totalizar();
            bsFatura_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsFatura.Current != null)
            {
                if (MessageBox.Show("Confirma cancelamento do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                     DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.CancelarFatura(bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao, null);
                        MessageBox.Show("Registro fatura excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar registro para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterPrint()
        {
            if (bsFatura.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsFatura;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO FATURA CARTÃO CREDITO/DEBITO";

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
                                           "RELATORIO FATURA CARTÃO CREDITO/DEBITO",
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
                                               "RELATORIO FATURA CARTÃO CREDITO/DEBITO",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void QuitarFatura()
        {
            using (TFQuitarFaturaCartao fQuitar = new TFQuitarFaturaCartao())
            {
                if(fQuitar.ShowDialog() == DialogResult.OK)
                    if (fQuitar.lFat != null)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.QuitarFatura(fQuitar.lFat, 
                                                                                          fQuitar.Dt_quitar, 
                                                                                          fQuitar.Cd_contager,
                                                                                          fQuitar.Cd_empresa,
                                                                                          fQuitar.Tp_movimento,
                                                                                          null);
                            MessageBox.Show("Quitação fatura realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void EstornarQuitacao()
        {
            if (bsQuitacao.Current != null)
            {
                try
                {
                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.EstornarQuitacaoFatura(bsQuitacao.Current as CamadaDados.Financeiro.Cartao.TRegistro_Quitarfatura, null);
                    MessageBox.Show("Quitação fatura estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar fatura para estornar quitação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void TransfCartao()
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                                          "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
          DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), string.Empty);

            if (linha != null)
                try
                {
                    CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura =
                    new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                   new Utils.TpBusca[]
                   {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_contager",
                            vOperador = "is",
                            vVL_Busca = "null"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "exists(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                        "on y.CD_ContaGer = x.CD_ContaGer " +
                                        "and y.CD_LanctoCaixa = x.CD_LanctoCaixa " +
                                        "inner join TB_PDV_Caixa z " +
                                        "on z.id_caixa = y.id_caixa " +
                                        "and isnull(z.st_registro, 'A') = 'P' " +
                                        "where x.ID_Fatura = a.ID_Fatura )"
                        }
                   }, 0, string.Empty, string.Empty);
                    if (lFatura.Count > 0)
                    {
                        CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.TransferirContaCartao(lFatura, linha["cd_empresa"].ToString(), null);
                        MessageBox.Show("Transferência efetuada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Não existem faturas com caixa operacional processado\r\n " +
                                        "e sem possuir transferencias para conta cartão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                                          "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFConsultaFaturaCartao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCaixa);
            Utils.ShapeGrid.RestoreShape(this, gFatura);
            Utils.ShapeGrid.RestoreShape(this, gQuitacao);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_bandeira_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_bandeira|Bandeira|200;" +
                              "a.id_bandeira|Id. Bandeira|80;" +
                              "a.tp_cartao|TP. Cartão|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bandeira },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao(), string.Empty);
        }

        private void id_bandeira_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bandeira|=|" + id_bandeira.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_bandeira },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao());
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_cartao|Cartão|200;" +
                            "a.nr_cartao|Nº Cartão|100";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cbAberto_Click(object sender, EventArgs e)
        {
            if (cbAberto.Checked)
                cbQuitado.Checked = false;
        }

        private void cbQuitado_Click(object sender, EventArgs e)
        {
            if (cbQuitado.Checked)
                cbAberto.Checked = false;
        }

        private void bsFatura_PositionChanged(object sender, EventArgs e)
        {
            if (bsFatura.Current != null)
            {
                //Buscar caixa origem fatura
                (bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).lCaixa =
                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.BuscarCaixa((bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_fatura.Value.ToString(), null);
                //Buscar quitacao fatura
                (bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).lQuitacao =
                    CamadaNegocio.Financeiro.Cartao.TCN_QuitarFatura.Buscar((bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_fatura.Value.ToString(), null);
                bsFatura.ResetCurrentItem();
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            QuitarFatura();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFConsultaFaturaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                QuitarFatura();
            else if (e.KeyCode.Equals(Keys.F4))
                BB_Descontar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                EstornarQuitacao();
            else if (e.KeyCode.Equals(Keys.F10))
                TransfCartao();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gFatura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("QUITADO"))
                    {
                        DataGridViewRow linha = gFatura.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gFatura.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            EstornarQuitacao();
        }

        private void gFatura_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFatura.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFatura.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao());
            CamadaDados.Financeiro.Cartao.TList_FaturaCartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao(lP.Find(gFatura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFatura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao(lP.Find(gFatura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFatura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sort(lComparer);
            bsFatura.ResetBindings(false);
            gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
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

        private void TFConsultaFaturaCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCaixa);
            Utils.ShapeGrid.SaveShape(this, gFatura);
            Utils.ShapeGrid.SaveShape(this, gQuitacao);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Descontar_Click(object sender, EventArgs e)
        {
            using (FDescontarCartao cartao = new FDescontarCartao())
                cartao.ShowDialog();
        }

        private void bbMaquina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Maquina|Maquina|200;" +
                              "a.ID_Maquina|Código|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_maquina },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadMaquinaCartao(), string.Empty);
        }

        private void id_maquina_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_maquina|=|" + id_maquina.Text, new Componentes.EditDefault[] { id_maquina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadMaquinaCartao());
        }
    }
}
