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
    public partial class TFAlterarCResultado : Form
    {
        public string Tp_movimento
        { get; set; }
        public string Id_empreendimento
        { get; set; }
        public bool St_novo
        { get; set; }

        private CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto rcusto;
        public CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto rCusto
        {
            get
            {
                if (bsCCusto.Current != null)
                    return bsCCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto;
                else
                    return null;
            }
            set { rcusto = value; }
        }

        public string Cd_ccusto
        {
            get
            {
                return cd_ccusto.Text;
            }
        }

        public TFAlterarCResultado()
        {
            InitializeComponent();
            this.St_novo = false;
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_ccusto.Text))
            {
                MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_ccusto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFAlterarCResultado_Load(object sender, EventArgs e)
        {
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (this.St_novo)
            {
                this.Text = "Centro Resultado";
                this.tlpCentral.RowStyles[0] = new RowStyle(SizeType.Absolute, 0);
            }
            else
                bsCCusto.Add(rcusto);
            if (!string.IsNullOrEmpty(Tp_movimento))
                tp_movimento.Text = Tp_movimento;
        }

        private void bb_ccusto_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResultado fBusca = new FormBusca.TFBuscaCentroResultado())
            {
                if (!string.IsNullOrEmpty(tp_movimento.Text))
                    fBusca.Tp_registro = (tp_movimento.Text.Trim().ToUpper().Equals("RECEITA") ? "'R'" : "'D'");
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_ccusto.Text = fBusca.Cd_centro;
                        ds_ccusto.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_ccusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_ccusto.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.cd_centroresult|<>|'" + cd_grupocfEditDefault.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(tp_movimento.Text))
                vParam += ";a.tp_registro|=|'" + (tp_movimento.Text.Trim().ToUpper().Equals("RECEITA") ? "R" : "D") + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ccusto, ds_ccusto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAlterarCResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
