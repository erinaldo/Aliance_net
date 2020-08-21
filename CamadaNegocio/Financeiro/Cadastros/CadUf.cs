using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadUf
    {
        public static TList_CadUf Buscar(string vUf,
                                         string vCd_uf,
                                         string vDs_uf,
                                         string vNm_campo,
                                         int vTop,
                                         TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vUf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.UF";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vUf.Trim().Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_uf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_UF";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_uf.Trim().Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_uf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_UF";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDs_uf.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_CadUf(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TRegistro_CadUf BuscarUf(string vUf,
                                               string vCd_uf,
                                               string vDs_uf,
                                               string vNm_campo,
                                               int vTop,
                                               TObjetoBanco banco)
        {
            TList_CadUf lUf = Buscar(vUf, vCd_uf, vDs_uf, vNm_campo, vTop, banco);
            if (lUf.Count > 0)
                return lUf[0];
            else
                return new TRegistro_CadUf();
        }

        public static string GravarUf(TRegistro_CadUf val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUf qtb_uf = new TCD_CadUf();
            try
            {
                if (banco == null)
                    st_transacao = qtb_uf.CriarBanco_Dados(true);
                else
                    qtb_uf.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_uf.GravarUf(val);
                if (st_transacao)
                    qtb_uf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_uf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar UF: "+ ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_uf.deletarBanco_Dados();
            }
        }

        public static string DeletarUf(TRegistro_CadUf val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUf qtb_uf = new TCD_CadUf();
            try
            {
                if (banco == null)
                    st_transacao = qtb_uf.CriarBanco_Dados(true);
                else
                    qtb_uf.Banco_Dados = banco;
                //Deletar Uf
                qtb_uf.DeletarUf(val);
                if (st_transacao)
                    qtb_uf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_uf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir UF: "+ ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_uf.deletarBanco_Dados();
            }
        }
    }
}
