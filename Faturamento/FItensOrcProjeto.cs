using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFItensOrcProjeto : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        private CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item ritem;
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item rItem
        {
            get
            {
                if (bsItensOrcamento.Current != null)
                    return bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                else
                    return null;
            }
            set
            { ritem = value; }
        }

        public TFItensOrcProjeto()
        {
            InitializeComponent();
        }

        private void BuscarProduto()
        {
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             pCd_empresa,
                                                             pNm_empresa,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             pCd_empresa,
                                                             pNm_empresa,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                st_servico.Checked = rProd.St_servico;
                if (bsItensOrcamento.Current != null)
                {
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo = rProd.CD_Grupo;
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                    (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_condfiscal_produto = rProd.DS_CondFiscal_Produto;
                }
            }
            else
            {
                CD_Produto.Clear();
                CD_Produto.Focus();
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFItensOrcProjeto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (ritem != null)
            {
                bsItensOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item() { ritem };
                CD_Produto.Enabled = string.IsNullOrEmpty(ritem.Cd_produto);
                if (!CD_Produto.Focus())
                    Sub_Total.Focus();
            }
            else
            {
                bsItensOrcamento.AddNew();
                (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade = 1;
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
               "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                             "(exists(select 1 from tb_est_codbarra x " +
                             "         where x.cd_produto = a.cd_produto " +
                             "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                             "isnull(a.st_registro, 'A')|<>|'C'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                DS_Produto.Enabled = false;
            else
            {
                DS_Produto.Enabled = true;
                DS_Produto.Focus();
            }
            if (linha != null)
                st_servico.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.BuscarProduto();
                Sub_Total.Focus();
            }
        }

        private void CD_Produto_TextChanged(object sender, EventArgs e)
        {
            DS_Produto.Enabled = string.IsNullOrEmpty(CD_Produto.Text);
            st_servico.Enabled = string.IsNullOrEmpty(CD_Produto.Text);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensOrcProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Sub_Total_ValueChanged(object sender, EventArgs e)
        {
            (bsItensOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario = Sub_Total.Value;
            bsItensOrcamento.ResetCurrentItem();
        }
    }
}
