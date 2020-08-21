using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFLanContratoFin : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanContratoFin()
        {
            InitializeComponent();
        }

        private void TFLanContratoFin_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gContratoFin);
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void LimpaFiltros()
        {
            Cd_empresa.Clear();
            Cd_clifor.Clear();
            nr_contrato.Clear();
            nr_contratoOrigem.Clear();
            dt_fin.Clear();
            dt_ini.Clear();
        }

        private void afterNovo()
        {
            using (TFContratoFin fContrato = new TFContratoFin())
            {
                if (fContrato.ShowDialog() == DialogResult.OK)
                    if (fContrato.rContrato != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.Gravar(fContrato.rContrato, null);
                            CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.ProcessarContratoFin(fContrato.rContrato, null);
                            MessageBox.Show("Contrato gerado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimpaFiltros();
                            nr_contrato.Text = fContrato.rContrato.NR_ContratoStr;
                            Cd_empresa.Text = fContrato.rContrato.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsContratoFin.Current != null)
            {
                using (TFContratoFin fContrato = new TFContratoFin())
                {
                    fContrato.rContrato = bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin;
                    if (fContrato.ShowDialog() == DialogResult.OK)
                        if (fContrato.rContrato != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.Gravar(fContrato.rContrato, null);
                                CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.ProcessarContratoFin(fContrato.rContrato, null);
                                MessageBox.Show("Contrato alterado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimpaFiltros();
                                nr_contrato.Text = fContrato.rContrato.NR_ContratoStr;
                                Cd_empresa.Text = fContrato.rContrato.Cd_empresa;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsContratoFin.Current != null)
            {
                if ((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc.Exists(p => !p.St_registro.ToUpper().Equals("A")))
                {
                    MessageBox.Show("Não é possivel excluir Contrato Financeiro com parcela PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja excluir este Contrato?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.Excluir(bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin, null);
                        MessageBox.Show("Contrato excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string or = string.Empty;
            if (cbAberto.Checked)
            {
                status = "null";
                or = " or nr_lancto is ";
            }
            if (cbProcessado.Checked)
                status += or + "not null";
            bsContratoFin.DataSource = CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.Buscar(nr_contrato.Text,
                                                                                                nr_contratoOrigem.Text,
                                                                                                Cd_empresa.Text,
                                                                                                Cd_clifor.Text,
                                                                                                status,
                                                                                                rbContrato.Checked ? "C" : rbVencimento.Checked ? "V" : string.Empty,
                                                                                                dt_ini.Text,
                                                                                                dt_fin.Text,
                                                                                                null);
            bsContratoFin.ResetCurrentItem();
            bsContratoFin_PositionChanged(this, new EventArgs());
        }

        private void EstornarProcesso()
        {
            if (MessageBox.Show("Deseja estornar processamento do Contrato selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                try
                {
                    CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.EstornarProcessamento(bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin, null);
                    MessageBox.Show("Contrato estornado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterPrint()
        {
            if (bsContratoFin.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsContratoFin;
                    Rel.Nome_Relatorio = "TFLanContratofin";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIN";
                    Rel.Ident = "TFLanContratoFin";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE CONTRATOS FINANCEIROS";

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
                                           "RELATORIO LISTA DE CONTRATOS FINANCEIROS",
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
                                                    "RELATORIO LISTA DE CONTRATOS FINANCEIROS",
                                                    fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void TFLanContratoFin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
            Utils.ShapeGrid.SaveShape(this, gContratoFin);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLanContratoFin_KeyDown(object sender, KeyEventArgs e)
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
                this.afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                this.EstornarProcesso();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void bsContratoFin_PositionChanged(object sender, EventArgs e)
        {
            if (bsContratoFin.Current != null)
            {
                if ((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Nr_lancto != null)
                {
                    (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParcela =
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.Busca((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_empresa,
                                                                                decimal.Parse((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Nr_lancto.ToString()),
                                                                                decimal.Zero,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
                }
                //Buscar Parcelas Contrato
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc =
                       CamadaNegocio.Financeiro.Contrato.TCN_ParcelaContrato.Buscar((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).NR_ContratoStr,
                                                                                    (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_empresa,
                                                                                    string.Empty,
                                                                                    null);
                                                                               
                //Buscar Duplicata
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup =
                    CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.BuscarDup((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_empresa,
                                                                                 (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).NR_ContratoStr,
                                                                                 null);
                bsContratoFin.ResetCurrentItem();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { Cd_empresa }
                         , new TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void Cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + Cd_empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { Cd_empresa }, new TCD_CadEmpresa());
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + Cd_clifor.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
               , new Componentes.EditDefault[] { Cd_clifor }, new TCD_CadClifor());
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.EstornarProcesso();
        }

        private void gContratoFin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                        gContratoFin.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gContratoFin.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gParcelas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("LIQUIDADA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("VENCIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PERDIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gContratoFin_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gContratoFin.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsContratoFin.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin());
            CamadaDados.Financeiro.Contrato.TList_ContratoFin lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gContratoFin.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gContratoFin.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Contrato.TList_ContratoFin(lP.Find(gContratoFin.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gContratoFin.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Contrato.TList_ContratoFin(lP.Find(gContratoFin.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gContratoFin.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsContratoFin.List as CamadaDados.Financeiro.Contrato.TList_ContratoFin).Sort(lComparer);
            bsContratoFin.ResetBindings(false);
            gContratoFin.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
