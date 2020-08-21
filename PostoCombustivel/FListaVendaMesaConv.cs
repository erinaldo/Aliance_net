using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaVendaMesaConv : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).FindAll(p => p.St_faturar);
                else
                    return null;
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }

        public TFListaVendaMesaConv()
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
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                    {
                        decimal saldo = BuscarSaldoLocal(lProduto[0].CD_Produto);
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
                    //Buscar preco venda produto
                    decimal vl_unit = ConsultaPreco(lProduto[0].CD_Produto);
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
                                    Id_vendastr = (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Id_vendastr,
                                    Quantidade = Quantidade.Value,
                                    Vl_unitario = vl_unit
                                }, null);
                            //Buscar Itens Venda
                            bsVenda_PositionChanged(this, new EventArgs());
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

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
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
                            vVL_Busca = (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Id_vendastr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_item",
                            vOperador = "=",
                            vVL_Busca = (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Id_itemstr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Qtd_Faturada",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, "1") == null)
                {
                    if (MessageBox.Show("Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Excluir(bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv, null);
                            bsVenda_PositionChanged(this, new EventArgs());
                            cd_produto.Focus();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Não é permitido excluir item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
                if ((bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).Exists(p => p.St_faturar))
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Não existe item selecionado para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não existe item selecionado para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFListaVendaMesaConv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                bb_identificarCliente_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F3))
                AlterarQuantidade();
            else if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                ExcluirItem();
        }

        private void TFListaVendaMesaConv_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsVenda.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                         Cd_empresa,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         "'A'",
                                                                                         true,
                                                                                         null);
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrEmpty(cd_produto.Text))
                {
                    MessageBox.Show("Obrigatório informar pelo menos um caractere para realizar busca.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!char.IsNumber(cd_produto.Text.Trim(), 0))
                    FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto },
                                                            string.Empty,
                                                            cd_produto.Text);
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).lItens =
                    new CamadaDados.PostoCombustivel.TCD_ItensVendaMesaConv().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_venda",
                            vOperador = "=",
                            vVL_Busca = (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Id_vendastr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Cd_empresa.Trim() + "'" 
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Quantidade - a.Qtd_Faturada",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    },0, string.Empty, "a.ID_Item desc");
                (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).lItens.ForEach(p => p.Qtd_faturar = p.Saldo);

                tot_venda.Value = (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).lItens.Sum(p => p.Vl_faturar);
                bsVenda.ResetCurrentItem();
            }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).ForEach(p => p.Qtd_faturar = p.Quantidade - p.Qtd_faturada);
                (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).ForEach(p => p.St_faturar = p.Qtd_faturar > decimal.Zero ? cbTodos.Checked : false);
                bsItens.ResetBindings(true);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if ((bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Qtd_faturar > decimal.Zero)
                {
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).St_faturar =
                        !(bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).St_faturar;
                    bsItens.ResetCurrentItem();
                }
        }

        private void TFListaVendaMesaConv_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }

        private void bb_identificarCliente_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
            if (linha != null)
            {
                (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).ForEach(p => p.Cd_clifor = linha["cd_clifor"].ToString());
                (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).ForEach(p => p.Nm_cliente = linha["nm_clifor"].ToString());
                (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Cd_cliente = linha["cd_clifor"].ToString();
                (bsVenda.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Nm_cliente = linha["nm_clifor"].ToString();
                bsVenda.ResetCurrentItem();
            }
        }

        private void Faturar_ValueChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (Faturar.Value <= (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Saldo)
                {
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).Qtd_faturar = Faturar.Value;
                }
                else
                {
                    MessageBox.Show("Valor informado maior que saldo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Faturar.Value = 0;    
                }
            }
        }

    }
}
