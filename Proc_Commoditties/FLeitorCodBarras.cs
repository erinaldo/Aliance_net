using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFLeitorCodBarras : Form
    {
        public string Titulo { get; set; } = string.Empty;
        public string TempoEspera { get; set; } = string.Empty;
        public string Leitura { get; set; } = string.Empty;
        public bool ComTempoEsp { get; set; } = true;

        public TFLeitorCodBarras()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void LeitorCodBarras_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Titulo))
                lblTitulo.Text = Titulo;
            TxtLeitura.Focus();
            TxtLeitura.Select();
        }

        private void TxtLeitura_TextChanged(object sender, EventArgs e)
        {
            if (TxtLeitura.Text.Length.Equals(10))
            {
                Leitura = TxtLeitura.Text;
                DialogResult = DialogResult.OK;
            }
            else if (TxtLeitura.Text.Length > 10)
            {
                TxtLeitura.Text = "";
                TxtLeitura.Focus();
                TxtLeitura.Select();
            }
        }
    }
}
