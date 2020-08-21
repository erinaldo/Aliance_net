using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Fazenda.Lancamento;

namespace CamadaNegocio.Fazenda.Lancamento
{
    public class TCN_LanPesFazenda
    {
        public static TList_LanPesFazenda Buscar(string vCD_Empresa,
                                                    decimal vID_Ticket,
                                                    string vTP_Tesagem,
                                                    string vCD_Produto)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Empresa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Ticket > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_Tesagem.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Tesagem + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'"; 
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_LanPesFazenda().Select(vBusca, 0, "");
        }

        public static string GravarPesFazenda(TRegistro_LanPesFazenda val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPesFazenda lanFazenda = new TCD_LanPesFazenda();
            try
            {
                if (banco == null)
                {
                    lanFazenda.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    lanFazenda.Banco_Dados = banco;
                string retorno = lanFazenda.Grava(val);
                if (pode_liberar)
                    lanFazenda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    lanFazenda.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    lanFazenda.deletarBanco_Dados();
            }
        }

        public static string DeletarPesFazenda(TRegistro_LanPesFazenda val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPesFazenda lanFazenda = new TCD_LanPesFazenda();
            try
            {
                if (banco == null)
                {
                    lanFazenda.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    lanFazenda.Banco_Dados = banco;
                string retorno = lanFazenda.Deleta(val);
                if (pode_liberar)
                    lanFazenda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    lanFazenda.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    lanFazenda.deletarBanco_Dados();
            }
        }
    }
}
