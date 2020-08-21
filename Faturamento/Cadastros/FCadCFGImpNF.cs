using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGImpNF : FormCadPadrao.FFormCadPadrao
    {
        private string path_principal = string.Empty;

        public TFCadCFGImpNF()
        {
            InitializeComponent();
            this.DTS = bsCfgImpNf;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (QT_ItensNota.Focused)
                    (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Qt_itensnota = QT_ItensNota.Value;
                if (Tam_DadosAdic.Focused)
                    (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Tam_dadosadic = Tam_DadosAdic.Value;

                bb_Captura.Enabled = false;
                bb_Localizar.Enabled = false;
                BS_IMAGEM.Enabled = false;
                return CamadaNegocio.Faturamento.Cadastros.TCN_CFGImpNF.GravarCFGImpNF(
                    bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CFGImpNF lista = 
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGImpNF.Buscar(nr_serie.Text, cd_modelo.Text, cd_empresa.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgImpNf.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgImpNf.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCfgImpNf.AddNew();
                base.afterNovo();
                bb_Captura.Enabled = true;
                bb_Localizar.Enabled = true;
                BS_IMAGEM.Enabled = true;
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            bb_Captura.Enabled = false;
            bb_Localizar.Enabled = false;
            BS_IMAGEM.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgImpNf.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa_busca.Enabled = false;
            bb_serie_busca.Enabled = false;
            bb_modelo.Enabled = false;
            bb_Captura.Enabled = true;
            bb_Localizar.Enabled = true;
            BS_IMAGEM.Enabled = true;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                QT_ItensNota.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGImpNF.ExcluirCFGImpNF(
                        bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF, null);
                    bsCfgImpNf.RemoveCurrent();
                    pDados.LimparRegistro();
                    bb_Captura.Enabled = false;
                    bb_Localizar.Enabled = false;
                    BS_IMAGEM.Enabled = true;
                    afterBusca();
                }
            }
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_serie_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "b.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80;" +
                              "b.DS_Modelo|Descrição Modelo|350;" +
                              "a.tp_docto|TP. Docto|80;" +
                              "d.ds_tpdocto|Tipo Documento|150";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serie, ds_serienf },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "'";
            if (string.IsNullOrEmpty(cd_modelo.Text))
                vParam += ";a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam
                , new Componentes.EditDefault[] { nr_serie, ds_serienf }, new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_Localizar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsCfgImpNf.Current != null) && ((vTP_Modo == Utils.TTpModo.tm_Insert) || (vTP_Modo == Utils.TTpModo.tm_Edit)))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";

                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            System.Drawing.Image acc_img = Image.FromFile(ofd.FileName);

                            pictureBox6.Image = acc_img;
                            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                            (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Imagem = acc_img;
                            bsCfgImpNf.ResetCurrentItem();
                        }
                }
            }
            catch { }
        }

        private void bb_Captura_Click(object sender, EventArgs e)
        {
            //if (camera != null)
            //{
            //    try
            //    {
            //        System.IO.MemoryStream st = new System.IO.MemoryStream(camera.GrabFrame());

            //        System.Drawing.Image acc_img = System.Drawing.Image.FromStream(st);

            //        pictureBox6.Image = acc_img;
            //        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

            //        (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Img = Utils.Convercao_imagem.imageToByteArray(acc_img);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }

        private void bb_ModeloNF_Click(object sender, EventArgs e)
        {
            FormRelPadrao.LayoutNotaFiscal Relatorio = new FormRelPadrao.LayoutNotaFiscal();
            (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Modelorst = Relatorio.Gera_ModeloNF(bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF);
            bsCfgImpNf.ResetCurrentItem();
        }

        private void bsCfgImpNf_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if ((bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Img.ToString().Trim().Equals(string.Empty))
                {
                    pictureBox6.Image = (bsCfgImpNf.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF).Imagem;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    tc_Tipo_dado.SelectedIndex = 1;
                }
                else
                {
                    pictureBox6.Image = null;
                    tc_Tipo_dado.SelectedIndex = 0;
                }
            }
            catch
            { }
        }

        private void FCadCFGImpNF_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
        }

        private void TFCadCFGImpNF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|150;" +
                              "a.cd_modelo|Codigo|50";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(nr_serie.Text))
                vParam = "|exists|(select 1 from tb_fat_serienf x " +
                         "          where x.cd_modelo = a.cd_modelo " +
                         "          and x.nr_serie = '" + nr_serie.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), vParam);
        }

        private void cd_modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            if(!string.IsNullOrEmpty(nr_serie.Text))
                vParam += ";|exists|(select 1 from tb_fat_serienf x " +
                          "          where x.cd_modelo = a.cd_modelo " +
                          "          and x.nr_serie = '" + nr_serie.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF());
        }
    }
}
