using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    #region Desdobro Aplicar
    public class TCN_DesdobroAplicar
    {
        public static TList_DesdobroAplicar Buscar(string Cd_clifor,
                                                   string Cd_empresa,
                                                   string Cd_tabeladesconto,
                                                   string Cd_produto,
                                                   bool St_gmo,
                                                   string Tp_movimento,
                                                   string Nr_pedido,
                                                   decimal Id_ticket,
                                                   string Tp_pesagem,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vVL_Busca = "((isNull((case when a.TP_Movimento = 'E' then " +
                                                  "         (case when b.TP_Pessoa = 'F' then " +
                                                  "             b.QTD_NotaLiquido " +
                                                  "         else " +
                                                  "             (case when((Select x.TP_Natureza_Pesagem From TB_GRO_Contrato x " +
                                                  "                         inner join TB_GRO_Contrato_X_PedidoItem y " +
                                                  "                         on x.nr_contrato = y.nr_contrato " +
                                                  "                         Where y.NR_Pedido = isNull(e.NR_Pedido, @NR_PEDIDO) " +
                                                  "                         and y.CD_Produto = b.CD_Produto) = 'O')then " +
                                                  "                 b.QTD_Nota " +
                                                  "             else " +
                                                  "                 b.QTD_NotaLiquido " +
                                                  "             end) " +
                                                  "         end) " +
                                                  "     else " +
                                                  "         b.QTD_NotaLiquido " +
                                                  "     end " +
                                                  "),0) > " +
                                                  "isNull((Select sum(isNull(x.QTD_Aplicado,0)) " +
                                                  "From TB_BAL_Aplicacao_Pedido x " +
                                                  "Where x.CD_Empresa = b.CD_Empresa " +
                                                  "and x.ID_Ticket = b.ID_Ticket " +
                                                  "and x.TP_Pesagem = b.TP_Pesagem " +
                                                  "and x.ID_Desdobro = b.ID_Desdobro " +
                                                  "and x.ID_Item = b.ID_Item),0)) or   @NR_PEDIDO = 0 )";
            filtro[0].vOperador = string.Empty;
            filtro[1].vNM_Campo = "isnull(tpps.tp_transbordo, 'N')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'S'";
            if (!string.IsNullOrEmpty(Cd_clifor.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.CD_CliforPedido";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_empresa.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_tabeladesconto.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_TabelaDesconto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_produto.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (St_gmo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((isnull(a.st_gmo, 'N') = 'S') or (isnull(a.st_gmodeclarado, 'N') = 'S'))";
                filtro[filtro.Length - 1].vOperador = string.Empty;
            }
            if (!string.IsNullOrEmpty(Tp_movimento.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Movimento";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (Id_ticket > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket.ToString();
            }
            if (!string.IsNullOrEmpty(Tp_pesagem.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }

            //Parametros do SubSelect
            Hashtable hs = new Hashtable(1);
            hs.Add("@NR_PEDIDO", Nr_pedido);
            return new TCD_DesdobroAplicar(banco).Select(filtro, 0, string.Empty, hs); 
        }
    }
    #endregion

    #region Pesagem Produto
    public class TCN_LanPesagemProduto
    {
        public static TList_RegLanPesagemProduto Busca(string vCD_Empresa,
                                                       string vID_Ticket,
                                                       string vTP_Pesagem,
                                                       string vCD_Produto,
                                                       string vID_Desdobro,
                                                       string vID_Item,
                                                       string vNR_Pedido,
                                                       string vNR_NotaFiscal,
                                                       string vNR_Serie,
                                                       Int32 vTop,
                                                       string vNM_Campo,
                                                       TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.ST_Registro";
            vBusca[0].vVL_Busca = "'A'";
            vBusca[0].vOperador = "=";
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Ticket.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_Pesagem.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Desdobro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Desdobro";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Desdobro;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Pedido.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Item.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Item";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Item;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_NotaFiscal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_NotaFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_NotaFiscal + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Serie.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Serie";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Serie + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_LanPesagemProduto qtb_psproduto = new TCD_LanPesagemProduto();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_psproduto.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psproduto.Banco_Dados = banco;
                return qtb_psproduto.Select(vBusca, vTop, vNM_Campo);
            }
            finally
            {
                if (pode_liberar)
                { qtb_psproduto.deletarBanco_Dados(); }
            }
        }

        public static string GravarPesagemProduto(TList_RegLanPesagemProduto val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = "";
                for (int i = 0; i < val.Count; i++)
                    retorno = retorno + "|" + GravarPesagemProduto(val[i], banco);
                return retorno;
            }
            else
                return "";
        }

        public static string GravarPesagemProduto(TRegistro_LanPesagemProduto val, TObjetoBanco banco)
        {
            string retorno = "";
            bool pode_liberar = false;
            TCD_LanPesagemProduto qtb_psproduto = new TCD_LanPesagemProduto();
            try
            {
                if (banco == null)
                {
                    qtb_psproduto.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psproduto.Banco_Dados = banco;
                //Gravar Desdobro Produtos
                retorno = qtb_psproduto.GravarPesagemProduto(val);
                if (pode_liberar)
                    qtb_psproduto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_psproduto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_psproduto.deletarBanco_Dados();
            }
        }

        public static string DeletarPesagemProduto(TList_RegLanPesagemProduto val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = "";
                for (int i = 0; i < val.Count; i++)
                    retorno = retorno + "|" + DeletarPesagemProduto(val[i], banco);
                return retorno;
            }
            else
                return "";
        }

        public static string DeletarPesagemProduto(TRegistro_LanPesagemProduto val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            string retorno = string.Empty;
            TCD_LanPesagemProduto qtb_psproduto = new TCD_LanPesagemProduto();
            try
            {
                if (banco == null)
                {
                    qtb_psproduto.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_psproduto.Banco_Dados = banco;
                retorno = qtb_psproduto.DeletarPesagemProduto(val);
                //Verificar se não existe mais registro na TB_BAL_Produto
                //Caso não exista, deletar o registro da TB_BAL_Clifor
                if (TCN_LanPesagemClifor.Busca(val.Cd_empresa, val.Id_ticket.ToString(), val.Tp_pesagem, val.Id_desdobro.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, false, 1, string.Empty, qtb_psproduto.Banco_Dados).Count.Equals(0))
                {
                    TRegistro_LanPesagemClifor regBalClifor = new TRegistro_LanPesagemClifor();
                    regBalClifor.Cd_empresa = val.Cd_empresa;
                    regBalClifor.Id_ticket = val.Id_ticket;
                    regBalClifor.Tp_pesagem = val.Tp_pesagem;
                    regBalClifor.Id_desdobro = val.Id_desdobro;
                    if (TCN_LanPesagemClifor.DeletarPesagemClifor(regBalClifor, qtb_psproduto.Banco_Dados).Trim() == string.Empty)
                        throw new Exception("Erro deletar TB_BAL_Clifor.");
                }
                if (pode_liberar)
                    qtb_psproduto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_psproduto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_psproduto.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
