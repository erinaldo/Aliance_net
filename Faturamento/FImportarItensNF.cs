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
    public partial class TFImportarItensNF : Form
    {
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItensNota
        { get; set; }
        public TFImportarItensNF()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((bsItensNota.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Exists(p => p.St_processar))
                this.DialogResult = DialogResult.OK;
        }

        private void TFImportarItensNF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItensNota.DataSource = lItensNota;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                (bsItensNota.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItensNota.ResetBindings(true);
            }
        }

        private void gItensNota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar =
                    !(bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar;
                bsItensNota.ResetCurrentItem();
            }
        }

        private void TFImportarItensNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
