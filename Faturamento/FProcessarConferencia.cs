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
    public partial class TFProcessarConferencia : Form
    {
        public string Login
        { get; set; }

        public TFProcessarConferencia()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (!(bsEntregaPedido.DataSource as CamadaDados.Faturamento.Pedido.TList_EntregaPedido).Exists(p => p.St_recontar))
            {
                MessageBox.Show("Não existe conferência marcada para ser processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Pedir autenticacao de um usuario com acesso a fazer conferencia
            using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
            {
                fUser.Ds_regraespecial = "PERMITIR PROCESSAR CONFERENCIA PEDIDO";
                if (fUser.ShowDialog() == DialogResult.OK)
                {
                    this.Login = fUser.Login;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void TFProcessarConferencia_Load(object sender, EventArgs e)
        {

            Utils.ShapeGrid.RestoreShape(this, gConf);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProcessarConferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gConf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if ((bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_registro.Trim().ToUpper().Equals("R"))
                    if ((bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_recontar)
                        (bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_recontar = false;
                    else
                        if ((bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).Qtd_entregue.Equals(decimal.Zero))
                            MessageBox.Show("Não é permitido processar conferência com quantidade contada igual a zero.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            (bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_recontar = true;
                else
                    MessageBox.Show("Conferência ja se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gConf_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 4)
                {
                    if (Convert.ToDecimal(e.Value.ToString()) > 0)
                    {
                        DataGridViewRow linha = gConf.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gConf.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFProcessarConferencia_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utils.ShapeGrid.SaveShape(this, gConf);
        }
    }
}
