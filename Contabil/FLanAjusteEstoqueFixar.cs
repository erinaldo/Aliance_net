using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;

namespace Contabil
{
    public partial class TFLanAjusteEstoqueFixar : Form
    {
        public TFLanAjusteEstoqueFixar()
        {
            InitializeComponent();
        }
        private void afterNovo()
        {
            using (TFSaldoEstoqueFixar fSaldo = new TFSaldoEstoqueFixar())
            {
                fSaldo.ShowDialog();
                afterBusca();
            }
        }
        private void afterExclui()
        {
            if(bsAtualizaEstFixar.Current != null)
                if(MessageBox.Show("Confirma exclusão registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_AtualizaEstFixar.Excluir(bsAtualizaEstFixar.Current as TRegistro_AtualizaEstFixar, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsAtualizaEstFixar.RemoveCurrent();
                    }
                    catch(Exception ex)
                    { MessageBox.Show("Erro", ex.Message.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void afterBusca()
        {
            bsAtualizaEstFixar.DataSource = TCN_AtualizaEstFixar.Buscar(cd_empresa.Text,
                                                                        cd_produto.Text,
                                                                        dt_ini.Text,
                                                                        dt_fin.Text,
                                                                        tp_movimento.SelectedIndex == 0 ? "C" : "V",
                                                                        null);
        }
        private void TFLanAjusteEstoqueFixar_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tp_movimento.SelectedIndex = 0;
        }

        private void bbEmpresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_commodities, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_commodities, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFLanAjusteEstoqueFixar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }
    }
}
