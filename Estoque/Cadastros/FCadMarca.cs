using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Estoque.Cadastros;
using Utils;


namespace Estoque.Cadastros
{
    public partial class TFCadMarca : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMarca()
        {
            InitializeComponent();
            DTS = BS_CadMarca;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadMarca.Grava_CadMarca(BS_CadMarca.Current as TRegistro_CadMarca);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadMarca lista = TCN_CadMarca.Busca(Cd_Marca.Text, Ds_Marca.Text);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadMarca.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadMarca.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadMarca.AddNew();
                base.afterNovo();
                if (!Cd_Marca.Focus())
                    Ds_Marca.Focus();
                
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
                if (!Cd_Marca.Focus())
                    Ds_Marca.Focus();
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
                    TCN_CadMarca.Deleta_CadMarca(BS_CadMarca.Current as TRegistro_CadMarca);
                    BS_CadMarca.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadMarca_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }
    }
}
