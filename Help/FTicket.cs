using System;
using System.Windows.Forms;
using CamadaDados.Help;
using System.Collections.Generic;

namespace Help
{
    public partial class TFTicket : Form
    {
        private List<Anexo> lAnexo;

        public string LoginCliente
        { get; set; }
        public string Id_cliente
        { get; set; }

        public TFTicket()
        {
            InitializeComponent();
            ds_assunto.CharacterCasing = CharacterCasing.Normal;
            ds_evolucao.CharacterCasing = CharacterCasing.Normal;
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_assunto.Text))
            {
                MessageBox.Show("Obrigatorio informar assunto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_assunto.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ds_evolucao.Text))
            {
                MessageBox.Show("Obrigatorio informar descrição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_evolucao.Focus();
                return;
            }
            try
            {
                if (lAnexo.Count > 0)
                    lAnexo.ForEach(p => (bsTicket.Current as Ticket).lAnexo.Add(p));
                MessageBox.Show(ServiceRest.DataService.NovoTicket(bsTicket.Current as Ticket), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Erro abrir ticket: " + ex.Message.Trim()); }
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFTicket_Load(object sender, EventArgs e)
        {
            bsTicket.AddNew();
            lAnexo = new List<Anexo>();
            (bsTicket.Current as Ticket).Logincliente = LoginCliente;
            (bsTicket.Current as Ticket).Id_cliente = decimal.Parse(Id_cliente);
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("BAIXA", "0"));
            cbx.Add(new Utils.TDataCombo("MÉDIA", "1"));
            cbx.Add(new Utils.TDataCombo("ALTA", "2"));
            cbPrioridade.DataSource = cbx;
            cbPrioridade.DisplayMember = "Display";
            cbPrioridade.ValueMember = "Value";
        }
                
        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFTicket_KeyDown(object sender, KeyEventArgs e)
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
                            MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            lAnexo.Clear();
            llkAnexo.Text = "Anexar Imagem";
        }
    }
}
