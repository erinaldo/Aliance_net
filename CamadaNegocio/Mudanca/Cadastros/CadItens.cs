using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca.Cadastros;

namespace CamadaNegocio.Mudanca.Cadastros
{
    public class TCN_CadItens
    {
        public static TList_CadItens Buscar(string Id_item,
                                           string Ds_item,
                                           string ID_ItemPai,
                                           string St_sintetico,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Ds_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ds_item";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_item.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(ID_ItemPai))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_ItemPai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_ItemPai;
            }
            if (!string.IsNullOrEmpty(St_sintetico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.St_sintetico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_sintetico.Trim() + "'";
            }
            return new TCD_CadItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadItens qtb_itens = new TCD_CadItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                val.Classificacao = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CLASSIFICACAO");
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ITEM");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadItens qtb_itens = new TCD_CadItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void MoverRegistros(TRegistro_CadItens rOrig, TRegistro_CadItens rDest, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadItens qtb_itens = new TCD_CadItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                string classif = rOrig.Classificacao;
                rOrig.Classificacao = rDest.Classificacao;
                qtb_itens.Gravar(rOrig);
                rDest.Classificacao = classif;
                qtb_itens.Gravar(rDest);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro mover registros: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }
}
