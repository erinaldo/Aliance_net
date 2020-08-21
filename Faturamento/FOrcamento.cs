using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.Orcamento;

namespace Faturamento
{
    public partial class TFOrcamento : Form
    {
        public bool St_editar { get; set; }
        public bool St_parcelas
        { get; set; }
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
        private string Cd_condPagtoOld = string.Empty;

        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;
        private string LoginDesconto = string.Empty;

        private decimal Pc_descOld
        { get; set; }
         
        public TFOrcamento()
        {
            InitializeComponent();
            St_editar = true;
            rorcamento = null;
            St_parcelas = false;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ABERTO", "AB"));
            cbx.Add(new TDataCombo("AGUARDANDO RETORNO", "AR"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("VENDEDOR", "P"));
            cbx1.Add(new TDataCombo("COMPRADOR", "T"));
            tp_descarga.DataSource = cbx1;
            tp_descarga.DisplayMember = "Display";
            tp_descarga.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("EMITENTE", "0"));
            cbx2.Add(new TDataCombo("DESTINATARIO", "1"));
            cbx2.Add(new TDataCombo("TERCEIRO", "2"));
            cbx2.Add(new TDataCombo("SEM FRETE", "9"));
            tp_frete.DataSource = cbx2;
            tp_frete.DisplayMember = "Display";
            tp_frete.ValueMember = "Value";
        }

        private void Alterar()
        {
            if (rorcamento != null)
            {
                bsOrcamento.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { rorcamento };
                TotalizarPedido();
                Pc_descOld = Pc_DescGeral.Value;
                cbEmpresa.Focus();
                bsItens_PositionChanged(this, new EventArgs());
            }
            else
            {
                bsOrcamento.AddNew();
                cbEmpresa.SelectedIndex = 0;
                cbEmpresa.Focus();
                tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
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

        private void BuscarRepresentante(string id_regiao)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                    new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_regiao",
                        vOperador = "=",
                        vVL_Busca = "'" + id_regiao.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.st_representante",
                        vOperador = "=",
                        vVL_Busca = "'S'" 
                    }
                }, "a.cd_vendedor");

                if (obj != null)
                {
                    cd_representante.Text = obj.ToString();
                    cd_representante_Leave(this, new EventArgs());
                }
                else
                {
                    cd_representante.Text = string.Empty;
                    nm_representante.Text = string.Empty;
                }
            }
        }

        private void TotalizarPedido()
        {
            if (bsOrcamento.Current != null)
            {
                //Ratear frete, o frete não tem campo no item por isso deve ser rateado sempre
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearFrete(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Count > 0)
                {
                    if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Exists(p => p.Pc_desconto > decimal.Zero))
                        Pc_DescGeral.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Pc_desconto > decimal.Zero).Average(p => p.Pc_desconto);
                    else
                        Pc_DescGeral.Value = decimal.Zero;
                }
                else
                {
                    Pc_DescGeral.Value = decimal.Zero;
                    pc_comrep.Value = decimal.Zero;
                }
                VL_Desconto_Geral.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_desconto);
                tot_acrescimo.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_acrescimo);
                vl_frete.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_frete);
                tot_custo.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_custototal);
                tot_itens.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p=> p.Vl_subtotal);
                if (tot_liquido.Value > decimal.Zero)
                {
                    if (tot_liquido.Value >= tot_custo.Value)
                    {
                        pc_lucro.Value = 100 - (tot_custo.Value * 100 / tot_liquido.Value);
                        lblLucro.Text = "% Lucro";
                        lblLucro.ForeColor = Color.Blue;
                    }
                    else
                    {
                        pc_lucro.Value = (tot_custo.Value * 100 / tot_liquido.Value) - 100;
                        lblLucro.Text = "% Perda";
                        lblLucro.ForeColor = Color.Red;
                    }
                }
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void Habilita_Data_Financeiro()
        {
            if (bsOrcamento.Current != null)
                diasvencimento.Enabled = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S") && 
                    (ST_ComEntrada.Checked ? BS_Parcelas.Position > 0 : true);
        }

        private void AjustarDadosFinanceiros()
        {
            if (bsOrcamento.Current != null)
            {
                Habilita_Data_Financeiro();
                if (!Parcelas_Entrada.Text.Trim().Equals("S"))
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Calcula_Parcelas(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                    bsOrcamento.ResetCurrentItem();
                    BS_Parcelas_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void CalcularValorPedidoItem()
        {
            if (bsOrcamento.Current != null)
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.CalcularValorJuroFin(
                                                                                                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto()
                                                                                                            {
                                                                                                                Pc_jurodiario_atrazoFin = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_jurodiario_atrazo,
                                                                                                                Tp_juro_fin = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Tp_juro,
                                                                                                                Qt_diasdesdobro = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Qt_diasdesdobro,
                                                                                                                St_comentradabool = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_cometrada,
                                                                                                                Qt_parcelas = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).QTD_Parcelas
                                                                                                            },
                                                                                                            p.Vl_subtotal));
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

        private void BuscarPromocao(CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item rItem)
        {
            if (rItem != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                rItem.Cd_produto,
                                                                                                rItem.Cd_grupo,
                                                                                                null,
                                                                                                decimal.Zero,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).Sum(p => p.Quantidade) + rItem.Quantidade >= rPro.Qtd_minimavenda)
                        {
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).ToList().ForEach(p =>
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
                            //Calcular item atual
                            if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                            {
                                rItem.Pc_desconto = rPro.Vl_promocao;
                                //Calcular desconto
                                rItem.Vl_desconto = rItem.Vl_subtotal * (rPro.Vl_promocao / 100);
                            }
                            else
                            {
                                rItem.Vl_desconto = rPro.Vl_promocao * rItem.Quantidade;
                                //Calcular % Desconto
                                rItem.Pc_desconto = rItem.Vl_desconto * 100 / rItem.Vl_subtotal;
                            }
                        }
                        else
                        {
                            rItem.Vl_desconto = decimal.Zero;
                            rItem.Pc_desconto = decimal.Zero;
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            rItem.Pc_desconto = rPro.Vl_promocao;
                            //Calcular desconto
                            rItem.Vl_desconto = rItem.Vl_subtotal * (rPro.Vl_promocao / 100);
                        }
                        else
                        {
                            rItem.Vl_desconto = rPro.Vl_promocao * rItem.Quantidade;
                            //Calcular % Desconto
                            rItem.Pc_desconto = rItem.Vl_desconto * 100 / rItem.Vl_subtotal;
                        }
                    }
            }
        }

        private void afterGrava()
        {
            //ReCalcular Parcelas
            if (VL_Parcela.Focused)
                VL_Parcela_Leave(this, new EventArgs());
            if (tcOrcamento.SelectedTab != tpOrcamento)
                tcOrcamento.SelectedTab = tpOrcamento;
            decimal cont = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).NR_Versao;
            if (pDados.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr))
                {
                    if (new CamadaDados.Faturamento.Orcamento.TCD_Orcamento().BuscarEscalar(
                         new TpBusca[]
                         {
                             new TpBusca()
                             {
                                 vNM_Campo = "a.cd_empresa",
                                 vOperador = "=",
                                 vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                             },
                             new TpBusca()
                             {
                                 vNM_Campo = "a.nr_orcamento",
                                 vOperador = "=",
                                 vVL_Busca = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr
                             },
                             new TpBusca()
                             {
                                 vNM_Campo = "a.st_registro",
                                 vOperador = "=",
                                 vVL_Busca = "'FT'"
                             }
                         }, "1") != null)
                    {
                        MessageBox.Show("Não é possivel gravar orçamento, pois ele já está PROCESSADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar orçamento sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!ValidarDescontos())
                    return;
                NR_Versao.Text = (cont + 1).ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void InserirItem()
        {
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                 "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                 null))
            {
                if (cbEmpresa.SelectedValue == null)
                {
                    MessageBox.Show("Informe a Empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(CD_TabelaPreco.Text))
                {
                    MessageBox.Show("Informe a Tabela de Preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFItensOrcamento fItem = new TFItensOrcamento())
            {
                fItem.CD_TabelaPreco = CD_TabelaPreco.Text;
                fItem.CD_Empresa = cbEmpresa.SelectedValue.ToString();
                fItem.Nm_empresa = cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                fItem.Cd_cliente = CD_Clifor.Text;
                fItem.Cd_vendedor = CD_CompVend.Text;
                fItem.St_representante = !string.IsNullOrEmpty(cd_representante.Text);
                if (fItem.ShowDialog() == DialogResult.OK)
                    if (fItem.rItem != null)
                    {
                        if (fItem.rItem.lFichaTec.Count > 0)
                        {
                            //Recalcular Custo Produto Composto
                            CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lCusto = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                            lCusto.Add(fItem.rItem);
                            if (fItem.rItem.lFichaTec.Count > 0)
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarListaSeparacaoOrc(null,
                                                                                                          cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                          lCusto,
                                                                                                          0);
                            fItem.rItem.Vl_custo = lCusto.Sum(p => p.Vl_custototal) / fItem.rItem.Quantidade;
                        }
                        //Buscar Promocao
                        BuscarPromocao(fItem.rItem);
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Add(fItem.rItem);
                        bsOrcamento.ResetCurrentItem();
                        TotalizarPedido();
                    }
            };
            AddCarrinho();

        }

        private void AlterarItem()
        {
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                 "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                 null))
            {
                if (cbEmpresa.SelectedValue == null)
                {
                    MessageBox.Show("Informe a Empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(CD_TabelaPreco.Text))
                {
                    MessageBox.Show("Informe a Tabela de Preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bsItens.Current != null)
            {
                using (TFItensOrcamento fItem = new TFItensOrcamento())
                {
                    fItem.rItem = bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                    fItem.st_alterar = true;
                    fItem.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fItem.CD_Empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                    fItem.Nm_empresa = cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                    fItem.Cd_cliente = CD_Clifor.Text;
                    fItem.Cd_vendedor = CD_CompVend.Text;
                    fItem.St_representante = !string.IsNullOrEmpty(cd_representante.Text);

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
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.ForEach(p => rCopia.lFichaTec.Add(p));

                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        if (fItem.rItem.lFichaTec.Count > 0)
                        {
                            //Recalcular Custo Produto Composto
                            CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lCusto = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                            lCusto.Add(fItem.rItem);
                            if (fItem.rItem.lFichaTec.Count > 0)
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarListaSeparacaoOrc(null,
                                                                                                          cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                          lCusto,
                                                                                                          0);
                            fItem.rItem.Vl_custo = lCusto.Sum(p => p.Vl_custototal) / fItem.rItem.Quantidade;
                        }
                        //Verificar se item possui promocao
                        CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                            CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                        fItem.rItem.Cd_produto,
                                                                                                        fItem.rItem.Cd_grupo,
                                                                                                        null,
                                                                                                        decimal.Zero,
                                                                                                        null);
                        if (rPro != null)
                            if (rPro.Qtd_minimavenda > 1)
                                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(fItem.rItem.Cd_produto.Trim())).Sum(p => p.Quantidade) < rPro.Qtd_minimavenda)
                                {
                                    //Verificar se tem programacao especial de venda
                                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                        CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                                     CD_Clifor.Text,
                                                                                                                     fItem.rItem.Cd_produto,
                                                                                                                     CD_TabelaPreco.Text,
                                                                                                                     null);
                                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(fItem.rItem.Cd_produto.Trim())).ToList().ForEach(p =>
                                    {
                                        if (rProgAux != null)
                                        {
                                            if (rProgAux.Valor > decimal.Zero)
                                            {
                                                if (rProgAux.Tp_valor.Trim().ToUpper().Equals("V"))
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
                                    bsOrcamento.ResetCurrentItem();
                                }
                                else
                                    BuscarPromocao(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item);
                        TotalizarPedido();
                    }
                    else
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
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_custo = rCopia.Vl_custo;
                    }
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
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                        CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto,
                                                                                                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_grupo,
                                                                                                    null,
                                                                                                    decimal.Zero,
                                                                                                    null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) - 
                                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                                 CD_Clifor.Text,
                                                                                                                 (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto,
                                                                                                                 CD_TabelaPreco.Text,
                                                                                                                 null);
                                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim())).ToList().ForEach(p =>
                                {
                                    if (rProgAux != null)
                                    {
                                        if (rProgAux.Valor > decimal.Zero)
                                        {
                                            if (rProgAux.Tp_valor.Trim().ToUpper().Equals("V"))
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
                                bsOrcamento.ResetCurrentItem();
                            }
                    bsItens.RemoveCurrent();
                    TotalizarPedido();
                }
            }
        }

        private void SimularImpostos()
        {
            using (TFSimuladorImpostos fSimular = new TFSimuladorImpostos())
            {
                fSimular.pCd_empresa = cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString();
                fSimular.pNm_empresa = cbEmpresa.SelectedValue == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                string auxCfg = string.Empty;
                if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cfg_pedido))
                {
                    auxCfg = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cfg_pedido;
                    fSimular.pCfg_pedido = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cfg_pedido;
                    fSimular.pDs_tipopedido = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Ds_tipopedido;
                    fSimular.pTp_mov = "S";
                }
                else
                {
                    //Buscar config do orcamento
                    CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg =
                        CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                    if (lCfg.Count > 0)
                    {
                        auxCfg = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cfg_pedido;
                        fSimular.pCfg_pedido = lCfg[0].Cfg_pedido;
                        fSimular.pDs_tipopedido = lCfg[0].Ds_tipopedido;
                        fSimular.pTp_mov = "S";//Orcamento somente para venda
                    }
                }
                fSimular.pCd_clifor = CD_Clifor.Text;
                fSimular.pNm_clifor = NM_Clifor.Text;
                fSimular.pCd_endereco = CD_Endereco.Text;
                fSimular.pDs_endereco = DS_Endereco.Text;
                fSimular.St_calcavulso = false;
                if (bsOrcamento.Current != null)
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                    {
                        fSimular.lProdSimular.Add(
                            new CamadaDados.Fiscal.TRegistro_ProdutoSimular()
                            {
                                Cd_produto = p.Cd_produto,
                                Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                Ds_condfiscal_produto = p.Ds_condfiscal_produto,
                                Ds_produto = p.Ds_produto,
                                Quantidade = p.Quantidade,
                                Sg_unidade = p.Sigla_unid_produto,
                                Vl_unitario = p.Vl_unitario
                            });
                    });
                if (fSimular.ShowDialog() == DialogResult.OK)
                {
                    vl_impostosomar.Value = fSimular.lResumo.Where(p => p.St_totalnota.Trim().ToUpper().Equals("S")).Sum(p => p.Vl_imposto);
                    vl_impostosubtrair.Value = fSimular.lResumo.Where(p => p.St_totalnota.Trim().ToUpper().Equals("D")).Sum(p => p.Vl_imposto);
                    if (((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa.Trim() != fSimular.Cd_empresasimular.Trim()) &&
                        string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_tabelapreco))
                        if (MessageBox.Show("Deseja trocar empresa do orçamento para a empresa da simulação imposto?", "Pergunta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cbEmpresa.SelectedValue = fSimular.Cd_empresasimular;
                            CalcularDtValidade();
                        }
                    if (auxCfg.Trim() != fSimular.Cfg_pedidosimular.Trim())
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cfg_pedido = fSimular.Cfg_pedidosimular;
                }
            }
        }

        private bool ValidarDescontos()
        {
            if (DialogResult == DialogResult.Cancel)
                return false;
            if ((Pc_descOld > decimal.Zero) && Pc_descOld.Equals(Pc_DescGeral.Value))
                return true;
            for (int i = 0; i < ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Count); i++)
            {
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                    cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if (lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                            p.Cd_grupo.Trim().Equals((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_totalitens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_grupo = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo;
                                    fLogin.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_totalitens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                    //Desconto por grupo de produto
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                        if (Pc_DescGeral.Value.Equals(decimal.Zero))
                            Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_totalitens;
                        if (Pc_DescGeral.Value > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens[i].Cd_grupo;
                                fLogin.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                                fLogin.Pc_desc = Pc_DescGeral.Value;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                    return false;
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    //Desconto por vendedor e empresa
                    if (Pc_DescGeral.Value > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                            fLogin.Pc_desc = Pc_DescGeral.Value;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                                return false;
                            else
                            {
                                LoginDesconto = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                    else return true;
                }
                else return true;
            }
            return true;
        }

        private void AddCarrinho()
        {
            if (bsItens.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto,
                                                                                            string.Empty,
                                                                                            null);
                if (lAssistente.Count > 0)
                {
                    using (TFAssistenteVenda fAssistente = new TFAssistenteVenda())
                    {
                        fAssistente.lAssistente = lAssistente;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Add(
                                    new CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = p.CD_ProdVenda,
                                        Ds_produto = p.DS_ProdVenda,
                                        Cd_unid_produto = p.CD_Unidade,
                                        Ds_unid_produto = p.DS_Unidade,
                                        Sigla_unid_produto = p.Sigla_Unidade,
                                        NCM = p.NCM,
                                        Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rOrcamento.Cd_empresa, p.CD_ProdVenda, rOrcamento.Cd_tabelapreco, null),
                                        Quantidade = p.Quantidade,
                                        Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(), p.CD_ProdVenda, null)
                                    }));
                                bsOrcamento.ResetCurrentItem();
                            }
                    }
                }
            }
        }

        private bool VerificarTotDesconto(CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento val)
        {
            for (int i = 0; i < (val.lItens.Count); i++)
            {
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(CD_CompVend.Text,
                                                                                    cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                if (lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                            p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalitens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_grupo = val.lItens[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalitens;
                            if (Pc_DescGeral.Value > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = Pc_DescGeral.Value;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                    //Desconto por grupo de produto
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                        if (Pc_DescGeral.Value.Equals(decimal.Zero))
                            Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / val.Vl_totalitens;
                        if (Pc_DescGeral.Value > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = val.lItens[i].Cd_grupo;
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = Pc_DescGeral.Value;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                    return false;
                                else
                                {
                                    LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    //Desconto por vendedor e empresa
                    if (Pc_DescGeral.Value > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = val.Cd_empresa;
                            fLogin.Pc_desc = Pc_DescGeral.Value;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                                return false;
                            else
                            {
                                LoginDesconto = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                    else return true;
                }
                else return true;
            }
            return true;
        }

        private void TFOrcamento_Load(object sender, EventArgs e)
        {          
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gFichaTec);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pCondPgto.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            Alterar();
            //Mostrar 
            bool st_vercusto = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null);
            lblCusto.Visible = st_vercusto;
            tot_custo.Visible = st_vercusto;
            lblLucro.Visible = st_vercusto;
            pc_lucro.Visible = st_vercusto;
            cVl_ultimacompra.Visible = st_vercusto;
            if (!st_vercusto)
            {
                gItens.Columns.Remove(cVl_custototal);
                gItens.Columns.Remove(cVl_ultimacompra);
            }
            if(!St_editar)
            {
                pDados.Enabled = false;
                TS_ItensPedido.Enabled = false;
                pDadosComp.Enabled = false;
                pCondPgto.Enabled = false;
                pParcelas.Enabled = false;
                bb_inutilizar.Enabled = false;
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            object obj_regvenda = null;
            if(!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                                        }
                                    }, "1");
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if(obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";

            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParam);
            //Buscar Representante
            if (linha != null)
                BuscarRepresentante(linha["id_regiao"].ToString());
            CD_Endereco.Clear();
            DS_Endereco.Clear();
            DS_Cidade.Clear();
            UF.Text = string.Empty;
            Fone.Clear();
            CD_TabelaPreco.Clear();
            NM_TabelaPreco.Clear();
            Busca_Endereco_Clifor();
            bsOrcamento.ResetCurrentItem();
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'";
            object obj_regvenda = null;
            if(!string.IsNullOrEmpty(CD_CompVend.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
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
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            //Buscar Representante
            if (linha != null)
                BuscarRepresentante(linha["id_regiao"].ToString());
            CD_Endereco.Clear();
            DS_Endereco.Clear();
            DS_Cidade.Clear();
            UF.Text = string.Empty;
            Fone.Clear();
            CD_TabelaPreco.Clear();
            NM_TabelaPreco.Clear();
            Busca_Endereco_Clifor();
            bsOrcamento.ResetCurrentItem();
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                       , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
            if (linha != null)
            {
                Fone.Text = linha["fone"].ToString();
                UF.Text = linha["UF"].ToString();
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                                    , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (linha != null)
            {
                Fone.Text = linha["fone"].ToString();
                UF.Text = linha["UF"].ToString();
            }
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_representante, nm_representante }, "isnull(a.st_representante, 'N')|=|'S'");
        }

        private void cd_representante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_representante.Text.Trim() + "';isnull(a.st_representante, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_representante, nm_representante }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }        

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if(!string.IsNullOrEmpty(CD_CompVend.Text))
                if(new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_vendedor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            //Verificar se cliente possui tab preco
            if(!string.IsNullOrEmpty(CD_Clifor.Text))
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += (string.IsNullOrEmpty(vParam) ? string.Empty : ";") +
                              "|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                       , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                       new CamadaDados.Diversos.TCD_CadTbPreco(),
                                       vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_vendedor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            //Verificar se cliente possui tab preco
            if(!string.IsNullOrEmpty(CD_Clifor.Text))
                if (new CamadaDados.Financeiro.Cadastros.TCD_Clifor_X_TabPreco().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                        }
                    }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fin_clifor_x_tabpreco x " +
                              "         where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "         and x.cd_clifor = '" + CD_Clifor.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void CD_Clifor_TextChanged(object sender, EventArgs e)
        {
            NM_Clifor.Enabled = string.IsNullOrEmpty(CD_Clifor.Text);
        }

        private void CD_Endereco_TextChanged(object sender, EventArgs e)
        {
            DS_Endereco.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            DS_Cidade.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            UF.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            Fone.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (St_editar && e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                SimularImpostos();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItem();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItem();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            Cd_condPagtoOld = CD_CondPGTO.Text;
            string vParam = string.Empty;
            //Verificar se condicao de pagamento para o vendedor
            object obj = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam = "|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                         "          where x.cd_condpgto = a.cd_condpgto " +
                         "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;a.QT_Parcelas|Quantidade Parcelas|40;" +
            "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;a.ST_VenctoEmFeriado|Vence em Feriado|40;a.cd_condPGTO|Código|100;a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            CD_CondPGTO_Leave(this, new EventArgs());
        }

        private void vl_frete_Leave(object sender, EventArgs e)
        {
            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_frete = vl_frete.Value;
            TotalizarPedido();
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            if (Cd_condPagtoOld.Trim().Equals(CD_CondPGTO.Text.Trim()) && 
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas.Count > 0)
                return;
            string vParam = "CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "'";
            object obj = null;
            if(!string.IsNullOrEmpty(CD_CompVend.Text))
                obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " +
                                            "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                            }
                        }, "1");
            if(obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                          "             where x.cd_condpgto = a.cd_condpgto " +
                          "             and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";

            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto },
             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                Parcelas.Value = Convert.ToDecimal(linha["qt_parcelas"].ToString());
                QT_DIASDESDOBRO.Value = Convert.ToDecimal(linha["qt_diasdesdobro"].ToString());
                ST_ComEntrada.Checked = linha["st_comentrada"].ToString().Trim().ToUpper().Equals("S");
                cd_juro_fin.Text = linha["cd_juro_fin"].ToString();
                PC_JuroDiario_Atrazo.Value = linha["pc_juroDiario_atrazoFin"].ToString().Equals("") ? 0 : Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                tp_juro.Text = linha["tp_juro_fin"].ToString();
            }
            else
            {
                Parcelas.Value = 0;
                QT_DIASDESDOBRO.Value = 0;
                ST_ComEntrada.Checked = false;
                cd_juro_fin.Clear();
                PC_JuroDiario_Atrazo.Value = 0;
            }
            CalcularValorPedidoItem();
            AjustarDadosFinanceiros();
        }

        private void VL_Entrada_Leave(object sender, EventArgs e)
        {
            decimal _VL_Entrada = VL_Entrada.Value;

            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Calcula_Parcelas(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);

            for (int x = 0; x < (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas.Count; x++)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas[x].Vl_entrada = VL_Entrada.Value;
                if (x == 0)
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas[x].Vl_parcela = VL_Entrada.Value;
            }

            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Recalcula_Parcelas(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, 0);
            bsOrcamento.ResetCurrentItem();
        }

        private void recalcularParcelas()
        {
            int indexAtual = BS_Parcelas.Position;
            decimal totalAtual = 0;

            //Somar os valores das parcelas até o indexAtual
            for (int i = 0; i <= indexAtual; i++)
                totalAtual += (bsOrcamento.Current as TRegistro_Orcamento).lParcelas[i].Vl_parcela;

            decimal diferenca = (bsOrcamento.Current as TRegistro_Orcamento).lParcelas.Count - (indexAtual + 1);
            decimal valor = ((bsOrcamento.Current as TRegistro_Orcamento).Vl_totalorcamento - totalAtual) / diferenca;

            //Reatribuicao dos valores para parcelas restantes
            for (int i = 0; i < (bsOrcamento.Current as TRegistro_Orcamento).lParcelas.Count; i++)
                if (i > indexAtual)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lParcelas[i].Vl_parcela = valor;
                }
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas[BS_Parcelas.Position].Vl_parcela = VL_Parcela.Value;
                recalcularParcelas();
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Recalcula_Parcelas(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, BS_Parcelas.Position);
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void tot_liquido_ValueChanged(object sender, EventArgs e)
        {
            if(St_parcelas)
                CD_CondPGTO_Leave(this, new EventArgs());
            St_parcelas = true;
        }

        private void DT_Pedido_Leave(object sender, EventArgs e)
        {
            CalcularDtValidade();
        }

        private void ST_ComEntrada_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_Entrada.Visible = ST_ComEntrada.Checked;
            VL_Entrada.Visible = ST_ComEntrada.Checked;
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
                if ((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Count > 0)
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
                else
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
        }

        private void bb_calcula_Click(object sender, EventArgs e)
        {
            SimularImpostos();
        }

        private void BS_Parcelas_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Parcelas.Current != null)
            {
                if (ST_ComEntrada.Checked)
                {
                    if (BS_Parcelas.Position.Equals(0))
                    {
                        diasvencimento.Enabled = false;
                        VL_Parcela.Enabled = false;
                    }
                    else
                    {
                        Habilita_Data_Financeiro();
                        VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1); ;
                    }
                }
                else
                {
                    Habilita_Data_Financeiro();
                    VL_Parcela.Enabled = BS_Parcelas.Position != (BS_Parcelas.Count - 1);
                }
            }
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

        private void TFOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gFichaTec);
        }

        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_acrescimo = tot_acrescimo.Value;
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearAcrescimo(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                TotalizarPedido();
            }
        }

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }

        private void bb_cliforind_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforind, nm_cliforind }, string.Empty);
        }

        private void cd_cliforind_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforind.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforind, nm_cliforind },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void tot_comRep_Leave(object sender, EventArgs e)
        {

        }

        private void cd_cidadent_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadent.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                             "a.cd_cidade|Código|60;" +
                             "b.uf|UF|30";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text) || !string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent }, 
                    "a.cd_clifor|=|'" + (!string.IsNullOrEmpty(Cd_cliforent.Text) ? Cd_cliforent.Text : CD_Clifor.Text) + "'");
        }

        private void Cd_cliforent_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_cliforent.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforEnt_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_cliforent, nm_cliforEnt }, string.Empty);
        }

        private void Cd_enderecoent_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text) || !string.IsNullOrEmpty(Cd_cliforent.Text))
                UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + (!string.IsNullOrEmpty(Cd_cliforent.Text) ? Cd_cliforent.Text : CD_Clifor.Text) + "'"
                                                        , new Componentes.EditDefault[] { Cd_enderecoent, logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularDtValidade();
        }

        private void Pc_DescGeral_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if (VerificarTotDesconto(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento))
                    {
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_desconto = Pc_DescGeral.Value;
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearDesconto(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, true);
                        TotalizarPedido();
                    }
                    else
                    {
                        Pc_DescGeral.Value = decimal.Zero;
                        VL_Desconto_Geral.Value = decimal.Zero;
                        Pc_DescGeral.Focus();
                    }
                if (Pc_DescGeral.Value == decimal.Zero || VL_Desconto_Geral.Value == decimal.Zero)
                {
                    VL_Desconto_Geral.Value = decimal.Zero;
                    Pc_DescGeral.Value = decimal.Zero;
                    TotalizarPedido();
                }
            }
        }

        private void VL_Desconto_Geral_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                //if (Math.Round((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_desconto, 2, MidpointRounding.AwayFromZero) !=
                //    Math.Round(VL_Desconto_Geral.Value, 2, MidpointRounding.AwayFromZero))
                //{

                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_desconto = VL_Desconto_Geral.Value;
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearDesconto(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, false);
                    TotalizarPedido();
                    if (!VerificarTotDesconto(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento))
                    {
                        Pc_DescGeral.Value = decimal.Zero;
                        VL_Desconto_Geral.Value = decimal.Zero;
                        VL_Desconto_Geral.Focus();
                    }
                //}else

                //if (Pc_DescGeral.Value == decimal.Zero || VL_Desconto_Geral.Value == decimal.Zero)
                //{
                //    VL_Desconto_Geral.Value = decimal.Zero;
                //    Pc_DescGeral.Value = decimal.Zero;
                //    TotalizarPedido();
                //}

            }
        }

        private void VL_Desconto_Geral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                VL_Desconto_Geral_Leave(this, new EventArgs());
                VL_Desconto_Geral.Focus();
            }
        }

        private void Pc_DescGeral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Pc_DescGeral_Leave(this, new EventArgs());
                Pc_DescGeral.Focus();
            }
        }

        private void bb_gerente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_gerente, nm_gerente }, string.Empty);
        }

        private void cd_gerente_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_gerente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_gerente, nm_gerente },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void CD_CondPGTO_Enter(object sender, EventArgs e)
        {
            Cd_condPagtoOld = CD_CondPGTO.Text;
        }
    }
}
