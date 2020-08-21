using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proc_Commoditties
{
    public partial class TFCaptcha : Form
    {
        public string html
        { get; set; }

        public string chaveAcesso
        { get; set; }
        //private SHDocVw.InternetExplorer ie;
        private mshtml.HTMLDocument mDoc;
        public TFCaptcha()
        {
            InitializeComponent();

            //ie = new SHDocVw.InternetExplorer();
            mDoc = new mshtml.HTMLDocumentClass();
        }

        private void afterGrava()
        {
            /*if (texto.Text.Length != 6)
            {
                MessageBox.Show("Código da Imagem deve conter 6 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((mshtml.HTMLInputElement)((mshtml.HTMLDocument)ie.Document).all.item("ctl00$ContentPlaceHolder1$txtChaveAcessoCompleta", 0)).value =
                chaveAcesso;
            ((mshtml.HTMLInputElement)((mshtml.HTMLDocument)ie.Document).all.item("ctl00$ContentPlaceHolder1$txtCaptcha", 0)).value = texto.Text;
            ((mshtml.HTMLInputElement)((mshtml.HTMLDocument)ie.Document).all.item("ctl00$ContentPlaceHolder1$btnConsultar", 0)).click();
            while (ie.Busy)
                System.Threading.Thread.Sleep(500);
            mDoc = (mshtml.HTMLDocument)ie.Document;
            ie.Visible = false;
            html = mDoc.body.innerHTML;
            if (html.Contains("ContentPlaceHolder1_revCaptcha.errormessage"))
            {
                MessageBox.Show("Código da imagem inválido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TFCaptcha_Load(object sender, EventArgs e)
        {
            //this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //object mVal = System.Reflection.Missing.Value;
            //ie.Visible = false;
            //string url = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("URL_CHAVENFE", null);
            //if (string.IsNullOrEmpty(url))
            //{
            //    MessageBox.Show("Não existe URL configurado para realizar download XML.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.BeginInvoke(new MethodInvoker(Close));
            //    return;
            //}
            //try
            //{
            //    ie.Navigate(url, ref mVal, ref mVal, ref mVal, ref mVal);
            //    while (ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            //        System.Threading.Thread.Sleep(500);
            //    mDoc = (mshtml.HTMLDocument)ie.Document;
            //    string cap = ((mshtml.HTMLImg)((mshtml.HTMLDocument)ie.Document).images.item("ctl00_ContentPlaceHolder1_imgCaptcha", 0)).href;
            //    cap = cap.Substring(cap.IndexOf(',') + 1, cap.Length - cap.IndexOf(',') - 1);
            //    byte[] bt = Convert.FromBase64String(cap);
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    ms.Write(bt, 0, bt.Length);
            //    ptbImagem.Image = Image.FromStream(ms);
            //}
            //catch (Exception ex)
            //{ MessageBox.Show("Erro download XML: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
        }

        private void bb_enter_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
