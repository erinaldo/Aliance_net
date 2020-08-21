using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Estoque;

namespace CamadaNegocio.Estoque
{
    public class TCN_LanTransfLocal_X_Estoque
    {
        public static TList_LanTransfLocal_X_Estoque Busca(decimal vID_Transf,
                                                           string vCD_Empresa,
                                                           string vCD_Produto,
                                                           decimal vID_LanctoEstoque)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Transf > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Transf";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Transf.ToString();
            }
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
            }
            if (vID_LanctoEstoque > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_LanctoEstoque";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_LanctoEstoque.ToString();
            }
            
            
            TCD_LanTransfLocal_X_Estoque cd = new TCD_LanTransfLocal_X_Estoque();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravarTransLocal_X_Estoque(TRegistro_LanTransfLocal_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTransfLocal_X_Estoque qtb_transf = new TCD_LanTransfLocal_X_Estoque();
            try
            {
                if (banco == null)
                {
                    qtb_transf.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_transf.Banco_Dados = banco;
                string retorno = qtb_transf.Grava(val);
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }
    }
}
