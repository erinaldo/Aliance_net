using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;

namespace Compra
{
    public partial class TFLanCotacao : Form
    {
        public TFLanCotacao()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            //if (bsRequisicao.Current != null)
            //{
            //    using (TFCotacao fCot = new TFCotacao())
            //    {
            //        fCot.Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto;
            //        fCot.Ds_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Ds_produto;
            //        fCot.Qtd_requisitada = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade;
            //        if (fCot.ShowDialog() == DialogResult.OK)
            //        {
            //            if (fCot.rCotacao != null)
            //            {
            //                try
            //                {
            //                    fCot.rCotacao.Id_requisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao;
            //                    CamadaNegocio.Compra.Lancamento.TCN_Cotacao.GravarCotacao(fCot.rCotacao, null);
            //                    MessageBox.Show("Cotação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    this.afterBusca();
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void afterAltera()
        {
            //if(bsRequisicao.Current != null)
            //    if (bsCotacao.Current != null)
            //        using (TFCotacao fCot = new TFCotacao())
            //        {
            //            fCot.Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto;
            //            fCot.Ds_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Ds_produto;
            //            fCot.Qtd_requisitada = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade;
            //            fCot.rCotacao = bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao;
            //            fCot.St_alterar = true;
            //            if (fCot.ShowDialog() == DialogResult.OK)
            //            {
            //                if (fCot.rCotacao != null)
            //                {
            //                    try
            //                    {
            //                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.GravarCotacao(fCot.rCotacao, null);
            //                        MessageBox.Show("Cotação alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        this.afterBusca();
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    }
            //                }
            //            }
            //        }
        }

        private void afterExclui()
        {
            if (bsCotacao.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão da cotação selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.DeletarCotacao(bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao, null);
                        MessageBox.Show("Cotação excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void afterBusca()
        {
            string st = string.Empty;
            string virg = string.Empty;
            if (st_ac.Checked)
            {
                st += virg.Trim() + "'AC'";
                virg = ",";
            }
            if (st_rn.Checked)
            {
                st += virg.Trim() + "'RN'";
                virg = ",";
            }
            if (st.Trim().Equals(string.Empty))
                st = "'AC'";
            bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Cotacao.BuscarRequisicao(cd_empresa.Text,
                                                                                                   cd_produto.Text,
                                                                                                   cd_fornecedor.Text,
                                                                                                   DT_Inic.Text,
                                                                                                   DT_Final.Text,
                                                                                                   st,
                                                                                                   0,
                                                                                                   string.Empty,
                                                                                                   null);
            bsRequisicao_PositionChanged(this, new EventArgs());
        }

        private void FecharCotacao()
        {
            if (bsRequisicao.Current != null)
            {
                if (MessageBox.Show("Confirma fechamento das cotações?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.FecharCotacoesRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                        MessageBox.Show("Cotações fechadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void TFLanCotacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCotacao);
            Utils.ShapeGrid.RestoreShape(this, gRequisicao);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_3;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tlpRequisicao.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(string.Empty, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, vParam);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao != null)
                {
                    //Buscar cotacoes da requisicao
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes =
                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                           string.Empty,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                                                           0,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
                    bsRequisicao.ResetCurrentItem();
                }
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("RN"))
                    tlpRequisicao.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 227);
                else
                    tlpRequisicao.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_EnviarLote_Click(object sender, EventArgs e)
        {
            this.FecharCotacao();
        }

        private void TFLanCotacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.FecharCotacao();
        }

        private void gRequisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("RENEGOCIAR"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Olive;
                    }
                    else
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLanCotacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCotacao);
            Utils.ShapeGrid.SaveShape(this, gRequisicao);
        }
    }
}

