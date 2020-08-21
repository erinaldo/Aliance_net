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
    public partial class TFListVendedor : Form
    {
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor> lVendedor
        {
            get
            {
                if (bsVendedor.Count > 0)
                    return (bsVendedor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFListVendedor()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((bsVendedor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).Exists(p => p.St_processar))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Obrigatório selecionar vendedor para finalizar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFListVendedor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Vendedor
            bsVendedor.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Gerente_X_Vendedor x " +
                                                        "where x.cd_vendedor = a.cd_clifor) "
                                        }
                                    },0, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gVendedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_processar =
                    !(bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_processar;
                bsVendedor.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsVendedor.Count > 0)
            {
                (bsVendedor.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadClifor).ForEach(p => p.St_processar = cbTodos.Checked);
                bsVendedor.ResetBindings(true);
            }
        }
    }
}
