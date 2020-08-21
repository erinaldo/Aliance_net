using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class EditHora : EditMask
    {
        public DateTime Hora { get { return get_vHora(); } }

        private DateTime get_vHora()
        {
            try
            {
                return Convert.ToDateTime(this.Text);
            }
            catch
            {
                return new DateTime();
            }
        }

        public EditHora()
        {
            InitializeComponent();
            this.Mask = "00:00:00";
        }

        public EditHora(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Mask = "00:00:00";
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            MaskFormat msk = this.TextMaskFormat;
            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            try
            {
                if (this.Text.Trim() != "")
                {
                    this.TextMaskFormat = msk;
                    try
                    {
                        Convert.ToDateTime(this.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Hora Invalida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        this.SelectAll();
                    }
                }
            }
            finally
            {
                this.TextMaskFormat = msk;
            }
        }
    }
}
