using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFCodBarra : Form
    {
        public string pCd_codbarra
        { get { return cd_codbarra.Text; } }

        public TFCodBarra()
        {
            InitializeComponent();
        }

        private void cd_codbarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(cd_codbarra.Text))
                {
                    object obj = new CamadaDados.Estoque.Cadastros.TCD_CodBarra().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_codbarra",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_codbarra.Text.Trim() + "'"
                                        }
                                    }, "a.cd_produto + '-' + b.ds_produto");
                    if (obj != null)
                    {
                        MessageBox.Show("Codigo barra ja esta cadastrado para o produto " + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFCodBarra_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }
}
