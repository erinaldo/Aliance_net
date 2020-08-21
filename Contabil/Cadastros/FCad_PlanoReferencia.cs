using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Contabil.Cadastro;
using CamadaDados.Contabil.Cadastro;

namespace Contabil.Cadastros
{
    public partial class FCad_PlanoReferencia : Form
    {


        private CamadaDados.Contabil.Cadastro.TRegistro_PlanoReferencial cPlano = new TRegistro_PlanoReferencial();
        public CamadaDados.Contabil.Cadastro.TRegistro_PlanoReferencial rPlano
        {
            get
            {
                return bsPlanoReferencia.Current as CamadaDados.Contabil.Cadastro.TRegistro_PlanoReferencial;
            }
            set
            {
                cPlano = value;
            }
        }
        public FCad_PlanoReferencia()
        {
            InitializeComponent();
        }

        private void FCad_PlanoReferencia_Load(object sender, EventArgs e)
        {
            if (cPlano != null)
                bsPlanoReferencia.Add(cPlano);
            else
                bsPlanoReferencia.AddNew();


            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ANALITICA", "A"));
            cbx.Add(new Utils.TDataCombo("SINTETICA", "S"));
            cbTipoHora.DataSource = cbx;
            cbTipoHora.DisplayMember = "Display";
            cbTipoHora.ValueMember = "Value";


            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("CONTA ATIVO", "1"));
            cbx1.Add(new Utils.TDataCombo("CONTA PASSIVO", "2"));
            cbx1.Add(new Utils.TDataCombo("PATRIMONIO LIQUIDO", "3"));
            cbx1.Add(new Utils.TDataCombo("CONTA RESULTADO", "4"));
            cbx1.Add(new Utils.TDataCombo("CONTA COMPENSAÇÃO", "5"));
            cbx1.Add(new Utils.TDataCombo("OUTRAS", "9")); 
            comboBoxDefault1.DataSource = cbx1;
            comboBoxDefault1.DisplayMember = "Display";
            comboBoxDefault1.ValueMember = "Value";
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if(panelDados1.validarCampoObrigatorio())
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FCad_PlanoReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                BB_Gravar_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F6))
            {
                BB_Cancelar_Click(this, new EventArgs());
            }
        }
    }
}
