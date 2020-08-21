using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace Commoditties
{
    public partial class TFContrato : Form
    {
        private CamadaDados.Graos.TRegistro_CadContrato rcontrato;
        public CamadaDados.Graos.TRegistro_CadContrato rContrato
        {
            get 
            {
                if (bsContrato.Current != null)
                    return bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato;
                else
                    return null;
            }
            set { rcontrato = value; }
        }

        private bool St_lancartitulo = false;

        public TFContrato()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("CONVENCIONAL", "CV"));
            cbx.Add(new Utils.TDataCombo("TRANSGÊNICA", "TR"));
            cbx.Add(new Utils.TDataCombo("INTACTA DECLARADA", "ID"));
            cbx.Add(new Utils.TDataCombo("INTACTA PARTICIPANTE", "IP"));
            tp_prodcontrato.DataSource = cbx;
            tp_prodcontrato.DisplayMember = "Display";
            tp_prodcontrato.ValueMember = "Value";

            ArrayList cbx3 = new ArrayList();
            cbx3.Add(new Utils.TDataCombo("ENTRADA", "E"));
            cbx3.Add(new Utils.TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx3;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";


            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("EMITENTE", "0"));
            cbx2.Add(new Utils.TDataCombo("DESTINATARIO", "1"));
            cbx2.Add(new Utils.TDataCombo("TERCEIRO", "2"));
            cbx2.Add(new Utils.TDataCombo("SEM FRETE", "9"));

            tp_frete.DataSource = cbx2;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";

            rcontrato = null;
        }

        private void BuscarContrato()
        {
            if (!string.IsNullOrEmpty(nr_contrato.Text.Trim()))
            {
                CamadaDados.Graos.TList_CadContrato lContrato =
                    CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                       nr_contrato.Text,
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
                                                                       null);
                if (lContrato.Count > 0)
                {
                    if (MessageBox.Show("Contrato ja existe. Deseja alterar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        this.rcontrato = lContrato[0];
                        this.Alterar();
                    }
                }
            }
        }

        private void afterGrava()
        {
            if (pContrato.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text.Trim()))
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
                else
                {
                    cd_endereco.Clear();
                    ds_endereco.Clear();
                }
            }
        }

        private void Alterar()
        {
            if (rcontrato != null)
            {
                bsContrato.DataSource = new CamadaDados.Graos.TList_CadContrato() { rcontrato };
                nr_contrato.Enabled = false;
                cd_tabeladesconto.Enabled = false;
                bb_tabeladesconto.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                bb_cadclifor.Enabled = false;
                cd_endereco.Enabled = false;
                bb_endereco.Enabled = false;
                bbCadEndereco.Enabled = false;
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                tp_movimento.Enabled = false;
                CFG_Pedido.Enabled = false;
                BB_CFGPedido.Enabled = false;
                CD_Moeda.Enabled = false;
                BB_Moeda.Enabled = false;
                CD_Produto.Enabled = false;
                BB_Produto.Enabled = false;
                bsContrato.ResetCurrentItem();
            }
            else
            {
                bsContrato.AddNew();
                nr_contrato.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("NR_Contrato");
                if (!nr_contrato.Focus())
                    nr_contratoorigem.Focus();
            }
        }

        private void InserirTaxa()
        {
            if (bsContrato.Current != null)
            {
                using (TFTaxaContrato fTaxa = new TFTaxaContrato())
                {
                    if(fTaxa.ShowDialog() == DialogResult.OK)
                        if (fTaxa.rTaxa != null)
                        {
                            (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Taxas.Add(fTaxa.rTaxa);
                            bsContrato.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Não existe contrato para inserir taxa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarTaxa()
        {
            if (bsContrato.Current != null)
            {
                if (bsTaxas.Current != null)
                {
                    using (TFTaxaContrato fTaxa = new TFTaxaContrato())
                    {
                        CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito rTx = (bsTaxas.Current as CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito).Copy();
                        fTaxa.rTaxa = bsTaxas.Current as CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito;
                        if(!(fTaxa.ShowDialog() == DialogResult.OK))
                        {
                            bsTaxas.RemoveCurrent();
                            bsTaxas.Add(rTx);
                            bsContrato.ResetCurrentItem();
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe taxa selecionada para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe contrato para alterar taxa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirTaxa()
        {
            if (bsContrato.Current != null)
                if (bsTaxas.Current != null)
                    if (MessageBox.Show("Confirma exclusão da taxa selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).DelTaxas.Add(
                            bsTaxas.Current as CamadaDados.Graos.TRegistro_CadContratoTaxaDeposito);
                        bsTaxas.RemoveCurrent();
                    }
                else
                    MessageBox.Show("Não existe taxa selecionada para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não existe contrato selecionado para excluir taxa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirHeadge()
        {
            if (bsContrato.Current != null)
            {
                using (TFCustoHeadge fHeadge = new TFCustoHeadge())
                {
                    if(fHeadge.ShowDialog() == DialogResult.OK)
                        if (fHeadge.rHeadge != null)
                        {
                            (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lContrato_Headge.Add(fHeadge.rHeadge);
                            bsContrato.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Não existe contrato para inserir Headge.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarHeadge()
        {
            if (bsContrato.Current != null)
            {
                if (bsHeadge.Current != null)
                {
                    using (TFCustoHeadge fHeadge = new TFCustoHeadge())
                    {
                        CamadaDados.Graos.TRegistro_CadContrato_Headge rCh = (bsHeadge.Current as CamadaDados.Graos.TRegistro_CadContrato_Headge).Copy();
                        fHeadge.rHeadge = bsHeadge.Current as CamadaDados.Graos.TRegistro_CadContrato_Headge;
                        if (!(fHeadge.ShowDialog() == DialogResult.OK))
                        {
                            bsHeadge.RemoveCurrent();
                            bsHeadge.Add(rCh);
                            bsContrato.ResetCurrentItem();
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe Headge selecionado para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe contrato para alterar Headge.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void ExcluirHeadge()
        {
            if (bsContrato.Current != null)
                if (bsTaxas.Current != null)
                    if (MessageBox.Show("Confirma exclusão do headge selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDelContrato_Headge.Add(
                            bsHeadge.Current as CamadaDados.Graos.TRegistro_CadContrato_Headge);
                        bsHeadge.RemoveCurrent();
                    }
                    else
                        MessageBox.Show("Não existe headge selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Não existe contrato selecionado para excluir headge.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirDesdobro()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Produto.Text))
            {
                MessageBox.Show("Obrigatorio informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Produto.Focus();
                return;
            }
            using (TFDesdobro fDesdobro = new TFDesdobro())
            {
                fDesdobro.Text = "NOVO DESDOBRO";
                fDesdobro.pCd_empresa = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_empresa;
                fDesdobro.pCd_produto = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_produto;
                if (fDesdobro.ShowDialog() == DialogResult.OK)
                    if (fDesdobro.rDesd != null)
                    {
                        if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDesdobro.Exists(p =>
                            p.Id_tpdesdobrostr.Trim().Equals(fDesdobro.rDesd.Id_tpdesdobrostr.Trim()) &&
                            p.Nr_contrato_dest.Value.Equals(fDesdobro.rDesd.Nr_contrato_dest)))
                        {
                            (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDesdobro.Find(p =>
                            p.Id_tpdesdobrostr.Trim().Equals(fDesdobro.rDesd.Id_tpdesdobrostr.Trim()) &&
                            p.Nr_contrato_dest.Value.Equals(fDesdobro.rDesd.Nr_contrato_dest.Value)).Valor_desdobro = fDesdobro.rDesd.Valor_desdobro;
                        }
                        else
                            (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDesdobro.Add(fDesdobro.rDesd);
                        bsContrato.ResetCurrentItem();
                    }
            }
        }

        private void AlterarDesdobro()
        {
            if (bsDesdobro.Current != null)
            {
                using (TFDesdobro fDesdobro = new TFDesdobro())
                {
                    fDesdobro.Text = "ALTERANDO DESDOBRO";
                    fDesdobro.pCd_produto = CD_Produto.Text;
                    decimal valor_desdobro = (bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial).Valor_desdobro;
                    fDesdobro.rDesd = bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial;
                    if (fDesdobro.ShowDialog() != DialogResult.OK)
                        (bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial).Valor_desdobro = valor_desdobro;
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirDesdobro()
        {
            if (bsDesdobro.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDesdobroDel.Add(
                        bsDesdobro.Current as CamadaDados.Graos.TRegistro_Contrato_X_DesdEspecial);
                    bsDesdobro.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFContrato_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pContrato.set_FormatZero();
            this.Alterar();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa |350;" +
                                  "a.CD_Empresa|Cd. Empresa|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar moeda padrao
                CD_Moeda.Text = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", cd_empresa.Text);
                CD_Moeda_Leave(this, new EventArgs());
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                                  "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar moeda padrao
                CD_Moeda.Text = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", cd_empresa.Text);
                CD_Moeda_Leave(this, new EventArgs());
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            this.BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LeaveClifor(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEndereco();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { cd_endereco, ds_endereco }, "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEndereco("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_endereco, ds_endereco });
        }

        private void bb_tabeladesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabeladesconto|Tabela Desconto|250;" +
                                  "a.cd_tabeladesconto|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                    new CamadaDados.Graos.TCD_CadDesconto(), string.Empty);
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                    new CamadaDados.Graos.TCD_CadDesconto());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Safra|Ano Safra|250;" +
                                  "a.AnoSafra|Cd. Ano Safra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
            {
                if (tcDetalhes.SelectedTab.Equals(tpTaxas))
                    this.InserirTaxa();
                else if (tcDetalhes.SelectedTab.Equals(tpHeadge))
                    this.InserirHeadge();
                else if (tcDetalhes.SelectedTab.Equals(tpDesdobro))
                    this.InserirDesdobro();
            }
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
            {
                if (tcDetalhes.SelectedTab.Equals(tpTaxas))
                    this.AlterarTaxa();
                else if (tcDetalhes.SelectedTab.Equals(tpHeadge))
                    this.AlterarHeadge();
                else if (tcDetalhes.SelectedTab.Equals(tpDesdobro))
                    this.AlterarDesdobro();
            }
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
            {
                if (tcDetalhes.SelectedTab.Equals(tpTaxas))
                    this.ExcluirTaxa();
                else if (tcDetalhes.SelectedTab.Equals(tpHeadge))
                    this.ExcluirHeadge();
                else if (tcDetalhes.SelectedTab.Equals(tpDesdobro))
                    this.ExcluirDesdobro();
            }
        }

        private void nr_contrato_Leave(object sender, EventArgs e)
        {
            this.BuscarContrato();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.InserirTaxa();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.ExcluirTaxa();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirHeadge();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirHeadge();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.AlterarTaxa();
        }

        private void bb_produtoembalagem_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_est_tpproduto x " +
                            "where x.tp_produto = a.tp_produto " +
                            "and isnull(x.st_embalagem, 'N') = 'S')";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produtoembalagem, ds_produtoembalagem }, vParam);
        }

        private void cd_produtoembalagem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produtoembalagem.Text.Trim() + "';" +
                                           "|exists|(select 1 from tb_est_tpproduto x "+
                                           "where x.tp_produto = a.tp_produto "+
                                           "and isnull(x.st_embalagem, 'N') = 'S')",
                                            new Componentes.EditDefault[] { cd_produtoembalagem, ds_produtoembalagem },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, cd_empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produtoembalagem.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produtoembalagem.Text);


            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                                   , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new TCD_CadLocalArm(cd_produtoembalagem.Text, cd_empresa.Text), string.Empty);
            else
                if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
                    UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80"
                                   , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(),
                                   "Exists(select top 1 1 from TB_EST_Empresa_X_LocalArm x where x.cd_Empresa = | '" + cd_empresa.Text.Trim() + "' |)");
                else
                    if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
                        UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80"
                               , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(),
                               "Exists(select top 1 1 from TB_EST_LocalArm_X_Produto x where x.cd_Produto = | '" + cd_produtoembalagem.Text.Trim() + "' |)");
                    else
                        UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80"
                                   , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(),
                                   null);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, cd_empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produtoembalagem.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produtoembalagem.Text);

            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localEmb.Text.Trim() + "'", 
                                        new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, 
                                        new TCD_CadLocalArm(cd_produtoembalagem.Text, cd_empresa.Text));
            else
                if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
                    UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localEmb.Text.Trim() + "';" + "Exists(select top 1 1 from TB_EST_Empresa_X_LocalArm x where x.cd_Empresa = | '" + cd_empresa.Text.Trim() + "' |)"
                 , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
                else
                    if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
                        UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localEmb.Text.Trim() + "';" + "Exists(select top 1 1 from TB_EST_LocalArm_X_Produto x where x.cd_produto = | '" + cd_produtoembalagem.Text.Trim() + "' |)"
                        , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
                    else
                        UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_localEmb.Text.Trim() + "'"
                        , new Componentes.EditDefault[] { cd_localEmb, ds_localEmb }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bb_condpgto_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. Condição|80;" +
                              "a.cd_portador|Cd. Portador|80;" +
                              "b.ds_portador|Portador|200";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto_fix, ds_condpgto_fix, cd_portador_fix, ds_portador_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto_fix.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto_fix, ds_condpgto_fix, cd_portador_fix, ds_portador_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_portador_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80;"+
                              "st_controletitulo|Controlar Titulo|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador_fix, ds_portador_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
            if (linha != null)
                St_lancartitulo = linha["st_controletitulo"].ToString().Trim().ToUpper().Equals("S");
            else
                St_lancartitulo = false;
        }

        private void cd_portador_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador_fix.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador_fix, ds_portador_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
            if (linha != null)
                St_lancartitulo = linha["st_controletitulo"].ToString().Trim().ToUpper().Equals("S");
            else
                St_lancartitulo = false;
        }

        private void bb_historico_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Financeiro|200;" +
                              "a.cd_historico|Cd. Historico|80;" +
                              "a.tp_mov|Tipo Movimento|80";
            string vParam = tp_movimento.SelectedValue == null ? string.Empty :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? "a.tp_mov|=|'P'" :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") ? "a.tp_mov|=|'R'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_fix, ds_historico_fix, tp_movhistorico_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_fix.Text.Trim() + "'";
            vParam += tp_movimento.SelectedValue == null ? string.Empty :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? ";a.tp_mov|=|'P'" :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") ? ";a.tp_mov|=|'R'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_fix, ds_historico_fix, tp_movhistorico_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_tpduplicata_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80;" +
                              "a.tp_mov|Tipo Movimento|80;" +
                              "a.CD_Historico_Dup|Cd. Historico|80;" +
                              "e.DS_Historico|Historico Financeiro|200";
            string vParam = tp_movimento.SelectedValue == null ? string.Empty :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? "a.tp_mov|=|'P'" :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") ? "a.tp_mov|=|'R'" : string.Empty;
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata_fix, ds_tpduplicata_fix, tp_movduplicata_fix },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
            if (linha != null)
            {
                cd_historico_fix.Text = linha["cd_historico_dup"].ToString();
                cd_historico_fix_Leave(this, new EventArgs());
            }
        }

        private void tp_duplicata_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata_fix.Text.Trim() + "'";
            vParam += tp_movimento.SelectedValue == null ? string.Empty :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? ";a.tp_mov|=|'P'" :
                tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") ? ";a.tp_mov|=|'R'" : string.Empty;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata_fix, ds_tpduplicata_fix, tp_movduplicata_fix },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
            if (linha != null)
            {
                cd_historico_fix.Text = linha["cd_historico_dup"].ToString();
                cd_historico_fix_Leave(this, new EventArgs());
            }
        }

        private void bb_tpdocto_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                               "a.tp_docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto_fix, ds_tpdocto_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto_fix.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto_fix, ds_tpdocto_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_contager_fix_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                "where k.CD_ContaGer = a.CD_ContaGer " +
                                "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "')";
            if(tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    if(St_lancartitulo)
                        vParam += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                    else
                        vParam += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
                else if(tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                    vParam += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager_fix, ds_contager_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_fix_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager_fix.Text.Trim() + "';"+
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                "where k.CD_ContaGer = a.CD_ContaGer " +
                                "and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "')";
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    if (St_lancartitulo)
                        vParam += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                    else
                        vParam += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
                else if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                    vParam += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager_fix, ds_contager_fix },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_tipoamostra1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|200;" +
                              "a.cd_tipoamostra|Cd. Amostra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tipoamostra1, ds_tipoamostra1 },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
        }

        private void cd_tipoamostra1_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tipoamostra|=|'" + cd_tipoamostra1.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tipoamostra1, ds_tipoamostra1 },
                                    new CamadaDados.Graos.TCD_CadAmostra());
        }

        private void bb_tipoamostra2_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_amostra|Amostra|200;" +
                              "a.cd_tipoamostra|Cd. Amostra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tipoamostra2, ds_tipoamostra2 },
                                    new CamadaDados.Graos.TCD_CadAmostra(), string.Empty);
        }

        private void cd_tipoamostra2_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tipoamostra|=|'" + cd_tipoamostra2.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tipoamostra2, ds_tipoamostra2 },
                                    new CamadaDados.Graos.TCD_CadAmostra());
        }

        private void TFContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_commoditties, 'N')|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            if (tp_movimento.SelectedValue != null)
                vParam += ";a.tp_movimento|=|'" + tp_movimento.SelectedValue.ToString() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50;A.st_ValoresFixos|Permitir valores fixos|50;A.ST_Deposito|Deposito Produto|50",
                                    new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
            if (linha != null)
            {
                (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_valoresfixos = linha["st_valoresfixos"].ToString().Trim().Equals("S");
                (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_deposito = linha["st_deposito"].ToString().Trim().Equals("S");
            }
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "isnull(a.st_commoditties, 'N')|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            if (tp_movimento.SelectedValue != null)
                vParam += ";a.tp_movimento|=|'" + tp_movimento.SelectedValue.ToString() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
            if (linha != null)
            {
                (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_valoresfixos = linha["st_valoresfixos"].ToString().Trim().Equals("S");
                (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_deposito = linha["st_deposito"].ToString().Trim().Equals("S");
            }
        }

        private void BB_Moeda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Moeda_Singular|Moeda|200;a.Sigla|Sigla|80;a.CD_Moeda|Cód. Moeda|80"
                                     , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                                     new CamadaDados.Financeiro.Cadastros.TCD_Moeda(),
                                     string.Empty);
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_moeda|=|'" + CD_Moeda.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string cond = "|exists|(select 1 from tb_gro_descontoXproduto x " +
                          "         where x.cd_produto = a.cd_produto " +
                          "         and x.cd_tabeladesconto = '" + cd_tabeladesconto.Text.Trim() + "')";
            if (tp_movimento.SelectedValue == null ? false : tp_movimento.SelectedValue.ToString().Equals("S"))
                cond += (cond.Equals(string.Empty) ? string.Empty : ";") + "||((a.tp_produto is null) or (exists(select 1 from tb_est_tpproduto x " +
                                                                                    "where x.tp_produto = a.tp_produto " +
                                                                                    "and isnull(x.st_mprima, 'N') <> 'S')))";


            DataRowView linha = UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, cond);
            if (linha != null)
            {
                cd_unidestoque.Text = linha["cd_unidade"].ToString();
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
            }
        }
                
        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Unidade|Ds Unidade|300;CD_Unidade|Cd.Unidade|80;Sigla_Unidade|Unid|60",
                new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD, sg_vlbonificacao_fix },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Unidade|=|'" + CD_Unidade.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD, sg_vlbonificacao_fix },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void bb_local_Click_1(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(cd_empresa.Text.Trim()))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, cd_empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text.Trim()))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vColunas = "a.DS_Local|Local Armazenagem|300;" +
                                  "a.CD_Local|Cd. Local|80";
            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local }, new TCD_CadLocalArm(CD_Produto.Text, cd_empresa.Text), string.Empty);
            else if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
            {
                string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                "where x.cd_local = a.cd_local " +
                                "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
                UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
            }
            else if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
            {
                string vParam = "|exists|(select top 1 from tb_est_localarm_x_produto x " +
                                "where x.cd_local = a.cd_local " +
                                "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
            }
            else
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), null);
        }

        private void cd_local_Leave_1(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(cd_empresa.Text.Trim()))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, cd_empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text.Trim()))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca("", CD_Produto.Text);

            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_local.Text.Trim() + "'", new Componentes.EditDefault[] { cd_local, ds_local }, new TCD_CadLocalArm(CD_Produto.Text, cd_empresa.Text));
            else if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
            {
                string vColunas = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                                  "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                  "where x.cd_local = a.cd_local " +
                                  "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
            }
            else if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
            {
                string vColunas = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                                  "|exists|(select 1 from tb_est_localarm_x_produto x " +
                                  "where x.cd_local = a.cd_local " +
                                  "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
            }
            else
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_local.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_local, ds_local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bb_inserirdesdobro_Click(object sender, EventArgs e)
        {
            this.InserirDesdobro();
        }

        private void bb_alterardesdobro_Click(object sender, EventArgs e)
        {
            this.AlterarDesdobro();
        }

        private void bb_excluirdesdobro_Click(object sender, EventArgs e)
        {
            this.ExcluirDesdobro();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string cond = "|exists|(select 1 from tb_gro_descontoXproduto x " +
                          "         where x.cd_produto = a.cd_produto " +
                          "         and x.cd_tabeladesconto = '" + cd_tabeladesconto.Text.Trim() + "')";
            if (tp_movimento.SelectedValue == null ? false : tp_movimento.SelectedValue.ToString().Equals("S"))
                cond += (cond.Equals(string.Empty) ? string.Empty : ";") + "||((a.tp_produto is null) or (exists(select 1 from tb_est_tpproduto x " +
                                                                                    "where x.tp_produto = a.tp_produto " +
                                                                                    "and isnull(x.st_mprima, 'N') <> 'S')))";


            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(cond, new Componentes.EditDefault[] { CD_Produto, DS_Produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null)
            {
                cd_unidestoque.Text = linha["cd_unidade"].ToString();
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
            }
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((Quantidade.Value > decimal.Zero) &&
                (Vl_Unitario.Value > decimal.Zero))
                Sub_Total.Value = TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text,
                                                                 CD_Unidade.Text,
                                                                 Quantidade.Value * Vl_Unitario.Value,
                                                                 2,
                                                                 null);
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            if ((Quantidade.Value > decimal.Zero) &&
                (Vl_Unitario.Value > decimal.Zero))
                Sub_Total.Value = TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text,
                                                                 CD_Unidade.Text,
                                                                 Quantidade.Value * Vl_Unitario.Value,
                                                                 2,
                                                                 null);
        }

        private void Sub_Total_Leave(object sender, EventArgs e)
        {
            if ((Sub_Total.Value > decimal.Zero) &&
                (Vl_Unitario.Value > decimal.Zero))
                Quantidade.Value = TCN_CadConvUnidade.ConvertUnid(CD_Unidade.Text,
                                                                  cd_unidestoque.Text,
                                                                  Sub_Total.Value,
                                                                  2,
                                                                  null);
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(cd_clifor.Text, null);
                    rClifor.lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                                                  cd_endereco.Text,
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
                    rClifor.lContato = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                      cd_clifor.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      false,
                                                                                                      false,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      0,
                                                                                                      null);
                    fClifor.rClifor = rClifor;
                }
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                        nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                        cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        cd_tabeladesconto.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
                
        private void bbCadEndereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                using (Financeiro.Cadastros.TFEndereco fEndereco = new Financeiro.Cadastros.TFEndereco())
                {
                    if (!string.IsNullOrEmpty(cd_endereco.Text))
                        fEndereco.rEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                                                   cd_endereco.Text,
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
                                                                                                   null)[0];
                    if (fEndereco.ShowDialog() == DialogResult.OK)
                        if (fEndereco.rEnd != null)
                            try
                            {
                                fEndereco.rEnd.Cd_clifor = cd_clifor.Text;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(fEndereco.rEnd, null);
                                MessageBox.Show("Endereço cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_endereco.Text = fEndereco.rEnd.Cd_endereco;
                                ds_endereco.Text = fEndereco.rEnd.Ds_endereco;
                                cd_tabeladesconto.Focus();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
    }
}
