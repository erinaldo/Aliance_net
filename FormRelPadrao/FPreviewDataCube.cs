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
    public partial class TFPreviewDataCube : Form
    {
        public BindingSource BS_DataCube
        { get; set; }
        public string NM_Layout
        { get; set; }

        public TFPreviewDataCube()
        {
            InitializeComponent();
        }

        private void FPreviewDataCube_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }
}
