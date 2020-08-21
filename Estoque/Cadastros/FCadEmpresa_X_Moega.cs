using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Diversos;
using Utils;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCadEmpresa_X_Moega : FormCadPadrao.FFormCadPadrao
    {
        public TFCadEmpresa_X_Moega()
        {
            InitializeComponent();
            DTS = BS_CadEmpresa_X_Moega;
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
                return TCN_CadEmpresa_X_Moega.Grava_CadEmpresa_X_Moega(BS_CadEmpresa_X_Moega.Current as TRegistro_CadEmpresa_X_Moega);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadEmpresa_X_Moega lista = TCN_CadEmpresa_X_Moega.Busca(CD_Moega.Text, CD_Empresa.Text, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadEmpresa_X_Moega.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadEmpresa_X_Moega.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadEmpresa_X_Moega.AddNew();
                base.afterNovo();
                this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
                if (!CD_Moega.Focus())
                {
                    CD_Empresa.Focus();
                }
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadEmpresa_X_Moega.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            this.modoBotoes(this.vTP_Modo, false, false, true, false, true, false, false);
            BB_Moega.Enabled = false;
            BB_Empresa.Enabled = false;
        }

        public override void afterBusca()
        {
            base.afterBusca();
            this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);
        }

        public override void afterExclui()
        {
            base.afterExclui();
            this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, false);
        }

        public override void afterGrava()
        {
            base.afterGrava();
            this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);
        }

        public override void excluirRegistro()
        {
            if (g_TFCadEmpresa_X_Moega.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadEmpresa_X_Moega.Deleta_CadEmpresa_X_Moega(BS_CadEmpresa_X_Moega.Current as TRegistro_CadEmpresa_X_Moega);
                        BS_CadEmpresa_X_Moega.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_Moega_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moega|Descrição Moega|350;" +
                              "CD_Moega|Cód. Moega|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega },
                                    new TCD_CadMoega(), "");
        }

        private void CD_Moega_Leave(object sender, EventArgs e)
        {
            if (CD_Moega.Text.Trim() != "")
            {
                string vColunas = CD_Moega.NM_CampoBusca + "|=|'" + CD_Moega.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega},
                                        new TCD_CadMoega());
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string empresa_aux = "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                               "(exists(select 1 from tb_div_usuario_x_grupos y " +
                               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa},
                                    new TCD_CadEmpresa(), empresa_aux);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa |=|'" + CD_Empresa.Text + "';" +
                "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                                " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcCentral.SelectedTab.Equals(tpPadrao))
            {
                this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
            }
        }

        private void TFCadEmpresa_X_Moega_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_TFCadEmpresa_X_Moega);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadEmpresa_X_Moega_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_TFCadEmpresa_X_Moega);
        }
    }
}

