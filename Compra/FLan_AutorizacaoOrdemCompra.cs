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
using CamadaNegocio.Compra;
using CamadaDados.Compra;
using System.Collections;
using Componentes;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFLanAutorizacaoOrdemCompra : FormPadrao.FFormPadrao
    {
        public TFLanAutorizacaoOrdemCompra()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override int buscarRegistros()
        {
            string vSTPrioridade = ST_Baixa.Checked ? "B" : ST_Normal.Checked ? "B" : ST_Urgente.Checked ? "U" : "";
            TList_LanCMP_Requisicao lista = TCN_LanCMP_Requisicao.Busca(Convert.ToDecimal(ID_Requisicao_busca.Text.Equals("") ? "0" : ID_Requisicao_busca.Text), 
                                                                        CD_Clifor_Busca.Text,
                                                                        CD_CCusto_Busca.Text, CD_Produto_busca.Text, 
                                                                        "", ST_aprovada.Checked ? "S" : "",
                                                                        ST_reprovada.Checked ? "S" : "",
                                                                        "S", "", "", "", "", "", vSTPrioridade, "", false, true);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    BS_Requisicoes.DataSource = lista;
                }
                else
                {
                    BS_Requisicoes.Clear();
                    BS_Cotacao.Clear();
                    BS_Item.Clear();
                }

                return lista.Count;
            }
            return 0;
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();

            ID_Requisicao_busca.Enabled = true;
            CD_Clifor_Busca.Enabled = true;
            CD_Empresa_Busca.Enabled = true;
            CD_CCusto_Busca.Enabled = true;
            CD_Produto_busca.Enabled = true;

            bb_Requisicao.Enabled = true;
            BB_Requisitante.Enabled = true;
            BB_Empresa_busca.Enabled = true;
            bb_Ccusto_busca.Enabled = true;
            bb_Produto_busca.Enabled = true;

            ST_aprovada.Checked = true;
            ST_Normal.Checked = true;

            ID_Requisicao_busca.Focus();
        }

        public override void afterBusca()
        {
            buscarRegistros();
        }

        private void BS_Requisicao_CurrentChanged(object sender, EventArgs e)
        {
            Busca_Cotacao();
        }

        public void Busca_Cotacao()
        {
            if (BS_Requisicoes.Current != null)
            {
                if ((BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao > 0M)
                {
                    TList_LanCotacao lista = TCN_LanCotacao.Busca(0, "", "", "", "", "", "S", "", "", "", "",
                                                                  Convert.ToDecimal((BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao));
                    if (lista != null)
                    {
                        if (lista.Count > 0)
                        {
                            BS_Cotacao.DataSource = lista;
                        }
                        else
                        {
                            BS_Cotacao.Clear();
                            BS_Item.Clear();
                        }
                    }

                    BS_Cotacao.ResetBindings(true);
                }
            }
        }

        private void bb_GerarOrdemCompra_Click(object sender, EventArgs e)
        {
            LancaOrdemCompra("A");
        }

        private void bb_ReprovarCotacao_Click(object sender, EventArgs e)
        {
            //LancaOrdemCompra("C");
            if ((BS_Cotacao.Current as TRegistro_LanCotacao).ID_Cotacao > 0M
                && (BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao > 0M)
            {
                (BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ST_Requisicao = "RE";
                (BS_Cotacao.Current as TRegistro_LanCotacao).ST_Cotacao = "RF";

                //GRAVA A ALTERAÇÃO DO STATUS
                TCN_LanCMP_Requisicao.Grava_LanCMP_Requisicao((BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao), null);
                TCN_LanCotacao.Grava_LanCotacao((BS_Cotacao.Current as TRegistro_LanCotacao), null);

                buscarRegistros();
            }
        }

        private string LancaOrdemCompra(string statusOrdem)
        { 
            //CHAMA O MÉTODO PARA GERAR A ORDEM DE COMPRA
            if (BS_Cotacao.Count > 0 && BS_Requisicoes.Count > 0 && BS_Item.Count > 0)
            {
                TCN_LanOrdemCompra.LancaOrdemCompra((BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao),
                                                    (BS_Cotacao.Current as TRegistro_LanCotacao), 
                                                    (BS_Item.Current as TRegistro_LanCotacao_Item), statusOrdem);
            }

            buscarRegistros();

            return "";
        }

        private void grid_Requisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.Value != null) && (BS_Cotacao != null))
                {
                    //if (e.ColumnIndex == 2)
                    //{
                        if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO"))
                        {
                            DataGridViewRow Linha = grid_Requisicao.Rows[e.RowIndex];
                            Linha.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                        else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                        {
                            DataGridViewRow Linha = grid_Requisicao.Rows[e.RowIndex];
                            Linha.DefaultCellStyle.ForeColor = Color.ForestGreen;
                        }
                        else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADA"))
                        {
                            DataGridViewRow Linha = grid_Requisicao.Rows[e.RowIndex];
                            Linha.DefaultCellStyle.ForeColor = Color.Red;
                        }
                    //}
                }
            }
            catch
            {

            }
        }

        private void grid_Item_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.Value != null) && (BS_Cotacao != null))
                {
                    //if (e.ColumnIndex == 2)
                    //{
                    if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO"))
                    {
                        DataGridViewRow Linha = grid_Cotacao.Rows[e.RowIndex];
                        Linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADA"))
                    {
                        DataGridViewRow Linha = grid_Cotacao.Rows[e.RowIndex];
                        Linha.DefaultCellStyle.ForeColor = Color.ForestGreen;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADA"))
                    {
                        DataGridViewRow Linha = grid_Cotacao.Rows[e.RowIndex];
                        Linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    //}
                }
            }
            catch
            {

            }
        }

        private void BS_Cotacao_CurrentChanged(object sender, EventArgs e)
        {
            Busca_Items_Cotacao();
        }

        public void Busca_Items_Cotacao()
        {
            if (BS_Cotacao.Current != null)
            {
                if ((BS_Cotacao.Current as TRegistro_LanCotacao).ID_Cotacao > 0M)
                {
                    TList_LanCotacao_Item lista = TCN_LanCotacao_Item.Busca(Convert.ToDecimal((BS_Cotacao.Current as TRegistro_LanCotacao).ID_Cotacao), "",
                                                                            Convert.ToDecimal((BS_Requisicoes.Current as TRegistro_LanCMP_Requisicao).ID_Requisicao), "");
                    if (lista != null)
                    {
                        if (lista.Count > 0)
                        {
                            BS_Item.DataSource = lista;
                        }
                        else
                        {
                            BS_Item.Clear();
                        }
                    }

                    BS_Item.ResetBindings(true);
                }
            }
        }

        private void bb_Requisicao_Click(object sender, EventArgs e)
        {
            string vColunas = "ID_Requisicao|Código Requisição|80;" +
                              "a.cd_produto|Produto|80;" +
                              "b.ds_produto|Produto|350;" +
                              "a.cd_clifor_requisitante|Clifor Requisitante|80;" +
                              "NM_clifor_requisitante|Clifor Requisitante|350;" +
                              "Dt_Requisicao|Data Requisição|50;" +
                              "gru.CD_Grupo|Cód. Grupo Produto|80;" +
                              "gru.DS_Grupo|Grupo Produto|350";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Requisicao_busca, Dt_Requisicao },
                                    new TCD_LanCMP_Requisicao(), "");
        }

        private void BB_Requisitante_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Login|Des. Requisitante|350;" +
                              "a.CD_Clifor_CMP|Cód. Requisitante|100;" +
                              "c.nm_clifor|Nome do Requisitante|350";

            string vParam = "a.Tp_Usuario|=|'R';" +
                            "a.login |=| '" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Clifor_Busca, NM_Clifor_Busca },
                                new TCD_CadUsuarioCompra(), vParam);
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

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                    "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                                    "where x.cd_empresa = a.cd_empresa and x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa_Busca, NM_Empresa_busca },
                                    new TCD_CadEmpresa());
        }

        private void bb_Ccusto_busca_Click(object sender, EventArgs e)
        {
            if (!CD_Clifor_Busca.Text.Equals(""))
            {
                string vColunas = "c.DS_CCusto|Des. Centro de Custo|350;" +
                                  "a.CD_CCusto|Cód. Centro de Custo|100";
                string vParam = "|EXISTS|(select 1 from tb_cmp_usuario_x_ccusto z where z.cd_ccusto = a.cd_ccusto " +
                                  "and z.cd_clifor_cmp = '" + CD_Clifor_Busca.Text + "')";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CCusto_Busca, DS_Ccustos_busca },
                                    new TCD_CadUsuarioXCcusto(), vParam);
            }
            else
            {
                MessageBox.Show("Atenção, é necessário informar o Requisitante!");
                CD_Clifor_Busca.Focus();
            }
        }

        private void CD_CCusto_Busca_Leave(object sender, EventArgs e)
        {
            if (!CD_Clifor_Busca.Text.Equals(""))
            {
                string vColunas = "a.CD_CCusto|=|'" + CD_CCusto_Busca.Text.Trim() + "';"+
                                  "|EXISTS|(select 1 from tb_cmp_usuario_x_ccusto z where z.cd_ccusto = a.cd_ccusto " +
                                  "and z.cd_clifor_cmp = '" + CD_Clifor_Busca.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CCusto_Busca, DS_Ccustos_busca },
                                        new TCD_CadUsuarioXCcusto());
            }
            else
            {
                MessageBox.Show("Atenção, é necessário informar o Requisitante!");
                CD_Clifor_Busca.Focus();
            }
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor_Cmp|=|'" + CD_Clifor_Busca.Text.Trim() + "';" +
                              "a.Tp_Usuario|=|'R';" +
                              "a.login|=|'" + Querys.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor_Busca, NM_Clifor_Busca },
                                    new TCD_CadUsuarioCompra());
        }

        private void bb_Produto_busca_Click(object sender, EventArgs e)
        {
            string vParam = "a.st_servico|=|'N'; |EXISTS|(Select 1 from vtb_est_vlestoque s " +
                             "where s.cd_produto = a.cd_produto)";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca },vParam);
        }

        private void CD_Produto_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto_busca, DS_Produto_busca },
                                    new TCD_CadProduto());
        }

        private void ID_Requisicao_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("", new Componentes.EditDefault[] { ID_Requisicao_busca },
                                        new TDatGrupoProduto());
        }
    }
}

