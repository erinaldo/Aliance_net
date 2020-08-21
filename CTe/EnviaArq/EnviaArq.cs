using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace CTe.EnviaArq
{
    public class TEnviaArq
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
                        br.gov.sp.fazenda.nfe.SVCRecepcao.CteRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.SVCRecepcao.CteRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCRecepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoLote(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.Recepcao.CteRecepcao cte = new CTe.br.gov.rs.sefaz.cte.Recepcao.CteRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.Recepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoLote(cteDadosMsg);
                    }
                    else return null;
                }
                else//Homologacao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-Sao Paulo
                    {
                        br.gov.sp.fazenda.nfe.homologacao.Recepcao.CteRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.Recepcao.CteRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.Recepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoLote(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.homologacao.Recepcao.CteRecepcao cte = new CTe.br.gov.rs.sefaz.cte.homologacao.Recepcao.CteRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.Recepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoLote(cteDadosMsg);
                    }
                    else return null;
                }
            }
            else
                switch (rCfgCte.Cd_uf_empresa.Trim())
                {
                    case ("31")://Minas Gerais
                        {
                            if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                            {
                                br.gov.mg.fazenda.cte.Recepcao.CteRecepcao cte = new CTe.br.gov.mg.fazenda.cte.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.mg.fazenda.cte.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                            {
                                br.gov.sp.fazenda.nfe.SVCRecepcao.CteRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.SVCRecepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.sp.fazenda.nfe.homologacao.Recepcao.CteRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                        }
                    case ("41")://Parana
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.pr.fazenda.cte.Recepcao.CteRecepcao cte = new CTe.br.gov.pr.fazenda.cte.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.pr.fazenda.cte.homologacao.Recepcao.CteRecepcao cte = new CTe.br.gov.pr.fazenda.cte.homologacao.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                            {
                                br.gov.rs.sefaz.cte.Recepcao.CteRecepcao cte = new CTe.br.gov.rs.sefaz.cte.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.rs.sefaz.cte.homologacao.Recepcao.CteRecepcao cte = new CTe.br.gov.rs.sefaz.cte.homologacao.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                            {
                                br.gov.ms.cte.producao.Recepcao.CteRecepcao cte = new CTe.br.gov.ms.cte.producao.Recepcao.CteRecepcao();
                                cte.cteCabecMsg = new CTe.br.gov.ms.cte.producao.Recepcao.CTeCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgCte.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                            {
                                br.gov.mt.sefaz.cte.Recepcao.CteRecepcao cte = new CTe.br.gov.mt.sefaz.cte.Recepcao.CteRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.mt.sefaz.cte.Recepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoLote(cteDadosMsg);
                            }
                            else return null;
                        }
                    default: return null;
                }
        }

        public static void EnviarLoteCte(List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lCte,
                                         TRegistro_CfgFrota rCfgCte)
        {
            if (lCte != null)
            {
                //Verificar status do servico junto a receita
                if (CTe.StatusServico.TStatusServico.StatusServico(rCfgCte, false).Trim() != "107")
                    if (CTe.StatusServico.TStatusServico.StatusServico(rCfgCte, true).Trim().Equals("107"))
                        rCfgCte.St_ctecontingencia = true;
                    else throw new Exception("Serviço indisponivel no momento.\r\nAguarde alguns minutos e tente novamente.");
                CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe lote = new CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe();
                try
                {
                    lote.Cd_empresa = rCfgCte.Cd_empresa;
                    lote.Tp_ambiente = rCfgCte.Tp_ambiente;
                    lote.Tp_emissaocte = rCfgCte.St_ctecontingencia ? rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS") ? "7" : "8" : "1";
                    CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(lote, null);
                    CTe.GerarArq.TGerarArq.GerarArquivoXml(lCte, rCfgCte);
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    xml.Append("<enviCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\">");
                    xml.Append("<idLote>");
                    xml.Append(lote.Id_lotestr);
                    xml.Append("</idLote>");
                    lCte.ForEach(p =>
                        {
                            //Gravar lote x cte
                            CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Gravar(
                                new CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Nr_lanctoctr = p.Nr_lanctoCTRC,
                                    Id_lote = lote.Id_lote
                                }, null);
                            xml.Append(p.Xml_cte);
                        });
                    xml.Append("</enviCTe>");
                    //Validar arquivo lote
                    Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                            rCfgCte.Path_schemas.SeparadorDiretorio() + "enviCte_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                            "CTE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                    //Enviar Lote para Receita
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml.ToString());
                    XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgCte);
                    //Tratar retorno
                    if (retorno != null)
                    {
                        if (retorno["cStat"].InnerText.Trim().Equals("103"))
                        {
                            //Lote recebido com sucesso
                            //Gravar dados do lote no banco de dados
                            lote.Status = decimal.Parse(retorno["cStat"].InnerText);
                            lote.Ds_mensagem = retorno["xMotivo"].InnerText;
                            if (retorno["infRec"].FirstChild != null)
                            {
                                try
                                {
                                    lote.Dt_recebimento = DateTime.Parse(retorno["infRec"]["dhRecbto"].InnerText);
                                }
                                catch { }
                                lote.Nr_recibo = Convert.ToDecimal(retorno["infRec"]["nRec"].InnerText);
                            }
                            CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(lote, null);
                        }
                        else
                        {
                            lote.Status = decimal.Parse(retorno["cStat"].InnerText);
                            lote.Ds_mensagem = retorno["xMotivo"].InnerText;
                            CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(lote, null);
                        }
                    }
                    else
                        throw new Exception("Serviço Enviar CT-e indisponivel no momento.");
                }
                catch (Exception ex)
                {
                    CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Buscar(lote.Cd_empresa, lote.Id_lotestr, string.Empty, null).ForEach(p =>
                        CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Excluir(p, null));
                    CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Excluir(lote, null);
                    throw new Exception("Erro ao enviar Lote!" + ex.Message.Trim());
                }
            }
        }
    }
}