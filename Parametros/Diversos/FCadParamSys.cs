using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadParamSys : FormCadPadrao.FFormCadPadrao
    {
        public TFCadParamSys()
        {
            InitializeComponent();
            this.DTS = bsParamSys;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadParamSys.GravaParam(bsParamSys.Current as TRegistro_CadParamSys, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadParamSys lista = TCN_CadParamSys.Busca(NM_CAMPO.Text,
                ST_AUTO.Checked ? "S" : string.Empty,
                TAMANHO.Value, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsParamSys.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsParamSys.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                bsParamSys.AddNew();
            base.afterNovo();
            if (!NM_CAMPO.Focus())
                TAMANHO.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            TAMANHO.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsParamSys.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadParamSys.DeletaParam(bsParamSys.Current as TRegistro_CadParamSys, null);
                    bsParamSys.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
        private void TFCadParamSys_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }
    }
}

