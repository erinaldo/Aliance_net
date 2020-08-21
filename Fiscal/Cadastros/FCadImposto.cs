using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Fiscal;
using CamadaDados.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadImposto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadImposto()
        {
            InitializeComponent();
            DTS = bs_CadImposto;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadImposto.Gravar(bs_CadImposto.Current as TRegistro_CadImposto, null);
            else
                return string.Empty;
        }
        
        public override int buscarRegistros()
        {
            TList_CadImposto lista = TCN_CadImposto.Busca(cd_imposto.Text, ds_imposto.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CadImposto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CadImposto.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bs_CadImposto.AddNew();
                base.afterNovo();
                if (!(cd_imposto.Focus()))
                    ds_imposto.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_imposto.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bs_CadImposto.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadImposto.Excluir(bs_CadImposto.Current as TRegistro_CadImposto, null);
                    bs_CadImposto.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadImposto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gridImposto);
        }

        private void TFCadImposto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gridImposto);
        }
    }
}


