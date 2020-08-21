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
    public partial class TFMsgTicket : Form
    {
        public string Id_ticket
        { get; set; }
        public string Ds_evolucao
        { get; set; }
        public bool St_atualiarTmpEvolucao
        { get; set; }
        public bool St_visualizarTicket
        { get; set; }

        public TFMsgTicket()
        {
            InitializeComponent();
        }

        private void lblTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            St_visualizarTicket = true;
            St_atualiarTmpEvolucao = true;
            this.Close();
        }

        private void tmpFechar_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFMsgTicket_Load(object sender, EventArgs e)
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

            lblTicket.Text = Id_ticket;
            lblEvolucao.Text = Ds_evolucao;
            tmpFechar.Interval = Utils.Parametros.pubTmpMsgTicket > decimal.Zero ? Convert.ToInt32(Utils.Parametros.pubTmpMsgTicket) : 10000;
            tmpFechar.Start();
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            St_atualiarTmpEvolucao = true;
            this.Close();
        }
    }
}
