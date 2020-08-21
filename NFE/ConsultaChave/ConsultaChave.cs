using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace srvNFE.ConsultaChave
{
    public class TConsultaChave
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg,
                                                  string Tp_ambiente,
                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case "31"://Minas Gerais
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                        else
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                    }
                case "41":
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.Url = "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                        else//Homologacao
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.Url = "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                    }
                case "50":
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                        else
                        {
                            br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4 nfe = new br.gov.ms.sefaz.nfe.ConsultaProt4.NFeConsultaProtocolo4();
                            nfe.Url = "https://hom.nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF(
                                new br.gov.ms.sefaz.nfe.ConsultaProt4.nfeResultMsg
                                {
                                    Any = new XmlNode[] { nfceDadosMsg }
                                }).Any[0];
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaChave(string Chave_acesso, string Tp_ambiente, CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consSitNFe versao=\"" + rCfgNfe.Cd_versao.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
            xml.Append("<tpAmb>");
            xml.Append(Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("CONSULTAR");
            xml.Append("</xServ>");
            xml.Append("<chNFe>");
            xml.Append(Chave_acesso.Trim());
            xml.Append("</chNFe>");
            xml.Append("</consSitNFe>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "consSitNFe_v" + rCfgNfe.Cd_versao.Trim() + ".xsd",
                                                         "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                //rCfgNfe.St_nfecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, Tp_ambiente, rCfgNfe);
                //Tratar retorno
                if (retorno != null)
                    if (retorno["cStat"].InnerText.Trim().Equals("100") ||
                        retorno["cStat"].InnerText.Trim().Equals("110"))
                        return retorno["protNFe"]["infProt"]["cStat"].InnerText + "|" +
                                retorno["protNFe"]["infProt"]["xMotivo"].InnerText + "|" +
                                retorno["protNFe"]["infProt"]["dhRecbto"].InnerText + "|" +
                                retorno["protNFe"]["infProt"]["nProt"].InnerText + "|" +
                                retorno["protNFe"]["infProt"]["digVal"].InnerText + "|" +
                                retorno["protNFe"]["infProt"]["verAplic"].InnerText;
                    else return string.Empty;
                else return string.Empty;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
