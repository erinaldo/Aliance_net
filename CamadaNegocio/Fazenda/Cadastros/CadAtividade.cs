using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Cadastros;
using Utils;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Atividade
    {
        public static TList_Atividade Buscar(string Id_atividade,
                                             string Ds_atividade,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_atividade;
            }
            if (!string.IsNullOrEmpty(Ds_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_atividade";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_atividade.Trim() + "%'";
            }
            return new TCD_Atividade(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Atividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Atividade qtb_atividade = new TCD_Atividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atividade.CriarBanco_Dados(true);
                else
                    qtb_atividade.Banco_Dados = banco;
                val.Id_atividadestr = CamadaDados.TDataQuery.getPubVariavel(qtb_atividade.Gravar(val), "@P_ID_ATIVIDADE");
                if (st_transacao)
                    qtb_atividade.Banco_Dados.Commit_Tran();
                return val.Id_atividadestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_atividade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atividade.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Atividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Atividade qtb_atividade = new TCD_Atividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atividade.CriarBanco_Dados(true);
                else
                    qtb_atividade.Banco_Dados = banco;
                qtb_atividade.Excluir(val);
                if (st_transacao)
                    qtb_atividade.Banco_Dados.Commit_Tran();
                return val.Id_atividadestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_atividade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atividade.deletarBanco_Dados();
            }
        }
    }
}
