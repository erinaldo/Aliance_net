using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Contabil.Cadastro;
using CamadaNegocio.Contabil.Cadastro;
using Utils;

namespace Contabil.Cadastros
{
    public partial class TFCadPatrimonio : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPatrimonio()
        {
            InitializeComponent();
            DTS = BS_Patrimonio;
        }

        private void BTN_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new TCD_CadEmpresa());
        }


        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            BS_Patrimonio.ResetBindings(true);
            if (pDados.validarCampoObrigatorio())
                return TCN_CadPatrimonio.Grava_Patrimonio((BS_Patrimonio.Current as TRegistro_CadPatrimonio), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadPatrimonio lista = TCN_CadPatrimonio.Busca(ID_Patrimonio.Text);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Patrimonio.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Patrimonio.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_Patrimonio.AddNew();
                base.afterNovo();
                if (!ID_Patrimonio.Focus())
                    DT_Lancto.Focus();

            }

        }

        public override void afterCancela()
        {
            base.afterCancela();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!ID_Patrimonio.Focus())
                    DT_Lancto.Focus();
            }

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadPatrimonio.Deleta_Patrimonio((BS_Patrimonio.Current as TRegistro_CadPatrimonio), null);
                    BS_Patrimonio.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
        

        private void btn_GrupoPatrim_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_GrupoPatrim|Grupo Patrimônio|250;a.ID_GrupoPatrim|Cód. Grupo Patrimônio|100"
                          , new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim }
                          , new TCD_CadGrupoPatrimonio(), "");
        }

        private void ID_GrupoPatrim_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_grupopatrim|=|'" + ID_GrupoPatrim.Text + "'"                                              
                          , new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim }, new TCD_CadGrupoPatrimonio());
        }

        private void TFCadPatrimonio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Patrimonio);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
        }

        private void TFCadPatrimonio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Patrimonio);
        }
    }
}
