using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.NotaFiscal;

namespace srvNFE.CCe
{
    public class TCartaCorrecao
    {
        private static XmlNode ConectarWebService(XmlNode cceDadosMsg,
                                                  TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case ("31")://Minas Gerais
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.mg.fazenda.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.mg.fazenda.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.mg.fazenda.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                case ("35")://Sao Paulo
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.sp.fazenda.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.sp.fazenda.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.sp.fazenda.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                case ("41")://Parana
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento();
                            cce.Url = "https://nfe2.fazenda.pr.gov.br/nfe-evento/NFeRecepcaoEvento";
                            cce.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else//Homologacao
                        {
                            br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento();
                            cce.Url = "https://homologacao.nfe2.fazenda.pr.gov.br/nfe-evento/NFeRecepcaoEvento";
                            //br.gov.pr.fazenda.nfe2.homologacao.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.pr.fazenda.nfe2.homologacao.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                    }
                case ("43")://Rio Grande do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.rs.sefaz.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.rs.sefaz.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                case ("50")://Mato Grosso do Sul
                    {
                        if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.ms.fazenda.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.ms.fazenda.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.ms.fazenda.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                case ("51")://Mato Grosso
                    {
                        if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.mt.sefaz.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.mt.sefaz.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.mt.sefaz.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                case ("52")://Goias
                    {
                        if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.gov.go.sefaz.nfe.RecEvento.RecepcaoEvento cce = new srvNFE.br.gov.go.sefaz.nfe.RecEvento.RecepcaoEvento();
                            cce.nfeCabecMsgValue = new srvNFE.br.gov.go.sefaz.nfe.RecEvento.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versaoCCe
                            };
                            cce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return cce.nfeRecepcaoEvento(cceDadosMsg);
                        }
                        else return null;
                    }
                default: { return null; }
            }
        }

        public static string EnviarCCe(CamadaDados.Faturamento.NFE.TRegistro_EventoNFe cce,
                                       TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            ConsultaStatusServico.ConsultaStatusServico2.ValidarCertificado(rCfgNfe);
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaoCCe.Trim() +"\">\n");
            xml.Append("<idLote>");
            xml.Append(cce.Id_eventostr);
            xml.Append("</idLote>\n");
            #region Grupo Evento
            xml.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versaoCCe.Trim() + "\">\n");
            #region Grupo infEvento
            xml.Append("<infEvento Id=\"ID" + rCfgNfe.Cd_eventoCCe.Value.ToString() + cce.Chave_acesso_nfe.Trim() + cce.Id_eventostr.FormatSringEsquerda(2, '0') + "\">\n");
            xml.Append("<cOrgao>");
            xml.Append(rCfgNfe.Cd_uf_empresa.Trim());
            xml.Append("</cOrgao>\n");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>\n");
            xml.Append("<CNPJ>");
            xml.Append(rCfgNfe.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>\n");
            xml.Append("<chNFe>");
            xml.Append(cce.Chave_acesso_nfe.Trim());
            xml.Append("</chNFe>\n");
            xml.Append("<dhEvento>");
            xml.Append(cce.Dt_evento.Value.ToString("yyyy-MM-dd") + "T" + cce.Dt_evento.Value.ToString("HH:mm:ss") + "-03:00");
            xml.Append("</dhEvento>\n");
            xml.Append("<tpEvento>");
            xml.Append(rCfgNfe.Cd_eventoCCe.Value.ToString());
            xml.Append("</tpEvento>\n");
            xml.Append("<nSeqEvento>");
            xml.Append(cce.Id_eventostr);
            xml.Append("</nSeqEvento>\n");
            xml.Append("<verEvento>");
            xml.Append(rCfgNfe.Cd_versaoCCe.Trim());
            xml.Append("</verEvento>\n");
            #region Grupo detEvento
            xml.Append("<detEvento versao=\"" + rCfgNfe.Cd_versaoCCe.Trim() +"\">\n");
            xml.Append("<descEvento>");
            xml.Append("Carta de Correcao");
            xml.Append("</descEvento>\n");
            xml.Append("<xCorrecao>");
            xml.Append(cce.Ds_evento.Trim());
            xml.Append("</xCorrecao>\n");
            xml.Append("<xCondUso>");
            xml.Append(rCfgNfe.Ds_condusoCCe.Trim());
            xml.Append("</xCondUso>\n");
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
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "envCCe_v" + rCfgNfe.Cd_versaoCCe.Trim() +".xsd",
                                                     false);
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
                        cce.St_registro = "T";
                        try
                        {
                            cce.Nr_protocolo = decimal.Parse(retorno["retEvento"]["infEvento"]["nProt"].InnerText);
                        }
                        catch { }
                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(cce, null);
                        return string.Empty;
                    }
                    else
                        return retorno["retEvento"]["infEvento"]["xMotivo"].InnerText;
                }
                else
                    return retorno["xMotivo"].InnerText;
            }
            else
                throw new Exception("Ocorreu um erro ao enviar Carta Correção.");
        }
    }
}
