using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanPecasEnvTerceiro
    {
        public static TList_LanPecasEnvTerceiro Buscar(string vId_os,
                                                    string vCd_empresa,
                                                    string vId_evolucao,
                                                    string vCd_produto,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_os;
            }
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if (vId_evolucao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_evolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_evolucao;
            }
            if (vCd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }

            return new TCD_LanPecasEnvTerceiro(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanPecasEnvTerceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPecasEnvTerceiro qtb_pecas = new TCD_LanPecasEnvTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else
                    qtb_pecas.Banco_Dados = banco;
                string retorno = qtb_pecas.Gravar(val);
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanPecasEnvTerceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPecasEnvTerceiro qtb_pecas = new TCD_LanPecasEnvTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pecas.CriarBanco_Dados(true);
                else
                    qtb_pecas.Banco_Dados = banco;
                qtb_pecas.Excluir(val);
                if (st_transacao)
                    qtb_pecas.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pecas.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }
    }
}
