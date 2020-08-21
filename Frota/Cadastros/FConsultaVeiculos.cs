using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFConsultaVeiculos : Form
    {
        private bool Altera_Relatorio = false;
        public TFConsultaVeiculos()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_veiculo.Clear();
            cd_cidade.Clear();
            placa.Clear();
            cor.Clear();
            ano.Clear();
            modelo.Clear();
            id_marca.Clear();
        }

        private void afterNovo()
        {
            using (TFCadVeiculo fVeiculo = new TFCadVeiculo())
            {
                if (fVeiculo.ShowDialog() == DialogResult.OK)
                    if (fVeiculo.rVeiculo != null)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Gravar(fVeiculo.rVeiculo, null);
                            MessageBox.Show("Veiculo gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_veiculo.Text = fVeiculo.rVeiculo.Id_veiculostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterAltera()
        {
            if (bsCadVeiculo.Current != null)
            {
                using (TFCadVeiculo fVeiculo = new TFCadVeiculo())
                {
                    fVeiculo.rVeiculo = bsCadVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo;
                    if (fVeiculo.ShowDialog() == DialogResult.OK)
                        if (fVeiculo.rVeiculo != null)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Gravar(fVeiculo.rVeiculo, null);
                                MessageBox.Show("Veiculo alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    this.LimparFiltros();
                    id_veiculo.Text = fVeiculo.rVeiculo.Id_veiculostr;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsCadVeiculo.Current == null)
                return;
            if (TCN_CadVeiculo.ExistsRodado((bsCadVeiculo.Current as TRegistro_CadVeiculo).Id_veiculostr, null))
            {
                MessageBox.Show("Não será possível excluir este veículo, pois possui rodado vinculado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confirma exclusão do veiculo selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    TCN_CadVeiculo.Excluir(bsCadVeiculo.Current as TRegistro_CadVeiculo, null);
                    MessageBox.Show("Veículo excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string Status = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                Status = "'A'";
                virg = ",";
            }
            if (cbInativo.Checked)
                Status += virg + "'I'";

            string Tipo_combustivel = string.Empty;
            string virg1 = string.Empty;
            if (cbGasolina.Checked)
            {
                Tipo_combustivel = "'GC'";
                virg1 = ",";
            }
            if (cbOleoDiesel.Checked)
                Tipo_combustivel += virg1 + "'OD'";
            if (cbEtanol.Checked)
                Tipo_combustivel += virg1 + "'ET'";
            if (cbFlex.Checked)
                Tipo_combustivel += virg1 + "'FL'";
            bsCadVeiculo.DataSource = TCN_CadVeiculo.Buscar(id_veiculo.Text,
                                                            cd_tpveiculo.Text,
                                                            cd_cidade.Text,
                                                            id_marca.Text,
                                                            cor.Text,
                                                            placa.Text,
                                                            ano.Text,
                                                            modelo.Text,
                                                            Tipo_combustivel,
                                                            string.Empty,
                                                            Status,
                                                            null);
            bsCadVeiculo.ResetBindings(true);
        }

        private void TFConsultaVeiculos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gSeguros);
            Utils.ShapeGrid.RestoreShape(this, gCadVeiculo);
            Utils.ShapeGrid.RestoreShape(this, gInfracoes);
            Utils.ShapeGrid.RestoreShape(this, gManutencao);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }


        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_cidade|Cidade|200;" +
                             "b.uf|UF|60;" +
                             "a.cd_cidade|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_cidade },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
                                            string.Empty);
        }

        private void cd_cidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidade },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tpveiculo|=|'" + cd_tpveiculo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpveiculo|TP.Veiculo|200;" +
                              "a.cd_tpveiculo|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cd_tpveiculo },
                new CamadaDados.Diversos.TCD_CadTpVeiculo(),
               string.Empty);
        }

        private void id_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_marca|=|'" + id_marca.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_marca },
                                    new CamadaDados.Frota.Cadastros.TCD_CadMarcaVeiculo());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_marca|Marca|200;" +
                              "a.id_marca|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { id_marca },
                new CamadaDados.Frota.Cadastros.TCD_CadMarcaVeiculo(),
               string.Empty);
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
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFConsultaVeiculos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void gCadVeiculo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadVeiculo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCadVeiculo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo());
            CamadaDados.Frota.Cadastros.TList_CadVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_CadVeiculo(lP.Find(gCadVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_CadVeiculo(lP.Find(gCadVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCadVeiculo.List as CamadaDados.Frota.Cadastros.TList_CadVeiculo).Sort(lComparer);
            bsCadVeiculo.ResetBindings(false);
            gCadVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gCadVeiculo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("INATIVO"))
                        gCadVeiculo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gCadVeiculo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }

        }


        private void TFConsultaVeiculos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gSeguros);
            Utils.ShapeGrid.SaveShape(this, gCadVeiculo);
            Utils.ShapeGrid.SaveShape(this, gInfracoes);
            Utils.ShapeGrid.SaveShape(this, gManutencao);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bbRel_Click(object sender, EventArgs e)
        {
            if (bsCadVeiculo.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCadVeiculo;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

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
                                           "RELATORIO " + this.Text.Trim(),
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
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void btn_adicionarRodado_Click(object sender, EventArgs e)
        {
            if (bsCadVeiculo.Current != null)
            {
                using (TFListRodado fRodado = new TFListRodado())
                {
                    fRodado.Id_veiculo = (bsCadVeiculo.Current as TRegistro_CadVeiculo).Id_veiculostr;
                    if (fRodado.ShowDialog() == DialogResult.OK)
                        if (fRodado.llRodado != null)
                            try
                            {
                                TList_RodadoVeic lRodadoVeic = new TList_RodadoVeic();
                                fRodado.llRodado.ForEach(p =>
                                {
                                    TRegistro_RodadoVeic rodadoVeic = new TRegistro_RodadoVeic();
                                    rodadoVeic.Id_veiculo = (bsCadVeiculo.Current as TRegistro_CadVeiculo).Id_veiculo;
                                    rodadoVeic.Id_rodado = p.Id_rodado;
                                    rodadoVeic.St_processar = p.St_processar;
                                    lRodadoVeic.Add(rodadoVeic);
                                });
                                TCN_RodadoVeic.Gravar(lRodadoVeic, null);
                                MessageBox.Show("Rodados adicionados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
    }
}
