using System;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Estoque.Cadastros
{
    public partial class TFItensBalanca : Form
    {
        private CamadaDados.Estoque.TList_LanPrecoItem _itens;
        public CamadaDados.Estoque.TList_LanPrecoItem Itens
        {
            get { return _itens; }
            set { _itens = value; }
        }

        public TFItensBalanca()
        {
            InitializeComponent();
        }

        private void TFItensBalanca_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItens.DataSource = _itens;
        }

        private void bbToledo_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                string path = null;
                StringBuilder s = new StringBuilder();
                using (FolderBrowserDialog fFile = new FolderBrowserDialog())
                {
                    fFile.SelectedPath = Properties.Settings.Default.Path;
                    if (fFile.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fFile.SelectedPath))
                        {
                            Properties.Settings.Default.Path = fFile.SelectedPath;
                            Properties.Settings.Default.Save();
                            path = fFile.SelectedPath + "\\" + "TXITENS.TXT";
                            (bsItens.List as CamadaDados.Estoque.TList_LanPrecoItem).ForEach(p => s.AppendLine("01".PadRight(5, '0') +
                                                             p.CD_Produto.FormatStringEsquerda(6, '0') +
                                                             p.VL_PrecoVenda.ToString("N2").SoNumero().FormatStringEsquerda(6, '0') +
                                                             p.Qtd_validade.ToString().FormatStringEsquerda(3, '0') +
                                                             p.DS_Produto.Trim()));
                            //Criar Arquivo SQL
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                                file.Write(s);
                                file.Close();
                            }
                            else
                                using (System.IO.FileStream fs = System.IO.File.Create(path))
                                {
                                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                                    {
                                        sw.Write(s);
                                    }
                                }
                            MessageBox.Show("Arquivo criado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                }
            }
        }

        private void bbFilizola_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                string path = null;
                StringBuilder s = new StringBuilder();
                using (FolderBrowserDialog fFile = new FolderBrowserDialog())
                {
                    fFile.SelectedPath = Properties.Settings.Default.Path;
                    if (fFile.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fFile.SelectedPath))
                        {
                            Properties.Settings.Default.Path = fFile.SelectedPath;
                            Properties.Settings.Default.Save();
                            path = fFile.SelectedPath + "\\" +
                                CamadaDados.UtilData.Data_Servidor().ToString("ddMMyyyy-HHmm") + "-Balanca.txt";
                            (bsItens.List as CamadaDados.Estoque.TList_LanPrecoItem).ForEach(p =>
                            {
                            //Tirar acentos descrição do produto
                            StringBuilder str = new StringBuilder();
                                var arrayText = p.DS_Produto.Normalize(NormalizationForm.FormD).ToCharArray();
                                foreach (char ds in arrayText)
                                {
                                    if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ds) != System.Globalization.UnicodeCategory.NonSpacingMark)
                                        str.Append(ds);

                                }
                                s.AppendLine(p.CD_Produto.Remove(0, 1) + "P" +
                                (str.ToString().Length > 22 ?
                                    str.ToString().Substring(0, 22).ToString() :
                                    str.ToString().Length < 22 ?
                                    str.ToString().PadRight(22, ' ') : str.ToString()) +
                                    p.VL_PrecoVenda.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).Split(new char[] { ',' })[0].PadLeft(5, '0').Trim() +
                                    p.VL_PrecoVenda.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).Split(new char[] { ',' })[1].PadRight(2, '0').Trim() +
                                    p.Qtd_validade.ToString().PadLeft(3, '0').Trim());
                            });
                            //Criar Arquivo SQL
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                                file.Write(s);
                                file.Close();
                            }
                            else
                                using (System.IO.FileStream fs = System.IO.File.Create(path))
                                {
                                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                                    {
                                        sw.Write(s);
                                    }
                                }
                            MessageBox.Show("Arquivo criado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                }
            }
        }

        private void bbRemove_Click(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
                if(MessageBox.Show("Deseja remover item do arquivo de exportação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
                        hs.Add("@produto", (bsItens.Current as CamadaDados.Estoque.TRegistro_LanPrecoItem).CD_Produto);
                        new CamadaDados.TDataQuery().executarSql("update tb_est_produto set ST_ExpBalanca = 'N', dt_alt = getdate() where cd_produto = @produto", hs);
                        MessageBox.Show("Produto removido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsItens.RemoveCurrent();
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
