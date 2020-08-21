using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadSitTribut : FormCadPadrao.FFormCadPadrao
    {
        public TFCadSitTribut()
        {
            InitializeComponent();
            DTS = bs_CadSitTrib;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("1 - TRIBUTADO", "1"));
            cbx.Add(new TDataCombo("2 - ISENTA", "2"));
            cbx.Add(new TDataCombo("3 - OUTRAS", "3"));
            tp_situacao.DataSource = cbx;
            tp_situacao.DisplayMember = "Display";
            tp_situacao.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadSitTribut lista = TCN_CadSitTribut.Busca(cd_st.Text,
                                                              DS_Situacao.Text,
                                                              CD_Imposto.Text,
                                                              null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_CadSitTrib.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_CadSitTrib.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bs_CadSitTrib.AddNew();
                base.afterNovo();
                cd_st.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            DS_Situacao.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bs_CadSitTrib.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadSitTribut.deletaSitTrib(bs_CadSitTrib.Current as TRegistro_CadSitTribut, null);
                    bs_CadSitTrib.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadSitTribut.gravaSitTrib(bs_CadSitTrib.Current as TRegistro_CadSitTribut, null);
            else
                return string.Empty;
        }

        private void TFCadSitTribut_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this); 
            this.pDados.set_FormatZero();
        }

        private void CD_Imposto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_imposto|=|" + CD_Imposto.Text,
                new Componentes.EditDefault[] { CD_Imposto, ds_imposto }, new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_imposto|Descrição|200;cd_imposto|Cód. Imposto|80",
                new Componentes.EditDefault[] { CD_Imposto, ds_imposto }, new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void TFCadSitTribut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

