using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;





namespace Empreendimento
{
    public partial class FCompraEmpreendimentoDireto : Form
    {
        private TList_FichaTec cListFicha { get; set; } = new TList_FichaTec();

        public TList_FichaTec rListFicha
        {
            get
            {
                return bsFichaDir.List as TList_FichaTec;
            }
            set
            {
                cListFicha = value;
            }
        }





        public FCompraEmpreendimentoDireto()
        {
            InitializeComponent();
        }

        private void FCompraEmpreendimentoDireto_Load(object sender, EventArgs e)
        {
            if (cListFicha.Count > 0)
                cListFicha.ForEach(p =>
                {
                    bsFichaDir.Add(p);
                });

        }
    }
}
