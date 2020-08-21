using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFIntervencaoTecECF : Form
    {
        private CamadaDados.Faturamento.Cadastros.TRegistro_IntervencaoTec rintervencao;
        public CamadaDados.Faturamento.Cadastros.TRegistro_IntervencaoTec rIntervencao
        {
            get
            {
                if (bsIntervencao.Current != null)
                    return bsIntervencao.Current as CamadaDados.Faturamento.Cadastros.TRegistro_IntervencaoTec;
                else
                    return null;
            }
            set { rintervencao = value; }
        }

        public TFIntervencaoTecECF()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFIntervencaoTecECF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rintervencao != null)
            {
                bsIntervencao.DataSource = new CamadaDados.Faturamento.Cadastros.TList_IntervencaoTec() { rintervencao };
                id_equipamento.Enabled = false;
                bb_equipamento.Enabled = false;
                motivo_intervencao.Focus();
            }
            else
                bsIntervencao.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFIntervencaoTecECF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_equipamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_equipamento|ECF|200;" +
                              "a.id_equipamento|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_equipamento, ds_equipamento },
                                             new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void id_equipamento_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_equipamento|=|" + id_equipamento.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_equipamento, ds_equipamento },
                                                new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF());
        }
    }
}
