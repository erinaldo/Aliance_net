using FormRelPadrao;
using Proc_Commoditties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCad_CondFiscalICMS : Form
    {
        private bool Altera_Relatorio = false;

        public TFCad_CondFiscalICMS()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFCondFiscalICMS fcond = new TFCondFiscalICMS())
            {
                if(fcond.ShowDialog() == DialogResult.OK)
                    if((fcond.rCond != null) &&
                        (fcond.lMov != null) &&
                        (fcond.lUfOrigem != null) &&
                        (fcond.lUfDestino != null))
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fcond.rCond,
                                                                              fcond.lMov,
                                                                              fcond.lUfOrigem,
                                                                              fcond.lUfDestino,
                                                                              null);
                            MessageBox.Show("Condição fiscal gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsCondFiscalICMS.Current != null)
                using (TFCondFiscalICMS fCond = new TFCondFiscalICMS())
                {
                    fCond.rCond = bsCondFiscalICMS.Current as CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS;
                    if (fCond.ShowDialog() == DialogResult.OK)
                        if ((fCond.rCond != null) &&
                            (fCond.lMov != null) &&
                            (fCond.lUfOrigem != null) &&
                            (fCond.lUfDestino != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCond.rCond,
                                                                                  fCond.lMov,
                                                                                  fCond.lUfOrigem,
                                                                                  fCond.lUfDestino,
                                                                                  null);
                                MessageBox.Show("Condição fiscal alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsCondFiscalICMS.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Excluir(bsCondFiscalICMS.Current as CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsCondFiscalICMS.DataSource = CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Busca(string.Empty,
                                                                                           cd_condfiscal_produto.Text,
                                                                                           cd_condfiscal_clifor.Text,
                                                                                           cd_uf_origem.Text,
                                                                                           cd_uf_destino.Text,
                                                                                           rbEntrada.Checked ? "E" : "S",
                                                                                           cd_st.Text,
                                                                                           string.Empty,
                                                                                           cd_movimentacao.Text,
                                                                                           cd_empresa.Text,
                                                                                           cd_cfop.Text,
                                                                                           cbSomarIPIBaseICMS.Checked,
                                                                                           cbSomarIPIBaseST.Checked,
                                                                                           null);
        }

        private void TFCad_CondFiscalICMS_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_uf_origem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|150;" +
                              "a.uf|Sigla|60;" +
                              "a.cd_uf|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_uf_origem },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_uf_origem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_uf_origem.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_uf_origem },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void bb_uf_destino_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|150;" +
                              "a.uf|Sigla|60;" +
                              "a.cd_uf|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_uf_destino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_uf_destino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_uf_destino.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_uf_destino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_condfiscal_clifor_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_condfiscal|Condição Fiscal|200;" +
                              "cd_condfiscal_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condfiscal_clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void cd_condfiscal_clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_condfiscal_clifor|=|'" + cd_condfiscal_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condfiscal_clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void bb_condfiscal_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_condfiscal_produto|Condição Fiscal|200;" +
                              "cd_condfiscal_produto|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condfiscal_produto },
                new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
        }

        private void cd_condfiscal_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_condfiscal_produto|=|'" + cd_condfiscal_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condfiscal_produto },
                new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFCad_CondFiscalICMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                BB_Imprimir_Click(this, new EventArgs());
            else if(e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }

        }

        private void gCondFiscalICMS_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCondFiscalICMS.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCondFiscalICMS.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS());
            CamadaDados.Fiscal.TList_CadCondFiscalICMS lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCondFiscalICMS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCondFiscalICMS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_CadCondFiscalICMS(lP.Find(gCondFiscalICMS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCondFiscalICMS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_CadCondFiscalICMS(lP.Find(gCondFiscalICMS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCondFiscalICMS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCondFiscalICMS.List as CamadaDados.Fiscal.TList_CadCondFiscalICMS).Sort(lComparer);
            bsCondFiscalICMS.ResetBindings(false);
            gCondFiscalICMS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_st_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_situacao|Situação Tributaria|150;" +
                              "a.cd_st|CST|60";
            string vParam = "b.st_icms|=|0";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_st },
                new CamadaDados.Fiscal.TCD_CadSitTribut(), vParam);
        }

        private void cd_st_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_st|=|'" + cd_st.Text.Trim() + "';b.st_icms|=|0";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_st },
                new CamadaDados.Fiscal.TCD_CadSitTribut());
        }

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cfop|CFOP|250;a.cd_cfop|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop },
                new CamadaDados.Fiscal.TCD_CadCFOP(), string.Empty);
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cfop },
                new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
            Relatorio.Nome_Relatorio = Name;
            Relatorio.NM_Classe = Name;
            Relatorio.Ident = Name;
            Relatorio.Modulo = Tag.ToString().Substring(0, 3);
            Relatorio.DTS_Relatorio = bsCondFiscalICMS;
            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pMensagem = "CONFIGURAÇÃO FISCAL ICMS";
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio("ICMS",
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "CONFIGURAÇÃO FISCAL ICMS",
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
}
