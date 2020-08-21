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
    public partial class TFLanMedicaoTanque : Form
    {
        public TFLanMedicaoTanque()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_medicao.Clear();
            id_tanque.Clear();
            cd_empresa.Clear();
            cd_funcionario.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFMedicaoTanque fMedicao = new TFMedicaoTanque())
            {
                if(fMedicao.ShowDialog() == DialogResult.OK)
                    if(fMedicao.rMedicao != null)
                        try
                        {
                            if (new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fMedicao.rMedicao.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_afericaoajustaest, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null)
                            {
                                decimal estoque = decimal.Zero;
                                decimal vlmedio = decimal.Zero;
                                //busca local de armazenamento do combustivel do tanque
                                object ob = new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_tanque",
                                        vOperador = "=",
                                        vVL_Busca = fMedicao.rMedicao.Id_tanquestr
                                    }
                                    }, "a.cd_local");
                                // busca a qtd de estoque
                                if (ob != null)
                                    estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(fMedicao.rMedicao.Cd_funcionario,
                                                                                                     fMedicao.rMedicao.Cd_combustivel,
                                                                                                     ob.ToString(), null);
                                if (fMedicao.rMedicao.Qtd_combustivel != estoque)
                                    if (MessageBox.Show("Saldo estoque fisico diferente da medição do tanque.\r\n" +
                                                       $"Saldo fisico atual:{estoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                       $"Quantidade Medição:{fMedicao.rMedicao.Qtd_combustivel.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                       (estoque > fMedicao.rMedicao.Qtd_combustivel ? "Saida:" + (estoque - fMedicao.rMedicao.Qtd_combustivel).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) :
                                                       "Entrada:" + (fMedicao.rMedicao.Qtd_combustivel - estoque).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))) + "\r\n" +
                                                       "Ajustar saldo estoque fisico?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        //busca vl medio
                                        vlmedio = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(fMedicao.rMedicao.Cd_empresa,
                                                                                                               fMedicao.rMedicao.Cd_combustivel,
                                                                                                               null);
                                        fMedicao.rMedicao.rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                                        fMedicao.rMedicao.rEstoque.Cd_empresa = fMedicao.rMedicao.Cd_empresa;
                                        fMedicao.rMedicao.rEstoque.Cd_produto = fMedicao.rMedicao.Cd_combustivel;
                                        fMedicao.rMedicao.rEstoque.Vl_medioestoque = vlmedio;
                                        fMedicao.rMedicao.rEstoque.Cd_local = ob.ToString();
                                        fMedicao.rMedicao.rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                                        fMedicao.rMedicao.rEstoque.St_registro = "A";
                                        fMedicao.rMedicao.rEstoque.Tp_lancto = "M";
                                        if (estoque < fMedicao.rMedicao.Qtd_combustivel)
                                        {
                                            fMedicao.rMedicao.rEstoque.Tp_movimento = "E";
                                            fMedicao.rMedicao.rEstoque.Qtd_entrada = Math.Round(fMedicao.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero);
                                            fMedicao.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(fMedicao.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                        }
                                        else
                                        {
                                            fMedicao.rMedicao.rEstoque.Tp_movimento = "S";
                                            fMedicao.rMedicao.rEstoque.Qtd_saida = Math.Round(estoque - fMedicao.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero);
                                            fMedicao.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(estoque - fMedicao.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                        }
                                        fMedicao.rMedicao.rEstoque.Vl_unitario = vlmedio;
                                    }
                            }
                            CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMedicao.rMedicao, null);
                            MessageBox.Show("Aferição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            id_medicao.Text = fMedicao.rMedicao.Id_medicaostr;
                            LimparFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsMedicao.Current != null)
                using (TFMedicaoTanque fMed = new TFMedicaoTanque())
                {
                    fMed.rMedicao = bsMedicao.Current as CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque;
                    if(fMed.ShowDialog() == DialogResult.OK)
                        if(fMed.rMedicao != null)
                            try
                            {
                                CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMed.rMedicao, null);
                                MessageBox.Show("Aferição alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_medicao.Text = fMed.rMedicao.Id_medicaostr;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsMedicao.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Excluir(bsMedicao.Current as CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque, null);
                        MessageBox.Show("Aferição excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsMedicao.DataSource = CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Buscar(id_medicao.Text,
                                                                                           id_tanque.Text,
                                                                                           cd_empresa.Text,
                                                                                           cd_funcionario.Text,
                                                                                           dt_ini.Text,
                                                                                           dt_fin.Text,
                                                                                           null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanMedicaoTanque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMedicaoTanque);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
            this.pPeriodo.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

        private void bb_tanque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_tanque|Id. Tanque|80;" +
                              "a.cd_produto|Cd. Combustivel|80;" +
                              "e.ds_produto|Combustivel|200;" +
                              "b.nm_empresa|Empresa|200";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{id_tanque},
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel(), "isnull(g.st_lubrificante, 'N')|<>|'S'");
        }

        private void id_tanque_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tanque|=|" + id_tanque.Text + ";isnull(g.st_lubrificante, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tanque },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel());
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

        private void bb_funcionario_Click(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_funcionario }, "a.st_funcionarios|=|'S'");
        }

        private void cd_funcionario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + "';a.st_funcionarios|=|'S'",
                                                    new Componentes.EditDefault[] { cd_funcionario },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFLanMedicaoTanque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gMedicaoTanque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gMedicaoTanque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsMedicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque());
            CamadaDados.PostoCombustivel.TList_MedicaoTanque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gMedicaoTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gMedicaoTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_MedicaoTanque(lP.Find(gMedicaoTanque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gMedicaoTanque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_MedicaoTanque(lP.Find(gMedicaoTanque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gMedicaoTanque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsMedicao.List as CamadaDados.PostoCombustivel.TList_MedicaoTanque).Sort(lComparer);
            bsMedicao.ResetBindings(false);
            gMedicaoTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
        }

        private void TFLanMedicaoTanque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMedicaoTanque);
        }
    }
}
