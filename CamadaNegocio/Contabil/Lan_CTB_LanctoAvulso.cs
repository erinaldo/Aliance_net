using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_LanctoAvulso
    {
        public static TList_LanctoAvulso Buscar(string Id_lan,
                                                string Id_reg,
                                                string Cd_conta_ctb,
                                                string D_C,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lan;
            }
            if (!string.IsNullOrEmpty(Id_reg))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_reg";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_reg;
            }
            if (!string.IsNullOrEmpty(Cd_conta_ctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta_ctb;
            }
            if (!string.IsNullOrEmpty(D_C))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.d_c";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + D_C.Trim() + "'";
            }
            return new TCD_LanctoAvulso(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanctoAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctoAvulso qtb_lancto = new TCD_LanctoAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lancto.CriarBanco_Dados(true);
                else
                    qtb_lancto.Banco_Dados = banco;
                string retorno = qtb_lancto.Gravar(val);
                if (st_transacao)
                    qtb_lancto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lancto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro avulso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lancto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanctoAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctoAvulso qtb_lancto = new TCD_LanctoAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lancto.CriarBanco_Dados(true);
                else
                    qtb_lancto.Banco_Dados = banco;
                qtb_lancto.Excluir(val);
                if (st_transacao)
                    qtb_lancto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lancto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lancto avulso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lancto.deletarBanco_Dados();
            }
        }
    }
}
