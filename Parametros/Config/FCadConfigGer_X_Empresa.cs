using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.ConfigGer;
using CamadaNegocio.ConfigGer;

namespace Parametros.Config
{
    public partial class TFCadConfigGer_X_Empresa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadConfigGer_X_Empresa()
        {
            InitializeComponent();
            DTS = bsConfigGerEmpresa;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadParamGer_X_Empresa.GravaParamGer_X_Empresa((bsConfigGerEmpresa.Current as TRegistro_ParamGer_X_Empresa));
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_RegParamGer_X_Empresa lista = TCN_CadParamGer_X_Empresa.Busca(id_parametro.Text, cd_empresa.Text, 0, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                    bsConfigGerEmpresa.DataSource = lista;
                this.Lista = lista;
                return lista.Count;

            }
            return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsConfigGerEmpresa.AddNew();
                base.afterNovo();
                id_parametro.Focus();
            }
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsConfigGerEmpresa.RemoveCurrent();
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_configger.Enabled = false;
                bb_empresa.Enabled = false;
            }
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadParamGer_X_Empresa.DeletaParamGer((bsConfigGerEmpresa.Current as TRegistro_ParamGer_X_Empresa));
                    bsConfigGerEmpresa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_configger_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Parametro|Descrição Parametro|350;" +
                              "DS_Finalidade|Finalidade Parametro|350;" +
                              "ID_Parametro|Cd. Parametro|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_parametro, ds_parametro },
                                    new TCD_ParamGer(), "");
        }

        private void id_parametro_Leave(object sender, EventArgs e)
        {
            string vColunas = "ID_Parametro|=|" + id_parametro.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_parametro, ds_parametro },
                                    new TCD_ParamGer());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
                new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFCadConfigGer_X_Empresa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, tList_RegParamGer_X_EmpresaDataGridDefault);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadConfigGer_X_Empresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, tList_RegParamGer_X_EmpresaDataGridDefault);
        }
    }
}

