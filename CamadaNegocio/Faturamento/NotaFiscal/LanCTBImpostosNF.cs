using CamadaDados.Faturamento.NotaFiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public static class TCN_CTBImpostosNF
    {
        public static TList_CTBImpostosNF Buscar(string Cd_empresa,
                                                 string Nr_lanctofiscal,
                                                 string Cd_imposto,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
                Estruturas.CriarParametro(ref filtro, "a.nr_lanctofiscal", Nr_lanctofiscal);
            if (!string.IsNullOrEmpty(Cd_imposto))
                Estruturas.CriarParametro(ref filtro, "a.cd_imposto", Cd_imposto);
            return new TCD_CTBImpostosNF(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CTBImpostosNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTBImpostosNF qtb_ctb = new TCD_CTBImpostosNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctb.CriarBanco_Dados(true);
                else qtb_ctb.Banco_Dados = banco;
                string ret = qtb_ctb.Gravar(val);
                if (st_transacao)
                    qtb_ctb.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_ctb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctb.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_CTBImpostosNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTBImpostosNF qtb_ctb = new TCD_CTBImpostosNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctb.CriarBanco_Dados(true);
                else qtb_ctb.Banco_Dados = banco;
                qtb_ctb.Excluir(val);
                if (st_transacao)
                    qtb_ctb.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctb.deletarBanco_Dados();
            }
        }
    }
}
