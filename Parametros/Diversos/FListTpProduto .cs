using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFListTpProduto : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadTpProduto> lTpProduto
        {
            get
            {
                if (bsTpProduto.Count > 0)
                    return (bsTpProduto.List as CamadaDados.Estoque.Cadastros.TList_CadTpProduto).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListTpProduto()
        {
            InitializeComponent();
        }

        private void gTpDuplicata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTpProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadTpProduto).St_processar =
                    !(bsTpProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadTpProduto).St_processar;
                bsTpProduto.ResetCurrentItem();
            }
        }

        private void TFListTpDuplicata_Load(object sender, EventArgs e)
        {
            bsTpProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpProduto x " +
                                                            "where x.TP_Produto = a.TP_Produto " +
                                                            "and x.login = '" + Login.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTpProduto.Count > 0)
            {
                (bsTpProduto.List as CamadaDados.Estoque.Cadastros.TList_CadTpProduto).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTpProduto.ResetBindings(true);
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

        private void TFListTpDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
