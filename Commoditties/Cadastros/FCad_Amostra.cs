using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using Utils;

namespace Commoditties.Cadastros
{
    public partial class TFCad_Amostra : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_Amostra()
        {
            InitializeComponent();
            DTS = BS_Amostra;
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
                return TCN_CadAmostra.Grava_CadAmostra(BS_Amostra.Current as TRegistro_CadAmostra);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadAmostra lista = TCN_CadAmostra.Busca(CD_TipoAmostra.Text.Trim(), 
                                                          Ds_Amostra.Text.Trim(),
                                                          Ordem.Text.Trim());

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Amostra.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Amostra.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_Amostra.AddNew();
                base.afterNovo();
                if (!CD_TipoAmostra.Focus())
                    Ds_Amostra.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_Amostra.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!CD_TipoAmostra.Focus())
                    Ds_Amostra.Focus();
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
                    TCN_CadAmostra.Deleta_CadAmostra(BS_Amostra.Current as TRegistro_CadAmostra);
                    BS_Amostra.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_metdo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_metodo|Metodo Analise|200;" +
                              "a.id_metodo|Id. Metodo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_metodo, ds_metodo },
                                            new CamadaDados.Graos.TCD_MetodoAnalise(), string.Empty);
        }

        private void id_metodo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_metodo|=|" + id_metodo.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_metodo, ds_metodo },
                                                new CamadaDados.Graos.TCD_MetodoAnalise());
        }

        private void TFCad_Amostra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_cadTpAmostra);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_Amostra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_cadTpAmostra);
        }
    }
}
