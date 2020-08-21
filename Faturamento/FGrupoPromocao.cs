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
    public partial class TFGrupoPromocao : Form
    {
        public CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rGrupo
        {
            get
            {
                if (bsGrupo.Current != null)
                    return bsGrupo.Current as CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo;
                else
                    return null;
            }
        }

        public TFGrupoPromocao()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx.Add(new Utils.TDataCombo("VALOR", "V"));

            tp_promocao.DataSource = cbx;
            tp_promocao.DisplayMember = "Display";
            tp_promocao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (vl_promocao.Focused)
                (bsGrupo.Current as CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo).Vl_promocao = vl_promocao.Value;
            if (qtd_minimavenda.Focused)
                (bsGrupo.Current as CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo).Qtd_minimavenda = qtd_minimavenda.Value;
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFGrupoPromocao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                              new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void TFGrupoPromocao_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsGrupo.AddNew();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'", new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void cd_grupo_TextChanged(object sender, EventArgs e)
        {
            cd_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
            bb_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
        }

        private void cd_produto_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_produto.Enabled)
                cd_produto.Clear();
        }

        private void cd_produto_TextChanged(object sender, EventArgs e)
        {
            cd_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
            bb_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
        }

        private void cd_grupo_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_grupo.Enabled)
                cd_grupo.Clear();
        }
    }
}
