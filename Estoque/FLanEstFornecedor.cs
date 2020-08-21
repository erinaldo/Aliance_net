using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Estoque
{
    public partial class TFLanEstFornecedor : Form
    {
        public TFLanEstFornecedor()
        {
            InitializeComponent();
        }
        private void afterBusca()
        {
            bsEstFornecedor.DataSource = TCN_EstFornecedor.Buscar(cbEmpresa.SelectedItem == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                  cd_fornecedor.Text,
                                                                  cd_produto.Text,
                                                                  null);
        }
        private void afterExclui()
        {
            if(bsEstFornecedor.Current != null)
            {
                if(MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_EstFornecedor.Excluir(bsEstFornecedor.Current as TRegistro_EstFornecedor, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void Importar()
        {
            using (TFImportarSaldo fImport = new TFImportarSaldo())
            {
                if(fImport.ShowDialog() == DialogResult.OK)
                    if(fImport.lProduto != null)
                        try
                        {
                            TCN_EstFornecedor.Importar(fImport.lProduto, fImport.pCd_empresa, fImport.pCd_fornecedor, null);
                            MessageBox.Show("Importação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void TFLanEstFornecedor_Load(object sender, EventArgs e)
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
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void bbFornecedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, "isnull(a.st_fornecedor, 'N')|=|'S'");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';isnull(a.st_fornecedor, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_fornecedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbImportarSaldo_Click(object sender, EventArgs e)
        {
            Importar();
        }

        private void TFLanEstFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F10))
                Importar();
        }

        private void gEstFornecedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEstFornecedor.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEstFornecedor.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_EstFornecedor());
            TList_EstFornecedor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEstFornecedor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEstFornecedor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_EstFornecedor(lP.Find(gEstFornecedor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEstFornecedor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_EstFornecedor(lP.Find(gEstFornecedor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEstFornecedor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEstFornecedor.List as TList_EstFornecedor).Sort(lComparer);
            bsEstFornecedor.ResetBindings(false);
            gEstFornecedor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
