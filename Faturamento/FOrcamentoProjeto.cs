using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFOrcamentoProjeto : Form
    {
        private CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rorcamento;
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rOrcamento
        {
            get
            {
                if (bsOrcamento.Current != null)
                    return bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento;
                else
                    return null;
            }
            set
            { rorcamento = value; }
        }

        public TFOrcamentoProjeto()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ABERTO", "AB"));
            cbx.Add(new Utils.TDataCombo("AGUARDANDO RETORNO", "AR"));
            cbx.Add(new Utils.TDataCombo("REPROVADO", "RE"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";
        }

        private void CalcularDtValidade()
        {
            if (bsOrcamento.Current != null)
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Dt_validade == null)
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.CalcularDtValidade(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                    bsOrcamento.ResetCurrentItem();
                }
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
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
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(CD_Endereco.Text))
                    {
                        CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                        DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                        DS_Cidade.Text = List_Endereco[0].DS_Cidade.Trim();
                        UF.Text = List_Endereco[0].UF.Trim();
                        Fone.Text = List_Endereco[0].Fone.Trim();
                    }
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar orçamento sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirItem()
        {
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                using (TFItensOrcProjeto fItem = new TFItensOrcProjeto())
                {
                    fItem.pCd_empresa = CD_Empresa.Text;
                    fItem.pNm_empresa = NM_Empresa.Text;
                    if(fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rItem != null)
                        {
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Add(fItem.rItem);
                            bsOrcamento.ResetCurrentItem();
                            tslTotal.Text = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        }
                }
            else MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarItem()
        {
            if (bsItens.Current != null)
            {
                using (TFItensOrcProjeto fItem = new TFItensOrcProjeto())
                {
                    fItem.rItem = bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                    fItem.pCd_empresa = CD_Empresa.Text;
                    fItem.pNm_empresa = NM_Empresa.Text;

                    CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item rCopia = new CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item();
                    rCopia.Cd_produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto;
                    rCopia.Ds_produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_produto;
                    rCopia.Cd_unid_produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_unid_produto;
                    rCopia.Ds_observacao = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_observacao;
                    rCopia.Ds_unid_produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_unid_produto;
                    rCopia.Id_item = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Id_item;
                    rCopia.Nr_orcamento = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento;
                    rCopia.Pc_desconto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Pc_desconto;
                    rCopia.Quantidade = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade;
                    rCopia.Sigla_unid_produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Sigla_unid_produto;
                    rCopia.Vl_desconto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_desconto;
                    rCopia.Vl_frete = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_frete;
                    rCopia.Vl_subtotal = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_subtotal;
                    rCopia.Vl_unitario = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario;
                    rCopia.Vl_custo = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_custo;

                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto = rCopia.Cd_produto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_produto = rCopia.Ds_produto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_unid_produto = rCopia.Cd_unid_produto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_observacao = rCopia.Ds_observacao;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_unid_produto = rCopia.Ds_unid_produto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Id_item = rCopia.Id_item;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento = rCopia.Nr_orcamento;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Pc_desconto = rCopia.Pc_desconto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade = rCopia.Quantidade;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Sigla_unid_produto = rCopia.Sigla_unid_produto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_desconto = rCopia.Vl_desconto;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_frete = rCopia.Vl_frete;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_subtotal = rCopia.Vl_subtotal;
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario = rCopia.Vl_unitario;
                    }
                    tslTotal.Text = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                };
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                {
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItensDel.Add(
                        bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item);
                    bsItens.RemoveCurrent();
                    tslTotal.Text = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
        }

        private void TFOrcamentoProjeto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (this.rorcamento != null)
            {
                bsOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { this.rorcamento };
                tslTotal.Text = rorcamento.lItens.Sum(p => p.Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                CD_Empresa.Focus();
            }
            else
            {
                bsOrcamento.AddNew();
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_orcprojeto = "S";
                CD_Empresa.Focus();
                //Buscar vendedor do login
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lVend =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.BuscaVendedor(string.Empty,
                                                                               Utils.Parametros.pubLogin,
                                                                               null);
                if (lVend.Count > 0)
                {
                    CD_CompVend.Text = lVend[0].Cd_clifor;
                    NM_CompVend.Text = lVend[0].Nm_clifor;
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
            this.CalcularDtValidade();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
            this.CalcularDtValidade();
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor=|'" + CD_CompVend.Text.Trim() + "'isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1");
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";

            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParam);
            CD_Endereco.Clear();
            DS_Endereco.Clear();
            DS_Cidade.Clear();
            UF.Text = string.Empty;
            Fone.Clear();
            Busca_Endereco_Clifor();
            bsOrcamento.ResetCurrentItem();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'";
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1");
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            CD_Endereco.Clear();
            DS_Endereco.Clear();
            DS_Cidade.Clear();
            UF.Text = string.Empty;
            Fone.Clear();
            Busca_Endereco_Clifor();
            bsOrcamento.ResetCurrentItem();
        }

        private void CD_Clifor_TextChanged(object sender, EventArgs e)
        {
            NM_Clifor.Enabled = string.IsNullOrEmpty(CD_Clifor.Text);
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        DS_Cidade.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        UF.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void DT_Pedido_Leave(object sender, EventArgs e)
        {
            this.CalcularDtValidade();
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                       , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
            if (linha != null)
            {
                Fone.Text = linha["fone"].ToString();
                UF.Text = linha["UF"].ToString();
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                                    , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (linha != null)
            {
                Fone.Text = linha["fone"].ToString();
                UF.Text = linha["UF"].ToString();
            }
        }

        private void CD_Endereco_TextChanged(object sender, EventArgs e)
        {
            DS_Endereco.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            DS_Cidade.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            UF.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            Fone.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFOrcamentoProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_vendedor",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                    }
                }, "1") != null)
                vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                         "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                         "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                       , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                       new CamadaDados.Diversos.TCD_CadTbPreco(),
                                       vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_vendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                    }
                                }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }
    }
}
