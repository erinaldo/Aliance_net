using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using Utils;
using BancoDados;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadReferenciaClifor
    {
        public static TList_CadReferenciaCliFor Busca(string vCD_Clifor,
                                                      string vID_Referencia,
                                                      string vTP_Referencia, 
                                                      string vTP_Parentesco,
                                                      BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vID_Referencia))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Referencia";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Referencia;
            }
            if (!string.IsNullOrEmpty(vTP_Referencia))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Referencia";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Referencia.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTP_Parentesco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Parentesco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Parentesco.Trim() + "'";
            }
            return new TCD_CadReferenciaCliFor(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadReferenciaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadReferenciaCliFor qtb_referencia = new TCD_CadReferenciaCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_referencia.CriarBanco_Dados(true);
                else qtb_referencia.Banco_Dados = banco;

                string retorno = qtb_referencia.Gravar(val);

                if (st_transacao)
                    qtb_referencia.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_referencia.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);

            }
            finally
            {
                if (st_transacao)
                    qtb_referencia.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadReferenciaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadReferenciaCliFor qtb_referencia = new TCD_CadReferenciaCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_referencia.CriarBanco_Dados(true);
                else qtb_referencia.Banco_Dados = banco;

                string retorno = qtb_referencia.Excluir(val);

                if (st_transacao)
                    qtb_referencia.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_referencia.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);

            }
            finally
            {
                if (st_transacao)
                    qtb_referencia.deletarBanco_Dados();
            }
        }
    }
}
