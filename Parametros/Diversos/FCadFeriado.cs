using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Graos;
using Utils;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadFeriado : FormCadPadrao.FFormCadPadrao
    {
        public TFCadFeriado()
        {
            InitializeComponent();
            DTS = BS_CadFeriado;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadFeriado.Grava_CadFeriado(BS_CadFeriado.Current as TRegistro_CadFeriado);
            else
                return "";

        }
        public override int buscarRegistros()
        {
            
            TList_CadFeriado lista = TCN_CadFeriado.Busca(Id_Feriado.Text, DS_Feriado.Text, DT_Feriado.Text, ST_RepeteAnual.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadFeriado.DataSource = lista;

                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadFeriado.Clear();
                return lista.Count;
            }
            else
                return 0;
        }
                    

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterAltera()
        {

            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby)) 
                base.afterAltera();
            DS_Feriado.Focus();
            
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadFeriado.AddNew();
            base.afterNovo();
            Id_Feriado.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadFeriado.RemoveCurrent();

        }

        private void TFCadFeriado_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ST_RepeteAnual.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            tableLayoutPanel1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

       
    }
}

