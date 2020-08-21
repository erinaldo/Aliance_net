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
    public partial class TFCFGFinanceiro : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pTp_duplicata
        { get; set; }
        public string pDs_tpduplicata
        { get; set; }
        public string pTp_movduplicata
        { get; set; }
        public string pCd_historico
        { get; set; }
        public string pDs_historico
        { get; set; }
        public string pTp_movhistorico
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pCd_contacred
        { get; set; }
        public string pDs_contacred
        { get; set; }
        public string pClassifcred
        { get; set; }
        public string pCd_contadeb
        { get; set; }
        public string pDs_contadeb
        { get; set; }
        public string pClassifdeb
        { get; set; }

        private CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro rfin;
        public CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro rFin
        {
            get
            {
                if (bsFinanceiro.Current != null)
                    return bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro;
                else return null;
            }
            set { rfin = value; }
        }

        public TFCFGFinanceiro()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGFinanceiro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rfin != null)
            {
                bsFinanceiro.DataSource = new CamadaDados.Contabil.TList_CTB_CFGFinanceiro() { rfin };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                tp_duplicata.Enabled = false;
                bb_tpduplicata.Enabled = false;
                cd_historico.Enabled = false;
                bb_historico.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
            }
            else
            {
                bsFinanceiro.AddNew();
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_empresa = pCd_empresa;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Nm_empresa = pNm_empresa;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_historico = pCd_historico;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Ds_historico = pDs_historico;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Tp_mov_historico = pTp_movhistorico;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_clifor = pCd_clifor;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Nm_clifor = pNm_clifor;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Tp_duplicata = pTp_duplicata;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Ds_tpduplicata = pDs_tpduplicata;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Tp_mov_duplicata = pTp_movduplicata;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_conta_ctb_credstr = pCd_contacred;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Ds_conta_ctb_cred = pDs_contacred;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_classificacao_cred = pClassifcred;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Ds_conta_ctb_deb = pDs_contadeb;
                (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro).Cd_classificacao_deb = pClassifdeb;
                bsFinanceiro.ResetCurrentItem();
            }
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(tp_movhistorico.Text))
                vParam = "a.tp_mov|=|'" + tp_movhistorico.Text.Trim().ToUpper() + "'";
            FormBusca.UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movdup }, vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(tp_movhistorico.Text))
                vParam += ";a.tp_mov|=|'" + tp_movhistorico.Text.Trim().ToUpper() + "'";
            FormBusca.UtilPesquisa.EDIT_LeaveTpDuplicata(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movdup });
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Historico|Descrição|350;a.CD_Historico|Cód. Histórico|150;a.tp_mov|Tipo Movimento|80";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(tp_movdup.Text))
                vParam += ";a.tp_mov|=|'" + tp_movdup.Text.Trim().ToUpper() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico, tp_movhistorico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(tp_movdup.Text))
                vParam += ";a.tp_mov|=|'" + tp_movdup.Text.Trim().ToUpper() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico, tp_movhistorico }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_contadeb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contadeb.Text = rConta.Cd_conta_ctbstr;
                ds_contadeb.Text = rConta.Ds_contactb.Trim();
                classificacaodeb.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contadeb_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_contadeb.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_contadeb, ds_contadeb, classificacaodeb },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contacred.Text = rConta.Cd_conta_ctbstr;
                ds_contacred.Text = rConta.Ds_contactb.Trim();
                classificacaocred.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contacred_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_contacred.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_contacred, ds_contacred, classificacaocred },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCFGFinanceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
