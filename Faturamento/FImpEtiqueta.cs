using System;
using System.Windows.Forms;
using Utils;
using FormRelPadrao;
using System.Collections.Generic;

namespace Faturamento
{
    public partial class TFImpEtiqueta : Form
    {
        private bool Altera_Relatorio = false;
        private CamadaDados.Diversos.TRegistro_CadTerminal rTerminal;
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TList_CodBarra lItens
        { get; set; }

        public TFImpEtiqueta()
        {
            InitializeComponent();
            lItens = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
        }

        private void atualizarBsCodBarra()
        {
            if (bsCodBarra.Current == null || bsCodBarra.Count.Equals(0)) return;

            (bsCodBarra.DataSource as CamadaDados.Estoque.Cadastros.TList_CodBarra).ForEach(p =>
            {
                p.Vl_venda = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa.Text, p.Cd_produto, CD_TabelaPreco.Text, null);

                if (string.IsNullOrEmpty(p.Cd_codbarra))
                {
                    object obj = new CamadaDados.Estoque.Cadastros.TCD_CodBarra().BuscarEscalar(
                                    new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        }
                                }, "a.cd_codbarra");
                    p.Cd_codbarra = obj == null ? string.Empty : obj.ToString();
                }
            });
            bsCodBarra.ResetBindings(true);
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            if (bsCodBarra.Current != null)
            {
                if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("Z"))
                {
                    if (string.IsNullOrEmpty(rTerminal.Porta_imptick))
                    {
                        MessageBox.Show("Não existe porta configurada no cadastro do terminal <" + rTerminal.Cd_Terminal.Trim() + "-" + rTerminal.Ds_Terminal.Trim() + "> para imprimir etiqueta.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        if (rTerminal.Id_layout != decimal.Zero)
                        {
                            List<CamadaNegocio.Diversos.TRegistro_Objeto> obj = new List<CamadaNegocio.Diversos.TRegistro_Objeto>();

                            for (int j = 0; j < bsCodBarra.Count; j++)
                            {
                                if ((bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).agregar)
                                {
                                    obj.Add(new CamadaNegocio.Diversos.TRegistro_Objeto()
                                    {
                                        Codigo = Convert.ToDecimal((bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_produto),
                                        Produto = (bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Ds_produto.Trim(),
                                        Vl_preco = (bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Vl_venda,
                                        Cod_barra = (bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_codbarra,
                                        Qtd_etiqueta = Convert.ToInt32((bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Quantidade.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true)))
                                    });
                                }
                            }


                            CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.ImpEtiquetaLayout(obj,
                                                                rTerminal.Porta_imptick, rTerminal);
                        }
                        else
                            (bsCodBarra.DataSource as CamadaDados.Estoque.Cadastros.TList_CodBarra).ForEach(p =>
                            {
                                if (p.agregar)
                                {


                                    if (rTerminal.Id_layout != decimal.Zero)
                                    {
                                        int qtd_etiquetas = 1;

                                        qtd_etiquetas = Convert.ToInt32(p.Quantidade);


                                        CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.ImpEtiquetaLayout(decimal.Parse(p.Cd_produto.SoNumero()),
                                                                            p.Ds_produto.Trim(),
                                                                            p.Cd_codbarra,
                                                                            p.Vl_venda,
                                                                            qtd_etiquetas,
                                                                            rTerminal.Porta_imptick, rTerminal);
                                    }
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("1"))
                                        TEtiquetaZebra.ImpEtiquetaL1(p.Referencia,
                                                                    p.Ds_produto,
                                                                    p.Cd_codbarra,
                                                                    p.Vl_venda,
                                                                    rTerminal.Porta_imptick);
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("2"))
                                        TEtiquetaZebra.ImpEtiquetaL2(p.Cd_produto,
                                                                     p.Ds_produto,
                                                                     p.Vl_venda,
                                                                     rTerminal.Porta_imptick);
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("3"))
                                        TEtiquetaZebra.ImpEtiquetaL3(p.Cd_produto,
                                                                     p.Ds_produto,
                                                                     p.Cd_codbarra,
                                                                     p.Vl_venda,
                                                                     rTerminal.Porta_imptick);
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("4"))
                                        TEtiquetaZebra.ImpEtiquetaL4(p.Cd_produto + p.Ds_produto,
                                                                     p.Cd_codbarra,
                                                                     Convert.ToInt32(p.Quantidade),
                                                                     rTerminal.Porta_imptick);
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("5"))
                                        TEtiquetaZebra.ImpEtiquetaL5(p.Cd_produto + p.Ds_produto,
                                                                     p.Cd_codbarra,
                                                                     p.Vl_venda,
                                                                     Convert.ToInt32(p.Quantidade),
                                                                     rTerminal.Porta_imptick);
                                    else if (rTerminal.Layoutetiqueta.Trim().Equals("6"))
                                        TEtiquetaZebra.ImpEtiquetaL6(decimal.Parse(p.Cd_produto),
                                                                     p.Ds_produto,
                                                                     p.Cd_codbarra,
                                                                     p.Vl_venda,
                                                                     Convert.ToInt32(p.Quantidade),
                                                                     rTerminal.Porta_imptick);
                                }
                            });
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir etiqueta: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("A"))
                {
                    try
                    {
                        CamadaDados.Estoque.Cadastros.TList_CodBarra bar = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                        for (int j = 0; j < bsCodBarra.Count; j++)
                        {
                            if ((bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).agregar)
                            {
                                (bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Quantidade = 1;
                                bar.Add((bsCodBarra[j] as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra));
                            }
                        }
                        Relatorio Relatorio = new Relatorio();
                        Relatorio.Altera_Relatorio = Altera_Relatorio;

                        //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                        Relatorio.Nome_Relatorio = Name;
                        Relatorio.NM_Classe = Name;


                        BindingSource bs = new BindingSource();
                        bs.DataSource = bar;
                        Relatorio.DTS_Relatorio = bs;
                        Relatorio.Nome_Relatorio = "FLanEtiqueta";
                        Relatorio.NM_Classe = "FLanEtiqueta";
                        Relatorio.Ident = "FLanEtiqueta";
                        Relatorio.Modulo = "EST";
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pMensagem = ("ETIQUETAS PRODUTO GONDULA");
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio("Etiqueta",
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             ("ETIQUETAS PRODUTO GONDULA"),
                                                             fImp.pDs_mensagem);
                            }
                        }
                        else
                        {
                            Relatorio.Gera_Relatorio();
                            Altera_Relatorio = false;
                        }
                    }
                    catch { }

                }
                else
                if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("A"))
                {
                    CamadaDados.Estoque.Cadastros.TList_CodBarra lbar = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                    (bsCodBarra.DataSource as CamadaDados.Estoque.Cadastros.TList_CodBarra).ForEach(p =>
                    {
                        if (p.agregar)
                        {
                            p.Quantidade = 1;
                            lbar.Add(p);
                        }
                    });


                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = lbar;
                    Relatorio.DTS_Relatorio = bs;
                    //  Relatorio.Ident = "REL_CODBARRA_CADPRODUTO";// "FLanEtiqueta";
                    Relatorio.Nome_Relatorio = "FLanEtiqueta";
                    Relatorio.NM_Classe = "FLanEtiqueta";
                    Relatorio.Ident = "FLanEtiqueta";
                    Relatorio.Modulo = "EST";



                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pMensagem = ("PRODUTO Nº " + (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_produto);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio("Etiqueta",
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("PRODUTO Nº " + (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra)),
                                                         fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }


                }
                else
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = this.Altera_Relatorio;
                        Rel.Nome_Relatorio = "TFProduto";
                        Rel.NM_Classe = "TFProduto";
                        Rel.Ident = "REL_CODBARRA";
                        Rel.Modulo = "EST";
                        //Numero de copias
                        int copias = Convert.ToInt32(qtde.Value);
                        CamadaDados.Estoque.Cadastros.TList_CodBarra lCod = new CamadaDados.Estoque.Cadastros.TList_CodBarra();

                        (bsCodBarra.DataSource as CamadaDados.Estoque.Cadastros.TList_CodBarra).ForEach(p =>
                            {
                                for (int i = 0; i < p.Quantidade; i++)
                                    lCod.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                                    {
                                        Cd_codbarra = p.Cd_codbarra,
                                        Cd_produto = p.Cd_produto,
                                        Ds_produto = p.Ds_produto,
                                        Referencia = p.Referencia,
                                        Vl_venda = p.Vl_venda
                                    });
                            });
                        BindingSource bs = new BindingSource();
                        bs.DataSource = lCod;
                        Rel.DTS_Relatorio = bs;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "IMPRESSÃO ETIQUETA";

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
                                               "IMPRESSÃO ETIQUETA",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                            bsCodBarra.MoveNext();
                        }
                        else
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               null,
                                               fImp.pDestinatarios,
                                               "IMPRESSÃO ETIQUETA",
                                               fImp.pDs_mensagem);
                            bsCodBarra.MoveNext();
                        }
                    }
            }
        }

        private void TFImpEtiqueta_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            CD_Empresa.Text = pCd_empresa;
            NM_Empresa.Text = pNm_empresa;
            CD_Empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            bb_empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            bsCodBarra.DataSource = lItens;
            rTerminal = CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Utils.Parametros.pubTerminal, string.Empty, null)[0];
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
            atualizarBsCodBarra();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
            atualizarBsCodBarra();
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|100;a.cd_tabelapreco|Código|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
            atualizarBsCodBarra();
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
            atualizarBsCodBarra();
        }
        
        private void TFImpEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).agregar =
                    !(bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).agregar;
                bsCodBarra.ResetCurrentItem();
            }
        }
    }
}
