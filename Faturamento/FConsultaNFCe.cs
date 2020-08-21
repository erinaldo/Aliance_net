using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
using System;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFConsultaNFCe : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaNFCe()
        {
            InitializeComponent();
        }

        private void afterExclui()
        {
            if (bsNFCe.Current != null)
            {
                if ((bsNFCe.Current as TRegistro_NFCe).St_registro.Trim().ToUpper().Equals("C") &&
                    (!(bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue ||
                    ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                        (bsNFCe.Current as TRegistro_NFCe).St_transmitidocancnfce)))
                {
                    MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                    !(bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue)
                {
                    MessageBox.Show("Não é permitido CANCELAR NFC-e emitida em CONTINGÊNCIA OFFLINE sem antes transmitir a mesma para receita.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Verificar se NFCe não esta vinculada a NFe
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_ECFVinculadoNF().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and isnull(x.st_registro, 'A') <> 'C')"
                                }
                            }, "1") != null)
                        {
                            MessageBox.Show("Para cancelar NFCe vinculada a NFe, obrigatório antes cancelar a NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        bool st_cancelar = true;
                        if ((bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue ||
                            (bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                        {
                            string motivo = string.Empty;
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                            //Verificar evento
                            TList_EventoNFCe lEvento =
                                TCN_EventoNFCe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                      (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
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
                                TRegistro_EventoNFCe rEvento = new TRegistro_EventoNFCe();
                                rEvento.Cd_empresa = (bsNFCe.Current as TRegistro_NFCe).Cd_empresa;
                                rEvento.Id_cupom = (bsNFCe.Current as TRegistro_NFCe).Id_nfce;
                                rEvento.Chave_acesso_nfce = (bsNFCe.Current as TRegistro_NFCe).Chave_acesso;
                                rEvento.Nr_protocoloNFCe = (bsNFCe.Current as TRegistro_NFCe).Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Justificativa = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.St_registro = "A";
                                TCN_EventoNFCe.Gravar(rEvento, null);
                                lEvento.Add(rEvento);
                            }
                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T") &&
                                (bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue)
                            {
                                //Buscar CfgNfe para a empresa
                                if (lCfg == null)
                                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    string ret = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + ret.Trim() + ".",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        st_cancelar = false;
                                    }
                                }
                            }
                        }
                        if (st_cancelar)
                        {
                            if (!(bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue &&
                                !(bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                !string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Chave_acesso))
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfCe =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                                if (lCfgNfCe.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração NFC-e para a empresa " + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    //Consultar Chave
                                    string ret = NFCe.ConsultaChave.TConsultaChave.ConsultaChave((bsNFCe.Current as TRegistro_NFCe).Chave_acesso,
                                                                                                    "1",
                                                                                                    lCfgNfCe[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Não é permtido excluir cupom com chave de acesso existente na receita.\r\n" + ret, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            TCN_NFCe.CancelarCF(bsNFCe.Current as TRegistro_NFCe, null);
                            MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!(bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue &&
                                !(bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                            {
                                CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca((bsNFCe.Current as TRegistro_NFCe).Nr_serie,
                                                                                                 (bsNFCe.Current as TRegistro_NFCe).Cd_modelo,
                                                                                                 (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                 null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals((bsNFCe.Current as TRegistro_NFCe).NR_NFCe))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
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
                                                                                                    (bsNFCe.Current as TRegistro_NFCe).Nr_serie,
                                                                                                    (bsNFCe.Current as TRegistro_NFCe).Cd_modelo,
                                                                                                    DateTime.Now.Year.ToString(),
                                                                                                    (bsNFCe.Current as TRegistro_NFCe).NR_NFCe.Value,
                                                                                                    (bsNFCe.Current as TRegistro_NFCe).NR_NFCe.Value,
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

        private void afterBusca()
        {
            string ini = string.Empty;
            string fim = string.Empty;
            if (dt_inicial.Text.SoNumero().Length.Equals(8))
                ini =
                    string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicial.Text).ToString("dd/MM/yyyy"))
                + " " +
                (hr_ini.Text.SoNumero().Length.Equals(4) ? string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(hr_ini.Text).ToString("HH:mm")) : "00:00");
            if (dt_final.Text.SoNumero().Length.Equals(8))
                fim =
                    string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_final.Text).ToString("dd/MM/yyyy"))
                + " " +
                (hr_fin.Text.SoNumero().Length.Equals(4) ? string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(hr_fin.Text).ToString("HH:mm")) : "23:59");

            bsNFCe.DataSource = TCN_NFCe.Buscar(id_nfce.Text,
                                                nr_nfce.Text,
                                                cd_empresa.Text,
                                                string.Empty,
                                                string.Empty,
                                                ini,
                                                fim,
                                                vl_ini.Value,
                                                vl_fin.Value,
                                                cd_produto.Text,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                false,
                                                id_venda.Text,
                                                cbStatus.SelectedIndex.Equals(0) ? "'A'" : cbStatus.SelectedIndex.Equals(1) ? "'C'" : string.Empty,
                                                0,
                                                null);
            lblTotalNFe.Text = (bsNFCe.List as TList_NFCe).Sum(p => p.Vl_cupom).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            bsNFCe_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsNFCe.Current != null)
            {
                if ((bsNFCe.Current as TRegistro_NFCe).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido imprimir DANFE NFCe CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue ? false : !(bsNFCe.Current as TRegistro_NFCe).Nr_protocolo.HasValue)
                {
                    MessageBox.Show("Permitido imprimir DANFE somente de NFCe aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource dts = new BindingSource();
                    dts.DataSource = new TList_NFCe_Item();
                    Rel.DTS_Relatorio = dts;// bsItens;
                    //DTS Cupom
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new TList_NFCe() { TCN_NFCe.BuscarNFCe((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                           (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                           null)};
                    NFCe.TGerarQRCode.GerarQRCode2(bs.Current as TRegistro_NFCe);
                    Rel.Adiciona_DataSource("DTS_NFCE", bs);
                    //Buscar Empresa
                    BindingSource bsEmpresa = new BindingSource();
                    bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa() { (bs.Current as TRegistro_NFCe).rEmpresa };
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                    //Forma Pagamento
                    BindingSource bsPagto = new BindingSource();
                    if ((bs.Current as TRegistro_NFCe).lDup.Count > 0)
                        (bs.Current as TRegistro_NFCe).lPagto.Add(new TRegistro_MovCaixa()
                        {
                            Tp_portador = "05",
                            Vl_recebido = (bs.Current as TRegistro_NFCe).lDup[0].Vl_documento
                        });
                    bsPagto.DataSource = (bs.Current as TRegistro_NFCe).lPagto;
                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                    //Parametros
                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bs.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                    Rel.Parametros_Relatorio.Add("QTD_ITENS", (bs.Current as TRegistro_NFCe).lItem.Count);
                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bs.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bs.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bs.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                    object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_lote = a.id_lote " +
                                                        "and x.status = '100')"
                                        }
                                    }, "a.tp_ambiente");
                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                    string dadoscf = TCN_NFCe.BuscarPlacaKM((bs.Current as TRegistro_NFCe).Cd_empresa,
                                                            (bs.Current as TRegistro_NFCe).Id_nfcestr,
                                                            null);
                    if (!string.IsNullOrEmpty(dadoscf))
                    {
                        string[] linhas = dadoscf.Split(new char[] { ':' });
                        string placa = string.Empty;
                        string km = string.Empty;
                        string frota = string.Empty;
                        string requisicao = string.Empty;
                        string nm_motorista = string.Empty;
                        string cpf_motorista = string.Empty;
                        string media = string.Empty;
                        string virg = string.Empty;
                        foreach (string s in linhas)
                        {
                            string[] colunas = s.Split(new char[] { '/' });
                            placa += virg + colunas[0];
                            km += virg + colunas[1];
                            frota += virg + colunas[2];
                            requisicao += virg + colunas[3];
                            nm_motorista += virg + colunas[4];
                            cpf_motorista += virg + colunas[5];
                            media += virg + colunas[6];
                            virg = ",";
                        }
                        if (!string.IsNullOrEmpty(placa))
                            Rel.Parametros_Relatorio.Add("PLACA", placa);
                        if (!string.IsNullOrEmpty(km))
                            Rel.Parametros_Relatorio.Add("KM", km);
                        if (!string.IsNullOrEmpty(media))
                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                        if (!string.IsNullOrEmpty(frota))
                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                        if (!string.IsNullOrEmpty(requisicao))
                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                        if (!string.IsNullOrEmpty(nm_motorista))
                            Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                        if (!string.IsNullOrEmpty(cpf_motorista))
                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                    }
                    Rel.Nome_Relatorio = "DANFE_NFCE";
                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                    Rel.Modulo = "FAT";
                    Rel.Ident = "DANFE_NFCE";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "DANFE NFC-e";
                    fImp.St_danfenfce = true;
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
                                            "DANFE NFC-e",
                                            fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                    {
                        fImp.pCd_clifor = (bs.Current as TRegistro_NFCe).Cd_clifor;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        {
                            if (fImp.St_danfenfcedetalhada)
                                Rel.DTS_Relatorio = bsItens;
                            if ((bs.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                fImp.St_viaestabelecimento)
                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                else
                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                            Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "DANFE NFC-e",
                                                fImp.pDs_mensagem);
                        }
                    }
                }
            }
        }

        private void VincularCfNFe()
        {
            using (Proc_Commoditties.TFVincularECFNF fVincular = new Proc_Commoditties.TFVincularECFNF())
            {
                if (fVincular.ShowDialog() == DialogResult.OK)
                    if (fVincular.lCupom != null)
                        if (fVincular.lCupom.Count > 0)
                        {
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                            try
                            {
                                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(fVincular.lCupom,
                                                                                                fVincular.pCd_empresa,
                                                                                                fVincular.pCd_cliente);
                                //Gravar Pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                                //Buscar pedido
                                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                                //Se o CMI do pedido gerar financeiro
                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                fVincular.lCupom.ForEach(p =>
                                {
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "inner join tb_pdv_cupomfiscal_x_duplicata y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_vendarapida = y.id_cupom " +
                                                                "where y.cd_empresa = a.cd_empresa " +
                                                                "and y.nr_lancto = a.nr_lancto " +
                                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + p.Id_nfcestr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                });
                                //Gerar Nota Fiscal
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed,
                                                                                             true,
                                                                                             lParcVinculado.Sum(p => p.Vl_atual));
                                //Vincular Cupom a Nota Fiscal
                                string Obs = string.Empty;
                                string virg = string.Empty;
                                fVincular.lCupom.ForEach(p =>
                                {
                                    rFat.lCupom.Add(p);
                                    string Placa_km = TCN_NFCe.BuscarPlacaKM(p.Cd_empresa, p.Id_nfcestr, null);
                                    Obs += virg + p.NR_NFCestr.Trim() + "-" + (string.IsNullOrEmpty(Placa_km) ? p.Placa : Placa_km.Trim()) + (!string.IsNullOrEmpty(p.Nr_requisicao) ? "/" + p.Nr_requisicao.Trim() : string.Empty);
                                    virg = ",";
                                });
                                //Vincular financeiro a Nota Fiscal
                                rFat.lParcAgrupar = lParcVinculado;
                                if (!string.IsNullOrEmpty(Obs))
                                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. CF-Placa/KM/Frota/Requisicao " + Obs.Trim();
                                //Gravar Nota Fiscal
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                if (rFat.Cd_modelo.Trim().Equals("55"))
                                    if (MessageBox.Show("NFe gerada com sucesso.\r\n" +
                                                       "Deseja enviar para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                    }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            }
                        }
                        else
                            MessageBox.Show("Não existe cupom fiscal selecionado para vincular a Nota Fiscal.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TFConsultaNFCe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            hr_ini.Text = "00:00";
            hr_fin.Text = "23:59";
            ShapeGrid.RestoreShape(this, gNFCe);
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gEvento);
        }
        
        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(
                new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(
                "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(
                new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(
                "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFConsultaNFCe_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gNFCe);
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gEvento);
        }

        private void bb_alterar_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as TRegistro_EventoNFCe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido alterar evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarEventoNFCe fAlt = new TFAlterarEventoNFCe())
                {
                    fAlt.rEvento = bsEvento.Current as TRegistro_EventoNFCe;
                    if (fAlt.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_EventoNFCe.Gravar(fAlt.rEvento, null);
                            MessageBox.Show("Evento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsNFCe.Current as TRegistro_NFCe).lEvento =
                                TCN_EventoNFCe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                      (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                      string.Empty,
                                                      null);
                            bsNFCe.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_exclui_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as TRegistro_EventoNFCe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido excluir evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do evento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_EventoNFCe.Excluir(bsEvento.Current as TRegistro_EventoNFCe, null);
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
                if ((bsEvento.Current as TRegistro_EventoNFCe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvento.Current as TRegistro_EventoNFCe).Tp_evento.Trim().ToUpper().Equals("CA"))
                    afterExclui();
                else
                {
                    //Buscar CfgNfe para a empresa
                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                    if (lCfg.Count.Equals(0))
                        MessageBox.Show("Não existe configuração para envio de EVENTO para a empresa " + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(bsEvento.Current as TRegistro_EventoNFCe, lCfg[0]);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar EVENTO para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                MessageBox.Show("EVENTO enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsNFCe.Current as TRegistro_NFCe).lEvento =
                                TCN_EventoNFCe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                      (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                      string.Empty,
                                                      null);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void gerarNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VincularCfNFe();
        }

        private void bsNFCe_PositionChanged(object sender, EventArgs e)
        {
            if(bsNFCe.Current !=null)
            {
                (bsNFCe.Current as TRegistro_NFCe).lItem =
                    TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                         (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                         string.Empty,
                                         null);
                (bsNFCe.Current as TRegistro_NFCe).lEvento =
                    TCN_EventoNFCe.Buscar((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                          (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                          string.Empty,
                                          null);
                bsNFCe.ResetCurrentItem();
            }
        }

        private void TFConsultaNFCe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if(e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmReVendas_Click(object sender, EventArgs e)
        {
            if (bsNFCe.Current != null)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFConsultaNFCe";
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                Relatorio.Ident = "TFConsultaNFCe";
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                Relatorio.DTS_Relatorio = bsNFCe;
                BindingSource bsInutilizadas = new BindingSource();
                bsInutilizadas.DataSource = new CamadaDados.Faturamento.Cadastros.TList_SeqInutNFe();
                Relatorio.Adiciona_DataSource("INUTILIZADOS", bsInutilizadas);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNFCe.Current as TRegistro_NFCe).Cd_clifor;
                        fImp.pMensagem = "RELATÓRIO DE VENDAS";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO DE VENDAS",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }
    }
}
