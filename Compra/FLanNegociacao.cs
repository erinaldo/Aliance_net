using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compra
{
    public partial class TFLanNegociacao : Form
    {
        public TFLanNegociacao()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFNegociacao fNeg = new TFNegociacao())
            {
                if (fNeg.ShowDialog() == DialogResult.OK)
                {
                    if (fNeg.rNeg != null)
                    {
                        try
                        {
                            string retorno = CamadaNegocio.Compra.Lancamento.TCN_Negociacao.GravarNegociacao(fNeg.rNeg, null);
                            MessageBox.Show("Negociação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_negociacao.Text = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_NEGOCIACAO");
                            CB_Abertas.Checked = true;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void afterAltera()
        {
            if (bsNegociacao.Current != null)
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    using (TFNegociacao fNeg = new TFNegociacao())
                    {
                        fNeg.St_alterar = true;
                        fNeg.rNeg = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao);
                        if (fNeg.ShowDialog() == DialogResult.OK)
                        {
                            if (fNeg.rNeg != null)
                            {
                                bsNegociacao.ResetCurrentItem();
                                try
                                {
                                    CamadaNegocio.Compra.Lancamento.TCN_Negociacao.GravarNegociacao(fNeg.rNeg, null);
                                    MessageBox.Show("Negociação alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.LimparFiltros();
                                    id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                            this.afterBusca();
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido alterar somente negociação com status <ABERTA> ou <FECHADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_Negociacao.DeletarNegociacao(bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao, null);
                        MessageBox.Show("Negociação cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                        cbCancelado.Checked = true;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Permitido cancelar somente negociação com status <ABERTA> ou <FECHADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterBusca()
        {
            string st = string.Empty;
            string virg = string.Empty;
            if (CB_Abertas.Checked)
            {
                st += virg.Trim() + "'A'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                st += virg.Trim() + "'C'";
                virg = ",";
            }
            if (cbProcessado.Checked)
            {
                st += virg.Trim() + "'F'";
                virg = ",";
            }
            if (cbFechada.Checked)
            {
                st += virg.Trim() + "'E'";
                virg = ",";
            }
            if (cbAprovada.Checked)
            {
                st += virg.Trim() + "'P'";
                virg = ",";
            }
            bsNegociacao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Negociacao.Buscar(id_negociacao.Text,
                                                                                            cd_produto.Text,
                                                                                            cd_grupo.Text,
                                                                                            ds_observacao.Text,
                                                                                            cd_fornecedor.Text,
                                                                                            cd_condpgto.Text,
                                                                                            (rbNegociacao.Checked ? "A" : rbDtProcessamento.Checked ? "P" : string.Empty),
                                                                                            DT_Inicial.Text,
                                                                                            DT_Final.Text,
                                                                                            st,
                                                                                            0,
                                                                                            string.Empty,
                                                                                            null);
            bsNegociacao_PositionChanged(this, new EventArgs());
        }

        private void InserirItemNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    using (TFNegociacaoFornec fNegFornec = new TFNegociacaoFornec())
                    {
                        fNegFornec.Cd_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto.Trim();
                        fNegFornec.Ds_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_produto.Trim();
                        fNegFornec.Sigla_unidade = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Sigla_unidade.Trim();
                        fNegFornec.Cd_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_grupo.Trim();
                        fNegFornec.Ds_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_grupo.Trim();
                        fNegFornec.St_alterar = false;
                        if (fNegFornec.ShowDialog() == DialogResult.OK)
                        {
                            if (fNegFornec.rNegItem != null)
                            {
                                fNegFornec.rNegItem.Id_negociacao = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao;
                                try
                                {
                                    CamadaNegocio.Compra.Lancamento.TCN_NegociacaoItem.GravarNegociacaoItem(fNegFornec.rNegItem, null);
                                    MessageBox.Show("Negociação com o fornecedor gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido incluir negociação de fornecedor somente de negociação com status <ABERTA> ou <FECHADA>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AlterarItemNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    using (TFNegociacaoFornec fNegFornec = new TFNegociacaoFornec())
                    {
                        fNegFornec.Cd_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto.Trim();
                        fNegFornec.Ds_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_produto.Trim();
                        fNegFornec.Sigla_unidade = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Sigla_unidade.Trim();
                        fNegFornec.Cd_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_grupo.Trim();
                        fNegFornec.Ds_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_grupo.Trim();
                        fNegFornec.St_alterar = true;
                        CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem rCopia = (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Copia();
                        fNegFornec.rNegItem = (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem);
                        if (fNegFornec.ShowDialog() == DialogResult.OK)
                        {
                            if (fNegFornec.rNegItem != null)
                            {
                                fNegFornec.rNegItem.Id_negociacao = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao;
                                try
                                {
                                    CamadaNegocio.Compra.Lancamento.TCN_NegociacaoItem.GravarNegociacaoItem(fNegFornec.rNegItem, null);
                                    MessageBox.Show("Negociação com o fornecedor alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            bsItens.RemoveCurrent();
                            bsItens.Add(rCopia);
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido alterar negociação de fornecedor somente de negociação com status <ABERTA> ou <FECHADA>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ExcluirItemNegociacao()
        {
            if (bsNegociacao.Current != null)
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    if (MessageBox.Show("Confirma a exclusão da negociação do fornecedor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_NegociacaoItem.DeletarNegociacaoItem(
                                    bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem, null);
                            MessageBox.Show("Negociação excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido excluir negociação de fornecedor somente de negociação com status <ABERTA> ou <FECHADA>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("A"))
                {
                    if (MessageBox.Show("Confirma fechamento da negociação?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_Negociacao.FecharNegociacao(bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao, null);
                            MessageBox.Show("Negociação fechada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido fechar somente negociação com status <ABERTA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AprovarNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("F"))
                {
                    using (TFListaFornecedor fLista = new TFListaFornecedor())
                    {
                        fLista.lItens = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).lItens;
                        if (fLista.ShowDialog() == DialogResult.OK)
                        {
                            //Pedir autenticacao de um usuario com acesso a fazer conferencia
                            using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                            {
                                fUser.Ds_regraespecial = "PERMITIR APROVAR NEGOCIACAO";
                                if (fUser.ShowDialog() == DialogResult.OK)
                                {
                                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Loginaprovareprova = fUser.Login;
                                    try
                                    {
                                        CamadaNegocio.Compra.Lancamento.TCN_Negociacao.ProcessarNegociacao(bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao, null);
                                        MessageBox.Show("Negociação Processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.LimparFiltros();
                                        id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                                        this.afterBusca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido aprovar somente negociação com status <FECHADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EncerrarNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido encerrar uma negociação cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).St_registro.Trim().ToUpper().Equals("P"))
                {
                    if (MessageBox.Show("Deseja realmente encerrar negociação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_Negociacao.EncerrarNegociacao(bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao, null);
                            MessageBox.Show("Negociação encerrada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_negociacao.Text = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    if (MessageBox.Show("Negociação com status diferente de <APROVADA>.\r\n" +
                                       "Deseja cancelar a negociação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        this.afterExclui();
            }
        }

        private void LancarNegFornec()
        {
            using (TFNegFornec fNeg = new TFNegFornec())
            {
                if (fNeg.ShowDialog() == DialogResult.OK)
                {
                    if (fNeg.lNegociacao.Count > 0)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_Negociacao.LancarNegFornec(fNeg.lNegociacao, null);
                            MessageBox.Show("Negociações gravadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe registro de negociação para gravar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LimparFiltros()
        {
            id_negociacao.Clear();
            cd_grupo.Clear();
            cd_produto.Clear();
            cd_condpgto.Clear();
            ds_observacao.Clear();
            cd_fornecedor.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            cbCancelado.Checked = false;
            CB_Abertas.Checked = false;
            cbProcessado.Checked = false;
        }

        private void TFLanNegociacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Utils.ShapeGrid.RestoreShape(this, gNegociacao);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            pFiltroValor.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pFiltroData.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            string vParam = "a.tp_grupo|=|'A'";//Somente grupo analitico
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParam);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "a.tp_grupo|=|'A'"; //Somente grupo analitico
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vCond = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(string.Empty, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, vParam);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(),
                                        string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bsNegociacao_PositionChanged(object sender, EventArgs e)
        {
            if(bsNegociacao.Current != null)
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao != null)
                {
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).lItens =
                        CamadaNegocio.Compra.Lancamento.TCN_NegociacaoItem.Buscar((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Id_negociacao.Value.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  null);
                    bsNegociacao.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItemNegociacao();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItemNegociacao();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItemNegociacao();
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
            this.ProcessarNegociacao();
        }

        private void TFLanNegociacao_KeyDown(object sender, KeyEventArgs e)
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
                this.ProcessarNegociacao();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EncerrarNegociacao();
            else if (e.KeyCode.Equals(Keys.F11))
                this.AprovarNegociacao();
            else if (e.KeyCode.Equals(Keys.F12))
                this.LancarNegFornec();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItemNegociacao();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItemNegociacao();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItemNegociacao();
        }

        private void gItens_DoubleClick(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                using (TFNegociacaoFornec fNegFornec = new TFNegociacaoFornec())
                {
                    fNegFornec.Cd_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto.Trim();
                    fNegFornec.Ds_produto = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_produto.Trim();
                    fNegFornec.Sigla_unidade = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Sigla_unidade.Trim();
                    fNegFornec.Cd_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_grupo.Trim();
                    fNegFornec.Ds_grupo = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_grupo.Trim();
                    fNegFornec.St_detalhe = true;
                    fNegFornec.rNegItem = (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem);
                    fNegFornec.ShowDialog();
                }
            }
        }

        private void bb_encerrar_Click(object sender, EventArgs e)
        {
            this.EncerrarNegociacao();
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                    {
                        DataGridViewRow linha = gItens.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADA"))
                    {
                        DataGridViewRow linha = gItens.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gItens.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void gNegociacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADA"))
                    {
                        DataGridViewRow linha = gNegociacao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    {
                        DataGridViewRow linha = gNegociacao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    {
                        DataGridViewRow linha = gNegociacao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADA"))
                    {
                        DataGridViewRow linha = gNegociacao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else
                    {
                        DataGridViewRow linha = gNegociacao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
                if (((bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_negociacao != null) &&
                    ((bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_item != null))
                {
                    //Buscar prazo entrega
                    (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).lPrazoEntrega =
                        CamadaNegocio.Compra.Lancamento.TCN_PrazoEntrega.Buscar(string.Empty,
                                                                                (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_negociacao.Value.ToString(),
                                                                                (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Id_item.Value.ToString(),
                                                                                0,
                                                                                string.Empty,
                                                                                null);
                    bsItens.ResetCurrentItem();
                }
        }

        private void bb_aprovar_Click(object sender, EventArgs e)
        {
            this.AprovarNegociacao();
        }

        private void bb_negfornec_Click(object sender, EventArgs e)
        {
            this.LancarNegFornec();
        }

        private void TFLanNegociacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
            Utils.ShapeGrid.SaveShape(this, gNegociacao);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
