using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;
using System.Globalization;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using System.IO;
using System.Windows.Forms;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Servicos;
using CamadaDados.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.Orcamento;

namespace CamadaNegocio.Faturamento.Pedido
{ 
    public class TCN_PedidoGrade
    { 
        public static TList_PedidoGrade Busca(string nr_pedido,
                                        string id_caracteristica, string nr_pedidoitem,
                                        string id_item, string cd_produto,
                                        TObjetoBanco banco)
        {

            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedido;
            }
            if (!string.IsNullOrEmpty(id_caracteristica))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caracteristica";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_caracteristica;
            }
            if (!string.IsNullOrEmpty(nr_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedidoitem;
            }
            if (!string.IsNullOrEmpty(cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_produto;
            }
            if (!string.IsNullOrEmpty(id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_item;
            }
            return new TCD_PedidoGrade(banco).Select(filtro, 0, string.Empty);
        }
          
        public static string Deleta_Pedido(TRegistro_PedidoGrade val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PedidoGrade QTB_Pedido = new TCD_PedidoGrade();
            try
            {
                if (banco == null)
                    st_transacao = QTB_Pedido.CriarBanco_Dados(true);
                else
                    QTB_Pedido.Banco_Dados = banco;  
                    //Excluir pedido
                    QTB_Pedido.Excluir(val);
                    if (st_transacao)
                        QTB_Pedido.Banco_Dados.Commit_Tran();
                    return "OK";
                 
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    QTB_Pedido.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    QTB_Pedido.deletarBanco_Dados();
            }
        }

        public static string Grava_Pedido(TRegistro_PedidoGrade val,
                                          TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PedidoGrade qtb_ped = new TCD_PedidoGrade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco; 
                val.nr_pedido = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ped.Gravar(val), "@P_NR_PEDIDO")); 
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();

                return val.nr_pedido.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }
          
    }
}
