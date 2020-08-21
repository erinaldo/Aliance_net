using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Diversos;
using CamadaNegocio.Graos;
using CamadaDados.Graos;
using Utils;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Faturamento.NotaFiscal;
using Proc_Commoditties;

namespace Commoditties
{
    public partial class TFLan_TransfContratos : Form
    {
        private bool Altera_Relatorio = false;
        public TFLan_TransfContratos()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            ID_Transferencia_Busca.Clear();
            nr_contrato_destino.Clear();
            nr_contrato_origem.Clear();
            CD_Clifor_Destino_Busca.Clear();
            CD_Clifor_Origem_Busca.Clear();
            DT_Final.Clear();
            DT_Inicial.Clear();
            st_aberto.Checked = true;
            st_cancelado.Checked = false;
        }

        private void afterNovo()
        {
            try
            {
                TRegistro_Transferencia rTransf = TProcessaTransferencia.ProcessarTransferencia();
                if (rTransf != null)
                {
                    TProcessaTransferencia.GerarTransferencia(rTransf);
                    TCN_Transferencia.Grava_Transferencia(rTransf,
                                                          null);
                    //Enviar NFe Origem
                    if (rTransf.rNfOrigem != null)
                    {
                        //Buscar nota de origem
                        TRegistro_LanFaturamento rNf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rTransf.Transf_X_Contrato_Origem[0].CD_Empresa,
                                                                                             rTransf.Transf_X_Contrato_Origem[0].NR_LanctoFiscal.ToString(),
                                                                                             null);
                        //Se for nota propria e NF-e
                        if (rNf.Tp_nota.Trim().ToUpper().Equals("P") &&
                            rNf.Cd_modelo.Trim().Equals("55"))
                        {
                            if (MessageBox.Show("Deseja enviar NF-e DEVOLUÇÃO para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                try
                                {
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = rNf;
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        else if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && (!rNf.Cd_modelo.Trim().Equals("55")))
                        {
                            //Chamar tela de impressao para a nota fiscal
                            //somente se for nota propria
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = rNf.Cd_clifor;
                                fImp.pMensagem = "NOTA FISCAL Nº" + rNf.Nr_notafiscal.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rNf,
                                                                                    fImp.pSt_imprimir,
                                                                                    fImp.pSt_visualizar,
                                                                                    fImp.pSt_enviaremail,
                                                                                    fImp.pDestinatarios,
                                                                                    "NOTA FISCAL Nº " + rNf.Nr_notafiscal.ToString(),
                                                                                    fImp.pDs_mensagem);
                            }
                        }
                    }
                    //Enviar NFe Destino
                    if (rTransf.rNfDestino != null)
                    {
                        //Buscar nota fiscal de destino
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = 
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rTransf.Transf_X_Contrato_Destino[0].CD_Empresa,
                                                                                             rTransf.Transf_X_Contrato_Destino[0].NR_LanctoFiscal.ToString(),
                                                                                             null);
                        //Se for nota propria e NF-e
                        if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && rNf.Cd_modelo.Trim().Equals("55"))
                        {
                            if (MessageBox.Show("Deseja enviar NF-e ENTRADA para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                try
                                {
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = rNf;
                                        fGerNfe.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        else if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && (!rNf.Cd_modelo.Trim().Equals("55")))
                        {
                            //Chamar tela de impressao para a nota fiscal
                            //somente se for nota propria
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = rNf.Cd_clifor;
                                fImp.pMensagem = "NOTA FISCAL Nº" + rNf.Nr_notafiscal.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rNf,
                                                                                    fImp.pSt_imprimir,
                                                                                    fImp.pSt_visualizar,
                                                                                    fImp.pSt_enviaremail,
                                                                                    fImp.pDestinatarios,
                                                                                    "NOTA FISCAL Nº " + rNf.Nr_notafiscal.ToString(),
                                                                                    fImp.pDs_mensagem);
                            }
                        }
                    }
                    LimparFiltros();
                    ID_Transferencia_Busca.Text = rTransf.ID_Transf.ToString();
                    afterBusca();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void afterExclui()
        {
            if (bsTransf.Current != null)
            {
                if ((bsTransf.Current as TRegistro_Transferencia).St_registro.Trim().Equals("C"))
                {
                    MessageBox.Show("Transferência ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento da transferência?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        bool st_cancelar = true;
                        //Verificar se existe nfe
                        string motivo = string.Empty;
                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                        CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                        if (bsOrigem.Current != null)
                        {
                            if (!(bsOrigem.Current as TRegistro_Transf_X_Contrato).St_registro.Trim().ToUpper().Equals("C"))
                            {
                                if (new TCD_LanFaturamento().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsOrigem.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_modelo",
                                            vOperador = "=",
                                            vVL_Busca = "'55'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_nota",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
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
                                            vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and x.status = '100')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_fat_eventonfe x " +
                                                        "inner join tb_fat_evento y " +
                                                        "on x.cd_evento = y.cd_evento " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and isnull(x.st_registro, 'A') <> 'T' " +
                                                        "and y.tp_evento = 'CA')"
                                        }
                                    }, "1") != null)
                                {
                                    //Verificar evento
                                    CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                           (bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                           (bsOrigem.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString(),
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           "CA",
                                                                                           string.Empty,
                                                                                           null);
                                    if (lEvento.Count.Equals(0))
                                    {
                                        if (string.IsNullOrEmpty(motivo))
                                        {
                                            InputBox ibp = new InputBox();
                                            ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                            motivo = ibp.ShowDialog();
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
                                        }
                                        //Buscar evento Cancelamento
                                        if (lEv == null)
                                            lEv = CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                        if (lEv.Count.Equals(0))
                                        {
                                            MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        //Cancelar NFe Receita
                                        CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                        rEvento.Cd_empresa = (bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa;
                                        rEvento.Nr_lanctofiscal = (bsOrigem.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal;
                                        rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                        rEvento.Ds_evento = motivo;
                                        rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                        rEvento.Descricao_evento = lEv[0].Ds_evento;
                                        rEvento.Tp_evento = lEv[0].Tp_evento;
                                        rEvento.St_registro = "A";
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                                        lEvento = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(rEvento.Id_eventostr,
                                                                                                     rEvento.Cd_empresa,
                                                                                                     rEvento.Nr_lanctofiscalstr,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     null);
                                    }
                                    if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                    {
                                        //Buscar CfgNfe para a empresa
                                        if (lCfg == null)
                                            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], lCfg[0]);
                                            if (!string.IsNullOrEmpty(msg))
                                            {
                                                MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                                "Aguarde um tempo e tente novamente.\r\n" +
                                                                "Erro: " + msg.Trim() + ".",
                                                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                st_cancelar = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (bsDestino.Current != null && st_cancelar)
                        {
                            if (!(bsDestino.Current as TRegistro_Transf_X_Contrato).St_registro.Trim().ToUpper().Equals("C"))
                            {
                                if (new TCD_LanFaturamento().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsDestino.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_modelo",
                                            vOperador = "=",
                                            vVL_Busca = "'55'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_nota",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
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
                                            vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and x.status = '100')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_fat_eventonfe x " +
                                                        "inner join tb_fat_evento y " +
                                                        "on x.cd_evento = y.cd_evento " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and isnull(x.st_registro, 'A') <> 'T' " +
                                                        "and y.tp_evento = 'CA')"
                                        }
                                    }, "1") != null)
                                {
                                    //Verificar evento
                                    CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                           (bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                           (bsDestino.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString(),
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           "CA",
                                                                                           string.Empty,
                                                                                           null);
                                    if (lEvento.Count.Equals(0))
                                    {
                                        if (string.IsNullOrEmpty(motivo))
                                        {
                                            InputBox ibp = new InputBox();
                                            ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                            motivo = ibp.ShowDialog();
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
                                        }
                                        //Buscar evento Cancelamento
                                        if (lEv == null)
                                            lEv = CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                        if (lEv.Count.Equals(0))
                                        {
                                            MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        //Cancelar NFe Receita
                                        CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                        rEvento.Cd_empresa = (bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa;
                                        rEvento.Nr_lanctofiscal = (bsDestino.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal;
                                        rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                        rEvento.Ds_evento = motivo;
                                        rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                        rEvento.Descricao_evento = lEv[0].Ds_evento;
                                        rEvento.Tp_evento = lEv[0].Tp_evento;
                                        rEvento.St_registro = "A";
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                                        lEvento = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(rEvento.Id_eventostr,
                                                                                                     rEvento.Cd_empresa,
                                                                                                     rEvento.Nr_lanctofiscalstr,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     null);
                                    }
                                    if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                    {
                                        //Buscar CfgNfe para a empresa
                                        if (lCfg == null)
                                            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], lCfg[0]);
                                            if (!string.IsNullOrEmpty(msg))
                                            {
                                                MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                                "Aguarde um tempo e tente novamente.\r\n" +
                                                                "Erro: " + msg.Trim() + ".",
                                                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                st_cancelar = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (st_cancelar)
                        {
                            TCN_Transferencia.Cancela_Transferencia(bsTransf.Current as TRegistro_Transferencia, null);
                            MessageBox.Show("Transferência cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            afterBusca();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void afterBusca()
        {
            string vStatus = string.Empty;
            string virg = string.Empty;
            if (st_aberto.Checked)
            {
                vStatus += virg + "'A'";
                virg = ",";
            }
            if (st_cancelado.Checked)
                vStatus += virg + "'C'";
            bsTransf.DataSource = CamadaNegocio.Graos.TCN_Transferencia.Busca(ID_Transferencia_Busca.Text,
                                                                              nr_contrato_origem.Text,
                                                                              nr_contrato_destino.Text,
                                                                              DT_Inicial.Text,
                                                                              DT_Final.Text,
                                                                              CD_Clifor_Origem_Busca.Text,
                                                                              CD_Clifor_Destino_Busca.Text,
                                                                              vStatus,
                                                                              null);
            bsTransf_PositionChanged(this, new EventArgs());
        }

        private void ReimprimirNfOrigem()
        {
            if (bsOrigem.Current != null)
            {
                if ((bsOrigem.Current as TRegistro_Transf_X_Contrato).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar NFe
                TRegistro_LanFaturamento rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF((bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                                                 (bsOrigem.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString(),
                                                                                                                 null);
                if (rNfe.Tp_nota.Trim().ToUpper().Equals("P"))
                    if(rNfe.Cd_modelo.Trim().Equals("55"))
                    {
                        FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
                        Danfe.Altera_Relatorio = false;
                        //Buscar Itens NFe
                        rNfe.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
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
                                                                    "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                    "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
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
                        object log = new TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
                        if (log != null)
                            Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
                        Danfe.Gera_Relatorio();
                    }
                else
                    MessageBox.Show("Somente sera impresso nota fiscal propria e não NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReimprimirNfDestino()
        {
            if (bsDestino.Current != null)
            {
                if ((bsDestino.Current as TRegistro_Transf_X_Contrato).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar NFe
                TRegistro_LanFaturamento rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF((bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa,
                                                                                                                 (bsDestino.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString(),
                                                                                                                 null);
                if (rNfe.Tp_nota.Trim().ToUpper().Equals("P"))
                    if (rNfe.Cd_modelo.Trim().Equals("55"))
                    {
                        FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
                        Danfe.Altera_Relatorio = false;
                        //Buscar Itens NFe
                        rNfe.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                                                                            rNfe.Nr_lanctofiscalstr,
                                                                                                            string.Empty,
                                                                                                            null);
                        Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
                        Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v => v.Vl_icms + v.Vl_FCP));
                        Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v => v.Vl_basecalcICMS));
                        Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v => v.Vl_basecalcSTICMS));
                        Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v => v.Vl_ICMSST + v.Vl_FCPST));
                        
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
                                                                    "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                    "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
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
                        object log = new TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
                        if (log != null)
                            Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
                        Danfe.Gera_Relatorio();
                    }
                    else
                        MessageBox.Show("Somente sera impresso nota fiscal propria e não NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterPrint()
        {
            if (bsTransf.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new TList_Transferencia() { bsTransf.Current as TRegistro_Transferencia };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "FLan_TransfContratos";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "GRO";
                    Rel.Ident = "FLan_TransfContratos";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pMensagem = "TRANSFERENCIA DE CONTRATOS";

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
                                           "TRANSFERENCIA DE CONTRATOS",
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
                                               "TRANSFERENCIA DE CONTRATOS",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void TFLan_TransfContratos_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gTransf);
            ShapeGrid.RestoreShape(this, gDestino);
            ShapeGrid.RestoreShape(this, gOrigem);
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLan_TransfContratos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void BB_Clifor_Origem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, string.Empty);
        }

        private void CD_Clifor_Origem_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Origem_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, new TCD_CadClifor());
        }

        private void BB_Clifor_Destino_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Destino_Busca },string.Empty);
        }

        private void CD_Clifor_Destino_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Origem_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, new TCD_CadClifor());
        }

        private void bsTransf_PositionChanged(object sender, EventArgs e)
        {
            if(bsTransf.Current != null)
                if ((bsTransf.Current as TRegistro_Transferencia).ID_Transf > 0)
                {
                    (bsTransf.Current as TRegistro_Transferencia).Transf_X_Contrato_Origem =
                        CamadaNegocio.Graos.TCN_Transf_X_Contrato.Busca((bsTransf.Current as TRegistro_Transferencia).ID_Transf.ToString(),
                                                                          string.Empty,
                                                                          "S",
                                                                          string.Empty,
                                                                          false,
                                                                          null);
                    (bsTransf.Current as TRegistro_Transferencia).Transf_X_Contrato_Destino =
                        CamadaNegocio.Graos.TCN_Transf_X_Contrato.Busca((bsTransf.Current as TRegistro_Transferencia).ID_Transf.ToString(),
                                                                          string.Empty,
                                                                          "E",
                                                                          string.Empty,
                                                                          false,
                                                                          null);
                    bsTransf.ResetCurrentItem();
                }
            tcOrigem.SelectedIndex = 0;
            tcDestino.SelectedIndex = 0;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gTransf_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gTransf.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gTransf.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void gOrigem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gOrigem.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gOrigem.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void gDestino_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gDestino.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gDestino.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_ReimprimeNfOrigem_Click(object sender, EventArgs e)
        {
            ReimprimirNfOrigem();
        }

        private void BB_ReimprimeNfDestino_Click(object sender, EventArgs e)
        {
            ReimprimirNfDestino();
        }

        private void TFLan_TransfContratos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gTransf);
            ShapeGrid.SaveShape(this, gDestino);
            ShapeGrid.SaveShape(this, gOrigem);
        }

        private void bb_contrato_origem_Click(object sender, EventArgs e)
        {
            string vParamFixo =
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                                "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                //Contrato de Deposito ou a Fixar
                                "||isnull(cfgped.ST_Deposito, 'N') = 'S' or isnull(cfgped.ST_ValoresFixos, 'N') <> 'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                 "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = a.cfg_pedido " +
                                 "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                // Configuracao fiscal de devolucao
                               "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                              "where x.cfg_pedido = cfgped.cfg_pedido and x.TP_Fiscal = 'TF') ";
            UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato_origem }, vParamFixo);
        }

        private void nr_contrato_origem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contrato_origem.Text + ";" +
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Contrato de Deposito ou a Fixar
                                "||isnull(cfgped.ST_Deposito, 'N') = 'S' or isnull(cfgped.ST_ValoresFixos, 'N') <> 'S';" +
                                "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                 "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = a.cfg_pedido " +
                                 "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                // Configuracao fiscal de devolucao
                                 "|EXISTS|(select 1 from TB_FAT_CFG_PedFiscal x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido and x.TP_Fiscal = 'TF') ";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato_origem }, new TCD_CadContrato());
        }

        private void bb_contrato_destino_Click(object sender, EventArgs e)
        {
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa);" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                                "isnull(a.st_registro, 'A')|=|'A'";
            UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato_destino }, vParamFixo);
        }

        private void nr_contrato_destino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.NR_Contrato|=|" + nr_contrato_destino.Text + ";" +
                                        "isnull(a.st_registro, 'A')|=|'A';" + //Contrato Aberto
                //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                     "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))" +
                //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = cfgped.cfg_pedido " +
                                     "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato_destino }, new TCD_CadContrato());
        }

        private void gTransf_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTransf.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTransf.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Transferencia());
            TList_Transferencia lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTransf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTransf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Transferencia(lP.Find(gTransf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTransf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Transferencia(lP.Find(gTransf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTransf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTransf.List as TList_Transferencia).Sort(lComparer);
            bsTransf.ResetBindings(false);
            gTransf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void tcOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcOrigem.SelectedIndex.Equals(1))
                bsEstOrig.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.cd_produto = a.cd_produto " +
                                                            "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                            "and x.cd_empresa = '" + (bsOrigem.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + "' " +
                                                            "and x.nr_lanctofiscal = " + (bsOrigem.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString() + " " +
                                                            "and x.id_nfitem = " + (bsOrigem.Current as TRegistro_Transf_X_Contrato).ID_NFItem.ToString() + ")"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
            else bsEstOrig.Clear();
        }

        private void tcDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDestino.SelectedIndex.Equals(1))
                bsEstDest.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.cd_produto = a.cd_produto " +
                                                            "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                            "and x.cd_empresa = '" + (bsDestino.Current as TRegistro_Transf_X_Contrato).CD_Empresa.Trim() + "' " +
                                                            "and x.nr_lanctofiscal = " + (bsDestino.Current as TRegistro_Transf_X_Contrato).NR_LanctoFiscal.ToString() + " " +
                                                            "and x.id_nfitem = " + (bsDestino.Current as TRegistro_Transf_X_Contrato).ID_NFItem.ToString() + ")"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
            else bsEstDest.Clear();
        }
    }
}
