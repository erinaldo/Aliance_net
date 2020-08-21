using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Faturamento.NotaFiscal;
using FormBusca;
using Proc_Commoditties;

namespace Faturamento
{
    public partial class TFSimuladorImpostos : Form
    {
        public CamadaDados.Fiscal.TList_ProdutoSimular lProdSimular
        { get; set; }
        public CamadaDados.Fiscal.TList_ResumoImposto lResumo
        {
            get
            {
                if (bsResumoImposto.Count > 0)
                    return bsResumoImposto.DataSource as CamadaDados.Fiscal.TList_ResumoImposto;
                else
                    return null;
            }
        }

        public string Cd_empresasimular
        { get { return CD_Empresa.Text; } }
        public string Cfg_pedidosimular
        { get { return CFG_Pedido.Text; } }

        public bool St_calcavulso
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_uf_empresa
        { get; set; }
        public string pCfg_pedido
        { get; set; }
        public string pDs_tipopedido
        { get; set; }
        public string pTp_mov
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pCd_condfiscal_clifor
        { get; set; }
        public string pCd_endereco
        { get; set; }
        public string pDs_endereco
        { get; set; }
        public string pCd_uf_clifor
        { get; set; }
        public string pCd_municipioexecservico
        { get; set; }

        public TFSimuladorImpostos()
        {
            InitializeComponent();
            pCd_empresa = string.Empty;
            pNm_empresa = string.Empty;
            pCd_uf_empresa = string.Empty;
            pCfg_pedido = string.Empty;
            pDs_tipopedido = string.Empty;
            pTp_mov = string.Empty;
            pCd_clifor = string.Empty;
            pNm_clifor = string.Empty;
            pCd_condfiscal_clifor = string.Empty;
            pCd_endereco = string.Empty;
            pDs_endereco = string.Empty;
            pCd_uf_clifor = string.Empty;
            pCd_municipioexecservico = string.Empty;
            St_calcavulso = false;
            lProdSimular = new CamadaDados.Fiscal.TList_ProdutoSimular();

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO NORMAL", "NO"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE COMPLEMENTO", "CP"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE DEVOLUÇÃO", "DV"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE ENTREGA FUTURA", "FT"));
            cbx1.Add(new Utils.TDataCombo("TRANSFERENCIA ENTRE CONTRATOS", "TF"));
            cbx1.Add(new Utils.TDataCombo("COMPLEMENTO FISCAL", "CF"));
            cbx1.Add(new Utils.TDataCombo("DEVOLUÇÃO FISCAL", "DF"));
            cbx1.Add(new Utils.TDataCombo("SERVICO", "SE"));

            Cbx_TP_Fiscal.DataSource = cbx1;
            Cbx_TP_Fiscal.DisplayMember = "Display";
            Cbx_TP_Fiscal.ValueMember = "Value";
            Cbx_TP_Fiscal.SelectedIndex = 0;
        }

        private void afterConfirma()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private bool VerificarCfgFiscalPedido()
        {
            if (!string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    }
                                }, "1");
                return obj == null ? false : obj.ToString().Trim().Equals("1");
            }
            else
                return false;
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
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

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(CD_Endereco.Text))
                    {
                        CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                        UF.Text = List_Endereco[0].Cd_uf.Trim();
                    }
                }
            }
        }

        private void CalcularImpostos()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            if (Cbx_TP_Fiscal.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo fiscal para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cbx_TP_Fiscal.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente/fornecedor para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Endereco.Text))
            {
                MessageBox.Show("Obrigatorio informar endereço para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Endereco.Focus();
                return;
            }
            if (bsProdutoSimular.Count.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar produto para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bb_adicionar.Focus();
                return;
            }
            //Buscar movimentacao comercial do tipo de pedido
                CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed = 
                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cbx_TP_Fiscal.SelectedValue.ToString() + "'"
                                    }
                                }, 1, string.Empty);
                if (lCfgPed.Count < 1)
                {
                    MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + CFG_Pedido.Text.Trim() + ", tipo fiscal " + Cbx_TP_Fiscal.Text + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CFG_Pedido.Focus();
                    return;
                }
            CamadaDados.Fiscal.TList_ResumoImposto lResumo = new CamadaDados.Fiscal.TList_ResumoImposto();
            for(int i = 0; i < bsProdutoSimular.Count; i++)
            {
                string retobs = string.Empty;
                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                                      (TP_Mov.Text.Trim().ToUpper().Equals("E") &&
                                                                                                       (Cbx_TP_Fiscal.SelectedValue.ToString().Trim() != "DV") &&
                                                                                                       (Cbx_TP_Fiscal.SelectedValue.ToString().Trim() != "DF") ? UF.Text : uf_empresa.Text),
                                                                                                      (TP_Mov.Text.Trim().ToUpper().Equals("E") &&
                                                                                                       (Cbx_TP_Fiscal.SelectedValue.ToString().Trim() != "DV") &&
                                                                                                       (Cbx_TP_Fiscal.SelectedValue.ToString().Trim() != "DF") ? uf_empresa.Text : UF.Text),
                                                                                                      lCfgPed[0].Cd_movtostring,
                                                                                                      (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DV") ||
                                                                                                      Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DF") ?
                                                                                                      TP_Mov.Text.Trim().Equals("E") ? "S" : "E" : TP_Mov.Text),
                                                                                                      cd_condfiscal_clifor.Text,
                                                                                                      (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto,
                                                                                                      (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Vl_subtotal,
                                                                                                      (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Quantidade,
                                                                                                      ref retobs,
                                                                                                      DateTime.Now,
                                                                                                      cd_produto.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Concat(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condfiscal_clifor.Text,
                                                                                                                                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto,
                                                                                                                                lCfgPed[0].Cd_movtostring,
                                                                                                                                (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DV") ||
                                                                                                                                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DF") ?
                                                                                                                                TP_Mov.Text.Trim().Equals("E") ? "S" : "E" : TP_Mov.Text),
                                                                                                                                tp_pessoa.Text,
                                                                                                                                CD_Empresa.Text,
                                                                                                                                lCfgPed[0].Nr_serie,
                                                                                                                                CD_Clifor.Text,
                                                                                                                                string.Empty,
                                                                                                                                DateTime.Now,
                                                                                                                                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Quantidade,
                                                                                                                                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Vl_subtotal,
                                                                                                                                string.Empty,
                                                                                                                                pCd_municipioexecservico,
                                                                                                                                null));
                var ipi = (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(v => v.Imposto.St_IPI);
                var icms = (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(v => v.Imposto.St_ICMS);
                if(ipi != null &&
                    (icms == null ? false : icms.St_somarIPIBaseICMS || icms.St_somarIPIBaseST))
                {
                    TRegistro_ImpostosNF rImp = new TRegistro_ImpostosNF();
                    rImp.Cd_imposto = icms.Cd_imposto;
                    rImp.Pc_aliquota = icms.Pc_aliquota;
                    rImp.Pc_reducaoaliquota = icms.Pc_reducaoaliquota;
                    rImp.Pc_reducaobasecalc = icms.Pc_reducaobasecalc;
                    rImp.Pc_aliquotasubst = icms.Pc_aliquotasubst;
                    rImp.Pc_reducaobasecalcsubsttrib = icms.Pc_reducaobasecalcsubsttrib;
                    rImp.Tp_situacao = icms.Tp_situacao;
                    rImp.Dt_imposto = icms.Dt_imposto;
                    rImp.St_impostouf = 0;
                    rImp.Tp_modbasecalc = icms.Tp_modbasecalc;
                    rImp.Tp_modbasecalcST = icms.Tp_modbasecalcST;
                    rImp.Cd_st = icms.Cd_st;
                    rImp.St_substtrib = icms.St_substtrib;
                    rImp.St_simplesnacional = icms.St_simplesnacional;
                    rImp.Pc_iva_st = icms.Pc_iva_st;
                    rImp.Vl_mva = icms.Vl_mva;
                    rImp.Pc_aliquotaICMSDest = icms.Pc_aliquotaICMSDest;
                    rImp.Vl_pauta = icms.Vl_pauta;
                    rImp.St_somarIPIBaseICMS = icms.St_somarIPIBaseICMS;
                    rImp.St_somarIPIBaseST = icms.St_somarIPIBaseST;
                    rImp.Vl_ipisomar = ipi.Vl_impostocalc;
                    //Calcular Imposto
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item
                        .CalcImpostos(rImp, 
                                      (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Vl_subtotal, 
                                      (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Quantidade,
                                      (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DV") ||
                                      Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DF") ?
                                      TP_Mov.Text.Trim().Equals("E") ? "S" : "E" : TP_Mov.Text));
                    //Preencher ICMS Item Nota
                    icms.Vl_basecalcsubsttrib = rImp.Vl_basecalcsubsttrib;
                    icms.Vl_impostosubsttrib = rImp.Vl_impostosubsttrib;
                }
                (bsProdutoSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.ForEach(p =>
                    {
                        if (lResumo.Exists(v => v.Cd_imposto.Trim().Equals(p.Cd_imposto.Value.ToString()) &&
                                                v.St_totalnota.Trim().Equals(p.St_totalnota.Trim())))
                        {
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(p.Cd_impostostr.Trim())).Vl_imposto += p.Vl_impostocalc;
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(p.Cd_impostostr.Trim())).Vl_impostoretido += p.Vl_impostoretido;
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(p.Cd_impostostr.Trim())).Vl_impostosubstrib += p.Vl_impostosubsttrib + p.Vl_FCPST;
                        }
                        else
                            lResumo.Add(new CamadaDados.Fiscal.TRegistro_ResumoImposto()
                            {
                                Cd_imposto = p.Cd_impostostr,
                                Ds_imposto = p.Ds_imposto,
                                Vl_imposto = p.Vl_impostocalc,
                                Vl_impostoretido = p.Vl_impostoretido,
                                Vl_impostosubstrib = p.Vl_impostosubsttrib + p.Vl_FCPST,
                                St_totalnota = p.St_totalnota
                            });
                    });
            }
            tot_imposto.Value = lResumo.Sum(p => p.Vl_imposto);
            tot_retido.Value = lResumo.Sum(p => p.Vl_impostoretido);
            tot_subst.Value = lResumo.Sum(p => p.Vl_impostosubstrib);
            bsProdutoSimular.ResetBindings(true);
            bsResumoImposto.DataSource = lResumo;
        }

        private void ConfigImpostoUf()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            if (Cbx_TP_Fiscal.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo fiscal para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cbx_TP_Fiscal.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente/fornecedor para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Endereco.Text))
            {
                MessageBox.Show("Obrigatorio informar endereço para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Endereco.Focus();
                return;
            }
            if (bsProdutoSimular.Count.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar produto para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bb_adicionar.Focus();
                return;
            }
            //Buscar movimentacao comercial do tipo de pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cbx_TP_Fiscal.SelectedValue.ToString() + "'"
                                    }
                                }, 1, string.Empty);
            if (lCfgPed.Count < 1)
            {
                MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + CFG_Pedido.Text.Trim() + ", tipo fiscal " + Cbx_TP_Fiscal.SelectedValue.ToString() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
            {
                fCondICMS.pCd_empresa = CD_Empresa.Text;
                fCondICMS.pCd_condfiscal_clifor = cd_condfiscal_clifor.Text;
                fCondICMS.pCd_condfiscal_produto = (bsProdutoSimular.Current != null ? (bsProdutoSimular.Current as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto : string.Empty);
                fCondICMS.pCd_movto = lCfgPed[0].Cd_movtostring;
                fCondICMS.pCd_UfDest = TP_Mov.Text.Trim().ToUpper().Equals("E") ? uf_empresa.Text : UF.Text;
                fCondICMS.pCd_UfOrig = TP_Mov.Text.Trim().ToUpper().Equals("E") ? UF.Text : uf_empresa.Text;
                fCondICMS.pTp_movimento = (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DV") || 
                    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().Equals("DF")) ? TP_Mov.Text.Trim().ToUpper().Equals("E") ? "S" : "E" : TP_Mov.Text;
                if(fCondICMS.ShowDialog() == DialogResult.OK)
                    if((fCondICMS.rCond != null) &&
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
                CalcularImpostos();
            }
        }

        private void ConfigOutrosImpostos()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            if (Cbx_TP_Fiscal.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo fiscal para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cbx_TP_Fiscal.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente/fornecedor para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Endereco.Text))
            {
                MessageBox.Show("Obrigatorio informar endereço para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Endereco.Focus();
                return;
            }
            if (bsProdutoSimular.Count.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar produto para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bb_adicionar.Focus();
                return;
            }
            //Buscar movimentacao comercial do tipo de pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cbx_TP_Fiscal.SelectedValue.ToString() + "'"
                                    }
                                }, 1, string.Empty);
            if (lCfgPed.Count < 1)
            {
                MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + CFG_Pedido.Text.Trim() + ", tipo fiscal " + Cbx_TP_Fiscal.SelectedValue.ToString() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
            {
                fCondImposto.pCd_empresa = CD_Empresa.Text;
                fCondImposto.pCd_imposto = (bsImpProduto.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr;
                fCondImposto.pCd_condfiscal_clifor = cd_condfiscal_clifor.Text;
                fCondImposto.pCd_condfiscal_produto = (bsProdutoSimular.Current != null ? (bsProdutoSimular.Current as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto : string.Empty);
                fCondImposto.pCd_movimentacao = lCfgPed[0].Cd_movtostring;
                fCondImposto.pTp_faturamento = TP_Mov.Text;
                fCondImposto.pSt_juridica = tp_pessoa.Text.Trim().ToUpper().Equals("J");
                fCondImposto.pSt_fisica = tp_pessoa.Text.Trim().ToUpper().Equals("F");
                if (fCondImposto.ShowDialog() == DialogResult.OK)
                    if ((fCondImposto.rCond != null) &&
                    (fCondImposto.lMov != null) &&
                    (fCondImposto.lCondClifor != null) &&
                    (fCondImposto.lCondProd != null))
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                             fCondImposto.lMov,
                                                                                             fCondImposto.lCondClifor,
                                                                                             fCondImposto.lCondProd,
                                                                                             fCondImposto.pSt_fisica,
                                                                                             fCondImposto.pSt_juridica,
                                                                                             fCondImposto.pSt_estrangeiro,
                                                                                             null);
                        }
                        catch { }
                CalcularImpostos();
            }
        }

        private void ConfigCfgFiscalPed()
        {
            if (string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            if (Cbx_TP_Fiscal.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo fiscal para configurar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cbx_TP_Fiscal.Focus();
                return;
            }
            using (Faturamento.Cadastros.TFCadCFGPedidoFiscal fCfgPed = new Faturamento.Cadastros.TFCadCFGPedidoFiscal())
            {
                fCfgPed.st_maximizar = false;
                fCfgPed.pCfg_pedido = CFG_Pedido.Text;
                fCfgPed.pTp_fiscal = Cbx_TP_Fiscal.SelectedValue.ToString();
                fCfgPed.ShowDialog();
                CalcularImpostos();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_calcula_Click(object sender, EventArgs e)
        {
            CalcularImpostos();
        }

        private void TFSimuladorImpostos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gImpProduto);
            Utils.ShapeGrid.RestoreShape(this, gResumoImposto);
            Utils.ShapeGrid.RestoreShape(this, gProdutoSimular);
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label9.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            CD_Empresa.Text = pCd_empresa;
            NM_Empresa.Text = pNm_empresa;
            CD_Empresa_Leave(this, new EventArgs());
            CFG_Pedido.Text = pCfg_pedido;
            DS_CFGPedido.Text = pDs_tipopedido;
            TP_Mov.Text = pTp_mov;
            CD_Clifor.Text = pCd_clifor;
            NM_Clifor.Text = pNm_clifor;
            CD_Clifor_Leave(this, new EventArgs());
            CD_Endereco.Text = pCd_endereco;
            DS_Endereco.Text = pDs_endereco;
            CD_Endereco_Leave(this, new EventArgs());
            bsProdutoSimular.DataSource = lProdSimular;
            CD_Clifor.Enabled = St_calcavulso;
            BB_Clifor.Enabled = St_calcavulso;
            CD_Endereco.Enabled = St_calcavulso;
            BB_Endereco.Enabled = St_calcavulso;
            bb_adicionar.Enabled = St_calcavulso;
            bb_excluir.Enabled = St_calcavulso;
            quantidade.Enabled = St_calcavulso;
            vl_unitario.Enabled = St_calcavulso;
            bb_confirma.Visible = !St_calcavulso;
            //Verificar se o usuario tem acesso a tela de parametros impostos estadual
            object obj = new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "((a.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                                "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "c.nm_classe",
                                    vOperador = "=",
                                    vVL_Busca = "'Fiscal.Cadastros.TFCad_CondFiscalICMS'"
                                }
                            }, "1");
            bb_impostosuf.Visible = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") ||
                                    Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV") || 
                                    (obj == null ? false : true);
            //Acesso tela de parametros dos impostos
            obj = new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "((a.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                        "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                        "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "c.nm_classe",
                            vOperador = "=",
                            vVL_Busca = "'Fiscal.Cadastros.TFCad_CondFiscalImpostos'"
                        }
                    }, "1");
            bb_outrosimpostos.Visible = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") ||
                                        Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV") || 
                                        (obj == null ? false : true);
            //Acesso a tela de configuracao fiscal pedido
            obj = new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "((a.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                        "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                        "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "c.nm_classe",
                            vOperador = "=",
                            vVL_Busca = "'Faturamento.Cadastros.TFCadCFGPedidoFiscal'"
                        }
                    }, "1");
            bb_configfiscalpedido.Visible = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") ||
                                            Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV") || 
                                            (obj == null ? false : true);
        }

        private void TFSimuladorImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4) && bb_confirma.Visible)
                afterConfirma();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                CalcularImpostos();
            else if (e.KeyCode.Equals(Keys.F10) && bb_impostosuf.Visible)
                ConfigImpostoUf();
            else if (e.KeyCode.Equals(Keys.F11) && bb_outrosimpostos.Visible)
                ConfigOutrosImpostos();
            else if (e.KeyCode.Equals(Keys.F12) && bb_configfiscalpedido.Visible)
                ConfigCfgFiscalPed();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100;cd_uf|UF Empresa|80"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa, uf_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
            if (linha != null)
                regimefiscal.Text = linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("LR") ?
                    "LUCRO REAL" : linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("LP") ?
                    "LUCRO PRESUMIDO" : linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("SP") ?
                    "SIMPLES" : string.Empty;
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa, uf_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            if (linha != null)
                regimefiscal.Text = linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("LR") ?
                    "LUCRO REAL" : linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("LP") ?
                    "LUCRO PRESUMIDO" : linha["tp_regimetributario"].ToString().Trim().ToUpper().Equals("SP") ?
                    "SIMPLES" : string.Empty;
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(pTp_mov))
                vParam += ";tp_movimento|=|'" + pTp_mov.Trim() + "'";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50;A.st_ValoresFixos|Permitir valores fixos|50;a.st_fecharpedidoauto|Fechar Pedido Automaticamente|50",
                            new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
            VerificarCfgFiscalPedido();
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S'";
            if (!string.IsNullOrEmpty(pTp_mov))
                vParam += ";tp_movimento|=|'" + pTp_mov.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
            VerificarCfgFiscalPedido();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor, cd_condfiscal_clifor, tp_pessoa }, "isnull(a.st_registro, 'A')|<>|'C'");
            Busca_Endereco_Clifor();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                    , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor, cd_condfiscal_clifor, tp_pessoa }, 
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            Busca_Endereco_Clifor();
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.CD_UF|Estado|150;a.fone|Telefone|80"
                                                            , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, UF }, 
                                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), 
                                                            "a.cd_clifor|=|'" + CD_Clifor.Text + "'");
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, UF }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            if (bsProdutoSimular.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsProdutoSimular.RemoveCurrent();
            }
        }

        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            bsProdutoSimular.AddNew();
            DataRowView linha = UtilPesquisa.BTN_BuscaProduto(
                new Componentes.EditDefault[]{cd_produto, ds_produto, sg_unidade, cd_condfiscal_produto, ds_condfiscal_produto}, string.Empty);
            if (linha == null)
                bsProdutoSimular.RemoveCurrent();
        }

        private void bb_confirma_Click(object sender, EventArgs e)
        {
            afterConfirma();
        }

        private void bb_impostosuf_Click(object sender, EventArgs e)
        {
            ConfigImpostoUf();
        }

        private void bb_outrosimpostos_Click(object sender, EventArgs e)
        {
            ConfigOutrosImpostos();
        }

        private void bb_configfiscalpedido_Click(object sender, EventArgs e)
        {
            ConfigCfgFiscalPed();
        }

        private void TFSimuladorImpostos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gImpProduto);
            Utils.ShapeGrid.SaveShape(this, gResumoImposto);
            Utils.ShapeGrid.SaveShape(this, gProdutoSimular);
        }

        private void bbAltCondfiscal_Click(object sender, EventArgs e)
        {
            if(bsProdutoSimular.Current != null)
            {
                try
                {
                    DataRowView linha = UtilPesquisa.BTN_BUSCA("a.DS_CondFiscal_Produto|Condição Fiscal|200;a.CD_CondFiscal_Produto|Código|50",
                                        null, new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
                    if (linha != null)
                    {
                        CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd =
                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsProdutoSimular.Current as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto.Trim() + "'"
                                }
                                }, 1, string.Empty, string.Empty, string.Empty)[0];
                        rProd.CD_CondFiscal_Produto = linha["cd_condfiscal_produto"].ToString();
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(rProd, null);
                        (bsProdutoSimular.Current as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                        bsProdutoSimular.ResetCurrentItem();
                    }
                }
                catch(Exception ex)
                { MessageBox.Show("Erro alterar produto: " + ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
