using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.ConsMDFeNaoEnc
{
    public class TConsMDFeNaoEnc
    {
        private static XmlNode ConectarWebService(XmlNode evDadosMsg,
                                                  TRegistro_CfgMDFe rCfgMdfe)
        {
            switch (rCfgMdfe.rEmp.rEndereco.Cd_uf.Trim())
            {
                case ("41")://Parana
                    {
                        if (rCfgMdfe.Tp_ambiente.Trim().Equals("1"))//Producao
                        {
                            br.gov.rs.svrs.mdfe.ConsNaoEnc.MDFeConsNaoEnc mdfe = new MDFe.br.gov.rs.svrs.mdfe.ConsNaoEnc.MDFeConsNaoEnc();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.ConsNaoEnc.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeConsNaoEnc(evDadosMsg);
                        }
                        else
                        {
                            br.gov.rs.svrs.mdfe.homolog.ConsNaoEnc.MDFeConsNaoEnc mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.ConsNaoEnc.MDFeConsNaoEnc();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.ConsNaoEnc.mdfeCabecMsg()
                            {
                                cUF = rCfgMdfe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMdfe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMdfe.Nr_certificado));
                            return mdfe.mdfeConsNaoEnc(evDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static List<CamadaDados.Frota.TRegistro_MDFe> ConsMDFeNaoEnc(TRegistro_CfgMDFe rCfgMdfe)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<consMDFeNaoEnc xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfgMdfe.Cd_versaomdfe.Trim() + "\">");
            xml.Append("<tpAmb>");
            xml.Append(rCfgMdfe.Tp_ambiente.Trim());
            xml.Append("</tpAmb>");
            xml.Append("<xServ>CONSULTAR NÃO ENCERRADOS</xServ>");
            xml.Append("<CNPJ>");
            xml.Append(rCfgMdfe.rEmp.rClifor.Nr_cgc.SoNumero());
            xml.Append("</CNPJ>");
            xml.Append("</consMDFeNaoEnc>");

            //Validar Schema XML Obs. Esta dando erro na validacao do schemas por isso foi desativado
            //Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
            //                                        rCfgMdfe.Path_schemas.SeparadorDiretorio() + "consMDFeNaoEnc_v" + rCfgMdfe.Cd_versaomdfe.Trim() + ".xsd", "MDFE");
            //if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
            //    throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMdfe);
            //Tratar retorno
            if (retorno != null)
            {
                List<CamadaDados.Frota.TRegistro_MDFe> lRet = new List<CamadaDados.Frota.TRegistro_MDFe>();
                foreach (XmlNode no in retorno.ChildNodes)
                {
                    if (no.Name.Trim().Equals("infMDFe"))
                    {
                        //Verificar se chave existe no sitema
                        CamadaDados.Frota.TList_MDFe lMdfe = CamadaNegocio.Frota.TCN_MDFe.Buscar(rCfgMdfe.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 no["chMDFe"].InnerText,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                        if (lMdfe.Count > 0)
                            lRet.Add(lMdfe[0]);
                        else
                        {
                            CamadaDados.Frota.TRegistro_MDFe rMDFe = new CamadaDados.Frota.TRegistro_MDFe();
                            rMDFe.Chaveacesso = no["chMDFe"].InnerText;
                            rMDFe.Nr_protocolo = no["nProt"].InnerText;
                            lRet.Add(rMDFe);
                        }
                    }
                }
                return lRet;
            }
            else
                throw new Exception("Ocorreu um erro ao enviar CONSULTA NÃO ENCERRADOS para receita.");
        }
    }
}
