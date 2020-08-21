using CamadaDados.Producao.Producao;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFFormulaApontamento : Form
    {
        public bool St_copiaFormula { get; set; }
        private TRegistro_FormulaApontamento rformula;
        public TRegistro_FormulaApontamento rFormula
        {
            get
            {
                if (bsFormulaApontamento.Current != null)
                    return bsFormulaApontamento.Current as TRegistro_FormulaApontamento;
                else
                    return null;
            }
            set { rformula = value; }
        }

        public TFFormulaApontamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pFormulaApontamento.validarCampoObrigatorio())
            {
                if (bsFichaTec_MPrima.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar ficha tecnica sem informar materia prima.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void afterInserirMPrima()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                using (TFLanFichaTec_MPrima fFichaTec_MPrima = new TFLanFichaTec_MPrima())
                {
                    fFichaTec_MPrima.Cd_empresa = CD_Empresa.Text;
                    if (fFichaTec_MPrima.ShowDialog() == DialogResult.OK)
                        if (fFichaTec_MPrima.FichaTec_MPrima != null)
                        {
                            //Se existir um registro para o produto, exclui
                            if ((bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.Exists(p => p.Cd_produto.Trim().Equals(fFichaTec_MPrima.FichaTec_MPrima.Cd_produto.Trim())))
                            {
                                if (MessageBox.Show("Este item ja se encontra na lista de materias-primas.\r\n" +
                                                   "Deseja ignorar o registro antigo e inserir o novo?",
                                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                   == DialogResult.Yes)
                                {
                                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.RemoveAll(p => p.Cd_produto.Trim().Equals(fFichaTec_MPrima.FichaTec_MPrima.Cd_produto.Trim()));
                                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.Add(fFichaTec_MPrima.FichaTec_MPrima);
                                    bsFormulaApontamento.ResetCurrentItem();
                                }
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.Add(fFichaTec_MPrima.FichaTec_MPrima);
                                bsFormulaApontamento.ResetCurrentItem();
                            }
                        }
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarMPrima()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                if (bsFichaTec_MPrima.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar item materia-prima para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLanFichaTec_MPrima fFichaTec_MPrima = new TFLanFichaTec_MPrima())
                {
                    fFichaTec_MPrima.St_altera = true;
                    fFichaTec_MPrima.Cd_empresa = CD_Empresa.Text;
                    fFichaTec_MPrima.FichaTec_MPrima = (bsFichaTec_MPrima.Current as TRegistro_FichaTec_MPrima);
                    if (fFichaTec_MPrima.ShowDialog() == DialogResult.OK)
                        if (fFichaTec_MPrima.FichaTec_MPrima != null)
                        {
                            //Excluir o registro existente
                            (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.RemoveAll(p => p.Cd_produto.Trim().Equals(fFichaTec_MPrima.FichaTec_MPrima.Cd_produto.Trim()));
                            //Acrescentar o novo registro
                            (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.Add(fFichaTec_MPrima.FichaTec_MPrima);
                            bsFormulaApontamento.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluiMPrima()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                if (bsFichaTec_MPrima.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar item materia-prima para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Matéria-prima selecionada: " + (bsFichaTec_MPrima.Current as TRegistro_FichaTec_MPrima).Cd_produto.Trim() + "-" +
                                                                (bsFichaTec_MPrima.Current as TRegistro_FichaTec_MPrima).Ds_produto.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrimaDel.Add(
                        bsFichaTec_MPrima.Current as TRegistro_FichaTec_MPrima);
                    //Excluir item do grid
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LFichaTec_MPrima.Remove(
                        bsFichaTec_MPrima.Current as TRegistro_FichaTec_MPrima);
                    bsFormulaApontamento.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterInserirCustoFixo()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                using (TFLanCustoFixoDireto fCustoFixoDireto = new TFLanCustoFixoDireto())
                {
                    fCustoFixoDireto.Cd_empresa = CD_Empresa.Text;
                    if (fCustoFixoDireto.ShowDialog() == DialogResult.OK)
                        if (fCustoFixoDireto.CustoFixoDireto != null)
                        {
                            //Se existir um registro para o produto, exclui
                            if ((bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.Exists(p => p.Id_custostr.Trim().Equals(fCustoFixoDireto.CustoFixoDireto.Id_custostr.Trim())))
                            {
                                if (MessageBox.Show("Este item ja se encontra na lista de custo fixo direto.\r\n" +
                                                   "Deseja ignorar o registro antigo e inserir o novo?",
                                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                   == DialogResult.Yes)
                                {
                                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.RemoveAll(p => p.Id_custostr.Trim().Equals(fCustoFixoDireto.CustoFixoDireto.Id_custostr.Trim()));
                                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.Add(fCustoFixoDireto.CustoFixoDireto);
                                    bsFormulaApontamento.ResetCurrentItem();
                                }
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.Add(fCustoFixoDireto.CustoFixoDireto);
                                bsFormulaApontamento.ResetCurrentItem();
                            }
                        }
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarCustoFixo()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                if (bsCustoFixo.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar custo fixo para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLanCustoFixoDireto fCustoFixo = new TFLanCustoFixoDireto())
                {
                    fCustoFixo.St_altera = true;
                    fCustoFixo.Cd_empresa = CD_Empresa.Text;
                    fCustoFixo.CustoFixoDireto = (bsCustoFixo.Current as TRegistro_CustoFixo_Direto);
                    if (fCustoFixo.ShowDialog() == DialogResult.OK)
                        if (fCustoFixo.CustoFixoDireto != null)
                        {
                            //Excluir o registro existente
                            (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.RemoveAll(p => p.Id_custostr.Trim().Equals(fCustoFixo.CustoFixoDireto.Id_custostr.Trim()));
                            //Acrescentar o novo registro
                            (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.Add(fCustoFixo.CustoFixoDireto);
                            bsFormulaApontamento.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluiCustoFixo()
        {
            if (bsFormulaApontamento.Current != null)
            {
                if (CD_Empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                if (bsCustoFixo.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar custo fixo para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Custo fixo selecionado: " + (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Cd_produto.Trim() + "-" +
                                                                (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).Ds_produto.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixoDel.Add(
                        bsCustoFixo.Current as TRegistro_CustoFixo_Direto);
                    //Excluir item do grid
                    (bsFormulaApontamento.Current as TRegistro_FormulaApontamento).LCustoFixo.Remove(
                        bsCustoFixo.Current as TRegistro_CustoFixo_Direto);
                    bsFormulaApontamento.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe registro de apontamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void btn_Inserir_ItemMPrima_Click(object sender, EventArgs e)
        {
            this.afterInserirMPrima();
        }

        private void BB_Alterar_ItemMPrima_Click(object sender, EventArgs e)
        {
            afterAlterarMPrima();
        }

        private void btn_Deleta_ItemMPrima_Click(object sender, EventArgs e)
        {
            afterExcluiMPrima();
        }
        
        private void tsbInserirItem_CFixo_Click(object sender, EventArgs e)
        {
            afterInserirCustoFixo();
        }

        private void tsbAlterarItem_CFixo_Click(object sender, EventArgs e)
        {
            afterAlterarCustoFixo();
        }

        private void tsbDeletarItem_CFixo_Click(object sender, EventArgs e)
        {
            afterExcluiCustoFixo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFFormulaApontamento_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault4);
            ShapeGrid.RestoreShape(this, dataGridDefault5);
            ShapeGrid.RestoreShape(this, gCustoFixo);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFormulaApontamento.set_FormatZero();
            if (rformula != null)
            {
                bsFormulaApontamento.DataSource = new TList_FormulaApontamento() { rformula };
                CD_Empresa.Enabled = St_copiaFormula;
                BB_Empresa.Enabled = St_copiaFormula;
                ds_formula.Focus();
            }
            else
            {
                bsFormulaApontamento.AddNew();
                CD_Empresa.Focus();
            }
        }

        private void TFFormulaApontamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
            {
                if (tcDetalhes.SelectedTab.Equals(tpFichaTec_MPrima))
                    afterInserirMPrima();
                else if (tcDetalhes.SelectedTab.Equals(tpCustoFixo))
                    afterInserirCustoFixo();
            }
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
            {
                if (tcDetalhes.SelectedTab.Equals(tpFichaTec_MPrima))
                    afterAlterarMPrima();
                else if (tcDetalhes.SelectedTab.Equals(tpCustoFixo))
                    afterAlterarCustoFixo();
            }
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
            {
                if (tcDetalhes.SelectedTab.Equals(tpFichaTec_MPrima))
                    afterExcluiMPrima();
                else if (tcDetalhes.SelectedTab.Equals(tpCustoFixo))
                    afterExcluiCustoFixo();
            }
        }

        private void TFFormulaApontamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault4);
            ShapeGrid.SaveShape(this, dataGridDefault5);
            ShapeGrid.SaveShape(this, gCustoFixo);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.ST_Industrializado, 'N')|=|'S'");
            cd_unidade.Text = linha?["cd_unidade"].ToString();
            ds_unidade.Text = linha?["ds_unidade"].ToString();
            sigla_unidade.Text = linha?["sigla_unidade"].ToString();
            if (string.IsNullOrEmpty(ds_formula.Text))
                ds_formula.Text = linha?["ds_produto"].ToString();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.ST_Industrializado, 'N')|=|'S'",
                            new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            cd_unidade.Text = linha?["cd_unidade"].ToString();
            ds_unidade.Text = linha?["ds_unidade"].ToString();
            sigla_unidade.Text = linha?["sigla_unidade"].ToString();
            if (string.IsNullOrEmpty(ds_formula.Text))
                ds_formula.Text = linha?["ds_produto"].ToString();
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|150;" +
                              "a.cd_unidade|Código|50;" +
                              "a.sigla_unidade|UN";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidade, ds_unidade, sigla_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Código|50";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }
    }
}
