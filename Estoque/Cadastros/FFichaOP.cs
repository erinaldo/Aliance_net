using CamadaDados.Estoque.Cadastros;
using System;
using System.Windows.Forms;
using Utils;

namespace Estoque.Cadastros
{
    public partial class TFFichaOP : Form
    {
        private TRegistro_FichaOP rficha;
        public TRegistro_FichaOP rFicha
        {
            get
            {
                if (bsFichaOP.Current != null)
                    return bsFichaOP.Current as TRegistro_FichaOP;
                else return null;
            }
            set { rficha = value; }
        }

        public TFFichaOP()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("USINAGEM", "U"));
            cbx.Add(new TDataCombo("ACESSORIOS", "A"));
            tp_item.DataSource = cbx;
            tp_item.ValueMember = "Value";
            tp_item.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(ds_item.Text))
            {
                MessageBox.Show("Obrigatório informar item ficha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_item.Focus();
                return;
            }
            if(quantidade.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if(diasprevisao.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar dias previsão produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                diasprevisao.Focus();
                return;
            }
            if(tp_item.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar tipo item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_item.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFFichaOP_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (rficha == null)
                bsFichaOP.AddNew();
            else bsFichaOP.DataSource = new TList_FichaOP { rficha };
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFFichaOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
