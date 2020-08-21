using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadCfgPainelVendaConv : Form
    {
        public TFCadCfgPainelVendaConv()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFCfgPainelVendaConv fConfig = new TFCfgPainelVendaConv())
            {
                if(fConfig.ShowDialog() == DialogResult.OK)
                    if(fConfig.rCfg != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPainelVendaConv.Gravar(fConfig.rCfg, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            id_config.Clear();
                            ds_config.Clear();
                            id_config.Text = fConfig.rCfg.Id_configstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsCfgPainelVendaConv.Current != null)
                using (TFCfgPainelVendaConv fConfig = new TFCfgPainelVendaConv())
                {
                    fConfig.rCfg = bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv;
                    if (fConfig.ShowDialog() == DialogResult.OK)
                    {
                        bsCfgPainelVendaConv.ResetCurrentItem();
                        if (fConfig.rCfg != null)
                            try
                            {
                                CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPainelVendaConv.Gravar(fConfig.rCfg, null);
                                MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    id_config.Clear();
                    ds_config.Clear();
                    id_config.Text = fConfig.rCfg.Id_configstr;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsCfgPainelVendaConv.Current != null)
                if(MessageBox.Show("Confirma exclusão da configuração selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPainelVendaConv.Excluir(bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv, null);
                        MessageBox.Show("Configuração excluida com suceso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_config.Clear();
                        ds_config.Clear();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsCfgPainelVendaConv.DataSource = CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPainelVendaConv.Buscar(id_config.Text,
                                                                                                                     ds_config.Text,
                                                                                                                     null);
            bsCfgPainelVendaConv_PositionChanged(this, new EventArgs());
        }

        private void gCfgPainelVendaConv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCfgPainelVendaConv.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCfgPainelVendaConv.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv());
            CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCfgPainelVendaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCfgPainelVendaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv(lP.Find(gCfgPainelVendaConv.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCfgPainelVendaConv.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv(lP.Find(gCfgPainelVendaConv.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCfgPainelVendaConv.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCfgPainelVendaConv.List as CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv).Sort(lComparer);
            bsCfgPainelVendaConv.ResetBindings(false);
            gCfgPainelVendaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gGrupo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gGrupo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsGrupo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv_X_Grupo());
            CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv_X_Grupo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gGrupo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gGrupo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv_X_Grupo(lP.Find(gGrupo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gGrupo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv_X_Grupo(lP.Find(gGrupo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gGrupo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsGrupo.List as CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv_X_Grupo).Sort(lComparer);
            bsGrupo.ResetBindings(false);
            gGrupo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void TFCadCfgPainelVendaConv_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFCadCfgPainelVendaConv_KeyDown(object sender, KeyEventArgs e)
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

        private void bsCfgPainelVendaConv_PositionChanged(object sender, EventArgs e)
        {
            if (bsCfgPainelVendaConv.Current != null)
            {
                (bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv).lGrupo =
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPainelVendaConv_X_Grupo.Buscar((bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv).Id_configstr,
                                                                                                   string.Empty,
                                                                                                   null);
                bsCfgPainelVendaConv.ResetCurrentItem();
            }
        }
    }
}
