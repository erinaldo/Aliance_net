using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFLan_GerarCreditoTitulo : Form
    {
        public CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCheque
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TRegistro_CreditoTitulo rCredTitulo
        {
            get
            {
                if (bsCreditoTitulo.Current != null)
                    return (bsCreditoTitulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_CreditoTitulo);
                else
                    return null;
            }
        }

        public TFLan_GerarCreditoTitulo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cd_contager_credito.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar conta gerencial a ser creditada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_contager_credito.Focus();
                return;
            }
            if (cd_historico.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar historico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_historico.Focus();
                return;
            }
            if (dt_lancto.Text.Trim().Equals(string.Empty) || dt_lancto.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data de lançamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_lancto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLan_GerarCreditoTitulo_Load(object sender, EventArgs e)
        {
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rCheque != null)
            {
                bsCreditoTitulo.Add(new CamadaDados.Financeiro.Titulo.TRegistro_CreditoTitulo()
                {
                    Cd_empresa = rCheque.Cd_empresa,
                    Nm_empresa = rCheque.Nm_empresa,
                    Cd_contager = rCheque.Cd_contager,
                    Ds_contager = rCheque.Nm_contager,
                    Cd_banco = rCheque.Cd_banco,
                    Ds_banco = rCheque.Ds_banco,
                    Nr_cheque = rCheque.Nr_cheque,
                    Nr_lanctocheque = rCheque.Nr_lanctocheque,
                    Vl_titulo = rCheque.Vl_titulo
                });
                bsCreditoTitulo.ResetCurrentItem();
            }
        }

        private void bb_contagercredito_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa_credito.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { cd_contager_credito, ds_contagercredito },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_credito_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager_credito.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.cd_empresa = '" + cd_empresa_credito.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager_credito, ds_contagercredito },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição|150;a.CD_Historico|Código|80"
                , new Componentes.EditDefault[] { cd_historico, ds_historico }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLan_GerarCreditoTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_empresa_credito_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa_credito, nm_empresa_credito }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_credito_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa_credito.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa_credito, nm_empresa_credito }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }
    }
}
