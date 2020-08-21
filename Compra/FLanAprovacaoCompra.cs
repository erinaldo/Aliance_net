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
    public partial class TFLanAprovacaoCompra : Form
    {
        public TFLanAprovacaoCompra()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsRequisicao.Current != null)
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("AA"))
                {
                    using (TFAprovarCompra fAprovar = new TFAprovarCompra())
                    {
                        fAprovar.rRequisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao);
                        if (fAprovar.ShowDialog() == DialogResult.OK)
                        {
                            if (fAprovar.rRequisicao != null)
                            {
                                try
                                {
                                    CamadaNegocio.Compra.Lancamento.TCN_Requisicao.ProcessarRequisicao(fAprovar.rRequisicao, null);
                                    MessageBox.Show("Requisição processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        this.afterBusca();
                    }
                }
                else
                    MessageBox.Show("Permitido aprovar somente requisição com status <AGUARDANDO APROVACAO>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("AA"))
                {
                    MessageBox.Show("Requisição ainda não foi processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o estorno do processamento da requisição?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.EstornarProcessamentoRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                        MessageBox.Show("Processamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (st_aa.Checked)
            {
                st += virg + "'AA'";
                virg = ",";
            }
            if (st_ap.Checked)
            {
                st += virg + "'AP'";
                virg = ",";
            }
            if (st_rp.Checked)
            {
                st += virg + "'RE'";
                virg = ",";
            }
            if (st.Trim().Equals(string.Empty))
                st = "'AA'";
            bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Requisicao.Buscar(id_requisicao.Text,
                                                                                            cd_empresa.Text,
                                                                                            cd_produto.Text,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            DT_Inic.Text,
                                                                                            DT_Final.Text,
                                                                                            st,
                                                                                            false,
                                                                                            false,
                                                                                            false,
                                                                                            "'E'",
                                                                                            false,
                                                                                            null);
            bsRequisicao_PositionChanged(this, new EventArgs());
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanAprovacaoCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRequisicao);
            Utils.ShapeGrid.RestoreShape(this, gCotacao);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_3;

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if(bsRequisicao.Current != null)
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao != null)
                {
                    //Buscar negociacoes da requisicao
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg =
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao_X_Negociacao.Buscar(
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                        string.Empty,
                        0, string.Empty, null);
                    bsNegociacao_PositionChanged(this, new EventArgs());
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
                    //Setar a page correta
                    if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Count > 0)
                        tcDetalhes.SelectedTab = tpNegociacoes;
                    else if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count > 0)
                        tcDetalhes.SelectedTab = tpCotacoes;
                    bsRequisicao.ResetCurrentItem();
                }
        }

        private void bsNegociacao_PositionChanged(object sender, EventArgs e)
        {
            if(bsNegociacao.Current != null)
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_negociacao != null)
                {
                    //Buscar entrega da negociacao para a empresa da requisicao
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).lPrazoEntrega =
                        CamadaNegocio.Compra.Lancamento.TCN_PrazoEntrega.Buscar(
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                        (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_negociacao.Value.ToString(),
                        (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_item.Value.ToString(),
                        0, string.Empty, null);
                    bsNegociacao.ResetCurrentItem();
                }
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanAprovacaoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gRequisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLanAprovacaoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRequisicao);
            Utils.ShapeGrid.SaveShape(this, gCotacao);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
