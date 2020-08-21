using CamadaDados.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using System;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public static class TCN_Chopeira
    {
        public static TList_Chopeira Buscar(string Id_chopeira,
                                            string Ds_chopeira,
                                            string Nr_chopeira,
                                            string Voltagem,
                                            string Qt_torneiras,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_chopeira))
                Estruturas.CriarParametro(ref filtro, "a.id_chopeira", Id_chopeira);
            if (!string.IsNullOrEmpty(Ds_chopeira))
                Estruturas.CriarParametro(ref filtro, "a.ds_chopeira", "'%" + Ds_chopeira.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(Nr_chopeira))
                Estruturas.CriarParametro(ref filtro, "a.nr_chopeira", "'%" + Nr_chopeira.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(Voltagem))
                Estruturas.CriarParametro(ref filtro, "a.voltagem", "'" + Voltagem.Trim() + "'");
            if (!string.IsNullOrEmpty(Qt_torneiras))
                Estruturas.CriarParametro(ref filtro, "a.qt_torneiras", "'" + Qt_torneiras.Trim() + "'");
            return new TCD_Chopeira(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Chopeira val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Chopeira query = new TCD_Chopeira();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_chopeira = int.Parse(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_CHOPEIRA"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_chopeira.ToString();
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

        public static string Excluir(TRegistro_Chopeira val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Chopeira query = new TCD_Chopeira();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                if(new TCD_Expedicao(query.Banco_Dados).BuscarEscalar(
                    new TpBusca[]{new TpBusca{vNM_Campo = "a.id_chopeira", vOperador = "=", vVL_Busca = val.Id_chopeira.Value.ToString()}}, "1") != null)
                {
                    val.Cancelado = true;
                    query.Gravar(val);
                }
                else query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_chopeira.Value.ToString();
            }
            catch(Exception ex)
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
