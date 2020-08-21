using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaFrete : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete> lfat;
        public List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete> lFat
        {
            get
            {
                if (bsFrete.Count > 0)
                    return (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lfat = value; }
        }
        public TFProcessaFrete()
        {
            InitializeComponent();
        }
        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsFrete.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Frete(cd_empresa.Text,
                                                                                             nr_notafiscal.Text,
                                                                                             string.Empty,
                                                                                             cd_transportadora.Text,
                                                                                             dt_ini.Text,
                                                                                             dt_fin.Text,
                                                                                             st_reprocessar.Checked,
                                                                                             string.Empty,
                                                                                             contadeb.Text,
                                                                                             contacred.Text,
                                                                                             vl_ini.Value,
                                                                                             vl_fin.Value,
                                                                                             null);
            if (bsFrete.Count > 0)
            {
                tot_receber.Text = (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                                          (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                                          p.Id_loteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGFaturamento fCfg = new TFCFGFaturamento())
            {
                if (bsFrete.Current != null)
                {
                    fCfg.pCd_empresa = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_empresa;
                    fCfg.pNm_empresa = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_movimentacao;
                    fCfg.pDs_movimentacao = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Ds_movimentacao;
                    fCfg.pCd_clifor = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_transportadora;
                    fCfg.pNm_clifor = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Nm_transportadora;
                    fCfg.pCd_contadeb = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Ds_contadeb;
                    fCfg.pClassifdeb = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Ds_contacred;
                    fCfg.pClassifcred = (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_classificacaocred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rFat != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Gravar(fCfg.rFat, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaFrete_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lfat != null)
                if (lfat.Count > 0)
                    bsFrete.DataSource = lfat;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_transportadora }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_contadeb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                            FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                contadeb.Text = rConta.Cd_conta_ctbstr;
        }

        private void contadeb_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + contadeb.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { contadeb }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                            FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                contacred.Text = rConta.Cd_conta_ctbstr;
        }

        private void contacred_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + contacred.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { contacred }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            if (bsFrete.Count > 0)
            {
                (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFaturamento.Checked);
                bsFrete.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gFaturamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsFrete.Current != null))
            {
                if (!(bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).St_processar)
                {
                    if (!(bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).CD_ContaCre.HasValue ||
                        !(bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).Cd_movimentacao.ToString().Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).St_processar = true;
                }
                else
                    (bsFrete.Current as CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete).St_processar = false;
                bsFrete.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gFaturamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFaturamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFrete.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete());
            CamadaDados.Contabil.TList_ProcConhecimentoFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcConhecimentoFrete(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcConhecimentoFrete(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFrete.List as CamadaDados.Contabil.TList_ProcConhecimentoFrete).Sort(lComparer);
            bsFrete.ResetBindings(false);
            gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsFrete.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete> lista =
                    (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                p.Id_loteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsFrete.DataSource = lista;
            }
        }

        private void gFaturamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>)[e.RowIndex].CD_ContaCre !=
                    (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>)[e.RowIndex].Cd_contactb_C ||
                    (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>)[e.RowIndex].CD_ContaDeb !=
                    (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>)[e.RowIndex].Cd_contactb_D) &&
                    (bsFrete.List as List<CamadaDados.Contabil.TRegistro_ProcConhecimentoFrete>)[e.RowIndex].Id_loteCTB.HasValue)
                    gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void TFProcessaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                afterConfig();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            afterConfig();
        }
    }
}
