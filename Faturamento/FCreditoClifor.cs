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
    public partial class TFCreditoClifor : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_CreditoClifor rcred;
        public CamadaDados.Faturamento.PDV.TRegistro_CreditoClifor rCred
        {
            get
            {
                if (bsCreditoClifor.Current != null)
                    return bsCreditoClifor.Current as CamadaDados.Faturamento.PDV.TRegistro_CreditoClifor;
                else
                    return null;
            }
            set { rcred = value; }
        }

        public TFCreditoClifor()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCreditoClifor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcred != null)
            {
                bsCreditoClifor.DataSource = new CamadaDados.Faturamento.PDV.TList_CreditoClifor() { rcred };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_clifor.Focus();
            }
            else
            {
                bsCreditoClifor.AddNew();
                cd_empresa.Focus();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCreditoClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
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

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|200;a.cd_endereco|Cd. Endereço|80",
                                            new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(),
                                            "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "';" +
                                              "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cd_endereco_Enter(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_clifor.Text)) && string.IsNullOrEmpty(cd_endereco.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                    }
                                }, "a.cd_endereco");
                if (obj != null)
                    cd_endereco.Text = obj.ToString();
            }
        }
    }
}
