using System;
using CamadaDados.Consulta.Cadastro;
using System.Windows.Forms;
using CamadaNegocio.Consulta.Cadastro;
using CamadaDados.WS_RDC;
using Utils;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FormRelPadrao
{
    public class AtualizarRDC
    {
        public static void GravarRDC(TRegistro_Cad_Report Reg_Report, CamadaDados.WS_RDC.TList_Cad_ParamClasse lCad_Param, string ST_RDC)
        {
            //CARREGA O OBJECT DO WS
            TRegistro_Cad_RDC Reg_RDC = new TRegistro_Cad_RDC();
            Reg_RDC.ID_RDC = Reg_Report.ID_RDC;
            Reg_RDC.Modulo = Reg_Report.Modulo;
            Reg_RDC.Ident = Reg_Report.Ident;
            Reg_RDC.NM_Classe = Reg_Report.NM_Classe;
            Reg_RDC.Versao = Reg_Report.Versao;
            Reg_RDC.Code_Report = Reg_Report.Code_Report;
            Reg_RDC.ST_RDC = ST_RDC;
            Reg_RDC.DS_RDC = Reg_Report.DS_Report;

            //A LISTA DE DTS
            TList_Cad_DataSource lDTS = new TList_Cad_DataSource();

            if (Reg_Report.lConsulta != null)
                foreach (TRegistro_Cad_Consulta reg_Consulta in Reg_Report.lConsulta)
                {
                    TRegistro_Cad_DataSource Reg_DTS = new TRegistro_Cad_DataSource();

                    Reg_DTS.DS_DataSource = reg_Consulta.DS_Consulta;
                    Reg_DTS.DS_SQL = reg_Consulta.DS_SQL;
                    Reg_DTS.ID_DataSource = reg_Consulta.ID_Consulta;

                    CamadaDados.Consulta.Cadastro.TList_Cad_ParamClasse listParam = TCN_Cad_ParamClasse.BuscaParamClasseSQLString(Reg_DTS.DS_SQL);

                    //CARREGA A LISTA DE PARAMETROS
                    CamadaDados.WS_RDC.TList_Cad_ParamClasse lReg_ParamRDCL = new CamadaDados.WS_RDC.TList_Cad_ParamClasse();

                    if (listParam != null)
                        foreach (CamadaDados.Consulta.Cadastro.TRegistro_Cad_ParamClasse reg_Param in listParam)
                        {
                            CamadaDados.WS_RDC.TRegistro_Cad_ParamClasse RegParamRDC = new CamadaDados.WS_RDC.TRegistro_Cad_ParamClasse();

                            RegParamRDC.CodigoCMP = reg_Param.CodigoCMP;
                            RegParamRDC.CondicaoBusca = reg_Param.CondicaoBusca;
                            RegParamRDC.NM_CampoFormat = reg_Param.NM_CampoFormat;
                            RegParamRDC.NM_Classe = reg_Param.NM_Classe;
                            RegParamRDC.NM_DLL = reg_Param.NM_DLL;
                            RegParamRDC.NM_Param = reg_Param.NM_Param;
                            RegParamRDC.NomeCMP = reg_Param.NomeCMP;
                            RegParamRDC.RadioCheckGroup = reg_Param.RadioCheckGroup;
                            RegParamRDC.St_Null = reg_Param.St_Null;
                            RegParamRDC.St_Obrigatorio = reg_Param.St_Obrigatorio;
                            RegParamRDC.TP_Dado = reg_Param.TP_Dado;

                            lReg_ParamRDCL.Add(RegParamRDC);
                        }

                    Reg_DTS.lCad_ParamClasse = lReg_ParamRDCL;

                    lDTS.Add(Reg_DTS);
                }

            //ADD A LISTA DO REGISTRO
            Reg_RDC.lCad_DataSource = lDTS;
            //GRAVA E FECHA A CONEXÃO COM O WS
            string result = ServiceRest.DataService.GravarRDC(Reg_RDC);
            try
            {
                if (result.Replace("\"", string.Empty).Substring(0, 1).Equals("0"))
                {
                    Reg_Report.ID_RDC = result.Replace("\"", string.Empty).Split(new char[] { '|' })[1];
                    Reg_Report.Versao += 1;
                    TCN_Cad_Report.GravarReport(Reg_Report, null);
                    throw new Exception("Relatório publicado com sucesso!");
                }
                else throw new Exception(result);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static bool VerificarVersaoRDC(TRegistro_Cad_Report Reg_Report, bool MostrarMSG)
        {
            decimal versao = ServiceRest.DataService.VerificarVersaoRDC(Reg_Report);
            if (versao > Reg_Report.Versao)
            {
                if (Reg_Report.Versao > 0)
                {
                    if (MessageBox.Show("A versão " + versao + ".0 do relatório " + Reg_Report.DS_Report + " esta disponível, deseja atualizá-lo?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        AtualizarVersaoRDC(Reg_Report);
                        return true;
                    }
                    else return false;
                }
                else
                {
                    AtualizarVersaoRDC(Reg_Report);
                    return true;
                }
            }
            else
            {
                if (MostrarMSG)
                    throw new Exception("Não existe atualizações para este relatório!");
                else return false;
            }
        }

        public static void AtualizarVersaoRDC(TRegistro_Cad_Report Reg_Report)
        {
            TRegistro_Cad_RDC Reg_RDC = ServiceRest.DataService.BuscarRDCAtualizar(Reg_Report);
            if (Reg_RDC != null)
            {
                decimal id_report = Reg_Report.ID_Report;
                Reg_Report = ConvertRDCparaReport(Reg_RDC);
                if (Reg_Report.ID_Report == 0)
                    Reg_Report.ID_Report = id_report;
                //GRAVA O REPORT
                TCN_Cad_Report.GravarReportConsulta(Reg_Report, null);
            }
        }

        public static TRegistro_Cad_Report ConvertRDCparaReport(TRegistro_Cad_RDC reg_RDC)
        {
            TRegistro_Cad_Report Cad_Report = new TRegistro_Cad_Report();
            Cad_Report.ID_RDC = reg_RDC.ID_RDC.ToString();
            Cad_Report.Modulo = reg_RDC.Modulo;
            Cad_Report.Ident = reg_RDC.Ident;
            Cad_Report.NM_Classe = reg_RDC.NM_Classe;
            Cad_Report.Versao = reg_RDC.Versao;
            Cad_Report.Code_Report = reg_RDC.Code_Report;
            Cad_Report.DS_Report = reg_RDC.DS_RDC;

            foreach (TRegistro_Cad_DataSource reg_DTS in reg_RDC.lCad_DataSource)
            {
                TRegistro_Cad_Consulta Cad_Consulta = new TRegistro_Cad_Consulta();
                Cad_Consulta.DS_Consulta = reg_DTS.DS_DataSource;
                Cad_Consulta.DS_SQL = reg_DTS.DS_SQL;
                Cad_Consulta.DT_Consulta = reg_DTS.DT_DataSource;
                Cad_Consulta.ID_Consulta = reg_DTS.ID_DataSource.ToString();

                //ADD OS PARAM DE BUSCA
                foreach (CamadaDados.WS_RDC.TRegistro_Cad_ParamClasse reg_Param in reg_DTS.lCad_ParamClasse)
                {
                    CamadaDados.Consulta.Cadastro.TRegistro_Cad_ParamClasse Cad_Param = new CamadaDados.Consulta.Cadastro.TRegistro_Cad_ParamClasse();

                    Cad_Param.CodigoCMP = reg_Param.CodigoCMP;
                    Cad_Param.CondicaoBusca = reg_Param.CondicaoBusca;
                    Cad_Param.NM_CampoFormat = reg_Param.NM_CampoFormat;
                    Cad_Param.NM_Classe = reg_Param.NM_Classe;
                    Cad_Param.NM_DLL = reg_Param.NM_DLL;
                    Cad_Param.NM_Param = reg_Param.NM_Param;
                    Cad_Param.NomeCMP = reg_Param.NomeCMP;
                    Cad_Param.RadioCheckGroup = reg_Param.RadioCheckGroup;
                    Cad_Param.St_Null = reg_Param.St_Null;
                    Cad_Param.St_Obrigatorio = reg_Param.St_Obrigatorio;
                    Cad_Param.TP_Dado = reg_Param.TP_Dado;

                    Cad_Consulta.lParamClasse.Add(Cad_Param);
                }

                //ADD A CONSULTA
                Cad_Report.lConsulta.Add(Cad_Consulta);
            }

            return Cad_Report;
        }

        public static TRegistro_Cad_Consulta ConvertDTSparaConsulta(TRegistro_Cad_DataSource reg_DTS)
        {
            TRegistro_Cad_Consulta Cad_Consulta = new TRegistro_Cad_Consulta();
            Cad_Consulta.DS_Consulta = reg_DTS.DS_DataSource;
            Cad_Consulta.DS_SQL = reg_DTS.DS_SQL;
            Cad_Consulta.DT_Consulta = reg_DTS.DT_DataSource;
            Cad_Consulta.ID_Consulta = reg_DTS.ID_DataSource.ToString();

            return Cad_Consulta;
        }

        public static TRegistro_Cad_DataSource ConvertConsultaparaDTS(TRegistro_Cad_Consulta Cad_Consulta)
        {
            TRegistro_Cad_DataSource reg_DTS = new TRegistro_Cad_DataSource();
            reg_DTS.DS_DataSource = Cad_Consulta.DS_Consulta;
            reg_DTS.DS_SQL = Cad_Consulta.DS_SQL;
            reg_DTS.DT_DataSource = Cad_Consulta.DT_Consulta;
            reg_DTS.ID_DataSource = Cad_Consulta.ID_Consulta;

            return reg_DTS;
        }
    }
}
