using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFLanRoyaltiesGMO : Form
    {
        public TFLanRoyaltiesGMO()
        {
            InitializeComponent();
        }

        private void LimparFiltro()
        {
            id_lanctogmo.Clear();
            nr_contrato.Clear();
            cd_produto.Clear();
            cd_clifor.Clear();
            st_declarado.Checked = false;
            st_testado.Checked = false;
            st_avulso.Checked = false;
            st_normal.Checked = false;
        }

        private void afterNovo()
        {
            using (TFRoyaltiesGMO fGmo = new TFRoyaltiesGMO())
            {
                if(fGmo.ShowDialog() == DialogResult.OK)
                    if (fGmo.rRoyalties != null)
                    {
                        try
                        {
                            CamadaNegocio.Graos.TCN_LanRoyaltiesGMO.Gravar(fGmo.rRoyalties, null);
                            MessageBox.Show("Credito Royalties gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltro();
                            id_lanctogmo.Text = fGmo.rRoyalties.Id_lanctoGMOstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(nr_contrato.Text))
            {
                MessageBox.Show("Obrigatorio informar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tp_gmo = string.Empty;
            string virg = string.Empty;
            if (st_declarado.Checked)
            {
                tp_gmo = "'D'";
                virg = ",";
            }
            if (st_testado.Checked)
            {
                tp_gmo += virg + "'T'";
                virg = string.Empty;
            }
            string tp_lancto = string.Empty;
            if (st_avulso.Checked)
            {
                tp_lancto = "'A'";
                virg = ",";
            }
            if (st_normal.Checked)
                tp_lancto += virg + "'N'";

            bsRoyaltiesGMO.DataSource = CamadaNegocio.Graos.TCN_LanRoyaltiesGMO.Buscar(id_lanctogmo.Text,
                                                                                       nr_contrato.Text,
                                                                                       string.Empty,
                                                                                       cd_clifor.Text,
                                                                                       cd_produto.Text,
                                                                                       tp_lancto,
                                                                                       tp_gmo,
                                                                                       null);
            tot_credito.Value = (bsRoyaltiesGMO.List as CamadaDados.Graos.TList_LanRoyaltiesGMO).Sum(p => p.QTD_Credito);
            tot_debito.Value = (bsRoyaltiesGMO.List as CamadaDados.Graos.TList_LanRoyaltiesGMO).Sum(p => p.QTD_Debito);
            saldo.Value = tot_debito.Value - tot_credito.Value;
            tot_royalties.Value = (bsRoyaltiesGMO.List as CamadaDados.Graos.TList_LanRoyaltiesGMO).Sum(p => p.Vl_royalties_retido);
        }

        private void afterExclui()
        {
            if (bsRoyaltiesGMO.Current != null)
            {
                if ((bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).TP_Lancto.Trim().ToUpper().Equals("N"))
                {
                    MessageBox.Show("Não é permitido excluir lançamento royalties gerado atravez de uma nota fiscal.\r\n" +
                                    "Para excluir o lançamento é necessario cancelar a nota fiscal de origem.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Graos.TCN_LanRoyaltiesGMO.Excluir(bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar Royalties para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanRoyaltiesGMO_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRoyaltiesGMO);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsRoyaltiesGMO_PositionChanged(object sender, EventArgs e)
        {
            if (bsRoyaltiesGMO.Current != null)
            {
                //Buscar Notas GMO
                (bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).lNf =
                    CamadaNegocio.Graos.TCN_Lan_NotaFiscalGMO.BuscarNF((bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).Id_lanctoGMOstr, null);
                //Buscar Pesagem GMO
                (bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).lPesagem =
                    CamadaNegocio.Graos.TCN_LanPesagemGMO.BuscarPesagem((bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).Id_lanctoGMOstr, null);
                //Buscar Duplicata Retencao
                (bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).lDuplicata =
                    CamadaNegocio.Graos.TCN_Lan_RetencaoFinanceiraGMO.BuscarDuplicata((bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).Id_lanctoGMOstr, null);
                //Buscar Caixa Retencao
                (bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).lCaixa =
                    CamadaNegocio.Graos.TCN_Lan_RetencaoFinanceiraGMO.BuscarCaixa((bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).Id_lanctoGMOstr, null);

                bsRoyaltiesGMO.ResetCurrentItem();
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFLanRoyaltiesGMO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFLanRoyaltiesGMO_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRoyaltiesGMO);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa)";
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato }, vParamFixo);
        }

        private void nr_contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa)";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato }, new CamadaDados.Graos.TCD_CadContrato());
        }

        private void gRoyaltiesGMO_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRoyaltiesGMO.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsRoyaltiesGMO.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Graos.TRegistro_LanRoyaltiesGMO());
            CamadaDados.Graos.TList_LanRoyaltiesGMO lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRoyaltiesGMO.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRoyaltiesGMO.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Graos.TList_LanRoyaltiesGMO(lP.Find(gRoyaltiesGMO.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRoyaltiesGMO.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Graos.TList_LanRoyaltiesGMO(lP.Find(gRoyaltiesGMO.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRoyaltiesGMO.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsRoyaltiesGMO.List as CamadaDados.Graos.TList_LanRoyaltiesGMO).Sort(lComparer);
            bsRoyaltiesGMO.ResetBindings(false);
            gRoyaltiesGMO.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
