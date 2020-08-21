using System;
using System.Drawing;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
using System.IO;
using Utils;

namespace Faturamento
{
    public partial class TFLanFrenteCaixa : Form
    {
        private bool Altera_relatorio = false;
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }

        public TFLanFrenteCaixa()
        {
            InitializeComponent();
        }

        private void IniciarMovimento()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Verificar se existe caixa aberto para o pdv/login
                        if (new TCD_CaixaPDV().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                }
                            }, "1") != null)
                        {
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
                                    vVL_Busca = "'" + fSessao.Usuario.Trim().ToUpper() + "'"
                                }
                            }, "1") == null)
                                TCN_Sessao.AbrirSessao(
                                    new TRegistro_Sessao()
                                    {
                                        Id_pdvstr = lPdv[0].Id_pdvstr,
                                        Login = fSessao.Usuario.Trim()
                                    }, null);
                            using (TFLanVendaRapida fVenda = new TFLanVendaRapida())
                            {
                                fVenda.FormBorderStyle = FormBorderStyle.FixedSingle;
                                fVenda.StartPosition = FormStartPosition.CenterScreen;
                                fVenda.WindowState = FormWindowState.Maximized;
                                fVenda.MaximizeBox = false;
                                fVenda.MinimizeBox = false;
                                fVenda.LoginPdv = fSessao.Usuario;
                                (MdiParent as Form).Visible = false;
                                try
                                {
                                    fVenda.ShowDialog();
                                }
                                finally
                                {
                                    (MdiParent as Form).Visible = true;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Não existe caixa aberto para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar login para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IniciarVendaCombustivel()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Buscar caixa aberto usuario
                        TList_CaixaPDV lCaixa = new TCD_CaixaPDV().SelectCaixaAbertoLogin(fSessao.Usuario.Trim());
                        if (lCaixa.Count > 0)
                        {
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
                                        vVL_Busca = "'" + fSessao.Usuario.Trim().ToUpper() + "'"
                                    }
                                }, "1") == null)
                                TCN_Sessao.AbrirSessao(
                                    new TRegistro_Sessao()
                                    {
                                        Id_pdvstr = lPdv[0].Id_pdvstr,
                                        Login = fSessao.Usuario.Trim()
                                    }, null);
                            //Abrir tela venda combustivel
                            using (PostoCombustivel.TFLanVendaCombustivel fVendaCombustivel = new PostoCombustivel.TFLanVendaCombustivel())
                            {
                                fVendaCombustivel.LoginPdv = fSessao.Usuario;
                                fVendaCombustivel.rCaixa = lCaixa[0];
                                (MdiParent as Form).Visible = false;
                                try
                                {
                                    fVendaCombustivel.ShowDialog();
                                }
                                finally
                                {
                                    (MdiParent as Form).Visible = true;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Não existe caixa aberto para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar login para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IniciarVendaConveniencia()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (new TCD_CaixaPDV().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                }
                            }, "1") != null)
                        {
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
                                        vVL_Busca = "'" + fSessao.Usuario.Trim().ToUpper() + "'"
                                    }
                                }, "1") == null)
                                TCN_Sessao.AbrirSessao(
                                    new TRegistro_Sessao()
                                    {
                                        Id_pdvstr = lPdv[0].Id_pdvstr,
                                        Login = fSessao.Usuario.Trim()
                                    }, null);
                            //Abrir tela venda conveniencia
                            using (PostoCombustivel.TFLanVendaConveniencia fConveniencia = new PostoCombustivel.TFLanVendaConveniencia())
                            {
                                fConveniencia.Cd_empConv = lPdv[0].Cd_empresa;
                                fConveniencia.Login = fSessao.Usuario;
                                //Buscar sessao usuario
                                TList_Sessao lSessao = new TCD_Sessao().Select(
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
                                                                    vVL_Busca = "'" + fSessao.Usuario.Trim().ToUpper() + "'"
                                                                }
                                                        }, 1, string.Empty);
                                if (lSessao.Count > 0)
                                    fConveniencia.rSessao = lSessao[0];
                                else
                                {
                                    MessageBox.Show("Não foi encontrado sessão aberta para o usuario " + fSessao.Usuario.Trim() + " no PDV " + lPdv[0].Id_pdvstr + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Buscar config
                                fConveniencia.lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
                                (MdiParent as Form).Visible = false;
                                try
                                {
                                    fConveniencia.ShowDialog();
                                }
                                finally
                                {
                                    (MdiParent as Form).Visible = true;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Não existe caixa aberto para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar login para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AbrirCaixa()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    //Verificar se existe caixa aberto para o pdv/login
                    if (new TCD_CaixaPDV().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Ja existe caixa aberto para o Usuario " + fSessao.Usuario.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (Proc_Commoditties.TFAbrirCaixaPDV fCaixa = new Proc_Commoditties.TFAbrirCaixaPDV())
                    {
                        fCaixa.pLogin = fSessao.Usuario;
                        if (fCaixa.ShowDialog() == DialogResult.OK)
                            if (fCaixa.rCaixa != null)
                            {
                                try
                                {
                                    TCN_CaixaPDV.AbrirCaixa(fCaixa.rCaixa, null);
                                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                                    Relatorio.Nome_Relatorio = "TFLanFrenteCaixa_AberturaCaixa";
                                    Relatorio.NM_Classe = "TFLanFrenteCaixa_AberturaCaixa";
                                    Relatorio.Modulo = "PDV";
                                    Relatorio.Ident = "TFLanFrenteCaixa_AberturaCaixa";
                                    Relatorio.Altera_Relatorio = Altera_relatorio;

                                    BindingSource BinEmpresa = new BindingSource();
                                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(fCaixa.rCaixa.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        null);
                                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                                    BindingSource meu_bind = new BindingSource();
                                    meu_bind.DataSource = fCaixa.rCaixa;
                                    Relatorio.DTS_Relatorio = meu_bind;


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
                                    Relatorio.ImprimiGraficoReduzida(print,
                                                                        true,
                                                                        false,
                                                                        null,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        1);
                                    Altera_relatorio = false;
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                }
                else
                    MessageBox.Show("Obrigatorio informar usuario para abrir caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FecharCaixa()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    //Verificar se existe caixa aberto para o pdv/login
                    object obj_cx = new CamadaDados.TDataQuery().executarEscalar("select a.id_caixa from tb_pdv_caixa a where a.login = '" + fSessao.Usuario.Trim() + "' and isnull(a.st_registro, 'A') = 'A'", null);
                    
                    if (obj_cx == null ? false : !string.IsNullOrEmpty(obj_cx.ToString()))
                    {
                        //Verificar se existe sessao aberta para o usuario
                        if (new TCD_Sessao().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'F'"
                                            }
                                        }, "1") == null)
                        {
                            TList_CaixaPDV lCaixa = new TCD_CaixaPDV().Select(new TpBusca[] { new TpBusca { vNM_Campo = "a.id_caixa", vOperador = "=", vVL_Busca = obj_cx.ToString() } }, 1, string.Empty);
                            //Verificar se existe venda de combustivel em espera para o login
                            if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginespera",
                                    vOperador = "=",
                                    vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                }
                            }, "1") != null)
                            {
                                MessageBox.Show("Existe venda de combustivel em ESPERA para o login " + fSessao.Usuario.Trim() + ".\r\n" +
                                                "Não é permitido fechar caixa com venda em ESPERA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCaixa[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_encerrantecaixa, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                                }, "1") != null)
                            {
                                MessageBox.Show("Posto exige que seja informado encerrante no fechamento de caixa.\r\n" +
                                                "Fechamento de caixa deve ser realizado pela tela de recebimento de combustivel, menu FISCAL, opção FECHAR CAIXA.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            using (PDV.TFFechaCaixaOperacional fFechar = new PDV.TFFechaCaixaOperacional())
                            {
                                fFechar.Id_caixa = lCaixa[0].Id_caixastr;
                                fFechar.pLogin = fSessao.Usuario;
                                if (fFechar.ShowDialog() == DialogResult.OK)
                                    if (fFechar.lPortador != null)
                                    {
                                        lCaixa[0].lPorFecharCaixa = fFechar.lPortador;
                                        lCaixa[0].Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                                        lCaixa[0].St_registro = "F";
                                        if (lCaixa[0].Vl_transportar.Equals(decimal.Zero))
                                        {
                                            if (lPdv[0].St_fixarvlretidobool)
                                                lCaixa[0].Vl_transportar = lPdv[0].Vl_maxretcaixa;
                                            else
                                                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                                                {
                                                    fQtde.Ds_label = "Vl. Retido Caixa";
                                                    fQtde.Vl_saldo = lPdv[0].Vl_maxretcaixa;
                                                    fQtde.Casas_decimais = 2;
                                                    if (fQtde.ShowDialog() == DialogResult.OK)
                                                        lCaixa[0].Vl_transportar = fQtde.Quantidade;
                                                }
                                        }
                                        try
                                        {
                                            TCN_CaixaPDV.FecharCaixa(lCaixa[0], null);
                                            //Imprimir Extrato Fechamento Caixa
                                            FormRelPadrao.Relatorio extrato = new FormRelPadrao.Relatorio();
                                            extrato.Altera_Relatorio = Altera_relatorio;
                                            extrato.Nome_Relatorio = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                                            extrato.NM_Classe = Name;
                                            extrato.Modulo = "PDV";
                                            extrato.Ident = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                                            BindingSource bs_ab = new BindingSource();
                                            bs_ab.DataSource = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().Select(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vOperador = "exists",
                                                                        vVL_Busca = "(select 1 from VTB_PDV_MovCaixa x where x.id_Cupom = a.Id_Cupom and a.CD_Empresa = x.CD_Empresa "+
                                                                                    " and x.id_caixa = "+ lCaixa[0].Id_caixastr + ")"
                                                                    }
                                                                }, 0, string.Empty, string.Empty);
                                            BindingSource bs_caixa = new BindingSource();
                                            bs_caixa.DataSource = lCaixa;
                                            extrato.Adiciona_DataSource("CAIXA", bs_caixa);
                                            extrato.Adiciona_DataSource("pontos", bs_ab);
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = TCN_FechamentoCaixa.Buscar(lCaixa[0].Id_caixastr,
                                                                                       string.Empty,
                                                                                       "'A'",
                                                                                       null);
                                            extrato.DTS_Relatorio = bs;
                                            //Buscar retiradas a processar
                                            object obj =
                                            new TCD_RetiradaCaixa().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = lCaixa[0].Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                }
                                                }, "isnull(sum(a.Vl_Retirada), 0)");
                                            if (obj != null)
                                                extrato.Parametros_Relatorio.Add("VL_RET_PROCESSAR", decimal.Parse(obj.ToString()));
                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                            {
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pCd_clifor = string.Empty;
                                                fImp.pMensagem = "EXTRATO FECHAMENTO CAIXA OPERACIONAL";

                                                if (Altera_relatorio)
                                                {
                                                    extrato.Gera_Relatorio(string.Empty,
                                                                           fImp.pSt_imprimir,
                                                                           fImp.pSt_visualizar,
                                                                           fImp.pSt_enviaremail,
                                                                           fImp.pSt_exportPdf,
                                                                           fImp.Path_exportPdf,
                                                                           fImp.pDestinatarios,
                                                                           null,
                                                                           "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                                           fImp.pDs_mensagem);
                                                    Altera_relatorio = false;
                                                }
                                                else
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    extrato.Gera_Relatorio(string.Empty,
                                                                           fImp.pSt_imprimir,
                                                                           fImp.pSt_visualizar,
                                                                           fImp.pSt_enviaremail,
                                                                           fImp.pSt_exportPdf,
                                                                           fImp.Path_exportPdf,
                                                                           fImp.pDestinatarios,
                                                                           null,
                                                                           "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                                           fImp.pDs_mensagem);
                                            }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                            }
                        }
                        else
                        {

                           object obj = new TCD_Sessao().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'F'"
                                            }
                                        }, "b.ds_pdv");
                            string pdv = (obj == null || string.IsNullOrEmpty(obj.ToString()) ? string.Empty : obj.ToString());
                            MessageBox.Show("Existe sessão aberta para o Usuário." + fSessao.Usuario.Trim() + "\r\n" +
                                            "no PDV: " + pdv.Trim() + "\r\n" + 
                                            "Para fazer o fechamento caixa, feche a tela de venda \r\n" +
                                            "no PDV: " + pdv.Trim() + " ou clique no botão Fechar Sessão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Não existe caixa aberto para o Usuário " + fSessao.Usuario.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Obrigatorio informar usuario para fechar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RetiradaCaixa()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    //Verificar se existe caixa aberto para o login
                    object obj = new TCD_CaixaPDV().BuscarEscalar(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                }
                            }, "a.id_caixa");
                    if (obj != null)
                    {
                        using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
                        {
                            fRetirar.pId_caixa = obj.ToString();
                            if (fRetirar.ShowDialog() == DialogResult.OK)
                                if (fRetirar.rRetirada != null)
                                {
                                    try
                                    {
                                        fRetirar.rRetirada.Id_caixastr = obj.ToString();
                                        fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                                        TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                                        object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                }
                                            }, "porta_imptick");
                                     //   if (porta == null ? false : !string.IsNullOrEmpty(porta.ToString()))
                                            printAberturaCaixa(null, fRetirar.rRetirada, porta.ToString());
                                        MessageBox.Show(fRetirar.rRetirada.Tp_registro.Trim().ToUpper().Equals("R") ? 
                                            "Retirada gravada com sucesso." : "Suprimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }
                        }
                    }
                    else
                        MessageBox.Show("Não existe caixa aberto para o Usuario " + fSessao.Usuario, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Obrigatorio informar usuario para realizar retirada/suprimento de caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void printAberturaCaixa(TRegistro_CaixaPDV rCaixa, TRegistro_RetiradaCaixa rRetirada, string porta)
        {
            string title = string.Empty;
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
            if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
            {
                title = rCaixa != null ? "ABERTURA" : rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? "SUPRIMENTO" : "RETIRADA";
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Abertura.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(" =========================================");
                    w.WriteLine("          " + title.Trim() + " - CAIXA Nº" + (rCaixa == null ? rRetirada.Id_caixastr.Trim() : rCaixa.Id_caixastr.Trim()));
                    w.WriteLine(" =========================================");
                    w.WriteLine(" Data: " + (rCaixa == null ? rRetirada.Dt_retiradastr : rCaixa.Dt_aberturastr));
                    if (rCaixa != null)
                        w.WriteLine(" USUÁRIO: " + rCaixa.Login.Trim().ToUpper());
                    w.WriteLine((rCaixa == null ? (rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? " VL.Suprimento: " : " VL.Retirada: ")
                        + (rRetirada.Vl_retirada.ToString("N2", new System.Globalization.CultureInfo("en-US", true)))
                        : (" VL.Abertura: " + rCaixa.Vl_abertura.ToString("N2", new System.Globalization.CultureInfo("en-US", true)))));
                    if (rRetirada != null)
                    {
                        w.WriteLine();
                        rRetirada.lPortador.ForEach(p =>
                        {
                            w.WriteLine(" Portador: " + p.Ds_portador.Trim() + "  Valor: " + p.Vl_pagtoPDV.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)));
                            if (p.lCheque.Count > 0)
                                p.lCheque.ForEach(v => w.WriteLine("Nº Cheque: " + v.Nr_cheque.Trim() + "  Vl. Cheque: " + v.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true))));
                        });
                    }
                    if (rRetirada != null)
                        w.WriteLine(" OBS: " + rRetirada.Ds_observacao.Trim().ToUpper());

                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(porta);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão Abertura Caixa: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
            else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.NM_Classe = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Altera_Relatorio = Altera_relatorio;

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rRetirada.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = rRetirada;
                Relatorio.DTS_Relatorio = meu_bind;


                //Verificar se existe Impressora padrão para o PDV
                object objIMP = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
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
                print = objIMP == null ? string.Empty : objIMP.ToString();
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
                Altera_relatorio = false;
            }
        }

        private void TFLanFrenteCaixa_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar PDV
               lPdv =
                CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          Utils.Parametros.pubTerminal,
                                                                          string.Empty,
                                                                          null);
               if (lPdv.Count > 0)
               {
                   lblPdv.Text = lPdv[0].Id_pdvstr + "-" + lPdv[0].Ds_pdv;
                   lblVendaCombustivel.Visible = lPdv[0].St_vendacombustivelbool;
               }
               else
               {
                   MessageBox.Show("Não existe ponto venda cadastrado para o terminal " + Utils.Parametros.pubTerminal, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   BeginInvoke(new MethodInvoker(Close));
                   return;
               }
            //Inicio Operacao
            lblHoraIni.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void lblMovimento_MouseEnter(object sender, EventArgs e)
        {
            lblMovimento.BorderStyle = BorderStyle.FixedSingle;
            lblMovimento.Cursor = Cursors.Hand;
            lblMovimento.ForeColor = Color.Blue;
        }

        private void lblMovimento_MouseLeave(object sender, EventArgs e)
        {
            lblMovimento.BorderStyle = BorderStyle.None;
            lblMovimento.Cursor = Cursors.Default;
            lblMovimento.ForeColor = Color.Black;
        }

        private void lblAbrirCaixa_MouseEnter(object sender, EventArgs e)
        {
            lblAbrirCaixa.BorderStyle = BorderStyle.FixedSingle;
            lblAbrirCaixa.Cursor = Cursors.Hand;
            lblAbrirCaixa.ForeColor = Color.Blue;
        }

        private void lblAbrirCaixa_MouseLeave(object sender, EventArgs e)
        {
            lblAbrirCaixa.BorderStyle = BorderStyle.None;
            lblAbrirCaixa.Cursor = Cursors.Default;
            lblAbrirCaixa.ForeColor = Color.Black;
        }

        private void lblFecharCaixa_MouseEnter(object sender, EventArgs e)
        {
            lblFecharCaixa.BorderStyle = BorderStyle.FixedSingle;
            lblFecharCaixa.Cursor = Cursors.Hand;
            lblFecharCaixa.ForeColor = Color.Blue;
        }

        private void lblFecharCaixa_MouseLeave(object sender, EventArgs e)
        {
            lblFecharCaixa.BorderStyle = BorderStyle.None;
            lblFecharCaixa.Cursor = Cursors.Default;
            lblFecharCaixa.ForeColor = Color.Black;
        }
                
        private void lblSair_MouseEnter(object sender, EventArgs e)
        {
            lblSair.BorderStyle = BorderStyle.FixedSingle;
            lblSair.Cursor = Cursors.Hand;
            lblSair.ForeColor = Color.Blue;
        }

        private void lblSair_MouseLeave(object sender, EventArgs e)
        {
            lblSair.BorderStyle = BorderStyle.None;
            lblSair.Cursor = Cursors.Default;
            lblSair.ForeColor = Color.Black;
        }

        private void lblMovimento_Click(object sender, EventArgs e)
        {
            IniciarMovimento();
        }

        private void lblAbrirCaixa_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void lblFecharCaixa_Click(object sender, EventArgs e)
        {
            FecharCaixa();
        }
                
        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanFrenteCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                IniciarMovimento();
            else if (e.KeyCode.Equals(Keys.F3))
                AbrirCaixa();
            else if (e.KeyCode.Equals(Keys.F4))
                FecharCaixa();
            else if (e.KeyCode.Equals(Keys.F5))
                RetiradaCaixa();
            else if (e.KeyCode.Equals(Keys.F10))
                IniciarVendaCombustivel();
            else if (e.KeyCode.Equals(Keys.F11))
                IniciarVendaConveniencia();
            else if (e.Control && e.KeyCode.Equals(Keys.F4))
                Close();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_relatorio = true;
            }   
        }

        private void lblRetirada_MouseEnter(object sender, EventArgs e)
        {
            lblRetirada.BorderStyle = BorderStyle.FixedSingle;
            lblRetirada.Cursor = Cursors.Hand;
            lblRetirada.ForeColor = Color.Blue;
        }

        private void lblRetirada_MouseLeave(object sender, EventArgs e)
        {
            lblRetirada.BorderStyle = BorderStyle.None;
            lblRetirada.Cursor = Cursors.Default;
            lblRetirada.ForeColor = Color.Black;
        }

        private void lblRetirada_Click(object sender, EventArgs e)
        {
            RetiradaCaixa();
        }

        private void lblVendaCombustivel_MouseEnter(object sender, EventArgs e)
        {
            lblVendaCombustivel.BorderStyle = BorderStyle.FixedSingle;
            lblVendaCombustivel.Cursor = Cursors.Hand;
            lblVendaCombustivel.ForeColor = Color.Blue;
        }

        private void lblVendaCombustivel_MouseLeave(object sender, EventArgs e)
        {
            lblVendaCombustivel.BorderStyle = BorderStyle.None;
            lblVendaCombustivel.Cursor = Cursors.Default;
            lblVendaCombustivel.ForeColor = Color.Black;
        }

        private void lblVendaCombustivel_Click(object sender, EventArgs e)
        {
            IniciarVendaCombustivel();
        }
        
        private void lblConveniencia_MouseEnter(object sender, EventArgs e)
        {
            lblConveniencia.BorderStyle = BorderStyle.FixedSingle;
            lblConveniencia.Cursor = Cursors.Hand;
            lblConveniencia.ForeColor = Color.Blue;
        }

        private void lblConveniencia_MouseLeave(object sender, EventArgs e)
        {
            lblConveniencia.BorderStyle = BorderStyle.None;
            lblConveniencia.Cursor = Cursors.Default;
            lblConveniencia.ForeColor = Color.Black;
        }

        private void lblConveniencia_Click(object sender, EventArgs e)
        {
            IniciarVendaConveniencia();
        }
        
        private void lblAbrirGaveta_Click(object sender, EventArgs e)
        {
            if (lPdv.Count > 0)
                if (lPdv[0].St_gavetadinheirobool)
                {
                    //Buscar porta comunicacao
                    object obj_porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lPdv[0].Cd_terminal.Trim() + "'"
                                            }
                                        }, "a.porta_imptick");
                    if (obj_porta != null)
                        try
                        {
                            TGavetaDinheiro.AbrirGaveta(obj_porta.ToString(), lPdv[0].CMD_Abrirgaveta);
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro executar comando: " + ex.Message.Trim()); }
                    else MessageBox.Show("Terminal " + lPdv[0].Cd_terminal.Trim() + "-" + lPdv[0].Ds_terminal.Trim() + " não tem porta comunicação configurada.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void lblAbrirGaveta_MouseEnter(object sender, EventArgs e)
        {
            lblAbrirGaveta.BorderStyle = BorderStyle.FixedSingle;
            lblAbrirGaveta.Cursor = Cursors.Hand;
            lblAbrirGaveta.ForeColor = Color.Blue;
        }

        private void lblAbrirGaveta_MouseLeave(object sender, EventArgs e)
        {
            lblAbrirGaveta.BorderStyle = BorderStyle.None;
            lblAbrirGaveta.Cursor = Cursors.Default;
            lblAbrirGaveta.ForeColor = Color.Black;
        }

        private void lblVendaPDV_Click(object sender, EventArgs e)
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Verificar se existe caixa aberto para o pdv/login
                        if (new TCD_CaixaPDV().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                }
                            }, "1") != null)
                        {
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
                                    vVL_Busca = "'" + fSessao.Usuario.Trim().ToUpper() + "'"
                                }
                            }, "1") == null)
                                TCN_Sessao.AbrirSessao(
                                    new TRegistro_Sessao()
                                    {
                                        Id_pdvstr = lPdv[0].Id_pdvstr,
                                        Login = fSessao.Usuario.Trim()
                                    }, null);
                            using (TFVendaPDV fVenda = new TFVendaPDV())
                            {
                               // fVenda.StartPosition = FormStartPosition.CenterScreen;
                                //fVenda.WindowState = FormWindowState.Normal;
                                //fVenda.MaximizeBox = true;
                                //fVenda.MinimizeBox = true;
                                fVenda.LoginPdv = fSessao.Usuario;
                                //fVenda.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
                                //fVenda.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
                                (MdiParent as Form).Visible = false;
                                try
                                {
                                    fVenda.ShowDialog();
                                }
                                catch(Exception ex)
                                { MessageBox.Show(ex.Message.Trim()); }
                                finally
                                {
                                    (MdiParent as Form).Visible = true;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Não existe caixa aberto para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar login para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblVendaPDV_MouseEnter(object sender, EventArgs e)
        {
            lblVendaPDV.BorderStyle = BorderStyle.FixedSingle;
            lblVendaPDV.Cursor = Cursors.Hand;
            lblVendaPDV.ForeColor = Color.Blue;
        }

        private void lblVendaPDV_MouseLeave(object sender, EventArgs e)
        {
            lblVendaPDV.BorderStyle = BorderStyle.None;
            lblVendaPDV.Cursor = Cursors.Default;
            lblVendaPDV.ForeColor = Color.Black;
        }

        private void lbFechaSessao_Click(object sender, EventArgs e)
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Buscar sessao aberta
                        CamadaDados.Faturamento.PDV.TList_Sessao lSessao = 
                            TCN_Sessao.Buscar(lPdv[0].Id_pdvstr,
                                                    string.Empty,
                                                    fSessao.Usuario.Trim(),
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    "'A'",
                                                    1,
                                                    null);
                        if (lSessao.Count > 0)
                        {
                            TCN_Sessao.EncerrarSessao(lSessao[0], null);
                            MessageBox.Show("Sessão encerrada para o PDV: " + lPdv[0].Ds_pdv.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Não existe sessão aberta para o PDV: " + lPdv[0].Ds_pdv.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Obrigatorio informar login para iniciar movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbFechaSessao_MouseEnter(object sender, EventArgs e)
        {
            lbFechaSessao.BorderStyle = BorderStyle.FixedSingle;
            lbFechaSessao.Cursor = Cursors.Hand;
            lbFechaSessao.ForeColor = Color.Blue;
        }

        private void lbFechaSessao_MouseLeave(object sender, EventArgs e)
        {
            lbFechaSessao.BorderStyle = BorderStyle.None;
            lbFechaSessao.Cursor = Cursors.Default;
            lbFechaSessao.ForeColor = Color.Black;
        }
    }
}
