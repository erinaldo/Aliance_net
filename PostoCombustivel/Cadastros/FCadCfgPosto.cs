using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Utils;
using CamadaDados.PostoCombustivel.Cadastros;
using CamadaNegocio.PostoCombustivel.Cadastros;

namespace PostoCombustivel.Cadastros
{
    public partial class FCadCfgPosto : FormCadPadrao.FFormCadPadrao
    {
        public FCadCfgPosto()
        {
            InitializeComponent();
            DTS = bsCfgPosto;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("SEM AUTOMAÇÃO", "SA"));
            cbx.Add(new TDataCombo("COMPANYTEC", "CT"));
            cbx.Add(new TDataCombo("VWTECH", "VW"));
            cbx.Add(new TDataCombo("HORUSTECH", "HT"));
            tp_concentrador.DataSource = cbx;
            tp_concentrador.DisplayMember = "Display";
            tp_concentrador.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new TDataCombo("ABERTURA", "A"));
            cbx1.Add(new TDataCombo("FECHAMENTO", "F"));
            tp_leituraencerrantebico.DataSource = cbx1;
            tp_leituraencerrantebico.DisplayMember = "Display";
            tp_leituraencerrantebico.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx2.Add(new TDataCombo("CAPTURAR", "C"));
            cbx2.Add(new TDataCombo("CALCULAR", "L"));
            tp_modoencerrante.DataSource = cbx2;
            tp_modoencerrante.DisplayMember = "Display";
            tp_modoencerrante.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("0", "0"));
            cbx3.Add(new TDataCombo("10", "10"));
            cbx3.Add(new TDataCombo("100", "100"));
            cbx3.Add(new TDataCombo("1000", "1000"));
            fatorconvvolume.DataSource = cbx3;
            fatorconvvolume.DisplayMember = "Display";
            fatorconvvolume.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new TDataCombo("0", "0"));
            cbx4.Add(new TDataCombo("10", "10"));
            cbx4.Add(new TDataCombo("100", "100"));
            cbx4.Add(new TDataCombo("1000", "1000"));
            fatorconvunit.DataSource = cbx4;
            fatorconvunit.DisplayMember = "Display";
            fatorconvunit.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new TDataCombo("0", "0"));
            cbx5.Add(new TDataCombo("10", "10"));
            cbx5.Add(new TDataCombo("100", "100"));
            cbx5.Add(new TDataCombo("1000", "1000"));
            fatorconvsubtotal.DataSource = cbx5;
            fatorconvsubtotal.DisplayMember = "Display";
            fatorconvsubtotal.ValueMember = "Value";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (porta_comunicacao.Focused)
                (bsCfgPosto.Current as TRegistro_CfgPosto).Porta_comunicacao = porta_comunicacao.Value;
            return TCN_CfgPosto.Gravar((bsCfgPosto.Current as TRegistro_CfgPosto), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {
            TList_CfgPosto lista = TCN_CfgPosto.Buscar(cd_empresa.Text,
                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgPosto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCfgPosto.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsCfgPosto.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCfgPosto.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            tp_concentrador.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsCfgPosto.Current != null)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CfgPosto.Excluir(bsCfgPosto.Current as TRegistro_CfgPosto, null);
                        bsCfgPosto.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void gCfg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCfg.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCfgPosto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto());
            CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto(lP.Find(gCfg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCfg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto(lP.Find(gCfg.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCfg.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCfgPosto.List as CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto).Sort(lComparer);
            bsCfgPosto.ResetBindings(false);
            gCfg.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_conveniencia_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_conveniencia, nm_conveniencia }, string.Empty);
        }

        private void cd_conveniencia_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_conveniencia.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_conveniencia, nm_conveniencia });
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpDuplicata|Tipo Duplicata|200;" +
                              "TP_Duplicata|Codigo|80;" +
                              "a.CD_Historico_Dup|Cd. Historico|80;" +
                              "e.DS_Historico|Historico|200";
            string vParam = "a.TP_MOV|=|'R'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
            if (linha != null)
            {
                cd_historico.Text = linha["CD_Historico_Dup"].ToString();
                ds_historico.Text = linha["DS_Historico_Dup"].ToString();
            }
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
            if (linha != null)
            {
                cd_historico.Text = linha["CD_Historico_Dup"].ToString();
                ds_historico.Text = linha["DS_Historico_Dup"].ToString();
            }
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_terminal_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_terminal|Terminal|200;" +
                              "a.cd_terminal|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_terminal, ds_terminal },
                new CamadaDados.Diversos.TCD_CadTerminal(), string.Empty);
        }

        private void cd_terminal_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_terminal|=|'" + cd_terminal.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_terminal, ds_terminal },
                new CamadaDados.Diversos.TCD_CadTerminal());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_condpgto|Condição Pagamento|200;" +
                                             "a.cd_condpgto|Código|60",
                                             new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(),
                                             string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_tpduplicataemp_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpDuplicata|Tipo Duplicata|200;" +
                              "TP_Duplicata|Codigo|80;" +
                              "a.CD_Historico_Dup|Cd. Historico|80;" +
                              "e.DS_Historico|Historico|200";
            string vParam = "a.TP_MOV|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicataemp, ds_tpduplicataemp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicataemp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicataemp.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicataemp, ds_tpduplicataemp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdoctoemp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_doctoemp, ds_tpdoctoemp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_doctoemp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_doctoemp.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_doctoemp, ds_tpdoctoemp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }
    }
}
