using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class EditMask : System.Windows.Forms.MaskedTextBox
    {
        private string vNM_Param;
        private string vNM_Campo;
        private string vNM_Alias;
        private bool vST_Gravar;
        private bool vST_NotNULL;
        private bool vST_PrimaryKey;
        private bool vST_LimparCampo;
        private string vNM_CampoBusca;

        public string NM_Param { get { if (vNM_Param == null)return ""; else return vNM_Param; } set { vNM_Param = value.ToUpper(); } }
        public string NM_Campo { get { if (vNM_Campo == null)return ""; else return vNM_Campo; } set { set_vNM_Campo(value); } }
        public string NM_Alias { get { if (vNM_Alias == null) return ""; else return vNM_Alias; } set { vNM_Alias = value; } }
        public string NM_CampoBusca { get { if (vNM_CampoBusca == null)return ""; else return vNM_CampoBusca; } set { vNM_CampoBusca = value; } }
        public bool ST_LimpaCampo { get { return vST_LimparCampo; } set { vST_LimparCampo = value; } }
        public bool ST_Gravar { get { return vST_Gravar; } set { vST_Gravar = value; } }
        public bool ST_NotNull { get { return vST_NotNULL; } set { set_vST_NotNULL(value); } }
        public bool ST_PrimaryKey { get { return vST_PrimaryKey; } set { set_vST_PrimaryKey(value); } }

        private void set_vNM_Campo(string value)
        {
            this.vNM_Campo = value;
            if (this.vNM_Campo != "")
            {
                if (vNM_CampoBusca == "")
                    this.vNM_CampoBusca = value;
                if ((this.vNM_Param == "") || (this.vNM_Param == null))
                    this.vNM_Param = "@P_" + this.vNM_Campo.ToUpper();
            }
        }

        private void set_vST_PrimaryKey(bool value)
        {
            if (value)
                this.vST_NotNULL = value;
            this.vST_PrimaryKey = value;
        }

        private void set_vST_NotNULL(bool value)
        {
            if (!value)
            {
                if (this.vST_PrimaryKey)
                    this.vST_NotNULL = true;
                else
                    this.vST_NotNULL = value;
            }
            else
                this.vST_NotNULL = value;
        }

        private bool verificaCamposChave()
        {
            foreach (Control t in (this.Parent as Panel).Controls)
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
            }
            return true;
        }

        public EditMask()
        {
            InitializeComponent();
            this.vST_LimparCampo = true;
        }

        public EditMask(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
                
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.SelectAll();
            if (this.vST_NotNULL)
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(137)))));
            else
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = System.Drawing.Color.White;
            if ((this.ST_PrimaryKey) && (this.Text.Trim() != ""))
            {
                if (this.FindForm().GetType().GetField("vTP_Modo").GetValue(this.FindForm()).ToString().Trim().Equals("tm_Insert"))
                    if (verificaCamposChave())
                    {
                        Type t = this.FindForm().GetType();
                        System.Reflection.MethodInfo m = t.GetMethod("afterAltera");
                        m.Invoke(this.FindForm(), null);
                    }
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if ((this.vST_NotNULL) && (this.Text == "") && (this.Visible))
                this.erro.SetError(this, "Campo Obrigatório!");
            else
                this.erro.SetError(this, "");
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.OnValidated(e);
        }
                
        private void EditMask_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
                this.BackColor = System.Drawing.Color.White;
            else
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(210)))));
        }
    }
}
