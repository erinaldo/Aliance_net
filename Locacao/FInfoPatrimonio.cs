using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFInfoPatrimonio : Form
    {
        public string pCd_empresa
        { get; set; }
        public DataRowView linha { get; set; } = null;
        public TFInfoPatrimonio()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void BuscarProduto(string vBusca,bool busca = true)
        {        
            Componentes.EditDefault cd_produto = new Componentes.EditDefault();
            if (busca)
            {
                if (vBusca.Equals("G"))
                {
                    string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                                     "a.CD_Grupo|Cód. Grupo|100";
                    string vParamFixo = "a.TP_Grupo|=|'A'";
                    linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                                             new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
                }
                else
                {
                    cd_produto.NM_CampoBusca = "cd_produto";
                    if (string.IsNullOrEmpty(cd_produto.Text))
                        UtilPesquisa.BuscarProduto(string.Empty,
                                                             pCd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             null);
                    else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                        UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             pCd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             null);
                }
            }
            List<CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao> lista = new List<CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao>();

            //Buscar produto
            lista =
                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao(!string.IsNullOrEmpty(cd_produto.Text) && vBusca.Equals("P") ? cd_produto.Text : string.Empty,
                                                                                    linha != null && vBusca.Equals("G") ? linha["cd_grupo"].ToString() : string.Empty,
                                                                                    pCd_empresa,
                                                                                    true,
                                                                                    string.Empty,
                                                                                    null);



            lista.ForEach(p =>
            {
                CamadaDados.Locacao.Cadastros.TList_CadPrecoItens lPreco =
                new CamadaDados.Locacao.Cadastros.TCD_CadPrecoItens().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + pCd_empresa.Trim() + "'"
                        }
                    }, 0, string.Empty);

                if (lPreco.Count > 0)
                    for (int i = 0; lPreco.Count > i; i++)
                    {
                        if (lPreco[i].Tp_tabela.Equals("0"))
                            p.Vl_unidade += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                        else if (lPreco[i].Tp_tabela.Equals("2"))
                            p.Vl_hora += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                        else if (lPreco[i].Tp_tabela.Equals("3"))
                            p.Vl_dia += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                        else if (lPreco[i].Tp_tabela.Equals("4"))
                            p.Vl_mes += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                        else if (lPreco[i].Tp_tabela.Equals("5"))
                            p.Vl_semana += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                        else if (lPreco[i].Tp_tabela.Equals("6"))
                            p.Vl_quinzena += lPreco[i].Ds_tabela + "-" + lPreco[i].Vl_preco.ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                    }
            });
            bsProdutoLoc.DataSource = lista;
            bsProdutoLoc_PositionChanged(this, new EventArgs());
        }

        private void TFInfoPatrimonio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bsProdutoLoc_PositionChanged(object sender, EventArgs e)
        {
            if (bsProdutoLoc.Current != null)
            {
                //Buscar Imagens
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).lImagens =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto_Imagens.Buscar(0,
                                                                                  (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto);
                bsProdutoLoc.ResetCurrentItem();
            }
        }

        private void bb_buscarGrupo_Click(object sender, EventArgs e)
        {
            this.BuscarProduto("G");
        }

        private void bb_buscarProduto_Click(object sender, EventArgs e)
        {
            this.BuscarProduto("P");
        }

        private void TFInfoPatrimonio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F10))
                this.BuscarProduto("G");
            else if (e.KeyCode.Equals(Keys.F12))
                this.BuscarProduto("P");
        }
    }
}
