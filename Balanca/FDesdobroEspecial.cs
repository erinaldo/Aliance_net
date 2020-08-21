using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balanca
{
    public partial class TFDesdobroEspecial : Form
    {
        public CamadaDados.Balanca.TRegistro_LanPesagemGraos rPsGraos
        { get; set; }

        public TFDesdobroEspecial()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFDesdobro fDesdobro = new TFDesdobro())
            {
                fDesdobro.rPsgraos = rPsGraos;
                if(fDesdobro.ShowDialog() == DialogResult.OK)
                    if (fDesdobro.rDesd != null)
                    {
                        try
                        {
                            CamadaNegocio.Balanca.TCN_DesdobroEspecial.Gravar(fDesdobro.rDesd, null);
                            MessageBox.Show("Desdobro Especial Gravado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsDesdobroEspecial.Current != null)
                using (TFDesdobro fDesdobro = new TFDesdobro())
                {
                    fDesdobro.rPsgraos = rPsGraos;
                    CamadaDados.Balanca.TRegistro_DesdobroEspecial copia = (bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial).Copy();
                    fDesdobro.rDesd = copia;
                    if(fDesdobro.ShowDialog() == DialogResult.OK)
                        if (fDesdobro.rDesd != null)
                        {
                            try
                            {
                                CamadaNegocio.Balanca.TCN_DesdobroEspecial.Gravar(fDesdobro.rDesd, null);
                                MessageBox.Show("Desdobro especial alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsDesdobroEspecial.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Balanca.TCN_DesdobroEspecial.Excluir(bsDesdobroEspecial.Current as CamadaDados.Balanca.TRegistro_DesdobroEspecial, null);
                        MessageBox.Show("Desdobro especial excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsDesdobroEspecial.DataSource = CamadaNegocio.Balanca.TCN_DesdobroEspecial.Buscar(string.Empty,
                                                                                              rPsGraos.Cd_empresa,
                                                                                              rPsGraos.Id_ticket.ToString(),
                                                                                              rPsGraos.Tp_pesagem,
                                                                                              null);
        }

        private void TFDesdobroEspecial_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gDesdobroEspecial);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFDesdobroEspecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gDesdobroEspecial_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDesdobroEspecial.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDesdobroEspecial.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Balanca.TRegistro_DesdobroEspecial());
            CamadaDados.Balanca.TList_DesdobroEspecial lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDesdobroEspecial.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDesdobroEspecial.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Balanca.TList_DesdobroEspecial(lP.Find(gDesdobroEspecial.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDesdobroEspecial.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Balanca.TList_DesdobroEspecial(lP.Find(gDesdobroEspecial.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDesdobroEspecial.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDesdobroEspecial.List as CamadaDados.Balanca.TList_DesdobroEspecial).Sort(lComparer);
            bsDesdobroEspecial.ResetBindings(false);
            gDesdobroEspecial.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFDesdobroEspecial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gDesdobroEspecial);
        }
    }
}
