using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFParamDRE : Form
    {
        public string Id_dre
        { get; set; }
        private CamadaDados.Financeiro.DRE.TRegistro_paramDRE rparam;
        public CamadaDados.Financeiro.DRE.TRegistro_paramDRE rParam
        {
            get
            {
                if (bsParamDRE.Current != null)
                    return bsParamDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE;
                else return null;
            }
            set { rparam = value; }
        }
        public TFParamDRE()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ANALITICA", "A"));
            cbx.Add(new Utils.TDataCombo("SINTETICA", "S"));
            cbx.Add(new Utils.TDataCombo("RESULTADO", "R"));
            tp_conta.DataSource = cbx;
            tp_conta.DisplayMember = "Display";
            tp_conta.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new Utils.TDataCombo("SOMAR", "S"));
            cbx1.Add(new Utils.TDataCombo("DIMINUIR", "D"));
            operador.DataSource = cbx1;
            operador.DisplayMember = "Display";
            operador.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_param.Text))
            {
                MessageBox.Show("Obrigatório informar nome paràmetro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_param.Focus();
                return;
            }
            if (tp_conta.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar tipo parâmetro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_conta.Focus();
                return;
            }
            if (tp_conta.SelectedValue.ToString() != "R" && operador.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar operador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                operador.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFParamDRE_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rparam == null)
                bsParamDRE.AddNew();
            else bsParamDRE.DataSource = new CamadaDados.Financeiro.DRE.TList_paramDRE() { rparam };
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFParamDRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void id_parampai_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_param|=|" + id_parampai.Text.Trim() + ";" +
                            "a.id_dre|=|" + Id_dre + ";" +
                            "a.tp_conta|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_parampai, ds_parampai },
                new CamadaDados.Financeiro.DRE.TCD_paramDRE());
        }

        private void bb_parampai_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_param|Parâmetro|200;" +
                             "a.id_param|Código|60";
            string vParam = "a.id_dre|=|" + Id_dre + ";a.tp_conta|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_parampai, ds_parampai },
                new CamadaDados.Financeiro.DRE.TCD_paramDRE(), vParam);
        }
    }
}
