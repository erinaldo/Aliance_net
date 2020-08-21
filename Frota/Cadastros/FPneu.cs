using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Frota.Cadastros
{
    public partial class TFPneu : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_LanPneu rpneu;
        public CamadaDados.Frota.Cadastros.TRegistro_LanPneu rPneu
        {
            get
            {
                if (bsPneus.Count > 0)
                    return bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu;
                else
                    return null;
            }
            set
            { rpneu = value; }
        }
        public TFPneu()
        {
            InitializeComponent();
        }

        private void InserirFoto()
        {
            try
            {
                if (bsPneus.Current != null)
                {
                    Utils.InputBox ibp = new Utils.InputBox();
                    ibp.Text = "Descrição Imagem";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatório informar Descrição da imagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).lPneu.Add(new CamadaDados.Frota.Cadastros.TRegistro_FotosPneu()
                            {
                                Ds_observacao = ds,
                                Imagem = Image.FromFile(ofd.FileName)
                            });
                            bsPneus.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExcluirFoto()
        {
            if (bsPneus.Current != null)
            {
                if (bsFotoPneu.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar imagem para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Imagem selecionada: " + (bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu).Id_fotostr.Trim() + "-" +
                                                                (bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu).Ds_observacao.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        //Adicionar item na lista a ser excluido
                        (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).lPneuDel.Add(
                            bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu);
                        //Excluir item do grid
                        (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).lPneu.Remove(
                           bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu);
                        bsPneus.ResetCurrentItem();
                    }
                    catch { }
            }
        }

        private void ImageShow()
        {
            if (bsFotoPneu.Current != null)
            {
                if ((bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu).Imagem != null)
                {
                    //Criar Form
                    Form fImagem = new Form();
                    fImagem.Size = new Size(1040, 720);
                    fImagem.StartPosition = FormStartPosition.CenterScreen;
                    fImagem.ShowInTaskbar = false;
                    fImagem.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                    fImagem.MinimizeBox = false;
                    fImagem.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fImagem.Text = "Visualizador de IMAGENS -  Aliance.Net";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    //Criar PictureBox
                    PictureBox img = new PictureBox();
                    bindingNavigator1.Dock = DockStyle.Bottom;
                    bindingNavigator1.BindingSource = bsFotoPneu;
                    fImagem.Controls.Add(panel);
                    panel.Controls.Add(img);
                    panel.Controls.Add(bindingNavigator1);
                    img.BorderStyle = BorderStyle.FixedSingle;
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.DataBindings.Add(new Binding("Image", bsFotoPneu, "imagem", true, DataSourceUpdateMode.OnPropertyChanged));
                    fImagem.ShowDialog();
                }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFPneu_Load(object sender, EventArgs e)
        {
            pDadosPneu.set_FormatZero();
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rpneu != null)
            {
                bsPneus.DataSource = new CamadaDados.Frota.Cadastros.TList_LanPneu() { rpneu };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else
                bsPneus.AddNew();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }
        
        private void ts_btn_InserirFoto_Click(object sender, EventArgs e)
        {
            InserirFoto();
        }

        private void ts_btn_DeletarFoto_Click(object sender, EventArgs e)
        {
            ExcluirFoto();
        }

        private void TFPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirFoto();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirFoto();
        }

        private void ptbImagem_DoubleClick(object sender, EventArgs e)
        {
            ImageShow();
        }
    }
}
