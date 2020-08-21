using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.Locacao;
using Utils;

namespace Faturamento
{
    public partial class TFLocacao : Form
    {
        public bool Altera_Relatorio;

        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;

        private decimal dias_devolucao = decimal.Zero;
        private CamadaDados.Faturamento.Cadastros.TList_CFGLocacao lCfg
        { get; set; }

        public TFLocacao()
        {
            InitializeComponent();
            this.rProg = null;
        }

        private TRegistro_Locacao rlocacao;
        public TRegistro_Locacao rLocacao
        {
            get { return bsLocacao.Current as TRegistro_Locacao; }
            set { rlocacao = value; }
        }

        public CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda
        { get; set; }

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
                    Cd_endereco.Text = lEnd[0].Cd_endereco;
                    Ds_endereco.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void BuscarPromocao()
        {
            if (bsItens.Current != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(Cd_empresa.Text,
                                                                                                (bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                                                                                (bsItens.Current as TRegistro_ItensLocacao).Cd_grupo,
                                                                                                rProg,
                                                                                                (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsLocacao.Current as TRegistro_Locacao).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_produto.Trim())).Sum(p => p.Quantidade) >= rPro.Qtd_minimavenda)
                        {
                            (bsLocacao.Current as TRegistro_Locacao).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    p.Pc_desconto = rPro.Vl_promocao;
                                    //Calcular desconto
                                    p.Vl_desconto = p.Vl_subtotal * (rPro.Vl_promocao / 100);
                                }
                                else
                                {
                                    p.Vl_desconto = rPro.Vl_promocao * p.Quantidade;
                                    //Calcular % Desconto
                                    p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                }
                            });
                            bsLocacao.ResetCurrentItem();
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto = rPro.Vl_promocao;
                            //Calcular desconto
                            (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto =
                                (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal * (rPro.Vl_promocao / 100);
                            bsItens.ResetCurrentItem();
                        }
                        else
                        {
                            (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = rPro.Vl_promocao * (bsItens.Current as TRegistro_ItensLocacao).Quantidade;
                            //Calcular % Desconto
                            (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto =
                                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto * 100 /
                                (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal;
                            bsItens.ResetCurrentItem();
                        }
                    }
            }
        }

        private decimal CalcularDescEspecial(decimal Qtde,
                                             decimal Vl_unit)
        {
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsLocacao.Current as TRegistro_Locacao).lItens.
                        Where(p => p.Cd_produto.Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Qtde * rProg.Valor;
                        else
                            return (Qtde * Vl_unit) * rProg.Valor / 100;
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Qtde * rProg.Valor;
                    else
                        return (Qtde * Vl_unit) * rProg.Valor / 100;
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private void CalcularDesconto(bool St_percentual)
        {
            if (bsItens.Current != null)
            {
                if (vl_desconto.Focused)
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = vl_desconto.Value;
                if (pc_desconto.Focused)
                    (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto = pc_desconto.Value;
                if (St_percentual)
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto =
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal *
                        ((bsItens.Current as TRegistro_ItensLocacao).Pc_desconto / 100);
                else
                    (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto =
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto * 100 / (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal;
                bsItens.ResetCurrentItem();
                this.TotalizarLocacao();
            }
        }

        private decimal ConsultaPreco(string vCd_produto)
        {
            rProg = null;
            if ((!string.IsNullOrEmpty(Cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(vCd_produto)))
            {
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(Cd_empresa.Text,
                                                                                                         cd_clifor.Text,
                                                                                                         vCd_produto,
                                                                                                         CD_TabelaPreco.Text,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa.Text,
                                                                                                    vCd_produto,
                                                                                                    null);
                }
                if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa.Text,
                                                                                                vCd_produto,
                                                                                                CD_TabelaPreco.Text,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void TotalizarLocacao()
        {
            if (bsLocacao.Current != null)
            {
                tot_liquido.Value = (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_liquido);
                tot_desconto.Value = (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_desconto);
                tot_locacao.Value = (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_subtotal);
            }
        }

        private void BuscarItens()
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
                    //Cria novo item
                    bsItens.AddNew();
                    (bsItens.Current as TRegistro_ItensLocacao).Cd_produto = lProduto[0].CD_Produto;
                    (bsItens.Current as TRegistro_ItensLocacao).Ds_produto = lProduto[0].DS_Produto;
                    (bsItens.Current as TRegistro_ItensLocacao).Cd_grupo = lProduto[0].CD_Grupo;
                    (bsItens.Current as TRegistro_ItensLocacao).Quantidade = Quantidade.Value;
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario = this.ConsultaPreco(lProduto[0].CD_Produto);
                    if ((bsItens.Current as TRegistro_ItensLocacao).Vl_unitario > decimal.Zero)
                    {
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal =
                            Quantidade.Value * (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario;
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = this.CalcularDescEspecial(Quantidade.Value, (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario);
                        (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto = (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto * 100 /
                            (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal;
                    }
                    vl_unitario.Enabled = vl_unitario.Value.Equals(decimal.Zero) ||
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                     null);
                    if (lProduto[0].St_composto)
                    {
                        (bsItens.Current as TRegistro_ItensLocacao).lFichaTec =
                            CamadaNegocio.Faturamento.Locacao.TCN_FichaTecItensLoc.MontarFichaTecItemLoc(Cd_empresa.Text,
                                                                                                         lProduto[0].CD_Produto,
                                                                                                         Quantidade.Value,
                                                                                                         null);
                        using (TFFichaTecLocacao fFicha = new TFFichaTecLocacao())
                        {
                            fFicha.rItem = bsItens.Current as TRegistro_ItensLocacao;
                            fFicha.ShowDialog();
                        }
                    }
                    else
                    {
                        decimal vl_custo = decimal.Zero;
                        CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(Cd_empresa.Text,
                                                                            lProduto[0].CD_Produto,
                                                                            ref vl_custo,
                                                                            null);
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_custo = vl_custo;
                    }
                    bsItens.ResetCurrentItem();
                    //Buscar promocao
                    this.BuscarPromocao();
                    bsItens_PositionChanged(this, new EventArgs());
                    this.TotalizarLocacao();
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                this.DialogResult = DialogResult.OK;
                this.ImprimirContrato();
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(Cd_empresa.Text,
                                                                                                (bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                                                                                (bsItens.Current as TRegistro_ItensLocacao).Cd_grupo,
                                                                                                null,
                                                                                                decimal.Zero,
                                                                                                null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((bsLocacao.Current as TRegistro_Locacao).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_produto.Trim())).Sum(p => p.Quantidade) - 
                                (bsItens.Current as TRegistro_ItensLocacao).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(Cd_empresa.Text,
                                                                                                                 cd_clifor.Text,
                                                                                                                 (bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                                                                                                 CD_TabelaPreco.Text,
                                                                                                                 null);
                                (bsLocacao.Current as TRegistro_Locacao).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_produto.Trim())).ToList().ForEach(p =>
                                {
                                    if (rProgAux != null)
                                    {
                                        if (rProgAux.Valor > decimal.Zero)
                                        {
                                            if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                                            {
                                                p.Vl_desconto = p.Quantidade * rProgAux.Valor;
                                                p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                            }
                                            else
                                            {
                                                p.Vl_desconto = p.Vl_subtotal * rProgAux.Valor / 100;
                                                p.Pc_desconto = rProgAux.Valor;
                                            }
                                        }
                                        else
                                        {
                                            p.Vl_desconto = decimal.Zero;
                                            p.Pc_desconto = decimal.Zero;
                                        }
                                    }
                                    else
                                    {
                                        p.Vl_desconto = decimal.Zero;
                                        p.Pc_desconto = decimal.Zero;
                                    }
                                });
                                bsLocacao.ResetCurrentItem();
                            }
                    (bsLocacao.Current as TRegistro_Locacao).lItensDel.Add(
                        bsItens.Current as TRegistro_ItensLocacao);
                    bsItens.RemoveCurrent();
                    this.TotalizarLocacao();
                }
        }

        private void CalcDtPrevDevolucao()
        {
            if (bsLocacao.Current != null)
                if((bsLocacao.Current as TRegistro_Locacao).Dt_locacao.HasValue)
                {
                    (bsLocacao.Current as TRegistro_Locacao).Dt_prevdevolucao =
                        (bsLocacao.Current as TRegistro_Locacao).Dt_locacao.Value.AddDays(Convert.ToDouble(dias_devolucao));
                    bsLocacao.ResetCurrentItem();
                }
        }

        private void ImprimirContrato()
        {
            if (bsLocacao.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new TList_Locacao() { bsLocacao.Current as TRegistro_Locacao };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "TFLanLocacao";
                    Rel.NM_Classe = "TFLanLocacao";
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Contrato de Locação";
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " + 
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar CFG Locacao
                    BindingSource bs_CFGLoc = new BindingSource();
                    bs_CFGLoc.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar((bsLocacao.Current as TRegistro_Locacao).Cd_empresa,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               string.Empty,
                                                                                                                                               null);
                    Rel.Adiciona_DataSource("DTS_CFGLoc", bs_CFGLoc);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
                                                                                                         (bsLocacao.Current as TRegistro_Locacao).Cd_endereco,
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
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);




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
                                           "Contrato de Locação",
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
                                               "Contrato de Locação",
                                               fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatorio selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TFLocacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rlocacao != null)
            {
                bsLocacao.DataSource = new TList_Locacao() { rlocacao };
                this.TotalizarLocacao();
            }
            else
            {
                bsLocacao.AddNew();
                if (rPreVenda != null)
                {
                    Cd_empresa.Text = rPreVenda.Cd_empresa;
                    Cd_empresa_Leave(this, new EventArgs());
                    cd_clifor.Text = rPreVenda.Cd_clifor;
                    nm_clifor.Text = rPreVenda.Nm_clifor;
                    cd_vendedor.Text = rPreVenda.Cd_vendedor;
                    nm_vendedor.Text = rPreVenda.Nm_vendedor;

                    Cd_empresa.Enabled = false;
                    bb_empresa.Enabled = false;
                    cd_clifor.Enabled = false;
                    bb_clifor.Enabled = false;
                    cd_vendedor.Enabled = false;
                    bb_vendedor.Enabled = false;
                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { Cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(Cd_empresa.Text))
            {
                //Buscar config pdv para a empresa
                lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar(Cd_empresa.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                if (lCfg.Count > 0)
                {
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                    ds_tabelapreco.Text = lCfg[0].Ds_tabelapreco;
                    dias_devolucao = lCfg[0].Qtd_diasdevolucao;
                    this.CalcDtPrevDevolucao();
                }
                else
                    MessageBox.Show("Não existe configuração para gerar locação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + Cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(Cd_empresa.Text))
            {
                //Buscar config pdv para a empresa
                lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar(Cd_empresa.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                if (lCfg.Count > 0)
                {
                    CD_TabelaPreco.Text = lCfg[0].Cd_tabelapreco;
                    ds_tabelapreco.Text = lCfg[0].Ds_tabelapreco;
                    dias_devolucao = lCfg[0].Qtd_diasdevolucao;
                    this.CalcDtPrevDevolucao();
                }
                else
                    MessageBox.Show("Não existe configuração para gerar locação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            this.BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_endereco, Ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(),
                                            vParam);
        }

        private void Cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + Cd_endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_endereco, Ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            this.BuscarEndereco();
        }

        private void TFLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F12))
                this.BuscarItens();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {

                if (string.IsNullOrEmpty(cd_produto.Text))
                    FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                         Cd_empresa.Text,
                                                         nm_empresa.Text,
                                                         CD_TabelaPreco.Text,
                                                         new Componentes.EditDefault[] { cd_produto },
                                                         null);
                else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                    FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                         Cd_empresa.Text,
                                                         nm_empresa.Text,
                                                         CD_TabelaPreco.Text,
                                                         new Componentes.EditDefault[] { cd_produto },
                                                         null);
                BuscarItens();
                cd_produto.Clear();
                Quantidade.Focus();
            }



        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            Quantidade.Value = 1;
            vl_unitario.Value = vl_unitario.Minimum;
            vl_desconto.Value = vl_desconto.Minimum;
            pc_desconto.Value = pc_desconto.Minimum;
            lblVlSubTotal.Text = string.Empty;
            lblTotalCupom.Text = string.Empty;
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Quantidade_Leave(sender, new EventArgs());
                if(!vl_unitario.Focus())
                    pc_desconto.Focus();
            }
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (Quantidade.Value.Equals(decimal.Zero))
                    Quantidade.Value = 1;
                
                (bsItens.Current as TRegistro_ItensLocacao).Quantidade = Quantidade.Value;
                (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = this.CalcularDescEspecial(Quantidade.Value, (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario);
                this.BuscarPromocao();
                this.TotalizarLocacao();
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                vl_unitario_Leave(sender, new EventArgs());
                pc_desconto.Focus();
            }
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario = vl_unitario.Value;
                (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal = Quantidade.Value * vl_unitario.Value;
                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = this.CalcularDescEspecial(Quantidade.Value, (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario);
                this.BuscarPromocao();
                this.TotalizarLocacao();
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            Quantidade.Value = bsItens.Current == null ? 1 : (bsItens.Current as TRegistro_ItensLocacao).Quantidade > decimal.Zero ?
                (bsItens.Current as CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao).Quantidade : 1;
            vl_unitario.Value = bsItens.Current == null ? vl_unitario.Minimum : (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario;
            lblVlSubTotal.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_ItensLocacao).Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            pc_desconto.Value = bsItens.Current == null ? pc_desconto.Minimum : (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto;
            vl_desconto.Value = bsItens.Current == null ? vl_desconto.Minimum : (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto;
            lblTotalCupom.Text = bsItens.Current == null ? string.Empty : (bsItens.Current as TRegistro_ItensLocacao).Vl_liquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto = pc_desconto.Value;
                    bsItens.ResetCurrentItem();
                    this.CalcularDesconto(true);
                    bsItens_PositionChanged(this, new EventArgs());
                    vl_desconto.Focus();
                }
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensLocacao).Pc_desconto = pc_desconto.Value;
                bsItens.ResetCurrentItem();
                this.CalcularDesconto(true);
                bsItens_PositionChanged(this, new EventArgs());
            }
        }

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (bsItens.Current != null)
                {
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = vl_desconto.Value;
                    bsItens.ResetCurrentItem();
                    this.CalcularDesconto(false);
                    bsItens_PositionChanged(this, new EventArgs());
                    cd_produto.Focus();
                }
        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = vl_desconto.Value;
                bsItens.ResetCurrentItem();
                this.CalcularDesconto(false);
                bsItens_PositionChanged(this, new EventArgs());
            }
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

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
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
                        cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                        nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                        Cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        Ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }

        private void dt_locacao_Leave(object sender, EventArgs e)
        {
            this.CalcDtPrevDevolucao();
        }

        private void bb_fichatecnica_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
                if ((bsItens.Current as TRegistro_ItensLocacao).lFichaTec.Count > 0)
                    using (TFFichaTecLocacao fFicha = new TFFichaTecLocacao())
                    {
                        fFicha.rItem = bsItens.Current as TRegistro_ItensLocacao;
                        fFicha.ShowDialog();
                    }
        }

        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            (bsItens.Current as TRegistro_ItensLocacao).lFichaTec =
                    CamadaNegocio.Faturamento.Locacao.TCN_FichaTecItensLoc.MontarFichaTecItemLoc(Cd_empresa.Text, (bsItens.Current as TRegistro_ItensLocacao).Cd_produto, Quantidade.Value, null);
            using (TFFichaTecLocacao fFicha = new TFFichaTecLocacao())
            {
                fFicha.rItem = bsItens.Current as TRegistro_ItensLocacao;
                fFicha.ShowDialog();
            }
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if (!string.IsNullOrEmpty(cd_vendedor.Text))
            {
                if(new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_vendedor_x_tabpreco x " +
                                                        "where x.cd_tabelapreco = a.cd_tabelapreco " +
                                                        "and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')"
                                        }
                                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')";
            }
            string vColunas = "a.DS_TabelaPreco|Tabela Preço|200;" +
                              "a.Cd_tabelaPreco|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_vendedor.Text))
            {
                if(new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_vendedor_x_tabpreco x " +
                                                        "where x.cd_tabelapreco = a.cd_tabelapreco " +
                                                        "and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')"
                                        }
                                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }
    }
}
