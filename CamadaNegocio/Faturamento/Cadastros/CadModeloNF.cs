using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;
using BancoDados;
using Utils;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CadModeloNF
    {
        public static TList_CadModeloNF Busca (string vCD_Modelo,
                                               string vDS_Modelo,
                                               string vST_Registro,
                                               string vNM_Campo,
                                               BancoDados.TObjetoBanco banco)
    
    
    {
        TpBusca[] vBusca = new TpBusca[0];

        if (vCD_Modelo.Trim() != "")
        {
            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Modelo";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Modelo + "'";
        }

        if (vDS_Modelo.Trim() != "")
        {
            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Modelo";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Modelo + "'";
        }

        if (vST_Registro.Trim() != "")
        {
            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro + "'";
        }

        return new TCD_CadModeloNF(banco).Select(vBusca, 0, vNM_Campo);
    }

        public static string Grava_CadModeloNF(TRegistro_CadModeloNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadModeloNF cd = new TCD_CadModeloNF();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar modelo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Deleta_CadModeloNF(TRegistro_CadModeloNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadModeloNF cd = new TCD_CadModeloNF();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir modelo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
