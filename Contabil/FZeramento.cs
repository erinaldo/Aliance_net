using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFZeramento : Form
    {
        private CamadaDados.Contabil.Cadastro.TList_Cad_CTB_ParamZeramento lParam
        { get; set; }

        public TFZeramento()
        {
            InitializeComponent();
            lParam = new CamadaDados.Contabil.Cadastro.TList_Cad_CTB_ParamZeramento();
        }

        private void afterGrava()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (lParam.Count.Equals(0))
            {
                MessageBox.Show("Empresa não possui paramêtros configurados para realizar ZERAMENTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dt_zeramento.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatório informar data final do periodo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_zeramento.Focus();
                return;
            }
            try
            {
                DateTime? dt = null;
                if(dt_ini.Text.Trim() != "/  /")
                    dt = DateTime.Parse(dt_ini.Text).AddDays(1);
                CamadaNegocio.Contabil.TCN_Zeramento.Zeramento(lParam[0], dt, DateTime.Parse(dt_zeramento.Text), complemento.Text, null);
                MessageBox.Show("Zeramento realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFZeramento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                //Buscar Config Zeramento
                lParam = CamadaNegocio.Contabil.Cadastro.TCN_Cad_CTB_ParamZeramento.Buscar((cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
                if (lParam.Count > 0)
                {
                    cd_contareceitas.Text = lParam[0].Cd_CReceitasstr;
                    ds_contareceitas.Text = lParam[0].ds_creceitas;
                    cd_classifrec.Text = lParam[0].Cd_classifreceitas;
                    cd_contadespesas.Text = lParam[0].Cd_CDespesasstr;
                    ds_contadespesas.Text = lParam[0].ds_despesas;
                    cd_classifdesp.Text = lParam[0].Cd_classifdespesas;
                    cd_contalucro.Text = lParam[0].Cd_cLucrostr;
                    ds_contalucro.Text = lParam[0].ds_lucro;
                    cd_classiflucro.Text = lParam[0].Cd_classiflucro;
                    cd_contacusto.Text = lParam[0].Cd_cCustostr;
                    ds_contacusto.Text = lParam[0].ds_custo;
                    cd_classifcusto.Text = lParam[0].Cd_classifcusto;
                    cd_contaresultado.Text = lParam[0].Cd_contaresultadostr;
                    ds_contaresultado.Text = lParam[0].Ds_contaresultado;
                    cd_classifresultado.Text = lParam[0].Cd_classifresultado;
                    cd_contaresultadoL.Text = lParam[0].Cd_cResultadoLstr;
                    ds_contaresultadoL.Text = lParam[0].ds_resultadoL;
                    cd_classifL.Text = lParam[0].Cd_classifresultadoL;
                    cd_contaresultadoP.Text = lParam[0].Cd_cResultadoPstr;
                    ds_contaresultadoP.Text = lParam[0].Ds_resultadoP;
                    cd_classifP.Text = lParam[0].Cd_classifresultadoP;
                }
                //Buscar Data Ultimo Zeramento
                object obj = new CamadaDados.Contabil.TCD_Zeramento().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa + "'"
                                    }
                                }, "a.dt_zeramento", string.Empty, "a.dt_zeramento desc", null);
                if (obj != null)
                    dt_ini.Text = DateTime.Parse(obj.ToString()).AddDays(1).ToString("dd/MM/yyyy");
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFZeramento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
