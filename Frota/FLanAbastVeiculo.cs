using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using Componentes;

namespace Frota
{
    public partial class TFLanAbastVeiculo : Form
    {
        private bool Altera_Relatorio = false;
        private EditDefault Nm_fornecedor = new EditDefault() { NM_CampoBusca = "nm_clifor", NM_Campo = "nm_Clifor", NM_Param = "@P_NM_CLIFOR" };

        public TFLanAbastVeiculo()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_abastecimento.Clear();
            cd_empresa.Clear();
            id_viagem.Clear();
            id_veiculo.Clear();
            id_despesa.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            placa.Clear();
        }

        private void afterNovo()
        {
            using (TFAbastAvulso fAbast = new TFAbastAvulso())
            {
                if (fAbast.ShowDialog() == DialogResult.OK)
                    if (fAbast.rAbast != null)
                    {
                        if (fAbast.rAbast.Tp_abastecimento.Trim().ToUpper().Equals("T") &&
                            fAbast.rAbast.Tp_pagamento.Trim().ToUpper().Equals("E"))
                        {
                            //Buscar config abast
                            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fAbast.rAbast.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata) && !string.IsNullOrEmpty(fAbast.vCd_clifor))
                                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                {
                                    fDup.vCd_empresa = fAbast.rAbast.Cd_empresa;
                                    fDup.vNm_empresa = fAbast.rAbast.Nm_empresa;
                                    fDup.vCd_clifor = fAbast.vCd_clifor;
                                    fDup.vNm_clifor = fAbast.rAbast.Nm_fornecedor;
                                    fDup.vCd_endereco = fAbast.vCd_endereco;
                                    fDup.vDs_endereco = fAbast.vDs_endereco;
                                    if (lCfg.Count > 0)
                                    {
                                        fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                        fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                        fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                        fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                        fDup.vTp_mov = "P";
                                        fDup.vCd_historico = lCfg[0].Cd_historico;
                                        fDup.vDs_historico = lCfg[0].Ds_historico;
                                        fDup.vDt_emissao = fAbast.rAbast.Dt_abastecimentostr;
                                        fDup.vVl_documento = fAbast.rAbast.Vl_subtotal;
                                        fDup.vNr_docto = fAbast.rAbast.Nr_notafiscal;
                                        fDup.vSt_ecf = true;
                                        if (fDup.ShowDialog() == DialogResult.OK)
                                            if (fDup.dsDuplicata.Count > 0)
                                                fAbast.rAbast.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    }
                                }
                        }
                        try
                        {
                            fAbast.rAbast.Tp_captura = "M";
                            fAbast.rAbast.Tp_registro = "A";
                            CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fAbast.rAbast, null);
                            MessageBox.Show("Abastecimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_abastecimento.Text = fAbast.rAbast.Id_abastecimentostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsAbastVeiculo.Current != null)
            {
                if ((bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro.Trim().ToUpper().Equals("R"))
                    using (TFRequisicao fRequisicao = new TFRequisicao())
                    {
                        fRequisicao.rAbast = bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                        if (fRequisicao.ShowDialog() == DialogResult.OK)
                            if (fRequisicao.rAbast != null)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fRequisicao.rAbast, null);
                                    MessageBox.Show("Requisição alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimparFiltros();
                                    id_abastecimento.Text = fRequisicao.rAbast.Id_abastecimentostr;
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    using (TFAbastAvulso fAbast = new TFAbastAvulso())
                    {
                        fAbast.rAbast = bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                        if (fAbast.ShowDialog() == DialogResult.OK)
                            if (fAbast.rAbast != null)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fAbast.rAbast, null);
                                    MessageBox.Show("Abastecimento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimparFiltros();
                                    id_abastecimento.Text = fAbast.rAbast.Id_abastecimentostr;
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterExclui()
        {
            if (bsAbastVeiculo.Current != null)
            {
                CamadaDados.Frota.TList_AbastVeiculo lAbast = new CamadaDados.Frota.TCD_AbastVeiculo().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_frt_abast_x_duplicata x where x.id_abastecimento = a.id_abastecimento " +
                                        "and x.cd_empresa = '" + (bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).lDup[0].Cd_empresa.Trim() + "' " +
                                        "and x.nr_lancto = " + (bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).lDup[0].Nr_lancto.ToString() + ")"
                        }
                    }, 0, string.Empty);
                if (lAbast.Count > 1)
                {
                    //Exclusão de abastecimentos compostos
                    if (MessageBox.Show("Confirma exclusão do abastecimento composto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.TCN_AbastVeiculo.Excluir(lAbast, null);
                            MessageBox.Show("Abastecimento excluído com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                //Exclusão de abastecimentos avulsos
                else
                {
                    if (MessageBox.Show("Confirma exclusão " + ((bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro.Trim().ToUpper().Equals("R") ? "da requisição " : "do abastecimento ") +
                                    "selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.TCN_AbastVeiculo.Excluir(bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo, null);
                            MessageBox.Show(((bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro.Trim().ToUpper().Equals("R") ? "Requisição excluida " : "Abastecimento excluido ") +
                                        "com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterBusca()
        {
            string tp_abast = string.Empty;
            string virg = string.Empty;
            if (cbProprio.Checked)
            {
                tp_abast = "'P'";
                virg = ",";
            }
            if (cbTerceiro.Checked)
                tp_abast += virg + "'T'";
            string tp_pagto = string.Empty;
            virg = string.Empty;
            if (cbEmpresa.Checked)
            {
                tp_pagto = "'E'";
                virg = ",";
            }
            if (cbMotorista.Checked)
                tp_pagto += virg + "'M'";
            string tp_reg = string.Empty;
            virg = string.Empty;
            if (cbAbastecida.Checked)
            {
                tp_reg = "'A'";
                virg = ",";
            }
            if (cbRequisicao.Checked)
                tp_reg += virg + "'R'";

            bsAbastVeiculo.DataSource = CamadaNegocio.Frota.TCN_AbastVeiculo.Buscar(id_abastecimento.Text,
                                                                                    cd_empresa.Text,
                                                                                    id_viagem.Text,
                                                                                    id_veiculo.Text,
                                                                                    placa.Text,
                                                                                    id_despesa.Text,
                                                                                    rbRequisicao.Checked ? "R" : string.Empty,
                                                                                    dt_ini.Text,
                                                                                    dt_fin.Text,
                                                                                    tp_abast,
                                                                                    tp_pagto,
                                                                                    tp_reg,
                                                                                    nr_notafiscal.Text,
                                                                                    nr_docagrup.Text,
                                                                                    0,
                                                                                    null);

            //Filtro por Nm_fornecedor com base no Código informado
            if (!string.IsNullOrEmpty(Nm_fornecedor.Text) && !string.IsNullOrEmpty(cd_clifor.Text.Trim()))
                bsAbastVeiculo.DataSource = (bsAbastVeiculo.DataSource as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>)
                    .ToList()
                        .FindAll(p => p.Nm_fornecedor.Equals(Nm_fornecedor.Text));

            //Totalizador
            tot_valor.Value = (bsAbastVeiculo.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Vl_subtotal);
            tot_volume.Value = (bsAbastVeiculo.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Volume);
            tot_unitario.Value = (bsAbastVeiculo.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Vl_unitario);

            bsAbastVeiculo_PositionChanged(this, new EventArgs());
        }

        private void RequisicaoAbast()
        {
            using (TFRequisicao fRequisicao = new TFRequisicao())
            {
                if (fRequisicao.ShowDialog() == DialogResult.OK)
                    if (fRequisicao.rAbast != null)
                        try
                        {
                            fRequisicao.rAbast.LoginRequisicao = Utils.Parametros.pubLogin;
                            fRequisicao.rAbast.Tp_registro = "R";//Requisicao
                            CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fRequisicao.rAbast, null);
                            MessageBox.Show("Requisição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_abastecimento.Text = fRequisicao.rAbast.Id_abastecimentostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Print()
        {
            if (bsAbastVeiculo.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsAbastVeiculo;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLanAbastVeiculo";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void TFLanAbastVeiculo_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAbastVeiculo);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|" + id_viagem.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem },
                                                new CamadaDados.Frota.TCD_Viagem());
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Descrição Viagem|200;" +
                              "a.id_viagem|Id. Viagem|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem },
                                            new CamadaDados.Frota.TCD_Viagem(), string.Empty);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_requisicao_Click(object sender, EventArgs e)
        {
            RequisicaoAbast();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gAbastVeiculo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("REQUISIÇÃO"))
                        gAbastVeiculo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else gAbastVeiculo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gAbastVeiculo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAbastVeiculo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAbastVeiculo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_AbastVeiculo());
            CamadaDados.Frota.TList_AbastVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAbastVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAbastVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_AbastVeiculo(lP.Find(gAbastVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAbastVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_AbastVeiculo(lP.Find(gAbastVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAbastVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAbastVeiculo.List as CamadaDados.Frota.TList_AbastVeiculo).Sort(lComparer);
            bsAbastVeiculo.ResetBindings(false);
            gAbastVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLanAbastVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                RequisicaoAbast();
            else if (e.KeyCode.Equals(Keys.F8))
                Print();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I';" +
                            "|EXISTS|(select * from tb_div_tpveiculo x " +
                             "where a.cd_tpveiculo = x.cd_tpveiculo " +
                             "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I';" +
                               "|EXISTS|(select * from tb_div_tpveiculo x " +
                               "where a.cd_tpveiculo = x.cd_tpveiculo " +
                               "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Descrição Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bsAbastVeiculo_PositionChanged(object sender, EventArgs e)
        {
            if (bsAbastVeiculo.Current != null)
                if ((bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("T") &&
                    (bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento.Trim().ToUpper().Equals("E"))
                {
                    (bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).lDup =
                        CamadaNegocio.Frota.TCN_Abast_X_Duplicata.BuscarDup((bsAbastVeiculo.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_abastecimentostr, null);
                    bsDup_PositionChanged(this, new EventArgs());
                    bsAbastVeiculo.ResetCurrentItem();
                }
        }

        private void bsDup_PositionChanged(object sender, EventArgs e)
        {
            if (bsDup.Current != null)
            {
                (bsDup.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Parcelas =
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.Busca((bsDup.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa,
                                                                            (bsDup.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_lancto,
                                                                            decimal.Zero,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
                bsDup.ResetCurrentItem();
            }
        }

        private void TFLanAbastVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAbastVeiculo);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }

        private void BB_Novo_C_Click(object sender, EventArgs e)
        {
            afterNovoC();
        }

        private void afterNovoC()
        {
            using (TFAbastComposto fAbast = new TFAbastComposto())
                fAbast.ShowDialog();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text + "'"
                , new EditDefault[] { cd_clifor, Nm_fornecedor }, new TCD_CadClifor());
        }

        private void bb_fornecedorAbast_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { cd_clifor, Nm_fornecedor }, string.Empty);
        }
    }
}
