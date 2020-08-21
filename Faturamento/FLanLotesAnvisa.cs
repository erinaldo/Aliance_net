using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLanLotesAnvisa : Form
    {
        public TFLanLotesAnvisa()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (Proc_Commoditties.TFNovoLoteAnvisa fLote = new Proc_Commoditties.TFNovoLoteAnvisa())
            {
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            using (Proc_Commoditties.TFNovoLoteAnvisa fLote = new Proc_Commoditties.TFNovoLoteAnvisa())
            {
                fLote.rLote = bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa;
                if (fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if (bsLoteAnvisa.Current != null)
            {
                if ((bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).lMov.Exists(p=> p.Tp_mov.ToUpper().Equals("S")))
                {
                    MessageBox.Show("Não é possivel excluir Lote que possui movimentação de saída", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do Lote selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Excluir(bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa, null);
                        MessageBox.Show("Lote excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            bsLoteAnvisa.DataSource =
                CamadaNegocio.Faturamento.LoteAnvisa.TCN_LoteAnvisa.Buscar(Cd_empresa.Text,
                                                                           Cd_fornecedor.Text,
                                                                           Cd_produto.Text,
                                                                           nr_lote.Text,
                                                                           rbDtFabric.Checked ? "F" : "V",
                                                                           dt_ini.Text,
                                                                           dt_fin.Text,
                                                                           string.Empty,
                                                                           null);
            bsLoteAnvisa_PositionChanged(this, new EventArgs());
        }

        private void TFLanLotesAnvisa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gLoteAnvisa);
            Utils.ShapeGrid.RestoreShape(this, gMovLoteAnvisa);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsLoteAnvisa_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteAnvisa.Current != null)
            {
                (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).lMov =
                    CamadaNegocio.Faturamento.LoteAnvisa.TCN_MovLoteAnvisa.Buscar((bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Cd_empresa,
                                                                                  (bsLoteAnvisa.Current as CamadaDados.Faturamento.LoteAnvisa.TRegistro_LoteAnvisa).Id_lotestr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                bsLoteAnvisa.ResetCurrentItem();
            }
        }

        private void TFLanLotesAnvisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { Cd_empresa }, string.Empty);
        }

        private void Cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + Cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_fornecedor }, string.Empty);
        }

        private void Cd_fornecedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_fornecedor.Text.Trim() + "'",
                                             new Componentes.EditDefault[] { Cd_fornecedor },
                                             new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_produto }, string.Empty);
        }

        private void Cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_produto.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { Cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFLanLotesAnvisa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gLoteAnvisa);
            Utils.ShapeGrid.SaveShape(this, gMovLoteAnvisa);
        }

        private void gLoteAnvisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gLoteAnvisa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gLoteAnvisa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
