using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Empreendimento.Cadastro;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_CadRequisitos
    {
        public static TList_CadRequisitos Buscar(string id_REQUISITO,
                                                string ds_REQUISITO,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_REQUISITO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_REQUISITO";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_REQUISITO;
            }
            if (!string.IsNullOrEmpty(id_REQUISITO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_REQUISITO";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%"+ds_REQUISITO+"%'";
            }
            return new TCD_CadRequisitos(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadRequisitos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRequisitos qtb_cad = new TCD_CadRequisitos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                val.id_requisito = CamadaDados.TDataQuery.getPubVariavel(qtb_cad.Gravar(val), "@P_ID_REQUISITO");
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.id_requisito;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Requisito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_CadRequisitos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRequisitos qtb_cad = new TCD_CadRequisitos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                qtb_cad.Excluir(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.id_requisito;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
    }
}
