using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Estoque
{
    public partial class TFPrecoProduto : Form
    {
        public TFPrecoProduto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(cbTabPreco.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar tabela preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTabPreco.Focus();
                return;
            }
            if ((bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Count(p=> p.St_processar) > 0)
            {
                if(string.IsNullOrWhiteSpace(dt_inivigencia.Text.SoNumero()))
                {
                    MessageBox.Show("Obrigatório informar data inicial da vigência do preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_inivigencia.Focus();
                    return;
                }
                if ((bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Count(p=> p.St_processar) > 1)
                {
                    if (pc_ajuste.Value.Equals(decimal.Zero) &&
                        pc_markup.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatorio informar percentual de ajuste ou percentual markup para processar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pc_ajuste.Focus();
                        return;
                    }
                    bool st = (bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Exists(p => p.Dt_ultimavigencia.HasValue ? p.Dt_ultimavigencia.Value >= Convert.ToDateTime(dt_inivigencia.Text) : false);
                    if (MessageBox.Show((st ? "Existe item com data inicial de vigência maior que a data inicial que esta sendo lançado, os mesmos não serão alterados.\r\n" : string.Empty) +
                                        "Confirma processamento dos itens?", "Pergunta",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        //Montar lista com os itens para atualizar preco
                        CamadaDados.Estoque.TList_LanPrecoItem lPreco = new CamadaDados.Estoque.TList_LanPrecoItem();
                        (bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Where(p=> p.St_processar &&
                        (p.Dt_ultimavigencia.HasValue ? p.Dt_ultimavigencia.Value < Convert.ToDateTime(dt_inivigencia.Text) : true)).ToList().ForEach(p =>
                            {
                                if(st_percultcompra.Checked ? p.Vl_ultimacompra > decimal.Zero : p.Vl_ultimopreco > 0)
                                    lPreco.Add(new CamadaDados.Estoque.TRegistro_LanPrecoItem()
                                    {
                                        CD_Empresa = cbEmpresa.SelectedValue.ToString(),
                                        CD_TabelaPreco = cbTabPreco.SelectedValue.ToString(),
                                        CD_Produto = p.Cd_produto,
                                        Dt_preco = Convert.ToDateTime(dt_inivigencia.Text),
                                        Vl_NovoPreco = pc_ajuste.Value > decimal.Zero ? 
                                                        Math.Round(st_percultcompra.Checked ? p.Vl_ultimacompra : p.Vl_ultimopreco, 3) + 
                                                        Math.Round(((Math.Round(st_percultcompra.Checked ? p.Vl_ultimacompra : p.Vl_ultimopreco, 3) * pc_ajuste.Value) / 100), 3) :
                                                        tp_markup.Text.Trim().ToUpper().Equals("D") ?
                                                        (st_percultcompra.Checked ? p.Vl_ultimacompra : p.Vl_custoreal) / pc_markup.Value :
                                                        (st_percultcompra.Checked ? p.Vl_ultimacompra : p.Vl_custoreal) * pc_markup.Value
                                    });
                            });
                        CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Grava_LanPrecoItem(lPreco, null);
                        pc_ajuste.Value = pc_ajuste.Minimum;
                        BuscarProdutos();
                    }
                }
                else
                {
                    if (vl_precovenda.Value.Equals(decimal.Zero) &&
                        pc_ajuste.Value.Equals(decimal.Zero) &&
                        pc_markup.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatorio informar valor ou indice para gravar preço venda.", 
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_precovenda.Focus();
                        return;
                    }
                    if(vl_precovenda.Value.Equals(decimal.Zero) &&
                        ((pc_ajuste.Value != decimal.Zero) || (pc_markup.Value != decimal.Zero)))
                        if ((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Vl_custoreal.Equals(decimal.Zero))
                        {
                            MessageBox.Show("Permitido gravar preço utilizando indice somente se produto tiver valor de estoque.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    if((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Dt_ultimavigencia.HasValue ?
                        (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Dt_ultimavigencia.Value >= Convert.ToDateTime(dt_inivigencia.Text) : false)
                    {
                        MessageBox.Show("Item possui preço com vigência inicial maior que a data de vigência atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Grava_LanPrecoItem(
                            new CamadaDados.Estoque.TRegistro_LanPrecoItem()
                            {
                                CD_Empresa = cbEmpresa.SelectedValue.ToString(),
                                CD_TabelaPreco = cbTabPreco.SelectedValue.ToString(),
                                CD_Produto = (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto,
                                Dt_preco = Convert.ToDateTime(dt_inivigencia.Text),
                                Vl_NovoPreco = vl_precovenda.Value > decimal.Zero ? 
                                                vl_precovenda.Value : 
                                                pc_ajuste.Value > 0 ?
                                                    st_percultcompra.Checked ?
                                                        Math.Round(vl_ultimacompra.Value > decimal.Zero ? vl_ultimacompra.Value : vl_custo.Value, 3) + 
                                                        Math.Round(((Math.Round(vl_ultimacompra.Value > decimal.Zero ? vl_ultimacompra.Value : vl_custo.Value, 3) * pc_ajuste.Value) / 100), 3) :
                                                    Math.Round((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Vl_ultimopreco, 3) + 
                                                    Math.Round(((Math.Round((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Vl_ultimopreco, 3) * pc_ajuste.Value) / 100), 3) :
                                                tp_markup.Text.Trim().ToUpper().Equals("D") ? vl_custo.Value / pc_markup.Value :
                                                vl_custo.Value * pc_markup.Value
                            }, null);
                        if ((new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto)))
                        {
                            if (MessageBox.Show("Deseja atualizar os preços de venda dos itens da ficha técnica?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                using (Cadastros.TFAlterarPrecoFichaTec fAltera = new Cadastros.TFAlterarPrecoFichaTec())
                                {
                                    fAltera.pCd_tabelapreco = cbTabPreco.SelectedValue.ToString();
                                    fAltera.pCd_produto = (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto;
                                    fAltera.St_atualizar = true;
                                    if (fAltera.ShowDialog() == DialogResult.OK)
                                        if (fAltera.lFicha != null)
                                            try
                                            {
                                                CamadaNegocio.Estoque.Cadastros.TCN_PrecoItemFicha.GravarLista(fAltera.lFicha, null);
                                                MessageBox.Show("Itens alterados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                        }
                        BuscarProdutos();
                        vl_precovenda.Value = vl_precovenda.Minimum;
                        pc_ajuste.Value = pc_ajuste.Minimum;
                        pc_markup.Value = pc_markup.Minimum;
                        vl_precovenda.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BuscarProdutos()
        {
            if (cbEmpresa.SelectedItem != null &&
                cbTabPreco.SelectedItem != null)
            {
                TpBusca[] filtro = new TpBusca[0];
                if (!string.IsNullOrWhiteSpace(cd_grupo.Text))
                    Estruturas.CriarParametro(ref filtro, "a.cd_grupo", "'" + cd_grupo.Text.Trim() + "'");
                if (!string.IsNullOrWhiteSpace(tp_produto.Text))
                    Estruturas.CriarParametro(ref filtro, "a.tp_produto", "'" + tp_produto.Text.Trim() + "'");
                if (!string.IsNullOrWhiteSpace(cd_marcaBusca.Text))
                    Estruturas.CriarParametro(ref filtro, "isnull(a.cd_marca, 0)", cd_marcaBusca.Text);
                if (!string.IsNullOrWhiteSpace(cd_prodbusca.Text))
                    Estruturas.CriarParametro(ref filtro, "a.cd_produto", "'" + cd_prodbusca.Text.Trim() + "'");
                if (!string.IsNullOrWhiteSpace(cd_condfiscal.Text))
                    Estruturas.CriarParametro(ref filtro, "a.cd_condfiscal_produto", "'" + cd_condfiscal.Text.Trim() + "'");
                if (!string.IsNullOrWhiteSpace(ds_produtobusca.Text) && string.IsNullOrWhiteSpace(cd_prodbusca.Text))
                    Estruturas.CriarParametro(ref filtro, "a.ds_produto", "'%" + ds_produtobusca.Text.Trim() + "%'", "like");
                bsItens.DataSource = new CamadaDados.Estoque.TCD_LanPrecoItem().SelectProdutoPreco(cbEmpresa.SelectedValue.ToString(), cbTabPreco.SelectedValue.ToString(), filtro);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void BuscarIndiceMarkup()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar empresa para utilizar MARKUP.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFBuscarMarkup fMarkup = new TFBuscarMarkup())
            {
                fMarkup.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                if (fMarkup.ShowDialog() == DialogResult.OK)
                    if(fMarkup.rMarkup != null)
                    {
                        pc_markup.Value = fMarkup.rMarkup.Pc_indicemarkup;
                        tp_markup.Text = fMarkup.rMarkup.Tp_markup;
                        pc_ajuste.Value = pc_ajuste.Minimum;
                    }
            }
        }
        
        private void vl_precovenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                afterGrava();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFPrecoProduto_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gProduto);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbTabPreco.DataSource = CamadaNegocio.Diversos.TCN_CadTbPreco.Busca(string.Empty, string.Empty, string.Empty);
            cbTabPreco.DisplayMember = "DS_TabelaPreco";
            cbTabPreco.ValueMember = "Cd_tabelaPreco";
            pFiltro.set_FormatZero();
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_grupo|Grupo Produto|200;" +
                            "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpproduto|Tipo Produto|200;" +
                            "a.tp_produto|TP. Produto|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prodbusca, ds_produtobusca }, null);
            ds_produtobusca.Enabled = string.IsNullOrWhiteSpace(cd_prodbusca.Text);
        }

        private void cd_prodbusca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_prodbusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_prodbusca, ds_produtobusca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            ds_produtobusca.Enabled = string.IsNullOrWhiteSpace(cd_prodbusca.Text);
        }

        private void bb_markup_Click(object sender, EventArgs e)
        {
            BuscarIndiceMarkup();
        }

        private void bb_custoprod_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null && cbEmpresa.SelectedItem != null && cbTabPreco.SelectedItem != null)
                if (new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "(isnull(a.st_semente, 'N') = 'S') or (isnull(a.st_industrializado, 'N') = 'S')"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_produto x " +
                                        "where x.tp_produto = a.tp_produto " +
                                        "and x.cd_produto = '" + (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto.Trim() + "')"
                        }
                    }, "1") != null)
                {
                    //Buscar lista de formulas
                    CamadaDados.Producao.Producao.TList_FormulaApontamento lFormula =
                        CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
                    if (lFormula.Count > 0)
                        if (lFormula.Count.Equals(1))
                            vl_custoprod.Value = CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.CalcularCustoProducao(lFormula[0]);
                        else
                            using (Proc_Commoditties.TFDisponibilidadeMPrima fDisponibilidade = new Proc_Commoditties.TFDisponibilidadeMPrima())
                            {
                                fDisponibilidade.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                                fDisponibilidade.pCd_produto = (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto;

                                fDisponibilidade.ShowDialog();

                                vl_custoprod.Value = fDisponibilidade.Vl_custoProducao;
                            }
                }
                else if (new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_composto, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_produto x " +
                                        "where x.tp_produto = a.tp_produto " +
                                        "and x.cd_produto = '" + (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto.Trim() + "')"
                        }
                    }, "1") != null)
                {
                    //Calcular custo produto
                    CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto,
                                                                                   string.Empty,
                                                                                   null);
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(cbEmpresa.SelectedValue.ToString(), cbTabPreco.SelectedValue.ToString(), lFicha, null);
                    vl_custoprod.Value = lFicha.Sum(p => p.Vl_subtotalservico);
                }
        }

        private void TFPrecoProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gProduto);
        }

        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_ProdutoPreco());
            CamadaDados.Estoque.TList_ProdutoPreco lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_ProdutoPreco(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_ProdutoPreco(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Sort(lComparer);
            bsItens.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null && cbEmpresa.SelectedItem != null)
            {
                (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Vl_ultimacompra =
                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.BuscarUltimaCompra(cbEmpresa.SelectedValue.ToString(),
                                                                                        (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).Cd_produto,
                                                                                        null);
                bsItens.ResetCurrentItem();
            }
        }

        private void cd_marcaBusca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_marca|=|" + cd_marcaBusca.Text.Trim();
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marcaBusca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_marca|Marca Produto|200;" +
                            "a.cd_marca|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_marcaBusca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), string.Empty);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItens.ResetBindings(true);
                vl_precovenda.Enabled = !cbTodos.Checked;
            }
        }

        private void vl_precovenda_EnabledChanged(object sender, EventArgs e)
        {
            if (!vl_precovenda.Enabled)
                vl_precovenda.Value = decimal.Zero;
        }

        private void gProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).St_processar =
                    !(bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).St_processar;
                bsItens.ResetCurrentItem();
                vl_precovenda.Enabled = (bsItens.List as CamadaDados.Estoque.TList_ProdutoPreco).Count(p => p.St_processar) < 2;
            }
        }

        private void bb_condfiscal_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CondFiscal_Produto|Condição Fiscal|200;a.CD_CondFiscal_Produto|Código|60",
                new Componentes.EditDefault[] { cd_condfiscal }, new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
        }

        private void cd_condfiscal_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_CondFiscal_Produto|=|'" + cd_condfiscal.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_condfiscal }, new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            BuscarProdutos();
        }
    }
}
