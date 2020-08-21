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
    public partial class TFDevolverSerieProduto : Form
    {
        public List<CamadaDados.Producao.Producao.TRegistro_SerieProduto> lSerie
        { get; set; }
        public decimal pQuantidade
        { get; set; }
        public TFDevolverSerieProduto()
        {
            InitializeComponent();
            lSerie = new List<CamadaDados.Producao.Producao.TRegistro_SerieProduto>();
        }

        private void afterGrava()
        {
            if (bsSerie.Current != null)
            {
                if (pQuantidade < (bsSerie.DataSource as List<CamadaDados.Producao.Producao.TRegistro_SerieProduto>).FindAll(p=> p.St_processar).Count)
                {
                    MessageBox.Show("Selecione " + pQuantidade.ToString() + " Nº Série(s) para devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsSerie.DataSource as List<CamadaDados.Producao.Producao.TRegistro_SerieProduto>).Exists(p => p.St_processar))
                    this.DialogResult = DialogResult.OK;
            }

        }

        private void TFDevolverSerieProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsSerie.DataSource = lSerie;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void TFDevolverSerieProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gSerie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsSerie.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).St_processar =
                    !(bsSerie.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).St_processar;
                bsSerie.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsSerie.Count > 0)
            {
                (bsSerie.DataSource as List<CamadaDados.Producao.Producao.TRegistro_SerieProduto>).ForEach(p => p.St_processar = cbTodos.Checked);
                bsSerie.ResetBindings(true);
            }
        }
    }
}
