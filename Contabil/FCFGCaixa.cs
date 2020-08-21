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
    public partial class TFCFGCaixa : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_contager
        { get; set; }
        public string pDs_contager
        { get; set; }
        public string pCd_historico
        { get; set; }
        public string pDs_historico
        { get; set; }
        public string pTp_movimento
        { get; set; }
        public string pCd_contadeb
        { get; set; }
        public string pDs_contadeb
        { get; set; }
        public string pClassifdeb
        { get; set; }
        public string pCd_contacred
        { get; set; }
        public string pDs_contacred
        { get; set; }
        public string pClassifcred
        { get; set; }

        private CamadaDados.Contabil.TRegistro_CTB_CFGCaixa rcaixa;
        public CamadaDados.Contabil.TRegistro_CTB_CFGCaixa rCaixa
        {
            get
            {
                if (bsCaixa.Current != null)
                    return bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa;
                else return null;
            }
            set { rcaixa = value; }
        }

        public TFCFGCaixa()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGCaixa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcaixa != null)
            {
                bsCaixa.DataSource = new CamadaDados.Contabil.TList_CTB_CFGCaixa() { rcaixa };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_contager.Enabled = false;
                bb_contager.Enabled = false;
                cd_historico.Enabled = false;
                bb_historico.Enabled = false;
                tp_movimento.Enabled = false;
            }
            else
            {
                bsCaixa.AddNew();
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Empresa = pCd_empresa;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).NM_Empresa = pNm_empresa;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_ContaGer = pCd_contager;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).DS_ContaGer = pDs_contager;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Historico = pCd_historico;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).DS_Historico = pDs_historico;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).TP_Movimento = pTp_movimento;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Conta_CTB_CRED_String = pCd_contacred;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).DS_Conta_CTB_CRED = pDs_contacred;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Classificacao_CRED = pClassifcred;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Conta_CTB_DEB_String = pCd_contadeb;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).DS_Conta_CTB_DEB = pDs_contadeb;
                (bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa).CD_Classificacao_DEB = pClassifdeb;
                bsCaixa.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCFGCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição Conta Gerencial|350;a.CD_ContaGer|Código|100",
            new Componentes.EditDefault[] { cd_contager, ds_contager },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contager, ds_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_historico|Histórico|350;a.CD_Historico|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historico.Text + "'"
            , new Componentes.EditDefault[] { cd_historico, ds_historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
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
    }
}
