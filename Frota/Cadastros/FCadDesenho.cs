using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFCadDesenho : Form
    {
        public TFCadDesenho()
        {
            InitializeComponent();
        }

        private void afterBuscar()
        {
            try
            {
                bindingSource1.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CadDesenhoPneu.Buscar(string.Empty, string.Empty, null);
                bindingSource1.ResetBindings(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FCadDesenho_Load(object sender, EventArgs e)
        {
            afterBuscar();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                return;
            try
            {
                CamadaDados.Frota.Cadastros.TRegistro_CadDesenhoPneu registro = new CamadaDados.Frota.Cadastros.TRegistro_CadDesenhoPneu();
                registro.Ds_desenho = textBox1.Text.Trim();
                if ((bindingSource1.DataSource as IEnumerable<CamadaDados.Frota.Cadastros.TRegistro_CadDesenhoPneu>).ToList().Exists(p => p.Ds_desenho.Equals(textBox1.Text.Trim())))
                    registro.Id_desenhostr = (bindingSource1.DataSource as IEnumerable<CamadaDados.Frota.Cadastros.TRegistro_CadDesenhoPneu>).ToList().Find(p => p.Ds_desenho.Equals(textBox1.Text.Trim())).Id_desenhostr;
                CamadaNegocio.Frota.Cadastros.TCN_CadDesenhoPneu.Gravar(registro, null);
                afterBuscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null)
            {
                try
                {
                    CamadaNegocio.Frota.Cadastros.TCN_CadDesenhoPneu.Excluir((bindingSource1.Current as CamadaDados.Frota.Cadastros.TRegistro_CadDesenhoPneu), null);
                    afterBuscar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
