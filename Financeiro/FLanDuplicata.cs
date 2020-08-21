using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaNegocio.ConfigGer;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.CCustoLan;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFLanDuplicata : Form
    {
        public string nr_lancto { get; set; }
        private TTpModo TPModo = TTpModo.tm_Standby;
        private string pCd_historicopag = string.Empty;
        private string pDs_historicopag = string.Empty;
        private string pCd_historicorec = string.Empty;
        private string pDs_historicorec = string.Empty;

        public string vId_caixa = string.Empty;
        public string vCd_centroresult = string.Empty;
        public string vDs_observacao = string.Empty;
        public string vId_configBoleto = string.Empty;
        public string vCd_contagerliq = string.Empty;
        public string vDs_configBoleto = string.Empty;
        public bool vSt_alterar = false;
        public bool vSt_notafiscal = false;
        public bool vSt_ctrc = false;
        public bool vSt_ecf = false;
        public bool vSt_agrupar = false;
        public bool vSt_finPed = false;
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vCd_clifor = string.Empty;
        public string vNm_clifor = string.Empty;
        public string vCd_endereco = string.Empty;
        public string vDs_endereco = string.Empty;
        public string vCd_historico = string.Empty;
        public string vDs_historico = string.Empty;
        public string vTp_duplicata = string.Empty;
        public string vDs_tpduplicata = string.Empty;
        public string vTp_mov = string.Empty;
        public string vTp_docto = string.Empty;
        public string vDs_tpdocto = string.Empty;
        public string vCd_condpgto = string.Empty;
        public string vDs_condpgto = string.Empty;
        public string vSt_comentrada = string.Empty;
        public string vCd_juro = string.Empty;
        public string vDs_juro = string.Empty;
        public string vTp_juro = string.Empty;
        public string vCd_moeda = string.Empty;
        public string vDs_moeda = string.Empty;
        public string vSigla_moeda = string.Empty;
        public string vCd_moeda_padrao = string.Empty;
        public string vDs_moeda_padrao = string.Empty;
        public string vSigla_moeda_padrao = string.Empty;
        public decimal vQt_dias_desdobro = decimal.Zero;
        public decimal vQt_parcelas = decimal.Zero;
        public decimal vPc_jurodiario_atrazo = 0;
        public string vCd_portador = string.Empty;
        public string vDs_portador = string.Empty;
        public bool vSt_solicitardtvencto = false;
        public string vNr_docto = string.Empty;
        public string vDt_emissao = string.Empty;
        public decimal vVl_documento = decimal.Zero;
        public decimal? vNr_pedido = null;
        public TList_RegLanParcela lParc
        { get; set; } = new TList_RegLanParcela();

        private bool st_lancarcheque = false;
        private bool st_cartaocredito = false;
        private bool st_solicitardtvencto = false;
        private bool st_rateioparcelas = false;
        public bool st_habilitaralterarvalor = false;
        public bool St_empreendimento = false;
        public bool St_bloquearccusto = false;
        public bool St_editardataemissao = false;

        public TFLanDuplicata()
        {
            InitializeComponent();
        }

        private void DevolverCredito()
        {
            //Devolucao de credito
            if (dsDuplicata.Current != null)
            {
                (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
                (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
                using (TFSaldoCreditos fSaldo = new TFSaldoCreditos())
                {
                    fSaldo.Cd_empresa = cd_empresa.Text;
                    fSaldo.Cd_clifor = cd_clifor.Text;
                    fSaldo.Vl_financeiro = vl_documento_index.Value - vl_entrada_padrao.Value;
                    fSaldo.Tp_mov = (dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("P") ? "'C'" : "'R'";
                    if (fSaldo.ShowDialog() == DialogResult.OK)
                        if (fSaldo.lSaldo != null)
                        {
                            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = fSaldo.lSaldo;
                            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                        }
                }
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void PreparaBotoes(TTpModo pModo)
        {
            if (pModo == TTpModo.tm_Standby)
            {
                BB_Novo.Visible = true;
                BB_Cancelar.Visible = false;
                BB_Gravar.Visible = false;
            }
            else if (pModo == TTpModo.tm_Insert)
            {
                BB_Novo.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = true;
            }
            else if (pModo == TTpModo.tm_Edit)
            {
                BB_Novo.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = true;
            }
            else if (pModo == TTpModo.tm_busca)
            {
                BB_Novo.Visible = true;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = false;
            }
        }

        private void HabilitarCampos(bool valor)
        {
            cd_empresa.Enabled = valor;
            bb_empresa.Enabled = valor;
            cd_clifor.Enabled = valor;
            bb_clifor.Enabled = valor;
            cd_endereco.Enabled = valor;
            bb_endereco.Enabled = valor;
            tp_duplicata.Enabled = valor;
            bb_tpduplicata.Enabled = valor;
            tp_docto.Enabled = valor;
            bb_tpdocto.Enabled = valor;
            cd_condpgto.Enabled = valor;
            bb_condpgto.Enabled = valor;
            cd_juro.Enabled = valor;
            bb_juro.Enabled = valor;
            cd_moeda.Enabled = valor;
            bb_moeda.Enabled = valor;
            cd_moeda_padrao.Enabled = valor;
            bb_moedapadrao.Enabled = valor;
            cd_portador.Enabled = valor;
            bb_portador.Enabled = valor;
            Vl_desconto.Enabled = valor;
            pc_desconto.Enabled = valor;
            cd_contager.Enabled = valor;
            bb_contager.Enabled = valor;
            cd_historico.Enabled = valor;
            bb_historico.Enabled = valor;
            cd_historico_dup.Enabled = valor;
            bb_historico_dup.Enabled = valor;
            complhistorico.Enabled = valor;
            nr_docto.Enabled = valor;
            dt_emissao.Enabled = valor;
            vl_documento_index.Enabled = valor;
            vl_entrada.Enabled = valor;
            ds_observacao.Enabled = valor;
            pCobranca.Enabled = valor;
            bbAddClifor.Enabled = valor;
        }

        private void afterNovo()
        {
            TPModo = TTpModo.tm_Insert;
            PreparaBotoes(TPModo);
            HabilitarCampos(true);
            dsDuplicata.AddNew();
        }

        private void afterCancela()
        {
            if (Tag == null ? false : !Tag.ToString().Trim().ToUpper().Equals("S"))
                DialogResult = DialogResult.Cancel;
            else
            {
                TPModo = TTpModo.tm_Standby;
                PreparaBotoes(TPModo);
                HabilitarCampos(false);
                dsDuplicata.Clear();
            }
        }

        private void preencherCampos()
        {
            dsDuplicata.AddNew();
            cd_empresa.Text = vCd_empresa;
            if (cd_empresa.Text.Trim() != string.Empty)
                BuscarMoedaPadrao(cd_empresa.Text);
            nm_empresa.Text = vNm_empresa;
            cd_portador.Text = vCd_portador;
            ds_portador.Text = vDs_portador;
            id_config.Text = vId_configBoleto;
            ds_configboleto.Text = vDs_configBoleto;
            cd_contager.Text = vCd_contagerliq;
            cd_contager_Leave(this, new EventArgs());
            cd_clifor.Text = vCd_clifor;
            nm_clifor.Text = vNm_clifor;
            cd_endereco.Text = vCd_endereco;
            ds_endereco.Text = vDs_endereco;
            tp_mov.Text = vTp_mov;
            cd_historico.Text = vCd_historico;
            ds_historico.Text = vDs_historico;
            cd_historico_Leave(this, new EventArgs());
            tp_duplicata.Text = vTp_duplicata;
            ds_tpduplicata.Text = vDs_tpduplicata;
            tp_docto.Text = vTp_docto;
            ds_tpdocto.Text = vDs_tpdocto;
            cd_condpgto.Text = vCd_condpgto;
            if (!string.IsNullOrEmpty(cd_condpgto.Text))
            {
                cd_portador.Enabled = true;
                bb_portador.Enabled = true;
                cd_contager.Enabled = true;
                bb_contager.Enabled = true;
                cd_historico_dup.Enabled = true;
                bb_historico_dup.Enabled = true;
            }
            cd_condpgto_Leave(this, new EventArgs());
            ds_condpagto.Text = vDs_condpgto;
            st_comentrada.Text = st_comentrada.Text.Trim().Equals(string.Empty) ? vSt_comentrada : st_comentrada.Text;
            cd_juro.Text = cd_juro.Text.Trim().Equals(string.Empty) ? vCd_juro : cd_juro.Text;
            ds_juro.Text = ds_juro.Text.Trim().Equals(string.Empty) ? vDs_juro : ds_juro.Text;
            tp_juro.Text = tp_juro.Text.Trim().Equals(string.Empty) ? vTp_juro : tp_juro.Text;
            cd_moeda.Text = vCd_moeda;
            ds_moeda.Text = vDs_moeda;
            cd_moeda_Leave(this, new EventArgs());
            cd_moeda.Enabled = cd_moeda.Text.Trim().Equals(string.Empty);
            bb_moeda.Enabled = cd_moeda.Text.Trim().Equals(string.Empty);
            sigla_moeda_index.Text = vSigla_moeda;
            cd_moeda_padrao.Text = (!string.IsNullOrEmpty(vCd_moeda_padrao) ? vCd_moeda_padrao : cd_moeda_padrao.Text);
            ds_moeda_padrao.Text = (!string.IsNullOrEmpty(vDs_moeda_padrao) ? vDs_moeda_padrao : ds_moeda_padrao.Text);
            sigla_moeda_padrao.Text = (!string.IsNullOrEmpty(vSigla_moeda_padrao) ? vSigla_moeda_padrao : sigla_moeda_padrao.Text);
            qt_dias_desdobro.Value = qt_dias_desdobro.Value.Equals(0) ? vQt_dias_desdobro : qt_dias_desdobro.Value;
            qt_parcelas.Value = qt_parcelas.Value.Equals(0) ? vQt_parcelas : qt_parcelas.Value;
            pc_jurodiario_atrazo.Value = pc_jurodiario_atrazo.Value.Equals(0) ? vPc_jurodiario_atrazo : pc_jurodiario_atrazo.Value;
            st_solicitardtvencto = st_solicitardtvencto ? st_solicitardtvencto : vSt_solicitardtvencto;
            nr_docto.Text = vNr_docto;
            dt_emissao.Text = vDt_emissao;
            vl_documento_index.Value = vVl_documento;
            ds_observacao.Text = vDs_observacao;
            (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_pedido = vNr_pedido;
            (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = lParc;
        }

        private void HabilitarCamposCTRC()
        {
            if (vSt_ctrc)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_endereco.Enabled = false;
                bb_endereco.Enabled = false;
                tp_duplicata.Enabled = false;
                bb_tpduplicata.Enabled = false;
                tp_docto.Enabled = false;
                bb_tpdocto.Enabled = false;
                dt_emissao.Enabled = false;
                vl_documento_index.Enabled = false;
                nr_docto.Enabled = false;
                bbAddClifor.Enabled = false;
                pCobranca.Enabled = !tp_mov.Text.Trim().ToUpper().Equals("P");
                cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
                Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
                cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                if (vCd_moeda_padrao.Trim().Equals(string.Empty))
                    BuscarMoedaPadrao(cd_empresa.Text);
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void habilitarCamposNf()
        {
            if (vSt_notafiscal)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_endereco.Enabled = false;
                bb_endereco.Enabled = false;
                tp_duplicata.Enabled = false;
                bb_tpduplicata.Enabled = false;
                tp_docto.Enabled = false;
                bb_tpdocto.Enabled = false;
                bbAddClifor.Enabled = false;
                pCobranca.Enabled = !tp_mov.Text.Trim().ToUpper().Equals("P");
                cd_moeda_padrao.Enabled = string.IsNullOrEmpty(cd_moeda_padrao.Text);
                bb_moedapadrao.Enabled = string.IsNullOrEmpty(cd_moeda_padrao.Text);
                vl_documento_index.Enabled = false;
                dt_emissao.Enabled = false;
                cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
                pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
                cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                nr_docto.Enabled = false;
                if (vCd_moeda_padrao.Trim().Equals(string.Empty))
                    BuscarMoedaPadrao(cd_empresa.Text);
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    if (vNr_pedido.HasValue)
                    {
                        CamadaDados.Faturamento.Pedido.TList_Pedido_DT_Vencto lVencto =
                            CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_DT_Vencto.Busca(vNr_pedido.Value, null);
                        if (lVencto.Count > 0)
                        {
                            cd_condpgto.Enabled = false;
                            bb_condpgto.Enabled = false;
                            vl_entrada.Enabled = false;
                            //if (lVencto[0].Diasvencto.Equals(decimal.Zero))
                            //    vl_entrada.Value = lVencto[0].VL_Parcela;
                        }
                    }
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void habilitarCamposEcf()
        {
            if (vSt_ecf)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_clifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
                bb_clifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
                cd_endereco.Enabled = true;
                bb_endereco.Enabled = true;
                tp_duplicata.Enabled = false;
                bb_tpduplicata.Enabled = false;
                tp_docto.Enabled = false;
                bb_tpdocto.Enabled = false;
                cd_juro.Enabled = true;
                bb_juro.Enabled = true;
                cd_moeda.Enabled = false;
                bb_moeda.Enabled = false;
                cd_moeda_padrao.Enabled = false;
                bb_moedapadrao.Enabled = false;
                vl_documento_index.Enabled = false;
                vl_documento.Enabled = false;
                dt_emissao.Enabled = false;
                bbAddClifor.Enabled = false;
                pCobranca.Enabled = !tp_mov.Text.Trim().ToUpper().Equals("P");
                cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
                pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
                cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                if (vCd_moeda_padrao.Trim().Equals(string.Empty))
                    BuscarMoedaPadrao(cd_empresa.Text);
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    if (lParc.Count.Equals(0))
                    {
                        (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                        (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                    }
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void HabilitarCamposAgrupar()
        {
            if (vSt_agrupar)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    cd_clifor.Enabled = false;
                    bb_clifor.Enabled = false;
                }
                else
                {
                    cd_clifor.Enabled = true;
                    bb_clifor.Enabled = true;
                }

                if (!string.IsNullOrEmpty(cd_endereco.Text))
                {
                    cd_endereco.Enabled = false;
                    bb_endereco.Enabled = false;
                }
                else
                {
                    cd_endereco.Enabled = true;
                    bb_endereco.Enabled = true;
                }
                cd_moeda_padrao.Enabled = false;
                bb_moedapadrao.Enabled = false;
                vl_documento_index.Enabled = false;
                vl_documento.Enabled = false;
                bbAddClifor.Enabled = false;
                cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
                pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
                cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
                if (vCd_moeda_padrao.Trim().Equals(string.Empty))
                    BuscarMoedaPadrao(cd_empresa.Text);
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void HabilitarCamposFinPed()
        {
            if (vSt_finPed)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_endereco.Enabled = false;
                bb_endereco.Enabled = false;
                vl_documento_index.Enabled = false;
                bbAddClifor.Enabled = false;
                if (vCd_moeda_padrao.Trim().Equals(string.Empty))
                    BuscarMoedaPadrao(cd_empresa.Text);
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    if (vNr_pedido.HasValue)
                    {
                        CamadaDados.Faturamento.Pedido.TList_Pedido_DT_Vencto lVencto =
                            CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_DT_Vencto.Busca(vNr_pedido.Value, null);
                        if (lVencto.Count > 0)
                        {
                            cd_condpgto.Enabled = false;
                            bb_condpgto.Enabled = false;
                            vl_entrada.Enabled = false;
                            //if (lVencto[0].Diasvencto.Equals(decimal.Zero))
                            //    vl_entrada.Value = lVencto[0].VL_Parcela;
                        }
                    }
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void BuscarCotacao()
        {
            if ((dt_emissao.Text.Trim() != "") && (dt_emissao.Text.Trim() != "/  /") && (cd_moeda_padrao.Text.Trim() != "") && (cd_moeda.Text.Trim() != ""))
            {
                DataTable tb_cotacao = new TCD_CotacaoMoeda().Buscar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_moeda",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_moeda.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_moedaresult",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_moeda_padrao.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.data",
                            vOperador = "<=",
                            vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(dt_emissao.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                        }
                    }, 1, string.Empty, string.Empty, "a.data desc", null);
                if (tb_cotacao != null)
                    if (tb_cotacao.Rows.Count > 0)
                    {
                        dt_cotacao.Text = tb_cotacao.Rows[0]["Data"].ToString();
                        vl_cotacao.Value = Convert.ToDecimal(tb_cotacao.Rows[0]["Valor"].ToString());
                        operador.Text = tb_cotacao.Rows[0]["OP"].ToString();
                    }
                    else
                    {
                        dt_cotacao.Text = string.Empty; ;
                        vl_cotacao.Value = 0;
                        operador.Text = string.Empty;
                    }
                else
                {
                    dt_cotacao.Text = string.Empty;
                    vl_cotacao.Value = 0;
                    operador.Text = string.Empty;
                }
            }
        }

        private void BuscarMoedaPadrao(string pCd_empresa)
        {
            TList_Moeda tb_moeda = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
            if (tb_moeda != null)
                if (tb_moeda.Count > 0)
                {
                    cd_moeda_padrao.Text = tb_moeda[0].Cd_moeda;
                    ds_moeda_padrao.Text = tb_moeda[0].Ds_moeda_singular;
                    sigla_moeda_padrao.Text = tb_moeda[0].Sigla;
                }
                else
                {
                    cd_moeda_padrao.Text = string.Empty;
                    ds_moeda_padrao.Text = string.Empty;
                    sigla_moeda_padrao.Text = string.Empty;
                }
            else
            {
                cd_moeda_padrao.Text = string.Empty;
                ds_moeda_padrao.Text = string.Empty;
                sigla_moeda_padrao.Text = string.Empty;
            }
        }

        private void ConverterValorMoeda()
        {
            if (dsDuplicata.Current != null)
                if ((dt_emissao.Text.Trim() != "") && (dt_emissao.Text.Trim() != "/  /") && (cd_moeda.Text.Trim() != "") && (cd_moeda_padrao.Text.Trim() != "") && (vl_documento_index.Value > 0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao = TCN_CotacaoMoeda.ConvertMoeda(cd_moeda.Text, cd_moeda_padrao.Text, Convert.ToDateTime(dt_emissao.Text), vl_documento_index.Value);
                    dsDuplicata.ResetCurrentItem();
                }
        }

        private decimal convertValorParcela(decimal vl_parcela)
        {
            if ((dt_emissao.Text.Trim() != "") && (dt_emissao.Text.Trim() != "/  /") && (cd_moeda.Text.Trim() != "") && (cd_moeda_padrao.Text.Trim() != "") && (vl_parcela > 0))
                return TCN_CotacaoMoeda.ConvertMoeda(cd_moeda.Text, cd_moeda_padrao.Text, Convert.ToDateTime(dt_emissao.Text), vl_parcela);
            else return 0;
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty(cd_clifor.Text)) &&
                (tp_mov.Text.Trim().ToUpper().Equals("R")) &&
                (qt_parcelas.Value > decimal.Zero) &&
                ((dsParcelas.List as TList_RegLanParcela).Sum(p => p.Vl_parcela) - vl_entrada.Value > decimal.Zero))
            {
                TRegistro_DadosBloqueio rDados = new TRegistro_DadosBloqueio();
                if (TCN_DadosBloqueio.VerificarBloqueioCredito(cd_clifor.Text,
                                                               (dsParcelas.List as TList_RegLanParcela).Sum(p => p.Vl_parcela) - vl_entrada.Value - vl_adiantamento.Value,
                                                               true,
                                                               ref rDados,
                                                               null))
                    using (TFLan_BloqueioCredito fBloq = new TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = (dsParcelas.List as TList_RegLanParcela).Sum(p => p.Vl_parcela) - vl_entrada.Value;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private TList_RegLanParcela calculaParcelas(TRegistro_LanDuplicata val)
        {
            if (val != null)
                if ((dt_emissao.Text.Trim() != "/  /") && (cd_condpgto.Text.Trim() != "") &&
                    (vl_documento_index.Value > 0) && (dsDuplicata.Current != null))
                    if (st_comentrada.Text.Trim().Equals("S"))
                    {
                        if ((vl_entrada.Value > 0) || (!vl_entrada.Enabled))
                            return TCN_LanDuplicata.calcularParcelas(val, null);
                        else
                            return val.Parcelas;
                    }
                    else
                        return TCN_LanDuplicata.calcularParcelas(val, null);
                else
                    return val.Parcelas;
            else
                return null;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
            BuscarMoedaPadrao(cd_empresa.Text);
            BuscarCotacao();
            ConverterValorMoeda();
            (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
            (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
            dsDuplicata.ResetCurrentItem();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            BuscarMoedaPadrao(cd_empresa.Text);
            BuscarCotacao();
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
                (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                TList_CadEndereco lEnd = TCN_CadEndereco.Buscar(cd_clifor.Text,
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
                if (lEnd.Count == 1)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco.ToString();
                    ds_endereco.Text = lEnd[0].Ds_endereco.ToString();
                    tp_duplicata.Focus();
                }
                pCd_historicopag = linha["cd_historicopag"].ToString();
                pDs_historicopag = linha["ds_historicopag"].ToString();
                pCd_historicorec = linha["cd_historicorec"].ToString();
                pDs_historicorec = linha["ds_historicorec"].ToString();
                if (tp_mov.Text.Trim().ToUpper().Equals("P") && string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["cd_historicopag"].ToString();
                    ds_historico.Text = linha["ds_historicopag"].ToString();
                }
                else if (tp_mov.Text.Trim().ToUpper().Equals("R") && string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["cd_historicorec"].ToString();
                    ds_historico.Text = linha["ds_historicorec"].ToString();
                }
            }
            else
            {
                pCd_historicorec = string.Empty;
                pDs_historicorec = string.Empty;
                pCd_historicopag = string.Empty;
                pDs_historicopag = string.Empty;
            }
            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
            dsDuplicata.ResetCurrentItem();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                    new TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                TList_CadEndereco lEnd =
                    TCN_CadEndereco.Buscar(cd_clifor.Text,
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
                if (lEnd.Count == 1)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco.ToString();
                    ds_endereco.Text = lEnd[0].Ds_endereco.ToString();
                    tp_duplicata.Focus();
                }
                else
                    bb_endereco_Click(this, new EventArgs());
                if (tp_mov.Text.Trim().ToUpper().Equals("P") && string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["cd_historicopag"].ToString();
                    ds_historico.Text = linha["ds_historicopag"].ToString();
                }
                else if (tp_mov.Text.Trim().ToUpper().Equals("R") && string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["cd_historicorec"].ToString();
                    ds_historico.Text = linha["ds_historicorec"].ToString();
                }
            }
            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
            dsDuplicata.ResetCurrentItem();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Descrição Endereço|350;" +
                              "a.CD_Endereco|Cód. Endereço|100";
            string vParamFixo = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                    new TCD_CadEndereco(), vParamFixo);
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + cd_endereco.Text + "';" +
                              "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                    new TCD_CadEndereco());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vParamFixo = string.Empty;
            if (!string.IsNullOrEmpty(vTp_mov))
                vParamFixo = "a.TP_Mov|=|'" + vTp_mov.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov }, vParamFixo);
            pCobranca.Enabled = !tp_mov.Text.Trim().ToUpper().Equals("P");
            if (linha != null)
            {
                id_config.Text = linha["id_config"].ToString();
                ds_configboleto.Text = linha["ds_config"].ToString();
                if (string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["tp_mov"].ToString().Trim().ToUpper().Equals("P") ? pCd_historicopag : pCd_historicorec;
                    ds_historico.Text = linha["tp_mov"].ToString().Trim().ToUpper().Equals("P") ? pDs_historicopag : pDs_historicorec;
                }
            }
            else
            {
                id_config.Clear();
                ds_configboleto.Clear();
            }
            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
            dsDuplicata.ResetCurrentItem();
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Duplicata|=|'" + tp_duplicata.Text + "'";
            if (!string.IsNullOrEmpty(vTp_mov))
                vColunas += ";a.TP_Mov|=|'" + vTp_mov.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LeaveTpDuplicata(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov });
            pCobranca.Enabled = !tp_mov.Text.Trim().ToUpper().Equals("P");
            if (linha != null)
            {
                id_config.Text = linha["id_config"].ToString();
                ds_configboleto.Text = linha["ds_config"].ToString();
                if (string.IsNullOrEmpty(cd_historico.Text))
                {
                    cd_historico.Text = linha["tp_mov"].ToString().Trim().ToUpper().Equals("P") ? pCd_historicopag : pCd_historicorec;
                    ds_historico.Text = linha["tp_mov"].ToString().Trim().ToUpper().Equals("P") ? pDs_historicopag : pDs_historicorec;
                }
            }
            else
            {
                id_config.Clear();
                ds_configboleto.Clear();
            }
            (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
            dsDuplicata.ResetCurrentItem();
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                              "TP_Docto|TP. Docto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Docto|=|'" + tp_docto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100;" +
                              "d.CD_Juro|Cód. Juro|100;" +
                              "d.DS_Juro|Descrição Juro|350";
            if (!string.IsNullOrEmpty(vId_caixa))
                vParam = "a.QT_Parcelas|<>|0";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpagto },
                                    new TCD_CadCondPgto(), vParam);
            cd_condpgto_Leave(this, e);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CondPgto|=|'" + cd_condpgto.Text + "'";
            if (!string.IsNullOrEmpty(vId_caixa))
                vColunas += ";a.QT_Parcelas|<>|0";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{cd_condpgto,
                                    ds_condpagto, st_comentrada, cd_juro, ds_juro,
                                    tp_juro, cd_moeda, ds_moeda, sigla_moeda_index},
                                    new TCD_CadCondPgto());
            cd_moeda.Enabled = string.IsNullOrEmpty(cd_moeda.Text);
            bb_moeda.Enabled = string.IsNullOrEmpty(cd_moeda.Text);
            if (linha != null)
            {
                if (vSt_ecf)
                {
                    vl_documento_index.Value = vVl_documento;
                    if(!string.IsNullOrWhiteSpace(linha["cd_juro_fin"].ToString()))
                        vl_documento_index.Value += TCN_CadCondPgto.CalcularValorJuroFin(
                                                    new TRegistro_CadCondPgto
                                                    {
                                                        Pc_jurodiario_atrazoFin = decimal.Parse(linha["pc_juroDiario_atrazoFin"].ToString()),
                                                        Tp_juro_fin = linha["tp_juro_fin"].ToString(),
                                                        Qt_diasdesdobro = decimal.Parse(linha["qt_diasdesdobro"].ToString()),
                                                        St_comentradabool = linha["st_comentrada"].ToString().Trim().ToUpper().Equals("S"),
                                                        Qt_parcelas = decimal.Parse(linha["qt_parcelas"].ToString())
                                                    }, vl_documento_index.Value);
                }
                //Verificar se existe rateio de parcelas para a cond de pgto
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "a.cd_condpgto";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_condpgto.Text.Trim() + "'";
                object obj = new TCD_CadCondPgto_X_Parcelas().BuscarEscalar(filtro, "'1'");
                if (obj != null)
                    st_rateioparcelas = obj.ToString().Trim().Equals("1");
                try
                {
                    qt_dias_desdobro.Value = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                }
                catch { qt_dias_desdobro.Value = 0; }
                try
                {
                    qt_parcelas.Value = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                }
                catch { qt_parcelas.Value = 0; }
                try
                {
                    pc_jurodiario_atrazo.Value = Convert.ToDecimal(linha["PC_JuroDiario_Atrazo"].ToString());
                }
                catch { pc_jurodiario_atrazo.Value = 0; }

                st_comentrada.Text = linha["ST_ComEntrada"].ToString().Trim().ToUpper();

                vl_entrada.Enabled = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S") && (!st_rateioparcelas);
                st_solicitardtvencto = linha["ST_SolicitarDtVencto"].ToString().Trim().Equals("S");
                if (dsDuplicata.Current != null)
                    (dsDuplicata.Current as TRegistro_LanDuplicata).St_venctoferiado = linha["ST_VenctoEmFeriado"].ToString().Trim();
                BuscarCotacao();
                ConverterValorMoeda();
                if (dsDuplicata.Current != null)
                {
                    if (lParc.Count.Equals(0))
                    {
                        (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                        (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                        dsDuplicata.ResetCurrentItem();
                    }
                }
            }
            else
            {
                qt_dias_desdobro.Value = 0;
                qt_parcelas.Value = 0;
                pc_jurodiario_atrazo.Value = 0;
                if (dsDuplicata.Current != null)
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Qt_parcelas = 0;
                    (dsDuplicata.Current as TRegistro_LanDuplicata).St_comentrada = "N";
                    dsDuplicata.ResetCurrentItem();
                }
            }
        }

        private void cd_condpgto_TextChanged(object sender, EventArgs e)
        {
            if (!vSt_alterar)
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
            if (cd_condpgto.Text.Trim().Equals(string.Empty))
            {
                st_comentrada.Clear();
                cd_juro.Clear();
                ds_juro.Clear();
                tp_juro.Clear();
                cd_moeda.Clear();
                ds_moeda.Clear();
                qt_dias_desdobro.Value = decimal.Zero;
                qt_parcelas.Value = decimal.Zero;
                pc_jurodiario_atrazo.Value = decimal.Zero;
            }
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100;" +
                              "a.cd_Historico_Quitacao|Cd. Quitação|80;" +
                              "e.DS_Historico|Historico Quitação|200";
            string vParamFixo = "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                        new TCD_CadHistorico(), vParamFixo);
            if (linha != null)
            {
                cd_historico_dup.Text = linha["cd_historico_quitacao"].ToString();
                ds_historico_dup.Text = linha["DS_Historico_Quitacao"].ToString();
            }
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text + "';" +
                              "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                    new TCD_CadHistorico());
            if (linha != null)
            {
                cd_historico_dup.Text = linha["cd_historico_quitacao"].ToString();
                ds_historico_dup.Text = linha["DS_Historico_Quitacao"].ToString();
            }
        }

        private void tp_duplicata_TextChanged(object sender, EventArgs e)
        {
            if (tp_duplicata.Text.Trim().Equals(""))
            {
                cd_historico.Clear();
                ds_historico.Clear();
            }
        }

        private void vl_entrada_EnabledChanged(object sender, EventArgs e)
        {
            if (!(vl_entrada.Enabled))
                vl_entrada.Value = 0;
        }

        private void FLanDuplicata_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            pDados.set_FormatZero();
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (Tag == null ? false : !Tag.ToString().Trim().ToUpper().Equals("S"))
            {
                if (!vSt_alterar)
                {
                    Text = "INCLUIR DUPLICATA";
                    preencherCampos();
                    habilitarCamposNf();
                    HabilitarCamposCTRC();
                    habilitarCamposEcf();
                    HabilitarCamposAgrupar();
                    HabilitarCamposFinPed();
                    if (St_editardataemissao) dt_emissao.Enabled = true;
                }
                else
                {
                    Text = "ALTERAR DUPLICATA";
                    BuscarMoedaPadrao(cd_empresa.Text);
                    pDados.HabilitarControls(false, TTpModo.tm_Standby);
                    tp_docto.Enabled = true;
                    bb_tpdocto.Enabled = true;
                    complhistorico.Enabled = true;
                    nr_docto.Enabled = true;
                    ds_observacao.Enabled = true;
                    if (dsParcelas.Current != null)
                    {
                        cd_condpgto.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        bb_condpgto.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        cd_juro.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        bb_juro.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        cd_moeda.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        bb_moeda.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        cd_moeda_padrao.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        bb_moedapadrao.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                        dt_vencto.Enabled = (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                    }

                    vl_documento_index.Enabled = st_habilitaralterarvalor;
                    dt_emissao.Enabled = st_habilitaralterarvalor;
                }
                TPModo = TTpModo.tm_Insert;
            }
            else
                HabilitarCampos(false);
            PreparaBotoes(TPModo);
            if (!string.IsNullOrEmpty(vCd_empresa) && !string.IsNullOrEmpty(vCd_condpgto))
            {
                cd_empresa_Leave(sender, new EventArgs());
                cd_condpgto_Leave(sender, new EventArgs());
            }
        }

        private void dt_emissao_Leave(object sender, EventArgs e)
        {
            if (dt_emissao.SoNumero().Length == 8)
            {
                DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                if (DateTime.Parse(dt_emissao.Text).Date > dt_atual.Date)
                {
                    //Verificar se o usuario tem permissao para liquidar com data superior a data corrente
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR DUPLICATA COM DATA SUPERIOR ATUAL", null))
                    {
                        MessageBox.Show("Usuario não tem permissão para lançar duplicatas com data superior a data corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_emissao.Text = dt_atual.ToString("dd/MM/yyyy");
                        dt_emissao.Focus();
                        return;
                    }
                }
            }
            BuscarCotacao();
            ConverterValorMoeda();
            if (lParc.Count.Equals(0))
            {
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                dsDuplicata.ResetCurrentItem();
            }
            if ((cd_contager.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.DataCaixa(cd_contager.Text, Convert.ToDateTime(dt_emissao.Text), null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + cd_contager.Text + "\r\n Data: " + dt_emissao.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_emissao.Focus();
                }
            }
        }

        public void vl_documentoleave()
        {
            vl_documento_Leave(this, new EventArgs());
        }

        private void vl_documento_Leave(object sender, EventArgs e)
        {
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                if (lParc.Count.Equals(0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                }
                (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
                (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void dsParcelas_PositionChanged(object sender, EventArgs e)
        {
            if (dsParcelas.Current != null)
            {
                if (st_comentrada.Text.Trim().Equals("S"))
                {
                    if (dsParcelas.Position.Equals(0))
                    {
                        dt_vencto.Enabled = (vSt_alterar && (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A")) || false;
                        vl_parcela_padrao.Enabled = false;
                    }
                    else
                    {
                        dt_vencto.Enabled = (vSt_alterar && (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A")) || st_solicitardtvencto;
                        vl_parcela_padrao.Enabled = (!st_rateioparcelas) && (dsParcelas.Position != (dsParcelas.Count - 1)) &&
                                                    (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                    }
                }
                else
                {
                    dt_vencto.Enabled = (vSt_alterar && (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A")) || st_solicitardtvencto;
                    vl_parcela_padrao.Enabled = (!st_rateioparcelas) && (dsParcelas.Position != (dsParcelas.Count - 1)) &&
                                                (dsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A");
                }
            }
        }

        private void vl_parcela_Leave(object sender, EventArgs e)
        {
            (dsParcelas.Current as TRegistro_LanParcela).Vl_parcela = vl_parcela.Value;
            dsParcelas.EndEdit();
            TCN_LanDuplicata.recalculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata), dsParcelas.Position, true);
            TCN_LanDuplicata.recalculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata), dsParcelas.Position, false);
            gParcelas.Refresh();
        }

        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            if (dsDuplicata.Current != null)
            {
                TCN_LanDuplicata.validaDataVencimento((dsDuplicata.Current as TRegistro_LanDuplicata), dsParcelas.Position);
                dt_vencto.Text = (dsParcelas.Current as TRegistro_LanParcela).Dt_vencto.Value.ToString("dd/MM/yyyy");
                gParcelas.Refresh();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            bool cancela = false;
            if (dt_emissao.SoNumero().Length == 8)
            {
                DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                if (DateTime.Parse(dt_emissao.Text).Date > dt_atual.Date)
                {
                    //Verificar se o usuario tem permissao para liquidar com data superior a data corrente
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR DUPLICATA COM DATA SUPERIOR ATUAL", null))
                    {
                        MessageBox.Show("Usuario não tem permissão para lançar duplicatas com data superior a data corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_emissao.Text = dt_atual.ToString("dd/MM/yyyy");
                        dt_emissao.Focus();
                        return;
                    }
                }
            }
            if (!bloqueioCredito())
            {
                MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                               "Financeiro não poderá ser gravado.", "Mensagem", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            try
            {
                DateTime dt = Convert.ToDateTime(dt_emissao.Text);
            }
            catch { }

            if (pDados.validarCampoObrigatorio())
            {
                if (pc_desconto.Focused)
                    pc_desconto_Leave(this, new EventArgs());
                if (vl_documento_index.Focused)
                    vl_documento_Leave(this, e);
                if (vl_entrada_padrao.Focused)
                    vl_entrada_padrao_Leave(this, e);
                if (dt_vencto.Focused)
                    dt_vencto_Leave(this, e);
                if (dsParcelas.Count < 1)
                {
                    MessageBox.Show("Obrigatório Informar Parcelas !", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((cd_moeda.Text.Trim() != "") && (cd_moeda_padrao.Text.Trim() != "") && (cd_moeda_padrao.Text.Trim() != cd_moeda.Text.Trim()) && (vl_cotacao.Value == 0))
                {
                    MessageBox.Show("Obrigatório informar cotação para as moedas", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((!vSt_alterar) && (st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0)) && cd_historico_dup.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Para lançamento de duplicata com condição de pagamento a vista ou com entrada,\r\n" +
                                    "o historico da duplicata deve possuir um historico de quitação configurado.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_historico.Focus();
                    return;
                }
                if ((!vSt_alterar) && (st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0)) && cd_portador.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Para lançamento de duplicata com condição de pagamento a vista ou com entrada,\r\n" +
                                    "obrigatorio informar portador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_portador.Focus();
                    return;
                }
                if ((!vSt_alterar) && (st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0)) && cd_contager.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Para lançamento de duplicata com condição de pagamento a vista ou com entrada,\r\n" +
                                    "obrigatorio informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_contager.Focus();
                    return;
                }
                if ((dsDuplicata.Current as TRegistro_LanDuplicata).lCred == null)
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", cd_empresa.Text, null).Trim().ToUpper().Equals("S"))
                        if (CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                             cd_empresa.Text,
                                                                                             cd_clifor.Text,
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
                if (st_lancarcheque)
                {
                    using (TFLanListaCheques fListaCheques = new TFLanListaCheques())
                    {
                        fListaCheques.Tp_mov = tp_mov.Text.Trim();
                        fListaCheques.Cd_empresa = cd_empresa.Text;
                        fListaCheques.Cd_contager = cd_contager.Text;
                        fListaCheques.Ds_contager = ds_contager.Text;
                        fListaCheques.Cd_clifor = cd_clifor.Text;
                        fListaCheques.Cd_historico = cd_historico_dup.Text;
                        fListaCheques.Ds_historico = string.Empty;
                        fListaCheques.Cd_portador = cd_portador.Text;
                        fListaCheques.Ds_portador = ds_portador.Text;
                        fListaCheques.Nm_clifor = nm_clifor.Text;
                        fListaCheques.Dt_emissao = dt_emissao.Data;
                        fListaCheques.Vl_totaltitulo = qt_parcelas.Value.Equals(0) ? vl_documento.Value - vl_adiantamento.Value : vl_entrada_padrao.Value;
                        if (fListaCheques.ShowDialog() == DialogResult.OK)
                        {
                            (dsDuplicata.Current as TRegistro_LanDuplicata).Titulos = fListaCheques.lCheques;
                            if (fListaCheques.Vl_totaltitulo <
                                    fListaCheques.lCheques.Sum(p => p.Vl_titulo))
                            {
                                using (TFTrocoPDV fTroco = new TFTrocoPDV())
                                {
                                    fTroco.Cd_empresa = cd_empresa.Text;
                                    fTroco.Cd_contager = cd_contager.Text;
                                    fTroco.Id_caixaPDV = string.Empty;
                                    fTroco.Vl_troco = fListaCheques.lCheques.Sum(p => p.Vl_titulo) - fListaCheques.Vl_totaltitulo;
                                    fTroco.Cd_historioTroco = cd_historico.Text;
                                    fTroco.Ds_historicoTroco = ds_historico.Text;
                                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR GERAR CREDITO NO TROCO", null);
                                    if (fTroco.ShowDialog() == DialogResult.OK)
                                    {
                                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoDH = fTroco.Vl_trocoDinheiro;
                                        if (fTroco.lChTroco != null)
                                        {
                                            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                            fTroco.lChTroco.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                                        }
                                        if (fTroco.lChRepasse != null)
                                        {
                                            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                            fTroco.lChRepasse.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                                        }
                                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adtoCH = fTroco.Vl_trocoCredito;
                                        (dsDuplicata.Current as TRegistro_LanDuplicata).St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
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
                            MessageBox.Show("Obrigatorio informar cheques parar gravar duplicata.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                if (st_cartaocredito)
                {
                    using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                    {
                        if (fD_C.ShowDialog() == DialogResult.OK)
                            //Buscar dados fatura cartao credito
                            using (TFFaturaCartao fFatura = new TFFaturaCartao())
                            {
                                fFatura.Cd_empresa = cd_empresa.Text;
                                fFatura.Tp_movimento = tp_mov.Text.Trim();
                                fFatura.Dt_fatura = dt_emissao.Data;
                                fFatura.Vl_nominal = qt_parcelas.Value.Equals(0) ? vl_documento.Value - vl_adiantamento.Value : vl_entrada_padrao.Value;
                                fFatura.Vl_juro = decimal.Zero;
                                fFatura.D_C = fD_C.D_C;
                                if (fFatura.ShowDialog() == DialogResult.OK)
                                    if (fFatura.lFatura != null)
                                    {
                                        (dsDuplicata.Current as TRegistro_LanDuplicata).lFatura = fFatura.lFatura;
                                        if (fFatura.Vl_nominal <
                                            fFatura.lFatura.Sum(p => p.Vl_nominal))
                                        {
                                            using (TFTrocoPDV fTroco = new TFTrocoPDV())
                                            {
                                                fTroco.Cd_empresa = cd_empresa.Text;
                                                fTroco.Cd_contager = cd_contager.Text;
                                                fTroco.Id_caixaPDV = string.Empty;
                                                fTroco.Vl_troco = fFatura.lFatura.Sum(p => p.Vl_nominal) - fFatura.Vl_nominal;
                                                fTroco.Cd_historioTroco = cd_historico.Text;
                                                fTroco.Ds_historicoTroco = ds_historico.Text;
                                                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                if (fTroco.ShowDialog() == DialogResult.OK)
                                                {
                                                    (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoDH = fTroco.Vl_trocoDinheiro;
                                                    if (fTroco.lChTroco != null)
                                                    {
                                                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                                                        fTroco.lChTroco.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                                                    }
                                                    if (fTroco.lChRepasse != null)
                                                    {
                                                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                                                        fTroco.lChRepasse.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                                                    }
                                                    (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adtoCH = fTroco.Vl_trocoCredito;
                                                    (dsDuplicata.Current as TRegistro_LanDuplicata).St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
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
                                        MessageBox.Show("Obrigatorio informar fatura para gravar duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar fatura para gravar duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar fatura para gravar duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                /*Procedimento de Troco com portador dinheiro nao esta completo,
                 * esta dando diferenca entre o valor da liquidacao e o valor do troco*/
                //if ((!vSt_alterar) && 
                //    (st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0)) && 
                //    (!st_cartaocredito) &&
                //    (!st_lancarcheque))//Portador dinheiro
                //{
                //    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                //    {
                //        fValor.Ds_label = "Valor " + (dsDuplicata.Current as TRegistro_LanDuplicata).Tipo_movimento;
                //        fValor.Vl_default = (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas[0].Vl_parcela;
                //        fValor.St_valor = true;
                //        if (fValor.ShowDialog() == DialogResult.OK)
                //            if (fValor.Quantidade > (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas[0].Vl_parcela)
                //                using (TFTrocoPDV fTroco = new TFTrocoPDV())
                //                {
                //                    fTroco.Cd_empresa = cd_empresa.Text;
                //                    fTroco.Cd_contager = cd_contager.Text;
                //                    fTroco.Id_caixaPDV = string.Empty;
                //                    fTroco.Vl_troco = fValor.Quantidade - (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas[0].Vl_parcela;
                //                    fTroco.Cd_historioTroco = cd_historico.Text;
                //                    fTroco.Ds_historicoTroco = ds_historico.Text;
                //                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR GERAR CREDITO NO TROCO", null);
                //                    if (fTroco.ShowDialog() == DialogResult.OK)
                //                    {
                //                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoDH = fTroco.Vl_trocoDinheiro;
                //                        if (fTroco.lChTroco != null)
                //                        {
                //                            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH = fTroco.lChTroco.Sum(p => p.Vl_titulo);
                //                            fTroco.lChTroco.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                //                        }
                //                        if (fTroco.lChRepasse != null)
                //                        {
                //                            (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_trocoCH += fTroco.lChRepasse.Sum(p => p.Vl_titulo);
                //                            fTroco.lChRepasse.ForEach(p => (dsDuplicata.Current as TRegistro_LanDuplicata).lChTroco.Add(p));
                //                        }
                //                        (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adtoCH = fTroco.Vl_trocoCredito;
                //                        (dsDuplicata.Current as TRegistro_LanDuplicata).St_AdtoTrocoCH = fTroco.Vl_trocoCredito > decimal.Zero;
                //                    }
                //                    else
                //                    {
                //                        MessageBox.Show("Obrigatorio informar troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                        return;
                //                    }
                //                }
                //    }
                //}
                //Verificar se a empresa utiliza rateio na provisao
                if (!vSt_alterar && !vSt_agrupar && !St_bloquearccusto)
                    if (TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                    (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                    null).Trim().ToUpper().Equals("S"))
                    {
                        //Verificar historico informado está ligado a um centro de resultado
                        TList_CentroResultado lCentro =
                            new TCD_CentroResultado().Select(
                                        new TpBusca[]
                                        {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_FIN_CentroResult_X_Historico x " +
                                                                    "where x.cd_centroresult = a.cd_centroresult " +
                                                                    "and x.cd_historico = '" + cd_historico.Text.Trim() + "') "
                                                    }
                                        }, 0, string.Empty);
                        if (lCentro.Count == 1)
                        {
                             (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Add(
                                new TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = cd_empresa.Text,
                                    Cd_centroresult = lCentro[0].Cd_centroresult,
                                    Vl_lancto = vl_documento.Value,
                                    Dt_lanctostr = dt_emissao.Text,
                                    Tp_registro = "A"
                                });
                        }
                        else if (lCentro.Count > 1)
                        {
                            using (TFRateioCentro fRateio = new TFRateioCentro())
                            {
                                TList_LanCCustoLancto lCCusto =
                                    new TList_LanCCustoLancto();
                                lCentro.ForEach(p =>
                                    lCCusto.Add(new TRegistro_LanCCustoLancto()
                                    {
                                        Cd_centroresult = p.Cd_centroresult,
                                        Ds_centroresultado = p.Ds_centroresultado,
                                        Dt_lanctostr = dt_emissao.Text,
                                        Tp_registro = "M",
                                    }));
                                fRateio.lCCusto = lCCusto;
                                fRateio.vVl_Documento = vl_documento.Value;
                                if (fRateio.ShowDialog() == DialogResult.OK)
                                    if (fRateio.lCCusto != null)
                                        (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto = fRateio.lCCusto;
                            }
                        }
                        else
                        {
                            using (TFRateioCResultado fRateio = new TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = (dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                fRateio.lCResultado = (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto;
                                fRateio.lCResultadoDel = (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLanctoDel;
                                fRateio.Tp_mov = (dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov;
                                fRateio.Dt_movimento = (dsDuplicata.Current as TRegistro_LanDuplicata).Dt_emissao;
                                fRateio.ShowDialog();
                                (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto = fRateio.lCResultado;
                                (dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLanctoDel = fRateio.lCResultadoDel;
                            }
                        }                     
                    }
                if (Tag == null ? false : !Tag.ToString().Trim().ToUpper().Equals("S"))
                {
                    if ((dsDuplicata.Current as TRegistro_LanDuplicata).Vl_desconto > decimal.Zero)
                    {
                        object objDesc = new TCD_CadTpDuplicata().BuscarEscalar(
                            new TpBusca[]
                            {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_duplicata",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (dsDuplicata.Current as TRegistro_LanDuplicata).Tp_duplicata.Trim() + "'"
                                    }
                            }, "a.CD_Historico_Desconto");
                        if (objDesc == null ? false : !string.IsNullOrEmpty(objDesc.ToString()))
                            (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_historico_Desconto = objDesc.ToString();
                        else
                        {
                            MessageBox.Show("Não existe Histórico no Desconto na CFG. TP.Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    try
                    {
                        if ((dsDuplicata.Current as TRegistro_LanDuplicata).Vl_desconto > decimal.Zero)
                        {
                            object objDesc = new TCD_CadTpDuplicata().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_duplicata",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (dsDuplicata.Current as TRegistro_LanDuplicata).Tp_duplicata.Trim() + "'"
                                    }
                                }, "a.CD_Historico_Desconto");
                            if (objDesc == null ? false : !string.IsNullOrEmpty(objDesc.ToString()))
                                (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_historico_Desconto = objDesc.ToString();
                            else
                            {
                                MessageBox.Show("Não existe Histórico no Desconto na CFG. TP.Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        string ret = TCN_LanDuplicata.GravarDuplicata((dsDuplicata.Current as TRegistro_LanDuplicata), true, null);
                        nr_lancto = ret;
                        if (!string.IsNullOrEmpty(ret))
                        {
                            string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");

                            MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Imprimir Boleto
                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                    (lan.Trim() != string.Empty ? Convert.ToDecimal(lan) : decimal.Zero),
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
                                    fImp.pCd_clifor = (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                          lBloqueto,
                                                                                          fImp.pSt_imprimir,
                                                                                          fImp.pSt_visualizar,
                                                                                          fImp.pSt_enviaremail,
                                                                                          fImp.pSt_exportPdf,
                                                                                          fImp.Path_exportPdf,
                                                                                          fImp.pDestinatarios,
                                                                                          "BLOQUETO(S) DO DOCUMENTO Nº " + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                          fImp.pDs_mensagem,
                                                                                          false);
                                }
                            //Imprimir Duplicata
                            if ((dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("R"))
                            {
                                object obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_docto",
                                                        vOperador = "=",
                                                        vVL_Busca = (dsDuplicata.Current as TRegistro_LanDuplicata).Tp_doctostring
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'S'"
                                                    }
                                                }, "1");
                                if (obj != null)
                                {
                                    //Chamar tela de impressao duplicata
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;

                                        if (TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                         (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                         null).Trim().ToUpper().Equals("S"))
                                        {
                                            //Verificar se tipo de documento gera Duplicata

                                            //Buscar dados Empresa
                                            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                                                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                                            //Buscar dados do sacado
                                            TList_CadClifor lSacado =
                                                TCN_CadClifor.Busca_Clifor((dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
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
                                                    TCN_CadEndereco.Buscar((dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                                                                              (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_endereco,
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

                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            //Duplicata
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = dsDuplicata;
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
                                            bs_parc.DataSource = (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas;
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
                                            fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;


                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                Rel.Gera_Relatorio(string.Empty,
                                                                   fImp.pSt_imprimir,
                                                                   fImp.pSt_visualizar,
                                                                   fImp.pSt_enviaremail,
                                                                   fImp.pSt_exportPdf,
                                                                   fImp.Path_exportPdf,
                                                                   fImp.pDestinatarios,
                                                                   null,
                                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                   fImp.pDs_mensagem);
                                        }
                                        else
                                        {
                                            fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas,
                                                                                                    null,
                                                                                                    null,
                                                                                                    fImp.pSt_imprimir,
                                                                                                    fImp.pSt_visualizar,
                                                                                                    fImp.pSt_exportPdf,
                                                                                                    fImp.Path_exportPdf,
                                                                                                    fImp.pSt_enviaremail,
                                                                                                    fImp.pDestinatarios,
                                                                                                    "DUPLICATAS(S) DO DOCUMENTO Nº " + (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                                    fImp.pDs_mensagem);
                                        }
                                    }
                                }
                            }
                            if ((dsDuplicata.Current as TRegistro_LanDuplicata).Qt_parcelas.Equals(decimal.Zero) ||
                                (dsDuplicata.Current as TRegistro_LanDuplicata).St_comentrada.Trim().ToUpper().Equals("S"))
                            {
                                try
                                {
                                    //Montar lista de parcelas
                                    List<TRegistro_LanParcela> lParcelas =
                                        new TCD_LanParcela().Select(
                                         new TpBusca[]
                                         {
                                             new TpBusca()
                                             {
                                                 vNM_Campo = "a.cd_empresa",
                                                 vOperador = "=",
                                                 vVL_Busca = "'" + (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'"
                                             },
                                             new TpBusca()
                                             {
                                                 vNM_Campo = "a.nr_lancto",
                                                 vOperador = "=",
                                                 vVL_Busca = (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString()
                                             },
                                             new TpBusca()
                                             {
                                                  vNM_Campo = "a.vl_liquidado",
                                                 vOperador = ">",
                                                 vVL_Busca = "0"
                                             }
                                         }, 0, string.Empty, string.Empty, string.Empty);

                                    TList_RegLanLiquidacao lLiquid =
                                        new TCD_LanLiquidacao().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_lancto",
                                                    vOperador = "=",
                                                    vVL_Busca = (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString()
                                                }
                                            }, 0, string.Empty);

                                    TList_RegLanDuplicata lDuplic = TCN_LanDuplicata.Busca((dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                                                (dsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString(),
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
                                        {
                                            FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboTexto(referente,
                                                                                               lLiquid[0]);
                                        }
                                    }
                                    else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                                    {
                                        if (MessageBox.Show("Deseja imprimir o recibo da Liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                            == DialogResult.Yes)
                                        {
                                            FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboReduzido(referente,
                                                                                               lLiquid[0]);
                                        }
                                    }
                                    else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                                    {
                                        FormRelPadrao.TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(false,
                                                                                      referente,
                                                                                      lLiquid[0],
                                                                                      lDuplic);
                                    }
                                    else
                                    {
                                        FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(false,
                                                                                      referente,
                                                                                      lLiquid[0],
                                                                                      lDuplic);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Erro imprimir recibos liquidação com cheques: " + ex.Message.Trim());
                                }
                            }
                            TPModo = TTpModo.tm_Standby;
                            PreparaBotoes(TPModo);
                            HabilitarCampos(false);
                            dsDuplicata.Clear();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim()); }
                }
            }
        }

        private void TFLanDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (BB_Novo.Visible && e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (BB_Gravar.Visible && e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (BB_Cancelar.Visible && e.KeyCode.Equals(Keys.F6))
                BB_Cancelar_Click(this, new EventArgs());
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string coluna = "DS_Juro|Descrição Juro|200;CD_Juro|Cd. Juro|80;TP_Juro|Tipo Juro|80";
            UtilPesquisa.BTN_BUSCA(coluna, new Componentes.EditDefault[] { cd_juro, ds_juro, tp_juro },
                                    new TCD_CadJuro(), "");
        }

        private void cd_juro_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_Juro|=|'" + cd_juro.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_juro, ds_juro, tp_juro },
                                    new TCD_CadJuro());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string coluna = "DS_Moeda_Singular|Descrição Moeda|200;CD_Moeda|Cd. Moeda|80;Sigla|Sigla|60";
            UtilPesquisa.BTN_BUSCA(coluna, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla_moeda_index },
                                    new TCD_Moeda(), "");
            BuscarCotacao();
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                if (lParc.Count.Equals(0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                }
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_Moeda|=|'" + cd_moeda.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla_moeda_index },
                                    new TCD_Moeda());
            BuscarCotacao();
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                if (lParc.Count.Equals(0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                }
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void vl_entrada_padrao_Leave(object sender, EventArgs e)
        {
            if (dsDuplicata.Current != null)
            {
                (dsDuplicata.Current as TRegistro_LanDuplicata).Vl_entrada = vl_entrada_padrao.Value;
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void dt_emissao_Enter(object sender, EventArgs e)
        {
            dt_emissao.SelectAll();
        }

        private void dt_vencto_Enter(object sender, EventArgs e)
        {
            dt_vencto.Select(0, dt_vencto.Text.Length - 1);
        }

        private void vl_entrada_Leave(object sender, EventArgs e)
        {
            if (dsDuplicata.Current != null)
            {
                (dsDuplicata.Current as TRegistro_LanDuplicata).Vl_entrada_padrao = vl_entrada.Value;
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                (dsDuplicata.Current as TRegistro_LanDuplicata).lCred = null;
                (dsDuplicata.Current as TRegistro_LanDuplicata).cVl_adiantamento = decimal.Zero;
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void vl_parcela_padrao_Leave(object sender, EventArgs e)
        {
            (dsParcelas.Current as TRegistro_LanParcela).Vl_parcela_padrao = vl_parcela_padrao.Value;
            (dsParcelas.Current as TRegistro_LanParcela).Vl_parcela = convertValorParcela(vl_parcela_padrao.Value);
            dsParcelas.EndEdit();
            TCN_LanDuplicata.recalculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata), dsParcelas.Position, true);
            TCN_LanDuplicata.recalculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata), dsParcelas.Position, false);
            gParcelas.Refresh();
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Portador|350;" +
                              "CD_Portador|Codigo|80";
            string vParam = "isnull(st_tituloterceiro, 'N')|<>|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                        new TCD_CadPortador(), vParam);
            if (linha != null)
            {
                st_lancarcheque = linha["st_controletitulo"].ToString().Trim().ToUpper().Equals("S");
                st_cartaocredito = Convert.ToInt32(linha["st_cartaocredito"]).Equals(0);
            }
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "isnull(st_tituloterceiro, 'N')|<>|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                    new TCD_CadPortador());
            if (linha != null)
            {
                st_lancarcheque = linha["st_controletitulo"].ToString().Trim().ToUpper().Equals("S");
                st_cartaocredito = Convert.ToInt32(linha["st_cartaocredito"]).Equals(0);
            }
        }

        private void st_comentrada_TextChanged(object sender, EventArgs e)
        {
            cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
            pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
            cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
        }

        private void qt_parcelas_ValueChanged(object sender, EventArgs e)
        {
            cd_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_contager.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            cd_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_portador.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            Vl_desconto.Enabled = qt_parcelas.Value.Equals(0);
            pc_desconto.Enabled = qt_parcelas.Value.Equals(0);
            cd_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
            bb_historico_dup.Enabled = st_comentrada.Text.Trim().ToUpper().Equals("S") || qt_parcelas.Value.Equals(0);
        }

        private void cd_portador_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_portador.Enabled)
            {
                cd_portador.Clear();
                ds_portador.Clear();
            }
        }

        private void cd_contager_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_contager.Enabled)
            {
                cd_contager.Clear();
                ds_contager.Clear();
            }
        }

        private void bb_moedapadrao_Click(object sender, EventArgs e)
        {
            string coluna = "DS_Moeda_Singular|Descrição Moeda|200;CD_Moeda|Cd. Moeda|80;Sigla|Sigla|60";
            UtilPesquisa.BTN_BUSCA(coluna, new Componentes.EditDefault[] { cd_moeda_padrao, ds_moeda_padrao, sigla_moeda_padrao },
                                    new TCD_Moeda(), "");
            BuscarCotacao();
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                if (lParc.Count.Equals(0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                }
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void cd_moeda_padrao_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_Moeda|=|'" + cd_moeda_padrao.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda_padrao, ds_moeda_padrao, sigla_moeda_padrao },
                                    new TCD_Moeda());
            BuscarCotacao();
            ConverterValorMoeda();
            if (dsDuplicata.Current != null)
            {
                if (lParc.Count.Equals(0))
                {
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas.Clear();
                    (dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas = calculaParcelas((dsDuplicata.Current as TRegistro_LanDuplicata));
                }
                dsDuplicata.ResetCurrentItem();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_historico_dup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_dup, ds_historico_dup },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_dup_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_dup.Text.Trim() + "';" +
                              "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_dup, ds_historico_dup },
                                    new TCD_CadHistorico());
        }

        private void TFLanDuplicata_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gParcelas);
        }

        private void cd_avalista_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_avalista.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_avalista, nm_avalista },
                                            new TCD_CadClifor());
        }

        private void bb_avalista_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_avalista, nm_avalista }, string.Empty);
        }

        private void cd_endavalista_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + cd_endavalista.Text + "';" +
                              "a.CD_Clifor|=|'" + cd_avalista.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_endavalista, ds_endavalista },
                                    new TCD_CadEndereco());
        }

        private void bb_endavalista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Descrição Endereço|350;" +
                              "a.CD_Endereco|Cód. Endereço|100";
            string vParamFixo = "a.CD_Clifor|=|'" + cd_avalista.Text + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endavalista, ds_endavalista },
                                    new TCD_CadEndereco(), vParamFixo);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + cd_contager.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "')";
            if (tp_mov.Text.Trim().ToUpper().Equals("P"))
                if (st_lancarcheque)
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            else if (tp_mov.Text.Trim().ToUpper().Equals("R"))
            {
                vColunas += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
                if (st_cartaocredito)
                    vColunas += ";a.st_contacartao|=|0";
                else vColunas += ";a.st_contacartao|<>|0";
            }
            if (string.IsNullOrEmpty(vId_caixa))
                vColunas += ";a.ST_ContaCF|<>|0";

            UtilPesquisa.EDIT_LEAVE(vColunas,
              new Componentes.EditDefault[] { cd_contager, ds_contager },
              new TCD_CadContaGer());
            if ((cd_contager.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.DataCaixa(cd_contager.Text, Convert.ToDateTime(dt_emissao.Text), null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + cd_contager.Text + "\r\n Data: " + dt_emissao.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_emissao.Focus();
                }
            }
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                "where k.CD_ContaGer = a.CD_ContaGer " +
                                "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "')";
            if (tp_mov.Text.Trim().ToUpper().Equals("P"))
                if (st_lancarcheque)
                    vParamFixo += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vParamFixo += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            else if (tp_mov.Text.Trim().ToUpper().Equals("R"))
            {
                vParamFixo += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
                if (st_cartaocredito)
                    vParamFixo += ";a.st_contacartao|=|0";
                else vParamFixo += ";a.st_contacartao|<>|0";
            }
            if (string.IsNullOrEmpty(vId_caixa))
                vParamFixo += ";a.ST_ContaCF|<>|0";

            UtilPesquisa.BTN_BUSCA(vColunas,
                new Componentes.EditDefault[] { cd_contager, ds_contager },
                new TCD_CadContaGer(), vParamFixo);
            if ((cd_contager.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != string.Empty) && (dt_emissao.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.DataCaixa(cd_contager.Text, Convert.ToDateTime(dt_emissao.Text), null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + cd_contager.Text + "\r\n Data: " + dt_emissao.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_emissao.Focus();
                }
            }
        }

        private void bb_devcredito_Click(object sender, EventArgs e)
        {
            DevolverCredito();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            dsParcelas.MoveNext();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            dsParcelas.MovePrevious();
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_configboleto }, new TCD_CadCFGBanco());
        }

        private void bb_configboleto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_configboleto },
                new TCD_CadCFGBanco(), vParam);
        }

        private void bbAddClifor_Click(object sender, EventArgs e)
        {
            using (Cadastros.TFCadCliforResumido fClifor = new Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente/Fornecedor gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                        nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                        cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        tp_duplicata.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if (pc_desconto.Value > decimal.Zero)
            {
                if (pc_desconto.Value * vl_documento.Value / 100 < (vl_documento.Value))
                    Vl_desconto.Value = Math.Round(vl_documento.Value * (pc_desconto.Value / 100), 2, MidpointRounding.AwayFromZero);
                else
                {
                    Vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    pc_desconto.Focus();
                }
            }
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Vl_desconto.Focus();
        }

        private void Vl_desconto_Leave(object sender, EventArgs e)
        {
            if (Vl_desconto.Value > decimal.Zero)
            {
                if (Vl_desconto.Value < (vl_documento.Value))
                    pc_desconto.Value = Math.Round(Vl_desconto.Value * 100 / vl_documento.Value, 2, MidpointRounding.AwayFromZero);
                else
                {
                    Vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    Vl_desconto.Focus();
                }
            }
        }

        private void Vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                pc_desconto.Focus();
        }

        private void Vl_desconto_EnabledChanged(object sender, EventArgs e)
        {
            if (!Vl_desconto.Enabled)
            {
                pc_desconto.Value = decimal.Zero;
                Vl_desconto.Value = decimal.Zero;
            }
        }

        private void pc_desconto_EnabledChanged(object sender, EventArgs e)
        {
            if (!pc_desconto.Enabled)
            {
                pc_desconto.Value = decimal.Zero;
                Vl_desconto.Value = decimal.Zero;
            }
        }
    }
}