using System;
using System.Text;
using System.Xml;
using Utils;

namespace srvNFE.ConsultaCad
{
    public class TConsultaCad2
    {
        private static XmlNode ConectarWebService2(XmlNode nfeDadosMsg,
                                                   string cd_ufConsulta,
                                                   CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (cd_ufConsulta.Trim())
            {
                case ("23")://Ceara
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.ce.sefaz.nfe.CEConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.ce.sefaz.nfe.CEConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.ce.sefaz.nfe.CEConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.ce.sefaz.nfe.CEConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.ce.sefaz.nfe.CEConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("26")://Pernambuco
                    {
                        br.gov.pe.sefaz.nfe.PEConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.pe.sefaz.nfe.PEConsultaCad2.CadConsultaCadastro2();
                        consulta.nfeCabecMsgValue = new br.gov.pe.sefaz.nfe.PEConsultaCad2.nfeCabecMsg()
                        {
                            cUF = cd_ufConsulta,
                            versaoDados = "2.00"
                        };
                        consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                        return consulta.consultaCadastro2(nfeDadosMsg);
                    }
                case ("29")://Bahia
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.ba.sefaz.nfe.BAConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.ba.sefaz.nfe.BAConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.ba.sefaz.nfe.BAConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.ba.sefaz.nfe.BAConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.ba.sefaz.nfe.BAConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("35")://Sao Paulo
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.sp.fazenda.nfe.SPConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.sp.fazenda.nfe.SPConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.sp.fazenda.nfe.SPConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.sp.fazenda.nfe.SPConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.sp.fazenda.nfe.SPConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("41")://Parana
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2();
                            consulta.Url = "https://nfe.fazenda.pr.gov.br/nfe/CadConsultaCadastro2";
                            consulta.nfeCabecMsgValue = new br.gov.rs.sefaz.sef.RSConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.pr.sefa.nfe.PRConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.pr.sefa.nfe.PRConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("42")://Santa Catarina
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2();
                            consulta.Url = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro2.asmx";
                            consulta.nfeCabecMsgValue = new br.gov.rs.sefaz.sef.RSConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.rs.svrs.cad.SVRSConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.rs.svrs.cad.SVRSConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("43")://Rio Grande do Sul
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.rs.sefaz.sef.RSConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.rs.sefaz.sef.RSConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.rs.sefazrs.cad.RSConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.rs.sefazrs.cad.RSConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                case ("50")://Mato Grosso do Sul
                    {
                        br.gov.ms.sefaz.nfe.MSConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.ms.sefaz.nfe.MSConsultaCad4.CadConsultaCadastro4();
                        consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                        consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                        return consulta.consultaCadastro(nfeDadosMsg);
                    }
                case ("51")://Mato Grosso
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.mt.sefaz.nfe.MTConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.mt.sefaz.nfe.MTConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.mt.sefaz.nfe.MTConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.mt.sefaz.nfe.MTConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.mt.sefaz.nfe.MTConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            var ret = consulta.consultaCadastro(nfeDadosMsg);
                            return ret;
                        }
                    }
                case ("52")://Goias
                    {
                        if (rCfgNfe.Cd_versao.Trim().Equals("3.10"))
                        {
                            br.gov.go.sefaz.nfe.GOConsultaCad2.CadConsultaCadastro2 consulta = new br.gov.go.sefaz.nfe.GOConsultaCad2.CadConsultaCadastro2();
                            consulta.nfeCabecMsgValue = new br.gov.go.sefaz.nfe.GOConsultaCad2.nfeCabecMsg()
                            {
                                cUF = cd_ufConsulta,
                                versaoDados = "2.00"
                            };
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.cadConsultaCadastro2(nfeDadosMsg);
                        }
                        else//4.00
                        {
                            br.gov.go.sefaz.nfe.GOConsultaCad4.CadConsultaCadastro4 consulta = new br.gov.go.sefaz.nfe.GOConsultaCad4.CadConsultaCadastro4();
                            consulta.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            consulta.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                            return consulta.consultaCadastro(nfeDadosMsg);
                        }
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public static CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor ConsultaCadClifor(string Cnpj,
                                                                                             string Cpf,
                                                                                             string Sigla_uf_consulta,
                                                                                             CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            if (((!string.IsNullOrEmpty(Cnpj)) ||
                (!string.IsNullOrEmpty(Cpf))) &&
                (!string.IsNullOrEmpty(Sigla_uf_consulta)))
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<ConsCad xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"2.00\">");
                xml.Append("<infCons>");
                xml.Append("<xServ>CONS-CAD</xServ>");
                xml.Append("<UF>");
                xml.Append(Sigla_uf_consulta.Trim());
                xml.Append("</UF>");
                if (!string.IsNullOrEmpty(Cnpj))
                {
                    xml.Append("<CNPJ>");
                    xml.Append(Cnpj.SoNumero());
                    xml.Append("</CNPJ>");
                }
                else if (!string.IsNullOrEmpty(Cpf))
                {
                    xml.Append("<CPF>");
                    xml.Append(Cpf.SoNumero());
                    xml.Append("</CPF>");
                }
                xml.Append("</infCons>");
                xml.Append("</ConsCad>");
                
                //Validar Schema XML
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "consCad_v2.00.xsd",
                                                         "NFE");
                //Buscar CD.UF
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadUf().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.UF",
                                vOperador = "=",
                                vVL_Busca = "'" + Sigla_uf_consulta.Trim() + "'"
                            }
                        }, "a.cd_uf");
                if (obj == null)
                    throw new Exception("Estado inexistente!");
                //Enviar consulta para a receita
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                XmlNode retorno = ConectarWebService2(doc.DocumentElement, obj.ToString().Trim(), rCfgNfe);
                //Tratar retorno
                if (retorno != null)
                {
                    if (retorno["infCons"]["cStat"].InnerText.Trim().Equals("111"))
                    {
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd = new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                        foreach (XmlNode no in retorno["infCons"]["infCad"].ChildNodes)
                        {
                            if (no.Name.Trim().Equals("ender"))
                                foreach (XmlNode n in no.ChildNodes)
                                {
                                    if (n.Name.Trim().Equals("xLgr"))
                                        rEnd.Ds_endereco = n.InnerText;
                                    else if (n.Name.Trim().Equals("nro"))
                                        rEnd.Numero = n.InnerText;
                                    else if (n.Name.Trim().Equals("xCpl"))
                                        rEnd.Ds_complemento = n.InnerText;
                                    else if (n.Name.Trim().Equals("xBairro"))
                                        rEnd.Bairro = n.InnerText;
                                    else if (n.Name.Trim().Equals("cMun"))
                                        rEnd.Cd_cidade = n.InnerText;
                                    else if (n.Name.Trim().Equals("xMun"))
                                        rEnd.DS_Cidade = n.InnerText;
                                    else if (n.Name.Trim().Equals("CEP"))
                                        rEnd.Cep = n.InnerText;
                                }
                            else if (no.Name.Trim().Equals("CNPJ"))
                            {
                                rClifor.Nr_cgc = no.InnerText.FormatStringEsquerda(14, '0');
                                rClifor.Tp_pessoa = "J";
                            }
                            else if (no.Name.Trim().Equals("CPF"))
                            {
                                rClifor.Nr_cpf = no.InnerText.FormatStringEsquerda(11, '0');
                                rClifor.Tp_pessoa = "F";
                            }
                            else if (no.Name.Trim().Equals("xNome"))
                                rClifor.Nm_clifor = no.InnerText;
                            else if (no.Name.Trim().Equals("xFant"))
                                rClifor.Nm_fantasia = no.InnerText;
                            else if (no.Name.Trim().Equals("IE"))
                                rEnd.Insc_estadual = no.InnerText;
                        }
                        rClifor.lEndereco.Add(rEnd);
                        rClifor.Tp_pessoa = !string.IsNullOrEmpty(rClifor.Nr_cgc) ? "J" : "F";
                        return rClifor;
                    }
                    else
                        throw new Exception("Erro: " + retorno["infCons"]["cStat"].InnerText.Trim() + "-" +
                                                retorno["infCons"]["xMotivo"].InnerText.Trim());
                }
                else
                    throw new Exception("Erro consultar cadastro cliente.");
            }
            else
                return null;
        }
    }
}
