using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante;

namespace CamadaNegocio.Restaurante
{
    public class TCN_HoraBoliche
    {
        public static TList_HoraBoliche Buscar(string Id_Hora,
                                               BancoDados.TObjetoBanco banco,
                                               string Tp_servico = null,
                                               string OrdenarPor = "")
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_Hora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_hora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_Hora.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_servico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_servico.Trim() + "'";
            }
            return new TCD_HoraBoliche(banco).Select(filtro, 0, string.Empty, OrdenarPor);
        }

        public static string Gravar(TRegistro_HoraBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_HoraBoliche qtb_orc = new TCD_HoraBoliche();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                string ret = qtb_orc.Gravar(val);
                val.Id_Hora = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_HORA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Hora.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar hora: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_HoraBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_HoraBoliche qtb_orc = new TCD_HoraBoliche();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir hora: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
}
