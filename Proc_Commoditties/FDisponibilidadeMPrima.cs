using CamadaNegocio.Estoque.Cadastros;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFDisponibilidadeMPrima : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pCd_unidade
        { get; set; }
        public string pId_formulacao
        { get; set; }
        public string pDs_formula
        { get; set; }
        public decimal pQtd_programada
        { get; set; }
        public string pId_ordem
        { get; set; }

        public decimal Vl_custoProducao
        { get { return Vl_CustoTotal.Value; } }

        public TFDisponibilidadeMPrima()
        {
            InitializeComponent();
            pCd_empresa = string.Empty;
            pCd_produto = string.Empty;
            pCd_unidade = string.Empty;
            pId_formulacao = string.Empty;
            pDs_formula = string.Empty;
            pQtd_programada = decimal.Zero;
        }

        private void CalcularDisponibilidade()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(id_formulacao.Text))
            {
                MessageBox.Show("Obrigatorio informar formula.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_formulacao.Focus();
                return;
            }
            //Verificar se existe Ficha de materia prima personalizada na ordem de produção.
            if (!string.IsNullOrEmpty(pId_ordem))
            {
                CamadaDados.Producao.Producao.TList_Ordem_MPrima lOrdemPrima =
                    CamadaNegocio.Producao.Producao.TCN_Ordem_MPrima.Buscar(pId_ordem, null);
                if (lOrdemPrima.Count > 0)
                {
                    bsMPrima.DataSource = CamadaNegocio.Producao.Producao.TCN_MPrima.MontarListaMPrimaOrdem(CD_Empresa.Text,
                                                                                                            lOrdemPrima[0].Id_ordemstr,
                                                                                                            qtd_batch.Value,
                                                                                                            null,
                                                                                                            null);
                }
            }
            else
            {
                bsMPrima.DataSource = CamadaNegocio.Producao.Producao.TCN_MPrima.MontarListaMPrima(CD_Empresa.Text,
                                                                                                   id_formulacao.Text,
                                                                                                   qtd_batch.Value,
                                                                                                   null,
                                                                                                   null);
            }
            VL_CustoMPD.Value = (bsMPrima.List as CamadaDados.Producao.Producao.TList_MPrima).Sum(p => p.Vl_custo);
            //Buscar Custo Fixo
            BuscarCustoFixo();
            //calculo valor unitario
            if (qtd_produzir.Value > decimal.Zero)
                Vl_CustoUnitario.Value = Vl_CustoTotal.Value / (qtd_batch.Value * qtd_produzir.Value);
            bsMPrima_PositionChanged(this, new EventArgs());
        }

        private void BuscarCustoFixo()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_formulacao.Text)))
            {
                bsCustoFixo.DataSource = CamadaNegocio.Producao.Producao.TCN_CustoFixo_Direto.Buscar(CD_Empresa.Text,
                                                                                                     id_formulacao.Text,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     0,
                                                                                                     string.Empty,
                                                                                                     null);
                CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.CalcularCustoFixo(bsCustoFixo.List as CamadaDados.Producao.Producao.TList_CustoFixo_Direto,
                                                                                         qtd_batch.Value,
                                                                                         CamadaDados.UtilData.Data_Servidor(),
                                                                                         null);
                VL_CustoFixo.Value = (bsCustoFixo.List as CamadaDados.Producao.Producao.TList_CustoFixo_Direto).Sum(p => p.Vl_custo_calculado);
                bsCustoFixo.ResetBindings(true);
            }
        }

        private void TransfEntreLocal()
        {
            if ((bsMPrima.Current != null) && (bsSaldoLocal.Current != null))
            {
                if (((bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Qtd_saldonecessario < 0) &&
                    ((bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).qtd_saldoest > 0) &&
                    ((bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_local.Trim() != 
                     (bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).cd_localArm.Trim()))
                {
                    if(MessageBox.Show("Confirma transferencia de saldo entre locais de armazenagem?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Estoque.TCN_TransfLocal.Gravar(
                                new CamadaDados.Estoque.TRegistro_TransfLocal()
                                {
                                    Ds_transf = "TRANSFERENCIA GRAVADA PELA DISPONIBILIDADE DE MATERIA PRIMA.",
                                    Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                    Cd_produto = (bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_mprima,
                                    Cd_empresaorigem = (bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).cd_Empresa,
                                    Cd_localorigem = (bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).cd_localArm,
                                    Cd_empresadestino = CD_Empresa.Text,
                                    Cd_localdestino = (bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_local,
                                    Quantidade = Math.Abs((bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Qtd_saldonecessario) <
                                                    (bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).qtd_saldoest ?
                                                    Math.Abs((bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Qtd_saldonecessario):
                                                    (bsSaldoLocal.Current as CamadaDados.Estoque.TRegistro_ConsultaProduto).qtd_saldoest
                                }, null);
                            MessageBox.Show("Transferencia realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CalcularDisponibilidade();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void LancarRequisicao()
        {
            if (bsMPrima.Current != null)
            {
                if ((bsMPrima.DataSource as CamadaDados.Producao.Producao.TList_MPrima).Exists(p => p.Qtd_saldonecessario < 0))
                    try
                    {
                        //Buscar Tipo Requisicao Externa
                        object obj = new CamadaDados.Compra.TCD_TpRequisicao().BuscarEscalar(
                                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.TP_Requisicao",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        }
                    }, "a.ID_TpRequisicao");
                        if (obj == null)
                        {
                            MessageBox.Show("Não existe Tipo Requisição cadastrada no sistema!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Buscar Clifor Requisitante
                        object objClifor = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                        "where x.cd_clifor_cmp = a.cd_clifor " +
                                        "and isnull(x.st_requisitar, 'N') = 'S' " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        }
                    }, "a.cd_clifor");
                        if (objClifor == null)
                        {
                            MessageBox.Show("Usuário: " + Utils.Parametros.pubLogin.Trim() + "\r\n" +
                                            "não possui clifor requisitante cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CamadaDados.Compra.Lancamento.TList_Requisicao lRequisicao =
                            new CamadaDados.Compra.Lancamento.TList_Requisicao();
                        CamadaDados.Producao.Producao.TList_OrdemProducao_X_Requisicao lOrdemProducao =
                                    new CamadaDados.Producao.Producao.TList_OrdemProducao_X_Requisicao();
                        lOrdemProducao.Add(new CamadaDados.Producao.Producao.TRegistro_OrdemProducao_X_Requisicao()
                        {
                            Cd_empresa = CD_Empresa.Text,
                            Id_ordem = Convert.ToDecimal(pId_ordem)
                        });
                        (bsMPrima.DataSource as CamadaDados.Producao.Producao.TList_MPrima).FindAll(p => p.Qtd_saldonecessario < 0).ForEach(p =>
                            {
                                if (new CamadaDados.Producao.Producao.TCD_OrdemProducao().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_PRD_OrdemProducao_X_Requisicao x " +
                                                    "inner join TB_PRD_OrdemProducao y " +
                                                    "on x.id_ordem = y.id_ordem " +
                                                    "and x.cd_empresa = y.cd_empresa " +
                                                    "inner join TB_PRD_FichaTec_MPrima h " +
                                                    "on y.ID_Formulacao = h.ID_Formulacao " +
                                                    "and y.cd_empresa = h.cd_empresa " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.ID_Ordem = x.ID_Ordem " +
                                                    "and exists(select 1 from TB_CMP_Requisicao z " +
                                                    "       where h.cd_empresa = z.cd_empresa " +
                                                    "       and h.CD_Produto = z.CD_Produto " +
                                                    "       and x.ID_Requisicao = z.ID_Requisicao " +
                                                    "       and x.cd_empresa = z.cd_empresa " +
                                                    "       and z.ST_Requisicao <> 'CA') " +
                                                    "and a.id_ordem = " + pId_ordem.Trim() + " " +
                                                    "and h.CD_Produto = " + p.Cd_mprima.Trim() + ")"
                                    }
                                }, "1") == null)
                                {
                                    lRequisicao.Add(new CamadaDados.Compra.Lancamento.TRegistro_Requisicao()
                                    {
                                        St_integrar = true,
                                        Cd_empresa = CD_Empresa.Text,
                                        Id_tprequisicaostr = obj.ToString(),
                                        Dt_requisicao = CamadaDados.UtilData.Data_Servidor(),
                                        Cd_clifor_requisitante = objClifor.ToString(),
                                        Cd_produto = p.Cd_mprima,
                                        Ds_produto = p.Ds_mprima,
                                        Cd_local = p.Cd_local,
                                        Ds_local = p.Ds_local,
                                        Sigla_unidade = p.Sigla_unidade,
                                        St_requisicao = "AC",
                                        Quantidade = Math.Abs(p.Qtd_saldonecessario),
                                        lOrdemProd = lOrdemProducao
                                    });
                                }
                            });
                        using (TFLanRequisicao fReq = new TFLanRequisicao())
                        {
                            fReq.lRequisicao = lRequisicao;
                            if (fReq.ShowDialog() == DialogResult.OK)
                                if (fReq.lRequisicao != null)
                                    fReq.lRequisicao.ForEach(x =>
                                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.GravarRequisicao(x, null));
                        }
                        bsMPrima_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(id_formulacao.Text))
                vParam += ";|exists|(select 1 from tb_prd_formula_apontamento x " +
                          "where x.cd_empresa = a.cd_empresa " +
                          "and x.id_formulacao = " + id_formulacao.Text + ")";
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(id_formulacao.Text))
                vParam += ";|exists|(select 1 from tb_prd_formula_apontamento x " +
                          "where x.cd_empresa = a.cd_empresa " +
                          "and x.id_formulacao = " + id_formulacao.Text + ")";
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa(vParam, new Componentes.EditDefault[] { CD_Empresa });
        }
                
        private void bb_formulacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_formula|Formula|100;" +
                              "a.id_formulacao|Id. Formula|80";
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(pCd_produto))
                vParam += ";|exists|(select 1 from tb_prd_fichatec_acabado x " +
                          "where x.cd_empresa = a.cd_empresa " +
                          "and x.id_formulacao = a.id_formulacao " +
                          "and x.cd_produto = '" + pCd_produto.Trim() + "')";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                                                new CamadaDados.Producao.Producao.TCD_FormulaApontamento(),
                                                                vParam);
            if (linha != null)
                qtd_produzir.Value = decimal.Parse(linha["qt_produto"].ToString());
        }

        private void id_formulacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_formulacao|=|" + id_formulacao.Text + ";" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(pCd_produto))
                vParam += "|exists|(select 1 from tb_prd_fichatec_acabado x " +
                          "where x.cd_empresa = a.cd_empresa " +
                          "and x.id_formulacao = a.id_formulacao " +
                          "and x.cd_produto = '" + pCd_produto.Trim() + "')";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_formulacao, ds_formula },
                                                              new CamadaDados.Producao.Producao.TCD_FormulaApontamento());
            if (linha != null)
                qtd_produzir.Value = decimal.Parse(linha["qt_produto"].ToString());
        }

        private void TFDisponibilidadeMPrima_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            Utils.ShapeGrid.RestoreShape(this, gMPrima);
            Utils.ShapeGrid.RestoreShape(this, gSintetico);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            CD_Empresa.Text = pCd_empresa.Trim();
            id_formulacao.Text = pId_formulacao.Trim();
            ds_formula.Text = pDs_formula.Trim();
            if (id_formulacao.Text != null)
                id_formulacao_Leave(this, new EventArgs());
            CD_Empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            BB_Empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            qtd_batch.Enabled = string.IsNullOrWhiteSpace(pId_ordem);
            //Calcular indice de bateladas
            if (pQtd_programada > decimal.Zero)
            {
                //Buscar formula
                CamadaDados.Producao.Producao.TList_FormulaApontamento lFormula =
                    CamadaNegocio.Producao.Producao.TCN_FormulaApontamento.Buscar(CD_Empresa.Text,
                                                                                  id_formulacao.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  null);
                if (lFormula.Count > 0)
                {
                    qtd_batch.Value = TCN_CadConvUnidade.ConvertUnid(pCd_unidade, lFormula[0].Cd_unidProduto, pQtd_programada, 3, null) / lFormula[0].Qt_produto;
                    qtd_produzir.Value = lFormula[0].Qt_produto;
                }
                    
            }
        }
                
        private void bb_calcula_Click(object sender, EventArgs e)
        {
            CalcularDisponibilidade();
        }

        private void gMPrima_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 5)
                {
                    if (Convert.ToDecimal(e.Value.ToString()) < 0)
                    {
                        DataGridViewRow linha = gMPrima.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gMPrima.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bsMPrima_PositionChanged(object sender, EventArgs e)
        {
            if (bsMPrima.Current != null)
            {
                //Buscar Estoque Sintetico por Empresa
                bsSintetico.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintetico(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_mprima.Trim() + "'"
                                                }
                                            }, string.Empty, string.Empty);
                //Buscar Itens Pedido de Compra a Faturar
                BS_Itens.DataSource = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "n.tp_movimento",
                                                vOperador = "=",
                                                vVL_Busca = "'E'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(n.st_pedido, 'F')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_mprima.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                            "inner join tb_fat_notafiscal y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                            "where x.nr_pedido = a.nr_pedido " +
                                                            "and x.cd_produto = a.cd_produto " +
                                                            "and x.id_pedidoitem = a.id_pedidoitem " +
                                                            "and isnull(y.st_registro, 'A') <> 'C')"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
                //Buscar Requisições Abertos da Ordem
                bsRequisicao.DataSource =
                    new CamadaDados.Compra.Lancamento.TCD_Requisicao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsMPrima.Current as CamadaDados.Producao.Producao.TRegistro_MPrima).Cd_mprima.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_CMP_OrdemCompra x " +
                                            "inner join TB_CMP_OrdemCompra_X_PedItem y " +
                                            "on x.ID_OC = y.ID_OC " +
                                            "inner join TB_FAT_Pedido_Itens z " +
                                            "on y.Nr_Pedido = z.Nr_Pedido " +
                                            "and y.CD_Produto  = z.CD_Produto " +
                                            "and y.ID_PedidoItem = z.ID_PedidoItem " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_requisicao = a.id_requisicao " +
                                            "and isnull(z.ST_Registro, 'A') <> 'C' ) "
                            }
                        }, 0, string.Empty, string.Empty);

                bsSintetico_PositionChanged(this, new EventArgs());

            }
        }

        private void bsSintetico_PositionChanged(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
            {
                bsSaldoLocal.DataSource = CamadaNegocio.Estoque.TCN_ConsultaProdutos.buscaLocal(
                                            (bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                                            (bsSintetico.Current as DataRowView)["cd_produto"].ToString());
                bsSaldoLocal.ResetBindings(true);
            }
            else
                bsSaldoLocal.Clear();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_transf_Click(object sender, EventArgs e)
        {
            TransfEntreLocal();
        }

        private void TFDisponibilidadeMPrima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F9))
                CalcularDisponibilidade();
            else if (e.KeyCode.Equals(Keys.F10))
                TransfEntreLocal();
            else if (e.KeyCode.Equals(Keys.F11))
                LancarRequisicao();
        }

        private void VL_CustoMPD_ValueChanged(object sender, EventArgs e)
        {
            Vl_CustoTotal.Value = VL_CustoMPD.Value + VL_CustoFixo.Value;
        }

        private void VL_CustoFixo_ValueChanged(object sender, EventArgs e)
        {
            Vl_CustoTotal.Value = VL_CustoMPD.Value + VL_CustoFixo.Value;
        }

        private void TFDisponibilidadeMPrima_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
            Utils.ShapeGrid.SaveShape(this, gMPrima);
            Utils.ShapeGrid.SaveShape(this, gSintetico);
        }

        private void bb_requisicao_Click(object sender, EventArgs e)
        {
            LancarRequisicao();
        }

        private void Vl_CustoTotal_ValueChanged(object sender, EventArgs e)
        {
            if(qtd_produzir.Value > decimal.Zero)
                Vl_CustoUnitario.Value = Vl_CustoTotal.Value/ (qtd_batch.Value * qtd_produzir.Value);
        }
    }
}
