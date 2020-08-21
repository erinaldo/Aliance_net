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
    public partial class TFAlocacaoItemAlmox : Form
    {
        public TFAlocacaoItemAlmox()
        {
            InitializeComponent();
        }

        private void BuscarPedido()
        {
            if (!string.IsNullOrEmpty(nr_pedido.Text))
            {
                CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                    new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = nr_pedido.Text
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "c.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_pedido, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'F'"
                        }
                    }, 1, string.Empty);
                if (lPed.Count > 0)
                {
                    cd_empresa.Text = lPed[0].CD_Empresa;
                    nm_empresa.Text = lPed[0].Nm_Empresa;
                    cd_clifor.Text = lPed[0].CD_Clifor;
                    nm_clifor.Text = lPed[0].NM_Clifor;
                    //Buscar Itens do Pedido
                    bsItensPedido.DataSource = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_pedido",
                                                        vOperador = "=",
                                                        vVL_Busca = lPed[0].Nr_pedido.ToString()
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(tpProd.st_consumointerno, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'S'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                    bsItensPedido_PositionChanged(this, new EventArgs());
                }
                else
                    nr_pedido.Clear();
            }
        }

        private void AlocarItem()
        {
            if (bsItensPedido.Current != null)
                if((bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Qtd_conferida.Equals(decimal.Zero))
                    using (Proc_Commoditties.TFAlocarItem fAloc = new Proc_Commoditties.TFAlocarItem())
                    {
                        fAloc.Cd_empresa = cd_empresa.Text;
                        fAloc.Cd_produto = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto;
                        fAloc.Ds_produto = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Ds_produto;
                        fAloc.Sigla_unidade = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Sg_unidade_est;
                        if(fAloc.ShowDialog() == DialogResult.OK)
                            try
                            {
                                CamadaNegocio.Almoxarifado.TCN_AlocacaoItem.AlocarItem(
                                    new CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido()
                                    {
                                        Nr_pedido = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Nr_pedido,
                                        Cd_produto = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto,
                                        Id_pedidoitem = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Id_pedidoitem,
                                        Login = Utils.Parametros.pubLogin,
                                        Qtd_entregue = fAloc.Quantidade,
                                        Dt_entrega = CamadaDados.UtilData.Data_Servidor(),
                                        Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA ALOCACAO ITEM NO ALMOXARIFADO",
                                        Id_almoxstr = fAloc.Id_almox,
                                        St_registro = "P"
                                    }
                                    , null);
                                MessageBox.Show("Item alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Qtd_conferida = fAloc.Quantidade;
                                bsItensPedido_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
        }

        private void ExcluirAlocacao()
        {
            if (bsItensPedido.Current != null)
                if ((bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).EntregaPedido.Count > 0)
                {
                    if (MessageBox.Show("Confirma cancelamento da alocação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Almoxarifado.TCN_AlocacaoItem.Excluir(new CamadaDados.Almoxarifado.TRegistro_AlocacaoItem()
                            {
                                Id_almox = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).EntregaPedido[0].Id_almox,
                                Id_entrega = (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).EntregaPedido[0].Id_entrega
                            }, null);
                            MessageBox.Show("Alocação item cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Qtd_conferida = decimal.Zero;
                            bsItensPedido_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Item não possui alocação para ser cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Obrigatorio selecionar item para cancelar alocação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFAlocacaoItemAlmox_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPedidoItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bb_cancelar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                               "PERMITIR CANCELAR MOVIMENTACAO",
                                                                                               null);
            nr_pedido.Focus();
        }

        private void bsItensPedido_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensPedido.Current != null)
            {
                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).EntregaPedido =
                    CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Busca(string.Empty,
                                                                                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Nr_pedido.ToString(),
                                                                                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto,
                                                                                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Id_pedidoitem.ToString(),
                                                                                false,
                                                                                string.Empty,
                                                                                null);
                bsItensPedido.ResetCurrentItem();
            }
        }

        private void nr_pedido_Leave(object sender, EventArgs e)
        {
            this.BuscarPedido();
        }

        private void nr_pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.BuscarPedido();
        }

        private void bb_alocar_Click(object sender, EventArgs e)
        {
            this.AlocarItem();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.ExcluirAlocacao();
        }

        private void TFAlocacaoItemAlmox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.F2))
                this.AlocarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                this.ExcluirAlocacao();
        }

        private void TFAlocacaoItemAlmox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPedidoItens);
        }

        private void gPedidoItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
