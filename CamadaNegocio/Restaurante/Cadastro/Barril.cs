using BancoDados;
using CamadaDados;
using CamadaDados.Restaurante.Cadastro;
using System;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public static class TCN_Barril
    {
        public static TList_Barril Buscar(string Id_barril,
                                          string Nr_barril,
                                          TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_barril))
                Estruturas.CriarParametro(ref filtro, "a.id_barril", Id_barril);
            if (!string.IsNullOrEmpty(Nr_barril))
                Estruturas.CriarParametro(ref filtro, "a.nr_barril", Nr_barril);
            return new TCD_Barril(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Barril val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Barril query = new TCD_Barril();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_barril = int.Parse(TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_BARRIL"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_barril.ToString();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Barril val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Barril query = new TCD_Barril();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_barril.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }
}
