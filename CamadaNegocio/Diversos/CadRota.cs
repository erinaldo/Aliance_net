using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadRota
    {
        public static TList_CadRota Busca(string Id_rota,
                                          string Ds_rota,
                                          BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_rota))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_rota";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_rota;

            }
            if (!string.IsNullOrEmpty(Ds_rota))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Ds_rota";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + Ds_rota.Trim() + "%')";

            }

            return new TCD_CadRota(banco).Select(vBusca, 0, string.Empty);

        }
        public static string Gravar(TRegistro_CadRota val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRota cd = new TCD_CadRota();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.ID_rotaString = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_ROTA");
                val.lCliforDel.ForEach(p =>
                    cd.executarSql("update TB_FIN_Clifor set id_rota = null where cd_clifor = '" + p.Cd_clifor.Trim() + "'", null));
                val.lClifor.ForEach(p =>
                    cd.executarSql("update TB_FIN_Clifor set id_rota = " + val.ID_rotaString + " where cd_clifor = '" + p.Cd_clifor.Trim() + "'", null));
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.ID_rotaString;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar rota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadRota val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRota cd = new TCD_CadRota();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.lCliforDel.ForEach(p =>
                    cd.executarSql("update TB_FIN_Clifor set id_rota = null where cd_clifor = '" + p.Cd_clifor.Trim() + "'", null));
                val.lClifor.ForEach(p =>
                    cd.executarSql("update TB_FIN_Clifor set id_rota = null where cd_clifor = '" + p.Cd_clifor.Trim() + "'", null));
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir rota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
