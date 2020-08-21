using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFReprocessarFiscal : Form
    {
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe { get; set; }

        public TFReprocessarFiscal()
        {
            InitializeComponent();
        }

        private void BuscarImpostosNota()
        {
            if (bsItensNota.Current != null)
            {
                //Reprocessar impostos da nota
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpNf =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos((bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                                               (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_serie,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_clifor,
                                                                                                               (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_unidEst,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Dt_emissao,
                                                                                                               (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade,
                                                                                                               (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_nota,
                                                                                                               (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_municipioexecservico,
                                                                                                               null);
                string vObsFiscal = string.Empty;
                lImpNf.Concat(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ?
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_clifor :
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_empresa,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ?
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_empresa :
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_clifor,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                                                (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                                                (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                                                (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade,
                                                                                                                ref vObsFiscal,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Dt_emissao,
                                                                                                                string.Empty,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_nota,
                                                                                                                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_serie,
                                                                                                                null));
                //Verificar se item da nota teve origem FIXAÇÃO
                if ((bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E"))
                {
                    object obj = new CamadaDados.Graos.TCD_Fixacao_NF().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString()
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_nfitem",
                                            vOperador = "=",
                                            vVL_Busca = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem.ToString()
                                        }
                                    }, "isnull(a.vl_fixacao, 0)");
                    if (obj == null ? false : decimal.Parse(obj.ToString()) > decimal.Zero)
                    {
                        decimal vl_baseret = decimal.Parse(obj.ToString());
                        //Buscar numero contrato
                        obj = new CamadaDados.Graos.TCD_CadContrato().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_pedido.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_produto.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_pedidoitem",
                                        vOperador = "=",
                                        vVL_Busca = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_pedidoitemstr
                                    }
                                }, "a.nr_contrato");
                        if (obj != null)
                        {
                            List<CamadaDados.Graos.TRegistro_ImpostosReter> lImpRet =
                                TProcessaFixacao.CalcularImpostoReter(obj.ToString(), vl_baseret);
                            //Concatenar Impostos Reter Funrural/Senar com a base de calculo no valor total da fixação.
                            lImpRet.ForEach(x =>
                            {
                                lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Vl_basecalc = x.Vl_basecalc;
                                lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Pc_retencao = x.Pc_retencao;
                                lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Vl_impostoretido = x.Vl_rentecao;
                            });
                        }
                    }
                }
                if (lImpNf.Exists(v => v.Imposto.St_ICMS))
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(
                        lImpNf.Find(v => v.Imposto.St_ICMS), bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item);
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    lImpNf, bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item,
                    (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento);
                rNf.Obsfiscal += string.IsNullOrEmpty(rNf.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                bsItensNota.ResetCurrentItem();
            }
            else if (bsItensNFCe.Current != null)
            {
                //Buscar config cupom fiscal
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa, null);
                if (lCfg.Count > 0)
                {
                    //Reprocessar impostos da nota
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpNf =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lCfg[0].Cd_condfiscal_clifor,
                                                                                                                   (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_condfiscal_produto,
                                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_movimentacaostr,
                                                                                                                   "S",
                                                                                                                   lCfg[0].Tp_pessoa,
                                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_serie,
                                                                                                                   lCfg[0].Cd_clifor,
                                                                                                                   string.Empty,
                                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Dt_emissao,
                                                                                                                   decimal.Zero,
                                                                                                                   (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_subtotalliquido,
                                                                                                                   "P",
                                                                                                                   string.Empty,
                                                                                                                   null);
                    string vObsFiscal = string.Empty;
                    lImpNf.Concat(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_uf_empresa,
                                                                                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_uf_empresa,
                                                                                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_movimentacaostr,
                                                                                                                    "S",
                                                                                                                    lCfg[0].Cd_condfiscal_clifor,
                                                                                                                    (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_condfiscal_produto,
                                                                                                                    (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_subtotalliquido,
                                                                                                                    (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Quantidade,
                                                                                                                    ref vObsFiscal,
                                                                                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Dt_emissao,
                                                                                                                    string.Empty,
                                                                                                                    "P",
                                                                                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_serie,
                                                                                                                    null));
                    if (lImpNf.Exists(v => v.Imposto.St_ICMS))
                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.PreencherICMS(lImpNf.Find(v => v.Imposto.St_ICMS), bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item);
                    CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.PreencherOutrosImpostos(lImpNf, bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item);
                    bsItensNFCe.ResetCurrentItem();
                }
            }
        }

        private void TFReprocessarFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensCF);
            Utils.ShapeGrid.RestoreShape(this, gItensNota);
            Utils.ShapeGrid.RestoreShape(this, gCTRC);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rNf != null)
            {
                bsNotaFiscal.DataSource = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento() { rNf };
                tcCentral.TabPages.Clear();
                tcCentral.TabPages.Add(tpNf);
            }
            else if (rNFCe != null)
            {
                bsNFCe.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe { rNFCe };
                tcCentral.TabPages.Clear();
                tcCentral.TabPages.Add(tpNFCe);
            }
            BuscarImpostosNota();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bsItensNota_PositionChanged(object sender, EventArgs e)
        {
            BuscarImpostosNota();
        }

        private void TFReprocessarFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensCF);
            Utils.ShapeGrid.SaveShape(this, gItensNota);
            Utils.ShapeGrid.SaveShape(this, gCTRC);
        }

        private void bbDelICMS_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_ICMS))
                    if (MessageBox.Show("Confirma exclusão do ICMS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ICMS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_ICMS = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_imposto = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_retencaoICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_ICMSRetido = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_icms = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_gerarcreditoICMS = false;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcSTICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_ICMSST = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_reducaobasecalcICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaSTICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_redbcstICMS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_situacao = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaICMSDest = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Ds_deducao = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_FCP = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_FCP = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_pauta = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_iva_st = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_modbasecalc = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_modbasecalcST = string.Empty;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbConfigICMS_Click(object sender, EventArgs e)
        {
            using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
            {
                fCondICMS.pCd_empresa = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa;
                fCondICMS.pCd_condfiscal_clifor = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                fCondICMS.pCd_condfiscal_produto = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                fCondICMS.pCd_movto = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring;
                fCondICMS.pCd_UfDest = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E") ?
                    (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_empresa :
                    (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_clifor;
                fCondICMS.pCd_UfOrig = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E") ?
                    (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_clifor :
                    (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_uf_empresa;
                fCondICMS.pTp_movimento = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento;
                fCondICMS.pCd_imposto =
                     new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_icms", vOperador = "=", vVL_Busca = "1" } },
                                    "a.cd_imposto")?.ToString();
                fCondICMS.pCd_st = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_ICMS;
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
                BuscarImpostosNota();
            }
        }

        private void bbDelPIS_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_PIS))
                    if (MessageBox.Show("Confirma exclusão do PIS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_PIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_PIS = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_BaseCreditoPIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_TpCredPIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_TpContribuicaoPIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_detrecisentaPIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_receitaPIS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaPIS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_pis = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcPIS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_gerarcreditoPIS = false;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_situacao = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_totalnotaPIS = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_imposto_unit_PIS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_retencaoPIS = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_retidoPIS = decimal.Zero;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbConfigPIS_Click(object sender, EventArgs e)
        {
            using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
            {
                fCondImposto.pCd_empresa = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa;
                fCondImposto.pCd_condfiscal_clifor = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                fCondImposto.pCd_condfiscal_produto = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                fCondImposto.pCd_movimentacao = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring;
                fCondImposto.pTp_faturamento = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento;
                fCondImposto.pSt_juridica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("J");
                fCondImposto.pSt_fisica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("F");
                fCondImposto.pCd_imposto =
                     new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_pis", vOperador = "=", vVL_Busca = "1" } },
                                    "a.cd_imposto")?.ToString();
                fCondImposto.pCd_st = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_PIS;
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
                BuscarImpostosNota();
            }
        }

        private void bbConfigCofins_Click(object sender, EventArgs e)
        {
            using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
            {
                fCondImposto.pCd_empresa = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa;
                fCondImposto.pCd_condfiscal_clifor = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                fCondImposto.pCd_condfiscal_produto = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                fCondImposto.pCd_movimentacao = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring;
                fCondImposto.pTp_faturamento = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento;
                fCondImposto.pSt_juridica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("J");
                fCondImposto.pSt_fisica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("F");
                fCondImposto.pCd_imposto =
                     new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_cofins", vOperador = "=", vVL_Busca = "1" } },
                                    "a.cd_imposto")?.ToString();
                fCondImposto.pCd_st = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_COFINS;
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
                BuscarImpostosNota();
            }
        }

        private void bbDelCofins_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_COFINS))
                    if (MessageBox.Show("Confirma exclusão do COFINS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_COFINS = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_COFINS = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_BaseCreditoCofins = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_TpCredCofins = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_TpContribuicaoCofins = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_detrecisentaCofins = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_receitaCofins = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaCofins = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_cofins = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcCofins = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_gerarcreditoCofins = false;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_situacao = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_totalnotaCofins = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_imposto_unit_Cofins = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_retencaoCofins = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_retidoCofins = decimal.Zero;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbConfigIPI_Click(object sender, EventArgs e)
        {
            using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
            {
                fCondImposto.pCd_empresa = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa;
                fCondImposto.pCd_condfiscal_clifor = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                fCondImposto.pCd_condfiscal_produto = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                fCondImposto.pCd_movimentacao = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_movimentacaostring;
                fCondImposto.pTp_faturamento = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_movimento;
                fCondImposto.pSt_juridica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("J");
                fCondImposto.pSt_fisica = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("F");
                fCondImposto.pCd_imposto =
                     new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_ipi", vOperador = "=", vVL_Busca = "1" } },
                                    "a.cd_imposto")?.ToString();
                fCondImposto.pCd_st = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_IPI;
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
                BuscarImpostosNota();
            }
        }

        private void bbDelIPI_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_IPI))
                    if (MessageBox.Show("Confirma exclusão do IPI?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_IPI = null;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_ST_IPI = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Pc_aliquotaIPI = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_ipi = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_basecalcIPI = decimal.Zero;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_gerarcreditoIPI = false;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Tp_situacao = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_totalnotaIPI = string.Empty;
                        (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Vl_imposto_unit_ipi = decimal.Zero;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbDelICMSNFCe_Click(object sender, EventArgs e)
        {
            if (bsItensNFCe.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_icms))
                    if (MessageBox.Show("Confirma exclusão do ICMS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_icms = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_icms = string.Empty;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Pc_aliquotaICMS = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_icms = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_basecalcICMS = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Tp_situacao = string.Empty;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Tp_modbasecalc = string.Empty;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Tp_modbasecalcST = string.Empty;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbConfigICMSNFCe_Click(object sender, EventArgs e)
        {
            //Buscar config cupom fiscal
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa, null);
            if (lCfg.Count > 0)
                using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
                {
                    fCondICMS.pCd_empresa = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa;
                    fCondICMS.pCd_condfiscal_clifor = lCfg[0].Cd_condfiscal_clifor;
                    fCondICMS.pCd_condfiscal_produto = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_condfiscal_produto;
                    fCondICMS.pCd_movto = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_movimentacaostr;
                    fCondICMS.pCd_UfDest = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_uf_empresa;
                    fCondICMS.pCd_UfOrig = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_uf_empresa;
                    fCondICMS.pTp_movimento = "S";
                    fCondICMS.pCd_imposto =
                         new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                        new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_icms", vOperador = "=", vVL_Busca = "1" } },
                                        "a.cd_imposto")?.ToString();
                    fCondICMS.pCd_st = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_icms;
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
                    BuscarImpostosNota();
                }
            else MessageBox.Show("Não existe configuração para empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbDelPISNFCe_Click(object sender, EventArgs e)
        {
            if (bsItensNFCe.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_pis))
                    if (MessageBox.Show("Confirma exclusão do PIS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_pis = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_pis = string.Empty;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_tpcontribuicaoPIS = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_detrecisentaPIS = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_receitaPIS = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Pc_aliquotaPIS = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_pis = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_basecalcPIS = decimal.Zero;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbDelCofinsNFCe_Click(object sender, EventArgs e)
        {
            if (bsItensNFCe.Current != null)
                if (!string.IsNullOrWhiteSpace((bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_cofins))
                    if (MessageBox.Show("Confirma exclusão do COFINS?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_cofins = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_cofins = string.Empty;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_tpcontribuicaoCOFINS = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_detrecisentaCofins = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Id_receitaCofins = null;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Pc_aliquotaCofins = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_cofins = decimal.Zero;
                        (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Vl_basecalcCofins = decimal.Zero;
                        bsItensNota.ResetCurrentItem();
                    }
        }

        private void bbConfigPISNFCe_Click(object sender, EventArgs e)
        {
            //Buscar config cupom fiscal
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa, null);
            if (lCfg.Count > 0)
                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                {
                    fCondImposto.pCd_empresa = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa;
                    fCondImposto.pCd_condfiscal_clifor = lCfg[0].Cd_condfiscal_clifor;
                    fCondImposto.pCd_condfiscal_produto = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_condfiscal_produto;
                    fCondImposto.pCd_movimentacao = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_movimentacaostr;
                    fCondImposto.pTp_faturamento = "S";
                    fCondImposto.pSt_juridica = lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("J");
                    fCondImposto.pSt_fisica = lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F");
                    fCondImposto.pCd_imposto =
                         new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                        new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_pis", vOperador = "=", vVL_Busca = "1" } },
                                        "a.cd_imposto")?.ToString();
                    fCondImposto.pCd_st = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_pis;
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
                    BuscarImpostosNota();
                }
            else MessageBox.Show("Não existe configuração para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbConfigCofinsNFCe_Click(object sender, EventArgs e)
        {
            //Buscar config cupom fiscal
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa, null);
            if (lCfg.Count > 0)
                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                {
                    fCondImposto.pCd_empresa = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa;
                    fCondImposto.pCd_condfiscal_clifor = lCfg[0].Cd_condfiscal_clifor;
                    fCondImposto.pCd_condfiscal_produto = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_condfiscal_produto;
                    fCondImposto.pCd_movimentacao = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_movimentacaostr;
                    fCondImposto.pTp_faturamento = "S";
                    fCondImposto.pSt_juridica = lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("J");
                    fCondImposto.pSt_fisica = lCfg[0].Tp_pessoa.Trim().ToUpper().Equals("F");
                    fCondImposto.pCd_imposto =
                         new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                        new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.st_cofins", vOperador = "=", vVL_Busca = "1" } },
                                        "a.cd_imposto")?.ToString();
                    fCondImposto.pCd_st = (bsItensNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe_Item).Cd_st_cofins;
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
                    BuscarImpostosNota();
                }
            else MessageBox.Show("Não existe configuração para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bsItensNFCe_PositionChanged(object sender, EventArgs e)
        {
            BuscarImpostosNota();
        }

        private void pAliquotaIPI_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vl_retidoINSS_ValueChanged(object sender, EventArgs e)
        {

        }

        #region Calc. Auto ICMS
        private void pc_fcp_Leave(object sender, EventArgs e)
        {
            try
            {
                //vl_fcp.Value = vlBaseCalcICMS.Value * (pc_fcp.Value / 100);
            }
            catch { }
        }

        private void vl_fcp_Leave(object sender, EventArgs e)
        {
            try
            {
                //pc_fcp.Value = vl_fcp.Value / vlBaseCalcICMS.Value;
            }
            catch { }
        }

        private void pAliquotaICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                vlICMS.Value = vlBaseCalcICMS.Value * (pAliquotaICMS.Value / 100);
            }
            catch { }
        }

        private void vlICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                pAliquotaICMS.Value = vlICMS.Value / vlBaseCalcICMS.Value;
            }
            catch { }
        }

        private void pRetencaoICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCofins.Value = vlBaseCalcICMS.Value * (pRetencaoICMS.Value / 100);
            }
            catch { }
        }

        private void vlICMSRetido_Leave(object sender, EventArgs e)
        {
            try
            {
                pRetencaoICMS.Value = vl_retidoCofins.Value / vlBaseCalcICMS.Value;
            }
            catch { }
        }

        private void pAliquotaST_Leave(object sender, EventArgs e)
        {
            try
            {
                vlICMSST.Value = vlBCStICMS.Value * (pAliquotaST.Value / 100);
            }
            catch { }
        }

        private void vlICMSST_Leave(object sender, EventArgs e)
        {
            try
            {
                pAliquotaST.Value = vlICMSST.Value / vlBCStICMS.Value;
            }
            catch { }
        }
        #endregion        

        #region Calc. Auto PIS
        private void pc_aliquotaPIS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_pis.Value = vl_basecalcPIS.Value * (pc_aliquotaPIS.Value / 100);
            }
            catch { }
        }

        private void vl_pis_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_aliquotaPIS.Value = (vl_pis.Value / vl_basecalcPIS.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoPIS_Leave(object sender, EventArgs e)
        {
            try
            {
                //Vl. Retenção PIS
                editFloat1.Value = vl_basecalcPIS.Value * (pc_retencaoPIS.Value / 100);
            }
            catch { }
        }

        private void editFloat1_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoPIS.Value = (editFloat1.Value / vl_basecalcPIS.Value) * 100;
            }
            catch { }
        }


        #endregion

        #region Calc. Auto Cofins
        private void pc_aliquotaCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_cofins.Value = vl_basecalcCofins.Value * (pc_aliquotaCofins.Value / 100);
            }
            catch { }
        }

        private void vl_cofins_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_aliquotaCofins.Value = (vl_cofins.Value / vl_basecalcCofins.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCofins.Value = vl_basecalcCofins.Value * (pc_retencaoCofins.Value / 100);
            }
            catch { }
        }

        private void vl_retidoCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoCofins.Value = (vl_retidoCofins.Value / vl_basecalcCofins.Value) * 100;
            }
            catch { }
        }
        #endregion

        #region Calc. Auto IPI
        private void pAliquotaIPI_Leave(object sender, EventArgs e)
        {
            if (vl_baseCalcIPI.Value > decimal.Zero && pAliquotaIPI.Value > decimal.Zero)
                vl_ipi.Value = (vl_baseCalcIPI.Value / 100) * pAliquotaIPI.Value;
            else
                vl_ipi.Value = decimal.Zero;
            vl_ipi.Focus();
        }

        private void Vl_impostoCalcIPI_Leave(object sender, EventArgs e)
        {
            pReducaoBC.Focus();
        }

        private void vl_baseCalcIPI_Leave(object sender, EventArgs e)
        {
            if (vl_baseCalcIPI.Value > decimal.Zero && pAliquotaIPI.Value > decimal.Zero)
                vl_ipi.Value = (vl_baseCalcIPI.Value / 100) * pAliquotaIPI.Value;
            else
                vl_ipi.Value = decimal.Zero;
            pAliquotaIPI.Focus();
        }
        #endregion  

        #region Calc. Auto Serviço
        private void pc_aliquotaISS_Leave(object sender, EventArgs e)
        {
            try
            {
                if (pc_reducaobasecalcISS.Value > 0)
                {
                    decimal baseRedu = vl_basecalcISS.Value * (pc_reducaobasecalcISS.Value / 100);
                    baseRedu = vl_basecalcISS.Value - baseRedu;
                    vl_iss.Value = baseRedu * (pc_aliquotaISS.Value / 100);
                }
                else
                {
                    vl_iss.Value = vl_basecalcISS.Value * (pc_aliquotaISS.Value / 100);
                }
            }
            catch { }
        }

        private void vl_iss_Leave(object sender, EventArgs e)
        {
            try
            {
                if (pc_reducaobasecalcISS.Value > 0)
                {
                    decimal baseRedu = vl_basecalcISS.Value * (pc_reducaobasecalcISS.Value / 100);
                    baseRedu = vl_basecalcISS.Value - baseRedu;
                    pc_aliquotaISS.Value = (vl_iss.Value / baseRedu) * 100;
                }
                else
                {
                    pc_aliquotaISS.Value = (vl_iss.Value / vl_basecalcISS.Value) * 100;
                }
            }
            catch { }
        }

        private void pc_retencaoISS_Leave(object sender, EventArgs e)
        {
            try
            {

                vl_issretido.Value = vl_basecalcISS.Value * (pc_retencaoISS.Value / 100);
            }
            catch { }
        }

        private void vl_issretido_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoISS.Value = (vl_issretido.Value / vl_basecalcISS.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoIRRF_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoIRRF.Value = vl_basecalcIRRF.Value * (pc_retencaoIRRF.Value / 100);
            }
            catch { }
        }

        private void vl_retidoIRRF_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoIRRF.Value = (vl_retidoIRRF.Value / vl_basecalcIRRF.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoCSLL_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCSLL.Value = vl_basecalcCSLL.Value * (pc_retencaoCSLL.Value / 100);
            }
            catch { }
        }

        private void pc_retencaoINSS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoINSS.Value = vl_basecalcINSS.Value * (pc_retencaoINSS.Value / 100);
            }
            catch { }
        }

        private void vl_retidoINSS_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoINSS.Value = vl_retidoINSS.Value / vl_basecalcINSS.Value;
            }
            catch { }
        }

        #endregion

        #region Calc. Auto Funrural/ Senar
        private void pc_funrural_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_funrural.Value = vl_basecalcFunrural.Value * (pc_funrural.Value / 100);
            }
            catch { }
        }

        private void vl_funrural_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_funrural.Value = vl_funrural.Value / vl_basecalcFunrural.Value;
            }
            catch { }
        }

        private void pc_retencaoFunrural_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidofunrural.Value = vl_basecalcFunrural.Value * (pc_retencaoFunrural.Value / 100);
            }
            catch { }
        }

        private void pc_senar_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_senar.Value = vl_basecalcSenar.Value * (pc_senar.Value / 100);
            }
            catch { }
        }

        private void vl_senar_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_senar.Value = vl_senar.Value / vl_basecalcSenar.Value;
            }
            catch { }
        }

        private void pc_retencaoSenar_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoSenar.Value = vl_basecalcSenar.Value * (pc_retencaoSenar.Value / 100);
            }
            catch { }
        }

        private void vl_retidoSenar_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoSenar.Value = vl_retidoSenar.Value / vl_basecalcSenar.Value;
            }
            catch { }
        }
        #endregion

        #region Calc. Auto II
        private void editFloat4_Leave(object sender, EventArgs e)
        {
            //editFloat4 = % Aliquota do II
            try
            {
                //editFloat3 = Vl. II editFloat5 = Base Calc.
                editFloat3.Value = editFloat5.Value * (editFloat4.Value / 100);
            }
            catch { }
        }

        private void editFloat3_Leave(object sender, EventArgs e)
        {
            try
            {
                editFloat4.Value = editFloat3.Value / editFloat5.Value;
            }
            catch { }
        }
        #endregion

        private void vl_percentualINSS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_INSS.Value = vl_basecalcINSS.Value * (vl_percentualINSS.Value / 100);
            }
            catch { }
        }

        private void vl_INSS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_percentualINSS.Value = (vl_INSS.Value / vl_basecalcINSS.Value) * 100;
            }
            catch { }
        }

        private void vl_percentualIRRF_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_IRRF.Value = vl_basecalcIRRF.Value * (vl_percentualIRRF.Value / 100);
            }
            catch { }
        }

        private void vl_IRRF_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_percentualIRRF.Value = (vl_IRRF.Value / vl_basecalcIRRF.Value) * 100;
            }
            catch { }
        }

        private void vl_percentualCSLL_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_CSLL.Value = vl_basecalcINSS.Value * (vl_percentualCSLL.Value / 100);
            }
            catch { }
        }

        private void vl_CSLL_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_percentualCSLL.Value = (vl_CSLL.Value / vl_basecalcINSS.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoCSLL_Leave_1(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCSLL.Value = vl_basecalcINSS.Value * (pc_retencaoCSLL.Value / 100);
            }
            catch { }
        }

        private void pc_redbasecalccsll_Leave(object sender, EventArgs e)
        {
            CalcularCSLL();
        }

        private void CalcularINSS(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcINSS.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcINSS.Value;
                if (pc_redbasecalcinss.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalcinss.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_INSS.Value > decimal.Zero)
                    vl_percentualINSS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_INSS.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (vl_percentualINSS.Value > decimal.Zero)
                    vl_INSS.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualINSS.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoINSS.Value > decimal.Zero)
                    pc_retencaoINSS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoINSS.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoINSS.Value > decimal.Zero)
                    vl_retidoINSS.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoINSS.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void CalcularCSLL(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcCSLL.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcCSLL.Value;
                if (pc_redbasecalccsll.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalccsll.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_CSLL.Value > decimal.Zero)
                    vl_percentualCSLL.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_CSLL.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (vl_percentualCSLL.Value > decimal.Zero)
                    vl_CSLL.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualCSLL.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoCSLL.Value > decimal.Zero)
                    pc_retencaoCSLL.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoCSLL.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoCSLL.Value > decimal.Zero)
                    vl_retidoCSLL.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoCSLL.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void CalcularIRRF(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcIRRF.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcIRRF.Value;
                if (pc_redbasecalcirrf.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalcirrf.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_IRRF.Value > decimal.Zero)
                    vl_percentualIRRF.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_IRRF.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (vl_percentualIRRF.Value > decimal.Zero)
                    vl_IRRF.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualIRRF.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoIRRF.Value > decimal.Zero)
                    pc_retencaoIRRF.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoIRRF.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoIRRF.Value > decimal.Zero)
                    vl_retidoIRRF.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoIRRF.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void pc_redbasecalcinss_Leave(object sender, EventArgs e)
        {
            CalcularINSS();
        }

        private void pc_redbasecalcirrf_Leave(object sender, EventArgs e)
        {
            CalcularIRRF();
        }
    }
}
