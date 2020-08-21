using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Frota;
using CamadaNegocio.Frota;

namespace Frota
{
    public partial class TFLanMDFe : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanMDFe()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            cd_empresa.Clear();
            nr_mdfe.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFMDFe fMdfe = new TFMDFe())
            {
                if(fMdfe.ShowDialog() == DialogResult.OK)
                    if(fMdfe.rMDFe != null)
                        try
                        {
                            TCN_MDFe.Gravar(fMdfe.rMDFe, null);
                            if(MessageBox.Show("MDF-e gravado com sucesso.\r\n" +
                                               "Deseja enviar a mesma para receita?", "Pergunta", 
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar(fMdfe.rMDFe.Cd_empresa,
                                                                                     null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + fMdfe.rMDFe.Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    MDFe.EnviaArq.TEnviaArq.EnviarLoteMDFe(new List<TRegistro_MDFe>() { fMdfe.rMDFe }, lCfg[0]);
                                    MessageBox.Show("Lote MDFe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Consultar Lote
                                    MDFe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                    LimparFiltros();
                                    cd_empresa.Text = fMdfe.rMDFe.Cd_empresa;
                                    nr_mdfe.Text = fMdfe.rMDFe.Nr_mdfestr;
                                    afterBusca();
                                    if (bsMDFe.Current != null)
                                        if ((bsMDFe.Current as TRegistro_MDFe).Status.ToString().Equals("100"))
                                            afterPrint();
                                        else
                                            using (Proc_Commoditties.TFPainelMDFe fPainel = new Proc_Commoditties.TFPainelMDFe())
                                            {
                                                fPainel.ShowDialog();
                                            }
                                    else
                                        using (Proc_Commoditties.TFPainelMDFe fPainel = new Proc_Commoditties.TFPainelMDFe())
                                        {
                                            fPainel.ShowDialog();
                                        }
                                }

                            }
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsMDFe.Current != null)
            {
                if ((bsMDFe.Current as TRegistro_MDFe).St_transmitido.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido corrigir MDF-e TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFMDFe fMDFe = new TFMDFe())
                {
                    fMDFe.rMDFe = bsMDFe.Current as TRegistro_MDFe;
                    if(fMDFe.ShowDialog() == DialogResult.OK)
                        if(fMDFe.rMDFe != null)
                            try
                            {
                                TCN_MDFe.Gravar(fMDFe.rMDFe, null);
                                if (MessageBox.Show("MDF-e corrigido com sucesso.\r\n" +
                                               "Deseja enviar a mesma para receita?", "Pergunta",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                        CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar(fMDFe.rMDFe.Cd_empresa,
                                                                                         null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + fMDFe.rMDFe.Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        MDFe.EnviaArq.TEnviaArq.EnviarLoteMDFe(new List<TRegistro_MDFe>() { fMDFe.rMDFe }, lCfg[0]);
                                        MessageBox.Show("Lote MDFe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Consultar Lote
                                        MDFe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                        LimparFiltros();
                                        cd_empresa.Text = fMDFe.rMDFe.Cd_empresa;
                                        nr_mdfe.Text = fMDFe.rMDFe.Nr_mdfestr;
                                        afterBusca();
                                        if (bsMDFe.Current != null)
                                            if ((bsMDFe.Current as TRegistro_MDFe).Status.ToString().Equals("100"))
                                                afterPrint();
                                            else
                                                using (Proc_Commoditties.TFPainelMDFe fPainel = new Proc_Commoditties.TFPainelMDFe())
                                                {
                                                    fPainel.ShowDialog();
                                                }
                                        else
                                            using (Proc_Commoditties.TFPainelMDFe fPainel = new Proc_Commoditties.TFPainelMDFe())
                                            {
                                                fPainel.ShowDialog();
                                            }
                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsMDFe.Current != null)
            {
                if ((bsMDFe.Current as TRegistro_MDFe).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("MDFe ja se encontra cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsMDFe.Current as CamadaDados.Frota.TRegistro_MDFe).Nr_protocolo))
                {
                    //Excluir CTe
                    if (MessageBox.Show("Confirma exclusão do MDFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        CamadaNegocio.Frota.TCN_MDFe.Excluir(bsMDFe.Current as TRegistro_MDFe, null);
                        MessageBox.Show("MDFe excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca((bsMDFe.Current as TRegistro_MDFe).Nr_serie,
                                                                                         (bsMDFe.Current as TRegistro_MDFe).Cd_modelo,
                                                                                         (bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                         null);
                        if (lSeq.Count > 0)
                            if (lSeq[0].Seq_NotaFiscal.Equals((bsMDFe.Current as TRegistro_MDFe).Nr_mdfe.Value))
                            {
                                lSeq[0].Seq_NotaFiscal--;
                                CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        afterBusca();
                    }
                }
                else
                {
                    //Cancelar CTe
                    if (MessageBox.Show("Confirma cancelamento MDFe?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        //Verificar se CTe ja nao foi cancelado junto a receita
                        CamadaDados.Frota.TList_MDFe_Evento lEvento =
                            CamadaNegocio.Frota.TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                       (bsMDFe.Current as TRegistro_MDFe).Nr_mdfestr,
                                                                       "CA",
                                                                       string.Empty,
                                                                       null);
                        if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                        {
                            //Cancelar somente CTe no Aliance.NET
                            CamadaNegocio.Frota.TCN_MDFe.Cancelar((bsMDFe.Current as TRegistro_MDFe), null);
                            MessageBox.Show("MDFe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        else
                        {
                            if (lEvento.Count.Equals(0))
                            {
                                InputBox ibp = new InputBox();
                                ibp.Text = "Motivo Cancelamento MDFe";
                                string motivo = ibp.ShowDialog();
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    MessageBox.Show("Obrigatorio informar motivo de cancelamento do MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    MessageBox.Show("Não existe evento de CANCELAMENTO MDFe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar CTe Receita
                                TRegistro_MDFe_Evento rEvento = new TRegistro_MDFe_Evento();
                                rEvento.Cd_empresa = (bsMDFe.Current as TRegistro_MDFe).Cd_empresa;
                                rEvento.Id_mdfe = (bsMDFe.Current as TRegistro_MDFe).Id_mdfe;
                                rEvento.Chaveacesso = (bsMDFe.Current as TRegistro_MDFe).Chaveacesso;
                                rEvento.Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Ds_evento = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Justificativa = motivo;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                                if (MessageBox.Show("Evento de CANCELAMENTO gravado com sucesso.\r\n" +
                                                    "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                {
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                        CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                         null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(rEvento, lCfg[0]);
                                        if (!string.IsNullOrEmpty(msg))
                                            MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                            "Aguarde um tempo e tente novamente.\r\n" +
                                                            "Erro: " + msg.Trim() + "\r\n" +
                                                            "Obs.: O MDFe não será cancelado no sistema Aliance.NET enquanto o mesmo não for cancelado junto a receita.",
                                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        else
                                        {
                                            MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            TCN_MDFe.Cancelar(bsMDFe.Current as TRegistro_MDFe, null);
                                            MessageBox.Show("MDFe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            afterBusca();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                     null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    lEvento[0].Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                                    string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(msg))
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + msg.Trim() + "\r\n" +
                                                        "Obs.: O MDFe não será cancelado no sistema Aliance.NET enquanto o mesmo não for cancelado junto a receita.",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CamadaNegocio.Frota.TCN_MDFe.Cancelar(bsMDFe.Current as TRegistro_MDFe, null);
                                        MessageBox.Show("MDFe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void afterBusca()
        {
            bsMDFe.DataSource = TCN_MDFe.Buscar(cd_empresa.Text,
                                                string.Empty,
                                                nr_mdfe.Text,
                                                string.Empty,
                                                string.Empty,
                                                dt_ini.Text,
                                                dt_fin.Text,
                                                cbStatus.SelectedIndex == 1 ? "'A'" : 
                                                cbStatus.SelectedIndex == 2 ? "'C'" : 
                                                cbStatus.SelectedIndex == 3 ? "'E'" : string.Empty,
                                                cbStatusRec.SelectedIndex == 1 ? "T" : cbStatusRec.SelectedIndex == 2 ? "N" : string.Empty,
                                                string.Empty,
                                                id_veiculo.Text,
                                                cd_motorista.Text,
                                                null);
            bsMDFe_PositionChanged(this, new EventArgs());
        }

        private void EncerrarMDFe()
        {
            if (bsMDFe.Current != null)
            {
                if ((bsMDFe.Current as TRegistro_MDFe).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido ENCERRAR MDFe CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMDFe.Current as TRegistro_MDFe).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("MDFe já se encontra ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Cancelar CTe
                if (MessageBox.Show("Confirma encerramento MDFe?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Verificar se CTe ja nao foi encerrado junto a receita
                    CamadaDados.Frota.TList_MDFe_Evento lEvento =
                        CamadaNegocio.Frota.TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                   (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                   "EC",
                                                                   string.Empty,
                                                                   null);
                    if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                    {
                        //Encerrar somente CTe no Aliance.NET
                        CamadaNegocio.Frota.TCN_MDFe.Encerrar((bsMDFe.Current as TRegistro_MDFe), null);
                        MessageBox.Show("MDFe encerrado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    else
                    {
                        if (lEvento.Count.Equals(0))
                        {
                            string vColunas = "a.ds_cidade|Cidade|200;a.uf|UF|30;a.cd_cidade|Código|60;a.cd_uf|Cd. UF|60";
                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
                            if (linha == null)
                            {
                                MessageBox.Show("Obrigótio selecinar cidade de encerramento do MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Buscar evento Encerramento
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                                CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "EC", null);
                            if (lEv.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe evento de ENCERRAMENTO MDFe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Encerrar MDFe Receita
                            TRegistro_MDFe_Evento rEvento = new TRegistro_MDFe_Evento();
                            rEvento.Cd_empresa = (bsMDFe.Current as TRegistro_MDFe).Cd_empresa;
                            rEvento.Id_mdfe = (bsMDFe.Current as TRegistro_MDFe).Id_mdfe;
                            rEvento.Chaveacesso = (bsMDFe.Current as TRegistro_MDFe).Chaveacesso;
                            rEvento.Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                            rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                            rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                            rEvento.Ds_evento = lEv[0].Ds_evento;
                            rEvento.Tp_evento = lEv[0].Tp_evento;
                            rEvento.Cd_cidadeEnc = linha["cd_cidade"].ToString();
                            rEvento.Ds_cidadeEnc = linha["ds_cidade"].ToString();
                            rEvento.Cd_ufEnc = linha["cd_uf"].ToString();
                            rEvento.Uf_enc = linha["uf"].ToString();
                            rEvento.St_registro = "A";
                            CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                            if (MessageBox.Show("Evento de ENCERRAMENTO gravado com sucesso.\r\n" +
                                                "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                     null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(rEvento, lCfg[0]);
                                    if (!string.IsNullOrEmpty(msg))
                                        MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + msg.Trim() + "\r\n" +
                                                        "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        TCN_MDFe.Encerrar(bsMDFe.Current as TRegistro_MDFe, null);
                                        MessageBox.Show("MDFe encerrado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Buscar CfgNfe para a empresa
                            CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                 null);
                            if (lCfg.Count.Equals(0))
                                MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                lEvento[0].Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                                string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(lEvento[0], lCfg[0]);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                                    "Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim() + "\r\n" +
                                                    "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                {
                                    MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CamadaNegocio.Frota.TCN_MDFe.Encerrar(bsMDFe.Current as TRegistro_MDFe, null);
                                    MessageBox.Show("MDFe encerrado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void IncluirMotMDFe()
        {
            if (bsMDFe.Current != null)
            {
                if ((bsMDFe.Current as TRegistro_MDFe).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido INCLUIR CONDUTOR MDFe CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMDFe.Current as TRegistro_MDFe).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido INCLUIR CONDUTOR MDFe ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar evento Inclusao Condutor
                CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                    CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "IC", null);
                if (lEv.Count.Equals(0))
                {
                    MessageBox.Show("Não existe evento de INCLUSÃO CONDUTOR MDFe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                                "|not exists|(select 1 from tb_ctr_mdfe_x_motorista x " +
                                "               where x.cd_motorista = a.cd_clifor " +
                                "               and x.cd_empresa = '" + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + "' " +
                                "               and x.id_mdfe = " + (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr + ");" +
                                "|not exists|(select 1 from tb_ctr_mdfe_evento x " +
                                "               where x.cd_motorista = a.cd_clifor " +
                                "               and x.cd_empresa = '" + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + "' " +
                                "               and x.id_mdfe = " + (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr + ")";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, vParam);
                if (linha == null)
                {
                    MessageBox.Show("Obrigatório selecionar motorista para incluir no MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                //Incluir Condutor MDFe Receita
                TRegistro_MDFe_Evento rEvento = new TRegistro_MDFe_Evento();
                rEvento.Cd_empresa = (bsMDFe.Current as TRegistro_MDFe).Cd_empresa;
                rEvento.Id_mdfe = (bsMDFe.Current as TRegistro_MDFe).Id_mdfe;
                rEvento.Chaveacesso = (bsMDFe.Current as TRegistro_MDFe).Chaveacesso;
                rEvento.Nr_protocoloMDFe = (bsMDFe.Current as TRegistro_MDFe).Nr_protocolo;
                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                rEvento.Ds_evento = lEv[0].Ds_evento;
                rEvento.Tp_evento = lEv[0].Tp_evento;
                rEvento.Cd_motorista = linha["cd_clifor"].ToString();
                rEvento.Nm_motorista = linha["nm_clifor"].ToString();
                rEvento.Cpf_motorista = linha["nr_cpf"].ToString();
                rEvento.St_registro = "A";
                CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                if (MessageBox.Show("Evento de INCLUSÃO MOTORISTA gravado com sucesso.\r\n" +
                                    "Deseja enviar o mesmo para a receita?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    //Buscar CfgNfe para a empresa
                    CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                        CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                         null);
                    if (lCfg.Count.Equals(0))
                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(rEvento, lCfg[0]);
                        if (!string.IsNullOrEmpty(msg))
                            MessageBox.Show("Erro ao enviar evento ENCERRAMENTO para a receita.\r\n" +
                                            "Aguarde um tempo e tente novamente.\r\n" +
                                            "Erro: " + msg.Trim() + "\r\n" +
                                            "Obs.: O MDFe não será encerrado no sistema Aliance.NET enquanto o mesmo não for encerrado na receita.",
                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Evento registrado e vinculado a MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                    }
                }
            }
        }

        private void afterPrint()
        {
            if (bsMDFe.Current != null)
            {
                if (string.IsNullOrEmpty((bsMDFe.Current as TRegistro_MDFe).Nr_protocolo))
                {
                    MessageBox.Show("Permitido imprimir DAMDFE somente de MDF-e aceito pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BinDados = new BindingSource();
                    BinDados.DataSource = new TList_MDFe() { bsMDFe.Current as TRegistro_MDFe };
                    Rel.DTS_Relatorio = BinDados;
                    //Buscar Empresa
                    BindingSource bs_empresa = new BindingSource();
                    bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    Rel.Adiciona_DataSource("EMPRESA", bs_empresa);
                    //Parametro RNTRC
                    object obj_rntrc = new CamadaDados.Frota.Cadastros.TCD_CfgFrota().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.rntrc");
                    if (obj_rntrc != null)
                        Rel.Parametros_Relatorio.Add("RNTRC", obj_rntrc.ToString());
                    if (bsVeic.Count > 0)
                        for (int i = 0; i < bsVeic.Count; i++)
                        {
                            if (i < 4)
                            {
                                Rel.Parametros_Relatorio.Add("PLACA" + (i + 1).ToString(), (bsVeic.List as TList_MDFe_Veiculo)[i].Placa);
                                Rel.Parametros_Relatorio.Add("RNTRC" + (i + 1).ToString(), (bsVeic.List as TList_MDFe_Veiculo)[i].rVeic.Rntrc_prop);
                            }
                            else
                                break;
                        }
                    int index = 0;
                    if (bsMot.Count > 0)
                        while (index < 8 && index < bsMot.Count)
                        {
                            Rel.Parametros_Relatorio.Add("NOME" + (index + 1).ToString(), (bsMot.List as TList_MDFe_Motorista)[index].Nm_motorista.Trim());
                            Rel.Parametros_Relatorio.Add("CPF" + (index + 1).ToString(), (bsMot.List as TList_MDFe_Motorista)[index].Cpf_motorista.Trim());
                            index++;
                        }
                    if (index < 8)
                    {
                        if (bsEvento.Count > 0)
                        {
                            List<TRegistro_MDFe_Evento> lEvent = (bsEvento.List as TList_MDFe_Evento).FindAll(p => p.St_registro.Trim().ToUpper().Equals("T") && p.Tp_evento.Trim().ToUpper().Equals("IC"));
                            if (lEvent.Count > 0)
                            {
                                int i = 0;
                                while (index < 8 && i < lEvent.Count)
                                {
                                    Rel.Parametros_Relatorio.Add("NOME" + (index + 1).ToString(), lEvent[i].Nm_motorista.Trim());
                                    Rel.Parametros_Relatorio.Add("CPF" + (index + 1).ToString(), lEvent[i].Cpf_motorista.Trim());
                                    index++;
                                    i++;
                                }
                            }
                        }
                    }
                    //Parametros Documentos
                    if (bsDoc.Count > 0)
                    {
                        Rel.Parametros_Relatorio.Add("QTD_CTE", (bsDoc.List as TList_MDFe_Documentos).Count(p => !string.IsNullOrEmpty(p.ChaveCTe)));
                        Rel.Parametros_Relatorio.Add("QTD_NFE", (bsDoc.List as TList_MDFe_Documentos).Count(p => !string.IsNullOrEmpty(p.ChaveNFe)));
                        Rel.Parametros_Relatorio.Add("PESO", (bsDoc.List as TList_MDFe_Documentos).Sum(p => p.PesoBrutoNFe));
                        for (int i = 0; i < (bsDoc.List as TList_MDFe_Documentos).Count; i++)
                            if (i >= 8)
                                break;
                            else
                                Rel.Parametros_Relatorio.Add("CHAVE" + (i + 1).ToString(), string.IsNullOrEmpty((bsDoc.List as TList_MDFe_Documentos)[i].ChaveCTe) ? (bsDoc.List as TList_MDFe_Documentos)[i].ChaveNFe : (bsDoc.List as TList_MDFe_Documentos)[i].ChaveCTe);
                    }
                    Rel.Nome_Relatorio = "TFLanMDFe_DAMDFe";
                    Rel.NM_Classe = "TFLanMDFe";
                    Rel.Modulo = "FRT";
                    Rel.Ident = "TFLanMDFe_DAMDFe";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "DAMDFe";
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
                                           "DAMDFe",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                    {
                        List<string> Anexo = null;
                        if (fImp.St_receberXmlNfe)
                        {
                            string path_anexo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                            if (!string.IsNullOrEmpty(path_anexo))
                            {
                                if (!System.IO.Directory.Exists(path_anexo))
                                    System.IO.Directory.CreateDirectory(path_anexo);
                                if (!path_anexo.EndsWith("\\"))
                                    path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                            }
                        }
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           Anexo,
                                           "MDFe",
                                           fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void TFLanMDFe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbStatus.SelectedIndex = 0;
            cbStatusRec.SelectedIndex = 0;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bsMDFe_PositionChanged(object sender, EventArgs e)
        {
            if (bsMDFe.Current != null)
            {
                (bsMDFe.Current as TRegistro_MDFe).lVeic = TCN_MDFe_Veiculo.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                   (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                   null);
                (bsMDFe.Current as TRegistro_MDFe).lMot = TCN_MDFe_Motorista.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                    (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                    null);
                (bsMDFe.Current as TRegistro_MDFe).lDoc = TCN_MDFe_Documentos.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                     (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                     null);
                (bsMDFe.Current as TRegistro_MDFe).lMunCar = TCN_MDFe_MunCarrega.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                        (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                        null);
                (bsMDFe.Current as TRegistro_MDFe).lUfPerc = TCN_MDFe_UfPercurso.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                        (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                        null);
                (bsMDFe.Current as TRegistro_MDFe).lSeguro = TCN_MDFe_Seguro.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                    (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                    null);
                (bsMDFe.Current as TRegistro_MDFe).lEventos = TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                                     (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     null);
                bsMDFe.ResetCurrentItem();
            }
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
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_dacte_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_listaCTe_Click(object sender, EventArgs e)
        {
            if (bsMDFe.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = "TFLanMDFe";
                    Rel.Ident = "TFLanMDFe";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    Rel.DTS_Relatorio = bsMDFe;

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void bb_MDFe_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFPainelMDFe fPainel = new Proc_Commoditties.TFPainelMDFe())
            {
                fPainel.ShowDialog();
            }
        }

        private void bb_exclui_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Frota.TRegistro_MDFe_Evento).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido excluir evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do evento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_MDFe_Evento.Excluir(bsEvento.Current as CamadaDados.Frota.TRegistro_MDFe_Evento, null);
                        MessageBox.Show("Evento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsEvento.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_enviarevento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as TRegistro_MDFe_Evento).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvento.Current as TRegistro_MDFe_Evento).Tp_evento.Trim().ToUpper().Equals("CA"))
                    afterExclui();
                else
                {
                    //Buscar configuracao cte
                    CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfgCte =
                        CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                         null);
                    if (lCfgCte.Count.Equals(0))
                        MessageBox.Show("Não existe configuração para envio de EVENTO para a empresa " + (bsMDFe.Current as TRegistro_MDFe).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = MDFe.Evento.TEventoMDFe.EnviarEvento(bsEvento.Current as TRegistro_MDFe_Evento, lCfgCte[0]);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro enviar evento: " + msg.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                MessageBox.Show("EVENTO enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsMDFe.Current as TRegistro_MDFe).lEventos =
                                CamadaNegocio.Frota.TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_MDFe).Cd_empresa,
                                                                           (bsMDFe.Current as TRegistro_MDFe).Id_mdfestr,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
                                bsMDFe.ResetCurrentItem();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void gMDFe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gMDFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gMDFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gMDFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bbEncerrar_Click(object sender, EventArgs e)
        {
            EncerrarMDFe();
        }

        private void bbAddMot_Click(object sender, EventArgs e)
        {
            IncluirMotMDFe();
        }

        private void TFLanMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                EncerrarMDFe();
            else if (e.KeyCode.Equals(Keys.F10))
                IncluirMotMDFe();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbVeiculo_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.placa|Placa|60;a.ds_veiculo|Veiculo|150;a.ID_veiculo|Código|50", new Componentes.EditDefault[] { id_veiculo },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), string.Empty);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_veiculo|=|" + id_veiculo.Text,
                new Componentes.EditDefault[] { id_veiculo }, new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bbMotorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, "isnull(a.st_motorista, 'N')|=|'S'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';isnull(a.st_motorista, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_motorista }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
