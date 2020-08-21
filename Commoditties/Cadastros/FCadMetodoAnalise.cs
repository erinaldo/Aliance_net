using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using Utils;

namespace Commoditties.Cadastros
{
    public partial class TFCadMetodoAnalise : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMetodoAnalise()
        {
            InitializeComponent();
            this.DTS = bsMetodo;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_MetodoAnalise.Gravar(bsMetodo.Current as TRegistro_MetodoAnalise, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_MetodoAnalise lista = TCN_MetodoAnalise.Buscar(id_metodo.Text,
                                                                 ds_metodo.Text,
                                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMetodo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsMetodo.Clear();
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
                bsMetodo.AddNew();
            base.afterNovo();
            if (!id_metodo.Focus())
                ds_metodo.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_metodo.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsMetodo.RemoveCurrent();

        }

        private void TFCadMetodoAnalise_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
