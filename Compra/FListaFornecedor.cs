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
    public partial class TFListaFornecedor : Form
    {
        public decimal Qtd_negociacao
        { get; set; }

        public bool St_requisicao
        { get; set; }

        public CamadaDados.Compra.Lancamento.TList_NegociacaoItem lItens
        {
            get;
            set;
        }

        public TFListaFornecedor()
        {
            InitializeComponent();
            this.Qtd_negociacao = decimal.Zero;
            this.St_requisicao = false;
        }

        private void afterGrava()
        {
            if (this.Qtd_negociacao > 0)
            {
                if (lItens.Select(p => p.St_processar).Count() < this.Qtd_negociacao)
                {
                    if (MessageBox.Show("Configuração de compras exige no minimo " + this.Qtd_negociacao.ToString() + " negociações.\r\n" +
                                    "A requisição será gravada sem utilizar nenhuma negociação e ficara aguardando cotação.\r\n" +
                                    "Confirma operação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        this.DialogResult = DialogResult.Cancel;
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar =
                    !(bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar;
        }

        private void TFListaFornecedor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            pMotivo.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItens.DataSource = lItens;
            ds_motivoaprovarreprovar.Enabled = !this.St_requisicao;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFListaFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gItens_DoubleClick(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                using (TFNegociacaoFornec fNegFornec = new TFNegociacaoFornec())
                {
                    fNegFornec.St_detalhe = true;
                    fNegFornec.rNegItem = (bsItens.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem);
                    fNegFornec.ShowDialog();
                }
            }
        }

        private void TFListaFornecedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
