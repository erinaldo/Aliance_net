/*
 * Fernando Castanho Morini 29/07/2008
 */
using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Compra;

namespace CamadaNegocio.Compra
{
    public class TCN_CadUsuarioCompra
    {
        public static TList_CadUsuarioCompra Busca(string Cd_clifor, 
                                                   string Login,
                                                   bool St_negociar,
                                                   bool St_requisitar,
                                                   bool St_aprovar,
                                                   bool St_comprar,
                                                   int vTop,
                                                   string vNm_campo,
                                                   BancoDados.TObjetoBanco banco
                                                   )
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (Cd_clifor.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_clifor_cmp";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (Login.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.login";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (St_negociar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_negociar";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_requisitar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_requisitar";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_aprovar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_aprovar";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_comprar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_comprar";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }

            return new TCD_CadUsuarioCompra(banco).Select(vBusca, vTop, string.Empty);
        }

        public static string GravaUsuarioCompra(TRegistro_CadUsuarioCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuarioCompra qtb_uc = new TCD_CadUsuarioCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_uc.CriarBanco_Dados(true);
                else
                    qtb_uc.Banco_Dados = banco;
                string retorno = qtb_uc.Grava(val);
                if (st_transacao)
                    qtb_uc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_uc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar usuario compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_uc.deletarBanco_Dados();
            }
        }

        public static string DeletaUsuarioCompra(TRegistro_CadUsuarioCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuarioCompra qtb_uc = new TCD_CadUsuarioCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_uc.CriarBanco_Dados(true);
                else
                    qtb_uc.Banco_Dados = banco;
                qtb_uc.Deleta(val);
                if (st_transacao)
                    qtb_uc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_uc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir usuario compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_uc.deletarBanco_Dados();
            }
        }
    }
}
