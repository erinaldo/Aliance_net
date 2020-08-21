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
    public partial class TFCodBarra : Form
    {
        public string pCd_codbarra
        { get { return cd_codbarra.Text; } }

        public TFCodBarra()
        {
            InitializeComponent();
        }

        private void TFCodBarra_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void cd_codbarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.DialogResult = DialogResult.OK;
        }
    }
}
