using System;
using System.ComponentModel;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFCadCfgFrota : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgFrota()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("COMPANYTEC", "CT"));
            cbx.Add(new Utils.TDataCombo("GILBARCO", "GB"));
            cbx.Add(new Utils.TDataCombo("VWTECH", "VW"));
            tp_concentrador.DataSource = cbx;
            tp_concentrador.DisplayMember = "Display";
            tp_concentrador.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PRODUÇÃO", "1"));
            cbx1.Add(new Utils.TDataCombo("HOMOLOGAÇÃO", "2"));
            tp_ambiente.DataSource = cbx1;
            tp_ambiente.ValueMember = "Value";
            tp_ambiente.DisplayMember = "Display";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("REMETENTE", "0"));
            cbx2.Add(new Utils.TDataCombo("EXPEDIDOR", "1"));
            cbx2.Add(new Utils.TDataCombo("RECEBEDOR", "2"));
            cbx2.Add(new Utils.TDataCombo("DESTINATARIO", "3"));
            tp_tomadordef.DataSource = cbx2;
            tp_tomadordef.DisplayMember = "Display";
            tp_tomadordef.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("SVC-SÃO PAULO", "SP"));
            cbx4.Add(new Utils.TDataCombo("SVC-RIO GRANDE DO SUL", "RS"));
            tp_ambientecont.DataSource = cbx4;
            tp_ambientecont.DisplayMember = "Display";
            tp_ambientecont.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new Utils.TDataCombo("METROS CUBICOS", "00"));
            cbx5.Add(new Utils.TDataCombo("QUILOGRAMA", "01"));
            cbx5.Add(new Utils.TDataCombo("TONELADA", "02"));
            cbx5.Add(new Utils.TDataCombo("UNIDADE", "03"));
            cbx5.Add(new Utils.TDataCombo("LITROS", "04"));
            cbx5.Add(new Utils.TDataCombo("MMBTU", "05"));
            tp_unidfrete.DataSource = cbx5;
            tp_unidfrete.DisplayMember = "Display";
            tp_unidfrete.ValueMember = "Value";

            System.Collections.ArrayList cbx6 = new System.Collections.ArrayList();
            cbx6.Add(new Utils.TDataCombo("CTE", "0"));
            cbx6.Add(new Utils.TDataCombo("OUTRAS RECEITAS", "1"));
            cbx6.Add(new Utils.TDataCombo("TODAS", "2"));
            St_recApuracao.DataSource = cbx6;
            St_recApuracao.DisplayMember = "Display";
            St_recApuracao.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CfgFrota.Gravar(bsCfgFrota.Current as TRegistro_CfgFrota, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CfgFrota lista = TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                       cd_produto.Text,
                                                       cd_localarm.Text,
                                                       id_despesa.Text,
                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgFrota.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgFrota.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCfgFrota.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            Cd_terminal.Focus();
            bb_empresa.Enabled = false;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgFrota.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CfgFrota.Excluir(bsCfgFrota.Current as TRegistro_CfgFrota, null);
                    bsCfgFrota.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gCfgFrota_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCfgFrota.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCfgFrota.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CfgFrota());
            TList_CfgFrota lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCfgFrota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCfgFrota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CfgFrota(lP.Find(gCfgFrota.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCfgFrota.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CfgFrota(lP.Find(gCfgFrota.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCfgFrota.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCfgFrota.List as TList_CfgFrota).Sort(lComparer);
            bsCfgFrota.ResetBindings(false);
            gCfgFrota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            FormBusca.UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80",
                new Componentes.EditDefault[] { cd_localarm, ds_localarm },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text),
                "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_localarm_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            string vParam = "a.cd_local|=|'" + cd_localarm.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam,
                                    new Componentes.EditDefault[] { cd_localarm, ds_localarm },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text));
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                                new TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa }, new TCD_Despesa());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|Codigo|80";
            string vParam = "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
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

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Codigo|80";
            string vParam = "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_terminal_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_terminal|Descrição|200;" +
                              "a.cd_terminal|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_terminal, Ds_terminal },
                                            new CamadaDados.Diversos.TCD_CadTerminal(), string.Empty);
        }

        private void Cd_terminal_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_terminal|=|" + Cd_terminal.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_terminal, Ds_terminal },
                                            new CamadaDados.Diversos.TCD_CadTerminal());
        }

        private void bb_historicodesp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Codigo|80";
            string vParam = "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicodesp, ds_historicodesp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historicodesp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historicodesp.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historicodesp, ds_historicodesp },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                           ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                           "where k.CD_ContaGer = a.CD_ContaGer " +
                           "and k.cd_Empresa = '" + cd_empresa.Text + "')";


            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vCond = "a.CD_ContaGer|=|'" + cd_contager.Text.Trim() + "';" +
                           "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')" +
                           ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                           "where k.CD_ContaGer = a.CD_ContaGer " +
                           "and k.cd_Empresa = '" + cd_empresa.Text + "')";

            FormBusca.UtilPesquisa.EDIT_LEAVE(vCond, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_pathschemas_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    path_schemas.Text = fbdPath.SelectedPath.Trim();
            }
        }

        private void bb_movcte_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Movimentacao|Movimentação Comercial|200;" +
                              "a.CD_Movimentacao|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movcte, ds_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), "a.TP_Movimento|=|'S'");
        }

        private void cd_movcte_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movcte.Text + ";" +
                            "a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movcte, ds_movimentacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_serienf|Serie CTe|150;" +
                              "a.nr_serie|Nº Serie|80;" +
                              "a.cd_modelo|Modelo CTe|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_seriecte, ds_serie, cd_modelocte },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), "a.cd_modelo|=|'57'");
        }

        private void nr_seriecte_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_seriecte.Text.Trim() + "';" +
                            "a.cd_modelo|=|'57'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_seriecte, ds_serie, cd_modelocte },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_movanulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Movimentacao|Movimentação Comercial|200;" +
                              "a.CD_Movimentacao|Codigo|80";
            string vParam = "a.TP_Movimento|=|'E'";
            if (!string.IsNullOrEmpty(cd_cmianulacao.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_movimentacao = a.cd_movimentacao " +
                          "and x.cd_cmi = " + cd_cmianulacao.Text + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movanulacao, ds_movanulacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), vParam);
        }

        private void cd_movanulacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movanulacao.Text + ";" +
                            "a.tp_movimento|=|'E'";
            if (!string.IsNullOrEmpty(cd_cmianulacao.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_movimentacao = a.cd_movimentacao " +
                          "and x.cd_cmi = " + cd_cmianulacao.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movanulacao, ds_movanulacao },
                new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_cmianulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cmi|CMI|200;" +
                               "a.cd_cmi|Codigo|60";
            string vParam = "a.tp_movimento|=|'E'";
            if (!string.IsNullOrEmpty(cd_movanulacao.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_cmi = a.cd_cmi " +
                          "and x.cd_movimentacao = " + cd_movanulacao.Text + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cmianulacao, ds_cmianulacao },
                new CamadaDados.Fiscal.TCD_CadCMI(), vParam);
        }

        private void cd_cmianulacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cmi|=|" + cd_cmianulacao.Text + ";" +
                            "a.tp_movimento|=|'E'";
            if (!string.IsNullOrEmpty(cd_movanulacao.Text))
                vParam += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                          "where x.cd_cmi = a.cd_cmi " +
                          "and x.cd_movimentacao = " + cd_movanulacao.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cmianulacao, ds_cmianulacao },
                new CamadaDados.Fiscal.TCD_CadCMI());
        }

        private void bb_movcteuf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Movimentacao|Movimentação Comercial|200;" +
                              "a.CD_Movimentacao|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movcteuf, ds_movcteuf },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), "a.TP_Movimento|=|'S'");
        }

        private void cd_movcteuf_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movcteuf.Text + ";" +
                            "a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movcteuf, ds_movcteuf },
                new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void TFCadCfgFrota_Load(object sender, EventArgs e)
        {
            ds_condusoCCe.CharacterCasing = CharacterCasing.Normal;
        }
    }
}
