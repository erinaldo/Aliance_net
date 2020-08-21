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

namespace Parametros.Diversos
{
    public partial class TFIntegraService : Form
    {
        public TFIntegraService()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            CD_Empresa.Clear();
            nm_empresa.Clear();
            cd_tabelapreco.Clear();
            ds_tabelapreco.Clear();
            path_arquivo.Clear();
            CD_Empresa.Focus();
        }

        private void afterGrava()
        {
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (cd_tabelapreco.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar tabela de desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_tabelapreco.Focus();
                return;
            }
            if (path_arquivo.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar path para salvar o arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_arquivo.Focus();
                return;
            }
            if (!System.IO.Directory.Exists(path_arquivo.Text.Trim()))
            {
                MessageBox.Show("Path informado não existe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_arquivo.Clear();
                path_arquivo.Focus();
                return;
            }
            try
            {
                CamadaNegocio.IntegraViaseg.IntegraViaseg.GerarArquivoIntegracao(CD_Empresa.Text, cd_tabelapreco.Text, path_arquivo.Text);
                MessageBox.Show("Arquivo gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gerar arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TFIntegraService_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            CD_Empresa.Text = configIntegracao.Default.cd_empresa.Trim();
            nm_empresa.Text = configIntegracao.Default.nm_empresa.Trim();
            cd_tabelapreco.Text = configIntegracao.Default.cd_tabelapreco.Trim();
            ds_tabelapreco.Text = configIntegracao.Default.ds_tabelapreco.Trim();
            path_arquivo.Text = configIntegracao.Default.path_arquivo.Trim();
        }

        private void TFIntegraService_FormClosing(object sender, FormClosingEventArgs e)
        {
            configIntegracao.Default.Save();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, nm_empresa },
                                    new TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, nm_empresa },
                                new TCD_CadEmpresa());
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                    new TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                    new TCD_CadTbPreco());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    path_arquivo.Text = fbdPath.SelectedPath.Trim();
            }
        }
    }
}
