using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_PistaBoliche
    {
        public static TList_PistaBoliche Buscar(string id_pista,
                                                string ds_pista,
                                                string st_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_pista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_pista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ds_pista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_pista";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_pista + "%'";
            }
            if (!string.IsNullOrEmpty(st_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + st_registro.ToString().Trim() + "'";
            }
            return new TCD_PistaBoliche(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PistaBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PistaBoliche qtb_orc = new TCD_PistaBoliche();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                string ret = qtb_orc.Gravar(val);
                val.Id_Pista = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_PISTA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Pista.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PistaBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PistaBoliche qtb_orc = new TCD_PistaBoliche();
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
                throw new Exception("Erro excluir pista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
}
