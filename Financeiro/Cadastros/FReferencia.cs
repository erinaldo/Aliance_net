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
    public partial class TFReferencia : Form
    {
         private TRegistro_CadReferenciaCliFor rreferencia;
         public TRegistro_CadReferenciaCliFor rReferencia
         {
             get
             {
                 if (bsReferencia.Current != null)
                     return bsReferencia.Current as TRegistro_CadReferenciaCliFor;
                 else
                     return null;
             }
             set { rreferencia = value; }
         }

        public TFReferencia()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("<NENHUM>", ""));
            cbx1.Add(new Utils.TDataCombo("PESSOAL", "P"));
            cbx1.Add(new Utils.TDataCombo("COMERCIAL", "C"));
            tipo_referencia.DataSource = cbx1;
            tipo_referencia.DisplayMember = "Display";
            tipo_referencia.ValueMember = "Value";

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("PAI", "PA"));
            cbx.Add(new TDataCombo("MÃE", "MA"));
            cbx.Add(new TDataCombo("FILHO/FILHA", "FL"));
            cbx.Add(new TDataCombo("NETO/NETA", "NT"));
            cbx.Add(new TDataCombo("AVÔ/AVÓ", "AV"));
            cbx.Add(new TDataCombo("PRIMO/PRIMA", "PR"));
            cbx.Add(new TDataCombo("SOBRINHO/SOBRINHA", "SB"));
            cbx.Add(new TDataCombo("TIO/TIA", "TI"));
            cbx.Add(new TDataCombo("SOGRO/SOGRA", "SG"));
            cbx.Add(new TDataCombo("CUNHADO/CUNHADA", "CH"));
            cbx.Add(new TDataCombo("AMIGO/AMIGA", "AM"));
            cbx.Add(new TDataCombo("VIZINHO/VIZINHA", "VZ"));
            cbx.Add(new TDataCombo("OUTROS", "OU"));
            tp_parentesco.DataSource = cbx;
            tp_parentesco.DisplayMember = "Display";
            tp_parentesco.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pReferencia.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFReferencia_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rreferencia != null)
                bsReferencia.DataSource = new TList_CadReferenciaCliFor() { rreferencia };
            else
                bsReferencia.AddNew();
            nm_referencia.Focus();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFReferencia_KeyDown(object sender, KeyEventArgs e)
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

        private void tipo_referencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParentesco.Visible = tipo_referencia.SelectedIndex.Equals(1);
            tp_parentesco.Visible = tipo_referencia.SelectedIndex.Equals(1);
        }

        private void tp_parentesco_VisibleChanged(object sender, EventArgs e)
        {
            if (!tp_parentesco.Visible)
                tp_parentesco.SelectedIndex = -1;
        }
    }
}
