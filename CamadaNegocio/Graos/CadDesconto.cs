using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadDesconto
    {
        public static TList_CadDesconto Busca(string vCD_Desconto,
                                              string vDS_Desconto,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Desconto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Desconto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDS_Desconto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_tabeladesconto";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vDS_Desconto.Trim() + "%'";
            }
            return new TCD_CadDesconto(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDesconto qtb_desc = new TCD_CadDesconto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else
                    qtb_desc.Banco_Dados = banco;
                val.CD_Desconto = CamadaDados.TDataQuery.getPubVariavel(qtb_desc.Gravar(val), "@P_CD_TABELADESCONTO");
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return val.CD_Desconto;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tabela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDesconto qtb_desc = new TCD_CadDesconto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else
                    qtb_desc.Banco_Dados = banco;
                qtb_desc.Excluir(val);
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return val.CD_Desconto;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tabela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }
    }
}