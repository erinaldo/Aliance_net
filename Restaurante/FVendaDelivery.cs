using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using CamadaNegocio.Restaurante.Cadastro;
using System.IO;
using CamadaDados.Restaurante.Cadastro;
using Restaurante.Impressao;
using System.Drawing;

namespace Restaurante
{
    public partial class TFVendaDelivery : Form
    {
        public bool vSt_entrega
        {
            get; set;
        } = false;
        public bool vSt_buscar
        {
            get; set;
        } = false;
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa { get; set; }
        private bool Altera_Relatorio { get; set; } = false;
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant
        { get; set; }
        private string LoginPdv { get; set; }
        private CamadaDados.Faturamento.PDV.TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private TList_CFG lcfg { get; set; } = new TList_CFG();
        public TFVendaDelivery()
        {
            InitializeComponent();
        }

        private void FecharComanda()
        {
            if (bsEntrega.Current != null)
            {
                if ((bsEntrega.Current as TRegistro_PreVenda).St_delivery.Equals("E"))
                {
                    CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                    //Contar  Id.lancto cupom
                    int cont = 1;
                    (bsEntrega.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                    {
                        CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item _VendaRapida_Item = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                        _VendaRapida_Item.Cd_produto = p.cd_produto;
                        _VendaRapida_Item.Quantidade = p.quantidade;
                        _VendaRapida_Item.Vl_unitario = p.vl_unitario;
                        _VendaRapida_Item.Vl_desconto = p.vl_desconto * p.quantidade;
                        _VendaRapida_Item.Cd_local = lcfg[0].cd_local;
                        _VendaRapida_Item.Vl_subtotal = p.quantidade * p.vl_unitario;
                        _VendaRapida_Item.id_item = Convert.ToDecimal(p.id_item);
                        _VendaRapida_Item.id_prevenda = Convert.ToDecimal(p.id_prevenda);
                        _VendaRapida_Item.Cd_condfiscal_produto = p.cd_condfiscal_produto;
                        rVenda.lItem.Add(_VendaRapida_Item);
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.cd_produto))
                        {
                            //Passar Id.Cupom do registro cupom fiscal para lista de amarração com a venda rápida
                            rVenda.lItem[rVenda.lItem.Count - 1].rItemVRDelivery = new CamadaDados.Faturamento.PDV.TRegistro_Cupom_X_VendaRapida();
                            rVenda.lItem[rVenda.lItem.Count - 1].rItemVRDelivery.Id_cupom = (bsEntrega.Current as TRegistro_PreVenda).Id_cupom;
                            rVenda.lItem[rVenda.lItem.Count - 1].rItemVRDelivery.Id_lancto = cont++;
                        }
                    });
                    rVenda.rCliente = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = string.IsNullOrEmpty((bsEntrega.Current as TRegistro_PreVenda).cd_clifor) ? lcfg[0].Cd_Clifor :
                                            (bsEntrega.Current as TRegistro_PreVenda).cd_clifor
                            }
                        }, 1, string.Empty)[0];
                    rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = string.IsNullOrEmpty((bsEntrega.Current as TRegistro_PreVenda).cd_clifor) ? lcfg[0].Cd_Clifor :
                                            (bsEntrega.Current as TRegistro_PreVenda).cd_clifor
                            }
                        }, 1, string.Empty)[0];
                    rVenda.Cd_clifor = rVenda.rCliente.Cd_clifor;
                    rVenda.Cd_empresa = lcfg[0].cd_empresa;
                    rVenda.Nm_clifor = rVenda.rCliente.Nm_clifor;
                    rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
                    rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
                    rVenda.Cd_endereco = rVenda.rEndCli.Cd_endereco;

                    using (PDV.TFFecharVendaPDV fFechar = new PDV.TFFecharVendaPDV())
                    {
                        fFechar.rCupom = rVenda;
                        fFechar.pCd_empresa = rVenda.Cd_empresa;
                        fFechar.pCd_clifor = rVenda.Cd_clifor;
                        fFechar.pNm_clifor = rVenda.Nm_clifor;
                        fFechar.rCfg = lCfg[0];
                        fFechar.pVl_receber = (bsEntrega.Current as TRegistro_PreVenda).lItens.Sum(p => p.vl_liquido);

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

                        if (fFechar.ShowDialog() == DialogResult.OK)
                            if (fFechar.lPortador != null)
                            {
                                rVenda.Cd_clifor = fFechar.pCd_clifor;
                                rVenda.Nm_clifor = fFechar.pNm_clifor;
                                rVenda.lPortador = fFechar.lPortador;
                                (bsEntrega.Current as TRegistro_PreVenda).lVenda.Add(rVenda);
                                TCN_PreVenda.FecharComanda(bsEntrega.Current as TRegistro_PreVenda, null);

                                //Fechar cartao da prevenda
                                try
                                {
                                    new TCD_Cartao().executarEscalar("update tb_res_cartao " +
                                                                    "set st_registro = 'F' " +
                                                                    "where id_cartao = " + (bsEntrega.Current as TRegistro_PreVenda).id_cartao + " " +
                                                                    "and cd_empresa = " + (bsEntrega.Current as TRegistro_PreVenda).Cd_empresa + " " +
                                                                    "update tb_res_cartao " +
                                                                    "set dt_fechamento = getdate() " +
                                                                    "where id_cartao = " + (bsEntrega.Current as TRegistro_PreVenda).id_cartao + " " +
                                                                    "and cd_empresa = " + (bsEntrega.Current as TRegistro_PreVenda).Cd_empresa, null);

                                    MessageBox.Show("Comanda fechada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterbusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                                return;
                            }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Permitido fechar pedido apenas em entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void afterPrint(TRegistro_PreVenda val)
        {
            if (val == null) return;

            if (MessageBox.Show("Deseja reimprimir pedidos?", "Reimprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            TRegistro_Cartao rcard = TCN_Cartao.Buscar(val.Cd_empresa, val.id_cartao.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)[0];
            IMP_Cartao.Impressao_PEDIDOS((bsAberto.Current as TRegistro_PreVenda), rcard, true);
            IMP_Cartao.Impressao_DELIVERY((bsAberto.Current as TRegistro_PreVenda));
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using (TFDelivery f = new TFDelivery())
            {
                f.ShowDialog();
                toolStripButton1_Click(this, new EventArgs());
                bsPreVenda_PositionChanged(this, new EventArgs());
            }
        }

        private void FVendaDelivery_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            LoginPdv = Utils.Parametros.pubLogin;
            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count <= 0)
            {
                MessageBox.Show("Não existe configuração cadastrada!", "Mensagem", MessageBoxButtons.OK);
                return;
            }

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
            if (new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_pdv",
                                    vOperador = "=",
                                    vVL_Busca = lPdv[0].Id_pdvstr
                                },
                                new Utils.TpBusca()
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
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Busca caixa aberto
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + LoginPdv + "'"
                            },
                            new Utils.TpBusca()
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
            if (vSt_buscar)
                afterbusca();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void afterbusca()
        {
            TList_PreVenda lPrevenda =
             new TCD_PreVenda().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.ST_Delivery",
                        vOperador = "in",
                        vVL_Busca = "('A', 'E')"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 0, string.Empty, "d.id_cartao asc");

            bsAberto.DataSource = lPrevenda.Where(p => p.St_delivery.ToUpper().Equals("A")).ToList();
            bsEntrega.DataSource = lPrevenda.Where(p => p.St_delivery.ToUpper().Equals("E")).ToList();
            bsPreVenda_PositionChanged(this, new EventArgs());
            bsEntrega_PositionChanged(this, new EventArgs());
            bsAberto.ResetCurrentItem();

        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            if (bsAberto.Current != null)
                if ((bsAberto.DataSource as List<TRegistro_PreVenda>).Exists(p => p.st_agregar))
                {
                    bool st_gerarcupom = MessageBox.Show("Deseja gerar cupom fiscal das venda(s) selecionada(s)?", "Pergunta", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                    using (TFApontarEntrega fapont = new TFApontarEntrega())
                    {
                        fapont.rPreVenda = (bsAberto.Current as TRegistro_PreVenda);
                        if (fapont.ShowDialog() == DialogResult.OK)
                        {
                            (bsAberto.DataSource as List<TRegistro_PreVenda>).ForEach(c =>
                            {
                                if (c.st_agregar)
                                {
                                    try
                                    {
                                        if (st_gerarcupom)
                                        {
                                            rVenda.st_restaurante = true;
                                            c.lItens.ForEach(p =>
                                            {
                                                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item item = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                                                if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.cd_produto))
                                                {
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
                                                }
                                            });
                                            rVenda.rCliente = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = c.cd_clifor
                                                        }
                                                }, 1, string.Empty)[0];
                                            rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                                new TpBusca[]
                                                {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = c.cd_clifor
                                                        }
                                                }, 1, string.Empty)[0];
                                            rVenda.Cd_clifor = rVenda.rCliente.Cd_clifor;
                                            rVenda.Cd_empresa = lcfg[0].cd_empresa;
                                            rVenda.Nm_clifor = rVenda.rCliente.Nm_clifor;
                                            rVenda.Cd_endereco = rVenda.rEndCli.Cd_endereco;
                                            rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
                                            rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;

                                            //Necessário pois quando não informado a forma de pagamento
                                            //o sistema irá cortar o NFCe na impressão
                                            rVenda.lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                            {
                                                new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                {
                                                    Tp_portador = "01",
                                                    Vl_recebido = rVenda.lItem.Sum(p => p.Vl_subtotal)
                                                }
                                            };

                                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarCup(rVenda, null, null, null, null);
                                        }
                                        c.St_delivery = "E";
                                        c.cd_entregador = fapont.cd_entregador;
                                        TCN_PreVenda.Gravar(c, null);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }

                            });
                            //Gerar Cupom
                            if (st_gerarcupom)
                                GerarCupom(rVenda, null);
                            MessageBox.Show("Pedido apontado para a entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            toolStripButton1_Click(this, new EventArgs());
                        }
                    }
                }
                else
                    MessageBox.Show("Selecione um delivery para apontar a entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void bsPreVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsAberto.Current != null)
            {
                (bsAberto.Current as TRegistro_PreVenda).lItens =
                    TCN_PreVenda_Item.Buscar(
                        (bsAberto.Current as TRegistro_PreVenda).Cd_empresa,
                        (bsAberto.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                        string.Empty, string.Empty, null);
                bsPreVendaItem_PositionChanged(this, new EventArgs());
            }
            bsAberto.ResetCurrentItem();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (TFLanPreVenda a = new TFLanPreVenda())
            {
                a.ShowDialog();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsAberto.Current == null) return;

            if ((bsAberto.Current as TRegistro_PreVenda).St_delivery.Equals("A"))
            {
                if (new TCD_ItensPreVenda_X_ItensCupom().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsAberto.Current as TRegistro_PreVenda).Cd_empresa.Trim() + "'" },
                            new TpBusca { vNM_Campo = "a.id_prevenda", vOperador = "=", vVL_Busca = (bsAberto.Current as TRegistro_PreVenda).id_prevenda.ToString() }
                        }, "1") == null)
                    using (TFDelivery f = new TFDelivery())
                    {
                        TRegistro_Cartao _Cartao = new TCD_Cartao().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_res_prevenda x where a.id_cartao = x.id_cartao and x.id_prevenda = '"
                                                            + (bsAberto.Current as TRegistro_PreVenda).id_prevenda.ToString()+"')"
                                            }
                                        }, 0, string.Empty, string.Empty)[0];
                        f.rCartao = _Cartao;
                        f.ShowDialog();
                        toolStripButton1_Click(this, new EventArgs());
                        bsPreVenda_PositionChanged(this, new EventArgs());
                    }
                else
                    MessageBox.Show("Não é possível alterar pedidos que tenham cupom gerado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Pedido em entrega! não pode alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui(bsAberto.Current as TRegistro_PreVenda);
        }

        private void afterExclui(TRegistro_PreVenda val)
        {
            if (val != null)
            {
                bool st_excluir = true;
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR ITEM CANCELAR VENDA", null))
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR EXCLUIR ITEM CANCELAR VENDA";
                        if (fRegra.ShowDialog() != DialogResult.OK)
                            st_excluir = false;
                    }
                if (st_excluir)
                    if (MessageBox.Show("Confirma a exclusão da venda selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_PreVenda.Excluir(val, null);
                            MessageBox.Show("Venda excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IMP_Cartao.CancelamentoDelivery(bsAberto.Current as TRegistro_PreVenda);
                            afterbusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ExcluiCupom(CamadaDados.Faturamento.PDV.TRegistro_NFCe val)
        {
            if (val != null)
            {
                if (val.St_registro.Trim().ToUpper().Equals("C") &&
                    (!val.Id_contingencia.HasValue ||
                    (val.Id_contingencia.HasValue &&
                        val.St_transmitidocancnfce)))
                {
                    MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (val.Id_contingencia.HasValue &&
                    !val.Nr_protocolo.HasValue)
                {
                    MessageBox.Show("Não é permitido CANCELAR NFC-e emitida em CONTINGÊNCIA OFFLINE sem antes transmitir a mesma para receita.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Verificar se NFCe não esta vinculada a NFe
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_ECFVinculadoNF().BuscarEscalar(
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
                                    vVL_Busca = val.Id_nfcestr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and isnull(x.st_registro, 'A') <> 'C')"
                                }
                            }, "1") != null)
                        {
                            MessageBox.Show("Para cancelar NFCe vinculada a NFe, obrigatório antes cancelar a NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        bool st_cancelar = true;
                        if (val.Nr_protocolo.HasValue ||
                            val.Id_contingencia.HasValue)
                        {
                            string motivo = string.Empty;
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                            //Verificar evento
                            CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(val.Cd_empresa,
                                                                                    val.Id_nfcestr,
                                                                                    string.Empty,
                                                                                    null);
                            if (lEvento.Count.Equals(0))
                            {
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Motivo Cancelamento NFCe";
                                    motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (motivo.Trim().Length < 15)
                                    {
                                        MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                //Buscar evento Cancelamento
                                if (lEv == null)
                                    lEv = CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                if (lEv.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar NFe Receita
                                CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe rEvento = new CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe();
                                rEvento.Cd_empresa = val.Cd_empresa;
                                rEvento.Id_cupom = val.Id_nfce;
                                rEvento.Chave_acesso_nfce = val.Chave_acesso;
                                rEvento.Nr_protocoloNFCe = val.Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Justificativa = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Gravar(rEvento, null);
                                lEvento.Add(rEvento);
                            }
                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T") &&
                                val.Nr_protocolo.HasValue)
                            {
                                //Buscar CfgNfe para a empresa
                                if (lCfg == null)
                                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(val.Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + val.Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    string ret = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + ret.Trim() + ".",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        st_cancelar = false;
                                    }
                                }
                            }
                        }
                        if (st_cancelar)
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe.CancelarCFdelivery(val, null);
                            MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!val.Nr_protocolo.HasValue &&
                                !val.Id_contingencia.HasValue)
                            {
                                CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(val.Nr_serie,
                                                                                                    val.Cd_modelo,
                                                                                                    val.Cd_empresa,
                                                                                                    null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals(val.NR_NFCe))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(val.Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                                        if (lCfgNfe.Count > 0)
                                        {
                                            try
                                            {
                                                //Inutilizar numero nota
                                                NFCe.InutilizaNFCe.TInutilizaNFCe.InutilizarNFCe(lCfgNfe[0].Cd_uf_empresa,
                                                                                                    lCfgNfe[0].Cnpj_empresa,
                                                                                                    val.Nr_serie,
                                                                                                    val.Cd_modelo,
                                                                                                    DateTime.Now.Year.ToString(),
                                                                                                    val.NR_NFCe.Value,
                                                                                                    val.NR_NFCe.Value,
                                                                                                    "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFCe",
                                                                                                    lCfgNfe[0]);
                                                MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                            }
                            //this.afterBusca();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
        }

        private void ExcluirVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            if (MessageBox.Show("Confirma cancelamento venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    //Verificar se venda possui pontos resgatados
                    if (val.PontosFidRes > decimal.Zero)
                    {
                        string loginCanc = string.Empty;
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                loginCanc = fRegra.Login;
                            else
                            {
                                MessageBox.Show("Obrigatório informar LOGIN com permissão para CANCELAR venda com pontos resgatados.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        val.LoginCancPontos = loginCanc;
                    }
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(new List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida> { val }, null);
                    MessageBox.Show("Venda rapida excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void GerarCupom(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda, ThreadEspera tEspera)
        {
            if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
            {
                try
                {
                    //Processar cupom fiscal
                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                    dados.lItens = rVenda.lItem;
                    dados.rSessao = lSessao[0];
                    dados.St_pedirCliente = true;
                    dados.Cd_clifor = rVenda.Cd_clifor;
                    dados.Nm_clifor = rVenda.Nm_clifor;
                    dados.CpfCgc = rVenda.Nr_cgccpf;
                    dados.Cd_endereco = rVenda.Cd_endereco;
                    dados.Mensagem = string.Empty;
                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                    dados.St_vendacombustivel = false;
                    dados.St_cupomavulso = true;
                    dados.St_agruparProduto = false;
                    
                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, dados.St_pedirCliente, true);

                    if (rNFCe != null)
                        if (!rNFCe.St_contingencia)
                        {
                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                            {

                                rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                          rNFCe.Id_nfcestr,
                                                                                          null,
                                                                                          true);

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
                                                                    "and x.Nr_Lancto = a.Nr_Lancto " +
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

                            //Ocorre quando cupom emitido pelo delivery
                            //logo não informando condição de pagamento
                            if (lPagto.Count.Equals(0))
                            {
                                lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                {
                                    Tp_portador = "01",
                                    Vl_recebido = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal)
                                });
                            }

                            bsPagto.DataSource = lPagto;
                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                            //Parametros
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                            object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
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
                            object imp = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                    }, "a.impressorapadrao");
                            string print = imp == null ? string.Empty : imp.ToString();
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
                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                    Rel.ImprimiGraficoReduzida(print,
                                                               true,
                                                               false,
                                                               null,
                                                               string.Empty,
                                                               string.Empty,
                                                               1);
                            }
                        }

                    #region impressão de cupom não aceito
                    /*
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource dts = new BindingSource();
                        dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                        Rel.DTS_Relatorio = dts;
                        BindingSource bsNFCe = new BindingSource();
                        bsNFCe.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe() { CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa, rNFCe.Id_nfcestr, null) };
                        NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                        Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa() { (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rEmpresa };
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        //Forma Pagamento
                        BindingSource bsPagto = new BindingSource();
                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lDup.Count > 0)
                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                            {
                                Tp_portador = "05",
                                Vl_recebido = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lDup[0].Vl_documento
                            });
                        bsPagto.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lPagto;
                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                        //Parametros
                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                        object tpAmbiente = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
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
                        Rel.Parametros_Relatorio.Add("TP_AMBIENTE", tpAmbiente == null ? string.Empty : tpAmbiente.ToString());
                        string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                              (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                              null);
                        if (!string.IsNullOrEmpty(dadoscf))
                        {
                            string[] linhas = dadoscf.Split(new char[] { ':' });
                            string placarel = string.Empty;
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
                                placarel += virg + colunas[0];
                                km += virg + colunas[1];
                                frota += virg + colunas[2];
                                requisicao += virg + colunas[3];
                                nm_motorista += virg + colunas[4];
                                cpf_motorista += virg + colunas[5];
                                media += virg + colunas[6];
                                virg = ",";
                            }
                            if (!string.IsNullOrEmpty(placarel))
                                Rel.Parametros_Relatorio.Add("PLACA", placarel);
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
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "DANFE NFC-e";
                        fImp.St_danfenfce = true;
                        if (Altera_Relatorio)
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "DANFE NFC-e",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                        }
                        else
                        {
                            fImp.pCd_clifor = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_clifor;
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            {
                                if (fImp.St_danfenfcedetalhada)
                                {
                                    BindingSource bsItens = new BindingSource();
                                    bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                    Rel.DTS_Relatorio = bsItens;
                                }
                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                    fImp.St_viaestabelecimento)
                                    if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                        Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                    else
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                Rel.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   null,
                                                   "DANFE NFC-e",
                                                   fImp.pDs_mensagem);
                            }
                        }
                    }
                    */
                    #endregion

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirGrafico(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
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
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
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
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
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

        private void FVendaDelivery_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lSessao.ForEach(p => CamadaNegocio.Faturamento.PDV.TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsAberto.Current as TRegistro_PreVenda).St_delivery.Equals("A"))
                {
                    MessageBox.Show("Delivery já está em entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsAberto.Current as TRegistro_PreVenda).st_agregar =
                    !(bsAberto.Current as TRegistro_PreVenda).st_agregar;
                bsAberto.ResetCurrentItem();
            }
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        {
            if (bsAberto.Count > 0)
                (bsAberto.DataSource as TList_PreVenda).ForEach(p =>
                {
                    if (p.St_delivery.Equals("A"))
                        p.st_agregar = !p.st_agregar;
                });
            bsAberto.ResetBindings(true);
        }

        private void FVendaDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                BB_Novo_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F3))
                BB_Alterar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F4))
                FecharComanda();
            else if (e.KeyCode.Equals(Keys.F6))
                toolStripButton5_Click_1(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F7))
                toolStripButton1_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint(bsAberto.Current as TRegistro_PreVenda);
            else if (e.KeyCode.Equals(Keys.F10))
                bbBuscar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12))
                toolStripButton2_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui(bsAberto.Current as TRegistro_PreVenda);
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            afterPrint(bsAberto.Current as TRegistro_PreVenda);
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
                    if ((bsAberto.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.
                        Where(p => p.Cd_produto.Equals(cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        // St_descEspecial = true;
                        //     St_promoDescEspecial = true;
                        //   this.DesabilitarDescontos();
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                        else
                            return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    //  St_descEspecial = true;
                    //   St_promoDescEspecial = true;
                    //   this.DesabilitarDescontos();
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private void dataGridDefault2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridDefault2.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAberto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PreVenda());
            TList_PreVenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((dataGridDefault2.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (dataGridDefault2.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PreVenda(lP.Find(dataGridDefault2.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in dataGridDefault2.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PreVenda(lP.Find(dataGridDefault2.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in dataGridDefault2.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAberto.List as List<TRegistro_PreVenda>).Sort(lComparer);
            bsAberto.ResetBindings(false);
            dataGridDefault2.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void GerarNFCe()
        {
            if (bsAberto.Current == null)
                return;
            BindingSource bsCartao = new BindingSource();
            bsCartao.DataSource = new TList_Cartao();
            bsCartao.DataSource = TCN_Cartao.Buscar(
                (bsAberto.Current as TRegistro_PreVenda).Cd_empresa,
                (bsAberto.Current as TRegistro_PreVenda).id_cartao.ToString(),
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);

            if (bsCartao.Current == null ? false :
                MessageBox.Show("Gerar NFCe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TList_ItensPreVenda_X_ItensCupom it = new TList_ItensPreVenda_X_ItensCupom();
                it = TCN_ItensPreVenda_X_ItensCupom.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                    (bsAberto.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                    string.Empty, string.Empty, string.Empty, null);
                if (it.Count <= 0)
                    return;
                CamadaDados.Faturamento.PDV.TList_VendaRapida lVenda =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(it[0].Id_VendaRapida.ToString(),
                                                                        (bsCartao.Current as TRegistro_Cartao).Cd_empresa,
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

                //Verificar se existe configuração para emitir NFC-e
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CfgNfe().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lVenda[0].Cd_empresa.Trim() + "'"
                                    }
                                }, "a.tp_ambiente_nfce");
                if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                {
                    MessageBox.Show("Empresa<" + lVenda[0].Cd_empresa.Trim() + "> não esta habilitada para emitir NFC-e.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui cupom
                if (new CamadaDados.Faturamento.PDV.TCD_NFCe().BuscarEscalar(
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
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_cupom " +
                                        "and x.cd_empresa = '" + lVenda[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + lVenda[0].Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui cupom fiscal/NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui nfe
                if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.cd_empresa = '" + lVenda[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + lVenda[0].Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui Faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {

                    lVenda[0].lItem =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(lVenda[0].Id_vendarapidastr,
                                                                              lVenda[0].Cd_empresa,
                                                                              false,
                                                                              string.Empty,
                                                                              null);
                    //Processar cupom fiscal
                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                    //Buscar dados PDV
                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                }
                            }, "a.id_pdv");
                    if (obj == null)
                    {
                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
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
                                vVL_Busca = obj.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                            }
                        }, "1") == null)
                        CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                            new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                            {
                                Id_pdvstr = obj.ToString(),
                                Login = Utils.Parametros.pubLogin
                            }, null);
                    //Buscar sessao aberta
                    dados.rSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(obj.ToString(),
                                                                                    string.Empty,
                                                                                    Utils.Parametros.pubLogin,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    "'A'",
                                                                                    1,
                                                                                    null)[0];
                    dados.lItens = lVenda[0].lItem;
                    dados.Cd_clifor = lVenda[0].Cd_clifor;
                    dados.Nm_clifor = lVenda[0].Nm_clifor;
                    dados.CpfCgc = string.Empty;
                    dados.Endereco = string.Empty;
                    dados.Mensagem = string.Empty;
                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                    dados.St_vendacombustivel = false;
                    dados.St_cupomavulso = true;
                    dados.St_agruparProduto = false;

                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                    if (rNFCe != null)
                        if (!rNFCe.St_contingencia)
                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                            {
                                fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                  rNFCe.Id_nfcestr,
                                                                                                  null);
                                fGerNfe.ShowDialog();
                            }
                        else
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            BindingSource dts = new BindingSource();
                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                            Rel.DTS_Relatorio = dts;// bsItens;
                            //DTS Cupom
                            BindingSource bsNFCe = new BindingSource();
                            bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                  rNFCe.Id_nfcestr,
                                                                                                  null);
                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                            //Buscar Empresa
                            BindingSource bsEmpresa = new BindingSource();
                            bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rEmpresa };
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
                                        vVL_Busca = "(select 1 from  x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_vendarapida = a.id_cupom " +
                                                    "and x.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                    "and x.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
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
                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.id_cupom = y.id_vendarapida " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                        "and y.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
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
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
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
                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                  (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
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
                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                Rel.DTS_Relatorio = bsItens;
                            }
                            if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
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
                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
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
            {
                using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                {
                    fGerar.St_NFCe = true;
                    if (fGerar.ShowDialog() == DialogResult.OK)
                        if (fGerar.lItens != null)
                            if (fGerar.lItens.Count > 0)
                            {
                                try
                                {
                                    //Processar cupom fiscal
                                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                    //Buscar dados PDV
                                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.id_pdv");
                                    if (obj == null)
                                    {
                                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
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
                                                vVL_Busca = obj.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                            }
                                        }, "1") == null)
                                        CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                                            new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                                            {
                                                Id_pdvstr = obj.ToString(),
                                                Login = Utils.Parametros.pubLogin
                                            }, null);
                                    //Buscar sessao aberta
                                    dados.rSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(obj.ToString(),
                                                                                                    string.Empty,
                                                                                                    Utils.Parametros.pubLogin,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    "'A'",
                                                                                                    1,
                                                                                                    null)[0];
                                    dados.lItens = fGerar.lItens;
                                    dados.Cd_clifor = string.Empty;
                                    dados.Nm_clifor = string.Empty;
                                    dados.CpfCgc = string.Empty;
                                    dados.Endereco = string.Empty;
                                    dados.Mensagem = string.Empty;
                                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                    dados.St_vendacombustivel = false;
                                    dados.St_cupomavulso = true;
                                    dados.St_agruparProduto = false;

                                    PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                    if (rNFCe != null)
                                        if (!rNFCe.St_contingencia)
                                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                            {
                                                fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                  null);
                                                fGerNfe.ShowDialog();
                                            }
                                        else
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource dts = new BindingSource();
                                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                            Rel.DTS_Relatorio = dts;// bsItens;
                                            //DTS Cupom
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
                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                                CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                   string.Empty,
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
                                                                    "and x.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
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
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
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
                                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
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
                                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                  (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
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
                                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                Rel.DTS_Relatorio = bsItens;
                                            }
                                            if (rNFCe.Id_contingencia.HasValue)
                                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                else
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                            //Verificar se existe Impressora padrão para o PDV
                                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
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
                                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
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
                                MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            GerarNFCe();
        }

        private void bsPreVendaItem_PositionChanged(object sender, EventArgs e)
        {
            if (bsItemAberto.Current != null)
            {
                (bsItemAberto.Current as TRegistro_PreVenda_Item).lSabores =
                    TCN_SaboresItens.Buscar(
                        (bsItemAberto.Current as TRegistro_PreVenda_Item).Cd_empresa,
                        (bsItemAberto.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                        (bsItemAberto.Current as TRegistro_PreVenda_Item).id_item.ToString(),
                        string.Empty, null);
                bsItemAberto.ResetCurrentItem();
            }
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (bsAberto.Current != null)
                using (Restaurante.Cadastro.TFCliforDetalhado ae = new Cadastro.TFCliforDetalhado())
                {
                    TList_Clifor cli = new TList_Clifor();
                    cli = new TCD_Clifor().Select(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = (bsAberto.Current as TRegistro_PreVenda).cd_clifor
                        }
                        }, 0, string.Empty);
                    if (cli.Count > 0)
                        ae.rClifor = cli[0];

                    if (ae.ShowDialog() == DialogResult.OK)
                    {
                        TCN_CliFor.Gravar(ae.rClifor, null);
                        MessageBox.Show("Cliente Gravado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        bsAberto.ResetCurrentItem();
                    }
                }
        }

        private void dataGridDefault2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex.Equals(1))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENTREGA"))
                        dataGridDefault2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        dataGridDefault2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void bsEntrega_PositionChanged(object sender, EventArgs e)
        {
            if (bsEntrega.Current != null)
            {
                (bsEntrega.Current as TRegistro_PreVenda).lItens =
                    TCN_PreVenda_Item.Buscar(
                        (bsEntrega.Current as TRegistro_PreVenda).Cd_empresa,
                        (bsEntrega.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                        string.Empty, string.Empty, null);
                bsItemEntrega_PositionChanged(this, new EventArgs());
            }
            bsEntrega.ResetCurrentItem();
        }

        private void bsItemEntrega_PositionChanged(object sender, EventArgs e)
        {
            if (bsItemEntrega.Current != null)
            {
                (bsItemEntrega.Current as TRegistro_PreVenda_Item).lSabores =
                    TCN_SaboresItens.Buscar(
                        (bsItemEntrega.Current as TRegistro_PreVenda_Item).Cd_empresa,
                        (bsItemEntrega.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                        (bsItemEntrega.Current as TRegistro_PreVenda_Item).id_item.ToString(),
                        string.Empty, null);
                //bsItemEntrega.ResetCurrentItem();
            }
        }

        private void btn_ImprimirEntrega_Click(object sender, EventArgs e)
        {
            afterPrint(bsEntrega.Current as TRegistro_PreVenda);
        }

        private void btn_excluirVenda_Click(object sender, EventArgs e)
        {
            afterExclui(bsEntrega.Current as TRegistro_PreVenda);
        }

        private void btn_fecharComanda_Click(object sender, EventArgs e)
        {
            FecharComanda();
        }

        private void dataGridDefault6_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridDefault6.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEntrega.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PreVenda());
            TList_PreVenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((dataGridDefault6.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (dataGridDefault6.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PreVenda(lP.Find(dataGridDefault6.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in dataGridDefault6.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PreVenda(lP.Find(dataGridDefault6.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in dataGridDefault6.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEntrega.List as List<TRegistro_PreVenda>).Sort(lComparer);
            bsEntrega.ResetBindings(false);
            dataGridDefault6.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
