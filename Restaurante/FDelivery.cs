using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using System.IO;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using Restaurante.Impressao;

namespace Restaurante
{
    public partial class TFDelivery : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa { get; set; }
        private bool Altera_Relatorio { get; set; } = false;
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant
        { get; set; }
        private List<TRegistro_Adicionais> lAdicionais;
        private string LoginPdv { get; set; }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private CamadaDados.Faturamento.PDV.TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private TRegistro_Cartao cCartao { get; set; }
        public TRegistro_Cartao rCartao
        {
            get { return bsCartao.Current as TRegistro_Cartao; }
            set { cCartao = value; }
        }
        private bool alterando = false;
        private TList_CFG lcfg { get; set; } = new TList_CFG();

        public TFDelivery()
        {
            InitializeComponent();
        }

        private void BuscarProduto()
        {
            if (string.IsNullOrEmpty(txtDados.Text))
            {
                if (FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                        lcfg[0].cd_empresa,
                                                        string.Empty,
                                                        lcfg[0].cd_tabelapreco,
                                                        new Componentes.EditDefault[] { txtDados },
                                                        null) == null)
                {
                    MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDados.Clear();
                    txtDados.Focus();
                    return;
                }
                else
                    lblQuantidade.Focus();
            }
            else if (txtDados.Text.SoNumero().Trim().Length != txtDados.Text.Trim().Length)
                if (FormBusca.UtilPesquisa.BuscarProduto(txtDados.Text,
                                                        lcfg[0].cd_empresa,
                                                        string.Empty,
                                                        lcfg[0].cd_tabelapreco,
                                                        new Componentes.EditDefault[] { txtDados },
                                                        null) == null)
                {
                    MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDados.Clear();
                    txtDados.Focus();
                    return;
                }
                else
                    lblQuantidade.Focus();

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
                                vVL_Busca = "(a.cd_produto like '%" + txtDados.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (txtDados.TextOld != null ? txtDados.TextOld.ToString() : txtDados.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + txtDados.Text.Trim() + "'))"
                            }
                    }, 0, string.Empty, string.Empty, string.Empty);
            if (lProd.Count > 0 && !string.IsNullOrEmpty(txtDados.Text.Trim()))
            {
                txtDados.Text = lProd[0].CD_Produto;
                lblQuantidade.Focus();
            }
        }

        private bool AddSabores()
        {
            if (bsItensPreVenda.Count > 0)
            {
                //Buscar quantidade máxima de sabores
                object qt_ = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto
                        }
                    }, "a.qt_combsabores");

                //Buscar grupo de produto para filtro de sabores
                object cdGrupo = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto
                        }
                    }, "a.cd_grupo");

                //Form informando sabores, de acordo com grupo de produto e quantidade máxima
                if (qt_ != null && !string.IsNullOrEmpty(qt_.ToString())
                        && cdGrupo != null && !string.IsNullOrEmpty(cdGrupo.ToString())
                        && Convert.ToDecimal(qt_.ToString()) > 0)
                    using (TFAddSabores sabores = new TFAddSabores())
                    {
                        sabores.qtd_agregar = Convert.ToDecimal(qt_.ToString());
                        sabores.vCd_Grupo = cdGrupo.ToString();
                        if (sabores.ShowDialog() == DialogResult.OK)
                        {
                            if (sabores.lSabores.Count > 0)
                            {
                                sabores.lSabores.ForEach(p =>
                                {
                                    p.Cd_Empresa = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa;
                                    p.Id_Item = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item;
                                    p.Id_PreVenda = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda;
                                    p.cd_grupo = cdGrupo.ToString();
                                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).lSabores.Add(p);
                                });

                                bsPreVenda.ResetCurrentItem();
                            }
                            //TCN_PreVenda_Item.Gravar((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                            return true;
                        }
                        else
                        {
                            //TCN_PreVenda_Item.Excluir((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                            (bsPreVenda.Current as TRegistro_PreVenda).lItens.Remove(bsItensPreVenda.Current as TRegistro_PreVenda_Item);
                            bsPreVenda.ResetCurrentItem();
                            return false;
                        }
                    }
            }

            return false;
        }

        private void carregarproduto()
        {
            if (!string.IsNullOrEmpty(txtDados.Text))
            {
                if (string.IsNullOrEmpty(lblQuantidade.Text))
                    lblQuantidade.Text = "1,00";

                //valida se ainda possui limite
                if (!string.IsNullOrEmpty(lblQuantidade.Text))
                    if (Convert.ToDecimal(lblQuantidade.Text) == decimal.Zero)
                        lblQuantidade.Text = "1,00";

                //Buscar preço de venda na tabela de preço
                object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(new TpBusca[]
                    {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador= "=",
                                    vVL_Busca = ""+txtDados.Text.SoNumero()+""
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.CD_TabelaPreco",
                                    vOperador = "=",
                                    vVL_Busca = ""+lcfg[0].cd_tabelapreco+""
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = ""+lcfg[0].cd_empresa+""
                                }
                    }, "a.vl_precovenda");

                //Buscar descrição do produto
                object obj2 = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(new TpBusca[]
                    {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador= "=",
                                    vVL_Busca = ""+txtDados.Text.SoNumero()+""
                                }
                    }, "a.ds_produto");

                // verifica se maior de idade
                object obj3 = new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador= "exists",
                            vVL_Busca = "( select 1 from tb_est_produto x where x.cd_produto = "+txtDados.Text.SoNumero()+" and x.cd_grupo = a.cd_grupo)"
                        }
                    }, "a.st_proibidomenores");
                string st_menor = obj3 != null ? obj3.ToString() : string.Empty;
                if (st_menor.Equals("S") && (bsCartao.Current as TRegistro_Cartao).status_menor.Equals("S"))
                {
                    bsCartao.RemoveCurrent();
                    MessageBox.Show("Produto não pode ser vendido para menores de idade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                //Valor do produto pela tabela de preço
                if (obj != null)
                {
                    TRegistro_PreVenda_Item item = new TRegistro_PreVenda_Item();
                    item.cd_produto = txtDados.Text.SoNumero();
                    if (string.IsNullOrEmpty(lblQuantidade.Text.Trim()))
                        lblQuantidade.Text = "1,00";
                    item.quantidade = Convert.ToDecimal(lblQuantidade.Text);

                    //Buscar unidade do produto
                    TpBusca[] filtroo = new TpBusca[0];
                    Array.Resize(ref filtroo, filtroo.Length + 1);
                    filtroo[filtroo.Length - 1].vOperador = "exists";
                    filtroo[filtroo.Length - 1].vVL_Busca = " (SELECT 1 FROM TB_EST_PRODUTO X WHERE X.CD_UNIDADE = A.CD_UNIDADE AND X.CD_PRODUTO = " + txtDados.Text.SoNumero() + ") ";
                    CamadaDados.Estoque.Cadastros.TList_CadUnidade un = new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(filtroo, 1, string.Empty, "a.casasdecimais");

                    if (!string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).Cd_empresa))
                    {
                        //Validar se prevenda tem st_delivery ativo
                        (bsCartao.Current as TRegistro_Cartao).nr_card = "1";
                        object a = new TCD_Cartao().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vVL_Busca = "a.dt_abertura > (dateadd(hour,-12,getdate())) and a.dt_abertura <   getdate()"
                                },
                                new TpBusca()
                                {
                                    vOperador = "exists",
                                    vVL_Busca = "( select 1 from tb_res_prevenda x where a.id_cartao = x.id_cartao and x.st_delivery is not null )"
                                }
                            }
                            , "  (isnull(a.nr_cartao,0) + 1) as nr_cartao  ", "a.id_cartao desc");
                        if (a != null)
                            if (!string.IsNullOrEmpty(a.ToString()))
                                (bsCartao.Current as TRegistro_Cartao).nr_card = a.ToString();

                        //Buscar código da cidade do consumidor final
                        object cd_cdd = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_Clifor",
                                    vOperador = "=",
                                    vVL_Busca = lcfg[0].Cd_Clifor
                                }
                            }, "a.cd_cidade");
                        if (cd_cdd != null)
                            if (!string.IsNullOrEmpty(cd_cdd.ToString()))
                                (bsClifor.Current as TRegistro_Clifor).cd_cidade = cd_cdd.ToString();

                        //Gerar pedido delivery para consumidor final 
                        gravarPedido();

                        //Gerar novo cartão/ pré-venda para consumidor final 
                        (bsPreVenda.Current as TRegistro_PreVenda).St_delivery = "A";
                        //TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);

                        bsCartao_PositionChanged(this, new EventArgs());
                        bsCartao.ResetCurrentItem();
                        item.Cd_empresa = (bsCartao.Current as TRegistro_Cartao).Cd_empresa;
                        item.cd_produto = txtDados.Text.SoNumero();

                        //Valida se clifor possui programa de desconto/ acrésimo
                        CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = new CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda();
                        rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                             (bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                                             item.cd_produto.SoNumero(),
                                                                                                             lcfg[0].cd_tabelapreco,
                                                                                                             null);
                        item.quantidade = Convert.ToDecimal(lblQuantidade.Text);
                        item.vl_unitario = Convert.ToDecimal(obj.ToString());
                        item.vl_unitario = Convert.ToDecimal(item.vl_unitario.ToString("N" + ((un != null && un[0].CasasDecimais != decimal.Zero) ? un[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR")));
                        item.id_prevenda = (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda;
                        item.Cd_empresa = (bsPreVenda.Current as TRegistro_PreVenda).Cd_empresa;
                        item.ds_produto = obj2 != null ? obj2.ToString() : string.Empty;
                        item.vl_desconto = CalcularDescEspecial(rProg, item.cd_produto, 1, item.vl_unitario);

                        //Buscar porta imp do produto
                        try
                        {
                            TpBusca[] tps = new TpBusca[0];
                            Estruturas.CriarParametro(ref tps, "a.cd_produto", item.cd_produto);
                            object id = new CamadaDados.Estoque.TCD_ConsultaProduto().BuscarEscalar(tps, "a.id_localimp");
                            item.id_portaimp = id == null ? 0 : Convert.ToDecimal(id);
                        }
                        catch { }


                        //verifica se tem obs do produto 
                        object obs_item = new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().BuscarEscalar(new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vOperador= "exists",
                                vVL_Busca = "( select 1 from tb_est_produto x where x.cd_produto = "+txtDados.Text.SoNumero()+" and x.cd_grupo = a.cd_grupo)"
                            }
                        }, "a.st_obsitem");

                        if (new TCD_Adicionais().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = item.cd_produto
                                }
                            }, "a.cd_produto") != null)
                        {
                            Componentes.EditDefault cd_prod = new Componentes.EditDefault();
                            cd_prod.NM_Alias = "id_item";
                            cd_prod.NM_Campo = "id_item";
                            cd_prod.NM_CampoBusca = "id_item";
                            cd_prod.NM_Param = "id_item";

                            string vColunas = "b.ds_produto|Nome Produto|200;" +
                                              "a.id_item|Id. Item|50;" +
                                                "a.cd_produto|Cd. Produto|80";
                            string vParam = "isnull(a.id_itempaiadic,0)|=| 0;" +
                                            "isnull(a.st_registro, 'A')|=|'A';" +
                                            "A.id_prevenda |=|" + (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString();
                            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_prod }, new TCD_PreVenda_Item(), vParam);
                            if (!string.IsNullOrEmpty(cd_prod.Text))
                            {
                                item.id_itemPaiAdic = Convert.ToDecimal(cd_prod.Text);
                                item.id_prevenda = (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda;
                                item.Cd_empresa = (bsPreVenda.Current as TRegistro_PreVenda).Cd_empresa;
                            }
                            else
                            {
                                MessageBox.Show("Para acrescentar o adicional é necessário informar um produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }

                        bsItensPreVenda.Add(item);

                        //Gerar item da pré-venda
                        //TCN_PreVenda_Item.Gravar(item, null);
                        ////Buscar itens da pré-venda recém gravada
                        //(bsPreVenda.Current as TRegistro_PreVenda).lItens = TCN_PreVenda_Item.Buscar(lcfg[0].cd_empresa,
                        //                                                                            (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                        //                                                                            string.Empty,
                        //                                                                            string.Empty,
                        //                                                                            null);

                        bsPreVenda.ResetCurrentItem();
                        bsItensPreVenda.Position = bsItensPreVenda.Count;
                        int position = bsItensPreVenda.Position;

                        //Buscar sabores por grupo de produto
                        AddSabores();

                        //Buscar adicionais do produto e adiciona no carrinho
                        AddCarrinho();

                        bsItensPreVenda.Position = position;
                        if (obs_item != null)
                        {
                            if (obs_item.ToString().Equals("S") && lcfg[0].Tp_cartao.Equals("2"))
                            {
                                InputBox ibp = new InputBox();
                                ibp.Text = "Obs: " + item.ds_produto;
                                item.obsItem = ibp.ShowDialog();
                                item.id_item = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item;
                                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem = item.obsItem;
                                //TCN_PreVenda_Item.Gravar(item, null);
                            }
                        }
                        bsCartao_PositionChanged(this, new EventArgs());
                        bsPreVenda.ResetCurrentItem();
                        bsItensPreVenda.Position = bsItensPreVenda.Count;
                    }

                    //carregarproduto totais
                    TpBusca[] filtro = new TpBusca[0];
                    string st = string.Empty;
                    int i = 0;
                    (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                    {
                        st += "( exists (SELECT 1 FROM TB_EST_PRODUTO X WHERE X.CD_UNIDADE = A.CD_UNIDADE AND X.CD_PRODUTO = " + p.cd_produto + ") )";
                        if (i < (bsPreVenda.Current as TRegistro_PreVenda).lItens.Count - 1)
                            st += "or";
                        i++;
                    });

                    CamadaDados.Estoque.Cadastros.TList_CadUnidade uni;
                    if (!string.IsNullOrEmpty(st))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vVL_Busca = st;
                        uni = new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(filtro, 1, string.Empty, "a.casasdecimais");

                        //Totalizador
                        decimal total = decimal.Zero;
                        decimal valor = decimal.Zero;
                        decimal desconto = decimal.Zero;
                        (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                        {
                            total += p.vl_liquido;
                            valor += p.vl_subtotal;
                            desconto += p.vl_desconto * p.quantidade;
                        });
                        VLsubtotal.Text = valor.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
                        lbldesconto.Text = desconto.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
                        lblTotal.Text = total.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));

                    }
                }
                else
                {
                    MessageBox.Show("Produto sem preço cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private decimal CalcularDescEspecial(CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg,
                                             string cd_produto,
                                             decimal Qtde,
                                             decimal Vl_unit)
        {
            //St_descEspecial = false;
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.
                        Where(p => p.Cd_produto.Equals(cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                        else
                            return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private void lblQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                lblQuantidade_Leave(this, new EventArgs());
        }

        private void gravarPedido()
        {
            if (panelDados4.validarCampoObrigatorio())
                if (bsCartao.Current != null)
                {
                    try
                    {
                        TCN_Cartao.GravarDelivery((bsCartao.Current as TRegistro_Cartao), (bsClifor.Current as TRegistro_Clifor), null);
                        (bsClifor.DataSource) = new TCD_Clifor().Select(new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor
                            }
                        }, 1, string.Empty);
                        bsClifor.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
        }

        private void buscarultimavenda()
        {
            if (bsClifor.Current != null)
            {
                if (string.IsNullOrEmpty((bsClifor.Current as TRegistro_Clifor).Cd_clifor))
                    return;
                bsPreVendaUltimo.DataSource = new TCD_PreVenda().Select(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "d.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsClifor.Current as TRegistro_Clifor).Cd_clifor.Trim() + "'"
                        },
                        new TpBusca
                        {
                            vNM_Campo = "a.ST_Delivery",
                            vOperador = "in",
                            vVL_Busca = "('F', 'E')"
                        }
                    }, 0, string.Empty, "a.dt_venda desc");
                bsPreVendaUltimo_PositionChanged(this, new EventArgs());
                bsPreVendaUltimo.ResetCurrentItem();
            }
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(lcfg[0].cd_empresa)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).Cd_Clifor))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(lcfg[0].cd_empresa,
                                                                                                         (bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                                         vCd_produto,
                                                                                                         lcfg[0].cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(lcfg[0].cd_empresa,
                                                                                                    vCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty(lcfg[0].cd_tabelapreco))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(lcfg[0].cd_empresa,
                                                                                                vCd_produto,
                                                                                                lcfg[0].cd_tabelapreco,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void AddCarrinho()
        {
            if (bsItensPreVenda.Count > 0)
            {
                decimal iditem = (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Count;
                lAdicionais = TCN_Adicionais.Buscar(string.Empty, string.Empty, (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto, null);
                if (lAdicionais.Count > 0)
                    using (TFAdicionais fAssistente = new TFAdicionais())
                    {
                        fAssistente.vCd_Produto = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                {
                                    TRegistro_PreVenda_Item rItemPre = new TRegistro_PreVenda_Item();
                                    rItemPre.cd_produto = p.CD_Produto;
                                    rItemPre.Cd_empresa = lcfg[0].cd_empresa;
                                    rItemPre.ds_produto = p.DS_Produto;
                                    rItemPre.id_itemPaiAdic = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item == null ? iditem : (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item;
                                    rItemPre.id_prevenda = (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda;
                                    rItemPre.vl_unitario = p.vl_unitario;
                                    rItemPre.quantidade = p.Quantidade;
                                    if (rItemPre.vl_unitario > decimal.Zero)
                                    {
                                        CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = new CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda();
                                        rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                                         (bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                                                         rItemPre.cd_produto,
                                                                                                                         lcfg[0].cd_tabelapreco,
                                                                                                                         null);
                                        rItemPre.vl_subtotal = rItemPre.vl_unitario * rItemPre.quantidade;
                                        rItemPre.vl_desconto = CalcularDescEspecial(rProg, rItemPre.cd_produto, 1, rItemPre.vl_unitario);
                                    }
                                    (bsPreVenda.Current as TRegistro_PreVenda).lItens.Add(rItemPre);
                                    //TCN_PreVenda_Item.Gravar(rItemPre, null);
                                });
                                bsCartao_PositionChanged(this, new EventArgs());
                                bsPreVenda.ResetCurrentItem();
                            }
                    }
            }
        }

        private void altera_qtd()
        {
            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
            {
                fQtd.Text = "Quantidade";
                fQtd.Vl_default = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).quantidade;
                if (fQtd.ShowDialog() == DialogResult.OK)
                    if (fQtd.Quantidade > decimal.Zero)
                    {
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).quantidade =
                            fQtd.Quantidade;
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).vl_subtotal =
                            decimal.Multiply((bsItensPreVenda.Current as TRegistro_PreVenda_Item).quantidade,
                            (bsItensPreVenda.Current as TRegistro_PreVenda_Item).vl_unitario);
                        bsItensPreVenda.ResetCurrentItem();
                        calculatotal();
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void FDelivery_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Não existe CFG.Restaurante cadastrada, não será possível finalizar a operação.!", "Mensagem", MessageBoxButtons.OK); return; }
            if (string.IsNullOrEmpty(LoginPdv)) LoginPdv = Utils.Parametros.pubLogin;

            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.RowTemplate.MinimumHeight = 20;
            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count.Equals(0))
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            if (!string.IsNullOrEmpty(lPdv[0].Nm_empresa))
            {
                //Buscar Config Cupom
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
                if (lCfg.Count < 1)
                {
                    MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + lPdv[0].Cd_empresa,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            //Verificar sessao
            if (new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_pdv",
                                    vOperador = "=",
                                    vVL_Busca = lPdv[0].Id_pdvstr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + LoginPdv + "'"
                                }
                            }, "1") == null)
                CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                    new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                    {
                        Id_pdvstr = lPdv[0].Id_pdvstr,
                        Login = LoginPdv
                    }, null);
            //Buscar sessao aberta
            lSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(lPdv[0].Id_pdvstr,
                                                                      string.Empty,
                                                                      LoginPdv,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'A'",
                                                                      1,
                                                                      null);
            if (lSessao.Count < 1)
            {
                MessageBox.Show("Não existe sessão aberta para o PDV " + lPdv[0].Id_pdvstr + " Login " + LoginPdv,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Busca caixa aberto
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + LoginPdv + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 1, string.Empty);
            if (lCaixa.Count > 0)
                rCaixa = lCaixa[0];
            else
            {
                MessageBox.Show("Não existe caixa aberto para iniciar movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
            }
            if (cCartao != null)
            {
                bsCartao.Add(cCartao);

                (bsCartao.Current as TRegistro_Cartao).lPreVenda = TCN_PreVenda.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                       (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(),
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "A",
                                                                                       null);
                (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(p =>
                {
                    p.lItens = TCN_PreVenda_Item.Buscar(p.Cd_empresa, p.id_prevenda.ToString(), string.Empty, string.Empty, null);
                    p.lItens.ForEach(o =>
                    {
                        o.lSabores = TCN_SaboresItens.Buscar(o.Cd_empresa, o.id_prevenda.ToString(), o.id_item.ToString(), string.Empty, null);
                    });
                });

                TList_Clifor clifor = new TList_Clifor();
                clifor = new TCD_Clifor().Select(
                    new TpBusca[] {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = cCartao.Cd_Clifor
                        }
                    }, 1, string.Empty);
                bsClifor.Add(clifor[0]);
                bsClifor.ResetCurrentItem();
                bsCartao.ResetCurrentItem();
                calculatotal();
                buscarultimavenda();
                alterando = true;
            }
            else
            {
                if (bsClifor.Count.Equals(0))
                    bsClifor.AddNew();
                bsCartao.AddNew();
                (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                (bsCartao.Current as TRegistro_Cartao).Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                (bsCartao.Current as TRegistro_Cartao).status_menor = "N";
                (bsCartao.Current as TRegistro_Cartao).St_registro = "A";
                (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = lcfg[0].Cd_Clifor;
                if ((bsCartao.Current as TRegistro_Cartao).lPreVenda.Count.Equals(0))
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda.Add(new TRegistro_PreVenda
                    {
                        St_delivery = "A",
                        Dt_venda = DateTime.Now
                    });
                bsCartao.ResetCurrentItem();
            }
            if (string.IsNullOrEmpty((bsClifor.Current as TRegistro_Clifor).Cd_clifor))
            {
                editDefault1.Focus();
            }
            else
                txtDados.Focus();
            lblQuantidade.Text = "1,00";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Adicionar";
            btn.UseColumnTextForButtonValue = true;
            dataGridDefault2.Columns.Insert(0, btn);
        }

        private void txtDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (panelDados4.validarCampoObrigatorio())
            {
                if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                    if (bsClifor.Count >= 1)
                        BuscarProduto();
                    else
                    {
                        MessageBox.Show("Informe o cliente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        editDefault1.Focus();
                    }
                else if (e.KeyCode.Equals(Keys.F9))
                    altera_qtd();
            }
            lblQuantidade.Text = "1,00";
        }

        private void FecharVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda, ThreadEspera tEspera)
        {

            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarCup(rVenda,
                                                                    null,
                                                                    null,
                                                                    tEspera,
                                                                    null);
            using (PostoCombustivel.TFGerarDocFiscal fDoc = new PostoCombustivel.TFGerarDocFiscal())
            {
                if (fDoc.ShowDialog() == DialogResult.OK)

                    if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                    {
                        try
                        {
                            //Processar cupom fiscal
                            PDV.TDadosCupom dados = new PDV.TDadosCupom();
                            dados.lItens = rVenda.lItem;
                            dados.rSessao = lSessao[0];
                            dados.Cd_clifor = rVenda.Cd_clifor;
                            dados.Nm_clifor = rVenda.Nm_clifor;
                            dados.Cd_endereco = rVenda.Cd_endereco;
                            //Buscar CNPJ/CPF
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'"
                                                }
                                        }, "isnull(a.nr_cgc, a.nr_cpf)");
                            if (obj != null)
                                dados.CpfCgc = obj.ToString();
                            dados.Mensagem = string.Empty;
                            dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                            dados.St_vendacombustivel = false;
                            dados.St_cupomavulso = true;
                            dados.St_agruparProduto = false;
                            dados.St_pedirCliente = false;

                            CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true, true);
                            if (rNFCe != null)
                                if (!rNFCe.St_contingencia)
                                {
                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                    {
                                        rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                  rNFCe.Id_nfcestr,
                                                                                                  null);
                                        fGerNfe.rNFCe = rNFCe;
                                        fGerNfe.ShowDialog();
                                    }
                                    if (dados.St_faturardireto)
                                        if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_cupom",
                                                        vOperador = "=",
                                                        vVL_Busca = rNFCe.Id_nfcestr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.status",
                                                        vOperador = "=",
                                                        vVL_Busca = "'100'"
                                                    }
                                            }, "1") != null)
                                            ProcessarCFVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                }
                                else
                                {
                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                    Rel.Altera_Relatorio = Altera_Relatorio;
                                    BindingSource dts = new BindingSource();
                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                    Rel.DTS_Relatorio = dts;// bsItens;
                                    BindingSource bsNFCe = new BindingSource();
                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                      string.Empty,
                                                                                                      rNFCe.Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      1,
                                                                                                      null);
                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                    //Buscar Empresa
                                    BindingSource bsEmpresa = new BindingSource();
                                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        null);
                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                    //Forma Pagamento
                                    BindingSource bsPagto = new BindingSource();
                                    List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                                    new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                }
                                        }, string.Empty).GroupBy(v => v.Tp_portador,
                                                            (aux, venda) =>
                                                                new
                                                                {
                                                                    tp_portador = aux,
                                                                    Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                    Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                    Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                {
                                                                    Tp_portador = x.tp_portador,
                                                                    Vl_recebido = x.Vl_recebido,
                                                                    Vl_troco_ch = x.Vl_troco_ch,
                                                                    Vl_troco_dh = x.Vl_troco_dh
                                                                }));
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                            new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                    }
                                            }, 1, string.Empty);
                                    if (lDup.Count > 0)
                                        lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                        {
                                            Tp_portador = "05",
                                            Vl_recebido = lDup[0].Vl_documento
                                        });
                                    bsPagto.DataSource = lPagto;
                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                    //Parametros
                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", rNFCe.lItem.Sum(p => p.Vl_imposto_Aprox));
                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", rVenda.lItem.Count);
                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", rVenda.lItem.Sum(p => p.Vl_subtotal));
                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", rVenda.lItem.Sum(p => p.Vl_acrescimo));
                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", rVenda.lItem.Sum(p => p.Vl_desconto));
                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                    obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.id_lote = a.id_lote " +
                                                                            "and x.status = '100')"
                                                            }
                                                    }, "a.tp_ambiente");
                                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                    string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(rVenda.Cd_empresa,
                                                                                                                 rVenda.Id_vendarapidastr,
                                                                                                                 null);
                                    if (!string.IsNullOrEmpty(dadoscf))
                                    {
                                        string[] linhas = dadoscf.Split(new char[] { ':' });
                                        string placa = string.Empty;
                                        string km = string.Empty;
                                        string frota = string.Empty;
                                        string requisicao = string.Empty;
                                        string nm_motorista = string.Empty;
                                        string cpf_motorista = string.Empty;
                                        string media = string.Empty;
                                        string virg = string.Empty;
                                        foreach (string s in linhas)
                                        {
                                            string[] colunas = s.Split(new char[] { '/' });
                                            placa += virg + colunas[0];
                                            km += virg + colunas[1];
                                            frota += virg + colunas[2];
                                            requisicao += virg + colunas[3];
                                            nm_motorista += virg + colunas[4];
                                            cpf_motorista += virg + colunas[5];
                                            media += virg + colunas[6];
                                            virg = ",";
                                        }
                                        if (!string.IsNullOrEmpty(placa))
                                            Rel.Parametros_Relatorio.Add("PLACA", placa);
                                        if (!string.IsNullOrEmpty(km))
                                            Rel.Parametros_Relatorio.Add("KM", km);
                                        if (!string.IsNullOrEmpty(media))
                                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                        if (!string.IsNullOrEmpty(frota))
                                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                                        if (!string.IsNullOrEmpty(requisicao))
                                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                        if (!string.IsNullOrEmpty(nm_motorista))
                                            Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                        if (!string.IsNullOrEmpty(cpf_motorista))
                                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                    }
                                    Rel.Nome_Relatorio = "DANFE_NFCE";
                                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                    Rel.Modulo = "FAT";
                                    Rel.Ident = "DANFE_NFCE";
                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                    {
                                        BindingSource bsItens = new BindingSource();
                                        bsItens.DataSource =
                                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rVenda.Id_vendarapidastr,
                                                                                                      rVenda.Cd_empresa,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      null);
                                        Rel.DTS_Relatorio = bsItens;
                                    }
                                    if (rNFCe.Id_contingencia.HasValue)
                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                        else
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                    //Verificar se existe Impressora padrão para o PDV
                                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                            }, "a.impressorapadrao");
                                    string print = obj == null ? string.Empty : obj.ToString();
                                    if (string.IsNullOrEmpty(print))
                                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                        {
                                            if (fLista.ShowDialog() == DialogResult.OK)
                                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                                    print = fLista.Impressora;

                                        }
                                    //Imprimir  
                                    if (!string.IsNullOrEmpty(print))
                                    {
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                        if (rNFCe.Id_contingencia.HasValue &&
                                            rNFCe.rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                    }
                                }
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                        MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImprimirGrafico(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   1,
                                                                                                   null);
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and y.id_vendarapida = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_clifor;
                    fImp.pMensagem = "ORÇAMENTO Nº " + val.Id_vendarapidastr;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(val.Id_vendarapidastr,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "ORÇAMENTO Nº " + val.Id_vendarapidastr,
                                                fImp.pDs_mensagem);
                }
            }
            else
            {
                Relatorio.Gera_Relatorio();
                Altera_Relatorio = false;
            }
        }

        private void ImprimirGraficoReduzido(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   1,
                                                                                                   null);
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;
                }
            //Imprimir
            if (!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
                                                 1);
            Altera_Relatorio = false;
        }

        private void ProcessarCFVincular(List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lCupom,
                                       string pCd_empresa,
                                       string pCd_cliente)
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(lCupom,
                                                                                pCd_empresa,
                                                                                pCd_cliente);
                //Gravar Pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                //Se o CMI do pedido gerar financeiro
                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                lCupom.ForEach(p =>
                {
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                "inner join tb_pdv_cupom_x_vendarapida y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and y.id_cupom = " + p.Id_nfcestr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                });
                //Gerar Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                //Vincular Cupom a Nota Fiscal
                string Obs = string.Empty;
                string virg = string.Empty;
                lCupom.ForEach(p =>
                {
                    rFat.lCupom.Add(p);
                    Obs += virg + p.NR_NFCestr.Trim() + "/" + p.Placa.Trim();
                    virg = ",";
                });
                //Vincular financeiro a Nota Fiscal
                rFat.lParcAgrupar = lParcVinculado;
                if (!string.IsNullOrEmpty(Obs))
                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. Cupom Fiscal/Placa " + Obs.Trim();
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                if (MessageBox.Show("NFe gravada com sucesso. Deseja enviar a mesma para a receita?",
                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                    {
                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                        rFat.Nr_lanctofiscalstr,
                                                                                                        null);
                        fGerNfe.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
            }
        }

        private void fechacartao()
        {
            CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
            rVenda.st_restaurante = true;
            (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
            {
                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item item = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                item.Cd_produto = p.cd_produto;
                item.Quantidade = p.quantidade;
                item.Vl_unitario = p.vl_unitario;
                item.Cd_local = lcfg[0].cd_local;
                item.Vl_subtotal = p.quantidade * p.vl_unitario;
                item.id_item = Convert.ToDecimal(p.id_item);
                item.id_prevenda = Convert.ToDecimal(p.id_prevenda);
                item.Cd_condfiscal_produto = p.cd_condfiscal_produto;
                rVenda.lItem.Add(item);
            });
            rVenda.rCliente = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = lcfg[0].Cd_Clifor
                    }
                }, 1, string.Empty)[0];
            rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = lcfg[0].Cd_Clifor
                    }
                }, 1, string.Empty)[0];
            rVenda.Cd_clifor = rVenda.rCliente.Cd_clifor;
            rVenda.Cd_empresa = lcfg[0].cd_empresa;
            rVenda.Nm_clifor = rVenda.rCliente.Nm_clifor;
            rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
            rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
            object cd_end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = rVenda.Cd_clifor
                    }
                }, "a.cd_endereco");
            rVenda.Cd_endereco = cd_end != null ? cd_end.ToString() : string.Empty;

            //Verificar se cliente possui adiantamento 
            lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rVenda.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_adto, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, 0, string.Empty);

            CamadaDados.Financeiro.Cadastros.TList_CadPortador lDevolCred = new CamadaDados.Financeiro.Cadastros.TList_CadPortador();
            if (lAdiant.Count > 0)
            {
                //Buscar portador Dev Credito
                lDevolCred = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'S'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.st_cartaocredito",
                                                    vOperador = "=",
                                                    vVL_Busca = "1"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'S'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, 1, string.Empty, string.Empty);
                if (lDevolCred.Count > decimal.Zero)
                {
                    decimal tot_devolver = rVenda.Vl_devcred <
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido) ?
                        rVenda.Vl_devcred :
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                    List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                    foreach (CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rSaldo in lAdiant)
                    {
                        if (tot_devolver > decimal.Zero)
                        {
                            rSaldo.Vl_processar = rSaldo.Vl_total_devolver > tot_devolver ? tot_devolver : rSaldo.Vl_total_devolver;
                            lDev.Add(rSaldo);
                            tot_devolver -= rSaldo.Vl_processar;
                        }
                        else break;
                    }
                    //Lancar Devolução Credito
                    lDevolCred[0].lCred = lDev;
                    lDevolCred[0].Vl_pagtoPDV = rVenda.lItem.Sum(p => p.Vl_subtotalliquido) >
                                                lDev.Sum(v => v.Vl_processar) ? lDev.Sum(v => v.Vl_processar) :
                                                rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                    rVenda.lPortador = lDevolCred;
                    decimal tot_venda =
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido) - lDev.Sum(v => v.Vl_processar);
                    if (tot_venda <= decimal.Zero)
                    {
                        ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                        try
                        {

                            FecharVenda(rVenda, tEsperaDev);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        {
                            tEsperaDev.Fechar();
                            tEsperaDev = null;
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            using (PDV.TFFecharVendaPDV fFechar = new PDV.TFFecharVendaPDV())
            {
                fFechar.rCupom = rVenda;
                fFechar.pCd_empresa = rVenda.Cd_empresa;
                fFechar.pCd_clifor = rVenda.Cd_clifor;
                fFechar.pNm_clifor = rVenda.Nm_clifor;
                fFechar.rCfg = lCfg[0];
                decimal total = decimal.Zero;
                (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p => { total += p.vl_subtotal; });
                fFechar.pVl_receber = total;
                fFechar.pagar("DH", (bsPreVenda.Current as TRegistro_PreVenda).Vl_TrocoPara);
                if (fFechar.lPortador != null)
                {
                    rVenda.Cd_clifor = fFechar.pCd_clifor;
                    rVenda.Nm_clifor = fFechar.pNm_clifor;
                    rVenda.lPortador = fFechar.lPortador;
                    if (lDevolCred.Count > 0)
                        rVenda.lPortador.Add(lDevolCred[0]);
                }
                else
                {
                    MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                    return;
                }
            }
            try
            {
                FecharVenda(rVenda, null);
                //verifica para fechar cartao 
                if ((bsCartao.Current != null && bsPreVenda.Current != null))
                {
                    TList_PreVenda_Item itemcup = TCN_PreVenda_Item.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                        (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString(), string.Empty, string.Empty, null);

                    (bsCartao.Current as TRegistro_Cartao).St_registro = "F";
                    TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);

                }

                // monta lista de pedidos
                #region lista pedidos
                //cria lista da prevenda impressao
                TList_PreVenda lprevenda = new TList_PreVenda();
                (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                {
                    TRegistro_PreVenda prevenda = new TRegistro_PreVenda();
                    object obj3 = new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador= "exists",
                            vVL_Busca = "( select 1 from tb_est_produto x where x.cd_produto = "+p.cd_produto+" and x.cd_grupo = a.cd_grupo)"
                        }
                    }, "a.ds_grupo");
                    if (obj3 != null)
                        p.ds_grupo = obj3.ToString();

                    prevenda.NR_SenhaDelivery = (bsPreVenda.Current as TRegistro_PreVenda).NR_SenhaDelivery;

                    bool a = true;
                    lprevenda.ForEach(l =>
                    {
                        if (l.id_portaimp.Equals(p.id_portaimp))
                        {
                            a = false;
                        }
                    });
                    prevenda.id_portaimp = p.id_portaimp;
                    prevenda.porta_imp = p.porta_imp;
                    prevenda.NR_SenhaDelivery = (bsPreVenda.Current as TRegistro_PreVenda).NR_SenhaDelivery;
                    if (a)
                        lprevenda.Add(prevenda);


                });
                bsPreVenda.ResetCurrentItem();
                // adiciona itens no pedido
                (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                {
                    lprevenda.ForEach(o =>
                    {
                        TRegistro_PreVenda_Item prevendaitem = new TRegistro_PreVenda_Item();
                        prevendaitem = p;
                        o.ds_grupo = p.ds_grupo;
                        if (p.id_portaimp.Equals(o.id_portaimp))
                            o.lItens.Add(prevendaitem);
                    });
                });

                #endregion

                lprevenda.ForEach(p =>
                {
                    // imprimir pedido
                    FileInfo f = null;
                    StreamWriter w = null;
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + p.ds_grupo + ".txt");
                    w = f.CreateText();
                    try
                    {


                        if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery 
                            w.WriteLine("D E L I V E R Y".FormatStringEsquerda(32, ' '));
                        w.WriteLine("DATA: " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy hh:mm"));
                        w.WriteLine("CLIENTE: " + (bsCartao.Current as TRegistro_Cartao).Nm_Clifor);
                        if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                        {
                            w.WriteLine(("editDefault1: " + (bsClifor.Current as TRegistro_Clifor).celular).FormatStringDireita(52, ' '));
                            w.WriteLine(("Endereco: " + (bsClifor.Current as TRegistro_Clifor).endereco + " " + (bsClifor.Current as TRegistro_Clifor).numero).FormatStringDireita(52, ' '));
                            w.WriteLine(("Bairro: " + (bsClifor.Current as TRegistro_Clifor).bairro).FormatStringDireita(52, ' '));
                            w.WriteLine(("Proximo: " + (bsClifor.Current as TRegistro_Clifor).obs).FormatStringDireita(52, ' '));
                        }

                        w.Write("COMANDA: ".FormatStringDireita(9, ' ') + (bsCartao.Current as TRegistro_Cartao).nr_card.FormatStringEsquerda(12, ' ')
                            );
                        if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))
                            w.WriteLine("SENHA: ".FormatStringEsquerda(9, ' ') + p.NR_SenhaDelivery.FormatStringEsquerda(12, ' '));
                        else
                            w.WriteLine("");
                        w.WriteLine("------------------------------------------------");
                        w.WriteLine("Qta".FormatStringDireita(14, ' ')
                                    + "Produto".FormatStringDireita(17, ' ')
                                    + "Observacao".FormatStringEsquerda(17, ' '));
                        w.WriteLine("------------------------------------------------");
                        p.lItens.ForEach(o =>
                        {
                            w.WriteLine(o.quantidade.FormatStringDireita(14, ' ') + (o.ds_produto).FormatStringDireita(17, ' ') + o.obsItem.FormatStringEsquerda(17, ' '));
                        });
                        w.Write(Convert.ToChar(12));
                        w.Write(Convert.ToChar(27));
                        w.Flush();
                        f.CopyTo(p.porta_imp);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão pedido a cozinha: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                });
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            bsPreVenda.Clear();
            bsItensPreVenda.Clear();
            bsCartao.Clear();
        }

        private void buscaclifor()
        {
            if ((bsPreVenda.Current as TRegistro_PreVenda).lItens.Count <= 0)
            {

                using (TFConsultaClifor c = new TFConsultaClifor())
                {
                    bsClifor.Clear();
                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        if (c.rClifor != null)
                        {
                            bsClifor.Add(c.rClifor);
                            bsClifor.ResetCurrentItem();
                            buscarultimavenda();
                            //  if (bsCartao.Current != null)
                            //    (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = nm_clifor.Text;
                            txtDados.Focus();
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Deseja alterar o cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) ==
                    DialogResult.Yes)
                {
                    using (TFConsultaClifor c = new TFConsultaClifor())
                    {
                        bsClifor.Clear();
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            if (c.rClifor != null)
                            {
                                //st_cliente = true;
                                bsClifor.Add(c.rClifor);
                                bsClifor.ResetCurrentItem();
                                // nm_clifor.Text = (bsCliFor.Current as TRegistro_Clifor).Nm_clifor;
                                //  if (bsCartao.Current != null)
                                //     (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = nm_clifor.Text;
                                (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = c.rClifor.Cd_clifor;


                                (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                                {

                                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = new CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda();
                                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                                     c.rClifor.Cd_clifor,
                                                                                                                     p.cd_produto,
                                                                                                                     lcfg[0].cd_tabelapreco,
                                                                                                                     null);
                                    //p.vl_subtotal = rItemPre.vl_unitario * rItemPre.quantidade;
                                    p.vl_desconto = CalcularDescEspecial(rProg, p.cd_produto, 1, p.vl_unitario);


                                });
                                bsCartao.ResetCurrentItem();
                                bsItensPreVenda.ResetCurrentItem();

                                calculatotal();


                            }
                        }
                    }

                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados4.validarCampoObrigatorio())
                if (bsClifor.Current != null && bsCartao.Current != null)
                    if ((bsPreVenda.Current as TRegistro_PreVenda).lItens.Count > 0)
                    {
                        using (TFFecharDelivery fapont = new TFFecharDelivery())
                        {
                            fapont.rPreVenda = (bsPreVenda.Current as TRegistro_PreVenda);
                            if (fapont.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    gravarPedido();
                                    TCN_PreVenda.Gravar((bsPreVenda.Current as TRegistro_PreVenda), null);
                                    bsPreVenda.ResetCurrentItem();
                                    IMP_Cartao.Impressao_DELIVERY((bsPreVenda.Current as TRegistro_PreVenda));
                                    (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = (bsClifor.Current as TRegistro_Clifor).Nm_clifor;
                                    IMP_Cartao.Impressao_PEDIDOS((bsPreVenda.Current as TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao));

                                    this.DialogResult = DialogResult.OK;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                IMP_Cartao.ReImpressao_PEDIDOS((bsClifor.Current as TRegistro_Clifor), (bsPreVenda.Current as TRegistro_PreVenda));
                                if (MessageBox.Show("Deseja imprimir o delivery na cozinha?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    IMP_Cartao.Impressao_PEDIDOS((bsPreVenda.Current as TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao));
                            }
                        }
                    }
        }

        private void editMask1_Leave(object sender, EventArgs e)
        {
            if (!editDefault1.Text.SoNumero().Trim().Equals(""))
            {
                TpBusca[] filtro = new TpBusca[0];

                if (!string.IsNullOrEmpty(editDefault1.Text.SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.celular";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'%" + editDefault1.Text.SoNumero() + "%'";
                }
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "A.ST_REGISTRO";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'A'";

                TList_Clifor lClifor = new TCD_Clifor().Select(filtro, 0, string.Empty);
                if (lClifor.Count == 1)
                    bsClifor.DataSource = lClifor;
                else
                    using (TFConsultaClifor fClifor = new TFConsultaClifor())
                    {
                        fClifor.nome = editDefault1.Text.SoNumero();
                        if (fClifor.ShowDialog() == DialogResult.OK)
                            if (fClifor.rClifor != null)
                                bsClifor.DataSource = new TList_Clifor() { fClifor.rClifor };
                    }
                bsClifor.ResetCurrentItem();
                if (bsClifor.Count.Equals(0))
                {
                    buscarultimavenda();
                    editDefault5.Focus();
                }
                else
                {
                    buscarultimavenda();
                    txtDados.Focus();
                }
            }
            else
            {
                string nr = editDefault1.Text;
                if (!string.IsNullOrEmpty(nr))
                {
                    (bsClifor.Current as TRegistro_Clifor).celular = nr;
                }
            }
        }

        private void bsCartao_PositionChanged(object sender, EventArgs e)
        {
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void FDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                if (panelDados4.validarCampoObrigatorio())
                    txtDados.Focus();
            }
            else
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            else
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
            else
            if (e.KeyCode.Equals(Keys.F5))
                buscaclifor();
        }

        private void calculatotal()
        {
            decimal total = decimal.Zero;
            decimal desconto = decimal.Zero;
            (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
            {
                total += p.vl_subtotal;
                desconto += p.vl_desconto * p.quantidade;
            });
            lbldesconto.Text = desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            VLsubtotal.Text = total.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            lblTotal.Text = (total - desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void excluir()
        {
            if (bsItensPreVenda.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (alterando)
                    {
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_removido = true;
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_registro = "C";
                        TCN_PreVenda_Item.Gravar((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);

                        TList_SaboresItens _SaboresItens = new TList_SaboresItens();
                        _SaboresItens = new TCD_SaboresItens().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_item",
                                    vOperador = "=",
                                    vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString()
                                }
                            }, 0, string.Empty);
                        _SaboresItens.ForEach(s =>
                        {
                            TCN_SaboresItens.Excluir(s, null);
                        });

                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itempaiadic",
                                    vOperador = "=",
                                    vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda.ToString()
                                }
                            }, 0, string.Empty);
                        adicionais.ForEach(ad =>
                        {
                            ad.st_registro = "C";
                            TCN_PreVenda_Item.Gravar(ad, null);
                        });
                    }

                    bsItensPreVenda.RemoveCurrent();
                    bsCartao.ResetCurrentItem();
                    calculatotal();
                }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            excluir();
            txtDados.Focus();
        }

        private void bsPreVendaUltimo_PositionChanged(object sender, EventArgs e)
        {
            if (bsPreVendaUltimo.Current != null)
            {
                (bsPreVendaUltimo.Current as TRegistro_PreVenda).lItens = TCN_PreVenda_Item.Buscar(
                    (bsPreVendaUltimo.Current as TRegistro_PreVenda).Cd_empresa,
                    (bsPreVendaUltimo.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                    string.Empty, string.Empty, null);
                bsPreVendaUltimo.ResetCurrentItem();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void bb_cancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void editDefault1_TextChanged(object sender, EventArgs e)
        {
            if (editDefault1.Text.SoNumero().Length.Equals(10))
            {
                editDefault1.Text = "(" + editDefault1.Text.SoNumero().Substring(0, 2) + ")" + editDefault1.Text.SoNumero().Substring(2, 4) + "-" + editDefault1.Text.SoNumero().Substring(6, 4);
                editDefault1.SelectionStart = editDefault1.Text.Length;
            }
            else if (editDefault1.Text.SoNumero().Length.Equals(11))
                if (editDefault1.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    editDefault1.Text = "(" + editDefault1.Text.SoNumero().Substring(0, 3) + ")" + editDefault1.Text.SoNumero().Substring(3, 4) + "-" + editDefault1.Text.SoNumero().Substring(7, 4);
                    editDefault1.SelectionStart = editDefault1.Text.Length;
                }
                else
                {
                    editDefault1.Text = "(" + editDefault1.Text.SoNumero().Substring(0, 2) + ")" + editDefault1.Text.SoNumero().Substring(2, 5) + "-" + editDefault1.Text.SoNumero().Substring(7, 4);
                    editDefault1.SelectionStart = editDefault1.Text.Length;
                }
            else if (editDefault1.Text.SoNumero().Length.Equals(12))
            {
                editDefault1.Text = "(" + editDefault1.Text.SoNumero().Substring(0, 3) + ")" + editDefault1.Text.SoNumero().Substring(3, 5) + "-" + editDefault1.Text.SoNumero().Substring(8, 4);
                editDefault1.SelectionStart = editDefault1.Text.Length;
            }
        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && bsPreVendaItemUltimo.Current != null)
            {
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Casas_decimais = 0;
                    fQtde.Ds_label = "Quantidade";
                    fQtde.Vl_default = (bsPreVendaItemUltimo.Current as TRegistro_PreVenda_Item).quantidade;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        txtDados.Text = (bsPreVendaItemUltimo.Current as TRegistro_PreVenda_Item).cd_produto;
                        txtDados_KeyDown(this, new KeyEventArgs(Keys.Enter));
                        lblQuantidade.Text = fQtde.Quantidade.ToString();
                        lblQuantidade_Leave(this, new EventArgs());
                        MessageBox.Show("Item Incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsItensPreVenda.Current != null)
            {
                InputBox inputBox = new InputBox();
                inputBox.Text = "Obs: " + (bsItensPreVenda.Current as TRegistro_PreVenda_Item).ds_produto.Trim();
                string retorno = inputBox.Show((bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem);
                if (!string.IsNullOrEmpty(retorno))
                {
                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem = retorno;
                    //TCN_PreVenda_Item.Gravar((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                    bsItensPreVenda.ResetCurrentItem();
                }
            }
        }

        private void barraMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bsItensPreVenda_PositionChanged(object sender, EventArgs e)
        {
            //if (bsItensPreVenda.Current != null)
            //{
            //    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).lSabores =
            //        TCN_SaboresItens.Buscar(
            //            (bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa,
            //            (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
            //            (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString(), string.Empty, null);

            //    bsItensPreVenda.ResetCurrentItem();

            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            altera_qtd();
        }

        private void lblQuantidade_Leave(object sender, EventArgs e)
        {
            carregarproduto();
            txtDados.Text = string.Empty;
            txtDados.Focus();
            lblQuantidade.Text = "1,00";
        }

        private void editDefault1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                editMask1_Leave(this, new EventArgs());
        }

    }
}
