using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFFecharVendaPDV : Form
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
        public string pCd_endereco
        { get; set; }
        public string pDs_endereco
        { get; set; }
        public string pNr_cupom
        { get; set; }
        public string pCd_portador
        { get; set; }
        public string pCd_vendedor
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
        public decimal pPc_Desconto
        { get; set; }
        public decimal pVl_troco
        { get { return Convert.ToDecimal(vl_saldo.Text); } }
        private decimal pTot_desc
        { get; set; }
        public bool pRb_Valor { get; set; }

        public TFFecharVendaPDV()
        {
            InitializeComponent();
        }

        public void pagar(string portador, decimal pVl_pago)
        {
            //Portador Dinheiro
            TFFecharVendaPDV_Load(this, new EventArgs());
            lPortador.Find(p => !p.St_devcreditobool &&
                                !p.St_entregafuturabool &&
                                !p.St_controletitulobool &&
                                !p.St_cartaocreditobool &&
                                !p.St_cartafretebool &&
                                !p.Tp_portadorpdv.Equals("P")).Vl_pagtoPDV = pVl_pago;

            CalcularTroco(portador);
            ConfirmarFin();

        }

        private void InformarDesconto()
        {
            if (lPortador.Count > 0)
            {
                //if (lPortador.Sum(p => p.Vl_pagtoPDV) > 0)
                //{
                //    MessageBox.Show("Já existe pagamento informado.\r\nNão é permitido informar desconto.",
                //        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                using (TFDesconto fDesc = new TFDesconto())
                {
                    fDesc.Vl_venda = pVl_receber;
                    fDesc.pRb_Valor = true;
                    if (fDesc.ShowDialog() == DialogResult.OK)
                    {
                        //decimal vl_desconto = decimal.Zero;
                        decimal pc_desconto = decimal.Zero;
                        if (fDesc.St_valor)
                        {
                            pVl_receber += pVl_desconto;
                            pVl_desconto = fDesc.Desconto;

                            //Percentual de desconto sobre o Valor a receber
                            pc_desconto = fDesc.Desconto * (100 / pVl_receber);
                        }
                        else
                        {
                            pVl_receber += pVl_desconto;
                            pc_desconto = fDesc.Desconto;
                            pVl_desconto = rCupom.lItem.Where(p => !p.st_servico).ToList().Sum(p => p.Vl_subtotal) * (fDesc.Desconto / 100);
                        }
                        if (pVl_desconto > decimal.Zero)
                        {
                            pTot_desc += pVl_desconto;
                            pTot_desconto = pTot_desc;
                            if (!VerificarTotDesconto(rCupom, pTot_desconto)) return;
                            pVl_receber = (rCupom.lItem.Sum(p => p.Vl_subtotal)) - pTot_desconto;
                            VL_DESCONTO.Value += pVl_desconto;
                            vl_receber.Text = pVl_receber.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                            pPc_Desconto = pc_desconto;
                            CalcularTroco(string.Empty);
                            ConfirmarFin();
                        }
                    }
                }
            }
        }

        private bool VerificarTotDesconto(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val, decimal tot_desconto)
        {
            for (int i = 0; i < (val.lItem.Count); i++)
            {
                if (lDesc != null)
                {
                    if (lDesc.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(val.Cd_tabelapreco))
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                                p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
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
                else return true;
            }
            return true;
        }

        private void ConfirmarFin()
        {
            if ((Math.Round(pVl_receber, 2) > Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2)))
                return;
            if (St_ReprocessaFin)//Se for reprocessamento, levar em consideracao o troco
            {
                if (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) < pVl_receber)
                    lPortador.FindLast(p => p.Vl_pagtoPDV > decimal.Zero).Vl_trocoPDV = pVl_receber - (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - pVl_outrosrec);
            }
            if (rCupom != null)
                if (pTot_desconto > decimal.Zero)
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.RatearDescontoVRapida(rCupom, pTot_desconto, decimal.Zero);
            DialogResult = DialogResult.OK;
        }

        private void InformarValor(string portador)
        {
            if (lPortador.Count > 0)
            {
                if (Math.Round(pVl_receber, 2) > Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
                {
                    if (portador.ToUpper().Trim().Equals("CH"))//Cheque
                    {
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
                            fListaCheques.Cd_portador = lPortador.Find(p => p.St_controletitulobool).Cd_portador;
                            fListaCheques.Ds_portador = lPortador.Find(p => p.St_controletitulobool).Ds_portador;
                            fListaCheques.Nm_clifor = pNm_clifor;
                            fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            fListaCheques.Vl_totaltitulo = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fListaCheques.St_bloquearTroco = St_ReprocessaFin;
                            if (fListaCheques.ShowDialog() == DialogResult.OK)
                            {
                                lPortador.Find(p => p.St_controletitulobool).lCheque = fListaCheques.lCheques;
                                lPortador.Find(p => p.St_controletitulobool).Vl_pagtoPDV +=
                                        fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                                CalcularTroco(portador);
                                ConfirmarFin();
                            }
                            else
                            {
                                MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada! ");
                                return;
                            }
                        }
                    }
                    else if (portador.ToUpper().Trim().Equals("CC"))//Cartao Credito
                    {
                        //Buscar dados fatura cartao credito
                        using (TFLanCartaoPDV fCartao = new TFLanCartaoPDV())
                        {
                            fCartao.pCd_empresa = pCd_empresa;
                            fCartao.D_C = "C";
                            fCartao.Vl_saldofaturar = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fCartao.St_bloquearTroco = St_ReprocessaFin;
                            if (fCartao.ShowDialog() == DialogResult.OK)
                            {
                                fCartao.lFatura.ForEach(p => lPortador.Find(x => x.St_cartaocreditobool).lFatura.Add(p));
                                lPortador.Find(p => p.St_cartaocreditobool).Vl_pagtoPDV += fCartao.lFatura.Sum(p => p.Vl_fatura);
                                CalcularTroco(portador);
                                ConfirmarFin();
                            }
                        }
                    }
                    else if (portador.ToUpper().Trim().Equals("CD"))//Cartao Debito
                    {
                        //Buscar dados fatura cartao credito
                        using (TFLanCartaoPDV fCartao = new TFLanCartaoPDV())
                        {
                            fCartao.pCd_empresa = pCd_empresa;
                            fCartao.D_C = "D";
                            fCartao.Vl_saldofaturar = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fCartao.St_bloquearTroco = St_ReprocessaFin;
                            if (fCartao.ShowDialog() == DialogResult.OK)
                            {
                                fCartao.lFatura.ForEach(p => lPortador.Find(x => x.St_cartaocreditobool).lFatura.Add(p));
                                lPortador.Find(p => p.St_cartaocreditobool).Vl_pagtoPDV += fCartao.lFatura.Sum(p => p.Vl_fatura);
                                CalcularTroco(portador);
                                ConfirmarFin();
                            }
                        }
                    }
                    else if (portador.ToUpper().Trim().Equals("DU"))//Duplicata
                    {
                        //Buscar portador duplicata
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lDup =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
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
                        //Verificar credito
                        CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                            new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                        if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(pCd_clifor,
                                                                                                          pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV),
                                                                                                          true,
                                                                                                          ref rDados,
                                                                                                          null))
                            using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                            {
                                fBloq.rDados = rDados;
                                fBloq.Vl_fatura = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                                fBloq.ShowDialog();
                                if (!fBloq.St_desbloqueado)
                                {
                                    MessageBox.Show("Não é permitido realizar venda para cliente com restrição crédito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        //Abrir tela Duplicata
                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                        rDup.Cd_empresa = pCd_empresa;
                        rDup.Nm_empresa = pNm_empresa;
                        rDup.Cd_clifor = pCd_clifor;
                        rDup.Nm_clifor = pNm_clifor;
                        //Buscar cond pagamento
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
                        {
                            rDup.Cd_condpgto = lCond[0].Cd_condpgto;
                            rDup.Qt_parcelas = lCond[0].Qt_parcelas;
                            rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                        }
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
                                pCd_endereco = rDup.Cd_endereco = lEnd[0].Cd_endereco;
                                pDs_endereco = rDup.Ds_endereco = lEnd[0].Ds_endereco;
                            }
                        }
                        rDup.Tp_docto = rCfg.Tp_docto;
                        rDup.Ds_tpdocto = rCfg.Ds_tpdocto;
                        rDup.Tp_duplicata = rCfg.Tp_duplicata;
                        rDup.Ds_tpduplicata = rCfg.Ds_tpduplicata;
                        rDup.Tp_mov = "R";
                        rDup.Cd_historico = rCfg.Cd_historico;
                        rDup.Ds_historico = rCfg.Ds_historico;
                        //Buscar Moeda Padrao
                        CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                            CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
                        if (tabela != null)
                            if (tabela.Count > 0)
                            {
                                rDup.Cd_moeda = tabela[0].Cd_moeda;
                                rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                                rDup.Sigla_moeda = tabela[0].Sigla;
                            }
                        rDup.Id_configBoleto = rCfg.Id_config;
                        rDup.Nr_docto = "PDC123";//pNr_cupom; //Numero Cupom
                        rDup.Dt_emissaostring = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        rDup.Vl_documento = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                        rDup.Vl_documento_padrao = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);

                        rDup.Parcelas.Add(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela()
                        {
                            Cd_parcela = 1,
                            Dt_vencto = lCond.Count > 0 ? rDup.Dt_emissao.Value.AddDays(double.Parse(lCond[0].Qt_diasdesdobro.ToString())) : rDup.Dt_emissao,
                            Vl_parcela = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV),
                            Vl_parcela_padrao = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV)
                        });
                        lPortador.Find(p => p.Tp_portadorpdv.ToUpper().Equals("P")).lDup.Add(rDup);
                        lPortador.Find(p => p.Tp_portadorpdv.ToUpper().Equals("P")).Vl_pagtoPDV = rDup.Vl_documento_padrao;
                        ConfirmarFin();
                    }
                    else if (portador.ToUpper().Trim().Equals("DV"))//Devolucao Credito
                    {
                        //Devolucao de credito
                        using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
                        {
                            fSaldo.Cd_empresa = pCd_empresa;
                            fSaldo.Cd_clifor = pCd_clifor;
                            fSaldo.Vl_financeiro = pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV);
                            fSaldo.Tp_mov = "'R'";
                            if (fSaldo.ShowDialog() == DialogResult.OK)
                            {
                                if (fSaldo.lSaldo != null)
                                {
                                    lPortador.Find(p => p.St_devcreditobool).lCred = fSaldo.lSaldo;
                                    lPortador.Find(p => p.St_devcreditobool).Vl_pagtoPDV =
                                            fSaldo.lSaldo.Sum(p => p.Vl_processar);
                                    CalcularTroco(portador);
                                    ConfirmarFin();
                                }
                            }
                            else
                            {
                                return;
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
                                lPortador.Find(p => !p.St_devcreditobool &&
                                                    !p.St_entregafuturabool &&
                                                    !p.St_controletitulobool &&
                                                    !p.St_cartaocreditobool &&
                                                    !p.St_cartafretebool &&
                                                    !p.Tp_portadorpdv.Equals("P")).Vl_pagtoPDV += fQtde.Quantidade;
                                CalcularTroco(portador);
                                ConfirmarFin();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe mais saldo para receber.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalcularTroco(string portador)
        {
            vl_pago.Text = lPortador.Sum(p => p.Vl_pagtoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (vl_receber.Value >= vl_pago.Value)
                vl_saldo.Text = Math.Abs(pVl_receber - lPortador.Sum(p => p.Vl_pagtoPDV)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (Math.Round(pVl_receber, 2) < Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
            {
                // LabelSaldo.Text = "Valor Troco";
                if (portador.ToUpper().Equals("CH"))
                    lPortador.Find(p => p.St_controletitulobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
                else if (portador.ToUpper().Equals("CC") || portador.ToUpper().Equals("CD"))
                    lPortador.Find(p => p.St_cartaocreditobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
                else if (portador.ToUpper().Equals("DU"))
                    lPortador.Find(p => p.Tp_portadorpdv.Equals("P")).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
                else if (portador.ToUpper().Equals("DV"))
                    lPortador.Find(p => p.St_devcreditobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
                else
                {
                    lPortador.Find(p => !p.St_devcreditobool &&
                                                    !p.St_entregafuturabool &&
                                                    !p.St_controletitulobool &&
                                                    !p.St_cartaocreditobool &&
                                                    !p.St_cartafretebool &&
                                                    !p.Tp_portadorpdv.Equals("P")).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2);
                }
            }
            if (Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - pVl_receber, 2) > 0)
                AbrirGavetaDinheiro();
        }

        private void AbrirGavetaDinheiro()
        {
            if (lPdv != null)
                if (lPdv.Count > 0)
                    if (lPdv[0].St_gavetadinheirobool)
                    {
                        //Buscar porta comunicacao
                        object obj_porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lPdv[0].Cd_terminal.Trim() + "'"
                                                }
                                            }, "a.porta_imptick");
                        if (obj_porta != null)
                            try
                            {
                                Utils.TGavetaDinheiro.AbrirGaveta(obj_porta.ToString(), lPdv[0].CMD_Abrirgaveta);
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro executar comando: " + ex.Message.Trim()); }
                        else MessageBox.Show("Terminal " + lPdv[0].Cd_terminal.Trim() + "-" + lPdv[0].Ds_terminal.Trim() + " não tem porta comunicação configurada.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
        }

        private void TFFecharVendaPDV_Load(object sender, EventArgs e)
        {
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

            if (!string.IsNullOrEmpty(pCd_vendedor))
            {
                lDesc = CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(pCd_vendedor,
                                                                                        pCd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
            }
            //bsPortador.DataSource = lPortador.FindAll(p => p.St_entregafuturabool.Equals(false));
            vl_receber.Text = pVl_receber.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            VL_DESCONTO.Value = pVl_desconto;
            //if (pVl_desconto > decimal.Zero)
            //    pPc_Desconto = decimal.Divide(decimal.Multiply(pVl_desconto,100), pVl_receber + pVl_desconto);

            if (lDesc == null ? true : lDesc.Count.Equals(0))
                label2.Enabled = false;

            //se tem desconto programado nao ativa desconto de vendedor
            if (pVl_desconto > decimal.Zero)
                label2.Enabled = false;
            //if (lPdv != null)
            //    lblAbrirGaveta.Visible = lPdv[0].St_gavetadinheirobool; 
        }

        private void bb_dinheiro_Click(object sender, EventArgs e)
        {
            InformarValor("DH");
        }

        private void bb_cheque_Click(object sender, EventArgs e)
        {
            InformarValor("CH");
        }

        private void bb_duplicata_Click(object sender, EventArgs e)
        {
            InformarValor("DU");
        }

        private void bb_cartaocredito_Click(object sender, EventArgs e)
        {
            InformarValor("CC");
        }

        private void bb_cartaodebito_Click(object sender, EventArgs e)
        {
            InformarValor("CD");
        }

        private void bb_gerarcredito_Click(object sender, EventArgs e)
        {
            InformarValor("DV");
        }

        private void TFFecharVendaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
                InformarValor("DH");
            else if (e.KeyCode.Equals(Keys.F2))
                InformarValor("CH");
            else if (e.KeyCode.Equals(Keys.F3))
                InformarValor("DU");
            else if (e.KeyCode.Equals(Keys.F4))
                InformarValor("CC");
            else if (e.KeyCode.Equals(Keys.F5))
                InformarValor("CD");
            else if (e.KeyCode.Equals(Keys.F6))
                InformarValor("DV");
            else if (e.KeyCode.Equals(Keys.F7) && label2.Enabled)
                InformarDesconto();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
                ConfirmarFin();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InformarDesconto();
        }
    }
}
