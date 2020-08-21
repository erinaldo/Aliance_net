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
    public partial class TFRecalcCoo : Form
    {
        public string pCd_empresa
        { get { return cd_empresa.Text; } }
        public string pId_equipamento
        { get { return id_equipamento.Text; } }
        public string pDt_ini
        { get { return dt_ini.Text; } }
        public string pDt_fin
        { get { return dt_fin.Text; } }

        public TFRecalcCoo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFRecalcCoo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
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

        private void bb_equipamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_equipamento|ECF|150;" +
                              "a.id_equipamento|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_equipamento, ds_equipamento },
                new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void id_equipamento_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_equipamento|=|" + id_equipamento.Text + ";isnull(a.st_registro, 'A')|<>|'C'",
                new Componentes.EditDefault[] { id_equipamento, ds_equipamento }, new CamadaDados.Faturamento.Cadastros.TCD_EmissorCF());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFRecalcCoo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
