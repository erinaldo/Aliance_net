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
    public partial class TFTransfTitulo : Form
    {
        public bool St_emitido
        { get; set; }

        public TFTransfTitulo()
        {
            InitializeComponent();
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta Gerencial|250;" +
                              "a.CD_ContaGer|Cd. Conta|80";
            string vParam = "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                            "isnull(a.st_contacompensacao, 'N')|" + (St_emitido ? "=" : "<>") + "|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_destino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager_destino.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";

            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (cd_contager_destino.Text.Trim().Equals(""))
            {
                MessageBox.Show("Obrigatório Informar Conta Destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_contager_destino.Focus();
                return;
            }
            if ((DT_Pgto.Text.Trim().Equals("")) || (DT_Pgto.Text.Trim().Equals("/  /")))
            {
                MessageBox.Show("Ogrigatório Informar Data da Transferência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Pgto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFTransfTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFTransfTitulo_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            gbOrigem.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

        private void DT_Pgto_Enter(object sender, EventArgs e)
        {
            DT_Pgto.Select(0, DT_Pgto.Text.Length);
        }
    }
}
