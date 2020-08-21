using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Compra.Lancamento;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Compra;
using Utils;
using System.Collections;

namespace Compra
{
    public partial class TFLan_Aprovador : FormCadPadrao.FFormCadPadrao
    {
        public TFLan_Aprovador()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            pd_Filtrar.set_FormatZero();
            pd_Aprovacao.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            pd_Filtrar.HabilitarControls(value, this.vTP_Modo);
            pd_Aprovacao.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            base.afterNovo();
            this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
            BS_Requisicao.Clear();
            pd_Filtrar.LimparRegistro();
            CD_Clifor_Aprovador.Clear();
            DS_Clifor_Aprovador.Clear();
            QTD_Aprovada.Value = 0;
        }

        public override void afterBusca()
        {
            base.afterBusca();
            this.modoBotoes(this.vTP_Modo, true, false, false, false, false, true, false);
            habilitarControls(true);
            CD_Clifor_Aprovador.Clear();
            DS_Clifor_Aprovador.Clear();
            QTD_Aprovada.Value = 0;
        }

        public override int buscarRegistros()
        {
            TList_LanCMP_Requisicao lista = TCN_LanCMP_Requisicao.BuscaLanAprovador(ID_Requisicao.Text.Trim() != "" ? Convert.ToDecimal(ID_Requisicao.Text) : 0,
                                                                                  CD_CCusto_Busca.Text.Trim(),
                                                                                  CD_Produto_busca.Text.Trim(),
                                                                                  CD_Clifor_Requisitante.Text.Trim(),
                                                                                  ST_Aguardando.Checked ? "S" : "",
                                                                                  ST_aprovada.Checked ? "S" : "",
                                                                                  ST_Reprovada.Checked ? "S" : "",
                                                                                  ST_Prioridade_Baixa.Checked ? "S" : "",
                                                                                  ST_Prioridade_Media.Checked ? "S" : "",
                                                                                  ST_Prioridade_Urgente.Checked ? "S" : "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_Requisicao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Requisicao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        private void CD_CCusto_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CCusto|=|'" + CD_CCusto_Busca.Text.Trim() + "'";
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

        private void BB_Produto_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "a.st_servico|=|'N'; |EXISTS|(Select 1 from vtb_est_vlestoque s " +
                             "where s.cd_produto = a.cd_produto)";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca }, vParam);
        }

        private void CD_Produto_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca },
                                    new TCD_CadProduto());
        }

        private void CD_Requisitante_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor_Cmp|=|'" + CD_Clifor_Requisitante.Text.Trim() + "';" +
                               "a.Tp_Usuario|=| 'R';"+
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

        private void Btn_Aprova_Click(object sender, EventArgs e)
        {
            if (((BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao == "AA")||
                ((BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao == "RE")||
                 ((BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao == "AP"))
            {
                if (CD_Clifor_Aprovador.Text != "")
                {
                    if (QTD_Aprovada.Value > 0)
                    {
                        if (QTD_Aprovada.Value <= (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Quantidade)
                        {
                            {
                                TRegistro_LanCMP_Requisicao LanAp = new TRegistro_LanCMP_Requisicao();
                                LanAp.ID_Requisicao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao.Value;
                                LanAp.CD_Empresa = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Empresa;
                                LanAp.NM_Empresa = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).NM_Empresa;
                                LanAp.CD_CCusto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_CCusto;
                                LanAp.DS_CCusto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_CCusto;
                                LanAp.CD_Clifor_Requisitante = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Requisitante;
                                LanAp.DS_Clifor_Requisitante = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Requisitante;
                                LanAp.CD_Clifor_Aprovador = CD_Clifor_Aprovador.Text;
                                LanAp.DS_Clifor_Aprovador = DS_Clifor_Aprovador.Text;
                                LanAp.DS_Clifor_Comprador = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Comprador;
                                LanAp.CD_Clifor_Comprador = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Comprador;
                                LanAp.CD_Produto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Produto;
                                LanAp.DS_Produto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Produto;
                                LanAp.Dt_EntregaSolicitada = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Dt_EntregaSolicitada;
                                LanAp.Dt_Requisicao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Dt_Requisicao;
                                LanAp.ST_Prioridade = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Prioridade;
                                LanAp.TP_Aplicacao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).TP_Aplicacao;
                                LanAp.Quantidade = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Quantidade;
                                LanAp.DS_Marca = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Marca;
                                LanAp.DS_Observacao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Observacao;
                                LanAp.ST_Requisicao = "AP";
                                LanAp.QTD_Aprovada = QTD_Aprovada.Value;
                                TCN_LanCMP_Requisicao.Grava_LanCMP_Requisicao(LanAp, null);

                                (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao = "AP";
                                (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).QTD_Aprovada = QTD_Aprovada.Value;
                                (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Aprovador = CD_Clifor_Aprovador.Text;
                                (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Aprovador = DS_Clifor_Aprovador.Text;
                                BS_Requisicao.ResetCurrentItem();
                                MessageBox.Show("Requisição Aprovada Com Sucesso!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantidade APROVADA Não Pode Ser Maior que a Quantidade SOLICITADA!");
                            QTD_Aprovada.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantidade Aprovada Não Pode Ser Igual a 0");
                        QTD_Aprovada.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Campo Aprovador Deve Ser Preenchido!");
                    CD_Clifor_Aprovador.Focus();
                }
            }
            else
                MessageBox.Show("O Status deve estar como \"Reprovado\" ou \"Aguardando Aprovação\" !");

        }

        private void Btn_Reprova_Click(object sender, EventArgs e)
        {
            if (CD_Clifor_Aprovador.Text != "")
            {
                if (((BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao == "AA") ||
                    ((BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao == "AP"))
              
                {
                    TRegistro_LanCMP_Requisicao LanRep = new TRegistro_LanCMP_Requisicao();
                    LanRep.ID_Requisicao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao.Value;
                    LanRep.CD_Empresa = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Empresa;
                    LanRep.NM_Empresa = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).NM_Empresa;
                    LanRep.CD_CCusto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_CCusto;
                    LanRep.DS_CCusto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_CCusto;
                    LanRep.CD_Clifor_Requisitante = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Requisitante;
                    LanRep.DS_Clifor_Requisitante = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Requisitante;
                    LanRep.CD_Clifor_Aprovador = CD_Clifor_Aprovador.Text;
                    LanRep.DS_Clifor_Aprovador = DS_Clifor_Aprovador.Text;
                    LanRep.DS_Clifor_Comprador = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Comprador;
                    LanRep.CD_Clifor_Comprador = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Comprador;
                    LanRep.CD_Produto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Produto;
                    LanRep.DS_Produto = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Produto;
                    LanRep.Dt_EntregaSolicitada = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Dt_EntregaSolicitada;
                    LanRep.Dt_Requisicao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Dt_Requisicao;
                    LanRep.ST_Prioridade = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Prioridade;
                    LanRep.TP_Aplicacao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).TP_Aplicacao;
                    LanRep.Quantidade = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Quantidade;
                    LanRep.DS_Marca = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Marca;
                    LanRep.DS_Observacao = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Observacao;
                    LanRep.ST_Requisicao = "RE";
                    LanRep.QTD_Aprovada = 0;
                    LanRep.Quantidade = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).Quantidade;

                    TCN_LanCMP_Requisicao.Grava_LanCMP_Requisicao(LanRep, null);

                    (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao = "RE";
                    (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).QTD_Aprovada = 0;
                    (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).CD_Clifor_Aprovador = CD_Clifor_Aprovador.Text;
                    (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Clifor_Aprovador = DS_Clifor_Aprovador.Text;
                    BS_Requisicao.ResetCurrentItem();
                    MessageBox.Show("Requisição Reprovada!");
                }
                else
                    MessageBox.Show("Status deve estar como \"Aguardando Aprovação\" ou \"Aprovado\" !");
            }
            else
                MessageBox.Show("Aprovador Deve ser Preenchido!");
        }

        private void BB_Clifor_Aprovador_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Login|Des. Requisitante|350;" +
                              "a.CD_Clifor_Cmp|Cód. Requisitante|100;" +
                              "a.NM_Clifor|Nome do Requisitante|350";

            string vParam = "a.Tp_Usuario|=|'A';" +
                            "a.login |=| '" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Clifor_Aprovador, DS_Clifor_Aprovador },
                                new TCD_CadUsuarioCompra(), vParam);
        }

        private void CD_Clifor_Aprovador_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor_Cmp|=|'" + CD_Clifor_Requisitante.Text.Trim() + "';" +
                               "a.Tp_Usuario|=|'A';"+
                               "a.login|=|'" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor_Aprovador, DS_Clifor_Aprovador },
                                    new TCD_CadUsuarioCompra());
        }

        private void g_requisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if(e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().Equals("Aprovada"))
                    {
                        DataGridViewRow linha = g_requisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().Equals("Reprovada"))
                    {
                        DataGridViewRow linha = g_requisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().Equals("Aguardando Aprovação"))
                    {
                        DataGridViewRow linha = g_requisicao.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }

        }

        private void g_requisicao_SelectionChanged(object sender, EventArgs e)
        {
            if(g_requisicao.SelectedRows.Count > 0)
            DS_Observacao.Text = (BS_Requisicao.Current as TRegistro_LanCMP_Requisicao).DS_Observacao;
        }
    }
}
