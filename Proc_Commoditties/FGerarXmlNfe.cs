using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ionic.Utils.Zip;

namespace Proc_Commoditties
{
    public partial class TFGerarXmlNfe : Form
    {
        public bool St_nfce
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe
        { get; set; }

        public TFGerarXmlNfe()
        {
            InitializeComponent();
        }

        private void afterGerarArqXml()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_notafiscal.Text))
            {
                if (dt_inicial.Text.Trim().Equals(string.Empty) || dt_inicial.Text.Trim().Equals("/  /"))
                {
                    MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_inicial.Focus();
                    return;
                }
                if (dt_final.Text.Trim().Equals(string.Empty) || dt_final.Text.Trim().Equals("/  /"))
                {
                    MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_final.Focus();
                    return;
                }
            }
            string path = string.Empty;
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    path = fbdPath.SelectedPath.Trim();
                else return;
            }
            //Criar diretorio caso não exista
            if (!System.IO.Directory.Exists(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                System.IO.Directory.CreateDirectory(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
            else
                if (System.IO.Directory.GetFiles(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")).Length > 0)
                if (MessageBox.Show("Apagar arquivos existentes no diretório?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                    foreach (string s in System.IO.Directory.GetFiles(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy")))
                        System.IO.File.Delete(s);

            try
            {
                string msg = string.Empty;
                if (St_nfce)
                    msg = NFCe.GerarXML.TGerarXML.GerarXMLPeriodo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                                  cd_clifor.Text,
                                                                  dt_inicial.Text,
                                                                  dt_final.Text,
                                                                  cbEmpresa.SelectedValue.ToString(),
                                                                  nr_notafiscal.Text);
                else
                {
                    if (rCfgNfe == null)
                        cbEmpresa_SelectedIndexChanged(this, new EventArgs());
                    msg = srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                                        cd_clifor.Text,
                                                                        dt_inicial.Text,
                                                                        dt_final.Text,
                                                                        cbEmpresa.SelectedValue.ToString(),
                                                                        nr_notafiscal.Text,
                                                                        rCfgNfe);
                }
                if (st_compactar.Checked)
                {
                    ZipFile zip = new ZipFile(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                    foreach (System.IO.FileInfo file in dir.GetFiles())
                        if (file.Name.Substring(file.Name.LastIndexOf('.') + 1, 3).Trim().Equals("xml"))
                            zip.AddFile(file.DirectoryName + "\\" + file.Name, string.Empty);
                    zip.Save();
                }
                MessageBox.Show("Arquivos gerados com sucesso." + (!string.IsNullOrEmpty(msg) ? "\r\n" + "Alguns arquivos não puderão ser gerados por inconsistências.\r\n" + msg.Trim() : string.Empty), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (st_email.Checked)
                    using (FormRelPadrao.TFMsgEmail fEmail = new FormRelPadrao.TFMsgEmail())
                    {
                        fEmail.lAnexos.Add(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                        if (fEmail.ShowDialog() == DialogResult.OK)
                        {
                            List<string> lDest = new List<string>();
                            string[] aux = fEmail.pDs_destinatario.Split(new char[] { ';' });
                            foreach (string s in aux) lDest.Add(s);
                            new FormRelPadrao.Email(lDest, fEmail.pTitulo, fEmail.Mensagem, fEmail.lAnexos).EnviarEmail();
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void TFGerarXmlNfe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
            pFiltro.set_FormatZero();
            if (St_nfce)
                Text = "Gerar Arquivo XML NFC-e";
            else Text = "Gerar Arquivo XML NF-e";
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFGerarXmlNfe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGerarArqXml();
        }

        private void bb_gerararquivo_Click(object sender, EventArgs e)
        {
            afterGerarArqXml();
        }
                
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null && rCfgNfe == null)
            {
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfg.Count > 0)
                    rCfgNfe = lCfg[0];
            }
        }
    }
}
