using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadMotivoInativo
    {
        public static TList_CadMotivoInativo Buscar(string ID_Motivo,
                                                      string DS_Motivo,
                        
                                                      int vTop,
                                                      string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (ID_Motivo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ID_Motivo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + ID_Motivo.Trim() + "'";
            }
            if (DS_Motivo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "DS_Motivo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + DS_Motivo.Trim() + "%')";
            }
            return new TCD_CadMotivoInativo().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadMotivoInativo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMotivoInativo qtb_motivoinativo = new TCD_CadMotivoInativo();
            try
            {
                if (banco == null)
                {
                    qtb_motivoinativo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_motivoinativo.Banco_Dados = banco;
                string retorno = qtb_motivoinativo.GravarMotivoInativo(val);
                if (st_transacao)
                    qtb_motivoinativo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_motivoinativo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_motivoinativo.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_CadMotivoInativo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMotivoInativo qtb_motivoinativo = new TCD_CadMotivoInativo();
            try
            {
                if (banco == null)
                {
                    qtb_motivoinativo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_motivoinativo.Banco_Dados = banco;
                qtb_motivoinativo.DeletarMotivoInativo(val);
                if (st_transacao)
                    qtb_motivoinativo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_motivoinativo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_motivoinativo.deletarBanco_Dados();
            }
        }
    }
}
