using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Producao.Cadastros;
using CamadaNegocio.Producao.Cadastros;

namespace Producao.Cadastros
{
    public partial class TFCadTurno : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTurno()
        {
            InitializeComponent();
            DTS = bsTurno;
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
            return TCN_Turno.Gravar((bsTurno.Current as TRegistro_Turno), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {

            TList_Turno lista = TCN_Turno.Buscar(id_turno.Text,
                                                 ds_turno.Text,
                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTurno.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTurno.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))

                bsTurno.AddNew();
            base.afterNovo();
            if (!id_turno.Focus())
                ds_turno.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTurno.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_turno.Focus();

        }

        public override void excluirRegistro()
        {
            if (bsTurno.Count > 0)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Turno.Excluir(bsTurno.Current as TRegistro_Turno, null);
                        bsTurno.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
        }
    }
}
