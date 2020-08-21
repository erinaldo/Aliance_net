using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public partial class TFWebBrowser : Form
    {
        public string Url
        { get; set; }

        public TFWebBrowser()
        {
            InitializeComponent();
        }

        private void TFWebBrowser_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            wbNavegador.Url = new System.Uri(Url);
        }
    }
}
