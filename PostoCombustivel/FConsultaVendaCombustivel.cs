using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFConsultaVendaCombustivel : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaVendaCombustivel()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFVendaCombustivel fVenda = new TFVendaCombustivel())
            {
                if(fVenda.ShowDialog() == DialogResult.OK)
                    if(fVenda.rVenda != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(fVenda.rVenda, null);
                            MessageBox.Show("Venda Combustivel gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if (bsVendaCombustivel.Current != null)
            {
                if ((bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_registro.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido excluir venda combustivel faturada.\r\n" +
                                    "Necessario antes excluir faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_afericaobool)
                {
                    if (MessageBox.Show("Venda combustivel marcada como aferição.\r\n" +
                                       "Confirma exclusão da venda mesmo assim?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Excluir(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel, null);
                            MessageBox.Show("Venda Combustivel excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else if(MessageBox.Show("Confirma exclusão da venda selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Excluir(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel, null);
                        MessageBox.Show("Venda Combustivel excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string st_registro = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                st_registro = "'A'";
                virg = ",";
            }
            if (cbFaturado.Checked)
            {
                st_registro += virg + "'F'";
                virg = ",";
            }
            if (cbEspera.Checked)
            {
                st_registro += virg + "'E'";
                virg = ",";
            }
            if (cbInconsistente.Checked)
                st_registro += virg + "'I'";

            CamadaDados.PostoCombustivel.TList_VendaCombustivel lVenda =
                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(CD_abastecida.Text,
                                                                           CD_Empresa.Text,
                                                                           cd_produto.Text,
                                                                           id_bico.Text,
                                                                           cd_clifor.Text,
                                                                           string.Empty,
                                                                           dt_inicial.Text,
                                                                           dt_final.Text,
                                                                           st_registro,
                                                                           cbAfericao.Checked ? "S" : "N",
                                                                           cbConvenio.Checked,
                                                                           string.Empty,
                                                                           placa.Text,
                                                                           "a.dt_abastecimento desc",
                                                                           null);
            bsVendaCombustivel.DataSource = lVenda;
            //Agrupar abastecimentos por produto
            bsResumo.DataSource = lVenda.GroupBy(p => p.Ds_produto,
                (aux, venda) =>
                new
                {
                    ds_produto = aux,
                    volumeabastecido = venda.Sum(x => x.Volumeabastecido),
                    vl_subtotal = venda.Sum(x => x.Vl_subtotal)
                });
            //Totalizar Volume e Valor
            tot_volume.Value = lVenda.Sum(p => p.Volumeabastecido);
            tot_valor.Value = lVenda.Sum(p => p.Vl_subtotal);
        }
                
        private void EstornarAfericao()
        {
            if(bsVendaCombustivel.Current != null)
                if ((bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_afericaobool)
                    if (MessageBox.Show("Desmarcar venda combustivel como aferição?\r\n" +
                                        "A venda combustivel voltara a ficar disponivel para ser faturada.", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_afericao = "N";
                            (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_registro = "A";
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel, null);
                            MessageBox.Show("Aferição cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        { this.afterBusca(); }
        }

        private void DesdobrarAbastecida()
        {
            using (TFDesmembrarAbast fDesd = new TFDesmembrarAbast())
            {
                if(fDesd.ShowDialog() == DialogResult.OK)
                    if (fDesd.lDesdobro != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.DesdobrarAbastecidas(fDesd.lVenda, fDesd.lDesdobro, null);
                            MessageBox.Show("Desdobros da abastecida gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch
                        (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void EncerranteManual()
        {
            using (TFEncerranteManual fEncManual = new TFEncerranteManual())
            {
                fEncManual.ShowDialog();
            }
        }

        private void CorrigirPlacaKM()
        {
            using (TFCorrigirPlacaKm fCor = new TFCorrigirPlacaKm())
            {
                fCor.ShowDialog();
                this.afterBusca();
            }
        }

        private void afterPrint()
        {
            if (bsVendaCombustivel.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsVendaCombustivel;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "POC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO VENDA COMBUSTIVEL";
                    Rel.Adiciona_DataSource("BINRESUMO", bsResumo);

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
                                           "RELATORIO VENDA COMBUSTIVEL",
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
                                               "RELATORIO VENDA COMBUSTIVEL",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe registros para gerar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFConsultaVendaCombustivel_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAbastecimento);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            BB_Novo.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR INCLUIR ABASTECIMENTO MANUAL", null);
            bb_cancelar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR ABASTECIMENTO", null);
            bb_desmembrar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR DESDOBRAR ABASTECIDA", null);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gAbastecimento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADO"))
                        gAbastecimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("EM ESPERA"))
                        gAbastecimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("INCONSISTENTE"))
                        gAbastecimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gAbastecimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void bb_estorna_Click(object sender, EventArgs e)
        {
            this.EstornarAfericao();
        }

        private void TFConsultaVendaCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EstornarAfericao();
            else if (e.KeyCode.Equals(Keys.F11))
                this.DesdobrarAbastecida();
            else if (e.KeyCode.Equals(Keys.F12))
                this.EncerranteManual();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void bb_desmembrar_Click(object sender, EventArgs e)
        {
            this.DesdobrarAbastecida();
        }

        private void gAbastecimento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAbastecimento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVendaCombustivel.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel());
            CamadaDados.PostoCombustivel.TList_VendaCombustivel lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_VendaCombustivel(lP.Find(gAbastecimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAbastecimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_VendaCombustivel(lP.Find(gAbastecimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAbastecimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sort(lComparer);
            bsVendaCombustivel.ResetBindings(false);
            gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_bico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|Id. Bico|60;" +
                              "a.ds_label|Label Bico|80;" +
                              "a.enderecofisicobico|Endereço Bico|80;" +
                              "c.ds_produto|Combustivel|200;" +
                              "d.nm_empresa|Empresa|200";
            string vParam = "a.st_registro|=|'A'";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" + "a.st_registro|=|'A'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(), vParam);
        }

        private void id_bico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|=|" + id_bico.Text;
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vColunas += ";a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_encerrante_Click(object sender, EventArgs e)
        {
            this.EncerranteManual();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_corrigirPlacaKM_Click(object sender, EventArgs e)
        {
            this.CorrigirPlacaKM();
        }

        private void TFConsultaVendaCombustivel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAbastecimento);
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void editDefault1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
