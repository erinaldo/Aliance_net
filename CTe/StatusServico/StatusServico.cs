using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace CTe.StatusServico
{
    public class TStatusServico
    {
        private static XmlNode ConectarWebService(XmlNode cteDadosMsg,
                                                  TRegistro_CfgFrota rCfgCte)
        {
            if (rCfgCte.St_ctecontingencia)
            {
                if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-Sao Paulo
                    {
                        br.gov.sp.fazenda.nfe.SVCStatusServico.CteStatusServico cte = new CTe.br.gov.sp.fazenda.nfe.SVCStatusServico.CteStatusServico();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCStatusServico.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteStatusServicoCT(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.StatusServico.CteStatusServico cte = new CTe.br.gov.rs.sefaz.cte.StatusServico.CteStatusServico();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.StatusServico.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteStatusServicoCT(cteDadosMsg);
                    }
                    else return null;
                }
                else//Homologacao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-Sao Paulo
                    {
                        br.gov.sp.fazenda.nfe.homologacao.StatusServico.CteStatusServico cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.StatusServico.CteStatusServico();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.StatusServico.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteStatusServicoCT(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.homologacao.StatusServico.CteStatusServico cte = new CTe.br.gov.rs.sefaz.cte.homologacao.StatusServico.CteStatusServico();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.StatusServico.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteStatusServicoCT(cteDadosMsg);
                    }
                    else return null;
                }
            }
            else
                switch (rCfgCte.Cd_uf_empresa.Trim())
                {
                    case ("31")://Minas Gerais
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.mg.fazenda.cte.StatusServico.CteStatusServico cte = new CTe.br.gov.mg.fazenda.cte.StatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.mg.fazenda.cte.StatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.sp.fazenda.nfe.SVCStatusServico.CteStatusServico cte = new CTe.br.gov.sp.fazenda.nfe.SVCStatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCStatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.sp.fazenda.nfe.homologacao.StatusServico.CteStatusServico cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.StatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.StatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                        }
                    case ("41")://Parana
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.pr.fazenda.cte.Status.CteStatusServico cte = new CTe.br.gov.pr.fazenda.cte.Status.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.Status.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.pr.fazenda.cte.homologacao.Status.CteStatusServico cte = new CTe.br.gov.pr.fazenda.cte.homologacao.Status.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.Status.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.rs.sefaz.cte.StatusServico.CteStatusServico cte = new CTe.br.gov.rs.sefaz.cte.StatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.StatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.rs.sefaz.cte.homologacao.StatusServico.CteStatusServico cte = new CTe.br.gov.rs.sefaz.cte.homologacao.StatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.StatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.ms.cte.producao.StatusServico.CteStatusServico cte = new CTe.br.gov.ms.cte.producao.StatusServico.CteStatusServico();
                                cte.cteCabecMsg = new CTe.br.gov.ms.cte.producao.StatusServico.CTeCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Produto
                            {
                                br.gov.mt.sefaz.cte.StatusServico.CteStatusServico cte = new CTe.br.gov.mt.sefaz.cte.StatusServico.CteStatusServico();
                                cte.cteCabecMsgValue = new CTe.br.gov.mt.sefaz.cte.StatusServico.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteStatusServicoCT(cteDadosMsg);
                            }
                            else return null;
                        }
                    default: return null;
                }
        }

        public static string StatusServico(TRegistro_CfgFrota rCfgCte, bool St_contingencia)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<consStatServCte versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/cte\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgCte.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("STATUS");
            xml.Append("</xServ>");
            xml.Append("</consStatServCte>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgCte.Path_schemas.Trim().SeparadorDiretorio() + "consStatServCTe_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                         "CTE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                rCfgCte.St_ctecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgCte);
                //Tratar retorno
                return retorno["cStat"].InnerText;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
    }
}
