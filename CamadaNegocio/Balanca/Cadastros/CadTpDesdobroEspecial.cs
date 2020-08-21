using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca.Cadastros;

namespace CamadaNegocio.Balanca.Cadastros
{
    public class TCN_TpDesdobroEspecial
    {
        public static TList_TpDesdobroEspecial Buscar(string Id_tpdesdobro,
                                                      string Ds_tpdesdobro,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if(!string.IsNullOrEmpty(Id_tpdesdobro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tpdesdobro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tpdesdobro;
            }
            if (!string.IsNullOrEmpty(Ds_tpdesdobro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tpdesdobro";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_tpdesdobro.Trim() + "%')";
            }
            return new TCD_TpDesdobroEspecial(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpDesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpDesdobroEspecial qtb_desd = new TCD_TpDesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desd.CriarBanco_Dados(true);
                else
                    qtb_desd.Banco_Dados = banco;
                val.Id_tpdesdobro = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_desd.Gravar(val), "@P_ID_TPDESDOBRO"));
                if (st_transacao)
                    qtb_desd.Banco_Dados.Commit_Tran();
                return val.Id_tpdesdobro.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpDesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpDesdobroEspecial qtb_desd = new TCD_TpDesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desd.CriarBanco_Dados(true);
                else
                    qtb_desd.Banco_Dados = banco;
                qtb_desd.Excluir(val);
                if (st_transacao)
                    qtb_desd.Banco_Dados.Commit_Tran();
                return val.Id_tpdesdobro.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desd.deletarBanco_Dados();
            }
        }
    }
}
