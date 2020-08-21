using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Diversos;

namespace Parametros.Diversos
{
    public partial class TFLojaVirtual : Form
    {
        private TRegistro_LojaVirtual _loja;

        public TRegistro_LojaVirtual Loja
        {
            get
            {
                if (bsLojaVirtual.Current != null)
                    return bsLojaVirtual.Current as TRegistro_LojaVirtual;
                else return null;
            }
            set { _loja = value; }
        }

        public TFLojaVirtual()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(string.IsNullOrEmpty(nm_loja.Text))
            {
                MessageBox.Show("Obrigatório informar nome loja.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_loja.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFLojaVirtual_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
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
            userName.CharacterCasing = CharacterCasing.Normal;
            apiKey.CharacterCasing = CharacterCasing.Normal;
            if (_loja != null)
            {
                bsLojaVirtual.DataSource = new TList_LojaVirtual { _loja };
                cbEmpresa.Enabled = false;
                nm_loja.Focus();
            }
            else bsLojaVirtual.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLojaVirtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
