using System;
using System.Windows.Forms;
using Utils;
namespace Faturamento
{
    public partial class FImp_OrdemCarregamento : Form
    {
        public FImp_OrdemCarregamento()
        {
            InitializeComponent();
        }
        public string item
        {
            get { return cbTipoHora.Text.ToString(); }
        }
        private void FImp_OrdemCarregamento_Load(object sender, EventArgs e)
        {

            Icon = ResourcesUtils.TecnoAliance_ICO;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();


            cbx.Add(new TDataCombo("1.000 LTS  - OLEO QUEIMADO JAQUETADO", "1"));
            cbx.Add(new TDataCombo("2.000 LTS - OLEO QUEIMADO JAQUETADO", "2")); 
            cbx.Add(new TDataCombo("3.000 LTS - OLEO QUEIMADO JAQUETADO", "3"));
            cbx.Add(new TDataCombo("5.000 LTS - OLEO QUEIMADO JAQUETADO", "4"));
            cbx.Add(new TDataCombo("15.000 PLENO JAQUETADO - 1910X5400 MM", "5"));
            cbx.Add(new TDataCombo("15.000 PLENO JAQUETADO - 2549X3000 MM", "6"));
            cbx.Add(new TDataCombo("20.000 LTS BI 10-10 M³ JAQUETADO", "7"));
            cbx.Add(new TDataCombo("20.000 LTS PLENO JAQUETADO", "8"));
            cbx.Add(new TDataCombo("30.000 LTS BI 10-20 M³ JAQUETADO", "9"));
            cbx.Add(new TDataCombo("30.000 LTS BI 15-15 M³ JAQUETADO", "10"));
            cbx.Add(new TDataCombo("30.000 LTS PLENO JAQUETADO", "11"));
            cbx.Add(new TDataCombo("30.000 LTS TRI 10-10-10 M³ JAQUETADO", "12"));
            cbx.Add(new TDataCombo("60.000 LTS BI 30-30 M³ JAQUETADO", "13"));
            cbx.Add(new TDataCombo("60.000 LTS PLENO JAQUETADO", "14"));
            cbx.Add(new TDataCombo("60.000 LTS QUADRI 15-15-15-15 M³ JAQUETADO", "15"));
            cbx.Add(new TDataCombo("60.000 LTS TRI 20-20-20 M³ JAQUETADO", "16"));
            cbTipoHora.DataSource = cbx;
            cbTipoHora.DisplayMember = "Display";
            cbTipoHora.ValueMember = "Value";
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FImp_OrdemCarregamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
