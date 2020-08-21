using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_PercDesconto
    {
        public static TList_PercDesconto Buscar(string Cd_tabeladesconto,
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
            return new TCD_PercDesconto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PercDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PercDesconto qtb_perc = new TCD_PercDesconto();
            try
            {
                if(banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else
                    qtb_perc.Banco_Dados = banco;
                string retorno = qtb_perc.Gravar(val);
                if(st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PercDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PercDesconto qtb_perc = new TCD_PercDesconto();
            try
            {
                if(banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else
                    qtb_perc.Banco_Dados = banco;
                qtb_perc.Excluir(val);
                if(st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }

        public static List<TRegistro_PercDesconto> CalcLoteDesconto(decimal pc_ini_resultado,
                                                                    decimal pc_fin_resultado,
                                                                    decimal intervalo_resultado,
                                                                    decimal pc_desc_apartir,
                                                                    decimal pc_desc_inicial,
                                                                    decimal intervalo_desconto)
        {
            List<TRegistro_PercDesconto> result = null;
            while (pc_ini_resultado <= pc_fin_resultado)
            {
                if (result == null)
                    result = new List<TRegistro_PercDesconto>();
                TRegistro_PercDesconto r = new TRegistro_PercDesconto();
                r.Pc_resultado = pc_ini_resultado;
                if (pc_desc_apartir <= r.Pc_resultado)
                {
                    r.Pc_descestoque = pc_desc_inicial;
                    r.Pc_descpagto = pc_desc_inicial;

                    pc_desc_inicial += intervalo_desconto;
                }
                pc_ini_resultado += intervalo_resultado;

                result.Add(r);
            }
            return result;
        }
    }
}
