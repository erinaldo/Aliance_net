using System;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Graos;
using CamadaNegocio.Contabil;
using CamadaNegocio.Graos;

namespace Contabil
{
    public partial class TFSaldoEstoqueFixar : Form
    {
        public TFSaldoEstoqueFixar()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if(cbEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(cbProduto.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbProduto.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(dt_saldo.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_saldo.Focus();
                return;
            }
            if (tp_movimento.SelectedIndex == 0)
            {
                TList_SaldoFixar lSaldo = new TCD_SaldoFixar().Select_E(cbEmpresa.SelectedValue.ToString(),
                                                                        string.Empty,
                                                                        cbProduto.SelectedValue.ToString(),
                                                                        DateTime.Parse(dt_saldo.Text));
                if (lSaldo.Count > 0)
                {
                    ps_entrada.Value = lSaldo.Sum(p => p.Peso);
                    Ps_transf_E.Value = lSaldo.Sum(p => p.Ps_transf_E);
                    Ps_transf_S.Value = lSaldo.Sum(p => p.Ps_transf_S);
                    Ps_devolvido.Value = lSaldo.Sum(p => p.Ps_devolvido);
                    Ps_fixado.Value = lSaldo.Sum(p => p.Ps_fixado);
                    ps_saldo.Value = lSaldo.Sum(p => p.Ps_saldo);

                    vl_entrada.Value = lSaldo.Sum(p => p.Valor);
                    vl_transf_E.Value = lSaldo.Sum(p => p.Vl_transf_E);
                    vl_transf_S.Value = lSaldo.Sum(p => p.Vl_transf_S);
                    vl_devolvido.Value = lSaldo.Sum(p => p.Vl_devolvido);
                    vl_fixado.Value = lSaldo.Sum(p => p.Vl_fixado);
                    vl_saldo.Value = lSaldo.Sum(p => p.Vl_saldo);

                    lblPeso.Text = "(+)Peso Entrada";
                    lblValor.Text = "(+)Vl. Entrada";
                    lblPsTransfE.Text = "(+)Transf. Entrada";
                    lblVlTransfE.Text = "(+)Transf. Entrada";
                    lblPsTransfS.Text = "(-)Transf. Saida";
                    lblVlTransfS.Text = "(-)Transf. Saida";
                    TList_SaldoFixar resumo = new TList_SaldoFixar();
                    lSaldo.Where(p=> p.Ps_saldo > decimal.Zero).GroupBy(p => p.Nm_clifor,
                        (aux, venda) =>
                        new TRegistro_SaldoFixar
                        {
                            Nm_clifor = aux,
                            Peso = venda.Sum(x => x.Ps_saldo),
                            Valor = venda.Sum(x=> x.Vl_saldo)
                        }).ToList().ForEach(p => resumo.Add(p));
                    bsSaldoFixar.DataSource = resumo;
                }
            }
            else
            {
                TList_SaldoFixar lSaldo = new TCD_SaldoFixar().Select_S(cbEmpresa.SelectedValue.ToString(),
                                                                        cbProduto.SelectedValue.ToString(),
                                                                        DateTime.Parse(dt_saldo.Text));
                if(lSaldo.Count > 0)
                {
                    ps_entrada.Value = lSaldo.Sum(p => p.Peso);
                    Ps_transf_E.Value = lSaldo.Sum(p => p.Ps_transf_E);
                    Ps_transf_S.Value = lSaldo.Sum(p => p.Ps_transf_S);
                    Ps_devolvido.Value = lSaldo.Sum(p => p.Ps_devolvido);
                    Ps_fixado.Value = lSaldo.Sum(p => p.Ps_fixado);
                    ps_saldo.Value = lSaldo.Sum(p => p.Ps_saldo);

                    vl_entrada.Value = lSaldo.Sum(p => p.Valor);
                    vl_transf_E.Value = lSaldo.Sum(p => p.Vl_transf_E);
                    vl_transf_S.Value = lSaldo.Sum(p => p.Vl_transf_S);
                    vl_devolvido.Value = lSaldo.Sum(p => p.Vl_devolvido);
                    vl_fixado.Value = lSaldo.Sum(p => p.Vl_fixado);
                    vl_saldo.Value = lSaldo.Sum(p => p.Vl_saldo);

                    lblPeso.Text = "(+)Peso Saida";
                    lblValor.Text = "(+)Vl. Saida";
                    lblPsTransfE.Text = "(-)Transf. Entrada";
                    lblVlTransfE.Text = "(-)Transf. Entrada";
                    lblPsTransfS.Text = "(+)Transf. Saida";
                    lblVlTransfS.Text = "(+)Transf. Saida";
                    TList_SaldoFixar resumo = new TList_SaldoFixar();
                    lSaldo.Where(p=> p.Ps_saldo > decimal.Zero).GroupBy(p => p.Nm_clifor,
                        (aux, venda) =>
                        new TRegistro_SaldoFixar
                        {
                            Nm_clifor = aux,
                            Peso = venda.Sum(x => x.Ps_saldo),
                            Valor = venda.Sum(x=> x.Vl_saldo)
                        }).ToList().ForEach(p => resumo.Add(p));
                    bsSaldoFixar.DataSource = resumo;
                }
            }
            //Buscar Preço Mercado Commodities
            TList_PrecoCommodities lCotacao = new TCD_PrecoCommodities().SelectProdCotacao(cbProduto.SelectedValue.ToString(), DateTime.Parse(dt_saldo.Text));
            if(lCotacao.Count > 0)
                if(tp_movimento.SelectedIndex == 0 && lCotacao[0].Vl_precocompra > decimal.Zero)
                {
                    lblCompraVenda.Text = "Valor Compra";
                    vl_compra.ReadOnly = true;
                    cbUnidade.Enabled = false;
                    vl_compra.Value = lCotacao[0].Vl_precocompra;
                    dt_preco.Text = lCotacao[0].Dt_precostr;
                    cbUnidade.SelectedValue = lCotacao[0].Cd_unidade;
                    //Calcular valor atualizado
                    vl_atualizado.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(lCotacao[0].Cd_unidade, (cbProduto.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Unidade, ps_saldo.Value * lCotacao[0].Vl_precocompra, 2, null);
                }
                else if(tp_movimento.SelectedIndex == 1 && lCotacao[0].Vl_precovenda > decimal.Zero)
                {
                    lblCompraVenda.Text = "Valor Venda";
                    vl_compra.ReadOnly = true;
                    cbUnidade.Enabled = false;
                    vl_compra.Value = lCotacao[0].Vl_precovenda;
                    dt_preco.Text = lCotacao[0].Dt_precostr;
                    cbUnidade.SelectedValue = lCotacao[0].Cd_unidade;
                    //Calcular valor atualizado
                    vl_atualizado.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(lCotacao[0].Cd_unidade, (cbProduto.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Unidade, ps_saldo.Value * lCotacao[0].Vl_precovenda, 2, null);
                }
        }

        private void ajustarSaldo()
        {
            if(cbEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(cbProduto.SelectedIndex < 0)
            {
                MessageBox.Show("Obrigatório selecionar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbProduto.Focus();
                return;
            }
            if(ps_saldo.Value > decimal.Zero && vl_compra.Value.Equals(0))
            {
                MessageBox.Show("Obrigatório informar valor de compra para ajustar valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_compra.Focus();
                return;
            }
            if(string.IsNullOrEmpty(dt_saldo.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_saldo.Focus();
                return;
            }
            try
            {
                TCN_AtualizaEstFixar.AjustarEstFixar(cbEmpresa.SelectedValue.ToString(),
                                                     cbProduto.SelectedValue.ToString(),
                                                     DateTime.Parse(dt_saldo.Text),
                                                     vl_saldo.Value,
                                                     vl_atualizado.Value,
                                                     tp_movimento.SelectedIndex == 0 ? "C" : "V",
                                                     null);
                MessageBox.Show("Atualização de saldo gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFSaldoEstoqueFixar_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            tp_movimento.SelectedIndex = 0;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            //Produto
            cbProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(e.st_commodities, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
            cbProduto.DisplayMember = "DS_Produto";
            cbProduto.ValueMember = "CD_Produto";
            //Unidade Medida
            cbUnidade.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_CadUnidade.Busca(string.Empty, string.Empty, string.Empty, null);
            cbUnidade.DisplayMember = "DS_Unidade";
            cbUnidade.ValueMember = "CD_Unidade";
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bbAjustarSaldo_Click(object sender, EventArgs e)
        {
            ajustarSaldo();
        }

        private void TFSaldoEstoqueFixar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ajustarSaldo();
        }

        private void bbAtualizaCotacao_Click(object sender, EventArgs e)
        {
            if (cbProduto.SelectedItem != null)
                using (Proc_Commoditties.TFCotacaoCommodities fCotacao = new Proc_Commoditties.TFCotacaoCommodities())
                {
                    fCotacao.pCd_produto = (cbProduto.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCotacao.pDs_produto = (cbProduto.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    if (fCotacao.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_PrecoCommodities.Gravar(
                                new TRegistro_PrecoCommodities()
                                {
                                    Cd_produto = fCotacao.pCd_produto,
                                    Cd_unidade = fCotacao.pCd_unidade,
                                    Dt_preco = fCotacao.pDt_cotacao,
                                    Vl_precocompra = fCotacao.pVl_precocompra,
                                    Vl_precovenda = fCotacao.pVl_precovenda
                                }, null);
                            MessageBox.Show("Cotação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }
    }
}
