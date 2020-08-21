using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFMovLote : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_fornecedor
        { get; set; }
        public string pNm_fornecedor
        { get; set; }
        public string pTp_mov
        { get; set; }
        private List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe> litens;
        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe> lItens
        {
            get
            {
                if (bsItensXMLNFe.Current != null)
                    return bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>;
                else
                    return null;
            }
            set { litens = value; }
        }
        public TFMovLote()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if ((bsItensXMLNFe.DataSource as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).Exists(p => p.Saldo > decimal.Zero))
            {
                MessageBox.Show("Ainda existe saldo para incluir em lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_incluir_Click(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                if (qtd_incluir.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não existe quantidade para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal saldo = pTp_mov.Trim().ToUpper().Equals("E") ? qtd_movimentar.Value - total_movimento.Value :
                    qtd_movimentar.Value - total_movimento.Value > (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo ?
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo : qtd_movimentar.Value - total_movimento.Value;
                if (qtd_incluir.Value > saldo)
                {
                    MessageBox.Show("Quantidade incluir não pode ser maior que saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_incluir.Value = saldo;
                    return;
                }
                (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lMov.Add(new CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade()
                {
                    Cd_empresa = (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Cd_empresa,
                    Id_lote = (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Id_lote,
                    Nr_lote = (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Nr_lote,
                    Tp_mov = pTp_mov,
                    Quantidade = qtd_incluir.Value
                });
                bsItensXMLNFe.ResetCurrentItem();
                if (pTp_mov.Trim().ToUpper().Equals("S"))
                {
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_Saida += qtd_incluir.Value;
                    bsLote.ResetCurrentItem();
                }
                total_movimento.Value += qtd_incluir.Value;
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo ?
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo : tot_saldo.Value;
            }
            else MessageBox.Show("Não existe lote selecionado para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFMovLote_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lblMov.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA";
            lblQtd.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "Qtd. Incluir Lote" : "Qtd. Retirar Lote";
            bsItensXMLNFe.DataSource = litens;
            bsItensXMLNFe_PositionChanged(this, new EventArgs());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bbLocalizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bsLote.Count; i++)
                if ((bsLote[i] as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Nr_lote.Trim().ToUpper().Contains(nr_lote.Text.Trim().ToUpper()))
                    bsLote.Position = i;
        }

        private void bbAddLote_Click(object sender, EventArgs e)
        {
            using (TFNovoLote fLote = new TFNovoLote())
            {
                fLote.pCd_empresa = pCd_empresa;
                fLote.pNm_empresa = pNm_empresa;
                fLote.pCd_produto = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_produto;
                fLote.pDs_produto = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Ds_produto;
                fLote.pCd_fornecedor = pCd_fornecedor;
                fLote.pNm_fornecedor = pNm_fornecedor;
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Producao.Producao.TCN_Rastreabilidade.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lLoteRast.Add(fLote.rLote);
                            bsItensXMLNFe.ResetBindings(true);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAltera_Click(object sender, EventArgs e)
        {
            using (TFNovoLote fLote = new TFNovoLote())
            {
                fLote.rLote = bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade;
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Producao.Producao.TCN_Rastreabilidade.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote Alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lLoteRast =
                                    CamadaNegocio.Producao.Producao.TCN_Rastreabilidade.Buscar(string.Empty,
                                                                                               pCd_empresa,
                                                                                               pCd_fornecedor,
                                                                                               (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Cd_produto,
                                                                                               string.Empty,
                                                                                               null);


                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbExcluiMov_Click(object sender, EventArgs e)
        {
            if (bsMovRastreabilidade.Current != null)
                if (MessageBox.Show("Confirma exclusão do movimento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    total_movimento.Value -= (bsMovRastreabilidade.Current as CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade).Quantidade;
                    //tot_saldo.Value = qtd_movimentar.Value - total_movimento.Value;
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lMov.Remove(bsMovRastreabilidade.Current as CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade);
                    bsMovRastreabilidade.ResetCurrentItem();
                }
        }

        private void qtd_incluir_Leave(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                decimal saldo = pTp_mov.Trim().ToUpper().Equals("E") ? qtd_movimentar.Value - total_movimento.Value :
                    qtd_movimentar.Value - total_movimento.Value > (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo ?
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo : qtd_movimentar.Value - total_movimento.Value;
                if (qtd_incluir.Value > saldo)
                {
                    MessageBox.Show("Quantidade incluir não pode ser maior que saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_incluir.Value = saldo;
                }
            }
        }

        private void TFMovLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bsLote_PositionChanged(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo ?
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo : tot_saldo.Value;
            }
            else
                qtd_incluir.Value = decimal.Zero;
        }

        private void qtd_incluir_Enter(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo ?
                    (bsLote.Current as CamadaDados.Producao.Producao.TRegistro_Rastreabilidade).Qtd_saldo : tot_saldo.Value;
            }
            else
                qtd_incluir.Value = decimal.Zero;
        }

        private void bsItensXMLNFe_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensXMLNFe.Current != null)
            {
                //Buscar Lotes do Produto selecionado
                (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lLoteRast =
                    CamadaNegocio.Producao.Producao.TCN_Rastreabilidade.Buscar(string.Empty,
                                                                               pCd_empresa,
                                                                               pCd_fornecedor,
                                                                               (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_produto,
                                                                               string.Empty,
                                                                               null);

                (bsItensXMLNFe.DataSource as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).ForEach(p => p.Qtd_movimentar = p.Quantidade);
                bsItensXMLNFe.ResetCurrentItem();
            }
        }
    }
}
