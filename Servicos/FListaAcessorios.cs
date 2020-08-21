using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFListaAcessorios : Form
    {
        private CamadaDados.Servicos.TList_Acessorios lacessorios;
        public CamadaDados.Servicos.TList_Acessorios lAcessorios
        {
            get { return bsAcessorios.List as CamadaDados.Servicos.TList_Acessorios; }
            set { lacessorios = value; }
        }

        public TFListaAcessorios()
        {
            InitializeComponent();
        }

        private void gAcessorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsAcessorios.Current as CamadaDados.Servicos.TRegistro_Acessorios).St_devolvidobool =
                    !(bsAcessorios.Current as CamadaDados.Servicos.TRegistro_Acessorios).St_devolvidobool;
                bsAcessorios.ResetCurrentItem();
            }
        }

        private void TFListaAcessorios_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsAcessorios.DataSource = lacessorios;
        }
    }
}
