using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class TFTarefas : Form
    {
        public string descricao = "tarefa";
        public string pDs_tarefa
        { get { return ds_tarefa.Text; } }


        public string pCd_Empresa { get; set; }
        public TFTarefas()
        {
            InitializeComponent();
        }
        private void afterGrava()
        {
            if(string.IsNullOrEmpty(ds_tarefa.Text))
            {
                MessageBox.Show("Obrigatório informar "+descricao, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFTarefas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFTarefas_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            ds_tarefa.CharacterCasing = CharacterCasing.Normal;
        }
    }
}
