using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCopiarConfigVend : Form
    {
        public string Msg
        { get; set; }
        public string pCd_vendedor
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa lempresavend;
        public CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa lEmpresaVend
        {
            get
            {
                if (cbCfgEmpresaVend.Checked)
                    return lempresavend;
                else
                    return null;
            }
            set { lempresavend = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_GrupoProd lgrupoprodvend;
        public CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_GrupoProd lGrupoProdVend
        {
            get
            {
                if (cbCfgGrupoProdVend.Checked)
                    return lgrupoprodvend;
                else
                    return null;
            }
            set { lgrupoprodvend = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_RegiaoVenda lcarteiravend;
        public CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_RegiaoVenda lCarteiraVend
        {
            get
            {
                if (cbCfgCarteiraVend.Checked)
                    return lcarteiravend;
                else
                    return null;
            }
            set { lcarteiravend = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_CondPgto lcondpagtovend;
        public CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_CondPgto lCondPagtoVend
        {
            get
            {
                if (cbCfgCondPagtoVend.Checked)
                    return lcondpagtovend;
                else
                    return null;
            }
            set { lcondpagtovend = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_TabelaPreco ltabprecovend;
        public CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_TabelaPreco lTabPrecoVend
        {
            get
            {
                if (cbCfgTabPrecoVend.Checked)
                    return ltabprecovend;
                else
                    return null;
            }
            set { ltabprecovend = value; }
        }
        private CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor ldescontovend;
        public CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDescontovend
        {
            get
            {
                if (cbCfgDescontoVend.Checked)
                    return ldescontovend;
                else return null;
            }
            set { ldescontovend = value; }
        }

        public TFCopiarConfigVend()
        {
            InitializeComponent();
        }

        private void BuscarCFGVend()
        {
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                cbTodos.Enabled = true;
                //Buscar CFG. Empresa
                lempresavend = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Buscar(CD_CompVend.Text,
                                                                                                             string.Empty,
                                                                                                             null);
                cbCfgEmpresaVend.Enabled = lempresavend.Count > decimal.Zero;
                //Buscar CFG. Condição Pagamento
                lcondpagtovend = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Buscar(CD_CompVend.Text,
                                                                                                               string.Empty,
                                                                                                               null);
                cbCfgCondPagtoVend.Enabled = lcondpagtovend.Count > decimal.Zero;
                //Buscar CFG. Tabela Preço
                ltabprecovend = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Buscar(CD_CompVend.Text,
                                                                                                                  string.Empty,
                                                                                                                  null);
                cbCfgTabPrecoVend.Enabled = ltabprecovend.Count > decimal.Zero;
                //Buscar CFG.Carteira
                lcarteiravend = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_RegiaoVenda.Buscar(CD_CompVend.Text,
                                                                                                                  string.Empty,
                                                                                                                  null);
                cbCfgCarteiraVend.Enabled = lcarteiravend.Count > decimal.Zero;
                //Buscar CFG. Grupo Produto
                lgrupoprodvend = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Buscar(CD_CompVend.Text,
                                                                                                                 string.Empty,
                                                                                                                 null);
                cbCfgGrupoProdVend.Enabled = lgrupoprodvend.Count > decimal.Zero;
                //Buscar CFG. Desconto
                ldescontovend = CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                null);
                cbCfgDescontoVend.Enabled = ldescontovend.Count > decimal.Zero;
            }
        }

        private void afterGrava()
        {
            if (cbCfgEmpresaVend.Checked ||
                cbCfgCarteiraVend.Checked ||
                cbCfgCondPagtoVend.Checked ||
                cbCfgGrupoProdVend.Checked ||
                cbCfgTabPrecoVend.Checked)
            {
                Msg = "CONFIGURAÇÕES:\r\n\r\n";
                if (cbCfgTabPrecoVend.Checked)
                    Msg += "CFG. Tabela Preço \r\n";
                if (cbCfgCarteiraVend.Checked)
                    Msg += "CFG. Carteira Clientes \r\n";
                if (cbCfgCondPagtoVend.Checked)
                    Msg += "CFG. Condição Pagto \r\n";
                if (cbCfgGrupoProdVend.Checked)
                    Msg += "CFG. Grupo Produto \r\n";
                if (cbCfgTabPrecoVend.Checked)
                    Msg += "CFG. Tabela Preço \r\n";
                if (cbCfgDescontoVend.Checked)
                    Msg += "CFG. Desconto \r\n";

                Msg += "\r\ncopiados com sucesso!";
            }
            else
            {
                Msg = string.Empty;
                MessageBox.Show("É necessário marcar uma Configuração para gravar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            if (pCopiarVend.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S';a.cd_clifor|<>|'"+ pCd_vendedor.Trim() + "'");

            this.BuscarCFGVend();
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S';a.cd_clifor|<>|'"+ pCd_vendedor.Trim() + "'",
                new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

            this.BuscarCFGVend();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCopiarConfigVend_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pCopiarVend.set_FormatZero();
        }

        private void TFCopiarConfigVend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbCfgTabPrecoVend.Checked = cbTodos.Checked && cbCfgTabPrecoVend.Enabled;
            cbCfgGrupoProdVend.Checked = cbTodos.Checked && cbCfgGrupoProdVend.Enabled;
            cbCfgEmpresaVend.Checked = cbTodos.Checked && cbCfgEmpresaVend.Enabled;
            cbCfgCondPagtoVend.Checked = cbTodos.Checked && cbCfgCondPagtoVend.Enabled;
            cbCfgCarteiraVend.Checked = cbTodos.Checked && cbCfgCarteiraVend.Enabled;
        }
    }
}
