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
    public partial class FCadLayoutEtiqueta : Form
    {
        CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta cLayout = new CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta();
        public CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta rLayout
        {
            get
            {
                return bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta;
            }
            set
            {
                cLayout = value;
            }
        }


        public FCadLayoutEtiqueta()
        {
            InitializeComponent();
        }

        private void panelDados3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FCadLayoutEtiqueta_Load(object sender, EventArgs e)
        {
            if (cLayout != null)
                bsLayout.Add(cLayout);
            else
                bsLayout.AddNew();

        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            using (FCadCampoLayout cad = new FCadCampoLayout())
            {
                if(cad.ShowDialog() == DialogResult.OK)
                {
                    (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta).lCampos.Add(cad.rCampo);
                    bsLayout.ResetCurrentItem();

                }

            }
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            if(bsCampo.Current != null)
            using (FCadCampoLayout cad = new FCadCampoLayout())
            {
                cad.rCampo = (bsCampo.Current as CamadaDados.Diversos.TRegistro_CamposEtiqueta);
                if (cad.ShowDialog() == DialogResult.OK)
                {
                    (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta).lCampos.Add(cad.rCampo);


                }

            }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (bsCampo.Current != null)
                if( MessageBox.Show("Deseja remover campo?","mensagem",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    bsCampo.RemoveCurrent();
                    (bsLayout.Current as CamadaDados.Diversos.TRegistro_CadLayoutEtiqueta).lCamposDel.Add((bsCampo.Current as CamadaDados.Diversos.TRegistro_CamposEtiqueta));
                }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void FCadLayoutEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
            {
                if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
