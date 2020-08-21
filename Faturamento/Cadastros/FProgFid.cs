using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFProgFid : Form
    {
        private CamadaDados.Faturamento.Fidelizacao.TRegistro_ProgFidelidade rprog;
        public CamadaDados.Faturamento.Fidelizacao.TRegistro_ProgFidelidade rProg
        {
            get
            {
                if (bsProgFid.Current != null)
                    return bsProgFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ProgFidelidade;
                else return null;
            }
            set { rprog = value; }
        }

        public TFProgFid()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("R$", "V"));
            cbx.Add(new Utils.TDataCombo("%", "P"));
            tp_vl_pc.DataSource = cbx;
            tp_vl_pc.DisplayMember = "Display";
            tp_vl_pc.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFProgFid_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rprog != null)
            {
                bsProgFid.DataSource = new CamadaDados.Faturamento.Fidelizacao.TList_ProgFidelidade() { rprog };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else bsProgFid.AddNew();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProgFid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
