using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class TFLanDespesa : Form
    {
        public string pcd_empresa { get; set; }
        public string pnr_versao { get; set; }
        public string pid_despesa { get; set; }
        public string pid_orcamento { get; set; }
       
        public int foco { get; set; }

        private CamadaDados.Empreendimento.TRegistro_Despesas cDespesa;
        public CamadaDados.Empreendimento.TRegistro_Despesas rDespesa
        {
            get
            {
                return bsDespesa.Current as CamadaDados.Empreendimento.TRegistro_Despesas;
            }
            set { cDespesa = value; }
        }
        

        public TFLanDespesa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(ds_despesa.Text))
            {
                MessageBox.Show("Obrigatório informar despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_despesa.Focus();
                return;
            }
            if(qtd.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qtd.Focus();
                return;
            }
            if(vl_unitario.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor unitario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_unitario.Focus();
                return;
            }
            if (vl_subtotal.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar subtotal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_subtotal.Focus();
                return;
            }
            if ((bsDespesa.Current as CamadaDados.Empreendimento.TRegistro_Despesas).Vl_unitario == decimal.Zero)
                (bsDespesa.Current as CamadaDados.Empreendimento.TRegistro_Despesas).Vl_unitario = vl_unitario.Value;
            DialogResult = DialogResult.OK;
        }

        private void FLanDespesa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (cDespesa == null)
                bsDespesa.AddNew();
            else
            {
                bsDespesa.DataSource = new CamadaDados.Empreendimento.TList_Despesas() { cDespesa };
                if (foco == 2)
                    qtd.Focus();
                if (foco == 3)
                    vl_unitario.Focus();


            }
        }

        private void qtd_ValueChanged(object sender, EventArgs e)
        {
            vl_subtotal.Value = decimal.Multiply(qtd.Value, vl_unitario.Value);
        }

        private void vl_unitario_ValueChanged(object sender, EventArgs e)
        {
            vl_subtotal.Value = decimal.Multiply(qtd.Value, vl_unitario.Value);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLanDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {

            if (qtd.Value > decimal.Zero)
                vl_subtotal.Value = Math.Round(decimal.Multiply(qtd.Value, vl_unitario.Value), 2, MidpointRounding.AwayFromZero);
            else if (vl_subtotal.Value > decimal.Zero)
                qtd.Value = Math.Round(decimal.Divide(vl_subtotal.Value, vl_unitario.Value), 3, MidpointRounding.AwayFromZero);
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {

            if (vl_subtotal.Value > decimal.Zero)
            {
                if (qtd.Value > decimal.Zero)
                    vl_unitario.Value = Math.Round(decimal.Divide(vl_subtotal.Value, qtd.Value), 5, MidpointRounding.AwayFromZero);
                else if (vl_unitario.Value > decimal.Zero)
                    qtd.Value = Math.Round(decimal.Divide(vl_subtotal.Value, vl_unitario.Value), 3, MidpointRounding.AwayFromZero);
            }
        }

        private void qtd_Leave(object sender, EventArgs e)
        {

            if (vl_unitario.Value > decimal.Zero)
                vl_subtotal.Value = Math.Round(decimal.Multiply(qtd.Value, vl_unitario.Value), 2, MidpointRounding.AwayFromZero);
            else if (vl_subtotal.Value > decimal.Zero)
                vl_unitario.Value = Math.Round(decimal.Divide(vl_subtotal.Value, qtd.Value), 5, MidpointRounding.AwayFromZero);
        }
    }
}
