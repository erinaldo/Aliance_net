using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class CheckBoxDefault : CheckBox
    {
        private string vNM_Campo;
        private string vNM_Alias;
        private string vNM_Param;
        private bool vST_Gravar;
        private bool vST_NotNULL;
        private bool vST_LimparCampo;
        private string vValorTrue;
        private string vValorFalse;

        public string NM_Param { get { if (vNM_Param == null) return "";else return vNM_Param; } set { vNM_Param = value.ToUpper(); } }
        public string NM_Campo { get { if (vNM_Campo == null) return "";else return vNM_Campo; } set { set_vNM_Campo(value); } }
        public string NM_Alias { get { if (vNM_Alias == null) return "";else return vNM_Alias; } set { vNM_Alias = value; } }
        public string Vl_True { get { if (vValorTrue == null) return "";else return vValorTrue; } set { vValorTrue = value; } }
        public string Vl_False { get { if (vValorFalse == null)return "";else return vValorFalse; } set { vValorFalse = value; } }
        public bool ST_Gravar { get { return vST_Gravar; } set { vST_Gravar = value; } }
        public bool ST_NotNull { get { return vST_NotNULL; } set { vST_NotNULL = value; } }
        public bool ST_LimparCampo { get { return vST_LimparCampo; } set { vST_LimparCampo = value; } }

        private void set_vNM_Campo(string value)
        {
            this.vNM_Campo = value;
            if(this.vNM_Campo != "")
                if(this.vNM_Param == "")
                    this.vNM_Param = "@P_"+this.vNM_Campo.Trim().ToUpper();
        }

        public CheckBoxDefault()
        {
            InitializeComponent();
            this.vST_LimparCampo = true;
        }

        public CheckBoxDefault(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.vST_LimparCampo = true;
        }
    }
}
