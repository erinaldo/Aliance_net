using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFListaVeiculoCliente : Form
    {
        public CamadaDados.Servicos.Cadastros.TList_VeiculoCliente lVeiculo
        { get; set; }

        public TFListaVeiculoCliente()
        {
            InitializeComponent();
        }

        private void TFListaVeiculoCliente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gVeiculoCliente);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsVeiculoCliente.DataSource = lVeiculo;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gVeiculoCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsVeiculoCliente.Current as CamadaDados.Servicos.Cadastros.TRegistro_VeiculoCliente).St_processar)
                    (bsVeiculoCliente.List as CamadaDados.Servicos.Cadastros.TList_VeiculoCliente).ForEach(p => p.St_processar = false);
                (bsVeiculoCliente.Current as CamadaDados.Servicos.Cadastros.TRegistro_VeiculoCliente).St_processar =
                    !(bsVeiculoCliente.Current as CamadaDados.Servicos.Cadastros.TRegistro_VeiculoCliente).St_processar;
                bsVeiculoCliente.ResetCurrentItem();
            }
        }

        private void TFListaVeiculoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFListaVeiculoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gVeiculoCliente);
        }
    }
}
