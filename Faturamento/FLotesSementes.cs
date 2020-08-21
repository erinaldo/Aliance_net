using System;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLotesSementes : Form
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
        public decimal pNr_lanctofiscal
        { get; set; }
        public decimal pID_NF_Item
        { get; set; }

        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lMov
        {
            get
            {
                if (bsMovLote.Count > 0)
                {
                    CamadaDados.Sementes.TList_LoteSemente_X_NFItem lmov = new CamadaDados.Sementes.TList_LoteSemente_X_NFItem();
                    foreach (CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem rmov in bsMovLote.List)
                        lmov.Add(rmov);
                    return lmov;
                }
                else return null;
            }
        }

        public TFLotesSementes()
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
            DialogResult = DialogResult.OK;
        }

        private void TFLotesSementes_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            qtd_movimentar.Value = pQtd_movimentar;
            tot_saldo.Value = pQtd_movimentar;
            lblMov.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA";
            lblQtd.Text = pTp_mov.Trim().ToUpper().Equals("E") ? "Qtd. Incluir Lote" : "Qtd. Retirar Lote";
            bsLoteSemente.DataSource = CamadaNegocio.Sementes.TCN_LoteSemente.Buscar(string.Empty,
                                                                                     pCd_empresa,
                                                                                     pCd_produto,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     false,
                                                                                     0,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     null);
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bbLocalizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bsLoteSemente.Count; i++)
                if ((bsLoteSemente[i] as CamadaDados.Sementes.TRegistro_LoteSemente).Nr_lote.Trim().ToUpper().Contains(nr_lote.Text.Trim().ToUpper()))
                    bsLoteSemente.Position = i;
        }

        private void bbAddLote_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFNovoLote fLote = new Proc_Commoditties.TFNovoLote())
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
                            fLote.rLote.Tp_lote = "T";
                            fLote.rLote.St_registro = "P";
                            CamadaNegocio.Sementes.TCN_LoteSemente.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteSemente.Add(fLote.rLote);
                            bsLoteSemente.ResetBindings(true);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbExcluiMov_Click(object sender, EventArgs e)
        {
            if (bsMovLote.Current != null)
                if (MessageBox.Show("Confirma exclusão do movimento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    total_movimento.Value -= (bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Quantidade;
                    tot_saldo.Value = qtd_movimentar.Value - total_movimento.Value;
                    if (pTp_mov.Trim().ToUpper().Equals("E"))
                        if ((bsLoteSemente.List as CamadaDados.Sementes.TList_LoteSemente).Exists(p => p.Cd_empresa.Trim().Equals((bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Cd_empresa) &&
                                                                                                              p.Id_lote.Equals((bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Id_lote)))
                        {
                            (bsLoteSemente.List as CamadaDados.Sementes.TList_LoteSemente).Find(p => p.Cd_empresa.Trim().Equals((bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Cd_empresa) &&
                                                                                                                p.Id_lote.Equals((bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Id_lote)).Qtd_amostra -=
                                (bsMovLote.Current as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Quantidade;
                            bsLoteSemente.ResetBindings(true);
                        }
                    bsMovLote.RemoveCurrent();
                }
        }

        private void TFLotesSementes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bsLoteSemente_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteSemente.Current != null)
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo ?
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo : tot_saldo.Value;
        }

        private void qtd_incluir_Enter(object sender, EventArgs e)
        {
            if (bsLoteSemente.Current != null)
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo ?
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo : tot_saldo.Value;
        }

        private void bb_incluir_Click(object sender, EventArgs e)
        {
            if (bsLoteSemente.Current != null)
            {
                if (qtd_incluir.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não existe quantidade para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal saldo = pTp_mov.Trim().ToUpper().Equals("E") ? qtd_movimentar.Value - total_movimento.Value :
                    qtd_movimentar.Value - total_movimento.Value > (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo ?
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo : qtd_movimentar.Value - total_movimento.Value;
                if (qtd_incluir.Value > saldo)
                {
                    MessageBox.Show("Quantidade incluir não pode ser maior que saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_incluir.Value = saldo;
                    return;
                }

                bsMovLote.Add(
                    new CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem()
                    {
                        Cd_empresa = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_empresa,
                        Id_lote = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote,
                        Nr_lanctofiscal = pNr_lanctofiscal,
                        Id_nfitem = pID_NF_Item,
                        Tp_movimento = pTp_mov.Equals("E") ? "O" : "D",
                        Quantidade = qtd_incluir.Value
                    });
                total_movimento.Value += qtd_incluir.Value;
                tot_saldo.Value = qtd_movimentar.Value - total_movimento.Value;
                qtd_incluir.Value = pTp_mov.Trim().ToUpper().Equals("E") ? tot_saldo.Value :
                    tot_saldo.Value > (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo ?
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo : tot_saldo.Value;
                bsMovLote.ResetCurrentItem();
            }
            else MessageBox.Show("Não existe lote selecionado para incluir movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
