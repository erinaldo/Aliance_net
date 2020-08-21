using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using System.Text;
using Utils; 
using System.Collections.Generic;

namespace Faturamento
{
    public partial class TFItensOrcamento : Form
    {
        List<decimal> lista = new List<decimal>(); 
        CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item item = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private bool St_informarpreco = false;
        private bool St_somarPrecoFicha = false;
        private bool St_composto = false;
        private bool St_industrializado = false;
        public bool st_alterar = false;
        public bool St_representante { get; set; }
        public string CD_Empresa = string.Empty;
        public string Nm_empresa = string.Empty;
        public string CD_TabelaPreco = string.Empty;
        public string Cd_cliente = string.Empty;
        public string Cd_vendedor = string.Empty;
        public decimal Pc_desconto = decimal.Zero;
        public string Ds_observacao = string.Empty;
        private string Ds_fichaTec = string.Empty;
        private string LoginDesconto = string.Empty;
        private string tp_unidade = string.Empty;
        private string larguras = string.Empty;
        private bool St_obrigaCusto = false;


        private void calcularunidade()
        {
            decimal valor = decimal.Zero;
            if (tp_unidade.Equals("0")) //Metro Quadrado
            {
                //vl_altura.Visible = false;
                //lblAltura.Visible = false;
                valor = vl_comprimento.Value * vl_largura.Value * qtd.Value ;
              //  Quantidade.Enabled = false;
                tot_r.Value = valor;
                tableLayoutPanel2.RowStyles[1].Height = 80;
            }
            else
            if (tp_unidade.Equals("1"))
            {
                //if (!vl_altura.Visible)
                //{
                //    vl_altura.Visible = true;
                //    lblAltura.Visible = true;
                //}
                //valor = vl_altura.Value * vl_comprimento.Value * vl_largura.Value;
                //Quantidade.Enabled = false;
                tableLayoutPanel2.RowStyles[1].Height = 80;
             //   qtd_restante.Value = decimal.Subtract(Quantidade.Value, tot_r.Value);
            }
            else
            {
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_comprimento = decimal.Zero;
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_altura = decimal.Zero;
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_largura = decimal.Zero;
                tableLayoutPanel2.RowStyles[1].Height = 0;
                Quantidade.Enabled = true;
            }

        }

        private CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item ritem;
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item rItem
        {
            get
            {
                if (bsItensOrcamento.Current != null)
                    return bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                else
                    return null;
            }
            set
            { ritem = value; }
        }

        public TFItensOrcamento()
        {
            InitializeComponent();
            ritem = null;
            rProg = null;
        }

        private void ConsultaPreco()
        {
            
            if (!st_alterar)
            {
                //Verificar se existe programacao especial de venda 
                rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa,
                                                                                                     Cd_cliente,
                                                                                                     CD_Produto.Text,
                                                                                                     CD_TabelaPreco,
                                                                                                     null);
                if (rProg != null)
                {
                    if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                    {
                        (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario =
                            CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa, CD_Produto.Text, null);
                        bsItensOrcamento.ResetCurrentItem();
                    }
                    else
                    { 
                        (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario =
                        CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                        St_somarPrecoFicha = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario.Equals(decimal.Zero);
                        bsItensOrcamento.ResetCurrentItem();
                    }
                }
                else if ((!string.IsNullOrEmpty(CD_Produto.Text)) &&
                    (!string.IsNullOrEmpty(CD_Empresa)) &&
                    (!string.IsNullOrEmpty(CD_TabelaPreco)))
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario =
                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                    St_somarPrecoFicha = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario.Equals(decimal.Zero);
                    bsItensOrcamento.ResetCurrentItem();
                }

                //Buscar custo produto
                vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa, CD_Produto.Text, null);
                CalcularDescEspecial();
            }
            vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
            St_informarpreco = CD_TabelaPreco.Trim().Equals(string.Empty) ||
                                Vl_Unitario.Value.Equals(decimal.Zero) ||
                                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                                             null);
            St_somarPrecoFicha = Vl_Unitario.Value.Equals(decimal.Zero);
            Vl_Unitario.Enabled = St_informarpreco;
        }

        private void CalcularDescEspecial()
        {
            if ((rProg != null) && (Quantidade.Value > decimal.Zero))
                if (rProg.Valor > decimal.Zero)
                {
                    bsItensOrcamento.ResetCurrentItem();
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade = Quantidade.Value;
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_desconto =
                            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade * rProg.Valor;
                    else
                        (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Pc_desconto = rProg.Valor;
                    bsItensOrcamento.ResetCurrentItem();
                }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!Quantidade.Focus())
                        vl_comprimento.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CD_Produto.Text) &&
                    string.IsNullOrEmpty(DS_Produto.Text))
                {
                    MessageBox.Show("Obrigatorio informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Focus();
                    return;
                }
                if ((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_custo.Equals(decimal.Zero) &&
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_OBRIGAR_CUSTO_UNIT_ORC",
                                                                         null).Equals(true))
                {
                    MessageBox.Show("Obrigatório informar Vl.custo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar custo produto
                decimal vl_custo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(CD_Empresa,
                                                                   (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto,
                                                                   ref vl_custo,
                                                                   null);
                if (Vl_Unitario.Value < vl_custo)
                {
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "PERMITIR VENDA ABAIXO CUSTO";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                        {
                            //Verificar se o usuario tem permissao para venda abaixo custo
                            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR VENDA ABAIXO CUSTO", null))
                                DialogResult = DialogResult.OK;
                            else
                                Vl_Unitario.Focus();
                        }
                        else
                            Vl_Unitario.Focus();
                    }
                }
                else
                    DialogResult = DialogResult.OK;
            }
        }

        private void InserirItemFicha()
        {
            if (bsItensOrcamento.Current != null)
                using (TFItensFichaTecOrc fItem = new TFItensFichaTecOrc())
                {
                    fItem.CD_Empresa = CD_Empresa;
                    fItem.CD_TabelaPreco = CD_TabelaPreco;
                    if (fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rFicha != null)
                        {
                            if ((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Exists(p => p.Cd_item.Trim().Equals(fItem.rFicha.Cd_item)))
                                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Find(p => p.Cd_item.Trim().Equals(fItem.rFicha.Cd_item)).Quantidade += fItem.rFicha.Quantidade;
                            else
                                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Add(fItem.rFicha);
                            if (Vl_Unitario.Enabled && St_somarPrecoFicha)
                                Vl_Unitario.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal);
                            vl_custo.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_custo * p.Quantidade);
                            vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                            tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                                ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            bsItensOrcamento.ResetCurrentItem();
                        }
                }
        }

        private void AlterarItemFicha()
        {
            if (bsFichaTec.Current != null)
            {
                CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem rAux = new CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem();
                rAux.Nr_orcamento = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Nr_orcamento;
                rAux.Id_item = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Id_item;
                rAux.Cd_item = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Cd_item;
                rAux.Cd_unditem = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Cd_unditem;
                rAux.Ds_item = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Ds_item;
                rAux.Ds_unditem = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Ds_unditem;
                rAux.Quantidade = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Quantidade;
                rAux.Sg_unditem = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Sg_unditem;
                using (TFItensFichaTecOrc fItem = new TFItensFichaTecOrc())
                {
                    fItem.CD_Empresa = CD_Empresa;
                    fItem.CD_TabelaPreco = CD_TabelaPreco;
                    fItem.rFicha = bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Nr_orcamento = rAux.Nr_orcamento;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Id_item = rAux.Id_item;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Cd_item = rAux.Cd_item;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Cd_unditem = rAux.Cd_unditem;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Ds_item = rAux.Ds_item;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Ds_unditem = rAux.Ds_unditem;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Quantidade = rAux.Quantidade;
                        (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Sg_unditem = rAux.Sg_unditem;
                    }
                    if (Vl_Unitario.Enabled && St_somarPrecoFicha)
                        Vl_Unitario.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal);
                    vl_custo.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_custo * p.Quantidade);
                    vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                    tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    bsFichaTec.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItemFicha()
        {
            if (bsFichaTec.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTecDel.Add(
                        bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem);
                    bsFichaTec.RemoveCurrent();
                    if (Vl_Unitario.Enabled && St_somarPrecoFicha)
                        Vl_Unitario.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal);
                    vl_custo.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_custo * p.Quantidade);
                    vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                    tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarProduto()
        {
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             CD_TabelaPreco,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             CD_TabelaPreco,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                St_composto = rProd.St_composto;
                St_industrializado = rProd.St_industrializado;
                SG_Unidade_Estoque.Text = rProd.Sigla_unidade;
                st_servico.Checked = rProd.St_servico;
                Ds_fichaTec = rProd.DS_TecnicaAssistencia;
                if (bsItensOrcamento.Current != null)
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo = rProd.CD_Grupo;
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_condfiscal_produto = rProd.DS_CondFiscal_Produto;
                    BuscarFichaTecItem();
                }
                ConsultaPreco();
            }
            else
            {
                CD_Produto.Clear();
                CD_Produto.Focus();
            }
            LoginDesconto = string.Empty;
        }

        private void NovoProduto()
        {
            using (Proc_Commoditties.TFAtualizaCadProduto fAtualiza = new Proc_Commoditties.TFAtualizaCadProduto())
            {
                fAtualiza.Text = "Novo Cadastro Produto";
                fAtualiza.Cd_empresa = CD_Empresa;
                fAtualiza.Cd_tabelapreco = CD_TabelaPreco;
                if (fAtualiza.ShowDialog() == DialogResult.OK)
                    if (fAtualiza.rProd != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                            MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Produto.Text = fAtualiza.rProd.CD_Produto;
                            CD_Produto_Leave(this, new EventArgs());
                            ConsultaPreco();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void AlterarDs_Tec()
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                using (TFDs_FichaTec fDs_tec = new TFDs_FichaTec())
                {
                    if (string.IsNullOrEmpty((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_Fichatec))
                        fDs_tec.Ds_fichaTec = Ds_fichaTec;
                    else
                        fDs_tec.Ds_fichaTec = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_Fichatec.Trim();
                    if (fDs_tec.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fDs_tec.Ds_fichaTec))
                            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_Fichatec =
                                fDs_tec.Ds_fichaTec.Trim();
                }
            }
        }

        private bool ValidarDescontos()
        {
            object obj_logindesc = null;
            if(!string.IsNullOrEmpty(LoginDesconto))
            {
                //Buscar Vendedor
                obj_logindesc = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_funcativo, 'S')",
                                        vOperador = "<>",
                                        vVL_Busca = "'N'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.LoginVendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + LoginDesconto.Trim() + "'"
                                    }
                                }, "a.cd_clifor");
            }
            //Buscar lista de descontos configuradas para o vendedor
            CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(obj_logindesc == null ? Cd_vendedor : obj_logindesc.ToString(),
                                                                                CD_Empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            if (lDesc.Count > 0)
            {
                if (!string.IsNullOrEmpty(CD_TabelaPreco))
                    if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim()) &&
                                        p.Cd_grupo.Trim().Equals((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo.Trim())))
                    {
                        //Desconto por tabela de preco e grupo de produto
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim()) &&
                                                                p.Cd_grupo.Trim().Equals((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo.Trim())).Pc_max_desconto;
                        if (Pc_DescontoItem.Value > pc_max_desc)
                        {
                            MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_tabelapreco = CD_TabelaPreco;
                                fLogin.Cd_empresa = CD_Empresa;
                                fLogin.Pc_desc = Pc_DescontoItem.Value;
                                fLogin.Cd_grupo = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    VL_Desconto.Value = decimal.Zero;
                                    Pc_DescontoItem.Value = decimal.Zero;
                                    Pc_DescontoItem.Focus();
                                    return false;
                                }
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim())))
                    {
                        //Desconto por tabela de preço
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim())).Pc_max_desconto;
                        if (Pc_DescontoItem.Value > pc_max_desc)
                        {
                            MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_tabelapreco = CD_TabelaPreco;
                                fLogin.Cd_empresa = CD_Empresa;
                                fLogin.Pc_desc = Pc_DescontoItem.Value;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    VL_Desconto.Value = decimal.Zero;
                                    Pc_DescontoItem.Value = decimal.Zero;
                                    Pc_DescontoItem.Focus();
                                    return false;
                                }
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                //Desconto por grupo de produto
                if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo.Trim())))
                {
                    decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo.Trim())).Pc_max_desconto;
                    if (Pc_DescontoItem.Value > pc_max_desc)
                    {
                        MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_grupo = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo;
                            fLogin.Cd_empresa = CD_Empresa;
                            fLogin.Pc_desc = Pc_DescontoItem.Value;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                            {
                                VL_Desconto.Value = decimal.Zero;
                                Pc_DescontoItem.Value = decimal.Zero;
                                Pc_DescontoItem.Focus();
                                return false;
                            }
                            else
                            {
                                LoginDesconto = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                    else return true;
                }
                //Desconto por vendedor e empresa
                if (Pc_DescontoItem.Value > lDesc[0].Pc_max_desconto)
                {
                    MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                    {
                        fLogin.Cd_empresa = CD_Empresa;
                        fLogin.Pc_desc = Pc_DescontoItem.Value;
                        if (fLogin.ShowDialog() != DialogResult.OK)
                        {
                            VL_Desconto.Value = decimal.Zero;
                            Pc_DescontoItem.Value = decimal.Zero;
                            Pc_DescontoItem.Focus();
                            return false;
                        }
                        else
                        {
                            LoginDesconto = fLogin.Logindesconto;
                            return true;
                        }
                    }
                }
                else return true;
            }
            else return true;
        }

        private void BuscarFichaTecItem()
        {
            if (St_composto)
            {
                Height = 600;
                Quantidade.Value = 0;
                try
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec =
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.MontarFichaTecOrcItem(CD_Produto.Text,
                                                                                                      CD_Empresa,
                                                                                                      CD_TabelaPreco,
                                                                                                      Quantidade.Value,
                                                                                                      null);
                    ConsultaPreco();
                    if (Vl_Unitario.Enabled && St_somarPrecoFicha)
                        Vl_Unitario.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal);
                    vl_custo.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_custo * p.Quantidade);
                    tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    bsItensOrcamento.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else if (St_industrializado)
            {
                Height = 600;
                Quantidade.Value = 0;
                try
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec =
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.MontarFichaTecOrcItemProducao(CD_Produto.Text,
                                                                                                              CD_Empresa,
                                                                                                              CD_TabelaPreco,
                                                                                                              Quantidade.Value,
                                                                                                              null);
                    ConsultaPreco();
                    if (Vl_Unitario.Enabled && St_somarPrecoFicha)
                        Vl_Unitario.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal);
                    vl_custo.Value = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_custo * p.Quantidade);
                    tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    bsItensOrcamento.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                Height = 320;
                if (bsItensOrcamento.Current != null)
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Clear();
                    bsItensOrcamento.ResetCurrentItem();
                }
            }
        }
                
        private void TFItensOrcamento_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (st_alterar)
            {
                bsItensOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item() { ritem };
                CD_Produto.Enabled = string.IsNullOrEmpty(ritem.Cd_produto);
                ConsultaPreco();
                St_composto = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + ritem.Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(e.st_composto, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null;
                if(!CD_Produto.Focus())
                    Quantidade.Focus();
                if (ritem.lFichaTec.Count > 0)
                {
                    Height = 600;
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.ForEach(p =>
                            {
                                p.Vl_unitario =
                                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, p.Cd_item, CD_TabelaPreco, null);

                            });
                    tot_itensFichaTec.Text = (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Sum(p => p.Vl_Subtotal).
                               ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
                if(ritem.vl_comprimento.Equals(decimal.Zero))
                    tableLayoutPanel2.RowStyles[1].Height = 0;
                St_somarPrecoFicha = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, ritem.Cd_produto, CD_TabelaPreco, null).Equals(decimal.Zero);
            }
            else
            {
                bsItensOrcamento.AddNew();
                Pc_DescontoItem.Value = Pc_desconto;
                tableLayoutPanel2.RowStyles[1].Height = 0;
                St_somarPrecoFicha = true;
            }
            St_obrigaCusto = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_OBRIGAR_CUSTO_UNIT_ORC",
                                                                         null).Equals(true);
            vl_custo.Visible = St_obrigaCusto;
            lbCusto.Visible = St_obrigaCusto;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            lista.Clear();
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
               "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                             "(exists(select 1 from tb_est_codbarra x " +
                             "         where x.cd_produto = a.cd_produto " +
                             "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                             "isnull(a.st_registro, 'A')|<>|'C'";
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, SG_Unidade_Estoque },
                                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                DS_Produto.Enabled = false;
                ConsultaPreco();
            }
            else
            {
                DS_Produto.Enabled = true;
                DS_Produto.Focus();
            }
            if (linha != null)
            {
                St_composto = linha["st_composto"].ToString().ToUpper().Equals("S");
                St_industrializado = linha["st_industrializado"].ToString().ToUpper().Equals("S");
                Ds_fichaTec = linha["DS_TecnicaAssistencia"].ToString();
                st_servico.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                tp_unidade = linha["tp_unidade"].ToString().Trim().ToUpper();
                calcularunidade();
               BuscarFichaTecItem();
            }
            // se tiver cubo ou quadrado foca na largura
            if(tp_unidade.Equals("0") || tp_unidade.Equals("1"))
                vl_comprimento.Focus();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFItensOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
                NovoProduto();
            else if (e.KeyCode.Equals(Keys.F9))
                AlterarDs_Tec();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItemFicha();
        }

        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            if ((bsItensOrcamento.Current != null) && St_composto)
                try
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec =
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.MontarFichaTecOrcItem(CD_Produto.Text,
                                                                                                      CD_Empresa,
                                                                                                      CD_TabelaPreco,
                                                                                                      Quantidade.Value,
                                                                                                      null);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void bb_inserirficha_Click(object sender, EventArgs e)
        {
            InserirItemFicha();
        }

        private void bb_alterarficha_Click(object sender, EventArgs e)
        {
            AlterarItemFicha();
        }

        private void bb_excluirficha_Click(object sender, EventArgs e)
        {
            ExcluirItemFicha();
        }

        private void CD_Produto_TextChanged(object sender, EventArgs e)
        {
            DS_Produto.Enabled = string.IsNullOrEmpty(CD_Produto.Text);
            SG_Unidade_Estoque.Enabled = string.IsNullOrEmpty(CD_Produto.Text);
            st_servico.Enabled = string.IsNullOrEmpty(CD_Produto.Text);
        }
        private void calculaquantidade()
        {
            qtd_restante.Value = Quantidade.Value - qtd_total.Value;
        }
        private void Quantidade_Leave(object sender, EventArgs e)
        {
            CalcularDescEspecial();
            calculaquantidade();
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                BuscarProduto();
                Quantidade.Focus();
            }
        }

        private void BB_NovoProduto_Click(object sender, EventArgs e)
        {
            NovoProduto();
        }

        private void bb_alterarDs_Tec_Click(object sender, EventArgs e)
        {
            AlterarDs_Tec();
        }

        private void Pc_DescontoItem_Leave(object sender, EventArgs e)
        {
            ValidarDescontos();
        }

        private void VL_Desconto_Leave(object sender, EventArgs e)
        {
            if (bsItensOrcamento.Current != null)
            {
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_desconto = VL_Desconto.Value;
                bsItensOrcamento.ResetCurrentItem();
                ValidarDescontos();
            }
        }

        private void Pc_DescontoItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ValidarDescontos();
        }

        private void VL_Desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ValidarDescontos();
        }
        private void vl_altura_ValueChanged(object sender, EventArgs e)
        {
            calcularunidade();
        }

        private void vl_altura_Leave(object sender, EventArgs e)
        {
            calcularunidade();
        }

        private void vl_largura_Leave(object sender, EventArgs e)
        {
            calcularunidade();
        }

        private void vl_comprimento_Leave(object sender, EventArgs e)
        {
            calcularunidade();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(qtd.Value != decimal.Zero && vl_comprimento.Value != decimal.Zero && vl_largura.Value != decimal.Zero && tot_r.Value != decimal.Zero)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("- " + qtd.Value + " unidades de largura:" +vl_largura.Value.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) 
                    + " e comprimento:" + vl_comprimento.Value.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) 
                    + " totalizando em "+tot_r.Value.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "M²");
                
                if (Quantidade.Value < (tot_r.Value + qtd_total.Value))
                {
                    lista.Remove(lista.Count);
                    MessageBox.Show("Quantidade total não pode ser maior que o total."); 
                    return;
                }
                decimal larg = decimal.Zero;

                lista.Add(vl_largura.Value);
                lista.ForEach(p =>
                {
                    larg += p;
                });


                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_comprimento += vl_comprimento.Value * qtd.Value;
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_largura = decimal.Divide(larg, lista.Count);
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_observacao += str.ToString();
                qtd_total.Value +=   tot_r.Value;
                calculaquantidade();
                bsItensOrcamento.ResetCurrentItem();
            }
        }

        private void qtd_Leave(object sender, EventArgs e)
        {
            calcularunidade();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_observacao = string.Empty;
            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_comprimento = decimal.Zero;
            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).vl_largura = decimal.Zero;
            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade = decimal.Zero;
            lista.Clear();
            bsItensOrcamento.ResetCurrentItem();
        }

        private void qtd_total_Leave(object sender, EventArgs e)
        {
            calculaquantidade();
        }

        private void Vl_Unitario_ValueChanged(object sender, EventArgs e)
        {
            if (!St_somarPrecoFicha)
                St_somarPrecoFicha = Vl_Unitario.Value == decimal.Zero;
        }
    }
}
