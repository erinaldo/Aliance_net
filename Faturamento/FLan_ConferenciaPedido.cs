using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Faturamento.Cadastros;

namespace Faturamento
{
    public partial class TFLan_ConferenciaPedido : Form
    {
        public TFLan_ConferenciaPedido()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            NR_Pedido_Busca.Clear();
            CD_Empresa_Busca.Clear();
            CD_Clifor_Busca.Clear();
            CFG_Pedido_Busca.Clear();
            rb_pedconfaberta.Checked = false;
            rb_pedconfprocessada.Checked = false;
        }

        private void GravarConferencia()
        {
            if (tcPedidos.SelectedTab.Equals(tpPedidosEnt))
            {
                if (BS_PedidoEnt.Current != null)
                    if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        using (TFConferenciaPedido fConf = new TFConferenciaPedido())
                        {
                            fConf.bsEntregaPedido.DataSource = (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido;
                            if (fConf.ShowDialog() == DialogResult.OK)
                            {
                                if (tcPedidos.SelectedTab.Equals(tpPedidosEnt))
                                    this.ProcessarConferencia();
                                else
                                {
                                    try
                                    {
                                        CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Gravar((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido, null);
                                        MessageBox.Show("Conferência gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
            }
            else if (tcPedidos.SelectedTab.Equals(tpPedidoSai))
            {
                if (bsPedidoSai.Current != null)
                    if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        using (TFConferenciaPedido fConf = new TFConferenciaPedido())
                        {
                            fConf.bsEntregaPedido.DataSource = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido;
                            if (fConf.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Gravar(bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, null);
                                    MessageBox.Show("Conferência gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
            }
        }

        private void ProcessarConferencia()
        {
            if (tcPedidos.SelectedTab.Equals(tpPedidosEnt))
            {
                if (BS_PedidoEnt.Current != null)
                    if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p=> p.St_registro.Trim().ToUpper().Equals("A") ||
                                                                                                                                p.St_registro.Trim().ToUpper().Equals("R")))
                        {
                            bool st_processar = true;
                            if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p => p.Qtd_entregue > p.Qtd_pedido))
                                if (!(MessageBox.Show("Existe item do pedido com quantidade conferida maior que a quantidade do item.\r\n" +
                                                   "Deseja Continuar o processamento?\r\n\r\n" +
                                                   "Obs.: Se optar por continuar o sistema ira incrementar o item do pedido com a diferença da conferência.",
                                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes))
                                    st_processar = false;
                                if(st_processar)
                                {
                                    (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.ForEach(p =>
                                        {
                                            if(p.St_registro.Trim().ToUpper() != "P")
                                                if (p.Qtd_entregue > 0)
                                                {
                                                    p.St_recontar = true;
                                                    p.Login = Utils.Parametros.pubLogin;
                                                }
                                                else
                                                    p.St_recontar = false;
                                        });
                                    try
                                    {
                                        CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.ProcessarEntregaPedido(
                                            (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido, null);
                                        MessageBox.Show("Conferência pedido processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                        }
                        else
                            MessageBox.Show("Permitido processar somente conferência com status <ABERTO> ou <PROCESSADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tcPedidos.SelectedTab.Equals(tpPedidoSai))
            {
                if (bsPedidoSai.Current != null)
                    if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p=> p.St_registro.Trim().ToUpper().Equals("A") ||
                                                                                                                               p.St_registro.Trim().ToUpper().Equals("R")))
                        {
                            //Verificar se existe OS Integrada ao pedido com status diferente de devolvida
                            object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_os, 'AB')",
                                        vOperador = "<>",
                                        vVL_Busca = "'DV'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedidointegra",
                                        vOperador = "=",
                                        vVL_Busca = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString()
                                    }
                                }, "1");
                            if(obj != null)
                                if (obj.ToString().Trim().Equals("1"))
                                {
                                    MessageBox.Show("Não é permitido processar conferência de pedido com ordem serviço integrada com status diferente de <DEVOLVIDA>.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            using (TFProcessarConferencia fProc = new TFProcessarConferencia())
                            {
                                fProc.bsEntregaPedido.DataSource = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido;
                                if (fProc.ShowDialog() == DialogResult.OK)
                                {
                                    if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p => p.Qtd_entregue > p.Qtd_pedido))
                                    {
                                        MessageBox.Show("Conferência não podera ser processada pois existe item do pedido com quantidade conferida maior que a quantidade do item.",
                                                           "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.ForEach(p => p.Login = p.St_recontar ? fProc.Login : string.Empty);
                                    try
                                    {
                                        CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.ProcessarEntregaPedido(
                                            (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido), null);
                                        MessageBox.Show("Conferência pedido processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.ForEach(p => p.St_recontar = false);
                            }
                        }
                        else
                            MessageBox.Show("Permitido processar somente conferência com status <ABERTO> ou <PROCESSADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EstornarConferencia()
        {
            if (tcPedidos.SelectedTab.Equals(tpPedidosEnt))
            {
                if (BS_PedidoEnt.Current != null)
                    if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p=> p.St_registro.Trim().ToUpper().Equals("P")))
                        {
                            if (MessageBox.Show("Confirma estorno das conferências processadas do pedido Nº " + (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString() + "?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Pedir autenticacao de um usuario com acesso a fazer conferencia
                                using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                                {
                                    fUser.Ds_regraespecial = "PERMITIR ESTORNAR CONFERENCIA PEDIDO";
                                    if (fUser.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.EstornarConferenciaPedido(
                                                (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido, null);
                                            MessageBox.Show("Conferência estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.afterBusca();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("Permitido estornar somente conferência com status <PROCESSADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tcPedidos.SelectedTab.Equals(tpPedidoSai))
            {
                if (bsPedidoSai.Current != null)
                    if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Count > 0)
                        if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido.Exists(p=> p.St_registro.Trim().ToUpper().Equals("P")))
                        {
                            if (MessageBox.Show("Confirma estorno das conferências processadas do pedido Nº " + (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString() + "?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Pedir autenticacao de um usuario com acesso a fazer conferencia
                                using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                                {
                                    fUser.Ds_regraespecial = "PERMITIR ESTORNAR CONFERENCIA PEDIDO";
                                    if (fUser.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            string retorno = CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.EstornarConferenciaPedido(
                                                                (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido, null);
                                            MessageBox.Show(retorno.Trim() != string.Empty ? retorno.Trim() : "Conferência estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.afterBusca();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("Permitido estornar somente conferência com status <PROCESSADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterBusca()
        {
            if (tcPedidos.SelectedTab.Equals(tpPedidosEnt))
            {
                BS_PedidoEnt.DataSource = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.BuscarPedidoConferencia(NR_Pedido_Busca.Text,
                                                                                                           CD_Empresa_Busca.Text,
                                                                                                           CD_Clifor_Busca.Text,
                                                                                                           CFG_Pedido_Busca.Text,
                                                                                                           (tcPedidos.SelectedTab.Equals(tpPedidoSai) ? cd_vendedor.Text : string.Empty),
                                                                                                           (tcPedidos.SelectedTab.Equals(tpPedidosEnt) ? cd_comprador.Text : string.Empty),
                                                                                                           "E",
                                                                                                           DT_Inicial.Text,
                                                                                                           DT_Final.Text,
                                                                                                           rb_pedconfaberta.Checked,
                                                                                                           rb_pedconfprocessada.Checked,
                                                                                                           rb_pedconfrecontar.Checked,
                                                                                                           null);
                BS_Pedido_PositionChanged(this, new EventArgs());
            }
            else if (tcPedidos.SelectedTab.Equals(tpPedidoSai))
            {
                bsPedidoSai.DataSource = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.BuscarPedidoConferencia(NR_Pedido_Busca.Text,
                                                                                                           CD_Empresa_Busca.Text,
                                                                                                           CD_Clifor_Busca.Text,
                                                                                                           CFG_Pedido_Busca.Text,
                                                                                                           (tcPedidos.SelectedTab.Equals(tpPedidoSai) ? cd_vendedor.Text : string.Empty),
                                                                                                           (tcPedidos.SelectedTab.Equals(tpPedidosEnt) ? cd_comprador.Text : string.Empty),
                                                                                                           "S",
                                                                                                           DT_Inicial.Text,
                                                                                                           DT_Final.Text,
                                                                                                           rb_pedconfaberta.Checked,
                                                                                                           rb_pedconfprocessada.Checked,
                                                                                                           rb_pedconfrecontar.Checked,
                                                                                                           null);
                bsPedidoSai_PositionChanged(this, new EventArgs());

            }
        }

        private void DevolverOs()
        {
            if ((BS_Ordem_Servico.Count > 0) && (bsPedidoSai.Current != null))
            {
                using (Proc_Commoditties.TFDevolverOS fDevOs = new Proc_Commoditties.TFDevolverOS())
                {
                    fDevOs.Cd_clifor = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Clifor;
                    fDevOs.Nm_clifor = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).NM_Clifor;
                    fDevOs.Nr_pedido = (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString();
                    if (fDevOs.ShowDialog() == DialogResult.OK)
                    {
                        if (fDevOs.lOs.Count > 0)
                        {
                            try
                            {
                                CamadaNegocio.Servicos.TCN_LanServico.DevolverOS(fDevOs.lOs, null);
                                MessageBox.Show("Ordens Serviço devolvidas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.BuscarOsIntegrada();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Não existe Ordem Serviço selecionada para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void RelatorioOs()
        {
            if (BS_Ordem_Servico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {

                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = false;
                    Rel.DTS_Relatorio = BS_Ordem_Servico;
                    Rel.Nome_Relatorio = "FRel_OrdemServico";
                    Rel.NM_Classe = "TFLan_Ordem_Servico";
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_OrdemServico";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO ORDEM SERVIÇO";
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO ORDEM SERVIÇO",
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço para imprimir relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarOsIntegrada()
        {
            if(bsPedidoSai.Current != null)
                if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido > 0)
                {
                    CamadaDados.Servicos.TList_LanServico lOs = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
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
                                                                                                              (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              0,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              null);
                    lOs.ForEach(p => p.lPecas = CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                                                                 p.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 false,
                                                                                                 0,
                                                                                                 null));
                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lOsIntegra = lOs;
                    bsPedidoSai.ResetCurrentItem();
                }
        }

        private void TFLan_ConferenciaPedido_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEntrega);
            Utils.ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.RestoreShape(this, gEntregaPedidoSai);
            Utils.ShapeGrid.RestoreShape(this, gPedidoSai);
            Utils.ShapeGrid.RestoreShape(this, gOrdemServico);
            label5.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            if(BS_PedidoEnt.Current != null)
                if ((BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido != 0)
                {
                    //Buscar conferencias do pedido
                        (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido =
                            CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Busca(string.Empty,
                                                                                        (BS_PedidoEnt.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,
                                                                                        string.Empty,
                                                                                        null);
                        BS_PedidoEnt.ResetCurrentItem();

                }
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

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void btn_CFG_Pedido_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_exigirconferenciaentrega, 'N')|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CFG_Pedido_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido_Busca.Text.Trim() + "';" +
                            "isnull(a.st_exigirconferenciaentrega, 'N')|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.GravarConferencia();
        }

        private void TFLan_ConferenciaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.GravarConferencia();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.ProcessarConferencia();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EstornarConferencia();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.RelatorioOs();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.DevolverOs();
        }

        private void gEntrega_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    {
                        DataGridViewRow linha = gEntrega.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gEntrega.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bsPedidoSai_PositionChanged(object sender, EventArgs e)
        {
            if (bsPedidoSai.Current != null)
                if ((bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido != 0)
                {
                    //Buscar conferencias do pedido
                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lEntregaPedido =
                        CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Busca(string.Empty,
                                                                                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    false,
                                                                                    string.Empty,
                                                                                    null);
                    //Buscar OS Integradas ao Pedido
                    CamadaDados.Servicos.TList_LanServico lOs = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
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
                                                                                                              (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              false,
                                                                                                              0,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              null);
                    lOs.ForEach(p => p.lPecas = CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                                                                 p.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 false,
                                                                                                 0,
                                                                                                 null));
                    (bsPedidoSai.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).lOsIntegra = lOs;
                    bsPedidoSai.ResetCurrentItem();

                }
        }

        private void tcPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BB_ProcessarConferencia.Visible = tcPedidos.SelectedTab.Equals(tpPedidoSai);
        }

        private void BB_ProcessarConferencia_Click(object sender, EventArgs e)
        {
            this.ProcessarConferencia();
        }

        private void gEntregaPedidoSai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    {
                        DataGridViewRow linha = gEntregaPedidoSai.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gEntregaPedidoSai.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_estornarconferencia_Click(object sender, EventArgs e)
        {
            this.EstornarConferencia();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.RelatorioOs();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.DevolverOs();
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S';" +
                            "a.loginvendedor|=|'" + Utils.Parametros.pubLogin.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S';" +
                            "a.loginvendedor|=|'" + Utils.Parametros.pubLogin.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_comprador_Click(object sender, EventArgs e)
        {
            string vColunas = "c.nm_clifor|Nome Comprador|250;" +
                              "a.cd_clifor_cmp|Cd. Comprador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_comprador },
                                    new CamadaDados.Compra.TCD_CadUsuarioCompra(), string.Empty);
        }

        private void cd_comprador_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor_cmp|=|'" + cd_comprador.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { cd_comprador },
                                    new CamadaDados.Compra.TCD_CadUsuarioCompra());
        }

        private void TFLan_ConferenciaPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEntrega);
            Utils.ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.SaveShape(this, gEntregaPedidoSai);
            Utils.ShapeGrid.SaveShape(this, gPedidoSai);
            Utils.ShapeGrid.SaveShape(this, gOrdemServico);
        }
    }
}
