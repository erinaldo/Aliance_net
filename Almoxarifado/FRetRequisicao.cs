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
    public partial class TFRetRequisicao : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal Saldo_retirar
        { get; set; }

        public decimal? Id_almox
        {
            get
            {
                if (bsSaldoAlmox.Current != null)
                    return (bsSaldoAlmox.Current as CamadaDados.Almoxarifado.TRegistro_SaldoAlmoxarifado).Id_almox;
                else
                    return null;
            }
        }
        public decimal Qtd_retirar
        { get { return qtd_retirar.Value; } }

        public TFRetRequisicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsSaldoAlmox.Current == null)
            {
                MessageBox.Show("Obrigatorio informar almoxarifado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (qtd_retirar.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade retirar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qtd_retirar.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFRetRequisicao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gSaldoAlmox);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar almoxarifados com saldo
            bsSaldoAlmox.DataSource = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Buscar(Cd_empresa,
                                                                                              string.Empty,
                                                                                              Cd_produto,
                                                                                              true,
                                                                                              null);
            saldo_retirar.Value = Saldo_retirar;
            qtd_retirar.Focus();
        }

        private void saldo_almox_ValueChanged(object sender, EventArgs e)
        {
            if (saldo_almox.Value < saldo_retirar.Value)
                qtd_retirar.Value = saldo_almox.Value;
            else
                qtd_retirar.Value = saldo_retirar.Value;
        }

        private void saldo_retirar_ValueChanged(object sender, EventArgs e)
        {
            if (saldo_almox.Value < saldo_retirar.Value)
                qtd_retirar.Value = saldo_almox.Value;
            else
                qtd_retirar.Value = saldo_retirar.Value;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFRetRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFRetRequisicao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gSaldoAlmox);
        }
    }
}
