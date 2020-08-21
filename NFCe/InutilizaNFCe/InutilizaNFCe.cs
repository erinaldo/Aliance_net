using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace NFCe.InutilizaNFCe
{
    public class TInutilizaNFCe
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg, TRegistro_CfgNfe rCfgNfce)
        {
            switch (rCfgNfce.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (rCfgNfce.Tp_ambiente_nfce.Trim().Equals("1"))//Producao
                        {
                            if (rCfgNfce.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.PRInutilizacao3.NfeInutilizacao3 nfce = new srvNFE.br.gov.pr.fazenda.nfe.PRInutilizacao3.NfeInutilizacao3();
                                nfce.Url = "https://nfce.fazenda.pr.gov.br/nfce/NFeInutilizacao3";
                                nfce.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.PRInutilizacao3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeInutilizacaoNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.Inutiliza4.NFeInutilizacao4 nfce = new br.gov.pr.sefa.nfce.Inutiliza4.NFeInutilizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeInutilizacaoNF(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfce.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.NfeInutilizacao3 nfe = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.NfeInutilizacao3();
                                nfe.Url = "https://homologacao.nfce.fazenda.pr.gov.br/nfce/NFeInutilizacao3";
                                nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRInutilizacao3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaonfce
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfe.nfeInutilizacaoNF(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.Inutiliza4.NFeInutilizacao4 nfce = new br.gov.pr.sefa.nfce.homologacao.Inutiliza4.NFeInutilizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeInutilizacaoNF(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static string InutilizarNFCe(string Cd_uf,
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
            srvNFE.ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<inutNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaonfce.Trim() + "\">\n");
            xml.Append("<infInut Id=\"ID" + Cd_uf.FormatStringEsquerda(2, '0') +
                        Ano.FormatStringEsquerda(2, '0') +
                        Cnpj.SoNumero().FormatStringEsquerda(14, '0') +
                        Cd_modelo.FormatStringEsquerda(2, '0') +
                        Nr_serie.FormatStringEsquerda(3, '0') +
                        Nfe_inicial.ToString().FormatStringEsquerda(9, '0') +
                        nfe_final.ToString().FormatStringEsquerda(9, '0') + "\">\n");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente_nfce);
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
            xml.Append(Cnpj.SoNumero().FormatStringEsquerda(14, '0'));
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
            xml.Append(Justificativa.Trim().RemoverCaracteres().SubstCaracteresEsp());
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
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "inutNFe_v" + rCfgNfe.Cd_versaonfce.Trim() + ".xsd",
                                                     "NFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());

            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
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
