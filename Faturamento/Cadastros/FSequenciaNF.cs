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
    public partial class TFSequenciaNF : Form
    {
        private CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF rseq;
        public CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF rSeq
        {
            get
            {
                if (bsSequencia.Current != null)
                    return bsSequencia.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF;
                else return null;
            }
            set { rseq = value; }
        }
        public TFSequenciaNF()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFSequenciaNF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rseq != null)
            {
                bsSequencia.DataSource = new CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF() { rseq };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else bsSequencia.AddNew();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFSequenciaNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
