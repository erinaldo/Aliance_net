using System;
using System.Windows.Forms;
using CamadaDados.Help;
using System.Collections.Generic;

namespace Help
{
    public partial class TFEvoluirTicket : Form
    {
        public List<Anexo> lAnexo { get; set; }
        public string Ds_historico { get { return ds_historico.Text; } }

        public TFEvoluirTicket()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_historico.Text))
            {
                MessageBox.Show("Obrigatorio informar histórico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_historico.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFEvoluirTicket_Load(object sender, EventArgs e)
        {
            ds_historico.CharacterCasing = CharacterCasing.Normal;
            lAnexo = new List<Anexo>();
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFEvoluirTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.Control && e.KeyCode.Equals(Keys.V))
            {
                if (Clipboard.ContainsImage())
                {
                    using (TFAnexosHelpDesk fAnexo = new TFAnexosHelpDesk())
                    {
                        fAnexo.st_print = true;
                        fAnexo.Img_anexo = Clipboard.GetImage();
                        if (fAnexo.ShowDialog() == DialogResult.OK)
                        {
                            Anexo anexo = new Anexo();
                            anexo.Ds_anexo = fAnexo.pDs_anexo;
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            fAnexo.Img_anexo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            anexo.Imagem = ms.ToArray();
                            anexo.Tp_ext = string.Empty;
                            lAnexo.Add(anexo);
                            llkAnexo.Text = "Anexar Imagem (" + lAnexo.Count.ToString() + ")";
                        }
                    }
                }
            }
        }

        private void llkAnexo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(file.FileName))
                    {
                        Anexo anexo = new Anexo();
                        anexo.Imagem = System.IO.File.ReadAllBytes(file.FileName);
                        anexo.Tp_ext = System.IO.Path.GetExtension(file.FileName);
                        Utils.InputBox ibp = new Utils.InputBox();
                        ibp.Text = "Descrição Anexo";
                        string ds = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(ds))
                        {
                            MessageBox.Show("Obrigatório informar Descrição da Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        anexo.Ds_anexo = ds;
                        lAnexo.Add(anexo);
                        llkAnexo.Text = "Anexar Imagem (" + lAnexo.Count.ToString() + ")";
                    }
            }
        }

        private void lklLimpar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lAnexo.Count > 0)
            {
                lAnexo.Clear();
                llkAnexo.Text = "Anexar Imagem";
            }
        }
    }
}
