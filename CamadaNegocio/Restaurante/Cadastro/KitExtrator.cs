using BancoDados;
using CamadaDados.Restaurante.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public static class TCN_KitExtrator
    {
        public static TList_KitExtrator Buscar(string Id_kit,
                                               string Nr_kit,
                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_kit))
                Estruturas.CriarParametro(ref filtro, "a.id_kit", Id_kit);
            if (!string.IsNullOrEmpty(Nr_kit))
                Estruturas.CriarParametro(ref filtro, "a.nr_kit", "'" + Nr_kit.Trim() + "'");
            return new TCD_KitExtrator(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_KitExtrator val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_KitExtrator query = new TCD_KitExtrator();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Id_kit = int.Parse(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_ID_KIT"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_kit.ToString();
            }
            catch (Exception ex)
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

        public static string Excluir(TRegistro_KitExtrator val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_KitExtrator query = new TCD_KitExtrator();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Id_kit.ToString();
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
