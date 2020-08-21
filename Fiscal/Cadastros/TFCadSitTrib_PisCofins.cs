using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;

namespace Fiscal.Cadastros
{
    public partial class TFCadSitTrib_PisCofins : FormCadPadrao.FFormCadPadrao
    {
        public TFCadSitTrib_PisCofins()
        {
            InitializeComponent();
            DTS = BS_SitTribPisCofins;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_SitTribPisCofins.AddNew();
            base.afterNovo();
            if (!cd_sitTrib.Focus())
                ds_sitTrib.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                cd_sitTrib.Focus();
            ds_sitTrib.Enabled = true;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert) 
                BS_SitTribPisCofins.RemoveCurrent();
            cd_sitTrib.Focus();
        }

        public override string  gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadSitTrib_Piscofins.GravarPiscofins(BS_SitTribPisCofins.Current as TRegistro_CadSitTrib_Piscofins);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadSitTrib_Piscofins lista = TCN_CadSitTrib_Piscofins.Busca(cd_sitTrib.Text, ds_sitTrib.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_SitTribPisCofins.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_SitTribPisCofins.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadSitTrib_Piscofins.DeletarPiscofins(BS_SitTribPisCofins.Current as TRegistro_CadSitTrib_Piscofins);
                    BS_SitTribPisCofins.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void cd_sitTrib_Leave(object sender, EventArgs e)
        {
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                buscarRegistros();
            }
        }

        private void TFCadSitTrib_PisCofins_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        
    }
}
