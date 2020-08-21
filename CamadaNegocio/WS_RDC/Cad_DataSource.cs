using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.WS_RDC;
using Utils;
using System.Data;
using BancoDados;

namespace CamadaNegocio.WS_RDC
{
    public class TCN_Cad_DataSource
    {
        public static TList_Cad_DataSource Busca(string vID_DataSource, 
                                                 string vNM_DataSource,
                                                 string vID_RDC,
                                                 TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_DataSource.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_DataSource";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_DataSource.ToString() + "'";
            }
            if (vNM_DataSource.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_DataSource";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_DataSource + "%'";
            }
            if (vID_RDC.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(SELECT 1 FROM TB_BIN_RDC_X_DATASOURCE x WHERE x.ID_DTS = a.ID_DTS AND x.ID_RDC = '"+vID_RDC+"')";
            }

            TCD_Cad_DataSource cd = new TCD_Cad_DataSource();
            if (banco != null)
                cd.Banco_Dados = banco;
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaDataSource(TRegistro_Cad_DataSource val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_DataSource qtb_DTS = new TCD_Cad_DataSource();
            try
            {
                if (banco == null)
                {
                    qtb_DTS.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_DTS.Banco_Dados;
                }
                else
                    qtb_DTS.Banco_Dados = banco;

                //GRAVA O REPORT
                string retorno = qtb_DTS.Grava(val);

                if (st_transacao)
                    qtb_DTS.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_DTS.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_DTS.deletarBanco_Dados();
            }
        }

        public static string DeletaDataSource(TRegistro_Cad_DataSource val, TObjetoBanco banco)
        {

            bool st_transacao = false;
            TCD_Cad_DataSource CD_DataSource = new TCD_Cad_DataSource();
            TCD_Cad_RDC_X_DataSource CD_RDC_X_DataSource = new TCD_Cad_RDC_X_DataSource();
            
            try
            {
                if (banco == null)
                {
                    CD_DataSource.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                {
                    CD_DataSource.Banco_Dados = banco;
                }

                //DELETAR CONSULTA
                string retorno = CD_RDC_X_DataSource.DeletarRDCPorDataSource(val.ID_DataSource);
                
                //DELETE A CONSULTA
                retorno = CD_DataSource.Deleta(val);

                if (st_transacao)
                    CD_DataSource.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (st_transacao)
                    CD_DataSource.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (st_transacao)
                    CD_DataSource.deletarBanco_Dados();
            }
        }
    }
}
