using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_FaturamentoCCusto
    {
        public static TList_FaturamentoCCusto Buscar(string Cd_empresa,
                                                     string Nr_lanctofiscal,
                                                     string Id_ccustolan,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_FaturamentoCCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FaturamentoCCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturamentoCCusto qtb_fat = new TCD_FaturamentoCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else qtb_fat.Banco_Dados = banco;
                string retorno = qtb_fat.Gravar(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FaturamentoCCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturamentoCCusto qtb_fat = new TCD_FaturamentoCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else qtb_fat.Banco_Dados = banco;
                qtb_fat.Excluir(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }
    }
}
