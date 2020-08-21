using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.NFE;

namespace srvNFE.Evento
{
    public class TEventoNFe
    {
        private static XmlNode ConectarWebService(XmlNode cceDadosMsg,
                                                  string Tp_evento,
                                                  TRegistro_CfgNfe rCfgNfe)
        {
            if (Tp_evento.Trim().ToUpper().Equals("MF"))//Manifesto
            {
                //Ambiente Nacional
                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                {
                    br.gov.fazenda.nfe.RecepcaoEvento.RecepcaoEvento evento = new br.gov.fazenda.nfe.RecepcaoEvento.RecepcaoEvento();
                    evento.nfeCabecMsgValue = new br.gov.fazenda.nfe.RecepcaoEvento.nfeCabecMsg()
                    {
                        cUF = "91",
                        versaoDados = rCfgNfe.Cd_versaoEvento
                    };
                    evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                    evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                    return evento.nfeRecepcaoEvento(cceDadosMsg);
                }
                else//4.00
                {
                    br.gov.fazenda.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 evento = new br.gov.fazenda.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                    evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                    evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                    return evento.nfeRecepcaoEventoNF(cceDadosMsg);
                }
            }
            else if (Tp_evento.Trim().ToUpper().Equals("CA") && rCfgNfe.St_nfecontingencia)
            {
                if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.RecepcaoEvento.RecepcaoEvento evento = new br.gov.fazenda.svc.RecepcaoEvento.RecepcaoEvento();
                            evento.nfeCabecMsgValue = new br.gov.fazenda.svc.RecepcaoEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoEvento
                            };
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.RecepcaoEvento4.NFeRecepcaoEvento4 evento = new br.gov.fazenda.svc.RecepcaoEvento4.NFeRecepcaoEvento4();
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                    }
                    else//Virtual Rio Grande do Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento evento = new br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento();
                            evento.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSRecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoEvento
                            };
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else
                        {
                            br.gov.rs.svrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 evento = new br.gov.rs.svrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                    }
                }
                else//Homologacao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.hom.ANRecEvento.RecepcaoEvento evento = new br.gov.fazenda.svc.hom.ANRecEvento.RecepcaoEvento();
                            evento.nfeCabecMsgValue = new br.gov.fazenda.svc.hom.ANRecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoEvento
                            };
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.sefazvirtual.hom.RecepcaoEvento4.NFeRecepcaoEvento4 evento = new br.gov.fazenda.sefazvirtual.hom.RecepcaoEvento4.NFeRecepcaoEvento4();
                            evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return evento.nfeRecepcaoEvento(cceDadosMsg);
                        }
                    }
                    else//Virtual Rio Grande do Sul
                    {
                        br.gov.rs.sefazvirtual.nfe.homologacao.RSRecEvento.RecepcaoEvento evento = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRecEvento.RecepcaoEvento();
                        evento.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRecEvento.nfeCabecMsg()
                        {
                            cUF = rCfgNfe.Cd_uf_empresa,
                            versaoDados = rCfgNfe.Cd_versaoEvento
                        };
                        evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                        return evento.nfeRecepcaoEvento(cceDadosMsg);
                    }
                }
            }
            else
                switch (rCfgNfe.Cd_uf_empresa.Trim())
                {
                    case ("31")://Minas Gerais
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.ms.sefaz.nfe.MSEvento4.NFeRecepcaoEvento4 evento = new br.gov.ms.sefaz.nfe.MSEvento4.NFeRecepcaoEvento4();
                                evento.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4";
                                evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return evento.nfeRecepcaoEvento(
                                    new br.gov.ms.sefaz.nfe.MSEvento4.nfeResultMsg { Any = new XmlNode[] { cceDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSEvento4.NFeRecepcaoEvento4 evento = new br.gov.ms.sefaz.nfe.hom.MSEvento4.NFeRecepcaoEvento4();
                                evento.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4";
                                evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return evento.nfeRecepcaoEvento(
                                    new br.gov.ms.sefaz.nfe.hom.MSEvento4.nfeResultMsg { Any = new XmlNode[] { cceDadosMsg } }).Any[0];
                            }
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.sp.fazenda.nfe.SPRecepcao3.RecepcaoEvento cce = new br.gov.sp.fazenda.nfe.SPRecepcao3.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPRecepcao3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.sp.fazenda.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 evento = new br.gov.sp.fazenda.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return evento.nfeRecepcaoEvento(cceDadosMsg);
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
                                    br.gov.pr.fazenda.nfe.RecepcaoEvento.RecepcaoEvento cce = new br.gov.pr.fazenda.nfe.RecepcaoEvento.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.RecepcaoEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 cce = new br.gov.pr.sefa.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEventoNF(cceDadosMsg);
                                }
                            }
                            else//Homologacao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.pr.fazenda.nfe.homologacao.RecepcaoEvento.RecepcaoEvento cce = new br.gov.pr.fazenda.nfe.homologacao.RecepcaoEvento.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.homologacao.RecepcaoEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.homologacao.RecepcaoEvento4.NFeRecepcaoEvento4 cce = new br.gov.pr.sefa.nfe.homologacao.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEventoNF(cceDadosMsg);
                                }
                            }
                        }
                    case ("42")://Santa Catarina
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento cce = new br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento();
                                    cce.Url = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx";
                                    cce.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSRecEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.svrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 cce = new br.gov.rs.svrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                            }
                            else return null;
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento cce = new br.gov.rs.sefaz.nfe.RSRecEvento.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSRecEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.sefazrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 cce = new br.gov.rs.sefazrs.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                            }
                            else return null;
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.ms.sefaz.nfe.MSEvento4.NFeRecepcaoEvento4 evento = new br.gov.ms.sefaz.nfe.MSEvento4.NFeRecepcaoEvento4();
                                evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return evento.nfeRecepcaoEvento(
                                    new br.gov.ms.sefaz.nfe.MSEvento4.nfeResultMsg { Any = new XmlNode[] { cceDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSEvento4.NFeRecepcaoEvento4 evento = new br.gov.ms.sefaz.nfe.hom.MSEvento4.NFeRecepcaoEvento4();
                                evento.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                evento.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return evento.nfeRecepcaoEvento(
                                    new br.gov.ms.sefaz.nfe.hom.MSEvento4.nfeResultMsg { Any = new XmlNode[] { cceDadosMsg } }).Any[0];
                            }
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.mt.sefaz.nfe.MTRecEvento.RecepcaoEvento cce = new br.gov.mt.sefaz.nfe.MTRecEvento.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.mt.sefaz.nfe.MTRecEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.mt.sefaz.nfe.RecepcaoEvento4.RecepcaoEvento4 cce = new br.gov.mt.sefaz.nfe.RecepcaoEvento4.RecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
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
                                    br.gov.go.sefaz.nfe.GORecEvento.RecepcaoEvento cce = new br.gov.go.sefaz.nfe.GORecEvento.RecepcaoEvento();
                                    cce.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GORecEvento.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versaoEvento
                                    };
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.go.sefaz.nfe.RecepcaoEvento4.NFeRecepcaoEvento4 cce = new br.gov.go.sefaz.nfe.RecepcaoEvento4.NFeRecepcaoEvento4();
                                    cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return cce.nfeRecepcaoEvento(cceDadosMsg);
                                }
                            }
                            else return null;
                        }
                    default: { return null; }
                }
        }

        public static string EnviarEvento(TRegistro_EventoNFe rEvento,
                                          TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            decimal seqEvento = 1;
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CC"))
            {
                object obj = new TCD_EventoNFe().BuscarEscalar(
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
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = rEvento.Nr_lanctofiscalstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'T'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "d.tp_evento",
                                        vOperador = "=",
                                        vVL_Busca = "'CC'"
                                    }
                                }, "count(*)");
                if (obj != null)
                    seqEvento += decimal.Parse(obj.ToString());
            }
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + 
                rCfgNfe.Cd_versaoEvento + "\">\n");
            xml.Append("<idLote>");
            xml.Append(rEvento.Id_eventostr);
            xml.Append("</idLote>\n");
            #region Grupo Evento
            xml.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + 
                rCfgNfe.Cd_versaoEvento + "\">\n");
            #region Grupo infEvento
            xml.Append("<infEvento Id=\"ID" + rEvento.Cd_eventostr + rEvento.Chave_acesso_nfe.Trim() + seqEvento.ToString().FormatStringEsquerda(2, '0') + "\">\n");
            xml.Append("<cOrgao>");
            xml.Append(rEvento.Tp_evento.Trim().ToUpper().Equals("MF") ? "91" : rCfgNfe.Cd_uf_empresa.Trim());
            xml.Append("</cOrgao>\n");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            xml.Append("<chNFe>");
            xml.Append(rEvento.Chave_acesso_nfe.Trim());
            xml.Append("</chNFe>\n");
            xml.Append("<dhEvento>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            xml.Append("</dhEvento>\n");
            xml.Append("<tpEvento>");
            xml.Append(rEvento.Cd_eventostr);
            xml.Append("</tpEvento>\n");
            xml.Append("<nSeqEvento>");
            xml.Append(seqEvento.ToString());
            xml.Append("</nSeqEvento>\n");
            xml.Append("<verEvento>");
            xml.Append(rCfgNfe.Cd_versaoEvento);
            xml.Append("</verEvento>\n");
            #region Grupo detEvento
            xml.Append("<detEvento versao=\"" + rCfgNfe.Cd_versaoEvento + "\">\n");
            xml.Append("<descEvento>");
            xml.Append(rEvento.Descricao_evento.Trim());
            xml.Append("</descEvento>\n");
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CC"))//Carta Correcao
            {
                xml.Append("<xCorrecao>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</xCorrecao>\n");
                xml.Append("<xCondUso>");
                xml.Append(rCfgNfe.Ds_condusoCCe.Trim());
                xml.Append("</xCondUso>\n");
            }
            else if (rEvento.Tp_evento.Trim().ToUpper().Equals("CA"))//Cancelamento
            {
                xml.Append("<nProt>");
                xml.Append(rEvento.Nr_protocoloNfe);
                xml.Append("</nProt>\n");
                xml.Append("<xJust>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</xJust>\n");
            }
            else if(!string.IsNullOrEmpty(rEvento.Ds_evento))
            {
                xml.Append("<xJust>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</xJust>\n");
            }
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
                                                     (rEvento.Tp_evento.Trim().ToUpper().Equals("CC") ? 
                                                     "envCCe_v" + rCfgNfe.Cd_versaoEvento.Trim() :
                                                     rEvento.Tp_evento.Trim().ToUpper().Equals("CA") ?
                                                     "envEventoCancNFe_v" + rCfgNfe.Cd_versaoEvento.Trim() :
                                                     "envConfRecebto_v" + rCfgNfe.Cd_versaoEvento.Trim()) + 
                                                     ".xsd",
                                                     "NFE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CA"))
                rCfgNfe.St_nfecontingencia = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                                                        vNM_Campo = "a.nr_lanctofiscal",
                                                        vOperador = "=",
                                                        vVL_Busca = rEvento.Nr_lanctofiscalstr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_emissaonfe",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'1'"
                                                    }
                                                }, "1") != null;
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rEvento.Tp_evento, rCfgNfe);
            //Tratar retorno
            if (retorno != null)
            {
                if (retorno["cStat"].InnerText.Trim().Equals("128"))
                {
                    if (retorno["retEvento"]["infEvento"]["cStat"].InnerText.Trim().Equals("135") ||
                        retorno["retEvento"]["infEvento"]["cStat"].InnerText.Trim().Equals("136"))
                    {
                        rEvento.St_registro = "T";
                        try
                        {
                            rEvento.Nr_protocolo = decimal.Parse(retorno["retEvento"]["infEvento"]["nProt"].InnerText);
                        }
                        catch { }
                        rEvento.Xml_evento = xmlassinado;
                        rEvento.Xml_retevento = retorno.InnerXml;
                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
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
