using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Compra
{
    public partial class TFNegFornec : Form
    {
        public CamadaDados.Compra.Lancamento.TList_Negociacao lNegociacao
        {
            get
            {
                if (bsNegociacao.Count > 0)
                {
                    CamadaDados.Compra.Lancamento.TList_Negociacao aux = new CamadaDados.Compra.Lancamento.TList_Negociacao();
                    for (int i = 0; i < bsNegociacao.Count; i++)
                        aux.Add(bsNegociacao[i] as CamadaDados.Compra.Lancamento.TRegistro_Negociacao);
                    return aux;
                }
                else
                    return null;
            }
        }

        public TFNegFornec()
        {
            InitializeComponent();
        }

        private void BuscarEnd()
        {
            if (cd_fornecedor.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'"+cd_fornecedor.Text.Trim()+"'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    cd_endfornecedor.Text = obj.ToString();
            }
        }

        private void BuscarProdutos()
        {
            if (cd_fornecedor.Text.Trim() != string.Empty)
            {
                bsProdutos.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cmp_fornec_x_grupoitem x " +
                                        "where x.cd_grupo = a.cd_grupo " +
                                        "and x.cd_clifor = '" + cd_fornecedor.Text.Trim() + "')"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
            }
        }

        private void InserirPrazoEntrega()
        {
            using (TFLanPrazoEntrega fPrazo = new TFLanPrazoEntrega())
            {
                if (fPrazo.ShowDialog() == DialogResult.OK)
                    if (fPrazo.rPrazo != null)
                        bsPrazoEntrega.Add(fPrazo.rPrazo);
            }
        }

        private void DeletarPrazoEntrega()
        {
            if (bsPrazoEntrega.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    bsPrazoEntrega.RemoveCurrent();
        }

        private int LocalizarNegociacaoProduto()
        {
            int index = -1;
            if ((bsProdutos.Current != null) && (bsNegociacao.Count > 0))
                for (int i = 0; i < bsNegociacao.Count; i++)
                    if ((bsNegociacao[i] as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto.Trim().Equals((bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim()))
                    {
                        index = i;
                        break;
                    }
            return index;
        }

        private bool RemoverNegLista()
        {
            if (bsNegociacao.Count > 0)
            {
                for(int i = 0; i < bsNegociacao.Count; i++)
                    if ((bsNegociacao[i] as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto.Trim().Equals((bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim()))
                    {
                        bsNegociacao.RemoveAt(i);
                        return true;
                    }
                return false;
            }
            else
                return false;
        }

        private void TFNegFornec_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPrazoEntrega);
            Utils.ShapeGrid.RestoreShape(this, gProdutos);
            pFiltroProduto.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pvalneg.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, vParam);
            this.BuscarEnd();
            this.BuscarProdutos();
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEnd();
            this.BuscarProdutos();
        }

        private void bb_endfornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_endfornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endfornecedor.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_contato_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Contato|Nome Contato|200;" +
                              "a.Email|Email|200;" +
                              "a.Fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "a.tp_contato|=|'C'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nm_vendedor, email_vendedor },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor(),
                                                        vParam);
            if (linha != null)
                fonefax.Text = linha["fone"].ToString();
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void gProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar)
                {
                    //Remover item da lista de negociacao
                    if(this.RemoverNegLista())
                        (bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar = false;
                }
                else
                {
                    if (pDados.validarCampoObrigatorio())
                    {
                        //Incluir registro negociacao 
                        //Criar lista de entrega
                        CamadaDados.Compra.Lancamento.TList_PrazoEntrega lPrazo = new CamadaDados.Compra.Lancamento.TList_PrazoEntrega();
                        for (int i = 0; i < bsPrazoEntrega.Count; i++)
                            lPrazo.Add(bsPrazoEntrega[i] as CamadaDados.Compra.Lancamento.TRegistro_PrazoEntrega);
                        using (TFValorNegociacao fValor = new TFValorNegociacao())
                        {
                            fValor.Sigla = sigla.Text;
                            if (fValor.ShowDialog() == DialogResult.OK)
                            {
                                bsNegociacao.AddNew();
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_grupo = (bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Grupo;
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Cd_produto = (bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_negociacao = string.Empty;
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Ds_observacao = string.Empty;
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).Dt_negociacao = DateTime.Now;
                                (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Negociacao).lItens = new CamadaDados.Compra.Lancamento.TList_NegociacaoItem()
                                {
                                    new CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem()
                                    {
                                        Cd_condpgto = cd_condpgto.Text,
                                        Cd_endfornecedor = cd_endfornecedor.Text,
                                        Cd_fornecedor = cd_fornecedor.Text,
                                        Cd_moeda = cd_moeda.Text,
                                        Cd_portador = cd_portador.Text,
                                        Email_vendedor = email_vendedor.Text,
                                        FoneFax = fonefax.Text,
                                        Nm_vendedor = nm_vendedor.Text,
                                        Nr_diasvigencia = nr_diasvigencia.Value,
                                        Qtd_min_compra = fValor.Qtd_min_compra,
                                        Qtd_porcompra = fValor.Qtd_compra,
                                        St_depositarpagtobool = st_depositarpagto.Checked,
                                        Vl_unitario_negociado = fValor.Vl_unit_negociado,
                                        Sigla = sigla.Text,
                                        lPrazoEntrega = lPrazo
                                    }
                                };
                                (bsProdutos.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar = true;
                            }
                        }
                    }
                }
                bsProdutos_PositionChanged(this, new EventArgs());
            }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirPrazoEntrega();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.DeletarPrazoEntrega();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if(pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFNegFornec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F10) && tcAux.SelectedTab.Equals(tpPrazoEntrega))
                this.InserirPrazoEntrega();
            else if (e.KeyCode.Equals(Keys.F11) && tcAux.SelectedTab.Equals(tpPrazoEntrega))
                this.DeletarPrazoEntrega();
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Descrição Moeda|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_localizar_Click(object sender, EventArgs e)
        {
            if (bsProdutos.Count > 0)
                for (int i = 0; i < bsProdutos.Count; i++)
                    if ((bsProdutos[i] as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim().Equals(cd_produto.Text.Trim()))
                        break;
                    else
                        bsProdutos.MoveNext();
        }

        private void bsProdutos_PositionChanged(object sender, EventArgs e)
        {
            int i = this.LocalizarNegociacaoProduto();
            pvalneg.Visible = !i.Equals(-1);
            bsNegociacao.Position = i;
            bsNegociacao.ResetCurrentItem();
        }

        private void TFNegFornec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPrazoEntrega);
            Utils.ShapeGrid.SaveShape(this, gProdutos);
        }
    }
}
