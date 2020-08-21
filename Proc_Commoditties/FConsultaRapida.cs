using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using System.Data.SqlClient;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Financeiro.Cadastros;
using Utils;
using CamadaDados.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Proc_Commoditties
{
    public partial class TFConsultaRapida : Form
    {

        public bool Altera_Relatorio = false;
        public TFConsultaRapida()
        {
            InitializeComponent();
        }

        public void afterNovo()
        {
            limpaCampos();
            ds_Produto.Focus();           

        }

        public void afterNovoClifor()
        {
            limpaCamposClifor();
            cd_Clifor.Focus();
        }

        public void limpaCampos()
        {
            ds_Produto.Clear();
            bs_ConsultaProduto.Clear();
            bs_ConsultaLocal.Clear();
            bsConsultaPrecoVenda.Clear();
            bsProduto.Clear();
            descComercial.Clear();
        }

        public void limpaCamposClifor()
        {
            cd_Clifor.Clear();
            cd_Endereco.Clear();
            endereco.Clear();
            bsConcultaClifor.Clear();
            bsConsultaCliforContato.Clear();
            cd_Clifor.Focus();
            tabControl1.SelectedIndex = 0;
        }
        
        public int buscarRegistrosClifor()
        {
            TList_ConsultaClifor lista = TCN_ConsultaProdutos.buscaClifor(cd_Clifor.Text);

            if (lista != null)
            {
                bsConcultaClifor.DataSource = lista;
                return lista.Count;
            }

            else
            {
                limpaCamposClifor();
                return 0;
            }
        }

        public int buscarRegistrosCliforContato()
        {
            TList_ConsultaClifor lista = TCN_ConsultaProdutos.buscaCliforContato(cd_Clifor.Text);


            if (lista != null)
            {
                bsConsultaCliforContato.DataSource = lista;
                return lista.Count;
            }

            else
            {
                limpaCamposClifor();
                return 0;
            }
        }

        public int buscarRegistrosCliforEndereco()
        {
            TList_ConsultaClifor lista = TCN_ConsultaProdutos.buscaCiforEndereco(cd_Clifor.Text);
            if (lista != null)
            {
                bsConsultaCliforEndereco.DataSource = lista;
                return lista.Count;
            }
            return 0;
        }
                
        public int buscarCliforUltimosFaturamentos(string tpMovimento)
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text))
            {
                string tp_Movimento = tpMovimento;
                TList_Pedido lista = TCN_ConsultaProdutos.buscaCliforUltimosFaturamentos(cd_Clifor.Text, 
                                                                                         Convert.ToInt32(top.Value), 
                                                                                         tp_Movimento);
                if (lista != null)
                {
                    bsConsultaCliforUltimosFaturamentos.DataSource = lista;
                    return lista.Count;
                }
                else return 0;
            }
            else return 0;

        }

        public int buscarCliforDadosBancarios()
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text))
            {
                TList_CadDados_Bancarios_Clifor lista = TCN_CadDados_Bancarios_Clifor.Busca(cd_Clifor.Text, 
                                                                                            string.Empty, 
                                                                                            string.Empty, 
                                                                                            string.Empty,
                                                                                            null);
                if (lista != null)
                {
                    bsCliforDadosBancarios.DataSource = lista;
                    return lista.Count;
                }
                else return 0;
            }
            else return 0;
            
        }

        public void buscasClifor()
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text))
            {
                buscarRegistrosClifor();
                buscarRegistrosCliforEndereco();
            }
            else
            {
                limpaCampos();
                limpaCamposClifor();
            }
        }

        public void Produtos()
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = string.Empty;
            filtro[1].vVL_Busca = "(a.cd_produto like '%" + ds_Produto.Text.Trim() + "') or " +
                                  "(a.ds_produto like " + (Utils.Parametros.ST_UtilizarCoringaEsq ? "'%" : "'") + ds_Produto.Text.Trim() + "%') or " +
                                  "(exists(select 1 from tb_est_codbarra x " +
                                  "           where x.cd_produto = a.cd_produto " +
                                  "           and x.cd_codbarra = '" + ds_Produto.Text.Trim() + "'))";
            if (!string.IsNullOrEmpty(cd_marca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_marca.Text;
                
            }
            bsProduto.DataSource = new TCD_CadProduto().Select(filtro, Utils.Parametros.pubTopMax, string.Empty, string.Empty, "a.ds_produto");
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void PrintFichaTec()
        {
            if (bsFichaTec.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_EST_FICHATECNICA";
                Relatorio.NM_Classe = "REL_EST_FICHATECNICA";
                Relatorio.Ident = "REL_EST_FICHATECNICA";

                //Buscar ficha tecnica produto
                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsProduto.Current as TRegistro_CadProduto).CD_Produto,
                                                                               string.Empty,
                                                                               null);
                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lFicha;
                Relatorio.DTS_Relatorio = bsFicha;

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsProduto.Current as TRegistro_CadProduto).CD_Produto,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + (bsProduto.Current as TRegistro_CadProduto).DS_Produto,
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

        private void BuscarVendaRapida()
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text))
            {
                bsVendaR.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + cd_Clifor.Text.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, string.IsNullOrEmpty(qtd_registros.Text) ? 50 : Convert.ToInt32(qtd_registros.Text),
                                        string.Empty,
                                        "a.dt_emissao desc");
                bsVendaR_PositionChanged(this, new EventArgs());
            }
            else
            {
                bsVendaR.Clear();
                bsVendaR.ResetBindings(true);
            }
        }

        private void BuscarUltItensVR()
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text))
                bsUltItensVR.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "vr.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + cd_Clifor.Text.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(vr.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, string.IsNullOrEmpty(qtd_ultitens.Text) ? 50 : Convert.ToInt32(qtd_ultitens.Text),
                                            string.Empty,
                                            "vr.dt_emissao desc");
            else bsUltItensVR.Clear();
        }

        private void TFConsultaProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (tbConsulta.SelectedIndex == 0)
                    afterNovo();
                else if (tbConsulta.SelectedIndex == 1)
                    limpaCamposClifor();
            }
            else if (e.KeyCode == Keys.F8)
            {
                if (tbConsulta.SelectedIndex == 0)
                    imprimirEtiquetaProduto();
                else if (tbConsulta.SelectedIndex == 1)
                    imprimirEtiquetaProduto();
            }
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void botaoNovo_Click(object sender, EventArgs e)
       {
           if (tbConsulta.SelectedIndex == 0)
           {
               afterNovo();
           }
           else if (tbConsulta.SelectedIndex == 1)
           {
               afterNovoClifor();
           }
       }

        private void bb_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_Clifor, nm_Clifor }, new TCD_CadClifor(), null);
            buscasClifor();
        }

        private void cd_Clifor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_Clifor.Text.Trim()))
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_Clifor.Text + "'"
                    , new Componentes.EditDefault[] { cd_Clifor, nm_Clifor }, new TCD_CadClifor());

                tabControl1.SelectedIndex = 0;
                buscasClifor();
            }
        }

        private void TFConsultaProdutos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gProduto);
            Utils.ShapeGrid.RestoreShape(this, gFicha);
            Utils.ShapeGrid.RestoreShape(this, gPrecoVenda);
            Utils.ShapeGrid.RestoreShape(this, gSaldoEstoque);
            Utils.ShapeGrid.RestoreShape(this, gUltimasCompras);
            Utils.ShapeGrid.RestoreShape(this, gVendasMes);
            Utils.ShapeGrid.RestoreShape(this, gEnderecos);
            Utils.ShapeGrid.RestoreShape(this, gContatos);
            Utils.ShapeGrid.RestoreShape(this, gPedidoEntrada);
            Utils.ShapeGrid.RestoreShape(this, gPedidoSaida);
            Utils.ShapeGrid.RestoreShape(this, gDadosBancarios);
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null))
            {
                lblVisualizarCustos.Visible = false;
                pVl_medio.Visible = false;
                pVl_ultimacompra.Visible = false;
                pVl_custoreal.Visible = false;
                Vl_ultimacompra.Visible = false;
            }
            tcProduto.TabPages.Remove(tpFichaTec);
            panelDados1.set_FormatZero();
            pCabProduto.set_FormatZero();
            ds_Produto.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(cd_Clifor.Text.Trim()))
                    buscarRegistrosCliforContato();
            }
            else if (tabControl1.SelectedIndex == 2)
                    buscarCliforUltimosFaturamentos("E");
            else if (tabControl1.SelectedIndex == 3)
                buscarCliforDadosBancarios();
        }

        private void tbMovimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMovimentos.SelectedIndex == 0)
                buscarCliforUltimosFaturamentos("E");
            else if (tbMovimentos.SelectedIndex == 1)
                buscarCliforUltimosFaturamentos("S");
            else if (tbMovimentos.SelectedIndex == 2)
            {
                BuscarVendaRapida();
                BuscarUltItensVR();
            }
        }
                
        private void vTop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (!string.IsNullOrEmpty(ds_Produto.Text.Trim()))
                    Produtos();
        }

        private void imprimirEtiquetaProduto()
        {
            if (bs_ConsultaProduto != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;

                    if (tbConsulta.SelectedIndex == 0)
                    {
                        Rel.DTS_Relatorio = bsProduto;
                        Rel.Parametros_Relatorio.Add("VLPRECO", (bsConsultaPrecoVenda.Current as TRegistro_LanPrecoItem).VL_PrecoVenda);
                        Rel.Adiciona_DataSource("BS_CONSULTAPRECOVENDA", bsConsultaPrecoVenda);
                    }
                    else
                        if (tbConsulta.SelectedIndex == 1)
                        {
                            Rel.DTS_Relatorio = bsConcultaClifor;
                            Rel.Adiciona_DataSource("BSCONSULTAENDERECO", bsConsultaCliforEndereco);
                            Rel.Ident = "TFConsultaProdutos_Clifor";

                        }

                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "EST";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
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
                            Rel.Gera_Relatorio(string.Empty,
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
        }

       private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (tbConsulta.SelectedIndex == 0)
                imprimirEtiquetaProduto();
            else if (tbConsulta.SelectedIndex == 1)
                imprimirEtiquetaProduto();
        }

       private void bsProduto_PositionChanged(object sender, EventArgs e)
       {
           if (bsProduto.Current != null)
           {
               //Dados Produto
               bs_ConsultaProduto.DataSource = TCN_ConsultaProdutos.busca((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
               //Buscar Ficha Tecnica
               (bsProduto.Current as TRegistro_CadProduto).lFicha = TCN_FichaTecProduto.Buscar((bsProduto.Current as TRegistro_CadProduto).CD_Produto,
                                                                                               string.Empty,
                                                                                               null);
               //Dados Estoque
               bs_ConsultaLocal.DataSource = TCN_ConsultaProdutos.buscaLocal(string.Empty, (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto); 
               //Preco Produto
               bsConsultaPrecoVenda.DataSource = TCN_ConsultaProdutos.buscaConsultaPreco(string.Empty,
                                                                                         (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                         string.Empty,
                                                                                         string.Empty);
           }
       }

       private void ds_Produto_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode.Equals(Keys.Enter))
               Produtos();
       }

       private void st_Kit_CheckedChanged(object sender, EventArgs e)
       {
           if (st_Kit.Checked)
           {
               if (!tcProduto.TabPages.Contains(tpFichaTec))
                   tcProduto.TabPages.Add(tpFichaTec);
           }
           else
           {
               if (tcProduto.TabPages.Contains(tpFichaTec))
                   tcProduto.TabPages.Remove(tpFichaTec);
           }
       }

       private void bb_custoprod_Click(object sender, EventArgs e)
       {
           if (bsProduto.Current != null)
               using (TFCustoProdComposto fCusto = new TFCustoProdComposto())
               {
                   fCusto.Cd_produto = (bsProduto.Current as TRegistro_CadProduto).CD_Produto;
                   fCusto.Ds_produto = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                   fCusto.ShowDialog();
               }
       }

       private void bb_imfichatec_Click(object sender, EventArgs e)
       {
           this.PrintFichaTec();
       }

       private void BB_Sair_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void cbMarca_DropDownClosed(object sender, EventArgs e)
       {
           Produtos();
       }

       private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
       {
           if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
               return;
           if (bsProduto.Count < 1)
               return;
           PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadProduto());
           TList_CadProduto lComparer;
           System.Windows.Forms.SortOrder direcao = System.Windows.Forms.SortOrder.None;
           if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.None) ||
               (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending))
           {
               lComparer = new TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), System.Windows.Forms.SortOrder.Ascending);
               foreach (DataGridViewColumn c in gProduto.Columns)
                   c.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
               direcao = System.Windows.Forms.SortOrder.Ascending;
           }
           else
           {
               lComparer = new TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), System.Windows.Forms.SortOrder.Descending);
               foreach (DataGridViewColumn c in gProduto.Columns)
                   c.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
               direcao = System.Windows.Forms.SortOrder.Descending;
           }
           (bsProduto.List as TList_CadProduto).Sort(lComparer);
           bsProduto.ResetBindings(false);
           gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
       }

       private void bb_marca_Click(object sender, EventArgs e)
       {
           string vColunas = "a.ds_marca|Marca Produto|200;" +
                             "a.cd_marca|Codigo|80";
           UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca, ds_marca },
                                    new TCD_CadMarca(), string.Empty);
           Produtos();
       }

       private void cd_marca_Leave(object sender, EventArgs e)
       {
           string vParam = "a.cd_marca|=|" + cd_marca.Text;
           UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marca, ds_marca },
                                    new TCD_CadMarca());
           Produtos();
       }

       private void TFConsultaRapida_FormClosing(object sender, FormClosingEventArgs e)
       {
           Utils.ShapeGrid.SaveShape(this, gProduto);
           Utils.ShapeGrid.SaveShape(this, gFicha);
           Utils.ShapeGrid.SaveShape(this, gPrecoVenda);
           Utils.ShapeGrid.SaveShape(this, gSaldoEstoque);
           Utils.ShapeGrid.SaveShape(this, gUltimasCompras);
           Utils.ShapeGrid.SaveShape(this, gVendasMes);
           Utils.ShapeGrid.SaveShape(this, gEnderecos);
           Utils.ShapeGrid.SaveShape(this, gContatos);
           Utils.ShapeGrid.SaveShape(this, gPedidoEntrada);
           Utils.ShapeGrid.SaveShape(this, gPedidoSaida);
           Utils.ShapeGrid.SaveShape(this, gDadosBancarios);
       }

       private void lblVisualizarCustos_Click(object sender, EventArgs e)
       {
           if (bsProduto.Current != null)
               using (TFCustoProduto fCusto = new TFCustoProduto())
               {
                   fCusto.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                   fCusto.pDs_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                   fCusto.pUnd = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade;
                   fCusto.ShowDialog();
               }
           else
               MessageBox.Show("Necessario selecionar produto para visualizar custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }

       private void qtd_registros_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
               e.Handled = true;
       }

       private void qtd_registros_Leave(object sender, EventArgs e)
       {
           if (string.IsNullOrEmpty(qtd_registros.Text))
               qtd_registros.Text = "50";
           this.BuscarVendaRapida();
       }

       private void bsVendaR_PositionChanged(object sender, EventArgs e)
       {
           if (bsVendaR.Current != null)
           {
               (bsVendaR.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).lItem =
                   CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar((bsVendaR.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Id_vendarapidastr,
                                                                             (bsVendaR.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).Cd_empresa,
                                                                             false,
                                                                             string.Empty,
                                                                             null);
               bsVendaR.ResetCurrentItem();
           }
       }

       private void qtd_ultitens_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
               e.Handled = true;
       }

       private void qtd_ultitens_Leave(object sender, EventArgs e)
       {
           if (string.IsNullOrEmpty(qtd_ultitens.Text))
               qtd_ultitens.Text = "50";
           this.BuscarUltItensVR();
       }
    }
}
