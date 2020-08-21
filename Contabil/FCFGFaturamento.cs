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
    public partial class TFCFGFaturamento : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_movimentacao
        { get; set; }
        public string pDs_movimentacao
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pCd_grupo
        { get; set; }
        public string pDs_grupo
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

        private CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento rfat;
        public CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento rFat
        {
            get
            {
                if (bsCfgFat.Current != null)
                    return bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento;
                else return null;
            }
            set { rfat = value; }
        }

        public TFCFGFaturamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCFGFaturamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rfat != null)
            {
                bsCfgFat.DataSource = new CamadaDados.Contabil.TList_CTB_CFGFaturamento() { rfat };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_movimentacao.Enabled = false;
                bb_movimentacao.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsCfgFat.AddNew();
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Empresa = pCd_empresa;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).NM_Empresa = pNm_empresa;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Movimentacao_String = pCd_movimentacao;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).DS_Movimentacao = pDs_movimentacao;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Clifor = pCd_clifor;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).NM_Clifor = pNm_clifor;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Produto = pCd_produto;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).DS_Produto = pDs_produto;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).Cd_grupo = pCd_grupo;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).Ds_grupo = pDs_grupo;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Conta_CTB_CRED_String = pCd_contacred;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).DS_Conta_CTB_CRED = pDs_contacred;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Classificacao_CRED = pClassifcred;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Conta_CTB_DEB_String = pCd_contadeb;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).DS_Conta_CTB_DEB = pDs_contadeb;
                (bsCfgFat.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento).CD_Classificacao_DEB = pClassifdeb;
                bsCfgFat.ResetCurrentItem();
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

        private void TFCFGFaturamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_grupo|Grupo Produto|200;a.cd_grupo|Código|50",
                new Componentes.EditDefault[] { cd_grupo, ds_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), "isnull(a.tp_grupo, 'A')|=|'A'");
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';isnull(a.tp_registro, 'A')|=|'A'",
                new Componentes.EditDefault[] { cd_grupo, ds_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }
    }
}
