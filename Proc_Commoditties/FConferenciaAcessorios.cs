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
    public partial class TFConferenciaAcessorios : Form
    {
        public CamadaDados.Servicos.TList_Acessorios lAcessorios
        { get; set; }

        public TFConferenciaAcessorios()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (!(bsAcessorios.DataSource as CamadaDados.Servicos.TList_Acessorios).Exists(p => p.St_devolvidobool))
            {
                if (MessageBox.Show("Existe um acessorio marcado para não ser devolvido.\r\n" +
                                "Confirma conferência mesmo assim?", "Pergunta", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    this.DialogResult = DialogResult.Yes;
            }
            else
                this.DialogResult = DialogResult.Yes;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFConferenciaAcessorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFConferenciaAcessorios_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsAcessorios.DataSource = lAcessorios;
        }

        private void gAcessorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsAcessorios.Current as CamadaDados.Servicos.TRegistro_Acessorios).St_devolvidobool =
                    !(bsAcessorios.Current as CamadaDados.Servicos.TRegistro_Acessorios).St_devolvidobool;
                bsAcessorios.ResetCurrentItem();
            }    
        }
    }
}
