using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaImpostos : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_ProcImpostos> lproc;
        public List<CamadaDados.Contabil.TRegistro_ProcImpostos> lProc
        {
            get
            {
                if (bsImpostos.Count > 0)
                    return (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lproc = value; }
        }

        public TFProcessaImpostos()
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
            bsImpostos.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Impostos(cd_empresa.Text,
                                                                                                    string.Empty,
                                                                                                    nr_notafiscal.Text,
                                                                                                    cd_movimentacao.Text,
                                                                                                    string.Empty,
                                                                                                    cd_clifor.Text,
                                                                                                    cd_produto.Text,
                                                                                                    string.Empty,
                                                                                                    dt_ini.Text,
                                                                                                    dt_fin.Text,
                                                                                                    contadeb.Text,
                                                                                                    contacred.Text,
                                                                                                    vl_ini.Value,
                                                                                                    vl_fin.Value,
                                                                                                    st_reprocessar.Checked,
                                                                                                    null);
            if (bsImpostos.Count > 0)
            {
                tot_impcalc.Text = (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).Sum(p => p.Vl_impostocalc).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_impret.Text = (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).Sum(p => p.Vl_impostoretido).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            }
        }

        private void afterConfig()
        {
            using (TFCFGImpostos fCfg = new TFCFGImpostos())
            {
                if (bsImpostos.Current != null)
                {
                    fCfg.pCd_empresa = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_empresa;
                    fCfg.pNm_empresa = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_movimentacao.Value.ToString();
                    fCfg.pDs_movimentacao = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_movimentacao;
                    fCfg.pCd_imposto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_imposto.Value.ToString();
                    fCfg.pDs_imposto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_imposto;
                    fCfg.pCd_clifor = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_clifor;
                    fCfg.pNm_clifor = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Nm_clifor;
                    fCfg.pCd_produto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_produto;
                    fCfg.pDs_produto = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_produto;
                    if ((bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_deb.HasValue)
                    {
                        fCfg.pCd_contadeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_deb.Value.ToString();
                        fCfg.pDs_contadeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_contactb_deb;
                        fCfg.pClassifdeb = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_classificacao_deb;
                    }
                    if ((bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_cred.HasValue)
                    {
                        fCfg.pCd_contacred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_cred.Value.ToString();
                        fCfg.pDs_contacred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Ds_contactb_cred;
                        fCfg.pClassifcred = (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_classificacao_cred;
                    }
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rImp != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Gravar(fCfg.rImp, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaImpostos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lproc != null)
                if (lproc.Count > 0)
                    bsImpostos.DataSource = lproc;
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

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_movimentacao }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_imposto|Imposto|350;a.cd_imposto|Código|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_imposto|=|" + cd_imposto.Text.Trim()
            , new Componentes.EditDefault[] { cd_imposto }, new CamadaDados.Fiscal.TCD_CadImposto());

        }
              
        private void cbMarcaImpostos_Click(object sender, EventArgs e)
        {
            if (bsImpostos.Count > 0)
            {
                (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).Where(p => p.Cd_contactb_cred.HasValue && p.Cd_contactb_deb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaImpostos.Checked);
                bsImpostos.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void TFProcessaImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.afterConfig();
        }

        private void gImpostos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsImpostos.Current != null))
            {
                if (!(bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).St_processar)
                {
                    if (!(bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_cred.HasValue ||
                        !(bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_contactb_deb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Cd_movimentacao.Value.ToString().Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).Tp_movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).St_processar = true;
                }
                else
                    (bsImpostos.Current as CamadaDados.Contabil.TRegistro_ProcImpostos).St_processar = false;
                bsImpostos.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsImpostos.List as List<CamadaDados.Contabil.TRegistro_ProcImpostos>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
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

        private void gImpostos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gImpostos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsImpostos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_ProcImpostos());
            CamadaDados.Contabil.TList_ProcImpostos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcImpostos(lP.Find(gImpostos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gImpostos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcImpostos(lP.Find(gImpostos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gImpostos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsImpostos.List as CamadaDados.Contabil.TList_ProcImpostos).Sort(lComparer);
            bsImpostos.ResetBindings(false);
            gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
