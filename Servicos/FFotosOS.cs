using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFFotosOS : Form
    {
        private CamadaDados.Servicos.Cadastros.TRegistro_Imagens rfoto;
        public CamadaDados.Servicos.Cadastros.TRegistro_Imagens rFoto
        {
            get { return bsFotos.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens; }
            set { rfoto = value; }
        }

        public TFFotosOS()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_imagem.Text))
            {
                MessageBox.Show("Obrigatorio informar descrição para foto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_imagem.Focus();
                return;
            }
            if (pImagem.Image == null)
            {
                MessageBox.Show("Obrigatorio informar foto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void LocalizarFoto()
        {
            try
            {
                if (bsFotos.Current != null)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsFotos.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem = Image.FromFile(ofd.FileName);
                            bsFotos.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_localizarfoto_Click(object sender, EventArgs e)
        {
            this.LocalizarFoto();
        }

        private void TFFotosOS_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rfoto != null)
                bsFotos.DataSource = new CamadaDados.Servicos.Cadastros.TList_Imagens() { rfoto };
            else
                bsFotos.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFFotosOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F7))
                this.LocalizarFoto();
        }
    }
}
