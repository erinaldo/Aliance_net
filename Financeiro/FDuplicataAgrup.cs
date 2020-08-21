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
    public partial class TFDuplicataAgrup : Form
    {
        private CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rdup;
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        {
            get
            {
                if (dsDuplicata.Current != null)
                    return dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                else return null;
            }
            set { rdup = value; }
        }

        public TFDuplicataAgrup()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_historico.Text))
            {
                MessageBox.Show("Obrigatorio informar historico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_historico.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_docto.Text))
            {
                MessageBox.Show("Obrigatorio informar numero documento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_docto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFDuplicataAgrup_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            dsDuplicata.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata() { rdup };
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDuplicataAgrup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100";
            string vParamFixo = "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text + "';" +
                              "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_configboleto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_configboleto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco(), vParam);
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_configboleto }, new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco());
        }
    }
}
