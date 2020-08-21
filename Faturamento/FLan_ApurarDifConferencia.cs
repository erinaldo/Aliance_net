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
    public partial class TFLan_ApurarDifConferencia : Form
    {
        public TFLan_ApurarDifConferencia()
        {
            InitializeComponent();
        }

        private void Recontar()
        {
            if (((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_difFatConf > 0) &&
                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_produto)) &&
                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_produto)))
                if ((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).lEntrega.Count > 0)
                {
                    if (MessageBox.Show("Confirma recontagem das conferências do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            string retorno = CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.GravarRecontagem((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).lEntrega, null);
                            MessageBox.Show(retorno.Trim() != string.Empty ? retorno.Trim() : "Recontagem gravada com sucesso para o item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe registro conferência gravado para o item selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLan_ApurarDifConferencia_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEntrega);
            Utils.ShapeGrid.RestoreShape(this, gItens);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void gEntrega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if((bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Quantidade > 
                    (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_totalconferencia)
                        (bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_recontar =
                            !(bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_recontar;
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 4)
                {
                    if (Convert.ToDecimal(e.Value.ToString()) > decimal.Zero)
                    {
                        DataGridViewRow linha = gItens.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gItens.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_recontar_Click(object sender, EventArgs e)
        {
            this.Recontar();
        }

        private void TFLan_ApurarDifConferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.Recontar();
        }

        private void TFLan_ApurarDifConferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEntrega);
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
