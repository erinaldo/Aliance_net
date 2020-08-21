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
    public partial class TFCfgPainelVendaConv : Form
    {
        private CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv rcfg;
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv rCfg
        {
            get
            {
                if (bsCfgPainelVendaConv.Current != null)
                    return bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv;
                else
                    return null;
            }
            set { rcfg = value; }
        }

        public TFCfgPainelVendaConv()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirGrupo()
        {
            if(bsCfgPainelVendaConv.Current != null)
                using (TFGrupoProduto fGrupo = new TFGrupoProduto())
                {
                    if (fGrupo.ShowDialog() == DialogResult.OK)
                        if (fGrupo.lGrupo != null)
                        {
                            fGrupo.lGrupo.ForEach(p =>
                                {
                                    if (!(bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv).lGrupo.Exists(v => v.Cd_grupo.Trim().Equals(p.CD_Grupo.Trim())))
                                        (bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv).lGrupo.Add(
                                            new CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv_X_Grupo()
                                            {
                                                Cd_grupo = p.CD_Grupo,
                                                Ds_grupo = p.DS_Grupo
                                            });
                                });
                            bsCfgPainelVendaConv.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirGrupo()
        {
            if(bsGrupo.Current != null)
                if (MessageBox.Show("Confirma exclusão do grupo selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCfgPainelVendaConv.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv).lGrupoDel.Add(
                        bsGrupo.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPainelVendaConv_X_Grupo);
                    bsGrupo.RemoveCurrent();
                }
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

        private void TFCfgPainelVendaConv_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcfg != null)
                bsCfgPainelVendaConv.DataSource = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPainelVendaConv() { rcfg };
            else
                bsCfgPainelVendaConv.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCfgPainelVendaConv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirGrupo();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirGrupo();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirGrupo();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirGrupo();
        }
    }
}
