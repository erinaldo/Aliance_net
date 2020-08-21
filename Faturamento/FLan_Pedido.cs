using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using Componentes;
using FormBusca;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using FormRelPadrao;
using Financeiro;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using Proc_Commoditties;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Orcamento;

namespace Faturamento
{
    public partial class TFLan_Pedido : Form
    {
        private bool Altera_Relatorio = false;
        private Form fEditar
        { get; set; }

        public TFLan_Pedido()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            NR_Pedido_Busca.Clear();
            CD_Empresa_Busca.Clear();
            nr_pedidoorigem_busca.Clear();
            CD_Clifor_Busca.Clear();
            cd_endereco_busca.Clear();
            cd_condpgto_busca.Clear();
            CFG_Pedido_Busca.Clear();
            cd_tabelapreco_busca.Clear();
            cd_moeda_busca.Clear();
            cd_vendedor_busca.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            VL_Inicial.Value = VL_Inicial.Minimum;
            VL_Final.Value = VL_Final.Minimum;
            cck_Cancelado.Checked = false;
            cck_Encerrado.Checked = false;
            cck_Fechado.Checked = false;
            cck_expirado.Checked = false;
            cck_Parcial.Checked = false;
            cck_Aberto.Checked = false;
            cbEntrada.Checked = false;
            cbSaida.Checked = false;
        }

        private void encerrarPedido()
        {
            try
            {
                (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "P";
                (BS_Pedido.Current as TRegistro_Pedido).ST_Registro = "P";
                TRegistro_Pedido rPed = BS_Pedido.Current as TRegistro_Pedido;
                TCN_Pedido.Grava_Pedido(BS_Pedido.Current as TRegistro_Pedido, null);
                LimparFiltros();
                NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                cck_Encerrado.Checked = true;
                Busca();
                MessageBox.Show("Pedido ENCERRADO com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao Encerrao o Pedido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void faturarPedido(string Tp_nf)
        {
            if (BS_Pedido.Current != null)
            {
                //Verificar se é pedido de troca
                object obj_troca = new TCD_TrocaCliente().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca{ vNM_Campo = "a.nr_pedidoorigem", vOperador = "=", vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() }
                                    }, "a.nr_pedidotroca");
                if (obj_troca != null)
                {
                    MessageBox.Show("Não é permitido faturar pedido de origem de uma troca de CNPJ na PROPOSTA.\r\n" +
                                    "Pedido a ser faturado " + obj_troca.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("P"))
                {
                    (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "F";
                    (BS_Pedido.Current as TRegistro_Pedido).St_registro = "F";
                    TRegistro_Pedido rPed = (BS_Pedido.Current as TRegistro_Pedido);
                    TCN_Pedido.Grava_Pedido(rPed, null);
                    LimparFiltros();
                    NR_Pedido_Busca.Text = rPed.Nr_pedido.ToString();
                    Busca();
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    //Verificar se o tipo de pedido exige conferencia
                    object obj = new TCD_CadCFGPedido().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cfg_pedido",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_exigirconferenciaentrega, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1");
                    if (obj != null)
                        if (obj.ToString().Trim().Equals("1"))
                        {
                            obj = new TCD_LanPedido_Item().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo= "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(b.st_servico, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "((not exists (select 1 from tb_fat_entregapedido x "+
                                                    "               where x.nr_pedido = a.nr_pedido "+
                                                    "               and x.cd_produto = a.cd_produto "+
                                                    "               and x.id_pedidoitem = a.id_pedidoitem)) or ( "+
                                                    "       exists(select 1 from tb_fat_entregapedido x "+
                                                    "               where x.nr_pedido = a.nr_pedido "+
                                                    "               and x.cd_produto = a.cd_produto "+
                                                    "               and x.id_pedidoitem = a.id_pedidoitem "+
                                                    "               and isnull(x.st_registro, 'A') = 'A')))"
                                    }
                                }, "1");
                            if (obj != null)
                                if (obj.ToString().Trim().Equals("1"))
                                {
                                    if (!(MessageBox.Show("Pedido possui conferência com status <ABERTA> ou itens sem registro de conferência.\r\n" +
                                                    "Estes itens não serão faturados.\r\n" +
                                                    "Confirma faturamento mesmo assim?",
                                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes))
                                        return;
                                }
                        }
                    //Verificar se o pedido tem configuracao fiscal para emitir nota
                    obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "in",
                                    vVL_Busca = "(" + Tp_nf + ")"
                                }
                            }, "1");
                    if (obj == null ? true : obj.ToString().Trim() != "1")
                    {
                        MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se o pedido tem valor fixo e se nao aceita faturar parcial
                    if (TCN_Pedido.FaturarPedidoDireto((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        try
                        {
                            TRegistro_LanFaturamento rFat = TProcessaPedFaturar.ProcessaPedFaturar(BS_Pedido.Current as TRegistro_Pedido, false, decimal.Zero);
                            TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            //Se for nota propria e NF-e
                            if (rFat.Tp_nota.Trim().ToUpper().Equals("P"))
                                if (rFat.Cd_modelo.Trim().Equals("55"))
                                {
                                    if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        //Verificar se é nota de produto ou mista
                                        obj = new TCD_CadSerieNF().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.nr_serie",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rFat.Nr_serie.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_modelo",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rFat.Cd_modelo.Trim() + "'"
                                                            }
                                                        }, "a.tp_serie");
                                        if (obj != null)
                                            if (obj.ToString().Trim().ToUpper().Equals("P") ||
                                                obj.ToString().Trim().ToUpper().Equals("M"))
                                            {
                                                try
                                                {
                                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                    {
                                                        fGerNfe.rNfe = TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                   rFat.Nr_lanctofiscalstr,
                                                                                                   null);
                                                        fGerNfe.ShowDialog();
                                                    }
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                            else if (obj.ToString().Trim().ToUpper().Equals("S"))
                                            {
                                                try
                                                {
                                                    TRegistro_LanFaturamento rNfs = TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                rFat.Nr_lanctofiscalstr,
                                                                                                                null);
                                                    NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<TRegistro_LanFaturamento>() { rNfs });
                                                    MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                    }
                                }
                                else
                                {
                                    //Chamar tela de impressao para a nota fiscal
                                    //somente se for nota propria
                                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                        fImp.pMensagem = "NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        {
                                            //Buscar Dt.Processamento
                                            obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rFat.Nr_lanctofiscalstr
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.status",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'100'"
                                                                }
                                                            }, "a.dt_processamento");
                                            if (obj != null)
                                                rFat.Dt_processamento = DateTime.Parse(obj.ToString());
                                            //Buscar Nr.Protocolo
                                            object nr_proc = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rFat.Nr_lanctofiscalstr
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.status",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'100'"
                                                                }
                                                            }, "a.Nr_protocolo");
                                            if (nr_proc != null)
                                                rFat.Nr_protocolo = nr_proc.ToString();
                                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                           rFat.Nr_lanctofiscalstr,
                                                                                           null),
                                                                fImp.pSt_imprimir,
                                                                fImp.pSt_visualizar,
                                                                fImp.pSt_enviaremail,
                                                                fImp.pDestinatarios,
                                                                "NOTA FISCAL Nº " + rFat.Nr_notafiscal.ToString(),
                                                                fImp.pDs_mensagem);
                                        }
                                    }
                                }
                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                                    "where x.cd_empresa = c.cd_empresa "+
                                                    "and x.nr_lanctoduplicata = c.nr_lancto "+
                                                    "and x.cd_empresa = '" + rFat.Cd_empresa.Trim() + "' "+
                                                    "and x.nr_lanctofiscal = " + rFat.Nr_lanctofiscal.ToString() + ")"
                                    }
                                }, 0, string.Empty);
                            if (lBloqueto.Count > 0)
                                //Chamar tela de impressao para o bloqueto
                                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = rFat.Cd_clifor;
                                    fImp.pMensagem = "BLOQUETOS DA NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                            lBloqueto,
                                                                            fImp.pSt_imprimir,
                                                                            fImp.pSt_visualizar,
                                                                            fImp.pSt_enviaremail,
                                                                            fImp.pSt_exportPdf,
                                                                            fImp.Path_exportPdf,
                                                                            fImp.pDestinatarios,
                                                                            "BLOQUETO(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
                                                                            fImp.pDs_mensagem,
                                                                            false);
                                }
                            //Imprimir Duplicata
                            if (rFat.Duplicata.Count > 0)
                                if (rFat.Duplicata[0].Tp_mov.Trim().ToUpper().Equals("R"))
                                {
                                    obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_docto",
                                                    vOperador = "=",
                                                    vVL_Busca = rFat.Duplicata[0].Tp_doctostring
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, "1");
                                    if (obj != null)
                                    {
                                        //Chamar tela de impressao duplicata
                                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                        {
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pCd_clifor = rFat.Cd_clifor;
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                                 rFat.Cd_empresa,
                                                                                 null).Trim().ToUpper().Equals("S"))
                                            {
                                                //Buscar dados Empresa
                                                TList_CadEmpresa lEmpresa = TCN_CadEmpresa.Busca(rFat.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                                //Buscar dados do sacado
                                                TList_CadClifor lSacado =
                                                    TCN_CadClifor.Busca_Clifor(rFat.Cd_clifor,
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
                                                                               0,
                                                                               null);
                                                //Buscar endereco sacado
                                                if (lSacado.Count > 0)
                                                    lSacado[0].lEndereco =
                                                        TCN_CadEndereco.Buscar(rFat.Cd_clifor,
                                                                               rFat.Cd_endereco,
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

                                                Relatorio Rel = new Relatorio();
                                                //Duplicata
                                                BindingSource bs = new BindingSource();
                                                bs.DataSource = rFat.Duplicata;
                                                Rel.DTS_Relatorio = bs;
                                                //Verificar se existe logo configurada para a empresa
                                                if (lEmpresa.Count > 0)
                                                    if (lEmpresa[0].Img != null)
                                                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                                //Empresa
                                                BindingSource bs_emp = new BindingSource();
                                                bs_emp.DataSource = lEmpresa;
                                                Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                                //Parcelas
                                                BindingSource bs_parc = new BindingSource();
                                                //Buscar Parcelas
                                                TList_RegLanParcela lParc =
                                                    new TCD_LanParcela().Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.nr_lancto",
                                                                vOperador = "=",
                                                                vVL_Busca = rFat.Duplicata[0].Nr_lancto.ToString()
                                                            }
                                                        }, 0, string.Empty, string.Empty, string.Empty);
                                                bs_parc.DataSource = lParc;
                                                Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                                //Sacado
                                                BindingSource bs_sacado = new BindingSource();
                                                bs_sacado.DataSource = lSacado;
                                                Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                                Rel.Nome_Relatorio = "FRel_CarneDup";
                                                Rel.NM_Classe = "TFDuplicata";
                                                Rel.Modulo = "FIN";
                                                Rel.Ident = "FRel_CarneDup";
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString();

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
                                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
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
                                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
                                                                       fImp.pDs_mensagem);
                                            }
                                            else
                                            {
                                                fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + rFat.Nr_notafiscal.ToString();
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                          rFat.Duplicata[0].Parcelas,
                                                                                          null,
                                                                                          null,
                                                                                          fImp.pSt_imprimir,
                                                                                          fImp.pSt_visualizar,
                                                                                          fImp.pSt_exportPdf,
                                                                                          fImp.Path_exportPdf,
                                                                                          fImp.pSt_enviaremail,
                                                                                          fImp.pDestinatarios,
                                                                                          "DUPLICATAS(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
                                                                                          fImp.pDs_mensagem);
                                            }
                                        }
                                    }
                                }
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_MANIFESTO_AUTO", rFat.Cd_empresa, null) == "S")
                            {
                                if (rFat.Tp_nota.Trim().ToUpper().Equals("T") && rFat.Cd_modelo.Trim().Equals("55"))
                                {
                                    //Buscar evento de Manifesto
                                    TList_Evento lEvento = TCN_Evento.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             "MF",
                                                                             null);
                                    TRegistro_Evento rEvento = null;
                                    if (lEvento.Count.Equals(1))
                                        rEvento = lEvento[0];
                                    else if (lEvento.Count > 1)
                                    {
                                        string vColunas = "a.ds_evento|Evento|200;" +
                                                            "a.cd_evento|Codigo|80";
                                        DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new TCD_Evento(), "a.tp_evento|=|'MF'");
                                        if (linha != null)
                                            rEvento = lEvento.Find(p => p.Cd_eventostr.Equals(linha["cd_evento"].ToString()));
                                    }
                                    if (rEvento != null)
                                    {
                                        CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rMan = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                        rMan.Cd_empresa = rFat.Cd_empresa;
                                        rMan.Nr_lanctofiscal = rFat.Nr_lanctofiscal;
                                        rMan.Chave_acesso_nfe = rFat.Chave_acesso_nfe;
                                        rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                        rMan.Cd_eventostr = rEvento.Cd_eventostr;
                                        rMan.Descricao_evento = rEvento.Ds_evento;
                                        rMan.Tp_evento = rEvento.Tp_evento;
                                        rMan.St_registro = "A";
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rMan, null);
                                        if (MessageBox.Show("Manifesto gravado com sucesso.\r\n" +
                                                                "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                                        {
                                            //Buscar CfgNfe para a empresa
                                            TList_CfgNfe lCfg = TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                                            if (lCfg.Count.Equals(0))
                                                MessageBox.Show("Não existe configuração para envio do Manifesto para a empresa " + rFat.Cd_empresa.Trim() + ".",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                            {
                                                try
                                                {
                                                    string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, lCfg[0]);
                                                    if (!string.IsNullOrEmpty(msg))
                                                        MessageBox.Show("Erro ao enviar Manifesto para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                                        "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    else
                                                        MessageBox.Show("Manifesto enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                        }
                                    }
                                }
                            }
                            //Verificar se o pedido ainda tem saldo, se nao, encerrar o pedido
                            TList_Pedido lPedido = new TCD_Pedido().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                                    }
                                }, 1, string.Empty);
                            if (lPedido.Count > 0)
                                if ((lPedido[0].Vl_saldopedido <= 0) && (!lPedido[0].St_Commodittiesbool))
                                    if (MessageBox.Show("Total do pedido faturado.\r\nDeseja encerrar o pedido?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        == DialogResult.Yes)
                                        encerrarPedido();
                            LimparFiltros();
                            NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            Busca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        using (TFLanFaturamento fFaturamento = new TFLanFaturamento())
                        {
                            if (Tp_nf.ToUpper().Equals("'NO'") ||
                            Tp_nf.ToUpper().Equals("'CP', 'CF'") ||
                            Tp_nf.ToUpper().Equals("'FT'"))
                                fFaturamento.vTp_movimento = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                            else if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("E"))
                                fFaturamento.vTp_movimento = "S";
                            else
                                fFaturamento.vTp_movimento = "E";
                            fFaturamento.Nr_pedidoFaturar = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            fFaturamento.vTp_NFFiscal = Tp_nf;
                            fFaturamento.ShowDialog();
                            if (Tp_nf.Trim().ToUpper().Equals("'NO'"))
                            {
                                //Verificar se o pedido ainda tem saldo, se nao, encerrar o pedido
                                TList_Pedido lPedido = new TCD_Pedido().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                                        }
                                    }, 1, string.Empty);
                                if (lPedido.Count > 0)
                                    if ((lPedido[0].Vl_saldopedido <= 0) && (!lPedido[0].St_Commodittiesbool))
                                        if (MessageBox.Show("Total do pedido faturado.\r\nDeseja encerrar o pedido?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            == DialogResult.Yes)
                                            encerrarPedido();
                            }
                            LimparFiltros();
                            NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            Busca();
                        }
                    }
                }
            }
        }

        private void GerarConferenciaPedido(TRegistro_Pedido val)
        {
            if (val != null)
                if (val.ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    if (val.St_Commodittiesbool)
                    {
                        MessageBox.Show("Conferencia pedido commoditties sera gerado automaticamente pela balança.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se o cfg_pedido exige conferencia
                    TList_CadCFGPedido lCfgPed =
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedido.Buscar(val.CFG_Pedido,
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
                                                                                    decimal.Zero,
                                                                                    1,
                                                                                    string.Empty,
                                                                                    null);
                    if (lCfgPed.Count > 0)
                        if (lCfgPed[0].St_ExigirConferenciaEntregaBool)
                        {
                            if (val.TP_Movimento.Trim().ToUpper().Equals("E"))
                            {
                                //Chamar tela de itens para conferencia
                                using (TFGerarConferencia fConf = new TFGerarConferencia())
                                {
                                    fConf.Nr_pedido = val.Nr_pedido.ToString();
                                    if (fConf.ShowDialog() == DialogResult.OK)
                                        if (fConf.lItensPed != null)
                                        {
                                            try
                                            {
                                                TCN_Pedido.GerarConferenciaPedido(fConf.lItensPed, null);
                                                MessageBox.Show("Conferência gerada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            {
                                                throw new Exception("Erro gerar conferência: " + ex.Message.Trim());
                                            }
                                        }
                                }
                            }
                            else
                            {
                                //Se o pedido for de saida gerar conferencia de todos os itens disponiveis
                                TList_RegLanPedido_Item lItensConf = TCN_LanPedido_Item.BuscarItemConferencia(val.Nr_pedido.ToString(), null);
                                lItensConf.ForEach(p => p.St_gerarConferencia = true);
                                try
                                {
                                    TCN_Pedido.GerarConferenciaPedido(lItensConf, null);
                                    MessageBox.Show("Conferência gerada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Erro gerar conferência: " + ex.Message.Trim());
                                }
                            }
                        }
                }
        }

        private void TFLan_Pedido_Load(object sender, EventArgs e)
        {
            tsAnexo.Visible = true;
            ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            ShapeGrid.RestoreShape(this, g_Fiscais);
            ShapeGrid.RestoreShape(this, g_Itens);
            ShapeGrid.RestoreShape(this, g_Parcelas);
            ShapeGrid.RestoreShape(this, gEntrega);
            ShapeGrid.RestoreShape(this, gOrdemServico);
            ShapeGrid.RestoreShape(this, gParcelas);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, gDup);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pnl_Consulta_Pedido.set_FormatZero();
            PedidoExpirado();

            tcItens.TabPages.Remove(tpEtapas);
            if (TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR ETAPAS", null))
                tcItens.TabPages.Add(tpEtapas);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca();
        }

        private void Busca()
        {
            BS_Pedido.DataSource = TCN_Pedido.Busca(CD_Empresa_Busca.Text,
                                                     cbEntrada.Checked && cbSaida.Checked ? string.Empty : cbEntrada.Checked ? "E" : cbSaida.Checked ? "S" : string.Empty,
                                                     NR_Pedido_Busca.Text,
                                                     CD_Clifor_Busca.Text,
                                                     Cd_produto.Text,
                                                     cd_endereco_busca.Text,
                                                     string.Empty,
                                                     nr_pedidoorigem_busca.Text,
                                                     string.Empty,
                                                     CFG_Pedido_Busca.Text,
                                                     cck_Cancelado.Checked,
                                                     cck_Fechado.Checked,
                                                     cck_Encerrado.Checked,
                                                     cck_Aberto.Checked,
                                                     cck_expirado.Checked,
                                                     cck_Parcial.Checked,
                                                     false,
                                                     st_comconferencia.Checked,
                                                     DT_Inicial.Text,
                                                     DT_Final.Text,
                                                     string.Empty,
                                                     cd_condpgto_busca.Text,
                                                     cd_tabelapreco_busca.Text,
                                                     cd_vendedor_busca.Text,
                                                     cd_moeda_busca.Text,
                                                     cd_representante.Text,
                                                     cd_grupo.Text,
                                                     VL_Inicial.Value,
                                                     VL_Final.Value,
                                                     nr_orcamento.Text,
                                                     string.Empty,
                                                     stOrigemProposta.Checked,
                                                     0,
                                                     string.Empty,
                                                     null,
                                                     edtCategoria.Text);
            BS_Pedido_PositionChanged(this, new EventArgs());
            BS_Itens_PositionChanged(this, new EventArgs());
            lblTotalVlPedido.Text = (BS_Pedido.DataSource as TList_Pedido).Sum(p => p.Vl_totalpedido).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            vlSaldoFaturar.Text = (BS_Pedido.DataSource as TList_Pedido).Sum(p => p.Vl_saldopedido).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            totPedidoLiq.Text = (BS_Pedido.DataSource as TList_Pedido).Sum(p => p.Vl_totalpedido_liquido).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            using (TFPedido fPedido = new TFPedido())
            {
                fPedido.Text = "NOVO PEDIDO";
                if (fPedido.ShowDialog() == DialogResult.OK)
                    if (fPedido.rPedido != null)
                        try
                        {
                            TRegistro_Pedido rPed = fPedido.rPedido;
                            TCN_Pedido.Grava_Pedido(rPed,
                                                    null);
                            try
                            {
                                GerarConferenciaPedido(rPed);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LimparFiltros();
                            NR_Pedido_Busca.Text = rPed.Nr_pedido.ToString();
                            Busca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void Altera()
        {
            if (BS_Pedido.Current != null)
            {
                bool st_editar = true;
                if ((BS_Pedido.Current as TRegistro_Pedido).St_Commodittiesbool)
                    st_editar = false;
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar pedido CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido == "F" ||
                    (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido == "P") &&
                    !TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR PEDIDO FATURADO", null) &&
                    TCN_Pedido.Verifica_Disponibilidade_Pedido((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                    st_editar = false;
                if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S") &&
                    ((BS_Pedido.Current as TRegistro_Pedido).Cd_vendedor.Trim() != string.Empty) &&
                    (Utils.Parametros.pubLogin.Trim().ToUpper() != "MASTER") &&
                    (Utils.Parametros.pubLogin.Trim().ToUpper() != "DESENV"))
                {
                    if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR PEDIDO OUTROS VENDEDORES", null))
                    {
                        //Verificar se o login atual e igual ao login do cadastro de vendedor
                        object obj = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginvendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim().ToUpper() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Cd_vendedor
                                }
                        }, "1");
                        if (obj == null)
                            st_editar = false;
                    }
                }
                using (TFPedido fPedido = new TFPedido())
                {
                    TCN_Pedido.Busca_Pedido_Itens(BS_Pedido.Current as TRegistro_Pedido, true, null);
                    fPedido.rPedido = BS_Pedido.Current as TRegistro_Pedido;
                    fPedido.Text = "ALTERAR PEDIDO Nº " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                    fPedido.St_editar = st_editar;
                    if (fPedido.ShowDialog() == DialogResult.OK)
                        if (fPedido.rPedido != null)
                        {
                            TRegistro_Pedido rPed = fPedido.rPedido;
                            TCN_Pedido.Grava_Pedido(rPed, null);
                            try
                            {
                                GerarConferenciaPedido(rPed);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    LimparFiltros();
                    NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                    Busca();
                }
            }
            else
                MessageBox.Show("Necessario selecionar pedido para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Print()
        {
            if (BS_Pedido.Current != null)
            {
                if (!(BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("CANCELADO"))
                {
                    TRegistro_Pedido pedido = (BS_Pedido.Current as TRegistro_Pedido);
                    TCN_Pedido.Busca_CFG_Fiscal(pedido);
                    TCN_Pedido.Busca_Pedido_Itens(pedido, false, null);
                    pedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(pedido.Nr_pedido, null);
                    if (pedido.Pedido_Itens.Count > 0)
                        pedido.Pedidos_DT_Vencto.ForEach(p => p.Vl_juro_fin = Math.Round((p.VL_Parcela * pedido.Pedido_Itens[0].Pc_juro_fin) / 100, 2));
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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

                    BindingSource BinVendedor = new BindingSource();
                    BinVendedor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).Cd_vendedor,
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


                    BindingSource bintransportadora = new BindingSource();
                    bintransportadora.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).CD_TRANSPORTADORA,
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
                    (bintransportadora.Current as TRegistro_CadClifor).lContato
                       = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                   (bintransportadora.Current as TRegistro_CadClifor).Cd_clifor,
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

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                                                    (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
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
                    BinEndEntrega.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa + "'"
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
                    if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count > 0)
                    {
                        TList_RegLanParcela lParc =
                            new TCD_LanParcela().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lancto",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).lDup[0].Nr_lancto.ToString()
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty);
                        //Criar fonte de dados para parcelas pedido                
                        lParc.ForEach(p =>
                        {
                            //Criar fonte de dados
                            DataTable tb_dup = new DataTable();
                            tb_dup.Columns.Add("Nr_Pedido", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("VL_Parcela", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("Dt_vencto", Type.GetType("System.DateTime"));
                            DataRow linha = tb_dup.NewRow();
                            linha["Nr_Pedido"] = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                            linha["VL_Parcela"] = p.Vl_parcela;
                            linha["Dt_vencto"] = p.Dt_vencto;
                            BinParcelas.Add(linha);
                        });
                    }
                    else
                    {

                        BinParcelas.DataSource = TCN_LanPedido_DT_Vencto.Busca((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido,
                                                                                                                 null);
                    }

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                               (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    {
                        CamadaDados.Compra.Lancamento.TList_Cotacao lCot =
                            new CamadaDados.Compra.Lancamento.TCD_Cotacao().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
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
                                    new TpBusca()
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

                    //Buscar ficha tecnica
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    {
                        if (p.lFichaTec.Count.Equals(0))
                            p.lFichaTec = TCN_FichaTecItemPed.Buscar(p.Nr_PedidoString,
                                               p.Cd_produto,
                                               p.Id_pedidoitem.ToString(),
                                               string.Empty,
                                               null);
                    });


                    object obj = new TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");
                    if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        try
                        {
                            TCN_Pedido.ImprimirPedido(pedido,
                                                      BinClifor.Current as TRegistro_CadClifor,
                                                      BinEndereco.Current as TRegistro_CadEndereco,
                                                      BinEmpresa.Current as TRegistro_CadEmpresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        Relatorio Relatorio = new Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = Name;
                        Relatorio.NM_Classe = Name;
                        Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                        TList_Pedido lista_pedido = new TList_Pedido();
                        lista_pedido.Add(pedido);
                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = lista_pedido;
                        BS_Pedido.ResetCurrentItem();
                        Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.Adiciona_DataSource("transportadora", bintransportadora);
                        Relatorio.Adiciona_DataSource("VENDEDOR", BinVendedor);
                        Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                        Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                        Relatorio.Adiciona_DataSource("ITENS", BS_Itens);
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
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                                fImp.pCd_representante = (BS_Pedido.Current as TRegistro_Pedido).Cd_representante;
                                fImp.pMensagem = ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                            (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                                            (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
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

        private void Duplica()
        {
            if (BS_Pedido.Current != null)
            {
                //Buscar pedido
                TRegistro_Pedido rPed = TCN_Pedido.Busca_Registro_Pedido((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(), null);
                //Buscar Itens Pedido
                TCN_Pedido.Busca_Pedido_Itens(rPed, true, null);
                rPed.Pedido_Itens.ForEach(x =>
                {
                    x.Nr_orcamento = null;
                    x.Id_itemorc = null;
                });
                //Buscar Parcelas Pedido
                rPed.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido, null);
                //Buscar Etapas
                rPed.lEtapa = TCN_EtapaPedido.Busca(string.Empty,
                                                    (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                    null);
                rPed.lEtapa.ForEach(x =>
                {
                    x.lProcEtapa = TCN_ProcEtapa.Busca(x.Id_etapastr,
                                                       x.Nr_pedidostr,
                                                       string.Empty,
                                                       null);
                    x.lProcEtapa.ForEach(y => y.lAnexo = TCN_AnexoPedido.Buscar(y.Nr_pedidostr,
                                                                                y.Id_etapastr,
                                                                                y.Id_processostr,
                                                                                y.Id_Anexo,
                                                                                null));
                });
                rPed.Nr_pedido = decimal.Zero;
                rPed.ST_Pedido = "F";
                rPed.St_registro = "F";

                bool st_editar = true;

                using (TFPedido fPedido = new TFPedido())
                {
                    fPedido.rPedido = rPed;
                    fPedido.Text = "DUPLICAR PEDIDO";
                    fPedido.St_editar = st_editar;
                    if (fPedido.ShowDialog() == DialogResult.OK)
                        if (fPedido.rPedido != null)
                            try
                            {
                                TCN_Pedido.Grava_Pedido(fPedido.rPedido, null);
                                GerarConferenciaPedido(rPed);
                                LimparFiltros();
                                NR_Pedido_Busca.Text = fPedido.rPedido.Nr_pedido.ToString();
                                Busca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
            }
            else
                MessageBox.Show("Necessário selecionar pedido para duplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool PermissaoCancelar(string log)
        {
            //verifica se usuario tem permissão para cancelar
            if (new TCD_Usuario_RegraEspecial().BuscarEscalar(
                new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.Login",
                            vOperador = "=",
                            vVL_Busca = "'"+log+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ds_regra",
                            vOperador = "=",
                            vVL_Busca = "'PERMITIR CANCELAR PEDIDO'"
                        }
                    }, "1") != null)
                return true;
            else
                return false;
        }
        private void Exclui()
        {
            if (BS_Pedido.Current != null)
            {
                //motivo do cancelamento
                InputBox iB = new InputBox();
                iB.Text = "Motivo do cancelamento";
                (BS_Pedido.Current as TRegistro_Pedido).dsCancelmento = iB.ShowDialog();
                if (string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).dsCancelmento))
                {
                    MessageBox.Show("Obrigatório informar descrição", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //verifica se usuario pode cancelar pedido, se nao:  chama tela de login 
                if (!PermissaoCancelar(Utils.Parametros.pubLogin))
                {
                    using (TFLanSessaoPDV fLog = new TFLanSessaoPDV())
                    {
                        do
                        {
                            fLog.ShowDialog();
                            if (fLog.DialogResult == DialogResult.Cancel)
                                return;
                            (BS_Pedido.Current as TRegistro_Pedido).LoginCancelamento = fLog.Usuario;
                            if (!PermissaoCancelar((BS_Pedido.Current as TRegistro_Pedido).LoginCancelamento))
                                MessageBox.Show("Usuário não pode cancelar pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } while (!PermissaoCancelar((BS_Pedido.Current as TRegistro_Pedido).LoginCancelamento));
                    }
                }
                if ((BS_Pedido != null) && (BS_Pedido.Count > 0))
                {
                    if ((BS_Pedido.Current as TRegistro_Pedido).St_Commodittiesbool)
                    {
                        MessageBox.Show("Não é permitido CANCELAR pedido commoditties pela tela de faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                    {
                        if (TCN_Pedido.Verifica_Disponibilidade_Pedido((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                        {
                            MessageBox.Show("Não é permitido CANCELAR um pedido FECHADO que tenha FATURAMENTO", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (TCN_Pedido.Verifica_Pedido_Contrato((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                        {
                            MessageBox.Show("Não é permitido CANCELAR pedido FECHADO que tenha CONTRATO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("P"))
                    {
                        MessageBox.Show("Não é permitido CANCELAR um pedido ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("O Pedido já se encontra CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se pedido possui duplicata ativa
                    if (new TCD_LanDuplicata().BuscarEscalar(
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
                            vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")"
                        }
                        }, "1") != null)
                    {
                        MessageBox.Show("Pedido possui duplicata em aberto.\r\n" +
                                        "Entre em contato com o responsável pelo financeiro para realizar o cancelamento da duplicata.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se o pedido integra ordem de servico com status <DEVOLVIDA>
                    object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedidointegra",
                            vOperador = "=",
                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_os, 'AB')",
                            vOperador = "=",
                            vVL_Busca = "'DV'"
                        }
                        }, "1");
                    string msg = string.Empty;
                    if (obj != null)
                        if (obj.ToString().Trim().Equals("1"))
                            msg = "Pedido integra ordem serviço com status <DEVOLVIDA>.\r\n" +
                                  "Ao cancelar o pedido as ordens de serviços voltarão para o status <PROCESSADA>.\r\n";
                    //Verificar se o pedido integra taxas armazenagem
                    obj = new CamadaDados.Graos.TCD_Taxa_X_PedidoItem().BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_GRO_Taxa_X_PedidoItem x "+
                                        "where x.nr_pedido = a.nr_pedido)"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        }
                        }, "1");
                    if (obj != null)
                        if (obj.ToString().Trim().Equals("1"))
                            msg += "Pedido integra taxas de armazenagem de produtos em deposito.\r\n" +
                                   "Ao cancelar o pedido as taxas voltarão para o status <ABERTA>.\r\n";
                    //Verificar se o pedido integra orcamento
                    if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p => p.Nr_orcamento != null))
                        msg += "Pedido integra orçamento. Ao cancelar o pedido o orçamento voltara para o status <ABERTO>\r\n";
                    if (MessageBox.Show(msg.Trim() + "Deseja Realmente CANCELAR o PEDIDO", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_Pedido.Deleta_Pedido(BS_Pedido.Current as TRegistro_Pedido, null);
                            MessageBox.Show("O Pedido foi CANCELADO com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            cck_Cancelado.Checked = true;
                            Busca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else MessageBox.Show("Obrigatório selecionar pedido para CANCELAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SimularImpostos()
        {
            if (BS_Pedido.Current != null)
                using (TFSimuladorImpostos fSimular = new TFSimuladorImpostos())
                {
                    fSimular.pCd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                    fSimular.pNm_empresa = (BS_Pedido.Current as TRegistro_Pedido).Nm_Empresa;
                    fSimular.pCfg_pedido = (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido;
                    fSimular.pDs_tipopedido = (BS_Pedido.Current as TRegistro_Pedido).DS_CFG_Pedido;
                    fSimular.pTp_mov = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                    fSimular.pCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                    fSimular.pNm_clifor = (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor;
                    fSimular.pCd_endereco = (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco;
                    fSimular.pDs_endereco = (BS_Pedido.Current as TRegistro_Pedido).DS_Endereco;
                    fSimular.pCd_municipioexecservico = (BS_Pedido.Current as TRegistro_Pedido).Cd_municipioexecservico;
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
                    fSimular.ShowDialog();
                }
        }

        private void VerificarEstoque()
        {
            if (BS_Itens.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("S"))
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto))
                        using (TFDisponibilidadeEstoque fDisp = new TFDisponibilidadeEstoque())
                        {
                            fDisp.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                            fDisp.Nm_empresa = (BS_Pedido.Current as TRegistro_Pedido).Nm_Empresa;
                            fDisp.rItemPed = BS_Itens.Current as TRegistro_LanPedido_Item;
                            fDisp.ShowDialog();
                        }
        }

        private void GerarDup()
        {
            if (BS_Pedido.Current != null)
            {
                if (!(BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("C"))
                {
                    //Verificar se TP.Pedido tem permissão para gerar financeiro
                    if (new TCD_CadCFGPedido().BuscarEscalar(
                         new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_gerarfin",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido + "'"
                        }
                    }, "1") != null)
                    {
                        if (new TCD_Pedido().BuscarEscalar(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_Pedido_X_Duplicata x " +
                                            "inner join TB_FIN_Duplicata y " +
                                            "on x.cd_empresa = y.cd_empresa " +
                                            "and x.nr_lancto = y.nr_lancto " +
                                            "where isnull(y.st_registro, 'C') = 'A' " +
                                            "and x.nr_pedido = '" + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido + "')"
                            }
                        }, "1") == null)
                        {
                            using (TFLanDuplicata fDuplicata = new TFLanDuplicata())
                            {
                                fDuplicata.vCd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                fDuplicata.vNm_empresa = (BS_Pedido.Current as TRegistro_Pedido).Nm_Empresa;
                                fDuplicata.vCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                                fDuplicata.vNm_clifor = (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor;
                                fDuplicata.vCd_endereco = (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco;
                                fDuplicata.vDs_endereco = (BS_Pedido.Current as TRegistro_Pedido).DS_Endereco;
                                fDuplicata.vCd_condpgto = (BS_Pedido.Current as TRegistro_Pedido).CD_CondPGTO;
                                fDuplicata.vDs_condpgto = (BS_Pedido.Current as TRegistro_Pedido).DS_CondPgto;
                                fDuplicata.vCd_moeda = (BS_Pedido.Current as TRegistro_Pedido).Cd_moeda;
                                fDuplicata.vDs_moeda = (BS_Pedido.Current as TRegistro_Pedido).Ds_moeda;
                                fDuplicata.vTp_mov = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Equals("E") ? "P" : "R";
                                fDuplicata.vVl_documento = (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido +
                                    ((BS_Pedido.Current as TRegistro_Pedido).Tp_frete.Trim().ToUpper().Equals("9") ||
                                     (BS_Pedido.Current as TRegistro_Pedido).Tp_frete.Trim().ToUpper().Equals("2") ?
                                    (BS_Pedido.Current as TRegistro_Pedido).Vl_frete : decimal.Zero);
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                fDuplicata.vNr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                                fDuplicata.vSt_finPed = true;
                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        (BS_Pedido.Current as TRegistro_Pedido).lDup.Add(
                                                                fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata);
                                        TCN_Pedido.GravaDuplicata(BS_Pedido.Current as TRegistro_Pedido, null);
                                        Busca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar Financeiro para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel Gerar Financeiro! Pedido já possui Duplicata Ativa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tipo de Pedido não tem permissão para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não é possivel Gerar Duplicata em Pedido Cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void TFLan_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                Novo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                Altera();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                Exclui();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                Busca();
            else if (e.KeyCode.Equals(Keys.F9) && bb_encerrar.Visible)
                encerrarPedido();
            else if ((e.Control) && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            Altera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            Exclui();
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            int position = 0;
            bsOrdemProducao.Clear();
            if (BS_Pedido.Current != null)
            {
                lblAnexo.Visible = (BS_Pedido.Current as TRegistro_Pedido).Anexo_compra != null;
                if ((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido > 0)
                {
                    if (bsEtapa.Current != null)
                        position = bsEtapa.Position;

                    miConferencia.Visible = (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F");
                    //Buscar lista de itens
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    "a.id_pedidoitem",
                                                                                                    false,
                                                                                                    null);
                    //Buscar OS Integradas ao Pedido
                    (BS_Pedido.Current as TRegistro_Pedido).lOsIntegra = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
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
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      "'AB', 'FE', 'PR', 'DV'",
                                                                                                                      string.Empty,
                                                                                                                      false,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                                      false,
                                                                                                                      false,
                                                                                                                      false,
                                                                                                                      false,
                                                                                                                      false,
                                                                                                                      0,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      null);
                    //Buscar conferencia de entrega
                    (BS_Pedido.Current as TRegistro_Pedido).lEntregaPedido = TCN_LanEntregaPedido.Busca(string.Empty,
                                                                                                        (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        false,
                                                                                                        string.Empty,
                                                                                                        null);

                    //Buscar Nota Fiscal
                    (BS_Pedido.Current as TRegistro_Pedido).lNotaFiscal =
                            new TCD_LanFaturamento().Select(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                "where x.Nr_Pedido = a.nr_pedido "+
                                                "and x.nr_pedido = "+(BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()+")"
                                }
                                }, 0, string.Empty);

                    //Buscar Duplicata Pedido
                    (BS_Pedido.Current as TRegistro_Pedido).lDup = TCN_LanPedido_X_Duplicata.BuscarDup((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido,
                                                                                                       null);

                    //Buscar Duplicata Nota fiscal
                    if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count.Equals(0) && (BS_Pedido.Current as TRegistro_Pedido).lNotaFiscal.Count > 0)
                        (BS_Pedido.Current as TRegistro_Pedido).lDup = TCN_LanPedido_X_Duplicata.BuscarDupNf((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                              null);

                    //Consulta dados clifor
                    TCN_Pedido.Consulta_Dados_Clifor((BS_Pedido.Current as TRegistro_Pedido));
                    //Buscar Vencimento Pedido
                    (BS_Pedido.Current as TRegistro_Pedido).Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido, null);
                    //Buscar configuracao pedido
                    TCN_Pedido.Busca_CFG_Fiscal(BS_Pedido.Current as TRegistro_Pedido);
                    //Buscar romaneio entrega
                    (BS_Pedido.Current as TRegistro_Pedido).lRomaneio = CamadaNegocio.Faturamento.Entrega.TCN_ItensRomaneio.Buscar(string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                                                   string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   null);
                    BS_Itens_PositionChanged(this, new EventArgs());
                    tcItens_SelectedIndexChanged(this, new EventArgs());
                    BS_Pedido.ResetCurrentItem();


                    if (bsEtapa.Current != null)
                    {
                        bsEtapa.Position = position;
                        bsEtapa_PositionChanged(this, new EventArgs());
                    }

                }
            }
        }

        private void Busca_CFG_Fiscal()
        {
            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Fiscal.Clear();
            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Fiscal = CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedidoFiscal.Buscar((BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty,
                                                                                                                        0,
                                                                                                                        0,
                                                                                                                        0,
                                                                                                                        string.Empty,
                                                                                                                        null);
            BS_Pedido.ResetCurrentItem();
        }

        private void btn_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new EditDefault[] { CD_Empresa_Busca }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void btn_CFG_Pedido_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CFG_Pedido_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido_Busca.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { CD_Clifor_Busca }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new EditDefault[] { Cd_produto }, string.Empty);
        }

        private void Cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_produto.Text.Trim() + "'",
                                                    new EditDefault[] { Cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void g_Consulta_Pedido_DoubleClick(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.BS_Pedido.Add(BS_Pedido.Current as TRegistro_Pedido);
                    fRastrear.TRastrear = TP_Rastrear.tm_pedido;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void g_Consulta_Pedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                    {
                        DataGridViewRow linha = g_Consulta_Pedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Teal;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                    {
                        DataGridViewRow linha = g_Consulta_Pedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = g_Consulta_Pedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                    {
                        DataGridViewRow linha = g_Consulta_Pedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = g_Consulta_Pedido.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                }
        }

        private void cd_endereco_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endereco_busca.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + CD_Clifor_Busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_endereco_busca }, new TCD_CadEndereco());
        }

        private void bb_endereco_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|200;" +
                              "a.cd_endereco|Cd. Endereço|80";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor_Busca.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_endereco_busca }, new TCD_CadEndereco(), vParam);
        }

        private void cd_condpgto_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_condpgto|=|'" + cd_condpgto_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_condpgto_busca }, new TCD_CadCondPgto());
        }

        private void cd_tabelapreco_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabelapreco|=|'" + cd_tabelapreco_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_tabelapreco_busca }, new TCD_CadTbPreco());
        }

        private void bb_condpgto_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_condpgto_busca },
                                    new TCD_CadCondPgto(), string.Empty);
        }

        private void bb_tabelapreco_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_tabelapreco_busca }, new TCD_CadTbPreco(), string.Empty);
        }

        private void cd_vendedor_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor_busca.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_vendedor_busca },
                                    new TCD_CadClifor());
        }

        private void bb_vendedor_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_vendedor_busca },
                new TCD_CadClifor(),
               vParam);
        }

        private void cd_moeda_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_moeda|=|'" + cd_moeda_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_moeda_busca }, new TCD_Moeda());
        }

        private void bb_moeda_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Moeda|200;" +
                              "cd_Moeda|Cd. Moeda|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_moeda_busca }, new TCD_Moeda(), string.Empty);
        }

        private void bb_encerrar_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).St_Commodittiesbool)
                {
                    MessageBox.Show("Não é permitido encerrar pedido de commoditties.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper() != "F")
                {
                    MessageBox.Show("É permitido ENCERRAR somente pedidos fechados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja Realmente ENCERRAR o pedido? ", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    DialogResult.Yes)
                {
                    encerrarPedido();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar pedido para ser encerrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Imprimir_PedidosPorCliFor()
        {

            if (BS_Pedido.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = "TFLan_Pedido_Imprimir_Pedidos";
                    Rel.Ident = "TFLan_Pedido_Imprimir_Pedidos";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    //(BS_Pedido.DataSource as TList_Pedido).ForEach(p => TCN_Pedido.Busca_Pedido_Itens(p, null));
                    BindingSource BinDados = new BindingSource();
                    TpBusca[] filtro = new TpBusca[0];
                    if (!string.IsNullOrEmpty(NR_Pedido_Busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.nr_pedido";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = nr_pedidoorigem_busca.Text;
                    }
                    if (!string.IsNullOrEmpty(CFG_Pedido_Busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cfg_pedido";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + CFG_Pedido_Busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(CD_Empresa_Busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_empresa";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa_Busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(CD_Clifor_Busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_clifor";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor_Busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(Cd_produto.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Text + "'";
                    }
                    if (cbEntrada.Checked || cbSaida.Checked)
                    {
                        string tp_mov = string.Empty;
                        string virg = string.Empty;
                        if (cbEntrada.Checked)
                        {
                            tp_mov = "'E'";
                            virg = ",";
                        }
                        if (cbSaida.Checked)
                            tp_mov += virg + "'S'";
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.tp_movimento";
                        filtro[filtro.Length - 1].vOperador = "in";
                        filtro[filtro.Length - 1].vVL_Busca = "(" + tp_mov.Trim() + ")";
                    }
                    if (cck_Fechado.Checked ||
                        cck_expirado.Checked ||
                        cck_Encerrado.Checked ||
                        cck_Cancelado.Checked)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.ST_Pedido";
                        filtro[filtro.Length - 1].vOperador = "IN";

                        string Virgula = "";
                        string IN = "( ";

                        if (cck_Cancelado.Checked)
                        {
                            IN += Virgula + "'C'";
                            Virgula = ",";
                        }
                        if (cck_Fechado.Checked || cck_expirado.Checked)
                        {
                            IN += Virgula + "'F'";
                            Virgula = ",";
                        }
                        if (cck_Encerrado.Checked)
                        {
                            IN += Virgula + "'P'";
                            Virgula = ",";
                        }
                        filtro[filtro.Length - 1].vVL_Busca = IN + ")";
                        if (cck_expirado.Checked)
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "(isnull(a.dt_entregapedido, getdate())";
                            filtro[filtro.Length - 1].vOperador = "<";
                            filtro[filtro.Length - 1].vVL_Busca = "getdate())";
                        }
                    }
                    if (!string.IsNullOrEmpty(nr_pedidoorigem_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.nr_pedidoorigem";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + nr_pedidoorigem_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(cd_endereco_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_endereco";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + cd_endereco_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(cd_vendedor_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_vendedor";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + cd_vendedor_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(cd_condpgto_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_condpgto";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + cd_condpgto_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(cd_tabelapreco_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_tabelapreco";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + cd_tabelapreco_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(cd_moeda_busca.Text))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.cd_moeda";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + cd_moeda_busca.Text + "'";
                    }
                    if (!string.IsNullOrEmpty(DT_Inicial.Text.SoNumero()))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), n.dt_pedido)))";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (!string.IsNullOrEmpty(DT_Final.Text.SoNumero()))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), n.dt_pedido)))";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (VL_Inicial.Value > decimal.Zero)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.vl_totalpedido";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), VL_Inicial.Value.ToString());
                    }
                    if (VL_Final.Value > decimal.Zero)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "n.vl_totalpedido";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), VL_Final.Value.ToString());
                    }
                    if (st_comconferencia.Checked)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                        filtro[filtro.Length - 1].vOperador = string.Empty;
                        filtro[filtro.Length - 1].vVL_Busca = "((exists(select 1 from tb_fat_entregapedido x " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and isnull(x.st_registro, 'A') = 'P')) or ( " +
                                                              "isnull(cfgped.st_exigirconferenciaentrega, 'N') = 'N'))";
                    }
                    BinDados.DataSource = new TCD_LanPedido_Item().BuscarRelAnaliticoPorClifor(filtro);
                    Rel.DTS_Relatorio = BinDados;

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                                    "RELATORIO " + Text.Trim(),
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
                                                "RELATORIO " + Text.Trim(),
                                                fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void relatorioVisualizarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir_Pedidos_Sintetico();
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir_PedidosPorCliFor();
        }

        private void Imprimir_Pedidos_Sintetico()
        {
            if (BS_Pedido.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = BS_Pedido;
                    Rel.Nome_Relatorio = "TFLan_Pedido_Total_Pedidos_Sintetico";
                    Rel.Ident = "TFLan_Pedido_Total_Pedidos_Sintetico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void PedidoExpirado()
        {
            //Buscar total os expiradas
            try
            {
                lblExpirado.Text = new TCD_Pedido().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                  "where x.cd_empresa = a.cd_empresa " +
                                                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))) and " +
                                                                  "(exists(select 1 from tb_div_usuario_X_cfgpedido ped " +
                                                                  "         where ped.cfg_pedido = a.cfg_pedido and ped.login = '" + Utils.Parametros.pubLogin.Trim() + "')))"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_pedido, 'F')",
                                                vOperador = "=",
                                                vVL_Busca = "'F'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.dt_entregapedido",
                                                vOperador = "<",
                                                vVL_Busca = "getdate()"
                                            }
                                        }, "count(*)").ToString();

            }
            catch { }
        }
        private void relatorioSeparacaooItensDoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    TList_RegLanPedido_Item lItem = new TList_RegLanPedido_Item();
                    TCN_Pedido.MontarListaSeparacaoPed((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                       lItem);
                    BindingSource dts = new BindingSource();
                    dts.DataSource = lItem;
                    Rel.DTS_Relatorio = dts;
                    BindingSource bs_pedido = new BindingSource();
                    TList_Pedido lPed = new TList_Pedido();
                    lPed.Add((BS_Pedido.Current as TRegistro_Pedido));
                    bs_pedido.DataSource = lPed;
                    Rel.Adiciona_DataSource("bs_Pedido", bs_pedido);
                    Rel.Adiciona_DataSource("BS_EMPRESA", BinEmpresa);
                    Rel.NM_Classe = "TFLan_Pedido_Separacao_Itens_Pedido";
                    Rel.Ident = "TFLan_Pedido_Separacao_Itens_Pedido";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
        }

        private void llbPesquisa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llbPesquisa.Tag.ToString().Trim().Equals("N"))
            {
                //Mudar para modo completo
                llbPesquisa.Text = "<<<Pesquisa Normal";
                tlpCentral.RowStyles[0].Height = 132;
                llbPesquisa.Tag = "C";
            }
            else
            {
                //Mudar para modo normal
                llbPesquisa.Text = "Pesquisa Avançada>>>";
                tlpCentral.RowStyles[0].Height = 61;
                llbPesquisa.Tag = "N";
                nr_pedidoorigem_busca.Clear();
                cd_endereco_busca.Clear();
                cd_vendedor_busca.Clear();
                cd_condpgto_busca.Clear();
                cd_tabelapreco_busca.Clear();
                cd_moeda_busca.Clear();
                DT_Inicial.Clear();
                DT_Final.Clear();
                VL_Inicial.Value = VL_Inicial.Minimum;
                VL_Final.Value = VL_Final.Minimum;
                st_comconferencia.Checked = false;
            }
        }

        private void BS_Itens_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Itens.Current != null)
            {
                //Buscar ficha tecnica
                (BS_Itens.Current as TRegistro_LanPedido_Item).lFichaTec =
                    TCN_FichaTecItemPed.Buscar((BS_Itens.Current as TRegistro_LanPedido_Item).Nr_PedidoString,
                                               (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto,
                                               (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString(),
                                               string.Empty,
                                               null);
                BS_Pedido.ResetCurrentItem();
            }
        }

        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLan_Pedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            ShapeGrid.SaveShape(this, g_Fiscais);
            ShapeGrid.SaveShape(this, g_Itens);
            ShapeGrid.SaveShape(this, g_Parcelas);
            ShapeGrid.SaveShape(this, gEntrega);
            ShapeGrid.SaveShape(this, gOrdemServico);
            ShapeGrid.SaveShape(this, gParcelas);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, gDup);
        }

        private void tcItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {

                if (tcItens.SelectedTab.Equals(tpEtapas))
                {
                    preencheEtapa();
                }
                if (tcItens.SelectedTab.Equals(tpAcessorios))
                {
                    //Buscar Acessórios
                    (BS_Pedido.Current as TRegistro_Pedido).lAcessorios =
                        TCN_AcessoriosPed.Buscar((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                }
                BS_Pedido.ResetCurrentItem();
            }
        }
        private void preencheEtapa()
        {
            int i = bsEtapa.Position;

            (BS_Pedido.Current as TRegistro_Pedido).lEtapa =
                       TCN_EtapaPedido.Busca(string.Empty,
                                             (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                             null);
            bsEtapa.ResetCurrentItem();
            bsEtapa.Position = i;
        }
        private void g_Consulta_Pedido_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_Consulta_Pedido.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_Pedido.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Pedido());
            TList_Pedido lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_Pedido.List as TList_Pedido).Sort(lComparer);
            BS_Pedido.ResetBindings(false);
            g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void lblExpirado_Click(object sender, EventArgs e)
        {
            PedidoExpirado();
            LimparFiltros();
            cck_expirado.Checked = true;
            Busca();
            cck_expirado.Checked = false;
        }

        private void calcularImpostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimularImpostos();
        }

        private void disponibilidadeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerificarEstoque();
        }

        private void gerarDuplicataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarDup();
        }

        private void conferenciaPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current == null)
            {
                MessageBox.Show("Não existe pedido selecionado para gerar conferência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper() != "F")
            {
                MessageBox.Show("Permitido gerar conferência somente de pedido com status <FECHADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                GerarConferenciaPedido(BS_Pedido.Current as TRegistro_Pedido);
                LimparFiltros();
                NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                Busca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void romaneioEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Permitido gerar romaneio de entrega somente para pedido de SAIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).Vl_totalfat_saida > decimal.Zero)
                {
                    MessageBox.Show("Permitido gerar romaneio de entrega somente de pedido sem FATURAMENTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    using (TFItensEntrega fItensEntrega = new TFItensEntrega())
                    {
                        fItensEntrega.rPedido = BS_Pedido.Current as TRegistro_Pedido;
                        if (fItensEntrega.ShowDialog() == DialogResult.OK)
                            if (fItensEntrega.rEntrega != null)
                            {
                                if (fItensEntrega.rEntrega.lItens.Count > decimal.Zero)
                                {
                                    CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Gravar(fItensEntrega.rEntrega, null);
                                    MessageBox.Show("Romaneio de Entrega Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Excluir(fItensEntrega.rEntrega, null);
                                    MessageBox.Show("Romaneio de Entrega Excluido com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void consultarRomaneioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFConsultaRomaneio fConsulta = new TFConsultaRomaneio())
            {
                if (BS_Pedido.Current != null)
                    fConsulta.pNr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                fConsulta.ShowDialog();
            }
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if (!(BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("CANCELADO"))
                {
                    TRegistro_Pedido pedido = (BS_Pedido.Current as TRegistro_Pedido);
                    TCN_Pedido.Busca_CFG_Fiscal(pedido);
                    TCN_Pedido.Busca_Pedido_Itens(pedido, false, null);
                    pedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(pedido.Nr_pedido, null);
                    if (pedido.Pedido_Itens.Count > 0)
                        pedido.Pedidos_DT_Vencto.ForEach(p => p.Vl_juro_fin = Math.Round((p.VL_Parcela * pedido.Pedido_Itens[0].Pc_juro_fin) / 100, 2));
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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
                    BinEndereco.DataSource = TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                                                    (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
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
                    BinEndEntrega.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa + "'"
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
                    if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count > 0)
                    {
                        TList_RegLanParcela lParc =
                            new TCD_LanParcela().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lancto",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).lDup[0].Nr_lancto.ToString()
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty);
                        //Criar fonte de dados para parcelas pedido
                        lParc.ForEach(p =>
                        {
                            //Criar fonte de dados
                            DataTable tb_dup = new DataTable();
                            tb_dup.Columns.Add("Nr_Pedido", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("VL_Parcela", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("Dt_vencto", Type.GetType("System.DateTime"));
                            DataRow linha = tb_dup.NewRow();
                            linha["Nr_Pedido"] = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                            linha["VL_Parcela"] = p.Vl_parcela;
                            linha["Dt_vencto"] = p.Dt_vencto;
                            BinParcelas.Add(linha);
                        });
                    }
                    else
                    {

                        BinParcelas.DataSource = TCN_LanPedido_DT_Vencto.Busca((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido,
                                                                                                                 null);
                    }

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                               (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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
                    //Buscar Ficha Técnica do cadastro do produto
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    {
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                        {
                            p.lFicha =
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto,
                                                                                           string.Empty,
                                                                                           null);
                        }
                    });


                    object obj = new TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");
                    if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        try
                        {
                            TCN_Pedido.ImprimirPedido(pedido,
                                                      BinClifor.Current as TRegistro_CadClifor,
                                                      BinEndereco.Current as TRegistro_CadEndereco,
                                                      BinEmpresa.Current as TRegistro_CadEmpresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        Relatorio Relatorio = new Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = "TFRelPedido";
                        Relatorio.NM_Classe = Name;
                        Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                        TList_Pedido lista_pedido = new TList_Pedido();
                        lista_pedido.Add(pedido);
                        BindingSource meu_bind = new BindingSource();
                        meu_bind.DataSource = lista_pedido;
                        BS_Pedido.ResetCurrentItem();
                        Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                        Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                        Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                        Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                        Relatorio.Adiciona_DataSource("ITENS", BS_Itens);
                        Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                        Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                        Relatorio.Adiciona_DataSource("PARCELAS", BinParcelas);
                        Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                        Relatorio.DTS_Relatorio = meu_bind;

                        Relatorio.Ident = "TFRelPedido";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                                fImp.pCd_representante = (BS_Pedido.Current as TRegistro_Pedido).Cd_representante;
                                fImp.pMensagem = ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                            (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                            fImp.pSt_imprimir,
                                                            fImp.pSt_visualizar,
                                                            fImp.pSt_enviaremail,
                                                            fImp.pSt_exportPdf,
                                                            fImp.Path_exportPdf,
                                                            fImp.pDestinatarios,
                                                            null,
                                                            ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                                            (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
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

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            faturarPedido("'NO'");
        }

        private void miNfDev_Click(object sender, EventArgs e)
        {
            faturarPedido("'DV','DF'");
        }

        private void miNfComplemento_Click(object sender, EventArgs e)
        {
            faturarPedido("'CP', 'CF'");
        }

        private void nFEntregaFuturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faturarPedido("'FT'");
        }

        private void importarXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                using (TFImportXmlPedido fXml = new TFImportXmlPedido())
                {
                    using (OpenFileDialog op = new OpenFileDialog())
                    {
                        op.Filter = "Documentos XML|*.xml";
                        op.InitialDirectory = "c:";
                        op.Title = "Selecione XML NFe";
                        if (op.ShowDialog() == DialogResult.OK)
                            if (System.IO.File.Exists(op.FileName))
                            {
                                fXml.rPedido = BS_Pedido.Current as TRegistro_Pedido;
                                fXml.NomeArquivo = op.FileName;
                                fXml.ShowDialog();
                            }

                    }
                }
        }

        private void nFServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).Vl_saldopedido.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não existe saldo para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p => p.St_servico))
                {
                    MessageBox.Show("Pedido não possui Itens Serviços!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //Verificar se existe configuracao fiscal para servico
                    object
                    obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FAT_CFGPedido x " +
                                                "where a.cfg_pedido = x.cfg_pedido " +
                                                "and isnull(x.st_servico, 'N') = 'S') "
                                }
                            }, "a.cfg_pedido");
                    if (obj == null)
                    {
                        MessageBox.Show("Não existe configuração fiscal para Serviço!",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //Gerar Nota Fiscal
                        TRegistro_LanFaturamento rFat =
                            Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturarServico(BS_Pedido.Current as TRegistro_Pedido,
                                                                                            obj.ToString(),
                                                                                            false,
                                                                                            decimal.Zero);
                        //Gravar Nota Fiscal
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                        try
                        {
                            TRegistro_LanFaturamento rNf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                             rFat.Nr_lanctofiscalstr,
                                                                                             null);
                            NFES.TGerarRPS.CriarArquivoRPS(rNf.rCfgNfe, new List<TRegistro_LanFaturamento>() { rNf });
                            MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Busca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Busca();
                        }
                    }
                }
            }
        }

        private void ordemDeCarregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if (!(BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("CANCELADO"))
                {
                    TRegistro_Pedido pedido = (BS_Pedido.Current as TRegistro_Pedido);
                    TCN_Pedido.Busca_CFG_Fiscal(pedido);
                    TCN_Pedido.Busca_Pedido_Itens(pedido, false, null);
                    pedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(pedido.Nr_pedido, null);
                    if (pedido.Pedido_Itens.Count > 0)
                        pedido.Pedidos_DT_Vencto.ForEach(p => p.Vl_juro_fin = Math.Round((p.VL_Parcela * pedido.Pedido_Itens[0].Pc_juro_fin) / 100, 2));
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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
                    BinEndereco.DataSource = TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                                                    (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
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
                    BinEndEntrega.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa + "'"
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

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                               (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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

                    //Buscar ficha tecnica
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    {
                        if (p.lFichaTec.Count.Equals(0))
                            p.lFichaTec = TCN_FichaTecItemPed.Buscar(p.Nr_PedidoString,
                                               p.Cd_produto,
                                               p.Id_pedidoitem.ToString(),
                                               string.Empty,
                                               null);
                    });


                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "FLan_OrdemCarregamento";
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Pedido lista_pedido = new TList_Pedido();
                    lista_pedido.Add(pedido);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista_pedido;
                    BS_Pedido.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("ITENS", BS_Itens);
                    Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_OrdemCarregamento";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                            fImp.pMensagem = ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                        (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ((BS_Pedido.Current as TRegistro_Pedido).Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                                        (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
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

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
            if (bsProcessos.Current != null)
            {
                //Verificar se usuario tem acesso a etapa.
                if (new CamadaDados.Diversos.TCD_CadUsuario_EtapaPed().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_etapa",
                                vOperador = "=",
                                vVL_Busca = (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapastr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            }
                        }, "1") == null)
                {
                    MessageBox.Show("Usuário não tem permissão para evoluir etapa " +
                                    (bsEtapa.Current as TRegistro_EtapaPedido).DS_Etapa.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
                {
                    MessageBox.Show("Não é possível finalizar processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a finalização do processo " +
                                   (bsProcessos.Current as TRegistro_ProcEtapa).DS_Processo.Trim() + "?",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                    try
                    {
                        TCN_ProcEtapa.Finalizar(bsProcessos.Current as TRegistro_ProcEtapa, BS_Pedido.Current as TRegistro_Pedido, null);
                        MessageBox.Show("Processo finalizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Busca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void btn_editarObs_Click(object sender, EventArgs e)
        {
            if (bsProcessos.Current != null)
            {
                //Verificar se usuario tem acesso a etapa.
                if (new CamadaDados.Diversos.TCD_CadUsuario_EtapaPed().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_etapa",
                                vOperador = "=",
                                vVL_Busca = (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapastr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            }
                        }, "1") == null)
                {
                    MessageBox.Show("Usuário não tem permissão para evoluir etapa " +
                                    (bsEtapa.Current as TRegistro_EtapaPedido).DS_Etapa.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*if (!string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
                {
                    MessageBox.Show("Não é possível editar observação de processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }*/
                //Criar Form
                using (fEditar = new Form())
                {
                    fEditar.Size = new Size(520, 360);
                    fEditar.StartPosition = FormStartPosition.CenterScreen;
                    fEditar.ShowInTaskbar = false;
                    fEditar.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                    fEditar.MinimizeBox = false;
                    fEditar.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fEditar.Text = "Editar Obs";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;

                    // se processado apenas visualizar
                    if (string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
                    {
                        Button btn = new Button();
                        panel.Controls.Add(btn);
                        btn.Dock = DockStyle.Bottom;
                        btn.Text = "Gravar";
                        btn.Click += new System.EventHandler(btn_Click);
                    }
                    //Criar Texbox
                    TextBox txt = new TextBox();
                    fEditar.Controls.Add(panel);
                    panel.Controls.Add(txt);
                    txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    txt.Dock = DockStyle.Fill;
                    txt.Multiline = true;
                    txt.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsProcessos, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    txt.Text = (bsProcessos.Current as TRegistro_ProcEtapa).Obs;
                    if (fEditar.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(txt.Text))
                            try
                            {
                                TCN_ProcEtapa.Gravar(bsProcessos.Current as TRegistro_ProcEtapa, null);
                                Busca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            fEditar.DialogResult = DialogResult.OK;
        }

        private void bb_NovoAnexo_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    if (file.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(file.FileName))
                        {
                            TRegistro_AnexoPedido rAnexo =
                                new TRegistro_AnexoPedido();
                            rAnexo.Anexo = System.IO.File.ReadAllBytes(file.FileName);
                            rAnexo.Ext_Anexo = System.IO.Path.GetExtension(file.FileName);
                            InputBox ibp = new InputBox();
                            ibp.Text = "Descrição Anexo";
                            string ds = ibp.ShowDialog();
                            if (string.IsNullOrEmpty(ds))
                            {
                                MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            try
                            {
                                rAnexo.Ds_anexo = ds;
                                rAnexo.Nr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                                TCN_AnexoPedido.Gravar(rAnexo, null);
                                MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcItens_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void bb_ExcluirAnexo_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null)
                if (MessageBox.Show("Deseja excluir esse Anexo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_AnexoPedido.Excluir(bsAnexo.Current as TRegistro_AnexoPedido, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcItens_SelectedIndexChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gAnexo_DoubleClick(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null)
            {
                if (!string.IsNullOrEmpty((bsAnexo.Current as TRegistro_AnexoPedido).Ext_Anexo))
                {
                    byte[] arquivoBuffer = (bsAnexo.Current as TRegistro_AnexoPedido).Anexo;
                    string extensao = (bsAnexo.Current as TRegistro_AnexoPedido).Ext_Anexo; // retornar do banco tbm

                    string path = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                    System.IO.File.WriteAllBytes(
                        path,
                        arquivoBuffer);

                    // para abrir o arquivo para o usuario
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                    Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                    Rel.Nome_Relatorio = "TFOrdem_Servico";
                    Rel.Ident = "TFOrdem_Servico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Ordem de serviço";

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void controleDeEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (BS_Pedido.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                    Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                    Rel.Nome_Relatorio = "TFControle_entregatanque";
                    Rel.Ident = "TFControle_entregatanque";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Controle de entrega de tanque";

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void impOrdemServico_Click(object sender, EventArgs e)
        {

            if (BS_Pedido.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                    Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                    Rel.Nome_Relatorio = "TFOrdem_Servico";
                    Rel.Ident = "TFOrdem_Servico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Ordem de serviço";

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void impEntregaTanque_Click(object sender, EventArgs e)
        {
            {
                if (BS_Pedido.Count > 0)
                {

                    object obj = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "'"
                            }
                        }, "c.fone");

                    (BS_Pedido.Current as TRegistro_Pedido).DadosEmpresa.rEndereco.Fone = obj.ToString();

                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio Rel = new Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                        Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                        Rel.Nome_Relatorio = "TFControle_entregatanque";
                        Rel.Ident = "TFControle_entregatanque";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = Tag.ToString().Substring(0, 3);

                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "Controle de entrega de tanque";

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
                                               "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                    }
                }
                else
                    MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void ImpTGarantia_Click(object sender, EventArgs e)
        {
            {

                if (BS_Pedido.Count > 0)
                {


                    object obj = new TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor.Trim() + "'"
                            }
                        }, "isnull(a.nr_cgc, a.nr_cpf) as NR_CGC_CPF");

                    (BS_Pedido.Current as TRegistro_Pedido).nr_cgc_cpf = obj.ToString();
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio Rel = new Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                        Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                        Rel.Nome_Relatorio = "TFTermoGarantia";
                        Rel.Ident = "TFTermoGarantia";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = Tag.ToString().Substring(0, 3);

                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "Termo de garantia";

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
                                               "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                    }
                }
                else
                    MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void implaudotec_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Count > 0)

            {
                //busca uf
                object obj1 = new TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor.Trim() + "'"
                            }
                        }, "(select y.uf from tb_fin_endereco x" +
                                            " join TB_FIN_Cidade z " +
                                            " on z.CD_Cidade = x.CD_Cidade" +
                                            " join tb_fin_uf y" +
                                            " on y.CD_UF = z.CD_UF " +
                                            " where a.cd_clifor = x.cd_clifor) as uf");

                (BS_Pedido.Current as TRegistro_Pedido).UF = obj1.ToString();
                //buca cpf ou cnpj
                object obj2 = new TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor.Trim() + "'"
                            }
                        }, "isnull(a.nr_cgc, a.nr_cpf) as NR_CGC_CPF");

                (BS_Pedido.Current as TRegistro_Pedido).nr_cgc_cpf = obj2.ToString();
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                    Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                    Rel.Nome_Relatorio = "TFLaudoTecnico";
                    Rel.Ident = "TFLaudoTecnico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Laudo técnico de estanqueidade";

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void fichaDeAcompanhamentoDoTanqueToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (BS_Pedido.Count > 0)
            {
                //buca cpf ou cnpj
                object obj2 = new TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor.Trim() + "'"
                            }
                        }, "isnull(a.nr_cgc, a.nr_cpf) as NR_CGC_CPF");

                (BS_Pedido.Current as TRegistro_Pedido).nr_cgc_cpf = obj2.ToString();
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Adiciona_DataSource("BS_Pedido", BS_Pedido);
                    Rel.Adiciona_DataSource("bs_itens", BS_Itens);
                    Rel.Nome_Relatorio = "TFFichaAcompanhamento";
                    Rel.Ident = "TFFichaAcompanhamento";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "FICHA DE ACOMPANHAMENTO DO TANQUE";

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void gEtapas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ABERTO"))
                    {
                        DataGridViewRow linha = gEtapas.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gEtapas.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
        }

        private void gProcessos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 1)

                    if (e.Value.ToString().Trim() != string.Empty)
                    {
                        DataGridViewRow linha = gProcessos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gProcessos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                if (bsAnexo.Current != null)
                    if (MessageBox.Show("Deseja excluir esse Anexo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_AnexoPedido.Excluir(bsAnexo.Current as TRegistro_AnexoPedido, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  tcItens_SelectedIndexChanged(this, new EventArgs());
                            bsProcessos_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Não é possível excluir anexo do processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current as TRegistro_AnexoPedido != null)
            {
                string ae;
                byte[] arquivoBuffer = (bsAnexo.Current as TRegistro_AnexoPedido).Anexo;
                string extensao = (bsAnexo.Current as TRegistro_AnexoPedido).Ext_Anexo; // retornar do banco tbm
                ae = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    ae,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(ae);
            }
        }

        private void bsProcessos_PositionChanged(object sender, EventArgs e)
        {
            if (bsProcessos.Current != null)
                (bsProcessos.Current as TRegistro_ProcEtapa).lAnexo =
                    TCN_AnexoPedido.Buscar(
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Nr_pedidostr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_etapastr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_processostr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_Anexo,
                                            null);
            bsProcessos.ResetCurrentItem();

        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                if (BS_Pedido.Current != null)
                {
                    using (OpenFileDialog file = new OpenFileDialog())
                    {
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(file.FileName))
                            {
                                if ((bsProcessos.Current as TRegistro_ProcEtapa != null) && (bsEtapa.Current as TRegistro_EtapaPedido != null))
                                {
                                    TRegistro_AnexoPedido rAnexo =
                                        new TRegistro_AnexoPedido();
                                    rAnexo.Anexo = System.IO.File.ReadAllBytes(file.FileName);
                                    rAnexo.Ext_Anexo = System.IO.Path.GetExtension(file.FileName);
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Descrição Anexo";
                                    rAnexo.Id_processo = (bsProcessos.Current as TRegistro_ProcEtapa).Id_processo;
                                    rAnexo.Id_etapa = (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapa;
                                    string ds = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(ds))
                                    {
                                        MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    try
                                    {
                                        rAnexo.Ds_anexo = ds;
                                        rAnexo.Nr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                                        TCN_AnexoPedido.Gravar(rAnexo, null);
                                        bsProcessos_PositionChanged(this, new EventArgs());
                                        MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é possível adicionar anexo onde  o processo é FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void bsEtapa_PositionChanged(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
                (bsEtapa.Current as TRegistro_EtapaPedido).lProcEtapa =
                    TCN_ProcEtapa.Busca(
                    (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapastr,
                    (bsEtapa.Current as TRegistro_EtapaPedido).Nr_pedidostr,
                    string.Empty,
                    null
                    );
            bsEtapa.ResetCurrentItem();

            bsProcessos_PositionChanged(this, new EventArgs());
        }

        private void bb_excuir_etapa_Click(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                if (bsProcessos.Current != null)
                    if (!string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
                    {
                        MessageBox.Show("Não é possível excluir etapa FINALIZADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                       "Deseja excluir esta etapa.",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    try
                    {
                        TCN_EtapaPedido.Excluir(bsEtapa.Current as TRegistro_EtapaPedido, null);
                        bsEtapa.RemoveCurrent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bb_excluir_procetapa_Click(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                if (!string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
                {
                    MessageBox.Show("Não é possível excluir processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsProcessos.Current as TRegistro_ProcEtapa).lAnexo.Count > 0)
                {
                    MessageBox.Show("Não é possível excluir processo com anexo!\r\n" +
                                    "Exclua primeiro o anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                {
                    if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                       "Deseja excluir esta etapa.",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_ProcEtapa.Excluir(bsProcessos.Current as TRegistro_ProcEtapa, null);
                            Busca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bb_imfichatec_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Count > 0)
            {
                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_FAT_FICHATECNICA_PED";
                Relatorio.NM_Classe = "REL_FAT_FICHATECNICA_PED";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "REL_FAT_FICHATECNICA_PED";

                //Buscar ficha tecnica produto
                TList_RegLanPedido_Item lItens = new TList_RegLanPedido_Item();
                TCN_Pedido.MontarFichaTecItem((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                               (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_local,
                                                                               BS_Itens.Current as TRegistro_LanPedido_Item,
                                                                               lItens);
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lItens;
                Relatorio.DTS_Relatorio = bsFicha;
                Relatorio.Parametros_Relatorio.Add("NR_PEDIDO", (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido);
                Relatorio.Parametros_Relatorio.Add("CD_PRODUTO", (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto);
                Relatorio.Parametros_Relatorio.Add("DS_PRODUTO", (BS_Itens.Current as TRegistro_LanPedido_Item).Ds_produto);

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + (BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto.Trim(),
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

        private void afterPrint()
        {
            if (bsNotaFiscal.Current != null)
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }
        private void Imprime_Danfe()
        {
            Relatorio Danfe = new Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST + v.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
            //Buscar financeiro da DANFE
            TList_RegLanParcela lParc =
                new TCD_LanParcela().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                lParc =
                    new TCD_LanParcela().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count == 0)
                {
                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                    lParc =
                        new TCD_LanParcela().Select(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
            }
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }


        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                        bool St_imprimir,
                                        bool St_visualizar,
                                        bool St_enviaremail,
                                        List<string> Destinatarios,
                                        string Titulo,
                                        string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((bsProcessos.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                //verifica se usuario pode reabrir etapa
                if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR REABRIR ETAPA", null))
                {
                    MessageBox.Show("Usuário não possui permissão para reabrir!");
                }
                else
                {
                    if (MessageBox.Show("Reabrir processo selecionado? " +
                       (bsProcessos.Current as TRegistro_ProcEtapa).DS_Processo.Trim() + "?",
                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            TCN_ProcEtapa.Reabrir(bsProcessos.Current as TRegistro_ProcEtapa, null);
                            MessageBox.Show("Processo reaberto com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Busca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            else
                MessageBox.Show("Processo está em aberto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nFRemessaTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    //Verificar se o pedido tem configuracao fiscal para emitir nota
                    object obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cfg_pedido",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'RT'"
                                        }
                                    }, "1");
                    if (obj == null ? true : obj.ToString().Trim() != "1")
                    {
                        MessageBox.Show("Não existe configuração fiscal para emitir REMESSA TRANSPORTE " + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TRegistro_LanFaturamento rFat =
                            Proc_Commoditties.TProcessarRemessaTransp.ProcessarNF(BS_Pedido.Current as TRegistro_Pedido);
                        TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                        //Buscar nota de origem
                        rFat = TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                           rFat.Nr_lanctofiscal.ToString(),
                                                           null);
                        //Se for nota propria e NF-e
                        if (rFat.Tp_nota.Trim().ToUpper().Equals("P") &&
                            rFat.Cd_modelo.Trim().Equals("55"))
                        {
                            if (MessageBox.Show("Deseja enviar NF-e REMESSA TRANSPORTE para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                try
                                {
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = rFat;
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        else if (rFat.Tp_nota.Trim().ToUpper().Equals("P") && (!rFat.Cd_modelo.Trim().Equals("55")))
                        {
                            //Chamar tela de impressao para a nota fiscal
                            //somente se for nota propria
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = rFat.Cd_clifor;
                                fImp.pMensagem = "NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    new LayoutNotaFiscal().Imprime_NF(rFat,
                                                                      fImp.pSt_imprimir,
                                                                      fImp.pSt_visualizar,
                                                                      fImp.pSt_enviaremail,
                                                                      fImp.pDestinatarios,
                                                                      "NOTA FISCAL Nº " + rFat.Nr_notafiscal.ToString(),
                                                                      fImp.pDs_mensagem);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("É permitido faturar somente pedido fechado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_trocarItemPedido_Click(object sender, EventArgs e)
        {
            if (BS_Itens.Count > 0)
            {
                if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR PEDIDO ITEM", null))
                {
                    MessageBox.Show("Usuário não tem permissão para ALTERAR PEDIDO ITEM!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se Pedido está faturado
                if (((BS_Pedido.Current as TRegistro_Pedido).Vl_totalfat_entrada > 0 ||
                     (BS_Pedido.Current as TRegistro_Pedido).Vl_totalfat_saida > 0) ? true :
                    new TCD_LanFaturamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.Nr_pedido",
                                vOperador = "=",
                                vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Pedido já se encontra faturado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Valor do Pedido Anterior
                decimal vl_pedidoanterior = (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido;
                using (TFLan_Itens_Faturamento Lan_Itens = new TFLan_Itens_Faturamento())
                {
                    Lan_Itens.CD_TabelaPreco = (BS_Pedido.Current as TRegistro_Pedido).Cd_tabelapreco;
                    Lan_Itens.CD_Empresa = (BS_Pedido.Current as TRegistro_Pedido).cd_empresa;
                    Lan_Itens.Nm_empresa = (BS_Pedido.Current as TRegistro_Pedido).Nm_Empresa;
                    Lan_Itens.Cd_cliente = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                    Lan_Itens.Cd_vendedor = (BS_Pedido.Current as TRegistro_Pedido).Cd_vendedor;
                    Lan_Itens.st_Commodities = false;
                    Lan_Itens.Cfg_pedido = (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido;
                    Lan_Itens.St_integraralmox = false;
                    Lan_Itens.pTp_movimento = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                    if (Lan_Itens.ShowDialog() == DialogResult.OK)
                        if (Lan_Itens.rItem != null)
                        {
                            Lan_Itens.rItem.Id_pedidoitem = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_pedidoitem;
                            Lan_Itens.rItem.Nr_orcamento = (BS_Itens.Current as TRegistro_LanPedido_Item).Nr_orcamento;
                            Lan_Itens.rItem.Id_itemorc = (BS_Itens.Current as TRegistro_LanPedido_Item).Id_itemorc;
                            (BS_Pedido.Current as TRegistro_Pedido).Deleta_Pedido_Itens.Add(
                               BS_Itens.Current as TRegistro_LanPedido_Item);
                            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Remove(
                                BS_Itens.Current as TRegistro_LanPedido_Item);


                            (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(Lan_Itens.rItem);
                            (BS_Pedido.Current as TRegistro_Pedido).lDup.Clear();
                            if ((BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido != vl_pedidoanterior)
                            {
                                if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count > 0 &&
                                    (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido > vl_pedidoanterior)

                                {
                                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                    {
                                        fDuplicata.vCd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                        fDuplicata.vNm_empresa = (BS_Pedido.Current as TRegistro_Pedido).Nm_Empresa;
                                        fDuplicata.vCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                                        fDuplicata.vNm_clifor = (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor;
                                        fDuplicata.vCd_endereco = (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco;
                                        fDuplicata.vDs_endereco = (BS_Pedido.Current as TRegistro_Pedido).DS_Endereco;
                                        fDuplicata.vCd_condpgto = (BS_Pedido.Current as TRegistro_Pedido).CD_CondPGTO;
                                        fDuplicata.vDs_condpgto = (BS_Pedido.Current as TRegistro_Pedido).DS_CondPgto;
                                        fDuplicata.vCd_moeda = (BS_Pedido.Current as TRegistro_Pedido).Cd_moeda;
                                        fDuplicata.vDs_moeda = (BS_Pedido.Current as TRegistro_Pedido).Ds_moeda;
                                        fDuplicata.vTp_mov = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Equals("E") ? "P" : "R";
                                        fDuplicata.vVl_documento = (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido - vl_pedidoanterior;
                                        fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                        fDuplicata.vNr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                                        fDuplicata.vSt_finPed = true;
                                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        {
                                            (BS_Pedido.Current as TRegistro_Pedido).lDup.Add(
                                                                        fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar Financeiro para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                else if ((BS_Pedido.Current as TRegistro_Pedido).lDup.Count > 0 &&
                                    (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido < vl_pedidoanterior)
                                {
                                    (BS_Pedido.Current as TRegistro_Pedido).lAdiant.Add(
                                        new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento()
                                        {
                                            Cd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                            Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                            CD_Endereco = (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
                                            Ds_adto = "CREDITO RECEBIDO PEDIDO Nº" + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido,
                                            Tp_movimento = "R",
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Vl_adto = vl_pedidoanterior - (BS_Pedido.Current as TRegistro_Pedido).Vl_totalpedido_liquido,
                                            ST_ADTO = "A",
                                            TP_Lancto = "F",//Financeiro
                                        });
                                }
                            }
                            try
                            {
                                TCN_Pedido.AlterarItemPedido(BS_Pedido.Current as TRegistro_Pedido, null);
                                this.Busca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
        }

        private void bb_inserirAcessorios_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                using (TFAcessorioItem fItem = new TFAcessorioItem())
                {
                    fItem.pCd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                    if (fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rAcessorio != null)
                            try
                            {
                                if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p => p.Cd_produto.Equals(fItem.rAcessorio.Cd_produto)))
                                {
                                    MessageBox.Show("Não é possível inserir produtos existentes nos itens do pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fItem.rAcessorio.Nr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;
                                TCN_AcessoriosPed.Gravar(fItem.rAcessorio, null);
                                MessageBox.Show("Item adicionado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcItens_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_excluirAcessorios_Click(object sender, EventArgs e)
        {
            if (bsAcessoriosItem.Current != null)
                if (MessageBox.Show("Confirma a exclusão do acessório?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_AcessoriosPed.Excluir(bsAcessoriosItem.Current as TRegistro_AcessoriosPed, null);
                        MessageBox.Show("Acessório excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcItens_SelectedIndexChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_representante, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { cd_representante }, vParam);
        }

        private void cd_representante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_representante.Text.Trim() + "';isnull(a.st_representante, 'N')|=|'S'",
                new EditDefault[] { cd_representante }, new TCD_CadClifor());
        }

        private void lblAnexo_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).Anexo_compra != null)
                {
                    string nome_arquivo = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
                    System.IO.File.WriteAllBytes(nome_arquivo, (BS_Pedido.Current as TRegistro_Pedido).Anexo_compra);
                    System.Diagnostics.Process.Start(nome_arquivo);
                }
        }

        private void bbGrupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;a.cd_grupo|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'", new EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void btn_devolver_Click(object sender, EventArgs e)
        {
            TGerarDevolucaoNF.DevolverNF(bsNotaFiscal.Current as TRegistro_LanFaturamento);
        }

        private void duplicarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duplica();
        }

        private void devolverItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FDevItemPedido fDev = new FDevItemPedido())
            {
                if (BS_Pedido.Current != null)
                    fDev.NrPedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido;

                fDev.ShowDialog();
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Ds_CategoriaCliFor|Descrição Clifor|200;a.Id_CategoriaCliFor|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { edtCategoria }, new TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void edtCategoria_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.Id_CategoriaCliFor|=|'" + edtCategoria.Text.Trim() + "'", new EditDefault[] { edtCategoria }, new TCD_CadCategoriaCliFor());
        }
    }
}




