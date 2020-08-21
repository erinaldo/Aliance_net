using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_IntervencaoTec
    {
        public static TList_IntervencaoTec Buscar(string Id_equipamento,
                                                  string Id_intervencao,
                                                  string Nr_ose,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  string Motivo_intervencao,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_equipamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_equipamento;
            }
            if (!string.IsNullOrEmpty(Id_intervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_intervencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_intervencao;
            }
            if (!string.IsNullOrEmpty(Nr_ose))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_ose";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_ose.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_intervencao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_intervencao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Motivo_intervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.motivo_intervencao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Motivo_intervencao.Trim() + "%'";
            }
            return new TCD_IntervencaoTec(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_IntervencaoTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_IntervencaoTec qtb_tec = new TCD_IntervencaoTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tec.CriarBanco_Dados(true);
                else
                    qtb_tec.Banco_Dados = banco;
                val.Id_intervencaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_tec.Gravar(val), "@P_ID_INTERVENCAO");
                if (st_transacao)
                    qtb_tec.Banco_Dados.Commit_Tran();
                return val.Id_intervencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tec.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar intervenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tec.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_IntervencaoTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_IntervencaoTec qtb_tec = new TCD_IntervencaoTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tec.CriarBanco_Dados(true);
                else
                    qtb_tec.Banco_Dados = banco;
                qtb_tec.Excluir(val);
                if (st_transacao)
                    qtb_tec.Banco_Dados.Commit_Tran();
                return val.Id_intervencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tec.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir intervenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tec.deletarBanco_Dados();
            }
        }
    }
}
