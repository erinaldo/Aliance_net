using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class FObterHoras : Form
    {
        public decimal quantidadeEmDecimal { get; set; } = decimal.Zero;

        public FObterHoras()
        {
            InitializeComponent();
        }

        private bool validarTempo()
        {
            try
            {
                object obj = Convert.ToDateTime(EDT_Tempo.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Erro na conversão do tempo. Informe HH:MM:SS.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void afterGravar()
        {
            if (validarTempo())
            {
                quantidadeEmDecimal = (decimal)Convert.ToDateTime(EDT_Tempo.Text.Trim()).TimeOfDay.TotalMinutes / 60;
                DialogResult = DialogResult.OK;
            }
            else
            {
                panelDados1.LimparRegistro();
                EDT_Tempo.Select();
            }
        }

        private void FObterHoras_Load(object sender, EventArgs e)
        {
            EDT_Tempo.Select();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGravar();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_KeyDown(object sender, KeyEventArgs e)
        {
            afterGravar();
        }

        private void BB_Cancelar_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FObterHoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                afterGravar();
            }else if (e.KeyCode.Equals(Keys.Escape))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void EDT_Tempo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                afterGravar();
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
