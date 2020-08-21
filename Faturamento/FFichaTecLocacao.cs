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
    public partial class TFFichaTecLocacao : Form
    {
        public string Cd_tabelapreco
        { get; set; }
        public CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao rItem
        { get; set; }

        public TFFichaTecLocacao()
        {
            InitializeComponent();
        }

        private void ExcluirItem()
        {
            if (bsFichaTec.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).lFichaTecDel.Add(
                    bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc);
                bsFichaTec.RemoveCurrent();
            }
        }

        private void BuscarProduto()
        {
            if (string.IsNullOrEmpty(cd_item.Text))
                FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                     rItem.Cd_empresa,
                                                     string.Empty,
                                                     Cd_tabelapreco,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                     rItem.Cd_empresa,
                                                     string.Empty,
                                                     Cd_tabelapreco,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            if (BuscarItens())
            {
                cd_item.Clear();
                quantidade.Focus();
            }
            else
            {
                MessageBox.Show("Produto inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_item.Clear();
                cd_item.Focus();
            }
        }

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_item.Text))
            {
                string pCd_codbarra = cd_item.Text;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (cd_item.Text.Trim().Length < lParam[0].Tamanho)
                        cd_item.Text = cd_item.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cd_item.Text,
                                                                                            pCd_codbarra,
                                                                                            null);

                if (lProduto.Count > 0)
                {
                    //Cria novo item
                    bsFichaTec.AddNew();
                    (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Cd_item = lProduto[0].CD_Produto;
                    (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Ds_item = lProduto[0].DS_Produto;
                    (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Sigla_item = lProduto[0].Sigla_unidade;
                    (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Quantidade = qtd_item.Value;
                    (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(rItem.Cd_empresa, lProduto[0].CD_Produto, null);
                    bsItens.ResetCurrentItem();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void TFFichaTecLocacao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItens.DataSource = new CamadaDados.Faturamento.Locacao.TList_ItensLocacao() { rItem };
        }

        private void bb_excluirficha_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFFichaTecLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                this.ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F12))
                this.BuscarProduto();
        }

        private void bsFichaTec_PositionChanged(object sender, EventArgs e)
        {
            qtd_item.Value = bsFichaTec.Current == null ? 1 : (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Quantidade > decimal.Zero ?
                (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Quantidade : 1;
            vl_unitario.Value = bsFichaTec.Current == null ? vl_unitario.Minimum : (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Vl_custo;
            lblVlSubTotal.Text = bsFichaTec.Current == null ? string.Empty : (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Vl_totalcusto.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void cd_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                this.BuscarProduto();
        }

        private void cd_item_Enter(object sender, EventArgs e)
        {
            qtd_item.Value = 1;
            vl_unitario.Value = vl_unitario.Minimum;
            lblVlSubTotal.Text = string.Empty;
        }

        private void qtd_item_Leave(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
            {
                (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Quantidade = qtd_item.Value;
                bsFichaTec.ResetCurrentItem();
                if (!cd_item.Focused)
                    vl_unitario.Focus();
                bsFichaTec_PositionChanged(this, new EventArgs());
            }
        }

        private void qtd_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                qtd_item_Leave(sender, new EventArgs());
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
            {
                (bsFichaTec.Current as CamadaDados.Faturamento.Locacao.TRegistro_FichaTecItensLoc).Vl_custo = vl_unitario.Value;
                bsFichaTec.ResetCurrentItem();
                bsFichaTec_PositionChanged(this, new EventArgs());
                cd_item.Focus();
            }
        }
    }
}
