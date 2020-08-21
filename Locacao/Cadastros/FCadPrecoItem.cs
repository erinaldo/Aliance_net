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
    public partial class TFCadPrecoItem : Form
    {
        public TFCadPrecoItem()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFPrecoItem fPreco = new TFPrecoItem())
            {
                fPreco.ShowDialog();
            }
        }

        private void afterAltera()
        {
            using (TFAtualizaPreco fAtualiza = new TFAtualizaPreco())
            {
                fAtualiza.ShowDialog();
            }
        }

        private void afterExclui()
        {
            if (bsPrecoItem.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Excluir(bsPrecoItem.Current as CamadaDados.Locacao.Cadastros.TRegistro_CadPrecoItens, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsPrecoItem.DataSource = CamadaNegocio.Locacao.Cadastros.TCN_CadPrecoItens.Buscar(cd_tabpreco.Text,
                                                                                              cd_empresa.Text,
                                                                                              CD_Produto.Text,
                                                                                              Nr_patrimonio.Text,
                                                                                              cd_grupo.Text,
                                                                                              null);
            bsPrecoItem.ResetCurrentItem();
        }

        private void TFCadPrecoItem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                            "|EXISTS| (select 1 from TB_LOC_CfgLocacao x where a.CD_Empresa = x.CD_Empresa ) ";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                            "|EXISTS| (select 1 from TB_LOC_CfgLocacao x where a.CD_Empresa = x.CD_Empresa ) ";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_tabpreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.ID_Tabela|=|'" + cd_tabpreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabpreco },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Tabela|Tabela Preço|200;" +
                              "a.ID_Tabela|Id. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabpreco },
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
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                             "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "';" +
                            "ISNULL(e.ST_Patrimonio, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { CD_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto }, "ISNULL(e.ST_Patrimonio, 'N')|=|'S'");
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFCadPrecoItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
