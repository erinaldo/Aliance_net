using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFDeclaracaoImport : Form
    {
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_DeclaracaoImport rdi;
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_DeclaracaoImport rDi
        {
            get
            {
                if (BS_DI.Current != null)
                    return BS_DI.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_DeclaracaoImport;
                else return null;
            }
            set { rdi = value; }
        }

        public TFDeclaracaoImport()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx_intermedio = new System.Collections.ArrayList();
            cbx_intermedio.Add(new Utils.TDataCombo("IMPORTACAO POR CONTA PROPRIA", "1"));
            cbx_intermedio.Add(new Utils.TDataCombo("IMPORTACAO POR CONTA E ORDEM", "2"));
            cbx_intermedio.Add(new Utils.TDataCombo("IMPORTACAO POR ENCOMENDA", "3"));
            TP_intermedio.DataSource = cbx_intermedio;
            TP_intermedio.ValueMember = "Value";
            TP_intermedio.DisplayMember = "Display";

            System.Collections.ArrayList cbx_ViaTransp = new System.Collections.ArrayList();
            cbx_ViaTransp.Add(new Utils.TDataCombo("MARITIMA", "1"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("FLUVIAL", "2"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("LACUSTRE", "3"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("AEREA", "4"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("POSTAL", "5"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("FERROVIARIA", "6"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("RODOVIARIA", "7"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("CONDUTO/REDE TRANSMISSAO", "8"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("MEIOS PROPRIOS", "9"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("ENTRADA/SAIDA FICTA", "10"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("COURIER", "11"));
            cbx_ViaTransp.Add(new Utils.TDataCombo("HANDCARRY", "12"));
            TP_ViaTransp.DataSource = cbx_ViaTransp;
            TP_ViaTransp.ValueMember = "Value";
            TP_ViaTransp.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pdados.validarCampoObrigatorio())
            {
                if (Vl_AFRMM.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Valor deve ser maior que 0!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Vl_AFRMM.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFDeclaracaoImport_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_ufdesemb.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.Buscar(string.Empty, string.Empty, string.Empty, string.Empty, 0, null);
            cd_ufdesemb.ValueMember = "CD_UF";
            cd_ufdesemb.DisplayMember = "DS_UF";

            if (rdi != null)
                BS_DI.DataSource = new CamadaDados.Faturamento.NotaFiscal.TList_DeclaracaoImport() { rdi };
            else
                BS_DI.AddNew();
        }

        private void TFDeclaracaoImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
