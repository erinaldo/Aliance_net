using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFNumeroOS : Form
    {
        public string Id_os
        { get { return id_os.Text; } }

        public TFNumeroOS()
        {
            InitializeComponent();
        }

        private void TFNumeroOS_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }
}
