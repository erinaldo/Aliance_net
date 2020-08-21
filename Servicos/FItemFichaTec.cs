using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFItemFichaTec : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_local
        { get; set; }
        public string pDs_local
        { get; set; }

        private CamadaDados.Servicos.TRegistro_FichaTecOS rficha;
        public CamadaDados.Servicos.TRegistro_FichaTecOS rFicha
        {
            get
            {
                if (bsFichaTec.Current != null)
                    return bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS;
                else return null;
            }
            set { rficha = value; }
        }
        public TFItemFichaTec()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_item.Text))
            {
                MessageBox.Show("Obrigatório informar item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_item.Focus();
                return;
            }
            if (quantidade.Focused)
                (bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Quantidade = quantidade.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void TFItemFichaTec_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rficha != null)
            {
                bsFichaTec.DataSource = new CamadaDados.Servicos.TList_FichaTecOS() { rficha };
                cd_item.Enabled = false;
                bb_item.Enabled = false;
            }
            else
            {
                bsFichaTec.AddNew();
                (bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Quantidade = 1;
                (bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Cd_local = pCd_local;
                (bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Ds_local = pDs_local;
                bsFichaTec.ResetCurrentItem();
            }
        }

        private void bb_item_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_item, ds_item, sg_unid_item }, "isnull(e.st_servico, 'N')|<>|'S';isnull(e.st_composto, 'N')|<>|'S'");
            vl_unitcusto.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(pCd_empresa, cd_item.Text, null);
            vl_unitcusto.Enabled = vl_unitcusto.Value.Equals(decimal.Zero);
        }

        private void cd_item_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_item.Text.Trim() + "';" +
                            "isnull(e.st_servico, 'N')|<>|'S';isnull(e.st_composto, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_item, ds_item, sg_unid_item },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            vl_unitcusto.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(pCd_empresa, cd_item.Text, null);
            vl_unitcusto.Enabled = vl_unitcusto.Value.Equals(decimal.Zero);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItemFichaTec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "c.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Cd. Local|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(), "a.cd_empresa|=|'" + pCd_empresa + "'");
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "a.cd_empresa|=|'" + pCd_empresa + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa());
        }
    }
}
