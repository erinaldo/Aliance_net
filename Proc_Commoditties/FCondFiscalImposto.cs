using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using Utils;
using CamadaNegocio.Fiscal;

namespace Proc_Commoditties
{
    public partial class TFCondFiscalImposto : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pCd_movimentacao
        { get; set; }
        public string pTp_faturamento
        { get; set; }
        public string pCd_condfiscal_clifor
        { get; set; }
        public string pCd_condfiscal_produto
        { get; set; }
        public string pCd_imposto
        { get; set; }
        public string pCd_st { get; set; }
        private bool pst_juridica;
        public bool pSt_juridica
        {
            get { return cbJuridica.Checked; }
            set { pst_juridica = value; }
        }
        private bool pst_fisica;
        public bool pSt_fisica
        {
            get { return cbFisica.Checked; }
            set { pst_fisica = value; }
        }
        private bool pst_estrangeiro;
        public bool pSt_estrangeiro
        {
            get { return cbEstrangeiro.Checked; }
            set { pst_estrangeiro = value; }
        }

        private TRegistro_CondicaoFiscalImposto rcond;
        public TRegistro_CondicaoFiscalImposto rCond
        {
            get { return bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto; }
            set { rcond = value; }
        }
        public List<TRegistro_CadMovimentacao> lMov
        {
            get
            {
                if (bsMovimentacao.Count > 0)
                    return (bsMovimentacao.List as TList_CadMovimentacao).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }
        public List<TRegistro_CadCondFiscalClifor> lCondClifor
        {
            get
            {
                if (bsCondFiscalClifor.Count > 0)
                    return (bsCondFiscalClifor.List as TList_CadConFiscalClifor).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }
        public List<TRegistro_CadCondFiscalProduto> lCondProd
        {
            get
            {
                if (bsCondFiscalProduto.Count > 0)
                    return (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }

        public TFCondFiscalImposto()
        {
            InitializeComponent();

            pCd_empresa = string.Empty;
            pCd_movimentacao = string.Empty;
            pTp_faturamento = string.Empty;
            pst_fisica = false;
            pst_juridica = false;
            pst_estrangeiro = false;
            pCd_condfiscal_clifor = string.Empty;
            pCd_condfiscal_produto = string.Empty;
            pCd_imposto = string.Empty;
            pCd_st = string.Empty;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_faturamento.DataSource = cbx;
            tp_faturamento.DisplayMember = "Display";
            tp_faturamento.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("IGNORAR", "I"));
            cbx2.Add(new TDataCombo("SOMAR", "S"));
            cbx2.Add(new TDataCombo("DIMINUIR", "D"));
            st_totalnota.DataSource = cbx2;
            st_totalnota.DisplayMember = "Display";
            st_totalnota.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("NORMAL", "N"));
            cbx3.Add(new TDataCombo("RETIDA", "R"));
            cbx3.Add(new TDataCombo("SUBSTITUTA", "S"));
            cbx3.Add(new TDataCombo("ISENTA", "I"));
            tp_tributiss.DataSource = cbx3;
            tp_tributiss.DisplayMember = "Display";
            tp_tributiss.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new TDataCombo("TRIBUTAÇÃO MUNICIPIO", "1"));
            cbx4.Add(new TDataCombo("TRIBUTAÇÃO FORA MUNICIPIO", "2"));
            cbx4.Add(new TDataCombo("ISENTO", "3"));
            cbx4.Add(new TDataCombo("IMUNE", "4"));
            cbx4.Add(new TDataCombo("EXIGIBILIDADE SUSPENSA DECISÃO JUDICIAL", "5"));
            cbx4.Add(new TDataCombo("EXIGIBILIDADE SUSPENSA DECISÃO ADIMINISTRATIVA", "6"));
            tp_naturezaoperacaoiss.DataSource = cbx4;
            tp_naturezaoperacaoiss.DisplayMember = "Display";
            tp_naturezaoperacaoiss.ValueMember = "Value";
        }

        private void PosicaoCursorGrids()
        {
            if (bs_CondFiscalImposto.Current != null)
            {
                //Posicionar cursor movimentacao
                if (bsMovimentacao.Count > 0)
                {
                    (bsMovimentacao.List as TList_CadMovimentacao).ForEach(p => p.St_agregar = false);
                    if ((bsMovimentacao.List as TList_CadMovimentacao).Exists(p => p.Cd_movimentacao.Value.Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_movimentacao)))
                    {
                        (bsMovimentacao.List as TList_CadMovimentacao).Find(p => p.Cd_movimentacao.Value.Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_movimentacao)).St_agregar = true;
                        bsMovimentacao.ResetBindings(true);
                    }
                }
                //Posicionar cursor condicao fiscal produto
                if (bsCondFiscalProduto.Count > 0)
                {
                    (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = false);
                    if ((bsCondFiscalProduto.List as TList_CadCondFiscalProduto).Exists(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_condfiscal_produto)))
                    {
                        (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).Find(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_condfiscal_produto)).St_agregar = true;
                        bsCondFiscalProduto.ResetBindings(true);
                    }
                }
                //Posicionar cursor condicao fiscal clifor
                if (bsCondFiscalClifor.Count > 0)
                {
                    (bsCondFiscalClifor.List as TList_CadConFiscalClifor).ForEach(p => p.St_agregar = false);
                    if ((bsCondFiscalClifor.List as TList_CadConFiscalClifor).Exists(p => p.Cd_condFiscal_clifor.Trim().Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_condfiscal_clifor)))
                    {
                        (bsCondFiscalClifor.List as TList_CadConFiscalClifor).Find(p => p.Cd_condFiscal_clifor.Trim().Equals((bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).cd_condfiscal_clifor)).St_agregar = true;
                        bsCondFiscalClifor.ResetBindings(true);
                    }
                }
                //Setar Tipo Pessoa
                cbFisica.Checked = (bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).Tp_pessoa.Trim().ToUpper().Equals("F");
                cbJuridica.Checked = (bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).Tp_pessoa.Trim().ToUpper().Equals("J");
                cbEstrangeiro.Checked = (bs_CondFiscalImposto.Current as TRegistro_CondicaoFiscalImposto).Tp_pessoa.Trim().ToUpper().Equals("E");
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((!cbFisica.Checked) && (!cbJuridica.Checked) && (!cbEstrangeiro.Checked))
                {
                    MessageBox.Show("Obrigatorio selecionar tipo pessoa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbFisica.Focus();
                }
                if (!(bsMovimentacao.List as TList_CadMovimentacao).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar movimentação comercial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsCondFiscalClifor.List as TList_CadConFiscalClifor).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar condição fiscal clifor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsCondFiscalProduto.List as TList_CadCondFiscalProduto).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar condição fiscal produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if((cbImposto.SelectedItem as TRegistro_CadImposto).St_ISSQN)
                {
                    if (tp_tributiss.SelectedValue == null)
                    {
                        MessageBox.Show("Condição Fiscal Imposto ISSQN.\r\n" +
                                        "Obrigatorio informar tipo tributação ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tp_tributiss.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(cd_municipiogeradoriss.Text))
                    {
                        MessageBox.Show("Obrigatório informar municipio gerador serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_municipiogeradoriss.Focus();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(cbImposto.SelectedValue.ToString()))
                {
                    object st_issqn = new TCD_CadImposto().BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_imposto",
                            vOperador = "=",
                            vVL_Busca =  cbImposto.SelectedValue.ToString()
                        },new TpBusca()
                        {
                            vNM_Campo = "a.st_issqn",
                            vOperador = "=",
                            vVL_Busca =  "1"
                        }
                    }, "a.st_issqn");
                    if (st_issqn != null)
                    {
                        if (tp_naturezaoperacaoiss.SelectedValue == null)
                        {
                            MessageBox.Show("Obrigatório selecionar a natureza do ISSQN.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                }

                DialogResult = DialogResult.OK;
            }
        }

        private void TFCondFiscalImposto_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();

            ShapeGrid.RestoreShape(this, gMovimentacao);
            ShapeGrid.RestoreShape(this, gCondFiscalClifor);
            ShapeGrid.RestoreShape(this, gCondFiscalProd);
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
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
            //Buscar Impostos
            cbImposto.DataSource = new TCD_CadImposto().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_icms",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                    }, 0, string.Empty);
            cbImposto.DisplayMember = "ds_imposto";
            cbImposto.ValueMember = "cd_imposto";
            cbImposto.SelectedValue = pCd_imposto;
            //Buscar Unidade Referencia
            cbUnidade.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(null, 0, string.Empty);
            cbUnidade.DisplayMember = "ds_unidade";
            cbUnidade.ValueMember = "cd_unidade";

            bsCondFiscalClifor.DataSource = TCN_CadCondFiscalClifor.Busca(string.Empty, string.Empty, string.Empty);
            bsCondFiscalProduto.DataSource = TCN_CadCondFiscalProduto.Busca(string.Empty, string.Empty);
            if ((!string.IsNullOrEmpty(pCd_imposto)) &&
                (!string.IsNullOrEmpty(pTp_faturamento)) &&
                (pst_juridica || pst_fisica || pst_estrangeiro) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_clifor)) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_produto)) &&
                (!string.IsNullOrEmpty(pCd_movimentacao)) &&
                (!string.IsNullOrEmpty(pCd_empresa)))
            {
                //Verificar se nao existe configuracao para a condicao informada pelo usuario
                TList_CondicaoFiscalImposto lCond = TCN_CondicaoFiscalImposto.Buscar(string.Empty,
                                                                          pCd_imposto,
                                                                          string.Empty,
                                                                          "'" + pTp_faturamento + "'",
                                                                          pst_fisica ? "'F'" : pst_juridica ? "'J'" : "'E'",
                                                                          pCd_condfiscal_produto,
                                                                          pCd_movimentacao,
                                                                          pCd_empresa,
                                                                          pCd_condfiscal_clifor,
                                                                          null);
                if (lCond.Count > 0)
                    rcond = lCond[0];
            }
            if (rcond != null)
            {
                pCd_st = rcond.Cd_st;
                bs_CondFiscalImposto.DataSource = new TList_CondicaoFiscalImposto() { rcond };
                cbEmpresa.Enabled = false;
                cbImposto.Enabled = !rcond.Cd_imposto.Equals(decimal.Zero);
                gCondFiscalClifor.Enabled = string.IsNullOrEmpty(rcond.cd_condfiscal_clifor);
                st_marcaclifor.Enabled = false;
                gCondFiscalProd.Enabled = string.IsNullOrEmpty(rcond.cd_condfiscal_produto);
                st_marcaprod.Enabled = false;
                gMovimentacao.Enabled = rcond.cd_movimentacao.Equals(decimal.Zero);
                st_marcamov.Enabled = false;

                tp_faturamento.Enabled = false;
                cbFisica.Enabled = string.IsNullOrEmpty( rcond.Tp_pessoa);
                cbJuridica.Enabled = string.IsNullOrEmpty(rcond.Tp_pessoa);
                cbEstrangeiro.Enabled = string.IsNullOrEmpty(rcond.Tp_pessoa);
                //Buscar Movimentacao
                bsMovimentacao.DataSource = TCN_CadMovimentacao.Busca(string.Empty,
                                                                      string.Empty,
                                                                      rcond.Tp_faturamento,
                                                                      null);
                if (bsMovimentacao.Count > 0)
                {
                    (bsMovimentacao.List as TList_CadMovimentacao).Find(p => p.Cd_movimentacaostr.Equals(rcond.cd_movimentacao.ToString())).St_agregar = true;
                    bsMovimentacao.ResetBindings(true);
                }
                if (bsCondFiscalClifor.Count > 0)
                {
                    (bsCondFiscalClifor.List as TList_CadConFiscalClifor).Find(p => p.Cd_condFiscal_clifor.Equals(rcond.cd_condfiscal_clifor)).St_agregar = true;
                    bsCondFiscalClifor.ResetBindings(true);
                }
                if (bsCondFiscalProduto.Count > 0)
                {
                    (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).Find(p => p.CD_CONDFISCAL_PRODUTO.Equals(rcond.cd_condfiscal_produto)).St_agregar = true;
                    bsCondFiscalProduto.ResetBindings(true);
                }
                pISS.Visible = (cbImposto.SelectedItem as TRegistro_CadImposto).St_ISSQN;
                cbSt.Focus();
            }
            else
            {
                bs_CondFiscalImposto.AddNew();
                if ((!string.IsNullOrEmpty(pCd_imposto)) &&
                (!string.IsNullOrEmpty(pTp_faturamento)) &&
                (pst_fisica || pst_juridica || pst_estrangeiro) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_clifor)) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_produto)) &&
                (!string.IsNullOrEmpty(pCd_movimentacao)) &&
                (!string.IsNullOrEmpty(pCd_empresa)))
                {
                    cbEmpresa.SelectedValue = pCd_empresa;
                    cbImposto.SelectedValue = pCd_imposto;
                    tp_faturamento.SelectedValue = pTp_faturamento;
                    cbFisica.Checked = pst_fisica;
                    cbJuridica.Checked = pst_juridica;
                    cbEstrangeiro.Checked = pst_estrangeiro;
                    if (bsMovimentacao.Count > 0)
                    {
                        (bsMovimentacao.List as TList_CadMovimentacao).Find(p => p.Cd_movimentacaostr.Equals(pCd_movimentacao)).St_agregar = true;
                        bsMovimentacao.ResetBindings(true);
                    }
                    if (bsCondFiscalClifor.Count > 0)
                    {
                        (bsCondFiscalClifor.List as TList_CadConFiscalClifor).Find(p => p.Cd_condFiscal_clifor.Equals(pCd_condfiscal_clifor)).St_agregar = true;
                        bsCondFiscalClifor.ResetBindings(true);
                    }
                    if (bsCondFiscalProduto.Count > 0)
                    {
                        (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).Find(p => p.CD_CONDFISCAL_PRODUTO.Equals(pCd_condfiscal_produto)).St_agregar = true;
                        bsCondFiscalProduto.ResetBindings(true);
                    }
                }
            }
        }
                
        private void rbSempre_CheckedChanged(object sender, EventArgs e)
        {
            Vl_TotFaturadoBase.Enabled = !(rbSempre.Checked);
        }

        private void Vl_TotFaturadoBase_EnabledChanged(object sender, EventArgs e)
        {
            if (!(Vl_TotFaturadoBase.Enabled))
                Vl_TotFaturadoBase.Value = decimal.Zero;
        }

        private void bb_basecredito_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_basecredito|Base Credito|200;" +
                              "a.id_basecredito|Id. Base|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_basecredito },
                                    new CamadaDados.Fiscal.TCD_TpBaseCalcCredito(), string.Empty);
        }

        private void id_basecredito_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_basecredito|=|" + id_basecredito.Text,
                                    new Componentes.EditDefault[] { id_basecredito },
                                    new CamadaDados.Fiscal.TCD_TpBaseCalcCredito());
        }

        private void bb_tpcred_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpcred|Tipo Credito|350;" +
                              "a.id_tpcred|TP. Credito|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpcred },
                                    new CamadaDados.Fiscal.TCD_TpCreditoPisCofins(), string.Empty);
        }

        private void id_tpcred_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpcred|=|" + id_tpcred.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpcred },
                                    new CamadaDados.Fiscal.TCD_TpCreditoPisCofins());
        }

        private void bb_tpcontribuicao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpcontribuicao|Tipo Contribuição|350;" +
                              "a.id_tpcontribuicao|TP. Contribuição|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpcontribuicao },
                                    new CamadaDados.Fiscal.TCD_TpContribuicaoPisCofins(), string.Empty);
        }

        private void id_tpcontribuicao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpcontribuicao|=|" + id_tpcontribuicao.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpcontribuicao },
                                    new CamadaDados.Fiscal.TCD_TpContribuicaoPisCofins());
        }

        private void bb_detrecisenta_Click(object sender, EventArgs e)
        {
            if (cbImposto.SelectedValue != null && cbSt.SelectedValue != null)
            {
                string vColunas = "a.ds_detrecisenta|Natureza Receita|200;" +
                                  "a.id_detrecisenta|Codigo|80";
                string vParam = "a.cd_imposto|=|" + cbImposto.SelectedValue.ToString() + ";" +
                                "a.cd_st|=|'" + cbSt.SelectedValue.ToString() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_detrecisenta },
                                        new CamadaDados.Fiscal.TCD_DetRecIsentaPisCofins(), vParam);
            }
        }

        private void id_detrecisenta_Leave(object sender, EventArgs e)
        {
            if (cbImposto.SelectedValue != null && cbSt.SelectedValue != null)
            {
                string vParam = "a.id_detrecisenta|=|" + id_detrecisenta.Text + ";" +
                    "a.cd_imposto|=|" + cbImposto.SelectedValue.ToString() + ";" +
                    "a.cd_st|=|'" + cbSt.SelectedValue.ToString() + "'";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_detrecisenta },
                                        new CamadaDados.Fiscal.TCD_DetRecIsentaPisCofins());
            }
        }

        private void tp_faturamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_faturamento.SelectedValue != null)
            {
                bsMovimentacao.DataSource = TCN_CadMovimentacao.Busca(string.Empty,
                                                                      string.Empty,
                                                                      tp_faturamento.SelectedValue.ToString().Trim().ToUpper(),
                                                                      null);
                PosicaoCursorGrids();
            }
        }

        private void bb_municipiogeradoriss_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Municipio|200;" +
                              "a.cd_cidade|Cd. Municipio|80;" +
                              "a.distrito|Distrito|100;" +
                              "b.uf|UF|20;" +
                              "b.ds_uf|Estado|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_municipiogeradoriss, ds_municipiogeradoriss },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void cd_municipiogeradoriss_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipiogeradoriss.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_municipiogeradoriss, ds_municipiogeradoriss },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bs_CondFiscalImposto_PositionChanged(object sender, EventArgs e)
        {
            PosicaoCursorGrids();
        }

        private void st_marcamov_Click(object sender, EventArgs e)
        {
            if (bsMovimentacao.Count > 0)
            {
                (bsMovimentacao.List as TList_CadMovimentacao).ForEach(p => p.St_agregar = st_marcamov.Checked);
                bsMovimentacao.ResetBindings(true);
            }
        }

        private void gMovimentacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsMovimentacao.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsMovimentacao.Current as TRegistro_CadMovimentacao).St_agregar =
                        !(bsMovimentacao.Current as TRegistro_CadMovimentacao).St_agregar;
                    bsMovimentacao.ResetCurrentItem();
                }
        }

        private void st_marcaclifor_Click(object sender, EventArgs e)
        {
            if (bsCondFiscalClifor.Count > 0)
            {
                (bsCondFiscalClifor.List as TList_CadConFiscalClifor).ForEach(p => p.St_agregar = st_marcaclifor.Checked);
                bsCondFiscalClifor.ResetBindings(true);
            }
        }

        private void gCondFiscalClifor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCondFiscalClifor.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsCondFiscalClifor.Current as TRegistro_CadCondFiscalClifor).St_agregar =
                        !(bsCondFiscalClifor.Current as TRegistro_CadCondFiscalClifor).St_agregar;
                    bsCondFiscalClifor.ResetCurrentItem();
                }
        }

        private void st_marcaprod_Click(object sender, EventArgs e)
        {
            if (bsCondFiscalProduto.Count > 0)
            {
                (bsCondFiscalProduto.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = st_marcaprod.Checked);
                bsCondFiscalProduto.ResetBindings(true);
            }
        }

        private void gCondFiscalProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCondFiscalProduto.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsCondFiscalProduto.Current as TRegistro_CadCondFiscalProduto).St_agregar =
                        !(bsCondFiscalProduto.Current as TRegistro_CadCondFiscalProduto).St_agregar;
                    bsCondFiscalProduto.ResetCurrentItem();
                }
        }

        private void bb_receita_Click(object sender, EventArgs e)
        {
            if (cbImposto.SelectedValue != null)
            {
                string vColunas = "a.ds_receita|Tipo Receita|200;" +
                                  "a.id_receita|Codigo|60";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_receita },
                    new CamadaDados.Fiscal.TCD_ReceitaPisCofins(), "a.cd_imposto|=|" + cbImposto.SelectedValue.ToString());
            }
            else MessageBox.Show("Obrigatorio informar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void id_receita_Leave(object sender, EventArgs e)
        {
            if (cbImposto.SelectedValue != null)
            {
                string vParam = "a.id_receita|=|" + id_receita.Text + ";" +
                                "a.cd_imposto|=|" + cbImposto.SelectedValue.ToString();
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_receita }, new CamadaDados.Fiscal.TCD_ReceitaPisCofins());
            }
            else MessageBox.Show("Obrigatorio informar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void cbImposto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbImposto.SelectedItem != null && bs_CondFiscalImposto.Count > 0)
            {
                pISS.Visible = (cbImposto.SelectedItem as TRegistro_CadImposto).St_ISSQN;
                cbSt.DataSource = new TCD_CadSitTribut().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_imposto",
                                            vOperador = "=",
                                            vVL_Busca = (cbImposto.SelectedItem as TRegistro_CadImposto).Cd_impostoSt
                                        }
                                    }, 0, string.Empty);
                cbSt.DisplayMember = "cd_ds";
                cbSt.ValueMember = "CD_St";
                cbSt.SelectedValue = pCd_st;
            }
        }
    }
}
