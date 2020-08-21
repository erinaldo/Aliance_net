using CamadaDados.Contabil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFCFGCartao_DC : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_contagerorig
        { get; set; }
        public string pDs_contagerorig
        { get; set; }
        public string pCd_contagerdest
        { get; set; }
        public string pDs_contagerdest
        { get; set; }
        public string pTp_movimento
        { get; set; }
        public string pCd_contadeb
        { get; set; }
        public string pDs_contadeb
        { get; set; }
        public string pCd_classificacaodeb
        { get; set; }
        public string pCd_contacred
        { get; set; }
        public string pDs_contacred
        { get; set; }
        public string pCd_classificacaocred
        { get; set; }

        private TRegistro_CTB_CFGCartao_DC rcartao;
        public TRegistro_CTB_CFGCartao_DC rCartao
        {
            get
            {
                if (bsCartao.Current != null)
                    return bsCartao.Current as TRegistro_CTB_CFGCartao_DC;
                else return null;
            }
            set { rcartao = value; }
        }

        public TFCFGCartao_DC()
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
                DialogResult = DialogResult.OK;
        }

        private void TFCFGCartao_DC_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcartao != null)
            {
                bsCartao.DataSource = new TList_CTB_CFGCartao_DC() { rcartao };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_contagerent.Enabled = false;
                bb_contagerent.Enabled = false;
                cd_contagersai.Enabled = false;
                bb_contagersai.Enabled = false;
                tp_movimento.Enabled = false;
            }
            else
            {
                bsCartao.AddNew();
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_empresa = pCd_empresa;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Nm_empresa = pNm_empresa;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_contager_saida = pCd_contagerorig;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Ds_contager_saida = pDs_contagerorig;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_contager_entrada = pCd_contagerdest;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Ds_contager_entrada = pDs_contagerdest;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).TP_Movimento = pTp_movimento;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_conta_ctb_credstr = pCd_contacred;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Ds_conta_ctb_cred = pDs_contacred;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_classificacao_cred = pCd_classificacaocred;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Ds_conta_ctb_deb = pDs_contadeb;
                (bsCartao.Current as TRegistro_CTB_CFGCartao_DC).Cd_classificacao_deb = pCd_classificacaodeb;
                bsCartao.ResetCurrentItem();
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

        private void bb_contagerent_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagerent, ds_contagerent },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerent_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerent.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerent, ds_contagerent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contagersai_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagersai, ds_contagersai },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagersai_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagersai.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagersai, ds_contagersai },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
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
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCFGCartao_DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
