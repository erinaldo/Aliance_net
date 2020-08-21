using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using Utils;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;

namespace Estoque.Cadastros
{
    public partial class TFCad_LocalArm_X_Empresa : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_LocalArm_X_Empresa()
        {
            InitializeComponent();
            DTS = BS_CadLocalArm_X_Empresa;
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
                return TCN_CadLocalArm_X_Empresa.Gravar(BS_CadLocalArm_X_Empresa.Current as TRegistro_CadLocalArm_X_Empresa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadLocalArm_X_Empresa lista = TCN_CadLocalArm_X_Empresa.Busca(CD_Local.Text, CD_Empresa.Text, string.Empty, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadLocalArm_X_Empresa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadLocalArm_X_Empresa.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadLocalArm_X_Empresa.AddNew();
                base.afterNovo();
                if (!CD_Empresa.Focus())
                    CD_Local.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadLocalArm_X_Empresa.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_Local.Enabled = false;
            BB_Empresa.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (g_CadLocalArm_X_Empresa.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadLocalArm_X_Empresa.Excluir(BS_CadLocalArm_X_Empresa.Current as TRegistro_CadLocalArm_X_Empresa, null);
                        BS_CadLocalArm_X_Empresa.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

       private void BB_Local_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Local Armazenagem|350;" +
                              "CD_Local|Cód. Local|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm(), "isnull(a.st_registro, 'A')|<>|'C'");
        }
        
       private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_local|=|'" + CD_Local.Text + "';" +
                              "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm());
        }

       private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string empresa_aux = "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                               "(exists(select 1 from tb_div_usuario_x_grupos y " +
                               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), empresa_aux);
        }

       private void CD_Empresa_Leave(object sender, EventArgs e)
       {
           string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
               "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                               "(exists(select 1 from tb_div_usuario_x_grupos y " +
                               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
           UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                   new TCD_CadEmpresa());

       }

       private void CD_Local_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
               e.Handled = true;
       }

       private void CD_Empresa_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
               e.Handled = true;
       }

       private void TFCad_LocalArm_X_Empresa_Load(object sender, EventArgs e)
       {
           Utils.ShapeGrid.RestoreShape(this, g_CadLocalArm_X_Empresa);
           if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
               Idioma.TIdioma.AjustaCultura(this);
       }

       private void TFCad_LocalArm_X_Empresa_FormClosing(object sender, FormClosingEventArgs e)
       {
           Utils.ShapeGrid.SaveShape(this, g_CadLocalArm_X_Empresa);
       }
     }
}