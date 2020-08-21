using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_DescontoXAmostra
    {
        public static TList_DescontoXAmostra Buscar(string Cd_tabeladesconto,
                                                    string Cd_tipoamostra,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_tabeladesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tipoamostra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tipoamostra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tipoamostra.Trim() + "'";
            }
            return new TCD_DescontoXAmostra(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DescontoXAmostra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DescontoXAmostra qtb_desc = new TCD_DescontoXAmostra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else
                    qtb_desc.Banco_Dados = banco;
                string retorno = qtb_desc.Gravar(val);
                //Excluir indices
                val.lPercDel.ForEach(p => TCN_PercDesconto.Excluir(p, qtb_desc.Banco_Dados));
                //Gravar Indices
                val.lPerc.ForEach(p =>
                    {
                        p.Cd_tabeladesconto = val.Cd_tabeladesconto;
                        p.Cd_tipoamostra = val.Cd_tipoamostra;
                        TCN_PercDesconto.Gravar(p, qtb_desc.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DescontoXAmostra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DescontoXAmostra qtb_desc = new TCD_DescontoXAmostra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else
                    qtb_desc.Banco_Dados = banco;
                val.lPerc.ForEach(p => TCN_PercDesconto.Excluir(p, qtb_desc.Banco_Dados));
                val.lPercDel.ForEach(p => TCN_PercDesconto.Excluir(p, qtb_desc.Banco_Dados));
                qtb_desc.Excluir(val);
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }
    }
}
