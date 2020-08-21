using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public partial class TFNumero_Nota : Form
    {
        public string pNr_serie
        { get; set; }
        public string pDs_serie
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pTp_nota
        { get; set; }
        public decimal pNr_notafiscal
        { get; set; }

        public TFNumero_Nota()
        {
            InitializeComponent();
        }
                
        private void TFNumero_Nota_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_empresa.Text = pCd_empresa;
            nm_empresa.Text = pNm_empresa;
            cd_clifor.Text = pCd_clifor;
            nm_clifor.Text = pNm_clifor;
            nr_serie.Text = pNr_serie;
            ds_serie.Text = pDs_serie;
            tp_nota.Text = pTp_nota.Trim().ToUpper().Equals("P") ? "PROPRIA" : pTp_nota.Trim().ToUpper().Equals("T") ? "TERCEIRO" : string.Empty;
        }

        private void TFNumero_Nota_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            try
            {
                this.pNr_notafiscal = Convert.ToDecimal(NR_Nota.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch
            { MessageBox.Show("Numero nota fiscal informado não é valido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {

        }
    }
}
