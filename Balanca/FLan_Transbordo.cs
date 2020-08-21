using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Balanca;

namespace Balanca
{
    public partial class TFLan_Transbordo : Form
    {
        public string Cd_empresa = string.Empty;
        public decimal Id_ticket = 0;
        public string Tp_pesagem = string.Empty;
        public string Cd_tabeladesconto = string.Empty;
        public string Cd_produto = string.Empty;
        public string Tp_movimento = string.Empty;
        public decimal Ps_liqTicket = 0;

        public TFLan_Transbordo()
        {
            InitializeComponent();
        }

        private decimal SomarTransbordo()
        {
            decimal total = 0;
            for (int i = 0; i < bsTransbordo.Count; i++)
                total += (bsTransbordo[i] as TRegistro_LanTransbordo).Ps_transbordo;
            return total;
        }

        private void afterExclui()
        {
            if (bsTransbordo.Current != null)
            {
                bsTransbordo.RemoveCurrent();
                total_quantidade.Value = this.SomarTransbordo();
            }
        }

        private void afterInclui()
        {
            if (bsPesagemGraos.Count > 0)
            {
                if (Tp_movimento.Trim().ToUpper().Equals("E") && (bsTransbordo.Count > 0))
                {
                    MessageBox.Show("Pesagem de transbordo de entrada não permite amarrar mais que uma pesagem de origem.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Tp_movimento.Trim().ToUpper().Equals("S") && (QTD_Transbordo.Value < 1))
                {
                    MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.Contains((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                 (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.Value,
                                 (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem))
                    (bsTransbordo.Current as TRegistro_LanTransbordo).Ps_transbordo = qtd_lancto.Value;
                else
                    bsTransbordo.Add(new TRegistro_LanTransbordo()
                    {
                        Id_transbordo = 0,
                        Cd_empresadest = Cd_empresa,
                        Id_ticketdest = Id_ticket,
                        Tp_pesagemdest = Tp_pesagem,
                        Cd_empresaorig = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                        Id_ticketorig = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.Value,
                        Tp_pesagemorig = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                        Ps_transbordo = Tp_movimento.Trim().ToUpper().Equals("E") ? (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_saldotransbordo : qtd_lancto.Value
                    });
                bsTransbordo.EndEdit();
                total_quantidade.Value = this.SomarTransbordo();
                bsPesagemGraos.MoveNext();
            }
        }

        private void DesenharTela()
        {
            if (Tp_movimento.Trim().ToUpper().Equals("E"))
            {
                bb_adicionar_entrada.Visible = true;
                bb_excluir_entrada.Visible = true;
                tlpDados.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 0);
            }
            else
            {
                bb_adicionar_entrada.Visible = false;
                bb_excluir_entrada.Visible = false;
                tlpDados.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 227);
            }
        }

        private bool Contains(string Cd_empresa, decimal Id_ticket, string Tp_pesagem)
        {
            for (int i = 0; i < bsTransbordo.Count; i++)
                if (Tp_movimento.Trim().ToUpper().Equals("E"))
                {
                    if ((bsTransbordo[i] as TRegistro_LanTransbordo).Cd_empresaorig.Trim().Equals(Cd_empresa.Trim()) &&
                        (bsTransbordo[i] as TRegistro_LanTransbordo).Id_ticketorig.Equals(Id_ticket) &&
                        (bsTransbordo[i] as TRegistro_LanTransbordo).Tp_pesagemorig.Trim().Equals(Tp_pesagem.Trim()))
                        return true;
                }
                else if (Tp_movimento.Trim().ToUpper().Equals("S"))
                    if ((bsTransbordo[i] as TRegistro_LanTransbordo).Cd_empresadest.Trim().Equals(Cd_empresa.Trim()) &&
                        (bsTransbordo[i] as TRegistro_LanTransbordo).Id_ticketdest.Equals(Id_ticket) &&
                        (bsTransbordo[i] as TRegistro_LanTransbordo).Tp_pesagemdest.Trim().Equals(Tp_pesagem.Trim()))
                        return true;
            return false;
        }

        private void TFLan_Transbordo_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTransbordo);
            Utils.ShapeGrid.RestoreShape(this, gPesagem);
            panelDados7.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados4.BackColor = Utils.SettingsUtils.Default.COLOR_2;

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.DesenharTela();
            qtd_lancto.Enabled = Tp_movimento.Trim().ToUpper().Equals("S");
            QTD_Transbordo.Value = Ps_liqTicket;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsPesagemGraos.DataSource = CamadaNegocio.Balanca.TCN_LanPesagemGraos.Busca(Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        Cd_produto,
                                                                                        Cd_tabeladesconto,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        Tp_movimento.Trim().ToUpper().Equals("S"),
                                                                                        Tp_movimento.Trim().ToUpper().Equals("E"),
                                                                                        false,
                                                                                        true,
                                                                                        false,
                                                                                        false,
                                                                                        Utils.Parametros.pubLogin,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,                                                                                        
                                                                                        true,
                                                                                        false,
                                                                                        Tp_movimento.Trim().ToUpper().Equals("E") ? "N" : Tp_movimento.Trim().ToUpper().Equals("S") ? "S" : string.Empty,
                                                                                        0,
                                                                                        string.Empty,
                                                                                        null);
            if (bsPesagemGraos.Current != null)
                qtd_lancto.Value = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_saldotransbordo;
        }

        private void TFLan_Transbordo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ID_Ticket_Leave(object sender, EventArgs e)
        {
            if (bsPesagemGraos.Count > 0)
                for (int i = 0; i < bsPesagemGraos.Count; i++)
                    if ((bsPesagemGraos[i] as TRegistro_LanPesagemGraos).Id_ticket.ToString().Trim().Equals(ID_Ticket.Text.Trim()))
                    {
                        bsPesagemGraos.Position = i;
                        return;
                    }
                    else
                        bsPesagemGraos.MoveNext();
        }

        private void total_quantidade_ValueChanged(object sender, EventArgs e)
        {
            saldo_quantidade.Value = QTD_Transbordo.Value - total_quantidade.Value;
        }

        private void QTD_Transbordo_ValueChanged(object sender, EventArgs e)
        {
            saldo_quantidade.Value = QTD_Transbordo.Value - total_quantidade.Value;
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            afterInclui();
        }

        private void qtd_lancto_ValueChanged(object sender, EventArgs e)
        {
            if (qtd_lancto.Value > (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_saldotransbordo)
                qtd_lancto.Value = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_saldotransbordo;
            if (qtd_lancto.Value > saldo_quantidade.Value)
                qtd_lancto.Value = saldo_quantidade.Value;
        }

        private void bsPesagemGraos_PositionChanged(object sender, EventArgs e)
        {
            if(bsPesagemGraos.Current != null)
                qtd_lancto.Value = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_saldotransbordo;
        }

        private void bb_excluir_entrada_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_adicionar_entrada_Click(object sender, EventArgs e)
        {
            afterInclui();
        }

        private void TFLan_Transbordo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTransbordo);
            Utils.ShapeGrid.SaveShape(this, gPesagem);
            if ((Tp_movimento.Trim().ToUpper().Equals("S")) && (saldo_quantidade.Value > 0))
            {
                if (MessageBox.Show("Ticket de transbordo de saida exige lançamento da quantidade total.\r\n" +
                                "Deseja informar saldo restante?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    e.Cancel = true;
                else
                    this.DialogResult = DialogResult.Cancel;
            }
        }

        private void gPesagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPesagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPesagemGraos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemGraos());
            TList_RegLanPesagemGraos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPesagemGraos.List as TList_RegLanPesagemGraos).Sort(lComparer);
            bsPesagemGraos.ResetBindings(false);
            gPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gTransbordo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTransbordo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTransbordo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanTransbordo());
            TList_LanTransbordo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTransbordo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTransbordo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanTransbordo(lP.Find(gTransbordo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTransbordo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanTransbordo(lP.Find(gTransbordo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTransbordo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTransbordo.List as TList_LanTransbordo).Sort(lComparer);
            bsTransbordo.ResetBindings(false);
            gTransbordo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
