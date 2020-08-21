using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadCFOP
    {
        public static TList_CadCFOP Busca(string CD_CFOP, 
                                          string DS_CFOP, 
                                          string Ds_aplicacao,
                                          bool St_bonificacao,
                                          bool St_usoconsumo,
                                          bool St_devolucao,
                                          bool St_remessa,
                                          bool St_retorno,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_CFOP))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_CFOP";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_CFOP.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(DS_CFOP))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_CFOP";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DS_CFOP + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(Ds_aplicacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ds_aplicacao";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + Ds_aplicacao.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (St_bonificacao)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_bonificacao, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_usoconsumo)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_usoconsumo, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_devolucao)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_devolucao, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_remessa)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_remessa, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_retorno)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_retorno, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }

            return new TCD_CadCFOP(banco).Select(vBusca, 0, string.Empty);
        }
        
        public static string Gravar(TRegistro_CadCFOP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFOP cfop = new TCD_CadCFOP();
            try
            {
                if(banco == null)
                    st_transacao = cfop.CriarBanco_Dados(true);
                else
                    cfop.Banco_Dados = banco;
                string retorno = cfop.Gravar(val);
                if(st_transacao)
                    cfop.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if(st_transacao)
                    cfop.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar CFOP: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cfop.deletarBanco_Dados();
            }
        }
        
        public static string Excluir(TRegistro_CadCFOP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFOP cfop = new TCD_CadCFOP();
            try
            {
                if (banco == null)
                    st_transacao = cfop.CriarBanco_Dados(true);
                else
                    cfop.Banco_Dados = banco;

                cfop.Excluir(val);
                if (st_transacao)
                    cfop.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cfop.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir CFOP: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cfop.deletarBanco_Dados();
            }
        }
    }
}
