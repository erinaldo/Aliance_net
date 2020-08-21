using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Contabil
{
    public partial class TFLanctoAvulso : Form
    {
        private CamadaDados.Contabil.TRegistro_LanctoAvulso rlancto;
        public CamadaDados.Contabil.TRegistro_LanctoAvulso rLancto
        {
            get
            {
                if (bsLanctoAvulso.Current != null)
                    return bsLanctoAvulso.Current as CamadaDados.Contabil.TRegistro_LanctoAvulso;
                else
                    return null;
            }
            set { rlancto = value; }
        }
        public string D_C
        { get; set; }
        public bool St_alterar
        { get; set; }

        public TFLanctoAvulso()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DEBITO", "D"));
            cbx.Add(new Utils.TDataCombo("CREDITO", "C"));
            deb_cred.DataSource = cbx;
            deb_cred.DisplayMember = "Display";
            deb_cred.ValueMember = "Value";

            this.rlancto = null;
            this.St_alterar = false;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanctoAvulso_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            
            if (this.St_alterar)
            {
                bsLanctoAvulso.Add(this.rlancto);
                cd_conta_ctb.Enabled = false;
                bb_conta_ctb.Enabled = false;
                vl_lancto.Focus();
            }
            else
            {
                bsLanctoAvulso.AddNew();
                cd_conta_ctb.Focus();
            }
            if (!string.IsNullOrEmpty(D_C))
                deb_cred.SelectedValue = D_C;
            deb_cred.Enabled = string.IsNullOrEmpty(D_C);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanctoAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
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
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta_ctb, ds_conta_ctb, classificacao }, 
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }
    }
}
