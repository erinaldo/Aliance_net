using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace FormRelPadrao
{
    public partial class TFMsgEmail : Form
    {
        public string pDs_destinatario
        { get; set; }
        public string pTitulo
        { get; set; }
        public string Mensagem
        { get; set; }
        public List<string> lAnexos
        { get; set; }
        private bool St_bold = false;
        private bool St_italic = false;
        private bool St_underline = false;
        private FontStyle fonte;
        private Font currentFont;
        private ColorDialog cor = new ColorDialog();

        public TFMsgEmail()
        {
            InitializeComponent();
            lAnexos = new List<string>();
        }

        private void FontText()
        {
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            currentFont = ds_mensagem.SelectionFont != null ?
                         ds_mensagem.SelectionFont : new Font(cbxFonteFamily.SelectedText, tamanho, fonte, GraphicsUnit.Point, ((byte)(0))); ;
            fonte = ((FontStyle)(St_bold.Equals(true) && St_underline.Equals(false) && St_italic.Equals(false) ? (FontStyle.Bold) :
                                                  St_italic.Equals(true) && St_bold.Equals(false) && St_underline.Equals(false) ? (FontStyle.Italic) :
                                                  St_underline.Equals(true) && St_bold.Equals(false) && St_italic.Equals(false) ? (FontStyle.Underline) :

                                                  St_bold.Equals(true) && St_italic.Equals(true) && St_underline.Equals(false) ?
                                                  (FontStyle.Bold) | (FontStyle.Italic) :
                                                  St_bold.Equals(true) && St_underline.Equals(true) && St_italic.Equals(false) ?
                                                  (FontStyle.Bold) | (FontStyle.Underline) :
                                                  St_italic.Equals(true) && St_underline.Equals(true) && St_bold.Equals(false) ?
                                                  (FontStyle.Italic) | (FontStyle.Underline) :

                                                  St_bold.Equals(true) && St_italic.Equals(true) &&
                                                  St_underline.Equals(true) ?
                                                  (FontStyle.Bold) | (FontStyle.Italic) | (FontStyle.Underline) :
                                                  (FontStyle.Regular)));
            ds_mensagem.SelectionColor = cor.Color;
            ds_mensagem.SelectionFont = new Font(currentFont.FontFamily, tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
        }

        private void TFMsgEmail_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            ds_destinatario.CharacterCasing = CharacterCasing.Normal;
            ds_assunto.CharacterCasing = CharacterCasing.Normal;
            ds_destinatario.Text = pDs_destinatario;
            cbxTamanho.SelectedIndex = 0;
            //Preencher Fontes
            for (int i = 0; FontFamily.Families.Count() > i; i++)
                cbxFonteFamily.Items.Add(FontFamily.Families[i].Name);
            cbxFonteFamily.SelectedIndex = 6;
            currentFont = ds_mensagem.SelectionFont;
            ds_mensagem.SelectionFont = new Font(cbxFonteFamily.SelectedText, currentFont.Size, fonte, GraphicsUnit.Point, ((byte)(0)));
            if (lAnexos.Count > 0)
                lAnexos.ForEach(p =>
                    lbAnexos.Items.Add(p.Substring(p.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1, p.Length - (p.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1))));
        }

        private void bb_BuscarEndEmail_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Contato|Nome|250;" +
                              "a.Email|Email|250";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_BuscarEmail(), string.Empty);
            if (linha != null)
                ds_destinatario.Text += (string.IsNullOrEmpty(ds_destinatario.Text) ? string.Empty : ";") + linha["email"].ToString();
        }

        private void bb_negrito_Click(object sender, EventArgs e)
        {
            //Negrito
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            ds_mensagem.SelectionFont = new Font(cbxFonteFamily.SelectedText, tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
            if (St_bold)
                St_bold = false;
            else
                St_bold = true;
            if (ds_mensagem.SelectionFont.Bold.Equals(false))
                bb_negrito.BackColor = Color.SkyBlue;
            else
                bb_negrito.BackColor = Color.Transparent;
            FontText();
        }

        private void bb_italico_Click(object sender, EventArgs e)
        {
            //Italico
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            ds_mensagem.SelectionFont = new Font(cbxFonteFamily.SelectedText, tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
            if (St_italic)
                St_italic = false;
            else
                St_italic = true;
            if (ds_mensagem.SelectionFont.Italic.Equals(false))
                bb_italico.BackColor = Color.SkyBlue;
            else
                bb_italico.BackColor = Color.Transparent;
            FontText();           
        }

        private void bb_sublinhado_Click(object sender, EventArgs e)
        {
            //Sublinhado
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            ds_mensagem.SelectionFont = new Font(cbxFonteFamily.SelectedText, tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
            if (St_underline)
                St_underline = false;
            else
                St_underline = true;
            if (ds_mensagem.SelectionFont.Underline.Equals(false))
                bb_sublinhado.BackColor = Color.SkyBlue;
            else
                bb_sublinhado.BackColor = Color.Transparent;
            FontText();
        }

        private void bb_enviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ds_destinatario.Text))
            {
                MessageBox.Show("Obrigatório informar destinatario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_destinatario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ds_assunto.Text))
            {
                MessageBox.Show("Informe o Assunto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(ds_mensagem.Text))
            {
                Mensagem = ds_mensagem.Text;
                pTitulo = ds_assunto.Text;
                pDs_destinatario = ds_destinatario.Text.TrimEnd(';');
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Não é possivel enviar email sem Mensagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbxTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFont = ds_mensagem.SelectionFont;
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            ds_mensagem.SelectionFont = new Font(currentFont.FontFamily, tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
        }

        private void bb_cor_Click(object sender, EventArgs e)
        {
            cor.AnyColor = true;
            cor.AllowFullOpen = true;
            cor.SolidColorOnly = false;
            if (cor.ShowDialog() == DialogResult.OK)
            {
                ds_mensagem.SelectionColor = cor.Color;
                bb_cor.BackColor = cor.Color;
            }
        }

        private void cbxFonteFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFont = ds_mensagem.SelectionFont;
            float tamanho = float.Parse(cbxTamanho.SelectedItem.ToString());
            ds_mensagem.SelectionFont = new Font(cbxFonteFamily.SelectedItem.ToString(), tamanho, fonte, GraphicsUnit.Point, ((byte)(0)));
        }

        private void bbAnexos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fbdFile = new OpenFileDialog())
            {
                fbdFile.Multiselect = true;
                if (fbdFile.ShowDialog() == DialogResult.OK)
                    if (fbdFile.FileNames.Length > 0)
                        foreach (string f in fbdFile.FileNames)
                        {
                            lbAnexos.Items.Add(f.Substring(f.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1, f.Length - (f.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1)));
                            lAnexos.Add(f);
                        }
            }
        }

        private void lbAnexos_DoubleClick(object sender, EventArgs e)
        {
            if(lbAnexos.SelectedIndex >= 0)
                if (MessageBox.Show("Confirma exclusão do anexo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    lAnexos.RemoveAt(lbAnexos.SelectedIndex);
                    lbAnexos.Items.RemoveAt(lbAnexos.SelectedIndex);
                }
        }

        private void ds_mensagem_SelectionChanged(object sender, EventArgs e)
        {
            FontText();
        }
    }
}
