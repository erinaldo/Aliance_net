using CamadaDados.Faturamento.Orcamento;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Estoque;
using CamadaNegocio.Estoque.Cadastros;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFFichaTecOrc : Form
    {
        private TList_FichaTecOrcItem lficha;
        public TList_FichaTecOrcItem lFicha
        {
            get
            {
                if (bsFichaTec.Count > 0)
                    return bsFichaTec.DataSource as TList_FichaTecOrcItem;
                else
                    return null;
            }
        }
        public string pCd_empresa { get; set; }
        public decimal? pNr_orcamento { get; set; }
        public decimal? pId_item { get; set; }
        public TFFichaTecOrc()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsFichaTec.Count > 0)
            {
                gFicha.EndEdit();
                DialogResult = DialogResult.OK;
            }
        }

        private void AtualizarFicha()
        {
            bsFichaTec.DataSource = lficha;
            bsFichaTec.ResetBindings(true);
        }

        private void PreencherFicha(TRegistro_FormulaApontamento rFormula)
        {
            //Buscar Ficha Formula
            TList_FichaTec_MPrima lFicha =
                CamadaNegocio.Producao.Producao.TCN_FichaTec_MPrima.Buscar(rFormula.Cd_empresa,
                                                                           rFormula.Id_formulacaostr,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           0,
                                                                           string.Empty,
                                                                           null);
            lFicha.ForEach(p =>
            {
                lficha.Add(
                        new TRegistro_FichaTecOrcItem()
                        {
                            Nr_orcamento = pNr_orcamento,
                            Id_item = pId_item,
                            Cd_item = p.Cd_produto,
                            Ds_item = p.Ds_produto,
                            Cd_local = p.Cd_local,
                            Ds_local = p.Ds_local,
                            Sg_unditem = p.Sigla_unidade,
                            Cd_unditem = p.Cd_unidade,
                            Ds_unditem = p.Ds_unidade,
                            Quantidade = p.Qtd_produto,
                            SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local(pCd_empresa, p.Cd_produto, p.Cd_local, null),
                        });
            });
            bsFichaTec.DataSource = lficha;
            bsFichaTec.ResetBindings(true);
        }

        private void TFFichaTecOrc_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lficha = new TCD_FichaTecOrcItem().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.Nr_orcamento",
                        vOperador = "=",
                        vVL_Busca = pNr_orcamento.ToString()
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.Id_item",
                        vOperador = "=",
                        vVL_Busca = pId_item.ToString()
                    }
                }, 0, string.Empty);
            if (lficha.Count > 0)
                bsFichaTec.DataSource = lficha;
            else
                lficha = new TList_FichaTecOrcItem();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bbAdd_Click(object sender, EventArgs e)
        {
            using (TFItensFichaTec fItens = new TFItensFichaTec())
            {
                if (fItens.ShowDialog() == DialogResult.OK)
                    if (fItens.rFicha != null)
                    {
                        fItens.rFicha.Nr_orcamento = pNr_orcamento;
                        fItens.rFicha.Id_item = pId_item;
                        fItens.rFicha.SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local(pCd_empresa, fItens.rFicha.Cd_item, fItens.rFicha.Cd_local, null);
                        lficha.Add(fItens.rFicha);
                        AtualizarFicha();
                    }
            }
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
                if (MessageBox.Show("Confirma a exclusão do Item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Excluir(bsFichaTec.Current as TRegistro_FichaTecOrcItem, null);
                        MessageBox.Show("Item excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lficha.Remove(bsFichaTec.Current as TRegistro_FichaTecOrcItem);
                        AtualizarFicha();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gFicha_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gFicha[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gFicha.EndEdit();
        }

        private void gFicha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != (char)44)
                e.Handled = true;
            else if (e.KeyChar == ',')
                if (((TextBox)sender).Text.Contains(","))
                    e.Handled = true;
        }

        private void bb_copiarFicha_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Count.Equals(0) ? true : MessageBox.Show("Se a fórmula for modificada você pode perder as alterações na ficha,\r\n" +
                                        "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
            {
                using (TFListFormula fLista = new TFListFormula())
                {
                    fLista.lFormula = CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar(string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    0,
                                                                                                    string.Empty,
                                                                                                    null);
                    if(fLista.ShowDialog() == DialogResult.OK)
                        if(fLista.rFormula != null)
                        {
                            if (bsFichaTec.Count > 0)
                            {
                                CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.ExcluirLista(bsFichaTec.DataSource as TList_FichaTecOrcItem, null);
                                bsFichaTec.Clear();
                            }
                            PreencherFicha(fLista.rFormula);
                        }
                }
            }
        }

        private void TFFichaTecOrc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void gFicha_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsFichaTec[e.RowIndex] as TRegistro_FichaTecOrcItem).Quantidade >
                        (bsFichaTec[e.RowIndex] as TRegistro_FichaTecOrcItem).SaldoEstoque)
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
                    else
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
            }
        }
    }
}
