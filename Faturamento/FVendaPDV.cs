using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using Utils;
using System.IO;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Faturamento.PDV;
using CamadaNegocio.ConfigGer;
using FormBusca;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using PostoCombustivel;

namespace Faturamento
{
    public partial class TFVendaPDV : Form
    { 
        private bool st_fechavenda = false;
        private bool st_alterouqtd = false;
        private bool Altera_Relatorio = false;
        public string LoginPdv
        { get; set; }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private TRegistro_CaixaPDV rCaixa { get; set; }
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadProtocolo rProtocolo { get; set; }
        private bool St_promocao = false;
        private bool St_promoDescEspecial = false;
        private bool St_descEspecial = false;

        public TFVendaPDV()
        {
            InitializeComponent();
            rProg = null;
        }
        
        private void afterNovo()
        {
            //Verificar se existe caixa aberto para realizar venda
            st_fechavenda = false;
            lblDescricao.Text = "CAIXA LIVRE";
            lbTroco.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (rCaixa != null)
            {
                //Limpar Campos
                //lblQuantidade.Text = "1,000";
                lblVl_Unitario.Text = "0,00";
                lblTotal.Text = "0,00";
                lblTotalCupom.Text = "0,00";
                bsVendaRapida.AddNew();
                if (!string.IsNullOrEmpty(lPdv[0].Nm_empresa))
                {
                    //Buscar Config Cupom
                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
                    if (lCfg.Count < 1)
                    {
                        MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + lPdv[0].Cd_empresa,
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa = lPdv[0].Cd_empresa;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa = lPdv[0].Nm_empresa;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = lCfg[0].Cd_clifor;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = lCfg[0].Nm_clifor;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = lCfg[0].Cd_endereco;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco = lCfg[0].Ds_endereco;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco = lCfg[0].Cd_tabelapreco;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;

                txtDados.Focus();
            }
            else
                MessageBox.Show("Não existe caixa aberto para realizar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarProduto()
        {
            if (st_fechavenda)
            {
                st_fechavenda = false;
                afterNovo();
            }
            if (!st_alterouqtd)
                lblQuantidade.Text = "1,00";
            if (lCfg.Count.Equals(0) ? false : !lCfg[0].St_produtocodigobool)
            {
                if (string.IsNullOrEmpty(txtDados.Text.SoNumero()))
                {
                    if (UtilPesquisa.BuscarProduto(txtDados.Text,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco,
                                                            new Componentes.EditDefault[] { txtDados },
                                                            null) == null)
                    {
                        MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDados.Clear();
                        txtDados.Focus();
                        return;
                    }
                }
                else if (txtDados.Text.Trim().Length != txtDados.Text.Trim().Length)
                    if (UtilPesquisa.BuscarProduto(txtDados.Text,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa,
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco,
                                                            new Componentes.EditDefault[] { txtDados },
                                                            null) == null)
                    {
                        MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDados.Clear();
                        txtDados.Focus();
                        return;
                    }
            }
            if (BuscarItens())
            {
                txtDados.Clear();
                txtDados.Focus();
            }
            else
            {
                MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDados.Clear();
                txtDados.Focus();
            }
        }

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(txtDados.Text))
            {
                string pCd_codbarra = txtDados.Text;
                if (pCd_codbarra.Contains("\r"))
                    MessageBox.Show("Barra r");
                if (pCd_codbarra.Contains("\n"))
                    MessageBox.Show("Barra n");
                decimal vl_subtotal = decimal.Zero;
                decimal qtd = decimal.Zero;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (txtDados.Text.Trim().Length < lParam[0].Tamanho)
                        txtDados.Text = txtDados.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(txtDados.Text,
                                                                                            pCd_codbarra,
                                                                                            null);
                //Buscar Código de barra balança
                if (lProduto.Count.Equals(0) && pCd_codbarra.Length.Equals(13))
                {
                    string cod = pCd_codbarra.Substring(1, 5).ToString();
                    string v = pCd_codbarra.Remove(12, 1).Substring(7, 3) + "," + pCd_codbarra.Remove(12, 1).Substring(10, 2);
                    vl_subtotal = decimal.Parse(v);
                    if (lParam.Count > 0)
                        if (cod.Trim().Length < lParam[0].Tamanho)
                            cod = cod.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                    //Buscar produto
                    lProduto =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cod,
                                                                                                string.Empty,
                                                                                                null);
                    if (lProduto.Count > 0)
                    {
                        decimal preco = ConsultaPreco(lProduto[0].CD_Produto);
                        if (preco.Equals(0))
                        {
                            MessageBox.Show("Não existe preço cadastrado para o \r\nProduto: " + cod.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "!",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        if (vl_subtotal.Equals(0))
                        {
                            MessageBox.Show("Não existe Vl.SubTotal registrado no Código de Barras do \r\nProduto " + cod.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "!",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        qtd = Math.Round(vl_subtotal / preco, 3);
                    }
                }
                if (lProduto.Count > 0)
                {
                    //Cria novo item
                    bsItens.AddNew();
                    //Verificar se existe quantidade com peso na balança.
                    if (lProduto[0].St_pesarprodbool)
                    {
                        if (rProtocolo == null)
                            AlterarQuantidade();
                        else
                        {
                            bool st_quantidade = true;
                            using (Proc_Commoditties.TFBalancaProc fPeso = new Proc_Commoditties.TFBalancaProc())
                            {
                                fPeso.rProtocolo = rProtocolo;
                                if (fPeso.ShowDialog() == DialogResult.OK)
                                    if (fPeso.Peso > decimal.Zero)
                                    {
                                        lblQuantidade.Text = fPeso.Peso.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                                        st_quantidade = false;
                                    }
                            }
                            if (st_quantidade)
                                AlterarQuantidade();
                        }
                    }
                    lblQuantidade.Text = qtd > decimal.Zero ? qtd.ToString() : lblQuantidade.Text;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo = lProduto[0].CD_Grupo;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_tabelapreco = lCfg[0].Cd_tabelapreco;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_condfiscal_produto = lProduto[0].CD_CondFiscal_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ncm = lProduto[0].Ncm;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_unidade = lProduto[0].CD_Unidade;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Sigla_unidade = lProduto[0].Sigla_unidade;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade = decimal.Parse(lblQuantidade.Text);
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario = ConsultaPreco(lProduto[0].CD_Produto);
                    if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario > decimal.Zero)
                    {
                        (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal = decimal.Parse(lblQuantidade.Text) * ConsultaPreco(lProduto[0].CD_Produto);
                        decimal desconto = CalcularDescEspecial(decimal.Parse(lblQuantidade.Text), ConsultaPreco(lProduto[0].CD_Produto));
                        if (desconto > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = desconto;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = desconto * 100 /
                                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                    }
                    //Buscar Promocao Venda
                    BuscarPromocao(bsItens.Current as TRegistro_VendaRapida_Item);
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    TotalizarVenda();
                    st_alterouqtd = false;
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
            if ((!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                         (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                                                         vCd_produto,
                                                                                                         (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                    vCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                vCd_produto,
                                                                                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void BuscarPromocao(TRegistro_VendaRapida_Item rItemCupom)
        {
            if (bsItens.Current != null)
            {
                St_promocao = false;
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                rItemCupom.Cd_produto,
                                                                                                rItemCupom.Cd_grupo,
                                                                                                rProg,
                                                                                                rItemCupom.Vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals(rItemCupom.Cd_produto.Trim())).Sum(p => p.Quantidade) >= rPro.Qtd_minimavenda)
                        {
                            St_promocao = true;
                            St_promoDescEspecial = true;
                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals(rItemCupom.Cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    p.Pc_desconto = rPro.Vl_promocao;
                                    //Calcular desconto
                                    p.Vl_desconto = p.Vl_subtotal * (rPro.Vl_promocao / 100);
                                }
                                else
                                {
                                    p.Vl_desconto = rPro.Vl_promocao * p.Quantidade;
                                    //Calcular % Desconto
                                    p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                }
                            });
                            bsVendaRapida.ResetCurrentItem();
                        }
                        else
                        {
                            rItemCupom.Vl_desconto = decimal.Zero;
                            rItemCupom.Pc_desconto = decimal.Zero;
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            rItemCupom.Pc_desconto = rPro.Vl_promocao;
                            //Calcular desconto
                            rItemCupom.Vl_desconto = rItemCupom.Vl_subtotal * (rPro.Vl_promocao / 100);
                        }
                        else
                        {
                            rItemCupom.Vl_desconto = rPro.Vl_promocao * rItemCupom.Quantidade;
                            //Calcular % Desconto
                            rItemCupom.Pc_desconto = rItemCupom.Vl_desconto * 100 / rItemCupom.Vl_subtotal;
                        }
                        St_promoDescEspecial = true;
                        St_promocao = true;
                    }
            }
        }

        private decimal CalcularDescEspecial(decimal Qtde,
                                             decimal Vl_unit)
        {
            St_descEspecial = false;
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.
                        Where(p => p.Cd_produto.Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        St_descEspecial = true;
                        St_promoDescEspecial = true;
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                        else
                            return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    St_descEspecial = true;
                    St_promoDescEspecial = true;
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private void TotalizarVenda()
        {
            if (bsVendaRapida.Current != null)
            {
                if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Count > 0)
                {
                    lblTotalCupom.Text = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else
                {
                    lblQuantidade.Text = "1,000";
                    lblVl_Unitario.Text = "0,00";
                    lblTotal.Text = "0,00";
                    lblTotalCupom.Text = "0,00";
                }
                bsVendaRapida.ResetCurrentItem();
            }
        }

        private void AlterarQuantidade()
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Vl_default = 1;
                fQtde.Ds_label = "Informar";
                if (fQtde.ShowDialog() == DialogResult.OK)
                    if (fQtde.Quantidade > decimal.Zero)
                    {
                        lblQuantidade.Text = fQtde.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                        st_alterouqtd = true;
                    }
            }
        }

        private void CancelarVenda()
        {
            if (MessageBox.Show("Confirma cancelamento da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bsItens.Clear();
                //Limpar Campos
                lblQuantidade.Text = "1,000";
                lblVl_Unitario.Text = "0,00";
                lblTotal.Text = "0,00";
                lblTotalCupom.Text = "0,00";
                lblDescricao.Text = "CAIXA LIVRE";
                bsItens.ResetBindings(true);
            }
        }

        private void afterGrava(string Tp_portador)
        {
            if (st_fechavenda)
                return;
            if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Count < 1)
            {
                MessageBox.Show("Não é permitido gravar venda rapida sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Exists(p => p.Quantidade.Equals(decimal.Zero)))
            {
                MessageBox.Show("Não é permitido gravar venda rapida com itens com quantidade zero.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Verificar se cliente possui adiantamento
            lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                        new TpBusca[]
                                            { 
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_adto, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, 0, string.Empty);
            string cd_clifor = string.Empty;
            string nm_clifor = string.Empty;
            TList_CadPortador lDevolCred = new TList_CadPortador();
            if (lAdiant.Count > 0)
            {
                //Buscar portador Dev Credito
                lDevolCred =
                    new TCD_CadPortador().Select(
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
                                vNM_Campo = "a.st_cartaocredito",
                                vOperador = "=",
                                vVL_Busca = "1"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                vOperador = "=",
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
                if (lDevolCred.Count > decimal.Zero)
                {
                    decimal tot_devolver = (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred <
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) ?
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred :
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
                    List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                    foreach (CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rSaldo in lAdiant)
                    {
                        if (tot_devolver > decimal.Zero)
                        {
                            rSaldo.Vl_processar = rSaldo.Vl_total_devolver > tot_devolver ? tot_devolver : rSaldo.Vl_total_devolver;
                            lDev.Add(rSaldo);
                            tot_devolver -= rSaldo.Vl_processar;
                        }
                        else break;
                    }
                    //Lancar Devolução Credito
                    lDevolCred[0].lCred = lDev;
                    lDevolCred[0].Vl_pagtoPDV = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) >
                                                lDev.Sum(v => v.Vl_processar) ? lDev.Sum(v => v.Vl_processar) :
                                                (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
                    (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                    decimal tot_venda =
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) - lDev.Sum(v => v.Vl_processar);
                    if (tot_venda <= decimal.Zero)
                    {
                        ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                        try
                        {
                            FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida, tEsperaDev, string.Empty,string.Empty);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        {
                            tEsperaDev.Fechar();
                            tEsperaDev = null;
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (Tp_portador.Trim().ToUpper().Equals("D"))//dinheiro
            {
                //Buscar portador dinheiro
                TList_CadPortador lDinheiro =
                    new TCD_CadPortador().Select(
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
                    fFechar.pCd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                    fFechar.pCd_operador = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_vend;
                    fFechar.rCupom = bsVendaRapida.Current as TRegistro_VendaRapida;
                    fFechar.pVl_receber = decimal.Parse(lblTotalCupom.Text) - (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
                    fFechar.lPdv = lPdv;
                    if (fFechar.ShowDialog() == DialogResult.OK)
                    {
                        //Ratear desconto 
                        if (fFechar.pVl_desconto > decimal.Zero)
                            TCN_VendaRapida.RatearDescontoVRapida(bsVendaRapida.Current as TRegistro_VendaRapida,
                                                                  fFechar.pVl_desconto,
                                                                  decimal.Zero);
                        lDinheiro[0].Vl_pagtoPDV = fFechar.pVl_dinheiro;
                        //Abrir Gaveta
                        if (fFechar.pVl_troco == decimal.Zero)
                            AbrirGavetaDinheiro();
                        //Troco
                        if (fFechar.pVl_troco > decimal.Zero)
                            lDinheiro[0].Vl_trocoPDV = fFechar.pVl_troco;
                        else lDinheiro[0].Vl_trocoPDV = decimal.Zero;
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lDinheiro[0]);
            }
            else if (Tp_portador.Trim().ToUpper().Equals("CC") ||
                Tp_portador.Trim().ToUpper().Equals("CD"))//Cartao Credito
            {
                //Buscar portador cartao
                TList_CadPortador lCartao =
                    new TCD_CadPortador().Select(
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
                    fCartao.pCd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                    fCartao.D_C = Tp_portador.Trim().ToUpper().Equals("CC") ? "C" : "D";
                    fCartao.Vl_saldofaturar = decimal.Parse(lblTotalCupom.Text) - (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
                    //Testar se existe saldo a faturar 
                    if (fCartao.Vl_saldofaturar.Equals(decimal.Zero))
                        return;
                    fCartao.St_validarSaldo = true;
                    if (fCartao.ShowDialog() == DialogResult.OK)
                    {
                        fCartao.lFatura.ForEach(p => lCartao[0].lFatura.Add(p));
                        lCartao[0].Vl_pagtoPDV = fCartao.lFatura.Sum(p => p.Vl_fatura);
                        lCartao[0].Vl_trocoPDV = lCartao[0].Vl_pagtoPDV - fCartao.Vl_saldofaturar;
                        AbrirGavetaDinheiro();
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lCartao[0]);
            }
            else if (Tp_portador.Trim().ToUpper().Equals("H"))//Cheque
            {
                //Buscar portador cheque
                TList_CadPortador lCheque =
                    new TCD_CadPortador().Select(
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
                TRegistro_DadosBloqueio rDados =
                    new TRegistro_DadosBloqueio();
                if (TCN_DadosBloqueio.VerificarBloqueioCredito((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                                                  (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido),
                                                                                                  false,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
                        fBloq.ShowDialog();
                        if (!fBloq.St_desbloqueado)
                            throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                    }
                using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                {
                    fListaCheques.Tp_mov = "R";
                    fListaCheques.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                    //fListaCheques.St_pdv = true;
                    fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                    fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                    fListaCheques.Cd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                    fListaCheques.Cd_historico = lCfg[0].Cd_historicocaixa;
                    fListaCheques.Ds_historico = lCfg[0].Ds_historicocaixa;
                    fListaCheques.Cd_portador = lCheque[0].Cd_portador;
                    fListaCheques.Ds_portador = lCheque[0].Ds_portador;
                    fListaCheques.Nm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                    fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    fListaCheques.Vl_totaltitulo = decimal.Parse(lblTotalCupom.Text) - (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
                    //Testar se existe saldo a faturar 
                    if (fListaCheques.Vl_totaltitulo.Equals(decimal.Zero))
                        return;
                    if (fListaCheques.ShowDialog() == DialogResult.OK)
                    {
                        lCheque[0].lCheque = fListaCheques.lCheques;
                        lCheque[0].Vl_pagtoPDV = fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                        lCheque[0].Vl_trocoPDV = lCheque[0].Vl_pagtoPDV - fListaCheques.Vl_totaltitulo;
                        AbrirGavetaDinheiro();
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lCheque[0]);
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
                decimal pVl_receber = decimal.Parse(lblTotalCupom.Text) - (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
                //Buscar portador duplicata
                TList_CadPortador lDup = new TCD_CadPortador().Select(
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
                if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                {
                    MessageBox.Show("Não é permitido venda a prazo sem identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Abrir tela Duplicata
                if ((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor == lCfg[0].Cd_clifor)
                {
                    Componentes.EditDefault CD_Clifor = new Componentes.EditDefault();
                    CD_Clifor.NM_Campo = "CD_Clifor";
                    CD_Clifor.NM_CampoBusca = "CD_Clifor";
                    DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
                    if (linha != null)
                    {
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["Nm_clifor"].ToString();
                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                        {
                            TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
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
                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = lEnd[0].Cd_endereco;
                                (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco = lEnd[0].Ds_endereco;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar cliente para gerar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //Verificar credito
                TRegistro_DadosBloqueio rDados = new TRegistro_DadosBloqueio();
                if (TCN_DadosBloqueio.VerificarBloqueioCredito((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                pVl_receber,
                                                                true,
                                                                ref rDados,
                                                                null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = pVl_receber;
                        fBloq.ShowDialog();
                        if (!fBloq.St_desbloqueado)
                        {
                            MessageBox.Show("Não é permitido realizar venda para cliente com restrição crédito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                //Abrir tela Duplicata
                TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                rDup.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                rDup.Nm_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa;
                rDup.Cd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                rDup.Nm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                rDup.Cd_endereco = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco;
                rDup.Ds_endereco = (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco;
                //Buscar cond pagamento
                TList_CadCondPgto lCond =
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
                {
                    rDup.Cd_condpgto = lCond[0].Cd_condpgto;
                    rDup.Qt_parcelas = lCond[0].Qt_parcelas;
                    rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                }
                rDup.Tp_docto = lCfg[0].Tp_docto;
                rDup.Ds_tpdocto = lCfg[0].Ds_tpdocto;
                rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                rDup.Ds_tpduplicata = lCfg[0].Ds_tpduplicata;
                rDup.Tp_mov = "R";
                rDup.Cd_historico = lCfg[0].Cd_historico;
                rDup.Ds_historico = lCfg[0].Ds_historico;
                //Buscar Moeda Padrao
                TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
                if (tabela != null)
                    if (tabela.Count > 0)
                    {
                        rDup.Cd_moeda = tabela[0].Cd_moeda;
                        rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                        rDup.Sigla_moeda = tabela[0].Sigla;
                    }
                rDup.Id_configBoleto = lCfg[0].Id_config;
                rDup.Nr_docto = "PDC123";//pNr_cupom; //Numero Cupom
                rDup.Dt_emissaostring = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                rDup.Vl_documento = pVl_receber;
                rDup.Vl_documento_padrao = pVl_receber;

                rDup.Parcelas.Add(new TRegistro_LanParcela()
                {
                    Cd_parcela = 1,
                    Dt_vencto = lCond.Count > 0 ? rDup.Dt_emissao.Value.AddDays(double.Parse(lCond[0].Qt_diasdesdobro.ToString())) : rDup.Dt_emissao,
                    Vl_parcela = pVl_receber,
                    Vl_parcela_padrao = pVl_receber
                });
                lDup[0].lDup.Add(rDup);
                lDup[0].Vl_pagtoPDV = rDup.Vl_documento_padrao;
                (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lDup[0]);
            }
            else
                using (PDV.TFFecharVendaPDV fFechar = new PDV.TFFecharVendaPDV())
                {
                    fFechar.rCupom = bsVendaRapida.Current as TRegistro_VendaRapida;
                    fFechar.pCd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                    fFechar.pCd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                    fFechar.pNm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                    fFechar.rCfg = lCfg[0];
                    fFechar.pVl_receber = decimal.Parse(lblTotalCupom.Text) - (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
                    fFechar.lPdv = lPdv;
                    fFechar.LoginPDV = LoginPdv;
                    if (fFechar.ShowDialog() == DialogResult.OK)
                        if (fFechar.lPortador != null)
                        {
                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = fFechar.pCd_clifor;
                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = fFechar.pNm_clifor;
                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = fFechar.pCd_endereco;
                            (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco = fFechar.pDs_endereco;
                            (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = fFechar.lPortador;
                            if (lDevolCred.Count > 0)
                                (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lDevolCred[0]);
                            if (fFechar.pVl_troco == decimal.Zero)
                                AbrirGavetaDinheiro();
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                        return;
                    }
                }
            
            try
            {
                 
                lbTroco.Text = (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Sum(p => p.Vl_trocoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida, null,cd_clifor,nm_clifor);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FecharVenda(TRegistro_VendaRapida rVenda, ThreadEspera tEspera, string cd_clifor , string nm_clifor)
        {
            TCN_VendaRapida.GravarVendaRapida(rVenda,
                                              null,
                                              null,
                                              null);

            st_fechavenda = true;
            lblDescricao.Text = "CAIXA LIVRE";
            //Busca cupom gravado
            TList_VendaRapida lCupom =
                        TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
                                               rVenda.Cd_empresa,
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
                                               1,
                                               null);
            lCupom.ForEach(p => p.lItem = TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                                      p.Cd_empresa,
                                                                      false,
                                                                      string.Empty,
                                                                      null));
            lCupom[0].lPortador = rVenda.lPortador;
            bsVendaRapida.DataSource = lCupom;
            TotalizarVenda();

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
             new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, 1, string.Empty);


            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCredito =
                new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                    "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                    }
                }, 0, string.Empty);
            //Imprimir comprovante de credito
            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
            {

                if (lCredito.Count > 0)
                {
                    FileInfo f = null;
                    StreamWriter w = null;
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Credito.txt");
                    w = f.CreateText();
                    try
                    {
                        w.WriteLine(" =========================================");
                        w.WriteLine("            COMPROVANTE CREDITO           ");
                        w.WriteLine(" =========================================");
                        w.WriteLine("NR. Venda Origem: ".FormatStringDireita(32, ' ') + lCupom[0].Id_vendarapidastr.FormatStringEsquerda(10, '0'));
                        lCredito.ForEach(p =>
                        {
                            w.WriteLine("NR. Credito: ".FormatStringDireita(32, ' ') + p.Id_adto.ToString().FormatStringEsquerda(10, '0'));
                            w.WriteLine("Data: ".FormatStringDireita(32, ' ') + p.Dt_lanctostring);
                            w.WriteLine("Valor: ".FormatStringEsquerda(32, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            //Imprimir observacao cupom
                            if (!string.IsNullOrEmpty(p.Ds_adto))
                            {
                                string obs = p.Ds_adto.Trim();
                                w.WriteLine("Observacoes".FormatStringDireita(42, '-'));
                                while (true)
                                {
                                    if (obs.Length <= 40)
                                    {
                                        w.WriteLine("  " + obs);
                                        break;
                                    }
                                    else
                                    {
                                        w.WriteLine("  " + obs.Substring(0, 40));
                                        obs = obs.Remove(0, 40);
                                    }
                                }
                            }
                            w.WriteLine();
                        });
                        w.Write(Convert.ToChar(12));
                        w.Write(Convert.ToChar(27));
                        w.Write(Convert.ToChar(109));
                        w.Flush();
                        f.CopyTo(lTerminal[0].Porta_imptick);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão comprovante credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                }
            }
            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
            {
                if (lCredito.Count > 0)
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.NM_Classe = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    BindingSource BinCredito = new BindingSource();
                    BinCredito.DataSource = lCredito;
                    Relatorio.Adiciona_DataSource("CREDITO", BinCredito);

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lCupom[0];
                    Relatorio.DTS_Relatorio = meu_bind;


                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "Comprovante de Crédito";
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(string.Empty,
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        "Comprovante de Crédito",
                                                        fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }
                }
            }
            if (lCupom[0].lPortador.Exists(p => p.lDup.Count > 0))
            {
                //Imprimir Boleto
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                        }
                    }, 0, string.Empty);
                if (lBloqueto.Count > 0)
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                        fImp.pMensagem = "BOLETO(S) VENDA RAPIDA Nº" + lCupom[0].Id_vendarapidastr;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                              lBloqueto,
                                                                              fImp.pSt_imprimir,
                                                                              fImp.pSt_visualizar,
                                                                              fImp.pSt_enviaremail,
                                                                              fImp.pSt_exportPdf,
                                                                              fImp.Path_exportPdf,
                                                                              fImp.pDestinatarios,
                                                                              "BOLETO(S) VENDA RAPIDA Nº " + lCupom[0].Id_vendarapidastr,
                                                                              fImp.pDs_mensagem,
                                                                              false);
                    }
                else
                {
                    //Se gerou duplicata imprimir confissão divida
                    TList_RegLanParcela lParc =
                        new TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                            "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                            }
                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                    if (lParc.Count > 0)
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource bs = new BindingSource();
                        bs.DataSource = new TList_VendaRapida() { lCupom[0] };
                        Rel.DTS_Relatorio = bs;
                        //DTS Cupom
                        BindingSource dts = new BindingSource();
                        dts.DataSource = TCN_VendaRapida_Item.Buscar(lCupom[0].Id_vendarapidastr,
                                                                     lCupom[0].Cd_empresa,
                                                                     false,
                                                                     string.Empty,
                                                                     null);
                        Rel.Adiciona_DataSource("DTS_ITENS", dts);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        TList_CadEndereco lEnd = new TList_CadEndereco();
                        TRegistro_CadClifor rClifor = new TRegistro_CadClifor();
                       BindingSource bsend = new BindingSource();
                        //Buscar Cliente Duplicata
                        rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(lParc[0].Cd_clifor, null);
                        //Buscar Endereco Duplicata
                        lEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParc[0].Cd_clifor,
                                                                                         lParc[0].Cd_endereco,
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
                        Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                        Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                        Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                        lEnd[0].cpf = rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc;
                        lEnd[0].rg = rClifor.Nr_rg;
                        bsend.DataSource = lEnd;
                        //Buscar Valor Pago
                        decimal vl_pago = decimal.Zero;
                        List<TRegistro_MovCaixa> lPag = 
                            new TCD_CaixaPDV().SelectMovCaixa(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_cupom",
                                            vOperador = "=",
                                            vVL_Busca = lCupom[0].Id_vendarapidastr
                                        }
                                    }, string.Empty);
                        if (lPag.Count > 0)
                            vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                        vl_pago += lParc.Sum(p => p.Vl_liquidado);
                        Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                        Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                        BindingSource bsParc = new BindingSource();
                        bsParc.DataSource = lParc;
                        Rel.Adiciona_DataSource("PARC", bsParc);
                        Rel.Adiciona_DataSource("END", bsend);
                        Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_PDV";
                        Rel.NM_Classe = "TFVendaPDV";
                        Rel.Modulo = "FAT";
                        Rel.Ident = "CONFISSAO_DIVIDA_PDV";
                        //Verificar se existe Impressora padrão para o PDV
                       object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
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
                        Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                    }
                }
            }
            using (TFGerarDocFiscal fDoc = new TFGerarDocFiscal())
            {
                if (fDoc.ShowDialog() == DialogResult.OK)
                    if (fDoc.St_nfe)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        if ((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor == lCfg[0].Cd_clifor)
                        {
                            Componentes.EditDefault CD_Clifor = new Componentes.EditDefault();
                            CD_Clifor.NM_Campo = "CD_Clifor";
                            CD_Clifor.NM_CampoBusca = "CD_Clifor";
                            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
                            if (linha != null)
                            {
                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["Nm_clifor"].ToString();
                                if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                {
                                    TList_CadEndereco lEnd =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
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
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = lEnd[0].Cd_endereco;
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco = lEnd[0].Ds_endereco;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar cliente para gerar NF-e!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        try
                        {
                            Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                                          (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          lCfg[0],
                                                                                          (bsVendaRapida.Current as TRegistro_VendaRapida).lItem,
                                                                                          ref rPedProduto,
                                                                                          ref rPedServico);
                            if (rPedProduto != null)
                            {
                                TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto,
                                                                                                       null);
                                //Buscar pedido
                                rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                //Se o CMI do pedido gerar financeiro
                                TList_RegLanParcela lParcVinculado = new TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                new TCD_LanParcela().Select(
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
                                                            "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
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
                                TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico, null);
                                //Buscar pedido
                                rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                                //Se o CMI do pedido gerar financeiro
                                TList_RegLanParcela lParcVinculado = new TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                new TCD_LanParcela().Select(
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
                                                            "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
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
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                        {
                            try
                            {
                                //Processar cupom fiscal
                                PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                dados.lItens = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem;
                                dados.rSessao = lSessao[0];
                                dados.Cd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                                dados.Nm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                                //Buscar CNPJ/CPF
                                object obj = new TCD_CadClifor().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'"
                                                }
                                            }, "isnull(a.nr_cgc, a.nr_cpf)");
                                if (obj != null)
                                    dados.CpfCgc = obj.ToString();
                                dados.Endereco = string.Empty;
                                dados.Mensagem = string.Empty;
                                dados.lPortador = new List<TRegistro_CadPortador>();
                                dados.St_vendacombustivel = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = false;
                                TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true);
                                if (rNFCe != null)
                                    if (!rNFCe.St_contingencia)
                                    {
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
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
                                                ProcessarCFVincular(new List<TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                    }
                                    else
                                    {
                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                        Rel.Altera_Relatorio = Altera_Relatorio;
                                        BindingSource dts = new BindingSource();
                                        dts.DataSource = new TList_NFCe_Item();
                                        Rel.DTS_Relatorio = dts;// bsItens;
                                        //DTS Cupom
                                        BindingSource bsNFCe = new BindingSource();
                                        bsNFCe.DataSource = TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
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
                                        NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
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
                                        List<TRegistro_MovCaixa> lPagto = new List<TRegistro_MovCaixa>();
                                        new TCD_CaixaPDV().SelectMovCaixa(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                "and x.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                }
                                            }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                (aux, venda) =>
                                                                    new
                                                                    {
                                                                        tp_portador = aux,
                                                                        Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                        Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                        Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                    }).ToList().ForEach(x => lPagto.Add(new TRegistro_MovCaixa()
                                                                    {
                                                                        Tp_portador = x.tp_portador,
                                                                        Vl_recebido = x.Vl_recebido,
                                                                        Vl_troco_ch = x.Vl_troco_ch,
                                                                        Vl_troco_dh = x.Vl_troco_dh
                                                                    }));
                                        TList_RegLanDuplicata lDup =
                                                new TCD_LanDuplicata().Select(
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
                                                                    "and x.cd_empresa = a.cd_empresa " +
                                                                    "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                    "and y.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                    "and y.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                    }
                                                }, 1, string.Empty);
                                        if (lDup.Count > 0)
                                            lPagto.Add(new TRegistro_MovCaixa()
                                            {
                                                Tp_portador = "05",
                                                Vl_recebido = lDup[0].Vl_documento
                                            });
                                        bsPagto.DataSource = lPagto;
                                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                        //Parametros
                                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                        obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
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
                                        string dadoscf = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
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
                                        if (TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                        {
                                            BindingSource bsItens = new BindingSource();
                                            bsItens.DataSource =
                                                TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                     (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                     string.Empty,
                                                                     null);
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
                                            if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                                (bsNFCe.Current as TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                Rel.ImprimiGraficoReduzida(print,
                                                                           true,
                                                                           false,
                                                                           null,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           1);
                                        }
                                    }
                                st_fechavenda = true;
                                lblDescricao.Text = "CAIXA LIVRE";
                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                st_fechavenda = true;
                                lblDescricao.Text = "CAIXA LIVRE";
                                return;
                            }
                        }
                        else
                            MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }

        private void AbrirGavetaDinheiro()
        {
            if (lPdv.Count > 0)
                if (lPdv[0].St_gavetadinheirobool)
                {
                    //Buscar porta comunicacao
                    object obj_porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lPdv[0].Cd_terminal.Trim() + "'"
                                            }
                                        }, "a.porta_imptick");
                    if (obj_porta != null)
                        try
                        {
                            TGavetaDinheiro.AbrirGaveta(obj_porta.ToString(), lPdv[0].CMD_Abrirgaveta);
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro executar comando: " + ex.Message.Trim()); }
                    else MessageBox.Show("Terminal " + lPdv[0].Cd_terminal.Trim() + "-" + lPdv[0].Ds_terminal.Trim() + " não tem porta comunicação configurada.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private decimal BuscarCreditoCliente(ref decimal vl_faturar)
        {
            decimal retorno = decimal.Zero;
            //Verificar se cliente possui adiantamento
            lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                        new TpBusca[]
                        { 
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'R'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.vl_receber - a.vl_pagar",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                        }, 0, string.Empty);
            //Somar Saldo Adto
            decimal vl_adiant = lAdiant.Sum(p => p.Vl_total_devolver);
            if ((lAdiant.Count > decimal.Zero) &&
                ((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor != lCfg[0].Cd_clifor))
            {
                //Buscar portador Dev Credito
                TList_CadPortador lDevolCred =
                    new TCD_CadPortador().Select(
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
                                vNM_Campo = "a.st_cartaocredito",
                                vOperador = "=",
                                vVL_Busca = "1"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                vOperador = "=",
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
                if (lDevolCred.Count > decimal.Zero)
                {
                    using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
                    {
                        fSaldo.Cd_empresa = lCfg[0].Cd_empresa;
                        fSaldo.Cd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                        fSaldo.Tp_mov = "'R'";
                        fSaldo.Vl_financeiro = vl_faturar;
                        if (fSaldo.ShowDialog() == DialogResult.OK)
                            if (fSaldo.lSaldo != null)
                            {
                                lAdiant = fSaldo.lSaldo;
                                //Lancar Devolução Credito
                                lDevolCred[0].lCred = fSaldo.lSaldo;
                                retorno = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                                lDevolCred[0].Vl_pagtoPDV = retorno;

                                (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                                if (fSaldo.lSaldo.Sum(p => p.Vl_processar) >= vl_faturar)
                                {
                                    ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                                    try
                                    {
                                        FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida, tEsperaDev,string.Empty, string.Empty);
                                        vl_faturar = 0;
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    finally
                                    {
                                        tEsperaDev.Fechar();
                                        tEsperaDev = null;
                                    }
                                }
                                else
                                    vl_faturar -= fSaldo.lSaldo.Sum(p => p.Vl_processar);
                            }
                    }
                }
            }
            return retorno;
        }

        private void ImprimirGrafico(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new TCD_LanParcela().Select(
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
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                (bsVendaRapida.Current as TRegistro_VendaRapida).ObsOS = obsOS.ToString();
            }


            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_clifor;
                    fImp.pMensagem = "ORÇAMENTO Nº " + val.Id_vendarapidastr;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(val.Id_vendarapidastr,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "ORÇAMENTO Nº " + val.Id_vendarapidastr,
                                                fImp.pDs_mensagem);
                }
            }
            else
            {
                Relatorio.Gera_Relatorio();
                Altera_Relatorio = false;
            }
        }

        private void ImprimirGraficoReduzido(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_cupom",
                                                vOperador = "=",
                                                vVL_Busca = val.Id_vendarapidastr
                                            }
                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new TCD_LanParcela().Select(
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
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa "+
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                (bsVendaRapida.Current as TRegistro_VendaRapida).ObsOS = obsOS.ToString();
            }


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            if (!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
                                                 1);
            Altera_Relatorio = false;
        }

        private void ProcessarCFVincular(List<TRegistro_NFCe> lCupom,
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
                TList_RegLanParcela lParcVinculado = new TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                lCupom.ForEach(p =>
                {
                    new TCD_LanParcela().Select(
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
                                            "inner join tb_pdv_cupom_x_vendarapida y " +
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

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                (bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo,
                                                                                                null, 
                                                                                                decimal.Zero,
                                                                                                null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) -
                                (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                                 (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                                                                 (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                                 (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco,
                                                                                                                 null);
                                (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto.Trim())).ToList().ForEach(p =>
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
                }
            }
            else
                MessageBox.Show("Não existe item selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);               
        }

        private void ConsultarPrecoVenda()
        {
            using (Proc_Commoditties.TFConsultaProduto fConsulta = new Proc_Commoditties.TFConsultaProduto())
            {
                fConsulta.ShowDialog();
            }
        }

        private void ExtratoDupAberto()
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
            if (linha != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Ident = "TFVendaPDV_ParcelasAbertas";
                    Rel.NM_Classe = "TFVendaPDV_ParcelasAbertas";
                    Rel.Modulo = "PDV";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = linha["cd_clifor"].ToString();
                    fImp.pMensagem = "PARCELAS EM ABERTO";

                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCfg[0].Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);

                    //Duplicata Locacao
                    BindingSource BinDup = new BindingSource();
                    BinDup.DataSource = new TCD_LanParcela().Select(
                                            new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + lCfg[0].Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + linha["cd_clifor"].ToString() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_mov",
                                                        vOperador = "=",
                                                        vVL_Busca = "'R'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "in",
                                                        vVL_Busca = "('A', 'P')",
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Empresa x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.login = '" + LoginPdv.Trim() + "') "
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                    Rel.DTS_Relatorio = BinDup;
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "PARCELAS EM ABERTO",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "PARCELAS EM ABERTO",
                                           fImp.pDs_mensagem);
                    }
                }
            }

        private void TFPAF_ECF_Load(object sender, EventArgs e)
        {

            Icon = ResourcesUtils.TecnoAliance_ICO;
            lblTotalCupom.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (string.IsNullOrEmpty(LoginPdv))
                LoginPdv = Utils.Parametros.pubLogin;
            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count < 1)
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Verificar sessao
            if (new TCD_Sessao().BuscarEscalar(
                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_pdv",
                                    vOperador = "=",
                                    vVL_Busca = lPdv[0].Id_pdvstr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + LoginPdv + "'"
                                }
                            }, "1") == null)
                TCN_Sessao.AbrirSessao(
                    new TRegistro_Sessao()
                    {
                        Id_pdvstr = lPdv[0].Id_pdvstr,
                        Login = LoginPdv
                    }, null);
            //Buscar sessao aberta
            lSessao = TCN_Sessao.Buscar(lPdv[0].Id_pdvstr,
                                                                      string.Empty,
                                                                      LoginPdv,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'A'",
                                                                      1,
                                                                      null);
            if (lSessao.Count < 1)
            {
                MessageBox.Show("Não existe sessão aberta para o PDV " + lPdv[0].Id_pdvstr + " Login " + LoginPdv,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Busca caixa aberto
            TList_CaixaPDV lCaixa =
                new TCD_CaixaPDV().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + LoginPdv + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 1, string.Empty);
            if (lCaixa.Count > 0)
                rCaixa = lCaixa[0];
            else
            {
                MessageBox.Show("Não existe caixa aberto para iniciar movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
            }
            CamadaDados.Diversos.TList_RegCadProtocolo lProt = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(string.Empty, string.Empty, Utils.Parametros.pubTerminal, null);
            if (lProt.Count > 0)
                rProtocolo = lProt[0];
            lblOperador.Text = LoginPdv;
            lblPDV.Text = lPdv[0].Ds_pdv;
            //Criar Venda
            afterNovo();

            timer1.Enabled = true;
            timer1.Interval = 1000; 


        }

        private void fecharToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDados_Enter(object sender, EventArgs e)
        {
            txtDados.Clear();
            lblQuantidade.Text = "1,000";
            lblVl_Unitario.Text = "0,00";
            lblTotal.Text = "0,00";
            lblTotalCupom.Text = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void txtDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            lblDescricao.Text = bsItens.Current == null ? lblDescricao.Text : st_fechavenda ? "CAIXA LIVRE" : (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto;
            lblQuantidade.Text = bsItens.Current == null ? lblQuantidade.Text : (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade > decimal.Zero ?
                (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) : lblQuantidade.Text; ;
            lblVl_Unitario.Text = bsItens.Current == null ? "0,00" : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            lblTotal.Text = bsItens.Current == null ? "0,00" : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void TFVendaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
                afterGrava("D");
            if (e.KeyCode.Equals(Keys.F2))
                afterGrava("CC");
            else if (e.KeyCode.Equals(Keys.F3))
                AlterarQuantidade();
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava(string.Empty);
            else if (e.KeyCode.Equals(Keys.F5))
                ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F6))
                CancelarVenda();
            else if (e.KeyCode.Equals(Keys.F7))
                ConsultarPrecoVenda();
            else if (e.KeyCode.Equals(Keys.F8))
                afterGrava("CD");
            else if (e.KeyCode.Equals(Keys.F9))
                afterGrava("H");
            else if (e.KeyCode.Equals(Keys.F10))
                ExtratoDupAberto();
            else if (e.KeyCode.Equals(Keys.F11))
                afterGrava("N");
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
            else if (e.KeyCode.Equals(Keys.Down) && !gItens.Focused)
            {
                if (bsItens.Position + 1 <= bsItens.Count - 1)
                    bsItens.Position = bsItens.Position + 1;
            }
            else if (e.KeyCode.Equals(Keys.Up) && !gItens.Focused)
            {
                if (!bsItens.Position.Equals(0))
                    bsItens.Position = bsItens.Position - 1;
            }
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0 && !st_fechavenda)
            {
                MessageBox.Show("Existe venda em andamento, para fechar PDV cancele a venda!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                Close();
        }

        private void TFVendaPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Encerrar Sessão
            try
            {
                lSessao.ForEach(p => TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbDinheiro_Click(object sender, EventArgs e)
        {
            afterGrava("D");
        }

        private void bbCredito_Click(object sender, EventArgs e)
        {
            afterGrava("CC");
        }

        private void bbDebito_Click(object sender, EventArgs e)
        {
            afterGrava("CD");
        }

        private void bbCheque_Click(object sender, EventArgs e)
        {
            afterGrava("H");
        }

        private void bbDuplicata_Click(object sender, EventArgs e)
        {
            afterGrava("N");
        }

        private void lblImpVenda_Click(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current == null ? false : (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapida.HasValue)
            {
                try
                {
                    CamadaDados.Diversos.TList_CadTerminal lTerminal =
                     new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                }
                                            }, 1, string.Empty);
                    if (lTerminal.Count > 0)
                    {
                        if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                        {
                            TCN_VendaRapida.ImprimirVendaRapida(bsVendaRapida.Current as TRegistro_VendaRapida);
                            return;
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                        {
                            if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                            TCN_VendaRapida.ImprimirReduzido(bsVendaRapida.Current as TRegistro_VendaRapida, lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                            ImprimirGraficoReduzido(bsVendaRapida.Current as TRegistro_VendaRapida);
                        else
                            ImprimirGrafico(bsVendaRapida.Current as TRegistro_VendaRapida);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Não existe venda para imprimir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblImpVenda_MouseEnter(object sender, EventArgs e)
        {
            lblImpVenda.ForeColor = System.Drawing.Color.Blue;
        }

        private void lblImpVenda_MouseLeave(object sender, EventArgs e)
        {
            lblImpVenda.ForeColor = System.Drawing.Color.Black;
        }

        private void miGerarCFVenda_Click(object sender, EventArgs e)
        {
            GerarCF();
        }

        private void ProcessaCfVincular(List<TRegistro_NFCe> val,
                                    string Cd_empresa,
                                    string Cd_cliente)
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(val, Cd_empresa, Cd_cliente);
                //Gravar Pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                //Se o CMI do pedido gerar financeiro
                TList_RegLanParcela lParcVinculado = new TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                val.ForEach(p =>
                {
                    new TCD_LanParcela().Select(
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
                                vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                            "inner join tb_pdv_cupomfiscal_x_duplicata y " +
                                            "on x.cd_empresa = y.cd_empresa " +
                                            "and x.id_vendarapida = y.id_cupom " +
                                            "and y.cd_empresa = a.cd_empresa " +
                                            "and y.nr_lancto = a.nr_lancto " +
                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + p.Id_nfcestr + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                });
                //Gerar Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                //Vincular Cupom a Nota Fiscal
                string Obs = string.Empty;
                string virg = string.Empty;
                val.ForEach(p =>
                {
                    rFat.lCupom.Add(p);
                    string Placa_km = TCN_NFCe.BuscarPlacaKM(p.Cd_empresa, p.Id_nfcestr, null);
                    Obs += virg + p.NR_NFCestr.Trim() + "-" + (string.IsNullOrEmpty(Placa_km) ? p.Placa : Placa_km.Trim()) + (!string.IsNullOrEmpty(p.Nr_requisicao) ? "/" + p.Nr_requisicao.Trim() : string.Empty);
                    virg = ",";
                });
                //Vincular financeiro a Nota Fiscal
                rFat.lParcAgrupar = lParcVinculado;
                if (!string.IsNullOrEmpty(Obs))
                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. CF-Placa/KM/Frota/Requisicao " + Obs.Trim();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
            }
        }


        private void GerarCF()
        {
            using (TFGerarCFCombustivel fGerar = new TFGerarCFCombustivel())
            {
                fGerar.Cd_empresa = lCfg[0].Cd_empresa;
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                        try
                        {
                            if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                            {
                                //Processar cupom fiscal
                                PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                dados.lItens = fGerar.lItens;
                                dados.rSessao = lSessao[0];
                                dados.Cd_clifor = string.Empty;
                                dados.Nm_clifor = string.Empty;
                                dados.CpfCgc = string.Empty;
                                dados.Endereco = string.Empty;
                                dados.Mensagem = string.Empty;
                                dados.lPortador = new List<TRegistro_CadPortador>();
                                dados.St_vendacombustivel = true;
                                dados.St_convenio = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = false;
                                PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                if (rNFCe != null)
                                    if (!rNFCe.St_contingencia)
                                    {
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
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
                                                ProcessaCfVincular(new List<TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                    }
                                    else
                                    {
                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                        BindingSource dts = new BindingSource();
                                        dts.DataSource = new TList_NFCe_Item();
                                        Rel.DTS_Relatorio = dts;// bsItens;
                                        //DTS Cupom
                                        BindingSource bsNFCe = new BindingSource();
                                        bsNFCe.DataSource = TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
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
                                        (bsNFCe.Current as TRegistro_NFCe).lItem = TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                             (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
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
                                        TList_RegLanDuplicata lDup =
                                        new TCD_LanDuplicata().Select(
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
                                            bsPagto.DataSource = new List<TRegistro_MovCaixa>()
                                                                    {
                                                                        new TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = "05",
                                                                            Vl_recebido = lDup[0].Vl_documento
                                                                        }
                                                                    };
                                        else
                                            bsPagto.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
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
                                                                                            }).ToList();
                                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                        //Parametros
                                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
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
                                        string dadoscf = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
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
                                        if (TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                        {
                                            BindingSource bsItens = new BindingSource();
                                            bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                            Rel.DTS_Relatorio = bsItens;
                                        }
                                        if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue)
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
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                        if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                            (bsNFCe.Current as TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                    }
                            }
                            else
                                MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GerarNfe()
        {
            using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
            {
                fGerar.St_habilitarNfConsumo = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR EMITIR NF CONSUMO", null);
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            string pCd_clifor = fGerar.Cd_clifor;
                            if (string.IsNullOrEmpty(pCd_clifor))
                            {
                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                    pCd_clifor = linha["cd_clifor"].ToString();
                            }
                            if (!string.IsNullOrEmpty(pCd_clifor))
                            {
                                //Buscar endereco
                                TList_CadEndereco lEnd =
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
                                    DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
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
                                                                                              fGerar.St_gerarNfConsumo,
                                                                                              string.Empty,
                                                                                              lCfg[0],
                                                                                              fGerar.lItens,
                                                                                              ref rPed,
                                                                                              ref rPedServico);
                                TCN_Pedido_X_VendaRapida.ProcessarPedido(rPed, null);
                                //Buscar pedido
                                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                                //Se o CMI do pedido gerar financeiro
                                TList_RegLanParcela lParcVinculado = new TList_RegLanParcela();
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
                                new TCD_LanParcela().Select(
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
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                                //Vincular financeiro a Nota Fiscal
                                rFat.lParcAgrupar = lParcVinculado;
                                //Montar obs com placa-km
                                string obs = string.Empty;
                                string virgula = string.Empty;
                                fGerar.lItens.ForEach(p => p.Placa_KM = TCN_VendaRapida.BuscarPlacaKM(p.Cd_empresa, p.Id_vendarapida.Value.ToString(), null));
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
                            else
                                MessageBox.Show("Obrigatorio informar cliente da NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void miGerarNFe_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void cancelarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCancelarNFe fCanc = new TFCancelarNFe())
            {
                fCanc.Cd_empresa = lCfg[0].Cd_empresa;
                fCanc.Nm_empresa = lCfg[0].Nm_empresa;
                fCanc.St_nfce = true;
                fCanc.ShowDialog();
            }
        }

        private void ConsultaNfe(string Tp_documento)
        {
            using (Proc_Commoditties.TFLanConsultaNFe fNfe = new Proc_Commoditties.TFLanConsultaNFe())
            {
                fNfe.Tp_documento = Tp_documento;
                fNfe.ShowDialog();
            }
        }
        private void consultarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFCE");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        { 
            AlterarQuantidade();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        { 
            afterGrava(string.Empty);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        { 
            ExcluirItem();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        { 
            CancelarVenda();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        { 
            ConsultarPrecoVenda();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lbhora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void cancelarVendaRecebidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PDV.TFExcluirVendaRapida fGerar = new PDV.TFExcluirVendaRapida())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lVenda != null)
                        try
                        {
                            //Verificar se alguma venda possui pontos resgatados
                            if (fGerar.lVenda.Exists(p => p.PontosFidRes > decimal.Zero))
                            {
                                string loginCanc = string.Empty;
                                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                                {
                                    fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                                    if (fRegra.ShowDialog() == DialogResult.OK)
                                        loginCanc = fRegra.Login;
                                    else
                                    {
                                        MessageBox.Show("Obrigatório informar LOGIN com permissão para CANCELAR venda com pontos resgatados.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                fGerar.lVenda.Where(p => p.PontosFidRes > decimal.Zero).ToList().ForEach(p => p.LoginCancPontos = loginCanc);
                            }
                            TCN_VendaRapida.ExcluirVendaRapida(fGerar.lVenda, null);
                            MessageBox.Show("Venda Rapida Excluida com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                        MessageBox.Show("Não existe venda selecionada excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDados_TextChanged(object sender, EventArgs e)
        {
            if (txtDados.Text.Contains("\r"))
                txtDados.Text = txtDados.Text.Replace("\r", string.Empty);
            if (txtDados.Text.Contains("\n"))
                txtDados.Text = txtDados.Text.Replace("\n", string.Empty);
        }

        private void contasPagarReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceberFinanceiro();
        }

        private void ReceberFinanceiro()
        {
            if (rCaixa == null)
                throw new Exception("Não existe caixa aberto para o Login " + lSessao[0].Login);
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCaixa.Cd_empresa, null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração para realizar venda na empresa " + rCaixa.Cd_empresa.Trim() + ".",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFLanParcelas fParcelas = new TFLanParcelas())
            {
                fParcelas.Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", lCfg[0].Cd_empresa, null);
                fParcelas.pId_caixaoperacional = rCaixa.Id_caixa;
                fParcelas.Loginpdv = LoginPdv;
                fParcelas.Cd_contaoperacional = lCfg[0].Cd_contaoperacional;
                fParcelas.Ds_contaoperacional = lCfg[0].Ds_contaoperacional;
                fParcelas.ShowDialog();
            }
        }
    }
}
