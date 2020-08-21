using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_Cotacao
    {
        public static TList_Cotacao Buscar(string Id_cotacao,
                                           string Cd_fornecedor,
                                           string Cd_empresa,
                                           string Id_requisicao,
                                           int vTop,
                                           string vNm_campo,
                                           string St_registro,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_cotacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cotacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cotacao;
            }          
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Id_requisicao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_requisicao;
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.St_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Cotacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_Requisicao BuscarRequisicao(string Cd_empresa,
                                                        string Cd_produto,
                                                        string Cd_fornecedor,
                                                        string Dt_ini,
                                                        string Dt_fin,
                                                        string St_registro,
                                                        int vTop,
                                                        string vNm_campo,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_cotacao x " +
                                                      "where x.id_requisicao = a.id_requisicao " +
                                                      "and x.cd_fornecedor = '" + Cd_fornecedor.Trim() + "')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_requisicao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_requisicao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_requisicao";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Requisicao(banco).Select(filtro, vTop, vNm_campo, string.Empty);
        }

        public static string GravarCotacao(TRegistro_Cotacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cotacao qtb_cot = new TCD_Cotacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cot.CriarBanco_Dados(true);
                else
                    qtb_cot.Banco_Dados = banco;
                //Gravar cotacao
                string retorno = qtb_cot.Gravar(val);
                if (st_transacao)
                    qtb_cot.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cot.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cotacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cot.deletarBanco_Dados();
            }
        }

        public static string DeletarCotacao(TRegistro_Cotacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cotacao qtb_cot = new TCD_Cotacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cot.CriarBanco_Dados(true);
                else
                    qtb_cot.Banco_Dados = banco;
                //Excluir cotacao
                qtb_cot.Excluir(val);
                if (st_transacao)
                    qtb_cot.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cot.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cotacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cot.deletarBanco_Dados();
            }
        }
    }
}
