using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadContratoTaxaDeposito
    {
        public static TList_CadContratoTaxaDeposito Buscar(
                                        decimal vId_Reg,
                                        decimal vNr_Contrato,
                                        decimal vId_Taxa,
                                        decimal vValorTaxa,
                                        string vCD_UnidadeTaxa,
                                        decimal vPeriodoCarencia,
                                        decimal vFrequencia,
                                        string vCD_TipoAmostra,
                                        decimal vPC_Result_MaiorQue,
                                        decimal vPC_Result_MenorQue,
                                        string vST_GerarTXSomente,
                                        string vNm_campo,
                                        int vTop,
                                        TObjetoBanco banco
        )
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vId_Reg > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_Reg";
                filtro[filtro.Length - 1].vVL_Busca = vId_Reg.ToString().Replace(",",".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_Contrato > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato.ToString().Replace(",", "."); 
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vId_Taxa > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_Taxa";
                filtro[filtro.Length - 1].vVL_Busca =  vId_Taxa.ToString().Replace(",",".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vValorTaxa > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ValorTaxa";
                filtro[filtro.Length - 1].vVL_Busca = vValorTaxa.ToString().Replace(",", ".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_UnidadeTaxa != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_UnidadeTaxa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_UnidadeTaxa.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vPeriodoCarencia > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.PeriodoCarencia";
                filtro[filtro.Length - 1].vVL_Busca = vPeriodoCarencia.ToString().Replace(",", ".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vFrequencia > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Frequencia";
                filtro[filtro.Length - 1].vVL_Busca = vFrequencia.ToString().Replace(",", ".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_TipoAmostra != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_TipoAmostra";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_TipoAmostra + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vPC_Result_MaiorQue > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.PC_Result_MaiorQue";
                filtro[filtro.Length - 1].vVL_Busca = vPC_Result_MaiorQue.ToString().Replace(",", ".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vPC_Result_MenorQue > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.PC_Result_MenorQue";
                filtro[filtro.Length - 1].vVL_Busca = vPC_Result_MenorQue.ToString().Replace(",", ".");
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vST_GerarTXSomente != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_GerarTXSomente";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_GerarTXSomente + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_CadContratoTaxaDeposito().Select(filtro, vTop, vNm_campo);
        }

        public static string GravarContratoTaxaDeposito(TRegistro_CadContratoTaxaDeposito val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoTaxaDeposito qtb_ContratoTaxaDeposito = new TCD_CadContratoTaxaDeposito();
            try
            {
                if (banco == null)
                {
                    qtb_ContratoTaxaDeposito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ContratoTaxaDeposito.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_ContratoTaxaDeposito.GravarContratoTaxaDeposito(val);
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.deletarBanco_Dados();
            }
        }

        public static string DeletarContratoTaxaDeposito(TRegistro_CadContratoTaxaDeposito val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoTaxaDeposito qtb_ContratoTaxaDeposito = new TCD_CadContratoTaxaDeposito();
            try
            {
                if (banco == null)
                {
                    qtb_ContratoTaxaDeposito.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ContratoTaxaDeposito.Banco_Dados = banco;
                //Deletar Uf
                qtb_ContratoTaxaDeposito.DeletarContratoTaxaDeposito(val);
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContratoTaxaDeposito.deletarBanco_Dados();
            }
        }
    }
}
