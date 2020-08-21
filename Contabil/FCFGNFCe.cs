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
    public partial class TFCFGNFCe : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_cfop
        { get; set; }
        public string pDs_cfop
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
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

        private CamadaDados.Contabil.TRegistro_CTB_CFGNFCe rfat;
        public CamadaDados.Contabil.TRegistro_CTB_CFGNFCe rFat
        {
            get
            {
                if (bsCfgNFCe.Current != null)
                    return bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe;
                else return null;
            }
            set { rfat = value; }
        }

        public TFCFGNFCe()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFCFGNFCe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rfat != null)
            {
                bsCfgNFCe.DataSource = new CamadaDados.Contabil.TList_CTB_CFGNFCe() { rfat };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_cfop.Enabled = false;
                bb_cfop.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsCfgNFCe.AddNew();
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Cd_empresa = pCd_empresa;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Nm_empresa = pNm_empresa;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Cd_cfop = pCd_cfop;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Ds_cfop = pDs_cfop;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Cd_produto = pCd_produto;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).Ds_produto = pDs_produto;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).CD_Conta_CTB_CRED_String = pCd_contacred;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).DS_Conta_CTB_CRED = pDs_contacred;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).CD_Classificacao_CRED = pClassifcred;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).CD_Conta_CTB_DEB_String = pCd_contadeb;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).DS_Conta_CTB_DEB = pDs_contadeb;
                (bsCfgNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe).CD_Classificacao_DEB = pClassifdeb;
                bsCfgNFCe.ResetCurrentItem();
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

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_CFOP|CFOP|350;a.CD_CFOP|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop, ds_cfop },
                                            new CamadaDados.Fiscal.TCD_CadCFOP(), string.Empty);
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_cfop, ds_cfop }, new CamadaDados.Fiscal.TCD_CadCFOP());
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

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCFGNFCe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
