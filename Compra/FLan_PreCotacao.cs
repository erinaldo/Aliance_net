using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Querys;
using Querys.Financeiro;
using Utils;
using Querys.Estoque;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Compra.Lancamento;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Compra;
using CamadaDados.Compra;
using System.Collections;
using Componentes;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFLanCotacao : FormPadrao.FFormPadrao
    {
        private FormRelPadrao.Relatorio Relatorio;
        private TList_LanCMP_Requisicao requisicoes = new TList_LanCMP_Requisicao();

        public TFLanCotacao()
        {
            InitializeComponent();
            buscarRegistros();
            formatZero();
            ID_Requisicao_busca.Focus();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
            pDadosButtonImprimir.set_FormatZero();
            pDadosFornecedor.set_FormatZero();
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if ((ID_Requisicao_busca.Text.Trim().Length > 0) || (CD_Grupo.Text.Trim().Length > 0))
                {
                    TList_LanCMP_Requisicao lista = TCN_LanCMP_Requisicao.Busca(ID_Requisicao_busca.Text.Equals("") ? 0M : Convert.ToDecimal(ID_Requisicao_busca.Text),
                        "", "", Cd_Produto_Busca.Text, ST_Aguardando.Checked ? "S" : "N", ST_Aguardando.Checked ? "S" : "N", "", ST_Negociacao.Checked ? "S" : "N", "", "", "", "", "", "", CD_Grupo.Text, false, false);
                    if (lista != null)
                    {
                        if (lista.Count > 0)
                        {
                            BS_Requisicoes.DataSource = lista;
                        }
                        else
                        {
                            BS_Requisicoes.Clear();
                        }

                        //ID_Requisicao_busca.Focus();
                        return lista.Count;
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 1)
            {
                string[] IDsRequisicao = new string[grid_Requisicoes.SelectedRows.Count];
                for (int i = 0; i < grid_Requisicoes.SelectedRows.Count; i++)
                {
                    IDsRequisicao[i] = ((TRegistro_LanCMP_Requisicao)grid_Requisicoes.SelectedRows[i].DataBoundItem).ID_RequisicaoString;
                }

                TList_Cad_Fornecedor_X_GrupoItem lista = TCN_Cad_Fornecedor_X_GrupoItem.Busca(CD_Fornecedor.Text, 
                                                                                              CD_Grupo.Text, 
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_Fornecedores.DataSource = lista;
                    }
                    else
                    {
                        BS_Fornecedores.Clear();
                    }

                    //CD_Empresa.Focus();
                    return lista.Count;
                }
            }
            return 0;
        }

        public override void afterNovo()
        {
            //base.afterNovo();
            pDados.LimparRegistro();
            pDadosCotacao.LimparRegistro();
            pDadosFornecedor.LimparRegistro();
            pDadosButtonImprimir.LimparRegistro();
            BS_Cotacao_Item.Clear();
            BS_Empresa.Clear();
            BS_Fornecedor_Imprimir.Clear();
            BS_Fornecedores.Clear();
            BS_Requisicoes.Clear();
            ID_Requisicao_busca.Enabled = true;
            CD_Grupo.Enabled = true;
            bb_Requisicao.Enabled = true;
            bb_Grupo.Enabled = true;
            tcCentral.SelectedIndex = 0;
            ID_Requisicao_busca.Focus();
            ST_Aguardando.Checked = true;
            ST_Negociacao.Checked = true;
        }

        public override void afterBusca()
        {
            buscarRegistros();

            if (tcCentral.SelectedIndex == 1)
            {
                if (BS_Fornecedores.Count <= 0)
                {
                    if (MessageBox.Show("Não existe nenhum fornecedor para este Grupo de produto, Deseja continuar assim mesmo?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        tcCentral.SelectedIndex = 0;
                    }
                }
            }
        }

        # region "ABA 1"

            private void CD_Grupo_Click(object sender, EventArgs e)
            {
                string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                                  "a.CD_Grupo|Cód. Grupo|100";

                string vParamFixo = "a.TP_Grupo|=|'A'";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                        new TDatGrupoProduto(), vParamFixo);
                if (CD_Grupo.Text != "")
                {
                    buscarRegistros();
                }
                else
                {
                    pDados.LimparRegistro();
                }
            }

            private void CD_Grupo_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                                  "a.TP_Grupo|=|'A'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                        new TDatGrupoProduto());

                if (CD_Grupo.Text != "")
                {
                    buscarRegistros();
                }
                else
                {
                    pDados.LimparRegistro();
                }
            }

            private void bb_Requisicao_Click(object sender, EventArgs e)
            {
                string vColunas = "ID_Requisicao|Código Requisição|80;" +
                                  "a.cd_produto|Produto|350;" +
                                  "b.ds_produto|Produto|350;" +
                                  "a.cd_clifor_requisitante|Clifor Requisitante|80;" +
                                  "NM_clifor_requisitante|Clifor Requisitante|350;" +
                                  "Dt_Requisicao|Data Requisição|50;" +
                                  "gru.CD_Grupo|Cód. Grupo Produto|80;" +
                                  "gru.DS_Grupo|Grupo Produto|350";

                string vParam = "a.ST_Requisicao|=|'AA'";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Requisicao_busca, CD_Clifor_Busca, NM_Clifor_Busca, Cd_Produto_Busca, Ds_Produto_Busca, DT_Requisicao_Busca, CD_Grupo, DS_Grupo },
                                        new TCD_LanCMP_Requisicao(), vParam);
                if (ID_Requisicao_busca.Text != "")
                {
                    buscarRegistros();
                }
                else
                {
                    pDados.LimparRegistro();
                }
            }

            private void ID_Requisicao_busca_Leave(object sender, EventArgs e)
            {
                string vColunas = "ID_Requisicao|=|'" + ID_Requisicao_busca.Text + "';" +
                                  "a.ST_Requisicao|=|'AA'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Requisicao_busca, CD_Clifor_Busca, NM_Clifor_Busca, Cd_Produto_Busca, Ds_Produto_Busca, DT_Requisicao_Busca, CD_Grupo, DS_Grupo },
                                        new TCD_LanCMP_Requisicao());
                if (ID_Requisicao_busca.Text != "")
                {
                    buscarRegistros();
                }
                else
                {
                    pDados.LimparRegistro();
                }
            }

        # endregion

        # region "ABA 2"

            private void tabFornecedores_Enter(object sender, EventArgs e)
            {
                if (grid_Requisicoes.SelectedRows.Count > 0)
                {
                    //BUSCA AS REQUISIÇOES SELECIONADAS
                    requisicoes = new TList_LanCMP_Requisicao();
                    TRegistro_LanCMP_Requisicao reg_requisicoes = new TRegistro_LanCMP_Requisicao();
                    for (int i = 0; i < grid_Requisicoes.SelectedRows.Count; i++)
                    {
                        reg_requisicoes = (TRegistro_LanCMP_Requisicao)grid_Requisicoes.SelectedRows[i].DataBoundItem;
                        requisicoes.Add(reg_requisicoes);
                    }
                    buscarRegistros();

                    bb_GerarPreCotacao.Enabled = true;
                    bb_ImprimirPreCotacao.Enabled = false;
                    BS_Fornecedor_Imprimir.Clear();
                    pDadosButtonImprimir.LimparRegistro();

                    CD_Empresa.Focus();
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("Atenção, é necessário selecionador ao menos uma requisição!");
                }
            }

            private void bb_Clifor_Click(object sender, EventArgs e)
            {
                //a.CD_Clifor, a.CD_Grupo, b.NM_Clifor, c.DS_Grup
                string vColunas = "a.CD_Clifor|Código Fornecedor|80;" +
                                  "b.NM_Clifor|Fornecedor|350;" +
                                  "a.CD_Grupo|Cód. Grupo|80;" +
                                  "c.DS_Grupo|Grupo Produto|350";

                string vParam = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                                "b.st_fornecedor|=|'S'";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Fornecedor, NM_Fornecedor },
                                        new TCD_Cad_Fornecedor_X_GrupoItem(), vParam);

                if (!CD_Fornecedor.Text.Equals(""))
                    buscarRegistros();
            }

            private void CD_Fornecedor_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + CD_Fornecedor.Text + "';" +
                                  "a.CD_Grupo|=|'" + CD_Grupo.Text + "';"+
                                  "b.st_fornecedor|=|'S'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Fornecedor, NM_Fornecedor },
                                        new TCD_Cad_Fornecedor_X_GrupoItem());

                if (!CD_Fornecedor.Text.Equals(""))
                    buscarRegistros();
            }

        # endregion

        # region "ABA 3"

            private void tabCotacao_Enter(object sender, EventArgs e)
            {
                if (grid_Fornecedores.SelectedRows.Count > 0)
                {
                    CD_Empresa.Focus();
                }
                else
                {
                    tcCentral.SelectedIndex = 1;
                    MessageBox.Show("Atenção, é necessário selecionador ao menos um fornecedor!");
                }
            }

            private void bb_ImprimirPreCotacao_Click(object sender, EventArgs e)
            {
                if (CD_Empresa.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Atenção, é necessário informar uma empresa!");
                    CD_Empresa.Focus();
                }
                else if (CD_CondPGTO.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Atenção, é necessário informar uma condição de pagamento!");
                    CD_CondPGTO.Focus();
                }
                else
                {
                    if (grid_Fornecedores_Imprimir.SelectedRows.Count > 0)
                    {
                        buscaEmpresa();
                        TRegistro_Cad_Fornecedor_X_GrupoItem reg_Imprimir = new TRegistro_Cad_Fornecedor_X_GrupoItem();
                        for (int i = 0; i < grid_Fornecedores_Imprimir.SelectedRows.Count; i++)
                        {
                            Relatorio = new FormRelPadrao.Relatorio();
                            reg_Imprimir = (TRegistro_Cad_Fornecedor_X_GrupoItem)grid_Fornecedores_Imprimir.SelectedRows[i].DataBoundItem;
                            Relatorio.Parametros_Relatorio.Add("NM_FORNECEDOR", reg_Imprimir.NM_Clifor);
                            Relatorio.Parametros_Relatorio.Add("CONDPGTO", DS_CondPGTO.Text);
                            Relatorio.Parametros_Relatorio.Add("IDCOTACAO", (BS_Cotacao_Item.Current as TRegistro_LanCotacao_Item).ID_Cotacao);
                            Relatorio.Parametros_Relatorio.Add("OBSERVACAO", Observacao.Text);
                            buscaFornecedor(reg_Imprimir.CD_Clifor);

                            ImprimeRelatorio(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atenção, é necessário selecionar um registro para fazer a impressão!");
                        CD_Empresa.Focus();
                    }
                }
            }

            private void bb_GerarPreCotacao_Click(object sender, EventArgs e)
            {
                if ((BS_Cotacao_Item.Current == null))
                {
                    if (CD_Empresa.Text.Trim().Length <= 0)
                    {
                        MessageBox.Show("Atenção, é necessário informar a empresa responsável!");
                        CD_Empresa.Focus();
                    }
                    else if (CD_CondPGTO.Text.Trim().Length <= 0)
                    {
                        MessageBox.Show("Atenção, é necessário informar uma condição de pagamento!");
                        CD_CondPGTO.Focus();
                    }
                    else
                    {
                        //BUSCA OS FORNECEDORES SELECIONADOS
                        TList_Cad_Fornecedor_X_GrupoItem fornecedores = new TList_Cad_Fornecedor_X_GrupoItem();
                        TRegistro_Cad_Fornecedor_X_GrupoItem reg_fornecedores = new TRegistro_Cad_Fornecedor_X_GrupoItem();
                        for (int i = 0; i < grid_Fornecedores.SelectedRows.Count; i++)
                        {
                            reg_fornecedores = (TRegistro_Cad_Fornecedor_X_GrupoItem)grid_Fornecedores.SelectedRows[i].DataBoundItem;
                            fornecedores.Add(reg_fornecedores);
                        }

                        //pega o retorno do lançamento da cotação
                        string retorno = TCN_LanCotacao.LancaCotacao(requisicoes, fornecedores, CD_CondPGTO.Text);
                        //busca o BIND dos itens da cotação
                        buscaItemsCotacao(Convert.ToDecimal(Querys.TDataQuery.getPubVariavel(retorno, "@P_ID_Cotacao")));
                        BS_Fornecedor_Imprimir.DataSource = fornecedores;
                        BS_Fornecedor_Imprimir.ResetBindings(true);

                        //MUDA O STATUS DA REQUISICAO
                        (BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao = "NG";
                        BS_Requisicoes.ResetBindings(true);

                        bb_GerarPreCotacao.Enabled = false;
                        bb_ImprimirPreCotacao.Enabled = true;
                    }
                }
            }

            private void bb_CancelarPreCotacao_Click(object sender, EventArgs e)
            {
                afterNovo();
            }

            private void bb_CondPGTO_Click(object sender, EventArgs e)
            {
                string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                                  "a.CD_CondPgto|Cód. CondPgto|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO },
                                        new TDatCondPgto(), "");
            }

            private void CD_CondPGTO_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_CondPgto|=|'" + CD_CondPGTO.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{CD_CondPGTO,
                                    DS_CondPGTO }, new TDatCondPgto());
            }

            private void bb_Empresa_Click(object sender, EventArgs e)
            {
                string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                                  "a.CD_Empresa|Cód. Empresa|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                        new TCD_CadEmpresa(), "");
            }

            private void CD_Empresa_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Empresa |=|'" + CD_Empresa.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                        new TCD_CadEmpresa());
            }

        # endregion

        private void selecionarTodosItemsGrid(CheckBox botao, Componentes.DataGridDefault grid)
        {
            if (botao.Checked)
            {
                grid_Fornecedores.SelectAll();
                botao.Text = "Desmarcar Todos";
            }
            else
            {
                grid_Fornecedores.Rows[0].Selected = true;
                botao.Text = "Marcar Todos";
            }
        }

        private void buscaItemsCotacao(decimal ID_Cotacao)
        {
            TList_LanCotacao_Item listaCotacaoItem = TCN_LanCotacao_Item.Busca(ID_Cotacao, "", 0M, "");
            if (listaCotacaoItem != null)
            {
                if (listaCotacaoItem.Count > 0)
                {
                    BS_Cotacao_Item.DataSource = listaCotacaoItem;
                    PopulaDetalhesRequisicao();
                }
                else
                {
                    BS_Cotacao_Item.Clear();
                }
            }
        }

        /*
         * MÉTODO PARA POPULAR OS DETALHES DA REQUISIÇÃO
         */
        public void PopulaDetalhesRequisicao()
        {
            if (BS_Cotacao_Item != null && BS_Cotacao_Item.Count > 0)
            {
                TList_LanCotacao_Item cotacao_item = (TList_LanCotacao_Item)BS_Cotacao_Item.DataSource;
                for (int i = 0; i < cotacao_item.Count; i++)
                {
                    TList_LanCMP_Requisicao lRequisicao = TCN_LanCMP_Requisicao.Busca(cotacao_item[i].ID_Requisicao, "", "", "", "", "", "", "", "", "", "", "", "", "", "", false, false);

                    cotacao_item[i].listaRequisicao = lRequisicao;
                }

                BS_Cotacao_Item.DataSource = cotacao_item;
                BS_Cotacao_Item.ResetBindings(true);
            }
        }

        /*
         * MÉTODO PARA BUSCAR A EMPRESA PARA A IMPRESSÃO DA COTAÇÃO
         */
        private void buscaEmpresa()
        {
            TList_CadEmpresa listaEmpresa = TCN_CadEmpresa.Busca(CD_Empresa.Text, "", "", null);
            if (listaEmpresa != null)
            {
                if (listaEmpresa.Count > 0)
                {
                    BS_Empresa.DataSource = listaEmpresa;
                }
                else
                {
                    BS_Empresa.Clear();
                }
            }
        }

        private void buscaFornecedor(string ID_Fornecedor)
        {

            TList_CadClifor listaClifor = TCN_CadClifor.Busca_Clifor(ID_Fornecedor, "", "", "", "", "", "", "", true, false, false, false, "", 0);
            if (listaClifor != null)
            {
                if (listaClifor.Count > 0)
                {                    
                    listaClifor[0].List_PF = TCN_CadClifor_PF.Buscar_Clifor_PF(listaClifor[0].CD_Clifor, "", 0, null);
                    listaClifor[0].List_PJ = TCN_CadClifor_PJ.Busca_Clifor_PJ(listaClifor[0].CD_Clifor, "", 0, null);
                    listaClifor[0].lEndereco = TCN_CadEndereco.Buscar(listaClifor[0].CD_Clifor, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, null);
                    
                    BS_Dados_Fornecedor.DataSource = listaClifor;
                }
                else
                {
                    BS_Dados_Fornecedor.Clear();
                }
            }
        }

        private void ImprimeRelatorio(bool Altera_Relatorio)
        {
            Relatorio.Altera_Relatorio = Altera_Relatorio;
            
            ///ESTA PARTE VERIFICA PARA PREENCHER AUTOMATICAMENTE O TANTO DE LINHAS
            BindingSource bind = BS_Cotacao_Item;
            int totalProdutos = 28;
            TList_LanCotacao_Item cotacao_item = bind.DataSource as TList_LanCotacao_Item;

            //CONTA O TOTAL DE LINHAS PAR IMPRIMIR NO RELATÒRIO
            int totalLoop = (totalProdutos - bind.Count);

            for (int i = 0; i < bind.Count; i++)
            {
                TRegistro_LanCotacao_Item item = BS_Cotacao_Item[i] as TRegistro_LanCotacao_Item;
                if (item.listaRequisicao[0].lDetalheRequisicao.Count > 0)
                {
                    totalLoop = totalLoop - (item.listaRequisicao[0].lDetalheRequisicao.Count + 1);
                }
            }

            //SE FALTAR LINHAS IMPRIMI EM BRANCO
            if (totalLoop < totalProdutos)
            {
                for (int i = 0; i < totalLoop; i++)
                {
                    TRegistro_LanCotacao_Item item = new TRegistro_LanCotacao_Item();
                    TList_LanCMP_Requisicao lrequisicao = new TList_LanCMP_Requisicao();
                    TRegistro_LanCMP_Requisicao requisicao = new TRegistro_LanCMP_Requisicao();
                    lrequisicao.Add(requisicao);
                    item.DS_Produto = "";
                    //coloquei numeros absurdos para não cair no agrupamento
                    item.ID_Requisicao = Convert.ToDecimal(9999*i);
                    item.listaRequisicao = lrequisicao;
                    cotacao_item.Add(item);
                }

                bind.DataSource = cotacao_item;
                bind.ResetBindings(true);
            }

            Relatorio.DTS_Relatorio = bind;
            Relatorio.Nome_Relatorio = "TFLanCotacao";

            //ADICIONA UM NOVO DATA SOURCE AO RELATÓRIO
            Relatorio.Adiciona_DataSource("DTS_EMPRESA", BS_Empresa);
            Relatorio.Adiciona_DataSource("DTS_FORNECEDOR", BS_Dados_Fornecedor);
            Relatorio.Gera_Relatorio();
        }

        private void TFLanCotacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (tcCentral.SelectedIndex == 2)
            {
                if (e.KeyCode == Keys.F9 && (bb_GerarPreCotacao.Visible))
                {
                    bb_GerarPreCotacao_Click(null, null);
                }
                else if (e.KeyCode == Keys.F10 && (bb_CancelarPreCotacao.Visible))
                {
                    bb_CancelarPreCotacao_Click(null, null);
                }
                else if (e.KeyCode == Keys.F11 && (bb_ImprimirPreCotacao.Visible))
                {
                    bb_ImprimirPreCotacao_Click(null, null);
                }
                else if (e.KeyCode == Keys.F12 && (bb_EnviarPreCotacao.Visible))
                {
                    //bb_EnviarPreCotacao_Click(null, null);
                }
            }
        }

        private void grid_Requisicoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.Value != null) && (BS_Requisicoes != null))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("NG"))
                    {
                        DataGridViewRow Linha = grid_Requisicoes.Rows[e.RowIndex];
                        Linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
            catch
            {

            }
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_Produto_Busca, Ds_Produto_Busca }, "");
        }

    }
}
