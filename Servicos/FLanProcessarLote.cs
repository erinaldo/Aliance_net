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
    public partial class TFLanProcessarLote : Form
    {
        public string Id_lote
        { get; set; }
        public string Ds_lote
        { get; set; }
        public bool St_gerarpedido
        {
            get
            {
                return st_gerarpedido.Checked;
            }
        }
        public DateTime? Dt_enviolote
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_processamento.Text);
                }
                catch
                { return null; }
            }
        }

        public TFLanProcessarLote()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (dt_processamento.Text.Trim().Equals(string.Empty) || dt_processamento.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data de envio do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_processamento.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanProcessarLote_Load(object sender, EventArgs e)
        {
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            id_lotebusca.Text = Id_lote;
            ds_lotebusca.Text = Ds_lote;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanProcessarLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
