using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadCartaoCredito
    {
        public static TList_CadCartaoCredito Buscar(string ID_Cartao,
                                                    string ID_Bandeira,
                                                    string NR_Cartao,
                                                    string NomeUsuario,
                                                    int vTop,
                                                    string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (ID_Cartao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + ID_Cartao.Trim() + "'";
            }
            if (ID_Bandeira.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Bandeira";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "('" + ID_Bandeira.Trim() + "')";
            }
            if (NomeUsuario.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "('" + NR_Cartao.Trim() + "')";
            }
            if (NR_Cartao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NomeUsuario";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + NomeUsuario.Trim() + "%')";
            }
            return new TCD_CadCartaoCredito().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadCartaoCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCartaoCredito qtb_cartaocredito = new TCD_CadCartaoCredito();
            try
            {
                if (banco == null)
                {
                    qtb_cartaocredito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cartaocredito.Banco_Dados = banco;
                string retorno = qtb_cartaocredito.GravarCartaoCredito(val);
                if (st_transacao)
                    qtb_cartaocredito.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cartaocredito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cartaocredito.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_CadCartaoCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCartaoCredito qtb_cartaocredito = new TCD_CadCartaoCredito();
            try
            {
                if (banco == null)
                {
                    qtb_cartaocredito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cartaocredito.Banco_Dados = banco;
                qtb_cartaocredito.DeletarCartaoCredito(val);
                if (st_transacao)
                    qtb_cartaocredito.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cartaocredito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cartaocredito.deletarBanco_Dados();
            }
        }
    
    }
}
