using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using Utils;
using FormBusca;

namespace Compra
{
    public partial class FConsultaEstoque : Form
    {
        public FConsultaEstoque()
        {
            InitializeComponent();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|" + cd_empresa.Text.Trim() + ";" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void FConsultaEstoque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto }, string.Empty);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = " + CD_Produto.Text.Trim() + ") or " +
                              "(exists(select 1 from tb_est_codbarra x " +
                              "         where x.cd_produto = a.cd_produto " +
                              "         and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca();
        }

        private void Busca()
        {
            
                TpBusca[] filtro = new TpBusca[0];
                if (cd_empresa.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                if (CD_Produto.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
                }
                if (cd_grupo.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_grupo";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "%'";
                }
                //if (tp_produto.Text.Trim() != string.Empty)
                //{
                //    Array.Resize(ref filtro, filtro.Length + 1);
                //    filtro[filtro.Length - 1].vNM_Campo = "b.tp_produto";
                //    filtro[filtro.Length - 1].vOperador = "=";
                //    filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
                //}
                if (cbProdSaldoMinimo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto_QTDEstoque x " + 
                                                          "where x.cd_produto = a.cd_produto " + 
                                                          "and x.cd_empresa = a.cd_empresa " + 
                                                          "and x.qt_min_estoque > a.tot_saldo) ";
                }
                if (cbItensSaldo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Tot_Saldo";
                    filtro[filtro.Length - 1].vOperador = ">";
                    filtro[filtro.Length - 1].vVL_Busca = "0";
                }
                bsSintetico.DataSource = new TCD_LanEstoque().BuscarEstoqueSinteticoSaldo(filtro, string.Empty, "b.ds_produto");
                bsSintetico.ResetCurrentItem();
                //bsSintetico_PositionChanged(this, new EventArgs());
                ////Buscar custo total do estoque
                //vl_custototalestoque.Value = TCN_LanEstoque.CustoTotalEstoque("'" + cd_empresa.Text.Trim() + "'", null);
            
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FConsultaEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                Busca();
            if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gSintetico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bsSintetico_PositionChanged(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
            {
                TpBusca[] filtro = new TpBusca[0];
                if (cd_empresa.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                if (CD_Produto.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
                }
                if (cd_grupo.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_grupo";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "%'";
                }
                //if (tp_produto.Text.Trim() != string.Empty)
                //{
                //    Array.Resize(ref filtro, filtro.Length + 1);
                //    filtro[filtro.Length - 1].vNM_Campo = "b.tp_produto";
                //    filtro[filtro.Length - 1].vOperador = "=";
                //    filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
                //}
                if (cbProdSaldoMinimo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto_QTDEstoque x " +
                                                          "where x.cd_produto = a.cd_produto " +
                                                          "and x.cd_empresa = a.cd_empresa " +
                                                          "and x.qt_min_estoque > a.tot_saldo) ";
                }
                if (cbItensSaldo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Tot_Saldo";
                    filtro[filtro.Length - 1].vOperador = ">";
                    filtro[filtro.Length - 1].vVL_Busca = "0";
                }


                if (!string.IsNullOrEmpty((bsSintetico.Current as DataRowView)["cd_produto"].ToString()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = (bsSintetico.Current as DataRowView)["cd_produto"].ToString();
                }
                object saldo_minimo = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintenticoSaldoEscalar(
                                    filtro,
                                    " a.tot_saldo");
                object requisicao = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintenticoSaldoEscalar(
                                    filtro,
                                    "qtd_requisicao = (select isnull(sum(o.quantidade),0) from tb_cmp_requisicao o  " +
                                    "	where o.cd_produto = a.cd_produto and a.cd_empresa = o.CD_Empresa  " +
                                    "	and isnull((select top 1 x.Nr_Pedido from TB_FAT_Pedido_Itens x  " +
                                    "	inner join TB_CMP_OrdemCompra_X_PedItem y  " +
                                    "	on x.CD_Produto = y.CD_Produto  " +
                                    "	and x.Nr_Pedido = y.Nr_Pedido  " +
                                    "	and x.ID_PedidoItem = y.ID_PedidoItem  " +
                                    "	inner join TB_CMP_OrdemCompra h  " +
                                    "	on y.ID_OC = h.ID_OC  " +
                                    "	join vtb_fat_pedido ped on ped.nr_pedido = x.nr_pedido  " +
                                    "	where ped.vl_totalfat_entrada > 0  " +
                                    "	and a.CD_Empresa = h.CD_Empresa  " +
                                    "	and a.CD_Produto = x.CD_Produto  " +
                                    "	and o.ID_Requisicao = h.ID_Requisicao  " +
                                    "	and h.ST_Registro <> 'C'  " +
                                    "	and x.ST_Registro <> 'C'), 0) = 0)   ");

                object qtd_orcamento = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintenticoSaldoEscalar(
                                    filtro,
                                    "qtd_orcamento = ( select isnull(sum(x.quantidade),0) from TB_FAT_Orcamento_Item x  " +
                                    "                 join TB_EST_Produto_QTDEstoque z on x.cd_produto = z.cd_produto  " +
                                    "                 join vTB_FAT_Orcamento op on x.nr_orcamento = op.NR_Orcamento  " +
                                    "                 where x.cd_produto = a.cd_produto and op.st_registro = 'AB')  ");

                object qtd_pedido = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintenticoSaldoEscalar(
                                    filtro,
                                    "qtd_pedido = (select isnull(sum(o.quantidade),0) from tb_fat_pedido_itens o  " +
                                    "                 join TB_EST_Produto_QTDEstoque z on o.cd_produto = z.cd_produto  " +
                                    "                 join vtb_fat_pedido pe on o.Nr_Pedido = pe.Nr_Pedido where o.cd_produto = a.cd_produto and pe.vl_totalfat_entrada = 0 and pe.st_pedido <> 'P' ) ");

                object saldo_total = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintenticoSaldoEscalar(
                                    filtro,
                                    "saldo_total = ( ( isnull( " +
                "        		    a.tot_saldo , 0) " +
                "                        	+ " +
                "                        		(select isnull(sum(o.quantidade),0) from tb_cmp_requisicao o " +
                "                        		where o.cd_produto = a.cd_produto and a.cd_empresa = o.CD_Empresa " +
                "                        		and isnull((select top 1 x.Nr_Pedido from TB_FAT_Pedido_Itens x " +
                "                        		inner join TB_CMP_OrdemCompra_X_PedItem y " +
                "                        		on x.CD_Produto = y.CD_Produto " +
                "                        		and x.Nr_Pedido = y.Nr_Pedido " +
                "                        		and x.ID_PedidoItem = y.ID_PedidoItem " +
                "                        		inner join TB_CMP_OrdemCompra h " +
                "                        		on y.ID_OC = h.ID_OC " +
                "                        		join vtb_fat_pedido ped on ped.nr_pedido = x.nr_pedido " +
                "                        		where ped.vl_totalfat_entrada > 0 " +
                "                        		and a.CD_Empresa = h.CD_Empresa " +
                "                        		and a.CD_Produto = x.CD_Produto " +
                "                        		and o.ID_Requisicao = h.ID_Requisicao " +
                "                        		and h.ST_Registro <> 'C' " +
                "                        		and x.ST_Registro <> 'C'), 0) = 0 ) " +
                "                        	) - (   " +
                "                        		( select isnull(sum(x.quantidade),0) from TB_FAT_Orcamento_Item x " +
                "                        		join TB_EST_Produto_QTDEstoque z on x.cd_produto = z.cd_produto " +
                "                        		join vTB_FAT_Orcamento op on x.nr_orcamento = op.NR_Orcamento " +
                "                        		where x.cd_produto = a.cd_produto and op.st_registro = 'AB') " +
                "                        	+ " +
                "                        		(select isnull(sum(o.quantidade),0) from tb_fat_pedido_itens o " +
                "                        		join TB_EST_Produto_QTDEstoque z on o.cd_produto = z.cd_produto " +
                "                        		join vtb_fat_pedido pe on o.Nr_Pedido = pe.Nr_Pedido where o.cd_produto = a.cd_produto and pe.vl_totalfat_entrada = 0 and pe.st_pedido <> 'P'" +
                "                        		) ) " +
                "                        	) ");


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Soma dos totais de requisição: " + Convert.ToDecimal(requisicao).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) +" + saldo em estoque: " + Convert.ToDecimal(saldo_minimo).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)));
                sb.AppendLine("Subtraido pela soma de todos pedidos: " + Convert.ToDecimal(qtd_pedido).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) + " + total de orcamentos: " + Convert.ToDecimal(qtd_orcamento).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)));
                sb.AppendLine("Saldo total: " + Convert.ToDecimal(saldo_total).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)));
                richtbDetalhe.Text = sb.ToString();

            }
            else
                richtbDetalhe.Text = "";
        }
    }
}
