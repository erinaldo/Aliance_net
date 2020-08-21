using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NFE;

namespace CamadaNegocio.Faturamento.NFE
{
    public class TCN_EventoNFe
    {
        public static TList_EventoNFe Buscar(string Id_evento,
                                             string Cd_empresa,
                                             string Nr_lanctofiscal,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string Tp_evento,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_evento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_evento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_evento)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Tp_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.tp_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_evento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_EventoNFe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EventoNFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoNFe qtb_evento = new TCD_EventoNFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else
                    qtb_evento.Banco_Dados = banco;
                val.Id_eventostr = CamadaDados.TDataQuery.getPubVariavel(qtb_evento.Gravar(val), "@P_ID_EVENTO");
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EventoNFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoNFe qtb_evento = new TCD_EventoNFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else
                    qtb_evento.Banco_Dados = banco;
                qtb_evento.Excluir(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }
    }
}
