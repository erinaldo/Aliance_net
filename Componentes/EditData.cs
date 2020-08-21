using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class EditData : EditMask
    {
        private string vOperador;
        public string Operador { get { if (vOperador == null)return ""; else return vOperador; } set { vOperador = value; } }
        public DateTime Data { get { return get_vData(); } }
        public string DataString_YMD 
        {
            get 
            { 
                DateTime vdata = get_vData();

                return System.String.Format("{0:D4}", vdata.Year) +
                       System.String.Format("{0:D2}", vdata.Month) +
                       System.String.Format("{0:D2}", vdata.Day);
            }
        } 

        private DateTime get_vData()
        {
            MaskFormat msk = this.TextMaskFormat;
            try
            {
                this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return Convert.ToDateTime(this.Text);
            }
            catch
            {
                return new DateTime();
            }
            finally
            {
                this.TextMaskFormat = msk;
            }
        }
                
        public EditData()
        {
            InitializeComponent();
            this.Mask = "00/00/0000";
        }

        public EditData(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Mask = "00/00/0000";
        }

        protected override void OnLeave(EventArgs e)
        {
            MaskFormat msk = this.TextMaskFormat;
            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            try
            {
                if (this.Text.Trim() != "")
                {
                    this.TextMaskFormat = msk;
                    try
                    {
                        this.TextMaskFormat = MaskFormat.IncludeLiterals;
                        Convert.ToDateTime(this.Text);
                        base.OnLeave(e);
                    }
                    catch
                    {
                        MessageBox.Show("Data Invalida!");
                        this.Focus();
                        this.Clear();
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
