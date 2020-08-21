using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class RadioGroup : GroupBox
    {
        private string vNM_Campo;
        private string vNM_Alias;
        private string vNM_Param;
        private bool vST_Gravar;
        private bool vST_NotNUL;
        private string vNM_Valor;

        public string NM_Campo { get { if (vNM_Campo == null)return "";else return vNM_Campo; } set { set_vNM_Campo(value); } }
        public string NM_Alias { get { if (vNM_Alias == null)return "";else return vNM_Alias; } set { vNM_Alias = value; } }
        public string NM_Param { get { if (vNM_Param == null)return "";else return vNM_Param; } set { vNM_Param = value.ToUpper(); } }
        public bool ST_Gravar { get { return vST_Gravar; } set { vST_Gravar = value; } }
        public bool ST_NotNull { get { return vST_NotNUL; } set { vST_NotNUL = value; } }
        public string NM_Valor { get { return get_vNM_Valor(); } set { set_vNM_Valor(value); } }

        private void set_vNM_Campo(string value)
        {
            this.vNM_Campo = value;
            if ((this.vNM_Param == "") && (value != ""))
                this.vNM_Param = "@P_" + this.vNM_Campo.Trim().ToUpper();
        }

        private string get_vNM_Valor()
        {
            string retorno = "";
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if ((this.Controls[i] is Panel) || (this.Controls[i] is PanelDados))
                {
                    for (int j = 0; j < this.Controls[i].Controls.Count; j++)
                        if (this.Controls[i].Controls[j] is RadioButtonDefault)
                            if ((this.Controls[i].Controls[j] as RadioButtonDefault).Checked)
                                retorno = (this.Controls[i].Controls[j] as RadioButtonDefault).Valor;
                }
                else if (this.Controls[i] is RadioButtonDefault)
                    if ((this.Controls[i] as RadioButtonDefault).Checked)
                        retorno = (this.Controls[i] as RadioButtonDefault).Valor;
            }
            return retorno;
        }

        private void set_vNM_Valor(string str)
        {
            this.vNM_Valor = str;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if ((this.Controls[i] is Panel) || (this.Controls[i] is PanelDados))
                {
                    for(int j = 0; j < this.Controls[i].Controls.Count; j++)
                        if (this.Controls[i].Controls[j] is RadioButtonDefault)
                        {
                            (this.Controls[i].Controls[j] as RadioButtonDefault).Checked = ((this.Controls[i].Controls[j] as RadioButtonDefault).Valor.Equals(str));
                            if ((this.Controls[i].Controls[j] as RadioButtonDefault).Valor.Equals(str))
                                return;
                        }   
                }
                else if (this.Controls[i] is RadioButtonDefault)
                {
                    (this.Controls[i] as RadioButtonDefault).Checked = ((this.Controls[i] as RadioButtonDefault).Valor == str);
                    if ((this.Controls[i] as RadioButtonDefault).Valor == str)
                        return;
                }
            }
        }

        public RadioGroup()
        {
            InitializeComponent();
        }

        public RadioGroup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
