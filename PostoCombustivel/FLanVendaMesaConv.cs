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
    public partial class TFLanVendaMesaConv : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Nm_cliente
        { get; set; }
        public string Id_venda
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }

        public bool St_finalizar
        { get; set; }
        private bool St_produtocodigo { get; set; }

        public TFLanVendaMesaConv()
        {
            InitializeComponent();
        }

        private void AlterarQuantidade()
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                if (fQtde.ShowDialog() == DialogResult.OK)
                    if (fQtde.Quantidade > decimal.Zero)
                        Quantidade.Value = fQtde.Quantidade;
            }
        }

        private decimal BuscarSaldoLocal(string Cd_produto)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_produto)) &&
                (!string.IsNullOrEmpty(Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(Cd_empresa,
                                                                       Cd_produto,
                                                                       Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private decimal ConsultaPreco(string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_tabelapreco)))
                return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa,
                                                                                            pCd_produto,
                                                                                            Cd_tabelapreco,
                                                                                            null);
            else
                return decimal.Zero;
        }

        private void BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                if (Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cd_produto.Text, pCd_codbarra, null);

                if (lProduto.Count > 0)
                {
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_movestoque, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") != null)
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto))
                            {
                                decimal saldo = this.BuscarSaldoLocal(lProduto[0].CD_Produto);
                                if (saldo < 1)
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + Cd_empresa.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + Cd_local + "\r\n" +
                                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                //Buscar ficha tecnica produto composto
                                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(lProduto[0].CD_Produto, string.Empty, null);
                                lFicha.ForEach(p => p.Quantidade = p.Quantidade * Quantidade.Value);
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                //Buscar saldo itens da ficha tecnica
                                string msg = string.Empty;
                                lFicha.ForEach(p =>
                                {
                                    //Buscar saldo estoque do item
                                    decimal saldo = decimal.Zero;
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(Cd_empresa.Trim(), p.Cd_item, Cd_local.Trim(), ref saldo, null);
                                    if (saldo < p.Quantidade)
                                        msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                               "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                });
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    //Buscar preco venda produto
                    decimal vl_unit = this.ConsultaPreco(lProduto[0].CD_Produto);
                    if (vl_unit <= decimal.Zero)
                        using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                        {
                            fValor.Casas_decimais = 2;
                            fValor.Ds_label = "Valor Unitario";
                            if (fValor.ShowDialog() == DialogResult.OK)
                                vl_unit = fValor.Quantidade;
                        }
                    if (vl_unit > decimal.Zero)
                    {
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Gravar(
                                new CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv()
                                {
                                    Cd_empresa = Cd_empresa,
                                    Cd_local = Cd_local,
                                    Cd_produto = lProduto[0].CD_Produto,
                                    Id_vendastr = Id_venda,
                                    Quantidade = Quantidade.Value,
                                    Vl_unitario = vl_unit
                                }, null);
                            //Buscar Itens Venda
                            bsItensVenda.DataSource = CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(Id_venda,
                                                                                                                   Cd_empresa,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   false,
                                                                                                                   null);
                            //Totalizar Venda
                            this.TotalizarVenda();
                            //Quantidade Padrao
                            Quantidade.Value = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cd_produto.Clear();
                            cd_produto.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar preço venda item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        cd_produto.Focus();
                    }
                }
            }
        }

        private void TotalizarVenda()
        {
            if (bsItensVenda.List != null)
                tot_venda.Value = (bsItensVenda.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).Sum(p => p.Vl_liquido);
        }

        private void FinalizarVenda()
        {
            St_finalizar = true;
            this.Close();
        }

        private void ExcluirVenda()
        {
            if (new CamadaDados.PostoCombustivel.TCD_ItensVendaMesaConv().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_venda",
                        vOperador = "=",
                        vVL_Busca = Id_venda
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.Qtd_Faturada",
                        vOperador = ">",
                        vVL_Busca = "0"
                    }
                }, "1") == null)
            {
                if (MessageBox.Show("Confirma cancelamento da venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        //Buscar registro venda
                        CamadaDados.PostoCombustivel.TList_VendaMesaConv lVenda =
                            CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(Id_venda,
                                                                                    Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    false,
                                                                                    null);
                        if (lVenda.Count > 0)
                        {
                            CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Excluir(lVenda[0], null);
                            MessageBox.Show("Venda cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Venda ja possui item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItem()
        {
            if(bsItensVenda.Current != null)
                if (new CamadaDados.PostoCombustivel.TCD_ItensVendaMesaConv().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_venda",
                            vOperador = "=",
                            vVL_Busca = Id_venda
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_item",
                            vOperador = "=",
                            vVL_Busca = (bsItensVenda.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Id_itemstr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Qtd_Faturada",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, "1") == null)
                {
                    if(MessageBox.Show("Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Excluir(bsItensVenda.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv, null);
                            bsItensVenda.DataSource = CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(Id_venda,
                                                                                                                   Cd_empresa,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   true,
                                                                                                                   null);
                            this.TotalizarVenda();
                            cd_produto.Focus();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Não é permitido excluir item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanVendaMesaConv_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.St_produtocodigo = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_produtocodigo, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, "1") != null;
            //Buscar itens da venda
            bsItensVenda.DataSource = CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(Id_venda,
                                                                                                   Cd_empresa,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   false,
                                                                                                   null);
            nm_cliente.Text = Nm_cliente;
            this.TotalizarVenda();
        }

        private void TFLanVendaMesaConv_Activated(object sender, EventArgs e)
        {
            cd_produto.Focus();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (!this.St_produtocodigo)
                {
                    if (string.IsNullOrEmpty(cd_produto.Text))
                        FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             Cd_empresa,
                                                             Nm_empresa,
                                                             Cd_tabelapreco,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             null);
                    else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                        FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             Cd_empresa,
                                                             Nm_empresa,
                                                             Cd_tabelapreco,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             null);
                }
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanVendaMesaConv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
                this.AlterarQuantidade();
            else if (e.KeyCode.Equals(Keys.F4))
                this.FinalizarVenda();
            else if (e.KeyCode.Equals(Keys.F5))
                this.ExcluirVenda();
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                this.ExcluirItem();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void bb_finalizar_Click(object sender, EventArgs e)
        {
            this.FinalizarVenda();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.ExcluirVenda();
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFLanVendaMesaConv_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
