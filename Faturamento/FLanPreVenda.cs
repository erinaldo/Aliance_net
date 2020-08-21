using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaNegocio.ConfigGer;
using CamadaDados.Financeiro.Duplicata;

namespace Faturamento
{
    public partial class TFLanPreVenda : Form
    {
        private bool Altera_Relatorio = false;
        private TTpModo vModo;
        private string TP_portadorPDV = string.Empty;
        private bool St_cartao = false;
        private decimal Pc_juro_fin = decimal.Zero;
        private string LoginDesconto = string.Empty;
        private string Vendedordefault = string.Empty;
        private string Empresadefault = string.Empty;
        //Verifica se item tem promoção
        private bool St_promocao = false;
        //Verifica se item tem prog especial de Venda
        private bool St_descEspecial = false;
        //Verifica se a Venda possui promoção ou Prog especial de Venda
        private bool St_promoDescEspecial = false;
        private decimal Tot_pontos_resgatar = decimal.Zero;

        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg;
        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;

        public TFLanPreVenda()
        {
            InitializeComponent();
            rProg = null;
        }

        private void BuscarPontosFid()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) && (!string.IsNullOrEmpty(CD_Clifor.Text)))
            {
                //Buscar Pontos Clifor
                object obj = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                }, "isnull(sum(isnull(a.qt_pontos - a.pontos_res, 0)), 0)");
                Tot_pontos_resgatar = obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
                if (Tot_pontos_resgatar > decimal.Zero)
                {
                    lblPontos.Text = "Pontos Resgatar: " + Tot_pontos_resgatar.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                    bb_resgatarPontos.Visible = true;
                }
                else
                {
                    lblPontos.Text = string.Empty;
                    Tot_pontos_resgatar = decimal.Zero;
                    bb_resgatarPontos.Visible = false;
                }
            }
        }

        private void ModoBotoes()
        {
            BB_Novo.Visible = vModo.Equals(TTpModo.tm_Standby);
            BB_Gravar.Visible = vModo.Equals(TTpModo.tm_Insert);
            BB_Excluir.Visible = vModo.Equals(TTpModo.tm_Standby);
            BB_Cancelar.Visible = vModo.Equals(TTpModo.tm_Insert);
        }

        private void HabilitarCampos()
        {
            CD_Empresa.Enabled = vModo.Equals(TTpModo.tm_Insert);
            BB_Empresa.Enabled = vModo.Equals(TTpModo.tm_Insert);
            CD_CompVend.Enabled = vModo.Equals(TTpModo.tm_Insert);
            BB_CompVend.Enabled = vModo.Equals(TTpModo.tm_Insert);
            CD_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert);
            BB_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_cadclifor.Enabled = vModo.Equals(TTpModo.tm_Insert);
            NM_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert);
            Cd_representante.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_representante.Enabled = vModo.Equals(TTpModo.tm_Insert);
            CD_TabelaPreco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_tabelapreco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            cd_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_cadEndereco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            ds_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert);
            numero.Enabled = vModo.Equals(TTpModo.tm_Insert);
            Bairro.Enabled = vModo.Equals(TTpModo.tm_Insert);
            proximo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            fone.Enabled = vModo.Equals(TTpModo.tm_Insert);
            cd_portador.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_portador.Enabled = vModo.Equals(TTpModo.tm_Insert);
            cd_cliforInd.Enabled = vModo.Equals(TTpModo.tm_Insert);
            bb_cliforInd.Enabled = vModo.Equals(TTpModo.tm_Insert);
            cd_produto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            Quantidade.Enabled = vModo.Equals(TTpModo.tm_Insert);
            vl_unitario.Enabled = vModo.Equals(TTpModo.tm_Insert);
            pc_desconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            vl_desconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            pc_acrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            vl_acrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            vl_frete.Enabled = vModo.Equals(TTpModo.tm_Insert);
            Ds_observacao.Enabled = vModo.Equals(TTpModo.tm_Insert);
            st_orcamento.Enabled = vModo.Equals(TTpModo.tm_Insert);
            st_condicional.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_vldesconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_pcdesconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_vlacrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_pcacrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
        }

        private void DesabilitarDescontos()
        {
            //Desabilitar os campos de desconto
            vl_desconto.Enabled = !St_promocao && !St_descEspecial;
            pc_desconto.Enabled = !St_promocao && !St_descEspecial;
            tot_pcdesconto.Enabled = !St_promoDescEspecial;
            tot_vldesconto.Enabled = !St_promoDescEspecial;
        }

        private void BuscarPromocao(CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda rItemPre)
        {
            if (rItemPre != null)
            {
                St_promocao = false;
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
                                                                                                rItemPre.Cd_produto,
                                                                                                rItemPre.Cd_grupo,
                                                                                                rProg,
                                                                                                rItemPre.Vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Where(p => p.Cd_produto.Trim().Equals(rItemPre.Cd_produto.Trim())).Sum(p => p.Quantidade) >= rPro.Qtd_minimavenda)
                        {
                            St_promocao = true;
                            St_promoDescEspecial = true;
                            (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Where(p => p.Cd_produto.Trim().Equals(rItemPre.Cd_produto.Trim())).ToList().ForEach(p =>
                                {
                                    if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                    {
                                        p.Pc_desconto = rPro.Vl_promocao;
                                        //Calcular desconto
                                        p.Vl_desconto = p.Vl_subtotal * (rPro.Vl_promocao / 100);
                                        //Calcular liquido
                                        p.Vl_liquido = p.Vl_subtotal - p.Vl_desconto;
                                    }
                                    else
                                    {
                                        p.Vl_desconto = rPro.Vl_promocao * p.Quantidade;
                                        //Calcular % Desconto
                                        p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                        if (p.Pc_desconto >= 100)
                                        {
                                            p.Vl_desconto = decimal.Zero;
                                            p.Pc_desconto = decimal.Zero;
                                        }
                                        //Calcular Liquido
                                        p.Vl_liquido = p.Vl_subtotal - p.Vl_desconto;
                                    }
                                });
                            bsPreVenda.ResetCurrentItem();
                        }
                        else
                        {
                            rItemPre.Vl_desconto = decimal.Zero;
                            rItemPre.Pc_desconto = decimal.Zero;
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            rItemPre.Pc_desconto = rPro.Vl_promocao;
                            //Calcular desconto
                            rItemPre.Vl_desconto = rItemPre.Vl_subtotal * (rPro.Vl_promocao / 100);
                            //Calcular liquido
                            rItemPre.Vl_liquido = rItemPre.Vl_subtotal - rItemPre.Vl_desconto;
                        }
                        else
                        {
                            rItemPre.Vl_desconto = rPro.Vl_promocao * rItemPre.Quantidade;
                            //Calcular % Desconto
                            rItemPre.Pc_desconto = rItemPre.Vl_desconto * 100 / rItemPre.Vl_subtotal;
                            if (rItemPre.Pc_desconto >= 100)
                            {
                                rItemPre.Vl_desconto = decimal.Zero;
                                rItemPre.Pc_desconto = decimal.Zero;
                            }
                            //Calcular Liquido
                            rItemPre.Vl_liquido = rItemPre.Vl_subtotal - rItemPre.Vl_desconto;
                        }
                        St_promoDescEspecial = true;
                        St_promocao = true;
                    }
                //Desabilitar os campos de desconto
                DesabilitarDescontos();
            }
        }

        private decimal CalcularDescEspecial(decimal Qtde,
                                             decimal Vl_unit)
        {
            St_descEspecial = false;
            if (rProg == null ? false : rProg.Tp_acresdesc.Trim().ToUpper().Equals("D"))
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.
                        Where(p => p.Cd_produto.Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        St_descEspecial = true;
                        St_promoDescEspecial = true;
                        DesabilitarDescontos();
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
                    DesabilitarDescontos();
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private decimal CalcularAcresEspecial(decimal Qtde,
                                              decimal Vl_unit)
        {
            if (rProg != null)
                if ((rProg.Valor > decimal.Zero) && rProg.Tp_acresdesc.Trim().ToUpper().Equals("A"))
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            else return decimal.Zero;
        }

        private void CalcularJuroFinPortador(decimal Pc_juro_fin)
        {
            if (bsPreVenda.Current != null)
            {
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.CalcularValorJuroFin(Pc_juro_fin, (p.Vl_subtotal + p.Vl_acrescimo - p.Vl_desconto)));
                bsPreVenda.ResetCurrentItem();
            }
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                         CD_Clifor.Text,
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

        private void TotalizarVenda()
        {
            if (bsPreVenda.Current != null)
                if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Count > 0)
                {
                    tot_pcdesconto.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Average(p => p.Pc_desconto);
                    tot_pcacrescimo.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Average(p => p.Pc_acrescimo);
                    tot_itens.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_subtotal);
                    tot_vldesconto.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_desconto);
                    tot_vlacrescimo.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_acrescimo);
                    tot_juro_fin.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_juro_fin);
                    tot_venda.Value = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_subtotal + p.Vl_acrescimo + p.Vl_juro_fin + p.Vl_frete - p.Vl_desconto);
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Vl_prevenda = tot_venda.Value;
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else
                {
                    tot_itens.Value = tot_itens.Minimum;
                    vl_frete.Value = vl_frete.Minimum;
                    tot_vldesconto.Value = tot_vldesconto.Minimum;
                    tot_pcdesconto.Value = tot_pcdesconto.Minimum;
                    tot_vlacrescimo.Value = tot_vlacrescimo.Minimum;
                    tot_pcacrescimo.Value = tot_pcacrescimo.Minimum;
                    tot_venda.Value = tot_venda.Minimum;
                    tot_juro_fin.Value = tot_juro_fin.Minimum;
                }

        }

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(rCfg.Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       rCfg.Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
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
                    Quantidade.DecimalPlaces = Convert.ToInt32(lProduto[0].CasasDecimais);
                    if (rCfg.St_obrigavendedorbool && string.IsNullOrEmpty(CD_CompVend.Text))
                    {
                        MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        CD_CompVend.Focus();
                        return false;
                    }
                    //Verificar saldo estoque do produto, somente para venda e condicional
                    if (rCfg.St_movestoquebool && (!st_orcamento.Checked))
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto))
                            {
                                decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, lProduto[0].CD_Produto);
                                if (saldo.Equals(decimal.Zero))
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + rCfg.Cd_local.Trim() + "-" + rCfg.Ds_local + "\r\n" +
                                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
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
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, p.Cd_item, rCfg.Cd_local, ref saldo, null);
                                    if (saldo < p.Quantidade)
                                        msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                               "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                });
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                    Quantidade.DecimalPlaces = Convert.ToInt32(lProduto[0].CasasDecimais);
                    Quantidade.Value = Convert.ToDecimal(Quantidade.Value.ToString("N" + Convert.ToInt32(lProduto[0].CasasDecimais), new System.Globalization.CultureInfo("pt-BR")));
                    //Cria novo item
                    bsItens.AddNew();
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).CasasDecimais = lProduto[0].CasasDecimais;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_unidade = lProduto[0].CD_Unidade;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_unidade = lProduto[0].DS_Unidade;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_Celula = lProduto[0].Ds_Celula;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_Rua = lProduto[0].Ds_Rua;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_Secao = lProduto[0].Ds_Secao;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Sigla_unidade = lProduto[0].Sigla_unidade;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo = lProduto[0].CD_Grupo;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_tabelaPreco = CD_TabelaPreco.Text;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ncm = lProduto[0].Ncm;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Quantidade = Quantidade.Value;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario = ConsultaPreco(lProduto[0].CD_Produto);
                    if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario > decimal.Zero)
                    {
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal =
                            Quantidade.Value * (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = CalcularDescEspecial(Quantidade.Value, Quantidade.Value * (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario);
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto * 100 /
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo = CalcularAcresEspecial(Quantidade.Value, Quantidade.Value * (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario);
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo * 100 /
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal;
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_liquido =
                            (Quantidade.Value * Quantidade.Value * (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario) - (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto + 
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo;
                    }
                    //Verificar se usuario´pode informar preço de Venda
                    vl_unitario.Enabled = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
                    bsItens.ResetCurrentItem();
                    //Buscar Promocao Venda
                    BuscarPromocao(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda);
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    CalcularJuroFin();
                    //Habilitar Campos Pre-Venda
                    CD_Empresa.Enabled = bsItens.Count.Equals(0);
                    BB_Empresa.Enabled = bsItens.Count.Equals(0);
                    CD_CompVend.Enabled = bsItens.Count.Equals(0);
                    BB_CompVend.Enabled = bsItens.Count.Equals(0);
                    CD_Clifor.Enabled = bsItens.Count.Equals(0);
                    BB_Clifor.Enabled = bsItens.Count.Equals(0);
                    bb_cadclifor.Enabled = bsItens.Count.Equals(0);
                    CD_TabelaPreco.Enabled = bsItens.Count.Equals(0);
                    bb_tabelapreco.Enabled = bsItens.Count.Equals(0);
                    cd_endereco.Enabled = bsItens.Count.Equals(0);
                    bb_endereco.Enabled = bsItens.Count.Equals(0);
                    bb_cadEndereco.Enabled = bsItens.Count.Equals(0);
                    st_orcamento.Enabled = bsItens.Count.Equals(0);
                    st_condicional.Enabled = bsItens.Count.Equals(0);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void LimparCampos()
        {
            bsPreVenda.Clear();
            cd_produto.Clear();
            numero.Clear();
            Bairro.Clear();
            fone.Clear();
            proximo.Clear();
            Quantidade.Value = 1;
            tot_pcdesconto.Value = tot_pcdesconto.Minimum;
            tot_pcacrescimo.Value = tot_pcacrescimo.Minimum;
            tot_itens.Value = tot_itens.Minimum;
            vl_frete.Value = vl_frete.Minimum;
            tot_vldesconto.Value = tot_vldesconto.Minimum;
            tot_vlacrescimo.Value = tot_vlacrescimo.Minimum;
            tot_venda.Value = tot_venda.Minimum;
            tot_juro_fin.Value = tot_juro_fin.Minimum;
        }

        private void afterNovo()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                vModo = TTpModo.tm_Insert;
                ModoBotoes();
                HabilitarCampos();
                bsPreVenda.AddNew();
                CD_CompVend.Text = Vendedordefault;
                CD_Empresa.Text = Empresadefault;
                if (!string.IsNullOrEmpty(CD_Empresa.Text))
                    CD_Empresa_Leave(this, new EventArgs());
		        bb_duplicata.Visible = false;
                St_cartao = false;
                St_promoDescEspecial = false;
                lblVlSubTotal.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                TP_portadorPDV = string.Empty;
                cd_produto.Focus();
            }
            else
                MessageBox.Show("Já existe uma venda em andamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterGrava()
        {
            if (vModo == TTpModo.tm_Insert)
                if (pDados.validarCampoObrigatorio())
                {
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Count < 1)
                    {
                        MessageBox.Show("Não é permitido gravar pré venda sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Exists(p => p.Quantidade.Equals(decimal.Zero)))
                    {
                        MessageBox.Show("Não é permitido gravar pré venda que possui item com quantidade zero.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (rCfg.St_portadorprevendabool.Equals(true) && 
                        string.IsNullOrEmpty(cd_portador.Text) && 
                        !st_orcamento.Checked &&
                        !st_condicional.Checked)
                    {
                        MessageBox.Show("Obrigatório informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (rCfg.St_obrigavendedorbool && string.IsNullOrEmpty(CD_CompVend.Text))
                    {
                        MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_CompVend.Focus();
                        return;
                    }
                    if (TP_portadorPDV.Trim().ToUpper().Equals("P"))
                    {
                        if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Count.Equals(0) &&
                            (tot_venda.Value - vl_devcred.Value) > 0)
                        {
                            MessageBox.Show("Não é permitido gravar pré venda com portador NOTAS A COBRAR sem informar PARCELAS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Sum(p => p.Vl_parcela) != (tot_venda.Value - vl_devcred.Value))
                        {
                            MessageBox.Show("Não é permitido gravar pré venda com valor das PARCELAS diferente do valor da VENDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    
                    if (st_condicional.Checked &&
                        (string.IsNullOrEmpty(CD_Clifor.Text) ||
                        CD_Clifor.Text.Trim().Equals(rCfg.Cd_clifor.Trim())))
                    {
                        MessageBox.Show("Não é permitido gravar venda CONDICIONAL sem identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if((!st_orcamento.Checked) && 
                        TP_portadorPDV.Trim().ToUpper().Equals("P"))
                        if (!bloqueioCredito())
                        {
                            MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                           "Venda não poderá ser concluida.", "Mensagem", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Gravar(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, null);
                        bsPreVenda.ResetCurrentItem();
                        //Alterar Layout Tela
                        vModo = TTpModo.tm_Standby;
                        ModoBotoes();
                        HabilitarCampos();
                        TP_portadorPDV = string.Empty;
                        St_cartao = false;
                        Pc_juro_fin = decimal.Zero;
                        if (new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_impvendaauto, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "1") != null)
                            Print();
                        else
                            MessageBox.Show("Pré venda Nº" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr +
                                " gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                if (bsPreVenda.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão da pré venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(new List<CamadaDados.Faturamento.PDV.TRegistro_PreVenda>(){ bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda }, null);
                            MessageBox.Show("Pré venda excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterCancela();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    using (TFListaPreVenda fLista = new TFListaPreVenda())
                    {
                        fLista.LoginPDV = Utils.Parametros.pubLogin;
                        if(fLista.ShowDialog() == DialogResult.OK)
                            if(fLista.lVenda != null)
                                try
                                {
                                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(fLista.lVenda, null);
                                    MessageBox.Show("Pré venda excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterCancela()
        {
            if (vModo != TTpModo.tm_Insert)
            {
                vModo = TTpModo.tm_Standby;
                ModoBotoes();
                HabilitarCampos();
                LimparCampos();
                TP_portadorPDV = string.Empty;
                bb_duplicata.Visible = false;
                St_cartao = false;
                Pc_juro_fin = decimal.Zero;
                Tot_pontos_resgatar = decimal.Zero;
            }
            else if (MessageBox.Show("Deseja cancelar lançamento da PRÉ-VENDA?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                vModo = TTpModo.tm_Standby;
                ModoBotoes();
                HabilitarCampos();
                LimparCampos();
                TP_portadorPDV = string.Empty;
                bb_duplicata.Visible = false;
                St_cartao = false;
                Pc_juro_fin = decimal.Zero;
                Tot_pontos_resgatar = decimal.Zero;
            }
        }

        private void ExcluirItem()
        {
            if (vModo.Equals(TTpModo.tm_Insert))
                if (bsItens.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Verificar se item possui promocao
                        CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                        CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
                                                                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto,
                                                                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo,
                                                                                                    null,
                                                                                                    decimal.Zero,
                                                                                                    null);
                        if(rPro != null)
                            if(rPro.Qtd_minimavenda > 1)
                                if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto.Trim())).Sum(p => p.Quantidade) - 
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Quantidade < rPro.Qtd_minimavenda)
                                {
                                    //Verificar se tem programacao especial de venda
                                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                        CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                                     CD_Clifor.Text,
                                                                                                                     (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto,
                                                                                                                     CD_TabelaPreco.Text,
                                                                                                                     null);
                                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto.Trim())).ToList().ForEach(p =>
                                    {
                                        if (rProgAux != null)
                                        {
                                            if (rProgAux.Valor > decimal.Zero)
                                            {
                                                if (rProgAux.Tp_valor.Trim().ToUpper().Equals("V"))
                                                {
                                                    p.Vl_desconto = p.Quantidade * rProgAux.Valor;
                                                    p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                                    p.Vl_liquido = p.Vl_subtotal - p.Vl_desconto + p.Vl_acrescimo;
                                                }
                                                else
                                                {
                                                    p.Vl_desconto = p.Vl_subtotal * rProgAux.Valor / 100;
                                                    p.Pc_desconto = rProgAux.Valor;
                                                    p.Vl_liquido = p.Vl_subtotal - p.Vl_desconto + p.Vl_acrescimo;
                                                }
                                            }
                                            else
                                            {
                                                p.Vl_desconto = decimal.Zero;
                                                p.Pc_desconto = decimal.Zero;
                                                p.Vl_acrescimo = decimal.Zero;
                                                p.Pc_acrescimo = decimal.Zero;
                                                p.Vl_liquido = p.Vl_subtotal;
                                            }
                                        }
                                        else
                                        {
                                            p.Vl_desconto = decimal.Zero;
                                            p.Pc_desconto = decimal.Zero;
                                            p.Vl_acrescimo = decimal.Zero;
                                            p.Pc_acrescimo = decimal.Zero;
                                            p.Vl_liquido = p.Vl_subtotal;
                                        }
                                    });
                                    bsPreVenda.ResetCurrentItem();
                                }
                        if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados > decimal.Zero)
                        {
                            Tot_pontos_resgatar += (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados;
                            lblPontos.Text = "Pontos Resgatar: " + Tot_pontos_resgatar.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                            bb_resgatarPontos.Visible = true;
                        }
                        if((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Id_itemprevenda.HasValue)
                            (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItensDel.Add(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda);
                        bsItens.RemoveCurrent();
                        TotalizarVenda();
                        //Habilitar Campos Pre-Venda
                        CD_Empresa.Enabled = bsItens.Count.Equals(0);
                        BB_Empresa.Enabled = bsItens.Count.Equals(0);
                        CD_CompVend.Enabled = bsItens.Count.Equals(0);
                        BB_CompVend.Enabled = bsItens.Count.Equals(0);
                        CD_Clifor.Enabled = bsItens.Count.Equals(0);
                        BB_Clifor.Enabled = bsItens.Count.Equals(0);
                        bb_cadclifor.Enabled = bsItens.Count.Equals(0);
                        CD_TabelaPreco.Enabled = bsItens.Count.Equals(0);
                        bb_tabelapreco.Enabled = bsItens.Count.Equals(0);
                        cd_endereco.Enabled = bsItens.Count.Equals(0);
                        bb_endereco.Enabled = bsItens.Count.Equals(0);
                        bb_cadEndereco.Enabled = bsItens.Count.Equals(0);
                        st_orcamento.Enabled = bsItens.Count.Equals(0);
                        st_condicional.Enabled = bsItens.Count.Equals(0);
                    }
                }
                else
                    MessageBox.Show("Não existe item selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddLocacao()
        {
            using (Faturamento.TFLocacao fLocacao = new Faturamento.TFLocacao())
            {
                if (bsPreVenda.Current != null)
                    fLocacao.rPreVenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                if (fLocacao.ShowDialog() == DialogResult.OK)
                    if (fLocacao.rLocacao != null)
                        try
                        {
                            if ((bsPreVenda.Current != null) && (vModo != TTpModo.tm_Standby))
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                                CamadaNegocio.Faturamento.Locacao.TCN_Locacao.ProcessarLocacaoPreVenda(fLocacao.rLocacao,
                                                                                                       ref rPreVenda,
                                                                                                       null);
                                bsPreVenda.ResetCurrentItem();
                                MessageBox.Show("Pré venda Nº" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr +
                                                " gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Alterar Layout Tela
                                vModo = TTpModo.tm_Standby;
                                ModoBotoes();
                                HabilitarCampos();
                            }
                            else
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                                CamadaNegocio.Faturamento.Locacao.TCN_Locacao.ProcessarLocacaoPreVenda(fLocacao.rLocacao,
                                                                                                       ref rPreVenda,
                                                                                                       null);
                                bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { rPreVenda };
                                TotalizarVenda();
                                MessageBox.Show("Pré venda Nº" + rPreVenda.Id_prevendastr +
                                                " gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ConsultaPreVenda()
        {
            using (TFConsultaPreVenda cPreVenda = new TFConsultaPreVenda())
            {
                cPreVenda.rCfg = rCfg;
                cPreVenda.ShowDialog();
                if (cPreVenda.rVenda != null)
                {
                    vModo = TTpModo.tm_Insert;
                    ModoBotoes();
                    HabilitarCampos();
                    rCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(cPreVenda.rVenda.Cd_empresa, null)[0];
                    cd_produto.ST_Int = rCfg.St_produtocodigobool;
                    bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { cPreVenda.rVenda };
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.ForEach(p=> p.Vl_liquido = p.Vl_subtotal - p.Vl_desconto + p.Vl_acrescimo);
                    if (!string.IsNullOrEmpty((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_portador))
                    {
                        //Buscar Tipo Portador a prazo
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_portador",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_portador.Trim() + "'"
                                            }
                                        }, "a.tp_portadorpdv");
                        if (obj != null)
                            TP_portadorPDV = obj.ToString();

                        //Buscar se Portador é cartão
                        object obj1 = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_portador",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_portador.Trim() + "'"
                                            }
                                        }, "a.ST_CartaoCredito");
                        if (obj1 != null)
                            St_cartao = obj1.Equals(false);

                        if (St_cartao || TP_portadorPDV.ToUpper().Equals("P"))
                        {
                            bb_duplicata.Visible = true;
                            pParcelas.Visible = true;
                        }
                    }
                    if(!string.IsNullOrEmpty(cPreVenda.rVenda.Cd_vendedor))
                        if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cPreVenda.rVenda.Cd_vendedor.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_clifor x " +
                                                "where x.id_regiao = a.id_regiao " +
                                                "and x.cd_clifor = '" + cPreVenda.rVenda.Cd_clifor.Trim() + "')"
                                }
                            }, "1") != null)
                        {
                            CD_CompVend.Enabled = false;
                            BB_CompVend.Enabled = false;
                        }
                    Busca_Endereco_Clifor();
                    TotalizarVenda();
                    cd_produto.Focus();
                }
            }
        }

        private void DevolverLocacao()
        {
            using (TFDevolverLocacao fDevolver = new TFDevolverLocacao())
            {
                if (bsPreVenda.Current != null)
                    fDevolver.rPreVenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                if(fDevolver.ShowDialog() == DialogResult.OK)
                    if(fDevolver.rLocacao != null)
                        try
                        {
                            if ((bsPreVenda.Current != null) && (vModo != TTpModo.tm_Standby))
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                                CamadaNegocio.Faturamento.Locacao.TCN_Locacao.DevolverLocacao(fDevolver.rLocacao,
                                                                                              ref rPreVenda,
                                                                                              null);
                                bsPreVenda.ResetCurrentItem();
                                MessageBox.Show("Devolução da locação realizada com sucesso.\r\nPré venda Nº" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr +
                                                " gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Alterar Layout Tela
                                vModo = TTpModo.tm_Standby;
                                ModoBotoes();
                                HabilitarCampos();
                            }
                            else
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                                CamadaNegocio.Faturamento.Locacao.TCN_Locacao.DevolverLocacao(fDevolver.rLocacao,
                                                                                              ref rPreVenda,
                                                                                              null);
                                string msg = "Devolução da locação realizada com sucesso.";
                                if (rPreVenda != null)
                                {
                                    bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { rPreVenda };
                                    msg += "\r\nPré venda Nº" + rPreVenda.Id_prevendastr +
                                                " gravada com sucesso.";
                                }
                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CalcularDesconto(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_desconto.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = vl_desconto.Value;
                if (pc_desconto.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = pc_desconto.Value;
                if (St_percentual)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto =
                        Math.Round((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal *
                        ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto / 100), 2, MidpointRounding.AwayFromZero);
                else
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto =
                        Math.Round((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto * 100 / (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_liquido =
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal - (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto +
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo;
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                    CD_Empresa.Text,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc.Equals(0) ||
                    ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc <
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto))
                    if (lDesc.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                p.Cd_grupo.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo.Trim())).Pc_max_desconto;
                                if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                                {
                                    MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_grupo = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo;
                                        fLogin.Cd_empresa = CD_Empresa.Text;
                                        fLogin.Pc_desc = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto;
                                        if (fLogin.ShowDialog() != DialogResult.OK)
                                        {
                                            vl_desconto.Value = decimal.Zero;
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = decimal.Zero;
                                            pc_desconto.Value = decimal.Zero;
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = decimal.Zero;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            pc_desconto.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                            LoginDesconto = fLogin.Logindesconto;
                                            return;
                                        }
                                    }
                                }
                                else return;
                            }
                            else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                            {
                                //Desconto por tabela de preço
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                                if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                                {
                                    MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_empresa = CD_Empresa.Text;
                                        fLogin.Pc_desc = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto;
                                        if (fLogin.ShowDialog() != DialogResult.OK)
                                        {
                                            vl_desconto.Value = decimal.Zero;
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = decimal.Zero;
                                            pc_desconto.Value = decimal.Zero;
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = decimal.Zero;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            pc_desconto.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                            LoginDesconto = fLogin.Logindesconto;
                                            return;
                                        }
                                    }
                                }
                                else return;
                            }
                        //Desconto por grupo de produto
                        if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo.Trim())))
                        {
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo.Trim())).Pc_max_desconto;
                            if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                            {
                                MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_grupo = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_grupo;
                                    fLogin.Cd_empresa = CD_Empresa.Text;
                                    fLogin.Pc_desc = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                    {
                                        vl_desconto.Value = decimal.Zero;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = decimal.Zero;
                                        pc_desconto.Value = decimal.Zero;
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = decimal.Zero;
                                        bsItens.ResetCurrentItem();
                                        TotalizarVenda();
                                        pc_desconto.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                        LoginDesconto = fLogin.Logindesconto;
                                        return;
                                    }
                                }
                            }
                            else return;
                        }
                        //Desconto por vendedor e empresa
                        if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto > lDesc[0].Pc_max_desconto && (!St_promocao) && (!St_descEspecial))
                        {
                            MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_empresa = CD_Empresa.Text;
                                fLogin.Pc_desc = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    vl_desconto.Value = decimal.Zero;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = decimal.Zero;
                                    pc_desconto.Value = decimal.Zero;
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = decimal.Zero;
                                    bsItens.ResetCurrentItem();
                                    TotalizarVenda();
                                    pc_desconto.Focus();
                                    return;
                                }
                                else
                                {
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                    LoginDesconto = fLogin.Logindesconto;
                                    return;
                                }
                            }
                        }
                        else return;
                    }
            }
            
        }

        private void CalcularAcrescimo(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_acrescimo.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo = vl_acrescimo.Value;
                if (pc_acrescimo.Focused)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo = pc_acrescimo.Value;
                if (St_percentual)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo =
                        Math.Round((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal *
                        ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo / 100), 2, MidpointRounding.AwayFromZero);
                else
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo =
                        Math.Round((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo * 100 / (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_liquido =
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal - (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto + 
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo;
                bsItens.ResetCurrentItem();
                TotalizarVenda();
            }

        }

        private void Print()
        {
            if (vModo != TTpModo.tm_Standby)
            {
                MessageBox.Show("Para imprimir VENDA, obrigatório antes GRAVAR a mesma.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bsPreVenda.Current != null)
            {
                if (!(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_registro.Trim().ToUpper().Equals("C"))
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
                    if (lTerminal.Count.Equals(0) ? false : lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                    {
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lTerminal[0].Cd_Terminal.Trim() + "'"
                                            }
                                        }, "a.tp_impnaofiscal");
                        if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                            throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                        //Imprimir
                        ImprimirReduzido(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, lTerminal[0].Porta_imptick, obj == null ? string.Empty : obj.ToString());
                    }
                    else if (lTerminal.Count.Equals(0) ? false : lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLanPreVendaGraficoReduzido";
                        Relatorio.NM_Classe = "TFLanPreVendaGraficoReduzido";
                        Relatorio.Modulo = string.Empty;


                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor,
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


                        //buscar nome vendedor
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_vendedor.Trim() + "'"
                                    }
                                }, "a.nm_clifor");

                        if (obj != null)
                            (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Nm_vendedor = obj.ToString();

                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = "FLanPreVendaGraficoReduzido";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        //Verificar se existe Impressora padrão para o PDV
                        object objIMP = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
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
                        print = objIMP == null ? string.Empty : objIMP.ToString();
                        if (string.IsNullOrEmpty(print))
                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                            {
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                        print = fLista.Impressora;

                            }
                        //Imprimir
                        if(!string.IsNullOrEmpty(print))
                            Relatorio.ImprimiGraficoReduzida(print,
                                                             true,
                                                             false,
                                                             null,
                                                             string.Empty,
                                                             string.Empty,
							                                 1);
                        Altera_Relatorio = false;
                    }
                    else
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLanPreVenda";
                        Relatorio.NM_Classe = "TFLanPreVenda";
                        Relatorio.Modulo = string.Empty;


                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(
                                                                          (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor,
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

                        //buscar nome vendedor
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_vendedor.Trim() + "'"
                                    }
                                }, "a.nm_clifor");

                        if (obj != null)
                            (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Nm_vendedor = obj.ToString();


                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = new CamadaDados.Faturamento.PDV.TList_PreVenda() { bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = "FLanPreVenda";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor;
                                fImp.pMensagem = "ORÇAMENTO Nº " + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "ORÇAMENTO Nº " + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr,
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
            }
            else
                ConsultaPreVenda();
        }

        private void BuscarProduto()
        {
            if (rCfg == null ? false : !rCfg.St_produtocodigobool)
            {
                if (string.IsNullOrEmpty(cd_produto.Text))
                {
                    if (UtilPesquisa.BuscarProduto(string.Empty,
                                                            CD_Empresa.Text,
                                                            NM_Empresa.Text,
                                                            CD_TabelaPreco.Text,
                                                            new Componentes.EditDefault[] { cd_produto },
                                                            null) == null)
                    {
                        MessageBox.Show("Produto Inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        cd_produto.Focus();
                        return;
                    }
                }
                else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                    if (UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                         CD_Empresa.Text,
                                                         NM_Empresa.Text,
                                                         CD_TabelaPreco.Text,
                                                         new Componentes.EditDefault[] { cd_produto },
                                                         null) == null)
                    {
                        MessageBox.Show("Produto Inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        cd_produto.Focus();
                        return;
                    }
            }
            if (BuscarItens())
            {
                cd_produto.Clear();
                vl_frete_Leave(this, new EventArgs());
                Quantidade.Focus();
            }
            else
            {
                MessageBox.Show("Produto inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Clear();
                cd_produto.Focus();
            }
            AddCarrinho();
            LoginDesconto = string.Empty;
        }

        private void Busca_Endereco_Clifor()
        {
           //Busca Endereço 
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor.Trim() + "'"
                        }
                    }, 0, string.Empty);
                if (List_Endereco.Count > 0)
                {
                    if (List_Endereco.Exists(p => p.St_enderecoentregabool))
                    {
                        cd_endereco.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Cd_endereco.Trim();
                        ds_endereco.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Ds_endereco.Trim();
                        numero.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Numero.Trim();
                        Bairro.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Bairro.Trim();
                        fone.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Fone.Trim();
                        proximo.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Proximo.Trim();
                    }
                    else
                    {
                        cd_endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                        numero.Text = List_Endereco[0].Numero.Trim();
                        Bairro.Text = List_Endereco[0].Bairro.Trim();
                        fone.Text = List_Endereco[0].Fone.Trim();
                        proximo.Text = List_Endereco[0].Proximo.Trim();
                    }
                }
            }

        private void Entregar()
        {
            if (bsItens.Count > 0)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Id_prevendastr))
                {
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_orcamentobool)
                    {
                        MessageBox.Show("Não é permitido gerar romaneio de entrega para orçamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se pre venda esta faturada
                    if (new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().BuscarEscalar(
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
                                    vNM_Campo = "isnull(cf.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_cupom = a.id_cupom " +
                                                "and x.id_lancto = a.id_lancto " +
                                                "and x.cd_empresa = '" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_empresa.Trim() + "' " +
                                                "and x.id_prevenda = " + (bsPreVenda.Current as  CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr + ")"
                                }
                            }, "1") != null)
                    {
                        MessageBox.Show("Não é permitido Entregar venda FATURADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        using (TFItensEntrega fItensEntrega = new TFItensEntrega())
                        {
                            fItensEntrega.rPrevenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                            if (fItensEntrega.ShowDialog() == DialogResult.OK)
                                if (fItensEntrega.rEntrega != null)
                                {
                                    if (fItensEntrega.rEntrega.lItens.Count > decimal.Zero)
                                    {
                                        CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Gravar(fItensEntrega.rEntrega, null);
                                        MessageBox.Show("Romaneio de Entrega Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Excluir(fItensEntrega.rEntrega, null);
                                        MessageBox.Show("Romaneio de Entrega Excluido com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                        }
                    }

                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Necessário gravar a PreVenda para entregar os Itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Não existem Itens para serem Entregues!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void AddCarrinho()
        {
            if (bsItens.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto,
                                                                                            string.Empty,
                                                                                            null);
                if (lAssistente.Count > 0)
                {
                    using (TFAssistenteVenda fAssistente = new TFAssistenteVenda())
                    {
                        lAssistente.ForEach(p => p.Vl_unitario = ConsultaPreco(p.CD_ProdVenda));
                        fAssistente.lAssistente = lAssistente;
                        fAssistente.Cd_empresa = CD_Empresa.Text;
                        fAssistente.Nm_empresa = NM_Empresa.Text;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                    {
                                        CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda rItemPre = new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda();
                                        rItemPre.Cd_produto = p.CD_ProdVenda;
                                        rItemPre.Ds_produto = p.DS_ProdVenda;
                                        rItemPre.Cd_unidade = p.CD_Unidade;
                                        rItemPre.Ds_unidade = p.DS_Unidade;
                                        rItemPre.Sigla_unidade = p.Sigla_Unidade;
                                        rItemPre.Ncm = p.NCM;
                                        rItemPre.Vl_unitario = ConsultaPreco(p.CD_ProdVenda);
                                        rItemPre.Quantidade = p.Quantidade; 
                                        if(rItemPre.Vl_unitario > decimal.Zero)
                                        {
                                            rItemPre.Vl_subtotal = rItemPre.Vl_unitario * rItemPre.Quantidade;
                                            rItemPre.Vl_desconto = CalcularDescEspecial(Quantidade.Value, Quantidade.Value * rItemPre.Vl_unitario);
                                            rItemPre.Pc_desconto = rItemPre.Vl_desconto * 100 / rItemPre.Vl_subtotal;
                                            rItemPre.Vl_acrescimo = CalcularAcresEspecial(Quantidade.Value, Quantidade.Value * rItemPre.Vl_unitario);
                                            rItemPre.Pc_acrescimo = rItemPre.Vl_acrescimo * 100 / rItemPre.Vl_subtotal;
                                            rItemPre.Vl_liquido = (rItemPre.Quantidade * rItemPre.Quantidade * rItemPre.Vl_unitario) - rItemPre.Vl_desconto + rItemPre.Vl_acrescimo;
                                        }
                                        //Buscar Promocao Venda
                                        BuscarPromocao(rItemPre);
                                        (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Add(rItemPre);
                                    });        
                                bsPreVenda.ResetCurrentItem();
                                CalcularJuroFin();
                            }
                    }
                }
            }
        }

        private void CalcularJuroFin()
        {
            if (!St_cartao && (!TP_portadorPDV.Trim().ToUpper().Equals("P")) && (Pc_juro_fin > decimal.Zero))
            {
                CalcularJuroFinPortador(Pc_juro_fin);
                TotalizarVenda();
            }
            else
            {
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_condPgto = string.Empty;
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto.Clear();
                (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.ForEach(p => p.Vl_juro_fin = decimal.Zero);
                bsPreVenda.ResetCurrentItem();
                TotalizarVenda();
            }
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty(CD_Clifor.Text)) &&
                (!CD_Clifor.Text.Equals(rCfg.Cd_clifor)))
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(CD_Clifor.Text,
                                                                                                  tot_venda.Value,
                                                                                                  true,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = tot_venda.Value;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private void BuscarCreditos()
        {
            //Verificar se cliente possui adiantamento
            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdiant =
            new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                    new TpBusca[]
                            { 
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
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
            if (lAdiant.Count > 0)
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Casas_decimais = 2;
                    fQtde.Ds_label = "Devolver Crédito";
                    fQtde.Vl_saldo = lAdiant.Sum(p => p.Vl_total_devolver) > tot_venda.Value ? tot_venda.Value : lAdiant.Sum(p => p.Vl_total_devolver);
                    if (fQtde.ShowDialog() == DialogResult.OK)
                        vl_devcred.Value = fQtde.Quantidade;
                }
        }

        private void ImprimirReduzido(CamadaDados.Faturamento.PDV.TRegistro_PreVenda val, string porta, string Tp_impressora)
        {
            //Buscar dados da empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
            if (lEmpresa.Count < 1)
                throw new Exception("Não foi possivel localizar empresa " + val.Cd_empresa);
            if (!string.IsNullOrEmpty(Tp_impressora))
            {
                PDV.TGerenciarImpNaoFiscal.IniciarPorta(porta);
                try
                {
                    StringBuilder imp = new StringBuilder();
                    imp.AppendLine("  PRÉ-VENDA  N: " + val.Id_prevendastr + "  " + val.Dt_emissaostr);
                    imp.AppendLine(" =========================================");
                    imp.AppendLine("               DADOS EMPRESA              ");
                    imp.AppendLine(" =========================================");
                    imp.AppendLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                    imp.AppendLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                    imp.AppendLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("               DADOS CLIENTE              ");
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("  " + val.Cd_clifor.Trim() + "-" + val.Nm_clifor.Trim().ToUpper());
                    if ((rCfg.Cd_clifor != val.Cd_clifor) && (!string.IsNullOrEmpty(CD_Clifor.Text)))
                    {
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, null);
                        if (!string.IsNullOrEmpty(rCliente.Nm_fantasia))
                            imp.AppendLine("  " + rCliente.Nm_fantasia.Trim().ToUpper());
                        if (rCfg.St_impcpfcnpjbool)
                        {
                            if ((!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero())) ||
                                (!string.IsNullOrEmpty(rCliente.Nr_cpf.SoNumero())))
                                imp.AppendLine("  CNPJ/CPF: " + (!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero()) ? rCliente.Nr_cgc : rCliente.Nr_cpf));
                        }
                    }
                    imp.Append("  " + val.Ds_endereco.Trim().ToUpper());
                    if ((rCfg.Cd_clifor != val.Cd_clifor) && (!string.IsNullOrEmpty(CD_Clifor.Text)))
                    {
                        //Buscar Endereco do cliente
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                            }
                        }, 0, string.Empty);
                        if (lEndereco.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(lEndereco[0].Numero))
                                imp.AppendLine(", " + lEndereco[0].Numero.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].Bairro))
                                imp.AppendLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].DS_Cidade))
                                imp.AppendLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                            if (!string.IsNullOrEmpty(lEndereco[0].Fone.SoNumero()))
                            {
                                imp.AppendLine("  " + lEndereco[0].Fone.Trim().ToUpper() +
                                    (!string.IsNullOrEmpty(lEndereco[0].Celular.SoNumero()) ? "/" + lEndereco[0].Celular.Trim().ToUpper() : string.Empty));
                            }
                            if (!string.IsNullOrEmpty(lEndereco[0].Cep.SoNumero()))
                                imp.AppendLine("  CEP: " + lEndereco[0].Cep);
                            if (!string.IsNullOrEmpty(lEndereco[0].Proximo))
                                imp.AppendLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                        }
                    }
                    else
                    {
                        imp.AppendLine();
                        imp.AppendLine();
                    }
                    if (!string.IsNullOrEmpty(val.Nm_vendedor)) 
                    {
                        imp.AppendLine(("  VENDEDOR: " + val.Nm_vendedor.Trim()).FormatStringDireita(42, ' '));
                    }

                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("  PRODUTO  QTD      VAL.UNIT  SUBTOTAL");
                    imp.AppendLine(" -----------------------------------------");

                    val.lItens.ForEach(p =>
                    {
                        imp.AppendLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                        imp.Append(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(13, ' ') + "x");
                        imp.Append(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' '));
                        imp.Append(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                        imp.AppendLine();
                        if (p.Vl_desconto > decimal.Zero)
                            imp.AppendLine(" DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_acrescimo > decimal.Zero)
                            imp.AppendLine(" ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_juro_fin > decimal.Zero)
                            imp.AppendLine(" JURO FIN.: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    });

                    imp.Append(" -----------------------------------------------");
                    imp.Append("  ACRESCIMOS JUROS FIN.  FRETE DESCONTO  LIQUIDO");
                    imp.Append(val.lItens.Sum(p => p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_juro_fin).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_frete).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(7, ' '));
                    imp.Append(val.lItens.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    imp.AppendLine(val.lItens.Sum(p => p.Vl_liquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    imp.AppendLine(" -------------------------------------------");
                    if (!string.IsNullOrEmpty(val.Cd_portador))
                        imp.AppendLine("  FORMA PGTO : " + val.Cd_portador.Trim() + "-" + val.Ds_portador.Trim());
                    //Buscar Parcelas
                    CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto lParc =
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda_DT_Vencto.Buscar(val.Id_prevendastr,
                                                                                    val.Cd_empresa,
                                                                                    null);
                    if (lParc.Count > 0)
                    {
                        imp.AppendLine("  COND.PGTO  : " + val.Cd_condPgto.Trim() + "-" + val.Ds_condPgto.Trim());
                        imp.AppendLine("  VENCIMENTO          VALOR ");
                        lParc.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                            imp.AppendLine("  " + p.Dt_vencto.ToString("dd/MM/yyyy").FormatStringDireita(20, ' ') + p.Vl_parcela.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))));
                        imp.AppendLine();
                        imp.AppendLine();
                    }
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("                Cliente               ");
                    imp.AppendLine();
                    imp.AppendLine();
                    //Imprimir observacao cupom
                    if (!string.IsNullOrEmpty(val.Ds_observacao))
                    {
                        string obs = val.Ds_observacao.Trim();
                        imp.AppendLine(" -----------------------------------------");
                        imp.AppendLine("              OBSERVAÇÕES                 ");
                        imp.AppendLine(" -----------------------------------------");
                        while (true)
                        {
                            if (obs.Length <= 40)
                            {
                                imp.AppendLine("  " + obs);
                                break;
                            }
                            else
                            {
                                imp.AppendLine("  " + obs.Substring(0, 40));
                                obs = obs.Remove(0, 40);
                            }
                        }
                    }
                    imp.AppendLine(" -----------------------------------------");
                    imp.AppendLine("      Este recibo nao tem valor Fiscal    ");
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();
                    imp.AppendLine();
                    
                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                finally
                { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
            }
            else
            {
                System.IO.FileInfo f = null;
                System.IO.StreamWriter w = null;
                f = new System.IO.FileInfo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + "Orcamento.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine("  PRÉ-VENDA  N: " + val.Id_prevendastr + "  " + val.Dt_emissaostr);
                    w.WriteLine(" =========================================");
                    w.WriteLine("               DADOS EMPRESA              "); 
                    w.WriteLine(" =========================================");
                    w.WriteLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                    w.WriteLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                    w.WriteLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("               DADOS CLIENTE              ");
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  " + val.Cd_clifor.Trim() + "-" + val.Nm_clifor.Trim().ToUpper());
                    if ((rCfg.Cd_clifor != val.Cd_clifor) && (!string.IsNullOrEmpty(CD_Clifor.Text)))
                    {
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, null);
                        if (!string.IsNullOrEmpty(rCliente.Nm_fantasia))
                            w.WriteLine("  " + rCliente.Nm_fantasia.Trim().ToUpper());
                        if (rCfg.St_impcpfcnpjbool)
                        {
                            if ((!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero())) ||
                                (!string.IsNullOrEmpty(rCliente.Nr_cpf.SoNumero())))
                                w.WriteLine("  CNPJ/CPF: " + (!string.IsNullOrEmpty(rCliente.Nr_cgc) ? rCliente.Nr_cgc : rCliente.Nr_cpf));
                        }
                    }
                    w.Write("  " + val.Ds_endereco.Trim().ToUpper());
                    if ((rCfg.Cd_clifor != val.Cd_clifor) && (!string.IsNullOrEmpty(CD_Clifor.Text)))
                    {
                        //Buscar Endereco do cliente
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                            }
                        }, 0, string.Empty);
                        if (lEndereco.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(lEndereco[0].Numero))
                                w.WriteLine(", " + lEndereco[0].Numero.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].Bairro))
                                w.WriteLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                            if (!string.IsNullOrEmpty(lEndereco[0].DS_Cidade))
                                w.WriteLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                            if (!string.IsNullOrEmpty(lEndereco[0].Fone.SoNumero()))
                            {
                                w.WriteLine("  " + lEndereco[0].Fone.Trim().ToUpper() +
                                    (!string.IsNullOrEmpty(lEndereco[0].Celular.SoNumero()) ? "/" + lEndereco[0].Celular.Trim().ToUpper() : string.Empty));
                            }
                            if (!string.IsNullOrEmpty(lEndereco[0].Cep.SoNumero()))
                                w.WriteLine("  CEP: " + lEndereco[0].Cep);
                            if (!string.IsNullOrEmpty(lEndereco[0].Proximo))
                                w.WriteLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                        }
                    }
                    else
                    {
                        w.WriteLine();
                        w.WriteLine();
                    }
                    if (!string.IsNullOrEmpty(val.Cd_vendedor))
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                    }
                                }, 0, string.Empty);
                        w.WriteLine(("  VENDEDOR: " + lClifor[0].Nm_clifor.Trim()).FormatStringDireita(42, ' '));
                    }

                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  PRODUTO  QTD      VAL.UNIT  SUBTOTAL");
                    w.WriteLine(" -----------------------------------------");

                    val.lItens.ForEach(p =>
                    {
                        w.WriteLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                        w.Write(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(13, ' ') + "x");
                        w.Write(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' '));
                        w.Write(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                        w.WriteLine();
                        if (p.Vl_desconto > decimal.Zero)
                            w.WriteLine(" DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_acrescimo > decimal.Zero)
                            w.WriteLine(" ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                        if (p.Vl_juro_fin > decimal.Zero)
                            w.WriteLine(" JURO FIN.: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    });

                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("  ACRESCIMOS JUROS FIN. DESCONTO  LIQUIDO ");
                    w.Write(val.lItens.Sum(p => p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.Write(val.lItens.Sum(p => p.Vl_juro_fin).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    w.Write(val.lItens.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    w.WriteLine(val.lItens.Sum(p => p.Vl_liquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                    w.WriteLine(" -----------------------------------------");
                    if (!string.IsNullOrEmpty(val.Cd_portador))
                        w.WriteLine("  FORMA PGTO : " + val.Cd_portador.Trim() + "-" + val.Ds_portador.Trim());
                    //Buscar Parcelas
                    CamadaDados.Faturamento.PDV.TList_PreVenda_DT_Vencto lParc =
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda_DT_Vencto.Buscar(val.Id_prevendastr,
                                                                                    val.Cd_empresa,
                                                                                    null);
                    if (lParc.Count > 0)
                    {
                        w.WriteLine("  COND.PGTO  : " + val.Cd_condPgto.Trim() + "-" + val.Ds_condPgto.Trim());
                        w.WriteLine("  VENCIMENTO          VALOR ");
                        lParc.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                            w.WriteLine("  " + p.Dt_vencto.ToString("dd/MM/yyyy").FormatStringDireita(20, ' ') + p.Vl_parcela.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))));
                        w.WriteLine();
                        w.WriteLine();
                    }
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("                Cliente               ");
                    w.WriteLine();
                    w.WriteLine();
                    //Imprimir observacao cupom
                    if (!string.IsNullOrEmpty(val.Ds_observacao))
                    {
                        string obs = val.Ds_observacao.Trim();
                        w.WriteLine(" -----------------------------------------");
                        w.WriteLine("              OBSERVAÇÕES                 ");
                        w.WriteLine(" -----------------------------------------");
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
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("      Este recibo nao tem valor Fiscal    ");

                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();

                    decimal copias = CamadaNegocio.ConfigGer.TCN_CadParamGer.VlNumericoEmpresa("QTD_VIA_REC_ECF", val.Cd_empresa, null);
                    if (copias.Equals(decimal.Zero))
                        copias = 1;
                    for (int i = 0; i < copias; i++) ;
                        f.CopyTo(porta);
                }

                catch (Exception ex)
                { throw new Exception("Erro na impressao: " + ex.Message.Trim()); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
        }

        private bool VerificarTotDesconto(CamadaDados.Faturamento.PDV.TRegistro_PreVenda val)
        {
            for (int i = 0; i < (val.lItens.Count); i++)
            {
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                    CD_Empresa.Text,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if (lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                            p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (tot_pcdesconto.Value.Equals(decimal.Zero))
                                tot_pcdesconto.Value = tot_vldesconto.Value * 100 / tot_itens.Value;
                            if (tot_pcdesconto.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_grupo = val.lItens[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = tot_pcdesconto.Value;
                                    if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                            if (tot_pcdesconto.Value.Equals(decimal.Zero))
                                tot_pcdesconto.Value = tot_vldesconto.Value * 100 / tot_itens.Value;
                            if (tot_pcdesconto.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = tot_pcdesconto.Value;
                                    if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                        return false;
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
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                        if (tot_pcdesconto.Value.Equals(decimal.Zero))
                            tot_pcdesconto.Value = tot_vldesconto.Value * 100 / tot_itens.Value;
                        if (tot_pcdesconto.Value > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = val.lItens[i].Cd_grupo;
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = tot_pcdesconto.Value;
                                if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    return false;
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
                    if (tot_pcdesconto.Value > lDesc[0].Pc_max_desconto && (!St_promocao) && (!St_descEspecial))
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = val.Cd_empresa;
                            fLogin.Pc_desc = tot_pcdesconto.Value;
                            if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                return false;
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
            return true;
        }

        private void TFLanPreVenda_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pTotais.set_FormatZero();
            vModo = TTpModo.tm_Standby;
            ModoBotoes();
            HabilitarCampos();
            lblVlSubTotal.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            //Buscar vendedor Padrao
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginvendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                }
                            }, "a.cd_clifor");
            if (obj != null)
                Vendedordefault = obj.ToString();
            //Buscar empresa padrao usuario
            obj = new CamadaDados.Diversos.TCD_CadUsuario_Empresa().BuscarEscalar(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_LOC_CfgLocacao x " + 
                                            "where x.cd_empresa = a.cd_empresa) "
                            }
                        }, "a.cd_empresa");
            if (obj != null)
                Empresadefault = obj.ToString();
            else
            {
                //Buscar config pdv para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(string.Empty, null);
                if (lCfg.Count == 1)
                    Empresadefault = lCfg[0].Cd_empresa;
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Quantidade > decimal.Zero ?
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Quantidade : 1;
            vl_unitario.Value = bsItens.Current == null ? vl_unitario.Minimum : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario;
            lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            pc_desconto.Value = bsItens.Current == null ? pc_desconto.Minimum : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto;
            vl_desconto.Value = bsItens.Current == null ? vl_desconto.Minimum : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto;
            pc_acrescimo.Value = bsItens.Current == null ? pc_acrescimo.Minimum : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo;
            vl_acrescimo.Value = bsItens.Current == null ? vl_acrescimo.Minimum : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo;
            lblTotalCupom.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_liquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

            Quantidade.Enabled = bsItens.Current == null ? true : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados.Equals(decimal.Zero);
            pc_desconto.Enabled = bsItens.Current == null ? true : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados.Equals(decimal.Zero);
            vl_desconto.Enabled = bsItens.Current == null ? true : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados.Equals(decimal.Zero);
            tot_pcdesconto.Enabled = bsItens.Current == null ? true : !(bsItens.List as CamadaDados.Faturamento.PDV.TList_ItensPreVenda).Exists(p => p.Qtd_pontosutilizados > decimal.Zero);
            tot_vldesconto.Enabled = bsItens.Current == null ? true : !(bsItens.List as CamadaDados.Faturamento.PDV.TList_ItensPreVenda).Exists(p => p.Qtd_pontosutilizados > decimal.Zero);
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            Quantidade.Enabled = true;
            Quantidade.DecimalPlaces = 3;
            vl_unitario.Value = vl_unitario.Minimum;
            vl_unitario.Enabled = true;
            lblVlSubTotal.Text = string.Empty;
            pc_desconto.Value = pc_desconto.Minimum;
            pc_desconto.Enabled = true;
            vl_desconto.Value = vl_desconto.Minimum;
            vl_desconto.Enabled = true;
            pc_acrescimo.Value = pc_acrescimo.Minimum;
            vl_acrescimo.Value = vl_acrescimo.Minimum; 
            lblTotalCupom.Text = string.Empty;
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quantidade.Focus();
                    return;
                }
                if (rCfg.St_movestoquebool && (!st_orcamento.Checked))
                {
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto)))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto))
                        {
                            decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto);
                            if (saldo < Quantidade.Value)
                            {
                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                "Produto.........: " + (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto.Trim() + "-" +
                                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Ds_produto.Trim() + "\r\n" +
                                                "Local Arm.......: " + rCfg.Cd_local.Trim() + "-" + rCfg.Ds_local + "\r\n" +
                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Quantidade.Focus();
                                return;
                            }
                        }
                        else
                        {
                            //Buscar ficha tecnica produto composto
                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto, string.Empty, null);
                            lFicha.ForEach(p => p.Quantidade = p.Quantidade * Quantidade.Value);
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                            //Buscar saldo itens da ficha tecnica
                            string msg = string.Empty;
                            lFicha.ForEach(p =>
                            {
                                //Buscar saldo estoque do item
                                decimal saldo = decimal.Zero;
                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, p.Cd_item, rCfg.Cd_local, ref saldo, null);
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
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Quantidade = Quantidade.Value;
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal = Quantidade.Value *
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario;
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = CalcularDescEspecial(Quantidade.Value, (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario);
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo = CalcularAcresEspecial(Quantidade.Value, (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario);
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_liquido = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal -
                                                                                                      (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto +
                                                                                                       (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo;
                bsItens.ResetCurrentItem();
                BuscarPromocao(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda);
                bsItens.ResetCurrentItem();
                CalcularJuroFin();
                if (!cd_produto.Focused)
                    if (vl_unitario.Enabled)
                        vl_unitario.Focus();
                    else if (pc_desconto.Enabled)
                        pc_desconto.Focus();
                    else
                        pc_acrescimo.Focus();
                bsItens_PositionChanged(this, new EventArgs());
                vl_frete_Leave(this, new EventArgs());
            }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void TFLanPreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F8))
                ConsultaPreVenda();
            else if (e.KeyCode.Equals(Keys.F9))
                AddLocacao();
            else if (e.KeyCode.Equals(Keys.F10))
                DevolverLocacao();
            else if (e.KeyCode.Equals(Keys.F11))
                Print();
            else if (e.KeyCode.Equals(Keys.F12) && vModo.Equals(TTpModo.tm_Insert))
                BuscarProduto();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_locacao_Click(object sender, EventArgs e)
        {
            AddLocacao();
        }

        private void bb_devolverLocacao_Click(object sender, EventArgs e)
        {
            DevolverLocacao();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            ConsultaPreVenda();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLanPreVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (pc_desconto.Value * (Quantidade.Value * vl_unitario.Value) / 100 < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = pc_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(true);
                    CalcularJuroFin();
                    bsItens_PositionChanged(this, new EventArgs());
                    vl_desconto.Focus();
                }
                else
                {
                    vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    pc_desconto.Focus();
                }
            }
        }
                
        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (vl_desconto.Value < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto = vl_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(false);
                    CalcularJuroFin();
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else
                {
                    vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    vl_desconto.Focus();
                }
            }
        }
                
        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_acrescimo = pc_acrescimo.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(true);
                CalcularJuroFin();
                bsItens_PositionChanged(this, new EventArgs());
            }
        }
                
        private void vl_acrescimo_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_acrescimo = vl_acrescimo.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(false);
                CalcularJuroFin();
                bsItens_PositionChanged(this, new EventArgs());
                if (!bb_resgatarPontos.Focus())
                    cd_produto.Focus();
            }
        }
                
        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
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
                                                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto,
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
                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario = vl_unitario.Value;
                                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                                bsItens.ResetCurrentItem();
                                CalcularDesconto(true);
                                CalcularJuroFin();
                                bsItens_PositionChanged(this, new EventArgs());
                                vl_frete_Leave(this, new EventArgs());
                                pc_desconto.Focus();
                            }
                            else
                                vl_unitario.Focus();
                        else
                            vl_unitario.Focus();
                    }
                }
                else
                {
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_unitario = vl_unitario.Value;
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(true);
                    CalcularJuroFin();
                    bsItens_PositionChanged(this, new EventArgs());
                    vl_frete_Leave(this, new EventArgs());
                    pc_desconto.Focus();
                }
            }
        }
                
        private void tot_desconto_Leave(object sender, EventArgs e)
        {
            if(bsPreVenda.Current != null)
            {
                if (tot_vldesconto.Value < (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.Sum(p => p.Vl_subtotal))
                {
                    if (VerificarTotDesconto(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda))
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RatearDesconto(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, tot_vldesconto.Value, decimal.Zero);
                        bsPreVenda.ResetBindings(true);
                        CalcularJuroFin();
                        TotalizarVenda();
                    }
                    else
                    {
                        tot_vldesconto.Value = decimal.Zero;
                        tot_pcdesconto.Value = decimal.Zero;
                        tot_desconto_Leave(this, new EventArgs());
                        tot_vldesconto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Desconto maior que o Valor da Pré-Venda!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tot_vldesconto.Value = decimal.Zero;
                    tot_pcdesconto.Value = decimal.Zero;
                    tot_vldesconto.Focus();
                }
            }
        }
                
        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            if (bsPreVenda.Current != null)
            {
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RatearAcrescimo(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, tot_vlacrescimo.Value, decimal.Zero);
                bsPreVenda.ResetBindings(true);
                CalcularJuroFin();
                TotalizarVenda();
            }
        }
                
        private void miRomaneioEntrega_Click(object sender, EventArgs e)
        {
            Entregar();
        }

        private void consultarRomaneioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFConsultaRomaneio fConsulta = new TFConsultaRomaneio())
            {
                if (bsPreVenda.Current != null)
                {
                    fConsulta.pCd_empresa = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_empresa;
                    fConsulta.pId_prevenda = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr;
                }
                fConsulta.ShowDialog();
            }
        }

        private void tot_pcdesconto_Leave(object sender, EventArgs e)
        {
            if (bsPreVenda.Current != null)
            {
                if (VerificarTotDesconto(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda))
                {
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RatearDesconto(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, decimal.Zero, tot_pcdesconto.Value);
                    bsPreVenda.ResetBindings(true);
                    CalcularJuroFin();
                    TotalizarVenda();
                }
                else
                {
                    tot_pcdesconto.Value = decimal.Zero;
                    tot_vldesconto.Value = decimal.Zero;
                    tot_pcdesconto_Leave(this, new EventArgs());
                    tot_pcdesconto.Focus();
                }
            }
        }
                
        private void tot_pcacrescimo_Leave(object sender, EventArgs e)
        {
            if (bsPreVenda.Current != null)
            {
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RatearAcrescimo(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, decimal.Zero, tot_pcacrescimo.Value);
                bsPreVenda.ResetBindings(true);
                CalcularJuroFin();
                TotalizarVenda();
            }
        }
                
        private void bb_duplicata_Click(object sender, EventArgs e)
        {
            if (bsItens.Count == 0)
            {
                MessageBox.Show("Obrigatório adicionar Itens para Gerar Financeiro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((TP_portadorPDV.ToString().ToUpper().Equals("P") || St_cartao) && (bsPreVenda.Current != null))
            {
                try
                {
                    using (TFDT_Vencto_PreVenda fVencto = new TFDT_Vencto_PreVenda())
                    {
                        fVencto.St_cartao = St_cartao;
                        fVencto.vCd_vendedor = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_vendedor;
                        fVencto.rPrevenda = bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                        if (fVencto.ShowDialog() == DialogResult.OK)
                            if (fVencto.rPrevenda.DT_Vencto.Count > 0)
                                try
                                {
                                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).DT_Vencto = fVencto.rPrevenda.DT_Vencto;
                                    bsPreVenda.ResetCurrentItem();
                                    TotalizarVenda();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                catch { }
            }
        }

        private void bb_consultaProd_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFConsultaProduto fConsulta = new Proc_Commoditties.TFConsultaProduto())
            {
                fConsulta.ShowDialog();
            }
        }

        private void bb_devolvervenda_Click(object sender, EventArgs e)
        {
            if (rCfg == null)
                rCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Empresadefault, null)[0];
            if (rCfg == null)
            {
                MessageBox.Show("Não existe configuração para realizar venda na empresa " + Empresadefault);
                return;
            }
            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR DEVOLVER VENDA";
                fRegra.Login = Utils.Parametros.pubLogin;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    using (PDV.TFItensDevolver fItem = new PDV.TFItensDevolver())
                    {
                        fItem.pCd_empresa = rCfg.Cd_empresa;
                        if (fItem.ShowDialog() == DialogResult.OK)
                            if (fItem.lItens != null)
                                if (fItem.lItens.Count > 0)
                                    try
                                    {
                                        CamadaDados.Faturamento.PDV.TRegistro_Devolucao rDev = new CamadaDados.Faturamento.PDV.TRegistro_Devolucao();
                                        InputBox inp = new InputBox();
                                        inp.Text = "Motivo Devolução";
                                        rDev.Ds_observacao = inp.ShowDialog();
                                        rDev.Cd_empresa = rCfg.Cd_empresa;
                                        rDev.Cd_clifor = fItem.pCd_clifor;
                                        rDev.Nm_clifor = fItem.pNm_clifor;
                                        rDev.Cd_contager = rCfg.Cd_contacaixa;
                                        rDev.Dt_devolucao = CamadaDados.UtilData.Data_Servidor();
                                        fItem.lItens.ForEach(p => rDev.lItens.Add(p));
                                        //Verificar se venda tem parcela em aberto
                                        TList_RegLanParcela lParc = new TCD_LanParcela().Select(
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
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + rDev.Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + rDev.lItens[0].Id_vendarapida.Value.ToString() + ")"
                                            }
                                            }, 0, string.Empty, string.Empty, string.Empty);
                                        if (lParc.Count > 0 ? MessageBox.Show("Venda devolvida possui financeiro em aberto.\r\n" +
                                                                              "Deseja devolver este financeiro?\r\n?" +
                                                                              "Obs.: Caso opte por não devolver financeiro, será gerado crédito.",
                                                                              "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                                              MessageBoxDefaultButton.Button1) == DialogResult.Yes : false)
                                        {
                                            if (lParc.Sum(x => x.cVl_atual) < Math.Round(rDev.lItens.Sum(p => p.Qtd_devolver * (p.Vl_subtotalliquido / p.Quantidade)), 2))
                                                //Verificar credito
                                                if ((string.IsNullOrWhiteSpace(fItem.pCd_clifor) ||
                                                    fItem.pCd_clifor.Trim().Equals(rCfg.Cd_clifor.Trim())) &&
                                                    TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rCfg.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rDev.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rDev.Nm_clifor = linha["nm_clifor"].ToString();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatório identificar cliente para gerar crédito devolução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                }
                                        }
                                        else lParc = null;
                                        CamadaNegocio.Faturamento.PDV.TCN_Devolucao.Gravar(rDev, lParc, null);
                                        MessageBox.Show("Devolução gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Devolucao.Buscar(rDev.Cd_empresa,
                                                                                                               rDev.Id_devolucaostr,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               true,
                                                                                                               null);
                                            Rel.DTS_Relatorio = bs;
                                            Rel.Nome_Relatorio = "FRel_Devolucao";
                                            Rel.NM_Classe = "TFLanDevolucaoVenda";
                                            Rel.Modulo = string.Empty;
                                            Rel.Ident = "FRel_Devolucao";
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pMensagem = "DEVOLUÇÃO DE COMPRAS";

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
                                                                   "DEVOLUÇÃO DE COMPRAS",
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
                                                                       "DEVOLUÇÃO DE COMPRAS",
                                                                       fImp.pDs_mensagem);
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void vl_frete_Leave(object sender, EventArgs e)
        {
            if (bsPreVenda.Current != null)
            {
                if (tot_itens.Value > decimal.Zero)
                {
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.RatearFrete(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda, vl_frete.Value);
                    bsPreVenda.ResetBindings(true);
                    CalcularJuroFin();
                    TotalizarVenda();
                }
            }
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                string vParam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                                "a.TP_portadorPDV|is not|null";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                      new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
                if (linha != null)
                {
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_cometrada = false;
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Parcelas_Dias_Desdobro = decimal.Zero;
                    TP_portadorPDV = linha["TP_portadorPDV"].ToString();
                    St_cartao = linha["ST_CartaoCredito"].Equals(false);
                    Pc_juro_fin = decimal.Parse(linha["pc_juro_fin"].ToString());
                    bb_duplicata.Visible = TP_portadorPDV.Trim().ToUpper().Equals("P") || St_cartao;
                    CalcularJuroFin();
                    BuscarCreditos();
                }
                if (string.IsNullOrEmpty(cd_portador.Text))
                {
                    TP_portadorPDV = string.Empty;
                    St_cartao = false;
                    Pc_juro_fin = decimal.Zero;
                    bb_duplicata.Visible = false;
                }
                pParcelas.Visible = TP_portadorPDV.Trim().ToUpper().Equals("P");
            }
            else
            {
                MessageBox.Show("Obrigatório adicionar Itens a Pré Venda para selecionar Portador!");
                cd_portador.Clear();
            }
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                string vColunas = "a.ds_portador|Portador|200;" +
                                      "a.cd_portador|Codigo|80";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                     new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), "a.TP_portadorPDV|is not|null");
                if (linha != null)
                {
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_cometrada = false;
                    (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Parcelas_Dias_Desdobro = decimal.Zero;
                    TP_portadorPDV = linha["TP_portadorPDV"].ToString();
                    St_cartao = linha["ST_CartaoCredito"].Equals(false);
                    Pc_juro_fin = decimal.Parse(linha["pc_juro_fin"].ToString());
                    bb_duplicata.Visible = TP_portadorPDV.Trim().ToUpper().Equals("P") || St_cartao;
                    CalcularJuroFin();
                    BuscarCreditos();
                }
                if (string.IsNullOrEmpty(cd_portador.Text))
                {
                    TP_portadorPDV = string.Empty;
                    St_cartao = false;
                    Pc_juro_fin = decimal.Zero;
                    bb_duplicata.Visible = false;

                }
                pParcelas.Visible = TP_portadorPDV.Trim().ToUpper().Equals("P");
            }
            else
            {
                MessageBox.Show("Obrigatório adicionar Itens a Pré Venda para selecionar Portador!");
                cd_portador.Clear();
            }
        }

        private void cd_cliforInd_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforInd.Text.Trim() + "'", new Componentes.EditDefault[] { cd_cliforInd, nm_cliforInd },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforInd_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforInd, nm_cliforInd }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar config pdv para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                    if (rCfg.St_exigirclientebool)
                    {
                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, "a.cd_clifor|<>|'" + lCfg[0].Cd_clifor.Trim() + "'");
                        if (linha != null)
                        {
                            CD_Clifor.Text = linha["cd_clifor"].ToString();
                            NM_Clifor.Text = linha["nm_clifor"].ToString();
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, 1, string.Empty);
                            if (lEnd.Count > 0)
                            {
                                cd_endereco.Text = lEnd[0].Cd_endereco;
                                ds_endereco.Text = lEnd[0].Ds_endereco;
                                numero.Text = lEnd[0].Numero;
                                Bairro.Text = lEnd[0].Bairro;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vModo = TTpModo.tm_Standby;
                            ModoBotoes();
                            HabilitarCampos();
                            LimparCampos();
                            TP_portadorPDV = string.Empty;
                            bb_duplicata.Visible = false;
                            St_cartao = false;
                            Pc_juro_fin = decimal.Zero;
                            Tot_pontos_resgatar = decimal.Zero;
                            return;
                        }
                    }
                    else
                    {
                        CD_Clifor.Text = rCfg.Cd_clifor;
                        NM_Clifor.Text = rCfg.Nm_clifor;
                        cd_endereco.Text = rCfg.Cd_endereco;
                        ds_endereco.Text = rCfg.Ds_endereco;
                    }
                    CD_TabelaPreco.Text = rCfg.Cd_tabelapreco;
                }
                else
                {
                    MessageBox.Show("Não existe configuração frente caixa para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    CD_Empresa.Focus();
                    return;
                }
                BuscarPontosFid();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar config pdv para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                    if (rCfg.St_exigirclientebool)
                    {
                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, "a.cd_clifor|<>|'" + lCfg[0].Cd_clifor.Trim() + "'");
                        if (linha != null)
                        {
                            CD_Clifor.Text = linha["cd_clifor"].ToString();
                            NM_Clifor.Text = linha["nm_clifor"].ToString();
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd = 
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, 1, string.Empty);
                            if (lEnd.Count > 0)
                            {
                                cd_endereco.Text = lEnd[0].Cd_endereco;
                                ds_endereco.Text = lEnd[0].Ds_endereco;
                                numero.Text = lEnd[0].Numero;
                                Bairro.Text = lEnd[0].Bairro;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vModo = TTpModo.tm_Standby;
                            ModoBotoes();
                            HabilitarCampos();
                            LimparCampos();
                            TP_portadorPDV = string.Empty;
                            bb_duplicata.Visible = false;
                            St_cartao = false;
                            Pc_juro_fin = decimal.Zero;
                            Tot_pontos_resgatar = decimal.Zero;
                            return;
                        }
                    }
                    else
                    {
                        CD_Clifor.Text = rCfg.Cd_clifor;
                        NM_Clifor.Text = rCfg.Nm_clifor;
                        cd_endereco.Text = rCfg.Cd_endereco;
                        ds_endereco.Text = rCfg.Ds_endereco;
                    }
                    CD_TabelaPreco.Text = rCfg.Cd_tabelapreco;
                }
                else
                {
                    MessageBox.Show("Não existe configuração frente caixa para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    CD_Empresa.Focus();
                    return;
                }
                BuscarPontosFid();
            }
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + CD_Empresa.Text.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend },
                                                 new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + CD_Empresa.Text.Trim() + "')";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                                               new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            Busca_Endereco_Clifor();
            BuscarPontosFid();
            id_pessoa.Clear();
            nm_pessoa.Clear();
            //Verificar se Cliente é consumidor final
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (rCfg.Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
                    proximo.Visible = true;
                    lbprox.Visible = true;
                    //Verificar se Cliente possui tabela preco configurada
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                        }
                                    }, "a.cd_tabelapreco");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        CD_TabelaPreco.Text = obj.ToString();
                    CD_TabelaPreco_Leave(this, new EventArgs());
                    ds_endereco.Size = new Size(274, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    proximo.Visible = false;
                    lbprox.Visible = false;
                    ds_endereco.Size = new Size(782, 20);
                }
            else
            {
                NM_Clifor.Enabled = true;
                ds_endereco.Enabled = true;
                numero.Visible = false;
                Bairro.Visible = false;
                proximo.Visible = false;
                lbprox.Visible = false;
                ds_endereco.Size = new Size(782, 20);
            }
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(linha["id_regiao"].ToString()))
                {
                    //Verificar se Cliente pertence alguma Carteira
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_regiao",
                                            vOperador = "=",
                                            vVL_Busca = "'" + linha["id_regiao"].ToString().Trim() + "'"
                                        }

                                    }, "a.cd_vendedor");
                    if (obj != null)
                    {
                        CD_CompVend.Text = obj.ToString();
                        CD_CompVend_Leave(this, new EventArgs());
                        if (!string.IsNullOrEmpty(CD_CompVend.Text))
                        {
                            CD_CompVend.Enabled = false;
                            BB_CompVend.Enabled = false;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Vendedordefault))
                                CD_CompVend.Text = Vendedordefault;
                            CD_CompVend.Enabled = true;
                            BB_CompVend.Enabled = true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Vendedordefault))
                            CD_CompVend.Text = Vendedordefault;
                        CD_CompVend.Enabled = true;
                        BB_CompVend.Enabled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Vendedordefault) && 
                        string.IsNullOrEmpty(CD_CompVend.Text))
                        CD_CompVend.Text = Vendedordefault;
                    CD_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            Busca_Endereco_Clifor();
            BuscarPontosFid();
            id_pessoa.Clear();
            nm_pessoa.Clear();
            //Verificar se Cliente é consumidor final
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (rCfg.Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
                    proximo.Visible = true;
                    lbprox.Visible = true;
                    //Verificar se Cliente possui tabela preco configurada
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                        }
                                    }, "a.cd_tabelapreco");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        CD_TabelaPreco.Text = obj.ToString();
                    CD_TabelaPreco_Leave(this, new EventArgs());
                    ds_endereco.Size = new Size(274, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    proximo.Visible = false;
                    lbprox.Visible = false;
                    ds_endereco.Size = new Size(782, 20);
                }
            //Verificar carteira do cliente se Usuario não tiver Vendedor padrão
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(linha["id_regiao"].ToString()))
                {
                    //Verificar se Cliente pertence alguma Carteira
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_regiao",
                                            vOperador = "=",
                                            vVL_Busca = "'" + linha["id_regiao"].ToString().Trim() + "'"
                                        }

                                    }, "a.cd_vendedor");
                    if (obj != null)
                    {
                        CD_CompVend.Text = obj.ToString();
                        CD_CompVend_Leave(this, new EventArgs());
                        if (!string.IsNullOrEmpty(CD_CompVend.Text))
                        {
                            CD_CompVend.Enabled = false;
                            BB_CompVend.Enabled = false;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Vendedordefault))
                                CD_CompVend.Text = Vendedordefault;
                            CD_CompVend.Enabled = true;
                            BB_CompVend.Enabled = true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Vendedordefault))
                            CD_CompVend.Text = Vendedordefault;
                        CD_CompVend.Enabled = true;
                        BB_CompVend.Enabled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Vendedordefault) && 
                        string.IsNullOrEmpty(CD_CompVend.Text))
                        CD_CompVend.Text = Vendedordefault;
                    CD_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
            }
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
            {
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (!string.IsNullOrEmpty(CD_Clifor.Text))
                        if (!rCfg.Cd_clifor.Trim().Equals(CD_Clifor.Text.Trim()))
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor.Text, null);
                            rClifor.lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                                                          cd_endereco.Text,
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
                            rClifor.lContato = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                              CD_Clifor.Text,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              string.Empty,
                                                                                                              0,
                                                                                                              null);
                            fClifor.rClifor = rClifor;
                        }
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                            NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                            cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                            ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                            CD_Clifor.Focus();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                using (Financeiro.Cadastros.TFCadClifor fClifor = new Financeiro.Cadastros.TFCadClifor())
                {
                    fClifor.WindowState = FormWindowState.Normal;
                    fClifor.StartPosition = FormStartPosition.CenterScreen;
                    fClifor.St_permiteCadResumido = true;
                    fClifor.ShowDialog();
                }
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_vendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                    }
                                }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            }
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            }
            //Verificar se cliente possui tab especial configurada
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += (string.IsNullOrEmpty(vParam) ? string.Empty : ";") +
                              "|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            }
            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                             , new Componentes.EditDefault[] { CD_TabelaPreco },
                                             new CamadaDados.Diversos.TCD_CadTbPreco(),
                                             vParam);
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());

                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                    fone.Text = linha["fone"].ToString();
                    proximo.Text = linha["proximo"].ToString();
                }
            }
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                    fone.Text = linha["fone"].ToString();
                    proximo.Text = linha["proximo"].ToString();
                }
            }
        }

        private void bb_cadEndereco_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CD_Clifor.Text)) &&
                (!CD_Clifor.Text.Trim().Equals(rCfg.Cd_clifor.Trim())))
            {
                using (Financeiro.Cadastros.TFEndereco fEndereco = new Financeiro.Cadastros.TFEndereco())
                {
                    if (!string.IsNullOrEmpty(cd_endereco.Text))
                        fEndereco.rEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                                                   cd_endereco.Text,
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
                                                                                                   null)[0];
                    if (fEndereco.ShowDialog() == DialogResult.OK)
                        if (fEndereco.rEnd != null)
                            try
                            {
                                fEndereco.rEnd.Cd_clifor = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(fEndereco.rEnd, null);
                                MessageBox.Show("Endereço cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_endereco.Text = fEndereco.rEnd.Cd_endereco;
                                ds_endereco.Text = fEndereco.rEnd.Ds_endereco;
                                numero.Text = fEndereco.rEnd.Numero;
                                Bairro.Text = fEndereco.rEnd.Bairro;
                                fone.Text = fEndereco.rEnd.Fone;
                                proximo.Text = fEndereco.rEnd.Proximo;

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void cd_endereco_TextChanged(object sender, EventArgs e)
        {
            ds_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert) && string.IsNullOrEmpty(cd_endereco.Text);
            numero.Enabled = vModo.Equals(TTpModo.tm_Insert) && string.IsNullOrEmpty(cd_endereco.Text);
            Bairro.Enabled = vModo.Equals(TTpModo.tm_Insert) && string.IsNullOrEmpty(cd_endereco.Text);
            proximo.Enabled = vModo.Equals(TTpModo.tm_Insert) && string.IsNullOrEmpty(cd_endereco.Text);
            fone.Enabled = vModo.Equals(TTpModo.tm_Insert) && string.IsNullOrEmpty(cd_endereco.Text);
        }

        private void fone_TextChanged(object sender, EventArgs e)
        {
            if (fone.Text.SoNumero().Length.Equals(10))
            {
                fone.Text = "(" + fone.Text.SoNumero().Substring(0, 2) + ")" + fone.Text.SoNumero().Substring(2, 4) + "-" + fone.Text.SoNumero().Substring(6, 4);
                fone.SelectionStart = fone.Text.Length;
            }
            else if (fone.Text.SoNumero().Length.Equals(11))
                if (fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    fone.Text = "(" + fone.Text.SoNumero().Substring(0, 3) + ")" + fone.Text.SoNumero().Substring(3, 4) + "-" + fone.Text.SoNumero().Substring(7, 4);
                    fone.SelectionStart = fone.Text.Length;
                }
                else
                {
                    fone.Text = "(" + fone.Text.SoNumero().Substring(0, 2) + ")" + fone.Text.SoNumero().Substring(2, 5) + "-" + fone.Text.SoNumero().Substring(7, 4);
                    fone.SelectionStart = fone.Text.Length;
                }
            else if (fone.Text.SoNumero().Length.Equals(12))
            {
                fone.Text = "(" + fone.Text.SoNumero().Substring(0, 3) + ")" + fone.Text.SoNumero().Substring(3, 5) + "-" + fone.Text.SoNumero().Substring(8, 4);
                fone.SelectionStart = fone.Text.Length;
            }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Quantidade_Leave(this, new EventArgs());
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (!pc_desconto.Focus())
                    pc_acrescimo.Focus();
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (pc_desconto.Value > decimal.Zero)
                    pc_acrescimo.Focus();
                else vl_desconto.Focus();
        }

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                pc_acrescimo.Focus();
        }

        private void pc_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_acrescimo.Focus();
        }

        private void vl_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (!bb_resgatarPontos.Focus())
                    cd_produto.Focus();
        }

        private void tot_pcdesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_pcacrescimo.Focus();
        }

        private void tot_vldesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_vlacrescimo.Focus();
        }

        private void bb_resgatarPontos_Click(object sender, EventArgs e)
        {
            if ((Tot_pontos_resgatar > decimal.Zero) && (bsItens.Current != null))
            {
                vl_acrescimo_Leave(this, new EventArgs());
                object pc_max_utilizar = new CamadaDados.Faturamento.Fidelizacao.TCD_ProgFidelidade().BuscarEscalar(
                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                                                }
                                                            }, "isnull(a.pc_maxpontosutilizar, 0)");
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Ds_label = "Resgatar(R$)";
                    fQtde.Casas_decimais = 2;
                    fQtde.Vl_saldo = pc_max_utilizar == null ? Math.Round(decimal.Divide(decimal.Multiply((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal, decimal.Parse(pc_max_utilizar.ToString())), 100), 2) : (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        if (fQtde.Quantidade > Tot_pontos_resgatar) MessageBox.Show("Valor informado Maior que o saldo disponível");
                        else
                        {
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto += fQtde.Quantidade;
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Pc_desconto = 
                                Math.Round(decimal.Divide(decimal.Multiply((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_desconto, 100), (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Vl_subtotal), 2);
                            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Qtd_pontosutilizados = fQtde.Quantidade;
                            Tot_pontos_resgatar -= fQtde.Quantidade;
                            if (Tot_pontos_resgatar > decimal.Zero)
                                lblPontos.Text = "Pontos Resgatar: " + Tot_pontos_resgatar.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                            else
                            {
                                lblPontos.Text = string.Empty;
                                Tot_pontos_resgatar = decimal.Zero;
                                bb_resgatarPontos.Visible = false;
                            }
                            bsItens.ResetCurrentItem();
                            TotalizarVenda();
                            cd_produto.Focus();
                        }
                    }
                }
            }
        }

        private void bbPessoasAut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente para selecionar pessoa autorizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            using (TFListPessoasAut fLista = new TFListPessoasAut())
            {
                fLista.pCd_clifor = CD_Clifor.Text;
                fLista.pNm_clifor = NM_Clifor.Text;
                if(fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rPessoa != null)
                    {
                        id_pessoa.Text = fLista.rPessoa.Id_pessoastr;
                        nm_pessoa.Text = fLista.rPessoa.Nm_pessoa;
                    }
            }
        }

        private void btn_trocaritem_Click(object sender, EventArgs e)
        {
            if (rCfg == null)
                rCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Empresadefault, null)[0];
            if (rCfg == null)
            {
                MessageBox.Show("Não existe configuração para realizar venda na empresa " + Empresadefault);
                return;
            }
            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR TROCAR MERCADORIA";
                fRegra.Login = Utils.Parametros.pubLogin;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    using (PDV.TFItensTroca fItem = new PDV.TFItensTroca())
                    {
                        fItem.lCfg = new CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal() { rCfg };
                        if (fItem.ShowDialog() == DialogResult.OK)
                            if (fItem.lItens != null)
                                if (fItem.lItens.Count > 0)
                                    try
                                    {
                                        for (int i = fItem.lItens.Count - 1; i >= 0; i--)
                                        {
                                            fItem.lItens[i].St_registro = fItem.lItens[i].lTrocaItem.Count > 0 ? "C" : "A";
                                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Gravar(fItem.lItens[i], rCfg.St_movestoquebool, null);
                                        }
                                        MessageBox.Show("Troca de Item gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = CamadaNegocio.Faturamento.PDV.TCN_TrocaItem.Buscar(rCfg.Cd_empresa,
                                                                                                               fItem.lItens[0].Id_vendarapida.ToString(),
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               null);
                                            Rel.DTS_Relatorio = bs;
                                            Rel.Nome_Relatorio = "FRel_Troca";
                                            Rel.NM_Classe = "TFLanTroca";
                                            Rel.Modulo = "";
                                            Rel.Ident = "FRel_Troca";
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pMensagem = "TROCA DE MERCADORIAS";

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
                                                                   "TROCA DE MERCADORIAS",
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
                                                                       "TROCA DE MERCADORIAS",
                                                                       fImp.pDs_mensagem);
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR ATUALIZAR VALOR VENDA PRODUTO";
                fRegra.Login = Utils.Parametros.pubLogin;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Casas_decimais = 2;
                        fQtde.Ds_label = "VALOR VENDA PRODUTO";
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (fQtde.Quantidade < 0)
                            {
                                MessageBox.Show("Não é permitido informar valor negativo!");
                                return;
                            }
                            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                            CamadaDados.Estoque.TRegistro_LanPrecoItem rPreco = new CamadaDados.Estoque.TRegistro_LanPrecoItem();
                            rProd = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto, null);
                            rProd.CD_Produto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto;
                            rPreco.CD_Empresa = CD_Empresa.Text;

                            rPreco.CD_Produto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_produto;
                            rPreco.CD_Empresa = CD_Empresa.Text;
                            rPreco.CD_TabelaPreco = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).Cd_tabelaPreco;
                            rPreco.Dt_preco = CamadaDados.UtilData.Data_Servidor();
                            rPreco.VL_PrecoVenda = fQtde.Quantidade;

                            rProd.lPrecoItem.Add(rPreco);

                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(rProd, null);
                            vl_unitario.Value = fQtde.Quantidade;
                            vl_unitario_Leave(this, new EventArgs());
                            MessageBox.Show("Produto Atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

            }
        }

        private void cd_produtoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void Cd_representante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_representante.Text.Trim() + "';isnull(a.st_representante, 'N')|=|'S'",
                new Componentes.EditDefault[] { Cd_representante, Nm_representante }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_representante, Nm_representante }, "isnull(a.st_representante, 'N')|=|'S'");
        }

        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
            {
                Quantidade.DecimalPlaces = Convert.ToInt32((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).CasasDecimais);
                Quantidade.Value = Convert.ToDecimal(Quantidade.Value.ToString("N" + Convert.ToInt32((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda).CasasDecimais), new System.Globalization.CultureInfo("pt-BR")));
            }
        }
    }
}
