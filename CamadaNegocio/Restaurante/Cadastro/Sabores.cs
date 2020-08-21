using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Restaurante.Cadastro;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_Sabores
    {

        public static TList_Sabores Buscar( 
                                          string id_sabor,
                                          string ds_sabor,
                                          string cd_grupo,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_sabor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_sabor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_sabor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ds_sabor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_sabor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_sabor.Trim() + "%'";
            }
            return new TCD_Sabores(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Sabores val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Sabores qtb_orc = new TCD_Sabores();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                val.ID_Sabor = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_SABOR"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.ID_Sabor.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar sabor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Sabores val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Sabores qtb_orc = new TCD_Sabores();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir sabor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
