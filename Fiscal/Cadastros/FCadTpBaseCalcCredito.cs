using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;

namespace Fiscal.Cadastros
{
    public partial class TFCadTpBaseCalcCredito : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpBaseCalcCredito()
        {
            InitializeComponent();
            this.DTS = bsTpBase;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_TpBaseCalcCredito.Gravar(bsTpBase.Current as TRegistro_TpBaseCalcCredito, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {

            TList_TpBaseCalcCredito lista = TCN_TpBaseCalcCredito.Buscar(id_base.Text,
                                                                         ds_basecredito.Text,
                                                                         null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpBase.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTpBase.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_basecredito.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_busca) || (this.vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsTpBase.AddNew();
                base.afterNovo();
                if (!id_base.Focus())
                    ds_basecredito.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpBase.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_TpBaseCalcCredito.Excluir(bsTpBase.Current as TRegistro_TpBaseCalcCredito, null);
                    bsTpBase.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}
