using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos.Cadastros;
using BancoDados;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_OSE_SerialClifor
    {
        public static TList_OSE_SerialClifor Buscar(string vId_serial,
                                                    string vNR_Serial,
                                                    string vCD_Clifor,
                                                    string vCD_Produto,
                                                    string vSt_registro
                                                    )
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vId_serial.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_serial";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_serial;
            }
            if (vNR_Serial.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Serial";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNR_Serial.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_Clifor.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            
            if (vSt_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_registro.Trim() + "'";
            }
            
            return new TCD_OSE_SerialClifor().Select(filtro, 0, "");
        }

        public static string Gravar_SerialClifor(TRegistro_OSE_SerialClifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_SerialClifor qtb_SerialClifor = new TCD_OSE_SerialClifor();
            try
            {
                if (banco == null)
                {
                    qtb_SerialClifor.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_SerialClifor.Banco_Dados = banco;
                //Verificar se existe serial aberta
                TList_OSE_SerialClifor lSerial = TCN_OSE_SerialClifor.Buscar("", val.NR_Serial, string.Empty, string.Empty, "A");
                for (int i = 0; i < lSerial.Count; i++)
                {
                    lSerial[i].St_registro = "C";
                    qtb_SerialClifor.Grava(lSerial[i]);
                }
                string retorno = qtb_SerialClifor.Grava(val);
                if (st_transacao)
                    qtb_SerialClifor.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_SerialClifor.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_SerialClifor.deletarBanco_Dados();
            }
        }

        public static string Deletar_SerialClifor(TRegistro_OSE_SerialClifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_SerialClifor qtb_SerialClifor = new TCD_OSE_SerialClifor();
            try
            {
                if (banco == null)
                {
                    qtb_SerialClifor.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_SerialClifor.Banco_Dados = banco;
                qtb_SerialClifor.Deleta(val);
                if (st_transacao)
                    qtb_SerialClifor.Banco_Dados.Commit_Tran();
                return "";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_SerialClifor.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_SerialClifor.deletarBanco_Dados();
            }
        }
    }
}
