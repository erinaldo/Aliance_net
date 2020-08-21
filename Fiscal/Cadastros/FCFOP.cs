using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class FCFOP : Form
    {
        private CamadaDados.Fiscal.TRegistro_CadCFOP cCFOP 
        {
            get;
            set;

        }
        public CamadaDados.Fiscal.TRegistro_CadCFOP rCFOP
        {
            get
            {
                return BS_CFOP.Current as CamadaDados.Fiscal.TRegistro_CadCFOP;
            }
            set
            {
                cCFOP = value;
            }

        }

        public FCFOP()
        {
            InitializeComponent();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja gravar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void FCFOP_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (cCFOP != null)
                BS_CFOP.Add(cCFOP);
            else
                BS_CFOP.AddNew();
        }

        private void FCFOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());

            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }
    }
}
