using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Utils;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFFecharCupom : Form
    {
        private CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom
        { get; set; }
        public bool St_ReprocessaFin
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pNr_cupom
        { get; set; }
        public string pCd_portador
        { get; set; }
        public string pCd_operador
        { get; set; }
        public string Id_caixaPDV
        { get; set; }
        public string LoginPDV
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TList_CadPortador lPortador
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private decimal pTot_desconto
        { get; set; }
        public decimal pVl_desconto
        { get; set; }
        public decimal pVl_receber
        { get; set; }
        public decimal pVl_outrosrec
        { get; set; }
        public decimal pVl_troco
        { get { return Convert.ToDecimal(lblVlRestante.Text); } }
        private decimal pTot_desc
        { get; set; }
        public bool st_convenio { get; set; } = false;
        public TFFecharCupom()
        {
            InitializeComponent();
            St_ReprocessaFin = false;
            pCd_empresa = string.Empty;
            pNm_empresa = string.Empty;
            pCd_clifor = string.Empty;
            pNm_clifor = string.Empty;
            pNr_cupom = string.Empty;
            pCd_portador = string.Empty;
            pTot_desconto = decimal.Zero;
            pVl_desconto = decimal.Zero;
            pVl_outrosrec = decimal.Zero;
            lPortador = new CamadaDados.Financeiro.Cadastros.TList_CadPortador();
            lblVlReceber.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            lblTotalPago.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            lblVlRestante.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
        }

        private void InformarValor()
        {
            if (lPortador.Count > 0)
            {
                if (Math.Round(pVl_receber, 2) > Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
                {
                    if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_controletitulobool)//Cheque
                    {
                        //Verificar credito
                        CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                            new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                        if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(pCd_clifor,
                                                                                                          pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV),
                                                                                                          false,
                                                                                                          ref rDados,
                                                                                                          null))
                            using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                            {
                                fBloq.rDados = rDados;
                                fBloq.Vl_fatura = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                                fBloq.ShowDialog();
                                if (!fBloq.St_desbloqueado)
                                    throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                            }
                        using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                        {
                            fListaCheques.Tp_mov = "R";
                            fListaCheques.Cd_empresa = pCd_empresa;
                            fListaCheques.St_pdv = true;
                            //Buscar Config PDV Empresa
                            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(pCd_empresa, null);
                            if (lCfg.Count > 0)
                            {
                                fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                                fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                            }
                            fListaCheques.Cd_clifor = pCd_clifor;
                            fListaCheques.Cd_historico = rCfg.Cd_historicocaixa;
                            fListaCheques.Ds_historico = rCfg.Ds_historicocaixa;
                            fListaCheques.Cd_portador = (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Cd_portador;
                            fListaCheques.Ds_portador = (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Ds_portador;
                            fListaCheques.Nm_clifor = pNm_clifor;
                            fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            fListaCheques.Vl_totaltitulo = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fListaCheques.St_bloquearTroco = St_ReprocessaFin;
                            if (fListaCheques.ShowDialog() == DialogResult.OK)
                            {
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCheque = fListaCheques.lCheques;
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV =
                                        fListaCheques.lCheques.Sum(p=> p.Vl_titulo);
                                bsPortador.ResetCurrentItem();
                                CalcularTroco();
                            }
                            else
                            {
                                MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada! ");
                                return;
                            }
                        }
                    }
                    else if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_cartaocreditobool)//Cartao Cred/Deb
                    {
                        using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                        {
                            if (fD_C.ShowDialog() == DialogResult.OK)
                            {
                                //Buscar dados fatura cartao credito
                                using (TFLanCartaoPDV fCartao = new TFLanCartaoPDV())
                                {
                                    fCartao.pCd_empresa = pCd_empresa;
                                    fCartao.D_C = fD_C.D_C;
                                    fCartao.Vl_saldofaturar = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                                    fCartao.St_bloquearTroco = St_ReprocessaFin;
                                    fCartao.st_parcela = true;
                                    if (fCartao.ShowDialog() == DialogResult.OK)
                                    {
                                        fCartao.lFatura.ForEach(p => (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lFatura.Add(p));
                                        (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV += fCartao.lFatura.Sum(p => p.Vl_fatura);
                                        bsPortador.ResetCurrentItem();
                                        CalcularTroco();
                                    }
                                }
                            }
                        }
                    }
                    else if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Tp_portadorpdv.Trim().ToUpper().Equals("P"))//Duplicata
                    {
                        if (string.IsNullOrEmpty(pCd_clifor))
                        {
                            MessageBox.Show("Não é permitido venda a prazo sem identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Abrir tela Duplicata
                        if (pCd_clifor == rCfg.Cd_clifor)
                        {
                            Componentes.EditDefault CD_Clifor = new Componentes.EditDefault();
                            CD_Clifor.NM_Campo = "CD_Clifor";
                            CD_Clifor.NM_CampoBusca = "CD_Clifor";
                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
                            if (linha != null)
                            {
                                pCd_clifor = linha["cd_clifor"].ToString();
                                pNm_clifor = linha["Nm_clifor"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar cliente para gerar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (lPdv == null ? false : lPdv.Count.Equals(0) ? false : lPdv[0].St_dupresumidabool)
                        {
                            CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                            rDup.Cd_empresa = pCd_empresa;
                            rDup.Nm_empresa = pNm_empresa;
                            rDup.Cd_clifor = pCd_clifor;
                            rDup.Nm_clifor = pNm_clifor;
                            rDup.Cd_condpgto = rCfg.Cd_condpgto;
                            rDup.Ds_condpgto = rCfg.Ds_condpgto;
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
                                                                                                  1,
                                                                                                  null);
                            if (lEnd.Count > 0)
                            {
                                rDup.Cd_endereco = lEnd[0].Cd_endereco;
                                rDup.Ds_endereco = lEnd[0].Ds_endereco;
                            }
                            rDup.Cd_historico = rCfg.Cd_historico;
                            rDup.Ds_historico = rCfg.Ds_historico;
                            rDup.Tp_duplicata = rCfg.Tp_duplicata;
                            rDup.Ds_tpduplicata = rCfg.Ds_tpduplicata;
                            rDup.Tp_mov = "R";
                            rDup.Tp_doctostring = rCfg.Tp_doctostr;
                            rDup.Ds_tpdocto = rCfg.Ds_tpdocto;
                            //Buscar Moeda Padrao
                            CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                                CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
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
                            rDup.Nr_docto = !string.IsNullOrEmpty(rCupom.Id_locacao) ?
                                "LOC" + rCupom.Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                            rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            rDup.Vl_documento = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            rDup.Vl_documento_padrao = rDup.Vl_documento;
                            object Id_Config = new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco().BuscarEscalar(
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
                                                                        "and x.cd_empresa = '" + pCd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Cd_portador.Trim() + "'"
                                                        }
                                                    }, "a.id_config");
                            rDup.Id_configboletostr = Id_Config == null ? string.Empty : Id_Config.ToString();
                            using (TFDuplicataPDV fDup = new TFDuplicataPDV())
                            {
                                fDup.rDup = rDup;
                                if (fDup.ShowDialog() == DialogResult.OK)
                                {
                                    if (rCupom != null)
                                    {
                                        rCupom.Cd_clifor = rDup.Cd_clifor;
                                        rCupom.Nm_clifor = rDup.Nm_clifor;
                                    }
                                    (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lDup.Add(rDup);
                                    (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = rDup.Vl_documento;
                                    bsPortador.ResetCurrentItem();
                                    CalcularTroco();
                                }
                            }
                        }
                        else
                        {
                            //Abrir tela Duplicata
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vCd_empresa = pCd_empresa;
                                fDuplicata.vNm_empresa = pNm_empresa;
                                fDuplicata.vCd_clifor = pCd_clifor;
                                fDuplicata.vNm_clifor = pNm_clifor;
                                fDuplicata.vCd_condpgto = rCfg.Cd_condpgto;
                                fDuplicata.vDs_condpgto = rCfg.Ds_condpgto;
                                fDuplicata.vSt_ecf = true;
                                fDuplicata.vId_caixa = Id_caixaPDV;
                                fDuplicata.St_bloquearccusto = true;
                                //Buscar endereco clifor
                                if (!string.IsNullOrEmpty(pCd_clifor))
                                {
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
                                                                                                  1,
                                                                                                  null);
                                    if (lEnd.Count > 0)
                                    {
                                        fDuplicata.vCd_endereco = lEnd[0].Cd_endereco;
                                        fDuplicata.vDs_endereco = lEnd[0].Ds_endereco;
                                    }
                                }
                                fDuplicata.vCd_historico = rCfg.Cd_historico;
                                fDuplicata.vDs_historico = rCfg.Ds_historico;
                                fDuplicata.vTp_duplicata = rCfg.Tp_duplicata;
                                fDuplicata.vDs_tpduplicata = rCfg.Ds_tpduplicata;
                                fDuplicata.vTp_mov = "R";
                                fDuplicata.vTp_docto = rCfg.Tp_doctostr;
                                fDuplicata.vDs_tpdocto = rCfg.Ds_tpdocto;
                                //Buscar Moeda Padrao
                                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                                    CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
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
                                //
                                object Id_Config = new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco().BuscarEscalar(
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
                                                                        "and x.cd_empresa = '" + pCd_empresa.Trim() + "')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_portador",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Cd_portador.Trim() + "'"
                                                        }
                                                    }, "a.id_config");
                                fDuplicata.vDs_observacao = rCupom.NR_Docto_Origem;
                                fDuplicata.vId_configBoleto = Id_Config == null ? string.Empty : Id_Config.ToString();
                                fDuplicata.vNr_docto = !string.IsNullOrEmpty(rCupom.Id_locacao) ?
                                "LOC" + rCupom.Id_locacao : "PDC123";//pNr_cupom; //Numero Cupom
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                fDuplicata.vVl_documento = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                    if (fDuplicata.dsDuplicata.Current != null)
                                    {
                                        if (rCupom != null)
                                        {
                                            rCupom.Cd_clifor = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_clifor;
                                            rCupom.Nm_clifor = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nm_clifor;
                                            if ((fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento > fDuplicata.vVl_documento)
                                            {
                                                pVl_receber += (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento - fDuplicata.vVl_documento;
                                                //Ratear juro financeiro cupom
                                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.RatearJuroFinVRapida(rCupom, (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento - fDuplicata.vVl_documento);
                                            }
                                        }
                                        (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lDup.Add(
                                            (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata));
                                        (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV =
                                            (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento_padrao;
                                        bsPortador.ResetCurrentItem();
                                        CalcularTroco();
                                    }
                            }
                        }
                    }
                    else if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_devcreditobool)//Devolucao Credito
                    {
                        using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
                        {
                            fSaldo.Cd_empresa = pCd_empresa;
                            fSaldo.Cd_clifor = pCd_clifor;
                            fSaldo.Vl_financeiro = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fSaldo.Tp_mov = "'R'";
                            if(fSaldo.ShowDialog() == DialogResult.OK)
                                if (fSaldo.lSaldo != null)
                                {
                                    (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCred = fSaldo.lSaldo;
                                    (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV =
                                            fSaldo.lSaldo.Sum(p => p.Vl_processar);
                                    bsPortador.ResetCurrentItem();
                                    CalcularTroco();
                                }
                        }
                    }
                    else if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_cartafretebool)
                    {
                        //Carta Frete
                        using (TFLanListaCartaFrete fCf = new TFLanListaCartaFrete())
                        {
                            fCf.Cd_empresa = pCd_empresa;
                            fCf.Nm_empresa = pNm_empresa;
                            fCf.Vl_totaltitulo = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            if (fCf.ShowDialog() == DialogResult.OK)
                            {
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCartaFrete = fCf.lCarta;
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = fCf.lCarta.Sum(p=> p.Vl_documento);
                                bsPortador.ResetCurrentItem();
                                CalcularTroco();
                            }
                        }
                    }
                    else
                    {
                        //Portador Dinheiro
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Casas_decimais = 2;
                            fQtde.Vl_default = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fQtde.Vl_saldo = St_ReprocessaFin ? pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV) : decimal.Zero;
                            fQtde.Ds_label = "Valor Recebido";
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = fQtde.Quantidade;
                                bsPortador.ResetCurrentItem();
                                CalcularTroco();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe mais saldo para receber.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalcularTroco()
        {
            lblTotalPago.Text = lPortador.Sum(p => p.Vl_pagtoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            lblVlRestante.Text = Math.Abs(pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (Math.Round(pVl_receber, 2) < Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
            {
                LabelSaldo.Text = "Valor Troco";
                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_trocoPDV =
                    Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
            }
            if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_trocoPDV > 0)
                AbrirGavetaDinheiro();
        }

        private void ConfirmarFin()
        {
            if (Math.Round(pVl_receber, 2) > Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
            {
                MessageBox.Show("Existe saldo receber: "  + 
                                (Math.Round(pVl_receber, 2) - Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (St_ReprocessaFin)//Se for reprocessamento, levar em consideracao o troco
            {
                if (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) < pVl_receber)
                    lPortador.FindLast(p=> p.Vl_pagtoPDV > decimal.Zero).Vl_trocoPDV = pVl_receber - (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - pVl_outrosrec);
            }
            if (lPortador.Exists(p => p.Vl_trocoPDV > decimal.Zero))
            {
                using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                {
                    fTroco.Cd_empresa = pCd_empresa;
                    fTroco.Id_caixaPDV = Id_caixaPDV;
                    fTroco.St_desativarCred = lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).St_cartafretebool;
                    fTroco.Vl_troco = lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).Vl_trocoPDV;
                    fTroco.Cd_historioTroco = rCfg.Cd_historico_troco;
                    fTroco.Ds_historicoTroco = rCfg.Ds_historico_troco;
                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPDV, "PERMITIR GERAR CREDITO NO TROCO", null);
                    if (fTroco.ShowDialog() == DialogResult.OK)
                    {
                        if (fTroco.Vl_trocoCredito > decimal.Zero)
                        {
                            lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).Vl_credTroco = fTroco.Vl_trocoCredito;
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", pCd_empresa, null).Trim().ToUpper().Equals("S"))
                            {
                                if(lPortador.Exists(p=> p.lCartaFrete.Count > 0))
                                {
                                    rCupom.Cd_clifor = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Cd_transportadora;
                                    rCupom.Nm_clifor = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Nm_transportadora;
                                    rCupom.Cd_endereco = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Cd_enderecotransp;
                                }
                                if(string.IsNullOrEmpty(rCupom.Cd_clifor))
                                {
                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                    if (linha != null)
                                    {
                                        rCupom.Cd_clifor = linha["cd_clifor"].ToString();
                                        rCupom.Nm_clifor = linha["nm_clifor"].ToString();
                                        //buscar endereco clifor
                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = rCupom.Cd_clifor
                                                }
                                            }, "a.cd_endereco");
                                        if (obj != null)
                                            rCupom.Cd_endereco = obj.ToString();
                                        lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).St_gerarCredito = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            else
                                using (Utils.InputBox inp = new Utils.InputBox())
                                {
                                    //buscar endereco clifor
                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = rCupom.Cd_clifor
                                            }
                                        }, "a.cd_endereco");
                                    if (obj != null)
                                        rCupom.Cd_endereco = obj.ToString();
                                    lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).Ds_mensagemCredito = inp.ShowDialog();
                                    lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).St_gerarCredito = true;
                                }
                        }
                        if (fTroco.lChRepasse != null)
                        {
                            fTroco.lChRepasse.ForEach(p => lPortador.Find(v => v.Vl_trocoPDV > decimal.Zero).lChTroco.Add(p));
                            if (string.IsNullOrEmpty(rCupom.Cd_clifor))
                            {
                                if(lPortador.Exists(p=> p.lCartaFrete.Count > 0))
                                {
                                    rCupom.Cd_clifor = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Cd_transportadora;
                                    rCupom.Nm_clifor = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Nm_transportadora;
                                    rCupom.Cd_endereco = lPortador.Find(p=> p.lCartaFrete.Count > 0).lCartaFrete[0].Cd_enderecotransp;
                                }
                                if(string.IsNullOrEmpty(rCupom.Cd_clifor))
                                {
                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                    if (linha != null)
                                    {
                                        rCupom.Cd_clifor = linha["cd_clifor"].ToString();
                                        rCupom.Nm_clifor = linha["nm_clifor"].ToString();
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
                            fTroco.lChTroco.ForEach(p => lPortador.Find(v => v.Vl_trocoPDV > decimal.Zero).lChTroco.Add(p));
                        if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                            lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                        else lPortador.Find(p => p.Vl_trocoPDV > decimal.Zero).Vl_trocoPDV = decimal.Zero;
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if(rCupom != null)
                if(pTot_desconto > decimal.Zero)
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.RatearDescontoVRapida(rCupom, pTot_desconto, decimal.Zero);
            DialogResult = DialogResult.OK;
        }

        private void InformarDesconto()
        {
            if (bsPortador.Count > 0)
            {
                if (lPortador.Sum(p => p.Vl_pagtoPDV) > 0)
                {
                    MessageBox.Show("Ja existe pagamento informado.\r\nNão é permitido informar desconto.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDesconto fDesc = new TFDesconto())
                {
                    fDesc.Vl_venda = pVl_receber;
                    if (fDesc.ShowDialog() == DialogResult.OK)
                    {
                        //decimal vl_desconto = decimal.Zero;
                        decimal pc_desconto = decimal.Zero;
                        if (fDesc.St_valor)
                        {
                            pVl_desconto = fDesc.Desconto;
                            pc_desconto = Math.Round(fDesc.Desconto * (100 / pVl_receber), 2);
                        }
                        else
                        {
                            pc_desconto = fDesc.Desconto;
                            pVl_desconto = rCupom.lItem.Where(p => !p.st_servico).ToList().Sum(p => p.Vl_subtotal) * (fDesc.Desconto / 100);
                        }
                        if (pVl_desconto > decimal.Zero)
                        {
                            pTot_desc += pVl_desconto; 
                            pTot_desconto = rCupom.lItem.Sum(p => p.Vl_desconto) + pTot_desc;
                            if (!VerificarTotDesconto(rCupom, pTot_desconto))
                                Close();
                            pVl_receber -= pVl_desconto;
                            lblVlReceber.Text = pVl_receber.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                        }
                    }
                }
            }
        }

        private bool VerificarTotDesconto(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val, decimal tot_desconto)
        {
            for (int i = 0; i < (val.lItem.Count); i++)
            {
                if (lDesc == null ? false : lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(val.Cd_tabelapreco))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                            p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
                            string tp_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                                        p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Tp_desconto;
                            decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                            if (pc_desconto > 100)
                            {
                                MessageBox.Show("Soma do % de desconto foi maior que 100! Favor verificar desconto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            if (pc_desconto > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = val.Cd_tabelapreco;
                                    fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginPDV = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim())).Pc_max_desconto;
                            decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                            if (pc_desconto > 100)
                            {
                                MessageBox.Show("Soma do % de desconto foi maior que 100! Favor verificar desconto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            if (pc_desconto > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = val.Cd_tabelapreco;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginPDV = fLogin.Logindesconto;
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
                        decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                        if (pc_desconto > 100)
                        {
                            MessageBox.Show("Soma do % de desconto foi maior que 100! Favor verificar desconto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        if (pc_desconto > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = pc_desconto;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                    return false;
                                else
                                {
                                    LoginPDV = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    //Desconto por vendedor e empresa
                    decimal pc_descontoOp = tot_desconto * 100 / pVl_receber;
                    if (pc_descontoOp > 100)
                    {
                        MessageBox.Show("Soma do % de desconto foi maior que 100! Favor verificar desconto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (pc_descontoOp > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = val.Cd_empresa;
                            fLogin.Pc_desc = pc_descontoOp;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                                return false;
                            else
                            {
                                LoginPDV = fLogin.Logindesconto;
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

        private void AbrirGavetaDinheiro()
        {
            if(lPdv != null)
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

        private void TFFecharCupom_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gPortador);
            //Buscar lista de descontos configuradas para o vendedor

            if (!string.IsNullOrEmpty(pCd_operador) && !st_convenio)
            {
                lDesc =
                     CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(pCd_operador,
                                                                                     pCd_empresa,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     null);
            }
            //Somente validar desconto se venda possuir vendedor
            if (!string.IsNullOrEmpty(pCd_operador) ? (lDesc == null ? true : lDesc.Count.Equals(0)) : false)
                lblDesconto.Enabled = false;
            lPortador = CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(pCd_portador,
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  false,
                                                                                  false,
                                                                                  "'A', 'P'",
                                                                                  0,
                                                                                  string.Empty,
                                                                                  "ordem",
                                                                                  null);
            bsPortador.DataSource = lPortador.FindAll(p=> p.St_entregafuturabool.Equals(false));
            lblVlReceber.Text = pVl_receber.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (lPdv != null)
                lblAbrirGaveta.Visible = lPdv[0].St_gavetadinheirobool;            
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lblInfValor_Click(object sender, EventArgs e)
        {
            InformarValor();
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarFin();
        }

        private void lblInfValor_MouseEnter(object sender, EventArgs e)
        {
            lblInfValor.BorderStyle = BorderStyle.FixedSingle;
            lblInfValor.Cursor = Cursors.Hand;
            lblInfValor.ForeColor = Color.Blue;
        }

        private void lblInfValor_MouseLeave(object sender, EventArgs e)
        {
            lblInfValor.BorderStyle = BorderStyle.None;
            lblInfValor.Cursor = Cursors.Default;
            lblInfValor.ForeColor = Color.Black;
        }

        private void lblConfirmar_MouseEnter(object sender, EventArgs e)
        {
            lblConfirmar.BorderStyle = BorderStyle.FixedSingle;
            lblConfirmar.Cursor = Cursors.Hand;
            lblConfirmar.ForeColor = Color.Blue;
        }

        private void lblConfirmar_MouseLeave(object sender, EventArgs e)
        {
            lblConfirmar.BorderStyle = BorderStyle.None;
            lblConfirmar.Cursor = Cursors.Default;
            lblConfirmar.ForeColor = Color.Black;
        }

        private void lblCancelar_MouseEnter(object sender, EventArgs e)
        {
            lblCancelar.BorderStyle = BorderStyle.FixedSingle;
            lblCancelar.Cursor = Cursors.Hand;
            lblCancelar.ForeColor = Color.Blue;
        }

        private void lblCancelar_MouseLeave(object sender, EventArgs e)
        {
            lblCancelar.BorderStyle = BorderStyle.None;
            lblCancelar.Cursor = Cursors.Default;
            lblCancelar.ForeColor = Color.Black;
        }

        private void TFFecharCupom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1) && lblDesconto.Enabled)
                InformarDesconto();
            else if (e.KeyCode.Equals(Keys.F2))
                InformarValor();
            else if (e.KeyCode.Equals(Keys.F4))
                ConfirmarFin();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Right))
                AbrirGavetaDinheiro();
        }

        private void lblDesconto_Click(object sender, EventArgs e)
        {
            InformarDesconto();
            
        }

        private void lblDesconto_MouseEnter(object sender, EventArgs e)
        {
            lblDesconto.BorderStyle = BorderStyle.FixedSingle;
            lblDesconto.Cursor = Cursors.Hand;
            lblDesconto.ForeColor = Color.Blue;
        }

        private void lblDesconto_MouseLeave(object sender, EventArgs e)
        {
            lblDesconto.BorderStyle = BorderStyle.None;
            lblDesconto.Cursor = Cursors.Default;
            lblDesconto.ForeColor = Color.Black;
        }

        private void gPortador_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPortador.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPortador.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador());
            CamadaDados.Financeiro.Cadastros.TList_CadPortador lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadPortador(lP.Find(gPortador.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPortador.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadPortador(lP.Find(gPortador.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPortador.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPortador.List as CamadaDados.Financeiro.Cadastros.TList_CadPortador).Sort(lComparer);
            bsPortador.ResetBindings(false);
            gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFFecharCupom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPortador);
        }
    }
}
