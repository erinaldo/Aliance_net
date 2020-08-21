using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Restaurante.Cadastro;
using Utils;
using System.Text;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_Local
    {

        public static TList_Local Buscar(
                                          string id_local,
                                          string ds_Local,
                                          string st_registro,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_local;
            }
            if (!string.IsNullOrEmpty(ds_Local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_Local";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_Local.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(st_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vVL_Busca = st_registro.Trim();
            }
            return new TCD_Local(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Local val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Local qtb_orc = new TCD_Local();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                val.Id_Local = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_Local"));

                val.lMesa.ForEach(p =>
                {
                    p.Id_Local = val.Id_Local;
                    TCN_Mesa.Gravar(p, qtb_orc.Banco_Dados);
                });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Local.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Local val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Local qtb_orc = new TCD_Local();
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
                throw new Exception("Erro excluir local, pois existe mesa cadastrada!");
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
