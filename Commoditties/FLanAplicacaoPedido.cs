using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Cadastros;
using Proc_Commoditties;

namespace Commoditties
{
    public partial class TFLanAplicacaoPedido : Form
    {
        private bool St_exigirAutoriz = false;
        private bool Altera_Relatorio = false;

        public TFLanAplicacaoPedido()
        {
            InitializeComponent();
        }

        private void afterGravaAplicacao()
        {
            if (ps_aplicar.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar peso aplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ps_aplicar.Focus();
                return;
            }
            if (bsPesagem.Count <= 0)
            {
                MessageBox.Show("Não existe TICKETS disponiveis para aplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rbSaida.Checked && St_exigirAutoriz && string.IsNullOrEmpty(cd_autoriz.Text))
            {
                MessageBox.Show("Contrato exige autorização de retirada para gerar nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_autoriz.Focus();
                return;
            }
            if ((bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).GroupBy(p => p.Tp_prodpesagem).Count() > 1 && st_notaunica.Checked)
            {
                MessageBox.Show("Não é possível aplicar Tickets com nota única com diversos tipos de produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if((bsPesagem.List as TList_RegLanPesagemGraos).Exists(p=> p.St_processarTicketRef && p.Tp_movimento.Trim().ToUpper().Equals("E") && string.IsNullOrEmpty(p.Nr_notaprodutor)))
            {
                MessageBox.Show("Não é permitido aplicar ticket de entrada sem informar nota fiscal produtor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Confirma aplicação dos TICKETS selecionados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                if(!string.IsNullOrEmpty(cd_autoriz.Text))
                    if (!ProcessaAplicacao.VerificarSaldoAutoriz(cd_autoriz.Text, ps_aplicar.Value))
                    {
                        MessageBox.Show("Autorização de retirada não tem saldo suficiente para gerar aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_autoriz.Focus();
                        return;
                    }
                try
                {
                    //Montar lista de ticket para aplicar
                    decimal saldo_aplicar = ps_aplicar.Value;
                    List<TRegistro_LanPesagemGraos> lTicketAplicar = new List<TRegistro_LanPesagemGraos>();
                    (bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).ToList().ForEach(p =>
                        {
                            if (saldo_aplicar > decimal.Zero)
                            {
                                lTicketAplicar.Add(p);
                                saldo_aplicar -= p.Ps_Aplicar;
                            }
                        });
                    TList_RegLanFaturamento lNotas = ProcessaAplicacao.ProcessarAplicacao(st_notaunica.Checked,
                                                                                          ps_aplicar.Value,
                                                                                          lTicketAplicar);
                    TCN_LanAplicacaoPedido.ProcessarAplicacaoPedido(lNotas,
                                                                    ps_aplicar.Value,
                                                                    null);
                    cbMarcarTodos.Checked = false;
                    ps_aplicar.Value = decimal.Zero;
                    ps_aplicarTicket.Value = decimal.Zero;
                    List<TRegistro_LanFaturamento> lNfe = lNotas.FindAll(p => p.Cd_modelo.Trim().Equals("55") && p.Tp_nota.Trim().ToUpper().Equals("P"));
                    List<TRegistro_LanFaturamento> lNfImp = lNotas.FindAll(p => (!p.Cd_modelo.Trim().Equals("55")) && p.Tp_nota.Trim().ToUpper().Equals("P"));
                    if (lNfImp.Count > 0)
                        if (MessageBox.Show("Aplicação realizada com sucesso.\r\nDeseja imprimir as notas fiscais?", "Pergunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                        {
                            lNfImp.ForEach(p =>
                            {
                                //Buscar nota fiscal
                                TList_RegLanFaturamento lNf =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(p.Cd_empresa,
                                                                                                  p.Nr_notafiscalstr,
                                                                                                  p.Nr_serie,
                                                                                                  p.Nr_lanctofiscalstr,
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
                                if (lNf.Count > 0)
                                {
                                    if (lNf[0].Tp_nota.Trim().ToUpper().Equals("P") && (!lNf[0].Cd_modelo.Trim().Equals("55")))
                                        //Chamar tela de impressao para a nota fiscal
                                        //somente se for nota propria
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pCd_clifor = lNf[0].Cd_clifor;
                                            fImp.pMensagem = "NOTA FISCAL Nº" + lNf[0].Nr_notafiscal.ToString();
                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(lNf[0],
                                                                                                fImp.pSt_imprimir,
                                                                                                fImp.pSt_visualizar,
                                                                                                fImp.pSt_enviaremail,
                                                                                                fImp.pDestinatarios,
                                                                                                "NOTA FISCAL Nº " + lNf[0].Nr_notafiscal.ToString(),
                                                                                                fImp.pDs_mensagem);
                                        }
                                }
                            });
                        }
                    if (lNfe.Count > 0)
                    {
                        if (MessageBox.Show("Deseja enviar NFe para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            try
                            {
                                lNfe.ForEach(p =>
                                    {
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(p.Cd_empresa,
                                                                                                                            p.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                    });
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        private void afterNovo()
        {
            cd_empresa.Clear();
            nr_contrato.Clear();
            cd_clifor.Clear();
            id_ticket.Clear();
            placaveiculo.Clear();
            cd_produto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            st_saldoaplicar.Checked = true;
            rbEntrada.Checked = true;
            bsPesagem.Clear();
            cd_empresa.Focus();
            St_exigirAutoriz = false;
            ps_aplicarTicket.Value = decimal.Zero;
            ps_aplicar.Value = decimal.Zero;
            sg_estoque.Clear();
            cd_autoriz.Clear();
            st_notaunica.Checked = false;
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_contrato.Text))
            {
                MessageBox.Show("Obrigatorio informar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_contrato.Focus();
                return;
            }
            bsPesagem.DataSource = TCN_LanPesagemGraos.Busca(cd_empresa.Text,
                                                            id_ticket.Text,
                                                            placaveiculo.Text,
                                                            nr_contrato.Text,
                                                            cd_produto.Text,
                                                            string.Empty,
                                                            dt_ini.Text,
                                                            dt_ini.Text,
                                                            rbEntrada.Checked,
                                                            rbSaida.Checked,
                                                            false,
                                                            true,
                                                            false,
                                                            false,
                                                            string.Empty,
                                                            string.Empty,
                                                            cd_clifor.Text,
                                                            string.Empty,
                                                            string.Empty,
                                                            st_saldoaplicar.Checked,
                                                            false,
                                                            false,
                                                            string.Empty,
                                                            0,
                                                            string.Empty,
                                                            null);
            bsPesagem_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsAplicacao.Current != null)
            if (MessageBox.Show("Confirma exclusão das aplicações selecionadas?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    //Buscar nota fiscal
                    TList_RegLanFaturamento lNf =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsAplicacao.Current as TRegistro_LanAplicacaoPedido).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  (bsAplicacao.Current as TRegistro_LanAplicacaoPedido).Nr_lanctofiscalaplic.ToString(),
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
                    if (lNf.Count > 0)
                    {
                        if (lNf[0].Cd_modelo.Trim().Equals("55") &&
                            lNf[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                            lNf[0].St_transmitidoNFe)
                        {
                            try
                            {
                                //Verificar se NFe ja nao foi cancelada junto a receita
                                CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                    CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                       lNf[0].Cd_empresa,
                                                                                       lNf[0].Nr_lanctofiscal.ToString(),
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "CA",
                                                                                       string.Empty,
                                                                                       null);
                                if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                {
                                    //Cancelar somente NFe no Aliance.NET
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNf[0], null);
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
                                        CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                        if (lEv.Count.Equals(0))
                                        {
                                            MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        //Cancelar NFe Receita
                                        CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                        rEvento.Cd_empresa = lNf[0].Cd_empresa;
                                        rEvento.Nr_lanctofiscal = lNf[0].Nr_lanctofiscal;
                                        rEvento.Chave_acesso_nfe = lNf[0].Chave_acesso_nfe;
                                        rEvento.Nr_protocoloNfe = lNf[0].Nr_protocolo;
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
                                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNf[0].Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                                            if (lCfg.Count.Equals(0))
                                                MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNf[0].Cd_empresa.Trim() + ".",
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
                                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNf[0], null);
                                                    MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    afterBusca();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Buscar CfgNfe para a empresa
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNf[0].Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNf[0].Cd_empresa.Trim() + ".",
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
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNf[0], null);
                                                MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                afterBusca();
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else
                            try
                            {
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNf[0], null);
                                MessageBox.Show("Nota Fiscal Cancelada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (lNf[0].Cd_modelo.Trim().Equals("55") &&
                                    lNf[0].Tp_nota.Trim().ToUpper().Equals("P"))
                                    if (!lNf[0].St_transmitidoNFe)
                                    {
                                        CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq = 
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(lNf[0].Nr_serie,
                                                                                                         lNf[0].Cd_modelo,
                                                                                                         lNf[0].Cd_empresa,
                                                                                                         null);
                                        if (lSeq.Count > 0)
                                            if (lSeq[0].Seq_NotaFiscal.Equals(lNf[0].Nr_notafiscal))
                                            {
                                                lSeq[0].Seq_NotaFiscal--;
                                                CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                                MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                //Buscar configuracao nfe
                                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNf[0].Cd_empresa,
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
                                                                                                           lNf[0].Nr_serie,
                                                                                                           lNf[0].Cd_modelo,
                                                                                                           DateTime.Now.Year.ToString(),
                                                                                                           lNf[0].Nr_notafiscal.Value,
                                                                                                           lNf[0].Nr_notafiscal.Value,
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
                    else
                        MessageBox.Show("Nota Fiscal aplicação não econtrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro excluir aplicação: " + ex.Message);
                }
            }
        }

        public void afterImprime()
        {
            if (bsPesagem.Current != null)
            {
                //Verificar se a impressao e DOS ou GRAFICA
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Parametros.pubTerminal.Trim() + "'"
                                    }
                                }, "TP_ImpTick");
                if (obj == null)
                {
                    MessageBox.Show("Obrigatorio informar terminal para realizar pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (obj.ToString().Trim().ToUpper().Equals("G"))
                {
                    //Buscar Configuracao para impressao do laudo
                    bool st_laudo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("IMP_LAUDO_DESCARGA",
                                                                                         (bsPesagem.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                         null).Trim().ToUpper().Equals("S");
                    FormRelPadrao.Relatorio rel = new FormRelPadrao.Relatorio();
                    try
                    {
                        rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource DTS = new BindingSource();
                        DTS.DataSource = new TList_RegLanPesagemGraos() { bsPesagem.Current as TRegistro_LanPesagemGraos };
                        rel.DTS_Relatorio = DTS;
                        rel.Nome_Relatorio = "TFLanPesagemGraos";
                        rel.NM_Classe = "TFLanPesagemGraos";
                        if ((bsPesagem.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("A") && st_laudo)
                            rel.Ident = "REL_LAUDO_CARGA_DESCARGA";
                        else
                            rel.Ident = "REL_IMPTICKET_GRAOS";
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsPesagem.Current as TRegistro_LanPesagemGraos).NM_Contratante.Trim();
                            fImp.pMensagem = "IMPRESSÃO TICKET Nº " + (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString();
                            if (Altera_Relatorio)
                            {
                                rel.Gera_Relatorio((bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "IMPRESSÃO TICKET Nº " + (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
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
                                                      "IMPRESSÃO TICKET Nº " + (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                      fImp.pDs_mensagem);
                            }
                        }
                    }
                    finally
                    { rel = null; }
                }
            }
            else
                MessageBox.Show("Necessario selecionar registro para imprimir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DesdobrarTicket()
        {
            if (bsPesagem.Current != null)
            {
                if ((bsPesagem.Current as TRegistro_LanPesagemGraos).Ps_Aplicar.Equals(decimal.Zero))
                {
                    MessageBox.Show("TICKET sem saldo para DESDOBRAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDesdobrarTicket fDesdobrar = new TFDesdobrarTicket())
                {
                    fDesdobrar.rPsGraos = bsPesagem.Current as TRegistro_LanPesagemGraos;
                    if (fDesdobrar.ShowDialog() == DialogResult.OK)
                        try
                        {
                            //TRegistro_LanPesagemGraos rTicketDest = TCN_LanPesagemGraos.DesdobrarTicket(fDesdobrar.rPsGraos,
                            //                                                                            fDesdobrar.Nr_contrato_dest,
                            //                                                                            fDesdobrar.Nr_notaprodutor,
                            //                                                                            fDesdobrar.Dt_emissaoprodutor,
                            //                                                                            fDesdobrar.Qt_nfprodutor,
                            //                                                                            fDesdobrar.Vl_nfprodutor,
                            //                                                                            fDesdobrar.Qt_desdobro,
                            //                                                                            fDesdobrar.St_descontoLiq,
                            //                                                                            null);
                            //MessageBox.Show("Desdobro gravado com sucesso.\r\n" +
                            //                "Empresa Origem: " + fDesdobrar.rPsGraos.Cd_empresa.Trim() + "\r\n" +
                            //                "TP. Pesagem Origem: " + fDesdobrar.rPsGraos.Tp_pesagem.Trim() + "\r\n" +
                            //                "Nº Ticket Origem: " + fDesdobrar.rPsGraos.Id_ticketstr + "\r\n" +
                            //                "Empresa Destino: " + rTicketDest.Cd_empresa.Trim() + "\r\n" +
                            //                "TP. Pesagem Destino: " + rTicketDest.Tp_pesagem.Trim() + "\r\n" +
                            //                "Nº Ticket Destino: " + rTicketDest.Id_ticketstr, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar TICKET para desdobrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'" , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanAplicacaoPedido_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gAplicacao);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pDados.set_FormatZero();
            cd_empresa.Focus();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor },
                                    new TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void ps_aplicar_Leave(object sender, EventArgs e)
        {
            if (ps_aplicar.Value > ps_aplicarTicket.Value)
                ps_aplicar.Value = ps_aplicarTicket.Value;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFLanAplicacaoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && bb_aplicar.Visible)
                afterGravaAplicacao();
            else if (e.KeyCode.Equals(Keys.F5) && bb_desaplicar.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6) && bb_desdobrar.Visible)
                DesdobrarTicket();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && BB_Imprimir.Visible)
                afterImprime();
        }

        private void rbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            st_notaunica.Enabled = rbEntrada.Checked;
            if (!rbEntrada.Checked)
                st_notaunica.Checked = false;
        }

        private void rbSaida_CheckedChanged(object sender, EventArgs e)
        {
            cd_autoriz.Enabled = rbSaida.Checked;
            bb_autoriz.Enabled = rbSaida.Checked;
        }

        private void bb_autoriz_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_contrato.Text))
            {
                string vColunas = "a.id_autoriz|Id. Autoriz.|80;" +
                                  "a.nr_pedido|Nº Pedido|80;" +
                                  "a.nr_contrato|Nº Contrato|80;" +
                                  "a.cd_produto|Cd. Produto|80;" +
                                  "b.ds_produto|Produto Retirar|200;" +
                                  "a.qtd_retirar|Qtd. Retirar|80;" +
                                  "saldo_retirar|Saldo Retirar|80";
                string vParam = "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                                "(a.qtd_retirar - a.qtd_retirada)|>|0 ";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_autoriz },
                                        new CamadaDados.Graos.TCD_Autoriz_RetDeposito(), vParam);
            }
            else
                cd_autoriz.Clear();
        }

        private void cd_autoriz_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_contrato.Text))
            {
                string vParam = "a.id_autoriz|=|" + cd_autoriz.Text + ";" +
                                "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                                "(a.qtd_retirar - a.qtd_retirada)|>|0";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_autoriz },
                                        new CamadaDados.Graos.TCD_Autoriz_RetDeposito());
            }
            else
                cd_autoriz.Clear();
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa)";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParamFixo += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato, cd_clifor }, vParamFixo);
            if (linha != null)
            {
                St_exigirAutoriz = linha["st_exigirautorizretirada"].ToString().Trim().ToUpper().Equals("S");
                sg_estoque.Text = linha["sigla_unid_produto"].ToString();
            }
        }

        private void nr_contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa)";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato, cd_clifor }, new CamadaDados.Graos.TCD_CadContrato());
            if (linha != null)
            {
                St_exigirAutoriz = linha["st_exigirautorizretirada"].ToString().Trim().ToUpper().Equals("S");
                sg_estoque.Text = linha["sigla_unid_produto"].ToString();
            }
        }

        private void TFLanAplicacaoPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gAplicacao);
        }

        private void bb_aplicar_Click(object sender, EventArgs e)
        {
            afterGravaAplicacao();
        }

        private void bb_desaplicar_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gPesagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPesagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPesagem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemGraos());
            TList_RegLanPesagemGraos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPesagem.List as TList_RegLanPesagemGraos).Sort(lComparer);
            bsPesagem.ResetBindings(false);
            gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_desdobrar_Click(object sender, EventArgs e)
        {
            DesdobrarTicket();
        }

        private void cbMarcarTodos_Click(object sender, EventArgs e)
        {
            if (bsPesagem.Count > 0)
            {
                (bsPesagem.List as TList_RegLanPesagemGraos).ForEach(p =>
                    {
                        if (p.Ps_Aplicar > decimal.Zero)
                        {
                            if(cbMarcarTodos.Checked)
                            {
                                if(p.Tp_movimento.Trim().ToUpper().Equals("E") &&
                                (string.IsNullOrEmpty(p.Nr_notaprodutor) ||
                                !p.Dt_venctonfprodutor.HasValue))
                                    using (TFNFProdutorRural fNf = new TFNFProdutorRural())
                                    {
                                        fNf.Nr_contrato = p.NR_ContratoStr;
                                        fNf.Cd_contratante = p.CD_Contratante;
                                        fNf.Nm_contratante = p.NM_Contratante;
                                        fNf.Id_ticket = p.Id_ticketstr;
                                        fNf.Nr_nfprodutor = p.Nr_notaprodutor;
                                        fNf.Dt_emissao = p.Dt_emissaonfprodutor;
                                        fNf.Dt_venctonfprodutor = p.Dt_venctonfprodutor;
                                        fNf.Qtd_nfprodutor = p.Qt_nfprodutor;
                                        fNf.Vl_nfprodutor = p.Vl_nfprodutor;
                                        if (fNf.ShowDialog() == DialogResult.OK)
                                            try
                                            {
                                                p.Nr_notaprodutor = fNf.Nr_nfprodutor;
                                                p.Dt_emissaonfprodutor = fNf.Dt_emissao;
                                                p.Dt_venctonfprodutor = fNf.Dt_venctonfprodutor;
                                                p.Qt_nfprodutor = fNf.Qtd_nfprodutor;
                                                p.Vl_nfprodutor = fNf.Vl_nfprodutor;
                                                new TCD_LanPesagemGraos().Gravar(p);
                                                MessageBox.Show("Dados Nota Produtor gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch { }
                                    }
                            }
                            p.St_processarTicketRef = cbMarcarTodos.Checked;
                        }
                    });
                bsPesagem.ResetBindings(true);
                ps_aplicarTicket.Value = (bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).Sum(p => p.Ps_Aplicar);
                ps_aplicar.Value = (bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).Sum(p => p.Ps_Aplicar);
            }
        }

        private void gPesagem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if ((bsPesagem.Current as TRegistro_LanPesagemGraos).Ps_Aplicar > decimal.Zero)
                {
                    if(!(bsPesagem.Current as TRegistro_LanPesagemGraos).St_processarTicketRef)
                    {
                        if((bsPesagem.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") &&
                            (string.IsNullOrEmpty((bsPesagem.Current as TRegistro_LanPesagemGraos).Nr_notaprodutor) ||
                            !(bsPesagem.Current as TRegistro_LanPesagemGraos).Dt_venctonfprodutor.HasValue))
                            using (TFNFProdutorRural fNf = new TFNFProdutorRural())
                            {
                                fNf.Nr_contrato = (bsPesagem.Current as TRegistro_LanPesagemGraos).NR_ContratoStr;
                                fNf.Cd_contratante = (bsPesagem.Current as TRegistro_LanPesagemGraos).CD_Contratante;
                                fNf.Nm_contratante = (bsPesagem.Current as TRegistro_LanPesagemGraos).NM_Contratante;
                                fNf.Id_ticket = (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticketstr;
                                fNf.Nr_nfprodutor = (bsPesagem.Current as TRegistro_LanPesagemGraos).Nr_notaprodutor;
                                fNf.Dt_emissao = (bsPesagem.Current as TRegistro_LanPesagemGraos).Dt_emissaonfprodutor;
                                fNf.Dt_venctonfprodutor = (bsPesagem.Current as TRegistro_LanPesagemGraos).Dt_venctonfprodutor;
                                fNf.Qtd_nfprodutor = (bsPesagem.Current as TRegistro_LanPesagemGraos).Qt_nfprodutor;
                                fNf.Vl_nfprodutor = (bsPesagem.Current as TRegistro_LanPesagemGraos).Vl_nfprodutor;
                                if (fNf.ShowDialog() == DialogResult.OK)
                                    try
                                    {
                                        (bsPesagem.Current as TRegistro_LanPesagemGraos).Nr_notaprodutor = fNf.Nr_nfprodutor;
                                        (bsPesagem.Current as TRegistro_LanPesagemGraos).Dt_emissaonfprodutor = fNf.Dt_emissao;
                                        (bsPesagem.Current as TRegistro_LanPesagemGraos).Dt_venctonfprodutor = fNf.Dt_venctonfprodutor;
                                        (bsPesagem.Current as TRegistro_LanPesagemGraos).Qt_nfprodutor = fNf.Qtd_nfprodutor;
                                        (bsPesagem.Current as TRegistro_LanPesagemGraos).Vl_nfprodutor = fNf.Vl_nfprodutor;
                                        new TCD_LanPesagemGraos().Gravar(bsPesagem.Current as TRegistro_LanPesagemGraos);
                                        MessageBox.Show("Dados Nota Produtor gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch(Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar dados nota produtor para aplicar ticket.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                    }
                    (bsPesagem.Current as TRegistro_LanPesagemGraos).St_processarTicketRef =
                        !(bsPesagem.Current as TRegistro_LanPesagemGraos).St_processarTicketRef;
                    bsPesagem.ResetCurrentItem();
                    ps_aplicarTicket.Value = (bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).Sum(p => p.Ps_Aplicar);
                    ps_aplicar.Value = (bsPesagem.List as TList_RegLanPesagemGraos).Where(p => p.St_processarTicketRef).Sum(p => p.Ps_Aplicar);
                }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            bb_aplicar.Visible = tcCentral.SelectedTab.Equals(tpTicket);
            bb_desaplicar.Visible = tcCentral.SelectedTab.Equals(tpAplicacao);
            bb_desdobrar.Visible = tcCentral.SelectedTab.Equals(tpTicket);
            BB_Imprimir.Visible = tcCentral.SelectedTab.Equals(tpTicket);
        }

        private void bsPesagem_PositionChanged(object sender, EventArgs e)
        {
            if (bsPesagem.Current != null)
                bsAplicacao.DataSource = TCN_LanAplicacaoPedido.Buscar(string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       (bsPesagem.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                       string.Empty,
                                                                       (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticketstr,
                                                                       (bsPesagem.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                       null);
            else
                bsAplicacao.Clear();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterImprime();
        }
    }
}