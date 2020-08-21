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
using Utils;


namespace Estoque.Cadastros
{
    public partial class TFCad_Moega : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Moega()
        {
            InitializeComponent();
            DTS = BS_CadMoega;
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
                return TCN_CadMoega.Grava_CadMoega(BS_CadMoega.Current as TRegistro_CadMoega);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadMoega lista = TCN_CadMoega.Busca(CD_Moega.Text, DS_Moega.Text, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadMoega.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadMoega.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadMoega.AddNew();
                base.afterNovo();
                if (!CD_Moega.Focus())
                    DS_Moega.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadMoega.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_Moega.Focus();
        }

        public override void excluirRegistro()
        {
            if (g_CadMoega.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadMoega.Deleta_CadMoega(BS_CadMoega.Current as TRegistro_CadMoega);
                        BS_CadMoega.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void CD_Moega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TFCad_Moega_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
