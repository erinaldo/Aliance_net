using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace CTe.Inutilizar
{
    public class TInutilizarCte
    {
        public static XmlNode ConectarWebService(XmlNode cteDadosMsg,
                                                 CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            switch (rCfgCte.Cd_uf_empresa.Trim())
            {
                case ("31")://Minas Gerais
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.mg.fazenda.cte.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.mg.fazenda.cte.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.mg.fazenda.cte.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else return null;
                    }
                case ("35")://São Paulo
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.sp.fazenda.nfe.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.sp.fazenda.nfe.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else//Homologacao
                        {
                            br.gov.sp.fazenda.nfe.homologacao.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                    }
                case ("41")://Parana
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.pr.fazenda.cte.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.pr.fazenda.cte.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else//Homologacao
                        {
                            br.gov.pr.fazenda.cte.homologacao.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.pr.fazenda.cte.homologacao.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                    }
                case ("43")://Rio Grande do Sul
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.rs.sefaz.cte.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.rs.sefaz.cte.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else//Homologacao
                        {
                            br.gov.rs.sefaz.cte.homologacao.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.rs.sefaz.cte.homologacao.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                    }
                case ("50")://Mato Grosso do Sul
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.ms.cte.producao.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.ms.cte.producao.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsg = new CTe.br.gov.ms.cte.producao.Inutilizacao.CTeCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else return null;
                    }
                case ("51")://Mato Grosso
                    {
                        if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.mt.sefaz.cte.Inutilizacao.CteInutilizacao cte = new CTe.br.gov.mt.sefaz.cte.Inutilizacao.CteInutilizacao();
                            cte.cteCabecMsgValue = new CTe.br.gov.mt.sefaz.cte.Inutilizacao.cteCabecMsg()
                            {
                                cUF = rCfgCte.Cd_uf_empresa,
                                versaoDados = rCfgCte.Cd_versaolayout
                            };
                            cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                            return cte.cteInutilizacaoCT(cteDadosMsg);
                        }
                        else return null;
                    }
                default: return null;
            }
        }

        public static string InutilizarCte(string Cd_uf,
                                           string Cnpj,
                                           string Nr_serie,
                                           string Cd_modelo,
                                           string Ano,
                                           decimal Cte_inicial,
                                           decimal Cte_final,
                                           string Justificativa,
                                           CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<inutCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\">");
            xml.Append("<infInut Id=\"ID" + 
                        Cd_uf.FormatStringEsquerda(2, '0') +
                        Cnpj.SoNumero() +
                        Cd_modelo.FormatStringEsquerda(2, '0') +
                        Nr_serie.FormatStringEsquerda(3, '0') +
                        Cte_inicial.ToString().FormatStringEsquerda(9, '0') +
                        Cte_final.ToString().FormatStringEsquerda(9, '0') + "\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgCte.Tp_ambiente);
            xml.Append("</tpAmb>");
            xml.Append("<xServ>");
            xml.Append("INUTILIZAR");
            xml.Append("</xServ>");
            xml.Append("<cUF>");
            xml.Append(Cd_uf.FormatStringEsquerda(2, '0'));
            xml.Append("</cUF>");
            xml.Append("<ano>");
            xml.Append(Ano.FormatStringEsquerda(2, '0'));
            xml.Append("</ano>");
            xml.Append("<CNPJ>");
            xml.Append(Cnpj.SoNumero());
            xml.Append("</CNPJ>");
            xml.Append("<mod>");
            xml.Append(Cd_modelo.FormatStringEsquerda(2, '0'));
            xml.Append("</mod>");
            xml.Append("<serie>");
            xml.Append(Nr_serie.Trim());
            xml.Append("</serie>");
            xml.Append("<nCTIni>");
            xml.Append(Cte_inicial.ToString());
            xml.Append("</nCTIni>");
            xml.Append("<nCTFin>");
            xml.Append(Cte_final.ToString());
            xml.Append("</nCTFin>");
            xml.Append("<xJust>");
            xml.Append(Justificativa.RemoverCaracteres());
            xml.Append("</xJust>");
            xml.Append("</infInut>");
            xml.Append("</inutCTe>");

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgCte.Nr_seriecertificado,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpInutiliza,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                     rCfgCte.Path_schemas.SeparadorDiretorio() + "inutCTe_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                     "CTE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());

            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgCte);
            if (retorno["infInut"]["cStat"].InnerText.Trim().Equals("102"))
            {
                //Gravar registro Inutilizacao
                try
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_SeqInutNFe.Gravar(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_SeqInutNFe()
                        {
                            Nr_serie = Nr_serie.Trim(),
                            Nr_nfinicial = Cte_inicial,
                            Nr_nffinal = Cte_final,
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
