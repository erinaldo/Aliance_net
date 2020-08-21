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
    public partial class TFItemCompraXOS : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Id_compra
        { get; set; }

        public TFItemCompraXOS()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsItensCompra.DataSource = CamadaNegocio.Faturamento.CompraAvulsa.TCN_Compra_Itens.Buscar(Cd_empresa,
                                                                                                      Id_compra,
                                                                                                      null);
            bsItensCompra_PositionChanged(this, new EventArgs());
        }

        private void ExcluirItem()
        {
            if(bsItemOs.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.CompraAvulsa.TCN_CompraItens_X_PecaOS.Excluir((bsItemOs.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraItens_X_PecaOS), null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BuscarItemOS()
        {
            if((bsItensCompra.Current != null) &&
                (!string.IsNullOrEmpty(id_os.Text)))
            {
                CamadaDados.Servicos.TList_LanServicosPecas lPeca =
                    new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = id_os.Text
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "(a.cd_produto is null or a.cd_produto = '" + (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Cd_produto.Trim() + "')"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Quantidade - a.Qtd_Compra",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, 0, string.Empty, string.Empty);
                if (lPeca.Count > 0)
                {
                    id_peca.Text = lPeca[0].Id_pecastr;
                    ds_peca.Text = lPeca[0].Ds_produto;
                    sd_peca.Value = lPeca[0].SD_Compra;
                }
            }
        }

        private void TFItemCompraXOS_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, gItensCompra);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void bsItensCompra_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensCompra.Current != null)
            {
                (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).lItemOs =
                    CamadaNegocio.Faturamento.CompraAvulsa.TCN_CompraItens_X_PecaOS.Buscar((bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Cd_empresa,
                                                                                           (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Id_comprastr,
                                                                                           (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Id_itemcomprastr,
                                                                                           null);
                bsItensCompra.ResetCurrentItem();
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void bb_os_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_os|Nº OS|60;" +
                              "a.nm_clifor|Nome Cliente|200";
            string vParam = "a.cd_empresa|=|'" + Cd_empresa.Trim() + "'";
            if(bsItensCompra.Current != null)
                vParam += ";|exists|(select 1 from vtb_ose_pecas x " +
                          "           where x.cd_empresa = a.cd_empresa " +
                          "           and x.id_os = a.id_os " +
                          "           and x.quantidade - x.qtd_compra > 0 " +
                          "           and (x.cd_produto is null or x.cd_produto = '" + (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Cd_produto.Trim() + "'))";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_os },
                                            new CamadaDados.Servicos.TCD_LanServico(), vParam);
            this.BuscarItemOS();
        }

        private void id_os_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + Cd_empresa.Trim() + "';" +
                            "a.id_os|=|" + id_os.Text;
            if(bsItensCompra.Current != null)
                vParam += ";|exists|(select 1 from vtb_ose_pecas x " +
                          "           where x.cd_empresa = a.cd_empresa " +
                          "           and x.id_os = a.id_os " +
                          "           and x.quantidade - x.qtd_compra > 0 " +
                          "           and (x.cd_produto is null or x.cd_produto = '" + (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Cd_produto.Trim() + "'))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_os },
                                            new CamadaDados.Servicos.TCD_LanServico());
            this.BuscarItemOS();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItensCompra.Current != null)
            {
                if (Quantidade.Value > (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).SD_Qtde)
                    Quantidade.Value = (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).SD_Qtde;
                if ((sd_peca.Value > decimal.Zero) && (Quantidade.Value > sd_peca.Value))
                    Quantidade.Value = sd_peca.Value;
            }
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            if (bsItensCompra.Current == null)
            {
                MessageBox.Show("Não existe item compra disponivel para informar na OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(id_os.Text))
            {
                MessageBox.Show("Obrigatorio informar OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_os.Focus();
                return;
            }
            if(string.IsNullOrEmpty(id_peca.Text))
            {
                MessageBox.Show("Peça não se encontra cadastrada para a OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Quantidade.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Quantidade.Focus();
                return;
            }
            try
            {
                (bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).lItemOs.Add(
                    new CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraItens_X_PecaOS()
                    {
                        Id_osstr = id_os.Text,
                        Id_pecastr = id_peca.Text,
                        Quantidade = Quantidade.Value
                    });
                CamadaNegocio.Faturamento.CompraAvulsa.TCN_Compra_Itens.Gravar((bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens), null);
                MessageBox.Show("Peça alocada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_os.Clear();
                id_peca.Clear();
                ds_peca.Clear();
                sd_peca.Value = decimal.Zero;
                Quantidade.Value = decimal.Zero;
                this.afterBusca();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFItemCompraXOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, gItensCompra);
        }
    }
}
