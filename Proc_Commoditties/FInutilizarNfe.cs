using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Proc_Commoditties
{
    public partial class TFInutilizarNfe : Form
    {
        public bool St_inutilizarCte
        { get; set; }

        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Nr_serie
        { get { return nr_serie.Text; } }
        public string Cd_modelo
        { get { return cd_modelo.Text; } }
        public int Ano
        { get { return ano.Value.Year; } }
        public decimal Nfeini
        { get { return nfe_inicial.Value; } }
        public decimal Nfefin
        { get { return nfe_final.Value; } }
        public string Justificativa
        { get { return justificativa.Text.Trim(); } }

        public TFInutilizarNfe()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (justificativa.Text.Trim().Length < 15)
                {
                    MessageBox.Show("Obrigatorio informar no minimo 15 caracteres no campo justificativa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    justificativa.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFInutilizarNfe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_empresa.Text = this.Cd_empresa;
            NM_Empresa.Text = this.Nm_empresa;
            if (this.St_inutilizarCte)
                this.Text = "Inutilizar Sequencia CT-e";
            else this.Text = "Inutilizar Sequencia NF-e/NFC-e";
        }
                
        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "a.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80";
            string vParam = "a.cd_modelo|in|(" + (this.St_inutilizarCte ? "'57'" : "'55', '65'") + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|=|'" + nr_serie.Text.Trim() + "';" +
                "a.cd_modelo|in|(" + (this.St_inutilizarCte ? "'57'" : "'55', '65'") + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas
                , new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFInutilizarNfe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void justificativa_TextChanged(object sender, EventArgs e)
        {
            lblCaracteres.Text = "Total Caracteres: " + justificativa.Text.Length.ToString();
        }
    }
}
