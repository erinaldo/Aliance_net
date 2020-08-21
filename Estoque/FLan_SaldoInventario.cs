using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;

namespace Estoque
{
    public partial class TFLan_SaldoInventario : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_SaldoInventario()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (bsItem.Current != null)
            {
                decimal id_inventario = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Id_inventario;
                bsItem.Clear();
                bsItem.DataSource = TCN_Inventario_Item_X_Saldo.Buscar(id_inventario, "", "", 0, "", null);
            }
        }

        private void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = bsItem;
                Rel.Nome_Relatorio = "REST_SaldoInventario";
                Rel.NM_Classe = "REST_SaldoInventario";
                Rel.Modulo = string.Empty;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO SALDO INVENTARIO";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO SALDO ESTOQUE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO SALDO ESTOQUE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }

        private void proximoControle(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Local|Local Armazenagem|250;" +
                              "a.CD_Local|CD. Local|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), string.Empty);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Local|=|'" + cd_local.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void cd_local_KeyUp(object sender, KeyEventArgs e)
        {
            this.proximoControle(sender, e);
        }

        private void bb_local_KeyUp(object sender, KeyEventArgs e)
        {
            this.proximoControle(sender, e);
        }

        private void qtd_contadaEditFloat_KeyUp(object sender, KeyEventArgs e)
        {
            this.proximoControle(sender, e);
        }

        private void vl_unitarioEditFloat_KeyUp(object sender, KeyEventArgs e)
        {
            this.proximoControle(sender, e);
        }

        private void TFLan_SaldoInventario_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }

        private void bsItem_PositionChanged(object sender, EventArgs e)
        {
            if (bsItem.Current != null)
            {
                //Buscar saldo
                decimal saldo = 0;
                TCN_LanEstoque.SaldoEstoqueLocal((bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Cd_empresa,
                                             (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Cd_produto,
                                             (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Cd_local,
                                             ref saldo, null);
                (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Qtd_saldo = saldo;

                //Buscar Vl Medio
                decimal vl_medio = 0;
                TCN_LanEstoque.VlMedioEstoque((bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Cd_empresa,
                                              (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Cd_produto,
                                              ref vl_medio);
                (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Vl_unitario = vl_medio;
                cd_local.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
                bb_local.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
                qtd_contadaEditFloat.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
                BB_GravarItem.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
                BB_Excluir.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
                vl_unitarioEditFloat.Enabled = (bsItem.Current as TRegistro_Inventario_Item_X_Saldo).St_registro.Trim().ToUpper().Equals("A");
            }
        }

        private void lSaldoItemDataGridDefault_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 9)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = lSaldoItemDataGridDefault.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;

                    }
                }
        }

        //Botoes novos
        private void BB_GravarItem_Click(object sender, EventArgs e)
        {
            if (bsItem.Current != null)
            {
                if (cd_local.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório Informar Local de Armazanagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_local.Focus();
                    return;
                }
                if (qtd_contadaEditFloat.Value.Equals(0))
                {
                    if (!(MessageBox.Show("Gravar item com quantidade igual a zero?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes))
                    {
                        qtd_contadaEditFloat.Focus();
                        return;
                    }
                }
                if (vl_unitarioEditFloat.Value.Equals(0))
                {
                    MessageBox.Show("Obrigatório Informar Valor Unitário!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_unitarioEditFloat.Focus();
                    return;
                }
                if (TCN_Inventario_Item_X_Saldo.GravarInventarioItemSaldo(bsItem.Current as TRegistro_Inventario_Item_X_Saldo, null).Trim() != string.Empty)
                {
                    bsItem.MoveNext();
                    cd_local.Focus();
                    
                }
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bsItem.Current != null)
                if (MessageBox.Show("Confirma Exclusão do Item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    if (TCN_Inventario_Item_X_Saldo.DeletarInventarioItemSaldo((bsItem.Current as TRegistro_Inventario_Item_X_Saldo), null).Trim() != "")
                        afterBusca();
        }

        private void BB_ImprimirInv_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void BB_ProcessarInv_Click(object sender, EventArgs e)
        {
            if (bsItem.Count > 0)
                if (MessageBox.Show("Confirma o processamento do Inventario?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    if (TCN_Inventario_Item_X_Saldo.ProcessarInventario((bsItem.Current as TRegistro_Inventario_Item_X_Saldo).Id_inventario, null).Trim() != "")
                    {
                        MessageBox.Show("Inventario Processado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }

        }

        private void TFLan_SaldoInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4) && BB_GravarItem.Enabled)
                 BB_GravarItem_Click(sender, e);
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Enabled)
                BB_Excluir_Click(sender, e);
            else if (e.KeyCode.Equals(Keys.F8) && BB_ImprimirInv.Enabled)
                BB_ImprimirInv_Click(sender, e);
            else if (e.KeyCode.Equals(Keys.F9) && BB_ProcessarInv.Enabled)
                BB_ProcessarInv_Click(sender, e);
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alteração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (bsItem.Count > 0)
            {
                int i = (bsItem.DataSource as TList_Inventario_Item_X_Saldo).FindIndex(p => p.Cd_produto.Trim().Equals(cd_produto.Text.Trim()));
                if (i < 0)
                {
                    MessageBox.Show("Item não existe na lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsItem.Position = 0;
                }
                else
                    bsItem.Position = i;
            }
        }
    }
}
