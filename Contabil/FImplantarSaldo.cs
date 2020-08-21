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
    public partial class TFImplantarSaldo : Form
    {
        private string pcd_empresa;
        public string pCd_empresa
        { 
            get { return cd_empresa.Text; }
            set { pcd_empresa = value; }
        }
        private string pcd_conta;
        public string pCd_conta
        { 
            get { return cd_conta_ctb.Text; }
            set { pcd_conta = value; }
        }
        public DateTime pDt_lancto
        { get { return DateTime.Parse(dt_lancto.Text); } }
        public decimal pVl_lancto
        { get { return vl_lancto.Value; } }
        public string pD_C
        { get { return deb_cred.SelectedValue.ToString(); } }
        public string pComp
        { get { return compHistorico.Text; } }

        public TFImplantarSaldo()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DEBITO", "D"));
            cbx.Add(new Utils.TDataCombo("CREDITO", "C"));
            deb_cred.DataSource = cbx;
            deb_cred.DisplayMember = "Display";
            deb_cred.ValueMember = "Value";
            compHistorico.CharacterCasing = CharacterCasing.Normal;
        }

        private void TFImplantarSaldo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (!string.IsNullOrEmpty(pcd_empresa))
            {
                cd_empresa.Text = pcd_empresa;
                cd_empresa_Leave(this, new EventArgs());
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            if (!string.IsNullOrEmpty(pcd_conta))
            {
                cd_conta_ctb.Text = pcd_conta;
                cd_conta_ctb_Leave(this, new EventArgs());
                cd_conta_ctb.Enabled = false;
                bb_conta_ctb.Enabled = false;
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_conta_ctb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_conta_ctb.Text = rConta.Cd_conta_ctbstr;
                ds_conta_ctb.Text = rConta.Ds_contactb.Trim();
                classificacao.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_conta_ctb_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_ctb|=|" + cd_conta_ctb.Text + ";" +
                            "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta_ctb, ds_conta_ctb, classificacao },
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

        private void TFImplantarSaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
