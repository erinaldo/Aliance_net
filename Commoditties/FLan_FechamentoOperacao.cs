using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Estoque.Cadastros;

namespace Commoditties
{
    public partial class TFLan_FechamentoOperacao : FormPadrao.FFormPadrao
    {
        //private bool Altera_Relatorio = false;
        public TFLan_FechamentoOperacao()
        {
            InitializeComponent();
            pDados.set_FormatZero();
            grid_NFSaida.ReadOnly = false;
            BS_TotaisContrato.AddNew();
        }

        public override int buscarRegistros()
        {
            if (TC_SaldoSintetico.SelectedTab == tabSaldoContrato)
            {
                //BUSCA OS CONTRATOS
                TList_CadContratoHeadge lista = TCN_LanFechamentoOperacao.BuscarContrato(nr_contrato_venda.Text.Equals("") ? 0 : Convert.ToDecimal(nr_contrato_venda.Text),
                                                                                         cd_empresa.Text,
                                                                                         AnoSafra.Text,
                                                                                         nr_pedido.Text.Equals("") ? 0 : Convert.ToDecimal(nr_pedido.Text),
                                                                                         CD_Produto.Text, 
                                                                                         cd_clifor.Text);

                if (lista != null)
                {
                    if (lista.Count > 0)
                        BS_SaldoContrato.DataSource = lista;
                    else
                        BS_SaldoContrato.Clear();
                    return lista.Count;
                }
            }
            else if (TC_NFS.SelectedTab == tabNFS && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabNFVenda)
            {
                //BUSCA AS NOTAS FISCAL DE SAIDA
                if (BS_SaldoContrato.Current != null)
                {
                    TList_CadNotaFiscalHeadge lista = TCN_LanFechamentoOperacao.BuscarNotaFiscal(Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato), 0);

                    if (lista != null)
                    {
                        if (lista.Count > 0)
                            BS_NFSaida.DataSource = lista;
                        else
                            BS_NFSaida.Clear();
                        return lista.Count;
                    }
                }
            }
            else if (TC_NFS.SelectedTab == tabDetalheNFS && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabNFVenda)
            {
                //BUSCA OS DETALHES DE NOTA FISCAL SAIDA
                if (BS_NFSaida.Current != null && BS_SaldoContrato.Current != null)
                {
                    TList_Lan_NFHeadge lista = TCN_Lan_NFHeadge.Buscar(0, 0, (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).CD_Empresa,
                                                                       (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal, (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem, 0, "");

                    if (lista != null)
                    {
                        if (lista.Count > 0)
                            BS_CustoVenda.DataSource = lista;
                        else
                            BS_CustoVenda.Clear();
                    }
                    
                    TList_Lan_NFHeadge listaTotais = TCN_Lan_NFHeadge.Buscar((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal);

                    if (listaTotais != null)
                    {
                        if (listaTotais.Count > 0)
                            BS_TotaisHeadgeCompra.DataSource = listaTotais;
                        else
                            BS_TotaisHeadgeCompra.Clear();
                    }
                }
            }
            else if ((TC_Originacao.SelectedTab == tabNFEntrada) && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabOriginacao)
            {
                //BUSCA AS NOTAS FISCAL DE ENTRADA
                if (BS_NFSaida.Current != null)
                {
                    TList_CadNotaFiscalHeadge lista = TCN_LanFechamentoOperacao.BuscarNotaFiscalEntrada((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).CD_Empresa,
                                                                                                        (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                                                        (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem);

                    if (lista != null)
                    {
                        if (lista.Count > 0)
                            BS_NFEntrada.DataSource = lista;
                        else
                            BS_NFEntrada.Clear();
                        return lista.Count;
                    }
                }
            }
            else if ((TC_Originacao.SelectedTab == tabDetalheNFE) && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabOriginacao)
            {
                //BUSCA OS DETALHES DA NOTA FISCAL DE ENTRADA
                if (BS_NFEntrada.Current != null && BS_SaldoContrato.Current != null)
                {
                    TList_Lan_NFHeadge lista = TCN_Lan_NFHeadge.Buscar(0, 0,
                                                                       (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).CD_Empresa,
                                                                       (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                       (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem,
                                                                       (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                       "SqlCodeBuscaCompra");

                    if (lista != null)
                    {
                        if (lista.Count > 0)
                            BS_CustoCompra.DataSource = lista;
                        else
                            BS_CustoCompra.Clear();
                        return lista.Count;
                    }
                }
            }

            return 0;
        }

        public override void afterBusca()
        {
            buscarRegistros();
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
        }

        public override void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                
                if (TC_SaldoSintetico.SelectedTab == tabSaldoContrato)
                {
                    //IMPRIME OS CONTRATOS
                    Relatorio.DTS_Relatorio = BS_SaldoContrato;
                    Relatorio.Ident = "TFFechaOperacao_SaldoSintetico";
                }
                else if (TC_NFS.SelectedTab == tabNFS && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabNFVenda)
                {
                    //IMPRIME AS NOTAS FISCAL DE SAIDA
                        Relatorio.DTS_Relatorio = BS_NFSaida;
                        Relatorio.Ident = "TFLan_FechamentoOperacao_NFSaida";
                }
                else if (TC_NFS.SelectedTab == tabDetalheNFS && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabNFVenda)
                {
                    //IMPRIME OS DETALHES DE NOTA FISCAL SAIDA
                    
                        Relatorio.DTS_Relatorio = BS_CustoVenda;
                        Relatorio.Adiciona_DataSource("BS_TOTAISHEADGECOMPRA", BS_TotaisHeadgeCompra);
                        Relatorio.Ident = "TFLan_FechamentoOperacao_DetalheNFSaida";
                }
                else if ((TC_Originacao.SelectedTab == tabNFEntrada) && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabOriginacao)
                {
                    //IMPRIME AS NOTAS FISCAL DE ENTRADA
                    
                        Relatorio.DTS_Relatorio = BS_NFEntrada;
                        Relatorio.Ident = "TFLan_FechamentoOperacao_NFEntrada";
                }
                else if ((TC_Originacao.SelectedTab == tabDetalheNFE) && TC_SaldoSintetico.SelectedTab == tabNotaFiscal && TC_NF.SelectedTab == tabOriginacao)
                {
                    //IMPRIME OS DETALHES DA NOTA FISCAL DE ENTRADA
                   
                        Relatorio.DTS_Relatorio = BS_CustoCompra;
                        Relatorio.Ident = "TFLan_FechamentoOperacao_DetalheNFEntrada";
                }
                
                Relatorio.NM_Classe = this.Name;
                Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                if (Altera_Relatorio)
                {
                    Relatorio.Gera_Relatorio(string.Empty,
                                             fImp.pSt_imprimir,
                                             fImp.pSt_visualizar,
                                             fImp.pSt_enviaremail,
                                             fImp.pSt_exportPdf,
                                             fImp.Path_exportPdf,
                                             fImp.pDestinatarios,
                                             null,
                                             "RELATORIO " + this.Text.Trim(),
                                             fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(string.Empty,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RELATORIO " + this.Text.Trim(),
                                                 fImp.pDs_mensagem);

            }
        }
        

        #region "FILTROS"

            private void nr_contrato_venda_Leave(object sender, EventArgs e)
            {
                if (cd_empresa.Text != "")
                {
                    string vParam = "a.nr_contrato|=|'" + nr_contrato_venda.Text + "';" +
                                    "a.cd_empresa|=|'" + cd_empresa.Text + "';" +
                                    "a.tp_movimento|=|'S'";

                    UtilPesquisa.EDIT_LEAVE(vParam,
                                            new Componentes.EditDefault[] { nr_contrato_venda },
                                            new TCD_CadContrato());
                }
            }

            private void BB_Contrato_Venda_Click(object sender, EventArgs e)
            {
                if (cd_empresa.Text != "")
                {
                    string vBusca = "a.nr_contrato|Número do Contrato|80;" +
                                    "a.cd_clifor|Cód. Clifor|80;" +
                                    "d.nm_clifor|Nome do Contrato|150;" +
                                    "a.cd_empresa|Cód. Empresa|80;" +
                                    "f.nm_empresa|Nome Empresa|150;" +
                                    "a.dt_abertura|Data Abertura|80;" +
                                    "a.tp_movimento|Tipo Movimento|80";

                    UtilPesquisa.BTN_BUSCA(vBusca,
                                           new Componentes.EditDefault[] { nr_contrato_venda },
                                           new TCD_CadContrato(), "a.tp_movimento|=|'S';a.cd_empresa|=|'" + cd_empresa.Text + "'");
                }
            }

            private void nr_contrato_compra_Leave(object sender, EventArgs e)
            {
                if (cd_empresa.Text != "")
                {
                    string vParam = "a.nr_contrato|=|'" + nr_contrato_compra.Text + "';" +
                                    "a.cd_empresa|=|'" + cd_empresa.Text + "';" +
                                    "a.tp_movimento|=|'E'";

                    UtilPesquisa.EDIT_LEAVE(vParam,
                                            new Componentes.EditDefault[] { nr_contrato_compra },
                                            new TCD_CadContrato());
                }
            }

            private void BB_Contrato_Compra_Click(object sender, EventArgs e)
            {
                if (cd_empresa.Text != "")
                {
                    string vBusca = "a.nr_contrato|Número do Contrato|80;" +
                                    "a.cd_clifor|Cód. Clifor|80;" +
                                    "d.nm_clifor|Nome do Contrato|150;" +
                                    "a.cd_empresa|Cód. Empresa|80;" +
                                    "f.nm_empresa|Nome Empresa|150;" +
                                    "a.dt_abertura|Data Abertura|80;" +
                                    "a.tp_movimento|Tipo Movimento|80";

                    UtilPesquisa.BTN_BUSCA(vBusca,
                                           new Componentes.EditDefault[] { nr_contrato_compra },
                                           new TCD_CadContrato(), "a.tp_movimento|=|'E';a.cd_empresa|=|'" + cd_empresa.Text + "'");
                }
            }

            private void bb_empresa_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
                    , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
            }

            private void cd_empresa_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
                            , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            }

            private void bb_pedido_Click(object sender, EventArgs e)
            {
                string vColunas = "a.NR_Pedido|Nº Pedido|80;" +
                                  "contrato.NR_Contrato|Nº Contrato|80;" +
                                  "a.CD_Clifor|Cód. Clifor|80;" +
                                  "clifor.NM_Clifor|Nome Clifor|350;" +
                                  "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                                  "b.CD_Produto|Cód. Produto|80;" +
                                  "d.DS_Produto|Descrição Produto|350;" +
                                  "contrato.TP_Natureza_Pesagem|Origem/Destino|100;" +
                                  "n.cfg_pedido|CFG. Pedido|100;" +
                                  "cfgped.ds_tipopedido|Tipo Pedido|100";

                string vParamFixo = "n.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = n.cd_empresa);" +
                                    "|EXISTS|(select 1 from vb_gro_contrato x " +
                                    "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem);" +
                                    "isnull(a.ST_Registro, 'A')|<>|'C'";
                UtilPesquisa.BTN_BUSCA(vColunas, 
                                        new Componentes.EditDefault[] { nr_pedido }, 
                                        new TCD_LanPedido_Item(), vParamFixo);
            }

            private void nr_pedido_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.nr_pedido|=|" + nr_pedido.Text + ";" +
                                  "n.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = n.cd_empresa);" +
                                    "|EXISTS|(select 1 from vtb_gro_contrato x " +
                                    "where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto and x.id_pedidoitem = a.id_pedidoitem);" +
                                    "isnull(a.ST_Registro, 'A')|<>|'C'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_pedido },
                                        new TCD_LanPedido_Item());
            }

            private void bb_clifor_Click(object sender, EventArgs e)
            {
                string vParamFixo = "";
                if (nr_pedido.Text.Trim() != "")
                    vParamFixo = "|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CD_Clifor = a.CD_Clifor and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, vParamFixo);
            }

            private void cd_clifor_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
                if (nr_pedido.Text.Trim() != "")
                    vColunas += ";|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CD_Clifor = a.CD_Clifor and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            }

            private void bbProduto_Click(object sender, EventArgs e)
            {                
                UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto },"");
            }

            private void Cd_Produto_Busca_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                        new TCD_CadProduto());
            }

            private void bb_AnoSafra_Click(object sender, EventArgs e)
            {
                string vColunas = "a.DS_Safra|Ano Safra|200;" +
                                  "a.Anosafra|Cd. Safra|80";
                string vParam = string.Empty;
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { AnoSafra },
                                        new CamadaDados.Graos.TCD_CadSafra(), vParam);
            }

            private void AnoSafra_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.anosafra|=|'" + AnoSafra.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { AnoSafra },
                                        new CamadaDados.Graos.TCD_CadSafra());
            }

        #endregion

        #region "ABA CONTRATO"

            private void grid_NFSaida_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
                if (grid_NFSaida.Columns[e.ColumnIndex].Name != "PS_Chegada_Grid")
                {
                    e.Cancel = true;
                }
            }

            private void grid_NFSaida_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if ((e.Value != null) && (BS_NFSaida != null))
                {
                    if (grid_NFSaida.Columns[e.ColumnIndex].Name == "PS_Chegada_Grid")
                    {
                        DataGridViewCell Celula = grid_NFSaida.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        Celula.Style.ForeColor = Color.Blue;
                    }
                }
            }

            private void grid_NFSaida_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                if (grid_NFSaida.Columns[e.ColumnIndex].Name == "PS_Chegada_Grid")
                {
                    //GRAVA O PS CHEGADA
                    TRegistro_Lan_Originacao reg_originacao = new TRegistro_Lan_Originacao();
                    reg_originacao.PS_Chegada = (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Ps_Chegada;
                    reg_originacao.ID_Originacao = (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).ID_Originacao;

                    //GRAVA
                    TCN_Lan_Originacao.GravarPSOriginacao(reg_originacao, (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge), Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato), null);

                    //BUSCA OS CUSTos
                    TList_Lan_NFHeadge ListaHeadge = TCN_Lan_NFHeadge.Buscar((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal, (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem, "SqlCodeBuscaLanctoHeadgeVenda", reg_originacao.PS_Chegada, (reg_originacao.PS_Chegada * ((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).VL_Subtotal / (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Quantidade)), reg_originacao.ID_Originacao);

                    if (ListaHeadge.Count > 0)
                    {
                        TCN_Lan_NFHeadge.GravarNFHeadge(ListaHeadge, null);
                    }

                    BS_NFSaida[BS_NFSaida.Position] = TCN_LanFechamentoOperacao.BuscarNotaFiscal( Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato), 
                                                                                                  Convert.ToDecimal((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal) )[0];
                }
            }

            private void BB_AlterarCustoHeadge_Click(object sender, EventArgs e)
            {
                if (BS_NFSaida.Current != null)
                {
                    TFLan_AlteracaoHeadge FLan_CustoHeadge = new TFLan_AlteracaoHeadge();

                    //DEFINE OS TITULOS
                    FLan_CustoHeadge.labelNr_Contrato.Text = Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato).ToString();
                    FLan_CustoHeadge.labelNr_Pedido.Text = (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_Pedido.ToString();
                    FLan_CustoHeadge.labelProduto.Text = (BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Cd_produto + " - " + (BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Ds_produto;

                    FLan_CustoHeadge.BS_LanctoNFHeadge.DataSource = TCN_Lan_NFHeadge.Buscar(0, 0, (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).CD_Empresa,
                                                                                            (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                                            (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem, 0, "");
                    if (FLan_CustoHeadge.ShowDialog() == DialogResult.OK)
                    {
                        if (FLan_CustoHeadge.ListaNFHeadge.Count > 0)
                        {
                            TCN_Lan_NFHeadge.AlterarNFHeadge(FLan_CustoHeadge.ListaNFHeadge, null);

                            BS_NFSaida[BS_NFSaida.Position] = TCN_LanFechamentoOperacao.BuscarNotaFiscal(Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato),
                                                                                                  Convert.ToDecimal((BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal))[0];
                        }

                    }

                    FLan_CustoHeadge.Dispose();
                }
            }

            private void BS_SaldoContrato_CurrentItemChanged(object sender, EventArgs e)
            {
                CalculaTotaisContrato();
            }

            private void CalculaTotaisContrato()
            {
                decimal totimpostocompra = 0;
                decimal totfretecompra = 0;
                decimal totcomissaocompra = 0;
                decimal totoutroscompra = 0;
                decimal totimpostovenda = 0;
                decimal totfretevenda = 0;
                decimal totcomissaovenda = 0;
                decimal totoutrosvenda = 0;
                decimal totvenda = 0;
                decimal totcompra = 0;
                decimal totvlcompra = 0;
                decimal totvlvenda = 0;

                for (int i = 0; i < grid_SaldoContrato.SelectedRows.Count; i++)
                {
                    totimpostocompra = totimpostocompra + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Imposto_Compra;
                    totimpostovenda = totimpostovenda + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Imposto_Venda;
                    totfretecompra = totfretecompra + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Frete_Compra;
                    totfretevenda = totfretevenda + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Frete_Venda;
                    totcomissaocompra = totcomissaocompra + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Comissao_Compra;
                    totcomissaovenda = totcomissaovenda + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Comissao_Venda;
                    totoutroscompra = totoutroscompra + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Outros_Compra;
                    totoutrosvenda = totoutrosvenda + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).Tot_Outros_Venda;
                    totvlvenda = totvlvenda + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).VL_Venda;
                    totvlcompra = totvlcompra + (BS_SaldoContrato[grid_SaldoContrato.SelectedRows[i].Index] as TRegistro_CadContratoHeadge).VL_Compra;

                    totcompra = totvlcompra  + (totcompra + totimpostocompra + totfretecompra + totcomissaocompra + totoutroscompra);
                    totvenda = totvlvenda - (totvenda + totimpostovenda + totfretevenda + totcomissaovenda + totoutrosvenda);
                }

                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalImpostoCompra = totimpostocompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalImpostoVenda= totimpostovenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalFreteCompra = totfretecompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalFreteVenda = totfretevenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalComissaoCompra = totcomissaocompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalComissaoVenda = totcomissaovenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalOutrosCompra = totoutroscompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalOutrosVenda = totoutrosvenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalCompra = totcompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalVenda = totvenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalVLVenda = totvlvenda;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalVLCompra = totvlcompra;

                //RESULTADOS
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulImposto = totimpostovenda + totimpostocompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulFrete = totfretevenda + totfretecompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulComissao = totcomissaovenda + totcomissaocompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulOutros = totoutrosvenda + totoutroscompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulTotCompraVenda = totvenda - totcompra;
                (BS_TotaisContrato.Current as TRegistro_CadTotaisContratoHeadge).TotalResulVLCompraVenda = totvlvenda - totvlcompra;
                BS_TotaisContrato.ResetBindings(true);
            }

        #endregion

        #region "ORIGINACAO"

            private void tabOriginacao_Enter(object sender, EventArgs e)
            {
                TC_Originacao.SelectedTab = tabNFEntrada;
                tabNFEntrada_Enter(this, e);
            }

            private void tabNFEntrada_Enter(object sender, EventArgs e)
            {
                if (BS_NFSaida.Current != null)
                    buscarRegistros();
            }

        #endregion

        #region "DETALHE NF SAIDA"

            private void tabNFVenda_Enter(object sender, EventArgs e)
            {
                TC_NFS.SelectedTab = tabNFS;
                tabNFS_Enter(this, e);
            }

            private void tabNotaFiscal_Enter(object sender, EventArgs e)
            {
                TC_NF.SelectedTab = tabNFVenda;
                tabNFVenda_Enter(this, e);
            }

            private void tabDetalheNFS_Enter(object sender, EventArgs e)
            {
                if (BS_NFSaida.Current != null)
                    buscarRegistros();
            }

            private void tabNFS_Enter(object sender, EventArgs e)
            {
                if (BS_SaldoContrato.Current != null)
                    buscarRegistros();
            }

        #endregion

        #region "DETALHE NF ORIG"

            private void tabDetalheNFE_Enter(object sender, EventArgs e)
            {
                if (BS_NFEntrada.Current != null)
                    buscarRegistros();
            }

            private void BB_AlterarCustoOrig_Click(object sender, EventArgs e)
            {
                if (BS_NFEntrada.Current != null)
                {
                    TFLan_AlteracaoHeadge FLan_CustoHeadge = new TFLan_AlteracaoHeadge();

                    //DEFINE OS TITULOS
                    FLan_CustoHeadge.labelNr_Contrato.Text = Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato).ToString();
                    FLan_CustoHeadge.labelNr_Pedido.Text = (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).Nr_Pedido.ToString();
                    FLan_CustoHeadge.labelProduto.Text = (BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Cd_produto + " - " + (BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Ds_produto;

                    FLan_CustoHeadge.BS_LanctoNFHeadge.DataSource = TCN_Lan_NFHeadge.Buscar(0, 0, (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).CD_Empresa,
                                                                                            (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                                            (BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).ID_NFItem,
                                                                                            (BS_NFSaida.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal,
                                                                                            "SqlCodeBuscaCompra");
                    if (FLan_CustoHeadge.ShowDialog() == DialogResult.OK)
                    {
                        if (FLan_CustoHeadge.ListaNFHeadge.Count > 0)
                        {
                            TCN_Lan_NFHeadge.AlterarNFHeadge(FLan_CustoHeadge.ListaNFHeadge, null);

                            BS_NFEntrada[BS_NFEntrada.Position] = TCN_LanFechamentoOperacao.BuscarNotaFiscal(Convert.ToDecimal((BS_SaldoContrato.Current as TRegistro_CadContratoHeadge).Nr_contrato),
                                                                                                  Convert.ToDecimal((BS_NFEntrada.Current as TRegistro_CadNotaFiscalHeadge).Nr_LanctoFiscal))[0];
                        }

                    }

                    FLan_CustoHeadge.Dispose();
                }
            }

        #endregion

        private void TFLan_FechamentoOperacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_CustoCompra);
            Utils.ShapeGrid.RestoreShape(this, grid_CustoVenda);
            Utils.ShapeGrid.RestoreShape(this, grid_NFEntrada);
            Utils.ShapeGrid.RestoreShape(this, grid_NFSaida);
            Utils.ShapeGrid.RestoreShape(this, grid_SaldoContrato);
            Utils.ShapeGrid.RestoreShape(this, grid_TotaisCompra);
            Utils.ShapeGrid.RestoreShape(this, grid_TotaisVenda);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            BB_Imprimir.Visible = true;
        }

        private void TFLan_FechamentoOperacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_CustoCompra);
            Utils.ShapeGrid.SaveShape(this, grid_CustoVenda);
            Utils.ShapeGrid.SaveShape(this, grid_NFEntrada);
            Utils.ShapeGrid.SaveShape(this, grid_NFSaida);
            Utils.ShapeGrid.SaveShape(this, grid_SaldoContrato);
            Utils.ShapeGrid.SaveShape(this, grid_TotaisCompra);
            Utils.ShapeGrid.SaveShape(this, grid_TotaisVenda);
        }

    }
}
