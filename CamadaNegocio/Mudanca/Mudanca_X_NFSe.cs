using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca;

namespace CamadaNegocio.Mudanca
{
    public class TCN_Mudanca_X_NFSe
    {
        public static TList_Mudanca_X_NFSe Buscar(string Cd_empresa,
                                                  string Id_mudanca,
                                                  string Nr_lanctoFiscal,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Nr_lanctoFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lanctoFiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoFiscal;
            }

            return new TCD_Mudanca_X_NFSe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Mudanca_X_NFSe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mudanca_X_NFSe qtb_nf = new TCD_Mudanca_X_NFSe();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_nf.CriarBanco_Dados(true);
                else
                    qtb_nf.Banco_Dados = banco;
                string retorno = qtb_nf.Gravar(val);
                if (st_transacao)
                    qtb_nf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Mudança NF: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Mudanca_X_NFSe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mudanca_X_NFSe qtb_nf = new TCD_Mudanca_X_NFSe();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_nf.CriarBanco_Dados(true);
                else
                    qtb_nf.Banco_Dados = banco;
                qtb_nf.Excluir(val);
                if (st_transacao)
                    qtb_nf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Mudança NF " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nf.deletarBanco_Dados();
            }
        }
    }
}
