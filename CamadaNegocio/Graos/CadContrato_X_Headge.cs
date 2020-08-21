using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;
using BancoDados;

namespace CamadaNegocio.Graos
{
    public class TCN_CadContrato_Headge
    {


        public static TList_CadContrato_Headge Busca(string vID_Headge,
                                                         string vNr_Contrato,
                                                         string vTpValor,
                                                         string vCD_Clifor, 
                                                         string vCD_Endereco, 
                                                         string vTp_Duplicata,
                                                         TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vTpValor.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TpValor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTpValor.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Clifor.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Endereco.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Endereco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Endereco.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vTp_Duplicata.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Duplicata";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_Duplicata.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vNr_Contrato.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_Contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNr_Contrato;
            }

            if (!string.IsNullOrEmpty(vID_Headge.Trim()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_Headge";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Headge;
            }

            return new TCD_CadContrato_Headge(banco).Select(vBusca, 0, string.Empty);
        }

        public static string GravarContrato_Headge(TRegistro_CadContrato_Headge vContrato_Headge, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato_Headge qtb_Contrato_Headge = new TCD_CadContrato_Headge();
            try
            {
                if (banco == null)
                {
                    qtb_Contrato_Headge.CriarBanco_Dados(true);
                    banco = qtb_Contrato_Headge.Banco_Dados;
                    st_transacao = true;
                }
                else
                    qtb_Contrato_Headge.Banco_Dados = banco;

                string r_Contrato_Headge = qtb_Contrato_Headge.Grava(vContrato_Headge);

                if (st_transacao)
                    qtb_Contrato_Headge.Banco_Dados.Commit_Tran();

                return r_Contrato_Headge;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Contrato_Headge.Banco_Dados.RollBack_Tran();

                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_Contrato_Headge.deletarBanco_Dados();
            }
        }

        public static string DeletarContrato_Headge(TRegistro_CadContrato_Headge val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContrato_Headge Qtb_Contrato_Headge = new TCD_CadContrato_Headge();
            try
            {
                if (banco == null)
                {
                    Qtb_Contrato_Headge.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    Qtb_Contrato_Headge.Banco_Dados = banco;
                //Deletar Uf
                Qtb_Contrato_Headge.Deleta(val);
                if (st_transacao)
                    Qtb_Contrato_Headge.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    Qtb_Contrato_Headge.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    Qtb_Contrato_Headge.deletarBanco_Dados();
            }
        }

      
    }
}

