using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Querys;
using Querys.Financeiro;
using Utils;
using Querys.Estoque;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Compra.Lancamento;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque.Cadastros;


namespace Compra
{
    public partial class TFDigitar_Cotacao : FormPadrao.FFormPadrao
    {
        public TFDigitar_Cotacao()
        {
            InitializeComponent();
        }

        private void BB_CondPGTO_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;" +
                                   "a.cd_condPGTO|Código|100",
                                   new Componentes.EditDefault[]{ CD_CondPGTO, DS_CondPGTO },
                                   new TDatCondPgto(),
                                   "");
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondPGTO|=|'" + CD_CondPGTO.Text + "'",
                                    new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPGTO }, new TDatCondPgto());
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'",
                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TDatClifor());
        }

        private void BB_Requisitante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90",
                                   new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TDatClifor(), null);
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
            pDadosCotacaoItem.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                base.afterNovo();
                if (tcCentral.SelectedIndex == 0)
                {
                    BS_Cotacao.AddNew();
                    BS_Cotacao.ResetCurrentItem();
                    if (!(CD_Clifor.Focus()))
                        CD_Clifor.Focus();
                    habilitarCombo(true);
                }
                else
                {
                    BS_Cotacao_Item.AddNew();
                    BS_Cotacao.ResetCurrentItem();
                    pDadosCotacaoItem.HabilitarControls(true, this.vTP_Modo);
                    pDadosAdicionais.HabilitarControls(true, this.vTP_Modo);
                    ST_Cotacao_Item.Enabled = true;
                    if (!(Cd_Produto.Focus()))
                        Cd_Produto.Focus();
                }
            }
        }

        public void habilitarCombo(bool habilitar)
        {
            TP_Frete.Enabled = habilitar;
            //ST_Cotacao.Enabled = habilitar;
            ST_Prioridade.Enabled = habilitar;
            ID_Cotacao.Enabled = habilitar;
        }

        public override void afterCancela()
        {
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                if (tcCentral.SelectedIndex == 0)
                {
                    BS_Cotacao.RemoveCurrent();
                }
                else
                {
                    BS_Cotacao_Item.RemoveCurrent();
                }
            }
            base.afterCancela();
            //habilitarCombo(true);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (tcCentral.SelectedIndex == 0)
                {
                    CD_Clifor.Focus();
                    habilitarCombo(true);
                }
                else
                {
                    pDadosCotacaoItem.HabilitarControls(true, this.vTP_Modo);
                    pDadosAdicionais.HabilitarControls(true, this.vTP_Modo);
                    ST_Cotacao_Item.Enabled = true;
                    Cd_Produto.Enabled = true;
                    bbProduto.Enabled = true;
                    Cd_Produto.Focus();
                }
            }
        }

        public override void excluirRegistro()
        {
            if (BS_Cotacao.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        if (tcCentral.SelectedIndex == 0)
                        {
                            TCN_LanCotacao.Deleta_LanCotacao((BS_Cotacao.Current as TRegistro_LanCotacao));
                            BS_Cotacao.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                        else
                        {
                            TCN_LanCotacao_Item.Deleta_LanCotacao_Item((BS_Cotacao_Item.Current as TRegistro_LanCotacao_Item));
                            BS_Cotacao_Item.RemoveCurrent();
                            pDadosCotacaoItem.LimparRegistro();
                            pDadosAdicionais.LimparRegistro();
                            afterBusca();
                        }
                    }
                }
            }
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                TList_LanCotacao lista = TCN_LanCotacao.Busca(ID_Cotacao.Value, CD_Clifor.Text, CD_CondPGTO.Text, Nm_Contato.Text, NM_Vendedor.Text);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_Cotacao.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        {
                            BS_Cotacao.Clear();

                        }

                    return lista.Count;
                }
            }
            else
            {
                TList_LanCotacao_Item lista = TCN_LanCotacao_Item.Busca(ID_Cotacao.Value, Cd_Produto.Text);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_Cotacao_Item.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        {
                            BS_Cotacao_Item.Clear();

                        }

                    return lista.Count;
                }
            }
            return 0;
        }

        public override string gravarRegistro()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if (pDados.validarCampoObrigatorio())
                {
                    return TCN_LanCotacao.Grava_LanCotacao((BS_Cotacao.Current as TRegistro_LanCotacao), null);
                }
            }
            else
            {
                if (pDadosCotacaoItem.validarCampoObrigatorio() && pDadosAdicionais.validarCampoObrigatorio())
                {
                    //ADICIONA O ID DA COTAÇÃO PARA O BS_COTACAO_ITEM
                    (BS_Cotacao_Item.Current as TRegistro_LanCotacao_Item).ID_Cotacao = (BS_Cotacao.Current as TRegistro_LanCotacao).ID_Cotacao;

                    //RECEBE O TIPO DE COTAÇÃO QUE ESTARA AGUARDANDO RESPOSTA DO FORNECEDOR
                    (BS_Cotacao_Item.Current as TRegistro_LanCotacao_Item).ST_Cotacao = "AR";

                    return TCN_LanCotacao_Item.Grava_LanCotacao_Item((BS_Cotacao_Item.Current as TRegistro_LanCotacao_Item), null);
                }
            }
            return "";
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.cd_produto|Código Produto|80;a.ds_produto|Nome Produto|350",
                                   new Componentes.EditDefault[] { Cd_Produto, Ds_Produto }, new TCD_CadProduto(), "");
        }

        private void Cd_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + Cd_Produto.Text + "'",
                                    new Componentes.EditDefault[] { Cd_Produto, Ds_Produto }, new TCD_CadProduto());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new TDatUnidade(), "");
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new TDatUnidade());
        }

        private void bb_Requisicao_Click(object sender, EventArgs e)
        {
            string vColunas = "ID_Requisicao|Código Requisição|80;" +
                              "b.ds_produto|Produto|350;"+
                              "NM_clifor_requisitante|Clifor Requisitante|350";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Requisicao },
                                    new TCD_LanCMP_Requisicao(), "");
        }

        private void ID_Requisicao_Leave(object sender, EventArgs e)
        {
            string vColunas = "ID_Requisicao|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Requisicao },
                                    new TCD_LanCMP_Requisicao());
        }

        private void tabCotacaoItem_Enter(object sender, EventArgs e)
        {
            if (tcCentral.SelectedIndex == 1)
            {
                if (BS_Cotacao.Current != null && (BS_Cotacao.Current as TRegistro_LanCotacao).ID_Cotacao > 0M)
                {
                    ID_Cotacao.Enabled = false;
                    buscarRegistros();
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("Atenção, é necessário selecionar uma cotação para lançar items!");
                }
            }
        }
    }
}
