using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;
using BancoDados;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;
using CamadaNegocio.ConfigGer;
using System.IO;
using CamadaDados.WS_RDC;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Report
    {
        public static TList_Cad_Report Buscar(decimal vID_Report,
                                              string vDS_Report,
                                              string vModulo,
                                              string vNM_Classe,
                                              string vIdent,
                                              decimal vVersao,
                                              string vId_rdc,
                                              bool vNaoBuscarRelClasse,
                                              bool vBuscarHomologacao,
                                              bool vBuscarDTSParam)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_Report > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Report";
                filtro[filtro.Length - 1].vVL_Busca = vID_Report.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDS_Report))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Report";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vDS_Report.Trim() + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            if (!string.IsNullOrEmpty(vModulo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Modulo";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vModulo.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNM_Classe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Classe";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNM_Classe.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vIdent))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ident";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vIdent.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVersao > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Versao";
                filtro[filtro.Length - 1].vVL_Busca = vVersao.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNaoBuscarRelClasse)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.NM_Classe,'')";
                filtro[filtro.Length - 1].vVL_Busca = "''";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vBuscarHomologacao)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_RDC";
                filtro[filtro.Length - 1].vVL_Busca = "null";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vId_rdc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rdc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vId_rdc.Trim() + "'";
            }

            TList_Cad_Report lReport = new TCD_Cad_Report().Select(filtro, 0, string.Empty);
            
            if (vBuscarDTSParam)
            {
                //BUSCA OS DATASOURCES
                foreach (TRegistro_Cad_Report regReport in lReport)
                {
                    regReport.lConsulta = TCN_Cad_Consulta.Busca(0, string.Empty, string.Empty, regReport.ID_Report);
                    foreach (TRegistro_Cad_Consulta regConsulta in regReport.lConsulta)
                        regConsulta.lParamClasse = TCN_Cad_ParamClasse.BuscaParamClasseSQLString(regConsulta.DS_SQL);
                }
            }

            return lReport;
        }

        public static string GravarReport(TRegistro_Cad_Report val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;
                
                //GRAVA O REPORT
                string retorno = qtb_Report.GravarReport(val);

                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar relatorio: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }

        public static string GravarReportConsulta(TRegistro_Cad_Report val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;

                //GRAVA O REPORT
                string retorno = qtb_Report.GravarReport(val);
                val.ID_Report = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_REPORT"));

                //DELETA AS ANTIGAS AMARRAÇÕES
                new CamadaDados.TDataQuery(qtb_Report.Banco_Dados).executarSql("DELETE TB_CON_Report_X_Consulta " +
                               "WHERE id_report = " + val.ID_Report, null);

                new CamadaDados.TDataQuery(qtb_Report.Banco_Dados).executarSql("UPDATE TB_DIV_MENU set DS_Menu = '"+val.DS_Report+"' " +
                               "WHERE id_report = " + val.ID_Report, null);

                //GRAVA OS DTS
                val.lConsulta.ForEach(p =>
                {
                    p.Login = Utils.Parametros.pubLogin;
                    string ret_cons = TCN_Cad_Consulta.GravaConsulta(p, qtb_Report.Banco_Dados);
                    TCN_Cad_Report_X_Consulta.GravarReport_X_Consulta(
                        new TRegistro_Cad_Report_X_Consulta()
                        {
                            ID_Report = val.ID_Report,
                            ID_Consulta = CamadaDados.TDataQuery.getPubVariavel(ret_cons, "@P_ID_CONSULTA")
                        }, qtb_Report.Banco_Dados);

                    p.lParamClasse.ForEach(v => TCN_Cad_ParamClasse.GravarParamClasse(v, qtb_Report.Banco_Dados));
                });

                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar relatorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }

        public static string GravarReportXMenu(TRegistro_Cad_Report val, TRegistro_CadMenu valMenu, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;
                //GRAVA MENU
                string retorno = TCN_CadMenu.GravarMenu(valMenu, qtb_Report.Banco_Dados);
                
                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar menu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }

        public static string DeletarReport(TRegistro_Cad_Report val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;
                //Deleta o menu
                new CamadaDados.TDataQuery(qtb_Report.Banco_Dados).executarSql("DELETE TB_DIV_Acesso "+
                               "FROM TB_DIV_Acesso a "+
                               "JOIN TB_DIV_Menu b ON a.id_menu = b.id_menu " +
                               "WHERE b.id_report = "+val.ID_Report, null);

                new CamadaDados.TDataQuery(qtb_Report.Banco_Dados).executarSql("DELETE TB_DIV_Menu " +
                               "WHERE id_report = " + val.ID_Report, null);

                new CamadaDados.TDataQuery(qtb_Report.Banco_Dados).executarSql("DELETE TB_CON_Report_X_Consulta " +
                               "WHERE id_report = " + val.ID_Report, null);

                //Deletar Report
                qtb_Report.DeletarReport(val);
                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir relatorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }

        public static string AtualizaMenuReport(string ID_Menu, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report qtb_Report = new TCD_Cad_Report();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;

                qtb_Report.AtualizaMenuReport(ID_Menu);
                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar menu: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }

        private static bool VerificaRelatorio(string Nome_Relatorio)
        {
            Nome_Relatorio = Nome_Relatorio.RemoverCaracteres().Replace(" ", "_");
            string vFilePath = "";
            string vURL_Relatorios = "";

            if ((Utils.Parametros.pubTerminal == null ? "" : Utils.Parametros.pubTerminal) != "")
            {
                vFilePath = TCN_CadParamGer.BuscaVlString("PATH_RELATORIO", Utils.Parametros.pubTerminal, null);
                vURL_Relatorios = TCN_CadParamGer.BuscaVlString("URL_RELATORIOS", Utils.Parametros.pubTerminal, null);
            }
            else
            {
                vFilePath = Utils.Parametros.pubPathAliance.Trim();
                vURL_Relatorios = Utils.Parametros.pubPathAliance.Trim();
            }

            if (!string.IsNullOrEmpty(vFilePath))
                if (!vFilePath.EndsWith("\\"))
                    vFilePath += "\\";


            if (!File.Exists(vFilePath + Nome_Relatorio + ".rst"))
            {
                //CRIA O MODELO
                if (!(System.IO.File.Exists(vFilePath + "Modelo.rst")) && (vURL_Relatorios != ""))
                {
                    //tentar baixar da internet
                    try
                    {
                        System.Net.WebClient www = new System.Net.WebClient();
                        www.BaseAddress = vURL_Relatorios;
                        byte[] buff = new byte[0];
                        buff = www.DownloadData(vURL_Relatorios + "Modelo.rst");

                        System.IO.FileInfo fInfo = new System.IO.FileInfo(vFilePath + "Modelo.rst");
                        System.IO.FileStream arq = fInfo.Create();

                        arq.Write(buff, 0, buff.Length);
                        arq.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        throw new Exception("Ocorreu um erro na tentativa de efetuar DOWNLOAD do relatorio de Modelo do Site da Tecnoaliance, Contacte o suporte /n" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro: " + ex.Message.Trim());
                    }
                }

                return GeraArquivoRelatorio(Nome_Relatorio + ".rst", vFilePath);
            }

            return false;
        }

        private static bool GeraArquivoRelatorio(string Nome_Relatorio, string path)
        {
            int i;
            FileStream fin;
            FileStream fout;

            try
            {
                // ABRE O ARQUIV PARA ABRIR
                try
                {
                    fin = new FileStream(path + "Modelo.rst", FileMode.Open);
                }
                catch
                { return false; }

                // ABRE O ARQUIVO
                try
                {
                    fout = new FileStream(path + Nome_Relatorio, FileMode.Create);
                }
                catch
                { return false; }
            }
            catch
            { return false; }

            // Copia o arquivo
            try
            {
                do
                {
                    i = fin.ReadByte();
                    if (i != -1) fout.WriteByte((byte)i);
                } while (i != -1);
            }
            catch
            { }

            fin.Close();
            fout.Close();

            return true;
        }
    }
}
