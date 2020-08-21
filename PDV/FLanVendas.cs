using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
namespace PDV
{
    public partial class TFLanVendas : Form
    {
        private string cliche = null;
        private string inscricaoEstadual = null;
        private string CNPJ = null;
        private string Cd_cliente = string.Empty;
        private string Nm_cliente = string.Empty;
        private string Cd_vendedor = string.Empty;

        private TRegistro_CupomFiscal rCupom = null;
        private CamadaDados.Faturamento.Cadastros.TRegistro_EmissorCF rECF = null;

        private TList_Sessao lSessao
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }

        public string LoginPdv
        { get; set; }

        public TFLanVendas()
        {
            InitializeComponent();
            LoginPdv = string.Empty;
        }

        internal void ExibirLayoutCaixaLivre()
        {
            this.rtbCupom.Visible = false;
            
            this.lblCxLivre.Text = "CAIXA LIVRE";
            this.lblMenuIniciarVenda.Visible = true;
            this.lblMenuIniciarVenda.Enabled = true;
            this.lblMenuAlterarQtde.Visible = true;
            this.lblMenuAlterarQtde.Enabled = false;
            this.lblMenuCancelarVenda.Visible = true;
            this.lblMenuCancelarVenda.Enabled = false;
            this.lblMenuFecharVenda.Visible = true;
            this.lblMenuFecharVenda.Enabled = false;
            this.lblMenuCancelarItem.Visible = true;
            this.lblMenuCancelarItem.Enabled = false;
            this.lblMenuSair.Enabled = true;
            this.lblProduto.Visible = false;
            this.lblTotalCupom.Visible = false;
            this.lblVlSubTotal.Visible = false;
            this.lblVlUnitario.Visible = false;
            this.lblCxLivre.Visible = true;

            this.cd_produto.Visible = false;
            this.lblQuantidade.Visible = false;

            lblCliente.Text = string.Empty;
            lblVendedor.Text = string.Empty;
            lblEcf.Text = string.Empty;
            lblCOO.Text = string.Empty;
            lblIdCupom.Text = string.Empty;

            pImgProduto.Image = null;
        }

        private void LimparControles()
        {
            this.rtbCupom.Clear();
            this.cd_produto.Clear();
            lblCliente.Text = string.Empty;
            lblIdCupom.Text = string.Empty;
            lblEcf.Text = string.Empty;
            lblCOO.Text = string.Empty;
            this.lblQuantidade.Text = Convert.ToDecimal(1).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
            this.lblProduto.Text = string.Empty;
            this.lblTotalCupom.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            this.lblVlSubTotal.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            this.lblVlUnitario.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            this.cd_produto.Focus();
        }

        private bool LerInformacoesCabecalhoCupom()
        {
            try
            {
                if (this.cliche == null)
                    this.cliche = TGerenciarECF.BuscarCliche(rECF).Replace('\0', ' ');
                TGerenciarECF.BuscarCNPJ_IE(rECF, ref this.CNPJ, ref this.inscricaoEstadual);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void MontarCabecalhoCupom()
        {
            StringBuilder cupom = new StringBuilder(500);
            cupom.Append(cliche);
            cupom.Append("CNPJ:");
            cupom.Append(CNPJ);
            cupom.Append('\n');
            cupom.Append("IE:");
            cupom.Append(inscricaoEstadual);
            cupom.Append('\n');
            cupom.Append('-', 51);
            cupom.Append('\n');
            cupom.Append(' ', 19);
            cupom.Append("CUPOM FISCAL");
            cupom.Append('\n');
            cupom.Append("ITEM  ");
            cupom.Append("DESCRIÇÃO                     ");
            cupom.Append("QTD  ");
            cupom.Append("TOTAL ITEM");
            cupom.Append('\n');
            cupom.Append('-', 51);
            cupom.Append('\n');
            this.AtualizarDisplay(cupom.ToString());
        }

        public void AtualizarDisplay(string mensagem)
        {
            rtbCupom.Focus();
            rtbCupom.SelectedText = mensagem;
            rtbCupom.ScrollToCaret();
            cd_produto.Focus();
        }

        private void ExibirLayoutVenda()
        {
            this.LimparControles();
            this.LerInformacoesCabecalhoCupom();
            this.MontarCabecalhoCupom();

            lblIdCupom.Text = rCupom != null ? rCupom.Id_cupomstr : string.Empty;
            lblCOO.Text = rCupom.Id_coo_ecfstr;
            lblEcf.Text = rCupom.Id_coo_ecfstr;
            lblCliente.Text = Cd_cliente.Trim() + "-" + Nm_cliente.Trim();
            this.lblCxLivre.Visible = false;
            this.rtbCupom.Visible = true;
            this.cd_produto.Visible = true;
            this.lblMenuIniciarVenda.Enabled = false;
            this.lblMenuAlterarQtde.Enabled = true;
            this.lblMenuCancelarItem.Enabled = false;
            this.lblMenuCancelarVenda.Enabled = true;
            this.lblMenuFecharVenda.Enabled = false;
            this.lblMenuSair.Enabled = false;
            this.lblProduto.Visible = true;
            this.lblQuantidade.Visible = true;
            this.lblTotalCupom.Visible = true;
            this.lblVlSubTotal.Visible = true;
            this.lblVlUnitario.Visible = true;
            this.cd_produto.Focus();

            this.Refresh();
        }

        private void ExibirLayoutFechamentoVenda()
        {
            this.cd_produto.Visible = false;
            this.lblQuantidade.Visible = false;

            this.lblProduto.Visible = false;
            this.lblTotalCupom.Visible = false;
            this.lblVlSubTotal.Visible = false;
            this.lblVlUnitario.Visible = false;
            this.lblMenuAlterarQtde.Enabled = false;
            this.lblMenuFecharVenda.Enabled = false;
            this.lblMenuCancelarItem.Enabled = false;
        }

        private void IniciarVenda()
        {
            rCupom = new TRegistro_CupomFiscal();
            string msgRet = string.Empty;
            if (TGerenciarECF.AbrirCupom(rECF,
                                         string.Empty,
                                         Nm_cliente,
                                         string.Empty,
                                         ref msgRet))
            {
                try
                {
                    rCupom.Id_coo_ecf = TGerenciarECF.UltimoCOOEmitido(rECF);
                    rCupom.Cd_clifor = Cd_cliente;
                    rCupom.Nm_clifor = Nm_cliente;
                    rCupom.Cd_empresa = lCfg[0].Cd_empresa;
                    rCupom.Nr_serie = lCfg[0].Nr_serie;
                    rCupom.Cd_vendedor = Cd_vendedor;
                    rCupom.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rCupom.Id_pdv = lSessao[0].Id_pdv;
                    rCupom.Id_sessao = lSessao[0].Id_sessao;
                    rCupom.Id_equipamento = rECF.Id_equipamento;
                    rCupom.Cd_movimentacao = lCfg[0].Cd_movimentacao;
                    rCupom.St_cupom = "S";
                    TCN_CupomFiscal.Gravar(rCupom, null);

                    this.ExibirLayoutVenda();
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    //Cancelar cupom fiscal aberto
                    if (rCupom.Id_coo_ecf.HasValue)
                        TGerenciarECF.CancelarUltimoCupom(rECF);
                }
            }
            else
                MessageBox.Show(msgRet, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CancelarCupom()
        {
            if(rCupom != null)
                if (MessageBox.Show("Confirma cancelamento do cupom?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        //Excluir cupom
                        TCN_CupomFiscal.CancelarCF(rCupom, null);
                        TGerenciarECF.CancelarUltimoCupom(rECF);
                        ExibirLayoutCaixaLivre();
                    }
                    catch (Exception erro)
                    { MessageBox.Show("Erro cancelar cupom: " + erro.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AlterarQuantidade()
        {
            if(rCupom != null)
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    if (fQtde.ShowDialog() == DialogResult.OK)
                        if (fQtde.Quantidade > decimal.Zero)
                            lblQuantidade.Text = fQtde.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                }
        }

        private void AlterarCliente()
        {
            if (rCupom != null)
            {
                string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, vParam);
                if (linha != null)
                {
                    try
                    {
                        rCupom.Cd_clifor = linha["cd_clifor"].ToString();
                        rCupom.Nm_clifor = linha["nm_clifor"].ToString();
                        TCN_CupomFiscal.Gravar(rCupom, null);

                        //Atualizar controle tela
                        Cd_cliente = linha["cd_clifor"].ToString();
                        Nm_cliente = linha["nm_clifor"].ToString();
                        lblCliente.Text = Cd_cliente.Trim() + "-" + Nm_cliente.Trim();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void BuscarVendedor()
        {
            if (rCupom != null)
            {
                string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                                  "a.cd_clifor|Cd. Vendedor|80";
                string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S';" +
                                "a.loginvendedor|=|'" + LoginPdv + "'";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
                if (linha != null)
                {
                    try
                    {
                        rCupom.Cd_vendedor = linha["cd_clifor"].ToString();
                        TCN_CupomFiscal.Gravar(rCupom, null);

                        Cd_vendedor = linha["cd_clifor"].ToString();
                        lblVendedor.Text = linha["cd_clifor"].ToString().Trim() + "-" + linha["nm_clifor"].ToString().Trim();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void CancelarItem()
        {
            if (rCupom != null)
            {
                using (TFItemCancelar fCanc = new TFItemCancelar())
                {
                    fCanc.Id_cupom = rCupom.Id_cupomstr;
                    fCanc.Cd_empresa = rCupom.Cd_empresa;
                    if(fCanc.ShowDialog() == DialogResult.OK)
                        if (fCanc.rItem != null)
                        {
                            try
                            {
                                //Cancelar cupom
                                if (TGerenciarECF.CancelarItemGenerico(rECF, fCanc.rItem.Nr_sequencial_ecf.Value.ToString()))
                                {
                                    //Cancelar Item
                                    TCN_CupomFiscal_Item.CancelarItem(fCanc.rItem, null);

                                    // Preparando o cupom para ser colocado na tela
                                    StringBuilder cupom = new StringBuilder(30);
                                    cupom.Append("Item Cancelado: ");
                                    cupom.Append(fCanc.rItem.Nr_sequencial_ecf.Value.ToString().PadLeft(3, '0'));
                                    cupom.Append(decimal.Negate(fCanc.rItem.Vl_subtotalliquido).ToString("N").PadLeft(32, ' '));
                                    cupom.Append('\n');
                                    AtualizarDisplay(cupom.ToString());

                                    this.lblVlUnitario.Text = string.Empty;
                                    this.lblVlSubTotal.Text = string.Empty;
                                    this.lblProduto.Text = string.Empty;
                                    this.lblTotalCupom.Text = TGerenciarECF.BuscarVlSubTotal(rECF).ToString("N");
                                    this.lblQuantidade.Text = decimal.Parse("1").ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)); // volta quantidade para 1
                                    this.cd_produto.Clear();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void FecharVenda()
        {
            using (TFFecharCupom fFechar = new TFFecharCupom())
            {
                try
                {
                    fFechar.rECF = rECF;
                    fFechar.rCupom = rCupom;
                    fFechar.pCd_empresa = lCfg[0].Cd_empresa;
                    fFechar.pCd_clifor = Cd_cliente;
                    fFechar.pNm_clifor = Nm_cliente;
                    fFechar.rCfg = lCfg[0];
                    fFechar.pVl_receber = TGerenciarECF.BuscarVlSubTotal(rECF);
                    if (fFechar.ShowDialog() == DialogResult.OK)
                    {
                        TGerenciarECF.IniciaFechamentoCupom(rECF,
                                                            TElgin.St_acrescimo_desconto.tmDesconto,
                                                            TElgin.Tp_acrescimo_desconto.tmPercentual,
                                                            decimal.Zero,
                                                            decimal.Zero);
                        fFechar.lPortador.ForEach(p =>
                            {
                                if(p.Vl_pagtoPDV > decimal.Zero)
                                    TGerenciarECF.EfetuaFormaPagamento(rECF, p.Ds_portador.Trim(), p.Vl_pagtoPDV);
                            });
                        TGerenciarECF.TerminaFechamentoCupom(rECF, new List<string> { lCfg[0].Ds_mensagem });
                        //Ratear desconto por item
                        TCN_CupomFiscal.RatearDesconto(rCupom, null);
                        //Fechar cupom
                        rCupom.lPortador = fFechar.lPortador;
                        TCN_CupomFiscal.FecharCupom(rCupom,
                                                    null,
                                                    null);

                        // Preparando o cupom para ser colocado na tela
                        StringBuilder cupom = new StringBuilder(200);
                        cupom.Append(' ', 40);
                        cupom.Append('-', 11);
                        cupom.Append('\n');
                        cupom.Append("TOTAL R$");
                        cupom.AppendFormat(TGerenciarECF.BuscarVlSubTotal(rECF).ToString("N").PadLeft(43, ' '));
                        cupom.Append('\n');

                        AtualizarDisplay(cupom.ToString());
                        cd_produto.Visible = false;
                        lblQuantidade.Visible = false;
                        this.ExibirLayoutCaixaLivre();
                    }
                }
                catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BuscarItens()
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
                List<CamadaDados.Estoque.Cadastros.TRegistro_ProdutoPDV> lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoPDV(cd_produto.Text,
                                                                                    pCd_codbarra,
                                                                                    lCfg[0],
                                                                                    null);
                if (lProduto.Count > 0)
                {
                    try
                    {
                        TRegistro_CupomFiscal_Item rItem = new TRegistro_CupomFiscal_Item();
                        //Criar objeto item cupom
                        rItem.Cd_empresa = lCfg[0].Cd_empresa;
                        rItem.Cd_local = lCfg[0].Cd_local;
                        rItem.Cd_produto = lProduto[0].Cd_produto;
                        rItem.Cd_condfiscal_produto = lProduto[0].Cd_condfiscal_produto;
                        rItem.Cd_unidade = lProduto[0].Cd_unidade;
                        rItem.Id_cupom = rCupom.Id_cupom;
                        rItem.Quantidade = decimal.Parse(lblQuantidade.Text);
                        rItem.Vl_unitario = lProduto[0].Vl_precovenda;
                        rItem.Vl_subtotal = rItem.Quantidade * rItem.Vl_unitario;
                        //Buscar CFOP
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rCupom.Cd_movimentacaostr, rItem.Cd_condfiscal_produto, true, ref rCfop, null))
                        {
                            rItem.Cd_cfop = rCfop.CD_CFOP;
                            rItem.Ds_cfop = rCfop.DS_CFOP;
                        }
                        else
                            throw new Exception("Não existe CFOP cadastrado para a movimentação " + rCupom.Cd_movimentacaostr.Trim() + "\r\n" +
                                                "Condição fiscal produto " + rItem.Cd_condfiscal_produto.Trim());
                        //Procurar Impostos Estaduais para o Item
                        //Buscar estado da empresa
                        object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                }
                            }, "c.cd_uf");
                        string vObsFiscal = string.Empty;
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rCupom.Cd_empresa,
                                                                                                              obj != null ? obj.ToString() : string.Empty,
                                                                                                              obj != null ? obj.ToString() : string.Empty,
                                                                                                              rCupom.Cd_movimentacaostr,
                                                                                                              "S",
                                                                                                              lCfg[0].Cd_condfiscal_clifor,
                                                                                                              rItem.Cd_condfiscal_produto,
                                                                                                              rItem.Vl_subtotalliquido,
                                                                                                              rItem.Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rCupom.Dt_emissao,
                                                                                                              rItem.Cd_produto,
                                                                                                              "P",
                                                                                                              rCupom.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Count > 0)
                            rItem.ImpostosItens = lImpUf;
                        else
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                        "Tipo Movimento: SAIDA" + "\r\n" +
                                                        "Movimentação: " + rCupom.Cd_movimentacaostr + "\r\n" +
                                                        "Cond. Fiscal Clifor: " + lCfg[0].Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                        "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                        "UF Origem: " + (obj != null ? obj.ToString() : string.Empty) + "\r\n" +
                                                        "UF Destino: " + (obj != null ? obj.ToString() : string.Empty));
                        //Procurar impostos sobre os itens da nota fiscal de destino
                        rItem.ImpostosItens.Concat(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lCfg[0].Cd_condfiscal_clifor,
                                                                                                                                              rItem.Cd_condfiscal_produto,
                                                                                                                                              rCupom.Cd_movimentacaostr,
                                                                                                                                              "S",
                                                                                                                                              lCfg[0].Tp_pessoa,
                                                                                                                                              rCupom.Cd_empresa,
                                                                                                                                              rCupom.Nr_serie,
                                                                                                                                              string.Empty,
                                                                                                                                              string.Empty,
                                                                                                                                              rCupom.Dt_emissao,
                                                                                                                                              decimal.Zero,
                                                                                                                                              rItem.Vl_subtotalliquido,
                                                                                                                                              "P",
                                                                                                                                              string.Empty,
                                                                                                                                              null));

                        pImgProduto.Image = lProduto[0].Imagem;
                        //Objeto Cupom Impressora
                        string aliquota = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.BuscarAliquotaICMS(rItem.ImpostosItens, null);
                        if(string.IsNullOrEmpty(aliquota))
                            throw new Exception("Item sem parametro do ICMS.");
                        int nr_sequencial = 0;
                        if(TGerenciarECF.VenderItem(rECF,
                                                 lProduto[0].Cd_produto,
                                                 lProduto[0].Ds_produto,
                                                 lProduto[0].Sigla_unidade,
                                                 aliquota,
                                                 "F",
                                                 lblQuantidade.Text,
                                                 3,
                                                 lProduto[0].Vl_precovenda.ToString("N3", new System.Globalization.CultureInfo("pt-BR")),
                                                 "%",
                                                 decimal.Zero,
                                                 decimal.Zero,
                                                 ref nr_sequencial))
                        {
                            //Gravar item no banco
                            if (nr_sequencial > 0)
                                rItem.Nr_sequencial_ecf = nr_sequencial;
                            else
                                rItem.Nr_sequencial_ecf = TGerenciarECF.UltimoItemVendido(rECF);
                            TCN_CupomFiscal_Item.Gravar(rItem, true, null);
                            //Adicionar ao cupom em tela
                            rCupom.lItem.Add(rItem);
                            //Atualizar o Display
                            StringBuilder cupom = new StringBuilder();
                            cupom.AppendFormat("{0:000}", rItem.Nr_sequencial_ecf);
                            cupom.Append(' ', 2);
                            cupom.AppendFormat("{0,-29:G}", rItem.Ds_produto);
                            cupom.Append(' ', 2);
                            cupom.AppendFormat(rItem.Quantidade.ToString("G").PadLeft(3, ' '));
                            cupom.AppendFormat(rItem.Vl_subtotal.ToString("N").PadLeft(12, ' '));
                            cupom.Append('\n');

                            this.AtualizarDisplay(cupom.ToString());
                            Application.DoEvents();

                            this.lblVlUnitario.Text = rItem.Vl_unitario.ToString("N");
                            this.lblVlSubTotal.Text = rItem.Vl_subtotal.ToString("N");
                            this.lblProduto.Text = rItem.Ds_produto;
                            this.lblTotalCupom.Text = TGerenciarECF.BuscarVlSubTotal(rECF).ToString("N");
                            this.lblQuantidade.Text = decimal.Parse("1").ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)); // volta quantidade para 1
                            this.cd_produto.Clear();
                            this.lblMenuCancelarItem.Enabled = true;
                            this.lblMenuFecharVenda.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
                
        private void TFLanVendas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar dados PDV
            CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
                CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          Utils.Parametros.pubTerminal,
                                                                          null);
            if (lPdv.Count < 1)
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            lblPdv.Text = lPdv[0].Id_pdvstr.Trim() + "-" + lPdv[0].Ds_pdv.Trim();
            //Buscar equipamento emissor ECF
            CamadaDados.Faturamento.Cadastros.TList_EmissorCF lEmissor =
                CamadaNegocio.Faturamento.Cadastros.TCN_EmissorCF.Buscar(string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         lPdv[0].Id_pdvstr,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         "A",
                                                                         null);
            if (lEmissor.Count < 1)
            {
                MessageBox.Show("Não existe emissor de cupom fiscal configurado para o PDV Nº" + lPdv[0].Id_pdvstr,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            if (lEmissor.Exists(p => p.St_defaultbool))
                rECF = lEmissor.Find(p => p.St_defaultbool);
            else if (lEmissor.Count.Equals(1))
                rECF = lEmissor[0];
            else
                using (PDV.TFListaECF fLista = new PDV.TFListaECF())
                {
                    fLista.lEmissor = lEmissor;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lEmissor.Exists(p => p.St_defaultbool))
                            rECF = fLista.lEmissor.Find(p => p.St_defaultbool);
                        else
                        {
                            MessageBox.Show("Obrigatorio informar emissor cupom fiscal.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar emissor cupom fiscal.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
            lblEmpresa.Text = rECF.Cd_empresa.Trim() + "-" + rECF.Nm_empresa.Trim();
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
            if (lSessao.Count > 0)
            {
                lblUsuario.Text = lSessao[0].Login.Trim();
                lblDtIni.Text = lSessao[0].Dt_aberturastr;
            }
            //Buscar Config Cupom
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rECF.Cd_empresa, null);
            if (lCfg.Count < 1)
            {
                MessageBox.Show("Não existe configuração para emitir cupom fiscal na empresa " + rECF.Cd_empresa.Trim(),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            Cd_cliente = lCfg[0].Cd_clifor;
            Nm_cliente = lCfg[0].Nm_clifor;
            //Buscar logo da empresa
            byte[] img = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlImagem("IMAGEM_RELATORIO", string.Empty, null);
            if (img != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms.Write(img, 0, img.Length);
                pbLogoEmpresa.Image = Image.FromStream(ms);
            }
            //Setar campos padrao
            ExibirLayoutCaixaLivre();
            //Restaurar ultimo cupom aberto
            //if (printer.Cupom.Status.Aberto)
            //    this.RestaurarCupom();
        }

        private void TFLanVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fechar sessao aberta
            if(lSessao != null)
                if (lSessao.Count > 0)
                    try
                    {
                        TCN_Sessao.EncerrarSessao(lSessao[0], null);
                    }
                    catch { }
        }

        private void lblMenuIniciarVenda_MouseEnter(object sender, EventArgs e)
        {
            lblMenuIniciarVenda.BorderStyle = BorderStyle.Fixed3D;
            lblMenuIniciarVenda.Cursor = Cursors.Hand;
            lblMenuIniciarVenda.ForeColor = Color.Blue;
        }

        private void lblMenuIniciarVenda_MouseLeave(object sender, EventArgs e)
        {
            lblMenuIniciarVenda.BorderStyle = BorderStyle.None;
            lblMenuIniciarVenda.Cursor = Cursors.Default;
            lblMenuIniciarVenda.ForeColor = Color.Black;
        }

        private void lblMenuAlterarQtde_MouseEnter(object sender, EventArgs e)
        {
            lblMenuAlterarQtde.BorderStyle = BorderStyle.Fixed3D;
            lblMenuAlterarQtde.Cursor = Cursors.Hand;
            lblMenuAlterarQtde.ForeColor = Color.Blue;
        }

        private void lblMenuAlterarQtde_MouseLeave(object sender, EventArgs e)
        {
            lblMenuAlterarQtde.BorderStyle = BorderStyle.None;
            lblMenuAlterarQtde.Cursor = Cursors.Default;
            lblMenuAlterarQtde.ForeColor = Color.Black;
        }

        private void lblMenuCancelarItem_MouseEnter(object sender, EventArgs e)
        {
            lblMenuCancelarItem.BorderStyle = BorderStyle.Fixed3D;
            lblMenuCancelarItem.Cursor = Cursors.Hand;
            lblMenuCancelarItem.ForeColor = Color.Blue;
        }

        private void lblMenuCancelarItem_MouseLeave(object sender, EventArgs e)
        {
            lblMenuCancelarItem.BorderStyle = BorderStyle.None;
            lblMenuCancelarItem.Cursor = Cursors.Default;
            lblMenuCancelarItem.ForeColor = Color.Black;
        }

        private void lblMenuFecharVenda_MouseEnter(object sender, EventArgs e)
        {
            lblMenuFecharVenda.BorderStyle = BorderStyle.Fixed3D;
            lblMenuFecharVenda.Cursor = Cursors.Hand;
            lblMenuFecharVenda.ForeColor = Color.Blue;
        }

        private void lblMenuFecharVenda_MouseLeave(object sender, EventArgs e)
        {
            lblMenuFecharVenda.BorderStyle = BorderStyle.None;
            lblMenuFecharVenda.Cursor = Cursors.Default;
            lblMenuFecharVenda.ForeColor = Color.Black;
        }

        private void lblMenuCancelarVenda_MouseEnter(object sender, EventArgs e)
        {
            lblMenuCancelarVenda.BorderStyle = BorderStyle.Fixed3D;
            lblMenuCancelarVenda.Cursor = Cursors.Hand;
            lblMenuCancelarVenda.ForeColor = Color.Blue;
        }

        private void lblMenuCancelarVenda_MouseLeave(object sender, EventArgs e)
        {
            lblMenuCancelarVenda.BorderStyle = BorderStyle.None;
            lblMenuCancelarVenda.Cursor = Cursors.Default;
            lblMenuCancelarVenda.ForeColor = Color.Black;
        }

        private void lblMenuVendedor_MouseEnter(object sender, EventArgs e)
        {
            lblMenuVendedor.BorderStyle = BorderStyle.Fixed3D;
            lblMenuVendedor.Cursor = Cursors.Hand;
            lblMenuVendedor.ForeColor = Color.Blue;
        }

        private void lblMenuVendedor_MouseLeave(object sender, EventArgs e)
        {
            lblMenuVendedor.BorderStyle = BorderStyle.None;
            lblMenuVendedor.Cursor = Cursors.Default;
            lblMenuVendedor.ForeColor = Color.Black;
        }

        private void lblMenuCliente_MouseEnter(object sender, EventArgs e)
        {
            lblMenuCliente.BorderStyle = BorderStyle.Fixed3D;
            lblMenuCliente.Cursor = Cursors.Hand;
            lblMenuCliente.ForeColor = Color.Blue;
        }

        private void lblMenuCliente_MouseLeave(object sender, EventArgs e)
        {
            lblMenuCliente.BorderStyle = BorderStyle.None;
            lblMenuCliente.Cursor = Cursors.Default;
            lblMenuCliente.ForeColor = Color.Black;
        }
                
        private void lblMenuSair_MouseEnter(object sender, EventArgs e)
        {
            lblMenuSair.BorderStyle = BorderStyle.Fixed3D;
            lblMenuSair.Cursor = Cursors.Hand;
            lblMenuSair.ForeColor = Color.Blue;
        }

        private void lblMenuSair_MouseLeave(object sender, EventArgs e)
        {
            lblMenuSair.BorderStyle = BorderStyle.None;
            lblMenuSair.Cursor = Cursors.Hand;
            lblMenuSair.ForeColor = Color.Black;
        }

        private void lblMenuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrEmpty(cd_produto.Text))
                    FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto },
                                                            string.Empty,
                                                            string.Empty);
                else if (!char.IsNumber(cd_produto.Text.Trim(), 0))
                    FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto },
                                                            string.Empty,
                                                            cd_produto.Text);
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void lblMenuIniciarVenda_Click(object sender, EventArgs e)
        {
            this.IniciarVenda();
        }

        private void lblMenuCancelarVenda_Click(object sender, EventArgs e)
        {
            this.CancelarCupom();
        }

        private void lblMenuAlterarQtde_Click(object sender, EventArgs e)
        {
            this.AlterarQuantidade();
        }

        private void lblMenuCliente_Click(object sender, EventArgs e)
        {
            this.AlterarCliente();
        }

        private void lblMenuVendedor_Click(object sender, EventArgs e)
        {
            this.BuscarVendedor();
        }

        private void lblMenuCancelarItem_Click(object sender, EventArgs e)
        {
            this.CancelarItem();
        }

        private void lblMenuFecharVenda_Click(object sender, EventArgs e)
        {
            this.FecharVenda();
        }

        private void TFLanVendas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && lblMenuIniciarVenda.Enabled)
                this.IniciarVenda();
            else if (e.KeyCode.Equals(Keys.F3) && lblMenuAlterarQtde.Enabled)
                this.AlterarQuantidade();
            else if (e.KeyCode.Equals(Keys.F4) && lblMenuCancelarItem.Enabled)
                this.CancelarItem();
            else if (e.KeyCode.Equals(Keys.F5) && lblMenuFecharVenda.Enabled)
                this.FecharVenda();
            else if (e.KeyCode.Equals(Keys.F6) && lblMenuCancelarVenda.Enabled)
                this.CancelarCupom();
            else if (e.KeyCode.Equals(Keys.F7) && lblMenuVendedor.Enabled)
                this.BuscarVendedor();
            else if (e.KeyCode.Equals(Keys.F8) && lblMenuCliente.Enabled)
                this.AlterarCliente();
            else if (e.Control && e.KeyCode.Equals(Keys.F4) && lblMenuSair.Enabled)
                this.Close();
        }
    }
}
