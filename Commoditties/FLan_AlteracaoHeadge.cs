using System;
using CamadaDados.Fazenda.Lancamento;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Fazenda.Lancamento;
using Utils;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace Commoditties
{
    public partial class TFLan_AlteracaoHeadge : FormPadrao.FFormPadrao
    {
        public List<int> ItensAlterados = new List<int>();
        public TList_Lan_NFHeadge ListaNFHeadge = new TList_Lan_NFHeadge();
        private bool fechaNormal = false;

        public TFLan_AlteracaoHeadge()
        {
            InitializeComponent();
            BB_Gravar.Visible = true;
            BB_Cancelar.Visible = true;
            BB_Buscar.Visible = false;
            BB_Novo.Visible = false;
            grid_LanctoNFHeadge.ReadOnly = false;
            grid_LanctoNFHeadge.Focus();
        }

        public override void afterGrava()
        {
            fechaNormal = true;
            this.DialogResult = DialogResult.OK;

            for (int i = 0; i < ItensAlterados.Count; i++)
            {
                int pos = ItensAlterados[i];
                ListaNFHeadge.Add(BS_LanctoNFHeadge[pos] as TRegistro_Lan_NFHeadge);
            }

            this.Dispose();
        }

        public override void afterCancela()
        {
            fechaNormal = false;
            FLan_AlteracaoHeadge_FormClosing(this, null);
        }

        private void grid_LanctoNFHeadge_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (grid_LanctoNFHeadge.Columns[e.ColumnIndex].Name != "VL_Lancto_Grid")
            {
                e.Cancel = true;
            }
        }

        private void grid_LanctoNFHeadge_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_LanctoNFHeadge.Columns[e.ColumnIndex].Name == "VL_Lancto_Grid")
            {
                if (!ItensAlterados.Contains(BS_LanctoNFHeadge.Position))
                    ItensAlterados.Add(BS_LanctoNFHeadge.Position);
            }
        }

        private void grid_LanctoNFHeadge_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (BS_LanctoNFHeadge != null))
            {
                if (grid_LanctoNFHeadge.Columns[e.ColumnIndex].Name == "VL_Lancto_Grid")
                {
                    DataGridViewCell Celula = grid_LanctoNFHeadge.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Celula.Style.ForeColor = Color.Blue;
                }
            }
        }

        private void FLan_AlteracaoHeadge_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_LanctoNFHeadge);
            if (!fechaNormal)
            {
                ListaNFHeadge.Clear();
                if (MessageBox.Show("Deseja realmente cancelar a alteração?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    fechaNormal = true;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void TFLan_AlteracaoHeadge_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_LanctoNFHeadge);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

    }
}
