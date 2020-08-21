using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFPracaCobranca : Form
    {
        public TFPracaCobranca()
        {
            InitializeComponent();
        }

        private void ImportarRegistro()
        {
            using (OpenFileDialog ofp = new OpenFileDialog())
            {
                ofp.Filter = "TXT|*.txt";
                if (ofp.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(ofp.FileName))
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(ofp.FileName))
                        {
                            //Buscar banco
                            DataRowView lbanco = FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_banco|Banco|200;a.cd_banco|Codigo|80",
                                                    null, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
                            if (lbanco == null)
                            {
                                MessageBox.Show("Obrigatorio selecionar banco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            while (!reader.EndOfStream)
                            {
                                string linha = reader.ReadLine();
                                if(linha.Length == 50)
                                    if (linha.Substring(0, 1).Equals("1"))
                                    {
                                        CamadaDados.Financeiro.Cadastros.TRegistro_PracaCobranca rPraca = new CamadaDados.Financeiro.Cadastros.TRegistro_PracaCobranca();
                                        //Codigo Praca
                                        rPraca.Cd_pracastr = linha.Substring(1, 6);
                                        //Cidade
                                        string cidade = linha.Substring(7, 25);
                                        string uf = linha.Substring(32, 2);
                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "b.uf",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + uf.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = string.Empty,
                                                                vVL_Busca = "(a.DS_Cidade like '" + cidade.Trim() + "%') or " +
                                                                            "(a.Distrito like '" + cidade.Trim() + "%')"
                                                            }
                                                        }, "a.cd_cidade");
                                        if (obj == null)
                                            continue;
                                        rPraca.Cd_cidade = obj.ToString();
                                        //status
                                        rPraca.St_registro = linha.Substring(34, 1).Trim().Equals("A") ? "A" : "I";
                                        //Banco
                                        rPraca.Cd_banco = lbanco["cd_banco"].ToString();
                                        //Gravar registro
                                        new CamadaDados.Financeiro.Cadastros.TCD_PracaCobranca().Gravar(rPraca);
                                    }
                            }
                            this.afterBusca();
                        }
            }
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(cd_banco.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_banco.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_cidade.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cidade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_cidade.Text.Trim() + "'";
            }
            bsPracaCobranca.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_PracaCobranca().Select(filtro, 0, string.Empty);
        }

        private void TFPracaCobranca_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_banco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void bb_banco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_banco|Banco|200;" +
                              "a.cd_banco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_cidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidade },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|80;" +
                              "a.distrito|Distrito|150;" +
                              "b.uf|UF|20";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidade },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_importar_Click(object sender, EventArgs e)
        {
            this.ImportarRegistro();
        }

        private void TFPracaCobranca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.ImportarRegistro();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
