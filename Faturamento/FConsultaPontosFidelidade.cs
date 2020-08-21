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
    public partial class TFConsultaPontosFidelidade : Form
    {
        public TFConsultaPontosFidelidade()
        {
            InitializeComponent();
        }

        public void afterBusca()
        {
            bsPontosFid.DataSource = CamadaNegocio.Faturamento.Fidelizacao.TCN_PontosFidelidade.Buscar(cd_empresa.Text,
                                                                                                       string.Empty,
                                                                                                       cd_clifor.Text,
                                                                                                       placa.Text,
                                                                                                       cpf.Text,
                                                                                                       rbRegistro.Checked ? "R" : string.Empty,
                                                                                                       dt_ini.Text,
                                                                                                       dt_fin.Text,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       rbComSaldo.Checked ? "C" : rbResgatado.Checked ? "S" : string.Empty,
                                                                                                       rbCancelado.Checked ? "'C'" : string.Empty,
                                                                                                       null);
            tot_pontos.Text = (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p => p.Qt_pontos).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            tot_resgatado.Text = (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p=> p.Pontos_res).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            tot_resgatar.Text = (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sum(p => p.SD_Pontos).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            bsPontosFid_PositionChanged(this, new EventArgs());
        }

        public void afterCancela()
        {
            if (bsPontosFid.Current != null)
            {
                if (MessageBox.Show("Deseja CANCELAR  os pontos selecionados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        Utils.InputBox ibp = new Utils.InputBox();
                        ibp.Text = "MOTIVO CANCELAMENTO";
                        string ds = ibp.ShowDialog();
                        while(string.IsNullOrEmpty(ds))
                        {
                            MessageBox.Show("Obrigatório informar MOTIVO CANCELAMENTO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ds = ibp.ShowDialog();
                        }
                        while (ds.Length < 16)
                        {
                            MessageBox.Show("Obrigatório informar no minimo 16 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ds = ibp.ShowDialog();
                        }
                        (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).MotivoCancelamento = ds;
                        (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).St_registro = "C";
                        CamadaNegocio.Faturamento.Fidelizacao.TCN_PontosFidelidade.Gravar(bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade, null);
                        MessageBox.Show("Pontos Fidelidade CANCELADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsPontosFid_PositionChanged(object sender, EventArgs e)
        {
            if (bsPontosFid.Current != null)
            {
                (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).lPontosRes =
                    CamadaNegocio.Faturamento.Fidelizacao.TCN_ResgatePontos.Buscar((bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Cd_empresa,
                                                                                   (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Id_pontostr,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                bsPontosFid.ResetCurrentItem();
            }
        }

        private void TFConsultaPontosFidelidade_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Verificar Permissao para exclusao de pontos
            BB_Excluir.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAMENTO DE PONTOS", null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cpf.Text.Trim().Length)
            {
                case 3:
                    {
                        cpf.Text += ".";
                        cpf.SelectionStart = 5;
                        break;
                    }
                case 7:
                    {
                        cpf.Text += ".";
                        cpf.SelectionStart = 9;
                        break;
                    }
                case 11:
                    {
                        cpf.Text += "-";
                        cpf.SelectionStart = 13;
                        break;
                    }
            }
        }

        private void TFConsultaPontosFidelidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterCancela();
            else if (e.KeyCode.Equals(Keys.F3))
                this.toolStripButton5_Click(this,new EventArgs());
        }

        private void gPontosFid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gPontosFid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RESGATADO"))
                        gPontosFid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gPontosFid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gPontosFid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPontosFid.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPontosFid.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade());
            CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPontosFid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPontosFid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade(lP.Find(gPontosFid.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPontosFid.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade(lP.Find(gPontosFid.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPontosFid.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPontosFid.List as CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade).Sort(lComparer);
            bsPontosFid.ResetBindings(false);
            gPontosFid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gPontosRes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gPontosRes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gPontosRes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (bsPontosFid.Current != null)
                if ((bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).St_registro.Equals("A"))
                {
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Text = "Alterar pontos de Fidelidade :"
                            + (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Qt_pontos;
                        //fQtd.Vl_default = (bsFicha.Current as TRegistro_FichaTec).vl_faturar;
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                            {
                                (bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Qt_pontos = fQtd.Quantidade;
                                CamadaNegocio.Faturamento.Fidelizacao.TCN_PontosFidelidade.Gravar(bsPontosFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade, null);
                                MessageBox.Show("Pontos Fidelidade ALTERADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsPontosFid.ResetCurrentItem();
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        else
                        {
                        }
                    }
                }else
                {
                    MessageBox.Show("Evoluir apenas status ativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
        }
    }
}
