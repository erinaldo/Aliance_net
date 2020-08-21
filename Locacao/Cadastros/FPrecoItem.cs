using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Locacao.Cadastros
{
    public partial class TFPrecoItem : Form
    {
        public TFPrecoItem()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsItens.Current != null)
            {
                if (vl_precolocacao.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor ou indice para gravar preço venda.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_precolocacao.Focus();
                    return;
                }
                try
                {
                    if ((bsItens.DataSource as CamadaDados.Estoque.TList_ProdutoPreco).Exists(p => p.St_processar))
                    {
                        (bsItens.DataSource as CamadaDados.Estoque.TList_ProdutoPreco).FindAll(p => p.St_processar).ForEach(p =>
                            {
                                CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Gravar(
                                    new CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens()
                                    {
                                        Cd_empresa = cd_empresa.Text,
                                        Id_tabelastr = cd_tabpreco.Text,
                                        Cd_produto = p.Cd_produto,
                                        Vl_preco = vl_precolocacao.Value
                                    }, null);
                            });
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar valor ou indice para gravar preço venda.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_precolocacao.Focus();
                        return;
                    }
                    this.BuscarProdSemPreco();
                    vl_precolocacao.Value = vl_precolocacao.Minimum;
                    vl_precolocacao.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscarProdSemPreco()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_tabpreco.Text)))
            {
                bsItens.DataSource = new CamadaDados.Estoque.TCD_LanPrecoItem().SelectProdutoPreco(cd_empresa.Text, cd_tabpreco.Text,
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from TB_LOC_PrecoItens x " +
                                                            "where x.cd_produto = a.cd_produto " +
                                                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "' " +
                                                            "and x.ID_Tabela = " + cd_tabpreco.Text.Trim() + ")"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_EST_TpProduto x " +
                                                            "where a.TP_Produto = x.TP_Produto " +
                                                            "and isnull(x.ST_Patrimonio, 'N') = 'S') "

                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_grupo",
                                                vOperador = "=",
                                                vVL_Busca = string.IsNullOrEmpty(cd_grupo.Text) ? "a.cd_grupo" : "'" + cd_grupo.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = string.IsNullOrEmpty(cd_prodbusca.Text) ? "a.cd_produto" : "'" + cd_prodbusca.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                            "where x.CD_Patrimonio = a.CD_Produto " +
                                                            (string.IsNullOrEmpty(Nr_patrimonio.Text) ? ") " : 
                                                            "and x.NR_Patrimonio = '" + Nr_patrimonio.Text.Trim() + "') ")
                                                
                                            }
                                        });
            }
        }

        private void TFPrecoItem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                "|EXISTS| (select 1 from TB_LOC_CfgLocacao x where a.CD_Empresa = x.CD_Empresa ) ";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            this.BuscarProdSemPreco();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                            "|EXISTS| (select 1 from TB_LOC_CfgLocacao x where a.CD_Empresa = x.CD_Empresa ) ";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
            this.BuscarProdSemPreco();
        }

        private void cd_tabpreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.ID_Tabela|=|'" + cd_tabpreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabpreco, ds_tabelapreco },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco());
            this.BuscarProdSemPreco();
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Tabela|Tabela Preço|200;" +
                              "a.ID_Tabela|Id. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabpreco, ds_tabelapreco },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco(), string.Empty);
            this.BuscarProdSemPreco();
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
            this.BuscarProdSemPreco();
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_grupo|Grupo Produto|200;" +
                           "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
            this.BuscarProdSemPreco();
        }

        private void cd_prodbusca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_prodbusca.Text.Trim() + "';" +
                            "ISNULL(e.ST_Patrimonio, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_prodbusca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            this.BuscarProdSemPreco();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prodbusca }, "ISNULL(e.ST_Patrimonio, 'N')|=|'S'");
            this.BuscarProdSemPreco();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void gProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).St_processar =
                    !(bsItens.Current as CamadaDados.Estoque.TRegistro_ProdutoPreco).St_processar;
                bsItens.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.DataSource as List<CamadaDados.Estoque.TRegistro_ProdutoPreco>).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItens.ResetBindings(true);
            }
        }

        private void Nr_patrimonio_Leave(object sender, EventArgs e)
        {
            this.BuscarProdSemPreco();
        }
    }
}
