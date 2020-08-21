using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_Markup
    {
        public static TList_Markup Buscar(string Cd_empresa,
                                          string Id_markup,
                                          string Ds_markup,
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
            if (!string.IsNullOrEmpty(Id_markup))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_markup";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_markup;
            }
            if (!string.IsNullOrEmpty(Ds_markup))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_makup";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_markup.Trim() + "%'";
            }
            return new TCD_Markup(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Markup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Markup qtb_markup = new TCD_Markup();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_markup.CriarBanco_Dados(true);
                else
                    qtb_markup.Banco_Dados = banco;
                val.Id_markupstr = CamadaDados.TDataQuery.getPubVariavel(qtb_markup.Gravar(val), "@P_ID_MARKUP");
                if (st_transacao)
                    qtb_markup.Banco_Dados.Commit_Tran();
                return val.Id_markupstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_markup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar markup: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_markup.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Markup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Markup qtb_markup = new TCD_Markup();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_markup.CriarBanco_Dados(true);
                else
                    qtb_markup.Banco_Dados = banco;
                qtb_markup.Excluir(val);
                if (st_transacao)
                    qtb_markup.Banco_Dados.Commit_Tran();
                return val.Id_markupstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_markup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir markup: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_markup.deletarBanco_Dados();
            }
        }
    }
}
