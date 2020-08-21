using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace srvNFE.InutilizarNFE
{
    public class InutilizarNFE2
    {
        private static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                   TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case ("31")://Minas Gerais
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.ms.sefaz.nfe.MSInutiliza4.NFeInutilizacao4 nfe = new br.gov.ms.sefaz.nfe.MSInutiliza4.NFeInutilizacao4();
                            nfe.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeInutilizacaoNF(
                                new br.gov.ms.sefaz.nfe.MSInutiliza4.nfeResultMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                        }
                        else
                        {
                            br.gov.ms.sefaz.nfe.hom.MSInutiliza4.NFeInutilizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSInutiliza4.NFeInutilizacao4();
                            nfe.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4";
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeInutilizacaoNF(
                                new br.gov.ms.sefaz.nfe.hom.MSInutiliza4.nfeResultMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                        }
                    }
                case ("35")://Sao Paulo
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.sp.fazenda.nfe.SPInutilizacao3.NfeInutilizacao2 nfe = new br.gov.sp.fazenda.nfe.SPInutilizacao3.NfeInutilizacao2();
                                nfe.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPInutilizacao3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF2(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.sp.fazenda.nfe.SPInutilizacao4.NFeInutilizacao4 nfe = new br.gov.sp.fazenda.nfe.SPInutilizacao4.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else return null;
                    }
                case ("41")://Parana
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfe.PRInutilizacao3.NfeInutilizacao3 nfe = new br.gov.pr.fazenda.nfe.PRInutilizacao3.NfeInutilizacao3();
                                nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.PRInutilizacao3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfe.PRInutilizacao4.NFeInutilizacao4 nfe = new br.gov.pr.sefa.nfe.PRInutilizacao4.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else
                        {
                            if(rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.NfeInutilizacao3 nfe = new br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.NfeInutilizacao3();
                                nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.nfeCabecMsg
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfe.homologacao.PRInutilizacao41.NFeInutilizacao4 nfe = new br.gov.pr.sefa.nfe.homologacao.PRInutilizacao41.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                    }
                case ("42")://Santa Catarina
                    {
                        if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Produção
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2 nfe = new br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2();
                                nfe.Url = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx";
                                nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSInutilizacao2.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF2(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.rs.svrs.nfe.Inutilizacao4.NFeInutilizacao4 nfe = new br.gov.rs.svrs.nfe.Inutilizacao4.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2 nfe = new br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2();
                            nfe.Url = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx";
                            nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSInutilizacao2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeInutilizacaoNF2(nfeDadosMsg);
                        }
                    }
                case ("43")://Rio Grande do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2 nfe = new br.gov.rs.sefaz.nfe.RSInutilizacao2.NfeInutilizacao2();
                                nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSInutilizacao2.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF2(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.rs.sefazrs.nfe.RSInutilizacao4.NFeInutilizacao4 nfe = new br.gov.rs.sefazrs.nfe.RSInutilizacao4.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else return null;
                    }
                case ("50")://Mato Grosso do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.ms.sefaz.nfe.MSInutiliza4.NFeInutilizacao4 nfe = new br.gov.ms.sefaz.nfe.MSInutiliza4.NFeInutilizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeInutilizacaoNF(
                                new br.gov.ms.sefaz.nfe.MSInutiliza4.nfeResultMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                        }
                        else
                        {
                            br.gov.ms.sefaz.nfe.hom.MSInutiliza4.NFeInutilizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSInutiliza4.NFeInutilizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeInutilizacaoNF(
                                new br.gov.ms.sefaz.nfe.hom.MSInutiliza4.nfeResultMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                        }
                    }
                case ("51")://Mato Grosso
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.mt.sefaz.nfe.MTInutilizacao2.NfeInutilizacao2 nfe = new br.gov.mt.sefaz.nfe.MTInutilizacao2.NfeInutilizacao2();
                                nfe.nfeCabecMsgValue = new br.gov.mt.sefaz.nfe.MTInutilizacao2.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF2(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.mt.sefaz.nfe.MTInutilizacao4.NfeInutilizacao4 nfe = new br.gov.mt.sefaz.nfe.MTInutilizacao4.NfeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else return null;
                    }
                case ("52")://Goias
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                            {
                                br.gov.go.sefaz.nfe.GOInutilizacao2.NfeInutilizacao2 nfeInutilizar = new br.gov.go.sefaz.nfe.GOInutilizacao2.NfeInutilizacao2();
                                nfeInutilizar.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GOInutilizacao2.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfeInutilizar.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfeInutilizar.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfeInutilizar.nfeInutilizacaoNF2(nfeDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.go.sefaz.nfe.GOInutilizacao4.NFeInutilizacao4 nfe = new br.gov.go.sefaz.nfe.GOInutilizacao4.NFeInutilizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfeDadosMsg);
                            }
                        }
                        else return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public static string InutilizarNfe2(string Cd_uf,
                                            string Cnpj,
                                            string Nr_serie,
                                            string Cd_modelo,
                                            string Ano,
                                            decimal Nfe_inicial,
                                            decimal nfe_final,
                                            string Justificativa,
                                            TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<inutNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versao.Trim() + "\">\n");
            xml.Append("<infInut Id=\"ID" + Cd_uf.FormatStringEsquerda(2, '0') +
                        Ano.FormatStringEsquerda(2, '0') +
                        Regex.Replace(Cnpj.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).FormatStringEsquerda(14, '0') +
                        Cd_modelo.FormatStringEsquerda(2, '0') +
                        Nr_serie.FormatStringEsquerda(3, '0') +
                        Nfe_inicial.ToString().FormatStringEsquerda(9, '0') +
                        nfe_final.ToString().FormatStringEsquerda(9, '0') + "\">\n");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            xml.Append("<xServ>");
            xml.Append("INUTILIZAR");
            xml.Append("</xServ>\n");
            xml.Append("<cUF>");
            xml.Append(Cd_uf.FormatStringEsquerda(2, '0'));
            xml.Append("</cUF>\n");
            xml.Append("<ano>");
            xml.Append(Ano.FormatStringEsquerda(2, '0'));
            xml.Append("</ano>\n");
            xml.Append("<CNPJ>");
            xml.Append(Regex.Replace(Cnpj.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).FormatStringEsquerda(14, '0'));
            xml.Append("</CNPJ>\n");
            xml.Append("<mod>");
            xml.Append(Cd_modelo.FormatStringEsquerda(2, '0'));
            xml.Append("</mod>\n");
            xml.Append("<serie>");
            xml.Append(Nr_serie.Trim());
            xml.Append("</serie>\n");
            xml.Append("<nNFIni>");
            xml.Append(Nfe_inicial.ToString());
            xml.Append("</nNFIni>\n");
            xml.Append("<nNFFin>");
            xml.Append(nfe_final.ToString());
            xml.Append("</nNFFin>\n");
            xml.Append("<xJust>");
            xml.Append(Regex.Replace(Justificativa.Trim().RemoverCaracteres(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
            xml.Append("</xJust>\n");
            xml.Append("</infInut>\n");
            xml.Append("</inutNFe>\n");
                                    
            //Assinar documento XML
            string xmlassinado = 
                new Utils.Assinatura.TAssinatura2(rCfgNfe.Nr_certificado_nfe,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpInutiliza,
                                                  xml.ToString()).Assinar();
            
            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "inutNFe_v" + rCfgNfe.Cd_versao.Trim() + ".xsd",
                                                     "NFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());

            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService2(doc.DocumentElement, rCfgNfe);
            if (retorno["infInut"]["cStat"].InnerText.Trim().Equals("102"))
            {
                //Gravar registro Inutilizacao
                try
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_SeqInutNFe.Gravar(
                        new TRegistro_SeqInutNFe()
                        {
                            Cd_empresa = rCfgNfe.Cd_empresa,
                            Nr_serie = Nr_serie.Trim(),
                            Cd_modelo = Cd_modelo.Trim(),
                            Nr_nfinicial = Nfe_inicial,
                            Nr_nffinal = nfe_final,
                            Ano = Convert.ToInt32(Ano),
                            Dh_processamento = DateTime.Parse(retorno["infInut"]["dhRecbto"].InnerText),
                            Nr_protocolo = decimal.Parse(retorno["infInut"]["nProt"].InnerText)
                        }, null);
                }
                catch { }
                return retorno["infInut"]["cStat"].InnerText.Trim() + " - " +
                        retorno["infInut"]["xMotivo"].InnerText.Trim();
            }
            else
                throw new Exception(retorno["infInut"]["cStat"].InnerText.Trim() + " - " +
                                    retorno["infInut"]["xMotivo"].InnerText.Trim());
        }
    }
}
