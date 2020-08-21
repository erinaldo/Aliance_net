using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadTabelaPreco : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTabelaPreco()
        {
            InitializeComponent();
            DTS = BS_TabelaPreco;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadTbPreco lista = TCN_CadTbPreco.Busca(CD_TabelaPreco.Text.Trim(), 
                                                          DS_TabelaPreco.Text.Trim(), "");
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TabelaPreco.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TabelaPreco.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTbPreco.GravarTbPreco(BS_TabelaPreco.Current as TRegistro_CadTbPreco);
            else
                return "";
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
            if(!CD_TabelaPreco.Focus())
                DS_TabelaPreco.Focus();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_TabelaPreco.AddNew();
                base.afterNovo();
                if (!CD_TabelaPreco.Focus())
                    DS_TabelaPreco.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                BS_TabelaPreco.RemoveCurrent();
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
                    TCN_CadTbPreco.DeletarTbPreco(BS_TabelaPreco.Current as TRegistro_CadTbPreco);
                    BS_TabelaPreco.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadTabelaPreco_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

    }
}
