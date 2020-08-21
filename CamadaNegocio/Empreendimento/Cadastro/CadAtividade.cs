using CamadaDados.Empreendimento.Cadastro;
using System;
using Utils;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_Atividade
    {
        public static TList_CadAtividade Buscar(string id_atividade,
                                                string ds_atividade,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(id_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_atividade;
            }
            if(!string.IsNullOrEmpty(ds_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_atividade";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_atividade.Trim() + "%'";
            }
            return new TCD_CadAtividade(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadAtividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAtividade qtb_cad = new TCD_CadAtividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                val.Id_atividadestr = CamadaDados.TDataQuery.getPubVariavel(qtb_cad.Gravar(val), "@P_ID_ATIVIDADE");
                //val.lDelRequisitos.ForEach(p =>
                //{
                //    TCN_CadRequisitos.Excluir(p, qtb_cad.Banco_Dados);
                //});
                //val.lRequisitos.ForEach(p =>
                //{
                //    p.id_atividade = val.Id_atividadestr;
                //    TCN_CadRequisitos.Gravar(p, qtb_cad.Banco_Dados);
                //});

                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.Id_atividadestr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_CadAtividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAtividade qtb_cad = new TCD_CadAtividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                qtb_cad.Excluir(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.Id_atividadestr;
            }
            catch(Exception ex)
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
