using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFCentralAudit : Form
    {
        public TFCentralAudit()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<TODOS>", string.Empty));
            cbx.Add(new Utils.TDataCombo("UPDATE", "U"));
            cbx.Add(new Utils.TDataCombo("DELETE", "D"));
            tp_evento.DataSource = cbx;
            tp_evento.DisplayMember = "Display";
            tp_evento.ValueMember = "Value";

            DataTable tb_tabela = new CamadaDados.Diversos.TCD_Auditoria().BuscarTabelas();
            nm_tabela.Items.Add("<TODOS>");
            if (tb_tabela != null)
                if (tb_tabela.Rows.Count > 0)
                    foreach (DataRow linha in tb_tabela.Rows)
                        nm_tabela.Items.Add(linha["name"].ToString().Trim().ToUpper());
            nm_tabela.SelectedIndex = 0;
        }

        private void afterBusca()
        {
            bsAuditoria.DataSource = CamadaNegocio.Diversos.TCN_Auditoria.Buscar(string.Empty,
                                                                                 login.Text,
                                                                                 dt_ini.Text,
                                                                                 dt_fin.Text,
                                                                                 nm_tabela.SelectedIndex > 0 ? nm_tabela.Text : string.Empty,
                                                                                 tp_evento.SelectedValue != null ? tp_evento.SelectedValue.ToString() : string.Empty,
                                                                                 null);
            bsAuditoria_PositionChanged(this, new EventArgs());
        }

        private void afterConfig()
        {
            using (TFCfgAudit fCfg = new TFCfgAudit())
            {
                fCfg.ShowDialog();
            }
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void FCentralAudit_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsAuditoria_PositionChanged(object sender, EventArgs e)
        {
            if (bsAuditoria.Current != null)
            {
                (bsAuditoria.Current as CamadaDados.Diversos.TRegistro_Auditoria).lColunas =
                    CamadaNegocio.Diversos.TCN_ColunasAudit.Buscar((bsAuditoria.Current as CamadaDados.Diversos.TRegistro_Auditoria).Id_auditoriastr, null);
                bsAuditoria.ResetCurrentItem();
            }
        }

        private void TFCentralAudit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.afterConfig();
        }
    }
}
