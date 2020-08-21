using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using System.Collections.Generic;
using System.ComponentModel;

namespace Estoque
{
    public partial class TFImportarSaldo : Form
    {
        public string pCd_empresa
        { get{ return cbEmpresa.SelectedItem == null ? string.Empty : cbEmpresa.SelectedValue.ToString(); }}
        public string pCd_fornecedor
        { get { return cd_fornecedor.Text; } }
        public List<TRegistro_CadProduto> lProduto
        {
            get
            {
                if (bsProduto.Count > 0)
                    return (bsProduto.List as IEnumerable<TRegistro_CadProduto>).ToList();
                else return null;
            }
        }
        public TFImportarSaldo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_fornecedor.Text))
            {
                MessageBox.Show("Obrigatório selecionar fornecedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_fornecedor.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFImportarSaldo_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void bbLerArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Arquivo CSV|*.csv";
                if(op.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader rd = new StreamReader(op.FileName))
                    {
                        string linha = null;
                        while((linha = rd.ReadLine()) != null)
                        {
                            string[] colunas = linha.Split(';');
                            if(colunas.Length.Equals(2))
                            {
                                TList_CadProduto lProd = TCN_CadProduto.Busca(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              "A",
                                                                              colunas[0],
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                                if(lProd.Count > 0)
                                {
                                    decimal qtd = decimal.Zero;
                                    decimal.TryParse(colunas[1], out qtd);
                                    lProd[0].Qt_dias_PrazoGarantia = qtd;
                                    bsProduto.Add(lProd[0]);
                                }
                                else
                                    bsProduto.Add(new TRegistro_CadProduto { Codigo_alternativo = colunas[0], Qt_dias_PrazoGarantia = decimal.Parse(colunas[1]) });
                            }
                        }
                        if (bsProduto.Count > 0)
                        {
                            int cont = (bsProduto.List as IEnumerable<TRegistro_CadProduto>).Count(p => string.IsNullOrEmpty(p.CD_Produto));
                            if (cont > 0)
                                tslRegInconsistente.Text = "Registros Inconsistentes {" + cont.ToString() + " }";
                            else tslRegInconsistente.Text = string.Empty;
                        }
                        else tslRegInconsistente.Text = string.Empty;
                    }
                }
            }
        }
        private void bbFornecedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, "isnull(a.st_fornecedor, 'N')|=|'S'");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';isnull(a.st_fornecedor, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_confirma_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFImportarSaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
