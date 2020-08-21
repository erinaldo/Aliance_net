using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebCamLibrary;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFPessoasAutorizadas : Form
    {
        private CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas rpessoa;
        public CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas rPessoa
        {
            get
            {
                if (bsPessoas.Current != null)
                    return bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas;
                else return null;
            }
            set { rpessoa = value; }
        }

        public TFPessoasAutorizadas()
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
            cbx.Add(new TDataCombo("SÓCIO", "SC"));
            cbx.Add(new TDataCombo("CONJUGÊ", "CJ"));
            cbx.Add(new TDataCombo("FUNCIONÁRIO", "FC"));
            cbx.Add(new TDataCombo("OUTROS", "OU"));
            tp_relacionamento.DataSource = cbx;
            tp_relacionamento.DisplayMember = "Display";
            tp_relacionamento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(nm_pessoa.Text))
            {
                MessageBox.Show("Obrigatório informar nome.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_pessoa.Focus();
                return;
            }
            if (tp_relacionamento.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório informar grau parentesco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_relacionamento.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFPessoasAutorizadas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rpessoa != null)
                bsPessoas.DataSource = new CamadaDados.Financeiro.Cadastros.TList_PessoasAutorizadas() { rpessoa };
            else bsPessoas.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFPessoasAutorizadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void NR_CPF_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_CPF.Text.SoNumero()))
            {
                Utils.CPF_Valido.nr_CPF = NR_CPF.Text;
                if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NR_CPF.Clear();
                    NR_CPF.Focus();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (TFVisualizarCaptura fClifor = new TFVisualizarCaptura())
            {
                fClifor.Img = (bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).Img;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.Img != null)
                        try
                        {
                            (bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).Img = fClifor.Img;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }
    }
}
