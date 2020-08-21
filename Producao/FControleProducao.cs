using CamadaDados.Faturamento.Pedido;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.Pedido;
using CamadaNegocio.Producao.Producao;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFControleProducao : Form
    {
        bool Altera_Relatorio = false;

        public TFControleProducao()
        {
            InitializeComponent();
        }

        private void ImprimirFichaProducao()
        {
            if (bsOrdemProduzir.Current != null)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).lSerie.Count > 0 &&
                    string.IsNullOrEmpty((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Nr_serie))
                    (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Nr_serie = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).lSerie[0].Nr_serie;
                BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = new TList_OrdemProducao { bsOrdemProduzir.Current as TRegistro_OrdemProducao };
                Relatorio.DTS_Relatorio = meu_bind;
                Relatorio.Ident = Name;
                //Buscar Ficha OP
                CamadaDados.Estoque.Cadastros.TList_FichaOP lFicha =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaOP.Buscar((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_produto,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       null);
                if (lFicha.Count > 0 && (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Dt_prevfinprod.HasValue)
                    lFicha.ForEach(p =>
                    {
                        decimal DiasProduzir = p.DiasPrevisao;
                        if (DiasProduzir > 0)
                        {
                            DateTime dt_ini = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Dt_prevfinprod.Value;
                            for (int i = 0; i < DiasProduzir; i++)
                            {
                                if (dt_ini.AddDays(-(i + 1)).DayOfWeek == DayOfWeek.Saturday ||
                                    dt_ini.AddDays(-(i + 1)).DayOfWeek == DayOfWeek.Sunday)
                                    DiasProduzir++;
                            }
                            p.Dt_prevProducao = dt_ini.AddDays(-Convert.ToDouble(DiasProduzir - 1));
                        }
                    });
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lFicha;
                Relatorio.Adiciona_DataSource("FICHAOP", bsFicha);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "OP Nº " + (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "OP Nº " + (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString(),
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void TFControleProducao_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltroOrdem.set_FormatZero();
            pFiltroEstoque.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
            bsProjetosEspeciais.DataSource = new TCD_PRD_ProdutoEntregar().SelectProjProgramar(cbEmpresa.SelectedValue.ToString(),
                                                                                               string.Empty,
                                                                                               string.Empty);
            bsPRDProdutoEntregar.DataSource = new TCD_PRD_ProdutoEntregar().SelectProjProduzir(cbEmpresa.SelectedValue.ToString(),
                                                                                               string.Empty,
                                                                                               string.Empty);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produtoordem }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produtoordem.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produtoordem }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo|150;a.cd_grupo|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupoordem }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupoordem.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupoordem }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }
        
        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPRDProduto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_PRD_Produto());
            TList_PRD_Produto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_PRD_Produto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_PRD_Produto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPRDProduto.List as TList_PRD_Produto).Sort(lComparer);
            bsPRDProduto.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bbAddOrdem_Click(object sender, EventArgs e)
        {
            using (TFOrdemProducao fOrdem = new TFOrdemProducao())
            {
                if (fOrdem.ShowDialog() == DialogResult.OK)
                    if (fOrdem.rOrdem != null)
                        try
                        {
                            for (int i = 0; i < fOrdem.rOrdem.Qt_replicarOP; i++)
                            {
                                TCN_OrdemProducao.Gravar(fOrdem.rOrdem, null);
                                fOrdem.rOrdem.Id_ordem = null;
                            }
                            MessageBox.Show("Ordem produção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bbBuscarOrdem_Click(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbProduzir_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
            {
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).St_registro.Trim().ToUpper() != "A")
                {
                    MessageBox.Show("Permitido INICIAR PRODUÇÃO somente de ordem com status ABERTA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    bool st_serie = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GERAR_SERIE_APONTAMENTO",
                        (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_empresa, null).Equals("S") &&
                        new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca{ vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_produto.Trim() + "'" },
                                new Utils.TpBusca{ vNM_Campo = "isnull(a.st_exigirserie, 'N')", vOperador = "=", vVL_Busca = "'S'" }
                            }, "1") != null;
                    if (st_serie)
                        using (TFSerieProduto fSerie = new TFSerieProduto())
                        {
                            object obj = new TCD_SerieProduto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                       vNM_Campo = "ISNUMERIC(a.nr_serie)",
                                       vOperador = "=",
                                       vVL_Busca = "1"
                                    }
                                }, "max(nr_serie)");
                            decimal numeroserie = decimal.Zero;
                            try
                            {
                                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                    numeroserie = decimal.Parse(obj.ToString());
                                for (int i = 0; (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir > i; i++)
                                    fSerie.lSerie.Add(new TRegistro_SerieProduto()
                                    {
                                        Cd_empresa = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_empresa,
                                        Cd_produto = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_produto,
                                        Ds_produto = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Ds_produto,
                                        Nr_serie = (numeroserie += 1).ToString()
                                    });
                            }
                            catch
                            {
                                fSerie.lSerie.Add(
                                    new TRegistro_SerieProduto
                                    {
                                        Cd_empresa = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_empresa,
                                        Cd_produto = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_produto,
                                        Ds_produto = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Ds_produto
                                    });
                            }
                            if (fSerie.ShowDialog() == DialogResult.OK)
                            {
                                if (fSerie.lSerie != null)
                                    if (fSerie.lSerie.Count > 0)
                                        (bsOrdemProduzir.Current as TRegistro_OrdemProducao).lSerie = fSerie.lSerie;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Nº Série!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    TCN_OrdemProducao.IniciarProducao(bsOrdemProduzir.Current as TRegistro_OrdemProducao, null);
                    if (st_serie)
                        ImprimirFichaProducao();
                    bbBuscarOrdem_Click(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    bbBuscarOrdem_Click(this, new EventArgs());
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bbApontar_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
            {
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Permitido apontar somente ordem com status <EM PRODUÇÃO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir <= 0)
                {
                    MessageBox.Show("Ordem Produção não tem saldo para apontamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFApontamentoProducao fApontamento = new TFApontamentoProducao())
                {
                    fApontamento.Id_ordem = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                    if (fApontamento.ShowDialog() == DialogResult.OK)
                        if (fApontamento.rApontamento != null)
                            try
                            {
                                TCN_ApontamentoProducao.Gravar2(fApontamento.rApontamento,
                                                                null);
                                MessageBox.Show("Apontamento Produção gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bbBuscarOrdem_Click(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_gerarFicha_Click(object sender, EventArgs e)
        {
            
        }

        private void bb_alterarFicha_Click(object sender, EventArgs e)
        {
            if (bsProjetosEspeciais.Current != null)
            {
                if ((bsProjetosEspeciais.Current as TRegistro_PRD_ProdutoEntregar).Vl_unitario > 0)
                {
                    MessageBox.Show("Não é possível alterar ficha de produto especial que possui preço na proposta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFFichaTecOrc fFicha = new TFFichaTecOrc())
                {
                    fFicha.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                    fFicha.pNr_orcamento = (bsProjetosEspeciais.Current as TRegistro_PRD_ProdutoEntregar).Nr_orcamento;
                    fFicha.pId_item = (bsProjetosEspeciais.Current as TRegistro_PRD_ProdutoEntregar).Id_item;
                    if (fFicha.ShowDialog() == DialogResult.OK)
                        if (fFicha.lFicha != null)
                            try
                            {
                                TCN_FichaTecOrcItem.GravarLista(fFicha.lFicha, null);
                                MessageBox.Show("Ficha Técnica gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
            }
        }

        private void bb_gerarOrdemProd_Click(object sender, EventArgs e)
        {
            if (bsPRDProdutoEntregar.Current != null)
            {
                if (MessageBox.Show("Deseja gerar a ordem de produção para o produto " +
                    (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Cd_produto.Trim() + "-" +
                    (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Ds_produto.Trim() + "?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        //Buscar Pedido
                        TList_Pedido lPedido =
                            new TCD_Pedido().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Nr_pedido.ToString()
                                    }
                                }, 1, string.Empty);
                        if (lPedido.Count > 0)
                        {
                            //Buscar Itens do Pedido
                            lPedido[0].Pedido_Itens =
                            new TCD_LanPedido_Item().Select(
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = lPedido[0].Nr_pedido.ToString()
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_pedidoitem",
                                    vOperador = "=",
                                    vVL_Busca =  (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Id_item.ToString()
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" +  (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Cd_produto.Trim() + "'"
                                }
                                }, 0, string.Empty, string.Empty, string.Empty);
                            lPedido[0].Pedido_Itens.ForEach(x =>
                            {
                                if ((bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Id_formulacao.HasValue)
                                {
                                    //Buscar ficha tecnica da formula
                                    TCN_FichaTec_MPrima.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                               (bsPRDProdutoEntregar.Current as TRegistro_PRD_ProdutoEntregar).Id_formulacao.Value.ToString(),
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               0,
                                                               string.Empty,
                                                               null).ForEach(v =>
                                                               {
                                                                   x.lFichaTec.Add(new TRegistro_FichaTecItemPed
                                                                   {
                                                                       Cd_item = v.Cd_produto,
                                                                       Cd_local = v.Cd_local,
                                                                       Cd_produto = x.Cd_produto,
                                                                       Cd_unditem = v.Cd_unid_produto,
                                                                       Id_pedidoitem = x.Id_pedidoitem,
                                                                       Nr_pedido = x.Nr_pedido,
                                                                       Quantidade = v.Qtd_produto
                                                                   });
                                                               });
                                }
                                else
                                {
                                    //Buscar Ficha Técnica do Pedido Item
                                    x.lFichaTec = new TCD_FichaTecItemPed().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = x.Nr_pedido.ToString()
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + x.Cd_produto.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_pedidoitem",
                                                    vOperador = "=",
                                                    vVL_Busca = x.Id_pedidoitem.ToString()
                                                }
                                            }, 0, string.Empty);
                                }
                            });
                            //Verificar se existe item na ficha técnica sem cadastro
                            if (lPedido[0].Pedido_Itens[0].lFichaTec.Exists(p => string.IsNullOrEmpty(p.Cd_item)))
                            {
                                using (TFFichaTecItemPed fItem = new TFFichaTecItemPed())
                                {
                                    fItem.rItem = lPedido[0].Pedido_Itens[0];
                                    if (fItem.ShowDialog() == DialogResult.OK)
                                        if (fItem.rItem != null)
                                            try
                                            {
                                                TCN_LanPedido_Item.GravaPedido_Item(fItem.rItem, null);
                                                MessageBox.Show("Itens alterados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                bb_gerarOrdemProd_Click(this, new EventArgs());
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        }
                        TCN_Pedido.GerarOrdemProducao(lPedido[0], null);
                        MessageBox.Show("Ordem de Produção gerada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarOrdem_Click(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbBuscarOrdem_Click(object sender, EventArgs e)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            Utils.Estruturas.CriarParametro(ref filtro, "(a.qtd_batch*a.qt_produto) - a.qtd_produzida", "0", ">");
            if (!string.IsNullOrEmpty(cd_produtoordem.Text))
                Utils.Estruturas.CriarParametro(ref filtro, "a.CD_Produto", "'" + cd_produtoordem.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(cd_grupoordem.Text))
                Utils.Estruturas.CriarParametro(ref filtro, "c.cd_grupo", "'" + cd_grupoordem.Text.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(nr_serie.Text))
                Utils.Estruturas.CriarParametro(ref filtro, string.Empty, "(select 1 from tb_prd_serieproduto x where x.id_ordem = a.id_ordem and x.nr_serie = '" + nr_serie.Text.Trim() + "')", "exists");
            if (cbStatus.SelectedIndex == 1)
                Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'A'");
            else if (cbStatus.SelectedIndex == 2)
                Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'P'");
            bsOrdemProduzir.DataSource = new TCD_OrdemProducao().Select(filtro, 0, string.Empty).OrderByDescending(p => p.Dt_prevfinprod).ToList();
        }

        private void bb_produtoestoque_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produtoestoque }, string.Empty);
        }

        private void cd_produtoestoque_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produtoestoque.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produtoestoque }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_grupoestoque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo|150;a.cd_grupo|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupoestoque }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupoestoque_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupoestoque.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupoestoque }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bbBuscarEstoque_Click(object sender, EventArgs e)
        {
            TList_PRD_Produto lista =
                 new TCD_PRD_Produto().Select(cbEmpresa.SelectedValue.ToString(),
                                             cd_produtoestoque.Text,
                                             cd_grupoestoque.Text);
            if (stSaldoAbaixoMinimo.Checked)
            {
                TList_PRD_Produto lProd = new TList_PRD_Produto();
                lista.FindAll(p => p.SD_Estoque < p.QT_Min_Estoque).ForEach(p => lProd.Add(p));
                bsPRDProduto.DataSource = lProd;
            }
            else
                bsPRDProduto.DataSource = lista;
        }

        private void alterarOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
            {
                if (!(bsOrdemProduzir.Current as TRegistro_OrdemProducao).Status.Equals("ABERTA"))
                {
                    MessageBox.Show("Apenas é possível alterar ordem de produção com sts. ABERTA.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (TFOrdemProducao fOrdem = new TFOrdemProducao())
                {
                    fOrdem.Text = "ALTERANDO ORDEM PRODUÇÃO Nº " + (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                    fOrdem.rOrdem = bsOrdemProduzir.Current as TRegistro_OrdemProducao;
                    if (fOrdem.ShowDialog() == DialogResult.OK)
                        if (fOrdem.rOrdem != null)
                            try
                            {
                                TCN_OrdemProducao.Gravar(fOrdem.rOrdem, null);
                                MessageBox.Show("Ordem Produção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bbBuscarOrdem_Click(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    bbBuscarOrdem_Click(this, new EventArgs());
                }
            }
        }

        private void excluirOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_OrdemProducao.Excluir(bsOrdemProduzir.Current as TRegistro_OrdemProducao, null);
                        MessageBox.Show("Ordem Produção excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarOrdem_Click(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void estornarIniProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Status.Trim().ToUpper().Equals("EM PRODUÇÃO"))
                    try
                    {
                        TCN_OrdemProducao.EstornarIniProducao(bsOrdemProduzir.Current as TRegistro_OrdemProducao, null);
                        MessageBox.Show("Inicio produção estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bbBuscarOrdem_Click(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else MessageBox.Show("Permitido estornar somente ordem com status <EM PRODUÇÃO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void verificarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
                if ((bsOrdemProduzir.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir > decimal.Zero)
                    using (Proc_Commoditties.TFDisponibilidadeMPrima fDisponibilidade = new Proc_Commoditties.TFDisponibilidadeMPrima())
                    {
                        fDisponibilidade.pCd_empresa = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_empresa;
                        fDisponibilidade.pCd_produto = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_produto;
                        fDisponibilidade.pCd_unidade = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Cd_unidade;
                        fDisponibilidade.pId_formulacao = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_formulacaostr;
                        fDisponibilidade.pDs_formula = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Ds_formula;
                        fDisponibilidade.pId_ordem = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Id_ordem.ToString();
                        fDisponibilidade.pQtd_programada = (bsOrdemProduzir.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir;

                        fDisponibilidade.ShowDialog();
                    }
                else
                    MessageBox.Show("Ordem produção não possui saldo para produzir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gerarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemProduzir.Current != null)
            {
                bbBuscarOrdem_Click(this, new EventArgs());
                ImprimirFichaProducao();
            }
        }

        private void TFControleProducao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
