using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_ImpostosReterFixacao
    {
        public static TList_ImpostosReterFixacao Buscar(string Nr_contrato,
                                                        string Cd_imposto,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            return new TCD_ImpostosReterFixacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ImpostosReterFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImpostosReterFixacao qtb_imp = new TCD_ImpostosReterFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imp.CriarBanco_Dados(true);
                else
                    qtb_imp.Banco_Dados = banco;
                string retorno = qtb_imp.Gravar(val);
                if (st_transacao)
                    qtb_imp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar impostos reter fixacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ImpostosReterFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImpostosReterFixacao qtb_imp = new TCD_ImpostosReterFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imp.CriarBanco_Dados(true);
                else
                    qtb_imp.Banco_Dados = banco;
                qtb_imp.Excluir(val);
                if (st_transacao)
                    qtb_imp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir imposto reter fixacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imp.deletarBanco_Dados();
            }
        }
    }
}
