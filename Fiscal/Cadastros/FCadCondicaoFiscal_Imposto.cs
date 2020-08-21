using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadCondicaoFiscal_Imposto : FormCadPadrao.FFormCadPadrao
    {
        public bool st_maximizar = true;
        public string pCd_empresa
        { get; set; }
        public decimal pCd_movimentacao
        { get; set; }
        public string pTp_faturamento
        { get; set; }
        public string pTp_pessoa
        { get; set; }
        public string pCd_condfiscal_clifor
        { get; set; }
        public string pCd_condfiscal_produto
        { get; set; }
        public string pCd_imposto
        { get; set; }

        public TFCadCondicaoFiscal_Imposto()
        {
            InitializeComponent();
            DTS = bs_CondFiscalImposto;           
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bs_CondFiscalImposto.AddNew();
            bnCondFiscalImposto.Enabled = false;
            base.afterNovo();
            gCondFiscalClifor.Enabled = true;
            gCondFiscalProd.Enabled = true;
            gMovimentacao.Enabled = true;
            if (bsCondFiscalClifor.Count > 0)
            {
                (bsCondFiscalClifor.List as TList_CadConFiscalClifor).ForEach(p => p.St_agregar = false);
                bsCondFiscalClifor.ResetBindings(true);
            }
            if (bsCondFiscalProduto.Count > 0)
            {
                (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = false);
                bsCondFiscalProduto.ResetBindings(true);
            }
            if (bsMovimentacao.Count > 0)
            {
                (bsMovimentacao.List as TList_CadMovimentacao).ForEach(p => p.St_agregar = false);
                bsMovimentacao.ResetBindings(true);
            }
            Vl_TotFaturadoBase.Enabled = !(rbSempre.Checked);
            this.CD_Imposto.Focus();
            if (!st_maximizar)
                this.PreencherCampos();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bnCondFiscalImposto.Enabled = false;
            CD_Imposto.Enabled = false;
            bb_imposto.Enabled = false;
            CD_Empresa.Enabled = false;
            bb_Empresa.Enabled = false;
            gCondFiscalProd.Enabled = false;
            gCondFiscalClifor.Enabled = false;
            gMovimentacao.Enabled = false;
            rgTpPessoa.Enabled = false;
            if((this.vTP_Modo == Utils.TTpModo.tm_Insert)||(this.vTP_Modo == Utils.TTpModo.tm_Edit))
                Vl_TotFaturadoBase.Enabled = !(rbSempre.Checked);
            this.cd_st.Focus();
        }

        public override void afterCancela()
        {
            bnCondFiscalImposto.Enabled = true;
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                base.afterCancela();
                gCondFiscalClifor.Enabled = false;
                gCondFiscalProd.Enabled = false;
                gMovimentacao.Enabled = false;
                if (vTP_Modo == TTpModo.tm_Insert)
                    bs_CondFiscalImposto.RemoveCurrent();
            }
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CondicaoFiscalImposto.deletarFisImposto((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto), null);
                    bs_CondFiscalImposto.RemoveCurrent();
                    pDados.LimparRegistro();
                    this.buscarRegistros();
                }
            }
        }

        public override void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                base.afterBusca();
                gCondFiscalClifor.Enabled = false;
                gCondFiscalProd.Enabled = false;
                gMovimentacao.Enabled = false;
            }
        }

        public override string gravarRegistro()
        {
            
            if (bsMovimentacao.Count.Equals(0))
                return string.Empty;
            if (bsCondFiscalClifor.Count.Equals(0))
                return string.Empty;
            if (bsCondFiscalProduto.Count.Equals(0))
                return string.Empty;
            return TCN_CondicaoFiscalImposto.gravarFiscImposto((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto),
                                                                (bsMovimentacao.List as TList_CadMovimentacao).FindAll(p=> p.St_agregar),
                                                                (bsCondFiscalClifor.List as TList_CadConFiscalClifor).FindAll(p=> p.St_agregar),
                                                                (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).FindAll(p=> p.St_agregar),
                                                                cbFisica.Checked,
                                                                cbJuridica.Checked,
                                                                null);
        }

        private void FCadCondicaoFiscal_Imposto_Load(object sender, EventArgs e)
        {
            
        }

        private void TFCadCondicaoFiscal_Imposto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMovimentacao);
            Utils.ShapeGrid.SaveShape(this, gCondFiscalClifor);
            Utils.ShapeGrid.SaveShape(this, gCondFiscalProd);
            Utils.ShapeGrid.SaveShape(this, gCondFisImposto);
        }
    }
}

