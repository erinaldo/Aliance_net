using System;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Faturamento.Entrega;
using CamadaNegocio.Faturamento.Comissao;
using CamadaNegocio.Compra.Lancamento;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Graos;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Faturamento.CompraAvulsa;
using CamadaDados.Faturamento.CompraAvulsa;
using CamadaNegocio.Servicos;
using CamadaDados.Servicos;

namespace CamadaNegocio.Faturamento.Pedido
{
    #region Classe Pedido Item
    public class TCN_LanPedido_Item
    {
        public static TList_RegLanPedido_Item Busca(string vCD_Empresa, 
                                                    string vNr_Contrato,
                                                    string vCD_Produto, 
                                                    string vNr_Pedido,
                                                    string vId_pedidoitem,
                                                    string vGroup,
                                                    string vOrder,
                                                    bool BuscaEntregas,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[1];
            if (!string.IsNullOrEmpty(vNr_Pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[0].vNM_Campo = "a.Nr_Pedido";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = vNr_Pedido;
            }
            if (!string.IsNullOrEmpty(vId_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_pedidoitem;
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "N.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vNr_Contrato)) && (vNr_Contrato.ToString().Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "contrato.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato;
            }

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }

            TList_RegLanPedido_Item lItens = new TCD_LanPedido_Item(banco).Select(filtro, 0, string.Empty, vGroup, vOrder);

            if (BuscaEntregas)
            {
                for (int i = 0; i < lItens.Count; i++ )
                    lItens[i].EntregaPedido = TCN_LanEntregaPedido.Busca(string.Empty, 
                                                                         lItens[i].Nr_PedidoString, 
                                                                         lItens[i].Cd_produto, 
                                                                         lItens[i].Id_pedidoitem.ToString(), 
                                                                         false,
                                                                         string.Empty,
                                                                         banco);
            }

            return lItens;
        }

        public static TList_RegLanPedido_Item BuscarItemConferencia(string Nr_pedido,
                                                                    TObjetoBanco banco)
        {
            if (Nr_pedido.Trim() != string.Empty)
            {
                TpBusca[] filtro = new TpBusca[4];
                //Pedido
                filtro[0].vNM_Campo = "a.nr_pedido";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = Nr_pedido;
                //Item do pedido tem saldo para faturar
                filtro[1].vNM_Campo = "a.quantidade";
                filtro[1].vOperador = ">";
                filtro[1].vVL_Busca = "case when n.tp_movimento = 'E' then isnull((select sum(case when y.tp_movimento = 'E' then isnull(x.quantidade, 0) else 0 end) " +
                                      "from tb_fat_notafiscal_item x " +
                                      "inner join tb_fat_notafiscal y " +
                                      "on x.cd_empresa = y.cd_empresa " +
                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                      "where isnull(y.st_registro, 'A') <> 'C' " +
                                      "and x.nr_pedido = a.nr_pedido " +
                                      "and x.cd_produto = a.cd_produto " +
                                      "and x.id_pedidoitem = a.id_pedidoitem), 0) else " +
                                      "isnull((select sum(case when y.tp_movimento = 'S' then isnull(x.quantidade, 0) else 0 end) " +
                                      "from tb_fat_notafiscal_item x " +
                                      "inner join tb_fat_notafiscal y " +
                                      "on x.cd_empresa = y.cd_empresa " +
                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                      "where isnull(y.st_registro, 'A') <> 'C' " +
                                      "and x.nr_pedido = a.nr_pedido " +
                                      "and x.cd_produto = a.cd_produto " +
                                      "and x.id_pedidoitem = a.id_pedidoitem), 0) end ";
                //Nao existe conferencia para o pedido
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "not exists";
                filtro[2].vVL_Busca = "(select 1 from TB_FAT_EntregaPedido x " +
                                      "where x.NR_PEDIDO = a.Nr_Pedido " +
                                      "and x.CD_PRODUTO = a.CD_Produto " +
                                      "and x.ID_PEDIDOITEM = a.ID_PedidoItem " +
                                      "and ((isnull(x.ST_REGISTRO, 'A') = 'A') or ( " +
                                      "     (x.QTD_ENTREGUE - isnull((case when n.tp_movimento = 'E' then " +
                                      "     (select isnull(SUM(case when y.Tp_Movimento = 'E' then " +
                                      "     isnull(x.Quantidade, 0) else 0 end), 0) " +
                                      "     from tb_fat_notafiscal_item x " +
                                      "     inner join tb_fat_notafiscal y " +
                                      "     on x.cd_empresa = y.cd_empresa " +
                                      "     and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                      "     where x.nr_pedido = a.nr_pedido " +
                                      "     and x.cd_produto = a.cd_produto " +
                                      "     and x.id_pedidoitem = a.id_pedidoitem " +
                                      "     and isnull(y.st_registro, 'A') <> 'C') else " +
                                      "     (select isnull(SUM(case when y.Tp_Movimento = 'S' then " +
                                      "     isnull(x.Quantidade, 0) else 0 end), 0) " +
                                      "     from tb_fat_notafiscal_item x " +
                                      "     inner join tb_fat_notafiscal y " +
                                      "     on x.cd_empresa = y.cd_empresa " +
                                      "     and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                      "     where x.nr_pedido = a.nr_pedido " +
                                      "     and x.cd_produto = a.cd_produto " +
                                      "     and x.id_pedidoitem = a.id_pedidoitem " +
                                      "     and isnull(y.st_registro, 'A') <> 'C') end), 0)) > 0))) ";
                //Item nao e servico
                filtro[3].vNM_Campo = "isnull(tpProd.st_servico, 'N')";
                filtro[3].vOperador = "<>";
                filtro[3].vVL_Busca = "'S'";
                return new TCD_LanPedido_Item(banco).Select(filtro, 0, string.Empty, string.Empty, string.Empty);
            }
            else
                return new TList_RegLanPedido_Item();
        }

        public static DataTable BuscaSaldoMestra(string vNR_Pedido,
                                                 string vCd_produto,
                                                 string vTp_serie,
                                                 ref decimal saldoQuantidade,
                                                 ref decimal saldoValor,
                                                 short vTop,
                                                 string vNM_Campo,
                                                 TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[2];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            vBusca[1].vNM_Campo = "a.Quantidade";
            vBusca[1].vOperador = ">";
            vBusca[1].vVL_Busca = "0";
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = vTp_serie.Trim().ToUpper().Equals("P") ? "<>" : "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vTp_serie.Trim().ToUpper() != "M" ? "'S'" : "isnull(a.st_servico, 'N')";
            }
            TCD_LanPedido_Item qtb_peditem = new TCD_LanPedido_Item("SqlCodeBuscaSaldoMestra");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_peditem.CriarBanco_Dados(false);
                else
                    qtb_peditem.Banco_Dados = banco;
                DataTable tabela = qtb_peditem.Buscar(vBusca, vTop, vNM_Campo);
                if ((tabela != null) && (vCd_produto.Trim() != string.Empty))
                    if (tabela.Rows.Count > 0)
                    {
                        try
                        {
                            saldoQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                        }
                        catch
                        { saldoQuantidade = 0; }
                        try
                        {
                            saldoValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                        }
                        catch
                        { saldoValor = 0; }
                    }
                return tabela;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (pode_liberar)
                    qtb_peditem.deletarBanco_Dados();
            }
        }

        public static DataTable BuscaSaldoNFNormal(string vNR_Pedido,
                                                   string vCd_produto,
                                                   string vId_pedidoitem,
                                                   string vTp_serie,
                                                   ref decimal saldoQuantidade,
                                                   ref decimal saldoValor,
                                                   short vTop,
                                                   string vNM_Campo,
                                                   TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[3];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            vBusca[1].vNM_Campo = "a.Quantidade";
            vBusca[1].vOperador = ">";
            vBusca[1].vVL_Busca = "0";
            vBusca[2].vNM_Campo = "a.vl_subtotal";
            vBusca[2].vOperador = ">";
            vBusca[2].vVL_Busca = "0";
            
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_pedidoitem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_pedidoitem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = vTp_serie.Trim().ToUpper().Equals("P") ? "<>" : "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vTp_serie.Trim().ToUpper() != "M" ? "'S'" : "isnull(a.st_servico, 'N')";
            }
            TCD_LanPedido_Item qtb_peditem = new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_peditem.CriarBanco_Dados(false);
                else
                    qtb_peditem.Banco_Dados = banco;
                DataTable tabela = qtb_peditem.Buscar(vBusca, 0);
                if ((tabela != null) && (vCd_produto.Trim() != string.Empty))
                    if (tabela.Rows.Count > 0)
                    {
                        try
                        {
                            saldoQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                        }
                        catch
                        { saldoQuantidade = 0; }
                        try
                        {
                            saldoValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                        }
                        catch
                        { saldoValor = 0; }
                    }
                return tabela;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (pode_liberar)
                    qtb_peditem.deletarBanco_Dados();
            }
        }

        public static DataTable BuscaSaldoNFComplemento(string vNR_Pedido,
                                                        string vCd_produto,
                                                        string vId_pedidoitem,
                                                        string vTp_serie,
                                                        ref decimal saldoQuantidade,
                                                        ref decimal saldoValor,
                                                        short vTop,
                                                        string vNM_Campo,
                                                        TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[2];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";

            vBusca[1].vNM_Campo = string.Empty;
            vBusca[1].vOperador = string.Empty;
            vBusca[1].vVL_Busca = "a.quantidade > 0 or a.vl_subtotal > 0";

            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_pedidoitem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_pedidoitem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = vTp_serie.Trim().ToUpper().Equals("P") ? "<>" : "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vTp_serie.Trim().ToUpper() != "M" ? "'S'" : "isnull(a.st_servico, 'N')";
            }
            TCD_LanPedido_Item qtb_peditem = new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_peditem.CriarBanco_Dados(false);
                else
                    qtb_peditem.Banco_Dados = banco;
                DataTable tabela = qtb_peditem.Buscar(vBusca, 0);
                if ((tabela != null) && (vCd_produto.Trim() != string.Empty))
                    if (tabela.Rows.Count > 0)
                    {
                        try
                        {
                            saldoQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                        }
                        catch
                        { saldoQuantidade = 0; }
                        try
                        {
                            saldoValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                        }
                        catch
                        { saldoValor = 0; }
                    }
                return tabela;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (pode_liberar)
                    qtb_peditem.deletarBanco_Dados();
            }
        }

        public static DataTable BuscaSaldoSimplesRemessa(string vNR_Pedido,
                                                         string vCd_produto,
                                                         string vId_pedidoitem,
                                                         string vTp_serie,
                                                         ref decimal saldoQuantidade,
                                                         ref decimal saldoValor,
                                                         short vTop,
                                                         string vNM_Campo,
                                                         TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_pedidoitem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_pedidoitem;
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = vTp_serie.Trim().ToUpper().Equals("P") ? "<>" : "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vTp_serie.Trim().ToUpper() != "M" ? "'S'" : "isnull(a.st_servico, 'N')";
            }
            TCD_LanPedido_Item qtb_peditem = new TCD_LanPedido_Item("SqlCodeBuscaSaldoSimplesRemessa");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_peditem.CriarBanco_Dados(false);
                else
                    qtb_peditem.Banco_Dados = banco;
                DataTable tabela = qtb_peditem.Buscar(vBusca, vTop, vNM_Campo);
                if ((tabela != null) && (vCd_produto.Trim() != string.Empty))
                    if (tabela.Rows.Count > 0)
                    {
                        try
                        {
                            saldoQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                        }
                        catch
                        { saldoQuantidade = 0; }
                        try
                        {
                            saldoValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                        }
                        catch
                        { saldoValor = 0; }
                    }
                return tabela;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (pode_liberar)
                    qtb_peditem.deletarBanco_Dados();
            }
        }

        public static DataTable BuscaSaldoDevolucao(string vNR_Pedido,
                                                    string vCd_produto,
                                                    string vId_pedidoitem,
                                                    string vTp_serie,
                                                    ref decimal saldoQuantidade,
                                                    ref decimal saldoValor,
                                                    short vTop,
                                                    string vNM_Campo,
                                                    TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[2];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            //Ter saldo para devolver
            vBusca[1].vNM_Campo = string.Empty;
            vBusca[1].vOperador = string.Empty;
            vBusca[1].vVL_Busca = "(a.Quantidade > 0) or (a.Vl_subTotal > 0)";
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_pedidoitem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_pedidoitem;
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = vTp_serie.Trim().ToUpper().Equals("P") ? "<>" : "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vTp_serie.Trim().ToUpper() != "M" ? "'S'" : "isnull(a.st_servico, 'N')";
            }
            TCD_LanPedido_Item qtb_peditem = new TCD_LanPedido_Item("SqlCodeBuscaSaldoDevolucao");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_peditem.CriarBanco_Dados(false);
                    pode_liberar = true;
                }
                else
                    qtb_peditem.Banco_Dados = banco;
                DataTable tabela = qtb_peditem.Buscar(vBusca, 0);
                if ((tabela != null) && (vCd_produto.Trim() != string.Empty))
                    if (tabela.Rows.Count > 0)
                    {
                        foreach (DataRow linha in tabela.Rows)
                        {
                            try
                            {
                                saldoQuantidade = Convert.ToDecimal(linha["Quantidade"].ToString());
                            }
                            catch
                            { saldoQuantidade = 0; }
                            try
                            {
                                saldoValor = Convert.ToDecimal(linha["Vl_SubTotal"].ToString());
                            }
                            catch
                            { saldoValor = 0; }
                        }
                    }
                return tabela;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (pode_liberar)
                    qtb_peditem.deletarBanco_Dados();
            }
        }

        public static bool VerificaDisponibilidadeItemPedido(string Nr_pedido,
                                                             string Cd_produto,
                                                             string Id_pedidoitem)
        {
            if (!string.IsNullOrEmpty(Nr_pedido.Trim()))
            {
                object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = Nr_pedido
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'"+Cd_produto.Trim()+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_pedidoitem",
                            vOperador = "=",
                            vVL_Busca = Id_pedidoitem
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, "1");
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                        return true;
                    else
                        return false;
                else
                    return false;

            }
            else
                return false;
        }

        public static void totalPedido(string vNR_Pedido, string vCD_Produto, ref decimal tQuantidade, ref decimal tValor)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_LanPedido_Item qtb_saldopedido = new TCD_LanPedido_Item();
            DataTable tabela = qtb_saldopedido.Buscar(vBusca, 1, "isNull(sum(isNull(a.Quantidade,0)),0) as QTD_Saldo, isNull(sum(isNull(a.Vl_SubTotal,0)),0) as Vl_Saldo");
            if (tabela != null)
                if (tabela.Rows.Count > 0)
                {
                    try
                    {
                        tQuantidade = Convert.ToDecimal(tabela.Rows[0]["QTD_Saldo"].ToString());
                    }
                    catch
                    { tQuantidade = 0; }
                    try
                    {
                        tValor = Convert.ToDecimal(tabela.Rows[0]["Vl_Saldo"].ToString());
                    }
                    catch
                    { tValor = 0; }
                }
        }

        public static string GravaPedido_Item(TList_RegLanPedido_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Item qtb_ped = new TCD_LanPedido_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                val.ForEach(p => GravaPedido_Item(p, qtb_ped.Banco_Dados));
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string GravaPedido_Item(TRegistro_LanPedido_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Item qtb_Pedido_Item = new TCD_LanPedido_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Pedido_Item.CriarBanco_Dados(true);
                else
                    qtb_Pedido_Item.Banco_Dados = banco;
                //Verificar se esta cancelando o item
                if (val.St_registro.Trim().ToUpper().Equals("C"))
                {
                    //Excluir romaneio de entrega
                    new CamadaDados.Faturamento.Entrega.TCD_RomaneioEntrega(qtb_Pedido_Item.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_romaneio = a.id_romaneio " +
                                                "and x.nr_pedido = " + val.Nr_PedidoString + " " +
                                                "and x.cd_produto = '" + val.Cd_produto.Trim() + "' " +
                                                "and x.id_pedidoitem = " + val.Id_pedidoitem.ToString() + ")"
                                }
                            }, 0, string.Empty).ForEach(v => TCN_RomaneioEntrega.Excluir(v, qtb_Pedido_Item.Banco_Dados));
                    //Cancelar comissao
                    TCN_Fechamento_Comissao.Buscar(string.Empty,
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
                                                    val.Nr_PedidoString,
                                                    val.Cd_produto,
                                                    val.Id_pedidoitem.ToString(),
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                    string.Empty,
                                                    qtb_Pedido_Item.Banco_Dados).ForEach(p => TCN_Fechamento_Comissao.Excluir(p, qtb_Pedido_Item.Banco_Dados));
                    ////Verificar se o item teve origem ordem servico
                    //object obj = new CamadaDados.Servicos.TCD_Servico_X_PedidoItem(qtb_Pedido_Item.Banco_Dados).BuscarEscalar(
                    //                new TpBusca[]
                    //                {
                    //                    new TpBusca()
                    //                    {
                    //                        vNM_Campo = "a.nr_pedido",
                    //                        vOperador = "=",
                    //                        vVL_Busca = val.Nr_PedidoString
                    //                    },
                    //                    new TpBusca()
                    //                    {
                    //                        vNM_Campo = "a.cd_produto",
                    //                        vOperador = "=",
                    //                        vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                    //                    },
                    //                    new TpBusca()
                    //                    {
                    //                        vNM_Campo = "a.id_pedidoitem",
                    //                        vOperador = "=",
                    //                        vVL_Busca = val.Id_pedidoitem.ToString()
                    //                    }
                    //                }, "a.id_os");
                    //if (obj != null)
                    //    throw new Exception("Item do pedido teve origem no processamento da OS Nº" + obj.ToString() + ".\r\n" +
                    //                        "Para cancelar o item deve-se estornar o processamento da OS.");
                    //Verificar se o item teve origem ordem compra
                    TList_OrdemCompra lOc = new TCD_OrdemCompra(qtb_Pedido_Item.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_cmp_ordemcompra_x_peditem x "+
                                            "where x.id_oc = a.id_oc "+
                                            "and x.nr_pedido = "+val.Nr_PedidoString+" "+
                                            "and x.cd_produto = '"+val.Cd_produto.Trim()+"' "+
                                            "and x.id_pedidoitem = "+val.Id_pedidoitem.ToString()+")"
                            }
                        }, 1, string.Empty);
                    if (lOc.Count > 0)
                    {
                        //Alterar status da Ordem Compra para A - Aberta
                        lOc[0].St_registro = "A";
                        TCN_OrdemCompra.Gravar(lOc[0], qtb_Pedido_Item.Banco_Dados);
                    }
                    //Excluir conferencia do item
                    TList_EntregaPedido lConf = TCN_LanEntregaPedido.Busca(string.Empty,
                                                                           val.Nr_PedidoString,
                                                                           val.Cd_produto,
                                                                           val.Id_pedidoitem.ToString(),
                                                                           false,
                                                                           string.Empty,
                                                                           qtb_Pedido_Item.Banco_Dados);
                    //Verificar se o tipo de pedido exige conferencia
                  object  obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(qtb_Pedido_Item.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                        "and x.nr_pedido = " + val.Nr_PedidoString + ")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.ST_ExigirConferenciaEntrega, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, "1");
                    if(obj == null ? false : obj.ToString().Trim().Equals("1") && lConf.Exists(p=> p.St_registro.Trim().ToUpper().Equals("P")))
                        throw new Exception("Não é permitido cancelar item do pedido com conferência processada.");
                    lConf.ForEach(p => TCN_LanEntregaPedido.Excluir(p, qtb_Pedido_Item.Banco_Dados));
                    //Verificar se o item teve origem nas taxas de deposito
                    CamadaDados.Graos.TList_TaxaDeposito lTaxas = new CamadaDados.Graos.TCD_LanTaxaDeposito(qtb_Pedido_Item.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_GRO_Taxa_X_PedidoItem x "+
                                            "where x.id_lantaxa = a.id_lantaxa "+
                                            "and x.nr_pedido = "+val.Nr_PedidoString+" "+
                                            "and x.cd_produto = '"+val.Cd_produto.Trim()+"' "+
                                            "and x.id_pedidoitem = "+val.Id_pedidoitem.ToString()+")"
                            }
                        }, 0, string.Empty);
                    lTaxas.ForEach(p =>
                        {
                            //Excluir registro taxa x pedido item
                            TCN_Taxa_X_PedidoItem.Excluir(new CamadaDados.Graos.TRegistro_Taxa_X_PedidoItem()
                            {
                                Nr_pedido = val.Nr_pedido,
                                Cd_produto = val.Cd_produto,
                                Id_pedidoitem = val.Id_pedidoitem,
                                Id_lantaxa = p.Id_LanTaxa
                            }, qtb_Pedido_Item.Banco_Dados);
                            //Voltar status da taxa para A - Aberto
                            p.St_registro = "A";
                            TCN_LanTaxas_Deposito.Gravar(p, qtb_Pedido_Item.Banco_Dados);
                        });
                    //Verificar se o item esta amarrado a uma ordem producao
                    obj = new TCD_OrdemProducao_X_PedItem(qtb_Pedido_Item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = val.Nr_PedidoString
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_pedidoitem",
                                    vOperador = "=",
                                    vVL_Busca = val.Id_pedidoitem.ToString()
                                }
                            }, "1");
                    if(obj == null ? false : obj.ToString().Trim().ToUpper().Equals("1"))
                        throw new Exception("Não é permitido cancelar um item do pedido que esteja amarrado a uma ordem produção.");
                    TCN_CompraItens_X_PedidoItens.Buscar(string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        val.Nr_PedidoString,
                                                        val.Cd_produto,
                                                        val.Id_pedidoitem.ToString(),
                                                        qtb_Pedido_Item.Banco_Dados).ForEach(p =>
                                                            {
                                                                TCN_CompraItens_X_PedidoItens.Excluir(p, qtb_Pedido_Item.Banco_Dados);
                                                                //Alterar status do romaneio para Faturado
                                                                TList_CompraAvulsa lCompra = TCN_CompraAvulsa.Buscar(p.Cd_empresa,
                                                                                                                    string.Empty,
                                                                                                                    p.Id_comprastr,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    "'F'",
                                                                                                                    qtb_Pedido_Item.Banco_Dados);
                                                                                                        if (lCompra.Count > 0)
                                                                                                        {
                                                                                                            lCompra[0].St_registro = "A";
                                                                                                            TCN_CompraAvulsa.Gravar(lCompra[0], qtb_Pedido_Item.Banco_Dados);
                                                                                                        }
                                                                                                    });
                    //Verificar se item do pedido esta amarrado a expedição
                    if (new TCD_ItensExpedicao(qtb_Pedido_Item.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = val.Nr_PedidoString
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_pedidoitem",
                                vOperador = "=",
                                vVL_Busca = val.Id_pedidoitem.ToString()
                            }
                        }, "1") != null)
                        throw new Exception("Não é permitido cancelar item pedido com EXPEDIÇÃO.\r\n" +
                                            "Obrigatório antes excluir EXPEDIÇÃO.");
                }
                string retorno = qtb_Pedido_Item.Grava(val);
                val.Id_pedidoitem = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_PEDIDOITEM"));
                //grava pedido grade
                val.lPedidoGrade.ForEach(p =>
                {
                    p.nr_pedido = val.Nr_pedido;
                    p.nr_pedidoItem = val.Id_pedidoitem;
                    TCN_PedidoGrade.Grava_Pedido(p, qtb_Pedido_Item.Banco_Dados);
                });

                //Gravar Romaneio Compra item
                val.lItensCompra.ForEach(p =>
                    {
                        TCN_CompraItens_X_PedidoItens.Gravar(
                        new TRegistro_CompraItens_X_PedidoItens()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Id_compra = p.Id_compra,
                            Id_itemcompra = p.Id_itemcompra,
                            Id_pedidoitem = val.Id_pedidoitem,
                            Nr_pedido = val.Nr_pedido
                        }, qtb_Pedido_Item.Banco_Dados);
                        //Alterar status do romaneio para Faturado
                        TList_CompraAvulsa lCompra = TCN_CompraAvulsa.Buscar(p.Cd_empresa,
                                                                            string.Empty,
                                                                            p.Id_comprastr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            "'A'",
                                                                            qtb_Pedido_Item.Banco_Dados);
                        if (lCompra.Count > 0)
                        {
                            lCompra[0].St_registro = "F";
                            TCN_CompraAvulsa.Gravar(lCompra[0], qtb_Pedido_Item.Banco_Dados);
                        }
                    });
                //Gravar Ficha Tecnica Item
                val.lFichaTec.ForEach(p =>
                    {
                        p.Nr_pedido = val.Nr_pedido;
                        p.Cd_produto = val.Cd_produto;
                        p.Id_pedidoitem = val.Id_pedidoitem;
                        TCN_FichaTecItemPed.Gravar(p, qtb_Pedido_Item.Banco_Dados);
                    });
                //Gravar Ordem Servico
                val.lPecaOS.ForEach(p => TCN_Servico_X_PedidoItem.Gravar(
                    new TRegistro_Servico_X_PedidoItem()
                    {
                        Id_os = p.Id_os,
                        Cd_empresa = val.Cd_Empresa,
                        Nr_pedido = val.Nr_pedido,
                        Cd_produto = val.Cd_produto,
                        Id_pedidoitem = val.Id_pedidoitem,
                        Tp_pedido = val.Tp_pedOS
                    }, qtb_Pedido_Item.Banco_Dados));
                //Processar Comissao
                if (!val.St_registro.Trim().ToUpper().Equals("C"))
                    ProcessarComissao(val, qtb_Pedido_Item.Banco_Dados);
                if (st_transacao)
                    qtb_Pedido_Item.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_Item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item do pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_Item.deletarBanco_Dados();
            }
        }
        
        public static string DeletaPedido_Item(TRegistro_LanPedido_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Item qtb_Pedido_Item = new TCD_LanPedido_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Pedido_Item.CriarBanco_Dados(true);
                else
                    qtb_Pedido_Item.Banco_Dados = banco;
                //Excluir romaneio de entrega
                if (!string.IsNullOrEmpty(val.Nr_PedidoString))
                    new CamadaDados.Faturamento.Entrega.TCD_RomaneioEntrega(qtb_Pedido_Item.Banco_Dados).Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_romaneio = a.id_romaneio " +
                                                "and x.nr_pedido = " + val.Nr_PedidoString + " " +
                                                "and x.cd_produto = '" + val.Cd_produto.Trim() + "' " +
                                                "and x.id_pedidoitem = " + val.Id_pedidoitem.ToString() + ")"
                                }
                            }, 0, string.Empty).ForEach(v => TCN_RomaneioEntrega.Excluir(v, qtb_Pedido_Item.Banco_Dados));
                //Verificar se item possui comissao
                TCN_Fechamento_Comissao.Buscar(string.Empty,
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
                                                val.Nr_PedidoString,
                                                val.Cd_produto,
                                                val.Id_pedidoitem.ToString(),
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                qtb_Pedido_Item.Banco_Dados).ForEach(p => TCN_Fechamento_Comissao.Excluir(p, qtb_Pedido_Item.Banco_Dados));
                //Deletar ficha tecnica item pedido
                val.lFichaTec = TCN_FichaTecItemPed.Buscar(val.Nr_PedidoString, val.Cd_produto, val.Id_pedidoitem.ToString(), string.Empty, qtb_Pedido_Item.Banco_Dados);
                val.lFichaTec.ForEach(p => TCN_FichaTecItemPed.Excluir(p, qtb_Pedido_Item.Banco_Dados));
                qtb_Pedido_Item.Deleta(val);
                if (st_transacao)
                    qtb_Pedido_Item.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_Item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar item pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_Item.deletarBanco_Dados();
            }
        }
        
        public static void Busca_Unidade(TRegistro_LanPedido_Item val, TObjetoBanco banco)
        {
           if (val != null)
               if (val.Cd_produto != null)
               {
                   TList_CadProduto Lista_Produto = TCN_CadProduto.Busca(val.Cd_produto, 
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
                                                                         0,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         banco);
                   if (Lista_Produto.Count > 0)
                   {
                       val.Cd_unidade_est = Lista_Produto[0].CD_Unidade;
                       val.Ds_unidade_est = Lista_Produto[0].DS_Unidade;
                       val.Sg_unidade_est = Lista_Produto[0].Sigla_unidade;

                       if (val.Cd_unidade_valor == string.Empty)
                       {
                        val.Cd_unidade_valor = Lista_Produto[0].CD_Unidade;
                        val.Ds_unidade_valor = Lista_Produto[0].DS_Unidade;
                        val.Sg_unidade_valor = Lista_Produto[0].Sigla_unidade;
                       }
                   }
               }
       }

        public static void ProcessarComissao(TRegistro_LanPedido_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Item qtb_item = new TCD_LanPedido_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
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
                                                                                      val.Nr_PedidoString,
                                                                                      val.Cd_produto,
                                                                                      val.Id_pedidoitem.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                      qtb_item.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    lComissao.ForEach(p =>
                        {
                            //Verificar se comissao possui faturamento
                            if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                       vNM_Campo = string.Empty,
                                       vOperador = "exists",
                                       vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.id_comissao = x.id_comissao " +
                                                    "and x.Nr_Pedido = " + val.Nr_PedidoString +
                                                    "and x.Id_pedidoitem = " + val.Id_pedidoitem + ")"
                                    }
                                }, "1") == null)
                                CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados);
                            else
                                throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                        });
                }
                //Verificar se o pedido gera comissao
                if ((new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(qtb_item.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_comissaoped, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                            "where x.cfg_pedido = a.cfg_pedido " +
                                            "and x.nr_pedido = " + val.Nr_pedido.ToString() + ")"
                            }
                        }, "1") != null))
                {
                    bool st_servico = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_item.Banco_Dados).ItemServico(val.Cd_produto);

                    //Verificar se o item e servico e se vendedor e comissionado sobre servico
                    if ((!st_servico) ||
                        (st_servico &&
                        (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_Empresa(qtb_item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_Empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo= "isnull(a.st_comservico, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "1") != null)))
                    {
                        if (!string.IsNullOrEmpty(val.Cd_vendedor))
                        {
                            decimal vl_basecalc = (val.Vl_subtotal + val.Vl_juro_fin + val.Vl_acrescimo - val.Vl_desc);
                            decimal pc_comissao = decimal.Zero;
                            string tp_comissao = "P";
                            decimal vl_comissao = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_Empresa,
                                                                                                                              val.Cd_vendedor,
                                                                                                                              val.Cd_tabelapreco,
                                                                                                                              val.Cd_condpgto,
                                                                                                                              val.Cd_produto,
                                                                                                                              val.Quantidade,
                                                                                                                              ref vl_basecalc,
                                                                                                                              ref pc_comissao,
                                                                                                                              ref tp_comissao,
                                                                                                                              qtb_item.Banco_Dados);
                            //Gravar fechamento comissao
                            CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                                new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                                {
                                    Cd_empresa = val.Cd_Empresa,
                                    Cd_vendedor = val.Cd_vendedor,
                                    Nr_pedido = val.Nr_pedido,
                                    Cd_produto = val.Cd_produto,
                                    Id_pedidoitem = val.Id_pedidoitem,
                                    Dt_lancto = val.Dt_pedido,
                                    Tp_comissao = tp_comissao,
                                    Pc_comissao = pc_comissao,
                                    Vl_basecalc = vl_basecalc,
                                    Vl_comissao = vl_comissao
                                }, qtb_item.Banco_Dados);
                            if (st_transacao)
                                qtb_item.Banco_Dados.Commit_Tran();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static decimal RatearFreteItemNF(string Nr_pedido,
                                                string Cd_produto,
                                                string Id_pedidoitem,
                                                decimal Quantidade,
                                                TObjetoBanco banco)
        {
            //Buscar Item Pedido
            TRegistro_LanPedido_Item rItem = Busca(string.Empty,
                                                   string.Empty,
                                                   Cd_produto,
                                                   Nr_pedido,
                                                   Id_pedidoitem,
                                                   string.Empty,
                                                   string.Empty,
                                                   false,
                                                   banco)[0];
            if (rItem.Vl_freteitem > decimal.Zero && 
                Quantidade > decimal.Zero &&
                rItem.Tp_frete.Trim().Equals("1"))//Destinatario
                return decimal.Multiply(decimal.Divide(Quantidade, rItem.Quantidade), rItem.Vl_freteitem);
            else return decimal.Zero;
        }
    }
    #endregion

    #region Classe Ficha Tecnica Item
    public class TCN_FichaTecItemPed
    {
        public static TList_FichaTecItemPed Buscar(string Nr_pedido,
                                                   string Cd_produto,
                                                   string Id_pedidoitem,
                                                   string Cd_item,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }

            return new TCD_FichaTecItemPed(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTecItemPed val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecItemPed qtb_ficha = new TCD_FichaTecItemPed();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                string retorno = qtb_ficha.Gravar(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ficha tecnica pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTecItemPed val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecItemPed qtb_ficha = new TCD_FichaTecItemPed();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                qtb_ficha.Excluir(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ficha tecnica pedido: " + ex.Message.Trim());
                
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static TList_FichaTecItemPed MontarFichaTecPedItem(string Cd_produto,
                                                                  string Cd_empresa,
                                                                  string Cd_tabelapreco,
                                                                  decimal Quantidade,
                                                                  TObjetoBanco banco)
        {
            //Buscar ficha tecnica do produto
            TList_FichaTecProduto lFicha = TCN_FichaTecProduto.Buscar(Cd_produto,
                                                                      string.Empty,
                                                                      banco);
            if (lFicha.Count > 0)
            {
                TList_FichaTecItemPed lFichaOrc = new TList_FichaTecItemPed();
                lFicha.ForEach(p =>
                {
                    lFichaOrc.Add(new TRegistro_FichaTecItemPed()
                    {
                        Cd_item = p.Cd_item,
                        Cd_unditem = p.Cd_unditem,
                        Ds_item = p.Ds_item,
                        Ds_unditem = p.Ds_unditem,
                        Sg_unditem = p.Sg_unditem,
                        Quantidade = p.Quantidade * Quantidade,
                        Vl_venda = TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, p.Cd_item, Cd_tabelapreco, banco)
                    });
                });
                return lFichaOrc;
            }
            else
                throw new Exception("Não existe ficha tecnica cadastrada para o produto " + Cd_produto.Trim());
        }
    }
    #endregion

    #region Classe Acessórios Ped
    public class TCN_AcessoriosPed
    {
        public static TList_AcessoriosPed Buscar(string Nr_pedido,
                                                   string Cd_produto,
                                                   string Cd_acessorio,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_acessorio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_acessorio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_acessorio.Trim() + "'";
            }

            return new TCD_AcessoriosPed(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AcessoriosPed val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcessoriosPed qtb_ficha = new TCD_AcessoriosPed();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                string retorno = qtb_ficha.Gravar(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acessorios pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AcessoriosPed val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcessoriosPed qtb_ficha = new TCD_AcessoriosPed();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                //Verificar se Acessório já está alocado em uma expedição.
                if (new TCD_ItensExpedicao().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = val.Nr_pedido.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_acessorio",
                                vOperador = "=",
                                vVL_Busca = val.Id_acessoriostr
                            }
                        }, "1") != null)
                    throw new Exception("Acessório já esta alocado na expedição!");
                qtb_ficha.Excluir(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir acessorios pedido: " + ex.Message.Trim());

            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region  Classe Itens Devolvidos
    public class TCN_ItensDevolvidos
    {
        public static TList_ItensDevolvidos Buscar(string Nr_Pedido,
                                                   string CD_Produto,
                                                   string ID_PedidoItem,
                                                   string ID_Devolvido,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_Pedido))
                Estruturas.CriarParametro(ref filtro, "a.Nr_Pedido", Nr_Pedido);
            if (!string.IsNullOrEmpty(CD_Produto))
                Estruturas.CriarParametro(ref filtro, "a.CD_Produto", "'" + CD_Produto.Trim() + "'");
            if (!string.IsNullOrEmpty(ID_PedidoItem))
                Estruturas.CriarParametro(ref filtro, "a.ID_PedidoItem", ID_PedidoItem);
            if (!string.IsNullOrEmpty(ID_Devolvido))
                Estruturas.CriarParametro(ref filtro, "a.ID_Devolvido", ID_Devolvido);

            return new TCD_ItensDevolvidos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensDevolvidos val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDevolvidos qtb_ficha = new TCD_ItensDevolvidos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;

                string retorno = qtb_ficha.Gravar(val);

                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens devolvidos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensDevolvidos val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDevolvidos qtb_ficha = new TCD_ItensDevolvidos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;

                qtb_ficha.Excluir(val);

                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir itens devolvidos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Gravar(TList_ItensDevolvidos itensDevolvidos, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDevolvidos qtb_ficha = new TCD_ItensDevolvidos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;

                itensDevolvidos.ForEach(r => qtb_ficha.Gravar(r));

                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens devolvidos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
