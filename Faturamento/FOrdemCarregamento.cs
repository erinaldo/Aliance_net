using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Bloqueto;
using FormRelPadrao;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using Financeiro;
using CamadaDados.Compra;
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFOrdemCarregamento : Form
    {
        private bool Altera_Relatorio = false;
        public TFOrdemCarregamento()
        {
            InitializeComponent();
        }

        private void Busca()
        {
            TpBusca[] filtro = new TpBusca[2];
            //Pedidos Encerrados e fechados
            filtro[0].vNM_Campo = "a.ST_Pedido";
            filtro[0].vOperador = "in";
            filtro[0].vVL_Busca = "('F', 'P')";
            //Buscar somente pedidos de saida
            filtro[1].vNM_Campo = "a.TP_Movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
            if ((dt_inicio.Text.Trim() != string.Empty) && (dt_inicio.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicio.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((dt_fin.Text.Trim() != string.Empty) && (dt_fin.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(CD_Empresa_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa_Busca.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(NR_Pedido_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = NR_Pedido_Busca.Text;
            }
            if (!string.IsNullOrEmpty(CD_Clifor_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor_Busca.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CFG_Pedido_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CFG_Pedido_Busca.Text.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_cfgpedido x " +
                                                      "where x.cfg_pedido = a.cfg_pedido " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(Cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Pedido_Itens x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_produto = '" + Cd_produto.Text.Trim() + "')";
            }
            if (st_carregar.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Pedido_Itens x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and isnull(x.quantidade, 0) - isnull((select count(*)  " +
				                                                 "from TB_FAT_ItensCarregamento y  " +
				                                                 "where  x.nr_pedido = y.nr_pedido  " +
				                                                 "and x.cd_produto = y.cd_produto  " +
                                                                 "and x.id_pedidoitem = y.id_pedidoitem), 0) > 0) ";
            }

            BS_Pedido.DataSource = new TCD_Pedido().Select(filtro, 0, string.Empty);
            bs_pedido_PositionChanged(this, new EventArgs());
        }

        private void faturarPedido(string Tp_nf)
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    //Verificar se o tipo de pedido exige conferencia
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
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
                            obj = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().BuscarEscalar(
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
                    obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                },
                                new Utils.TpBusca()
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
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(BS_Pedido.Current as TRegistro_Pedido, false, decimal.Zero);
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            if (MessageBox.Show("Pedido Faturado com Sucesso.\r\nDeseja imprimir as notas fiscais?\r\n" +
                                    "Obs.: Somente serão impressas as notas fiscais proprias e que não sejam NF-e.", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                            {
                                rFat = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                     rFat.Nr_notafiscalstr,
                                                                                                     rFat.Nr_serie,
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
                                                                                                     null)[0];
                                if (rFat.Tp_nota.Trim().ToUpper().Equals("P") && (!rFat.Cd_modelo.Trim().Equals("55")))
                                    //Chamar tela de impressao para a nota fiscal
                                    //somente se for nota propria
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                        fImp.pMensagem = "NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rFat,
                                                                                            fImp.pSt_imprimir,
                                                                                            fImp.pSt_visualizar,
                                                                                            fImp.pSt_enviaremail,
                                                                                            fImp.pDestinatarios,
                                                                                            "NOTA FISCAL Nº " + rFat.Nr_notafiscal.ToString(),
                                                                                            fImp.pDs_mensagem);
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
                                        this.encerrarPedido();
                            this.LimparFiltros();
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
                                            this.encerrarPedido();
                            }
                            this.LimparFiltros();
                            NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            Busca();
                        }
                    }
                }
                else
                    MessageBox.Show("É permitido faturar somente pedido fechado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void encerrarPedido()
        {
            try
            {
                (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "P";
                (BS_Pedido.Current as TRegistro_Pedido).ST_Registro = "P";
                TRegistro_Pedido rPed = BS_Pedido.Current as TRegistro_Pedido;
                TCN_Pedido.Grava_Pedido(BS_Pedido.Current as TRegistro_Pedido, null);
                this.LimparFiltros();
                NR_Pedido_Busca.Text = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                Busca();
                MessageBox.Show("Pedido ENCERRADO com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao Encerrao o Pedido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Imprime_Danfe()
        {
            FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
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
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
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
                                                        "and y.cd_empresa = '" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                lParc =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new Utils.TpBusca()
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
                                                            "and z.cd_empresa = '" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count == 0)
                {
                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                    lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new Utils.TpBusca()
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
                                                            "and z.cd_empresa = '" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
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
                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }

        private void LimparFiltros()
        {
            NR_Pedido_Busca.Clear();
            CD_Empresa_Busca.Clear();
            NR_Pedido_Busca.Clear();
            CD_Clifor_Busca.Clear();
            Cd_produto.Clear();
            CFG_Pedido_Busca.Clear();
            dt_inicio.Clear();
            dt_fin.Clear();
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

        private void bs_pedido_PositionChanged(object sender, EventArgs e)
        {
            //bsOrdemProducao.Clear();
            if (BS_Pedido.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido > 0)
                {
                    //Buscar Expedições do Pedido
                    (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lExpedicao =
                    new CamadaDados.Faturamento.Pedido.TCD_Expedicao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and x.nr_pedido = " + (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido + ") "
                            }
                        }, 0, string.Empty);
                    BS_Pedido.ResetCurrentItem();
                    bsExpedicao_PositionChanged(this, new EventArgs());
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

                    tabControl1_SelectedIndexChanged(this, new EventArgs());
                    BS_Pedido.ResetCurrentItem();

                    //Buscar Parcelas Pedido
                    (BS_Pedido.Current as TRegistro_Pedido).lParc = 
                       new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_empresa = '" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "' " +
                                                "and x.nr_pedido = '" + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + "')"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);
                    bsParcelas.ResetCurrentItem();

                    (BS_Pedido.Current as TRegistro_Pedido).lEtapa =
                       CamadaNegocio.Faturamento.Pedido.TCN_EtapaPedido.Busca(string.Empty,
                                                                              (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                              null);

                    bsEtapa.ResetCurrentItem();
                    bsOrdem.ResetCurrentItem();
                    
                    bsProcessos_PositionChanged(this, new EventArgs());
                    BS_Pedido.ResetCurrentItem();
                }

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                if (tcCentral.SelectedTab.Equals(tpNotaFiscal))
                    (BS_Pedido.Current as TRegistro_Pedido).lNotaFiscal =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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

                BS_Pedido.ResetCurrentItem();
            }
        }

        private void btn_CFG_Pedido_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void btn_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa_Busca }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_produto }, string.Empty);
        }

        private void CFG_Pedido_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido_Busca.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void Cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void FOrdemCarregamento_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFOrdemCarregamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                Busca();
            else if ((e.Control) && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void bb_visualizar_dup_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                blListaTitulo lista = TCN_Titulo.Buscar(string.Empty,
                                                   decimal.Parse((bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Nr_lanctostr),
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty, string.Empty, 
                                                   false, 1, null);


                dsBloqueto.DataSource = lista;
            }
            else
            {
                return;
            }



             if (dsBloqueto.Current != null)
             {
                 if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                 {
                     MessageBox.Show("Bloqueto encontra-se cancelado. Não sera possivel realizar a compensação do mesmo!", "Mensagem", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                     return;
                 }
                 if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                 {
                     MessageBox.Show("Não é permitido reimprimir bloqueto COMPENSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
                 }
                 if (!Altera_Relatorio)
                 {
                     //Chamar tela de impressao para o bloqueto
                     using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                     {
                         fImp.St_enabled_enviaremail = true;
                         fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                         fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                         if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                             TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                 new blListaTitulo() { dsBloqueto.Current as blTitulo },
                                                                 fImp.pSt_imprimir,
                                                                 fImp.pSt_visualizar,
                                                                 fImp.pSt_enviaremail,
                                                                 fImp.pSt_exportPdf,
                                                                 fImp.Path_exportPdf,
                                                                 fImp.pDestinatarios,
                                                                 "BLOQUETO Nº " + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim(),
                                                                 fImp.pDs_mensagem,
                                                                 false);
                     }
                 }
                 else
                     TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                         new blListaTitulo() { (dsBloqueto.Current as blTitulo) },
                                                         false,
                                                         false,
                                                         false,
                                                         false,
                                                         string.Empty,
                                                         null,
                                                         string.Empty,
                                                         string.Empty,
                                                         false);

                 Altera_Relatorio = false;
             }
             else
             {

                 MessageBox.Show("Não existe boleto desta duplicata","Mensagem", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                 return;

             }
        }

        private void bb_visualizar_nf_Click(object sender, EventArgs e)
        {
            if (bs_NotaFiscal.Current != null)
                if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
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
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }

        private void bsEtapa_PositionChanged(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
                (bsEtapa.Current as CamadaDados.Faturamento.Pedido.TRegistro_EtapaPedido).lProcEtapa =
                    CamadaNegocio.Faturamento.Pedido.TCN_ProcEtapa.Busca(
                    (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapastr,
                    (bsEtapa.Current as TRegistro_EtapaPedido).Nr_pedidostr,
                    string.Empty,
                    null
                    );
            bsEtapa.ResetCurrentItem();

            bsProcessos_PositionChanged(this, new EventArgs());
        }

        private void bsProcessos_PositionChanged(object sender, EventArgs e)
        {
            if (bsProcessos.Current != null)
                (bsProcessos.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).lAnexo =
                    CamadaNegocio.Faturamento.Pedido.TCN_AnexoPedido.Buscar(
                                            (bsProcessos.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Nr_pedidostr,
                                            (bsProcessos.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Id_etapastr,
                                            (bsProcessos.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Id_processostr,
                                            (bsProcessos.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Id_Anexo,
                                            null);
            bsProcessos.ResetCurrentItem();
        }

        private void bb_visualizar_Click(object sender, EventArgs e)
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

        private void bb_imprimirNota_Click(object sender, EventArgs e)
        {
            if (bs_NotaFiscal.Current != null)
                if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
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
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }

        private void bb_gerarOrdem_Click(object sender, EventArgs e)
        {
            //if (BS_Itens.Current != null)
            //{
            //    using (TFGerarOrdemCarregamento fGerar = new TFGerarOrdemCarregamento())
            //    {
            //        fGerar.pCd_empresa = (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Empresa;
            //        fGerar.pCd_clifor = (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Clifor;
            //        fGerar.pCd_endereco = (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Endereco;
            //        fGerar.pVl_frete = (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Vl_frete;
            //        fGerar.rPedido = BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido;
            //        (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedido_Itens.ForEach(p => fGerar.lItem.Add(p));
            //        if (fGerar.ShowDialog() == DialogResult.OK)
            //            if (fGerar.rOrdem.lItens.Count > 0)
            //                try
            //                {
            //                    fGerar.rOrdem.Cd_empresa = (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Empresa;
            //                    CamadaNegocio.Faturamento.Pedido.TCN_OrdemCarregamento.Gravar(fGerar.rOrdem, null);
            //                    MessageBox.Show("Ordem de Carregamento gerada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    bs_pedido_PositionChanged(this, new EventArgs());
            //                    this.bb_ImprimirOrdem_Click(this, new EventArgs());
            //                }
            //                catch (Exception ex)
            //                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //    }
            //}
        }

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            this.faturarPedido("'NO'");
        }

        private void miNfDev_Click(object sender, EventArgs e)
        {
            this.faturarPedido("'DV','DF'");
        }

        private void miNfComplemento_Click(object sender, EventArgs e)
        {
            this.faturarPedido("'CP', 'CF'");
        }

        private void nFEntregaFuturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.faturarPedido("'FT'");
        }

        private void bb_ImprimirOrdem_Click(object sender, EventArgs e)
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
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor + "'"
                            },
                            new Utils.TpBusca()
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
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Clifor,
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
                    (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedido_Itens.ForEach(p =>
                    {
                        if (p.lFichaTec.Count.Equals(0))
                            p.lFichaTec = TCN_FichaTecItemPed.Buscar(p.Nr_PedidoString,
                                               p.Cd_produto,
                                               p.Id_pedidoitem.ToString(),
                                               string.Empty,
                                               null);
                    });


                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "FLan_OrdemCarregamento";
                    Relatorio.NM_Classe = "TFLan_Pedido";
                    Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);

                    TList_Pedido lista_pedido = new TList_Pedido();
                    lista_pedido.Add(pedido);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista_pedido;
                    BindingSource bd_ordem = new BindingSource();
                    bd_ordem.DataSource = new CamadaDados.Faturamento.Pedido.TList_OrdemCarregamento() { bsOrdem.Current as CamadaDados.Faturamento.Pedido.TRegistro_OrdemCarregamento };
                    BS_Pedido.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("ITENS", BS_Itens);
                    Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.Adiciona_DataSource("ORDEMCARREGAMENTO", bd_ordem);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_OrdemCarregamento";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
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

        private void bsExpedicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsExpedicao.Current != null)
            {
                (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).lItens =
                    CamadaNegocio.Faturamento.Pedido.TCN_ItensExpedicao.Busca((bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).Cd_empresa,
                                                                              (bsExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_Expedicao).Id_expedicaostr,
                                                                              string.Empty,
                                                                              null);
                bsExpedicao.ResetCurrentItem();
            }
        }        
    }
}
