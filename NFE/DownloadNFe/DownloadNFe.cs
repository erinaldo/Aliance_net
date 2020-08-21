using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace srvNFE.DownloadNFe
{
    public class TDownloadNFe
    {
        private static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                   TRegistro_CfgNfe rCfgNfe)
        {
            br.gov.fazenda.nfe.DownloadNF.NfeDownloadNF nfe = new br.gov.fazenda.nfe.DownloadNF.NfeDownloadNF();
            nfe.nfeCabecMsgValue = new br.gov.fazenda.nfe.DownloadNF.nfeCabecMsg()
            {
                cUF = rCfgNfe.Cd_uf_empresa,
                versaoDados = rCfgNfe.Cd_versaocondest
            };
            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
            return nfe.nfeDownloadNF(nfeDadosMsg);
        }
       
        public static string DownloadXML(string Chave_acesso, 
                                         TRegistro_CfgNfe rCfgNfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<downloadNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaocondest.Trim() + "\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("DOWNLOAD NFE");
            xml.Append("</xServ>");
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>");
            xml.Append("<chNFe>");
            xml.Append(Chave_acesso.Trim());
            xml.Append("</chNFe>");
            xml.Append("</downloadNFe>");

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "downloadNFe_v" + rCfgNfe.Cd_versaocondest.Trim() + ".xsd",
                                                     "NFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            XmlNode retorno = ConectarWebService2(doc.DocumentElement, rCfgNfe);
            if (retorno != null)
                if (retorno["cStat"].InnerText.Trim().Equals("139"))
                    if (retorno["retNFe"]["cStat"].InnerText.Trim().Equals("140"))
                        return Compact_Data.Descompactar(Convert.FromBase64String(retorno["retNFe"]["procNFeGrupoZip"]["NFeZip"].InnerText));
                    else throw new Exception(retorno["retNFe"]["cStat"].InnerText.Trim() + "-" + retorno["retNFe"]["xMotivo"].InnerText.Trim());
                else
                    throw new Exception(retorno["cStat"].InnerText.Trim() + "-" + retorno["xMotivo"].InnerText.Trim());
            else
                throw new Exception("Erro executar WebService.");
        }
    }
}
