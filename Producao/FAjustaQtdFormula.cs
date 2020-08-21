using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFAjustaQtdFormula : Form
    {
        public CamadaDados.Producao.Producao.TList_FormulaApontamento lFormula
        { get; set; }

        public TFAjustaQtdFormula()
        {
            InitializeComponent();
        }

        private void MoveRegistros(string A_V)
        {
            if (A_V.Trim().ToUpper().Equals("A"))
            {
                (bsFichaTec_MPrima.Current as CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima).Qtd_produto = qtd_mprima.Value;
                bsFichaTec_MPrima.MoveNext();
            }
            else if (A_V.Trim().ToUpper().Equals("V"))
            {
                (bsFichaTec_MPrima.Current as CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima).Qtd_produto = qtd_mprima.Value;
                bsFichaTec_MPrima.MovePrevious();
            }
        }

        private void qtd_mprima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                MoveRegistros("A");
            else if (e.KeyCode.Equals(Keys.Escape))
                MoveRegistros("V");
        }
        
        private void BB_Voltar_Click(object sender, EventArgs e)
        {
            MoveRegistros("V");
        }

        private void BB_Avancar_Click(object sender, EventArgs e)
        {
            MoveRegistros("A");
        }
        
        private void TFAjustaQtdFormula_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            label2.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label8.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            bsFormulaApontamento.DataSource = lFormula;
            bsFormulaApontamento.ResetCurrentItem();
            qtd_mprima.Focus();
        }

        private void TFAjustaQtdFormula_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }
    }
}
