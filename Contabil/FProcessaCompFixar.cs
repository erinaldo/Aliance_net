using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaCompFixar : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_ProcCompFixar> lcomp;
        public List<CamadaDados.Contabil.TRegistro_ProcCompFixar> lComp
        {
            get
            {
                if (bsComp.Count > 0)
                    return (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lcomp = value; }
        }

        public TFProcessaCompFixar()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("TODOS", string.Empty));
            cbx.Add(new Utils.TDataCombo("ESTORNO", "E"));
            cbx.Add(new Utils.TDataCombo("ATUALIZAÇÃO", "A"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsComp.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_CompFixar(cd_empresa.Text,
                                                                                                 string.Empty,
                                                                                                 dt_ini.Text,
                                                                                                 dt_fin.Text,
                                                                                                 tp_registro.SelectedValue == null ? string.Empty : tp_registro.SelectedValue.ToString(),
                                                                                                 tp_movimento.SelectedIndex == 0 ? "C" : tp_movimento.SelectedIndex == 1 ? "V" : string.Empty,
                                                                                                 cd_produto.Text,
                                                                                                 string.Empty,
                                                                                                 contadeb.Text,
                                                                                                 contacred.Text,
                                                                                                 vl_ini.Value,
                                                                                                 vl_fin.Value,
                                                                                                 st_reprocessar.Checked,
                                                                                                 null);
            if(bsComp.Count > 0)
                lblInconsistente.Text = "{" + (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                             (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                             p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
        }

        private void afterConfig()
        {
            using (TFCFGCompFixar fCfg = new TFCFGCompFixar())
            {
                if (bsComp.Current != null)
                {
                    fCfg.pCd_empresa = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_empresa;
                    fCfg.pNm_empresa = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Nm_empresa;
                    fCfg.pCd_produto = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_produto;
                    fCfg.pDs_produto = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Ds_produto;
                    fCfg.pCd_contadeb = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Ds_contadeb;
                    fCfg.pClassifdeb = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Ds_contacred;
                    fCfg.pClassifcred = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_classificacaocred;
                    fCfg.pTp_registro = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Tp_registro;
                    fCfg.pTp_movimento = (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Tp_movimento;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rComp != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCompFixar.Gravar(fCfg.rComp, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaCompFixar_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tp_movimento.SelectedIndex = 0;
            cd_empresa.Text = pCd_empresa;
            if (lcomp != null)
                if (lcomp.Count > 0)
                    bsComp.DataSource = lcomp;
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
        
        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            if (bsComp.Count > 0)
            {
                (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFaturamento.Checked);
                bsComp.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsComp.Current != null))
            {
                if (!(bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).St_processar)
                {
                    if (!(bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).CD_ContaCre.HasValue ||
                        !(bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_empresa.Trim() + "\r\n" +
                                        "Produto: " + (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Cd_produto.Trim() + "\r\n" +
                                        "Tipo Registro: " + (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).Tipo_registro.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).St_processar = true;
                }
                else
                    (bsComp.Current as CamadaDados.Contabil.TRegistro_ProcCompFixar).St_processar = false;
                bsComp.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFProcessaCompFixar_KeyDown(object sender, KeyEventArgs e)
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

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void gComp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].Cd_contactb_C.HasValue ?
                    (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].CD_ContaCre !=
                    (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].Cd_contactb_C : false) ||
                    ((bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].Cd_contactb_D.HasValue ?
                    (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].CD_ContaDeb !=
                    (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>)[e.RowIndex].Cd_contactb_D : false))
                    gComp.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gComp.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsComp.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_ProcCompFixar> lista =
                    (bsComp.List as List<CamadaDados.Contabil.TRegistro_ProcCompFixar>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                   (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                   p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsComp.DataSource = lista;
            }
        }

        private void gComp_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gComp.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsComp.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_ProcCompFixar());
            CamadaDados.Contabil.TList_ProcCompFixar lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gComp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gComp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCompFixar(lP.Find(gComp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gComp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCompFixar(lP.Find(gComp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gComp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsComp.List as CamadaDados.Contabil.TList_ProcCompFixar).Sort(lComparer);
            bsComp.ResetBindings(false);
            gComp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
