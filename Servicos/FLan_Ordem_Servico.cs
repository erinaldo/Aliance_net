using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using CamadaDados.Diversos;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Servicos.Cadastros;

namespace Servicos
{
    public partial class TFLan_Ordem_Servico : Form
    {
        public TTpModo vTP_Modo;
        public bool Altera_Relatorio = false;
        private bool st_cancelar
        { get; set; }

        public TFLan_Ordem_Servico()
        {
            InitializeComponent();
            vTP_Modo = TTpModo.tm_Standby;
            ControlarBarraBotoes();
        }

        private void ControlarBarraBotoes()
        {
            BB_Novo.Visible = vTP_Modo.Equals(TTpModo.tm_Standby);
            BB_Alterar.Visible = vTP_Modo.Equals(TTpModo.tm_Standby);
            BB_Gravar.Visible = vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit);
            BB_Excluir.Visible = vTP_Modo.Equals(TTpModo.tm_Standby);
            BB_Cancelar.Visible = vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit);
            BB_ProcessarOS.Visible = vTP_Modo.Equals(TTpModo.tm_Standby);
            if (tcCentral.SelectedTab != null)
                BB_Buscar.Visible = tcCentral.SelectedTab.Equals(TP_Busca) && vTP_Modo.Equals(TTpModo.tm_Standby);
            else
                BB_Buscar.Visible = false;
        }

        private void ControlarPages()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                //TabControl Central
                if (tcCentral.TabPages.Contains(TP_Busca))
                    tcCentral.TabPages.Remove(TP_Busca);
                //TabControl Lancamento
                if (vTP_Modo.Equals(TTpModo.tm_Insert))
                {
                    if (TC_Lancamento.TabPages.Contains(TP_Evolucao))
                        TC_Lancamento.TabPages.Remove(TP_Evolucao);
                    if (TC_Lancamento.TabPages.Contains(TP_Pecas))
                        TC_Lancamento.TabPages.Remove(TP_Pecas);
                }
                else
                {
                    if (!TC_Lancamento.TabPages.Contains(TP_Abertura))
                        TC_Lancamento.TabPages.Add(TP_Abertura);
                    if (!TC_Lancamento.TabPages.Contains(TP_Evolucao))
                        TC_Lancamento.TabPages.Add(TP_Evolucao);
                    if (!TC_Lancamento.TabPages.Contains(TP_Pecas))
                        TC_Lancamento.TabPages.Add(TP_Pecas);
                }
            }
            else
            {
                if (!tcCentral.TabPages.Contains(TP_Busca))
                {
                    bool st_os = false;
                    if (tcCentral.TabPages.Contains(TP_Insert))
                    {
                        tcCentral.TabPages.Remove(TP_Insert);
                        st_os = true;
                    }
                    tcCentral.TabPages.Add(TP_Busca);
                    if (st_os)
                    {
                        tcCentral.TabPages.Add(TP_Insert);
                        if (!TC_Lancamento.TabPages.Contains(TP_Abertura))
                            TC_Lancamento.TabPages.Add(TP_Abertura);
                        if (!TC_Lancamento.TabPages.Contains(TP_Evolucao))
                            TC_Lancamento.TabPages.Add(TP_Evolucao);
                        if (!TC_Lancamento.TabPages.Contains(TP_Pecas))
                            TC_Lancamento.TabPages.Add(TP_Pecas);
                    }
                }
            }
        }

        private void HabilitarControls()
        {
            pnl_Cabecalho2.HabilitarControls((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)), vTP_Modo);
            pnl_Abertura.HabilitarControls((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)), vTP_Modo);
            TS_Evolucao.Enabled = vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit);
            TS_Pecas.Enabled = vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit);
            TS_SERVICOS.Enabled = vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit);
        }

        private void afterNovo()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Standby))
            {
                vTP_Modo = TTpModo.tm_Insert;
                ControlarBarraBotoes();
                ControlarPages();
                HabilitarControls();
                bsOrdemServico.AddNew();
                CD_Empresa.Focus();
            }
        }

        public void afterAltera()
        {
            if (afterBusca() > 0)
            {
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    MessageBox.Show("Não é permitido alterar ordem serviço finalizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido alterar ordem serviço processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido alterar ordem serviço cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                vTP_Modo = TTpModo.tm_Edit;
                ControlarBarraBotoes();
                ControlarPages();
                HabilitarControls();
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                TP_Ordem.Enabled = false;
                BB_TPOrdem.Enabled = false;
                id_os.Enabled = false;
                CD_Produto.Enabled = false;
            }
        }

        private void afterGrava()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
                if (pnl_Cabecalho2.validarCampoObrigatorio())
                {
                    if (vTP_Modo.Equals(TTpModo.tm_Insert))
                    {
                        //Inserir evolucao
                        (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Clear();
                        afterInserirEvolucao();
                    }
                    if (BS_Evolucao.Count < 1)
                    {
                        MessageBox.Show("Obrigatorio informar uma evolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty((bsOrdemServico.Current as TRegistro_LanServico).Dt_previsaostr))
                    {
                        MessageBox.Show("Obrigatorio informar DT.Previsão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if(gbHorimetro.Visible && horimetro.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatório informar horimetro do patrimonio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        horimetro.Focus();
                        return;
                    }
                    try
                    {
                        string retorno = TCN_LanServico.Gravar(bsOrdemServico.Current as TRegistro_LanServico, null);
                        MessageBox.Show("Ordem serviço gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_osbusca.Text = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_OS")).ToString();
                        afterBusca();
                        vTP_Modo = TTpModo.tm_Edit;
                        afterCancela();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro gravar ordem serviço: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        afterCancela();
                    }
                }
        }

        private void afterExclui()
        {  
            if (vTP_Modo.Equals(TTpModo.tm_Standby))
                if (bsOrdemServico.Current != null)
                {
                    if (!st_cancelar)
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR CANCELAR ORDEM SERVICO";
                            fRegra.Login = Utils.Parametros.pubLogin;
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                st_cancelar = true;
                        }
                    if (st_cancelar)
                    {
                        if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                        {
                            MessageBox.Show("Ordem de serviço ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("AB") ||
                            (bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                        {
                            if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                try
                                {
                                    CamadaNegocio.Servicos.TCN_LanServico.cancelar(bsOrdemServico.Current as TRegistro_LanServico, null);
                                    MessageBox.Show("Ordem serviço cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                    afterCancela();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim());
                                }
                            }
                        }
                        else
                            MessageBox.Show("Permitido cancelar somente ordem serviço com status <ABERTA> ou <FINALIZADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Obrigatorio selecionar ordem serviço para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int afterBusca()
        {
            string st_os = string.Empty;
            string virg = string.Empty;
            if (ST_OS_Aberta.Checked)
            {
                st_os += virg + "'AB'";
                virg = ",";
            }
            if (ST_OS_Cancelada.Checked)
            {
                st_os += virg + "'CA'";
                virg = ",";
            }
            if (ST_OS_Fechada.Checked)
            {
                st_os += virg + "'FE'";
                virg = ",";
            }
            if (cbProcessada.Checked)
            {
                st_os += virg + "'PR'";
                virg = ",";
            }
            string tp_data = "A";
            if (rbAbertura.Checked)
                tp_data = "A";
            else if (rbFinalizacao.Checked)
                tp_data = "F";
            else if (rbProcessamento.Checked)
                tp_data = "P";
            TList_LanServico lista =
                CamadaNegocio.Servicos.TCN_LanServico.Buscar(NR_Serial_Busca.Text,
                                                             CD_Empresa_Busca.Text,
                                                             CD_Clifor_Busca.Text,
                                                             string.Empty,
                                                             CD_Produto_Busca.Text,
                                                             nr_patrimoniobusca.Text,
                                                             string.Empty,
                                                             id_osbusca.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             id_tecnico.Text,
                                                             id_etapa.Text,
                                                             string.Empty,
                                                             cd_fornecedor.Text,
                                                             tp_data,
                                                             DT_Inic.Text,
                                                             DT_Final.Text,
                                                             st_os,
                                                             RG_PrioridadeBusca.NM_Valor,
                                                             false,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             false,
                                                             false,
                                                             false,
                                                             false,
                                                             false,
                                                             0,
                                                             string.Empty,
                                                             string.Empty,
                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    bsOrdemServico.DataSource = lista;
                    BS_Ordem_Servico_PositionChanged(this, new EventArgs());
                    vl_total.Value = lista.Sum(p => p.Vl_subtotal);
                }
                else
                    if (vTP_Modo.Equals(TTpModo.tm_Standby) || vTP_Modo.Equals(TTpModo.tm_busca))
                        bsOrdemServico.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        private void afterCancela()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                if (vTP_Modo.Equals(TTpModo.tm_Insert))
                    bsOrdemServico.RemoveCurrent();
                vTP_Modo = TTpModo.tm_Standby;
                ControlarPages();
                ControlarBarraBotoes();
                HabilitarControls();
            }
        }

        private void afterPrint()
        {
            if (bsOrdemServico.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new TList_LanServico() { bsOrdemServico.Current as TRegistro_LanServico };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "FRel_LaudoServico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_LaudoServico";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "LAUDO ORDEM SERVIÇO";

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
                                           "LAUDO ORDEM SERVIÇO",
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
                                               "LAUDO ORDEM SERVIÇO",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço para imprimir laudo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RelatorioOs()
        {
            if (bsOrdemServico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    //Buscar pecas das OS
                    for(int i = 0; i < bsOrdemServico.Count;i++)
                        if ((bsOrdemServico[i] as TRegistro_LanServico).lPecas.Count.Equals(0))
                        {
                            //Buscar Pecas/Servicos
                            (bsOrdemServico[i] as TRegistro_LanServico).lPecas =
                                CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar((bsOrdemServico[i] as TRegistro_LanServico).Id_osstr,
                                                                                  (bsOrdemServico[i] as TRegistro_LanServico).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  0,
                                                                                  null);
                        }
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrdemServico;
                    Rel.Nome_Relatorio = "FRel_OrdemServico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_OrdemServico";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO ORDEM SERVIÇO";

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
                                           "RELATORIO ORDEM SERVIÇO",
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
                                               "RELATORIO ORDEM SERVIÇO",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço para imprimir relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void ProcessarOs()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Standby))
                if (bsOrdemServico.Current != null)
                    if (MessageBox.Show("Confirma o processamento da OS Nº " + (bsOrdemServico.Current as TRegistro_LanServico).Id_osstr + "?",
                                        "Pergunta", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.ProcessarOSPatrimonio(bsOrdemServico.Current as TRegistro_LanServico, null);
                            MessageBox.Show("Ordem de Serviço processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim());
                        }
        }

        private void EstornarProcessarOs()
        {
            if(vTP_Modo.Equals(TTpModo.tm_Standby))
                if (bsOrdemServico.Current != null)
                {
                    if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper() != "PR")
                    {
                        MessageBox.Show("Ordem de serviço selecionada não se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma estorno do processamento da Ordem Serviço Selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanServico.EstornarProcessarOSOficina(bsOrdemServico.Current as TRegistro_LanServico, null);
                            MessageBox.Show("Estorno realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                            afterCancela();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim());
                        }
                    }
                }
        }

        private void afterInserirEvolucao()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                if (bsOrdemServico.Current != null)
                {
                    if (TP_Ordem.Text.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Obrigatorio informar tipo de ordem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TP_Ordem.Focus();
                        return;
                    }
                    TRegistro_LanServicoEvolucao regEvolucao = (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Find(p => p.St_evolucao.Trim().ToUpper().Equals("A"));
                    
                    using (TFLan_Evolucao_Ordem_Servico fEvolucao = new TFLan_Evolucao_Ordem_Servico())
                    {
                        fEvolucao.TP_Ordem = TP_Ordem.Text;
                        if((bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Count > 0)
                        {
                            TRegistro_LanServicoEvolucao lEvolucao = (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Find(p => p.St_evolucao.Trim().ToUpper().Equals("A"));
                            if (lEvolucao != null)
                                fEvolucao.Etapa_atual = lEvolucao.Id_etapastr;
                        }
                        if (fEvolucao.ShowDialog() == DialogResult.OK)
                        {
                            (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.ForEach(p =>
                                {
                                    p.St_evolucao = "E";
                                    p.Dt_final = CamadaDados.UtilData.Data_Servidor();
                                });
                            TList_EtapaOrdem lEtapa =
                                TCN_EtapaOrdem.Buscar(fEvolucao.rEvolucao.Id_etapa.Value.ToString(),
                                                                                       string.Empty,
                                                                                       null);
                            if (lEtapa.Count > 0)
                            {
                                fEvolucao.rEvolucao.St_iniciarOS = lEtapa[0].St_iniciarOSbool;
                                fEvolucao.rEvolucao.St_finalizarOS = lEtapa[0].St_finalizarOSbool;
                                fEvolucao.rEvolucao.St_envterceiro = lEtapa[0].St_envterceirobool;
                                if (fEvolucao.rEvolucao.St_finalizarOS)
                                {
                                    fEvolucao.rEvolucao.St_evolucao = "E";
                                    fEvolucao.rEvolucao.Dt_final = CamadaDados.UtilData.Data_Servidor();
                                    (bsOrdemServico.Current as TRegistro_LanServico).Dt_finalizada = DateTime.Now;
                                }
                            }
                            //Verificar se a etapa que esta sendo inserida nao e de Envio para terceiro
                            //if (fEvolucao.rEvolucao.St_envterceiro)
                            //    if (MessageBox.Show("Evolução exige envio da ordem serviço para fornecedor.\r\n" +
                            //                       "Deseja amarrar ordem a um lote ja existente?",
                            //                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            //                       == DialogResult.Yes)
                            //    {
                            //        using (TFLanLoteAberto fLote = new TFLanLoteAberto())
                            //        {
                            //            fLote.Cd_empresa = (BS_Ordem_Servico.Current as TRegistro_LanServico).Cd_empresa;
                            //            if (fLote.ShowDialog() == DialogResult.OK)
                            //                if (fLote.rLote != null)
                            //                    (BS_Ordem_Servico.Current as TRegistro_LanServico).rLoteServico =
                            //                        new TRegistro_Lote_X_Servicos()
                            //                        {
                            //                            Cd_empresa = fLote.rLote.Cd_empresa,
                            //                            Id_lote = fLote.rLote.Id_lote,
                            //                            Id_os = (BS_Ordem_Servico.Current as TRegistro_LanServico).Id_os
                            //                        };
                            //        }
                            //    }
                            //Verificar se a etapa e de finalizacao
                            if (fEvolucao.rEvolucao.St_finalizarOS)
                                (bsOrdemServico.Current as TRegistro_LanServico).St_os = "FE";
                            //Inserir novo registro
                            (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Add(
                                fEvolucao.rEvolucao);
                            bsOrdemServico.ResetCurrentItem();
                            TotalizarPecasServicos();
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido incluir nova evolução\r\n" +
                                "na inclusão de uma ordem de serviço ou na alteração de uma ordem existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarEvolucao()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
            {
                if (bsOrdemServico.Current != null)
                {
                    if (TP_Ordem.Text.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Obrigatório informar tipo de ordem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TP_Ordem.Focus();
                        return;
                    }
                    if (BS_Evolucao.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar etapa para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((BS_Evolucao.Current as TRegistro_LanServicoEvolucao).St_evolucao == "E")
                    {
                        MessageBox.Show("Não é permitido alterar etapa encerrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFLan_Evolucao_Ordem_Servico fEvolucao = new TFLan_Evolucao_Ordem_Servico())
                    {
                        fEvolucao.St_altera = true;
                        fEvolucao.TP_Ordem = TP_Ordem.Text;
                        fEvolucao.Etapa_atual = (BS_Evolucao.Current as TRegistro_LanServicoEvolucao).Id_etapastr;
                        fEvolucao.rEvolucao = (BS_Evolucao.Current as TRegistro_LanServicoEvolucao);
                        if (fEvolucao.ShowDialog() == DialogResult.OK)
                        {
                            //Remove registro atual
                            BS_Evolucao.RemoveCurrent();
                            //Incluir novo registro
                            TList_EtapaOrdem lEtapa =
                                TCN_EtapaOrdem.Buscar(fEvolucao.rEvolucao.Id_etapa.Value.ToString(),
                                                                                       string.Empty,
                                                                                       null);
                            if (lEtapa.Count > 0)
                            {
                                fEvolucao.rEvolucao.St_iniciarOS = lEtapa[0].St_iniciarOSbool;
                                fEvolucao.rEvolucao.St_finalizarOS = lEtapa[0].St_finalizarOSbool;
                                fEvolucao.rEvolucao.St_envterceiro = lEtapa[0].St_envterceirobool;
                                if (fEvolucao.rEvolucao.St_finalizarOS)
                                {
                                    fEvolucao.rEvolucao.St_evolucao = "E";
                                    fEvolucao.rEvolucao.Dt_final = DateTime.Now;
                                    (bsOrdemServico.Current as TRegistro_LanServico).Dt_finalizada = DateTime.Now;

                                }
                            }
                            //Inserir novo registro
                            (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao.Add(
                                fEvolucao.rEvolucao);
                            bsOrdemServico.ResetCurrentItem();
                            TotalizarPecasServicos();
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido alterar uma evolução\r\n" +
                                "na inclusão de uma ordem de serviço ou na alteração de uma ordem existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = CD_Empresa.Text;
                    fPecas.Nm_empresa = NM_Empresa.Text;
                    fPecas.St_garantia = false;
                    fPecas.St_consumoInterno = st_servico.Equals(false) ? true : false;
                    fPecas.pSt_servico = st_servico;
                    if (st_servico && (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Nm_tecnico;
                    }
                    else if (!st_servico && (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Nm_tecnico;
                    }
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        if (!st_servico)
                        {
                            //Se existir um registro para o produto, exclui
                            if ((!fPecas.rPeca.Cd_produto.Equals(string.Empty)) && (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Exists(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())))
                            {
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Quantidade = fPecas.rPeca.Quantidade;
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_unitario = fPecas.rPeca.Vl_unitario;
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_subtotal = fPecas.rPeca.Vl_subtotal;
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_desconto = fPecas.rPeca.Vl_desconto;
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_SubTotalLiq = fPecas.rPeca.Vl_SubTotalLiq;
                                bsOrdemServico.ResetCurrentItem();
                                TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                TotalizarPecasServicos();
                            }
                        }
                        else
                        {
                            //Se existir um registro para o produto, exclui
                            if ((!fPecas.rPeca.Cd_produto.Equals(string.Empty)) && (bsOrdemServico.Current as TRegistro_LanServico).lServico.Exists(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())))
                            {
                                (bsOrdemServico.Current as TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Quantidade = fPecas.rPeca.Quantidade;
                                (bsOrdemServico.Current as TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_unitario = fPecas.rPeca.Vl_unitario;
                                (bsOrdemServico.Current as TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_subtotal = fPecas.rPeca.Vl_subtotal;
                                (bsOrdemServico.Current as TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_desconto = fPecas.rPeca.Vl_desconto;
                                (bsOrdemServico.Current as TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_SubTotalLiq = fPecas.rPeca.Vl_SubTotalLiq;
                                TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                bsServico.ResetCurrentItem();
                                TotalizarPecasServicos();
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                if (!st_servico && BS_Pecas.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar peça para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (st_servico && bsServico.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar Serviço para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_Pecas_Ordem_Servico fPeca = new TFLan_Pecas_Ordem_Servico())
                {
                    fPeca.CD_Empresa = CD_Empresa.Text;
                    fPeca.Nm_empresa = NM_Empresa.Text;
                    fPeca.St_alterar = true;
                    fPeca.pSt_servico = st_servico;
                    fPeca.St_consumoInterno = st_servico.Equals(false) ? true : false;
                    TRegistro_LanServicosPecas rPeca = new TRegistro_LanServicosPecas();
                    if (!st_servico)
                    {
                        fPeca.rPeca = BS_Pecas.Current as TRegistro_LanServicosPecas;
                        rPeca.Cd_produto = (BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (BS_Pecas.Current as TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (BS_Pecas.Current as TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (BS_Pecas.Current as TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (BS_Pecas.Current as TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    else
                    {
                        fPeca.rPeca = (bsServico.Current as TRegistro_LanServicosPecas);
                        rPeca.Cd_produto = (bsServico.Current as TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (bsServico.Current as TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (bsServico.Current as TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (bsServico.Current as TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (bsServico.Current as TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (bsServico.Current as TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (bsServico.Current as TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (bsServico.Current as TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (bsServico.Current as TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (bsServico.Current as TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (bsServico.Current as TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (bsServico.Current as TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (bsServico.Current as TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (bsServico.Current as TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (bsServico.Current as TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    if (fPeca.ShowDialog() != DialogResult.OK)
                    {
                        if (!st_servico)
                        {
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (BS_Pecas.Current as TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                        else
                        {
                            (bsServico.Current as TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (bsServico.Current as TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (bsServico.Current as TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (bsServico.Current as TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (bsServico.Current as TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (bsServico.Current as TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (bsServico.Current as TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (bsServico.Current as TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (bsServico.Current as TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (bsServico.Current as TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (bsServico.Current as TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (bsServico.Current as TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (bsServico.Current as TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (bsServico.Current as TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (bsServico.Current as TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                    }
                    if (!st_servico)
                        BS_Pecas.ResetCurrentItem();
                    else bsServico.ResetCurrentItem();
                    TotalizarPecasServicos();
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                if (!st_servico)
                {
                    if (BS_Pecas.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar peça para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (BS_Pecas.Current as TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as TRegistro_LanServico).Deleta_lPecas.Add(
                            BS_Pecas.Current as TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Remove(
                            BS_Pecas.Current as TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        BuscaPecasServicos();
                        TotalizarPecasServicos();
                    }
                }
                else
                {
                    if (bsServico.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (bsServico.Current as TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (bsServico.Current as TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as TRegistro_LanServico).Deleta_lServico.Add(
                            bsServico.Current as TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Remove(
                            bsServico.Current as TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        BuscaPecasServicos();
                        TotalizarPecasServicos();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem Peça/Serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Acessorios_Produto()
        {
            if (bsOrdemServico.Current != null)
            {
                object obj = new TCD_CadAcessoriosProduto().BuscarEscalar(
                    new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                    }
                }, "1");
                if (obj != null)
                    if (obj.ToString().Trim() != string.Empty)
                    {
                        using (TFLan_Lista_Acessorios fAcess = new TFLan_Lista_Acessorios())
                        {
                            fAcess.Cd_produto = CD_Produto.Text;
                            if (fAcess.ShowDialog() == DialogResult.OK)
                            {
                                fAcess.lAcessoriosSelecionados.ForEach(p =>
                                    {
                                        if (!(bsOrdemServico.Current as TRegistro_LanServico).lAcessorios.Exists(v => v.Ds_acessorio.Trim().ToUpper().Equals(p.ds_Acessorio.Trim().ToUpper())))
                                            (bsOrdemServico.Current as TRegistro_LanServico).lAcessorios.Add(
                                                new TRegistro_Acessorios()
                                                {
                                                    Ds_acessorio = p.ds_Acessorio
                                                });
                                    });
                                bsOrdemServico.ResetCurrentItem();
                            }
                        }
                    }
            }
        }

        private void Busca_Empresa()
        {
            TList_CadUsuario_Empresa Usuario_X_Empresa = TCN_CadUsuario_Empresa.Busca(string.Empty, 
                                                                                      Utils.Parametros.pubLogin, 
                                                                                      null);

            if (Usuario_X_Empresa.Count == 1)
            {
                if (CD_Empresa.Text == "")
                {
                    CD_Empresa.Text = Usuario_X_Empresa[0].CD_Empresa.Trim();
                    NM_Empresa.Text = Usuario_X_Empresa[0].NM_Empresa.Trim();
                }
            }
        }

        private void ValidarNumeroOs()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) &&
                (CD_Empresa.Text.Trim() != string.Empty) &&
                id_os.Enabled &&
                (id_os.Value > 0))
            {
                object obj = new TCD_LanServico().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = id_os.Value.ToString()
                        }
                    }, "1");
                    
                if (obj != null)
                {
                    MessageBox.Show("Ja existe uma ordem de serviço com este numero para a empresa " + CD_Empresa.Text.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_os.Value = id_os.Minimum;
                    id_os.Focus();
                }
            }   
        }

        private void BuscarItens()
        {
            if (string.IsNullOrEmpty(CD_Produto.Text))
                UtilPesquisa.BuscarProduto(string.Empty,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { CD_Produto, DS_Produto, Nr_patrimonio },
                                                     null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                     CD_Empresa.Text,
                                                     NM_Empresa.Text,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { CD_Produto, DS_Produto, Nr_patrimonio },
                                                     null);

            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                if (new TCD_LanServico().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_ProdutoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_finalizada",
                                vOperador = "is",
                                vVL_Busca = "null"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_os, 'AB')",
                                vOperador = "<>",
                                vVL_Busca = "'CA'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                            "where x.cd_patrimonio = a.CD_ProdutoOS " +
                                            "and x.quantidade > 1 ) "
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Existem manutenções não finalizadas para este Patrimônio!\r\n" +
                                    "Consulte a tela de Ordem de serviço e verifique para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    DS_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
                if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from VTB_LOC_LOCACAO x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_locacao = x.ID_Locacao " +
                                                        "and x.Status in ('DEVOLUCAO EXPIRADA', 'ENTREGUE', 'ENTREGA PARCIAL')) "
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                        "where x.cd_patrimonio = a.cd_produto " +
                                                        "and x.quantidade > 1 ) "
                                        }
                                    }, "1") != null)
                {
                    MessageBox.Show("Item está em locação!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    DS_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
                if(new TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca {vNM_Campo = "a.cd_patrimonio", vOperador = "=", vVL_Busca = "'" + CD_Produto.Text.Trim() + "'" },
                        new TpBusca {vNM_Campo = "isnull(a.st_controlehora, 'N')", vOperador = "=", vVL_Busca = "'S'" }
                    }, "1") != null)
                {
                    gbHorimetro.Visible = true;
                    horimetro.Value = 0;
                }
                else
                {
                    gbHorimetro.Visible = false;
                    horimetro.Value = 0;
                }
                if (!string.IsNullOrEmpty(CD_Produto.Text))
                {
                    //Buscar lengt cd_produto
                    TList_CadParamSys lParam =
                        TCN_CadParamSys.Busca("CD_PRODUTO",
                                              string.Empty,
                                              decimal.Zero,
                                              null);
                    if (lParam.Count > 0)
                        if (CD_Produto.Text.Trim().Length < lParam[0].Tamanho)
                            CD_Produto.Text = CD_Produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                }

            }
        }

        private void TotalizarPecasServicos()
        {
            if (bsOrdemServico.Current != null)
            {
                //Total Peças
                pc_desconto.Value = decimal.Zero;
                pc_acrescimo.Value = decimal.Zero;
                tot_prodservico.Value = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Sum(p => p.Vl_desconto);
                tot_acrescimo.Value = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Sum(p => p.Vl_acrescimo);
                tot_liquido.Value = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.Sum(p => p.Vl_SubTotalLiq);
                if (tot_prodservico.Value > decimal.Zero)
                {
                    pc_desconto.Value = Math.Round(decimal.Divide(decimal.Multiply(tot_desconto.Value, 100), tot_prodservico.Value), 5, MidpointRounding.AwayFromZero);
                    pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(tot_acrescimo.Value, 100), tot_prodservico.Value), 5, MidpointRounding.AwayFromZero);
                }
            }
        }

        private void BuscaPecasServicos()
        {
            //Buscar Pecas 
            BS_Pecas.DataSource = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false);

            //Buscar Servicos
            bsServico.DataSource = (bsOrdemServico.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);

        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
              , new TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
            ValidarNumeroOs();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new TCD_CadEmpresa());
            ValidarNumeroOs();
        }

        private void TFLan_Ordem_Servico_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            ShapeGrid.RestoreShape(this, g_Evolucao);
            ShapeGrid.RestoreShape(this, g_Pecas);
            ShapeGrid.RestoreShape(this, gOrdemServico);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pnl_Cabecalho2.set_FormatZero();
            pnl_Abertura.set_FormatZero();
            pnl_Busca.set_FormatZero();
            TS_Pecas.Visible = true;
            st_cancelar = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR ORDEM SERVICO", null);
        }
        
        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }
        
        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void TFLan_Ordem_Servico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F10) && BB_ProcessarOS.Visible)
                ProcessarOs();
            else if (e.KeyCode.Equals(Keys.F12) && bb_estornar.Visible)
                EstornarProcessarOs();
            else if (e.KeyCode.Equals(Keys.F10) && TC_Lancamento.SelectedTab.Equals(TP_Evolucao)
    && btn_Insere_Evolucao.Enabled && e.Control)
                afterInserirEvolucao();
            else if (e.KeyCode.Equals(Keys.F10) && TC_Lancamento.SelectedTab.Equals(tpItens)
                && btn_Insere_Pecas.Enabled && e.Control)
                afterInserirPecas(false);
            else if (e.KeyCode.Equals(Keys.F11) && TC_Lancamento.SelectedTab.Equals(TP_Evolucao)
                && btn_Altera_Evolucao.Enabled && e.Control)
                afterAlterarEvolucao();
            else if (e.KeyCode.Equals(Keys.F11) && TC_Lancamento.SelectedTab.Equals(tpItens)
                && btn_Altera_Pecas.Enabled && e.Control)
                afterAlterarPecas(false);
            else if (e.KeyCode.Equals(Keys.F12) && TC_Lancamento.SelectedTab.Equals(tpItens)
                && btn_Deleta_Pecas.Enabled && e.Control)
                afterExcluirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpServiços) && e.Control && e.KeyCode.Equals(Keys.F10))
                afterInserirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServiços) && e.Control && e.KeyCode.Equals(Keys.F11))
                afterAlterarPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServiços) && e.Control && e.KeyCode.Equals(Keys.F12))
                afterExcluirPecas(true);
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Insere_Evolucao_Click(object sender, EventArgs e)
        {
            afterInserirEvolucao();
        }
    
        private void btn_Insere_Pecas_Click(object sender, EventArgs e)
        {
            afterInserirPecas(false);
        }

        private void btn_Altera_Evolucao_Click(object sender, EventArgs e)
        {
            afterAlterarEvolucao();
        }

        private void btn_Altera_Pecas_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(false);
        }

        private void btn_Deleta_Pecas_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(false); 
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }        

        private void BS_Ordem_Servico_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemServico.Current != null)
            {
                if ((!string.IsNullOrEmpty((bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa.Trim())) &&
                    (bsOrdemServico.Current as TRegistro_LanServico).Id_os.HasValue)
                {
                    //Buscar evolucao OS   
                    (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao =
                        TCN_LanServicoEvolucao.Buscar((bsOrdemServico.Current as TRegistro_LanServico).Id_osstr,
                                                                             (bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             false,
                                                                             0,
                                                                             null);
                    lblEtapaAtual.Text = (bsOrdemServico.Current as TRegistro_LanServico).Ds_etapaatual.Trim();
                    //Buscar Acessorios
                    (bsOrdemServico.Current as TRegistro_LanServico).lAcessorios =
                        TCN_Acessorios.Buscar((bsOrdemServico.Current as TRegistro_LanServico).Id_os.ToString(),
                                                                     (bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     0,
                                                                     string.Empty,
                                                                     null);
                    //Buscar Pecas/Servicos
                    (bsOrdemServico.Current as TRegistro_LanServico).lPecas =
                        TCN_LanServicoPecas.Buscar((bsOrdemServico.Current as TRegistro_LanServico).Id_osstr,
                                                                          (bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          false,
                                                                          0,
                                                                          null);
                    //Buscar pedidos da OS
                    (bsOrdemServico.Current as TRegistro_LanServico).lPedido =
                        TCN_Servico_X_PedidoItem.BuscarPedidos((bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa,
                                                                                   (bsOrdemServico.Current as TRegistro_LanServico).Id_os.ToString(),
                                                                                   null);

                    BuscaPecasServicos();
                    bsOrdemServico.ResetCurrentItem();
                }
            }
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TipoOrdem|Tipo Ordem|300;a.tp_Ordem|Código|90"
            , new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem}, new TCD_TpOrdem(), null);
            //Verificar se o numero da os e automatico
            if (bsOrdemServico.Current != null)
            {
                id_os.Enabled = TCN_LanServico.SequenciaManual((bsOrdemServico.Current as TRegistro_LanServico), null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_Ordem|=|" + TP_Ordem.Text, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem}, new TCD_TpOrdem());
            //Verificar se o numero da os e automatico
            if (bsOrdemServico.Current != null)
            {
                id_os.Enabled = TCN_LanServico.SequenciaManual((bsOrdemServico.Current as TRegistro_LanServico), null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
        }

        private void ID_TPTransp_Recebido_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_tptransp|=|'" + ID_TPTransp_Recebido.Text + "'"
             , new Componentes.EditDefault[] { ID_TPTransp_Recebido, DS_TPTransp_Recebido }, new TCD_CadTipoTransporte());
        }

        private void BB_TPTransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_tptransp|Tipo de Transportadora|300;a.id_tptransp|Código Tipo de Transportadora|90"
           , new Componentes.EditDefault[] { ID_TPTransp_Recebido, DS_TPTransp_Recebido}, new TCD_CadTipoTransporte(), null);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            BuscarItens();       
        }

        private void BB_Produto_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Produto|Produto|300;a.cd_Produto|Código Produto|90"
                          , new Componentes.EditDefault[] { CD_Produto_Busca }, new TCD_CadProduto(), null);
        }

        private void BB_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { CD_Empresa_Busca }
              , new TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void BB_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, string.Empty);
        }

        private void CD_Produto_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Produto_Busca }, new TCD_CadProduto());
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text.Trim() + "';" +
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
             , new Componentes.EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {

            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void gOrdemServico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                    {
                        DataGridViewRow linha = gOrdemServico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Teal;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    {
                        DataGridViewRow linha = gOrdemServico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    {
                        DataGridViewRow linha = gOrdemServico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDA"))
                    {
                        DataGridViewRow linha = gOrdemServico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        DataGridViewRow linha = gOrdemServico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { id_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'");
        }

        private void id_tecnico_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + id_tecnico.Text.Trim() + 
                                                    "';isnull(a.st_tecnico, 'N')|=|'S'" +
                                                    ";isnull(a.ST_Funcionarios, 'N')|=|'S'",
                                                      new Componentes.EditDefault[] { id_tecnico },
                                                      new TCD_CadClifor());
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_etapa|Descrição Etapa|200;" +
                              "a.id_etapa|Id. Etapa|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_etapa },
                new TCD_EtapaOrdem(), string.Empty);
        }

        private void id_etapa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_etapa|=|" + id_etapa.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_etapa },
                new TCD_EtapaOrdem());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                new TCD_CadClifor());
        }

        private void id_os_Leave(object sender, EventArgs e)
        {
            ValidarNumeroOs();
        }

        private void BB_ProcessarOS_Click(object sender, EventArgs e)
        {
            ProcessarOs();
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            EstornarProcessarOs();
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RelatorioOs();
        }

        private void TFLan_Ordem_Servico_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            ShapeGrid.SaveShape(this, g_Evolucao);
            ShapeGrid.SaveShape(this, g_Pecas);
            ShapeGrid.SaveShape(this, gOrdemServico);
        }

        private void bb_inserirServicos_Click(object sender, EventArgs e)
        {
            afterInserirPecas(true);
        }

        private void bb_alterarServicos_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(true);
        }

        private void bb_excluirServicos_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(true);
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarItens();
        }

        private void listaOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemServico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrdemServico;
                    Rel.Nome_Relatorio = "TFLanOrdem_Servico_ListaOS";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "OSE";
                    Rel.Ident = "TFLanOrdem_Servico_ListaOS";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE OS";

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
                                           "RELATORIO LISTA DE OS",
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
                                               "RELATORIO LISTA DE OS",
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void imprimirOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
