using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Faturamento.Promocao;
using CamadaNegocio.Faturamento.Promocao;

namespace Faturamento
{
    public partial class TFLanPromocoes : Form
    {
        public TFLanPromocoes()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_promocao.Clear();
            cd_empresa.Clear();
            ds_promocao.Clear();
            DT_Final.Clear();
            DT_Inicial.Clear();
            cbAberta.Checked = false;
            cbFinalizada.Checked = false;
            cbExpirada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFPromocao fPromocao = new TFPromocao())
            {
                if(fPromocao.ShowDialog() == DialogResult.OK)
                    if (fPromocao.rPromocao != null)
                        try
                        {
                            TCN_PromocaoVenda.Gravar(fPromocao.rPromocao, null);
                            MessageBox.Show("Promoção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_promocao.Text = fPromocao.rPromocao.Id_promocaostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsPromocao.Current != null)
                using (TFPromocao fPromocao = new TFPromocao())
                {
                    fPromocao.rPromocao = bsPromocao.Current as TRegistro_PromocaoVenda;
                    if(fPromocao.ShowDialog() == DialogResult.OK)
                        if (fPromocao.rPromocao != null)
                            try
                            {
                                TCN_PromocaoVenda.Gravar(fPromocao.rPromocao, null);
                                MessageBox.Show("Promoção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    LimparFiltros();
                    id_promocao.Text = fPromocao.rPromocao.Id_promocaostr;
                    afterBusca();
                }
            else
                MessageBox.Show("Obrigatorio selecinar promoção para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsPromocao.Current != null)
            {
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_PromocaoVenda.Excluir(bsPromocao.Current as TRegistro_PromocaoVenda, null);
                        MessageBox.Show("Promoção excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Não existe promoção selecionada para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void afterBusca()
        {
            string st_registro = string.Empty;
            string virg = string.Empty;
            if (cbAberta.Checked)
            {
                st_registro = "'A'";
                virg = ",";
            }
            if (cbFinalizada.Checked)
            {
                st_registro += virg + "'F'";
                virg = ",";
            }
            bsPromocao.DataSource = TCN_PromocaoVenda.Buscar(id_promocao.Text,
                                                             cd_empresa.Text,
                                                             ds_promocao.Text,
                                                             cd_grupo.Text,
                                                             edtProduto.Text,
                                                             rbDtInicio.Checked ? "I" : "F",
                                                             DT_Inicial.Text,
                                                             DT_Final.Text,
                                                             st_registro,
                                                             cbExpirada.Checked,
                                                             null);
            bsPromocao_PositionChanged(this, new EventArgs());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFLanPromocoes_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPromocao);
            Utils.ShapeGrid.RestoreShape(this, gGrupoProduto);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanPromocoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gPromocao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                    gPromocao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                else if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADA"))
                    gPromocao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gPromocao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bsPromocao_PositionChanged(object sender, EventArgs e)
        {
            if (bsPromocao.Current != null)
            {
                (bsPromocao.Current as TRegistro_PromocaoVenda).lGrupo =
                    TCN_Promocao_X_Grupo.Buscar(
                    (bsPromocao.Current as TRegistro_PromocaoVenda).Id_promocaostr,
                    string.Empty,
                    string.Empty,
                    null);
                bsPromocao.ResetCurrentItem();
            }   
        }

        private void TFLanPromocoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPromocao);
            Utils.ShapeGrid.SaveShape(this, gGrupoProduto);
        }

        private void bbGrupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + cd_grupo.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { edtProduto }, string.Empty);
        }

        private void edtProduto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + edtProduto.Text.Trim() + "'",
                new Componentes.EditDefault[] { edtProduto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
