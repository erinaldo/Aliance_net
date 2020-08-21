using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFListaContatos : Form
    {
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor> lContato
        { get; set; }

        public TFListaContatos()
        {
            InitializeComponent();
        }

        private void TFListaContatos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsContato.DataSource = lContato;
        }

        private void gContato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato =
                    !(bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).St_utilizarContato;
                bsContato.ResetCurrentItem();
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

        private void TFListaContatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
