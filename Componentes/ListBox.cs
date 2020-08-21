using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class ListBox : System.Windows.Forms.ListBox
    {
        private string vNM_Campo;
        private string vNM_Alias;
        public string NM_Campo { get { if (vNM_Campo == null)return ""; else return vNM_Campo; } set { vNM_Campo = value; } }
        public string NM_Alias { get { if (vNM_Alias == null) return ""; else return vNM_Alias; } set { vNM_Alias = value; } }

    }
}
