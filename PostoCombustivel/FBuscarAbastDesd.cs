using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFBuscarAbastDesd : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda
        { get { return (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar); } }

        public TFBuscarAbastDesd()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsVendaCombustivel.Count > 0)
            {
                if (!(bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Exists(p => p.St_processar))
                {
                    MessageBox.Show("Obrigatorio selecionar abastecida para desdobrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Obrigatorio selecionar abastecida para desdobrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(id_bico.Text))
            {
                MessageBox.Show("Obrigatorio informar bico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_bico.Focus();
                return;
            }
            bsVendaCombustivel.DataSource =
            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                       CD_Empresa.Text,
                                                                       string.Empty,
                                                                       id_bico.Text,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       dt_inicial.Text,
                                                                       dt_final.Text,
                                                                       "'A'",
                                                                       "N",
                                                                       false,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       "a.dt_abastecimento desc",
                                                                       null);
            volumetotal.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Volumeabastecido);
            valortotal.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Vl_subtotal);
        }

        private void TFBuscarAbastDesd_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAbastecimento);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_bico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|Id. Bico|60;" +
                              "a.ds_label|Label Bico|80;" +
                              "a.enderecofisicobico|Endereço Bico|80;" +
                              "c.ds_produto|Combustivel|200";
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(), vParam);
        }

        private void id_bico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|=|" + id_bico.Text + ";" +
                              "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFBuscarAbastDesd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsVendaCombustivel.Count > 0)
            {
                (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).ForEach(p => p.St_processar = cbTodos.Checked);
                bsVendaCombustivel.ResetBindings(true);

                volumeprocessar.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Volumeabastecido);
                valorprocessar.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void gAbastecimento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar =
                    !(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar;
                bsVendaCombustivel.ResetCurrentItem();

                volumeprocessar.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Volumeabastecido);
                valorprocessar.Value = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void TFBuscarAbastDesd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAbastecimento);
        }
    }
}
