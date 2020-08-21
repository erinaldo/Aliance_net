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
    public partial class TFAddCResultado : Form
    {
        public CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado rCResult
        { get { return bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado; } }

        public TFAddCResultado()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("RECEITA", "R"));
            cbx.Add(new Utils.TDataCombo("DESPESA", "D"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_centroresultado.Text))
            {
                MessageBox.Show("Obrigatório informar descrição centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_centroresultado.Focus();
                return;
            }
            if (!ST_Sintetico.Checked && string.IsNullOrEmpty(tp_registro.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo de Movimento para registro Analitico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFAddCResultado_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsCentroResult.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAddCResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_grupocf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CentroResultado|Centro Resultado|350;" +
                              "a.CD_CentroResult|Código|100";
            string vParamFixo = "isNull(a.ST_Sintetico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_centroresult_pai, ds_centroresult_pai },
                                             new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado(), vParamFixo);
        }

        private void cd_centroresult_pai_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_centroresult|=|'" + cd_centroresult_pai.Text.Trim() + "';" +
                              "isNull(a.ST_Sintetico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_centroresult_pai, ds_centroresult_pai },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }
    }
}
