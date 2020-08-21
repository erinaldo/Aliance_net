using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Almoxarifado
{
    public partial class TFSaldoAlmoxCusto : Form
    {
        private string pCd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Text; } set { pCd_empresa = value; } }

        public string Id_almox
        { get { return id_almox.Text; } }

        public decimal Quantidade
        { get { return quantidade.Value; } }

        public decimal Vl_unitario
        { get { return vl_unitario.Value; } }
        public TFSaldoAlmoxCusto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(id_almox.Text))
            {
                MessageBox.Show("Obrigatório informar Almoxarifado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_almox.Focus();
                return;
            }
            if (quantidade.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if (vl_unitario.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar valor custo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_unitario.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarAlmoxarifado()
        {
            //Buscar Almoxarifado
            CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                    "where x.id_almox = a.id_almox " +
                                    "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                    }
                }, 0, string.Empty);
            if (lAlmox.Count == 1)
            {
                id_almox.Text = lAlmox[0].Id_almoxString;
                ds_almox.Text = lAlmox[0].Ds_almoxarifado;
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava(); 
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            this.BuscarAlmoxarifado();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            this.BuscarAlmoxarifado();
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text + ";" +
                            "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almox },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            string vParam = "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almox },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), vParam);
        }

        private void TFSaldoAlmoxCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFSaldoAlmoxCusto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pSaldoAlmox.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            cd_empresa_Leave(this, new EventArgs());
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }
    }
}
