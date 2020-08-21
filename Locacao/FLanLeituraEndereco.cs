using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFLanLeituraEndereco : Form
    {
        public TFLanLeituraEndereco()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFMedicao fMedicao = new TFMedicao())
            {
                if (fMedicao.ShowDialog() == DialogResult.OK)
                    if (fMedicao.lProdutos != null)
                        if (fMedicao.lProdutos.Count > 0)
                            try
                            {
                                CamadaNegocio.Locacao.TCN_MedicaoProdutoItens.Gravar(fMedicao.lProdutos, fMedicao.pDtMedicao, null);
                                MessageBox.Show("Medições gravadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else MessageBox.Show("Obrigatório informar medição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterBusca()
        {
            bsMedicao.DataSource = CamadaNegocio.Locacao.TCN_MedicaoProdutoItens.Buscar(cd_empresa.Text,
                                                                                        cd_buscapatrimonio.Text,
                                                                                        cd_produto.Text,
                                                                                        cd_endereco.Text,
                                                                                        DT_Inicial.Text,
                                                                                        DT_Final.Text,
                                                                                        null);
        }

        private void afterExclui()
        {
            if(bsMedicao.Current != null)
                if(MessageBox.Show("Confirma exclusão medição selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_MedicaoProdutoItens.Excluir(bsMedicao.Current as CamadaDados.Locacao.TRegistro_MedicaoProdutoItens, null);
                        MessageBox.Show("Medição excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bbBuscaPatrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "b.ds_produto|Patrimonio|200;" +
                              "a.NR_Patrimonio|Nº Patrimonio|80;" +
                              "a.CD_Patrimonio|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_buscapatrimonio },
                new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio(), string.Empty);
        }

        private void cd_buscapatrimonio_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_patrimonio|=|'" + cd_buscapatrimonio.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_buscapatrimonio }, new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bbEmpresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFLanLeituraEndereco_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLanLeituraEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }
    }
}
