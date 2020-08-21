using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFContatoPF : Form
    {
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor rcontato;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor rContato
        {
            get { return bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor; }
            set { rcontato = value; }
        }

        public TFContatoPF()
        {
            InitializeComponent();

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
            tp_relacionamento.DataSource = cbx;
            tp_relacionamento.DisplayMember = "Display";
            tp_relacionamento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFContatoPF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcontato != null)
                bsContato.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor() { rcontato };
            else bsContato.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFContatoPF_KeyDown(object sender, KeyEventArgs e)
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

        private void bb_data_Click(object sender, EventArgs e)
        {
            using (TFDataAdicionais fData = new TFDataAdicionais())
            {
                fData.St_contato = true;
                fData.Cd_clifor = (bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).Cd_CliFor;
                fData.Id_contato = (bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).Id_Contato_St;
                if (fData.ShowDialog() == DialogResult.OK)
                {
                    if (fData.lDataContato.Count > 0)
                    {
                        fData.lDataContato.ForEach(p =>
                        (bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).lDataContato.Add(
                            new CamadaDados.Financeiro.Cadastros.TRegistro_DataContato()
                            {
                                Id_TpData = p.Id_TpData,
                                Data = p.Data
                            }));
                    }
                    if (fData.lDataContatoDel.Count > 0)
                    {
                        fData.lDataContatoDel.ForEach(p =>
                           (bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor).lDataContatoDel.Add(
                               new CamadaDados.Financeiro.Cadastros.TRegistro_DataContato()
                               {
                                   Id_contato = p.Id_contato,
                                   Cd_clifor = p.Cd_clifor,
                                   Id_TpData = p.Id_TpData,
                                   Data = p.Data
                               }));
                    }
                }
                bsContato.ResetCurrentItem();
            }
        }
    }
}
