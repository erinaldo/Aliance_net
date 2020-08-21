using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFMotoristaConvenio : Form
    {
        public CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista rMot
        {
            get
            {
                if (bsMotorista.Current != null)
                    return bsMotorista.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista;
                else
                    return null;
            }
        }

        public TFMotoristaConvenio()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (cpf_motorista.Focused)
                {
                    if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
                        if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                            this.Valida_CPF();
                    if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                    {
                        MessageBox.Show("CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cpf_motorista.Focus();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Valida_CPF()
        {
            if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
            {
                Utils.CPF_Valido.nr_CPF = cpf_motorista.Text;
                if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cpf_motorista.Clear();
                    cpf_motorista.Focus();
                }
            }
        }

        private void TFMotoristaConvenio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsMotorista.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFMotoristaConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cpf_motorista_TextChanged(object sender, EventArgs e)
        {
            if (cpf_motorista.Text.Trim().Length.Equals(3) ||
                cpf_motorista.Text.Trim().Length.Equals(7))
            {
                cpf_motorista.Text = cpf_motorista.Text + ".";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
            if (cpf_motorista.Text.Trim().Length.Equals(11))
            {
                cpf_motorista.Text = cpf_motorista.Text + "-";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
        }

        private void cpf_motorista_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
                if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                    this.Valida_CPF();
        }
    }
}
