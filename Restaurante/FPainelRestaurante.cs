using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class FPainelRestaurante : Form
    {
        private bool Altera_relatorio = false;
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }

        public FPainelRestaurante()
        {
            InitializeComponent();
        }

        #region Métodos

        private void FecharCaixa()
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    //Verificar se existe caixa aberto para o pdv/login
                    TList_CaixaPDV lCaixa = new TCD_CaixaPDV().Select(
                                                new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            }
                                        }, 1, string.Empty);
                    if (lCaixa.Count > 0)
                    {
                        //Verificar se existe sessao aberta para o usuario
                        if (new TCD_Sessao().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'F'"
                                            }
                                        }, "1") != null)
                        {
                            if (MessageBox.Show("Existe sessão aberta para o Usuário." + fSessao.Usuario.Trim() + "\r\n" +
                                            "Deseja finalizar todas as sessões?", "Mensagem",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                TList_Sessao se = new TList_Sessao();
                                se = TCN_Sessao.Buscar(string.Empty, string.Empty, Utils.Parametros.pubLogin, string.Empty, string.Empty, string.Empty, "'A'", 0, null);
                                se.ForEach(p =>
                                {
                                    p.St_registro = "F";
                                    TCN_Sessao.EncerrarSessao(p, null);
                                });
                            }
                            else
                            {
                                return;
                            }
                        }

                        string dt_ini = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy")).ToString();
                        string dt_fim = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")).ToString();
                        //Verificar se existe venda de delivery
                        if (new CamadaDados.Restaurante.TCD_PreVenda().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_delivery, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.dt_venda",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini).ToString("yyyyMMdd")) + " 00:00:00'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.dt_venda",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fim).ToString("yyyyMMdd")) + " 00:00:00'"
                                }

                    }, "1") != null)
                        {
                            if (MessageBox.Show("Existe venda de delivery em ENTREGA, gostaria de fechar?" + fSessao.Usuario.Trim() + ".\r\n" +
                                            "Deseja fechar delivery?.", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                using (TFVendaDelivery f = new TFVendaDelivery())
                                {
                                    f.vSt_entrega = true;
                                    f.vSt_buscar = true;
                                    f.ShowDialog();
                                }
                            }
                        }
                        //Verificar se existe venda de combustivel em espera para o login
                        if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                },
                                new Utils.TpBusca()
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
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCaixa[0].Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
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
                                        extrato.NM_Classe = this.Name;
                                        extrato.Modulo = "PDV";
                                        extrato.Ident = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                                        BindingSource bs_caixa = new BindingSource();
                                        bs_caixa.DataSource = lCaixa;
                                        extrato.Adiciona_DataSource("CAIXA", bs_caixa);
                                        BindingSource bs = new BindingSource();
                                        bs.DataSource = TCN_FechamentoCaixa.Buscar(lCaixa[0].Id_caixastr,
                                                                                   string.Empty,
                                                                                   "'A'",
                                                                                   null);
                                        extrato.DTS_Relatorio = bs;
                                        //Buscar retiradas a processar
                                        object obj =
                                        new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = lCaixa[0].Id_caixastr
                                                },
                                                new Utils.TpBusca()
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
                        MessageBox.Show("Não existe caixa aberto para o Usuário " + fSessao.Usuario.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Obrigatorio informar usuario para fechar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                            },
                            new Utils.TpBusca()
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
                                    //if (lPdv[0].St_nfcebool)
                                    //{
                                    //    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                                    //    Relatorio.Nome_Relatorio = "TFLanFrenteCaixa_AberturaCaixa";
                                    //    Relatorio.NM_Classe = "TFLanFrenteCaixa_AberturaCaixa";
                                    //    Relatorio.Modulo = "PDV";
                                    //    Relatorio.Ident = "TFLanFrenteCaixa_AberturaCaixa";
                                    //    Relatorio.Altera_Relatorio = Altera_relatorio;

                                    //    BindingSource BinEmpresa = new BindingSource();
                                    //    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(fCaixa.rCaixa.Cd_empresa,
                                    //                                                                        string.Empty,
                                    //                                                                        string.Empty,
                                    //                                                                        null);
                                    //    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                                    //    BindingSource meu_bind = new BindingSource();
                                    //    meu_bind.DataSource = fCaixa.rCaixa;
                                    //    Relatorio.DTS_Relatorio = meu_bind;


                                    //    //Verificar se existe Impressora padrão para o PDV
                                    //    object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                    //                                        new Utils.TpBusca[]
                                    //        {
                                    //            new Utils.TpBusca()
                                    //            {
                                    //                vNM_Campo = "a.cd_terminal",
                                    //                vOperador = "=",
                                    //                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                    //            }
                                    //        }, "a.impressorapadrao");
                                    //    string print = string.Empty;
                                    //    print = obj == null ? string.Empty : obj.ToString();
                                    //    if (string.IsNullOrEmpty(print))
                                    //        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                    //        {
                                    //            if (fLista.ShowDialog() == DialogResult.OK)
                                    //                if (!string.IsNullOrEmpty(fLista.Impressora))
                                    //                    print = fLista.Impressora;

                                    //        }
                                    //    //Imprimir
                                    //    Relatorio.ImprimiGraficoReduzida(print,
                                    //                                        true,
                                    //                                        false,
                                    //                                        1);
                                    //    Altera_relatorio = false;
                                    //}
                                    //else
                                    //{
                                    //    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    //        new Utils.TpBusca[]
                                    //        {
                                    //            new Utils.TpBusca()
                                    //            {
                                    //                vNM_Campo = "a.cd_terminal",
                                    //                vOperador = "=",
                                    //                vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                    //            }
                                    //        }, "porta_imptick");
                                    //    if (obj != null)
                                    //        printAberturaCaixa(fCaixa.rCaixa, null, obj.ToString());
                                    //}
                                    MessageBox.Show("Caixa aberto com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void visibilidadeComponentes()
        {
            lblHoraboliche.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITE LANÇAR PREÇO DE HORA PARA PISTA", null);

            label1.Visible
                = lblStatusCartao.Visible
                    = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ABERTURA STATUS CARTAO", null);

            lblPistaBoliche.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PISTA BOLICHE", null);

            lblVendaCombustivel.Visible
                = delivery.Visible
                    = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PREVENDA DELIVERY", null);

            label2.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CADASTRO CLIENTE", null);

            lblFecharCartao.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FECHAR VENDA", null);

            lblFecharCartao.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "VISIBILIDADE FECHAR VENDA", null);
        }

        #endregion

        #region Eventos

        private void lblVendaCombustivel_Click(object sender, EventArgs e)
        {
            using (TFLanPreVenda a = new TFLanPreVenda())
            {
                a.ShowDialog();
            }
        }

        private void FPainelRestaurante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F10))
            {
                if (lblVendaCombustivel.Visible)
                    lblVendaCombustivel_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.P) && e.Control)
                Altera_relatorio = true;
            else if (e.KeyCode.Equals(Keys.F8))
            {
                if (label1.Visible)
                    label1_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F11))
            {
                if (lblVendaCombustivel.Visible)
                    using (TFVendaDelivery f = new TFVendaDelivery())
                        f.ShowDialog();
            }
            else if (e.KeyCode.Equals(Keys.F12))
            {
                if (label2.Visible)
                    using (Restaurante.Cadastro.FClifor f = new Restaurante.Cadastro.FClifor())
                        f.ShowDialog();
            }
            else if (e.KeyCode.Equals(Keys.F3))
                this.AbrirCaixa();
            else if (e.KeyCode.Equals(Keys.F4))
                this.FecharCaixa();
            else if (e.KeyCode.Equals(Keys.F9))
            {
                if (lblPistaBoliche.Visible)
                    using (TFMovBoliche fMov = new TFMovBoliche())
                        fMov.ShowDialog();
            }
            else if (e.KeyCode.Equals(Keys.F7))
            {
                if (lblFecharCartao.Visible)
                    using (TFFechaCartao fFecharCartao = new TFFechaCartao())
                        fFecharCartao.ShowDialog();
            }
        }

        private void control_MouseEnter(object sender, EventArgs e)
        {

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

        private void FPainelRestaurante_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
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
            }
            else
            {
                MessageBox.Show("Não existe ponto venda cadastrado para o terminal " + Utils.Parametros.pubTerminal, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }

            //Controla visibilidade de componentes
            CamadaDados.Restaurante.Cadastro.TList_CFG lConf =
                CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(lPdv[0].Cd_empresa, null);
            if (lConf.Count > 0)
            {
                lConf.ForEach(p =>
                {
                    if (p.cd_empresa == lPdv[0].Cd_empresa)
                    {
                        if (string.IsNullOrEmpty(p.Cd_horaboliche))
                            lblPistaBoliche.Visible = false;
                    }
                });
            }
            visibilidadeComponentes();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Cursor = Cursors.Hand;
            label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {

            label1.BorderStyle = BorderStyle.None;
            label1.Cursor = Cursors.Default;
            label1.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (TFAbrirCartao ca = new TFAbrirCartao())
            {
                ca.ShowDialog();
            }
        }

        private void lblFecharCaixa_Click(object sender, EventArgs e)
        {
            this.FecharCaixa();
        }

        private void lblAbrirCaixa_Click(object sender, EventArgs e)
        {
            this.AbrirCaixa();
        }

        private void fastfood_Click(object sender, EventArgs e)
        {
            using (TFVendaDelivery f = new TFVendaDelivery())
            {
                f.ShowDialog();
            }
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delivery_MouseEnter(object sender, EventArgs e)
        {
            delivery.BorderStyle = BorderStyle.FixedSingle;
            delivery.Cursor = Cursors.Hand;
            delivery.ForeColor = Color.Blue;
        }

        private void delivery_MouseLeave(object sender, EventArgs e)
        {
            delivery.BorderStyle = BorderStyle.None;
            delivery.Cursor = Cursors.Default;
            delivery.ForeColor = Color.Black;
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

        private void label2_Click(object sender, EventArgs e)
        {
            using (Restaurante.Cadastro.FClifor cli = new Cadastro.FClifor())
            {
                if (cli.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Cursor = Cursors.Hand;
            label2.ForeColor = Color.Blue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BorderStyle = BorderStyle.None;
            label2.Cursor = Cursors.Default;
            label2.ForeColor = Color.Black;
        }

        private void lblPistaBoliche_MouseEnter(object sender, EventArgs e)
        {
            lblPistaBoliche.BorderStyle = BorderStyle.FixedSingle;
            lblPistaBoliche.Cursor = Cursors.Hand;
            lblPistaBoliche.ForeColor = Color.Blue;
        }

        private void lblPistaBoliche_MouseLeave(object sender, EventArgs e)
        {
            lblPistaBoliche.BorderStyle = BorderStyle.None;
            lblPistaBoliche.Cursor = Cursors.Default;
            lblPistaBoliche.ForeColor = Color.Black;
        }

        private void lblHoraboliche_MouseEnter(object sender, EventArgs e)
        {
            lblHoraboliche.BorderStyle = BorderStyle.FixedSingle;
            lblHoraboliche.Cursor = Cursors.Hand;
            lblHoraboliche.ForeColor = Color.Blue;
        }

        private void lblHoraboliche_MouseLeave(object sender, EventArgs e)
        {
            lblHoraboliche.BorderStyle = BorderStyle.None;
            lblHoraboliche.Cursor = Cursors.Default;
            lblHoraboliche.ForeColor = Color.Black;
        }

        private void lblPistaBoliche_Click(object sender, EventArgs e)
        {
            using (TFMovBoliche fMov = new TFMovBoliche())
            {
                fMov.ShowDialog();

            }
        }

        private void lblHoraboliche_Click(object sender, EventArgs e)
        {
            using (TFHoraBoliche fHora = new TFHoraBoliche())
            {
                fHora.ShowDialog();
            }
        }

        private void lblFecharCartao_Click(object sender, EventArgs e)
        {
            using (TFFechaCartao fFecharCartao = new TFFechaCartao())
            {
                fFecharCartao.ShowDialog();
            }
        }

        private void lblStatusCartao_Click(object sender, EventArgs e)
        {
            using (TFStatusCartao fCartao = new TFStatusCartao())
            {
                fCartao.ShowDialog();
            }
        }

        private void lblStatusCartao_MouseEnter(object sender, EventArgs e)
        {
            lblStatusCartao.BorderStyle = BorderStyle.FixedSingle;
            lblStatusCartao.Cursor = Cursors.Hand;
            lblStatusCartao.ForeColor = Color.Blue;
        }

        private void lblStatusCartao_MouseLeave(object sender, EventArgs e)
        {
            lblStatusCartao.BorderStyle = BorderStyle.None;
            lblStatusCartao.Cursor = Cursors.Default;
            lblStatusCartao.ForeColor = Color.Black;
        }

        private void lblRetirada_Click(object sender, EventArgs e)
        {
            //Logar no PDV
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                {
                    //Verificar se existe caixa aberto para o login
                    object obj = new TCD_CaixaPDV().BuscarEscalar(
                                                                new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.login",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + fSessao.Usuario.Trim() + "'"
                                                                    },
                                                                    new Utils.TpBusca()
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

        private void lblFecharCartao_MouseEnter(object sender, EventArgs e)
        {
            lblFecharCartao.BorderStyle = BorderStyle.FixedSingle;
            lblFecharCartao.Cursor = Cursors.Hand;
            lblFecharCartao.ForeColor = Color.Blue;
        }

        private void lblFecharCartao_MouseLeave(object sender, EventArgs e)
        {
            lblFecharCartao.BorderStyle = BorderStyle.None;
            lblFecharCartao.Cursor = Cursors.Default;
            lblFecharCartao.ForeColor = Color.Black;
        }

        private void lb_venda_pesagem_Click(object sender, EventArgs e)
        {
            using (TFResBalanca a = new TFResBalanca())
            {
                a.ShowDialog();
            }
        }

        #endregion

        private void lb_venda_pesagem_MouseEnter(object sender, EventArgs e)
        {
            lb_venda_pesagem.BorderStyle = BorderStyle.FixedSingle;
            lb_venda_pesagem.Cursor = Cursors.Hand;
            lb_venda_pesagem.ForeColor = Color.Blue;
        }

        private void lb_venda_pesagem_MouseLeave(object sender, EventArgs e)
        {
            lb_venda_pesagem.BorderStyle = BorderStyle.None;
            lb_venda_pesagem.Cursor = Cursors.Default;
            lb_venda_pesagem.ForeColor = Color.Black;
        }

        private void btConsultaPedidos_Click(object sender, EventArgs e)
        {
            using (TFConsultaCartao fConsultaCartao = new TFConsultaCartao())
                fConsultaCartao.ShowDialog();
        }

        private void btConsultaPedidos_MouseEnter(object sender, EventArgs e)
        {
            btConsultaPedidos.BorderStyle = BorderStyle.FixedSingle;
            btConsultaPedidos.Cursor = Cursors.Hand;
            btConsultaPedidos.ForeColor = Color.Blue;
        }

        private void btConsultaPedidos_MouseLeave(object sender, EventArgs e)
        {
            btConsultaPedidos.BorderStyle = BorderStyle.None;
            btConsultaPedidos.Cursor = Cursors.Default;
            btConsultaPedidos.ForeColor = Color.Black;
        }
    }
}
