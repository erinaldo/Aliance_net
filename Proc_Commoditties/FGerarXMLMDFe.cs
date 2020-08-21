using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;
using Ionic.Utils.Zip;

namespace Proc_Commoditties
{
    public partial class TFGerarXMLMDFe : Form
    {
        public TFGerarXMLMDFe()
        {
            InitializeComponent();
        }

        private void afterGerarArqXml()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_mdfe.Text))
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
                TpBusca[] filtro = new TpBusca[2];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //MDFe Aceito
                filtro[1].vNM_Campo = "a.nr_protocolo";
                filtro[1].vOperador = "is";
                filtro[1].vVL_Busca = "not null";
                if (!string.IsNullOrEmpty(nr_mdfe.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_mdfe";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_mdfe.Text;
                }
                if (!string.IsNullOrEmpty(dt_inicial.Text.SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inicial.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_final.Text.SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_final.Text).ToString("yyyyMMdd") + "'";
                }
                CamadaDados.Frota.Cadastros.TList_CfgMDFe lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgMDFe.Buscar(CD_Empresa.Text,
                                                                                                                  null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração de MDFe para empresa selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MDFe.GerarArq.TGerarArq.GerarArquivoXmlPeriodo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                               new CamadaDados.Frota.TCD_MDFe().Select(filtro, 0, string.Empty),
                                                               lCfg[0]);
                if (st_compactar.Checked)
                {
                    ZipFile zip = new ZipFile(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy") + ".zip");
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"));
                    foreach (System.IO.FileInfo file in dir.GetFiles())
                        if (file.Name.Substring(file.Name.LastIndexOf('.') + 1, 3).Trim().Equals("xml"))
                            zip.AddFile(file.DirectoryName + "\\" + file.Name, string.Empty);
                    zip.Save();
                }
                MessageBox.Show("Arquivos gerados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void TFGerarXMLMDFe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_gerararquivo_Click(object sender, EventArgs e)
        {
            this.afterGerarArqXml();
        }

        private void TFGerarXMLMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGerarArqXml();
        }
    }
}
