using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadContatoCliFor
    {
        public static TList_CadContatoCliFor Buscar(string vId_Contato,
                                                    string vCd_CliFor,
                                                    string vTp_Contato,
                                                    string vNm_Contato,
                                                    string vEmail,
                                                    string vFone,
                                                    string vFoneMovel,
                                                    bool St_Danfe,
                                                    bool St_xmlNfe,
                                                    bool St_receberOS,
                                                    string vNm_campo,
                                                    int vTop,
                                                    TObjetoBanco banco)

        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_Contato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_Contato";
                filtro[filtro.Length - 1].vVL_Busca = vId_Contato;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_CliFor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_cliFor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_CliFor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTp_Contato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_Contato";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_Contato.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNm_Contato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nm_Contato";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNm_Contato.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vEmail))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Email";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vEmail+ "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vFone))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Fone";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vFone+ "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vFoneMovel))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.FoneMovel";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vFoneMovel+ "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (St_Danfe)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_receberdanfe, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_xmlNfe)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_receberxmlnfe, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_receberOS)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_receberOS, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }

            return new TCD_CadContatoCliFor(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TRegistro_CadContatoCliFor BuscarCadContatoCliFor(string vId_Contato,
                                                                        string vCd_CliFor,
                                                                        string vTp_Contato,
                                                                        string vNM_Contato,
                                                                        string vEmail,
                                                                        string vFone,
                                                                        string vFoneMovel,
                                                                        string vNm_campo,
                                                                        TObjetoBanco banco)
        {
            TList_CadContatoCliFor listaCadContatoClifor = Buscar(vId_Contato, 
                                                                  vCd_CliFor, 
                                                                  vTp_Contato,
                                                                  vNM_Contato, 
                                                                  vEmail, 
                                                                  vFone, 
                                                                  vFoneMovel, 
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  vNm_campo, 
                                                                  1, 
                                                                  banco);
            if (listaCadContatoClifor.Count > 0)
                return listaCadContatoClifor[0];
            else
                return new TRegistro_CadContatoCliFor();
        }

        public static string Gravar(TRegistro_CadContatoCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContatoCliFor qtb_ContatoClifor = new TCD_CadContatoCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ContatoClifor.CriarBanco_Dados(true);
                else
                    qtb_ContatoClifor.Banco_Dados = banco;
                //Gravar Uf
                val.Id_Contato_St = CamadaDados.TDataQuery.getPubVariavel(qtb_ContatoClifor.GravarContatoCliFor(val), "@P_ID_CONTATO");
                //Exluir Data Contato
                val.lDataContatoDel.ForEach(p => TCN_DataContato.Excluir(p, qtb_ContatoClifor.Banco_Dados));
                //Gravar Data Contato
                val.lDataContato.ForEach(p =>
                {
                    p.Cd_clifor = val.Cd_CliFor;
                    p.Id_contato = val.Id_Contato;
                    TCN_DataContato.Gravar(p, qtb_ContatoClifor.Banco_Dados);
                });
                if (st_transacao)
                    qtb_ContatoClifor.Banco_Dados.Commit_Tran();
                return val.Id_Contato_St;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContatoClifor.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContatoClifor.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadContatoCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContatoCliFor qtb_ContatoClifor = new TCD_CadContatoCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ContatoClifor.CriarBanco_Dados(true);
                else
                    qtb_ContatoClifor.Banco_Dados = banco;
                //Deletar Uf
                qtb_ContatoClifor.DeletarContatoCliFor(val);// DeletarContatoCliFor(val);
                if (st_transacao)
                    qtb_ContatoClifor.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContatoClifor.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContatoClifor.deletarBanco_Dados();
            }
        }
    }
}
