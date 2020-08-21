using System;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_Cad_TaxaBandeiraCartao
    {
        public static TList_Cad_TaxaBandeiraCartao Buscar(string ID_Bandeira,
                                                          string Cd_empresa,
                                                          string Id_maquina,
                                                          string Cd_DomicilioBancario,  
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
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrWhiteSpace(Id_maquina))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_maquina";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_maquina;
            }
            if (!string.IsNullOrEmpty(Cd_DomicilioBancario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_domiciliobancario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_DomicilioBancario.Trim() + "'";
            }
            return new TCD_Cad_TaxaBandeiraCartao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_Cad_TaxaBandeiraCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_TaxaBandeiraCartao qtb_bandeiracartao = new TCD_Cad_TaxaBandeiraCartao();
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

        public static string Deletar(TRegistro_Cad_TaxaBandeiraCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_TaxaBandeiraCartao qtb_bandeiracartao = new TCD_Cad_TaxaBandeiraCartao();
            try
            {
                if (banco == null)
                {
                    qtb_bandeiracartao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_bandeiracartao.Banco_Dados = banco;
                qtb_bandeiracartao.Excluir(val);
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
