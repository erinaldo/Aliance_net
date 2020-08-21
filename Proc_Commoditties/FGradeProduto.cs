using System;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using System.Collections.Generic;

namespace Proc_Commoditties
{
    public partial class TFGradeProduto : Form
    {
        public string pCd_empresa { get; set; } = string.Empty;
        public string pCd_produto { get; set; } = string.Empty;
        public string pDs_produto { get; set; } = string.Empty;
        public string pId_caracteristica { get; set; } = string.Empty;
        public string pTp_movimento { get; set; } = string.Empty;
        public decimal pQuantidade { get; set; } = decimal.Zero;
        public List<TRegistro_ValorCaracteristica> lGrade
        { get { return (bsValorGrade.List as List<TRegistro_ValorCaracteristica>).FindAll(p => p.Vl_mov > decimal.Zero); } }
        
        public TFGradeProduto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            gGrade.EndEdit();
            if(pQuantidade - (bsValorGrade.List as List<TRegistro_ValorCaracteristica>).Sum(p=> p.Vl_mov) > decimal.Zero)
            {
                MessageBox.Show("Obrigatório alocar toda quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFGradeProduto_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if(pTp_movimento.Trim().ToUpper().Equals("E"))
                bsValorGrade.DataSource = new TCD_ValorCaracteristica().Select(pId_caracteristica, pCd_empresa, pCd_produto);
            else bsValorGrade.DataSource = new TCD_ValorCaracteristica().Select(pId_caracteristica, pCd_empresa, pCd_produto).Where(p => p.SaldoEst > decimal.Zero).ToList();
            bsValorGrade.ResetCurrentItem();
            saldo_mov.Text = string.Format(pQuantidade.ToString(), "{0:N3}");
            if(bsValorGrade.Count > 0)
                gGrade.CurrentCell = gGrade.Rows[0].Cells[2];
            lblProduto.Text = pCd_produto.Trim() + "-" + pDs_produto.Trim() + " - " + (pTp_movimento.ToUpper().Trim().Equals("E") ? "ENTRADA" : "SAÍDA");
        }

        private void gGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gGrade.EndEdit();
        }

        private void gGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(pTp_movimento.Trim().ToUpper().Equals("S"))
                if(decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()) > decimal.Parse(gGrade[e.ColumnIndex - 1, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("Saldo Insuficiente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
                    gGrade.EndEdit();
                }
            if (pQuantidade == decimal.Zero ? false : pQuantidade - (bsValorGrade.List as List<TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov) + decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()) < decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                MessageBox.Show("valor infomado não pode ser maior que saldo movimento disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
                gGrade.EndEdit();
            }
            tot_mov.Text = string.Format((bsValorGrade.List as List<TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov).ToString(), "{0:N3}");
            saldo_mov.Text = string.Format((pQuantidade - (bsValorGrade.List as List<TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov)).ToString(), "{0:N3}");
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFGradeProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void gGrade_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
