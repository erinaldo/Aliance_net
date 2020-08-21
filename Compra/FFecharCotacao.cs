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
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFFecharCotacao : Form
    {
        public string pStatus
        { get; set; }
        private CamadaDados.Compra.TList_CFGCompra lCfg
        { get; set; }
        private bool Altera_Relatorio = false;
        public TFFecharCotacao()
        {
            InitializeComponent();
        }

        private void HabilitarFechar()
        {
            bb_habilitarAprovacao.Text = "Avançar p/ Aprovar Cotação";
            tlpCentral.RowStyles[0] = new RowStyle(SizeType.Absolute, 0);
            TS_AprovarCotacao.Visible = false;
            bbEstornarAprovacao.Visible = false;
            bbGerarOrdemCompra.Visible = false;
            bbEstornarAprovacao.Visible = false;
            bbFecharCotacao.Text = "Fechar Cotação";
            bb_habilitarAprovacao.Visible = true;
            bb_gerarPedido.Visible = false;
            bb_cancelarOrdemCompra.Visible = false;
            pSt_aprovar.Visible = false;
            pSt_fechar.Visible = true;
            cbTodos.Visible = true;
            pDs_condPgto.Visible = pStatus.ToUpper().Equals("OC");
        }

        private void HabilitarAprovar()
        {
            bb_habilitarAprovacao.Text = "Aprovar Cotação";
            bbFecharCotacao.Text = "Retornar p/ Fechar Cotação";
            bbGerarOrdemCompra.Text = "Avançar p/ Ordem Compra";
            tlpCentral.RowStyles[0] = new RowStyle(SizeType.Absolute, 0);
            TS_AprovarCotacao.Visible = true;
            bb_habilitarAprovacao.Visible = false;
            bbFecharCotacao.Visible = true;
            bbEstornarAprovacao.Visible = false;
            TS_AprovarCotacao.Visible = true;
            bbGerarOrdemCompra.Visible = true;
            bb_gerarPedido.Visible = false;
            bb_cancelarOrdemCompra.Visible = false;
            pSt_aprovar.Visible = true;
            pSt_fechar.Visible = false;
            this.Text = "Aprovar Cotação";
            cbTodos.Visible = false;
            pDs_condPgto.Visible = pStatus.ToUpper().Equals("OC");
        }

        private void HabilitarOrdemCompra()
        {
            bb_habilitarAprovacao.Text = "Retornar p/ Aprovar Cotação";
            tlpCentral.RowStyles[0] = new RowStyle(SizeType.Absolute, 135);
            TS_AprovarCotacao.Visible = false;
            bbFecharCotacao.Visible = false;
            bbEstornarAprovacao.Visible = true;
            bb_habilitarAprovacao.Visible = true;
            bb_gerarPedido.Visible = true;
            this.Text = "Gerar Ordem Compra";
            bbGerarOrdemCompra.Text = "Gerar Ordem Compra";
            bb_gerarPedido.Text = "Avançar p/ Gerar Pedido";
            bb_cancelarOrdemCompra.Visible = false;
            pSt_aprovar.Visible = false;
            pSt_fechar.Visible = true;
            cbTodos.Visible = true;
            pDs_condPgto.Visible = pStatus.ToUpper().Equals("OC");
        }

        private void HabilitarGerarPedido()
        {
            bbGerarOrdemCompra.Text = "Retornar p/ Ordem Compra";
            TS_AprovarCotacao.Visible = false;
            bbFecharCotacao.Visible = false;
            bbEstornarAprovacao.Visible = false;
            bb_habilitarAprovacao.Visible = false;
            bb_cancelarOrdemCompra.Visible = true;
            pSt_aprovar.Visible = false;
            pSt_fechar.Visible = true;
            bb_gerarPedido.Text = "Gerar Pedido";
            this.Text = "Gerar Pedido";
            cbTodos.Visible = false;
            pDs_condPgto.Visible = pStatus.ToUpper().Equals("OC");
        }

        private void BuscarFornecedor(string status)
        {
            pStatus = status;
            bsClifor.DataSource =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                        "inner join TB_EST_Produto z " +
                                        "on x.cd_grupo = z.cd_grupo " +
                                        "where a.CD_Clifor = x.CD_Clifor " +
                                        "and exists(select 1 from TB_CMP_Requisicao y " +
                                        "           inner join TB_CMP_Cotacao h " +
                                                    "on y.id_requisicao = h.id_requisicao " +
                                                    "and y.cd_empresa = h.cd_empresa " +
                                                    //se for gerar pedido buscar ordem compras abertas
                                                    (status.ToUpper().Equals("OC") ?
                                                    "inner join TB_CMP_OrdemCompra o " +
                                                    "on y.id_requisicao = o.id_requisicao " +
                                                    "and y.cd_empresa = o.cd_empresa " : string.Empty) +
                                                    "where y.cd_produto = z.cd_produto " +
                                                    "and h.CD_Fornecedor = a.cd_clifor " +
                                                    (status.ToUpper().Equals("OC") ?
                                                    "and isnull(o.ST_Registro, 'A') = 'A' " : string.Empty) +
                                                    "and h.ST_Registro = " + (status.ToUpper().Equals("AP") || status.ToUpper().Equals("OC")  ? "'P'" : "'A'") + " " +
                                                    "and y.ST_Requisicao in " + (status.ToUpper().Equals("FE") ?  "('AC', 'RN')"  : 
                                                                                 status.ToUpper().Equals("AA") ? "('AA')" :
                                                                                 status.ToUpper().Equals("AP") ? "('AP')" :
                                                                                 status.ToUpper().Equals("OC") ? "('OC')" : string.Empty) + "))"
                        }
                    }, 0, string.Empty);
            cbTodos.Checked = false;
            bsClifor_PositionChanged(this, new EventArgs());
            bsClifor.ResetCurrentItem();
        }

        private void AprovarRequisicao()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Count > 0)
                {
                    //Verificar se existe alguma negociacao selecionada
                    if (!(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar uma negociação para aprovar requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count > 0)
                {
                    //Verificar se existe alguma cotacao selecionada
                    if (!(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Exists(p => p.St_integrar))
                    {
                        MessageBox.Show("Obrigatorio selecionar uma cotação para aprovar requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                try
                {
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao = "AP";//Aprovada
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Qtd_aprovada = 
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Find(p => p.St_integrar).Qtd_atendida;
                    CamadaNegocio.Compra.Lancamento.TCN_Requisicao.ProcessarRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                    MessageBox.Show("Requisição aprovada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BuscarFornecedor(pStatus);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RenegociarRequisicao()
        {
            if (bsRequisicao.Current != null)
            {
                if (MessageBox.Show("Confirma a renegociação da requisição selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao = "RN";//Renegociar
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.ProcessarRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                        MessageBox.Show("Requisição renegociada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BuscarFornecedor(pStatus);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void EstornarAprovacao()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar))
                {
                    if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("AA"))
                    {
                        MessageBox.Show("Requisição ainda não foi processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma o estorno do processamento da requisição?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_Requisicao.EstornarProcessamentoRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                            MessageBox.Show("Processamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarFornecedor(pStatus);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void GerarOrdemCompra()
        {
            if (bsRequisicao.Current != null)
                if ((bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar))
                    if (MessageBox.Show("Deseja gerar ordem compra das requisições selecionadas?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            List<CamadaDados.Compra.Lancamento.TRegistro_Requisicao> lReqProc = (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).FindAll(p => p.St_integrar);
                            if (lReqProc.Exists(p => p.lCotacoes.Count.Equals(0)))
                            {
                                lReqProc.ForEach(p =>
                                    {
                                        if (p.lCotacoes.Count.Equals(0))
                                        {
                                            p.lCotacoes =
                                                CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                                                  (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                                                                  p.Cd_empresa,
                                                                                                  p.Id_requisicao.ToString(),
                                                                                                  1,
                                                                                                  string.Empty,
                                                                                                  "'P'",
                                                                                                  null);
                                        }
                                    });
                            }
                            CamadaNegocio.Compra.Lancamento.TCN_Requisicao.ProcessarOrdemCompra(lReqProc, null);
                            MessageBox.Show("Ordem de Compra geradas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarFornecedor(pStatus);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
        }

        private void GerarPedido()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar))
                {
                    List<CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra> lOC = new List<CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra>();
                    (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).FindAll(p => p.St_integrar).ForEach(p =>
                        {
                            CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra val =
                                 new CamadaDados.Compra.Lancamento.TCD_OrdemCompra().Select(
                                     new Utils.TpBusca[]
                                     {
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "a.id_requisicao",
                                             vOperador = "=",
                                             vVL_Busca = p.Id_requisicao.ToString()
                                         },
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "a.cd_empresa",
                                             vOperador = "=",
                                             vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                         },
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "a.ST_Registro",
                                             vOperador = "=",
                                             vVL_Busca = "'A'"
                                         }
                                     }, 1, string.Empty)[0];
                            if (val != null)
                                lOC.Add(val);
                        });
                    using (TFListaPed fLista = new TFListaPed())
                    {
                        fLista.pCd_empresa = lOC[0].Cd_empresa;
                        if (fLista.ShowDialog() == DialogResult.OK)
                            if (!string.IsNullOrEmpty(fLista.Cfg_pedido))
                                try
                                {
                                    CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                                    object st_dup = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(null, "a.st_gerarfin");
                                    if (st_dup != null )
                                        if (st_dup.Equals("S"))
                                    using (Financeiro.TFLanDuplicata dp = new Financeiro.TFLanDuplicata())
                                    {
                                        decimal total = decimal.Zero;
                                        string valida = string.Empty;
                                        lOC.ForEach(p =>
                                        {
                                            total += p.Vl_subtotal;
                                            if (p.Cd_condpgto.Equals(valida) || valida == string.Empty)
                                                valida = p.Cd_condpgto;
                                            else
                                            {
                                                MessageBox.Show("Existe condicao de pagamento diferente, e devem ser iguais!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                                return;
                                            }
                                        });
                                        CamadaDados.Compra.TList_CFGCompra lcfg = new CamadaDados.Compra.TCD_CFGCompra().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador= "=",
                                                    vVL_Busca = lOC[0].Cd_empresa
                                                }
                                            }, 1, string.Empty);


                                        dp.vCd_condpgto = lOC[0].Cd_condpgto;
                                        dp.vCd_clifor = lOC[0].Cd_fornecedor;
                                        dp.vNm_clifor = lOC[0].Nm_fornecedor;
                                        dp.vTp_docto = lcfg[0].tp_doc;
                                        dp.vDs_tpdocto = lcfg[0].ds_doc;
                                        dp.vTp_duplicata = lcfg[0].id_duplicata;
                                        dp.vDs_tpduplicata = lcfg[0].ds_dup;
                                        dp.vCd_endereco = lOC[0].Cd_endfornecedor;
                                        dp.vDs_endereco = lOC[0].Ds_endfornecedor;
                                        dp.vVl_documento = total;
                                        dp.vCd_empresa = lOC[0].Cd_empresa;
                                        //Buscar Moeda Padrao
                                        CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                                            CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(lOC[0].Cd_empresa, null);
                                        if (tabela != null)
                                            if (tabela.Count > 0)
                                            {
                                                dp.vCd_moeda = tabela[0].Cd_moeda;
                                                dp.vDs_moeda = tabela[0].Ds_moeda_singular;
                                                dp.vSigla_moeda = tabela[0].Sigla;
                                                dp.vCd_moeda_padrao = tabela[0].Cd_moeda;
                                                dp.vDs_moeda_padrao = tabela[0].Ds_moeda_singular;
                                                dp.vSigla_moeda_padrao = tabela[0].Sigla;
                                                dp.vNr_docto = "N° PEDIDO";
                                            }

                                        dp.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");

                                        if (dp.ShowDialog() == DialogResult.OK)
                                            rDup = dp.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    }

                                    CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.ProcessarPedido(lOC, fLista.Cfg_pedido, rDup, null, null);
                                    MessageBox.Show("Pedido Nº" + lOC[0].Nr_pedido.ToString() + " gerado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    PrintPedido(lOC[0].Nr_pedido.ToString());
                                    BuscarFornecedor(pStatus);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            else MessageBox.Show("Obrigatório selecionar CONFIG. PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Obrigatório selecionar CONFIG. PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                }
                else
                    MessageBox.Show("Obrigatorio selecionar Ordem Compra para Gerar Pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintPedido(string Nr_pedido)
        {
            //Buscar Pedido
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                TList_Pedido lPedido = new TCD_Pedido().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lCfg[0].Cd_empresa.Trim() + "'" 
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = Nr_pedido
                            }
                        }, 1, string.Empty);
                if (lPedido.Count > 0)
                {
                    TRegistro_Pedido pedido = lPedido[0];
                    TCN_Pedido.Busca_CFG_Fiscal(pedido);
                    TCN_Pedido.Busca_Pedido_Itens(pedido, false, null);
                    pedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(pedido.Nr_pedido, null);
                    if (pedido.Pedido_Itens.Count > 0)
                        pedido.Pedidos_DT_Vencto.ForEach(p => p.Vl_juro_fin = Math.Round((p.VL_Parcela * pedido.Pedido_Itens[0].Pc_juro_fin) / 100, 2));

                    BindingSource binItens = new BindingSource();
                    binItens.DataSource = pedido.Pedido_Itens;
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca(lPedido[0].CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = TCN_CadClifor.Busca_Clifor(lPedido[0].CD_Clifor,
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

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = TCN_CadEndereco.Buscar(lPedido[0].CD_Clifor,
                                                                    lPedido[0].CD_Endereco,
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

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + lPedido[0].CD_Clifor + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lPedido[0].CD_Empresa + "'"
                                            }
                                        }, "a.cd_clifor");
                    BindingSource BinDadosFin = new BindingSource();
                    BinDadosFin.DataSource = TCN_CadDados_Bancarios_Clifor.Busca(cliforEmpresa.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         false,
                                                                         false,
                                                                         false,
                                                                         string.Empty,
                                                                         0,
                                                                         null);

                    BindingSource BinParcelas = new BindingSource();
                    BinParcelas.DataSource = CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_DT_Vencto.Busca(lPedido[0].Nr_pedido,
                                                                                                             null);

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                                lPedido[0].CD_Clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                false,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    //Buscar % ICMS, ST, IPI da Cotação
                    (binItens.DataSource as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).ForEach(p =>
                    {
                        CamadaDados.Compra.Lancamento.TList_Cotacao lCot =
                            new CamadaDados.Compra.Lancamento.TCD_Cotacao().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_CMP_Requisicao x " +
                                                    "inner join TB_CMP_OrdemCompra y " +
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.id_requisicao = y.id_requisicao " +
                                                    "inner join TB_CMP_OrdemCompra_X_PedItem k " +
                                                    "on y.id_oc = k.id_oc " +
                                                    "and k.Nr_pedido = " + p.Nr_PedidoString + " " +
                                                    "and k.ID_PedidoItem = " + p.Id_pedidoitem.ToString() + " " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.id_requisicao = x.id_requisicao) "

                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    }
                                }, 1, string.Empty);
                        if (lCot.Count > 0)
                        {
                            p.Vl_IPI = lCot[0].Vl_ipi;
                            p.Vl_subst = lCot[0].Vl_icmssubst;
                            p.Pc_icms = lCot[0].Pc_icms;
                        }
                    });


                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");
                    if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        try
                        {
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.ImprimirPedido(pedido,
                                                                                       BinClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor,
                                                                                       BinEndereco.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco,
                                                                                       BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFLan_Pedido";
                        Relatorio.NM_Classe = "TFLan_Pedido";
                        Relatorio.Modulo = "FAT";

                        TList_Pedido lista_pedido = new TList_Pedido();
                        lista_pedido.Add(pedido);
                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = lista_pedido;
                        Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                        Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                        Relatorio.Adiciona_DataSource("ITENS", binItens);
                        Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                        Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                        Relatorio.Adiciona_DataSource("PARCELAS", BinParcelas);
                        Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                        Relatorio.DTS_Relatorio = meu_bind;

                        Relatorio.Ident = "FLan_Pedido";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = lPedido[0].CD_Clifor;
                                fImp.pMensagem = "PEDIDO Nº " + lPedido[0].Nr_pedido.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio(lPedido[0].Nr_pedido.ToString(),
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             ("PEDIDO Nº ") + lPedido[0].Nr_pedido.ToString(),
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
            }
        }

        private void TFFecharCotacao_Load(object sender, EventArgs e)
        {
            //Buscar CFG.Compra
             lCfg = CamadaNegocio.Compra.TCN_CFGCompra.Buscar(string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          1,
                                                          string.Empty,
                                                          null);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Fechar cotação
            if (pStatus.ToUpper().Equals("FE"))
                this.HabilitarFechar();
            //Aprovar Cotação
            else if (pStatus.ToUpper().Equals("AA"))
                this.HabilitarAprovar();
            //Gerar Ordem Compra
            else if (pStatus.ToUpper().Equals("AP"))
                this.HabilitarOrdemCompra();
            //Gerar Pedido
            else if (pStatus.ToUpper().Equals("OC"))
                this.HabilitarGerarPedido();
            this.BuscarFornecedor(pStatus);
        }

        private void bsClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                bsRequisicao.DataSource =
                    new CamadaDados.Compra.Lancamento.TCD_Requisicao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                            "inner join TB_CMP_Cotacao y " +
                                            "on y.id_requisicao = a.id_requisicao " +
                                            "and y.cd_empresa = a.cd_empresa " +
                                            //se for gerar pedido buscar ordem compras abertas
                                            (pStatus.ToUpper().Equals("OC") ?
                                                    "inner join TB_CMP_OrdemCompra o " +
                                                    "on a.id_requisicao = o.id_requisicao " +
                                                    "and a.cd_empresa = o.cd_empresa " : string.Empty) +
                                            "inner join TB_EST_Produto z " +
                                            "on x.cd_grupo = z.cd_grupo " +
                                            "where a.cd_produto = z.cd_produto " +
                                            (pStatus.ToUpper().Equals("OC") ?
                                                    "and isnull(o.ST_Registro, 'A') = 'A' " : string.Empty) +
                                             "and y.ST_Registro = " + (pStatus.ToUpper().Equals("AP") || pStatus.ToUpper().Equals("OC") ? "'P'" : "'A'") + " " +
                                             (pStatus.ToUpper().Equals("AP") || pStatus.ToUpper().Equals("OC") ?
                                             "and y.CD_Fornecedor = '" + (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor.Trim() + "'" : string.Empty) + 
                                            "and a.ST_Requisicao in " + (pStatus.ToUpper().Equals("FE") ?  "('AC', 'RN')"  : 
                                                                         pStatus.ToUpper().Equals("AA") ? "('AA')" :
                                                                         pStatus.ToUpper().Equals("AP") ? "('AP')" :
                                                                         pStatus.ToUpper().Equals("OC") ? "('OC')" : string.Empty) + ") "

                            }
                        }, 0, string.Empty, string.Empty);
                bsRequisicao_PositionChanged(this, new EventArgs());
                bsRequisicao.ResetCurrentItem();
            }
            else
                bsRequisicao.Clear();
        }


        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (bsRequisicao.Current != null)
                {
                    //Buscar cotacoes da requisicao
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes =
                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                           string.Empty,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                                                           0,
                                                                           string.Empty,
                                                                           pStatus.ToUpper().Equals("OC") ? "'P'" : string.Empty,
                                                                           null);
                    (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tot_cotado =
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Sum(p => p.Vl_subtotal);
                     bsRequisicao.ResetCurrentItem();
                }
        }

        private void gRequisicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (pStatus.ToUpper().Equals("OC"))
                {
                    if ((bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar && (p.Cd_condPgto.Trim() != (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_condPgto.Trim())))
                    {
                        MessageBox.Show("Não é possivel gerar pedido com condições de pagamento diferentes!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar =
                    !(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar;
                bsRequisicao.ResetCurrentItem();
            }
        }

        private void bbFecharCotacao_Click(object sender, EventArgs e)
        {
            if (pStatus.ToUpper().Equals("FE"))
            {
                if (bsRequisicao.Current != null)
                    if ((bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar))
                        try
                        {
                            (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).FindAll(p => p.St_integrar).ForEach(p =>
                                CamadaNegocio.Compra.Lancamento.TCN_Requisicao.FecharCotacoesRequisicao(p, null));
                            MessageBox.Show("Cotações fechadas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarFornecedor("FE");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                pStatus = "FE";
                this.HabilitarFechar();
                this.BuscarFornecedor(pStatus);
            }
        }

        private void gCotacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Exists(p=> p.St_integrar) ||
                    (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar)
                {
                    (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar =
                        !(bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar;
                }
            }
        }

        private void bb_habilitarAprovacao_Click(object sender, EventArgs e)
        {
            pStatus = "AA";
            this.HabilitarAprovar();
            this.BuscarFornecedor(pStatus);
        }

        private void bbAprovarCotacao_Click(object sender, EventArgs e)
        {
            this.AprovarRequisicao();
        }

        private void bbRenegociar_Click(object sender, EventArgs e)
        {
            this.RenegociarRequisicao();
        }

        private void bbEstornarAprovacao_Click(object sender, EventArgs e)
        {
            this.EstornarAprovacao();
        }

        private void bbGerarOrdemCompra_Click(object sender, EventArgs e)
        {
            if (pStatus.ToUpper().Equals("AA") || pStatus.ToUpper().Equals("OC"))
            {
                pStatus = "AP";
                this.HabilitarOrdemCompra();
                this.BuscarFornecedor(pStatus);
            }
            else
                this.GerarOrdemCompra();
        }

        private void gCotacao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCotacao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCotacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Compra.Lancamento.TRegistro_Cotacao());
            CamadaDados.Compra.Lancamento.TList_Cotacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCotacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCotacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Cotacao(lP.Find(gCotacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCotacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Cotacao(lP.Find(gCotacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCotacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCotacao.List as CamadaDados.Compra.Lancamento.TList_Cotacao).Sort(lComparer);
            bsCotacao.ResetBindings(false);
            gCotacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gRequisicao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRequisicao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsRequisicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Compra.Lancamento.TRegistro_Requisicao());
            CamadaDados.Compra.Lancamento.TList_Requisicao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Sort(lComparer);
            bsRequisicao.ResetBindings(false);
            gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_gerarPedido_Click(object sender, EventArgs e)
        {
            if (pStatus.ToUpper().Equals("AP"))
            {
                pStatus = "OC";
                this.HabilitarGerarPedido();
                this.BuscarFornecedor(pStatus);
            }
            else
                this.GerarPedido();
        }

        private void bb_cancelarOrdemCompra_Click(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
            {
                CamadaDados.Compra.Lancamento.TList_OrdemCompra lOrdem =
                         new CamadaDados.Compra.Lancamento.TCD_OrdemCompra().Select(
                             new Utils.TpBusca[]
                                     {
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "a.id_requisicao",
                                             vOperador = "=",
                                             vVL_Busca = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.ToString()
                                         },
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "a.cd_empresa",
                                             vOperador = "=",
                                             vVL_Busca = "'" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa.Trim() + "'"
                                         },
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = "isnull(a.st_registro, 'A')",
                                             vOperador = "=",
                                             vVL_Busca = "'A'"
                                         }
                                     }, 1, string.Empty);
                if (MessageBox.Show("Confirma cancelamento da ordem de compra?", "Pergunta", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.Estornar(lOrdem[0], null);
                        MessageBox.Show("Ordem Compra cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BuscarFornecedor(pStatus);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TFFecharCotacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsRequisicao.Count > 0)
            {
                (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).ForEach(p => p.St_integrar = cbTodos.Checked);
                bsRequisicao.ResetBindings(true);
            }
        }
    }
}
