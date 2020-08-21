using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFEncerranteCaixa : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Id_caixa
        { get; set; }
        public bool St_gravarencerranteLMC
        { get { return st_gravarencerrante.Checked; } }

        public CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lBico
        {
            get
            {
                if (bsBicoBomba.Count > 0)
                    return bsBicoBomba.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba;
                else return null;
            }
        }

        public TFEncerranteCaixa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsBicoBomba.Count > 0)
            {
                if ((bsBicoBomba.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).Exists(p => p.Qtd_encerrante.Equals(decimal.Zero)))
                {
                    MessageBox.Show("Obrigatorio informar encerrante para todos os bicos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsBicoBomba.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).Exists(p => p.Diferenca_venda < decimal.Zero))
                {
                    MessageBox.Show("Não é permitido informar ENCERRANTE ATUAL com diferença NEGATIVA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFEncerranteCaixa_Load(object sender, EventArgs e)
        {
            //Buscar bicos ativos para a empresa
            bsBicoBomba.DataSource = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().SelectEncerrante(Cd_empresa, Id_caixa);
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsBicoBomba.MoveNext();
            qtd_encerrante.Focus();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsBicoBomba.MovePrevious();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEncerranteCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void qtd_encerrante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                (bsBicoBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Qtd_encerrante = qtd_encerrante.Value;
                bsBicoBomba.ResetCurrentItem();
                bb_avancar_Click(this, new EventArgs());
            }
        }
    }
}
