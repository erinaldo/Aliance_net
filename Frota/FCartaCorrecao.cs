using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFCartaCorrecao : Form
    {
        public CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe rEvento
        { get { return bsEventoCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe; } }

        public TFCartaCorrecao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsCampos.Count.Equals(0))
            {
                MessageBox.Show("Obrigatório informar registro para correção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFCartaCorrecao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            ds_grupo.CharacterCasing = CharacterCasing.Normal;
            ds_campo.CharacterCasing = CharacterCasing.Normal;
            valoralterado.CharacterCasing = CharacterCasing.Normal;
            bsEventoCTe.AddNew();
        }

        private void bbIncluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ds_grupo.Text))
            {
                MessageBox.Show("Obrigatório informar grupo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_grupo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ds_campo.Text))
            {
                MessageBox.Show("Obrigatório informar campo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_campo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(valoralterado.Text))
            {
                MessageBox.Show("Obrigatório informar valor alteração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valoralterado.Focus();
                return;
            }
            (bsEventoCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe).lCamposCC.Add(
                new CamadaDados.Faturamento.CTRC.TRegistro_CamposCC()
                {
                    Ds_grupo = ds_grupo.Text,
                    Ds_campo = ds_campo.Text,
                    ValorAlterado = valoralterado.Text
                });
            bsEventoCTe.ResetCurrentItem();
            ds_grupo.Clear();
            ds_campo.Clear();
            valoralterado.Clear();
            ds_grupo.Focus();
        }

        private void bb_exclui_evento_Click(object sender, EventArgs e)
        {
            if(bsCampos.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsCampos.RemoveCurrent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCartaCorrecao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
