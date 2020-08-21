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
    public partial class TFProcessarOrcamento : Form
    {
        private CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rorcamento;
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rOrcamento
        {
            get
            {
                if (bsOrcamento.Current != null)
                    return bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento;
                else
                    return null;
            }
            set { rorcamento = value; }
        }

        public TFProcessarOrcamento()
        {
            InitializeComponent();
        }

        private void VerificarEstoque()
        {
            if (bsItens.Current != null)
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto) ||
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoIndustrializado(
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto))
                    using (TFDisponibilidadeEstoque fDisp = new TFDisponibilidadeEstoque())
                    {
                        fDisp.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                        fDisp.Nm_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nm_empresa;
                        fDisp.rItemOrc = bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                        fDisp.ShowDialog();
                    }
        }

        private decimal BuscarSaldoLocal()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(cd_localarm.Text)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, cd_produto.Text, cd_localarm.Text, ref saldo, null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private string VerificarSaldoEstoque()
        {
            string msg = string.Empty;
            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.FindAll(p=> !p.St_servicobool).ForEach(p =>
                {
                    p.Qtd_saldoestoque = this.BuscarSaldoLocal();
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto) ||
                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoIndustrializado(p.Cd_produto))
                        {
                            CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lItem = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarFichaTecItem(CD_Empresa.Text,
                                                                                                 cd_localarm.Text,
                                                                                                 p,
                                                                                                 lItem);
                            if (lItem.Exists(v => v.St_semsaldoestoque))
                            {
                                msg += "Produto composto " + p.Cd_produto.Trim() + " sem saldo de materia prima para faturar.\r\n";
                                List<CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item> lItemSaldo = lItem.FindAll(v => v.St_semsaldoestoque);
                                lItemSaldo.ForEach(v => msg += "Materia Prima: " + v.Cd_produto.Trim() + " Qtd: " + v.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + " Saldo: " +
                                    v.Qtd_saldoestoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n");
                            }
                        }
                        else
                            if (p.Quantidade > p.Qtd_saldoestoque)
                                msg += "Produto " + p.Cd_produto.Trim() + " sem saldo para faturar. Qtd: " + p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + " Saldo: " +
                                    p.Qtd_saldoestoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                });
            return msg;
        }

        private void afterGrava()
        {
            if (bsOrcamento.Current != null)
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Exists(p => (!p.St_servicobool) && string.IsNullOrEmpty(p.Cd_local)))
                {
                    MessageBox.Show("Não é permitido processar orçamento sem informar local de armazenagem para os itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            string msg = this.VerificarSaldoEstoque();
            if(!string.IsNullOrEmpty(msg))
                if (MessageBox.Show(msg.Trim() + "\r\n" +
                                   "Confirma processamento mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    != DialogResult.Yes)
                    return;
            this.DialogResult = DialogResult.OK;
        }

        private void TFProcessarOrcamento_Load(object sender, EventArgs e)
        {

            Utils.ShapeGrid.RestoreShape(this, gItens);
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            bsOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { rorcamento };
        }

        private void bb_localarm_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Local|Local Armazenagem|300;a.CD_Local|Código|80"
                , new Componentes.EditDefault[] { cd_localarm, ds_localarm }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, CD_Empresa.Text), string.Empty);

            (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Qtd_saldoestoque = this.BuscarSaldoLocal();
            bsItens.ResetCurrentItem();
        }

        private void cd_localarm_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            FormBusca.UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localarm.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { cd_localarm, ds_localarm },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, CD_Empresa.Text));

            (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Qtd_saldoestoque = this.BuscarSaldoLocal();
            bsItens.ResetCurrentItem();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProcessarOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_disponibilidadeestoque_Click(object sender, EventArgs e)
        {
            this.VerificarEstoque();
        }

        private void TFProcessarOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
