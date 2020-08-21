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
    public partial class TFCartaFrete : Form
    {
        private CamadaDados.Frota.TRegistro_CartaFrete rcarta;
        public CamadaDados.Frota.TRegistro_CartaFrete rCarta
        {
            get
            {
                if (bsCartaCorrecao.Current != null)
                    return bsCartaCorrecao.Current as CamadaDados.Frota.TRegistro_CartaFrete;
                else
                    return null;
            }
            set { rcarta = value; }
        }

        public TFCartaFrete()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCartaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rcarta != null)
            {
                bsCartaCorrecao.DataSource = new CamadaDados.Frota.TList_CartaFrete() { rcarta };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                vl_documento.Enabled = !rcarta.Id_acerto.HasValue;
            }
            else
                bsCartaCorrecao.AddNew();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_motorista.Text))
                vParam += ";|exists|(select 1 from tb_frt_viagem x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.id_viagem = " + cd_motorista.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_motorista.Text))
                vParam = "|exists|(select 1 from tb_frt_viagem x " +
                         "          where x.cd_empresa = a.cd_empresa " +
                         "          and x.id_viagem = " + cd_motorista.Text + ")";
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, vParam);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, nm_motorista }, "isnull(a.st_motorista, 'N')|=|'S';isnull(a.ST_AtivoMot, 'N')|=|'S'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                                                    "isnull(a.st_motorista, 'N')|=|'S';" +
                                                    "isnull(a.ST_AtivoMot, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
