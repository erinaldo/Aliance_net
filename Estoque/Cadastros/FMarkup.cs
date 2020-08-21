using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFMarkup : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_Markup rmarkup;
        public CamadaDados.Estoque.Cadastros.TRegistro_Markup rMarkup
        {
            get
            {
                if (bsMarkup.Current != null)
                    return bsMarkup.Current as CamadaDados.Estoque.Cadastros.TRegistro_Markup;
                else
                    return null;
            }
            set { rmarkup = value; }
        }

        public TFMarkup()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DIVISOR", "D"));
            cbx.Add(new Utils.TDataCombo("MULTIPLICADOR", "M"));
            tp_markup.DataSource = cbx;
            tp_markup.DisplayMember = "Display";
            tp_markup.ValueMember = "Value";
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

        private void TFMarkup_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            if (rmarkup != null)
            {
                bsMarkup.DataSource = new CamadaDados.Estoque.Cadastros.TList_Markup() { rmarkup };
                cbEmpresa.Enabled = false;
                ds_markup.Focus();
            }
            else
                bsMarkup.AddNew();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFMarkup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
