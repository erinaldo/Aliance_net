using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadPais : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPais()
        {
            InitializeComponent();
            DTS = BS_Pais;
        }
             
        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return TCN_CadPais.GravarPais((BS_Pais.Current as TRegistro_CadPais), null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadPais lista = TCN_CadPais.Buscar(CD_PAIS.Text, NM_PAIS.Text, "", 0,null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Pais.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Pais.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_Pais.AddNew();
                base.afterNovo();
                if (!CD_PAIS.Focus())
                {
                    NM_PAIS.Focus();
                }

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
                NM_PAIS.Focus();
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
                    TCN_CadPais.DeletarPais(BS_Pais.Current as TRegistro_CadPais, null);
                    BS_Pais.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        private void g_Pais_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TFCadPais_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);

        }
            



    }
}
