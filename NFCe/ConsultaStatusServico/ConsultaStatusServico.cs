using System;
using System.Text;
using System.Xml;
using Utils;

namespace NFCe.ConsultaStatusServico
{
    public class TConsultaStatusServico
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg,
                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (rCfgNfe.Tp_ambiente_nfce.Trim().Equals("1"))//Producao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.PRStatusServico3.NfeStatusServico3 nfce = new srvNFE.br.gov.pr.fazenda.nfe.PRStatusServico3.NfeStatusServico3();
                                nfce.Url = "https://nfce.fazenda.pr.gov.br/nfce/NFeStatusServico3";
                                nfce.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.PRStatusServico3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeStatusServicoNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.StatusServico4.NFeStatusServico4 nfce = new br.gov.pr.sefa.nfce.StatusServico4.NFeStatusServico4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeStatusServicoNF(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.NfeStatusServico3 nfe = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.NfeStatusServico3();
                                nfe.Url = "https://homologacao.nfce.fazenda.pr.gov.br/nfce/NFeStatusServico3";
                                nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeStatusServicoNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.StatusServico4.NFeStatusServico4 nfce = new br.gov.pr.sefa.nfce.homologacao.StatusServico4.NFeStatusServico4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeStatusServicoNF(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static string StatusServico(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consStatServ versao=\"" + rCfgNfe.Cd_versaonfce.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente_nfce.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<cUF>");
            xml.Append(rCfgNfe.Cd_uf_empresa);
            xml.Append("</cUF>");
            xml.Append("<xServ>");
            xml.Append("STATUS");
            xml.Append("</xServ>");
            xml.Append("</consStatServ>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "consStatServ_v" + rCfgNfe.Cd_versaonfce.Trim() + ".xsd",
                                                         "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                //rCfgNfe.St_nfecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
                //Tratar retorno
                return retorno["cStat"].InnerText;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
