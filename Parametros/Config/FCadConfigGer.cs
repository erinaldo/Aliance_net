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
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace Parametros.Config
{
    public partial class TFCadConfigGer : FormCadPadrao.FFormCadPadrao
    {
        private int posicao_anterior;
        
        public TFCadConfigGer()
        {
            InitializeComponent();
            DTS = bsParamGer;
        }
        
        public override void formatZero()
        {
            pDados.set_FormatZero();
        }
        
        public override void afterBusca()
        {
            base.afterBusca();
            tc_Tipo_dado.Enabled = false;
            
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
                string retorno = TCN_CadParamGer.GravaParamGer((bsParamGer.Current as TRegistro_ParamGer), null);
                if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("TOPMAX_CONSULTA"))
                    Utils.Parametros.pubTopMax = Convert.ToInt16((bsParamGer.Current as TRegistro_ParamGer).Vl_numerico);
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("PATH_CONFIG"))
                    Utils.Parametros.pubPathConfig = (bsParamGer.Current as TRegistro_ParamGer).Vl_string.Trim();
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("ST_UTILIZAR_CORINGA_ESQ"))
                    Utils.Parametros.ST_UtilizarCoringaEsq = (bsParamGer.Current as TRegistro_ParamGer).VL_Booleano;
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("TMP_STATUS_TICKET_BI"))
                    Utils.Parametros.pubTmpStatusTicket = (bsParamGer.Current as TRegistro_ParamGer).Vl_numerico;
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("TMP_MSG_BI"))
                    Utils.Parametros.pubTmpMsgTicket = (bsParamGer.Current as TRegistro_ParamGer).Vl_numerico;
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("WS_SERVIDOR_BI"))
                    Utils.Parametros.WS_ServidorHelpDesk = (bsParamGer.Current as TRegistro_ParamGer).Vl_string;
                else if ((bsParamGer.Current as TRegistro_ParamGer).Ds_parametro.Trim().ToUpper().Equals("URL_UTILS"))
                    Utils.Parametros.URL_Utils = (bsParamGer.Current as TRegistro_ParamGer).Vl_string;
                return retorno;
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {


            string seleParametro = string.Empty;
            if (ds_parametro.SelectedValue != null)
                seleParametro = ds_parametro.SelectedValue.ToString();
            string seleTpDado = string.Empty;
            if (tp_dado.SelectedValue != null)
                seleTpDado = tp_dado.SelectedValue.ToString();

            TList_RegParamGer lista = TCN_CadParamGer.Busca(0, 
                                                            seleParametro, 
                                                            ds_finalidade.Text, 
                                                            seleTpDado, 
                                                            0, 
                                                            string.Empty,
                                                            null);
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
                tc_Tipo_dado.Enabled = true;
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
                    TCN_CadParamGer.DeletaParamGer((bsParamGer.Current as TRegistro_ParamGer), null);
                    bsParamGer.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void foco_nos_valores(bool vString, bool vNumerico, bool vData, bool vBooleano, bool vImagem)
        {
            if (vString)
            {
                vl_string.Focus();
            }
            else if (vNumerico)
            {
                vl_numerico.Focus();
            }
            else if (vData)
            {
                vl_data.Focus();
            }
            else if (vBooleano)
            {
                vl_bool.Focus();
            }
            else if (vImagem)
            {
                BS_IMAGEM.Focus();
                BS_IMAGEM.Items.Find("toolStripButton14", true)[0].Select();
                //BS_IMAGEM.Items.Find("toolStripButton14", true)[0].owner;
                //BS_IMAGEM.Items.Find()
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
                tp_dado.Focus();
            }
            else
            {
                tc_Tipo_dado.SelectedIndex = 0;
                tpDados.Show();
                tp_dado.Focus();
            }

        }

        private void TFCadConfigGer_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            vl_string.CharacterCasing = CharacterCasing.Normal;
            ArrayList CBox = new ArrayList();
            CBox.Add(new Utils.TDataCombo("STRING", "S"));
            CBox.Add(new Utils.TDataCombo("NUMERICO", "N"));
            CBox.Add(new Utils.TDataCombo("DATA", "D"));
            CBox.Add(new Utils.TDataCombo("BOOLEANO", "B"));
            CBox.Add(new Utils.TDataCombo("IMAGEM", "I"));
            CBox.Add(new Utils.TDataCombo("SENHA", "H"));

            tp_dado.DataSource = CBox;
            tp_dado.DisplayMember = "Display";
            tp_dado.ValueMember = "Value";
            tp_dado.SelectedIndex = -1;

            ArrayList CBox1 = new ArrayList();
            //Por Empresa TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("MOEDA PADRÃO", "CD_MOEDA_PADRAO"));
            //TP.Dado IMAGEM
            CBox1.Add(new Utils.TDataCombo("IMAGEM DO RELATÓRIO", "IMAGEM_RELATORIO"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("RODAPÉ DO RELATÓRIO", "RODAPE_RELATORIO"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("ESTILO DE RELATÓRIO", "ESTILO_RELATORIO"));
            //Por Empresa TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("SITUAÇÃO TRIBUTARIA ISENTA ICMS", "CD_SITTRIB_ISENTA_ICMS"));
            //Por Empresa TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("SITUAÇÃO TRIBUTARIA ISENTA PIS", "CD_SITTRIB_ISENTA_PIS"));
            //Por Empresa TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("SITUAÇÃO TRIBUTARIA ISENTA COFINS", "CD_SITTRIB_ISENTA_COFINS"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("TOP MAX DE CONSULTAS", "TOPMAX_CONSULTA"));
            //Por Terminal TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("UTILIZAR OUTLOOK ENVIAR EMAIL", "ST_ENVIAR_EMAIL_OUTLOOK"));
            //Por Terminal TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("SERVIDOR SMTP", "SERVIDOR_SMTP"));
            //Por Terminal TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("PORTA SMTP", "PORTA_SMTP"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("CONEXAO SSL SMTP", "CONEXAO_SSL_SMTP"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("EMAIL PADRAO PARA AUTENTICAR SERVIDOR SMTP", "EMAIL_PADRAO"));
            //TP.Dado SENHA
            CBox1.Add(new Utils.TDataCombo("SENHA DO EMAIL PADRAO", "SENHA_EMAIL"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("ENVIAR EMAIL COM COPIA", "ST_COPIA_EMAIL"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("MESANGEM PADRAO EMAIL", "MENSAGEM_PADRAO_EMAIL"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("PATH ANEXO EMAIL", "PATH_ANEXO_EMAIL"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("PATH CONFIGURAÇÕES", "PATH_CONFIG"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("URL UTILS", "URL_UTILS"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("OBRIGATORIO INFORMAR TRANSPORTADORA PEDIDO VENDA", "TRANSP_PEDIDOVENDA"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("GERAR APONTAMENTO DE PRODUCAO NA VENDA DE SEMENTES", "APONT_PRODUCAO_SEMENTE"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("IMPRIMIR LAUDO DE DESCARGA", "IMP_LAUDO_DESCARGA"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("APLICAR PESAGEM AUTOMATICAMENTE NO FECHAMENTO DO TICKET", "APLIC_PSAUTO"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("CONTROLAR GMO", "ST_CONTROLAR_GMO"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("INDICE GMO DECLARADO", "PC_GMO_DECLARADO"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("INDICE GMO TESTADO", "PC_GMO_TESTADO"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("VALOR CHEQUE MAIOR QUE VALOR FINANCEIRO A RECEBER", "VL_CH_MAIORVLFINRECEBER"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("VALOR CARTAO MAIOR QUE VALOR FINANCEIRO A RECEBER", "VL_CD_MAIORVLFINRECEBER"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("IDENTIFICAR CLIENTE NO CREDITO", "ST_IDENT_CLIFOR_CRED"));
            //PARAMETRO INEXISTENTE
            CBox1.Add(new Utils.TDataCombo("DIAS VALIDADE DO CADASTRO CLIENTE", "DIAS_RENOVACAO_CADASTRO_CLIFOR"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("EMPRESA UTILIZA CENTRO DE RESULTADO", "CRESULTADO_EMPRESA"));
            //Por Empresa TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("QUANTIDADE COPIAS RECIBO ECF", "QTD_VIA_REC_ECF"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("QUANTIDADE COPIAS DANFE", "QTD_VIA_DANFE"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("PERMITIR CLIENTE MULTIPLOS CONVENIOS", "ST_CLIFOR_MULTIPLOS_CONV"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("CADASTRO CLIENTE/FORNECEDOR RESUMIDO", "ST_CADCLFOR_RESUMIDO"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("BLOQUEAR CREDITO PARA CADASTRO DE CLIENTES", "ST_BLOQ_CLIENTE"));
            //Por Empresa TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("PERMITIR FINANCEIRO SOMENTE CLIFOR CNPJ/CPF VALIDO", "ST_FIN_CLIFOR_VALIDO"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("UTILIZAR CORINGA <%> A ESQUERDA DAS BUSCAS", "ST_UTILIZAR_CORINGA_ESQ"));
            //TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("URL API ALIANCE", "WS_SERVIDOR_BI"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("TEMPO BUSCA STATUS TICKET BI", "TMP_STATUS_TICKET_BI"));
            //TP.Dado NUMÉRICO
            CBox1.Add(new Utils.TDataCombo("TEMPO MENSAGEM TICKET BI", "TMP_MSG_BI"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("CONTROLAR ADIANTAMENTO POR VIAGEM", "ST_ADTO_VIAGEM"));
            //TP.Dado BOOLEANO
            CBox1.Add(new Utils.TDataCombo("TRUNCAR VALOR SUBTOTAL EM DUAS CASAS DECIMAIS", "ST_TRUNCAR_SUBTOTAL"));
            //Por Empresa TP.Dado STRING
            CBox1.Add(new Utils.TDataCombo("CONTA CONTABIL ANALITICA INVENTARIO ESTOQUE", "CD_CONTA_ESTOQUE"));
            //TP. Dado NUMERICO
            CBox1.Add(new Utils.TDataCombo("INDICE CUSTO FORMAÇÃO PREÇO VENDA", "PC_INDICE_VENDA"));
            //TP. Dado NUMERICO
            CBox1.Add(new Utils.TDataCombo("DIAS AVISO ANIVERSARIO CLIENTE", "DIAS_ANIVERSARIO_CLIENTE"));
            //TP. Dado STRING
            CBox1.Add(new Utils.TDataCombo("URL CONSULTA NFE CHAVE ACESSO", "URL_CHAVENFE"));
            //IMPRIMIR DANFE NFC-E DETALHADA - BOOLEANO
            CBox1.Add(new Utils.TDataCombo("IMPRIMIR DANFE NFC-E DETALHADA", "ST_IMP_DANFE_NFCE_DETALHADA"));
            //Por Empresa BOOLEANO
            CBox1.Add(new Utils.TDataCombo("UTILIZAR IMPRESSÃO CARNE NA DUPLICATA", "ST_CARNE"));
            //Por Empresa
            CBox1.Add(new Utils.TDataCombo("UNIDADE PADRÃO BALANÇA", "UND_BALANCA"));
            //Por Empresa
            CBox1.Add(new Utils.TDataCombo("PERMITIR PROCESSAR RETIRADA AUTOMATICAMENTE", "PROC_RETIRADA"));
            //Por Empresa BOOLEANO
            CBox1.Add(new Utils.TDataCombo("OBRIGAR CUSTO UNITARIO NO ORÇAMENTO", "ST_OBRIGAR_CUSTO_UNIT_ORC"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("MANIFESTAR NF-E AUTOMATICO","ST_MANIFESTO_AUTO"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("AGRUPAR ITENS IGUAIS NF DIRETA", "AGRUPAR_ITENS_IGUAIS_NF_DIRETA"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("GRAVAR ESTOQUE NEGATIVO", "GRAVAR_ESTOQUE_NEGATIVO"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("GERAR SERIE APONTAMENTO PRODUÇÃO", "GERAR_SERIE_APONTAMENTO"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("GERAR COMISSÃO POR METAS", "GERAR_COMISSAO_METAS"));
            //Por Booleano
            CBox1.Add(new Utils.TDataCombo("CALCULAR CODBARRA AUTOMATICO", "CALC_CODBARRA_AUTOMATICO"));
            // booleao por empresa 
            CBox1.Add(new Utils.TDataCombo("PERMITIR DUPLICAR CNPJ","DUP_CNPJ"));
            //Por Empresa TP.Dado String
            CBox1.Add(new Utils.TDataCombo("TRANSFERIR ESTOQUE AUTOMATICAMENTE ENTRE EMPRESAS", "TRANS_ESTOQUE_EMP"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("SEMPRE CALCULAR PARCELAS DA DUPLICATA NA NF", "CALC_PARCELASDUP_NF"));
            //Por Empresa Booleano
            CBox1.Add(new Utils.TDataCombo("PERMITIR AGRUPAR FINANCEIRO CLIFOR", "ST_PERMITIRAGRUPFINCLIFORDIF"));

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
            using (WebCamLibrary.TFCapturaVideo fCap = new WebCamLibrary.TFCapturaVideo())
            {
                if (fCap.ShowDialog() == DialogResult.OK)
                {
                    pictureBox6.Image = fCap.Img;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    (bsParamGer.Current as TRegistro_ParamGer).Img = Convercao_imagem.imageToByteArray(fCap.Img);
                }
            }
        }

        private void localizarimagem()
        {
            try
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
            catch { }
        }

        private void bsParamGer_CurrentChanged(object sender, EventArgs e)
        {
            try{
                if ((bsParamGer.Current as TRegistro_ParamGer).Tp_dado.Equals("I"))
                {
                    pictureBox6.Image = (bsParamGer.Current as TRegistro_ParamGer).Imagem;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    tc_Tipo_dado.SelectedIndex = 1;
                }
                else
                {
                    pictureBox6.Image = null;
                    tc_Tipo_dado.SelectedIndex = 0;
                }
            }
            catch {

            }
        }

        private void tp_dado_Leave(object sender, EventArgs e)
        {

            try
            {
                foco_nos_valores
               (tp_dado.SelectedValue.ToString().Trim().Equals("S"),
                       tp_dado.SelectedValue.ToString().Trim().Equals("N"),
                       tp_dado.SelectedValue.ToString().Trim().Equals("D"),
                       tp_dado.SelectedValue.ToString().Trim().Equals("B"),
                       tp_dado.SelectedValue.ToString().Trim().Equals("I")
                       );
            }
            catch { }
        }      
    }
}
