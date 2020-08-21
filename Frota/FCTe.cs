using Proc_Commoditties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFCTe : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pId_viagem
        { get; set; }
        public string pId_veiculo
        { get; set; }
        public string pCd_motorista
        { get; set; }
        public decimal pSaldoFaturar
        { get; set; }
        public CamadaDados.Mudanca.TRegistro_LanMudanca rMudança
        { get; set; }

        private CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfg
        { get; set; }
        private CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rcte;
        public CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCte
        {
            get
            {
                if (bsCte.Count > 0)
                    return bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete;
                else
                    return null;
            }
            set { rcte = value; }
        }
        public bool St_duplicarCTe { get; set; }

        public TFCTe()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("RODOVIARIO", "01"));
            cbx.Add(new TDataCombo("AEREO", "02"));
            cbx.Add(new TDataCombo("AQUAVIARIO", "03"));
            cbx.Add(new TDataCombo("FERROVIARIO", "04"));
            cbx.Add(new TDataCombo("DUTOVIARIO", "05"));
            tp_modalidade.DataSource = cbx;
            tp_modalidade.DisplayMember = "Display";
            tp_modalidade.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("NORMAL", "0"));
            cbx1.Add(new TDataCombo("SUBCONTRATAÇÃO", "1"));
            cbx1.Add(new TDataCombo("REDESPACHO", "2"));
            cbx1.Add(new TDataCombo("REDESPACHO INTERMEDIARIO", "3"));
            tp_servico.DataSource = cbx1;
            tp_servico.DisplayMember = "Display";
            tp_servico.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("NORMAL", "0"));
            cbx2.Add(new TDataCombo("COMPLEMENTO DE VALORES", "1"));
            cbx2.Add(new TDataCombo("ANULAÇÃO DE VALORES", "2"));
            cbx2.Add(new TDataCombo("SUBSTITUTO", "3"));
            cbTpCte.DataSource = cbx2;
            cbTpCte.DisplayMember = "Display";
            cbTpCte.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("REMETENTE", "0"));
            cbx3.Add(new TDataCombo("EXPEDIDOR", "1"));
            cbx3.Add(new TDataCombo("RECEBEDOR", "2"));
            cbx3.Add(new TDataCombo("DESTINATARIO", "3"));
            cbx3.Add(new TDataCombo("OUTROS", "4"));
            tp_tomador.DataSource = cbx3;
            tp_tomador.DisplayMember = "Display";
            tp_tomador.ValueMember = "Value";          

            St_duplicarCTe = false;
        }

        private void afterGrava()
        {
            if (bsNfCTe.Count.Equals(0))
            {
                MessageBox.Show("Obrigatório informar documento ser transportado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                return;
            }
            if (bsQtdeCarga.Count.Equals(0))
            {
                MessageBox.Show("Obrigatório informar Dados QTD da carga.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                return;
            }
            if (string.IsNullOrEmpty(cd_cidade_fin.Text))
            {
                MessageBox.Show("Obrigatório informar cidade de destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (string.IsNullOrEmpty(cd_cmi.Text))
            {
                MessageBox.Show("Obrigatório informar CMI.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (string.IsNullOrEmpty(cd_remetente.Text))
            {
                MessageBox.Show("Obrigatório informar remetente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (string.IsNullOrEmpty(cd_endremetente.Text))
            {
                MessageBox.Show("Obrigatório informar endereço remetente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (string.IsNullOrEmpty(cd_destinatario.Text))
            {
                MessageBox.Show("Obrigatório informar destinatário!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (string.IsNullOrEmpty(cd_enddestinatario.Text))
            {
                MessageBox.Show("Obrigatório informar endereço destinatário!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!tcCentral.SelectedTab.Equals(tpDados))
                    tcCentral.SelectedTab = tpDados;
                return;
            }
            if (tp_tomador.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório informar tomador do serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                tp_tomador.Focus();
                return;
            }
            if(tp_tomador.SelectedValue.ToString().Equals("4") &&
                string.IsNullOrEmpty(cd_tomador.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente tomador do serviço para tipo tomador <OUTROS>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                cd_tomador.Focus();
                return;
            }
            if(tp_tomador.SelectedValue.ToString().Equals("4") &&
                string.IsNullOrEmpty(cd_endtomador.Text))
            {
                MessageBox.Show("Obrigatório informar endereço do tomador para tipo tomador <OUTROS>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                cd_endtomador.Focus();
                return;
            }
            if(!cbTpCte.SelectedValue.ToString().Equals("0") &&
                string.IsNullOrWhiteSpace(chaveacessocteref.Text))
            {
                MessageBox.Show("Obrigatório informar CT-e referenciado quando tipo CT-e for diferente de NORMAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chaveacessocteref.Focus();
                return;
            }
            if (!tp_servico.SelectedValue.ToString().Equals("0") &&
                string.IsNullOrWhiteSpace(chaveacessocteref.Text))
            {
                MessageBox.Show("Obrigatório informar CT-e referenciado quando tipo Serviço for diferente de NORMAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chaveacessocteref.Focus();
                return;
            }
            if (!tp_servico.SelectedValue.ToString().Equals("0") &&
                string.IsNullOrWhiteSpace(cd_cliforCTeRef.Text))
            {
                MessageBox.Show("Obrigatório informar Emitente CT-e referenciado quando tipo Serviço for diferente de NORMAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chaveacessocteref.Focus();
                return;
            }
            if (!cbTpCte.SelectedValue.ToString().Equals("1") && vl_frete.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor do frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                vl_frete.Focus();
                return;
            }
            if(vl_carga.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor da carga.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                vl_carga.Focus();
                return;
            }
            if(string.IsNullOrEmpty(Produto_predominante.Text))
            {
                MessageBox.Show("Obrigatório informar produto predominante.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                Produto_predominante.Focus();
                return;
            }
            if(string.IsNullOrEmpty(OutrasCaracCarga.Text))
            {
                MessageBox.Show("Obrigatório informar outras caracteristicas da carga.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!tcCentral.SelectedTab.Equals(tpDadosComp))
                    tcCentral.SelectedTab = tpDadosComp;
                OutrasCaracCarga.Focus();
                return;
            }
            if (!(bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos.Exists(p=> p.Imposto.St_ICMS) &&
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(string.Empty, (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_serie, null))
            {
                //Buscar Imposto ICMS
                object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                           new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "st_icms",
                                            vOperador = "=",
                                            vVL_Busca = "1"
                                        }
                                    }, "a.cd_imposto");
                if (obj == null)
                {
                    MessageBox.Show("Não existe imposto cadastrado como ICMS!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCadICMS fIcms = new TFCadICMS()) 
                {
                    fIcms.Cd_imposto = obj.ToString();
                    if (fIcms.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fIcms.Cd_st))
                            try
                            {
                                List<CamadaDados.Fiscal.TRegistro_CadMovimentacao> lMov = new List<CamadaDados.Fiscal.TRegistro_CadMovimentacao>();
                                List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfOrig = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf>();
                                List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfDest = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf>();
                                CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS val = new CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS();
                                val.Cd_empresa = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                val.Tp_movimento = "S";
                                val.Cd_impostostr = obj.ToString();
                                val.Cd_st = fIcms.Cd_st;
                                val.Pc_aliquota_icms = fIcms.pAliquota;
                                val.Pc_aliquota_icmsDest = fIcms.pAliquotaDest;
                                val.Tp_modbasecalc = "0";
                                val.Tp_modbasecalcST = "4";
                                val.Cd_condfiscal_clifor = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("0") ?
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_remetente :
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("1") ?
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_expedidor :
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("2") ?
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_recebedor :
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("3") ?
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_destinatario :
                                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_tomador;
                                lMov.Add(new CamadaDados.Fiscal.TRegistro_CadMovimentacao() { Cd_movimentacaostr = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacaostr });
                                lUfDest.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadUf() { Cd_uf = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin });
                                lUfOrig.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadUf() { Cd_uf = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini });

                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(val,
                                                                                  lMov,
                                                                                  lUfOrig,
                                                                                  lUfDest,
                                                                                  null);
                                BuscarImpostos();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                        {
                            MessageBox.Show("Obrigatório gravar ICMS para gerar o CTe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Obrigatório gravar ICMS para gerar o CTe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void BuscarEmitente()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar clifor transportadora
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_div_empresa x " +
                                        "where x.cd_clifor = a.cd_clifor " +
                                        "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                        }
                    }, 0, string.Empty);
                if (lClifor.Count > 0)
                {
                    cd_transportadora.Text = lClifor[0].Cd_clifor;
                    nm_transportadora.Text = lClifor[0].Nm_clifor;
                    cnpj_transp.Text = lClifor[0].Nr_cgc;
                    cd_condfiscal_transp.Text = lClifor[0].Cd_condfiscal_clifor;
                }
                //Buscar endereco transportadora
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_div_empresa x " +
                                        "where x.cd_clifor = a.cd_clifor " +
                                        "and x.cd_endereco = a.cd_endereco " +
                                        "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                        }
                    }, 0, string.Empty);
                if (lEnd.Count > 0)
                {
                    cd_endtransportadora.Text = lEnd[0].Cd_endereco;
                    ds_endtransportadora.Text = lEnd[0].Ds_endereco;
                    cd_uf_transportadora.Text = lEnd[0].Cd_uf;
                    uf_transportadora.Text = lEnd[0].UF;
                    insc_estadual_transp.Text = lEnd[0].Insc_estadual;
                }
            }
        }

        private void BuscarCfgFrota()
        {
            if (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa))
            {
                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacaostr = lCfg[0].Cd_movctestr;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_movimentacao = lCfg[0].Ds_movimentacao;
                    //Buscar CMI Padrao
                    if (string.IsNullOrEmpty(lCfg[0].Cd_movctestr))
                    {
                        MessageBox.Show("Na configuração de frota, não foi informado o tipo de movimentação, necessário atualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CamadaDados.Fiscal.TList_CadMov_x_CMI lCmi =
                        new CamadaDados.Fiscal.TCD_CadMov_x_CMI().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_movimentacao",
                                    vOperador = "=",
                                    vVL_Busca = (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacaostr
                                }
                            }, 1, string.Empty);
                    if (lCmi.Count > 0)
                    {
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cmistr = lCmi[0].CD_CMIString;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cmi = lCmi[0].ds_cmi;
                    }
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_serie = lCfg[0].Nr_seriecte;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_serienf = lCfg[0].Ds_seriecte;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_modelo = lCfg[0].Cd_modelocte;
                    nr_ctrc.Enabled = !lCfg[0].St_sequenciaauto;
                    if (!string.IsNullOrEmpty(lCfg[0].Tp_tomadordef))
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador = lCfg[0].Tp_tomadordef;
                }
            }
        }

        private void BuscarCFOP()
        {
            if ((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacao.HasValue)
            {
                //Buscar CFOP Movimentacao
                CamadaDados.Fiscal.TList_Mov_X_CFOP lMovCfop =
                    CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacaostr,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               null);
                if (lMovCfop.Count > 0)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cfop = 
                        cd_uf_ini.Text.Trim().Equals(cd_uf_fin.Text.Trim()) ?
                        lMovCfop[0].Cd_cfop_dentroestado : lMovCfop[0].Cd_cfop_foraestado;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cfop = 
                        cd_uf_ini.Text.Trim().Equals(cd_uf_fin.Text.Trim()) ?
                        lMovCfop[0].Ds_cfop_dentroestado : lMovCfop[0].Ds_cfop_foraestado;
                    bsCte.ResetCurrentItem();
                }
                else
                    MessageBox.Show("Não existe CFOP configurado para movimentação " + cd_movimentacao.Text, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InserirDocumentoCTe(bool St_nfe)
        {
            if(bsCte.Current != null)
                using (TFDocumentoCTe fDoc = new TFDocumentoCTe())
                {
                    fDoc.St_nfe = St_nfe;
                    fDoc.Tp_cte = cbTpCte.SelectedValue.ToString(); ;
                    if (fDoc.ShowDialog() == DialogResult.OK)
                    {
                        if ((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTe.Exists(p => p.Chave_acesso_nfe.Equals(fDoc.rDoc.Chave_acesso_nfe)))
                        {
                            MessageBox.Show("Chave de acesso já adicionada neste CT-e!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTe.Add(fDoc.rDoc);
                        bsCte.ResetCurrentItem();
                    }
                }
        }
                
        private void ExcluirDocumentoCTe()
        {
            if(bsNfCTe.Current != null)
                if (MessageBox.Show("Confirma exclusão documento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTeDel.Add(bsNfCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal);
                    bsNfCTe.RemoveCurrent();
                }
        }

        private void InserirQtde()
        {
            if(bsCte.Current != null)
                using (TFQtdeCarga fQtde = new TFQtdeCarga())
                {
                    if (fQtde.ShowDialog() == DialogResult.OK)
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lQtdeCarga.Add(fQtde.rQtde);
                    bsCte.ResetCurrentItem();
                }
        }

        private void ExcluirQtde()
        {
            if(bsQtdeCarga.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lQtdeCargaDel.Add(bsQtdeCarga.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga);
                    bsQtdeCarga.RemoveCurrent();
                }
        }

        private void InserirCompValorFrete()
        {
            if(bsCte.Current != null)
                using (TFCompValorFrete fComp = new TFCompValorFrete())
                {
                    if (fComp.ShowDialog() == DialogResult.OK)
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lCompValorFrete.Add(fComp.rComp);
                    bsCte.ResetCurrentItem();
                }
        }

        private void ExcluirCompValorFrete()
        {
            if(bsCompValorFrete.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lCompValorFreteDel.Add(bsCompValorFrete.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete);
                    bsCompValorFrete.RemoveCurrent();
                }
        }

        private void InserirOrdemColeta()
        {
            using (TFOrdemColeta fOrdem = new TFOrdemColeta())
            {
                if(fOrdem.ShowDialog() == DialogResult.OK)
                    if (fOrdem.rOrdem != null)
                    {
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lOrdemColeta.Add(fOrdem.rOrdem);
                        bsCte.ResetCurrentItem();
                    }
            }
        }

        private void AlterarOrdemColeta()
        {
            if (bsOrdemColeta.Current != null)
                using (TFOrdemColeta fOrdem = new TFOrdemColeta())
                {
                    CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta rCopia = new CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta();
                    rCopia.Cd_clifor = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cd_clifor;
                    rCopia.Nm_clifor = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nm_clifor;
                    rCopia.Cnpj_clifor = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cnpj_clifor;
                    rCopia.Cd_endereco = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cd_endereco;
                    rCopia.Ds_endereco = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Ds_endereco;
                    rCopia.Uf = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Uf;
                    rCopia.Nr_serie = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nr_serie;
                    rCopia.Nr_ordem = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nr_ordem;
                    rCopia.Dt_emissao = (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Dt_emissao;
                    fOrdem.rOrdem = bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta;
                    if (fOrdem.ShowDialog() != DialogResult.OK)
                    {
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cd_clifor = rCopia.Cd_clifor;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nm_clifor = rCopia.Nm_clifor;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cnpj_clifor = rCopia.Cnpj_clifor;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Cd_endereco = rCopia.Cd_endereco;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Ds_endereco = rCopia.Ds_endereco;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Uf = rCopia.Uf;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nr_serie = rCopia.Nr_serie;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Nr_ordem = rCopia.Nr_ordem;
                        (bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta).Dt_emissao = rCopia.Dt_emissao;
                        bsOrdemColeta.ResetCurrentItem();
                    }
                } 
        }

        private void ExcluirOrdemColeta()
        {
            if(bsOrdemColeta.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro corrente?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lOrdemColetadel.Add(
                        bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta);
                    bsOrdemColeta.RemoveCurrent();
                }
        }

        private void BuscarImpostos()
        {
            if ((!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_transportadora)) &&
                ((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("0") ?
                 (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_remetente)) :
                 (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("1") ?
                 (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_expedidor)) :
                 (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("2") ?
                 (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_recebedor)) :
                 (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("3") ?
                 (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_destinatario)) :
                 (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_tomador))) &&
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacao.HasValue &&
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Dt_emissao.HasValue &&
                (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini)) &&
                (!string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin)))
            {
                string vObsFiscal = string.Empty;
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpostos =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini,
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin,
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_movimentacaostr,
                                                                                                      "S",
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("0") ? 
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_remetente : 
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("1") ?
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_expedidor :
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("2") ?
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_recebedor :
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_tomador.Equals("3") ?
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_destinatario :
                                                                                                         (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_tomador,
                                                                                                      string.Empty,
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete,
                                                                                                      decimal.Zero,
                                                                                                      ref vObsFiscal,
                                                                                                      (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Dt_emissao.Value,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                if (lImpostos.Count > 0)
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_ICMS = lImpostos.Sum(p => p.Vl_impostocalc);
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar = lImpostos.Where(p => p.St_somaricmsbase).Sum(p => p.Vl_impostocalc);
                    if(rcte == null)
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_receber =
                            (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete +
                            (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos.Concat(lImpostos);
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Obsfiscal +=
                        string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                    bsCte.ResetCurrentItem();
                }
                else
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_ICMS = lImpostos.Sum(p => p.Vl_impostocalc);
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar = lImpostos.Where(p => p.St_somaricmsbase).Sum(p => p.Vl_impostocalc);
                    if(rcte == null)
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_receber =
                            (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete +
                            (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar;
                    if (bsImpostosCtrc.Count > 0)
                        bsImpostosCtrc.RemoveCurrent();
                    bsCte.ResetCurrentItem();
                }
            }
        }

        private void ImportNfe(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            using (TFImportarNFeCTe fImport = new TFImportarNFeCTe())
            {
                fImport.File_xml = path;
                if (fImport.ShowDialog() == DialogResult.OK)
                {
                    if (cbTpCte.SelectedValue.ToString().ToUpper().Trim().Equals("0"))
                    {
                        //Verificar se chave de acesso ja possui CTe Emitido
                        object nr_cte = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().BuscarEscalar(
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
                                                            vVL_Busca = "(select 1 from tb_ctr_notafiscal x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                                        "and x.chave_acesso_nfe = '" + fImport.Chave_acesso_nfe.Trim() + "')"
                                                        }
                                                    }, "a.NR_CTRC");
                        if (nr_cte != null)
                        {
                            MessageBox.Show("NF-e ja transportada pelo CTe Nº" + nr_cte.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    //Remetente
                    if (!string.IsNullOrEmpty(fImport.Cd_remetente))
                    {
                        cd_remetente.Text = fImport.Cd_remetente;
                        cd_remetente_Leave(this, new EventArgs());
                    }
                    //Endereco Remetente
                    if (!string.IsNullOrEmpty(fImport.Cd_endremetente))
                    {
                        cd_endremetente.Text = fImport.Cd_endremetente;
                        cd_endremetente_Leave(this, new EventArgs());
                    }
                    //Destinatario
                    if (!string.IsNullOrEmpty(fImport.Cd_destinatario))
                    {
                        cd_destinatario.Text = fImport.Cd_destinatario;
                        cd_destinatario_Leave(this, new EventArgs());
                    }
                    //Endereco Destinatario
                    if (!string.IsNullOrEmpty(fImport.Cd_enddestinatario))
                    {
                        cd_enddestinatario.Text = fImport.Cd_enddestinatario;
                        cd_enddestinatario_Leave(this, new EventArgs());
                    }
                    if (!string.IsNullOrEmpty(fImport.Chave_acesso_nfe))
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTe.Add(
                            new CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal() { Chave_acesso_nfe = fImport.Chave_acesso_nfe });
                    //Produto Predominante
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_prodpredominante = fImport.Produto_predominante;
                    //Valor Carga
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_carga = fImport.Valor_carga;
                    if ((fImport.Qtd_carga > decimal.Zero) && !string.IsNullOrEmpty(fImport.Sigla_unidade))
                    {
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lQtdeCarga.Add(
                            new CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga()
                            {
                                cUnid = fImport.Sigla_unidade.Trim().ToUpper().Equals("M3") ? "00" :
                                        fImport.Sigla_unidade.Trim().ToUpper().Equals("KG") ? "01" :
                                        fImport.Sigla_unidade.Trim().ToUpper().Equals("TON") ? "02" :
                                        fImport.Sigla_unidade.Trim().ToUpper().Equals("LT") ? "04" : "03",
                                Tp_medida = fImport.Sigla_unidade,
                                Qt_carga = fImport.Qtd_carga
                            });
                        if (rCfg != null)
                            if ((rCfg.Vl_unitfrete > decimal.Zero) &&
                                (fImport.Sigla_unidade.Trim().ToUpper().Equals("M3") ? "00" :
                                fImport.Sigla_unidade.Trim().ToUpper().Equals("KG") ? "01" :
                                fImport.Sigla_unidade.Trim().ToUpper().Equals("TON") ? "02" :
                                fImport.Sigla_unidade.Trim().ToUpper().Equals("LT") ? "04" : "03").Equals(rCfg.Tp_unidfrete.Trim()))
                                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete = Math.Round(fImport.Qtd_carga * rCfg.Vl_unitfrete, 2);
                    }
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).OutrasCaracCarga = rCfg != null ? rCfg.OutrasCaracCarga : string.Empty;
                    bsCte.ResetCurrentItem();
                    //Movimentacao
                    if (rCfg != null)
                    {
                        cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                        ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                    }
                    //Buscar CFOP
                    BuscarCFOP();
                    //Buscar Impostos
                    BuscarImpostos();
                    if (!System.IO.Directory.Exists(SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                        System.IO.Directory.CreateDirectory(SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                    if (!System.IO.File.Exists(SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" +
                        System.IO.Path.DirectorySeparatorChar.ToString() + path.Substring(path.LastIndexOf("\\"), path.Trim().Length - path.LastIndexOf("\\"))))
                        System.IO.File.Move(path,
                            SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" +
                            System.IO.Path.DirectorySeparatorChar.ToString() + path.Substring(path.LastIndexOf("\\"), path.Trim().Length - path.LastIndexOf("\\")));
                }
            }
        }

        private void CalcularICMS(bool St_valor = false)
        {
            if (vlBaseCalcICMS.Value > decimal.Zero)
            {
                decimal basecalc = vlBaseCalcICMS.Value;
                if (pReducaoBC.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pReducaoBC.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vlICMS.Value > decimal.Zero)
                    pAliquotaICMS.Value = Math.Round(decimal.Multiply(decimal.Divide(vlICMS.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pAliquotaICMS.Value > decimal.Zero)
                    vlICMS.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pAliquotaICMS.Value, 100)), 2, MidpointRounding.AwayFromZero);
                bsImpostosCtrc.ResetBindings(true);
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_ICMS = (bsImpostosCtrc.List as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostocalc);
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar = (bsImpostosCtrc.List as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Where(p => p.St_somaricmsbase).Sum(p => p.Vl_impostocalc);
                if (rcte == null)
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_receber =
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete +
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_icmssomar;
                bsCte.ResetCurrentItem();
            }
        }

        private void TFCTe_Load(object sender, EventArgs e)
        {
            //Deixar Barras sempre visiveis
            ts_Frete.Visible = true;
            tsCarga.Visible = true;
            tsCompFrete.Visible = true;
            tsOrdemColeta.Visible = true;

            Icon = ResourcesUtils.TecnoAliance_ICO;
            pCte.set_FormatZero();
            pComplementar.set_FormatZero();
            pRemetente.set_FormatZero();
            pExpedidor.set_FormatZero();
            pDestinatario.set_FormatZero();
            if (rcte != null)
            {
                if (St_duplicarCTe)
                {
                    rcte.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rcte.Nr_lanctoCTRC = null;
                    rcte.Nr_ctrc = null;
                    rcte.lQtdeCarga.ForEach(p =>
                    {
                        p.Nr_lanctoCTR = null;
                        p.Cd_empresa = string.Empty;
                    });
                    rcte.lCompValorFrete.ForEach(p =>
                    {
                        p.Nr_lanctoctr = null;
                        p.Cd_empresa = string.Empty;
                    });
                    rcte.lImpostos.Clear();
                    rcte.lOrdemColeta.ForEach(p =>
                    {
                        p.Nr_lanctoctr = null;
                        p.Cd_empresa = string.Empty;
                    });
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_serie",
                                vOperador = "=",
                                vVL_Busca = "'" + rcte.Nr_serie.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_modelo",
                                vOperador = "=",
                                vVL_Busca = "'" + rcte.Cd_modelo.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_sequenciaauto, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") != null)
                        nr_ctrc.Enabled = false;
                    rcte.St_registro = "A";
                }
                else
                {
                    vl_frete.Enabled = false;
                    if (rcte.lImpostos.Count > 0)
                        rcte.lImpostos.ForEach(p => rcte.lImpDel.Add(p));
                }
                bsCte.DataSource = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete() { rcte };
                lblChaveRef.Visible = cbTpCte.SelectedIndex > 0;
                chaveacessocteref.Visible = cbTpCte.SelectedIndex > 0;
                bb_lanctoctrref.Visible = cbTpCte.SelectedIndex > 0;
                lblCliforRef.Visible = cbTpCte.SelectedIndex > 0;
                cd_cliforCTeRef.Visible = cbTpCte.SelectedIndex > 0;
                bb_cliforcteref.Visible = cbTpCte.SelectedIndex > 0;
                nm_cliforcteref.Visible = cbTpCte.SelectedIndex > 0;
                lblChAcessoNFeTom.Visible = cbTpCte.SelectedIndex.Equals(3);
                ch_acessonfetom.Visible = cbTpCte.SelectedIndex.Equals(3);
                vlBaseCalcICMS.Enabled = vl_frete.Value.Equals(decimal.Zero);
            }
            else
                bsCte.AddNew();
            if (!string.IsNullOrEmpty(pCd_empresa))
            {
                cd_empresa.Text = pCd_empresa;
                cd_empresa_Leave(this, new EventArgs());
            }
            if (!string.IsNullOrEmpty(pId_viagem))
            {
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Id_viagemstr = pId_viagem;
                //Buscar rota
                CamadaDados.Frota.Cadastros.TList_RotaFrete lRota =
                    CamadaNegocio.Frota.TCN_Viagem_X_Rota.BuscarRotas(cd_empresa.Text, pId_viagem, null);
                if (lRota.Count.Equals(1))
                {
                    //Origem
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_ini = lRota[0].Cd_cidade_origem;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_ini = lRota[0].Ds_cidade_origem;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini = lRota[0].Cd_uf_origem;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_ini = lRota[0].Uf_origem;
                    //Destino
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_fin = lRota[0].Cd_cidade_destino;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_fin = lRota[0].Ds_cidade_destino;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin = lRota[0].Cd_uf_destino;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_fin = lRota[0].Uf_destino;
                }
            }
            if (rMudança != null)
            {
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Id_mudancastr = rMudança.Id_mudancastr;
                //Remetente
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_remetente = string.IsNullOrEmpty(rMudança.Cd_remetente) ? rMudança.Cd_clifor : rMudança.Cd_remetente;
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nm_remetente = string.IsNullOrEmpty(rMudança.Nm_remetente) ? rMudança.Nm_clifor : rMudança.Nm_remetente;
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_remetente = string.IsNullOrEmpty(rMudança.Cd_CondFiscalRemetente) ? rMudança.Cd_condFiscal_Clifor : rMudança.Cd_CondFiscalRemetente;
                if (!string.IsNullOrEmpty(rMudança.Cd_remetente))
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente = rMudança.Cd_endremetente;
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndRem =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_remetente,
                                                                              (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente,
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
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_endremetente = rEndRem.Ds_endereco;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numeroremetente = rEndRem.Numero;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidaderemetente = rEndRem.DS_Cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_remetente = rEndRem.Cd_uf;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_remetente = rEndRem.UF;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_ini = rEndRem.Cd_cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_ini = rEndRem.DS_Cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini = rEndRem.Cd_uf;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_ini = rEndRem.UF;
                }
                else
                {
                    //Verificar se endereço coleta esta cadastrado para o cliente
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rMudança.Cd_clifor,
                                                                                  string.Empty,
                                                                                  rMudança.Logradouro_Orig.Trim(),
                                                                                  rMudança.CD_Cidade_Orig.Trim(),
                                                                                  rMudança.Numero_Orig.Trim(),
                                                                                  rMudança.Bairro_Orig.Trim(),
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
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente = lEnd[0].Cd_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_endremetente = lEnd[0].Ds_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numeroremetente = lEnd[0].Numero;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidaderemetente = lEnd[0].DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_remetente = lEnd[0].Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_remetente = lEnd[0].UF;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_ini = lEnd[0].Cd_cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_ini = lEnd[0].DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini = lEnd[0].Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_ini = lEnd[0].UF;

                    }
                    else
                    {
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente = rMudança.Cd_endereco;
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndRem =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_remetente,
                                                                                  (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente,
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
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_endremetente = rEndRem.Ds_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numeroremetente = rEndRem.Numero;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidaderemetente = rEndRem.DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_remetente = rEndRem.Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_remetente = rEndRem.UF;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_ini = rEndRem.Cd_cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_ini = rEndRem.DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini = rEndRem.Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_ini = rEndRem.UF;
                    }
                }
                //Destinatário
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_destinatario = string.IsNullOrEmpty(rMudança.Cd_destinatario) ? rMudança.Cd_clifor : rMudança.Cd_destinatario;
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nm_destinatario = string.IsNullOrEmpty(rMudança.Nm_destinatario) ? rMudança.Nm_clifor : rMudança.Nm_destinatario;
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_condfiscal_destinatario = string.IsNullOrEmpty(rMudança.Cd_CondFiscalDestinatario) ? rMudança.Cd_condFiscal_Clifor : rMudança.Cd_CondFiscalDestinatario;
                if (!string.IsNullOrEmpty(rMudança.Cd_destinatario))
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_enddestinatario = rMudança.Cd_enddestinatario;
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndDest =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_destinatario,
                                                                              (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_enddestinatario,
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
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_enddestinatario = rEndDest.Ds_endereco;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numerodestinatario = rEndDest.Numero;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidadedestinatario = rEndDest.DS_Cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_destinatario = rEndDest.Cd_uf;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_destinatario = rEndDest.UF;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_fin = rEndDest.Cd_cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_fin = rEndDest.DS_Cidade;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin = rEndDest.Cd_uf;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_fin = rEndDest.UF;
                }
                else
                {
                    //Verificar se endereço entrega esta cadastrado para o cliente
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rMudança.Cd_clifor,
                                                                                  string.Empty,
                                                                                  rMudança.Logradouro_Dest.Trim(),
                                                                                  rMudança.CD_Cidade_Dest.Trim(),
                                                                                  rMudança.Numero_Dest.Trim(),
                                                                                  rMudança.Bairro_Dest.Trim(),
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
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_enddestinatario = lEnd[0].Cd_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_enddestinatario = lEnd[0].Ds_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numerodestinatario = lEnd[0].Numero;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidadedestinatario = lEnd[0].DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_destinatario = lEnd[0].Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_destinatario = lEnd[0].UF;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_fin = lEnd[0].Cd_cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_fin = lEnd[0].DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin = lEnd[0].Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_fin = lEnd[0].UF;
                    }
                    else
                    {
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_enddestinatario = rMudança.Cd_endereco;
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndDest =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_remetente,
                                                                                  (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_endremetente,
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
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_enddestinatario = rEndDest.Ds_endereco;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numerodestinatario = rEndDest.Numero;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidadedestinatario = rEndDest.DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_destinatario = rEndDest.Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_destinatario = rEndDest.UF;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_fin = rEndDest.Cd_cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_fin = rEndDest.DS_Cidade;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin = rEndDest.Cd_uf;
                        (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_fin = rEndDest.UF;
                    }
                }
                //Local de coleta
                if (((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_endremetente.Trim().ToUpper() != rMudança.Logradouro_Orig.Trim().ToUpper()) &&
                    ((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numeroremetente.Trim() != rMudança.Numero_Orig.Trim()))
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_observacoes =
                        "Coleta: " + rMudança.Logradouro_Orig.Trim() + ", " + rMudança.Numero_Orig.Trim() + ", " + rMudança.Bairro_Orig.Trim() + ", " +
                        rMudança.DS_Cidade_Orig.Trim() + ", " + rMudança.UfOrig.Trim();
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_ini = rMudança.CD_Cidade_Orig;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_ini = rMudança.DS_Cidade_Orig;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_ini = rMudança.CD_UfOrig;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_ini = rMudança.UfOrig;
                }
                //Local Entrega
                if (((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_enddestinatario.Trim().ToUpper() != rMudança.Logradouro_Dest.Trim().ToUpper()) &&
                    ((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Numerodestinatario.Trim() != rMudança.Numero_Dest.Trim()))
                {
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_observacoes =
                        (string.IsNullOrEmpty((bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_observacoes) ? string.Empty : "\r\n") +
                        "Entrega: " + rMudança.Logradouro_Dest.Trim() + ", " + rMudança.Numero_Dest.Trim() + ", " + rMudança.Bairro_Dest.Trim() + ", " +
                        rMudança.DS_Cidade_Dest.Trim() + ", " + rMudança.UfDest.Trim();
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_cidade_fin = rMudança.CD_Cidade_Dest;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Ds_cidade_fin = rMudança.DS_Cidade_Dest;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_uf_fin = rMudança.CD_UfDest;
                    (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Uf_fin = rMudança.UfDest;
                }
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete = rMudança.Vl_mudanca - rMudança.TotalFaturado;
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_carga = rMudança.Tot_Seguro;
                //Documentos Transportados
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTe.Add(
                    new CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal()
                    {
                        Tp_documento = "99",

                        Ds_documento = "FICHA MUDANÇA",
                        Vl_documento = rMudança.Vl_mudanca
                    });
                //Quantidade Carga
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lQtdeCarga.Add(
                    new CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga()
                    {
                        cUnid = "00",
                        Tp_medida = "M3",
                        Qt_carga = rMudança.Tot_MTCub
                    });
                bsCte.ResetCurrentItem();
            }
            if (rCfg != null)
            {
                cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
            }
            BuscarCFOP();
            BuscarImpostos();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            BuscarEmitente();
            BuscarCfgFrota();
            BuscarCFOP();
            BuscarImpostos();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            BuscarEmitente();
            BuscarCfgFrota();
            BuscarCFOP();
            BuscarImpostos();
        }

        private void bb_remetente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_remetente, nm_remetente, cd_condfiscal_Remetente }, string.Empty);
            if (!string.IsNullOrEmpty(cd_remetente.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_remetente.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endremetente.Text = lEnd[0].Cd_endereco;
                    ds_endremetente.Text = lEnd[0].Ds_endereco;
                    cd_uf_remetente.Text = lEnd[0].Cd_uf;
                    uf_remetente.Text = lEnd[0].UF;
                    cd_cidade_ini.Text = lEnd[0].Cd_cidade;
                    ds_cidade_ini.Text = lEnd[0].DS_Cidade;
                    cd_uf_ini.Text = lEnd[0].Cd_uf;
                    uf_ini.Text = lEnd[0].UF;

                    if (rCfg != null)
                    {
                        cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                        ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                    }
                    BuscarCFOP();
                    BuscarImpostos();
                }
            }
        }

        private void cd_remetente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_remetente, nm_remetente, cd_condfiscal_Remetente }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_remetente.Text))
            {
              //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_remetente.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endremetente.Text = lEnd[0].Cd_endereco;
                    ds_endremetente.Text = lEnd[0].Ds_endereco;
                    cd_uf_remetente.Text = lEnd[0].Cd_uf;
                    uf_remetente.Text = lEnd[0].UF;
                    cd_cidade_ini.Text = lEnd[0].Cd_cidade;
                    ds_cidade_ini.Text = lEnd[0].DS_Cidade;
                    cd_uf_ini.Text = lEnd[0].Cd_uf;
                    uf_ini.Text = lEnd[0].UF;

                    if (rCfg != null)
                    {
                        cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                        ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                    }
                    BuscarCFOP();
                    BuscarImpostos();
                }
            }
        }

        private void bb_endremetente_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { cd_endremetente, ds_endremetente, ds_cidaderemetente, cd_uf_remetente, uf_remetente },
                                "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'");
            if (linha != null)
            {
                cd_cidade_ini.Text = linha["cd_cidade"].ToString();
                ds_cidade_ini.Text = linha["ds_cidade"].ToString();
                cd_uf_ini.Text = linha["cd_uf"].ToString();
                uf_ini.Text = linha["uf"].ToString();
                if (rCfg != null)
                {
                    cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                    ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                }
            }
            BuscarCFOP();
            BuscarImpostos();
        }

        private void cd_endremetente_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endremetente.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endremetente, ds_endremetente, ds_cidaderemetente, cd_uf_remetente, uf_remetente },
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (linha != null)
            {
                cd_cidade_ini.Text = linha["cd_cidade"].ToString();
                ds_cidade_ini.Text = linha["ds_cidade"].ToString();
                cd_uf_ini.Text = linha["cd_uf"].ToString();
                uf_ini.Text = linha["uf"].ToString();
                if (rCfg != null)
                {
                    cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                    ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                }
            }
            BuscarCFOP();
            BuscarImpostos();
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario, nm_destinatario, cd_condfiscal_dest }, string.Empty);
            if (!string.IsNullOrEmpty(cd_destinatario.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                     new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_destinatario.Text.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_enddestinatario.Text = lEnd[0].Cd_endereco;
                    ds_enddestinatario.Text = lEnd[0].Ds_endereco;
                    cd_uf_destinatario.Text = lEnd[0].Cd_uf;
                    uf_destinatario.Text = lEnd[0].UF;
                    cd_cidade_fin.Text = lEnd[0].Cd_cidade;
                    ds_cidade_fin.Text = lEnd[0].DS_Cidade;
                    cd_uf_fin.Text = lEnd[0].Cd_uf;
                    uf_fin.Text = lEnd[0].UF;

                    if (rCfg != null)
                    {
                        cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                        cd_movimentacao_Leave(this, new EventArgs());
                    }
                    BuscarCFOP();
                    BuscarImpostos();
                }
            }
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_destinatario, nm_destinatario, cd_condfiscal_dest },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_destinatario.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                     new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_destinatario.Text.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_enddestinatario.Text = lEnd[0].Cd_endereco;
                    ds_enddestinatario.Text = lEnd[0].Ds_endereco;
                    cd_uf_destinatario.Text = lEnd[0].Cd_uf;
                    uf_destinatario.Text = lEnd[0].UF;
                    cd_cidade_fin.Text = lEnd[0].Cd_cidade;
                    ds_cidade_fin.Text = lEnd[0].DS_Cidade;
                    cd_uf_fin.Text = lEnd[0].Cd_uf;
                    uf_fin.Text = lEnd[0].UF;

                    if (rCfg != null)
                    {
                        cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                        ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                    }
                    BuscarCFOP();
                    BuscarImpostos();
                }
            }
        }

        private void bb_enddestinatario_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, ds_cidadedestinatario, cd_uf_destinatario, uf_destinatario },
                                "a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'");
            if (linha != null)
            {
                cd_cidade_fin.Text = linha["cd_cidade"].ToString();
                ds_cidade_fin.Text = linha["ds_cidade"].ToString();
                cd_uf_fin.Text = linha["cd_uf"].ToString();
                uf_fin.Text = linha["uf"].ToString();
                if (rCfg != null)
                {
                    cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                    ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                }
                BuscarCFOP();
                BuscarImpostos();
            }
        }

        private void cd_enddestinatario_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "';" +
                                                              "a.cd_endereco|=|'" + cd_enddestinatario.Text.Trim() + "'",
                                                              new Componentes.EditDefault[] { cd_enddestinatario, ds_enddestinatario, ds_cidadedestinatario, cd_uf_destinatario, uf_destinatario },
                                                              new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (linha != null)
            {
                cd_cidade_fin.Text = linha["cd_cidade"].ToString();
                ds_cidade_fin.Text = linha["ds_cidade"].ToString();
                cd_uf_fin.Text = linha["cd_uf"].ToString();
                uf_fin.Text = linha["uf"].ToString();
                if (rCfg != null)
                {
                    cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                    ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
                }
                BuscarCFOP();
                BuscarImpostos();
            }
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Movimentacao|Movimentação Comercial|200;" +
                              "a.CD_Movimentacao|Codigo|80";
            string vParam = "a.tp_movimento|=|'S'";
            if (!string.IsNullOrEmpty(cd_cmi.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_movimentacao = a.cd_movimentacao " +
                          "and x.cd_cmi = " + cd_cmi.Text + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), vParam);
            BuscarCFOP();
            BuscarImpostos();
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "';" +
                            "a.tp_movimento|=|'S'";
            if (!string.IsNullOrEmpty(cd_cmi.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_movimentacao = a.cd_movimentacao " +
                          "and x.cd_cmi = " + cd_cmi.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao());
            BuscarCFOP();
            BuscarImpostos();
        }

        private void bb_cmi_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cmi|CMI|200;" +
                              "a.cd_cmi|Codigo|60";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_movimentacao.Text))
                vParam = "|exists|(select 1 from tb_fis_mov_x_cmi x " +
                         "where x.cd_cmi = a.cd_cmi " +
                         "and x.cd_movimentacao = " + cd_movimentacao.Text + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cmi, ds_cmi },
                new CamadaDados.Fiscal.TCD_CadCMI(), vParam);
        }

        private void cd_cmi_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cmi|=|" + cd_cmi.Text;
            if (!string.IsNullOrEmpty(cd_movimentacao.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_cmi = a.cd_cmi " +
                          "and x.cd_movimentacao = " + cd_movimentacao.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cmi, ds_cmi },
                new CamadaDados.Fiscal.TCD_CadCMI());
        }

        private void bb_cidade_ini_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|60;" +
                              "b.cd_uf|Cd. UF|60;" +
                              "b.uf|Sigla|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidade_ini, ds_cidade_ini, cd_uf_ini, uf_ini },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
            if (rCfg != null)
            {
                cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
            }
            BuscarCFOP();
            BuscarImpostos();
        }

        private void cd_cidade_ini_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidade_ini.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidade_ini, ds_cidade_ini, cd_uf_ini, uf_ini },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
            if(rCfg != null)
            {
                cd_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Cd_movctestr : rCfg.Cd_movcteufstr;
                ds_movimentacao.Text = uf_ini.Text.Trim().Equals(uf_transportadora.Text.Trim()) ? rCfg.Ds_movimentacao : rCfg.Ds_movcteuf;
            }
            BuscarCFOP();
            BuscarImpostos();
        }

        private void bb_cidade_fin_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|60;" +
                              "b.cd_uf|Cd. UF|60;" +
                              "b.uf|Sigla|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidade_fin, ds_cidade_fin, cd_uf_fin, uf_fin },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
            BuscarCFOP();
            BuscarImpostos();
        }

        private void cd_cidade_fin_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidade_fin.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidade_fin, ds_cidade_fin, cd_uf_fin, uf_fin },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
            BuscarCFOP();
            BuscarImpostos();
        }      

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_serienf|Serie CTe|150;" +
                              "a.nr_serie|Serie|60;" +
                              "a.cd_modelo|Modelo|60;" +
                              "a.st_sequenciaauto|Seq. Auto|60";
            string vParam = "a.cd_modelo|=|'57'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
            if(linha != null)
                nr_ctrc.Enabled = !linha["st_sequenciaauto"].ToString().Trim().ToUpper().Equals("S");
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "';" +
                            "a.cd_modelo|=|'57'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
            if (linha != null)
                nr_ctrc.Enabled = !linha["st_sequenciaauto"].ToString().Trim().ToUpper().Equals("S");
        }

        private void bb_inserirDocCTe_Click(object sender, EventArgs e)
        {
            InserirDocumentoCTe(true);
        }

        private void bb_excluirDocCte_Click(object sender, EventArgs e)
        {
            ExcluirDocumentoCTe();
        }

        private void st_recebedorretira_CheckedChanged(object sender, EventArgs e)
        {
            ds_retira.Enabled = st_recebedorretira.Checked;
        }

        private void ds_retira_EnabledChanged(object sender, EventArgs e)
        {
            if (!ds_retira.Enabled)
                ds_retira.Clear();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (tcDetalhes.SelectedTab.Equals(tpDocCte) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirDocumentoCTe(true);
            else if (tcDetalhes.SelectedTab.Equals(tpDocCte) && e.Control && e.KeyCode.Equals(Keys.F11))
                InserirDocumentoCTe(false);
            else if (tcDetalhes.SelectedTab.Equals(tpDocCte) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirDocumentoCTe();
            else if (tcDetalhes.SelectedTab.Equals(tpInfCarga) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirQtde();
            else if (tcDetalhes.SelectedTab.Equals(tpInfCarga) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirQtde();
            else if (tcDetalhes.SelectedTab.Equals(tpCompValorFrete) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirCompValorFrete();
            else if (tcDetalhes.SelectedTab.Equals(tpCompValorFrete) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirCompValorFrete();
            else if (tcDetalhes.SelectedTab.Equals(tpOrdem) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirOrdemColeta();
            else if (tcDetalhes.SelectedTab.Equals(tpOrdem) && e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarOrdemColeta();
            else if (tcDetalhes.SelectedTab.Equals(tpOrdem) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirOrdemColeta();
        }

        private void dt_emissao_Leave(object sender, EventArgs e)
        {
            BuscarImpostos();
        }

        private void tsbInserirQtde_Click(object sender, EventArgs e)
        {
            InserirQtde();
        }

        private void tsbExcluirQtde_Click(object sender, EventArgs e)
        {
            ExcluirQtde();
        }

        private void tsbInserirComp_Click(object sender, EventArgs e)
        {
            InserirCompValorFrete();
        }

        private void tsbExcluirComp_Click(object sender, EventArgs e)
        {
            ExcluirCompValorFrete();
        }

        private void bb_lanctoctrref_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nr_ctrc|Nº CTe|80;" +
                              "a.nr_lanctoctr|Lancto CTe|80;" +
                              "a.chaveacesso|Chave Acesso|100";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "a.status_cte|=|'100'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { chaveacessocteref },
                new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete(), vParam);
        }

        private void bb_expedidor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_expedidor, nm_expedidor, cd_condfiscal_expedidor }, string.Empty);
            if (!string.IsNullOrEmpty(cd_expedidor.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_expedidor.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endexpedidor.Text = lEnd[0].Cd_endereco;
                    ds_endexpedidor.Text = lEnd[0].Ds_endereco;
                    cd_uf_expedidor.Text = lEnd[0].Cd_uf;
                    uf_expedidor.Text = lEnd[0].UF;
                }
            }
        }

        private void cd_expedidor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_expedidor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_expedidor, nm_expedidor, cd_condfiscal_expedidor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_expedidor.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_expedidor.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endexpedidor.Text = lEnd[0].Cd_endereco;
                    ds_endexpedidor.Text = lEnd[0].Ds_endereco;
                    cd_uf_expedidor.Text = lEnd[0].Cd_uf;
                    uf_expedidor.Text = lEnd[0].UF;
                }
            }
        }

        private void bb_endexpedidor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Codigo|80;" +
                              "a.cd_uf|Estado|50;" +
                              "a.uf|Sigla|30";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endexpedidor, ds_endexpedidor, ds_cidadeexpedidor, cd_uf_expedidor, uf_expedidor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_expedidor.Text.Trim() + "'");
        }

        private void cd_endexpedidor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_expedidor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endexpedidor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endexpedidor, ds_endexpedidor, ds_cidadeexpedidor, cd_uf_expedidor, uf_expedidor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_recebedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_recebedor, nm_recebedor, cd_condfiscal_Recebedor }, string.Empty);
            if (!string.IsNullOrEmpty(cd_recebedor.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_recebedor.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endrecebedor.Text = lEnd[0].Cd_endereco;
                    ds_endrecebedor.Text = lEnd[0].Ds_endereco;
                    cd_uf_recebedor.Text = lEnd[0].Cd_uf;
                    uf_recebedor.Text = lEnd[0].UF;
                }
            }
        }

        private void cd_recebedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_recebedor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_recebedor, nm_recebedor, cd_condfiscal_Recebedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_expedidor.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_recebedor.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endrecebedor.Text = lEnd[0].Cd_endereco;
                    ds_endrecebedor.Text = lEnd[0].Ds_endereco;
                    cd_uf_recebedor.Text = lEnd[0].Cd_uf;
                    uf_recebedor.Text = lEnd[0].UF;
                }
            }
        }

        private void bb_endrecebedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Codigo|80;" +
                              "a.cd_uf|Estado|50;" +
                              "a.uf|Sigla|30";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endrecebedor, ds_endrecebedor, ds_cidaderecebedor, cd_uf_recebedor, uf_recebedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_recebedor.Text.Trim() + "'");
        }

        private void cd_endrecebedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_recebedor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endrecebedor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endrecebedor, ds_endrecebedor, ds_cidaderecebedor, cd_uf_recebedor, uf_recebedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bbInserirOutrosDoc_Click(object sender, EventArgs e)
        {
            InserirDocumentoCTe(false);
        }

        private void tsmiExcluir_Click(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedTab.Equals(tpDocCte))
                ExcluirDocumentoCTe();
            else if (tcDetalhes.SelectedTab.Equals(tpInfCarga))
                ExcluirQtde();
            else if (tcDetalhes.SelectedTab.Equals(tpCompValorFrete))
                ExcluirCompValorFrete();
        }

        private void bb_tomador_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_tomador, nm_tomador, cd_condfiscal_tomador }, string.Empty);
            if (!string.IsNullOrEmpty(cd_tomador.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_tomador.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endtomador.Text = lEnd[0].Cd_endereco;
                    ds_endtomador.Text = lEnd[0].Ds_endereco;
                    cd_uf_tomador.Text = lEnd[0].Cd_uf;
                    uf_tomador.Text = lEnd[0].UF;
                }
                //todo - inserido para testes ticket 7260
                BuscarImpostos();
            }
        }

        private void cd_tomador_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_tomador.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_tomador, nm_tomador, cd_condfiscal_tomador }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_tomador.Text))
            {
                //Buscar endereco
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                      new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_tomador.Text.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                if (lEnd.Count > decimal.Zero)
                {
                    cd_endtomador.Text = lEnd[0].Cd_endereco;
                    ds_endtomador.Text = lEnd[0].Ds_endereco;
                    cd_uf_tomador.Text = lEnd[0].Cd_uf;
                    uf_tomador.Text = lEnd[0].UF;
                }
                //todo - inserido para testes ticket 7260
                BuscarImpostos();
            }            
        }

        private void bb_endtomador_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|150;" +
                              "a.cd_endereco|Codigo|80;" +
                              "a.cd_uf|Estado|50;" +
                              "a.uf|Sigla|30";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endtomador, ds_endtomador, ds_cidadetomador, cd_uf_tomador, uf_tomador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_tomador.Text.Trim() + "'");
        }

        private void cd_endtomador_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_tomador.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endtomador.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endtomador, ds_endtomador, ds_cidadetomador, cd_uf_tomador, uf_tomador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void tp_tomador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_tomador.SelectedValue != null)
            {
                cd_tomador.Enabled = tp_tomador.SelectedValue.ToString().Equals("4");
                bb_tomador.Enabled = tp_tomador.SelectedValue.ToString().Equals("4");
                cd_endtomador.Enabled = tp_tomador.SelectedValue.ToString().Equals("4");
                bb_endtomador.Enabled = tp_tomador.SelectedValue.ToString().Equals("4");
            }
        }

        private void cd_tomador_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_tomador.Enabled)
            {
                cd_tomador.Clear();
                nm_tomador.Clear();
            }
        }

        private void cd_endtomador_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_endtomador.Enabled)
            {
                cd_endtomador.Clear();
                ds_endtomador.Clear();
                cd_uf_tomador.Clear();
                uf_tomador.Clear();
            }
        }
        
        private void bb_xmlNFe_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Documentos XML|*.xml";
                op.InitialDirectory = string.IsNullOrEmpty(SettingsUtils.Default.Path_XML_NFe_CTe) ? "c:" : SettingsUtils.Default.Path_XML_NFe_CTe;
                op.Title = "Selecione XML NFe";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(op.FileName))
                    {
                        SettingsUtils.Default.Path_XML_NFe_CTe = op.FileName.Substring(0, op.FileName.LastIndexOf("\\"));
                        SettingsUtils.Default.Save();
                        ImportNfe(op.FileName);
                    }
                }
            }
        }
        
        private void vl_frete_Leave(object sender, EventArgs e)
        {
            (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Vl_frete = vl_frete.Value;
            bsCte.ResetCurrentItem();
            if (pSaldoFaturar > decimal.Zero)
                if (vl_frete.Value > pSaldoFaturar)
                {
                    MessageBox.Show("Saldo insuficiente para gerar CTe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_frete.Value = decimal.Zero;
                    vl_frete.Focus();
                }
            BuscarImpostos();
        }

        private void bbInserirOC_Click(object sender, EventArgs e)
        {
            InserirOrdemColeta();
        }

        private void bbAlterarOC_Click(object sender, EventArgs e)
        {
            AlterarOrdemColeta();
        }

        private void bbExcluiOC_Click(object sender, EventArgs e)
        {
            ExcluirOrdemColeta();
        }
                     
        private void chave_acesso_nfe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar a empresa para consulta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CamadaDados.Diversos.TRegistro_CadEmpresa rEmp =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(cd_empresa.Text,
                                                            string.Empty,
                                                            string.Empty,
                                                            null)[0];
            CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe =
                   CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cd_empresa.Text,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null)[0];
            if (!string.IsNullOrEmpty(chave_acesso_nfe.Text))
                if (chave_acesso_nfe.Text.Length == 44)
                    if (Estruturas.Mod11(chave_acesso_nfe.Text.Trim().Substring(0, 43), 9, false, 0).ToString() == chave_acesso_nfe.Text.Trim().Substring(43, 1))
                    {
                        try
                        {
                            ImportNfe(
                            srvNFE.DistribuicaoDFe.TDistribuicaoDFe.DownloadXML(rCfgNfe,
                                                                                rEmp,
                                                                                chave_acesso_nfe.Text));
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        MessageBox.Show("Chave de Acesso inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void chave_acesso_nfe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
               char.IsSymbol(e.KeyChar) || //Símbolos
               char.IsWhiteSpace(e.KeyChar) || //Espaço
               char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void bb_configicms_Click(object sender, EventArgs e)
        {
            using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
            {
                fCondICMS.pCd_empresa = cd_empresa.Text;
                fCondICMS.pCd_condfiscal_clifor = tp_tomador.SelectedValue.ToString().Equals("0") ?
                                                  cd_condfiscal_Remetente.Text :
                                                  tp_tomador.SelectedValue.ToString().Equals("1") ?
                                                  cd_condfiscal_expedidor.Text :
                                                  tp_tomador.SelectedValue.ToString().Equals("2") ?
                                                  cd_condfiscal_Recebedor.Text :
                                                  tp_tomador.SelectedValue.ToString().Equals("3") ?
                                                  cd_condfiscal_dest.Text : cd_condfiscal_tomador.Text;
                fCondICMS.pCd_condfiscal_produto = string.Empty;
                fCondICMS.pCd_movto = cd_movimentacao.Text;
                fCondICMS.pCd_UfDest = cd_uf_fin.Text;
                fCondICMS.pCd_UfOrig = cd_uf_ini.Text;
                fCondICMS.pTp_movimento = "S";
                fCondICMS.pCd_imposto = bsImpostosCtrc.Current != null ? (bsImpostosCtrc.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr : string.Empty;
                if (fCondICMS.ShowDialog() == DialogResult.OK)
                    if ((fCondICMS.rCond != null) &&
                        (fCondICMS.lMov != null) &&
                        (fCondICMS.lUfDestino != null) &&
                        (fCondICMS.lUfOrigem != null))
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                              fCondICMS.lMov,
                                                                              fCondICMS.lUfOrigem,
                                                                              fCondICMS.lUfDestino,
                                                                              null);
                        }
                        catch { }
                BuscarImpostos();
            }
        }

        private void ch_acessonfetom_VisibleChanged(object sender, EventArgs e)
        {
            if (!ch_acessonfetom.Visible)
                ch_acessonfetom.Clear();
        }

        private void bb_novoRemetente_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Remetente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_remetente.Text = fClifor.rClifor.Cd_clifor;
                        nm_remetente.Text = fClifor.rClifor.Nm_clifor;
                        cd_endremetente.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endremetente.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        cd_remetente.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_novoDestinatario_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Destinatário gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_destinatario.Text = fClifor.rClifor.Cd_clifor;
                        nm_destinatario.Text = fClifor.rClifor.Nm_clifor;
                        cd_enddestinatario.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_enddestinatario.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        cd_destinatario.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_cliforcteref_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforCTeRef, nm_cliforcteref, cnpj_cliforcteref }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void cd_cliforCTeRef_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforCTeRef.Text.Trim() + "'isnull(a.st_transportadora, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_cliforCTeRef, nm_cliforcteref, cnpj_cliforcteref },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void tp_servico_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChaveRef.Visible = tp_servico.SelectedIndex > 0;
            chaveacessocteref.Visible = tp_servico.SelectedIndex > 0;
            bb_lanctoctrref.Visible = tp_servico.SelectedIndex > 0;
            lblCliforRef.Visible = tp_servico.SelectedIndex > 0;
            cd_cliforCTeRef.Visible = tp_servico.SelectedIndex > 0;
            bb_cliforcteref.Visible = tp_servico.SelectedIndex > 0;
            nm_cliforcteref.Visible = tp_servico.SelectedIndex > 0;
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, nm_motorista }, "a.tp_pessoa|=|'F'");
            if (!string.IsNullOrEmpty(cd_motorista.Text) && string.IsNullOrEmpty(id_veiculo.Text))
            {
                //Buscar Veiculo do Motorista
                CamadaDados.Frota.Cadastros.TList_CadVeiculo lVeic =
                    new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().Select(
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
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_frt_motorista x " +
                                        "where x.id_veiculo = a.id_veiculo " +
                                        "and x.cd_motorista = '" + cd_motorista.Text.Trim() + "')"
                        }
                    }, 0, string.Empty);
                if (lVeic.Count > 0)
                {
                    id_veiculo.Text = lVeic[0].Id_veiculostr;
                    ds_veiculo.Text = lVeic[0].Ds_veiculo;
                    placa.Text = lVeic[0].placa;
                }
            }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpDadosComp))
            {
                if(!string.IsNullOrEmpty(pId_veiculo) && string.IsNullOrEmpty(id_veiculo.Text))
                {
                    id_veiculo.Text = pId_veiculo;
                    id_veiculo_Leave(this, new EventArgs());
                }
                if ((!string.IsNullOrEmpty(pCd_motorista)) &&
                    string.IsNullOrEmpty(cd_motorista.Text))
                {
                    cd_motorista.Text = pCd_motorista;
                    cd_motorista_Leave(this, new EventArgs());
                }
            }
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';a.tp_pessoa|=|'F'",
                new Componentes.EditDefault[] { cd_motorista, nm_motorista }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_motorista.Text) && string.IsNullOrEmpty(id_veiculo.Text))
            {
                //Buscar Veiculo do Motorista
                CamadaDados.Frota.Cadastros.TList_CadVeiculo lVeic =
                    new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().Select(
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
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_frt_motorista x " +
                                        "where x.id_veiculo = a.id_veiculo " +
                                        "and x.cd_motorista = '" + cd_motorista.Text.Trim() + "')"
                        }
                    }, 0, string.Empty);
                if (lVeic.Count > 0)
                {
                    id_veiculo.Text = lVeic[0].Id_veiculostr;
                    ds_veiculo.Text = lVeic[0].Ds_veiculo;
                    placa.Text = lVeic[0].placa;
                }
            }
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_veiculo|Veiculo|150;a.placa|Placa|50;a.id_veiculo|Código|50",
                new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa }, new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), string.Empty);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_veiculo|=|" + id_veiculo.Text, 
                new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void cbTpCte_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChaveRef.Visible = cbTpCte.SelectedIndex > 0;
            chaveacessocteref.Visible = cbTpCte.SelectedIndex > 0;
            bb_lanctoctrref.Visible = cbTpCte.SelectedIndex > 0;
            lblCliforRef.Visible = cbTpCte.SelectedIndex > 0;
            cd_cliforCTeRef.Visible = cbTpCte.SelectedIndex > 0;
            bb_cliforcteref.Visible = cbTpCte.SelectedIndex > 0;
            nm_cliforcteref.Visible = cbTpCte.SelectedIndex > 0;
            lblChAcessoNFeTom.Visible = cbTpCte.SelectedIndex.Equals(3);
            ch_acessonfetom.Visible = cbTpCte.SelectedIndex.Equals(3);
        }

        private void vl_frete_ValueChanged(object sender, EventArgs e)
        {
            vlBaseCalcICMS.Enabled = vl_frete.Value.Equals(decimal.Zero);
        }

        private void vlBaseCalcICMS_Leave(object sender, EventArgs e)
        {
            CalcularICMS();
        }

        private void pReducaoBC_Leave(object sender, EventArgs e)
        {
            CalcularICMS();
        }

        private void pAliquotaICMS_Leave(object sender, EventArgs e)
        {
            CalcularICMS();
        }

        private void vlICMS_Leave(object sender, EventArgs e)
        {
            CalcularICMS(St_valor: true);
        }
    }
}
