using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fazenda.Lancamento;
using BancoDados;
using CamadaDados.Financeiro.CCustoLan;
using CamadaNegocio.Financeiro.CCustoLan;

namespace CamadaNegocio.Fazenda.Lancamento
{
    public class TCN_LanAtividade_Item
    {
        public static TList_LanAtividade_Item Busca(string Id_lanctoativ,
                                                    int vTop,
                                                    string vNm_campo,
                                                    BancoDados.TObjetoBanco banco)
        {
            if (Id_lanctoativ.Trim() != string.Empty)
            {
                return new TCD_LanAtividade_Item(banco).Select(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.id_lanctoativ",
                                                                        vOperador = "=",
                                                                        vVL_Busca = Id_lanctoativ
                                                                    }
                                                                }, vTop, vNm_campo);
            }
            else
                return new TList_LanAtividade_Item();
        }

        public static string GravaLanAtividadeItem(TRegistro_LanAtividade_Item val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanAtividade_Item lanAtividadeItem = new TCD_LanAtividade_Item(); 
            try
            {
                if (banco == null)
                    pode_liberar = lanAtividadeItem.CriarBanco_Dados(true);
                else
                    lanAtividadeItem.Banco_Dados = banco;

                //MANDA GRAVAR A ATIVIDADE
                string retorno = lanAtividadeItem.GravaLanAtividadeItem(val);
                if (pode_liberar)
                    lanAtividadeItem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception erro)
            {
                if (pode_liberar)
                    lanAtividadeItem.Banco_Dados.RollBack_Tran();

                throw new Exception(erro.Message);
            }
            finally
            {
                if (pode_liberar)
                    lanAtividadeItem.deletarBanco_Dados();
            }
        }

        public static void DeletaLanAtividadeItem(TRegistro_LanAtividade_Item val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanAtividade_Item lanAtividade = new TCD_LanAtividade_Item();
            try
            {
                if (banco == null)
                    pode_liberar = lanAtividade.CriarBanco_Dados(true);
                else
                    lanAtividade.Banco_Dados = banco;

                //EXLUIU A ATIVIDADE
                lanAtividade.DeletaLanAtividadeItem(val);

                if (pode_liberar)
                    lanAtividade.Banco_Dados.Commit_Tran();
            }
            catch (Exception erro)
            {
                if (pode_liberar)
                    lanAtividade.Banco_Dados.RollBack_Tran();
                throw new Exception(erro.Message);
            }
            finally
            {
                if (pode_liberar)
                    lanAtividade.deletarBanco_Dados();
            }
        }
    }
}
