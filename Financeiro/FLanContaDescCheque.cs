using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFLanContaDescCheque : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        public string Cd_contager
        {
            get
            {
                return cd_contager_destino.Text;
            }
        }

        public DateTime? Dt_enviolote
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(DT_Pgto.Text);
                }
                catch
                { return null; }
            }
        }

        public TFLanContaDescCheque()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanContaDescCheque_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_empresa.Text = this.Cd_empresa;
            nm_empresa.Text = this.Nm_empresa;
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_contacompensacao, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + this.Cd_empresa.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_destino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager_destino.Text.Trim() + "';" +
                            "isnull(a.st_contacompensacao, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + this.Cd_empresa.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam,
                new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (cd_contager_destino.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_contager_destino.Focus();
                return;
            }
            if((DT_Pgto.Text.Trim().Equals(string.Empty) || DT_Pgto.Text.Trim().Equals("/  /")))
            {
                MessageBox.Show("Obrigatorio informar data de envio do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Pgto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanContaDescCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
