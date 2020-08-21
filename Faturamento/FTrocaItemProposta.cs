using CamadaDados.Faturamento.Orcamento;
using CamadaDados.Financeiro.Duplicata;
using FormBusca;
using System;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFTrocaItemProposta : Form
    {
        private bool St_insert = false;
        private bool St_informarpreco = false;
        private string Ds_fichaTec = string.Empty;
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        public TRegistro_Orcamento rOrc { get; set; }
        public TRegistro_Orcamento_Item rItemTroca { get; set; }
        public TRegistro_Orcamento_Item rNovoItem { get { return bsItens.Current as TRegistro_Orcamento_Item; } }
        public TRegistro_LanDuplicata rDup { get; set; }
        public string MotivoTroca { get { return edtMotivoTroca.Text; } }
        public string pLogin { get; set; } = string.Empty;

        public TFTrocaItemProposta()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(bsItens.Current == null)
            {
                MessageBox.Show("Obrigatório informar novo item para realizar troca.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(string.IsNullOrEmpty(edtMotivoTroca.Text))
            {
                MessageBox.Show("Obrigatório informar motivo da troca.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtMotivoTroca.Focus();
                return;
            }
            //Buscar local de armazenagem
            object obj = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Produto().BuscarEscalar(
                            new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim() + "'" } },
                            "a.cd_local");
            if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
            {
                (bsItens.Current as TRegistro_Orcamento_Item).Cd_local = 
                    new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                        new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rOrc.Cd_empresa.Trim() + "'" } },
                        "a.cd_local")?.ToString();
            }
            else (bsItens.Current as TRegistro_Orcamento_Item).Cd_local = obj.ToString();
            if(rItemTroca.Vl_subtotalliq < (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq)
                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                {
                    fDup.vCd_empresa = rOrc.Cd_empresa;
                    fDup.vNm_empresa = rOrc.Nm_empresa;
                    fDup.vCd_clifor = rOrc.Cd_clifor;
                    fDup.vNm_clifor = rOrc.Nm_clifor;
                    fDup.vCd_endereco = rOrc.Cd_endereco;
                    fDup.vDs_endereco = rOrc.Ds_endereco;
                    fDup.vTp_mov = "R";
                    fDup.vNr_docto = rOrc.Nr_orcamentostr;
                    fDup.vVl_documento = (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq - rItemTroca.Vl_subtotalliq;
                    fDup.cd_empresa.Enabled = false;
                    fDup.bb_empresa.Enabled = false;
                    fDup.cd_clifor.Enabled = false;
                    fDup.bb_clifor.Enabled = false;
                    fDup.cd_endereco.Enabled = false;
                    fDup.bb_endereco.Enabled = false;
                    fDup.vl_documento_index.Enabled = false;
                    if (fDup.ShowDialog() == DialogResult.OK)
                        if (fDup.dsDuplicata.Current != null)
                            rDup = fDup.dsDuplicata.Current as TRegistro_LanDuplicata;
                        else
                        {
                            MessageBox.Show("Obrigatório gerar duplicata para saldo devedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Obrigatório gerar duplicata para saldo devedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TROCA ITEM PROPOSTA", null))
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Login = Utils.Parametros.pubLogin;
                    fRegra.Ds_regraespecial = "PERMITIR TROCA ITEM PROPOSTA";
                    if (fRegra.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Obrigatório informar LOGIN com permissão para realizar troca", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else pLogin = fRegra.Login;
                }
            DialogResult = DialogResult.OK;
        }

        private void CalcularAcrescimo(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if ((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal > 0)
                {
                    if (vl_acrescimoitem.Focused)
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo = vl_acrescimoitem.Value;
                    if (pc_acrescimo.Focused)
                        (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo = pc_acrescimo.Value;
                    if (St_percentual)
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo =
                            Math.Round((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal *
                            ((bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo / 100), 2, MidpointRounding.AwayFromZero);
                    else
                        (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo =
                            Math.Round((bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo * 100 /
                            (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    vl_acrescimoitem.Value = decimal.Zero;
                    pc_acrescimo.Value = decimal.Zero;
                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo = decimal.Zero;
                    (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo = decimal.Zero;
                }
                bsItens.ResetCurrentItem();
            }
        }

        private void CalcularSubTotal()
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal =
                    (bsItens.Current as TRegistro_Orcamento_Item).Quantidade *
                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario;
                bsItens.ResetCurrentItem();
            }
        }

        private void BuscarProduto()
        {
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                              "PERMITIR INFORMAR PREÇO VENDA",
                                                                              null))
            {
                if (string.IsNullOrEmpty(rOrc.Cd_empresa))
                {
                    MessageBox.Show("Informe a Empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(rOrc.Cd_tabelapreco))
                {
                    MessageBox.Show("Informe a Tabela de Preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (string.IsNullOrEmpty(rOrc.Cd_vendedor))
            {
                MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Clear();
                cd_produto.Focus();
                return;
            }
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   rOrc.Cd_empresa,
                                                   string.Empty,
                                                   rOrc.Cd_tabelapreco,
                                                   new Componentes.EditDefault[] { cd_produto },
                                                   null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                   rOrc.Cd_empresa,
                                                   string.Empty,
                                                   rOrc.Cd_tabelapreco,
                                                   new Componentes.EditDefault[] { cd_produto },
                                                   null);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                cd_produto.Text = rProd.CD_Produto;
                //Cria novo item
                bsItens.Clear();
                bsItens.AddNew();
                St_insert = true;
                (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto = rProd.CD_Produto;
                (bsItens.Current as TRegistro_Orcamento_Item).Ds_produto = rProd.DS_Produto;
                (bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo = rProd.CD_Grupo;
                (bsItens.Current as TRegistro_Orcamento_Item).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                (bsItens.Current as TRegistro_Orcamento_Item).Cd_unid_produto = rProd.CD_Unidade;
                (bsItens.Current as TRegistro_Orcamento_Item).Sigla_unid_produto = rProd.Sigla_unidade;
                (bsItens.Current as TRegistro_Orcamento_Item).Quantidade = Quantidade.Value;

                Ds_fichaTec = rProd.DS_TecnicaAssistencia;
                if (bsItens.Current != null)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo = rProd.CD_Grupo;
                    (bsItens.Current as TRegistro_Orcamento_Item).Cd_condfiscal_produto = rProd.CD_CondFiscal_Produto;
                    (bsItens.Current as TRegistro_Orcamento_Item).Ds_condfiscal_produto = rProd.DS_CondFiscal_Produto;
                }
                ConsultaPreco();
                BuscarFichaTecItem();
                bsItens_PositionChanged(this, new EventArgs());
                Quantidade.Focus();
            }
            else
            {
                cd_produto.Clear();
                cd_produto.Focus();
            }
            //LoginDesconto = string.Empty;
        }
        
        private void BuscarFichaTecItem()
        {
            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto))
            {
                try
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).lFichaTec =
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.MontarFichaTecPropostaItem((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                          rOrc.Cd_empresa,
                                                                                                          rOrc.Cd_tabelapreco,
                                                                                                          Quantidade.Value,
                                                                                                          null);
                    bsItens.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void ConsultaPreco()
        {
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = BuscarPreco();
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela = (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario;
            bsItens.ResetCurrentItem();
            //Buscar custo produto
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_custo =
            CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlUltimaCompra(rOrc.Cd_empresa,
                                                                      cd_produto.Text, null);
            CalcularDescEspecial();
            St_informarpreco = string.IsNullOrEmpty(rOrc.Cd_tabelapreco) ||
                                (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario.Equals(decimal.Zero) ||
                                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                                             null);
            vl_unitario.Enabled = St_informarpreco && pc_desconto.Value.Equals(decimal.Zero);
        }

        private void CalcularDescEspecial()
        {
            if ((rProg != null) && (Quantidade.Value > decimal.Zero))
                if (rProg.Valor > decimal.Zero)
                {
                    bsItens.ResetCurrentItem();
                    (bsItens.Current as TRegistro_Orcamento_Item).Quantidade = Quantidade.Value;
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto =
                            (bsItens.Current as TRegistro_Orcamento_Item).Quantidade * rProg.Valor;
                    else
                        (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto = rProg.Valor;
                    bsItens.ResetCurrentItem();
                }
        }

        private decimal BuscarPreco()
        {
            //Verificar se existe programacao especial de venda 
            rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(rOrc.Cd_empresa,
                                                                                                 rOrc.Cd_clifor,
                                                                                                 cd_produto.Text,
                                                                                                 rOrc.Cd_tabelapreco,
                                                                                                 null);
            if (rProg != null)
                if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                    return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(rOrc.Cd_empresa,
                                                                                            (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto, null);
                else
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rOrc.Cd_empresa,
                                                                                                (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                rOrc.Cd_tabelapreco,
                                                                                                null);
            else if ((!string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto)) &&
                (!string.IsNullOrEmpty(rOrc.Cd_empresa)) &&
                (!string.IsNullOrEmpty(rOrc.Cd_tabelapreco)))
                return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rOrc.Cd_empresa,
                                                                                            (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                            rOrc.Cd_tabelapreco,
                                                                                            null);
            else return decimal.Zero;
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            DS_Produto.Text = string.Empty;
            vl_unitario.Value = vl_unitario.Minimum;
            lblVlSubTotal.Text = string.Empty;
            pc_desconto.Value = pc_desconto.Minimum;
            vl_descontoItem.Value = vl_descontoItem.Minimum;
            pc_acrescimo.Value = pc_acrescimo.Minimum;
            vl_acrescimoitem.Value = vl_acrescimoitem.Minimum;
            lblTotalCupom.Text = string.Empty;
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!St_insert)
            {
                DS_Produto.Enabled = true;
                DS_Produto.Focus();
            }
        }

        private void DS_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DS_Produto_Leave(this, new EventArgs());
        }

        private void DS_Produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DS_Produto.Text) && St_insert)
            {
                string prod = DS_Produto.Text;
                //Cria novo item
                bsItens.AddNew();
                St_insert = true;
                (bsItens.Current as TRegistro_Orcamento_Item).Ds_produto = prod;
                (bsItens.Current as TRegistro_Orcamento_Item).Quantidade = Quantidade.Value;
                (bsItens.Current as TRegistro_Orcamento_Item).St_projespecialbool = true;
                bsItens_PositionChanged(this, new EventArgs());
            }
            Quantidade.Focus();
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (!cd_produto.Focused)
                    if (!vl_unitario.Focus())
                        pc_desconto.Focus();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                (bsItens.Current as TRegistro_Orcamento_Item).Quantidade = Quantidade.Value;
                CalcularSubTotal();
                bsItens.ResetCurrentItem();
                if ((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal > decimal.Zero)
                    CalcularDescEspecial();
                bsItens.ResetCurrentItem();
                bsItens_PositionChanged(this, new EventArgs());
                //Totalizar Venda
                if (!cd_produto.Focused)
                    if (vl_unitario.Enabled)
                        vl_unitario.Focus();
                    else
                        pc_desconto.Focus();
            }
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (pc_desconto.Enabled)
                    pc_desconto.Focus();
                else pc_acrescimo.Focus();
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                if (vl_unitario.Value < vl_tabela.Value)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto = decimal.Zero;
                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto = decimal.Zero;
                    bsItens.ResetCurrentItem();
                    pc_desconto.Enabled = false;
                    vl_descontoItem.Enabled = false;
                    pc_acrescimo.Focus();
                }
                else
                {
                    pc_desconto.Enabled = true;
                    vl_descontoItem.Enabled = true;
                    pc_desconto.Focus();
                }
                (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = vl_unitario.Value;
                (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                bsItens.ResetCurrentItem();
                //CalcularDescontos(true);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (pc_desconto.Value > decimal.Zero)
                    pc_acrescimo.Focus();
                else vl_descontoItem.Focus();
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                if (pc_desconto.Value * (Quantidade.Value * vl_unitario.Value) / 100 < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto = pc_desconto.Value;
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else if (vl_unitario.Value > 0)
                {
                    vl_descontoItem.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    pc_desconto.Focus();
                }
            }
        }

        private void vl_descontoItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null && St_insert)
                {
                    if (vl_descontoItem.Value < (Quantidade.Value * vl_unitario.Value))
                    {
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto = vl_descontoItem.Value;
                        bsItens.ResetCurrentItem();
                        bsItens_PositionChanged(this, new EventArgs());
                        pc_acrescimo.Focus();
                    }
                    else if (vl_unitario.Value > 0)
                    {
                        vl_descontoItem.Value = decimal.Zero;
                        pc_desconto.Value = decimal.Zero;
                        vl_descontoItem.Focus();
                    }
                }
        }

        private void vl_descontoItem_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                if (vl_descontoItem.Value < (Quantidade.Value * vl_unitario.Value))
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto = vl_descontoItem.Value;
                    bsItens.ResetCurrentItem();
                    bsItens_PositionChanged(this, new EventArgs());
                }
                else if (vl_unitario.Value > 0)
                {
                    vl_descontoItem.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    vl_descontoItem.Focus();
                }
            }
        }

        private void pc_acrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null && St_insert)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo = pc_acrescimo.Value;
                    bsItens.ResetCurrentItem();
                    CalcularAcrescimo(true);
                    bsItens_PositionChanged(this, new EventArgs());
                    vl_acrescimoitem.Focus();
                }
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo = pc_acrescimo.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(true);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void vl_acrescimoitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null && St_insert)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo = vl_acrescimoitem.Value;
                    bsItens.ResetCurrentItem();
                    CalcularAcrescimo(false);
                    bsItens_PositionChanged(this, new EventArgs());
                    cd_produto.Focus();
                    DS_Produto.Enabled = true;
                    St_insert = false;
                }
                else
                    cd_produto.Focus();
        }

        private void vl_acrescimoitem_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null && St_insert)
            {
                (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo = vl_acrescimoitem.Value;
                bsItens.ResetCurrentItem();
                CalcularAcrescimo(false);
                bsItens_PositionChanged(this, new EventArgs());
                cd_produto.Focus();
                DS_Produto.Enabled = true;
                St_insert = false;
            }
            else
                cd_produto.Focus();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as TRegistro_Orcamento_Item).Quantidade > decimal.Zero ?
                                            (bsItens.Current as TRegistro_Orcamento_Item).Quantidade : 1;
                DS_Produto.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_Orcamento_Item).Ds_produto;
                vl_unitario.Value = bsItens.Current == null ? vl_unitario.Minimum : (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario;
                lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                pc_desconto.Value = bsItens.Current == null ? pc_desconto.Minimum : (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto;
                vl_descontoItem.Value = bsItens.Current == null ? vl_descontoItem.Minimum : (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto;
                pc_acrescimo.Value = bsItens.Current == null ? pc_acrescimo.Minimum : (bsItens.Current as TRegistro_Orcamento_Item).Pc_acrescimo;
                vl_acrescimoitem.Value = bsItens.Current == null ? vl_acrescimoitem.Minimum : (bsItens.Current as TRegistro_Orcamento_Item).Vl_acrescimo;
                lblTotalCupom.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                St_informarpreco = string.IsNullOrEmpty(rOrc.Cd_tabelapreco) ||
                                (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario.Equals(decimal.Zero) ||
                                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                                             null);
                pc_desconto.Enabled = !((bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario < (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela);
                vl_descontoItem.Enabled = !((bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario < (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela);
                vl_unitario.Enabled = St_informarpreco && pc_desconto.Value.Equals(decimal.Zero);
                DS_Produto.Enabled = string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto) && St_insert;
                St_insert = true;
            }
            else St_insert = false;
        }

        private void TFTrocaItemProposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
        }

        private void TFTrocaItemProposta_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            edtMotivoTroca.CharacterCasing = CharacterCasing.Normal;
            edtProposta.Text = rOrc.Nr_orcamentostr;
            edtCliente.Text = rOrc.Cd_clifor.Trim() + "-" + rOrc.Nm_clifor;
            edtProduto.Text = rItemTroca.Cd_produto.Trim() + "-" + rItemTroca.Ds_produto;
            edtQtde.Text = rItemTroca.Quantidade.ToString();
            edtVlLiquido.Text = rItemTroca.Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            //Buscar Parcelas
            bsParcelas.DataSource = new TCD_LanParcela().Select(
                new TpBusca[]
                {
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                    "inner join tb_fat_pedido_itens y " +
                                    "on x.nr_pedido = y.nr_pedido " +
                                    "and x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and y.nr_orcamento = " + rOrc.Nr_orcamentostr + ")"
                    }
                }, 0, string.Empty, "a.dt_vencto", string.Empty);
        }

        private void editDefault3_TextChanged(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
                if(rItemTroca.Vl_subtotalliq < (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq)
                {
                    lblSaldo.Text = "Saldo Devedor: " + ((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq - rItemTroca.Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    lblSaldo.ForeColor = System.Drawing.Color.Red;
                }
                else if(rItemTroca.Vl_subtotalliq > (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq)
                {
                    lblSaldo.Text = "Saldo Credor: " + (rItemTroca.Vl_subtotalliq - (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotalliq).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    lblSaldo.ForeColor = System.Drawing.Color.Red;
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
    }
}
