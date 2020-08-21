using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Graos;
using CamadaNegocio.Graos;


namespace Commoditties.Cadastros
{
    public partial class TFCad_Safra : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Safra()
        {
            InitializeComponent();
            DTS = BS_CadSafra;
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
                return TCN_CadSafra.Gravar(BS_CadSafra.Current as TRegistro_CadSafra, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadSafra lista = TCN_CadSafra.Busca(AnoSafra.Text, 
                                                      DS_Safra.Text,
                                                      null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadSafra.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadSafra.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadSafra.AddNew();
                base.afterNovo();
                if (!AnoSafra.Focus())
                    DS_Safra.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadSafra.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if(!AnoSafra.Focus())
                    DS_Safra.Focus();
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
                    TCN_CadSafra.Excluir(BS_CadSafra.Current as TRegistro_CadSafra, null);
                    BS_CadSafra.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_Safra_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}