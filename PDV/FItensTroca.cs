using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace PDV
{
    public partial class TFItensTroca : Form
    {
        private decimal? Id_caracteristica { get; set; } = null;
        public CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                {
                    List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> ret = new List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item>();
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.ForEach(p => ret.Add(p));
                    return ret;
                }
                else
                    return null;
            }
        }
        public TFItensTroca()
        {
            InitializeComponent();
        }

        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void BuscarProduto()
        {
            if (bsItens.Current != null)
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                //Valor
                filtro[0].vNM_Campo = "dbo.F_PRECO_VENDA('" +
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa.Trim() + "'," +
                    "a.cd_produto, '" + (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_tabelapreco.Trim() + "')";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario.ToString().Replace(',', '.');
                CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
                if (string.IsNullOrEmpty(cd_produtobusca.Text))
                    rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Nm_empresa,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_tabelapreco,
                                                                 new Componentes.EditDefault[] { cd_produtobusca, ds_produtobusca },
                                                                 filtro);
                else if (cd_produtobusca.Text.SoNumero().Trim().Length != cd_produtobusca.Text.Trim().Length)
                    rProd = FormBusca.UtilPesquisa.BuscarProduto(cd_produtobusca.Text,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Nm_empresa,
                                                                 (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_tabelapreco,
                                                                 new Componentes.EditDefault[] { cd_produtobusca, ds_produtobusca },
                                                                 filtro);
                else
                {
                    System.Collections.Hashtable vParametros = new System.Collections.Hashtable();
                    vParametros.Add("@CD_EMPRESA", string.IsNullOrEmpty((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa) ?
                        "null" : (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa);
                    vParametros.Add("@CD_TABELAPRECO", string.IsNullOrEmpty((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_tabelapreco) ?
                        "null" : (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_tabelapreco);
                    CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                        new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                        new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + cd_produtobusca.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (cd_produtobusca.TextOld != null ? cd_produtobusca.TextOld.ToString() : cd_produtobusca.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + cd_produtobusca.Text.Trim() + "'))"
                            }
                            }, 0, string.Empty, string.Empty, string.Empty, vParametros);
                    if (lProd.Count > 0)
                        rProd = lProd[0];
                }
                if (rProd != null)
                {
                    cd_produtobusca.Text = rProd.CD_Produto;
                    ds_produtobusca.Text = rProd.DS_Produto;
                    Id_caracteristica = rProd.Id_caracteristicaH;
                    vl_venda.Text = rProd.Vl_precovenda.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    if (rProd.Vl_precovenda != (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario)
                    {
                        MessageBox.Show("Produto não pode ser trocado!\r\n" +
                                        "Selecione um item com valor de venda igual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produtobusca.Text = string.Empty;
                        ds_produtobusca.Text = string.Empty;
                        vl_venda.Text = string.Empty;
                        Id_caracteristica = null;
                        return;
                    }
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(rProd.CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(rProd.CD_Produto)))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(rProd.CD_Produto) &&
                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoPatrimonio(rProd.CD_Produto))
                        {
                            decimal saldo = BuscarSaldoLocal(lCfg[0].Cd_empresa, rProd.CD_Produto);
                            if (saldo < (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade)
                            {
                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                "Empresa.........: " + lCfg[0].Cd_empresa.Trim() + "-" + lCfg[0].Nm_empresa.Trim() + "\r\n" +
                                                "Produto.........: " + rProd.CD_Produto.Trim() + "-" + rProd.DS_Produto.Trim() + "\r\n" +
                                                "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_produtobusca.Text = string.Empty;
                                ds_produtobusca.Text = string.Empty;
                                vl_venda.Text = string.Empty;
                                Id_caracteristica = null;
                                return;
                            }
                        }
                        else
                        {
                            cd_produtobusca.Text = string.Empty;
                            ds_produtobusca.Text = string.Empty;
                            vl_venda.Text = string.Empty;
                            Id_caracteristica = null;
                        }
                    }
                }
                else
                {
                    cd_produtobusca.Clear();
                    cd_produtobusca.Focus();
                }
            }
            else
            {
                cd_produtobusca.Clear();
                cd_produtobusca.Focus();
            }
        }

        private void afterGrava()
        {
            if (bsVenda.Current != null)
            {
                if ((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Exists(p => p.lTrocaItem.Count.Equals(decimal.Zero)))
                {
                    MessageBox.Show("Não existe item para troca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Alocar Grade de Produto se Existir
                foreach (CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item r in (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem)
                {
                    if (r.Id_caracteristicaH.HasValue && r.lGrade.Count > 0)
                        if (r.Quantidade > r.lGrade.Sum(v => v.Vl_mov))
                        {
                            MessageBox.Show("Existe item com saldo para alocar em grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Não existe venda selecionada para troca de itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[1];
            //Status
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_venda.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_venda.Text;
            }
            if (!string.IsNullOrEmpty(Cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_nfce.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                      "inner join tb_pdv_nfce y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_cupom = y.id_nfce " +
                                                      "where a.cd_empresa = x.cd_empresa " +
                                                      "and a.id_vendarapida = x.id_vendarapida " +
                                                      "and y.nr_nfce = " + nr_nfce.Text + ")";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_vendarapida_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_vendarapida = a.id_vendarapida " +
                                                      "and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            }
            if (dt_inicial.Text.Trim() != "/  /       :")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inicial.Text).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            if (dt_final.Text.Trim() != "/  /       :")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_final.Text).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            bsVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(filtro, 0, string.Empty, string.Empty);
            bsVenda_PositionChanged(this, new EventArgs());
        }

        private void TFItensTroca_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            tlpItens.ColumnStyles[1].Width = 0;
            pFiltro.set_FormatZero();
            pProduto.set_FormatZero();
        }

        private void TFItensTroca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                if ((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Count.Equals(0))
                {
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem =
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar((bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Id_vendarapidastr,
                                                                                  (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa,
                                                                                  true,
                                                                                  "'A'",
                                                                                  null);
                    bsVenda.ResetCurrentItem();
                }
            }
        }

        private void cd_produtobusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).lTrocaItem.Count > 0)
                {
                    MessageBox.Show("Item já trocado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(cd_produtobusca.Text))
                {
                    InputBox ibp = new InputBox();
                    ibp.Text = "Motivo de Troca";
                    string motivo = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(motivo))
                    {
                        MessageBox.Show("Obrigatório informar motivo de troca do produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se preço de venda é igual ao do item a ser trocado.
                    if ((string.IsNullOrEmpty(vl_venda.Text) ? 0 : decimal.Parse(vl_venda.Text)) != (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario)
                    {
                        MessageBox.Show("Produto não pode ser trocado!\r\n" +
                                        "Selecione um item com valor de venda igual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_produtobusca.Text = string.Empty;
                        ds_produtobusca.Text = string.Empty;
                        vl_venda.Text = string.Empty;
                        Id_caracteristica = null;
                        return;
                    }
                    (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Add(
                        new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                        {
                            Id_vendarapida = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Id_vendarapida,
                            Cd_empresa = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_empresa,
                            Id_lanctovenda = (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Count + 1,
                            Cd_produto = cd_produtobusca.Text,
                            Ds_produto = ds_produtobusca.Text,
                            Id_caracteristicaH = Id_caracteristica,
                            Cd_local = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_local,
                            Cd_vendedor = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Cd_vendedor,
                            Quantidade = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade,
                            Sigla_unidade = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Sigla_unidade,
                            Vl_unitario = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_unitario,
                            Vl_desconto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_desconto,
                            Vl_acrescimo = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_acrescimo,
                            Vl_juro_fin = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_juro_fin,
                            Vl_frete = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_frete,
                            Vl_subtotal = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Vl_subtotal,
                            St_registro = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_registro,
                            St_processar = true
                        });
                    bsVenda.ResetCurrentItem();
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).lTrocaItem.Add(
                    new CamadaDados.Faturamento.PDV.TRegistro_TrocaItem()
                    {
                        Cd_produtoDest = cd_produtobusca.Text,
                        Ds_produtoDest = ds_produtobusca.Text,
                        Id_lanctoOrig = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Id_lanctovenda,
                        Id_lanctoDest = (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem.Count,
                        MotivoTroca = motivo
                    });
                    bsItens.ResetCurrentItem();
                    bsItens.MoveNext();
                    cd_produtobusca.Text = string.Empty;
                    ds_produtobusca.Text = string.Empty;
                    vl_venda.Text = string.Empty;

                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cd_produtobusca_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produtobusca.Text))
                BuscarProduto();
        }

        private void bbExcluiItem_Click(object sender, EventArgs e)
        {
            if (bsTrocaItem.Current != null)
            {
                bsTrocaItem.RemoveCurrent();
                bsItens.ResetCurrentItem();
            }
        }

        private void gGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gGrade.EndEdit();
        }

        private void gGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade -
                (bsValorGrade.List as List<CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov) +
                decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()) < decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()))

            {
                MessageBox.Show("valor infomado não pode ser maior que saldo movimento disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
                gGrade.EndEdit();
            }
            saldo_alocar.Text = string.Format(((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade -
                                                (bsValorGrade.List as List<CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov)).ToString(), "{0:N3}");
        }

        private void gGrade_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null &&
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_processar)
            {
                if ((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Id_caracteristicaH.HasValue)
                {
                    tlpItens.ColumnStyles[1].Width = 230;
                    CamadaNegocio.Estoque.Cadastros.TCN_ValorCaracteristica.Buscar((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Id_caracteristicaHstr,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         0,
                                                                                                         string.Empty,
                                                                                                         null).ForEach(p =>
                                                                                                         (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).lGrade.Add(p));
                    bsItens.ResetCurrentItem();
                    saldo_alocar.Text = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                }
                else tlpItens.ColumnStyles[1].Width = 0;
            }
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "a.st_registro|=|'A'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                           "a.st_registro|=|'A'",
                                           new Componentes.EditDefault[] { cd_produto },
                                           new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
