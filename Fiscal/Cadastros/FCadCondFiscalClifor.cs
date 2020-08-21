using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;

namespace Fiscal.Cadastros
{
    public partial class TFCadCondFiscalClifor : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCondFiscalClifor()
        {
            InitializeComponent();
            DTS = BS_FiscalClifor;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadConFiscalClifor lista = TCN_CadCondFiscalClifor.Busca(Cd_condFiscal_clifor.Text, Ds_condFiscal.Text, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_FiscalClifor.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_FiscalClifor.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCondFiscalClifor.GravarFiscalClifor(BS_FiscalClifor.Current as TRegistro_CadCondFiscalClifor);
            else
                return "";
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_FiscalClifor.AddNew();
                base.afterNovo();
                if (!(Cd_condFiscal_clifor.Focus()))
                    Ds_condFiscal.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            Ds_condFiscal.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_FiscalClifor.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadCondFiscalClifor.DeletarFiscalClifor(BS_FiscalClifor.Current as TRegistro_CadCondFiscalClifor);
                    BS_FiscalClifor.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadCondFiscalClifor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCondFiscalClifor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

       

    
    }
}

