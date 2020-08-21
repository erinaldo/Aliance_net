using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFConDetAgendamento : Form
    {
        public string pCd_empresa
        { get; set; }

        public TFConDetAgendamento()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if(cbAtivo.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if(cbDesmarcado.Checked)
            {
                status += virg + "'D'";
                virg = ",";
            }
            if(cbExecutado.Checked)
            {
                status += virg + "'E'";
                virg = ",";
            }
            if(cbNaoCompareceu.Checked)
                status += virg + "'N'";
            bsAgendamento.DataSource = CamadaNegocio.Servicos.TCN_Agendamento.Buscar(cd_empresa.Text,
                                                                                     string.Empty,
                                                                                     cd_clifor.Text,
                                                                                     cd_tecnico.Text,
                                                                                     cd_servico.Text,
                                                                                     dt_ini.Text,
                                                                                     dt_fin.Text,
                                                                                     status,
                                                                                     string.Empty,
                                                                                     null);
        }

        private void TFConDetAgendamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
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
                new Componentes.EditDefault[] { cd_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void cd_tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_tecnico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_servico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_servico }, "isnull(e.st_servico, 'N')|=|'S'");
        }

        private void cd_servico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_servico.Text.Trim() + "';isnull(e.st_servico, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_servico }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gAgendamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAgendamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAgendamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Servicos.TRegistro_Agendamento());
            CamadaDados.Servicos.TList_Agendamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAgendamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAgendamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Servicos.TList_Agendamento(lP.Find(gAgendamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAgendamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Servicos.TList_Agendamento(lP.Find(gAgendamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAgendamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAgendamento.List as CamadaDados.Servicos.TList_Agendamento).Sort(lComparer);
            bsAgendamento.ResetBindings(false);
            gAgendamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFConDetAgendamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gAgendamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXECUTADO"))
                        gAgendamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DESMARCADO"))
                        gAgendamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("NÃO COMPARECEU"))
                        gAgendamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Peru;
                    else
                        gAgendamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}
