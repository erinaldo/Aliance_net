using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFLanCartaoPDV : Form
    {
        public string pCd_empresa
        { get; set; }
        public string D_C
        { get; set; }
        public decimal Vl_saldofaturar
        { get; set; }
        public bool St_bloquearTroco
        { get; set; }
        public bool St_validarSaldo
        { get; set; }
        public decimal Qtd_parcelasFaturar
        { get; set; }
        public bool st_parcela { get; set; } = false;
       
        public CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura
        {
            get
            {
                CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFat = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
                if (bsParcelas.Count > 1)
                {
                    (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas).ForEach(p =>
                        lFat.Add(new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao()
                        {
                            Cd_empresa = pCd_empresa,
                            Dt_fatura = p.Dt_vencimento,
                            Id_bandeirastr = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Id_bandeirastr,
                            Id_maquinastr = (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).Id_maquinastr,
                            Nr_autorizacao = nr_autorizacao.Text,
                            Tp_movimento = "R",
                            Vl_nominal = p.Vl_parcela
                        }));
                }
                else
                    lFat.Add(new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao()
                    {
                        Cd_empresa = pCd_empresa,
                        Dt_fatura = CamadaDados.UtilData.Data_Servidor(),
                        Id_bandeirastr = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Id_bandeirastr,
                        Id_maquinastr = (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).Id_maquinastr,
                        Nr_autorizacao = nr_autorizacao.Text,
                        Tp_movimento = "R",
                        Vl_nominal = vl_fatura.Value
                    });
                return lFat;
            }
        }   

        public TFLanCartaoPDV()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsBandeiraCartao.Current == null ? true : !(bsBandeiraCartao.List as CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao).Exists(p => p.St_processar))
            {
                MessageBox.Show("Obrigatorio selecionar bandeira cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(bsMaquina.Current == null ? true : !(bsMaquina.List as CamadaDados.Financeiro.Cadastros.TList_CadMaquinaCartao).Exists(p=> p.St_processar))
            {
                MessageBox.Show("Obrigatório selecionar maquina cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (vl_fatura.Focused)
                if (!ValidarValorTitulo())
                    return;
            if (vl_fatura.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar valor da fatura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_fatura.Focus();
                return;
            }
            if (St_validarSaldo && (vl_fatura.Value < Vl_saldofaturar))
            {
                MessageBox.Show("Valor da fatura não pode ser menor que o valor da venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_fatura.Value = Vl_saldofaturar;
                vl_fatura.Focus();
                return;
            }
            if(ValidarValorTitulo())
                DialogResult = DialogResult.OK;
        }

        private bool ValidarValorTitulo()
        {
            bool retorno = true;
            if ((vl_fatura.Value > Vl_saldofaturar) &&
                (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("VL_CD_MAIORVLFINRECEBER", pCd_empresa, null).Trim().ToUpper().Equals("N") ||
                St_bloquearTroco))
            {
                MessageBox.Show("Valor da fatura não pode ser maior que saldo a faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_fatura.Value = Vl_saldofaturar;
                vl_fatura.Focus();
                retorno = false;
            }
            return retorno;
        }

        private void TFLanCartaoPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFLanCartaoPDV_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBandeiraCartao);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar bandeira cartao
            bsBandeiraCartao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_Cad_BandeiraCartao.Buscar(string.Empty,
                                                                                                           string.Empty,
                                                                                                           D_C,
                                                                                                           0,
                                                                                                           string.Empty,
                                                                                                           null);
            //Buscar Maquina Cartao
            bsMaquina.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadMaquinaCartao.Buscar(string.Empty, string.Empty, null);
            if(bsMaquina.List.Count.Equals(1))
            {
                (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar = true;
                bsMaquina.ResetCurrentItem();
            }
            vl_fatura.Value = Vl_saldofaturar;
            //Habilitar parcelas
            if (Qtd_parcelasFaturar > decimal.Zero)
            {
                qtd_parcelas.Value = Qtd_parcelasFaturar;
                qtd_parcelas_Leave(this, new EventArgs());
            }
            qtd_parcelas.Enabled = st_parcela;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void vl_fatura_Leave(object sender, EventArgs e)
        {
            ValidarValorTitulo();
        }

        private void gBandeiraCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Tab))
            {
                if (bsMaquina.Count < 2)
                    nr_autorizacao.Focus();
                else gMaquina.Focus();
            }
        }

        private void gBandeiraCartao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBandeiraCartao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBandeiraCartao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao());
            CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao(lP.Find(gBandeiraCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBandeiraCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao(lP.Find(gBandeiraCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBandeiraCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBandeiraCartao.List as CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao).Sort(lComparer);
            bsBandeiraCartao.ResetBindings(false);
            gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bsBandeiraCartao_PositionChanged(object sender, EventArgs e)
        {
            if (bsBandeiraCartao.Current != null)
                qtd_parcelas.Enabled = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Tp_cartao.Trim().ToUpper().Equals("C");
        }

        private void qtd_parcelas_Leave(object sender, EventArgs e)
        {
            if (vl_fatura.Value.Equals(0))
            {
                MessageBox.Show("Necessario informar valor fatura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qtd_parcelas.Value = qtd_parcelas.Minimum;
                if (!vl_fatura.Focus())
                    qtd_parcelas.Focus();
            }
            //Calcular parcelas
            bsParcelas.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(vl_fatura.Value,
                                                                                                         decimal.Zero,
                                                                                                         CamadaDados.UtilData.Data_Servidor(),
                                                                                                         qtd_parcelas.Value,
                                                                                                         decimal.Zero);
            if (qtd_parcelas.Value > 1)
                Height = 600;
            else
                Height = 450;
        }

        private void vl_parcela_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela = vl_parcela.Value;
                (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela_padrao = vl_parcela.Value;
                CamadaDados.Financeiro.Duplicata.TList_Parcelas lParc = bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas;
                CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.reajustaValorParcela(bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas,
                                                                                         vl_fatura.Value,
                                                                                         bsParcelas.Position);
                bsParcelas.ResetBindings(true);
            }
        }

        private void TFLanCartaoPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBandeiraCartao);
        }

        private void gBandeiraCartao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).St_processar)
                {
                    (bsBandeiraCartao.List as CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao).ForEach(p => p.St_processar = false);
                    gBandeiraCartao.Refresh();
                }
                (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).St_processar = !(bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).St_processar;
                bsBandeiraCartao.ResetCurrentItem();
            }
        }

        private void gMaquina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar)
                {
                    (bsMaquina.List as CamadaDados.Financeiro.Cadastros.TList_CadMaquinaCartao).ForEach(p => p.St_processar = false);
                    gMaquina.Refresh();
                }
                (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar = !(bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar;
                bsMaquina.ResetCurrentItem();
            }
        }

        private void gMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Tab))
                nr_autorizacao.Focus();
        }
    }
}
