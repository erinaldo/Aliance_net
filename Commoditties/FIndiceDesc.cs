using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFIndiceDesc : Form
    {
        private CamadaDados.Graos.TRegistro_PercDesconto rperc;
        public CamadaDados.Graos.TRegistro_PercDesconto rPerc
        {
            get
            {
                if (bsIndice.Current != null)
                    return bsIndice.Current as CamadaDados.Graos.TRegistro_PercDesconto;
                else
                    return null;
            }
            set
            { rperc = value; }
        }

        public TFIndiceDesc()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (PC_Resultado.Focused)
                (bsIndice.Current as CamadaDados.Graos.TRegistro_PercDesconto).Pc_resultado = PC_Resultado.Value;
            if (PC_DescEstoque.Focused)
                (bsIndice.Current as CamadaDados.Graos.TRegistro_PercDesconto).Pc_descestoque = PC_DescEstoque.Value;
            if (PC_DescPagto.Focused)
                (bsIndice.Current as CamadaDados.Graos.TRegistro_PercDesconto).Pc_descpagto = PC_DescPagto.Value;
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFIndiceDesc_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rperc != null)
            {
                bsIndice.DataSource = new CamadaDados.Graos.TList_PercDesconto() { rperc };
                PC_Resultado.Enabled = false;
            }
            else
                bsIndice.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFIndiceDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
