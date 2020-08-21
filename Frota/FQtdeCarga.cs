using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFQtdeCarga : Form
    {
        private CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga rqtde;
        public CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga rQtde
        {
            get
            {
                if (bsQtdeCarga.Current != null)
                    return bsQtdeCarga.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga;
                else return null;
            }
            set { rqtde = value; }
        }

        public TFQtdeCarga()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("METROS CUBICOS", "00"));
            cbx.Add(new Utils.TDataCombo("QUILOGRAMA", "01"));
            cbx.Add(new Utils.TDataCombo("TONELADA", "02"));
            cbx.Add(new Utils.TDataCombo("UNIDADE", "03"));
            cbx.Add(new Utils.TDataCombo("LITROS", "04"));
            cbx.Add(new Utils.TDataCombo("MMBTU", "05"));

            tp_unidade.DataSource = cbx;
            tp_unidade.DisplayMember = "Display";
            tp_unidade.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFQtdeCarga_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rqtde != null)
                bsQtdeCarga.DataSource = new CamadaDados.Faturamento.CTRC.TList_CTRQtdeCarga() { rqtde };
            else bsQtdeCarga.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFQtdeCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
