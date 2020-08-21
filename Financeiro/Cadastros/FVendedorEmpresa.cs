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
    public partial class TFVendedorEmpresa : Form
    {
        public string Cd_vendedor
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa rvend;
        public CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa rVend
        {
            get
            {
                if (bsVendEmpresa.Current != null)
                    return bsVendEmpresa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa;
                else
                    return null;
            }
            set { rvend = value; }
        }

        public TFVendedorEmpresa()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("FIXO VENDEDOR", "F"));
            cbx.Add(new Utils.TDataCombo("TABELA PREÇO", "T"));
            cbx.Add(new Utils.TDataCombo("FIXO PRODUTO", "P"));

            tp_comissao.DataSource = cbx;
            tp_comissao.DisplayMember = "Display";
            tp_comissao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFVendedorEmpresa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rvend != null)
            {
                bsVendEmpresa.DataSource = new CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa() { rvend };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                tp_comissao.Focus();
            }
            else
            {
                bsVendEmpresa.AddNew();
                (bsVendEmpresa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa).Cd_vendedor = Cd_vendedor;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFVendedorEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void tp_comissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_comissao.SelectedValue != null)
            if (tp_comissao.SelectedValue.Equals("F"))
                cbRecebimento.Visible = true;
            else
                cbRecebimento.Visible = false;
        }
    }
}
