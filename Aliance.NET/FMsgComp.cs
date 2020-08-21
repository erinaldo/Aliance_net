using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aliance.NET
{
    public partial class TFMsgComp : Form
    {
        public string Id_compromisso
        { get; set; }
        public string NM_Compromisso
        { get; set; }
        public bool St_visualizarComp
        { get; set; }
        public string DT_Comp
        { get; set; }

        public TFMsgComp()
        {
            InitializeComponent();
        }

        private void TFMsgComp_Load(object sender, EventArgs e)
        {
            //System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
            //p.StartFigure();
            //p.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            //p.AddLine(40, 0, this.Width - 40, 0);
            //p.AddArc(new Rectangle(this.Width - 40, 0, 40, 40), -90, 90);
            //p.AddLine(this.Width, 40, this.Width, this.Height - 40);
            //p.AddArc(new Rectangle(this.Width - 40, this.Height - 40, 40, 40), 0, 90);
            //p.AddLine(this.Width - 40, this.Height, 40, this.Height);
            //p.AddArc(new Rectangle(0, this.Height - 40, 40, 40), 90, 90);
            //p.CloseFigure();
            //this.Region = new Region(p);

            lblComp.Text = NM_Compromisso;
            lbl_DTComp.Text = DT_Comp;
            tmpFechar.Interval = Utils.Parametros.pubTmpMsgTicket > decimal.Zero ? Convert.ToInt32(Utils.Parametros.pubTmpMsgTicket) : 10000;
            tmpFechar.Start();
        }

        private void lblComp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            St_visualizarComp = true;
            this.Close();
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
