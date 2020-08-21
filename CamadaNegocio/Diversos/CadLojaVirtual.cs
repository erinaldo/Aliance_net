using System;
using Utils;
using BancoDados;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_LojaVirtual
    {
        public static TList_LojaVirtual Buscar(string Cd_empresa,
                                               string Id_loja,
                                               string Nm_loja,
                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_loja))
                Estruturas.CriarParametro(ref filtro, "a.id_loja", Id_loja);
            if (!string.IsNullOrEmpty(Nm_loja))
                Estruturas.CriarParametro(ref filtro, "a.nm_loja", "'%" + Nm_loja.Trim() + "%'", "like");
            return new TCD_LojaVirtual(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_LojaVirtual val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LojaVirtual qtb_loja = new TCD_LojaVirtual();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loja.CriarBanco_Dados(true);
                else qtb_loja.Banco_Dados = banco;
                val.Id_lojastr = CamadaDados.TDataQuery.getPubVariavel(qtb_loja.Gravar(val), "@P_ID_LOJA");
                if (st_transacao)
                    qtb_loja.Banco_Dados.Commit_Tran();
                return val.Id_lojastr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_loja.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar loja: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loja.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_LojaVirtual val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LojaVirtual qtb_loja = new TCD_LojaVirtual();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loja.CriarBanco_Dados(true);
                else qtb_loja.Banco_Dados = banco;
                qtb_loja.Excluir(val);
                if (st_transacao)
                    qtb_loja.Banco_Dados.Commit_Tran();
                return val.Id_lojastr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_loja.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir loja: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loja.deletarBanco_Dados();
            }
        }
    }
}
