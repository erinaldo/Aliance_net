using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;
using Utils;
using BancoDados;

namespace CamadaNegocio.Graos
{
    public class TCN_Transf_X_Contrato
    {

        public static TList_Transf_X_Contrato Busca(string vID_Transf,
                                                    string vCD_Empresa,
                                                    string vTP_Movimento,
                                                    string vNR_Contrato,
                                                    bool ST_Ativo,
                                                    TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vID_Transf))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Transf";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Transf; 
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Contrato;

            }
            if (ST_Ativo)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(nf.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "<>";
                vBusca[vBusca.Length - 1].vVL_Busca = "'C'";
            }
            
            return new TCD_Transf_X_Contrato(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Transf_X_Contrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Transf_X_Contrato qtb_Transf = new TCD_Transf_X_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Transf.CriarBanco_Dados(true);
                else
                    qtb_Transf.Banco_Dados = banco;
                
                string retorno = qtb_Transf.Gravar(val);
                if (st_transacao)
                    qtb_Transf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar transf. pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Transf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Transf_X_Contrato val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Transf_X_Contrato qtb_Transf = new TCD_Transf_X_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Transf.CriarBanco_Dados(true);
                else
                    qtb_Transf.Banco_Dados = banco;

                string retorno = qtb_Transf.Excluir(val);
                if (st_transacao)
                    qtb_Transf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir transf. pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Transf.deletarBanco_Dados();
            }
        }
    }
}
