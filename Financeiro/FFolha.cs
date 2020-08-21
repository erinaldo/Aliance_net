using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFFolha : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public List<CamadaDados.Financeiro.Folha_Pagamento.TRegistro_PagamentoFolha> lPagtoFolha
        {
            get
            {
                if (bsFuncionario.Count > 0)
                    return (bsFuncionario.DataSource as CamadaDados.Financeiro.Folha_Pagamento.TList_PagamentoFolha).FindAll(p=> p.St_gerarpagamento);
                else
                    return null;
            }
        }

        public TFFolha()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = null;
            if (cbSomenteFuncEmpresa.Checked)
            {
                filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            }
            bsFuncionario.DataSource = new CamadaDados.Financeiro.Folha_Pagamento.TCD_FolhaPagamento().Select(filtro, CD_Empresa.Text, 0, string.Empty);
        }

        private void TotalizarFolha()
        {
            if (bsFuncionario.Count > 0)
                tot_pagar.Text = (bsFuncionario.List as CamadaDados.Financeiro.Folha_Pagamento.TList_PagamentoFolha).Where(p => p.St_gerarpagamento).Sum(p => p.Vl_salario).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
        }

        private void TFFolha_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gFuncionario);
            CD_Empresa.Text = this.Cd_empresa;
            NM_Empresa.Text = this.Nm_empresa;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
            vl_adtodevolver.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR INFORMAR VALOR DEVOLUCAO ADIANTAMENTO", null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void st_marcartodos_Click(object sender, EventArgs e)
        {
            if (bsFuncionario.Count > 0)
            {
                (bsFuncionario.DataSource as CamadaDados.Financeiro.Folha_Pagamento.TList_PagamentoFolha).ForEach(p => p.St_gerarpagamento = st_marcartodos.Checked);
                bsFuncionario.ResetBindings(true);
                this.TotalizarFolha();
            }
        }

        private void gFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsFuncionario.Current != null))
            {
                (bsFuncionario.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_PagamentoFolha).St_gerarpagamento =
                    !(bsFuncionario.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_PagamentoFolha).St_gerarpagamento;
                bsFuncionario.ResetCurrentItem();
                this.TotalizarFolha();
            }
        }

        private void TFFolha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsFuncionario.MoveNext();
            vl_salario.Focus();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsFuncionario.MovePrevious();
            vl_salario.Focus();
        }

        private void cbSomenteFuncEmpresa_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void vl_adtodevolver_Leave(object sender, EventArgs e)
        {
            if (vl_adtodevolver.Value > vl_saldoadto.Value)
                vl_adtodevolver.Value = vl_saldoadto.Value;
            if (vl_adtodevolver.Value > vl_salario.Value)
                vl_adtodevolver.Value = vl_salario.Value;
        }

        private void TFFolha_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gFuncionario);
        }
    }
}
