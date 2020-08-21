using System;
using System.Text;
using System.Xml;
using Utils;

namespace srvNFE.NFERecepcao
{
    public class TRetRecepcao2
    {
        private static CamadaDados.Faturamento.NFE.TList_LanLoteNFE BuscarLotes(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            return new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_registro",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.status",
                                vOperador = "<>",
                                vVL_Busca = "'215'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x "+
                                            "where x.id_lote = a.id_lote "+
                                            "and x.cd_empresa = '" + rCfgNfe.Cd_empresa.Trim() + "')"
                            }
                        }, 0, string.Empty);
        }

        private static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                   CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            if (rCfgNfe.St_nfecontingencia)
            {
                if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                {
                    if(rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.RetAutorizacao.NfeRetAutorizacao nfe = new br.gov.fazenda.svc.RetAutorizacao.NfeRetAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.fazenda.svc.RetAutorizacao.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.RetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.fazenda.svc.RetAutorizacao4.NFeRetAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                    else//Ambiente Rio Grande Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.nfe.RSRetAutoriza.NfeRetAutorizacao nfe = new br.gov.rs.sefaz.nfe.RSRetAutoriza.NfeRetAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSRetAutoriza.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.rs.svrs.nfe.RetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.rs.svrs.nfe.RetAutorizacao4.NFeRetAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                }
                else//Homologacao
                {
                    if(rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.hom.ANRetAutoriza.NfeRetAutorizacao nfe = new br.gov.fazenda.svc.hom.ANRetAutoriza.NfeRetAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.fazenda.svc.hom.ANRetAutoriza.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.hom.RetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.fazenda.svc.hom.RetAutorizacao4.NFeRetAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                    else//Ambiente Rio Grande do Sul
                    {
                        br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.NfeRetAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.NfeRetAutorizacao();
                        nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.nfeCabecMsg()
                        {
                            cUF = rCfgNfe.Cd_uf_empresa,
                            versaoDados = rCfgNfe.Cd_versao
                        };
                        nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                        return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
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
                                br.gov.ms.sefaz.nfe.MSRetAutoriza4.NFeRetAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.MSRetAutoriza4.NFeRetAutorizacao4();
                                nfe.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4";
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.MSRetAutoriza4.nfeDadosMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.NFeRetAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.NFeRetAutorizacao4();
                                nfe.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4";
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.nfeDadosMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.sp.fazenda.nfe.SPRetAutoriza.NfeRetAutorizacao nfe = new br.gov.sp.fazenda.nfe.SPRetAutoriza.NfeRetAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPRetAutoriza.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.sp.fazenda.nfe.SPRetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.sp.fazenda.nfe.SPRetAutorizacao4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
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
                                    br.gov.pr.fazenda.nfe.PRRetAutoriza3.NfeRetAutorizacao3 nfe = new srvNFE.br.gov.pr.fazenda.nfe.PRRetAutoriza3.NfeRetAutorizacao3();
                                    nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.PRRetAutoriza3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacao(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.PRRetAutoriza4.NFeRetAutorizacao4 nfe = new br.gov.pr.sefa.nfe.PRRetAutoriza4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.NfeRetAutorizacao3 nfe = new br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.NfeRetAutorizacao3();
                                    nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacao(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.homologacao.PRRetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.pr.sefa.nfe.homologacao.PRRetAutorizacao4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                        }
                    case ("42")://Santa Catarina
                        {
                            if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefazvirtual.nfe.RSRetAutoriza.NfeRetAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.RSRetAutoriza.NfeRetAutorizacao();
                                    nfe.Url = "https://nfe.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx";
                                    nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.RSRetAutoriza.nfeCabecMsg
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.svrs.nfe.RetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.rs.svrs.nfe.RetAutorizacao4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else//Homologacao
                            {
                                br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.NfeRetAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.NfeRetAutorizacao();
                                nfe.Url = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx";
                                nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSRetAutoriza.nfeCabecMsg
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefaz.nfe.RSRetAutoriza.NfeRetAutorizacao nfe = new br.gov.rs.sefaz.nfe.RSRetAutoriza.NfeRetAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSRetAutoriza.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.sefazrs.nfe.RSRetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.rs.sefazrs.nfe.RSRetAutorizacao4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else return null;
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.ms.sefaz.nfe.MSRetAutoriza4.NFeRetAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.MSRetAutoriza4.NFeRetAutorizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.MSRetAutoriza4.nfeDadosMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.NFeRetAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.NFeRetAutorizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.hom.MSRetAutoriza4.nfeDadosMsg { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.mt.sefaz.nfe.MTRetAutoriza.NfeRetAutorizacao nfe = new srvNFE.br.gov.mt.sefaz.nfe.MTRetAutoriza.NfeRetAutorizacao();
                                    nfe.nfeCabecMsgValue = new srvNFE.br.gov.mt.sefaz.nfe.MTRetAutoriza.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.mt.sefaz.nfe.MTRetAutorizacao4.NfeRetAutorizacao4 nfe = new br.gov.mt.sefaz.nfe.MTRetAutorizacao4.NfeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
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
                                    br.gov.go.sefaz.nfe.GORetRecepcao2.NfeRetRecepcao2 nfe = new br.gov.go.sefaz.nfe.GORetRecepcao2.NfeRetRecepcao2();
                                    nfe.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GORetRecepcao2.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetRecepcao2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.go.sefaz.nfe.GORetAutorizacao4.NFeRetAutorizacao4 nfe = new br.gov.go.sefaz.nfe.GORetAutorizacao4.NFeRetAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeRetAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else return null;
                        }
                    default:
                        {
                            return null;
                        }
                }
        }

        public static string ConsultaNFERecepcao2(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            string msg = string.Empty;
            //Buscar Lotes aguardando processamento
            BuscarLotes(rCfgNfe).ForEach(p =>
                {
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
                    xml.Append("<consReciNFe versao=\"" + rCfgNfe.Cd_versao.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">\n");
                    xml.Append("<tpAmb>");
                    xml.Append(p.Tp_ambiente.Trim());
                    xml.Append("</tpAmb>\n");
                    xml.Append("<nRec>");
                    xml.Append(p.Loteretorno.ToString().PadLeft(15, '0'));
                    xml.Append("</nRec>\n");
                    xml.Append("</consReciNFe>\n");
                    
                    //Validar schema xml
                    Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                             rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "consReciNFe_v" + rCfgNfe.Cd_versao.Trim()  + ".xsd",
                                                             "NFE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

                    //Conectar Web Service
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml.ToString());
                    //Verificar se o lote foi gerado no ambiente SCAN
                    rCfgNfe.St_nfecontingencia = p.Tp_emissaonfe.Trim().Equals("6") || p.Tp_emissaonfe.Trim().Equals("7");
                    XmlNode retorno = ConectarWebService2(doc.DocumentElement, rCfgNfe);
                    
                    //Tratar retorno
                    if (retorno["cStat"].InnerText.Trim().Equals("104"))
                    {
                        //Atualizar status do lote
                        srvNFE.EnviaArq.TEnviarArq2.GerarIdLote(p.Id_lote,
                                                                p.Loteretorno,
                                                                p.Dt_recebimento,
                                                                p.Tempomedio,
                                                                "P",
                                                                Convert.ToDecimal(retorno["cStat"].InnerText),
                                                                retorno["xMotivo"].InnerText,
                                                                p.Tp_emissaonfe,
                                                                rCfgNfe);
                        msg += "Lote: " + p.Id_lote.ToString() + "\r\nMensagem: " + retorno["xMotivo"].InnerText.Trim() + "\r\n";
                        //Tratar as Notas do Lote
                        foreach (XmlNode no in retorno.ChildNodes)
                        {
                            if (no.Name.Trim().Equals("protNFe"))
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
                                srvNFE.EnviaArq.TEnviarArq2.GravarLoteXNf(p.Id_lote,
                                                                          no["infProt"]["chNFe"].InnerText,
                                                                          dt_rec,
                                                                          nprot,
                                                                          (status.Equals(100) ? no["infProt"]["digVal"].InnerText : string.Empty),
                                                                          status,
                                                                          no["infProt"]["xMotivo"].InnerText,
                                                                          no["infProt"]["verAplic"].InnerText);
                            }
                        }
                    }
                    else
                        srvNFE.EnviaArq.TEnviarArq2.GerarIdLote(p.Id_lote,
                                                                p.Loteretorno,
                                                                p.Dt_recebimento,
                                                                p.Tempomedio,
                                                                p.St_registro,
                                                                Convert.ToDecimal(retorno["cStat"].InnerText),
                                                                retorno["xMotivo"].InnerText,
                                                                p.Tp_emissaonfe,
                                                                rCfgNfe);
                });
            return msg;
        }
    }
}
