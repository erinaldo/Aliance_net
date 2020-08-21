using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFFatOrcProjeto : Form
    {
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rOrc
        { get; set; }

        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;

        public TFFatOrcProjeto()
        {
            InitializeComponent();
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            //Vefiricar se existe programacao especial de venda 
            rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                                 (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
                                                                                                 vCd_produto,
                                                                                                 string.Empty,
                                                                                                 null);
            if (rProg != null)
                if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                    return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                            vCd_produto,
                                                                                            null);
            if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_tabelapreco))
                return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                            vCd_produto,
                                                                                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_tabelapreco,
                                                                                            null);
            else
                return decimal.Zero;
        }

        private void BuscarProduto()
        {
            if (bsItens.Current != null)
            {
                decimal tot_faturado = decimal.Zero;
                if (bsItensFat.Count > 0)
                    tot_faturado = (bsItensFat.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal);
                if ((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_faturar - tot_faturado > decimal.Zero)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                    filtro[0].vNM_Campo = "isnull(e.st_servico, 'N')";
                    filtro[0].vOperador = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_servicobool ? "=" : "<>";
                    filtro[0].vVL_Busca = "'S'";
                    if (string.IsNullOrEmpty(CD_Produto.Text))
                        FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nm_empresa,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_tabelapreco,
                                                             new Componentes.EditDefault[] { CD_Produto },
                                                             filtro);
                    else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                        FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nm_empresa,
                                                             (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_tabelapreco,
                                                             new Componentes.EditDefault[] { CD_Produto },
                                                             null);
                }
                else
                {
                    MessageBox.Show("Item orçamento não possui mais saldo disponivel para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (BuscarItens())
                {
                    CD_Produto.Clear();
                    Quantidade.Focus();
                }
                else
                {
                    MessageBox.Show("Produto inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    CD_Produto.Focus();
                }
            }
        }

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                string pCd_codbarra = CD_Produto.Text;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (CD_Produto.Text.Trim().Length < lParam[0].Tamanho)
                        CD_Produto.Text = CD_Produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(CD_Produto.Text,
                                                                                            pCd_codbarra,
                                                                                            null);

                if (lProduto.Count > 0)
                {
                    //Cria novo item
                    bsItensFat.AddNew();
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto = lProduto[0].CD_Produto;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Ds_produto = lProduto[0].DS_Produto;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_unidade_valor = lProduto[0].CD_Unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Ds_unidade_valor = lProduto[0].DS_Unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Sg_unidade_valor = lProduto[0].Sigla_unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_unidade_est = lProduto[0].CD_Unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Ds_unidade_est = lProduto[0].DS_Unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Sg_unidade_est = lProduto[0].Sigla_unidade;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_grupo = lProduto[0].CD_Grupo;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).ncm = lProduto[0].Ncm;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_condfiscal_produto = lProduto[0].CD_CondFiscal_Produto;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Quantidade = Quantidade.Value;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario = this.ConsultaPreco(lProduto[0].CD_Produto);
                    if ((bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario > decimal.Zero)
                    {
                        (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_subtotal =
                            Quantidade.Value * (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario;
                    }
                    //Verificar se usuario´pode informar preço de Venda
                    Vl_Unitario.Enabled = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
                    bsItensFat.ResetCurrentItem();
                    bsItensFat_PositionChanged(this, new EventArgs());
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void ExcluirItens()
        {
            if (bsItensFat.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsItensFat.RemoveCurrent();
        }

        private void bsItensFat_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensFat.Current != null)
            {
                DS_Produto.Text = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Ds_produto;
                Quantidade.Value = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Quantidade;
                SG_Unidade_Estoque.Text = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Sg_unidade_est;
                Vl_Unitario.Value = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario;
                Sub_Total.Value = (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_subtotal;
            }
        }

        private void gItensOrc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(!(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar)
                    if ((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_faturar.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Item sem saldo para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar =
                    !(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar;
                bsItens.ResetCurrentItem();
            }
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {
                this.BuscarProduto();
                Quantidade.Focus();
            }
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItensFat.Current != null)
            {
                if (Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quantidade.Focus();
                    return;
                }
                (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Quantidade = Quantidade.Value;
                (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_subtotal = Quantidade.Value *
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario;
                bsItensFat.ResetCurrentItem();
                if ((bsItensFat.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal) >
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_faturar)
                {
                    MessageBox.Show("Valor faturado maior que o saldo disponivel para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quantidade.Focus();
                    return;
                }
                if (!CD_Produto.Focused)
                    Vl_Unitario.Focus();
                bsItensFat_PositionChanged(this, new EventArgs());
            }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Quantidade_Leave(sender, new EventArgs());
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            if (bsItensFat.Current != null)
            {
                if (Vl_Unitario.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não é permitido vender item sem valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Vl_Unitario.Focus();
                    return;
                }
                //Buscar custo produto
                decimal vl_custo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto,
                                                                    ref vl_custo,
                                                                    null);
                if (Vl_Unitario.Value < vl_custo)
                {
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "PERMITIR VENDA ABAIXO CUSTO";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                            //Verificar se o usuario tem permissao para venda abaixo custo
                            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR VENDA ABAIXO CUSTO", null))
                            {
                                (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario = Vl_Unitario.Value;
                                (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_subtotal = Quantidade.Value * Vl_Unitario.Value;
                                bsItensFat.ResetCurrentItem();
                                if ((bsItensFat.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal) >
                                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_faturar)
                                {
                                    MessageBox.Show("Valor faturado maior que o saldo disponivel para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Vl_Unitario.Focus();
                                    return;
                                }
                                ds_observacao.Focus();
                                bsItensFat_PositionChanged(this, new EventArgs());
                            }
                            else
                                Vl_Unitario.Focus();
                        else
                            Vl_Unitario.Focus();
                    }
                }
                else
                {
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario = Vl_Unitario.Value;
                    (bsItensFat.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_subtotal = Quantidade.Value * Vl_Unitario.Value;
                    bsItensFat.ResetCurrentItem();
                    if ((bsItensFat.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal) >
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_faturar)
                    {
                        MessageBox.Show("Valor faturado maior que o saldo disponivel para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Vl_Unitario.Focus();
                        return;
                    }
                    bsItensFat_PositionChanged(this, new EventArgs());
                    ds_observacao.Focus();
                }
            }
        }

        private void TFFatOrcProjeto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { rOrc };
        }

        private void CD_Produto_Enter(object sender, EventArgs e)
        {
            DS_Produto.Clear();
            Quantidade.Value = 1;
            Vl_Unitario.Value = Vl_Unitario.Minimum;
            Sub_Total.Value = decimal.Zero;
            ds_observacao.Clear();
        }

        private void Vl_Unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Vl_Unitario_Leave(sender, new EventArgs());
        }

        private void bsItensFat_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(bsItensFat.Count > 0)
                tslFaturar.Text = (bsItensFat.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFFatOrcProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                this.ExcluirItens();


        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            this.ExcluirItens();
        }

        private void ds_observacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                CD_Produto.Focus();
        }
    }
}
