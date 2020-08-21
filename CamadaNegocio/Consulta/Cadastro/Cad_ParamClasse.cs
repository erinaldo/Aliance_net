/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;
using BancoDados;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_ParamClasse
    {
        public static TList_Cad_ParamClasse Buscar(decimal vID_ParamClasse,
                                                   string vNM_Param,
                                                   string vNM_CampoFormat,
                                                   string vNM_Classe,
                                                   int vTop,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_ParamClasse > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_ParamClasse";
                filtro[filtro.Length - 1].vVL_Busca = "" + vID_ParamClasse.ToString() + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vNM_Param.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_ParamCaption";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNM_Param + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            if (vNM_CampoFormat.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_CampoFormat";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNM_CampoFormat + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            if (vNM_Classe.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Classe";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNM_Classe + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }

            TCD_Cad_ParamClasse qtb_ParamClasse = new TCD_Cad_ParamClasse();
            return qtb_ParamClasse.Select(filtro, vTop, "");
        }

        public static string GravarParamClasse(TRegistro_Cad_ParamClasse val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_ParamClasse qtb_ParamClasse = new TCD_Cad_ParamClasse();
            try
            {
                if (banco == null)
                {
                    qtb_ParamClasse.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_ParamClasse.Banco_Dados;
                }
                else
                    qtb_ParamClasse.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_ParamClasse.GravarParamClasse(val);
                if (st_transacao)
                    qtb_ParamClasse.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                {
                    qtb_ParamClasse.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_ParamClasse.deletarBanco_Dados();
            }
        }

        public static string DeletarParamClasse(TRegistro_Cad_ParamClasse val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_ParamClasse qtb_ParamClasse = new TCD_Cad_ParamClasse();
            try
            {
                if (banco == null)
                {
                    qtb_ParamClasse.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ParamClasse.Banco_Dados = banco;
                //Deletar Uf
                qtb_ParamClasse.DeletarParamClasse(val);
                if (st_transacao)
                    qtb_ParamClasse.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ParamClasse.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_ParamClasse.deletarBanco_Dados();
            }
        }

        public static TList_Cad_ParamClasse BuscaParamClasseSQLString(string SQL)
        {
            TList_Cad_ParamClasse lParamRetorno = new TList_Cad_ParamClasse();
            const char chaveInicio = '{';
            const char chaveFim = '}';

            char[] delimitadores = new char[] { chaveInicio, chaveFim };
            String[] resultadoArray = SQL.Split(delimitadores);


            for (int i = 0; i < resultadoArray.Length; i++)
            {
                if (resultadoArray[i].IndexOf("@") == 0)
                {
                    TList_Cad_ParamClasse listaParam = TCN_Cad_ParamClasse.Buscar(0, "", "{" + resultadoArray[i] + "}", "", 0, null);

                    for (int x = 0; x < listaParam.Count; x++)
                    {
                        if (!lParamRetorno.Exists(p => p.NM_CampoFormat == (listaParam[x] as TRegistro_Cad_ParamClasse).NM_CampoFormat))
                        {
                            //ADD A LISTA DE RETORNO DOS PARAMETROS
                            lParamRetorno.Add(listaParam[x] as TRegistro_Cad_ParamClasse);
                        }
                    }
                }
            }

            return lParamRetorno;
        }
    }
}
