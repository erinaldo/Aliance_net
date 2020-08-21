using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Cadastros;
using Utils;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Equipamento
    {
        public static TList_Equipamento Buscar(string Cd_equipamento,
                                               string Cd_fazenda,
                                               string Tp_equipamento,
                                               string Tp_conservacao,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_equipamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_equipamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_equipamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_equipamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_conservacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_conservacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_conservacao.Trim() + "'";
            }
            return new TCD_Equipamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Equipamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Equipamento qtb_equip = new TCD_Equipamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_equip.CriarBanco_Dados(true);
                else
                    qtb_equip.Banco_Dados = banco;
                qtb_equip.Gravar(val);
                if (st_transacao)
                    qtb_equip.Banco_Dados.Commit_Tran();
                return val.Cd_equipamento;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_equip.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar equipamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_equip.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Equipamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Equipamento qtb_equip = new TCD_Equipamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_equip.CriarBanco_Dados(true);
                else
                    qtb_equip.Banco_Dados = banco;
                qtb_equip.Excluir(val);
                if (st_transacao)
                    qtb_equip.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_equip.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir equipamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_equip.deletarBanco_Dados();
            }
        }
    }
}
