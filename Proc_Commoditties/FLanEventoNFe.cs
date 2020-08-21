using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFLanEventoNFe : Form
    {
        public CamadaDados.Faturamento.NFE.TRegistro_LanLoteNFE_X_NotaFiscal rNfe
        { get; set; }

        public bool Altera_Relatorio = false;

        public TFLanEventoNFe()
        {
            InitializeComponent();
        }

        private void EmitirCCe()
        {
            if (rNfe != null)
                if (rNfe.Status.Value.Equals(100))
                {
                    //Buscar evento Carta Correcao
                    CamadaDados.Faturamento.Cadastros.TList_Evento lEvento =
                        CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CC", null);
                    if (lEvento.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento de CARTA CORREÇÃO cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFCartaCorrecaoEletronica fCCe = new TFCartaCorrecaoEletronica())
                    {
                        if (fCCe.ShowDialog() == DialogResult.OK)
                            try
                            {
                                CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rCCe = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                rCCe.Cd_empresa = rNfe.Cd_empresa;
                                rCCe.Nr_lanctofiscal = rNfe.Nr_lanctofiscal;
                                rCCe.Chave_acesso_nfe = rNfe.Chave_acesso_nfe;
                                rCCe.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rCCe.Ds_evento = fCCe.Ds_correcao;
                                rCCe.Cd_eventostr = lEvento[0].Cd_eventostr;
                                rCCe.Descricao_evento = lEvento[0].Ds_evento;
                                rCCe.Tp_evento = lEvento[0].Tp_evento;
                                rCCe.St_registro = "A";
                                CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rCCe, null);
                                if (MessageBox.Show("Carta correção eletronica gravada com sucesso.\r\n" +
                                                "Deseja enviar a mesma para a receita?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                {
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rNfe.Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de CCe para a empresa " + rNfe.Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        try
                                        {
                                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rCCe, lCfg[0]);
                                            if (!string.IsNullOrEmpty(msg))
                                                MessageBox.Show("Erro ao enviar CCe para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            else
                                            {
                                                MessageBox.Show("CCe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.ImprimirEventoCCe();
                                            }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                                bsEventoNFe.DataSource = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                                            rNfe.Cd_empresa,
                                                                                                            rNfe.Nr_lanctofiscal.ToString(),
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            "CC",
                                                                                                            string.Empty,
                                                                                                            null);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
        }

        private void EnviarCCe()
        {
            if (bsEventoNFe.Current != null)
            {
                if ((bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Evento ja esta TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar CfgNfe para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rNfe.Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfg.Count.Equals(0))
                    MessageBox.Show("Não existe configuração para envio de CCe para a empresa " + rNfe.Cd_empresa.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    try
                    {
                    string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe, lCfg[0]);
                        if (!string.IsNullOrEmpty(msg))
                            MessageBox.Show("Erro ao enviar CCe para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                            "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("CCe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsEventoNFe.DataSource = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                                        rNfe.Cd_empresa,
                                                                                                        rNfe.Nr_lanctofiscal.ToString(),
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        "CC",
                                                                                                        string.Empty,
                                                                                                        null);
                            this.ImprimirEventoCCe();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ImprimirEventoCCe()
        {
            if (bsEventoNFe.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Evento = new FormRelPadrao.Relatorio();
                    Evento.Altera_Relatorio = Altera_Relatorio;

                    BindingSource Bin = new BindingSource();
                    Bin.DataSource = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(
                                                    (bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa,
                                                    string.Empty,
                                                    string.Empty,
                                                    (bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Nr_lanctofiscalstr,
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
                                                    0,
                                                    string.Empty,
                                                    null);
                    //Buscar Carta Correção
                    BindingSource binCCe = new BindingSource();
                    binCCe.DataSource = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar((bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Id_eventostr,
                                                                                           (bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa,
                                                                                           (bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Nr_lanctofiscalstr,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           "CC",
                                                                                           string.Empty,
                                                                                           null);
                    Evento.Adiciona_DataSource("CCe", binCCe);

                    Evento.Nome_Relatorio = "TFLanFaturamento_Evento";
                    Evento.NM_Classe = "TFLanFaturamento";
                    Evento.Modulo = "FAT";
                    Evento.Ident = "TFLanFaturamento_Evento";
                    Evento.DTS_Relatorio = Bin;
                    fImp.pMensagem = "CARTA CORREÇÃO";
                    //Verificar se existe logo configurada para a empresa
                    object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsEventoNFe.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa.Trim() + "'"
                                                }
                                            }, "a.logoEmpresa");
                    if (log != null)
                        Evento.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);


                    if (Altera_Relatorio)
                    {
                        Evento.Gera_Relatorio(string.Empty,
                                              fImp.pSt_imprimir,
                                              fImp.pSt_visualizar,
                                              fImp.pSt_enviaremail,
                                              fImp.pSt_exportPdf,
                                              fImp.Path_exportPdf,
                                              fImp.pDestinatarios,
                                              null,
                                              "CARTA DE CORREÇÃO",
                                              fImp.pDs_mensagem);

                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Evento.Gera_Relatorio(string.Empty,
                                                  fImp.pSt_imprimir,
                                                  fImp.pSt_visualizar,
                                                  fImp.pSt_enviaremail,
                                                  fImp.pSt_exportPdf,
                                                  fImp.Path_exportPdf,
                                                  fImp.pDestinatarios,
                                                  null,
                                                  "CARTA DE CORREÇÃO",
                                                  fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Evento!");

        }

        private void TFLanEventoNFe_Load(object sender, EventArgs e)
        {
            bsEventoNFe.DataSource = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                        rNfe.Cd_empresa,
                                                                                        rNfe.Nr_lanctofiscal.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        "CC",
                                                                                        string.Empty,
                                                                                        null);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.EmitirCCe();
        }

        private void bb_enviarevento_Click(object sender, EventArgs e)
        {
            this.EnviarCCe();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanEventoNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.EmitirCCe();
            else if (e.KeyCode.Equals(Keys.F3))
                this.EnviarCCe();
        }
    }
}
