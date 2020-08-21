using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFLanCargaEntrega : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanCargaEntrega()
        {
            InitializeComponent();
        }

        private void LimparFitros()
        {
            carga.Clear();
            entrega.Clear();
            cd_empresa.Clear();
            placa.Clear();
            cd_motorista.Clear();;
            DT_Final.Clear();
            DT_Inicial.Clear();
            cbAberto.Checked = false;
            cbEntregue.Checked = false;
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                cond = "'A'";
                virg = ",";
            }
            if (cbEntregue.Checked)
            {
                cond += virg + "'E'";
                virg = ",";
            }
            bsCarga.DataSource = CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.Buscar(cd_empresa.Text,
                                                                                              carga.Text,
                                                                                              cd_motorista.Text,
                                                                                              placa.Text,
                                                                                              entrega.Text,
                                                                                              CD_Produto.Text,
                                                                                              DT_Inicial.Text,
                                                                                              DT_Final.Text,
                                                                                              cond,
                                                                                              null);


            bsCarga_PositionChanged(this, new EventArgs());
        }

        private void afterNovo()
        {
            using (TFCarga fCarga = new TFCarga())
            {
                if (fCarga.ShowDialog() == DialogResult.OK)
                    if (fCarga.rCarga != null)
                    {
                        try
                        {
                            CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.Gravar(fCarga.rCarga, null);
                            MessageBox.Show("Carga gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFitros();
                            carga.Text = fCarga.rCarga.Id_cargastr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido alterar Carga EXECUTADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar Carga CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCarga fCarga = new TFCarga())
                {
                    fCarga.rCarga = bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega;
                    if (fCarga.ShowDialog() == DialogResult.OK)
                        if (fCarga.rCarga != null)
                            try
                            {
                                CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.Gravar(fCarga.rCarga, null);
                                MessageBox.Show("Carga alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    this.LimparFitros();
                    carga.Text = fCarga.rCarga.Id_cargastr;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir Carga EXECUTADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Esta Carga já se encontra CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão da Carga selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.Excluir(bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega, null);
                        MessageBox.Show("Carga excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Print()
        {
            if (bsCarga.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Faturamento.Entrega.TList_CargaEntrega() { bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = this.Name;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ROMANEIO DE ENTREGA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ROMANEIO DE ENTREGA",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "ROMANEIO DE ENTREGA",
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void ProcessarEntrega()
        {
            if (bsCarga.Current != null && bsCargaItens.Count > 0)
            {
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é possivel processar Carga EXECUTADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEntregarCarga fEntregarCarga = new TFEntregarCarga())
                {
                    fEntregarCarga.rCarga = (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega);
                    if (fEntregarCarga.ShowDialog() == DialogResult.OK)
                        if (fEntregarCarga.rCarga != null)
                            try
                            {
                                CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.ProcessarEntrega(fEntregarCarga.rCarga, null);
                                MessageBox.Show("Entrega processada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFitros();
                                carga.Text = fEntregarCarga.rCarga.Id_cargastr;
                                this.afterBusca();

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void EstornarProcEntrega()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).St_registro.Trim().ToUpper() != "E")
                {
                    MessageBox.Show("Permitido estornar somente entrega PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma estorno do processamento?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Entrega.TCN_CargaEntrega.EstornarProcEntrega(bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega, null);
                        MessageBox.Show("Processamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFitros();
                        carga.Text = (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).Id_cargastr;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanCargaEntrega_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            Utils.ShapeGrid.RestoreShape(this, gEntrega);
            Utils.ShapeGrid.RestoreShape(this, gEntregaItens);
            Utils.ShapeGrid.RestoreShape(this, gCarga);
            Utils.ShapeGrid.RestoreShape(this, gCargaItens);
        }

        private void TFLanCargaEntrega_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEntrega);
            Utils.ShapeGrid.SaveShape(this, gEntregaItens);
            Utils.ShapeGrid.SaveShape(this, gCarga);
            Utils.ShapeGrid.SaveShape(this, gCargaItens);
        }

        private void TFLanCargaEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.Print();
            else if (e.KeyCode.Equals(Keys.F10))
                this.ProcessarEntrega();
            else if (e.KeyCode.Equals(Keys.F11))
                this.EstornarProcEntrega();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void bb_Processar_Click(object sender, EventArgs e)
        {
            this.ProcessarEntrega();
        }

        private void bsCarga_PositionChanged(object sender, EventArgs e)
        {
            if (bsCarga.Current != null)
            {
                (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).lItens =
                    CamadaNegocio.Faturamento.Entrega.TCN_ItensCarga.Buscar(string.Empty,
                                                                            (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).Id_cargastr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
                bsCarga.ResetCurrentItem();
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                              "isnull(a.st_motorista, 'N')|=|'S';" +
                               "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
                              "(exists(select 1 from tb_est_codbarra x " +
                              "         where x.cd_produto = a.cd_produto " +
                              "         and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXECUTADA"))
                        gCarga.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gCarga.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gCargaItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gCargaItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gCargaItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.EstornarProcEntrega();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.Print();
        }
    }
}
