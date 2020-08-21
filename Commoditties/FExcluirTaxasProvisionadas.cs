using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFExcluirTaxasProvisionadas : Form
    {
        public string Nr_contrato
        { get; set; }

        public List<CamadaDados.Graos.TRegistro_TaxaDeposito> lTaxa
        {
            get
            {
                if (bsTaxaRealizar.Count > 0)
                    return (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).FindAll(p => p.St_faturar);
                else
                    return null;
            }
        }

        public TFExcluirTaxasProvisionadas()
        {
            InitializeComponent();
            this.Nr_contrato = string.Empty;
        }

        private void TFExcluirTaxasProvisionadas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTaxaRealizar);
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar taxas provisionadas
            bsTaxaRealizar.DataSource = CamadaNegocio.Graos.TCN_LanTaxas_Deposito.BuscarTx(Nr_contrato,
                                                                                           "'P', 'M'",
                                                                                           null);
            ps_provisionado.Value = (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Ps_Taxa);
            vl_provisionado.Value = (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).Sum(p => p.Vl_Taxa);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void st_marcatodos_Click(object sender, EventArgs e)
        {
            if (bsTaxaRealizar.Count > 0)
            {
                (bsTaxaRealizar.DataSource as CamadaDados.Graos.TList_TaxaDeposito).ForEach(p => p.St_faturar = st_marcatodos.Checked);
                bsTaxaRealizar.ResetBindings(true);
            }
        }

        private void gTaxaRealizar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsTaxaRealizar.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsTaxaRealizar.Current as CamadaDados.Graos.TRegistro_TaxaDeposito).St_faturar =
                        !(bsTaxaRealizar.Current as CamadaDados.Graos.TRegistro_TaxaDeposito).St_faturar;
                    bsTaxaRealizar.ResetCurrentItem();
                }
        }

        private void TFExcluirTaxasProvisionadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFExcluirTaxasProvisionadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTaxaRealizar);
        }
    }
}
