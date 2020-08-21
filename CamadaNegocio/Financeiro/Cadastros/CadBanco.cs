using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadBanco
    {
        public static TList_CadBanco Buscar(string vCd_banco,
                                            string vDs_banco,
                                            string vNm_campo,
                                            int vTop,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_banco.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Banco";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_banco.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vDs_banco.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Banco";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_banco.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            return new TCD_CadBanco(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarBanco(TRegistro_CadBanco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadBanco cd = new TCD_CadBanco();
            try
            {
                if(banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.GravarBanco(val);
                if(st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar banco: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string DeletarBanco(TRegistro_CadBanco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadBanco cd = new TCD_CadBanco();
            try
            {
                if(banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.DeletarBanco(val);
                if(st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir banco: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

    }
}
