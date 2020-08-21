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
    public partial class TFDisponibilidadeEstoque : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item rItemOrc
        { get; set; }
        public CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item rItemPed
        { get; set; }

        public TFDisponibilidadeEstoque()
        {
            InitializeComponent();
        }

        private void Calcular()
        {
            if (rItemOrc != null)
            {
                rItemOrc.Quantidade = qtd_programada.Value;
                CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lItem = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarFichaTecItem(Cd_empresa,
                                                                                     cd_localarm.Text,
                                                                                     rItemOrc,
                                                                                     lItem);
                cSaldoEst.DataPropertyName = "Qtd_saldoestoque";
                cUnd.DataPropertyName = "Sigla_unid_produto";
                bsItens.DataSource = lItem;
            }
            if (rItemPed != null)
            {
                CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItem = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item();
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.MontarFichaTecItem(Cd_empresa,
                                                                               cd_localarm.Text,
                                                                               rItemPed,
                                                                               lItem);
                cSaldoEst.DataPropertyName = "Qtd_estoque";
                cUnd.DataPropertyName = "Sg_unidade_est";
                bsItens.DataSource = lItem;
            }
            bsItens_PositionChanged(this, new EventArgs());
        }

        private void TFDisponibilidadeEstoque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Utils.ShapeGrid.RestoreShape(this, gSaldoLocal);
            Utils.ShapeGrid.RestoreShape(this, gSintetico);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_empresa.Text = Cd_empresa;
            nm_empresa.Text = Nm_empresa;
            cd_produto.Text = rItemOrc != null ? rItemOrc.Cd_produto : rItemPed != null ? rItemPed.Cd_produto : string.Empty;
            ds_produto.Text = rItemOrc != null ? rItemOrc.Ds_produto : rItemPed != null ? rItemPed.Ds_produto : string.Empty;
            qtd_programada.Value = rItemOrc != null ? rItemOrc.Quantidade : rItemPed != null ? rItemPed.Quantidade : decimal.Zero;
            sg_unidade.Text = rItemOrc != null ? rItemOrc.Sigla_unid_produto : rItemPed != null ? rItemPed.Sg_unidade_est : string.Empty;
            //Buscar Local Armazenagem Config orcamento
            CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar(Cd_empresa,
                                                                                                                                    string.Empty,
                                                                                                                                    string.Empty,
                                                                                                                                    null);
            if (lCfg.Count > 0)
            {
                cd_localarm.Text = lCfg[0].Cd_local;
                ds_localarm.Text = lCfg[0].Ds_local;
            }

            this.Calcular();
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("TRUE"))
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                //Buscar Estoque Sintetico por Empresa
                bsSintetico.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintetico(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (rItemOrc != null ? (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim() :
                                                                        (bsItens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Cd_produto.Trim()) + "'"
                                                }
                                            }, string.Empty, string.Empty);
                bsSintetico_PositionChanged(this, new EventArgs());
            }
        }

        private void bb_localarm_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Local|Local Armazenagem|300;a.CD_Local|Código|80"
                , new Componentes.EditDefault[] { cd_localarm, ds_localarm }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text), string.Empty);
        }

        private void cd_localarm_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            FormBusca.UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localarm.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { cd_localarm, ds_localarm },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text));
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_calcula_Click(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void TFDisponibilidadeEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F9))
                this.Calcular();
        }

        private void bsSintetico_PositionChanged(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
            {
                bsSaldoLocal.DataSource = CamadaNegocio.Estoque.TCN_ConsultaProdutos.buscaLocal(
                                            (bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                                            (bsSintetico.Current as DataRowView)["cd_produto"].ToString());
                bsSaldoLocal.ResetBindings(true);
            }
            else
                bsSaldoLocal.Clear();
        }

        private void TFDisponibilidadeEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
            Utils.ShapeGrid.SaveShape(this, gSaldoLocal);
            Utils.ShapeGrid.SaveShape(this, gSintetico);
        }
    }
}
