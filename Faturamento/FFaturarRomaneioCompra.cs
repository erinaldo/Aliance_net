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
    public partial class TFFaturarRomaneioCompra : Form
    {
        public List<CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa> lCompra
        {
            get
            {
                if (bsCompraAvulsa.Count > 0)
                    return (bsCompraAvulsa.List as CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public string Cd_empresa
        { get { return cd_empresa.Text; } }
        public string Cd_clifor
        { get { return cd_clifor.Text; } }

        public TFFaturarRomaneioCompra()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar fornecedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            bsCompraAvulsa.DataSource = CamadaNegocio.Faturamento.CompraAvulsa.TCN_CompraAvulsa.Buscar(cd_empresa.Text,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       cd_clifor.Text,
                                                                                                       string.Empty,
                                                                                                       dt_ini.Text,
                                                                                                       dt_fin.Text,
                                                                                                       "'A'",
                                                                                                       null);
            tot_romaneio.Value = (bsCompraAvulsa.List as CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa).Sum(p => p.Vl_totalcompra);
        }

        private void TFFaturarRomaneioCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensCompra);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFFaturarRomaneioCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gItensCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).St_processar =
                    !(bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).St_processar;
                bsCompraAvulsa.ResetCurrentItem();
                tot_faturar.Value = (bsCompraAvulsa.List as CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa).Where(p => p.St_processar).Sum(p => p.Vl_totalcompra);
            }
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsCompraAvulsa.Count > 0)
            {
                (bsCompraAvulsa.List as CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa).ForEach(p => p.St_processar = cbProcessar.Checked);
                bsCompraAvulsa.ResetBindings(true);
                tot_faturar.Value = (bsCompraAvulsa.List as CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa).Where(p => p.St_processar).Sum(p => p.Vl_totalcompra);
            }
        }

        private void TFFaturarRomaneioCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensCompra);
        }
    }
}
