using System;
using System.Collections.Generic;
using FormRelPadrao;
using System.Data;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Estoque.Cadastros;

namespace Estoque
{
    public partial class TFEtiqueta : Form
    {
        private TList_CodBarra lista = new TList_CodBarra();
        private CamadaDados.Diversos.TRegistro_CadTerminal rTerminal;
        bool Altera_Relatorio = false;
        private string pId_caracteristica { get; set; }
        private string Referencia = string.Empty;
        private string pCd_tabelapreco { get; set; } = string.Empty;
        public TFEtiqueta()
        {
            InitializeComponent();
        }

        private void VerificarGrade()
        {
            if (!string.IsNullOrEmpty(pId_caracteristica))
                using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                {
                    fGrade.pId_caracteristica = pId_caracteristica;
                    fGrade.pCd_empresa = cbEmpresa.SelectedValue.ToString(); ;
                    fGrade.pCd_produto = CD_Produto.Text;
                    fGrade.pDs_produto = ds_produto.Text;
                    fGrade.pTp_movimento = "E";
                    fGrade.pQuantidade = Quantidade.Value;
                    if (fGrade.ShowDialog() == DialogResult.OK)
                    {
                        fGrade.lGrade.ForEach(p => GerarCodBarra(p));
                        panelDados3.LimparRegistro();
                        bsCodBarra.ResetCurrentItem();
                        pId_caracteristica = string.Empty;
                        CD_Produto.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
        }

        private void GerarCodBarra(TRegistro_ValorCaracteristica grade)
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                bsCodBarra.AddNew();
                (bsCodBarra.Current as TRegistro_CodBarra).Cd_produto = CD_Produto.Text;
                (bsCodBarra.Current as TRegistro_CodBarra).Ds_produto = grade != null ? ds_produto.Text.Trim() + "/" + grade.Valor : ds_produto.Text;
                (bsCodBarra.Current as TRegistro_CodBarra).Quantidade = grade != null ? grade.Vl_mov : Quantidade.Value;
                (bsCodBarra.Current as TRegistro_CodBarra).Referencia = Referencia;
                if(!string.IsNullOrWhiteSpace(pCd_tabelapreco))
                    (bsCodBarra.Current as TRegistro_CodBarra).Vl_venda =
                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                                         CD_Produto.Text.Trim(),
                                                                                         pCd_tabelapreco,
                                                                                         null);
                object a = new TCD_CodBarra().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca(){
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Produto.Text.Trim() + "'"
                        }
                    }
                    , "a.CD_CodBarra ");
                if (a != null)
                    (bsCodBarra.Current as TRegistro_CodBarra).Cd_codbarra = a.ToString();

                TList_CadUnidade unidade = new TList_CadUnidade();
                 unidade = new TCD_CadUnidade().Select(
                    new TpBusca[]
                        { 
                            new TpBusca()
                            { 
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_est_produto x where x.cd_produto = "+CD_Produto.Text.Trim()+" and x.cd_unidade = a.cd_unidade)"
                            }
                        }, 1,string.Empty);
                if (unidade.Count > 0)
                    (bsCodBarra.Current as TRegistro_CodBarra).uni = unidade[0].Sigla_Unidade;
                if (grade == null)
                {
                    panelDados3.LimparRegistro();
                    bsCodBarra.ResetCurrentItem();
                }
            }
            if (grade == null)
            CD_Produto.Focus(); 
        }

        private void FEtiqueta_Load(object sender, EventArgs e)
        {
            rTerminal = CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Parametros.pubTerminal, string.Empty, null)[0];
            //Preencher lista empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbEmpresa.SelectedIndex = 0;
            cbEmpresa_SelectionChangeCommitted(this, new EventArgs());
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelDados3.set_FormatZero();
            CD_Produto.Focus();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            pId_caracteristica = string.Empty;
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
               "(a.Codigo_Alternativo = '" + (!string.IsNullOrWhiteSpace(CD_Produto.TextOld) ? CD_Produto.TextOld : CD_Produto.Text.Trim()) + "') or " +
                             "(exists(select 1 from tb_est_codbarra x " +
                             "         where x.cd_produto = a.cd_produto " +
                             "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                             "isnull(a.st_registro, 'A')|<>|'C'";
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, ds_produto },
                                                            new TCD_CadProduto());
            if (linha != null)
            {
                pId_caracteristica = linha["id_caracteristicaH"].ToString();
                Referencia = linha["Codigo_alternativo"].ToString();
                Quantidade.Focus();
            }
        }

        private void BuscarProduto()
        {
            pId_caracteristica = string.Empty;
            Referencia = string.Empty;
            TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   new Componentes.EditDefault[] { CD_Produto, ds_produto },
                                                   null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   new Componentes.EditDefault[] { CD_Produto, ds_produto },
                                                   null);
            else
            {
                TList_CadProduto lProd =
                    new TCD_CadProduto().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (!string.IsNullOrWhiteSpace(CD_Produto.TextOld) ? CD_Produto.TextOld : CD_Produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                ds_produto.Text = rProd.DS_Produto;
                Referencia = rProd.Codigo_alternativo;
                pId_caracteristica = rProd.Id_caracteristicaHstr;
                Quantidade.Focus();
            }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                VerificarGrade();
                if (string.IsNullOrEmpty(pId_caracteristica))
                    GerarCodBarra(null);
            }
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            VerificarGrade();
            if (string.IsNullOrEmpty(pId_caracteristica))
                GerarCodBarra(null); 
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if (bsCodBarra.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Deseja remover este produto.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                        bsCodBarra.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatório selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        }

        private void tmRelEstoque_Click(object sender, EventArgs e)
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
                    bsCodBarra.ResetCurrentItem();
                    if (!rTerminal.Id_layout.HasValue ? false : rTerminal.Id_layout != decimal.Zero)
                    {
                        List<CamadaNegocio.Diversos.TRegistro_Objeto> obj = new List<CamadaNegocio.Diversos.TRegistro_Objeto>();

                        for (int j = 0; j < bsCodBarra.Count; j++)
                        {
                            if ((bsCodBarra[j] as TRegistro_CodBarra).agregar)
                            {
                                obj.Add(new CamadaNegocio.Diversos.TRegistro_Objeto()
                                {
                                    Codigo = Convert.ToDecimal((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto),
                                    Produto = (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                    Vl_preco = (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                    Cod_barra = (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                    Qtd_etiqueta = Convert.ToInt32((bsCodBarra[j] as TRegistro_CodBarra).Quantidade.ToString())
                                });
                            }
                        }
                               

                        CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.ImpEtiquetaLayout(obj,
                                                            rTerminal.Porta_imptick, rTerminal);
                    }else
                    for (int j = 0; j < bsCodBarra.Count; j++)
                    {
                        if ((bsCodBarra[j] as TRegistro_CodBarra).agregar)
                        {

                             
                                if (rTerminal.Layoutetiqueta.Trim().Equals("1"))
                                TEtiquetaZebra.ImpEtiquetaL1((bsCodBarra[j] as TRegistro_CodBarra).Referencia,
                                                            (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                            (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                                            (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                                            rTerminal.Porta_imptick);
                            else if (rTerminal.Layoutetiqueta.Trim().Equals("2"))
                                TEtiquetaZebra.ImpEtiquetaL2((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                                                rTerminal.Porta_imptick);
                            else if (rTerminal.Layoutetiqueta.Trim().Equals("3"))
                                TEtiquetaZebra.ImpEtiquetaL3((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                                                rTerminal.Porta_imptick);
                            else if (rTerminal.Layoutetiqueta.Trim().Equals("4"))
                                TEtiquetaZebra.ImpEtiquetaL4((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto + (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                                                Convert.ToInt32((bsCodBarra[j] as TRegistro_CodBarra).Quantidade),
                                                                rTerminal.Porta_imptick);
                            else if (rTerminal.Layoutetiqueta.Trim().Equals("5"))
                                TEtiquetaZebra.ImpEtiquetaL5((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto + (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                                                Convert.ToInt32((bsCodBarra[j] as TRegistro_CodBarra).Quantidade),
                                                                rTerminal.Porta_imptick);
                            else if (rTerminal.Layoutetiqueta.Trim().Equals("6"))
                                TEtiquetaZebra.ImpEtiquetaL6(decimal.Parse((bsCodBarra[j] as TRegistro_CodBarra).Cd_produto),
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                                                (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda,
                                                                Convert.ToInt32((bsCodBarra[j] as TRegistro_CodBarra).Quantidade),
                                                                rTerminal.Porta_imptick);
                        }
                    };
                }
                else if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("A"))
                {
                    TList_CodBarra bar = new TList_CodBarra();
                    for (int j = 0; j < bsCodBarra.Count; j++)
                    { 
                        if ((bsCodBarra[j] as TRegistro_CodBarra).agregar)
                        {
                            bar.Add((bsCodBarra[j] as TRegistro_CodBarra));
                        }
                    }
                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = bar;
                    Relatorio.DTS_Relatorio = bs;
                    //  Relatorio.Ident = "REL_CODBARRA_CADPRODUTO";// "FLanEtiqueta";
                    Relatorio.Nome_Relatorio = "FLanEtiqueta";
                    Relatorio.NM_Classe = "FLanEtiqueta";
                    Relatorio.Ident = "FLanEtiqueta";
                    Relatorio.Modulo = "EST";



                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
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
                else if ( 
                         rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("N") ||
                         string.IsNullOrEmpty(rTerminal.Tp_impetiqueta.Trim()))
                {
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio Rel = new Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Nome_Relatorio = "TFProduto";
                        Rel.NM_Classe = "TFProduto";
                        Rel.Ident = "REL_CODBARRA";
                        Rel.Modulo = "EST";

                        TList_CodBarra lCod = new TList_CodBarra();
                        for (int j = 0; j < bsCodBarra.Count; j++)
                        {
                            for (int i = 0; i < (bsCodBarra[j] as TRegistro_CodBarra).Quantidade; i++)
                                lCod.Add(new TRegistro_CodBarra()
                                {
                                    Cd_codbarra = (bsCodBarra[j] as TRegistro_CodBarra).Cd_codbarra,
                                    Cd_produto = (bsCodBarra[j] as TRegistro_CodBarra).Cd_produto,
                                    Ds_produto = (bsCodBarra[j] as TRegistro_CodBarra).Ds_produto,
                                    Referencia = (bsCodBarra[j] as TRegistro_CodBarra).Referencia,
                                    Vl_venda = (bsCodBarra[j] as TRegistro_CodBarra).Vl_venda
                                });
                        }
                        BindingSource bs = new BindingSource();
                        bs.DataSource = lCod;
                        Rel.DTS_Relatorio = bs;

                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "IMPRESSÃO CODIGO BARRA";

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
                                               "IMPRESSÃO CODIGO BARRA",
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
                                               null,
                                               fImp.pDestinatarios,
                                               "IMPRESSÃO CODIGO BARRA",
                                               fImp.pDs_mensagem);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio adicionar codigo de barra para impressão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void TFEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void cbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
            {
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo =  "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_TabelaPreco");
                if (obj != null)
                    pCd_tabelapreco = obj.ToString();
            }
        }
    }
    
}
