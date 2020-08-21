using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadCMI
    {
        public static TList_CadCMI Busca(string CD_CMI, 
                                         string DS_CMI,
                                         string vTp_movimento,
                                         string vTp_docto,
                                         string vTp_duplicata,
                                         string vCd_condpgto,
                                         bool St_devolucao,
                                         bool St_complementar,
                                         bool St_mestra,
                                         bool St_simplesremessa,
                                         bool St_gerarestoque,
                                         bool St_compdevimposto,
                                         bool St_retorno,
                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (CD_CMI.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CMI";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_CMI.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (DS_CMI.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_CMI";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DS_CMI.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (vTp_movimento.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_movimento";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_movimento.Trim() + "'";
            }
            if (vTp_docto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_docto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_docto.Trim() + "'";
            }
            if (vTp_duplicata.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_duplicata";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_duplicata.Trim() + "'";
            }
            if (vCd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_condpgto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_condpgto.Trim() + "'";
            }
            if (St_devolucao)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_deposito";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_gerarestoque)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_geraestoque";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_mestra)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_mestra";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_simplesremessa)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_simplesremessa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_compdevimposto)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_compdevimposto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            if (St_retorno)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_retorno";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            
            return new TCD_CadCMI(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadCMI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCMI cmi = new TCD_CadCMI();
            try
            {
                if (banco == null)
                    st_transacao = cmi.CriarBanco_Dados(true);
                else
                    cmi.Banco_Dados = banco;
                string retorno = cmi.Gravar(val);
                if (st_transacao)
                    cmi.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cmi.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cmi: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cmi.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadCMI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCMI cmi = new TCD_CadCMI();
            try
            {
                if (banco == null)
                    st_transacao = cmi.CriarBanco_Dados(true);
                else
                    cmi.Banco_Dados = banco;
                cmi.Excluir(val);
                if (st_transacao)
                    cmi.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cmi.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cmi: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cmi.deletarBanco_Dados();
            }
        }
    }
}
