using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using FormBusca;
using Proc_Commoditties;

namespace Faturamento
{
    public partial class TFLan_ConhecimentoFrete : Form
    {
        private bool Altera_Relatorio = false;
        public TFLan_ConhecimentoFrete()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            nr_ctrcbusca.Clear();
            cd_empresabusca.Clear();
            cd_transportadorabusca.Clear();
            cd_movimentacaobusca.Clear();
            cd_cmibusca.Clear();
            cd_remetentebusca.Clear();
            cd_destinatariobusca.Clear();
            nr_seriebusca.Clear();
            nr_notafiscal.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            cbAtivo.Checked = false;
            cbProcessado.Checked = false;
            cbCancelado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFConhecimentoFrete fCtrc = new TFConhecimentoFrete())
            {
                if(fCtrc.ShowDialog() == DialogResult.OK)
                    if(fCtrc.rCtrc != null)
                        try
                        {
                            //Verificar se o cmi gera financeiro
                            CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCtrc.rCtrc.Cd_cmistr,
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
                                fCtrc.rCtrc.rCmi = lCmi[0];
                            if (lCmi.Exists(p => p.Tp_duplicata.Trim() != string.Empty))
                            {
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = fCtrc.rCtrc.Cd_empresa;
                                    fDuplicata.vNm_empresa = fCtrc.rCtrc.Nm_empresa;
                                    fDuplicata.vCd_clifor = fCtrc.rCtrc.Cd_transportadora;
                                    fDuplicata.vNm_clifor = fCtrc.rCtrc.Nm_transportadora;
                                    fDuplicata.vCd_endereco = fCtrc.rCtrc.Cd_endtransportadora;
                                    fDuplicata.vDs_endereco = fCtrc.rCtrc.Ds_endtransportadora;
                                    fDuplicata.vNr_docto = fCtrc.rCtrc.Nr_ctrcstr;
                                    fDuplicata.vDt_emissao = fCtrc.rCtrc.Dt_emissaostr;
                                    fDuplicata.vVl_documento = fCtrc.rCtrc.Vl_frete;
                                    fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                    fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                    fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                    //Verificar se a serie do conhecimento de frete tem tipo de documento configurado
                                    CamadaDados.Faturamento.Cadastros.TList_CadSerieNF lSerie =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(fCtrc.rCtrc.Nr_serie,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 "A",
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                    fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                    fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                    fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                    fDuplicata.vSt_ctrc = true;
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        if (fDuplicata.dsDuplicata.Current != null)
                                        {
                                            fCtrc.rCtrc.rDuplicata =
                                                fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            bsCTRC.ResetCurrentItem();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Gravar(fCtrc.rCtrc, null);
                            MessageBox.Show("CTRC gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresabusca.Text = fCtrc.rCtrc.Cd_empresa;
                            nr_ctrcbusca.Text = fCtrc.rCtrc.Nr_ctrcstr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public void afterAltera()
        {
            if (bsCTRC.Current != null)
            {
                if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido alterar conhecimento frete PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar conhecimento frete CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFConhecimentoFrete fCtrc = new TFConhecimentoFrete())
                {
                    fCtrc.rCtrc = bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete;
                    if (fCtrc.ShowDialog() == DialogResult.OK)
                        try
                        {
                            //Verificar se o cmi gera financeiro
                            CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCtrc.rCtrc.Cd_cmistr,
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
                                fCtrc.rCtrc.rCmi = lCmi[0];
                            if (lCmi.Exists(p => p.Tp_duplicata.Trim() != string.Empty))
                            {
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = fCtrc.rCtrc.Cd_empresa;
                                    fDuplicata.vNm_empresa = fCtrc.rCtrc.Nm_empresa;
                                    fDuplicata.vCd_clifor = fCtrc.rCtrc.Cd_transportadora;
                                    fDuplicata.vNm_clifor = fCtrc.rCtrc.Nm_transportadora;
                                    fDuplicata.vCd_endereco = fCtrc.rCtrc.Cd_endtransportadora;
                                    fDuplicata.vDs_endereco = fCtrc.rCtrc.Ds_endtransportadora;
                                    fDuplicata.vNr_docto = fCtrc.rCtrc.Nr_ctrcstr;
                                    fDuplicata.vDt_emissao = fCtrc.rCtrc.Dt_emissaostr;
                                    fDuplicata.vVl_documento = fCtrc.rCtrc.Vl_frete;
                                    fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                    fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                    fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                    //Verificar se a serie do conhecimento de frete tem tipo de documento configurado
                                    CamadaDados.Faturamento.Cadastros.TList_CadSerieNF lSerie =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(fCtrc.rCtrc.Nr_serie,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 "A",
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                    fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                    fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                    fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                    fDuplicata.vSt_ctrc = true;
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        if (fDuplicata.dsDuplicata.Current != null)
                                        {
                                            fCtrc.rCtrc.rDuplicata =
                                                fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            bsCTRC.ResetCurrentItem();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Gravar(fCtrc.rCtrc, null);
                            LimparFiltros();
                            cd_empresabusca.Text = fCtrc.rCtrc.Cd_empresa;
                            nr_ctrcbusca.Text = fCtrc.rCtrc.Nr_ctrcstr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsCTRC.Current != null)
            {
                if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("C") &&
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Tp_emissao.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Conhecimento frete ja esta cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma " +
                    ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A") ? "exclusão" : "cancelamento") + " do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Excluir(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, null);
                        MessageBox.Show("Conhecimento de frete " +
                            ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A") ? "exclusão" : "cancelamento") + " com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro " +
                            ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A") ? "exclusão" : "cancelamento") + " conhecimento frete: " + ex.Message.Trim());
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar conhecimento frete para " +
                    ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("A") ? "exclusão" : "cancelamento") + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string st_registro = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                st_registro += virg + "'A'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                st_registro += virg + "'C'";
                virg = ",";
            }
            if (cbProcessado.Checked)
            {
                st_registro += virg + "'P'";
                virg = ",";
            }
            bsCTRC.DataSource =
                CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar(cd_empresabusca.Text,
                                                                            string.Empty,
                                                                            nr_ctrcbusca.Text,
                                                                            cd_transportadorabusca.Text,
                                                                            string.Empty,
                                                                            cd_remetentebusca.Text,
                                                                            string.Empty,
                                                                            cd_destinatariobusca.Text,
                                                                            string.Empty,
                                                                            cd_movimentacaobusca.Text,
                                                                            cd_cmibusca.Text,
                                                                            nr_seriebusca.Text,
                                                                            (rbEmissao.Checked ? "E" : string.Empty),
                                                                            DT_Inicial.Text,
                                                                            DT_Final.Text,
                                                                            st_registro,
                                                                            nr_notafiscal.Text,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
            bsCTRC_PositionChanged(this, new EventArgs());
        }

        private void ReprocessarFiscal()
        {
            if (bsCTRC.Current != null)
            {
                if ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("P"))
                {

                }
                else
                    MessageBox.Show("Permitido reprocessar fiscal somente de CTRC processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print()
        {
            if (bsCTRC.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCTRC;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLan_ConhecimentoFrete";
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
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void ImportarXmlCte()
        {
            using (TFConhecimentoFrete fCtrc = new TFConhecimentoFrete())
            {
                fCtrc.St_Importar = true;
                if (fCtrc.ShowDialog() == DialogResult.OK)
                    if (fCtrc.rCtrc != null)
                        try
                        {
                            //Verificar se o cmi gera financeiro
                            CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCtrc.rCtrc.Cd_cmistr,
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
                                fCtrc.rCtrc.rCmi = lCmi[0];
                            if (lCmi.Exists(p => p.Tp_duplicata.Trim() != string.Empty))
                            {
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = fCtrc.rCtrc.Cd_empresa;
                                    fDuplicata.vNm_empresa = fCtrc.rCtrc.Nm_empresa;
                                    fDuplicata.vCd_clifor = fCtrc.rCtrc.Cd_transportadora;
                                    fDuplicata.vNm_clifor = fCtrc.rCtrc.Nm_transportadora;
                                    fDuplicata.vCd_endereco = fCtrc.rCtrc.Cd_endtransportadora;
                                    fDuplicata.vDs_endereco = fCtrc.rCtrc.Ds_endtransportadora;
                                    fDuplicata.vNr_docto = fCtrc.rCtrc.Nr_ctrcstr;
                                    fDuplicata.vDt_emissao = fCtrc.rCtrc.Dt_emissaostr;
                                    fDuplicata.vVl_documento = fCtrc.rCtrc.Vl_frete;
                                    fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                    fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                    fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                    //Verificar se a serie do conhecimento de frete tem tipo de documento configurado
                                    CamadaDados.Faturamento.Cadastros.TList_CadSerieNF lSerie =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(fCtrc.rCtrc.Nr_serie,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 "A",
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                    fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                    fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                    fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                    fDuplicata.vSt_ctrc = true;
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        if (fDuplicata.dsDuplicata.Current != null)
                                        {
                                            fCtrc.rCtrc.rDuplicata =
                                                fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            bsCTRC.ResetCurrentItem();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para gravar conhecimento frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Gravar(fCtrc.rCtrc, null);
                            MessageBox.Show("CTRC gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresabusca.Text = fCtrc.rCtrc.Cd_empresa;
                            nr_ctrcbusca.Text = fCtrc.rCtrc.Nr_ctrcstr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLan_ConhecimentoFrete_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gCTRC);
            ShapeGrid.RestoreShape(this, gEstoque);
            ShapeGrid.RestoreShape(this, gImpostosCtrc);
            ShapeGrid.RestoreShape(this, gItensNota);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, dataGridDefault4);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bb_reprocessarfiscal.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR REPROCESSAR FISCAL CTRC", null);
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLan_ConhecimentoFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F10))
                ImportarXmlCte();
            else if (e.KeyCode.Equals(Keys.F12))
                ReprocessarFiscal();
            else if (e.KeyCode.Equals(Keys.F8))
                Print();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsCTRC_PositionChanged(object sender, EventArgs e)
        {
            if (bsCTRC.Current != null)
            {
                if (((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() != string.Empty) &&
                    ((bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC != null))
                {
                    //Buscar notas fiscais
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNf =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ctr_notafiscal x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                        "and x.cd_empresa = '"+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim()+"' "+
                                        "and x.nr_lanctoctr = "+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC+")"
                        }
                    }, 0, string.Empty);
                    //Buscar estoque de complemento
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lEstoque =
                        new CamadaDados.Estoque.TCD_LanEstoque().Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ctr_estoque x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.cd_produto = a.cd_produto "+
                                        "and x.id_lanctoestoque = a.id_lanctoestoque "+
                                        "and x.cd_empresa = '"+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim()+"' "+
                                        "and x.nr_lanctoctr = "+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC+")"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                    //Buscar financeiro
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lParcelas =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_ctr_duplicata x "+
                                            "where x.cd_empresa = a.cd_empresa "+
                                            "and x.nr_lanctoduplicata = a.nr_lancto "+
                                            "and x.cd_empresa = '"+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim()+"' "+
                                            "and x.nr_lanctoctr = "+(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC+")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    //Buscar impostos 
                    (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Buscar(string.Empty,
                                                                                   (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.Value.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   false,
                                                                                   string.Empty,
                                                                                   null);
                    bsCTRC.ResetCurrentItem();
                }
            }
        }

        private void bb_empresabusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresabusca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresabusca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresabusca.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresabusca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_movimentacaobusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|250;" +
                                  "a.cd_movimentacao|Cd. Movimentação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacaobusca },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacaobusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_movimentacao|=|" + cd_movimentacaobusca.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_movimentacaobusca },
                                new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_cmibusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CMI|Descrição CMI|200;" +
                              "a.CD_CMI|Cd. CMI|80";
            string vParam = string.Empty;
            if(cd_movimentacaobusca.Text.Trim() != string.Empty)
                vParam = "|exists|(select 1 from tb_fis_mov_x_cmi x " +
                            "           where x.cd_cmi = a.cd_cmi " +
                            "           and x.cd_movimentacao = " + cd_movimentacaobusca.Text + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cmibusca },
                                new CamadaDados.Fiscal.TCD_CadCMI(), vParam);
        }

        private void cd_cmibusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_cmi|=|" + cd_cmibusca.Text;
            if(cd_movimentacaobusca.Text.Trim() != string.Empty)
                vColunas += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                              "         where x.cd_cmi = a.cd_cmi " +
                              "         and x.cd_movimentacao = " + cd_movimentacaobusca.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_cmibusca },
                                    new CamadaDados.Fiscal.TCD_CadCMI());
        }

        private void bb_seriebusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "b.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80;" +
                              "b.DS_Modelo|Descrição Modelo|350";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_seriebusca },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), string.Empty);
        }

        private void nr_seriebusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_serie|=|'" + nr_seriebusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_seriebusca },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_transportadorabusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadorabusca }, "isnull(a.ST_Transportadora, 'N')|=|'S'");
        }

        private void cd_transportadorabusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_transportadorabusca.Text.Trim() + "';" +
                              "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transportadorabusca },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_remetentebusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100"
                , new Componentes.EditDefault[] { cd_remetentebusca },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
        }

        private void cd_remetentebusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_remetentebusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_remetentebusca },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_destinatariobusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100"
                , new Componentes.EditDefault[] { cd_destinatariobusca },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
        }

        private void cd_destinatariobusca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_destinatariobusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_destinatariobusca },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gCTRC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gCTRC.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gCTRC.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else 
                    {
                        DataGridViewRow linha = gCTRC.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_reprocessarfiscal_Click(object sender, EventArgs e)
        {
            ReprocessarFiscal();            
        }

        private void TFLan_ConhecimentoFrete_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gCTRC);
            ShapeGrid.SaveShape(this, gEstoque);
            ShapeGrid.SaveShape(this, gImpostosCtrc);
            ShapeGrid.SaveShape(this, gItensNota);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, dataGridDefault4);
        }

        private void bb_importaXmlCte_Click(object sender, EventArgs e)
        {
            ImportarXmlCte();
        }

        private void bsNotaFiscal_PositionChanged(object sender, EventArgs e)
        {
            if (bsNotaFiscal.Current != null)
            {
                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).ItensNota =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctofiscal",
                            vOperador = "=",
                            vVL_Busca = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_lanctofiscalstr
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                bsNotaFiscal.ResetCurrentItem();
            }
        }

        private void gCTRC_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCTRC.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCTRC.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete());
            CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCTRC.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCTRC.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCTRC.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCTRC.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCTRC.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sort(lComparer);
            bsCTRC.ResetBindings(false);
            gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}

