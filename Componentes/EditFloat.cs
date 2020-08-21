using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class EditFloat : NumericUpDown
    {
        private string vNM_Param;
        private string vNM_Campo;
        private string vNM_Alias;
        private bool vST_Gravar;
        private bool vST_NotNULL;
        private bool vST_PrimaryKey;
        private bool vST_AutoINC;
        private bool vST_DisableAuto;
        private bool vST_LimparCampo;
        private string vOperador;
        private decimal vValueOld;

        public string NM_Alias { get { if (vNM_Alias == null)return "";else return vNM_Alias; } set { vNM_Alias = value; } }
        public string NM_Param { get { if (vNM_Param == null)return "";else return vNM_Param; } set { vNM_Param = value.ToUpper(); } }
        public string NM_Campo { get { if (vNM_Campo == null)return "";else return vNM_Campo; } set { set_vNM_Campo(value); } }
        public string Operador { get { if (vOperador == null)return "";else return vOperador; } set { vOperador = value; } }
        public bool ST_AutoInc { get { return vST_AutoINC; } set { set_vST_AutoInc(value); } }
        public bool ST_DisableAuto{get{return vST_DisableAuto;}set{vST_DisableAuto = value;}}
        public bool ST_Gravar{get{return vST_Gravar;}set{vST_Gravar = value;}}
        public bool ST_PrimaryKey { get { return vST_PrimaryKey; } set { set_vST_PrimaryKey(value); } }
        public bool ST_NotNull { get { return vST_NotNULL; } set { set_vST_NotNULL(value); } }
        public bool ST_LimparCampo{get{return vST_LimparCampo;}set{vST_LimparCampo = value;}}
        public decimal ValueOld { get { return vValueOld; } set { vValueOld = value; } }

        private void set_vST_PrimaryKey(bool value)
        {
            if (value)
                vST_NotNULL = true;
            vST_PrimaryKey = value;
        }

        private void set_vST_NotNULL(bool value)
        {
            if (!value)
            {
                if (vST_PrimaryKey)
                    vST_NotNULL = true;
                else
                    vST_NotNULL = false;
            }
            else
                vST_NotNULL = value;
        }

        private void set_vST_AutoInc(bool value)
        {
            if (value)
                Enabled = false;
            vST_AutoINC = value;
        }

        private void set_vNM_Campo(string value)
        {
            vNM_Campo = value;
            if (vNM_Campo != "")
            {
                if (vNM_Param == "")
                    vNM_Param = "@P_" + vNM_Campo.Trim().ToUpper();
            }
        }

        public EditFloat()
        {
            InitializeComponent();
            vST_LimparCampo = true;
            ThousandsSeparator = true;
            Increment = decimal.Zero;
        }

        public EditFloat(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            vST_LimparCampo = true;
            ThousandsSeparator = true;
            Increment = decimal.Zero;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            Select(0, Text.Length);
            if (vST_NotNULL)
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(137)))));
            else
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
            vValueOld = Value;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            BackColor = System.Drawing.Color.White;
            if (Text.Trim().Equals(string.Empty))
                Text = Minimum.ToString();
            if ((ST_PrimaryKey) && (Value != 0))
            {
                if(FindForm().GetType().GetField("vTP_Modo").GetValue(FindForm()).ToString().Trim().Equals("tm_Insert"))
                    if (verificaCamposChave())
                        FindForm().GetType().InvokeMember("afterAltera", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.ExactBinding | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Instance, null, FindForm(), null);
            }
        }

        private bool verificaCamposChave()
        {
            foreach (Control t in (Parent as Panel).Controls)
            {
                if (t is EditDefault)
                {
                    if (((t as EditDefault).ST_PrimaryKey) && ((t as EditDefault).Text.Trim().Equals("")))
                        return false;
                }
                else if (t is EditMask)
                {
                    (t as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (((t as EditMask).ST_PrimaryKey) && ((t as EditMask).Text.Trim().Equals("")))
                        return false;
                    (t as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                }
                else if (t is EditFloat)
                {
                    if (((t as EditFloat).ST_PrimaryKey) && ((t as EditFloat).Value == 0))
                        return false;
                }
            }
            return true;
        }

        private void EditFloat_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
                BackColor = System.Drawing.Color.White;
            else
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(210)))));
        }
    }
}
