using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FormBusca;

namespace Proc_Commoditties
{
    public partial class TFCondFiscalICMS : Form
    {
        public bool st_novo = false;
        public string pCd_empresa { get; set; } = string.Empty;
        public string pCd_condfiscal_clifor { get; set; } = string.Empty;
        public string pCd_condfiscal_produto { get; set; } = string.Empty;
        public string pCd_movto { get; set; } = string.Empty;
        public string pCd_UfDest { get; set; } = string.Empty;
        public string pCd_UfOrig { get; set; } = string.Empty;
        public string pTp_movimento { get; set; } = string.Empty;
        public string pCd_imposto { get; set; } = string.Empty;
        public string pCd_st { get; set; } = string.Empty;

        private CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS rcond;
        public CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS rCond
        {
            get { return bsCondICMS.Current as CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS; }
            set { rcond = value; }
        }
        public List<CamadaDados.Fiscal.TRegistro_CadMovimentacao> lMov
        {
            get
            {
                if (bsMovimentacao.Count > 0)
                    return (bsMovimentacao.List as CamadaDados.Fiscal.TList_CadMovimentacao).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfOrigem
        {
            get
            {
                if (bsUfOrigem.Count > 0)
                    return (bsUfOrigem.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfDestino
        {
            get
            {
                if (bsUfDestino.Count > 0)
                    return (bsUfDestino.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).FindAll(p => p.St_agregar);
                else
                    return null;
            }
        }

        public TFCondFiscalICMS()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ENTRADA", "E"));
            cbx.Add(new Utils.TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("MARGEM VALOR AGREGADO(%)", "0"));
            cbx1.Add(new Utils.TDataCombo("PAUTA(VALOR)", "1"));
            cbx1.Add(new Utils.TDataCombo("PREÇO TABELADO MAXIMO(VALOR)", "2"));
            cbx1.Add(new Utils.TDataCombo("VALOR OPERAÇÃO", "3"));
            tp_modbasecalc.DataSource = cbx1;
            tp_modbasecalc.DisplayMember = "Display";
            tp_modbasecalc.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("PREÇO TABELADO", "0"));
            cbx2.Add(new Utils.TDataCombo("LISTA NEGATIVA(VALOR)", "1"));
            cbx2.Add(new Utils.TDataCombo("LISTA POSITIVA(VALOR)", "2"));
            cbx2.Add(new Utils.TDataCombo("LISTA NEUTRA(VALOR)", "3"));
            cbx2.Add(new Utils.TDataCombo("MARGEM VALOR AGREGADO", "4"));
            cbx2.Add(new Utils.TDataCombo("PAUTA(VALOR)", "5"));
            tp_modbasecalcst.DataSource = cbx2;
            tp_modbasecalcst.DisplayMember = "Display";
            tp_modbasecalcst.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (cbST.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatorio informar situação tributaria para imposto ICMS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbST.Focus();
                    return;
                }
                if (!(bsMovimentacao.List as CamadaDados.Fiscal.TList_CadMovimentacao).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar movimentação comercial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsUfOrigem.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar estado de origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsUfDestino.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Exists(p => p.St_agregar))
                {
                    MessageBox.Show("Obrigatorio selecionar estado destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(tp_modbasecalcst.SelectedIndex.Equals(5) && vl_pauta.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar valor de pauta para modalidade base calc subst. selecionada.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void BuscarImposto()
        {
            //Imposto
            cbImposto.DataSource = new CamadaDados.Fiscal.TCD_CadImposto().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "st_icms",
                                            vOperador = "=",
                                            vVL_Busca = "1"
                                        }
                                    }, 0, string.Empty);
            cbImposto.DisplayMember = "ds_imposto";
            cbImposto.ValueMember = "cd_imposto";
            //cbImposto.SelectedValue = pCd_imposto;
        }
                
        private void TFCondFiscalICMS_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMovComercial);
            Utils.ShapeGrid.RestoreShape(this, gUFDestino);
            Utils.ShapeGrid.RestoreShape(this, gUFOrigem);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
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
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
            //Condicao Clifor
            cbCondClifor.DataSource = CamadaNegocio.Fiscal.TCN_CadCondFiscalClifor.Busca(string.Empty, string.Empty, string.Empty);
            cbCondClifor.DisplayMember = "Cd_Ds";
            cbCondClifor.ValueMember = "Cd_condFiscal_clifor";
            
            //Buscar Uf Origem
            bsUfOrigem.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.Buscar(string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        0,
                                                                                        null);
            //Buscar Uf Destino
            bsUfDestino.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.Buscar(string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         0,
                                                                                         null);
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_clifor)) &&
                (!string.IsNullOrEmpty(pCd_movto)) &&
                (!string.IsNullOrEmpty(pCd_UfDest)) &&
                (!string.IsNullOrEmpty(pCd_UfOrig)) &&
                (!string.IsNullOrEmpty(pTp_movimento)))
            {
                CamadaDados.Fiscal.TList_CadCondFiscalICMS lCond =
                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Busca(string.Empty,
                                                                 pCd_condfiscal_produto,
                                                                 pCd_condfiscal_clifor,
                                                                 pCd_UfOrig,
                                                                 pCd_UfDest,
                                                                 pTp_movimento,
                                                                 string.Empty,
                                                                 pCd_imposto,
                                                                 pCd_movto,
                                                                 pCd_empresa,
                                                                 string.Empty,
                                                                 false,
                                                                 false,
                                                                 null);
                if (lCond.Count > 0)
                    rcond = lCond[0];
            }
            if (rcond != null)
            {
                pCd_st = rcond.Cd_st;
                bsCondICMS.DataSource = new CamadaDados.Fiscal.TList_CadCondFiscalICMS() { rcond };
                cbEmpresa.Enabled = false;
                tp_movimento.Enabled = false;
                cbImposto.Enabled = false;
                gComercial.Enabled = !rcond.Cd_movimentacao.Equals(decimal.Zero);
                st_marcamovto.Enabled = false;
                cbImposto.Enabled = false;
                gridUfDestino.Enabled = string.IsNullOrEmpty(rcond.Cd_ufdest);
                st_marcaUfDestino.Enabled = st_novo;
                gridUfOrigem.Enabled = string.IsNullOrEmpty(rcond.Cd_uforig);
                st_marcaUfOrigem.Enabled = st_novo; 
                if (!string.IsNullOrEmpty(rcond.Cd_condfiscal_produto))
                {
                    bb_Condproduto.Enabled = false;
                    CD_CondFiscal_Produto.Enabled = false;
                }
                if (!string.IsNullOrEmpty(rcond.Cd_condfiscal_clifor))
                {
                    cbCondClifor.Enabled = false;
                }
                
                if(string.IsNullOrEmpty(rcond.Cd_impostostr))
                {
                    cbImposto.SelectedIndex = 0;
                }
                if (bsMovimentacao.Count > 0)
                {
                    (bsMovimentacao.List as CamadaDados.Fiscal.TList_CadMovimentacao).Find(p => p.Cd_movimentacaostr.Equals(rcond.Cd_movimentacaostr)).St_agregar = true;
                    bsMovimentacao.ResetBindings(true);
                }
                if (bsUfDestino.Count > 0)
                {
                    (bsUfDestino.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Find(p => p.Cd_uf.Equals(rcond.Cd_ufdest)).St_agregar = true;
                    bsUfDestino.ResetBindings(true);
                }
                if (bsUfOrigem.Count > 0)
                {
                    (bsUfOrigem.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Find(p => p.Cd_uf.Equals(rcond.Cd_uforig)).St_agregar = true;
                    bsUfOrigem.ResetBindings(true);
                }
                this.BuscarImposto();
                cbST.Focus();
            }
            else
            {
                this.BuscarImposto();
                bsCondICMS.AddNew();
                if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_condfiscal_clifor)) &&
                (!string.IsNullOrEmpty(pCd_movto)) &&
                (!string.IsNullOrEmpty(pCd_UfDest)) &&
                (!string.IsNullOrEmpty(pCd_UfOrig)) &&
                (!string.IsNullOrEmpty(pTp_movimento)))
                {
                    cbEmpresa.SelectedValue = pCd_empresa;
                    cbCondClifor.SelectedValue = pCd_condfiscal_clifor;
                    CD_CondFiscal_Produto.Text = pCd_condfiscal_produto;
                    tp_movimento.SelectedValue = pTp_movimento;
                    cbImposto.SelectedValue = pCd_imposto;
                    cbST.SelectedValue = pCd_st;
                    if (bsMovimentacao.Count > 0)
                    {
                        (bsMovimentacao.List as CamadaDados.Fiscal.TList_CadMovimentacao).Find(p => p.Cd_movimentacaostr.Equals(pCd_movto)).St_agregar = true;
                        bsMovimentacao.ResetBindings(true);
                    }
                    if (bsUfDestino.Count > 0)
                    {
                        (bsUfDestino.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Find(p => p.Cd_uf.Equals(pCd_UfDest)).St_agregar = true;
                        bsUfDestino.ResetBindings(true);
                    }
                    if (bsUfOrigem.Count > 0)
                    {
                        (bsUfOrigem.List as CamadaDados.Financeiro.Cadastros.TList_CadUf).Find(p => p.Cd_uf.Equals(pCd_UfOrig)).St_agregar = true;
                        bsUfOrigem.ResetBindings(true);
                    }
                }
            }
        }

        private void bb_Condproduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_condFiscal_produto|Descrição|200;cd_CondFiscal_produto|Cód.CondFiscal|80",
                new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto }, new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_CondFiscal_produto|=|'" + CD_CondFiscal_Produto.Text + "'",
                new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto }, new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd_cfop.Clear();
            ds_cfop.Clear();
            if (tp_movimento.SelectedValue != null)
                bsMovimentacao.DataSource = new CamadaDados.Fiscal.TCD_CadMovimentacao().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + tp_movimento.SelectedValue.ToString().Trim().ToUpper() + "'"
                                                }
                                            }, 0, string.Empty);
        }

        private void bb_obs_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_observacaofiscal|Observação Fiscal|200;cd_ObservacaoFiscal|Cód. Observação Fiscal|80",
                new Componentes.EditDefault[] { CD_ObservacaoFiscal, ds_observacaofiscal }, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), null);
        }

        private void CD_ObservacaoFiscal_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_ObservacaoFiscal|=|'" + CD_ObservacaoFiscal.Text + "'",
                new Componentes.EditDefault[] { CD_ObservacaoFiscal, ds_observacaofiscal }, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal());
        }

        private void gComercial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsMovimentacao.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsMovimentacao.Current as CamadaDados.Fiscal.TRegistro_CadMovimentacao).St_agregar =
                        !(bsMovimentacao.Current as CamadaDados.Fiscal.TRegistro_CadMovimentacao).St_agregar;
                    bsMovimentacao.ResetCurrentItem();
                }
        }

        private void gridUfOrigem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsUfOrigem.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsUfOrigem.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadUf).St_agregar =
                        !(bsUfOrigem.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadUf).St_agregar;
                    bsUfOrigem.ResetCurrentItem();
                }
        }

        private void gridUfDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsUfDestino.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsUfDestino.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadUf).St_agregar =
                        !(bsUfDestino.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadUf).St_agregar;
                    bsUfDestino.ResetCurrentItem();
                }
        }

        private void st_marcamovto_Click(object sender, EventArgs e)
        {
            if (bsMovimentacao.Count > 0)
            {
                (bsMovimentacao.DataSource as CamadaDados.Fiscal.TList_CadMovimentacao).ForEach(p => p.St_agregar = st_marcamovto.Checked);
                bsMovimentacao.ResetBindings(true);
            }
        }

        private void st_marcaUfOrigem_Click(object sender, EventArgs e)
        {
            if (bsUfOrigem.Count > 0)
            {
                (bsUfOrigem.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadUf).ForEach(p => p.St_agregar = st_marcaUfOrigem.Checked);
                bsUfOrigem.ResetBindings(true);
            }
        }

        private void st_marcaUfDestino_Click(object sender, EventArgs e)
        {
            if (bsUfDestino.Count > 0)
            {
                (bsUfDestino.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadUf).ForEach(p => p.St_agregar = st_marcaUfDestino.Checked);
                bsUfDestino.ResetBindings(true);
            }
        }

        private void TFCondFiscalICMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMovComercial);
            Utils.ShapeGrid.SaveShape(this, gUFDestino);
            Utils.ShapeGrid.SaveShape(this, gUFOrigem);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCondFiscalICMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbImposto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbImposto.SelectedItem != null)
            {
                if (cbEmpresa.Items.Count > 0)
                    if (!string.IsNullOrEmpty((cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Tp_regimetributario))
                    {
                        cbST.DataSource = new CamadaDados.Fiscal.TCD_CadSitTribut().Select(
                                            new Utils.TpBusca[]
                                            {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_imposto",
                                                vOperador = "=",
                                                vVL_Busca = (cbImposto.SelectedItem as CamadaDados.Fiscal.TRegistro_CadImposto).Cd_impostoSt
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_simplesnacional, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Tp_regimetributario.Trim().Equals("1") ? "'S'" : "'N'"
                                            }
                                            }, 0, string.Empty);
                        cbST.DisplayMember = "cd_ds";
                        cbST.ValueMember = "CD_St";
                        cbST.SelectedValue = pCd_st;
                    }
                    else
                    {
                        MessageBox.Show("Cadastre Tp.Regime Tributário na Empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
        }

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedIndex >= 0)
            {
                string vParam = string.Empty;
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    vParam = "substring(a.cd_cfop, 1, 1)|in|('1', '2', '3')";
                else vParam = "substring(a.cd_cfop, 1, 1)|in|('5', '6', '7')";
                string vColunas = "a.ds_cfop|CFOP|250;a.cd_cfop|Código|50";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop, ds_cfop },
                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
            }
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedIndex >= 0)
            {
                string vParam = "a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'";
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    vParam += ";substring(a.cd_cfop, 1, 1)|in|('1', '2', '3')";
                else vParam += ";substring(a.cd_cfop, 1, 1)|in|('5', '6', '7')";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cfop, ds_cfop },
                    new CamadaDados.Fiscal.TCD_CadCFOP());
            }
        }

        private void cbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
            {
                lblaliqopdifal.Visible = !(cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Tp_regimetributario.Equals("3");
                pc_aliqopdifal.Visible = !(cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Tp_regimetributario.Equals("3");
            }
        }
    }
}
