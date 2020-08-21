using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFDadosBanc : Form
    {
        private TRegistro_CadDados_Bancarios_Clifor rdados;
        public TRegistro_CadDados_Bancarios_Clifor rDados
        {
            get
            {
                if (bsDados.Current != null)
                    return bsDados.Current as TRegistro_CadDados_Bancarios_Clifor;
                else
                    return null;
            }
            set { rdados = value; }
        }

        public TFDadosBanc()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("CONTA CORRENTE", "0"));
            cbx.Add(new Utils.TDataCombo("POUPANÇA", "1"));

            cbTpConta.DataSource = cbx;
            cbTpConta.DisplayMember = "Display";
            cbTpConta.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pnl_Dados_Bancarios.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFDadosBanc_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Dados_Bancarios.set_FormatZero();
            if (rdados != null)
                bsDados.DataSource = new TList_CadDados_Bancarios_Clifor() { rdados };
            else
                bsDados.AddNew();
            CD_Banco.Focus();
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("Ds_Banco|Nome Banco|200;CD_Banco|Cód. Banco|100",
                               new Componentes.EditDefault[] { CD_Banco, Ds_Banco }, new TCD_CadBanco(), string.Empty);
        }

        private void CD_Banco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Banco|=|'" + CD_Banco.Text + "'",
                new Componentes.EditDefault[] { CD_Banco, Ds_Banco }, new TCD_CadBanco());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFDadosBanc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
