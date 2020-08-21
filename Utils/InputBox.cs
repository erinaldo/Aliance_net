using System;
using System.Windows.Forms;

namespace Utils
{
    public class InputBox : Form
    {
        private Button cmdOK;
        private Button cmdCancel;
        public String txtInput;
        private MaskedTextBox txtImputMask;
        private Label lblCaracteres;
        private System.ComponentModel.Container components = null;

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string mask, string text)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(mask))
            {
                txtImputMask.Mask = mask;
                lblCaracteres.Visible = false;
            }
            if (!string.IsNullOrEmpty(text))
                Text = text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtImputMask = new System.Windows.Forms.MaskedTextBox();
            this.lblCaracteres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.Location = new System.Drawing.Point(204, 42);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 26);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(281, 42);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 26);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtImputMask
            // 
            this.txtImputMask.Location = new System.Drawing.Point(16, 16);
            this.txtImputMask.Name = "txtImputMask";
            this.txtImputMask.Size = new System.Drawing.Size(529, 20);
            this.txtImputMask.TabIndex = 0;
            this.txtImputMask.TextChanged += new System.EventHandler(this.txtImputMask_TextChanged);
            // 
            // lblCaracteres
            // 
            this.lblCaracteres.Location = new System.Drawing.Point(377, 39);
            this.lblCaracteres.Name = "lblCaracteres";
            this.lblCaracteres.Size = new System.Drawing.Size(168, 16);
            this.lblCaracteres.TabIndex = 3;
            this.lblCaracteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputBox
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(557, 69);
            this.ControlBox = false;
            this.Controls.Add(this.lblCaracteres);
            this.Controls.Add(this.txtImputMask);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtInput_KeyDown(object sender,
                                        System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdOK.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                cmdCancel.PerformClick();
        }

        public string Show(string previewInput)
        {
            this.txtImputMask.Text = previewInput;
            this.txtImputMask.Focus();
            base.ShowDialog();
            return this.txtImputMask.Text;
        }

        public new string Show()
        {
            if (string.IsNullOrEmpty(txtInput))
                this.txtImputMask.Text = string.Empty;
            else
                this.txtImputMask.Text = txtInput;

            this.txtImputMask.Focus();
            base.ShowDialog();
            return txtImputMask.Text;
        }

        public new string ShowDialog()
        {
            return this.Show();
        }

        public new string Show(IWin32Window owner)
        {
            this.txtImputMask.Text = string.Empty;
            this.txtImputMask.Focus();
            base.ShowDialog(owner);
            return this.txtImputMask.Text;
        }

        public new string ShowDialog(IWin32Window owner)
        {
            return this.Show(owner);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            txtImputMask.Clear();
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImputMask_TextChanged(object sender, EventArgs e)
        {
            if (lblCaracteres.Visible)
                lblCaracteres.Text = "Caracteres: " + txtImputMask.Text.Trim().Length.ToString();
        }
    }
}
