using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace CTe.Evento
{
    public class TEventoCTe
    {
        private static XmlNode ConectarWebService(XmlNode evDadosMsg,
                                                  CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            if (rCfgCte.St_ctecontingencia)
            {
                if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Produto
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-São Paulo
                    {
                        br.gov.sp.fazenda.nfe.Evento.CteRecepcaoEvento cte = new CTe.br.gov.sp.fazenda.nfe.Evento.CteRecepcaoEvento();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.Evento.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoEvento(evDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.Evento.CteRecepcaoEvento cte = new CTe.br.gov.rs.sefaz.cte.Evento.CteRecepcaoEvento();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.Evento.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoEvento(evDadosMsg);
                    }
                    else return null;
                }
                else//Homologacao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-São Paulo
                    {
                        br.gov.sp.fazenda.nfe.homologacao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.Evento.CteRecepcaoEvento();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.Evento.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoEvento(evDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.homologacao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.rs.sefaz.cte.homologacao.Evento.CteRecepcaoEvento();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.Evento.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRecepcaoEvento(evDadosMsg);
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
                                br.gov.mg.fazenda.cte.Evento.RecepcaoEvento cte = new CTe.br.gov.mg.fazenda.cte.Evento.RecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.mg.fazenda.cte.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else return null;
                        }
                    case ("35")://São Paulo
                        {
                            if(rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.sp.fazenda.nfe.Evento.CteRecepcaoEvento cte = new CTe.br.gov.sp.fazenda.nfe.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.sp.fazenda.nfe.homologacao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                        }
                    case ("41")://Parana
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.pr.fazenda.cte.Evento.CteRecepcaoEvento cte = new CTe.br.gov.pr.fazenda.cte.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.pr.fazenda.cte.homologacao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.pr.fazenda.cte.homologacao.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                        }
                    case("43")://Rio Grande do Sul
                        {
                            if(rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.rs.sefaz.cte.Evento.CteRecepcaoEvento cte = new CTe.br.gov.rs.sefaz.cte.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.rs.sefaz.cte.homologacao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.rs.sefaz.cte.homologacao.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if(rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.ms.cte.producao.Evento.CteRecepcaoEvento cte = new CTe.br.gov.ms.cte.producao.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsg = new CTe.br.gov.ms.cte.producao.Evento.CTeCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else return null;
                        }
                    case("51")://Mato Grosso
                        {
                            if(rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.mt.sefaz.cte.Evento.CteRecepcaoEvento cte = new CTe.br.gov.mt.sefaz.cte.Evento.CteRecepcaoEvento();
                                cte.cteCabecMsgValue = new CTe.br.gov.mt.sefaz.cte.Evento.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRecepcaoEvento(evDadosMsg);
                            }
                            else return null;
                        }
                    default: return null;
                }
        }

        public static string EnviarEvento(CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe rEvento,
                                          CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            decimal seqEvento = 1;
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CC"))
            {
                object obj = new CamadaDados.Faturamento.CTRC.TCD_EventoCTe().BuscarEscalar(
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
                                        vNM_Campo = "a.nr_lanctoCTR",
                                        vOperador = "=",
                                        vVL_Busca = rEvento.Nr_lanctoctrstr
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
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            #region eventoCTe
            xml.Append("<eventoCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\">");
            #region infEvento
            xml.Append("<infEvento Id=\"ID" + rEvento.Cd_eventostr + rEvento.Chaveacesso.Trim() + "01\">");
            #region cOrgao
            xml.Append("<cOrgao>");
            xml.Append(rCfgCte.Cd_uf_empresa.Trim());
            xml.Append("</cOrgao>");
            #endregion
            #region tpAmb
            xml.Append("<tpAmb>");
            xml.Append(rCfgCte.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            #endregion
            #region CNPJ
            xml.Append("<CNPJ>");
            xml.Append(rCfgCte.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>");
            #endregion
            #region chCTe
            xml.Append("<chCTe>");
            xml.Append(rEvento.Chaveacesso.Trim());
            xml.Append("</chCTe>");
            #endregion
            #region dhEvento
            xml.Append("<dhEvento>");
            xml.Append(rEvento.Dt_evento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            xml.Append("</dhEvento>");
            #endregion
            #region tpEvento
            xml.Append("<tpEvento>");
            xml.Append(rEvento.Cd_eventostr);
            xml.Append("</tpEvento>");
            #endregion
            #region nSeqEvento
            xml.Append("<nSeqEvento>");
            xml.Append(seqEvento.ToString());
            xml.Append("</nSeqEvento>");
            #endregion
            #region detEvento
            xml.Append("<detEvento versaoEvento=\"" + rCfgCte.Cd_versaolayout.Trim() + "\">");
            //Especifico Cancelamento
            #region evCancCTe
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CA"))
            {
                xml.Append("<evCancCTe>");
                #region descEvento
                xml.Append("<descEvento>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</descEvento>");
                #endregion
                #region nProt
                xml.Append("<nProt>");
                xml.Append(rEvento.Nr_protocolo_ctestr.FormatStringEsquerda(15, '0'));
                xml.Append("</nProt>");
                #endregion
                #region xJust
                xml.Append("<xJust>");
                xml.Append(rEvento.Justificativa.RemoverCaracteres().Trim());
                xml.Append("</xJust>");
                #endregion
                xml.Append("</evCancCTe>");
            }
            #endregion
            //Especifico Carta Correção
            #region evCCeCTe
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CC"))
            {
                xml.Append("<evCCeCTe>");
                #region descEvento
                xml.Append("<descEvento>");
                xml.Append(rEvento.Ds_evento.Trim());
                xml.Append("</descEvento>");
                #endregion
                #region infCorrecao
                xml.Append("<infCorrecao>");
                CamadaNegocio.Faturamento.CTRC.TCN_CamposCC.Buscar(rEvento.Cd_empresa,
                                                                   rEvento.Nr_lanctoctrstr,
                                                                   rEvento.Id_eventostr,
                                                                   null).ForEach(p=>
                                                                       {
                                                                            #region grupoAlterado
                                                                            xml.Append("<grupoAlterado>");
                                                                            xml.Append(p.Ds_grupo.Trim());
                                                                            xml.Append("</grupoAlterado>");
                                                                            #endregion
                                                                            #region campoAlterado
                                                                            xml.Append("<campoAlterado>");
                                                                            xml.Append(p.Ds_campo.Trim());
                                                                            xml.Append("</campoAlterado>");
                                                                            #endregion
                                                                            #region valorAlterado
                                                                            xml.Append("<valorAlterado>");
                                                                            xml.Append(p.ValorAlterado.Trim());
                                                                            xml.Append("</valorAlterado>");
                                                                            #endregion
                                                                       });
                xml.Append("</infCorrecao>");
                #endregion
                #region xCondUso
                xml.Append("<xCondUso>");
                xml.Append(rCfgCte.Ds_condusoCCe.Trim());
                xml.Append("</xCondUso>");
                #endregion
                xml.Append("</evCCeCTe>");
            }
            #endregion
            xml.Append("</detEvento>");
            #endregion
            xml.Append("</infEvento>");
            #endregion
            xml.Append("</eventoCTe>");
            #endregion
            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgCte.Nr_seriecertificado,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpEventoCTe,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                    rCfgCte.Path_schemas.SeparadorDiretorio() + "eventoCTe_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd", "CTE");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            if (rEvento.Tp_evento.Trim().ToUpper().Equals("CA"))
                rCfgCte.St_ctecontingencia = new CamadaDados.Faturamento.CTRC.TCD_LoteCTe().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_lote = a.id_lote " +
                                                                    "and x.cd_empresa = '" + rEvento.Cd_empresa.Trim() + "' " +
                                                                    "and x.nr_lanctoctr = " + rEvento.Nr_lanctoctrstr + ")"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.status",
                                                        vOperador = "=",
                                                        vVL_Busca = "'104'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_emissaoCTe",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'1'"
                                                    }
                                                }, "1") != null;
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgCte);
            //Tratar retorno
            if (retorno != null)
            {
                if (retorno["infEvento"]["cStat"].InnerText.Trim().Equals("135"))
                {
                    rEvento.St_registro = "T";
                    try
                    {
                        rEvento.Nr_protocolo = decimal.Parse(retorno["infEvento"]["nProt"].InnerText);
                    }
                    catch { }
                    rEvento.Xml_evento = xmlassinado;
                    rEvento.Xml_retevent = retorno.OuterXml;
                    CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Gravar(rEvento, null);
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
