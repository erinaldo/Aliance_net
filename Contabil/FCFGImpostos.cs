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
    public partial class TFCFGImpostos : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_movimentacao
        { get; set; }
        public string pDs_movimentacao
        { get; set; }
        public string pCd_imposto
        { get; set; }
        public string pDs_imposto
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
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

        private CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento rimp;
        public CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento rImp
        {
            get
            {
                if (bsImpostos.Current != null)
                    return bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento;
                else return null;
            }
            set { rimp = value; }
        }

        public TFCFGImpostos()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGImpostos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rimp != null)
            {
                bsImpostos.DataSource = new CamadaDados.Contabil.TList_CFGImpostoFaturamento() { rimp };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_movimentacao.Enabled = false;
                bb_movimentacao.Enabled = false;
                cd_imposto.Enabled = false;
                bb_imposto.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsImpostos.AddNew();
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_empresa = pCd_empresa;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Nm_empresa = pNm_empresa;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_movimentacaostr = pCd_movimentacao;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Ds_movimentacao = pDs_movimentacao;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_impostostr = pCd_imposto;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Ds_imposto = pDs_imposto;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_clifor = pCd_clifor;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Nm_clifor = pNm_clifor;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_produto = pCd_produto;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Ds_produto = pDs_produto;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_conta_ctb_credstr = pCd_contacred;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Ds_contactb_cred = pDs_contacred;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_classificacao_cred = pClassifcred;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Ds_contactb_deb = pDs_contadeb;
                (bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento).Cd_classificacao_deb = pClassifdeb;
                bsImpostos.ResetCurrentItem();
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
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_imposto|Imposto|350;a.cd_imposto|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_imposto|=|'" + cd_imposto.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_imposto, ds_imposto }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
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

        private void TFCFGImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
