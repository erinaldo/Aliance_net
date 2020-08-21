using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using FormBusca;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Graos;
using CamadaNegocio.Fazenda.Lancamento;
namespace Fazenda
{
    public partial class TFlan_Faz_Atividade : Form
    {
        public TFlan_Faz_Atividade()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFLan_Faz_LanAtividadeItem fItem = new TFLan_Faz_LanAtividadeItem())
            {
                if (fItem.ShowDialog() == DialogResult.OK)
                {
                    if (fItem.rAtiv != null)
                    {
                        try
                        {
                            CamadaNegocio.Fazenda.Lancamento.TCN_LanAtividade.GravaLanAtividade(fItem.rAtiv, null);
                            MessageBox.Show("Atividade gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void afterExclui()
        {
            if (BS_LanAtividade.Current != null)
            {
                if (MessageBox.Show("Confirma a exclusão da atividade selecionada?",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanAtividade.DeletaLanAtividade(BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade, null);
                        MessageBox.Show("Atividade excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void afterBusca()
        {
            BS_LanAtividade.DataSource = TCN_LanAtividade.Busca(CD_Empresa.Text,
                                                                CD_Fazenda.Text,
                                                                CD_Talhao.Text,
                                                                ID_LanctoAtiv.Text,
                                                                AnoSafra.Text,
                                                                cd_produto.Text,
                                                                DT_Inicial.Text,
                                                                DT_Final.Text,
                                                                null);
            BS_LanAtividade_PositionChanged(this, new EventArgs());
        }

        private void InserirItem()
        {
            if (BS_LanAtividade.Current != null)
            {
                using (TFLan_Faz_LanAtividadeItem fItem = new TFLan_Faz_LanAtividadeItem())
                {
                    BS_LanItemAtividade.AddNew();
                    fItem.rAtiv = BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade;
                    fItem.St_alterar = true;
                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        if (fItem.rAtiv != null)
                        {
                            try
                            {
                                CamadaNegocio.Fazenda.Lancamento.TCN_LanAtividade.GravaLanAtividade(fItem.rAtiv, null);
                                MessageBox.Show("Item atividade gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        BS_LanItemAtividade.RemoveCurrent();
                }
            }
        }

        private void ExcluirItem()
        {
            if ((BS_LanAtividade.Current != null) && (BS_LanItemAtividade.Current != null))
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).LitensDel.Add(
                        BS_LanItemAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade_Item);
                    try
                    {
                        CamadaNegocio.Fazenda.Lancamento.TCN_LanAtividade.GravaLanAtividade(
                            BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade, null);
                        BS_LanItemAtividade.RemoveCurrent();
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Total.Value = (BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).Litens.Sum(p => p.Vl_total);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Flan_Faz_Atividade_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            pFiltroData.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDadosTotal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
         }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa }, new TCD_CadEmpresa());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|150;" +
                              "a.CD_Empresa|Cód. Empresa|80";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new TCD_CadEmpresa(), vParam);
        }

        private void CD_Fazenda_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_fazenda|=|" + CD_Fazenda.Text,
                                                    new Componentes.EditDefault[] { CD_Fazenda },
                                                    new TCD_Fazenda());
        }

        private void BB_Fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Nome Propriedade|350;" +
                              "a.CD_Fazenda|Codigo Propriedade|100;" +
                              "a.cd_empresa|Cód. Empresa|100";

            UtilPesquisa.BTN_BUSCA(vColunas,
                                   new Componentes.EditDefault[] { CD_Fazenda},
                                   new TCD_Fazenda(), string.Empty);
        }

        private void CD_Talhao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Talhao|=|" + CD_Talhao.Text, new Componentes.EditDefault[] { CD_Talhao}, new TCD_Talhoes());
        }

        private void BB_Talhao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Talhao|Nome Talhao|250;a.CD_Talhao|Cód. Talhão|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Talhao}, new TCD_Talhoes(), string.Empty);
        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.AnoSafra|=|'" + AnoSafra.Text + "'"
            , new Componentes.EditDefault[] { AnoSafra}, new TCD_CadSafra());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_atividade|Atividade|200;"+
                              "a.id_atividade|Id. Atividade|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_LanctoAtiv },
                                    new TCD_Atividade(), string.Empty);
        }

        private void ID_LanctoAtiv_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_atividade|=|" + ID_LanctoAtiv.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { ID_LanctoAtiv },
                                    new TCD_Atividade());
        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Ano Safra|200;" +
                              "a.anosafra|Cd. Safra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { AnoSafra },
                                    new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto(string.Empty, new Componentes.EditDefault[] { cd_produto }, 
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BS_LanAtividade_PositionChanged(object sender, EventArgs e)
        {
            if(BS_LanAtividade.Current != null)
                if ((BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).Id_lanctoativ != null)
                {
                    (BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).Litens =
                        TCN_LanAtividade_Item.Busca((BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).Id_lanctoativ.Value.ToString(),
                                                    0, string.Empty, null);
                    Total.Value = (BS_LanAtividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade).Litens.Sum(p => p.Vl_total);
                    BS_LanAtividade.ResetCurrentItem();
                }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFlan_Faz_Atividade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F11))
                this.InserirItem();
            else if (e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }

        private void TFlan_Faz_Atividade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
