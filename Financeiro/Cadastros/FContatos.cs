using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFContatos : Form
    {
        private TRegistro_CadContatoCliFor rcontato;
        public TRegistro_CadContatoCliFor rContato
        {
            get
            {
                if (bsContato.Current != null)
                    return bsContato.Current as TRegistro_CadContatoCliFor;
                else
                    return null;
            }
            set { rcontato = value; }
        }
        public TFContatos()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("FINANCEIRO", "F"));
            cbx1.Add(new Utils.TDataCombo("FATURAMENTO", "T"));
            cbx1.Add(new Utils.TDataCombo("COMERCIAL", "C"));
            cbx1.Add(new Utils.TDataCombo("OPERACIONAL", "P"));
            cbx1.Add(new Utils.TDataCombo("OUTROS", "O"));

            tipo_contato.DataSource = cbx1;
            tipo_contato.DisplayMember = "Display";
            tipo_contato.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pnl_Contato.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFContatos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcontato != null)
                bsContato.DataSource = new TList_CadContatoCliFor() { rcontato };
            else
                bsContato.AddNew();
            NM_Contato.Focus();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFContatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }

        private void FoneMovel_TextChanged(object sender, EventArgs e)
        {
            if (FoneMovel.Text.SoNumero().Length.Equals(10))
            {
                FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 2) + ")" + FoneMovel.Text.SoNumero().Substring(2, 4) + "-" + FoneMovel.Text.SoNumero().Substring(6, 4);
                FoneMovel.SelectionStart = FoneMovel.Text.Length;
            }
            else if (FoneMovel.Text.SoNumero().Length.Equals(11))
                if (FoneMovel.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 3) + ")" + FoneMovel.Text.SoNumero().Substring(3, 4) + "-" + FoneMovel.Text.SoNumero().Substring(7, 4);
                    FoneMovel.SelectionStart = FoneMovel.Text.Length;
                }
                else
                {
                    FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 2) + ")" + FoneMovel.Text.SoNumero().Substring(2, 5) + "-" + FoneMovel.Text.SoNumero().Substring(7, 4);
                    FoneMovel.SelectionStart = FoneMovel.Text.Length;
                }
            else if (FoneMovel.Text.SoNumero().Length.Equals(12))
            {
                FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 3) + ")" + FoneMovel.Text.SoNumero().Substring(3, 5) + "-" + FoneMovel.Text.SoNumero().Substring(8, 4);
                FoneMovel.SelectionStart = FoneMovel.Text.Length;
            }
        }
    }
}
