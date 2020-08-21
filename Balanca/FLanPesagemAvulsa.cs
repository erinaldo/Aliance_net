using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Balanca
{
    public partial class TFLanPesagemAvulsa : FormPesagemPadrao.TFLanPesagemPadrao
    {
        private bool controlePlaca = true;

        public TFLanPesagemAvulsa()
        {
            InitializeComponent();
            pTopEsquerdo.set_FormatZero();
            pPsAvulsa.set_FormatZero();
            pFiltro.set_FormatZero();
            modoBotoes();
            ativaPage(string.Empty);
            cbProtocolo.DataSource = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(string.Empty,
                                                                                   string.Empty,
                                                                                   Parametros.pubTerminal,
                                                                                   null); ;
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
            if (Parametros.pubTerminal.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar terminal para realizar pesagem", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            bsPsAvulsa.AddNew();
            if (!tcCentral.TabPages.Contains(tpPesagem))
                tcCentral.TabPages.Add(tpPesagem);
            if (tcCentral.TabPages.Contains(tpNavegador))
                tcCentral.TabPages.Remove(tpNavegador);
            tcCentral.SelectedTab = tpPesagem;
            placaCarreta.Enabled = true;
            BB_PlacaCarreta.Enabled = true;
            placaCarreta.Focus();
        }

        public override void afterGrava()
        {
            try
            {
                base.afterGrava();
                if (validaGravaPsAvulsa())
                {
                    if ((ps_bruto.Value > 0) && (ps_tara.Value > 0) && (vl_taxa.Value > 0))
                    {
                        //Buscar configuracao financeira
                        CamadaDados.Balanca.Cadastros.TList_CFGFinPsAvulsa lCfg =
                            CamadaNegocio.Balanca.Cadastros.TCN_CFGFinPsAvulsa.Buscar((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_empresa,
                                                                                      (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_pesagem,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
                        if (lCfg.Count < 1)
                        {
                            MessageBox.Show("Não existe configuração para gerar financeiro para a pesagem avulsa.\r\n" +
                                            "Configuração obrigtoria para gerar financeiro da taxa. Ticket não será fechado.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            //Gerar financeiro da taxa
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vCd_empresa = lCfg[0].Cd_empresa;
                                fDuplicata.vNm_empresa = lCfg[0].Nm_empresa;
                                fDuplicata.vCd_clifor = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_clifor.Trim() != string.Empty ?
                                    (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_clifor : lCfg[0].Cd_cliforpadrao;
                                fDuplicata.vNm_clifor = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_clifor.Trim() != string.Empty ?
                                    (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Nm_clifor : lCfg[0].Nm_cliforpadrao;
                                if ((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_clifor.Trim() != string.Empty)
                                {
                                    //Buscar primeiro endereco do cadastro do cliente
                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_clifor,
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
                                                                                                  1,
                                                                                                  null);
                                    if (lEnd.Count > 0)
                                    {
                                        fDuplicata.vCd_endereco = lEnd[0].Cd_endereco;
                                        fDuplicata.vDs_endereco = lEnd[0].Ds_endereco;
                                    }
                                }
                                else
                                {
                                    fDuplicata.vCd_endereco = lCfg[0].Cd_endpadrao;
                                    fDuplicata.vDs_endereco = lCfg[0].Ds_endpadrao;
                                }
                                fDuplicata.vTp_docto = lCfg[0].Tp_doctostr;
                                fDuplicata.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                fDuplicata.vTp_duplicata = lCfg[0].Tp_duplicata;
                                fDuplicata.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                fDuplicata.vTp_mov = lCfg[0].Tp_mov;
                                fDuplicata.vCd_condpgto = lCfg[0].Cd_condpgto;
                                fDuplicata.vDs_condpgto = lCfg[0].Ds_condpgto;
                                fDuplicata.vCd_contagerliq = lCfg[0].Cd_contager;
                                fDuplicata.vCd_juro = lCfg[0].Cd_juro;
                                fDuplicata.vDs_juro = lCfg[0].Ds_juro;
                                fDuplicata.vCd_moeda = lCfg[0].Cd_moeda;
                                fDuplicata.vDs_moeda = lCfg[0].Ds_moeda;
                                fDuplicata.vCd_portador = lCfg[0].Cd_portador;
                                fDuplicata.vDs_portador = lCfg[0].Ds_portador;
                                fDuplicata.vNr_docto = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString();
                                fDuplicata.vDt_emissao = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Dt_brutostring;
                                fDuplicata.vVl_documento = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Vl_taxa;
                                fDuplicata.vDs_observacao = "TAXA COBRANCA PESAGEM AVULSA DO CLIENTE " + (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Nm_clifor.Trim();
                                fDuplicata.vCd_historico = lCfg[0].Cd_historico;
                                fDuplicata.vDs_historico = lCfg[0].Ds_historico;
                                fDuplicata.vSt_ctrc = true;
                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                {
                                    if (fDuplicata.dsDuplicata.Current != null)
                                        (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).lDup.Add(
                                            (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata));
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para fechar pesagem avulsa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar financeiro para fechar pesagem avulsa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    CamadaNegocio.Balanca.TCN_PesagemAvulsa.Gravar(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa, null);
                    bsPsAvulsa.ResetCurrentItem();
                    if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                        MessageBox.Show("Pesagem Finalizada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (TpModo.Equals(TTpModo.tm_Insert))
                        MessageBox.Show("Pesagem aberta com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Pesagem alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsPsAvulsa.ResetCurrentItem();

                    TpModo = TTpModo.tm_Standby;
                    ativaPage((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_modo);

                    modoBotoes();
                    pTopEsquerdo.HabilitarControls(false, TpModo);
                    pPsAvulsa.HabilitarControls(false, TpModo);

                    if (tcCentral.TabPages.Contains(tpPesagem))
                        tcCentral.SelectedTab = tpPesagem;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.Trim());
            }
        }

        public override void afterAltera()
        {
            if (bsPsAvulsa.Current != null)
            {
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                //Verificar se a pesagem nao esta cancelada
                if ((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar pesagem com status <CANCELADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                base.afterAltera();
                ativaPage("V");
                pPsAvulsa.HabilitarControls(true, TpModo);
                vl_taxa.Enabled = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Nr_lancto == null;
            }
        }

        public override void afterCancela()
        {
            if (TpModo == TTpModo.tm_Insert)
                bsPsAvulsa.Clear();

            TpModo = TTpModo.tm_Standby;
            modoBotoes();

            ativaPage(string.Empty);

            pTopDireito.HabilitarControls(false, TpModo);
            pTopEsquerdo.HabilitarControls(false, TpModo);
            pPsAvulsa.HabilitarControls(false, TpModo);
        }

        public override void afterExclui()
        {
            if(bsPsAvulsa.Current != null)
                if(MessageBox.Show("Confirma exclusão da pesagem?\r\n"+
                                   "Empresa.....: "+(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_empresa.Trim()+"\r\n"+
                                   "Ticket......: "+(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString()+"\r\n"+
                                   "TP. Pesagem.: "+(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_pesagem.Trim(),
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Balanca.TCN_PesagemAvulsa.Excluir(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa, null);
                        MessageBox.Show("Pesagem avulsa excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ativaPage(string.Empty);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
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
            bsPsAvulsa.DataSource = CamadaNegocio.Balanca.TCN_PesagemAvulsa.Buscar(cd_empresabusca.Text,
                                                                                   string.Empty,
                                                                                   id_ticketbusca.Text,
                                                                                   placacarretabusca.Text,
                                                                                   ds_cargabusca.Text,
                                                                                   nm_cliforbusca.Text,
                                                                                   tp_veiculobusca.Text,
                                                                                   string.Empty,
                                                                                   dt_ini.Text,
                                                                                   dt_fin.Text,
                                                                                   status,
                                                                                   0,
                                                                                   string.Empty,
                                                                                   null);
            bsPsAvulsa_PositionChanged(this, new EventArgs());
            ativaPage(string.Empty);
        }

        public override void configTPPesagem()
        {
            CamadaDados.Balanca.Cadastros.TList_CadTpPesagem lTpPesagem =
                new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_modo",
                        vOperador = "=",
                        vVL_Busca = "'V'"
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
                                    "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "        where y.logingrp = x.login " +
                                    "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
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
                        (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_movimento = "E"; //Entrada
                    else if (lTpPesagem[0].Tp_movdefault.Trim().ToUpper().Equals("S") && (TpModo == TTpModo.tm_Insert))
                        (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_movimento = "S"; //Saida
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
            if (bsPsAvulsa.Current != null)
            {
                if ((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).St_registro.Trim().ToUpper().Equals("C"))
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
                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
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
                        DTS.DataSource = new CamadaDados.Balanca.TList_PesagemAvulsa() { bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa };
                        rel.DTS_Relatorio = DTS;
                        rel.Nome_Relatorio = Name;
                        rel.NM_Classe = Name;
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Nm_clifor.Trim();
                            fImp.pMensagem = "IMPRESSÃO TICKET Nº " + (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString();
                            if (Altera_Relatorio)
                            {
                                rel.Gera_Relatorio((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString(),
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "IMPRESSÃO TICKET Nº " + (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString(),
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
                                                      "IMPRESSÃO TICKET Nº " + (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString(),
                                                      fImp.pDs_mensagem);
                            }
                        }
                    }
                    finally
                    { rel = null; }
                }
                else
                    CamadaNegocio.Balanca.TCN_PesagemAvulsa.ImprimirTicket(bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa);
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
                    (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).lFotosPesagem = fFotos.lFotos;
                    (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).lFotosPesagemExcluir = fFotos.lFotosExcluir;
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

        private bool validaGravaPsAvulsa()
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
            if (nm_clifor.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar nome do cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_clifor.Focus();
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
                pPsAvulsa.HabilitarControls(false, TpModo);
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
                pPsAvulsa.HabilitarControls(true, TpModo);
            }
            else if (TpModo == TTpModo.tm_Edit)
            {
                pTopEsquerdo.HabilitarControls(false, TpModo);
                pTopDireito.HabilitarControls(false, TpModo);
                pPsAvulsa.HabilitarControls(true, TpModo);
            }
        }

        private void TPPesagem()
        {
            string vColunas = "a.tp_pesagem|=|'" + TP_Pesagem.Text.Trim() + "';" +
                              "TP_Modo|=|'V'";
            DataRow retorno = UtilPesquisa.EDIT_LeaveTpPesagem(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem });
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

                bsPsAvulsa.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                bsPsAvulsa.ResetCurrentItem();
            }

            if (VOrdemPesagem == "DI") //PESAGEM LANCANDO PESO BRUTO E TARA DE UMA VEZ SO SEM FLUXO DE VEICULO
            {
                ps_bruto.Enabled = true;
                ps_tara.Enabled = true;
            }

        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veiculo|350;" +
                              "CD_TpVeiculo|Cód. TPVeiculo|100";
            
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo(), string.Empty);
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_tpveiculo|=|'" + cd_tpveiculo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
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
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaCarreta },
                                    new CamadaDados.Balanca.TCD_PesagemAvulsa(), vParam);

            placaCarreta_Leave(this, new EventArgs());
        }

        private void placaCarreta_Leave(object sender, EventArgs e)
        {
            if (controlePlaca)
            {
                controlePlaca = false;
                if (placaCarreta.Text.Trim() != string.Empty)
                {
                    CamadaDados.Balanca.TList_PesagemAvulsa lPsAvulsa = CamadaNegocio.Balanca.TCN_PesagemAvulsa.Buscar(string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       placaCarreta.Text,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       "'A'",
                                                                                                                       0,
                                                                                                                       string.Empty,
                                                                                                                       null);
                    if (lPsAvulsa.Count > 0)
                    {
                        ps_bruto.Value = 0;
                        ps_tara.Value = 0;
                        ps_liquido.Value = 0;
                        bsPsAvulsa.DataSource = lPsAvulsa;
                        CD_Empresa.Enabled = false;
                        BB_Empresa.Enabled = false;
                        placaCarreta.Enabled = false;
                        TpModo = TTpModo.tm_Edit;
                        vST_FecharPesagem = true;
                        modoBotoes();
                        ativaCampos();
                        TP_Pesagem.Text = lPsAvulsa[0].Tp_pesagem;
                        TPPesagem();
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

        private void bb_tppesagem_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaTpPesagem(new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem }, "a.tp_modo|=|'V'");
            if (linha != null)
            {
                TPPesagem();
                bsPsAvulsa.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                bsPsAvulsa.ResetCurrentItem();
            }
        }

        private void TP_Pesagem_Leave(object sender, EventArgs e)
        {
            TPPesagem();
        }

        private void TFLanPesagemAvulsa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPsAvulsa);
            Utils.ShapeGrid.RestoreShape(this, gParcela);
            pTopDireito.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pTP_Registro.BackColor = Utils.SettingsUtils.Default.COLOR_2;

            pTopEsquerdo.set_FormatZero();
            pPsAvulsa.set_FormatZero();
            if (tcCentral.TabPages.Contains(tpNavegador))
                tcCentral.SelectedTab = tpNavegador;
        }

        private void bb_empresabusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresabusca },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresabusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + cd_empresabusca.NM_CampoBusca + "|=|'" + cd_empresabusca.Text + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresabusca },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_tpveiculobusca_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veiculo|350;" +
                              "CD_TpVeiculo|Cód. TPVeiculo|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_veiculobusca },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo(), string.Empty);
        }

        private void tp_veiculobusca_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_tpveiculo|=|'" + tp_veiculobusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_veiculobusca },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        private void gPsAvulsa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                    {
                        DataGridViewRow linha = gPsAvulsa.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gPsAvulsa.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gPsAvulsa.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bsPsAvulsa_PositionChanged(object sender, EventArgs e)
        {
            if (bsPsAvulsa.Current != null)
            {
                (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).lParc =
                    CamadaNegocio.Balanca.TCN_PsAvulsa_X_Duplicata.Buscar((bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Cd_empresa,
                                                                          (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Id_ticket.ToString(),
                                                                          (bsPsAvulsa.Current as CamadaDados.Balanca.TRegistro_PesagemAvulsa).Tp_pesagem,
                                                                          null);
                bsPsAvulsa.ResetCurrentItem();
            }
        }

        private void tcDetPsAvulsa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetPsAvulsa.SelectedTab.Equals(tpDetPs))
                bindingNavigator1.BindingSource = bsPsAvulsa;
            else if (tcDetPsAvulsa.SelectedTab.Equals(tpFinPs))
                bindingNavigator1.BindingSource = bsParc;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { ds_carga }, string.Empty);
        }

        private void bb_transp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transp, nm_motorista },
                 "a.ST_Transportadora|=|'S'");
        }

        private void cd_transp_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + cd_transp.NM_CampoBusca + "|=|'" + cd_transp.Text + "';" +
                              "a.ST_Transportadora|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transp, nm_motorista },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gPsAvulsa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPsAvulsa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPsAvulsa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Balanca.TRegistro_PesagemAvulsa());
            CamadaDados.Balanca.TList_PesagemAvulsa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPsAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPsAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Balanca.TList_PesagemAvulsa(lP.Find(gPsAvulsa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPsAvulsa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Balanca.TList_PesagemAvulsa(lP.Find(gPsAvulsa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPsAvulsa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPsAvulsa.List as CamadaDados.Balanca.TList_PesagemAvulsa).Sort(lComparer);
            bsPsAvulsa.ResetBindings(false);
            gPsAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gParcela_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gParcela.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsParc.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela());
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gParcela.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gParcela.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcela.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gParcela.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcela.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gParcela.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsParc.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sort(lComparer);
            bsParc.ResetBindings(false);
            gParcela.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanPesagemAvulsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPsAvulsa);
            Utils.ShapeGrid.SaveShape(this, gParcela);
        }
    }
}
