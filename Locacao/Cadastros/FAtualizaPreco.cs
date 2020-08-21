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
    public partial class TFAtualizaPreco : Form
    {
        public TFAtualizaPreco()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsPrecoItem.Count > 0)
            {
                try
                {
                    if (vl_novopreco.Value > decimal.Zero)
                    {
                        if ((bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).Exists(p => p.St_processar))
                        {
                            (bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).FindAll(p => p.St_processar).ForEach(p =>
                                {
                                    p.Vl_preco = vl_novopreco.Value;
                                    CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Gravar(p, null);
                                });
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar selecionar produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar novo preço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Preço Alterado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int index = bsPrecoItem.Position;
                    this.afterBusca();
                    bsPrecoItem.Position = index + 1;
                    vl_novopreco.Value = vl_novopreco.Minimum;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void afterBusca()
        {
            bsPrecoItem.DataSource = CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Buscar(cd_tabpreco.Text,
                                                                                              cd_empresa.Text,
                                                                                              cd_prodbusca.Text,
                                                                                              Nr_patrimonio.Text,
                                                                                              cd_grupo.Text,
                                                                                              null);
            bsPrecoItem.ResetCurrentItem();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFAtualizaPreco_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAtualiza);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void cd_tabpreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.ID_Tabela|=|'" + cd_tabpreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabpreco, ds_tabelapreco },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Tabela|Tabela Preço|200;" +
                              "a.ID_Tabela|Id. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabpreco, ds_tabelapreco },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_grupo|Grupo Produto|200;" +
                          "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_prodbusca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_prodbusca.Text.Trim() + "';" +
                           "ISNULL(e.ST_Patrimonio, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_prodbusca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prodbusca }, "ISNULL(e.ST_Patrimonio, 'N')|=|'S'");
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAtualizaPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gAtualiza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).St_processar =
                    !(bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens).St_processar;
                bsPrecoItem.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsPrecoItem.Count > 0)
            {
                (bsPrecoItem.DataSource as CamadaDados.Locacao.Cadastros.TList_CadPrecoItens).ForEach(p => p.St_processar = cbTodos.Checked);
                bsPrecoItem.ResetBindings(true);
            }
        }
    }
}
