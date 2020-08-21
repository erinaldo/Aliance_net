using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fazenda.Cadastros;


namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Talhoes
    {
        public static TList_Talhoes Buscar(string Cd_fazenda,
                                           string Id_area,
                                           string Id_talhao,
                                           string Ds_talhao,
                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_area";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_area;
            }
            if (!string.IsNullOrEmpty(Id_talhao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_talhao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_talhao;
            }
            if (!string.IsNullOrEmpty(Ds_talhao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_talhao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_talhao.Trim() + "%')";
            }
            return new TCD_Talhoes(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Talhoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Talhoes qtb_talhoes = new TCD_Talhoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_talhoes.CriarBanco_Dados(true);
                else
                    qtb_talhoes.Banco_Dados = banco;
                val.Id_talhaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_talhoes.Gravar(val), "@P_ID_TALHAO");
                if (st_transacao)
                    qtb_talhoes.Banco_Dados.Commit_Tran();
                return val.Id_talhaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_talhoes.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar talhão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_talhoes.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Talhoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Talhoes qtb_talhoes = new TCD_Talhoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_talhoes.CriarBanco_Dados(true);
                else
                    qtb_talhoes.Banco_Dados = banco;
                val.St_registro = "I";
                Gravar(val, qtb_talhoes.Banco_Dados);
                if (st_transacao)
                    qtb_talhoes.Banco_Dados.Commit_Tran();
                return val.Id_talhaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_talhoes.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir talhão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_talhoes.deletarBanco_Dados();
            }
        }
    }
}
