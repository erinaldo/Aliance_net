using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_Apontamento_CustoFixo
    {
        public static TList_Apontamento_CustoFixo Buscar(string Id_apontamento,
                                                         string Id_custo,
                                                         int vTop,
                                                         string vNm_campo,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_apontamento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }
            if (Id_custo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_custo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_custo;
            }
            return new TCD_Apontamento_CustoFixo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarApontamentoCustoFixo(TRegistro_Apontamento_CustoFixo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_CustoFixo qtb_apontamento = new TCD_Apontamento_CustoFixo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                //Gravar apontamento custo fixo
                string retorno = qtb_apontamento.GravarApontamentoCustoFixo(val);
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }

        public static string DeletarApontamentoCustoFixo(TRegistro_Apontamento_CustoFixo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_CustoFixo qtb_apontamento = new TCD_Apontamento_CustoFixo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                //Deletar custo fixo apontamento
                qtb_apontamento.DeletarApontamentoCustoFixo(val);
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }
    }
}
