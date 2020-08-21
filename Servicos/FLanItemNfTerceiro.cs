using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFLanItemNfTerceiro : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }

        public decimal Vl_unitario
        {
            get
            {
                return vl_unitario.Value;
            }
        }

        public TFLanItemNfTerceiro()
        {
            InitializeComponent();
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Quantidade = decimal.Zero;
        }

        private void afterGrava()
        {
            if (vl_unitario.Value <= 0)
            {
                MessageBox.Show("Obrigatorio informar valor unitario para gravar.", "Mensagem",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_unitario.Focus();
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanItemNfTerceiro_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_produto.Text = this.Cd_produto;
            ds_produto.Text = this.Ds_produto;
            qtd_os.Value = this.Quantidade;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanItemNfTerceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void vl_unitario_ValueChanged(object sender, EventArgs e)
        {
            vl_subtotal.Value = qtd_os.Value * vl_unitario.Value;
        }
    }
}
