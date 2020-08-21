using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCompromisso : Form
    {
        private CamadaDados.Diversos.TRegistro_LanCompromisso rcompromisso;
        public CamadaDados.Diversos.TRegistro_LanCompromisso rCompromisso 
        {
            get {
                if (bsComp.Current != null)
                    return bsComp.Current as CamadaDados.Diversos.TRegistro_LanCompromisso;
                else
                    return null;
                }
            set
            { rcompromisso = value; }
        }        
        
        public TFCompromisso()
        {
            rcompromisso = null;
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void afterCancela() 
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancela_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Usuario_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("login|Login|80;Nome_usuario|Nome Login|350;email_padrao|Email|200",
               new Componentes.EditDefault[] { login, ds_login, email_padrao }, new TCD_CadUsuario(), string.Empty);
        }

        private void TFCompromisso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcompromisso != null)
                bsComp.DataSource = new CamadaDados.Diversos.TList_LanCompromisso() { rcompromisso };
            else
                bsComp.AddNew();

            nm_compromisso.Focus();
            login.Text = Utils.Parametros.pubLogin;
            login_Leave(this, new EventArgs());
        }

        private void login_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("login|=|'" + login.Text + "'", new Componentes.EditDefault[] { login, ds_login }
                , new TCD_CadUsuario());
        }

        private void TFCompromisso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.afterCancela();
        }
    }
}
