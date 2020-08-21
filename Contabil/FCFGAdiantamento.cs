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
    public partial class TFCFGAdiantamento : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pCd_historico
        { get; set; }
        public string pDs_historico
        { get; set; }
        public string pCd_contager
        { get; set; }
        public string pDs_contager
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

        private CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento radto;
        public CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento rAdto
        {
            get
            {
                if (bsAdto.Current != null)
                    return bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento;
                else return null;
            }
            set { radto = value; }
        }

        public TFCFGAdiantamento()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("CONCEDIDO", "C"));
            cbx.Add(new Utils.TDataCombo("RECEBIDO", "R"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGAdiantamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (radto != null)
            {
                bsAdto.DataSource = new CamadaDados.Contabil.TList_CTB_CFGAdiantamento() { radto };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_historico.Enabled = false;
                bb_historico.Enabled = false;
                tp_movimento.Enabled = false;
                cd_contager.Enabled = false;
                bb_contager.Enabled = false;
            }
            else
            {
                bsAdto.AddNew();
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_empresa = pCd_empresa;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Nm_empresa = pNm_empresa;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_clifor = pCd_clifor;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Nm_clifor = pNm_clifor;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_historico = pCd_historico;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Ds_historico = pDs_historico;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_contager = pCd_contager;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Ds_contager = pDs_contager;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Tp_movimento = pTp_movimento;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_conta_ctb_credstr = pCd_contacred;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Ds_conta_ctb_cred = pDs_contacred;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_classificacao_cred = pClassifcred;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Ds_conta_ctb_deb = pDs_contadeb;
                (bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento).Cd_classificacao_deb = pClassifdeb;
                bsAdto.ResetCurrentItem();
            }
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
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

        private void TFCFGAdiantamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;

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
    }
}
