using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFLogEmail : Form
    {
        public TFLogEmail()
        {
            InitializeComponent();
        }

        private void TFLogEmail_Load(object sender, EventArgs e)
        {
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label5.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            bsLogEmail.DataSource = CamadaNegocio.Diversos.TCN_CadLogEmail.Busca(string.Empty,
                                                                                 st_emailLogin.Checked ? string.Empty : Utils.Parametros.pubLogin,
                                                                                 titulo.Text,
                                                                                 mensagem.Text,
                                                                                 destinatario.Text,
                                                                                 dt_inicial.Text,
                                                                                 dt_final.Text,
                                                                                 null);
        }

        private void TFLogEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                BB_Buscar_Click(this, new EventArgs());
        }

        private void bsLogEmail_PositionChanged(object sender, EventArgs e)
        {
            if (bsLogEmail.Current != null)
            {
                lbAnexos.Items.Clear();
                if (!string.IsNullOrEmpty((bsLogEmail.Current as CamadaDados.Diversos.TRegistro_CadlogEmail).Anexo))
                {
                    string[] aux = (bsLogEmail.Current as CamadaDados.Diversos.TRegistro_CadlogEmail).Anexo.Split(new char[] { ';' });
                    foreach (string a in aux)
                        if (!string.IsNullOrEmpty(a))
                            lbAnexos.Items.Add(a.Trim());
                }
            }
        }

        private void lbAnexos_DoubleClick(object sender, EventArgs e)
        {
            if (lbAnexos.SelectedItem != null)
                if (System.IO.File.Exists(lbAnexos.SelectedItem.ToString()))
                    try
                    {
                        System.Diagnostics.Process.Start(lbAnexos.SelectedItem.ToString());
                    }
                    catch
                    { MessageBox.Show("Erro abrir arquivo: " + lbAnexos.SelectedItem.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                    MessageBox.Show("Arquivo não se encontra mais no diretório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gLogEmail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLogEmail.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLogEmail.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Diversos.TRegistro_CadlogEmail());
            CamadaDados.Diversos.TList_CadLogEmail lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLogEmail.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLogEmail.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Diversos.TList_CadLogEmail(lP.Find(gLogEmail.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLogEmail.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Diversos.TList_CadLogEmail(lP.Find(gLogEmail.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLogEmail.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLogEmail.List as CamadaDados.Diversos.TList_CadLogEmail).Sort(lComparer);
            bsLogEmail.ResetBindings(false);
            gLogEmail.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
