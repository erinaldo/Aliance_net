using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace NFCe.EventoNFCe
{
    public class TEventoNFCe
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
                                br.gov.pr.fazenda.nfce.Evento.RecepcaoEvento nfce = new br.gov.pr.fazenda.nfce.Evento.RecepcaoEvento();
                                nfce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfce.Evento.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaoEvento
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRecepcaoEvento(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.Evento4.NFeRecepcaoEvento4 nfce = new br.gov.pr.sefa.nfce.Evento4.NFeRecepcaoEvento4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRecepcaoEventoNF(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfce.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfce.homologacao.Evento.RecepcaoEvento nfce = new br.gov.pr.fazenda.nfce.homologacao.Evento.RecepcaoEvento();
                                nfce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfce.homologacao.Evento.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaoEvento
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRecepcaoEvento(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.Evento4.NFeRecepcaoEvento4 nfce = new br.gov.pr.sefa.nfce.homologacao.Evento4.NFeRecepcaoEvento4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRecepcaoEventoNF(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static string EnviarEvento(CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe rEvento,
                                          TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            srvNFE.ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaoEvento + "\">\n");
            xml.Append("<idLote>");
            xml.Append(rEvento.Id_eventostr);
            xml.Append("</idLote>\n");
            #region Grupo Evento
            xml.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaoEvento + "\">\n");
            #region Grupo infEvento
            xml.Append("<infEvento Id=\"ID" + rEvento.Cd_eventostr + rEvento.Chave_acesso_nfce.Trim() + "01\">\n");
            xml.Append("<cOrgao>");
            xml.Append(rCfgNfe.Cd_uf_empresa.Trim());
            xml.Append("</cOrgao>\n");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente_nfce);
            xml.Append("</tpAmb>\n");
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            xml.Append("<chNFe>");
            xml.Append(rEvento.Chave_acesso_nfce.Trim());
            xml.Append("</chNFe>\n");
            xml.Append("<dhEvento>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-dd") + "T" + rEvento.Dt_evento.Value.ToString("HH:mm:ss") +
                (TimeZoneInfo.Local.IsDaylightSavingTime(rEvento.Dt_evento.Value) ? "-02:00" : "-03:00"));
            xml.Append("</dhEvento>\n");
            xml.Append("<tpEvento>");
            xml.Append(rEvento.Cd_eventostr);
            xml.Append("</tpEvento>\n");
            xml.Append("<nSeqEvento>");
            xml.Append("1");
            xml.Append("</nSeqEvento>\n");
            xml.Append("<verEvento>");
            xml.Append(rCfgNfe.Cd_versaoEvento.Trim());
            xml.Append("</verEvento>\n");
            #region Grupo detEvento
            xml.Append("<detEvento versao=\"" + rCfgNfe.Cd_versaoEvento + "\">\n");
            xml.Append("<descEvento>");
            xml.Append(rEvento.Ds_evento.Trim());
            xml.Append("</descEvento>\n");           
            xml.Append("<nProt>");
            xml.Append(rEvento.Nr_protocoloNFCe);
            xml.Append("</nProt>\n");
            xml.Append("<xJust>");
            xml.Append(rEvento.Justificativa.Trim());
            xml.Append("</xJust>\n");
            xml.Append("</detEvento>\n");
            #endregion
            xml.Append("</infEvento>\n");
            #endregion
            xml.Append("</evento>\n");
            #endregion
            xml.Append("</envEvento>\n");

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgNfe.Nr_certificado_nfe,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpCCe,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() +
                                                     "envEventoCancNFe_v" + rCfgNfe.Cd_versaoEvento.Trim() +
                                                     ".xsd",
                                                     "NFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
            //Tratar retorno
            if (retorno != null)
            {
                if (retorno["cStat"].InnerText.Trim().Equals("128"))
                {
                    if (retorno["retEvento"]["infEvento"]["cStat"].InnerText.Trim().Equals("135"))
                    {
                        rEvento.St_registro = "T";
                        try
                        {
                            rEvento.Nr_protocolo = decimal.Parse(retorno["retEvento"]["infEvento"]["nProt"].InnerText);
                        }
                        catch { }
                        rEvento.Xml_evento = xmlassinado;
                        rEvento.Xml_retevento = retorno.InnerXml;
                        CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Gravar(rEvento, null);
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
    }
}
