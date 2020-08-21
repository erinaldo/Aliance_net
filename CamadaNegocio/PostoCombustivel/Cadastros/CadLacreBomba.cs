using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_LacreBomba
    {
        public static TList_LacreBomba Buscar(string Id_lacre,
                                              string Id_bomba,
                                              string Cd_empresa,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lacre))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lacre";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lacre;
            }
            if (!string.IsNullOrEmpty(Id_bomba))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bomba";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bomba;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_LacreBomba(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LacreBomba val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LacreBomba qtb_lacre = new TCD_LacreBomba();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lacre.CriarBanco_Dados(true);
                else
                    qtb_lacre.Banco_Dados = banco;
                val.Id_lacrestr = CamadaDados.TDataQuery.getPubVariavel(qtb_lacre.Gravar(val), "@P_ID_LACRE");
                if (st_transacao)
                    qtb_lacre.Banco_Dados.Commit_Tran();
                return val.Id_lacrestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lacre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lacre: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lacre.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LacreBomba val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LacreBomba qtb_lacre = new TCD_LacreBomba();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lacre.CriarBanco_Dados(true);
                else
                    qtb_lacre.Banco_Dados = banco;
                qtb_lacre.Excluir(val);
                if (st_transacao)
                    qtb_lacre.Banco_Dados.Commit_Tran();
                return val.Id_lacrestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lacre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lacre: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lacre.deletarBanco_Dados();
            }
        }
    }
}
