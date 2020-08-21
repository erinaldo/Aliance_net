using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Faturamento.PDV;
using System.IO;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Faturamento.PDV;

namespace Faturamento
{
    public partial class TFLanVendaRapida : Form
    {
        private bool st_editando = false;
        private int qtd_decimal = 0;
        private TTpModo vModo;
        private string Tp_portador = string.Empty;
        private bool Altera_Relatorio = false;
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private TList_CadPortador lPortador
        { get; set; }
        private TList_RegLanDuplicata lDup
        { get; set; }
        private TRegistro_CaixaPDV rCaixa { get; set; }
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant
        { get; set; }

        private string Cd_vendedordefault
        { get; set; }

        public string LoginPdv
        { get; set; }
        private string LoginDesconto = string.Empty;
        //Verifica se item tem promoção
        private bool St_promocao = false;
        //Verifica se item tem prog especial de Venda
        private bool St_descEspecial = false;
        private bool St_acreEspecial = false;
        //Verifica se a Venda possui promoção ou Prog especial de Venda
        private bool St_promoDescEspecial = false;
        private decimal Tot_pontos_resgatar = decimal.Zero;

        //Tabela buscar dados dos semafaros
        private DataTable tb_semafaro;
        //Tabela buscar dados das Pre-Venda
        private TList_PreVenda lPreVenda;


        public TFLanVendaRapida()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
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
                                }, "isnull(sum(isnull(a.qt_pontos - a.pontos_res, 0)), 0) ");
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

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void ModoBotoes()
        {
            BB_Novo.Visible = vModo.Equals(TTpModo.tm_Standby);
            bb_fecharvenda.Visible = vModo.Equals(TTpModo.tm_Insert);
            BB_Excluir.Visible = vModo.Equals(TTpModo.tm_Standby);
            BB_Cancelar.Visible = vModo.Equals(TTpModo.tm_Insert);
            bb_fatprevenda.Visible = vModo.Equals(TTpModo.tm_Standby);
        }

        private void HabilitarCampos(bool St_prevenda)
        {
            Quantidade.Enabled = vModo.Equals(TTpModo.tm_Insert);
            CD_Empresa.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            BB_Empresa.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            CD_CompVend.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            BB_CompVend.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            Cd_representante.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bb_representante.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bb_cadclifor.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bbPessoasAut.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            CD_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            BB_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            NM_Clifor.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            cd_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            ds_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bb_endereco.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            ds_observacao.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            CD_TabelaPreco.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bb_tabelapreco.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            cd_cliforind.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            bb_cliforind.Enabled = vModo.Equals(TTpModo.tm_Insert) && (!St_prevenda);
            cd_produto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_vldesconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_pcdesconto.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_vlacrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_pcacrescimo.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_frete.Enabled = vModo.Equals(TTpModo.tm_Insert);
            tot_juro_fin.Enabled = vModo.Equals(TTpModo.tm_Insert);
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                pc_desconto.Enabled = false;
                vl_desconto.Enabled = false;
                pc_acrescimo.Enabled = false;
                vl_acrescimo.Enabled = false;
            }
        }

        private void DesabilitarDescontos()
        {
            //Desabilitar os campos de desconto
            vl_desconto.Enabled = !St_promocao && !St_descEspecial;
            pc_desconto.Enabled = !St_promocao && !St_descEspecial;
            vl_acrescimo.Enabled = !St_promocao && !St_acreEspecial;
            pc_acrescimo.Enabled = !St_promocao && !St_acreEspecial;
            tot_pcdesconto.Enabled = !St_promoDescEspecial;
            tot_vldesconto.Enabled = !St_promoDescEspecial;
            tot_pcacrescimo.Enabled = !St_promoDescEspecial;
            tot_vlacrescimo.Enabled = !St_promoDescEspecial;
        }

        private void LimparCampos()
        {
            bsVendaRapida.Clear();
            cd_produto.Clear();
            numero.Clear();
            Bairro.Clear();
            Quantidade.Value = 1;
            tot_pcdesconto.Value = tot_pcdesconto.Minimum;
            tot_pcacrescimo.Value = tot_pcacrescimo.Minimum;
            tot_vldesconto.Value = tot_vldesconto.Minimum;
            tot_vlacrescimo.Value = tot_vlacrescimo.Minimum;
            tot_juro_fin.Value = tot_juro_fin.Minimum;
            tot_frete.Value = tot_frete.Minimum;
            tot_itens.Value = tot_itens.Minimum;
            tot_venda.Value = tot_venda.Minimum;
            vladto.Value = vladto.Minimum;
            Tot_pontos_resgatar = decimal.Zero;
        }

        private void afterNovo()
        {
            st_editando = false;
            if (vModo.Equals(TTpModo.tm_Standby))
            {   //
                //Verificar se existe caixa aberto para realizar venda
                if (rCaixa != null)
                {
                    vModo = TTpModo.tm_Insert;
                    ModoBotoes();
                    HabilitarCampos(false);
                    LimparCampos();
                    bsVendaRapida.AddNew();
                    CD_CompVend.Text = Cd_vendedordefault;
                    St_promoDescEspecial = false;
                    CD_Empresa.Text = lPdv[0].Cd_empresa;
                    NM_Empresa.Text = lPdv[0].Nm_empresa;
                    if (!string.IsNullOrEmpty(CD_Empresa.Text))
                    {
                        //Buscar Config Cupom
                        lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                        if (lCfg.Count < 1)
                        {
                            MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + CD_Empresa.Text,
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Empresa.Clear();
                            NM_Empresa.Clear();
                            CD_Empresa.Focus();
                            return;
                        }
                        else
                            cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                        BuscarPontosFid();
                    }
                    if (lCfg[0].St_obrigavendedorbool)
                    {
                        string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
                        string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                                        "isnull(a.st_funcativo, 'N')|=|'S';" +
                                        "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                                        "where a.CD_Clifor = x.CD_Vendedor " +
                                        "and x.CD_Empresa = '" + CD_Empresa.Text.Trim() + "')";
                        DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                             new TCD_CadClifor(),
                            vParam);
                        if (linha == null)
                        {
                            MessageBox.Show("Obrigatório informar VENDEDOR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vModo = TTpModo.tm_Standby;
                            ModoBotoes();
                            HabilitarCampos(false);
                            LimparCampos();
                            return;
                        }
                    }
                    if (lCfg[0].St_exigirclientebool)
                    {
                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, "a.cd_clifor|<>|'" + lCfg[0].Cd_clifor.Trim() + "'");
                        if (linha != null)
                        {
                            CD_Clifor.Text = linha["cd_clifor"].ToString();
                            NM_Clifor.Text = linha["nm_clifor"].ToString();
                            TList_CadEndereco lEnd = new TCD_CadEndereco().Select(
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
                            HabilitarCampos(false);
                            LimparCampos();
                            return;
                        }
                    }
                    else
                    {
                        CD_Clifor.Text = lCfg[0].Cd_clifor;
                        NM_Clifor.Text = lCfg[0].Nm_clifor;
                        cd_endereco.Text = lCfg[0].Cd_endereco;
                        ds_endereco.Text = lCfg[0].Ds_endereco;
                    }
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                    (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                    (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;
                    cd_produto.Focus();
                }
                else
                    MessageBox.Show("Não existe caixa aberto para realizar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ja existe uma venda em andamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterGrava(string Tp_portador)
        {
            if (vModo == TTpModo.tm_Insert)
                if (pDados.validarCampoObrigatorio())
                {
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
                    if (lCfg[0].St_obrigavendedorbool && string.IsNullOrEmpty(CD_CompVend.Text))
                    {
                        MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_CompVend.Focus();
                        return;
                    }
                    if (Quantidade.Focused)
                        //Verificar se produto movimenta registro anvisa
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoRegAnvisa((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto))
                            using (Proc_Commoditties.TFLoteAnvisa fLote = new Proc_Commoditties.TFLoteAnvisa())
                            {
                                fLote.pCd_empresa = CD_Empresa.Text;
                                fLote.pNm_empresa = NM_Empresa.Text;
                                fLote.pCd_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto;
                                fLote.pDs_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto;
                                fLote.pQtd_movimentar = (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade;
                                fLote.pTp_mov = "S";
                                if (fLote.ShowDialog() == DialogResult.OK)
                                    if (fLote.lMov != null)
                                    {
                                        (bsItens.Current as TRegistro_VendaRapida_Item).lMovLoteAnvisa.Clear();
                                        fLote.lMov.ForEach(p => (bsItens.Current as TRegistro_VendaRapida_Item).lMovLoteAnvisa.Add(p));
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
                            decimal pVl_faturar = tot_venda.Value;
                            BuscarCreditoCliente(ref pVl_faturar);
                            if (pVl_faturar <= 0)
                                return;
                            fFechar.pVl_receber = pVl_faturar;
                            //Testar se existe saldo a faturar 
                            if (fFechar.pVl_receber.Equals(decimal.Zero))
                                return;
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
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                        fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                        fTroco.Vl_troco = fFechar.pVl_troco;
                                        fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                        fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                            {
                                                lDinheiro[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                if (TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                                            //buscar endereco clifor
                                                            object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                                }
                                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
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
                                                        object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                                        lDinheiro[0].Ds_mensagemCredito = inp.ShowDialog();
                                                        lDinheiro[0].St_gerarCredito = true;
                                                    }
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                fTroco.lChRepasse.ForEach(p => lDinheiro[0].lChTroco.Add(p));
                                                if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                {
                                                    if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
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
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lDinheiro[0]);
                    }
                    else if (Tp_portador.Trim().ToUpper().Equals("C"))//Cartao Credito
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
                            MessageBox.Show("Não existe portador cartão crédito configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                        {
                            if (fD_C.ShowDialog() == DialogResult.OK)
                            {
                                using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                {
                                    fCartao.pCd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                    fCartao.D_C = fD_C.D_C;
                                    decimal pVl_faturar = tot_venda.Value;
                                    BuscarCreditoCliente(ref pVl_faturar);
                                    if (pVl_faturar <= 0)
                                        return;
                                    fCartao.Vl_saldofaturar = pVl_faturar;
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
                                        //Troco
                                        if (lCartao[0].Vl_trocoPDV > decimal.Zero)
                                        {
                                            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                            {
                                                fTroco.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                                fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                                fTroco.Vl_troco = lCartao[0].Vl_trocoPDV;
                                                fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                                fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                if (fTroco.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                    {
                                                        lCartao[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                        if (TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                        {
                                                            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                            {
                                                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                                if (linha != null)
                                                                {
                                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                                                    //buscar endereco clifor
                                                                    object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_clifor",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor
                                                                        }
                                                                    }, "a.cd_endereco");
                                                                    if (obj != null)
                                                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
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
                                                                object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_clifor",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                    }
                                                                }, "a.cd_endereco");
                                                                if (obj != null)
                                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                                                lCartao[0].Ds_mensagemCredito = inp.ShowDialog();
                                                                lCartao[0].St_gerarCredito = true;
                                                            }
                                                    }
                                                    if (fTroco.lChRepasse != null)
                                                    {
                                                        fTroco.lChRepasse.ForEach(p => lCartao[0].lChTroco.Add(p));
                                                        if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                        {
                                                            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                            {
                                                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                                if (linha != null)
                                                                {
                                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
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
                            decimal pVl_faturar = tot_venda.Value;
                            BuscarCreditoCliente(ref pVl_faturar);
                            if (pVl_faturar <= 0)
                                return;
                            fListaCheques.Vl_totaltitulo = pVl_faturar;
                            //Testar se existe saldo a faturar 
                            if (fListaCheques.Vl_totaltitulo.Equals(decimal.Zero))
                                return;
                            if (fListaCheques.ShowDialog() == DialogResult.OK)
                            {
                                lCheque[0].lCheque = fListaCheques.lCheques;
                                lCheque[0].Vl_pagtoPDV = fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                                lCheque[0].Vl_trocoPDV = lCheque[0].Vl_pagtoPDV - fListaCheques.Vl_totaltitulo;
                                AbrirGavetaDinheiro();
                                //Troco
                                if (lCheque[0].Vl_trocoPDV > decimal.Zero)
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                        fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                        fTroco.Vl_troco = lCheque[0].Vl_trocoPDV;
                                        fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                        fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                            {
                                                lCheque[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                if (TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                {
                                                    if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                                            //buscar endereco clifor
                                                            object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                                }
                                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
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
                                                        object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                                        lCheque[0].Ds_mensagemCredito = inp.ShowDialog();
                                                        lCheque[0].St_gerarCredito = true;
                                                    }
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                fTroco.lChRepasse.ForEach(p => lCheque[0].lChTroco.Add(p));
                                                if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                {
                                                    if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                                    {
                                                        DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                        if (linha != null)
                                                        {
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
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
                        //Buscar portador duplicata
                        TList_CadPortador lDup =
                            new TCD_CadPortador().Select(
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
                        if (lPdv[0].St_dupresumidabool)
                        {
                            TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                            rDup.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                            rDup.Nm_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa;
                            rDup.Cd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                            rDup.Nm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                            rDup.Cd_condpgto = lCfg[0].Cd_condpgto;
                            rDup.Ds_condpgto = lCfg[0].Ds_condpgto;
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
                                rDup.Cd_endereco = lEnd[0].Cd_endereco;
                                rDup.Ds_endereco = lEnd[0].Ds_endereco;
                            }
                            rDup.Cd_historico = lCfg[0].Cd_historico;
                            rDup.Ds_historico = lCfg[0].Ds_historico;
                            rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                            rDup.Ds_tpduplicata = lCfg[0].Ds_tpduplicata;
                            rDup.Tp_mov = "R";
                            rDup.Tp_doctostring = lCfg[0].Tp_doctostr;
                            rDup.Ds_tpdocto = lCfg[0].Ds_tpdocto;
                            //Buscar Moeda Padrao
                            TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
                            if (tabela != null)
                                if (tabela.Count > 0)
                                {
                                    rDup.Cd_moeda = tabela[0].Cd_moeda;
                                    rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                                    rDup.Sigla_moeda = tabela[0].Sigla;
                                    rDup.DupCotacao.Cd_moedaresult = tabela[0].Cd_moeda;
                                    rDup.DupCotacao.Ds_moedaresult = tabela[0].Ds_moeda_singular;
                                    rDup.DupCotacao.Siglaresult = tabela[0].Sigla;
                                }
                            rDup.Nr_docto = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                "LOC" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                            rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            decimal pVl_faturar = tot_venda.Value;
                            BuscarCreditoCliente(ref pVl_faturar);
                            if (pVl_faturar <= 0)
                                return;
                            rDup.Vl_documento = pVl_faturar;
                            rDup.Vl_documento_padrao = rDup.Vl_documento;
                            object Id_Config = new TCD_CadCFGBanco().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + lDup[0].Cd_portador.Trim() + "'"
                                                        }
                                                    }, "a.id_config");
                            rDup.Id_configboletostr = Id_Config == null ? string.Empty : Id_Config.ToString();
                            using (PDV.TFDuplicataPDV fDup = new PDV.TFDuplicataPDV())
                            {
                                fDup.rDup = rDup;
                                if (fDup.ShowDialog() == DialogResult.OK)
                                {
                                    lDup[0].lDup.Add(rDup);
                                    lDup[0].Vl_pagtoPDV = rDup.Vl_documento;
                                    AbrirGavetaDinheiro();
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vCd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                fDuplicata.vNm_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa;
                                fDuplicata.vCd_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor;
                                fDuplicata.vNm_clifor = (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor;
                                //Buscar condicao de pagamento
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
                                    fDuplicata.vCd_condpgto = lCond[0].Cd_condpgto;

                                fDuplicata.vSt_ecf = true;
                                fDuplicata.vId_caixa = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                                fDuplicata.St_bloquearccusto = true;
                                //Buscar endereco clifor
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
                                TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
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
                                fDuplicata.vDs_observacao = (bsVendaRapida.Current as TRegistro_VendaRapida).NR_Docto_Origem;
                                fDuplicata.vNr_docto = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                "LOC" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                decimal pVl_faturar = tot_venda.Value;
                                BuscarCreditoCliente(ref pVl_faturar);
                                if (pVl_faturar <= 0)
                                    return;
                                fDuplicata.vVl_documento = pVl_faturar;
                                object Id_Config = new TCD_CadCFGBanco().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + lDup[0].Cd_portador.Trim() + "'"
                                                        }
                                                    }, "a.id_config");
                                fDuplicata.vId_configBoleto = Id_Config == null ? string.Empty : Id_Config.ToString();
                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                    if (fDuplicata.dsDuplicata.Current != null)
                                    {
                                        lDup[0].lDup.Add((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata));
                                        lDup[0].Vl_pagtoPDV = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                        AbrirGavetaDinheiro();
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
                        }
                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lDup[0]);
                    }
                    else
                    {
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
                                                    vNM_Campo = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? string.Empty : "a.id_adto",
                                                    vOperador = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? "exists" : "=",
                                                    vVL_Busca = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                                                "(select 1 from TB_LOC_AdtoLocacao x " +
                                                                "where a.id_adto = x.id_adto " +
                                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) " : "a.id_adto"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                }
                                            }, 0, string.Empty);

                        TList_CadPortador lDevolCred = new TList_CadPortador();
                        if (lAdiant.Count > 0)
                        {
                            if (lAdiant.Sum(v => v.Vl_total_devolver) < (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred)
                                if (MessageBox.Show("Saldo credito disponivel para devolução é menor que o valor informado na PRÉ-VENDA.\r\n" +
                                                   "Deseja utilizar somente saldo disponivel<" + lAdiant.Sum(v => v.Vl_total_devolver).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + ">?",
                                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                    return;
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
                                List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                                if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred >
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                                    this.TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                                else
                                {
                                    decimal tot_devolver = (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred <
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) ?
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred :
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
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
                                    try
                                    {
                                        FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else if ((bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred > 0)
                        {
                            if (MessageBox.Show("Não existe saldo credito disponivel para devolução.\r\n" +
                                                   "Deseja ignorar o valor do credito e finalizar a venda?",
                                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred = decimal.Zero;
                            else return;
                        }
                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                        {
                            fFechar.rCupom = bsVendaRapida.Current as TRegistro_VendaRapida;
                            fFechar.pCd_empresa = CD_Empresa.Text;
                            fFechar.pCd_clifor = CD_Clifor.Text;
                            fFechar.pNm_clifor = NM_Clifor.Text;
                            fFechar.rCfg = lCfg[0];
                            fFechar.pVl_receber = tot_venda.Value;
                            fFechar.lPdv = lPdv;
                            fFechar.LoginPDV = LoginPdv;
                            fFechar.pCd_operador = CD_CompVend.Text;
                            fFechar.Id_caixaPDV = rCaixa.Id_caixastr;
                            if (fFechar.ShowDialog() == DialogResult.OK)
                                if (fFechar.lPortador != null)
                                {
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
                    }
                    try
                    {
                        this.Tp_portador = Tp_portador;
                        FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally { LimparCampos(); }
                }
        }

        private void afterCancela()
        {
            if (MessageBox.Show("Confirma cancelamento do lançamento da venda rapida?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                st_editando = false;
                vModo = TTpModo.tm_Standby;
                ModoBotoes();
                HabilitarCampos(false);
                LimparCampos();
            }
        }

        private void FecharVenda(TRegistro_VendaRapida rVenda)
        {
            //Verificar se empresa movimenta centro resultado
            if (TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S") &&
                rVenda.lItem.Sum(p => p.Vl_subtotalliquido - p.Vl_frete) - rVenda.lItem.Where(p => p.St_baixapatrimoniobool).Sum(p => p.Vl_subtotalliquido - p.Vl_frete) > decimal.Zero)
            {
                //Gravar Lancamento Vl.Liquido venda sem frete
                string cd_result = string.Empty;
                if (!string.IsNullOrEmpty(rVenda.Id_locacao))
                {
                    object obj = new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_loc_itenslocacao x " +
                                                            "where x.id_tabela = a.id_tabela " +
                                                            "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                            "and x.id_locacao = " + rVenda.Id_locacao + ")"
                                            }
                                    }, "a.TP_Tabela");
                    if (obj == null ? false : obj.ToString().Trim().Equals("4"))
                    {
                        //Buscar parametro Mensal
                        obj = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                        }
                                }, "a.cd_centroresultmes");
                        cd_result = obj == null ? string.Empty : obj.ToString();
                    }
                    else if (obj == null ? false : obj.ToString().Trim().Equals("5"))
                    {
                        //Semanal
                        obj = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                        }
                                }, "a.cd_centroresultsem");
                        cd_result = obj == null ? string.Empty : obj.ToString();
                    }
                    else if (obj == null ? false : obj.ToString().Trim().Equals("6"))
                    {
                        //Quinzenal
                        obj = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                        }
                                }, "a.cd_centroresultquinz");
                        cd_result = obj == null ? string.Empty : obj.ToString();
                    }
                    else
                    {
                        //Locacao Diaria
                        obj = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                        }
                                }, "a.cd_centroresultdia");
                        cd_result = obj == null ? string.Empty : obj.ToString();
                    }
                }
                else cd_result = lCfg[0].Cd_centroresult;
                if (!string.IsNullOrEmpty(cd_result))
                {
                    rVenda.lCusto.Add(
                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = rVenda.Cd_empresa,
                            Cd_centroresult = cd_result,
                            Vl_lancto = rVenda.lItem.Sum(p => p.Vl_subtotalliquido - p.Vl_frete) -
                                        rVenda.lItem.Where(p => p.St_baixapatrimoniobool).Sum(p => p.Vl_subtotalliquido - p.Vl_frete),
                            Dt_lancto = rVenda.Dt_emissao
                        });
                }
                else
                    using (Financeiro.TFRateioCResultado fRateio = new Financeiro.TFRateioCResultado())
                    {
                        fRateio.vVl_Documento = rVenda.lItem.Sum(p => p.Vl_subtotalliquido - p.Vl_frete) - rVenda.lItem.Where(p => p.St_baixapatrimoniobool).Sum(p => p.Vl_subtotalliquido - p.Vl_frete);
                        fRateio.Tp_mov = "R";
                        fRateio.Dt_movimento = rVenda.Dt_emissao;
                        if (fRateio.ShowDialog() == DialogResult.OK)
                            rVenda.lCusto = fRateio.lCResultado;
                    }
            }
            TCN_VendaRapida.GravarVendaRapida(rVenda,
                                              null,
                                              null,
                                              null);
            //Busca cupom gravado
            TList_VendaRapida lCupom = TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
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
                                                              0,
                                                              null);
            lCupom.ForEach(p =>
            {
                p.lItem = TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                      p.Cd_empresa,
                                                      false,
                                                      string.Empty,
                                                      null);
                p.lItem.ForEach(v => v.lGradeEstoque = new CamadaDados.Estoque.TCD_GradeEstoque().Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_item_x_estoque x " +
                                                                            "where x.cd_empresa = a.cd_empresa "+
                                                                            "and x.cd_produto = a.cd_produto " +
                                                                            "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                                            "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + v.Id_vendarapida.ToString() + " " +
                                                                            "and x.id_lancto = " + v.Id_lanctovenda.ToString() + ")"

                                                            }
                                                        }, 0, string.Empty));
            });
            lCupom[0].lPortador = rVenda.lPortador;
            //Alterar Layout Tela
            vModo = TTpModo.tm_Standby;
            ModoBotoes();
            HabilitarCampos(false);
            LimparCampos();
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

            //Verificar se PDV imprime Venda automática
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
                            }, "1") == null)
            {
                if (MessageBox.Show("Deseja imprimir orçamento venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        if (lCupom.Count > 0)
                        {
                            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                            {
                                TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                                return;
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                            {
                                if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                    throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                                TCN_VendaRapida.ImprimirReduzido(lCupom[0], lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                                ImprimirGraficoReduzido(lCupom[0]);
                            else
                                ImprimirGrafico(lCupom[0]);
                            //criar um cupom para cada produto pedido

                        }
                        if (!Tp_portador.Trim().ToUpper().Equals("N") &&
                            MessageBox.Show("Deseja imprimir o recibo da venda?",
                                            "Pergunta",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            ImprimirRecibo(lCupom[0]);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else if (!Tp_portador.Trim().ToUpper().Equals("N") &&
                            MessageBox.Show("Deseja imprimir o recibo da venda?",
                                            "Pergunta",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ImprimirRecibo(lCupom[0]);
                }
            }
            else
            {
                try
                {
                    if (lCupom.Count > 0)
                    {
                        if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                        {
                            TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                            return;
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                        {
                            if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                            TCN_VendaRapida.ImprimirReduzido(lCupom[0], lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                            ImprimirGraficoReduzido(lCupom[0]);
                        else
                            ImprimirGrafico(lCupom[0]);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

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
                    TList_RegLanParcela lParcelas =
                            new TCD_LanParcela().Select(
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
                            }, 0, string.Empty, string.Empty, string.Empty);
                    if (lParcelas.Count > 0)
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {

                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = lParcelas[0].Cd_clifor;
                            //Buscar dados Empresa
                            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lParcelas[0].Cd_empresa,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
                            //Buscar dados do sacado
                            TList_CadClifor lSacado =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(lParcelas[0].Cd_clifor,
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
                                                                                              0,
                                                                                              null);
                            //Buscar endereco sacado
                            if (lSacado.Count > 0)
                                lSacado[0].lEndereco =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParcelas[0].Cd_clifor,
                                                                                              lParcelas[0].Cd_endereco,
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
                            if (TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                             lParcelas[0].Cd_empresa,
                                                             null).Trim().ToUpper().Equals("S"))
                            {
                                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();

                                //Buscar Duplicata
                                TList_RegLanDuplicata lDup =
                                    new TCD_LanDuplicata().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lParcelas[0].Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_lancto",
                                                vOperador = "=",
                                                vVL_Busca = lParcelas[0].Nr_lanctostr
                                            }
                                        }, 0, string.Empty);
                                //Duplicata
                                BindingSource bs = new BindingSource();
                                bs.DataSource = lDup;
                                Rel.DTS_Relatorio = bs;
                                //Verificar se existe logo configurada para a empresa
                                if (lEmpresa.Count > 0)
                                    if (lEmpresa[0].Img != null)
                                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                //Empresa
                                BindingSource bs_emp = new BindingSource();
                                bs_emp.DataSource = lEmpresa;
                                Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                //Parcelas
                                BindingSource bs_parc = new BindingSource();
                                bs_parc.DataSource = lParcelas;
                                Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                //Sacado
                                BindingSource bs_sacado = new BindingSource();
                                bs_sacado.DataSource = lSacado;
                                Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                Rel.Nome_Relatorio = "FRel_CarneDup";
                                Rel.NM_Classe = "TFDuplicata";
                                Rel.Modulo = "FIN";
                                Rel.Ident = "FRel_CarneDup";
                                fImp.St_enabled_enviaremail = true;
                                fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto;

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
                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
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
                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                       fImp.pDs_mensagem);
                            }
                            else
                            {
                                fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lParcelas[0].Nr_docto;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(Altera_Relatorio,
                                                                                        lParcelas,
                                                                                        lEmpresa,
                                                                                        lSacado,
                                                                                        fImp.pSt_imprimir,
                                                                                        fImp.pSt_visualizar,
                                                                                        fImp.pSt_exportPdf,
                                                                                        fImp.Path_exportPdf,
                                                                                        fImp.pSt_enviaremail,
                                                                                        fImp.pDestinatarios,
                                                                                        "DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                                                        fImp.pDs_mensagem);
                            }
                        }
                    if (lParcelas.Sum(p => p.Vl_liquidado) > decimal.Zero)
                    {
                        try
                        {

                            TList_RegLanLiquidacao lLiquid =
                                new TCD_LanLiquidacao().Select(
                                    new TpBusca[]
                                    {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lParcelas[0].Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_lancto",
                                                    vOperador = "=",
                                                    vVL_Busca = lParcelas[0].Nr_lancto.ToString()
                                                }
                                    }, 0, string.Empty);

                            TList_RegLanDuplicata lDuplic = TCN_LanDuplicata.Busca(lParcelas[0].Cd_empresa,
                                                                                   lParcelas[0].Nr_lancto.ToString(),
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
                                                                                   false,
                                                                                   0,
                                                                                   string.Empty,
                                                                                   null);

                            //Impressao do recibo
                            string referente = string.Empty;
                            string virg = string.Empty;
                            lParcelas.ForEach(p =>
                            {
                                referente += virg + p.Nr_docto.Trim() + "/" + p.Cd_parcelastr + (p.St_registro.Trim().ToUpper().Equals("P") ? "(PARCIAL)" : string.Empty);
                                virg = ", ";
                            });
                            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                   new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                            if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                            {
                                if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                       lLiquid[0]);
                            }
                            else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                            {
                                if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                       lLiquid[0]);
                            }
                            else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                              referente,
                                                                              lLiquid[0],
                                                                              lDuplic);
                            else
                                FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                              referente,
                                                                              lLiquid[0],
                                                                              lDuplic);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro imprimir recibos liquidação com cheques: " + ex.Message.Trim());
                        }
                    }
                }
            }

            using (PostoCombustivel.TFGerarDocFiscal fDoc = new PostoCombustivel.TFGerarDocFiscal())
            {
                if (fDoc.ShowDialog() == DialogResult.OK)
                    if (fDoc.St_nfe)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
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
                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto = 
                                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                                        "where x.cd_empresa = c.cd_empresa "+
                                                        "and x.nr_lanctoduplicata = c.nr_lancto "+
                                                        "and x.cd_empresa = '" + rFat.Cd_empresa.Trim() + "' "+
                                                        "and x.nr_lanctofiscal = " + rFat.Nr_lanctofiscalstr + ")"
                                        }
                                    }, 0, string.Empty);
                                if (lBloqueto.Count > 0)
                                    //Chamar tela de impressao para o bloqueto
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                        fImp.pMensagem = "BLOQUETOS DA NOTA FISCAL Nº" + rFat.Nr_notafiscalstr;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                              lBloqueto,
                                                                                              fImp.pSt_imprimir,
                                                                                              fImp.pSt_visualizar,
                                                                                              fImp.pSt_enviaremail,
                                                                                              fImp.pSt_exportPdf,
                                                                                              fImp.Path_exportPdf,
                                                                                              fImp.pDestinatarios,
                                                                                              "BLOQUETO(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscalstr,
                                                                                              fImp.pDs_mensagem,
                                                                                              false);
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
                                dados.Cd_endereco = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco;
                                dados.Endereco = (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco;
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
                                            rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
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
                                        bsNFCe.DataSource = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
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
                                                                    "where x.cd_empresa = a.cd_empresa " +
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
                                            bsItens.DataSource = TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
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
                                        if (lDup.Count > 0)
                                        {
                                            Rel = new FormRelPadrao.Relatorio();
                                            Rel.DTS_Relatorio = bsNFCe;
                                            //DTS Cupom
                                            if (dts.Count.Equals(0))
                                                dts.DataSource = TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                      (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                      string.Empty,
                                                                                      null);
                                            Rel.Adiciona_DataSource("DTS_ITENS", dts);
                                            //Buscar Empresa
                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                            //Buscar Cliente Cupom 
                                            if (string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Cd_clifor))
                                            {
                                                TRegistro_CadClifor rClifor =
                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsNFCe.Current as TRegistro_NFCe).Cd_clifor, null);
                                                Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                                                Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                                            }
                                            else
                                            {
                                                Rel.Parametros_Relatorio.Add("NM_CLIENTE", (bsNFCe.Current as TRegistro_NFCe).Nm_clifor);
                                                Rel.Parametros_Relatorio.Add("CPF_CLIENTE", (bsNFCe.Current as TRegistro_NFCe).Nr_cgc_cpf);
                                            }
                                            if (string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Ds_endereco))
                                            {
                                                TList_CadEndereco lEnd =
                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_clifor,
                                                                                                          (bsNFCe.Current as TRegistro_NFCe).Cd_endereco,
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
                                                Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                                            }
                                            else Rel.Parametros_Relatorio.Add("ENDERECO", (bsNFCe.Current as TRegistro_NFCe).Ds_endereco.Trim());
                                            string dadosdi = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                    (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                    null);
                                            if (!string.IsNullOrEmpty(dadosdi))
                                            {
                                                string[] linhas = dadosdi.Split(new char[] { ':' });
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
                                            //Buscar Valor Pago
                                            decimal vl_pago = decimal.Zero;
                                            List<TRegistro_MovCaixa> lPag = new TCD_CaixaPDV().SelectMovCaixa(
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
                                                                                }, string.Empty);
                                            if (lPag.Count > 0)
                                                vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                                            vl_pago += lDup.Sum(p => p.Vl_liquidado);
                                            Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                                            Rel.Parametros_Relatorio.Add("VL_PAGAR", lDup.Sum(p => p.Vl_atual));
                                            Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", (bsNFCe.Current as TRegistro_NFCe).NR_NFCestr);
                                            Rel.Parametros_Relatorio.Add("DT_EMISSAO", (bsNFCe.Current as TRegistro_NFCe).Dt_emissaostr);
                                            Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", (bsNFCe.Current as TRegistro_NFCe).Chave_acesso);
                                            Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", "0");//1-NF-e;0-NFC-e
                                            Rel.Nome_Relatorio = "CONFISSAO_DIVIDA";
                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                            Rel.Modulo = "FAT";
                                            Rel.Ident = "CONFISSAO_DIVIDA";
                                            if (string.IsNullOrEmpty(print))
                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                {
                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                            print = fLista.Impressora;

                                                }
                                            //Imprimir
                                            if (!string.IsNullOrEmpty(print))
                                                Rel.ImprimiGraficoReduzida(print, true, false, null, string.Empty, string.Empty, 1);
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
                            MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }

        private void afterExclui()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                if (bsVendaRapida.Current != null)
                    if (MessageBox.Show("Confirma exclusão da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_VendaRapida.ExcluirVendaRapida(new List<TRegistro_VendaRapida> { bsVendaRapida.Current as TRegistro_VendaRapida }, null);
                            MessageBox.Show("Venda rapida excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vModo = TTpModo.tm_Standby;
                            ModoBotoes();
                            HabilitarCampos(false);
                            LimparCampos();
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                using (PDV.TFExcluirVendaRapida fGerar = new PDV.TFExcluirVendaRapida())
                {
                    if (fGerar.ShowDialog() == DialogResult.OK)
                        if (fGerar.lVenda != null)
                            try
                            {
                                TCN_VendaRapida.ExcluirVendaRapida(fGerar.lVenda, null);
                                MessageBox.Show("Vendas excluidas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                            MessageBox.Show("Não existe venda selecionada excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BuscarPromocao(TRegistro_VendaRapida_Item rItemCupom)
        {
            if (bsItens.Current != null)
            {
                St_promocao = false;
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
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
                                    if (p.Pc_desconto >= 100)
                                    {
                                        p.Vl_desconto = decimal.Zero;
                                        p.Pc_desconto = decimal.Zero;
                                    }
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
                            if (rItemCupom.Pc_desconto >= 100)
                            {
                                rItemCupom.Vl_desconto = decimal.Zero;
                                rItemCupom.Pc_desconto = decimal.Zero;
                            }
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
                    if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem
                        .Where(p => p.Cd_produto.Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
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
            St_acreEspecial = false;
            if (rProg != null)
                if ((rProg.Valor > decimal.Zero) && rProg.Tp_acresdesc.Trim().ToUpper().Equals("A"))
                {
                    St_acreEspecial = true;
                    St_promoDescEspecial = true;
                    DesabilitarDescontos();
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            else return decimal.Zero;
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                {
                    //Verificar se existe programacao especial de venda 
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

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                string pCd_codbarra = cd_produto.Text;
                decimal vl_subtotal = decimal.Zero;
                decimal qtd = decimal.Zero;
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
                //Buscar Código de barra balança
                if (lProduto.Count.Equals(0) && pCd_codbarra.Length.Equals(13))
                {
                    string cod = pCd_codbarra.Substring(1, 6).ToString();
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
                        Quantidade.DecimalPlaces = Convert.ToInt32(lProduto[0].CasasDecimais);
                        qtd_decimal = Convert.ToInt32(lProduto[0].CasasDecimais);
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
                    if (lCfg[0].St_obrigavendedorbool && string.IsNullOrEmpty(CD_CompVend.Text))
                    {
                        MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        CD_CompVend.Focus();
                        return false;
                    }
                    //Verificar saldo estoque do produto
                    if (lCfg[0].St_movestoquebool)
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto) &&
                                 !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(lProduto[0].CD_Produto))
                            {
                                decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, lProduto[0].CD_Produto);
                                if (saldo.Equals(decimal.Zero))
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
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
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
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
                    qtd_decimal = Convert.ToInt32(lProduto[0].CasasDecimais);
                    //Cria novo item
                    bsItens.AddNew();
                    //Verificar se existe quantidade com peso na balança.
                    Quantidade.Value = qtd > decimal.Zero ? qtd : Quantidade.Value;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo = lProduto[0].CD_Grupo;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_tabelapreco = CD_TabelaPreco.Text;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_condfiscal_produto = lProduto[0].CD_CondFiscal_Produto;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ncm = lProduto[0].Ncm;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_unidade = lProduto[0].CD_Unidade;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Sigla_unidade = lProduto[0].Sigla_unidade;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_local = lCfg[0].Cd_local;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Ds_local = lCfg[0].Ds_local;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario = ConsultaPreco(lProduto[0].CD_Produto);
                    if (lCfg[0].St_RATEARDESCSERVICObool)
                        (bsItens.Current as TRegistro_VendaRapida_Item).st_servico =
                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto);

                    if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario > decimal.Zero)
                    {
                        (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal = Quantidade.Value * ConsultaPreco(lProduto[0].CD_Produto);
                        decimal desconto = CalcularDescEspecial(Quantidade.Value, (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (desconto > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = desconto;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = desconto * 100 /
                                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        decimal acrescimo = CalcularAcresEspecial(Quantidade.Value, (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (acrescimo > decimal.Zero)
                        {

                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = acrescimo;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = acrescimo * 100 /
                                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                    }
                    //Buscar Promocao Venda
                    BuscarPromocao(bsItens.Current as TRegistro_VendaRapida_Item);
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    //Verificar se usuario´pode informar preço de Venda
                    vl_unitario.Enabled = (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
                    TotalizarVenda();
                    //Habilitar Campos Pre-Venda
                    CD_Empresa.Enabled = bsItens.Count.Equals(0);
                    BB_Empresa.Enabled = bsItens.Count.Equals(0);
                    CD_CompVend.Enabled = bsItens.Count.Equals(0);
                    BB_CompVend.Enabled = bsItens.Count.Equals(0);
                    CD_Clifor.Enabled = bsItens.Count.Equals(0);
                    BB_Clifor.Enabled = bsItens.Count.Equals(0);
                    bb_cadclifor.Enabled = bsItens.Count.Equals(0);
                    bbPessoasAut.Enabled = bsItens.Count.Equals(0);
                    CD_TabelaPreco.Enabled = bsItens.Count.Equals(0);
                    bb_tabelapreco.Enabled = bsItens.Count.Equals(0);
                    cd_endereco.Enabled = bsItens.Count.Equals(0);
                    bb_endereco.Enabled = bsItens.Count.Equals(0);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void CalcularSubTotal()
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal =
                    (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade *
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario;
                bsItens.ResetCurrentItem();
            }
        }

        private void CalcularDesconto(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_desconto.Focused)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                if (pc_desconto.Focused)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = pc_desconto.Value;
                if (St_percentual)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto =
                        Math.Round((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal *
                        ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto / 100), 2, MidpointRounding.AwayFromZero);
                else
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto =
                        Math.Round((bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto * 100 / (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                    CD_Empresa.Text,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc.Equals(0) ||
                    ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc <
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto))
                    if (lDesc.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo.Trim())).Pc_max_desconto;
                                if ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                                {
                                    MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_grupo = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo;
                                        fLogin.Cd_empresa = CD_Empresa.Text;
                                        fLogin.Pc_desc = (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto;
                                        if (fLogin.ShowDialog() != DialogResult.OK)
                                        {
                                            vl_desconto.Value = decimal.Zero;
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = decimal.Zero;
                                            pc_desconto.Value = decimal.Zero;
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = decimal.Zero;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            pc_desconto.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                            LoginDesconto = fLogin.Logindesconto;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    bsItens.ResetCurrentItem();
                                    TotalizarVenda();
                                    return;
                                }
                            }
                            else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                            {
                                //Desconto por tabela de preço
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                                if ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                                {
                                    MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_empresa = CD_Empresa.Text;
                                        fLogin.Pc_desc = (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto;
                                        if (fLogin.ShowDialog() != DialogResult.OK)
                                        {
                                            vl_desconto.Value = decimal.Zero;
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = decimal.Zero;
                                            pc_desconto.Value = decimal.Zero;
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = decimal.Zero;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            pc_desconto.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                            LoginDesconto = fLogin.Logindesconto;
                                            bsItens.ResetCurrentItem();
                                            TotalizarVenda();
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    bsItens.ResetCurrentItem();
                                    TotalizarVenda();
                                    return;
                                }
                            }
                        //Desconto por grupo de produto
                        if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo.Trim())))
                        {
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo.Trim())).Pc_max_desconto;
                            if ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto > pc_max_desc && (!St_promocao) && (!St_descEspecial))
                            {
                                MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_grupo = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_grupo;
                                    fLogin.Cd_empresa = CD_Empresa.Text;
                                    fLogin.Pc_desc = (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                    {
                                        vl_desconto.Value = decimal.Zero;
                                        (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = decimal.Zero;
                                        pc_desconto.Value = decimal.Zero;
                                        (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = decimal.Zero;
                                        bsItens.ResetCurrentItem();
                                        TotalizarVenda();
                                        pc_desconto.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        (bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                        LoginDesconto = fLogin.Logindesconto;
                                        bsItens.ResetCurrentItem();
                                        TotalizarVenda();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                bsItens.ResetCurrentItem();
                                TotalizarVenda();
                                return;
                            }
                        }
                        //Desconto por vendedor e empresa
                        if ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto > lDesc[0].Pc_max_desconto && (!St_promocao) && (!St_descEspecial))
                        {
                            MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_empresa = CD_Empresa.Text;
                                fLogin.Pc_desc = (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    vl_desconto.Value = decimal.Zero;
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = decimal.Zero;
                                    pc_desconto.Value = decimal.Zero;
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = decimal.Zero;
                                    bsItens.ResetCurrentItem();
                                    TotalizarVenda();
                                    pc_desconto.Focus();
                                    return;
                                }
                                else
                                {
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                    LoginDesconto = fLogin.Logindesconto;
                                    bsItens.ResetCurrentItem();
                                    TotalizarVenda();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            bsItens.ResetCurrentItem();
                            TotalizarVenda();
                            return;
                        }
                    }
                    else
                        TotalizarVenda();
                else
                    TotalizarVenda();
            }
        }

        private void CalcularAcrescimo(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_acrescimo.Focused)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = vl_acrescimo.Value;
                if (pc_acrescimo.Focused)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = pc_acrescimo.Value;
                if (St_percentual)
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo =
                        Math.Round((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal *
                        ((bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo / 100), 2, MidpointRounding.AwayFromZero);
                else
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo =
                        Math.Round((bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo * 100 / (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                bsItens.ResetCurrentItem();
                TotalizarVenda();
            }
        }

        private void TotalizarVenda()
        {
            if (bsVendaRapida.Current != null)
            {
                if ((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Count > 0)
                {
                    tot_itens.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotal);
                    tot_vldesconto.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_desconto);
                    tot_pcdesconto.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Average(p => p.Pc_desconto);
                    tot_vlacrescimo.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_acrescimo);
                    tot_pcacrescimo.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Average(p => p.Pc_acrescimo);
                    tot_juro_fin.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_juro_fin);
                    tot_frete.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_frete);
                    tot_venda.Value = (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) - vladto.Value > 0 ?
                                      (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) - vladto.Value : 0;
                    //Calcular Percentual de vl.descontos e vl.acrescimos forem maiores que zero(Faturar PreVenda)
                    if (tot_vldesconto.Value > decimal.Zero)
                    {
                        if (tot_pcdesconto.Value.Equals(decimal.Zero))
                            tot_pcdesconto.Value = tot_vldesconto.Value * 100 / tot_itens.Value;
                    }
                    if (tot_vlacrescimo.Value > decimal.Zero)
                    {
                        if (tot_pcacrescimo.Value.Equals(decimal.Zero))
                            tot_pcacrescimo.Value = tot_vlacrescimo.Value * 100 / tot_itens.Value;
                    }
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else
                {
                    tot_itens.Value = tot_itens.Minimum;
                    tot_frete.Value = tot_frete.Minimum;
                    tot_vldesconto.Value = tot_vldesconto.Minimum;
                    tot_pcdesconto.Value = tot_pcdesconto.Minimum;
                    tot_vlacrescimo.Value = tot_vlacrescimo.Minimum;
                    tot_pcacrescimo.Value = tot_pcacrescimo.Minimum;
                    tot_venda.Value = tot_venda.Minimum;
                    tot_juro_fin.Value = tot_juro_fin.Minimum;
                }
                bsVendaRapida.ResetCurrentItem();
            }
        }

        private void GerarCupom()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                if (bsVendaRapida.Current != null)
                {
                    if (MessageBox.Show("Gerar NFCe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Verificar se venda possui cupom
                        if (new TCD_NFCe().BuscarEscalar(
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
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_cupom " +
                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                            }, "1") != null)
                        {
                            MessageBox.Show("Venda possui cupom fiscal/NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Verificar se venda tem Nota faturada
                        object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                        "inner join TB_PDV_Pedido_X_VendaRapida y " +
                                                        "on x.nr_pedido = y.nr_pedido " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_pedidoitem = y.id_pedidoitem " +
                                                        "and x.cd_empresa = y.cd_empresa " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and y.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'" +
                                                        "and y.Id_VendaRapida = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ") "
                                        }
                                        }, "a.nr_notafiscal");
                        if (obj != null)
                        {
                            MessageBox.Show("Essa venda já está faturada. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
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
                                obj = new TCD_CadClifor().BuscarEscalar(
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

                                //PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true);
                                if (rNFCe != null)
                                {
                                    if (!rNFCe.St_contingencia)
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            fGerNfe.rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
                                            fGerNfe.ShowDialog();
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
                                        bsNFCe.DataSource = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
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
                                                                    "where x.cd_empresa = a.cd_empresa " +
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
                                            bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
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
                                        //Imprimir confissao de divida
                                        if (lDup.Count > 0)
                                        {
                                            Rel = new FormRelPadrao.Relatorio();
                                            Rel.DTS_Relatorio = bsNFCe;
                                            //DTS Cupom
                                            if (dts.Count.Equals(0))
                                                dts.DataSource = TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                      (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                      string.Empty,
                                                                                      null);
                                            Rel.Adiciona_DataSource("DTS_ITENS", dts);
                                            //Buscar Empresa
                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                            //Buscar Cliente Cupom 
                                            if (string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Cd_clifor))
                                            {
                                                TRegistro_CadClifor rClifor =
                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsNFCe.Current as TRegistro_NFCe).Cd_clifor, null);
                                                Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                                                Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                                            }
                                            else
                                            {
                                                Rel.Parametros_Relatorio.Add("NM_CLIENTE", (bsNFCe.Current as TRegistro_NFCe).Nm_clifor);
                                                Rel.Parametros_Relatorio.Add("CPF_CLIENTE", (bsNFCe.Current as TRegistro_NFCe).Nr_cgc_cpf);
                                            }
                                            if (string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Ds_endereco))
                                            {
                                                TList_CadEndereco lEnd =
                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_clifor,
                                                                                                          (bsNFCe.Current as TRegistro_NFCe).Cd_endereco,
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
                                                Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                                            }
                                            else Rel.Parametros_Relatorio.Add("ENDERECO", (bsNFCe.Current as TRegistro_NFCe).Ds_endereco.Trim());
                                            string dadosdi = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                           (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                           null);
                                            if (!string.IsNullOrEmpty(dadosdi))
                                            {
                                                string[] linhas = dadosdi.Split(new char[] { ':' });
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
                                            //Buscar Valor Pago
                                            decimal vl_pago = decimal.Zero;
                                            List<TRegistro_MovCaixa> lPag = new TCD_CaixaPDV().SelectMovCaixa(
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
                                                                                }, string.Empty);
                                            if (lPag.Count > 0)
                                                vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                                            vl_pago += lDup.Sum(p => p.Vl_liquidado);
                                            Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                                            Rel.Parametros_Relatorio.Add("VL_PAGAR", lDup.Sum(p => p.Vl_atual));
                                            Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", (bsNFCe.Current as TRegistro_NFCe).NR_NFCestr);
                                            Rel.Parametros_Relatorio.Add("DT_EMISSAO", (bsNFCe.Current as TRegistro_NFCe).Dt_emissaostr);
                                            Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", (bsNFCe.Current as TRegistro_NFCe).Chave_acesso);
                                            Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", "0");//1-NF-e;0-NFC-e
                                            Rel.Nome_Relatorio = "CONFISSAO_DIVIDA";
                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                            Rel.Modulo = "FAT";
                                            Rel.Ident = "CONFISSAO_DIVIDA";
                                            if (string.IsNullOrEmpty(print))
                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                {
                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                            print = fLista.Impressora;

                                                }
                                            //Imprimir
                                            if (!string.IsNullOrEmpty(print))
                                                Rel.ImprimiGraficoReduzida(print, true, false, null, string.Empty, string.Empty, 1);
                                        }
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
                            MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                        {
                            if (fGerar.ShowDialog() == DialogResult.OK)
                                if (fGerar.lItens != null)
                                    if (fGerar.lItens.Count > 0)
                                    {
                                        if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                                        {
                                            try
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
                                                dados.St_vendacombustivel = false;
                                                dados.St_cupomavulso = true;
                                                dados.St_agruparProduto = false;

                                                PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                                TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                                if (rNFCe != null)
                                                    if (!rNFCe.St_contingencia)
                                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                        {
                                                            fGerNfe.rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                rNFCe.Id_nfcestr,
                                                                                                null);
                                                            fGerNfe.ShowDialog();
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
                                                        bsNFCe.DataSource = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
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
                                                                                    "where x.cd_empresa = a.cd_empresa " +
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
                                                return;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                        else
                                            MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                    {
                        if (fGerar.ShowDialog() == DialogResult.OK)
                            if (fGerar.lItens != null)
                                if (fGerar.lItens.Count > 0)
                                {
                                    if (lCfg == null)
                                    {
                                        lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(fGerar.lItens[0].Cd_empresa, null);
                                        if (lCfg.Count.Equals(0))
                                        {
                                            MessageBox.Show("Não existe configuração para realizar venda na empresa " + fGerar.lItens[0].Cd_empresa.Trim() + ".",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                    if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                                    {
                                        try
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
                                            dados.St_vendacombustivel = false;
                                            dados.St_cupomavulso = true;
                                            dados.St_agruparProduto = false;

                                            PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                            TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                            if (rNFCe != null)
                                                if (!rNFCe.St_contingencia)
                                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                    {
                                                        fGerNfe.rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                            rNFCe.Id_nfcestr,
                                                                                            null);
                                                        fGerNfe.ShowDialog();
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
                                                    bsNFCe.DataSource = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null);
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
                                                                                    "where x.cd_empresa = a.cd_empresa " +
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
                                            return;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                        MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Permitido gerar cupom somente de venda gravada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GerarNfe()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                if (bsVendaRapida.Current != null)
                    if (MessageBox.Show("Gerar NFe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Verificar se venda possui cupom
                        if (new TCD_NFCe().BuscarEscalar(
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
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_cupom " +
                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                            }, "1") != null)
                        {
                            MessageBox.Show("Venda possui cupom fiscal/NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Verificar se venda tem Nota faturada
                        object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                        "inner join TB_PDV_Pedido_X_VendaRapida y " +
                                                        "on x.nr_pedido = y.nr_pedido " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_pedidoitem = y.id_pedidoitem " +
                                                        "and x.cd_empresa = y.cd_empresa " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and y.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'" +
                                                        "and y.Id_VendaRapida = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ") "
                                        }
                                        }, "a.nr_notafiscal");
                        if (obj != null)
                        {
                            MessageBox.Show("Essa venda já está faturada. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Verificar se existe pedido amarrado nessa venda
                        CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                        new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_empresa =  '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'" +
                                                      "and isnull(a.st_pedido, 'F') <> 'C' " +
                                                      "and x.id_vendarapida = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr + ") "
                            }
                            }, 0, string.Empty);
                        if (lPed.Count > 0)
                            lPed.ForEach(p => CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(p, null));
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            //Buscar configuracao
                            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
                            if (lCfg.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe configuração para realizar venda na empresa " + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
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
                                TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
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
                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                                        "where x.cd_empresa = c.cd_empresa "+
                                                        "and x.nr_lanctoduplicata = c.nr_lancto "+
                                                        "and x.cd_empresa = '" + rFat.Cd_empresa.Trim() + "' "+
                                                        "and x.nr_lanctofiscal = " + rFat.Nr_lanctofiscalstr + ")"
                                        }
                                    }, 0, string.Empty);
                                if (lBloqueto.Count > 0)
                                    //Chamar tela de impressao para o bloqueto
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                        fImp.pMensagem = "BLOQUETOS DA NOTA FISCAL Nº" + rFat.Nr_notafiscalstr;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                              lBloqueto,
                                                                                              fImp.pSt_imprimir,
                                                                                              fImp.pSt_visualizar,
                                                                                              fImp.pSt_enviaremail,
                                                                                              fImp.pSt_exportPdf,
                                                                                              fImp.Path_exportPdf,
                                                                                              fImp.pDestinatarios,
                                                                                              "BLOQUETO(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscalstr,
                                                                                              fImp.pDs_mensagem,
                                                                                              false);
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
                using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                {
                    if (fGerar.ShowDialog() == DialogResult.OK)
                        if (fGerar.lItens != null)
                        {
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                            try
                            {
                                //Buscar configuracao
                                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(fGerar.lItens[0].Cd_empresa, null);
                                if (lCfg.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe configuração para realizar venda na empresa " + fGerar.lItens[0].Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
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
                                                                                                  false,
                                                                                                  string.Empty,
                                                                                                  lCfg[0],
                                                                                                  fGerar.lItens,
                                                                                                  ref rPedProduto,
                                                                                                  ref rPedServico);
                                    if (rPedProduto != null)
                                    {
                                        TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                        //Buscar pedido
                                        rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                        //Buscar itens pedido
                                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
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
                                    MessageBox.Show("Obrigatorio informar cliente do pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
                MessageBox.Show("Permitido gerar NFe somente de venda gravada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void VincularCfNFe()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
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
            if (bsItens.Current == null ? false :
                vModo.Equals(TTpModo.tm_Insert) &&
                !st_editando)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(CD_Empresa.Text,
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
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa.Text,
                                                                                                                    CD_Clifor.Text,
                                                                                                                    (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto,
                                                                                                                    CD_TabelaPreco.Text,
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
                    if ((bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados > decimal.Zero)
                    {
                        Tot_pontos_resgatar += (bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados;
                        lblPontos.Text = "Pontos Resgatar: " + Tot_pontos_resgatar.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                        bb_resgatarPontos.Visible = true;
                    }
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
                    bbPessoasAut.Enabled = bsItens.Count.Equals(0);
                    CD_TabelaPreco.Enabled = bsItens.Count.Equals(0);
                    bb_tabelapreco.Enabled = bsItens.Count.Equals(0);
                    cd_endereco.Enabled = bsItens.Count.Equals(0);
                    bb_endereco.Enabled = bsItens.Count.Equals(0);
                }
            }
        }

        private void ReimprimirVenda()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                if (bsVendaRapida.Current != null && !string.IsNullOrEmpty(id_venda.Text))
                {
                    if (MessageBox.Show("Reimprimir venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
                        if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T")))
                        {
                            TCN_VendaRapida.ImprimirVendaRapida(bsVendaRapida.Current as TRegistro_VendaRapida);
                            return;
                        }
                        else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                        {
                            object obj1 = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                }
                                            }, "a.porta_imptick");
                            if (obj1 == null)
                                throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                            TCN_VendaRapida.ImprimirReduzido(bsVendaRapida.Current as TRegistro_VendaRapida, lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, obj1.ToString());
                        }
                        else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                            ImprimirGraficoReduzido(bsVendaRapida.Current as TRegistro_VendaRapida);
                        else
                            ImprimirGrafico(bsVendaRapida.Current as TRegistro_VendaRapida);
                    }
                }
                else
                    using (TFReimprimeVenda fVenda = new TFReimprimeVenda())
                    {
                        fVenda.ShowDialog();
                    }
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

        private void NovoCliente()
        {
            if (TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
            {
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (!string.IsNullOrEmpty(CD_Clifor.Text))
                        if (!lCfg[0].Cd_clifor.Trim().Equals(CD_Clifor.Text.Trim()))
                        {
                            TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor.Text, null);
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

        private void FaturarPreVenda()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                //Verificar se existe caixa aberto para realizar venda
                if (rCaixa != null)
                {
                    using (TFListaPreVenda fLista = new TFListaPreVenda())
                    {
                        fLista.LoginPDV = LoginPdv;
                        if (fLista.ShowDialog() == DialogResult.OK)
                            if (fLista.lVenda != null)
                                if (fLista.lVenda.Count > 0)
                                    ProcessarFatPreVenda(fLista.lVenda);
                    }
                }
                else
                    MessageBox.Show("Não existe caixa aberto para realizar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ja existe uma venda em andamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarFatPreVenda(List<TRegistro_PreVenda> lPreVenda)
        {
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPreVenda[0].Cd_empresa, null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração para realizar venda na empresa " + lPreVenda[0].Cd_empresa.Trim() + ".",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // traz valor do adto TB_LOC_Itens_X_PreVenda
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(lPreVenda[0].Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + lPreVenda[0].Cd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(lPreVenda[0].Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + lPreVenda[0].Cd_clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.vl_receber - a.vl_pagar";
            filtro[filtro.Length - 1].vOperador = ">";
            filtro[filtro.Length - 1].vVL_Busca = "0";

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = string.Empty;
            filtro[filtro.Length - 1].vVL_Busca = " exists( select x.id_prevenda from TB_LOC_Itens_X_PreVenda x " +
               " join TB_LOC_AdtoLocacao z on z.id_locacao = x.id_locacao and z.id_adto = a.Id_Adto where x.id_prevenda = " + lPreVenda[0].Id_prevendastr + ")";


            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento ladt
                = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(filtro, 0, string.Empty);
            if (ladt.Count > 0)
                vladto.Value = ladt[0].Vl_adto;
            else vladto.Value = decimal.Zero;

            //Venda sem portador
            if (lPreVenda.Exists(p => string.IsNullOrEmpty(p.Cd_portador) && !p.St_condicionalbool))
            {
                vModo = TTpModo.tm_Insert;
                ModoBotoes();
                HabilitarCampos(true);

                st_editando = true;
                Quantidade.Enabled = false;
                ds_observacao.Enabled = true;
                bsVendaRapida.AddNew();
                CD_TabelaPreco.Text = lPreVenda[0].Cd_tabelaPreco;
                CD_CompVend.Text = lPreVenda[0].Cd_vendedor;
                CD_Empresa.Text = lPreVenda[0].Cd_empresa;
                CD_Empresa_Leave(this, new EventArgs());
                CD_Clifor.Text = lPreVenda[0].Cd_clifor;
                NM_Clifor.Text = lPreVenda[0].Nm_clifor;
                id_pessoa.Text = lPreVenda[0].Id_pessoastr;
                nm_pessoa.Text = lPreVenda[0].Nm_pessoa;
                cd_cliforind.Text = lPreVenda[0].Cd_cliforInd;
                nm_cliforind.Text = lPreVenda[0].Nm_cliforInd;
                cd_endereco.Text = lPreVenda[0].Cd_endereco;
                ds_endereco.Text = lPreVenda[0].Ds_endereco;
                Cd_representante.Text = lPreVenda[0].Cd_representante;
                Nm_representante.Text = lPreVenda[0].Nm_representante;
                ds_observacao.Text = lPreVenda[0].Ds_observacao + (lPreVenda[0].Id_locacao != null ? " REF LOCAÇÃO: " + lPreVenda[0].Id_locacao.ToString() : string.Empty);
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;
                (bsVendaRapida.Current as TRegistro_VendaRapida).NR_Docto_Origem = "REF LOCAÇÃO: " + lPreVenda[0].Id_locacao.ToString();
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao = lPreVenda[0].Id_locacao.ToString();
            }
            foreach (TRegistro_PreVenda p in lPreVenda)
            {
                //Buscar Itens PreVenda
                p.lItens =
                   TCN_ItensPreVenda.Buscar(p.Cd_empresa,
                                            p.Id_prevendastr,
                                            string.Empty,
                                            string.Empty,
                                            true,
                                            null);
                if (p.lItens.Count.Equals(0))
                {
                    MessageBox.Show("Pré-Venda sem saldo para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vModo = TTpModo.tm_Standby;
                    ModoBotoes();
                    HabilitarCampos(false);
                    LimparCampos();
                    break;
                }
                //Verificar se e condicional
                if (p.St_condicionalbool)
                {
                    TRegistro_Condicional rCond = new TRegistro_Condicional();
                    rCond.Cd_empresa = p.Cd_empresa;
                    rCond.Cd_clifor = p.Cd_clifor;
                    rCond.Nm_clifor = p.Nm_clifor;
                    rCond.Cd_endereco = p.Cd_endereco;
                    rCond.Ds_endereco = p.Ds_endereco;
                    rCond.Cd_vendedor = p.Cd_vendedor;
                    rCond.Nm_vendedor = p.Nm_vendedor;
                    rCond.Cd_cliforind = p.Cd_cliforInd;
                    rCond.Id_pessoa = p.Id_pessoa;
                    rCond.Dt_condicional = p.Dt_emissao;
                    rCond.Ds_observacao = p.Ds_observacao;
                    rCond.Tp_movimento = "S";
                    rCond.St_registro = "A";
                    p.lItens.ForEach(v => rCond.lItens.Add(new TRegistro_ItensCondicional()
                    {
                        Cd_produto = v.Cd_produto,
                        Ds_produto = v.Ds_produto,
                        Cd_local = lCfg[0].Cd_local,
                        Quantidade = v.Quantidade,
                        Vl_unitario = v.Vl_unitario,
                        St_registro = "A",
                        rItemPreVenda = v
                    }));
                    //Gravar Condicional
                    TCN_Condicional.Gravar(rCond, null);
                    MessageBox.Show("Venda Condicional Nº " + p.Id_prevendastr + " faturada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PrintCondicional(rCond);
                }
                else
                {
                    //Buscar Parcelas PreVenda
                    p.DT_Vencto =
                       TCN_PreVenda_DT_Vencto.Buscar(p.Id_prevendastr, p.Cd_empresa, null);

                    //Verificar se venda possui portador
                    if (!string.IsNullOrEmpty(p.Cd_portador))
                    {
                        TRegistro_CadPortador rPortador =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(p.Cd_portador,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      false,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null)[0];

                        //Criar venda
                        bsVendaRapida.AddNew();
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa = lPreVenda[0].Cd_empresa;
                        CD_Empresa_Leave(this, new EventArgs());
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_tabelapreco = p.Cd_tabelaPreco;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = p.Cd_clifor;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = p.Nm_clifor;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pessoastr = p.Id_pessoastr;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_pessoa = p.Nm_pessoa;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = p.Cd_endereco;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_endereco = p.Ds_endereco;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_vend = p.Cd_vendedor;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_cliforInd = p.Cd_cliforInd;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_cliforInd = p.Nm_cliforInd;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_representante = p.Cd_representante;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_representante = p.Nm_representante;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Ds_observacao = p.Ds_observacao + (p.Id_locacao != null ? " REF LOCAÇÃO: " + p.Id_locacao.ToString() : string.Empty);
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred = p.Vl_devcred;
                        (bsVendaRapida.Current as TRegistro_VendaRapida).NR_Docto_Origem = "REF LOCAÇÃO: " + p.Id_locacao.ToString();
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao = p.Id_locacao.ToString();

                        foreach (TRegistro_ItensPreVenda v in p.lItens)
                        {
                            //Verificar saldo estoque do produto
                            if (lCfg[0].St_movestoquebool)
                            {
                                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_produto)) &&
                                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_produto)))
                                {
                                    if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_produto) &&
                                        !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(v.Cd_produto))
                                    {
                                        decimal saldo = BuscarSaldoLocal((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, v.Cd_produto);
                                        if (saldo < Quantidade.Value)
                                        {
                                            MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                            "Empresa.........: " + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "-" + (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_empresa.Trim() + "\r\n" +
                                                            "Produto.........: " + v.Cd_produto.Trim() + "-" + v.Ds_produto.Trim() + "\r\n" +
                                                            "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                            "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }

                                        else
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                new TRegistro_VendaRapida_Item()
                                                {
                                                    Cd_produto = v.Cd_produto,
                                                    Ds_produto = v.Ds_produto,
                                                    Sigla_unidade = v.Sigla_unidade,
                                                    Cd_local = lCfg[0].Cd_local,
                                                    Ds_local = lCfg[0].Ds_local,
                                                    Cd_grupo = v.Cd_grupo,
                                                    Cd_tabelapreco = v.Cd_tabelaPreco,
                                                    Cd_vendedor = p.Cd_vendedor,
                                                    Quantidade = v.Quantidade,
                                                    Vl_unitario = v.Vl_unitario,
                                                    Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                                    Vl_desconto = v.Vl_desconto,
                                                    Vl_acrescimo = v.Vl_acrescimo,
                                                    Vl_juro_fin = v.Vl_juro_fin,
                                                    Vl_frete = v.Vl_frete,
                                                    St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                                    rItemPreVenda = v,
                                                    ds_celula = v.Ds_Celula,
                                                    ds_rua = v.Ds_Rua,
                                                    ds_secao = v.Ds_Secao
                                                });
                                    }
                                    else
                                    {
                                        //Buscar ficha tecnica produto composto
                                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(v.Cd_produto, string.Empty, null);
                                        lFicha.ForEach(x => x.Quantidade = x.Quantidade * v.Quantidade);
                                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                        //Buscar saldo itens da ficha tecnica
                                        string msg = string.Empty;
                                        lFicha.ForEach(x =>
                                        {
                                            //Buscar saldo estoque do item
                                            decimal saldo = decimal.Zero;
                                            CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, x.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                            if (saldo < x.Quantidade)
                                                msg += "Produto.........: " + x.Cd_item.Trim() + "-" + x.Ds_item.Trim() + "\r\n" +
                                                       "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                        });
                                        if (!string.IsNullOrEmpty(msg))
                                        {
                                            msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                            MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
                                        else
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                new TRegistro_VendaRapida_Item()
                                                {
                                                    Cd_produto = v.Cd_produto,
                                                    Ds_produto = v.Ds_produto,
                                                    Sigla_unidade = v.Sigla_unidade,
                                                    Cd_local = lCfg[0].Cd_local,
                                                    Ds_local = lCfg[0].Ds_local,
                                                    Cd_grupo = v.Cd_grupo,
                                                    Cd_tabelapreco = v.Cd_tabelaPreco,
                                                    Cd_vendedor = p.Cd_vendedor,
                                                    Quantidade = v.Quantidade,
                                                    Vl_unitario = v.Vl_unitario,
                                                    Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                                    Vl_desconto = v.Vl_desconto,
                                                    Vl_acrescimo = v.Vl_acrescimo,
                                                    Vl_juro_fin = v.Vl_juro_fin,
                                                    Vl_frete = v.Vl_frete,
                                                    St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                                    rItemPreVenda = v
                                                });
                                    }
                                }
                                else
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                        new TRegistro_VendaRapida_Item()
                                        {
                                            Cd_produto = v.Cd_produto,
                                            Ds_produto = v.Ds_produto,
                                            Sigla_unidade = v.Sigla_unidade,
                                            Cd_local = lCfg[0].Cd_local,
                                            Ds_local = lCfg[0].Ds_local,
                                            Cd_grupo = v.Cd_grupo,
                                            Cd_tabelapreco = v.Cd_tabelaPreco,
                                            Cd_vendedor = p.Cd_vendedor,
                                            Quantidade = v.Quantidade,
                                            Vl_unitario = v.Vl_unitario,
                                            Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                            Vl_desconto = v.Vl_desconto,
                                            Vl_acrescimo = v.Vl_acrescimo,
                                            Vl_juro_fin = v.Vl_juro_fin,
                                            Vl_frete = v.Vl_frete,
                                            St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                            rItemPreVenda = v
                                        });
                            }
                            else
                                (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                        new TRegistro_VendaRapida_Item()
                                        {
                                            Cd_produto = v.Cd_produto,
                                            Ds_produto = v.Ds_produto,
                                            Sigla_unidade = v.Sigla_unidade,
                                            Cd_local = lCfg[0].Cd_local,
                                            Ds_local = lCfg[0].Ds_local,
                                            Cd_grupo = v.Cd_grupo,
                                            Cd_tabelapreco = v.Cd_tabelaPreco,
                                            Cd_vendedor = p.Cd_vendedor,
                                            Quantidade = v.Quantidade,
                                            Vl_unitario = v.Vl_unitario,
                                            Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                            Vl_desconto = v.Vl_desconto,
                                            Vl_acrescimo = v.Vl_acrescimo,
                                            Vl_juro_fin = v.Vl_juro_fin,
                                            Vl_frete = v.Vl_frete,
                                            St_baixapatrimoniobool = v.St_itemLocacao,
                                            rItemPreVenda = v
                                        });
                        }
                        bsVendaRapida.ResetCurrentItem();
                        TotalizarVenda();
                        if (rPortador.St_controletitulobool)//Cheque
                        {
                            //Verificar se cliente possui credito
                            if (p.Vl_devcred.Equals(decimal.Zero))
                            {
                                decimal pVl_faturar = p.Vl_prevenda;
                                p.Vl_devcred = BuscarCreditoCliente(ref pVl_faturar);
                                if (pVl_faturar <= 0)
                                    return;
                                else p.Vl_prevenda = pVl_faturar;
                                p.DT_Vencto =
                                TCN_PreVenda.Calcula_Parcelas(p, true);
                                if (rPortador == null)
                                    rPortador = new TRegistro_CadPortador();
                            }
                            else
                            {
                                //Verificar se cliente possui adiantamento
                                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? string.Empty : "a.id_adto",
                                                    vOperador = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? "exists" : "=",
                                                    vVL_Busca = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                                                "(select 1 from TB_LOC_AdtoLocacao x " +
                                                                "where a.id_adto = x.id_adto " +
                                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) " : "a.id_adto"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                }
                                            }, 0, string.Empty);
                                if (lAdiant.Count > 0)
                                {
                                    if (lAdiant.Sum(v => v.Vl_total_devolver) < p.Vl_devcred)
                                        if (MessageBox.Show("Saldo credito disponivel para devolução é menor que o valor informado na PRÉ-VENDA.\r\n" +
                                                           "Deseja utilizar somente saldo disponivel<" + lAdiant.Sum(v => v.Vl_total_devolver).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + ">?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                        {
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
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
                                        List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred > p.Vl_prevenda)
                                            this.TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                                        else
                                        {
                                            decimal tot_devolver = p.Vl_devcred;
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
                                        }
                                        if (rPortador == null)
                                            rPortador = new TRegistro_CadPortador();
                                        //Lancar Devolução Credito
                                        lDevolCred[0].lCred = lDev;
                                        lDevolCred[0].Vl_pagtoPDV = lDev.Sum(v => v.Vl_processar);
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                                        p.Vl_prevenda = p.Vl_prevenda - lDev.Sum(v => v.Vl_processar);
                                        if (p.Vl_prevenda <= decimal.Zero)
                                        {
                                            try
                                            {
                                                FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //Cancelar venda
                                                st_editando = false;
                                                vModo = TTpModo.tm_Standby;
                                                ModoBotoes();
                                                HabilitarCampos(false);
                                                LimparCampos();
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Não existe saldo credito disponivel para devolução.\r\n" +
                                                           "Deseja ignorar o valor do credito e finalizar a venda?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        p.Vl_devcred = decimal.Zero;
                                    else
                                    {
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                            }
                            using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                            {
                                fListaCheques.Tp_mov = "R";
                                fListaCheques.Cd_empresa = lCfg[0].Cd_empresa;
                                fListaCheques.St_pdv = false;
                                //Buscar Config PDV Empresa
                                if (lCfg.Count > 0)
                                {
                                    fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                                    fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                                }
                                fListaCheques.Cd_clifor = CD_Clifor.Text;
                                fListaCheques.Cd_historico = lCfg[0].Cd_historicocaixa;
                                fListaCheques.Ds_historico = lCfg[0].Ds_historicocaixa;
                                fListaCheques.Cd_portador = rPortador.Cd_portador;
                                fListaCheques.Ds_portador = rPortador.Ds_portador;
                                fListaCheques.Nm_clifor = NM_Clifor.Text;
                                fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                                fListaCheques.Vl_totaltitulo = p.Vl_prevenda;
                                fListaCheques.St_bloquearTroco = false;
                                if (fListaCheques.ShowDialog() == DialogResult.OK)
                                {
                                    rPortador.lCheque = fListaCheques.lCheques;
                                    rPortador.Vl_pagtoPDV = fListaCheques.lCheques.Sum(v => v.Vl_titulo);
                                    //Troco
                                    rPortador.Vl_trocoPDV = Math.Round(rPortador.Vl_pagtoPDV - p.Vl_prevenda, 2);
                                }
                                else
                                {
                                    MessageBox.Show("Cheque não foi informado... Pré Venda " + p.Id_prevendastr + " não sera processada! ");
                                    //Cancelar venda
                                    st_editando = false;
                                    vModo = TTpModo.tm_Standby;
                                    ModoBotoes();
                                    HabilitarCampos(false);
                                    LimparCampos();
                                    continue;
                                }
                            }
                        }
                        else if (rPortador.St_cartaocreditobool)//Cartao Cred/Deb
                        {
                            //Verificar se cliente possui credito
                            if (p.Vl_devcred.Equals(decimal.Zero))
                            {
                                decimal pVl_faturar = p.Vl_prevenda;
                                p.Vl_devcred = BuscarCreditoCliente(ref pVl_faturar);
                                if (pVl_faturar <= 0)
                                    return;
                                else p.Vl_prevenda = pVl_faturar;
                                p.DT_Vencto =
                                TCN_PreVenda.Calcula_Parcelas(p, true);
                                if (rPortador == null)
                                    rPortador = new TRegistro_CadPortador();
                            }
                            else
                            {
                                //Verificar se cliente possui adiantamento
                                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? string.Empty : "a.id_adto",
                                                    vOperador = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? "exists" : "=",
                                                    vVL_Busca = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                                                "(select 1 from TB_LOC_AdtoLocacao x " +
                                                                "where a.id_adto = x.id_adto " +
                                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) " : "a.id_adto"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                }
                                            }, 0, string.Empty);
                                if (lAdiant.Count > 0)
                                {
                                    if (lAdiant.Sum(v => v.Vl_total_devolver) < p.Vl_devcred)
                                        if (MessageBox.Show("Saldo credito disponivel para devolução é menor que o valor informado na PRÉ-VENDA.\r\n" +
                                                           "Deseja utilizar somente saldo disponivel<" + lAdiant.Sum(v => v.Vl_total_devolver).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + ">?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                        {
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
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
                                        List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred > p.Vl_prevenda)
                                            this.TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                                        else
                                        {
                                            decimal tot_devolver = p.Vl_devcred;
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
                                        }
                                        if (rPortador == null)
                                            rPortador = new TRegistro_CadPortador();
                                        //Lancar Devolução Credito
                                        lDevolCred[0].lCred = lDev;
                                        lDevolCred[0].Vl_pagtoPDV = lDev.Sum(v => v.Vl_processar);
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                                        p.Vl_prevenda = p.Vl_prevenda - lDev.Sum(v => v.Vl_processar);
                                        if (p.Vl_prevenda <= decimal.Zero)
                                        {
                                            try
                                            {
                                                FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Não existe saldo credito disponivel para devolução.\r\n" +
                                                           "Deseja ignorar o valor do credito e finalizar a venda?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        p.Vl_devcred = decimal.Zero;
                                    else
                                    {
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                            }
                            if (p.DT_Vencto.Count > 0)
                            {
                                //Buscar dados fatura cartao credito
                                using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                {
                                    fCartao.pCd_empresa = lCfg[0].Cd_empresa;
                                    fCartao.D_C = "C";
                                    fCartao.Vl_saldofaturar = p.Vl_prevenda;
                                    fCartao.St_bloquearTroco = false;
                                    fCartao.Qtd_parcelasFaturar = p.DT_Vencto.Count;
                                    if (fCartao.ShowDialog() == DialogResult.OK)
                                    {
                                        fCartao.lFatura.ForEach(v => rPortador.lFatura.Add(v));
                                        rPortador.Vl_pagtoPDV += fCartao.lFatura.Sum(v => v.Vl_fatura);
                                        //Troco
                                        rPortador.Vl_trocoPDV = Math.Round(rPortador.Vl_pagtoPDV - p.Vl_prevenda, 2);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Fatura não foi informada... Pré Venda " + p.Id_prevendastr + " não sera processada! ");
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                                {
                                    if (fD_C.ShowDialog() == DialogResult.OK)
                                    {
                                        //Buscar dados fatura cartao credito
                                        using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                        {
                                            fCartao.pCd_empresa = lCfg[0].Cd_empresa;
                                            fCartao.D_C = fD_C.D_C;
                                            fCartao.Vl_saldofaturar = p.Vl_prevenda;
                                            fCartao.St_bloquearTroco = false;
                                            fCartao.St_validarSaldo = true;
                                            if (fCartao.ShowDialog() == DialogResult.OK)
                                            {
                                                fCartao.lFatura.ForEach(v => rPortador.lFatura.Add(v));
                                                rPortador.Vl_pagtoPDV += fCartao.lFatura.Sum(v => v.Vl_fatura);
                                                //Troco
                                                rPortador.Vl_trocoPDV = Math.Round(rPortador.Vl_pagtoPDV - p.Vl_prevenda, 2);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Fatura não foi informada... Pré Venda " + p.Id_prevendastr + " não sera processada! ");
                                                //Cancelar venda
                                                st_editando = false;
                                                vModo = TTpModo.tm_Standby;
                                                ModoBotoes();
                                                HabilitarCampos(false);
                                                LimparCampos();
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Fatura não foi informada... Pré Venda " + p.Id_prevendastr + " não sera processada! ");
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        continue;
                                    }
                                }
                            }
                        }
                        else if (rPortador.Tp_portadorpdv.Trim().ToUpper().Equals("P"))//Duplicata
                        {
                            //Verificar se cliente possui credito
                            if (p.Vl_devcred.Equals(decimal.Zero))
                            {
                                decimal pVl_faturar = p.Vl_prevenda;
                                p.Vl_devcred = BuscarCreditoCliente(ref pVl_faturar);
                                if (pVl_faturar <= 0)
                                    return;
                                else p.Vl_prevenda = pVl_faturar;
                                if (p.Vl_devcred > 0)
                                {
                                    p.DT_Vencto =
                                    TCN_PreVenda.ReCalcula_VlParcela(p, true);
                                }
                                if (rPortador == null)
                                    rPortador = new TRegistro_CadPortador();
                            }
                            else
                            {
                                //Verificar se cliente possui adiantamento
                                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? string.Empty : "a.id_adto",
                                                    vOperador = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? "exists" : "=",
                                                    vVL_Busca = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                                                "(select 1 from TB_LOC_AdtoLocacao x " +
                                                                "where a.id_adto = x.id_adto " +
                                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) " : "a.id_adto"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                }
                                            }, 0, string.Empty);
                                if (lAdiant.Count > 0)
                                {
                                    if (lAdiant.Sum(v => v.Vl_total_devolver) < p.Vl_devcred)
                                        if (MessageBox.Show("Saldo credito disponivel para devolução é menor que o valor informado na PRÉ-VENDA.\r\n" +
                                                           "Deseja utilizar somente saldo disponivel<" + lAdiant.Sum(v => v.Vl_total_devolver).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + ">?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                        {
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
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
                                        List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred > p.Vl_prevenda)
                                            this.TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                                        else
                                        {
                                            decimal tot_devolver = p.Vl_devcred;
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
                                        }
                                        if (rPortador == null)
                                            rPortador = new TRegistro_CadPortador();
                                        //Lancar Devolução Credito
                                        decimal pVl_faturar = p.Vl_prevenda;
                                        lDevolCred[0].lCred = lDev;
                                        lDevolCred[0].Vl_pagtoPDV = lDev.Sum(v => v.Vl_processar);
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                                        p.Vl_prevenda = p.Vl_prevenda - lDev.Sum(v => v.Vl_processar);
                                        if (p.Vl_prevenda <= decimal.Zero)
                                        {
                                            try
                                            {
                                                FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            break;
                                        }
                                        else
                                        {
                                            p.Vl_prevenda = pVl_faturar;
                                            if (p.Vl_devcred > 0)
                                                p.DT_Vencto = TCN_PreVenda.ReCalcula_VlParcela(p, true);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Não existe saldo credito disponivel para devolução.\r\n" +
                                                           "Deseja ignorar o valor do credito e finalizar a venda?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        p.Vl_devcred = decimal.Zero;
                                        p.DT_Vencto = TCN_PreVenda.ReCalcula_VlParcela(p, true);
                                    }
                                    else
                                    {
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                            }

                            //Lançamento da duplicata internamente
                            //sem abrir frame ticket 7660
                            TRegistro_LanDuplicata _LanDuplicata = new TRegistro_LanDuplicata();
                            _LanDuplicata.Cd_portador = p.Cd_portador;
                            _LanDuplicata.Cd_empresa = p.Cd_empresa;
                            _LanDuplicata.Nm_empresa = p.Nm_empresa;
                            _LanDuplicata.Cd_clifor = p.Cd_clifor;
                            _LanDuplicata.Nm_clifor = p.Nm_clifor;
                            _LanDuplicata.Cd_endereco = p.Cd_endereco;
                            _LanDuplicata.Ds_endereco = p.Ds_endereco;
                            _LanDuplicata.Cd_historico = lCfg[0].Cd_historico;
                            _LanDuplicata.Ds_historico = lCfg[0].Ds_historico;
                            _LanDuplicata.Tp_duplicata = lCfg[0].Tp_duplicata;
                            _LanDuplicata.Ds_tpduplicata = lCfg[0].Ds_tpduplicata;
                            _LanDuplicata.Tp_mov = "R";
                            _LanDuplicata.Tp_doctostring = lCfg[0].Tp_doctostr;
                            _LanDuplicata.Ds_tpdocto = lCfg[0].Ds_tpdocto;
                            //Buscar condicao de pagamento
                            TList_CadCondPgto lCon =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(p.Cd_condPgto,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null);
                            if (lCon.Count > 0)
                            {
                                _LanDuplicata.Cd_condpgto = lCon[0].Cd_condpgto;
                                _LanDuplicata.Ds_condpgto = lCon[0].Ds_condpgto;
                                _LanDuplicata.Qt_parcelas = lCon[0].Qt_parcelas;
                            }
                            //Buscar Moeda Padrao
                            TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
                            if (tabela != null)
                                if (tabela.Count > 0)
                                {
                                    _LanDuplicata.Cd_moeda = tabela[0].Cd_moeda;
                                    _LanDuplicata.Ds_moeda = tabela[0].Ds_moeda_singular;
                                    _LanDuplicata.Sigla_moeda = tabela[0].Sigla;
                                }
                            //Buscar juro cond pagto
                            TList_CadJuro lJuro =
                                new TCD_CadJuro().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_condpgto x " +
                                                    "where x.cd_juro = a.cd_juro " +
                                                    "and x.cd_condpgto = '" + p.Cd_condPgto.Trim() + "')"
                                    }
                                }, 1, string.Empty);
                            if (lJuro.Count > 0)
                            {
                                _LanDuplicata.Cd_juro = lJuro[0].Cd_juro;
                                _LanDuplicata.Ds_juro = lJuro[0].Ds_juro;
                                _LanDuplicata.Tp_juro = lJuro[0].Tp_juro;
                                _LanDuplicata.Pc_jurodiario_atrazo = lJuro[0].Pc_jurodiario_atrazo;
                            }
                            _LanDuplicata.Ds_observacao = (bsVendaRapida.Current as TRegistro_VendaRapida).NR_Docto_Origem;
                            _LanDuplicata.Nr_docto = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                            "LOC" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                            _LanDuplicata.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            decimal id_parcela = decimal.Zero;
                            p.DT_Vencto.ForEach(x =>
                            {
                                TRegistro_LanParcela r = new TRegistro_LanParcela();
                                r.Cd_parcela = ++id_parcela;
                                r.Dt_vencto = p.Dt_emissao.Value.AddDays(int.Parse(x.DiasVencto.ToString()));
                                r.Vl_parcela = x.Vl_parcela;
                                r.Vl_parcela_padrao = x.Vl_parcela;
                                _LanDuplicata.Parcelas.Add(r);
                            });
                            _LanDuplicata.Vl_documento = p.DT_Vencto.Count > 0 ? p.DT_Vencto.Sum(z => z.Vl_parcela) : (p.Vl_prevenda - p.Vl_devcred);
                            TList_CadCFGBanco rCFGBanco = new TCD_CadCFGBanco().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rPortador.Cd_portador.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);
                            if (rCFGBanco.Count > 0)
                            {
                                _LanDuplicata.Id_configboletostr = rCFGBanco[0].Id_configstr;
                                _LanDuplicata.Cd_contager = rCFGBanco[0].Cd_contager;
                                _LanDuplicata.Cd_historico = "0157";
                                _LanDuplicata.Cd_historico_Dup = "0158";
                            }

                            try
                            {
                                TCN_LanDuplicata.GravarDuplicata(_LanDuplicata, true, null);

                                rPortador.lDup.Add(_LanDuplicata);
                                rPortador.Vl_pagtoPDV = _LanDuplicata.Vl_documento_padrao;
                                AbrirGavetaDinheiro();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //Cancelar venda
                                st_editando = false;
                                vModo = TTpModo.tm_Standby;
                                ModoBotoes();
                                HabilitarCampos(false);
                                LimparCampos();
                                return;
                            }

                            /*
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())

                            {
                                fDuplicata.vCd_empresa = p.Cd_empresa;
                                fDuplicata.vNm_empresa = p.Nm_empresa;
                                fDuplicata.vCd_clifor = p.Cd_clifor;
                                fDuplicata.vNm_clifor = p.Nm_clifor;
                                //Buscar condicao de pagamento
                                TList_CadCondPgto lCond =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(p.Cd_condPgto,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          decimal.Zero,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          null);
                                if (lCond.Count > 0)
                                {
                                    fDuplicata.vCd_condpgto = lCond[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCond[0].Ds_condpgto;
                                }

                                fDuplicata.vSt_ecf = true;
                                fDuplicata.vId_caixa = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                                fDuplicata.St_bloquearccusto = true;
                                fDuplicata.vCd_endereco = p.Cd_endereco;
                                fDuplicata.vDs_endereco = p.Ds_endereco;
                                fDuplicata.vCd_historico = lCfg[0].Cd_historico;
                                fDuplicata.vDs_historico = lCfg[0].Ds_historico;
                                fDuplicata.vTp_duplicata = lCfg[0].Tp_duplicata;
                                fDuplicata.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                fDuplicata.vTp_mov = "R";
                                fDuplicata.vTp_docto = lCfg[0].Tp_doctostr;
                                fDuplicata.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                //Buscar Moeda Padrao
                                TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null);
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
                                //Buscar juro cond pagto
                                TList_CadJuro lJuro =
                                    new TCD_CadJuro().Select(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_condpgto x " +
                                                    "where x.cd_juro = a.cd_juro " +
                                                    "and x.cd_condpgto = '" + p.Cd_condPgto.Trim() + "')"
                                    }
                                    }, 1, string.Empty);
                                if (lJuro.Count > 0)
                                {
                                    fDuplicata.vCd_juro = lJuro[0].Cd_juro;
                                    fDuplicata.vDs_juro = lJuro[0].Ds_juro;
                                    fDuplicata.vTp_juro = lJuro[0].Tp_juro;
                                    fDuplicata.vPc_jurodiario_atrazo = lJuro[0].Pc_jurodiario_atrazo;
                                }
                                fDuplicata.vDs_observacao = (bsVendaRapida.Current as TRegistro_VendaRapida).NR_Docto_Origem;
                                fDuplicata.vNr_docto = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                "LOC" + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                decimal id_parcela = decimal.Zero;
                                p.DT_Vencto.ForEach(x =>
                                {
                                    TRegistro_LanParcela r = new TRegistro_LanParcela();
                                    r.Cd_parcela = ++id_parcela;
                                    r.Dt_vencto = p.Dt_emissao.Value.AddDays(int.Parse(x.DiasVencto.ToString()));
                                    r.Vl_parcela = x.Vl_parcela;
                                    r.Vl_parcela_padrao = x.Vl_parcela;
                                    fDuplicata.lParc.Add(r);
                                });
                                fDuplicata.vVl_documento = p.DT_Vencto.Count > 0 ? p.DT_Vencto.Sum(z => z.Vl_parcela) : (p.Vl_prevenda - p.Vl_devcred);
                                object Id_Config = new TCD_CadCFGBanco().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.cd_empresa = '" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rPortador.Cd_portador.Trim() + "'"
                                                        }
                                                    }, "a.id_config");
                                fDuplicata.vId_configBoleto = Id_Config == null ? string.Empty : Id_Config.ToString();
                                fDuplicata.cd_condpgto.Enabled = false;
                                fDuplicata.bb_condpgto.Enabled = false;
                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                    if (fDuplicata.dsDuplicata.Current != null)
                                    {
                                        rPortador.lDup.Add((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata));
                                        rPortador.Vl_pagtoPDV = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                        AbrirGavetaDinheiro();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                    //Cancelar venda
                                    st_editando = false;
                                    vModo = TTpModo.tm_Standby;
                                    ModoBotoes();
                                    HabilitarCampos(false);
                                    LimparCampos();
                                    return;
                                }
                            }
                            */
                        }
                        else
                        {
                            //Verificar se cliente possui credito
                            if (p.Vl_devcred.Equals(decimal.Zero))
                            {
                                decimal pVl_faturar = p.Vl_prevenda;
                                p.Vl_devcred = BuscarCreditoCliente(ref pVl_faturar);
                                if (pVl_faturar <= 0)
                                    return;
                                else p.Vl_prevenda = pVl_faturar;
                                p.DT_Vencto =
                                TCN_PreVenda.Calcula_Parcelas(p, true);
                                if (rPortador == null)
                                    rPortador = new TRegistro_CadPortador();
                            }
                            else
                            {
                                //Verificar se cliente possui adiantamento
                                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? string.Empty : "a.id_adto",
                                                    vOperador = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ? "exists" : "=",
                                                    vVL_Busca = !string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) ?
                                                                "(select 1 from TB_LOC_AdtoLocacao x " +
                                                                "where a.id_adto = x.id_adto " +
                                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) " : "a.id_adto"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                }
                                            }, 0, string.Empty);
                                if (lAdiant.Count > 0)
                                {
                                    if (lAdiant.Sum(v => v.Vl_total_devolver) < p.Vl_devcred)
                                        if (MessageBox.Show("Saldo credito disponivel para devolução é menor que o valor informado na PRÉ-VENDA.\r\n" +
                                                           "Deseja utilizar somente saldo disponivel<" + lAdiant.Sum(v => v.Vl_total_devolver).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) + ">?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                        {
                                            //Cancelar venda
                                            st_editando = false;
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
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
                                        List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred > p.Vl_prevenda)
                                            TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                                        else
                                        {
                                            decimal tot_devolver = p.Vl_devcred;
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
                                        }
                                        if (rPortador == null)
                                            rPortador = new TRegistro_CadPortador();
                                        //Lancar Devolução Credito
                                        lDevolCred[0].lCred = lDev;
                                        lDevolCred[0].Vl_pagtoPDV = lDev.Sum(v => v.Vl_processar);
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                                        p.Vl_prevenda = p.Vl_prevenda - lDev.Sum(v => v.Vl_processar);
                                        if (p.Vl_prevenda > decimal.Zero)
                                            using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                            {
                                                fFechar.rCupom = bsVendaRapida.Current as TRegistro_VendaRapida;
                                                fFechar.pCd_empresa = CD_Empresa.Text;
                                                fFechar.pCd_clifor = CD_Clifor.Text;
                                                fFechar.pNm_clifor = NM_Clifor.Text;
                                                fFechar.rCfg = lCfg[0];
                                                fFechar.pVl_receber = p.Vl_prevenda;
                                                fFechar.lPdv = lPdv;
                                                fFechar.LoginPDV = LoginPdv;
                                                fFechar.Id_caixaPDV = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                                                fFechar.pCd_operador = CD_CompVend.Text;

                                                if (fFechar.ShowDialog() == DialogResult.OK)
                                                    if (fFechar.lPortador != null)
                                                        fFechar.lPortador.FindAll(v => v.Vl_pagtoPDV > decimal.Zero).ForEach(v => (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(v));
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                                                        //Cancelar venda
                                                        st_editando = false;
                                                        vModo = TTpModo.tm_Standby;
                                                        ModoBotoes();
                                                        HabilitarCampos(false);
                                                        LimparCampos();
                                                        return;
                                                    }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                                                    //Cancelar venda
                                                    st_editando = false;
                                                    vModo = TTpModo.tm_Standby;
                                                    ModoBotoes();
                                                    HabilitarCampos(false);
                                                    LimparCampos();
                                                    return;
                                                }
                                            }
                                        //Fechar venda pois obrigatoriamente sempre vai faturar valor total da venda.
                                        try
                                        {
                                            FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Não existe saldo credito disponivel para devolução.\r\n" +
                                                           "Deseja ignorar o valor do credito e finalizar a venda?",
                                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        p.Vl_devcred = decimal.Zero;
                                    else
                                    {
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                }
                            }
                            //Portador Dinheiro
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Casas_decimais = 2;
                                fQtde.Vl_default = p.Vl_prevenda;
                                fQtde.Vl_Minimo = p.Vl_prevenda;
                                fQtde.Ds_label = "Valor Recebido";
                                if (fQtde.ShowDialog() == DialogResult.OK)
                                {
                                    if (fQtde.Quantidade < p.Vl_prevenda)
                                    {
                                        MessageBox.Show("Não é permitido informar Vl.Receber menor que valor á Faturar!");
                                        //Cancelar venda
                                        st_editando = false;
                                        vModo = TTpModo.tm_Standby;
                                        ModoBotoes();
                                        HabilitarCampos(false);
                                        LimparCampos();
                                        return;
                                    }
                                    rPortador.Vl_pagtoPDV = fQtde.Quantidade;
                                    //Troco
                                    rPortador.Vl_trocoPDV = Math.Round(rPortador.Vl_pagtoPDV - p.Vl_prevenda, 2);
                                }
                                else
                                {
                                    MessageBox.Show("Valor recebido não informado... Pré Venda " + p.Id_prevendastr + " não sera processada! ");
                                    //Cancelar venda
                                    st_editando = false;
                                    vModo = TTpModo.tm_Standby;
                                    ModoBotoes();
                                    HabilitarCampos(false);
                                    LimparCampos();
                                    continue;
                                }
                            }
                        }
                        //Tratar troco
                        if (rPortador.Vl_trocoPDV > decimal.Zero)
                        {
                            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                            {
                                fTroco.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                                fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                fTroco.Vl_troco = rPortador.Vl_trocoPDV;
                                fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                if (fTroco.ShowDialog() == DialogResult.OK)
                                {
                                    if (fTroco.Vl_trocoCredito > decimal.Zero)
                                    {
                                        rPortador.Vl_credTroco = fTroco.Vl_trocoCredito;
                                        if (TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                        {
                                            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                            {
                                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                if (linha != null)
                                                {
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                                    //buscar endereco clifor
                                                    object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_clifor",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor
                                                                        }
                                                                    }, "a.cd_endereco");
                                                    if (obj != null)
                                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                                    rPortador.St_gerarCredito = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    //Cancelar venda
                                                    st_editando = false;
                                                    vModo = TTpModo.tm_Standby;
                                                    ModoBotoes();
                                                    HabilitarCampos(false);
                                                    LimparCampos();
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                            using (InputBox inp = new InputBox())
                                            {
                                                //buscar endereco clifor
                                                object obj = new TCD_CadEndereco().BuscarEscalar(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_clifor",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor
                                                                    }
                                                                }, "a.cd_endereco");
                                                if (obj != null)
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                                rPortador.Ds_mensagemCredito = inp.ShowDialog();
                                                rPortador.St_gerarCredito = true;
                                            }
                                    }
                                    if (fTroco.lChRepasse != null)
                                    {
                                        fTroco.lChRepasse.ForEach(v => rPortador.lChTroco.Add(v));
                                        if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                                        {
                                            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                            if (linha != null)
                                            {
                                                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                                (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //Cancelar venda
                                                st_editando = false;
                                                vModo = TTpModo.tm_Standby;
                                                ModoBotoes();
                                                HabilitarCampos(false);
                                                LimparCampos();
                                                return;
                                            }
                                        }
                                    }
                                    if (fTroco.lChTroco != null)
                                        fTroco.lChTroco.ForEach(v => rPortador.lChTroco.Add(v));
                                    if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                        rPortador.Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                    else rPortador.Vl_trocoPDV = decimal.Zero;
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Cancelar venda
                                    st_editando = false;
                                    vModo = TTpModo.tm_Standby;
                                    ModoBotoes();
                                    HabilitarCampos(false);
                                    LimparCampos();
                                    return;
                                }
                            }
                        }
                        try
                        {
                            (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(rPortador);
                            //Faturar Venda
                            FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Cancelar venda
                            st_editando = false;
                            vModo = TTpModo.tm_Standby;
                            ModoBotoes();
                            HabilitarCampos(false);
                            LimparCampos();
                        }
                        finally
                        { LimparCampos(); }
                    }
                    else
                    {
                        //Adicionar Crédito
                        (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred = p.Vl_devcred;
                        foreach (TRegistro_ItensPreVenda v in p.lItens)
                        {
                            //Verificar saldo estoque do produto
                            if (lCfg[0].St_movestoquebool)
                            {
                                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_produto)) &&
                                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_produto)))
                                {
                                    if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_produto) &&
                                         !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(v.Cd_produto))
                                    {
                                        decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, v.Cd_produto);
                                        Quantidade.Value = v.Quantidade;
                                        if (saldo < v.Quantidade)
                                        {
                                            MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                            "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                            "Produto.........: " + v.Cd_produto.Trim() + "-" + v.Ds_produto.Trim() + "\r\n" +
                                                            "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                            "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
                                        else
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                new TRegistro_VendaRapida_Item()
                                                {
                                                    Cd_produto = v.Cd_produto,
                                                    Ds_produto = v.Ds_produto,
                                                    Sigla_unidade = v.Sigla_unidade,
                                                    Cd_local = lCfg[0].Cd_local,
                                                    Ds_local = lCfg[0].Ds_local,
                                                    Cd_grupo = v.Cd_grupo,
                                                    Cd_tabelapreco = v.Cd_tabelaPreco,
                                                    Cd_vendedor = p.Cd_vendedor,
                                                    Quantidade = v.Quantidade,
                                                    Vl_unitario = v.Vl_unitario,
                                                    Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                                    Vl_desconto = v.Vl_desconto,
                                                    Vl_acrescimo = v.Vl_acrescimo,
                                                    Vl_juro_fin = v.Vl_juro_fin,
                                                    Vl_frete = v.Vl_frete,
                                                    St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                                    rItemPreVenda = v
                                                });
                                    }
                                    else
                                    {
                                        //Buscar ficha tecnica produto composto
                                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(v.Cd_produto, string.Empty, null);
                                        lFicha.ForEach(x => x.Quantidade = x.Quantidade * v.Quantidade);
                                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                        //Buscar saldo itens da ficha tecnica
                                        string msg = string.Empty;
                                        lFicha.ForEach(x =>
                                        {
                                            //Buscar saldo estoque do item
                                            decimal saldo = decimal.Zero;
                                            CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, x.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                            if (saldo < x.Quantidade)
                                                msg += "Produto.........: " + x.Cd_item.Trim() + "-" + x.Ds_item.Trim() + "\r\n" +
                                                       "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                        });
                                        if (!string.IsNullOrEmpty(msg))
                                        {
                                            msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                            MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            vModo = TTpModo.tm_Standby;
                                            ModoBotoes();
                                            HabilitarCampos(false);
                                            LimparCampos();
                                            return;
                                        }
                                        else
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                new TRegistro_VendaRapida_Item()
                                                {
                                                    Cd_produto = v.Cd_produto,
                                                    Ds_produto = v.Ds_produto,
                                                    Sigla_unidade = v.Sigla_unidade,
                                                    Cd_local = lCfg[0].Cd_local,
                                                    Ds_local = lCfg[0].Ds_local,
                                                    Cd_grupo = v.Cd_grupo,
                                                    Cd_tabelapreco = v.Cd_tabelaPreco,
                                                    Cd_vendedor = p.Cd_vendedor,
                                                    Quantidade = v.Quantidade,
                                                    Vl_unitario = v.Vl_unitario,
                                                    Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                                    Vl_desconto = v.Vl_desconto,
                                                    Vl_acrescimo = v.Vl_acrescimo,
                                                    Vl_juro_fin = v.Vl_juro_fin,
                                                    Vl_frete = v.Vl_frete,
                                                    St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                                    rItemPreVenda = v
                                                });
                                    }
                                }
                                else
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                        new TRegistro_VendaRapida_Item()
                                        {
                                            Cd_produto = v.Cd_produto,
                                            Ds_produto = v.Ds_produto,
                                            Sigla_unidade = v.Sigla_unidade,
                                            Cd_local = lCfg[0].Cd_local,
                                            Ds_local = lCfg[0].Ds_local,
                                            Cd_grupo = v.Cd_grupo,
                                            Cd_tabelapreco = v.Cd_tabelaPreco,
                                            Cd_vendedor = p.Cd_vendedor,
                                            Quantidade = v.Quantidade,
                                            Vl_unitario = v.Vl_unitario,
                                            Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                            Vl_desconto = v.Vl_desconto,
                                            Vl_acrescimo = v.Vl_acrescimo,
                                            Vl_juro_fin = v.Vl_juro_fin,
                                            Vl_frete = v.Vl_frete,
                                            St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                            rItemPreVenda = v
                                        });
                            }
                            else
                                (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                        new TRegistro_VendaRapida_Item()
                                        {
                                            Cd_produto = v.Cd_produto,
                                            Ds_produto = v.Ds_produto,
                                            Sigla_unidade = v.Sigla_unidade,
                                            Cd_local = lCfg[0].Cd_local,
                                            Ds_local = lCfg[0].Ds_local,
                                            Cd_grupo = v.Cd_grupo,
                                            Cd_tabelapreco = v.Cd_tabelaPreco,
                                            Cd_vendedor = p.Cd_vendedor,
                                            Quantidade = v.Quantidade,
                                            Vl_unitario = v.Vl_unitario,
                                            Vl_subtotal = v.Quantidade * v.Vl_unitario,
                                            Vl_desconto = v.Vl_desconto,
                                            Vl_acrescimo = v.Vl_acrescimo,
                                            Vl_juro_fin = v.Vl_juro_fin,
                                            Vl_frete = v.Vl_frete,
                                            St_baixapatrimoniobool = v.St_baixapatrimoniobool,
                                            rItemPreVenda = v,
                                            ds_secao = v.Ds_Secao,
                                            ds_rua = v.Ds_Rua,
                                            ds_celula = v.Ds_Celula
                                        });
                        }
                    }
                }
            }
            bsVendaRapida.ResetCurrentItem();
            TotalizarVenda();
            try
            {
                afterGrava(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Cancelar venda
                st_editando = false;
                vModo = TTpModo.tm_Standby;
                ModoBotoes();
                HabilitarCampos(false);
                LimparCampos();
            }
            finally
            { LimparCampos(); }
        }

        private void FaturarOrcamento()
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                //Verificar se existe caixa aberto para realizar venda
                if (rCaixa != null)
                {
                    using (FConsultaOrcamentoVenda imp = new FConsultaOrcamentoVenda())
                    {
                        if (imp.ShowDialog() == DialogResult.OK)
                            if (!string.IsNullOrEmpty(imp.nr_orcamento))
                            {
                                //Buscar orcamento
                                CamadaDados.Faturamento.Orcamento.TList_Orcamento lOrc =
                                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(imp.nr_orcamento,
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
                                                                                             decimal.Zero,
                                                                                             decimal.Zero,
                                                                                             "'AB', 'AR'",
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             false,
                                                                                             false,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             false,
                                                                                             false,
                                                                                             null);
                                if (lOrc.Count > 0)
                                {
                                    using (TFListaOrcamento fLista = new TFListaOrcamento())
                                    {
                                        fLista.Nr_orcamento = lOrc[0].Nr_orcamentostr;
                                        if (fLista.ShowDialog() == DialogResult.OK)
                                            if (fLista.lItens != null)
                                                if (fLista.lItens.Count > 0)
                                                {
                                                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lOrc[0].Cd_empresa, null);
                                                    if (lCfg.Count.Equals(0))
                                                    {
                                                        MessageBox.Show("Não existe configuração para realizar venda na empresa " + lOrc[0].Cd_empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                    //Buscar itens do orcamento
                                                    fLista.lItens.ForEach(p => lOrc[0].lItens.Add(p));
                                                    vModo = TTpModo.tm_Insert;
                                                    ModoBotoes();
                                                    HabilitarCampos(true);
                                                    Quantidade.Enabled = false;
                                                    ds_observacao.Enabled = true;
                                                    bsVendaRapida.AddNew();
                                                    CD_Empresa.Text = lCfg[0].Cd_empresa;
                                                    NM_Empresa.Text = lCfg[0].Nm_empresa;
                                                    CD_Clifor.Text = lOrc[0].Cd_clifor;
                                                    NM_Clifor.Text = lOrc[0].Nm_clifor;
                                                    cd_endereco.Text = lOrc[0].Cd_endereco;
                                                    ds_endereco.Text = lOrc[0].Ds_endereco;
                                                    ds_observacao.Text = lOrc[0].Ds_observacoes;
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_vend = lOrc[0].Cd_vendedor;
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;
                                                    //Buscar item da venda
                                                    foreach (CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item v in lOrc[0].lItens)
                                                    {
                                                        //Verificar saldo estoque do produto
                                                        if (lCfg[0].St_movestoquebool)
                                                        {
                                                            if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_produto)) &&
                                                                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_produto)))
                                                            {
                                                                if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_produto) &&
                                                                     !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(v.Cd_produto))
                                                                {
                                                                    decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, v.Cd_produto);
                                                                    if (saldo < v.Qtd_faturar)
                                                                    {
                                                                        MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                                                        "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                                                        "Produto.........: " + v.Cd_produto.Trim() + "-" + v.Ds_produto.Trim() + "\r\n" +
                                                                                        "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                                                        "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        //Alterar Layout Tela
                                                                        vModo = TTpModo.tm_Standby;
                                                                        ModoBotoes();
                                                                        HabilitarCampos(false);
                                                                        LimparCampos();
                                                                        return;
                                                                    }
                                                                    else
                                                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                            new TRegistro_VendaRapida_Item()
                                                                            {
                                                                                Cd_produto = v.Cd_produto,
                                                                                Ds_produto = v.Ds_produto,
                                                                                Sigla_unidade = v.Sigla_unid_produto,
                                                                                Cd_local = lCfg[0].Cd_local,
                                                                                Ds_local = lCfg[0].Ds_local,
                                                                                Cd_grupo = v.Cd_grupo,
                                                                                Cd_tabelapreco = CD_TabelaPreco.Text,
                                                                                Cd_vendedor = lOrc[0].Cd_vendedor,
                                                                                Quantidade = v.Qtd_faturar,
                                                                                Vl_unitario = v.Vl_unitario,
                                                                                Vl_subtotal = v.Qtd_faturar * v.Vl_unitario,
                                                                                Vl_desconto = (v.Qtd_faturar * v.Vl_unitario) * (v.Pc_desconto / 100),
                                                                                Vl_acrescimo = v.Vl_acrescimo,
                                                                                Vl_juro_fin = v.Vl_juro_fin,
                                                                                Vl_frete = v.Vl_frete,
                                                                                rItemOrcamento = v
                                                                            });
                                                                }
                                                                else
                                                                {
                                                                    //Buscar ficha tecnica produto composto
                                                                    CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                                                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(v.Cd_produto, string.Empty, null);
                                                                    lFicha.ForEach(x => x.Quantidade = x.Quantidade * v.Qtd_faturar);
                                                                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                                                    //Buscar saldo itens da ficha tecnica
                                                                    string msg = string.Empty;
                                                                    lFicha.ForEach(x =>
                                                                    {
                                                                        //Buscar saldo estoque do item
                                                                        decimal saldo = decimal.Zero;
                                                                        CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, x.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                                                        if (saldo < x.Quantidade)
                                                                            msg += "Produto.........: " + x.Cd_item.Trim() + "-" + x.Ds_item.Trim() + "\r\n" +
                                                                                   "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                                                    });
                                                                    if (!string.IsNullOrEmpty(msg))
                                                                    {
                                                                        msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                                                        MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        //Alterar Layout Tela
                                                                        vModo = TTpModo.tm_Standby;
                                                                        ModoBotoes();
                                                                        HabilitarCampos(false);
                                                                        LimparCampos();
                                                                        return;
                                                                    }
                                                                    else
                                                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                            new TRegistro_VendaRapida_Item()
                                                                            {
                                                                                Cd_produto = v.Cd_produto,
                                                                                Ds_produto = v.Ds_produto,
                                                                                Sigla_unidade = v.Sigla_unid_produto,
                                                                                Cd_local = lCfg[0].Cd_local,
                                                                                Ds_local = lCfg[0].Ds_local,
                                                                                Cd_grupo = v.Cd_grupo,
                                                                                Cd_tabelapreco = CD_TabelaPreco.Text,
                                                                                Cd_vendedor = lOrc[0].Cd_vendedor,
                                                                                Quantidade = v.Qtd_faturar,
                                                                                Vl_unitario = v.Vl_unitario,
                                                                                Vl_subtotal = v.Qtd_faturar * v.Vl_unitario,
                                                                                Vl_desconto = (v.Qtd_faturar * v.Vl_unitario) * (v.Pc_desconto / 100),
                                                                                Vl_acrescimo = v.Vl_acrescimo,
                                                                                Vl_juro_fin = v.Vl_juro_fin,
                                                                                Vl_frete = v.Vl_frete,
                                                                                rItemOrcamento = v
                                                                            });
                                                                }
                                                            }
                                                            else
                                                                (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                    new TRegistro_VendaRapida_Item()
                                                                    {
                                                                        Cd_produto = v.Cd_produto,
                                                                        Ds_produto = v.Ds_produto,
                                                                        Sigla_unidade = v.Sigla_unid_produto,
                                                                        Cd_local = lCfg[0].Cd_local,
                                                                        Ds_local = lCfg[0].Ds_local,
                                                                        Cd_grupo = v.Cd_grupo,
                                                                        Cd_tabelapreco = CD_TabelaPreco.Text,
                                                                        Cd_vendedor = lOrc[0].Cd_vendedor,
                                                                        Quantidade = v.Qtd_faturar,
                                                                        Vl_unitario = v.Vl_unitario,
                                                                        Vl_subtotal = v.Qtd_faturar * v.Vl_unitario,
                                                                        Vl_desconto = (v.Qtd_faturar * v.Vl_unitario) * (v.Pc_desconto / 100),
                                                                        Vl_acrescimo = v.Vl_acrescimo,
                                                                        Vl_juro_fin = v.Vl_juro_fin,
                                                                        Vl_frete = v.Vl_frete,
                                                                        rItemOrcamento = v
                                                                    });
                                                        }
                                                        else
                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                    new TRegistro_VendaRapida_Item()
                                                                    {
                                                                        Cd_produto = v.Cd_produto,
                                                                        Ds_produto = v.Ds_produto,
                                                                        Sigla_unidade = v.Sigla_unid_produto,
                                                                        Cd_local = lCfg[0].Cd_local,
                                                                        Ds_local = lCfg[0].Ds_local,
                                                                        Cd_grupo = v.Cd_grupo,
                                                                        Cd_tabelapreco = CD_TabelaPreco.Text,
                                                                        Cd_vendedor = lOrc[0].Cd_vendedor,
                                                                        Quantidade = v.Qtd_faturar,
                                                                        Vl_unitario = v.Vl_unitario,
                                                                        Vl_subtotal = v.Qtd_faturar * v.Vl_unitario,
                                                                        Vl_desconto = (v.Qtd_faturar * v.Vl_unitario) * (v.Pc_desconto / 100),
                                                                        Vl_acrescimo = v.Vl_acrescimo,
                                                                        Vl_juro_fin = v.Vl_juro_fin,
                                                                        Vl_frete = v.Vl_frete,
                                                                        rItemOrcamento = v
                                                                    });
                                                    }
                                                    bsVendaRapida.ResetCurrentItem();
                                                    TotalizarVenda();
                                                    //Verificar se orcamento possui financeiro programado
                                                    lOrc[0].lParcelas = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar(lOrc[0].Nr_orcamentostr, null);
                                                    if (lOrc[0].lParcelas.Count > 0)
                                                    {
                                                        //Verificar se a soma do valor das parcelas e diferente do total faturado
                                                        if (lOrc[0].lParcelas.Sum(p => p.Vl_parcela) != (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                                                        {
                                                            //Recalcular valor das parcelas
                                                            decimal vl_parcelas = Math.Round((bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) /
                                                                                                lOrc[0].lParcelas.Count, 2);
                                                            lOrc[0].lParcelas.ForEach(p => p.Vl_parcela = vl_parcelas);
                                                            lOrc[0].lParcelas[lOrc[0].lParcelas.Count - 1].Vl_parcela += (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) -
                                                                lOrc[0].lParcelas.Sum(p => p.Vl_parcela);
                                                        }
                                                        //Buscar dados condicao pagamento
                                                        TRegistro_CadCondPgto rCond =
                                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(lOrc[0].Cd_condpgto,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      1,
                                                                                                                      string.Empty,
                                                                                                                      null)[0];
                                                        if (rCond.Qt_parcelas > 0)
                                                        {
                                                            if (rCond.St_comentradabool)
                                                            {
                                                                using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                                                {
                                                                    fFechar.rCupom = bsVendaRapida.Current as TRegistro_VendaRapida;
                                                                    fFechar.pCd_empresa = CD_Empresa.Text;
                                                                    fFechar.pCd_clifor = CD_Clifor.Text;

                                                                    fFechar.pNm_clifor = NM_Clifor.Text;
                                                                    fFechar.rCfg = lCfg[0];
                                                                    fFechar.pVl_receber = lOrc[0].lParcelas[0].Vl_parcela;
                                                                    fFechar.LoginPDV = LoginPdv;
                                                                    fFechar.pCd_operador = CD_CompVend.Text;
                                                                    fFechar.Id_caixaPDV = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                                                                    if (fFechar.ShowDialog() == DialogResult.OK)
                                                                        if (fFechar.lPortador != null)
                                                                        {
                                                                            (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = fFechar.lPortador;
                                                                            lOrc[0].lParcelas.RemoveRange(0, 1);
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("Obrigatorio informar portador para recebimento da entrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                            bsVendaRapida.Clear();
                                                                            return;
                                                                        }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Obrigatorio informar portador para recebimento da entrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        bsVendaRapida.Clear();
                                                                        return;
                                                                    }
                                                                }
                                                            }

                                                            //Buscar portador a prazo
                                                            TList_CadPortador lPort =
                                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(string.Empty,
                                                                                                                          string.Empty,
                                                                                                                          decimal.Zero,
                                                                                                                          decimal.Zero,
                                                                                                                          false,
                                                                                                                          false,
                                                                                                                          "'P'",
                                                                                                                          1,
                                                                                                                          string.Empty,
                                                                                                                          string.Empty,
                                                                                                                          null);
                                                            if (lPort.Count > 0)
                                                            {
                                                                //Criar duplicata com as parcelas programadas no orcamento
                                                                TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                                                                rDup.Cd_empresa = lOrc[0].Cd_empresa;
                                                                rDup.Cd_clifor = lOrc[0].Cd_clifor;

                                                                rDup.Cd_endereco = lOrc[0].Cd_endereco;
                                                                rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                                                                rDup.Tp_docto = lCfg[0].Tp_docto;
                                                                rDup.Cd_condpgto = lOrc[0].Cd_condpgto;
                                                                if (string.IsNullOrEmpty(CD_Clifor.Text))
                                                                {
                                                                    using (Financeiro.Cadastros.TFCadCliforResumido res = new Financeiro.Cadastros.TFCadCliforResumido())
                                                                    {
                                                                        res.pNm_clifor = NM_Clifor.Text;
                                                                        //          res.pBairro = 
                                                                        if (res.ShowDialog() == DialogResult.OK)
                                                                        {
                                                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(res.rClifor, null);
                                                                            rDup.Cd_clifor = res.rClifor.Cd_clifor;
                                                                            object cd_end = new TCD_CadEndereco().BuscarEscalar(
                                                                                new TpBusca[]
                                                                                {
                                                                                    new TpBusca()
                                                                                    {
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador = "=",
                                                                                        vVL_Busca = res.rClifor.Cd_clifor
                                                                                    }
                                                                                }, "a.cd_endereco");
                                                                            rDup.Cd_endereco = cd_end.ToString();
                                                                        }
                                                                        else
                                                                            return;
                                                                    }

                                                                }

                                                                //Buscar dados juro
                                                                rDup.Cd_juro = rCond.Cd_juro;
                                                                rDup.Tp_juro = rCond.Tp_juro;
                                                                rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                                                                rDup.Qt_parcelas = rCond.Qt_parcelas;
                                                                rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                                                                rDup.St_venctoferiado = rCond.St_venctoemferiado;
                                                                rDup.Cd_moeda = rCond.Cd_moeda;
                                                                rDup.Cd_historico = lCfg[0].Cd_historico;
                                                                rDup.Complhistorico = "RECEBIMENTO VENDA ORCAMENTO";
                                                                rDup.Nr_docto = lOrc[0].Nr_orcamentostr;
                                                                rDup.Dt_emissao = (bsVendaRapida.Current as TRegistro_VendaRapida).Dt_emissao;
                                                                rDup.Vl_documento = lOrc[0].lParcelas.Sum(v => v.Vl_parcela);
                                                                rDup.Vl_documento_padrao = rDup.Vl_documento;
                                                                //Parcelas Duplicata
                                                                decimal parcela = 0;
                                                                lOrc[0].lParcelas.OrderBy(p => p.DiasVencto).ToList().ForEach(p =>
                                                                    {
                                                                        parcela++;
                                                                        rDup.Parcelas.Add(new TRegistro_LanParcela()
                                                                        {
                                                                            Cd_parcela = parcela,
                                                                            Dt_vencto = rDup.Dt_emissao.Value.AddDays(Convert.ToDouble(p.DiasVencto)),
                                                                            Vl_parcela = p.Vl_parcela,
                                                                            Vl_parcela_padrao = p.Vl_parcela
                                                                        });
                                                                    });
                                                                rDup.DupCotacao = new TRegistro_DuplicataCotacao()
                                                                {
                                                                    Cd_empresa = rDup.Cd_empresa,
                                                                    Cd_moeda = rDup.Cd_moeda,
                                                                    Cd_moedaresult = rDup.Cd_moeda,
                                                                    Dt_cotacao = rDup.Dt_emissao,
                                                                    Login = Utils.Parametros.pubLogin,
                                                                    Operador = "*",
                                                                    Vl_cotacao = 1
                                                                };
                                                                //Verificar credito
                                                                TRegistro_DadosBloqueio rDados =
                                                                    new TRegistro_DadosBloqueio();
                                                                if (TCN_DadosBloqueio.VerificarBloqueioCredito(rDup.Cd_clifor,
                                                                                                               rDup.Parcelas.Sum(p => p.Vl_parcela),
                                                                                                               true,
                                                                                                               ref rDados,
                                                                                                               null))
                                                                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                                                                    {
                                                                        fBloq.rDados = rDados;
                                                                        fBloq.Vl_fatura = rDup.Parcelas.Sum(p => p.Vl_parcela);
                                                                        fBloq.ShowDialog();
                                                                        if (!fBloq.St_desbloqueado)
                                                                            throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                                                                    }
                                                                lPort[0].lDup.Add(rDup);
                                                                lPort[0].Vl_pagtoPDV = rDup.Vl_documento;
                                                                (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador.Add(lPort[0]);
                                                                try
                                                                {
                                                                    FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    //Alterar Layout Tela
                                                                    vModo = TTpModo.tm_Standby;
                                                                    ModoBotoes();
                                                                    HabilitarCampos(false);
                                                                    LimparCampos();
                                                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                }
                                                            }
                                                        }
                                                        else
                                                            afterGrava(string.Empty);
                                                    }
                                                    else
                                                        afterGrava(string.Empty);
                                                }
                                    }
                                }
                                else
                                    MessageBox.Show("Orçamento não encontrado ou ja FATURADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                }
                else
                    MessageBox.Show("Não existe caixa aberto para realizar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ja existe uma venda em andamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            using (PostoCombustivel.TFLanParcelas fParcelas = new PostoCombustivel.TFLanParcelas())
            {
                fParcelas.Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", lCfg[0].Cd_empresa, null);
                fParcelas.pId_caixaoperacional = rCaixa.Id_caixa;
                fParcelas.Loginpdv = LoginPdv;
                fParcelas.Cd_contaoperacional = lCfg[0].Cd_contaoperacional;
                fParcelas.Ds_contaoperacional = lCfg[0].Ds_contaoperacional;
                fParcelas.ShowDialog();
            }
        }

        private void BuscarProduto()
        {
            if (lCfg.Count.Equals(0) ? false : !lCfg[0].St_produtocodigobool)
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
                        MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produto.Clear();
                        cd_produto.Focus();
                        return;
                    }
            }
            if (BuscarItens())
            {
                cd_produto.Clear();
                tot_frete_Leave(this, new EventArgs());
                Quantidade.Enabled = true;
                Quantidade.Focus();
            }
            else
            {
                MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Clear();
                cd_produto.Focus();
            }
            if (bsItens.Current != null)
            {
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto.Trim() + "'"
                                }
                                }, "a.id_caracteristicaH");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                    {
                        fGrade.pId_caracteristica = obj.ToString();
                        fGrade.pCd_empresa = CD_Empresa.Text;
                        fGrade.pCd_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto;
                        fGrade.pDs_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto;
                        fGrade.pTp_movimento = "S";
                        if (fGrade.ShowDialog() == DialogResult.OK)
                        {
                            fGrade.lGrade.ForEach(p => (bsItens.Current as TRegistro_VendaRapida_Item).lGrade.Add(p));
                            Quantidade.Value = fGrade.lGrade.Sum(p => p.Vl_mov);
                            Quantidade.Enabled = false;
                            if (vl_unitario.Enabled)
                                vl_unitario.Focus();
                            else if (pc_desconto.Enabled)
                                pc_desconto.Focus();
                            else pc_acrescimo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsItens.RemoveCurrent();
                        }
                    }
                AddCarrinho();
                LoginDesconto = string.Empty;
            }
        }

        private void AddCarrinho()
        {
            if (bsItens.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto,
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
                                    TRegistro_VendaRapida_Item rItemCupom = new TRegistro_VendaRapida_Item();
                                    rItemCupom.Cd_produto = p.CD_ProdVenda;
                                    rItemCupom.Ds_produto = p.DS_ProdVenda;
                                    rItemCupom.Cd_unidade = p.CD_Unidade;
                                    rItemCupom.Ds_unidade = p.DS_Unidade;
                                    rItemCupom.Sigla_unidade = p.Sigla_Unidade;
                                    rItemCupom.Ncm = p.NCM;
                                    rItemCupom.Vl_unitario = ConsultaPreco(p.CD_ProdVenda);
                                    rItemCupom.Quantidade = p.Quantidade;
                                    if (rItemCupom.Vl_unitario > decimal.Zero)
                                    {
                                        rItemCupom.Vl_subtotal = rItemCupom.Vl_unitario * rItemCupom.Quantidade;
                                        rItemCupom.Vl_desconto = CalcularDescEspecial(Quantidade.Value, Quantidade.Value * rItemCupom.Vl_unitario);
                                        rItemCupom.Pc_desconto = rItemCupom.Vl_desconto * 100 / rItemCupom.Vl_subtotal;
                                        rItemCupom.Vl_acrescimo = CalcularAcresEspecial(Quantidade.Value, Quantidade.Value * rItemCupom.Vl_unitario);
                                        rItemCupom.Pc_acrescimo = rItemCupom.Vl_acrescimo * 100 / rItemCupom.Vl_subtotal;
                                    }
                                    //Buscar Promocao Venda
                                    BuscarPromocao(rItemCupom);
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(rItemCupom);
                                });
                                bsVendaRapida.ResetCurrentItem();
                            }
                    }
                }
            }
        }

        private void TrocoDevCredito(CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rSaldo,
                                     TList_CadPortador lDevolCred,
                                    ref List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev)
        {
            rSaldo.Vl_processar = (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred;
            lDev.Add(rSaldo);
            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
            {
                fTroco.Cd_empresa = (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa;
                fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                fTroco.Vl_troco = (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred -
                    (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
                fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                if (fTroco.ShowDialog() == DialogResult.OK)
                {
                    if (fTroco.Vl_trocoCredito > decimal.Zero)
                    {
                        lDevolCred[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                        if (TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                        {
                            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                            {
                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                {
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
                                    //buscar endereco clifor
                                    object obj = new TCD_CadEndereco().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_clifor",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                                }
                                                    }, "a.cd_endereco");
                                    if (obj != null)
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                    lDevolCred[0].St_gerarCredito = true;
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
                                object obj = new TCD_CadEndereco().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor + "'"
                                                                            }
                                                }, "a.cd_endereco");
                                if (obj != null)
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_endereco = obj.ToString();
                                lDevolCred[0].Ds_mensagemCredito = inp.ShowDialog();
                                lDevolCred[0].St_gerarCredito = true;
                            }
                    }
                    if (fTroco.lChRepasse != null)
                    {
                        fTroco.lChRepasse.ForEach(p => lDevolCred[0].lChTroco.Add(p));
                        if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                        {
                            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor))
                            {
                                DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                {
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor = linha["cd_clifor"].ToString();
                                    (bsVendaRapida.Current as TRegistro_VendaRapida).Nm_clifor = linha["nm_clifor"].ToString();
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
                        fTroco.lChTroco.ForEach(p => lDevolCred[0].lChTroco.Add(p));
                    if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                        lDevolCred[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                    else lDevolCred[0].Vl_trocoPDV = decimal.Zero;
                }
                else
                {
                    MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void ImprimirRecibo(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFReciboVendaRapida";
            Relatorio.NM_Classe = "TFReciboVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Recibo Venda";
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

            BindingSource BinCliforEmpresa = new BindingSource();
            BinCliforEmpresa.DataSource = new TCD_CadClifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_div_empresa x where x.cd_empresa = '"+val.Cd_empresa+"' and a.cd_clifor = x.CD_Clifor)"
                    }
                }, 1, string.Empty);
            Relatorio.Adiciona_DataSource("CLIENTEEMPRESA", BinCliforEmpresa);



            TList_Moeda lMoeda = new TList_Moeda();
            lMoeda = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(val.Cd_empresa, null);

            val.Valor_Extenso = new Utils.Extenso().ValorExtenso(val.Vl_cupom, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
            val.sigla_moeda = lMoeda[0].Sigla.Trim();
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
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr + "')"
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
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                (bsVendaRapida.Current as TRegistro_VendaRapida).ObsOS = obsOS.ToString();
            }
            //Buscar Itens Devolvidos
            BindingSource bsDev = new BindingSource();
            bsDev.DataSource = TCN_ItensDevolvidos.Buscar(
                (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_empresa,
                string.Empty,
                (bsVendaRapida.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                null);
            Relatorio.Adiciona_DataSource("DTS_DEV", bsDev);

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
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
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

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Busca Endereço 
                TList_CadEndereco List_Endereco =
                    new TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsVendaRapida.Current as TRegistro_VendaRapida).Cd_clifor.Trim() + "'"
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
                    }
                    else
                    {
                        cd_endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                        numero.Text = List_Endereco[0].Numero.Trim();
                        Bairro.Text = List_Endereco[0].Bairro.Trim();
                    }
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

        private bool VerificarTotDesconto(TRegistro_VendaRapida val)
        {
            for (int i = 0; i < (val.lItem.Count); i++)
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
                                            p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
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
                                    fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = tot_pcdesconto.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
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
                                    if (fLogin.ShowDialog() != DialogResult.OK)
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
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
                        if (tot_pcdesconto.Value.Equals(decimal.Zero))
                            tot_pcdesconto.Value = tot_vldesconto.Value * 100 / tot_itens.Value;
                        if (tot_pcdesconto.Value > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = tot_pcdesconto.Value;
                                if (fLogin.ShowDialog() != DialogResult.OK)
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
                            if (fLogin.ShowDialog() != DialogResult.OK)
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

        private decimal BuscarCreditoCliente(ref decimal vl_faturar)
        {
            decimal retorno = decimal.Zero;
            //Verificar se Origem é de uma locação
            if (string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao))
            {
                //Verificar se cliente possui adiantamento
                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
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
                //Somar Saldo Adto
                decimal vl_adiant = lAdiant.Sum(p => p.Vl_total_devolver);
                if ((lAdiant.Count > decimal.Zero) &&
                    (CD_Clifor.Text != lCfg[0].Cd_clifor))
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
                            fSaldo.Cd_clifor = CD_Clifor.Text;
                            fSaldo.Id_locacao = (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao;
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
                                    if (fSaldo.lSaldo.Sum(p => p.Vl_processar) >= (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                                    {
                                        try
                                        {
                                            FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                            vl_faturar = 0;
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                    else
                                        vl_faturar -= fSaldo.lSaldo.Sum(p => p.Vl_processar);
                                }
                        }
                    }
                }
                return retorno;
            }
            else
            {
                //Verificar se cliente possui adiantamento
                lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
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
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                                "where a.id_adto = x.id_adto " +
                                                "and x.id_locacao = " + (bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao + " ) "
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
                    (CD_Clifor.Text != lCfg[0].Cd_clifor))
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
                        List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                        if (!string.IsNullOrEmpty((bsVendaRapida.Current as TRegistro_VendaRapida).Id_locacao) &&
                            (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred >
                            (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                            this.TrocoDevCredito(lAdiant[0], lDevolCred, ref lDev);
                        else
                        {
                            decimal tot_devolver = (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred <
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) ?
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).Vl_devcred :
                                        (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
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
                        }

                        //Lancar Devolução Credito
                        lDevolCred[0].lCred = lDev;
                        retorno = lDev.Sum(v => v.Vl_processar);
                        lDevolCred[0].Vl_pagtoPDV = retorno;

                        (bsVendaRapida.Current as TRegistro_VendaRapida).lPortador = lDevolCred;
                        if (lDev.Sum(v => v.Vl_processar) >= (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                        {
                            try
                            {
                                FecharVenda(bsVendaRapida.Current as TRegistro_VendaRapida);
                                vl_faturar = 0;
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
                return retorno;
            }
        }

        private void printAberturaCaixa(TRegistro_RetiradaCaixa rRetirada, string porta)
        {
            string title = rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? "SUPRIMENTO" : "RETIRADA";
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
            if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
            {
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Abertura.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(" =========================================");
                    w.WriteLine("          " + title.Trim() + " - CAIXA Nº" + rRetirada.Id_caixastr.Trim());
                    w.WriteLine(" =========================================");
                    w.WriteLine(" Data: " + rRetirada.Dt_retiradastr);
                    w.WriteLine((rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? " VL.Suprimento: " : " VL.Retirada: ")
                        + (rRetirada.Vl_retirada.ToString("N2", new System.Globalization.CultureInfo("en-US", true))));
                    if (rRetirada.lPortador.Count > 0)
                    {
                        w.WriteLine();
                        rRetirada.lPortador.ForEach(p =>
                            {
                                w.WriteLine(" Portador: " + p.Ds_portador.Trim() + "  Valor: " + p.Vl_pagtoPDV.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)));
                                if (p.lCheque.Count > 0)
                                    p.lCheque.ForEach(v => w.WriteLine("Nº Cheque: " + v.Nr_cheque.Trim() + "  Vl. Cheque: " + v.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true))));
                            });
                    }
                    string obs = rRetirada.Ds_observacao.Trim().ToUpper();
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
                    w.WriteLine();

                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(porta);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão Abertura Caixa: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
            else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.NM_Classe = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rRetirada.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = rRetirada;
                Relatorio.DTS_Relatorio = meu_bind;


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
        }

        private void printCreditoAvulso(CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto, List<string> texto)
        {
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
            if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
            {
                object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                    new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                    }
                                                }, "porta_imptick");
                if (porta != null)
                    if (!string.IsNullOrEmpty(porta.ToString()))
                    {
                        FileInfo f = null;
                        StreamWriter w = null;
                        f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "CreditoAvulso.txt");
                        w = f.CreateText();
                        try
                        {
                            w.WriteLine(" =========================================");
                            w.WriteLine("              EXTRATO CREDITO             ");
                            w.WriteLine(" =========================================");
                            w.WriteLine(" Nº Credito: " + rAdto.Id_adto.ToString());
                            w.WriteLine(" Cliente: " + rAdto.Cd_clifor.Trim() + "-" + rAdto.Nm_clifor.Trim().ToUpper());
                            w.WriteLine(" Data: " + rAdto.Dt_lanctostring);
                            w.WriteLine(" Valor: " + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            w.WriteLine(" Obs: " + rAdto.Ds_adto);

                            w.Write(Convert.ToChar(12));
                            w.Write(Convert.ToChar(27));
                            w.Write(Convert.ToChar(109));
                            w.Flush();
                            f.CopyTo(porta.ToString());
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro impressão Extrato Credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        {
                            w.Dispose();
                            f = null;
                        }
                    }
            }
            else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("G")))
            {
                if (rAdto != null)
                {
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        //Preencher dados empresa da duplicata
                        BindingSource Empresa = new BindingSource();
                        Empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rAdto.Cd_empresa, string.Empty, string.Empty, null);
                        decimal valor = rAdto.Vl_adto;
                        string Valor_Extenso = string.Empty;
                        string transf = string.Empty;
                        //Buscar Moeda da Conta Gerencial
                        TList_Moeda lMoeda = new TList_Moeda();
                        if (!string.IsNullOrEmpty(rAdto.Cd_contager_qt))
                        {
                            lMoeda =
                                new TCD_Moeda().Select(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_contager x "+
                                                "where x.cd_moeda = a.cd_moeda "+
                                                "and x.cd_contager = '" + rAdto.Cd_contager_qt.Trim() + "')"
                                }
                            }, 1, string.Empty);
                        }
                        else
                        {
                            //Buscar moeda padrao empresa
                            lMoeda = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(rAdto.Cd_empresa, null);
                        }
                        if (lMoeda.Count > 0)
                            Valor_Extenso = new Extenso().ValorExtenso(valor, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
                        else
                            Valor_Extenso = new Extenso().ValorExtenso(valor, "Real", "Reais");
                        //Criar objeto Relatório
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource Bin = new BindingSource();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Bin.DataSource = new CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento() { rAdto };
                        Rel.DTS_Relatorio = Bin;
                        Rel.Nome_Relatorio = "TFConsulaAdiant_Recibo";
                        Rel.NM_Classe = "TFConsulta_Adiantamento";
                        Rel.Ident = "TFConsulaAdiant_Recibo";
                        Rel.Modulo = "FIN";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        BindingSource moeda = new BindingSource();
                        moeda.DataSource = lMoeda[0];
                        Rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso);
                        Rel.Parametros_Relatorio.Add("VALOR", valor);
                        Rel.Adiciona_DataSource("MOEDA", moeda);
                        if (Empresa.Count > 0)
                            if ((Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        Rel.Adiciona_DataSource("EMPRESA", Empresa);
                        fImp.pMensagem = "RECIBO DE ADIANTAMENTO CAIXA";

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
                                               "RECIBO DE ADIANTAMENTO CAIXA",
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
                                               "RECIBO DE ADIANTAMENTO CAIXA",
                                               fImp.pDs_mensagem);
                    }
                }
            }
            else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanVendaRapida_CredAvulso";
                Relatorio.NM_Classe = "TFLanVendaRapida_CredAvulso";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "TFLanVendaRapida_CredAvulso";
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCaixa.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);

                string text = string.Join(Environment.NewLine, texto.ToArray());
                Relatorio.Parametros_Relatorio.Add("TEXTO", text);
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

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
        }

        private void PrintCondicional(TRegistro_Condicional rCond)
        {
            if (rCond != null)
            {
                if (!rCond.St_registro.Trim().ToUpper().Equals("C"))
                {
                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                              new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
                    if (string.IsNullOrEmpty(obj.ToString()))
                        throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());

                    if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                        TCN_Condicional.ImprimirReduzido(rCond, null);
                    else
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLanCondicional";
                        Relatorio.NM_Classe = "TFLanCondicional";
                        Relatorio.Modulo = string.Empty;


                        BindingSource BinEmpresa = new BindingSource();
                        BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                     rCond.Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);

                        BindingSource BinClifor = new BindingSource();
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(
                                                                          rCond.Cd_clifor,
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


                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = new TList_Condicional() { rCond };
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.DTS_Relatorio = meu_bind;



                        Relatorio.Ident = "TFLanCondicional";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = rCond.Cd_clifor;
                                fImp.pMensagem = "CONDICIONAL Nº " + rCond.Id_condicionalstr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio(rCond.Id_condicionalstr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "CONDICIONAL Nº " + rCond.Id_condicionalstr,
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
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + LoginPdv.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + LoginPdv.Trim() + "'))))");
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar Config Cupom
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
                    cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                BuscarPontosFid();
            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + LoginPdv.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + LoginPdv.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar Config Cupom
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
                    cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                BuscarPontosFid();
            }
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
                 new TCD_CadClifor(),
                vParam);

            if (linha != null)
            {
                CD_CompVend.Enabled = false;
                BB_CompVend.Enabled = false;
            }
            else
            {
                CD_CompVend.Enabled = true;
                BB_CompVend.Enabled = true;
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
                                    new TCD_CadClifor());

            if (linha != null)
            {
                CD_CompVend.Enabled = false;
                BB_CompVend.Enabled = false;
            }
            else
            {
                CD_CompVend.Enabled = true;
                BB_CompVend.Enabled = true;
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
                if (lCfg[0].Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
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
                    ds_endereco.Size = new Size(366, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    ds_endereco.Size = new Size(779, 20);
                }
            else
            {
                NM_Clifor.Enabled = true;
                ds_endereco.Enabled = true;
                numero.Visible = false;
                Bairro.Visible = false;
                ds_endereco.Size = new Size(779, 20);
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
                            if (!string.IsNullOrEmpty(Cd_vendedordefault))
                                CD_CompVend.Text = Cd_vendedordefault;
                            CD_CompVend.Enabled = true;
                            BB_CompVend.Enabled = true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Cd_vendedordefault))
                            CD_CompVend.Text = Cd_vendedordefault;
                        CD_CompVend.Enabled = true;
                        BB_CompVend.Enabled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Cd_vendedordefault) &&
                        string.IsNullOrEmpty(CD_CompVend.Text))
                        CD_CompVend.Text = Cd_vendedordefault;
                    CD_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
            }
            //Buscar Obs Cliente
            object objObs =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "a.DS_Observacao");
            if (objObs == null ? false : !string.IsNullOrEmpty(objObs.ToString()))
                MessageBox.Show("OBS CLIENTE: " + objObs.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                             new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                             new TCD_CadClifor());
            Busca_Endereco_Clifor();
            BuscarPontosFid();
            id_pessoa.Clear();
            nm_pessoa.Clear();
            //Verificar se Cliente é consumidor final
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (lCfg[0].Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
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
                    ds_endereco.Size = new Size(366, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    ds_endereco.Size = new Size(779, 20);
                }
            else
            {
                NM_Clifor.Enabled = true;
                ds_endereco.Enabled = true;
                numero.Visible = false;
                Bairro.Visible = false;
                ds_endereco.Size = new Size(779, 20);
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
                            if (!string.IsNullOrEmpty(Cd_vendedordefault))
                                CD_CompVend.Text = Cd_vendedordefault;
                            CD_CompVend.Enabled = true;
                            BB_CompVend.Enabled = true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Cd_vendedordefault))
                            CD_CompVend.Text = Cd_vendedordefault;
                        CD_CompVend.Enabled = true;
                        BB_CompVend.Enabled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Cd_vendedordefault) &&
                        string.IsNullOrEmpty(CD_CompVend.Text))
                        CD_CompVend.Text = Cd_vendedordefault;
                    CD_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
            }
            //Buscar Obs Cliente
            object objObs =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "a.DS_Observacao");
            if (objObs == null ? false : !string.IsNullOrEmpty(objObs.ToString()))
                MessageBox.Show("OBS CLIENTE: " + objObs.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanVendaRapida_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            vModo = TTpModo.tm_Standby;
            ModoBotoes();
            HabilitarCampos(false);
            lblVlSubTotal.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            lblTotalCupom.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (string.IsNullOrEmpty(LoginPdv))
                LoginPdv = Utils.Parametros.pubLogin;
            //Mostrar botao NFe
            tsmGerarNF.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR PROCESSAR NFE", null);
            tsmVincular.Visible = tsmGerarNF.Visible;
            creditoRecebidoToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR CREDITO RECEBIDO", null);
            devolverCreditoToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR DEVOLVER CREDITO", null);
            estornarDevoluçãoCreditoToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR ESTORNAR CREDITO", null);
            quitarAdiantamentoToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR QUITAR ADIANTAMENTO", null);


            tsmConsultarNF.Visible = tsmGerarNF.Visible;
            tsmCancelarNF.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR CANCELAR NOTAS FISCAIS", null);
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
            //Buscar vendedor Padrao
            object obj = new TCD_CadClifor().BuscarEscalar(
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
                                    vVL_Busca = "'" + LoginPdv.Trim() + "'"
                                }
                            }, "a.cd_clifor");
            if (obj != null)
                Cd_vendedordefault = obj.ToString();
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
            tmpSemaforo_Tick(this, new EventArgs());
            tmpSemaforo.Start();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (pc_desconto.Value * (Quantidade.Value * vl_unitario.Value) / 100 < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = pc_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(true);
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else
                {
                    vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    pc_desconto.Focus();
                }
            }
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (pc_desconto.Value > decimal.Zero)
                    pc_acrescimo.Focus();
                else vl_desconto.Focus();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava(string.Empty);
        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (vl_desconto.Value < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(false);
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

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    if (vl_desconto.Value < (Quantidade.Value * vl_unitario.Value))
                    {
                        (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = vl_desconto.Value;
                        bsItens.ResetCurrentItem();
                        CalcularDesconto(false);
                        bsItens_PositionChanged(this, new EventArgs());
                        pc_acrescimo.Focus();
                    }
                    else
                    {
                        vl_desconto.Value = decimal.Zero;
                        pc_desconto.Value = decimal.Zero;
                        vl_desconto.Focus();
                    }
                }
        }

        private void TFLanVendaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && bb_fatorcamento.Visible)
                FaturarOrcamento();
            else if (e.KeyCode.Equals(Keys.F4) && bb_fecharvenda.Visible)
                afterGrava(string.Empty);
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.Control && e.KeyCode.Equals(Keys.D) && bb_fecharvenda.Visible)
                afterGrava("D");
            else if (e.Control && e.KeyCode.Equals(Keys.C) && bb_fecharvenda.Visible)
                afterGrava("C");
            else if (e.Control && e.KeyCode.Equals(Keys.H) && bb_fecharvenda.Visible)
                afterGrava("H");
            else if (e.Control && e.KeyCode.Equals(Keys.N) && bb_fecharvenda.Visible)
                afterGrava("N");
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7) && bb_fatprevenda.Visible)
                FaturarPreVenda();
            else if (e.KeyCode.Equals(Keys.F8) && BB_Imprimir.Visible)
                ReimprimirVenda();
            else if (e.KeyCode.Equals(Keys.Right))
                AbrirGavetaDinheiro();
            else if (e.KeyCode.Equals(Keys.F12) && vModo.Equals(TTpModo.tm_Insert) && !st_editando)
                BuscarProduto();
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                ExcluirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            ReimprimirVenda();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (vModo.Equals(TTpModo.tm_Insert))
            {
                Quantidade.Enabled = bsItens.Current == null ? true : (bsItens.Current as TRegistro_VendaRapida_Item).rItemPreVenda == null && (bsItens.Current as TRegistro_VendaRapida_Item).lGrade.Count.Equals(0);
                pc_acrescimo.Enabled = st_editando ? false : true;
                vl_acrescimo.Enabled = st_editando ? false : true;
            }
            Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade > decimal.Zero ?
                (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade : 1;
            vl_unitario.Value = bsItens.Current == null ? vl_unitario.Minimum : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario;
            lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            pc_desconto.Value = bsItens.Current == null ? pc_desconto.Minimum : (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto;
            vl_desconto.Value = bsItens.Current == null ? vl_desconto.Minimum : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto;
            pc_acrescimo.Value = bsItens.Current == null ? pc_acrescimo.Minimum : (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo;
            vl_acrescimo.Value = bsItens.Current == null ? vl_acrescimo.Minimum : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo;
            lblTotalCupom.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotalliquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

            Quantidade.Enabled = vModo.Equals(TTpModo.tm_Insert) ? bsItens.Current == null ? true : (bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados.Equals(decimal.Zero) : false;
            pc_desconto.Enabled = vModo.Equals(TTpModo.tm_Insert) ? bsItens.Current == null ? true : (bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados.Equals(decimal.Zero) : false;
            vl_desconto.Enabled = vModo.Equals(TTpModo.tm_Insert) ? bsItens.Current == null ? true : (bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados.Equals(decimal.Zero) : false;
            tot_pcdesconto.Enabled = vModo.Equals(TTpModo.tm_Insert) ? bsItens.Current == null ? true : !(bsItens.List as TList_VendaRapida_Item).Exists(p => p.Qt_pontosutilizados > decimal.Zero) : false;
            tot_vldesconto.Enabled = vModo.Equals(TTpModo.tm_Insert) ? bsItens.Current == null ? true : !(bsItens.List as TList_VendaRapida_Item).Exists(p => p.Qt_pontosutilizados > decimal.Zero) : false;

            Quantidade.Enabled = st_editando ? false : true;
            vl_unitario.Enabled = st_editando ? false : vl_unitario.Enabled;
            pc_desconto.Enabled = st_editando ? false : pc_desconto.Enabled;
            vl_desconto.Enabled = st_editando ? false : vl_desconto.Enabled;
            tot_pcdesconto.Enabled = st_editando ? false : tot_pcdesconto.Enabled;
            tot_vldesconto.Enabled = st_editando ? false : tot_vldesconto.Enabled;
            cd_produto.Enabled = st_editando ? false : true;

            tot_itens.Enabled = st_editando ? false : tot_itens.Enabled;
            tot_pcacrescimo.Enabled = st_editando ? false : tot_pcacrescimo.Enabled;
            tot_vlacrescimo.Enabled = st_editando ? false : tot_vlacrescimo.Enabled;
            tot_pcdesconto.Enabled = st_editando ? false : tot_pcdesconto.Enabled;
            tot_juro_fin.Enabled = st_editando ? false : tot_juro_fin.Enabled;
            tot_frete.Enabled = st_editando ? false : tot_frete.Enabled;
            tot_venda.Enabled = st_editando ? false : tot_venda.Enabled;
            vladto.Enabled = st_editando ? false : vladto.Enabled;
            ds_observacao.Enabled = st_editando ? false : ds_observacao.Enabled;

        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                if (Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quantidade.Focus();
                    return;
                }
                if (lCfg[0].St_movestoquebool)
                {
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto)))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto) &&
                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto))
                        {
                            decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto);
                            if (saldo < Quantidade.Value)
                            {
                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                "Produto.........: " + (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto.Trim() + "-" +
                                                (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto.Trim() + "\r\n" +
                                                "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
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
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto, string.Empty, null);
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
                                Quantidade.Focus();
                                return;
                            }
                        }
                        (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                        bsItens.ResetCurrentItem();
                        CalcularSubTotal();
                        decimal desconto = CalcularDescEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                     (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (desconto > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = desconto;
                            if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal > decimal.Zero)
                                (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = desconto * 100 /
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        decimal acrescimo = CalcularAcresEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                  (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (acrescimo > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = acrescimo;
                            if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal > decimal.Zero)
                                (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = acrescimo * 100 /
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        BuscarPromocao(bsItens.Current as TRegistro_VendaRapida_Item);
                        bsItens.ResetCurrentItem();
                        bsItens_PositionChanged(this, new EventArgs());
                        //Totalizar Venda
                        TotalizarVenda();
                        if (!cd_produto.Focused)
                            if (vl_unitario.Enabled)
                                vl_unitario.Focus();
                            else if (pc_desconto.Enabled)
                                pc_desconto.Focus();
                            else
                                pc_acrescimo.Focus();
                    }
                    else
                    {
                        (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                        bsItens.ResetCurrentItem();
                        CalcularSubTotal();
                        decimal desconto = CalcularDescEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                     (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (desconto > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = desconto;
                            if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal > decimal.Zero)
                                (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = desconto * 100 /
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        decimal acrescimo = CalcularAcresEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                     (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (acrescimo > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = acrescimo;
                            if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal > decimal.Zero)
                                (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = acrescimo * 100 /
                                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        BuscarPromocao(bsItens.Current as TRegistro_VendaRapida_Item);
                        bsItens.ResetCurrentItem();
                        bsItens_PositionChanged(this, new EventArgs());
                        //Totalizar Venda
                        TotalizarVenda();
                        if (!cd_produto.Focused)
                            if (vl_unitario.Enabled)
                                vl_unitario.Focus();
                            else
                                pc_desconto.Focus();
                    }
                }
                else
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade = Quantidade.Value;
                    bsItens.ResetCurrentItem();
                    CalcularSubTotal();
                    if ((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal > decimal.Zero)
                    {
                        decimal desconto = CalcularDescEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                     (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (desconto > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto = desconto;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto = desconto * 100 / (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                        decimal acrescimo = CalcularAcresEspecial((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade,
                                                                     (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario);
                        if (acrescimo > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = acrescimo;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = acrescimo * 100 / (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                        }
                    }
                    BuscarPromocao(bsItens.Current as TRegistro_VendaRapida_Item);
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    //Totalizar Venda
                    TotalizarVenda();
                    if (!cd_produto.Focused)
                        if (vl_unitario.Enabled)
                            vl_unitario.Focus();
                        else
                            pc_desconto.Focus();
                }
                //Verificar se produto movimenta registro anvisa
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoRegAnvisa((bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto))
                    using (Proc_Commoditties.TFLoteAnvisa fLote = new Proc_Commoditties.TFLoteAnvisa())
                    {
                        fLote.pCd_empresa = CD_Empresa.Text;
                        fLote.pNm_empresa = NM_Empresa.Text;
                        fLote.pCd_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto;
                        fLote.pDs_produto = (bsItens.Current as TRegistro_VendaRapida_Item).Ds_produto;
                        fLote.pQtd_movimentar = (bsItens.Current as TRegistro_VendaRapida_Item).Quantidade;
                        fLote.pTp_mov = "S";
                        if (fLote.ShowDialog() == DialogResult.OK)
                            if (fLote.lMov != null)
                            {
                                (bsItens.Current as TRegistro_VendaRapida_Item).lMovLoteAnvisa.Clear();
                                fLote.lMov.ForEach(p => (bsItens.Current as TRegistro_VendaRapida_Item).lMovLoteAnvisa.Add(p));
                            }
                    }
                tot_frete_Leave(this, new EventArgs());
            }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (!cd_produto.Focused)
                    if (!vl_unitario.Focus())
                        pc_desconto.Focus();
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            Quantidade.DecimalPlaces = 3;
            vl_unitario.Value = vl_unitario.Minimum;
            lblVlSubTotal.Text = string.Empty;
            pc_desconto.Value = pc_desconto.Minimum;
            vl_desconto.Value = vl_desconto.Minimum;
            pc_acrescimo.Value = pc_acrescimo.Minimum;
            vl_acrescimo.Value = vl_acrescimo.Minimum;
            lblTotalCupom.Text = string.Empty;
        }

        private void bb_fatprevenda_Click(object sender, EventArgs e)
        {
            FaturarPreVenda();
        }

        private void bb_liquidacao_Click(object sender, EventArgs e)
        {
            ReceberFinanceiro();
        }

        private void TFLanVendaRapida_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            try
            {
                lSessao.ForEach(p => TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_fatorcamento_Click(object sender, EventArgs e)
        {
            FaturarOrcamento();
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            NovoCliente();
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
                decimal vl_custo =
                CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa.Text,
                                                                   (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto,
                                                                   (bsItens.Current as TRegistro_VendaRapida_Item).Cd_local,
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
                                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario = vl_unitario.Value;
                                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                                bsItens.ResetCurrentItem();
                                CalcularDesconto(true);
                                bsItens_PositionChanged(this, new EventArgs());
                                tot_frete_Leave(this, new EventArgs());
                            }
                            else
                                vl_unitario.Focus();
                        else
                            vl_unitario.Focus();
                    }
                }
                else
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_unitario = vl_unitario.Value;
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                    bsItens.ResetCurrentItem();
                    CalcularDesconto(true);
                    bsItens_PositionChanged(this, new EventArgs());
                    tot_frete_Leave(this, new EventArgs());
                }
            }
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (pc_desconto.Enabled)
                    pc_desconto.Focus();
                else pc_acrescimo.Focus();
        }

        private void tsmConsultarNF_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFE");
        }

        private void tsmCancelarNF_Click(object sender, EventArgs e)
        {
            using (PostoCombustivel.TFCancelarNFe fCanc = new PostoCombustivel.TFCancelarNFe())
            {
                fCanc.Cd_empresa = lCfg[0].Cd_empresa;
                fCanc.Nm_empresa = lCfg[0].Nm_empresa;
                fCanc.ShowDialog();
            }
        }

        private void tsmVincular_Click(object sender, EventArgs e)
        {
            VincularCfNFe();
        }

        private void tsmGerarNF_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void tsmCupom_Click(object sender, EventArgs e)
        {
            GerarCupom();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                     new TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");

                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                }
            }
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco, numero, Bairro },
                       new TCD_CadEndereco());

                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                }
            }
        }

        private void miRetiradaCaixa_Click(object sender, EventArgs e)
        {
            using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
            {
                if (rCaixa == null)
                {
                    MessageBox.Show("Não existe caixa aberto para lançar suprimento/retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                fRetirar.pId_caixa = rCaixa.Id_caixastr;
                if (fRetirar.ShowDialog() == DialogResult.OK)
                    if (fRetirar.rRetirada != null)
                    {
                        try
                        {
                            fRetirar.rRetirada.Id_caixastr = rCaixa.Id_caixastr;
                            fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                            TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                            object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                }
                                            }, "porta_imptick");
                            printAberturaCaixa(fRetirar.rRetirada, porta.ToString());
                            MessageBox.Show((fRetirar.rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? "SUPRIMENTO gravado " : "RETIRADA gravada ") + "com sucesso.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AbrirGavetaDinheiro();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
            }
        }

        private void tsmNovoCond_Click(object sender, EventArgs e)
        {
            using (TFCondicional fCond = new TFCondicional())
            {
                fCond.Cd_empresa = CD_Empresa.Text;
                fCond.Nm_empresa = NM_Empresa.Text;
                fCond.Tp_movimento = "S";
                fCond.WindowState = FormWindowState.Normal;
                if (fCond.ShowDialog() == DialogResult.OK)
                    if (fCond.rCond != null)
                    {
                        //Imprimir Condicional
                        object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_terminal",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                            }
                                                        }, "a.tp_imporcamento");
                        if (string.IsNullOrEmpty(obj.ToString()))
                            throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                        if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                            TCN_Condicional.ImprimirReduzido(fCond.rCond, null);
                        else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                        {
                            if (!fCond.rCond.St_registro.Trim().ToUpper().Equals("C"))
                            {
                                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                                Relatorio.Altera_Relatorio = Altera_Relatorio;

                                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                                Relatorio.Nome_Relatorio = "TFLanCondicionalGraficaReduzida";
                                Relatorio.NM_Classe = "TFLanCondicionalGraficaReduzida";
                                Relatorio.Modulo = string.Empty;



                                BindingSource BinEmpresa = new BindingSource();
                                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                                fCond.rCond.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);

                                BindingSource BinClifor = new BindingSource();
                                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(
                                                                                    fCond.rCond.Cd_clifor,
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


                                BindingSource meu_bind = new BindingSource();
                                meu_bind.DataSource = new TList_Condicional() { fCond.rCond };
                                Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                                Relatorio.DTS_Relatorio = meu_bind;



                                Relatorio.Ident = "TFLanCondicionalGraficaReduzida";
                                if (BinEmpresa.Current != null)
                                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                                if (!Altera_Relatorio)
                                {
                                    //Chamar tela de gerenciamento de impressao
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = fCond.rCond.Cd_clifor;
                                        fImp.pMensagem = "CONDICIONAL Nº " + fCond.rCond.Id_condicionalstr;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            Relatorio.Gera_Relatorio(fCond.rCond.Id_condicionalstr,
                                                                        fImp.pSt_imprimir,
                                                                        fImp.pSt_visualizar,
                                                                        fImp.pSt_enviaremail,
                                                                        fImp.pSt_exportPdf,
                                                                        fImp.Path_exportPdf,
                                                                        fImp.pDestinatarios,
                                                                        null,
                                                                        "CONDICIONAL Nº " + fCond.rCond.Id_condicionalstr,
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
                        else
                        {
                            if (!fCond.rCond.St_registro.Trim().ToUpper().Equals("C"))
                            {
                                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                                Relatorio.Altera_Relatorio = Altera_Relatorio;

                                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                                Relatorio.Nome_Relatorio = "TFLanCondicional";
                                Relatorio.NM_Classe = "TFLanCondicional";
                                Relatorio.Modulo = string.Empty;



                                BindingSource BinEmpresa = new BindingSource();
                                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                                fCond.rCond.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);

                                BindingSource BinClifor = new BindingSource();
                                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(
                                                                                    fCond.rCond.Cd_clifor,
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


                                BindingSource meu_bind = new BindingSource();
                                meu_bind.DataSource = new TList_Condicional() { fCond.rCond };
                                Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                                Relatorio.DTS_Relatorio = meu_bind;



                                Relatorio.Ident = "TFLanCondicional";
                                if (BinEmpresa.Current != null)
                                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                                if (!Altera_Relatorio)
                                {
                                    //Chamar tela de gerenciamento de impressao
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = fCond.rCond.Cd_clifor;
                                        fImp.pMensagem = "CONDICIONAL Nº " + fCond.rCond.Id_condicionalstr;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            Relatorio.Gera_Relatorio(fCond.rCond.Id_condicionalstr,
                                                                        fImp.pSt_imprimir,
                                                                        fImp.pSt_visualizar,
                                                                        fImp.pSt_enviaremail,
                                                                        fImp.pSt_exportPdf,
                                                                        fImp.Path_exportPdf,
                                                                        fImp.pDestinatarios,
                                                                        null,
                                                                        "CONDICIONAL Nº " + fCond.rCond.Id_condicionalstr,
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
                        //Gerar NF Condicional
                        if (MessageBox.Show("Deseja gerar NF do condicional?", "Pergunta", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                fCond.rCond.lItens.ForEach(p => p.Qtd_faturar = p.Quantidade);
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fCond.rCond.Cd_clifor, fCond.rCond.lItens.ToList());
                                TCN_Condicional.ProcessarNFCondicional(rNf, null);
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void tsmDevCond_Click(object sender, EventArgs e)
        {
            if (vModo.Equals(TTpModo.tm_Standby))
                using (TFDevolverCond fDev = new TFDevolverCond())
                {
                    fDev.Cd_empresa = CD_Empresa.Text;
                    fDev.St_faturar = true;
                    if (fDev.ShowDialog() == DialogResult.OK)
                        if (fDev.lItens != null)
                            if (fDev.lItens.Count > 0)
                                try
                                {
                                    TCN_ItensCondicional.DevolverItensCond(fDev.lItens, null);
                                    if (MessageBox.Show("Condicional devolvido com sucesso.\r\n Deseja gerar NF de Devolução?",
                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        try
                                        {
                                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                                Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao(fDev.Cd_clifor, fDev.lItens);
                                            TCN_Condicional.ProcessarNFDevCond(rNf, null);
                                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                            {
                                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                                null);
                                                fGerNfe.ShowDialog();
                                            }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    if (fDev.lItens.Exists(p => p.Tp_movimento.Trim().ToUpper().Equals("S") && p.Qtd_faturar > decimal.Zero))
                                    {
                                        //Verificar se existe caixa aberto para realizar venda
                                        if (rCaixa != null)
                                        {
                                            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCaixa.Cd_empresa, null);
                                            vModo = TTpModo.tm_Insert;
                                            ModoBotoes();
                                            HabilitarCampos(true);

                                            Quantidade.Enabled = false;
                                            ds_observacao.Enabled = true;
                                            bsVendaRapida.AddNew();
                                            CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                                            CD_Empresa.Text = lCfg[0].Cd_empresa;
                                            NM_Empresa.Text = lCfg[0].Nm_empresa;
                                            CD_CompVend.Text = fDev.lItens[0].Cd_vendedor;
                                            CD_Clifor.Text = fDev.lItens[0].Cd_clifor;
                                            NM_Clifor.Text = fDev.lItens[0].Nm_clifor;
                                            cd_endereco.Text = fDev.lItens[0].Cd_endereco;
                                            ds_endereco.Text = fDev.lItens[0].Ds_endereco;
                                            id_pessoa.Text = fDev.lItens[0].Id_pessoastr;
                                            nm_pessoa.Text = fDev.lItens[0].Nm_pessoa;
                                            cd_cliforind.Text = fDev.lItens[0].Cd_cliforind;
                                            nm_cliforind.Text = fDev.lItens[0].Nm_cliforind;
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Id_pdv = lSessao[0].Id_pdv;
                                            (bsVendaRapida.Current as TRegistro_VendaRapida).Id_sessao = lSessao[0].Id_sessao;
                                            fDev.lItens.FindAll(p => p.Tp_movimento.Trim().ToUpper().Equals("S") && p.Qtd_faturar > decimal.Zero).ForEach(p =>
                                             {
                                                 //Verificar saldo estoque do produto
                                                 if (lCfg[0].St_movestoquebool)
                                                 {
                                                     if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                                                     {
                                                         if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto) &&
                                                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(p.Cd_produto))
                                                         {
                                                             decimal saldo = BuscarSaldoLocal(CD_Empresa.Text, p.Cd_produto);
                                                             if (saldo < Quantidade.Value)
                                                                 MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                                                "Empresa.........: " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                                                                "Produto.........: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                                                                "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                             else
                                                                 (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                    new TRegistro_VendaRapida_Item()
                                                                    {
                                                                        Cd_produto = p.Cd_produto,
                                                                        Ds_produto = p.Ds_produto,
                                                                        Sigla_unidade = p.Sigla_unidade,
                                                                        Cd_local = lCfg[0].Cd_local,
                                                                        Ds_local = lCfg[0].Ds_local,
                                                                        Cd_vendedor = p.Cd_vendedor,
                                                                        Quantidade = p.Qtd_faturar,
                                                                        Vl_unitario = p.Vl_unitario,
                                                                        Vl_subtotal = p.Qtd_faturar * p.Vl_unitario,
                                                                        rItemCond = p
                                                                    });
                                                         }
                                                         else
                                                         {
                                                             //Buscar ficha tecnica produto composto
                                                             CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                                                 CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto, string.Empty, null);
                                                             lFicha.ForEach(x => x.Quantidade = x.Quantidade * p.Qtd_faturar);
                                                             CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                                             //Buscar saldo itens da ficha tecnica
                                                             string msg = string.Empty;
                                                             lFicha.ForEach(x =>
                                                            {
                                                                //Buscar saldo estoque do item
                                                                decimal saldo = decimal.Zero;
                                                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, x.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                                                if (saldo < x.Quantidade)
                                                                    msg += "Produto.........: " + x.Cd_item.Trim() + "-" + x.Ds_item.Trim() + "\r\n" +
                                                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                                            });
                                                             if (!string.IsNullOrEmpty(msg))
                                                             {
                                                                 msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                                                 MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                             }
                                                             else
                                                                 (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                                    new TRegistro_VendaRapida_Item()
                                                                    {
                                                                        Cd_produto = p.Cd_produto,
                                                                        Ds_produto = p.Ds_produto,
                                                                        Sigla_unidade = p.Sigla_unidade,
                                                                        Cd_local = lCfg[0].Cd_local,
                                                                        Ds_local = lCfg[0].Ds_local,
                                                                        Cd_vendedor = p.Cd_vendedor,
                                                                        Quantidade = p.Qtd_faturar,
                                                                        Vl_unitario = p.Vl_unitario,
                                                                        Vl_subtotal = p.Qtd_faturar * p.Vl_unitario,
                                                                        rItemCond = p
                                                                    });
                                                         }
                                                     }
                                                     else
                                                         (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                            new TRegistro_VendaRapida_Item()
                                                            {
                                                                Cd_produto = p.Cd_produto,
                                                                Ds_produto = p.Ds_produto,
                                                                Sigla_unidade = p.Sigla_unidade,
                                                                Cd_local = lCfg[0].Cd_local,
                                                                Ds_local = lCfg[0].Ds_local,
                                                                Cd_vendedor = p.Cd_vendedor,
                                                                Quantidade = p.Qtd_faturar,
                                                                Vl_unitario = p.Vl_unitario,
                                                                Vl_subtotal = p.Qtd_faturar * p.Vl_unitario,
                                                                rItemCond = p
                                                            });
                                                 }
                                                 else
                                                     (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Add(
                                                            new TRegistro_VendaRapida_Item()
                                                            {
                                                                Cd_produto = p.Cd_produto,
                                                                Ds_produto = p.Ds_produto,
                                                                Sigla_unidade = p.Sigla_unidade,
                                                                Cd_local = lCfg[0].Cd_local,
                                                                Ds_local = lCfg[0].Ds_local,
                                                                Cd_vendedor = p.Cd_vendedor,
                                                                Quantidade = p.Qtd_faturar,
                                                                Vl_unitario = p.Vl_unitario,
                                                                Vl_subtotal = p.Qtd_faturar * p.Vl_unitario,
                                                                rItemCond = p
                                                            });
                                             });
                                            bsVendaRapida.ResetCurrentItem();
                                            TotalizarVenda();
                                        }
                                        else
                                            MessageBox.Show("Não existe caixa aberto para realizar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = pc_acrescimo.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(true);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void pc_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Pc_acrescimo = pc_acrescimo.Value;
                    bsItens.ResetCurrentItem();
                    CalcularAcrescimo(true);
                    bsItens_PositionChanged(this, new EventArgs());
                    vl_acrescimo.Focus();
                }
        }

        private void vl_acrescimo_Leave(object sender, EventArgs e)
        {
            if ((bsItens.Current != null) && vModo.Equals(TTpModo.tm_Insert))
            {
                (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = vl_acrescimo.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(false);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void vl_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as TRegistro_VendaRapida_Item).Vl_acrescimo = vl_acrescimo.Value;
                    bsItens.ResetCurrentItem();
                    CalcularAcrescimo(false);
                    bsItens_PositionChanged(this, new EventArgs());
                    if (!bb_resgatarPontos.Focus())
                        cd_produto.Focus();
                }
        }

        private void tot_desconto_Leave(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current != null)
            {
                if (tot_vldesconto.Value < (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotal))
                {
                    if (VerificarTotDesconto(bsVendaRapida.Current as TRegistro_VendaRapida))
                    {
                        TCN_VendaRapida.RatearDescontoVRapida(bsVendaRapida.Current as TRegistro_VendaRapida, tot_vldesconto.Value, decimal.Zero);
                        bsVendaRapida.ResetBindings(true);
                        TotalizarVenda();
                    }
                    else
                    {
                        tot_vldesconto.Value = decimal.Zero;
                        tot_pcdesconto.Value = decimal.Zero;
                        tot_vldesconto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Valor de desconto maior que o valor da venda!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tot_vldesconto.Value = decimal.Zero;
                    tot_pcdesconto.Value = decimal.Zero;
                    tot_vldesconto.Focus();
                }
            }
        }

        private void tot_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_pcacrescimo.Focus();
        }

        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            if ((bsVendaRapida.Current != null) && (tot_vlacrescimo.Value > 0))
            {
                TCN_VendaRapida.RatearAcrescimoVRapida(bsVendaRapida.Current as TRegistro_VendaRapida, tot_vlacrescimo.Value, decimal.Zero);
                bsVendaRapida.ResetBindings(true);
                TotalizarVenda();
            }
        }

        private void tot_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_acrescimo_Leave(this, new EventArgs());
        }

        private void tot_pcdesconto_Leave(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current != null)
            {
                if (tot_pcdesconto.Value < 100)
                {
                    if (VerificarTotDesconto(bsVendaRapida.Current as TRegistro_VendaRapida))
                    {
                        TCN_VendaRapida.RatearDescontoVRapida(bsVendaRapida.Current as TRegistro_VendaRapida, decimal.Zero, tot_pcdesconto.Value);
                        bsVendaRapida.ResetBindings(true);
                        TotalizarVenda();
                    }
                    else
                    {
                        tot_pcdesconto.Value = decimal.Zero;
                        tot_vldesconto.Value = decimal.Zero;
                        tot_pcdesconto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Percentual de desconto maior que o valor da venda!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tot_pcdesconto.Value = decimal.Zero;
                    tot_vldesconto.Value = decimal.Zero;
                    tot_pcdesconto.Focus();
                }
            }
        }

        private void tot_pcdesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (tot_pcdesconto.Value > decimal.Zero)
                    tot_pcacrescimo.Focus();
                else tot_vldesconto.Focus();
        }

        private void tot_pcacrescimo_Leave(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current != null)
            {
                TCN_VendaRapida.RatearAcrescimoVRapida(bsVendaRapida.Current as TRegistro_VendaRapida, decimal.Zero, tot_pcacrescimo.Value);
                bsVendaRapida.ResetBindings(true);
                TotalizarVenda();
            }
        }

        private void tot_pcacrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_pcacrescimo_Leave(this, new EventArgs());
        }

        private void tot_frete_Leave(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current != null)
            {
                if (tot_itens.Value > decimal.Zero)
                {
                    TCN_VendaRapida.RatearFreteVRapida(bsVendaRapida.Current as TRegistro_VendaRapida, tot_frete.Value);
                    bsVendaRapida.ResetBindings(true);
                    TotalizarVenda();
                }
            }
        }

        private void tot_frete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_frete_Leave(this, new EventArgs());
        }

        private void bb_consultaProd_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFConsultaProduto fConsulta = new Proc_Commoditties.TFConsultaProduto())
            {
                fConsulta.ShowDialog();
            }
        }

        private void abrirGavetaDinheiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirGavetaDinheiro();
        }

        private void devolverVendaToolStripMenuItem_Click(object sender, EventArgs e)
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
            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR DEVOLVER VENDA";
                fRegra.Login = Utils.Parametros.pubLogin;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    using (PDV.TFItensDevolver fItem = new PDV.TFItensDevolver())
                    {
                        fItem.pCd_empresa = lCfg[0].Cd_empresa;
                        if (fItem.ShowDialog() == DialogResult.OK)
                            if (fItem.lItens != null)
                                if (fItem.lItens.Count > 0)
                                    try
                                    {
                                        TRegistro_Devolucao rDev = new TRegistro_Devolucao();
                                        InputBox inp = new InputBox();
                                        inp.Text = "Motivo Devolução";
                                        rDev.Ds_observacao = inp.ShowDialog();
                                        rDev.Cd_empresa = lCfg[0].Cd_empresa;
                                        rDev.Cd_clifor = fItem.pCd_clifor;
                                        rDev.Nm_clifor = fItem.pNm_clifor;
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
                                                    fItem.pCd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim())) &&
                                                    TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", lCfg[0].Cd_empresa, null).Trim().ToUpper().Equals("S"))
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
                                        TCN_Devolucao.Gravar(
                                            rDev,
                                            lParc,
                                            null);
                                        MessageBox.Show("Devolução gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (rDev.Id_adto.HasValue)
                                        {//Buscar Adiantamento
                                            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdto =
                                                new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                                    new TpBusca[]
                                                    {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_adto",
                                                        vOperador = "=",
                                                        vVL_Busca = rDev.Id_adtostr
                                                    }
                                                    }, 1, string.Empty);
                                            if (lAdto.Count > 0)
                                            {
                                                List<string> Texto = new List<string>();
                                                Texto.Add("                EXTRATO CREDITO                 ");
                                                Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + lAdto[0].Id_adto.ToString());
                                                Texto.Add("Data: ".FormatStringDireita(38, ' ') + lAdto[0].Dt_lanctostring);
                                                Texto.Add("Valor: ".FormatStringDireita(38, ' ') + lAdto[0].Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                                if (Texto.Count > 1)
                                                    printCreditoAvulso(lAdto[0], Texto);
                                            }
                                        }
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource bs = new BindingSource();
                                            TList_Devolucao _Devolucaos = TCN_Devolucao.Buscar(rDev.Cd_empresa,
                                                                                 rDev.Id_devolucaostr,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 true,
                                                                                 null);

                                            //Adicionar a grade aos produtos devolvidos
                                            _Devolucaos.ForEach(r =>
                                            {
                                                r.lItensDev.ForEach(p =>
                                                {
                                                    //Para cada item devolvido, busca-se a grade
                                                    rDev.lItens.ForEach(z =>
                                                    {
                                                        if (p.Cd_produto.Equals(z.Cd_produto))
                                                        {
                                                            p.lGrade = z.lGrade;
                                                        }
                                                    });
                                                });
                                            });
                                            _Devolucaos.ForEach(r => r.lItensDev.ForEach(p => { p.lGrade.RemoveAll(z => z.Vl_mov.Equals(0)); }));



                                            bs.DataSource = _Devolucaos;
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

        private void bb_fecharvenda_ButtonClick(object sender, EventArgs e)
        {
            afterGrava(string.Empty);
        }

        private void ctrlDDinheiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterGrava("D");
        }

        private void ctrlHChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterGrava("H");
        }

        private void ctrlNNotaCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterGrava("N");
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void pagarReceberDuplicataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceberFinanceiro();
        }

        private void creditoRecebidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rCaixa == null)
                throw new Exception("Não existe caixa aberto para o Login " + lSessao[0].Login);
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCaixa.Cd_empresa, null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração frente caixa para receber CREDITO AVULSO. " + rCaixa.Cd_empresa.Trim() + ".",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (PostoCombustivel.TFCreditoAvulso fCred = new PostoCombustivel.TFCreditoAvulso())
            {
                fCred.Cd_empresa = lCfg[0].Cd_empresa;
                fCred.Nm_empresa = lCfg[0].Nm_empresa;
                if (fCred.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                        rAdto.Cd_empresa = lCfg[0].Cd_empresa;
                        rAdto.Nm_empresa = lCfg[0].Nm_empresa;
                        rAdto.Cd_clifor = fCred.Cd_clifor;
                        rAdto.Nm_clifor = fCred.Nm_clifor;
                        rAdto.CD_Endereco = fCred.Cd_endereco;
                        rAdto.Ds_adto = string.IsNullOrEmpty(fCred.Observacao) ? "CREDITO AVULSO FRENTE CAIXA" : fCred.Observacao;
                        rAdto.Tp_movimento = "R";
                        rAdto.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                        rAdto.Vl_adto = fCred.Vl_credito;
                        rAdto.ST_ADTO = "A";
                        rAdto.TP_Lancto = "T";
                        rAdto.Id_caixaPDV = rCaixa.Id_caixa;
                        string Tp_portador = string.Empty;
                        using (PostoCombustivel.TFPortadorCredAvulso fPort = new PostoCombustivel.TFPortadorCredAvulso())
                        {
                            if (fPort.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fPort.Tp_portador))
                                    Tp_portador = fPort.Tp_portador;
                                else
                                {
                                    MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (Tp_portador.ToUpper().Equals("CH"))
                        {
                            using (Financeiro.TFLanListaCheques fCh = new Financeiro.TFLanListaCheques())
                            {
                                fCh.Cd_empresa = rAdto.Cd_empresa;
                                fCh.Tp_mov = "R";
                                fCh.Cd_contager = lCfg[0].Cd_contacaixa;
                                fCh.Ds_contager = lCfg[0].Ds_contacaixa;
                                fCh.Cd_clifor = rAdto.Cd_clifor;
                                fCh.Nm_clifor = rAdto.Nm_clifor;
                                fCh.Dt_emissao = rAdto.Dt_lancto;
                                fCh.Vl_totaltitulo = rAdto.Vl_adto;
                                fCh.St_bloquearTroco = true;
                                if (fCh.ShowDialog() == DialogResult.OK)
                                {
                                    rAdto.lCheques = fCh.lCheques;
                                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                                    MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    List<string> Texto = new List<string>();
                                    Texto.Add("                EXTRATO CREDITO                 ");
                                    Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                                    Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                                    Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                    if (Texto.Count > 1)
                                        printCreditoAvulso(rAdto, Texto);

                                }
                            }
                        }
                        else if (Tp_portador.ToUpper().Equals("DH"))
                        {
                            rAdto.Cd_contager_qt = lCfg[0].Cd_contacaixa;
                            CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                            MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List<string> Texto = new List<string>();
                            Texto.Add("                EXTRATO CREDITO                 ");
                            Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                            Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                            Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            if (Texto.Count > 1)
                                printCreditoAvulso(rAdto, Texto);

                        }
                        else if (Tp_portador.ToUpper().Equals("CC") || Tp_portador.ToUpper().Equals("CD"))
                        {
                            using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                            {
                                fCartao.pCd_empresa = rAdto.Cd_empresa;
                                fCartao.D_C = Tp_portador.ToUpper().Equals("CC") ? "C" : "D";
                                fCartao.Vl_saldofaturar = rAdto.Vl_adto;
                                fCartao.St_validarSaldo = true;
                                if (fCartao.ShowDialog() == DialogResult.OK)
                                    if (fCartao.lFatura != null)
                                    {
                                        rAdto.lFatura = fCartao.lFatura;
                                        rAdto.lFatura.ForEach(p =>
                                        {
                                            p.Cd_contager = lCfg[0].Cd_contacartao;
                                            p.Cd_historico = lCfg[0].Cd_historicocaixa;
                                        });
                                        CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                                        MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        List<string> Texto = new List<string>();
                                        Texto.Add("                EXTRATO CREDITO                 ");
                                        Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                                        Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                                        Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                        if (Texto.Count > 1)
                                            printCreditoAvulso(rAdto, Texto);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void devolverCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rCaixa == null)
                throw new Exception("Não existe caixa aberto para o Login " + lSessao[0].Login);
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCaixa.Cd_empresa, null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração frente caixa para DEVOLVER CREDITO. " + rCaixa.Cd_empresa.Trim() + ".",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Devolucao de credito
            using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
            {
                fSaldo.Cd_empresa = lCfg[0].Cd_empresa;
                fSaldo.Tp_mov = "'R'";
                fSaldo.St_adtoUnico = true;
                if (fSaldo.ShowDialog() == DialogResult.OK)
                    if (fSaldo.lSaldo != null)
                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                        {
                            fTroco.Cd_empresa = lCfg[0].Cd_empresa;
                            fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                            fTroco.Vl_troco = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                            fTroco.St_desativarCred = true;
                            if (fTroco.ShowDialog() == DialogResult.OK)
                            {
                                TCN_Caixa_X_DevCredAvulso.DevolverCredito(
                                    new TRegistro_Caixa_X_DevCredAvulso()
                                    {
                                        Cd_empresa = lCfg[0].Cd_empresa,
                                        Id_caixa = rCaixa.Id_caixa,
                                        rAdto = fSaldo.lSaldo[0],
                                        lDevCHP = fTroco.lChTroco,
                                        lDevCHT = fTroco.lChRepasse
                                    }, null);
                                MessageBox.Show("Credito devolvido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Obrigatorio informar valor total troco para especie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
            }
        }

        private void estornarDevoluçãoCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFListaDevCredAvulso fLista = new Proc_Commoditties.TFListaDevCredAvulso())
            {
                fLista.Id_caixa = rCaixa.Id_caixastr;
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rDev != null)
                        try
                        {
                            TCN_Caixa_X_DevCredAvulso.EstornarDevCredito(fLista.rDev, null);
                            MessageBox.Show("Devolução credito estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void faturarCondicionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFItensCondicional fItens = new TFItensCondicional())
            {
                fItens.St_nfdev = false;
                if (fItens.ShowDialog() == DialogResult.OK)
                    if (fItens.lItens != null)
                        try
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarNFCondicional.ProcessarCondicional(fItens.Cd_clifor, fItens.lItens);
                            TCN_Condicional.ProcessarNFCondicional(rNf, null);
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void nFDevoluçãoCondicionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFItensCondicional fItens = new TFItensCondicional())
            {
                fItens.St_nfdev = true;
                if (fItens.ShowDialog() == DialogResult.OK)
                    if (fItens.lItens != null)
                        try
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarNFCondicional.ProcessarNfDevolucao(fItens.Cd_clifor, fItens.lItens);
                            TCN_Condicional.ProcessarNFDevCond(rNf, null);
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
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
                        TCN_DevolucaoCF.ProcessarNFDevolucao(rFat, null);
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

        private void bb_cliforind_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, string.Empty);
        }

        private void cd_cliforind_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforind.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, new TCD_CadClifor());
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
            //Verificar se cliente tem tab preco configurada
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                if (new TCD_Clifor_X_TabPreco().BuscarEscalar(
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
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_vendedor_x_tabpreco x " +
                                                    "where x.cd_tabelapreco = a.cd_tabelapreco " +
                                                    "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                                    }
                                }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                if (new TCD_Clifor_X_TabPreco().BuscarEscalar(
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

        private void bb_resgatarPontos_Click(object sender, EventArgs e)
        {
            if ((Tot_pontos_resgatar > decimal.Zero) && (bsItens.Current != null))
            {
                vl_acrescimo.Focus();
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
                    fQtde.Vl_saldo = pc_max_utilizar == null ? Math.Round(decimal.Divide(decimal.Multiply((bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal, decimal.Parse(pc_max_utilizar.ToString())), 100), 2) : (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        if (fQtde.Quantidade > Tot_pontos_resgatar) MessageBox.Show("Valor informado Maior que o saldo disponível");
                        else
                        {
                            (bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto += fQtde.Quantidade;
                            (bsItens.Current as TRegistro_VendaRapida_Item).Pc_desconto =
                            pc_desconto.Value = Math.Round(decimal.Divide(decimal.Multiply((bsItens.Current as TRegistro_VendaRapida_Item).Vl_desconto, 100), (bsItens.Current as TRegistro_VendaRapida_Item).Vl_subtotal), 2);
                            (bsItens.Current as TRegistro_VendaRapida_Item).Qt_pontosutilizados = fQtde.Quantidade;
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

        private void gItens_MouseClick(object sender, MouseEventArgs e)
        {
            bsItens_PositionChanged(this, new EventArgs());
        }

        private void ctrlCCartãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterGrava("C");
        }

        private void cancelarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PostoCombustivel.TFCancelarNFe fCanc = new PostoCombustivel.TFCancelarNFe())
            {
                fCanc.Cd_empresa = lCfg[0].Cd_empresa;
                fCanc.Nm_empresa = lCfg[0].Nm_empresa;
                fCanc.St_nfce = true;
                fCanc.ShowDialog();
            }
        }

        private void consultarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFCE");
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
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rPessoa != null)
                    {
                        id_pessoa.Text = fLista.rPessoa.Id_pessoastr;
                        nm_pessoa.Text = fLista.rPessoa.Nm_pessoa;
                    }
            }
        }

        private void trocaDeMercadoriasToolStripMenuItem_Click(object sender, EventArgs e)
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
            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR TROCAR MERCADORIA";
                fRegra.Login = Utils.Parametros.pubLogin;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    using (PDV.TFItensTroca fItem = new PDV.TFItensTroca())
                    {
                        fItem.lCfg = lCfg;
                        if (fItem.ShowDialog() == DialogResult.OK)
                            if (fItem.lItens != null)
                                if (fItem.lItens.Count > 0)
                                    try
                                    {
                                        for (int i = fItem.lItens.Count - 1; i >= 0; i--)
                                        {
                                            fItem.lItens[i].St_registro = fItem.lItens[i].lTrocaItem.Count > 0 ? "C" : "A";
                                            TCN_VendaRapida_Item.Gravar(fItem.lItens[i], lCfg[0].St_movestoquebool, null);
                                        }
                                        MessageBox.Show("Troca de Item gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = TCN_TrocaItem.Buscar(lCfg[0].Cd_empresa,
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

        private void bbCalc_Click(object sender, EventArgs e)
        {
            if (bsVendaRapida.Current != null)
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Casas_decimais = 2;
                    fQtd.Ds_label = "Valor Liquido";
                    if (fQtd.ShowDialog() == DialogResult.OK)
                    {
                        if (fQtd.Quantidade > (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                        {
                            tot_vlacrescimo.Value += fQtd.Quantidade - (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido);
                            tot_acrescimo_Leave(this, new EventArgs());
                        }
                        else if (fQtd.Quantidade < (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido))
                        {
                            tot_vldesconto.Value += (bsVendaRapida.Current as TRegistro_VendaRapida).lItem.Sum(p => p.Vl_subtotalliquido) - fQtd.Quantidade;
                            tot_desconto_Leave(this, new EventArgs());
                        }
                    }
                }
        }

        private void tmpSemaforo_Tick(object sender, EventArgs e)
        {
            tmpSemaforo.Enabled = false;
            if (!bgwSemafaro.IsBusy)
                bgwSemafaro.RunWorkerAsync();
        }

        private void lblNFe_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFE");
        }

        private void lblNFCe_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFCE");
        }

        private void tmPreVenda_Tick(object sender, EventArgs e)
        {
            if (vModo.Equals(TTpModo.tm_Standby))
            {
                tmPreVenda.Enabled = false;
                if (!bgwPreVenda.IsBusy)
                    bgwPreVenda.RunWorkerAsync();

            }
        }

        private void gPreVenda_DoubleClick(object sender, EventArgs e)
        {
            // if (vModo.Equals(TTpModo.tm_Standby))
            if (bsPreVenda.Current != null)
                if (bsItens.Count > 0)
                {
                    if (MessageBox.Show("Existe uma pre venda em andamento, deseja alterar?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        ProcessarFatPreVenda(new List<TRegistro_PreVenda>() { bsPreVenda.Current as TRegistro_PreVenda });
                    }
                }
                else
                    ProcessarFatPreVenda(new List<TRegistro_PreVenda>() { bsPreVenda.Current as TRegistro_PreVenda });

        }
        private void quitarAdiantamentoToolStripMenuItem_Click(object sender, EventArgs e)
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
            bool st_quitar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR LANCAMENTO DE LIQUIDACAO", null);
            if (!st_quitar)
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Ds_regraespecial = "PERMITIR LANCAMENTO DE LIQUIDACAO";
                    fRegra.Login = Utils.Parametros.pubLogin;
                    if (fRegra.ShowDialog() == DialogResult.OK)
                        st_quitar = true;
                }
            if (st_quitar)
            {
                using (Financeiro.TFQuitarAdiantamentos fQuitar = new Financeiro.TFQuitarAdiantamentos())
                {
                    if (fQuitar.ShowDialog() == DialogResult.OK)
                        if (fQuitar.rAdto != null)
                            try
                            {
                                fQuitar.rAdto.Id_caixaPDVstr = rCaixa.Id_caixastr;
                                string Tp_portador = string.Empty;
                                using (PostoCombustivel.TFPortadorCredAvulso fPort = new PostoCombustivel.TFPortadorCredAvulso())
                                {
                                    if (fPort.ShowDialog() == DialogResult.OK)
                                        if (!string.IsNullOrEmpty(fPort.Tp_portador))
                                            Tp_portador = fPort.Tp_portador;
                                        else
                                        {
                                            MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                if (Tp_portador.ToUpper().Equals("CH"))
                                {
                                    using (Financeiro.TFLanListaCheques fCh = new Financeiro.TFLanListaCheques())
                                    {
                                        fCh.Cd_empresa = fQuitar.rAdto.Cd_empresa;
                                        fCh.Tp_mov = "R";
                                        fCh.Cd_contager = lCfg[0].Cd_contacaixa;
                                        fCh.Ds_contager = lCfg[0].Ds_contacaixa;
                                        fCh.Cd_clifor = fQuitar.rAdto.Cd_clifor;
                                        fCh.Nm_clifor = fQuitar.rAdto.Nm_clifor;
                                        fCh.Dt_emissao = fQuitar.rAdto.Dt_lancto;
                                        fCh.Vl_totaltitulo = fQuitar.rAdto.Vl_adto;
                                        fCh.St_bloquearTroco = true;
                                        if (fCh.ShowDialog() == DialogResult.OK)
                                        {
                                            fQuitar.rAdto.lCheques = fCh.lCheques;
                                            CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(fQuitar.rAdto, null);
                                            MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            List<string> Texto = new List<string>();
                                            Texto.Add("                EXTRATO CREDITO                 ");
                                            Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Id_adto.ToString());
                                            Texto.Add("Data: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Dt_lanctostring);
                                            Texto.Add("Valor: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                            if (Texto.Count > 1)
                                                printCreditoAvulso(fQuitar.rAdto, Texto);

                                        }
                                    }
                                }
                                else if (Tp_portador.ToUpper().Equals("DH"))
                                {
                                    fQuitar.rAdto.Cd_contager_qt = lCfg[0].Cd_contacaixa;
                                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(fQuitar.rAdto, null);
                                    MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    List<string> Texto = new List<string>();
                                    Texto.Add("                EXTRATO CREDITO                 ");
                                    Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Id_adto.ToString());
                                    Texto.Add("Data: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Dt_lanctostring);
                                    Texto.Add("Valor: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                    if (Texto.Count > 1)
                                        printCreditoAvulso(fQuitar.rAdto, Texto);

                                }
                                else if (Tp_portador.ToUpper().Equals("CC") || Tp_portador.ToUpper().Equals("CD"))
                                {
                                    using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                    {
                                        fCartao.pCd_empresa = fQuitar.rAdto.Cd_empresa;
                                        fCartao.D_C = Tp_portador.ToUpper().Equals("CC") ? "C" : "D";
                                        fCartao.Vl_saldofaturar = fQuitar.rAdto.Vl_adto;
                                        fCartao.St_validarSaldo = true;
                                        if (fCartao.ShowDialog() == DialogResult.OK)
                                            if (fCartao.lFatura != null)
                                            {
                                                fQuitar.rAdto.lFatura = fCartao.lFatura;
                                                fQuitar.rAdto.lFatura.ForEach(p =>
                                                {
                                                    p.Cd_contager = lCfg[0].Cd_contacartao;
                                                    p.Cd_historico = lCfg[0].Cd_historicocaixa;
                                                });
                                                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(fQuitar.rAdto, null);
                                                MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                List<string> Texto = new List<string>();
                                                Texto.Add("                EXTRATO CREDITO                 ");
                                                Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Id_adto.ToString());
                                                Texto.Add("Data: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Dt_lanctostring);
                                                Texto.Add("Valor: ".FormatStringDireita(38, ' ') + fQuitar.rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                                if (Texto.Count > 1)
                                                    printCreditoAvulso(fQuitar.rAdto, Texto);


                                            }
                                            else
                                            {
                                                MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        else
                                        {
                                            MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!st_editando)
                if (bsItens.Count > 0)
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
                                    rProd = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo(
                                        (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto, null);

                                    rProd.CD_Produto = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto;
                                    rPreco.CD_Empresa = CD_Empresa.Text;

                                    rPreco.CD_Produto = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto;
                                    rPreco.CD_Empresa = CD_Empresa.Text;
                                    rPreco.CD_TabelaPreco = (bsItens.Current as TRegistro_VendaRapida_Item).Cd_tabelapreco;
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
        }

        private void expediçãoToolStripMenuItem_Click(object sender, EventArgs e)
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
            using (InputBox ibp = new InputBox())
            {
                ibp.Text = "Informe o Nº Nota Fiscal";
                string Nr_nota = ibp.ShowDialog();
                if (!string.IsNullOrEmpty(Nr_nota))
                {
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                    vNM_Campo = "a.Nr_notafiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Nr_nota.Trim() + "'"
                                }
                            }, 1, string.Empty);
                    //Criar Quantidade de Etiquetas de acordo com o volume informado
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento nota = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
                    if (lNf.Count > 0)
                    {
                        if (lNf[0].Quantidade > 0)
                            for (int i = 0; lNf[0].Quantidade > i; i++)
                                nota.Add(lNf[0]);
                        else
                            nota.Add(lNf[0]);
                    }
                    else
                    {
                        MessageBox.Show("Não encontrada NF com este número!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource bs_valor = new BindingSource();
                        bs_valor.DataSource = nota;
                        Rel.DTS_Relatorio = bs_valor;
                        Rel.Ident = Name;
                        Rel.NM_Classe = Name;
                        Rel.Modulo = "FAT";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "ETIQUETA - EXPEDIÇÃO";

                        //Buscar dados Empresa
                        CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lNf[0].Cd_empresa,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null);

                        //Buscar Endereço Destinatário
                        BindingSource bsEndDest = new BindingSource();
                        bsEndDest.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lNf[0].Cd_clifor,
                                                                                      lNf[0].Cd_endereco,
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

                        Rel.Adiciona_DataSource("ENDERECODEST", bsEndDest);
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
                                               "ETIQUETA - EXPEDIÇÃO",
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
                                               "ETIQUETA - EXPEDIÇÃO",
                                               fImp.pDs_mensagem);
                    }
                }
            }
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

        private void barraMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bgwSemafaro_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Buscar Parametros
            tb_semafaro = new CamadaDados.TDataQuery().ExecutarBusca(
                                "select " +
                                "qtd_nfe = (select count(*) " +
                                "			from TB_FAT_NOTAFISCAL a " +
                                "			inner join tb_fat_serienf b " +
                                "			on a.nr_serie = b.nr_serie " +
                                "			and a.cd_modelo = b.cd_modelo " +
                                "			inner join tb_div_empresa c " +
                                "			on a.cd_empresa = c.cd_empresa " +
                                "			where a.CD_Modelo = '55' " +
                                "			and (isnull(a.st_registro, 'A') <> 'C' ) " +
                                "			and (a.tp_nota = 'P' ) " +
                                "			and (b.tp_serie = 'P' or b.tp_serie = 'M') " +
                                "			and isnull(c.st_registro, 'A') <> 'C' " +
                                "           and not exists(select 1 from TB_FAT_LoteNFE_X_NotaFiscal x " +
                                "                           where x.cd_empresa = a.cd_empresa " +
                                "                           and x.nr_lanctofiscal = a.nr_lanctofiscal)), " +
                                "qtd_nfeA = (select count(*) " +
                                            "from tb_fat_lotenfe_x_notafiscal a " +
                                            "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 302), " +
                                "qtd_nfce = (select count(*) " +
                                "			from tb_pdv_nfce a " +
                                "			inner join tb_div_empresa b " +
                                "			on a.cd_empresa = b.cd_empresa " +
                                "			where isnull(b.ST_Registro, 'A') <> 'C' " +
                                "           and isnull(a.st_registro, 'A') <> 'C' " +
                                "			and a.CD_Modelo = '65' " +
                                "			and not exists(select 1 from TB_FAT_Lote_X_NFCe x " +
                                "							where x.cd_empresa = a.cd_empresa " +
                                "							and x.id_cupom = a.id_nfce)), " +
                                "qtd_nfceA = (select count(*) " +
                                            "from tb_fat_lote_x_nfce a " +
                                            "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 150 and isnull(a.status, 0) <> 302) ", null);
        }

        private void bgwSemafaro_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (tb_semafaro != null)
                if (tb_semafaro.Rows.Count > 0)
                {
                    //NFe
                    lblNFe.Text = tb_semafaro.Rows[0]["qtd_nfe"].ToString();
                    lblNFe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfe"].ToString() != "0" ? 1 : 0;
                    lblNFeA.Text = tb_semafaro.Rows[0]["qtd_nfea"].ToString();
                    lblNFeA.ImageIndex = tb_semafaro.Rows[0]["qtd_nfea"].ToString() != "0" ? 1 : 0;
                    //NFCe
                    lblNFCe.Text = tb_semafaro.Rows[0]["qtd_nfce"].ToString();
                    lblNFCe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfce"].ToString() != "0" ? 1 : 0;
                    lblNFCeA.Text = tb_semafaro.Rows[0]["qtd_nfcea"].ToString();
                    lblNFCeA.ImageIndex = tb_semafaro.Rows[0]["qtd_nfcea"].ToString() != "0" ? 1 : 0;
                }
            tmpSemaforo.Enabled = true;
        }

        private void devolverTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCondDevTotal fCond = new TFCondDevTotal())
            {
                if (fCond.ShowDialog() == DialogResult.OK)
                    if (fCond.Condicional != null)
                        try
                        {
                            List<TRegistro_ItensCondicional> lItens = fCond.Condicional.lItens.FindAll(p => p.Saldo_devolver > decimal.Zero);
                            if (lItens.Count > 0)
                                if (MessageBox.Show("Confirma a devolução total?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                    return;
                            lItens.ForEach(p =>
                            {
                                p.Qtd_devolver = p.Saldo_devolver;
                                p.lGrade.Clear();
                                new CamadaDados.Estoque.TCD_GradeEstoque().Select(new Utils.TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_estoque x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                        "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                        "and x.id_condicional = " + p.Id_condicionalstr + " " +
                                                        "and x.id_item = " + p.Id_itemstr + ")"
                                        }
                                }, 0, string.Empty).ForEach(v => p.lGrade.Add(new CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica() { Id_caracteristica = v.Id_caracteristica, Id_item = v.Id_item, Valor = v.valor, Vl_mov = v.quantidade.Value }));
                            });
                            TCN_ItensCondicional.DevolverItensCond(lItens, null);
                            MessageBox.Show("Condicional devolvido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bgwPreVenda_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            lPreVenda = new TCD_PreVenda().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and ((x.login = '" + LoginPdv.Trim() + "') or " +
                                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                "       where y.logingrp = x.login and y.loginusr = '" + LoginPdv.Trim() + "'))))"
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
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_faturada",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_orcamento, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                }
                            }, 0, string.Empty, "a.dt_emissao desc");
        }

        private void bgwPreVenda_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            bsPreVenda.DataSource = lPreVenda;
            tmPreVenda.Enabled = true;
        }

        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            if (qtd_decimal == 0)
                Quantidade.Value = Convert.ToDecimal(Quantidade.Value.ToString("N0", new System.Globalization.CultureInfo("pt-BR")));
        }

        private void pc_acrescimo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tot_venda_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tsmAlterarCond_Click(object sender, EventArgs e)
        {
            using (TFLanCondicional fCond = new TFLanCondicional())
            {
                fCond.WindowState = FormWindowState.Normal;
                fCond.ShowDialog();
            }
        }

    }
}
