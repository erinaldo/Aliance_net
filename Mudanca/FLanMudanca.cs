using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaNegocio.Mudanca;
using CamadaDados.Mudanca;
using CamadaDados.Mudanca.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using Utils;
using FormBusca;
using FormRelPadrao;
using CamadaDados.Financeiro.Cadastros;
using Microsoft.Office.Interop.Word;

namespace Mudanca
{
    public partial class TFLanMudanca : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanMudanca()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            id_mudanca.Text = string.Empty;
            cd_empresa.Text = string.Empty;
            Id_veiculo.Text = string.Empty;
            Cd_motorista.Text = string.Empty;
            Cd_clifor.Text = string.Empty;
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
        }

        private void afterNovo()
        {
            using (TFMudanca fMudanca = new TFMudanca())
            {
                if (fMudanca.ShowDialog() == DialogResult.OK)
                    if (fMudanca.rMudanca != null)
                        try
                        {
                            TCN_LanMudanca.Gravar(fMudanca.rMudanca, null);
                            MessageBox.Show("Mudança gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Aprovar Mudança
                            if (fMudanca.St_aprovada)
                            {
                                if (fMudanca.rMudanca.St_utilizaguardamoveisbool)
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Nº Box";
                                    fMudanca.rMudanca.Nr_guardavol = ibp.ShowDialog();
                                }
                                TCN_LanMudanca.AprovarMudanca(fMudanca.rMudanca, null);
                                MessageBox.Show("Mudança aprovada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.LimparCampos();
                            id_mudanca.Text = fMudanca.rMudanca.Id_mudancastr;
                            cd_empresa.Text = fMudanca.rMudanca.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void afterAltera()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("3"))
                {
                    MessageBox.Show("Não é possivel alterar mudança CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("4"))
                {
                    MessageBox.Show("Não é possivel alterar mudança APROVADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFMudanca fMudanca = new TFMudanca())
                {
                    fMudanca.rMudanca = bsMudanca.Current as TRegistro_LanMudanca;
                    if (fMudanca.ShowDialog() == DialogResult.OK)
                        if (fMudanca.rMudanca != null)
                            try
                            {
                                TCN_LanMudanca.Gravar(fMudanca.rMudanca, null);
                                bsMudanca.ResetCurrentItem();
                                MessageBox.Show("Mudança alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Aprovar Mudança
                                if (fMudanca.St_aprovada)
                                {
                                    if (fMudanca.rMudanca.St_utilizaguardamoveisbool && string.IsNullOrEmpty(fMudanca.rMudanca.Nr_guardavol))
                                    {
                                        InputBox ibp = new InputBox();
                                        ibp.Text = "Nº Box";
                                        fMudanca.rMudanca.Nr_guardavol = ibp.ShowDialog();
                                    }
                                    TCN_LanMudanca.AprovarMudanca(fMudanca.rMudanca, null);
                                    MessageBox.Show("Mudança aprovada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    this.LimparCampos();
                    id_mudanca.Text = fMudanca.rMudanca.Id_mudancastr;
                    cd_empresa.Text = fMudanca.rMudanca.Cd_empresa;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("3"))
                {
                    MessageBox.Show("Mudança já se encontra CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("4"))
                {
                    MessageBox.Show("Não é possivel cancelar mudança PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja CANCELAR a Mudança Nº" + (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr.Trim() + "?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_LanMudanca.Excluir(bsMudanca.Current as TRegistro_LanMudanca, null);
                        MessageBox.Show("Mudança cancelada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparCampos();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxAprovado.Checked)
            {
                status = "1";
                virg = ",";
            }
            if (cbxOrcamento.Checked)
            {
                status += virg + "0";
                virg = ",";
            }
            if (cbxCancelado.Checked)
            {
                status += virg + "3";
                virg = ",";
            }
            if (cbxProcessada.Checked)
                status += virg + "4";
            bsMudanca.DataSource = TCN_LanMudanca.Buscar(cd_empresa.Text,
                                                         id_mudanca.Text,
                                                         nr_box.Text,
                                                         Cd_clifor.Text,
                                                         Id_veiculo.Text,
                                                         Cd_motorista.Text,
                                                         cd_vendedor.Text,
                                                         rbColeta.Checked ? "C" : rbViagem.Checked ? "V" : "E",
                                                         dt_ini.Text,
                                                         dt_fin.Text,
                                                         status,
                                                         null);
            bsMudanca.ResetCurrentItem();
            bsMudanca_PositionChanged(this, new EventArgs());
        }

        private void AprovarMudanca()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("3"))
                {
                    MessageBox.Show("Não é possivel aprovar mudança CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("4"))
                {
                    MessageBox.Show("Não é permitido aprovar mudança PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1"))
                {
                    MessageBox.Show("Mudança ja se encontra APROVADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma APROVAÇÃO do orçamento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        if ((bsMudanca.Current as TRegistro_LanMudanca).St_utilizaguardamoveisbool)
                        {
                            InputBox ibp = new InputBox();
                            ibp.Text = "Nº Box";
                            (bsMudanca.Current as TRegistro_LanMudanca).Nr_guardavol = ibp.ShowDialog();
                        }
                        TCN_LanMudanca.AprovarMudanca(bsMudanca.Current as TRegistro_LanMudanca, null);
                        MessageBox.Show("Orçamento APROVADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        id_mudanca.Text = (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr;
                        cd_empresa.Text = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro aprovar orçamento: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ProcessarMudanca()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("3"))
                {
                    MessageBox.Show("Não é possivel processar mudança CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("0"))
                {
                    MessageBox.Show("Não é possivel processar mudança ORÇAMENTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("4"))
                {
                    MessageBox.Show("Mudança já se encontra PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).CD_CondPGTO))
                    {
                        TList_CFGMudanca lCfg = new TCD_CFGMudanca().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);
                        if (lCfg.Count.Equals(0))
                            throw new Exception("Não existe configuração de mudança para gerar duplicata!");
                        //Buscar condicao de pagamento
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar((bsMudanca.Current as TRegistro_LanMudanca).CD_CondPGTO,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                        if (rCond.Qt_parcelas.Equals(0))//A vista
                        {
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vCd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                                fDuplicata.vNm_empresa = (bsMudanca.Current as TRegistro_LanMudanca).Nm_empresa;
                                fDuplicata.vCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor;
                                fDuplicata.vNm_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Nm_clifor;
                                fDuplicata.vCd_endereco = (bsMudanca.Current as TRegistro_LanMudanca).Cd_endereco;
                                fDuplicata.vDs_endereco = (bsMudanca.Current as TRegistro_LanMudanca).Ds_endereco;
                                fDuplicata.vTp_duplicata = lCfg[0].Tp_duplicata;
                                fDuplicata.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                fDuplicata.vTp_mov = lCfg[0].Tp_movDup;
                                fDuplicata.vTp_docto = lCfg[0].Tp_doctostr;
                                fDuplicata.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                                     new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.Tp_duplicata",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lCfg[0].Tp_duplicata.Trim() + "'"
                                                }
                                            }, 0, string.Empty);
                                if (lTpDup.Count > 0)
                                {
                                    fDuplicata.vCd_historico = lTpDup[0].Cd_historico_dup.Trim();
                                    fDuplicata.vDs_historico = lTpDup[0].Ds_historico_dup.Trim();
                                }
                                else
                                    MessageBox.Show("Não existe histórico configurado para o TP.Duplicata: " + lCfg[0].Ds_tpduplicata.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fDuplicata.vCd_condpgto = rCond.Cd_condpgto.Trim();
                                fDuplicata.vDs_condpgto = rCond.Ds_condpgto.Trim();
                                fDuplicata.vSt_comentrada = rCond.St_comentrada.Trim();
                                fDuplicata.vCd_juro = rCond.Cd_juro.Trim();
                                fDuplicata.vDs_juro = rCond.Ds_juro.Trim();
                                fDuplicata.vTp_juro = rCond.Tp_juro.Trim();
                                fDuplicata.vQt_dias_desdobro = rCond.Qt_diasdesdobro;
                                fDuplicata.vQt_parcelas = rCond.Qt_parcelas;
                                fDuplicata.vPc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                                fDuplicata.vCd_portador = rCond.Cd_portador.Trim();
                                fDuplicata.vDs_portador = rCond.Ds_portador.Trim();
                                fDuplicata.vSt_solicitardtvencto = rCond.St_solicitardtvenctobool;

                                //Moeda Padrao
                                //Buscar Moeda Padrao
                                TList_Moeda tabela =
                                    CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa, null);
                                if (tabela != null)
                                    if (tabela.Count > 0)
                                    {
                                        fDuplicata.vCd_moeda_padrao = tabela[0].Cd_moeda;
                                        fDuplicata.vDs_moeda_padrao = tabela[0].Ds_moeda_singular;
                                        fDuplicata.vSigla_moeda_padrao = tabela[0].Sigla;
                                        fDuplicata.vCd_moeda = tabela[0].Cd_moeda;
                                        fDuplicata.vDs_moeda = tabela[0].Ds_moeda_singular;
                                        fDuplicata.vSigla_moeda = tabela[0].Sigla;
                                    }

                                fDuplicata.vNr_docto = "MUD" + (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr;
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString();
                                fDuplicata.vVl_documento = (bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca;
                                fDuplicata.vSt_notafiscal = true;


                                if (fDuplicata.ShowDialog() == DialogResult.OK)
                                    (bsMudanca.Current as TRegistro_LanMudanca).lDup.Add(fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                else
                                {
                                    MessageBox.Show("Obrigatório informar financeiro para gravar nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //Criar Duplicata
                            TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                            rDup.Cd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                            rDup.Tp_doctostring = lCfg[0].Tp_doctostr;
                            rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                            object CD_Historico_Dup = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.Tp_duplicata",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + lCfg[0].Tp_duplicata.Trim() + "'"
                                                            }
                                                        }, "a.CD_Historico_Dup");
                            if (CD_Historico_Dup != null)
                                rDup.Cd_historico = CD_Historico_Dup.ToString();
                            else
                                MessageBox.Show("Não existe histórico configurado para o TP.Duplicata: " + lCfg[0].Ds_tpduplicata.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            object cd_juro = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.CD_CondPGTO",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsMudanca.Current as TRegistro_LanMudanca).CD_CondPGTO.Trim() + "'"
                                                    }

                                                }, "a.CD_Juro");

                            if (cd_juro != null)
                                rDup.Cd_juro = cd_juro.ToString();
                            rDup.Cd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor;
                            rDup.Cd_endereco = (bsMudanca.Current as TRegistro_LanMudanca).Cd_endereco;
                            //Buscar Moeda Padrao
                            TList_Moeda tabela =
                                CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa, null);
                            if (tabela != null)
                                if (tabela.Count > 0)
                                {
                                    rDup.Cd_moeda = tabela[0].Cd_moeda;
                                    rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                                    rDup.Sigla_moeda = tabela[0].Sigla;
                                }
                            rDup.Cd_condpgto = (bsMudanca.Current as TRegistro_LanMudanca).CD_CondPGTO;
                            rDup.Nr_docto = "MUD" + (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr;
                            rDup.Vl_documento = (bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca;
                            rDup.Vl_documento_padrao = (bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca;
                            rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            rDup.Qt_parcelas = (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud.Count;
                            decimal cd_parcela = 1;
                            (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud.ForEach(v =>
                                rDup.Parcelas.Add(new TRegistro_LanParcela()
                                {
                                    Cd_parcela = cd_parcela++,
                                    Dt_vencto = v.Dt_vencto,
                                    Vl_parcela = v.Vl_parcela,
                                    Vl_parcela_padrao = v.Vl_parcela
                                }));
                            (bsMudanca.Current as TRegistro_LanMudanca).lDup.Add(rDup);
                        }
                    }
                    TCN_LanMudanca.ProcessarMudanca(bsMudanca.Current as TRegistro_LanMudanca, null);
                    MessageBox.Show("Mudança processada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if ((bsMudanca.Current as TRegistro_LanMudanca).lDup.Count > 0)
                    {
                        //Imprimir Boleto
                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                            CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                                (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_lancto,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
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
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                false,
                                                                                0,
                                                                                null);
                        if (lBloqueto.Count > 0)
                            //Chamar tela de impressao para o bloqueto
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_clifor;
                                fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                        lBloqueto,
                                                                        fImp.pSt_imprimir,
                                                                        fImp.pSt_visualizar,
                                                                        fImp.pSt_enviaremail,
                                                                        fImp.pSt_exportPdf,
                                                                        fImp.Path_exportPdf,
                                                                        fImp.pDestinatarios,
                                                                        "BLOQUETO(S) DO DOCUMENTO Nº " + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto,
                                                                        fImp.pDs_mensagem,
                                                                        false);
                            }
                        else
                        {
                            //Imprimir Duplicata
                            object obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                            new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_docto",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Tp_doctostring
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                }
                                        }, "1");
                            if (obj != null)
                            {
                                //Chamar tela de impressao duplicata
                                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                {
                                    //Buscar dados Empresa
                                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                                    //Buscar dados do sacado
                                    TList_CadClifor lSacado =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_clifor,
                                                                                                      string.Empty,
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
                                                                                                      0,
                                                                                                      null);
                                    //Buscar endereco sacado
                                    if (lSacado.Count > 0)
                                        lSacado[0].lEndereco =
                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_clifor,
                                                                                                      (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_endereco,
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
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      0,
                                                                                                      null);
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_clifor;
                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                     (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                     null).Trim().ToUpper().Equals("S"))
                                    {
                                        Relatorio Rel = new Relatorio();
                                        //Duplicata
                                        BindingSource bs = new BindingSource();
                                        bs.DataSource = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca((bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_empresa,
                                                                                                                  (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_lancto.ToString(),
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
                                                                                                                  false,
                                                                                                                  0,
                                                                                                                  string.Empty,
                                                                                                                  null); 
                                        Rel.DTS_Relatorio = bs;
                                        //Verificar se existe logo configurada para a empresa
                                        if (lEmpresa.Count > 0)
                                            if (lEmpresa[0].Img != null)
                                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                        //Empresa
                                        BindingSource bs_emp = new BindingSource();
                                        bs_emp.DataSource = lEmpresa;
                                        Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                        //Parcelas
                                        BindingSource bs_parc = new BindingSource();
                                        bs_parc.DataSource = CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.Busca((bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Cd_empresa,
                                                                                                                     (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_lancto,
                                                                                                                     decimal.Zero,
                                                                                                                     string.Empty,
                                                                                                                     string.Empty,
                                                                                                                     string.Empty,
                                                                                                                     string.Empty,
                                                                                                                     string.Empty,
                                                                                                                     0,
                                                                                                                     string.Empty,
                                                                                                                     null);
                                        Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                        //Sacado
                                        BindingSource bs_sacado = new BindingSource();
                                        bs_sacado.DataSource = lSacado;
                                        Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                        Rel.Nome_Relatorio = "FRel_CarneDup";
                                        Rel.NM_Classe = "TFDuplicata";
                                        Rel.Modulo = "FIN";
                                        Rel.Ident = "FRel_CarneDup";
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto;

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
                                                               "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto,
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
                                                               "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto,
                                                               fImp.pDs_mensagem);
                                    }
                                    else
                                    {
                                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                  (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Parcelas,
                                                                                  lEmpresa,
                                                                                  lSacado,
                                                                                  fImp.pSt_imprimir,
                                                                                  fImp.pSt_visualizar,
                                                                                  fImp.pSt_exportPdf,
                                                                                  fImp.Path_exportPdf,
                                                                                  fImp.pSt_enviaremail,
                                                                                  fImp.pDestinatarios,
                                                                                  "DUPLICATAS(S) DO DOCUMENTO Nº " + (bsMudanca.Current as TRegistro_LanMudanca).lDup[0].Nr_docto,
                                                                                  fImp.pDs_mensagem);
                                    }
                                }
                            }
                        }
                    }
                    LimparCampos();
                    id_mudanca.Text = (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr;
                    cd_empresa.Text = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterPrint()
        {
            if (bsMudanca.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Mudanca.TList_LanMudanca() { bsMudanca.Current as TRegistro_LanMudanca };
                    Rel.DTS_Relatorio = bs;

                    //Buscar Serviços
                    (bsMudanca.Current as TRegistro_LanMudanca).Ds_servico = string.Empty;
                    (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.ForEach(p => (bsMudanca.Current as TRegistro_LanMudanca).Ds_servico += p.Ds_servico + " + ");
                    char[] end = { ' ', '+', ' ' };
                    (bsMudanca.Current as TRegistro_LanMudanca).Ds_servico =
                    (bsMudanca.Current as TRegistro_LanMudanca).Ds_servico.TrimEnd(end);

                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    //Endereco Cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor,
                                                                                                    (bsMudanca.Current as TRegistro_LanMudanca).Cd_endereco,
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
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    1,
                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_ENDCLI", bsEndCli);
                    Rel.Nome_Relatorio = "FLanMudancaFicha";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "FLanMudancaFicha";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor;
                    fImp.pMensagem = "MUDANÇA";

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
                                           "MUDANÇA",
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
                                               "MUDANÇA",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void OrcamentoMudanca()
        {
            using (TFLanOrcamento fOrcamento = new TFLanOrcamento())
            {
                fOrcamento.ShowDialog();
                //afterBusca();
            }
        }

        private void afterContrato()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1") ||
                    (bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("4"))
                {
                    //Abre a aplicação Word e faz uma cópia do documento mapeado
                    Microsoft.Office.Interop.Word.Application aplication = new Microsoft.Office.Interop.Word.Application();
                    Document doc = new Document();
                    //Objeto a ser usado nos parâmetros opcionais
                    object missing = System.Reflection.Missing.Value;

                    TList_CFGMudanca lCFG =
                        CamadaNegocio.Mudanca.Cadastros.TCN_CFGMudanca.buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);
                    if (lCFG.Count > 0)
                    {
                        if (string.IsNullOrEmpty(lCFG[0].ContratoInterMunicipal.ToString()) && string.IsNullOrEmpty(lCFG[0].ContratoMunicipal.ToString()))
                        {
                            MessageBox.Show("Obrigatório configurar Contrato na CFG.Mudança!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Buscar Contrato Mudanca Municipal
                        byte[] arquivoBuffer = (bsMudanca.Current as TRegistro_LanMudanca).Tp_mudanca.ToUpper().Equals("INTERMUNICIPAL") ? 
                            lCFG[0].ContratoInterMunicipal : lCFG[0].ContratoMunicipal;
                        string extensao = ".docx"; // retornar do banco tbm
                        string nameTemp = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);
                        System.IO.File.WriteAllBytes(
                            nameTemp,
                            arquivoBuffer);
                        object Template = nameTemp;

                        doc = aplication.Documents.Add(ref Template, ref missing, ref missing, ref missing);

                        aplication.Visible = true;

                        foreach (Field field in doc.Fields)
                        {
                            if (field.Code.Text.Contains("cliente"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Nm_clifor);
                            }
                            else if (field.Code.Text.Contains("rg"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Rg))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Rg);
                                else
                                    aplication.Selection.TypeText("           ");
                            }
                            else if (field.Code.Text.Contains("cpf"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Cpf))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Cpf);
                                else
                                    aplication.Selection.TypeText("              ");
                            }
                            else if (field.Code.Text.Contains("fone"))
                            {
                                field.Select();
                                object fone = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor.Trim() + "'"
                                    }
                                }, "isnull(a.fone, a.Fone_Comercial)");
                                if (fone != null)
                                    aplication.Selection.TypeText(fone.ToString());
                            }
                            else if (field.Code.Text.Contains("dia"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(DateTime.Now.Day.ToString());
                            }
                            else if (field.Code.Text.Contains("mesextenso"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month));
                            }
                            else if (field.Code.Text.Contains("ano"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(DateTime.Now.Year.ToString());
                            }
                            else if (field.Code.Text.Contains("id_mudanca"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr);
                            }
                            else if (field.Code.Text.Contains("cidadeorig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Orig);
                            }
                            else if (field.Code.Text.Contains("uforig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).UfOrig);
                            }
                            else if (field.Code.Text.Contains("cidadedest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Dest);
                            }
                            else if (field.Code.Text.Contains("ufdest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).UfDest);
                            }
                            else if (field.Code.Text.Contains("vl_mudanca"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Vl_mudanca.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            }
                            else if (field.Code.Text.Contains("dt_coleta"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Dt_coletastr);
                            }
                            else if (field.Code.Text.Contains("dt_entrega"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Dt_entregastr);
                            }
                            else if (field.Code.Text.Contains("dt_embalagem"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Dt_embalagemstr))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Dt_embalagemstr);
                                else
                                    aplication.Selection.TypeText("      ");
                            }
                            else if (field.Code.Text.Contains("dt_viagem"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Dt_viagemstr))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Dt_viagemstr);
                                else
                                    aplication.Selection.TypeText("      ");
                            }
                            else if (field.Code.Text.Contains("dias_exec"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).NR_DiasExecMudanca.ToString());
                            }
                            else if (field.Code.Text.Contains("enderecoorig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Orig);
                            }
                            else if (field.Code.Text.Contains("numeroorig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Numero_Orig);
                            }
                            else if (field.Code.Text.Contains("complementoorig"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Complemento_Orig))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Complemento_Orig);
                                else
                                    aplication.Selection.TypeText("      ");
                            }
                            else if (field.Code.Text.Contains("bairroorig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Bairro_Orig);
                            }
                            else if (field.Code.Text.Contains("cidadeorig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Orig);
                            }
                            else if (field.Code.Text.Contains("uforig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).UfOrig);
                            }
                            else if (field.Code.Text.Contains("ceporig"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).CEP_Orig);
                            }
                            else if (field.Code.Text.Contains("enderecodest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Logradouro_Dest);
                            }
                            else if (field.Code.Text.Contains("numerodest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Numero_Dest);
                            }
                            else if (field.Code.Text.Contains("complementodest"))
                            {
                                field.Select();
                                if (!string.IsNullOrEmpty((bsMudanca.Current as TRegistro_LanMudanca).Complemento_Dest))
                                    aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Complemento_Dest);
                                else
                                    aplication.Selection.TypeText("      ");
                            }
                            else if (field.Code.Text.Contains("bairrodest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).Bairro_Dest);
                            }
                            else if (field.Code.Text.Contains("cidadedest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).DS_Cidade_Dest);
                            }
                            else if (field.Code.Text.Contains("ufdest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).UfDest);
                            }
                            else if (field.Code.Text.Contains("cepdest"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).CEP_Dest);
                            }
                            else if (field.Code.Text.Contains("servico"))
                            {
                                field.Select();
                                string servico = string.Empty;
                                (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud.ForEach(p => servico += p.Ds_servico + ", ");
                                char[] end = { ',', ' ' };
                                aplication.Selection.TypeText(servico.TrimEnd(end));
                            }
                            else if (field.Code.Text.Contains("tot_seguro"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsMudanca.Current as TRegistro_LanMudanca).lItensMud.Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            }
                        }
                    }
                }
                else MessageBox.Show("Permitido gerar contrato somente de mudança APROVADA ou PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe mudança selecionada para gerar contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirItem()
        {
            if (bsMudanca.Current != null)
            {
                if ((bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).St_registro.Trim().Equals("0") ||
                    (bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).St_registro.Trim().Equals("1"))
                    try
                    {
                        using (TFItensMud fItensMud = new TFItensMud())
                        {
                            fItensMud.plItensMud = bsItens.List as CamadaDados.Mudanca.TList_LanItensMud;
                            if (fItensMud.ShowDialog() == DialogResult.OK)
                            {
                                if (fItensMud.lItensDel.Count > 0)
                                    CamadaNegocio.Mudanca.TCN_LanItensMud.Excluir(fItensMud.lItensDel, null);
                                if (fItensMud.lItens.Count > 0)
                                {
                                    CamadaDados.Mudanca.TList_LanItensMud lItens = new TList_LanItensMud();
                                    fItensMud.lItens.ForEach(p =>
                                        lItens.Add(new TRegistro_LanItensMud()
                                        {
                                            Cd_empresa = (bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).Cd_empresa,
                                            Id_mudanca = (bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).Id_mudanca,
                                            Id_item = p.Id_item,
                                            Quantidade = p.Quantidade,
                                            Vl_seguro = p.Vl_seguro,
                                            MetragemCub = p.MetragemCub
                                        }));
                                    CamadaNegocio.Mudanca.TCN_LanItensMud.Gravar(lItens, null);
                                    bsMudanca_PositionChanged(this, new EventArgs());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else MessageBox.Show("Permitido incluir itens somente registro com status ORÇAMENTO ou APROVADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Obrigatório selecionar registro mudança.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if ((bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).St_registro.Trim().Equals("3"))
                {
                    MessageBox.Show("Não é permitido excluir item mudança CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMudanca.Current as CamadaDados.Mudanca.TRegistro_LanMudanca).St_registro.Trim().Equals("4"))
                {
                    MessageBox.Show("Não é permitido excluir item mudança PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Mudanca.TCN_LanItensMud.Excluir(bsItens.Current as CamadaDados.Mudanca.TRegistro_LanItensMud, null);
                        bsItens.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanMudanca_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            tcDetalhes.TabPages.Remove(tpParcelas);
            pConsulta.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void Id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + Id_veiculo.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                             "a.id_veiculo|Codigo|80;" +
                             "a.placa|Placa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_veiculo },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void Cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + Cd_motorista.Text.Trim() + "';" +
                               "isnull(a.st_motorista, 'N')|=|'S';" +
                                "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_motorista },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                                "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_motorista },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
               new Componentes.EditDefault[] { Cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void TFLanMudanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.AprovarMudanca();
            else if (e.KeyCode.Equals(Keys.F10))
                this.OrcamentoMudanca();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsMudanca_PositionChanged(object sender, EventArgs e)
        {
            if (bsMudanca.Current != null)
            {
                //Buscar Itens
                (bsMudanca.Current as TRegistro_LanMudanca).lItensMud =
                    TCN_LanItensMud.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                           (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr,
                                           string.Empty,
                                           null);

                //Buscar Serviços
                (bsMudanca.Current as TRegistro_LanMudanca).lServicosMud =
                    TCN_LanServicosMud.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                           (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr,
                                           string.Empty,
                                           null);
                //Buscar Parcelas
                (bsMudanca.Current as TRegistro_LanMudanca).lParcelasMud =
                    TCN_ParcelasMud.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                           (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr,
                                           string.Empty,
                                           null);
                //Buscar Material
                (bsMudanca.Current as TRegistro_LanMudanca).lMaterialMud =
                    TCN_MaterialMud.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                           (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr,
                                           string.Empty,
                                           null);
                //Buscar Ajudante
                (bsMudanca.Current as TRegistro_LanMudanca).lAjudantesMud =
                    TCN_AjudantesMud.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                           (bsMudanca.Current as TRegistro_LanMudanca).Id_mudancastr,
                                           string.Empty,
                                           null);
                //Buscar CTe
                (bsMudanca.Current as TRegistro_LanMudanca).lCtrc =
                    new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_MUD_Mudanca_X_CTe x " +
                                            "where x.nr_lanctoCTR = a.nr_lanctoCTR " +
                                            "and x.cd_empresa = '" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa.Trim() + "'" +
                                            "and x.id_mudanca = " + (bsMudanca.Current as TRegistro_LanMudanca).Id_mudanca + ")"
                            }
                        }, 0, string.Empty);

                //Buscar NFSe
                (bsMudanca.Current as TRegistro_LanMudanca).lFat =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_MUD_Mudanca_X_NFSe x " +
                                            "where x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and x.cd_empresa = '" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa.Trim() + "'" +
                                            "and x.id_mudanca = " + (bsMudanca.Current as TRegistro_LanMudanca).Id_mudanca + ")"
                            }
                        }, 0, string.Empty);
                //Buscar Despesas da Viagem
                if ((bsMudanca.Current as TRegistro_LanMudanca).Id_viagem.HasValue)
                {
                    (bsMudanca.Current as TRegistro_LanMudanca).lDespesas =
                        new CamadaDados.Frota.Cadastros.TCD_DespesasVeiculo().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_viagem",
                                    vOperador = "=",
                                    vVL_Busca = (bsMudanca.Current as TRegistro_LanMudanca).Id_viagemstr
                                }
                            }, 0, string.Empty);
                    if ((bsMudanca.Current as TRegistro_LanMudanca).lDespesas.Count > 0)
                        tot_despesas.Text = (bsMudanca.Current as TRegistro_LanMudanca).lDespesas.Sum(p => p.Vl_despesas).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                }
                bsMudanca.ResetCurrentItem();
            }
        }

        private void gMudanca_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ORÇAMENTO"))
                        gMudanca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                        gMudanca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                        gMudanca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gMudanca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.AprovarMudanca();
        }

        private void emiCte_Click(object sender, EventArgs e)
        {
            using (Frota.TFCTe fCte = new Frota.TFCTe())
            {
                if (bsMudanca.Current != null)
                {
                    if (!(bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1"))
                    {
                        MessageBox.Show("Permitido Faturar somente mudança APROVADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsMudanca.Current as TRegistro_LanMudanca).SaldoFaturar.Equals(0))
                    {
                        MessageBox.Show("Não existe saldo para gerar CTe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!(bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("3"))
                    {
                        fCte.pCd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa;
                        fCte.pCd_motorista = (bsMudanca.Current as TRegistro_LanMudanca).Cd_motorista;
                        fCte.pId_veiculo = (bsMudanca.Current as TRegistro_LanMudanca).Id_veiculostr;
                        fCte.pSaldoFaturar = (bsMudanca.Current as TRegistro_LanMudanca).SaldoFaturar;
                        fCte.rMudança = bsMudanca.Current as TRegistro_LanMudanca;
                    }
                    if (fCte.ShowDialog() == DialogResult.OK)
                        if (fCte.rCte != null)
                        {
                            //Verificar se o CMI gera financeiro
                            CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCte.rCte.Cd_cmistr,
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
                                                                                                         null);
                            if (lCmi.Count > 0)
                                if (!string.IsNullOrEmpty(lCmi[0].Tp_duplicata))
                                {
                                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                    {
                                        fDuplicata.vCd_empresa = fCte.rCte.Cd_empresa;
                                        fDuplicata.vNm_empresa = fCte.rCte.Nm_empresa;
                                        fDuplicata.vCd_clifor = fCte.rCte.Cd_remetente;
                                        fDuplicata.vNm_clifor = fCte.rCte.Nm_remetente;
                                        fDuplicata.vCd_endereco = fCte.rCte.Cd_endremetente;
                                        fDuplicata.vDs_endereco = fCte.rCte.Ds_endremetente;
                                        fDuplicata.vNr_docto = fCte.rCte.Nr_ctrcstr;
                                        fDuplicata.vDt_emissao = fCte.rCte.Dt_emissao.Value.ToString("dd/MM/yyyy");
                                        fDuplicata.vVl_documento = fCte.rCte.Vl_frete;
                                        fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                        fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                        fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                        fDuplicata.vCd_historico = lCmi[0].Cd_historico;
                                        fDuplicata.vDs_historico = lCmi[0].Ds_historico;
                                        fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                        fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                        fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                        fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                        fDuplicata.vCd_moeda = lCmi[0].Cd_moeda;
                                        fDuplicata.vDs_moeda = lCmi[0].Ds_moeda;
                                        fDuplicata.vSigla_moeda = lCmi[0].Sigla;
                                        fDuplicata.vSt_ctrc = true;
                                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                                            if (fDuplicata.dsDuplicata.Current != null)
                                            {
                                                fCte.rCte.rDuplicata =
                                                    fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            if (fCte.rCte.Vl_frete > (bsMudanca.Current as TRegistro_LanMudanca).SaldoFaturar)
                            {
                                MessageBox.Show("Saldo insuficiente para gerar CTe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            try
                            {
                                CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(fCte.rCte, false, null);
                                if (MessageBox.Show("CTe gravado com sucesso.\r\nDeseja enviar o mesmo para receita?",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                
                                {
                                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fCte.rCte.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                                    if (lCfg.Count > 0)
                                        //Gerar e assinar Arquivos xml
                                        try
                                        {
                                            CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { fCte.rCte }, lCfg[0]);
                                            MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Consultar lote
                                            CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                            fCte.rCte = CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar(fCte.rCte.Cd_empresa,
                                                                                                                    fCte.rCte.Nr_lanctoCTRC.ToString(),
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
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    1,
                                                                                                                    string.Empty,
                                                                                                                    null)[0];
                                            if (fCte.rCte.Status_cte.ToString().Equals("100"))
                                                    this.afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete);
                                            else
                                                using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                {
                                                    fPainel.ShowDialog();
                                                }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Erro enviar CTe: " + ex.Message);
                                        }
                                }
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void afterPrintDacte(CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCTe)
        {
            if (bsCTe.Current != null)
            {
                if (!rCTe.Status_cte.ToString().Trim().Equals("100"))
                {
                    MessageBox.Show("Permitido imprimir DACTE somente de CT-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BinDados = new BindingSource();
                    BinDados.DataSource = rCTe;
                    Rel.DTS_Relatorio = BinDados;

                    //Buscar ENDEREÇO Emitente
                    BindingSource bs_endEmitente = new BindingSource();
                    bs_endEmitente.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_transportadora,
                                                                                  rCTe.Cd_endtransportadora,
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
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  null);

                    //Buscar ENDEREÇO Remetente
                    BindingSource bs_endRemetente = new BindingSource();
                    bs_endRemetente.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_remetente,
                                                                                  rCTe.Cd_endremetente,
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
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  null);
                    //Buscar ENDEREÇO Expedidor
                    BindingSource bs_endExpedidor = new BindingSource();
                    if ((!string.IsNullOrEmpty(rCTe.Cd_expedidor)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endexpedidor)))
                        bs_endExpedidor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_expedidor,
                                                                                      rCTe.Cd_endexpedidor,
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
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                    else bs_endExpedidor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar ENDEREÇO Destinatario
                    BindingSource bs_endDest = new BindingSource();
                    bs_endDest.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_destinatario,
                                                                                  rCTe.Cd_enddestinatario,
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
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  null);
                    //Buscar ENDEREÇO Recebedor
                    BindingSource bs_endRecebedor = new BindingSource();
                    if ((!string.IsNullOrEmpty(rCTe.Cd_recebedor)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endrecebedor)))
                        bs_endRecebedor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_recebedor,
                                                                                      rCTe.Cd_endrecebedor,
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
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                    else bs_endRecebedor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar Endereco Tomador
                    BindingSource bs_endTomador = new BindingSource();
                    if ((!string.IsNullOrEmpty(rCTe.Cd_tomador)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endtomador)))
                        bs_endTomador.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_tomador,
                                                                                      rCTe.Cd_endtomador,
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
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                    else bs_endTomador.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar NF-e 
                    BindingSource BD_NF = new BindingSource();
                    BD_NF.DataSource = new CamadaDados.Faturamento.CTRC.TCD_CTRNotaFiscal().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCTe.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.NR_lanctoCTR",
                                vOperador = "=",
                                vVL_Busca = "'" + rCTe.Nr_lanctoCTRC.ToString().Trim() + "'"
                            }
                        }, 0, string.Empty);

                    //Buscar CFG Frota
                    BindingSource bs_CFG = new BindingSource();
                    bs_CFG.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(rCTe.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                    //Buscar Empresa
                    BindingSource bs_empresa = new BindingSource();
                    bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCTe.Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);


                    Rel.Adiciona_DataSource("EMPRESA", bs_empresa);
                    Rel.Adiciona_DataSource("CFGFROTA", bs_CFG);
                    Rel.Adiciona_DataSource("BD_NF", BD_NF);
                    Rel.Adiciona_DataSource("ENDEMITENTE", bs_endEmitente);
                    Rel.Adiciona_DataSource("ENDREMETENTE", bs_endRemetente);
                    Rel.Adiciona_DataSource("ENDEXPEDIDOR", bs_endExpedidor);
                    Rel.Adiciona_DataSource("ENDDEST", bs_endDest);
                    Rel.Adiciona_DataSource("ENDRECEBEDOR", bs_endRecebedor);
                    Rel.Adiciona_DataSource("ENDTOMADOR", bs_endTomador);

                    //Buscar financeiro da CTE
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                    "inner join TB_CTR_Duplicata y " +
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                    "where isnull(x.st_registro, 'A') <> 'C' " +
                                                    "and x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and y.cd_empresa = '" + rCTe.Cd_empresa.Trim() + "' " +
                                                    "and y.nr_lanctoCTR = " + rCTe.Nr_lanctoCTRC+ ")"
                                    }
                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    if (lParc.Count > 0)
                        for (int i = 0; i < lParc.Count; i++)
                        {
                            if (i < 8)
                            {
                                Rel.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                Rel.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                            }
                            else
                                break;
                        }
                    //Montar Parametros QTD
                    if (rCTe.lQtdeCarga.Count > 0)
                        for (int i = 0; i < rCTe.lQtdeCarga.Count; i++)
                        {
                            if (i < 3)
                            {
                                Rel.Parametros_Relatorio.Add("UND_MED" + i.ToString(), rCTe.lQtdeCarga[i].Tp_medida);
                                Rel.Parametros_Relatorio.Add("QTD" + i.ToString(), rCTe.lQtdeCarga[i].Qt_carga + " ");
                            }
                            else
                                break;
                        }
                    //Montar Parametros Complemento Frete
                    if (rCTe.lCompValorFrete.Count > 0)
                        for (int i = 0; i < rCTe.lCompValorFrete.Count; i++)
                        {
                            if (i < 8)
                            {
                                Rel.Parametros_Relatorio.Add("NOMECOMP" + i.ToString(), rCTe.lCompValorFrete[i].Nm_componente);
                                Rel.Parametros_Relatorio.Add("VL_COMP" + i.ToString(), rCTe.lCompValorFrete[i].Vl_componente);
                            }
                            else
                                break;
                        }
                    Rel.Nome_Relatorio = "TFLanCTE_Dacte";
                    Rel.NM_Classe = "TFPainelCTe";
                    Rel.Modulo = "FRT";
                    Rel.Ident = "TFLanCTE_Dacte";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "CTE";
                    //Verificar se existe logo configurada para a empresa
                    object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCTe.Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.logoEmpresa");
                    if (log != null)
                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
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
                                           "CTE",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        fImp.pCd_clifor = rCTe.Nm_destinatario;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
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
                                           "CTE",
                                           fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void emitirNFSe_Click(object sender, EventArgs e)
        {
            if (bsMudanca.Current != null)
                if ((bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1"))
                {
                    if ((bsMudanca.Current as TRegistro_LanMudanca).SaldoFaturar > decimal.Zero)
                    {
                        TList_CFGMudanca lCfg =
                            new TCD_CFGMudanca().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa.Trim() + "'"
                            }
                        }, 1, string.Empty);
                        if (lCfg.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe parametro para a CFG.Mudança!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(lCfg[0].CFG_PedServico))
                        {
                            MessageBox.Show("Não existe tipo pedido serviço configurado para a mudança!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        decimal valor = decimal.Zero;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        try
                        {
                            //Informar Valor
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Casas_decimais = 2;
                                fQtde.Vl_saldo = decimal.Zero;
                                fQtde.Ds_label = "Valor Serviço";
                                if (fQtde.ShowDialog() == DialogResult.OK)
                                {
                                    if (fQtde.Quantidade > (bsMudanca.Current as TRegistro_LanMudanca).SaldoFaturar)
                                    {
                                        MessageBox.Show("Saldo insuficiente para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (fQtde.Quantidade == decimal.Zero)
                                    {
                                        MessageBox.Show("Obrigatório informar quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                        valor = fQtde.Quantidade;
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            TCN_LanMudanca.GerarPedidoMudanca(ref rPed,
                                                               bsMudanca.Current as TRegistro_LanMudanca,
                                                               valor,
                                                               lCfg);
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            //Buscar pedido
                            rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                            //Gravar Nota Fiscal
                            TCN_LanMudanca.GravarFaturamento(rFat, bsMudanca.Current as TRegistro_LanMudanca, null);
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                 rFat.Nr_lanctofiscalstr,
                                                                                                 null);
                                NFES.TGerarRPS.CriarArquivoRPS(rNf.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNf });
                                MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe saldo para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                    MessageBox.Show("Permitido Faturar somente mudança APROVADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_orcamento_Click(object sender, EventArgs e)
        {
            this.OrcamentoMudanca();
        }

        private void bb_imprimirMudanca_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void bb_imprimirContrato_Click(object sender, EventArgs e)
        {
            this.afterContrato();
        }

        private void imprimirReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsMudanca.Current != null)
            {
                if (!(bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1"))
                {
                    MessageBox.Show("Só é permitido gerar recibo de mudança APROVADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Mudanca.TList_LanMudanca() { bsMudanca.Current as TRegistro_LanMudanca };
                    Rel.DTS_Relatorio = bs;

                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    //Endereco Cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor,
                                                                                                    (bsMudanca.Current as TRegistro_LanMudanca).Cd_endereco,
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
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    1,
                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_ENDCLI", bsEndCli);
                    Rel.Nome_Relatorio = "FLanMudancaRecibo";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "FLanMudancaRecibo";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor;
                    fImp.pMensagem = "RECIBO";

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
                                           "RECIBO",
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
                                               "RECIBO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void bbProcessar_Click(object sender, EventArgs e)
        {
            this.ProcessarMudanca();
        }

        private void consultarCTeEmitidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
            {
                fPainel.ShowDialog();
            }
        }

        private void bb_inserirItens_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void bb_excluirItens_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                                               new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                                 new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void tsAdto_Click(object sender, EventArgs e)
        {
            if(bsMudanca.Current != null)
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_ADTO_VIAGEM", string.Empty, null).Trim().ToUpper().Equals("S"))
                {
                    if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem != null)
                    {
                        if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem.St_viagem.Trim().ToUpper().Equals("F"))
                        {
                            MessageBox.Show("Não é permitido incluir adiantamento para viagem FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem.St_viagem.Trim().ToUpper().Equals("C"))
                        {
                            MessageBox.Show("Não é permitido incluir adiantamento para viagem CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (Financeiro.TFLan_Adiantamento fAdto = new Financeiro.TFLan_Adiantamento())
                        {
                            fAdto.BS_Adiantamento.AddNew();
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Tp_movimento = "C";
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_empresa;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_empresa;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_motorista;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_motorista;
                            //Buscar endereco motorista
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_motorista,
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
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          null);
                            if (lEnd.Count > 0)
                            {
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).CD_Endereco = lEnd[0].Cd_endereco;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).DS_Endereco = lEnd[0].Ds_endereco;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cidade = lEnd[0].DS_Cidade;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).UF = lEnd[0].UF;
                            }
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).TP_Lancto = "R";
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_prevdevolucao = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Dt_prevRetorno;

                            fAdto.CD_Empresa.Enabled = false;
                            fAdto.BB_Empresa.Enabled = false;
                            fAdto.cd_clifor.Enabled = false;
                            fAdto.bb_clifor.Enabled = false;
                            fAdto.CD_Endereco.Enabled = false;
                            fAdto.bb_endereco.Enabled = false;
                            fAdto.rb_Adiantamento.Enabled = false;
                            fAdto.rb_Recebido.Enabled = false;

                            if (fAdto.ShowDialog() == DialogResult.OK)
                                try
                                {
                                   CamadaNegocio.Frota.TCN_Viagem.IncluirAdiantamento((bsMudanca.Current as TRegistro_LanMudanca).rViagem,
                                                                   fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento,
                                                                   null);
                                    MessageBox.Show("Adiantamento incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim()); }
                        }
                    }
                }
                else
                {
                    using (Financeiro.TFLan_Adiantamento fAdto = new Financeiro.TFLan_Adiantamento())
                    {
                        fAdto.BS_Adiantamento.AddNew();
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Tp_movimento = "C";
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).TP_Lancto = "R";
                        fAdto.rb_Adiantamento.Enabled = false;
                        fAdto.rb_Recebido.Enabled = false;
                        if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem != null)
                        {
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_empresa;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_empresa;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_motorista;
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_motorista;
                            //Buscar endereco motorista
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_motorista,
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
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          null);
                            if (lEnd.Count > 0)
                            {
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).CD_Endereco = lEnd[0].Cd_endereco;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).DS_Endereco = lEnd[0].Ds_endereco;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cidade = lEnd[0].DS_Cidade;
                                (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).UF = lEnd[0].UF;
                            }
                            (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_prevdevolucao = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Dt_prevRetorno;
                        }

                        if (fAdto.ShowDialog() == DialogResult.OK)
                            if (fAdto.BS_Adiantamento.Current != null)
                                try
                                {
                                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento, null);
                                    MessageBox.Show("Adiantamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim()); }
                    }
                }
        }

        private void tsDespesas_Click(object sender, EventArgs e)
        {
            if(bsMudanca.Current != null)
                if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem != null)
                    if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem.St_viagem.Trim().ToUpper().Equals("P") ||
                        (bsMudanca.Current as TRegistro_LanMudanca).rViagem.St_viagem.Trim().ToUpper().Equals("E"))
                    {
                        //Buscar despesas da viagem
                        (bsMudanca.Current as TRegistro_LanMudanca).rViagem.lDespesas =
                            CamadaNegocio.Frota.TCN_DespesasViagem.Buscar(string.Empty,
                                                                          (bsMudanca.Current as TRegistro_LanMudanca).Id_viagemstr,
                                                                          (bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                        using (Frota.TFDespesasViagem fDespesa = new Frota.TFDespesasViagem())
                        {
                            fDespesa.rViagem = (bsMudanca.Current as TRegistro_LanMudanca).rViagem;
                            fDespesa.ShowDialog();
                            this.afterBusca();
                        }
                    }
        }

        private void tsAcerto_Click(object sender, EventArgs e)
        {
            if(bsMudanca.Current != null)
                using (Frota.TFAcertoMotorista fAcerto = new Frota.TFAcertoMotorista())
                {
                    if ((bsMudanca.Current as TRegistro_LanMudanca).rViagem != null)
                    {
                        fAcerto.Cd_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_empresa;
                        fAcerto.Nm_empresa = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_empresa;
                        fAcerto.Cd_motorista = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Cd_motorista;
                        fAcerto.Nm_motorista = (bsMudanca.Current as TRegistro_LanMudanca).rViagem.Nm_motorista;
                        if (fAcerto.ShowDialog() == DialogResult.OK)
                            if (fAcerto.rAcerto != null)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_AcertoMotorista.Gravar(fAcerto.rAcerto, null);
                                    if (MessageBox.Show("Acerto gravado com sucesso.\r\n" +
                                                       "Deseja processar acerto?", "Pergunta",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        if (fAcerto.rAcerto.Vl_sobradinheiro > decimal.Zero)
                                        {
                                            using (Financeiro.TFLanCaixa fCaixa = new Financeiro.TFLanCaixa())
                                            {
                                                fCaixa.Text = "CAIXA SOBRA DINHEIRO";
                                                fCaixa.dsLanCaixa.AddNew();
                                                (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_Empresa = fAcerto.rAcerto.Cd_empresa;
                                                (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Nm_empresa = fAcerto.rAcerto.Nm_empresa;
                                                fCaixa.RB_Receber.Checked = true;
                                                fCaixa.RB_Pagar.Enabled = false;
                                                fCaixa.RB_Receber.Enabled = false;
                                                (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Vl_RECEBER = fAcerto.rAcerto.Vl_sobradinheiro;
                                                fCaixa.VL_Receber.Enabled = false;
                                                if (fCaixa.ShowDialog() == DialogResult.OK)
                                                    if (fCaixa.dsLanCaixa.Current != null)
                                                    {
                                                        fAcerto.rAcerto.rCaixa = fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa;
                                                        if (MessageBox.Show("Deseja gerar credito com a sobra de dinheiro?", "Pergunta", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                        {
                                                            fAcerto.rAcerto.rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                                                            fAcerto.rAcerto.rAdto.Cd_empresa = fAcerto.rAcerto.Cd_empresa;
                                                            fAcerto.rAcerto.rAdto.Cd_clifor = fAcerto.rAcerto.Cd_motorista;
                                                            //endereco
                                                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fAcerto.rAcerto.rAdto.Cd_clifor,
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
                                                                                                                          string.Empty,
                                                                                                                          string.Empty,
                                                                                                                          string.Empty,
                                                                                                                          1,
                                                                                                                          null);
                                                            if (lEnd.Count > 0)
                                                                fAcerto.rAcerto.rAdto.CD_Endereco = lEnd[0].Cd_endereco;
                                                            fAcerto.rAcerto.rAdto.Tp_movimento = "C";
                                                            fAcerto.rAcerto.rAdto.Dt_lancto = fAcerto.rAcerto.rCaixa.Dt_lancto;
                                                            fAcerto.rAcerto.rAdto.Vl_adto = fAcerto.rAcerto.rCaixa.Vl_RECEBER;
                                                            fAcerto.rAcerto.rAdto.ST_ADTO = "A";
                                                            fAcerto.rAcerto.rAdto.TP_Lancto = "R";
                                                            fAcerto.rAcerto.rAdto.Cd_contager_qt = fAcerto.rAcerto.rCaixa.Cd_ContaGer;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        }
                                        if (fAcerto.rAcerto.Vl_resultado < decimal.Zero)
                                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                            {
                                                fDup.Text = "DUPLICATA A PAGAR PARA O MOTORISTA";
                                                //Empresa
                                                fDup.vCd_empresa = fAcerto.rAcerto.Cd_empresa;
                                                fDup.vNm_empresa = fAcerto.rAcerto.Nm_empresa;
                                                fDup.cd_empresa.Enabled = false;
                                                fDup.bb_empresa.Enabled = false;
                                                //Cliente
                                                fDup.vCd_clifor = fAcerto.rAcerto.Cd_motorista;
                                                fDup.vNm_clifor = fAcerto.rAcerto.Nm_motorista;
                                                fDup.cd_clifor.Enabled = false;
                                                fDup.bb_clifor.Enabled = false;
                                                //endereco
                                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fDup.vCd_clifor,
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
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              1,
                                                                                                              null);
                                                if (lEnd.Count > 0)
                                                {
                                                    fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                                    fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                                    fDup.cd_endereco.Enabled = false;
                                                    fDup.bb_endereco.Enabled = false;
                                                }
                                                fDup.vTp_mov = "P";
                                                fDup.vVl_documento = Math.Abs(fAcerto.rAcerto.Vl_resultado);
                                                fDup.vl_documento_index.Enabled = false;
                                                fDup.vNr_docto = "AC" + fAcerto.rAcerto.Id_acertostr;
                                                if (fDup.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (fDup.dsDuplicata.Count > 0)
                                                        fAcerto.rAcerto.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar financeiro para processar acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        fAcerto.rAcerto.lCartaFrete.ForEach(p =>
                                        {
                                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                            {
                                                fDup.Text = "DUPLICATA CARTA FRETE Nº" + p.Nr_cartafretestr;
                                                //Empresa
                                                fDup.vCd_empresa = fAcerto.rAcerto.Cd_empresa;
                                                fDup.vNm_empresa = fAcerto.rAcerto.Nm_empresa;
                                                fDup.cd_empresa.Enabled = false;
                                                fDup.bb_empresa.Enabled = false;
                                                fDup.vTp_mov = "P";
                                                fDup.vVl_documento = p.Vl_documento;
                                                fDup.vl_documento_index.Enabled = false;
                                                fDup.vNr_docto = "CARTAFRETE" + p.Nr_cartafretestr;
                                                if (fDup.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (fDup.dsDuplicata.Count > 0)
                                                        p.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar financeiro para processar acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        });
                                        try
                                        {
                                            CamadaNegocio.Frota.TCN_AcertoMotorista.ProcessarAcerto(fAcerto.rAcerto, null);
                                            MessageBox.Show("Acerto processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
        }

        private void listaDeMudançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsMudanca.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsMudanca;
                    Rel.Nome_Relatorio = "TFLanMudanca_Lista";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "TFLanMudanca_Lista";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE MUDANÇAS";

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
                                           "RELATORIO LISTA DE MUDANÇAS",
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
                                               "RELATORIO LISTA DE MUDANÇAS",
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void gMudanca_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gMudanca.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsMudanca.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Mudanca.TRegistro_LanMudanca());
            CamadaDados.Mudanca.TList_LanMudanca lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gMudanca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gMudanca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Mudanca.TList_LanMudanca(lP.Find(gMudanca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gMudanca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Mudanca.TList_LanMudanca(lP.Find(gMudanca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gMudanca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsMudanca.List as CamadaDados.Mudanca.TList_LanMudanca).Sort(lComparer);
            bsMudanca.ResetBindings(false);
            gMudanca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void pesquisaDeSatisfaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsMudanca.Current != null)
            {
                if (!(bsMudanca.Current as TRegistro_LanMudanca).St_registro.Equals("1"))
                {
                    MessageBox.Show("Só é permitido gerar documento de mudança APROVADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Mudanca.TList_LanMudanca() { bsMudanca.Current as TRegistro_LanMudanca };
                    Rel.DTS_Relatorio = bs;

                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsMudanca.Current as TRegistro_LanMudanca).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    //Endereco Cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor,
                                                                                                    (bsMudanca.Current as TRegistro_LanMudanca).Cd_endereco,
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
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    1,
                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_ENDCLI", bsEndCli);
                    Rel.Nome_Relatorio = "FLanMudancaPesquisa";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "MUD";
                    Rel.Ident = "FLanMudancaPesquisa";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsMudanca.Current as TRegistro_LanMudanca).Cd_clifor;
                    fImp.pMensagem = "PESQUISA DE SATISFAÇÃO";

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
                                           "PESQUISA DE SATISFAÇÃO",
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
                                               "PESQUISA DE SATISFAÇÃO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void bb_copiar_Click(object sender, EventArgs e)
        {

            using (TFMudanca fMudanca = new TFMudanca())
            {
                fMudanca.lItens = (bsMudanca.Current as TRegistro_LanMudanca).lItensMud;
                if (fMudanca.ShowDialog() == DialogResult.OK) 
                    if (fMudanca.rMudanca != null)
                        try
                        {
                            TCN_LanMudanca.Gravar(fMudanca.rMudanca, null);
                            MessageBox.Show("Mudança gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Aprovar Mudança
                            if (fMudanca.St_aprovada)
                            {
                                if (fMudanca.rMudanca.St_utilizaguardamoveisbool)
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Nº Box";
                                    fMudanca.rMudanca.Nr_guardavol = ibp.ShowDialog();
                                }
                                TCN_LanMudanca.AprovarMudanca(fMudanca.rMudanca, null);
                                MessageBox.Show("Mudança aprovada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.LimparCampos();
                            id_mudanca.Text = fMudanca.rMudanca.Id_mudancastr;
                            cd_empresa.Text = fMudanca.rMudanca.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

    }

}
