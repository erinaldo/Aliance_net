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
    public partial class TFCfgAudit : Form
    {
        public TFCfgAudit()
        {
            InitializeComponent();
        }

        private void TFCfgAudit_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar tabelas do banco de dados
            DataTable tb_tabela = new CamadaDados.Diversos.TCD_Auditoria().BuscarTabelas();
            if (tb_tabela != null)
                if (tb_tabela.Rows.Count > 0)
                    foreach (DataRow linha in tb_tabela.Rows)
                        lbTabelas.Items.Add(linha["name"].ToString().Trim().ToUpper());
        }

        private void lbTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTabelas.SelectedIndex >= 0)
                bsTrigger.DataSource = new CamadaDados.Diversos.TCD_Auditoria().BuscarTrigger(lbTabelas.Items[lbTabelas.SelectedIndex].ToString());
        }

        private void bb_buscartrigger_Click(object sender, EventArgs e)
        {
            bsTrigger.DataSource = new CamadaDados.Diversos.TCD_Auditoria().BuscarTrigger(string.Empty);
        }

        private void bb_ativar_Click(object sender, EventArgs e)
        {
            if (bsTrigger.Current != null)
            {
                if ((bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).ST_Enabled)
                {
                    MessageBox.Show("Trigger ja se encontra ativa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    new CamadaDados.TDataQuery().executarSql("alter table " + (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).Nm_tabela.Trim() +
                                                             " enable trigger " + (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).Nm_trigger.Trim(), null);
                    (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).ST_Enabled = true;
                    bsTrigger.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro ativar trigger: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_desativar_Click(object sender, EventArgs e)
        {
            if (bsTrigger.Current != null)
            {
                if (!(bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).ST_Enabled)
                {
                    MessageBox.Show("Trigger ja se encontra desativada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    new CamadaDados.TDataQuery().executarSql("alter table " + (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).Nm_tabela.Trim() +
                                                             " disable trigger " + (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).Nm_trigger.Trim(), null);
                    (bsTrigger.Current as CamadaDados.Diversos.TRegistro_Trigger).ST_Enabled = false;
                    bsTrigger.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro desativar trigger: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
