using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Fiscal;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Orcamento;

namespace Faturamento
{
    public partial class TFProposta : Form
    {
        private bool St_insert = false;
        private decimal vVl_pedido { get; set; }
        private string Ds_fichaTec = string.Empty;
        public bool St_editar { get; set; }
        public bool St_parcelas
        { get; set; }
        public string Cd_vendedorOld
        { get; set; }
        private bool St_informarpreco = false;
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;
        private TRegistro_Orcamento rorcamento;
        public TRegistro_Orcamento rOrcamento
        {
            get
            {
                if (bsOrcamento.Current != null)
                    return bsOrcamento.Current as TRegistro_Orcamento;
                else
                    return null;
            }
            set
            { rorcamento = value; }
        }
        private string Cd_condPagtoOld = string.Empty;
        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;
        //private string LoginDesconto = string.Empty;

        private decimal Pc_descOld
        { get; set; }

        public TFProposta()
        {
            InitializeComponent();
            St_editar = true;
            rorcamento = null;
            St_parcelas = false;
            rProg = null;
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
                bsOrcamento.DataSource = new TList_Orcamento() { rorcamento };
                TotalizarPedido();
                Pc_descOld = Pc_DescGeral.Value;
                cbEmpresa.Focus();
                Cd_vendedorOld = CD_CompVend.Text;
                bsItens_PositionChanged(this, new EventArgs());
                if (rorcamento.lParc.Count() > 0)
                {
                    CD_Clifor.Enabled = false;
                    BB_Clifor.Enabled = false;
                    CD_CondPGTO.Enabled = false;
                    BB_CondPGTO.Enabled = false;
                    VL_Parcela.Enabled = false;
                    vVl_pedido = tot_liquido.Value;
                }
            }
            else
            {
                bsOrcamento.AddNew();
                cbEmpresa.SelectedIndex = 0;
                cbEmpresa.Focus();
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
                cd_produto.Clear();
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearFrete(bsOrcamento.Current as TRegistro_Orcamento);
                if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Count > 0)
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Exists(p => p.Pc_desconto > decimal.Zero))
                        Pc_DescGeral.Value = Math.Round((bsOrcamento.Current as TRegistro_Orcamento).lItens.Where(p => p.Pc_desconto > decimal.Zero).Average(p => p.Pc_desconto), 2, MidpointRounding.AwayFromZero);
                    else
                        Pc_DescGeral.Value = decimal.Zero;
                }
                else
                {
                    Pc_DescGeral.Value = decimal.Zero;
                    pc_comrep.Value = decimal.Zero;
                }
                VL_Desconto_Geral.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_desconto);
                tot_acrescimo.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_acrescimo);
                vl_frete.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_frete);
                tot_custo.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_custototal);
                tot_itens.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotal);
                if (tot_liquido.Value > decimal.Zero)
                {
                    if (tot_liquido.Value >= tot_custo.Value + tot_impostos.Value)
                    {
                        vl_lucro.Value = tot_liquido.Value - tot_custo.Value - tot_impostos.Value;
                        lblVlLucro.Text = "Valor Lucro";
                        pc_lucro.Value = Math.Round(100 - ((tot_custo.Value + tot_impostos.Value) * 100 / tot_liquido.Value), 2, MidpointRounding.AwayFromZero);
                        lblLucro.Text = "% Lucro";
                        lblLucro.ForeColor = Color.Blue;
                    }
                    else
                    {
                        vl_lucro.Value = tot_custo.Value + tot_impostos.Value - tot_liquido.Value;
                        lblVlLucro.Text = "Valor Perda";
                        pc_lucro.Value = Math.Round(((tot_custo.Value + tot_impostos.Value) * 100 / tot_liquido.Value) - 100, 2, MidpointRounding.AwayFromZero);
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
                diasvencimento.Enabled = (bsOrcamento.Current as TRegistro_Orcamento).ST_SolicitarDtVencto.Trim().ToUpper().Equals("S") &&
                    (ST_ComEntrada.Checked ? BS_Parcelas.Position > 0 : true);
        }

        private void AjustarDadosFinanceiros()
        {
            //Chamado ao se dar leave no campo Cond. PGTO
            if (bsOrcamento.Current != null)
            {
                Habilita_Data_Financeiro();
                if (!Parcelas_Entrada.Text.Trim().Equals("S"))
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Calcula_Parcelas(bsOrcamento.Current as TRegistro_Orcamento);
                    bsOrcamento.ResetCurrentItem();
                    BS_Parcelas_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void CalcularValorPedidoItem()
        {
            if (bsOrcamento.Current != null)
                (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p =>
                    p.Vl_juro_fin = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.CalcularValorJuroFin(
                                                                                                            new CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto()
                                                                                                            {
                                                                                                                Pc_jurodiario_atrazoFin = (bsOrcamento.Current as TRegistro_Orcamento).Pc_jurodiario_atrazo,
                                                                                                                Tp_juro_fin = (bsOrcamento.Current as TRegistro_Orcamento).Tp_juro,
                                                                                                                Qt_diasdesdobro = (bsOrcamento.Current as TRegistro_Orcamento).Qt_diasdesdobro,
                                                                                                                St_comentradabool = (bsOrcamento.Current as TRegistro_Orcamento).St_cometrada,
                                                                                                                Qt_parcelas = (bsOrcamento.Current as TRegistro_Orcamento).QTD_Parcelas
                                                                                                            },
                                                                                                            p.Vl_subtotal));
        }

        private void CalcularDtValidade()
        {
            if (bsOrcamento.Current != null)
                if ((bsOrcamento.Current as TRegistro_Orcamento).Dt_validade == null)
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.CalcularDtValidade(bsOrcamento.Current as TRegistro_Orcamento);
                    bsOrcamento.ResetCurrentItem();
                }
        }

        private void BuscarPromocao(TRegistro_Orcamento_Item rItem)
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
                        if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).Sum(p => p.Quantidade) + rItem.Quantidade >= rPro.Qtd_minimavenda)
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals(rItem.Cd_produto.Trim())).ToList().ForEach(p =>
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
            //Testar vl_unitario
            if (vl_unitario.Focused)
                vl_unitario_Leave(this, new EventArgs());
            if (vl_unitario.Value.Equals(0) && St_insert &&
                !(bsItens.Current as TRegistro_Orcamento_Item).St_projespecialbool)
            {
                tcOrcamento.SelectedTab = tpItens;
                vl_unitario.Focus();
                return;
            }
            decimal cont = (bsOrcamento.Current as TRegistro_Orcamento).NR_Versao;
            if (!tcOrcamento.SelectedTab.Equals(tpOrcamento))
                tcOrcamento.SelectedTab = tpOrcamento;
            if (pDados.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr) &&
                    (bsOrcamento.Current as TRegistro_Orcamento).St_registro.ToUpper().Equals("AB"))
                {
                    if (new TCD_Orcamento().BuscarEscalar(
                         new TpBusca[]
                         {
                             new TpBusca()
                             {
                                 vNM_Campo = "a.cd_empresa",
                                 vOperador = "=",
                                 vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                             },
                             new TpBusca()
                             {
                                 vNM_Campo = "a.nr_orcamento",
                                 vOperador = "=",
                                 vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr
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
                if ((bsOrcamento.Current as TRegistro_Orcamento).lParc.Count() > 0 && 
                    !vVl_pedido.Equals((bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq) +
                                       (bsOrcamento.Current as TRegistro_Orcamento).Vl_impostosomar -
                                       (bsOrcamento.Current as TRegistro_Orcamento).Vl_impostosubtrair))
                {
                    MessageBox.Show("Não é permitido alterar valor pedido que possui duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar orçamento sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Validar Venda Abaixo Custo 
                if((bsOrcamento.Current as TRegistro_Orcamento).lItens.Exists(x=> decimal.Divide(x.Vl_subtotalliq, x.Quantidade) < x.Vl_custo && string.IsNullOrWhiteSpace(x.Logincusto)))
                {
                    //Verificar se usuario atual tem acesso a regra venda abaixo do custo
                    string login = Utils.Parametros.pubLogin;
                    if(!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(login, "PERMITIR VENDA ABAIXO CUSTO", null))
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR VENDA ABAIXO CUSTO";
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                login = fRegra.Login;
                            else
                            {
                                MessageBox.Show("Usuário não tem permissão para VENDA ABAIXO CUSTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    InputBox ip = new InputBox();
                    ip.Text = "Motivo Venda Abaixo Custo";
                    string motivo = ip.ShowDialog();
                    if (string.IsNullOrWhiteSpace(motivo))
                    {
                        MessageBox.Show("Obrigatório informar motivo para venda abaixo do custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.FindAll(x => decimal.Divide(x.Vl_subtotalliq, x.Quantidade) < x.Vl_custo && string.IsNullOrWhiteSpace(x.Logincusto))
                        .ForEach(x =>
                        {
                            x.Logincusto = login;
                            x.Ds_motabaixocusto = motivo;
                        });
                }
                if (!ValidarDescontos())
                    return;
                if (!string.IsNullOrEmpty(cd_representante.Text) && pc_comrep.Value.Equals(decimal.Zero))
                    if (MessageBox.Show("Informado representante no orçamento e não informado % COMISSÃO para o mesmo.\r\n" +
                                       "Confirma gravar orçamento sem % COMISSÃO para o representante?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        if (!tcOrcamento.SelectedTab.Equals(tpOrcamento))
                            tcOrcamento.SelectedTab = tpOrcamento;
                        pc_comrep.Focus();
                        return;
                    }
                NR_Versao.Text = (cont + 1).ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lItensDel.Add(
                        bsItens.Current as TRegistro_Orcamento_Item);
                    //Verificar se item possui promocao
                    CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                        CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                    (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                    (bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo,
                                                                                                    null,
                                                                                                    decimal.Zero,
                                                                                                    null);
                    if (rPro != null)
                        if (rPro.Qtd_minimavenda > 1)
                            if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim())).Sum(p => p.Quantidade) -
                                (bsItens.Current as TRegistro_Orcamento_Item).Quantidade < rPro.Qtd_minimavenda)
                            {
                                //Verificar se tem programacao especial de venda
                                CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProgAux =
                                    CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                                 CD_Clifor.Text,
                                                                                                                 (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                                 CD_TabelaPreco.Text,
                                                                                                                 null);
                                (bsOrcamento.Current as TRegistro_Orcamento).lItens.Where(p => p.Cd_produto.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim())).ToList().ForEach(p =>
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
                if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido))
                {
                    auxCfg = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
                    fSimular.pCfg_pedido = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
                    fSimular.pDs_tipopedido = (bsOrcamento.Current as TRegistro_Orcamento).Ds_tipopedido;
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
                        auxCfg = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
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
                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p =>
                    {
                        fSimular.lProdSimular.Add(
                            new TRegistro_ProdutoSimular()
                            {
                                Cd_produto = p.Cd_produto,
                                Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                Ds_condfiscal_produto = p.Ds_condfiscal_produto,
                                Ds_produto = p.Ds_produto,
                                Quantidade = p.Quantidade,
                                Sg_unidade = p.Sigla_unid_produto,
                                Ncm = p.NCM,
                                Vl_unitario = p.Vl_unitario
                            });
                    });
                if (fSimular.ShowDialog() == DialogResult.OK)
                {
                    if (((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() != fSimular.Cd_empresasimular.Trim()) &&
                        string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_tabelapreco))
                        if (MessageBox.Show("Deseja trocar empresa do orçamento para a empresa da simulação imposto?", "Pergunta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cbEmpresa.SelectedValue = fSimular.Cd_empresasimular;
                            CalcularDtValidade();
                        }
                    if (auxCfg.Trim() != fSimular.Cfg_pedidosimular.Trim())
                        (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido = fSimular.Cfg_pedidosimular;
                }
            }
        }

        private bool ValidarDescontos()
        {
            if (DialogResult == DialogResult.Cancel)
                return false;
            if ((bsOrcamento.Current as TRegistro_Orcamento).Vl_totalitens.Equals(decimal.Zero))
                return true;
            if (Pc_DescGeral.Value.Equals(decimal.Zero))
                Pc_DescGeral.Value = VL_Desconto_Geral.Value * 100 / (bsOrcamento.Current as TRegistro_Orcamento).Vl_totalitens;
            decimal pc_desc = Math.Round(decimal.Add(Pc_DescGeral.Value, (bsOrcamento.Current as TRegistro_Orcamento).lItens.Average(x => x.PcDescUnit)), 2, MidpointRounding.AwayFromZero);
            if ((Pc_descOld > decimal.Zero) && Pc_descOld.Equals(Pc_DescGeral.Value))
                return true;
            for (int i = 0; i < ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Count); i++)
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
                                            p.Cd_grupo.Trim().Equals((bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals((bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (pc_desc > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_grupo = (bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo;
                                    fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                    fLogin.Pc_desc = pc_desc;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(x=> x.LoginDesc = fLogin.Logindesconto);
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
                            if (pc_desc > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                    fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                    fLogin.Pc_desc = pc_desc;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(x=> x.LoginDesc = fLogin.Logindesconto);
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                    //Desconto por grupo de produto
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                        if (pc_desc > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = (bsOrcamento.Current as TRegistro_Orcamento).lItens[i].Cd_grupo;
                                fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                fLogin.Pc_desc = pc_desc;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                    return false;
                                else
                                {
                                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(x=> x.LoginDesc = fLogin.Logindesconto);
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    //Desconto por vendedor e empresa
                    if (pc_desc > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fLogin.Pc_desc = pc_desc;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                                return false;
                            else
                            {
                                (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(x=> x.LoginDesc = fLogin.Logindesconto);
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
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
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
                                (bsOrcamento.Current as TRegistro_Orcamento).lItens.Add(
                                    new TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = p.CD_ProdVenda,
                                        Ds_produto = p.DS_ProdVenda,
                                        Cd_unid_produto = p.CD_Unidade,
                                        Ds_unid_produto = p.DS_Unidade,
                                        Sigla_unid_produto = p.Sigla_Unidade,
                                        NCM = p.NCM,
                                        Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rOrcamento.Cd_empresa, p.CD_ProdVenda, rOrcamento.Cd_tabelapreco, null),
                                        Quantidade = p.Quantidade,
                                        Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlUltimaCompra(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(), p.CD_ProdVenda, null)
                                    }));
                                bsOrcamento.ResetCurrentItem();
                            }
                    }
                }
            }
        }

        private bool VerificarTotDesconto(TRegistro_Orcamento val)
        {
            if (string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pc_DescGeral.Value = decimal.Zero;
                VL_Desconto_Geral.Value = decimal.Zero;
                return false;
            }
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
                                        (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                        //LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                        }
                        else if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
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
                                        (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                        //LoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                        }
                    //Desconto por grupo de produto
                    if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
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
                                    (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                    //LoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                    }
                    //Desconto por vendedor e empresa
                    else if (Pc_DescGeral.Value > lDesc[0].Pc_max_desconto)
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
                                (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                //LoginDesconto = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                }
                else return true;
            }
            return true;
        }

        private void BuscarSaldoEstoque()
        {
            //Buscar Qtd Estoque
            object qtdestoque = new CamadaDados.Estoque.TCD_LanEstoque().BuscarSaldo_EstoqueEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim() + "'"
                    }
                }, "a.tot_saldo");
            if (qtdestoque == null ? false : !string.IsNullOrEmpty(qtdestoque.ToString()))
                lbQtdEstoque.Text = decimal.Parse(qtdestoque.ToString()).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            else
                lbQtdEstoque.Text = "0,000";
            //Buscar Qtd Reservada
            object qtdreservada = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "n.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "n.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "sum(isnull(a.quantidade, 0)) - sum(isnull(a.qtd_faturada, 0)) + sum(isnull(a.qtd_devolvida, 0))");
            if (qtdreservada == null ? false : !string.IsNullOrEmpty(qtdreservada.ToString()))
                lbQtdReservada.Text = decimal.Parse(qtdreservada.ToString()).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            else
                lbQtdReservada.Text = "0,000";
            //Buscar Qtd Reservada
            object qtdrequisitada = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "n.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "n.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "sum(isnull(a.quantidade, 0)) - sum(isnull(a.qtd_faturada, 0)) + sum(isnull(a.qtd_devolvida, 0))");
            if (qtdrequisitada == null ? false : !string.IsNullOrEmpty(qtdrequisitada.ToString()))
                lbQtdRequisitada.Text = decimal.Parse(qtdrequisitada.ToString()).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            else
                lbQtdRequisitada.Text = "0,000";
            //Calcular Qtd.Disponível
            lbDisponivel.Text = (Convert.ToDecimal(lbQtdEstoque.Text) - 
                                 Convert.ToDecimal(lbQtdReservada.Text) + 
                                 Convert.ToDecimal(lbQtdRequisitada.Text)).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void BuscarProduto()
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
                cd_produto.Clear();
                cd_produto.Focus();
                return;
            }
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                   (bsOrcamento.Current as TRegistro_Orcamento).Nm_empresa,
                                                   CD_TabelaPreco.Text,
                                                   new Componentes.EditDefault[] { cd_produto },
                                                   null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                   (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                   (bsOrcamento.Current as TRegistro_Orcamento).Nm_empresa,
                                                   CD_TabelaPreco.Text,
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
                //Buscar Promocao
                BuscarPromocao(bsItens.Current as TRegistro_Orcamento_Item);
                bsItens_PositionChanged(this, new EventArgs());
                bsOrcamento.ResetCurrentItem();
                BuscarFichaTecItem();
                TotalizarPedido();
                BuscarSaldoEstoque();
                Quantidade.Focus();
            }
            else
            {
                cd_produto.Clear();
                cd_produto.Focus();
            }
            //LoginDesconto = string.Empty;
        }

        private decimal BuscarPreco()
        {
            //Verificar se existe programacao especial de venda 
            rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                                 (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                 cd_produto.Text,
                                                                                                 CD_TabelaPreco.Text,
                                                                                                 null);
            if (rProg != null)
                if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                    return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                            (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto, null);
                else
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                                (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                CD_TabelaPreco.Text,
                                                                                                null);
            else if ((!string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto)) &&
                (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa)) &&
                (!string.IsNullOrEmpty(CD_TabelaPreco.Text)))
                return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                            (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                            CD_TabelaPreco.Text,
                                                                                            null);
            else return decimal.Zero;
        }

        private void ConsultaPreco()
        {
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = BuscarPreco();
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela = (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario;
            bsItens.ResetCurrentItem();
            //Buscar custo produto
            (bsItens.Current as TRegistro_Orcamento_Item).Vl_custo =
            CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlUltimaCompra((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                      cd_produto.Text, null);
            CalcularDescEspecial();
            St_informarpreco = CD_TabelaPreco.Text.Trim().Equals(string.Empty) ||
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

        private bool CalcularDescontos(bool St_percentual)
        {
            if (string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Informe o Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (St_percentual)
                {
                    pc_desconto.Value = decimal.Zero;
                    vl_descontoItem.Value = decimal.Zero;
                    pc_desconto.Focus();
                    return false;
                }
                else
                {
                    vl_descontoItem.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    vl_descontoItem.Focus();
                    return false;
                }
            }
            object obj_logindesc = null;
            if (!string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).LoginDesc))
            {
                if ((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal > 0)
                {
                    if (vl_descontoItem.Focused)
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto = vl_descontoItem.Value;
                    if (pc_desconto.Focused)
                        (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto = pc_desconto.Value;
                    if (St_percentual)
                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto =
                            Math.Round((bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal *
                            ((bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto / 100), 2, MidpointRounding.AwayFromZero);
                    else
                        (bsItens.Current as TRegistro_Orcamento_Item).Pc_desconto =
                            Math.Round((bsItens.Current as TRegistro_Orcamento_Item).Vl_desconto * 100 /
                            (bsItens.Current as TRegistro_Orcamento_Item).Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                }
                else
                    return false;
                //Buscar Vendedor
                obj_logindesc = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
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
                                        vNM_Campo = "isnull(a.st_funcativo, 'S')",
                                        vOperador = "<>",
                                        vVL_Busca = "'N'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.LoginVendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc.Trim() + "'"
                                    }
                                }, "a.cd_clifor");
            }
            //Buscar lista de descontos configuradas para o vendedor
            CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(obj_logindesc == null ? CD_CompVend.Text : obj_logindesc.ToString(),
                                                                                (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            if (lDesc.Count > 0)
            {
                decimal pc_desc = pc_desconto.Value;
                if(vl_unitario.Value < vl_tabela.Value)
                    pc_desc = decimal.Divide(decimal.Multiply(decimal.Multiply(decimal.Subtract(vl_tabela.Value, vl_unitario.Value), Quantidade.Value), 100),
                                               decimal.Multiply(Quantidade.Value, vl_tabela.Value)); 
                if (!string.IsNullOrEmpty(CD_TabelaPreco.Text))
                    if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                        p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo.Trim())))
                    {
                        //Desconto por tabela de preco e grupo de produto
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim()) &&
                                                                p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo.Trim())).Pc_max_desconto;
                        if (pc_desc > pc_max_desc)
                        {
                            MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa; ;
                                fLogin.Pc_desc = pc_desc;
                                fLogin.Cd_grupo = (bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                    if (vl_unitario.Value < vl_tabela.Value)
                                    {
                                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = vl_tabela.Value;
                                        pc_desconto.Enabled = true;
                                        vl_descontoItem.Enabled = true;
                                        vl_unitario.Focus();
                                    }
                                    else
                                    {
                                        vl_descontoItem.Value = decimal.Zero;
                                        pc_desconto.Value = decimal.Zero;
                                        pc_desconto.Focus();
                                    }
                                    bsItens.ResetCurrentItem();
                                    TotalizarPedido();
                                    return false;
                                }
                                else
                                {
                                    bsItens.ResetCurrentItem();
                                    TotalizarPedido();
                                    (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            bsItens.ResetCurrentItem();
                            TotalizarPedido();
                            return true;
                        }
                    }
                    else if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())))
                    {
                        //Desconto por tabela de preço
                        decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_grupo) && p.Cd_tabelapreco.Trim().Equals(CD_TabelaPreco.Text.Trim())).Pc_max_desconto;
                        if (pc_desc > pc_max_desc)
                        {
                            MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_tabelapreco = CD_TabelaPreco.Text;
                                fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa; ;
                                fLogin.Pc_desc = pc_desc;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                {
                                    (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                    if (vl_unitario.Value < vl_tabela.Value)
                                    {
                                        (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = vl_tabela.Value;
                                        pc_desconto.Enabled = true;
                                        vl_descontoItem.Enabled = true;
                                        vl_unitario.Focus();
                                    }
                                    else
                                    {
                                        vl_descontoItem.Value = decimal.Zero;
                                        pc_desconto.Value = decimal.Zero;
                                        pc_desconto.Focus();
                                    }
                                    bsItens.ResetCurrentItem();
                                    TotalizarPedido();
                                    return false;
                                }
                                else
                                {
                                    bsItens.ResetCurrentItem();
                                    TotalizarPedido();
                                    (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            bsItens.ResetCurrentItem();
                            TotalizarPedido();
                            return true;
                        }
                    }
                //Desconto por grupo de produto
                if (lDesc.Exists(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo.Trim())))
                {
                    decimal pc_max_desc = lDesc.Find(p => string.IsNullOrEmpty(p.Cd_tabelapreco) && p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo.Trim())).Pc_max_desconto;
                    if (pc_desc > pc_max_desc)
                    {
                        MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_grupo = (bsItens.Current as TRegistro_Orcamento_Item).Cd_grupo;
                            fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fLogin.Pc_desc = pc_desc;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                            {
                                (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                if (vl_unitario.Value < vl_tabela.Value)
                                {
                                    (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = vl_tabela.Value;
                                    pc_desconto.Enabled = true;
                                    vl_descontoItem.Enabled = true;
                                    vl_unitario.Focus();
                                }
                                else
                                {
                                    vl_descontoItem.Value = decimal.Zero;
                                    pc_desconto.Value = decimal.Zero;
                                    pc_desconto.Focus();
                                }
                                bsItens.ResetCurrentItem();
                                TotalizarPedido();
                                return false;
                            }
                            else
                            {
                                bsItens.ResetCurrentItem();
                                TotalizarPedido();
                                (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        bsItens.ResetCurrentItem();
                        TotalizarPedido();
                        return true;
                    }
                }
                //Desconto por vendedor e empresa
                if (pc_desc > lDesc[0].Pc_max_desconto)
                {
                    MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chamar tela de usuario com autorizacao para o % desconto solicitado
                    using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                    {
                        fLogin.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        fLogin.Pc_desc = pc_desc;
                        if (fLogin.ShowDialog() != DialogResult.OK)
                        {
                            (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;
                            if (vl_unitario.Value < vl_tabela.Value)
                            {
                                (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario = vl_tabela.Value;
                                pc_desconto.Enabled = true;
                                vl_descontoItem.Enabled = true;
                                vl_unitario.Focus();
                            }
                            else
                            {
                                vl_descontoItem.Value = decimal.Zero;
                                pc_desconto.Value = decimal.Zero;
                                pc_desconto.Focus();
                            }
                            bsItens.ResetCurrentItem();
                            TotalizarPedido();
                            return false;
                        }
                        else
                        {
                            bsItens.ResetCurrentItem();
                            TotalizarPedido();
                            (bsItens.Current as TRegistro_Orcamento_Item).LoginDesc = fLogin.Logindesconto;

                            ///sumarry
                            ///adicionado linha 1428, caso o usuário informado tenha autorização para efetuar a autorização do processo
                            ///é atribuido ao logincusto
                            (bsItens.Current as TRegistro_Orcamento_Item).Logincusto = fLogin.Logindesconto;
                            return true;
                        }
                    }
                }
                else
                {
                    bsItens.ResetCurrentItem();
                    TotalizarPedido();
                    return true;
                }
            }
            else
            {
                bsItens.ResetCurrentItem();
                TotalizarPedido();
                return true;
            }
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
                TotalizarPedido();
            }
        }

        private void BuscarFichaTecItem()
        {
            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto))
            {
                try
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).lFichaTec =
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.MontarFichaTecPropostaItem((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                                          cbEmpresa.SelectedValue.ToString(),
                                                                                                          CD_TabelaPreco.Text,
                                                                                                          Quantidade.Value,
                                                                                                          null);
                    bsItens.ResetCurrentItem();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void TFProsposta_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pCondPgto.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
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
            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null))
                tlpImpostos.ColumnStyles[1].Width = 260;
            else tlpImpostos.ColumnStyles[1].Width = 0;
            if (!St_editar)
            {
                cbEmpresa.Enabled = false;
                CD_Clifor.Enabled = false;
                BB_Clifor.Enabled = false;
                bb_cadclifor.Enabled = false;
                NM_Clifor.Enabled = false;
                DT_Pedido.Enabled = false;
                dt_validade.Enabled = false;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                DS_Endereco.Enabled = false;
                DS_Cidade.Enabled = false;
                UF.Enabled = false;
                Fone.Enabled = false;
                cd_representante.Enabled = false;
                bb_representante.Enabled = false;
                nm_representante.Enabled = false;
                pc_comrep.Enabled = false;
                CD_TabelaPreco.Enabled = false;
                BB_TabelaPreco.Enabled = false;
                st_registro.Enabled = false;
                NR_Versao.Enabled = false;
                tp_descarga.Enabled = false;
                tp_frete.Enabled = false;
                PrazoEntrega.Enabled = false;
                DS_Observacao.Enabled = false;

                TS_ItensPedido.Enabled = false;
                pDadosComp.Enabled = false;
                pCondPgto.Enabled = false;
                pParcelas.Enabled = false;
                bb_inutilizar.Enabled = false;
                pInserirItens.Enabled = false;
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
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
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
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
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
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
            string cond = "isnull(a.st_vendedor, 'N')|=|'S';" +
                          "isnull(a.st_funcativo, 'N')|=|'S';" +
                          "||(a.LoginVendedor in('MASTER', '" + Utils.Parametros.pubLogin.Trim() + "') or exists(select 1 from TB_DIV_Usuario_X_RegraEspecial x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.DS_Regra = 'PERMITIR ALTERAR PEDIDO OUTROS VENDEDORES'))";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, cond);
            if (!St_editar && !Cd_vendedorOld.Equals(CD_CompVend.Text))
                try
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.AlterarVendedor(bsOrcamento.Current as TRegistro_Orcamento, null);
                    MessageBox.Show("Vendedor alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string cond = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                          "isnull(a.st_vendedor, 'N')|=|'S';" +
                          "isnull(a.st_funcativo, 'N')|=|'S';" +
                          "||(a.LoginVendedor in('MASTER', '" + Utils.Parametros.pubLogin.Trim() + "') or exists(select 1 from TB_DIV_Usuario_X_RegraEspecial x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.DS_Regra = 'PERMITIR ALTERAR PEDIDO OUTROS VENDEDORES'))";
            UtilPesquisa.EDIT_LeaveClifor(cond, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!St_editar && !Cd_vendedorOld.Equals(CD_CompVend.Text))
                try
                {
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.AlterarVendedor(bsOrcamento.Current as TRegistro_Orcamento, null);
                    MessageBox.Show("Vendedor alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            //Verificar se cliente possui tab preco
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
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
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
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

        private void TFProsposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (St_editar && e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F9))
                SimularImpostos();
            else if (St_editar && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
            else if (e.KeyCode.Equals(Keys.F12) && St_editar)
                BuscarProduto();
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
            if (bsItens.Count > 0)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Vl_frete = vl_frete.Value;
                TotalizarPedido();
            }
            else
            {
                MessageBox.Show("Para informar valor do frete, é preciso inserir os itens da proposta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_frete.Value = decimal.Zero;
            }
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            if (Cd_condPagtoOld.Trim().Equals(CD_CondPGTO.Text.Trim()) &&
                Math.Round(tot_liquido.Value, 2, MidpointRounding.AwayFromZero).Equals(Math.Round((BS_Parcelas.List as TList_Orcamento_DT_Vencto).Sum(p=> p.Vl_parcela), 2, MidpointRounding.AwayFromZero)))
                return;
            string vParam = "CD_CondPGTO|=|'" + CD_CondPGTO.Text.Trim() + "'";
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

            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Calcula_Parcelas(bsOrcamento.Current as TRegistro_Orcamento);

            for (int x = 0; x < (bsOrcamento.Current as TRegistro_Orcamento).lParcelas.Count; x++)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lParcelas[x].Vl_entrada = VL_Entrada.Value;
                if (x == 0)
                    (bsOrcamento.Current as TRegistro_Orcamento).lParcelas[x].Vl_parcela = VL_Entrada.Value;
            }

            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Recalcula_Parcelas(bsOrcamento.Current as TRegistro_Orcamento, 0);
            bsOrcamento.ResetCurrentItem();
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lParcelas[BS_Parcelas.Position].Vl_parcela = VL_Parcela.Value;
                recalcularParcelas();

                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Recalcula_Parcelas(bsOrcamento.Current as TRegistro_Orcamento, BS_Parcelas.Position);
                bsOrcamento.ResetCurrentItem();
            }
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

        private void tot_liquido_ValueChanged(object sender, EventArgs e)
        {
            if (St_parcelas)
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
                BuscarSaldoEstoque();
                St_informarpreco = CD_TabelaPreco.Text.Trim().Equals(string.Empty) ||
                                (bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario.Equals(decimal.Zero) ||
                                CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                             "PERMITIR INFORMAR PREÇO VENDA",
                                                                                             null);
                pc_desconto.Enabled = !((bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario < (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela);
                vl_descontoItem.Enabled = !((bsItens.Current as TRegistro_Orcamento_Item).Vl_unitario < (bsItens.Current as TRegistro_Orcamento_Item).Vl_tabela);
                vl_unitario.Enabled = St_informarpreco && pc_desconto.Value.Equals(decimal.Zero);
                Pc_DescGeral.Enabled = !(bsItens.List as TList_Orcamento_Item).Exists(x => x.Vl_unitario < x.Vl_tabela);
                VL_Desconto_Geral.Enabled = !(bsItens.List as TList_Orcamento_Item).Exists(x => x.Vl_unitario < x.Vl_tabela);
                DS_Produto.Enabled = string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto) && St_insert;
                bb_incluirProduto.Visible = string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto);
                St_insert = true;
            }
            else St_insert = false;
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
            if (!CamadaNegocio.Diversos.TCN_CadAcesso.AcessarMenu(055600))
            {
                MessageBox.Show("Usuário sem permissão de menu para acessar funcionalidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private void TFProsposta_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            if (this.DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("Alguns dados ainda não foram salvos!\r\n" +
                                    "Deseja sair da tela de proposta?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Vl_acrescimo = tot_acrescimo.Value;
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearAcrescimo(bsOrcamento.Current as TRegistro_Orcamento);
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
                if (Math.Round((bsOrcamento.Current as TRegistro_Orcamento).Pc_desconto, 2, MidpointRounding.AwayFromZero) !=
                    Math.Round(Pc_DescGeral.Value, 2, MidpointRounding.AwayFromZero))
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_desconto = Pc_DescGeral.Value;
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearDesconto(bsOrcamento.Current as TRegistro_Orcamento, true);
                    TotalizarPedido();
                }
        }

        private void VL_Desconto_Geral_Leave(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
                if (Math.Round((bsOrcamento.Current as TRegistro_Orcamento).Vl_desconto, 2, MidpointRounding.AwayFromZero) !=
                    Math.Round(VL_Desconto_Geral.Value, 2, MidpointRounding.AwayFromZero))
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).Vl_desconto = VL_Desconto_Geral.Value;
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.RatearDesconto(bsOrcamento.Current as TRegistro_Orcamento, false);
                    TotalizarPedido();
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

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void bb_alterarDs_Tecnica_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                using (TFDs_FichaTec fDs_tec = new TFDs_FichaTec())
                {
                    if (string.IsNullOrEmpty((bsItens.Current as TRegistro_Orcamento_Item).Ds_Fichatec))
                        fDs_tec.Ds_fichaTec = Ds_fichaTec;
                    else
                        fDs_tec.Ds_fichaTec = (bsItens.Current as TRegistro_Orcamento_Item).Ds_Fichatec.Trim();
                    if (fDs_tec.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fDs_tec.Ds_fichaTec))
                            (bsItens.Current as TRegistro_Orcamento_Item).Ds_Fichatec =
                                fDs_tec.Ds_fichaTec.Trim();
                }
            }
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
                BuscarPromocao(bsItens.Current as TRegistro_Orcamento_Item);
                bsItens.ResetCurrentItem();
                bsItens_PositionChanged(this, new EventArgs());
                //Totalizar Venda
                TotalizarPedido();
                if (!cd_produto.Focused)
                    if (vl_unitario.Enabled)
                        vl_unitario.Focus();
                    else
                        pc_desconto.Focus();
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
                TotalizarPedido();
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
                    TotalizarPedido();
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
                TotalizarPedido();
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

        private void bb_dadosRep_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
                using (TFCorrigirRepresentante fCorrigir = new TFCorrigirRepresentante())
                {
                    fCorrigir.pCd_representante = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_representante;
                    fCorrigir.pNm_representante = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_representante;
                    fCorrigir.pPc_comrep = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pc_comrep;
                    fCorrigir.pCd_cliforind = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_cliforind;
                    fCorrigir.pNm_cliforind = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_cliforind;
                    fCorrigir.pCd_gerente = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_gerente;
                    fCorrigir.pNm_gerente = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_gerente;
                    if (fCorrigir.ShowDialog() == DialogResult.OK)
                    {
                        string pCd_representante = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_representante;
                        string pNm_representante = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_representante;
                        decimal pPc_comrep = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pc_comrep;
                        string pCd_cliforind = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_cliforind;
                        string pNm_cliforind = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_cliforind;
                        string pCd_gerente = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_gerente;
                        string pNm_gerente = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_gerente;
                        try
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_representante = fCorrigir.pCd_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pc_comrep = fCorrigir.pPc_comrep;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_cliforind = fCorrigir.pCd_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_gerente = fCorrigir.pCd_gerente;
                            //Orçamento
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_representante = fCorrigir.pCd_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).Nm_representante = fCorrigir.pNm_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).Pc_comrep = fCorrigir.pPc_comrep;
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_cliforind = fCorrigir.pCd_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).Nm_cliforind = fCorrigir.pNm_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_gerente = fCorrigir.pCd_gerente;
                            (bsOrcamento.Current as TRegistro_Orcamento).Nm_gerente = fCorrigir.pNm_gerente;
                            System.Collections.Hashtable hs = new System.Collections.Hashtable();
                            hs.Add("@CD_REPRESENTANTE", fCorrigir.pCd_representante);
                            hs.Add("@PC_COMREP", fCorrigir.pPc_comrep);
                            hs.Add("@CD_CLIFORIND", fCorrigir.pCd_cliforind);
                            hs.Add("@CD_GERENTE", fCorrigir.pCd_gerente);
                            hs.Add("@NR_PEDIDO", (bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda);
                            hs.Add("@NR_ORCAMENTO", (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamento);
                            new CamadaDados.TDataQuery().executarSql("update TB_FAT_DadosPedido set CD_REPRESENTANTE = @CD_REPRESENTANTE, " +
                                                                     "PC_COMREP = @PC_COMREP, CD_CLIFORIND = @CD_CLIFORIND, CD_GERENTE = @CD_GERENTE, Dt_alt = GETDATE()  " +
                                                                     "where Nr_pedido = @NR_PEDIDO " +
                                                                     "update TB_FAT_Orcamento set CD_REPRESENTANTE = @CD_REPRESENTANTE, " +
                                                                     "PC_COMREP = @PC_COMREP, CD_CLIFORIND = @CD_CLIFORIND, CD_GERENTE = @CD_GERENTE, Dt_alt = GETDATE()  " +
                                                                     "where NR_Orcamento = @NR_ORCAMENTO ", hs);
                            MessageBox.Show("Proposta alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_representante = fCorrigir.pCd_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_representante = fCorrigir.pNm_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pc_comrep = fCorrigir.pPc_comrep;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_cliforind = fCorrigir.pCd_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_cliforind = fCorrigir.pNm_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_gerente = fCorrigir.pCd_gerente;
                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_gerente = fCorrigir.pNm_gerente;
                            //Orçamento
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_representante = fCorrigir.pCd_representante;
                            (bsOrcamento.Current as TRegistro_Orcamento).Pc_comrep = fCorrigir.pPc_comrep;
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_cliforind = fCorrigir.pCd_cliforind;
                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_gerente = fCorrigir.pCd_gerente;
                        }
                        bsOrcamento.ResetCurrentItem();
                    }
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
                if(vl_unitario.Value < vl_tabela.Value)
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

        private void tcOrcamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcOrcamento.SelectedTab.Equals(tpImpostos))
            {
                if (cbEmpresa.SelectedItem == null)
                {
                    MessageBox.Show("Obrigatorio selecionar empresa para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(CD_Clifor.Text))
                {
                    MessageBox.Show("Obrigatorio informar cliente/fornecedor para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Clifor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CD_Endereco.Text))
                {
                    MessageBox.Show("Obrigatorio informar endereço para simular impostos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Endereco.Focus();
                    return;
                }
                //Buscar movimentacao comercial do tipo de pedido
                CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_cfgorcamento x " +
                                                    "where x.cfg_pedido = a.cfg_pedido " +
                                                    "and x.cd_empresa = '" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "')"
                                    }
                                }, 1, string.Empty);
                if (lCfgPed.Count < 1)
                {
                    MessageBox.Show("Não existe configuração fiscal para o orçamento.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                TList_ResumoImposto lResumo = new TList_ResumoImposto();
                TList_ImpostosNF lImp = new TList_ImpostosNF();
                string Cd_condfiscal_clifor = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                                                 new TpBusca[]
                                                                                 {
                                                                                     new TpBusca()
                                                                                     {
                                                                                         vNM_Campo = "a.cd_clifor",
                                                                                         vOperador = "=",
                                                                                         vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                                                                     }
                                                                                 }, "a.cd_condfiscal_clifor").ToString();
                string tp_pessoa = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                                                 new TpBusca[]
                                                                                 {
                                                                                     new TpBusca()
                                                                                     {
                                                                                         vNM_Campo = "a.cd_clifor",
                                                                                         vOperador = "=",
                                                                                         vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                                                                     }
                                                                                 }, "a.tp_pessoa").ToString();
                string uf_clifor = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                                    new TpBusca[]
                                                                                    {
                                                                                        new TpBusca()
                                                                                        {
                                                                                            vNM_Campo = "a.cd_clifor",
                                                                                            vOperador = "=",
                                                                                            vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'"
                                                                                        },
                                                                                        new TpBusca()
                                                                                        {
                                                                                            vNM_Campo = "a.cd_endereco",
                                                                                            vOperador = "=",
                                                                                            vVL_Busca = "'" + CD_Endereco.Text.Trim() + "'"
                                                                                        }
                                                                                    }, "a.cd_uf").ToString();
                (bsItens.List as TList_Orcamento_Item).ForEach(p =>
                {
                    string retobs = string.Empty;
                    lImp.Concat(TCN_LanFaturamento_Item.procuraImpostosPorUf(cbEmpresa.SelectedValue.ToString(),
                                                                             (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).rEndereco.Cd_uf,
                                                                             uf_clifor,
                                                                             lCfgPed[0].Cd_movtostring,
                                                                             "S",
                                                                             Cd_condfiscal_clifor,
                                                                             p.Cd_condfiscal_produto,
                                                                             p.Vl_subtotal,
                                                                             p.Quantidade,
                                                                             ref retobs,
                                                                             DateTime.Now,
                                                                             p.Cd_produto,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             null));
                    lImp.Concat(TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(Cd_condfiscal_clifor,
                                                                                      p.Cd_condfiscal_produto,
                                                                                      lCfgPed[0].Cd_movtostring,
                                                                                      "S",
                                                                                      tp_pessoa,
                                                                                      cbEmpresa.SelectedValue.ToString(),
                                                                                      lCfgPed[0].Nr_serie,
                                                                                      CD_Clifor.Text,
                                                                                      string.Empty,
                                                                                      DateTime.Now,
                                                                                      p.Quantidade,
                                                                                      p.Vl_subtotal,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null));
                    lImp.ForEach(x =>
                    {
                        if (lResumo.Exists(v => v.Cd_imposto.Trim().Equals(x.Cd_imposto.Value.ToString()) &&
                                                v.St_totalnota.Trim().Equals(x.St_totalnota.Trim())))
                        {
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(x.Cd_impostostr.Trim())).Vl_imposto += x.Vl_impostocalc;
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(x.Cd_impostostr.Trim())).Vl_impostoretido += x.Vl_impostoretido;
                            lResumo.Find(v => v.Cd_imposto.Trim().Equals(x.Cd_impostostr.Trim())).Vl_impostosubstrib += x.Vl_impostosubsttrib;
                            //lResumo.Find(v => v.Cd_imposto.Trim().Equals(x.Cd_impostostr.Trim())).Vl_difsubst += x.Vl_difsubst;
                        }
                        else
                            lResumo.Add(new TRegistro_ResumoImposto()
                            {
                                Cd_imposto = x.Cd_impostostr,
                                Ds_imposto = x.Ds_imposto,
                                Vl_imposto = x.Vl_impostocalc,
                                Vl_impostoretido = x.Vl_impostoretido,
                                Vl_impostosubstrib = x.Vl_impostosubsttrib,
                                //Vl_difsubst = x.Vl_difsubst,
                                St_totalnota = x.St_totalnota
                            });
                    });
                });
                tot_impostos.Value = lResumo.Sum(p => p.Vl_imposto + p.Vl_impostoretido + p.Vl_impostosubstrib + p.Vl_difsubst);
                bsImpostos.DataSource = lResumo;
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsItens.Count > 0)
                if (e.ColumnIndex == 0)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).St_projespecialbool =
                        !(bsItens.Current as TRegistro_Orcamento_Item).St_projespecialbool;
                    bsItens.ResetCurrentItem();
                    if ((bsItens.Current as TRegistro_Orcamento_Item).St_projespecialbool)
                    {
                        //Verificar se item possui mais de uma formulação
                        CamadaDados.Producao.Producao.TList_FormulaApontamento lFormula =
                            CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto,
                                                                                          string.Empty,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);
                        if(lFormula.Count > 1)
                            using (Producao.TFListFormula fLista = new Producao.TFListFormula())
                            {
                                fLista.lFormula = lFormula;
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    (bsItens.Current as TRegistro_Orcamento_Item).Id_formulacao = fLista.rFormula?.Id_formulacao;
                            }
                        else
                            using (TFDs_FichaTec fDs_tec = new TFDs_FichaTec())
                            {
                                fDs_tec.Text = "Descrição";
                                if (fDs_tec.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fDs_tec.Ds_fichaTec))
                                        (bsItens.Current as TRegistro_Orcamento_Item).Ds_projespecial =
                                            fDs_tec.Ds_fichaTec.Trim();
                            }
                        bsItens.ResetCurrentItem();
                    }
                }
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
                bsOrcamento.ResetCurrentItem();
                TotalizarPedido();
            }
            Quantidade.Focus();
        }

        private void DS_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DS_Produto_Leave(this, new EventArgs());
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!St_insert)
            {
                DS_Produto.Enabled = true;
                DS_Produto.Focus();
            }
        }

        private void bb_incluirProduto_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                 (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                 (bsOrcamento.Current as TRegistro_Orcamento).Nm_empresa,
                                                 CD_TabelaPreco.Text,
                                                 new Componentes.EditDefault[] { cd_produto },
                                                 null);

                if (rProd != null)
                {
                    (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto = rProd.CD_Produto;
                    bsItens_PositionChanged(this, new EventArgs());
                    bsOrcamento.ResetCurrentItem();
                }
            }
        }

        private void CD_CondPGTO_Enter(object sender, EventArgs e)
        {
            Cd_condPagtoOld = CD_CondPGTO.Text;
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        if (System.IO.File.Exists(file.FileName))
                        {
                            TRegistro_AnexoItemOrc rAnexo = new TRegistro_AnexoItemOrc();
                            rAnexo.Anexo = System.IO.File.ReadAllBytes(file.FileName);
                            rAnexo.Ext_anexo = System.IO.Path.GetExtension(file.FileName);
                            InputBox ibp = new InputBox();
                            ibp.Text = "Descrição Anexo";
                            string ds = ibp.ShowDialog();
                            if (string.IsNullOrEmpty(ds))
                            {
                                MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            rAnexo.Ds_anexo = ds;
                            (bsItens.Current as TRegistro_Orcamento_Item).lAnexo.Add(rAnexo);
                            bsItens.ResetCurrentItem();
                        }
                    }
                }
            }
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current != null)
                if (MessageBox.Show("Confirma exclusão do anexo selecionado?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    if ((bsAnexo.Current as TRegistro_AnexoItemOrc).Id_anexo.HasValue)
                        (bsItens.Current as TRegistro_Orcamento_Item).lAnexoDel.Add(bsAnexo.Current as TRegistro_AnexoItemOrc);
                    bsAnexo.RemoveCurrent();
                }
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current as TRegistro_AnexoItemOrc != null)
            {
                string ae;
                byte[] arquivoBuffer = (bsAnexo.Current as TRegistro_AnexoItemOrc).Anexo;
                string extensao = (bsAnexo.Current as TRegistro_AnexoItemOrc).Ext_anexo; // retornar do banco tbm
                ae = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);
                System.IO.File.WriteAllBytes(ae, arquivoBuffer);
                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(ae);
            }
        }
    }
}
