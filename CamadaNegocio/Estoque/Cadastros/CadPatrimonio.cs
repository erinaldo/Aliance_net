using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadPatrimonio
    {
        public static TList_CadPatrimonio Busca(string CD_Patrimonio,
                                                   string CD_empresa,
                                                   string Nr_patrimonio,
                                                   BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Patrimonio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_Patrimonio.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CD_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_patrimonio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Nr_patrimonio.Trim() + "'";
            }
            return new TCD_CadPatrimonio(banco).Select(vBusca, 0, "");
        }

        public static string Gravar(TRegistro_CadPatrimonio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPatrimonio cd = new TCD_CadPatrimonio();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Patrimonio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadPatrimonio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPatrimonio cd = new TCD_CadPatrimonio();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Patrimonio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
