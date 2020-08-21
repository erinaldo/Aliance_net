using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using System.IO;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Restaurante.Integracao.Torneiras;
using CamadaDados.Estoque.Cadastros;

namespace Restaurante
{
    public partial class TFFechaCartao : Form
    {
        private bool St_ReprocessaFin = false;
        public CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg { get; set; }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private CamadaDados.Faturamento.PDV.TList_Sessao lSessao { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv { get; set; }
        private CamadaDados.Financeiro.Cadastros.TList_CadPortador lPortador { get; set; }
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa { get; set; }
        private bool Altera_Relatorio = false;
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant { get; set; }
        private TList_CFG lCfgRes { get; set; }
        public string LoginPdv { get; set; }
        /// <summary>
        /// tm_standby, foco em nr_cartao, bindingsource vazios
        /// </summary>
        private enum TTpModoRes { tm_Standby, tm_Insert, tm_Edit, tm_busca };
        private TTpModoRes tpModo = new TTpModoRes();

        #region Métodos

        public TFFechaCartao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            //Validar movimentação em aberto para cada cartão informado
            bool bMov = false;
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p =>
            {
                DataTable rMov = new TCD_MovBoliche().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + p.id_cartao + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Fechamento",
                                vOperador = "",
                                vVL_Busca = "is null"
                            }
                    }, 1);
                if (rMov.Rows.Count > 0)
                    bMov = true;
            });
            if (bMov)
            {
                MessageBox.Show("Cartão possui movimentação de serviços em aberto, não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Remover da listagem cartões sem itens e fechar automaticamente
            atualizarBindingSource();
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p =>
            {
                if (p.valor_cartao.Equals(0))
                {
                    p.St_registro = "F";
                    TCN_Cartao.Gravar(p, null);
                    MessageBox.Show("O Cartão de número " + p.nr_card + " informado não possui itens, fechado automaticamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizarBindingSource();
                }
            });

            if (bsCartaoAberto.Current == null || bsCartaoAberto.List.Count.Equals(0)
                || bsPrevenda.Current == null || bsPrevenda.List.Count.Equals(0)
                    || bsItens.Current == null || bsItens.List.Count.Equals(0)) return;

            CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
            rVenda.st_restaurante = true;
            (bsPrevenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
            {
                if (p.st_agregar)
                {
                    CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item item = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                    item.Cd_produto = p.cd_produto;
                    item.Quantidade = p.quantidade_agregar;
                    item.Vl_unitario = p.vl_unitario;
                    item.Vl_subtotal = p.quantidade_agregar * p.vl_unitario;
                    item.id_item = Convert.ToDecimal(p.id_item);
                    item.id_prevenda = Convert.ToDecimal(p.id_prevenda);
                    item.Cd_condfiscal_produto = p.cd_condfiscal_produto;
                    rVenda.lItem.Add(item);
                }
            });

            //Validar fechamento de cartão com unico clifor
            bool unicoClifor = false;
            unicoClifor = bsCartaoAberto.Count.Equals(1);
            rVenda.rCliente = new TCD_CadClifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = unicoClifor ? (bsCartaoAberto.Current as TRegistro_Cartao).Cd_Clifor : lCfgRes[0].Cd_Clifor
                    }
                }, 1, string.Empty)[0];
            rVenda.rEndCli = new TCD_CadEndereco().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = unicoClifor ? (bsCartaoAberto.Current as TRegistro_Cartao).Cd_Clifor : lCfgRes[0].Cd_Clifor
                    }
                }, 1, string.Empty)[0];

            rVenda.Cd_clifor = rVenda.rCliente.Cd_clifor;
            rVenda.Cd_empresa = lCfgRes[0].cd_empresa;
            rVenda.Nm_clifor = rVenda.rCliente.Nm_clifor;
            rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
            rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
            object cd_end = new TCD_CadEndereco().BuscarEscalar(
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

            TList_CadPortador lDevolCred = new TList_CadPortador();
            if (lAdiant.Count > 0)
            {
                //Buscar portador Dev Credito
                lDevolCred =
                    new TCD_CadPortador().Select(
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
                fFechar.lPdv = lPdv;
                fFechar.LoginPDV = LoginPdv;
                fFechar.pRb_Valor = true;

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

                fFechar.pVl_receber = decimal.Parse(subtotal.Text) - rVenda.Vl_devcred;
                if (fFechar.ShowDialog() == DialogResult.OK)
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
                else
                {
                    MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                    return;
                }
            }
            try
            {
                vl_troco.Text = rVenda.lPortador.Sum(p => p.Vl_trocoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                this.FecharVenda(rVenda, null);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            controlarModos(TTpModoRes.tm_Standby);
        }

        private void FecharVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda, ThreadEspera tEspera)
        {
            //Fechar Cartão
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p => TCN_Cartao.FecharCartao(p, rVenda, tEspera, null));

            //Busca cupom gravado
            CamadaDados.Faturamento.PDV.TList_VendaRapida lCupom =
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
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
            lCupom[0].lPortador = rVenda.lPortador;

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


            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCredito =
                new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
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

            //Imprimir comprovante de credito
            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
            {
                if (lCredito.Count > 0)
                {
                    FileInfo f = null;
                    StreamWriter w = null;
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Credito.txt");
                    w = f.CreateText();
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
                                        "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
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
                        bs.DataSource = new CamadaDados.Faturamento.PDV.TList_VendaRapida() { lCupom[0] };
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
                        TRegistro_CadClifor rClifor = TCN_CadClifor.Busca_Clifor_Codigo(lParc[0].Cd_clifor, null);
                        //Buscar Endereco Duplicata
                        TList_CadEndereco lEnd = TCN_CadEndereco.Buscar(lParc[0].Cd_clifor,
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
                        List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPag = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
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
                            Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(rVenda.Cd_clifor,
                                                                                          rVenda.Cd_endereco,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          lCfg[0],
                                                                                          rVenda.lItem,
                                                                                          ref rPedProduto,
                                                                                          ref rPedServico);
                            if (rPedProduto != null)
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                //Buscar pedido
                                rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                //Se o CMI do pedido gerar financeiro
                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
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
                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
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
                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
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
                    else
                    {
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
                                dados.lPortador = new List<TRegistro_CadPortador>();
                                dados.St_vendacombustivel = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = false;

                                PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, dados.St_pedirCliente);
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
                                                this.ProcessarCFVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
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
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
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
                            MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                if (fDoc.DialogResult == DialogResult.Cancel)
                {
                    try
                    {
                        if (lCupom.Count > 0)
                        {
                            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                                return;
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                            {
                                if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                    throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirReduzido(lCupom[0], lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                                this.ImprimirGraficoReduzido(lCupom[0]);
                            else
                                this.ImprimirGrafico(lCupom[0]);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
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
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                BinEndereco.DataSource = TCN_CadEndereco.Buscar(val.Cd_clifor,
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

            //Adiciona na observação os cartões
            if (bsCartaoAberto.Count > 0) val.Ds_observacao = "CARTÃO: ";
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p =>
            {
                val.Ds_observacao += p.nr_card + ", ";
            });

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
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                BinEndereco.DataSource = TCN_CadEndereco.Buscar(val.Cd_clifor,
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

        private void fquantidade()
        {
            if (bsItens.Current == null || bsItens.Count.Equals(0)) return;

            //Validar se item corrente foi adicionado no fechamento
            if (!(bsItens.Current as TRegistro_PreVenda_Item).obsItem.Equals("Adicionado no fechamento"))
            {
                MessageBox.Show("Não é possível alterar quantidade ou excluir itens consumados. Caso seja necessário, dar desconto no fechamento da pré-venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            //Validar se item corrente é boliche
            if (TCN_CFG.Buscar((bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horaboliche) && (bsItens.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horaboliche)))
            {
                MessageBox.Show("O item selecionado é referente a uma movimentação de pista boliche. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Validar se item corrente é sinuca
            if (TCN_CFG.Buscar((bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horasinuca) && (bsItens.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horasinuca)))
            {
                MessageBox.Show("O item selecionado é referente a uma movimentação de sinuca. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((bsItens.Current as TRegistro_PreVenda_Item).st_agregar)
            {
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Text = "Quantidade";
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > decimal.Zero)
                        {
                            (bsItens.Current as TRegistro_PreVenda_Item).quantidade_agregar =
                                (bsItens.Current as TRegistro_PreVenda_Item).quantidade =
                                    fQtd.Quantidade;
                            (bsItens.Current as TRegistro_PreVenda_Item).vl_subtotal =
                                decimal.Multiply((bsItens.Current as TRegistro_PreVenda_Item).quantidade_agregar, (bsItens.Current as TRegistro_PreVenda_Item).vl_unitario);
                            TCN_PreVenda_Item.Gravar((bsItens.Current as TRegistro_PreVenda_Item), null);
                            atualizarBindingSource();
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar quantidade maior do que zero.!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
            }
        }

        private void busca_cartao()
        {
            //Validar existencia de cartao informado na listagem
            bool stop = false;
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p =>
            {
                decimal i = decimal.Parse(p.nr_card);
                if (i == decimal.Parse(nr_cartao.Text.SoNumero().Trim()))
                    stop = true;
            });
            if (stop) return;

            //Buscar cartao informado
            TpBusca[] filtroo = new TpBusca[0];
            if (!string.IsNullOrEmpty(nr_cartao.Text.SoNumero().Trim()))
            {
                Array.Resize(ref filtroo, filtroo.Length + 1);
                filtroo[filtroo.Length - 1].vNM_Campo = "a.nr_cartao";
                filtroo[filtroo.Length - 1].vOperador = "=";
                filtroo[filtroo.Length - 1].vVL_Busca = nr_cartao.Text;
                Array.Resize(ref filtroo, filtroo.Length + 1);
                filtroo[filtroo.Length - 1].vNM_Campo = "a.st_registro";
                filtroo[filtroo.Length - 1].vOperador = "=";
                filtroo[filtroo.Length - 1].vVL_Busca = "'A'";
            }
            TList_Cartao cartao = new TCD_Cartao().Select(filtroo, 1, string.Empty, string.Empty);

            if (cartao.Count > 0)
            {
                bsCartaoAberto.Add(cartao[0]);
                //Informativo
                DataTable rMov = new TCD_MovBoliche().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + cartao[0].id_cartao + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Fechamento",
                                vOperador = "",
                                vVL_Busca = "is null"
                            }
                    }, 1);
                if (rMov.Rows.Count > 0) MessageBox.Show("Cartão informado possui movimentação em aberto.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizarBindingSource();
            }
            else
            {
                MessageBox.Show("Cartão informado não está ativo no sistema.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CalcularTroco(string portador)
        {
            /*vl_pago.Text = lPortador.Sum(p => p.Vl_pagtoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (vl_receber.Value >= vl_pago.Value)
                vl_saldo.Text = Math.Abs(Convert.ToDecimal(subtotal.Text) - lPortador.Sum(p => p.Vl_pagtoPDV)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            if (Math.Round(Convert.ToDecimal(subtotal.Text), 2) < Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2))
            {
                // LabelSaldo.Text = "Valor Troco";
                if (portador.ToUpper().Equals("CH"))
                    lPortador.Find(p => p.St_controletitulobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                else if (portador.ToUpper().Equals("CC") || portador.ToUpper().Equals("CD"))
                    lPortador.Find(p => p.St_cartaocreditobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                else if (portador.ToUpper().Equals("DU"))
                    lPortador.Find(p => p.Tp_portadorpdv.Equals("P")).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                else if (portador.ToUpper().Equals("DV"))
                    lPortador.Find(p => p.St_devcreditobool).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                else
                {
                    if (lPortador.Count > 0)
                        lPortador[0].Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                    //lPortador.Find(p => !p.St_devcreditobool &&
                    //                                !p.St_entregafuturabool &&
                    //                                !p.St_controletitulobool &&
                    //                                !p.St_cartaocreditobool &&
                    //                                !p.St_cartafretebool &&
                    //                                !p.Tp_portadorpdv.Equals("P")).Vl_trocoPDV = Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2);
                }
            }
            if (Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV) - Convert.ToDecimal(subtotal.Text), 2) > 0)
                this.AbrirGavetaDinheiro();
                */
        }

        private void AbrirGavetaDinheiro()
        {
            if (lPdv != null)
                if (lPdv.Count > 0)
                    if (lPdv[0].St_gavetadinheirobool)
                    {
                        //Buscar porta comunicacao
                        object obj_porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lPdv[0].Cd_terminal.Trim() + "'"
                                                }
                                            }, "a.porta_imptick");
                        if (obj_porta != null)
                            try
                            {
                                Utils.TGavetaDinheiro.AbrirGaveta(obj_porta.ToString(), lPdv[0].CMD_Abrirgaveta);
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro executar comando: " + ex.Message.Trim()); }
                        else MessageBox.Show("Terminal " + lPdv[0].Cd_terminal.Trim() + "-" + lPdv[0].Ds_terminal.Trim() + " não tem porta comunicação configurada.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
        }

        private void ConfirmarFin()
        {
            if ((Math.Round((Convert.ToDecimal(subtotal.Text)), 2) > Math.Round(lPortador.Sum(p => p.Vl_pagtoPDV), 2)))
                return;
            if (this.St_ReprocessaFin)//Se for reprocessamento, levar em consideracao o troco
            {
                //if (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) < Convert.ToDecimal(subtotal.Text))
                //    lPortador.FindLast(p => p.Vl_pagtoPDV > decimal.Zero).Vl_trocoPDV = Convert.ToDecimal(subtotal.Text) - (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - this.pVl_outrosrec);
            }
            //if (rCupom != null)
            //    if (pTot_desconto > decimal.Zero)
            //        CamadaNegocio.Faturamento.PDV.TCN_CupomFiscal.RatearDescontoVRapida(rCupom, pTot_desconto, decimal.Zero);
            //this.DialogResult = DialogResult.OK;
        }

        private void excluirCartao()
        {
            if (bsCartaoAberto.Current != null)
            {
                if (MessageBox.Show("Deseja Remover cartão?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TList_PreVenda_Item itens = new TList_PreVenda_Item();
                    (bsPrevenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                    {
                        itens.Add(p);
                    });

                    (bsPrevenda.Current as TRegistro_PreVenda).lItens.Clear();
                    itens.ForEach(p =>
                    {
                        if (!p.id_cartao.Equals((bsCartaoAberto.Current as TRegistro_Cartao).id_cartao))
                            (bsPrevenda.Current as TRegistro_PreVenda).lItens.Add(p);
                    });

                    if ((bsPrevenda.Current as TRegistro_PreVenda).lItens.Count <= itens.Count)
                    {
                        string id = (bsCartaoAberto.Current as TRegistro_Cartao).nr_cartao;
                        bsCartaoAberto.RemoveCurrent();

                        TList_Cartao lcard = new TList_Cartao();

                    }
                    atualizarBindingSource();
                }
            }
            else
                controlarModos(tpModo);
        }

        private void novoProduto()
        {
            if (bsCartaoAberto.Current == null) return;

            TRegistro_CadProduto rProduto = UtilPesquisa.BuscarProduto(string.Empty,
                                                                       lCfgRes[0].cd_empresa,
                                                                       string.Empty,
                                                                       lCfgRes[0].cd_tabelapreco,
                                                                       null,
                                                                       null);
            if (rProduto == null)
            {
                MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            object id_prevenda = new TCD_PreVenda().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.id_cartao", vOperador = "=", vVL_Busca = (bsCartaoAberto.Current as TRegistro_Cartao).id_cartao.ToString() } }, "a.id_prevenda");
            if (id_prevenda == null || string.IsNullOrEmpty(id_prevenda.ToString())) return;
            TCN_PreVenda_Item.Gravar(new TRegistro_PreVenda_Item()
            {
                Cd_empresa = (bsCartaoAberto.Current as TRegistro_Cartao).Cd_empresa,
                id_prevenda = decimal.Parse(id_prevenda.ToString()),
                cd_produto = rProduto.CD_Produto,
                quantidade = 1,
                vl_unitario = rProduto.Vl_precovenda,
                St_impresso = "N",
                st_registro = "A",
                obsItem = "Adicionado no fechamento"
            }, null);
            atualizarBindingSource();
        }

        private void excluirItem()
        {
            if (bsItens.Current == null) return;

            //Validar se item corrente foi Adicionado no fechamento
            if (!(bsItens.Current as TRegistro_PreVenda_Item).obsItem.Equals("Adicionado no fechamento"))
            {
                MessageBox.Show("Não é possível alterar quantidade ou excluir itens consumados. Caso seja necessário, dar desconto no fechamento da pré-venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            //Validar se item corrente é boliche
            if (TCN_CFG.Buscar((bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horaboliche) && (bsItens.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horaboliche)))
            {
                MessageBox.Show("O item selecionado é referente a uma movimentação de pista boliche. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Validar se item corrente é sinuca
            if (TCN_CFG.Buscar((bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa, null).Exists(p => !string.IsNullOrEmpty(p.Cd_horasinuca) && (bsItens.Current as TRegistro_PreVenda_Item).cd_produto.Equals(p.Cd_horasinuca)))
            {
                MessageBox.Show("O item selecionado é referente a uma movimentação de sinuca. Não será possível excluir o registro, é possível anular o valor cobrado dando como desconto no fechamento da venda.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                                vVL_Busca = (bsItens.Current as TRegistro_PreVenda_Item).id_item.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = (bsItens.Current as TRegistro_PreVenda_Item).id_prevenda.ToString()
                            }
                    }, 0, string.Empty);
                adicionais.ForEach(ad =>
                {
                    ad.st_registro = "C";
                    TCN_PreVenda_Item.Excluir(ad, null);
                    ad.st_agregar = true;
                    ad.st_removido = true;
                });

                TList_SaboresItens lista = new TList_SaboresItens();
                lista = TCN_SaboresItens.Buscar((bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa,
                                                (bsItens.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                                                (bsItens.Current as TRegistro_PreVenda_Item).id_item.ToString(),
                                                string.Empty,
                                                null);
                lista.ForEach(ad =>
                {
                    TCN_SaboresItens.Excluir(ad, null);
                });

                (bsItens.Current as TRegistro_PreVenda_Item).st_removido = true;
                (bsItens.Current as TRegistro_PreVenda_Item).st_registro = "C";
                TCN_PreVenda_Item.Excluir(bsItens.Current as TRegistro_PreVenda_Item, null);
                atualizarBindingSource();
            }
        }

        private void controlarModos(TTpModoRes modoRes)
        {
            if (modoRes.Equals(TTpModoRes.tm_Standby))
            {
                lblCliente.Text = "";
                lblNCartao.Text = "";
                lblVlCartao.Text = "";
                nr_cartao.Text = "";
                subtotal.Text = "";
                lblMovServicos.Visible = false;
                bsCartaoAberto.Clear();
                bsPrevenda.Clear();
                bsItens.Clear();
                bsCartaoAberto.ResetBindings(true);
                bsPrevenda.ResetBindings(true);
                bsItens.ResetBindings(true);
                nr_cartao.Focus();
            }
            tpModo = modoRes;
        }

        private void gerarExtrato()
        {
            TList_Cartao _Cartaos = new TList_Cartao();
            (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(c => _Cartaos.Add(c));
            (bsPrevenda.Current as TRegistro_PreVenda).lItens.ForEach(i =>
            {
                i.lSabores = TCN_SaboresItens.Buscar(i.Cd_empresa, i.id_prevenda.ToString(), i.id_item.ToString(), string.Empty, null);
            });
            Impressao.IMP_Cartao.Impressao_ExtratoComposto((bsPrevenda.Current as TRegistro_PreVenda).lItens, _Cartaos, lPdv[0].Id_pdvstr);
        }

        private decimal ConsultaPreco(string vCd_clifor, string vCd_produto, TRegistro_Cfg rCfg)
        {
            rProg = null;
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                if (!string.IsNullOrEmpty(vCd_clifor))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(rCfg.cd_empresa,
                                                                                                         vCd_clifor,
                                                                                                         vCd_produto,
                                                                                                         rCfg.cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(rCfg.cd_empresa,
                                                                                                    vCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty(rCfg.cd_tabelapreco))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rCfg.cd_empresa,
                                                                                                vCd_produto,
                                                                                                rCfg.cd_tabelapreco,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void atualizarBindingSource()
        {
            if (bsCartaoAberto != null && bsCartaoAberto.List.Count > 0)
            {
                TList_Cartao _Cartaos = new TList_Cartao();
                (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(c => _Cartaos.Add(c));
                bsCartaoAberto.Clear();

                if (bsPrevenda.Current == null) bsPrevenda.AddNew(); else { bsPrevenda.Clear(); bsItens.Clear(); }

                _Cartaos.RemoveAll(p => p.St_registro.Equals("F"));
                if (_Cartaos.Count.Equals(0)) { controlarModos(tpModo); }

                _Cartaos.ForEach(c =>
                {
                    TCN_Cartao.Buscar(c.Cd_empresa, c.id_cartao.ToString(), c.nr_card, c.Cd_Clifor, string.Empty, string.Empty, c.St_registro, string.Empty, string.Empty, null).ForEach(p => bsCartaoAberto.Add(p));
                });

                //Buscar itens do cartao informado
                (bsCartaoAberto.List as IEnumerable<TRegistro_Cartao>).ToList().ForEach(p =>
                {
                    //Para configuração PathDbTorneira (integracao)
                    TList_CFG lCfg = new TCD_CFG().Select(null, 1, string.Empty);
                    if (lCfg.Count == 0 ? false : !string.IsNullOrEmpty(lCfg[0].PathBdTorneira))
                    {
                        try
                        {
                            List<TRegistro_TapTransactions> _ListTapTran = new ServiceRest.TCD_TapTransactions().Buscar(lCfg[0].PathBdTorneira,
                                                                                                                        p.nr_cartao,
                                                                                                                        0,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty);

                            _ListTapTran.ForEach(x =>
                            {
                                if (string.IsNullOrEmpty(x.cdProduto))
                                    throw new Exception("Erro na importação dos consumos. Existe torneira sem produto configurado.");

                                TpBusca[] tps = new TpBusca[0];
                                Estruturas.CriarParametro(ref tps, "a.cd_produto", x.cdProduto);
                                TRegistro_CadProduto _CadProduto = new TCD_CadProduto().Select(tps, 0, string.Empty, string.Empty, string.Empty)[0];

                                TRegistro_PreVenda_Item rItemIntegrado = new TRegistro_PreVenda_Item();
                                rItemIntegrado.Cd_empresa = p.Cd_empresa;
                                rItemIntegrado.cd_produto = _CadProduto.CD_Produto;
                                rItemIntegrado.ds_produto = _CadProduto.DS_Produto;
                                rItemIntegrado.quantidade = Math.Round(decimal.Divide(x.volumeAmount, 1000), 3, MidpointRounding.AwayFromZero); //unidade em litros
                                rItemIntegrado.vl_unitario = ConsultaPreco(p.Cd_Clifor, _CadProduto.CD_Produto, lCfg[0]);
                                if (rItemIntegrado.vl_unitario.Equals(decimal.Zero))
                                    rItemIntegrado.vl_unitario = Math.Round(decimal.Divide(decimal.Divide(x.moneyAmount, 100), rItemIntegrado.quantidade), 2, MidpointRounding.AwayFromZero);
                                rItemIntegrado.tapTransactions = x;
                                //Gravar item na venda
                                object obj = new TCD_PreVenda().BuscarEscalar(new TpBusca[]
                                                {
                                                    new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + p.Cd_empresa.Trim() + "'" },
                                                    new TpBusca{ vNM_Campo = "a.id_cartao", vOperador = "=", vVL_Busca = p.id_cartao.ToString() }
                                                }, "a.id_prevenda");
                                if (obj != null)
                                {
                                    rItemIntegrado.id_prevenda = Convert.ToDecimal(obj);
                                    TCN_PreVenda_Item.Gravar(rItemIntegrado, null);
                                    new ServiceRest.TCD_TapTransactions().Update(x, lCfg[0].PathBdTorneira);
                                }
                            });
                        }
                        catch
                        {
                            MessageBox.Show("Erro ler banco dados torneira.\r\nVerifique mapeamento do banco dados.");
                            return;
                        }
                    }
                    TList_PreVenda_Item itens = new TList_PreVenda_Item();
                    TpBusca[] filtro = new TpBusca[0];
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "e.id_cartao";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = p.id_cartao.ToString();
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'A'";
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.qtd_faturar";
                    filtro[filtro.Length - 1].vOperador = ">";
                    filtro[filtro.Length - 1].vVL_Busca = "0";

                    itens = new TCD_PreVenda_Item().Select(filtro, 0, string.Empty);
                    if (itens.Count > decimal.Zero)
                    {
                        if (bsPrevenda.Current == null) bsPrevenda.AddNew();
                        itens.ForEach(i =>
                        {
                            i.st_agregar = true;
                            i.quantidade_agregar = i.qtd_faturar;
                            (bsPrevenda.Current as TRegistro_PreVenda).lItens.Add(i);
                        });
                    }
                    //
                });

                //Calcular total
                decimal total = decimal.Zero;
                if (bsPrevenda.Current == null) bsPrevenda.AddNew();
                (bsPrevenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
                {
                    if (p.st_agregar)
                        total += p.quantidade_agregar * p.vl_unitario;
                });

                bsCartaoAberto.ResetBindings(true);
                bsPrevenda.ResetBindings(true);
                bsItens.ResetBindings(true);


                subtotal.Text = total.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
            else controlarModos(tpModo);
        }

        private void consultaPedido()
        {
            if (tpModo.Equals(TTpModoRes.tm_Standby))
                using (TFConsultaCartao fConsulta = new TFConsultaCartao())
                    fConsulta.ShowDialog();
        }

        private void novoCliente()
        {
            using (Cadastro.TFCliforDetalhado fClifor = new Cadastro.TFCliforDetalhado())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                {
                    TCN_CliFor.Gravar(fClifor.rClifor, null);
                    if (bsCartaoAberto.Current != null)
                    {
                        if (MessageBox.Show("Deseja relacionar o novo cliente cadastrado ao cartão corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            (bsCartaoAberto.Current as TRegistro_Cartao).Cd_Clifor = fClifor.rClifor.Cd_clifor;
                            TCN_Cartao.Gravar((bsCartaoAberto.Current as TRegistro_Cartao), null);
                            atualizarBindingSource();
                        }
                    }
                }
            }
        }

        private void alterarCliente()
        {
            if (bsCartaoAberto.Current == null)
                return;

            using (TFConsultaClifor fConsulta = new TFConsultaClifor())
            {
                if (fConsulta.ShowDialog() == DialogResult.OK)
                {
                    (bsCartaoAberto.Current as TRegistro_Cartao).Cd_Clifor = fConsulta.rClifor.Cd_clifor;
                    TCN_Cartao.Gravar((bsCartaoAberto.Current as TRegistro_Cartao), null);
                    atualizarBindingSource();
                }
            }
        }

        #endregion

        #region Eventos

        private void FFechaCartao_Load(object sender, EventArgs e)
        {
            controlarModos(TTpModoRes.tm_Standby);

            //Timer da hora e data
            timer1.Enabled = true;
            timer1.Interval = 1000;

            if (string.IsNullOrEmpty(LoginPdv))
                LoginPdv = Utils.Parametros.pubLogin;

            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count.Equals(0))
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            lblOperador.Text = Utils.Parametros.pubLogin;
            lblPdv.Text = lPdv[0].Ds_pdv;

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
            if (lSessao.Count.Equals(0))
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
            //afterbusca();
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(string.Empty, null);
            lCfgRes = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            if (lCfgRes.Count.Equals(0)) { MessageBox.Show("Não existe CFG. Restaurante cadastrado para empresa. Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            lPortador = CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(lCfg[0].Cd_empresa,
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  false,
                                                                                  false,
                                                                                  "'A', 'P'",
                                                                                  0,
                                                                                  string.Empty,
                                                                                  "ordem",
                                                                                  null);
            pnNCartao.set_FormatZero();
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as TRegistro_PreVenda_Item).st_agregar =
                    !(bsItens.Current as TRegistro_PreVenda_Item).st_agregar;
                fquantidade();
            }
            else if (e.ColumnIndex == 1)
            {
                fquantidade();
            }
        }

        private void FFechaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                nr_cartao.Text = string.Empty;
                nr_cartao.Focus();
            }
            else if (e.KeyCode.Equals(Keys.F2))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                excluirCartao();
            else if (e.KeyCode.Equals(Keys.F7))
                fquantidade();
            else if (e.KeyCode.Equals(Keys.F6))
                novoProduto();
            else if (e.KeyCode.Equals(Keys.Escape))
                controlarModos(tpModo);
            else if (e.KeyCode.Equals(Keys.F8))
                excluirItem();
            else if (e.KeyCode.Equals(Keys.F10))
                gerarExtrato();
            else if (e.KeyCode.Equals(Keys.F9))
                consultaPedido();
            else if (e.KeyCode.Equals(Keys.F12))
                alterarCliente();
            else if (e.KeyCode.Equals(Keys.F11))
                novoCliente();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = !Altera_Relatorio;
                MessageBox.Show("Atalho alterar relatório: " + Altera_Relatorio);
            }
        }

        private void nr_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrEmpty(nr_cartao.Text)) return;

                busca_cartao();
                nr_cartao.Text = string.Empty;
                vl_troco.Text = string.Empty;
            }
        }

        private void FFechaCartao_ForeColorChanged(object sender, EventArgs e)
        {
            //Encerrar Sessão
            try
            {
                lSessao.ForEach(p => CamadaNegocio.Faturamento.PDV.TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbExcluircartao_Click(object sender, EventArgs e)
        {
            excluirCartao();
        }

        private void nr_cartao_TextChanged(object sender, EventArgs e)
        {
            nr_cartao.Text = nr_cartao.Text.SoNumero().Trim();
        }

        private void bb_sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bsCartaoAberto_PositionChanged(object sender, EventArgs e)
        {
            if (bsCartaoAberto.Current == null) return;

            DataTable rMov = new TCD_MovBoliche().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsCartaoAberto.Current as TRegistro_Cartao).id_cartao + "'"
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
            else
                lblMovServicos.Visible = false;

            //Informativo
            lblCliente.Text = (bsCartaoAberto.Current as TRegistro_Cartao).Nm_Clifor;
            lblNCartao.Text = (bsCartaoAberto.Current as TRegistro_Cartao).nr_card;
            lblVlCartao.Text = (bsCartaoAberto.Current as TRegistro_Cartao).valor_cartao.Equals(0) ? "" : "R$ " + (bsCartaoAberto.Current as TRegistro_Cartao).valor_cartao.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void lblFecharPreVenda_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void lblAlterarQuant_Click(object sender, EventArgs e)
        {
            fquantidade();
        }

        private void lblNovoProduto_Click(object sender, EventArgs e)
        {
            novoProduto();
        }

        private void lblCancelarOperacao_Click(object sender, EventArgs e)
        {
            controlarModos(tpModo);
        }

        private void lblExcluirItem_Click(object sender, EventArgs e)
        {
            excluirItem();
        }

        #endregion

        private void lblGerarExtrato_Click(object sender, EventArgs e)
        {
            gerarExtrato();
        }

        private void lblConsultaPedido_Click(object sender, EventArgs e)
        {
            consultaPedido();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = CamadaDados.UtilData.Data_Servidor().ToString();
        }

        private void BB_AlterarCliente_Click(object sender, EventArgs e)
        {
            alterarCliente();
        }

        private void lblNovoCliente_Click(object sender, EventArgs e)
        {
            novoCliente();
        }

        private void event_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.FixedSingle;
            (sender as Label).Cursor = Cursors.Hand;
            (sender as Label).ForeColor = Color.Blue;
        }

        private void event_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.None;
            (sender as Label).Cursor = Cursors.Default;
            (sender as Label).ForeColor = Color.Green;
        }
    }
}
