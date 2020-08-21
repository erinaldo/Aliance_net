using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFImpostosReterFixacao : Form
    {
        private CamadaDados.Graos.TRegistro_ImpostosReterFixacao rimp;
        public CamadaDados.Graos.TRegistro_ImpostosReterFixacao rImp
        {
            get
            {
                if (bsImpostosReterFixacao.Current != null)
                    return bsImpostosReterFixacao.Current as CamadaDados.Graos.TRegistro_ImpostosReterFixacao;
                else
                    return null;
            }
            set { rimp = value; }
        }

        public TFImpostosReterFixacao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_aliquota.Focused)
                {
                    (bsImpostosReterFixacao.Current as CamadaDados.Graos.TRegistro_ImpostosReterFixacao).Pc_aliquota = pc_aliquota.Value;
                    bsImpostosReterFixacao.ResetCurrentItem();
                }
                if (pc_reducaobasecalc.Focused)
                {
                    (bsImpostosReterFixacao.Current as CamadaDados.Graos.TRegistro_ImpostosReterFixacao).Pc_reducaobasecalc = pc_reducaobasecalc.Value;
                    bsImpostosReterFixacao.ResetCurrentItem();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFImpostosReterFixacao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rimp != null)
            {
                bsImpostosReterFixacao.DataSource = new CamadaDados.Graos.TList_ImpostosReterFixacao() { rimp };
                cd_imposto.Enabled = false;
                bb_imposto.Enabled = false;
            }
            else
                bsImpostosReterFixacao.AddNew();
            if (!cd_imposto.Focus())
                pc_aliquota.Focus();
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.cd_imposto|Cd. Imposto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void TFImpostosReterFixacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
