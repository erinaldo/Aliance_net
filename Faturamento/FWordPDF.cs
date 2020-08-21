using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFWordPDF : Form
    {
        public bool St_pdf
        { get; set; }
        public TFWordPDF()
        {
            InitializeComponent();
        }

        private void bb_word_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            St_pdf = false;
        }

        private void bb_pdf_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            St_pdf = true;
        }

        private void TFWordPDF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                bb_word_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F3))
                bb_pdf_Click(this, new EventArgs());
        }
    }
}
