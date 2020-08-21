using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Estoque.Cadastros;

namespace Estoque.Cadastros
{
    public partial class TFCad_Genero : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Genero()
        {
            InitializeComponent();
            DTS = bs_CadGenero;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_Genero.GravaCad_Genero(bs_CadGenero.Current as TRegistro_Cad_Genero, null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_Cad_Genero lista = TCN_Cad_Genero.buscar(id_Genero.Text, ds_Genero.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CadGenero.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CadGenero.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bs_CadGenero.AddNew();
                base.afterNovo();

                if (!id_Genero.Focus())
                    ds_Genero.Focus();

            }

        }

        public override void afterCancela()
        {
            base.afterCancela();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!id_Genero.Focus())
                    ds_Genero.Focus();
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
                    TCN_Cad_Genero.DeletaCad_Genero(bs_CadGenero.Current as TRegistro_Cad_Genero, null);
                    bs_CadGenero.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_Genero_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
