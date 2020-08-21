using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.Evento
{
    public class TEventoMDFe
    {
        private static XmlNode ConectarWebService(XmlNode evDadosMsg,
                                                  TRegistro_CfgMDFe rCfgMdfe)
        {
            switch (rCfgMdfe.rEmp.rEndereco.Cd_uf.Trim())
            {
                case ("41")://Parana
                    {
                        if (rCfgMdfe.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.rs.svrs.mdfe.RecEvento.MDFeRecepcaoEvento mdfe = new MDFe.br.gov.rs.svrs.mdfe.RecEvento.MDFeRecepcaoEvento();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.RecEvento.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeRecepcaoEvento(evDadosMsg);
                        }
                        else
                        {
                            br.gov.rs.svrs.mdfe.homolog.RecEvento.MDFeRecepcaoEvento mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.RecEvento.MDFeRecepcaoEvento();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.RecEvento.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeRecepcaoEvento(evDadosMsg);
                        }
                    }
                default: return null;
            }
        }
        
        public static string EnviarEvento(CamadaDados.Frota.TRegistro_MDFe_Evento rEvento,
                                          TRegistro_CfgMDFe rCfgMdfe)
        {
            decimal seqEvento = 1;
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("IC"))
            {
                object obj = new CamadaDados.Frota.TCD_MDFe_Evento().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rEvento.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_mdfe",
                                        vOperador = "=",
                                        vVL_Busca = rEvento.Id_mdfe.Value.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'T'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "b.tp_evento",
                                        vOperador = "=",
                                        vVL_Busca = "'IC'"
                                    }
                                }, "count(*)");
                if (obj != null)
                    seqEvento += decimal.Parse(obj.ToString());
            }
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<eventoMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
            xml.Append("<infEvento Id=\"ID" + rEvento.Cd_eventostr + rEvento.Chaveacesso.Trim() + seqEvento.ToString().FormatStringEsquerda(2, '0') + "\">");
            xml.Append("<cOrgao>");
            xml.Append(rCfgMdfe.rEmp.rEndereco.Cd_uf.Trim());
            xml.Append("</cOrgao>");
            xml.Append("<tpAmb>");
            xml.Append(rCfgMdfe.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<CNPJ>");
            xml.Append(rCfgMdfe.rEmp.rClifor.Nr_cgc.SoNumero());
            xml.Append("</CNPJ>");
            xml.Append("<chMDFe>");
            xml.Append(rEvento.Chaveacesso.Trim());
            xml.Append("</chMDFe>");
            xml.Append("<dhEvento>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            xml.Append("</dhEvento>");
            xml.Append("<tpEvento>");
            xml.Append(rEvento.Cd_eventostr);
            xml.Append("</tpEvento>");
            xml.Append("<nSeqEvento>");
            xml.Append(seqEvento.ToString());
            xml.Append("</nSeqEvento>");
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CA"))//Cancelamento
            {
                xml.Append("<detEvento versaoEvento=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
                xml.Append("<evCancMDFe>");
                xml.Append("<descEvento>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</descEvento>");
                xml.Append("<nProt>");
                xml.Append(rEvento.Nr_protocoloMDFe.FormatStringEsquerda(15, '0'));
                xml.Append("</nProt>");
                xml.Append("<xJust>");
                xml.Append(rEvento.Justificativa.RemoverCaracteres().SubstCaracteresEsp().Trim());
                xml.Append("</xJust>");
                xml.Append("</evCancMDFe>");
                xml.Append("</detEvento>");
            }
            else if (rEvento.Tp_evento.Trim().ToUpper().Equals("EC"))//Encerramento
            {
                xml.Append("<detEvento versaoEvento=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
                xml.Append("<evEncMDFe>");
                xml.Append("<descEvento>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</descEvento>");
                xml.Append("<nProt>");
                xml.Append(rEvento.Nr_protocoloMDFe.FormatStringEsquerda(15, '0'));
                xml.Append("</nProt>");
                xml.Append("<dtEnc>");
                xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-dd"));
                xml.Append("</dtEnc>");
                xml.Append("<cUF>");
                xml.Append(rEvento.Cd_ufEnc.Trim());
                xml.Append("</cUF>");
                xml.Append("<cMun>");
                xml.Append(rEvento.Cd_cidadeEnc.Trim());
                xml.Append("</cMun>");
                xml.Append("</evEncMDFe>");
                xml.Append("</detEvento>");
            }
            else if (rEvento.Tp_evento.Trim().ToUpper().Equals("IC"))//Inclusão Condutor
            {
                xml.Append("<detEvento versaoEvento=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
                xml.Append("<evIncCondutorMDFe>");
                xml.Append("<descEvento>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</descEvento>");
                xml.Append("<condutor>");
                xml.Append("<xNome>");
                xml.Append(rEvento.Nm_motorista.RemoverCaracteres().SubstCaracteresEsp());
                xml.Append("</xNome>");
                xml.Append("<CPF>");
                xml.Append(rEvento.Cpf_motorista.SoNumero());
                xml.Append("</CPF>");
                xml.Append("</condutor>");
                xml.Append("</evIncCondutorMDFe>");
                xml.Append("</detEvento>");
            }
            xml.Append("</infEvento>");
            xml.Append("</eventoMDFe>");

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgMdfe.Nr_certificado,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpEventoCTe,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                    rCfgMdfe.Path_schemas.SeparadorDiretorio() + "eventoMDFe_v" + rCfgMdfe.Cd_versaomdfe.Trim() + ".xsd", "MDFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMdfe);
            //Tratar retorno
            if (retorno != null)
            {
                if (retorno["infEvento"]["cStat"].InnerText.Trim().Equals("135"))
                {
                    rEvento.St_registro = "T";
                    try
                    {
                        rEvento.Nr_protocolo = retorno["infEvento"]["nProt"].InnerText;
                    }
                    catch { }
                    rEvento.Xml_evento = xmlassinado;
                    rEvento.Xml_retevent = retorno.OuterXml;
                    CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                    return string.Empty;
                }
                else
                    return retorno["infEvento"]["xMotivo"].InnerText;
            }
            else
                throw new Exception("Ocorreu um erro ao enviar EVENTO para receita.");
        }

        public static string EnviarEncerramento(CamadaDados.Frota.TRegistro_MDFe_Evento rEvento,
                                          TRegistro_CfgMDFe rCfgMdfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<eventoMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
            xml.Append("<infEvento Id=\"ID" + rEvento.Cd_eventostr + rEvento.Chaveacesso.Trim() + "01\">");
            xml.Append("<cOrgao>");
            xml.Append(rCfgMdfe.rEmp.rEndereco.Cd_uf.Trim());
            xml.Append("</cOrgao>");
            xml.Append("<tpAmb>");
            xml.Append(rCfgMdfe.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<CNPJ>");
            xml.Append(rCfgMdfe.rEmp.rClifor.Nr_cgc.SoNumero());
            xml.Append("</CNPJ>");
            xml.Append("<chMDFe>");
            xml.Append(rEvento.Chaveacesso.Trim());
            xml.Append("</chMDFe>");
            xml.Append("<dhEvento>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            xml.Append("</dhEvento>");
            xml.Append("<tpEvento>");
            xml.Append(rEvento.Cd_eventostr);
            xml.Append("</tpEvento>");
            xml.Append("<nSeqEvento>");
            xml.Append("1");
            xml.Append("</nSeqEvento>");            
            xml.Append("<detEvento versaoEvento=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
            xml.Append("<evEncMDFe>");
            xml.Append("<descEvento>");
            xml.Append(rEvento.Ds_evento.Trim());
            xml.Append("</descEvento>");
            xml.Append("<nProt>");
            xml.Append(rEvento.Nr_protocoloMDFe.FormatStringEsquerda(15, '0'));
            xml.Append("</nProt>");
            xml.Append("<dtEnc>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-dd"));
            xml.Append("</dtEnc>");
            xml.Append("<cUF>");
            xml.Append(rEvento.Cd_ufEnc.Trim());
            xml.Append("</cUF>");
            xml.Append("<cMun>");
            xml.Append(rEvento.Cd_cidadeEnc.Trim());
            xml.Append("</cMun>");
            xml.Append("</evEncMDFe>");
            xml.Append("</detEvento>");
            xml.Append("</infEvento>");
            xml.Append("</eventoMDFe>");

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgMdfe.Nr_certificado,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpEventoCTe,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                    rCfgMdfe.Path_schemas.SeparadorDiretorio() + "eventoMDFe_v" + rCfgMdfe.Cd_versaomdfe.Trim() + ".xsd", "MDFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMdfe);
            //Tratar retorno
            if (retorno != null)
            {
                if (retorno["infEvento"]["cStat"].InnerText.Trim().Equals("135"))
                {
                    rEvento.St_registro = "T";
                    try
                    {
                        rEvento.Nr_protocolo = retorno["infEvento"]["nProt"].InnerText;
                    }
                    catch { }
                    if (rEvento.Id_mdfe.HasValue)//Somente MDF-e existente no sistema
                    {
                        rEvento.Xml_evento = xmlassinado;
                        rEvento.Xml_retevent = retorno.OuterXml;
                        CamadaNegocio.Frota.TCN_MDFe_Evento.Gravar(rEvento, null);
                    }
                    return string.Empty;
                }
                else
                    return retorno["infEvento"]["xMotivo"].InnerText;
            }
            else
                throw new Exception("Ocorreu um erro ao enviar EVENTO para receita.");
        }
    }
}
