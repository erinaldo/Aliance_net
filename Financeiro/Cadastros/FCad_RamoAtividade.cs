using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCad_RamoAtividade : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_RamoAtividade()
        {
            InitializeComponent();
            DTS = Bs_Cad_RamoAtividade;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_RamoAtividade.Grava_CadRamoAtividade(Bs_Cad_RamoAtividade.Current as TRegistro_Cad_RamoAtividade, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Cad_RamoAtividade lista = TCN_Cad_RamoAtividade.Busca(Id_RamoAtividade.Text, Ds_RamoAtividade.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    Bs_Cad_RamoAtividade.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        Bs_Cad_RamoAtividade.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                Bs_Cad_RamoAtividade.AddNew();
                base.afterNovo();
                if (!Id_RamoAtividade.Focus())
                    Ds_RamoAtividade.Focus();

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
                if (!Id_RamoAtividade.Focus())
                    Ds_RamoAtividade.Focus();
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
                    TCN_Cad_RamoAtividade.Deleta_CadRamoAtividade(Bs_Cad_RamoAtividade.Current as TRegistro_Cad_RamoAtividade, null);
                    Bs_Cad_RamoAtividade.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_RamoAtividade_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }

        private void TFCad_RamoAtividade_Load_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        
    }
}
