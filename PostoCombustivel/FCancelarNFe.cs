using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFCancelarNFe : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public bool St_nfce
        { get; set; }

        public TFCancelarNFe()
        {
            InitializeComponent();
        }

        private void CancelarNFe()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(cbSerie.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar serie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSerie.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_notafiscal.Text))
            {
                MessageBox.Show("Obrigatorio informar " + (St_nfce ? "NFCe" : "NFe") + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_notafiscal.Focus();
                return;
            }
            if (St_nfce)
            {
                CamadaDados.Faturamento.PDV.TList_NFCe lNFCe =
                    CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(string.Empty,
                                                                  nr_notafiscal.Text,
                                                                  cd_empresa.Text,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  decimal.Zero,
                                                                  decimal.Zero,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  cbSerie.SelectedValue.ToString(),
                                                                  string.Empty,
                                                                  false,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  1,
                                                                  null);
                if (lNFCe.Count > 0)
                {
                    List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida> lVenda = null;
                    if (lNFCe[0].St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string msg = string.Empty;
                    if (lNFCe[0].Id_contingencia.HasValue &&
                        !lNFCe[0].Nr_protocolo.HasValue)
                        msg = "NFCe emitida em CONTINGÊNCIA OFFLINE e ainda não transmitida para a receita.\r\n" +
                              "O cancelamento desta NFCe somente ocorrerá após o envio da mesma para receita.";
                    if (MessageBox.Show((string.IsNullOrEmpty(msg) ? string.Empty : msg + "\r\n") + "Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            bool st_cancelar = true;
                            //Verificar se o NFCe esta vinculado a NFe
                            object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                            new TpBusca[]
                                            {
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
                                                    vVL_Busca = "(select 1 from tb_fat_ecfvinculadoNF x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                                "and x.cd_empresa = '" + lNFCe[0].Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + lNFCe[0].Id_nfcestr + ")"
                                                }
                                            }, "a.nr_notafiscal");
                            if (obj != null)
                            {
                                MessageBox.Show("NFCe Nº" + lNFCe[0].Id_nfcestr + " esta vinculado a NFe Nº" + obj.ToString() + ".\r\n" +
                                                "Para cancelar NFCe obrigatório antes cancelar NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (lNFCe[0].Nr_protocolo.HasValue ||
                                lNFCe[0].Id_contingencia.HasValue)
                            {
                                string motivo = string.Empty;
                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                                CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                                //Verificar evento
                                CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                    CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(lNFCe[0].Cd_empresa,
                                                                                        lNFCe[0].Id_nfcestr,
                                                                                        string.Empty,
                                                                                        null);
                                if (lEvento.Count.Equals(0))
                                {
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        InputBox ibp = new InputBox();
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
                                    rEvento.Cd_empresa = lNFCe[0].Cd_empresa;
                                    rEvento.Id_cupom = lNFCe[0].Id_nfce;
                                    rEvento.Chave_acesso_nfce = lNFCe[0].Chave_acesso;
                                    rEvento.Nr_protocoloNFCe = lNFCe[0].Nr_protocolo;
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
                                    lNFCe[0].Nr_protocolo.HasValue)
                                {
                                    //Buscar CfgNfe para a empresa
                                    if (lCfg == null)
                                        lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNFCe[0].Cd_empresa,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNFCe[0].Cd_empresa.Trim() + ".",
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
                                if (!lNFCe[0].Nr_protocolo.HasValue &&
                                        !lNFCe[0].Id_contingencia.HasValue)
                                {
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfCe =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNFCe[0].Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfgNfCe.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração NFC-e para a empresa " + lNFCe[0].Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        //Consultar Chave
                                        string ret = NFCe.ConsultaChave.TConsultaChave.ConsultaChave(lNFCe[0].Chave_acesso,
                                                                                                     "1",
                                                                                                     lCfgNfCe[0]);
                                        if (!string.IsNullOrEmpty(ret))
                                        {
                                            MessageBox.Show("Não é permtido excluir cupom com chave de acesso existente na receita.\r\n" + ret, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                CamadaNegocio.Faturamento.PDV.TCN_NFCe.CancelarCF(lNFCe[0], null);
                                MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (!lNFCe[0].Nr_protocolo.HasValue &&
                                    !lNFCe[0].Id_contingencia.HasValue)
                                {
                                    CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(lNFCe[0].Nr_serie,
                                                                                                     lNFCe[0].Cd_modelo,
                                                                                                     lNFCe[0].Cd_empresa,
                                                                                                     null);
                                    if (lSeq.Count > 0)
                                        if (lSeq[0].Seq_NotaFiscal.Equals(lNFCe[0].NR_NFCe))
                                        {
                                            lSeq[0].Seq_NotaFiscal--;
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                            MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            //Buscar configuracao nfe
                                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNFCe[0].Cd_empresa,
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
                                                                                                     lNFCe[0].Nr_serie,
                                                                                                     lNFCe[0].Cd_modelo,
                                                                                                     DateTime.Now.Year.ToString(),
                                                                                                     lNFCe[0].NR_NFCe.Value,
                                                                                                     lNFCe[0].NR_NFCe.Value,
                                                                                                     "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFCe",
                                                                                                     lCfgNfe[0]);
                                                    MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                        }
                                }
                                Close();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else
            {
                CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(cd_empresa.Text,
                                                                              nr_notafiscal.Text,
                                                                              cbSerie.SelectedValue.ToString(),
                                                                              string.Empty,
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
                                                                              true,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              "S",
                                                                              string.Empty,
                                                                              "A",
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              "'P'",
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
                            //Cancelar pedido
                            CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca(lNf[0].Cd_empresa,
                                                                              string.Empty,
                                                                              lNf[0].Nr_pedidostring,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              string.Empty,
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
                                                                              false,
                                                                              1,
                                                                              string.Empty,
                                                                              null);
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(lPed[0], null);
                            //Cancelar venda rapida
                            CamadaDados.Faturamento.PDV.TList_VendaRapida lVenda =
                                new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_vendarapida = a.id_cupom  " +
                                                    "and x.nr_pedido = " + lNf[0].Nr_pedidostring + ")"
                                    }
                                }, 0, string.Empty, string.Empty);
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(lVenda, null);
                            Close();
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
                                            //Cancelar pedido
                                            CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                                                new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = lNf[0].Nr_pedidostring
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                                                "where x.nr_pedido = a.nr_pedido)"
                                                }
                                            }, 1, string.Empty);
                                            if (lPed.Count > 0)
                                            {
                                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(lPed[0], null);
                                                //Cancelar venda rapida
                                                CamadaDados.Faturamento.PDV.TList_VendaRapida lVenda =
                                                    new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.id_vendarapida = a.id_cupom  " +
                                                                        "and x.nr_pedido = " + lNf[0].Nr_pedidostring + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty);
                                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(lVenda, null);
                                            }
                                            //Cancelar venda rapida nota entrega futura
                                            CamadaDados.Faturamento.PDV.TList_VendaRapida lVendaEF =
                                                new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_vendarapida_x_entregafutura x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_cupom = a.id_cupom " +
                                                                    "and x.cd_empresa = '" + lNf[0].Cd_empresa.Trim() + "' " +
                                                                    "and x.nr_lanctofiscal = " + lNf[0].Nr_lanctofiscalstr + ")"
                                                    }
                                                }, 0, string.Empty, string.Empty);
                                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(lVendaEF, null);
                                            Close();
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
                                        //Cancelar pedido
                                        CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca(lNf[0].Cd_empresa,
                                                                                          string.Empty,
                                                                                          lNf[0].Nr_pedidostring,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          false,
                                                                                          string.Empty,
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
                                                                                          false,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          null);
                                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(lPed[0], null);
                                        //Cancelar venda rapida
                                        CamadaDados.Faturamento.PDV.TList_VendaRapida lVenda =
                                            new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom  " +
                                                                "and x.nr_pedido = " + lNf[0].Nr_pedidostring + ")"
                                                }
                                            }, 0, string.Empty, string.Empty);
                                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(lVenda, null);
                                        Close();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                }
            }
        }

        private void TFCancelarNFe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cd_empresa.Text = Cd_empresa;
            nm_empresa.Text = Nm_empresa;
            Text = St_nfce ? "Cancelar NFCe" : "Cancelar NFe";
            lblNumero.Text = St_nfce ? "Nº NFCe" : "Nº NFe";
            cbSerie.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(string.Empty, St_nfce ? "65" : "55", string.Empty, string.Empty, string.Empty, "S", string.Empty, null);
            cbSerie.ValueMember = "NR_Serie";
            cbSerie.DisplayMember = "DS_Serie";
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            CancelarNFe();
        }

        private void TFCancelarNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                CancelarNFe();
        }
    }
}
