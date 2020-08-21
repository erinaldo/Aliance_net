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
    public partial class TFNegociacao : Form
    {
        public bool St_alterar
        { get; set; }

        public CamadaDados.Compra.Lancamento.TRegistro_Negociacao rNeg
        {
            get
            {
                if (bsNegociacao.Current != null)
                    return bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao;
                else
                    return null;
            }
            set
            {
                bsNegociacao.Add(value);
            }
        }

        public TFNegociacao()
        {
            InitializeComponent();
            this.St_alterar = false;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirFornecedor()
        {
            if (bsNegociacao.Current != null)
            {
                if (cd_grupo.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar grupo de produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFNegociacaoFornec fNegFornec = new TFNegociacaoFornec())
                {
                    fNegFornec.Cd_produto = cd_produto.Text;
                    fNegFornec.Ds_produto = ds_produto.Text;
                    fNegFornec.Sigla_unidade = sigla_unidade.Text;
                    fNegFornec.Cd_grupo = cd_grupo.Text;
                    fNegFornec.Ds_grupo = ds_grupo.Text;
                    fNegFornec.St_alterar = false;
                    if (fNegFornec.ShowDialog() == DialogResult.OK)
                    {
                        if (fNegFornec.rNegItem != null)
                        {
                            (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).lItens.Add(fNegFornec.rNegItem);
                            bsNegociacao.ResetCurrentItem();
                        }
                    }
                }
            }
        }

        private void AlterarFornecedor()
        {
            if(bsNegociacao.Current != null)
                if (bsItens.Current != null)
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
                                bsItens.RemoveCurrent();
                                bsItens.Add(fNegFornec.rNegItem);
                            }
                        }
                        else
                        {
                            bsItens.RemoveCurrent();
                            bsItens.Add(rCopia);
                        }
                    }
                }
        }

        private void ExcluirFornecedor()
        {
            if(bsNegociacao.Current != null)
                if (bsItens.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão da negociação selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).lItensDel.Add(
                            bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem);
                        bsItens.RemoveCurrent();
                    }
                }
        }

        private void TFNegociacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (this.St_alterar)
            {
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                cd_grupo.Enabled = false;
                bb_grupo.Enabled = false;
                ds_negociacao.Focus();
            }
            else
            {
                bsNegociacao.AddNew();
                cd_produto.Focus();
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
            if (linha != null)
            {
                sigla_unidade.Text = linha["sigla_unidade"].ToString().Trim();
                cd_grupo.Text = linha["cd_grupo"].ToString().Trim();
                ds_grupo.Text = linha["ds_grupo"].ToString().Trim();
                cd_grupo.Enabled = linha["cd_grupo"].ToString().Trim().Equals(string.Empty);
                bb_grupo.Enabled = linha["cd_grupo"].ToString().Trim().Equals(string.Empty);
            }
            else
            {
                cd_grupo.Enabled = true;
                bb_grupo.Enabled = true;
            }
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'", new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null)
            {
                sigla_unidade.Text = linha["sigla_unidade"].ToString().Trim();
                cd_grupo.Text = linha["cd_grupo"].ToString().Trim();
                ds_grupo.Text = linha["ds_grupo"].ToString().Trim();
                cd_grupo.Enabled = linha["cd_grupo"].ToString().Trim().Equals(string.Empty);
                bb_grupo.Enabled = linha["cd_grupo"].ToString().Trim().Equals(string.Empty);
            }
            else
            {
                cd_grupo.Enabled = true;
                bb_grupo.Enabled = true;
            }
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            string vParam = "a.tp_grupo|=|'A'";//Somente grupo analitico
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParam);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "a.tp_grupo|=|'A'"; //Somente grupo analitico
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFNegociacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F10))
                this.InserirFornecedor();
            else if (e.KeyCode.Equals(Keys.F11))
                this.AlterarFornecedor();
            else if (e.KeyCode.Equals(Keys.F12))
                this.ExcluirFornecedor();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirFornecedor();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirFornecedor();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarFornecedor();
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

        private void TFNegociacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
