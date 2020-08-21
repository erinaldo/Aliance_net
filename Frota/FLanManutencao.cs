using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFLanManutencao : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanManutencao()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_manutencao.Clear();
            cd_empresa.Clear();
            id_veiculo.Clear();
            id_viagem.Clear();
            id_despesa.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFManutencao fManut = new TFManutencao())
            {
                if (fManut.ShowDialog() == DialogResult.OK)
                    if (fManut.rManutencao != null)
                    {
                        if (!fManut.st_consumointerno && !string.IsNullOrEmpty(fManut.rManutencao.Cd_cliforOficina))
                        {
                            //Buscar config abast
                            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fManut.rManutencao.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                {
                                    fDup.vCd_empresa = fManut.rManutencao.Cd_empresa;
                                    fDup.vNm_empresa = fManut.rManutencao.Nm_empresa;
                                    fDup.vCd_clifor = fManut.rManutencao.Cd_cliforOficina;
                                    fDup.vNm_clifor = fManut.rManutencao.Nm_cliforOficina;
                                    //Buscar endereco clifor oficina
                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fManut.rManutencao.Cd_cliforOficina,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  1,
                                                                                                  null);
                                    if (lEnd.Count > 0)
                                    {
                                        fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                        fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                    }
                                    if (lCfg.Count > 0)
                                    {
                                        fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                        fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                        fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                        fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                        fDup.vTp_mov = "P";
                                        fDup.vCd_historico = lCfg[0].Cd_historico;
                                        fDup.vDs_historico = lCfg[0].Ds_historico;
                                        fDup.vDt_emissao = fManut.rManutencao.Dt_realizadastr;
                                        fDup.vVl_documento = fManut.rManutencao.Vl_realizada;
                                        fDup.vNr_docto = fManut.rManutencao.Nr_notafiscal;
                                        fDup.vSt_ecf = true;
                                        if (fDup.ShowDialog() == DialogResult.OK)
                                            if (fDup.dsDuplicata.Count > 0)
                                                fManut.rManutencao.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    }
                                }
                        }
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(fManut.rManutencao, null);

                            MessageBox.Show("Manutenção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_manutencao.Text = fManut.rManutencao.Id_manutencaostr;
                            id_veiculo.Text = fManut.rManutencao.Id_veiculostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterNovoC()
        {
            using (TFDespComposta fDesp = new TFDespComposta())
            {
                if (fDesp.ShowDialog() == DialogResult.OK)
                {
                    if (fDesp.lManutencao != null)
                    {
                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = null;
                        //Buscar config abast
                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fDesp.lManutencao[0].Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                        {
                            fDup.vCd_empresa = fDesp.lManutencao[0].Cd_empresa;
                            fDup.vNm_empresa = fDesp.lManutencao[0].Nm_empresa;
                            fDup.vCd_clifor = fDesp.lManutencao[0].Cd_cliforOficina;
                            fDup.vNm_clifor = fDesp.lManutencao[0].Nm_cliforOficina;
                            //Buscar endereco clifor oficina
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fDesp.lManutencao[0].Cd_cliforOficina,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          null);
                            if (lEnd.Count > 0)
                            {
                                fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                fDup.vDs_endereco = lEnd[0].Ds_endereco;
                            }
                            if (lCfg.Count > 0)
                            {
                                if (string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                {
                                    MessageBox.Show("Não existe Tp.duplicata na CFG.Frota cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                fDup.vTp_mov = "P";
                                fDup.vCd_historico = lCfg[0].Cd_historico;
                                fDup.vDs_historico = lCfg[0].Ds_historico;
                                fDup.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                fDup.vVl_documento = (fDesp.lManutencao as IEnumerable<CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo>)
                                    .ToList().Sum(x => x.Vl_realizada);
                                fDup.vNr_docto = "AGPDESP"; //agrupamento despesas
                                fDup.vSt_ecf = true;
                                fDup.St_bloquearccusto = true; //Centro Resultado sera lancado pelo modulo frota
                                if (fDup.ShowDialog() == DialogResult.OK)
                                {
                                    if (fDup.dsDuplicata.Count > 0)
                                    {
                                        rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                        rDup.Vl_documento_padrao = (fDesp.lManutencao as IEnumerable<CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo>)
                                            .ToList().Sum(x => x.Vl_realizada);
                                        rDup.Parcelas[0].Vl_parcela_padrao = rDup.Parcelas[0].Vl_parcela;
                                    }
                                }
                                else
                                    return;
                            }
                            else
                            {
                                MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(fDesp.lManutencao, rDup, null);
                            MessageBox.Show("Manutenção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_manutencao.Text = fDesp.lManutencao[0].Id_manutencaostr;
                            id_veiculo.Text = fDesp.lManutencao[0].Id_veiculostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void afterAltera()
        {
            if (bsManutencao.Current != null)
            {
                //Verificar se TP.Despesa é Manutenção Interna
                if (new CamadaDados.Frota.Cadastros.TCD_Despesa().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_despesa",
                            vOperador = "=",
                            vVL_Busca = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_despesastr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.TP_Despesa",
                            vOperador = "<>",
                            vVL_Busca = "'MI'"
                        }
                    }, "1") != null)
                {
                    using (TFManutencao fManut = new TFManutencao())
                    {
                        fManut.rManutencao = bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo;
                        if (fManut.ShowDialog() == DialogResult.OK)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(fManut.rManutencao, null);
                                MessageBox.Show("Manutenção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                id_manutencao.Text = fManut.rManutencao.Id_manutencaostr;
                                id_veiculo.Text = fManut.rManutencao.Id_veiculostr;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                    MessageBox.Show("Não é permitido alterar Despesas de Movimentação Interna!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterExclui()
        {
            if (bsManutencao.Current != null)
            {
                CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo lManutencao =
                    new CamadaDados.Frota.Cadastros.TCD_ManutencaoVeiculo().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Nr_lanctostr + "' "
                            }
                        }, 0, string.Empty);
                if (lManutencao.Count > 1)
                {
                    //Exclusão de manutenção composta
                    if (MessageBox.Show("Este registro faz parte de um lançamento composto de despesas, relacionados a uma duplicata, deseja excluir todos registros?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Excluir(lManutencao, null);
                            MessageBox.Show("Despesas/Manutenções excluídas com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    //Exclusão de manutenção avulsa
                    if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Excluir(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo, null);
                            this.LimparFiltros();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

        }

        private void afterBusca()
        {
            bsManutencao.DataSource = CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Buscar(id_veiculo.Text,
                                                                                                 id_manutencao.Text,
                                                                                                 id_despesa.Text,
                                                                                                 id_viagem.Text,
                                                                                                 cd_empresa.Text,
                                                                                                 string.Empty,
                                                                                                 cd_oficina.Text,
                                                                                                 dt_ini.Text,
                                                                                                 dt_fin.Text,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 null);
            tot_realizado.Value = (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Sum(p => p.Vl_realizada);
            bsManutencao_PositionChanged(this, new EventArgs());
        }

        private void Print()
        {
            if (bsManutencao.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsManutencao;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLanManutencao";
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
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void TFLanManutencao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Viagem|200;" +
                              "a.id_viagem|Id. Viagem|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem },
                                             new CamadaDados.Frota.TCD_Viagem(), string.Empty);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|" + id_viagem.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem },
                                            new CamadaDados.Frota.TCD_Viagem());
        }

        private void cd_oficina_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_oficina.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_oficina },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_oficina_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_oficina }, string.Empty);
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Id. Despesa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(),
                                            string.Empty);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Novo_C_Click(object sender, EventArgs e)
        {
            this.afterNovoC();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void TFLanManutencao_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void gManutencao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gManutencao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsManutencao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo());
            CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo(lP.Find(gManutencao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gManutencao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo(lP.Find(gManutencao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gManutencao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Sort(lComparer);
            bsManutencao.ResetBindings(false);
            gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gManutencao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("REALIZADA"))
                        gManutencao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else
                        gManutencao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bsManutencao_PositionChanged(object sender, EventArgs e)
        {
            if (bsManutencao.Current != null)
            {
                (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lMov =
                    new CamadaDados.Almoxarifado.TCD_Movimentacao().Select(
                     new Utils.TpBusca[]
                     {
                         new Utils.TpBusca()
                         {
                             vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FRT_Manut_X_Almox x " +
                                        "where x.id_movimento = a.id_movimento " +
                                        "and x.id_veiculo = " + (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_veiculostr + " " +
                                        "and x.id_manutencao = " + (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_manutencaostr + ")"
                         }
                     }, 0, string.Empty);

                // Busca duplica do registro selecionado
                (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lDup =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                        new Utils.TpBusca[]
                        {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.Nr_Lancto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Nr_lanctostr + "' "
                                }
                        }, 0, string.Empty);



                bsDup_PositionChanged(this, new EventArgs());
                bsManutencao.ResetCurrentItem();
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

    }
}
