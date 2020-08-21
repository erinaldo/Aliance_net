using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanAlmoxarifado
    {
        public static TList_LanAlmoxarifado Buscar(string vId_os,
                                                    string vCd_empresa,
                                                    string vId_peca,
                                                    string vId_movimento,
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
            if (vId_peca.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_peca;
            }
            if (vId_movimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_movimento;
            }

            return new TCD_LanAlmoxarifado(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanAlmoxarifado val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAlmoxarifado qtb_pecas = new TCD_LanAlmoxarifado();
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
                throw new Exception("Erro gravar almoxarifado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanAlmoxarifado val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAlmoxarifado qtb_pecas = new TCD_LanAlmoxarifado();
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
                throw new Exception("Erro excluir almoxarifado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pecas.deletarBanco_Dados();
            }
        }
    }
}
