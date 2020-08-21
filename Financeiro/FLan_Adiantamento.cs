using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Financeiro
{
    public partial class TFLan_Adiantamento : Form
    {
        public TFLan_Adiantamento()
        {
            InitializeComponent();
            pnl_Adiantamento.set_FormatZero();
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    CD_Endereco.Text = obj.ToString();
            }
        }
        
        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, String.Empty);
            this.BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEndereco();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFLan_Adiantamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
            if (e.Control && (e.KeyCode == Keys.P))
                Imprime_Relatorio(true);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pnl_Adiantamento.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty(CD_ContaGer.Text))
                    if (CD_ContaGer.Focused && CD_ContaGer.Text.Length != 3)
                    {
                        MessageBox.Show("Valide a conta gerencial, clique em TAB ou no botão para selecionar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_ContaGer.Focus();
                        return;
                    }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + CD_Endereco.Text + "';" + "b.cd_clifor|=|'" + cd_clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, Cidade, UF },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|350;" +
                              "a.CD_Endereco|Cód. Endereço|80;" +
                              "a.UF|UF|80;" +
                              "a.DS_cidade|Cidade|100;" +
                              "a.CD_UF|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, Cidade, UF  },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "b.CD_CLIFOR|=|" + cd_clifor.Text);
        }
        private void Imprime_Relatorio(bool Altera_Relatorio)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Altera_Relatorio = Altera_Relatorio;
            Relatorio.Nome_Relatorio = "TFLan_Adiantamento";
            Relatorio.DTS_Relatorio = BS_Adiantamento;
            Relatorio.Gera_Relatorio();
        }

        private void TFLan_Adiantamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados3.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void BB_ContaGer_Click(object sender, EventArgs e)
        {
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                           "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                           "a.st_contacartao|<>|0;" +
                           "a.st_contaCF|<>|0";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vCond += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                        "where k.CD_ContaGer = a.CD_ContaGer " +
                        "and k.cd_Empresa = '" + CD_Empresa.Text + "')";


            string vColunas = "a.ds_contager|Conta|350;" +
                  "a.CD_ContaGer|Cód. Conta|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vCond = "a.CD_ContaGer|=|'" + CD_ContaGer.Text.Trim() + "';" +
                           "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                           "a.st_contacartao|<>|0;" +
                           "a.st_contaCF|<>|0;" +
                           "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vCond += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                         "where k.CD_ContaGer = a.CD_ContaGer " +
                         "and k.cd_Empresa = '" + CD_Empresa.Text + "')";

            UtilPesquisa.EDIT_LEAVE(vCond, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }
    }
}
