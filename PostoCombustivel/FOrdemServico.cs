using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFOrdemServico : Form
    {
        private Utils.TTpModo vModo;
        public string pLogin
        { get; set; }
        private CamadaDados.PostoCombustivel.TRegistro_OrdemServico ros;
        public CamadaDados.PostoCombustivel.TRegistro_OrdemServico rOs
        {
            get
            {
                if (bsOrdemServico.Current != null)
                    return bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico;
                else
                    return null;
            }
            set { ros = value; }
        }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }

        public TFOrdemServico()
        {
            InitializeComponent();
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(cd_endereco.Text))
                    {
                        cd_endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                    }
                }
            }
        }

        private void BuscarVendedor()
        {
            CamadaDados.Financeiro.Cadastros.TList_CadClifor lVend =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.BuscaVendedor(string.Empty,
                                                                               (string.IsNullOrEmpty(pLogin) ? Utils.Parametros.pubLogin : pLogin),
                                                                               null);
            if (lVend.Count > 0)
            {
                cd_vendedor.Text = lVend[0].Cd_clifor;
                nm_vendedor.Text = lVend[0].Nm_clifor;
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                //Verificar se o item nao tem faturamento
                if ((bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Id_item.HasValue)
                    if (new CamadaDados.PostoCombustivel.TCD_Ordem_X_VendaRapida().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_ordem",
                                vOperador = "=",
                                vVL_Busca = (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Id_ordemstr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_item",
                                vOperador = "=",
                                vVL_Busca = (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Id_itemstr
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Não é permitido alterar item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                (bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).lItensDel.Add(
                    bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico);
                bsItens.RemoveCurrent();
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFOrdemServico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (ros != null)
            {
                bsOrdemServico.DataSource = new CamadaDados.PostoCombustivel.TList_OrdemServico() { ros };
                //Verificar se OS ja teve faturamento
                if (new CamadaDados.PostoCombustivel.TCD_Ordem_X_VendaRapida().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + ros.Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_ordem",
                            vOperador = "=",
                            vVL_Busca = ros.Id_ordemstr
                        }
                    }, "1") != null)
                {
                    CD_Empresa.Enabled = false;
                    BB_Empresa.Enabled = false;
                    cd_clifor.Enabled = false;
                    bb_clifor.Enabled = false;
                    cd_endereco.Enabled = false;
                    bb_endereco.Enabled = false;
                    cd_vendedor.Enabled = false;
                    bb_vendedor.Enabled = false;
                    CD_TabelaPreco.Enabled = false;
                }
            }
            else
                bsOrdemServico.AddNew();
            this.BuscarVendedor();
        }

        private void BuscarProduto()
        {
            if (string.IsNullOrEmpty(cd_produto.Text))
                FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     CD_TabelaPreco.Text,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     CD_TabelaPreco.Text,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            if (BuscarItens())
            {
                cd_produto.Clear();
                Quantidade.Focus();
            }
            else
            {
                MessageBox.Show("Produto inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Clear();
                cd_produto.Focus();
            }
        }

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                string pCd_codbarra = cd_produto.Text;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (cd_produto.Text.Trim().Length < lParam[0].Tamanho)
                        cd_produto.Text = cd_produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cd_produto.Text,
                                                                                            pCd_codbarra,
                                                                                            null);

                if (lProduto.Count > 0)
                {
                    //Cria novo item
                    bsItens.AddNew();
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Cd_unidade = lProduto[0].CD_Unidade;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Cd_local = lCfg[0].Cd_local;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Sigla_unidade = lProduto[0].Sigla_unidade;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Quantidade = Quantidade.Value;
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario = this.ConsultaPreco(lProduto[0].CD_Produto);
                    if ((bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario > decimal.Zero)
                    {
                        decimal SUBTOTAL =
                            Quantidade.Value * (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario;
                        lblVlSubTotal.Text = SUBTOTAL.ToString();
                    }
                    vl_unitario.Enabled = vl_unitario.Value.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
 
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                         cd_clifor.Text,
                                                                                                         vCd_produto,
                                                                                                         CD_TabelaPreco.Text,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa.Text,
                                                                                                    vCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa.Text,
                                                                                                vCd_produto,
                                                                                                CD_TabelaPreco.Text,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar CFG Cupom
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count < 1)
                {
                    MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + CD_Empresa.Text,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    NM_Empresa.Clear();
                    CD_Empresa.Focus();
                }
                else
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
               //Buscar CFG Cupom
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count < 1)
                {
                    MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + CD_Empresa.Text,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    NM_Empresa.Clear();
                    CD_Empresa.Focus();
                }
                else
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            this.Busca_Endereco_Clifor();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Cd. Endereço|80";
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), string.Empty);
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFOrdemServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                this.ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F12))
                this.BuscarProduto();
        }

        private void TFOrdemServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            vl_unitario.Value = vl_unitario.Minimum;
            lblVlSubTotal.Text = string.Empty;
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                this.BuscarProduto();
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Quantidade_Leave(sender, new EventArgs());
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Quantidade = Quantidade.Value;
                decimal SUBTOTAL = Quantidade.Value * (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario;
                lblVlSubTotal.Text = SUBTOTAL.ToString();
                bsItens.ResetCurrentItem();
                if (!cd_produto.Focused)
                    vl_unitario.Focus();
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Quantidade > decimal.Zero ?
                (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Quantidade : 1;
            vl_unitario.Value = bsItens.Current == null ? vl_unitario.Minimum : (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario;
            lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_unitario_Leave(this, new EventArgs());
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (vl_unitario.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não é permitido vender item sem valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_unitario.Focus();
                    return;
                }
                //Buscar custo produto
                decimal vl_custo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(CD_Empresa.Text,
                                                                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Cd_produto,
                                                                    ref vl_custo,
                                                                    null);
                if (vl_unitario.Value < vl_custo)
                {
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "PERMITIR VENDA ABAIXO CUSTO";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                            //Verificar se o usuario tem permissao para venda abaixo custo
                            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR VENDA ABAIXO CUSTO", null))
                            {
                                (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario = vl_unitario.Value;
                                bsItens.ResetCurrentItem();
     
                                bsItens_PositionChanged(this, new EventArgs());
                            }
                            else
                                vl_unitario.Focus();
                        else
                            vl_unitario.Focus();
                    }
                }
                else
                {
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario = vl_unitario.Value;
                    decimal SUBTOTAL = Quantidade.Value * (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario;
                    lblVlSubTotal.Text = SUBTOTAL.ToString();
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                }
            }
        }
    }
}
