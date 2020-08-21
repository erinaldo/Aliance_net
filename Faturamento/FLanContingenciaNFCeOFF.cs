using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLanContingenciaNFCeOFF : Form
    {
        public TFLanContingenciaNFCeOFF()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (Proc_Commoditties.TFContingenciaNFCeOFF fContingencia = new Proc_Commoditties.TFContingenciaNFCeOFF())
            {
                if(fContingencia.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.Gravar(fContingencia.lPDV,
                                                                                     fContingencia.pCd_empresa,
                                                                                     fContingencia.pJustificativa,
                                                                                     null);
                        MessageBox.Show("Contingência gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void SairContingencia()
        {
            using (Proc_Commoditties.TFSairContingenciaNFCeOFF fSairCont = new Proc_Commoditties.TFSairContingenciaNFCeOFF())
            {
                if(fSairCont.ShowDialog() == DialogResult.OK)
                    if(fSairCont.lContingencia != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.SairContingencia(fSairCont.lContingencia, null);
                            MessageBox.Show("Contingência alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            if (st_aberto.Checked)
                status = "'A'";
            if (st_finalizado.Checked)
                status += (string.IsNullOrEmpty(status) ? string.Empty : ",") + "'F'";
            bsContingencia.DataSource = CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.Buscar(cd_empresa.Text,
                                                                                                     id_pdv.Text,
                                                                                                     status,
                                                                                                     null);
        }

        private void TFLanContingenciaNFCeOFF_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            SairContingencia();
        }

        private void TFLanContingenciaNFCeOFF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                SairContingencia();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpNFCe))
                if (bsContingencia.Current != null)
                    bsNFCeEnviar.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Id_pdvstr,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Id_contingenciastr,
                                                                                            false,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            0,
                                                                                            null);
                else bsNFCeEnviar.Clear();
        }

        private void gNFCeEnviar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(1))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gNFCeEnviar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gNFCeEnviar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gNFCeEnviar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_processar)
                {
                    if ((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_transmitidonfce)
                        MessageBox.Show("NFCe ja foi transmitido para receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_processar = true;
                        bsNFCeEnviar.ResetCurrentItem();
                    }
                }
                else
                {
                    (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_processar = false;
                    bsNFCeEnviar.ResetCurrentItem();
                }
            }
        }

        private void bbEnvNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Count > 0)
            {
                //Buscar CfgNfe
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfgNfe.Count > 0)
                {
                    List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lNFCEnviar = new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe>();
                    if (bsNFCeEnviar.Count > 0)
                        if ((bsNFCeEnviar.List as CamadaDados.Faturamento.PDV.TList_NFCe).Exists(p => p.St_processar))
                            (bsNFCeEnviar.List as CamadaDados.Faturamento.PDV.TList_NFCe).FindAll(p => p.St_processar).Take(50).ToList().ForEach(p =>
                                lNFCEnviar.Add(CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(p.Cd_empresa, p.Id_nfcestr, null)));
                    //Gerar e assinar Arquivos xml
                    try
                    {
                        NFCe.EnviaArq.TEnviaArq.EnviarLote(null, lNFCEnviar);
                        if (lNFCEnviar.Count > 1)
                        {
                            System.Threading.Thread.Sleep(1000);
                            try
                            {
                                NFCe.RetAutoriza.TRetAutoriza.ConsultaNFERecepcao(lCfgNfe[0]);
                            }
                            catch { }
                        }
                        bsNFCeEnviar.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(string.Empty,
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
                                                                                                (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Id_contingenciastr,
                                                                                                false,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                0,
                                                                                                null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro enviar NF-e: " + ex.Message);
                    }
                }
                else MessageBox.Show("Não existe configuração para emitir NFCe na empresa " + (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Cd_empresa + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbConsultarLote_Click(object sender, EventArgs e)
        {
            if (bsContingencia.Current != null)
            {
                //Buscar CfgNfe
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfgNfe.Count > 0)
                {
                    try
                    {
                        NFCe.RetAutoriza.TRetAutoriza.ConsultaNFERecepcao(lCfgNfe[0]);
                        bsNFCeEnviar.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(string.Empty,
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
                                                                                                (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Id_contingenciastr,
                                                                                                false,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                0,
                                                                                                null);
                    }
                    catch { }
                }
                else MessageBox.Show("Não existe configuração para emitir NFCe na empresa " + (bsContingencia.Current as CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF).Cd_empresa + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbEnvEventoNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Current != null)
            {
                if ((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_registro.Trim().ToUpper().Equals("C") &&
                    (!(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue ||
                    ((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                     (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).St_transmitidocancnfce)))
                {
                    MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string msg = string.Empty;
                if ((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                    !(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_protocolo.HasValue)
                    msg = "NFCe emitida em CONTINGÊNCIA OFFLINE e ainda não transmitida para a receita.\r\n" +
                          "O cancelamento desta NFCe somente ocorrerá após o envio da mesma para receita.";
                if (MessageBox.Show((string.IsNullOrEmpty(msg) ? string.Empty : msg + "\r\n") + "Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        bool st_cancelar = true;
                        if ((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_protocolo.HasValue ||
                            (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
                        {
                            string motivo = string.Empty;
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                            //Verificar evento
                            CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                    (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                    string.Empty,
                                                                                    null);
                            if (lEvento.Count.Equals(0))
                            {
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    Utils.InputBox ibp = new Utils.InputBox();
                                    ibp.Text = "Motivo Cancelamento NFCe";
                                    motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe rEvento = new CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe();
                                rEvento.Cd_empresa = (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa;
                                rEvento.Id_cupom = (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfce;
                                rEvento.Chave_acesso_nfce = (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Chave_acesso;
                                rEvento.Nr_protocoloNFCe = (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Justificativa = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Gravar(rEvento, null);
                                lEvento.Add(rEvento);
                            }
                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T") &&
                                (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_protocolo.HasValue)
                            {
                                //Buscar CfgNfe para a empresa
                                if (lCfg == null)
                                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    msg = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lCfg[0]);
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
                        if (st_cancelar)
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe.CancelarCF(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe, null);
                            MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_protocolo.HasValue &&
                                !(bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
                            {
                                CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_serie,
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_modelo,
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                 null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).NR_NFCe))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                                        if (lCfgNfe.Count > 0)
                                        {
                                            try
                                            {
                                                //Inutilizar numero nota
                                                NFCe.InutilizaNFCe.TInutilizaNFCe.InutilizarNFCe(lCfgNfe[0].Cd_uf_empresa,
                                                                                                 lCfgNfe[0].Cnpj_empresa,
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Nr_serie,
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_modelo,
                                                                                                 DateTime.Now.Year.ToString(),
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).NR_NFCe.Value,
                                                                                                 (bsNFCeEnviar.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).NR_NFCe.Value,
                                                                                                 "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFCe",
                                                                                                 lCfgNfe[0]);
                                                MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                            }
                            afterBusca();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void gContingencia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADO"))
                        gContingencia.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gContingencia.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}
