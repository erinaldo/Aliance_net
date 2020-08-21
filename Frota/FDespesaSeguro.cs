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
    public partial class TFDespesaSeguro : Form
    {
        public string pCd_empresa
        { get { return cd_empresa.Text; } }
        public string pId_despesa
        { get { return id_despesa.Text; } }
        public decimal Vl_despesa
        { get; set; }

        public TFDespesaSeguro()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFDespesaSeguro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            vl_despesa.Value = Vl_despesa;
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

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'MV'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'MV'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
