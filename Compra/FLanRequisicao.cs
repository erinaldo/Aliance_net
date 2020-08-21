using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFLanRequisicao : Form
    {
        public bool Altera_Relatorio = false;
        private bool St_visualizartodas = false;
        private bool St_aprovar
        { get; set; }
        private bool St_comprar
        { get; set; }
        private int Tot_req = 0;
        private int Tot_aguard = 0;
        private CamadaDados.Compra.TList_CadUsuarioCompra lUser
        { get; set; }

        private System.Threading.Thread thNovaReq;

        public TFLanRequisicao()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFRequisicao fReq = new TFRequisicao())
            {
                if (fReq.ShowDialog() == DialogResult.OK)
                {
                    if (fReq.rReq != null)
                    {
                        try
                        {
                            if (fReq.rReq.Tp_requisicao.Trim().ToUpper().Equals("E"))
                            {
                                //Verificar se existe alguma negociacao aprovada para este produto
                                CamadaDados.Compra.Lancamento.TList_NegociacaoItem lNegociacao =
                                    new CamadaDados.Compra.Lancamento.TCD_NegociacaoItem().Select(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(d.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'V'"
                                    },
                                    //Dentro do prazo de vigencia
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "(case when a.NR_DiasVigencia = 0 then CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), GETDATE()))) else "+
                                                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), d.dt_fechnegociacao)) + a.NR_DiasVigencia) end "+
                                                    ") >= "+
                                                    "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), GETDATE()))) "
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "((d.cd_produto = '"+fReq.rReq.Cd_produto.Trim()+"') or ("+
                                                    "exists(select 1 from tb_est_produto x "+
                                                    "where x.cd_grupo = d.cd_grupo "+
                                                    "and x.cd_produto = '"+fReq.rReq.Cd_produto.Trim()+"' "+
                                                    "and isnull(d.cd_produto, '') = '')))"
                                    }
                                }, 0, string.Empty, string.Empty);
                                if (lNegociacao.Count > 0)
                                {
                                    //Chamar tela de negociacao
                                    using (TFListaFornecedor fFornec = new TFListaFornecedor())
                                    {
                                        CamadaDados.Compra.TList_CFGCompra lCfg =
                                            CamadaNegocio.Compra.TCN_CFGCompra.Buscar(cd_empresa.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
                                        if (lCfg.Count > 0)
                                            fFornec.Qtd_negociacao = lCfg[0].Qtd_min_negociacao;
                                        fFornec.lItens = lNegociacao;
                                        fFornec.St_requisicao = true;
                                        fFornec.Text = "Lista de Negociação em vigencia do produto " + cd_produto.Text.Trim();
                                        if (fFornec.ShowDialog() == DialogResult.OK)
                                        {
                                            //Montar lista de negociacao selecionada
                                            fFornec.lItens.ForEach(p =>
                                                {
                                                    if (p.St_processar)
                                                        fReq.rReq.lReqneg.Add(
                                                            new CamadaDados.Compra.Lancamento.TRegistro_Requisicao_X_Negociacao()
                                                            {
                                                                Id_negociacao = p.Id_negociacao,
                                                                Id_item = p.Id_item
                                                            });
                                                });
                                            //Mudar status da ordem para Aguardando Aprovacao
                                            fReq.rReq.St_requisicao = "AA";
                                            lNegociacao.ForEach(p =>
                                            {
                                                fReq.rReq.lCotacoes.Add(new CamadaDados.Compra.Lancamento.TRegistro_Cotacao()
                                                {
                                                    Cd_empresa = fReq.rReq.Cd_empresa,
                                                    Cd_fornecedor = p.Cd_fornecedor,
                                                    Cd_endfornecedor = p.Cd_endfornecedor,
                                                    Cd_condpgto = p.Cd_condpgto,
                                                    Cd_moeda = p.Cd_moeda,
                                                    Cd_portador = p.Cd_portador,
                                                    Nm_vendedor = p.Nm_vendedor,
                                                    Emailvendedor = p.Email_vendedor,
                                                    Fonefax = p.FoneFax,
                                                    Qtd_atendida = fReq.rReq.Quantidade,
                                                    Vl_unitario_cotado = p.Vl_unitario_negociado,
                                                    Dt_cotacao = CamadaDados.UtilData.Data_Servidor(),
                                                    Ds_observacao = p.Ds_observacao,
                                                    Nr_diasvigencia = p.Nr_diasvigencia,
                                                    St_registro = "A"
                                                });
                                            });
                                        }
                                    }
                                }
                            }
                            else
                            {
                                fReq.rReq.St_requisicao = "AP";//Requisicao INTERNA ja entra como APROVADA
                                fReq.rReq.Qtd_aprovada = fReq.rReq.Quantidade;
                            }
                            //Verificar se existe requisicao com o mesmo o produto sem cotacoes lancadas
                            CamadaDados.Compra.Lancamento.TList_Requisicao lReq =
                                  new CamadaDados.Compra.Lancamento.TCD_Requisicao().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fReq.rReq.Cd_empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fReq.rReq.Cd_produto.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.CD_Clifor_Requisitante",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fReq.rReq.Cd_clifor_requisitante.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_tprequisicao",
                                                    vOperador = "=",
                                                    vVL_Busca = fReq.rReq.Id_tprequisicaostr
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_local",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fReq.rReq.Cd_local + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.ST_Requisicao, 'AC')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'AC'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "not exists",
                                                    vVL_Busca = "(select 1 from tb_cmp_cotacao x " +
                                                                "where a.cd_empresa = x.cd_empresa " +
                                                                "and a.id_requisicao = x.id_requisicao) "
                                                }
                                            }, 1, string.Empty, string.Empty);
                            if (lReq.Count > 0)
                                if (MessageBox.Show("A requisição Nº" + lReq[0].Id_requisicao.ToString() + " com data " + lReq[0].Dt_requisicaostr + ".\r\n" +
                                    "Ainda não possui cotações lançadas.\r\n" +
                                    "Deseja adicionar a QTD lançada para esta requisição?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    fReq.rReq.Id_requisicao = lReq[0].Id_requisicao;
                                    fReq.rReq.Quantidade = fReq.rReq.Quantidade + lReq[0].Quantidade;
                                    fReq.rReq.Ds_observacao = lReq[0].Ds_observacao + "\r\n" + fReq.rReq.Ds_observacao;
                                }
                            CamadaNegocio.Compra.Lancamento.TCN_Requisicao.GravarRequisicao(fReq.rReq, null);
                            MessageBox.Show("Requisição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void afterAltera()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("AC"))
                {
                    if ((new CamadaDados.Compra.TCD_CadUsuarioCompra().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor_cmp",
                                vOperador = "=",
                                vVL_Busca = (!string.IsNullOrEmpty((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_clifor_requisitante) ?
                                                 "'" +  (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_clifor_requisitante.Trim()+ "'" : "a.cd_clifor_cmp")
                            }
                        }, "a.login").ToString() != Utils.Parametros.pubLogin) &&
                        (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR REQUISICAO OUTRO USUARIO", null)))
                    {
                        MessageBox.Show("Usuário não tem permissão para alterar requisição de outro comprador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFRequisicao fReq = new TFRequisicao())
                    {
                        fReq.rReq = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao);
                        if (fReq.ShowDialog() == DialogResult.OK)
                        {
                            if (fReq.rReq != null)
                            {
                                try
                                {
                                    CamadaNegocio.Compra.Lancamento.TCN_Requisicao.AlterarRequisicao(fReq.rReq, null);
                                    MessageBox.Show("Requisição alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido alterar somente requisição com status <AGUARDANDO COTACAO>.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterExclui()
        {
            if (bsRequisicao.Current != null)
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.Trim().ToUpper().Equals("OC"))
                {
                    MessageBox.Show("Não é permitido excluir requisição com status <ORDEM COMPRA>.\r\n" +
                                    "Necessario antes excluir Ordem Compra.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
            if (MessageBox.Show("Confirma exclusão da requisição?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Compra.Lancamento.TCN_Requisicao.DeletarRequisicao(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao, null);
                    MessageBox.Show("Requisição excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void afterBusca()
        {
            string Status = string.Empty;
            string virg = string.Empty;
            if (st_ac.Checked)
            {
                Status += virg.Trim() + "'AC'";
                virg = ",";
            }
            if (st_aa.Checked)
            {
                Status += virg.Trim() + "'AA'";
                virg = ",";
            }
            if (st_cancelada.Checked)
            {
                Status += virg.Trim() + "'CA'";
                virg = ",";
            }
            if (st_ap.Checked)
            {
                Status += virg.Trim() + "'AP'";
                virg = ",";
            }
            if (st_rp.Checked)
            {
                Status += virg.Trim() + "'RE'";
                virg = ",";
            }
            if (st_rn.Checked)
            {
                Status += virg.Trim() + "'RN'";
                virg = ",";
            }
            string tp = string.Empty;
            virg = string.Empty;
            if (cbInterna.Checked)
            {
                tp = "'I'";
                virg = ",";
            }
            if (cbExterna.Checked)
                tp += virg + "'E'";
            bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Requisicao.Buscar(id_requisicao.Text,
                                                                                            cd_empresa.Text,
                                                                                            cd_produto.Text,
                                                                                            string.Empty,
                                                                                            cd_fornecedor.Text,
                                                                                            DT_Inic.Text,
                                                                                            DT_Final.Text,
                                                                                            Status,
                                                                                            st_oc.Checked,
                                                                                            st_pedido.Checked,
                                                                                            !St_visualizartodas,
                                                                                            tp,
                                                                                            false,
                                                                                            null);

            bsRequisicao_PositionChanged(this, new EventArgs());
        }

        private void InserirCotacao()
        {
            using (TFCotacao fCot = new TFCotacao())
            {
                if (fCot.ShowDialog() == DialogResult.OK)
                {
                    if (fCot.lRequisicao != null)
                        if (fCot.lRequisicao.Count > 0)
                            try
                            {
                                fCot.lRequisicao.ForEach(p =>
                                    {
                                        p.lCotacoes.ForEach(x =>
                                            {
                                                x.Id_requisicao = p.Id_requisicao;
                                                x.Qtd_atendida = p.Qtd_atendida;
                                                x.Vl_unitario_cotado = p.Vl_unitCotacao;
                                                x.Vl_ipi = p.Vl_ipi;
                                                x.Vl_icmssubst = p.Vl_icmssubst;
                                                x.Pc_icms = p.Pc_icms;
                                                CamadaNegocio.Compra.Lancamento.TCN_Cotacao.GravarCotacao(x, null);
                                            });
                                    });
                                MessageBox.Show("Cotação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
            }
        }

        public void ExcluirCotacao()
        {
            if (bsCotacao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.ToUpper().Equals("AC") ||
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.ToUpper().Equals("RN"))
                {
                    if (MessageBox.Show("Confirma exclusão da cotação selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Compra.Lancamento.TCN_Cotacao.DeletarCotacao(bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao, null);
                            MessageBox.Show("Cotação excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Só é permitido excluir cotações de requições com o\r\nSTATUS AGUARDANDO COTACAO ou RENEGOCIAR!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FecharCotacao()
        {
            using (TFFecharCotacao fFechar = new TFFecharCotacao())
            {
                fFechar.pStatus = "FE";
                fFechar.ShowDialog();
                afterBusca();
            }
        }

        private void AprovarRequisicao()
        {
            using (TFFecharCotacao fFechar = new TFFecharCotacao())
            {
                fFechar.pStatus = "AA";
                fFechar.ShowDialog();
                afterBusca();
            }
        }

        private void EstornarAprovacao()
        {
            if (bsRequisicao.Current != null)
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
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GerarOrdemCompra()
        {
            using (TFFecharCotacao fFechar = new TFFecharCotacao())
            {
                fFechar.pStatus = "AP";
                fFechar.ShowDialog();
                afterBusca();
            }
        }

        private void GerarPedido()
        {
            using (TFFecharCotacao fFechar = new TFFecharCotacao())
            {
                fFechar.pStatus = "OC";
                fFechar.ShowDialog();
                afterBusca();
            }
        }

        private void VisualizarFornec()
        {
            if (bsRequisicao.Current != null)
            {
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.ToUpper().Equals("AC") ||
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao.ToUpper().Equals("RN"))
                    using (TFVisualizarForn fForn = new TFVisualizarForn())
                    {
                        fForn.Cd_empresa = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa;
                        fForn.Cd_grupo = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_grupo;
                        fForn.Id_requisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.ToString();
                        fForn.ShowDialog();
                        afterBusca();
                    }
            }
        }

        private void afterPrint()
        {
            if (bsRequisicao.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Compra.Lancamento.TList_Requisicao { bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "CMP";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pMensagem = "REQUISIÇÃO DE COMPRA";

                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

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
                                           "REQUISIÇÃO DE COMPRA",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "REQUISIÇÃO DE COMPRA",
                                           fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatório selecionar requisição para imprimir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void AtualizaRequisicao(string Qtd_req)
        {
            if (lblNovaRequisicao.InvokeRequired)
            {
                Invoke((Action)(() => AtualizaRequisicao(Qtd_req)));
                return;
            }
            lblNovaRequisicao.Text = "NOVAS REQUISIÇÕES " + Environment.NewLine + Qtd_req;
            tlpDetRequisicao.ColumnStyles[0].Width = 213;
        }

        private void NovaThread()
        {
            if (lUser.Count > 0)
                while (true)
                {
                    System.Threading.Thread.Sleep(int.Parse(tempoNotificacao.Value.ToString()) * 1000);
                    //Buscar Total Requisicões
                    object obj = new CamadaDados.Compra.Lancamento.TCD_Requisicao().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_requisicao, 'AC')",
                                            vOperador = "<>",
                                            vVL_Busca = "'CA'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "cd_clifor_requisitante",
                                            vOperador = "<>",
                                            vVL_Busca = "'" + lUser[0].Cd_clifor_cmp.Trim() + "'"
                                        }
                                    }, "count(*)");
                    if (obj != null)
                    {
                        int cont = int.Parse(obj.ToString());
                        if (Tot_req < cont)
                        {
                            Tot_aguard = cont - Tot_req;
                            AtualizaRequisicao(Tot_aguard.ToString());
                        }
                    }
                }
        }

        private void TFLanRequisicao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRequisicao);
            Utils.ShapeGrid.RestoreShape(this, gItens);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pFiltros.BackColor = Utils.SettingsUtils.Default.COLOR_3;
            pFiltro.set_FormatZero();
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            St_visualizartodas = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR TODAS REQUISICOES", null);
            //Verificar se o Usuário tem permissão para aprovar compra
            lUser =
            new CamadaDados.Compra.TCD_CadUsuarioCompra().Select(
                           new Utils.TpBusca[]
                           {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                }
                           }, 1, string.Empty);
            if (lUser.Count > 0)
            {
                St_aprovar = lUser[0].St_aprovarbool;
                St_comprar = lUser[0].St_comprarbool;
            }
            if (!St_aprovar)
            {
                bb_aprovarCompra.Visible = false;
                tsdCotacao.Visible = false;
            }
            if (!St_comprar)
            {
                bb_gerarPedido.Visible = false;
                bb_gerarOrdem.Visible = false;
            }
            if (Properties.Settings.Default.tempo.Equals(0))
                tempoNotificacao.Value = 1;
            else
                tempoNotificacao.Value = Properties.Settings.Default.tempo;
            //Buscar Total Requisicões
            object obj = null;
            if (lUser.Count > 0)
            {

                obj = new CamadaDados.Compra.Lancamento.TCD_Requisicao().BuscarEscalar(
                                new Utils.TpBusca[]
                                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_requisicao, 'AC')",
                                        vOperador = "<>",
                                        vVL_Busca = "'CA'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "cd_clifor_requisitante",
                                        vOperador = "<>",
                                        vVL_Busca = "'" + lUser[0].Cd_clifor_cmp.Trim() + "'"
                                    }
                                    }, "count(*)");
            }
            Tot_req = obj == null ? 0 : int.Parse(obj.ToString());
            tlpDetRequisicao.ColumnStyles[0].Width = 0;
            thNovaReq = new System.Threading.Thread(NovaThread);
            thNovaReq.Start();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vCond = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vCond, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gRequisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO APROVACAO"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Chocolate;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ORDEM COMPRA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.OrangeRed;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RENEGOCIAR"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Olive;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PEDIDO GERADO"))
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        DataGridViewRow linha = gRequisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLanRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                AprovarRequisicao();
            else if (e.KeyCode.Equals(Keys.F10))
                GerarOrdemCompra();
            else if (e.KeyCode.Equals(Keys.F11))
                GerarPedido();
            else if (e.KeyCode.Equals(Keys.F12))
                bbEstoque_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirCotacao();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirCotacao();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao != null)
                {
                    //Buscar lista de negociacao
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg =
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao_X_Negociacao.Buscar(
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                        string.Empty,
                        0, string.Empty, null);

                    //Buscar cotacoes da requisicao
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes =
                        CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                           string.Empty,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                                                           (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                                                           0,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
                    bsRequisicao.ResetCurrentItem();
                }
        }

        private void TFLanRequisicao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRequisicao);
            Utils.ShapeGrid.SaveShape(this, gItens);
            Properties.Settings.Default.tempo = tempoNotificacao.Value;
            Properties.Settings.Default.Save();
            try
            {
                thNovaReq.Suspend();
                thNovaReq = null;
            }
            catch { }
        }

        private void bbInserirCotacao_Click(object sender, EventArgs e)
        {
            InserirCotacao();
        }

        private void bbExcluirCotacao_Click(object sender, EventArgs e)
        {
            ExcluirCotacao();
        }

        private void miInserirCotacao_Click(object sender, EventArgs e)
        {
            InserirCotacao();
        }

        private void miFecharCotacao_Click(object sender, EventArgs e)
        {
            FecharCotacao();
        }

        private void bb_aprovarCompra_Click(object sender, EventArgs e)
        {
            AprovarRequisicao();
        }

        private void bb_gerarOrdem_Click(object sender, EventArgs e)
        {
            GerarOrdemCompra();
        }

        private void bb_gerarPedido_Click(object sender, EventArgs e)
        {
            GerarPedido();
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_X_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                           "isnull(a.st_fornecedor, 'N')|=|'S';" +
                           "|exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                           "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, vParam);
        }

        private void bb_visualizarForn_Click(object sender, EventArgs e)
        {
            VisualizarFornec();
        }

        private void gRequisicao_DoubleClick(object sender, EventArgs e)
        {
            VisualizarFornec();
        }

        private void bbEstoque_Click(object sender, EventArgs e)
        {
            using (FConsultaEstoque estoque = new FConsultaEstoque())
            {
                estoque.ShowDialog();
            }
        }

        private void lblNovaRequisicao_Click(object sender, EventArgs e)
        {
            id_requisicao.Clear();
            cd_empresa.Clear();
            cd_produto.Clear();
            cd_fornecedor.Clear();
            cbInterna.Checked = false;
            cbExterna.Checked = false;
            DT_Inic.Clear();
            DT_Final.Clear();
            st_ac.Checked = true;
            st_aa.Checked = false;
            st_cancelada.Checked = false;
            st_ap.Checked = false;
            st_rp.Checked = false;
            st_oc.Checked = false;
            st_rn.Checked = false;
            st_pedido.Checked = false;
            afterBusca();
            tlpDetRequisicao.ColumnStyles[0].Width = 0;
            Tot_req += Tot_aguard;
            Tot_aguard = 0;
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

        private void ImpRequisicao_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void ImpRequisicaoForn_Click(object sender, EventArgs e)
        {
            using (TFRequisicaoFornec fReq = new TFRequisicaoFornec())
            {
                fReq.ShowDialog();
            }
        }
    }
}
