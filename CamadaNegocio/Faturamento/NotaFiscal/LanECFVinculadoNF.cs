using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_ECFVinculadoNF
    {
        public static TList_ECFVinculadoNF Buscar(string Cd_empresa,
                                                  string Nr_lanctofiscal,
                                                  string Id_cupom,
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
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            
            return new TCD_ECFVinculadoNF(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ECFVinculadoNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ECFVinculadoNF qtb_ecf = new TCD_ECFVinculadoNF();
            try
            {
                if(banco == null)
                    st_transacao = qtb_ecf.CriarBanco_Dados(true);
                else
                    qtb_ecf.Banco_Dados = banco;
                string retorno = CamadaDados.TDataQuery.getPubVariavel(qtb_ecf.Gravar(val), "@P_ID_REGISTRO");
                if(st_transacao)
                    qtb_ecf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ecf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ECF Vinculado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ecf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ECFVinculadoNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ECFVinculadoNF qtb_ecf = new TCD_ECFVinculadoNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ecf.CriarBanco_Dados(true);
                else
                    qtb_ecf.Banco_Dados = banco;
                qtb_ecf.Excluir(val);
                if (st_transacao)
                    qtb_ecf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ecf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ECF Vinculado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ecf.deletarBanco_Dados();
            }
        }
    }
}
