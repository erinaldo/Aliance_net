using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;

namespace Financeiro
{
    public partial class TFAnaliseCredito : Form
    {
        private TRegistro_CadClifor rclifor;
        public TRegistro_CadClifor rClifor
        {
            get
            {
                if (bsClifor.Current != null)
                    return bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor;
                else
                    return null;
            }
            set { rclifor = value; }
        }
        public TFAnaliseCredito()
        {
            InitializeComponent();
        }

        private void VisualizarCampos()
        {
            LB_DS_RamoAtividade.Visible = rclifor.Tp_pessoa.ToUpper().Equals("J");
            ID_RamoAtividade.Visible = rclifor.Tp_pessoa.ToUpper().Equals("J");
            DS_RamoAtividade.Visible = rclifor.Tp_pessoa.ToUpper().Equals("J");
            lbLocaltrab.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
            nm_localtrabalho.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
            lbcargo.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
            ds_cargo.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
            lbvlrenda.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
            vl_renda.Visible = rclifor.Tp_pessoa.ToUpper().Equals("F");
        }

        private void afterGrava()
        {
            if (st_bloqcreditoavulso.Checked && string.IsNullOrEmpty(ds_motivobloqueio.Text))
            {
                MessageBox.Show("Obrigatorio informar motivo bloqueio para gerar bloqueio de credito avulso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFAnaliseCredito_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rclifor != null)
            {
                bsClifor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadClifor() { rclifor };
                this.VisualizarCampos();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFAnaliseCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
