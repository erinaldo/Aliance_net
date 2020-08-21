using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento.Cadastro;

namespace Empreendimento.Cadastro
{
    public partial class FCadRequisitoAtividade : Form
    {
        public string vcd_atividade { get; set; } = string.Empty;
        public string vds_atividade { get; set; } = string.Empty;
        public string vcd_requisito { get; set; } = string.Empty;
        
        private CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos cRequisitos
        {
            get;set;
        }
        public CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos rRequisitos
        {
            set
            {
                cRequisitos = value;
            }
            get
            {
                return bsCadRequisitos.Current as TRegistro_CadRequisitos;
            }
        }
        public FCadRequisitoAtividade()
        {
            InitializeComponent();
        }

        private void FCadRequisitoAtividade_Load(object sender, EventArgs e)
        {
            if (cRequisitos != null)
            {
                bsCadRequisitos.Add(cRequisitos);
            }
            else
                bsCadRequisitos.AddNew();

            cd_atividade.Text = vcd_atividade;
            ds_atividade.Text = vds_atividade;
            // editDefault3.Text = vcd_requisito;
            richTextBox1.Focus();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Gravar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                if (panelDados2.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FCadRequisitoAtividade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }
    }
}
