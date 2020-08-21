using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Documents;
using System.IO;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Proc_Commoditties
{
    public partial class TFListaAniversariante : Form
    {
        public CamadaDados.Financeiro.Cadastros.TList_Aniversariante lAniversariante
        { get; set; }

        public TFListaAniversariante()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("TODOS", ""));
            cbx.Add(new Utils.TDataCombo("ANIVERSÁRIO", "0"));
            var b = CamadaNegocio.Financeiro.Cadastros.TCN_TpData.Buscar(string.Empty, string.Empty, null);
            b.ForEach(p => cbx.Add(new Utils.TDataCombo(p.Ds_tpData, p.Id_TpDataStr)));
            cbxTpData.DataSource = cbx;
            cbxTpData.ValueMember = "Value";
            cbxTpData.DisplayMember = "Display";
        }

        private void afterBusca()
        {
            decimal qtd_dias = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("DIAS_ANIVERSARIO_CLIENTE", null);
            if (qtd_dias.Equals(decimal.Zero))
                qtd_dias = 30;
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            //Cliente
            if (!string.IsNullOrEmpty(NM_Clifor_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NM_Clifor_Busca.Text.Trim() + "'";
            }
            //TP.Data
            if (!(cbxTpData.SelectedValue.Equals("")))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cbxTpData.SelectedValue + "'";
            }
            //St.Enviado
            if (st_enviados.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_enviado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }

           
            bsAniversariante.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_Aniversariante().Select(filtro, qtd_dias.ToString());
        }

        private void TFListaAniversariante_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsAniversariante.DataSource = lAniversariante;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsAniversariante.Count > 0)
            {
                (bsAniversariante.List  as CamadaDados.Financeiro.Cadastros.TList_Aniversariante).ForEach(p => p.St_enviaremail = cbTodos.Checked);
                bsAniversariante.ResetBindings(true);
            }
        }

        private void gAniversariante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsAniversariante.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Aniversariante).St_enviaremail =
                         !(bsAniversariante.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Aniversariante).St_enviaremail;
                bsAniversariante.ResetCurrentItem();
            }
        }

        private void bb_gerararquivo_Click(object sender, EventArgs e)
        {
            if (bsAniversariante.Count > 0)
                if ((bsAniversariante.List as CamadaDados.Financeiro.Cadastros.TList_Aniversariante).Exists(p => p.St_enviaremail))
                {
                    this.MsgEmail();
                    this.Close();
                }
                    
        }

        private void MsgEmail()
        {
            using (FormRelPadrao.TFMsgEmail fMsg = new FormRelPadrao.TFMsgEmail())
            {
                List<string> dest = new List<string>();
                (bsAniversariante.DataSource as CamadaDados.Financeiro.Cadastros.TList_Aniversariante).FindAll(p => p.St_enviaremail).ForEach(p => dest.Add(p.Email));
                dest.ForEach(p => fMsg.pDs_destinatario += p + ";");
                if (fMsg.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fMsg.Mensagem))
                        try
                        {
                            StringBuilder msgCorpoEmail = new StringBuilder();
                            //// Define o corpo do E-mail --------------------------------------------------------------------------------
                            //// Insere a imagem superior centralizada ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
                            //msgCorpoEmail.Append("<table style=\"width: 0%\" border=\"0\">");
                            //msgCorpoEmail.Append("<tr>");
                            //msgCorpoEmail.Append("<td align=\"bottom\">");
                            //msgCorpoEmail.Append("<img src=\"http://www.tecnopackembalagem.com.br/imagens/produtos/-faixa-feliz-aniversario-em-eva-40-x-7-cm-unidade-1407173714_52373_g.jpg\" />");
                            //msgCorpoEmail.Append("</td>");
                            //msgCorpoEmail.Append("</tr>");
                            //msgCorpoEmail.Append("</table>");

                            //// Insere uma mensagem padrão ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
                            //msgCorpoEmail.Append("<br />");

                            //msgCorpoEmail.Append("<br />");
                            //msgCorpoEmail.Append("<br />");

                            //// Insere a mensagem original ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
                            //msgCorpoEmail.Append(Proc_Commoditties.Converter.ConvertRtfToHtml(fMsg.Mensagem));
                            FormRelPadrao.Email email = new FormRelPadrao.Email();
                            email.Titulo = fMsg.pTitulo;
                            string[] end = fMsg.pDs_destinatario.Split(';');
                            foreach (string e in end)
                                email.Destinatario.Add(e);
                            email.Mensagem = Proc_Commoditties.Converter.ConvertRtfToHtml(fMsg.Mensagem);
                            //email.Mensagem = msgCorpoEmail.ToString();
                            email.St_html = true;
                            email.Id_TpData = (bsAniversariante.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Aniversariante).Id_TpData;
                            email.EnviarEmail();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
                
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.nm_clifor|=|'" + NM_Clifor_Busca.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { NM_Clifor_Busca }, new TCD_CadClifor());
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { NM_Clifor_Busca }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFListaAniversariante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        } 
   }
}
