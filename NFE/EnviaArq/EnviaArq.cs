using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using Utils;

namespace srvNFE.EnviaArq
{
    public class TEnviarArq2
    {
        private static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                   CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            if (rCfgNfe.St_nfecontingencia)
            {
                if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.AutorizacaoLote.NfeAutorizacao nfe = new br.gov.fazenda.svc.AutorizacaoLote.NfeAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.fazenda.svc.AutorizacaoLote.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.AutorizacaoLote4.NFeAutorizacao4 nfe = new br.gov.fazenda.svc.AutorizacaoLote4.NFeAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                    else//Virtual Rio Grande do Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.NfeAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.NfeAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.rs.svrs.nfe.AutorizaLote4.NFeAutorizacao4 nfe = new br.gov.rs.svrs.nfe.AutorizaLote4.NFeAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                }
                else//Homologacao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.hom.ANAutorizaLote.NfeAutorizacao nfe = new br.gov.fazenda.svc.hom.ANAutorizaLote.NfeAutorizacao();
                            nfe.nfeCabecMsgValue = new br.gov.fazenda.svc.hom.ANAutorizaLote.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.hom.AutorizacaoLote4.NFeAutorizacao4 nfe = new br.gov.fazenda.svc.hom.AutorizacaoLote4.NFeAutorizacao4();
                            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                        }
                    }
                    else//Virtual Rio Grande do Sul
                    {
                        br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.NfeAutorizacao nfe = new srvNFE.br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.NfeAutorizacao();
                        nfe.nfeCabecMsgValue = new srvNFE.br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.nfeCabecMsg()
                        {
                            cUF = rCfgNfe.Cd_uf_empresa,
                            versaoDados = rCfgNfe.Cd_versao
                        };
                        nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                        return nfe.nfeAutorizacaoLote(nfeDadosMsg);
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
                                br.gov.ms.sefaz.nfe.MSAutoriza4.NFeAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.MSAutoriza4.NFeAutorizacao4();
                                nfe.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4";
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.MSAutoriza4.nfeResultMsg
                                    {
                                        Any = new XmlNode[] { nfeDadosMsg }
                                    }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSAutoriza4.NFeAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSAutoriza4.NFeAutorizacao4();
                                nfe.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4";
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.hom.MSAutoriza4.nfeResultMsg
                                    {
                                        Any = new XmlNode[] { nfeDadosMsg }
                                    }).Any[0];
                            }
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.sp.fazenda.nfe.SPAutorizaLote.NfeAutorizacao nfe = new br.gov.sp.fazenda.nfe.SPAutorizaLote.NfeAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPAutorizaLote.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.sp.fazenda.nfe.SPAutorizaLote4.NFeAutorizacao4 nfe = new br.gov.sp.fazenda.nfe.SPAutorizaLote4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
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
                                    br.gov.pr.fazenda.nfe.PRAutorizaLote3.NfeAutorizacao3 nfe = new br.gov.pr.fazenda.nfe.PRAutorizaLote3.NfeAutorizacao3();
                                    nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.PRAutorizaLote3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.PRAutorizaLote4.NFeAutorizacao4 nfe = new br.gov.pr.sefa.nfe.PRAutorizaLote4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.pr.fazenda.nfe.homologacao.PRAutorizaLote3.NfeAutorizacao3 nfe = new br.gov.pr.fazenda.nfe.homologacao.PRAutorizaLote3.NfeAutorizacao3();
                                    nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.homologacao.PRAutorizaLote3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.homologacao.Autoriza4.NFeAutorizacao4 nfe = new br.gov.pr.sefa.nfe.homologacao.Autoriza4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                        }
                    case ("42")://Santa Catarina
                        {
                            if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.NfeAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.NfeAutorizacao();
                                    nfe.Url = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx";
                                    nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.RSAutorizaLote.nfeCabecMsg
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.svrs.nfe.AutorizaLote4.NFeAutorizacao4 nfe = new br.gov.rs.svrs.nfe.AutorizaLote4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else//Homologacao
                            {
                                br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.NfeAutorizacao nfe = new br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.NfeAutorizacao();
                                nfe.Url = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx";
                                nfe.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSAutorizaLote.nfeCabecMsg
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versao
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefaz.nfe.RSAutorizaLote.NfeAutorizacao nfe = new br.gov.rs.sefaz.nfe.RSAutorizaLote.NfeAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSAutorizaLote.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.sefazrs.nfe.RSAutorizaLote4.NFeAutorizacao4 nfe = new br.gov.rs.sefazrs.nfe.RSAutorizaLote4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                            }
                            else return null;
                        }
                    case ("50")://Mato Grosso do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.ms.sefaz.nfe.MSAutoriza4.NFeAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.MSAutoriza4.NFeAutorizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.MSAutoriza4.nfeResultMsg
                                    {
                                        Any = new XmlNode[] { nfeDadosMsg }
                                    }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSAutoriza4.NFeAutorizacao4 nfe = new br.gov.ms.sefaz.nfe.hom.MSAutoriza4.NFeAutorizacao4();
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfe.nfeAutorizacaoLote(
                                    new br.gov.ms.sefaz.nfe.hom.MSAutoriza4.nfeResultMsg
                                    {
                                        Any = new XmlNode[] { nfeDadosMsg }
                                    }).Any[0];
                            }
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.mt.sefaz.nfe.MTAutorizaLote.NfeAutorizacao nfe = new br.gov.mt.sefaz.nfe.MTAutorizaLote.NfeAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.mt.sefaz.nfe.MTAutorizaLote.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.mt.sefaz.nfe.MTAutorizaLote4.NfeAutorizacao4 nfe = new br.gov.mt.sefaz.nfe.MTAutorizaLote4.NfeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
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
                                    br.gov.go.sefaz.nfe.GOAutorizaLote.NfeAutorizacao nfe = new br.gov.go.sefaz.nfe.GOAutorizaLote.NfeAutorizacao();
                                    nfe.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GOAutorizaLote.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.go.sefaz.nfe.GOAutorizaLote4.NFeAutorizacao4 nfe = new br.gov.go.sefaz.nfe.GOAutorizaLote4.NFeAutorizacao4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeAutorizacaoLote(nfeDadosMsg);
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

        public static decimal GerarIdLote(decimal id_lote,
                                           decimal? loteretorno,
                                           DateTime? dt_recebimento,
                                           decimal? tempomedio,
                                           string st_registro,
                                           decimal? status,
                                           string ds_mensagem,
                                           string Tp_emissaoNFe,
                                           CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            string retorno = CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE.Gravar(
                                new CamadaDados.Faturamento.NFE.TRegistro_LanLoteNFE()
                                {
                                    Id_lote = id_lote,
                                    Loteretorno = loteretorno.HasValue ? loteretorno.Value : decimal.Zero,
                                    Dt_recebimento = dt_recebimento,
                                    Tempomedio = tempomedio.HasValue ? tempomedio.Value : decimal.Zero,
                                    St_registro = st_registro,
                                    Status = status.HasValue ? status.Value : decimal.Zero,
                                    Ds_mensagem = ds_mensagem,
                                    Tp_ambiente = rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2",
                                    Tp_emissaonfe = Tp_emissaoNFe
                                }, null);
            return Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
        }

        public static void GravarLoteXNf(decimal id_lote,
                                          string chave_acesso_nfe,
                                          DateTime? dt_processamento,
                                          decimal nr_protocolo,
                                          string digitoverificado,
                                          decimal status,
                                          string ds_mensagem,
                                          string Veraplic)
        {
            //Buscar nota fiscal que tenha a chave de acesso
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.chave_acesso_nfe",
                        vOperador = "=",
                        vVL_Busca = "'" + chave_acesso_nfe.Trim() + "'"
                    }
                }, 1, string.Empty);
            lNf.ForEach(p => CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE_X_NotaFiscal.Gravar(
                                new CamadaDados.Faturamento.NFE.TRegistro_LanLoteNFE_X_NotaFiscal()
                                {
                                    Id_lote = id_lote,
                                    Cd_empresa = p.Cd_empresa,
                                    Nr_lanctofiscal = p.Nr_lanctofiscal.Value,
                                    Dt_processamento = dt_processamento,
                                    Nr_protocolo = nr_protocolo,
                                    Digitoverificado = digitoverificado,
                                    Status = status,
                                    Ds_mensagem = ds_mensagem,
                                    Veraplic = Veraplic
                                }, null));
        }

        public static bool EnviarLoteNfe2(decimal Id_lote,
                                          List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNfe,
                                          CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            bool ret = false;
            //Verificar se Nfe ja esta em algum lote
            if (lNfe != null)
                lNfe.ForEach(p =>
                    {
                        if (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctofiscal",
                                    vOperador = "=",
                                    vVL_Busca = p.Nr_lanctofiscal.ToString()
                                }
                            }, "1") != null)
                            lNfe.Remove(p);
                    });
            //Validar Certificado
            ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            //Verificar status do servico junto a receita
            if (ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, false).Trim() != "107")
                if (ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, true).Trim().Equals("107"))
                {
                    rCfgNfe.St_nfecontingencia = true;
                    rCfgNfe.Dt_contingencia = CamadaDados.UtilData.Data_Servidor();
                }
                else
                    throw new Exception("Serviço indisponivel no momento.\r\nAguarde alguns minutos e tente novamente.");
            if (lNfe == null)
            {
                //Deletar Nfe com problemas
                GerarArq.TGerarArq2.DeletarNfLotesProblemas(rCfgNfe);
                //Deletar lotes com erro
                GerarArq.TGerarArq2.DeletarLotesProblemas(rCfgNfe);
            }
            GerarArq.TGerarArq2.GerarArqXML(ref lNfe, rCfgNfe);
            if (lNfe.Count > 0)
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");

                #region enviNFe
                xml.Append("<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versao.Trim() + "\">\n");

                //Gerar Lote NFe
                if (Id_lote.Equals(decimal.Zero))
                    Id_lote = GerarIdLote(decimal.Zero, 
                                          decimal.Zero, 
                                          null, 
                                          decimal.Zero, 
                                          "A", 
                                          decimal.Zero, 
                                          string.Empty,
                                          (rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1"),
                                          rCfgNfe);
                if (Id_lote <= 0)
                    throw new Exception("Erro gerar Id. do lote");
                #region "idLote"
                xml.Append("<idLote>");
                xml.Append(Id_lote.ToString().PadLeft(15, '0'));
                xml.Append("</idLote>\n");
                #endregion
                #region indSinc
                xml.Append("<indSinc>");
                xml.Append(lNfe.Count > 1 ? "0" : "1");
                xml.Append("</indSinc>");
                #endregion
                lNfe.ForEach(p =>
                   {
                       XmlDocument documento = new XmlDocument();
                       documento.LoadXml(p.Xml_Nfe);
                       //Gravar lote x nota fiscal
                       GravarLoteXNf(Id_lote, 
                                     documento["NFe"]["infNFe"].Attributes["Id"].InnerText.Trim().Substring(3, documento["NFe"]["infNFe"].Attributes["Id"].InnerText.Trim().Length - 3), 
                                     null, 
                                     decimal.Zero, 
                                     string.Empty, 
                                     decimal.Zero, 
                                     string.Empty,
                                     string.Empty);
                       xml.Append(p.Xml_Nfe + "\n");
                   });
                xml.Append("</enviNFe>\n");
                #endregion

                //Validar Arquivo Lote
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                        rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "enviNFe_v" + rCfgNfe.Cd_versao.Trim() + ".xsd",
                                                        "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                try
                {
                    //Enviar Lote para Receita
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml.ToString());
                    XmlNode retorno = ConectarWebService2(doc.DocumentElement, rCfgNfe);

                    //Tratar retorno
                    if (retorno != null)
                    {
                        if (retorno["cStat"].InnerText.Trim().Equals("103") ||
                            retorno["cStat"].InnerText.Trim().Equals("104"))
                        {
                            //Lote recebido com sucesso
                            //Gravar dados do lote no banco de dados
                            decimal? nRec = null;
                            DateTime? dhRecbto = null;
                            decimal? tMed = null;
                            try
                            {
                                dhRecbto = Convert.ToDateTime(retorno["dhRecbto"].InnerText);
                            }
                            catch { }
                            if (retorno.InnerXml.Contains("infRec"))
                            {
                                nRec = Convert.ToDecimal(retorno["infRec"]["nRec"].InnerText);
                                tMed = Convert.ToDecimal(retorno["infRec"]["tMed"].InnerText);
                            }
                            else if(retorno.InnerXml.Contains("protNFe"))
                            {
                                DateTime? dt_rec = null;
                                try
                                {
                                    dt_rec = Convert.ToDateTime(retorno["protNFe"]["infProt"]["dhRecbto"].InnerText);
                                }
                                catch { }
                                decimal nprot = decimal.Zero;
                                try
                                {
                                    nprot = Convert.ToDecimal(retorno["protNFe"]["infProt"]["nProt"].InnerText);
                                }
                                catch { }
                                decimal status = decimal.Zero;
                                try
                                {
                                    status = Convert.ToDecimal(retorno["protNFe"]["infProt"]["cStat"].InnerText);
                                }
                                catch { }
                                srvNFE.EnviaArq.TEnviarArq2.GravarLoteXNf(Id_lote,
                                                                          retorno["protNFe"]["infProt"]["chNFe"].InnerText,
                                                                          dt_rec,
                                                                          nprot,
                                                                          (status.Equals(100) ? retorno["protNFe"]["infProt"]["digVal"].InnerText : string.Empty),
                                                                          status,
                                                                          retorno["protNFe"]["infProt"]["xMotivo"].InnerText,
                                                                          retorno["protNFe"]["infProt"]["verAplic"].InnerText);
                                ret = true;
                            }
                            GerarIdLote(Id_lote,
                                        nRec,
                                        dhRecbto,
                                        tMed,
                                        ret ? "P" : "E",
                                        Convert.ToDecimal(retorno["cStat"].InnerText),
                                        retorno["xMotivo"].InnerText,
                                        (rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1"),
                                        rCfgNfe);
                            //Verificar se Nota é denegada
                            if (retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("110") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("205") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("233") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("234") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("301") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("302") ||
                                retorno["protNFe"]["infProt"]["cStat"].InnerText.Equals("303"))
                            {
                                lNfe.ForEach(p => CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarNfDenegada(p, null));
                            }
                            //Gravar xml da nota no banco
                            lNfe.ForEach(p => CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.AlterarFaturamento(p, null));
                        }
                        else
                            //Erro no envio do lote
                            //Gravar mensagem de erro de envio do lote
                            GerarIdLote(Id_lote,
                                        decimal.Zero,
                                        null,
                                        decimal.Zero,
                                        "A",
                                        Convert.ToDecimal(retorno["cStat"].InnerText),
                                        retorno["xMotivo"].InnerText,
                                        (rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1"),
                                        rCfgNfe);
                    }
                    else
                        throw new Exception("Serviço Enviar NF-e indisponivel no momento.");
                }
                catch (Exception ex)
                {
                    srvNFE.GerarArq.TGerarArq2.DeletarNfLotesProblemas(rCfgNfe);
                    srvNFE.GerarArq.TGerarArq2.DeletarLotesProblemas(rCfgNfe);
                    throw new Exception(ex.Message.Trim());
                }
            }
            else
            {
                srvNFE.GerarArq.TGerarArq2.DeletarNfLotesProblemas(rCfgNfe);
                srvNFE.GerarArq.TGerarArq2.DeletarLotesProblemas(rCfgNfe);
            }
            return ret;
        }

        public static void ConsultarLote(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfe,
                                         CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            if ((rNfe == null) || (rCfgNfe == null))
                return;
            //Consultar status lote NFe
            int tot = 1;
            do
            {
                try
                {
                    srvNFE.NFERecepcao.TRetRecepcao2.ConsultaNFERecepcao2(rCfgNfe);
                }
                catch 
                { 
                    tot++;
                    continue;
                }
                //Verificar status Lote NFe
                if (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.status",
                            vOperador = "=",
                            vVL_Busca = "'104'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FAT_LoteNFE_X_NotaFiscal x " +
                                        "where x.id_lote = a.id_lote " +
                                        "and x.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                        "and x.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal.ToString() + ")"
                        }
                    }, "1") != null)
                {
                    //Verificar NFe aceita pela receita
                    if (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = rNfe.Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_LoteNFE x " +
                                                        "where x.id_lote = a.id_lote " +
                                                        "and x.st_registro = 'P' " +
                                                        "and x.status = '104')"
                                        }
                                    }, "1") != null)
                    {
                        try
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            System.Windows.Forms.BindingSource BinDados = new System.Windows.Forms.BindingSource();
                            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(
                                                    rNfe.Cd_empresa,
                                                    string.Empty,
                                                    string.Empty,
                                                    rNfe.Nr_lanctofiscalstr,
                                                    string.Empty,
                                                    string.Empty,
                                                    decimal.Zero,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    false,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    decimal.Zero,
                                                    decimal.Zero,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    false,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    0,
                                                    string.Empty,
                                                    null);
                            Rel.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(p=> p.Vl_ipi));
                            Rel.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(p=> p.Vl_icms + p.Vl_FCP));
                            Rel.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(p=> p.Vl_basecalcICMS));
                            Rel.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(p=> p.Vl_basecalcSTICMS));
                            Rel.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(p=> p.Vl_ICMSST + p.Vl_FCPST));
                            if (lNf.Count > 0)
                            {
                                //Buscar conf impressao da nota fiscal
                                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF().BuscarEscalar(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lNf[0].Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_serie",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lNf[0].Nr_serie.Trim() + "'"
                                                }
                                            }, "a.QT_ItensNota");
                                if (obj != null)
                                    if (lNf[0].ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                        while (lNf[0].ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                            lNf[0].ItensNota.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item());
                            }
                            BinDados.DataSource = lNf;
                            Rel.DTS_Relatorio = BinDados;
                            //Buscar financeiro da DANFE
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'L'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                    "inner join tb_fat_notafiscal_x_duplicata y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                                    "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                    "and x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                    "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal.ToString() + ")"
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            if (lParc.Count == 0)
                            {
                                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                                lParc =
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                                if (lParc.Count == 0)
                                {
                                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                                    lParc =
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'L'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.nr_lancto = y.nr_lancto " +
                                                                "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                                "on k.cd_empresa = y.cd_empresa " +
                                                                "and k.id_vendarapida = y.id_cupom " +
                                                                "inner join TB_FAT_NotaFiscal z " +
                                                                "on z.cd_empresa = k.cd_empresa " +
                                                                "and z.nr_pedido = k.nr_pedido " +
                                                                "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                                }
                                           }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                                }
                            }
                            if (lParc.Count > 0)
                                for (int i = 0; i < lParc.Count; i++)
                                {
                                    if (i < 12)
                                    {
                                        Rel.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                        Rel.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                                    }
                                    else
                                        break;
                                }
                            Rel.Nome_Relatorio = "TFLanFaturamento_Danfe";
                            Rel.NM_Classe = "TFLanConsultaNFe";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "TFLanFaturamento_Danfe";
                            //Verificar se o clifor da nota tem contato configurado para receber danfe ou xml da nfe
                            CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lContato =
                                new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor().Select(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rNfe.Cd_clifor.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(isnull(a.st_receberdanfe, 'N') = 'S' or isnull(a.st_receberxmlnfe, 'N') = 'S')"
                                }
                            }, 0, string.Empty);
                            List<string> Anexo = null;
                            List<string> Destinatarios = new List<string>();
                            if (lContato.Count > 0)
                            {
                                if (lContato.Exists(p => p.St_receberxmlnfebool))
                                {
                                    string path_anexo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                                    if (!string.IsNullOrEmpty(path_anexo))
                                    {
                                        if (!System.IO.Directory.Exists(path_anexo))
                                            System.IO.Directory.CreateDirectory(path_anexo);
                                        if (!path_anexo.EndsWith("\\"))
                                            path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                                        try
                                        {
                                            srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(path_anexo,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          lNf[0].Cd_empresa,
                                                                                          lNf[0].Nr_notafiscal.ToString(),
                                                                                          rCfgNfe);
                                        }
                                        catch { }
                                        //Ler arquivo gerado
                                        Anexo = new List<string>();
                                        Anexo.Add(path_anexo + lNf[0].Chave_acesso_nfe.Trim() + "-nfe.xml");
                                    }
                                }
                                lContato.ForEach(p => Destinatarios.Add(p.Email));
                            }
                            Rel.Gera_Relatorio(string.Empty,
                                               true,
                                               false,
                                               lContato.Count > 0,
                                               false,
                                               string.Empty,
                                               Destinatarios,
                                               Anexo,
                                               "DANFE",
                                               "NFe Nº" + rNfe.Nr_notafiscal.ToString());
                            break;
                        }
                        catch { throw new Exception("Erro imprimir NFe"); }//Levantar erro
                    }
                    else
                        tot = 11;//Levantar erro
                }
                else
                    tot++;
            } while (tot <= 10);
            if (tot > 10)
                throw new Exception("Erro processar NFe");
        }
    }
}
