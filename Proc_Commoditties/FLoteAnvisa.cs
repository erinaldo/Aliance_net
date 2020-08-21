using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFLoteAnvisa : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pCd_fornecedor
        { get; set; }
        public string pNm_fornecedor
        { get; set; }
        public string pTp_mov
        { get; set; }
        public decimal pQtd_movimentar
        { get; set; }

        public CamadaDados.Faturamento.LoteAnvisa.TList_MovLoteAnvisa lMov
        {
            get
            {
                if (bsMovLoteAnvisa.Count > 0)
                {
                    CamadaDados.Faturamento.LoteAnvisa.TList_MovLoteAnvisa lmov = new CamadaDados.Faturamento.LoteAnvisa.TList_MovLoteAnvisa();
                    foreach (CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa rmov in bsMovLoteAnvisa.List)
                        lmov.Add(rmov);
                    return lmov;
                }
                else return null;
            }
        }

        public TFLoteAnvisa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (tot_saldo.Value > decimal.Zero)
            {
                MessageBox.Show("Ainda existe saldo para incluir em lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }


        private void bbExcluiMov_Click(object sender, EventArgs e)
        {
            if (bsMovLoteAnvisa.Current != null)
                if (MessageBox.Show("Confirma exclusão do movimento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    total_movimento.Value -= (bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Quantidade;
                    tot_saldo.Value = qtd_movimentar.Value - total_movimento.Value;
                    if (pTp_mov.Trim().ToUpper().Equals("S"))
                        if ((bsLoteAnvisa.List as CamadaDados.Faturamento.LoteAnvisa.TList_LoteAnvisa).Exists(p => p.Cd_empresa.Trim().Equals((bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Cd_empresa) &&
                                                                                                              p.Id_lote.Value.Equals((bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Id_lote.Value)))
                        {
                            (bsLoteAnvisa.List as CamadaDados.Faturamento.LoteAnvisa.TList_LoteAnvisa).Find(p => p.Cd_empresa.Trim().Equals((bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Cd_empresa) &&
                                                                                                                p.Id_lote.Value.Equals((bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Id_lote.Value)).Qtd_loteSai -=
                                (bsMovLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa).Quantidade;
                            bsLoteAnvisa.ResetBindings(true);
                        }
                    bsMovLoteAnvisa.RemoveCurrent();
                }
        }

        private void TFLoteAnvisa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            qtd_movimentar.Value = pQtd_movimentar;
            tot_saldo.Value = pQtd_movimentar;
            lblMov.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA";
            lblQtd.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "Qtd. Incluir Lote" : "Qtd. Retirar Lote";
            bsLoteAnvisa.DataSource = CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Buscar(pCd_empresa,
                                                                                                 pCd_fornecedor,
                                                                                                 pCd_produto,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 pTp_mov.Trim().ToUpper().Equals("E") ? string.Empty : "A",
                                                                                                 null);
        }

        private void bbLocalizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bsLoteAnvisa.Count; i++)
                if ((bsLoteAnvisa[i] as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Nr_lote.Trim().ToUpper().Contains(nr_lote.Text.Trim().ToUpper()))
                    bsLoteAnvisa.Position = i;
        }

        private void qtd_incluir_Leave(object sender, EventArgs e)
        {
            if (bsLoteAnvisa.Current != null)
            {
                decimal saldo = pTp_mov.Trim().ToUpper().Equals("E") ? qtd_movimentar.Value - total_movimento.Value :
                    qtd_movimentar.Value - total_movimento.Value > (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo ?
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo : qtd_movimentar.Value - total_movimento.Value;
                if (qtd_incluir.Value > saldo)
                {
                    MessageBox.Show("Quantidade incluir não pode ser maior que saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_incluir.Value = saldo;
                }
            }
        }

        private void bb_incluir_Click(object sender, EventArgs e)
        {
            if (bsLoteAnvisa.Current != null)
            {
                if (qtd_incluir.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não existe quantidade para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal saldo = pTp_mov.Trim().ToUpper().Equals("E") ? qtd_movimentar.Value - total_movimento.Value :
                    qtd_movimentar.Value - total_movimento.Value > (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo ?
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo : qtd_movimentar.Value - total_movimento.Value;
                if (qtd_incluir.Value > saldo)
                {
                    MessageBox.Show("Quantidade incluir não pode ser maior que saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_incluir.Value = saldo;
                    return;
                }
                bsMovLoteAnvisa.Add(new CamadaDados.Faturamento.LoteAnvisa.TRegistro_MovLoteAnvisa()
                {
                    Cd_empresa = (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Cd_empresa,
                    Id_lote = (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Id_lote,
                    Nr_lote = (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Nr_lote,
                    Tp_mov = pTp_mov,
                    Quantidade = qtd_incluir.Value
                });
                if (pTp_mov.Trim().ToUpper().Equals("S"))
                {
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_loteSai += qtd_incluir.Value;
                    bsLoteAnvisa.ResetCurrentItem();
                }
                total_movimento.Value += qtd_incluir.Value;
                tot_saldo.Value = qtd_movimentar.Value - total_movimento.Value;
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo ?
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo : tot_saldo.Value;
            }
            else MessageBox.Show("Não existe lote selecionado para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLoteAnvisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bsLoteAnvisa_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteAnvisa.Current != null)
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo ?
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo : tot_saldo.Value;
        }

        private void qtd_incluir_Enter(object sender, EventArgs e)
        {
            if (bsLoteAnvisa.Current != null)
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo ?
                    (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Qtd_saldo : tot_saldo.Value;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            using (TFNovoLoteAnvisa fLote = new TFNovoLoteAnvisa())
            {
                fLote.pCd_empresa = pCd_empresa;
                fLote.pNm_empresa = pNm_empresa;
                fLote.pCd_produto = pCd_produto;
                fLote.pDs_produto = pDs_produto;
                fLote.pCd_fornecedor = pCd_fornecedor;
                fLote.pNm_fornecedor = pNm_fornecedor;
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteAnvisa.Add(fLote.rLote);
                            bsLoteAnvisa.ResetBindings(true);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAltera_Click(object sender, EventArgs e)
        {
            using (TFNovoLoteAnvisa fLote = new TFNovoLoteAnvisa())
            {
                fLote.rLote = bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa;
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Gravar(fLote.rLote, null);
                            MessageBox.Show("Alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteAnvisa.DataSource = CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Buscar(fLote.rLote.Cd_empresa,
                                                                                                                 string.Empty,
                                                                                                                 fLote.rLote.Cd_produto,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 null);
                                                                                                                 

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
            
        }
    }
}
