using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFVendedorRegVenda : Form
    {
        public List<CamadaDados.Diversos.TRegistro_CadRegiaoVenda> lReg
        {
            get
            {
                if (bsRegVenda.Count > 0)
                    return (bsRegVenda.List as CamadaDados.Diversos.TList_CadRegiaoVenda).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFVendedorRegVenda()
        {
            InitializeComponent();
        }

        private void TFVendedorRegVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsRegVenda.DataSource = CamadaNegocio.Diversos.TCN_CadRegiaoVenda.Busca(decimal.Zero, string.Empty);
        }

        private void gRegVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsRegVenda.Current as CamadaDados.Diversos.TRegistro_CadRegiaoVenda).St_processar =
                    !(bsRegVenda.Current as CamadaDados.Diversos.TRegistro_CadRegiaoVenda).St_processar;
                bsRegVenda.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsRegVenda.Count > 0)
            {
                (bsRegVenda.List as CamadaDados.Diversos.TList_CadRegiaoVenda).ForEach(p => p.St_processar = cbTodos.Checked);
                bsRegVenda.ResetBindings(true);
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

        private void TFVendedorRegVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
