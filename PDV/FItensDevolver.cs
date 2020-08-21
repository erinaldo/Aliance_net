using CamadaDados.Faturamento.PDV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Faturamento.PDV;
namespace PDV
{
    public partial class TFItensDevolver : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }

        public List<TRegistro_VendaRapida_Item> lItens
        {
            get
            {
                if (bsVenda.Count > 0)
                {
                    List<TRegistro_VendaRapida_Item> ret = new List<TRegistro_VendaRapida_Item>();
                    (bsVenda.List as TList_VendaRapida).ForEach(p =>
                        p.lItem.FindAll(v => v.Qtd_devolver > decimal.Zero && v.Qtd_devolver <= v.Sd_devolver).ForEach(v => ret.Add(v)));
                    return ret;
                }
                else
                    return null;
            }
        }

        public TFItensDevolver()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsVenda.Current != null)
            {
                if (qtd_devolver.Focus())
                    (bsItens.Current as TRegistro_VendaRapida_Item).Qtd_devolver = qtd_devolver.Value;
                if (!(bsVenda.Current as TRegistro_VendaRapida).lItem.Exists(p => p.Qtd_devolver > decimal.Zero))
                {
                    MessageBox.Show("Não existe item com quantidade a devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsVenda.Current as TRegistro_VendaRapida).lItem.Exists(p => p.Qtd_devolver > p.Sd_devolver))
                {
                    MessageBox.Show("Existe item com quantidade devolver maior que o saldo disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Alocar Grade de Produto se Existir
                foreach (TRegistro_VendaRapida_Item r in (bsVenda.Current as TRegistro_VendaRapida).lItem)
                {
                    if (r.Id_caracteristicaH.HasValue)
                        if (r.Qtd_devolver > r.lGrade.Sum(v => v.Vl_mov))
                        {
                            MessageBox.Show("Existe item com saldo para alocar em grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
                pCd_clifor = (bsVenda.Current as TRegistro_VendaRapida).Cd_clifor;
                pNm_clifor = (bsVenda.Current as TRegistro_VendaRapida).Nm_clifor;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Não existe venda selecionada para devolver itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[2];
            //Status
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            //Saldo Devolver
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "exists";
            filtro[1].vVL_Busca = "(select 1 from TB_PDV_VendaRapida_Item x " +
                                  "where x.cd_empresa = a.CD_Empresa " +
                                  "and x.Id_VendaRapida = a.Id_VendaRapida " +
                                  "and x.Quantidade > isnull((select sum(isnull(z.qtd_entrada, 0)) " +
                                  "                             from TB_PDV_ItensDevolvidos y " +
                                  "                             inner join TB_EST_Estoque z " +
                                  "                             on y.cd_empresa = z.cd_empresa " +
                                  "                             and y.cd_produto = z.cd_produto " +
                                  "                             and y.id_lanctoestoque = z.id_lanctoestoque " +
                                  "                             where y.cd_empresa = x.cd_empresa " +
                                  "                             and y.id_cupom = x.id_vendarapida " +
                                  "                             and y.id_lancto = x.id_lanctovenda " +
                                  "                             and isnull(z.st_registro, 'A') <> 'C'), 0))";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_venda.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_venda.Text;
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text + "'";
            }
            if (!string.IsNullOrEmpty(nr_nfce.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                      "inner join tb_pdv_nfce y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_cupom = y.id_nfce " +
                                                      "where a.cd_empresa = x.cd_empresa " +
                                                      "and a.id_vendarapida = x.id_vendarapida " +
                                                      "and y.nr_nfce = " + nr_nfce.Text + ")";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_vendarapida_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_vendarapida = a.id_vendarapida " +
                                                      "and x.cd_produto = '" + cd_produto.Text.Trim() + "')";
            }
            if (dt_inicial.Text.Trim() != "/  /       :")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inicial.Text).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            if (dt_final.Text.Trim() != "/  /       :")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_final.Text).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            bsVenda.DataSource = new TCD_VendaRapida().Select(filtro, 0, string.Empty, string.Empty);
            bsVenda_PositionChanged(this, new EventArgs());
        }

        private void qtd_devolver_Leave(object sender, EventArgs e)
        {
            if (qtd_devolver.Value > sd_devolver.Value)
            {
                MessageBox.Show("Não é permitido devolver quantidade maior que saldo a devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qtd_devolver.Value = decimal.Zero;
            }
            else 
                saldo_alocar.Text = qtd_devolver.Value.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsItens.MovePrevious();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsItens.MoveNext();
        }

        private void gVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_VendaRapida());
            TList_VendaRapida lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_VendaRapida(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_VendaRapida(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVenda.List as TList_VendaRapida).Sort(lComparer);
            bsVenda.ResetBindings(false);
            gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_VendaRapida_Item());
            TList_VendaRapida_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_VendaRapida_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_VendaRapida_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as TList_VendaRapida_Item).Sort(lComparer);
            bsItens.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void TFItensDevolver_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            tlpItens.ColumnStyles[1].Width = 0;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            qtd_devolver.Increment = 1;
        }

        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
                if ((bsVenda.Current as TRegistro_VendaRapida).lItem.Count.Equals(0))
                {
                    (bsVenda.Current as TRegistro_VendaRapida).lItem =
                        TCN_VendaRapida_Item.Buscar((bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                    (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                    true,
                                                    "'A'",
                                                    null);
                    bsVenda.ResetCurrentItem();
                }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFItensDevolver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gGrade.EndEdit();
        }

        private void gGrade_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void gGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade -
                (bsValorGrade.List as List<CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov) +
                decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()) < decimal.Parse(gGrade[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                MessageBox.Show("valor infomado não pode ser maior que saldo movimento disponivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
                gGrade.EndEdit();
            }
            else if (!TCN_VendaRapida_Item.ValidarQuantidadeItemGrade(bsVenda.Current as TRegistro_VendaRapida, 
                                                                      bsItens.Current as TRegistro_VendaRapida_Item,
                                                                      bsValorGrade.Current as CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica,
                                                                      gGrade[e.ColumnIndex, e.RowIndex].Value))
            {
                MessageBox.Show("O valor infomado é maior ou inválido a quantidade vendida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
                gGrade.EndEdit();
            }
            saldo_alocar.Text = string.Format(((bsItens.Current as TRegistro_VendaRapida_Item).Quantidade -
                                                (bsValorGrade.List as List<CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov)).ToString(), "{0:N3}");
            qtd_devolver.Value = (bsValorGrade.List as List<CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica>).Sum(p => p.Vl_mov);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (bsItens.Current == null ? false : (bsItens.Current as TRegistro_VendaRapida_Item).Id_caracteristicaH.HasValue)
                {
                    tlpItens.ColumnStyles[1].Width = 230;

                    TpBusca[] tps = new TpBusca[0];
                    Estruturas.CriarParametro(ref tps, "a.id_caracteristica", (bsItens.Current as TRegistro_VendaRapida_Item).Id_caracteristicaH.ToString());
                    Estruturas.CriarParametro(ref tps, "", "(select 1 " +
                                                           "from TB_PDV_CupomFiscal_Item_X_Estoque xxx " +
                                                           "inner join tb_est_gradeestoque xx1 " +
                                                           "on xxx.Id_LanctoEstoque = xx1.Id_LanctoEstoque " +
                                                           "where xxx.Id_Cupom = " + (bsItens.Current as TRegistro_VendaRapida_Item).Id_vendarapida + " " +
                                                           "and xx1.ID_Caracteristica = a.ID_Caracteristica " +
                                                           "and xx1.ID_Item = a.ID_Item " +
                                                           "and xxx.cd_produto = " + (bsItens.Current as TRegistro_VendaRapida_Item).Cd_produto + " " +
                                                           "and xxx.CD_Empresa = "+ (bsItens.Current as TRegistro_VendaRapida_Item).Cd_empresa + ") " , "exists");
                    new CamadaDados.Estoque.Cadastros.TCD_ValorCaracteristica()
                        .Select(tps, 0, string.Empty)
                            .ForEach(p => (bsItens.Current as TRegistro_VendaRapida_Item).lGrade.Add(p));
                }
                else tlpItens.ColumnStyles[1].Width = 0;              
            }
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbClifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }
    }
}
