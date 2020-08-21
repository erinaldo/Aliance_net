using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;
using Ionic.Utils.Zip;

namespace Proc_Commoditties
{
    public partial class TFGerarXMLCTe : Form
    {
        public TFGerarXMLCTe()
        {
            InitializeComponent();
        }

        private void afterGerarArqXml()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar transportadora.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_cte.Text))
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
                TpBusca[] filtro = new TpBusca[3];
                //Emissao Propria
                filtro[0].vNM_Campo = "a.tp_emissao";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'P'";
                //CTe
                filtro[1].vNM_Campo = "a.cd_modelo";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "57";
                //CTe Aceito
                filtro[2].vNM_Campo = "a.status_cte";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'100'";
                if (!string.IsNullOrEmpty(nr_cte.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_ctrc";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_cte.Text;
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
                if (!string.IsNullOrEmpty(CD_Empresa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(cd_remetente.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_remetente";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_remetente.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(cd_destinatario.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_destinatario";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_destinatario.Text.Trim() + "'";
                }
                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(CD_Empresa.Text,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração de CTe para transportadora selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string msg = CTe.GerarArq.TGerarArq.GerarArquivoXmlPeriodo(path + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("ddMMyyyy"),
                                                                           new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(filtro, 0, string.Empty),
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
                MessageBox.Show("Arquivos gerados com sucesso." + (!string.IsNullOrEmpty(msg) ? "\r\n" + "Alguns arquivos não puderão ser gerados por inconsistências.\r\n" + msg.Trim() : string.Empty), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(st_email.Checked)
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

        private void TFGerarXMLCTe_Load(object sender, EventArgs e)
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
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_remetente, nm_remente }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_remetente, nm_remente }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }      

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_gerararquivo_Click(object sender, EventArgs e)
        {
            this.afterGerarArqXml();
        }

        private void TFGerarXMLCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGerarArqXml();
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario, nm_destinatario }, string.Empty);
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_destinatario, nm_destinatario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
