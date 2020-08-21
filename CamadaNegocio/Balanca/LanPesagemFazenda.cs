using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_PesagemFazenda
    {
        public static TList_PesagemFazenda Buscar(string Cd_fazenda,
                                                  string Id_ticket,
                                                  string Tp_pesagem,
                                                  string PlacaCarreta,
                                                  string Cd_produto,
                                                  string Cd_tabeladesconto,
                                                  string Cd_local,
                                                  string Anosafra,
                                                  string Id_plantio,
                                                  string Id_talhao,
                                                  string Id_area,
                                                  string Tp_data,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  string St_registro,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(PlacaCarreta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placacarreta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + PlacaCarreta.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_plantio x " +
                                                      "inner join tb_faz_cultura y " +
                                                      "on x.id_cultura = y.id_cultura " +
                                                      "where x.id_plantio = a.id_plantio " +
                                                      "and x.id_area = a.id_area " +
                                                      "and x.id_talhao = a.id_talhao " +
                                                      "and x.cd_fazenda = a.cd_fazenda " +
                                                      "and y.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_tabeladesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_local.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Anosafra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_plantio x " +
                                                      "where x.id_plantio = a.id_plantio " +
                                                      "and x.anosafra = '" + Anosafra.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_plantio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_plantio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_plantio;
            }
            if (!string.IsNullOrEmpty(Id_talhao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_talhao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_talhao;
            }
            if (!string.IsNullOrEmpty(Id_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_area";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_area;
            }
            if (!string.IsNullOrEmpty(Dt_ini.Trim().Replace("/", "")))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("B") ? "a.dt_bruto" : "a.dt_tara") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.Replace("/", "")))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("B") ? "a.dt_bruto" : "a.dt_tara") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_PesagemFazenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PesagemFazenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemFazenda qtb_ps = new TCD_PesagemFazenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ps.CriarBanco_Dados(true);
                else
                    qtb_ps.Banco_Dados = banco;
                string retorno = qtb_ps.Gravar(val);
                if (st_transacao)
                    qtb_ps.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ps.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pesagem fazenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ps.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PesagemFazenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PesagemFazenda qtb_ps = new TCD_PesagemFazenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ps.CriarBanco_Dados(true);
                else
                    qtb_ps.Banco_Dados = banco;
                qtb_ps.Excluir(val);
                if (st_transacao)
                    qtb_ps.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ps.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pesagem fazenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ps.deletarBanco_Dados();
            }
        }
    }
}
