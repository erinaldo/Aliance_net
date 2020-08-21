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
    public partial class TFCFGCompFixar : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pTp_registro
        { get; set; }
        public string pTp_movimento
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

        private CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao rcomp;
        public CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao rComp
        {
            get
            {
                if (bsCompFixar.Current != null)
                    return bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao;
                else return null;
            }
            set { rcomp = value; }
        }

        public TFCFGCompFixar()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ESTORNO", "E"));
            cbx.Add(new Utils.TDataCombo("ATUALIZAÇÃO", "A"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("COMPRA", "C"));
            cbx1.Add(new Utils.TDataCombo("VENDA", "V"));
            tp_movimento.DataSource = cbx1;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFCFGCompFixar_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcomp != null)
            {
                bsCompFixar.DataSource = new CamadaDados.Contabil.TList_CTB_CFGCompFixacao() { rcomp };
                CD_Empresa.Enabled = false;
                btn_Empresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                tp_registro.Enabled = false;
            }
            else
            {
                bsCompFixar.AddNew();
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_empresa = pCd_empresa;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Nm_empresa = pNm_empresa;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_produto = pCd_produto;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Ds_produto = pDs_produto;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_conta_ctb_credstr = pCd_contacred;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Ds_conta_ctb_cred = pDs_contacred;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_classificacao_cred = pClassifcred;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_conta_ctb_debstr = pCd_contadeb;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Ds_conta_ctb_deb = pDs_contadeb;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Cd_classificacao_deb = pClassifdeb;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Tp_registro = pTp_registro;
                (bsCompFixar.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao).Tp_movimento = pTp_movimento;
                bsCompFixar.ResetCurrentItem();
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

        private void TFCFGCompFixar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
