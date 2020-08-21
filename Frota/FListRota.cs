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
    public partial class TFListRota : Form
    {
        public List<CamadaDados.Frota.Cadastros.TRegistro_RotaFrete> lRotaf
        {
            get
            {
                if (bsRotaFrete.Count > 0)
                    return (bsRotaFrete.List as CamadaDados.Frota.Cadastros.TList_RotaFrete).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListRota()
        {
            InitializeComponent();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListRota_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRotaFrete);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsRotaFrete.DataSource = CamadaNegocio.Frota.Cadastros.TCN_RotaFrete.Buscar(string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
        }

        private void TFListRota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsRotaFrete.Count > 0)
            {
                (bsRotaFrete.List as CamadaDados.Frota.Cadastros.TList_RotaFrete).ForEach(p => p.St_processar = cbTodos.Checked);
                bsRotaFrete.ResetBindings(true);
            }
        }

        private void gRotaFrete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsRotaFrete.Current as CamadaDados.Frota.Cadastros.TRegistro_RotaFrete).St_processar =
                    !(bsRotaFrete.Current as CamadaDados.Frota.Cadastros.TRegistro_RotaFrete).St_processar;
                bsRotaFrete.ResetCurrentItem();
            }
        }

        private void TFListRota_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRotaFrete);
        }
    }
}
