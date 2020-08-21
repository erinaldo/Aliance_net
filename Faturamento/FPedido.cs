using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Pedido;

namespace Faturamento
{
    public partial class TFPedido : Form
    {
        private bool St_condProgramada
        { get; set; }
        private decimal vVl_pedido { get; set; }
        public bool St_parcelas
        { get; set; }
        public bool St_editar { get; set; }
        private string Cd_condPagtoOld = string.Empty;

        private TRegistro_Pedido rpedido;
        public TRegistro_Pedido rPedido
        {
            get
            {
                if (BS_Pedido.Current != null)
                    return BS_Pedido.Current as TRegistro_Pedido;
                else
                    return null;
            }
            set { rpedido = value; }
        }

        private string LoginDesconto = string.Empty;

        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;

        private decimal Pc_descOld
        { get; set; }

        public TFPedido()
        {
            InitializeComponent();
            rpedido = null;
            St_parcelas = false;
            St_editar = true;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMITENTE", "0"));
            cbx.Add(new Utils.TDataCombo("DESTINATARIO", "1"));
            cbx.Add(new Utils.TDataCombo("TERCEIRO", "2"));
            cbx.Add(new Utils.TDataCombo("SEM FRETE", "9"));

            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("VENDEDOR", "P"));
            cbx1.Add(new Utils.TDataCombo("COMPRADOR", "T"));
            tp_descarga.DataSource = cbx1;
            tp_descarga.DisplayMember = "Display";
            tp_descarga.ValueMember = "Value";
        }

        private void Alterar()
        {
            if (rpedido != null)
            {
                BS_Pedido.DataSource = new TList_Pedido() { rpedido };
                TotalizarPedido();
                Pc_descOld = rpedido.Pc_descgeral;
                //Verificar disponibilidade do pedido
                if (TCN_Pedido.Verifica_Disponibilidade_Pedido((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                {
                    cbEmpresa.Enabled = false;
                    CFG_Pedido.Enabled = false;
                    BB_CFGPedido.Enabled = false;
                    CD_Clifor.Enabled = false;
                    BB_Clifor.Enabled = false;
                    CD_Endereco.Enabled = false;
                    BB_Endereco.Enabled = false;
                    CD_Moeda.Enabled = false;
                    BB_Moeda.Enabled = false;
                    TS_ItensPedido.Enabled = false;
                }
                cbEmpresa.Enabled = string.IsNullOrEmpty(rpedido.Cd_tabelapreco) && rpedido.lDup.Count().Equals(0);
                CD_TabelaPreco.Enabled = string.IsNullOrEmpty(CD_TabelaPreco.Text);
                BB_TabelaPreco.Enabled = string.IsNullOrEmpty(CD_TabelaPreco.Text);
                if (rpedido.lDup.Count() > 0)
                {
                    CD_Clifor.Enabled = false;
                    BB_Clifor.Enabled = false;
                    CD_CondPGTO.Enabled = false;
                    BB_CondPGTO.Enabled = false;
                    VL_Parcela.Enabled = false;
                    vVl_pedido = tot_liquido.Value;
                }
                lblAgente.Text = (rpedido.TP_Movimento.Trim().ToUpper().Equals("S") ? "Vendedor:" : "Comprador:");
                cd_comprador.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("E");
                bb_comprador.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("E");
                nm_comprador.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("E");

                CD_CompVend.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("S");
                BB_CompVend.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("S");
                NM_CompVend.Visible = rpedido.TP_Movimento.Trim().ToUpper().Equals("S");
                if (rpedido.TP_Movimento.Trim().ToUpper().Equals("E") && string.IsNullOrEmpty(rpedido.Cd_clifor_comprador))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lComp =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                        "where x.cd_clifor_cmp = a.cd_clifor " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        }
                    }, 1, string.Empty);
                    if (lComp.Count > 0)
                    {
                        cd_comprador.Text = lComp[0].Cd_clifor;
                        nm_comprador.Text = lComp[0].Nm_clifor;
                    }
                }
            }
            else
            {
                BS_Pedido.AddNew();
                cbEmpresa.SelectedIndex = 0;
                cbEmpresa.Focus();
            }
        }

        private void Busca_Endereco_Clifor()
        {
            if (CD_Clifor.Text != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
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
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(CD_Endereco.Text))
                    {
                        CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                        DS_Cidade.Text = List_Endereco[0].DS_Cidade.Trim();
                        UF.Text = List_Endereco[0].UF.Trim();
                    }
                }
            }
        }

        private void Busca_Endereco_Transportadora()
        {
            if (CD_Transportadora.Text != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Transportadora.Text,
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
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(CD_EnderecoTransp.Text))
                    {
                        CD_EnderecoTransp.Text = List_Endereco[0].Cd_endereco.Trim();
                        DS_Endereco_Transp.Text = List_Endereco[0].Ds_endereco.Trim();
                        DS_Cidade_Transp.Text = List_Endereco[0].DS_Cidade.Trim();
                        UF_Transp.Text = List_Endereco[0].DS_Estado.Trim();
                    }
                }
            }
        }

        private void afterGrava()
        {
            //ReCalcular Parcelas
            if (VL_Parcela.Focused)
                VL_Parcela_Leave(this, new EventArgs());
            if (tcPedido.SelectedTab != tpPedido)
                tcPedido.SelectedTab = tpPedido;
            if (pnl_Pedido.validarCampoObrigatorio())
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count(p => p.St_registro.Trim() != "C") > 0 && !vVl_pedido.Equals(tot_liquido.Value))
                {
                    MessageBox.Show("Não é permitido alterar valor pedido que possui duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).CD_TRANSPORTADORA.Trim().Equals(string.Empty) &&
                    (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S") &&
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("TRANSP_PEDIDOVENDA", null))
                {
                    MessageBox.Show("Não é permitido gravar pedido de venda sem informar transportadora.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar pedido sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(logradouroent.Text) ||
                    !string.IsNullOrEmpty(numeroent.Text) ||
                    !string.IsNullOrEmpty(bairroent.Text) ||
                    !string.IsNullOrEmpty(cd_cidadent.Text))
                {
                    tcPedido.SelectedTab = tpDados;
                    tcOutrosDados.SelectedTab = tpEntrega;
                    if (string.IsNullOrEmpty(logradouroent.Text))
                    {
                        MessageBox.Show("Obrigatório informar logradouro entrega.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logradouroent.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(numeroent.Text))
                    {
                        MessageBox.Show("Obrigatório informar numero entrega.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numeroent.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(bairroent.Text))
                    {
                        MessageBox.Show("Obrigatório informar bairro entrega.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bairroent.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(cd_cidadent.Text))
                    {
                        MessageBox.Show("Obrigatório informar cidade entrega.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cidadent.Focus();
                        return;
                    }
                }
                if (!ValidarDescontos())
                    return;
                if (string.IsNullOrEmpty(CD_CompVend.Text) && TP_Mov.Text.Trim().ToUpper().Equals("S"))
                {
                    //Verificar se o tipo de pedido comissiona vendedor
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cfg_pedido",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "isnull(a.st_comissaoped, 'N') = 'S' or isnull(a.st_comissaofat, 'N') = 'S'"
                                        }
                                    }, "1");
                    if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido gravar pedido configurado para gerar comissão sem informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_CompVend.Focus();
                        return;
                    }
                }
                if (st_servico.Checked && string.IsNullOrEmpty(cd_municipioexecservico.Text))
                {
                    //Verificar tp_naturezaoperacaoiss da empresa
                    object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (cbEmpresa.SelectedValue != null ? cbEmpresa.SelectedValue.ToString() : string.Empty) + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_naturezaoperacao",
                                            vOperador = "=",
                                            vVL_Busca = "'2'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        MessageBox.Show("Obrigatorio informar municipio execução do serviço para pedido de SERVIÇO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcPedido.SelectedTab = tpDados;
                        cd_municipioexecservico.Focus();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(cd_representante.Text) && pc_comrep.Value.Equals(decimal.Zero))
                    if (MessageBox.Show("Informado representante no pedido e não informado % COMISSÃO para o mesmo.\r\n" +
                                       "Confirma gravar pedido sem % COMISSÃO para o representante?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        if (!tcPedido.SelectedTab.Equals(tpPedido))
                            tcPedido.SelectedTab = tpPedido;
                        pc_comrep.Focus();
                        return;
                    }
                DialogResult = DialogResult.OK;
            }
        }

        private void InserirItem()
        {//Verificar se o tipo de pedido exige conferencia
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                            new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_ExigirConferenciaEntrega, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
            {
                //Verificar se o pedido tem conferencia processada
                obj = new CamadaDados.Faturamento.Pedido.TCD_EntregaPedido().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        }
                    }, "1");
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido adicionar item no pedido com conferência processada.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
            if (TP_Mov.Text.Trim().ToUpper().Equals("S"))
            {
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                     null))
                {
                    if (cbEmpresa.SelectedValue == null)
                    {
                        MessageBox.Show("Informe a Empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    {
                        MessageBox.Show("Informe a Tabela de Preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(CD_CompVend.Text))
                {
                    //Verificar se o tipo de pedido comissiona vendedor
                    obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "isnull(a.st_comissaoped, 'N') = 'S' or isnull(a.st_comissaofat, 'N') = 'S'"
                                }
                            }, "1");
                    if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                    {
                        MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_CompVend.Focus();
                        return;
                    }
                }
            }
            using (TFLan_Itens_Faturamento Lan_Itens = new TFLan_Itens_Faturamento())
            {
                Lan_Itens.st_servico = st_servico.Checked;
                Lan_Itens.St_deposito = st_deposito.Checked;
                Lan_Itens.CD_TabelaPreco =
                Lan_Itens.CD_TabelaPreco = CD_TabelaPreco.Text;
                Lan_Itens.CD_Empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                Lan_Itens.Nm_empresa = (cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa);
                Lan_Itens.Cd_cliente = CD_Clifor.Text;
                Lan_Itens.Cd_vendedor = CD_CompVend.Text;
                Lan_Itens.st_Commodities = false;
                Lan_Itens.Cfg_pedido = CFG_Pedido.Text;
                Lan_Itens.St_integraralmox = st_integraralmox.Checked;
                Lan_Itens.pTp_movimento = TP_Mov.Text.Trim();
                if (Lan_Itens.ShowDialog() == DialogResult.OK)
                    if (Lan_Itens.rItem != null)
                    {
                        //Buscar Promocao
                        BuscarPromocao(Lan_Itens.rItem);
                        (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(Lan_Itens.rItem);
                        BS_Pedido.ResetCurrentItem();
                        TotalizarPedido();
                    }
            };
            AddCarrinho();

        }

        private void AlterarItem()
        {
            if (TP_Mov.Text.Trim().ToUpper().Equals("S"))
            {
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                     null))
                {
                    if (cbEmpresa.SelectedValue == null)
                    {
                        MessageBox.Show("Informe a Empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    {
                        MessageBox.Show("Informe a Tabela de Preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(CD_CompVend.Text))
                {
                    //Verificar se o tipo de pedido comissiona vendedor
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                             new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "isnull(a.st_comissaoped, 'N') = 'S' or isnull(a.st_comissaofat, 'N') = 'S'"
                                }
                            }, "1");
                    if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                    {
                        MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_CompVend.Focus();
                        return;
                    }
                }
            }
            if (BS_Itens.Current != null)
            {
                using (TFLan_Itens_Faturamento Lan_Itens = new TFLan_Itens_Faturamento())
                {
                    //Verificar se o item tem conferencia processada
                    object obj = new CamadaDados.Faturamento.Pedido.TCD_EntregaPedido().BuscarEscalar(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Nr_PedidoString
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_pedidoitem",
                            vOperador = "=",
                            vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        }
                    }, "1");
                    Lan_Itens.Quantidade.Enabled = obj == null;
                    //Verificar se o item tem ordem producao
                    obj = new CamadaDados.Producao.Producao.TCD_OrdemProducao_X_PedItem().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Nr_PedidoString
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_pedidoitem",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString()
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim() + "'"
                                }
                            }, "1");
                    Lan_Itens.Quantidade.Enabled = obj == null;
                    Lan_Itens.CD_Produto.Enabled = false;

                    Lan_Itens.rItem = BS_Itens.Current as TRegistro_LanPedido_Item;
                    Lan_Itens.st_alterar = true;
                    Lan_Itens.st_servico = st_servico.Checked;
                    Lan_Itens.St_deposito = st_deposito.Checked;
                    Lan_Itens.CD_TabelaPreco = CD_TabelaPreco.Text;
                    Lan_Itens.CD_Empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                    Lan_Itens.Nm_empresa = (cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa);
                    Lan_Itens.Cd_cliente = CD_Clifor.Text;
                    Lan_Itens.Cd_vendedor = CD_CompVend.Text;
                    Lan_Itens.Cfg_pedido = CFG_Pedido.Text;
                    Lan_Itens.St_integraralmox = st_integraralmox.Checked;
                    string _CD_Produto = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto;
                    string _DS_Produto = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_produto;
                    string _CD_Unidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_unidade_valor;
                    string _DS_Unidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_unidade_valor;
                    string _SG_UniQTD = (BS_Itens.Current as TRegistro_LanPedido_Item).Sg_unidade_valor;
                    string _CD_Local = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_local;
                    string _DS_Local = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_local;
                    string _DS_Observacao = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_observacaoitem;

                    decimal _Quantidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Quantidade;
                    decimal _Vl_Unitario = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_unitario;
                    decimal _Sub_Total = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_subtotal;
                    decimal _Frete_Item = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_freteitem;
                    decimal _Pc_DescontoItem = (BS_Itens.Current as TRegistro_LanPedido_Item).Pc_desc;
                    decimal _VL_Desconto = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_desc;
                    Lan_Itens.pTp_movimento = TP_Mov.Text.Trim();
                    if (Lan_Itens.ShowDialog() == DialogResult.OK)
                    {
                        BS_Itens.ResetCurrentItem();
                        //Verificar se item possui promocao
                        CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                        CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue.ToString(),
                                                                                                    Lan_Itens.rItem.Cd_produto,
                                                                                                    Lan_Itens.rItem.Cd_grupo,
                                                                                                    null,
                                                                                                    decimal.Zero,
                                                                                                    null);
                        if (rPro != null)
                            if (rPro.Qtd_minimavenda > 1)
                                if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals(Lan_Itens.rItem.Cd_produto.Trim())).Sum(p => p.Quantidade) < rPro.Qtd_minimavenda)
                                {
                                    //Verificar se tem programacao especial de venda
                                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                        CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(cbEmpresa.SelectedValue.ToString(),
                                                                                                                     CD_Clifor.Text,
                                                                                                                     Lan_Itens.rItem.Cd_produto,
                                                                                                                     CD_TabelaPreco.Text,
                                                                                                                     null);
                                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals(Lan_Itens.rItem.Cd_produto.Trim())).ToList().ForEach(p =>
                                    {
                                        if (rProgAux != null)
                                        {
                                            if (rProgAux.Valor > decimal.Zero)
                                            {
                                                if (rProgAux.Tp_valor.Trim().ToUpper().Equals("V"))
                                                {
                                                    p.Vl_desc = p.Quantidade * rProgAux.Valor;
                                                    p.Pc_desc = p.Vl_desc * 100 / p.Vl_subtotal;
                                                    p.VL_Total_Item = p.Vl_subtotal + p.Vl_freteitem + p.Vl_juro_fin - p.Vl_desc;
                                                }
                                                else
                                                {
                                                    p.Vl_desc = p.Vl_subtotal * rProgAux.Valor / 100;
                                                    p.Pc_desc = rProgAux.Valor;
                                                    p.VL_Total_Item = p.Vl_subtotal + p.Vl_freteitem + p.Vl_juro_fin - p.Vl_desc;
                                                }
                                            }
                                            else
                                            {
                                                p.Vl_desc = decimal.Zero;
                                                p.Pc_desc = decimal.Zero;
                                                p.VL_Total_Item = p.Vl_subtotal + p.Vl_freteitem + p.Vl_juro_fin - p.Vl_desc;
                                            }
                                        }
                                        else
                                        {
                                            p.Vl_desc = decimal.Zero;
                                            p.Pc_desc = decimal.Zero;
                                            p.VL_Total_Item = p.Vl_subtotal + p.Vl_freteitem + p.Vl_juro_fin - p.Vl_desc;
                                        }
                                    });
                                    BS_Pedido.ResetCurrentItem();
                                }
                                else
                                    BuscarPromocao(BS_Itens.Current as TRegistro_LanPedido_Item);
                        TotalizarPedido();
                    }
                    else
                    {
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto = _CD_Produto;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_produto = _DS_Produto;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_unidade_valor = _CD_Unidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_unidade_valor = _DS_Unidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Sg_unidade_valor = _SG_UniQTD;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_local = _CD_Local;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_local = _DS_Local;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_observacaoitem = _DS_Observacao;

                        (BS_Itens.Current as TRegistro_LanPedido_Item).Quantidade = _Quantidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_unitario = _Vl_Unitario;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_subtotal = _Sub_Total;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_freteitem = _Frete_Item;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Pc_desc = _Pc_DescontoItem;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_desc = _VL_Desconto;
                    }
                };
            }
        }

        private void ExcluirItem()
        {
            if (BS_Itens.Current != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                {
                    //Verificar se o tipo de pedido exige conferencia
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cfg_pedido",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CFG_Pedido.Text.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.ST_ExigirConferenciaEntrega, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, "1") != null)
                    {
                        //Verificar se o item tem conferencia processada
                        if (new CamadaDados.Faturamento.Pedido.TCD_EntregaPedido().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Nr_PedidoString
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_pedidoitem",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString()
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                }
                            }, "1") != null)
                        {
                            MessageBox.Show("Não é permitido excluir item com conferência processada.", "Mensagem", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }
                    }
                    //Verificar se o item teve origem ordem compra
                    if (new CamadaDados.Compra.Lancamento.TCD_OrdemCompra_X_PedItem().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = (BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Nr_PedidoString
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'"+(BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto.Trim()+"'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_pedidoitem",
                                vOperador = "=",
                                vVL_Busca = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString()
                            }
                        }, "a.id_oc") != null)
                    {
                        if (!(MessageBox.Show("Item do pedido foi gerado apartir da ordem de compra.\r\n" +
                                        "A exclusão do item ira abrir novamente a ordem de compra.\r\n" +
                                        "Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                            return;
                    }

                    (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedido_Itens.Add(BS_Itens.Current as TRegistro_LanPedido_Item);
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue.ToString(),
                                                                                                (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto,
                                                                                                (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_grupo,
                                                                                                null,
                                                                                                decimal.Zero,
                                                                                                null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) -
                                (BS_Itens.Current as TRegistro_LanPedido_Item).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(cbEmpresa.SelectedValue.ToString(),
                                                                                                                 CD_Clifor.Text,
                                                                                                                 (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto,
                                                                                                                 CD_TabelaPreco.Text,
                                                                                                                 null);
                                (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim())).ToList().ForEach(p =>
                                {
                                    if (rProgAux != null)
                                    {
                                        if (rProgAux.Valor > decimal.Zero)
                                        {
                                            if (rProgAux.Tp_valor.Trim().ToUpper().Equals("V"))
                                            {
                                                p.Vl_desc = p.Quantidade * rProgAux.Valor;
                                                p.Pc_desc = p.Vl_desc * 100 / p.Vl_subtotal;
                                                p.VL_Total_Item = p.Vl_subtotal + p.Vl_juro_fin + p.Vl_freteitem - p.Vl_desc;
                                            }
                                            else
                                            {
                                                p.Vl_desc = p.Vl_subtotal * rProgAux.Valor / 100;
                                                p.Pc_desc = rProgAux.Valor;
                                                p.VL_Total_Item = p.Vl_subtotal + p.Vl_juro_fin + p.Vl_freteitem - p.Vl_desc;
                                            }
                                        }
                                        else
                                        {
                                            p.Vl_desc = decimal.Zero;
                                            p.Pc_desc = decimal.Zero;
                                            p.VL_Total_Item = p.Vl_subtotal + p.Vl_juro_fin + p.Vl_freteitem - p.Vl_desc;
                                        }
                                    }
                                    else
                                    {
                                        p.Vl_desc = decimal.Zero;
                                        p.Pc_desc = decimal.Zero;
                                        p.VL_Total_Item = p.Vl_subtotal + p.Vl_juro_fin + p.Vl_freteitem - p.Vl_desc;
                                    }
                                });
                                BS_Pedido.ResetCurrentItem();
                            }
                    BS_Itens.RemoveCurrent();
                    TotalizarPedido();
                }
            }
        }

        private void TotalizarPedido()
        {
            if (BS_Pedido.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Count > 0)
                {
                    //Somar Impostos
                    (BS_Pedido.Current as TRegistro_Pedido).Tot_subst = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_subst);
                    (BS_Pedido.Current as TRegistro_Pedido).Tot_ipi = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_IPI);
                    //Ratear frete
                    TCN_Pedido.Rateia_Frete(BS_Pedido.Current as TRegistro_Pedido);
                    if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p => p.Pc_desc > decimal.Zero))
                        Pc_DescGeral.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Pc_desc > decimal.Zero).Average(p => p.Pc_desc);
                    else
                        Pc_DescGeral.Value = decimal.Zero;
                    VL_Desconto_Geral.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_desc);
                    vl_frete.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_freteitem);
                    vl_acrescimo.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_acrescimo);
                }
                else
                {
                    Pc_DescGeral.Value = Pc_DescGeral.Minimum;
                    VL_Desconto_Geral.Value = VL_Desconto_Geral.Minimum;
                    vl_frete.Value = vl_frete.Minimum;
                    vl_acrescimo.Value = vl_acrescimo.Minimum;
                }
                BS_Pedido.ResetCurrentItem();
            }
        }


        private void Habilita_Data_Financeiro()
        {
            if (BS_Pedido.Current != null)
                edtDt_Vencto.Enabled = (BS_Pedido.Current as TRegistro_Pedido).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S") &&
                    (ST_ComEntrada.Checked ? BS_Parcelas.Position > 0 : true);
        }

        private void AjustarDadosFinanceiros()
        {
            if (BS_Pedido.Current != null)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto_X_Parcelas().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_condpgto",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_CondPGTO.Text + "'"
                            }
                        }, " 1");
                Habilita_Data_Financeiro();
                if (!ST_ComEntrada.Checked)
                {
                    TCN_Pedido.Calcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido);
                    BS_Pedido.ResetCurrentItem();
                    BS_Parcelas_PositionChanged(this, new EventArgs());
                }

                else if (ST_ComEntrada.Checked && obj != null)
                {
                    VL_Entrada.Enabled = false;
                    TCN_Pedido.Calcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido);
                    BS_Pedido.ResetCurrentItem();
                    BS_Parcelas_PositionChanged(this, new EventArgs());
                }

                else
                {
                    VL_Entrada.Enabled = true;
                    (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.ForEach(p => (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedidos_DT_Vencto.Add(p));
                    (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.Clear();
                    BS_Pedido.ResetCurrentItem();
                }
            }
        }

        private void CalcularValorPedidoItem()
        {
            if (BS_Pedido.Current != null)
                (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.CalcularValorJuroFin(
                                                                                                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto()
                                                                                                            {
                                                                                                                Pc_jurodiario_atrazoFin = (BS_Pedido.Current as TRegistro_Pedido).Pc_jurodiario_atrazo,
                                                                                                                Tp_juro_fin = (BS_Pedido.Current as TRegistro_Pedido).Tp_juro,
                                                                                                                Qt_diasdesdobro = (BS_Pedido.Current as TRegistro_Pedido).Qt_diasdesdobro,
                                                                                                                St_comentradabool = (BS_Pedido.Current as TRegistro_Pedido).St_cometrada,
                                                                                                                Qt_parcelas = (BS_Pedido.Current as TRegistro_Pedido).QTD_Parcelas
                                                                                                            },
                                                                                                            p.Vl_subtotal_semjuros));
        }

        private void SimularImpostos()
        {
            using (TFSimuladorImpostos fSimular = new TFSimuladorImpostos())
            {
                fSimular.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                fSimular.pNm_empresa = cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                fSimular.pCfg_pedido = CFG_Pedido.Text;
                fSimular.pDs_tipopedido = DS_CFGPedido.Text;
                fSimular.pTp_mov = TP_Mov.Text;
                fSimular.pCd_clifor = CD_Clifor.Text;
                fSimular.pNm_clifor = NM_Clifor.Text;
                fSimular.pCd_endereco = CD_Endereco.Text;
                fSimular.pDs_endereco = DS_Endereco.Text;
                fSimular.pCd_municipioexecservico = cd_municipioexecservico.Text;
                fSimular.St_calcavulso = false;
                if (BS_Pedido.Current != null)
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                        {
                            fSimular.lProdSimular.Add(
                                new CamadaDados.Fiscal.TRegistro_ProdutoSimular()
                                {
                                    Cd_produto = p.Cd_produto,
                                    Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                    Ds_condfiscal_produto = p.Ds_condfiscal_produto,
                                    Ds_produto = p.Ds_produto,
                                    Quantidade = p.Quantidade,
                                    Sg_unidade = p.Sg_unidade_est,
                                    Vl_unitario = p.Vl_unitario
                                });
                        });
                if (fSimular.ShowDialog() == DialogResult.OK)
                {
                    (BS_Pedido.Current as TRegistro_Pedido).lImpostoPedido = fSimular.lResumo;
                    if (((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() != fSimular.Cd_empresasimular.Trim()) &&
                        string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco))
                        if (MessageBox.Show("Deseja trocar empresa do pedido para a empresa da simulação imposto?", "Pergunta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cbEmpresa.SelectedValue = fSimular.Cd_empresasimular;
                            cbEmpresa_SelectedIndexChanged(this, new EventArgs());
                        }
                    if ((BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() != fSimular.Cfg_pedidosimular.Trim())
                        if (MessageBox.Show("Deseja trocar tipo pedido do pedido para o tipo pedido da simulação imposto?", "Pergunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            CFG_Pedido.Text = fSimular.Cfg_pedidosimular;
                            CFG_Pedido_Leave(this, new EventArgs());
                        }
                    BS_Pedido.ResetCurrentItem();
                }
            }
        }

        private bool ValidarDescontos()
        {
            if (DialogResult == DialogResult.Cancel)
                return false;
            if ((Pc_descOld > decimal.Zero) && Pc_descOld.Equals(Pc_DescGeral.Value))
                return true;
            if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S") &&
                (!string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).Cd_vendedor)))
            {
                for (int i = 0; i < ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Count); i++)
                {
                    //Buscar lista de descontos configuradas para o vendedor
                    CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                        CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                        cbEmpresa.SelectedValue.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    if (lDesc.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                p.Cd_grupo.Trim().Equals((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo.Trim())).Pc_max_desconto;
                                if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                    Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (BS_Pedido.Current as TRegistro_Pedido).Vl_totalItens;
                                if (Pc_DescGeral.Value > pc_max_desc)
                                {
                                    MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_grupo = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo;
                                        fLogin.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                        fLogin.Pc_desc = Pc_DescGeral.Value;
                                        if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                            return false;
                                        else
                                        {
                                            LoginDesconto = fLogin.Logindesconto;
                                            return true;
                                        }
                                    }
                                }
                                else return true;
                            }
                            else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                            {
                                //Desconto por tabela de preço
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                                if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                    Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (BS_Pedido.Current as TRegistro_Pedido).Vl_totalItens;
                                if (Pc_DescGeral.Value > pc_max_desc)
                                {
                                    MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                        fLogin.Pc_desc = Pc_DescGeral.Value;
                                        if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                            return false;
                                        else
                                        {
                                            LoginDesconto = fLogin.Logindesconto;
                                            return true;
                                        }
                                    }
                                }
                                else return true;
                            }
                        //Desconto por grupo de produto
                        if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo.Trim())))
                        {
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (BS_Pedido.Current as TRegistro_Pedido).Vl_totalItens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_grupo = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens[i].Cd_grupo;
                                    fLogin.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        //Desconto por vendedor e empresa
                        if (Pc_DescGeral.Value > lDesc[0].Pc_max_desconto)
                        {
                            MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                fLogin.Pc_desc = Pc_DescGeral.Value;
                                if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    return false;
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    else return true;
                }
                return true;
            }
            else
                return true;
        }

        private void AddCarrinho()
        {
            if (BS_Itens.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto,
                                                                                            string.Empty,
                                                                                            null);
                if (lAssistente.Count > 0)
                {
                    using (TFAssistenteVenda fAssistente = new TFAssistenteVenda())
                    {
                        fAssistente.lAssistente = lAssistente;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(
                                    new TRegistro_LanPedido_Item()
                                    {
                                        Cd_produto = p.CD_ProdVenda,
                                        Ds_produto = p.DS_ProdVenda,
                                        Cd_unidade_est = p.CD_Unidade,
                                        Ds_unidade_est = p.DS_Unidade,
                                        Sg_unidade_est = p.Sigla_Unidade,
                                        Cd_unidade_valor = p.CD_Unidade,
                                        Ds_unidade_valor = p.DS_Unidade,
                                        Sg_unidade_valor = p.Sigla_Unidade,
                                        Ds_marca = p.DS_Marca,
                                        ncm = p.NCM,
                                        Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rPedido.CD_Empresa, p.CD_ProdVenda, rPedido.Cd_tabelapreco, null),
                                        Quantidade = p.Quantidade,
                                    }));
                                BS_Pedido.ResetCurrentItem();
                            }
                    }
                }
            }
        }

        //atualiza gride historico de pedidos
        private void atualiza_historico()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text.ToString().Trim())
                && cbEmpresa.SelectedItem != null
                && !string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                try
                {
                    BS_Historico.DataSource = new TCD_LanPedido_Item().Select(
                                              new Utils.TpBusca[]
                                              {
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "isnull(n.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "isnull(n.st_pedido, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "n.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa + "'"
                                                },
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "n.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                                },
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca
                                                {
                                                    vNM_Campo = "n.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + TP_Mov.Text.Trim() + "'"
                                                }
                                              }, 0, string.Empty, string.Empty, "n.dt_pedido desc");
                }
                catch { }
            }
        }

        private void BuscarPromocao(TRegistro_LanPedido_Item rItem)
        {
            if (rItem != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue.ToString(),
                                                                                                rItem.Cd_produto,
                                                                                                rItem.Cd_grupo,
                                                                                                null,
                                                                                                decimal.Zero,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).Sum(p => p.Quantidade) + rItem.Quantidade >= rPro.Qtd_minimavenda)
                        {
                            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    p.Pc_desc = rPro.Vl_promocao;
                                    //Calcular desconto
                                    p.Vl_desc = p.Vl_subtotal * (rPro.Vl_promocao / 100);
                                    rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                                }
                                else
                                {
                                    p.Vl_desc = rPro.Vl_promocao * p.Quantidade;
                                    //Calcular % Desconto
                                    p.Pc_desc = p.Vl_desc * 100 / p.Vl_subtotal;
                                    rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                                }
                            });
                            //Calcular item atual
                            if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                            {
                                rItem.Pc_desc = rPro.Vl_promocao;
                                //Calcular desconto
                                rItem.Vl_desc = rItem.Vl_subtotal * (rPro.Vl_promocao / 100);
                                rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                            }
                            else
                            {
                                rItem.Vl_desc = rPro.Vl_promocao * rItem.Quantidade;
                                //Calcular % Desconto
                                rItem.Pc_desc = rItem.Vl_desc * 100 / rItem.Vl_subtotal;
                                rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                            }
                        }
                        else
                        {
                            rItem.Vl_desc = decimal.Zero;
                            rItem.Pc_desc = decimal.Zero;
                            rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            rItem.Pc_desc = rPro.Vl_promocao;
                            //Calcular desconto
                            rItem.Vl_desc = rItem.Vl_subtotal * (rPro.Vl_promocao / 100);
                            rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                        }
                        else
                        {
                            rItem.Vl_desc = rPro.Vl_promocao * rItem.Quantidade;
                            //Calcular % Desconto
                            rItem.Pc_desc = rItem.Vl_desc * 100 / rItem.Vl_subtotal;
                            rItem.VL_Total_Item = rItem.Vl_subtotal + rItem.Vl_freteitem + rItem.Vl_juro_fin - rItem.Vl_desc;
                        }
                    }
            }
        }

        private void BuscarRepresentante(string id_regiao)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                    new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_regiao",
                        vOperador = "=",
                        vVL_Busca = "'" + id_regiao.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "b.st_representante",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, "a.cd_vendedor");

                if (obj != null)
                {
                    cd_representante.Text = obj.ToString();
                    cd_representante_Leave(this, new EventArgs());
                }
                else
                {
                    cd_representante.Text = string.Empty;
                    nm_representante.Text = string.Empty;
                }
            }
        }

        private bool VerificarTotDesconto(TRegistro_Pedido val)
        {
            if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S"))
                for (int i = 0; i < (val.Pedido_Itens.Count); i++)
                {
                    //Buscar lista de descontos configuradas para o vendedor
                    CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                        CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                        cbEmpresa.SelectedValue.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    if (lDesc.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                            if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                p.Cd_grupo.Trim().Equals(val.Pedido_Itens[i].Cd_grupo.Trim())))
                            {
                                //Desconto por tabela de preco e grupo de produto
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                        p.Cd_grupo.Trim().Equals(val.Pedido_Itens[i].Cd_grupo.Trim())).Pc_max_desconto;
                                if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                    Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalItens;
                                if (Pc_DescGeral.Value > pc_max_desc)
                                {
                                    MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_grupo = val.Pedido_Itens[i].Cd_grupo;
                                        fLogin.Cd_empresa = val.CD_Empresa;
                                        fLogin.Pc_desc = Pc_DescGeral.Value;
                                        if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                            return false;
                                        else
                                        {
                                            LoginDesconto = fLogin.Logindesconto;
                                            return true;
                                        }
                                    }
                                }
                                else return true;
                            }
                            else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                            {
                                //Desconto por tabela de preço
                                decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                                if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                    Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalItens;
                                if (Pc_DescGeral.Value > pc_max_desc)
                                {
                                    MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                    {
                                        fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                        fLogin.Cd_empresa = val.CD_Empresa;
                                        fLogin.Pc_desc = Pc_DescGeral.Value;
                                        if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                            return false;
                                        else
                                        {
                                            LoginDesconto = fLogin.Logindesconto;
                                            return true;
                                        }
                                    }
                                }
                                else return true;
                            }
                        //Desconto por grupo de produto
                        if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.Pedido_Itens[i].Cd_grupo.Trim())))
                        {
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.Pedido_Itens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalItens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_grupo = val.Pedido_Itens[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.CD_Empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        //Desconto por vendedor e empresa
                        if (Pc_DescGeral.Value > lDesc[0].Pc_max_desconto)
                        {
                            MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_empresa = val.CD_Empresa;
                                fLogin.Pc_desc = Pc_DescGeral.Value;
                                if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    return false;
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    else return true;
                }
            return true;
        }

        private void TFPedido_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Pedido.set_FormatZero();
            pCondPgto.set_FormatZero();
            pEntrega.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            Alterar();
            //Deletar Parcelas
            (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.ForEach(p =>
                (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedidos_DT_Vencto.Add(p));
            if (!St_editar)
            {
                pnl_Pedido.Enabled = false;
                pCondPgto.Enabled = false;
                pParcelas.Enabled = false;
                TS_ItensPedido.Enabled = false;
                ds_observacao.Enabled = false;
                pDadosComp.Enabled = false;
                bb_inutilizar.Enabled = false;
            }
            corrigirDadosRepresentanteToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CORRIGIR REPRESENTANTE PEDIDO", null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;" +
                                                       "TP_Movimento|Movimento|50;" +
                                                       "a.CFG_Pedido|CD. CFG Pedido|80;" +
                                                       "ST_Servico|Servico|50;" +
                                                       "a.st_integraralmox|Integrar Almox.|80;" +
                                                       "A.st_ValoresFixos|Permitir valores fixos|50;" +
                                                       "a.st_fecharpedidoauto|Fechar Pedido Automaticamente|50",
                            new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
            if (linha != null)
            {
                cb_valoresfixos.Checked = linha["st_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                st_comissaoPed.Checked = linha["ST_ComissaoPed"].ToString().Trim().ToUpper().Equals("S");
                st_comissaoFat.Checked = linha["St_comissaoFat"].ToString().Trim().ToUpper().Equals("S");
                st_servico.Checked = linha["ST_Servico"].ToString().Trim().ToUpper().Equals("S");
                st_deposito.Checked = linha["st_deposito"].ToString().Trim().ToUpper().Equals("S");
                st_integraralmox.Checked = linha["st_integraralmox"].ToString().Trim().ToUpper().Equals("S");
                CD_TabelaPreco.Enabled = linha["TP_Movimento"].ToString().Trim().ToUpper().Equals("S");
                BB_TabelaPreco.Enabled = linha["TP_Movimento"].ToString().Trim().ToUpper().Equals("S");
                lblClifor.Text = linha["TP_Movimento"].ToString().Trim().ToUpper().Equals("E") ? "Fornecedor:" : "Cliente:";

                lblAgente.Text = (TP_Mov.Text.Trim().ToUpper().Equals("S") ? "Vendedor:" : "Comprador:");
                cd_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");
                bb_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");
                nm_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");

                CD_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
                BB_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
                NM_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
            }
            if (TP_Mov.Text.Trim().ToUpper().Equals("E") && string.IsNullOrEmpty(cd_comprador.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lComp =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                        "where x.cd_clifor_cmp = a.cd_clifor " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        }
                    }, 1, string.Empty);
                if (lComp.Count > 0)
                {
                    cd_comprador.Text = lComp[0].Cd_clifor;
                    nm_comprador.Text = lComp[0].Nm_clifor;
                }
            }
            atualiza_historico();
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
            if (linha != null)
            {
                cb_valoresfixos.Checked = linha["st_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                st_comissaoPed.Checked = linha["ST_ComissaoPed"].ToString().Trim().ToUpper().Equals("S");
                st_comissaoFat.Checked = linha["St_comissaoFat"].ToString().Trim().ToUpper().Equals("S");
                st_servico.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                st_deposito.Checked = linha["st_deposito"].ToString().Trim().ToUpper().Equals("S");
                st_integraralmox.Checked = linha["st_integraralmox"].ToString().Trim().ToUpper().Equals("S");
                CD_TabelaPreco.Enabled = linha["tp_movimento"].ToString().Trim().ToUpper().Equals("S");
                BB_TabelaPreco.Enabled = linha["tp_movimento"].ToString().Trim().ToUpper().Equals("S");
                lblClifor.Text = linha["tp_movimento"].ToString().Trim().ToUpper().Equals("E") ? "Fornecedor:" : "Cliente:";

                lblAgente.Text = (TP_Mov.Text.Trim().ToUpper().Equals("S") ? "Vendedor:" : "Comprador:");
                cd_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");
                bb_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");
                nm_comprador.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");

                CD_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
                BB_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
                NM_CompVend.Visible = TP_Mov.Text.Trim().ToUpper().Equals("S");
            }
            if (TP_Mov.Text.Trim().ToUpper().Equals("E") && string.IsNullOrEmpty(cd_comprador.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lComp =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                        "where x.cd_clifor_cmp = a.cd_clifor " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        }
                    }, 1, string.Empty);
                if (lComp.Count > 0)
                {
                    cd_comprador.Text = lComp[0].Cd_clifor;
                    nm_comprador.Text = lComp[0].Nm_clifor;
                }
            }
            atualiza_historico();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1");
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParam);
            CD_Endereco.Text = string.Empty;
            DS_Endereco.Text = string.Empty;
            DS_Cidade.Text = string.Empty;
            UF.Text = string.Empty;
            CD_TabelaPreco.Clear();
            NM_TabelaPreco.Clear();
            Busca_Endereco_Clifor();
            //Buscar Representante
            if (linha != null)
                BuscarRepresentante(linha["id_regiao"].ToString());
            TCN_Pedido.Consulta_Dados_Clifor((BS_Pedido.Current as TRegistro_Pedido));
            BS_Pedido.ResetCurrentItem();
            atualiza_historico();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'";
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1");
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CD_Endereco.Text = string.Empty;
            DS_Endereco.Text = string.Empty;
            DS_Cidade.Text = string.Empty;
            UF.Text = string.Empty;
            CD_TabelaPreco.Clear();
            NM_TabelaPreco.Clear();
            TCN_Pedido.Consulta_Dados_Clifor((BS_Pedido.Current as TRegistro_Pedido));
            BS_Pedido.ResetCurrentItem();



            Busca_Endereco_Clifor();
            //Buscar Representante
            if (linha != null)
                BuscarRepresentante(linha["id_regiao"].ToString());

            //atualiza gride historico
            atualiza_historico();
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF }, "a.cd_clifor|=|'" + CD_Clifor.Text + "'");
        }

        private void BB_Moeda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Moeda_Singular|Moeda|200;Sigla|Sigla|80;CD_Moeda|Cód. Moeda|80"
                                     , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                                     new CamadaDados.Financeiro.Cadastros.TCD_Moeda(),
                                     string.Empty);
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Moeda|=|'" + CD_Moeda.Text.Trim() + "'"
                            , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                            new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void cd_comprador_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor_cmp|=|'" + cd_comprador.Text.Trim() + "';" +
                              "||((a.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos x " +
                              "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_comprador, nm_comprador },
                                    new CamadaDados.Compra.TCD_CadUsuarioCompra());
        }

        private void bb_comprador_Click(object sender, EventArgs e)
        {
            string vColunas = "c.nm_clifor|Nome Comprador|250;" +
                              "a.cd_clifor_cmp|Cd. Comprador|80";

            string vParam = "||((a.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos x " +
                            "         where x.logingrp = a.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_comprador, nm_comprador },
                                    new CamadaDados.Compra.TCD_CadUsuarioCompra(), vParam);
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cd_representante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_representante.Text.Trim() + "';" +
                            "isnull(a.st_representante, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_representante, nm_representante },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_representante, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_representante, nm_representante },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_vendedor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            //Verificar se cliente possui Tab Preco
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += (string.IsNullOrEmpty(vParam) ? string.Empty : ";") +
                              "|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                       , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                       new CamadaDados.Diversos.TCD_CadTbPreco(),
                                       vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_vendedor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            //Verificar se cliente possui Tab Preco
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void btn_Transportadora_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Transportadora, NM_Transportadora }, string.Empty);

            CD_EnderecoTransp.Text = string.Empty;
            DS_Endereco_Transp.Text = string.Empty;
            DS_Cidade_Transp.Text = string.Empty;
            UF_Transp.Text = string.Empty;

            Busca_Endereco_Transportadora();
        }

        private void CD_Transportadora_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Transportadora.Text + "'"
                    , new Componentes.EditDefault[] { CD_Transportadora, NM_Transportadora },
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CD_EnderecoTransp.Text = string.Empty;
            DS_Endereco_Transp.Text = string.Empty;
            DS_Cidade_Transp.Text = string.Empty;
            UF_Transp.Text = string.Empty;

            Busca_Endereco_Transportadora();
        }

        private void btn_Endereco_Transp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150"
                                , new Componentes.EditDefault[] { CD_EnderecoTransp, DS_Endereco_Transp, DS_Cidade_Transp, UF_Transp },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Transportadora.Text + "'");
        }

        private void CD_EnderecoTransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_EnderecoTransp.Text + "';a.cd_clifor|=|'" + CD_Transportadora.Text + "'"
                    , new Componentes.EditDefault[] { CD_EnderecoTransp, DS_Endereco_Transp, DS_Cidade_Transp, UF_Transp },
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void TFPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (St_editar && e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                SimularImpostos();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItem();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItem();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F8))
                codBarras();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void cck_Soma_Frete_Intens_Click(object sender, EventArgs e)
        {
            TotalizarPedido();
        }

        private void VL_Entrada_Leave(object sender, EventArgs e)
        {
            TCN_Pedido.Calcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido);

            for (int x = 0; x < (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.Count; x++)
            {
                (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Entrada = VL_Entrada.Value;
                if (x == 0)
                    (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Parcela = VL_Entrada.Value;
            }

            TCN_Pedido.Recalcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido, 0);
            BS_Pedido.ResetCurrentItem();
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (CD_CondPGTO.Enabled)
            {
                (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[BS_Parcelas.Position].VL_Parcela = VL_Parcela.Value;
                TCN_Pedido.Recalcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido, BS_Parcelas.Position);
                BS_Parcelas.ResetBindings(true);
            }
        }

        private void BS_Parcelas_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Parcelas.Current != null)
            {
                if (ST_ComEntrada.Checked)
                {
                    if (BS_Parcelas.Position.Equals(0))
                    {
                        edtDt_Vencto.Enabled = false;
                        VL_Parcela.Enabled = false;
                    }
                    else
                    {
                        Habilita_Data_Financeiro();
                        VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1); ;
                    }
                }
                else
                {
                    Habilita_Data_Financeiro();
                    VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1);
                }
            }
        }

        private void Pc_DescGeral_Leave(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                if (VerificarTotDesconto(BS_Pedido.Current as TRegistro_Pedido))
                {
                    (BS_Pedido.Current as TRegistro_Pedido).Pc_descgeral = Pc_DescGeral.Value;
                    TCN_Pedido.Rateia_Desconto_Itens(BS_Pedido.Current as TRegistro_Pedido, true);
                    TotalizarPedido();
                }
                else
                {
                    Pc_DescGeral.Value = decimal.Zero;
                    VL_Desconto_Geral.Value = decimal.Zero;
                    Pc_DescGeral.Focus();
                }
        }

        private void VL_Desconto_Geral_Leave(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                (BS_Pedido.Current as TRegistro_Pedido).Vl_descontogeral = VL_Desconto_Geral.Value;
                TCN_Pedido.Rateia_Desconto_Itens(BS_Pedido.Current as TRegistro_Pedido, false);
                TotalizarPedido();
                if (!VerificarTotDesconto(BS_Pedido.Current as TRegistro_Pedido))
                {
                    Pc_DescGeral.Value = decimal.Zero;
                    VL_Desconto_Geral.Value = decimal.Zero;
                    VL_Desconto_Geral.Focus();
                }
            }
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            if (Cd_condPagtoOld.Trim().Equals(CD_CondPGTO.Text.Trim()))
                return;
            string vParam = "CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "'";
            object obj = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                          "             where x.cd_condpgto = a.cd_condpgto " +
                          "             and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                Parcelas.Value = Convert.ToDecimal(linha["qt_parcelas"].ToString());
                QT_DIASDESDOBRO.Value = Convert.ToDecimal(linha["qt_diasdesdobro"].ToString());
                ST_ComEntrada.Checked = linha["st_comentrada"].ToString().Trim().ToUpper().Equals("S");
                cd_juro_fin.Text = linha["cd_juro_fin"].ToString();
                ds_juro_fin.Text = linha["ds_juro_fin"].ToString();
                PC_JuroDiario_Atrazo.Value = linha["pc_juroDiario_atrazoFin"].ToString().Equals("") ? 0 : Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                tp_juro.Text = linha["tp_juro"].ToString();
            }
            else
            {
                Parcelas.Value = 0;
                QT_DIASDESDOBRO.Value = 0;
                ST_ComEntrada.Checked = false;
                cd_juro_fin.Clear();
                ds_juro_fin.Clear();
                PC_JuroDiario_Atrazo.Value = 0;
                (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.ForEach(p => (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedidos_DT_Vencto.Add(p));
                (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.Clear();
                BS_Pedido.ResetCurrentItem();
            }
            if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S"))
                CalcularValorPedidoItem();
            AjustarDadosFinanceiros();
            TotalizarPedido();
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            Cd_condPagtoOld = CD_CondPGTO.Text;
            string vParam = string.Empty;
            //Verificar se condicao de pagamento para o vendedor
            object obj = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam = "|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                         "          where x.cd_condpgto = a.cd_condpgto " +
                         "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;a.QT_Parcelas|Quantidade Parcelas|40;" +
            "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;a.ST_VenctoEmFeriado|Vence em Feriado|40;a.cd_condPGTO|Código|100;a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            CD_CondPGTO_Leave(this, new EventArgs());
        }

        private void tot_liquido_ValueChanged(object sender, EventArgs e)
        {
            if (St_parcelas)
                CD_CondPGTO_Leave(this, new EventArgs());
            St_parcelas = true;
        }

        private void ST_ComEntrada_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_Entrada.Visible = ST_ComEntrada.Checked;
            VL_Entrada.Visible = ST_ComEntrada.Checked;
        }

        private void bb_calcula_Click(object sender, EventArgs e)
        {
            SimularImpostos();
        }

        private void bb_municipioexecservico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Municipio|200;" +
                              "a.cd_cidade|Cd. Municipio|80;" +
                              "a.distrito|Distrito|100;" +
                              "a.uf|UF|20;" +
                              "a.ds_uf|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_municipioexecservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipioexecservico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void vl_frete_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Vl_frete = vl_frete.Value;
            TCN_Pedido.Rateia_Frete(BS_Pedido.Current as TRegistro_Pedido);
            TotalizarPedido();
        }

        private void TFPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }

        private void CliforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
        }

        private void vl_acrescimo_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Vl_acrescimogeral = vl_acrescimo.Value;
            TCN_Pedido.Rateia_Acrescimo(BS_Pedido.Current as TRegistro_Pedido);
            TotalizarPedido();
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|60;" +
                              "b.uf|UF|30";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_cidadent_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadent.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text) || !string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent },
                    "a.cd_clifor|=|'" + (!string.IsNullOrEmpty(Cd_cliforent.Text) ? Cd_cliforent.Text : CD_Clifor.Text) + "'");
        }

        private void bb_cliforind_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, string.Empty);
        }

        private void cd_cliforind_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforind.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforind, nm_cliforind },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void Cd_cliforent_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + Cd_cliforent.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforEnt_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt }, string.Empty);
        }

        private void Cd_enderecoent_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text) || !string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + (!string.IsNullOrEmpty(Cd_cliforent.Text) ? Cd_cliforent.Text : CD_Clifor.Text) + "'"
                                                        , new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent },
                                                          new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
            {
                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(cbEmpresa.SelectedValue.ToString(), null);
                if (tabela != null)
                {
                    CD_Moeda.Text = tabela[0].Cd_moeda;
                    DS_Moeda.Text = tabela[0].Ds_moeda_singular;
                    Sigla_Moeda.Text = tabela[0].Sigla;
                }
            }
        }

        private void bb_gerente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_gerente, nm_gerente }, string.Empty);
        }

        private void cd_gerente_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_gerente.Text + "'", new Componentes.EditDefault[] { cd_gerente, nm_gerente },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void corrigirDadosRepresentanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S"))
                using (TFCorrigirRepresentante fCorrigir = new TFCorrigirRepresentante())
                {
                    fCorrigir.pCd_representante = (BS_Pedido.Current as TRegistro_Pedido).Cd_representante;
                    fCorrigir.pNm_representante = (BS_Pedido.Current as TRegistro_Pedido).Nm_representante;
                    fCorrigir.pPc_comrep = (BS_Pedido.Current as TRegistro_Pedido).Pc_comrep;
                    fCorrigir.pCd_cliforind = (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforind;
                    fCorrigir.pNm_cliforind = (BS_Pedido.Current as TRegistro_Pedido).Nm_cliforind;
                    fCorrigir.pCd_gerente = (BS_Pedido.Current as TRegistro_Pedido).Cd_gerente;
                    fCorrigir.pNm_gerente = (BS_Pedido.Current as TRegistro_Pedido).Nm_gerente;
                    if (fCorrigir.ShowDialog() == DialogResult.OK)
                    {
                        string pCd_representante = (BS_Pedido.Current as TRegistro_Pedido).Cd_representante;
                        string pNm_representante = (BS_Pedido.Current as TRegistro_Pedido).Nm_representante;
                        decimal pPc_comrep = (BS_Pedido.Current as TRegistro_Pedido).Pc_comrep;
                        string pCd_cliforind = (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforind;
                        string pNm_cliforind = (BS_Pedido.Current as TRegistro_Pedido).Nm_cliforind;
                        string pCd_gerente = (BS_Pedido.Current as TRegistro_Pedido).Cd_gerente;
                        string pNm_gerente = (BS_Pedido.Current as TRegistro_Pedido).Nm_gerente;
                        try
                        {
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_representante = fCorrigir.pCd_representante;
                            (BS_Pedido.Current as TRegistro_Pedido).Pc_comrep = fCorrigir.pPc_comrep;
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforind = fCorrigir.pCd_cliforind;
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_gerente = fCorrigir.pCd_gerente;
                            new TCD_Pedido().Gravar_Pedido(BS_Pedido.Current as TRegistro_Pedido);
                            MessageBox.Show("Pedido corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_representante = fCorrigir.pCd_representante;
                            (BS_Pedido.Current as TRegistro_Pedido).Nm_representante = fCorrigir.pNm_representante;
                            (BS_Pedido.Current as TRegistro_Pedido).Pc_comrep = fCorrigir.pPc_comrep;
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforind = fCorrigir.pCd_cliforind;
                            (BS_Pedido.Current as TRegistro_Pedido).Nm_cliforind = fCorrigir.pNm_cliforind;
                            (BS_Pedido.Current as TRegistro_Pedido).Cd_gerente = fCorrigir.pCd_gerente;
                            (BS_Pedido.Current as TRegistro_Pedido).Nm_gerente = fCorrigir.pNm_gerente;
                        }
                        BS_Pedido.ResetCurrentItem();
                    }
                }
        }

        private void CD_CondPGTO_Enter(object sender, EventArgs e)
        {
            Cd_condPagtoOld = CD_CondPGTO.Text;
        }

        private void TP_Mov_TextChanged(object sender, EventArgs e)
        {
            bbAnexarDocumento.Visible = TP_Mov.Text.Trim().ToUpper().Equals("E");
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).Anexo_compra != null)
                    bbAnexarDocumento.Text = "Excluir Documento Anexado";
                else bbAnexarDocumento.Text = "Anexar Documento";
        }

        private void bbAnexarDocumento_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).Anexo_compra != null)
                {
                    if (MessageBox.Show("Deletar Anexo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        (BS_Pedido.Current as TRegistro_Pedido).Anexo_compra = null;
                }
                else
                    using (OpenFileDialog file = new OpenFileDialog())
                    {
                        if (file.ShowDialog() == DialogResult.OK)
                            if (System.IO.File.Exists(file.FileName))
                                (BS_Pedido.Current as TRegistro_Pedido).Anexo_compra = System.IO.File.ReadAllBytes(file.FileName);
                    }
        }

        private void codBarras()
        {
            if (string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco))
            {
                MessageBox.Show("Erro: Não foi informado o código da tabela de preço. " +
                                "Não será possível finalizar a operação. Informe e tente novamente.",
                                "Informativo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                tcPedido.SelectedIndex = 0;
                CD_TabelaPreco.Select();
                return;
            }
            else if (string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa))
            {
                MessageBox.Show("Erro: Não foi informado o código da empresa. " +
                                "Não será possível finalizar a operação. Informe e tente novamente.",
                                "Informativo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                tcPedido.SelectedIndex = 0;
            }

            using (TFCodBarraProdutos fCodBarraProdutos = new TFCodBarraProdutos())
            {
                fCodBarraProdutos.TbPreco = (BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco;
                fCodBarraProdutos.CdEmpresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                if (fCodBarraProdutos.ShowDialog() == DialogResult.OK)
                    if (fCodBarraProdutos._LanPedido_Items.ToList().Count > 0)
                    {
                        fCodBarraProdutos._LanPedido_Items.ToList().ForEach(r =>
                        {
                            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(r);
                        });
                    }
                BS_Pedido.ResetBindings(true);
            }
        }

        private void btnCodBarras_Click(object sender, EventArgs e)
        {
            codBarras();
        }

        private void btn_CodBarras_Click(object sender, EventArgs e)
        {
            codBarras();
        }

        private void DtValidEmDias_Leave(object sender, EventArgs e)
        {
            if (!DT_Pedido.Text.Length.Equals(10))
            {
                MessageBox.Show("Informe a data do pedido.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(CD_CondPGTO.Text))
            {
                MessageBox.Show("Informe a condição de pagamento.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (BS_Parcelas.Count.Equals(0))
            {
                MessageBox.Show("Necessário ter pelo menos uma parcela para informar os dias de desdobro.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (BS_Parcelas.Current == null)
                return;
            else if (string.IsNullOrEmpty(DtValidEmDias.Text))
                return;

            (BS_Parcelas.Current as TRegistro_Pedido_DT_Vencto).Dt_vencto = Convert.ToDateTime(DT_Pedido.Text).AddDays(Convert.ToInt32(DtValidEmDias.Text));
            edtDt_Vencto.Text = (BS_Parcelas.Current as TRegistro_Pedido_DT_Vencto).Dt_vencto.ToString();
        }
    }
}
