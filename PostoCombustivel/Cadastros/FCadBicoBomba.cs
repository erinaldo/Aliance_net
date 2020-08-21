using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadBicoBomba : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        private CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba rbico;
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba rBico
        {
            get
            {
                if (bsBico.Current != null)
                    return bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba;
                else
                    return null;
            }
            set { rbico = value; }
        }

        public TFCadBicoBomba()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("CANCELADO", "C"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadBicoBomba_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rbico != null)
                bsBico.DataSource = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba() { rbico };
            else
            {
                bsBico.AddNew();
                (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Cd_empresa = Cd_empresa;
                (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Nm_empresa = Nm_empresa;
                bsBico.ResetCurrentItem();
            }
        }

        private void bb_tanque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_tanque|Id. Tanque|80;" +
                              "a.cd_produto|Cd. Combustivel|80;" +
                              "e.ds_produto|Combustivel|200";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tanque, cd_produto, ds_produto },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel(), vParam);
        }

        private void id_tanque_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tanque|=|" + id_tanque.Text + ";" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tanque, cd_produto, ds_produto },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel());
        }

        private void TFCadBicoBomba_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void st_registro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (st_registro.SelectedValue == null ? false : st_registro.SelectedValue.ToString().Equals("C"))
            {
                lblDtAtivacao.Visible = false;
                dt_ativacao.Visible = false;
                lblDtDesativacao.Visible = true;
                dt_desativacao.Visible = true;
            }
            else
            {
                lblDtAtivacao.Visible = true;
                dt_ativacao.Visible = true;
                lblDtDesativacao.Visible = false;
                dt_desativacao.Visible = false;
                dt_desativacao.Clear();
            }
        }
    }
}
