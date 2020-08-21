using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using Utils;
using System.Collections;

namespace Faturamento.Cadastros
{
    public partial class TFCadModeloNF : FormCadPadrao.FFormCadPadrao
    {
        private string path_principal = string.Empty;
        public TFCadModeloNF()
        {
            InitializeComponent();
            DTS = BS_CadModeloNF;
        }
        
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadModeloNF.Grava_CadModeloNF(BS_CadModeloNF.Current as TRegistro_CadModeloNF, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadModeloNF lista = TCN_CadModeloNF.Busca(CD_Modelo.Text, DS_Modelo.Text, string.Empty, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadModeloNF.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadModeloNF.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadModeloNF.AddNew();
                base.afterNovo();
                if (!CD_Modelo.Focus())
                    DS_Modelo.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadModeloNF.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_Modelo.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadModeloNF.Deleta_CadModeloNF(BS_CadModeloNF.Current as TRegistro_CadModeloNF, null);
                    BS_CadModeloNF.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCad_ModeloNF_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();           
        }
    }
}