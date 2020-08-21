using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFRastrearLancto : Form
    {
        public CamadaDados.Contabil.TRegistro_LanctosCTB rLancto
        { get; set; }

        public TFRastrearLancto()
        {
            InitializeComponent();
        }

        private void BuscarFaturamento(string Id_lote, string Id_loteImp)
        {
            if (!string.IsNullOrEmpty(Id_lote) || !string.IsNullOrEmpty(Id_loteImp))
            {
                if (!string.IsNullOrEmpty(Id_lote))
                    bsFaturamento.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcFaturamento().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.ID_LoteCTB_Fat",
                                                        vOperador = "=",
                                                        vVL_Busca = Id_lote
                                                    }
                                                });
                else
                    bsFaturamento.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcFaturamento().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_ctbimpostosnf x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                                    "and (x.id_lotectb_retido = " + Id_loteImp + " or x.id_lotectb_calculado = " + Id_loteImp + "))"
                                                    }
                                                });
                if (bsFaturamento.Current != null)
                {
                    bsImpostos.DataSource = new CamadaDados.Contabil.TCD_ProcImpostos().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nr_lanctofiscalstr
                                                }
                                            });
                    bsCaixa.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcCaixa().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                                "inner join tb_fat_notafiscal_x_duplicata y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                                "where x.cd_contager = a.cd_contager " +
                                                                "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                                "and y.cd_empresa = '" + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "' " +
                                                                "and y.nr_lanctofiscal = " + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nr_lanctofiscalstr + ")"
                                                }
                                            });
                    bsCheque.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcChequeCompensado().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FIN_Titulo_X_Caixa x " +
                                                                "inner join TB_FIN_Caixa y " +
                                                                "on x.CD_ContaGer = y.CD_ContaGer " +
                                                                "and x.CD_LanctoCaixa = y.CD_LanctoCaixa " +
                                                                "inner join TB_FIN_Liquidacao z " +
                                                                "on y.CD_ContaGer = z.CD_ContaGer " +
                                                                "and y.CD_LanctoCaixa = z.CD_LanctoCaixa " +
                                                                "inner join TB_FAT_NotaFiscal_X_Duplicata w " +
                                                                "on z.CD_Empresa = w.CD_Empresa " +
                                                                "and z.Nr_Lancto = w.Nr_LanctoDuplicata " +
                                                                "where x.CD_ContaGer = a.CD_ContaOrig " +
                                                                "and x.CD_LanctoCaixa = a.cd_lanctocaixaorig " +
                                                                "and w.cd_empresa = '" + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "' " +
                                                                "and w.Nr_LanctoFiscal = " + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nr_lanctofiscalstr + ")"
                                        }
                                    });
                    if (tcFatFin.TabPages.Contains(tpFinanceiro))
                        tcFatFin.TabPages.Remove(tpFinanceiro);
                    if (tcFatFin.TabPages.Contains(tpAdto))
                        tcFatFin.TabPages.Remove(tpAdto);
                }
            }
        }

        private void BuscarCaixa(string Id_lote, string Id_lotech)
        {
            if (!string.IsNullOrEmpty(Id_lote) || !string.IsNullOrEmpty(Id_lotech))
            {
                if (!string.IsNullOrEmpty(Id_lote))
                    bsCaixa.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcCaixa().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.ID_LoteCTB",
                                                        vOperador = "=",
                                                        vVL_Busca = Id_lote
                                                    }
                                                });
                else
                    bsCaixa.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcCaixa().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from VTB_CTB_ProcChequeCompensado x " +
                                                                "where x.CD_ContaOrig = a.CD_Contager " +
                                                                "and x.cd_lanctocaixaorig = a.cd_lanctocaixa " +
                                                                "and x.id_lotectb = " + Id_lotech + ")"
                                                }
                                            });
                if (bsCaixa.Current != null)
                {
                    //Buscar Faturamento
                    bsFaturamento.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcFaturamento().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                                    "inner join tb_fin_liquidacao y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                                    "and y.cd_contager = '" + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "' " +
                                                                    "and y.cd_lanctocaixa = " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Id_lanctocaixastr + ")"
                                                    }
                                                });
                    if (bsFaturamento.Current != null)
                    {
                        //Buscar Impostos
                        bsImpostos.DataSource = new CamadaDados.Contabil.TCD_ProcImpostos().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                                    "inner join tb_fin_liquidacao y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                                    "and y.cd_contager = '" + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "' " +
                                                                    "and y.cd_lanctocaixa = " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Id_lanctocaixastr + ")"
                                                    }
                                                });
                        if (tcFatFin.TabPages.Contains(tpFinanceiro))
                            tcFatFin.TabPages.Remove(tpFinanceiro);
                        if (tcFatFin.TabPages.Contains(tpAdto))
                            tcFatFin.TabPages.Remove(tpAdto);
                    }
                    else
                    {
                        //Buscar Financeiro
                        bsFinanceiro.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcFinanceiro().Select(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_contager = '" + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "' " +
                                                                        "and x.cd_lanctocaixa = " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Id_lanctocaixastr + ")"
                                                        }
                                                    });
                        if (bsFinanceiro.Count > 0)
                        {
                            if (tcFatFin.TabPages.Contains(tpFaturamento))
                                tcFatFin.TabPages.Remove(tpFaturamento);
                            if (tcFatFin.TabPages.Contains(tpAdto))
                                tcFatFin.TabPages.Remove(tpAdto);
                        }
                    }
                    //Buscar Cheques
                    bsCheque.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcChequeCompensado().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FIN_Titulo_X_Caixa x " +
                                                                "where x.CD_ContaGer = a.CD_ContaOrig " +
                                                                "and x.CD_LanctoCaixa = a.cd_lanctocaixaorig " +
                                                                "and x.cd_contager = '" + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "' " +
                                                                "and x.cd_lanctocaixa = " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Id_lanctocaixastr + ")"
                                        }
                                    });
                }
            }
        }

        private void BuscarFinanceiro(string Id_lote)
        {
            if (!string.IsNullOrEmpty(Id_lote))
            {
                bsFinanceiro.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcFinanceiro().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_lotectb",
                                                    vOperador = "=",
                                                    vVL_Busca = Id_lote
                                                }
                                            });
                if (bsFinanceiro.Current != null)
                {
                    bsCaixa.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcCaixa().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                                "where x.cd_contager = a.cd_contager " +
                                                                "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                                "and x.cd_empresa = '" + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa.Trim() + "' " +
                                                                "and x.nr_lancto = " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Nr_lanctostr + ")"
                                                }
                                            });
                    bsCheque.DataSource = new CamadaDados.Contabil.TCD_Lan_ProcChequeCompensado().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_FIN_Titulo_X_Caixa x " +
                                                                        "inner join TB_FIN_Liquidacao y " +
                                                                        "on x.cd_contager = y.cd_contager " +
                                                                        "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                        "where x.CD_ContaGer = a.CD_ContaOrig " +
                                                                        "and x.CD_LanctoCaixa = a.cd_lanctocaixaorig " +
                                                                        "and y.cd_empresa = '" + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa.Trim() + "' " +
                                                                        "and y.nr_lancto = " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Nr_lanctostr + ")"
                                                }
                                            });
                    if (tcFatFin.TabPages.Contains(tpFaturamento))
                        tcFatFin.TabPages.Remove(tpFaturamento);
                    if (tcFatFin.TabPages.Contains(tpAdto))
                        tcFatFin.TabPages.Remove(tpAdto);
                }
            }
        }

        private void BuscarAdiantameto(string Id_lote)
        {
            if (!string.IsNullOrEmpty(Id_lote))
            {
                bsAdto.DataSource = new CamadaDados.Contabil.TCD_ProcAdiantamento().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.id_loteCTB",
                                                vOperador = "=",
                                                vVL_Busca = Id_lote
                                            }
                                        });
                if (bsAdto.Count > 0)
                {
                    if (tcFatFin.TabPages.Contains(tpFaturamento))
                        tcFatFin.TabPages.Remove(tpFaturamento);
                    if (tcFatFin.TabPages.Contains(tpFinanceiro))
                        tcFatFin.TabPages.Remove(tpFinanceiro);
                }
            }
        }

        private void TFRastrearLancto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rLancto.Tp_integracao.Trim().ToUpper().Equals("FA"))
                this.BuscarFaturamento(rLancto.Id_lotectbstr, string.Empty);
            else if (rLancto.Tp_integracao.Trim().ToUpper().Equals("IF"))
                this.BuscarFaturamento(string.Empty, rLancto.Id_lotectbstr);
            else if (rLancto.Tp_integracao.Trim().ToUpper().Equals("CX"))
                this.BuscarCaixa(rLancto.Id_lotectbstr, string.Empty);
            else if (rLancto.Tp_integracao.Trim().ToUpper().Equals("CC"))
                this.BuscarCaixa(string.Empty, rLancto.Id_lotectbstr);
            else if (rLancto.Tp_integracao.Trim().ToUpper().Equals("FI"))
                this.BuscarFinanceiro(rLancto.Id_lotectbstr);
            else if (rLancto.Tp_integracao.Trim().ToUpper().Equals("AD"))
                this.BuscarAdiantameto(rLancto.Id_lotectbstr);
        }

        private void bb_configfat_Click(object sender, EventArgs e)
        {
            if(bsFaturamento.Current != null)
                using (TFCFGFaturamento fCfg = new TFCFGFaturamento())
                {
                    fCfg.pCd_empresa = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa;
                    fCfg.pNm_empresa = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_movtostr;
                    fCfg.pDs_movimentacao = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_movimentacao;
                    fCfg.pCd_clifor = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Clifor;
                    fCfg.pNm_clifor = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).NM_Clifor;
                    fCfg.pCd_produto = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Produto;
                    fCfg.pDs_produto = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).DS_Produto;
                    fCfg.pCd_contadeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_contadeb;
                    fCfg.pClassifdeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_contacred;
                    fCfg.pClassifcred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_classificacaocred;
                    if (fCfg.ShowDialog() == DialogResult.OK)
                        if (fCfg.rFat != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Gravar(fCfg.rFat, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).ForEach(p =>
                                    {
                                        p.CD_ContaCre = fCfg.rFat.CD_Conta_CTB_CRED;
                                        p.Ds_contacred = fCfg.rFat.DS_Conta_CTB_CRED;
                                        p.Cd_classificacaocred = fCfg.rFat.CD_Classificacao_CRED;
                                        p.CD_ContaDeb = fCfg.rFat.CD_Conta_CTB_DEB;
                                        p.Ds_contadeb = fCfg.rFat.DS_Conta_CTB_DEB;
                                        p.Cd_classificacaodeb = fCfg.rFat.CD_Classificacao_DEB;
                                    });
                                bsFaturamento.ResetBindings(true);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_configImp_Click(object sender, EventArgs e)
        {
            if(bsImpostos.Current != null)
                using (TFCFGImpostos fCfg = new TFCFGImpostos())
                {
                    fCfg.pCd_empresa = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_empresa;
                    fCfg.pNm_empresa = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_movimentacao.Value.ToString();
                    fCfg.pDs_movimentacao = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_movimentacao;
                    fCfg.pCd_imposto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_imposto.Value.ToString();
                    fCfg.pDs_imposto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_imposto;
                    fCfg.pCd_clifor = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_clifor;
                    fCfg.pNm_clifor = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Nm_clifor;
                    fCfg.pCd_produto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_produto;
                    fCfg.pDs_produto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_produto;
                    if ((bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_deb.HasValue)
                    {
                        fCfg.pCd_contadeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_deb.Value.ToString();
                        fCfg.pDs_contadeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_contactb_deb;
                        fCfg.pClassifdeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_classificacao_deb;
                    }
                    if ((bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_cred.HasValue)
                    {
                        fCfg.pCd_contacred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_cred.Value.ToString();
                        fCfg.pDs_contacred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_contactb_cred;
                        fCfg.pClassifcred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_classificacao_cred;
                    }
                    if (fCfg.ShowDialog() == DialogResult.OK)
                        if (fCfg.rImp != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Gravar(fCfg.rImp, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsImpostos.DataSource = new CamadaDados.Contabil.TCD_ProcImpostos().Select(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.nr_lanctofiscal",
                                                                vOperador = "=",
                                                                vVL_Busca = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nr_lanctofiscalstr
                                                            }
                                                        });
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_configCx_Click(object sender, EventArgs e)
        {
            if(bsCaixa.Current != null)
                using (TFCFGCaixa fCfg = new TFCFGCaixa())
                {
                    fCfg.pCd_empresa = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Empresa;
                    fCfg.pNm_empresa = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Nm_empresa;
                    fCfg.pCd_historico = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Historico;
                    fCfg.pDs_historico = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).DS_Historico;
                    fCfg.pCd_contager = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer;
                    fCfg.pDs_contager = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).DS_ContaGer;
                    fCfg.pTp_movimento = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).TP_Movimento;
                    fCfg.pCd_contadeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Ds_contadeb;
                    fCfg.pClassifdeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Ds_contacred;
                    fCfg.pClassifcred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_classificacao_cred;
                    if (fCfg.ShowDialog() == DialogResult.OK)
                        if (fCfg.rCaixa != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Gravar(fCfg.rCaixa, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).ForEach(p =>
                                {
                                    p.CD_ContaCre = fCfg.rCaixa.CD_Conta_CTB_CRED;
                                    p.Ds_contacred = fCfg.rCaixa.DS_Conta_CTB_CRED;
                                    p.Cd_classificacao_cred = fCfg.rCaixa.CD_Classificacao_CRED;
                                    p.CD_ContaDeb = fCfg.rCaixa.CD_Conta_CTB_DEB;
                                    p.Ds_contadeb = fCfg.rCaixa.DS_Conta_CTB_DEB;
                                    p.Cd_classificacao_deb = fCfg.rCaixa.CD_Classificacao_DEB;
                                });
                                bsCaixa.ResetBindings(true);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_configCh_Click(object sender, EventArgs e)
        {
            if(bsCheque.Current != null)
                using (TFCFGChequeComp fCfg = new TFCFGChequeComp())
                {
                    fCfg.pCd_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_Empresa;
                    fCfg.pNm_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Nm_empresa;
                    fCfg.pCd_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerOrig;
                    fCfg.pDs_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerOrig;
                    fCfg.pCd_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerDest;
                    fCfg.pDs_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerDest;
                    fCfg.pTp_movimento = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).TP_Movimento;
                    fCfg.pCd_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contadeb;
                    fCfg.pCd_classificacaodeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contacredstr;
                    fCfg.pDs_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contacred;
                    fCfg.pCd_classificacaocred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_cred;
                    if (fCfg.ShowDialog() == DialogResult.OK)
                        if (fCfg.rCheque != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Gravar(fCfg.rCheque, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).ForEach(p =>
                                {
                                    p.Cd_contacred = fCfg.rCheque.Cd_conta_ctb_cred;
                                    p.Ds_contacred = fCfg.rCheque.Ds_conta_ctb_cred;
                                    p.Cd_classificacao_cred = fCfg.rCheque.Cd_classificacao_cred;
                                    p.Cd_contadeb = fCfg.rCheque.Cd_conta_ctb_deb;
                                    p.Ds_contadeb = fCfg.rCheque.Ds_conta_ctb_deb;
                                    p.Cd_classificacao_deb = fCfg.rCheque.Cd_classificacao_deb;
                                });
                                bsCheque.ResetBindings(true);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_procfat_Click(object sender, EventArgs e)
        {
            if(bsFaturamento.Count > 0)
                try
                {
                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Faturamento(bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>, null);
                    MessageBox.Show("Processamento Contábil FATURAMENTO concluido com sucesso.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_procImp_Click(object sender, EventArgs e)
        {
            if(bsImpostos.Count > 0)
                try
                {
                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Impostos(bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>, null);
                    MessageBox.Show("Processamento Contábil IMPOSTOS concluido com sucesso.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_procCx_Click(object sender, EventArgs e)
        {
            if(bsCaixa.Count > 0)
                try
                {
                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Caixa(bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>, null);
                    MessageBox.Show("Processamento Contábil CAIXA concluido com sucesso.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_procCh_Click(object sender, EventArgs e)
        {
            if(bsCheque.Count > 0)
                try
                {
                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ChequeCompensado(bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>, null);
                    MessageBox.Show("Processamento Contábil COMPENSAÇÃO CHEQUES concluido com sucesso.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_configFin_Click(object sender, EventArgs e)
        {
            if(bsFinanceiro.Current != null)
                using (TFCFGFinanceiro fCfg = new TFCFGFinanceiro())
                {
                    fCfg.pCd_empresa = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa;
                    fCfg.pNm_empresa = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Nm_empresa;
                    fCfg.pCd_historico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Historico;
                    fCfg.pDs_historico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).DS_Historico;
                    fCfg.pTp_movhistorico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Tp_movhistorico;
                    fCfg.pCd_clifor = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Clifor;
                    fCfg.pNm_clifor = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).NM_Clifor;
                    fCfg.pTp_duplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).TP_Duplicata;
                    fCfg.pDs_tpduplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_tpduplicata;
                    fCfg.pTp_movduplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Tp_movduplicata;
                    fCfg.pCd_contadeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_contadeb;
                    fCfg.pClassifdeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_contacre;
                    fCfg.pClassifcred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_classificacaocre;
                    if (fCfg.ShowDialog() == DialogResult.OK)
                        if (fCfg.rFin != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Gravar(fCfg.rFin, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).ForEach(p =>
                                {
                                    p.CD_ContaCre = fCfg.rFin.Cd_conta_ctb_cred;
                                    p.Ds_contacre = fCfg.rFin.Ds_conta_ctb_cred;
                                    p.Cd_classificacaocre = fCfg.rFin.Cd_classificacao_cred;
                                    p.CD_ContaDeb = fCfg.rFin.Cd_conta_ctb_deb;
                                    p.Ds_contadeb = fCfg.rFin.Ds_conta_ctb_deb;
                                    p.Cd_classificacaodeb = fCfg.rFin.Cd_classificacao_deb;
                                });
                                bsFinanceiro.ResetBindings(true);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_procfin_Click(object sender, EventArgs e)
        {
            if (bsFinanceiro.Count > 0)
                try
                {
                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Financeiro(bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>, null);
                    MessageBox.Show("Processamento Contábil FINANCEIRO concluido com sucesso.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_configAdto_Click(object sender, EventArgs e)
        {
            //if (bsAdto.Current != null)
            //    using (TFCFGAdiantamento fCfg = new TFCFGAdiantamento())
            //    {
            //        fCfg.pCd_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_Empresa;
            //        fCfg.pNm_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Nm_empresa;
            //        fCfg.pCd_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerOrig;
            //        fCfg.pDs_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerOrig;
            //        fCfg.pCd_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerDest;
            //        fCfg.pDs_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerDest;
            //        fCfg.pTp_movimento = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).TP_Movimento;
            //        fCfg.pCd_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contadebstr;
            //        fCfg.pDs_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contadeb;
            //        fCfg.pCd_classificacaodeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_deb;
            //        fCfg.pCd_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contacredstr;
            //        fCfg.pDs_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contacred;
            //        fCfg.pCd_classificacaocred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_cred;
            //        if (fCfg.ShowDialog() == DialogResult.OK)
            //            if (fCfg.rCheque != null)
            //                try
            //                {
            //                    CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Gravar(fCfg.rCheque, null);
            //                    MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).ForEach(p =>
            //                    {
            //                        p.Cd_contacred = fCfg.rCheque.Cd_conta_ctb_cred;
            //                        p.Ds_contacred = fCfg.rCheque.Ds_conta_ctb_cred;
            //                        p.Cd_classificacao_cred = fCfg.rCheque.Cd_classificacao_cred;
            //                        p.Cd_contadeb = fCfg.rCheque.Cd_conta_ctb_deb;
            //                        p.Ds_contadeb = fCfg.rCheque.Ds_conta_ctb_deb;
            //                        p.Cd_classificacao_deb = fCfg.rCheque.Cd_classificacao_deb;
            //                    });
            //                    bsCheque.ResetBindings(true);
            //                }
            //                catch (Exception ex)
            //                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //    }
        }

        private void dataGridDefault3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
