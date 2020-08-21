using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota;
using CamadaNegocio.Frota;

namespace Frota
{
    public partial class TFLanCartaFrete : Form
    {
        public TFLanCartaFrete()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            nr_cartafrete.Clear();
            cd_empresa.Clear();
            cd_motorista.Clear();
            id_acerto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            cbAberto.Checked = false;
            cbProcessado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFCartaFrete fCarta = new TFCartaFrete())
            {
                if(fCarta.ShowDialog() == DialogResult.OK)
                    if(fCarta.rCarta != null)
                        try
                        {
                            CamadaNegocio.Frota.TCN_CartaFrete.Gravar(fCarta.rCarta, null);
                            MessageBox.Show("Carta frete gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            nr_cartafrete.Text = fCarta.rCarta.Nr_cartafretestr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void afterAltera()
        {
            if (bsCartaFrete.Current != null)
            {
                if ((bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).Id_acerto.HasValue)
                {
                    MessageBox.Show("Carta frete esta sendo utilizada no acerto Nº" + (bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).Id_acertostr + ".\r\n" +
                                    "Para alterar a mesma é necessario antes exclui-la do acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCartaFrete fCarta = new TFCartaFrete())
                {
                    fCarta.rCarta = bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete;
                    if(fCarta.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Frota.TCN_CartaFrete.Gravar(fCarta.rCarta, null);
                            MessageBox.Show("Carta frete alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    nr_cartafrete.Text = fCarta.rCarta.Nr_cartafretestr;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsCartaFrete.Current != null)
            {
                if((bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).Id_acerto.HasValue)
                {
                    MessageBox.Show("Carta frete esta sendo utilizada no acerto Nº" + (bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).Id_acertostr + ".\r\n" +
                                    "Para excluir a mesma é necessario antes exclui-la do acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_CartaFrete.Excluir(bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete, null);
                        MessageBox.Show("Carta frete excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsCartaFrete.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string st = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                st = "'A'";
                virg = ",";
            }
            if (cbProcessado.Checked)
                st += virg + "'P'";
            bsCartaFrete.DataSource = TCN_CartaFrete.Buscar(nr_cartafrete.Text,
                                                            cd_empresa.Text,
                                                            cd_motorista.Text,
                                                            id_acerto.Text,
                                                            dt_ini.Text,
                                                            dt_fin.Text,
                                                            st,
                                                            null);
        }

        private void TFLanCartaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void id_acerto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_acerto|=|" + id_acerto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_acerto },
                new CamadaDados.Frota.TCD_AcertoMotorista());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void TFLanCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void gCartaFrete_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCartaFrete.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCartaFrete.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_CartaFrete());
            CamadaDados.Frota.TList_CartaFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_CartaFrete(lP.Find(gCartaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCartaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_CartaFrete(lP.Find(gCartaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCartaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCartaFrete.List as CamadaDados.Frota.TList_CartaFrete).Sort(lComparer);
            bsCartaFrete.ResetBindings(false);
            gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gCartaFrete_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                        gCartaFrete.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gCartaFrete.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, "isnull(a.st_motorista, 'N')|=|'S';isnull(a.ST_AtivoMot, 'N')|=|'S'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                                                    "isnull(a.st_motorista, 'N')|=|'S';" +
                                                    "isnull(a.ST_AtivoMot, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_motorista },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
