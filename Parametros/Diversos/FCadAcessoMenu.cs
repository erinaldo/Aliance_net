using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using Querys.Financeiro;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class FCadAcessoMenu : FormCadPadrao.FFormCadPadrao
    {
        public FCadAcessoMenu()
        {
            InitializeComponent();
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
                return TCN_CadAcesso.GravarAcesso((Bs_CadAcesso.Current as TRegistro_CadAcesso));
            else
                return "";
        }
        public override int buscarRegistros()
        {
            TList_CadAcesso lista = TCN_CadAcesso.Busca(login.Text, id_menu.Text, "", false, "", 0, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_CadAcesso.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_CadAcesso.Clear();
                return lista.Count;
            }
            else

                return 0;
        }
        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                Bs_CadAcesso.AddNew();
                base.afterNovo();
                if (!(login.Focus()))
                    id_menu.Focus();
            }
        }
        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                Bs_CadAcesso.RemoveCurrent();
        }
        public override void afterAltera()
        {
            base.afterAltera();
            id_menu.Focus();
        }
        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadAcesso.DeletarAcesso((Bs_CadAcesso.Current as TRegistro_CadAcesso));
                    Bs_CadAcesso.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}