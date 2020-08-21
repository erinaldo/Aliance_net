using System;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Faturamento.Pedido;
using Utils;
using System.Linq;

namespace Faturamento
{
    public partial class TFLan_Itens_Faturamento : Form
    {
        public bool st_alterar { get; set; }
        public bool st_servico { get; set; }
        public string CD_Empresa = string.Empty;
        public string Nm_empresa = string.Empty;
        public string CD_TabelaPreco = string.Empty;
        public string Cd_cliente = string.Empty;
        public string Cd_vendedor = string.Empty;
        public string pTp_movimento = string.Empty;
        public decimal Pc_desconto = decimal.Zero;
        public bool st_Commodities = false;
        public bool St_deposito = false;
        public bool St_integraralmox = false;
        public string Cfg_pedido = string.Empty;
        public string Ds_observacao = string.Empty;
        private string Ds_fichaTec = string.Empty;
        private string LoginDesconto = string.Empty;

        private TRegistro_LanPedido_Item ritem;
        public TRegistro_LanPedido_Item rItem
        {
            get
            {
                if (BS_Itens_Pedido.Current != null)
                    return (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item);
                else
                    return null;
            }
            set
            { ritem = value; }
        }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;

        public decimal _VL_Frete_Tonelada = 0;
        
        public TFLan_Itens_Faturamento()
        {
            InitializeComponent();
            Cfg_pedido = string.Empty;
            ritem = null;
            rProg = null;
        }

        private decimal BuscarReservaEstoque()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)) &&
                (!string.IsNullOrEmpty(CD_Local.Text)))
            {
                CamadaDados.Estoque.TList_ReservaEstoque lReserva =
                CamadaNegocio.Estoque.TCN_LanEstoque.BuscarReservaEstoque(CD_Empresa,
                                                                          CD_Produto.Text,
                                                                          CD_Local.Text,
                                                                          null);
                if (lReserva.Count > 0)
                    return lReserva[0].Qtd_reservada;
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private decimal BuscarSaldoLocal()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)) &&
                (!string.IsNullOrEmpty(CD_Local.Text)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa, CD_Produto.Text, CD_Local.Text, ref saldo, null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void AlterarDs_Tec()
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                using (TFDs_FichaTec fDs_tec = new TFDs_FichaTec())
                {
                    if (string.IsNullOrEmpty((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Ds_Fichatec))
                        fDs_tec.Ds_fichaTec = Ds_fichaTec;
                    else
                        fDs_tec.Ds_fichaTec = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Ds_Fichatec.Trim();
                    if (fDs_tec.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fDs_tec.Ds_fichaTec))
                            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Ds_Fichatec =
                                fDs_tec.Ds_fichaTec.Trim();
                }
            }
        }

        private bool ValidarDescontos()
        {
            if (pTp_movimento.ToUpper().Equals("S"))
            {
                object obj_logindesc = null;
                if (!string.IsNullOrEmpty(LoginDesconto))
                {
                    //Buscar Vendedor
                    obj_logindesc = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
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
                                            vNM_Campo = "isnull(a.st_funcativo, 'S')",
                                            vOperador = "<>",
                                            vVL_Busca = "'N'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.LoginVendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + LoginDesconto.Trim() + "'"
                                        }
                                    }, "a.cd_clifor");
                }
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(obj_logindesc == null ? Cd_vendedor : obj_logindesc.ToString(),
                                                                                    CD_Empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if (lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_TabelaPreco))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim()) &&
                                            p.Cd_grupo.Trim().Equals((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo.Trim())).Pc_max_desconto;
                            if (Pc_DescontoItem.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco;
                                    fLogin.Cd_empresa = CD_Empresa;
                                    fLogin.Pc_desc = Pc_DescontoItem.Value;
                                    fLogin.Cd_grupo = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                    {
                                        VL_Desconto.Value = decimal.Zero;
                                        Pc_DescontoItem.Value = decimal.Zero;
                                        Pc_DescontoItem.Focus();
                                        return false;
                                    }
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Trim())).Pc_max_desconto;
                            if (Pc_DescontoItem.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco;
                                    fLogin.Cd_empresa = CD_Empresa;
                                    fLogin.Pc_desc = Pc_DescontoItem.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                    {
                                        VL_Desconto.Value = decimal.Zero;
                                        Pc_DescontoItem.Value = decimal.Zero;
                                        Pc_DescontoItem.Focus();
                                        return false;
                                    }
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
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo.Trim())).Pc_max_desconto;
                        if (Pc_DescontoItem.Value > pc_max_desc)
                        {
                            MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo;
                                fLogin.Cd_empresa = CD_Empresa;
                                fLogin.Pc_desc = Pc_DescontoItem.Value;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    VL_Desconto.Value = decimal.Zero;
                                    Pc_DescontoItem.Value = decimal.Zero;
                                    Pc_DescontoItem.Focus();
                                    return false;
                                }
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
                    if (Pc_DescontoItem.Value > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = CD_Empresa;
                            fLogin.Pc_desc = Pc_DescontoItem.Value;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                            {
                                VL_Desconto.Value = decimal.Zero;
                                Pc_DescontoItem.Value = decimal.Zero;
                                Pc_DescontoItem.Focus();
                                return false;
                            }
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

        private void CalcularImpostos()
        {
            if (!string.IsNullOrEmpty(CD_Empresa) &&
                !string.IsNullOrEmpty(Cd_cliente) &&
                !string.IsNullOrEmpty(Cfg_pedido) &&
                BS_Itens_Pedido.Current == null ? false : 
                !string.IsNullOrEmpty((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto) &&
                Quantidade.Value > decimal.Zero &&
                Sub_Total.Value > decimal.Zero)
            {
                //Buscar uf empresa
                string uf_emp = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + CD_Empresa.Trim() + "'" }
                    }, "c.cd_uf")?.ToString();
                //Buscar Uf cliente
                string uf_cli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + Cd_cliente.Trim() + "'" }
                    }, "a.cd_uf")?.ToString();
                //Buscar cond fiscal cliente
                string condCli = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + Cd_cliente.Trim() + "'" }
                    }, "a.cd_condfiscal_clifor")?.ToString();
                //Buscar tipo pessoa cliente
                string PessoaCli = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + Cd_cliente.Trim() + "'" }
                    }, "a.tp_pessoa")?.ToString();
                //Buscar movimentacao comercial do tipo de pedido
                CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cfg_pedido.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    }
                                }, 1, string.Empty);
                if (lCfgPed.Count > 0)
                {
                    string retobs = string.Empty;
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lICMS =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa,
                                                                                                      uf_emp,
                                                                                                      uf_cli,
                                                                                                      lCfgPed[0].Cd_movtostring,
                                                                                                      "S",
                                                                                                      condCli,
                                                                                                      (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_condfiscal_produto,
                                                                                                      (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_subtotal,
                                                                                                      Quantidade.Value,
                                                                                                      ref retobs,
                                                                                                      DateTime.Now,
                                                                                                      (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(condCli,
                                                                                                               (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_condfiscal_produto,
                                                                                                               lCfgPed[0].Cd_movtostring,
                                                                                                               "S",
                                                                                                               PessoaCli,
                                                                                                               CD_Empresa,
                                                                                                               lCfgPed[0].Nr_serie,
                                                                                                               Cd_cliente,
                                                                                                               string.Empty,
                                                                                                               DateTime.Now,
                                                                                                               (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade,
                                                                                                               (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_subtotal,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               null);
                    if (lICMS.Count > 0)
                    {
                        if ((lICMS[0].St_somarIPIBaseICMS || lICMS[0].St_somarIPIBaseST) &&
                            lImp.Exists(p => p.Imposto.St_IPI))
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rImp = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                            rImp.Cd_imposto = lICMS[0].Cd_imposto;
                            rImp.Pc_aliquota = lICMS[0].Pc_aliquota;
                            rImp.Pc_reducaoaliquota = lICMS[0].Pc_reducaoaliquota;
                            rImp.Pc_reducaobasecalc = lICMS[0].Pc_reducaobasecalc;
                            rImp.Pc_aliquotasubst = lICMS[0].Pc_aliquotasubst;
                            rImp.Pc_reducaobasecalcsubsttrib = lICMS[0].Pc_reducaobasecalcsubsttrib;
                            rImp.Pc_FCPST = lICMS[0].Pc_FCPST;
                            rImp.Pc_FCP = lICMS[0].Pc_FCP;
                            rImp.Tp_situacao = lICMS[0].Tp_situacao;
                            rImp.Dt_imposto = lICMS[0].Dt_imposto;
                            rImp.St_impostouf = 0;
                            rImp.Tp_modbasecalc = lICMS[0].Tp_modbasecalc;
                            rImp.Tp_modbasecalcST = lICMS[0].Tp_modbasecalcST;
                            rImp.Cd_st = lICMS[0].Cd_st;
                            rImp.St_substtrib = lICMS[0].St_substtrib;
                            rImp.St_simplesnacional = lICMS[0].St_simplesnacional;
                            rImp.Pc_iva_st = lICMS[0].Pc_iva_st;
                            rImp.Vl_mva = lICMS[0].Vl_mva;
                            rImp.Pc_aliquotaICMSDest = lICMS[0].Pc_aliquotaICMSDest;
                            rImp.Vl_pauta = lICMS[0].Vl_pauta;
                            rImp.St_somarIPIBaseICMS = lICMS[0].St_somarIPIBaseICMS;
                            rImp.St_somarIPIBaseST = lICMS[0].St_somarIPIBaseST;
                            rImp.Vl_ipisomar = lImp.First(p => p.Imposto.St_IPI).Vl_impostocalc;
                            //Calcular Imposto
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item
                                .CalcImpostos(rImp,
                                              (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_subtotal,
                                              (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade,
                                              "S");
                            vl_subst.Value = rImp.Vl_impostosubsttrib + rImp.Vl_FCPST;
                        }
                        else vl_subst.Value = lICMS[0].Vl_impostosubsttrib + lICMS[0].Vl_FCPST;
                    }
                    if (lImp.Count > 0)
                        vl_ipi.Value = lImp.Where(x => x.St_totalnota.Trim().ToUpper().Equals("S")).Sum(x => x.Vl_impostocalc);
                    vlLiqImpostos.Value = Sub_Total.Value + vl_subst.Value + vl_ipi.Value;
                    vlUnitImpostos.Value = (Sub_Total.Value + vl_subst.Value + vl_ipi.Value) / Quantidade.Value;
                }
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (Sub_Total.Focused)
                Sub_Total_Leave(this, new EventArgs());
            if (Vl_Unitario.Focused)
                Vl_Unitario_ValueChanged(this, new EventArgs());
            object id_car = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto
                    }
                }, "a.id_caracteristicaH");
            if(id_car != null)
                if(!string.IsNullOrEmpty(id_car.ToString()))
                {
                    using(Proc_Commoditties.TFGradeProduto gprod = new Proc_Commoditties.TFGradeProduto())
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lPedidoGrade.Clear();
                        gprod.pCd_empresa = CD_Empresa;
                        gprod.pCd_produto = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto;
                        gprod.pId_caracteristica = id_car.ToString();
                        gprod.pQuantidade = (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade;
                        if (gprod.ShowDialog() == DialogResult.OK)
                        {
                            gprod.lGrade.ForEach(p =>
                            {
                                (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lPedidoGrade.Add(
                                    new TRegistro_PedidoGrade()
                                    {
                                        id_caracteristica = p.Id_caracteristica.Value,
                                        id_item = p.Id_item.Value,
                                        quantidade = p.Vl_mov,
                                        cd_produto = gprod.pCd_produto
                                    });
                            });
                        }
                        else
                            return; 
                    } 
                }

            if ((cb_servico.Checked == false) && (CD_Local.Text.Trim().Equals(string.Empty)))
            {
                //verificar se o pedido movimenta estoque
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + Cfg_pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(d.st_geraEstoque, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1");
                if ((obj == null ? false : obj.ToString().Trim().Equals("1")))
                    MessageBox.Show("Obrigatório Informar Local de Armazenagem", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    DialogResult = DialogResult.OK;
            }
            else if (Vl_Unitario.Value <= 0)
            {
                if (CD_TabelaPreco.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar valor do item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Vl_Unitario.Focus();
                }
                else
                    MessageBox.Show("Não existe preço para o produto " + CD_Produto.Text.Trim() + " configurado na tabela de preço " + CD_TabelaPreco.Trim(),
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (pnl_Itens.validarCampoObrigatorio())
            {
                if(Quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!Quantidade.Focus())
                        vl_compromento.Focus();
                }
                if (pTp_movimento.Trim().ToUpper().Equals("S"))
                {
                    //Buscar custo produto
                    decimal vl_custo =
                    CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa,
                                                                       (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto,
                                                                       (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_local,
                                                                       null);
                    if (Vl_Unitario.Value < vl_custo)
                    {
                        if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VENDA ABAIXO CUSTO", null))
                            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                            {
                                fSessao.Mensagem = "PERMITIR VENDA ABAIXO CUSTO";
                                if (fSessao.ShowDialog() == DialogResult.OK)
                                {
                                    //Verificar se o usuario tem permissao para venda abaixo custo
                                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR VENDA ABAIXO CUSTO", null))
                                        this.DialogResult = DialogResult.OK;
                                    else
                                        Vl_Unitario.Focus();
                                }
                                else
                                    Vl_Unitario.Focus();
                            }
                        else DialogResult = DialogResult.OK;
                    }
                    else
                        this.DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.OK;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FLan_Itens_Faturamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(sender, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                BB_Cancelar_Click(sender, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F8))
                this.AlterarDs_Tec();
        }
        private void calcularcubo()
        {
            if (BS_Itens_Pedido.Current != null)
            {
                if (!string.IsNullOrEmpty((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Tp_unidade))
                    if ((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Tp_unidade.Equals("1"))
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade = largura.Value * altura.Value * vl_compromento.Value;
                        Quantidade.Enabled = true;
                        tableLayoutPanel1.RowStyles[1].Height = 30;
                        lblAltura.Visible = true;
                        altura.Visible = true;
                        BS_Itens_Pedido.ResetCurrentItem();
                    }
                    else if ((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Tp_unidade.Equals("0"))
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade = largura.Value * vl_compromento.Value;
                        Quantidade.Enabled = true;
                        tableLayoutPanel1.RowStyles[1].Height = 30;
                        lblAltura.Visible = false;
                        altura.Visible = false;
                        BS_Itens_Pedido.ResetCurrentItem();
                    }
                    else
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).comprimento_und = decimal.Zero;
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).altura = decimal.Zero;
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).largura = decimal.Zero;
                        tableLayoutPanel1.RowStyles[1].Height = 0;
                        Quantidade.Enabled = false;
                    }
            }
        }
        private void FLan_Itens_Faturamento_Load(object sender, EventArgs e)
        {

            CD_Local.Enabled = (!st_servico);
            BB_Local.Enabled = (!st_servico);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pnl_Itens.set_FormatZero();
            if (st_alterar)
            {
                BS_Itens_Pedido.DataSource = new TList_RegLanPedido_Item() { ritem };
                if (ritem.lFichaTec.Count > 0)
                {
                    st_kit.Checked = true;
                    Height = 600;
                }
                if (ritem.comprimento_und > decimal.Zero)
                {
                    tableLayoutPanel1.RowStyles[1].Height = 30;
                    calcularcubo();
                }
                if (pTp_movimento.Trim().ToUpper().Equals("E"))
                    vl_ultimacompra.Value = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.UltimaCompra(CD_Empresa, CD_Produto.Text, null);
                //caso a tabela de preco for tipo mercado habilitar valor para informar
                if (st_Commodities)
                    Vl_Unitario.Enabled = true;
                if ((CD_Empresa.Trim() != string.Empty) &&
                    (CD_Produto.Text.Trim() != string.Empty) &&
                    (!st_kit.Checked) &&
                    (BS_Itens_Pedido.Current != null))
                {
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_estoque = BuscarSaldoLocal();
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_reservada = BuscarReservaEstoque();
                    BS_Itens_Pedido.ResetCurrentItem();
                    vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
                }
                LoginDesconto = string.Empty;
                if (CD_Local.Enabled)
                    CD_Local_Leave(this, new EventArgs());
                if (ritem.comprimento_und.Equals(decimal.Zero))
                    tableLayoutPanel1.RowStyles[1].Height = 0;
            }
            else
            {
                BS_Itens_Pedido.AddNew();
                Pc_DescontoItem.Value = Pc_desconto;
                tableLayoutPanel1.RowStyles[1].Height = 0;
            }
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(CD_Empresa))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, 
                                                                       CD_Empresa, 
                                                                       string.Empty, 
                                                                       St_deposito ? "S" : string.Empty,
                                                                       null);
            string produto = CD_Produto.Text;
            if (List_Local_x_Empresa.Count == 1)
            {
                CD_Local.Text = List_Local_x_Empresa[0].CD_Local;
                DS_Local.Text = List_Local_x_Empresa[0].DS_Local;
            }
            Vl_Unitario.Enabled = string.IsNullOrEmpty(CD_TabelaPreco) ||
                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                             null);
            Sub_Total.Enabled = string.IsNullOrEmpty(CD_TabelaPreco) ||
                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                             null);
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Unidade|Ds Unidade|300;CD_Unidade|Cd.Unidade|80;Sigla_Unidade|Unid|60"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, new TCD_CadUnidade(),
                null);
        }
                
        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if (St_deposito)
                vParam += ";isnull(a.st_estterceiro, 'N')|=|'S'";

            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80", 
                new Componentes.EditDefault[] { CD_Local, DS_Local }, 
                new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa), 
                vParam);
            
            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_estoque = BuscarSaldoLocal();
            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_reservada = BuscarReservaEstoque();
            BS_Itens_Pedido.ResetCurrentItem();
            vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (pTp_movimento.Trim().ToUpper().Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(e.st_mprimasemente, 'N')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (st_servico)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(e.ST_Servico, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_integraralmox)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(e.st_consumointerno, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }

            TRegistro_CadProduto rProd = null;

            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   CD_Empresa,
                                                   Nm_empresa,
                                                   CD_TabelaPreco,
                                                   new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                   filtro);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                   CD_Empresa,
                                                   Nm_empresa,
                                                   CD_TabelaPreco,
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
                                                      "(a.Codigo_Alternativo = '" + (!string.IsNullOrWhiteSpace(CD_Produto.TextOld) ? CD_Produto.TextOld : CD_Produto.Text.Trim()) + "') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
                TList_CadProduto lProd = new TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
                else
                {
                    CD_Produto.Text = string.Empty;
                    CD_Produto.Focus();
                }
            }

            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                CD_Unidade.Text = rProd.CD_Unidade;
                DS_Unidade.Text = rProd.DS_Unidade;
                SG_UniQTD.Text = rProd.Sigla_unidade;
                cb_servico.Checked = rProd.St_servico;
                st_kit.Checked = rProd.St_composto;
                st_consumointerno.Checked = rProd.St_consumointerno;
                Ds_fichaTec = rProd.DS_TecnicaAssistencia;
                // busca unidade
                object obj_unidade = new TCD_CadProduto().BuscarEscalar(new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = rProd.CD_Produto
                                            }
                                        },"b.tp_unidade");
                (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Tp_unidade = obj_unidade.ToString();
                calcularcubo();
                if ((!cb_servico.Checked))
                {
                    //Buscar local armazenagem
                    object obj = new TCD_CadLocalArm().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_est_empresa_x_localarm x " +
                                                        "where x.cd_local = a.cd_local " +
                                                        "and x.cd_empresa = '" + CD_Empresa.Trim() + "')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_est_localarm_x_produto x " +
                                                        "where x.cd_local = a.cd_local " +
                                                        "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')"
                                        }
                                    }, "a.cd_local");
                    if (obj != null)
                    {
                        CD_Local.Text = obj.ToString();
                        CD_Local_Leave(this, new EventArgs());
                        Quantidade.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CD_Local.Text))
                            CD_Local.Focus();
                        else Quantidade.Focus();
                    }
                }
                else
                {
                    CD_Local.Enabled = false;
                    BB_Local.Enabled = false;
                }
                if (BS_Itens_Pedido.Current != null)
                {

                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_grupo = rProd.CD_Grupo;
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Ds_marca = rProd.DS_Marca;
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Ds_condfiscal_produto = rProd.DS_CondFiscal_Produto;
                    if (st_kit.Checked)
                    {
                        Height = 600;
                        Quantidade.Value = 1;
                        try
                        {
                            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lFichaTec =
                                TCN_FichaTecItemPed.MontarFichaTecPedItem(CD_Produto.Text,
                                                                          CD_Empresa,
                                                                          CD_TabelaPreco,
                                                                          Quantidade.Value,
                                                                          null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        Height = 446;
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lFichaTec.Clear();
                        BS_Itens_Pedido.ResetCurrentItem();
                    }
                }
            }
            ConsultaPreco();
            Busca_Unidade();

            if (pTp_movimento.Trim().ToUpper().Equals("E"))
                vl_ultimacompra.Value = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.UltimaCompra(CD_Empresa, CD_Produto.Text, null);

            //caso a tabela de preco for tipo mercado habilitar valor para informar
            if (st_Commodities)
                Vl_Unitario.Enabled = true;
            if ((CD_Empresa.Trim() != string.Empty) &&
                (CD_Produto.Text.Trim() != string.Empty) &&
                (!st_kit.Checked) &&
                (BS_Itens_Pedido.Current != null))
            {
                (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_estoque = BuscarSaldoLocal();
                (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_reservada = BuscarReservaEstoque();
                BS_Itens_Pedido.ResetCurrentItem();
                vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
            }
            LoginDesconto = string.Empty;
            CalcularImpostos();
        }
        
        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Unidade|=|'" + CD_Unidade.Text + "'"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, new TCD_CadUnidade());
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            if (St_deposito)
                vParam += ";isnull(a.st_estterceiro, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, 
                                    new Componentes.EditDefault[] { CD_Local, DS_Local }, 
                                    new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa));
            
            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_estoque = this.BuscarSaldoLocal();
            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Qtd_reservada = this.BuscarReservaEstoque();
            BS_Itens_Pedido.ResetCurrentItem();
            vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
        }

        private void ConsultaPreco()
        {
            if (!this.st_alterar)
            {
                //Vefiricar se existe programacao especial de venda 
                rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa,
                                                                                                     Cd_cliente,
                                                                                                     CD_Produto.Text,
                                                                                                     CD_TabelaPreco,
                                                                                                     null);
                if (rProg != null)
                {
                    if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_unitario =
                            CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa, CD_Produto.Text, null);
                        BS_Itens_Pedido.ResetCurrentItem();
                    }else
                    {
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_unitario = TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                        BS_Itens_Pedido.ResetCurrentItem();
                    }
                }
                else if ((!string.IsNullOrEmpty(CD_Produto.Text)) &&
                    (!string.IsNullOrEmpty(CD_Empresa)) &&
                    (!string.IsNullOrEmpty(CD_TabelaPreco)))
                {
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_unitario = TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                    BS_Itens_Pedido.ResetCurrentItem();
                }
                Vl_Unitario.Enabled = CD_TabelaPreco.Trim().Equals(string.Empty) || 
                                      Vl_Unitario.Value.Equals(0) ||
                                      CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                   "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                   null);
                CalcularDescEspecial();
            }
        }

        private void CalcularDescEspecial()
        {
            if ((rProg != null) && (Quantidade.Value > decimal.Zero))
                if (rProg.Valor > decimal.Zero)
                {
                    BS_Itens_Pedido.ResetCurrentItem();
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade = Quantidade.Value;
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_desc =
                            (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Quantidade * rProg.Valor;
                    else
                        (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Pc_desc = rProg.Valor;
                    BS_Itens_Pedido.ResetCurrentItem();
                }
        }

        private void Busca_Unidade()
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
               TCN_LanPedido_Item.Busca_Unidade(BS_Itens_Pedido.Current as TRegistro_LanPedido_Item, null);
               BS_Itens_Pedido.ResetCurrentItem();
            }
        }

        private void cb_servico_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_servico.Checked)
            {
                CD_Local.Enabled = false;
                CD_Local.Clear();
                BB_Local.Enabled = false;
                DS_Local.Clear();
            }
            else
            {
                CD_Local.Enabled = true;
                BB_Local.Enabled = true;
            }
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((!st_kit.Checked) && pTp_movimento.Trim().Equals("S") && (!cb_servico.Checked))
                if (Quantidade.Value > qtd_saldoreal.Value)
                    MessageBox.Show("Não existe saldo suficiente para faturar o item.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CalcularDescEspecial();
            CalcularImpostos();
        }

        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            if ((BS_Itens_Pedido.Current != null) && st_kit.Checked)
                try
                {
                    (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lFichaTec =
                        TCN_FichaTecItemPed.MontarFichaTecPedItem(CD_Produto.Text,
                                                                  CD_Empresa,
                                                                  CD_TabelaPreco,
                                                                  Quantidade.Value,
                                                                  null);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Vl_Unitario_ValueChanged(object sender, EventArgs e)
        {
            if (pTp_movimento.Trim().ToUpper().Equals("E") && (Vl_Unitario.Value > decimal.Zero))
            {
                if (Vl_Unitario.Value > vl_ultimacompra.Value)
                    pc_aumentodesc.Value = 100 - ((vl_ultimacompra.Value * 100) / Vl_Unitario.Value);
                else
                    pc_aumentodesc.Value = ((vl_ultimacompra.Value * 100) / Vl_Unitario.Value) - 100;

                if (vl_ultimacompra.Value > decimal.Zero)
                    if (Vl_Unitario.Value > vl_ultimacompra.Value)
                        Vl_Unitario.ForeColor = Color.Red;
                    else if (Vl_Unitario.Value < vl_ultimacompra.Value)
                        Vl_Unitario.ForeColor = Color.Blue;
                    else
                        Vl_Unitario.ForeColor = Color.Black;
                else
                    Vl_Unitario.ForeColor = Color.Black;
            }
            //Habilitar somente se vl.unitario for igual a zero
            Sub_Total.Enabled = Vl_Unitario.Enabled;
            CalcularImpostos();
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                CD_Unidade.Focus();
        }

        private void bb_alterarDs_Tec_Click(object sender, EventArgs e)
        {
            AlterarDs_Tec();
        }

        private void Pc_DescontoItem_Leave(object sender, EventArgs e)
        {
            ValidarDescontos();
        }

        private void VL_Desconto_Leave(object sender, EventArgs e)
        {
            if (BS_Itens_Pedido.Current != null)
            {
                (BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).Vl_desc = VL_Desconto.Value;
                BS_Itens_Pedido.ResetCurrentItem();
                ValidarDescontos();
            }
        }

        private void Pc_DescontoItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ValidarDescontos();
        }

        private void VL_Desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ValidarDescontos();
        }

        private void Sub_Total_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero && Quantidade.Value > decimal.Zero)
            {
                decimal total = Sub_Total.Value;
                Vl_Unitario.Value = total / Quantidade.Value;
            }
        }

        private void vl_compromento_Leave(object sender, EventArgs e)
        {
            calcularcubo();
        }

        private void largura_Leave(object sender, EventArgs e)
        {
            calcularcubo();
        }

        private void altura_Leave(object sender, EventArgs e)
        {
            calcularcubo();
        }
    }
}
