using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormRelPadrao
{
    public partial class TFPreviewChart : Form
    {
        public TFPreviewChart()
        {
            InitializeComponent();
        }

        private void FPreviewChart_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }
}
