using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using BancoDados;
using Utils;

namespace Financeiro
{
    public partial class TFLan_Transfere_Caixa : Form
    {
        public TFLan_Transfere_Caixa()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("* - Multiplicar", "*"));
            cbx.Add(new Utils.TDataCombo("/ - Dividir", "/"));

            operador.DataSource = cbx;
            operador.DisplayMember = "Display";
            operador.ValueMember = "Value";
        }

        private void BuscarMoedaDestino()
        {
            if (!string.IsNullOrEmpty(CD_ContaGer_Saida.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_contager x "+
                                        "where x.cd_moeda = a.cd_moeda "+
                                        "and x.cd_contager = '"+ CD_ContaGer.Text.Trim()+ "')"
                        }
                    }, 0, string.Empty);
                if (lMoeda.Count > 0)
                {
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Cd_moeda_entrada = lMoeda[0].Cd_moeda;
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Ds_moeda_entrada = lMoeda[0].Ds_moeda_singular;
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Sigla_moeda_entrada = lMoeda[0].Sigla;
                    BS_Transfere_Caixa.ResetCurrentItem();
                }
            }
        }

        private void BB_ContaGer_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|EXISTS|(select 1 from tb_fin_contager_x_empresa x " +
                                "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                                "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                                "a.st_contacartao|=|1;" +
                                "a.st_contacf|=|1";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
            this.BuscarMoedaDestino();
        }

         private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + CD_ContaGer.Text + "';" +
                              "|EXISTS|(select 1 from tb_fin_contager_x_empresa x " +
                              "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                              "isnull(a.st_contacompensacao, 'N')|<>|'S';" +
                                "a.st_contacartao|=|1;" +
                                "a.st_contacf|=|1";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
            this.BuscarMoedaDestino();
        }

        private void TFLan_Transfere_Caixa_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pnl_Transfere.set_FormatZero();
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            pValores.BackColor = SettingsUtils.Default.COLOR_1;
            if (BS_Transfere_Caixa.Current != null)
            {
                //Buscar moeda da conta entrada
                CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_contager x "+
                                        "where x.cd_moeda = a.cd_moeda "+
                                        "and x.cd_contager = '" + (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).CD_ContaGer_Saida.Trim() + "')"
                        }
                    }, 0, string.Empty);
                if (lMoeda.Count > 0)
                {
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Cd_moeda_saida = lMoeda[0].Cd_moeda;
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Ds_moeda_saida = lMoeda[0].Ds_moeda_singular;
                    (BS_Transfere_Caixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa).Sigla_moeda_saida = lMoeda[0].Sigla;
                    BS_Transfere_Caixa.ResetCurrentItem();
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam); 
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Historico|Conta|350;" +
                  "a.CD_Historico|Cód. Historico|100";
            string vParamFixo = "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_HISTORICO|=|'" + CD_Historico.Text.Trim() + "';" + "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pnl_Transfere.validarCampoObrigatorio())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFLan_Transfere_Caixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                BB_Cancelar_Click(this, new EventArgs());
        }




    }
}
