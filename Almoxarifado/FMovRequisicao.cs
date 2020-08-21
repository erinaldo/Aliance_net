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
    public partial class TFMovRequisicao : Form
    {
        public TFMovRequisicao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Requisicao.Buscar(id_requisicao.Text,
                                                                                            cd_empresa.Text,
                                                                                            cd_produto.Text,
                                                                                            cd_requisitante.Text,
                                                                                            string.Empty,
                                                                                            dt_ini.Text,
                                                                                            dt_fin.Text,
                                                                                            string.Empty,
                                                                                            false,
                                                                                            false,
                                                                                            false,
                                                                                            "'I'",
                                                                                            true,
                                                                                            null);
        }

        private void TFMovRequisicao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRequisicao);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_consumointerno, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_consumointerno, 'N')|=|'S'");
        }

        private void cd_requisitante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_requisitante.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                            "and isnull(x.st_requisitar, 'N') = 'S' " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_requisitante },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_requisitante_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                            "and isnull(x.st_requisitar, 'N') = 'S' " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_requisitante }, vParam);
        }

        private void gRequisicao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRequisicao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsRequisicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Compra.Lancamento.TRegistro_Requisicao());
            CamadaDados.Compra.Lancamento.TList_Requisicao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Sort(lComparer);
            bsRequisicao.ResetBindings(false);
            gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFMovRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gRequisicao_DoubleClick(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
                using (TFRetRequisicao fRet = new TFRetRequisicao())
                {
                    fRet.Saldo_retirar = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Sd_retirar_almox;
                    fRet.Cd_empresa = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa;
                    fRet.Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto;
                    if(fRet.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(
                                new CamadaDados.Almoxarifado.TRegistro_Movimentacao()
                                {
                                    Cd_empresa = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                    Id_almox = fRet.Id_almox,
                                    Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto,
                                    Dt_movimento = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_movimento = "S",
                                    Quantidade = fRet.Qtd_retirar,
                                    St_registro = "A",
                                    Ds_observacao = "RETIRADA PRODUTO PELA REQUISICAO Nº" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                    rRequisicao = new CamadaDados.Almoxarifado.TRegistro_Mov_X_Requisicao()
                                    {
                                        Id_requisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao
                                    }
                                }, null);
                            MessageBox.Show("Movimentação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void TFMovRequisicao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRequisicao);
        }
    }
}
