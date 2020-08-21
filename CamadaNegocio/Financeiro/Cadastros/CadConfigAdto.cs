using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadConfigAdto
    {
        public static TList_ConfigAdto Buscar(string vCd_empresa,
                                              string vCd_historico_adto_c,
                                              string vCd_historico_adto_r,
                                              string vCd_historico_devadto_c,
                                              string vCd_historico_devadto_r,
                                              int vTop,
                                              string vNm_campo,
                                              TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
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
            if (!string.IsNullOrEmpty(vCd_historico_adto_c))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico_Adto_C";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico_adto_c.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_historico_adto_r))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico_Adto_R";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico_adto_r.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_historico_devadto_c))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico_DEVAdto_C";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico_devadto_c.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_historico_devadto_r))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico_DEVAdto_R";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico_devadto_r.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_CadConfigAdto(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadConfigAdto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConfigAdto cd = new TCD_CadConfigAdto();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.GravarConfigAdto(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadConfigAdto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConfigAdto cd = new TCD_CadConfigAdto();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.DeletarConfigAdto(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
