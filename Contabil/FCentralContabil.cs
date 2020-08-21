using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFCentralContabil : Form
    {
        private bool Altera_Relatorio = false;

        public TFCentralContabil()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("<TODOS>", string.Empty));
            cbx.Add(new TDataCombo("FATURAMENTO", "FA"));
            cbx.Add(new TDataCombo("CUPOM ELETRONICO", "CE"));
            cbx.Add(new TDataCombo("CONHECIMENTO FRETE", "CT"));
            cbx.Add(new TDataCombo("CMV", "CM"));
            cbx.Add(new TDataCombo("IMPOSTOS FATURAMENTO", "IF"));
            cbx.Add(new TDataCombo("FINANCEIRO", "FI"));
            cbx.Add(new TDataCombo("CAIXA", "CX"));
            cbx.Add(new TDataCombo("CHEQUE COMPENSADO", "CC"));
            cbx.Add(new TDataCombo("FATURA CARTÃO", "FC"));
            cbx.Add(new TDataCombo("PROVISÃO ESTOQUE", "PE"));
            cbx.Add(new TDataCombo("LANÇAMENTO AVULSO", "AV"));
            cbx.Add(new TDataCombo("IMPLANTAÇÃO SALDO", "IS"));
            cbx.Add(new TDataCombo("COMPLEMENTO NOTAS FIXAR", "CF"));
            cbx.Add(new TDataCombo("ADIANTAMENTOS RECEBIDOS/CONCEDIDOS", "AD"));
            cbx.Add(new TDataCombo("ZERAMENTO", "ZR"));
            tp_integracao.DataSource = cbx;
            tp_integracao.DisplayMember = "Display";
            tp_integracao.ValueMember = "Value";
        }

        private void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpLancto))
            {
                bsLanContabil.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.Buscar(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                         cd_conta.Text,
                                                                                         DT_Inic.Text,
                                                                                         DT_Final.Text,
                                                                                         id_lotectb.Text,
                                                                                         nr_docto.Text,
                                                                                         vl_ini.Value,
                                                                                         vl_fin.Value,
                                                                                         tp_integracao.SelectedValue != null ? tp_integracao.SelectedValue.ToString() : string.Empty,
                                                                                         null);
                if (bsLanContabil.Count > 0)
                {
                    totdebito.Text = (bsLanContabil.List as CamadaDados.Contabil.TList_LanContabil).Where(p => p.D_c.Trim().ToUpper().Equals("D")).Sum(p => p.Valor).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                    totcredito.Text = (bsLanContabil.List as CamadaDados.Contabil.TList_LanContabil).Where(p => p.D_c.Trim().ToUpper().Equals("C")).Sum(p => p.Valor).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                }
            }
            else
            {
                if (cbEmpresa.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatório informar empresa para visualizar balanço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(DT_Inic.Text.SoNumero()))
                {
                    MessageBox.Show("Obrigatório informar data inicial para visualizar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DateTime? dt_fin = null;
                if (!string.IsNullOrEmpty(DT_Final.Text.SoNumero()))
                    dt_fin = DateTime.Parse(DT_Final.Text);
                bsBalanco.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.GerarBalanco(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           DateTime.Parse(DT_Inic.Text),
                                                                                           dt_fin,
                                                                                           st_contamovimento.Checked,
                                                                                           st_contasaldo.Checked,
                                                                                           cbContaSintetica.Checked ? "S" : string.Empty,
                                                                                           st_ignorarzeramento.Checked,
                                                                                           stCliforSintetico.Checked);
                if (bsBalanco.Count > 0)
                {
                    lblAudit.Text = (bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Where(p => p.Classificacao.Trim().Length.Equals(1)).Sum(p => p.Natureza.Trim().ToUpper().Equals("C") ? (-1) * p.Vl_atual : p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                    if((bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Exists(p => p.Classificacao.Trim().Equals("3")) &&
                        (bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Exists(p => p.Classificacao.Trim().Equals("4")))
                        lblLucro.Text = ((bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Find(p => p.Classificacao.Trim().Equals("3")).Vl_atual -
                                        (bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Find(p => p.Classificacao.Trim().Equals("4")).Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                }
            }                                                                                        
        }

        private void ExcluirLancamento()
        {
            if (bsLanContabil.Current != null)
                if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().Equals("AV") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().Equals("IS"))
                {
                    if (MessageBox.Show("Confirma exclusão do lançamento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                         DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_LanContabil.ExcluirLanctoAvulso(bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB, null);
                            MessageBox.Show("Lançamento contabil avulso excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    try
                    {
                        new CamadaDados.Contabil.TCD_LanctosCTB().ExcluiLanctosLote((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).ID_LoteCTB);
                        MessageBox.Show("Lote Contabil excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro excluir lote: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AlterarLancamento()
        {
            if (bsLanContabil.Current != null)
                if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("AV") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("IS"))
                    if (CamadaNegocio.Contabil.TCN_Zeramento.BuscarUltimoFechamento((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Cd_empresa,
                                                                                   (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Data.Value,
                                                                                   null))
                        using (TFAlterarLanctoCTB fAlt = new TFAlterarLanctoCTB())
                        {
                            fAlt.rLancto = bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB;
                            if (fAlt.ShowDialog() == DialogResult.OK)
                                afterBusca();
                        }
                    else MessageBox.Show("Os lançamentos datados em '" + (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Data.Value.ToString("dd/MM/yyyy") + "' já tiveram fechamento contábil!", "Mensagem",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Permitido alterar somente lançamento contábil AVULSO ou IMPLANTAÇÃO SALDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFCentralContabil_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
            tlpRel.ColumnStyles[1].Width = 0;
            tlpLanctos.RowStyles[1].Height = 0;
            cbEmpresa_SelectedIndexChanged(this, new EventArgs());
        }
                        
        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                cd_conta.Text = rConta.Cd_conta_ctbstr;
        }

        private void cd_contacred_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cd_conta.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void implantarSaldoContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFImplantarSaldo fSaldo = new TFImplantarSaldo())
            {
                fSaldo.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (tcCentral.SelectedTab.Equals(tpBalanco) && bsBalanco.Current != null)
                    if ((bsBalanco.Current as CamadaDados.Contabil.TRegistro_BalancoSintetico).Tp_conta.Trim().Equals("A"))
                        fSaldo.pCd_conta = (bsBalanco.Current as CamadaDados.Contabil.TRegistro_BalancoSintetico).Cd_contaCTBstr;
                if(fSaldo.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo val = new CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo();
                        val.Cd_empresa = fSaldo.pCd_empresa;
                        val.Dt_lan = fSaldo.pDt_lancto;
                        val.Complhistorico = fSaldo.pComp;
                        val.lLanctoAvulso.Add(new CamadaDados.Contabil.TRegistro_LanctoAvulso()
                        {
                            Cd_conta_ctbstr = fSaldo.pCd_conta,
                            Vl_lancto = fSaldo.pVl_lancto,
                            D_C = fSaldo.pD_C
                        });
                        CamadaNegocio.Contabil.TCN_LanMultiplo.ImplantarSaldo(val, null);
                        MessageBox.Show("Lançamento contabil gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFCentralContabil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar layout.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gLanContabil_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLanContabil.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLanContabil.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_LanctosCTB());
            CamadaDados.Contabil.TList_LanContabil lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLanContabil.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLanContabil.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_LanContabil(lP.Find(gLanContabil.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLanContabil.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_LanContabil(lP.Find(gLanContabil.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLanContabil.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLanContabil.List as CamadaDados.Contabil.TList_LanContabil).Sort(lComparer);
            bsLanContabil.ResetBindings(false);
            gLanContabil.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBalanco_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(6))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("S"))
                        gBalanco.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else gBalanco.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFContabilAvulso fContabil = new TFContabilAvulso())
            {
                fContabil.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                fContabil.ShowDialog();
                afterBusca();
            }
        }

        private void lançamentoNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFLanctoNormalAvulso fLancto = new TFLanctoNormalAvulso())
            {
                fLancto.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                fLancto.ShowDialog();
                afterBusca();
            }
        }

        private void excluirLançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirLancamento();
        }

        private void notasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaFaturamento fProc = new TFProcessaFaturamento())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if(fProc.ShowDialog() == DialogResult.OK)
                    if(fProc.lFat != null)
                        if(fProc.lFat.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Faturamento(fProc.lFat, null);
                                MessageBox.Show("Processamento Contábil FATURAMENTO concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void impostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaImpostos fProc = new TFProcessaImpostos())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if(fProc.ShowDialog() == DialogResult.OK)
                    if(fProc.lProc != null)
                        if(fProc.lProc.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Impostos(fProc.lProc, null);
                                MessageBox.Show("Processamento Contábil IMPOSTOS concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void financeiroAvulsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaFinanceiro fProc = new TFProcessaFinanceiro())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lFin != null)
                        if(fProc.lFin.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Financeiro(fProc.lFin, null);
                                MessageBox.Show("Processamento Contábil FINANCEIRO concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessarCaixa fProc = new TFProcessarCaixa())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lCaixa != null)
                        if(fProc.lCaixa.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Caixa(fProc.lCaixa, null);
                                MessageBox.Show("Processamento Contábil CAIXA concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void chequesCompensadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaCheque fProc = new TFProcessaCheque())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lCh != null)
                        if (fProc.lCh.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ChequeCompensado(fProc.lCh, null);
                                MessageBox.Show("Processamento Contábil CHEQUE COMPENSADO concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void provisãoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaProvisao fProc = new TFProcessaProvisao())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lProvisao != null)
                        if (fProc.lProvisao.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ProvEstoque(fProc.lProvisao, null);
                                MessageBox.Show("Processamento Contábil PROVISÃO ESTOQUE concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void tsmRelBalancete_Click(object sender, EventArgs e)
        {
            if (bsBalanco.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_CTB_BALANCETE";
                Relatorio.NM_Classe = Name.Trim();
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);

                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                Relatorio.DTS_Relatorio = bsBalanco;
                if (BinEmpresa.Current != null)
                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                Relatorio.Parametros_Relatorio.Add("DT_INI", DT_Inic.Text);
                Relatorio.Parametros_Relatorio.Add("DT_FIN", DT_Final.Text);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "BALANCETE CONTABIL";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "BALANCETE CONTABIL",
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

        private void excluirLançamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExcluirLancamento();
        }

        private void alterarLançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarLancamento();
        }

        private void reprocessarLançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsLanContabil.Current != null)
                if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("FA"))
                    using (TFProcessaFaturamento fProc = new TFProcessaFaturamento())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lFat = new CamadaDados.Contabil.TCD_Lan_ProcFaturamento().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_LoteCTB_Fat",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lFat != null)
                                if (fProc.lFat.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Faturamento(fProc.lFat, null);
                                        MessageBox.Show("Processamento Contábil FATURAMENTO concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("IF"))
                    using (TFProcessaImpostos fProc = new TFProcessaImpostos())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lProc = new CamadaDados.Contabil.TCD_ProcImpostos().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.Id_LoteCTB_Calculado",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lProc != null)
                                if (fProc.lProc.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Impostos(fProc.lProc, null);
                                        MessageBox.Show("Processamento Contábil IMPOSTOS concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("FI"))
                    using (TFProcessaFinanceiro fProc = new TFProcessaFinanceiro())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lFin = new CamadaDados.Contabil.TCD_Lan_ProcFinanceiro().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_LoteCTB",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lFin != null)
                                if (fProc.lFin.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Financeiro(fProc.lFin, null);
                                        MessageBox.Show("Processamento Contábil FINANCEIRO concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("CC"))
                    using (TFProcessaCheque fProc = new TFProcessaCheque())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lCh = new CamadaDados.Contabil.TCD_Lan_ProcChequeCompensado().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_loteCTB",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lCh != null)
                                if (fProc.lCh.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ChequeCompensado(fProc.lCh, null);
                                        MessageBox.Show("Processamento Contábil CHEQUE COMPENSADO concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("CX"))
                    using (TFProcessarCaixa fProc = new TFProcessarCaixa())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lCaixa = new CamadaDados.Contabil.TCD_Lan_ProcCaixa().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_LoteCTB",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lCaixa != null)
                                if (fProc.lCaixa.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Caixa(fProc.lCaixa, null);
                                        MessageBox.Show("Processamento Contábil CAIXA concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if ((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("PE"))
                    using (TFProcessaProvisao fProc = new TFProcessaProvisao())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lProvisao = new CamadaDados.Contabil.TCD_Lan_ProcProvEstoque().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.Id_LoteCTB",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                                }
                                            });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lProvisao != null)
                                if (fProc.lProvisao.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ProvEstoque(fProc.lProvisao, null);
                                        MessageBox.Show("Processamento Contábil PROVISÃO ESTOQUE concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else if((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("CM"))
                    using (TFProcessaCMV fProc = new TFProcessaCMV())
                    {
                        fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                        fProc.lCMV = new CamadaDados.Contabil.TCD_Lan_ProcCMV().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_LoteCTB_CMV",
                                                vOperador = "=",
                                                vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                            }
                                        });
                        if (fProc.ShowDialog() == DialogResult.OK)
                            if (fProc.lCMV != null)
                                if (fProc.lCMV.Count > 0)
                                    try
                                    {
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_CMV(fProc.lCMV, null);
                                        MessageBox.Show("Processamento Contábil CMV concluido com sucesso.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                else MessageBox.Show("Tipo de integração não permite reprocessamento de registros.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cMVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaCMV fProc = new TFProcessaCMV())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lCMV != null)
                        if (fProc.lCMV.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_CMV(fProc.lCMV, null);
                                MessageBox.Show("Processamento Contábil CMV concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void complementoNotasFixarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaCompFixar fProc = new TFProcessaCompFixar())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lComp != null)
                        if (fProc.lComp.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_CompFixar(fProc.lComp, null);
                                MessageBox.Show("Processamento Contábil COMPLEMENTO NOTAS FIXAR concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void razãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Relatorio.TFRel_RazaoContabil fRel = new Contabil.Relatorio.TFRel_RazaoContabil())
            {
                fRel.ShowDialog();
            }
        }

        private void detalharContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsBalanco.Current != null)
            {
                bsRazao.DataSource = new CamadaDados.Contabil.TCD_LanctosCTB().SelectRazaoContabil("'" + (cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString()) + "'",
                                                                                                   string.Empty,
                                                                                                   (bsBalanco.Current as CamadaDados.Contabil.TRegistro_BalancoSintetico).Classificacao,
                                                                                                   DT_Inic.Data,
                                                                                                   DT_Final.Data);
                tot_credito.Text = (bsRazao.List as List<CamadaDados.Contabil.TRegistro_RazaoContabil>).Sum(p => p.Vl_credito).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_debito.Text = (bsRazao.List as List<CamadaDados.Contabil.TRegistro_RazaoContabil>).Sum(p => p.Vl_debito).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tlpRel.ColumnStyles[1].SizeType = SizeType.Percent;
                tlpRel.ColumnStyles[1].Width = 50;
            }
        }

        private void gBalanco_Click(object sender, EventArgs e)
        {
            tlpRel.ColumnStyles[1].Width = 0;
        }

        private void visualizarDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsLanContabil.Current != null)
            {
                bsLanCPartida.DataSource = new CamadaDados.Contabil.TCD_LanctosCTB().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_lotectb",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Id_lotectbstr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_conta_ctb",
                                                    vOperador = "<>",
                                                    vVL_Busca = (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Cd_conta_ctbstr
                                                }
                                            }, 0, string.Empty, string.Empty);
                tlpLanctos.RowStyles[1].Height = 174;
            }
        }

        private void gLanContabil_Click(object sender, EventArgs e)
        {
            tlpLanctos.RowStyles[1].Height = 0;
        }

        private void rastrearLançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bsLanContabil.Current != null)
                if((bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("FA") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("IF") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("FI") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("CC") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("CX") ||
                    (bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB).Tp_integracao.Trim().ToUpper().Equals("AD"))
                    using (TFRastrearLancto fRastrear = new TFRastrearLancto())
                    {
                        fRastrear.rLancto = bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB;
                        fRastrear.ShowDialog();
                    }
        }

        private void adiantamentosRecebidosConcedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessarAdto fProc = new TFProcessarAdto())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lAdto != null)
                        if (fProc.lAdto.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Adto(fProc.lAdto, null);
                                MessageBox.Show("Processamento Contábil ADIANTAMENTO concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Relatorio.TFRel_DiarioContabil fRel = new Contabil.Relatorio.TFRel_DiarioContabil())
            {
                fRel.ShowDialog();
            }
        }

        private void zeramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFZeramento fZeramento = new TFZeramento())
            {
                fZeramento.ShowDialog();
            }
        }

        private void balançoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsBalanco.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_CTB_BALANCO";
                Relatorio.Ident = "REL_CTB_BALANCO";
                Relatorio.NM_Classe = Name.Trim();
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);

                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                BindingSource bs = new BindingSource();
                bs.DataSource = (bsBalanco.List as List<CamadaDados.Contabil.TRegistro_BalancoSintetico>).Where(p => p.Classificacao.StartsWith("1") || p.Classificacao.StartsWith("2")).ToList();
                Relatorio.DTS_Relatorio = bs;
                if (BinEmpresa.Current != null)
                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                Relatorio.Parametros_Relatorio.Add("DT_INI", DT_Inic.Text);
                Relatorio.Parametros_Relatorio.Add("DT_FIN", DT_Final.Text);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "BALANÇO CONTABIL";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "BALANÇO CONTABIL",
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

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
            {
                object obj = new CamadaDados.TDataQuery().executarEscalar("select top 1 a.dt_zeramento from tb_ctb_zeramento a where a.cd_empresa = '" + cbEmpresa.SelectedValue.ToString() + "' order by a.dt_zeramento desc", null);
                lblZeramento.Text = obj == null ? string.Empty : DateTime.Parse(obj.ToString()).ToString("dd/MM/yyyy");
            }
        }

        private void dREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Relatorio.TFRel_DRE fDRE = new Relatorio.TFRel_DRE())
            {
                fDRE.ShowDialog();
            }
        }

        private void excluirUltimoZeramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            //Buscar ultimo zeramento
            CamadaDados.Contabil.TList_Zeramento lZer =
            new CamadaDados.Contabil.TCD_Zeramento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                    }
                }, 1, string.Empty, "a.dt_zeramento desc");
            if (lZer.Count > 0)
            {
                if(MessageBox.Show("Confirma exclusão do ultimo zeramento " + lZer[0].Id_zeramentostr + "?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Contabil.TCN_Zeramento.ExcluirUltimoZeramento(lZer[0], null);
                        MessageBox.Show("Ultimo zeramento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Não existe zeramento para a empresa selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportarDominioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFExportDominio fExport = new TFExportDominio())
            {
                fExport.ShowDialog();
            }
        }

        private void listaLançamentosContábeisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsLanContabil.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsLanContabil;
                    Rel.Nome_Relatorio = "TFCentralContabil_Lista";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFCentralContabil_Lista";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LANÇAMENTOS CONTÁBEIS";

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
                                           "RELATORIO LANÇAMENTOS CONTÁBEIS",
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
                                           "RELATORIO LANÇAMENTOS CONTÁBEIS",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void cartãoCréditoDébitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaCartao fProc = new TFProcessaCartao())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lCcd != null)
                        if (fProc.lCcd.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_CartaoDC(fProc.lCcd, null);
                                MessageBox.Show("Processamento Contábil CARTÃO CRÉDITO/DÉBITO concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void nFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaNFCe fProc = new TFProcessaNFCe())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lFat != null)
                        if (fProc.lFat.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_NFCe(fProc.lFat, null);
                                MessageBox.Show("Processamento Contábil NFC-e concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void conhecimentoFreteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFProcessaFrete fProc = new TFProcessaFrete())
            {
                fProc.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lFat != null)
                        if (fProc.lFat.Count > 0)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Frete(fProc.lFat, null);
                                MessageBox.Show("Processamento Contábil Frete concluido com sucesso.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
