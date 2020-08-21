using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Componentes
{
    public partial class EditDefault : TextBox
    {
        private string vTextOld;
        private string vNM_Param;
        private string vNM_Campo;
        private string vNM_Alias;
        private bool vST_Gravar;
        private bool vST_NotNULL;
        private bool vST_PrimaryKey;
        private bool vST_AutoINC;
        private bool vST_DisableAuto;
        private bool vST_LimparCampo;
        private bool vST_Int;
        private bool vST_Float;
        private int vQTD_Zero;
        private string vNM_CampoBusca;

        public string NM_Param { get { if (vNM_Param == null)return ""; else return vNM_Param; } set { vNM_Param = value.ToUpper(); } }
        public string NM_Campo { get { if (vNM_Campo == null)return ""; else return vNM_Campo; } set { set_vNM_Campo(value); } }
        public string NM_Alias { get { if (vNM_Alias == null) return ""; else return vNM_Alias; } set { vNM_Alias = value; } }
        public string NM_CampoBusca { get { if (vNM_CampoBusca == null)return ""; else return vNM_CampoBusca; } set { vNM_CampoBusca = value; } }
        public bool ST_AutoInc{get{return vST_AutoINC;} set{vST_AutoINC = value;}}
        public bool ST_DisableAuto{get{return vST_DisableAuto;} set{vST_DisableAuto = value;}}
        public bool ST_LimpaCampo{get{return vST_LimparCampo;} set{vST_LimparCampo = value;}}
        public bool ST_Gravar{get{return vST_Gravar;} set{vST_Gravar = value;}}
        public bool ST_PrimaryKey{get{return vST_PrimaryKey;} set{set_vST_PrimaryKey(value);}}
        public bool ST_NotNull { get { return vST_NotNULL; } set { set_vST_NotNULL(value); } }
        public int QTD_Zero{get{return vQTD_Zero;} set{vQTD_Zero = value;}}
        public bool ST_Int { get { return vST_Int; } set { vST_Int = value; } }
        public bool ST_Float { get { return vST_Float; } set { vST_Float = value; } }
        public string TextOld { get { return vTextOld; } set { vTextOld = value; } }

        private void set_vST_PrimaryKey(bool value)
        {
            if(value)
                vST_NotNULL = value;
            vST_PrimaryKey = value;
        }

        private void set_vST_NotNULL(bool value)
        {
            if (!value)
            {
                if (vST_PrimaryKey)
                    vST_NotNULL = true;
                else
                    vST_NotNULL = value;
            }
            else
                vST_NotNULL = value;
        }

        private void set_vNM_Campo(string value)
        {
            vNM_Campo = value;
            if (vNM_Campo != string.Empty)
            {
                if(vNM_CampoBusca == string.Empty)
                    vNM_CampoBusca = value;
                if ((vNM_Param == string.Empty)||(vNM_Param == null))
                    vNM_Param = "@P_" + vNM_Campo.ToUpper();
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

        public EditDefault()
        {
            InitializeComponent();
            vST_LimparCampo = true;
            CharacterCasing = CharacterCasing.Upper;
        }

        public EditDefault(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            SelectAll();
            if(vST_NotNULL)
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(137)))));
            else
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
            vTextOld = Text;
        }

        protected override void OnLeave(EventArgs e)
        {
            BackColor = System.Drawing.Color.White;
            string str = Text;
            if((! vST_AutoINC))
            {
                if ((vQTD_Zero > 1) && (str != ""))
                    try
                    {
                        Text = string.Format("{0:D" + vQTD_Zero.ToString().Trim() + "}", Convert.ToInt32(str));
                    }
                    catch { }
            }
            if ((ST_PrimaryKey) && (Text.Trim() != ""))
            {
                if(FindForm().GetType().GetField("vTP_Modo").GetValue(FindForm()).ToString().Trim().Equals("tm_Insert"))
                    if (verificaCamposChave())
                        FindForm().GetType().InvokeMember("afterAltera", 
                                                                System.Reflection.BindingFlags.InvokeMethod | 
                                                                System.Reflection.BindingFlags.Public | 
                                                                System.Reflection.BindingFlags.DeclaredOnly | 
                                                                System.Reflection.BindingFlags.Default | 
                                                                System.Reflection.BindingFlags.ExactBinding | 
                                                                System.Reflection.BindingFlags.FlattenHierarchy | 
                                                                System.Reflection.BindingFlags.Instance, 
                                                                null, 
                                                                FindForm(), 
                                                                null);
            }
            base.OnLeave(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if ((vST_NotNULL) && (string.IsNullOrEmpty(Text) || ((ST_Int || ST_Float) && Text.Trim().Equals("0"))) && (Visible)&&(Enabled))
                erro.SetError(this, "Campo Obrigatório!");
            else
                erro.SetError(this, "");
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (vST_Int)
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                    e.Handled = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            OnValidated(e);
        }

        private void EditDefault_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                OnValidated(e);
                BackColor = System.Drawing.Color.White;
            }
            else
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            }

        }
    }
}
