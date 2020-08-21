using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Compra.Lancamento;
using Utils;
using System.Collections;
using CamadaDados.Diversos;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Compra;
using Querys;
using BancoDados;

namespace Compra
{
    public partial class TFLanCMP_Requisicao : FormCadPadrao.FFormCadPadrao
    {
        public TFLanCMP_Requisicao()
        {
            InitializeComponent();
            DTS = BS_LanCMP_Requisicao;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
            pd_Consulta.set_FormatZero();

        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            pd_lancamento.HabilitarControls(value, this.vTP_Modo);
            pd_detalheReq.HabilitarControls(false, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return TCN_LanCMP_Requisicao.Grava_LanCMP_Requisicao((BS_LanCMP_Requisicao.Current as TRegistro_LanCMP_Requisicao), null);
            }
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_LanCMP_Requisicao lista = TCN_LanCMP_Requisicao.Busca(0,
                                                                         CD_Empresa_Busca.Text.Trim(),
                                                                         CD_CCusto_Busca.Text.Trim(),
                                                                         CD_Produto_busca.Text.Trim(),
                                                                         ST_AguardandoAprovacao.Checked ? "S" : "",
                                                                         ST_aprovada.Checked ? "S" : "",
                                                                         ST_reprovada.Checked ? "S" : "",
                                                                         ST_Negociacao.Checked ? "S" : "",
                                                                         ST_OrdemCompra.Checked ? "S" : "",
                                                                         ST_PedidoConfirmado.Checked ? "S" : "",
                                                                         ST_EmEstoque.Checked ? "S" : "",
                                                                         Dt_busca_inicial.Text.Trim(),
                                                                         "",
                                                                         "", "", false, false);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_LanCMP_Requisicao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_LanCMP_Requisicao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                if (tcCentral.SelectedTab.Equals(tpPadrao))
                {
                    BS_LanCMP_Requisicao.AddNew();
                    base.afterNovo();
                    if (!CD_Empresa.Focus())
                    {
                        CD_Clifor_Requisitante.Focus();
                        this.modoBotoes(this.vTP_Modo, true, false , true, false, true, false, false);
                    }
                }
                else
                {
                    pd_Consulta.LimparRegistro();
                    BS_LanCMP_Requisicao.Clear();
                    this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
                }
            }
            if (tcCentral.SelectedTab.Equals(tpPadrao))
                this.modoBotoes(this.vTP_Modo, true, false, true, false, true, false, false);
        }

        public override void afterGrava()
        {
            base.afterGrava();
            this.modoBotoes(this.vTP_Modo, true, true, false, false, false, false, true);
        }

        public override void afterCancela()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                base.afterCancela();
            //  BS_LanCMP_Requisicao.RemoveCurrent();
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, false, true);

            }
        }

        public override void afterAltera()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                base.afterAltera();
                if (vTP_Modo == TTpModo.tm_Edit)
                    CD_Empresa.Focus();
                QTD_Aprovada.Enabled = false;
            }
        }

        public override void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tabConsulta))
            {
                base.afterBusca();
                this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
            }
            else
            {
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, false, true);
            }
        }

        public override void afterExclui()
        {
            base.afterExclui();
            this.modoBotoes(this.vTP_Modo, true, false, true, true, true, false, true);
        }

        public override void excluirRegistro()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                if (BS_LanCMP_Requisicao.DataSource != null)
                {
                    if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    {
                            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                if (bsDetalheRequisicao.Count != 0)
                                {
                                    while ((bsDetalheRequisicao.Count) != 0)
                                    {
                                        TCN_LanDetalheRequisicao.Deleta_LanDetalheRequisicao((bsDetalheRequisicao.Current as TRegistro_LanDetalheRequisicao));
                                        bsDetalheRequisicao.RemoveCurrent();
                                    }
                                }
                                TCN_LanCMP_Requisicao.Deleta_LanCMP_Requisicao(BS_LanCMP_Requisicao.Current as TRegistro_LanCMP_Requisicao);
                                BS_LanCMP_Requisicao.RemoveCurrent();
                                pDados.LimparRegistro();
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Não Existe Item Gravado Para Ser Excluído!");
                }
            }
        }

        private void TFLanCMP_Requisicao_Load(object sender, EventArgs e)
        {
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("B - Baixa", "B"));
            CBox1.Add(new Utils.TDataCombo("N - Normal", "N"));
            CBox1.Add(new Utils.TDataCombo("U - Urgente", "U"));
            ST_Prioridade.DataSource = CBox1;
            ST_Prioridade.DisplayMember = "Display";
            ST_Prioridade.ValueMember = "Value";
            ST_Prioridade.SelectedValue = "";

            ArrayList CBox2 = new ArrayList();
            CBox2.Add(new Utils.TDataCombo("E - Estoque", "E"));
            CBox2.Add(new Utils.TDataCombo("I - Imediata", "I"));
            Tp_Aplicacao.DataSource = CBox2;
            Tp_Aplicacao.DisplayMember = "Display";
            Tp_Aplicacao.ValueMember = "Value";
            Tp_Aplicacao.SelectedValue = "";

            this.tcCentral.SelectedIndex = 1;

        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string empresa_aux = "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and x.login = '" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), empresa_aux);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                                " where x.cd_empresa = a.cd_empresa and x.login = '" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());

        }

        private void BB_Empresa_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa_Busca, NM_Empresa_busca },
                                    new TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                    "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                                    "where x.cd_empresa = a.cd_empresa and x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa_Busca, NM_Empresa_busca },
                                    new TCD_CadEmpresa());
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto},"");
        }

        private void CD_PRODUTO_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, Sigla },
                                    new TCD_CadProduto());
        }

        private void BB_Produto_Busca_Click(object sender, EventArgs e)
        {
            
            string vParam = "a.st_servico|=|'N'; |EXISTS|(Select 1 from vtb_est_vlestoque s " +
                             "where s.cd_produto = a.cd_produto)";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca },vParam);
        }

        private void CD_Produto_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca },
                                    new TCD_CadProduto());
        }

        private void CD_CCusto_Leave(object sender, EventArgs e)
        {
            if (!CD_Clifor_Requisitante.Text.Equals(""))
            {
                string vColunas = "a.CD_CCusto|=|'" + CD_CCusto.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from tb_cmp_usuario_x_ccusto z where z.cd_ccusto = a.cd_ccusto " +
                                  "and z.cd_clifor_cmp = '" + CD_Clifor_Requisitante.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CCusto, DS_CCusto },
                                        new TCD_CadCentroCusto());
            }
            else
            {
                MessageBox.Show("Atenção, é necessário informar o Requisitante!");
                CD_Clifor_Requisitante.Focus();
            }
        }

        private void BB_CentroCusto_Click(object sender, EventArgs e)
        {
            if (!CD_Clifor_Requisitante.Text.Equals(""))
            {
                string vColunas = "a.DS_CCusto|Des. Centro de Custo|350;" +
                                  "a.CD_CCusto|Cód. Centro de Custo|100";
                string vParam = "|EXISTS|(select 1 from tb_cmp_usuario_x_ccusto z where z.cd_ccusto = a.cd_ccusto " +
                                      "and z.cd_clifor_cmp = '" + CD_Clifor_Requisitante.Text + "')";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CCusto, DS_CCusto },
                                    new TCD_CadCentroCusto(), vParam);
            }
            else
            {
                MessageBox.Show("Atenção, é necessário informar o Requisitante!");
                CD_Clifor_Requisitante.Focus();
            }
        }

        private void CD_CCusto_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CCusto|=|'" + CD_CCusto_Busca.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_cmp_usuario_x_ccusto z where z.cd_ccusto = a.cd_ccusto " +
                              "and z.cd_clifor_cmp = '" + CD_Clifor_Requisitante.Text + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CCusto_Busca, DS_Ccustos_busca },
                                    new TCD_CadCentroCusto());
        }

        private void BB_CentroCusto_Busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CCusto|Des. Centro de Custo|350;" +
                              "a.CD_CCusto|Cód. Centro de Custo|100";
            string vParam = "a.TP_CCusto|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CCusto_Busca, DS_Ccustos_busca },
                                new TCD_CadCentroCusto(), vParam);
        }

        private void pDados_Enter(object sender, EventArgs e)
        {
            Dt_Requisicao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            QTD_Aprovada.Enabled = false;
        }

        private void CD_Requisitante_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor_Cmp|=|'" + CD_Clifor_Requisitante.Text.Trim() + "';" +
                              "a.login|=|'" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor_Requisitante, DS_Clifor_Requisitante },
                                    new TCD_CadUsuarioCompra());
        }

        private void BB_Requisitante_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Login|Des. Requisitante|350;" +
                              "a.CD_Clifor_Cmp|Cód. Requisitante|100;" +
                              "a.NM_Clifor|Nome do Requisitante|350";

            string vParam = "a.Tp_Usuario|=|'R';" +
                            "a.login |=| '" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Clifor_Requisitante, DS_Clifor_Requisitante },
                                new TCD_CadUsuarioCompra(), vParam);
        }
               
        private void BN_DetalheRequisicao_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "BN_NovoNewItemDetalheReq")
            {
                    if ((vTP_Modo == TTpModo.tm_Edit)||(vTP_Modo == TTpModo.tm_Insert))
                    {
                    pd_detalheReq.Enabled = true;   
                    pd_detalheReq.HabilitarControls(true, vTP_Modo);
                    bsDetalheRequisicao.AddNew();
                    Ds_Produto_DetalheRequisicao.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Clique em ALTERAR ou NOVO Para Poder Adicionar Mais Um Detalhe!");
                    }
            }
            if (e.ClickedItem.Name == "BN_DeleteItemDetalheReq")
            {
                if (bsDetalheRequisicao.Count == 0)
                    pd_detalheReq.HabilitarControls(false, vTP_Modo);
                else
                {
                    try
                    {
                        TCN_LanDetalheRequisicao.Deleta_LanDetalheRequisicao((bsDetalheRequisicao.Current as TRegistro_LanDetalheRequisicao));
                        bsDetalheRequisicao.RemoveCurrent();
                    }
                    catch { throw; }
                }
            }
            if(e.ClickedItem.Name == "BN_AAdicionarDetalheReq")
            {
                //if((ID_Requisicao.Text != "") || (ID_Requisicao.Text != "0"))
                {
                    //if ((Ds_Produto_DetalheRequisicao.Text != "") || (Sigla_DetalheReq.Text != "") || (Quantidade_DetalheReq.Value > 0) || (Vl_DetalheReq.Value > 0))
                    if ((Ds_Produto_DetalheRequisicao.Text != "") || (Sigla_DetalheReq.Text != "") || (Quantidade_DetalheReq.Value > 0))
                    {
                        if (vTP_Modo == TTpModo.tm_Edit)
                        {
                            bsDetalheRequisicao.EndEdit();
                            pd_detalheReq.Enabled = false;
                            int i = (BS_LanCMP_Requisicao.Current as TRegistro_LanCMP_Requisicao).lDetalheRequisicao.Count;
                        }
                    }
                }
            }
        }

        private void Dt_EntregaSolicitada_Leave(object sender, EventArgs e)
        {
            if (Dt_EntregaSolicitada.DataString_YMD != "00010101")
            {
                if ((Dt_Requisicao.Data >= Dt_EntregaSolicitada.Data))
                {
                    MessageBox.Show("Data de Entrega Não Pode Ser Inferior a Data de Requisição!");
                    Dt_EntregaSolicitada.Focus();
                }
            }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tabConsulta))
                this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
            else
                this.modoBotoes(this.vTP_Modo, true, true, false, true, false, false, true);
        }
      
    }
}
