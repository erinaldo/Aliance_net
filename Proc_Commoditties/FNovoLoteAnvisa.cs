using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFNovoLoteAnvisa : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pCd_fornecedor
        { get; set; }
        public string pNm_fornecedor
        { get; set; }

        private CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa rlote;
        public CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa rLote
        { 
            get 
            {
                if (bsLoteAnvisa.Current != null)
                    return bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa;
                else
                    return null;
            }
            set { rlote = value; }
        }

        public TFNovoLoteAnvisa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_produto.Text))
            {
                MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_lote.Text))
            {
                MessageBox.Show("Obrigatório informar numero lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_lote.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FNovoLoteAnvisa_Load(object sender, EventArgs e)
        {
            this.pLote.set_FormatZero();
            if (rlote != null)
            {
                bsLoteAnvisa.DataSource = new CamadaDados.Faturamento.LoteAnvisa.TList_LoteAnvisa { rlote };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsLoteAnvisa.AddNew();
                cd_empresa.Text = pCd_empresa;
                nm_empresa.Text = pNm_empresa;
                cd_produto.Text = pCd_produto;
                ds_produto.Text = pDs_produto;
                cd_fornecedor.Text = pCd_fornecedor;
                nm_fornecedor.Text = pNm_fornecedor;
                if (!string.IsNullOrEmpty(cd_empresa.Text))
                {
                    cd_empresa.Enabled = false;
                    bb_empresa.Enabled = false;
                }
                if (!string.IsNullOrEmpty(cd_produto.Text))
                {
                    cd_produto.Enabled = false;
                    bb_produto.Enabled = false;
                }
                if (!string.IsNullOrEmpty(cd_fornecedor.Text))
                {
                    cd_fornecedor.Enabled = false;
                    bb_fornecedor.Enabled = false;
                }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void FNovoLoteAnvisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa  }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'",
                                             new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor },
                                             new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, string.Empty);
        }
    }
}
