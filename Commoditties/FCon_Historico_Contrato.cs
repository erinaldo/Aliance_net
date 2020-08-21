using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Financeiro.Cadastros;
using Financeiro;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaNegocio.Financeiro.Cadastros;

namespace Commoditties
{
    public partial class TFCon_Historico_Contrato : FormPadrao.FFormPadrao
    {
        private List<TList_RegLanPesagemGraos> ListaPesagemE = new List<TList_RegLanPesagemGraos>();
        private List<TList_RegLanPesagemGraos> ListaPesagemS = new List<TList_RegLanPesagemGraos>();
        private TList_SaldoSinteticoPedido ListReg_SaldoSinteticoPedido = new TList_SaldoSinteticoPedido();
        private TList_SaldoSinteticoPedido ListReg_SaldoFiscal = new TList_SaldoSinteticoPedido();
        private TList_SaldoSinteticoPedido ListReg_SaldoFisDev = new TList_SaldoSinteticoPedido();
        private TList_SaldoSinteticoPedido ListReg_Balanca = new TList_SaldoSinteticoPedido();
        private List<TList_NotaFiscalPedido> ListaNFE = new List<TList_NotaFiscalPedido>();
        private List<TList_NotaFiscalPedido> ListaNFS = new List<TList_NotaFiscalPedido>();
        private List<TList_NotaFiscalPedido> ListaNFMestraE = new List<TList_NotaFiscalPedido>();
        private List<TList_NotaFiscalPedido> ListaNFMestraS = new List<TList_NotaFiscalPedido>();
        private List<TList_Transferencia> ListaTransferenciaContrato = new List<TList_Transferencia>();
        private List<TList_LanctoEstoqueXPedido> ListaLanctoEstoqueXPedido = new List<TList_LanctoEstoqueXPedido>();
        
        public TFCon_Historico_Contrato()
        {
            InitializeComponent();
            pDados.set_FormatZero();
            BB_Imprimir.Visible = true;
        }

        public void LimpaCache()
        {
            ListaPesagemE.Clear();
            ListaPesagemS.Clear();
            ListReg_SaldoSinteticoPedido.Clear();
            ListReg_SaldoFiscal.Clear();
            ListReg_SaldoFisDev.Clear();
            ListReg_Balanca.Clear();
            ListaNFE.Clear();
            ListaNFS.Clear();
            ListaNFMestraE.Clear();
            ListaNFMestraS.Clear();
            ListaTransferenciaContrato.Clear();
            ListaLanctoEstoqueXPedido.Clear();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void afterBusca()
        {
            if (tabControl.SelectedIndex == 0)
            {
                if (cd_empresa.Text.Trim() != string.Empty)
                {
                    LimpaCache();
                    TList_PedidoAplicacao lista = TCN_PedidoAplicacao.Buscar(cd_empresa.Text,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             cd_clifor.Text,
                                                                             string.Empty,
                                                                             false,
                                                                             Nr_Contrato.Text,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             false, 
                                                                             string.Empty, 
                                                                             false, 
                                                                             false,
                                                                             rbEntrada.Checked ? "E" : rbSaida.Checked ? "S" : string.Empty,
                                                                             false,
                                                                             false,
                                                                             0);

                    BS_AplicacaoPedido.DataSource = lista;
                    BS_AplicacaoPedido_CurrentChanged(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário informar uma empresa!");
                    cd_empresa.Focus();
                }
            }
        }

        public override void afterPrint()
        {
            if(!string.IsNullOrEmpty(cd_empresa.Text))
            {
                if (BS_AplicacaoPedido.Current != null)
                {

                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Nome_Relatorio = "TFCon_Historico_Contrato";
                        BindingSource Bin = new BindingSource();
                        BindingSource Bin_Current_Totais = new BindingSource();
                        Bin_Current_Totais.DataSource = BS_TotaisConsulta.Current;
                        Bin.DataSource = BS_AplicacaoPedido.Current;
                        Rel.Adiciona_DataSource("BS_AplicacaoPedido", Bin);
                        Rel.DTS_Relatorio = Bin_Current_Totais;

                        BindingSource Bin_Clifor = new BindingSource();
                        Bin_Clifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_clifor,
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
                        BindingSource Bin_EndCLi = new BindingSource();
                        Bin_EndCLi.DataSource = TCN_CadEndereco.Buscar((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_clifor,
                                                                        (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_endereco,
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
                        bool St_todos = (!check_NF.Checked) &&
                                        (!check_Pesagem.Checked) &&
                                        (!check_Lanc_Estoque.Checked) &&
                                        (!check_Adto_Contrato.Checked) &&
                                        (!check_Tx_Contrato.Checked) &&
                                        (!check_Transf_Contrato.Checked);
                        if (check_NF.Checked || St_todos)
                        {
                            tabTPNFMestraS_Enter(this, new EventArgs());
                            tabTPNFMestraE_Enter(this, new EventArgs());
                            tabTPNFNormalE_Enter(this, new EventArgs());
                            tabTPNFNormalS_Enter(this, new EventArgs());
                        }

                        if (check_Pesagem.Checked || St_todos)
                            tabPesagem_Enter(this, new EventArgs());
                        if (check_Lanc_Estoque.Checked || St_todos)
                            tabLanctoEstoque_Enter(this, new EventArgs());
                        if (check_Adto_Contrato.Checked || St_todos)
                            tabAdiantamento_Enter(this, new EventArgs());
                        if (check_Tx_Contrato.Checked || St_todos)
                            tabTaxa_Enter(this, new EventArgs());
                        if (check_Transf_Contrato.Checked || St_todos)
                            tabTransferenciaContrato_Enter(this, new EventArgs());

                        Rel.Adiciona_DataSource("BS_Adiantamento", BS_Adiantamento);
                        Rel.Adiciona_DataSource("Bin_EndCLi", Bin_EndCLi);
                        Rel.Adiciona_DataSource("Bin_Clifor", Bin_Clifor);
                        Rel.Adiciona_DataSource("BS_MestraS", BS_MestraS);
                        Rel.Adiciona_DataSource("BS_MestraE", BS_MestraE);
                        Rel.Adiciona_DataSource("BS_NFEntrada", BS_NFEntrada);
                        Rel.Adiciona_DataSource("BS_NFSaida", BS_NFSaida);
                        Rel.Adiciona_DataSource("BS_Pesagem", BS_Pesagem);
                        Rel.Adiciona_DataSource("BS_Taxa", BS_Taxa);
                        Rel.Adiciona_DataSource("BS_LanctoEstoque", BS_LanctoEstoque);
                        Rel.Adiciona_DataSource("BS_TransfOrigem", BS_Saida_Transferencia);
                        Rel.Adiciona_DataSource("BS_TransfDetino", BS_Entrada_Transferencia);
                        Rel.Parametros_Relatorio.Add("CNF", check_NF.Checked || St_todos);
                        Rel.Parametros_Relatorio.Add("CPESAGEM", check_Pesagem.Checked || St_todos);
                        Rel.Parametros_Relatorio.Add("CTRANSFCONTRATO", check_Transf_Contrato.Checked || St_todos);
                        Rel.Parametros_Relatorio.Add("CTXCONTRATO", check_Tx_Contrato.Checked || St_todos);
                        Rel.Parametros_Relatorio.Add("CLANCESTOQUE", check_Lanc_Estoque.Checked || St_todos);
                        Rel.Parametros_Relatorio.Add("CADTOCONTRATO", check_Adto_Contrato.Checked || St_todos);
                        
                        Rel.NM_Classe = Name;
                        Rel.Modulo = Tag.ToString().Substring(0, 3);
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                               "RELATORIO " + Text.Trim(),
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
                                                   "RELATORIO " + Text.Trim(),
                                                   fImp.pDs_mensagem);
                    }
                }
             }
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
            tabControl.SelectedIndex = 0;
            if (!cd_empresa.Focus())
                cd_empresa.Focus();
            rbEntrada.Checked = true;
        }

        public void afterVisualizar(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BS_AplicacaoPedido_CurrentChanged(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
                TRegistro_SaldoSinteticoPedido Reg_SaldoSinteticoPedido = null;
                TRegistro_SaldoSinteticoPedido Reg_SaldoFiscal = null;
                TRegistro_SaldoSinteticoPedido Reg_SaldoFisDev = null;
                TRegistro_SaldoSinteticoPedido Reg_Balanca = null;

                bool EfetuaBusca = true;
                if (ListReg_SaldoSinteticoPedido.Count > 0)
                {
                    for (int i = 0; i < ListReg_SaldoSinteticoPedido.Count; i++)
                    {
                        if (Reg_LanAplicacaoPedido.Nr_contrato.Equals(ListReg_SaldoSinteticoPedido[i].NR_Contrato))
                        {
                            EfetuaBusca = false;
                            Reg_SaldoSinteticoPedido = ListReg_SaldoSinteticoPedido[i];
                            Reg_SaldoFiscal = ListReg_SaldoFiscal[i];
                            Reg_SaldoFisDev = ListReg_SaldoFisDev[i];
                            Reg_Balanca = ListReg_Balanca[i];
                            break;
                        }
                    }
                }

                if (EfetuaBusca)
                {
                    Reg_SaldoSinteticoPedido = new TCD_PedidoAplicacao().BuscaSaldoSintetico(Reg_LanAplicacaoPedido.Nr_contratostr,
                                                                                             Reg_LanAplicacaoPedido.Cd_produto);
                    Reg_SaldoFiscal = new TCD_PedidoAplicacao().BuscaSaldoFiscal(Reg_LanAplicacaoPedido.Nr_contratostr,
                                                                                 Reg_LanAplicacaoPedido.Cd_produto);
                    Reg_Balanca = new TCD_PedidoAplicacao().BuscaSaldoBalanca(Reg_LanAplicacaoPedido.Nr_contratostr,
                                                                              Reg_LanAplicacaoPedido.Cd_produto);

                    ListReg_SaldoSinteticoPedido.Add(Reg_SaldoSinteticoPedido);
                    ListReg_SaldoFiscal.Add(Reg_SaldoFiscal);
                    ListReg_SaldoFisDev.Add(Reg_SaldoFisDev);
                    ListReg_Balanca.Add(Reg_Balanca);
                }

                if ((Reg_SaldoSinteticoPedido != null) &&
                    (Reg_SaldoFiscal != null) &&
                    (Reg_Balanca != null))
                    CalculaTotaisSaldoNF(Reg_SaldoSinteticoPedido, Reg_SaldoFiscal, Reg_SaldoFisDev, Reg_Balanca, Reg_LanAplicacaoPedido);
            }
        }

        public void CalculaTotaisSaldoNF(TRegistro_SaldoSinteticoPedido Reg_SaldoSinteticoPedido, 
                                         TRegistro_SaldoSinteticoPedido Reg_SaldoFiscal, 
                                         TRegistro_SaldoSinteticoPedido Reg_SaldoFisDev,
                                         TRegistro_SaldoSinteticoPedido Reg_Balanca, 
                                         TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido)
        {
            //ADICIONA OS DADOS PARA A ENTRADA E SAÍDA
            //ESTOQUE
            if (BS_TotaisConsulta.Current == null)
                BS_TotaisConsulta.AddNew();
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).EstoqueQTDEnt = Reg_SaldoSinteticoPedido.Qtd_E;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).EstoqueQTDSai = Reg_SaldoSinteticoPedido.Qtd_S;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).EstoqueVLEnt = Reg_SaldoSinteticoPedido.VL_Entrada_Est;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).EstoqueVLSai = Reg_SaldoSinteticoPedido.VL_Saida_Est;
            //SAIDA
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).FiscalQTDEnt = Reg_SaldoFiscal.Quantidade_Fiscal_E;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).FiscalQTDSai = Reg_SaldoFiscal.Quantidade_Fiscal_S;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).FiscalVLEnt = Reg_SaldoFiscal.VL_SubTotal_Fiscal_E;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).FiscalVLSai = Reg_SaldoFiscal.VL_SubTotal_Fiscal_S;
            //DIFERENÇA
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDEnt = (Reg_SaldoSinteticoPedido.Qtd_E - Reg_SaldoFiscal.Quantidade_Fiscal_E);
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDSai = (Reg_SaldoSinteticoPedido.Qtd_S - Reg_SaldoFiscal.Quantidade_Fiscal_S);
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLEnt = (Reg_SaldoSinteticoPedido.VL_Entrada_Est - Reg_SaldoFiscal.VL_SubTotal_Fiscal_E);
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLSai = (Reg_SaldoSinteticoPedido.VL_Saida_Est - Reg_SaldoFiscal.VL_SubTotal_Fiscal_S);
            
            //BUSCA SALDO BALANÇA
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).BalancaEnt = Reg_Balanca.Qtd_Estoque_E;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).BalancaSai = Reg_Balanca.Qtd_Estoque_S;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).TransfEnt = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Qtd_Entrada_Transferencia;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).TransfSai = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Qtd_Saida_Transferencia  ;

            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).TransfTotSai = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Qtd_Saida_Transferencia - Reg_Balanca.Qtd_Estoque_S;
            
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).BalTotEnt = (Reg_Balanca.Qtd_Estoque_E + (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Qtd_Entrada_Transferencia);
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).BalTotSai = (Reg_Balanca.Qtd_Estoque_S + (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Qtd_Saida_Transferencia);

            //SALDOS DE ESTOQUE
            decimal SDEstoqueQTD = (Reg_SaldoSinteticoPedido.Qtd_E - Reg_SaldoSinteticoPedido.Qtd_S);
            decimal SDEstoqueVL = (Reg_SaldoSinteticoPedido.VL_Entrada_Est - Reg_SaldoSinteticoPedido.VL_Saida_Est);
            decimal SDFiscalQTD = (Reg_SaldoFiscal.Quantidade_Fiscal_E - Reg_SaldoFiscal.Quantidade_Fiscal_S);
            decimal SDFiscalVL = (Reg_SaldoFiscal.VL_SubTotal_Fiscal_E - Reg_SaldoFiscal.VL_SubTotal_Fiscal_S);

            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDEstoqueQTD = SDEstoqueQTD;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDEstoqueVL = SDEstoqueVL;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDFiscalQTD = SDFiscalQTD;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDFiscalVL = SDFiscalVL;
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDDiferencaQTD = (SDEstoqueQTD - SDFiscalQTD);
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).SDDiferencaVL = (SDEstoqueVL - SDFiscalVL);

            //DISPONIVEL
            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).PSRetidoTaxa = Reg_LanAplicacaoPedido.ps_retido_taxa;

            if ((Reg_LanAplicacaoPedido.QTD_SALDO_GMO_D + Reg_LanAplicacaoPedido.QTD_SALDO_GMO_T) > decimal.Zero)
            {
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).ps_RetidoGMO_D = (Reg_LanAplicacaoPedido.QTD_SALDO_GMO_D * 0.02M);
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).ps_RetidoGMO_T = (Reg_LanAplicacaoPedido.QTD_SALDO_GMO_T * 0.03M);
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).PSRetidoGMO = ((Reg_LanAplicacaoPedido.QTD_SALDO_GMO_D * 0.02M) + (Reg_LanAplicacaoPedido.QTD_SALDO_GMO_T * 0.03M));
            }
            else
            {
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).PSRetidoGMO = decimal.Zero;
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).ps_RetidoGMO_D = decimal.Zero;
                (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).ps_RetidoGMO_T = decimal.Zero;
            }

            (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).LiquidoFinal = (SDEstoqueQTD - (BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).PSRetidoGMO);
            BS_TotaisConsulta.ResetBindings(true);
        }

        private void ProcessarFisicoFiscal(string pTp_movimento)
        {
            if (BS_AplicacaoPedido.Current != null)
                using (TFApurarFisicoFiscal fApura = new TFApurarFisicoFiscal())
                {
                    fApura.Cd_empresa = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa;
                    fApura.Nr_pedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_pedidostring;
                    fApura.Tp_movimento = pTp_movimento;
                    if (fApura.ShowDialog() == DialogResult.OK)
                        if ((fApura.lComp != null) || (fApura.lDev != null))
                        {
                            try
                            {
                                TList_RegLanFaturamento lNf =
                                    Proc_Commoditties.TProcessaFisicoFiscal.ProcessarFisicoFiscal((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao),
                                                                                                  fApura.lDev,
                                                                                                  fApura.lComp);
                                TCN_LanFaturamento.ProcessarFisicoFiscal(lNf, null);
                                if (MessageBox.Show("Diferença fisico/fiscal processada com sucesso.\r\n" +
                                                "Deseja imprimir notas fiscais geradas?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                    lNf.ForEach(p => ImprimirNfFisicoFiscal(p));
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else
                            MessageBox.Show("Não existe nota fiscal selecionada para devolver/complementar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void ImprimirNfFisicoFiscal(TRegistro_LanFaturamento rNf)
        {
            if (rNf != null)
            {
                rNf = TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                  rNf.Nr_lanctofiscalstr,
                                                  null);
                if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && (!rNf.Cd_modelo.Trim().Equals("55")))
                    //Chamar tela de impressao para a nota fiscal
                    //somente se for nota propria
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = rNf.Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº" + rNf.Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rNf,
                                                                            fImp.pSt_imprimir,
                                                                            fImp.pSt_visualizar,
                                                                            fImp.pSt_enviaremail,
                                                                            fImp.pDestinatarios,
                                                                            "NOTA FISCAL Nº " + rNf.Nr_notafiscal.ToString(),
                                                                            fImp.pDs_mensagem);
                    }
                else
                    MessageBox.Show("Somente sera impresso nota fiscal propria e não NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabAdiantamento_Enter(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                BS_Adiantamento.DataSource = TCN_Lan_Adto_Contrato.BuscarAdiantamento((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr, null);

                VLTotalQuitadoCD.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("C")).Sum(p => p.VL_total_quitado);
                VLTotalDevolvidoCD.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("C")).Sum(p => p.VL_Receber);
                SaldoRemanecenteCD.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_total_devolver);

                VLTotalQuitadoRC.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R")).Sum(p => p.VL_total_quitado);
                SaldoRemanecenteRC.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R")).Sum(p => p.VL_Pagar);
                VLTotalDevolvidoRC.Value = (BS_Adiantamento.DataSource as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_total_devolver);
            }
            else
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
        }

        private void tabTaxa_Enter(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                //Buscar sintetico Taxas
                (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).SinteticoTaxas =
                    new TCD_SinteticoTaxas().Select((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr);
                //Buscar Analitico Taxas
                (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas =
                    TCN_LanTaxas_Deposito.BuscarTx((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                   string.Empty,
                                                   null);
                BS_AplicacaoPedido.ResetCurrentItem();
                totalizarTaxas();
            }
            else
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
        }

        private void totalizarTaxas()
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                qtd_taxa_fat.Value = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("P")).Sum(p => p.Ps_Taxa);
                qtd_peso_faturar.Value = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("A")).Sum(p => p.Ps_Taxa);
                qtd_pesototal.Value = qtd_taxa_fat.Value + qtd_peso_faturar.Value;
                vl_taxa_fat.Value = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_Taxa);
                vl_taxa_faturar.Value = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("A")).Sum(p => p.Vl_Taxa);
                vl_taxa_total.Value = vl_taxa_faturar.Value + vl_taxa_fat.Value;
            }
        }

        private void tabPesagem_Enter(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                cd_tipoamostra1.Text = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_tipoamostra1;
                cd_tipoamostra2.Text = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_tipoamostra2;
                TList_RegLanPesagemGraos ListaPesagem = null;
                string TipoMovimento = string.Empty;
                TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
                bool EfetuarBusca = true;

                if (tcPesagem.SelectedIndex == 0)
                {
                    //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
                    for (int i = 0; i < ListaPesagemE.Count; i++)
                    {
                        if (ListaPesagemE[i] != null)
                        {
                            if ((ListaPesagemE[i] as TList_RegLanPesagemGraos).Count > 0)
                            {
                                if (Reg_LanAplicacaoPedido.Cd_empresa == ((ListaPesagemE[i] as TList_RegLanPesagemGraos)[0] as TRegistro_LanPesagemGraos).Cd_empresa &&
                                    Reg_LanAplicacaoPedido.Nr_contrato == ((ListaPesagemE[i] as TList_RegLanPesagemGraos)[0] as TRegistro_LanPesagemGraos).NR_Contrato)
                                {
                                    ListaPesagem = (ListaPesagemE[i] as TList_RegLanPesagemGraos);
                                    EfetuarBusca = false;
                                    break;
                                }
                            }
                        }
                    }
                    TipoMovimento = "E";
                }
                else if (tcPesagem.SelectedIndex == 1)
                {
                    //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
                    for (int i = 0; i < ListaPesagemS.Count; i++)
                    {
                        if (ListaPesagemS[i] != null)
                        {
                            if ((ListaPesagemS[i] as TList_RegLanPesagemGraos).Count > 0)
                            {
                                if (Reg_LanAplicacaoPedido.Cd_empresa == ((ListaPesagemS[i] as TList_RegLanPesagemGraos)[0] as TRegistro_LanPesagemGraos).Cd_empresa &&
                                    Reg_LanAplicacaoPedido.Nr_contrato == ((ListaPesagemS[i] as TList_RegLanPesagemGraos)[0] as TRegistro_LanPesagemGraos).NR_Contrato)
                                {
                                    ListaPesagem = (ListaPesagemS[i] as TList_RegLanPesagemGraos);
                                    EfetuarBusca = false;
                                    break;
                                }
                            }
                        }
                    }
                    TipoMovimento = "S";
                }


                if (EfetuarBusca)
                {
                    ListaPesagem = TCN_LanPesagemGraos.Busca(Reg_LanAplicacaoPedido.Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             Utils.Parametros.pubLogin,
                                                             TipoMovimento,
                                                             Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                             cd_tipoamostra1.Text,
                                                             cd_tipoamostra2.Text,
                                                             0,
                                                             string.Empty,
                                                             null);
                }

                decimal PsBruto = decimal.Zero;
                decimal PsTara = decimal.Zero;
                decimal PsProduto = decimal.Zero;
                decimal PsDesconto = decimal.Zero;
                decimal PsLiquido = decimal.Zero;
                decimal PsEstoque = decimal.Zero;
                decimal Diferenca = decimal.Zero;

                for (int i = 0; i < ListaPesagem.Count; i++)
                {
                    PsBruto = PsBruto + ListaPesagem[i].Ps_bruto;
                    PsTara = PsTara + ListaPesagem[i].Ps_tara;
                    PsDesconto = PsDesconto + ListaPesagem[i].Ps_desconto_est;
                    PsLiquido = PsLiquido + ListaPesagem[i].Ps_liquido;
                }

                if (tcPesagem.SelectedIndex == 0)
                {
                    PSBrutoD.Value = PsBruto;
                    PSTaraD.Value = PsTara;
                    PSProdutoD.Value = PsProduto;
                    PSDescontoD.Value = PsDesconto;
                    PSLiquidoD.Value = PsLiquido;
                    PSEstoqueD.Value = PsEstoque;
                    DiferencaD.Value = Diferenca;
                    ListaPesagemE.Add(ListaPesagem);
                }
                else if (tcPesagem.SelectedIndex == 1)
                {
                    PSBrutoE.Value = PsBruto;
                    PSTaraE.Value = PsTara;
                    PSProdutoE.Value = PsProduto;
                    PSDescontoE.Value = PsDesconto;
                    PSLiquidoE.Value = PsLiquido;
                    PSEstoqueE.Value = PsEstoque;
                    DiferencaE.Value = Diferenca;
                    ListaPesagemS.Add(ListaPesagem);
                }
                tot_psamostra1.Value = ListaPesagem.Sum(p => p.Ps_amostra1);
                tot_psamostra2.Value = ListaPesagem.Sum(p => p.Ps_amostra2);
                BS_Pesagem.DataSource = ListaPesagem;
            }
            else
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
        }

        private void tabPesDeposito_Enter(object sender, EventArgs e)
        {
            tabPesagem_Enter(null, null);
        }

        private void tabPesExpedicao_Enter(object sender, EventArgs e)
        {
            tabPesagem_Enter(null, null);
        }

        private void tabTransferenciaContrato_Enter(object sender, EventArgs e)
        {
            if ((BS_AplicacaoPedido != null) && (BS_AplicacaoPedido.Count > 0))
            {
                TP_Transferecia_Entrada_Enter(this, new EventArgs());
                TP_Transferecia_Saida_Enter(this, new EventArgs());
            }
            else
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
        }

        private void grid_AplicacaoPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 3)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                    {
                        DataGridViewRow linha = grid_AplicacaoPedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Teal;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = grid_AplicacaoPedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                    {
                        DataGridViewRow linha = grid_AplicacaoPedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = grid_AplicacaoPedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void tabLanctoEstoque_Enter(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current != null)
            {
                TList_LanctoEstoqueXPedido LanctoEstoqueXPedido = null;
                TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
                bool EfetuarBusca = true;

                //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
                for (int i = 0; i < ListaLanctoEstoqueXPedido.Count; i++)
                {
                    if (ListaLanctoEstoqueXPedido[i] != null)
                    {
                        if ((ListaLanctoEstoqueXPedido[i] as TList_LanctoEstoqueXPedido).Count > 0)
                        {
                            if (Reg_LanAplicacaoPedido.Nr_pedido == ((ListaLanctoEstoqueXPedido[i] as TList_LanctoEstoqueXPedido)[0] as TRegistro_LanctoEstoqueXPedido).NR_Pedido)
                            {
                                LanctoEstoqueXPedido = (ListaLanctoEstoqueXPedido[i] as TList_LanctoEstoqueXPedido);
                                EfetuarBusca = false;
                                break;
                            }
                        }
                    }
                }

                if (EfetuarBusca)
                {
                    LanctoEstoqueXPedido = new TCD_PedidoAplicacao().BuscaLanctoEstoqueXPedido(Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                                                               Reg_LanAplicacaoPedido.Cd_produto,
                                                                                               Reg_LanAplicacaoPedido.Cd_empresa);
                    ListaLanctoEstoqueXPedido.Add(LanctoEstoqueXPedido);
                }

                BS_LanctoEstoque.DataSource = LanctoEstoqueXPedido;

                //CALCULA TOTAL
                decimal VLTotEntrada = 0;
                decimal VLTotSaida = 0;
                decimal QTDTolEntrada = 0;
                decimal QTDTolSaida = 0;

                for (int i = 0; i < BS_LanctoEstoque.Count; i++)
                {
                    if ((BS_LanctoEstoque[i] as TRegistro_LanctoEstoqueXPedido).Tp_movimento == "E")
                    {
                        VLTotEntrada = VLTotEntrada + (BS_LanctoEstoque[i] as TRegistro_LanctoEstoqueXPedido).VL_Subtotal;
                        QTDTolEntrada = QTDTolEntrada + (BS_LanctoEstoque[i] as TRegistro_LanctoEstoqueXPedido).QTD_Entrada;
                    }
                    else
                    {
                        VLTotSaida = VLTotSaida + (BS_LanctoEstoque[i] as TRegistro_LanctoEstoqueXPedido).VL_Subtotal;
                        QTDTolSaida = QTDTolSaida + (BS_LanctoEstoque[i] as TRegistro_LanctoEstoqueXPedido).QTD_Saida;
                    }
                }

                VLTotEntradaEstoq.Value = VLTotEntrada;
                VLTotSaidaEstoq.Value = VLTotSaida;
                QtdTotEntradaEstoq.Value = QTDTolEntrada;
                QtdTotSaidaEstoq.Value = QTDTolSaida;
                QtdTotEnt.Value = QTDTolEntrada - QTDTolSaida;
                QtdTotSai.Value = VLTotEntrada - VLTotSaida;
            }
            else
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
        }

        private void tabTPNFMestraE_Enter(object sender, EventArgs e)
        {
            TList_NotaFiscalPedido ListaNota = null;
            TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
            bool EfetuarBusca = true;

            //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
            for (int i = 0; i < ListaNFMestraE.Count; i++)
            {
                if (ListaNFMestraE[i] != null)
                {
                    if ((ListaNFMestraE[i] as TList_NotaFiscalPedido).Count > 0)
                    {
                        if (Reg_LanAplicacaoPedido.Nr_pedido == ((ListaNFMestraE[i] as TList_NotaFiscalPedido)[0] as TRegistro_NotaFiscalPedido).Nr_Pedido)
                        {
                            ListaNota = (ListaNFMestraE[i] as TList_NotaFiscalPedido);
                            EfetuarBusca = false;
                            break;
                        }
                    }
                }
            }

            if (EfetuarBusca)
            {
                ListaNota = new TCD_PedidoAplicacao().BuscaNotasFiscaisPedido(Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                                              Reg_LanAplicacaoPedido.Cd_empresa, true, "E");
                ListaNFMestraE.Add(ListaNota);
            }

            BS_MestraE.DataSource = ListaNota;
            BS_MestraE.ResetCurrentItem();
        }

        private void tabTPNFMestraS_Enter(object sender, EventArgs e)
        {
            TList_NotaFiscalPedido ListaNota = null;
            TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
            bool EfetuarBusca = true;

            //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
            for (int i = 0; i < ListaNFMestraS.Count; i++)
            {
                if (ListaNFMestraS[i] != null)
                {
                    if ((ListaNFMestraS[i] as TList_NotaFiscalPedido).Count > 0)
                    {
                        if (Reg_LanAplicacaoPedido.Nr_pedido == ((ListaNFMestraS[i] as TList_NotaFiscalPedido)[0] as TRegistro_NotaFiscalPedido).Nr_Pedido)
                        {
                            ListaNota = (ListaNFMestraS[i] as TList_NotaFiscalPedido);
                            EfetuarBusca = false;
                            break;
                        }
                    }
                }
            }

            if (EfetuarBusca)
            {
                ListaNota = new TCD_PedidoAplicacao().BuscaNotasFiscaisPedido(Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                                              Reg_LanAplicacaoPedido.Cd_empresa, true, "S");
                ListaNFMestraS.Add(ListaNota);
            }

            BS_MestraS.DataSource = ListaNota;
            BS_MestraS.ResetCurrentItem();
        }

        private void tabNF_Enter(object sender, EventArgs e)
        {
            if (BS_AplicacaoPedido.Current == null)
            {
                tabControl.SelectedIndex = 0;
                MessageBox.Show("Atenção, é necessário selecionar um pedido!");
            }
            else
            {
                if (tcNotaFiscal.SelectedIndex == 0)
                    tabNotaFiscalEntrada_Enter(null, null);
                else
                    tabNotaFiscalSaida_Enter(null, null);
            }
        }

        private void tabTPNFNormalE_Enter(object sender, EventArgs e)
        {
            TList_NotaFiscalPedido ListaNota = null;
            TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
            bool EfetuarBusca = true;

            //EFETUA A BUSCA PELA LISTA PRA CADASTRADA
            for (int i = 0; i < ListaNFE.Count; i++)
            {
                if (ListaNFE[i] != null)
                {
                    if ((ListaNFE[i] as TList_NotaFiscalPedido).Count > 0)
                    {
                        if (Reg_LanAplicacaoPedido.Nr_pedido == ((ListaNFE[i] as TList_NotaFiscalPedido)[0] as TRegistro_NotaFiscalPedido).Nr_Pedido)
                        {
                            ListaNota = (ListaNFE[i] as TList_NotaFiscalPedido);
                            EfetuarBusca = false;
                            break;
                        }
                    }
                }
            }

            if (EfetuarBusca)
            {
                ListaNota = new TCD_PedidoAplicacao().BuscaNotasFiscaisPedido(Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                                              Reg_LanAplicacaoPedido.Cd_empresa, false, "E");
                ListaNFE.Add(ListaNota);
            }
            tot_qtdnfentrada.Value = ListaNota.Sum(p => p.Quantidade);
            tot_vlnfentrada.Value = ListaNota.Sum(p => p.VL_SubTotal);
            tot_qtdorigem.Value = ListaNota.Sum(p => p.Qtd_origem);
            saldo_qtdorigem.Value = ListaNota.Sum(p => p.Qtd_sdorigem);
            tot_vlorigem.Value = ListaNota.Sum(p => p.Vl_origem);
            saldo_vlorigem.Value = ListaNota.Sum(p => p.Vl_sdorigem);
            BS_NFEntrada.DataSource = ListaNota;
            BS_NFEntrada.ResetCurrentItem();
        }

        private void tabTPNFNormalS_Enter(object sender, EventArgs e)
        {
            TList_NotaFiscalPedido ListaNota = null;
            TRegistro_PedidoAplicacao Reg_LanAplicacaoPedido = (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao);
            bool EfetuarBusca = true;

            //EFETUA A BUSCA PELA LISTA PRE CADASTRADA
            foreach(var p in ListaNFS)
            {
                if (p != null)
                    if (p.Count > 0)
                    {
                        if (Reg_LanAplicacaoPedido.Nr_pedido.Equals(p[0].Nr_Pedido))
                        {
                            ListaNota = p;
                            EfetuarBusca = false;
                            break;
                        }
                    }
            }

            if (EfetuarBusca)
            {
                ListaNota = new TCD_PedidoAplicacao().BuscaNotasFiscaisPedido(Convert.ToDecimal(Reg_LanAplicacaoPedido.Nr_pedido),
                                                                              Reg_LanAplicacaoPedido.Cd_empresa, false, "S");
                ListaNFS.Add(ListaNota);
            }
            tot_qtdnfsaida.Value = ListaNota.Sum(p => p.Quantidade);
            tot_vlnfsaida.Value = ListaNota.Sum(p => p.VL_SubTotal);
            BS_NFSaida.DataSource = ListaNota;
            BS_NFSaida.ResetCurrentItem();
        }

        private void tabNotaFiscalEntrada_Enter(object sender, EventArgs e)
        {
            if (tcTPNFE.SelectedIndex == 0)
                tabTPNFNormalE_Enter(null, null);
            else
                tabTPNFMestraE_Enter(null, null);
        }

        private void tabNotaFiscalSaida_Enter(object sender, EventArgs e)
        {
            if (tcTPNFS.SelectedIndex == 0)
                tabTPNFNormalS_Enter(null, null);
            else
                tabTPNFMestraS_Enter(null, null);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                        "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
                        , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor },
                "|exists|(select 1 from vtb_gro_contrato x " +
                "           where x.cd_clifor = a.cd_clifor)");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                                          "|exists|(select 1 from vtb_gro_contrato x " +
                                          "         where x.cd_clifor = a.cd_clifor)",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto }, string.Empty);
        }

        private void Cd_Produto_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto },
                                    new TCD_CadProduto());
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {

            string vParam = "isnull(a.st_registro, 'A')|in|('A', 'E')";
            if (cd_empresa.Text.Trim() != string.Empty)
                vParam += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            else
            {
                vParam += ";|exists|(select 1 from tb_div_usuario_x_empresa x " +
                         "where x.cd_empresa = a.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "          where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { Nr_Contrato }, vParam);
        }

        private void Nr_Contrato_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_contrato|=|" + Nr_Contrato.Text + ";" +
                              "isnull(a.st_registro, 'A')|in|('A', 'E');";
            if (cd_empresa.Text.Trim() != string.Empty)
                vColunas += "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            else
            {
                vColunas += "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_Contrato },
                                    new TCD_CadContrato());
        }

        private void BS_Entrada_Transferencia_PositionChanged(object sender, EventArgs e)
        {
            if (TC_Transferencia.SelectedTab == TP_Transferecia_Entrada)
                if (((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_pedido > 0) && ((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa != ""))
                    if ((BS_Entrada_Transferencia != null) && (BS_Entrada_Transferencia.Count > 0))
                    {
                        TList_Transf_X_Contrato List_Transf_X_Contrato_Origem_Entrada_Transf = 
                            TCN_Transf_X_Contrato.Busca(string.Empty, 
                                                        string.Empty, 
                                                        "E", 
                                                        (BS_Entrada_Transferencia.Current as TRegistro_Transf_X_Contrato).NR_Contrato.ToString(), 
                                                        true,
                                                        null);
                        if ((List_Transf_X_Contrato_Origem_Entrada_Transf != null) && (List_Transf_X_Contrato_Origem_Entrada_Transf.Count > 0))
                            BS_Origem_TransfEntrada.DataSource = List_Transf_X_Contrato_Origem_Entrada_Transf;
                        else
                            BS_Origem_TransfEntrada.Clear();
                    }
        }

        private void BS_Saida_Transferencia_PositionChanged(object sender, EventArgs e)
        {
            if (TC_Transferencia.SelectedTab == TP_Transferecia_Saida)
                if (((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_pedido > 0) && ((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa != ""))
                    if ((BS_Saida_Transferencia != null) && (BS_Saida_Transferencia.Count > 0))
                    {
                        TList_Transf_X_Contrato List_Transf_X_Contrato_Destino_Saida_Transf = 
                            TCN_Transf_X_Contrato.Busca(string.Empty, 
                                                        string.Empty,
                                                        "S", 
                                                        (BS_Saida_Transferencia.Current as TRegistro_Transf_X_Contrato).NR_Contrato.ToString(),
                                                        true,
                                                        null);
                        if ((List_Transf_X_Contrato_Destino_Saida_Transf != null) && (List_Transf_X_Contrato_Destino_Saida_Transf.Count > 0))
                            BS_Destino_TransfSaida.DataSource = List_Transf_X_Contrato_Destino_Saida_Transf;
                        else
                            BS_Destino_TransfSaida.Clear();
                    }
        }

        private void TFCon_Historico_Contrato_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_AplicacaoPedido);
            Utils.ShapeGrid.RestoreShape(this, grid_Destino);
            Utils.ShapeGrid.RestoreShape(this, grid_ItemsNotaFiscalE);
            Utils.ShapeGrid.RestoreShape(this, grid_ItemsNotaFiscalS);
            Utils.ShapeGrid.RestoreShape(this, grid_MestraE);
            Utils.ShapeGrid.RestoreShape(this, grid_MestraS);
            Utils.ShapeGrid.RestoreShape(this, grid_NotaFiscalE);
            Utils.ShapeGrid.RestoreShape(this, grid_NotaFiscalS);
            Utils.ShapeGrid.RestoreShape(this, grid_NotaNormalEntrada);
            Utils.ShapeGrid.RestoreShape(this, grid_NotaNormalS);
            Utils.ShapeGrid.RestoreShape(this, grid_Origem);
            Utils.ShapeGrid.RestoreShape(this, grid_PesDeposito);
            Utils.ShapeGrid.RestoreShape(this, grid_PesExpedicao);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TP_Transferecia_Entrada_Enter(object sender, EventArgs e)
        {
            if ((BS_AplicacaoPedido != null) && (BS_AplicacaoPedido.Count > 0))
                if (((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_pedido > 0) && ((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa != ""))
                {
                    TList_Transf_X_Contrato List_Transf_X_Pedido_Entrada_Transferencia =
                        TCN_Transf_X_Contrato.Busca(string.Empty,
                                                    (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                    "E",
                                                    (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                    true,
                                                    null);
                    if ((List_Transf_X_Pedido_Entrada_Transferencia != null) && (List_Transf_X_Pedido_Entrada_Transferencia.Count > 0))
                    {
                        BS_Entrada_Transferencia.DataSource = List_Transf_X_Pedido_Entrada_Transferencia;
                        BS_Entrada_Transferencia_PositionChanged(sender, e);

                        BS_Entrada_Transferencia.ResetBindings(true);
                    }
                    else
                    {
                        BS_Entrada_Transferencia.Clear();
                        BS_Origem_TransfEntrada.Clear();
                    }
                }
        }

        private void TP_Transferecia_Saida_Enter(object sender, EventArgs e)
        {
            if ((BS_AplicacaoPedido != null) && (BS_AplicacaoPedido.Count > 0))
                if (((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_pedido > 0) && ((BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa != ""))
                {
                    TList_Transf_X_Contrato List_Transf_X_Pedido_Saida_Transferecia =
                        TCN_Transf_X_Contrato.Busca(string.Empty,
                                                   (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                   "S",
                                                   (BS_AplicacaoPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                   true,
                                                   null);
                    if ((List_Transf_X_Pedido_Saida_Transferecia != null) && (List_Transf_X_Pedido_Saida_Transferecia.Count > 0))
                    {
                        BS_Saida_Transferencia.DataSource = List_Transf_X_Pedido_Saida_Transferecia;
                        BS_Saida_Transferencia_PositionChanged(sender, e);

                        BS_Saida_Transferencia.ResetBindings(true);
                    }
                    else
                    {
                        BS_Saida_Transferencia.Clear();
                        BS_Destino_TransfSaida.Clear();
                    }
                }
        }

        private void labelDiferencaQTDEnt_Click(object sender, EventArgs e)
        {
            if(((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDEnt != 0) ||
                ((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLEnt != 0))
                ProcessarFisicoFiscal("E");
        }

        private void labelDiferencaVLEnt_Click(object sender, EventArgs e)
        {
            if (((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDEnt != 0) ||
                ((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLEnt != 0))
                ProcessarFisicoFiscal("E");
        }

        private void labelDiferencaVLSai_Click(object sender, EventArgs e)
        {
            if (((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDSai != 0) ||
                ((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLSai != 0))
                ProcessarFisicoFiscal("S");
        }

        private void labelDiferencaQTDSai_Click(object sender, EventArgs e)
        {
            if (((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaQTDSai != 0) ||
                ((BS_TotaisConsulta.Current as TRegistro_TotaisConsulta).DiferencaVLSai != 0))
                ProcessarFisicoFiscal("S");
        }

        private void cd_tipoamostra1_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tipoamostra|=|'" + cd_tipoamostra1.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tipoamostra1 },
                                    new CamadaDados.Graos.TCD_CadAmostra());
            tabPesagem_Enter(this, new EventArgs());
        }

        private void bb_tipoamostra1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|200;" +
                              "a.cd_tipoamostra|Cd. Amostra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tipoamostra1 },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
            tabPesagem_Enter(this, new EventArgs());
        }

        private void cd_tipoamostra2_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tipoamostra|=|'" + cd_tipoamostra2.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tipoamostra2 },
                                    new CamadaDados.Graos.TCD_CadAmostra());
            tabPesagem_Enter(this, new EventArgs());
        }

        private void bb_tipoamostra2_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|200;" +
                              "a.cd_tipoamostra|Cd. Amostra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tipoamostra2 },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
            tabPesagem_Enter(this, new EventArgs());
        }

        private void TFCon_Historico_Contrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_AplicacaoPedido);
            Utils.ShapeGrid.SaveShape(this, grid_Destino);
            Utils.ShapeGrid.SaveShape(this, grid_ItemsNotaFiscalE);
            Utils.ShapeGrid.SaveShape(this, grid_ItemsNotaFiscalS);
            Utils.ShapeGrid.SaveShape(this, grid_MestraE);
            Utils.ShapeGrid.SaveShape(this, grid_MestraS);
            Utils.ShapeGrid.SaveShape(this, grid_NotaFiscalE);
            Utils.ShapeGrid.SaveShape(this, grid_NotaFiscalS);
            Utils.ShapeGrid.SaveShape(this, grid_NotaNormalEntrada);
            Utils.ShapeGrid.SaveShape(this, grid_NotaNormalS);
            Utils.ShapeGrid.SaveShape(this, grid_Origem);
            Utils.ShapeGrid.SaveShape(this, grid_PesDeposito);
            Utils.ShapeGrid.SaveShape(this, grid_PesExpedicao);
        }
    }
}
