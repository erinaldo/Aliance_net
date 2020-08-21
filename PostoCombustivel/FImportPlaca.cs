using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFImportPlaca : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }

        public List<CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa> lPlaca
        {
            get
            {
                if (bsConvPlaca.Count > 0)
                    return (bsConvPlaca.List as CamadaDados.PostoCombustivel.TList_Convenio_Placa).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFImportPlaca()
        {
            InitializeComponent();
        }

        private void TFImportPlaca_Load(object sender, EventArgs e)
        {
            bsConvPlaca.DataSource = new CamadaDados.PostoCombustivel.TCD_Convenio_Placa().SelectImport(pCd_empresa, pCd_clifor);
        }

        private void gPlaca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsConvPlaca.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa).St_processar =
                    !(bsConvPlaca.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa).St_processar;
                bsConvPlaca.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsConvPlaca.Count > 0)
            {
                (bsConvPlaca.List as CamadaDados.PostoCombustivel.TList_Convenio_Placa).ForEach(p => p.St_processar = cbTodos.Checked);
                bsConvPlaca.ResetBindings(true);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFImportPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
