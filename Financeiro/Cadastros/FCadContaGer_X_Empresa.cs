using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormCadPadrao;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadContaGer_X_Empresa : FFormCadPadrao
    {
        public TFCadContaGer_X_Empresa()
        {
            InitializeComponent();
            pDados.set_FormatZero();
            DTS = BS_ContaGer;
        }

        private void bb_ContaGer_Click(object sender, EventArgs e)
        {

            string vColunas = "a.DS_ContaGer| Conta Gerencial|350;" +
                              "a.CD_ContaGer|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), "");
        }

        private void BTN_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa |350;" +
                              "a.CD_Empresa|Cd. Empresa|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + CD_ContaGer.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer()); 
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa},
                                    new CamadaDados.Diversos.TCD_CadEmpresa()); 
        }


        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadContaGer_X_Empresa.GravaContaGer_X_Empresa((BS_ContaGer.Current as TRegistro_CadContaGer_X_Empresa), null);
            else
                return string.Empty;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_ContaGer.Enabled = false;
                BTN_Empresa.Enabled = false;
            }
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {
            TList_CadContaGer_X_Empresa lista = TCN_CadContaGer_X_Empresa.Busca(CD_ContaGer.Text, CD_Empresa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                    BS_ContaGer.DataSource = lista;
                this.Lista = Lista;
                return lista.Count;
            }
            return 0;

        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_ContaGer.AddNew();
                base.afterNovo();
                CD_ContaGer.Focus();
            }
            if (!((this.vTP_Modo == Utils.TTpModo.tm_Edit) || (this.vTP_Modo == Utils.TTpModo.tm_Insert)))
                this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);
        }

        public override void afterBusca()
        {
            base.afterBusca();
            if (!((this.vTP_Modo == Utils.TTpModo.tm_Edit) || (this.vTP_Modo == Utils.TTpModo.tm_Insert)))
                this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if ((vTP_Modo == TTpModo.tm_Edit) || (vTP_Modo == TTpModo.tm_Insert))
                BS_ContaGer.RemoveCurrent();
            if (!((this.vTP_Modo == Utils.TTpModo.tm_Edit) || (this.vTP_Modo == Utils.TTpModo.tm_Insert)))
                this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);

        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadContaGer_X_Empresa.DeletaContaGer_X_Empresa(BS_ContaGer.Current as TRegistro_CadContaGer_X_Empresa, null);
                        BS_ContaGer.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (!((this.vTP_Modo == Utils.TTpModo.tm_Edit) || (this.vTP_Modo == Utils.TTpModo.tm_Insert)))
                this.modoBotoes(this.vTP_Modo, true, false, false, true, false, true, true);

        }

        private void TFCadContaGer_X_Empresa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadContaGer_X_Empresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
