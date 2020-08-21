using System;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFListFormula : Form
    {
        public CamadaDados.Producao.Producao.TList_FormulaApontamento lFormula { get; set; }
        public CamadaDados.Producao.Producao.TRegistro_FormulaApontamento rFormula
        {
            get
            {
                if (bsFormula.Current != null)
                    return bsFormula.Current as CamadaDados.Producao.Producao.TRegistro_FormulaApontamento;
                else return null;
            }
        }
        public TFListFormula()
        {
            InitializeComponent();
        }

        private void TFListFormula_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsFormula.DataSource = lFormula;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFListFormula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
