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
    public partial class FCadCampoLayout : Form
    {
        public FCadCampoLayout()
        {
            InitializeComponent();
        }

        private CamadaDados.Diversos.TRegistro_CamposEtiqueta cCampos = new CamadaDados.Diversos.TRegistro_CamposEtiqueta();
        public CamadaDados.Diversos.TRegistro_CamposEtiqueta rCampo
        {
            get
            {
                return bsCampo.Current as CamadaDados.Diversos.TRegistro_CamposEtiqueta;
            }
            set
            {
                cCampos = value;
            }
        }

        private void FCadCampoLayout_Load(object sender, EventArgs e)
        {

            System.Collections.ArrayList cb = new System.Collections.ArrayList();
            cb.Add(new Utils.TDataCombo("CAMPO", "0"));
            cb.Add(new Utils.TDataCombo("CODIGO BARRA", "1"));
            cbTipoHora.DataSource = cb;
            cbTipoHora.DisplayMember = "Display";
            cbTipoHora.ValueMember = "Value";


            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("DESCRICAO", "DESCRICAO"));
            cbx1.Add(new Utils.TDataCombo("DESCRICAO2", "DESCRICAO2"));
            cbx1.Add(new Utils.TDataCombo("COD_BAR", "COD_BAR"));
            cbx1.Add(new Utils.TDataCombo("VALOR", "VALOR"));
            comboBoxDefault2.DataSource = cbx1;
            comboBoxDefault2.DisplayMember = "Display";
            comboBoxDefault2.ValueMember = "Value";

            if (cCampos != null)
                bsCampo.Add(cCampos);
            else
                bsCampo.AddNew();

        }

        private void FCadCampoLayout_KeyDown(object sender, KeyEventArgs e)
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
    }
}
