using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaProvisao : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque> lprovisao;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque> lProvisao
        {
            get
            {
                if (bsProvisao.Count > 0)
                    return (bsProvisao.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lprovisao = value; }
        }

        public TFProcessaProvisao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsProvisao.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_ProvEstoque(cd_empresa.Text,
                                                                                                      string.Empty,
                                                                                                      dt_ini.Text,
                                                                                                      dt_fin.Text,
                                                                                                      decimal.Zero,
                                                                                                      cd_produto.Text,
                                                                                                      contadeb.Text,
                                                                                                      contacred.Text,
                                                                                                      vl_ini.Value,
                                                                                                      vl_fin.Value,
                                                                                                      st_reprocessar.Checked,
                                                                                                      null);
        }

        private void afterConfig()
        {
            using (TFCFGProvisaoEst fCfg = new TFCFGProvisaoEst())
            {
                if (bsProvisao.Current != null)
                {
                    fCfg.pCd_empresa = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_Empresa;
                    fCfg.pNm_empresa = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Nm_empresa;
                    fCfg.pCd_produto = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_Produto;
                    fCfg.pDs_produto = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).DS_Produto;
                    fCfg.pTp_movimento = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).TP_Movimento;
                    fCfg.pCd_contadeb = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Ds_contadeb;
                    fCfg.pClassificacaodeb = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Ds_contacre;
                    fCfg.pClassificacaocred = (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).Cd_classificacaocre;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rProv != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGProvisao_Estoque.Gravar(fCfg.rProv, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaProvisao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lprovisao != null)
                if (lprovisao.Count > 0)
                    bsProvisao.DataSource = lprovisao;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
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

        private void gProvisao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsProvisao.Current != null))
            {
                if (!(bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).St_processar)
                {
                    if (!(bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_ContaCre.HasValue ||
                        !(bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_Empresa.Trim() + "\r\n" +
                                        "Produto: " + (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).CD_Produto.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).St_processar = true;
                }
                else
                    (bsProvisao.Current as CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque).St_processar = false;
                bsProvisao.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsProvisao.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void cbMarcaProvisao_Click(object sender, EventArgs e)
        {
            if (bsProvisao.Count > 0)
            {
                (bsProvisao.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaProvisao.Checked);
                bsProvisao.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsProvisao.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
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

        private void TFProcessaProvisao_KeyDown(object sender, KeyEventArgs e)
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

        private void contacred_TextChanged(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + contacred.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { contacred }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void gProvisao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProvisao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProvisao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque());
            CamadaDados.Contabil.TList_ProcProvEstoque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcProvEstoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcProvEstoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProvisao.List as CamadaDados.Contabil.TList_ProcProvEstoque).Sort(lComparer);
            bsProvisao.ResetBindings(false);
            gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
