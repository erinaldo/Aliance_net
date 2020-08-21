using System;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;

namespace Faturamento
{
    public partial class TFPrecoItem : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        public TList_RegLanFaturamento_Item lItens
        { get; set; }

        public TFPrecoItem()
        {
            InitializeComponent();
            dt_inivigencia.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void PrecoProduto()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text.Trim())) &&
                (!string.IsNullOrEmpty(CD_Produto.Text.Trim())) &&
                (!string.IsNullOrEmpty(CD_TabelaPreco.Text.Trim())))
            {
                TList_LanPrecoItem lPreco = new TCD_LanPrecoItem().SelectConsultaPreco(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_tabelapreco",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_TabelaPreco.Text.Trim() + "'"
                    }
                }, 1, string.Empty);
                if (lPreco.Count > 0)
                    VL_PrecoVenda.Value = lPreco[0].VL_PrecoVenda;
            }
        }

        private void UltimaCompra()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text.Trim())) &&
                (!string.IsNullOrEmpty(CD_Produto.Text.Trim())))
            {
                TListUltimasCompras UltimaCompra = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.tp_movimento",
                                                            vOperador = "=",
                                                            vVL_Busca = "'E'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "b.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "b.cd_produto",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'N'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'N'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        }
                                                    }, 2);
                if (UltimaCompra.Count > 0)
                {
                    vl_ultimacompra.Value = UltimaCompra[0].Vl_UnitCustoNota;
                    if (UltimaCompra.Count > 1)
                    {
                        vl_penultimacompra.Value = UltimaCompra[1].Vl_UnitCustoNota;
                        if (vl_penultimacompra.Value > vl_ultimacompra.Value)
                            pc_aumentodesconto.Value = 100 - ((vl_ultimacompra.Value * 100) / vl_penultimacompra.Value);
                        else
                            pc_aumentodesconto.Value = ((vl_ultimacompra.Value * 100) / vl_penultimacompra.Value) - 100;
                    }
                }
            }
        }

        private void custoProduto()
        {
            decimal vl_custo = 0;
            CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(CD_Empresa.Text, CD_Produto.Text, ref vl_custo, null);
            vl_custoproduto.Value = vl_custo;
        }

        private void TFPrecoItem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensNf);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            lItens.ForEach(p=> p.St_atualizaprecovenda = false);
            bsItensNf.DataSource = lItens;
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TabelaPreco|Descrição da Tabela de Preço|300;a.CD_TabelaPreco|Cd. Tab.Preço|80"
                                      , new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                                      new CamadaDados.Diversos.TCD_CadTbPreco(), null);
            this.PrecoProduto();
            this.custoProduto();
            this.UltimaCompra();
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_TabelaPreco|=|'" + CD_TabelaPreco.Text + "'"
             , new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco());
            this.PrecoProduto();
            this.custoProduto();
            this.UltimaCompra();
        }

        private void gItensNf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsItensNf.Current != null))
            {
                if ((bsItensNf.Current as TRegistro_LanFaturamento_Item).St_atualizaprecovenda)
                    (bsItensNf.Current as TRegistro_LanFaturamento_Item).St_atualizaprecovenda = false;
                else
                {
                    (bsItensNf.DataSource as TList_RegLanFaturamento_Item).ForEach(p => p.St_atualizaprecovenda = false);
                    (bsItensNf.Current as TRegistro_LanFaturamento_Item).St_atualizaprecovenda = true;
                    if (string.IsNullOrEmpty(CD_Empresa.Text))
                    {
                        CD_Empresa.Text = Cd_empresa;
                        NM_Empresa.Text = Nm_empresa;
                    }
                    CD_Produto.Text = (bsItensNf.List as TList_RegLanFaturamento_Item).Find(p => p.St_atualizaprecovenda).Cd_produto;
                    DS_Produto.Text = (bsItensNf.List as TList_RegLanFaturamento_Item).Find(p => p.St_atualizaprecovenda).Ds_produto;
                    if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                        CD_TabelaPreco_Leave(this, new EventArgs());
                }
                bsItensNf.ResetBindings(true);
            }
        }

        private void bb_aplicperc_Click(object sender, EventArgs e)
        {
            if ((pc_aumentodesconto.Value > decimal.Zero) && (VL_PrecoVenda.Value > decimal.Zero))
                if (vl_ultimacompra.Value > vl_penultimacompra.Value)
                    vl_novopreco.Value = VL_PrecoVenda.Value + Math.Round(((VL_PrecoVenda.Value * pc_aumentodesconto.Value) / 100), 2);
                else
                    vl_novopreco.Value = VL_PrecoVenda.Value - Math.Round(((VL_PrecoVenda.Value * pc_aumentodesconto.Value) / 100), 2);
        }

        private void TFPrecoItem_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utils.ShapeGrid.SaveShape(this, gItensNf);
        }

        private void pc_atualizacao_Leave(object sender, EventArgs e)
        {
            if (pc_atualizacao.Value > decimal.Zero)
                if (rbCusto.Checked)
                    if (vl_custoproduto.Value > decimal.Zero)
                        vl_novopreco.Value = vl_custoproduto.Value + Math.Round(decimal.Divide(decimal.Multiply(vl_custoproduto.Value, pc_atualizacao.Value), 100), 2);
                    else
                        MessageBox.Show("Produto sem custo para atualizar preço venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (rbPrecoAtual.Checked)
                    if (VL_PrecoVenda.Value > decimal.Zero)
                        vl_novopreco.Value = VL_PrecoVenda.Value + Math.Round(decimal.Divide(decimal.Multiply(VL_PrecoVenda.Value, pc_atualizacao.Value), 100), 2);
                    else
                        MessageBox.Show("Produto sem preço venda para atualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (rbUltimaCompra.Checked)
                    if (vl_ultimacompra.Value > decimal.Zero)
                        vl_novopreco.Value = vl_ultimacompra.Value + Math.Round(decimal.Divide(decimal.Multiply(vl_ultimacompra.Value, pc_atualizacao.Value), 100), 2);
                    else
                        MessageBox.Show("Produto sem valor ultima compra para atualizar preço venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            if (pc_atualizacao.Focused)
                pc_atualizacao_Leave(this, new EventArgs());
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(bsItensNf.List as TList_RegLanFaturamento_Item).Exists(p => p.St_atualizaprecovenda))
            {
                MessageBox.Show("Obrigatorio selecionar item venda para atualizar preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(CD_TabelaPreco.Text))
            {
                MessageBox.Show("Obrigatorio informar tabela de preço para atualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_TabelaPreco.Focus();
                return;
            }
            if (vl_novopreco.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar novo preço venda para atualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_novopreco.Focus();
                return;
            }
            if(string.IsNullOrEmpty(dt_inivigencia.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data inicial vigência do preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_inivigencia.Focus();
                return;
            }
            try
            {
                CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Grava_LanPrecoItem(
                    new TRegistro_LanPrecoItem()
                    {
                        CD_Empresa = CD_Empresa.Text,
                        CD_Produto = CD_Produto.Text,
                        CD_TabelaPreco = CD_TabelaPreco.Text,
                        Dt_preco = Convert.ToDateTime(dt_inivigencia.Text),
                        Vl_NovoPreco = vl_novopreco.Value
                    }, null);
                MessageBox.Show("Preço de venda atualizado com sucesso.", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                bsItensNf.RemoveCurrent();
                CD_Empresa.Clear();
                NM_Empresa.Clear();
                CD_Produto.Clear();
                DS_Produto.Clear();
                vl_penultimacompra.Value = decimal.Zero;
                vl_ultimacompra.Value = decimal.Zero;
                vl_custoproduto.Value = decimal.Zero;
                VL_PrecoVenda.Value = decimal.Zero;
                vl_novopreco.Value = decimal.Zero;
                pc_aumentodesconto.Value = decimal.Zero;
                pc_atualizacao.Value = decimal.Zero;
                dt_inivigencia.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void btn_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }
    }
}
