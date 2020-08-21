using CamadaDados.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using FormRelPadrao;

namespace PostoCombustivel
{
    public partial class TFLanParcelas : Form
    {
        private CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc
        { get; set; }
        private string pCd_operador
        { get; set; }
        private string pCd_empresa
        { get; set; }
        private string pTp_mov
        { get; set; }
        private string pCd_clifor
        { get; set; }
        private string pCd_moeda
        { get; set; }

        public string Loginpdv
        { get; set; }
        public string Cd_moeda
        { get; set; }
        public decimal? pId_caixaoperacional
        { get; set; }
        public string Cd_contaoperacional
        { get; set; }
        public string Ds_contaoperacional
        { get; set; }
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lCred;

        public TFLanParcelas()
        {
            InitializeComponent();
            Cd_contaoperacional = string.Empty;
            Ds_contaoperacional = string.Empty;
        }

        private string BuscarMoedaPadrao(string pCd_empresa)
        {
            CamadaDados.Financeiro.Cadastros.TList_Moeda tb_moeda = 
                CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
            if (tb_moeda != null)
                if (tb_moeda.Count > 0)
                    return tb_moeda[0].Cd_moeda;
                else
                    return string.Empty;
            else
                return string.Empty;
        }

        private bool VerificarTotDesconto(decimal tot_desconto)
        {
            if (lDesc.Count > 0)
            {
                //Desconto por vendedor e empresa
                decimal pc_descontoOp = tot_desconto * 100 / vl_totatual.Value;
                if (pc_descontoOp > lDesc[0].Pc_max_desconto)
                {
                    MessageBox.Show("Usuário está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                    {
                        fLogin.Cd_empresa = CD_Empresa.Text;
                        fLogin.Pc_desc = pc_descontoOp;
                        if (fLogin.ShowDialog() != DialogResult.OK)
                            return false;
                        else
                            return true;
                    }
                }
                else return true;
            }
            else
            {
                vl_desconto.Enabled = false;
                return true;
            }
        }

        private void DevolverCredito()
        {
            lCred = null;
            vl_adtodevolver.Value = decimal.Zero;
            using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
            {
                fSaldo.Cd_empresa = CD_Empresa.Text;
                fSaldo.Cd_clifor = CD_Clifor.Text;
                fSaldo.Vl_financeiro = vl_totliquidar.Value - vl_desconto.Value;
                fSaldo.Tp_mov = rbPagar.Checked ? "'C'" : "'R'";
                if (fSaldo.ShowDialog() == DialogResult.OK)
                    if (fSaldo.lSaldo != null)
                    {
                        lCred = fSaldo.lSaldo;
                        vl_adtodevolver.Value = lCred.Sum(p => p.Vl_processar);
                    }
            }
            //Calcular Total Liquido
            tot_liquido.Value = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Tipo Movimento
            filtro[0].vNM_Campo = "a.tp_mov";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = rbPagar.Checked ? "'P'" : "'R'";
            //Status Parcela
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "in";
            filtro[1].vVL_Busca = "('A', 'P')";
            //Cliente
            filtro[2].vNM_Campo = "a.cd_clifor";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            //Status da Duplicata
            filtro[3].vNM_Campo = "isnull(dup.st_registro, 'A')";
            filtro[3].vOperador = "<>";
            filtro[3].vVL_Busca = "'C'";
            //Verificar se usuario tem acesso a empresa
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vOperador = "exists";
            filtro[4].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Empresa x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.login = '" + Loginpdv.Trim() + "') "; 
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(NR_Docto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_Docto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_cupomfiscal.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_cupomfiscal.Text;
            }
            if(DT_Inicial.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
            }
            if(DT_Final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(placa.Text.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                      "inner join TB_PDC_VendaCombustivel y " +
                                                      "on x.CD_Empresa = y.CD_Empresa " +
                                                      "and x.Id_Cupom = y.Id_Cupom " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.Nr_Lancto = a.Nr_Lancto " +
                                                      "and REPLACE(y.PlacaVeiculo, '-', '') = '" + placa.Text.Replace("-", "") + "')";
            }
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(filtro, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (bsParcelas.Count > 0)
            {
                //Buscar Historico Cliente
                TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor.Text, null);
                if (rClifor != null)
                {
                    if (rbPagar.Checked && !string.IsNullOrEmpty(rClifor.Cd_historicopag))
                    {
                        cd_historico.Text = rClifor.Cd_historicopag;
                        ds_historico.Text = rClifor.Ds_historicopag;
                    }
                    if (rbReceber.Checked && !string.IsNullOrEmpty(rClifor.Cd_historicorec))
                    {
                        cd_historico.Text = rClifor.Cd_historicorec;
                        ds_historico.Text = rClifor.Ds_historicorec;
                    }
                }
                if (string.IsNullOrWhiteSpace(cd_historico.Text))
                {
                    object obj = new TCD_CadHistorico().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_Historico",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsParcelas[0] as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_historico.Trim() + "'"
                                    }
                                    }, "a.cd_Historico_Quitacao");
                    if (obj != null)
                    {
                        cd_historico.Text = obj.ToString();
                        cd_historico_Leave(this, new EventArgs());
                    }
                }
            }
            lCred = null;
            RecalcularParcelas();
            vl_totatual.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p=> p.cVl_atual);
            
            vl_totliquidar.Value = decimal.Zero;
            cbTodos.Checked = false;
        }

        private void afterLiquidar()
        {
            if ((bsParcelas.Count > 0) && (bsPortador.Current != null) && (vl_totliquidar.Value > decimal.Zero))
            {
                if (vl_desconto.Focused)
                    vl_desconto_Leave(this, new EventArgs());
                decimal saldo = vl_totliquidar.Value;
                decimal juro = decimal.Zero;
                List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParc = new List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela>();
                (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar).OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                    {
                        if (saldo > decimal.Zero)
                        {
                            if (p.cVl_atual < saldo)
                                juro += p.Vl_juro;
                            else if (p.cVl_atual - p.Vl_juro < saldo)
                                juro += saldo - (p.cVl_atual - p.Vl_juro);
                            lParc.Add(p);
                            saldo -= p.cVl_atual;
                        }
                    });
                if(saldo > decimal.Zero)
                    juro += saldo;
                lParc = lParc.OrderBy(p=> p.Dt_vencto).ToList();
                if (lParc.Count > 0)
                {
                    //Verificar empresa para liquidacao
                    string emp = lParc[0].Cd_empresa.Trim();
                    if (!lParc.Exists(p => p.Cd_empresa.Trim().Equals(emp.Trim())))
                    {
                        MessageBox.Show("Não é permitido liquidar duplicata de empresas diferentes.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if(lCred == null)
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", emp, null).Trim().ToUpper().Equals("S"))
                            if (CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                                 emp,
                                                                                                 CD_Clifor.Text,
                                                                                                 string.Empty,
                                                                                                 "'R'",
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 false,
                                                                                                 false,
                                                                                                 true,
                                                                                                 string.Empty,
                                                                                                 false,
                                                                                                 true,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 0,
                                                                                                 string.Empty,
                                                                                                 null).Count > 0)
                                DevolverCredito();
                    //Criar Liquidacao
                    CamadaDados.Financeiro.Duplicata.TRegistro_LanLiquidacao rLiquidacao = new CamadaDados.Financeiro.Duplicata.TRegistro_LanLiquidacao();
                    rLiquidacao.cVl_Nominal = lParc.Sum(p => p.Vl_parcela);
                    rLiquidacao.cVl_Liquidado = lParc.Sum(p => p.Vl_liquidado);
                    rLiquidacao.cVl_Atual = lParc.Sum(p => p.Vl_atual);
                    rLiquidacao.cVl_JuroTotal = juro;
                    rLiquidacao.cVl_DescontoTotal = lParc.Sum(p => p.Vl_DescLiquid);
                    rLiquidacao.Vl_difcamb_at = lParc.Sum(p => p.cVl_DifCamb_Ativa);
                    rLiquidacao.Vl_difcamb_pa = lParc.Sum(p => p.cVl_DifCamb_Passiva);
                    rLiquidacao.Id_caixaoperacional = pId_caixaoperacional;
                    rLiquidacao.Cvl_aliquidar_padrao = vl_totliquidar.Value;
                    rLiquidacao.cVl_descontoconcedido = vl_desconto.Value;
                    rLiquidacao.cVl_adiantamento = vl_adtodevolver.Value;
                    rLiquidacao.Cd_empresa = lParc[0].Cd_empresa;
                    rLiquidacao.Cd_historico = cd_historico.Text;
                    rLiquidacao.Cd_portador = (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Cd_portador;
                    rLiquidacao.Cd_historico_desc = lParc[0].Cd_historico_desconto;
                    rLiquidacao.Cd_historico_juro = lParc[0].Cd_historico_juro;
                    rLiquidacao.Cd_historico_trocoCH = lParc[0].Cd_historico_troco;
                    rLiquidacao.Cd_contager = Cd_contaoperacional;
                    rLiquidacao.Cd_clifor = lParc.First(p=> !string.IsNullOrEmpty(p.Cd_clifor)).Cd_clifor;
                    rLiquidacao.Nr_docto = lParc[0].Nr_docto;
                    rLiquidacao.Nr_lancto = lParc[0].Nr_lancto;
                    rLiquidacao.Tp_mov = rbReceber.Checked ? "R" : "P";
                    rLiquidacao.Dt_Liquidacao = CamadaDados.UtilData.Data_Servidor();
                    //Lista de creditos devolver
                    rLiquidacao.lCred = lCred;
                    //Se portador Cheque
                    if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_controletitulobool &&
                        ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) > decimal.Zero))
                    {
                        CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                        if(CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(CD_Clifor.Text,
                                                                                                         decimal.Zero,
                                                                                                         false,
                                                                                                         ref rDados,
                                                                                                         null))
                            using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                            {
                                fBloq.St_liquidacao = true;
                                fBloq.rDados = rDados;
                                fBloq.Vl_fatura = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                                fBloq.ShowDialog();
                                if (!fBloq.St_desbloqueado)
                                    return;
                            }
                        CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
                        using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                        {
                            if (rbPagar.Checked)
                            {
                                string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
                                string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                                    "where x.cd_contager = a.cd_contager " +
                                                    "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                                    "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                                    "where k.CD_ContaGer = a.CD_ContaGer " +
                                                    "and k.cd_Empresa = '" + lParc[0].Cd_empresa + "' );" +
                                                    "a.st_contaCF|=|1;" +
                                                    "ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
                                if (linha != null)
                                {
                                    fListaCheques.Cd_contager = linha["cd_contager"].ToString();
                                    fListaCheques.Ds_contager = linha["ds_contager"].ToString();
                                    rLiquidacao.Cd_contager = linha["cd_contager"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio selecionar conta gerencial para emitir cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                fListaCheques.Cd_contager = Cd_contaoperacional;
                                fListaCheques.Ds_contager = Ds_contaoperacional;
                            }
                            fListaCheques.Tp_mov = rbReceber.Checked ? "R" : "P";
                            fListaCheques.Cd_empresa = lParc[0].Cd_empresa;
                            fListaCheques.Cd_clifor = lParc[0].Cd_clifor;
                            fListaCheques.Cd_historico = cd_historico.Text;
                            fListaCheques.Ds_historico = ds_historico.Text;
                            fListaCheques.Cd_portador = (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Cd_portador;
                            fListaCheques.Ds_portador = (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Ds_portador;
                            fListaCheques.Nm_clifor = lParc[0].Nm_clifor;
                            fListaCheques.Dt_emissao = rLiquidacao.Dt_Liquidacao;
                            fListaCheques.Vl_totaltitulo = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                            fListaCheques.St_bloquearTroco = false;
                            if ((fListaCheques.ShowDialog() == DialogResult.OK) &&
                                (fListaCheques.lCheques.Count > 0))
                            {
                                lCheques = fListaCheques.lCheques;
                                if ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) <
                                    fListaCheques.lCheques.Sum(p => p.Vl_titulo))
                                {
                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                    {
                                        fTroco.Cd_empresa = emp;
                                        fTroco.Id_caixaPDV = pId_caixaoperacional.HasValue ? pId_caixaoperacional.Value.ToString() : string.Empty;
                                        if (fListaCheques.lCheques.Sum(p => p.Vl_titulo) - vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value < 0)
                                            fTroco.Vl_troco = (fListaCheques.lCheques.Sum(p => p.Vl_titulo) - vl_totliquidar.Value - vl_desconto.Value + vl_adtodevolver.Value);
                                        else fTroco.Vl_troco = (fListaCheques.lCheques.Sum(p => p.Vl_titulo) - (vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value));
                                        fTroco.Cd_historioTroco = cd_historico.Text;
                                        fTroco.Ds_historicoTroco = ds_historico.Text;
                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Loginpdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                        {
                                            rLiquidacao.Vl_trocoDH = fTroco.Vl_trocoDinheiro;
                                            if (fTroco.lChTroco != null)
                                            {
                                                rLiquidacao.Vl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                                fTroco.lChTroco.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                            }
                                            if (fTroco.lChRepasse != null)
                                            {
                                                rLiquidacao.Vl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                                fTroco.lChRepasse.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                            }
                                            rLiquidacao.Vl_adto = fTroco.Vl_trocoCredito;
                                            rLiquidacao.St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada!");
                                return;
                            }
                        }
                        //Gravar liquidacao
                        Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio do processo gravar liquidação...");
                        try
                        {
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.GravarLiquidacao(lParc,
                                                                                                  rLiquidacao,
                                                                                                  lCheques,
                                                                                                  null,
                                                                                                  null,
                                                                                                  tEspera,
                                                                                                  null);
                            MessageBox.Show("Liquidação Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vl_desconto.Value = decimal.Zero;
                            lCred = null;
                            vl_adtodevolver.Value = decimal.Zero;
                            cd_historico.Clear();
                            ds_historico.Clear();
                            //Chamar tela de impressao para o cheque
                            //somente se for contas a pagar e for com cheque
                            try
                            {
                                if (rbPagar.Checked && lCheques.Count > 0)
                                    if (MessageBox.Show("Imprimir cheques emitidos?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        try
                                        {
                                            CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(lCheques);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Erro imprimir lista de cheques: " + ex.Message.Trim());
                            }
                            try
                            {
                                //Impressao do recibo
                                string referente = string.Empty;
                                string virg = string.Empty;
                                lParc.ForEach(p =>
                                {
                                    referente += virg + p.Nr_docto.Trim() + "/" + p.Cd_parcelastr + (p.St_registro.Trim().ToUpper().Equals("P") ? "(PARCIAL)" : string.Empty);
                                    virg = ", ";
                                });
                                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                   new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                       rLiquidacao);
                                }
                                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                       rLiquidacao);
                                }
                                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                                  referente,
                                                                                  rLiquidacao,
                                                                                  CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(lParc[0].Cd_empresa,
                                                                                                                                            lParc[0].Nr_lancto.ToString(),
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
                                                                                                                                            null));
                                }
                                else
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                                  referente,
                                                                                  rLiquidacao,
                                                                                  CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(lParc[0].Cd_empresa,
                                                                                                                                            lParc[0].Nr_lancto.ToString(),
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
                                                                                                                                            null));
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Erro imprimir recibos liquidação com cheques: " + ex.Message.Trim());
                            }
                            finally
                            { afterBusca(); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            tEspera.Fechar();
                            tEspera = null;
                        }
                    }
                    else 
                    {
                        CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
                        CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete = new CamadaDados.PostoCombustivel.TList_CartaFrete();
                        if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_cartaocreditobool &&
                        ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) > decimal.Zero))
                        {
                            using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                            {
                                if (fD_C.ShowDialog() == DialogResult.OK)
                                    //Buscar dados fatura cartao credito
                                    using (Financeiro.TFFaturaCartao fFatura = new Financeiro.TFFaturaCartao())
                                    {
                                        fFatura.Cd_empresa = lParc[0].Cd_empresa;
                                        fFatura.Tp_movimento = "R";
                                        fFatura.Dt_fatura = rLiquidacao.Dt_Liquidacao;
                                        fFatura.Vl_nominal = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                                        fFatura.Vl_juro = decimal.Zero;
                                        fFatura.D_C = fD_C.D_C;
                                        if (fFatura.ShowDialog() == DialogResult.OK)
                                            if (fFatura.lFatura != null)
                                            {
                                                lFatura = fFatura.lFatura;
                                                if ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) <
                                                    lFatura.Sum(p => p.Vl_fatura))
                                                {
                                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                                    {
                                                        fTroco.Cd_empresa = emp;
                                                        fTroco.Id_caixaPDV = pId_caixaoperacional.HasValue ? pId_caixaoperacional.Value.ToString() : string.Empty;
                                                        fTroco.Vl_troco = lFatura.Sum(p => p.Vl_juro);
                                                        fTroco.Cd_historioTroco = cd_historico.Text;
                                                        fTroco.Ds_historicoTroco = ds_historico.Text;
                                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Loginpdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                        if (fTroco.ShowDialog() == DialogResult.OK)
                                                        {
                                                            rLiquidacao.Vl_trocoDH = fTroco.Vl_trocoDinheiro;
                                                            if (fTroco.lChTroco != null)
                                                            {
                                                                rLiquidacao.Vl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                                                fTroco.lChTroco.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                            }
                                                            if (fTroco.lChRepasse != null)
                                                            {
                                                                rLiquidacao.Vl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                                                fTroco.lChRepasse.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                            }
                                                            rLiquidacao.Vl_adto = fTroco.Vl_trocoCredito;
                                                            rLiquidacao.St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Fatura cartão não foi lançada.\r\nLiquidação não sera efetivada.");
                                                return;
                                            }
                                        else
                                        {
                                            MessageBox.Show("Fatura cartão não foi lançada.\r\nLiquidação não sera efetivada.");
                                            return;
                                        }
                                    }
                            }
                        }
                        else if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_cartafretebool &&
                        ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) > decimal.Zero))
                            using(PDV.TFLanListaCartaFrete fLista = new PDV.TFLanListaCartaFrete())
                            {
                                fLista.Cd_empresa = lParc[0].Cd_empresa;
                                fLista.Nm_empresa = lParc[0].Nm_empresa;
                                fLista.Vl_totaltitulo = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (fLista.lCarta != null)
                                    {
                                        lCartaFrete = fLista.lCarta;
                                        if ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) <
                                            lCartaFrete.Sum(p=> p.Vl_documento))
                                        {
                                            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                            {
                                                fTroco.Cd_empresa = emp;
                                                fTroco.Id_caixaPDV = pId_caixaoperacional.HasValue ? pId_caixaoperacional.Value.ToString() : string.Empty;
                                                fTroco.Vl_troco = lCartaFrete.Sum(p => p.Vl_documento) - (vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value);
                                                fTroco.Cd_historioTroco = cd_historico.Text;
                                                fTroco.Ds_historicoTroco = ds_historico.Text;
                                                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Loginpdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                if (fTroco.ShowDialog() == DialogResult.OK)
                                                {
                                                    rLiquidacao.Vl_trocoDH = fTroco.Vl_trocoDinheiro;
                                                    if (fTroco.lChTroco != null)
                                                    {
                                                        rLiquidacao.Vl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                                        fTroco.lChTroco.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                    }
                                                    if (fTroco.lChRepasse != null)
                                                    {
                                                        rLiquidacao.Vl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                                        fTroco.lChRepasse.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                    }
                                                    rLiquidacao.Vl_adto = fTroco.Vl_trocoCredito;
                                                    rLiquidacao.St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar carta frete para gravar liquidação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar carta frete para gravar liquidação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        else if  ((vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value) > decimal.Zero)
                            using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                            {
                                fValor.Ds_label = "Valor Informado";
                                fValor.Vl_default = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                                fValor.Casas_decimais = 2;
                                fValor.Vl_Minimo = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
                                if (fValor.ShowDialog() == DialogResult.OK)
                                {
                                    if (fValor.Quantidade > (vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value))
                                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                        {
                                            fTroco.Cd_empresa = emp;
                                            fTroco.Id_caixaPDV = pId_caixaoperacional.HasValue ? pId_caixaoperacional.Value.ToString() : string.Empty;
                                            fTroco.Vl_troco = fValor.Quantidade - (vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value);
                                            fTroco.Cd_historioTroco = cd_historico.Text;
                                            fTroco.Ds_historicoTroco = ds_historico.Text;
                                            fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Loginpdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                            if (fTroco.ShowDialog() == DialogResult.OK)
                                            {
                                                rLiquidacao.Vl_trocoDH = fTroco.Vl_trocoDinheiro;
                                                if (fTroco.lChTroco != null)
                                                {
                                                    rLiquidacao.Vl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                                    fTroco.lChTroco.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                }
                                                if (fTroco.lChRepasse != null)
                                                {
                                                    rLiquidacao.Vl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                                    fTroco.lChRepasse.ForEach(p => rLiquidacao.lChTroco.Add(p));
                                                }
                                                rLiquidacao.Vl_adto = fTroco.Vl_trocoCredito;
                                                rLiquidacao.St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }

                                        }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar valor para Liquidar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        //Gravar liquidacao
                        Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio do processo gravar liquidação...");
                        try
                        {
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.GravarLiquidacao(lParc,
                                                                                                  rLiquidacao,
                                                                                                  null,
                                                                                                  lFatura,
                                                                                                  lCartaFrete,
                                                                                                  tEspera,
                                                                                                  null);
                            MessageBox.Show("Liquidação Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vl_desconto.Value = decimal.Zero;
                            lCred = null;
                            vl_adtodevolver.Value = decimal.Zero;
                            cd_historico.Clear();
                            ds_historico.Clear();
                            try
                            {
                                //Impressao do recibo
                                string referente = string.Empty;
                                string virg = string.Empty;
                                lParc.ForEach(p =>
                                {
                                    referente += virg + p.Nr_docto.Trim() + "/" + p.Cd_parcelastr + (p.St_registro.Trim().ToUpper().Equals("P") ? "(PARCIAL)" : string.Empty);
                                    virg = ", ";
                                });
                                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                   new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                       rLiquidacao);
                                }
                                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                       rLiquidacao);
                                }
                                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                                  referente,
                                                                                  rLiquidacao,
                                                                                  CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(lParc[0].Cd_empresa,
                                                                                                                                            lParc[0].Nr_lancto.ToString(),
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
                                                                                                                                            null));
                                }
                                else
                                {
                                    FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                                  referente,
                                                                                  rLiquidacao,
                                                                                  CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(lParc[0].Cd_empresa,
                                                                                                                                            lParc[0].Nr_lancto.ToString(),
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
                                                                                                                                            null));
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Erro imprimir recibos liquidação com cheques: " + ex.Message.Trim());
                            }
                            finally
                            { afterBusca(); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            tEspera.Fechar();
                            tEspera = null;
                        }
                    }
                }
            }
        }

        private void RecalcularParcelas()
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela>).ForEach(p =>
                {
                    System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
                    hs.Add("@P_CD_EMPRESA", p.Cd_empresa);
                    hs.Add("@P_NR_LANCTO", p.Nr_lancto);
                    hs.Add("@P_CD_PARCELA", p.Cd_parcela);
                    hs.Add("@P_DATA_ATUAL", CamadaDados.UtilData.Data_Servidor());
                    hs.Add("@P_ST_CALCMOEDAPADRAO", "N");
                    try
                    {
                        p.Vl_atual = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(new CamadaDados.TDataQuery().executarProc("STP_FIN_CALC_ATUAL", hs), "@@VL_RET"));
                        p.cVl_atual = p.Vl_atual;
                    }
                    catch
                    { }
                });
                bsParcelas.ResetBindings(true);
            }
        } 
        
        private void BuscarPortador()
        {
            bsPortador.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_portadorPDV",
                                            vOperador = "=",
                                            vVL_Busca = "'A'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_tituloterceiro, 'N')",
                                            vOperador = rbReceber.Checked ?  "<>" : "in",
                                            vVL_Busca = rbReceber.Checked ? "'S'" : "('S', 'N')"
                                        }
                                    }, 0, string.Empty, "ordem");
        }  

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar)
                {
                    (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar = false;
                    if (!(bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Exists(p => p.St_processar))
                    {
                        pCd_empresa = string.Empty;
                        pTp_mov = string.Empty;
                        pCd_moeda = string.Empty;
                        pCd_clifor = string.Empty;
                    }
                }
                else
                {
                    if (!(bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Exists(p => p.St_processar))
                    {
                        pCd_empresa = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_empresa;
                        pTp_mov = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Tp_mov;
                        pCd_moeda = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_moeda;
                        pCd_clifor = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_clifor;
                        (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar = true;
                    }
                    else if ((bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_empresa.Trim().Equals(pCd_empresa.Trim()) &&
                            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_clifor.Trim().Equals(pCd_clifor.Trim()) &&
                            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_moeda.Trim().Equals(pCd_moeda.Trim()) &&
                            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Tp_mov.Trim().Equals(pTp_mov.Trim()))
                    {
                        (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar = true;
                        bsParcelas.ResetCurrentItem();
                    }
                    else
                        MessageBox.Show("Permitido liquidar somente contas que sejam da mesma empresa, clifor, moeda e tipo de movimento.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                vl_totliquidar.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
                vl_totatual.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
                vl_totjuro.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar && p.Vl_juro > decimal.Zero).Sum(p => p.Vl_juro);
            }
        }

        private void BB_Liquidar_Click(object sender, EventArgs e)
        {
            afterLiquidar();
        }

        private void TFLanParcelas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                afterLiquidar();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void TFLanParcelas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            vl_totliquidar.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR LIQUIDAÇÃO PARCIAL", null);
            vl_adtodevolver.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR INFORMAR VALOR DEVOLUCAO ADIANTAMENTO", null);

            //Buscar Portador
            BuscarPortador();
            BB_Clifor_Click(this, new EventArgs());
            //Buscar Codigo Operador amarrado ao login
            object obj_operador =
            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.loginvendedor",
                        vOperador = "=",
                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                    }
                }, "a.cd_clifor");
            if (obj_operador != null)
                pCd_operador = obj_operador.ToString();
            else
                vl_desconto.Enabled = false;

            if (!string.IsNullOrEmpty(pCd_operador))
            {
                lDesc =
                  CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(pCd_operador,
                                                                                  CD_Empresa.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                afterBusca();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                afterBusca();
        }

        private void gParcelas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gParcelas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsParcelas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela());
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sort(lComparer);
            bsParcelas.ResetBindings(false);
            gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
                if (cbTodos.Checked)
                {
                    (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p =>
                        {
                            if (string.IsNullOrEmpty(pCd_empresa))
                            {
                                pCd_empresa = p.Cd_empresa;
                                pTp_mov = p.Tp_mov;
                                pCd_moeda = p.Cd_moeda;
                                pCd_clifor = p.Cd_clifor;
                                p.St_processar = true;
                            }
                            else if (p.Cd_empresa.Trim().Equals(pCd_empresa.Trim()) &&
                                p.Tp_mov.Trim().Equals(pTp_mov.Trim()) &&
                                p.Cd_moeda.Trim().Equals(pCd_moeda.Trim()) &&
                                p.Cd_clifor.Trim().Equals(pCd_clifor.Trim()))
                                p.St_processar = true;
                        });
                    bsParcelas.ResetBindings(true);
                    vl_totliquidar.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
                    vl_totatual.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
                    vl_totjuro.Value = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar && p.Vl_juro > decimal.Zero).Sum(p => p.Vl_juro);
                }
                else
                {
                    (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = false);
                    bsParcelas.ResetBindings(true);
                    vl_totliquidar.Value = decimal.Zero;
                    vl_totjuro.Value = decimal.Zero;
                    vl_totatual.Value = decimal.Zero;
                }
        }

        private void vl_totliquidar_Enter(object sender, EventArgs e)
        {
            vl_totliquidar.Value = vl_totatual.Value;
            vl_totliquidar.Select(0, vl_totliquidar.ToString().Trim().Length);
        }

        private void vl_totliquidar_Leave(object sender, EventArgs e)
        {
            lCred = null;
            vl_adtodevolver.Value = decimal.Zero;
            tot_liquido.Value = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
        }

        private void vl_desconto_Enter(object sender, EventArgs e)
        {
            vl_desconto.Select(0, vl_desconto.ToString().Trim().Length);
        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if (!VerificarTotDesconto(vl_desconto.Value))
            {
                vl_desconto.Value = decimal.Zero;
                vl_desconto.Focus();
            }
            lCred = null;
            vl_adtodevolver.Value = decimal.Zero;
            if (vl_desconto.Value > vl_totliquidar.Value)
                vl_desconto.Value = vl_totliquidar.Value;
            tot_liquido.Value = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|" + (rbReceber.Checked ? "'R'" : "'P'");
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text.Trim() + "';" +
                               "a.TP_Mov|=|" + (rbReceber.Checked ? "'R'" : "'P'");
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void rbPagar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPagar.Checked)
            {
                lblClifor.Text = "Fornecedor:";
                lblValor.Text = "Valor Pagar:";
                BuscarPortador();
            }
        }

        private void rbReceber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReceber.Checked)
            {
                lblClifor.Text = "Cliente:";
                lblValor.Text = "Valor Receber:";
                BuscarPortador();
            }
        }

        private void rbPagar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void rbReceber_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLanParcelas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }

        private void bb_devcredito_Click(object sender, EventArgs e)
        {
            //Devolucao de credito
            DevolverCredito();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_liquido.Value = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
        }

        private void vl_totliquidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tot_liquido.Value = vl_totliquidar.Value - vl_desconto.Value - vl_adtodevolver.Value;
        }

        private void tot_liquido_ValueChanged(object sender, EventArgs e)
        {
            if (tot_liquido.Value != vl_totatual.Value)
            {
                labelAberto.Visible = true;
                lblEmAberto.Text = (vl_totatual.Value - tot_liquido.Value).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            }
            else
            {
                labelAberto.Visible = false;
                lblEmAberto.Text = string.Empty;
            }
        }

        private void bbImpDuplicata_Click(object sender, EventArgs e)
        {
            ImprimirDuplicata("D");
        }

        private void ImprimirDuplicata(string Layout)
        {
            if (bsParcelas.Current != null)
            {
                //Buscar parcela
                TList_RegLanDuplicata lDup =
                    TCN_LanDuplicata.Busca((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                           (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr,
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
                                           true,
                                           0,
                                           string.Empty,
                                           null);
                lDup[0].Parcelas =
                    new TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lDup[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = "" + lDup[0].Nr_lancto + ""
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lDup.Count > 0)
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        //Buscar dados Empresa
                        CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                            TCN_CadEmpresa.Busca(lDup[0].Cd_empresa,
                                                 string.Empty,
                                                 string.Empty,
                                                 null);
                        //Buscar dados do sacado
                        TList_CadClifor lSacado = TCN_CadClifor.Busca_Clifor(lDup[0].Cd_clifor,
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
                            lSacado[0].lEndereco = TCN_CadEndereco.Buscar(lDup[0].Cd_clifor,
                                                                          lDup[0].Cd_endereco,
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
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lDup[0].Cd_clifor;
                        if (Layout.Trim().ToUpper().Equals("C"))
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = false;
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
                            bs_parc.DataSource = lDup[0].Parcelas;
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
                            fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto;

                            if (Rel.Altera_Relatorio)
                            {
                                Rel.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   null,
                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                   fImp.pDs_mensagem);
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
                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                   fImp.pDs_mensagem);
                        }
                        else
                        {
                            fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lDup[0].Nr_docto;
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            {
                                TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                      lDup[0].Parcelas.FindAll(p => p.Cd_parcela == (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela),
                                                                      lEmpresa,
                                                                      lSacado,
                                                                      fImp.pSt_imprimir,
                                                                      fImp.pSt_visualizar,
                                                                      fImp.pSt_exportPdf,
                                                                      fImp.Path_exportPdf,
                                                                      fImp.pSt_enviaremail,
                                                                      fImp.pDestinatarios,
                                                                      "DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                                      fImp.pDs_mensagem);
                            }
                        }
                    }
            }
        }

    }
}
