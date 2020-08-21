using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CamadaNegocio.Graos;
using CamadaDados.Graos;
using Utils;

namespace Commoditties.Cadastros
{
    public partial class TFCad_Headge : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Headge()
        {
            InitializeComponent();


            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("IMPOSTOS", "I"));
            cbx.Add(new Utils.TDataCombo("FRETE", "F"));
            cbx.Add(new Utils.TDataCombo("COMISSOES", "C"));
            cbx.Add(new Utils.TDataCombo("OUTROS", "O"));
            CB_TipoHeadge.DataSource = cbx;
            CB_TipoHeadge.DisplayMember = "Display";
            CB_TipoHeadge.ValueMember = "Value";

            DTS = BS_headge;

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
                return TCN_CadHeadge.Grava_CadHeadge(BS_headge.Current as TRegistro_CadHeadge);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadHeadge lista = TCN_CadHeadge.Busca(Id_Headge.Value,
                                                          DS_Headge.Text.Trim(),
                                                          CB_TipoHeadge.SelectedValue != null ? CB_TipoHeadge.SelectedValue.ToString().Trim() : "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_headge.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_headge.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_headge.AddNew();
                base.afterNovo();
                if (!Id_Headge.Focus())
                    DS_Headge.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_headge.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!Id_Headge.Focus())
                    DS_Headge.Focus();
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
                    TCN_CadHeadge.Deleta_CadHeadge(BS_headge.Current as TRegistro_CadHeadge);
                    BS_headge.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

    }
}
