using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace FormRelPadrao
{
    public partial class TFGerenciadorImpressao : Form
    {
        public bool St_enabled_enviaremail
        { get; set; }
        public bool St_danfe
        { get; set; }
        public bool St_danfenfce
        { get; set; }
        public bool St_danfenfcedetalhada
        { get { return st_danfenfcedetalhada.Checked; } }
        public bool St_viaestabelecimento
        { get { return st_viaestabelecimento.Checked; } }
        public bool St_receberXmlNfe
        { get; set; }
        public string pMensagem
        { get; set; }
        public bool pSt_enviaremail
        { get; set; }
        public bool pSt_visualizar
        { get; set; }
        public bool pSt_imprimir
        { get; set; }
        public bool pSt_exportPdf
        { get; set; }
        public string Path_exportPdf
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pCd_representante
        { get; set; }
        public string pDs_mensagem
        { get; set; }
        public List<string> pDestinatarios
        { get; set; }

        public TFGerenciadorImpressao()
        {
            InitializeComponent();
            pSt_enviaremail = false;
            pSt_visualizar = false;
            pSt_imprimir = false;
            pSt_exportPdf = false;
            Path_exportPdf = string.Empty;
            ds_mensagem.CharacterCasing = CharacterCasing.Normal;
            ds_email.CharacterCasing = CharacterCasing.Normal;
        }

        public void BuscarContatos()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lContatos =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                   cd_clifor.Text,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   string.Empty,
                                                                                   0,
                                                                                   null);
                lContatos.ForEach(p =>
                    {
                        if (!string.IsNullOrEmpty(p.Email))
                            clbContatos.Items.Add(p.Email.Trim(), (St_danfe && (p.St_receberdanfebool || p.St_receberxmlnfebool)) ? true : false);
                    });
                //Verificar se existe contato para enviar XML
                if (lContatos.Exists(p => p.St_receberxmlnfebool.Equals(true)))
                    St_receberXmlNfe = true;
            }
        }

        private void TFGerenciadorImpressao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            if (St_danfenfce)
            {
                Height = 349;
                clbContatos.Height = 109;
                BB_Visualizar.Location = new Point(9, 208);
                BB_Imprimir.Location = new Point(202, 208);
                bbExportarPDF.Location = new Point(395, 208);
                bb_enviaremail.Location = new Point(576, 208);
                st_danfenfcedetalhada.Visible = true;
                st_danfenfcedetalhada.Checked = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null);
                st_viaestabelecimento.Visible = true;
            }
            else
            {
                Height = 295;
                clbContatos.Height = 64;
                BB_Visualizar.Location = new Point(9, 155);
                BB_Imprimir.Location = new Point(202, 155);
                bbExportarPDF.Location = new Point(395, 155);
                bb_enviaremail.Location = new Point(576, 155);
                st_danfenfcedetalhada.Visible = St_danfenfce;
                st_viaestabelecimento.Visible = St_danfenfce;
            }
            
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            lblMensagem.Text = pMensagem.Trim();
            ds_mensagem.Text = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("MENSAGEM_PADRAO_EMAIL", null);
            cd_clifor.Text = pCd_clifor;
            pDestinatarios = new List<string>();
            if (!string.IsNullOrEmpty(pCd_representante))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + pCd_representante.Trim() + "'"
                                    }
                                }, "a.email");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    clbContatos.Items.Add(obj.ToString());
            }
            cd_clifor_Leave(this, new EventArgs());
        }

        private void BB_Visualizar_Click(object sender, EventArgs e)
        {
            pSt_visualizar = true;
            DialogResult = DialogResult.OK;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            pSt_imprimir = true;
            DialogResult = DialogResult.OK;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                            , new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
            BuscarContatos();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarContatos();
        }

        private void TFGerenciadorImpressao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((clbContatos.CheckedItems.Count > 0) ||
                (!string.IsNullOrEmpty(ds_email.Text)))
            {
                if (!string.IsNullOrEmpty(ds_email.Text))
                    if (ds_email.Text.Contains(';'))
                    {
                        string[] aux = ds_email.Text.Split(new char[] { ';' });
                        foreach (string a in aux)
                            if (!string.IsNullOrEmpty(a))
                                pDestinatarios.Add(a);
                    }
                    else
                        pDestinatarios.Add(ds_email.Text.Trim());
                for (int i = 0; i < clbContatos.CheckedItems.Count; i++)
                    pDestinatarios.Add(clbContatos.CheckedItems[i].ToString().Trim());
                pDs_mensagem = ds_mensagem.Text.Trim();
                pSt_enviaremail = true;
            }
        }

        private void bb_enviaremail_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFGerenciadorImpressao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                BB_Visualizar_Click(this, null);
            else if (e.KeyData == Keys.F6)
                BB_Imprimir_Click(this, null);
        }

        private void bbExportarPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog salvar = new SaveFileDialog())
            {
                salvar.Filter = "PDF|*.pdf";
                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    pSt_exportPdf = true;
                    Path_exportPdf = salvar.FileName;
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
