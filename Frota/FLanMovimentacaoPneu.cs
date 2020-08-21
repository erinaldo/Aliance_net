using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Frota.Cadastros;

namespace Frota
{
    public partial class TFLanMovimentacaoPneu : Form
    {
        bool mover;
        Point inicial;

        public TFLanMovimentacaoPneu()
        {
            InitializeComponent();
        }

        private void DesabilitarPneus()
        {
            //Steps
            bb_step1.Visible = false;
            bb_step2.Visible = false;
            bb_step3.Visible = false;
            bb_step4.Visible = false;
            bb_step5.Visible = false;
            bb_step6.Visible = false;
            bb_step7.Visible = false;
            bb_step8.Visible = false;
            bb_step9.Visible = false;
            bb_step10.Visible = false;

            //Rodas Layout
            bb_roda1.Visible = false;
            bb_roda2.Visible = false;
            bb_roda3.Visible = false;
            bb_roda4.Visible = false;
            bb_roda5.Visible = false;
            bb_roda6.Visible = false;
            bb_roda7.Visible = false;
            bb_roda8.Visible = false;
            bb_roda9.Visible = false;
            bb_roda10.Visible = false;

            pLayout.Visible = false;

        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAlmoxarifado.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbRodando.Checked)
            {
                status = "'R'";
                virg = ",";
            }
            if (cbManutencao.Checked)
            {
                status = "'M'";
                virg = ",";
            }
            if (cbDesativado.Checked)
                status += virg + "'D'";
            bsPneus.DataSource = TCN_LanPneu.Buscar(string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    null);

            bsPneus.ResetCurrentItem();
        }
        /*
        private void HabilitarSteps(CamadaDados.Frota.Cadastros.TList_CadLayoutVeiculo lista)
        {
            if (lista[0].QT_steps.Equals(1))
                bb_step1.Visible = true;
            else if (lista[0].QT_steps.Equals(2))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(3))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(4))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(5))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(6))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
                bb_step6.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(7))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
                bb_step6.Visible = true;
                bb_step7.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(8))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
                bb_step6.Visible = true;
                bb_step7.Visible = true;
                bb_step8.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(9))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
                bb_step6.Visible = true;
                bb_step7.Visible = true;
                bb_step8.Visible = true;
                bb_step9.Visible = true;
            }
            else if (lista[0].QT_steps.Equals(10))
            {
                bb_step1.Visible = true;
                bb_step2.Visible = true;
                bb_step3.Visible = true;
                bb_step4.Visible = true;
                bb_step5.Visible = true;
                bb_step6.Visible = true;
                bb_step7.Visible = true;
                bb_step8.Visible = true;
                bb_step9.Visible = true;
                bb_step10.Visible = true;
            }
        }

        private void HabilitarLayout(CamadaDados.Frota.Cadastros.TList_CadLayoutVeiculo lista)
        {
            if (lista[0].QT_eixos.Equals(2) && lista[0].QT_rodas.Equals(4))
            {
                pLayout.Visible = true;
                //Habilitar Eixo 1
                bb_roda1.Visible = true;
                bb_roda2.Visible = true;
                //habilitar Eixo 2
                bb_roda8.Visible = true;
                bb_roda9.Visible = true;
            }
            else if (lista[0].QT_eixos.Equals(3) && lista[0].QT_rodas.Equals(10))
            {
                pLayout.Visible = true;
                //Habilitar Eixo 1
                bb_roda1.Visible = true;
                bb_roda2.Visible = true;
                //Habilitar Eixo 2
                bb_roda3.Visible = true;
                bb_roda4.Visible = true;
                bb_roda5.Visible = true;
                bb_roda6.Visible = true;
                //Habilitar Eixo 3
                bb_roda7.Visible = true;
                bb_roda8.Visible = true;
                bb_roda9.Visible = true;
                bb_roda10.Visible = true;
            }
        }
        */
        private void TFLanMovimentacaoPneu_Load(object sender, EventArgs e)
        {
            pConsulta.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void Id_veiculo_Leave(object sender, EventArgs e)
        {
            this.DesabilitarPneus();
            string vParam = "a.id_veiculo|=|'" + Id_veiculo.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_veiculo, Ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            DataRowView linha =   FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_veiculo, Ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void gPneus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(1))
                {

                    if (e.Value.ToString().Trim().ToUpper().Equals("ALMOXARIFADO"))
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RODANDO"))
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("MANUTENÇÃO"))
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void gPneus_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPneus.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPneus.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_LanPneu());
            CamadaDados.Frota.Cadastros.TList_LanPneu lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneus.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPneus.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneus.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPneus.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPneus.List as CamadaDados.Frota.Cadastros.TList_LanPneu).Sort(lComparer);
            bsPneus.ResetBindings(false);
            gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }


        private void BB_Desativar_Click(object sender, EventArgs e)
        {
            if (bsPneus.Count > 0)
                if ((bsPneus.DataSource as CamadaDados.Frota.Cadastros.TList_LanPneu).Exists(p => p.St_processar))
                    if (MessageBox.Show("Deseja desativar os pneus selecionados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                            try
                            {
                                (bsPneus.DataSource as CamadaDados.Frota.Cadastros.TList_LanPneu).Where(p => p.St_processar).ToList().ForEach(p =>
                                    {
                                       // p.St_pneu = "D";
                                        TCN_LanPneu.Gravar(p, null);
                                    });
                                MessageBox.Show("Pneus desativados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private void BB_Manutencao_Click(object sender, EventArgs e)
        {

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_roda1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                mover = true;

                inicial = e.Location;

            }

        }

        private void bb_roda1_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void bb_roda1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover == true)
                try
                {

                    ((Button)sender).Location = new Point(((Button)sender).Left + (e.X - inicial.X),

                    ((Button)sender).Top + (e.Y - inicial.Y));
                }
                catch { }

        }

        private void gPneus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).St_processar =
                    !(bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).St_processar;
                bsPneus.ResetCurrentItem();
            }
        }
    }
}
