using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFSociosEmpresa : Form
    {
        private CamadaDados.Diversos.TRegistro_SociosEmpresa rsocio;
        public CamadaDados.Diversos.TRegistro_SociosEmpresa rSocio
        {
            get
            {
                if (bsSocios.Current != null)
                    return bsSocios.Current as CamadaDados.Diversos.TRegistro_SociosEmpresa;
                else
                    return null;
            }
            set { rsocio = value; }
        }

        public TFSociosEmpresa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFSociosEmpresa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rsocio != null)
            {
                bsSocios.DataSource = new CamadaDados.Diversos.TList_SociosEmpresa() { rsocio };
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                ds_funcao.Focus();
            }
            else
            {
                bsSocios.AddNew();
                cd_clifor.Focus();
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFSociosEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
