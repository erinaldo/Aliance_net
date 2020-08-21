using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_Abastecidas
    {
        public static TList_Abastecidas Buscar(string Id_abastecida,
                                               string Cd_empresa,
                                               string Id_abastecimento,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_abastecida))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecida;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecimento;
            }

            return new TCD_Abastecidas(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Abastecidas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Abastecidas qtb_abast = new TCD_Abastecidas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                val.Id_abastecidastr = CamadaDados.TDataQuery.getPubVariavel(qtb_abast.Gravar(val), "@P_ID_ABASTECIDA");
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecidastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar abastecida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Abastecidas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Abastecidas qtb_abast = new TCD_Abastecidas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                qtb_abast.Excluir(val);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecidastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }
    }
}
