using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TCN_VincularDup
    {
        public static TList_VincularDup Buscar(string Cd_empresa,
                                               string Nr_lancto,
                                               string Nr_lanctovinculado,
                                               string Cd_parcelavinculado,
                                               string Id_liquidvinculado,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Nr_lanctovinculado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctovinculado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctovinculado;
            }
            if (!string.IsNullOrEmpty(Cd_parcelavinculado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcelavinculado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcelavinculado;
            }
            if (!string.IsNullOrEmpty(Id_liquidvinculado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_liquidvinculado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_liquidvinculado;
            }

            return new TCD_VincularDup(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VincularDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VincularDup qtb_vincular = new TCD_VincularDup();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vincular.CriarBanco_Dados(true);
                else
                    qtb_vincular.Banco_Dados = banco;
                string retorno = qtb_vincular.Gravar(val);
                if (st_transacao)
                    qtb_vincular.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vincular.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar agrupamento financeiro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vincular.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VincularDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VincularDup qtb_vincular = new TCD_VincularDup();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vincular.CriarBanco_Dados(true);
                else
                    qtb_vincular.Banco_Dados = banco;
                qtb_vincular.Excluir(val);
                if (st_transacao)
                    qtb_vincular.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vincular.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir agrupamento financeiro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vincular.deletarBanco_Dados();
            }
        }
    }
}
