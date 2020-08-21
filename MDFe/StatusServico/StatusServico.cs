using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.StatusServico
{
    public class TStatusServico
    {
        private static XmlNode ConectarWebService(XmlNode mdfeDadosMsg, TRegistro_CfgMDFe rCfgMDFe)
        {
            switch (rCfgMDFe.rEmp.rEndereco.Cd_uf.Trim())
            {
                case ("41"):
                    {
                        if (rCfgMDFe.Tp_ambiente.Trim().Equals("1"))//Produção
                        {
                            br.gov.rs.svrs.mdfe.Status.MDFeStatusServico mdfe = new MDFe.br.gov.rs.svrs.mdfe.Status.MDFeStatusServico();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.Status.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeStatusServicoMDF(mdfeDadosMsg);
                        }
                        else//Homologação
                        {
                            br.gov.rs.svrs.mdfe.homolog.Status.MDFeStatusServico mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.Status.MDFeStatusServico();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.Status.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeStatusServicoMDF(mdfeDadosMsg);
                        }
                    }
                default: return null;
            }
        }
                                                  
        public static string StatusServico(TRegistro_CfgMDFe rCfgMDFe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<consStatServMDFe versao=\"" + rCfgMDFe.Cd_versaomdfe.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/mdfe\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgMDFe.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("STATUS");
            xml.Append("</xServ>");
            xml.Append("</consStatServMDFe>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgMDFe.Path_schemas.Trim().SeparadorDiretorio() + "consStatServMDFe_v" + rCfgMDFe.Cd_versaomdfe.Trim() + ".xsd",
                                                         "MDFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMDFe);
                //Tratar retorno
                return retorno["cStat"].InnerText;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
