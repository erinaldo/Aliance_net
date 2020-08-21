using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFCadConfLayout : Form
    {
        private TRegistro_CadConf_Layout rlayout;
        public TRegistro_CadConf_Layout rLayout
        {
            get
            {
                if (bsConfLayout.Current != null)
                    return bsConfLayout.Current as TRegistro_CadConf_Layout;
                else
                    return null;
            }
            set { rlayout = value; }
        }
        public TFCadConfLayout()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(Coord_Sup_X.Text) || 
                string.IsNullOrEmpty(Coord_Sup_Y.Text) ||
                string.IsNullOrEmpty(Coord_Inf_X.Text) ||
                string.IsNullOrEmpty(Coord_Inf_Y.Text))
            {
                MessageBox.Show("Obrigatório completar todas as cooordenadas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFCadConfLayout_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsConfLayout.AddNew();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadConfLayout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Coord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espaço
                char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }
    }
}
