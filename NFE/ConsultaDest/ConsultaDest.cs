using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace srvNFE.ConsultaDest
{
    public class TConsultaDest
    {
        private static XmlNode ConectarWebService(XmlNode cceDadosMsg,
                                                  TRegistro_CfgNfe rCfgNfe)
        {
            //Ambiente Nacional
            br.gov.fazenda.nfe.ConsultaDest.NFeConsultaDest consulta = new srvNFE.br.gov.fazenda.nfe.ConsultaDest.NFeConsultaDest();
            consulta.nfeCabecMsgValue = new srvNFE.br.gov.fazenda.nfe.ConsultaDest.nfeCabecMsg()
            {
                cUF = rCfgNfe.Cd_uf_empresa,
                versaoDados = rCfgNfe.Cd_versaocondest
            };
            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
            return consulta.nfeConsultaNFDest(cceDadosMsg);
        }

        public static string ConsultaNFDest(TRegistro_CfgNfe rCfgNfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<consNFeDest xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaocondest.Trim() + "\">\n");
            //Ambiente
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            //Serviço Solicitado
            xml.Append("<xServ>CONSULTAR NFE DEST</xServ>\n");
            //CNPJ Destinatario
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            //Indicador de NFe
            xml.Append("<indNFe>");
            xml.Append("0");
            xml.Append("</indNFe>\n");
            //Indicador de Emissor
            xml.Append("<indEmi>");
            xml.Append("0");
            xml.Append("</indEmi>\n");
            //NSU
            xml.Append("<ultNSU>");
            xml.Append("0");
            xml.Append("</ultNSU>\n");
            xml.Append("</consNFeDest>\n");

            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "consNFeDest_v" + rCfgNfe.Cd_versaocondest.Trim() + ".xsd",
                                                         "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
                //Tratar retorno
                if (retorno != null)
                {
                    if (retorno["cStat"].InnerText.Trim().Equals("128"))
                    {
                        if (retorno["retEvento"]["infEvento"]["cStat"].InnerText.Trim().Equals("135"))
                        {
                            //rEvento.St_registro = "T";
                            //try
                            //{
                            //    rEvento.Nr_protocolo = decimal.Parse(retorno["retEvento"]["infEvento"]["nProt"].InnerText);
                            //}
                            //catch { }
                            //CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                            return string.Empty;
                        }
                        else
                            return retorno["retEvento"]["infEvento"]["xMotivo"].InnerText;
                    }
                    else
                        return retorno["xMotivo"].InnerText;
                }
                else
                    throw new Exception("Ocorreu um erro ao enviar EVENTO para receita.");
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
