using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadPortadorXJuro : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPortadorXJuro()
        {
            InitializeComponent();
            this.DTS = bsPortJuro;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Portador_X_Juros.Gravar(bsPortJuro.Current as TRegistro_Portador_X_Juros, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Portador_X_Juros lista = TCN_Portador_X_Juros.Buscar(cd_juro.Text,
                                                                       cd_portador.Text,
                                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsPortJuro.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsPortJuro.Clear();
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
                bsPortJuro.AddNew();
            base.afterNovo();
            cd_portador.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_juro.Enabled = false;
            bb_portador.Enabled = false;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsPortJuro.RemoveCurrent();

        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Descrição Portador|350;" +
                              "CD_Portador|Cód. Portador|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new TCD_CadPortador(), "");
  
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            if (cd_portador.Text.Trim() != "")
            {
                string vColunas = cd_portador.NM_CampoBusca + "|=|'" + cd_portador.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                        new TCD_CadPortador());
            }
            else
            {
                ds_portador.Clear();
            }
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Juro|Descrição Juro|350;" +
                              "CD_Juro|Cód. Juro|100";
            string vParamFixo = "CD_Juro|NOT IN|(Select CD_Juro From TB_FIN_Juro_X_Portador x Where x.CD_Portador = '" + cd_portador.Text + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_juro, ds_juro },
                                    new TCD_CadJuro(), vParamFixo);
        }

        private void cd_juro_Leave(object sender, EventArgs e)
        {
            if (cd_juro.Text.Trim() != "")
            {
                string vColunas = cd_juro.NM_CampoBusca + "|=|'" + cd_juro.Text + "';" +
                                  "CD_Juro|NOT IN|(Select CD_Juro From TB_FIN_Juro_X_Portador x Where x.CD_Portador = '" + cd_portador.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_juro, ds_juro },
                                        new TCD_CadJuro());
            }
            else
            {
                ds_juro.Clear();
                buscarRegistros();
            }
        }

        private void TFCadPortadorXJuro_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadPortadorXJuro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

