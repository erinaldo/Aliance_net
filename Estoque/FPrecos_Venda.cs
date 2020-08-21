using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using Utils;
using CamadaDados.Estoque;
using CamadaNegocio.Diversos;
using CamadaNegocio.Estoque.Cadastros;

namespace Estoque
{
    public partial class TFPrecos_Venda : FormPadrao.FFormPadrao
    {
        public TFPrecos_Venda()
        {
            InitializeComponent();
        }
             
        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                                "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());
            
            if ((CD_Empresa.Text != string.Empty) && (CD_TabelaPreco.Text != string.Empty))
            {
                afterBusca();
            }
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TabelaPreco|Descrição da Tabela de Preço|300;a.CD_TabelaPreco|Cd. Tab.Preço|80"
                                    , new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                                    new TCD_CadTbPreco(), null);
            if ((CD_Empresa.Text != string.Empty) && (CD_TabelaPreco.Text != string.Empty))
            {
                afterBusca();
            }
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_TabelaPreco|=|'" + CD_TabelaPreco.Text + "'"
             , new Componentes.EditDefault[] { CD_TabelaPreco, DS_TabelaPreco },
                                    new TCD_CadTbPreco());

            if ((CD_Empresa.Text != string.Empty) && (CD_TabelaPreco.Text != string.Empty))
            {
                afterBusca();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                            "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), vParam);

            if ((CD_Empresa.Text != string.Empty) && (CD_TabelaPreco.Text != string.Empty))
            {
                afterBusca();
            }
        }

        public override void afterNovo()
        {
            CD_Empresa.Text = "";
            NM_Empresa.Text = "";
            CD_TabelaPreco.Text = "";
            DS_TabelaPreco.Text = "";
            VL_Indice.Value = 0;
            
            DT_Preco.Text = DateTime.Now.ToString();

            Busca_Empresa();
            g_Itens.DataSource = null;
        }

        private void TFPrecos_Venda_Load(object sender, EventArgs e)
        {
            pnl_Preco.set_FormatZero();
            CD_Empresa.Enabled = true;
            bb_empresa.Enabled = true;
            CD_TabelaPreco.Enabled = true;
            BB_TabelaPreco.Enabled = true;
            DT_Preco.Enabled = true;
            VL_Indice.Enabled = true;
                

            this.gc_Preco.HeaderText = "Preço Lancto";
            this.gc_Indice.HeaderText = "Indice";

            Busca_Empresa();
            DT_Preco.Text = DateTime.Now.ToString();

            BB_Alterar.Dispose();
            BB_Cancelar.Dispose();
            BB_Excluir.Dispose();
            BB_Gravar.Dispose();
            BB_Imprimir.Dispose();
            
        }

        public override void afterBusca()
        {
            if ((CD_Empresa.Text != string.Empty) && (CD_TabelaPreco.Text != string.Empty))
            {
                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_TabelaPreco.Text + "'";
                
                
                TCD_LanPrecoItem Busca_Preco = new TCD_LanPrecoItem();
                DataTable DT_Busca_Preco = Busca_Preco.Busca_PrecosProdutos(CD_Empresa.Text, vBusca, 0, "");
                if (DT_Busca_Preco.Rows.Count > 0)
                {
                    g_Itens.DataSource = DT_Busca_Preco;
                    g_Itens.ReadOnly = false;
                    gc_CD_Produto.ReadOnly = true;
                    gc_DS_Produto.ReadOnly = true;
                    gc_VL_Preco_Venda.ReadOnly = true;
                    gc_vl_CustoMedio.ReadOnly = true;
                    gc_qtd_saldo.ReadOnly = true;
                    gc_Preco.ReadOnly = false;
                    gc_Indice.ReadOnly = false;
                }
                else
                {                    
                }
            }
            else
            {
                MessageBox.Show("É necessario informar a Empresa e a Tabela de Preço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Busca_Empresa()
        {
            TList_CadUsuario_Empresa Usuario_X_Empresa = TCN_CadUsuario_Empresa.Busca("", Utils.Parametros.pubLogin, "");

            if (Usuario_X_Empresa.Count == 1)
            {
                if (CD_Empresa.Text == "")
                {
                    CD_Empresa.Text = Usuario_X_Empresa[0].CD_Empresa.Trim();
                    NM_Empresa.Text = Usuario_X_Empresa[0].NM_Empresa.Trim();
                }
            }
        }

        private void g_Itens_RowLeave(object sender, DataGridViewCellEventArgs e)
        {           
           
                try
                {
                    if (g_Itens.CurrentRow.Cells["gc_CD_Produto"].Value.ToString() != "")
                    {
                        if (g_Itens.CurrentRow.Cells["gc_Preco"].Value.ToString() != "")
                        {
                            decimal Indice = 0;
                            if (g_Itens.CurrentRow.Cells["gc_Indice"].Value.ToString() != "")
                            {
                                Indice = Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_Indice"].Value);
                            }
                                if (DT_Preco.Text != "")
                                {
                                    TRegistro_LanPrecoItem Reg_Preco_Item = new TRegistro_LanPrecoItem();
                                    Reg_Preco_Item.CD_Produto = g_Itens.CurrentRow.Cells["gc_CD_Produto"].Value.ToString();
                                    Reg_Preco_Item.CD_TabelaPreco = CD_TabelaPreco.Text;
                                    Reg_Preco_Item.CD_Empresa = CD_Empresa.Text;
                                    Reg_Preco_Item.Dt_preco_string = DT_Preco.Text;
                                    Reg_Preco_Item.VL_PrecoVenda = Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_Preco"].Value);
                                    Reg_Preco_Item.Indice_MarkUp = Indice;
                                    Reg_Preco_Item.ST_Registro = "A";

                                    TCD_LanPrecoItem Preco_Item = new TCD_LanPrecoItem();
                                    Preco_Item.Grava(Reg_Preco_Item);
                                    MessageBox.Show("Preço Gravado com Sucesso! \r\n", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    afterBusca();
                                }
                            
                        }

                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao Gravar Preco! \r\n" +  ex.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

       


        private void g_Itens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (g_Itens.Rows.Count > 0)
            {

                if (e.ColumnIndex == 5)
                {
                    if (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_vl_CustoMedio"].Value) > 0)
                    {
                        if (g_Itens.CurrentRow.Cells["gc_Preco"].Value.ToString() != "")
                        {
                            if (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_Preco"].Value) > 0)
                            {
                                g_Itens.CurrentRow.Cells["gc_indice"].Value = ((Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_Preco"].Value)) / (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_vl_CustoMedio"].Value)));
                            };
                        }
                    }
                }
                else
                {
                    if (e.ColumnIndex == 6)
                    {
                        if (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_vl_CustoMedio"].Value) > 0)
                        {
                            if (g_Itens.CurrentRow.Cells["gc_Indice"].Value.ToString() != "")
                            {
                                if (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_Indice"].Value) > 0)
                                {
                                    g_Itens.CurrentRow.Cells["gc_preco"].Value = (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_vl_CustoMedio"].Value)) * (Convert.ToDecimal(g_Itens.CurrentRow.Cells["gc_indice"].Value));
                                }
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
        }

        private void btn_Aplicar_Indice_Click(object sender, EventArgs e)
        {
            try
            {
                if (VL_Indice.Value > 0)
                {
                    DataTable DT_Precos = (g_Itens.DataSource as DataTable);

                    if (DT_Precos.Rows.Count > 0)
                    {
                        TCN_LanPrecoItem.Grava_Lista_LanPrecoItem(DT_Precos, CD_Empresa.Text, DT_Preco.Text, CD_TabelaPreco.Text, VL_Indice.Value, null);
                    }
                }
            }
            catch
            {

            }
        }

        
    }
}
