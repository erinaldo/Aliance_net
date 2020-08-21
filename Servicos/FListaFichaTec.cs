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
    public partial class TFListaFichaTec : Form
    {
        public CamadaDados.Servicos.TList_FichaTecOS lFicha
        { get; set; }

        public TFListaFichaTec()
        {
            InitializeComponent();
        }

        private void TFListaFichaTec_Load(object sender, EventArgs e)
        {
            bsFichaTec.DataSource = lFicha;
        }

        private void bbCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bbConfirma_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Count > 0)
            {
                (bsFichaTec.List as CamadaDados.Servicos.TList_FichaTecOS).ForEach(p => p.St_processar = cbTodos.Checked);
                bsFichaTec.ResetBindings(true);
            }
        }

        private void gTodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).St_processar =
                    !(bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).St_processar;
                bsFichaTec.ResetCurrentItem();
            }
        }
    }
}
