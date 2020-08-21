using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_SeqInutNFe
    {
        public static TList_SeqInutNFe Buscar(string Cd_empresa,
                                              string Nr_serie,
                                              string Cd_modelo,
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
            if (!string.IsNullOrEmpty(Nr_serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_modelo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_modelo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_modelo.Trim() + "'";
            }
            return new TCD_SeqInutNFe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_SeqInutNFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SeqInutNFe qtb_seq = new TCD_SeqInutNFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_seq.CriarBanco_Dados(true);
                else
                    qtb_seq.Banco_Dados = banco;
                val.Id_sequenciastr = CamadaDados.TDataQuery.getPubVariavel(qtb_seq.Gravar(val), "@P_ID_SEQUENCIA");
                if (st_transacao)
                    qtb_seq.Banco_Dados.Commit_Tran();
                return val.Id_sequenciastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_seq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar inutilização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_seq.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_SeqInutNFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SeqInutNFe qtb_seq = new TCD_SeqInutNFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_seq.CriarBanco_Dados(true);
                else
                    qtb_seq.Banco_Dados = banco;
                qtb_seq.Excluir(val);
                if (st_transacao)
                    qtb_seq.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_seq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir inutilização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_seq.deletarBanco_Dados();
            }
        }
    }
}
