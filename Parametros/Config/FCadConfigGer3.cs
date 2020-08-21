using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.ConfigGer;
using CamadaNegocio.ConfigGer;

namespace Parametros.Config
{
    public partial class TFCadConfigGer3 : FormCadPadrao.FFormCadPadrao
    {
        public TFCadConfigGer3()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            if (tp_dado.SelectedValue != null)
                habilitaValores(tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("B"));
            else
                habilitaValores(false, false, false, false);
        }

        public override string gravarRegistro()
        {
            if (vTP_Modo == TTpModo.tm_Edit)
                ds_parametro.ST_NotNull = false;
            if (pDados.validarCampoObrigatorio())
            {
                ds_parametro.ST_NotNull = true;
                return TCN_CadParamGer.GravaParamGer((bsParamGer.Current as TRegistro_ParamGer));
            }
            else

                return "";
        }

        public override int buscarRegistros()
        {


            string seleParametro = "";
            if (ds_parametro.SelectedValue != null)
                seleParametro = ds_parametro.SelectedValue.ToString();
            string seleTpDado = "";
            if (tp_dado.SelectedValue != null)
                seleTpDado = tp_dado.SelectedValue.ToString();

            TList_RegParamGer lista = TCN_CadParamGer.Busca(0, seleParametro, ds_finalidade.Text, seleTpDado, 0, "");
            if (lista != null)
            {
                if (lista.Count > 0)
                    bsParamGer.DataSource = lista;
                     return lista.Count;
            }
            this.Lista = Lista;
            return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsParamGer.AddNew();
                ds_parametro.SelectedIndex = -1;
                base.afterNovo();
                ds_parametro.Focus();
            }
        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsParamGer.RemoveCurrent();
            ds_parametro.SelectedIndex = -1;
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                ds_parametro.Enabled = false;
                ds_finalidade.Focus();
            }
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadParamGer.DeletaParamGer((bsParamGer.Current as TRegistro_ParamGer));
                    bsParamGer.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void habilitaValores(bool vString, bool vNumerico, bool vData, bool vBooleano)
        {
            vl_string.Enabled = vString;
            vl_string.ST_NotNull = vString;
            vl_numerico.Enabled = vNumerico;
            vl_numerico.ST_NotNull = vNumerico;
            vl_data.Enabled = vData;
            vl_data.ST_NotNull = vData;
            vl_bool.Enabled = vBooleano;
            vl_bool.ST_NotNull = vBooleano;
        }

        private void TFCadConfigGer3_Load(object sender, EventArgs e)
        {
            ArrayList CBox = new ArrayList();
            CBox.Add(new Utils.TDataCombo("STRING", "S"));
            CBox.Add(new Utils.TDataCombo("NUMERICO", "N"));
            CBox.Add(new Utils.TDataCombo("DATA", "D"));
            CBox.Add(new Utils.TDataCombo("BOOLEANO", "B"));
            tp_dado.DataSource = CBox;
            tp_dado.DisplayMember = "Display";
            tp_dado.ValueMember = "Value";
            tp_dado.SelectedIndex = -1;

            //se o cadastro estiver vazio de onde ira buscar a lista de parametros?
            //ArrayList CBox1 = TCN_CadParamGer.BuscaParametros(false);

            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("PATH DLL", "PATH_DLL"));
            CBox1.Add(new Utils.TDataCombo("PATH RELATÓRIOS", "PATH_RELATORIO"));
            CBox1.Add(new Utils.TDataCombo("MOEDA PADRÃO", "CD_MOEDA_PADRAO"));
            CBox1.Add(new Utils.TDataCombo("TABELA DE PREÇOS DO SITE INTERNET", "CD_TABELAPRECO_SITE"));
            CBox1.Add(new Utils.TDataCombo("EMPRESA PADRÃO DO SITE INTERNET", "CD_EMPRESA_SITE"));
            

            ds_parametro.DataSource = CBox1;
            ds_parametro.DisplayMember = "Display";
            ds_parametro.ValueMember = "Value";
            ds_parametro.SelectedIndex = -1;
        }

        private void tp_dado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit))
                habilitaValores(tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                                tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                                tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                                tp_dado.SelectedValue.ToString().Trim().Equals("B"));
        }

        private void vl_string_EnabledChanged(object sender, EventArgs e)
        {
            if ((!(vl_string.Enabled)) && (vTP_Modo == TTpModo.tm_Edit))
                vl_string.Clear();
        }

        private void vl_numerico_EnabledChanged(object sender, EventArgs e)
        {
            if ((!(vl_numerico.Enabled)) && (vTP_Modo == TTpModo.tm_Edit))
                vl_numerico.Value = 0;
        }

        private void vl_data_EnabledChanged(object sender, EventArgs e)
        {
            if ((!(vl_data.Enabled)) && (vTP_Modo == TTpModo.tm_Edit))
                vl_data.Clear();
        }

        private void vl_bool_EnabledChanged(object sender, EventArgs e)
        {
            if ((!(vl_bool.Enabled)) && (vTP_Modo == TTpModo.tm_Edit))
                vl_bool.Checked = false;
        }

        private void tList_RegParamGerDataGridDefault_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

