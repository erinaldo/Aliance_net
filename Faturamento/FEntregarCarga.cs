using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFEntregarCarga : Form
    {
        private CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega rcarga;
        public CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega rCarga
        {
            get
            {
                if (bsCarga.Current != null)
                    return bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega;
                else
                    return null;
            }
            set
            { rcarga = value; }
        }

        public List<CamadaDados.Faturamento.Entrega.TRegistro_ItensCarga> lItensCarga
        { get; set; }

        public TFEntregarCarga()
        {
            InitializeComponent();
            lItensCarga = new List<CamadaDados.Faturamento.Entrega.TRegistro_ItensCarga>();
        }

        private void afterGrava()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFEntregarCarga_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCargaItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsCarga.DataSource = new CamadaDados.Faturamento.Entrega.TList_CargaEntrega() { this.rcarga };
            dt_entrega.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void TFEntregarCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFEntregarCarga_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCargaItens);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsCargaItens.MoveNext();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsCargaItens.MovePrevious();
        }

        private void qtd_entregue_ValueChanged(object sender, EventArgs e)
        {
            if (qtd_entregue.Value > qtd_entregar.Value)
                qtd_entregue.Value = qtd_entregar.Value;
        }
    }
}
