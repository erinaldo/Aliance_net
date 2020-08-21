using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFListaChCustodiaDeposito : Form
    {
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lCheque
        { get; set; }

        public TFListaChCustodiaDeposito()
        {
            InitializeComponent();
        }

        private void TFListaChCustodiaDeposito_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lCheque.ForEach(p => p.St_processar = true);
            bsChequesCustodia.DataSource = lCheque;
        }

        private void dG_Titulo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsChequesCustodia.Current != null))
            {
                (bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_processar = 
                    !(bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_processar;
                bsChequesCustodia.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaChCustodiaDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
