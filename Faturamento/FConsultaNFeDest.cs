using CamadaDados.Diversos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Faturamento.NFE;
using CamadaNegocio.Faturamento.NFE;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using Utils;

namespace Faturamento
{
    public partial class TFConsultaNFeDest : Form
    {
        private TRegistro_CfgNfe rCfgNfe
        { get; set; }
        public TFConsultaNFeDest()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsConsultaDest.DataSource = TCN_ConsultaDest.Buscar(empresa.SelectedItem == null ? string.Empty : empresa.SelectedValue.ToString(),
                                                                string.Empty,
                                                                chaveBusca.Text,
                                                                emitenteBusca.Text,
                                                                dt_ini.Text,
                                                                dt_fin.Text,
                                                                true,
                                                                cbXmlBaixado.Checked ? "S" : cbXmlBaixar.Checked ? "N" : string.Empty,
                                                                cbXmlImportado.Checked ? "S" : cbXmlImportar.Checked ? "N" : string.Empty,
                                                                cbOpConfirmada.Checked ? "S" : cbConfirmarOp.Checked ? "N" : string.Empty,
                                                                null);
        }

        private void Consultar()
        {
            if (rCfgNfe == null)
            {
                MessageBox.Show("Não existe configuração NFe para a empresa selecionada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(!string.IsNullOrWhiteSpace(txtChaveAcesso.Text) && txtChaveAcesso.Text.Length < 44)
            {
                MessageBox.Show("Obrigatório informar chave de acesso valida para consultar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChaveAcesso.Clear();
                return;
            }
            if(txtChaveAcesso.Text.Trim().Length.Equals(44))
            {
                TList_ConsultaDest lista = TCN_ConsultaDest.Buscar(empresa.SelectedItem == null ? string.Empty : empresa.SelectedValue.ToString(),
                                                                   string.Empty,
                                                                   txtChaveAcesso.Text,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   true,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   null);
                if(lista.Count > 0)
                {
                    MessageBox.Show("Chave de acesso já existe na base Aliance.NET.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsConsultaDest.DataSource = lista;
                    return;
                }
            }
            try
            {
                TList_ConsultaDest lConsulta =
                    srvNFE.DistribuicaoDFe.TDistribuicaoDFe.DistribuicaoDFe(rCfgNfe,
                                                                            empresa.SelectedItem as TRegistro_CadEmpresa,
                                                                            string.Empty,
                                                                            string.IsNullOrWhiteSpace(txtChaveAcesso.Text) ? txtUltimoNSU.Text : string.Empty,
                                                                            txtChaveAcesso.Text);
                //Gravar consulta no banco
                lConsulta.ForEach(p => TCN_ConsultaDest.Gravar(p, null));
                bsConsultaDest.DataSource = lConsulta.Where(p => !string.IsNullOrEmpty(p.St_nfe)).ToList();
                //Buscar ultimo NSU consultado
                object obj = new TCD_ConsultaDest().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                                    }
                                }, "max(nsu)");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    txtUltimoNSU.Text = obj.ToString();
            }
            catch(Exception  ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ImportarXML()
        {
            if (bsConsultaDest.Current != null)
            {
                if(string.IsNullOrWhiteSpace((bsConsultaDest.Current as TRegistro_ConsultaDest).XML_NFe))
                {
                    MessageBox.Show("Registro não possui XML.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFImportarXMLNFe fImport = new TFImportarXMLNFe())
                {
                    fImport.Xml_nfe = (bsConsultaDest.Current as TRegistro_ConsultaDest).XML_NFe;
                    fImport.ShowDialog();
                }
            }
            else MessageBox.Show("Obrigatorio selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AtualizarCamposTela()
        {
            if (empresa.SelectedValue != null)
            {
                object obj = new TCD_CfgNfe().BuscarEscalar(
                                        new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                                }
                                }, "a.tp_ambiente + '-' + a.cd_versao");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                {
                    string[] part = obj.ToString().Split(new char[] { '-' });
                    lblAmbiente.Text = part[0].Trim().ToUpper().Equals("H") ? "HOMOLOGAÇÃO" : "PRODUÇÃO";
                    tsVersao.Text = part[1].Trim();
                }
                //Buscar ultimo NSU consultado
                obj = new TCD_ConsultaDest().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                        }
                    }, "max(nsu)");

                if (!string.IsNullOrEmpty(obj.ToString()))
                    txtUltimoNSU.Text = obj.ToString();
                else
                    txtUltimoNSU.Text = "";

                ConsultaStatusServico();
            }
        }

        private void ConsultaStatusServico()
        {
            if (empresa.SelectedItem != null)
            {
                TList_CfgNfe lista  = TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                        string.Empty,
                                                        string.Empty,
                                                        null);
                if (lista.Count > 0)
                {
                    rCfgNfe = lista[0];
                    string retorno = srvNFE.ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, false);
                    if (retorno.Trim().Equals("107"))
                        tsStatus.Text = "SERVIÇO EM OPERAÇÃO";
                    else
                    {
                        string ret_cont = srvNFE.ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, true);
                        if (ret_cont.Trim().Equals("107"))
                            tsStatus.Text = "SERVIÇO EM OPERAÇÃO - MODO CONTINGENCIA(" + rCfgNfe.Tipo_ambientecont.Trim() + ")";
                        else
                            tsStatus.Text = "SERVIÇO INDISPONIVEL NO MOMENTO.";
                    }
                }
            }
        }

        private void TFConsultaNFeDest_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            empresa.DataSource = new TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "EXISTS",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_cfgnfe x "+
                                                        "where x.cd_empresa = a.cd_empresa)"
                                        }
                                    }, 0, string.Empty);
            empresa.DisplayMember = "NM_Empresa";
            empresa.ValueMember = "CD_Empresa";
            if ((empresa.DataSource as TList_CadEmpresa).Count > 0)
            {
                empresa.SelectedIndex = 0;
                empresa_SelectedIndexChanged(this, new EventArgs());
            }
            ConsultaStatusServico();
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCamposTela();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bbConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void bbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbConfirma_Click(object sender, EventArgs e)
        {
            if (bsConsultaDest.Current != null)
            {
                TList_EventoNFe lEvento = new TCD_EventoNFe().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.chave_acesso",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "d.cd_evento",
                            vOperador = "=",
                            vVL_Busca = "'210200'"
                        }
                    }, 0, string.Empty);
                if(lEvento.Exists(p=> p.St_registro.Trim().ToUpper().Equals("T")))
                {
                    MessageBox.Show("NF-e já possui evento<CONFIRMAÇÃO DA OPERAÇÃO> transmitido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lEvento.Count > 0)
                {
                    if (rCfgNfe == null)
                        MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], rCfgNfe);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    //Buscar evento de Manifesto
                    TList_Evento lEvent = TCN_Evento.Buscar("210200",
                                                            string.Empty,
                                                            "MF",
                                                            null);
                    if (lEvent.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento <210200-CONFIRMAÇÃO DA OPERAÇÃO> configurado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TRegistro_EventoNFe rMan = new TRegistro_EventoNFe();
                    rMan.Cd_empresa = (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa;
                    rMan.Chave_acesso_nfe = (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso;
                    rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                    rMan.Cd_eventostr = lEvent[0].Cd_eventostr;
                    rMan.Descricao_evento = lEvent[0].Ds_evento;
                    rMan.Tp_evento = lEvent[0].Tp_evento;
                    rMan.St_registro = "A";
                    TCN_EventoNFe.Gravar(rMan, null);
                    if (MessageBox.Show("Evento gravado com sucesso.\r\n" +
                                            "Deseja enviar o mesmo para a receita?", "Pergunta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                    {
                        if (rCfgNfe == null)
                            MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            try
                            {
                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, rCfgNfe);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            else MessageBox.Show("Obrigatório selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbDesconhece_Click(object sender, EventArgs e)
        {
            if (bsConsultaDest.Current != null)
            {
                TList_EventoNFe lEvento = new TCD_EventoNFe().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.chave_acesso",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "d.cd_evento",
                            vOperador = "=",
                            vVL_Busca = "'210220'"
                        }
                    }, 0, string.Empty);
                if (lEvento.Exists(p => p.St_registro.Trim().ToUpper().Equals("T")))
                {
                    MessageBox.Show("NF-e já possui evento <DESCONHECIMENTO DA OPERAÇÃO> transmitido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lEvento.Count > 0)
                {
                    if (rCfgNfe == null)
                        MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], rCfgNfe);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("EVento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    //Buscar evento de Manifesto
                    TList_Evento lEvent = TCN_Evento.Buscar("210220",
                                                            string.Empty,
                                                            "MF",
                                                            null);
                    if (lEvent.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento <210220-DESCONHECIMENTO DA OPERAÇÃO> configurado..", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TRegistro_EventoNFe rMan = new TRegistro_EventoNFe();
                    rMan.Cd_empresa = (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa;
                    rMan.Chave_acesso_nfe = (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso;
                    rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                    rMan.Cd_eventostr = lEvent[0].Cd_eventostr;
                    rMan.Descricao_evento = lEvent[0].Ds_evento;
                    rMan.Tp_evento = lEvent[0].Tp_evento;
                    rMan.St_registro = "A";
                    TCN_EventoNFe.Gravar(rMan, null);
                    if (MessageBox.Show("Evento gravado com sucesso.\r\n" +
                                            "Deseja enviar o mesmo para a receita?", "Pergunta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                    {
                        if (rCfgNfe == null)
                            MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            try
                            {
                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, rCfgNfe);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            else MessageBox.Show("Obrigatório selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbNaoR_Click(object sender, EventArgs e)
        {
            if (bsConsultaDest.Current != null)
            {
                TList_EventoNFe lEvento = new TCD_EventoNFe().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.chave_acesso",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "d.cd_evento",
                            vOperador = "=",
                            vVL_Busca = "'210240'"
                        }
                    }, 0, string.Empty);
                if (lEvento.Exists(p => p.St_registro.Trim().ToUpper().Equals("T")))
                {
                    MessageBox.Show("NF-e já possui evento <OPERAÇÃO NÃO REALIZADA> transmitido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lEvento.Count > 0)
                {
                    if (rCfgNfe == null)
                        MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], rCfgNfe);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    //Buscar evento de Manifesto
                    TList_Evento lEvent = TCN_Evento.Buscar("210240",
                                                            string.Empty,
                                                            "MF",
                                                            null);
                    if (lEvent.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento <210240-OPERAÇÃO NÃO REALIZADA> configurado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InputBox inp = new InputBox(string.Empty, "Justificativa");
                    string ret = inp.Show();
                    if(ret.Trim().Length < 15)
                    {
                        MessageBox.Show("Obrigatório informar no minimo 15 caracteres na justificativa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TRegistro_EventoNFe rMan = new TRegistro_EventoNFe();
                    rMan.Cd_empresa = (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa;
                    rMan.Chave_acesso_nfe = (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso;
                    rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                    rMan.Cd_eventostr = lEvent[0].Cd_eventostr;
                    rMan.Descricao_evento = lEvent[0].Ds_evento;
                    rMan.Tp_evento = lEvent[0].Tp_evento;
                    rMan.Ds_evento = ret;
                    rMan.St_registro = "A";
                    TCN_EventoNFe.Gravar(rMan, null);
                    if (MessageBox.Show("Evento gravado com sucesso.\r\n" +
                                            "Deseja enviar o mesmo para a receita?", "Pergunta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                    {
                        if (rCfgNfe == null)
                            MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            try
                            {
                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, rCfgNfe);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            else MessageBox.Show("Obrigatório selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbCiencia_Click(object sender, EventArgs e)
        {
            if (bsConsultaDest.Current != null)
            {
                TList_EventoNFe lEvento = new TCD_EventoNFe().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.chave_acesso",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "d.cd_evento",
                            vOperador = "=",
                            vVL_Busca = "'210210'"
                        }
                    }, 0, string.Empty);
                if (lEvento.Exists(p => p.St_registro.Trim().ToUpper().Equals("T")))
                {
                    MessageBox.Show("NF-e já possui evento <CIENCIA DA OPERAÇÃO> transmitido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lEvento.Count > 0)
                {
                    if (rCfgNfe == null)
                        MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], rCfgNfe);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    //Buscar evento de Manifesto
                    TList_Evento lEvent = TCN_Evento.Buscar("210210",
                                                            string.Empty,
                                                            "MF",
                                                            null);
                    if (lEvent.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento <210210-CIENCIA DA OPERAÇÃO> configurado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TRegistro_EventoNFe rMan = new TRegistro_EventoNFe();
                    rMan.Cd_empresa = (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa;
                    rMan.Chave_acesso_nfe = (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso;
                    rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                    rMan.Cd_eventostr = lEvent[0].Cd_eventostr;
                    rMan.Descricao_evento = lEvent[0].Ds_evento;
                    rMan.Tp_evento = lEvent[0].Tp_evento;
                    rMan.St_registro = "A";
                    TCN_EventoNFe.Gravar(rMan, null);
                    if (MessageBox.Show("Evento gravado com sucesso.\r\n" +
                                            "Deseja enviar o mesmo para a receita?", "Pergunta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                    {
                        if (rCfgNfe == null)
                            MessageBox.Show("Não existe configuração para envio do evento para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            try
                            {
                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, rCfgNfe);
                                if (!string.IsNullOrEmpty(msg))
                                    MessageBox.Show("Erro ao enviar evento para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Evento enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            else MessageBox.Show("Obrigatório selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbDownload_Click(object sender, EventArgs e)
        {
            if (bsConsultaDest.Current != null)
            {
                if(!string.IsNullOrEmpty((bsConsultaDest.Current as TRegistro_ConsultaDest).XML_NFe))
                {
                    MessageBox.Show("Registro ja possui XML baixado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rCfgNfe == null)
                    MessageBox.Show("Não existe configuração para envio do Manifesto para a empresa " + (bsConsultaDest.Current as TRegistro_ConsultaDest).Cd_empresa.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    try
                    {
                        string xml =
                        srvNFE.DistribuicaoDFe.TDistribuicaoDFe.DownloadXML(rCfgNfe,
                                                                            empresa.SelectedItem as TRegistro_CadEmpresa,
                                                                            (bsConsultaDest.Current as TRegistro_ConsultaDest).chave_acesso);
                        if (xml.Contains("nfeProc"))
                        {
                            (bsConsultaDest.Current as TRegistro_ConsultaDest).XML_NFe = xml;
                            TCN_ConsultaDest.Gravar(bsConsultaDest.Current as TRegistro_ConsultaDest, null);
                            if (MessageBox.Show("XML baixado com sucesso.\r\nDeseja importar XML?", "Pergunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                ImportarXML();
                        }
                        else MessageBox.Show("Sem permissão para baixar XML. Verifique se foi feito Manifesto para a chave de acesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else MessageBox.Show("Obrigatório selecionar registro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbImportar_Click(object sender, EventArgs e)
        {
            ImportarXML();
        }

        private void cbXmlBaixado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXmlBaixado.Checked)
                cbXmlBaixar.Checked = false;
        }

        private void cbXmlBaixar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXmlBaixar.Checked)
                cbXmlBaixado.Checked = false;
        }

        private void cbXmlImportado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXmlImportado.Checked)
                cbXmlImportar.Checked = false;
        }

        private void cbXmlImportar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXmlImportar.Checked)
                cbXmlImportado.Checked = false;
        }

        private void cbConfirmarOp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirmarOp.Checked)
                cbOpConfirmada.Checked = false;
        }

        private void cbOpConfirmada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOpConfirmada.Checked)
                cbConfirmarOp.Checked = false;
        }
    }
}
