using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Estoque
{
    public partial class TFLan_TransfEstoque : Form
    {
        public TFLan_TransfEstoque()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_transf.Clear();
            cd_produto.Clear();
            cd_empresadest.Clear();
            cd_empresaorig.Clear();
            cd_localdest.Clear();
            cd_localorig.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFTransfEstoque fTransf = new TFTransfEstoque())
            {
                if(fTransf.ShowDialog() == DialogResult.OK)
                    if (fTransf.rTransf != null)
                    {
                        try
                        {
                            CamadaNegocio.Estoque.TCN_TransfLocal.Gravar(fTransf.rTransf, null);
                            MessageBox.Show("Transferencia gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_transf.Text = fTransf.rTransf.Id_transf.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterExclui()
        {
            if (bsTransf.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.TCN_TransfLocal.Excluir(bsTransf.Current as CamadaDados.Estoque.TRegistro_TransfLocal, null);
                        MessageBox.Show("Transferencia excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Necessario selecionar transferencia para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsTransf.DataSource = CamadaNegocio.Estoque.TCN_TransfLocal.Buscar(id_transf.Text,
                                                                               cd_produto.Text,
                                                                               cd_empresaorig.Text,
                                                                               cd_empresadest.Text,
                                                                               cd_localorig.Text,
                                                                               cd_localdest.Text,
                                                                               dt_ini.Text,
                                                                               dt_fin.Text,
                                                                               null);
            bsTransf_PositionChanged(this, new EventArgs());
        }   

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + cd_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { cd_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_empresaorig_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresaorig },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresaorig_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresaorig.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresaorig },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresadest_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresadest },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresadest_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresadest.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresadest },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_localorig_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Local Armazenagem|350;" +
                              "CD_Local|Cód. Local|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_localorig },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), string.Empty);  
        }

        private void cd_localorig_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_local|=|'" + cd_localorig.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_localorig },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bb_localdest_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Local Armazenagem|350;" +
                              "CD_Local|Cód. Local|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_localdest },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), string.Empty);  
        }

        private void cd_localdest_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_local|=|'" + cd_localorig.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_localdest },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bsTransf_PositionChanged(object sender, EventArgs e)
        {
            if (bsTransf.Current != null)
            {
                (bsTransf.Current as CamadaDados.Estoque.TRegistro_TransfLocal).lEstTransf =
                    new CamadaDados.Estoque.TCD_LanEstoque().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_transf = " + (bsTransf.Current as CamadaDados.Estoque.TRegistro_TransfLocal).Id_transf.Value.ToString() + ")"
                        }
                    }, 0, string.Empty, string.Empty, "a.id_lanctoestoque");
                bsTransf.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFLan_TransfEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLan_TransfEstoque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEstoque);
            Utils.ShapeGrid.RestoreShape(this, gTransfLocal);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void TFLan_TransfEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEstoque);
            Utils.ShapeGrid.SaveShape(this, gTransfLocal);
        }
    }
}
