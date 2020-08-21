using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;

namespace Financeiro
{
    public partial class TFLanCaixa : Form
    {
        public TFLanCaixa()
        {
            InitializeComponent();
            
            BB_Gravar.Visible = true;
            BB_Cancelar.Visible = true;

           this.panelDados1.set_FormatZero();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
  
        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            if (CD_ContaGer.Text != "")
                vParam += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = '" + CD_ContaGer.Text + "' and k.cd_Empresa = a.cd_empresa )|";
            
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam); 
        }

        private void BB_ContaGer_Click(object sender, EventArgs e)
        {
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vCond += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                        "where k.CD_ContaGer = a.CD_ContaGer " +
                        "and k.cd_Empresa = '" + CD_Empresa.Text + "')";

            
            string vColunas = "a.ds_contager|Conta|350;" +
                  "a.CD_ContaGer|Cód. Conta|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_ContaGer.Text))
                vColunas += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = '"+CD_ContaGer.Text +"' and k.cd_Empresa = a.cd_empresa )|";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vCond = "a.CD_ContaGer|=|'" + CD_ContaGer.Text.Trim() + "';" +
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

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Historico|Historico|350;" +
                              "a.CD_Historico|Cód. Historico|100";
            string vParamFixo = string.Empty;
            if (RB_Pagar.Checked)
                vParamFixo += "a.TP_Mov|=|'P'";
            else
                vParamFixo += "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_HISTORICO|=|'" + CD_Historico.Text + "';";
            if (RB_Pagar.Checked)
                vColunas += "a.TP_Mov|=|'P'";
            else
                vColunas += "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico},
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                if (RB_Pagar.Checked && (VL_Pagar.Value == 0))
                {
                    MessageBox.Show("Campo Obrigatório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VL_Pagar.Focus();
                    return;
                }
                if (RB_Receber.Checked && (VL_Receber.Value == 0))
                {
                    MessageBox.Show("Campo Obrigatório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VL_Receber.Focus();
                    return;
                }
                if (VL_Pagar.Focused)
                    (dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR = VL_Pagar.Value;
                if (VL_Receber.Focused)
                    (dsLanCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER = VL_Receber.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void RB_Receber_Click(object sender, EventArgs e)
        {
            VL_Pagar.Enabled = false;
            VL_Receber.Enabled = true;
            VL_Pagar.Value = decimal.Zero;
        }

        private void RB_Pagar_Click(object sender, EventArgs e)
        {
            VL_Pagar.Enabled = true;
            VL_Receber.Enabled = false;
            VL_Receber.Value = decimal.Zero;
        }

        private void TFLanCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void RB_Receber_CheckedChanged(object sender, EventArgs e)
        {
            VL_Pagar.Enabled = false;
            VL_Receber.Enabled = true;
            VL_Pagar.Value = 0;
        }

        private void RB_Pagar_CheckedChanged(object sender, EventArgs e)
        {
            VL_Pagar.Enabled = true;
            VL_Receber.Enabled = false;
            VL_Receber.Value = 0;
        }

        private void TFLanCaixa_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void DT_Lancto_Enter(object sender, EventArgs e)
        {
            DT_Lancto.Select(0, DT_Lancto.Text.Length);
        }

        private void VL_Receber_Enter(object sender, EventArgs e)
        {
            VL_Receber.Select(0, VL_Receber.Value.ToString().Length);
        }

        private void VL_Pagar_Enter(object sender, EventArgs e)
        {
            VL_Pagar.Select(0, VL_Pagar.Value.ToString().Length);
        }

        private void bb_cadhistorico_Click(object sender, EventArgs e)
        {
            using (Cadastros.TFHistorico fHist = new Cadastros.TFHistorico())
            {
                fHist.Tp_movimento = RB_Pagar.Checked ? "P" : "R";
                if(fHist.ShowDialog() == DialogResult.OK)
                    if(fHist.rHist != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadHistorico.Gravar(fHist.rHist, null);
                            MessageBox.Show("Historico gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Historico.Text = fHist.rHist.Cd_historico;
                            DS_Historico.Text = fHist.rHist.Ds_historico;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}