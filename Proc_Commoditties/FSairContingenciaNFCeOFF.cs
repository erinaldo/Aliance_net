using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFSairContingenciaNFCeOFF : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF> lContingencia
        {
            get
            {
                if (bsContingencia.Count > 0)
                    return (bsContingencia.List as CamadaDados.Faturamento.PDV.TList_ContingenciaNFCeOFF).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFSairContingenciaNFCeOFF()
        {
            InitializeComponent();
        }

        private void TFSairContingenciaNFCeOFF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsContingencia.DataSource = CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.Buscar(string.Empty,
                                                                                                     string.Empty,
                                                                                                     "'A'",
                                                                                                     null);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsContingencia.Count > 0)
            {
                (bsContingencia.List as CamadaDados.Faturamento.PDV.TList_ContingenciaNFCeOFF).FindAll(p => p.St_processar = cbTodos.Checked);
                bsContingencia.ResetBindings(true);
            }
        }

        private void gContingencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsContingencia.Current != null)
            {
                (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).St_processar =
                    !(bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).St_processar;
                bsContingencia.ResetCurrentItem();
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

        private void TFSairContingenciaNFCeOFF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
