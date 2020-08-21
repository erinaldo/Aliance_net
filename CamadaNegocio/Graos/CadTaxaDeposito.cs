using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadTaxaDeposito
    {
        public static TList_CadTaxaDeposito Buscar(string vId_Taxa,
                                                   string vDs_Taxa,
                                                   string vTP_Taxa,
                                                   string vNm_campo,
                                                   int vTop,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            
            if (!string.IsNullOrEmpty(vId_Taxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_taxa";
                filtro[filtro.Length - 1].vVL_Busca = vId_Taxa;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Taxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_taxa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTP_Taxa + "'";
                filtro[filtro.Length - 1].vOperador = "like";
            }

            if (!string.IsNullOrEmpty(vDs_Taxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_taxa";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vDs_Taxa + "%'";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            return new TCD_CadTaxaDeposito(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTaxaDeposito(TRegistro_CadTaxaDeposito val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTaxaDeposito qtb_TaxaDeposito = new TCD_CadTaxaDeposito();
            try
            {
                if (banco == null)
                {
                    qtb_TaxaDeposito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_TaxaDeposito.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_TaxaDeposito.GravarTaxaDeposito(val);
                if (st_transacao)
                    qtb_TaxaDeposito.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_TaxaDeposito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_TaxaDeposito.deletarBanco_Dados();
            }
        }

        public static string DeletarTaxaDeposito(TRegistro_CadTaxaDeposito val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTaxaDeposito qtb_TaxaDeposito = new TCD_CadTaxaDeposito();
            try
            {
                if (banco == null)
                {
                    qtb_TaxaDeposito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_TaxaDeposito.Banco_Dados = banco;
                //Deletar Uf
                qtb_TaxaDeposito.DeletarTaxaDeposito(val);
                if (st_transacao)
                    qtb_TaxaDeposito.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_TaxaDeposito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_TaxaDeposito.deletarBanco_Dados();
            }
        }
    }
}
