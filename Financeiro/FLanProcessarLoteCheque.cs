using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFLanProcessarLoteCheque : Form
    {
        public DateTime? Dt_processamento
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(DT_Inic.Text);
                }
                catch
                { return null; }
            }
        }
        public decimal Vl_credito
        {
            get { return vl_credito.Value; }
        }
        public decimal Vl_taxa
        {
            get { return vl_taxa.Value; }
        }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques
        {
            get;
            set;
        }

        public TFLanProcessarLoteCheque()
        {
            InitializeComponent();
        }

        private void vl_taxa_ValueChanged(object sender, EventArgs e)
        {
            vl_credito.Value = vl_totalchequecompensar.Value - vl_taxa.Value;
        }

        private void vl_credito_ValueChanged(object sender, EventArgs e)
        {
            vl_taxa.Value = vl_totalchequecompensar.Value - vl_credito.Value;
        }

        private void TFLanProcessarLoteCheque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheques);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            lCheques.ForEach(p => p.St_conciliar = true);
            vl_totalchequecompensar.Value = lCheques.Sum(p => p.Vl_titulo);
            bsCheques.DataSource = lCheques;
        }

        private void gCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_conciliar = 
                    !(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_conciliar;
                bsCheques.ResetCurrentItem();
                if (bsCheques.DataSource != null)
                    vl_totalchequecompensar.Value = (bsCheques.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (DT_Inic.Text.Trim().Equals(string.Empty) || DT_Inic.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data de processamento do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Inic.Focus();
                return;
            }
            if (vl_credito.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar valor do credito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_credito.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanProcessarLoteCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanProcessarLoteCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCheques);
        }
    }
}
