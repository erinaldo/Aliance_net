using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using FormBusca;

namespace Parametros.Diversos
{
    public partial class TFAuditoria : Form
    {
        public TFAuditoria()
        {
            InitializeComponent(); 
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo(string.Empty, string.Empty));
            cbx.Add(new Utils.TDataCombo("UPDATE", "U"));
            cbx.Add(new Utils.TDataCombo("DELETE", "D"));
            cbTrigger.DataSource = cbx;
            cbTrigger.DisplayMember = "Display";
            cbTrigger.ValueMember = "Value";
        }

        private void afterBusca()
        {
            bsAuditoria.DataSource = TCN_Auditoria.Buscar(string.Empty,
                                                          string.Empty,
                                                          eddtini.Text,
                                                          eddtfim.Text,
                                                          tabela.Text,
                                                          cbTrigger.SelectedValue.ToString(),null);

        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsAuditoria_PositionChanged(object sender, EventArgs e)
        {
            if(bsAuditoria.Current != null)
            bsColuna.DataSource = new TCD_ColunasAudit().Buscar( new Utils.TpBusca[]{
                                                                     new Utils.TpBusca{
                                                                        vNM_Campo = "a.id_auditoria",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'"+ (bsAuditoria.Current as TRegistro_Auditoria).Id_auditoriastr +"'"
                                                                     }
                                                                 }
                                                                 ,0);
            bsColuna.ResetCurrentItem();
        }

        private void dataGridDefault1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 4)// tipo 
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("DELETE"))
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("UPDATE"))
                    {
                        DataGridViewRow linha = dataGridDefault1.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
        }

        private void cbTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void editData1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TFAuditoria_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            //System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            //cbx.Add(new Utils.TDataCombo(string.Empty, string.Empty));
            //cbx.Add(new Utils.TDataCombo("UPDATE", "U"));
            //cbx.Add(new Utils.TDataCombo("DELETE", "D"));
            //new TCD_Auditoria().Select
            //cbTrigger.DataSource = cbx;
            //cbTrigger.DisplayMember = "Display";
            //cbTrigger.ValueMember = "Value";
        }

        private void TFAuditoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }
    }
}
