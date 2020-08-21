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
    public partial class TFCFGCMV : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_movimentacao
        { get; set; }
        public string pDs_movimentacao
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
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

        private CamadaDados.Contabil.TRegistro_CTB_CFGCMV rcmv;
        public CamadaDados.Contabil.TRegistro_CTB_CFGCMV rCmv
        {
            get
            {
                if (bsCMV.Current != null)
                    return bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV;
                else return null;
            }
            set { rcmv = value; }
        }

        public TFCFGCMV()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGCMV_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcmv != null)
            {
                bsCMV.DataSource = new CamadaDados.Contabil.TList_CTB_CFGCMV() { rcmv };
                CD_Empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_movimentacao.Enabled = false;
                bb_movimentacao.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsCMV.AddNew();
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_empresa = pCd_empresa;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Nm_empresa = pNm_empresa;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_movimentacaostr = pCd_movimentacao;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Ds_movimentacao = pDs_movimentacao;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_produto = pCd_produto;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Ds_produto = pDs_produto;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_conta_ctb_credstr = pCd_contacred;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Ds_conta_ctb_cred = pDs_contacred;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_classificacao_cred = pClassifcred;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Ds_conta_ctb_deb = pDs_contadeb;
                (bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV).Cd_classificacao_deb = pClassifdeb;
                bsCMV.ResetCurrentItem();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), "a.TP_Movimento|=|'S'");
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|" + cd_movimentacao.Text.Trim() + ";a.TP_Movimento|=|'S'",
                new Componentes.EditDefault[]{cd_movimentacao, ds_movimentacao}, new CamadaDados.Fiscal.TCD_CadMovimentacao());
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCFGCMV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
