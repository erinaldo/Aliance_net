using System;
using BancoDados;
using CamadaDados.Producao.Cadastros;
using Utils;

namespace CamadaNegocio.Producao.Cadastros
{
    public static class TCN_CadLote
    {
        public static TList_CadLote Busca(string vNR_LoteProducao,
                                          string vDS_LoteProducao,
                                          int vTop,
                                          string vCD_LoteID,   
                                          string vNM_Campo,
                                          TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if ((vNR_LoteProducao.Trim() != "") && (vNR_LoteProducao.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LoteProducao";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LoteProducao;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vDS_LoteProducao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_LoteProducao";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_LoteProducao + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }

            if (!string.IsNullOrEmpty(vCD_LoteID))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_LoteID";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_LoteID + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_CadLote(banco).Select(vBusca, vTop, vNM_Campo);
        }

        public static string Gravar(TRegistro_CadLote val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLote query = new TCD_CadLote();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                val.Nr_loteproducao = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(query.Gravar(val), "@P_NR_LOTEPRODUCAO"));
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Nr_loteproducao.ToString();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadLote val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLote query = new TCD_CadLote();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                query.Excluir(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
                return val.Nr_loteproducao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }
    }
}
