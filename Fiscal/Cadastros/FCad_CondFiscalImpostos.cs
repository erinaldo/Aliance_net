using Proc_Commoditties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCad_CondFiscalImpostos : Form
    {
        public TFCad_CondFiscalImpostos()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFCondFiscalImposto fCond = new TFCondFiscalImposto())
            {
                if(fCond.ShowDialog() == DialogResult.OK)
                    if((fCond.rCond != null) &&
                        (fCond.lMov != null) &&
                        (fCond.lCondClifor != null) &&
                        (fCond.lCondProd != null))
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCond.rCond,
                                                                                             fCond.lMov,
                                                                                             fCond.lCondClifor,
                                                                                             fCond.lCondProd,
                                                                                             fCond.pSt_fisica,
                                                                                             fCond.pSt_juridica,
                                                                                             fCond.pSt_estrangeiro,
                                                                                             null);
                            MessageBox.Show("Condição fiscal gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsCondFiscalImposto.Current != null)
                using (TFCondFiscalImposto fCond = new TFCondFiscalImposto())
                {
                    fCond.rCond = bsCondFiscalImposto.Current as CamadaDados.Fiscal.TRegistro_CondicaoFiscalImposto;
                    if (fCond.ShowDialog() == DialogResult.OK)
                        if ((fCond.rCond != null) &&
                            (fCond.lMov != null) &&
                            (fCond.lCondClifor != null) &&
                            (fCond.lCondProd != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCond.rCond,
                                                                                                 fCond.lMov,
                                                                                                 fCond.lCondClifor,
                                                                                                 fCond.lCondProd,
                                                                                                 fCond.pSt_fisica,
                                                                                                 fCond.pSt_juridica,
                                                                                                 fCond.pSt_estrangeiro,
                                                                                                 null);
                                MessageBox.Show("Condição fiscal alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if (bsCondFiscalImposto.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.deletarFisImposto(bsCondFiscalImposto.Current as CamadaDados.Fiscal.TRegistro_CondicaoFiscalImposto, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string tp_mov = string.Empty;
            string virg = string.Empty;
            if (cbEntrada.Checked)
            {
                tp_mov = "'E'";
                virg = ",";
            }
            if (cbSaida.Checked)
            {
                tp_mov += virg + "'S'";
                virg = ",";
            }
            string tp_pessoa = string.Empty;
            virg = string.Empty;
            if (cbFisica.Checked)
            {
                tp_pessoa = "'F'";
                virg = ",";
            }
            if (cbJuridica.Checked)
            {
                tp_pessoa += virg + "'J'";
                virg = ",";
            }
            if (st_estrangeiro.Checked)
                tp_pessoa += virg + "'E'";
            bsCondFiscalImposto.DataSource = CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.Buscar(cd_municipiogeradoriss.Text,
                                                                                                   cd_imposto.Text,
                                                                                                   string.Empty,
                                                                                                   tp_mov,
                                                                                                   tp_pessoa,
                                                                                                   cd_condfiscal_produto.Text,
                                                                                                   cd_movimentacao.Text,
                                                                                                   cd_empresa.Text,
                                                                                                   cd_condfiscal_clifor.Text,
                                                                                                   null);
        }

        private void TFCad_CondFiscalImpostos_Load(object sender, EventArgs e)
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

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.sigla|Sigla|60;" +
                              "a.cd_imposto|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto },
                new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|'" + cd_imposto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto },
                new CamadaDados.Fiscal.TCD_CadImposto());
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

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFCad_CondFiscalImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gCondFiscalImp_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCondFiscalImp.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCondFiscalImposto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fiscal.TRegistro_CondicaoFiscalImposto());
            CamadaDados.Fiscal.TList_CondicaoFiscalImposto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCondFiscalImp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCondFiscalImp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fiscal.TList_CondicaoFiscalImposto(lP.Find(gCondFiscalImp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCondFiscalImp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fiscal.TList_CondicaoFiscalImposto(lP.Find(gCondFiscalImp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCondFiscalImp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCondFiscalImposto.List as CamadaDados.Fiscal.TList_CondicaoFiscalImposto).Sort(lComparer);
            bsCondFiscalImposto.ResetBindings(false);
            gCondFiscalImp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;

        }

        private void bb_municipiogeradoriss_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Municipio|200;" +
                              "a.cd_cidade|Cd. Municipio|80;" +
                              "a.distrito|Distrito|100;" +
                              "b.uf|UF|20;" +
                              "b.ds_uf|Estado|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_municipiogeradoriss },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        
        }

        private void cd_municipiogeradoriss_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipiogeradoriss.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_municipiogeradoriss },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }
    }
}
