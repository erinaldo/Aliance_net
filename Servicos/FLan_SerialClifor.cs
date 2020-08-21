using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFLan_SerialClifor : Form
    {
        public TFLan_SerialClifor()
        {
            InitializeComponent();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (Observacao.Text.Trim() != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por Favor! Preencha o Campo Observação", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FLan_SerialClifor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void TFLan_SerialClifor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
        }

    }
}
