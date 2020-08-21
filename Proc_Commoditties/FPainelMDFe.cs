using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Frota;
using CamadaNegocio.Frota;

namespace Proc_Commoditties
{
    public partial class TFPainelMDFe : Form
    {
        private bool Altera_Relatorio = false;
        private CamadaDados.Frota.Cadastros.TRegistro_CfgMDFe rCfgMdfe
        { get; set; }

        public TFPainelMDFe()
        {
            InitializeComponent();
        }

        private void enviarMDFe()
        {
            if (rCfgMdfe == null)
            {
                MessageBox.Show("Não existe configuração FROTA para emitir MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFListaMDFeEnviar fLista = new TFListaMDFeEnviar())
            {
                fLista.Cd_empresa = empresa.SelectedValue.ToString();
                fLista.ShowDialog();
                if (fLista.lMDFe != null)
                    if (fLista.lMDFe.Count > 0)
                    {
                        //Gerar e assinar Arquivos xml
                        try
                        {
                            MDFe.EnviaArq.TEnviaArq.EnviarLoteMDFe(fLista.lMDFe, rCfgMdfe);
                            MessageBox.Show("Lote MDFe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Consultar lote
                            MDFe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(rCfgMdfe);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro enviar CTe: " + ex.Message);
                        }
                    }
            }
        }

        private void consultarMDFe()
        {
            if (rCfgMdfe == null)
            {
                MessageBox.Show("Não existe configuração FROTA para emitir MDFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                MDFe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(rCfgMdfe);
                afterBusca();
            }
            catch (Exception ex)
            { MessageBox.Show("Erro consultar CTe: " + ex.Message.Trim()); }
        }

        private void afterBusca()
        {
            bsLote.DataSource = TCN_LoteMDFe.Buscar(empresa.SelectedValue.ToString(),
                                                    string.Empty,
                                                    nr_mdfe.Text,
                                                    string.Empty,
                                                    string.Empty,
                                                    dt_inicial.Text,
                                                    dt_final.Text,
                                                    null);
            bsLote_PositionChanged(this, new EventArgs());
        }

        private void ConsultaStatusServico()
        {
            if (empresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                empresa.Focus();
                return;
            }
            if (MDFe.StatusServico.TStatusServico.StatusServico(rCfgMdfe).Trim().Equals("107"))
                tsStatus.Text = "SERVIÇO EM OPERAÇÃO";
            else
                tsStatus.Text = "SERVIÇO INDISPONIVEL NO MOMENTO.";
        }

        private void ReabrirMDFe()
        {
            if (bsMDFe.Current != null)
            {
                if ((bsLote.Current as TRegistro_LoteMDFe).cStat.Equals(103) ||
                    (bsLote.Current as TRegistro_LoteMDFe).cStat.Equals(105))
                {
                    MessageBox.Show("Não é permitido REABRIR MDF-e de um lote ainda não processado pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMDFe.Current as TRegistro_Lote_X_MDFe).cStat.ToString().Trim().Equals("100") &&
                    (bsLote.Current as TRegistro_LoteMDFe).Tp_ambiente.Trim().Equals("1"))
                {
                    MessageBox.Show("Não é permitido REABRIR MDF-e aceita pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Frota.TCN_Lote_X_MDFe.ReabrirMDFeProcessar(bsMDFe.Current as TRegistro_Lote_X_MDFe, null);
                    MessageBox.Show("MDF-e pronta para ser processada novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if(bsLote.Current != null)
                try
                {
                    CamadaNegocio.Frota.TCN_LoteMDFe.Excluir(bsLote.Current as TRegistro_LoteMDFe, null);
                    MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void afterPrint()
        {
            if (bsMDFe.Current != null)
            {
                if (!(bsMDFe.Current as TRegistro_Lote_X_MDFe).cStat.Trim().Equals("100"))
                {
                    MessageBox.Show("Permitido imprimir DAMDFE somente de MDF-e aceito pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BinDados = new BindingSource();
                    BinDados.DataSource = TCN_MDFe.Buscar((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                          (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
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
                                                          null);
                    Rel.DTS_Relatorio = BinDados;
                    //Buscar Empresa
                    BindingSource bs_empresa = new BindingSource();
                    bs_empresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa() { empresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa };
                    Rel.Adiciona_DataSource("EMPRESA", bs_empresa);
                    //Parametro RNTRC
                    object obj_rntrc = new CamadaDados.Frota.Cadastros.TCD_CfgFrota().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (empresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.rntrc");
                    if (obj_rntrc != null)
                        Rel.Parametros_Relatorio.Add("RNTRC", obj_rntrc.ToString());
                    //Montar Parametros Veiculos
                    TList_MDFe_Veiculo lVeic = TCN_MDFe_Veiculo.Buscar((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                                       (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
                                                                       null);
                    if (lVeic.Count > 0)
                        for (int i = 0; i < lVeic.Count; i++)
                        {
                            if (i < 3)
                            {
                                Rel.Parametros_Relatorio.Add("PLACA" + (i + 1).ToString(), lVeic[i].Placa);
                                Rel.Parametros_Relatorio.Add("RNTRC" + (i + 1).ToString(), lVeic[i].rVeic.Rntrc_prop);
                            }
                            else
                                break;
                        }
                    //Montar Parametros Motorista
                    TList_MDFe_Motorista lMot = TCN_MDFe_Motorista.Buscar((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                                          (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
                                                                          null);
                    int index = 0;
                    if(lMot.Count > 0)
                        while (index < 6 && index < lMot.Count)
                        {
                            Rel.Parametros_Relatorio.Add("NOME" + (index + 1).ToString(), lMot[index].Nm_motorista.Trim());
                            Rel.Parametros_Relatorio.Add("CPF" + (index + 1).ToString(), lMot[index].Cpf_motorista.Trim());
                            index++;
                        }
                    if (index < 6)
                    {
                        TList_MDFe_Evento lEvent = TCN_MDFe_Evento.Buscar((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                                          (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
                                                                          "IC",
                                                                          "T",
                                                                          null);
                        if(lEvent.Count > 0)
                            while (index < 6 && index < lEvent.Count)
                            {
                                Rel.Parametros_Relatorio.Add("NOME" + (index + 1).ToString(), lEvent[index].Nm_motorista.Trim());
                                Rel.Parametros_Relatorio.Add("CPF" + (index + 1).ToString(), lEvent[index].Cpf_motorista.Trim());
                                index++;
                            }
                    }
                    //Parametros Documentos
                    TList_MDFe_Documentos lDoc = TCN_MDFe_Documentos.Buscar((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                                            (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
                                                                            null);
                    if (lDoc.Count > 0)
                    {
                        Rel.Parametros_Relatorio.Add("QTD_CTE", lDoc.Count(p => !string.IsNullOrEmpty(p.ChaveCTe)));
                        Rel.Parametros_Relatorio.Add("QTD_NFE", lDoc.Count(p => !string.IsNullOrEmpty(p.ChaveNFe)));
                        Rel.Parametros_Relatorio.Add("PESO", lDoc.Sum(p => p.PesoBrutoNFe));
                        for (int i = 0; i < lDoc.Count; i++)
                            if (i >= 8)
                                break;
                            else
                                Rel.Parametros_Relatorio.Add("CHAVE" + (i + 1).ToString(), string.IsNullOrEmpty(lDoc[i].ChaveCTe) ? lDoc[i].ChaveNFe : lDoc[i].ChaveCTe);
                    }
                    Rel.Nome_Relatorio = "TFLanMDFe_DAMDFe";
                    Rel.NM_Classe = "TFLanMDFe";
                    Rel.Modulo = "FRT";
                    Rel.Ident = "TFLanMDFe_DAMDFe";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "DAMDFe";
                    //Verificar se existe logo configurada para a empresa
                    if((empresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (empresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
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

        private void GerarXML()
        {
            using (TFGerarXMLMDFe fGerar = new TFGerarXMLMDFe())
            {
                fGerar.ShowDialog();
            }
        }

        private void ConsMDFeNaoEnc()
        {
            if (empresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                empresa.Focus();
                return;
            }
            try
            {
                List<TRegistro_MDFe> lMDFe = MDFe.ConsMDFeNaoEnc.TConsMDFeNaoEnc.ConsMDFeNaoEnc(rCfgMdfe);
                if(lMDFe.Count > 0)
                    using (TFEncMDFe fEnc = new TFEncMDFe())
                    {
                        fEnc.lMDFe = lMDFe;
                        fEnc.rCfgMdfe = rCfgMdfe;
                        fEnc.ShowDialog();
                    }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void TFPainelMDFe_Load(object sender, EventArgs e)
        {
            pFiltro.set_FormatZero();
            empresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
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
                                                vVL_Busca = "(select 1 from tb_frt_cfgMDFe x "+
                                                            "where x.cd_empresa = a.cd_empresa)"
                                            }
                                        }, 0, string.Empty);
            empresa.DisplayMember = "NM_Empresa";
            empresa.ValueMember = "CD_Empresa";
            ConsultaStatusServico();
            tmStatus.Enabled = true;
            afterBusca();
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empresa.SelectedItem != null)
            {
                CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg =
                CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar((empresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                 null);
                if (lCfg.Count > 0)
                {
                    rCfgMdfe = lCfg[0];
                    lblAmbiente.Text = rCfgMdfe.Tp_ambiente.Trim().Equals("1") ? "PRODUÇÃO" : "HOMOLOGAÇÃO";
                }
                else MessageBox.Show("Não existe configuração para emitir MDF-e na empresa <" + empresa.SelectedValue.ToString() + ">",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            afterBusca();
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            ConsultaStatusServico();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            enviarMDFe();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            consultarMDFe();
        }

        private void bsLote_PositionChanged(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                (bsLote.Current as TRegistro_LoteMDFe).lMDFe =
                    TCN_Lote_X_MDFe.Buscar((bsLote.Current as TRegistro_LoteMDFe).Cd_empresa,
                                           (bsLote.Current as TRegistro_LoteMDFe).Id_lotestr,
                                           null);
                bsLote.ResetCurrentItem();
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            ReabrirMDFe();
        }

        private void tslConAutentic_Click(object sender, EventArgs e)
        {
            if (bsMDFe.Current != null)
                if (!string.IsNullOrEmpty((bsMDFe.Current as TRegistro_Lote_X_MDFe).ChaveAcesso) &&
                    !string.IsNullOrEmpty((bsLote.Current as TRegistro_LoteMDFe).Tp_ambiente))
                {
                    if (!string.IsNullOrEmpty((bsMDFe.Current as TRegistro_Lote_X_MDFe).cStat))
                        if ((bsMDFe.Current as TRegistro_Lote_X_MDFe).cStat.Equals("100"))
                        {
                            MessageBox.Show("MDF-e já esta com status <100-Autorizado o uso do MDF-e>", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    try
                    {
                        string ret = MDFe.ConsultaMDFe.TConsultaMDFe.ConsultaChave((bsMDFe.Current as TRegistro_Lote_X_MDFe).ChaveAcesso,
                                                                                   (bsLote.Current as TRegistro_LoteMDFe).Tp_ambiente,
                                                                                   rCfgMdfe);
                        if (string.IsNullOrEmpty(ret))
                            MessageBox.Show("MDF-e não encontrado para a chave de acesso: " + (bsMDFe.Current as TRegistro_Lote_X_MDFe).ChaveAcesso,
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            string[] v = ret.Split(new char[] { '|' });
                            if (v.Length > 0)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_Lote_X_MDFe.AtualizarDadosMDFe((bsMDFe.Current as TRegistro_Lote_X_MDFe).Cd_empresa,
                                                                                           (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_lotestr,
                                                                                           (bsMDFe.Current as TRegistro_Lote_X_MDFe).Id_mdfestr,
                                                                                           v[0],
                                                                                           v[1],
                                                                                           v[2],
                                                                                           v[3],
                                                                                           v[4],
                                                                                           null);
                                    MessageBox.Show("MDF-e atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro consultar MDF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFPainelMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                enviarMDFe();
            else if (e.KeyCode.Equals(Keys.F3))
                consultarMDFe();
            else if (e.KeyCode.Equals(Keys.F5))
                ReabrirMDFe();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                ConsMDFeNaoEnc();
            else if (e.KeyCode.Equals(Keys.F10))
                GerarXML();
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_xmlCTe_Click(object sender, EventArgs e)
        {
            GerarXML();
        }

        private void bbConsMDFeNaoEnc_Click(object sender, EventArgs e)
        {
            ConsMDFeNaoEnc();
        }
    }
}
