using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Graos;
using CamadaDados.Faturamento.NotaFiscal;
using FormBusca;
using CamadaNegocio.Graos;

namespace Faturamento
{
    public partial class TFLan_Originacao : FormPadrao.FFormPadrao
    {
        public TList_RegLanFaturamento_Item ItensNota = new TList_RegLanFaturamento_Item();
        public decimal QTD_NFCurrent = 0;
        public bool fechaNormal = false;

        public TFLan_Originacao(TList_RegLanFaturamento_Item ItensNotaParam)
        {
            InitializeComponent();
            BB_Novo.Visible = false;
            BB_Gravar.Visible = true;
            BB_Gravar.Text = "(F4)\n Lançar";
            BB_Gravar.Width = 105;
            BB_Cancelar.Visible = true;
            BB_Buscar.Visible = false;
            habilitarControls(false);
            pDadosFiltro.set_FormatZero();
            ItensNota = ItensNotaParam;
            BS_ItensNota.DataSource = ItensNotaParam;
        }

        public override void habilitarControls(bool value)
        {
            pDadosFiltro.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            pDadosFiltro.LimparRegistro();
        }

        public override void afterGrava()
        {
            if (pDadosFiltro.validarCampoObrigatorio())
            {
                fechaNormal = true;
                //reg_Atividade_Item = BS_Item.Current as TRegistro_LanAtividade_Item;
                this.Dispose();
            }
        }

        public override void afterCancela()
        {
            fechaNormal = false;
            FLan_Originacao_FormClosing(this, null);
        }

        private void TFLan_Originacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (TC_Originacao.SelectedTab == tabOriginacao)
            {
                if (e.KeyCode == Keys.F9)
                    if (tsBB_Add.Visible)
                        tsBB_Add_Click(this, null);
                    else
                        tsBB_Salvar_Click(this, null);
                else if (e.KeyCode == Keys.F10)
                    if (tsBB_Remover.Visible)
                        tsBB_Remover_Click(this, null);
                    else
                        tsBB_Cancelar_Click(this, null);
            }
            else if (TC_Originacao.SelectedTab == tabHeadge)
            {
                if (e.KeyCode == Keys.F9)
                    if (tsBB_Alterar_Headge.Visible)
                        tsBB_Alterar_Headge_Click(this, null);
                    else
                        tsBB_Salvar_Headge_Click(this, null);
                else if (e.KeyCode == Keys.F10)
                    if (tsBB_Remover_Headge.Visible)
                        tsBB_Remover_Headge_Click(this, null);
                    else
                        tsBB_Cancelar_Headge_Click(this, null);
            }
        }

        #region "FILTROS"

            private void FLan_Originacao_FormClosing(object sender, FormClosingEventArgs e)
            {
                Utils.ShapeGrid.SaveShape(this, grid_Headge);
                Utils.ShapeGrid.SaveShape(this, grid_ItensNota);
                Utils.ShapeGrid.SaveShape(this, grid_NotaFiscal);
                if (!fechaNormal)
                {
                    if (MessageBox.Show("Deseja realmente cancelar a originação?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        fechaNormal = true;
                        this.DialogResult = DialogResult.Cancel;

                        foreach (TRegistro_LanFaturamento_Item regItem in ItensNota)
                            regItem.lOriginacao_x_Faturamento.Clear();

                        this.Close();
                    }
                }
            }

            private void bb_clifor_Click(object sender, EventArgs e)
            {
                string vParamFixo = "|| EXISTS (Select 1 From TB_FAT_notafiscal_item x "+
                                        "INNER JOIN TB_FAT_NotaFiscal w On w.cd_empresa = x.cd_empresa and w.Nr_LanctoFiscal = x.Nr_lanctoFiscal "+
                                        "LEFT OUTER JOIN TB_gro_Originacao_x_faturamento y On x.cd_empresa = y.cd_empresa and x.Nr_LanctoFiscal = y.Nr_lanctoFiscal and x.ID_NFItem = y.ID_NFItem "+
                                        "Where w.CD_Clifor = a.cd_clifor and w.tp_movimento = 'E' "+
                                        "GROUP BY x.quantidade "+
                                        "having SUM(isnull(y.QTD_Origem,0)) < x.quantidade)";
                UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, vParamFixo);

                if (cd_clifor.Text.Trim() == "")
                {
                    Nr_LanctoFiscal.Text = "";
                    Nr_NotaFiscal.Text = "";
                    ID_NFItem.Text = "";
                    VL_SubtotalNF.Value = 0;
                    Quantidade.Value = 0;
                    Quantidade.Maximum = 0;
                    VL_Subtotal.Value = 0;
                    VL_Subtotal.Maximum = 0;
                }
            }

            private void cd_clifor_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
                vColunas += ";|| EXISTS (Select 1 From TB_FAT_notafiscal_item x " +
                                        "INNER JOIN TB_FAT_NotaFiscal w On w.cd_empresa = x.cd_empresa and w.Nr_LanctoFiscal = x.Nr_lanctoFiscal " +
                                        "LEFT OUTER JOIN TB_gro_Originacao_x_faturamento y On x.cd_empresa = y.cd_empresa and x.Nr_LanctoFiscal = y.Nr_lanctoFiscal and x.ID_NFItem = y.ID_NFItem " +
                                        "Where w.CD_Clifor = a.cd_clifor and w.tp_movimento = 'E' " +
                                        "GROUP BY x.quantidade " +
                                        "having SUM(isnull(y.QTD_Origem,0)) < x.quantidade)";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

                if (cd_clifor.Text.Trim() == "")
                {
                    Nr_LanctoFiscal.Text = "";
                    Nr_NotaFiscal.Text = "";
                    ID_NFItem.Text = "";
                    VL_SubtotalNF.Value = 0;
                    Quantidade.Value = 0;
                    Quantidade.Maximum = 0;
                    VL_Subtotal.Value = 0;
                    VL_Subtotal.Maximum = 0;
                }
            }

            private void BB_NotaFiscal_Click(object sender, EventArgs e)
            {
                string vParam = "c.Tp_Movimento|=|'E';c.st_registro|<>|'C'";
                if (cd_clifor.Text.Trim() != "")
                    vParam += ";c.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
                string vColunas = "c.Nr_NotaFiscal|Nr. Nota Fiscal|80;" +
                                  "c.Nr_LanctoFiscal|Nr. Lancto Fiscal|80;" +
                                  "a.ID_NFItem|ID. Nf. Item|80;" +
                                  "c.CD_Empresa|Cód. Empresa|80;" +
                                  "c.CD_Clifor|Cód. Clifor|80;" +
                                  "d.NM_Clifor|Nome Clifor|250;" +
                                  "c.DT_Emissao|Data Emissão|80;" +
                                  "c.DT_SaiEnt|Data Entrada/Saída|80;" +
                                  "c.Especie|Espécie|150;" +
                                  "a.Quantidade|Quantidade|100;" +
                                  "a.Vl_Unitario|Valor Unitario|100;" +
                                  "a.Vl_Subtotal|Valor Subtotal|100;" +
                                  "QTD_Disponivel|Qtd. Disponivel|100;" +
                                  "VL_Disponivel|Vl. Disponivel|100;" +
                                  "c.Marca|Marca|200;" +
                                  "C.Tp_Movimento|Tipo Movimento|80";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_NotaFiscal, Nr_LanctoFiscal, ID_NFItem },
                                        new TCD_Lan_SaldoNotasOriginacao(), vParam);

                if (Nr_NotaFiscal.Text.Trim() != "")
                    Nr_NotaFiscal_Leave(this, e);
                else
                {
                    Nr_LanctoFiscal.Text = "";
                    Nr_NotaFiscal.Text = "";
                    ID_NFItem.Text = "";
                    VL_SubtotalNF.Value = 0;
                    Quantidade.Value = 0;
                    Quantidade.Maximum = 0;
                    VL_Subtotal.Value = 0;
                    VL_Subtotal.Maximum = 0;
                }
            }

            private void Nr_NotaFiscal_Leave(object sender, EventArgs e)
            {
                string vColunas = "c.Tp_Movimento|=|'E';c.Nr_NotaFiscal|=|'" + Nr_NotaFiscal.Text.Trim() + "';c.st_registro|<>|'C'";
                if (cd_clifor.Text.Trim() != "")
                    vColunas += ";c.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_NotaFiscal, Nr_LanctoFiscal, ID_NFItem },
                                        new TCD_Lan_SaldoNotasOriginacao());

                if (linha != null)
                {
                    VL_SubtotalNF.Value = Convert.ToDecimal(linha["VL_Subtotal"].ToString());
                    decimal qtd = Convert.ToDecimal(linha["QTD_Disponivel"].ToString());
                    decimal vl = Convert.ToDecimal(linha["VL_Disponivel"].ToString());
                    decimal totqtd = 0;
                    decimal totvl = 0;
                    QTD_NFCurrent = Convert.ToDecimal(linha["Quantidade"].ToString());
                    TList_Lan_Originacao_x_Faturamento listaValidaTotalLancto = (BS_ItensNota.Current as TRegistro_LanFaturamento_Item).lOriginacao_x_Faturamento;

                    //VERIFICAR SE EXISTE LANÇAMENTO BS ORIG 
                    if (listaValidaTotalLancto != null)
                    {
                        totqtd = ((BS_ItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade - Convert.ToDecimal(listaValidaTotalLancto.Sum(p => p.QTD_Origem)));
                        totvl = ((BS_ItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal - Convert.ToDecimal(listaValidaTotalLancto.Sum(p => p.VL_Origem)));

                        //VERIFICA se jah existe um lançamento para esta nota fiscal
                        if (listaValidaTotalLancto.Count(p => (p.Nr_LanctoFiscal == Convert.ToDecimal(Nr_LanctoFiscal.Text)) && (p.ID_NFItem == Convert.ToDecimal(ID_NFItem.Text))) > 1)
                        {
                            Nr_LanctoFiscal.Text = "";
                            Nr_NotaFiscal.Text = "";
                            ID_NFItem.Text = "";
                            qtd = 0;
                            vl = 0;
                            totqtd = 0;
                            totvl = 0;
                            MessageBox.Show("Atenção, já existe um lançamento para esta nota fiscal!");
                        }
                    }


                    //VERIRICA A QTD DE PRODUTO
                    if (qtd > totqtd)
                        qtd = totqtd;

                    //VERIRICA A QTD DE PRODUTO
                    if (vl > totvl)
                        vl = totvl;

                    Quantidade.Maximum = qtd;
                    Quantidade.Value = qtd;
                    //Quantidade_Leave(this, e);
                    VL_Subtotal.Maximum = vl;
                    //VL_Subtotal.Value = vl;
                    decimal valor = 0;
                    if (QTD_NFCurrent > 0)
                        valor = Math.Round(((Quantidade.Value) * (VL_SubtotalNF.Value / QTD_NFCurrent)), 2);
                    VL_Subtotal.Maximum = valor;
                    VL_Subtotal.Value = valor;
                }
                else
                {
                    Nr_LanctoFiscal.Text = "";
                    Nr_NotaFiscal.Text = "";
                    ID_NFItem.Text = "";
                    VL_SubtotalNF.Value = 0;
                    Quantidade.Value = 0;
                    Quantidade.Maximum = 0;
                    VL_Subtotal.Value = 0;
                    VL_Subtotal.Maximum = 0;
                }
            }

            private void Quantidade_Leave(object sender, EventArgs e)
            {
                decimal valor = 0;
                if (QTD_NFCurrent > 0)
                    valor = Math.Round(((Quantidade.Value) * (VL_SubtotalNF.Value / QTD_NFCurrent)), 2);
                VL_Subtotal.Maximum = valor;
                VL_Subtotal.Value = valor;
            }

        #endregion

        #region "ORIGINACAO"

            private void tsBB_Add_Click(object sender, EventArgs e)
            {
                if (BS_ItensNota.Current != null)
                {
                    tsBB_Salvar.Visible = true;
                    tsBB_Cancelar.Visible = true;
                    tsBB_Add.Visible = false;
                    tsBB_Remover.Visible = false;
                    BS_Originacao_x_Faturamento.AddNew();
                    pDadosFiltro.LimparRegistro();
                    habilitarControls(true);
                    ID_NFItem.Enabled = false;
                    Nr_LanctoFiscal.Enabled = false;
                    VL_SubtotalNF.Enabled = false;
                    cd_clifor.Focus();
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar um item da nota fiscal!");
                }
            }

            private void tsBB_Salvar_Click(object sender, EventArgs e)
            {
                if (pDadosFiltro.validarCampoObrigatorio())
                {
                    List<TRegistro_Lan_Originacao_x_Faturamento> listaValida = new List<TRegistro_Lan_Originacao_x_Faturamento>();

                    if (BS_Originacao_x_Faturamento.Count > 1)
                    {
                        TList_Lan_Originacao_x_Faturamento lista = (BS_ItensNota.Current as TRegistro_LanFaturamento_Item).lOriginacao_x_Faturamento;
                        //lista.Remove(BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento);
                        listaValida = lista.Where(p => (p.Nr_LanctoFiscalstr == Nr_NotaFiscal.Text)).ToList<TRegistro_Lan_Originacao_x_Faturamento>();
                    }

                    if (listaValida.Count <= 1)
                    {
                        tsBB_Salvar.Visible = false;
                        tsBB_Cancelar.Visible = false;
                        tsBB_Add.Visible = true;
                        tsBB_Remover.Visible = true;
                        habilitarControls(false);
                        BS_Originacao_x_Faturamento.ResetCurrentItem();
                        buscaHeadge();
                    }
                    else
                    {
                        MessageBox.Show("Atenção, já existe um lançamento de originação desta nota fiscal!");
                    }
                }
            }

            private void tsBB_Remover_Click(object sender, EventArgs e)
            {
                if (BS_Originacao_x_Faturamento.Current != null)
                {
                    tsBB_Salvar.Visible = false;
                    tsBB_Cancelar.Visible = false;
                    tsBB_Add.Visible = true;
                    tsBB_Remover.Visible = true;

                    BS_Originacao_x_Faturamento.RemoveCurrent();
                    habilitarControls(false);
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar uma originação!");
                }
            }

            private void tsBB_Cancelar_Click(object sender, EventArgs e)
            {
                tsBB_Salvar.Visible = false;
                tsBB_Cancelar.Visible = false;
                tsBB_Add.Visible = true;
                tsBB_Remover.Visible = true;
                BS_Originacao_x_Faturamento.RemoveCurrent();
                habilitarControls(false);
            }

        #endregion

        #region "HEADGE"

            private void buscaHeadge()
            {
                if (BS_Originacao_x_Faturamento.Current != null)
                {
                    (BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).lNFHeadge.Clear();
                    BS_Headge.DataSource = TCN_Lan_NFHeadge.Buscar(Convert.ToDecimal((BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).Nr_LanctoFiscal), Convert.ToDecimal((BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).ID_NFItem), "SqlCodeBuscaLanctoHeadge", (BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).QTD_Origem, (BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).VL_Origem, 0);

                    (BS_Originacao_x_Faturamento.Current as TRegistro_Lan_Originacao_x_Faturamento).lNFHeadge = BS_Headge.DataSource as TList_Lan_NFHeadge;
                    BS_Headge.ResetBindings(true);
                    BS_Headge.ResetCurrentItem();
                }
            }

            private void tsBB_Alterar_Headge_Click(object sender, EventArgs e)
            {
                if (BS_ItensNota.Current != null)
                {
                    tsBB_Salvar_Headge.Visible = true;
                    tsBB_Cancelar_Headge.Visible = true;
                    tsBB_Alterar_Headge.Visible = false;
                    tsBB_Remover_Headge.Visible = false;
                    VL_TotalHeadge.Enabled = true;
                    VL_TotalHeadge.Focus();
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar um item da nota fiscal!");
                }
            }

            private void tsBB_Salvar_Headge_Click(object sender, EventArgs e)
            {
                if (pDadosOriginacao.validarCampoObrigatorio())
                {
                    tsBB_Salvar_Headge.Visible = false;
                    tsBB_Cancelar_Headge.Visible = false;
                    tsBB_Alterar_Headge.Visible = true;
                    tsBB_Remover_Headge.Visible = true;
                    VL_TotalHeadge.Enabled = false;
                }
            }

            private void tsBB_Remover_Headge_Click(object sender, EventArgs e)
            {
                if (BS_Headge.Current != null)
                {
                    tsBB_Salvar_Headge.Visible = false;
                    tsBB_Cancelar_Headge.Visible = false;
                    tsBB_Alterar_Headge.Visible = true;
                    tsBB_Remover_Headge.Visible = true;

                    BS_Headge.RemoveCurrent();
                    BS_Headge.ResetCurrentItem();
                    habilitarControls(false);
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar uma originação!");
                }
            }

            private void tsBB_Cancelar_Headge_Click(object sender, EventArgs e)
            {
                tsBB_Salvar_Headge.Visible = false;
                tsBB_Cancelar_Headge.Visible = false;
                tsBB_Alterar_Headge.Visible = true;
                tsBB_Remover_Headge.Visible = true;
                VL_TotalHeadge.Enabled = false;
            }

            private void tabHeadge_Enter(object sender, EventArgs e)
            {
                if (BS_Originacao_x_Faturamento.Current == null)
                {
                    TC_Originacao.SelectedTab = tabOriginacao;
                    MessageBox.Show("Atenção, é necessário informar um item de originação!");
                }
                else
                    if (BS_Headge.Count <= 0)
                        buscaHeadge();
            }

            private void tsBB_Atualizar_Click(object sender, EventArgs e)
            {
                buscaHeadge();
            }

            private void BS_Originacao_x_Faturamento_PositionChanged(object sender, EventArgs e)
            {
                //if (BS_Originacao_x_Faturamento.Current != null)
                //    Nr_NotaFiscal_Leave(this, null);
            }

        #endregion

            private void TFLan_Originacao_Load(object sender, EventArgs e)
            {
                Utils.ShapeGrid.RestoreShape(this, grid_Headge);
                Utils.ShapeGrid.RestoreShape(this, grid_ItensNota);
                Utils.ShapeGrid.RestoreShape(this, grid_NotaFiscal);
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }

    }
}

