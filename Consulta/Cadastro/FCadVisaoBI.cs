using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consulta.Cadastro
{
    public partial class FCadVisaoBI : Form
    {

        private CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI cVisao;
        public CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI rVisao
        {
            get
            {
                if (bsVisaoBI.Current != null)
                    return bsVisaoBI.Current as CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI;
                else return null;
            }
            set { cVisao = value; }
        }




        public FCadVisaoBI()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("BI VENDAS UF", "TFBI"));
            cbx.Add(new Utils.TDataCombo("BI ORDEM SERVICO", "TFBIOS"));
            cbx.Add(new Utils.TDataCombo("BI VENDAS DIA", "TFBIDia"));
            cbx.Add(new Utils.TDataCombo("BI CENTRO RESULTADO", "TFBICentroResultado"));
            cbx.Add(new Utils.TDataCombo("BI - Centro Resultado Viagem", "TFBICentroResultViagem"));
            comboclasse.DataSource = cbx;
            comboclasse.DisplayMember = "Display";
            comboclasse.ValueMember = "Value";
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            (bsVisaoBI.Current as CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI).Tipo_classe = comboclasse.Text;
            if (panelDados1.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void FCadVisaoBI_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (cVisao != null)
            {
                bsVisaoBI.DataSource = new CamadaDados.Consulta.Cadastro.TList_VisaoBI() { cVisao };
            }
            else bsVisaoBI.AddNew();
        }
    }
}
