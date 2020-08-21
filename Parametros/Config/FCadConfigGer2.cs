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

using FormBusca;
using BancoDados;
using Querys;

using Querys.Fiscal;
using Querys.Estoque;
using Querys.Contabil;

using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;




namespace Parametros.Config
{
    public partial class TFCadConfigGer2 : FormCadPadrao.FFormCadPadrao
    {
        
        private WebCamLibrary.WebCam camera;
        private int posicao_anterior;



        public TFCadConfigGer2()
        {
            InitializeComponent();

            try
            {
                camera = WebCamLibrary.WebCam.NewWebCamDirectX();
                camera.Initialize();
            }
            catch
            { camera = null; }
        }
        
        public override void formatZero()
        {
            pDados.set_FormatZero();
        }
        
        public override void afterBusca()
        {
            base.afterBusca();
            
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            if (tp_dado.SelectedValue != null)
                habilitaValores(tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("B"),
                                    tp_dado.SelectedValue.ToString().Trim().Equals("I")
                                    );
            else
                habilitaValores(false, false, false, false,false);
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
                tc_Tipo_dado.SelectedTab = tpDados;
                bsParamGer.AddNew();

                ds_parametro.SelectedIndex = -1;

                base.afterNovo();
                ds_parametro.Focus();

                tempo.Enabled = true;

                tc_Tipo_dado.Enabled = true;

            }

        }

        public override void afterCancela()
        {
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsParamGer.RemoveCurrent();
            ds_parametro.SelectedIndex = -1;
            base.afterCancela();
            tc_Tipo_dado.Enabled = false;
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

        private void habilitaValores(bool vString, bool vNumerico, bool vData, bool vBooleano, bool vImagem)
        {
            vl_string.Enabled = vString;
            vl_string.ST_NotNull = vString;
            vl_numerico.Enabled = vNumerico;
            vl_numerico.ST_NotNull = vNumerico;
            vl_data.Enabled = vData;
            vl_data.ST_NotNull = vData;
            vl_bool.Enabled = vBooleano;
            vl_bool.ST_NotNull = vBooleano;

            if (vImagem)
            {
                tc_Tipo_dado.SelectedIndex = 1;
                tpImagem.Show();
            }
            else
            {
                tc_Tipo_dado.SelectedIndex = 0;
                tpDados.Show();
            }

        }

        private void TFCadConfigGer_Load(object sender, EventArgs e)
        {
            ArrayList CBox = new ArrayList();
            CBox.Add(new Utils.TDataCombo("STRING", "S"));
            CBox.Add(new Utils.TDataCombo("NUMERICO", "N"));
            CBox.Add(new Utils.TDataCombo("DATA", "D"));
            CBox.Add(new Utils.TDataCombo("BOOLEANO", "B"));
            CBox.Add(new Utils.TDataCombo("IMAGEM", "I"));


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

        private void tp_dado_SelectedIndexChanged(object sender, EventArgs e)
         {
             int i = 0;

             for (i = 0; i < tp_dado.Items.Count; i++)
             {
                 if (tp_dado.Items[i].Equals(new Utils.TDataCombo("IMAGEM", "I")))
                 {
                     break;
                 }
             }

             if (i != tp_dado.SelectedIndex)
                posicao_anterior = tp_dado.SelectedIndex;


             if ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit))
             {

                 if (tp_dado.SelectedIndex!=-1)
                 habilitaValores(tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                          tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                          tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                          tp_dado.SelectedValue.ToString().Trim().Equals("B"),
                          tp_dado.SelectedValue.ToString().Trim().Equals("I")
                 );
                 
             }


        }

        private void tc_Tipo_dado_SelectedIndexChanged(object sender, EventArgs e)
         {
             int i = 0;

             for (i = 0; i < tp_dado.Items.Count; i++)
             {
                 if (tp_dado.Items[i].Equals(new Utils.TDataCombo("IMAGEM", "I")))
                 {
                     break;
                 }
             }



             if (tc_Tipo_dado.SelectedTab.Equals(tpImagem))
             {
                 tp_dado.SelectedIndex=i;
             }
             else
                 tp_dado.SelectedIndex=posicao_anterior;


             if (tp_dado.SelectedIndex != -1)
             habilitaValores(
                tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                tp_dado.SelectedValue.ToString().Trim().Equals("B"),
                tp_dado.SelectedValue.ToString().Trim().Equals("I")
            );

            bsParamGer.ResetCurrentItem();


         }

        private void BS_IMAGEM_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
         {
             if (e.ClickedItem.Name == "toolStripButton14")
             {
                 //capturar imagem da web cam
                 capturarImagem();
             }
             else if (e.ClickedItem.Name == "toolStripButton15") {
                 //buscar a imagem
                 localizarimagem();
             }

         }
        
        private void capturarImagem()
        {
            if (camera != null)
            {
                try
                {
                    System.IO.MemoryStream st = new System.IO.MemoryStream(camera.GrabFrame());


                    System.Drawing.Image acc_img = System.Drawing.Image.FromStream(st);

                    pictureBox6.Image = acc_img;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;


                    (bsParamGer.Current as TRegistro_ParamGer).Img = Convercao_imagem.imageToByteArray(acc_img);
                    


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private void localizarimagem()
        {
            if ((bsParamGer.Current != null) && ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit)))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "IMAGENS|*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(ofd.FileName))
                    {




                        System.Drawing.Image acc_img = Image.FromFile(ofd.FileName);


                        pictureBox6.Image = acc_img;
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;


                        (bsParamGer.Current as TRegistro_ParamGer).Img = Convercao_imagem.imageToByteArray(acc_img);

                    }
            }
        }

        private void bsParamGer_CurrentChanged(object sender, EventArgs e)
        {
            try{
                if ((bsParamGer.Current as TRegistro_ParamGer).Tp_dado.Equals("I"))
                {
                    pictureBox6.Image = (bsParamGer.Current as TRegistro_ParamGer).Imagem;
                    tc_Tipo_dado.SelectedIndex = 1;
                }
                else
                {
                    pictureBox6.Image = null;
                    tc_Tipo_dado.SelectedIndex = 0;
                }
            }
            catch(Exception erro){

            }
        }
      
    }
}
