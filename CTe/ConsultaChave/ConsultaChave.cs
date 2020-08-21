using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace CTe.ConsultaChave
{
    public class TConsultaChave
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg,
                                                  string Tp_ambiente,
                                                  TRegistro_CfgFrota rCfgCte)
        {
            switch (rCfgCte.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            CTe.br.gov.pr.fazenda.cte.Consulta.CteConsulta cte = new CTe.br.gov.pr.fazenda.cte.Consulta.CteConsulta();
                            cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.Consulta.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteConsultaCT(nfceDadosMsg);
                        }
                        else//Homologacao
                        {
                            CTe.br.gov.pr.fazenda.cte.homologacao.Consulta.CteConsulta cte = new CTe.br.gov.pr.fazenda.cte.homologacao.Consulta.CteConsulta();
                            cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.Consulta.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteConsultaCT(nfceDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaChave(string Chave_acesso, string Tp_ambiente, TRegistro_CfgFrota rCfgCte)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consSitCTe versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/cte\">");
            xml.Append("<tpAmb>");
            xml.Append(Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("CONSULTAR");
            xml.Append("</xServ>");
            xml.Append("<chCTe>");
            xml.Append(Chave_acesso.Trim());
            xml.Append("</chCTe>");
            xml.Append("</consSitCTe>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgCte.Path_schemas.Trim().SeparadorDiretorio() + "consSitCTe_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                         "CTE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                //rCfgNfe.St_nfecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, Tp_ambiente, rCfgCte);
                //Tratar retorno
                if (retorno != null)
                    if (retorno["cStat"].InnerText.Trim().Equals("100") ||
                        retorno["cStat"].InnerText.Trim().Equals("110"))
                        return retorno["protCTe"]["infProt"]["cStat"].InnerText + "|" +
                                retorno["protCTe"]["infProt"]["xMotivo"].InnerText + "|" +
                                retorno["protCTe"]["infProt"]["dhRecbto"].InnerText + "|" +
                                retorno["protCTe"]["infProt"]["nProt"].InnerText + "|" +
                                retorno["protCTe"]["infProt"]["digVal"].InnerText + "|" +
                                retorno["protCTe"]["infProt"]["verAplic"].InnerText;
                    else return string.Empty;
                else return string.Empty;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
