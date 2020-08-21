using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Producao.Cadastros;

namespace CamadaNegocio.Producao.Cadastros
{
    public class TCN_Turno
    {
        public static TList_Turno Buscar(string Id_turno,
                                         string Ds_turno,
                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_turno))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_turno";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_turno;
            }
            if (!string.IsNullOrEmpty(Ds_turno))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_turno";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_turno.Trim() + "%')";
            }
            return new TCD_Turno(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Turno val, BancoDados.TObjetoBanco banco)
        {
            TCD_Turno qtb_turno = new TCD_Turno();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_turno.CriarBanco_Dados(true);
                else
                    qtb_turno.Banco_Dados = banco;
                val.Id_turnostr = CamadaDados.TDataQuery.getPubVariavel(qtb_turno.Gravar(val), "@P_ID_TURNO");
                if (st_transacao)
                    qtb_turno.Banco_Dados.Commit_Tran();
                return val.Id_turnostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_turno.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar turno: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_turno.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Turno val, BancoDados.TObjetoBanco banco)
        {
            TCD_Turno qtb_turno = new TCD_Turno();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_turno.CriarBanco_Dados(true);
                else
                    qtb_turno.Banco_Dados = banco;
                qtb_turno.Excluir(val);
                if (st_transacao)
                    qtb_turno.Banco_Dados.Commit_Tran();
                return val.Id_turnostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_turno.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir turno: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_turno.deletarBanco_Dados();
            }
        }
    }
}
