using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using System.IO;
using CamadaDados.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaNegocio.Restaurante;
using Restaurante.Impressao;
using CamadaDados.Faturamento.PDV;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.ProgEspecialVenda;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Restaurante.Integracao.Torneiras;
using CamadaDados.Estoque.Cadastros;

namespace Restaurante
{
    public partial class TFLanPreVenda : Form
    {
        private string cd_clifor_fidelidade = string.Empty;
        private string nome = string.Empty;
        public string id_pdv = string.Empty;
        public string LoginPdv
        { get; set; }
        private string nrcartao = string.Empty;
        public string vCd_Tabela { get; set; } = string.Empty;

        private decimal lvunitario = decimal.Zero;

        private bool Altera_Relatorio = false;
        private bool st_gravar { get; set; } = false;
        private bool st_cliente { get; set; } = false;

        public TRegistro_CadProtocolo rProtocolo
        { get; set; }
        private TRegistro_Cartao cCartao;
        public TRegistro_Cartao rCartao
        {
            get { return bsCartao.Current as TRegistro_Cartao; }
            set { cCartao = value; }
        }
        private TRegistro_CaixaPDV rCaixa
        { get; set; }
        private List<TRegistro_LanAdiantamento> lAdiant
        { get; set; }
        private TList_Sessao lSessao
        { get; set; }
        private TList_CFGCupomFiscal lCfg
        { get; set; }
        private TList_PontoVenda lPdv
        { get; set; }
        private TList_CFG lcfg
        { get; set; }
        private TRegistro_ProgEspecialVenda rProg;
        private List<TRegistro_Adicionais> lAdicionais;
        private List<TRegistro_PreVenda_Item> lAux = new List<TRegistro_PreVenda_Item>();
        private bool pedirParaImprimirExtrato = false;

        public TFLanPreVenda()
        {
            InitializeComponent();
        }

        #region Métodos

        private void carregarmesas()
        {
            if ((lcfg[0].Tp_cartao.Equals("0") && !lcfg[0].bool_mesacartao) || lcfg[0].Tp_cartao.Equals("2"))
                return;

            TList_Local local_mesa = new TList_Local();
            local_mesa = TCN_Local.Buscar(string.Empty, string.Empty, string.Empty, null);
            local_mesa.ForEach(pi =>
            {
                pi.lMesa = TCN_Mesa.Buscar(string.Empty, string.Empty, string.Empty, null);
            });

            mesas_tab.TabPages.Clear();

            //adiciona locais na tabcontrol de locais
            local_mesa.ForEach(pi =>
            {
                TabPage tab = new TabPage();
                tab.Text = pi.Ds_Local;
                tab.Name = pi.Id_Local.ToString();
                FlowLayoutPanel flow = new FlowLayoutPanel();
                flow.Dock = DockStyle.Fill;

                if (pi.lMesa.Count > 0)
                {
                    Componentes.ListPanel[] lPanel = new Componentes.ListPanel[pi.lMesa.Count];
                    flow.Controls.Clear();
                    for (int i = 0; pi.lMesa.Count > i; i++)
                    {
                        if (pi.Id_Local.Equals(pi.lMesa[i].Id_Local))
                        {
                            lPanel[i] = new Componentes.ListPanel();
                            flow.Controls.Add(lPanel[i]);
                            lPanel[i].Location = new System.Drawing.Point(3, 3);
                            lPanel[i].Name = lcfg[0].Tp_cartao.Equals("1") ? pi.lMesa[i].Id_Mesa.ToString() + "-" + pi.lMesa[i].ds_local.ToString() : pi.lMesa[i].nr_cartao.ToString() + "-" + pi.lMesa[i].ds_local.ToString();
                            //  comboBoxDefault1.Text = pi.lMesa[i].ds_local.ToString();
                            lPanel[i].Size = new System.Drawing.Size(25, 15);
                            lPanel[i].TabIndex = 0;
                            lPanel[i].NM_Campo = pi.lMesa[i].Nr_Mesa;
                            if (pi.lMesa[i].id_cartao == decimal.Zero)
                                lPanel[i].BackColor = Color.GreenYellow;
                            else
                                lPanel[i].BackColor = Color.Red;
                            lPanel[i].Tag = pi.lMesa[i].id_cartao;

                            lPanel[i].BorderStyle = BorderStyle.FixedSingle;
                            lPanel[i].Click += new EventHandler(this.Mesa_Click);
                        }
                    }
                }
                //else
                //    tlpColunas.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
                tab.Controls.Add(flow);
                mesas_tab.TabPages.Add(tab);
            });
        }

        private void afterNovo()
        {
            lAux.Clear();

            if (!lcfg[0].Tp_cartao.Equals("2"))
                if (bsCartao.Current != null)
                    if ((bsCartao.Current as TRegistro_Cartao).lPreVenda.Count > 0)
                    {
                        //Itens de integração são gravados apenas no fechamento da venda
                        (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.RemoveAll(i => i.tapTransactions != null);

                        if (lcfg[0].Tp_cartao.Equals("0"))
                        {
                            if (lcfg[0].bool_mesacartao)
                            {
                                using (FTrocaMesa aew = new FTrocaMesa())
                                {
                                    aew.seleciona_mesa = false;
                                    aew.id_cartao = (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString();
                                    DialogResult ae = aew.ShowDialog();
                                    if (ae == DialogResult.OK || ae == DialogResult.Abort)
                                    {
                                        (bsCartao.Current as TRegistro_Cartao).Id_mesa = aew.id_mesa;
                                        (bsCartao.Current as TRegistro_Cartao).nr_mesa = aew.Nr_mesa;
                                        (bsCartao.Current as TRegistro_Cartao).id_local = aew.id_local;
                                        bsCartao.ResetCurrentItem();
                                    }
                                    else
                                    {
                                        if ((bsCartao.Current as TRegistro_Cartao).lPreVenda[0]
                                            .lItens
                                                .Exists(r =>
                                                    !string.IsNullOrEmpty(r.porta_imp)
                                                        && !r.St_impressobool)
                                                            && lcfg[0].ST_ObrigarMesaProdPed)
                                        {
                                            MessageBox.Show("Na configuração do restaurante está selecionado a opção de obrigar informar mesa no fechamento, não será possível finalizar o processo do pedido.",
                                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                            }
                            IMP_Cartao.Impressao_ITENSPORPORTA((bsCliFor.Current as TRegistro_Clifor),
                                                               (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens,
                                                               (bsCartao.Current as TRegistro_Cartao));

                        }
                        else
                        {
                            IMP_Cartao.Impressao_PEDIDOS((bsCartao.Current as TRegistro_Cartao).lPreVenda[0],
                                                         (bsCartao.Current as TRegistro_Cartao),
                                                         true);
                        }

                        TCN_Cartao.Gravar(((bsCartao.Current as TRegistro_Cartao)), null);
                    }

            bsCartao.Clear();
            cd_clifor_fidelidade = string.Empty;

            bsCliFor.Clear();
            nm_clifor.Text = string.Empty;
            nr_cartao.Text = string.Empty;
            txtDados.Text = string.Empty;
            nrcartao = string.Empty;
            nome = string.Empty;
            lblQuantidade.Text = "1,00";
            st_cliente = false;
            lblTotalLiquidoCupom.Text = string.Empty;
            lbltroco.Text = string.Empty;
            lblvalorpago.Text = string.Empty;
            VLsubtotal.Text = string.Empty;
            lbldesconto.Text = string.Empty;
            carregarmesas();
            if (lcfg[0].Tp_cartao.Equals("2"))
                txtDados.Focus();
            else
                nr_cartao.Select();
        }

        private void excluir()
        {
            if (bsItensPreVenda.Current != null)
            {
                if (!lAux.Exists(p => p.cd_produto.Equals((bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto)))
                {
                    //Validar usuário para operação
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR ITEM CANCELAR VENDA", null))
                    {
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Login = Utils.Parametros.pubLogin;
                            fRegra.Ds_regraespecial = "PERMITIR EXCLUIR ITEM CANCELAR VENDA";
                            if (fRegra.ShowDialog() == DialogResult.Cancel)
                            {
                                MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                //Utilizado para gravar usuário informado no login de cancelamento do item
                                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).LoginCanc = fRegra.LoginInformado;
                            }
                        }
                    }

                    //Caso o usuário correte tenha permissão para excluir item, adicionar login ao item corrente
                    else
                    {
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).LoginCanc = Utils.Parametros.pubLogin;
                    }
                }

                //Ticket 8085 solicitado retirada
                //Validar se item corrente é boliche
                //if (!(bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_produto && TCN_CFG.Buscar((bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horaboliche) && (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horaboliche)))
                //{
                //    MessageBox.Show("O item selecionado é referente a uma movimentação de pista boliche. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                ////Validar se item corrente é sinuca
                //if (!(bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_produto && TCN_CFG.Buscar((bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horasinuca) && (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horasinuca)))
                //{
                //    MessageBox.Show("O item selecionado é referente a uma movimentação de sinuca. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}


                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
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
                        ad.LoginCanc = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).LoginCanc;
                        TCN_PreVenda_Item.ExcluirC(ad, null);
                        ad.st_agregar = true;
                        ad.st_removido = true;
                    });

                    //Exclusão dos sabores da pré-venda
                    TList_SaboresItens lista = new TList_SaboresItens();
                    lista = TCN_SaboresItens.Buscar((bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa, (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString(), string.Empty, null);
                    lista.ForEach(ad =>
                    {
                        TCN_SaboresItens.Excluir(ad, null);
                    });


                    string id_item = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString();
                    string cd_Prod = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto.ToString();
                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_removido = true;

                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).st_registro = "C";
                    (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lDelItens.Add(bsItensPreVenda.Current as TRegistro_PreVenda_Item);
                    TCN_PreVenda_Item.ExcluirC(bsItensPreVenda.Current as TRegistro_PreVenda_Item, null);
                    bsItensPreVenda.RemoveCurrent();
                    calculatotal();
                }
            }

        }

        private void calculatotal()
        {
            if (bsPreVenda.Current == null)
            {
                lblTotalLiquidoCupom.Text = string.Empty;
                VLsubtotal.Text = string.Empty;
                lbldesconto.Text = string.Empty;
                lbltroco.Text = string.Empty;
                lblvalorpago.Text = string.Empty;
                return;
            }

            CamadaDados.Estoque.Cadastros.TList_CadUnidade uni = new CamadaDados.Estoque.Cadastros.TList_CadUnidade();
            TpBusca[] filtro = new TpBusca[0];
            string st = string.Empty;
            int i = 0;
            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
            {
                st += "( exists (SELECT 1 FROM TB_EST_PRODUTO X WHERE X.CD_UNIDADE = A.CD_UNIDADE AND X.CD_PRODUTO = " + p.cd_produto + ") )";
                if (i < (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Count - 1)
                    st += "or";
                i++;
            });
            decimal total = decimal.Zero;
            decimal valor = decimal.Zero;
            decimal desconto = decimal.Zero;
            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
            {
                total += p.vl_liquido;
                valor += p.vl_subtotal;
                desconto += p.vl_desconto;
            });
            uni = new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(filtro, 1, string.Empty, "a.casasdecimais");
            lblTotalLiquidoCupom.Text = total.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
            VLsubtotal.Text = valor.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
            lbldesconto.Text = desconto.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
            lbltroco.Text = string.Empty;
            lblvalorpago.Text = string.Empty;
        }

        private void novoproduto()
        {
            txtDados.Focus();
            txtDados.Text = string.Empty;
            lblQuantidade.Text = "1,00";
            if (bsCartao.Current != null)
            {
                if (!string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).nr_fastfoodStr))
                {
                    nr_cartao.Text = (bsCartao.Current as TRegistro_Cartao).nr_fastfoodStr;
                    na_cartao.Text = "N° Senha";
                }
                else
                    nr_cartao.Text = !string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString()) ? (bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString() : nr_cartao.Text;

                nrcartao = !string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString()) ? (bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString() : nr_cartao.Text;
            }
        }

        private void novocartao()
        {
            using (Cadastro.FCadCartao cartao = new Cadastro.FCadCartao())
            {
                cartao.vCd_Empresa = lcfg[0].cd_empresa;
                if (cartao.ShowDialog() == DialogResult.OK)
                {
                    cartao.rCartao.St_registro = "F";
                    TCN_Cartao.Gravar(cartao.rCartao, null);
                    afterNovo();
                    if (!string.IsNullOrEmpty(cartao.rCartao.nr_fastfoodStr))
                    {
                        nr_cartao.Text = cartao.rCartao.nr_fastfoodStr;
                        na_cartao.Text = "N° Senha";
                    }
                    else
                        nr_cartao.Text = cartao.rCartao.nr_cartao;
                    nrcartao = ((bsCartao.Current as TRegistro_Cartao).nr_cartao + 1).ToString();
                    procura_cartao();

                }


            }

        }

        private void consultaproduto()
        {
            FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                            lcfg[0].cd_empresa,//cd_empresa
                                                            string.Empty,
                                                            lcfg[0].cd_tabelapreco,//cd-tbpreco
                                                            new Componentes.EditDefault[] { },
                                                            null);
        }

        private void fechacartao()
        {
            if (bsCartao.Current == null)
            {
                MessageBox.Show("Para realizar o fechamento da venda é necessário informar o número do cartão.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (string.IsNullOrEmpty(nr_cartao.Text)) nr_cartao.Focus();
                return;
            }

            //Validar usuário para operação
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FECHAR VENDA", null))
            {
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Login = Utils.Parametros.pubLogin;
                    fRegra.Ds_regraespecial = "PERMITIR FECHAR VENDA";
                    if (fRegra.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //Validar existencia de serviço em aberto para cartao
            if (TCN_MovBoliche.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                      (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString().Trim(),
                                      null,
                                      null,
                                      null,
                                      null,
                                      null).Exists(p => p.Dt_fechamento == null))
            {
                MessageBox.Show("O cartão informado consta com movimentação em aberto. Será necessário efetuar o fechamento da movimentação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bsItensPreVenda.Current == null)
            {
                //Fechar cartão sem itens
                (bsCartao.Current as TRegistro_Cartao).St_registro = "F";
                TCN_Cartao.Gravar(bsCartao.Current as TRegistro_Cartao, null);
                MessageBox.Show("Cartão informado não possui itens, fechado automaticamente.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_cartao.Clear();
                nr_cartao.Focus();
                carregarmesas();
                return;
            }

            //Grava-se itens integrados
            ///summarry
            ///colocado pois o modelo não preve um item integrado
            ///necessário gravar novamente para obter indices e gerar venda rapida para itens
            ///nas buscas por cartao (quando é informado) poderia-se já ter o mesmo na listagem
            ///devido a isso apenas é gravado neste ponto
            ///nos pontos demais é retirado da listagem de itens da prevenda
            if ((bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.FindAll(c => c.tapTransactions != null).Count > 0)
            {
                (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.ForEach(p =>
                {
                    p.id_cartao = (bsCartao.Current as TRegistro_Cartao).id_cartao;
                    p.id_prevenda = (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].id_prevenda;
                    TCN_PreVenda_Item.Gravar(p, null);
                });

                #region Update Integracao Torneiras
                (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda)
                    .lItens.Where(p => p.tapTransactions != null)
                    .ToList().ForEach(p =>
                {
                    try
                    {
                        new ServiceRest.TCD_TapTransactions().Update(p.tapTransactions, lcfg[0].PathBdTorneira);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                });
                #endregion

                //Buscar itens da prevenda
                (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(p =>
                {
                    p.lItens = TCN_PreVenda_Item.Buscar(
                    p.Cd_empresa,
                    p.id_prevenda.ToString(),
                    string.Empty, string.Empty, null);
                    p.lItens.ForEach(u =>
                    {
                        u.lSabores = TCN_SaboresItens.Buscar(u.Cd_empresa, u.id_prevenda.ToString(), u.id_item.ToString(), string.Empty, null);
                    });
                });
            }

            TRegistro_VendaRapida rVenda = new TRegistro_VendaRapida();
            rVenda.st_restaurante = true;
            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
            {
                TRegistro_VendaRapida_Item item = new TRegistro_VendaRapida_Item();
                item.Cd_produto = p.cd_produto;
                item.Quantidade = p.quantidade;
                item.Vl_unitario = p.vl_unitario;
                item.Vl_desconto = p.vl_desconto * p.quantidade;
                item.Cd_local = lcfg[0].cd_local;
                item.Vl_subtotal = p.quantidade * (p.vl_unitario);
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
                        vVL_Busca = "'" + (bsCartao.Current as TRegistro_Cartao).Cd_Clifor.Trim() + "'"
                    }
                }, 1, string.Empty)[0];
            rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsCartao.Current as TRegistro_Cartao).Cd_Clifor.Trim() + "'"
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
            lAdiant = new TCD_LanAdiantamento().Select(
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
                lDevolCred =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
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
                    decimal tot_devolver = rVenda.Vl_devcred < rVenda.lItem.Sum(p => p.Vl_subtotalliquido)
                        ? rVenda.Vl_devcred : rVenda.lItem.Sum(p => p.Vl_subtotalliquido);

                    List<TRegistro_LanAdiantamento> lDev = new List<TRegistro_LanAdiantamento>();
                    foreach (TRegistro_LanAdiantamento rSaldo in lAdiant)
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
                    lDevolCred[0].Vl_pagtoPDV = rVenda.lItem.Sum(p => p.Vl_subtotalliquido) > lDev.Sum(v => v.Vl_processar)
                                                ? lDev.Sum(v => v.Vl_processar)
                                                : rVenda.lItem.Sum(p => p.Vl_subtotalliquido);

                    rVenda.lPortador = lDevolCred;
                    decimal tot_venda =
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido) - lDev.Sum(v => v.Vl_processar);
                    if (tot_venda <= decimal.Zero)
                    {
                        ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                        try
                        {
                            this.FecharVenda(rVenda, tEsperaDev);
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
                    MessageBox.Show("Não existe portador DEVOLUÇÃO DE CRÉDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            using (PDV.TFFecharVendaPDV fFechar = new PDV.TFFecharVendaPDV())
            {
                fFechar.rCupom = rVenda;
                fFechar.pCd_empresa = rVenda.Cd_empresa;
                fFechar.pCd_clifor = rVenda.Cd_clifor;
                fFechar.pNm_clifor = rVenda.Nm_clifor;

                //Informar usuário que cliente possui adiantamento
                if (lDevolCred.Count > 0)
                {
                    MessageBox.Show("O cliente possui saldo devolução de crédito!\n"
                            + "Cliente de código: " + fFechar.pCd_clifor + "\n"
                            + "Nome: " + fFechar.pNm_clifor, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Buscar Vendedor
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_vendedor, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_funcativo, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.loginvendedor",
                            vOperador = "=",
                            vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                        }
                    }, "a.cd_clifor");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    fFechar.pCd_vendedor = obj.ToString();

                fFechar.rCfg = lCfg[0];
                fFechar.pVl_receber = decimal.Parse(lblTotalLiquidoCupom.Text) - rVenda.Vl_devcred;
                fFechar.pVl_desconto = decimal.Parse(lbldesconto.Text);
                if (fFechar.ShowDialog() == DialogResult.OK)
                {
                    //Validar existencia de pista boliche em aberto para cartão informado
                    if (!string.IsNullOrEmpty(lcfg[0].Cd_horaboliche))
                        if (TCN_MovBoliche.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                  (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(),
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  null).Exists(p => string.IsNullOrEmpty(p.Id_PreVenda.ToString())))
                        {
                            MessageBox.Show("Não será possível fechar a venda, pois o cartão possui movimentação de pista boliche em aberto.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    if (fFechar.lPortador != null)
                    {
                        rVenda.Cd_clifor = fFechar.pCd_clifor;
                        rVenda.Nm_clifor = fFechar.pNm_clifor;
                        rVenda.lPortador = fFechar.lPortador;
                        if (lDevolCred.Count > 0)
                            rVenda.lPortador.Add(lDevolCred[0]);
                        if (decimal.Parse(lbldesconto.Text) <= decimal.Zero)
                        {
                            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
                            {
                                p.vl_desconto = decimal.Divide(decimal.Multiply(fFechar.pPc_Desconto, decimal.Multiply(p.quantidade, p.vl_unitario)), 100);

                            });
                            rVenda.lItem.ForEach(p =>
                            {
                                p.Vl_desconto = decimal.Divide(decimal.Multiply(fFechar.pPc_Desconto, decimal.Multiply(p.Quantidade, p.Vl_unitario)), 100);
                                p.Pc_desconto = fFechar.pPc_Desconto;
                            });
                        }
                        try
                        {
                            lbltroco.Text = rVenda.lPortador.Sum(p => p.Vl_trocoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            lblvalorpago.Text = rVenda.lPortador.Sum(p => p.Vl_pagtoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            this.FecharVenda(rVenda, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                        return;
                    }
                }
                else
                {
                    //Para cancelamento de operação com saldo valor pago
                    decimal vl_pago = fFechar.lPortador.Sum(p => p.Vl_pagtoPDV);
                    if (vl_pago > 0)
                    {
                        MessageBox.Show("Foi selecionado a operação de cancelar com saldo de valor pago, será gerado um adiantamento para o cliente corrente.\n"
                            + "Cliente de código: " + fFechar.pCd_clifor + "\n"
                            + "Nome: " + fFechar.pNm_clifor, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Buscar conta gerencial para usuário
                        object CdContagerQt = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "",
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x where x.cd_contager = a.cd_contager and x.login = '" + Utils.Parametros.pubLogin.Trim() +"')"
                                        }
                                    }, "a.cd_contager");

                        if (CdContagerQt == null || string.IsNullOrEmpty(CdContagerQt.ToString()))
                        {
                            MessageBox.Show("Não exite conta gerencial autorizada para usuário de sistema. Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(
                            new TRegistro_LanAdiantamento()
                            {
                                Cd_empresa = fFechar.pCd_empresa,
                                Cd_clifor = fFechar.pCd_clifor,
                                CD_Endereco = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = fFechar.pCd_clifor } }, "a.cd_endereco").ToString(),
                                Ds_adto = "Adiantamento recebido no cancelamento da operação fechar venda. Módulo restaurante/ pré-venda",
                                Tp_movimento = "R",
                                Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                Vl_adto = vl_pago,
                                ST_ADTO = "A",
                                TP_Lancto = "F",
                                Cd_contager_qt = CdContagerQt.ToString()
                            }, null);
                    }
                }
            }

            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
            {
                p.lSabores = TCN_SaboresItens.Buscar(p.Cd_empresa, p.id_prevenda.ToString(), p.id_item.ToString(), string.Empty, null);
            });

            if (lcfg[0].Tp_cartao.Equals("0"))
            {
                if (lcfg[0].st_imprimirextratoposvenda &&
                    pedirParaImprimirExtrato &&
                    MessageBox.Show("Deseja imprimir o extrato da venda?",
                        "Pergunta",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
                {
                    //Via cliente
                    IMP_Cartao.Impressao_FASTFOOD((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao), id_pdv);
                    //IMP_Cartao.Impressao_PEDIDOS((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao));
                    //Via local porta
                    //IMP_Cartao.ReImpressao_PEDIDOS((bsCliFor.Current as TRegistro_Clifor), bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda, (bsCartao.Current as TRegistro_Cartao));
                }
            }
            else
            {
                if (lcfg[0].st_imprimirextratoposvenda)
                {
                    //Via cliente
                    IMP_Cartao.Impressao_PEDIDOS((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao));
                    //Via local porta fast food
                    IMP_Cartao.Impressao_FASTFOOD((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao), id_pdv);
                }
            }
            try
            {
                if (lcfg[0].st_mantercartaoaberto)
                {
                    if (bsCartao.Current != null && MessageBox.Show("Deseja reabrir o cartão?",
                                                                    "Pergunta",
                                                                    MessageBoxButtons.YesNo,
                                                                    MessageBoxIcon.Question,
                                                                    MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
                    {
                        TRegistro_Cartao rcartao = new TRegistro_Cartao();
                        rcartao.nr_cartao = (bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString().Trim().SoNumero();
                        rcartao.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                        rcartao.St_registro = "A";
                        rcartao.vl_limitecartao = decimal.Zero;
                        rcartao.st_menor = false;
                        rcartao.Cd_empresa = lcfg[0].cd_empresa;
                        rcartao.Cd_Clifor = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor;
                        CamadaDados.Restaurante.TRegistro_PreVenda pre = new CamadaDados.Restaurante.TRegistro_PreVenda();
                        pre.Dt_venda = CamadaDados.UtilData.Data_Servidor();
                        rcartao.lPreVenda.Add(pre);
                        TCN_Cartao.Gravar(rcartao, null);
                    }
                }
            }
            finally
            {
                lblTotalLiquidoCupom.Text = string.Empty;
                nr_cartao.Text = string.Empty;
                bsPreVenda.Clear();
                bsItensPreVenda.Clear();
                bsCartao.Clear();
                nm_clifor.Text = string.Empty;
                bsCliFor.Clear();
                nrcartao = string.Empty;

                if (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao)
                    carregarmesas();

                nr_cartao.Select();
            }
        }

        private void FecharVenda(TRegistro_VendaRapida rVenda, ThreadEspera tEspera)
        {
            //Gravar Cartão
            TCN_Cartao.FecharCartao(bsCartao.Current as TRegistro_Cartao,
                                    rVenda,
                                    tEspera,
                                    null);

            //Busca cupom gravado
            TList_VendaRapida lCupom = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
                                                                                            rVenda.Cd_empresa,
                                                                                            string.Empty,
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
                                                                                            0,
                                                                                            null);

            lCupom.ForEach(p => p.lItem = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                                                                    p.Cd_empresa,
                                                                                                    false,
                                                                                                    string.Empty,
                                                                                                    null));

            bsCartao.ResetCurrentItem();

            lCupom[0].lPortador = rVenda.lPortador;

            TList_LanAdiantamento lCredito =
                new TCD_LanAdiantamento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                    "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                    }
                }, 0, string.Empty);

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
              new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                     new TpBusca[]
                                     {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                     }, 1, string.Empty);

            //Imprimir comprovante de credito 
            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
            {

                if (lCredito.Count > 0)
                {
                    FileInfo f = null;
                    StreamWriter w = null;
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Credito.txt");
                    w = f.AppendText();
                    try
                    {
                        w.WriteLine(" =========================================");
                        w.WriteLine("            COMPROVANTE CREDITO           ");
                        w.WriteLine(" =========================================");
                        w.WriteLine("NR. Venda Origem: ".FormatStringDireita(32, ' ') + lCupom[0].Id_vendarapidastr.FormatStringEsquerda(10, '0'));
                        lCredito.ForEach(p =>
                        {
                            w.WriteLine("NR. Credito: ".FormatStringDireita(32, ' ') + p.Id_adto.ToString().FormatStringEsquerda(10, '0'));
                            w.WriteLine("Data: ".FormatStringDireita(32, ' ') + p.Dt_lanctostring);
                            w.WriteLine("Valor: ".FormatStringEsquerda(32, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            //Imprimir observacao cupom
                            if (!string.IsNullOrEmpty(p.Ds_adto))
                            {
                                string obs = p.Ds_adto.Trim();
                                w.WriteLine("Observacoes".FormatStringDireita(42, '-'));
                                while (true)
                                {
                                    if (obs.Length <= 40)
                                    {
                                        w.WriteLine("  " + obs);
                                        break;
                                    }
                                    else
                                    {
                                        w.WriteLine("  " + obs.Substring(0, 40));
                                        obs = obs.Remove(0, 40);
                                    }
                                }
                            }
                            w.WriteLine();
                        });
                        w.Write(Convert.ToChar(12));
                        w.Write(Convert.ToChar(27));
                        w.Write(Convert.ToChar(109));
                        w.Flush();
                        f.CopyTo(lTerminal[0].Porta_imptick);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão comprovante credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                }
            }
            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
            {
                if (lCredito.Count > 0)
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.NM_Classe = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Altera_Relatorio = this.Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    BindingSource BinCredito = new BindingSource();
                    BinCredito.DataSource = lCredito;
                    Relatorio.Adiciona_DataSource("CREDITO", BinCredito);

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lCupom[0];
                    Relatorio.DTS_Relatorio = meu_bind;


                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "Comprovante de Crédito";
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(string.Empty,
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        "Comprovante de Crédito",
                                                        fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }
                }
            }
            if (lCupom[0].lPortador.Exists(p => p.lDup.Count > 0))
            {
                //Imprimir Boleto
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + lCupom[0].Id_vendarapidastr+ ")"
                        }
                    }, 0, string.Empty);
                if (lBloqueto.Count > 0)
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                        fImp.pMensagem = "BOLETO(S) VENDA RAPIDA Nº" + lCupom[0].Id_vendarapidastr;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                              lBloqueto,
                                                                              fImp.pSt_imprimir,
                                                                              fImp.pSt_visualizar,
                                                                              fImp.pSt_enviaremail,
                                                                              fImp.pSt_exportPdf,
                                                                              fImp.Path_exportPdf,
                                                                              fImp.pDestinatarios,
                                                                              "BOLETO(S) VENDA RAPIDA Nº " + lCupom[0].Id_vendarapidastr,
                                                                              fImp.pDs_mensagem,
                                                                              false);
                    }
                else
                {
                    //Se gerou duplicata imprimir confissão divida
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                            "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                            }
                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                    if (lParc.Count > 0)
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource bs = new BindingSource();
                        bs.DataSource = new TList_VendaRapida() { lCupom[0] };
                        Rel.DTS_Relatorio = bs;
                        //DTS Cupom
                        BindingSource dts = new BindingSource();
                        dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(lCupom[0].Id_vendarapidastr,
                                                                                                   lCupom[0].Cd_empresa,
                                                                                                   false,
                                                                                                   string.Empty,
                                                                                                   null);
                        Rel.Adiciona_DataSource("DTS_ITENS", dts);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        //Buscar Cliente Duplicata
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(lParc[0].Cd_clifor, null);
                        //Buscar Endereco Duplicata
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParc[0].Cd_clifor,
                                                                                         lParc[0].Cd_endereco,
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
                        Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                        Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                        Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                        lEnd[0].cpf = rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc;
                        lEnd[0].rg = rClifor.Nr_rg;
                        BindingSource bsend = new BindingSource();
                        bsend.DataSource = lEnd;
                        //Buscar Valor Pago
                        decimal vl_pago = decimal.Zero;
                        List<TRegistro_MovCaixa> lPag = new TCD_CaixaPDV().SelectMovCaixa(
                                                                                        new TpBusca[]
                                                                                        {
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = "a.cd_empresa",
                                                                                                vOperador = "=",
                                                                                                vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                                                                            },
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = "a.id_cupom",
                                                                                                vOperador = "=",
                                                                                                vVL_Busca = lCupom[0].Id_vendarapidastr
                                                                                            }
                                                                                        }, string.Empty);
                        if (lPag.Count > 0)
                            vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                        vl_pago += lParc.Sum(p => p.Vl_liquidado);
                        Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                        Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                        BindingSource bsParc = new BindingSource();
                        bsParc.DataSource = lParc;
                        Rel.Adiciona_DataSource("PARC", bsParc);
                        Rel.Adiciona_DataSource("END", bsend);
                        Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_PDV";
                        Rel.NM_Classe = "TFVendaPDV";
                        Rel.Modulo = "FAT";
                        Rel.Ident = "CONFISSAO_DIVIDA_PDV";
                        //Verificar se existe Impressora padrão para o PDV
                        object obj = new TCD_PontoVenda().BuscarEscalar(
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
                        Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                    }
                }
            }

            using (PostoCombustivel.TFGerarDocFiscal fDoc = new PostoCombustivel.TFGerarDocFiscal())
            {
                if (fDoc.ShowDialog() == DialogResult.OK)
                    if (fDoc.St_nfe)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            //Validar se cliente informado é consumidor final
                            //Caso seja, solicitar alteração
                            if (lcfg[0].Cd_Clifor.Equals((bsCartao.Current as TRegistro_Cartao).Cd_Clifor))
                                solicitarAlteracaoClifor();

                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco cli = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                            cli = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_Clifor, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1, null);

                            Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido((bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                          cli.Count > 0 ? cli[0].Cd_endereco : string.Empty,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          lCfg[0],
                                                                                          lCupom[0].lItem,
                                                                                          ref rPedProduto,
                                                                                          ref rPedServico);
                            if (rPedProduto != null)
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto,
                                                                                                       null);
                                //Buscar pedido
                                rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                //Se o CMI do pedido gerar financeiro
                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
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
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + lcfg[0].cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " +  lCupom[0].Id_vendarapidastr + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                //Gerar Nota Fiscal
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                                //Vincular financeiro a Nota Fiscal
                                rFat.lParcAgrupar = lParcVinculado;
                                //Gravar Nota Fiscal
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            if (rPedServico != null)
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico,
                                                                                                       null);
                                //Buscar pedido
                                rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                                //Se o CMI do pedido gerar financeiro
                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
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
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + lcfg[0].cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                //Gerar Nota Fiscal
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedServico, true, lParcVinculado.Sum(p => p.Vl_atual));
                                //Vincular financeiro a Nota Fiscal
                                rFat.lParcAgrupar = lParcVinculado;
                                //Gravar Nota Fiscal
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                //Buscar CfgNfe para a empresa
                                TList_CfgNfe lCfgNfe =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                                if (lCfgNfe.Count > 0)
                                {
                                    NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0],
                                                                   CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 rFat.Nr_lanctofiscalstr,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 decimal.Zero,
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
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 decimal.Zero,
                                                                                                                                 decimal.Zero,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 false,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 string.Empty,
                                                                                                                                 1,
                                                                                                                                 string.Empty,
                                                                                                                                 null));
                                    MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
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

                            PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                            TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, dados.St_pedirCliente);

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
                                            ProcessarCFVincular(new List<TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                }
                                else
                                {
                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                    Rel.Altera_Relatorio = Altera_Relatorio;
                                    BindingSource dts = new BindingSource();
                                    dts.DataSource = new TList_NFCe_Item();
                                    Rel.DTS_Relatorio = dts;
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

                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
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
                                    List<TRegistro_MovCaixa> lPagto = new List<TRegistro_MovCaixa>();
                                    new TCD_CaixaPDV().SelectMovCaixa(
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
                                                                }).ToList().ForEach(x => lPagto.Add(new TRegistro_MovCaixa()
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
                                                                    "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.id_cupom = y.id_vendarapida " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                    "and y.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                    "and y.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                    }
                                            }, 1, string.Empty);
                                    if (lDup.Count > 0)
                                        lPagto.Add(new TRegistro_MovCaixa()
                                        {
                                            Tp_portador = "05",
                                            Vl_recebido = lDup[0].Vl_documento
                                        });
                                    bsPagto.DataSource = lPagto;
                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                    //Parametros
                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", rNFCe.lItem.Sum(p => p.Vl_imposto_Aprox));
                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", rNFCe.lItem.Count);
                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", rNFCe.lItem.Sum(p => p.Vl_subtotal));
                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", rNFCe.lItem.Sum(p => p.Vl_acrescimo));
                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", rNFCe.lItem.Sum(p => p.Vl_desconto));
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
                                    string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM(rNFCe.Cd_empresa,
                                                                                                            rNFCe.Id_nfcestr,
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
                                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(rNFCe.Id_nfcestr,
                                                                                                rNFCe.Cd_empresa,
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
                                    obj = new TCD_PontoVenda().BuscarEscalar(
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

                if (fDoc.DialogResult == DialogResult.Cancel)
                {
                    ///summary
                    ///Acontece quando o usuário seleciona a opção ESC
                    pedirParaImprimirExtrato = true;
                    return;
                }
            }

        }

        private void solicitarAlteracaoClifor()
        {
            using (PDV.TFClienteCupom fCliente = new PDV.TFClienteCupom())
            {
                fCliente.Cd_clifor = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor;
                fCliente.Nm_clifor = (bsCartao.Current as TRegistro_Cartao).Nm_Clifor;
                fCliente.BloquearNmClifor = false;
                if (fCliente.ShowDialog() == DialogResult.OK)
                {
                    (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = fCliente.Cd_clifor;
                    (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = fCliente.Nm_clifor;
                    bsCartao.ResetCurrentItem();
                }
            }
        }

        private void ImprimirGrafico(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = this.Altera_Relatorio;

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
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
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

        private void ImprimirGraficoReduzido(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = this.Altera_Relatorio;

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
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
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
            object obj = new TCD_PontoVenda().BuscarEscalar(
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
            this.Altera_Relatorio = false;
        }

        private void ProcessarCFVincular(List<TRegistro_NFCe> lCupom, string pCd_empresa, string pCd_cliente)
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
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + p.Id_nfcestr + ")"
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

        private void buscaclifor()
        {
            if (bsPreVenda.Count <= 0)
            {
                using (TFConsultaClifor c = new TFConsultaClifor())
                {
                    bsCliFor.Clear();
                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        if (c.rClifor != null)
                        {
                            st_cliente = true;
                            bsCliFor.Add(c.rClifor);
                            bsCliFor.ResetCurrentItem();
                            nr_cartao.Text = c.rClifor.Ident_frentista;
                            nm_clifor.Text = (bsCliFor.Current as TRegistro_Clifor).Nm_clifor;
                            if (bsCartao.Current != null)
                                (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = nm_clifor.Text;
                            if (bsCartao.Current != null)
                                TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);
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
                        bsCliFor.Clear();
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            if (c.rClifor != null)
                            {
                                st_cliente = true;
                                bsCliFor.Add(c.rClifor);
                                bsCliFor.ResetCurrentItem();
                                nm_clifor.Text = (bsCliFor.Current as TRegistro_Clifor).Nm_clifor;
                                if (bsCartao.Current != null)
                                    (bsCartao.Current as TRegistro_Cartao).Nm_Clifor = nm_clifor.Text;
                                (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = c.rClifor.Cd_clifor;

                                TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);

                                (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
                                {
                                    TRegistro_ProgEspecialVenda rProg = new TRegistro_ProgEspecialVenda();
                                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                                     c.rClifor.Cd_clifor,
                                                                                                                     p.cd_produto,
                                                                                                                     lcfg[0].cd_tabelapreco,
                                                                                                                     null);
                                    p.vl_desconto = CalcularDescEspecial(rProg, p.cd_produto, p.quantidade, p.vl_unitario);
                                    //Gravar Item com o Desconto
                                    TCN_PreVenda_Item.Gravar(p, null);
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

        private void cadclifor()
        {
            using (Cadastro.TFCliforDetalhado a = new Cadastro.TFCliforDetalhado())
            {
                a.rClifor = null;
                if (a.ShowDialog() == DialogResult.OK)
                {

                    TCN_CliFor.Gravar(a.rClifor, null);
                    bsCliFor.Clear();
                    bsCliFor.Add(a.rClifor);
                    bsCliFor.ResetCurrentItem();
                    nm_clifor.Text = a.rClifor.Nm_clifor;
                    nr_cartao.Text = a.rClifor.Ident_frentista;
                    if (bsCartao.Current != null)
                    {
                        (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = a.rClifor.Cd_clifor;
                        bsCartao.ResetCurrentItem();
                    }
                }
            }
        }

        private void altera_qtd()
        {
            if (bsItensPreVenda.Current != null)
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Text = "Quantidade";
                    fQtd.Vl_Minimo = 1;
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > decimal.Zero)
                        {
                            if (fQtd.Quantidade > decimal.Zero)
                            {
                                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).quantidade =
                                    fQtd.Quantidade;
                                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).vl_subtotal =
                                    decimal.Multiply((bsItensPreVenda.Current as TRegistro_PreVenda_Item).quantidade,
                                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).vl_unitario);
                                bsItensPreVenda.ResetCurrentItem();
                                calculatotal();
                                TCN_PreVenda_Item.Gravar(bsItensPreVenda.Current as TRegistro_PreVenda_Item, null);
                            }
                            else
                            {
                                MessageBox.Show("Quantidade informada é menor que zero!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
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
            }
            else if (txtDados.Text.SoNumero().Trim().Length != txtDados.Text.Trim().Length) //Criar filtro de produtos por nome
            {
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
            }

            TList_CadProduto lProd = new TCD_CadProduto().Select(
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
                                        "         where x.cd_produto = a.cd_produto " +
                                        "           and x.cd_codbarra = '" + txtDados.Text.Trim() + "'))"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);



            if (lProd.Count > 0 && !string.IsNullOrEmpty(txtDados.Text.Trim()))
            {
                txtDados.Text = lProd[0].CD_Produto;
                lblDescricao.Text = lProd[0].DS_Produto;

                if (lProd[0].St_pesarprodbool)
                {
                    if (rProtocolo == null)
                        AlterarQuantidade();
                    else
                    {
                        using (Proc_Commoditties.TFBalancaProc fPeso = new Proc_Commoditties.TFBalancaProc())
                        {
                            fPeso.rProtocolo = rProtocolo;
                            if (fPeso.ShowDialog() == DialogResult.OK)
                            {
                                if (fPeso.Peso > decimal.Zero)
                                {
                                    lblQuantidade.Text = fPeso.Peso.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                                    //SendKeys.Send("{ENTER}");
                                }
                                else
                                {
                                    AlterarQuantidade();
                                }
                            }
                            else
                            {
                                AlterarQuantidade();
                            }
                        }
                    }
                }

                object vl = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(new TpBusca[]
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

                if (lvunitario == decimal.Zero || string.IsNullOrEmpty(lvunitario.ToString()))
                    if (vl == null || Convert.ToDecimal(vl) <= 0)
                    {
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Vl_default = 0;
                            fQtde.Ds_label = "Valor Unitario";
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (fQtde.Quantidade > decimal.Zero)
                                {
                                    lvunitario = fQtde.Quantidade;
                                }
                            }
                        }
                    }

                if (lcfg[0].Cd_horaboliche.Equals(lProd[0].CD_Produto) || lcfg[0].Cd_horasinuca.Equals(lProd[0].CD_Produto))
                {
                    using (Proc_Commoditties.FObterHoras fObterHoras = new Proc_Commoditties.FObterHoras())
                    {
                        if (fObterHoras.ShowDialog() == DialogResult.OK)
                        {
                            lblQuantidade.Text = fObterHoras.quantidadeEmDecimal.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                            lblQuantidade.Select();
                        }
                        else
                        {
                            lblQuantidade.Select();
                        }
                    }
                }
                else
                {
                    lblQuantidade.Select();
                }
            }
        }

        private void AlterarQuantidade()
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Vl_default = 1;
                fQtde.Ds_label = "Informar";
                if (fQtde.ShowDialog() == DialogResult.OK)
                    if (fQtde.Quantidade > decimal.Zero)
                    {
                        lblQuantidade.Text = fQtde.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                    }
            }
        }

        private void BuscarPromocao(TRegistro_PreVenda_Item rItemPre)
        {
            if (rItemPre != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(rItemPre.Cd_empresa,
                                                                                                rItemPre.cd_produto,
                                                                                                rItemPre.Cd_grupo,
                                                                                                rProg,
                                                                                                rItemPre.vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Where(p => p.cd_produto.Trim().Equals(rItemPre.cd_produto.Trim())).Sum(p => p.quantidade) + rItemPre.quantidade >= rPro.Qtd_minimavenda)
                        {
                            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Where(p => p.cd_produto.Trim().Equals(rItemPre.cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    //Calcular desconto
                                    p.vl_desconto = p.vl_subtotal * (rPro.Vl_promocao / 100);
                                    //Calcular liquido
                                    p.vl_liquido = p.vl_subtotal - p.vl_desconto;
                                }
                                else
                                {
                                    p.vl_desconto = rPro.Vl_promocao * p.quantidade;
                                    //Calcular Liquido
                                    p.vl_liquido = p.vl_subtotal - p.vl_desconto;
                                }
                                TCN_PreVenda_Item.Gravar(p, null);
                            });
                            if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                            {
                                //Calcular desconto
                                rItemPre.vl_desconto = rItemPre.vl_subtotal * (rPro.Vl_promocao / 100);
                                //Calcular liquido
                                rItemPre.vl_liquido = rItemPre.vl_subtotal - rItemPre.vl_desconto;
                            }
                            else
                            {
                                rItemPre.vl_desconto = rPro.Vl_promocao * rItemPre.quantidade;
                                //Calcular Liquido
                                rItemPre.vl_liquido = rItemPre.vl_subtotal - rItemPre.vl_desconto;
                            }
                            bsItensPreVenda.ResetBindings(true);
                        }
                        else
                            rItemPre.vl_desconto = decimal.Zero;
                    }
                    else if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                    {
                        //Calcular desconto
                        rItemPre.vl_desconto = rItemPre.vl_subtotal * (rPro.Vl_promocao / 100);
                        //Calcular liquido
                        rItemPre.vl_liquido = rItemPre.vl_subtotal - rItemPre.vl_desconto;
                    }
                    else
                    {
                        rItemPre.vl_desconto = rPro.Vl_promocao * rItemPre.quantidade;
                        //Calcular Liquido
                        rItemPre.vl_liquido = rItemPre.vl_subtotal - rItemPre.vl_desconto;
                    }
            }
        }

        private decimal CalcularDescEspecial(TRegistro_ProgEspecialVenda rProg, string cd_produto, decimal Qtde, decimal Vl_unit)
        {
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    decimal qtd = Qtde;
                    if ((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Exists(p => p.cd_produto == cd_produto))
                        qtd += (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.FindAll(p => p.cd_produto == cd_produto).Sum(p => p.quantidade);
                    if (qtd >= rProg.Qtd_minVenda)
                    {
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            if (rProg.Valor > Vl_unit)
                                return decimal.Zero;
                            else return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
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

        private void carregarproduto()
        {
            if (!string.IsNullOrEmpty(txtDados.Text))
            {
                //Itens de integração são gravados apenas no fechamento da venda
                if (bsCartao.Current != null)
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.RemoveAll(i => i.tapTransactions != null);


                //Para produto corrente buscar preço de venda na tabela
                object vlPrecoVenda = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(new TpBusca[]
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

                if (vlPrecoVenda == null)
                    vlPrecoVenda = lvunitario.ToString();

                object descProduto = new TCD_CadProduto().BuscarEscalar(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador= "=",
                        vVL_Busca = ""+txtDados.Text.SoNumero()+""
                    }
                }, "a.ds_produto");

                // verifica se maior de idade
                object stMenores = new TCD_CadGrupoProduto().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador= "exists",
                            vVL_Busca = "( select 1 from tb_est_produto x where x.cd_produto = "+txtDados.Text.SoNumero()+" and x.cd_grupo = a.cd_grupo)"
                        }
                    }, "a.st_proibidomenores");
                string st_menor = stMenores != null ? stMenores.ToString() : string.Empty;
                bool menor = false;

                if (lcfg[0].Tp_cartao.Equals("2") && bsCartao.Current == null)
                {
                    TList_Cartao lcard = new TList_Cartao();

                    lcard = new TCD_Cartao().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao ",
                            vOperador = "is not null"
                        }
                    }, 1, string.Empty, "a.nr_cartao desc");

                    object card = new TCD_Cartao().BuscarEscalar(null, "count(a.id_cartao)  ");
                    bsCartao.AddNew();

                    if (lcard.Count != decimal.Zero && card == null)
                        (bsCartao.Current as TRegistro_Cartao).nr_cartao = (Convert.ToDecimal(lcard[0].nr_cartao) + 1).ToString();
                    else if (card != null)
                        (bsCartao.Current as TRegistro_Cartao).nr_cartao = (Convert.ToDecimal(card) + 1).ToString();
                    else
                        (bsCartao.Current as TRegistro_Cartao).nr_cartao = "1";

                    (bsCartao.Current as TRegistro_Cartao).Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                    (bsCartao.Current as TRegistro_Cartao).St_registro = "A";
                    (bsCartao.Current as TRegistro_Cartao).vl_limitecartao = decimal.Zero;
                    (bsCartao.Current as TRegistro_Cartao).status_menor = "N";
                    (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                    (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = (bsCliFor.Current != null) ? (bsCliFor.Current as TRegistro_Clifor).Cd_clifor : lcfg[0].Cd_Clifor;
                    nrcartao = (bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString();
                    CamadaDados.Restaurante.TRegistro_PreVenda pre = new CamadaDados.Restaurante.TRegistro_PreVenda();
                    pre.Dt_venda = CamadaDados.UtilData.Data_Servidor();
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda.Add(pre);
                    bsCartao.ResetCurrentItem();

                }
                else if (lcfg[0].Tp_cartao.Equals("1"))
                {
                    bool novo = true;
                    if (bsCartao.Current != null)
                        if ((bsCartao.Current as TRegistro_Cartao).id_local.Equals(comboBoxDefault1.SelectedValue))
                            novo = false;

                    if (novo)
                    {
                        bsCartao.AddNew();
                        (bsCartao.Current as TRegistro_Cartao).Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                        (bsCartao.Current as TRegistro_Cartao).St_registro = "A";
                        if (lcfg[0].Tp_cartao.Equals("1"))
                        {
                            if (!string.IsNullOrEmpty(nome))
                                (bsCartao.Current as TRegistro_Cartao).Id_mesa = !string.IsNullOrEmpty(nome) ? Convert.ToDecimal(nr_cartao.Text.SoNumero()) : Convert.ToDecimal(nome.Split('-')[0].ToString());
                            else
                                (bsCartao.Current as TRegistro_Cartao).Id_mesa = Convert.ToDecimal(nr_cartao.Text.SoNumero());
                        }
                        else
                            (bsCartao.Current as TRegistro_Cartao).Id_mesa = Convert.ToDecimal(nome.Split('-')[0].ToString());

                        (bsCartao.Current as TRegistro_Cartao).id_local = !string.IsNullOrEmpty(comboBoxDefault1.SelectedValue.ToString()) ? Convert.ToDecimal(comboBoxDefault1.SelectedValue) : (bsCartao.Current as TRegistro_Cartao).id_local;
                        (bsCartao.Current as TRegistro_Cartao).vl_limitecartao = decimal.Zero;
                        (bsCartao.Current as TRegistro_Cartao).status_menor = "N";
                        (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                        (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = (bsCliFor.Current != null) ? (bsCliFor.Current as TRegistro_Clifor).Cd_clifor : lcfg[0].Cd_Clifor;

                        nrcartao = (bsCartao.Current as TRegistro_Cartao).nr_cartao.ToString();
                        CamadaDados.Restaurante.TRegistro_PreVenda pre = new CamadaDados.Restaurante.TRegistro_PreVenda();
                        pre.Dt_venda = CamadaDados.UtilData.Data_Servidor();
                        pre.Cd_empresa = lcfg[0].cd_empresa;
                        (bsCartao.Current as TRegistro_Cartao).lPreVenda.Add(pre);
                        bsCartao.ResetCurrentItem();
                    }
                }
                else if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].bool_abrircartao && bsCartao.Current == null)
                {
                    bsCartao.AddNew();

                    (bsCartao.Current as TRegistro_Cartao).Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                    (bsCartao.Current as TRegistro_Cartao).St_registro = "A";
                    if (lcfg[0].bool_mesacartao && string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).Id_mesa.ToString()))
                    {
                        (bsCartao.Current as TRegistro_Cartao).id_local = Convert.ToDecimal(comboBoxDefault1.SelectedValue.ToString());
                        using (FTrocaMesa aew = new FTrocaMesa())
                        {
                            DialogResult ae = aew.ShowDialog();
                            if (ae == DialogResult.OK || ae == DialogResult.Abort)
                            {
                                (bsCartao.Current as TRegistro_Cartao).Id_mesa = aew.id_mesa;
                                (bsCartao.Current as TRegistro_Cartao).id_local = aew.id_local;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(nr_cartao.Text.SoNumero()))
                    {
                        MessageBox.Show("Obrigatório informar numero cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsCartao.Clear();
                        nr_cartao.Focus();
                        return;
                    }
                    (bsCartao.Current as TRegistro_Cartao).nr_cartao = nr_cartao.Text;
                    (bsCartao.Current as TRegistro_Cartao).vl_limitecartao = decimal.Zero;
                    (bsCartao.Current as TRegistro_Cartao).status_menor = "N";
                    (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                    (bsCartao.Current as TRegistro_Cartao).Cd_Clifor = !string.IsNullOrEmpty(cd_clifor_fidelidade) ? cd_clifor_fidelidade : (bsCliFor.Current != null) ? (bsCliFor.Current as TRegistro_Clifor).Cd_clifor : lcfg[0].Cd_Clifor;

                    bsCliFor.DataSource = new TCD_Clifor().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor
                            }
                        }, 1, string.Empty);
                    bsCliFor.ResetCurrentItem();
                    nrcartao = (bsCartao.Current as TRegistro_Cartao).nr_cartao;
                    CamadaDados.Restaurante.TRegistro_PreVenda pre = new CamadaDados.Restaurante.TRegistro_PreVenda();
                    pre.Dt_venda = CamadaDados.UtilData.Data_Servidor();
                    pre.Cd_empresa = lcfg[0].cd_empresa;
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda.Add(pre);
                    bsCartao.ResetCurrentItem();
                }

                if (st_menor.Equals("S") && (bsCartao.Current as TRegistro_Cartao).status_menor.Equals("S"))
                {
                    menor = true;
                    bsCartao.RemoveCurrent();
                    MessageBox.Show("Produto não pode ser vendido para menores de idade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (vlPrecoVenda != null)
                {
                    TRegistro_PreVenda_Item item = new TRegistro_PreVenda_Item();
                    item.cd_produto = txtDados.Text.SoNumero();
                    item.Cd_grupo = new TCD_CadProduto().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + item.cd_produto.Trim() + "'" } }, "a.cd_grupo").ToString();
                    if (string.IsNullOrEmpty(lblQuantidade.Text.Trim()))
                        lblQuantidade.Text = "1,00";
                    item.quantidade = Convert.ToDecimal(lblQuantidade.Text);

                    TpBusca[] filtro = new TpBusca[0];
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = " (SELECT 1 FROM TB_EST_PRODUTO X WHERE X.CD_UNIDADE = A.CD_UNIDADE AND X.CD_PRODUTO = " + txtDados.Text.SoNumero() + ") ";
                    TList_CadUnidade un = new TCD_CadUnidade().Select(filtro, 1, string.Empty, "a.casasdecimais");

                    decimal total = decimal.Zero;
                    decimal valor = decimal.Zero;
                    decimal desconto = decimal.Zero;
                    if (bsPreVenda.Current != null)
                    {
                        (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
                        {
                            total += p.vl_liquido;
                            valor += p.vl_subtotal;
                            desconto += p.vl_desconto;
                        });
                    }

                    if (!menor && !string.IsNullOrEmpty((bsCartao.Current as TRegistro_Cartao).Cd_empresa))
                    {
                        //corrige casas decimais
                        TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);
                        bsCartao.ResetCurrentItem();
                        item.cd_produto = txtDados.Text.SoNumero();

                        //busca programacao espacial de vendas
                        TRegistro_ProgEspecialVenda rProg = new TRegistro_ProgEspecialVenda();
                        rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                             (bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                                             item.cd_produto.SoNumero(),
                                                                                                             lcfg[0].cd_tabelapreco,
                                                                                                             null);
                        item.quantidade = Convert.ToDecimal(string.IsNullOrEmpty(lblQuantidade.Text.Trim()) ? "1" : lblQuantidade.Text);
                        if (lvunitario == decimal.Zero)
                            item.vl_unitario = Convert.ToDecimal(vlPrecoVenda.ToString());
                        else
                            item.vl_unitario = lvunitario;
                        item.vl_unitario = Convert.ToDecimal(item.vl_unitario.ToString("N" + ((un != null && un[0].CasasDecimais != decimal.Zero) ? un[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR")));
                        item.id_prevenda = (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).id_prevenda;
                        item.Cd_empresa = (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).Cd_empresa;
                        item.ds_produto = stMenores != null ? stMenores.ToString() : string.Empty;
                        item.vl_desconto = CalcularDescEspecial(rProg, item.cd_produto, item.quantidade, item.vl_unitario);
                        //Buscar promoção venda
                        BuscarPromocao(item);
                        //buscar porta imp
                        object porta = new TCD_CadProduto().BuscarEscalar(new TpBusca[]
                        {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador= "=",
                                        vVL_Busca = ""+item.cd_produto+""
                                    }
                        }, "a.id_localimp");

                        // verifica se maior de idade
                        if (porta == null ? false : !string.IsNullOrEmpty(porta.ToString()))
                            item.id_portaimp = Convert.ToDecimal(porta.ToString());
                        //verifica se tem obs do produto 
                        object obs_item = new TCD_CadGrupoProduto().BuscarEscalar(new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vOperador= "exists",
                                vVL_Busca = "( select 1 from tb_est_produto x where x.cd_produto = "+txtDados.Text+" and x.cd_grupo = a.cd_grupo)"
                            }
                        }, "a.st_obsitem");

                        total += Convert.ToDecimal(item.vl_liquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                        item.st_registro = "A";

                        ///summary
                        ///Utilizado para excluir itens precadastrados como servico
                        ///porém podendo ser inserido como produto (sinuca/ boliche)
                        ///para esses produtos é possível exclusão
                        if (item.cd_produto.Equals(lcfg[0].Cd_horaboliche) || item.cd_produto.Equals(lcfg[0].Cd_horasinuca))
                            item.st_produto = true;

                        TCN_PreVenda_Item.Gravar(item, null);

                        //Controlar a possibilidade de exclusão de item lançado na instancia
                        lAux.Add(item);

                        (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Add(item);
                        bsPreVenda.CurrencyManager.Refresh();
                        bsItensPreVenda.CurrencyManager.Refresh();

                        item.st_adicionado = true;
                        item.st_agregar = true;
                        procura_cartao();
                        bsItensPreVenda.Position = bsItensPreVenda.Count;
                        bsPreVenda.ResetCurrentItem();
                        int position = bsItensPreVenda.Position;

                        if (!AddSabores())
                        {
                            TCN_PreVenda_Item.Excluir((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Remove(bsItensPreVenda.Current as TRegistro_PreVenda_Item);
                            bsPreVenda.ResetCurrentItem();
                            return;
                        }

                        AddCarrinho();
                        bsItensPreVenda.Position = position;
                        if (obs_item != null)
                        {
                            if (obs_item.ToString().Equals("S"))
                            {
                                InputBox ibp = new InputBox();
                                ibp.Text = "Obs: " + item.ds_produto;
                                item.obsItem = ibp.ShowDialog();
                                item.id_item = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item;
                                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem = item.obsItem;
                                TCN_PreVenda_Item.Gravar(item, null);
                            }
                        }


                        bsPreVenda.ResetCurrentItem();
                        bsItensPreVenda.Position = bsItensPreVenda.Count;
                        bsItensPreVenda_PositionChanged(this, new EventArgs());

                    }

                    carregarmesas();
                    calculatotal();
                    novoproduto();
                    if (bsCartao.Current != null)
                        nm_clifor.Text = (bsCartao.Current as TRegistro_Cartao).Nm_Clifor;
                }
                else
                {
                    MessageBox.Show("Produto sem preço cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            lvunitario = decimal.Zero;
        }

        private void calculaTotal(decimal total, decimal valor, decimal desconto)
        {
            TpBusca[] filtro = new TpBusca[0];
            string st = string.Empty;
            int i = 0;
            (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
            {
                st += "( exists (SELECT 1 FROM TB_EST_PRODUTO X WHERE X.CD_UNIDADE = A.CD_UNIDADE AND X.CD_PRODUTO = " + p.cd_produto + ") )";
                if (i < (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Count - 1)
                    st += "or";
                i++;
            });
            CamadaDados.Estoque.Cadastros.TList_CadUnidade uni = new CamadaDados.Estoque.Cadastros.TList_CadUnidade();
            if (!string.IsNullOrEmpty(st))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = st;
                total = decimal.Zero;
                valor = decimal.Zero;
                desconto = decimal.Zero;
                (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.ForEach(p =>
                {
                    total += p.vl_liquido;
                    valor += p.vl_subtotal;
                    desconto += p.vl_desconto * p.quantidade;
                });
                uni = new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(filtro, 1, string.Empty, "a.casasdecimais");
                lblTotalLiquidoCupom.Text = total.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
                VLsubtotal.Text = valor.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
                lbldesconto.Text = desconto.ToString("N" + (uni[0].CasasDecimais != decimal.Zero ? uni[0].CasasDecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR"));
                lbltroco.Text = string.Empty;
                lblvalorpago.Text = string.Empty;
            }
        }

        private void procura_cartao()
        {
            nrcartao = nr_cartao.Text.SoNumero().Trim();

            if (lcfg[0].bool_abrircartao && (lcfg[0].Tp_cartao.Equals("0") || (lcfg[0].bool_mesacartao && lcfg[0].Tp_cartao.Equals("0"))) && lcfg[0].nr_cartaorotini > Convert.ToDecimal(nrcartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                nrcartao = string.Empty;
                return;
            }
            else if (lcfg[0].bool_abrircartao && (lcfg[0].Tp_cartao.Equals("0") || (lcfg[0].bool_mesacartao && lcfg[0].Tp_cartao.Equals("0"))) && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(nrcartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                nrcartao = string.Empty;
                return;
            }

            TList_Cartao cartao = new TList_Cartao();

            //verifica se esta na faixa
            if (lcfg[0].Tp_cartao.Equals("0") && !lcfg[0].bool_abrircartao)
            {
                object a = new TCD_Cartao().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = "'"+nr_cartao.Text.SoNumero().Trim()+ "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, "1");
                if (a == null || string.IsNullOrEmpty(a.ToString()))
                {
                    MessageBox.Show("Cartão informado não está em aberto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nrcartao = string.Empty;
                    return;
                }
            }

            //verifica se cliente fidelidade
            if (lcfg[0].Tp_cartao.Equals("0"))
            {
                TList_Clifor cli = new TList_Clifor();
                cli = new TCD_Clifor().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.Cartao_Fidelidade",
                            vOperador = "=",
                            vVL_Busca = "'"+nr_cartao.Text+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 1, string.Empty);
                if (cli.Count > 0)
                {
                    nr_cartao.Text = cli[0].Ident_frentista;
                    nrcartao = cli[0].Ident_frentista;
                    nm_clifor.Text = cli[0].Nm_clifor;
                    cd_clifor_fidelidade = cli[0].Cd_clifor;
                    bsCliFor.DataSource = new TCD_Clifor().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = cli[0].Cd_clifor
                            }
                        }, 1, string.Empty);
                    bsCliFor.ResetCurrentItem();
                }
            }

            if (lcfg[0].Tp_cartao.Equals("1"))
            {
                object a = new TCD_Mesa().BuscarEscalar(
                     new TpBusca[]
                     {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_local",
                            vOperador = "=",
                            vVL_Busca = comboBoxDefault1.SelectedValue.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_mesa",
                            vOperador = "=",
                            vVL_Busca = nr_cartao.ToString().SoNumero()
                        }
                     }, "1");
                if (a == null || string.IsNullOrEmpty(a.ToString()))
                {
                    nrcartao = string.Empty;
                    MessageBox.Show("Mesa não localizada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cartao = new TCD_Cartao().Select(
                new TpBusca[]
                {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_local",
                            vOperador = "=",
                            vVL_Busca = comboBoxDefault1.SelectedValue.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_mesa",
                            vOperador = "=",
                            vVL_Busca = nr_cartao.ToString().SoNumero()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                        }, 1, string.Empty, string.Empty);
            }

            else if (lcfg[0].Tp_cartao.Equals("0"))
            {
                cartao = new TCD_Cartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_cartao",
                                            vOperador = "=",
                                            vVL_Busca =  "'"+nrcartao+"'"

                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_registro",
                                            vOperador = "=",
                                            vVL_Busca = "'A'"
                                        }
                                    }, 1, string.Empty, string.Empty);
            }

            else
                cartao = new TCD_Cartao().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = (bsCartao.Current as TRegistro_Cartao).nr_cartao
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 1, string.Empty, string.Empty);

            bsCartao.DataSource = cartao;

            if (cartao.Count > 0)
            {
                //Buscar prevenda
                (bsCartao.Current as TRegistro_Cartao).lPreVenda = TCN_PreVenda.Buscar(
                    (bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                    (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(),
                    string.Empty, string.Empty,
                    string.Empty, "A", null);

                //Buscar itens da prevenda
                (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(p =>
                {
                    p.lItens = TCN_PreVenda_Item.Buscar(
                    p.Cd_empresa,
                    p.id_prevenda.ToString(),
                    string.Empty, string.Empty, null);
                    p.lItens.ForEach(u =>
                    {
                        u.lSabores = TCN_SaboresItens.Buscar(u.Cd_empresa, u.id_prevenda.ToString(), u.id_item.ToString(), string.Empty, null);
                    });
                });

                //Para configuração PathDbTorneira (integracao)
                if (lcfg[0].PathBdTorneira != null && !string.IsNullOrEmpty(lcfg[0].PathBdTorneira.Trim()))
                {
                    try
                    {
                        List<TRegistro_TapTransactions> _ListTapTran = new ServiceRest.TCD_TapTransactions().Buscar(lcfg[0].PathBdTorneira.Trim(),
                                                                                                                    (bsCartao.Current as TRegistro_Cartao).nr_cartao,
                                                                                                                    0,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty);

                        _ListTapTran.ForEach(p =>
                        {
                            if (string.IsNullOrEmpty(p.cdProduto))
                                throw new Exception("Erro na importação dos consumos. Existe torneira sem produto configurado.");

                            TpBusca[] tps = new TpBusca[0];
                            Estruturas.CriarParametro(ref tps, "a.cd_produto", p.cdProduto);
                            TRegistro_CadProduto _CadProduto = new TCD_CadProduto().Select(tps, 0, string.Empty, string.Empty, string.Empty)[0];

                            TRegistro_PreVenda_Item rItemIntegrado = new TRegistro_PreVenda_Item();
                            rItemIntegrado.Cd_empresa = (bsCartao.Current as TRegistro_Cartao).Cd_empresa;
                            rItemIntegrado.cd_produto = _CadProduto.CD_Produto;
                            rItemIntegrado.ds_produto = _CadProduto.DS_Produto;
                            rItemIntegrado.quantidade = Math.Round(decimal.Divide(p.volumeAmount, 1000), 3, MidpointRounding.AwayFromZero); //unidade em litros
                            rItemIntegrado.vl_unitario = ConsultaPreco(_CadProduto.CD_Produto);
                            if (rItemIntegrado.vl_unitario.Equals(decimal.Zero))
                                rItemIntegrado.vl_unitario = Math.Round(decimal.Divide(decimal.Divide(p.moneyAmount, 100), rItemIntegrado.quantidade), 2, MidpointRounding.AwayFromZero);
                            rItemIntegrado.tapTransactions = p;

                            (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.Add(rItemIntegrado);
                        });
                    }
                    catch { MessageBox.Show("Erro ler banco dados torneira.\r\nVerifique mapeamento do banco dados."); }
                }

                bsCliFor.DataSource = new TCD_Clifor().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor
                        }
                    }, 1, string.Empty);
                nm_clifor.Text = (bsCartao.Current as TRegistro_Cartao).Nm_Clifor;
                bsCartao.ResetCurrentItem();
                calculatotal();

                //Validar existencia de serviço em aberto para cartao
                if (TCN_MovBoliche.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                          (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString().Trim(),
                                          null,
                                          null,
                                          null,
                                          null,
                                          null)
                    .Exists(p => p.Dt_fechamento == null) && (bsCartao.Current as TRegistro_Cartao).lPreVenda.Count > 0 && (bsCartao.Current as TRegistro_Cartao).lPreVenda[0].lItens.Count.Equals(0))
                {
                    MessageBox.Show(
                        "O cartão informado consta com movimentação em aberto.",
                        "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (lcfg[0].Tp_cartao.Equals("2") && !lcfg[0].Tp_cartao.Equals("0") && cartao.Count <= 0)
            {
                nr_cartao.Text = string.Empty;
                bsItensPreVenda.Clear();
                bsCartao.Clear();
                calculatotal();
            }
            else if (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao)
            {
                calculatotal();
            }

        }

        private void CancelarVenda()
        {
            if (bsCartao.Current != null)
            {
                //Validar usuário para operação
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR ITEM CANCELAR VENDA", null))
                {
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Login = Utils.Parametros.pubLogin;
                        fRegra.Ds_regraespecial = "PERMITIR EXCLUIR ITEM CANCELAR VENDA";
                        if (fRegra.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                //Validar existencia de pista boliche em aberto para cartao
                if (TCN_MovBoliche.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                          (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString().Trim(),
                                          null,
                                          null,
                                          null,
                                          null,
                                          null)
                    .Exists(p => p.Dt_fechamento == null))
                {
                    MessageBox.Show(
                        "O cartão informado consta com movimentação em aberto. Será necessário efetuar o fechamento da movimentação.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Deseja cancelar venda?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
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
                        p.lItens.ForEach(u =>
                        {
                            u.lSabores = TCN_SaboresItens.Buscar(u.Cd_empresa, u.id_prevenda.ToString(), u.id_item.ToString(), string.Empty, null);
                        });
                    });
                    bsCartao.ResetCurrentItem();
                    TCN_Cartao.Excluir((bsCartao.Current as TRegistro_Cartao), null);

                    nr_cartao.Text = string.Empty;
                    nrcartao = string.Empty;
                    bsCartao.Clear();
                    carregarmesas();
                    afterNovo();
                }
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
                //Buscar Produtos no Cadastro Assistente de Venda 
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
                                    rItemPre.id_prevenda = (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).id_prevenda;
                                    rItemPre.vl_unitario = p.vl_unitario;
                                    rItemPre.quantidade = p.Quantidade;
                                    if (rItemPre.vl_unitario > decimal.Zero)
                                    {
                                        TRegistro_ProgEspecialVenda rProg = new TRegistro_ProgEspecialVenda();
                                        rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                                                                         (bsCartao.Current as TRegistro_Cartao).Cd_Clifor,
                                                                                                                         rItemPre.cd_produto,
                                                                                                                         lcfg[0].cd_tabelapreco,
                                                                                                                         null);
                                        rItemPre.vl_subtotal = rItemPre.vl_unitario * rItemPre.quantidade;
                                        rItemPre.vl_desconto = CalcularDescEspecial(rProg, rItemPre.cd_produto, rItemPre.quantidade, rItemPre.vl_unitario);
                                    }
                                    (bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda).lItens.Add(rItemPre);
                                    TCN_PreVenda_Item.Gravar(rItemPre, null);
                                });
                                procura_cartao();
                                bsPreVenda.ResetCurrentItem();
                            }
                    }
            }
        }

        private bool AddSabores()
        {
            if (bsItensPreVenda.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda s
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
                object grupo = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                   new TpBusca[]
                                   {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = (bsItensPreVenda.Current as TRegistro_PreVenda_Item).cd_produto
                        }
                                   }, "a.cd_grupo");

                if (qt_ != null && !string.IsNullOrEmpty(qt_.ToString()))
                    if (Convert.ToDecimal(qt_.ToString()) > decimal.Zero)
                    {
                        using (TFAddSabores sabores = new TFAddSabores())
                        {
                            sabores.qtd_agregar = Convert.ToDecimal(qt_.ToString());
                            sabores.vCd_Grupo = grupo.ToString();
                            if (sabores.ShowDialog() == DialogResult.OK)
                            {
                                if (sabores.lSabores.Count > 0)
                                {
                                    sabores.lSabores.ForEach(p =>
                                    {
                                        p.cd_grupo = grupo.ToString();
                                        (bsItensPreVenda.Current as TRegistro_PreVenda_Item).lSabores.Add(p);
                                    });

                                    bsPreVenda.ResetCurrentItem();
                                }
                                TCN_PreVenda_Item.Gravar((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                                return true;
                            }
                            else
                            {
                                //TCN_PreVenda_Item.Excluir((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                                //(bsPreVenda.Current as TRegistro_PreVenda).lItens.Remove(bsItensPreVenda.Current as TRegistro_PreVenda_Item);
                                bsPreVenda.ResetCurrentItem();
                                return false;
                            }
                        }
                    }
            }
            return true;
        }

        private void gerarExtrato()
        {
            if (bsPreVenda.Current != null)
            {
                if (bsCartao.Current != null)
                {
                    if (!string.IsNullOrEmpty(id_pdv))
                    {
                        IMP_Cartao.Impressao_FASTFOOD((bsPreVenda.Current as CamadaDados.Restaurante.TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao), id_pdv);
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void FLanPreVenda_Load(object sender, EventArgs e)
        {
            //time da hora
            timer1.Enabled = true;
            timer1.Interval = 1000;

            panelValores.set_FormatZero();

            if (cCartao != null)
            {
                TList_Cartao cartao = new TList_Cartao();
                cartao.Add(cCartao);
                if (cartao.Count > 0)
                {
                    bsCartao.DataSource = cartao;
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda = TCN_PreVenda.Buscar(
                        (bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                        (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(),
                        string.Empty, string.Empty,
                        string.Empty, "A", null);
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(u =>
                    {
                        u.lItens = TCN_PreVenda_Item.Buscar(
                        u.Cd_empresa,
                        u.id_prevenda.ToString(),
                        string.Empty, string.Empty, null);
                        u.lItens.ForEach(io =>
                        {
                            io.lSabores = TCN_SaboresItens.Buscar(io.Cd_empresa, io.id_prevenda.ToString(), io.id_item.ToString(), string.Empty, null);
                        });
                    });
                    // busca clifor
                    bsCliFor.DataSource = new TCD_Clifor().Select(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" +  cCartao.Cd_Clifor.Trim() + "'"
                        }
                    }, 1, string.Empty);
                    bsCliFor.ResetCurrentItem();
                    nm_clifor.Text = (bsCliFor.Current as TRegistro_Clifor).Nm_clifor;


                    bsCartao.ResetCurrentItem();
                    calculatotal();
                    nr_cartao.Text = cCartao.nr_cartao;
                    nrcartao = cCartao.nr_cartao;
                }
            }

            #region Arredondar bordas
            System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
            p.StartFigure();
            p.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            p.AddLine(40, 0, this.Width - 40, 0);
            p.AddArc(new Rectangle(this.Width - 40, 0, 40, 40), -90, 90);
            p.AddLine(this.Width, 40, this.Width, this.Height - 40);
            p.AddArc(new Rectangle(this.Width - 40, this.Height - 40, 40, 40), 0, 90);
            p.AddLine(this.Width - 40, this.Height, 40, this.Height);
            p.AddArc(new Rectangle(0, this.Height - 40, 40, 40), 90, 90);
            p.CloseFigure();
            this.Region = new Region(p);

            System.Drawing.Drawing2D.GraphicsPath p3 = new System.Drawing.Drawing2D.GraphicsPath();
            p3.StartFigure();
            p3.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            p3.AddLine(40, 0, dataGridView1.Width - 40, 0);
            p3.AddArc(new Rectangle(dataGridView1.Width - 40, 0, 40, 40), -90, 90);
            p3.AddLine(dataGridView1.Width, 40, dataGridView1.Width, dataGridView1.Height - 40);
            p3.AddArc(new Rectangle(dataGridView1.Width - 40, dataGridView1.Height - 40, 40, 40), 0, 90);
            p3.AddLine(dataGridView1.Width - 40, dataGridView1.Height, 40, dataGridView1.Height);
            p3.AddArc(new Rectangle(0, dataGridView1.Height - 40, 40, 40), 90, 90);
            p3.CloseFigure();
            dataGridView1.Region = new Region(p3);

            #endregion
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.RowTemplate.MinimumHeight = 20;

            if (string.IsNullOrEmpty(LoginPdv))
                LoginPdv = Utils.Parametros.pubLogin;
            label15.Text = Utils.Parametros.pubLogin;

            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count <= 0)
            {
                MessageBox.Show("Não existe configuração cadastrada!", "Mensagem", MessageBoxButtons.OK);
                return;
            }


            TList_RegCadProtocolo lProt = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(string.Empty, string.Empty, Utils.Parametros.pubTerminal, null);
            if (lProt.Count > 0)
                rProtocolo = lProt[0];
            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count < 1)
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            else if (!string.IsNullOrEmpty(lPdv[0].Nm_empresa))
            {
                label11.Text = lPdv[0].Ds_pdv;
                //Buscar Config Cupom
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
                if (lCfg.Count < 1)
                {
                    MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + lPdv[0].Cd_empresa,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            //Verificar sessao
            if (new TCD_Sessao().BuscarEscalar(
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
                    new TRegistro_Sessao()
                    {
                        Id_pdvstr = lPdv[0].Id_pdvstr,
                        Login = LoginPdv
                    }, null);
            if (lPdv.Count > 0)
                id_pdv = lPdv[0].Id_pdvstr;
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
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Busca caixa aberto
            TList_CaixaPDV lCaixa =
                new TCD_CaixaPDV().Select(
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
                this.BeginInvoke(new MethodInvoker(Close));
            }

            buscamesas.Enabled = false;
            if (lcfg[0].Tp_cartao.Equals("2"))
            {
                nr_cartao.Enabled = false;
                txtDados.Focus();
                lblcliente.Text = "(F5) - Cliente";
                na_cartao.Text = "N° Senha";
                lblNovoCartao.Text = "F2 - Fechar Venda";
                txtDados.Focus();
                lblNovoCartao.Text = "F2 - Fechar Venda";
                bb_trocarmesa.Visible = false;
                mesas_tab.Visible = false;
                lbllocal.Visible = false;
                plocal.Visible = false;
            }
            else if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].bool_mesacartao)
            {
                lblNovoCartao.Text = "F2 - Fechar Venda";
                nr_cartao.Enabled = true;
                lblcliente.Text = "(F5) - Cliente";
                na_cartao.Text = "N° Cartão - (F4 LIMPAR)";
                nr_cartao.Focus();
                carregarmesas();
                buscamesas.Enabled = true;
                buscamesas.Interval = 30000;
                bb_trocarmesa.Visible = true;
                mesas_tab.Visible = true;
                lbllocal.Visible = true;
                plocal.Visible = true;
                carregarmesas();
            }
            else if (lcfg[0].Tp_cartao.Equals("0"))
            {

                lblNovoCartao.Visible = true;
                nr_cartao.Focus();
                lblcliente.Text = "(F5) - Cliente";
                na_cartao.Text = "N° Cartão (F4)";
                lblNovoCartao.Text = "F2 - Fechar Venda";
                bb_trocarmesa.Visible = false;
                mesas_tab.Visible = false;
                lbllocal.Visible = false;
                plocal.Visible = false;
            }
            else if (lcfg[0].Tp_cartao.Equals("1"))
            {
                lblNovoCartao.Text = "F2 - Fechar Venda";
                nr_cartao.Enabled = true;
                nr_cartao.Focus();
                lblcliente.Text = "(F5) - Cliente";
                na_cartao.Text = "N° Mesa - (F4 LIMPAR)";
                carregarmesas();
                buscamesas.Enabled = true;
                buscamesas.Interval = 30000;
                bb_trocarmesa.Visible = true;
                mesas_tab.Visible = true;
                lbllocal.Visible = true;
                plocal.Visible = true;
            }
            lblQuantidade.Text = "1,00";
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 5) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 5) * 1;


            comboBoxDefault1.DataSource = TCN_Local.Buscar(string.Empty, string.Empty, string.Empty, null);

            comboBoxDefault1.DisplayMember = "Ds_Local";
            comboBoxDefault1.ValueMember = "Id_Local";

            if (lcfg[0].Tp_cartao.Equals("1") && bsCartao.Current != null)
            {
                nr_cartao.Text = (bsCartao.Current as TRegistro_Cartao).Id_mesa.ToString();
                //comboBoxDefault1.SelectedValue = (bsCartao.Current as TRegistro_Cartao).id_local.ToString();
            }

        }

        private void Mesa_Click(object sender, EventArgs e)
        {
            String[] a = ((Componentes.ListPanel)sender).Name.Split('-');
            this.nome = ((Componentes.ListPanel)sender).Name;
            comboBoxDefault1.Text = a[1];
            string id_cartao = ((Componentes.ListPanel)sender).Tag.ToString();

            nr_cartao.Text = a[0].ToString();

            //Validar se mesa possui mesclagem (mais de 1 cartao relacionado)
            TList_Cartao cart = new TList_Cartao();
            cart = new TCD_Cartao().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = lcfg[0].cd_empresa
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "c.nr_mesa",
                        vOperador = "=",
                        vVL_Busca = ((Componentes.ListPanel)sender).NM_Campo
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_local",
                        vOperador = "=",
                        vVL_Busca = comboBoxDefault1.SelectedValue.ToString()
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.st_registro",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 0, string.Empty, string.Empty);
            if (cart.Count > 1)
            {
                using (TFCartoesMesa fCartoesMesa = new TFCartoesMesa())
                {
                    fCartoesMesa.pId_local = comboBoxDefault1.SelectedValue.ToString();
                    fCartoesMesa.pCd_Empresa = lcfg[0].cd_empresa;
                    fCartoesMesa.pNr_Mesa = ((Componentes.ListPanel)sender).NM_Campo;
                    if (fCartoesMesa.ShowDialog() == DialogResult.OK)
                    {
                        id_cartao = fCartoesMesa.pId_Cartao;
                        nr_cartao.Text = fCartoesMesa.pNr_Cartao;
                        nrcartao = fCartoesMesa.pNr_Cartao;
                    }
                }
            }


            TList_Cartao cartao = new TCD_Cartao().Select(
                new TpBusca[]
                {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cartao",
                            vOperador = "=",
                            vVL_Busca = id_cartao
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                        }, 1, string.Empty, string.Empty);

            if (cartao.Count > 0)
            {

                bsCartao.DataSource = cartao;
                (bsCartao.Current as TRegistro_Cartao).lPreVenda = TCN_PreVenda.Buscar(
                    (bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                    (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(),
                    string.Empty, string.Empty,
                    string.Empty, "A", null);
                (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(p =>
                {
                    p.lItens = TCN_PreVenda_Item.Buscar(
                    p.Cd_empresa,
                    p.id_prevenda.ToString(),
                    string.Empty, string.Empty, null);
                    p.lItens.ForEach(u =>
                    {
                        u.lSabores = TCN_SaboresItens.Buscar(u.Cd_empresa, u.id_prevenda.ToString(), u.id_item.ToString(), string.Empty, null);
                    });
                });
                bsCliFor.DataSource = new TCD_Clifor().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor
                        }
                    }, 1, string.Empty);
                nm_clifor.Text = (bsCartao.Current as TRegistro_Cartao).Nm_Clifor;
                bsCartao.ResetCurrentItem();

                calculatotal();
            }
            else
            {
                bsCartao.Clear();
                bsCliFor.Clear();
                bsPreVenda.Clear();
                lblTotalLiquidoCupom.Text = string.Empty;
                VLsubtotal.Text = string.Empty;
                lbldesconto.Text = string.Empty;
                lbltroco.Text = string.Empty;
                lblvalorpago.Text = string.Empty;
            }
            return;
        }

        private void FLanPreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
                this.cadclifor();
            else if (e.KeyCode.Equals(Keys.F4) && !lcfg[0].Tp_cartao.Equals("2"))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.BuscarProduto();
            else if (e.KeyCode.Equals(Keys.F5))
                this.buscaclifor();
            else if (e.KeyCode.Equals(Keys.F2))
                fechacartao();
            else if (e.KeyCode.Equals(Keys.F8))
                bb_trocarmesa_Click(sender, e);
            //altera_qtd();
            else if (e.KeyCode.Equals(Keys.Delete))
                this.excluir();
            else if (e.KeyCode.Equals(Keys.F7))
                this.consultaproduto();
            else if (e.KeyCode.Equals(Keys.F6))
                this.CancelarVenda();
            else if (e.KeyCode.Equals(Keys.F9))
                using (TFConsultaCartao fConsulta = new TFConsultaCartao())
                    fConsulta.ShowDialog();
            else if (e.KeyCode.Equals(Keys.F10))
                gerarExtrato();

        }

        private void nr_cartao_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_cartao.Text))
                nr_cartao.Text = nr_cartao.Text.SoNumero().Trim();
        }

        private void txtDados_TextChanged(object sender, EventArgs e)
        {
            if ((!lcfg[0].Tp_cartao.Equals("0")) && (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao))
            {
                buscamesas.Stop();
                if (txtDados.Text.Trim().Length == 0 || txtDados.Text.Trim().Length == 7)
                    buscamesas.Start();
            }
        }

        private void txtDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void bsItensPreVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensPreVenda.Current != null)
            {
                (bsItensPreVenda.Current as TRegistro_PreVenda_Item).lSabores
                     = TCN_SaboresItens.Buscar((bsItensPreVenda.Current as TRegistro_PreVenda_Item).Cd_empresa,
                     (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                     (bsItensPreVenda.Current as TRegistro_PreVenda_Item).id_item.ToString(), string.Empty, null);
                bsItensPreVenda.ResetCurrentItem();
            }
        }

        private void nr_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                txtDados.Focus();
            if (e.KeyCode.Equals(Keys.Tab))
                nr_cartao_Leave(this, new EventArgs());
        }

        private void txtDados_Leave(object sender, EventArgs e)
        {
            if ((!lcfg[0].Tp_cartao.Equals("0")) && (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao))
            {
                buscamesas.Stop();
                buscamesas.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bsItensPreVenda.Count == 0)
                this.Close();
            else
                MessageBox.Show("Existe venda não finalizada em andamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                carregarproduto();
        }

        private void FLanPreVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridView1);
            try
            {
                lSessao.ForEach(p => CamadaNegocio.Faturamento.PDV.TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsItensPreVenda.Current != null)
            {
                if ((bsItensPreVenda.Current as TRegistro_PreVenda_Item).tapTransactions != null)
                    return;

                InputBox inputBox = new InputBox();
                inputBox.Text = "Obs: " + (bsItensPreVenda.Current as TRegistro_PreVenda_Item).ds_produto.Trim();
                string retorno = inputBox.Show((bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem);
                if (!string.IsNullOrEmpty(retorno))
                {
                    (bsItensPreVenda.Current as TRegistro_PreVenda_Item).obsItem = retorno;
                    TCN_PreVenda_Item.Gravar((bsItensPreVenda.Current as TRegistro_PreVenda_Item), null);
                    bsItensPreVenda.ResetCurrentItem();
                }
            }
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {

            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Cursor = Cursors.Hand;
            label7.ForeColor = Color.Blue;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {

            label7.BorderStyle = BorderStyle.None;
            label7.Cursor = Cursors.Default;
            label7.ForeColor = Color.Green;
        }

        private void lblNovoCartao_MouseEnter(object sender, EventArgs e)
        {
            lblNovoCartao.BorderStyle = BorderStyle.FixedSingle;
            lblNovoCartao.Cursor = Cursors.Hand;
            lblNovoCartao.ForeColor = Color.Blue;

        }

        private void lblNovoCartao_MouseLeave(object sender, EventArgs e)
        {
            lblNovoCartao.BorderStyle = BorderStyle.None;
            lblNovoCartao.Cursor = Cursors.Default;
            lblNovoCartao.ForeColor = Color.Green;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Cursor = Cursors.Hand;
            label9.ForeColor = Color.Blue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BorderStyle = BorderStyle.None;
            label9.Cursor = Cursors.Default;
            label9.ForeColor = Color.Green;
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            label18.BorderStyle = BorderStyle.FixedSingle;
            label18.Cursor = Cursors.Hand;
            label18.ForeColor = Color.Blue;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {

            label18.BorderStyle = BorderStyle.None;
            label18.Cursor = Cursors.Default;
            label18.ForeColor = Color.Green;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Cursor = Cursors.Hand;
            label3.ForeColor = Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BorderStyle = BorderStyle.None;
            label3.Cursor = Cursors.Default;
            label3.ForeColor = Color.Green;
        }

        private void label7_Click(object sender, EventArgs e)
        {

            this.cadclifor();
        }

        private void lblNovoCartao_Click(object sender, EventArgs e)
        {
            if (lblNovoCartao.Equals("F4 - Novo Cartão"))
            {

                this.afterNovo();
            }
            else
            {
                fechacartao();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.excluir();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.CancelarVenda();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.consultaproduto();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (bsItensPreVenda.Count == 0)
                using (TFConsultaCartao fConsulta = new TFConsultaCartao())
                {
                    fConsulta.ShowDialog();
                }
            else
                MessageBox.Show("Não é possível consultar pedido com venda em andamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Cursor = Cursors.Hand;
            label4.ForeColor = Color.Blue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BorderStyle = BorderStyle.None;
            label4.Cursor = Cursors.Default;
            label4.ForeColor = Color.Green;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.altera_qtd();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void buscamesas_Tick(object sender, EventArgs e)
        {
            if ((!lcfg[0].Tp_cartao.Equals("0")) && (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao))
                carregarmesas();
        }

        private void mesas_tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }

        private void bb_trocarmesa_Click(object sender, EventArgs e)
        {
            if (bsCartao.Current != null)
                using (FTrocaMesa mesa = new FTrocaMesa())
                {

                    DialogResult dialog = mesa.ShowDialog();
                    if (dialog == DialogResult.OK)
                    {
                        (bsCartao.Current as TRegistro_Cartao).Id_mesa = mesa.id_mesa;
                        (bsCartao.Current as TRegistro_Cartao).id_local = mesa.id_local;
                        TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);
                        MessageBox.Show("Mesa alterada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dialog == DialogResult.Abort)
                    {
                        (bsCartao.Current as TRegistro_Cartao).Id_mesa = mesa.id_mesa;
                        (bsCartao.Current as TRegistro_Cartao).id_local = mesa.id_local;
                        TCN_PreVenda.TransferirMesa((bsCartao.Current as TRegistro_Cartao), lcfg[0], mesa.id_cartao, null);
                        MessageBox.Show("Mesa alterada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    carregarmesas();

                }
        }

        private void nr_cartao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_cartao.Text))
            {
                if (bsCartao.Count.Equals(0))
                    procura_cartao();

                if (lcfg[0].Tp_cartao.Equals("1"))
                {
                    this.novoproduto();
                }
                else
                if (bsCartao.Count > 0 || (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].bool_abrircartao && !string.IsNullOrEmpty(nrcartao)))
                {
                    this.novoproduto();
                }
                else
                    nr_cartao.Focus();

                if (string.IsNullOrEmpty(nrcartao) && lcfg[0].Tp_cartao.Equals("1"))
                    nr_cartao.Focus();

            }
        }

        private void lblQuantidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nr_cartao.Text))
                nr_cartao.Focus();
            else
                txtDados.Focus();
        }

        private void comboBoxDefault1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDefault1.Focus())
                nr_cartao.Focus();
        }

        private void lblGerarExtrato_Click(object sender, EventArgs e)
        {
            gerarExtrato();
        }

        private void bsCartao_CurrentChanged(object sender, EventArgs e)
        {
            //Validar se prévenda possui serviços para lançar (em aberto)
            if (bsCartao.Current != null)
            {
                DataTable rMov = new TCD_MovBoliche().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsCartao.Current as TRegistro_Cartao).id_cartao + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Fechamento",
                                vOperador = "",
                                vVL_Busca = "is null"
                            }
                    }, 1);
                if (rMov.Rows.Count > 0)
                    lblMovServicos.Visible = true;
            }
            else
            {
                lblMovServicos.Visible = false;
            }
        }
        #endregion

        private void lblGerarExtrato_MouseEnter(object sender, EventArgs e)
        {
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Cursor = Cursors.Hand;
            label4.ForeColor = Color.Blue;
        }

        private void lblGerarExtrato_MouseLeave(object sender, EventArgs e)
        {
            label4.BorderStyle = BorderStyle.None;
            label4.Cursor = Cursors.Default;
            label4.ForeColor = Color.Green;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //método adicionado pois há estouro de exception index
            //colocado para não aparecer mensagem
        }
    }
}