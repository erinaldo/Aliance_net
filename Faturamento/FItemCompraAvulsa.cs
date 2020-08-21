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


namespace Faturamento
{
    public partial class TFItemCompraAvulsa : Form
    {
        public string CD_Empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens rItem
        { get { return bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens; } }

        public TFItemCompraAvulsa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(CD_Produto.Text) &&
                    string.IsNullOrEmpty(DS_Produto.Text))
                {
                    MessageBox.Show("Obrigatorio informar peça/serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscarProduto()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(e.ST_Servico, 'N')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'S'";
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;

            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vOperador = "<>";
                filtro[filtro.Length - 2].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                                      "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }

            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                sigla_unidade.Text = rProd.Sigla_unidade;
            }
        }

        private void Pc_DescontoItem_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                VL_Desconto.Value = Pc_DescontoItem.Value * Sub_Total.Value / 100;
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value;
            }
        }

        private void TFItemCompraAvulsa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsItensCompra.AddNew();
        }

        private void VL_Desconto_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = VL_Desconto.Value * 100 / Sub_Total.Value;
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItemCompraAvulsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            Sub_Total.Value = Quantidade.Value * Vl_Unitario.Value;
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            Sub_Total.Value = Quantidade.Value * Vl_Unitario.Value;
        }

        private void bb_novoproduto_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFAtualizaCadProduto fAtualiza = new Proc_Commoditties.TFAtualizaCadProduto())
            {
                fAtualiza.Text = "Novo Cadastro Produto";
                if(fAtualiza.ShowDialog() == DialogResult.OK)
                    if(fAtualiza.rProd != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                            MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Produto.Text = fAtualiza.rProd.CD_Produto;
                            CD_Produto_Leave(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Vl_Despesas_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = VL_Desconto.Value * 100 / Sub_Total.Value;
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + Vl_Despesas.Value;
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
                "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                              "(exists(select 1 from tb_est_codbarra x " +
                              "         where x.cd_produto = a.cd_produto " +
                              "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                              "isnull(a.st_registro, 'A')|<>|'C'" +
                              "         and e.ST_Servico = 'N'";
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, sigla_unidade },
                                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                Quantidade.Focus();
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.BuscarProduto();
                if (!string.IsNullOrEmpty(CD_Produto.Text))
                    Quantidade.Focus();
            }
        }
    }
}
