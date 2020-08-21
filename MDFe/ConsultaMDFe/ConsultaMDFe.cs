using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.ConsultaMDFe
{
    public class TConsultaMDFe
    {
        private static XmlNode ConectarWebService(XmlNode mdfeDadosMsg,
                                                  string Tp_ambiente,
                                                  TRegistro_CfgMDFe rCfgMdfe)
        {
            switch (rCfgMdfe.rEmp.rEndereco.Cd_uf.Trim())
            {
                case "41":
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.rs.svrs.mdfe.Consulta.MDFeConsulta mdfe = new MDFe.br.gov.rs.svrs.mdfe.Consulta.MDFeConsulta();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.Consulta.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeConsultaMDF(mdfeDadosMsg);
                        }
                        else//Homologacao
                        {
                            br.gov.rs.svrs.mdfe.homolog.Consulta.MDFeConsulta mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.Consulta.MDFeConsulta();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.Consulta.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeConsultaMDF(mdfeDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaChave(string Chave_acesso, string Tp_ambiente, TRegistro_CfgMDFe rCfgMdfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consSitMDFe versao=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/mdfe\">");
            xml.Append("<tpAmb>");
            xml.Append(Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("CONSULTAR");
            xml.Append("</xServ>");
            xml.Append("<chMDFe>");
            xml.Append(Chave_acesso.Trim());
            xml.Append("</chMDFe>");
            xml.Append("</consSitMDFe>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgMdfe.Path_schemas.Trim().SeparadorDiretorio() + "consSitMDFe_v" + rCfgMdfe.Cd_versaomdfe.Trim() + ".xsd",
                                                         "MDFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                //rCfgNfe.St_nfecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, Tp_ambiente, rCfgMdfe);
                //Tratar retorno
                if (retorno != null)
                    if (retorno["cStat"].InnerText.Trim().Equals("100") ||
                        retorno["cStat"].InnerText.Trim().Equals("132"))
                        return retorno["protMDFe"]["infProt"]["cStat"].InnerText + "|" +
                                retorno["protMDFe"]["infProt"]["xMotivo"].InnerText + "|" +
                                retorno["protMDFe"]["infProt"]["dhRecbto"].InnerText + "|" +
                                retorno["protMDFe"]["infProt"]["nProt"].InnerText + "|" +
                                retorno["protMDFe"]["infProt"]["digVal"].InnerText + "|" +
                                retorno["protMDFe"]["infProt"]["verAplic"].InnerText;
                    else return string.Empty;
                else return string.Empty;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
