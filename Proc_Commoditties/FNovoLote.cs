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
    public partial class TFNovoLote : Form
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

        private CamadaDados.Sementes.TRegistro_LoteSemente rlote;
        public CamadaDados.Sementes.TRegistro_LoteSemente rLote
        {
            get
            {
                if (bsLoteSemente.Current != null)
                    return bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente;
                else
                    return null;
            }
            set { rlote = value; }
        }

        public TFNovoLote()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFNovoLote_Load(object sender, EventArgs e)
        {
            this.pDados.set_FormatZero();
            if (rlote != null)
            {
                bsLoteSemente.DataSource = new CamadaDados.Sementes.TList_LoteSemente { rlote };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsLoteSemente.AddNew();
                cd_empresa.Text = pCd_empresa;
                nm_empresa.Text = pNm_empresa;
                cd_produto.Text = pCd_produto;
                ds_produto.Text = pDs_produto;
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
            }
        }

        private void TFNovoLote_KeyDown(object sender, KeyEventArgs e)
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
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
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

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
