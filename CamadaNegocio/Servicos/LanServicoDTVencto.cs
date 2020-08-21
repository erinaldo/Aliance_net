using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_DtVencto
    {
        public static TList_DtVencto Buscar(string Id_os,
                                            string Cd_empresa,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_DtVencto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DtVencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DtVencto qtb_dt = new TCD_DtVencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dt.CriarBanco_Dados(true);
                else
                    qtb_dt.Banco_Dados = banco;
                string retorno = qtb_dt.Gravar(val);
                if (st_transacao)
                    qtb_dt.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dt.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vencimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dt.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DtVencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DtVencto qtb_dt = new TCD_DtVencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dt.CriarBanco_Dados(true);
                else
                    qtb_dt.Banco_Dados = banco;
                qtb_dt.Excluir(val);
                if (st_transacao)
                    qtb_dt.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dt.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dt.deletarBanco_Dados();
            }
        }
    }
}
