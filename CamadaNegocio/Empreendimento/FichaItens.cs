using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento;
using Utils;

namespace CamadaNegocio.Empreendimento
{
    public class TCN_FichaItens
    {
        public static TList_FichaItens Buscar(string Cd_empresa,
                                            string Id_orcamento,
                                            string Nr_versao,
                                            string Id_projeto,
                                            string id_ficha,
                                            string cd_item,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Id_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_projeto;
            }
            if (!string.IsNullOrEmpty(id_ficha))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ficha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_ficha;
            }
            if (!string.IsNullOrEmpty(cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_item;
            }
            return new TCD_FichaItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaItens qtb_desp = new TCD_FichaItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                val.Cd_itemstr =  CamadaDados.TDataQuery.getPubVariavel(qtb_desp.Gravar(val), "@P_CD_ITEM");
                
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Cd_itemstr.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ficha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaItens qtb_desp = new TCD_FichaItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                //Excluir Funcionarios
                //val.lFunc.ForEach(p => TCN_Funcionarios.Excluir(p, qtb_desp.Banco_Dados));
                //val.lFuncDel.ForEach(p => TCN_Funcionarios.Excluir(p, qtb_desp.Banco_Dados));
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_fichastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }
}
