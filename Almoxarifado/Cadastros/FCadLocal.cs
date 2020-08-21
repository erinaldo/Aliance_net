using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Estoque;
using Utils;
using FormBusca;
using CamadaDados.Estoque.Cadastros;


namespace Almoxarifado.Cadastros
{
    public partial class TFCadLocal : FormCadPadrao.FFormCadPadrao
    {
        public TFCadLocal()
        {
            InitializeComponent();
            DTS = BS_CadLocal;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadLocal.RemoveCurrent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadLocal.AddNew();
            base.afterNovo();
            Id_Almox.Focus();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadLocal.gravarLocal(BS_CadLocal.Current as TRegistro_CadLocal);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadLocal lista = TCN_CadLocal.Busca(Id_Almox.Value,Nm_Almox.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadLocal.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadLocal.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadLocal.deletarLocal(BS_CadLocal.Current as TRegistro_CadLocal);
                    BS_CadLocal.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }
    }
}
