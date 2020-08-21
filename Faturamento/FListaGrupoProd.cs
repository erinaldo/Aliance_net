using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFListaGrupoProd : Form
    {
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto> lGrupo
        {
            get
            {
                if (bsGrupoProduto.Count > 0)
                    return (bsGrupoProduto.List as CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public TFListaGrupoProd()
        {
            InitializeComponent();
        }

        private void TFListaGrupoProd_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsGrupoProduto.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_CadGrupoProduto.Busca(string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
        }

        private void gGrupoProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).St_processar)
                {
                    if((bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).Tp_Grupo != "A")
                    {
                        MessageBox.Show("Permitido marcar somente grupo ANALITICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).St_processar = true;
                }
                else (bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).St_processar = false;
                bsGrupoProduto.ResetBindings(true);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFListaGrupoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
