using CamadaDados.Producao.Producao;
using System;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFLanFormulaApontamento : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanFormulaApontamento()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_formulacao_busca.Clear();
            cd_empresa_busca.Clear();
            ds_formula_busca.Clear();
            ds_indicacao_busca.Clear();
            cd_produto.Clear();
            cd_materiaprima.Clear();
        }

        private void afterNovo()
        {
            using (TFFormulaApontamento fFormula = new TFFormulaApontamento())
            {
                fFormula.Text = "NOVA FORMULA APONTAMENTO PRODUÇÃO";
                if(fFormula.ShowDialog() == DialogResult.OK)
                    if (fFormula.rFormula != null)
                    {
                        try
                        {
                            CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Gravar(fFormula.rFormula, null);
                            MessageBox.Show("Formula Apontamento gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_formulacao_busca.Text = fFormula.rFormula.Id_formulacaostr;
                            cd_empresa_busca.Text = fFormula.rFormula.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        public void afterAltera()
        {
            if (bsFormulaApontamento.Current != null)
                using (TFFormulaApontamento fFormula = new TFFormulaApontamento())
                {
                    fFormula.rFormula = bsFormulaApontamento.Current as TRegistro_FormulaApontamento;
                    fFormula.Text = "ALTERAR FORMULA Nº " + (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Id_formulacaostr;
                    if(fFormula.ShowDialog() == DialogResult.OK)
                        if (fFormula.rFormula != null)
                        {
                            try
                            {
                                CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Gravar(fFormula.rFormula, null);
                                MessageBox.Show("Formula alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    this.LimparFiltros();
                    id_formulacao_busca.Text = fFormula.rFormula.Id_formulacaostr;
                    cd_empresa_busca.Text = fFormula.rFormula.Cd_empresa;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Excluir(bsFormulaApontamento.Current as TRegistro_FormulaApontamento, null);
                        MessageBox.Show("Formula apontamento excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar formula apontamento para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
                
        private void afterBusca()
        {
            bsFormulaApontamento.DataSource = 
                CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar(cd_empresa_busca.Text,
                                                                            id_formulacao_busca.Text,
                                                                            string.Empty,
                                                                            ds_indicacao_busca.Text,
                                                                            ds_formula_busca.Text,
                                                                            cd_produto.Text,
                                                                            cd_materiaprima.Text,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
            bsFormulaApontamento_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsFormulaApontamento.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    (bsFormulaApontamento.DataSource as TList_FormulaApontamento).ForEach(p =>
                        {
                            //Buscar itens materia-prima
                            p.LFichaTec_MPrima =
                                CamadaNegocio.Producao.Producao.TCN_FichaTec_MPrima.Buscar(
                                p.Cd_empresa,
                                p.Id_formulacaostr,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                0,
                                string.Empty,
                                null);
                            //Buscar custo fixo direto
                            p.LCustoFixo =
                                CamadaNegocio.Producao.Producao.TCN_CustoFixo_Direto.Buscar(
                                p.Cd_empresa,
                                p.Id_formulacaostr,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                0,
                                string.Empty,
                                null);
                        });
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsFormulaApontamento;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Ident = "REL_PRD_OrdemProducao";
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
        }

        private void CopiarFormula()
        {
            if (bsFormulaApontamento.Current != null)
                using (TFFormulaApontamento fFormula = new TFFormulaApontamento())
                {
                    fFormula.Text = "COPIA DE FORMULA APONTAMENTO PRODUÇÃO";
                    TRegistro_FormulaApontamento rCopia = new TRegistro_FormulaApontamento();
                    rCopia.Cd_empresa = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_empresa;
                    rCopia.Nm_empresa = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Nm_empresa;
                    rCopia.Ds_formula = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Ds_formula;
                    rCopia.Ds_indicacao = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Ds_indicacao;
                    rCopia.Ds_observacoes = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Ds_observacoes;
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.ForEach(p =>
                        {
                            p.Id_formulacao = null;
                            rCopia.LCustoFixo.Add(p);
                        });
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.ForEach(p =>
                        {
                            p.Id_formulacao = null;
                            rCopia.LFichaTec_MPrima.Add(p);
                        });
                    fFormula.rFormula = rCopia;
                    fFormula.St_copiaFormula = true;
                    if(fFormula.ShowDialog() == DialogResult.OK)
                        if (fFormula.rFormula != null)
                        {
                            try
                            {
                                CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Gravar(fFormula.rFormula, null);
                                MessageBox.Show("Copia formula gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_formulacao_busca.Text = fFormula.rFormula.Id_formulacaostr;
                                cd_empresa_busca.Text = fFormula.rFormula.Cd_empresa;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
        }

        private void VerificarDisponibilidadeMPrima()
        {
            if (bsFormulaApontamento.Current != null)
                using (Proc_Commoditties.TFDisponibilidadeMPrima fDisponibilidade = new Proc_Commoditties.TFDisponibilidadeMPrima())
                {
                    fDisponibilidade.pCd_empresa = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_empresa;
                    fDisponibilidade.pId_formulacao = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Id_formulacaostr;
                    fDisponibilidade.pDs_formula = (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Ds_formula;

                    fDisponibilidade.ShowDialog();
                }
        }

        private void TFLanFormulaApontamento_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, gFormulaApontamento);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltros.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa_busca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_busca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa_busca.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bsFormulaApontamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (((bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_empresa.Trim() != string.Empty) &&
                    ((bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Id_formulacaostr.Trim() != string.Empty))
                {
                    //Buscar itens materia-prima
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima =
                        CamadaNegocio.Producao.Producao.TCN_FichaTec_MPrima.Buscar(
                        (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_empresa,
                        (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Id_formulacaostr,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        0,
                        string.Empty,
                        null);
                    //Buscar custo fixo direto
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo =
                        CamadaNegocio.Producao.Producao.TCN_CustoFixo_Direto.Buscar(
                        (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_empresa,
                        (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Id_formulacaostr,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        0,
                        string.Empty,
                        null);
                    bsFormulaApontamento.ResetCurrentItem();
                }
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLanFormulaApontamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && BB_Imprimir.Visible)
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_materiaprima_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_materiaprima }, string.Empty);
        }

        private void cd_materiaprima_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_materiaprima.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_materiaprima },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void bb_arvore_Click(object sender, EventArgs e)
        {
            if(bsFormulaApontamento.Current != null)
                using (TFArvoreFormula fArvore = new TFArvoreFormula())
                {
                    fArvore.rFormula = bsFormulaApontamento.Current as TRegistro_FormulaApontamento;
                    fArvore.ShowDialog();
                }
        }

        private void bb_copiarformula_Click(object sender, EventArgs e)
        {
            CopiarFormula();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_custoproducao_Click(object sender, EventArgs e)
        {
            VerificarDisponibilidadeMPrima();
        }

        private void TFLanFormulaApontamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, gFormulaApontamento);
        }
    }
}
