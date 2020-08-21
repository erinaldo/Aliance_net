using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Frota.Cadastros
{

    public class TCN_DevOutrasReceitas
    {
        public static CamadaDados.Frota.Cadastros.TList_DevOutrasReceitas Buscar(string ID_Receita,
                                           string CD_ContaGer,
                                           string CD_LanctoCaixa,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(ID_Receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Receita";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Receita;
            }
            if (!string.IsNullOrEmpty(CD_ContaGer))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_ContaGer.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CD_LanctoCaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_LanctoCaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_LanctoCaixa;
            }
            return new CamadaDados.Frota.Cadastros.TCD_DevOutrasReceitas(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Frota.Cadastros.TCD_DevOutrasReceitas qtb_desp = new CamadaDados.Frota.Cadastros.TCD_DevOutrasReceitas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                val.Id_receitaStr = CamadaDados.TDataQuery.getPubVariavel(qtb_desp.Gravar(val), "@P_ID_receita");
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_receitaStr;
            }
            catch (Exception ex)            
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Frota.Cadastros.TCD_DevOutrasReceitas qtb_desp = new CamadaDados.Frota.Cadastros.TCD_DevOutrasReceitas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_receitaStr;
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
