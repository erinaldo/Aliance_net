using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;

namespace Frota
{
    public partial class TFDevolucaoOutrasReceitas : Form
    {

        public decimal? vl_adtoViagem { get; set; }
        private CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rlancaixa;
        public CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rLancaixa
        {
            get
            {
                if (bs.Current != null)
                    return bs.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa;
                else
                    return null;
            }
            set { rlancaixa = value; }      
        }

        public TFDevolucaoOutrasReceitas()
        {
            InitializeComponent();
        }

        private void bb_salvar_Click(object sender, EventArgs e)
        {
            rlancaixa = bs.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa;
            rlancaixa.Nr_Docto = "Devolução";
            if (panelDados1.validarCampoObrigatorio())
            {
                if (vl_adtoViagem < VL_Receber.Value)
                {
                    MessageBox.Show("Você não pode devolver um valor mais alto que o adiantamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (VL_Receber.Value == 0)
                {
                    MessageBox.Show("Campo Obrigatório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VL_Receber.Focus();
                    return;
                }
                
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFDevolucaoOutrasReceitas_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();               
        }
        public void preenche()
        {

            if (rlancaixa != null)
            {
                bs.DataSource = new CamadaDados.Financeiro.Caixa.TList_LanCaixa() { rlancaixa };

            }
            else
            {
                bs.AddNew();

                CD_Empresa.Enabled = string.IsNullOrEmpty(CD_Empresa.Text);
                BB_Empresa.Enabled = string.IsNullOrEmpty(CD_Empresa.Text);
                CD_ContaGer.Enabled = string.IsNullOrEmpty(CD_ContaGer.Text);
                CD_Historico.Enabled = string.IsNullOrEmpty(CD_Historico.Text);
                
                //VL_Receber.Enabled = string.IsNullOrEmpty(VL_Receber.Text);
            }
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
                vColunas += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = '" + CD_ContaGer.Text + "' and k.cd_Empresa = a.cd_empresa )|";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
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

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_HISTORICO|=|'" + CD_Historico.Text + "';";
           
                vColunas += "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Historico|Historico|350;" +
                              "a.CD_Historico|Cód. Historico|100";
            string vParamFixo = string.Empty;
            
                vParamFixo += "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico, DS_Historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }
    }
}
