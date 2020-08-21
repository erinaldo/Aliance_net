using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLanComissao : Form
    {
        public TFLanComissao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsComissao.DataSource = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                                      CD_Empresa.Text,
                                                                                                      string.Empty,
                                                                                                      CD_CompVend.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      nr_notafiscal.Text,
                                                                                                      id_cupom.Text,
                                                                                                      string.Empty,
                                                                                                      id_ordem.Text,
                                                                                                      string.Empty,
                                                                                                      nr_pedido.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      nr_cte.Text,
                                                                                                      id_receita.Text,
                                                                                                      id_locacao.Text,
                                                                                                      string.Empty,
                                                                                                      dt_ini.Text,
                                                                                                      dt_fin.Text,
                                                                                                      cbSaldoFat.Checked ? "C" : cbFaturada.Checked ? "F" : string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                                      null);
            //Totalizar Grid
            tot_basecalc.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_basecalc);
            if(bsComissao.List.Count > 0)
                tot_perccomissao.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Average(p => p.Pc_comissao);
            tot_comissao.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_comissao);
            tot_faturado.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_faturado);
            tot_saldofat.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_saldofaturar);

            bsComissao_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsComissao.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(
                            (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao), null);
                        MessageBox.Show("Comissão excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FaturarComissao()
        {
            using (TFFaturarComissao fFat = new TFFaturarComissao())
            {
                if(fFat.ShowDialog() == DialogResult.OK)
                    if(fFat.lComissao != null)
                        try
                        {
                            //Chamar tela de duplicata para comissao
                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vNr_pedido = null;
                                fDuplicata.vCd_empresa = fFat.lComissao[0].Cd_empresa;
                                fDuplicata.vNm_empresa = fFat.lComissao[0].Nm_empresa;
                                fDuplicata.vCd_clifor = fFat.lComissao[0].Cd_vendedor;
                                fDuplicata.vNm_clifor = fFat.lComissao[0].Nm_vendedor;
                                fDuplicata.vCd_endereco = fFat.lComissao[0].Cd_endvendedor;
                                fDuplicata.vTp_mov = "P";
                                fDuplicata.vVl_documento = fFat.lComissao.Sum(p => p.Vl_saldofaturar);
                                fDuplicata.cd_empresa.Enabled = false;
                                fDuplicata.bb_empresa.Enabled = false;
                                fDuplicata.cd_clifor.Enabled = false;
                                fDuplicata.bb_clifor.Enabled = false;
                                fDuplicata.cd_endereco.Enabled = false;
                                fDuplicata.bb_endereco.Enabled = false;
                                fDuplicata.vl_documento_index.Enabled = false;
                                if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.ProcessarComissao(fFat.lComissao, 
                                                                                                                 fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata, 
                                                                                                                 null);
                                    MessageBox.Show("Comissões processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                else
                                    throw new Exception("Obrigatorio informar financeiro para processar comissões.");
                            }
                            
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ReprocessarComissao()
        {
            using (TFReprocessarComissao fRep = new TFReprocessarComissao())
            {
                if(fRep.ShowDialog() == DialogResult.OK)
                    if((fRep.lItemNf != null) ||
                        (fRep.lItemVenda != null) ||
                        (fRep.lPecasOS != null) ||
                        (fRep.lItemPed != null) ||
                        (fRep.lCte != null) ||
                        (fRep.lReceita != null) ||
                        (fRep.lItensLocacao != null))
                        if(MessageBox.Show("Confirma reprocessamento das comissões?\r\n"+
                                           "Somente serão reprocessadas comissões que ainda não foram faturadas.",
                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            try
                            {
                                CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.ReprocessarComissao(fRep.lItemNf, fRep.lItemVenda, fRep.lPecasOS, fRep.lItemPed, fRep.lCte, fRep.lReceita, fRep.lItensLocacao, null);
                                MessageBox.Show("Comissões reprocessadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TrocarVendedor()
        {
            using (TFTrocarVendComissao fTroca = new TFTrocarVendComissao())
            {
                if(fTroca.ShowDialog() == DialogResult.OK)
                    if(fTroca.lComissao != null && !string.IsNullOrEmpty(fTroca.Cd_vendTransf))
                        try
                        {
                            CamadaNegocio.Faturamento.Comissao.TCN_TransfComissao.TransfComissao(fTroca.lComissao, fTroca.Cd_vendTransf, null);
                            MessageBox.Show("Comissões transferidas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void GerarComissao()
        {
            using (TFGerarComissao fGerar = new TFGerarComissao())
            {
                fGerar.ShowDialog();
            }
        }

        private void TFLanComissao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gComissao);
            Utils.ShapeGrid.RestoreShape(this, gParcela);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            bbTrocarVendedor.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TROCAR VENDEDOR COMISSÃO", null);
            bb_reprocessar.Visible = !CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GERAR_COMISSAO_METAS", string.Empty, null).Equals("S");
            bb_gerarComissao.Visible = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GERAR_COMISSAO_METAS", string.Empty, null).Equals("S");
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gComissao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gComissao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsComissao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao());
            CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao(lP.Find(gComissao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gComissao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao(lP.Find(gComissao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gComissao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sort(lComparer);
            bsComissao.ResetBindings(false);
            gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gComissao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADA"))
                        gComissao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gComissao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsComissao_PositionChanged(object sender, EventArgs e)
        {
            if (bsComissao.Current != null)
            {
                (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).lParc =
                    CamadaNegocio.Faturamento.Comissao.TCN_Comissao_X_Duplicata.BuscarParc(
                    (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).Cd_empresa,
                    (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).Id_comissaostr,
                    null);
                bsComissao.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanComissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.FaturarComissao();
            else if (e.KeyCode.Equals(Keys.F10) && bb_reprocessar.Visible)
                this.ReprocessarComissao();
            else if (e.KeyCode.Equals(Keys.F11) && bbTrocarVendedor.Visible)
                this.TrocarVendedor();
            else if (e.KeyCode.Equals(Keys.F12) && bb_gerarComissao.Visible)
                this.GerarComissao();
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            this.FaturarComissao();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void bb_reprocessar_Click(object sender, EventArgs e)
        {
            this.ReprocessarComissao();
        }

        private void TFLanComissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gComissao);
            Utils.ShapeGrid.SaveShape(this, gParcela);
        }

        private void bbTrocarVendedor_Click(object sender, EventArgs e)
        {
            this.TrocarVendedor();
        }

        private void bb_gerarComissao_Click(object sender, EventArgs e)
        {
            this.GerarComissao();
        }
    }
}
