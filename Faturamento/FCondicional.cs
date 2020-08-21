using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFCondicional : Form
    {
        public bool Altera_Relatorio = false;
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg;

        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Tp_movimento
        { get; set; }

        private TRegistro_Condicional rcond;
        public TRegistro_Condicional rCond
        {
            get
            {
                if (bsCondicional.Current != null)
                    return bsCondicional.Current as TRegistro_Condicional;
                else
                    return null;
            }
            set { rcond = value; }
        }

        public TFCondicional()
        {
            InitializeComponent();

            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Tp_movimento = string.Empty;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (Quantidade.Focused)
                    Quantidade_Leave(this, new EventArgs());
                if (bsItens.Count.Equals(0))
                {
                    MessageBox.Show("Não é permitido gravar condicional sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsItens.Current as TRegistro_ItensCondicional).Quantidade.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não é possivel gravar itens sem quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TCN_Condicional.Gravar(bsCondicional.Current as TRegistro_Condicional, null);
                    DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bsItens.RemoveCurrent();
                    TotalizarVenda();
                }
            else
                MessageBox.Show("Não existe item selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
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
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void BuscarProduto()
        {
            if (string.IsNullOrEmpty(cd_produto.Text))
                FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                     cd_empresa.Text,
                                                     nm_empresa.Text,
                                                     CD_TabelaPreco.Text,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                     cd_empresa.Text,
                                                     nm_empresa.Text,
                                                     CD_TabelaPreco.Text,
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     null);
            if (BuscarItens())
            {
                cd_produto.Clear();
                Quantidade.Focus();
            }
            else
            {
                MessageBox.Show("Produto inexistente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Clear();
                cd_produto.Focus();
            }
        }

        private bool BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                string pCd_codbarra = cd_produto.Text;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (cd_produto.Text.Trim().Length < lParam[0].Tamanho)
                        cd_produto.Text = cd_produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cd_produto.Text,
                                                                                            pCd_codbarra,
                                                                                            null);

                if (lProduto.Count > 0)
                {
                    if (lCfg[0].St_movestoquebool)
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto))
                            {
                                decimal saldo = BuscarSaldoLocal(lProduto[0].CD_Produto);
                                if (saldo < Quantidade.Value)
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + cd_empresa.Text.Trim() + "-" + nm_empresa.Text.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                            else
                            {
                                //Buscar ficha tecnica produto composto
                                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(lProduto[0].CD_Produto, string.Empty, null);
                                lFicha.ForEach(p => p.Quantidade = p.Quantidade * Quantidade.Value);
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                //Buscar saldo itens da ficha tecnica
                                string msg = string.Empty;
                                lFicha.ForEach(p =>
                                {
                                    //Buscar saldo estoque do item
                                    decimal saldo = decimal.Zero;
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(cd_empresa.Text, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                    if (saldo < p.Quantidade)
                                        msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                               "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                });
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                    //Cria novo item
                    bsItens.AddNew();
                    (bsItens.Current as TRegistro_ItensCondicional).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as TRegistro_ItensCondicional).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as TRegistro_ItensCondicional).Cd_condfiscal_produto = lProduto[0].CD_CondFiscal_Produto;
                    (bsItens.Current as TRegistro_ItensCondicional).Cd_unidade = lProduto[0].CD_Unidade;
                    (bsItens.Current as TRegistro_ItensCondicional).Sigla_unidade = lProduto[0].Sigla_unidade;
                    (bsItens.Current as TRegistro_ItensCondicional).Cd_local = lCfg[0].Cd_local;
                    (bsItens.Current as TRegistro_ItensCondicional).Quantidade = Quantidade.Value;
                    (bsItens.Current as TRegistro_ItensCondicional).Vl_unitario = ConsultaPreco(lProduto[0].CD_Produto);
                    vl_unit.Enabled = vl_unit.Value.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    TotalizarVenda();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private decimal BuscarSaldoLocal(string Cd_produto)
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(Cd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(cd_empresa.Text,
                                                                       Cd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(cd_empresa.Text,
                                                                                            vCd_produto,
                                                                                            CD_TabelaPreco.Text,
                                                                                            null);
            else
                return decimal.Zero;
        }

        private void TotalizarVenda()
        {
            if (bsCondicional.Current != null)
                tot_condicional.Value = (bsCondicional.Current as TRegistro_Condicional).lItens.Sum(p => p.Vl_subtotal);
        }

        private void TFCondicional_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar config pdv para a empresa
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Cd_empresa, null);
            if (lCfg.Count > 0)
            {
                if (rcond == null)
                {
                    bsCondicional.AddNew();
                    if (Tp_movimento.Trim().ToUpper().Equals("E"))
                        tp_movimento.SelectedIndex = 0;
                    else if (Tp_movimento.Trim().ToUpper().Equals("S"))
                        tp_movimento.SelectedIndex = 1;
                    cd_empresa.Text = Cd_empresa;
                    nm_empresa.Text = Nm_empresa;
                    cd_clifor.Text = lCfg[0].Cd_clifor;
                    nm_clifor.Text = lCfg[0].Nm_clifor;
                    cd_endereco.Text = lCfg[0].Cd_endereco;
                    ds_endereco.Text = lCfg[0].Ds_endereco;
                }
                else
                {
                    bsCondicional.DataSource = new TList_Condicional() { rcond };
                    cd_clifor.Enabled = false;
                    bb_clifor.Enabled = false;
                    cd_endereco.Enabled = false;
                    bb_endereco.Enabled = false;
                }
                CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
            }
            else
            {
                MessageBox.Show("Não existe configuração de PDV para a empresa " + Cd_empresa.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            id_pessoa.Clear();
            nm_pessoa.Clear();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            id_pessoa.Clear();
            nm_pessoa.Clear();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            Quantidade.Enabled = true;
            vl_unit.Value = vl_unit.Minimum;
            lblVlSubTotal.Text = string.Empty;
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as TRegistro_ItensCondicional).Quantidade > decimal.Zero ?
                (bsItens.Current as TRegistro_ItensCondicional).Quantidade : 1;
            vl_unit.Value = bsItens.Current == null ? vl_unit.Minimum : (bsItens.Current as TRegistro_ItensCondicional).Vl_unitario;
            lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_ItensCondicional).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            Quantidade.Enabled = bsItens.Current == null ? true : (bsItens.Current as TRegistro_ItensCondicional).lGrade.Count.Equals(0);
            TotalizarVenda();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensCondicional).Quantidade = Quantidade.Value;
                if (lCfg[0].St_movestoquebool)
                {
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico((bsItens.Current as TRegistro_ItensCondicional).Cd_produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno((bsItens.Current as TRegistro_ItensCondicional).Cd_produto)))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as TRegistro_ItensCondicional).Cd_produto))
                        {
                            decimal saldo = BuscarSaldoLocal((bsItens.Current as TRegistro_ItensCondicional).Cd_produto);
                            if (saldo < Quantidade.Value)
                            {
                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                "Empresa.........: " + cd_empresa.Text.Trim() + "-" + nm_empresa.Text.Trim() + "\r\n" +
                                                "Produto.........: " + (bsItens.Current as TRegistro_ItensCondicional).Cd_produto.Trim() + "-" +
                                                (bsItens.Current as TRegistro_ItensCondicional).Ds_produto.Trim() + "\r\n" +
                                                "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Quantidade.Focus();
                                Quantidade.Value = decimal.Zero;
                                (bsItens.Current as TRegistro_ItensCondicional).Quantidade = Quantidade.Value;
                                return;
                            }
                        }
                        else
                        {
                            //Buscar ficha tecnica produto composto
                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsItens.Current as TRegistro_ItensCondicional).Cd_produto, string.Empty, null);
                            lFicha.ForEach(p => p.Quantidade = p.Quantidade * Quantidade.Value);
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                            //Buscar saldo itens da ficha tecnica
                            string msg = string.Empty;
                            lFicha.ForEach(p =>
                            {
                                //Buscar saldo estoque do item
                                decimal saldo = decimal.Zero;
                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(cd_empresa.Text, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                if (saldo < p.Quantidade)
                                    msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                            });
                            if (!string.IsNullOrEmpty(msg))
                            {
                                msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Quantidade.Focus();
                                Quantidade.Value = decimal.Zero;
                                (bsItens.Current as TRegistro_ItensCondicional).Quantidade = Quantidade.Value;
                                return;
                            }
                        }
                    }
                }
                bsItens.ResetCurrentItem();
                if (bsItens.Current != null)
                {
                    object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" +(bsItens.Current as TRegistro_ItensCondicional).Cd_produto.Trim() + "'"
                                }
                                    }, "a.id_caracteristicaH");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                        {
                            fGrade.pId_caracteristica = obj.ToString();
                            fGrade.pCd_empresa = cd_empresa.Text;
                            fGrade.pCd_produto = (bsItens.Current as TRegistro_ItensCondicional).Cd_produto;
                            fGrade.pDs_produto = (bsItens.Current as TRegistro_ItensCondicional).Ds_produto;
                            fGrade.pQuantidade = (bsItens.Current as TRegistro_ItensCondicional).Quantidade;
                            fGrade.pTp_movimento = "S";
                            if (fGrade.ShowDialog() == DialogResult.OK)
                            {
                                fGrade.lGrade.ForEach(p => (bsItens.Current as TRegistro_ItensCondicional).lGrade.Add(p));
                                Quantidade.Value = fGrade.lGrade.Sum(p => p.Vl_mov);
                                Quantidade.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsItens.RemoveCurrent();
                            }
                        }
                }
                TotalizarVenda();
                if (!cd_produto.Focused)
                    vl_unit.Focus();
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_unit.Focus();
        }

        private void vl_unit_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (vl_unit.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não é permitido vender item sem valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_unit.Focus();
                    return;
                }
                //Buscar custo produto
                decimal vl_custo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(cd_empresa.Text,
                                                                    (bsItens.Current as TRegistro_ItensCondicional).Cd_produto,
                                                                    ref vl_custo,
                                                                    null);
                if (vl_unit.Value < vl_custo)
                {
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "PERMITIR VENDA ABAIXO CUSTO";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                            //Verificar se o usuario tem permissao para venda abaixo custo
                            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR VENDA ABAIXO CUSTO", null))
                            {
                                (bsItens.Current as TRegistro_ItensCondicional).Vl_unitario = vl_unit.Value;
                                bsItens.ResetCurrentItem();
                                bsItens_PositionChanged(this, new EventArgs());
                                cd_produto.Focus();
                            }
                            else
                                vl_unit.Focus();
                        else
                            vl_unit.Focus();
                    }
                }
                else
                {
                    (bsItens.Current as TRegistro_ItensCondicional).Vl_unitario = vl_unit.Value;
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                    cd_produto.Focus();
                }
            }
        }

        private void vl_unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_unit_Leave(this, new EventArgs());
        }

        private void gItens_MouseClick(object sender, MouseEventArgs e)
        {
            if (bsItens.Count.Equals(1))
            {
                bsItens_PositionChanged(this, new EventArgs());
                Quantidade.Focus();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCondicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F5))
                ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar config pdv para a empresa
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(cd_empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    cd_clifor.Text = lCfg[0].Cd_clifor;
                    nm_clifor.Text = lCfg[0].Nm_clifor;
                    cd_endereco.Text = lCfg[0].Cd_endereco;
                    ds_endereco.Text = lCfg[0].Ds_endereco;
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                }
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar config pdv para a empresa
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(cd_empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    cd_clifor.Text = lCfg[0].Cd_clifor;
                    nm_clifor.Text = lCfg[0].Nm_clifor;
                    cd_endereco.Text = lCfg[0].Cd_endereco;
                    ds_endereco.Text = lCfg[0].Ds_endereco;
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                }
            }
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void TFCondicional_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
        }

        private void bb_cliforind_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, string.Empty);
        }

        private void cd_cliforind_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforind.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbAutorizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente para selecionar pessoa autorizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            using (TFListPessoasAut fLista = new TFListPessoasAut())
            {
                fLista.pCd_clifor = cd_clifor.Text;
                fLista.pNm_clifor = nm_clifor.Text;
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rPessoa != null)
                    {
                        id_pessoa.Text = fLista.rPessoa.Id_pessoastr;
                        nm_pessoa.Text = fLista.rPessoa.Nm_pessoa;
                    }
            }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }
        
    }
}
