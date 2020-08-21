using CamadaDados.Frota;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFDadosMovPneu : Form
    {
        public TRegistro_MovPneu rMovPneu
        {
            get
            {
                if (bsMovPneu.Current != null)
                    return bsMovPneu.Current as TRegistro_MovPneu;
                else return null;
            }
        }

        public TFDadosMovPneu()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("RECAP", "0"));
            cbx.Add(new TDataCombo("RODIZIO", "1"));
            cbx.Add(new TDataCombo("REPARO", "2"));

            tp_mov.DataSource = cbx;
            tp_mov.ValueMember = "Value";
            tp_mov.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("LISO", "0"));
            cbx1.Add(new TDataCombo("BORRACHUDO", "1"));

            tp_recap.DataSource = cbx1;
            tp_recap.ValueMember = "Value";
            tp_recap.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            //Verificar se tipo recap é obrigatório
            tp_recap.ST_NotNull = tp_mov.SelectedValue.Equals("0");
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFDadosMovPneu_Load(object sender, EventArgs e)
        {
            bsMovPneu.AddNew();
            pDados.set_FormatZero();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFDadosMovPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
