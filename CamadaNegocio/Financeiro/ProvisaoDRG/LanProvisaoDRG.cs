using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.ProvisaoDRG;
using System.Data;

namespace CamadaNegocio.Financeiro.ProvisaoDRG
{
    #region "Classe ProvisaoDRG"
    public class TCN_LanProvisaoDRG
    {
        public static TList_LanProvisaoDRG Buscar(string Cd_centroresult,
                                                  string Cd_empresa,
                                                  decimal Ano,
                                                  decimal mes,
                                                  int vTop,
                                                  string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_centroresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_centroresult";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_centroresult.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Cd_empresa.Trim() + ")";
            }
            if (Ano > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Ano.ToString();
            }
            if (mes > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.mes";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = mes.ToString();
            }

            return new TCD_LanProvisaoDRG().Select(filtro);
        }

        public static string Gravar(TList_LanProvisaoDRG val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanProvisaoDRG qtb_prov = new TCD_LanProvisaoDRG();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prov.CriarBanco_Dados(true);
                else
                    qtb_prov.Banco_Dados = banco;
                string retorno = string.Empty;
                val.ForEach(p => Gravar(p, qtb_prov.Banco_Dados));
                if (st_transacao)
                    qtb_prov.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prov.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_prov.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_LanProvisaoDRG val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanProvisaoDRG qtb_provisao = new TCD_LanProvisaoDRG();
            try
            {
                if (banco == null)
                {
                    qtb_provisao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_provisao.Banco_Dados = banco;
                //Gravar provisao
                string retorno = qtb_provisao.Gravar(val);
                if (st_transacao)
                    qtb_provisao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_provisao.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_provisao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanProvisaoDRG val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanProvisaoDRG qtb_provisao = new TCD_LanProvisaoDRG();
            try
            {
                if (banco == null)
                {
                    qtb_provisao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_provisao.Banco_Dados = banco;
                //Deletar Provisao
                qtb_provisao.Excluir(val);
                if (st_transacao)
                    qtb_provisao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_provisao.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_provisao.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Previsao Centro Resultado por Mes
    public class TCN_ProvisaoMes
    {
        public static TList_ProvisaoMes Buscar(string cd_empresa,
                                               string cd_grupocf,
                                               string ano,
                                               string anoIni,
                                               string anoFin)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(cd_grupocf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_centroresult";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupocf.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ano))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + ano + ")";
            }
            if (!string.IsNullOrEmpty(anoIni))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = anoIni;
            }
            if (!string.IsNullOrEmpty(anoFin))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = anoFin;
            }
            return new TCD_ProvisaoMes().Select(filtro);
        }
    }
    #endregion
}
