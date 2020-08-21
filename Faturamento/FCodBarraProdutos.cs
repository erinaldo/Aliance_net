using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using Utils;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;

namespace Faturamento
{
    public partial class TFCodBarraProdutos : Form
    {
        private TRegistro_LanPedido_Item _LanPedido_Item = null;
        public string TbPreco { get; set; } = string.Empty;
        public string CdEmpresa { get; set; } = string.Empty;
        public IEnumerable<TRegistro_LanPedido_Item> _LanPedido_Items
        {
            get
            {
                return (bsProdutos.List as IEnumerable<TRegistro_LanPedido_Item>).ToList();
            }
            set { }
        }

        public TFCodBarraProdutos()
        {
            InitializeComponent();
        }

        private void codBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                buscarProduto();
        }

        private void buscarProduto()
        {
            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "", "(select 1 " +
                                                   "from TB_EST_CodBarra xxx " +
                                                   "where xxx.CD_Produto = a.cd_produto " +
                                                   "and xxx.CD_CodBarra = '" + codBarras.Text.Trim() + "')", "exists");
            TList_CadProduto lProd = new TCD_CadProduto().Select(tps, 0, string.Empty, string.Empty, string.Empty);
            if (lProd.Count.Equals(0))
                MessageBox.Show("Nenhum produto foi encontrado pelo código de barras: " + codBarras.Text.Trim() + " informado. " +
                    "Verifique o valor e acione ENTER novamente.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                _LanPedido_Item = new TRegistro_LanPedido_Item();

                //Buscar local de armazenagem do produto
                TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
                if (!string.IsNullOrEmpty(lProd[0].CD_Produto))
                    List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, lProd[0].CD_Produto);

                Componentes.EditDefault CD_Local = new Componentes.EditDefault();
                Componentes.EditDefault DS_Local = new Componentes.EditDefault();

                if (List_Local_x_Produto.Count.Equals(1))
                {
                    CD_Local.Text = List_Local_x_Produto[0].CD_Local;
                    DS_Local.Text = List_Local_x_Produto[0].DS_Local;
                }
                else if (List_Local_x_Produto.Count > 1)
                {
                    string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                        "a.cd_produto|=|" + lProd[0].CD_Produto;
                    UtilPesquisa.BTN_BUSCA("c.DS_Local|Local|300",
                        new Componentes.EditDefault[] { CD_Local, DS_Local },
                        new TCD_CadLocalArm_X_Produto(),
                        vParam);
                }
                else
                {
                    TList_CadLocalArm_X_Empresa _CadLocalArm_X_Empresas = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, CdEmpresa, "A", string.Empty, null);
                    if (_CadLocalArm_X_Empresas.Count.Equals(0))
                    {
                        closeWithMessage("Não existe pré-cadastrado no sistema local de armazenagem para a empresa informada. " +
                            "Não será possível finalizar a operação.", false);
                        return;
                    }
                    else if (_CadLocalArm_X_Empresas.Count > 1)
                    {
                        string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                        "a.cd_empresa|=|" + CdEmpresa;
                        UtilPesquisa.BTN_BUSCA("c.DS_Local|Local|300",
                            new Componentes.EditDefault[] { CD_Local, DS_Local },
                            new TCD_CadLocalArm_X_Empresa(),
                            vParam);
                    }
                    else
                    {
                        CD_Local.Text = _CadLocalArm_X_Empresas[0].CD_Local;
                        DS_Local.Text = _CadLocalArm_X_Empresas[0].DS_Local;
                    }
                }

                if (string.IsNullOrEmpty(CD_Local.Text.Trim()))
                {
                    closeWithMessage("É obrigatório informar local de armazenagem.", false);
                    return;
                }

                _LanPedido_Item.Cd_produto = lProd[0].CD_Produto;
                _LanPedido_Item.Ds_produto = lProd[0].DS_Produto;
                _LanPedido_Item.Cd_local = CD_Local.Text.Trim();
                _LanPedido_Item.Ds_local = DS_Local.Text.Trim();
                _LanPedido_Item.Cd_unidade_valor = lProd[0].CD_Unidade;
                _LanPedido_Item.Ds_unidade_valor = lProd[0].DS_Unidade.Trim();
                _LanPedido_Item.Sg_unidade_valor = lProd[0].Sigla_unidade.Trim();
                _LanPedido_Item.St_registro = "A";

                adicionarProduto();
            }

        }

        private void codBarras_Leave(object sender, EventArgs e)
        {
            if (_LanPedido_Item == null && !string.IsNullOrEmpty(codBarras.Text.Trim()))
                buscarProduto();
        }

        private void adicionarProduto()
        {
            if (_LanPedido_Item != null && qtdProduto.Value > 0)
            {
                _LanPedido_Item.Quantidade = qtdProduto.Value;

                object precoVenda = new TCD_CadProduto().BuscarPrecoVenda(CdEmpresa, _LanPedido_Item.Cd_produto, TbPreco);
                if (precoVenda == null || string.IsNullOrEmpty(precoVenda.ToString()) || decimal.Parse(precoVenda.ToString()) <= 0)
                {
                    closeWithMessage("O produto de código: " + _LanPedido_Item.Cd_produto + " \n" +
                        "Descrição: " + _LanPedido_Item.Ds_produto + " \n" +
                        "Não possui preço de venda pré-cadastrado. \n" +
                        "Empresa: " + _LanPedido_Item.Cd_Empresa + " \n" +
                        "Tab. Preço: " + TbPreco, false);
                    return;
                }

                _LanPedido_Item.Vl_unitario = decimal.Parse(precoVenda.ToString());
                _LanPedido_Item.Vl_subtotal = _LanPedido_Item.Vl_unitario * _LanPedido_Item.Quantidade;

                if (!validarExistencia(_LanPedido_Item))
                    bsProdutos.Add(_LanPedido_Item);

                bsProdutos.ResetBindings(true);

                limparCampos();
            }
            else if (string.IsNullOrEmpty(qtdProduto.Value.ToString()) || qtdProduto.Value <= 0)
                MessageBox.Show("É permitido adicionar apenas produtos com quantidade maior que zero.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Método valida se item informado já existe na listagem,
        /// caso existe deve apenas incrementar na quantidade, e
        /// não deve adicionar novo produto. Ticket 8510
        /// </summary>
        /// <param name="lanPedido_Item"> Novo item informado</param>
        /// <returns>
        /// True, já existe na listagem
        /// False, ainda não existe na listagem
        /// </returns>
        private bool validarExistencia(TRegistro_LanPedido_Item lanPedido_Item)
        {
            bool ret = false;
            (bsProdutos.List as IEnumerable<TRegistro_LanPedido_Item>).ToList().ForEach(r => 
            {
                if (r.Cd_produto.Equals(lanPedido_Item.Cd_produto))
                {
                    r.Quantidade += lanPedido_Item.Quantidade;
                    r.Vl_subtotal = r.Quantidade * r.Vl_unitario;
                    ret = true;
                }
            });

            return ret;
        }

        private void limparCampos()
        {
            _LanPedido_Item = null;
            qtdProduto.Value = 1;
            codBarras.Text = "";
            codBarras.Select();
        }

        private void TFCodBarraProdutos_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbPreco))
                closeWithMessage("Erro: Não foi informado corretamente o código da tabela de preço. " +
                    "Não será possível finalizar a operação.");
            else if (string.IsNullOrEmpty(CdEmpresa))
                closeWithMessage("Erro: Não foi informado corretamente o código da empresa. " +
                    "Não será possível finalizar a operação.");

            codBarras.Select();
        }

        private void closeWithMessage(string v, bool close = true)
        {
            MessageBox.Show(v, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (close)
                Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionarProduto();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFCodBarraProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
