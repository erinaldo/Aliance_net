using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque
{
    public partial class TFBuscarMarkup : Form
    {
        public string pCd_empresa
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TRegistro_Markup rMarkup
        {
            get
            {
                if (bsMarkup.Current != null)
                    return bsMarkup.Current as CamadaDados.Estoque.Cadastros.TRegistro_Markup;
                else return null;
            }
        }

        public TFBuscarMarkup()
        {
            InitializeComponent();
        }

        private void TFBuscarMarkup_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar markup
            bsMarkup.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_Markup.Buscar(pCd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_confirma_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFBuscarMarkup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
