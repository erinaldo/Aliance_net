using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compra
{
    public partial class TFListaPed : Form
    {
        public string pCd_empresa
        { get; set; }
        public string Cfg_pedido
        {
            get
            {
                if (bsCfgPedido.Count > 0)
                    return (bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Find(p => p.St_processar).Cfg_pedido;
                else return string.Empty;
            }
        }

        public TFListaPed()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsCfgPedido.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração para gerar pedido compra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Exists(p => p.St_processar))
            {
                MessageBox.Show("Obrigatório selecionar CONFIG. PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaPed_Load(object sender, EventArgs e)
        {
            //Buscar Pedidos Compra
            bsCfgPedido.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedido.Buscar(string.Empty,
                                                                                                 string.Empty,
                                                                                                 "E",
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 0,
                                                                                                 string.Empty,
                                                                                                 null);
            //Buscar Config Compra Empresa
            CamadaDados.Compra.TList_CFGCompra lCfg = CamadaNegocio.Compra.TCN_CFGCompra.Buscar(pCd_empresa,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                1,
                                                                                                string.Empty,
                                                                                                null);
            if (lCfg.Count > 0 && bsCfgPedido.Count > 0)
                if ((bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Exists(p => p.Cfg_pedido.Trim().Equals(lCfg[0].Cfg_pedidocompra.Trim())))
                {
                    (bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Find(p => p.Cfg_pedido.Trim().Equals(lCfg[0].Cfg_pedidocompra.Trim())).St_processar = true;
                    bsCfgPedido.ResetBindings(true);
                }
        }

        private void gCfgPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).St_processar)
                    (bsCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).St_processar = false;
                else
                {
                    if((bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Exists(p=> p.St_processar))
                        (bsCfgPedido.List as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).Find(p => p.St_processar).St_processar = false;
                    (bsCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).St_processar = true;
                }
                bsCfgPedido.ResetBindings(true);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFListaPed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
