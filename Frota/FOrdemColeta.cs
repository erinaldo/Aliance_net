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
    public partial class TFOrdemColeta : Form
    {
        private CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta rordem;
        public CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta rOrdem
        {
            get
            {
                if (bsOrdemColeta.Current != null)
                    return bsOrdemColeta.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTROrdemColeta;
                else return null;
            }
            set { rordem = value; }
        }

        public TFOrdemColeta()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFOrdemColeta_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rordem != null)
                bsOrdemColeta.DataSource = new CamadaDados.Faturamento.CTRC.TList_CTROrdemColeta() { rordem };
            else bsOrdemColeta.AddNew();
        }

        private void bbEmitente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_emitente, nm_emitente, cnpj_emitente }, "a.tp_pessoa|=|'J'");
        }

        private void cd_emitente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_emitente.Text.Trim() + "';a.tp_pessoa|=|'J'",
                new Componentes.EditDefault[] { cd_emitente, nm_emitente, cnpj_emitente },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbEndereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_endereco|Codigo|50;" +
                              "a.ds_endereco|Endereço|150;" +
                              "a.numero|Numero|30;" +
                              "a.bairro|Bairro|100;" +
                              "a.Fone|Fone|60;" +
                              "a.UF|UF|20;" +
                              "a.Insc_Estadual|Insc. Estadual|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, dsEndereco, uf },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_emitente.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_emitente.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, dsEndereco, uf },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFOrdemColeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
