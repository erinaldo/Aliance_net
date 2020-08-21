using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Sementes.Cadastros;
using CamadaNegocio.Sementes.Cadastros;

namespace Sementes.Cadastros
{
    public partial class TFCad_TipoAnalise : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TipoAnalise()
        {
            InitializeComponent();
            this.DTS = bsTipoAnalise;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_TipoAnalise.GravarTipoAnalise(bsTipoAnalise.Current as TRegistro_TipoAnalise, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_TipoAnalise lista = TCN_TipoAnalise.Buscar(id_analise.Text,
                                                             ds_tipoanalise.Text,
                                                             0,
                                                             string.Empty,
                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTipoAnalise.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTipoAnalise.Clear();
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
                bsTipoAnalise.AddNew();
            base.afterNovo();
            if (!id_analise.Focus())
                ds_tipoanalise.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_tipoanalise.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTipoAnalise.RemoveCurrent();

        }
    }
}
