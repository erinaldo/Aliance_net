using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.NFE;

namespace srvNFE.DistribuicaoDFe
{
    public class TDistribuicaoDFe
    {
        private static XmlNode ConectarWebService(XmlNode cceDadosMsg,
                                                  TRegistro_CfgNfe rCfgNfe)
        {
            //Ambiente Nacional
            br.gov.fazenda.nfe.NFeDistribuicaoDFe.NFeDistribuicaoDFe consulta = new br.gov.fazenda.nfe.NFeDistribuicaoDFe.NFeDistribuicaoDFe();
            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
            return consulta.nfeDistDFeInteresse(cceDadosMsg);
        }

        public static TList_ConsultaDest DistribuicaoDFe(TRegistro_CfgNfe rCfgNfe,
                                                         TRegistro_CadEmpresa rEmp,
                                                         string NSU,
                                                         string UltimoNSU,
                                                         string ChaveAcesso)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<distDFeInt xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.01\">\n");
            //Ambiente
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            //UF Autor
            xml.Append("<cUFAutor>");
            xml.Append(rEmp.rEndereco.Cd_uf);
            xml.Append("</cUFAutor>\n");
            //CNPJ Destinatario
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            if(!string.IsNullOrEmpty(NSU))
            {
                xml.Append("<consNSU>\n");
                xml.Append("<NSU>" + NSU.Trim() + "</NSU>\n");
                xml.Append("</consNSU>\n");
            }
            else if(!string.IsNullOrEmpty(ChaveAcesso) && ChaveAcesso.Trim().Length.Equals(44))
            {
                xml.Append("<consChNFe>\n");
                xml.Append("<chNFe>" + ChaveAcesso.Trim() + "</chNFe>\n");
                xml.Append("</consChNFe>\n");
            }
            else
            {
                xml.Append("<distNSU>\n");
                xml.Append("<ultNSU>" + (string.IsNullOrEmpty(UltimoNSU) ? "000000000000000": UltimoNSU.FormatStringEsquerda(15, '0')) + "</ultNSU>\n");
                xml.Append("</distNSU>\n");
            }
            xml.Append("</distDFeInt>\n");

            //Validar schema xml
            Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                        rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "distDFeInt_v" + rCfgNfe.Cd_versaocondest.Trim() + ".xsd",
                                                        "MDFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

            //Conectar Web Service
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
            //Tratar retorno
            if (retorno != null)
            {
                //para abrir o arquivo para o usuario
                if (retorno["cStat"].InnerText.Trim().Equals("138"))
                {
                    TList_ConsultaDest lRet = new TList_ConsultaDest();
                    foreach(XmlNode n in retorno["loteDistDFeInt"].ChildNodes)
                    {
                        TRegistro_ConsultaDest registro = new TRegistro_ConsultaDest();
                        registro.Cd_empresa = rEmp.Cd_empresa;
                        registro.Loginconsulta = Parametros.pubLogin;
                        registro.Dt_consulta = DateTime.Now;
                        registro.Nsu = decimal.Parse(n.Attributes.GetNamedItem("NSU").InnerText);
                        if (!string.IsNullOrWhiteSpace(ChaveAcesso))
                            registro.St_nfe = "1";
                        XmlDocument d = new XmlDocument();
                        d.LoadXml(Compact_Data.Descompactar(Convert.FromBase64String(n.InnerText)));
                        if(d.GetElementsByTagName("chNFe").Count > 0)
                            registro.chave_acesso = d.GetElementsByTagName("chNFe")[0].InnerText;
                        if (d.GetElementsByTagName("CNPJ").Count > 0)
                            registro.Cnpj_emitente = d.GetElementsByTagName("CNPJ")[0].InnerText;
                        if (d.GetElementsByTagName("xNome").Count > 0)
                            registro.Nm_emitente = d.GetElementsByTagName("xNome")[0].InnerText;
                        if (d.GetElementsByTagName("IE").Count > 0)
                            registro.Insc_Emitente = d.GetElementsByTagName("IE")[0].InnerText;
                        if (d.GetElementsByTagName("dhEmi").Count > 0)
                            registro.Dt_eminfe = DateTime.Parse(d.GetElementsByTagName("dhEmi")[0].InnerText);
                        if (d.GetElementsByTagName("tpNF").Count > 0)
                            registro.Tp_movimento = d.GetElementsByTagName("tpNF")[0].InnerText;
                        if (d.GetElementsByTagName("vNF").Count > 0)
                            registro.Vl_nfe = decimal.Parse(d.GetElementsByTagName("vNF")[0].InnerText, new System.Globalization.CultureInfo("en-US"));
                        if (d.GetElementsByTagName("digVal").Count > 0)
                            registro.digVal = d.GetElementsByTagName("digVal")[0].InnerText;
                        if (d.GetElementsByTagName("dhRecbto").Count > 0)
                            registro.Dh_recbto = DateTime.Parse(d.GetElementsByTagName("dhRecbto")[0].InnerText);
                        if (d.GetElementsByTagName("nProt").Count > 0)
                            registro.nProt = decimal.Parse(d.GetElementsByTagName("nProt")[0].InnerText);
                        if (d.GetElementsByTagName("cSitNFe").Count > 0)
                            registro.St_nfe = d.GetElementsByTagName("cSitNFe")[0].InnerText;
                        lRet.Add(registro);
                    }
                    return lRet;
                }
                else
                    throw new Exception(retorno["xMotivo"].InnerText);
            }
            else
                throw new Exception("Erro executar WebService.");
        }

        public static string DownloadXML(TRegistro_CfgNfe rCfgNfe,
                                         TRegistro_CadEmpresa rEmp,
                                         string Chave)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<distDFeInt xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.01\">\n");
            //Ambiente
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            //UF Autor
            xml.Append("<cUFAutor>");
            xml.Append(rEmp.rEndereco.Cd_uf);
            xml.Append("</cUFAutor>\n");
            //CNPJ Destinatario
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            xml.Append("<consChNFe>\n");
            xml.Append("<chNFe>" + Chave.Trim() + "</chNFe>\n");
            xml.Append("</consChNFe>\n");
            xml.Append("</distDFeInt>\n");

            //Validar schema xml
            Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                        rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "distDFeInt_v" + rCfgNfe.Cd_versaocondest.Trim() + ".xsd",
                                                        "MDFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

            //Conectar Web Service
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
            //Tratar retorno
            if (retorno != null)
            {
                //para abrir o arquivo para o usuario
                if (retorno["cStat"].InnerText.Trim().Equals("138"))
                {
                    if (retorno["loteDistDFeInt"].ChildNodes.Count > 0)
                        return Compact_Data.Descompactar(Convert.FromBase64String(retorno["loteDistDFeInt"].ChildNodes[0].InnerText));
                    else return string.Empty;
                }
                else
                    throw new Exception(retorno["xMotivo"].InnerText);
            }
            else
                throw new Exception("Erro executar WebService.");
        }
    }
}
