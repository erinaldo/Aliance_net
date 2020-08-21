using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class FLayoutEtiqueta : Form
    {
        public FLayoutEtiqueta()
        {
            InitializeComponent();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            bsLayout.DataSource = CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.Busca(id_layout.Text, Layout.Text, null);
            bsLayout_PositionChanged(this, new EventArgs());
            bsLayout.ResetCurrentItem();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using(FCadLayoutEtiqueta cad = new FCadLayoutEtiqueta())
            {
                if(cad.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.GravarMenu(cad.rLayout, null);
                    MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BB_Buscar_Click(this, new EventArgs());
                } 
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if(bsLayout.Current != null)
                using (FCadLayoutEtiqueta cad = new FCadLayoutEtiqueta())
                {
                    cad.rLayout = (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta);
                    if (cad.ShowDialog() == DialogResult.OK)
                    {
                        CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.GravarMenu(cad.rLayout, null);
                        MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BB_Buscar_Click(this, new EventArgs());
                    }
                }

        }

        private void FLayoutEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
            {
                BB_Novo_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F3 ))
            {
                BB_Alterar_Click(this, new EventArgs());
            }
            else
            if (e.KeyCode.Equals(Keys.F7))
            {
                BB_Buscar_Click(this, new EventArgs());
            }
        }

        private void barraMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bsLayout_PositionChanged(object sender, EventArgs e)
        {
            if(bsLayout.Current != null)
            {
                (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta).lCampos =
                    CamadaNegocio.Diversos.TCN_CamposLayout.Busca(string.Empty,
                        (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta).Id_layoutstr,
                        string.Empty, null);
                bsLayout.ResetCurrentItem();
            }
        }

        private void FLayoutEtiqueta_Load(object sender, EventArgs e)
        {

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
