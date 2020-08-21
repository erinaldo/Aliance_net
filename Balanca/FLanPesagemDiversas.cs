using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Balanca;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Balanca.Cadastros;

namespace Balanca
{
    public partial class TFLanPesagemDiversas : FormPesagemPadrao.TFLanPesagemPadrao
    {
        private bool controlePlaca = true;

        public TFLanPesagemDiversas()
        {
            InitializeComponent();
            pTopEsquerdo.set_FormatZero();
            pPsDiversas.set_FormatZero();
            pFiltro.set_FormatZero();
            modoBotoes();
            ativaPage(string.Empty);
            cbProtocolo.DataSource = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(string.Empty,
                                                                                   string.Empty,
                                                                                   Parametros.pubTerminal,
                                                                                   null);
            cbProtocolo.DisplayMember = "Ds_protocolo";
            cbProtocolo.ValueMember = "Cd_protocolo";
            System.Collections.ArrayList CBox1 = new System.Collections.ArrayList();
            CBox1.Add(new TDataCombo("ENTRADA", "E"));
            CBox1.Add(new TDataCombo("SAIDA", "S"));
            TP_Movimento.DataSource = CBox1;
            TP_Movimento.DisplayMember = "Display";
            TP_Movimento.ValueMember = "Value";
        }

        public override void afterNovo()
        {
            afterCancela();
            base.afterNovo();
            limparCampos();
            if (Parametros.pubTerminal.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar terminal para realizar pesagem", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            bsPsDiversas.AddNew();
            tcCentral.TabPages.Clear();
            placaCarreta.Enabled = true;
            BB_PlacaCarreta.Enabled = true;
            placaCarreta.Focus();
        }

        public override void afterGrava()
        {
            try
            {
                base.afterGrava();
                if (validaGravaPsDiversas())
                {
                    CamadaNegocio.Balanca.TCN_PesagemDiversa.Gravar(bsPsDiversas.Current as TRegistro_PesagemDiversas, null);
                    bsPsDiversas.ResetCurrentItem();
                    if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                        MessageBox.Show("Pesagem Finalizada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (TpModo.Equals(TTpModo.tm_Insert))
                        MessageBox.Show("Pesagem aberta com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Pesagem alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsPsDiversas.ResetCurrentItem();

                    TpModo = TTpModo.tm_Standby;
                    ativaPage((bsPsDiversas.Current as TRegistro_PesagemDiversas).Tp_modo);

                    modoBotoes();
                    pTopEsquerdo.HabilitarControls(false, TpModo);
                    pPsDiversas.HabilitarControls(false, TpModo);

                    if (!tcCentral.TabPages.Contains(tpNavegador))
                        tcCentral.TabPages.Add(tpNavegador);
                    if (tcCentral.TabPages.Contains(tpPesagem))
                        tcCentral.SelectedTab = tpPesagem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void afterAltera()
        {
            if (bsPsDiversas.Current != null)
            {
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                tcCentral.SelectedIndex = 0;
                //Verificar se a pesagem nao esta cancelada
                if ((bsPsDiversas.Current as TRegistro_PesagemDiversas).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar pesagem com status <CANCELADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                base.afterAltera();
                ativaPage("V");
                pPsDiversas.HabilitarControls(true, TpModo);
            }
        }

        public override void afterCancela()
        {
            if (TpModo == TTpModo.tm_Insert)
                bsPsDiversas.Clear();

            TpModo = TTpModo.tm_Standby;
            modoBotoes();

            ativaPage(string.Empty);

            pTopDireito.HabilitarControls(false, TpModo);
            pTopEsquerdo.HabilitarControls(false, TpModo);
            pPsDiversas.HabilitarControls(false, TpModo);
        }

        public override void afterExclui()
        {
            if (bsPsDiversas.Current != null)
                if (MessageBox.Show("Confirma exclusão da pesagem?\r\n" +
                                   "Empresa.....: " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Cd_empresa.Trim() + "\r\n" +
                                   "Ticket......: " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Id_ticket.ToString() + "\r\n" +
                                   "TP. Pesagem.: " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Tp_pesagem.Trim(),
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Balanca.TCN_PesagemDiversa.Excluir(bsPsDiversas.Current as TRegistro_PesagemDiversas, null);
                        MessageBox.Show("Pesagem excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ativaPage(string.Empty);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        public override void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (st_aberto.Checked)
            {
                status += virg + "'A'";
                virg = ",";
            }
            if (st_fechado.Checked)
            {
                status += virg + "'F'";
                virg = ",";
            }
            if (st_cancelado.Checked)
            {
                status += virg + "'C'";
                virg = ",";
            }
            bsPsDiversas.DataSource = CamadaNegocio.Balanca.TCN_PesagemDiversa.Buscar(cd_empresabusca.Text,
                                                                                   string.Empty,
                                                                                   id_ticketbusca.Text,
                                                                                   placacarretabusca.Text,
                                                                                   tp_veiculobusca.Text,
                                                                                   string.Empty,
                                                                                   dt_ini.Text,
                                                                                   dt_fin.Text,
                                                                                   status,
                                                                                   0,
                                                                                   string.Empty,
                                                                                   null);
            ativaPage(string.Empty);
        }

        public override void configTPPesagem()
        {
            TList_CadTpPesagem lTpPesagem =
                new TCD_CadTpPesagem().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_modo",
                        vOperador = "=",
                        vVL_Busca = "'D'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_pesagem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Pesagem.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_div_usuario_x_tppesagem x "+
                                    "where x.tp_pesagem = a.tp_pesagem "+
                                    "and((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "        where y.logingrp = x.login " +
                                    "        and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                    }
                }, 1, string.Empty);
            if (lTpPesagem.Count > 0)
            {
                try
                {
                    TP_Pesagem.Text = lTpPesagem[0].Tp_pesagem.Trim();
                    NM_TpPesagem.Text = lTpPesagem[0].Nm_tppesagem.Trim();
                    VTP_MovDefault = lTpPesagem[0].Tp_movdefault.Trim();
                    VOrdemPesagem = lTpPesagem[0].Ordempesagem.Trim();
                    VST_SeqManual = lTpPesagem[0].St_seqmanual.Trim();
                    if (lTpPesagem[0].Tp_movdefault.Trim().ToUpper().Equals("E") && (TpModo == TTpModo.tm_Insert))
                        (bsPsDiversas.Current as TRegistro_PesagemDiversas).Tp_movimento = "E"; //Entrada
                    else if (lTpPesagem[0].Tp_movdefault.Trim().ToUpper().Equals("S") && (TpModo == TTpModo.tm_Insert))
                        (bsPsDiversas.Current as TRegistro_PesagemDiversas).Tp_movimento = "S"; //Saida
                }
                catch
                {
                    TP_Pesagem.Text = string.Empty;
                    NM_TpPesagem.Text = string.Empty;
                    VTP_MovDefault = string.Empty;
                    VOrdemPesagem = string.Empty;
                    VST_SeqManual = string.Empty;
                    TP_Movimento.SelectedIndex = -1;
                }
            }
            else
            {
                TP_Pesagem.Text = string.Empty;
                NM_TpPesagem.Text = string.Empty;
                VTP_MovDefault = string.Empty;
                VOrdemPesagem = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
            }
        }

        public override void afterImprime()
        {
            if (bsPsDiversas.Current != null)
            {
                if ((bsPsDiversas.Current as TRegistro_PesagemDiversas).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido imprimir ticket pesagem cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se a impressao e dos ou grafica
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Parametros.pubTerminal.Trim() + "'"
                                    }
                                }, "TP_ImpTickAvulso");
                if (obj == null)
                {
                    MessageBox.Show("Obrigatorio informar terminal para realizar pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (obj.ToString().Trim().ToUpper().Equals("G"))
                {
                    FormRelPadrao.Relatorio rel = new FormRelPadrao.Relatorio();
                    try
                    {
                        rel.Altera_Relatorio = Altera_Relatorio;
                        DTS = new BindingSource();
                        DTS.DataSource = new TList_PesagemDiversas() { bsPsDiversas.Current as TRegistro_PesagemDiversas };
                        rel.DTS_Relatorio = DTS;
                        //Fonte Dados Empresa
                        BindingSource bs_empresa = new BindingSource();
                        bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsPsDiversas.Current as TRegistro_PesagemDiversas).Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                        rel.Adiciona_DataSource("DTS_Empresa", bs_empresa);
                        rel.Nome_Relatorio = Name;
                        rel.NM_Classe = Name;
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pMensagem = "IMPRESSÃO TICKET Nº " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Id_ticket.ToString();
                            if (Altera_Relatorio)
                            {
                                rel.Gera_Relatorio((bsPsDiversas.Current as TRegistro_PesagemDiversas).Id_ticket.ToString(),
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "IMPRESSÃO TICKET Nº " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Id_ticket.ToString(),
                                                    fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                            else
                            {
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    rel.Gera_Relatorio(string.Empty,
                                                      fImp.pSt_imprimir,
                                                      fImp.pSt_visualizar,
                                                      fImp.pSt_enviaremail,
                                                      fImp.pSt_exportPdf,
                                                      fImp.Path_exportPdf,
                                                      fImp.pDestinatarios,
                                                      null,
                                                      "IMPRESSÃO TICKET Nº " + (bsPsDiversas.Current as TRegistro_PesagemDiversas).Id_ticket.ToString(),
                                                      fImp.pDs_mensagem);
                            }
                        }
                    }
                    finally
                    { rel = null; }
                }
                else
                    CamadaNegocio.Balanca.TCN_PesagemDiversa.ImprimirTicket(bsPsDiversas.Current as TRegistro_PesagemDiversas);
            }
            else
                MessageBox.Show("Necessário selecionar pesagem para imprimir ticket.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void CapturarImagem()
        {
            using (TFLanFotosPesagem fFotos = new TFLanFotosPesagem())
            {
                fFotos.St_capturar = TpModo.Equals(TTpModo.tm_Insert) || TpModo.Equals(TTpModo.tm_Edit);
                fFotos.ShowDialog();
                if (fFotos.St_capturar)
                {
                    (bsPsDiversas.Current as TRegistro_PesagemDiversas).lFotosPesagem = fFotos.lFotos;
                    (bsPsDiversas.Current as TRegistro_PesagemDiversas).lFotosPesagemExcluir = fFotos.lFotosExcluir;
                }
            }
        }

        private void ativaPage(string Tp_Modo)
        {
            if (Tp_Modo.Trim() != string.Empty)
            {
                if (!tcCentral.TabPages.Contains(tpPesagem))
                    tcCentral.TabPages.Add(tpPesagem);
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
            }
            else
                if (TpModo.Equals(TTpModo.tm_Standby) || TpModo.Equals(TTpModo.tm_busca))
                {
                    tcCentral.TabPages.Clear();
                    if (!tcCentral.TabPages.Contains(tpNavegador))
                        tcCentral.TabPages.Add(tpNavegador);
                    if (!tcCentral.TabPages.Contains(tpPesagem))
                        tcCentral.TabPages.Add(tpPesagem);
                }
        }

        private bool validaGravaPsDiversas()
        {
            if (placaCarreta.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar placa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                placaCarreta.Focus();
                return false;
            }
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return false;
            }
            if (TP_Movimento.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar tipo de movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TP_Movimento.Focus();
                return false;
            }
            return true;
        }

        private void ativaCampos()
        {
            if (TpModo == TTpModo.tm_Standby)
            {
                pTopEsquerdo.HabilitarControls(false, TpModo);
                pTopDireito.HabilitarControls(false, TpModo);
                pPsDiversas.HabilitarControls(false, TpModo);
            }
            else if (TpModo == TTpModo.tm_Insert)
            {
                placaCarreta.Enabled = false;
                BB_PlacaCarreta.Enabled = false;
                CD_Empresa.Enabled = true;
                BB_Empresa.Enabled = true;
                TP_Pesagem.Enabled = true;
                bb_tppesagem.Enabled = true;
                ID_Ticket.Enabled = (VST_SeqManual == "S");
                cbProtocolo.Enabled = true;
                pPsDiversas.HabilitarControls(true, TpModo);
            }
            else if (TpModo == TTpModo.tm_Edit)
            {
                pTopEsquerdo.HabilitarControls(false, TpModo);
                pTopDireito.HabilitarControls(false, TpModo);
                pPsDiversas.HabilitarControls(true, TpModo);
            }
        }

        private void limparCampos()
        {
            VTP_MovDefault = string.Empty;
            VOrdemPesagem = string.Empty;
            VST_SeqManual = string.Empty;
            if (tcCentral.Equals(tpPesagem))
            {
                pTopDireito.LimparRegistro();
                pTopEsquerdo.LimparRegistro();
                pPsDiversas.LimparRegistro();
            }
            else if (tcCentral.Equals(tpNavegador))
                pFiltro.LimparRegistro();
        }

        private void TPPesagem()
        {
            string vColunas = TP_Pesagem.NM_CampoBusca + "|=|'" + TP_Pesagem.Text + "';" +
                              "TP_Modo|IN|('D');" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            DataRow retorno = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TCD_CadTpPesagem());
            if (retorno != null)
            {
                VOrdemPesagem = retorno["OrdemPesagem"].ToString().Trim();
                VTP_MovDefault = retorno["TP_MovDefault"].ToString().Trim();
                VST_SeqManual = retorno["ST_SeqManual"].ToString().Trim();
                ID_Ticket.Enabled = retorno["ST_SeqManual"].ToString().Trim().Equals("S");
                if (retorno["TP_MovDefault"].ToString().Trim().Equals("E"))
                    TP_Movimento.SelectedIndex = 0;
                else if (retorno["TP_MovDefault"].ToString().Trim().Equals("S"))
                    TP_Movimento.SelectedIndex = 1;

                bsPsDiversas.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                bsPsDiversas.ResetCurrentItem();
            }

            if (VOrdemPesagem == "DI") //PESAGEM LANCANDO PESO BRUTO E TARA DE UMA VEZ SO SEM FLUXO DE VEICULO
            {
                ps_bruto.Enabled = true;
                ps_tara.Enabled = true;
            }
        }

        public override void AplicarPesagem()
        {
            if (bsPsDiversas.Current == null ? false :
                (bsPsDiversas.Current as TRegistro_PesagemDiversas).St_registro.Trim().ToUpper().Equals("F") &&
                !(bsPsDiversas.Current as TRegistro_PesagemDiversas).Nr_lanctoFiscal.HasValue &&
                MessageBox.Show("Confirma aplicação da pesagem selecionada?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                    Proc_Commoditties.TProcessarPedPSDiversos.ProcessarAplicPsDiversos(new List<TRegistro_PesagemDiversas>() { bsPsDiversas.Current as TRegistro_PesagemDiversas });
                    //Aplicar PS Diversas
                    CamadaNegocio.Balanca.TCN_PesagemDiversa.AplicarPSDiversas(new List<TRegistro_PesagemDiversas>() { bsPsDiversas.Current as TRegistro_PesagemDiversas }, rNf, null);
                    if (rNf.Cd_modelo.Trim().Equals("55") && rNf.Tp_nota.Trim().ToUpper().Equals("P"))
                    {
                        if (MessageBox.Show("Aplicação realizada com sucesso.\r\n Deseja enviar NFe para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            try
                            {
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else MessageBox.Show("Aplicação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
                using (TFPsDiversasAplicar fAplicar = new TFPsDiversasAplicar())
                {
                    if (fAplicar.ShowDialog() == DialogResult.OK)
                        if (fAplicar.lPsDiversas != null)
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                Proc_Commoditties.TProcessarPedPSDiversos.ProcessarAplicPsDiversos(fAplicar.lPsDiversas);
                                //Aplicar PS Diversas
                                CamadaNegocio.Balanca.TCN_PesagemDiversa.AplicarPSDiversas(fAplicar.lPsDiversas, rNf, null);
                                if (rNf.Cd_modelo.Trim().Equals("55") && rNf.Tp_nota.Trim().ToUpper().Equals("P"))
                                {
                                    if (MessageBox.Show("Aplicação realizada com sucesso.\r\n Deseja enviar NFe para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                            {
                                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                                rNf.Nr_lanctofiscalstr,
                                                                                                                                null);
                                                fGerNfe.ShowDialog();
                                            }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                                else MessageBox.Show("Aplicação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
        }

        private void TFLanPesagemDiversas_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gPsDiversas);
            ShapeGrid.RestoreShape(this, gAplicacao);
            ShapeGrid.RestoreShape(this, gItensNota);
            nr_tickOrig.Visible = false;
            labeltick.Visible = false;
            tp_transbordo.Visible = false;
            lblPsSaca.Visible = false;
            lblPsDesconto.Visible = false;
            ps_desconto.Visible = false;
            lblDesdobro.Visible = false;
            ps_desdobro.Visible = false;
            lblPsSaca.Visible = false;
            bb_desdobrarticket.Visible = false;
            bb_recusarticket.Visible = false;
            bb_processarticketrecusado.Visible = false;
            bb_desdobroespecial.Visible = false;
            bb_trocarcontrato.Visible = false;
            ps_liquido.Visible = false;
            if (tcCentral.TabPages.Contains(tpPesagem))
                tcCentral.TabPages.Remove(tpPesagem);
            bb_cancelarAplic.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR CANCELAR NOTAS FISCAIS", null);
        }

        private void placaCarreta_Leave(object sender, EventArgs e)
        {
            if (controlePlaca)
            {
                controlePlaca = false;
                if (placaCarreta.Text.Trim() != string.Empty)
                {
                    TList_PesagemDiversas lPsDiversa = CamadaNegocio.Balanca.TCN_PesagemDiversa.Buscar(string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           placaCarreta.Text,
                                                                                                                           string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           "'A'",
                                                                                                                           0,
                                                                                                                           string.Empty,
                                                                                                                           null);

                    if (lPsDiversa.Count > 0)
                    {
                        ps_bruto.Value = decimal.Zero;
                        ps_tara.Value = decimal.Zero;
                        ps_liquido.Value = decimal.Zero;
                        bsPsDiversas.DataSource = lPsDiversa;
                        //Desabilitar Campos
                        CD_Empresa.Enabled = false;
                        BB_Empresa.Enabled = false;
                        cd_produto.Enabled = false;
                        ds_produto.Enabled = false;
                        placaCarreta.Enabled = false;

                        TpModo = TTpModo.tm_Edit;
                        vST_FecharPesagem = true;
                        modoBotoes();
                        ativaCampos();
                        TP_Pesagem.Text = lPsDiversa[0].Tp_pesagem;
                        TPPesagem();
                        //Habilitar Aba Pedido
                        if (!tcCentral.TabPages.Contains(tpPesagem))
                            tcCentral.TabPages.Add(tpPesagem);
                    }
                    else
                    {
                        ativaCampos();
                        CD_Empresa.Focus();
                    }
                }
                controlePlaca = true;
            }
        }

        private void BB_PlacaCarreta_Click(object sender, EventArgs e)
        {
            string vColunas = "a.placacarreta|Nº Placa|80;" +
                              "a.tp_movimento|Tipo Movimento|80;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "a.Ds_Carga|Descrição Carga|200;" +
                              "a.NM_Clifor|Cliente/Fornecedor|200";
            string vParam = "isnull(a.st_registro, 'A')|=|'A';" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaCarreta },
                                    new TCD_PesagemDiversas(), vParam);

            placaCarreta_Leave(this, new EventArgs());
        }

        private void TP_Pesagem_Leave(object sender, EventArgs e)
        {
            string vParamFixo = "TP_Modo|IN|('D');" +
                                "a.TP_Pesagem = '" + TP_Pesagem.Text.Trim() + "'" +
                                "and |EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParamFixo, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                new TCD_CadTpPesagem());

            if (linha != null)
            {
                TPPesagem();
                if (!tcCentral.TabPages.Contains(tpPesagem))
                    tcCentral.TabPages.Add(tpPesagem);
                bsPsDiversas.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                bsPsDiversas.ResetCurrentItem();
            }
        }

        private void bb_tppesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_TPPesagem|Tipo Pesagem|350;" +
                              "TP_Pesagem|TP. Pesagem|100";
            string vParamFixo = "TP_Modo|IN|('D');" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TCD_CadTpPesagem(), vParamFixo);

            TP_Pesagem_Leave(this, new EventArgs());
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto, ds_produto, cd_unidade, sg_unidade },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto, cd_unidade, sg_unidade }, string.Empty);
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_tpveiculo|=|'" + cd_tpveiculo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veiculo|350;" +
                              "CD_TpVeiculo|Cód. TPVeiculo|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo(), string.Empty);
        }

        private void cd_transp_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + cd_transp.NM_CampoBusca + "|=|'" + cd_transp.Text + "';" +
                              "a.ST_Transportadora|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transp, nm_transp },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_transp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transp, nm_transp },
                                        "a.ST_Transportadora|=|'S'");
        }
                
        private void gPsDiversas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPsDiversas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPsDiversas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PesagemDiversas());
            TList_PesagemDiversas lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPsDiversas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPsDiversas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PesagemDiversas(lP.Find(gPsDiversas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPsDiversas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PesagemDiversas(lP.Find(gPsDiversas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPsDiversas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPsDiversas.List as TList_PesagemDiversas).Sort(lComparer);
            bsPsDiversas.ResetBindings(false);
            gPsDiversas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanPesagemDiversas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gPsDiversas);
            ShapeGrid.SaveShape(this, gAplicacao);
            ShapeGrid.SaveShape(this, gItensNota);
        }

        private void gPsDiversas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                        gPsDiversas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gPsDiversas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else 
                        gPsDiversas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_motorista }, string.Empty);
        }
        
        private void bb_cancelarAplic_Click(object sender, EventArgs e)
        {
            if (bsPsDiversas.Current != null)
                if((bsPsDiversas.Current as TRegistro_PesagemDiversas).Nr_lanctoFiscal.HasValue)
                    if (MessageBox.Show("Confirma cancelamento Aplicação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        //Buscar objeto nota fiscal a ser cancelado
                        TList_RegLanFaturamento lNfAplic =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsPsDiversas.Current as TRegistro_PesagemDiversas).Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          (bsPsDiversas.Current as TRegistro_PesagemDiversas).Nr_lanctofiscalstr,
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
                                                                                          null);
                        if (lNfAplic[0].Cd_modelo.Trim().Equals("55") &&
                            lNfAplic[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                            lNfAplic[0].St_transmitidoNFe)
                        {
                            //Verificar se NFe ja nao foi cancelada junto a receita
                            CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                   lNfAplic[0].Cd_empresa,
                                                                                   lNfAplic[0].Nr_lanctofiscal.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   "CA",
                                                                                   string.Empty,
                                                                                   null);
                            if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                            {
                                //Cancelar somente NFe no Aliance.NET
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            else
                            {
                                if (lEvento.Count.Equals(0))
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                    string motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (motivo.Trim().Length < 15)
                                    {
                                        MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    //Buscar evento Carta Correcao
                                    TList_Evento lEv =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                    if (lEv.Count.Equals(0))
                                    {
                                        MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    //Cancelar NFe Receita
                                    CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                    rEvento.Cd_empresa = lNfAplic[0].Cd_empresa;
                                    rEvento.Nr_lanctofiscal = lNfAplic[0].Nr_lanctofiscal;
                                    rEvento.Chave_acesso_nfe = lNfAplic[0].Chave_acesso_nfe;
                                    rEvento.Nr_protocoloNfe = lNfAplic[0].Nr_protocolo;
                                    rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                    rEvento.Ds_evento = motivo;
                                    rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                    rEvento.Descricao_evento = lEv[0].Ds_evento;
                                    rEvento.Tp_evento = lEv[0].Tp_evento;
                                    rEvento.St_registro = "A";
                                    CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                                    if (MessageBox.Show("Evento de CANCELAMENTO gravado com sucesso.\r\n" +
                                                        "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                            == DialogResult.Yes)
                                    {
                                        //Buscar CfgNfe para a empresa
                                        TList_CfgNfe lCfg =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNfAplic[0].Cd_empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rEvento, lCfg[0]);
                                            if (!string.IsNullOrEmpty(msg))
                                                MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                                "Aguarde um tempo e tente novamente.\r\n" +
                                                                "Erro: " + msg.Trim() + "\r\n" +
                                                                "Obs.: A NFe não será cancelada no sistema Aliance.NET enquanto a mesma não for cancelada junto a receita.",
                                                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            else
                                            {
                                                MessageBox.Show("Evento registrado e vinculado a NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                                MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                afterBusca();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //Buscar CfgNfe para a empresa
                                    TList_CfgNfe lCfg =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNfAplic[0].Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], lCfg[0]);
                                        if (!string.IsNullOrEmpty(msg))
                                            MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                            "Aguarde um tempo e tente novamente.\r\n" +
                                                            "Erro: " + msg.Trim() + "\r\n" +
                                                            "Obs.: A NFe não será cancelada no sistema Aliance.NET enquanto a mesma não for cancelada junto a receita.",
                                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        else
                                        {
                                            MessageBox.Show("Evento registrado e vinculado a NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                            MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            afterBusca();
                                        }
                                    }
                                }
                            }
                        }
                        else
                            try
                            {
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                MessageBox.Show("Aplicação Cancelada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (lNfAplic[0].Cd_modelo.Trim().Equals("55") &&
                                    lNfAplic[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                                    (!lNfAplic[0].St_transmitidoNFe))
                                {
                                    TList_CadSequenciaNF lSeq = CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(lNfAplic[0].Nr_serie,
                                                                                                                             lNfAplic[0].Cd_modelo,
                                                                                                                             lNfAplic[0].Cd_empresa,
                                                                                                                             null);
                                    if (lSeq.Count > 0)
                                        if (lSeq[0].Seq_NotaFiscal.Equals(lNfAplic[0].Nr_notafiscal))
                                        {
                                            lSeq[0].Seq_NotaFiscal--;
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                            MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            //Buscar configuracao nfe
                                            TList_CfgNfe lCfgNfe =
                                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                                            if (lCfgNfe.Count > 0)
                                            {
                                                try
                                                {
                                                    //Inutilizar numero nota
                                                    srvNFE.InutilizarNFE.InutilizarNFE2.InutilizarNfe2(lCfgNfe[0].Cd_uf_empresa,
                                                                                                       lCfgNfe[0].Cnpj_empresa,
                                                                                                       lNfAplic[0].Nr_serie,
                                                                                                       lNfAplic[0].Cd_modelo,
                                                                                                       DateTime.Now.Year.ToString(),
                                                                                                       lNfAplic[0].Nr_notafiscal.Value,
                                                                                                       lNfAplic[0].Nr_notafiscal.Value,
                                                                                                       "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFE",
                                                                                                       lCfgNfe[0]);
                                                    MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch
                                                { MessageBox.Show("Erro ao INUTILIZAR numero junto a receita.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                        }
                                }
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message); }
                    }
        }
    }
}
