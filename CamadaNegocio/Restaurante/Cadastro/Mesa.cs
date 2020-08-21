using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Restaurante.Cadastro;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_Mesa
    {

        public static TList_Mesa Buscar(string nr_mesa,
                                          string id_local,
                                          string ds_mesa,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(nr_mesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_mesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_mesa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_local;
            }
            if (!string.IsNullOrEmpty(ds_mesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_mesa";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_mesa.Trim() + "%'";
            }
            Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'A'");

            return new TCD_Mesa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Mesa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mesa qtb_orc = new TCD_Mesa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                val.Id_Mesa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_MESA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Mesa.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar mesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        
        public static string Excluir(TRegistro_Mesa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mesa qtb_orc = new TCD_Mesa();
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
                throw new Exception("Erro excluir mesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
}
