using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace srvNFE.ConsultaNF
{
    public class TConsultaNFe2
    {
        public static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case ("31")://Minas Gerais
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.mg.fazenda.nfe.MGConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.mg.fazenda.nfe.MGConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.mg.fazenda.nfe.MGConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                case ("35")://Sao Paulo
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.sp.fazenda.nfe.SPConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.sp.fazenda.nfe.SPConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.sp.fazenda.nfe.SPConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                case ("41")://Parana
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.pr.fazenda.nfe2.PRConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.pr.fazenda.nfe2.PRConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe2.PRConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else
                        {
                            br.gov.pr.fazenda.nfe2.PRConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.pr.fazenda.nfe2.PRConsultaNF2.NfeConsulta2();
                            nfe.Url = "https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeConsulta2";
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe2.PRConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                    }
                case ("43")://Rio Grande do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.rs.sefaz.nfe.RSConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.rs.sefaz.nfe.RSConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.rs.sefaz.nfe.RSConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                case ("50")://Mato Grosso do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.ms.fazenda.nfe.MSConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.ms.fazenda.nfe.MSConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.ms.fazenda.nfe.MSConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                case ("51")://Mato Grosso
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.mt.sefaz.nfe.MTConsultaNF2.NfeConsulta2 nfe = new srvNFE.br.gov.mt.sefaz.nfe.MTConsultaNF2.NfeConsulta2();
                            nfe.nfeCabecMsgValue = new srvNFE.br.gov.mt.sefaz.nfe.MTConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                case ("52")://Goias
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.go.sefaz.nfe.GOConsultaNF2.NfeConsulta2 nfeInutilizar = new srvNFE.br.gov.go.sefaz.nfe.GOConsultaNF2.NfeConsulta2();
                            nfeInutilizar.nfeCabecMsgValue = new srvNFE.br.gov.go.sefaz.nfe.GOConsultaNF2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfeInutilizar.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeInutilizar.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeInutilizar.nfeConsultaNF2(nfeDadosMsg);
                        }
                        else return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public static string ConsultaNFe(string Chave_acesso,
                                         CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            XmlDocument documento = new XmlDocument();
            documento.AppendChild(documento.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlNode root = documento.CreateElement("conSitNFe");
            XmlAttribute atr = documento.CreateAttribute("xmlns");
            atr.Value = "http://www.portalfiscal.inf.br/nfe";
            root.Attributes.Append(atr);
            atr = documento.CreateAttribute("versao");
            atr.Value = rCfgNfe.Cd_versao;
            root.Attributes.Append(atr);

            XmlNode filho = documento.CreateElement("tpAmb");
            filho.InnerText = rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2";
            root.AppendChild(filho);

            filho = documento.CreateElement("xServ");
            filho.InnerText = "CONSULTAR";
            root.AppendChild(filho);

            filho = documento.CreateElement("chNFe");
            filho.InnerText = Chave_acesso.Trim().FormatSringEsquerda(44, '0');
            root.AppendChild(filho);

            documento.AppendChild(root);

            //Validar schema xml
            Utils.ValidaSchema.ValidaXML2.validaXML(documento.InnerXml,
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "consSitNFe_v2.00.xsd",
                                                     false);
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                return Utils.ValidaSchema.ValidaXML2.Retorno;

            //Conectar Web Service
            XmlNode retorno = ConectarWebService2(root, rCfgNfe);

            //Tratar Retorno
            if (retorno != null)
                return retorno["cStat"].InnerText.Trim() + " - " +
                        retorno["xMotivo"].InnerText.Trim();
            else
                throw new Exception("Erro acessar Serviços da Receita Estadual do " + rCfgNfe.Cd_uf_empresa.Trim());
        }
    }
}
