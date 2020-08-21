using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class RadioButtonDefault : RadioButton
    {
        private string vValor;

        public string Valor { get { if (vValor == null) return "";else return vValor; } set { vValor = value; } }

        public RadioButtonDefault()
        {
            InitializeComponent();
        }

        public RadioButtonDefault(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
