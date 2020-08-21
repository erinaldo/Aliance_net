using System;
using System.Text;
using System.Xml;
using Utils;

namespace NFCe.ConsultaChave
{
    public class TConsultaChave
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg,
                                                  string Tp_ambiente,
                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfce.ConsultaChave.NfeConsulta3 nfce = new br.gov.pr.fazenda.nfce.ConsultaChave.NfeConsulta3();
                                nfce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfce.ConsultaChave.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeConsultaNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.ConsultaChave4.NFeConsultaProtocolo4 nfce = new br.gov.pr.sefa.nfce.ConsultaChave4.NFeConsultaProtocolo4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeConsultaNF(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfce.homologacao.ConsultaChave.NfeConsulta3 nfe = new br.gov.pr.fazenda.nfce.homologacao.ConsultaChave.NfeConsulta3();
                                nfe.nfeCabecMsgValue = new NFCe.br.gov.pr.fazenda.nfce.homologacao.ConsultaChave.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeConsultaNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.ConsultaChave4.NFeConsultaProtocolo4 nfce = new br.gov.pr.sefa.nfce.homologacao.ConsultaChave4.NFeConsultaProtocolo4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeConsultaNF(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaChave(string Chave_acesso, string Tp_ambiente, CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consSitNFe versao=\"" + rCfgNfe.Cd_versaonfce.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
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
                                                         rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "consSitNFe_v" + rCfgNfe.Cd_versaonfce.Trim() + ".xsd",
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
                        retorno["cStat"].InnerText.Trim().Equals("110") ||
                        retorno["cStat"].InnerText.Trim().Equals("150"))
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
