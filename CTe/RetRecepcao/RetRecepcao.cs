using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace CTe.RetRecepcao
{
    public class TRetRecepcao
    {
        private static XmlNode ConectarWebService(XmlNode cteDadosMsg,
                                                  CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            if (rCfgCte.St_ctecontingencia)
            {
                if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-Sao Paulo
                    {
                        br.gov.sp.fazenda.nfe.SVCRetRecepcao.CteRetRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.SVCRetRecepcao.CteRetRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCRetRecepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRetRecepcao(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.rs.sefaz.cte.RetRecepcao.CteRetRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.RetRecepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRetRecepcao(cteDadosMsg);
                    }
                    else return null;
                }
                else//Homologacao
                {
                    if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("SP"))//SVC-Sao Paulo
                    {
                        br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.CteRetRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRetRecepcao(cteDadosMsg);
                    }
                    else if (rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS"))//SVC-Rio Grande do Sul
                    {
                        br.gov.rs.sefaz.cte.homologacao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.rs.sefaz.cte.homologacao.RetRecepcao.CteRetRecepcao();
                        cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.RetRecepcao.cteCabecMsg()
                        {
                            cUF = rCfgCte.Cd_uf_empresa,
                            versaoDados = rCfgCte.Cd_versaolayout
                        };
                        cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                        return cte.cteRetRecepcao(cteDadosMsg);
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
                                br.gov.mg.fazenda.cte.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.mg.fazenda.cte.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.mg.fazenda.cte.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("35")://São Paulo
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.sp.fazenda.nfe.SVCRetRecepcao.CteRetRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.SVCRetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.SVCRetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.sp.fazenda.nfe.homologacao.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                        }
                    case ("41")://Parana
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.pr.fazenda.cte.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.pr.fazenda.cte.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else//Homologacao
                            {
                                br.gov.pr.fazenda.cte.homologacao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.pr.fazenda.cte.homologacao.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.pr.fazenda.cte.homologacao.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.rs.sefaz.cte.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.rs.sefaz.cte.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else
                            {
                                br.gov.rs.sefaz.cte.homologacao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.rs.sefaz.cte.homologacao.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.rs.sefaz.cte.homologacao.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.ms.cte.producao.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.ms.cte.producao.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsg = new CTe.br.gov.ms.cte.producao.RetRecepcao.CTeCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else return null;
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgCte.Tp_ambiente.Trim().Equals("1"))//Producao
                            {
                                br.gov.mt.sefaz.cte.RetRecepcao.CteRetRecepcao cte = new CTe.br.gov.mt.sefaz.cte.RetRecepcao.CteRetRecepcao();
                                cte.cteCabecMsgValue = new CTe.br.gov.mt.sefaz.cte.RetRecepcao.cteCabecMsg()
                                {
                                    cUF = rCfgCte.Cd_uf_empresa,
                                    versaoDados = rCfgCte.Cd_versaolayout
                                };
                                cte.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                cte.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgCte.Nr_seriecertificado));
                                return cte.cteRetRecepcao(cteDadosMsg);
                            }
                            else return null;
                        }
                    default: return null;
                }
        }

        public static string ConsultaRetRecepcao(CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte)
        {
            string msg = string.Empty;
            new CamadaDados.Faturamento.CTRC.TCD_LoteCTe().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCfgCte.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.status",
                                vOperador = "=",
                                vVL_Busca = "103"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_recibo",
                                vOperador = "is not",
                                vVL_Busca = "null"
                            }
                        }, 0, string.Empty, string.Empty).ForEach(p =>
                            {
                                StringBuilder xml = new StringBuilder();
                                xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                                xml.Append("<consReciCTe versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/cte\">");
                                xml.Append("<tpAmb>");
                                xml.Append(rCfgCte.Tp_ambiente);
                                xml.Append("</tpAmb>");
                                xml.Append("<nRec>");
                                xml.Append(p.Nr_recibo.Value.ToString().PadLeft(15, '0'));
                                xml.Append("</nRec>");
                                xml.Append("</consReciCTe>");

                                //Validar schema xml
                                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                                         rCfgCte.Path_schemas.SeparadorDiretorio() + "consReciCte_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                                         "CTE");
                                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                                    throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

                                //Conectar Web Service
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(xml.ToString());
                                rCfgCte.St_ctecontingencia = !p.Tp_emissaocte.Trim().Equals("1");
                                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgCte);

                                //Tratar retorno
                                if (retorno["cStat"].InnerText.Trim().Equals("104"))
                                {
                                    p.Status = Convert.ToDecimal(retorno["cStat"].InnerText);
                                    p.Ds_mensagem = retorno["xMotivo"].InnerText;
                                    CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(p, null);
                                    msg += "Lote: " + p.Id_lote.ToString() + "\r\nMensagem: " + retorno["xMotivo"].InnerText.Trim() + "\r\n";
                                    //Tratar as Notas do Lote
                                    foreach (XmlNode no in retorno.ChildNodes)
                                    {
                                        if (no.Name.Trim().Equals("protCTe"))
                                        {
                                            DateTime? dt_rec = null;
                                            try
                                            {
                                                dt_rec = Convert.ToDateTime(no["infProt"]["dhRecbto"].InnerText);
                                            }
                                            catch { }
                                            decimal nprot = decimal.Zero;
                                            try
                                            {
                                                nprot = Convert.ToDecimal(no["infProt"]["nProt"].InnerText);
                                            }
                                            catch { }
                                            decimal status = decimal.Zero;
                                            try
                                            {
                                                status = Convert.ToDecimal(no["infProt"]["cStat"].InnerText);
                                            }
                                            catch { }
                                            //Buscar CTe
                                            new CamadaDados.Faturamento.CTRC.TCD_Lote_X_CTe().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rCfgCte.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_lote",
                                                        vOperador = "=",
                                                        vVL_Busca = p.Id_lotestr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "b.chaveacesso",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + no["infProt"]["chCTe"].InnerText.Trim() + "'"
                                                    }
                                                }, 1, string.Empty).ForEach(v =>
                                                    {
                                                        v.Dt_processamento = dt_rec;
                                                        v.Nr_protocolo = nprot;
                                                        v.Digval = status.Equals(100) ? no["infProt"]["digVal"].InnerText : string.Empty;
                                                        v.Status = status;
                                                        v.Ds_mensagem = no["infProt"]["xMotivo"].InnerText;
                                                        v.VerAplic = no["infProt"]["verAplic"].InnerText;
                                                        CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Gravar(v, null);
                                                    });
                                        }
                                    }
                                }
                                else
                                {
                                    p.Status = Convert.ToDecimal(retorno["cStat"].InnerText);
                                    p.Ds_mensagem = retorno["xMotivo"].InnerText;
                                    CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(p, null);
                                }
                            });
            return msg;
        }
    }
}
