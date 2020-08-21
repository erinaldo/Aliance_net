using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.WS_RDC;
using Utils;
using BancoDados;
using System.IO;

namespace CamadaNegocio.WS_RDC
{
    public class TCN_Cad_RDC
    {
        public static TList_Cad_RDC Buscar(string vID_RDC,
                                           string vDS_RDC,
                                           string vModulo,
                                           string vNM_Classe,
                                           string vIdent,
                                           string vST_RDC,
                                           decimal vVersao, 
                                           string vNM_CampoBusca, 
                                           bool vBuscarDTS,
                                           bool vBuscarRelClasse,
                                           bool vNaoBuscarRelClasse,
                                           string vSistema, 
                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_RDC.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_RDC";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vID_RDC.ToString() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vDS_RDC.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_RDC";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDS_RDC.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            if (vModulo.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Modulo";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vModulo.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNM_Classe.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Classe";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNM_Classe.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vST_RDC.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_RDC";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_RDC + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vIdent.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ident";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vIdent.Replace("'", "''") + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVersao > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Versao";
                filtro[filtro.Length - 1].vVL_Busca = "" + vVersao.ToString() + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vBuscarRelClasse)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Classe";
                filtro[filtro.Length - 1].vVL_Busca = "null";
                filtro[filtro.Length - 1].vOperador = "!=";
            }
            if (vNaoBuscarRelClasse)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.NM_Classe,'')";
                filtro[filtro.Length - 1].vVL_Busca = "''";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSistema.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Sistema";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSistema + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            TCD_Cad_RDC qtb_RDC = new TCD_Cad_RDC();

            if (banco != null)
                qtb_RDC.Banco_Dados = banco;

            TList_Cad_RDC lRDC = qtb_RDC.Select(filtro, 0, vNM_CampoBusca);

            if (vBuscarDTS)
            {
                //BUSCA OS DATASOURCES
                foreach (TRegistro_Cad_RDC regRDC in lRDC)
                {
                    regRDC.lCad_DataSource = TCN_Cad_DataSource.Busca("", "", regRDC.ID_RDC, banco);

                    foreach (TRegistro_Cad_DataSource regDTS in regRDC.lCad_DataSource)
                    {
                        regDTS.lCad_ParamClasse = TCN_Cad_ParamClasse.BuscaParamRDCSQLString(regDTS.DS_SQL, banco);
                    }
                }
            }

            return lRDC;
        }

        public static string GravarRDC(TRegistro_Cad_RDC val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_RDC qtb_RDC = new TCD_Cad_RDC();
            try
            {
                if (banco == null)
                {
                    qtb_RDC.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_RDC.Banco_Dados;
                }
                else
                    qtb_RDC.Banco_Dados = banco;

                //GRAVA O REPORT
                string retorno = qtb_RDC.GravarRDC(val);

                //GRAVA TAMBÉM O DATASOURCE E AMARRA OS DOIS
                val.ID_RDC = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_RDC");

                //EXCLUI TODOS OS RDC X DATASOURCE
                TCN_Cad_RDC_X_DataSource.DeletarRDCPorRDC(val.ID_RDC, banco);

                foreach (TRegistro_Cad_DataSource Reg_DataSource in val.lCad_DataSource)
                {
                    string Ret_DTS = TCN_Cad_DataSource.GravaDataSource(Reg_DataSource, banco);
                    Reg_DataSource.ID_DataSource = CamadaDados.TDataQuery.getPubVariavel(Ret_DTS, "@P_ID_DATASOURCE");

                    TRegistro_Cad_RDC_X_DataSource reg_rdcdts = new TRegistro_Cad_RDC_X_DataSource();
                    reg_rdcdts.ID_RDC = val.ID_RDC;
                    reg_rdcdts.ID_DataSource = Reg_DataSource.ID_DataSource;
                    reg_rdcdts.ST_RDC = val.ST_RDC;

                    TCN_Cad_RDC_X_DataSource.GravarRDC_X_DataSource(reg_rdcdts, banco);

                    //GRAVA OS PARAMETROS
                    foreach (TRegistro_Cad_ParamClasse Reg_Param in Reg_DataSource.lCad_ParamClasse)
                        TCN_Cad_ParamClasse.GravarParamClasse(Reg_Param, banco);
                }

                if (st_transacao)
                    qtb_RDC.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_RDC.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_RDC.deletarBanco_Dados();
            }
        }

        public static string DeletarRDC(TRegistro_Cad_RDC val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_RDC qtb_RDC = new TCD_Cad_RDC();
            try
            {
                if (banco == null)
                {
                    qtb_RDC.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_RDC.Banco_Dados;
                }
                else
                    qtb_RDC.Banco_Dados = banco;
                //Deleta o menu
                new CamadaDados.TDataQuery(banco).executarSql("DELETE TB_DIV_Acesso " +
                               "FROM TB_DIV_Acesso a " +
                               "JOIN TB_DIV_Menu b ON a.id_menu = b.id_menu " +
                               "WHERE b.id_report = " + val.ID_RDC, null);

                new CamadaDados.TDataQuery(banco).executarSql("DELETE TB_DIV_Menu " +
                               "WHERE id_report = " + val.ID_RDC, null);

                //Deletar RDC
                qtb_RDC.DeletarRDC(val);
                if (st_transacao)
                    qtb_RDC.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                {
                    qtb_RDC.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                if (st_transacao)
                    qtb_RDC.deletarBanco_Dados();
            }
            return "";
        }
    }
}
