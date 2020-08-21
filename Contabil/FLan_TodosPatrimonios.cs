using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Contabil;

namespace Contabil
{
    public partial class TFLan_TodosPatrimonios : Form
    {
        public TFLan_TodosPatrimonios()
        {
            InitializeComponent();
        }
                
        public DataTable DT_Patrimonios;

        private void FLan_TodosPatrimonios_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Patrimonio);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            g_Patrimonio.DataSource = DT_Patrimonios;

        }

        private void FLan_TodosPatrimonios_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLan_TodosPatrimonios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Patrimonio);
        }
    }
}
