using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFInscSubstEmpresa : Form
    {
        private CamadaDados.Diversos.TRegistro_InscSubstEmpresa rinsc;
        public CamadaDados.Diversos.TRegistro_InscSubstEmpresa rInsc
        {
            get
            {
                if (bsSubst.Current != null)
                    return bsSubst.Current as CamadaDados.Diversos.TRegistro_InscSubstEmpresa;
                else return null;
            }
            set { rinsc = value; }
        }

        public TFInscSubstEmpresa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
            {
                if(insc_estadual_subst.Focused)
                    if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                    {
                        string pInsc_estadual_subst = insc_estadual_subst.Text.SoNumero();
                        if (string.IsNullOrEmpty(pInsc_estadual_subst))
                            return;
                        try
                        {
                            if (CamadaNegocio.Diversos.TValidaInscEstadual.ValidaInscEstadual(pInsc_estadual_subst.Trim(), uf.Text.Trim()) == 1)
                            {
                                MessageBox.Show("Inscrição estadual Substituição Tributaria incorreta para o estado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                insc_estadual_subst.Clear();
                                insc_estadual_subst.Focus();
                                return;
                            }
                        }
                        catch { }
                    }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFInscSubstEmpresa_Load(object sender, EventArgs e)
        {
            this.pDados.set_FormatZero();
            if (rinsc != null)
            {
                bsSubst.DataSource = new CamadaDados.Diversos.TList_InscSubstEmpresa() { rinsc };
                cd_uf.Enabled = false;
                bb_uf.Enabled = false;
                insc_estadual_subst.Focus();
            }
            else
            {
                bsSubst.AddNew();
                cd_uf.Focus();
            }
        }

        private void bb_uf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|150;" +
                              "a.cd_uf|Codigo|50;" +
                              "a.uf|Sigla|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_uf, ds_uf, uf },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_uf_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_uf|=|'" + cd_uf.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_uf, ds_uf, uf },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFInscSubstEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void insc_estadual_subst_Leave(object sender, EventArgs e)
        {
            if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
            {
                string pInsc_estadual_subst = insc_estadual_subst.Text.SoNumero();
                if (string.IsNullOrEmpty(pInsc_estadual_subst))
                    return;
                try
                {
                    if (string.IsNullOrEmpty(cd_uf.Text))
                    {
                        MessageBox.Show("Obrigatorio informar UF para validar inscrição estadual", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        insc_estadual_subst.Clear();
                        cd_uf.Focus();
                        return;
                    }
                    if (CamadaNegocio.Diversos.TValidaInscEstadual.ValidaInscEstadual(pInsc_estadual_subst.Trim(), uf.Text.Trim()) == 1)
                    {
                        MessageBox.Show("Inscrição estadual Substituição Tributaria incorreta para o estado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        insc_estadual_subst.Clear();
                        insc_estadual_subst.Focus();
                        return;
                    }
                }
                catch { }
            }
        }
    }
}
