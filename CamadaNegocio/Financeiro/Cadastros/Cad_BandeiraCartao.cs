using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
namespace CamadaNegocio.Financeiro.Cadastros
{

    public class TCN_Cad_BandeiraCartao
    {
        public static TList_Cad_BandeiraCartao Buscar(string ID_Bandeira,
                                                      string DS_Bandeira,
                                                      string Tp_cartao,
                                                      int vTop,
                                                      string vNm_campo,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(ID_Bandeira))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Bandeira";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Bandeira;
            }
            if (!string.IsNullOrEmpty(DS_Bandeira))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Bandeira";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + DS_Bandeira.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Tp_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_cartao.Trim() + "'";
            }
            return new TCD_Cad_BandeiraCartao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_Cad_BandeiraCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_BandeiraCartao qtb_bandeiracartao = new TCD_Cad_BandeiraCartao();
            try
            {
                if (banco == null)
                {
                    qtb_bandeiracartao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_bandeiracartao.Banco_Dados = banco;
                string retorno = qtb_bandeiracartao.Gravar(val);
                if (st_transacao)
                    qtb_bandeiracartao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bandeiracartao.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bandeiracartao.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_Cad_BandeiraCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_BandeiraCartao qtb_bandeiracartao = new TCD_Cad_BandeiraCartao();
            try
            {
                if (banco == null)
                {
                    qtb_bandeiracartao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_bandeiracartao.Banco_Dados = banco;
                try
                {
                    qtb_bandeiracartao.Excluir(val);
                }
                catch
                {
                    val.St_registro = "C";
                    qtb_bandeiracartao.Gravar(val);
                }
                if (st_transacao)
                    qtb_bandeiracartao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bandeiracartao.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bandeiracartao.deletarBanco_Dados();
            }
        }
    }
}
