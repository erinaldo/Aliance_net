using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Almoxarifado;
using Utils;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_CadItens
    {
        public static TList_CadItens Buscar(string cd_produto, 
                                            string id_almox,
                                            string id_rua,
                                            string id_secao,
                                            string id_celula,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_produto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(id_almox))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_almox";
                vBusca[vBusca.Length - 1].vVL_Busca = id_almox;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(id_rua))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_rua";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = id_rua;
            }
            if (!string.IsNullOrEmpty(id_secao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_secao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = id_secao;
            }
            if (!string.IsNullOrEmpty(id_celula))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_celula";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = id_celula;
            }

            return new TCD_CadItens(banco).Select(vBusca, 0, string.Empty);
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
                string retorno = qtb_itens.gravarItens(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar item: " + ex.Message.Trim());
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
                qtb_itens.deletarItens(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        } 
    }
}
