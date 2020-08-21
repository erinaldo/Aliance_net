using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Almoxarifado;
using Utils;
using FormBusca;
using CamadaDados.Diversos;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadAMX_Usuario_X_AMX : FormCadPadrao.FFormCadPadrao
    {
        public TFCadAMX_Usuario_X_AMX()
        {
            InitializeComponent();
            DTS = BS_CadAMX_Usuario_X_AMX;
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
                return TCN_CadAMX_Usuario_X_AMX.Grava_CadAMX_Usuario_X_AMX(BS_CadAMX_Usuario_X_AMX.Current as TRegistro_CadAMX_Usuario_X_AMX);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadAMX_Usuario_X_AMX lista = TCN_CadAMX_Usuario_X_AMX.Busca(Login.Text.Trim(),
                                                                              Id_Almox.Text.Trim() != "" ? Convert.ToDecimal(Id_Almox.Text) : 0);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadAMX_Usuario_X_AMX.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadAMX_Usuario_X_AMX.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadAMX_Usuario_X_AMX.AddNew();
                base.afterNovo();
                if (!Login.Focus())
                {
                    Id_Almox.Focus();
                    ST_Operacao_Conferencia.Enabled = true;
                    ST_Operacao_Entrada.Enabled = true;
                    ST_Operacao_Saida.Enabled = true;
                }
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadAMX_Usuario_X_AMX.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                Id_Almox.Focus();
                ST_Operacao_Conferencia.Enabled = true;
                ST_Operacao_Entrada.Enabled = true;
                ST_Operacao_Saida.Enabled = true;
                bbLogin.Enabled = false;
                BB_Almoxarifado.Enabled = false;
                
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
                    TCN_CadAMX_Usuario_X_AMX.Deleta_CadAMX_Usuario_X_AMX(BS_CadAMX_Usuario_X_AMX.Current as TRegistro_CadAMX_Usuario_X_AMX);
                    BS_CadAMX_Usuario_X_AMX.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void Id_Almox_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("Id_Almox|=|'" + Id_Almox.Text + "'"
          , new Componentes.EditDefault[] { Id_Almox, DS_Almoxarifado }, new TCD_CadLocal());
        }

        private void BB_Almoxarifado_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("Id_Almox|Cód. Almoxarifado|50;DS_Almoxarifado|Desc. Almoxarifado|350"
                   , new Componentes.EditDefault[] { Id_Almox, DS_Almoxarifado }, new TCD_CadLocal(), null);
        }

        private void bbLogin_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("login|Login do Usuario|100", new Componentes.EditDefault[] { Login }, new TCD_CadUsuario(), null);
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("login|=|'" + Login.Text + "'", new Componentes.EditDefault[] { Login }, new TCD_CadUsuario());
        }

        private void TFCadAMX_Usuario_X_AMX_Load(object sender, EventArgs e)
        {
            pd_Operacao.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

        
    }
}
