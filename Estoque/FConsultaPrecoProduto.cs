using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Estoque
{
    public partial class TFConsultaPrecoProduto : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaPrecoProduto()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFPrecoProduto fPreco = new TFPrecoProduto())
            {
                fPreco.ShowDialog();
            }
        }

        private void afterExclui()
        {
            if(bsPrecoItem.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Deleta_LanPrecoItem(bsPrecoItem.Current as CamadaDados.Estoque.TRegistro_LanPrecoItem, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            if (cbAtivo.Checked && !cbExpirado.Checked)
                status = "A";
            else if (cbExpirado.Checked && !cbAtivo.Checked)
                status = "E";
            bsPrecoItem.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca(cd_tabpreco.Text,
                                                                                            CD_Produto.Text,
                                                                                            string.IsNullOrWhiteSpace(CD_Produto.Text) ? ds_produto.Text : string.Empty,
                                                                                            cd_empresa.Text,
                                                                                            string.Empty,
                                                                                            cd_grupo.Text,
                                                                                            tp_produto.Text,
                                                                                            cd_marca.Text,
                                                                                            status,
                                                                                            null,
                                                                                            vDtIniVigencia: dtIniVigencia.Text,
                                                                                            vDtFinVigencia: dtFinVigencia.Text);
        }

        private void afterPrint()
        {
            if (bsPrecoItem.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsPrecoItem;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe registros para gerar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabpreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabpreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabpreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabpreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, ds_produto }, string.Empty);
            ds_produto.Enabled = string.IsNullOrWhiteSpace(CD_Produto.Text);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { CD_Produto, ds_produto},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            ds_produto.Enabled = string.IsNullOrWhiteSpace(CD_Produto.Text);
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|TP. Produto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void TFConsultaPrecoProduto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPrecoItem);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFConsultaPrecoProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFConsultaPrecoProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPrecoItem);
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca Produto|200;" +
                              "a.cd_marca|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), string.Empty);
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_marca|=|" + cd_marca.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void gPrecoItem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPrecoItem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPrecoItem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_LanPrecoItem());
            CamadaDados.Estoque.TList_LanPrecoItem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPrecoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPrecoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_LanPrecoItem(lP.Find(gPrecoItem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPrecoItem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_LanPrecoItem(lP.Find(gPrecoItem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPrecoItem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPrecoItem.List as CamadaDados.Estoque.TList_LanPrecoItem).Sort(lComparer);
            bsPrecoItem.ResetBindings(false);
            gPrecoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gPrecoItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADO"))
                        gPrecoItem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gPrecoItem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}
