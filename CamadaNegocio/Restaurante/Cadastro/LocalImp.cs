using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Restaurante.Cadastro;
using System.Text;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_LocalImp
    {
        public static TList_LocalImp Buscar(string id_localimp,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_localimp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_localimp";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_localimp.Trim() + "'";
            }
            return new TCD_LocalImp(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LocalImp val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LocalImp qtb_orc = new TCD_LocalImp();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.ID_LocalImp.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre local imp: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_LocalImp val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LocalImp qtb_orc = new TCD_LocalImp();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre local imp: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
