using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using Utils;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadTpDoctoDup
    {
        public static TList_CadTpDoctoDup Buscar(string vtp_docto, 
                                                 string vds_docto, 
                                                 string vst_registro,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vtp_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_docto";
                filtro[filtro.Length - 1].vVL_Busca = vtp_docto;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vds_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_Tpdocto";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vds_docto.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vst_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vVL_Busca = vst_registro.Trim();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_CadTpDoctoDup(banco).Select(filtro, 0, string.Empty);
        }

        public static string gravarDocto(TRegistro_CadTpDoctoDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpDoctoDup docto = new TCD_CadTpDoctoDup();
            try
            {
                if (banco == null)
                    st_transacao = docto.CriarBanco_Dados(true);
                else
                    docto.Banco_Dados = banco;
                val.Tp_doctoString = CamadaDados.TDataQuery.getPubVariavel(docto.gravarDocto(val), "@P_TP_DOCTO");
                if (st_transacao)
                    docto.Banco_Dados.Commit_Tran();
                return val.Tp_doctoString;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    docto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo documento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    docto.deletarBanco_Dados();
            }
        }

        public static string deletarDocto(TRegistro_CadTpDoctoDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpDoctoDup docto = new TCD_CadTpDoctoDup();
            try
            {
                if (banco == null)
                    st_transacao = docto.CriarBanco_Dados(true);
                else
                    docto.Banco_Dados = banco;
                docto.deletarDocto(val);
                if (st_transacao)
                    docto.Banco_Dados.Commit_Tran();
                return val.Tp_doctoString;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    docto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tipo documento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    docto.deletarBanco_Dados();
            }
        }
    }
}
