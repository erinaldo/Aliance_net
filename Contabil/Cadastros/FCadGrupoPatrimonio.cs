using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Contabil.Cadastro;
using CamadaDados.Contabil.Cadastro;
using Utils;

namespace Contabil.Cadastros
{
    public partial class TFCadGrupoPatrimonio : FormCadPadrao.FFormCadPadrao
    {
        public TFCadGrupoPatrimonio()
        {
            InitializeComponent();
            DTS = BS_GrupoPatrimonio;
        }
        
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadGrupoPatrimonio.Grava_GrupoPatrimonio((BS_GrupoPatrimonio.Current as TRegistro_CadGrupoPatrimonio), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadGrupoPatrimonio lista = TCN_CadGrupoPatrimonio.Busca(ID_GrupoPatrim.Text);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_GrupoPatrimonio.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_GrupoPatrimonio.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_GrupoPatrimonio.Clear();
                BS_GrupoPatrimonio.AddNew();
                base.afterNovo();
                if (!ID_GrupoPatrim.Focus())
                    Ds_GrupoPatrim.Focus();

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
                if (!ID_GrupoPatrim.Focus())
                    Ds_GrupoPatrim.Focus();
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
                    TCN_CadGrupoPatrimonio.Deleta_GrupoPatrimonio((BS_GrupoPatrimonio.Current as TRegistro_CadGrupoPatrimonio), null);
                    BS_GrupoPatrimonio.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
        
        private void TFCadGrupoPatrimonio_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }

    }
}
