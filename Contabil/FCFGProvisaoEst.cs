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
    public partial class TFCFGProvisaoEst : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pTp_movimento
        { get; set; }
        public string pCd_contadeb
        { get; set; }
        public string pDs_contadeb
        { get; set; }
        public string pClassificacaodeb
        { get; set; }
        public string pCd_contacred
        { get; set; }
        public string pDs_contacred
        { get; set; }
        public string pClassificacaocred
        { get; set; }

        private CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque rprov;
        public CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque rProv
        {
            get
            {
                if (bsProvisao.Current != null)
                    return bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque;
                else return null;
            }
            set { rprov = value; }
        }

        public TFCFGProvisaoEst()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ENTRADA", "E"));
            cbx.Add(new Utils.TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGProvisaoEst_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rprov != null)
            {
                bsProvisao.DataSource = new CamadaDados.Contabil.TList_CTB_CFGProvisao_Estoque() { rprov };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                tp_movimento.Enabled = false;
            }
            else
            {
                bsProvisao.AddNew();
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).Cd_empresa = pCd_empresa;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).Nm_empresa = pNm_empresa;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).CD_Produto = pCd_produto;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).DS_Produto = pDs_produto;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).Tp_movimento = pTp_movimento;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).CD_Conta_CTB_CRED_String = pCd_contacred;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).DS_Conta_CTB_CRED = pDs_contacred;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).CD_Classificacao_CRED = pClassificacaocred;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).CD_Conta_CTB_DEB_String = pCd_contadeb;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).DS_Conta_CTB_DEB = pDs_contadeb;
                (bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque).CD_Classificacao_DEB = pClassificacaodeb;
                bsProvisao.ResetCurrentItem();
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

        private void TFCFGProvisaoEst_KeyDown(object sender, KeyEventArgs e)
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

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
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
