using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using System.Net;

namespace srvNFE.ConsultaStatusServico
{
    public class ConsultaStatusServico
    {
        private static XmlNode ConectarWebService(XmlNode nfeDadosMsg,
                                                  TRegistro_CfgNfe rCfgNfe)
        {
            if (rCfgNfe.St_nfecontingencia)
            {
                if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.StatusServico.NfeStatusServico2 nfeStatus = new br.gov.fazenda.svc.StatusServico.NfeStatusServico2();
                            nfeStatus.nfeCabecMsgValue = new br.gov.fazenda.svc.StatusServico.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                        }
                        else //4.00
                        {
                            br.gov.fazenda.svc.StatusServico4.NFeStatusServico4 nfeStatus = new br.gov.fazenda.svc.StatusServico4.NFeStatusServico4();
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
                        }
                    }
                    else//Ambiente Rio Grande do Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.nfe.RSStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.rs.sefaz.nfe.RSStatusServico2.NfeStatusServico2();
                            nfeStatus.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSStatusServico2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.rs.svrs.nfe.StatusServico4.NfeStatusServico4 nfeStatus = new br.gov.rs.svrs.nfe.StatusServico4.NfeStatusServico4();
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
                        }
                    }
                }
                else//Homologacao
                {
                    if (rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N"))//Ambiente Nacional
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.fazenda.svc.hom.ANStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.fazenda.svc.hom.ANStatusServico2.NfeStatusServico2();
                            nfeStatus.nfeCabecMsgValue = new br.gov.fazenda.svc.hom.ANStatusServico2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.fazenda.svc.hom.ANStatusServico4.NFeStatusServico4 nfeStatus = new br.gov.fazenda.svc.hom.ANStatusServico4.NFeStatusServico4();
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
                        }
                    }
                    else//Ambiente Rio Grande do Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.NfeStatusServico2();
                            nfeStatus.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.nfeCabecMsg()
                            {
                                cUF = rCfgNfe.Cd_uf_empresa,
                                versaoDados = rCfgNfe.Cd_versao
                            };
                            nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            return null;
                        }
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
                                br.gov.ms.sefaz.nfe.MSStatusServico4.NFeStatusServico4 status = new br.gov.ms.sefaz.nfe.MSStatusServico4.NFeStatusServico4();
                                status.Url = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4";
                                status.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                status.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return status.nfeStatusServicoNF(
                                    new br.gov.ms.sefaz.nfe.MSStatusServico4.nfeResultMsg
                                    { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSStatusServico4.NFeStatusServico4 status = new br.gov.ms.sefaz.nfe.hom.MSStatusServico4.NFeStatusServico4();
                                status.Url = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4";
                                status.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                status.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return status.nfeStatusServicoNF(
                                    new br.gov.ms.sefaz.nfe.hom.MSStatusServico4.nfeResultMsg
                                    { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                        }
                    case ("35")://Sao Paulo
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.sp.fazenda.nfe.SPStatusServico3.NfeStatusServico2 nfeStatus = new br.gov.sp.fazenda.nfe.SPStatusServico3.NfeStatusServico2();
                                    nfeStatus.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPStatusServico3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.sp.fazenda.nfe.SPStatusServico4.NFeStatusServico4 nfeStatus = new br.gov.sp.fazenda.nfe.SPStatusServico4.NFeStatusServico4();
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
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
                                    br.gov.pr.fazenda.nfe.PRStatusServico3.NfeStatusServico3 nfe = new br.gov.pr.fazenda.nfe.PRStatusServico3.NfeStatusServico3();
                                    nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.PRStatusServico3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeStatusServicoNF(nfeDadosMsg);
                                }
                                else //4.00
                                {
                                    br.gov.pr.sefa.nfe.PRStatusServico4.NFeStatusServico4 nfe = new br.gov.pr.sefa.nfe.PRStatusServico4.NFeStatusServico4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeStatusServicoNF(nfeDadosMsg);
                                }
                            }
                            else
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.NfeStatusServico3 nfe = new br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.NfeStatusServico3();
                                    nfe.nfeCabecMsgValue = new br.gov.pr.fazenda.nfe.homologacao.PRStatusServico3.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeStatusServicoNF(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.pr.sefa.nfe.homologacao.PRStatusServico4.NFeStatusServico4 nfe = new br.gov.pr.sefa.nfe.homologacao.PRStatusServico4.NFeStatusServico4();
                                    nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfe.nfeStatusServicoNF(nfeDadosMsg);
                                }
                            }
                        }
                    case ("42")://Santa Catarina
                        {
                            if(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.rs.sefazrs.nfe.RSStatusServico4.NfeStatusServico4 nfeStatus = new br.gov.rs.sefazrs.nfe.RSStatusServico4.NfeStatusServico4();
                                nfeStatus.Url = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";
                                nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);    
                            }
                            else//Homologacao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.NfeStatusServico2();
                                    nfeStatus.Url = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx";
                                    nfeStatus.nfeCabecMsgValue = new br.gov.rs.sefazvirtual.nfe.homologacao.RSStatusServico2.nfeCabecMsg
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    return null;
                                }
                            }
                        }
                    case ("43")://Rio Grande do Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.rs.sefaz.nfe.RSStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.rs.sefaz.nfe.RSStatusServico2.NfeStatusServico2();
                                    nfeStatus.nfeCabecMsgValue = new br.gov.rs.sefaz.nfe.RSStatusServico2.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.rs.sefazrs.nfe.RSStatusServico4.NfeStatusServico4 nfeStatus = new br.gov.rs.sefazrs.nfe.RSStatusServico4.NfeStatusServico4();
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
                                }
                            }
                            else return null;
                        }
                    case ("50")://Mato Grosso Sul
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                br.gov.ms.sefaz.nfe.MSStatusServico4.NFeStatusServico4 status = new br.gov.ms.sefaz.nfe.MSStatusServico4.NFeStatusServico4();
                                status.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                status.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return status.nfeStatusServicoNF(
                                    new br.gov.ms.sefaz.nfe.MSStatusServico4.nfeResultMsg
                                    { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                            else
                            {
                                br.gov.ms.sefaz.nfe.hom.MSStatusServico4.NFeStatusServico4 status = new br.gov.ms.sefaz.nfe.hom.MSStatusServico4.NFeStatusServico4();
                                status.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                status.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return status.nfeStatusServicoNF(
                                    new br.gov.ms.sefaz.nfe.hom.MSStatusServico4.nfeResultMsg
                                    { Any = new XmlNode[] { nfeDadosMsg } }).Any[0];
                            }
                        }
                    case ("51")://Mato Grosso
                        {
                            if (rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P"))//Producao
                            {
                                if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                                {
                                    br.gov.mt.sefaz.nfe.MTStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.mt.sefaz.nfe.MTStatusServico2.NfeStatusServico2();
                                    nfeStatus.nfeCabecMsgValue = new br.gov.mt.sefaz.nfe.MTStatusServico2.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.mt.sefaz.nfe.MTStatusServico4.NfeStatusServico4 nfeStatus = new br.gov.mt.sefaz.nfe.MTStatusServico4.NfeStatusServico4();
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
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
                                    br.gov.go.sefaz.nfe.GOStatusServico2.NfeStatusServico2 nfeStatus = new br.gov.go.sefaz.nfe.GOStatusServico2.NfeStatusServico2();
                                    nfeStatus.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GOStatusServico2.nfeCabecMsg()
                                    {
                                        cUF = rCfgNfe.Cd_uf_empresa,
                                        versaoDados = rCfgNfe.Cd_versao
                                    };
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF2(nfeDadosMsg);
                                }
                                else//4.00
                                {
                                    br.gov.go.sefaz.nfe.GOStatusServico4.NFeStatusServico4 nfeStatus = new br.gov.go.sefaz.nfe.GOStatusServico4.NFeStatusServico4();
                                    nfeStatus.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                    nfeStatus.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                    return nfeStatus.nfeStatusServicoNF(nfeDadosMsg);
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

        public static string StatusServico(TRegistro_CfgNfe rCfgNfe,
                                           bool St_contingencia)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.Append("<consStatServ xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versao.Trim() + "\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
            xml.Append("</tpAmb>");
            xml.Append("<cUF>");
            xml.Append(rCfgNfe.Cd_uf_empresa);
            xml.Append("</cUF>");
            xml.Append("<xServ>");
            xml.Append("STATUS");
            xml.Append("</xServ>");
            xml.Append("</consStatServ>");
            try
            {
                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.Trim().SeparadorDiretorio() + "consStatServ_v" + rCfgNfe.Cd_versao.Trim() + ".xsd",
                                                         "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    return Utils.ValidaSchema.ValidaXML2.Retorno;

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                rCfgNfe.St_nfecontingencia = St_contingencia;
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
                //Tratar retorno
                return retorno["cStat"].InnerText;
            }
            catch (Exception ex)
            { return ex.Message.Trim(); }
        }
        
        public static void ValidarCertificado(TRegistro_CfgNfe rCfgNfe)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            if (!rCfgNfe.Dt_avisoCert.HasValue)
                rCfgNfe.Dt_avisoCert = dt_atual.AddDays(-1);
            if ((rCfgNfe.Nr_diasexpirarcert > decimal.Zero) &&
                (rCfgNfe.Dt_avisoCert.Value.Date < dt_atual.Date))
            {
                DateTime dt_validade = new Utils.Assinatura.TAssinatura2(rCfgNfe.Nr_certificado_nfe).ValidadeCertificado();
                if (dt_atual.AddDays(Convert.ToDouble(rCfgNfe.Nr_diasexpirarcert)).Date >= dt_validade.Date)
                {
                    System.Windows.Forms.MessageBox.Show("Certificado digital da empresa " + rCfgNfe.Nm_empresa.Trim() + " irá expirar em " + dt_validade.ToString("dd/MM/yyyy HH:mm:ss") + ".\r\n" +
                                                         "Favor providenciar a renovação do mesmo, para que o faturamento da empresa não seja paralisado.",
                                                            "Mensagem", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    try
                    {
                        new CamadaDados.TDataQuery().executarSql("update tb_fat_cfgnfe set dt_avisocert = getdate(), dt_alt = getdate() where cd_empresa = '" + rCfgNfe.Cd_empresa.Trim() + "'", null);
                    }
                    catch
                    { }
                    if (rCfgNfe.St_enviaremailcontadorbool)
                    {
                        //Verificar se o contador tem email cadastrado
                        object email = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                            "where x.cd_clifor_contador = a.cd_clifor "+
                                                            "and x.cd_empresa = '" + rCfgNfe.Cd_empresa.Trim() + "')"
                                            }
                                        }, "a.email");
                        if (email != null)
                            new FormRelPadrao.Email(new List<string>() { email.ToString() },
                                                    "CERTIFICADO DIGITAL EXPIRANDO",
                                                    "<p><b>ATENÇÃO!</b><br /></p>" +
                                                    "Certificado digital da empresa <b>" + rCfgNfe.Nm_empresa.Trim() +"</b> expira em <b>" + dt_validade.ToString("dd/MM/yyyy HH:mm:ss") +"</b>.<br />" +
                                                    "Favor providenciar a renovação do mesmo, para que o faturamento da empresa não seja paralisado.<br />" +
                                                    "<p><font size=\"2\" color=\"blue\"><i>Obs.: Mensagem automática do sistema ALIANCE.NET.<br />" +
                                                    "Desconsiderar caso já tenha renovado o certificado.</font></i></p>" +
                                                    "TecnoAliance Ltda.<br />" +
                                                    "(45)3421-5050<br />" +
                                                    "www.tecnoaliance.com.br",
                                                    new List<string>()).EnviarEmail();
                                                    
                    }
                }
            }
        }
    }
}
