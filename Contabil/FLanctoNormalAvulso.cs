using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFLanctoNormalAvulso : Form
    {
        public string pCd_empresa
        { get; set; }

        public TFLanctoNormalAvulso()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo val = new CamadaDados.Contabil.TRegistro_Lan_CTB_LanMultiplo();
                    val.Cd_empresa = cd_empresa.Text;
                    val.Dt_lan = dt_lancto.Data;
                    val.Complhistorico = compHistorico.Text;
                    val.Nr_docto = nr_docto.Text;
                    val.lLanctoAvulso.Add(new CamadaDados.Contabil.TRegistro_LanctoAvulso()
                    {
                        Cd_conta_ctbstr = cd_contacred.Text,
                        Vl_lancto = vl_lancto.Value,
                        D_C = "C"
                    });
                    val.lLanctoAvulso.Add(new CamadaDados.Contabil.TRegistro_LanctoAvulso()
                    {
                        Cd_conta_ctbstr = cd_contadeb.Text,
                        Vl_lancto = vl_lancto.Value,
                        D_C = "D"
                    });
                    CamadaNegocio.Contabil.TCN_LanMultiplo.Gravar(val, true, null);
                    MessageBox.Show("Lançamento contabil avulso gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Limpar Campos
                    cd_empresa.Clear();
                    nm_empresa.Clear();
                    cd_contadeb.Clear();
                    ds_contadeb.Clear();
                    classificacaodeb.Clear();
                    cd_contacred.Clear();
                    ds_contacred.Clear();
                    classificacaocred.Clear();
                    dt_lancto.Clear();
                    vl_lancto.Value = vl_lancto.Minimum;
                    nr_docto.Clear();
                    compHistorico.Clear();
                    if (!string.IsNullOrEmpty(pCd_empresa))
                    {
                        cd_empresa.Text = pCd_empresa;
                        cd_empresa_Leave(this, new EventArgs());
                        cd_empresa.Enabled = false;
                        bb_empresa.Enabled = false;
                    }
                    cd_contadeb.Focus();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void TFLanctoNormalAvulso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            compHistorico.CharacterCasing = CharacterCasing.Normal;
            if (!string.IsNullOrEmpty(pCd_empresa))
            {
                cd_empresa.Text = pCd_empresa;
                cd_empresa_Leave(this, new EventArgs());
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_contadeb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contadeb.Text = rConta.Cd_conta_ctbstr;
                ds_contadeb.Text = rConta.Ds_contactb.Trim();
                classificacaodeb.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contadeb_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_ctb|=|" + cd_contadeb.Text + ";" +
                            "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contadeb, ds_contadeb, classificacaodeb },
                                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_contacred.Text = rConta.Cd_conta_ctbstr;
                ds_contacred.Text = rConta.Ds_contactb.Trim();
                classificacaocred.Text = rConta.Cd_classificacao;
            }
        }

        private void cd_contacred_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_ctb|=|" + cd_contacred.Text + ";" +
                            "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contacred, ds_contacred, classificacaocred },
                                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanctoNormalAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
