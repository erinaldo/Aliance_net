using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using FormBusca;

namespace Faturamento
{
    public partial class TFFechamentoPedido : Form
    {
        private TRegistro_Pedido rpedido;
        public TRegistro_Pedido rPedido
        {
            get
            {
                if (BS_Pedido.Count > 0)
                    return BS_Pedido.Current as TRegistro_Pedido;
                else
                    return null;
            }
            set { rpedido = value; }
        }

        public TFFechamentoPedido()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Count < 1)
            {
                MessageBox.Show("Não é permitido fechar pedido sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Habilita_Data_Financeiro()
        {
            if (BS_Pedido.Current != null)
                dt_vencto.Enabled = (BS_Pedido.Current as TRegistro_Pedido).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S");
        }

        private void AjustarDadosFinanceiros()
        {
            if (BS_Pedido.Current != null)
            {
                Habilita_Data_Financeiro();
                if (!(Parcelas_Entrada.Text.Trim() == "S"))
                {
                    TCN_Pedido.Calcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido);
                    BS_Pedido.ResetCurrentItem();
                }
            }
        }

        private void CalcularValorPedidoItem()
        {
            if (BS_Pedido.Current != null)
                (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.CalcularValorJuro(
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

        private void InserirItem()
        {
            //Verificar se o pedido tem conferencia processada
            object obj = new CamadaDados.Faturamento.Pedido.TCD_EntregaPedido().BuscarEscalar(
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
            using (TFLan_Itens_Faturamento Lan_Itens = new TFLan_Itens_Faturamento())
            {
                Lan_Itens.st_servico = (BS_Pedido.Current as TRegistro_Pedido).St_servicobool;
                Lan_Itens.st_valoresfixos = (BS_Pedido.Current as TRegistro_Pedido).St_valoresfixosbool;
                Lan_Itens.CD_TabelaPreco = (BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco;
                Lan_Itens.CD_Empresa = CD_Empresa.Text;
                Lan_Itens.st_Commodities = false;
                Lan_Itens.Cfg_pedido = (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido;
                Lan_Itens.Comissionar_pedido = (BS_Pedido.Current as TRegistro_Pedido).St_comissaovendedorbool;
                Lan_Itens.Comissionar_Produto = TCN_Pedido.Busca_Comissao_Vendedor(BS_Pedido.Current as TRegistro_Pedido).Trim().ToUpper().Equals("P");
                Lan_Itens.Pc_desconto = (BS_Pedido.Current as TRegistro_Pedido).Pc_descgeral;
                
                Lan_Itens.pTp_movimento = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                if (Lan_Itens.ShowDialog() == DialogResult.OK)
                    if (Lan_Itens.rItem != null)
                    {
                        (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(Lan_Itens.rItem);
                        BS_Pedido.ResetCurrentItem();
                        this.TotalizarPedido();
                    }
            };
        }

        private void AlterarItem()
        {
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
                    if (obj != null)
                        if (obj.ToString().Trim().Equals("1"))
                            Lan_Itens.Quantidade.Enabled = false;
                    Lan_Itens.CD_Produto.Enabled = false;
                    Lan_Itens.BB_Produto.Enabled = false;
                    
                    Lan_Itens.rItem = BS_Itens.Current as TRegistro_LanPedido_Item;
                    Lan_Itens.st_alterar = true;
                    Lan_Itens.st_servico = (BS_Pedido.Current as TRegistro_Pedido).St_servicobool;
                    Lan_Itens.st_valoresfixos = (BS_Pedido.Current as TRegistro_Pedido).St_valoresfixosbool;
                    Lan_Itens.CD_TabelaPreco = (BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco;
                    Lan_Itens.CD_Empresa = CD_Empresa.Text;
                    Lan_Itens.Cfg_pedido = (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido;
                    Lan_Itens.Comissionar_pedido = (BS_Pedido.Current as TRegistro_Pedido).St_comissaovendedorbool;
                    Lan_Itens.Comissionar_Produto = TCN_Pedido.Busca_Comissao_Vendedor(BS_Pedido.Current as TRegistro_Pedido).Trim().ToUpper().Equals("P");

                    string _CD_Produto = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto;
                    string _DS_Produto = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_produto;
                    string _CD_Variedade = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_variedade;
                    string _DS_Variedade = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_variedade;
                    string _CD_Unidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_unidade_valor;
                    string _DS_Unidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_unidade_valor;
                    string _SG_UniQTD = (BS_Itens.Current as TRegistro_LanPedido_Item).Sg_unidade_valor;
                    string _CD_Local = (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_local;
                    string _DS_Local = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_local;
                    string _DS_Acondicionamento = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_acondicionamento;
                    string _DS_Observacao = (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_observacaoitem;

                    decimal _Quantidade = (BS_Itens.Current as TRegistro_LanPedido_Item).Quantidade;
                    decimal _Vl_Unitario = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_unitario;
                    decimal _Sub_Total = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_subtotal;
                    decimal _Frete_Item = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_freteitem;
                    decimal _Pc_ComissaoItem = (BS_Itens.Current as TRegistro_LanPedido_Item).Pc_comissao;
                    decimal _VL_Comissao = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_comissao;
                    decimal _Pc_DescontoItem = (BS_Itens.Current as TRegistro_LanPedido_Item).Pc_desc;
                    decimal _VL_Desconto = (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_desc;
                    Lan_Itens.pTp_movimento = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                    if (Lan_Itens.ShowDialog() == DialogResult.OK)
                    {
                        BS_Itens.ResetCurrentItem();
                        this.TotalizarPedido();
                    }
                    else
                    {
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto = _CD_Produto;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_produto = _DS_Produto;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_variedade = _CD_Variedade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_variedade = _DS_Variedade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_unidade_valor = _CD_Unidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_unidade_valor = _DS_Unidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Sg_unidade_valor = _SG_UniQTD;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_local = _CD_Local;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_local = _DS_Local;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_acondicionamento = _DS_Acondicionamento;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_observacaoitem = _DS_Observacao;

                        (BS_Itens.Current as TRegistro_LanPedido_Item).Quantidade = _Quantidade;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_unitario = _Vl_Unitario;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_subtotal = _Sub_Total;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_freteitem = _Frete_Item;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Pc_comissao = _Pc_ComissaoItem;
                        (BS_Itens.Current as TRegistro_LanPedido_Item).Vl_comissao = _VL_Comissao;
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
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido excluir item com conferência processada.", "Mensagem", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                {
                    //Verificar se o item teve origem ordem compra
                    obj = new CamadaDados.Compra.Lancamento.TCD_OrdemCompra_X_PedItem().BuscarEscalar(
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
                                vVL_Busca = (BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Id_pedidoitem.ToString()
                            }
                        }, "a.id_oc");
                    if (obj != null)
                    {
                        if (!(MessageBox.Show("Item do pedido foi gerado apartir da ordem de compra Nº " + obj.ToString().Trim() + ".\r\n" +
                                        "A exclusão do item ira abrir novamente a ordem de compra.\r\n" +
                                        "Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                            return;
                    }

                    (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedido_Itens.Add(BS_Itens.Current as TRegistro_LanPedido_Item);
                    BS_Itens.RemoveCurrent();
                    this.TotalizarPedido();
                }
            }
        }

        private void TotalizarPedido()
        {
            if (BS_Pedido.Current != null)
            {
                //Ratear frete
                TCN_Pedido.Rateia_Frete(BS_Pedido.Current as TRegistro_Pedido);
                VL_Desconto_Geral.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_desc);
                VL_Comissao.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_comissao);
                Vl_Frete.Value = (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Sum(p => p.Vl_freteitem);
            }
        }

        private void TFFechamentoPedido_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            TCN_Pedido.Consulta_Dados_Clifor(rpedido);
            Pc_Comissao.Enabled = rpedido.St_comissaovendedorbool && (!TCN_Pedido.Busca_Comissao_Vendedor(BS_Pedido.Current as TRegistro_Pedido).Trim().ToUpper().Equals("P"));
            VL_Comissao.Enabled = Pc_Comissao.Enabled;
            BS_Pedido.DataSource = new TList_Pedido() { rpedido };
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFFechamentoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "'"
             , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
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
            }
            if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S"))
                this.CalcularValorPedidoItem();
            this.AjustarDadosFinanceiros();
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;a.QT_Parcelas|Quantidade Parcelas|40;" +
            "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;a.ST_VenctoEmFeriado|Vence em Feriado|40;a.cd_condPGTO|Código|100;a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
            CD_CondPGTO_Leave(this, new EventArgs());            
        }

        private void VL_Entrada_Leave(object sender, EventArgs e)
        {
            decimal _VL_Entrada = VL_Entrada.Value;

            TCN_Pedido.Calcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido);

            for (int x = 0; x < (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto.Count; x++)
            {
                (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Entrada = VL_Entrada.Value;
                if (x == 0)
                {
                    (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[x].VL_Parcela = VL_Entrada.Value;
                }
            }

            TCN_Pedido.Recalcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido, 0);
            BS_Pedido.ResetCurrentItem();
        }

        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            TCN_Pedido.Valida_Datas(BS_Pedido.Current as TRegistro_Pedido, BS_Parcelas.Position);
            BS_Pedido.ResetCurrentItem();
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto[BS_Parcelas.Position].VL_Parcela = VL_Parcela.Value;
            TCN_Pedido.Recalcula_Parcelas(BS_Pedido.Current as TRegistro_Pedido, BS_Parcelas.Position);
            BS_Pedido.ResetCurrentItem();
        }

        private void Parcelas_Entrada_TextChanged(object sender, EventArgs e)
        {
            if (Parcelas_Entrada.Text.Trim() == "S")
            {
                Lbl_Entrada.Visible = true;
                VL_Entrada.Visible = true;
                VL_Entrada.Enabled = true;
            }
            else
            {
                Lbl_Entrada.Visible = false;
                VL_Entrada.Visible = false;
                VL_Entrada.Enabled = false;
            }
        }

        private void BS_Parcelas_PositionChanged(object sender, EventArgs e)
        {
            if ((BS_Parcelas.Count > 0) && (BS_Parcelas.Position > 0))
            {
                if ((BS_Parcelas.Count - 1) == BS_Parcelas.Position)
                {
                    VL_Parcela.ReadOnly = true;
                }
                else
                {
                    VL_Parcela.ReadOnly = false;
                }
            }
            else
            {
                VL_Parcela.ReadOnly = false;
            }
        }

        private void Pc_DescGeral_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Pc_descgeral = Pc_DescGeral.Value;
            TCN_Pedido.Rateia_Desconto_Itens(BS_Pedido.Current as TRegistro_Pedido);
            this.TotalizarPedido();
        }

        private void VL_Desconto_Geral_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Vl_descontogeral = VL_Desconto_Geral.Value;
            TCN_Pedido.Rateia_Desconto_Itens(BS_Pedido.Current as TRegistro_Pedido);
            this.TotalizarPedido();
        }

        private void Pc_Comissao_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Pc_comissao = Pc_Comissao.Value;
            TCN_Pedido.Rateia_Comissao_Itens(BS_Pedido.Current as TRegistro_Pedido);
            this.TotalizarPedido();
        }

        private void VL_Comissao_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).VL_Comissao = VL_Comissao.Value;
            TCN_Pedido.Rateia_Comissao_Itens(BS_Pedido.Current as TRegistro_Pedido);
            this.TotalizarPedido();
        }

        private void Vl_Frete_Leave(object sender, EventArgs e)
        {
            (BS_Pedido.Current as TRegistro_Pedido).Vl_frete = Vl_Frete.Value;
            TCN_Pedido.Rateia_Frete(BS_Pedido.Current as TRegistro_Pedido);
            this.TotalizarPedido();
        }
    }
}
