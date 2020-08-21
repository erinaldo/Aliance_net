using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFLanListaCartaFrete : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal Vl_totaltitulo
        { get; set; }
        public bool St_faturartotal
        { get; set; }
        public DateTime? Dt_vencimento
        { get; set; }

        public CamadaDados.PostoCombustivel.TList_CartaFrete lCarta
        { get; set; }

        public TFLanListaCartaFrete()
        {
            InitializeComponent();
            this.lCarta = new CamadaDados.PostoCombustivel.TList_CartaFrete();
        }

        private void afterNovo()
        {
            if (vl_saldo.Value > decimal.Zero)
                using (TFCartaFrete fCarta = new TFCartaFrete())
                {
                    fCarta.Cd_empresa = Cd_empresa;
                    fCarta.Nm_empresa = Nm_empresa;
                    fCarta.Dt_vencimento = Dt_vencimento;
                    if (fCarta.ShowDialog() == DialogResult.OK)
                    {
                        lCarta.Add(fCarta.rCF);
                        bsCartaFrete.ResetBindings(true);
                        bsCartaFrete_PositionChanged(this, new EventArgs());
                    }
                }
            else
                MessageBox.Show("Não existe mais saldo lançar nova carta frete.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void afterGrava()
        {
            if (this.St_faturartotal && (vl_saldo.Value > decimal.Zero))
                MessageBox.Show("Obrigatorio valor total da venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else this.DialogResult = DialogResult.OK;
        }

        private void afterExclui()
        {
            if(bsCartaFrete.Current != null)
                if (MessageBox.Show("Confirma exclusão da carta frete?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    bsCartaFrete.RemoveCurrent();
                    bsCartaFrete_PositionChanged(this, new EventArgs());
                }
        }

        private void TFLanListaCartaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_totalliquidar.Value = Vl_totaltitulo;
            bsCartaFrete.DataSource = lCarta;
        }

        private void vl_totalliquidar_ValueChanged(object sender, EventArgs e)
        {
            vl_saldo.Value = vl_totalliquidar.Value - vl_totcartafrete.Value;
        }

        private void vl_totcartafrete_ValueChanged(object sender, EventArgs e)
        {
            vl_saldo.Value = vl_totalliquidar.Value - vl_totcartafrete.Value;
        }

        private void bsCartaFrete_PositionChanged(object sender, EventArgs e)
        {
            if (lCarta != null)
                vl_totcartafrete.Value = lCarta.Sum(p => p.Vl_documento);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanListaCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
