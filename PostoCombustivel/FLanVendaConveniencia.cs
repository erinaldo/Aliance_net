using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace PostoCombustivel
{
    public partial class TFLanVendaConveniencia : Form
    {
        private int Qtd_itensvenda;
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;

        public string Cd_empConv
        { get; set; }
        public string Login
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_Sessao rSessao
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        public TFLanVendaConveniencia()
        {
            InitializeComponent();
            rProg = null;
        }

        private void afterNovo()
        {
            tot_desconto.Value = decimal.Zero;
            tot_venda.Value = decimal.Zero;
            tot_subtotal.Value = decimal.Zero;
            HabilitarCampos(true);
            bsVendaRapida.Clear();
            bsVendaRapida.AddNew();
            //Buscar empresa
            BuscarEmpresa();
            if (lCfg == null)
            {
                MessageBox.Show("Não existe configuração para realizar venda conveniência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsVendaRapida.Clear();
                Close();
                return;
            }
            //Buscar vendedor
            BuscarVendedor();
            CD_Clifor.Text = lCfg[0].Cd_clifor;
            NM_Clifor.Text = lCfg[0].Nm_clifor;
            CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
            NM_TabelaPreco.Text = lCfg[0].Ds_tabelapreco;
            (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Id_pdv = rSessao.Id_pdv;
            (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Id_sessao = rSessao.Id_sessao;
            cd_produto.Focus();
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

        private void HabilitarCampos(bool Status)
        {
            CD_CompVend.Enabled = Status;
            BB_CompVend.Enabled = Status;
            CD_Clifor.Enabled = Status;
            BB_Clifor.Enabled = Status;
            NM_Clifor.Enabled = Status;
            cd_produto.Enabled = Status;
        }

        private void BuscarVendedor()
        {
            CamadaDados.Financeiro.Cadastros.TList_CadClifor lVend =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.BuscaVendedor(string.Empty,
                                                                               Login,
                                                                               null);
            if (lVend.Count > 0)
            {
                CD_CompVend.Text = lVend[0].Cd_clifor;
                NM_CompVend.Text = lVend[0].Nm_clifor;
            }
        }

        public void BuscarEmpresa()
        {
            CamadaDados.Diversos.TList_CadEmpresa lEmp =
                new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and ((x.login = '" + Login.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "       where y.logingrp = x.login and y.loginusr = '" + Login.Trim() + "'))))"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cfgcupomfiscal x " +
                                    "where x.cd_empresa = a.cd_empresa)"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "not exists",
                        vVL_Busca = "(select 1 from TB_PDC_CfgPosto x "+
                                    "where x.cd_empresa = a.cd_empresa)"
                    }
                }, 1, string.Empty);
            if (lEmp.Count > 0)
            {
                CD_Empresa.Text = lEmp[0].Cd_empresa;
                NM_Empresa.Text = lEmp[0].Nm_empresa;
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count > 0)
                    cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
            }
        }

        private decimal BuscarSaldoLocal(string Cd_produto)
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(Cd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text,
                                                                       Cd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void BuscarPromocao()
        {
            if (bsItens.Current != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo,
                                                                                                rProg,
                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) >= rPro.Qtd_minimavenda)
                        {
                            (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    //Calcular desconto
                                    p.Vl_desconto = p.Vl_subtotal * (rPro.Vl_promocao / 100);
                                    p.Pc_desconto = rPro.Vl_promocao;
                                }
                                else
                                {
                                    p.Vl_desconto = rPro.Vl_promocao * p.Quantidade;
                                    p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                }
                            });
                            bsVendaRapida.ResetCurrentItem();
                        }
                        else
                        {
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = decimal.Zero;
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = decimal.Zero;
                            bsItens.ResetCurrentItem();
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            //Calcular desconto
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto =
                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal * (rPro.Vl_promocao / 100);
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = rPro.Vl_promocao;
                            bsItens.ResetCurrentItem();
                        }
                        else
                        {
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = rPro.Vl_promocao * (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade;
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                            bsItens.ResetCurrentItem();
                        }
                    }
            }
        }

        private decimal CalcularDescEspecial(decimal Qtde,
                                             decimal Vl_unit)
        {
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.
                        Where(p => p.Cd_produto.Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Qtde * rProg.Valor;
                        else
                            return (Qtde * Vl_unit) * rProg.Valor / 100;
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Qtde * rProg.Valor;
                    else
                        return (Qtde * Vl_unit) * rProg.Valor / 100;
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private decimal ConsultaPreco(string pCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(pCd_produto)))
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                         CD_Clifor.Text,
                                                                                                         pCd_produto,
                                                                                                         CD_TabelaPreco.Text,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa.Text,
                                                                                                    pCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa.Text,
                                                                                                pCd_produto,
                                                                                                CD_TabelaPreco.Text,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void CalcularDesconto(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_desconto.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                if (pc_desconto.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = pc_desconto.Value;
                if (St_percentual)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto =
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal *
                        ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto / 100);
                else
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto =
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 / (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                bsItens.ResetCurrentItem();
                TotalizarVenda();
            }
        }

        private void TotalizarVenda()
        {
            if (bsVendaRapida.Current != null)
            {
                tot_subtotal.Value = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Sum(p => p.Vl_desconto);
                tot_venda.Value = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
            }
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
                    if (lCfg[0].St_movestoquebool)
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto))
                            {
                                decimal saldo = BuscarSaldoLocal(lProduto[0].CD_Produto);
                                if (saldo < 1)
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
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
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
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
                    decimal vl_unit = ConsultaPreco(lProduto[0].CD_Produto);
                    if (vl_unit <= decimal.Zero)
                        using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                        {
                            fValor.Casas_decimais = 2;
                            fValor.Ds_label = "Valor Unitario";
                            if (fValor.ShowDialog() == DialogResult.OK)
                                vl_unit = fValor.Quantidade;
                        }
                    //Buscar preco venda produto
                    if (vl_unit > decimal.Zero)
                    {
                        string Cd_vendedor = string.Empty;
                        if(string.IsNullOrEmpty(CD_CompVend.Text))
                            //Verificar se o produto e comissionado
                            if (lProduto[0].Pc_Comissao > decimal.Zero)
                            {
                                //Buscar Vendedor
                                string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                                                  "a.cd_clifor|Cd. Vendedor|80";
                                string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                                                "isnull(a.st_funcativo, 'N')|=|'S';" +
                                                "|exists|(select 1 from tb_fat_vendedor_x_empresa x " +
                                                "           where x.cd_vendedor = a.cd_clifor " +
                                                "           and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "' " +
                                                "           and x.tp_comissao = 'P')";
                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                                   vParam);
                                if (linha != null)
                                    Cd_vendedor = linha["cd_clifor"].ToString();
                            }
                        //Cria novo item
                        bsItens.AddNew();
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_vendedor = Cd_vendedor;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = lProduto[0].CD_Produto;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = lProduto[0].DS_Produto;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = lProduto[0].CD_Grupo;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = lProduto[0].CD_CondFiscal_Produto;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = lProduto[0].CD_Unidade;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = lProduto[0].Sigla_unidade;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = vl_unit;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Quantidade.Value * vl_unit;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(Quantidade.Value, vl_unit);
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                        bsItens.ResetCurrentItem();
                        //Buscar Promocao de Venda
                        BuscarPromocao();
                        Quantidade.Value = 1;
                        bsItens.ResetCurrentItem();
                        TotalizarVenda();
                        Qtd_itensvenda++;
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

        private void CalcularSubTotal()
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal =
                    Math.Round((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade *
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario, 2);
                bsItens.ResetCurrentItem();
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo,
                                                                                                null,
                                                                                                decimal.Zero,
                                                                                                null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) - 
                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                                 CD_Clifor.Text,
                                                                                                                 (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                                 CD_TabelaPreco.Text,
                                                                                                                 null);
                                (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto.Trim())).ToList().ForEach(p =>
                                {
                                    if (rProgAux != null)
                                    {
                                        if (rProgAux.Valor > decimal.Zero)
                                        {
                                            if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                                            {
                                                p.Vl_desconto = p.Quantidade * rProgAux.Valor;
                                                p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                            }
                                            else
                                            {
                                                p.Vl_desconto = p.Vl_subtotal * rProgAux.Valor / 100;
                                                p.Pc_desconto = rProgAux.Valor;
                                            }
                                        }
                                        else
                                        {
                                            p.Vl_desconto = decimal.Zero;
                                            p.Pc_desconto = decimal.Zero;
                                        }
                                    }
                                    else
                                    {
                                        p.Vl_desconto = decimal.Zero;
                                        p.Pc_desconto = decimal.Zero;
                                    }
                                });
                                bsVendaRapida.ResetCurrentItem();
                            }
                    bsItens.RemoveCurrent();
                    TotalizarVenda();
                    Qtd_itensvenda--;
                }
            }
            else
                MessageBox.Show("Não existe item selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CancelarVenda()
        {
            if (MessageBox.Show("Confirma cancelamento da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bsItens.Clear();
                bsItens.ResetBindings(true);
                Qtd_itensvenda = 0;
            }
        }

        private void FinalizarVenda(string Tp_portador)
        {
            if (bsVendaRapida.Current != null)
            {
                if (pDados.validarCampoObrigatorio())
                {
                    if (string.IsNullOrEmpty(CD_Empresa.Text))
                    {
                        MessageBox.Show("Não é permitido gravar venda rapida sem EMPRESA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Count < 1)
                    {
                        MessageBox.Show("Não é permitido gravar venda rapida sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Buscar caixa aberto do PDV
                    object obj_caixa = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = " isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                            "where x.login = a.login " +
                                                            "and x.id_pdv = " + rSessao.Id_pdvstr + " " +
                                                            "and x.id_sessao = " + rSessao.Id_sessaostr + ")"
                                            }
                                        }, "a.id_caixa");
                    if (obj_caixa == null)
                        throw new Exception("Não existe caixa aberto para o Login " + rSessao.Login);
                    CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida;
                    if (Tp_portador.Trim().ToUpper().Equals("D"))//dinheiro
                    {
                        //Buscar portador dinheiro
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lDinheiro =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_tituloterceiro, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_cartaocredito",
                                    vOperador = "=",
                                    vVL_Busca = "1"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lDinheiro.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe portador dinheiro configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (PDV.TFFecharVendaDinheiro fFechar = new PDV.TFFecharVendaDinheiro())
                        {
                            fFechar.pCd_empresa = rVenda.Cd_empresa;
                            fFechar.pCd_operador = rVenda.Cd_vend;
                            fFechar.rCupom = rVenda;
                            fFechar.pVl_receber = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                            if (fFechar.ShowDialog() == DialogResult.OK)
                            {
                                //Ratear desconto 
                                if (fFechar.pVl_desconto > decimal.Zero)
                                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.RatearDescontoVRapida(rVenda,
                                                                                                        fFechar.pVl_desconto,
                                                                                                        decimal.Zero);
                                lDinheiro[0].Vl_pagtoPDV = fFechar.pVl_dinheiro;
                                //Troco
                                if (fFechar.pVl_troco > decimal.Zero)
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = rVenda.Cd_empresa;
                                        fTroco.Id_caixaPDV = obj_caixa.ToString();
                                        fTroco.Vl_troco = fFechar.pVl_troco;
                                        fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                        fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(login.Text, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                            {
                                                lDinheiro[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                            //buscar endereco clifor
                                                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + rVenda.Cd_clifor + "'"
                                                                                }
                                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                rVenda.Cd_endereco = obj.ToString();
                                                            lDinheiro[0].St_gerarCredito = true;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                                else
                                                    using (InputBox inp = new InputBox())
                                                    {
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + rVenda.Cd_clifor + "'"
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lDinheiro[0].Ds_mensagemCredito = inp.ShowDialog();
                                                        lDinheiro[0].St_gerarCredito = true;
                                                    }
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                fTroco.lChRepasse.ForEach(p => lDinheiro[0].lChTroco.Add(p));
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                            if (fTroco.lChTroco != null)
                                                fTroco.lChTroco.ForEach(p => lDinheiro[0].lChTroco.Add(p));
                                            if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                lDinheiro[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                            else lDinheiro[0].Vl_trocoPDV = decimal.Zero;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        rVenda.lPortador = lDinheiro;
                    }
                    else if (Tp_portador.Trim().ToUpper().Equals("C"))//Cartao Credito/Debito
                    {
                        //Buscar portador cartao
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lCartao =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_cartaocredito",
                                    vOperador = "=",
                                    vVL_Busca = "0"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lCartao.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe portador cartão crédito/débito configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                        {
                            fCartao.pCd_empresa = rVenda.Cd_empresa;
                            fCartao.Vl_saldofaturar = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                            fCartao.St_validarSaldo = true;
                            if (fCartao.ShowDialog() == DialogResult.OK)
                            {
                                fCartao.lFatura.ForEach(p => lCartao[0].lFatura.Add(p));
                                lCartao[0].Vl_pagtoPDV = fCartao.lFatura.Sum(p => p.Vl_fatura);
                                lCartao[0].Vl_trocoPDV = lCartao[0].Vl_pagtoPDV - fCartao.Vl_saldofaturar;
                                //Troco
                                if (lCartao[0].Vl_trocoPDV > decimal.Zero)
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = rVenda.Cd_empresa;
                                        fTroco.Id_caixaPDV = obj_caixa.ToString();
                                        fTroco.Vl_troco = lCartao[0].Vl_trocoPDV;
                                        fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                        fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(login.Text, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                            {
                                                lCartao[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                            //buscar endereco clifor
                                                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = rVenda.Cd_clifor
                                                                                }
                                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                rVenda.Cd_endereco = obj.ToString();
                                                            lCartao[0].St_gerarCredito = true;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                                else
                                                    using (InputBox inp = new InputBox())
                                                    {
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + rVenda.Cd_clifor + "'"
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lCartao[0].Ds_mensagemCredito = inp.ShowDialog();
                                                        lCartao[0].St_gerarCredito = true;
                                                    }
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                fTroco.lChRepasse.ForEach(p => lCartao[0].lChTroco.Add(p));
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                            if (fTroco.lChTroco != null)
                                                fTroco.lChTroco.ForEach(p => lCartao[0].lChTroco.Add(p));
                                            if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                lCartao[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                            else lCartao[0].Vl_trocoPDV = decimal.Zero;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        rVenda.lPortador = lCartao;
                    }
                    else if (Tp_portador.Trim().ToUpper().Equals("H"))//Cheque
                    {
                        //Buscar portador cheque
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lCheque =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lCheque.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe portador cheque configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Verificar credito
                        CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                            new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                        if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rVenda.Cd_clifor,
                                                                                                          rVenda.lItem.Sum(p => p.Vl_subtotalliquido),
                                                                                                          false,
                                                                                                          ref rDados,
                                                                                                          null))
                            using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                            {
                                fBloq.rDados = rDados;
                                fBloq.Vl_fatura = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                                fBloq.ShowDialog();
                                if (!fBloq.St_desbloqueado)
                                    throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                            }
                        using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                        {
                            fListaCheques.Tp_mov = "R";
                            fListaCheques.Cd_empresa = rVenda.Cd_empresa;
                            //fListaCheques.St_pdv = true;
                            fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                            fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                            fListaCheques.Cd_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Cd_clifor;
                            fListaCheques.Cd_historico = lCfg[0].Cd_historicocaixa;
                            fListaCheques.Ds_historico = lCfg[0].Ds_historicocaixa;
                            fListaCheques.Cd_portador = lCheque[0].Cd_portador;
                            fListaCheques.Ds_portador = lCheque[0].Ds_portador;
                            fListaCheques.Nm_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Nm_clifor;
                            fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            fListaCheques.Vl_totaltitulo = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                            if (fListaCheques.ShowDialog() == DialogResult.OK)
                            {
                                lCheque[0].lCheque = fListaCheques.lCheques;
                                lCheque[0].Vl_pagtoPDV = fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                                lCheque[0].Vl_trocoPDV = lCheque[0].Vl_pagtoPDV - fListaCheques.Vl_totaltitulo;
                                //Troco
                                if (lCheque[0].Vl_trocoPDV > decimal.Zero)
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = rVenda.Cd_empresa;
                                        fTroco.Id_caixaPDV = obj_caixa.ToString();
                                        fTroco.Vl_troco = lCheque[0].Vl_trocoPDV;
                                        fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                        fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(login.Text, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                            {
                                                lCheque[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                            //buscar endereco clifor
                                                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + rVenda.Cd_clifor + "'"
                                                                                }
                                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                rVenda.Cd_endereco = obj.ToString();
                                                            lCheque[0].St_gerarCredito = true;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                                else
                                                    using (InputBox inp = new InputBox())
                                                    {
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = rVenda.Cd_clifor
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lCheque[0].Ds_mensagemCredito = inp.ShowDialog();
                                                        lCheque[0].St_gerarCredito = true;
                                                    }
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                fTroco.lChRepasse.ForEach(p => lCheque[0].lChTroco.Add(p));
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                            rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                            if (fTroco.lChTroco != null)
                                                fTroco.lChTroco.ForEach(p => lCheque[0].lChTroco.Add(p));
                                            if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                lCheque[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                            else lCheque[0].Vl_trocoPDV = decimal.Zero;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                rVenda.lPortador = lCheque;
                            }
                            else
                            {
                                MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada! ");
                                return;
                            }
                        }
                    }
                    else if (Tp_portador.Trim().ToUpper().Equals("N"))//Duplicata
                    {
                        //Buscar portador duplicata
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lDup =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lDup.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe portador duplicata configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                        {
                            MessageBox.Show("Não é permitido venda a prazo sem identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Abrir tela Duplicata
                        using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                        {
                            fDuplicata.vCd_empresa = rVenda.Cd_empresa;
                            fDuplicata.vNm_empresa = rVenda.Nm_empresa;
                            fDuplicata.vCd_clifor = rVenda.Cd_clifor;
                            fDuplicata.vNm_clifor = rVenda.Nm_clifor;
                            //Buscar condicao de pagamento
                            CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null);
                            if (lCond.Count > 0)
                                fDuplicata.vCd_condpgto = lCond[0].Cd_condpgto;

                            fDuplicata.vSt_ecf = true;
                            fDuplicata.vId_caixa = obj_caixa.ToString();
                            //Buscar endereco clifor
                            if (!string.IsNullOrEmpty(rVenda.Cd_clifor))
                            {
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rVenda.Cd_clifor,
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
                                                                                              1,
                                                                                              null);
                                if (lEnd.Count > 0)
                                {
                                    fDuplicata.vCd_endereco = lEnd[0].Cd_endereco;
                                    fDuplicata.vDs_endereco = lEnd[0].Ds_endereco;
                                }
                            }
                            fDuplicata.vCd_historico = lCfg[0].Cd_historico;
                            fDuplicata.vDs_historico = lCfg[0].Ds_historico;
                            fDuplicata.vTp_duplicata = lCfg[0].Tp_duplicata;
                            fDuplicata.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                            fDuplicata.vTp_mov = "R";
                            fDuplicata.vTp_docto = lCfg[0].Tp_doctostr;
                            fDuplicata.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                            //Buscar Moeda Padrao
                            CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                                CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(rVenda.Cd_empresa, null);
                            if (tabela != null)
                                if (tabela.Count > 0)
                                {
                                    fDuplicata.vCd_moeda = tabela[0].Cd_moeda;
                                    fDuplicata.vDs_moeda = tabela[0].Ds_moeda_singular;
                                    fDuplicata.vSigla_moeda = tabela[0].Sigla;
                                    fDuplicata.vCd_moeda_padrao = tabela[0].Cd_moeda;
                                    fDuplicata.vDs_moeda_padrao = tabela[0].Ds_moeda_singular;
                                    fDuplicata.vSigla_moeda_padrao = tabela[0].Sigla;
                                }

                            fDuplicata.vNr_docto = "PDC123";//pNr_cupom; //Numero Cupom
                            fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                            fDuplicata.vVl_documento = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                                if (fDuplicata.dsDuplicata.Current != null)
                                {
                                    lDup[0].lDup.Add((fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata));
                                    lDup[0].Vl_pagtoPDV = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento_padrao;
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                return;
                            }
                        }
                        rVenda.lPortador = lDup;
                    }
                    else
                    {
                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                        {
                            rVenda.lPortador = new CamadaDados.Financeiro.Cadastros.TList_CadPortador();
                            fFechar.rCupom = rVenda;
                            fFechar.Id_caixaPDV = obj_caixa.ToString();
                            fFechar.pCd_empresa = CD_Empresa.Text;
                            fFechar.pCd_clifor = CD_Clifor.Text.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : CD_Clifor.Text;
                            fFechar.pNm_clifor = CD_Clifor.Text.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : NM_Clifor.Text;
                            fFechar.pCd_operador = CD_CompVend.Text;
                            fFechar.rCfg = lCfg[0];
                            fFechar.pVl_receber = tot_venda.Value;
                            fFechar.LoginPDV = login.Text;
                            if (fFechar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                if (fFechar.lPortador != null)
                                    rVenda.lPortador = fFechar.lPortador;
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    ThreadEspera tEspera = new ThreadEspera("Inicio processo gravar venda rapida.");
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda,
                                                                                        null,
                                                                                        null,
                                                                                        null);
                        Qtd_itensvenda = 0;
                        //Buscar venda Mesa em Aberto
                        bsVendaMesaConv.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                                             rVenda.Cd_empresa,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             "'A'",
                                                                                                             true,
                                                                                                             null);
                        using (TFGerarDocFiscal fDoc = new TFGerarDocFiscal())
                        {
                            if (fDoc.ShowDialog() == DialogResult.OK)
                                if (fDoc.St_nfe)
                                {
                                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                                    try
                                    {
                                        string pCd_clifor = rVenda.Cd_clifor;
                                        if (string.IsNullOrEmpty(pCd_clifor))
                                        {
                                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                            if (linha != null)
                                                pCd_clifor = linha["cd_clifor"].ToString();
                                        }

                                        if (!string.IsNullOrEmpty(pCd_clifor))
                                        {
                                            //Buscar endereco
                                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
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
                                            string pCd_endereco = string.Empty;
                                            if (lEnd.Count.Equals(1))
                                                pCd_endereco = lEnd[0].Cd_endereco;
                                            else
                                            {
                                                string vColunas = "a.ds_endereco|Endereço|200;" +
                                                                  "a.cd_endereco|Codigo|80;" +
                                                                  "a.bairro|Bairro|80;" +
                                                                  "a.insc_estadual|Insc. Estadual|80";
                                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
                                                if (linha != null)
                                                    pCd_endereco = linha["cd_endereco"].ToString();
                                            }
                                            if (string.IsNullOrEmpty(pCd_endereco))
                                            {
                                                MessageBox.Show("Obrigatorio informar endereço cliente NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(pCd_clifor,
                                                                                                          pCd_endereco,
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          lCfg[0],
                                                                                                          rVenda.lItem,
                                                                                                          ref rPedProduto,
                                                                                                          ref rPedServico);
                                            if (rPedProduto != null)
                                            {
                                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                                //Buscar pedido
                                                rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                                //Buscar itens pedido
                                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                                //Se o CMI do pedido gerar financeiro
                                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "in",
                                                            vVL_Busca = "('A', 'P')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                                //Gerar Nota Fiscal
                                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                                                //Vincular financeiro a Nota Fiscal
                                                rFat.lParcAgrupar = lParcVinculado;
                                                //Gravar Nota Fiscal
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                                    null);
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            if (rPedServico != null)
                                            {
                                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico, null);
                                                //Buscar pedido
                                                rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                                                //Buscar itens pedido
                                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                                                //Se o CMI do pedido gerar financeiro
                                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "in",
                                                            vVL_Busca = "('A', 'P')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                                //Gerar Nota Fiscal
                                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedServico, true, lParcVinculado.Sum(p => p.Vl_atual));
                                                //Vincular financeiro a Nota Fiscal
                                                rFat.lParcAgrupar = lParcVinculado;
                                                //Gravar Nota Fiscal
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                                //Buscar CfgNfe para a empresa
                                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          null);
                                                if (lCfgNfe.Count > 0)
                                                {
                                                    NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0],
                                                                                   CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 rFat.Nr_lanctofiscalstr,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 decimal.Zero,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 false,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 decimal.Zero,
                                                                                                                                                 decimal.Zero,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 false,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 string.Empty,
                                                                                                                                                 1,
                                                                                                                                                 string.Empty,
                                                                                                                                                 null));
                                                    MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        else
                                            MessageBox.Show("Obrigatorio informar cliente da NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (rPedProduto != null)
                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedProduto, null);
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    if (new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_pdv",
                                                vOperador = "=",
                                                vVL_Busca = rSessao.Id_pdvstr
                                            }
                                        }, "1") != null)
                                    {
                                        try
                                        {
                                            //Processar cupom fiscal
                                            PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                            dados.lItens = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem;
                                            dados.rSessao = rSessao;
                                            dados.Cd_clifor = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_clifor;
                                            dados.Nm_clifor = (bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Nm_clifor;
                                            dados.CpfCgc = string.Empty;
                                            dados.Endereco = string.Empty;
                                            dados.Mensagem = string.Empty;
                                            dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                            dados.St_vendacombustivel = false;
                                            dados.St_cupomavulso = true;
                                            dados.St_agruparProduto = false;

                                            PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                            CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                            if (rNFCe != null)
                                                if (!rNFCe.St_contingencia)
                                                {
                                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                    {
                                                        rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                  null);
                                                        fGerNfe.rNFCe = rNFCe;
                                                        fGerNfe.ShowDialog();
                                                    }
                                                    if (dados.St_faturardireto)
                                                        if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.id_cupom",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rNFCe.Id_nfcestr
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.status",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'100'"
                                                                }
                                                            }, "1") != null)
                                                            ProcessarCFVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                                }
                                                else
                                                {
                                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                    BindingSource dts = new BindingSource();
                                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                                    Rel.DTS_Relatorio = dts;// bsItens;
                                                    //DTS Cupom
                                                    BindingSource bsNFCe = new BindingSource();
                                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                                      string.Empty,
                                                                                                                      rNFCe.Cd_empresa,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      false,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      1,
                                                                                                                      null);
                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                           (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                           string.Empty,
                                                                                                           null);
                                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                                    //Buscar Empresa
                                                    BindingSource bsEmpresa = new BindingSource();
                                                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty,
                                                                                                                        null);
                                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                    //Forma Pagamento
                                                    BindingSource bsPagto = new BindingSource();
                                                    List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                                                    new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.id_vendarapida = a.id_cupom " +
                                                                            "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                            }
                                                        }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                            (aux, venda) =>
                                                                                new
                                                                                {
                                                                                    tp_portador = aux,
                                                                                    Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                    Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                    Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                                {
                                                                                    Tp_portador = x.tp_portador,
                                                                                    Vl_recebido = x.Vl_recebido,
                                                                                    Vl_troco_ch = x.Vl_troco_ch,
                                                                                    Vl_troco_dh = x.Vl_troco_dh
                                                                                }));
                                                    CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                            new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                                "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                                "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                }
                                                            }, 1, string.Empty);
                                                    if (lDup.Count > 0)
                                                        lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                        {
                                                            Tp_portador = "05",
                                                            Vl_recebido = lDup[0].Vl_documento
                                                        });
                                                    bsPagto.DataSource = lPagto;
                                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                                    //Parametros
                                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                                    object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_lote = a.id_lote " +
                                                                                        "and x.status = '100')"
                                                                        }
                                                                    }, "a.tp_ambiente");
                                                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                                    string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                          (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                          null);
                                                    if(!string.IsNullOrEmpty(dadoscf))
                                                    {
                                                        string[] linhas = dadoscf.Split(new char[]{':'});
                                                        string placa = string.Empty;
                                                        string km = string.Empty;
                                                        string frota = string.Empty;
                                                        string requisicao = string.Empty;
                                                        string nm_motorista = string.Empty;
                                                        string cpf_motorista = string.Empty;
                                                        string media = string.Empty;
                                                        string virg = string.Empty;
                                                        foreach(string s in linhas)
                                                        {
                                                            string[] colunas = s.Split(new char[]{'/'});
                                                            placa += virg + colunas[0];
                                                            km += virg + colunas[1];
                                                            frota += virg + colunas[2];
                                                            requisicao += virg + colunas[3];
                                                            nm_motorista += virg + colunas[4];
                                                            cpf_motorista += virg + colunas[5];
                                                            media += virg + colunas[6];
                                                            virg = ",";
                                                        }
                                                        if(!string.IsNullOrEmpty(placa))
                                                            Rel.Parametros_Relatorio.Add("PLACA", placa);
                                                        if (!string.IsNullOrEmpty(km))
                                                            Rel.Parametros_Relatorio.Add("KM", km);
                                                        if (!string.IsNullOrEmpty(media))
                                                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                        if (!string.IsNullOrEmpty(frota))
                                                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                        if (!string.IsNullOrEmpty(requisicao))
                                                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                        if (!string.IsNullOrEmpty(nm_motorista))
                                                            Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                        if (!string.IsNullOrEmpty(cpf_motorista))
                                                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                                    }
                                                    Rel.Nome_Relatorio = "DANFE_NFCE";
                                                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                                    Rel.Modulo = "FAT";
                                                    Rel.Ident = "DANFE_NFCE";
                                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                                    {
                                                        BindingSource bsItens = new BindingSource();
                                                        bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                        Rel.DTS_Relatorio = bsItens;
                                                    }
                                                    if (rNFCe.Id_contingencia.HasValue)
                                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                        else
                                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                                    //Verificar se existe Impressora padrão para o PDV
                                                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_terminal",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                }
                                                            }, "a.impressorapadrao");
                                                    string print = obj == null ? string.Empty : obj.ToString();
                                                    if (string.IsNullOrEmpty(print))
                                                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                        {
                                                            if (fLista.ShowDialog() == DialogResult.OK)
                                                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                    print = fLista.Impressora;

                                                        }
                                                    //Imprimir
                                                    if (!string.IsNullOrEmpty(print))
                                                    {
                                                        Rel.ImprimiGraficoReduzida(print,
                                                                                   true,
                                                                                   false,
                                                                                   null,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   1);
                                                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                            Rel.ImprimiGraficoReduzida(print,
                                                                                       true,
                                                                                       false,
                                                                                       null,
                                                                                       string.Empty,
                                                                                       string.Empty,
										                                               1);

                                                    }
                                                }
                                            return;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                        }
                        //Imprimir Boleto
                        if (rVenda.lPortador.Exists(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0))
                        {
                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                            CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(rVenda.lPortador.Find(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0).lDup[0].Cd_empresa,
                                                                                rVenda.lPortador.Find(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0).lDup[0].Nr_lancto,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
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
                                                                                false,
                                                                                0,
                                                                                null);
                            if (lBloqueto.Count > 0)
                                //Chamar tela de impressao para o bloqueto
                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = rVenda.lPortador.Find(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0).lDup[0].Cd_clifor;
                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + rVenda.lPortador.Find(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0).lDup[0].Nr_docto;
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                          lBloqueto,
                                                                                          fImp.pSt_imprimir,
                                                                                          fImp.pSt_visualizar,
                                                                                          fImp.pSt_enviaremail,
                                                                                          fImp.pSt_exportPdf,
                                                                                          fImp.Path_exportPdf,
                                                                                          fImp.pDestinatarios,
                                                                                          "BLOQUETO(S) DO DOCUMENTO Nº " + rVenda.lPortador.Find(p => p.Vl_pagtoPDV > decimal.Zero && p.lDup.Count > 0).lDup[0].Nr_docto,
                                                                                          fImp.pDs_mensagem,
                                                                                          false);
                                }
                        }
                        afterNovo();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        tEspera.Fechar();
                        tEspera = null;
                    }
                }           
            }
            else
                MessageBox.Show("Não existe venda para finalizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GerarCupom()
        {
            using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                        if (fGerar.lItens.Count > 0)
                        {
                            if (new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_pdv",
                                        vOperador = "=",
                                        vVL_Busca = rSessao.Id_pdvstr
                                    }
                                }, "1") != null)
                            {
                                try
                                {
                                    //Processar cupom fiscal
                                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                    dados.lItens = fGerar.lItens;
                                    dados.rSessao = rSessao;
                                    dados.Cd_clifor = string.Empty;
                                    dados.Nm_clifor = string.Empty;
                                    dados.CpfCgc = string.Empty;
                                    dados.Endereco = string.Empty;
                                    dados.Mensagem = string.Empty;
                                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                    dados.St_vendacombustivel = false;
                                    dados.St_cupomavulso = true;
                                    dados.St_agruparProduto = false;

                                    PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                    if (rNFCe != null)
                                        if (!rNFCe.St_contingencia)
                                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                            {
                                                fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                         rNFCe.Id_nfcestr,
                                                                                                                         null);
                                                fGerNfe.ShowDialog();
                                            }
                                        else
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            BindingSource dts = new BindingSource();
                                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                            Rel.DTS_Relatorio = dts;// bsItens;
                                            //DTS Cupom
                                            BindingSource bsNFCe = new BindingSource();
                                            bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                              string.Empty,
                                                                                                              rNFCe.Cd_empresa,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              decimal.Zero,
                                                                                                              decimal.Zero,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              false,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              1,
                                                                                                              null);
                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                                CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                   string.Empty,
                                                                                                   null);
                                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                            //Buscar Empresa
                                            BindingSource bsEmpresa = new BindingSource();
                                            bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                null);
                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                            //Forma Pagamento
                                            BindingSource bsPagto = new BindingSource();
                                            List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                                            new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                    "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                    }
                                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                    (aux, venda) =>
                                                                        new
                                                                        {
                                                                            tp_portador = aux,
                                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                        }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = x.tp_portador,
                                                                            Vl_recebido = x.Vl_recebido,
                                                                            Vl_troco_ch = x.Vl_troco_ch,
                                                                            Vl_troco_dh = x.Vl_troco_dh
                                                                        }));
                                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                        }
                                                    }, 1, string.Empty);
                                            if (lDup.Count > 0)
                                                lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                {
                                                    Tp_portador = "05",
                                                    Vl_recebido = lDup[0].Vl_documento
                                                });
                                            bsPagto.DataSource = lPagto;
                                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                            //Parametros
                                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                            object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.id_lote = a.id_lote " +
                                                                                "and x.status = '100')"
                                                                }
                                                            }, "a.tp_ambiente");
                                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                  (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                  null);
                                            if (!string.IsNullOrEmpty(dadoscf))
                                            {
                                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                                string placa = string.Empty;
                                                string km = string.Empty;
                                                string frota = string.Empty;
                                                string requisicao = string.Empty;
                                                string nm_motorista = string.Empty;
                                                string cpf_motorista = string.Empty;
                                                string media = string.Empty;
                                                string virg = string.Empty;
                                                foreach (string s in linhas)
                                                {
                                                    string[] colunas = s.Split(new char[] { '/' });
                                                    placa += virg + colunas[0];
                                                    km += virg + colunas[1];
                                                    frota += virg + colunas[2];
                                                    requisicao += virg + colunas[3];
                                                    nm_motorista += virg + colunas[4];
                                                    cpf_motorista += virg + colunas[5];
                                                    media += virg + colunas[6];
                                                    virg = ",";
                                                }
                                                if (!string.IsNullOrEmpty(placa))
                                                    Rel.Parametros_Relatorio.Add("PLACA", placa);
                                                if (!string.IsNullOrEmpty(km))
                                                    Rel.Parametros_Relatorio.Add("KM", km);
                                                if (!string.IsNullOrEmpty(media))
                                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                if (!string.IsNullOrEmpty(frota))
                                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                if (!string.IsNullOrEmpty(requisicao))
                                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                if (!string.IsNullOrEmpty(nm_motorista))
                                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                if (!string.IsNullOrEmpty(cpf_motorista))
                                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                            }
                                            Rel.Nome_Relatorio = "DANFE_NFCE";
                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                            Rel.Modulo = "FAT";
                                            Rel.Ident = "DANFE_NFCE";
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                            {
                                                BindingSource bsItens = new BindingSource();
                                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                Rel.DTS_Relatorio = bsItens;
                                            }
                                            if (rNFCe.Id_contingencia.HasValue)
                                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                else
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                            //Verificar se existe Impressora padrão para o PDV
                                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.impressorapadrao");
                                            string print = obj == null ? string.Empty : obj.ToString();
                                            if (string.IsNullOrEmpty(print))
                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                {
                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                            print = fLista.Impressora;

                                                }
                                            //Imprimir
                                            if (!string.IsNullOrEmpty(print))
                                            {
                                                Rel.ImprimiGraficoReduzida(print,
                                                                           true,
                                                                           false,
                                                                           null,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           1);
                                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                    Rel.ImprimiGraficoReduzida(print,
                                                                               true,
                                                                               false,
                                                                               null,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               1);
                                            }
                                        }
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GerarNfe()
        {
            using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            string pCd_clifor = fGerar.Cd_clifor;
                            if (string.IsNullOrEmpty(pCd_clifor))
                            {
                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                    pCd_clifor = linha["cd_clifor"].ToString();
                            }

                            if (!string.IsNullOrEmpty(pCd_clifor))
                            {
                                //Buscar endereco
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
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
                                string pCd_endereco = string.Empty;
                                if (lEnd.Count.Equals(1))
                                    pCd_endereco = lEnd[0].Cd_endereco;
                                else
                                {
                                    string vColunas = "a.ds_endereco|Endereço|200;" +
                                                      "a.cd_endereco|Codigo|80;" +
                                                      "a.bairro|Bairro|80;" +
                                                      "a.insc_estadual|Insc. Estadual|80";
                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
                                    if (linha != null)
                                        pCd_endereco = linha["cd_endereco"].ToString();
                                }
                                if (string.IsNullOrEmpty(pCd_endereco))
                                {
                                    MessageBox.Show("Obrigatorio informar endereço cliente NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(pCd_clifor,
                                                                                              pCd_endereco,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              lCfg[0],
                                                                                              fGerar.lItens,
                                                                                              ref rPedProduto,
                                                                                              ref rPedServico);
                                if (rPedProduto != null)
                                {
                                    CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                    //Buscar pedido
                                    rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                    //Buscar itens pedido
                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                    //Se o CMI do pedido gerar financeiro
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                    //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                    string vId_venda = string.Empty;
                                    string virg = string.Empty;
                                    fGerar.lItens.GroupBy(p => p.Id_vendarapida,
                                        (aux, cupom) =>
                                            new
                                            {
                                                id_cupom = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                vId_venda += virg + p.id_cupom.Value.ToString();
                                                virg = ",";
                                            });
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + fGerar.lItens[0].Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom in(" + vId_venda + "))"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                    //Gerar Nota Fiscal
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                                    //Vincular financeiro a Nota Fiscal
                                    rFat.lParcAgrupar = lParcVinculado;
                                    //Montar obs com placa-km
                                    string obs = string.Empty;
                                    string virgula = string.Empty;
                                    fGerar.lItens.ForEach(p => p.Placa_KM = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(p.Cd_empresa, p.Id_vendarapida.Value.ToString(), null));
                                    fGerar.lItens.GroupBy(p => p.Placa_KM,
                                        (aux, pl) =>
                                            new
                                            {
                                                placa = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                obs += virgula + p.placa;
                                                virgula = ",";
                                            });
                                    if (!string.IsNullOrEmpty(obs))
                                        rFat.Dadosadicionais += (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Placa/KM " + obs.Trim();
                                    //Gravar Nota Fiscal
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                        rFat.Nr_lanctofiscalstr,
                                                                                                                        null);
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                if (rPedServico != null)
                                {
                                    CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico, null);
                                    //Buscar pedido
                                    rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                                    //Buscar itens pedido
                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                                    //Se o CMI do pedido gerar financeiro
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                    //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                    string vId_venda = string.Empty;
                                    string virg = string.Empty;
                                    fGerar.lItens.GroupBy(p => p.Id_vendarapida,
                                        (aux, cupom) =>
                                            new
                                            {
                                                id_cupom = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                vId_venda += virg + p.id_cupom.Value.ToString();
                                                virg = ",";
                                            });
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + fGerar.lItens[0].Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom in(" + vId_venda + "))"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                    //Gerar Nota Fiscal
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedServico, true, lParcVinculado.Sum(p => p.Vl_atual));
                                    //Vincular financeiro a Nota Fiscal
                                    rFat.lParcAgrupar = lParcVinculado;
                                    //Montar obs com placa-km
                                    string obs = string.Empty;
                                    string virgula = string.Empty;
                                    fGerar.lItens.ForEach(p => p.Placa_KM = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(p.Cd_empresa, p.Id_vendarapida.Value.ToString(), null));
                                    fGerar.lItens.GroupBy(p => p.Placa_KM,
                                        (aux, pl) =>
                                            new
                                            {
                                                placa = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                obs += virgula + p.placa;
                                                virgula = ",";
                                            });
                                    if (!string.IsNullOrEmpty(obs))
                                        rFat.Dadosadicionais += (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Placa/KM " + obs.Trim();
                                    //Gravar Nota Fiscal
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfgNfe.Count > 0)
                                    {
                                        NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0],
                                                                       CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     rFat.Nr_lanctofiscalstr,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     decimal.Zero,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     false,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     decimal.Zero,
                                                                                                                                     decimal.Zero,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     false,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     1,
                                                                                                                                     string.Empty,
                                                                                                                                     null));
                                        MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar cliente da NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (rPedProduto != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedProduto, null);
                            if (rPedServico != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedServico, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcessarCFVincular(List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lCupom,
                                         string pCd_empresa,
                                         string pCd_cliente)
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(lCupom,
                                                                                pCd_empresa,
                                                                                pCd_cliente);
                //Gravar Pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                //Se o CMI do pedido gerar financeiro
                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                lCupom.ForEach(p =>
                {
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                "inner join tb_pdv_cupom_x_movcaixa y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and y.id_cupom = " + p.Id_nfcestr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                });
                //Gerar Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                //Vincular Cupom a Nota Fiscal
                string Obs = string.Empty;
                string virg = string.Empty;
                lCupom.ForEach(p =>
                {
                    rFat.lCupom.Add(p);
                    Obs += virg + p.NR_NFCestr.Trim() + "/" + p.Placa.Trim();
                    virg = ",";
                });
                //Vincular financeiro a Nota Fiscal
                rFat.lParcAgrupar = lParcVinculado;
                if (!string.IsNullOrEmpty(Obs))
                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. Cupom Fiscal/Placa " + Obs.Trim();
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                if (MessageBox.Show("NFe gravada com sucesso. Deseja enviar a mesma para a receita?",
                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                    {
                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                        rFat.Nr_lanctofiscalstr,
                                                                                                        null);
                        fGerNfe.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
            }
        }

        private void VincularCfNFe()
        {
            using (Proc_Commoditties.TFVincularECFNF fVincular = new Proc_Commoditties.TFVincularECFNF())
            {
                if (fVincular.ShowDialog() == DialogResult.OK)
                    if (fVincular.lCupom != null)
                        if (fVincular.lCupom.Count > 0)
                            ProcessarCFVincular(fVincular.lCupom, fVincular.pCd_empresa, fVincular.pCd_cliente);
                        else
                            MessageBox.Show("Não existe cupom fiscal selecionado para vincular a Nota Fiscal.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CadastrarCodBarra()
        {
            using (Proc_Commoditties.TFCadCodBarra fCod = new Proc_Commoditties.TFCadCodBarra())
            {
                fCod.ShowDialog();
            }
        }

        private void NovaVendaMesaConv()
        {
            using (TFVendaMesaConv fNova = new TFVendaMesaConv())
            {
                if (fNova.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string Id_venda = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Gravar(
                                            new CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv()
                                            {
                                                Cd_empresa = CD_Empresa.Text,
                                                Dt_venda = CamadaDados.UtilData.Data_Servidor(),
                                                Nm_cliente = fNova.Nm_cliente,
                                                St_registro = "A"
                                            }, null);
                        using (TFLanVendaMesaConv fVenda = new TFLanVendaMesaConv())
                        {
                            fVenda.Cd_empresa = CD_Empresa.Text;
                            fVenda.Nm_empresa = NM_Empresa.Text;
                            fVenda.Cd_local = lCfg[0].Cd_local;
                            fVenda.Cd_tabelapreco = lCfg[0].Cd_tabelapreco;
                            fVenda.Nm_cliente = fNova.Nm_cliente;
                            fVenda.Id_venda = Id_venda;
                            fVenda.ShowDialog();
                            if (fVenda.St_finalizar)
                            {
                                //Verificar se ja existe venda em aberto
                                if (bsItens.Count > 0)
                                {
                                    if (MessageBox.Show("Existe venda em aberto. Deseja acrescentar os itens a venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                    {
                                        //Buscar lista de itens da venda
                                        CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                                     fVenda.Cd_empresa,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     true,
                                                                                                     null).ForEach(p =>
                                                                                                     {
                                                                                                         //Cria novo item
                                                                                                         bsItens.AddNew();
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = p.Qtd_faturar * p.Vl_unitario;
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                                                                         bsItens.ResetCurrentItem();
                                                                                                         TotalizarVenda();
                                                                                                         Qtd_itensvenda++;
                                                                                                     });
                                        FinalizarVenda(string.Empty);
                                    }
                                }
                                else
                                {
                                    //Buscar lista de itens da venda
                                    CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                                 fVenda.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 true,
                                                                                                 null).ForEach(p =>
                                                                                                 {
                                                                                                     //Cria novo item
                                                                                                     bsItens.AddNew();
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = p.Qtd_faturar * p.Vl_unitario;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                                                                     bsItens.ResetCurrentItem();
                                                                                                     TotalizarVenda();
                                                                                                     Qtd_itensvenda++;
                                                                                                 });
                                    FinalizarVenda(string.Empty);
                                }
                            }    
                        }
                        //Buscar venda Mesa em Aberto
                        bsVendaMesaConv.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                                             CD_Empresa.Text,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             "'A'",
                                                                                                             true,
                                                                                                             null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.Cancel;
                    }
                    
                }
                else
                    MessageBox.Show("Obrigatorio informar cliente para abrir venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FaturarVendaMesaConv()
        {
            if (bsVendaMesaConv.Current != null)
            {
                using (TFItensVendaMesaFat fItens = new TFItensVendaMesaFat())
                {
                    fItens.Cd_empresa = (bsVendaMesaConv.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Cd_empresa;
                    fItens.Id_venda = (bsVendaMesaConv.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Id_vendastr;
                    if (fItens.ShowDialog() == DialogResult.OK)
                    {
                        fItens.lItens.ForEach(p =>
                            {
                                if (lCfg[0].St_movestoquebool)
                                {
                                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                                    {
                                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                                        {
                                            //Verificar se item possui saldo estoque
                                            decimal saldo = BuscarSaldoLocal(p.Cd_produto);
                                            if (saldo < p.Qtd_faturar)
                                            {

                                                if (saldo.Equals(decimal.Zero))
                                                {
                                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                                    "Empresa.........: " + p.Cd_empresa.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                                    "Produto.........: " + p.Cd_produto.Trim() + "-" +
                                                                                        p.Ds_produto.Trim() + "\r\n" +
                                                                    "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n" +
                                                                    "Item não sera faturado.",
                                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else if (MessageBox.Show("Deseja faturar item com quantidade igual ao saldo disponivel?\r\n" +
                                                                        "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                {
                                                    //Cria novo item
                                                    bsItens.AddNew();
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = saldo;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Math.Round(saldo * p.Vl_unitario, 2);
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(saldo, p.Vl_unitario);
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                    bsItens.ResetCurrentItem();
                                                    //Buscar Promocao
                                                    BuscarPromocao();
                                                    TotalizarVenda();
                                                    Qtd_itensvenda++;
                                                }
                                            }
                                            else
                                            {
                                                //Cria novo item
                                                bsItens.AddNew();
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Math.Round(p.Qtd_faturar * p.Vl_unitario, 2);
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(p.Qtd_faturar, p.Vl_unitario);
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                bsItens.ResetCurrentItem();
                                                //Buscar promocao
                                                BuscarPromocao();
                                                TotalizarVenda();
                                                Qtd_itensvenda++;
                                            }
                                        }
                                        else
                                        {
                                            //Buscar ficha tecnica produto composto
                                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto, string.Empty, null);
                                            lFicha.ForEach(v => v.Quantidade = v.Quantidade * p.Qtd_faturar);
                                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                            //Buscar saldo itens da ficha tecnica
                                            string msg = string.Empty;
                                            lFicha.ForEach(v =>
                                            {
                                                //Buscar saldo estoque do item
                                                decimal saldo = decimal.Zero;
                                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal((bsVendaMesaConv.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Cd_empresa,
                                                                                                        v.Cd_item,
                                                                                                        p.Cd_local,
                                                                                                        ref saldo,
                                                                                                        null);
                                                if (saldo < v.Quantidade)
                                                    msg += "Produto.........: " + v.Cd_item.Trim() + "-" + v.Ds_item.Trim() + "\r\n" +
                                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                            });
                                            if (!string.IsNullOrEmpty(msg))
                                            {
                                                msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                //Cria novo item
                                                bsItens.AddNew();
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Math.Round(p.Qtd_faturar * p.Vl_unitario, 2);
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(p.Qtd_faturar, p.Vl_unitario);
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                bsItens.ResetCurrentItem();
                                                //Buscar promocao
                                                BuscarPromocao();
                                                TotalizarVenda();
                                                Qtd_itensvenda++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Cria novo item
                                        bsItens.AddNew();
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Math.Round(p.Qtd_faturar * p.Vl_unitario, 2);
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(p.Qtd_faturar, p.Vl_unitario);
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                        bsItens.ResetCurrentItem();
                                        //Promocao
                                        BuscarPromocao();
                                        TotalizarVenda();
                                        Qtd_itensvenda++;
                                    }
                                }
                                else
                                {
                                    //Cria novo item
                                    bsItens.AddNew();
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = Math.Round(p.Qtd_faturar * p.Vl_unitario, 2);
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(p.Qtd_faturar, p.Vl_unitario);
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto * 100 /
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                    bsItens.ResetCurrentItem();
                                    //Promocao
                                    BuscarPromocao();
                                    TotalizarVenda();
                                    Qtd_itensvenda++;
                                }
                            });
                        FinalizarVenda(string.Empty);
                        //Buscar venda Mesa em Aberto
                        bsVendaMesaConv.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                                             CD_Empresa.Text,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             "'A'",
                                                                                                             true,
                                                                                                             null);
                    }
                }
            }
        }
        
        private void TFLanVendaConveniencia_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gVendaMesaConv);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            login.Text = Login.Trim();
            CD_Empresa.Text = Cd_empConv;
            afterNovo();
            //Buscar venda Mesa em Aberto
            bsVendaMesaConv.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                                 CD_Empresa.Text,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 "'A'",
                                                                                                 true,
                                                                                                 null);
            
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (lCfg.Count.Equals(0) ? false : !lCfg[0].St_produtocodigobool)
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
                }
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = vl_unitario.Value;
                bsItens.ResetCurrentItem();
                CalcularSubTotal();
                BuscarPromocao();
            }
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = vl_unitario.Value;
                    bsItens.ResetCurrentItem();
                    CalcularSubTotal();
                    BuscarPromocao();
                }
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = pc_desconto.Value;
                bsItens.ResetCurrentItem();
                CalcularDesconto(true);
            }
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Pc_desconto = pc_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(true);
                    vl_desconto.Focus();
                }
        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                bsItens.ResetCurrentItem();
                CalcularDesconto(false);
            }
        }

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(false);
                    cd_produto.Focus();
                }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void bb_retornar_Click(object sender, EventArgs e)
        {
            if(bsVendaRapida.Current != null)
                if ((bsVendaRapida.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar venda sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            DialogResult = DialogResult.OK;
        }

        private void bb_finalizar_Click(object sender, EventArgs e)
        {
            FinalizarVenda(string.Empty);
        }

        private void TFLanVendaConveniencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
                AlterarQuantidade();
            else if (e.KeyCode.Equals(Keys.F4))
                FinalizarVenda(string.Empty);
            else if (e.KeyCode.Equals(Keys.F5))
                CancelarVenda();
            else if (e.Control && e.KeyCode.Equals(Keys.F2))
                NovaVendaMesaConv();
            else if (e.Control && e.KeyCode.Equals(Keys.F4))
                FaturarVendaMesaConv();
        }

        private void TFLanVendaConveniencia_Activated(object sender, EventArgs e)
        {
            cd_produto.Focus();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_cupom_Click(object sender, EventArgs e)
        {
            GerarCupom();
        }

        private void bb_gerarnfe_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void bb_vincularcf_Click(object sender, EventArgs e)
        {
            VincularCfNFe();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && lCfg[0].St_movestoquebool)
                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto)) &&
                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto)))
                {
                    //Verificar saldo estoque do produto
                    decimal saldo = BuscarSaldoLocal((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto);
                    if (saldo < Quantidade.Value)
                    {
                        MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                        "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                        "Produto.........: " + (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto.Trim() + "-" +
                                                               (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto.Trim() + "\r\n" +
                                        "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                        "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (saldo.Equals(decimal.Zero))
                        {
                            bsItens.RemoveCurrent();
                            cd_produto.Focus();
                        }
                        else
                        {
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = saldo;
                            bsItens.ResetCurrentItem();
                            CalcularSubTotal();
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(saldo, 
                                                                                                                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario);
                            BuscarPromocao();
                            TotalizarVenda();
                        }
                    }
                    else
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                    bsItens.ResetCurrentItem();
                    CalcularSubTotal();
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(Quantidade.Value,
                                                                                                                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario);
                    BuscarPromocao();
                    TotalizarVenda();
                }
                else
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                    bsItens.ResetCurrentItem();
                    CalcularSubTotal();
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto = CalcularDescEspecial(Quantidade.Value,
                                                                                                                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario);
                    BuscarPromocao();
                    TotalizarVenda();
                }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Quantidade_Leave(sender, new EventArgs());
                if (!cd_produto.Focused)
                    if (!vl_unitario.Focus())
                        pc_desconto.Focus();
            }
        }

        private void bb_cancelarvenda_Click(object sender, EventArgs e)
        {
            CancelarVenda();
        }

        private void bb_codbarra_Click(object sender, EventArgs e)
        {
            CadastrarCodBarra();
        }

        private void TFLanVendaConveniencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gVendaMesaConv);
            if (Qtd_itensvenda > 0)
            {
                MessageBox.Show("Existe venda em aberto. Para fechar janela é necessario finalizar ou cancelar a venda", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            try
            {
                CamadaNegocio.Faturamento.PDV.TCN_Sessao.EncerrarSessao(rSessao, null);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_vendamesaconv_Click(object sender, EventArgs e)
        {
            NovaVendaMesaConv();
        }

        private void gVendaMesaConv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(bsVendaMesaConv.Current != null)
                using (TFLanVendaMesaConv fVenda = new TFLanVendaMesaConv())
                {
                    fVenda.Cd_empresa = CD_Empresa.Text;
                    fVenda.Nm_empresa = NM_Empresa.Text;
                    fVenda.Cd_local = lCfg[0].Cd_local;
                    fVenda.Cd_tabelapreco = lCfg[0].Cd_tabelapreco;
                    fVenda.Nm_cliente = (bsVendaMesaConv.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Nm_cliente;
                    fVenda.Id_venda = (bsVendaMesaConv.Current as CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv).Id_vendastr;
                    fVenda.ShowDialog();
                    if (fVenda.St_finalizar)
                    {
                        //Verificar se ja existe venda em aberto
                        if (bsItens.Count > 0)
                        {
                            if (MessageBox.Show("Existe venda em aberto. Deseja acrescentar os itens a venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                //Buscar lista de itens da venda
                                CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                             fVenda.Cd_empresa,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             true,
                                                                                             null).ForEach(p =>
                                                                                                 {
                                                                                                     //Cria novo item
                                                                                                     bsItens.AddNew();
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = p.Qtd_faturar * p.Vl_unitario;
                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                                                                     bsItens.ResetCurrentItem();
                                                                                                     TotalizarVenda();
                                                                                                     Qtd_itensvenda++;
                                                                                                 });
                                FinalizarVenda(string.Empty);
                            }
                        }
                        else
                        {
                            //Buscar lista de itens da venda
                            CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                         fVenda.Cd_empresa,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         true,
                                                                                         null).ForEach(p =>
                                                                                         {
                                                                                             //Cria novo item
                                                                                             bsItens.AddNew();
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_produto = p.Cd_produto;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_produto = p.Ds_produto;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_grupo = p.Cd_grupo;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_unidade = p.Cd_unidade;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade = p.Sigla_unidade;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade = p.Qtd_faturar;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario = p.Vl_unitario;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal = p.Qtd_faturar * p.Vl_unitario;
                                                                                             (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).rItensVendaMesaConv = p;
                                                                                             bsItens.ResetCurrentItem();
                                                                                             TotalizarVenda();
                                                                                             Qtd_itensvenda++;
                                                                                         });
                            FinalizarVenda(string.Empty);
                        }
                    }
                    //Buscar venda Mesa em Aberto
                    bsVendaMesaConv.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Buscar(string.Empty,
                                                                                                         CD_Empresa.Text,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         "'A'",
                                                                                                         true,
                                                                                                         null);
                    cd_produto.Focus();
                }
        }

        private void bb_faturarvenda_Click(object sender, EventArgs e)
        {
            FaturarVendaMesaConv();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            CancelarVenda();
        }

        private void gerarCupomFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarCupom();
        }

        private void gerarNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void vincularCFANFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VincularCfNFe();
        }

        private void cadastrarCodigoBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarCodBarra();
        }

        private void liquidarDuplicatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Buscar caixa aberto do PDV
            object obj_caixa = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = " isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                "where x.login = a.login " +
                                                "and x.id_pdv = " + rSessao.Id_pdvstr + " " +
                                                "and x.id_sessao = " + rSessao.Id_sessaostr + ")"
                                }
                            }, "a.id_caixa");
            if (obj_caixa == null)
                throw new Exception("Não existe caixa aberto para o Login " + rSessao.Login);
            using (TFLanParcelas fParcelas = new TFLanParcelas())
            {
                fParcelas.Cd_moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", lCfg[0].Cd_empresa, null);
                fParcelas.pId_caixaoperacional = decimal.Parse(obj_caixa.ToString());
                fParcelas.Loginpdv = Login;
                fParcelas.Cd_contaoperacional = lCfg[0].Cd_contaoperacional;
                fParcelas.Ds_contaoperacional = lCfg[0].Ds_contaoperacional;
                fParcelas.ShowDialog();
            }
        }

        private void consultarNFeEmitidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFLanConsultaNFe fNfe = new Proc_Commoditties.TFLanConsultaNFe())
            {
                fNfe.ShowDialog();
            }
        }

        private void conexãoRemotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Utils.Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "ShowMyPC.exe"))
                if (System.Diagnostics.Process.GetProcessesByName("ShowMyPC").Length == 0)
                    try
                    {
                        System.Diagnostics.Process.Start(Utils.Parametros.pubPathAliance.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "ShowMyPC.exe");
                    }
                    catch
                    { }
        }

        private void suporteOnLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tecnoaliance.mysuite1.com.br/clientvivo.php?param=sochat_chatdep&inf=&sl=tna&idm=&redirect=http://tecnoaliance.mysuite1.com.br/empresas/tna/atendimento.php");
        }

        private void cancelarVendaRecebidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PDV.TFExcluirVendaRapida fGerar = new PDV.TFExcluirVendaRapida())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lVenda != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(fGerar.lVenda, null);
                            MessageBox.Show("Venda Rapida Excluida com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                        MessageBox.Show("Não existe venda selecionada excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelarNFeEmitidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lCfg.Count > 0)
                using (TFCancelarNFe fCanc = new TFCancelarNFe())
                {
                    fCanc.Cd_empresa = lCfg[0].Cd_empresa;
                    fCanc.Nm_empresa = lCfg[0].Nm_empresa;
                    fCanc.ShowDialog();
                }
        }

        private void bb_dinheiro_Click(object sender, EventArgs e)
        {
            FinalizarVenda("R");
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            FinalizarVenda("C");
        }

        private void bb_cheque_Click(object sender, EventArgs e)
        {
            FinalizarVenda("H");
        }

        private void bb_notacobrar_Click(object sender, EventArgs e)
        {
            FinalizarVenda("N");
        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Buscar caixa aberto do PDV
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = " isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                    "where x.login = a.login " +
                                    "and x.id_pdv = " + rSessao.Id_pdvstr + " " +
                                    "and x.id_sessao = " + rSessao.Id_sessaostr + ")"
                    }
                }, 1, string.Empty);
            if (lCaixa.Count.Equals(0))
            {
                MessageBox.Show("Não existe caixa aberto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (PDV.TFFechaCaixaOperacional fFechar = new PDV.TFFechaCaixaOperacional())
            {
                if (fFechar.ShowDialog() == DialogResult.OK)
                    if (fFechar.lPortador != null)
                    {
                        lCaixa[0].lPorFecharCaixa = fFechar.lPortador;
                        lCaixa[0].Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                        lCaixa[0].St_registro = "F";
                        //Verificar se o PDV permite reter valor caixa
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_pdv",
                                                vOperador = "=",
                                                vVL_Busca = rSessao.Id_pdvstr
                                            }
                                        }, "a.vl_maxretcaixa");
                        if ((obj == null ? false : decimal.Parse(obj.ToString()) > decimal.Zero) &&
                            lCaixa[0].Vl_transportar.Equals(decimal.Zero))
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Ds_label = "Vl. Retido Caixa";
                                fQtde.Vl_saldo = decimal.Parse(obj.ToString());
                                fQtde.Casas_decimais = 2;
                                if (fQtde.ShowDialog() == DialogResult.OK)
                                    lCaixa[0].Vl_transportar = fQtde.Quantidade;
                            }
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.FecharCaixa(lCaixa[0], null);
                            MessageBox.Show("Caixa fechado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void suprimentoRetiradaCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Buscar caixa aberto do PDV
            object obj = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = " isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                "where x.login = a.login " +
                                                "and x.id_pdv = " + rSessao.Id_pdvstr + " " +
                                                "and x.id_sessao = " + rSessao.Id_sessaostr + ")"
                                }
                            }, "a.id_caixa");
            if (obj == null)
            {
                MessageBox.Show("Não existe caixa aberto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
            {
                fRetirar.pId_caixa = obj.ToString();
                if (fRetirar.ShowDialog() == DialogResult.OK)
                    if (fRetirar.rRetirada != null)
                    {
                        try
                        {
                            fRetirar.rRetirada.Id_caixastr = obj.ToString();
                            fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                            CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
            }
        }
        
        private void trocarEspecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Buscar caixa aberto do PDV
            object obj_caixa = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = " isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                            "where x.login = a.login " +
                                                            "and x.id_pdv = " + rSessao.Id_pdvstr + " " +
                                                            "and x.id_sessao = " + rSessao.Id_sessaostr + ")"
                                            }
                                        }, "a.id_caixa");
            if (obj_caixa == null)
                throw new Exception("Não existe caixa aberto para o Login " + rSessao.Login);
            using (PDV.TFTrocaEspecie fTrocar = new PDV.TFTrocaEspecie())
            {
                fTrocar.pCd_empresa = lCfg[0].Cd_empresa;
                fTrocar.pNm_empresa = lCfg[0].Nm_empresa;
                fTrocar.pId_caixa = obj_caixa.ToString();
                fTrocar.pCd_contager = lCfg[0].Cd_contaoperacional;
                fTrocar.pDs_contager = lCfg[0].Ds_contaoperacional;
                fTrocar.pCd_historico = lCfg[0].Cd_historico;
                fTrocar.pDs_historico = lCfg[0].Ds_historico;
                if (fTrocar.ShowDialog() == DialogResult.OK)
                    if (fTrocar.rTroca != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_TrocaEspecie.Gravar(fTrocar.rTroca, null);
                            MessageBox.Show("Troca realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void devolverVendaCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFDevolverECF fDev = new Proc_Commoditties.TFDevolverECF())
            {
                if (fDev.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        Proc_Commoditties.TProcessarNFDevVendaCF.ProcessarDevVendaCF(fDev.pCd_cliente, fDev.rCF);
                        CamadaNegocio.Faturamento.PDV.TCN_DevolucaoCF.ProcessarNFDevolucao(rFat, null);
                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                        {
                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                            null);
                            fGerNfe.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cancelarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lCfg.Count > 0)
                using (TFCancelarNFe fCanc = new TFCancelarNFe())
                {
                    fCanc.Cd_empresa = lCfg[0].Cd_empresa;
                    fCanc.Nm_empresa = lCfg[0].Nm_empresa;
                    fCanc.St_nfce = true;
                    fCanc.ShowDialog();
                }
        }        
    }
}
